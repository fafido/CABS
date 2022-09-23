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
Imports System.Collections.Generic
Imports DevExpress.Web.ASPxEditors
Imports DevExpress.Web.ASPxGridView

Partial Class Corp_DivOption
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
            Dim cmd = New SqlCommand("SELECT DISTINCT a.company,b.Fnam FROM div_instr a join para_company b on a.company=b.Company where a.Authorize=3 and a.Instr_type='Option' order by b.Fnam", cn)
            Dim adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "Div_instr")
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
        clearFields()
        getDivnumber()
    End Sub
    Sub getDivnumber()
        cmbDivNo.SelectedIndex = -1
        Dim strSQL As String = ""
        strSQL = "SELECT DISTINCT a.div_no, format(a.date_payment,'MMMM-yyyy','en-us') + ' ' + a.div_type +' '+a.Instr_type +' div no. ' + convert(nvarchar(100),a.div_no) AS displayname FROM div_instr a WHERE a.Authorize=3 and a.company=@company and a.Instr_type='Option' order by a.div_no desc"
        Using cn = New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("connpath"))
            Dim ds As New DataSet
            Dim cmd = New SqlCommand(strSQL, cn)
            cmd.Parameters.AddWithValue("@Company", cmbCompany.Value)
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
        getDivDetails()
    End Sub
    Sub getDivDetails()
        clearFields()
        Dim strSQL As String = ""
        strSQL = "SELECT *,format(date_declared,'dd MMMM yyyy','en-us') as date_declared1,format(date_closed,'dd MMMM yyyy','en-us') as date_closed1,format(date_payment,'dd MMMM yyyy','en-us') as date_payment1,format(date_Yearending,'dd MMMM yyyy','en-us') as date_Yearending1,case when scrip_round='M' then 'Middle' when scrip_round='D' then 'Down' else 'Up' end as scrip_round1 FROM div_instr WHERE company=@Company and div_no=@div_no"
        Using cn = New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("connpath"))
            Dim ds As New DataSet
            Dim cmd = New SqlCommand(strSQL, cn)
            cmd.Parameters.AddWithValue("@Company", cmbCompany.Value)
            cmd.Parameters.AddWithValue("@div_no", cmbDivNo.Value)
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
                getDividendData()
            Else
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
        divSpecie1.Visible = False
        divSpecie2.Visible = False
        divSpecie3.Visible = False
        divScrip1.Visible = False
        divCashScrip.Visible = False
        grdPaymentsOption.DataSource = Nothing
        grdPaymentsOption.DataBind()
        grdPaymentsOption.Visible = False
        chkSelectAll.Checked = False
        chkSelectAll.Enabled = True
    End Sub
    Sub getDividendData()
        Dim strSQL As String = " "
        If txtEventType.Text = "Option" Then
            strSQL = "SELECT a.*,isnull(c.PaidAmount,0) as PaidAmount,a.offer_cash-isnull(c.PaidAmount,0) as RemainingAmount,a.actual_shares-isnull(c.PaidShares,0) as RemainingShares FROM dividend a left outer join (SELECT b.company,b.Div_No,b.Shareholder,b.AssetManager,sum(b.AmountPaid) as PaidAmount,sum(b.Shares) as PaidShares FROM DivPayments b WHERE ISNULL(b.Authorized,0) in (0,1) group by b.company,b.Div_No,b.Shareholder,b.AssetManager) c On a.company=c.Company and a.div_no=c.Div_No and a.shareholder=c.Shareholder and a.AssetManager=c.AssetManager where a.company=@Company and a.div_no=@divNo AND isnull(c.PaidShares,0)=0 Order by RemainingAmount desc"
        Else
            strSQL = "SELECT * FROM dividend where company=@Company and div_no=@divNo Order by actual_nett desc"
        End If

        Using cn = New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("connpath"))
            Dim ds As New DataSet
            Dim cmd = New SqlCommand(strSQL, cn)
            cmd.Parameters.AddWithValue("@Company", cmbCompany.Value)
            cmd.Parameters.AddWithValue("@divNo", cmbDivNo.Value)
            Dim adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "dividend")
            If ds.Tables(0).Rows.Count > 0 Then
                grdPaymentsOption.DataSource = ds
                grdPaymentsOption.DataBind()
                grdPaymentsOption.Visible = True
                chkSelectAll.Enabled = True
                chkSelectAll.Checked = False
            Else
                grdPaymentsOption.DataSource = Nothing
                grdPaymentsOption.DataBind()
                grdPaymentsOption.Visible = False
            End If
        End Using
    End Sub
    Protected Sub chkSelectAll_CheckedChanged(sender As Object, e As EventArgs) Handles chkSelectAll.CheckedChanged
        Dim myGridView As New ASPxGridView
        myGridView = grdPaymentsOption

        If chkSelectAll.Checked = True Then
            Dim keys As List(Of Object) = myGridView.GetCurrentPageRowValues(New String() {"SEQ"})
            For Each key As Object In keys
                Dim chk As ASPxCheckBox = TryCast(myGridView.FindRowCellTemplateControlByKey(key, TryCast(myGridView.Columns("Selec"), GridViewDataColumn), "chk1"), ASPxCheckBox)
                chk.Checked = True
            Next
        Else
            Dim keys As List(Of Object) = myGridView.GetCurrentPageRowValues(New String() {"SEQ"})
            For Each key As Object In keys
                Dim chk As ASPxCheckBox = TryCast(myGridView.FindRowCellTemplateControlByKey(key, TryCast(myGridView.Columns("Selec"), GridViewDataColumn), "chk1"), ASPxCheckBox)
                chk.Checked = False
            Next
        End If
        btnCalc_Click(sender:=New Object, e:=New EventArgs)
    End Sub
    Protected Sub btnCalc_Click(sender As Object, e As EventArgs) Handles btnCalc.Click
        If txtEventType.Text = "Option" Then
            Dim totalSharesToAccept As Long = 0
            Dim totalAmounttoAccept As Double = 0
            Dim myGridView As New ASPxGridView
            myGridView = grdPaymentsOption
            Dim keys As List(Of Object) = myGridView.GetCurrentPageRowValues(New String() {"SEQ"})
            For Each key As Object In keys
                If TryCast(myGridView.FindRowCellTemplateControlByKey(key, TryCast(myGridView.Columns("Selec"), GridViewDataColumn), "chk1"), ASPxCheckBox).Checked = True Then
                    Dim AmounttoAccept As Double = 0
                    Dim SharesToAccept As Long = 0
                    Try
                        AmounttoAccept = CDbl(TryCast(myGridView.FindRowCellTemplateControlByKey(key, TryCast(myGridView.Columns("AcceptedCashc"), GridViewDataColumn), "txtAcceptedCash"), ASPxTextBox).Text)
                    Catch ex As Exception
                    End Try
                    Try
                        SharesToAccept = CLng(TryCast(myGridView.FindRowCellTemplateControlByKey(key, TryCast(myGridView.Columns("AcceptedSharesc"), GridViewDataColumn), "txtAcceptedShares"), ASPxTextBox).Text)
                    Catch ex As Exception
                    End Try

                    totalSharesToAccept += SharesToAccept
                    totalAmounttoAccept += AmounttoAccept
                End If
            Next
            lblTotalCashSelected.Text = "Pay: " & totalAmounttoAccept.ToString("#,#.##") & " . Total Shares to Accept: " & totalSharesToAccept.ToString("#,#") & " ."
        End If
    End Sub
    Private Function ISSelectedData() As Boolean
        Dim myGridView As New ASPxGridView
        myGridView = grdPaymentsOption

        Dim SelectedCount As Long = 0
        Dim keys As List(Of Object) = myGridView.GetCurrentPageRowValues(New String() {"SEQ"})
        For Each key As Object In keys
            Dim chk As ASPxCheckBox = TryCast(myGridView.FindRowCellTemplateControlByKey(key, TryCast(myGridView.Columns("Selec"), GridViewDataColumn), "chk1"), ASPxCheckBox)
            If chk.Checked = True Then
                SelectedCount += 1
            End If
        Next
        If SelectedCount > 0 Then
            Return True
        Else
            Return False
        End If
    End Function
    Private Function SomeSelectedDataMisMatchAmountToPayOption() As Boolean
        Dim myGridView As New ASPxGridView
        If txtEventType.Text = "Option" Then
            myGridView = grdPaymentsOption
        End If

        Dim SelectedCount As Long = 0
        Dim keys As List(Of Object) = myGridView.GetCurrentPageRowValues(New String() {"SEQ"})
        For Each key As Object In keys
            If TryCast(myGridView.FindRowCellTemplateControlByKey(key, TryCast(myGridView.Columns("Selec"), GridViewDataColumn), "chk1"), ASPxCheckBox).Checked = True Then
                Dim OfferAmount As Double = 0, AmounttoAccept As Double = 0
                Dim OfferShares As Long = 0, SharesToAccept As Long = 0
                Try
                    OfferAmount = CDbl(TryCast(myGridView.FindRowCellTemplateControlByKey(key, TryCast(myGridView.Columns("offerCashc"), GridViewDataColumn), "lblofferCash"), ASPxLabel).Text)
                Catch ex As Exception
                End Try
                Try
                    OfferShares = CLng(TryCast(myGridView.FindRowCellTemplateControlByKey(key, TryCast(myGridView.Columns("offerSharesc"), GridViewDataColumn), "lblofferShares"), ASPxLabel).Text)
                Catch ex As Exception
                End Try
                Try
                    AmounttoAccept = CDbl(TryCast(myGridView.FindRowCellTemplateControlByKey(key, TryCast(myGridView.Columns("AcceptedCashc"), GridViewDataColumn), "txtAcceptedCash"), ASPxTextBox).Text)
                Catch ex As Exception
                End Try
                Try
                    SharesToAccept = CLng(TryCast(myGridView.FindRowCellTemplateControlByKey(key, TryCast(myGridView.Columns("AcceptedSharesc"), GridViewDataColumn), "txtAcceptedShares"), ASPxTextBox).Text)
                Catch ex As Exception
                End Try

                If (AmounttoAccept > 0) Then
                    If AmounttoAccept <> OfferAmount Then
                        SelectedCount += 1
                    ElseIf SharesToAccept > 0 Then
                        SelectedCount += 1
                    End If
                End If
                If (SharesToAccept > 0) Then
                    If SharesToAccept <> OfferShares Then
                        SelectedCount += 1
                    ElseIf AmounttoAccept > 0 Then
                        SelectedCount += 1
                    End If
                End If
            End If
        Next
        If SelectedCount > 0 Then
            Return True
        Else
            Return False
        End If
    End Function
    Protected Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        If cmbCompany.Text <> "" And cmbDivNo.Text <> "" Then
            If ISSelectedData() = False Then
                msgbox("Select Records to Update")
                Exit Sub
            End If
            If txtEventType.Text = "Option" Then
                If SomeSelectedDataMisMatchAmountToPayOption() = True Then
                    msgbox("Accepted value should be equal to offered value, or Accepted shares should be equal to offered shares")
                    Exit Sub
                End If
            End If
            Dim myGridView As New ASPxGridView
            myGridView = grdPaymentsOption
            Dim keys As List(Of Object) = myGridView.GetCurrentPageRowValues(New String() {"SEQ"})
            For Each key As Object In keys
                If TryCast(myGridView.FindRowCellTemplateControlByKey(key, TryCast(myGridView.Columns("Selec"), GridViewDataColumn), "chk1"), ASPxCheckBox).Checked = True Then
                    Dim AmounttoAccept As Double = 0
                    Dim SharesToAccept As Long = 0
                    Try
                        AmounttoAccept = CDbl(TryCast(myGridView.FindRowCellTemplateControlByKey(key, TryCast(myGridView.Columns("AcceptedCashc"), GridViewDataColumn), "txtAcceptedCash"), ASPxTextBox).Text)
                    Catch ex As Exception
                    End Try
                    Try
                        SharesToAccept = CLng(TryCast(myGridView.FindRowCellTemplateControlByKey(key, TryCast(myGridView.Columns("AcceptedSharesc"), GridViewDataColumn), "txtAcceptedShares"), ASPxTextBox).Text)
                    Catch ex As Exception
                    End Try
                    Dim Shareholder As String = TryCast(myGridView.FindRowCellTemplateControlByKey(key, TryCast(myGridView.Columns("shareholderc"), GridViewDataColumn), "lblshareholder"), ASPxLabel).Text
                    Dim AssetManager As String = TryCast(myGridView.FindRowCellTemplateControlByKey(key, TryCast(myGridView.Columns("AssetManagerc"), GridViewDataColumn), "lblAssetManager"), ASPxLabel).Text
                    Dim stmnt As String = "  "
                    stmnt = stmnt & " INSERT DivAcceptAudit(CreatedBy,Company,Div_no,AssetManager,Shareholder,AcceptedShares,AcceptedCash)VALUES(@CreatedBy,@Company,@Div_no,@AssetManager,@Shareholder,@actual_shares,@offer_cash) "
                    stmnt = stmnt & " update dividend set offer_cash=@offer_cash,actual_shares=@actual_shares where Company=@Company AND Div_no=@Div_no and Shareholder=@Shareholder and AssetManager=@AssetManager "
                    Using cn = New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("connpath"))
                        Using cmd As New SqlCommand(stmnt, cn)
                            cmd.CommandType = CommandType.Text
                            cmd.CommandTimeout = 0
                            cmd.Parameters.AddWithValue("@company", cmbCompany.Value)
                            cmd.Parameters.AddWithValue("@Div_no", cmbDivNo.Value)
                            cmd.Parameters.AddWithValue("@Shareholder", Shareholder)
                            cmd.Parameters.AddWithValue("@AssetManager", AssetManager)
                            cmd.Parameters.AddWithValue("@offer_cash", AmounttoAccept)
                            cmd.Parameters.AddWithValue("@actual_shares", SharesToAccept)
                            cmd.Parameters.AddWithValue("@CreatedBy", Session("Username"))
                            If cn.State = ConnectionState.Open Then cn.Close()
                            cn.Open()
                            cmd.ExecuteNonQuery()
                            cn.Close()
                        End Using
                    End Using
                End If
            Next
            Response.Write("<script>alert('Option Updated Successfully') ; location.href='dividendOption.aspx'</script>")
        Else
            msgbox("Please select Company and dividend No. to update option")
            Exit Sub
        End If
    End Sub
End Class
