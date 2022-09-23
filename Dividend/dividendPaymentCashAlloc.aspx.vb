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

Partial Class Corp_divPaymentAllocation
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
                loadassetmanagers()
                loadassetmanagersDividend()
                Try
                    getunallocated(cmbassetmanager.SelectedItem.Value.ToString)
                Catch ex As Exception
                End Try
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Sub getCompanies()
        Using cn = New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("connpath"))
            Dim ds As New DataSet
            Dim cmd = New SqlCommand("SELECT DISTINCT a.company,b.Fnam FROM div_instr a join para_company b on a.company=b.Company where a.Authorize=3 and a.Instr_Type in ('Cash','Option') order by b.Fnam", cn)
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
        If cmbDividendAssetManager.Text <> "" Then
            getDivDetails()
        End If
    End Sub
    Sub getDivnumber()
        cmbDivNo.SelectedIndex = -1
        Dim strSQL As String = ""
        strSQL = "SELECT DISTINCT a.div_no, format(a.date_payment,'MMMM-yyyy','en-us') + ' ' + a.div_type +' '+a.Instr_type +' div no. ' + convert(nvarchar(100),a.div_no) AS displayname FROM div_instr a WHERE a.Authorize=3 and a.company=@company and a.Instr_Type in ('Cash','Option') order by a.div_no desc"
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
        btnCalc_Click(sender:=New Object, e:=New EventArgs)
        If ISSelectedData() = False Then
            msgbox("Select Records to post")
            Exit Sub
        End If
        If txtEventType.Text = "Cash" Or (txtEventType.Text = "Option" And OptionDivHasCash() = True) Then
            If Not IsNumeric(txtAmount.Text.Replace(",", "")) Then
                msgbox("Amount must be numbers only")
            End If
            Dim allamt As Double = txtAmount.Text.Replace(",", "")
            Dim ava As Double = lblCashBal.Text.Replace(",", "")

            If ava < allamt Then
                msgbox("Please enter amount equivalent or less than the transaction amount!")
                Exit Sub
            End If
            If getTotalAmountToPayIndividual() > allamt Then
                msgbox("Total Amount from individual dividend payments exceeds the Deposit Amount")
                Exit Sub
            End If
            If txtEventType.Text = "Cash" Then
                If SomeSelectedDataMisMatchAmountToPay() = True Then
                    msgbox("Amount to Pay + Write-off should not exceed remaining amount")
                    Exit Sub
                End If
            End If
            If txtEventType.Text = "Option" Then
                If SomeSelectedDataMisMatchAmountToPayOption() = True Then
                    msgbox("Amount to Pay + Write-off should not exceed remaining amount")
                    Exit Sub
                End If
            End If
            If txtEventType.Text = "Cash" Then
                If SomeSelectedClientsDonNotmatchBankAccount() = True Then
                    msgbox("1 or more selected payments are not tied to the selected bank account")
                    Exit Sub
                End If
            End If
            If txtEventType.Text = "Option" Then
                If SomeSelectedClientsDonNotmatchBankAccountOPTION() = True Then
                    msgbox("1 or more selected payments are not tied to the selected bank account")
                    Exit Sub
                End If
            End If
        End If

        If txtEventType.Text = "Cash" Then
            PostTempData()
        ElseIf txtEventType.Text = "Option" Then
            PostTempDataOption()
        End If
        btnPost.Enabled = False
        Using cn = New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("connpath"))
            Dim stmnt As String = "Proc_PostDivPayments_CASH"
            Using cmd As New SqlCommand(stmnt, cn)
                cmd.CommandType = CommandType.StoredProcedure
                cmd.CommandTimeout = 0
                cmd.Parameters.Add("@wk_comp", SqlDbType.VarChar).Value = cmbCompany.Value
                cmd.Parameters.Add("@wk_div", SqlDbType.Decimal).Value = CInt(cmbDivNo.Value)
                cmd.Parameters.Add("@createdBy", SqlDbType.VarChar).Value = Session("Username")
                cmd.Parameters.Add("@selectedID", SqlDbType.VarChar).Value = IIf(IsNumeric(lblselected.Text) = True, lblselected.Text, "0")
                cmd.Parameters.Add("@desc", SqlDbType.VarChar).Value = txtdesc.Text
                cmd.Parameters.Add("@EventType", SqlDbType.VarChar).Value = txtEventType.Text
                If cn.State = ConnectionState.Open Then cn.Close()
                cn.Open()
                cmd.ExecuteNonQuery()
                cn.Close()
            End Using
        End Using
        Response.Write("<script>alert('Dividend Payment Posted successfully,awaiting authorization') ; location.href='dividendPaymentCashAlloc.aspx'</script>")
    End Sub
    Protected Sub btnPost_Click(sender As Object, e As EventArgs) Handles btnPost.Click
        If cmbDivNo.Text <> "" Then
            Try
                PostDividend()
            Catch ex As Exception
                ErrorLogging.WriteLogFile2(ex.ToString)
            End Try
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
                txtTaxRate.Text = dr.Item("TaxRate").ToString
                txtRound.Text = dr.Item("scrip_round1").ToString
                txtScriptPrice.Text = dr.Item("scrip_price").ToString
                txtCurrency.Text = dr.Item("Currency").ToString
                txtdesc.Text = cmbDivNo.Text
                If dr.Item("Instr_type").ToString = "Option" Then
                    divScrip1.Visible = True
                    Panel8i.Visible = True
                Else
                    divScrip1.Visible = False
                    Panel8i.Visible = True
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
        txtTaxRate.Text = ""
        txtRound.Text = ""
        txtScriptPrice.Text = ""
        txtCurrency.Text = ""
        divScrip1.Visible = False
        grdPaymentsCash.Visible = False
        grdPaymentsOption.Visible = False
        chkSelectAll.Checked = False
        chkSelectAll.Enabled = True
    End Sub
    Sub getDividendData()
        If cmbCompany.Text <> "" And cmbDivNo.Text <> "" Then
            Dim strSQL As String = " "
            If txtEventType.Text = "Cash" Then
                strSQL = "SELECT a.*,isnull(c.PaidAmount,0) as PaidAmount,a.actual_nett-isnull(c.PaidAmount,0) as RemainingAmount FROM dividend a left outer join (SELECT b.company,b.Div_No,b.Shareholder,b.AssetManager,sum(b.AmountPaid) as PaidAmount FROM DivPayments b WHERE ISNULL(b.Authorized,0) in (0,1) group by b.company,b.Div_No,b.Shareholder,b.AssetManager) c On a.company=c.Company and a.div_no=c.Div_No and a.shareholder=c.Shareholder and a.AssetManager=c.AssetManager where a.company=@Company and a.div_no=@divNo and a.AssetManager=@AssetManager AND a.actual_nett-isnull(c.PaidAmount,0)>0 Order by RemainingAmount desc"
            ElseIf txtEventType.Text = "Option" Then
                strSQL = "SELECT a.*,isnull(c.PaidAmount,0) as PaidAmount,a.offer_cash-isnull(c.PaidAmount,0) as RemainingAmount,a.actual_shares-isnull(c.PaidShares,0) as RemainingShares FROM dividend a left outer join (SELECT b.company,b.Div_No,b.Shareholder,b.AssetManager,sum(b.AmountPaid) as PaidAmount,sum(b.Shares) as PaidShares FROM DivPayments b WHERE ISNULL(b.Authorized,0) in (0,1) group by b.company,b.Div_No,b.Shareholder,b.AssetManager) c On a.company=c.Company and a.div_no=c.Div_No and a.shareholder=c.Shareholder and a.AssetManager=c.AssetManager where a.company=@Company and a.div_no=@divNo and a.AssetManager=@AssetManager AND (a.offer_cash-isnull(c.PaidAmount,0)>0 OR a.actual_shares-isnull(c.PaidShares,0)>0) Order by RemainingAmount desc"
            Else
                strSQL = "SELECT * FROM dividend where company=@Company and div_no=@divNo and AssetManager=@AssetManager Order by actual_nett desc"
            End If

            Using cn = New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("connpath"))
                Dim ds As New DataSet
                Dim cmd = New SqlCommand(strSQL, cn)
                cmd.Parameters.AddWithValue("@Company", cmbCompany.Value)
                cmd.Parameters.AddWithValue("@divNo", cmbDivNo.Value)
                cmd.Parameters.AddWithValue("@AssetManager", cmbDividendAssetManager.Value)
                Dim adp = New SqlDataAdapter(cmd)
                adp.Fill(ds, "dividend")
                If ds.Tables(0).Rows.Count > 0 Then
                    If txtEventType.Text = "Cash" Then
                        grdPaymentsCash.DataSource = ds
                        grdPaymentsCash.DataBind()
                        grdPaymentsCash.Visible = True

                        grdPaymentsOption.DataSource = Nothing
                        grdPaymentsOption.DataBind()
                        grdPaymentsOption.Visible = False

                        chkSelectAll.Enabled = True
                        chkSelectAll.Checked = False
                    Else
                        grdPaymentsOption.DataSource = ds
                        grdPaymentsOption.DataBind()
                        grdPaymentsOption.Visible = True

                        grdPaymentsCash.DataSource = Nothing
                        grdPaymentsCash.DataBind()
                        grdPaymentsCash.Visible = False

                        chkSelectAll.Enabled = True
                        chkSelectAll.Checked = False
                    End If
                Else
                    grdPaymentsOption.DataSource = Nothing
                    grdPaymentsOption.DataBind()
                    grdPaymentsOption.Visible = False
                    grdPaymentsCash.DataSource = Nothing
                    grdPaymentsCash.DataBind()
                    grdPaymentsCash.Visible = False
                End If
            End Using
        End If
    End Sub
    Protected Sub chkSelectAll_CheckedChanged(sender As Object, e As EventArgs) Handles chkSelectAll.CheckedChanged
        Dim myGridView As New ASPxGridView
        If txtEventType.Text = "Cash" Then
            myGridView = grdPaymentsCash
        Else
            myGridView = grdPaymentsOption
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
        If txtEventType.Text = "Cash" Then
            myGridView = grdPaymentsCash
        Else
            myGridView = grdPaymentsOption
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
    Private Function SomeSelectedDataMisMatchAmountToPayOption() As Boolean
        Dim myGridView As New ASPxGridView
        If txtEventType.Text = "Option" Then
            myGridView = grdPaymentsOption
        End If

        Dim SelectedCount As Long = 0
        Dim keys As List(Of Object) = myGridView.GetCurrentPageRowValues(New String() {"SEQ"})
        For Each key As Object In keys
            If TryCast(myGridView.FindRowCellTemplateControlByKey(key, TryCast(myGridView.Columns("Selec"), GridViewDataColumn), "chk1"), ASPxCheckBox).Checked = True Then
                Dim RemainingAmount As Double = 0, AmountToPay As Double = 0, AmountWriteoff As Double = 0
                Dim RemainingShares As Long = 0, SharesToPay As Long = 0, SharesToWriteoff As Long = 0
                Try
                    RemainingAmount = CDbl(TryCast(myGridView.FindRowCellTemplateControlByKey(key, TryCast(myGridView.Columns("RemainingAmountc"), GridViewDataColumn), "lblRemainingAmount"), ASPxLabel).Text)
                Catch ex As Exception
                End Try
                Try
                    AmountToPay = CDbl(TryCast(myGridView.FindRowCellTemplateControlByKey(key, TryCast(myGridView.Columns("AmountToPayc"), GridViewDataColumn), "txtAmountToPay"), ASPxTextBox).Text)
                Catch ex As Exception
                End Try
                Try
                    AmountWriteoff = CDbl(TryCast(myGridView.FindRowCellTemplateControlByKey(key, TryCast(myGridView.Columns("AmountWriteoffc"), GridViewDataColumn), "txtAmountWriteoff"), ASPxTextBox).Text)
                Catch ex As Exception
                End Try
                Try
                    RemainingShares = CLng(TryCast(myGridView.FindRowCellTemplateControlByKey(key, TryCast(myGridView.Columns("RemainingSharesc"), GridViewDataColumn), "lblRemainingShares"), ASPxLabel).Text)
                Catch ex As Exception
                End Try
                Try
                    SharesToPay = CLng(TryCast(myGridView.FindRowCellTemplateControlByKey(key, TryCast(myGridView.Columns("SharesToPostc"), GridViewDataColumn), "txtSharesToPost"), ASPxTextBox).Text)
                Catch ex As Exception
                End Try
                Try
                    SharesToWriteoff = CLng(TryCast(myGridView.FindRowCellTemplateControlByKey(key, TryCast(myGridView.Columns("SharesWriteoffc"), GridViewDataColumn), "txtSharesWriteoff"), ASPxTextBox).Text)
                Catch ex As Exception
                End Try

                If AmountToPay + AmountWriteoff > RemainingAmount Then
                    SelectedCount += 1
                End If
                If SharesToPay + SharesToWriteoff > RemainingShares Then
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
    Private Function SomeSelectedDataMisMatchAmountToPay() As Boolean
        Dim myGridView As New ASPxGridView
        If txtEventType.Text = "Cash" Then
            myGridView = grdPaymentsCash
        End If

        Dim SelectedCount As Long = 0
        Dim keys As List(Of Object) = myGridView.GetCurrentPageRowValues(New String() {"SEQ"})
        For Each key As Object In keys
            If TryCast(myGridView.FindRowCellTemplateControlByKey(key, TryCast(myGridView.Columns("Selec"), GridViewDataColumn), "chk1"), ASPxCheckBox).Checked = True Then
                Dim RemainingAmount As Double = 0, AmountToPay As Double = 0, AmountWriteoff As Double = 0
                Try
                    RemainingAmount = CDbl(TryCast(myGridView.FindRowCellTemplateControlByKey(key, TryCast(myGridView.Columns("RemainingAmountc"), GridViewDataColumn), "lblRemainingAmount"), ASPxLabel).Text)
                Catch ex As Exception
                End Try
                Try
                    AmountToPay = CDbl(TryCast(myGridView.FindRowCellTemplateControlByKey(key, TryCast(myGridView.Columns("AmountToPayc"), GridViewDataColumn), "txtAmountToPay"), ASPxTextBox).Text)
                Catch ex As Exception
                End Try
                Try
                    AmountWriteoff = CDbl(TryCast(myGridView.FindRowCellTemplateControlByKey(key, TryCast(myGridView.Columns("AmountWriteoffc"), GridViewDataColumn), "txtAmountWriteoff"), ASPxTextBox).Text)
                Catch ex As Exception
                End Try
                If AmountToPay + AmountWriteoff > RemainingAmount Then
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
        If txtEventType.Text = "Cash" Then
            sharesPostDesc = "Cash Dividend"
            sharesWriteoffDesc = "Write-off"
            myGridView = grdPaymentsCash
        End If
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
    Sub PostTempDataOption()
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
        Dim myGridView As New ASPxGridView
        myGridView = grdPaymentsOption
        Dim keys As List(Of Object) = myGridView.GetCurrentPageRowValues(New String() {"SEQ"})
        For Each key As Object In keys
            If TryCast(myGridView.FindRowCellTemplateControlByKey(key, TryCast(myGridView.Columns("Selec"), GridViewDataColumn), "chk1"), ASPxCheckBox).Checked = True Then
                Dim AmountToPay As Double = 0, AmountWriteoff As Double = 0
                Dim SharesToPay As Long = 0, SharesToWriteoff As Long = 0
                Try
                    AmountToPay = CDbl(TryCast(myGridView.FindRowCellTemplateControlByKey(key, TryCast(myGridView.Columns("AmountToPayc"), GridViewDataColumn), "txtAmountToPay"), ASPxTextBox).Text)
                Catch ex As Exception
                End Try
                Try
                    AmountWriteoff = CDbl(TryCast(myGridView.FindRowCellTemplateControlByKey(key, TryCast(myGridView.Columns("AmountWriteoffc"), GridViewDataColumn), "txtAmountWriteoff"), ASPxTextBox).Text)
                Catch ex As Exception
                End Try
                Try
                    SharesToPay = CLng(TryCast(myGridView.FindRowCellTemplateControlByKey(key, TryCast(myGridView.Columns("SharesToPostc"), GridViewDataColumn), "txtSharesToPost"), ASPxTextBox).Text)
                Catch ex As Exception
                End Try
                Try
                    SharesToWriteoff = CLng(TryCast(myGridView.FindRowCellTemplateControlByKey(key, TryCast(myGridView.Columns("SharesWriteoffc"), GridViewDataColumn), "txtSharesWriteoff"), ASPxTextBox).Text)
                Catch ex As Exception
                End Try
                Dim Shareholder As String = TryCast(myGridView.FindRowCellTemplateControlByKey(key, TryCast(myGridView.Columns("shareholder"), GridViewDataColumn), "lblshareholder"), ASPxLabel).Text
                Dim AssetManager As String = TryCast(myGridView.FindRowCellTemplateControlByKey(key, TryCast(myGridView.Columns("AssetManager"), GridViewDataColumn), "lblAssetManager"), ASPxLabel).Text
                Dim stmnt As String = " "
                If AmountToPay > 0 Then
                    stmnt = " INSERT INTO DivPayments_temp([Company], [Div_No], [Shareholder], [AssetManager], [AmountPaid], [PaidBy], [PaymentType],[Shares])VALUES(@Company,@Div_No,@Shareholder,@AssetManager,'" & AmountToPay & "',@PaidBy,'Cash Dividend',0) "
                End If
                If AmountWriteoff > 0 Then
                    stmnt = stmnt & " INSERT INTO DivPayments_temp([Company], [Div_No], [Shareholder], [AssetManager], [AmountPaid], [PaidBy], [PaymentType],[Shares])VALUES(@Company,@Div_No,@Shareholder,@AssetManager,'" & AmountWriteoff & "',@PaidBy,'Write-off',0) "
                End If
                If SharesToPay > 0 Then
                    stmnt = " INSERT INTO DivPayments_temp([Company], [Div_No], [Shareholder], [AssetManager], [AmountPaid], [PaidBy], [PaymentType],[Shares])VALUES(@Company,@Div_No,@Shareholder,@AssetManager,0,@PaidBy,'Option Shares','" & SharesToPay & "') "
                End If
                If SharesToWriteoff > 0 Then
                    stmnt = " INSERT INTO DivPayments_temp([Company], [Div_No], [Shareholder], [AssetManager], [AmountPaid], [PaidBy], [PaymentType],[Shares])VALUES(@Company,@Div_No,@Shareholder,@AssetManager,0,@PaidBy,'Write-off Shares','" & SharesToWriteoff & "') "
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
        If txtEventType.Text = "Cash" Then
            Dim totalToPay As Double = 0
            Dim totalWriteoff As Double = 0
            Dim myGridView As New ASPxGridView
            myGridView = grdPaymentsCash
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
                    totalToPay += AmountToPay
                    totalWriteoff += AmountWriteoff
                End If
            Next
            lblTotalCashSelected.Text = "Pay: " & totalToPay.ToString("#,#.##") & " . Write-off: " & totalWriteoff.ToString("#,#.##") & " ."
        ElseIf txtEventType.Text = "Option" Then
            Dim totalSharesToPay As Long = 0
            Dim totalToPay As Double = 0
            Dim totalWriteoffMoney As Double = 0
            Dim totalWriteoffShares As Long = 0
            Dim myGridView As New ASPxGridView
            myGridView = grdPaymentsOption
            Dim keys As List(Of Object) = myGridView.GetCurrentPageRowValues(New String() {"SEQ"})
            For Each key As Object In keys
                If TryCast(myGridView.FindRowCellTemplateControlByKey(key, TryCast(myGridView.Columns("Selec"), GridViewDataColumn), "chk1"), ASPxCheckBox).Checked = True Then
                    Dim AmountToPay As Double = 0, AmountWriteoff As Double = 0
                    Dim SharesToPay As Long = 0, SharesToWriteoff As Long = 0
                    Try
                        AmountToPay = CDbl(TryCast(myGridView.FindRowCellTemplateControlByKey(key, TryCast(myGridView.Columns("AmountToPayc"), GridViewDataColumn), "txtAmountToPay"), ASPxTextBox).Text)
                    Catch ex As Exception
                    End Try
                    Try
                        AmountWriteoff = CDbl(TryCast(myGridView.FindRowCellTemplateControlByKey(key, TryCast(myGridView.Columns("AmountWriteoffc"), GridViewDataColumn), "txtAmountWriteoff"), ASPxTextBox).Text)
                    Catch ex As Exception
                    End Try
                    Try
                        SharesToPay = CLng(TryCast(myGridView.FindRowCellTemplateControlByKey(key, TryCast(myGridView.Columns("SharesToPostc"), GridViewDataColumn), "txtSharesToPost"), ASPxTextBox).Text)
                    Catch ex As Exception
                    End Try
                    Try
                        SharesToWriteoff = CLng(TryCast(myGridView.FindRowCellTemplateControlByKey(key, TryCast(myGridView.Columns("SharesWriteoffc"), GridViewDataColumn), "txtSharesWriteoff"), ASPxTextBox).Text)
                    Catch ex As Exception
                    End Try
                    totalSharesToPay += SharesToPay
                    totalToPay += AmountToPay
                    totalWriteoffMoney += AmountWriteoff
                    totalWriteoffShares += SharesToWriteoff
                End If
            Next
            lblTotalCashSelected.Text = "Pay: " & totalToPay.ToString("#,#.##") & " . Write-off: " & totalWriteoffMoney.ToString("#,#.##") & " . Total Shares to Post: " & totalSharesToPay.ToString("#,#") & " . Total write-off shares: " & totalWriteoffShares.ToString("#,#")
        End If
    End Sub
    Function getDividendDataFXN() As DataSet
        Dim strSQL As String = " "
        If txtEventType.Text = "Cash" Then
            strSQL = "SELECT a.*,isnull(c.PaidAmount,0) as PaidAmount,a.actual_nett-isnull(c.PaidAmount,0) as RemainingAmount,0 as RemainingShares FROM dividend a left outer join (SELECT b.company,b.Div_No,b.Shareholder,b.AssetManager,sum(b.AmountPaid) as PaidAmount FROM DivPayments b WHERE ISNULL(b.Authorized,0) in (0,1) group by b.company,b.Div_No,b.Shareholder,b.AssetManager) c On a.company=c.Company and a.div_no=c.Div_No and a.shareholder=c.Shareholder and a.AssetManager=c.AssetManager where a.company=@Company and a.div_no=@divNo and a.AssetManager=@AssetManager AND a.actual_nett-isnull(c.PaidAmount,0)>0 Order by RemainingAmount desc"
        ElseIf txtEventType.Text = "Option" Then
            strSQL = "SELECT a.*,isnull(c.PaidAmount,0) as PaidAmount,a.offer_cash-isnull(c.PaidAmount,0) as RemainingAmount,a.actual_shares-isnull(c.PaidShares,0) as RemainingShares FROM dividend a left outer join (SELECT b.company,b.Div_No,b.Shareholder,b.AssetManager,sum(b.AmountPaid) as PaidAmount,sum(b.Shares) as PaidShares FROM DivPayments b WHERE ISNULL(b.Authorized,0) in (0,1) group by b.company,b.Div_No,b.Shareholder,b.AssetManager) c On a.company=c.Company and a.div_no=c.Div_No and a.shareholder=c.Shareholder and a.AssetManager=c.AssetManager where a.company=@Company and a.div_no=@divNo and a.AssetManager=@AssetManager AND (a.offer_cash-isnull(c.PaidAmount,0)>0 OR a.actual_shares-isnull(c.PaidShares,0)>0) Order by RemainingAmount desc"
        Else
            strSQL = "SELECT * FROM dividend where company=@Company and div_no=@divNo and AssetManager=@AssetManager Order by actual_nett desc"
        End If

        Using cn = New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("connpath"))
            Dim ds As New DataSet
            Dim cmd = New SqlCommand(strSQL, cn)
            cmd.Parameters.AddWithValue("@Company", cmbCompany.Value)
            cmd.Parameters.AddWithValue("@divNo", cmbDivNo.Value)
            cmd.Parameters.AddWithValue("@AssetManager", cmbDividendAssetManager.Value)
            Dim adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "dividend")
            If txtEventType.Text = "Cash" Then
                grdPaymentsCash.Visible = True
                grdPaymentsOption.Visible = False
                chkSelectAll.Enabled = True
                chkSelectAll.Checked = False
            Else
                grdPaymentsOption.Visible = True
                grdPaymentsCash.Visible = False
                chkSelectAll.Enabled = True
                chkSelectAll.Checked = False
            End If
            Return ds
        End Using
    End Function
    Protected Sub grdPaymentsOption_DataBinding(sender As Object, e As EventArgs) Handles grdPaymentsOption.DataBinding
        grdPaymentsOption.DataSource = getDividendDataFXN()
    End Sub
    Protected Sub grdPaymentsCash_DataBinding(sender As Object, e As EventArgs) Handles grdPaymentsCash.DataBinding
        grdPaymentsCash.DataSource = getDividendDataFXN()
    End Sub
    Public Sub loadassetmanagers()
        Using cn = New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("connpath"))
            Dim ds As New DataSet
            'Dim cmd = New SqlCommand("select * from para_assetManager WHERE AssetManagerCode IN (select DISTINCT t1.AssetManager from Trans_Bank t1 LEFT join trans_bank_alloc t2 on t1.id=t2.Ref2 where T1.allocated='NOT ALLOCATED'  group by t1.AssetManager, t1.BankAccount, t1.BankName, t1.Amount, t1.Reference, t1.Other_Details, t1.DateCreated, t1.Allocated, t1.AllocatedBy, t1.ApprovedBy, t1.ApprovedDate,t1.ReceivedVia, t1.AllocatedTo, t1.Currency, t1.id having isnull(sum(t2.amount),0)<t1.Amount) order by AssetMananger", cn)
            Dim cmd = New SqlCommand("SELECT UPPER(A.AssetManager) AS AssetManager,ISNULL(B.AssetMananger,'') AS Fnam FROM ( select DISTINCT t1.AssetManager from Trans_Bank t1 LEFT join trans_bank_alloc t2 on t1.id=t2.Ref2 where T1.allocated='NOT ALLOCATED'  group by t1.AssetManager, t1.BankAccount, t1.BankName, t1.Amount, t1.Reference, t1.Other_Details, t1.DateCreated, t1.Allocated, t1.AllocatedBy, t1.ApprovedBy, t1.ApprovedDate,t1.ReceivedVia, t1.AllocatedTo, t1.Currency, t1.id having isnull(sum(t2.amount),0)<t1.Amount )A LEFT OUTER JOIN ( select * from para_assetManager ) B ON A.AssetManager=B.AssetManagerCode ORDER BY B.AssetMananger", cn)
            Dim adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "para_assetManager")
            If (ds.Tables(0).Rows.Count > 0) Then
                cmbassetmanager.DataSource = ds
                cmbassetmanager.TextField = "Fnam"
                cmbassetmanager.ValueField = "AssetManager"
                cmbassetmanager.DataBind()
            Else
                cmbassetmanager.DataSource = Nothing
                cmbassetmanager.DataBind()
            End If
        End Using
    End Sub
    Public Sub loadassetmanagersDividend()
        Using cn = New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("connpath"))
            Dim ds As New DataSet
            Dim cmd = New SqlCommand("select * from para_assetManager order by AssetMananger", cn)
            Dim adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "para_assetManager")
            If (ds.Tables(0).Rows.Count > 0) Then
                cmbDividendAssetManager.DataSource = ds
                cmbDividendAssetManager.TextField = "AssetMananger"
                cmbDividendAssetManager.ValueField = "AssetManagerCode"
                cmbDividendAssetManager.DataBind()
            Else
                cmbDividendAssetManager.DataSource = Nothing
                cmbDividendAssetManager.DataBind()
            End If
        End Using
    End Sub
    Protected Sub cmbassetmanager_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbassetmanager.SelectedIndexChanged
        clearFieldsALL()
        getunallocated(cmbassetmanager.SelectedItem.Value.ToString)
        Try
            cmbDividendAssetManager.Value = cmbassetmanager.SelectedItem.Value.ToString.Trim
        Catch ex As Exception
        End Try
    End Sub
    Public Sub getunallocated(assetmanager As String)
        Using cn = New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("connpath"))
            Dim ds As New DataSet
            Dim cmd = New SqlCommand("select t1.id,t1.AssetManager, t1.BankAccount, t1.BankName, t1.Amount-ISNULL(sum(t2.amount),0) as Amount, t1.Reference, t1.Other_Details, t1.DateCreated, t1.Allocated, t1.AllocatedBy, t1.ApprovedBy, t1.ApprovedDate,t1.ReceivedVia, t1.AllocatedTo, t1.Currency from Trans_Bank t1 LEFT join trans_bank_alloc t2 on t1.id=t2.Ref2 where T1.allocated='NOT ALLOCATED' and T1.AssetManager='" + assetmanager + "'  group by t1.AssetManager, t1.BankAccount, t1.BankName, t1.Amount, t1.Reference, t1.Other_Details, t1.DateCreated, t1.Allocated, t1.AllocatedBy, t1.ApprovedBy, t1.ApprovedDate,t1.ReceivedVia, t1.AllocatedTo, t1.Currency, t1.id having isnull(sum(t2.amount),0)<t1.Amount", cn)
            Dim adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "para_assetManager")
            If (ds.Tables(0).Rows.Count > 0) Then
                ASPxGridView5.DataSource = ds
                ASPxGridView5.DataBind()
                getCompanies()
            Else
                ASPxGridView5.DataSource = Nothing
                ASPxGridView5.DataBind()
            End If
        End Using
    End Sub
    Public Function unallocated_(assetmanager As String) As DataSet
        Using cn = New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("connpath"))
            Dim ds As New DataSet
            Dim cmd = New SqlCommand("select t1.id,t1.AssetManager, t1.BankAccount, t1.BankName, t1.Amount-ISNULL(sum(t2.amount),0) as Amount, t1.Reference, t1.Other_Details, t1.DateCreated, t1.Allocated, t1.AllocatedBy, t1.ApprovedBy, t1.ApprovedDate,t1.ReceivedVia, t1.AllocatedTo, t1.Currency from Trans_Bank t1 LEFT join trans_bank_alloc t2 on t1.id=t2.Ref2 where T1.allocated='NOT ALLOCATED' and T1.AssetManager='" + assetmanager + "'  group by t1.AssetManager, t1.BankAccount, t1.BankName, t1.Amount, t1.Reference, t1.Other_Details, t1.DateCreated, t1.Allocated, t1.AllocatedBy, t1.ApprovedBy, t1.ApprovedDate,t1.ReceivedVia, t1.AllocatedTo, t1.Currency, t1.id having isnull(sum(t2.amount),0)<t1.Amount", cn)
            Dim adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "para_assetManager")
            If (ds.Tables(0).Rows.Count > 0) Then
                Return ds
            Else
                Return Nothing
            End If
        End Using
    End Function
    Private Sub ASPxGridView5_RowCommand(sender As Object, e As ASPxGridViewRowCommandEventArgs) Handles ASPxGridView5.RowCommand
        Dim id As String = e.KeyValue.ToString
        If e.CommandArgs.CommandName.ToString = "Select" Then
            lblselected.Text = id
            getinfor(id)
        End If
    End Sub
    Public Sub getinfor(id As String)
        Using cn = New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("connpath"))
            Dim ds As New DataSet
            Dim cmd = New SqlCommand("select t1.id,t1.AssetManager, t1.BankAccount, t1.BankName, t1.Amount-ISNULL(sum(t2.amount),0) as Amount, t1.Reference, t1.Other_Details, t1.DateCreated, t1.Allocated, t1.AllocatedBy, t1.ApprovedBy, t1.ApprovedDate,t1.ReceivedVia, t1.AllocatedTo, t1.Currency from Trans_Bank t1 LEFT join trans_bank_alloc t2 on t1.id=t2.Ref2 where T1.allocated='NOT ALLOCATED' and T1.ID='" + id + "'  group by t1.AssetManager, t1.BankAccount, t1.BankName, t1.Amount, t1.Reference, t1.Other_Details, t1.DateCreated, t1.Allocated, t1.AllocatedBy, t1.ApprovedBy, t1.ApprovedDate,t1.ReceivedVia, t1.AllocatedTo, t1.Currency, t1.id having isnull(sum(t2.amount),0)<t1.Amount", cn)
            Dim adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "para_assetManager")
            If (ds.Tables(0).Rows.Count > 0) Then
                Dim amt As Decimal = ds.Tables(0).Rows(0).Item("amount").ToString
                'txtdesc.Text = ds.Tables(0).Rows(0).Item("Other_Details").ToString
                txtAmount.Text = amt.ToString("N")
                txtaccountno.Text = ds.Tables(0).Rows(0).Item("BankAccount").ToString
                txtbankname.Text = ds.Tables(0).Rows(0).Item("BankName").ToString
                txtcurrency2.Text = ds.Tables(0).Rows(0).Item("Currency").ToString
                lblCashBal.Text = amt.ToString("N")
            End If
        End Using
    End Sub
    Sub clearFieldsALL()
        cmbCompany.Text = ""
        cmbCompany.Items.Clear()
        cmbCompany.DataSource = Nothing
        cmbCompany.DataBind()
        cmbDivNo.Text = ""
        cmbDivNo.Items.Clear()
        cmbDivNo.DataSource = Nothing
        cmbDivNo.DataBind()
        txtdesc.Text = ""
        txtAmount.Text = ""
        txtaccountno.Text = ""
        txtbankname.Text = ""
        txtcurrency2.Text = ""
        txtDividendType.Text = ""
        txtEventType.Text = ""
        txtDateCreated.Text = ""
        txtDateClose.Text = ""
        txtPaymentdate.Text = ""
        txtYearEnding.Text = ""
        txtRate.Text = ""
        txtTaxRate.Text = ""
        txtRound.Text = ""
        txtScriptPrice.Text = ""
        txtCurrency.Text = ""
        divScrip1.Visible = False
        grdPaymentsCash.Visible = False
        grdPaymentsOption.Visible = False
        chkSelectAll.Checked = False
        chkSelectAll.Enabled = True
    End Sub
    Private Function getTotalAmountToPayIndividual() As Double
        Dim myGridView As New ASPxGridView
        If txtEventType.Text = "Cash" Then
            myGridView = grdPaymentsCash
        ElseIf txtEventType.Text = "Option" Then
            myGridView = grdPaymentsOption
        End If

        Dim TotalAmountToPay As Double = 0
        Dim keys As List(Of Object) = myGridView.GetCurrentPageRowValues(New String() {"SEQ"})
        For Each key As Object In keys
            If TryCast(myGridView.FindRowCellTemplateControlByKey(key, TryCast(myGridView.Columns("Selec"), GridViewDataColumn), "chk1"), ASPxCheckBox).Checked = True Then
                Dim AmountToPay As Double = 0
                Try
                    AmountToPay = CDbl(TryCast(myGridView.FindRowCellTemplateControlByKey(key, TryCast(myGridView.Columns("AmountToPayc"), GridViewDataColumn), "txtAmountToPay"), ASPxTextBox).Text)
                Catch ex As Exception
                End Try
                TotalAmountToPay += AmountToPay
            End If
        Next
        Return TotalAmountToPay
    End Function

    Private Sub ASPxGridView5_DataBinding(sender As Object, e As EventArgs) Handles ASPxGridView5.DataBinding
        ASPxGridView5.DataSource = unallocated_(cmbassetmanager.SelectedItem.Value.ToString)
    End Sub
    Private Function SomeSelectedClientsDonNotmatchBankAccount() As Boolean
        Dim myGridView As New ASPxGridView
        If txtEventType.Text = "Cash" Then
            myGridView = grdPaymentsCash
        End If

        Dim SelectedCount As Long = 0
        Dim keys As List(Of Object) = myGridView.GetCurrentPageRowValues(New String() {"SEQ"})
        For Each key As Object In keys
            If TryCast(myGridView.FindRowCellTemplateControlByKey(key, TryCast(myGridView.Columns("Selec"), GridViewDataColumn), "chk1"), ASPxCheckBox).Checked = True Then
                Dim shareholderNo As String = ""
                shareholderNo = TryCast(myGridView.FindRowCellTemplateControlByKey(key, TryCast(myGridView.Columns("shareholder"), GridViewDataColumn), "lblshareholder"), ASPxLabel).Text
                If ClientHasThisBankAccount(shareholderNo) = False Then
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
    Private Function SomeSelectedClientsDonNotmatchBankAccountOPTION() As Boolean
        Dim myGridView As New ASPxGridView
        If txtEventType.Text = "Option" Then
            myGridView = grdPaymentsOption
        End If

        Dim SelectedCount As Long = 0
        Dim keys As List(Of Object) = myGridView.GetCurrentPageRowValues(New String() {"SEQ"})
        For Each key As Object In keys
            If TryCast(myGridView.FindRowCellTemplateControlByKey(key, TryCast(myGridView.Columns("Selec"), GridViewDataColumn), "chk1"), ASPxCheckBox).Checked = True Then
                Dim shareholderNo As String = ""
                shareholderNo = TryCast(myGridView.FindRowCellTemplateControlByKey(key, TryCast(myGridView.Columns("shareholder"), GridViewDataColumn), "lblshareholder"), ASPxLabel).Text
                If ClientHasThisBankAccount(shareholderNo) = False Then
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
    Private Function ClientHasThisBankAccount(ByVal myClientNo As String) As Boolean
        Using cn = New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("connpath"))
            Dim ds As New DataSet
            Dim cmd = New SqlCommand("SELECT TOP 1 A.* FROM Client_AssetManagers A WHERE A.ClientNo=@ClientNo AND A.BankAccount=@BankAccNo AND A.BankName=@Bank AND A.Currency=@Currency and A.AssetManager=@Assetmanager AND ISNULL(A.[Status],0)=1", cn)
            cmd.Parameters.AddWithValue("@ClientNo", myClientNo)
            cmd.Parameters.AddWithValue("@BankAccNo", txtaccountno.Text)
            cmd.Parameters.AddWithValue("@Bank", txtbankname.Text)
            cmd.Parameters.AddWithValue("@Currency", txtcurrency2.Text)
            cmd.Parameters.AddWithValue("@Assetmanager", cmbDividendAssetManager.SelectedItem.Value.ToString)
            Dim adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "ClientAssetManagers")
            If (ds.Tables(0).Rows.Count > 0) Then
                Return True
            Else
                Return False
            End If
        End Using
    End Function
    Protected Sub cmbDividendAssetManager_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbDividendAssetManager.SelectedIndexChanged
        getDividendData()
    End Sub
    Private Function OptionDivHasCash() As Boolean
        Dim myGridView As New ASPxGridView
        If txtEventType.Text = "Option" Then
            myGridView = grdPaymentsOption
        End If

        Dim SelectedCash As Double = 0
        Dim keys As List(Of Object) = myGridView.GetCurrentPageRowValues(New String() {"SEQ"})
        For Each key As Object In keys
            If TryCast(myGridView.FindRowCellTemplateControlByKey(key, TryCast(myGridView.Columns("Selec"), GridViewDataColumn), "chk1"), ASPxCheckBox).Checked = True Then
                Dim AmountToPay As Double = 0
                Try
                    AmountToPay = CDbl(TryCast(myGridView.FindRowCellTemplateControlByKey(key, TryCast(myGridView.Columns("AmountToPayc"), GridViewDataColumn), "txtAmountToPay"), ASPxTextBox).Text)
                Catch ex As Exception
                End Try
                SelectedCash = SelectedCash + AmountToPay
            End If
        Next
        If SelectedCash > 0 Then
            Return True
        Else
            Return False
        End If
    End Function
End Class
