Partial Class WebUserControl
    Inherits System.Web.UI.UserControl
    Dim cmd As New SqlCommand
    Dim adp As New SqlDataAdapter
    Dim cnstr As String = (System.Configuration.ConfigurationManager.AppSettings("connpath"))
    Dim cn As New SqlConnection(cnstr)
    Dim d As New DataSet
    Dim dmbOb As New BindCombo
    Public LoginURL As String = System.Configuration.ConfigurationManager.AppSettings("LoginURL")
    Protected Sub Menu2_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Menu2.Load
        Dim i As String = Session("Username")
        Dim cmd As New SqlCommand
        cmd.Connection = cn
        cn.Open()
        cmd.CommandText = "select permission from permissions where userid= '" & i & "' Order By permission"
        adp = New SqlDataAdapter(cmd)
        adp.Fill(d, "permissions")
        Dim j As Integer
        Dim k As Integer = 0
        'For j = 0 To Menu2.Items.Count - 1
        '    If k < d.Tables(0).Rows.Count Then
        '        if (menu
        '            If Menu2.Items(j).Value = d.Tables(0).Rows(k).Item(0).ToString Then
        '                Menu2.Items(j).Enabled = True
        '                k = k + 1
        '            Else
        '                Menu2.Items(j).Enabled = False
        '            End If
        '        Else
        '            Menu2.Items(j).Enabled = False
        '        End If


        'Next j

        For j = 0 To Menu2.Items.Count - 1
            Menu2.Items(j).Enabled = False
        Next j

        Dim row As DataRow
        For Each row In d.Tables(0).Rows
            If Not (Menu2.FindItem(row(0).ToString()) Is Nothing) Then
                Menu2.FindItem(row(0).ToString()).Enabled = True
            End If
        Next

        Menu2.Items(0).Enabled = True

        cmd.ExecuteNonQuery()
        cn.Close()

    End Sub
    'Dim i As String = Session("Username")
    'Dim cmd As New SqlCommand
    'cnstr = (System.Configuration.ConfigurationManager.AppSettings("connpath"))
    'cn = New SqlConnection(cnstr)
    'cmd.Connection = cn
    'cn.Open()
    'cmd.CommandText = "select permission from permissions where userid= '" & i & "' Order By permission"
    'adp = New SqlDataAdapter(cmd)
    'adp.Fill(d, "permissions")
    'Dim j As Integer
    'Dim k As Integer = 0
    'For j = 0 To Menu2.Items.Count - 1
    '    If k < d.Tables(0).Rows.Count Then
    '        If Menu2.Items(j).Value = d.Tables(0).Rows(k).Item(0).ToString Then
    '            Menu2.Items(j).Enabled = True
    '            k = k + 1
    '        Else
    '            Menu2.Items(j).Enabled = False
    '        End If
    '    Else
    '        Menu2.Items(j).Enabled = False
    '    End If


    'Next j
    'Menu2.Items(0).Enabled = True

    'cmd.ExecuteNonQuery()
    'cn.Close()
    Protected Sub Menu2_MenuItemClick(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.MenuEventArgs) Handles Menu2.MenuItemClick
        Dim activity As String
        activity = e.Item.Text
        If activity.Trim.Length = 0 Then
            activity = e.Item.Value
            If activity = "0" Then
                activity = "Logout"
            End If

            If (cn.State = ConnectionState.Open) Then
                cn.Close()
            End If
            cmd = New SqlCommand("insert into logindetail  values ('" & Session("Userid").ToString & "','" & Now.Date & "','" & Now.Hour & ":" & Now.Minute & ":" & Now.Second & "','" & Session("Userfullname").ToString.ToUpper & "','LOG OUT')", cn)
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()
            Response.Redirect("~/LoginSystem.aspx", False)

        End If
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim ds As New DataSet
            lblName.Text = Session("Username").ToString.ToUpper
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Class
