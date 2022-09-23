Imports System.Data
Imports System.Data.SqlClient
Imports DevExpress.Web.ASPxGridView

Partial Class BrokerMode_SystemCalender
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
            ASPxCalendar1.MinDate = Date.UtcNow
            GetSecurities()

            If (Session("Username") = Nothing) Then
                Response.Redirect("~\loginsystem.aspx")
                Exit Sub
            End If
            'Label4.Text = "Logged on as " & Session("UserName").ToString & " of " & Session("UserCompany")

            UpdatePastEvents()
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
    Public Sub insertholiday()
        Try
            cmd = New SqlCommand("insert into para_holiday (holiday_date, comment) values ('" + ASPxCalendar1.SelectedDate.ToString + "','" + txtHolidayComments.Text + "')", cn)
            If (cn.State = ConnectionState.Open) Then
                cn.Close()
            End If
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()
            GetSecurities()
            txtHolidayComments.Text = ""
            msgbox("Holiday Added")
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub updateholiday()
        Try
            cmd = New SqlCommand("update para_holiday set holiday_date='" + ASPxCalendar1.SelectedDate.ToString + "',comment='" + txtHolidayComments.Text + "' where id='" + lblid.Text + "'", cn)
            If (cn.State = ConnectionState.Open) Then
                cn.Close()
            End If
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()
            GetSecurities()
            txtHolidayComments.Text = ""
            msgbox("Holiday Updated")
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub GetSecurities()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select id, holiday_date as [Date], Comment  from para_holiday", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "security_type")
            If (ds.Tables(0).Rows.Count > 0) Then
                ASPxGridView2.DataSource = ds
                ASPxGridView2.DataBind()
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub ASPxButton1_Click(sender As Object, e As EventArgs) Handles ASPxButton1.Click
        If txtHolidayComments.Text <> "" Then
            Try
                If ASPxButton1.Text = "Save" Then
                    insertholiday()
                Else
                    updateholiday()
                End If

            Catch ex As Exception

            End Try
        Else
            msgbox("Please enter the Holiday Comment!")
        End If

    End Sub

    Public Sub getinfortoedit(id As String)
        cmd = New SqlCommand("select * from para_holiday where id='" + id.ToString + "'", cn)
        Dim ds As New DataSet
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "info")
        If ds.Tables(0).Rows.Count > 0 Then
            ASPxCalendar1.SelectedDate = ds.Tables(0).Rows(0).Item("holiday_date").ToString
            txtHolidayComments.Text = ds.Tables(0).Rows(0).Item("comment").ToString
            lblid.Text = id
            ASPxButton1.Text = "Update"
        End If
    End Sub

    Private Sub ASPxGridView2_RowCommand(sender As Object, e As ASPxGridViewRowCommandEventArgs) Handles ASPxGridView2.RowCommand
        Dim id As String = e.KeyValue.ToString
        If e.CommandArgs.CommandName.ToString = "Edit" Then
            getinfortoedit(id)
        ElseIf e.CommandArgs.CommandName.ToString = "Delete" Then
            cmd = New SqlCommand("DELETE FROM para_holiday where id='" + e.KeyValue.ToString + "' ", cn)
            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If
            cn.Open()
            cmd.ExecuteNonQuery()
            GetSecurities()

            msgbox("Holiday Deleted!")
        End If
    End Sub
End Class
