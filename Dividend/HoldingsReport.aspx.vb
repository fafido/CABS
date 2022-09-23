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

Partial Class CORPHldingsReport
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
            Dim cmd = New SqlCommand("select * from para_company order by fnam", cn)
            Dim adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "para_company")
            If ds.Tables(0).Rows.Count > 0 Then
                cmbCompany.DataSource = ds
                cmbCompany.ValueField = "Company"
                cmbCompany.TextField = "fnam"
                cmbCompany.DataBind()
            Else
                cmbCompany.DataSource = Nothing
                cmbCompany.DataBind()
            End If
        End Using
    End Sub
    Sub getAssetManagers()
        Using cn = New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("connpath"))
            Dim ds As New DataSet
            Dim cmd = New SqlCommand("SELECT 'ALL' AS AssetManager,'ALL' AS AssetManagerCode, 1 as [Rank] union SELECT A.AssetMananger,A.AssetManagerCode,2 AS [Rank] FROM para_assetManager A JOIN ( SELECT DISTINCT AssetManager as TransAssetManager FROM TRANS WHERE COMPANY=@COMPANY ) B ON A.AssetManagerCode=B.TransAssetManager ORDER BY [Rank],[AssetManager]", cn)
            cmd.Parameters.AddWithValue("@COMPANY", cmbCompany.Value)
            Dim adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "para_assetManager")
            If ds.Tables(0).Rows.Count > 0 Then
                cmbAssetManager.DataSource = ds
                cmbAssetManager.ValueField = "AssetManagerCode"
                cmbAssetManager.TextField = "AssetManager"
                cmbAssetManager.DataBind()
            Else
                cmbAssetManager.DataSource = Nothing
                cmbAssetManager.DataBind()
            End If
        End Using
    End Sub
    Function validateDate(inp As String) As Object
        'Return IIf(IsNumeric(toMoney(inp)), DBNull.Value, inp)
        Return IIf(Trim(inp) = "" Or Not IsDate(inp), DBNull.Value, inp)
    End Function
    Protected Sub btnPreview_Click(sender As Object, e As EventArgs) Handles btnPreview.Click
        If cmbCompany.Text <> "" And cmbAssetManager.Text <> "" And IsDate(txtDate.Text) = True Then
            Dim strscript As String
            strscript = "<script langauage=JavaScript>"
            strscript += "window.open('HoldingsReportPreview.aspx?Company=" & cmbCompany.Value & "&ASAT=" & txtDate.Text & "&AssetManager=" & cmbAssetManager.Value & "');"
            strscript += "</script>"
            ClientScript.RegisterStartupScript(Me.GetType(), "newwin", strscript)
        Else
            msgbox("Select Company, Asset Manager and Date")
        End If
    End Sub
    Protected Sub cmbCompany_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbCompany.SelectedIndexChanged
        getAssetManagers()
    End Sub
End Class
