Imports DevExpress.Web.ASPxGridView

Partial Class Parameters_billingprofiles

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
                ' getcurrencies()

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


    Protected Sub ASPxButton7_Click(sender As Object, e As EventArgs) Handles ASPxButton7.Click
        If ASPxButton7.Text = "Save" Then
            If txtCode.Text <> "" And txtprofilename.Text <> "" Then
                cmd = New SqlCommand("select * from Para_Billingprofiles where ProfileCode='" & txtCode.Text & "'", cn)
                Dim ds As New DataSet
                adp = New SqlDataAdapter(cmd)
                adp.Fill(ds, "para_Country")
                If ds.Tables(0).Rows.Count <= 0 Then
                    cmd = New SqlCommand("insert into para_Billingprofiles (ProfileCode,ProfileName, Currency, Details) values ('" & txtCode.Text & "','" & txtprofilename.Text & "','','" + txtdesc.Text + "')", cn)
                    If cn.State = ConnectionState.Open Then
                        cn.Close()
                    End If
                    cn.Open()
                    Dim y As Integer = cmd.ExecuteNonQuery()
                    cn.Close()
                    getSecurities_Categories()
                    clearall()
                Else
                    msgbox("Profile Code Already Exists")
                    Exit Sub
                End If
            Else
                msgbox("Enter All Details")
                Exit Sub
            End If
        Else
            If txtCode.Text <> "" And txtprofilename.Text <> "" Then
                cmd = New SqlCommand("update para_Billingprofiles set ProfileCode='" & txtCode.Text & "',ProfileName='" & txtprofilename.Text & "', Details='" + txtdesc.Text + "' where id='" + Label2.Text + "'", cn)
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
            cmd = New SqlCommand("select * from para_BillingProfiles", cn)
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
        cmd = New SqlCommand("select * from Para_billingprofiles where id='" + id.ToString + "'", cn)
        Dim ds As New DataSet
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "info")
        If ds.Tables(0).Rows.Count > 0 Then
            txtCode.Text = ds.Tables(0).Rows(0).Item("ProfileCode").ToString
            txtprofilename.Text = ds.Tables(0).Rows(0).Item("ProfileName").ToString
            txtdesc.Text = ds.Tables(0).Rows(0).Item("details").ToString
            '   cmbcurrency.Value = ds.Tables(0).Rows(0).Item("Currency").ToString
            Label2.Text = id
            ASPxButton7.Text = "Update"
        End If
    End Sub
    Private Sub ASPxGridView2_RowCommand(sender As Object, e As ASPxGridViewRowCommandEventArgs) Handles ASPxGridView2.RowCommand
        Dim idd As String = e.CommandArgs.CommandArgument.ToString
        If e.CommandArgs.CommandName.ToString = "Edit" Then
            getinfortoedit(idd)
        ElseIf e.CommandArgs.CommandName.ToString = "Delete" Then
            cmd = New SqlCommand("DELETE FROM para_BillingProfiles where id='" + e.KeyValue.ToString + "' ", cn)
            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()
            getSecurities_Categories()
            msgbox("Billing Profile Removed!")
        End If
    End Sub
End Class
