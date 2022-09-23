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

Partial Class Corp_DeMergerPostingAuth
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
            Dim cmd = New SqlCommand("SELECT DISTINCT a.company,b.Fnam FROM DeMergerPayments a join para_company b on a.company=b.Company where ISNULL(a.Authorized,0)=0 and a.PaidBy<>@PaidBy order by a.company", cn)
            cmd.Parameters.AddWithValue("@PaidBy", Session("Username"))
            Dim adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "DeMergerPayments")
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
    Protected Sub cmbIssueNo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbIssueNo.SelectedIndexChanged
        getDivDetails()
    End Sub
    Sub getDivnumber()
        cmbIssueNo.SelectedIndex = -1
        Dim strSQL As String = ""
        strSQL = "SELECT DISTINCT a.div_no FROM DeMerger_Instr a join (SELECT DISTINCT company,div_no FROM DeMergerPayments where ISNULL(Authorized,0)=0 and company=@company and PaidBy<>@PaidBy) b on a.company=b.Company and a.div_no=b.Div_No WHERE a.company=@company order by a.div_no desc"
        Using cn = New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("connpath"))
            Dim ds As New DataSet
            Dim cmd = New SqlCommand(strSQL, cn)
            cmd.Parameters.AddWithValue("@Company", cmbCompany.Value)
            cmd.Parameters.AddWithValue("@PaidBy", Session("Username"))
            Dim adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "DeMerger_Instr")
            If ds.Tables(0).Rows.Count > 0 Then
                cmbIssueNo.DataSource = ds
                cmbIssueNo.ValueField = "div_no"
                cmbIssueNo.TextField = "div_no"
                cmbIssueNo.DataBind()
                PanelSAVE.Visible = True
                PanelSAVE1.Visible = True
            Else
                cmbIssueNo.DataSource = Nothing
                cmbIssueNo.DataBind()
            End If
        End Using
    End Sub
    Sub PostDeMerger()
        If ISSelectedData() = False Then
            msgbox("Select Records to authorize/Reject")
            Exit Sub
        End If
        PostTempDataAuth()
        Using cn = New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("connpath"))
            Dim stmnt As String = "Proc_PostDeMergerAuth"
            Using cmd As New SqlCommand(stmnt, cn)
                cmd.CommandType = CommandType.StoredProcedure
                cmd.CommandTimeout = 0
                cmd.Parameters.Add("@wk_comp", SqlDbType.VarChar).Value = cmbCompany.Value
                cmd.Parameters.Add("@wk_div", SqlDbType.Decimal).Value = CInt(cmbIssueNo.Value)
                cmd.Parameters.Add("@createdBy", SqlDbType.VarChar).Value = Session("Username")
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = RadioButtonList1.SelectedValue
                If cn.State = ConnectionState.Open Then cn.Close()
                cn.Open()
                cmd.ExecuteNonQuery()
                cn.Close()
            End Using
        End Using
        Response.Write("<script>alert('DeMerger Issue Authorized/Rejected successfully') ; location.href='DeMergerPostingAuth.aspx'</script>")
    End Sub
    Protected Sub btnPost_Click(sender As Object, e As EventArgs) Handles btnPost.Click
        If cmbIssueNo.Text <> "" Then
            If RadioButtonList1.SelectedIndex < 0 Then
                msgbox("Select Authorize/Reject")
                Exit Sub
            Else
                PostDeMerger()
            End If
        End If
    End Sub
    Sub getDivDetails()
        clearFields()
        Dim strSQL As String = ""
        strSQL = "SELECT *,format(date_declared,'dd MMMM yyyy','en-us') as date_declared1,format(date_closed,'dd MMMM yyyy','en-us') as date_closed1,format(date_payment,'dd MMMM yyyy','en-us') as date_payment1,format(date_Yearending,'dd MMMM yyyy','en-us') as date_Yearending1,case when scrip_round='M' then 'Middle' when scrip_round='D' then 'Down' else 'Up' end as scrip_round1 FROM DeMerger_Instr WHERE company=@Company and div_no=@div_no"
        Using cn = New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("connpath"))
            Dim ds As New DataSet
            Dim cmd = New SqlCommand(strSQL, cn)
            cmd.Parameters.AddWithValue("@Company", cmbCompany.Value)
            cmd.Parameters.AddWithValue("@div_no", cmbIssueNo.Value)
            Dim adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "DeMerger_Instr")
            If ds.Tables(0).Rows.Count > 0 Then
                Dim dr As DataRow = ds.Tables(0).Rows(0)
                txtDateClose.Text = dr.Item("date_closed1").ToString
                txtPaymentDate.Text = dr.Item("date_payment1").ToString
                txtMsg1.Text = dr.Item("mess_1").ToString
                txtRound.Text = dr.Item("scrip_round1").ToString
                txtSpecieShares.Text = dr.Item("SpecieOfferShares").ToString
                txtForEvery.Text = dr.Item("SpecieforEvery").ToString
                txtNewCompany.Text = dr.Item("SpecieNewCompany").ToString
                PanelSAVE.Visible = True
                getDeMergerData()
            Else
                clearFields()
            End If
        End Using
    End Sub
    Sub clearFields()
        txtDateClose.Text = ""
        txtPaymentDate.Text = ""
        txtMsg1.Text = ""
        txtRound.Text = ""
        txtSpecieShares.Text = ""
        txtForEvery.Text = ""
        txtNewCompany.Text = ""
        PanelSAVE.Visible = False
        grdPaymentsDeMerger.Visible = False
        chkSelectAll.Checked = False
        chkSelectAll.Enabled = True
    End Sub
    Sub getDeMergerData()
        'clear all grids
        grdPaymentsDeMerger.DataSource = Nothing
        grdPaymentsDeMerger.DataBind()
        'clear all grids
        Dim strSQL As String = " "
        strSQL = "SELECT a.*,c.ID,c.AmountPaid,c.PaymentType,c.DatePosted,c.PaidBy,c.PaidShares FROM DeMerger_Issue a join (SELECT b.ID,b.company,b.Div_No,b.Shareholder,b.AssetManager,b.AmountPaid,b.PaymentType,b.PaidBy,format(b.DatePaid,'dd-MMMM-yyyy hh:mm:ss','en-us') as DatePosted,b.Shares as PaidShares FROM DeMergerPayments b WHERE ISNULL(b.Authorized,0) in (0) and b.PaidBy<>@PaidBy) c On a.company=c.Company AND a.Merger_No=c.div_no and a.Shareholder=c.Shareholder and a.AssetManager=c.AssetManager where a.company=@Company and a.Merger_No=@divNo Order by a.Shareholder"
        Using cn = New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("connpath"))
            Dim ds As New DataSet
            Dim cmd = New SqlCommand(strSQL, cn)
            cmd.Parameters.AddWithValue("@Company", cmbCompany.Value)
            cmd.Parameters.AddWithValue("@divNo", cmbIssueNo.Value)
            cmd.Parameters.AddWithValue("@PaidBy", Session("Username"))
            Dim adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "DeMerger_Issue")
            If ds.Tables(0).Rows.Count > 0 Then
                grdPaymentsDeMerger.DataSource = ds
                grdPaymentsDeMerger.DataBind()
                grdPaymentsDeMerger.Visible = True
                chkSelectAll.Enabled = True
                chkSelectAll.Checked = False
            Else
                grdPaymentsDeMerger.DataSource = Nothing
                grdPaymentsDeMerger.DataBind()
                grdPaymentsDeMerger.Visible = False
            End If
        End Using
    End Sub
    Protected Sub chkSelectAll_CheckedChanged(sender As Object, e As EventArgs) Handles chkSelectAll.CheckedChanged
        Dim myGridView As New ASPxGridView
        myGridView = grdPaymentsDeMerger
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
        myGridView = grdPaymentsDeMerger
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
            Dim stmnt As String = "DELETE FROM DeMergerPaymentsAuth_temp WHERE PaidBy=@PaidBy"
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
        myGridView = grdPaymentsDeMerger
        Dim keys As List(Of Object) = myGridView.GetCurrentPageRowValues(New String() {"ID"})
        For Each key As Object In keys
            If TryCast(myGridView.FindRowCellTemplateControlByKey(key, TryCast(myGridView.Columns("Selec"), GridViewDataColumn), "chk1"), ASPxCheckBox).Checked = True Then
                Dim stmnt As String = " "
                stmnt = " IF NOT EXISTS(SELECT TOP 1 H.* FROM DeMergerPaymentsAuth_temp H where H.RecordID=@RecordID AND H.PaidBy=@PaidBy) begin INSERT INTO DeMergerPaymentsAuth_temp([Company], [Div_No], [Shareholder], [AssetManager], [AmountPaid], [DatePaid], [PaidBy], [PaymentType], [RecordID])SELECT [Company], [Div_No], [Shareholder], [AssetManager], [AmountPaid], [DatePaid], @PaidBy, [PaymentType], @RecordID FROM DeMergerPayments s WHERE s.ID=@RecordID AND ISNULL(s.Authorized,0)=0 end "

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
        Dim totalSharesToPay As Long = 0
        Dim totalSharesWriteOff As Long = 0
        Dim myGridView As New ASPxGridView
        myGridView = grdPaymentsDeMerger
        Dim keys As List(Of Object) = myGridView.GetCurrentPageRowValues(New String() {"ID"})
        For Each key As Object In keys
            If TryCast(myGridView.FindRowCellTemplateControlByKey(key, TryCast(myGridView.Columns("Selec"), GridViewDataColumn), "chk1"), ASPxCheckBox).Checked = True Then
                Dim sharesPay As Long = 0
                Dim PayType As String = TryCast(myGridView.FindRowCellTemplateControlByKey(key, TryCast(myGridView.Columns("PaymentTypec"), GridViewDataColumn), "lblPaymentType"), ASPxLabel).Text
                Try
                    sharesPay = CDbl(TryCast(myGridView.FindRowCellTemplateControlByKey(key, TryCast(myGridView.Columns("Sharesc"), GridViewDataColumn), "lblShares"), ASPxLabel).Text)
                Catch ex As Exception
                End Try
                If PayType = "DeMerger Shares" Then
                    totalSharesToPay += sharesPay
                ElseIf PayType = "Write-off DeMerger Shares" Then
                    totalSharesWriteOff += sharesPay
                End If
            End If
        Next
        lblTotalCashSelected.Text = "DeMerger Shares to Post: " & totalSharesToPay.ToString("#,#") & " . Write-off DeMerger Shares: " & totalSharesWriteOff.ToString("#,#")
    End Sub
    Function getMergerDataDSET() As DataSet
        Dim strSQL As String = " "
        strSQL = "SELECT a.*,c.ID,c.AmountPaid,c.PaymentType,c.DatePosted,c.PaidBy,c.PaidShares FROM DeMerger_Issue a join (SELECT b.ID,b.company,b.Div_No,b.Shareholder,b.AssetManager,b.AmountPaid,b.PaymentType,b.PaidBy,format(b.DatePaid,'dd-MMMM-yyyy hh:mm:ss','en-us') as DatePosted,b.Shares as PaidShares FROM DeMergerPayments b WHERE ISNULL(b.Authorized,0) in (0) and b.PaidBy<>@PaidBy) c On a.company=c.Company AND a.Merger_No=c.div_no and a.Shareholder=c.Shareholder and a.AssetManager=c.AssetManager where a.company=@Company and a.Merger_No=@divNo Order by a.Shareholder"
        Using cn = New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("connpath"))
            Dim ds As New DataSet
            Dim cmd = New SqlCommand(strSQL, cn)
            cmd.Parameters.AddWithValue("@Company", cmbCompany.Value)
            cmd.Parameters.AddWithValue("@divNo", cmbIssueNo.Value)
            cmd.Parameters.AddWithValue("@PaidBy", Session("Username"))
            Dim adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "DeMerger_Issue")
            If ds.Tables(0).Rows.Count > 0 Then
                grdPaymentsDeMerger.Visible = True
                chkSelectAll.Enabled = True
                chkSelectAll.Checked = False
            Else
                grdPaymentsDeMerger.Visible = False
            End If
            Return ds
        End Using
    End Function
    Protected Sub grdPaymentsDeMerger_DataBinding(sender As Object, e As EventArgs) Handles grdPaymentsDeMerger.DataBinding
        grdPaymentsDeMerger.DataSource = getMergerDataDSET()
    End Sub
End Class
