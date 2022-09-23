Imports System.Data.SqlClient
Imports System.Data
Imports System.Net.Sockets
Imports System.Net
Imports System.IO
Imports System.Text.RegularExpressions

Partial Class _LoginSystem2
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

                moveord()
                GetMaturedRec()
                Getsells()
                pay2()
                finish()
                unmatched()
                notifyunmatched()



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
                    'Label4.Text = PickTime1.GetTime0
                    Label5.Text = Request.UserAgent
                    'Label10.Text = "ohh" ' TimeOfDay.AddTicks(60) - Date.Now.TimeOfDay
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
            cmd = New SqlCommand("select company,companyCode,CompanyType,userName,password,Trail,Activation,PasswordExpireyDate,accounttype, id from SystemUsers where userName='" & txtUserId.Text & "'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "SystemUsers")

            If (ds.Tables(0).Rows.Count > 0) Then
                If ((ds.Tables(0).Rows(0).Item("password").ToString = "password")) Then
                    msgbox("For your first time log in you are required to change your password")
                    Exit Sub
                End If
                If (ds.Tables(0).Rows(0).Item("Activation") = 0) Then
                    msgbox("Your Account has been blocked, Please contact the system administrator for re-activation")
                    Exit Sub
                End If
                'If (isnot txtPassword.Equals(ds.Tables(0).Rows(0).Item("password").ToString())) Then
                'msgbox("test1")
                If ((base64Encode(txtPassword.Text)) <> (ds.Tables(0).Rows(0).Item("password").ToString())) Then

                    trails = ds.Tables(0).Rows(0).Item("trail").ToString + 1
                    changes = (3 - trails)
                    cmd = New SqlCommand("Update systemusers set Trail=" & trails & " where userName='" & txtUserId.Text & "'", cn)
                    If (cn.State = ConnectionState.Open) Then
                        cn.Close()
                    End If
                    cn.Open()
                    cmd.ExecuteNonQuery()
                    cn.Close()
                    lblChances.Text = CStr(" " & changes & " attempt(s) remaining before account locks !")
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
                    msgbox("Wrong Username or Password!")
                    Exit Sub
                Else
                    'msgbox("test2")

                    If (CDate(ds.Tables(0).Rows(0).Item("PasswordExpireyDate").ToString) < CDate(Date.Now)) Then
                        msgbox("Please change your password")
                        ShowPasswordReset()
                        Exit Sub
                    End If


                    Session("BrokerCode") = ds.Tables(0).Rows(0).Item("companyCode").ToString
                    Session("UserCompany") = ds.Tables(0).Rows(0).Item("company").ToString
                    Session("Username") = ds.Tables(0).Rows(0).Item("UserName").ToString
                    Session("newid") = ds.Tables(0).Rows(0).Item("id").ToString
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

                    cmd = New SqlCommand("insert into UserActivityLog (UserName,Activity,TimeOfActivity,DateDone,CompanyCode,AddressLocation) values ('" & Session("Username") & "','Authorized new account creation','" & Date.Now & "','" & Now.Date & "','" & Session("BrokerCode") & "','" & strClientIP & "')", cn)
                    If (cn.State = ConnectionState.Open) Then
                        cn.Close()
                    End If
                    cn.Open()
                    cmd.ExecuteNonQuery()
                    cn.Close()

                    'msgbox("test3")
                    'Exit SUB

                    cmd = New SqlCommand("update systemUsers set trail=0 where company='" & cmbOrg.Text & "' and userName='" & txtUserId.Text & "'", cn)
                    If (cn.State = ConnectionState.Open) Then
                        cn.Close()
                    End If
                    cn.Open()
                    cmd.ExecuteNonQuery()
                    cn.Close()
                    'msgbox("test4")
                    If (ds.Tables(0).Rows(0).Item("CompanyType").ToString = "BROKER") Then
                        If (ds.Tables(0).Rows(0).Item("AccountType").ToString <> "ADMIN") Then
                            Session("usertype") = "BrokerUser"
                            Session("menu") = "User"
                            Response.Redirect("~\CDSMode\CDSHome.aspx")
                        Else
                            Session("usertype") = "BrokerAdmin"
                            Response.Redirect("~\CDSMode\CDSHome.aspx")
                        End If


                    End If

                    If (ds.Tables(0).Rows(0).Item("CompanyType").ToString = "REGULATOR") Then
                        If (ds.Tables(0).Rows(0).Item("AccountType").ToString <> "ADMIN") Then
                            Session("usertype") = "RegulatorUser"
                            Session("menu") = "User"
                            Response.Redirect("~\CDSMode\CDSHome.aspx")
                        Else
                            Session("usertype") = "RegulatorAdmin"
                            Response.Redirect("~\CDSMode\CDSHome.aspx")
                        End If


                    End If
                    If (ds.Tables(0).Rows(0).Item("CompanyType").ToString = "AUDIT") Then
                        '      msgbox("done")
                        Session("usertype") = "AuditAdmin"
                        Response.Redirect("~\CDSMode\CDSHome.aspx")

                    End If
                    If (ds.Tables(0).Rows(0).Item("CompanyType").ToString = "TSec") Then
                        '      msgbox("done")
                        Session("usertype") = "TransferSecUser"
                        Response.Redirect("~\CDSMode\CDSHome.aspx")

                    End If
                    'If (ds.Tables(0).Rows(0).Item("CompanyType").ToString = "BrokerAdmin") Then
                    '    Response.Redirect("~\Administration\BrokerAdminHme.aspx")
                    'End If

                    If (ds.Tables(0).Rows(0).Item("CompanyType").ToString = "CDS") Then
                        'Response.Redirect("~\CDSMode\CDSHome.aspx")
                        If (ds.Tables(0).Rows(0).Item("AccountType").ToString = "ADMIN") Then
                            Session("usertype") = "CDSAdmin"
                            Response.Redirect("~\CDSMode\CDSHome.aspx")

                        Else
                            Session("usertype") = "CDSUser"
                            Response.Redirect("~\CDSMode\CDSHome.aspx")
                        End If
                    End If

                    'If (ds.Tables(0).Rows(0).Item("CompanyType").ToString = "CDSAdmin") Then

                    '    Response.Redirect("~\CDSMode\CDSAdminHome.aspx")
                    'End If
                    If (ds.Tables(0).Rows(0).Item("CompanyType").ToString = "CUSTODIAN") Then
                        Session("usertype") = "CustodianUser"
                        Response.Redirect("~\CDSMode\CDSHome.aspx")
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
            Label3.Visible = True
            txtPassword.Visible = True
            Label6.Visible = False
            txtoldPass.Visible = False
            Label7.Visible = False
            txtNewPass.Visible = False
            Label8.Visible = False
            txtConfirmPassword.Visible = False
            btnSignIn.Visible = True
            btnChange.Visible = False
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub ShowPasswordReset()
        Try
            Label3.Visible = False
            txtPassword.Visible = False
            Label6.Visible = True
            txtoldPass.Visible = True
            Label7.Visible = True
            txtNewPass.Visible = True
            Label8.Visible = True
            txtConfirmPassword.Visible = True
            btnSignIn.Visible = False
            btnChange.Visible = True
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub btnChange_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnChange.Click
        Try

            If txtoldPass.Text = txtNewPass.Text Then
                msgbox("You cannot use your old password!")
                If txtUserId.Text = txtNewPass.Text Then
                    msgbox("You cannot have the same password as your username!")
                    Exit Sub
                End If
            Else
                If txtUserId.Text = txtNewPass.Text Then
                    msgbox("You cannot have the same password as your username!")
                    Exit Sub
                End If
                If Regex.IsMatch(txtConfirmPassword.Text, "/\d+/") Then
                    msgbox("Password must contain: Minimum 8 characters at least 1 UpperCase Alphabet, 1 LowerCase Alphabet, 1 Number and 1 Special Character")
                    Exit Sub
                End If

                If Regex.IsMatch(txtConfirmPassword.Text, "/[a-z]/") Then
                    msgbox("Password must contain: Minimum 8 characters at least 1 UpperCase Alphabet, 1 LowerCase Alphabet, 1 Number and 1 Special Character")
                    Exit Sub
                End If

                If Regex.IsMatch(txtConfirmPassword.Text, "/[0-9]/") Then
                    msgbox("Password must contain: Minimum 8 characters at least 1 UpperCase Alphabet, 1 LowerCase Alphabet, 1 Number and 1 Special Character")
                    Exit Sub
                End If

                If Regex.IsMatch(txtConfirmPassword.Text, "/[A-Z]/") Then
                    msgbox("Password must contain: Minimum 8 characters at least 1 UpperCase Alphabet, 1 LowerCase Alphabet, 1 Number and 1 Special Character")
                    Exit Sub
                End If
                If Regex.IsMatch(txtConfirmPassword.Text, "/[.,!,@,#,$,%,^,&]/") Then
                    msgbox("Password must contain: Minimum 8 characters at least 1 UpperCase Alphabet, 1 LowerCase Alphabet, 1 Number and 1 Special Character")
                    Exit Sub
                End If
                If Regex.IsMatch(txtConfirmPassword.Text, "/[*,?,_,~,-,£,(,)]/") Then
                    msgbox("Password must contain: Minimum 8 characters at least 1 UpperCase Alphabet, 1 LowerCase Alphabet, 1 Number and 1 Special Character")
                    Exit Sub
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
                        If (txtNewPass.Text = txtConfirmPassword.Text) Then
                            cmd = New SqlCommand("Update SystemUsers set password='" & base64Encode(txtNewPass.Text) & "', passwordExpireyDate='" & Now.Date.AddDays(30) & "' where username='" & txtUserId.Text & "'", cn)
                            If (cn.State = ConnectionState.Open) Then
                                cn.Close()
                            End If
                            cn.Open()
                            cmd.ExecuteNonQuery()
                            cn.Close()

                            msgbox("Password has been updated")
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
        cmd = New SqlCommand("select company, tocdsnumber, (select MOBILE from Accounts_Clients where cds_number=tbl_units_move.tocdsnumber) as mobile, (select sum(shares) from trans where CDS_Number=tbl_units_move.tocdsnumber and company=tbl_units_move.company) as newbalance, quantity  FROM tbl_units_move where status=0", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "tbl_SettlementSummary")
        If (ds.Tables(0).Rows.Count > 0) Then
            Dim i As Integer = 0
            For i = 0 To ds.Tables(0).Rows.Count - 1

                cmd = New SqlCommand(" insert into  trans values ('" + ds.Tables("tbl_SettlementSummary").Rows(i).Item("company").ToString + "', '" + ds.Tables("tbl_SettlementSummary").Rows(i).Item("tocdsnumber").ToString + "', getdate(), getdate(), '" + ds.Tables("tbl_SettlementSummary").Rows(i).Item("quantity").ToString + "', 'DEAL','SETTLEMENT', '0', 'D', '0', '')", cn)
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
                    Dim request = TryCast(System.Net.WebRequest.Create("http://45.55.246.121:8083/api/send?id=m6brnkdgdhti7kc6d3ea&secret=cdd065d4a323f21d097521348864ccdc&message_from=mAKIBA&message_to=" & ds.Tables("tbl_SettlementSummary").Rows(i).Item("mobile") & "&message_body=Your Buy Order is complete and your CDS Account has been credited with  " + ds.Tables("tbl_SettlementSummary").Rows(i).Item("quantity").ToString + " Bond Notes. Your new Balance is " + ds1.Tables("bals").Rows(0).Item("bal").ToString + " Bond Notes&delivery_time=1 day&delivery_report=1&priority=0"), System.Net.HttpWebRequest)
                    request.Method = "POST"
                    request.ContentLength = 0
                    Dim responseContent As String
                    Using response = TryCast(request.GetResponse(), System.Net.HttpWebResponse)
                        Using reader = New System.IO.StreamReader(response.GetResponseStream())
                            responseContent = reader.ReadToEnd()
                        End Using
                    End Using
                Else
                    msgbox("nothing")
                End If
            Next
        End If

    End Sub
    Public Sub Getsells()
        '   Try
        Dim ds2 As New DataSet
        cmd = New SqlCommand("select company, fromcdsnumber, (select MOBILE from Accounts_Clients where cds_number=tbl_units_move.fromcdsnumber ) as mobile, (select sum(shares) from trans where CDS_Number=tbl_units_move.fromcdsnumber  and company=tbl_units_move.company) as newbalance, quantity, amount  FROM tbl_units_move where status=0", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds2, "tbl_SettlementSummary2")
        If (ds2.Tables(0).Rows.Count > 0) Then
            Dim i As Integer = 0
            For i = 0 To ds2.Tables(0).Rows.Count - 1

                cmd = New SqlCommand(" insert into  trans values ('" & ds2.Tables("tbl_SettlementSummary2").Rows(i).Item("company").ToString & "', '" + ds2.Tables("tbl_SettlementSummary2").Rows(i).Item("fromcdsnumber").ToString + "', getdate(), getdate(), '-" + ds2.Tables("tbl_SettlementSummary2").Rows(i).Item("quantity").ToString + "', 'DEAL','SETTLEMENT', '0', 'D', '0', '')", cn)
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
                    Dim request = TryCast(System.Net.WebRequest.Create("http://45.55.246.121:8083/api/send?id=m6brnkdgdhti7kc6d3ea&secret=cdd065d4a323f21d097521348864ccdc&message_from=mAKIBA&message_to=" & ds2.Tables("tbl_SettlementSummary2").Rows(i).Item("mobile") & "&message_body=Your Sell Order is complete and your CDS Account has been debited with  " + ds2.Tables("tbl_SettlementSummary2").Rows(i).Item("quantity").ToString + " Bond Notes. Your new Balance is " + ds1.Tables("bals1").Rows(0).Item("bal").ToString + " Bond Notes&delivery_time=1 day&delivery_report=1&priority=0"), System.Net.HttpWebRequest)
                    request.Method = "POST"
                    request.ContentLength = 0
                    Dim responseContent As String
                    Using response = TryCast(request.GetResponse(), System.Net.HttpWebResponse)
                        Using reader = New System.IO.StreamReader(response.GetResponseStream())
                            responseContent = reader.ReadToEnd()
                        End Using
                    End Using

                    cmd = New SqlCommand("insert into Payment_SellOrder (Mobile, Amount, Quantity, payment_status) values ('" + ds2.Tables("tbl_SettlementSummary2").Rows(i).Item("mobile").ToString + "','" + ds2.Tables("tbl_SettlementSummary2").Rows(i).Item("amount").ToString + "','" + ds2.Tables("tbl_SettlementSummary2").Rows(i).Item("quantity").ToString + "','0')", cn)
                    If (cn.State = ConnectionState.Open) Then
                        cn.Close()
                    End If
                    cn.Open()
                    cmd.ExecuteNonQuery()
                    cn.Close()

                    ' Try
                    'sendsoapfile("" + ds2.Tables("tbl_SettlementSummary2").Rows(i).Item("mobile").tostring + "", ds2.Tables("tbl_SettlementSummary2").Rows(i).Item("amount"), "" + ds2.Tables("tbl_SettlementSummary2").Rows(i).Item("id").tostring + "1234TTESCR", "from your sell of " + ds2.Tables("tbl_SettlementSummary2").Rows(i).Item("quantity").tostring + " Units. Thank You for using our services.")
                    'Catch ex As Exception

                    'End Try
                End If

            Next
        End If
    End Sub
    Public Sub moveord()
        cmd = New SqlCommand("insert into cds.dbo.tbl_units_move select SELLERCDSNO, Buyercdsno, Quantity, '0', BuyCompany, deal, case when (select top 1 indicator from CDS.DBO.para_billing order by id desc)='PERCENT' THEN Quantity*DealPrice*(select top 1 PercentageOrValue/100 from CDS.DBO.para_billing order by id desc) ELSE (select top 1 PercentageOrValue from CDS.DBO.para_billing order by id desc) END AS [CHARGE], (select top 1 ChargeCode from CDS.DBO.para_billing order by id desc), DealPrice   FROM testcds.dbo.Tbl_MatchedOrders where deal not in (select deal from cds.dbo.tbl_units_move) UPDATE  testcds.dbo.Tbl_MatchedOrders SET dealflag='C' where deal in (select deal from cds.dbo.tbl_units_move)", cn)
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
        ' Dim request As HttpWebRequest = WebRequest.Create("https://41.223.56.58:7203/BulkPayment.asmx")
        Dim request As HttpWebRequest = WebRequest.Create("https://41.223.56.58:55533/BulkPayment.asmx")

        Dim bytes As Byte()
        Dim strXmlInputData As String = String.Empty
        'strXmlInputData &= "<?xml version='1.0' encoding='utf-8'?>"
        strXmlInputData &= "<soapenv:Envelope xmlns:soapenv='http://schemas.xmlsoap.org/soap/envelope/' xmlns:zain='http://www.zain.com/'>"
        strXmlInputData &= "<soapenv:Header/>"
        strXmlInputData &= "<soapenv:Body>"
        strXmlInputData &= "<zain:TrxPayment>"
        strXmlInputData &= "<zain:referenceid>" & CustREF & "</zain:referenceid>"
        strXmlInputData &= "<zain:customermsisdn>" & CustMobile & "</zain:customermsisdn>"
        strXmlInputData &= " <zain:nickname>mAkiba</zain:nickname>"
        strXmlInputData &= "<zain:amount>" & CDbl(CustAMT) & "</zain:amount>"
        strXmlInputData &= "<zain:batchref>" & CustREF & "</zain:batchref>"
        strXmlInputData &= "<zain:username>MAKIBAPAY</zain:username>"
        strXmlInputData &= "<zain:password>mAKIBA321</zain:password>"
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
    Public Sub pay2()
        Dim ds2 As New DataSet
        cmd = New SqlCommand("select * from payment_SellOrder where Payment_Status='0'", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds2, "tbl_SettlementSummary2")
        If (ds2.Tables(0).Rows.Count > 0) Then
            Dim i As Integer = 0
            For i = 0 To ds2.Tables(0).Rows.Count - 1
                Dim mystr As String = sendsoapfile("" + ds2.Tables("tbl_SettlementSummary2").Rows(i).Item("mobile").ToString + "", ds2.Tables("tbl_SettlementSummary2").Rows(i).Item("amount"), "" + ds2.Tables("tbl_SettlementSummary2").Rows(i).Item("id").ToString + "12332768ESCR", "You have received " + ds2.Tables("tbl_SettlementSummary2").Rows(i).Item("amount").ToString + "Ksh from your sell of " + ds2.Tables("tbl_SettlementSummary2").Rows(i).Item("quantity").ToString + " Units. Thank You for using our services.")
                ' msgbox(i)
            Next
            cmd = New SqlCommand("update payment_sellorder set payment_status='1'", cn)
            If (cn.State = ConnectionState.Open) Then
                cn.Close()
            End If
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()
        End If
    End Sub

    
    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim reg As New Regex("^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[$@$!%*?&amp;])[A-Za-z\d$@$!%*?&amp;]{8,}")
        If reg.IsMatch(txtPassword.Text) = True Then
            msgbox("email")
        Else
            msgbox("not email")
        End If

        ' Static method:
        ' Name does not match schema
        'If Not Regex.IsMatch(txtPassword.Text, "^[a-zA-Z'.]{1,40}$") Then
        '    msgbox("ismatch")
        'Else
        '    msgbox("notmatch")
        'End If

    End Sub
End Class
