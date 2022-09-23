Imports System.Data.SqlClient
Imports System.Data
Partial Class _SignSystem
    Inherits System.Web.UI.Page
    Dim constr As String = (System.Configuration.ConfigurationManager.AppSettings("connpath"))
    Dim cn As New SqlConnection(constr)
    Dim cmd As SqlCommand
    Dim ds As New DataSet
    Dim adp As SqlDataAdapter
    Dim validChars As String = "1"
    Dim strClientIP As String
    Dim v2 As String = "2"
    Dim v3 As String = "3"
    Dim v4 As String = "4"
    Dim v5 As String = "5"
    Dim v6 As String = "6"
    Dim v7 As String = "7"
    Dim v8 As String = "8"
    Dim v9 As String = "9"
    Dim v10 As String = "0"
    Protected Sub btnSignIn_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSignIn.Click
        Try
            Dim dstime As New DataSet
            cmd = New SqlCommand("select max(UpdateID) as UpdateID, SystemUptime, SystemDownTime, LoginScope, ActivationState from SystemTimeAccess where ActivationState = 1 group by UpdateID , SystemUptime, SystemDownTime, LoginScope, ActivationState order by UpdateID desc", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(dstime, "SystemTimeAccess")
            If (dstime.Tables(0).Rows(0).Item("LoginScope").ToString = "ALL") Then
                'If ((dstime.Tables(0).Rows(0).Item("SystemUptime").ToString < TimeOfDay) And (dstime.Tables(0).Rows(0).Item("SystemDowntime").ToString > TimeOfDay)) Then
                If (TimeOfDay <= dstime.Tables(0).Rows(0).Item("SystemUptime").ToString Or TimeOfDay >= dstime.Tables(0).Rows(0).Item("SystemDownTime").ToString) Then
                    lblEvent.Text = "Log in session not yet started"
                    Exit Sub
                Else
                    lblEvent.Text = ""
                End If
            End If
            PasswordValidation()
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub loginAudit()
        Try
            strClientIP = Request.UserHostAddress()
            cmd = New SqlCommand("insert into LoginAudit (Username,company,LoginDate,LoginStatus,AddressLocation,AccessMode) values ('" & Session("Username") & "','" & Session("BrokerCode") & "','" & Date.Now & "',1,'" & strClientIP & "','" & Label5.Text & "')", cn)
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
        Try
            If (Not IsPostBack) Then
                HidePasswordReset()
                txtPassword.Attributes.Clear()

                cmd = New SqlCommand("select distinct(company) from CompanyAccounts where activation=1", cn)
                adp = New SqlDataAdapter(cmd)
                adp.Fill(ds, "CompanyAccounts")
                If (ds.Tables(0).Rows.Count > 0) Then
                    cmbOrg.DataSource = ds.Tables(0)
                    cmbOrg.DataValueField = "company"
                    cmbOrg.DataBind()
                    txtUserId.Enabled = True
                    txtPassword.Enabled = True
                    Session("BrokerCode") = ""
                    Session("UserCompany") = ""
                    Session("Username") = ""
                    'Label4.Text = PickTime1.GetTime
                    Label5.Text = Request.UserAgent
                Else
                    msgbox("No current active company")
                    txtUserId.Enabled = False
                    txtPassword.Enabled = False
                End If
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub clearlogins()
        Try
            Session("Username") = ""
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub PasswordValidation()
        Try

            Dim trails, changes As Integer
            strClientIP = Request.UserHostAddress()
            'cmd = New SqlCommand("select company,companyCode,CompanyType,userName,password,Trail,Activation,PasswordExpireyDate from SystemUsers where company='" & cmbOrg.Text & "' and userName='" & txtUserId.Text & "'", cn)
            cmd = New SqlCommand("select company,companyCode,CompanyType,userName,password,Trail,Activation,PasswordExpireyDate from SystemUsers where userName='" & txtUserId.Text & "'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "SystemUsers")
            If (ds.Tables(0).Rows.Count > 0) Then
                If ((ds.Tables(0).Rows(0).Item("password").ToString = "password")) Then
                    msgbox("For your first time log in you are required to change your password")

                End If
                If (ds.Tables(0).Rows(0).Item("Activation").ToString = "0") Then
                    msgbox("Your Account has been blocked, Please contact the system administrator for re-activation")
                    Exit Sub
                End If
                'If (isnot txtPassword.Equals(ds.Tables(0).Rows(0).Item("password").ToString())) Then
                'msgbox("test1")
                If ((txtPassword.Text) <> (ds.Tables(0).Rows(0).Item("password").ToString())) Then
                    msgbox("password invalid")
                    trails = ds.Tables(0).Rows(0).Item("trail").ToString + 1
                    changes = (3 - trails)
                    cmd = New SqlCommand("Update systemusers set Trail=" & trails & " where company='" & cmbOrg.Text & "' and userName='" & txtUserId.Text & "' and activation=1", cn)
                    If (cn.State = ConnectionState.Open) Then
                        cn.Close()
                    End If
                    cn.Open()
                    cmd.ExecuteNonQuery()
                    cn.Close()
                    If (CInt(ds.Tables(0).Rows(0).Item("trail").ToString) >= 3) Then
                        cmd = New SqlCommand("Update systemusers set Activation=0 where company='" & cmbOrg.Text & "' and userName='" & txtUserId.Text & "'", cn)
                        If (cn.State = ConnectionState.Open) Then
                            cn.Close()
                        End If
                        cn.Open()
                        cmd.ExecuteNonQuery()
                        cn.Close()
                        lblChances.Text = "Your account has been blocked, Please contact your administrator for account re-activation"
                        Exit Sub
                    End If
                    lblChances.Text = CStr(" " & changes & " attempt(s) remaining before account locks !")
                    txtPassword.Text = ""
                    Exit Sub
                Else
                    'msgbox("test2")

                    If (CDate(ds.Tables(0).Rows(0).Item("PasswordExpireyDate").ToString) < CDate(Date.Now)) Then
                        msgbox("Your password has expired, please change your password")
                        Exit Sub
                    End If

                    Session("BrokerCode") = ds.Tables(0).Rows(0).Item("companyCode").ToString
                    Session("UserCompany") = ds.Tables(0).Rows(0).Item("company").ToString
                    Session("Username") = ds.Tables(0).Rows(0).Item("UserName").ToString
                    If (cn.State = ConnectionState.Open) Then
                        cn.Close()
                    End If


                    loginAudit()

                    cmd = New SqlCommand("insert into UserActivityLog (UserName,Activity,TimeOfActivity,DateDone,CompanyCode,AddressLocation) values ('" & Session("Username") & "','Authorized new account creation','" & Date.Now & "','" & Now.Date & "','" & Session("BrokerCode") & "','" & strClientIP & "')", cn)
                    If (cn.State = ConnectionState.Open) Then
                        cn.Close()
                    End If
                    cn.Open()
                    cmd.ExecuteNonQuery()
                    cn.Close()

                    'msgbox("test3")
                    cmd = New SqlCommand("update systemUsers set trail=0 where company='" & cmbOrg.Text & "' and userName='" & txtUserId.Text & "'", cn)
                    If (cn.State = ConnectionState.Open) Then
                        cn.Close()
                    End If
                    cn.Open()
                    cmd.ExecuteNonQuery()
                    cn.Close()
                    'msgbox("test4")
                    If (ds.Tables(0).Rows(0).Item("CompanyType").ToString = "BROKER") Then
                        Response.Redirect("~\BrokerMode\BrokerHme.aspx")
                    End If
                    If (ds.Tables(0).Rows(0).Item("CompanyType").ToString = "TSEC") Then
                        Response.Redirect("~\TSecMode\TSecHme.aspx")
                    End If
                    If (ds.Tables(0).Rows(0).Item("CompanyType").ToString = "BrokerAdmin") Then
                        Response.Redirect("~\Administration\BrokerAdminHme.aspx")
                    End If
                    If (ds.Tables(0).Rows(0).Item("CompanyType").ToString = "CDS") Then
                        Response.Redirect("~\CDSMode\CDSHome.aspx")
                    End If
                    If (ds.Tables(0).Rows(0).Item("CompanyType").ToString = "CUSTODIAN") Then
                        Response.Redirect("~\Custodian\BrokerHme.aspx")
                    End If

                End If
            Else
                msgbox("Wrong username or password")
                txtUserId.Text = ""
                txtPassword.Text = ""
                Exit Sub
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Public Sub ValidateCPass()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select * from userAccounts where user_id='" & txtUserId.Text & "'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "UserAccounts")
            If (ds.Tables(0).Rows.Count > 0) Then
                If (ds.Tables(0).Rows(0).Item("Password").ToString = Trim(txtPassword.Text)) Then
                    Response.Redirect("~\Home.apx")

                End If
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub HidePasswordReset()
        Try
            Label1.Visible = False
            txtChangeUsername.Visible = False
            Label6.Visible = False
            txtoldPass.Visible = False
            Label7.Visible = False
            txtNewPass.Visible = False
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

End Class
