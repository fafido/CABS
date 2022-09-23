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

Partial Class Corp_divInstrAUTH
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
            Dim cmd = New SqlCommand("SELECT DISTINCT a.company,b.Fnam FROM div_instr a join para_company b on a.company=b.Company where a.Authorize=1 and a.createdBy<>@createdBy order by b.Fnam", cn)
            cmd.Parameters.AddWithValue("@createdBy", Session("Username"))
            Dim adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "div_instr")
            If ds.Tables(0).Rows.Count > 0 Then
                cmbCompany.DataSource = ds
                cmbCompany.ValueField = "company"
                cmbCompany.TextField = "Fnam"
                cmbCompany.DataBind()
            Else
                cmbCompany.DataSource = Nothing
                cmbCompany.DataBind()
            End If
        End Using
    End Sub
    Protected Sub cmbCompany_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbCompany.SelectedIndexChanged
        getDivnumber()
        clearFields()
    End Sub
    Sub getDivnumber()
        cmbDivNo.SelectedIndex = -1
        Dim strSQL As String = ""
        strSQL = "SELECT DISTINCT a.div_no, format(a.date_payment,'MMMM-yyyy','en-us') + ' ' + a.div_type +' '+a.Instr_type +' div no. ' + convert(nvarchar(100),a.div_no) AS displayname FROM div_instr a WHERE a.Authorize=1 and a.company=@company and a.createdBy<>@createdBy order by a.div_no desc"
        Using cn = New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("connpath"))
            Dim ds As New DataSet
            Dim cmd = New SqlCommand(strSQL, cn)
            cmd.Parameters.AddWithValue("@Company", cmbCompany.Value)
            cmd.Parameters.AddWithValue("@createdBy", Session("Username"))
            Dim adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "div_instr")
            If ds.Tables(0).Rows.Count > 0 Then
                cmbDivNo.DataSource = ds
                cmbDivNo.ValueField = "div_no"
                cmbDivNo.TextField = "displayname"
                cmbDivNo.DataBind()
            Else
                cmbDivNo.DataSource = Nothing
                cmbDivNo.DataBind()
            End If
        End Using
    End Sub
    Protected Sub cmbDivNo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbDivNo.SelectedIndexChanged
        If cmbDivNo.Text <> "" Then
            getDivDetails()
        End If
    End Sub
    Sub getDivDetails()
        Dim strSQL As String = ""
        strSQL = "SELECT *,format(date_declared,'dd MMMM yyyy','en-us') as date_declared1,format(date_closed,'dd MMMM yyyy','en-us') as date_closed1,format(date_payment,'dd MMMM yyyy','en-us') as date_payment1,format(date_Yearending,'dd MMMM yyyy','en-us') as date_Yearending1,case when scrip_round='M' then 'Middle' when scrip_round='D' then 'Down' else 'Up' end as scrip_round1 FROM div_instr WHERE company=@Company and div_no=@div_no and Authorize=1 and createdBy<>@createdBy"
        Using cn = New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("connpath"))
            Dim ds As New DataSet
            Dim cmd = New SqlCommand(strSQL, cn)
            cmd.Parameters.AddWithValue("@Company", cmbCompany.Value)
            cmd.Parameters.AddWithValue("@div_no", cmbDivNo.Value)
            cmd.Parameters.AddWithValue("@createdBy", Session("Username"))
            Dim adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "div_instr")
            If ds.Tables(0).Rows.Count > 0 Then
                Dim dr As DataRow = ds.Tables(0).Rows(0)
                txtDividendType.Text = dr.Item("div_type").ToString
                txtEventType.Text = dr.Item("Instr_type").ToString
                txtDateCreated.Text = dr.Item("date_declared1").ToString
                txtDateClose.Text = dr.Item("date_closed1").ToString
                txtPaymentdate.Text = dr.Item("date_payment1").ToString
                txtYearEnding.Text = dr.Item("date_Yearending1").ToString
                txtRate.Text = dr.Item("rate").ToString
                txtBankAccount.Text = dr.Item("bank_accNo").ToString
                txtTaxRate.Text = dr.Item("TaxRate").ToString
                txtTaxAccount.Text = dr.Item("TaxBankAccount").ToString
                txtMsg1.Text = dr.Item("mess_1").ToString
                txtRound.Text = dr.Item("scrip_round1").ToString
                txtSpecieShares.Text = dr.Item("SpecieOfferShares").ToString
                txtForEvery.Text = dr.Item("SpecieforEvery").ToString
                txtSpecieNewCompany.Value = dr.Item("SpecieNewCompany").ToString
                txtScriptPrice.Text = dr.Item("scrip_price").ToString
                txtCurrency.Text = dr.Item("Currency").ToString
                If dr.Item("Instr_type").ToString = "Specie" Then
                    divSpecie1.Visible = True
                    divSpecie2.Visible = True
                    divSpecie3.Visible = True
                    divScrip1.Visible = False
                    Panel8i.Visible = False
                    divCashScrip.Visible = False
                ElseIf dr.Item("Instr_type").ToString = "Scrip" Then
                    divSpecie1.Visible = False
                    divSpecie2.Visible = False
                    divSpecie3.Visible = False
                    divScrip1.Visible = False
                    Panel8i.Visible = True
                    divCashScrip.Visible = True
                ElseIf dr.Item("Instr_type").ToString = "Option" Then
                    divSpecie1.Visible = False
                    divSpecie2.Visible = False
                    divSpecie3.Visible = False
                    divScrip1.Visible = True
                    Panel8i.Visible = True
                    divCashScrip.Visible = True
                Else
                    divSpecie1.Visible = False
                    divSpecie2.Visible = False
                    divSpecie3.Visible = False
                    divScrip1.Visible = False
                    Panel8i.Visible = True
                    divCashScrip.Visible = True
                End If
                PanelSAVE.Visible = True
            Else
                msgbox("Dividend not on authorization stage")
                clearFields()
            End If
        End Using
    End Sub
    Sub clearFields()
        txtDividendType.Text = ""
        txtEventType.Text = ""
        txtDateCreated.Text = ""
        txtDateClose.Text = ""
        txtPaymentdate.Text = ""
        txtYearEnding.Text = ""
        txtRate.Text = ""
        txtBankAccount.Text = ""
        txtTaxRate.Text = ""
        txtTaxAccount.Text = ""
        txtMsg1.Text = ""
        txtRound.Text = ""
        txtSpecieShares.Text = ""
        txtForEvery.Text = ""
        txtSpecieNewCompany.Text = ""
        txtScriptPrice.Text = ""
        txtCurrency.Text = ""
        PanelSAVE.Visible = False
        divSpecie1.Visible = False
        divSpecie2.Visible = False
        divSpecie3.Visible = False
        divScrip1.Visible = False
        divCashScrip.Visible = False
    End Sub
    Sub AuthorizeInstruction()
        If DivNoExists() = False Then
            msgbox("Dividend instruction no longer at authorization stage")
            Exit Sub
        End If
        Using cn = New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("connpath"))
            Dim stmnt As String = " DECLARE @LastAuditID numeric(18,0)=(select max(ID) FROM div_instrAuth WHERE company=@Company and div_no=@div_no) "
            stmnt = stmnt & "  UPDATE div_instr SET Authorize=2,AuthorizedBy=@createdBy WHERE company=@Company and div_no=@div_no and Authorize=1 and createdBy<>@createdBy "
            stmnt = stmnt & " UPDATE div_instrAuth SET AuthBy=@createdBy,AuthDate=GETDATE(),Authorize=2,AuthorizedBy=@createdBy WHERE ID =  @LastAuditID "
            Using cmd As New SqlCommand(stmnt, cn)
                cmd.Parameters.AddWithValue("@company", cmbCompany.Value)
                cmd.Parameters.AddWithValue("@div_no", cmbDivNo.Value)
                cmd.Parameters.AddWithValue("@createdBy", Session("Username"))
                If cn.State = ConnectionState.Open Then cn.Close()
                cn.Open()
                cmd.ExecuteNonQuery()
                cn.Close()
            End Using
        End Using
        Response.Write("<script>alert('Instruction authorized successfully') ; location.href='dividendInstrAuth.aspx'</script>")
    End Sub
    Protected Sub btnAuthorize_Click(sender As Object, e As EventArgs) Handles btnAuthorize.Click
        AuthorizeInstruction()
    End Sub
    Protected Sub btnReject_Click(sender As Object, e As EventArgs) Handles btnReject.Click
        RejectInstruction()
    End Sub
    Function DivNoExists() As Boolean
        Dim strSQL As String = ""
        strSQL = "SELECT * from div_instr where Company=@Company and div_no=@div_no and Authorize=1 and createdBy<>@createdBy"
        Using cn = New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("connpath"))
            Dim ds As New DataSet
            Dim cmd = New SqlCommand(strSQL, cn)
            cmd.Parameters.AddWithValue("@Company", cmbCompany.Value)
            cmd.Parameters.AddWithValue("@div_no", cmbDivNo.Value)
            cmd.Parameters.AddWithValue("@createdBy", Session("Username"))
            Dim adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "div_instr")
            If ds.Tables(0).Rows.Count > 0 Then
                Return True
            Else
                Return False
            End If
        End Using
    End Function
    Sub RejectInstruction()
        If DivNoExists() = False Then
            msgbox("Dividend instruction no longer at authorization stage")
            Exit Sub
        End If
        Using cn = New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("connpath"))
            Dim stmnt As String = " DECLARE @LastAuditID numeric(18,0)=(select max(ID) FROM div_instrAuth WHERE company=@Company and div_no=@div_no) "
            stmnt = stmnt & "  UPDATE div_instr SET Authorize=0,AuthorizedBy=@createdBy WHERE company=@Company and div_no=@div_no and Authorize=1 and createdBy<>@createdBy "
            stmnt = stmnt & " UPDATE div_instrAuth SET AuthBy=@createdBy,AuthDate=GETDATE(),Authorize=0,AuthorizedBy=@createdBy WHERE ID =  @LastAuditID "
            Using cmd As New SqlCommand(stmnt, cn)
                cmd.Parameters.AddWithValue("@company", cmbCompany.Value)
                cmd.Parameters.AddWithValue("@div_no", cmbDivNo.Value)
                cmd.Parameters.AddWithValue("@createdBy", Session("Username"))
                If cn.State = ConnectionState.Open Then cn.Close()
                cn.Open()
                cmd.ExecuteNonQuery()
                cn.Close()
            End Using
        End Using
        Response.Write("<script>alert('Instruction has been rejected') ; location.href='dividendInstrAuth.aspx'</script>")
    End Sub
End Class
