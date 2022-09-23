Imports System.Data
Imports System.Data.SqlClient
Partial Class BrokerMode_EventsManagement
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
            If (Session("Username") = Nothing) Then
                Response.Redirect("~\loginsystem.aspx")
                Exit Sub
            End If
            'Label4.Text = "Logged on as " & Session("UserName").ToString & " of " & Session("UserCompany")
            Dim HourofDay As Integer = 0
            HourofDay = TimeOfDay.Hour
            If (HourofDay < 12) Then
                Label4.Text = "Good Morning " & Session("Username").ToString
            ElseIf (HourofDay >= 12 And HourofDay <= 17) Then
                Label4.Text = "Good Afternoon " & Session("Username").ToString
            Else
                Label4.Text = "Good Evening " & Session("username").ToString
            End If
            UpdatePastEvents()
            GetEvents()
        End If
        If Session("finish") = "true" Then
            Session("finish") = ""
            msgbox("Successfully Saved")
        End If
    End Sub
    Public Sub UpdatePastEvents()
        Try
            cmd = New SqlCommand("update tbl_EventsDiary set EventFlag = 'C' where EventEndDate < '" & Now.Date & "'", cn)
            If (cn.State = ConnectionState.Open) Then
                cn.Close()
            End If
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub GetSecurities()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select distinct (security_name) from security_type", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "security_type")
            If (ds.Tables(0).Rows.Count > 0) Then

            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            cmd = New SqlCommand("insert into tbl_EventsDiary (company,caption,EventDate,Details,EventFlag,EventEndDate) values ('" & cmbSecurities.SelectedItem.Text & "','" & txtTitle.Text & "','" & txtStartDate.Date & "','" & txtDetails.Text & "','O','" & txtEndDate.Date & "')", cn)
            If (cn.State = ConnectionState.Open) Then
                cn.Close()
            End If
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()
            Session("finish") = "true"
            Response.Redirect(Request.RawUrl)
        Catch ex As Exception
            msgbox("Please enter valid data in all fields!")
        End Try
    End Sub
    Public Sub GetEvents()
        Try
            Dim ds As New DataSet

            cmd = New SqlCommand("select company as [Company],caption as [Title],eventdate as [Start Date],details as [Event Details], case EventFlag when 'O' THEN 'OPEN' WHEN 'C' then 'CLOSE' end as [Status], EventEndDate as [End Date] from tbl_EventsDiary order by EventDate desc", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "tbl_EventsDiary")
            If (ds.Tables(0).Rows.Count > 0) Then
                grdRules.DataSource = ds.Tables(0)
                grdRules.DataBind()
            Else
                grdRules.DataSource = Nothing
                grdRules.DataBind()
            End If
        Catch ex As Exception
            msgbox(ex.Message)

        End Try
    End Sub

    Protected Sub txtDetails_TextChanged(sender As Object, e As EventArgs) Handles txtDetails.TextChanged

    End Sub
End Class
