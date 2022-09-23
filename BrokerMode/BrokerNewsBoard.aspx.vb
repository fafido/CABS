Imports System.Data
Imports System.Data.SqlClient
Partial Class BrokerMode_BrokerNewsBoard
    Inherits System.Web.UI.Page
    Dim constr As String = (System.Configuration.ConfigurationManager.AppSettings("connpath"))
    Dim cn As New SqlConnection(constr)
    Dim cmd As SqlCommand
    Dim adp As SqlDataAdapter
    Dim ds As New DataSet
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
        Page.MaintainScrollPositionOnPostBack = True
        Try
            If (Not IsPostBack) Then
                lblDtate.Text = Now.Date & " Day: " & Now.DayOfWeek & " of the week, Day: " & Now.DayOfYear & " of the year."
                getNewz()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Public Sub getNewz()
        Try
            cmd = New SqlCommand("select company as Company, audience as [Target Group],Newz,Post_by as Author,date_Of_Post as [Published On] from NewzBoard", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "NewzBoard")
            If (ds.Tables(0).Rows.Count > 0) Then
                gdNewzUpdate.DataSource = ds.Tables(0)
                gdNewzUpdate.DataBind()
            Else
                lblNewzStatus.Text = "No news Update"
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Protected Sub GridView1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gdNewzUpdate.SelectedIndexChanged

    End Sub
End Class
