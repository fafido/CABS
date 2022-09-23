Imports DevExpress.Web.ASPxGridView

Partial Class Parameters_BillingGroups


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
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Page.MaintainScrollPositionOnPostBack = True
            If (Not IsPostBack) Then
                getSecurities_Categories()
                getcurrencies()

            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Protected Sub clearall()
        txtCode.Text = ""
        txtprofilename.Text = ""

        getSecurities_Categories()
    End Sub
    Public Sub getcurrencies()
        Dim dsport As New DataSet
        cmd = New SqlCommand("select * from para_currencies", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(dsport, "trans")
        If (dsport.Tables(0).Rows.Count > 0) Then
            cmbcurrency.DataSource = dsport
            cmbcurrency.TextField = "currencycode"
            cmbcurrency.ValueField = "currencycode"
            cmbcurrency.DataBind()
        End If
    End Sub

    Protected Sub ASPxButton7_Click(sender As Object, e As EventArgs) Handles ASPxButton7.Click
        If ASPxButton7.Text = "Save" Then
            If txtCode.Text <> "" And txtprofilename.Text <> "" Then
                cmd = New SqlCommand("select * from Para_BillingGroups where GroupCode='" & txtCode.Text & "'", cn)
                Dim ds As New DataSet
                adp = New SqlDataAdapter(cmd)
                adp.Fill(ds, "para_Country")
                If ds.Tables(0).Rows.Count <= 0 Then
                    cmd = New SqlCommand("insert into Para_BillingGroups (GroupCode,GroupName, Currency, Details) values ('" & txtCode.Text & "','" & txtprofilename.Text & "','" + cmbcurrency.SelectedItem.Text + "','" + txtdesc.Text + "')", cn)
                    If cn.State = ConnectionState.Open Then
                        cn.Close()
                    End If
                    cn.Open()
                    Dim y As Integer = cmd.ExecuteNonQuery()
                    cn.Close()
                    getSecurities_Categories()
                    clearall()
                Else
                    msgbox("Group Code Already Exists")
                    Exit Sub
                End If
            Else
                msgbox("Enter All Details")
                Exit Sub
            End If
        Else
            If txtCode.Text <> "" And txtprofilename.Text <> "" Then
                cmd = New SqlCommand("update Para_BillingGroups set GroupCode='" & txtCode.Text & "',GroupName='" & txtprofilename.Text & "', Details='" + txtdesc.Text + "', Currency='" + cmbcurrency.SelectedItem.Text + "' where id='" + Label2.Text + "'", cn)
                If cn.State = ConnectionState.Open Then
                    cn.Close()
                End If
                cn.Open()
                Dim y As Integer = cmd.ExecuteNonQuery()
                cn.Close()
                ASPxButton7.Text = "Save"
                clearall()
                getSecurities_Categories()
            Else
                msgbox("Enter All Details")
                Exit Sub
            End If
        End If
    End Sub
    Protected Sub getSecurities_Categories()
        Try
            cmd = New SqlCommand("select * from Para_BillingGroups", cn)
            Dim ds As New DataSet
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "para_Country")
            If ds.Tables(0).Rows.Count > 0 Then
                ASPxGridView2.DataSource = ds.Tables(0)
            Else
                ASPxGridView2.DataSource = Nothing
            End If
            ASPxGridView2.DataBind()
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub getinfortoedit(id As String)
        cmd = New SqlCommand("select * from Para_BillingGroups where id='" + id.ToString + "'", cn)
        Dim ds As New DataSet
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "info")
        If ds.Tables(0).Rows.Count > 0 Then
            txtCode.Text = ds.Tables(0).Rows(0).Item("GroupCode").ToString
            txtprofilename.Text = ds.Tables(0).Rows(0).Item("GroupName").ToString
            txtdesc.Text = ds.Tables(0).Rows(0).Item("details").ToString
            cmbcurrency.Value = ds.Tables(0).Rows(0).Item("Currency").ToString
            Label2.Text = id
            ASPxButton7.Text = "Update"
        End If
    End Sub
    Private Sub ASPxGridView2_RowCommand(sender As Object, e As ASPxGridViewRowCommandEventArgs) Handles ASPxGridView2.RowCommand
        Dim idd As String = e.CommandArgs.CommandArgument.ToString
        If e.CommandArgs.CommandName.ToString = "Edit" Then
            getinfortoedit(idd)
        ElseIf e.CommandArgs.CommandName.ToString = "Delete" Then
            cmd = New SqlCommand("DELETE FROM Para_BillingGroups where id='" + e.KeyValue.ToString + "' ", cn)
            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()
            getSecurities_Categories()
            msgbox("Billing Group Removed!")
        End If
    End Sub
End Class
