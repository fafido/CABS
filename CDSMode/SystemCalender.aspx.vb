Imports System.Data
Imports System.Data.SqlClient
Partial Class SystemCalender
    Inherits System.Web.UI.Page
    Dim constr As String = (System.Configuration.ConfigurationManager.AppSettings("connpath"))
    Dim cn As New SqlConnection(constr)
    Dim cmd As SqlCommand
    Dim adp As SqlDataAdapter
  
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Page.MaintainScrollPositionOnPostBack = True
        If Not IsPostBack Then
            
        End If
    End Sub

    Public Sub msgbox(ByVal strMessage As String)

        'finishes server processing, returns to client.
        Dim strScript As String = "<script language=JavaScript>"
        strScript += "window.alert(""" & strMessage & """);"
        strScript += "</script>"
        Dim lbl As New System.Web.UI.WebControls.Label
        lbl.Text = strScript
        Page.Controls.Add(lbl)

    End Sub
    
    Protected Sub rdLockGroup_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdLockGroup.CheckedChanged
        Try
            If (rdLockGroup.Checked = True) Then
                cmbGroups.Visible = True
                Dim dsi As New DataSet
                cmd = New SqlCommand("select distinct (CompanyAccounts .CompanyType ) from CompanyAccounts ", cn)
                adp = New SqlDataAdapter(cmd)
                adp.Fill(dsi, "companyAccounts")
                If (dsi.Tables(0).Rows.Count > 0) Then
                    cmbGroups.DataSource = dsi.Tables(0)
                    cmbGroups.DataValueField = "Companytype"
                    cmbGroups.DataBind()
                End If
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub rdLockSystem_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdLockSystem.CheckedChanged
        Try
            If (rdLockSystem.Checked = True) Then
                cmbGroups.Visible = False
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub rdGrant_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdGrant.CheckedChanged
        Try
            If (rdGrant.Checked = True) Then
                cmbGroups.Visible = False
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
End Class
