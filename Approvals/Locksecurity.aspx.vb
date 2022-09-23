Partial Class Locksecurity
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
            Page.MaintainScrollPositionOnPostBack = True
            If (Not IsPostBack) Then
                checkSessionState()
                'getclasses_param()
                getpending()
            End If
            If Session("finish") = "yes" Then
                Session("finish") = ""
                msgbox("Successful")
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub ASPxTextBox12_TextChanged(sender As Object, e As EventArgs) Handles txttransferorname.TextChanged

    End Sub



    Public Sub getpending()

        Dim ds As New DataSet
        cmd = New SqlCommand("  select id,(select top 1 isnull(surname,'')+' '+isnull(forenames,'') from accounts_clients where cds_Number=locked_securities.cds_Number) as Name from locked_securities where [status]='0'", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "Accounts_Audit2")
        If (ds.Tables(0).Rows.Count > 0) Then
            cmbpending.DataSource = ds
            cmbpending.TextField = "Name"
            cmbpending.ValueField = "id"
            cmbpending.DataBind()

        End If
    End Sub


    Public Sub loadnames()
        Dim ds As New DataSet
        cmd = New SqlCommand("select *,(select top 1 isnull(surname,'')+' '+isnull(forenames,'') from accounts_clients where cds_Number=locked_securities.cds_Number) as Name from locked_securities where id='" + cmbpending.SelectedItem.Value.ToString + "'", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "Accounts_Audit2")
        If (ds.Tables(0).Rows.Count > 0) Then
            txttransferorid.Text = ds.Tables(0).Rows(0).Item("cds_Number")
            txttransferorname.Text = ds.Tables(0).Rows(0).Item("Name")
            txttype.Text = ds.Tables(0).Rows(0).Item("Type_")
            txttransferorid0.Text = ds.Tables(0).Rows(0).Item("company_locked")
            '       getclasses()


        End If
    End Sub

 
    Public Sub savenewclass()
        Dim ds1 As New DataSet
        cmd = New SqlCommand("select cds_number from account_transfer where cds_number='" + txttransferorid.Text + "'", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds1, "Accounts_Audit3")
        If (ds1.Tables(0).Rows.Count > 0) Then
            cmd = New SqlCommand("Update account_transfer set to_broker=(select company_code  from client_companies where company_name='" + +"') where cds_number='" + txttransferorid.Text + "'", cn)
            If (cn.State = ConnectionState.Open) Then
                cn.Close()
            End If
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()

            Session("finish") = "yes"
            Response.Redirect(Request.RawUrl)
        Else
            '   cmd = New SqlCommand("insert into account_transfer values ('" + txtclientid.Text + "','" + Session("brokercode") + "',(select company_code  from client_companies where company_name='" + +"'), '" + txtComments.Text + "',GEtdate(),0)", cn)
            If (cn.State = ConnectionState.Open) Then
                cn.Close()
            End If
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()

            Session("finish") = "yes"
            Response.Redirect(Request.RawUrl)
        End If
    End Sub

   



    Protected Sub cmbpending_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbpending.SelectedIndexChanged
        loadnames()
        '        getnames()

    End Sub

    Protected Sub ASPxButton5_Click(sender As Object, e As EventArgs) Handles ASPxButton5.Click
        If txttype.Text = "Lock" Then
            cmd = New SqlCommand("update locked_securities set [status]='1' where id='" + cmbpending.SelectedItem.Value.ToString + "'", cn)
            If (cn.State = ConnectionState.Open) Then
                cn.Close()
            End If
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()
        Else
            cmd = New SqlCommand("delete from locked_securities where company_locked='" + txttransferorid0.Text + "' and cds_Number='" + txttransferorid.Text + "'", cn)
            If (cn.State = ConnectionState.Open) Then
                cn.Close()
            End If
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()
        End If
       

        Session("finish") = "yes"
        Response.Redirect(Request.RawUrl)
    End Sub
End Class