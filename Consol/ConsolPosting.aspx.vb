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
Imports DevExpress.Web.ASPxGridView
Imports System.Collections.Generic
Imports DevExpress.Web.ASPxEditors

Partial Class Corp_ConsolFinalPosting
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
            Dim cmd = New SqlCommand("SELECT DISTINCT company FROM Consol_instr where Authorize=3 order by company", cn)
            Dim adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "Consol_instr")
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
        getDivnumber()
    End Sub
    Protected Sub cmbIssueNo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbIssueNo.SelectedIndexChanged
        getDivDetails()
    End Sub
    Sub getDivnumber()
        cmbIssueNo.SelectedIndex = -1
        clearFields()
        Dim strSQL As String = ""
        strSQL = "SELECT DISTINCT div_no FROM Consol_instr where Authorize=3 and company=@company order by div_no desc"
        Using cn = New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("connpath"))
            Dim ds As New DataSet
            Dim cmd = New SqlCommand(strSQL, cn)
            cmd.Parameters.AddWithValue("@Company", cmbCompany.Value)
            Dim adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "Consol_instr")
            If ds.Tables(0).Rows.Count > 0 Then
                cmbIssueNo.DataSource = ds
                cmbIssueNo.ValueField = "div_no"
                cmbIssueNo.TextField = "div_no"
                cmbIssueNo.DataBind()
                PanelSAVE.Visible = True
            Else
                cmbIssueNo.DataSource = Nothing
                cmbIssueNo.DataBind()
            End If
        End Using
    End Sub
    Private Function ISSelectedData() As Boolean
        Dim myGridView As New ASPxGridView
        myGridView = grdPaymentsConsol
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
    Private Function SomeSelectedDataMisMatchAmountToPayConsol() As Boolean
        Dim myGridView As New ASPxGridView
        myGridView = grdPaymentsConsol

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
    Sub PostConsol()
        If ISSelectedData() = False Then
            msgbox("Select Records to post")
            Exit Sub
        End If
        If SomeSelectedDataMisMatchAmountToPayConsol() = True Then
            msgbox("Consolidation Shares to Post + Write-off should not exceed remaining Consolidation Shares")
            Exit Sub
        End If
        PostTempData()
        Using cn = New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("connpath"))
            Dim stmnt As String = "Proc_PostConsol"
            Using cmd As New SqlCommand(stmnt, cn)
                cmd.CommandType = CommandType.StoredProcedure
                cmd.CommandTimeout = 0
                cmd.Parameters.Add("@Company", SqlDbType.VarChar).Value = cmbCompany.Value
                cmd.Parameters.Add("@IssueNo", SqlDbType.Decimal).Value = CInt(cmbIssueNo.Value)
                cmd.Parameters.Add("@createdBy", SqlDbType.VarChar).Value = Session("Username")
                If cn.State = ConnectionState.Open Then cn.Close()
                cn.Open()
                cmd.ExecuteNonQuery()
                cn.Close()
            End Using
        End Using
        Response.Write("<script>alert('Consolidation Shares Posted successfully, awaiting authorization') ; location.href='ConsolPosting.aspx'</script>")
    End Sub
    Protected Sub btnPost_Click(sender As Object, e As EventArgs) Handles btnPost.Click
        If IsNumeric(cmbIssueNo.Text) = True Then
            PostConsol()
        End If
    End Sub
    Sub getDivDetails()
        Dim strSQL As String = ""
        clearFields()
        strSQL = "SELECT *,format(date_declared,'dd MMMM yyyy','en-us') as date_declared1,format(date_closed,'dd MMMM yyyy','en-us') as date_closed1,format(date_payment,'dd MMMM yyyy','en-us') as date_payment1,format(date_Yearending,'dd MMMM yyyy','en-us') as date_Yearending1,case when scrip_round='M' then 'Middle' when scrip_round='D' then 'Down' else 'Up' end as scrip_round1 FROM Consol_instr WHERE company=@Company and div_no=@div_no "
        Using cn = New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("connpath"))
            Dim ds As New DataSet
            Dim cmd = New SqlCommand(strSQL, cn)
            cmd.Parameters.AddWithValue("@Company", cmbCompany.Value)
            cmd.Parameters.AddWithValue("@div_no", cmbIssueNo.Value)
            cmd.Parameters.AddWithValue("@createdBy", Session("Username"))
            Dim adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "Consol_instr")
            If ds.Tables(0).Rows.Count > 0 Then
                Dim dr As DataRow = ds.Tables(0).Rows(0)
                txtDateClose.Text = dr.Item("date_closed1").ToString
                txtDatePayment.Text = dr.Item("date_payment1").ToString
                txtMsg1.Text = dr.Item("mess_1").ToString
                txtRound.Text = dr.Item("scrip_round1").ToString
                txtSpecieShares.Text = dr.Item("SpecieOfferShares").ToString
                txtForEvery.Text = dr.Item("SpecieforEvery").ToString
                PanelSAVE.Visible = True
                getConsolData()
            Else
                clearFields()
            End If
        End Using
    End Sub
    Sub clearFields()
        txtDateClose.Text = ""
        txtMsg1.Text = ""
        txtRound.Text = ""
        txtSpecieShares.Text = ""
        txtForEvery.Text = ""
        txtDatePayment.Text = ""
        PanelSAVE.Visible = False
        grdPaymentsConsol.Visible = False
        chkSelectAll.Checked = False
        chkSelectAll.Enabled = True
    End Sub
    Sub getConsolData()
        Dim strSQL As String = " "
        strSQL = "SELECT a.*,a.Scaled_Shares-ISNULL(c.PaidShares,0) as RemainingShares FROM Consol_Issue a left outer join (SELECT b.company,b.Div_No,b.Shareholder,b.AssetManager,sum(b.Shares) as PaidShares FROM ConsolPayments b WHERE ISNULL(b.Authorized,0) in (0,1) group by b.company,b.Div_No,b.Shareholder,b.AssetManager) c On a.company=c.Company and a.Consol_No=c.Div_No and a.Shareholder=c.Shareholder and a.AssetManager=c.AssetManager where a.company=@Company and a.Consol_No=@IssueNo and isnull(a.Scaled_Shares,0)>0 AND (a.Scaled_Shares-isnull(c.PaidShares,0)>0) Order by RemainingShares desc"
        Using cn = New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("connpath"))
            Dim ds As New DataSet
            Dim cmd = New SqlCommand(strSQL, cn)
            cmd.Parameters.AddWithValue("@Company", cmbCompany.Value)
            cmd.Parameters.AddWithValue("@IssueNo", cmbIssueNo.Value)
            Dim adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "Consol_Issue")
            If ds.Tables(0).Rows.Count > 0 Then
                grdPaymentsConsol.DataSource = ds
                grdPaymentsConsol.DataBind()
                grdPaymentsConsol.Visible = True
                chkSelectAll.Enabled = True
                chkSelectAll.Checked = False
            Else
                grdPaymentsConsol.DataSource = Nothing
                grdPaymentsConsol.DataBind()
                grdPaymentsConsol.Visible = False
            End If
        End Using
    End Sub
    Protected Sub chkSelectAll_CheckedChanged(sender As Object, e As EventArgs) Handles chkSelectAll.CheckedChanged
        Dim myGridView As New ASPxGridView
        myGridView = grdPaymentsConsol
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
        Dim totalPostShares As Long = 0
        Dim totalwriteoffConsolShares As Long = 0
        Dim myGridView As New ASPxGridView
        myGridView = grdPaymentsConsol
        Dim keys As List(Of Object) = myGridView.GetCurrentPageRowValues(New String() {"SEQ"})
        For Each key As Object In keys
            If TryCast(myGridView.FindRowCellTemplateControlByKey(key, TryCast(myGridView.Columns("Selec"), GridViewDataColumn), "chk1"), ASPxCheckBox).Checked = True Then
                Dim PostShares As Long = 0, writeoffConsolShares As Long = 0
                Try
                    PostShares = CLng(TryCast(myGridView.FindRowCellTemplateControlByKey(key, TryCast(myGridView.Columns("SharesToPayc"), GridViewDataColumn), "txtSharesToPay"), ASPxTextBox).Text)
                Catch ex As Exception
                End Try
                Try
                    writeoffConsolShares = CLng(TryCast(myGridView.FindRowCellTemplateControlByKey(key, TryCast(myGridView.Columns("SharesWriteoffc"), GridViewDataColumn), "txtSharesWriteoff"), ASPxTextBox).Text)
                Catch ex As Exception
                End Try
                totalPostShares += PostShares
                totalwriteoffConsolShares += writeoffConsolShares
            End If
        Next
        lblTotalCashSelected.Text = "Consolidation Shares to Post: " & totalPostShares.ToString("#,#") & " . Write-off Consolidation Shares: " & totalwriteoffConsolShares.ToString("#,#") & ""
    End Sub
    Sub PostTempData()
        Using cn = New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("connpath"))
            Dim stmnt As String = "DELETE FROM ConsolPayments_temp WHERE PaidBy=@PaidBy"
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
        myGridView = grdPaymentsConsol
        Dim sharesPostDesc As String = ""
        Dim sharesWriteoffDesc As String = ""
        sharesPostDesc = "Consolidation Shares"
        sharesWriteoffDesc = "Write-off Consolidation Shares"
        Dim keys As List(Of Object) = myGridView.GetCurrentPageRowValues(New String() {"SEQ"})
        For Each key As Object In keys
            If TryCast(myGridView.FindRowCellTemplateControlByKey(key, TryCast(myGridView.Columns("Selec"), GridViewDataColumn), "chk1"), ASPxCheckBox).Checked = True Then
                Dim Shareholder As String = TryCast(myGridView.FindRowCellTemplateControlByKey(key, TryCast(myGridView.Columns("Shareholder"), GridViewDataColumn), "lblshareholder"), ASPxLabel).Text
                Dim AssetManager As String = TryCast(myGridView.FindRowCellTemplateControlByKey(key, TryCast(myGridView.Columns("AssetManager"), GridViewDataColumn), "lblAssetManager"), ASPxLabel).Text
                Dim PostShares As Long = 0, writeoffConsolShares As Long = 0
                Try
                    PostShares = CLng(TryCast(myGridView.FindRowCellTemplateControlByKey(key, TryCast(myGridView.Columns("SharesToPayc"), GridViewDataColumn), "txtSharesToPay"), ASPxTextBox).Text)
                Catch ex As Exception
                End Try
                Try
                    writeoffConsolShares = CLng(TryCast(myGridView.FindRowCellTemplateControlByKey(key, TryCast(myGridView.Columns("SharesWriteoffc"), GridViewDataColumn), "txtSharesWriteoff"), ASPxTextBox).Text)
                Catch ex As Exception
                End Try
                Dim stmnt As String = " "
                If PostShares > 0 Then
                    stmnt = " INSERT INTO ConsolPayments_temp([Company], [Div_No], [Shareholder], [AssetManager], [AmountPaid], [PaidBy], [PaymentType],[Shares])VALUES(@Company,@IssueNo,@Shareholder,@AssetManager,0,@PostedBy,'" & sharesPostDesc & "','" & PostShares & "') "
                End If
                If writeoffConsolShares > 0 Then
                    stmnt = stmnt & " INSERT INTO ConsolPayments_temp([Company], [Div_No], [Shareholder], [AssetManager], [AmountPaid], [PaidBy], [PaymentType],[Shares])VALUES(@Company,@IssueNo,@Shareholder,@AssetManager,0,@PostedBy,'" & sharesWriteoffDesc & "','" & writeoffConsolShares & "') "
                End If
                Using cn = New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("connpath"))
                    Using cmd As New SqlCommand(stmnt, cn)
                        cmd.CommandType = CommandType.Text
                        cmd.CommandTimeout = 0
                        cmd.Parameters.AddWithValue("@Company", cmbCompany.Value)
                        cmd.Parameters.AddWithValue("@IssueNo", cmbIssueNo.Value)
                        cmd.Parameters.AddWithValue("@Shareholder", Shareholder)
                        cmd.Parameters.AddWithValue("@AssetManager", AssetManager)
                        cmd.Parameters.AddWithValue("@PostedBy", Session("Username"))
                        If cn.State = ConnectionState.Open Then cn.Close()
                        cn.Open()
                        cmd.ExecuteNonQuery()
                        cn.Close()
                    End Using
                End Using
            End If
        Next
    End Sub
    Protected Sub grdPaymentsConsol_DataBinding(sender As Object, e As EventArgs) Handles grdPaymentsConsol.DataBinding
        grdPaymentsConsol.DataSource = getConsolDataDSET()
    End Sub
    Function getConsolDataDSET() As DataSet
        Dim strSQL As String = " "
        strSQL = "SELECT a.*,a.Scaled_Shares-ISNULL(c.PaidShares,0) as RemainingShares FROM Consol_Issue a left outer join (SELECT b.company,b.Div_No,b.Shareholder,b.AssetManager,sum(b.Shares) as PaidShares FROM ConsolPayments b WHERE ISNULL(b.Authorized,0) in (0,1) group by b.company,b.Div_No,b.Shareholder,b.AssetManager) c On a.company=c.Company and a.Consol_No=c.Div_No and a.Shareholder=c.Shareholder and a.AssetManager=c.AssetManager where a.company=@Company and a.Consol_No=@IssueNo and isnull(a.Scaled_Shares,0)>0 AND (a.Scaled_Shares-isnull(c.PaidShares,0)>0) Order by RemainingShares desc"
        Using cn = New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("connpath"))
            Dim ds As New DataSet
            Dim cmd = New SqlCommand(strSQL, cn)
            cmd.Parameters.AddWithValue("@Company", cmbCompany.Value)
            cmd.Parameters.AddWithValue("@IssueNo", cmbIssueNo.Value)
            Dim adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "Consol_Issue")
            If ds.Tables(0).Rows.Count > 0 Then
                grdPaymentsConsol.Visible = True
                chkSelectAll.Enabled = True
                chkSelectAll.Checked = False
            Else
                grdPaymentsConsol.Visible = False
            End If
            Return ds
        End Using
    End Function
End Class
