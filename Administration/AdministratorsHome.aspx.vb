Imports System.Data
Imports System.Data.SqlClient
Partial Class Administration_AccountCreation
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
    Public Sub getBrokerCode()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select distinct(broker_Code) from para_broker", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "para_broker")
            If (ds.Tables(0).Rows.Count > 0) Then
                cmbBroker.DataSource = ds.Tables(0)
                cmbBroker.DataValueField = "broker_code"
                cmbBroker.DataBind()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Try
            If (txtUsername.Text = "") Then
                MsgBox("Enter a valid user id")
                txtUsername.Focus()
                Exit Sub
            End If
            If (txtSurname.Text = "") Then
                MsgBox("Enter a valid Name for the user")
                txtSurname.Focus()
                Exit Sub
            End If
            If (txtID.Text = "") Then
                MsgBox("Enter a valid id number")
                txtID.Focus()
                Exit Sub
            End If
            Dim accmode As Integer
            If (rdActive.Checked = True) Then
                accmode = 1
            End If
            If (rdLock.Checked = True) Then
                accmode = 0
            End If
            Dim ds As New DataSet
            cmd = New SqlCommand("select username from SystemUsersProfile where userName='" & txtUsername.Text & "'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "SystemUsersProfile")
            If (ds.Tables(0).Rows.Count > 0) Then
                MsgBox("Selected Username already Exists, Chose another name")
                txtUsername.Text = ""
                Exit Sub
            End If
            cmd = New SqlCommand("insert into SystemUsersProfile (Username,Surname,Forenames,DOB,idpp,EmpId,BrokerCode,Company,Department,Wposition,Tel,Cel,Email,Address,HOD,DateOfCreation) values ('" & txtUsername.Text & "','" & txtSurname.Text & "','" & txtforenames.Text & "','" & BasicDatePicker1.Text & "','" & txtID.Text & "','" & txtEmpID.Text & "','" & cmbBroker.Text & "','" & txtCompany.Text & "','" & txtDept.Text & "','" & txtJobTitle.Text & "'," & txtTel.Text & "," & txtCell.Text & ",'" & txtEmail.Text & "','" & txtAdd1.Text & "','" & txtHod.Text & "','" & Date.Now & "')", cn)
            If (cn.State = ConnectionState.Open) Then
                cn.Close()
            End If
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()

            cmd = New SqlCommand("insert into systemusers (company,companycode,companytype,username,department,password,activation,trail) values('" & cmbBroker.Text & "','" & txtCompany.Text & "','" & lblCompanyType.Text & "','" & txtUsername.Text & "','" & txtDept.Text & "','password'," & accmode & ",0)", cn)
            If (cn.State = ConnectionState.Open) Then
                cn.Close()
            End If
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()

            cmd = New SqlCommand("insert into permissions (UserName,Surname,Forenames,EmployeeCode,Department,Company) values('" & txtUsername.Text & "','" & txtSurname.Text & "','" & txtforenames.Text & "','" & txtCompany.Text & "','" & txtDept.Text & "','" & cmbBroker.Text & "')", cn)
            If (cn.State = ConnectionState.Open) Then
                cn.Close()
            End If
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()
            MsgBox("Account created")
            cleartext()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Function RandomPassword() As String

        Dim arrPossibleChars As Char() = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789".ToCharArray()

        Dim intPasswordLength As Integer = 10

        Dim stringPassword As String = Nothing

        Dim rand As System.Random = New Random

        Dim i As Integer = 0

        For i = 0 To intPasswordLength
            Dim intRandom As Integer = rand.Next(arrPossibleChars.Length)

            stringPassword = stringPassword & arrPossibleChars(intRandom).ToString()
        Next

        RandomPassword = stringPassword

    End Function
    Public Sub ValidateUsername()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select username from SystemUsersProfile where userName='" & txtUsername.Text & "'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "SystemUsersProfile")
            If (ds.Tables(0).Rows.Count > 0) Then
                MsgBox("Selected Username already Exists, Chose another name")
                txtUsername.Text = ""
                Exit Sub
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Public Sub getFulcomp()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select fnam,companytype from para_broker where broker_code='" & cmbBroker.Text & "'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "para_broker")
            If (ds.Tables(0).Rows.Count > 0) Then
                txtCompany.Text = (ds.Tables(0).Rows(0).Item("fnam").ToString)
                lblCompanyType.Text = (ds.Tables(0).Rows(0).Item("companyType").ToString)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Public Sub validation()
        Try
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Page.MaintainScrollPositionOnPostBack = True
        If (Not IsPostBack) Then
            getBrokerCode()
            getFulcomp()
        End If
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
            txtUsername.Text = ""
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Protected Sub txtEmpID_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtEmpID.TextChanged

    End Sub

    Protected Sub txtUsername_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtUsername.TextChanged
        ValidateUsername()
    End Sub

    Protected Sub cmbBroker_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbBroker.SelectedIndexChanged
        getFulcomp()
    End Sub
End Class
