Partial Class Parameters_MakerChecker
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
        If Not IsPostBack = True Then
            getaccmaintanance()
            getbatches()
            getotc()
            getpledge()
            getlending()
        End If
      


    End Sub
    Public Sub getaccmaintanance()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select top 1 on_off from para_maker_checker where control='Account Maintanance' order by id desc", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "para_country")

            If ds.Tables(0).Rows(0).Item("on_off") = "On" Then
                rdChkOn.Checked = True
            Else
                rdChkOff.Checked = True
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub getbatches()
        Try
            Dim ds1 As New DataSet
            cmd = New SqlCommand("select top 1 on_off from para_maker_checker where control='Batch Transactions' order by id desc", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds1, "para_country1")

            If ds1.Tables("para_country1").Rows(0).Item("on_off") = "On" Then
                rdbatchon.Checked = True

            Else
                rdbatchoff.Checked = True
            End If

        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub getotc()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select top 1 on_off from para_maker_checker where control='OTC Transactions' order by id desc", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "para_country")

            If ds.Tables(0).Rows(0).Item("on_off") = "On" Then
                rdotcon.Checked = True
            Else
                rdotcoff.Checked = True
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub getpledge()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select top 1 on_off from para_maker_checker where control='Pledge Transactions' order by id desc", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "para_country")

            If ds.Tables(0).Rows(0).Item("on_off") = "On" Then
                rdpledgeon.Checked = True
            Else
                rdpledgeoff.Checked = True
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub getlending()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select top 1 on_off from para_maker_checker where control='Lending and Borrowing' order by id desc", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "para_country")

            If ds.Tables(0).Rows(0).Item("on_off") = "On" Then
                rdlendon.Checked = True
            Else
                rdlendoff.Checked = True
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub ASPxButton3_Click(sender As Object, e As EventArgs) Handles ASPxButton3.Click
        Dim on_off As String
        If rdChkOn.Checked = True Then
            on_off = "On"
        Else
            on_off = "Off"
        End If

        cmd = New SqlCommand("insert into para_maker_checker  values('Account Maintanance','" + on_off + "')", cn)
        If (cn.State = ConnectionState.Open) Then
            cn.Close()
        End If
        cn.Open()
        cmd.ExecuteNonQuery()
        cn.Close()
        Response.Redirect(Request.RawUrl)
    End Sub

    Protected Sub ASPxButton1_Click(sender As Object, e As EventArgs) Handles ASPxButton1.Click
        Dim on_off As String
        If rdbatchon.Checked = True Then
            on_off = "On"
        Else
            on_off = "Off"
        End If

        cmd = New SqlCommand("insert into para_maker_checker  values('Batch Transactions','" + on_off + "')", cn)
        If (cn.State = ConnectionState.Open) Then
            cn.Close()
        End If
        cn.Open()
        cmd.ExecuteNonQuery()
        cn.Close()
        Response.Redirect(Request.RawUrl)
    End Sub

    Protected Sub ASPxButton2_Click(sender As Object, e As EventArgs) Handles ASPxButton2.Click
        Dim on_off As String
        If rdotcon.Checked = True Then
            on_off = "On"
        Else
            on_off = "Off"
        End If

        cmd = New SqlCommand("insert into para_maker_checker  values('OTC Transactions','" + on_off + "')", cn)
        If (cn.State = ConnectionState.Open) Then
            cn.Close()
        End If
        cn.Open()
        cmd.ExecuteNonQuery()
        cn.Close()
        Response.Redirect(Request.RawUrl)
    End Sub

    Protected Sub ASPxButton4_Click(sender As Object, e As EventArgs) Handles ASPxButton4.Click
        Dim on_off As String
        If rdpledgeon.Checked = True Then
            on_off = "On"
        Else
            on_off = "Off"
        End If

        cmd = New SqlCommand("insert into para_maker_checker  values('Pledge Transactions','" + on_off + "')", cn)
        If (cn.State = ConnectionState.Open) Then
            cn.Close()
        End If
        cn.Open()
        cmd.ExecuteNonQuery()
        cn.Close()
        Response.Redirect(Request.RawUrl)
    End Sub

    Protected Sub ASPxButton5_Click(sender As Object, e As EventArgs) Handles ASPxButton5.Click
        Dim on_off As String
        If rdlendon.Checked = True Then
            on_off = "On"
        Else
            on_off = "Off"
        End If

        cmd = New SqlCommand("insert into para_maker_checker  values('Lending and Borrowing','" + on_off + "')", cn)
        If (cn.State = ConnectionState.Open) Then
            cn.Close()
        End If
        cn.Open()
        cmd.ExecuteNonQuery()
        cn.Close()
        Response.Redirect(Request.RawUrl)
    End Sub
End Class
