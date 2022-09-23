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

Partial Class Corp_RightsInstr
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
    Sub getCurrencies()
        Using cn = New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("connpath"))
            Dim ds As New DataSet
            Dim cmd = New SqlCommand("select * from para_currencies order by CurrencyCode", cn)
            Dim adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "para_currencies")
            If ds.Tables(0).Rows.Count > 0 Then
                cmbCurrency.DataSource = ds
                cmbCurrency.ValueField = "CurrencyCode"
                cmbCurrency.TextField = "CurrencyCode"
                cmbCurrency.DataBind()
            Else
                cmbCurrency.DataSource = Nothing
                cmbCurrency.DataBind()
            End If
        End Using
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Page.MaintainScrollPositionOnPostBack = True
            If (Not IsPostBack) Then
                getCompanies()
                getBanks()
                getCurrencies()
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
            Else
                cmbCompany.DataSource = Nothing
                cmbCompany.DataBind()
            End If
        End Using
    End Sub
    Protected Sub cmbCompany_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbCompany.SelectedIndexChanged
        getNextDivnumber()
    End Sub
    Sub getNextDivnumber()
        Dim strSQL As String = ""
        strSQL = "SELECT ISNULL(MAX(div_no),0)+1 as NextDivNo FROM Rights_instr WHERE company=@Company"
        Using cn = New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("connpath"))
            Dim ds As New DataSet
            Dim cmd = New SqlCommand(strSQL, cn)
            cmd.Parameters.AddWithValue("@Company", cmbCompany.Value)
            Dim adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "Rights_instr")
            If ds.Tables(0).Rows.Count > 0 Then
                txtIssueNo.Text = ds.Tables(0).Rows(0).Item("NextDivNo").ToString
            Else
                txtIssueNo.Text = "0"
            End If
        End Using
    End Sub
    Protected Sub chkEdit_CheckedChanged(sender As Object, e As EventArgs) Handles chkEdit.CheckedChanged
        If chkEdit.Checked = True Then
            getDivList()
            paneldivList.Visible = True
            btnDivsearch.Visible = False
        Else
            lstDivs.Items.Clear()
            lstDivs.DataSource = Nothing
            lstDivs.DataBind()
            paneldivList.Visible = False
            btnDivsearch.Visible = False
        End If
    End Sub
    Sub getDivList()
        Using cn = New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("connpath"))
            Dim ds As New DataSet
            Dim cmd = New SqlCommand("SELECT DISTINCT a.div_no, format(a.date_payment,'MMMM-yyyy','en-us') + ' issue no. ' + convert(nvarchar(100),a.div_no) AS displayname FROM Rights_Instr a WHERE a.COMPANY=@Company order by a.div_no desc", cn)
            cmd.Parameters.AddWithValue("@Company", cmbCompany.Value)
            Dim adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "div_instr")
            If ds.Tables(0).Rows.Count > 0 Then
                lstDivs.DataSource = ds
                lstDivs.ValueField = "div_no"
                lstDivs.TextField = "displayname"
                lstDivs.DataBind()
            Else
                lstDivs.DataSource = Nothing
                lstDivs.DataBind()
            End If
        End Using
    End Sub
    Protected Sub lstDivs_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstDivs.SelectedIndexChanged
        Try
            txtIssueNo.Text = lstDivs.Value
            btnDivsearch_Click(sender:=New Object, e:=New EventArgs)
        Catch ex As Exception
            msgbox(ex.Message.ToString)
        End Try
    End Sub
    Protected Sub btnDivsearch_Click(sender As Object, e As EventArgs) Handles btnDivsearch.Click
        Dim strSQL As String = ""
        strSQL = "SELECT *,format(date_declared,'dd MMMM yyyy','en-us') as date_declared1,format(date_closed,'dd MMMM yyyy','en-us') as date_closed1,format(date_payment,'dd MMMM yyyy','en-us') as date_payment1,format(date_Yearending,'dd MMMM yyyy','en-us') as date_Yearending1 FROM Rights_instr WHERE company=@Company and div_no=@div_no"
        Using cn = New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("connpath"))
            Dim ds As New DataSet
            Dim cmd = New SqlCommand(strSQL, cn)
            cmd.Parameters.AddWithValue("@Company", cmbCompany.Value)
            cmd.Parameters.AddWithValue("@div_no", txtIssueNo.Text)
            Dim adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "Rights_instr")
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
                    txtRate.Text = dr.Item("rate").ToString
                    txtMsg1.Text = dr.Item("mess_1").ToString
                    Try
                        cmbRound.Value = dr.Item("scrip_round").ToString
                    Catch ex As Exception
                        cmbRound.SelectedIndex = 0
                    End Try
                    txtSpecieShares.Text = dr.Item("SpecieOfferShares").ToString
                    txtForEvery.Text = dr.Item("SpecieforEvery").ToString
                    txtAccount.Text = dr.Item("AccountNo").ToString
                    txtBranch.Text = dr.Item("Branch").ToString
                    Try
                        cmbBank.Value = dr.Item("Bank").ToString
                    Catch ex As Exception
                        cmbBank.SelectedIndex = 0
                    End Try
                    Try
                        cmbCurrency.Value = dr.Item("Currency").ToString
                    Catch ex As Exception
                        cmbCurrency.SelectedIndex = 0
                    End Try
                    PanelSAVE.Visible = False
                    panelUPDATE.Visible = True
                ElseIf Auth = 1 Then
                    msgbox("Issue number " & txtIssueNo.Text & " at Authorization stage,proceed to reject it or contact Admin for reflagging to be able to update it")
                    clearFields()
                ElseIf Auth = 2 Then
                    msgbox("Issue number " & txtIssueNo.Text & " at Computation stage, contact Admin for reflagging")
                    clearFields()
                ElseIf Auth = 3 Then
                    msgbox("Issue number " & txtIssueNo.Text & " already Computed, contact Admin for reflagging")
                    clearFields()
                ElseIf Auth = 4 Then
                    msgbox("Issue number " & txtIssueNo.Text & " already Computed/Paid, contact Admin for reflagging")
                    clearFields()
                End If
            Else
                msgbox("Invalid Issue number " & txtIssueNo.Text)
                clearFields()
            End If
        End Using
    End Sub
    Sub clearFields()
        txtDateClose.Text = ""
        txtPaymentDate.Text = ""
        txtRate.Text = ""
        txtMsg1.Text = ""
        cmbRound.SelectedIndex = 0
        txtSpecieShares.Text = ""
        txtForEvery.Text = ""
        PanelSAVE.Visible = True
        panelUPDATE.Visible = False
        chkEdit.Checked = False
        chkEdit_CheckedChanged(sender:=New Object, e:=New EventArgs)
        txtAccount.Text = ""
        txtBranch.Text = ""
        cmbBank.SelectedIndex = -1
        cmbCurrency.SelectedIndex = -1
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
        If IsNumeric(txtRate.Text) = False Then
            msgbox("Enter Price per share")
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
        If DivNoExists() = True Then
            msgbox("Issue number already exists")
            Exit Sub
        End If
        Dim BankDiv As String = ""
        If (cmbBank.Text.Trim <> "") Then
            BankDiv = cmbBank.Value
        Else
            BankDiv = ""
        End If
        If cmbCurrency.Text = "" Then
            msgbox("Enter Currency")
            Exit Sub
        End If
        Using cn = New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("connpath"))
            Dim stmnt As String = " INSERT INTO Rights_instr(Currency,Bank,Branch,AccountNo,Authorize,company,div_no,div_type,date_declared,date_closed,date_payment,date_Yearending,rate,TaxRate,bank_accNo,TaxBankAccount,mess_1,scrip_round,SpecieOfferShares,SpecieforEvery,SpecieNewCompany,scrip_price,createdBy)values(@Currency,@Bank,@Branch,@AccountNo,1,@company,@div_no,@div_type,GETDATE(),@date_closed,@date_payment,GETDATE(),@rate,@TaxRate,@bank_accNo,@TaxBankAccount,@mess_1,@scrip_round,@SpecieOfferShares,@SpecieforEvery,@SpecieNewCompany,@scrip_price,@createdBy) "
            Dim stmntAUDIT As String = " INSERT INTO Rights_instrAuth(Currency,Bank,Branch,AccountNo,Authorize,company,div_no,div_type,date_declared,date_closed,date_payment,date_Yearending,rate,TaxRate,bank_accNo,TaxBankAccount,mess_1,scrip_round,SpecieOfferShares,SpecieforEvery,SpecieNewCompany,scrip_price,createdBy)values(@Currency,@Bank,@Branch,@AccountNo,1,@company,@div_no,@div_type,GETDATE(),@date_closed,@date_payment,GETDATE(),@rate,@TaxRate,@bank_accNo,@TaxBankAccount,@mess_1,@scrip_round,@SpecieOfferShares,@SpecieforEvery,@SpecieNewCompany,@scrip_price,@createdBy) "
            Using cmd As New SqlCommand(stmnt & stmntAUDIT, cn)
                cmd.Parameters.AddWithValue("@company", cmbCompany.Value)
                cmd.Parameters.AddWithValue("@div_no", txtIssueNo.Text)
                cmd.Parameters.AddWithValue("@div_type", "FINAL")
                cmd.Parameters.AddWithValue("@date_closed", validateDate(txtDateClose.Text))
                cmd.Parameters.AddWithValue("@date_payment", validateDate(txtPaymentDate.Text))
                cmd.Parameters.AddWithValue("@rate", txtRate.Text)
                cmd.Parameters.AddWithValue("@TaxRate", "0")
                cmd.Parameters.AddWithValue("@bank_accNo", " ")
                cmd.Parameters.AddWithValue("@TaxBankAccount", " ")
                cmd.Parameters.AddWithValue("@mess_1", txtMsg1.Text)
                cmd.Parameters.AddWithValue("@scrip_round", cmbRound.Value)
                cmd.Parameters.AddWithValue("@SpecieOfferShares", specieShares)
                cmd.Parameters.AddWithValue("@SpecieforEvery", specieForEvery)
                cmd.Parameters.AddWithValue("@SpecieNewCompany", specieNewCompany)
                cmd.Parameters.AddWithValue("@scrip_price", ScriptPrice)
                cmd.Parameters.AddWithValue("@createdBy", Session("Username"))
                cmd.Parameters.AddWithValue("@Bank", BankDiv)
                cmd.Parameters.AddWithValue("@Branch", txtBranch.Text)
                cmd.Parameters.AddWithValue("@AccountNo", txtAccount.Text)
                cmd.Parameters.AddWithValue("@Currency", cmbCurrency.Text)
                If cn.State = ConnectionState.Open Then cn.Close()
                cn.Open()
                cmd.ExecuteNonQuery()
                cn.Close()
            End Using
        End Using
        Response.Write("<script>alert('Instruction saved, pending authorization') ; location.href='RightsInstr.aspx'</script>")
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
        strSQL = "SELECT * from Rights_instr where Company=@Company and div_no=@div_no"
        Using cn = New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("connpath"))
            Dim ds As New DataSet
            Dim cmd = New SqlCommand(strSQL, cn)
            cmd.Parameters.AddWithValue("@Company", cmbCompany.Value)
            cmd.Parameters.AddWithValue("@div_no", txtIssueNo.Text)
            Dim adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "Rights_instr")
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
        If IsNumeric(txtRate.Text) = False Then
            msgbox("Enter Price per share")
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
            msgbox("Issue number does not exists")
            Exit Sub
        End If
        Dim BankDiv As String = ""
        If (cmbBank.Text.Trim <> "") Then
            BankDiv = cmbBank.Value
        Else
            BankDiv = ""
        End If
        If cmbCurrency.Text = "" Then
            msgbox("Enter Currency")
            Exit Sub
        End If
        Using cn = New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("connpath"))
            Dim stmnt As String = " UPDATE Rights_instr SET Currency=@Currency,Bank=@Bank,Branch=@Branch,AccountNo=@AccountNo,date_payment=@date_payment,Authorize=1,div_type=@div_type,date_closed=@date_closed,rate=@rate,TaxRate=@TaxRate,bank_accNo=@bank_accNo,TaxBankAccount=@TaxBankAccount,mess_1=@mess_1,scrip_round=@scrip_round,SpecieOfferShares=@SpecieOfferShares,SpecieforEvery=@SpecieforEvery,SpecieNewCompany=@SpecieNewCompany,scrip_price=@scrip_price,createdBy=@createdBy WHERE company=@company AND div_no=@div_no "
            Dim stmntAUDIT As String = " INSERT INTO Rights_instrAuth(Currency,Bank,Branch,AccountNo,Authorize,company,div_no,div_type,date_declared,date_closed,date_payment,date_Yearending,rate,TaxRate,bank_accNo,TaxBankAccount,mess_1,scrip_round,SpecieOfferShares,SpecieforEvery,SpecieNewCompany,scrip_price,createdBy)values(@Currency,@Bank,@Branch,@AccountNo,1,@company,@div_no,@div_type,GETDATE(),@date_closed,@date_payment,GETDATE(),@rate,@TaxRate,@bank_accNo,@TaxBankAccount,@mess_1,@scrip_round,@SpecieOfferShares,@SpecieforEvery,@SpecieNewCompany,@scrip_price,@createdBy) "
            Using cmd As New SqlCommand(stmnt & stmntAUDIT, cn)
                cmd.Parameters.AddWithValue("@company", cmbCompany.Value)
                cmd.Parameters.AddWithValue("@div_no", txtIssueNo.Text)
                cmd.Parameters.AddWithValue("@div_type", "FINAL")
                cmd.Parameters.AddWithValue("@date_closed", validateDate(txtDateClose.Text))
                cmd.Parameters.AddWithValue("@date_payment", validateDate(txtPaymentDate.Text))
                cmd.Parameters.AddWithValue("@rate", txtRate.Text)
                cmd.Parameters.AddWithValue("@TaxRate", "0")
                cmd.Parameters.AddWithValue("@bank_accNo", " ")
                cmd.Parameters.AddWithValue("@TaxBankAccount", " ")
                cmd.Parameters.AddWithValue("@mess_1", txtMsg1.Text)
                cmd.Parameters.AddWithValue("@scrip_round", cmbRound.Value)
                cmd.Parameters.AddWithValue("@SpecieOfferShares", specieShares)
                cmd.Parameters.AddWithValue("@SpecieforEvery", specieForEvery)
                cmd.Parameters.AddWithValue("@SpecieNewCompany", specieNewCompany)
                cmd.Parameters.AddWithValue("@scrip_price", ScriptPrice)
                cmd.Parameters.AddWithValue("@createdBy", Session("Username"))
                cmd.Parameters.AddWithValue("@Bank", BankDiv)
                cmd.Parameters.AddWithValue("@Branch", txtBranch.Text)
                cmd.Parameters.AddWithValue("@AccountNo", txtAccount.Text)
                cmd.Parameters.AddWithValue("@Currency", cmbCurrency.Text)
                If cn.State = ConnectionState.Open Then cn.Close()
                cn.Open()
                cmd.ExecuteNonQuery()
                cn.Close()
            End Using
        End Using
        Response.Write("<script>alert('Instruction updated, pending authorization') ; location.href='RightsInstr.aspx'</script>")
    End Sub
    Sub getBanks()
        Using cn = New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("connpath"))
            Dim ds As New DataSet
            Dim cmd = New SqlCommand("SELECT ISNULL(BANK,'') +'|'+ ISNULL(bank_name,'') AS DispName,bank FROM para_bank ORDER BY DispName", cn)
            Dim adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "para_bank")
            If ds.Tables(0).Rows.Count > 0 Then
                cmbBank.DataSource = ds
                cmbBank.ValueField = "bank"
                cmbBank.TextField = "DispName"
                cmbBank.DataBind()
            Else
                cmbBank.DataSource = Nothing
                cmbBank.DataBind()
            End If
        End Using
    End Sub
End Class
