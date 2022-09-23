Imports System.Data.SqlClient
Imports System.Data
Imports System.Net.Sockets
Imports System.Net
Imports System.IO
Imports System.Text.RegularExpressions
Imports System.Security.Cryptography
Imports System
Imports System.Security.Principal
Imports System.DirectoryServices.AccountManagement
Imports System.DirectoryServices

Partial Class _LoginSystem
    Inherits System.Web.UI.Page
    Dim constr As String = (System.Configuration.ConfigurationManager.AppSettings("connpath"))
    Dim cn As New SqlConnection(constr)
    Dim cmd As SqlCommand
    Dim ds As New DataSet
    Dim adp As SqlDataAdapter

    Dim validChars As String = "1"
    Dim strClientIP As String
    Dim msocClient As New Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)
    Dim szIPSelected As String = "127.0.0.1"
    Dim szPort As String = "4510"
    Dim alPort As Int32 = System.Convert.ToInt16(szPort, 10)

    Dim remoteIPAddress As System.Net.IPAddress = System.Net.IPAddress.Parse(szIPSelected)
    Dim remoteEndPoint As New System.Net.IPEndPoint(remoteIPAddress, alPort)
    Dim v2 As String = "2"
    Dim v3 As String = "3"
    Dim v4 As String = "4"
    Dim v5 As String = "5"
    Dim v6 As String = "6"
    Dim v7 As String = "7"
    Dim v8 As String = "8"
    Dim v9 As String = "9"
    Dim v10 As String = "0"
    Private key() As Byte = {}
    Private IV() As Byte = {&H12, &H34, &H56, &H78, &H90, &HAB, &HCD, &HEF}

    Public Function Decrypt(ByVal stringToDecrypt As String,
        ByVal sEncryptionKey As String) As String
        Dim inputByteArray(stringToDecrypt.Length) As Byte
        Try
            key = System.Text.Encoding.UTF8.GetBytes(Left(sEncryptionKey, 8))
            Dim des As New DESCryptoServiceProvider()
            inputByteArray = Convert.FromBase64String(stringToDecrypt)
            Dim ms As New MemoryStream()
            Dim cs As New CryptoStream(ms, des.CreateDecryptor(key, IV),
                CryptoStreamMode.Write)
            cs.Write(inputByteArray, 0, inputByteArray.Length)
            cs.FlushFinalBlock()
            Dim encoding As System.Text.Encoding = System.Text.Encoding.UTF8
            Return encoding.GetString(ms.ToArray())
        Catch e As Exception
            Return e.Message
        End Try
    End Function

    Public Function Encrypt(ByVal stringToEncrypt As String,
        ByVal SEncryptionKey As String) As String
        Try
            key = System.Text.Encoding.UTF8.GetBytes(Left(SEncryptionKey, 8))
            Dim des As New DESCryptoServiceProvider()
            Dim inputByteArray() As Byte = Encoding.UTF8.GetBytes(
                stringToEncrypt)
            Dim ms As New MemoryStream()
            Dim cs As New CryptoStream(ms, des.CreateEncryptor(key, IV),
                CryptoStreamMode.Write)
            cs.Write(inputByteArray, 0, inputByteArray.Length)
            cs.FlushFinalBlock()
            Return Convert.ToBase64String(ms.ToArray())
        Catch e As Exception
            Return e.Message
        End Try
    End Function
    Protected Sub btnSignIn_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSignIn.Click
        'Try
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
        'Catch ex As Exception
        '    msgbox(ex.Message)
        'End Try
    End Sub


    Public Function GetData(ByVal cmd As SqlCommand) As DataTable
        Dim dt As New DataTable
        Dim strConnString As String = (System.Configuration.ConfigurationManager.AppSettings("connpath"))
        Dim con As New SqlConnection(strConnString)
        Dim sda As New SqlDataAdapter
        cmd.CommandType = CommandType.Text
        cmd.Connection = con
        Try
            con.Open()
            sda.SelectCommand = cmd
            sda.Fill(dt)
            Return dt
        Catch ex As Exception
            Response.Write(ex.Message)
            Return Nothing
        Finally
            con.Close()
            sda.Dispose()
            con.Dispose()
        End Try
    End Function

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
    Public Sub checkifusernameiscorre()
        Try
            strClientIP = Request.UserHostAddress()
            cmd = New SqlCommand("select * from user_management where username=@loggedinuser", cn)
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

    Function GetUserName() As String
        Dim originalUsername As String = System.Web.HttpContext.Current.User.Identity().Name
        Try
            Return originalUsername.Split("\")(1)
        Catch ex As Exception
            Return originalUsername
        End Try
    End Function
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Page.MaintainScrollPositionOnPostBack = True

        '   Try
        If (Not IsPostBack) Then
            HidePasswordReset()
            'txtPassword.Attributes.Clear()
            'Console.WriteLine("UserName: {0}", Environment.UserName)
            'Dim x As New NaymatBilling
            'msgbox(x.transfercharges("ENQUIRE", "DEPOSITOR", 10, "1001", "EWR100"))
            '     moveord()
            'GetMaturedRec()
            'Getsells()
            ' finish()
            'unmatched()
            'notifyunmatched()

            txtUserId.Text = GetUserName()

            cmd = New SqlCommand("select distinct(company) from CompanyAccounts where activation=1", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "CompanyAccounts")
            If (ds.Tables(0).Rows.Count > 0) Then
                cmbOrg.DataSource = ds.Tables(0)
                cmbOrg.DataValueField = "company"
                cmbOrg.DataBind()
                txtUserId.Enabled = True
                'txtPassword.Enabled = True
                Session("BrokerCode") = ""
                Session("UserCompany") = ""
                Session("Username") = ""
                'Label4.Text = PickTime1.GetTime0
                Label5.Text = Request.UserAgent
                If Session("ddr") = "yes" Then
                    Session("ddr") = ""
                    msgbox("Password Changed Successfully!")
                End If
                'Label10.Text = "ohh" ' TimeOfDay.AddTicks(60) - Date.Now.TimeOfDay
            Else
                msgbox("No current active company")
                txtUserId.Enabled = False
                'txtPassword.Enabled = False
            End If
        End If
        'Catch ex As Exception
        '    msgbox(ex.Message)
        'End Try

    End Sub
    Public Sub clearlogins()
        Try
            Session("Username") = ""
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub PasswordValidation()
        'Try

        Dim trails, changes As Integer
        strClientIP = Request.UserHostAddress()
        'cmd = New SqlCommand("select company,companyCode,CompanyType,userName,password,Trail,Activation,PasswordExpireyDate from SystemUsers where company='" & cmbOrg.Text & "' and userName='" & txtUserId.Text & "'", cn)
        cmd = New SqlCommand("select company,companyCode,CompanyType,userName,password,Trail,Activation,PasswordExpireyDate,accounttype, id, isnull(Active_session,'') as Active_session from SystemUsers where userName=@userid", cn)
        cmd.Parameters.AddWithValue("@userid", txtUserId.Text)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "SystemUsers")



        If (ds.Tables(0).Rows.Count > 0) Then
            If isUserActiveInAD(txtUserId.Text) = False Then
                msgbox("Your Account is not active, Please contact the system administrator for re-activation")
                Exit Sub
            End If
            'If ((ds.Tables(0).Rows(0).Item("password").ToString = "password")) Then
            '    msgbox("For your first time log in you are required to change your password")
            '    Exit Sub
            'End If
            If (ds.Tables(0).Rows(0).Item("Activation") = 0) Then
                msgbox("Your Account has been blocked, Please contact the system administrator for re-activation")
                Exit Sub
            End If

            Dim pp As New passmanagement
            Dim trail As Integer = pp.passrules().Tables(0).Rows(0).Item("LockoutAttempt").ToString
            If (ds.Tables(0).Rows(0).Item("trail") >= trail) Then

                msgbox("Your Account has been blocked, Please contact the system administrator for re-activation")
                Exit Sub
            End If


            'If (isnot txtPassword.Equals(ds.Tables(0).Rows(0).Item("password").ToString())) Then
            'msgbox("test1")
            'If ((base64Encode(txtPassword.Text)) <> (ds.Tables(0).Rows(0).Item("password").ToString())) Then


            '    trails = ds.Tables(0).Rows(0).Item("trail").ToString + 1
            '    changes = (trail - trails)
            '    cmd = New SqlCommand("Update systemusers set Trail=" & trails & " where userName='" & txtUserId.Text & "'", cn)
            '    If (cn.State = ConnectionState.Open) Then
            '        cn.Close()
            '    End If
            '    cn.Open()
            '    cmd.ExecuteNonQuery()
            '    cn.Close()
            '    lblChances.Text = CStr(" " & changes & " attempt(s) remaining before account locks !")
            '    If (CInt(ds.Tables(0).Rows(0).Item("trail").ToString) >= trail) Then
            '        cmd = New SqlCommand("Update systemusers set Activation=0 where company='" & cmbOrg.Text & "' and userName='" & txtUserId.Text & "'", cn)
            '        If (cn.State = ConnectionState.Open) Then
            '            cn.Close()
            '        End If
            '        cn.Open()
            '        cmd.ExecuteNonQuery()
            '        cn.Close()
            '        lblChances.Text = "Your account has been blocked, Please contact your administrator for account re-activation"
            '        Exit Sub
            '    End If
            '    lblChances.Text = CStr(" " & changes & " attempt(s) remaining before account locks !")
            '    'txtPassword.Text = ""
            '    msgbox("Wrong Username or Password!")
            '    Exit Sub
            'Else
            'msgbox("test2")
            If lblsess.Text = "" Then
                If (ds.Tables(0).Rows(0).Item("Active_session") = "") Then

                Else
                    lblsess.Text = 1
                    msgbox("You Currently have an active session on Another Computer, by trying to login again your other session will be terminated")
                    Exit Sub
                End If
            Else

            End If


            'If (CDate(ds.Tables(0).Rows(0).Item("PasswordExpireyDate").ToString) < CDate(Date.Now)) Then
            '    msgbox("Please change your password")
            '    ASPxPopupControl2.PopupHorizontalAlign = DevExpress.Web.ASPxClasses.PopupHorizontalAlign.WindowCenter
            '    ASPxPopupControl2.PopupVerticalAlign = DevExpress.Web.ASPxClasses.PopupVerticalAlign.WindowCenter
            '    ASPxPopupControl2.AllowDragging = True
            '    ASPxPopupControl2.ShowCloseButton = True
            '    ASPxPopupControl2.ShowOnPageLoad = True
            '    ShowPasswordReset()
            '    Exit Sub
            'End If


            Session("BrokerCode") = ds.Tables(0).Rows(0).Item("companyCode").ToString
            Session("UserCompany") = ds.Tables(0).Rows(0).Item("company").ToString
            Session("Username") = ds.Tables(0).Rows(0).Item("UserName").ToString
            Session("newid") = ds.Tables(0).Rows(0).Item("id").ToString
            Session("Companytype") = ds.Tables(0).Rows(0).Item("CompanyType").ToString

            Dim role As String = ds.Tables(0).Rows(0).Item("CompanyType").ToString + "" + ds.Tables(0).Rows(0).Item("AccountType").ToString
            Session("role") = role
            Dim menu As String = ds.Tables(0).Rows(0).Item("AccountType").ToString
            Dim dscompT As New DataSet
            cmd = New SqlCommand("select * from  Client_Companies where company_code='" & Session("brokercode").ToString & "'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(dscompT, "client_companies")
            If (dscompT.Tables(0).Rows.Count > 0) Then
                Session("CompanyType") = dscompT.Tables(0).Rows(0).Item("company_type").ToString
            End If
            If (cn.State = ConnectionState.Open) Then
                cn.Close()
            End If


            loginAudit()

            Try
                Dim a As New passmanagement
                a.auditlog(Session("BrokerCode"), Session("Username"), "Logged In", "0", "0")
            Catch ex As Exception

            End Try

            cmd = New SqlCommand("insert into UserActivityLog (UserName,Activity,TimeOfActivity,DateDone,CompanyCode,AddressLocation) values ('" & Session("Username") & "','Authorized new account creation','" & Date.Now & "','" & Now.Date & "','" & Session("BrokerCode") & "','" & strClientIP & "')", cn)
            If (cn.State = ConnectionState.Open) Then
                cn.Close()
            End If
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()

            'msgbox("test3")
            'Exit SUB

            Dim actsess As String = CreateRandomPassword(Integer.Parse(20))

            cmd = New SqlCommand("update systemUsers set trail=0, Active_session='" + actsess + "' where userName='" & txtUserId.Text & "'", cn)
            If (cn.State = ConnectionState.Open) Then
                cn.Close()
            End If
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()
            Session("Active_Session") = actsess
            'msgbox("test4")



            Session("usertype") = role
            Session("menu") = menu
            Response.Redirect("~\CDSMode\CDSHome.aspx")







            'End If
        Else
            msgbox("Wrong username")
            'txtUserId.Text = ""
            'txtPassword.Text = ""
            Exit Sub
        End If
        'Catch ex As Exception
        '    msgbox(ex.Message)
        'End Try
    End Sub
    Public Sub auditlog(participantcode As String, username As String, activity As String, affected As String, receiptid As String)
        ' Try
        Dim browser As HttpBrowserCapabilities = HttpContext.Current.Request.Browser
        cmd = New SqlCommand("insert into audit_log ([userid],[date],[time],[name],[activity], [userid_2], [request_id],[Browser],[IP],[Machine],[Broker_id],[AffectedTrans]) values((select id from systemusers where username='" & username & "' and companycode='" + participantcode + "'),getdate(),'" & Date.Now.Hour & ":" & Date.Now.Minute & ":" & Date.Now.Second & "','" + username + "','" + activity + "',0,'" + affected + "','" + browser.ToString + "','" + HttpContext.Current.Request.UserHostAddress + "','" + HttpContext.Current.Request.UserHostName + "','" + participantcode + "','" + receiptid + "')", cn)
        If (cn.State = ConnectionState.Open) Then
            cn.Close()
        End If
        cn.Open()
        cmd.ExecuteNonQuery()
        cn.Close()
        'Catch ex As Exception
        'End Try
    End Sub
    Public Shared Function CreateRandomPassword(ByVal PasswordLength As Integer) As String
        Dim _allowedChars As String = "abcdefghijkmnopqrstuvwxyzABCDEFGHJKLMNOPQRSTUVWXYZ0123456789"
        Dim randomNumber As New Random()
        Dim chars(PasswordLength - 1) As Char
        Dim allowedCharCount As Integer = _allowedChars.Length
        For i As Integer = 0 To PasswordLength - 1
            chars(i) = _allowedChars.Chars(CInt(Fix((_allowedChars.Length) * randomNumber.NextDouble())))
        Next i
        Return New String(chars)
    End Function
    Public Sub ValidateCPass()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select * from userAccounts where user_id='" & txtUserId.Text & "'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "UserAccounts")
            If (ds.Tables(0).Rows.Count > 0) Then
                If (ds.Tables(0).Rows(0).Item("Password").ToString = Trim(base64Encode(txtPassword.Text))) Then
                    Response.Redirect("~\Home.apx")

                End If
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Private Function base64Encode(ByVal sData As String) As String
        Try
            Dim encData_byte As Byte() = New Byte(sData.Length - 1) {}
            encData_byte = System.Text.Encoding.UTF8.GetBytes(sData)
            Dim encodedData As String = Convert.ToBase64String(encData_byte)
            Return (encodedData)
        Catch ex As Exception
            Throw (New Exception("Error in base64Encode" & ex.Message))
        End Try
    End Function
    Public Sub HidePasswordReset()
        Try
            'Label3.Visible = True
            'txtPassword.Visible = True
            Label6.Visible = False
            txtoldPass.Visible = False
            Label7.Visible = False
            txtNewPass.Visible = False
            Label8.Visible = False
            txtconfirmpassword.Visible = False
            btnSignIn.Visible = True
            btnChange.Visible = False
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub ShowPasswordReset()
        Try
            'Label3.Visible = True
            'txtPassword.Visible = True
            Label6.Visible = True
            txtoldPass.Visible = True
            Label7.Visible = True
            txtNewPass.Visible = True
            Label8.Visible = True
            txtconfirmpassword.Visible = True
            btnSignIn.Visible = True
            btnChange.Visible = True
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub btnChange_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnChange.Click
        Try


            If txtoldPass.Text = txtNewPass.Text Then
                msgbox("You cannot use your old password!")

            Else
                If txtUserId.Text = txtNewPass.Text Then
                    msgbox("Username and Password cannot be the same!")
                    Exit Sub
                End If
                'Dim reg As New Regex("^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[$@$!%*?&amp;])[A-Za-z\d$@$!%*?&amp;]{8,}")
                'If reg.IsMatch(txtNewPass.Text) = True Then

                'Else
                '    msgbox("Password must contain: Minimum 8 characters at least 1 UpperCase Alphabet, 1 LowerCase Alphabet, 1 Number and 1 Special Character")
                '    Exit Sub

                'End If
                Dim pp As New passmanagement

                Dim minpasslength As Integer = pp.passrules().Tables(0).Rows(0).Item("MinPasswordLength").ToString
                Dim maxpasslength As Integer = pp.passrules().Tables(0).Rows(0).Item("MaxPasswordLength").ToString
                Dim passtype As String = pp.passrules().Tables(0).Rows(0).Item("PasswordType").ToString

                If Len(txtNewPass.Text) < minpasslength Then
                    msgbox("Password length cannot be below " + minpasslength.ToString + " characters!")
                    Exit Sub
                End If
                If Len(txtNewPass.Text) > maxpasslength Then
                    msgbox("Password length cannot be above " + maxpasslength.ToString + " characters!")
                    Exit Sub
                End If
                If passtype = "Alphanumeric + Special Character" Then
                    If pp.containsnumeric(txtNewPass.Text) = False Then
                        msgbox("Password should contain numeric character(s)")
                        Exit Sub
                    End If
                    If pp.CheckForAlphaCharacters(txtNewPass.Text) = False Then
                        msgbox("Password should contain alphabet character(s)")
                        Exit Sub
                    End If
                    If pp.containsspecial(txtNewPass.Text) = False Then
                        msgbox("Password should contain special character(s)")
                        Exit Sub
                    End If
                ElseIf passtype = "Alphanumeric" Then
                    If pp.containsnumeric(txtNewPass.Text) = False Then
                        msgbox("Password should contain numeric character(s)")
                        Exit Sub
                    End If
                    If pp.CheckForAlphaCharacters(txtNewPass.Text) = False Then
                        msgbox("Password should contain alphabet character(s)")
                        Exit Sub
                    End If
                    If pp.containsspecial(txtNewPass.Text) = True Then
                        msgbox("Password should not contain special character(s)")
                        Exit Sub
                    End If
                ElseIf passtype = "Alphabet Only" Then
                    If pp.containsnumeric(txtNewPass.Text) = True Then
                        msgbox("Password should not contain numeric character(s)")
                        Exit Sub
                    End If
                    If pp.CheckForAlphaCharacters(txtNewPass.Text) = False Then
                        msgbox("Password should contain alphabet character(s)")
                        Exit Sub
                    End If
                    If pp.containsspecial(txtNewPass.Text) = True Then
                        msgbox("Password should not contain special character(s)")
                        Exit Sub
                    End If

                ElseIf passtype = "Numeric Only" Then
                    If pp.containsnumeric(txtNewPass.Text) = False Then
                        msgbox("Password should contain numeric character(s)")
                        Exit Sub
                    End If
                    If pp.CheckForAlphaCharacters(txtNewPass.Text) = True Then
                        msgbox("Password should not contain alphabet character(s)")
                        Exit Sub
                    End If
                    If pp.containsspecial(txtNewPass.Text) = True Then
                        msgbox("Password should not contain special character(s)")
                        Exit Sub
                    End If

                End If

                ChangePassword()
            End If

        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Public Sub ChangePassword()
        Try
            If (txtUserId.Text <> "") Then
                Dim ds As New DataSet
                cmd = New SqlCommand("select * from systemusers where userName='" & txtUserId.Text & "'", cn)
                adp = New SqlDataAdapter(cmd)
                adp.Fill(ds, "SystemUsers")
                If (ds.Tables(0).Rows.Count > 0) Then
                    Dim ros As New DataSet
                    cmd = New SqlCommand("select * from SystemUsers where userName='" & txtUserId.Text & "' and password='" & base64Encode(txtoldPass.Text) & "'", cn)
                    adp = New SqlDataAdapter(cmd)
                    adp.Fill(ros, "systemusers")
                    If (ros.Tables(0).Rows.Count > 0) Then
                        If (txtNewPass.Text = txtconfirmpassword.Text) Then
                            Dim pp As New passmanagement
                            Dim Validity As Integer = pp.passrules().Tables(0).Rows(0).Item("Validity").ToString

                            cmd = New SqlCommand("Update SystemUsers set password='" & base64Encode(txtNewPass.Text) & "', passwordExpireyDate='" & Now.Date.AddDays(Validity) & "' where username='" & txtUserId.Text & "'", cn)
                            If (cn.State = ConnectionState.Open) Then
                                cn.Close()
                            End If
                            cn.Open()
                            cmd.ExecuteNonQuery()
                            cn.Close()

                            msgbox("Password has been updated")
                            ASPxPopupControl2.PopupHorizontalAlign = DevExpress.Web.ASPxClasses.PopupHorizontalAlign.WindowCenter
                            ASPxPopupControl2.PopupVerticalAlign = DevExpress.Web.ASPxClasses.PopupVerticalAlign.WindowCenter
                            ASPxPopupControl2.AllowDragging = False
                            ASPxPopupControl2.ShowCloseButton = False
                            ASPxPopupControl2.ShowOnPageLoad = False
                            HidePasswordReset()
                        Else
                            msgbox("New password and confirmation password do not match")
                            Exit Sub
                        End If
                    Else
                        msgbox("Invalid old password")
                        Exit Sub
                    End If
                Else
                    msgbox("Enter a valid user name")
                    Exit Sub
                End If
            End If

        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub OpenPort()
        Try
            Dim msocClient As Socket
            msocClient = New Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)
            Dim szIPSelected As String = "192.168.3.253"
            Dim szPort As String = ""
            Dim alPort As Int32 = System.Convert.ToInt16(szPort, 10)

            Dim remoteIPAddress As System.Net.IPAddress = System.Net.IPAddress.Parse(szIPSelected)
            Dim remoteEndPoint As New System.Net.IPEndPoint(remoteIPAddress, alPort)
            msocClient.Connect(remoteEndPoint)
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Protected Sub ASPxButton1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ASPxButton1.Click
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select * from Orderssummary where company='OMZIL'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "orderssummary")
            Dim line As String = ""
            Dim line1 As String = "{1:F01CDSUATWWXXXX0000000000}"
            Dim Block2 As String = "{2:I199BANKBEBXXXXN}"

            Dim line2 As String = "-}"
            Dim line3 As String = "reference"

            If (ds.Tables(0).Rows.Count > 0) Then
                Dim alPort As Int32 = System.Convert.ToInt16(szPort, 10)
                Dim msocClient As Socket
                msocClient = New Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)
                Dim szIPSelected As String = "127.0.0.1"

                Dim remoteIPAddress As System.Net.IPAddress = System.Net.IPAddress.Parse(szIPSelected)
                Dim remoteEndPoint As New System.Net.IPEndPoint(remoteIPAddress, alPort)
                msocClient.Connect(remoteEndPoint)
                For i = 0 To ds.Tables(0).Rows.Count - 1
                    Dim Block41a As String = ""
                    Block41a = "{4:"
                    Dim block41b As String = ""
                    block41b = ":20:" & ds.Tables(0).Rows(i).Item("orderNumber").ToString
                    Dim block41c As String = ""
                    block41c = ":79:" & ds.Tables(0).Rows(i).Item("OrderType").ToString
                    Dim block41d As String = ""
                    block41d = ds.Tables(0).Rows(i).Item("Order_Quantity").ToString
                    Dim block41e As String = ""
                    block41e = Replace(ds.Tables(0).Rows(i).Item("BasePrice").ToString, ".", ",")
                    ''line = line + Left(ds.Tables(0).Rows(i).Item("OrderNumber").ToString & Space(13), 13) & Left(ds.Tables(0).Rows(i).Item("COMPANY") & Space(7), 7) & Left(ds.Tables(0).Rows(i).Item("ordernumber") & Space(7), 7) & Left(ds.Tables(0).Rows(i).Item("cds_number") & Space(13), 13)
                    'line = line + line1 + Block2 + Block41a
                    ''My.Computer.FileSystem.WriteAllText("D:\myfile.txt", line1 & vbCrLf, True)
                    ''My.Computer.FileSystem.WriteAllText("D:\myfile.txt", line3 & vbCrLf, True)
                    'My.Computer.FileSystem.WriteAllText("D:\myfile1.txt", line & vbCrLf, True)
                    'My.Computer.FileSystem.WriteAllText("D:\myfile1.txt", block41b & vbCrLf, True)
                    'My.Computer.FileSystem.WriteAllText("D:\myfile1.txt", block41c & vbCrLf, True)
                    'My.Computer.FileSystem.WriteAllText("D:\myfile1.txt", block41d & vbCrLf, True)
                    'My.Computer.FileSystem.WriteAllText("D:\myfile1.txt", block41e & vbCrLf, True)
                    'My.Computer.FileSystem.WriteAllText("D:\myfile1.txt", line2 & vbCrLf, True)
                    line = line + line1 + Block2 + Block41a & vbCrLf & block41b & vbCrLf & block41c & vbCrLf & block41d & vbCrLf & block41e & vbCrLf & line2 & vbCrLf

                    'Dim byData As Byte() = System.Text.Encoding.ASCII.GetBytes(line)
                    'msocClient.Send(byData)

                    line = ""
                Next
                msocClient.Connect(remoteEndPoint)

                Dim byData As Byte() = System.Text.Encoding.ASCII.GetBytes(line)
                msocClient.Send(byData)
                Dim EOF As String = "EOF" & vbCrLf
                Dim EOFbyData As Byte() = System.Text.Encoding.ASCII.GetBytes(EOF)
                msocClient.Send(EOFbyData)
                msgbox("done")
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub MOVESHARES()
        Try
            '   cmd = New SqlCommand("insert into trans select company, tocdsnumber, getdate(), getdate(), quantity, 'DEAL','SETTLEMENT', '0', 'D', '0', '' FROM tbl_units_move where status=0  insert into trans select company, fromcdsnumber, getdate(), getdate(), quantity*-1, 'DEAL','SETTLEMENT', '0', 'D', '0', '' FROM tbl_units_move where status=0", cn)
            cmd = New SqlCommand("DECLARE @cnt INT = (SELECT Min(ID) FROM CDS.DBO.tbl_units_move where status='0'); WHILE @cnt <= (SELECT MAX(ID) FROM CDS.DBO.tbl_units_move where status='0') BEGIN   insert into trans select company, tocdsnumber, getdate(), getdate(), quantity, 'DEAL','SETTLEMENT', '0', 'D', '0', '' FROM tbl_units_move where status=0 and id=@cnt insert into trans select company, fromcdsnumber, getdate(), getdate(), quantity*-1, 'DEAL','SETTLEMENT', '0', 'D', '0', '' FROM tbl_units_move where status=0 and id=@cnt SET @cnt = @cnt + 1;END;", cn)
            If (cn.State = ConnectionState.Open) Then
                cn.Close()
            End If
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()

        Catch ex As Exception

        End Try

    End Sub
    Public Sub finish()
        cmd = New SqlCommand("update tbl_units_move set status='1' where status='0'", cn)
        If (cn.State = ConnectionState.Open) Then
            cn.Close()
        End If
        cn.Open()
        cmd.ExecuteNonQuery()
        cn.Close()

    End Sub
    Public Sub unmatched()
        cmd = New SqlCommand("insert into cds.dbo.tbl_unmatchedorders (cds_number, quantity_unmatched, order_date, orderno, order_status) select shareholder, quantity, orderdate, orderno, '0' from testcds.dbo.LiveTradingExpiredOrders where orderno not in (select orderno from cds.dbo.tbl_unmatchedorders) ", cn)
        If (cn.State = ConnectionState.Open) Then
            cn.Close()
        End If
        cn.Open()
        cmd.ExecuteNonQuery()
        cn.Close()

    End Sub
    Public Sub GetMaturedRec()
        '   Try
        Dim ds As New DataSet
        cmd = New SqlCommand("select company, tocdsnumber, (select MOBILE from Accounts_Clients where cds_number=tbl_units_move.tocdsnumber) as mobile, (select sum(shares) from trans where CDS_Number=tbl_units_move.tocdsnumber and company=tbl_units_move.company) as newbalance, quantity, instrument  FROM tbl_units_move where status=0", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "tbl_SettlementSummary")
        If (ds.Tables(0).Rows.Count > 0) Then
            Dim i As Integer = 0
            For i = 0 To ds.Tables(0).Rows.Count - 1

                cmd = New SqlCommand(" insert into  trans values ('" + ds.Tables("tbl_SettlementSummary").Rows(i).Item("company").ToString + "', '" + ds.Tables("tbl_SettlementSummary").Rows(i).Item("tocdsnumber").ToString + "', getdate(), getdate(), '" + ds.Tables("tbl_SettlementSummary").Rows(i).Item("quantity").ToString + "', 'DEAL','SETTLEMENT', '0', 'D', '0', '','" + ds.Tables("tbl_SettlementSummary").Rows(i).Item("instrument").ToString + "')", cn)
                If (cn.State = ConnectionState.Open) Then
                    cn.Close()
                End If
                cn.Open()
                cmd.ExecuteNonQuery()
                cn.Close()

                Dim ds1 As New DataSet
                cmd = New SqlCommand("select sum(shares) as bal from trans where CDS_Number= '" + ds.Tables("tbl_SettlementSummary").Rows(i).Item("tocdsnumber") + "' and company='" + ds.Tables("tbl_SettlementSummary").Rows(i).Item("company") + "'", cn)
                adp = New SqlDataAdapter(cmd)
                adp.Fill(ds1, "bals")
                If (ds1.Tables("bals").Rows.Count > 0) Then
                    '  msgbox("http://45.55.246.121:8083/api/send?id=m6brnkdgdhti7kc6d3ea&secret=cdd065d4a323f21d097521348864ccdc&message_from=mAKIBA&message_to=" & ds.Tables("tbl_SettlementSummary").Rows(i).Item("mobile") & "&message_body=Your Buy Order is complete and your CDS Account has been credited with  " + ds.Tables("tbl_SettlementSummary").Rows(i).Item("quantity").ToString + " Bond Notes. Your new Balance is " + ds1.Tables("bals").Rows(0).Item("bal").ToString + " Bond Notes&delivery_time=1 day&delivery_report=1&priority=0")
                    Try
                        ' for m-akiba
                        'Dim request = TryCast(System.Net.WebRequest.Create("http://45.55.246.121:8083/api/send?id=m6brnkdgdhti7kc6d3ea&secret=cdd065d4a323f21d097521348864ccdc&message_from=mAKIBA&message_to=" & ds.Tables("tbl_SettlementSummary").Rows(i).Item("mobile") & "&message_body=Your Buy Order is complete and your CDS Account has been credited with  " + ds.Tables("tbl_SettlementSummary").Rows(i).Item("quantity").ToString + " Bond Notes. Your new Balance is " + ds1.Tables("bals").Rows(0).Item("bal").ToString + " Bond Notes&delivery_time=1 day&delivery_report=1&priority=0"), System.Net.HttpWebRequest)
                        'request.Method = "POST"
                        'request.ContentLength = 0
                        'Dim responseContent As String
                        'Using response = TryCast(request.GetResponse(), System.Net.HttpWebResponse)
                        '    Using reader = New System.IO.StreamReader(response.GetResponseStream())
                        '        responseContent = reader.ReadToEnd()
                        '    End Using
                        'End Using

                    Catch ex As Exception

                    End Try
                Else
                    msgbox("nothing")
                End If
            Next
        End If

    End Sub
    Public Sub Getsells()
        '   Try
        Dim ds2 As New DataSet
        cmd = New SqlCommand("select company, fromcdsnumber, (select MOBILE from Accounts_Clients where cds_number=tbl_units_move.fromcdsnumber ) as mobile, (select sum(shares) from trans where CDS_Number=tbl_units_move.fromcdsnumber  and company=tbl_units_move.company) as newbalance, quantity, amount, instrument  FROM tbl_units_move where status=0", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds2, "tbl_SettlementSummary2")
        If (ds2.Tables(0).Rows.Count > 0) Then
            Dim i As Integer = 0
            For i = 0 To ds2.Tables(0).Rows.Count - 1

                cmd = New SqlCommand(" insert into  trans values ('" & ds2.Tables("tbl_SettlementSummary2").Rows(i).Item("company").ToString & "', '" + ds2.Tables("tbl_SettlementSummary2").Rows(i).Item("fromcdsnumber").ToString + "', getdate(), getdate(), '-" + ds2.Tables("tbl_SettlementSummary2").Rows(i).Item("quantity").ToString + "', 'DEAL','SETTLEMENT', '0', 'D', '0', '','" + ds2.Tables("tbl_SettlementSummary2").Rows(i).Item("instrument").ToString + "')", cn)
                If (cn.State = ConnectionState.Open) Then
                    cn.Close()
                End If
                cn.Open()
                cmd.ExecuteNonQuery()
                cn.Close()

                Dim ds1 As New DataSet
                cmd = New SqlCommand("select sum(shares) as bal from trans where CDS_Number= '" + ds2.Tables("tbl_SettlementSummary2").Rows(i).Item("fromcdsnumber") + "' and company='" + ds2.Tables("tbl_SettlementSummary2").Rows(i).Item("company") + "'", cn)
                adp = New SqlDataAdapter(cmd)
                adp.Fill(ds1, "bals1")
                If (ds1.Tables("bals1").Rows.Count > 0) Then
                    'msgbox("http://45.55.246.121:8083/api/send?id=m6brnkdgdhti7kc6d3ea&secret=cdd065d4a323f21d097521348864ccdc&message_from=mAKIBA&message_to=" & ds2.Tables("tbl_SettlementSummary2").Rows(i).Item("mobile") & "&message_body=Your Sell Order is complete and your CDS Account has been debited with  " + ds2.Tables("tbl_SettlementSummary2").Rows(i).Item("quantity").ToString + " Bond Notes. Your new Balance is " + ds1.Tables("bals1").Rows(0).Item("bal").ToString + " Bond Notes&delivery_time=1 day&delivery_report=1&priority=0")
                    Try


                        Dim request = TryCast(System.Net.WebRequest.Create("http://45.55.246.121:8083/api/send?id=m6brnkdgdhti7kc6d3ea&secret=cdd065d4a323f21d097521348864ccdc&message_from=mAKIBA&message_to=" & ds2.Tables("tbl_SettlementSummary2").Rows(i).Item("mobile") & "&message_body=Your Sell Order is complete and your CDS Account has been debited with  " + ds2.Tables("tbl_SettlementSummary2").Rows(i).Item("quantity").ToString + " Bond Notes. Your new Balance is " + ds1.Tables("bals1").Rows(0).Item("bal").ToString + " Bond Notes&delivery_time=1 day&delivery_report=1&priority=0"), System.Net.HttpWebRequest)
                        request.Method = "POST"
                        request.ContentLength = 0
                        Dim responseContent As String
                        Using response = TryCast(request.GetResponse(), System.Net.HttpWebResponse)
                            Using reader = New System.IO.StreamReader(response.GetResponseStream())
                                responseContent = reader.ReadToEnd()
                            End Using
                        End Using
                    Catch ex As Exception

                    End Try

                    Try
                        Dim mystr As String = sendsoapfile("" + ds2.Tables("tbl_SettlementSummary2").Rows(i).Item("mobile") + "", ds2.Tables("tbl_SettlementSummary2").Rows(i).Item("amount"), "" + ds2.Tables("tbl_SettlementSummary2").Rows(i).Item("id") + "1234TTESCR", "from your sell of " + ds2.Tables("tbl_SettlementSummary2").Rows(i).Item("quantity") + " Units. Thank You for using our services.")
                    Catch ex As Exception

                    End Try
                End If

            Next
        End If
    End Sub
    Public Sub moveord()
        cmd = New SqlCommand("insert into cds.dbo.tbl_units_move select SELLERCDSNO, Buyercdsno, Quantity, '0', BuyCompany, deal, case when (select top 1 indicator from CDS.DBO.para_billing order by id desc)='PERCENT' THEN Quantity*DealPrice*(select top 1 PercentageOrValue/100 from CDS.DBO.para_billing order by id desc) ELSE (select top 1 PercentageOrValue from CDS.DBO.para_billing order by id desc) END AS [CHARGE], (select top 1 ChargeCode from CDS.DBO.para_billing order by id desc), DealPrice, instrument, affirmation,  sellbroker,buybroker   FROM testcds.dbo.Tbl_Matcheddeals where deal not in (select deal from cds.dbo.tbl_units_move) UPDATE  testcds.dbo.Tbl_Matcheddeals SET dealflag='C' where deal in (select deal from cds.dbo.tbl_units_move) UPDATE tbl_units_move set instrument=a.sec_type  from para_company a, tbl_units_move t where t.company=a.Company and instrument is null", cn)
        If (cn.State = ConnectionState.Open) Then
            cn.Close()
        End If
        cn.Open()
        cmd.ExecuteNonQuery()
        cn.Close()
    End Sub
    Public Sub notifyunmatched()
        Dim ds2 As New DataSet
        cmd = New SqlCommand("select (select MOBILE from Accounts_Clients where cds_number=tbl_unmatchedorders.cds_number) as mobile,quantity_unmatched , orderno from tbl_unmatchedorders where order_status='0'", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds2, "unmatched")
        If (ds2.Tables("unmatched").Rows.Count > 0) Then
            Dim x As Integer = 0
            For x = 0 To ds2.Tables("unmatched").Rows.Count - 1
                Dim request = TryCast(System.Net.WebRequest.Create("http://45.55.246.121:8083/api/send?id=m6brnkdgdhti7kc6d3ea&secret=cdd065d4a323f21d097521348864ccdc&message_from=mAKIBA&message_to=" & ds2.Tables("unmatched").Rows(x).Item("mobile") & "&message_body=Your Order Number " + ds2.Tables("unmatched").Rows(x).Item("orderno").ToString + "  of " + ds2.Tables("unmatched").Rows(x).Item("quantity_unmatched").ToString + " Bond Notes was not matched.&delivery_time=1 day&delivery_report=1&priority=0"), System.Net.HttpWebRequest)
                request.Method = "POST"
                request.ContentLength = 0
                Dim responseContent As String
                Using response = TryCast(request.GetResponse(), System.Net.HttpWebResponse)
                    Using reader = New System.IO.StreamReader(response.GetResponseStream())
                        responseContent = reader.ReadToEnd()
                    End Using
                End Using

            Next
        End If
    End Sub

    Function sendsoapfile(ByVal CustMobile As String, ByVal CustAMT As String, ByVal CustREF As String, ByVal msg As String) As String
        System.Net.ServicePointManager.ServerCertificateValidationCallback = Function(se As Object, cert As System.Security.Cryptography.X509Certificates.X509Certificate, chain As System.Security.Cryptography.X509Certificates.X509Chain, sslerror As System.Net.Security.SslPolicyErrors) True
        Dim request As HttpWebRequest = WebRequest.Create("https://41.223.56.58:7203/BulkPayment.asmx")
        Dim bytes As Byte()
        Dim strXmlInputData As String = String.Empty
        'strXmlInputData &= "<?xml version='1.0' encoding='utf-8'?>"
        strXmlInputData &= "<soapenv:Envelope xmlns:soapenv='http://schemas.xmlsoap.org/soap/envelope/' xmlns:zain='http://www.zain.com/'>"
        strXmlInputData &= "<soapenv:Header/>"
        strXmlInputData &= "<soapenv:Body>"
        strXmlInputData &= "<zain:TrxPayment>"
        strXmlInputData &= "<zain:referenceid>" & CustREF & "</zain:referenceid>"
        strXmlInputData &= "<zain:customermsisdn>" & CustMobile & "</zain:customermsisdn>"
        strXmlInputData &= " <zain:nickname>MAKIBA</zain:nickname>"
        strXmlInputData &= "<zain:amount>" & CDbl(CustAMT) & "</zain:amount>"
        strXmlInputData &= "<zain:batchref>" & CustREF & "</zain:batchref>"
        strXmlInputData &= "<zain:username>MAKIBA</zain:username>"
        strXmlInputData &= "<zain:password>MAKIBA@4321</zain:password>"
        strXmlInputData &= "<zain:narrative>" & msg & "</zain:narrative>"
        strXmlInputData &= "</zain:TrxPayment>"
        strXmlInputData &= "</soapenv:Body>"
        strXmlInputData &= "</soapenv:Envelope>"
        bytes = System.Text.Encoding.ASCII.GetBytes(strXmlInputData)
        request.ContentType = "text/xml; encoding='utf-8'"
        request.ContentLength = bytes.Length
        request.Method = "POST"
        Dim requestStream As Stream = request.GetRequestStream()
        requestStream.Write(bytes, 0, bytes.Length)
        requestStream.Close()

        Using myWebResponse As WebResponse = request.GetResponse()
            Using myResponseStream As Stream = myWebResponse.GetResponseStream()
                Using myStreamReader As StreamReader = New StreamReader(myResponseStream)
                    Return myStreamReader.ReadToEnd()
                End Using
            End Using
        End Using
    End Function


    Protected Sub LinkButton1_Click(sender As Object, e As EventArgs) Handles LinkButton1.Click
        ASPxPopupControl1.PopupHorizontalAlign = DevExpress.Web.ASPxClasses.PopupHorizontalAlign.WindowCenter
        ASPxPopupControl1.PopupVerticalAlign = DevExpress.Web.ASPxClasses.PopupVerticalAlign.WindowCenter
        ASPxPopupControl1.AllowDragging = True
        ASPxPopupControl1.ShowCloseButton = True
        ASPxPopupControl1.ShowOnPageLoad = True
    End Sub


    Private Function getPassword(ByVal emailID As String) As Boolean
        Dim ds2 As New DataSet
        cmd = New SqlCommand("select * from systemusers where email='" + emailID + "'", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds2, "unmatched")
        If (ds2.Tables("unmatched").Rows.Count > 0) Then
            insertpasswordreset(emailID)
        Else
            msgbox("Email not found!")
        End If
    End Function
    Public Sub insertpasswordreset(email As String)
        Dim sqlqry As String
        Dim newrandom As String = CreateRandomPassword(30)
        Dim xn As String = base64Encode(newrandom).ToString
        sqlqry = "insert into password_reset (user_mail, userid, date_created, random_number,[status]) values ('" + email + "',(select top 1 id from systemusers where email='" + email + "'),getdate(),'" + xn + "','0')"
        'End If
        cmd = New SqlCommand(sqlqry, cn)
        If (cn.State = ConnectionState.Open) Then
            cn.Close()
        End If
        cn.Open()
        cmd.ExecuteNonQuery()
        Dim g As New sendmail
        Dim dt As Date
        dt = Date.UtcNow

        g.sendmail(email, "Password Reset Instructions", "Dear " + fullname(email) + ",  You recently requested a password reset. To change your Custodial System password, follow the following link to change your password https://ewrsystem-uat.naymatcollateral.com/CTRADEWR/passwordchange.aspx?evilc=" + xn + "&tevilc=" + base64Encode(uid(email).ToString) + "&dt=" + base64Encode(dt.ToString) + " or copy and paste the link to your web browser. This link will expire in 24 hours, so be sure to use it right away. If you have any problems logging in, or additional questions, please contact our customer service team by email at: info@ncml.com. Thank you for using Custodial System")
        '   g.sendmail("clivetaps@outlook.com", "tes", "new")

    End Sub
    Public Function fullname(mail As String) As String
        Dim ds2 As New DataSet
        cmd = New SqlCommand("select top 1 isnull(forenames,'')+' '+isnull(surname,'') as names from systemusers where email='" + mail + "'", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds2, "unmatched")
        If (ds2.Tables("unmatched").Rows.Count > 0) Then
            Return ds2.Tables("unmatched").Rows(0).Item("names")
        Else
            Return ""
        End If
    End Function
    Public Function uid(mail As String) As String
        Dim ds2 As New DataSet
        cmd = New SqlCommand("select top 1 id from systemusers where email='" + mail + "'", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds2, "unmatched")
        If (ds2.Tables("unmatched").Rows.Count > 0) Then
            Return ds2.Tables("unmatched").Rows(0).Item("id")
        Else
            Return ""
        End If
    End Function

    Protected Sub btnSignIn0_Click(sender As Object, e As EventArgs) Handles btnSignIn0.Click
        If ASPxTextBox1.Text = "" Then
            Exit Sub
        End If
        getPassword(ASPxTextBox1.Text)
        msgbox("Password Reset Instructions sent by email")
        ASPxPopupControl1.ShowOnPageLoad = False

    End Sub
    Private Function isUserActiveInAD(ByVal pUserName As String) As Boolean
        Dim countFound As Long = 0
        Try
            Dim dssADDefaults As DataSet = getADCredentials()
            If dssADDefaults.Tables(0).Rows.Count > 0 Then
                Dim adName As String = dssADDefaults.Tables(0).Rows(0).Item("ADName").ToString
                Dim adUserAdmin As String = dssADDefaults.Tables(0).Rows(0).Item("ADUserName").ToString
                Dim adUserPass As String = dssADDefaults.Tables(0).Rows(0).Item("ADPassword").ToString
                'Dim uid As String = ""
                'Dim pwd As String = ""
                'Using context = New PrincipalContext(ContextType.Domain, "corpserve.local", uid, pwd)
                Using context = New PrincipalContext(ContextType.Domain, adName, adUserAdmin, adUserPass)
                    Using user As UserPrincipal = New UserPrincipal(context)
                        user.SamAccountName = pUserName
                        Using searcher = New PrincipalSearcher(user)
                            For Each result In searcher.FindAll()
                                Dim de As DirectoryEntry = TryCast(result.GetUnderlyingObject(), DirectoryEntry)
                                'Console.WriteLine("First Name: " & de.Properties("givenName").Value)
                                'Console.WriteLine("Last Name : " & de.Properties("sn").Value)
                                'Console.WriteLine("SAM account name   : " & de.Properties("samAccountName").Value)
                                'Console.WriteLine("User principal name: " & de.Properties("userPrincipalName").Value)
                                'Console.WriteLine("Mail: " & de.Properties("mail").Value)
                                'Dim groups As PrincipalSearchResult(Of Principal) = result.GetGroups()

                                'For Each item As Principal In groups
                                '    Console.WriteLine("Groups: {0}: {1}", item.DisplayName, item.Name)
                                'Next
                                If de.Properties("userAccountControl").Value.ToString.Trim.Contains("66048") = True Or de.Properties("userAccountControl").Value.ToString.Trim.Contains("512") = True Then
                                    countFound += 1
                                End If
                            Next
                        End Using
                    End Using
                End Using
            End If
        Catch ex As Exception
            ErrorLogging.WriteLogFile("", "login", ex.ToString)
        End Try
        If countFound >= 1 Then
            Return True
        Else
            Return False
        End If
    End Function
    Private Function getADCredentials() As DataSet
        Dim strSQL As String = ""
        strSQL = "SELECT A.* FROM [Para_AD] A "
        Using cn = New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("connpath"))
            Dim ds As New DataSet
            Dim cmd = New SqlCommand(strSQL, cn)
            Dim adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "ADusersTemp")
            Return ds
        End Using
    End Function
End Class
