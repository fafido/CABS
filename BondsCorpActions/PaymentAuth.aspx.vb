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

Partial Class Corp_MMPayment
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
            Dim cmd = New SqlCommand("SELECT DISTINCT a.company FROM MMDivPayments a where ISNULL(a.Authorized,0)=0 and a.PaidBy<>@PaidBy order by a.company", cn)
            cmd.Parameters.AddWithValue("@PaidBy", Session("Username"))
            Dim adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "MMDivPayments")
            If ds.Tables(0).Rows.Count > 0 Then
                cmbCompany.DataSource = ds
                cmbCompany.ValueField = "company"
                cmbCompany.TextField = "company"
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
        strSQL = "SELECT DISTINCT a.div_no, format(a.date_payment,'MMMM-yyyy','en-us') + ' ' + a.div_type +' No. ' + convert(nvarchar(100),a.div_no) AS displayname FROM MM_instr a join (SELECT DISTINCT company,div_no FROM MMDivPayments where ISNULL(Authorized,0)=0 and company=@company and PaidBy<>@PaidBy) b on a.company=b.Company and a.div_no=b.Div_No WHERE a.company=@company order by a.div_no desc"
        Using cn = New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("connpath"))
            Dim ds As New DataSet
            Dim cmd = New SqlCommand(strSQL, cn)
            cmd.Parameters.AddWithValue("@Company", cmbCompany.Value)
            cmd.Parameters.AddWithValue("@PaidBy", Session("Username"))
            Dim adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "MM_instr")
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
        PostTempDataAuth()
        btnPost.Enabled = False
        Using cn = New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("connpath"))
            Dim stmnt As String = "Proc_PostMMPaymentsAuth"
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
        msgbox("Payment Authorized/Rejected successfully")
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
        strSQL = "SELECT *,format(date_declared,'dd MMMM yyyy','en-us') as date_declared1,format(date_closed,'dd MMMM yyyy','en-us') as date_closed1,format(date_payment,'dd MMMM yyyy','en-us') as date_payment1,format(date_Yearending,'dd MMMM yyyy','en-us') as date_Yearending1,case when scrip_round='M' then 'Middle' when scrip_round='D' then 'Down' else 'Up' end as scrip_round1 FROM MM_instr WHERE company=@Company and div_no=@div_no"
        Using cn = New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("connpath"))
            Dim ds As New DataSet
            Dim cmd = New SqlCommand(strSQL, cn)
            cmd.Parameters.AddWithValue("@Company", cmbCompany.Value)
            cmd.Parameters.AddWithValue("@div_no", cmbDivNo.Value)
            Dim adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "MM_instr")
            If ds.Tables(0).Rows.Count > 0 Then
                Dim dr As DataRow = ds.Tables(0).Rows(0)
                txtDividendType.Text = dr.Item("div_type").ToString
                txtDateCreated.Text = dr.Item("date_declared1").ToString
                txtDateClose.Text = dr.Item("date_closed1").ToString
                txtPaymentdate.Text = dr.Item("date_payment1").ToString
                txtYearEnding.Text = dr.Item("date_Yearending1").ToString
                txtTaxRate.Text = dr.Item("TaxRate").ToString
                txtRound.Text = dr.Item("scrip_round1").ToString
                txtCurrency.Text = dr.Item("Currency").ToString
                getDividendData()
            Else
                clearFields()
            End If
        End Using
    End Sub
    Sub clearFields()
        txtDividendType.Text = ""
        txtDateCreated.Text = ""
        txtDateClose.Text = ""
        txtPaymentdate.Text = ""
        txtYearEnding.Text = ""
        txtTaxRate.Text = ""
        txtRound.Text = ""
        txtCurrency.Text = ""
        grdPaymentsCash.Visible = False
        chkSelectAll.Checked = False
        chkSelectAll.Enabled = True
    End Sub
    Sub getDividendData()
        'clear all grids
        grdPaymentsCash.Visible = False
        'clear all grids
        Dim strSQL As String = " "
        strSQL = "SELECT a.*,c.ID,c.AmountPaid,c.PaymentType,c.DatePosted,c.PaidBy FROM MMdividend a join (SELECT b.ID,b.company,b.Div_No,b.Shareholder,b.AssetManager,b.AmountPaid,b.PaymentType,b.PaidBy,format(b.DatePaid,'dd-MMMM-yyyy hh:mm:ss','en-us') as DatePosted FROM MMDivPayments b WHERE ISNULL(b.Authorized,0) in (0) and b.PaidBy<>@PaidBy) c On a.company=c.Company AND a.div_no=c.div_no and a.shareholder=c.Shareholder and a.AssetManager=c.AssetManager where a.company=@Company and a.div_no=@divNo Order by a.shareholder"
        Using cn = New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("connpath"))
            Dim ds As New DataSet
            Dim cmd = New SqlCommand(strSQL, cn)
            cmd.Parameters.AddWithValue("@Company", cmbCompany.Value)
            cmd.Parameters.AddWithValue("@divNo", cmbDivNo.Value)
            cmd.Parameters.AddWithValue("@PaidBy", Session("Username"))
            Dim adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "MMdividend")
            If ds.Tables(0).Rows.Count > 0 Then
                grdPaymentsCash.DataSource = ds
                grdPaymentsCash.DataBind()
                grdPaymentsCash.Visible = True
                chkSelectAll.Enabled = True
                chkSelectAll.Checked = False
            Else
                grdPaymentsCash.Visible = False
            End If
        End Using
    End Sub
    Protected Sub chkSelectAll_CheckedChanged(sender As Object, e As EventArgs) Handles chkSelectAll.CheckedChanged
        Dim myGridView As New ASPxGridView
        myGridView = grdPaymentsCash
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
        myGridView = grdPaymentsCash
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
            Dim stmnt As String = "DELETE FROM MMDivPaymentsAuth_temp WHERE PaidBy=@PaidBy"
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
                stmnt = " IF NOT EXISTS(SELECT TOP 1 H.* FROM MMDivPaymentsAuth_temp H where H.RecordID=@RecordID AND H.PaidBy=@PaidBy) begin INSERT INTO MMDivPaymentsAuth_temp([Company], [Div_No], [Shareholder], [AssetManager], [AmountPaid], [DatePaid], [PaidBy], [PaymentType], [RecordID])SELECT [Company], [Div_No], [Shareholder], [AssetManager], [AmountPaid], [DatePaid], @PaidBy, [PaymentType], @RecordID FROM MMDivPayments s WHERE s.ID=@RecordID AND ISNULL(s.Authorized,0)=0 end "

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
    End Sub
    Protected Sub grdPaymentsCash_DataBinding(sender As Object, e As EventArgs) Handles grdPaymentsCash.DataBinding
        grdPaymentsCash.DataSource = getDividendDataDSET()
    End Sub
    Function getDividendDataDSET() As DataSet
        grdPaymentsCash.Visible = False
        'clear all grids
        Dim strSQL As String = " "
        strSQL = "SELECT a.*,c.ID,c.AmountPaid,c.PaymentType,c.DatePosted,c.PaidBy FROM MMdividend a join (SELECT b.ID,b.company,b.Div_No,b.Shareholder,b.AssetManager,b.AmountPaid,b.PaymentType,b.PaidBy,format(b.DatePaid,'dd-MMMM-yyyy hh:mm:ss','en-us') as DatePosted FROM MMDivPayments b WHERE ISNULL(b.Authorized,0) in (0) and b.PaidBy<>@PaidBy) c On a.company=c.Company AND a.div_no=c.div_no and a.shareholder=c.Shareholder and a.AssetManager=c.AssetManager where a.company=@Company and a.div_no=@divNo Order by a.shareholder"
        Using cn = New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("connpath"))
            Dim ds As New DataSet
            Dim cmd = New SqlCommand(strSQL, cn)
            cmd.Parameters.AddWithValue("@Company", cmbCompany.Value)
            cmd.Parameters.AddWithValue("@divNo", cmbDivNo.Value)
            cmd.Parameters.AddWithValue("@PaidBy", Session("Username"))
            Dim adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "MMdividend")
            If ds.Tables(0).Rows.Count > 0 Then
                grdPaymentsCash.Visible = True
                chkSelectAll.Enabled = True
                chkSelectAll.Checked = False
            Else
                grdPaymentsCash.Visible = False
            End If
            Return ds
        End Using
    End Function
End Class
