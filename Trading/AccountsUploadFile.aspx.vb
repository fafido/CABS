Partial Class Trading_AccountsUploadFile
    Inherits System.Web.UI.Page
    Dim constr As String = (System.Configuration.ConfigurationManager.AppSettings("connpath"))
    Dim cn As New SqlConnection(constr)
    Dim cmd As SqlCommand
    Dim adp As SqlDataAdapter
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Page.MaintainScrollPositionOnPostBack = True
            If (Not IsPostBack) Then
                BasicDatePicker1.SelectedDate = Today
                cmd = New SqlCommand("insert into UserActivityLog (UserName,Activity,TimeOfActivity,DateDone,CompanyCode) values ('" & Session("Username") & "','Accessed Accounts Electrinic Upload Form','" & Date.Now & "','" & Now.Date & "','" & Session("BrokerCode") & "')", cn)
                If (cn.State = ConnectionState.Open) Then
                    cn.Close()
                End If
                cn.Open()
                cmd.ExecuteNonQuery()
                cn.Close()
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
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

    Protected Sub btnSelect_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSelect.Click
        Try
            cmd = New SqlCommand("insert into tbl_AccountsUploadID ('" & Session("BrokerCode") & "','" & BasicDatePicker1.Text & "','" & Session("Username") & "')", cn)
            If (cn.State = ConnectionState.Open) Then
                cn.Close()
            End If
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()

            Dim ds As New DataSet
            cmd = New SqlCommand("select distinct max (UploadID) as UploadID from tbl_AccountsUploadID order by UploadID desc", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "tbl_AccountsUploadID")

            'cmd = New SqlCommand("insert into ")
            cmd = New SqlCommand("insert into UserActivityLog (UserName,Activity,TimeOfActivity,DateDone,CompanyCode) values ('" & Session("Username") & "','Uploaded Accounts Electronic File','" & Date.Now & "','" & Now.Date & "','" & Session("BrokerCode") & "')", cn)
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
End Class
