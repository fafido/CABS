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

Partial Class Corp_BillSummary
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
                getAssetManagers()
                getClients()
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Protected Sub btnPreview_Click(sender As Object, e As EventArgs) Handles btnPreview.Click
        If cmbAssetManager.Text <> "" And cmbClient.Text <> "" And cmbStatus.Text <> "" Then
            If cmbStatus.Text = "NOT Billed" Then
                If IsDate(txtFromDate.Text) = False Or IsDate(txtToDate.Text) = False Then
                    msgbox("Select Dates")
                    Exit Sub
                End If
            End If
            Dim strscript As String
            strscript = "<script langauage=JavaScript>"
            strscript += "window.open('frmInvoiceSummaryReport.aspx?assetManager=" & cmbAssetManager.Value & "&clientno=" & cmbClient.Value & "&DateFrom=" & txtFromDate.Text & "&DateTo=" & txtToDate.Text & "&Status=" & cmbStatus.Text & "');"
            strscript += "</script>"
            ClientScript.RegisterStartupScript(Me.GetType(), "newwin", strscript)
        Else
            msgbox("Select Asset Manager, Status and Client")
            Exit Sub
        End If
    End Sub
    Sub getAssetManagers()
        Using cn = New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("connpath"))
            Dim ds As New DataSet
            Dim cmd = New SqlCommand("SELECT * FROM (SELECT 'ALL' AS AssetManagerCode,'ALL' AS AssetMananger, 0 as Ordr  UNION SELECT AssetManagerCode,AssetMananger,1 AS Ordr FROM para_assetManager) D ORDER BY D.Ordr,D.AssetMananger", cn)
            Dim adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "para_assetManager")
            If ds.Tables(0).Rows.Count > 0 Then
                cmbAssetManager.DataSource = ds
                cmbAssetManager.ValueField = "AssetManagerCode"
                cmbAssetManager.TextField = "AssetMananger"
                cmbAssetManager.DataBind()
            Else
                cmbAssetManager.DataSource = Nothing
                cmbAssetManager.DataBind()
            End If
        End Using
    End Sub
    Sub getClients()
        Using cn = New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("connpath"))
            Dim ds As New DataSet
            Dim cmd = New SqlCommand("SELECT * FROM (SELECT 'ALL' AS CDS_Number,'ALL' AS namess, 0 as Ordr  UNION SELECT A.CDS_Number,CASE WHEN A.AccountType IN ('C','P') THEN ISNULL(A.Surname,'') ELSE ISNULL(A.Forenames,'')+ ' '+ISNULL(A.Surname,'') END + ' ' + isnull(A.CDS_Number,'')AS namess, 1 as Ordr FROM Accounts_Clients A ) W ORDER BY W.Ordr,W.namess", cn)
            Dim adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "Accounts_Clients")
            If ds.Tables(0).Rows.Count > 0 Then
                cmbClient.DataSource = ds
                cmbClient.ValueField = "CDS_Number"
                cmbClient.TextField = "namess"
                cmbClient.DataBind()
            Else
                cmbClient.DataSource = Nothing
                cmbClient.DataBind()
            End If
        End Using
    End Sub
End Class
