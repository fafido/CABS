Imports System.Net.Mail
Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Imports System
Imports System.Configuration
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls
Imports System.Web.Services

Partial Class Corp_DeMergerInstr
    Inherits System.Web.UI.Page
    Public Sub msgbox(ByVal strMessage As String)

        'finishes server processing, returns to client.
        Dim strScript As String = "<script language=JavaScript>"
        strScript += "window.alert(""" & strMessage & """);"
        strScript += "</script>"
        Dim lbl As New System.Web.UI.WebControls.Label
        lbl.Text = strScript
        Page.Controls.Add(lbl)
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Page.MaintainScrollPositionOnPostBack = True
            If (Not IsPostBack) Then
                getCompanies()
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Sub getCompanies()
        Using cn = New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("connpath"))
            Dim ds As New DataSet
            Dim cmd = New SqlCommand("select * from para_company order by fnam", cn)
            Dim adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "para_company")
            If ds.Tables(0).Rows.Count > 0 Then
                cmbCompany.DataSource = ds
                cmbCompany.ValueField = "Company"
                cmbCompany.TextField = "fnam"
                cmbCompany.DataBind()

                cmbNewCompany.DataSource = ds
                cmbNewCompany.ValueField = "Company"
                cmbNewCompany.TextField = "fnam"
                cmbNewCompany.DataBind()
            Else
                cmbCompany.DataSource = Nothing
                cmbCompany.DataBind()

                cmbNewCompany.DataSource = Nothing
                cmbNewCompany.DataBind()
            End If
        End Using
    End Sub
    Protected Sub cmbCompany_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbCompany.SelectedIndexChanged
        getNextDivnumber()
    End Sub
    Sub getNextDivnumber()
        Dim strSQL As String = ""
        strSQL = "SELECT ISNULL(MAX(div_no),0)+1 as NextDivNo FROM DeMerger_instr WHERE company=@Company"
        Using cn = New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("connpath"))
            Dim ds As New DataSet
            Dim cmd = New SqlCommand(strSQL, cn)
            cmd.Parameters.AddWithValue("@Company", cmbCompany.Value)
            Dim adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "DeMerger_instr")
            If ds.Tables(0).Rows.Count > 0 Then
                txtIssueNo.Text = ds.Tables(0).Rows(0).Item("NextDivNo").ToString
            Else
                txtIssueNo.Text = "0"
            End If
        End Using
    End Sub
    Protected Sub chkEdit_CheckedChanged(sender As Object, e As EventArgs) Handles chkEdit.CheckedChanged
        If chkEdit.Checked = True Then
            txtIssueNo.Enabled = True
            btnDivsearch.Visible = True
        Else
            txtIssueNo.Enabled = False
            btnDivsearch.Visible = False
        End If
    End Sub
    Protected Sub btnDivsearch_Click(sender As Object, e As EventArgs) Handles btnDivsearch.Click
        Dim strSQL As String = ""
        strSQL = "SELECT *,format(date_declared,'dd MMMM yyyy','en-us') as date_declared1,format(date_closed,'dd MMMM yyyy','en-us') as date_closed1,format(date_payment,'dd MMMM yyyy','en-us') as date_payment1,format(date_Yearending,'dd MMMM yyyy','en-us') as date_Yearending1 FROM DeMerger_instr WHERE company=@Company and div_no=@div_no"
        Using cn = New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("connpath"))
            Dim ds As New DataSet
            Dim cmd = New SqlCommand(strSQL, cn)
            cmd.Parameters.AddWithValue("@Company", cmbCompany.Value)
            cmd.Parameters.AddWithValue("@div_no", txtIssueNo.Text)
            Dim adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "DeMerger_instr")
            If ds.Tables(0).Rows.Count > 0 Then
                Dim dr As DataRow = ds.Tables(0).Rows(0)
                Dim Auth As Integer = 0
                Try
                    Auth = CInt(dr.Item("Authorize"))
                Catch ex As Exception
                    Auth = 0
                End Try
                If Auth = 0 Then
                    txtDateClose.Text = dr.Item("date_closed1").ToString
                    txtPaymentDate.Text = dr.Item("date_payment1").ToString
                    txtMsg1.Text = dr.Item("mess_1").ToString
                    Try
                        cmbRound.Value = dr.Item("scrip_round").ToString
                    Catch ex As Exception
                        cmbRound.SelectedIndex = 0
                    End Try
                    txtSpecieShares.Text = dr.Item("SpecieOfferShares").ToString
                    txtForEvery.Text = dr.Item("SpecieforEvery").ToString
                    Try
                        cmbNewCompany.Value = dr.Item("SpecieNewCompany").ToString
                    Catch ex As Exception
                        cmbNewCompany.SelectedIndex = 0
                    End Try
                    PanelSAVE.Visible = False
                    panelUPDATE.Visible = True
                ElseIf Auth = 1 Then
                    msgbox("DeMerger Instruction No. " & txtIssueNo.Text & " at Authorization stage,proceed to reject it or contact Admin for reflagging to be able to update it")
                    clearFields()
                ElseIf Auth = 2 Then
                    msgbox("DeMerger Instruction No. " & txtIssueNo.Text & " at Computation stage, contact Admin for reflagging")
                    clearFields()
                ElseIf Auth = 3 Then
                    msgbox("DeMerger Instruction No. " & txtIssueNo.Text & " already Computed, contact Admin for reflagging")
                    clearFields()
                ElseIf Auth = 4 Then
                    msgbox("DeMerger Instruction No. " & txtIssueNo.Text & " already Computed/Posted, contact Admin for reflagging")
                    clearFields()
                End If
            Else
                msgbox("Invalid DeMerger Instruction No. " & txtIssueNo.Text)
                clearFields()
            End If
        End Using
    End Sub
    Sub clearFields()
        txtDateClose.Text = ""
        txtPaymentDate.Text = ""
        txtMsg1.Text = ""
        cmbRound.SelectedIndex = 0
        txtSpecieShares.Text = ""
        txtForEvery.Text = ""
        PanelSAVE.Visible = True
        panelUPDATE.Visible = False
        chkEdit.Checked = False
        chkEdit_CheckedChanged(sender:=New Object, e:=New EventArgs)
        getNextDivnumber()
    End Sub
    Function validateDate(inp As String) As Object
        'Return IIf(IsNumeric(toMoney(inp)), DBNull.Value, inp)
        Return IIf(Trim(inp) = "" Or Not IsDate(inp), DBNull.Value, inp)
    End Function
    Sub saveInstruction()
        If IsDate(txtDateClose.Text) = False Then
            msgbox("Select Record date")
            Exit Sub
        End If
        If IsDate(txtPaymentDate.Text) = False Then
            msgbox("Select Payment date")
            Exit Sub
        End If
        If cmbRound.Text = "" Then
            msgbox("Select Round")
            Exit Sub
        End If
        If cmbNewCompany.Text = "" Then
            msgbox("Select New Company")
            Exit Sub
        End If
        If cmbNewCompany.Text = cmbCompany.Text Then
            msgbox("New company should be different from old company")
            Exit Sub
        End If
        Dim specieShares As Double = 0
        Dim specieForEvery As Double = 0
        Dim specieNewCompany As String = " "
        Dim ScriptPrice As Double = 0
        If IsNumeric(txtSpecieShares.Text) = False Then
            msgbox("Enter shares")
            Exit Sub
        End If
        If IsNumeric(txtForEvery.Text) = False Then
            msgbox("Enter For Every")
            Exit Sub
        End If
        specieShares = txtSpecieShares.Text
        specieForEvery = txtForEvery.Text
        If DivNoExists() = True Then
            msgbox("DeMerger Instruction No. already exists")
            Exit Sub
        End If
        Using cn = New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("connpath"))
            Dim stmnt As String = " INSERT INTO DeMerger_instr(Authorize,company,div_no,div_type,date_declared,date_closed,date_payment,date_Yearending,rate,TaxRate,bank_accNo,TaxBankAccount,mess_1,scrip_round,SpecieOfferShares,SpecieforEvery,SpecieNewCompany,scrip_price,createdBy)values(1,@company,@div_no,@div_type,GETDATE(),@date_closed,@date_payment,GETDATE(),@rate,@TaxRate,@bank_accNo,@TaxBankAccount,@mess_1,@scrip_round,@SpecieOfferShares,@SpecieforEvery,@SpecieNewCompany,@scrip_price,@createdBy) "
            Dim stmntAUDIT As String = " INSERT INTO DeMerger_instrAuth(Authorize,company,div_no,div_type,date_declared,date_closed,date_payment,date_Yearending,rate,TaxRate,bank_accNo,TaxBankAccount,mess_1,scrip_round,SpecieOfferShares,SpecieforEvery,SpecieNewCompany,scrip_price,createdBy)values(1,@company,@div_no,@div_type,GETDATE(),@date_closed,@date_payment,GETDATE(),@rate,@TaxRate,@bank_accNo,@TaxBankAccount,@mess_1,@scrip_round,@SpecieOfferShares,@SpecieforEvery,@SpecieNewCompany,@scrip_price,@createdBy) "
            Using cmd As New SqlCommand(stmnt & stmntAUDIT, cn)
                cmd.Parameters.AddWithValue("@company", cmbCompany.Value)
                cmd.Parameters.AddWithValue("@div_no", txtIssueNo.Text)
                cmd.Parameters.AddWithValue("@div_type", "FINAL")
                cmd.Parameters.AddWithValue("@date_closed", validateDate(txtDateClose.Text))
                cmd.Parameters.AddWithValue("@date_payment", validateDate(txtPaymentDate.Text))
                cmd.Parameters.AddWithValue("@rate", "0")
                cmd.Parameters.AddWithValue("@TaxRate", "0")
                cmd.Parameters.AddWithValue("@bank_accNo", " ")
                cmd.Parameters.AddWithValue("@TaxBankAccount", " ")
                cmd.Parameters.AddWithValue("@mess_1", txtMsg1.Text)
                cmd.Parameters.AddWithValue("@scrip_round", cmbRound.Value)
                cmd.Parameters.AddWithValue("@SpecieOfferShares", specieShares)
                cmd.Parameters.AddWithValue("@SpecieforEvery", specieForEvery)
                cmd.Parameters.AddWithValue("@SpecieNewCompany", cmbNewCompany.Value)
                cmd.Parameters.AddWithValue("@scrip_price", ScriptPrice)
                cmd.Parameters.AddWithValue("@createdBy", Session("Username"))
                If cn.State = ConnectionState.Open Then cn.Close()
                cn.Open()
                cmd.ExecuteNonQuery()
                cn.Close()
            End Using
        End Using
        Response.Write("<script>alert('Instruction saved, pending authorization') ; location.href='DeMergerInstr.aspx'</script>")
    End Sub
    Function validateNumeric(inp As String) As Object
        'Return IIf(IsNumeric(toMoney(inp)), DBNull.Value, inp)
        inp = inp.Replace(",", "")
        Return IIf(IsNumeric(Trim(inp)) = False, 0, inp)
    End Function

    Protected Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        saveInstruction()
    End Sub
    Protected Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        UpdateInstruction()
    End Sub
    Function DivNoExists() As Boolean
        Dim strSQL As String = ""
        strSQL = "SELECT * from DeMerger_instr where Company=@Company and div_no=@div_no"
        Using cn = New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("connpath"))
            Dim ds As New DataSet
            Dim cmd = New SqlCommand(strSQL, cn)
            cmd.Parameters.AddWithValue("@Company", cmbCompany.Value)
            cmd.Parameters.AddWithValue("@div_no", txtIssueNo.Text)
            Dim adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "DeMerger_instr")
            If ds.Tables(0).Rows.Count > 0 Then
                Return True
            Else
                Return False
            End If
        End Using
    End Function
    Sub UpdateInstruction()
        If IsDate(txtDateClose.Text) = False Then
            msgbox("Select Record date")
            Exit Sub
        End If
        If IsDate(txtPaymentDate.Text) = False Then
            msgbox("Select Payment date")
            Exit Sub
        End If
        If cmbRound.Text = "" Then
            msgbox("Select Round")
            Exit Sub
        End If
        Dim specieShares As Double = 0
        Dim specieForEvery As Double = 0
        Dim specieNewCompany As String = " "
        Dim ScriptPrice As Double = 0
        If IsNumeric(txtSpecieShares.Text) = False Then
            msgbox("Enter shares")
            Exit Sub
        End If
        If IsNumeric(txtForEvery.Text) = False Then
            msgbox("Enter For Every")
            Exit Sub
        End If
        specieShares = txtSpecieShares.Text
        specieForEvery = txtForEvery.Text
        If DivNoExists() = False Then
            msgbox("Merger Instruction No. does not exists")
            Exit Sub
        End If
        If cmbNewCompany.Text = "" Then
            msgbox("Select New Company")
            Exit Sub
        End If
        If cmbNewCompany.Text = cmbCompany.Text Then
            msgbox("New company should be different from old company")
            Exit Sub
        End If
        Using cn = New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("connpath"))
            Dim stmnt As String = " UPDATE DeMerger_instr SET date_payment=@date_payment,Authorize=1,div_type=@div_type,date_closed=@date_closed,rate=@rate,TaxRate=@TaxRate,bank_accNo=@bank_accNo,TaxBankAccount=@TaxBankAccount,mess_1=@mess_1,scrip_round=@scrip_round,SpecieOfferShares=@SpecieOfferShares,SpecieforEvery=@SpecieforEvery,SpecieNewCompany=@SpecieNewCompany,scrip_price=@scrip_price,createdBy=@createdBy WHERE company=@company AND div_no=@div_no "
            Dim stmntAUDIT As String = " INSERT INTO DeMerger_instrAuth(Authorize,company,div_no,div_type,date_declared,date_closed,date_payment,date_Yearending,rate,TaxRate,bank_accNo,TaxBankAccount,mess_1,scrip_round,SpecieOfferShares,SpecieforEvery,SpecieNewCompany,scrip_price,createdBy)values(1,@company,@div_no,@div_type,GETDATE(),@date_closed,@date_payment,GETDATE(),@rate,@TaxRate,@bank_accNo,@TaxBankAccount,@mess_1,@scrip_round,@SpecieOfferShares,@SpecieforEvery,@SpecieNewCompany,@scrip_price,@createdBy) "
            Using cmd As New SqlCommand(stmnt & stmntAUDIT, cn)
                cmd.Parameters.AddWithValue("@company", cmbCompany.Value)
                cmd.Parameters.AddWithValue("@div_no", txtIssueNo.Text)
                cmd.Parameters.AddWithValue("@div_type", "FINAL")
                cmd.Parameters.AddWithValue("@date_closed", validateDate(txtDateClose.Text))
                cmd.Parameters.AddWithValue("@date_payment", validateDate(txtPaymentDate.Text))
                cmd.Parameters.AddWithValue("@rate", "0")
                cmd.Parameters.AddWithValue("@TaxRate", "0")
                cmd.Parameters.AddWithValue("@bank_accNo", " ")
                cmd.Parameters.AddWithValue("@TaxBankAccount", " ")
                cmd.Parameters.AddWithValue("@mess_1", txtMsg1.Text)
                cmd.Parameters.AddWithValue("@scrip_round", cmbRound.Value)
                cmd.Parameters.AddWithValue("@SpecieOfferShares", specieShares)
                cmd.Parameters.AddWithValue("@SpecieforEvery", specieForEvery)
                cmd.Parameters.AddWithValue("@SpecieNewCompany", cmbNewCompany.Value)
                cmd.Parameters.AddWithValue("@scrip_price", ScriptPrice)
                cmd.Parameters.AddWithValue("@createdBy", Session("Username"))
                If cn.State = ConnectionState.Open Then cn.Close()
                cn.Open()
                cmd.ExecuteNonQuery()
                cn.Close()
            End Using
        End Using
        Response.Write("<script>alert('Instruction updated, pending authorization') ; location.href='DeMergerInstr.aspx'</script>")
    End Sub
End Class
