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

Partial Class Corp_divPayment
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
            Dim cmd = New SqlCommand("SELECT DISTINCT a.company,b.Fnam FROM div_instr a join para_company b on a.company=b.Company where a.Authorize=3 and a.Instr_Type NOT in ('Cash','Option') order by b.Fnam", cn)
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
        clearFields()
        getDivnumber()
    End Sub
    Protected Sub cmbDivNo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbDivNo.SelectedIndexChanged
        getDivDetails()
    End Sub
    Sub getDivnumber()
        cmbDivNo.SelectedIndex = -1
        Dim strSQL As String = ""
        strSQL = "SELECT DISTINCT a.div_no, format(a.date_payment,'MMMM-yyyy','en-us') + ' ' + a.div_type +' '+a.Instr_type +' div no. ' + convert(nvarchar(100),a.div_no) AS displayname FROM div_instr a WHERE a.Authorize=3 and a.company=@company and a.Instr_Type NOT in ('Cash','Option') order by a.div_no desc"
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
                PanelSAVE.Visible = True
            Else
                cmbDivNo.DataSource = Nothing
                cmbDivNo.DataBind()
            End If
        End Using
    End Sub
    Sub PostDividend()
        If ISSelectedData() = False Then
            msgbox("Select Records to post")
            Exit Sub
        End If
        If txtEventType.Text = "Scrip" Then
            If SomeSelectedDataMisMatchAmountToPaySCRIP() = True Then
                msgbox("Shares to Pay + Write-off should not exceed remaining Shares")
                Exit Sub
            End If
        End If
        If txtEventType.Text = "Specie" Then
            If SomeSelectedDataMisMatchAmountToPaySPECIE() = True Then
                msgbox("Shares to Pay + Write-off should not exceed remaining Shares")
                Exit Sub
            End If
        End If
        If txtEventType.Text = "Cash" Then
            PostTempData()
        ElseIf txtEventType.Text = "Scrip" Then
            PostTempDataScrip()
        ElseIf txtEventType.Text = "Specie" Then
            PostTempDataSpecie()
        End If
        Using cn = New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("connpath"))
            Dim stmnt As String = "Proc_PostDivPayments"
            Using cmd As New SqlCommand(stmnt, cn)
                cmd.CommandType = CommandType.StoredProcedure
                cmd.CommandTimeout = 0
                cmd.Parameters.Add("@wk_comp", SqlDbType.VarChar).Value = cmbCompany.Value
                cmd.Parameters.Add("@wk_div", SqlDbType.Decimal).Value = CInt(cmbDivNo.Value)
                cmd.Parameters.Add("@createdBy", SqlDbType.VarChar).Value = Session("Username")
                If cn.State = ConnectionState.Open Then cn.Close()
                cn.Open()
                cmd.ExecuteNonQuery()
                cn.Close()
            End Using
        End Using
        Response.Write("<script>alert('Dividend Payment Posted successfully,awaiting authorization') ; location.href='dividendPayment.aspx'</script>")
    End Sub
    Protected Sub btnPost_Click(sender As Object, e As EventArgs) Handles btnPost.Click
        If cmbDivNo.Text <> "" Then
            PostDividend()
        End If
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
        grdPaymentsScrip.Visible = False
        grdPaymantsSpecie.Visible = False
        chkSelectAll.Checked = False
        chkSelectAll.Enabled = True
    End Sub
    Sub getDividendData()
        Dim strSQL As String = " "
        If txtEventType.Text = "Scrip" Then
            strSQL = "SELECT a.*,isnull(c.PaidAmount,0) as PaidAmount,a.offer_cash-isnull(c.PaidAmount,0) as RemainingAmount,a.offer_shares-ISNULL(c.PaidShares,0) as RemainingShares FROM dividend a left outer join (SELECT b.company,b.Div_No,b.Shareholder,b.AssetManager,sum(b.AmountPaid) as PaidAmount,sum(b.Shares) as PaidShares FROM DivPayments b WHERE ISNULL(b.Authorized,0) in (0,1) group by b.company,b.Div_No,b.Shareholder,b.AssetManager) c On a.company=c.Company and a.div_no=c.Div_No and a.shareholder=c.Shareholder and a.AssetManager=c.AssetManager where a.company=@Company and a.div_no=@divNo AND (a.offer_shares-isnull(c.PaidShares,0)>0) Order by a.AssetManager,a.Holder asc"
        ElseIf txtEventType.Text = "Specie" Then
            strSQL = "SELECT a.*,a.DivSpecieShares-ISNULL(c.PaidShares,0) as RemainingShares FROM dividend a left outer join (SELECT b.company,b.Div_No,b.Shareholder,b.AssetManager,sum(b.Shares) as PaidShares FROM DivPayments b WHERE ISNULL(b.Authorized,0) in (0,1) group by b.company,b.Div_No,b.Shareholder,b.AssetManager) c On a.company=c.Company and a.div_no=c.Div_No and a.shareholder=c.Shareholder and a.AssetManager=c.AssetManager where a.company=@Company and a.div_no=@divNo AND (a.DivSpecieShares-isnull(c.PaidShares,0)>0) Order by a.AssetManager,a.Holder asc"
        End If

        Using cn = New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("connpath"))
            Dim ds As New DataSet
            Dim cmd = New SqlCommand(strSQL, cn)
            cmd.Parameters.AddWithValue("@Company", cmbCompany.Value)
            cmd.Parameters.AddWithValue("@divNo", cmbDivNo.Value)
            Dim adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "dividend")
            If ds.Tables(0).Rows.Count > 0 Then
                If txtEventType.Text = "Specie" Then
                    grdPaymantsSpecie.DataSource = ds
                    grdPaymantsSpecie.DataBind()
                    grdPaymantsSpecie.Visible = True

                    grdPaymentsScrip.DataSource = Nothing
                    grdPaymentsScrip.DataBind()
                    grdPaymentsScrip.Visible = False

                    chkSelectAll.Enabled = True
                    chkSelectAll.Checked = False
                ElseIf txtEventType.Text = "Scrip" Then
                    grdPaymentsScrip.DataSource = ds
                    grdPaymentsScrip.DataBind()
                    grdPaymentsScrip.Visible = True

                    grdPaymantsSpecie.DataSource = Nothing
                    grdPaymantsSpecie.DataBind()
                    grdPaymantsSpecie.Visible = False

                    chkSelectAll.Enabled = True
                    chkSelectAll.Checked = False
                Else
                    grdPaymantsSpecie.DataSource = Nothing
                    grdPaymantsSpecie.DataBind()
                    grdPaymantsSpecie.Visible = False
                    grdPaymentsScrip.DataSource = Nothing
                    grdPaymentsScrip.DataBind()
                    grdPaymentsScrip.Visible = False

                    chkSelectAll.Enabled = True
                    chkSelectAll.Checked = False
                End If
            Else
                grdPaymantsSpecie.DataSource = Nothing
                grdPaymantsSpecie.DataBind()
                grdPaymantsSpecie.Visible = False
                grdPaymentsScrip.DataSource = Nothing
                grdPaymentsScrip.DataBind()
                grdPaymentsScrip.Visible = False
            End If
        End Using
    End Sub
    Protected Sub chkSelectAll_CheckedChanged(sender As Object, e As EventArgs) Handles chkSelectAll.CheckedChanged
        Dim myGridView As New ASPxGridView
        If txtEventType.Text = "Specie" Then
            myGridView = grdPaymantsSpecie
        ElseIf txtEventType.Text = "Scrip" Then
            myGridView = grdPaymentsScrip
        End If
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
    Private Function ISSelectedData() As Boolean
        Dim myGridView As New ASPxGridView
        If txtEventType.Text = "Specie" Then
            myGridView = grdPaymantsSpecie
        ElseIf txtEventType.Text = "Scrip" Then
            myGridView = grdPaymentsScrip
        End If
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
    Private Function SomeSelectedDataMisMatchAmountToPaySCRIP() As Boolean
        Dim myGridView As New ASPxGridView
        If txtEventType.Text = "Scrip" Then
            myGridView = grdPaymentsScrip
        End If

        Dim SelectedCount As Long = 0
        Dim keys As List(Of Object) = myGridView.GetCurrentPageRowValues(New String() {"SEQ"})
        For Each key As Object In keys
            If TryCast(myGridView.FindRowCellTemplateControlByKey(key, TryCast(myGridView.Columns("Selec"), GridViewDataColumn), "chk1"), ASPxCheckBox).Checked = True Then
                Dim RemainingShares As Long = 0, SharesToPay As Long = 0, SharesWriteoff As Long = 0
                Try
                    RemainingShares = CLng(TryCast(myGridView.FindRowCellTemplateControlByKey(key, TryCast(myGridView.Columns("RemainingSharesc"), GridViewDataColumn), "lblRemainingShares"), ASPxLabel).Text)
                Catch ex As Exception
                End Try
                Try
                    SharesToPay = CLng(TryCast(myGridView.FindRowCellTemplateControlByKey(key, TryCast(myGridView.Columns("SharesToPayc"), GridViewDataColumn), "txtSharesToPay"), ASPxTextBox).Text)
                Catch ex As Exception
                End Try
                Try
                    SharesWriteoff = CLng(TryCast(myGridView.FindRowCellTemplateControlByKey(key, TryCast(myGridView.Columns("SharesWriteoffc"), GridViewDataColumn), "txtSharesWriteoff"), ASPxTextBox).Text)
                Catch ex As Exception
                End Try
                If SharesToPay + SharesWriteoff > RemainingShares Then
                    SelectedCount += 1
                End If
            End If
        Next
        If SelectedCount > 0 Then
            Return True
        Else
            Return False
        End If
    End Function
    Private Function SomeSelectedDataMisMatchAmountToPaySPECIE() As Boolean
        Dim myGridView As New ASPxGridView
        If txtEventType.Text = "Specie" Then
            myGridView = grdPaymantsSpecie
        End If

        Dim SelectedCount As Long = 0
        Dim keys As List(Of Object) = myGridView.GetCurrentPageRowValues(New String() {"SEQ"})
        For Each key As Object In keys
            If TryCast(myGridView.FindRowCellTemplateControlByKey(key, TryCast(myGridView.Columns("Selec"), GridViewDataColumn), "chk1"), ASPxCheckBox).Checked = True Then
                Dim RemainingShares As Long = 0, SharesToPay As Long = 0, SharesWriteoff As Long = 0
                Try
                    RemainingShares = CLng(TryCast(myGridView.FindRowCellTemplateControlByKey(key, TryCast(myGridView.Columns("RemainingSharesc"), GridViewDataColumn), "lblRemainingShares"), ASPxLabel).Text)
                Catch ex As Exception
                End Try
                Try
                    SharesToPay = CLng(TryCast(myGridView.FindRowCellTemplateControlByKey(key, TryCast(myGridView.Columns("SharesToPayc"), GridViewDataColumn), "txtSharesToPay"), ASPxTextBox).Text)
                Catch ex As Exception
                End Try
                Try
                    SharesWriteoff = CLng(TryCast(myGridView.FindRowCellTemplateControlByKey(key, TryCast(myGridView.Columns("SharesWriteoffc"), GridViewDataColumn), "txtSharesWriteoff"), ASPxTextBox).Text)
                Catch ex As Exception
                End Try
                If SharesToPay + SharesWriteoff > RemainingShares Then
                    SelectedCount += 1
                End If
            End If
        Next
        If SelectedCount > 0 Then
            Return True
        Else
            Return False
        End If
    End Function
    Sub PostTempData()
        Using cn = New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("connpath"))
            Dim stmnt As String = "DELETE FROM DivPayments_temp WHERE PaidBy=@PaidBy"
            Using cmd As New SqlCommand(stmnt, cn)
                cmd.CommandType = CommandType.Text
                cmd.CommandTimeout = 0
                cmd.Parameters.AddWithValue("@PaidBy", Session("Username"))
                If cn.State = ConnectionState.Open Then cn.Close()
                cn.Open()
                cmd.ExecuteNonQuery()
                cn.Close()
            End Using
        End Using
        Dim sharesPostDesc As String = ""
        Dim sharesWriteoffDesc As String = ""
        Dim myGridView As New ASPxGridView
        Dim keys As List(Of Object) = myGridView.GetCurrentPageRowValues(New String() {"SEQ"})
        For Each key As Object In keys
            If TryCast(myGridView.FindRowCellTemplateControlByKey(key, TryCast(myGridView.Columns("Selec"), GridViewDataColumn), "chk1"), ASPxCheckBox).Checked = True Then
                Dim AmountToPay As Double = 0, AmountWriteoff As Double = 0
                Try
                    AmountToPay = CDbl(TryCast(myGridView.FindRowCellTemplateControlByKey(key, TryCast(myGridView.Columns("AmountToPayc"), GridViewDataColumn), "txtAmountToPay"), ASPxTextBox).Text)
                Catch ex As Exception
                End Try
                Try
                    AmountWriteoff = CDbl(TryCast(myGridView.FindRowCellTemplateControlByKey(key, TryCast(myGridView.Columns("AmountWriteoffc"), GridViewDataColumn), "txtAmountWriteoff"), ASPxTextBox).Text)
                Catch ex As Exception
                End Try
                Dim Shareholder As String = TryCast(myGridView.FindRowCellTemplateControlByKey(key, TryCast(myGridView.Columns("shareholder"), GridViewDataColumn), "lblshareholder"), ASPxLabel).Text
                Dim AssetManager As String = TryCast(myGridView.FindRowCellTemplateControlByKey(key, TryCast(myGridView.Columns("AssetManager"), GridViewDataColumn), "lblAssetManager"), ASPxLabel).Text
                Dim stmnt As String = " "
                If AmountToPay > 0 Then
                    stmnt = " INSERT INTO DivPayments_temp([Company], [Div_No], [Shareholder], [AssetManager], [AmountPaid], [PaidBy], [PaymentType])VALUES(@Company,@Div_No,@Shareholder,@AssetManager,'" & AmountToPay & "',@PaidBy,'" & sharesPostDesc & "') "
                End If
                If AmountWriteoff > 0 Then
                    stmnt = stmnt & " INSERT INTO DivPayments_temp([Company], [Div_No], [Shareholder], [AssetManager], [AmountPaid], [PaidBy], [PaymentType])VALUES(@Company,@Div_No,@Shareholder,@AssetManager,'" & AmountWriteoff & "',@PaidBy,'" & sharesWriteoffDesc & "') "
                End If
                Using cn = New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("connpath"))
                    Using cmd As New SqlCommand(stmnt, cn)
                        cmd.CommandType = CommandType.Text
                        cmd.CommandTimeout = 0
                        cmd.Parameters.AddWithValue("@Company", cmbCompany.Value)
                        cmd.Parameters.AddWithValue("@Div_No", cmbDivNo.Value)
                        cmd.Parameters.AddWithValue("@Shareholder", Shareholder)
                        cmd.Parameters.AddWithValue("@AssetManager", AssetManager)
                        cmd.Parameters.AddWithValue("@PaidBy", Session("Username"))
                        If cn.State = ConnectionState.Open Then cn.Close()
                        cn.Open()
                        cmd.ExecuteNonQuery()
                        cn.Close()
                    End Using
                End Using
            End If
        Next
    End Sub
    Sub PostTempDataScrip()
        Using cn = New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("connpath"))
            Dim stmnt As String = "DELETE FROM DivPayments_temp WHERE PaidBy=@PaidBy"
            Using cmd As New SqlCommand(stmnt, cn)
                cmd.CommandType = CommandType.Text
                cmd.CommandTimeout = 0
                cmd.Parameters.AddWithValue("@PaidBy", Session("Username"))
                If cn.State = ConnectionState.Open Then cn.Close()
                cn.Open()
                cmd.ExecuteNonQuery()
                cn.Close()
            End Using
        End Using
        Dim sharesPostDesc As String = ""
        Dim sharesWriteoffDesc As String = ""
        Dim myGridView As New ASPxGridView
        If txtEventType.Text = "Scrip" Then
            sharesPostDesc = "Scrip Shares"
            sharesWriteoffDesc = "Write-off Shares"
            myGridView = grdPaymentsScrip
        End If
        Dim keys As List(Of Object) = myGridView.GetCurrentPageRowValues(New String() {"SEQ"})
        For Each key As Object In keys
            If TryCast(myGridView.FindRowCellTemplateControlByKey(key, TryCast(myGridView.Columns("Selec"), GridViewDataColumn), "chk1"), ASPxCheckBox).Checked = True Then
                Dim SharesToPay As Long = 0, SharesWriteoff As Long = 0
                Try
                    SharesToPay = CLng(TryCast(myGridView.FindRowCellTemplateControlByKey(key, TryCast(myGridView.Columns("SharesToPayc"), GridViewDataColumn), "txtSharesToPay"), ASPxTextBox).Text)
                Catch ex As Exception
                End Try
                Try
                    SharesWriteoff = CLng(TryCast(myGridView.FindRowCellTemplateControlByKey(key, TryCast(myGridView.Columns("SharesWriteoffc"), GridViewDataColumn), "txtSharesWriteoff"), ASPxTextBox).Text)
                Catch ex As Exception
                End Try
                Dim Shareholder As String = TryCast(myGridView.FindRowCellTemplateControlByKey(key, TryCast(myGridView.Columns("shareholder"), GridViewDataColumn), "lblshareholder"), ASPxLabel).Text
                Dim AssetManager As String = TryCast(myGridView.FindRowCellTemplateControlByKey(key, TryCast(myGridView.Columns("AssetManager"), GridViewDataColumn), "lblAssetManager"), ASPxLabel).Text
                Dim stmnt As String = " "
                If SharesToPay > 0 Then
                    stmnt = " INSERT INTO DivPayments_temp([Company], [Div_No], [Shareholder], [AssetManager], [AmountPaid], [PaidBy], [PaymentType],[Shares])VALUES(@Company,@Div_No,@Shareholder,@AssetManager,0,@PaidBy,'" & sharesPostDesc & "','" & SharesToPay & "') "
                End If
                If SharesWriteoff > 0 Then
                    stmnt = stmnt & " INSERT INTO DivPayments_temp([Company], [Div_No], [Shareholder], [AssetManager], [AmountPaid], [PaidBy], [PaymentType],[Shares])VALUES(@Company,@Div_No,@Shareholder,@AssetManager,0,@PaidBy,'" & sharesWriteoffDesc & "','" & SharesWriteoff & "') "
                End If
                Using cn = New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("connpath"))
                    Using cmd As New SqlCommand(stmnt, cn)
                        cmd.CommandType = CommandType.Text
                        cmd.CommandTimeout = 0
                        cmd.Parameters.AddWithValue("@Company", cmbCompany.Value)
                        cmd.Parameters.AddWithValue("@Div_No", cmbDivNo.Value)
                        cmd.Parameters.AddWithValue("@Shareholder", Shareholder)
                        cmd.Parameters.AddWithValue("@AssetManager", AssetManager)
                        cmd.Parameters.AddWithValue("@PaidBy", Session("Username"))
                        If cn.State = ConnectionState.Open Then cn.Close()
                        cn.Open()
                        cmd.ExecuteNonQuery()
                        cn.Close()
                    End Using
                End Using
            End If
        Next
    End Sub
    Sub PostTempDataSpecie()
        Using cn = New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("connpath"))
            Dim stmnt As String = "DELETE FROM DivPayments_temp WHERE PaidBy=@PaidBy"
            Using cmd As New SqlCommand(stmnt, cn)
                cmd.CommandType = CommandType.Text
                cmd.CommandTimeout = 0
                cmd.Parameters.AddWithValue("@PaidBy", Session("Username"))
                If cn.State = ConnectionState.Open Then cn.Close()
                cn.Open()
                cmd.ExecuteNonQuery()
                cn.Close()
            End Using
        End Using
        Dim sharesPostDesc As String = ""
        Dim sharesWriteoffDesc As String = ""
        Dim myGridView As New ASPxGridView
        If txtEventType.Text = "Specie" Then
            sharesPostDesc = "Specie Shares"
            sharesWriteoffDesc = "Write-off Shares"
            myGridView = grdPaymantsSpecie
        End If
        Dim keys As List(Of Object) = myGridView.GetCurrentPageRowValues(New String() {"SEQ"})
        For Each key As Object In keys
            If TryCast(myGridView.FindRowCellTemplateControlByKey(key, TryCast(myGridView.Columns("Selec"), GridViewDataColumn), "chk1"), ASPxCheckBox).Checked = True Then
                Dim SharesToPay As Long = 0, SharesWriteoff As Long = 0
                Try
                    SharesToPay = CLng(TryCast(myGridView.FindRowCellTemplateControlByKey(key, TryCast(myGridView.Columns("SharesToPayc"), GridViewDataColumn), "txtSharesToPay"), ASPxTextBox).Text)
                Catch ex As Exception
                End Try
                Try
                    SharesWriteoff = CLng(TryCast(myGridView.FindRowCellTemplateControlByKey(key, TryCast(myGridView.Columns("SharesWriteoffc"), GridViewDataColumn), "txtSharesWriteoff"), ASPxTextBox).Text)
                Catch ex As Exception
                End Try
                Dim Shareholder As String = TryCast(myGridView.FindRowCellTemplateControlByKey(key, TryCast(myGridView.Columns("shareholder"), GridViewDataColumn), "lblshareholder"), ASPxLabel).Text
                Dim AssetManager As String = TryCast(myGridView.FindRowCellTemplateControlByKey(key, TryCast(myGridView.Columns("AssetManager"), GridViewDataColumn), "lblAssetManager"), ASPxLabel).Text
                Dim stmnt As String = " "
                If SharesToPay > 0 Then
                    stmnt = " INSERT INTO DivPayments_temp([Company], [Div_No], [Shareholder], [AssetManager], [AmountPaid], [PaidBy], [PaymentType],[Shares])VALUES(@Company,@Div_No,@Shareholder,@AssetManager,0,@PaidBy,'" & sharesPostDesc & "','" & SharesToPay & "') "
                End If
                If SharesWriteoff > 0 Then
                    stmnt = stmnt & " INSERT INTO DivPayments_temp([Company], [Div_No], [Shareholder], [AssetManager], [AmountPaid], [PaidBy], [PaymentType],[Shares])VALUES(@Company,@Div_No,@Shareholder,@AssetManager,0,@PaidBy,'" & sharesWriteoffDesc & "','" & SharesWriteoff & "') "
                End If
                Using cn = New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("connpath"))
                    Using cmd As New SqlCommand(stmnt, cn)
                        cmd.CommandType = CommandType.Text
                        cmd.CommandTimeout = 0
                        cmd.Parameters.AddWithValue("@Company", cmbCompany.Value)
                        cmd.Parameters.AddWithValue("@Div_No", cmbDivNo.Value)
                        cmd.Parameters.AddWithValue("@Shareholder", Shareholder)
                        cmd.Parameters.AddWithValue("@AssetManager", AssetManager)
                        cmd.Parameters.AddWithValue("@PaidBy", Session("Username"))
                        If cn.State = ConnectionState.Open Then cn.Close()
                        cn.Open()
                        cmd.ExecuteNonQuery()
                        cn.Close()
                    End Using
                End Using
            End If
        Next
    End Sub
    Protected Sub btnCalc_Click(sender As Object, e As EventArgs) Handles btnCalc.Click
        If txtEventType.Text = "Scrip" Then
            Dim totalSharesToPay As Long = 0
            Dim totalWriteoff As Long = 0
            Dim myGridView As New ASPxGridView
            myGridView = grdPaymentsScrip
            Dim keys As List(Of Object) = myGridView.GetCurrentPageRowValues(New String() {"SEQ"})
            For Each key As Object In keys
                If TryCast(myGridView.FindRowCellTemplateControlByKey(key, TryCast(myGridView.Columns("Selec"), GridViewDataColumn), "chk1"), ASPxCheckBox).Checked = True Then
                    Dim SharesWriteoff As Long = 0, SharesToPay As Long = 0
                    Try
                        SharesToPay = CLng(TryCast(myGridView.FindRowCellTemplateControlByKey(key, TryCast(myGridView.Columns("SharesToPayc"), GridViewDataColumn), "txtSharesToPay"), ASPxTextBox).Text)
                    Catch ex As Exception
                    End Try
                    Try
                        SharesWriteoff = CLng(TryCast(myGridView.FindRowCellTemplateControlByKey(key, TryCast(myGridView.Columns("SharesWriteoffc"), GridViewDataColumn), "txtSharesWriteoff"), ASPxTextBox).Text)
                    Catch ex As Exception
                    End Try
                    totalSharesToPay += SharesToPay
                    totalWriteoff += SharesWriteoff
                End If
            Next
            lblTotalCashSelected.Text = "Post: " & totalSharesToPay.ToString("#,#") & " Shares . Write-off: " & totalWriteoff.ToString("#,#") & "  Shares."
        ElseIf txtEventType.Text = "Specie" Then
            Dim totalSharesToPay As Long = 0
            Dim totalWriteoff As Long = 0
            Dim myGridView As New ASPxGridView
            myGridView = grdPaymantsSpecie
            Dim keys As List(Of Object) = myGridView.GetCurrentPageRowValues(New String() {"SEQ"})
            For Each key As Object In keys
                If TryCast(myGridView.FindRowCellTemplateControlByKey(key, TryCast(myGridView.Columns("Selec"), GridViewDataColumn), "chk1"), ASPxCheckBox).Checked = True Then
                    Dim SharesWriteoff As Long = 0, SharesToPay As Long = 0
                    Try
                        SharesToPay = CLng(TryCast(myGridView.FindRowCellTemplateControlByKey(key, TryCast(myGridView.Columns("SharesToPayc"), GridViewDataColumn), "txtSharesToPay"), ASPxTextBox).Text)
                    Catch ex As Exception
                    End Try
                    Try
                        SharesWriteoff = CLng(TryCast(myGridView.FindRowCellTemplateControlByKey(key, TryCast(myGridView.Columns("SharesWriteoffc"), GridViewDataColumn), "txtSharesWriteoff"), ASPxTextBox).Text)
                    Catch ex As Exception
                    End Try
                    totalSharesToPay += SharesToPay
                    totalWriteoff += SharesWriteoff
                End If
            Next
            lblTotalCashSelected.Text = "Post: " & totalSharesToPay.ToString("#,#") & " Shares . Write-off: " & totalWriteoff.ToString("#,#") & "  Shares."
        End If
    End Sub
    Function getDividendDataFXN() As DataSet
        Dim strSQL As String = " "
        If txtEventType.Text = "Scrip" Then
            strSQL = "SELECT a.*,isnull(c.PaidAmount,0) as PaidAmount,a.offer_cash-isnull(c.PaidAmount,0) as RemainingAmount,a.offer_shares-ISNULL(c.PaidShares,0) as RemainingShares FROM dividend a left outer join (SELECT b.company,b.Div_No,b.Shareholder,b.AssetManager,sum(b.AmountPaid) as PaidAmount,sum(b.Shares) as PaidShares FROM DivPayments b WHERE ISNULL(b.Authorized,0) in (0,1) group by b.company,b.Div_No,b.Shareholder,b.AssetManager) c On a.company=c.Company and a.div_no=c.Div_No and a.shareholder=c.Shareholder and a.AssetManager=c.AssetManager where a.company=@Company and a.div_no=@divNo AND (a.offer_shares-isnull(c.PaidShares,0)>0) Order by a.AssetManager,a.Holder asc"
        ElseIf txtEventType.Text = "Specie" Then
            strSQL = "SELECT a.*,a.DivSpecieShares-ISNULL(c.PaidShares,0) as RemainingShares,0 as RemainingAmount FROM dividend a left outer join (SELECT b.company,b.Div_No,b.Shareholder,b.AssetManager,sum(b.Shares) as PaidShares FROM DivPayments b WHERE ISNULL(b.Authorized,0) in (0,1) group by b.company,b.Div_No,b.Shareholder,b.AssetManager) c On a.company=c.Company and a.div_no=c.Div_No and a.shareholder=c.Shareholder and a.AssetManager=c.AssetManager where a.company=@Company and a.div_no=@divNo AND (a.DivSpecieShares-isnull(c.PaidShares,0)>0) Order by a.AssetManager,a.Holder asc"
        End If

        Using cn = New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("connpath"))
            Dim ds As New DataSet
            Dim cmd = New SqlCommand(strSQL, cn)
            cmd.Parameters.AddWithValue("@Company", cmbCompany.Value)
            cmd.Parameters.AddWithValue("@divNo", cmbDivNo.Value)
            Dim adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "dividend")
            If txtEventType.Text = "Specie" Then
                grdPaymantsSpecie.Visible = True
                grdPaymentsScrip.Visible = False
                chkSelectAll.Enabled = True
                chkSelectAll.Checked = False
            ElseIf txtEventType.Text = "Scrip" Then
                grdPaymentsScrip.Visible = True
                grdPaymantsSpecie.Visible = False
                chkSelectAll.Enabled = True
                chkSelectAll.Checked = False
            Else
                grdPaymantsSpecie.Visible = False
                grdPaymentsScrip.Visible = False
                chkSelectAll.Enabled = True
                chkSelectAll.Checked = False
            End If
            Return ds
        End Using
    End Function
    Protected Sub grdPaymentsScrip_DataBinding(sender As Object, e As EventArgs) Handles grdPaymentsScrip.DataBinding
        grdPaymentsScrip.DataSource = getDividendDataFXN()
    End Sub
    Protected Sub grdPaymantsSpecie_DataBinding(sender As Object, e As EventArgs) Handles grdPaymantsSpecie.DataBinding
        grdPaymantsSpecie.DataSource = getDividendDataFXN()
    End Sub
End Class
