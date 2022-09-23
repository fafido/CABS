Partial Class TransferSec_newaccs
    Inherits System.Web.UI.Page
    Dim constr As String = (System.Configuration.ConfigurationManager.AppSettings("connpath"))
    Dim cn As New SqlConnection(constr)
    Dim adp As SqlDataAdapter
    Dim cmd As SqlCommand
    Public Sub msgbox(ByVal strMessage As String)

        'finishes server processing, returns to client.
        Dim strScript As String = "<script language=JavaScript>"
        strScript += "window.alert(""" & strMessage & """);"
        strScript += "</script>"
        Dim lbl As New System.Web.UI.WebControls.Label
        lbl.Text = strScript
        Page.Controls.Add(lbl)

    End Sub
    Public Sub checkSessionState()
        Try

        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Session("finish") = "yes" Then
                Session("finish") = ""
                msgbox(" Account Successfully Created")
            End If
            If Request.QueryString("exists") = "1" Then
                msgbox("Account Already being processed!")
            End If
            Page.MaintainScrollPositionOnPostBack = True
            If (Not IsPostBack) Then
                checkSessionState()
                
                getCompany()

            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub getCompany()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("SELECT [CdsNumber], [IdNumber], [Surname], [Forename], [Total],  [AccountType], [Date] FROM [CDS].[dbo].[AccountNewDetails] where Status=0 and cdsNumber not in (select cds_number from accounts_audit)", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "para_company")
            If ds.Tables("para_company").Rows.Count > 0 Then
                grdApps.DataSource = ds
                grdApps.DataBind()
            Else
                grdApps.DataSource = Nothing
                grdApps.DataBind()
            End If
           
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
   
    Protected Sub grdApps_SelectedIndexChanged(sender As Object, e As EventArgs) Handles grdApps.SelectedIndexChanged
        If grdApps.SelectedRow.Cells(6).Text.Trim = "C" Then
            Response.Redirect("AccountsCreations_corpB.aspx?acctype=" + grdApps.SelectedRow.Cells(6).Text.Trim + "&ID=" + grdApps.SelectedRow.Cells(2).Text.Trim + "&cds=" + grdApps.SelectedRow.Cells(1).Text.Trim + "")
        Else
            Response.Redirect("AccountsCreationsB.aspx?acctype=" + grdApps.SelectedRow.Cells(6).Text.Trim + "&ID=" + grdApps.SelectedRow.Cells(2).Text.Trim + "&cds=" + grdApps.SelectedRow.Cells(1).Text.Trim + "")
        End If
    End Sub
End Class
