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

Partial Class Corp_MergerReports
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
            Dim cmd = New SqlCommand("SELECT DISTINCT company FROM Merger_instr order by company", cn)
            Dim adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "Merger_instr")
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
    Sub getDivnumber()
        cmbIssueNo.SelectedIndex = -1
        Dim strSQL As String = ""
        strSQL = "SELECT DISTINCT div_no FROM Merger_instr where company=@company order by div_no desc"
        Using cn = New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("connpath"))
            Dim ds As New DataSet
            Dim cmd = New SqlCommand(strSQL, cn)
            cmd.Parameters.AddWithValue("@Company", cmbCompany.Value)
            Dim adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "Merger_instr")
            If ds.Tables(0).Rows.Count > 0 Then
                cmbIssueNo.DataSource = ds
                cmbIssueNo.ValueField = "div_no"
                cmbIssueNo.TextField = "div_no"
                cmbIssueNo.DataBind()
            Else
                cmbIssueNo.DataSource = Nothing
                cmbIssueNo.DataBind()
            End If
        End Using
    End Sub
    Sub activateLinks()
        If IsNumeric(cmbIssueNo.Text) = True Then
            HyperLink1.Text = "<a href='MergerReportsPreview.aspx?Company=" & cmbCompany.Value & "&IssueNo=" & cmbIssueNo.Value & "&RepType=CS&AssetManager=ALL' target='blank'>Control Summary</a>"
            HyperLink2.Text = "<a href='MergerReportsPreview.aspx?Company=" & cmbCompany.Value & "&IssueNo=" & cmbIssueNo.Value & "&RepType=DS&AssetManager=ALL' target='blank'>Merger Schedule</a>"
            PanelSAVE1.Visible = True
            PanelSAVE2.Visible = True
        End If
    End Sub
    Sub getAssetManagers()
        Dim strSQL As String = ""
        strSQL = "SELECT * FROM (SELECT 'ALL' AS AssetManager,1 AS sn UNION SELECT DISTINCT AssetManager,2 as sn FROM Merger_Issue WHERE company=@Company and Merger_No=@div_no)H order by H.sn, H.AssetManager"
        Using cn = New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("connpath"))
            Dim ds As New DataSet
            Dim cmd = New SqlCommand(strSQL, cn)
            cmd.Parameters.AddWithValue("@Company", cmbCompany.Value)
            cmd.Parameters.AddWithValue("@div_no", cmbIssueNo.Value)
            Dim adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "Bonus_Issue")
            If ds.Tables(0).Rows.Count > 0 Then
                cmbAssetManager.DataSource = ds
                cmbAssetManager.ValueField = "AssetManager"
                cmbAssetManager.TextField = "AssetManager"
                cmbAssetManager.DataBind()
            Else
                cmbAssetManager.DataSource = Nothing
                cmbAssetManager.DataBind()
            End If
        End Using
    End Sub
    Protected Sub cmbAssetManager_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbAssetManager.SelectedIndexChanged
        HyperLink1.Text = "<a href='MergerReportsPreview.aspx?Company=" & cmbCompany.Value & "&IssueNo=" & cmbIssueNo.Value & "&RepType=CS&AssetManager=" & cmbAssetManager.Value & "' target='blank'>Control Summary</a>"
        HyperLink2.Text = "<a href='MergerReportsPreview.aspx?Company=" & cmbCompany.Value & "&IssueNo=" & cmbIssueNo.Value & "&RepType=DS&AssetManager=" & cmbAssetManager.Value & "' target='blank'>Merger Schedule</a>"
    End Sub
    Protected Sub cmbIssueNo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbIssueNo.SelectedIndexChanged
        If IsNumeric(cmbIssueNo.Text) = True Then
            getDivDetails()
            getAssetManagers()
            activateLinks()
        End If
    End Sub
    Sub getDivDetails()
        Dim strSQL As String = ""
        strSQL = "SELECT *,format(date_declared,'dd MMMM yyyy','en-us') as date_declared1,format(date_closed,'dd MMMM yyyy','en-us') as date_closed1,format(date_payment,'dd MMMM yyyy','en-us') as date_payment1,format(date_Yearending,'dd MMMM yyyy','en-us') as date_Yearending1,case when scrip_round='M' then 'Middle' when scrip_round='D' then 'Down' else 'Up' end as scrip_round1 FROM Merger_instr WHERE company=@Company and div_no=@div_no "
        Using cn = New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("connpath"))
            Dim ds As New DataSet
            Dim cmd = New SqlCommand(strSQL, cn)
            cmd.Parameters.AddWithValue("@Company", cmbCompany.Value)
            cmd.Parameters.AddWithValue("@div_no", cmbIssueNo.Value)
            cmd.Parameters.AddWithValue("@createdBy", Session("Username"))
            Dim adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "Merger_instr")
            If ds.Tables(0).Rows.Count > 0 Then
                Dim dr As DataRow = ds.Tables(0).Rows(0)
                txtDateClose.Text = dr.Item("date_closed1").ToString
                txtPaymentDate.Text = dr.Item("date_payment1").ToString
                txtMsg1.Text = dr.Item("mess_1").ToString
                txtRound.Text = dr.Item("scrip_round1").ToString
                txtSpecieShares.Text = dr.Item("SpecieOfferShares").ToString
                txtForEvery.Text = dr.Item("SpecieforEvery").ToString
                txtNewCompany.Text = dr.Item("SpecieNewCompany").ToString
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
    End Sub
End Class
