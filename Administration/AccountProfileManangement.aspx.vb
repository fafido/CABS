Imports System.Data
Imports System.Data.SqlClient
Partial Class Administration_AccountPermisions
    Inherits System.Web.UI.Page
    Dim constr As String = (System.Configuration.ConfigurationManager.AppSettings("connpath"))
    Dim cn As New SqlConnection(constr)
    Dim cmd As SqlCommand
    Dim adp As SqlDataAdapter
    Dim ds As New DataSet
    Public Sub msgbox(ByVal strMessage As String)

        'finishes server processing, returns to client.
        Dim strScript As String = "<script language=JavaScript>"
        strScript += "window.alert(""" & strMessage & """);"
        strScript += "</script>"
        Dim lbl As New System.Web.UI.WebControls.Label
        lbl.Text = strScript
        Page.Controls.Add(lbl)

    End Sub
    Public Sub getUserAccount()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select distinct(username) from systemusers where companyCode='" & Session("BrokerCode") & "'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "systemUsers")
            If (ds.Tables(0).Rows.Count > 0) Then
                cmbUser.DataSource = ds.Tables(0)
                cmbUser.DataValueField = "username"
                cmbUser.DataBind()
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Try
            If (cmbUser.Text = "") Then
                msgbox("Select a valid user id")
                Exit Sub
            End If
            If (txtSurname.Text = "") Then
                msgbox("Enter a valid Name for the user")
                txtSurname.Focus()
                Exit Sub
            End If
            If (txtID.Text = "") Then
                msgbox("Enter a valid id number")
                txtID.Focus()
                Exit Sub
            End If
            Dim ds As New DataSet
            cmd = New SqlCommand("select username from SystemUsersProfile where userName='" & cmbUser.Text & "'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "SystemUsersProfile")
            If (ds.Tables(0).Rows.Count > 0) Then
                msgbox("Selected Username already Exists, Chose another name")
                Exit Sub
            End If
            'cmd = New SqlCommand("insert into SystemUsersProfile (Username,Surname,Forenames,DOB,idpp,EmpId,BrokerCode,Company,Department,Wposition,Tel,Cel,Email,Address,HOD,DateOfCreation) values ('" & txtUsername.Text & "','" & txtSurname.Text & "','" & txtforenames.Text & "','" & BasicDatePicker1.Text & "','" & txtID.Text & "','" & txtEmpID.Text & "','" & cmbBroker.Text & "','" & txtCompany.Text & "','" & txtDept.Text & "','" & txtJobTitle.Text & "'," & txtTel.Text & "," & txtCell.Text & ",'" & txtEmail.Text & "','" & txtAdd1.Text & "','" & txtHod.Text & "','" & Date.Now & "')", cn)
            If (cn.State = ConnectionState.Open) Then
                cn.Close()
            End If
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()
            msgbox("Account created")
            cleartext()
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub validation()
        Try
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Page.MaintainScrollPositionOnPostBack = True
        If (Not IsPostBack) Then
            getUserAccount()
        End If
    End Sub
    Public Sub getAccountDetails()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select * from systemUsersProfile where username='" & cmbUser.Text & "'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "systemUsersProfile")
            If (ds.Tables(0).Rows.Count > 0) Then

            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub cleartext()
        Try
            txtSurname.Text = ""
            txtforenames.Text = ""
            txtID.Text = ""
            txtAdd1.Text = ""
            txtTel.Text = ""
            txtCell.Text = ""
            txtEmail.Text = ""
            txtFax.Text = ""
            txtHod.Text = ""
            txtCompany.Text = ""
            txtDept.Text = ""
            txtJobTitle.Text = ""
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub txtEmpID_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtEmpID.TextChanged

    End Sub

End Class
