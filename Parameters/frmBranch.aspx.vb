
Imports System.Data
Imports System.Data.SqlClient
Imports DevExpress.Web.ASPxGridView

Partial Class Parameters_frmBranch
    Inherits System.Web.UI.Page
    Dim constr As String = (System.Configuration.ConfigurationManager.AppSettings("connpath"))
    Dim cn As New SqlConnection(constr)
    Dim cmd As SqlCommand
    Dim adp As SqlDataAdapter
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
                GetBanks()
                GetBanks2()

            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try

    End Sub


    Public Sub GetBanks()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("Select Bank,Bank_name,Bank_code from para_bank", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "para_bank")

            cmbBank.DataSource = ds.Tables("para_bank")
            cmbBank.DataValueField = "Bank"
            cmbBank.DataTextField = "Bank_Name"
            cmbBank.DataBind()
            'GridView1.DataSource = ds.Tables("para_bank")
            'GridView1.DataBind()
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Public Sub GetBanks2()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select id,  branch as [Branch Code], Branch_Name, branch_code as [Status] from para_branch  where bank='" + cmbBank.SelectedValue.ToString + "'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "para_bank")
            If ds.Tables("para_bank").Rows.Count > 0 Then

                ASPxGridView2.DataSource = ds.Tables("para_bank")
                ASPxGridView2.DataBind()
            End If


        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub btnSave_click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Try
            If btnSave.Text = "Save" Then

                If txtbcode.Text = "" Then
                    msgbox("Enter Branch Name")
                    txtbcode.Focus()
                    Exit Sub
                End If

                If txtName.Text = "" Then
                    msgbox("Enter Branch Name")
                    txtName.Focus()
                    Exit Sub
                End If
                cmd = New SqlCommand("insert into para_Branch (Bank,Branch,Branch_name,Branch_Code) values('" & cmbBank.SelectedValue.ToString & "','" & txtbcode.Text & "','" & txtName.Text & "','" & txtCode.Text & "')", cn)
                If (cn.State = ConnectionState.Open) Then
                    cn.Close()
                End If
                cn.Open()
                cmd.ExecuteNonQuery()
                cn.Close()
                txtName.Text = ""
                txtbcode.Text = ""
                ' GetBanks()
                GetBanks2()
                msgbox("Branch Successfully Updated")
            Else

                If txtbcode.Text = "" Then
                    msgbox("Enter Branch Name")
                    txtbcode.Focus()
                    Exit Sub
                End If

                If txtName.Text = "" Then
                    msgbox("Enter Branch Name")
                    txtName.Focus()
                    Exit Sub
                End If
                cmd = New SqlCommand("update para_Branch set branch='" + txtbcode.Text + "', branch_name='" + txtName.Text + "' where id='" + lblid.text + "'", cn)
                If (cn.State = ConnectionState.Open) Then
                    cn.Close()
                End If
                cn.Open()
                cmd.ExecuteNonQuery()
                cn.Close()
                txtName.Text = ""
                txtbcode.Text = ""
                '   GetBanks()
                GetBanks2()
                msgbox("Branch Successfully Updated")
            End If

        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub cmbBank_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbBank.SelectedIndexChanged


        GetBanks2()

    End Sub
    Public Sub getinfortoedit(id As String)
        cmd = New SqlCommand("select * from para_branch where id='" + id.ToString + "'", cn)
        Dim ds As New DataSet
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "info")
        If ds.Tables(0).Rows.Count > 0 Then
            txtbcode.Text = ds.Tables(0).Rows(0).Item("branch").ToString
            txtName.Text = ds.Tables(0).Rows(0).Item("branch_name").ToString
            lblid.Text = id
            btnSave.Text = "Update"
        End If
    End Sub

    Private Sub ASPxGridView2_RowCommand(sender As Object, e As ASPxGridViewRowCommandEventArgs) Handles ASPxGridView2.RowCommand
        Dim id As String = e.KeyValue.ToString
        If e.CommandArgs.CommandName.ToString = "Edit" Then
            getinfortoedit(id)
        ElseIf e.CommandArgs.CommandName.ToString = "Delete" Then
            cmd = New SqlCommand("DELETE FROM para_branch where id='" + e.KeyValue.ToString + "' ", cn)
            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If
            cn.Open()
            cmd.ExecuteNonQuery()
            GetBanks2()

            msgbox("Branch Deleted!")
        End If
    End Sub
End Class
