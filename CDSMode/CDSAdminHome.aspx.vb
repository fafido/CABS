Imports System.Data
Imports System.Data.SqlClient
Partial Class CDSMode_CDSAdminHome
    Inherits System.Web.UI.Page
    Dim constr As String = (System.Configuration.ConfigurationManager.AppSettings("connpath"))
    Dim cn As New SqlConnection(constr)
    Dim cmd As SqlCommand
    Dim adp As SqlDataAdapter
    Dim ds As New DataSet
    Dim maxholder As Integer = 0
 
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
        If (Not IsPostBack) Then
            Label4.Text = "Logged on as " & Session("UserName").ToString & " of " & Session("UserCompany")
            GetEventsData()
        End If
    End Sub
    Public Sub GetEventsData()
        Try
            Dim ds As New DataSet
            Dim EventStartDate As Date = Now.Date.AddDays(2)
            Label6.Text = EventStartDate
            cmd = New SqlCommand("select company as [Company], caption as [Meeting Agenda], convert(varchar,eventdate,103) as [Start Date], Details as [Meeting Details], convert(varchar,EventEndDate,103) as [End Date] from tbl_EventsDiary where EventDate <='" & EventStartDate & "' and eventEndDate >='" & Now.Date & "'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "tbl_EventsDiary")
            If (ds.Tables(0).Rows.Count > 0) Then
                grdEventsDiary.DataSource = ds.Tables(0)
                grdEventsDiary.DataBind()
            Else
                grdEventsDiary.DataSource = Nothing
                grdEventsDiary.DataBind()


            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
End Class
