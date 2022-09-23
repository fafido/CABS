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
            Dim cmd = New SqlCommand("SELECT DISTINCT a.company,b.Fnam FROM DivPayments a join para_company b on a.company=b.Company where ISNULL(a.Authorized,0)=0 and a.PaidBy<>@PaidBy order by a.company", cn)
            cmd.Parameters.AddWithValue("@PaidBy", Session("Username"))
            Dim adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "DivPayments")
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
        strSQL = "SELECT DISTINCT a.div_no, format(a.date_payment,'MMMM-yyyy','en-us') + ' ' + a.div_type +' '+a.Instr_type +' div no. ' + convert(nvarchar(100),a.div_no) AS displayname FROM div_instr a join (SELECT DISTINCT company,div_no FROM DivPayments where ISNULL(Authorized,0)=0 and company=@company and PaidBy<>@PaidBy) b on a.company=b.Company and a.div_no=b.Div_No WHERE a.company=@company order by a.div_no desc"
        Using cn = New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("connpath"))
            Dim ds As New DataSet
            Dim cmd = New SqlCommand(strSQL, cn)
            cmd.Parameters.AddWithValue("@Company", cmbCompany.Value)
            cmd.Parameters.AddWithValue("@PaidBy", Session("Username"))
            Dim adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "div_instr")
            If ds.Tables(0).Rows.Count > 0 Then
                cmbDivNo.DataSource = ds
                cmbDivNo.ValueField = "div_no"
                cmbDivNo.TextField = "displayname"
                cmbDivNo.DataBind()
                PanelSAVE.Visible = True
                PanelSAVE1.Visible = True
            Else
                cmbDivNo.DataSource = Nothing
                cmbDivNo.DataBind()
            End If
        End Using
    End Sub
    Sub PostDividend()
        If ISSelectedData() = False Then
            msgbox("Select Records to authorize/Reject")
            Exit Sub
        End If
        If txtEventType.Text = "Cash" Then
            PostTempDataAuth()
        ElseIf txtEventType.Text = "Option" Then
            PostTempDataAuthOption()
        ElseIf txtEventType.Text = "Scrip" Then
            PostTempDataAuthScrip()
        ElseIf txtEventType.Text = "Specie" Then
            PostTempDataAuthSpecie()
        End If
        btnPost.Enabled = False
        Using cn = New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("connpath"))
            Dim stmnt As String = "Proc_PostDivPaymentsAuth"
            Using cmd As New SqlCommand(stmnt, cn)
                cmd.CommandType = CommandType.StoredProcedure
                cmd.CommandTimeout = 0
                cmd.Parameters.Add("@wk_comp", SqlDbType.VarChar).Value = cmbCompany.Value
                cmd.Parameters.Add("@wk_div", SqlDbType.Decimal).Value = CInt(cmbDivNo.Value)
                cmd.Parameters.Add("@createdBy", SqlDbType.VarChar).Value = Session("Username")
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = RadioButtonList1.SelectedValue
                If cn.State = ConnectionState.Open Then cn.Close()
                cn.Open()
                cmd.ExecuteNonQuery()
                cn.Close()
            End Using
        End Using
        getDividendData()
        btnPost.Enabled = True
        msgbox("Dividend Payment Authorized/Rejected successfully")
        ' Response.Write("<script>alert('Dividend Payment Authorized/Rejected successfully') ; location.href='dividendPaymentAuth.aspx'</script>")
    End Sub
    Protected Sub btnPost_Click(sender As Object, e As EventArgs) Handles btnPost.Click
        If cmbDivNo.Text <> "" Then
            If RadioButtonList1.SelectedIndex < 0 Then
                msgbox("Select Authorize/Reject")
                Exit Sub
            Else
                PostDividend()
            End If
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
        grdPaymentsCash.Visible = False
        grdPaymentsOption.Visible = False
        grdPaymentsScrip.Visible = False
        grdPaymentsSpecie.Visible = False
        chkSelectAll.Checked = False
        chkSelectAll.Enabled = True
    End Sub
    Sub getDividendData()
        'clear all grids
        grdPaymentsCash.Visible = False
        grdPaymentsOption.Visible = False
        grdPaymentsScrip.Visible = False
        grdPaymentsSpecie.Visible = False
        'clear all grids
        Dim strSQL As String = " "
        If txtEventType.Text = "Cash" Then
            strSQL = "SELECT a.*,c.ID,c.AmountPaid,c.PaymentType,c.DatePosted,c.PaidBy FROM dividend a join (SELECT b.ID,b.company,b.Div_No,b.Shareholder,b.AssetManager,b.AmountPaid,b.PaymentType,b.PaidBy,format(b.DatePaid,'dd-MMMM-yyyy hh:mm:ss','en-us') as DatePosted FROM DivPayments b WHERE ISNULL(b.Authorized,0) in (0) and b.PaidBy<>@PaidBy) c On a.company=c.Company AND a.div_no=c.div_no and a.shareholder=c.Shareholder and a.AssetManager=c.AssetManager where a.company=@Company and a.div_no=@divNo Order by a.shareholder"
        ElseIf txtEventType.Text = "Option" Then
            strSQL = "SELECT a.*,c.ID,c.AmountPaid,c.PaymentType,c.DatePosted,c.PaidBy,c.PaidShares FROM dividend a join (SELECT b.ID,b.company,b.Div_No,b.Shareholder,b.AssetManager,b.AmountPaid,b.PaymentType,b.PaidBy,format(b.DatePaid,'dd-MMMM-yyyy hh:mm:ss','en-us') as DatePosted,b.Shares as PaidShares FROM DivPayments b WHERE ISNULL(b.Authorized,0) in (0) and b.PaidBy<>@PaidBy) c On a.company=c.Company AND a.div_no=c.div_no and a.shareholder=c.Shareholder and a.AssetManager=c.AssetManager where a.company=@Company and a.div_no=@divNo Order by a.shareholder"
        ElseIf txtEventType.Text = "Scrip" Then
            strSQL = "SELECT a.*,c.ID,c.AmountPaid,c.PaymentType,c.DatePosted,c.PaidBy,c.PaidShares FROM dividend a join (SELECT b.ID,b.company,b.Div_No,b.Shareholder,b.AssetManager,b.AmountPaid,b.PaymentType,b.PaidBy,format(b.DatePaid,'dd-MMMM-yyyy hh:mm:ss','en-us') as DatePosted,b.Shares as PaidShares FROM DivPayments b WHERE ISNULL(b.Authorized,0) in (0) and b.PaidBy<>@PaidBy) c On a.company=c.Company AND a.div_no=c.div_no and a.shareholder=c.Shareholder and a.AssetManager=c.AssetManager where a.company=@Company and a.div_no=@divNo Order by a.shareholder"
        ElseIf txtEventType.Text = "Specie" Then
            strSQL = "SELECT a.*,c.ID,c.AmountPaid,c.PaymentType,c.DatePosted,c.PaidBy,c.PaidShares FROM dividend a join (SELECT b.ID,b.company,b.Div_No,b.Shareholder,b.AssetManager,b.AmountPaid,b.PaymentType,b.PaidBy,format(b.DatePaid,'dd-MMMM-yyyy hh:mm:ss','en-us') as DatePosted,b.Shares as PaidShares FROM DivPayments b WHERE ISNULL(b.Authorized,0) in (0) and b.PaidBy<>@PaidBy) c On a.company=c.Company AND a.div_no=c.div_no and a.shareholder=c.Shareholder and a.AssetManager=c.AssetManager where a.company=@Company and a.div_no=@divNo Order by a.shareholder"
        End If
        Using cn = New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("connpath"))
            Dim ds As New DataSet
            Dim cmd = New SqlCommand(strSQL, cn)
            cmd.Parameters.AddWithValue("@Company", cmbCompany.Value)
            cmd.Parameters.AddWithValue("@divNo", cmbDivNo.Value)
            cmd.Parameters.AddWithValue("@PaidBy", Session("Username"))
            Dim adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "dividend")
            If ds.Tables(0).Rows.Count > 0 Then
                If txtEventType.Text = "Cash" Then
                    grdPaymentsCash.DataSource = ds
                    grdPaymentsCash.DataBind()
                    grdPaymentsCash.Visible = True

                    chkSelectAll.Enabled = True
                    chkSelectAll.Checked = False
                ElseIf txtEventType.Text = "Option" Then
                    grdPaymentsOption.DataSource = ds
                    grdPaymentsOption.DataBind()
                    grdPaymentsOption.Visible = True

                    chkSelectAll.Enabled = True
                    chkSelectAll.Checked = False
                ElseIf txtEventType.Text = "Scrip" Then
                    grdPaymentsScrip.DataSource = ds
                    grdPaymentsScrip.DataBind()
                    grdPaymentsScrip.Visible = True

                    chkSelectAll.Enabled = True
                    chkSelectAll.Checked = False
                ElseIf txtEventType.Text = "Specie" Then
                    grdPaymentsSpecie.DataSource = ds
                    grdPaymentsSpecie.DataBind()
                    grdPaymentsSpecie.Visible = True

                    chkSelectAll.Enabled = True
                    chkSelectAll.Checked = False
                End If
            Else
                grdPaymentsCash.Visible = False
                grdPaymentsOption.Visible = False
                grdPaymentsScrip.Visible = False
                grdPaymentsSpecie.Visible = False
            End If
        End Using
    End Sub
    Protected Sub chkSelectAll_CheckedChanged(sender As Object, e As EventArgs) Handles chkSelectAll.CheckedChanged
        Dim myGridView As New ASPxGridView
        If txtEventType.Text = "Cash" Then
            myGridView = grdPaymentsCash
        ElseIf txtEventType.Text = "Option" Then
            myGridView = grdPaymentsOption
        ElseIf txtEventType.Text = "Scrip" Then
            myGridView = grdPaymentsScrip
        ElseIf txtEventType.Text = "Specie" Then
            myGridView = grdPaymentsSpecie
        End If
        If chkSelectAll.Checked = True Then
            Dim keys As List(Of Object) = myGridView.GetCurrentPageRowValues(New String() {"ID"})
            For Each key As Object In keys
                Dim chk As ASPxCheckBox = TryCast(myGridView.FindRowCellTemplateControlByKey(key, TryCast(myGridView.Columns("Selec"), GridViewDataColumn), "chk1"), ASPxCheckBox)
                chk.Checked = True
            Next
        Else
            Dim keys As List(Of Object) = myGridView.GetCurrentPageRowValues(New String() {"ID"})
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
        ElseIf txtEventType.Text = "Option" Then
            myGridView = grdPaymentsOption
        ElseIf txtEventType.Text = "Scrip" Then
            myGridView = grdPaymentsScrip
        ElseIf txtEventType.Text = "Specie" Then
            myGridView = grdPaymentsSpecie
        End If
        Dim SelectedCount As Long = 0
        Dim keys As List(Of Object) = myGridView.GetCurrentPageRowValues(New String() {"ID"})
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
    Sub PostTempDataAuth()
        Using cn = New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("connpath"))
            Dim stmnt As String = "DELETE FROM DivPaymentsAuth_temp WHERE PaidBy=@PaidBy"
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
        myGridView = grdPaymentsCash
        Dim keys As List(Of Object) = myGridView.GetCurrentPageRowValues(New String() {"ID"})
        For Each key As Object In keys
            If TryCast(myGridView.FindRowCellTemplateControlByKey(key, TryCast(myGridView.Columns("Selec"), GridViewDataColumn), "chk1"), ASPxCheckBox).Checked = True Then
                Dim stmnt As String = " "
                stmnt = " IF NOT EXISTS(SELECT TOP 1 H.* FROM DivPaymentsAuth_temp H where H.RecordID=@RecordID AND H.PaidBy=@PaidBy) begin INSERT INTO DivPaymentsAuth_temp([Company], [Div_No], [Shareholder], [AssetManager], [AmountPaid], [DatePaid], [PaidBy], [PaymentType], [RecordID])SELECT [Company], [Div_No], [Shareholder], [AssetManager], [AmountPaid], [DatePaid], @PaidBy, [PaymentType], @RecordID FROM DivPayments s WHERE s.ID=@RecordID AND ISNULL(s.Authorized,0)=0 end "

                Using cn = New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("connpath"))
                    Using cmd As New SqlCommand(stmnt, cn)
                        cmd.CommandType = CommandType.Text
                        cmd.CommandTimeout = 0
                        cmd.Parameters.AddWithValue("@RecordID", key.ToString)
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
    Sub PostTempDataAuthOption()
        Using cn = New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("connpath"))
            Dim stmnt As String = "DELETE FROM DivPaymentsAuth_temp WHERE PaidBy=@PaidBy"
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
        Dim keys As List(Of Object) = myGridView.GetCurrentPageRowValues(New String() {"ID"})
        For Each key As Object In keys
            If TryCast(myGridView.FindRowCellTemplateControlByKey(key, TryCast(myGridView.Columns("Selec"), GridViewDataColumn), "chk1"), ASPxCheckBox).Checked = True Then
                Dim stmnt As String = " "
                stmnt = " IF NOT EXISTS(SELECT TOP 1 H.* FROM DivPaymentsAuth_temp H where H.RecordID=@RecordID AND H.PaidBy=@PaidBy) begin INSERT INTO DivPaymentsAuth_temp([Company], [Div_No], [Shareholder], [AssetManager], [AmountPaid], [DatePaid], [PaidBy], [PaymentType], [RecordID],[Shares])SELECT [Company], [Div_No], [Shareholder], [AssetManager], [AmountPaid], [DatePaid], @PaidBy, [PaymentType], @RecordID,[Shares] FROM DivPayments s WHERE s.ID=@RecordID AND ISNULL(s.Authorized,0)=0 end "

                Using cn = New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("connpath"))
                    Using cmd As New SqlCommand(stmnt, cn)
                        cmd.CommandType = CommandType.Text
                        cmd.CommandTimeout = 0
                        cmd.Parameters.AddWithValue("@RecordID", key.ToString)
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
    Sub PostTempDataAuthScrip()
        Using cn = New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("connpath"))
            Dim stmnt As String = "DELETE FROM DivPaymentsAuth_temp WHERE PaidBy=@PaidBy"
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
        myGridView = grdPaymentsScrip
        Dim keys As List(Of Object) = myGridView.GetCurrentPageRowValues(New String() {"ID"})
        For Each key As Object In keys
            If TryCast(myGridView.FindRowCellTemplateControlByKey(key, TryCast(myGridView.Columns("Selec"), GridViewDataColumn), "chk1"), ASPxCheckBox).Checked = True Then
                Dim stmnt As String = " "
                stmnt = " IF NOT EXISTS(SELECT TOP 1 H.* FROM DivPaymentsAuth_temp H where H.RecordID=@RecordID AND H.PaidBy=@PaidBy) begin INSERT INTO DivPaymentsAuth_temp([Company], [Div_No], [Shareholder], [AssetManager], [AmountPaid], [DatePaid], [PaidBy], [PaymentType], [RecordID],[Shares])SELECT [Company], [Div_No], [Shareholder], [AssetManager], [AmountPaid], [DatePaid], @PaidBy, [PaymentType], @RecordID,[Shares] FROM DivPayments s WHERE s.ID=@RecordID AND ISNULL(s.Authorized,0)=0 end "

                Using cn = New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("connpath"))
                    Using cmd As New SqlCommand(stmnt, cn)
                        cmd.CommandType = CommandType.Text
                        cmd.CommandTimeout = 0
                        cmd.Parameters.AddWithValue("@RecordID", key.ToString)
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
    Sub PostTempDataAuthSpecie()
        Using cn = New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("connpath"))
            Dim stmnt As String = "DELETE FROM DivPaymentsAuth_temp WHERE PaidBy=@PaidBy"
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
        myGridView = grdPaymentsSpecie
        Dim keys As List(Of Object) = myGridView.GetCurrentPageRowValues(New String() {"ID"})
        For Each key As Object In keys
            If TryCast(myGridView.FindRowCellTemplateControlByKey(key, TryCast(myGridView.Columns("Selec"), GridViewDataColumn), "chk1"), ASPxCheckBox).Checked = True Then
                Dim stmnt As String = " "
                stmnt = " IF NOT EXISTS(SELECT TOP 1 H.* FROM DivPaymentsAuth_temp H where H.RecordID=@RecordID AND H.PaidBy=@PaidBy) begin INSERT INTO DivPaymentsAuth_temp([Company], [Div_No], [Shareholder], [AssetManager], [AmountPaid], [DatePaid], [PaidBy], [PaymentType], [RecordID],[Shares])SELECT [Company], [Div_No], [Shareholder], [AssetManager], [AmountPaid], [DatePaid], @PaidBy, [PaymentType], @RecordID,[Shares] FROM DivPayments s WHERE s.ID=@RecordID AND ISNULL(s.Authorized,0)=0 end "

                Using cn = New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("connpath"))
                    Using cmd As New SqlCommand(stmnt, cn)
                        cmd.CommandType = CommandType.Text
                        cmd.CommandTimeout = 0
                        cmd.Parameters.AddWithValue("@RecordID", key.ToString)
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
            Dim keys As List(Of Object) = myGridView.GetCurrentPageRowValues(New String() {"ID"})
            For Each key As Object In keys
                If TryCast(myGridView.FindRowCellTemplateControlByKey(key, TryCast(myGridView.Columns("Selec"), GridViewDataColumn), "chk1"), ASPxCheckBox).Checked = True Then
                    Dim AmountToPay As Double = 0
                    Dim PayType As String = TryCast(myGridView.FindRowCellTemplateControlByKey(key, TryCast(myGridView.Columns("PaymentTypec"), GridViewDataColumn), "lblPaymentType"), ASPxLabel).Text
                    Try
                        AmountToPay = CDbl(TryCast(myGridView.FindRowCellTemplateControlByKey(key, TryCast(myGridView.Columns("Amountc"), GridViewDataColumn), "lblAmount"), ASPxLabel).Text)
                    Catch ex As Exception
                    End Try
                    If PayType = "Write-off" Then
                        totalWriteoff += AmountToPay
                    Else
                        totalToPay += AmountToPay
                    End If
                End If
            Next
            lblTotalCashSelected.Text = "Pay: " & totalToPay.ToString("#,#.##") & " . Write-off: " & totalWriteoff.ToString("#,#.##") & " ."
        ElseIf txtEventType.Text = "Option" Then
            Dim totalSharesToPay As Long = 0
            Dim totalSharesWriteOff As Long = 0
            Dim totalToPay As Double = 0
            Dim totalWriteoff As Double = 0
            Dim myGridView As New ASPxGridView
            myGridView = grdPaymentsOption
            Dim keys As List(Of Object) = myGridView.GetCurrentPageRowValues(New String() {"ID"})
            For Each key As Object In keys
                If TryCast(myGridView.FindRowCellTemplateControlByKey(key, TryCast(myGridView.Columns("Selec"), GridViewDataColumn), "chk1"), ASPxCheckBox).Checked = True Then
                    Dim AmountToPay As Double = 0, sharesPay As Long = 0
                    Dim PayType As String = TryCast(myGridView.FindRowCellTemplateControlByKey(key, TryCast(myGridView.Columns("PaymentTypec"), GridViewDataColumn), "lblPaymentType"), ASPxLabel).Text
                    Try
                        AmountToPay = CDbl(TryCast(myGridView.FindRowCellTemplateControlByKey(key, TryCast(myGridView.Columns("Amountc"), GridViewDataColumn), "lblAmount"), ASPxLabel).Text)
                    Catch ex As Exception
                    End Try
                    Try
                        sharesPay = CDbl(TryCast(myGridView.FindRowCellTemplateControlByKey(key, TryCast(myGridView.Columns("Sharesc"), GridViewDataColumn), "lblShares"), ASPxLabel).Text)
                    Catch ex As Exception
                    End Try
                    If PayType = "Write-off" Then
                        totalWriteoff += AmountToPay
                    ElseIf PayType = "Option Shares" Then
                        totalSharesToPay += sharesPay
                    ElseIf PayType = "Write-off Shares" Then
                        totalSharesWriteOff += sharesPay
                    Else
                        totalToPay += AmountToPay
                    End If
                End If
            Next
            lblTotalCashSelected.Text = "Pay: " & totalToPay.ToString("#,#.##") & " . Write-off: " & totalWriteoff.ToString("#,#.##") & " ." & " Option Shares: " & totalSharesToPay.ToString("#,#") & " . Write-off Shares: " & totalSharesWriteOff.ToString("#,#")
        ElseIf txtEventType.Text = "Scrip" Then
            Dim totalSharesToPay As Long = 0
            Dim totalSharesWriteOff As Long = 0
            Dim myGridView As New ASPxGridView
            myGridView = grdPaymentsScrip
            Dim keys As List(Of Object) = myGridView.GetCurrentPageRowValues(New String() {"ID"})
            For Each key As Object In keys
                If TryCast(myGridView.FindRowCellTemplateControlByKey(key, TryCast(myGridView.Columns("Selec"), GridViewDataColumn), "chk1"), ASPxCheckBox).Checked = True Then
                    Dim sharesPay As Long = 0
                    Dim PayType As String = TryCast(myGridView.FindRowCellTemplateControlByKey(key, TryCast(myGridView.Columns("PaymentTypec"), GridViewDataColumn), "lblPaymentType"), ASPxLabel).Text
                    Try
                        sharesPay = CDbl(TryCast(myGridView.FindRowCellTemplateControlByKey(key, TryCast(myGridView.Columns("Sharesc"), GridViewDataColumn), "lblShares"), ASPxLabel).Text)
                    Catch ex As Exception
                    End Try
                    If PayType = "Scrip Shares" Then
                        totalSharesToPay += sharesPay
                    ElseIf PayType = "Write-off Shares" Then
                        totalSharesWriteOff += sharesPay
                    End If
                End If
            Next
            lblTotalCashSelected.Text = "Scrip Shares: " & totalSharesToPay.ToString("#,#") & " . Write-off Shares: " & totalSharesWriteOff.ToString("#,#")
        ElseIf txtEventType.Text = "Specie" Then
            Dim totalSharesToPay As Long = 0
            Dim totalSharesWriteOff As Long = 0
            Dim myGridView As New ASPxGridView
            myGridView = grdPaymentsSpecie
            Dim keys As List(Of Object) = myGridView.GetCurrentPageRowValues(New String() {"ID"})
            For Each key As Object In keys
                If TryCast(myGridView.FindRowCellTemplateControlByKey(key, TryCast(myGridView.Columns("Selec"), GridViewDataColumn), "chk1"), ASPxCheckBox).Checked = True Then
                    Dim sharesPay As Long = 0
                    Dim PayType As String = TryCast(myGridView.FindRowCellTemplateControlByKey(key, TryCast(myGridView.Columns("PaymentTypec"), GridViewDataColumn), "lblPaymentType"), ASPxLabel).Text
                    Try
                        sharesPay = CDbl(TryCast(myGridView.FindRowCellTemplateControlByKey(key, TryCast(myGridView.Columns("Sharesc"), GridViewDataColumn), "lblShares"), ASPxLabel).Text)
                    Catch ex As Exception
                    End Try
                    If PayType = "Specie Shares" Then
                        totalSharesToPay += sharesPay
                    ElseIf PayType = "Write-off Shares" Then
                        totalSharesWriteOff += sharesPay
                    End If
                End If
            Next
            lblTotalCashSelected.Text = "Specie Shares: " & totalSharesToPay.ToString("#,#") & " . Write-off Shares: " & totalSharesWriteOff.ToString("#,#")
        End If
    End Sub
    Protected Sub grdPaymentsCash_DataBinding(sender As Object, e As EventArgs) Handles grdPaymentsCash.DataBinding
        grdPaymentsCash.DataSource = getDividendDataDSET()
    End Sub
    Protected Sub grdPaymentsOption_DataBinding(sender As Object, e As EventArgs) Handles grdPaymentsOption.DataBinding
        grdPaymentsOption.DataSource = getDividendDataDSET()
    End Sub
    Protected Sub grdPaymentsScrip_DataBinding(sender As Object, e As EventArgs) Handles grdPaymentsScrip.DataBinding
        grdPaymentsScrip.DataSource = getDividendDataDSET()
    End Sub
    Protected Sub grdPaymentsSpecie_DataBinding(sender As Object, e As EventArgs) Handles grdPaymentsSpecie.DataBinding
        grdPaymentsSpecie.DataSource = getDividendDataDSET()
    End Sub
    Function getDividendDataDSET() As DataSet
        grdPaymentsCash.Visible = False
        grdPaymentsOption.Visible = False
        grdPaymentsScrip.Visible = False
        grdPaymentsSpecie.Visible = False
        'clear all grids
        Dim strSQL As String = " "
        If txtEventType.Text = "Cash" Then
            strSQL = "SELECT a.*,c.ID,c.AmountPaid,c.PaymentType,c.DatePosted,c.PaidBy FROM dividend a join (SELECT b.ID,b.company,b.Div_No,b.Shareholder,b.AssetManager,b.AmountPaid,b.PaymentType,b.PaidBy,format(b.DatePaid,'dd-MMMM-yyyy hh:mm:ss','en-us') as DatePosted FROM DivPayments b WHERE ISNULL(b.Authorized,0) in (0) and b.PaidBy<>@PaidBy) c On a.company=c.Company AND a.div_no=c.div_no and a.shareholder=c.Shareholder and a.AssetManager=c.AssetManager where a.company=@Company and a.div_no=@divNo Order by a.shareholder"
        ElseIf txtEventType.Text = "Option" Then
            strSQL = "SELECT a.*,c.ID,c.AmountPaid,c.PaymentType,c.DatePosted,c.PaidBy,c.PaidShares FROM dividend a join (SELECT b.ID,b.company,b.Div_No,b.Shareholder,b.AssetManager,b.AmountPaid,b.PaymentType,b.PaidBy,format(b.DatePaid,'dd-MMMM-yyyy hh:mm:ss','en-us') as DatePosted,b.Shares as PaidShares FROM DivPayments b WHERE ISNULL(b.Authorized,0) in (0) and b.PaidBy<>@PaidBy) c On a.company=c.Company AND a.div_no=c.div_no and a.shareholder=c.Shareholder and a.AssetManager=c.AssetManager where a.company=@Company and a.div_no=@divNo Order by a.shareholder"
        ElseIf txtEventType.Text = "Scrip" Then
            strSQL = "SELECT a.*,c.ID,c.AmountPaid,c.PaymentType,c.DatePosted,c.PaidBy,c.PaidShares FROM dividend a join (SELECT b.ID,b.company,b.Div_No,b.Shareholder,b.AssetManager,b.AmountPaid,b.PaymentType,b.PaidBy,format(b.DatePaid,'dd-MMMM-yyyy hh:mm:ss','en-us') as DatePosted,b.Shares as PaidShares FROM DivPayments b WHERE ISNULL(b.Authorized,0) in (0) and b.PaidBy<>@PaidBy) c On a.company=c.Company AND a.div_no=c.div_no and a.shareholder=c.Shareholder and a.AssetManager=c.AssetManager where a.company=@Company and a.div_no=@divNo Order by a.shareholder"
        ElseIf txtEventType.Text = "Specie" Then
            strSQL = "SELECT a.*,c.ID,c.AmountPaid,c.PaymentType,c.DatePosted,c.PaidBy,c.PaidShares FROM dividend a join (SELECT b.ID,b.company,b.Div_No,b.Shareholder,b.AssetManager,b.AmountPaid,b.PaymentType,b.PaidBy,format(b.DatePaid,'dd-MMMM-yyyy hh:mm:ss','en-us') as DatePosted,b.Shares as PaidShares FROM DivPayments b WHERE ISNULL(b.Authorized,0) in (0) and b.PaidBy<>@PaidBy) c On a.company=c.Company AND a.div_no=c.div_no and a.shareholder=c.Shareholder and a.AssetManager=c.AssetManager where a.company=@Company and a.div_no=@divNo Order by a.shareholder"
        End If
        Using cn = New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("connpath"))
            Dim ds As New DataSet
            Dim cmd = New SqlCommand(strSQL, cn)
            cmd.Parameters.AddWithValue("@Company", cmbCompany.Value)
            cmd.Parameters.AddWithValue("@divNo", cmbDivNo.Value)
            cmd.Parameters.AddWithValue("@PaidBy", Session("Username"))
            Dim adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "dividend")
            If ds.Tables(0).Rows.Count > 0 Then
                If txtEventType.Text = "Cash" Then
                    grdPaymentsCash.Visible = True
                    chkSelectAll.Enabled = True
                    chkSelectAll.Checked = False
                ElseIf txtEventType.Text = "Option" Then
                    grdPaymentsOption.Visible = True
                    chkSelectAll.Enabled = True
                    chkSelectAll.Checked = False
                ElseIf txtEventType.Text = "Scrip" Then
                    grdPaymentsScrip.Visible = True
                    chkSelectAll.Enabled = True
                    chkSelectAll.Checked = False
                ElseIf txtEventType.Text = "Specie" Then
                    grdPaymentsSpecie.Visible = True
                    chkSelectAll.Enabled = True
                    chkSelectAll.Checked = False
                End If
            Else
                grdPaymentsCash.Visible = False
                grdPaymentsOption.Visible = False
                grdPaymentsScrip.Visible = False
                grdPaymentsSpecie.Visible = False
            End If
            Return ds
        End Using
    End Function
End Class
