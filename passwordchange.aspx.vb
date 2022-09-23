Imports System.Text.RegularExpressions
Partial Class passwordchange
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

                ' msgbox(isvalidurl)
                If isvalidurl() = "Invalid" Then
                    Response.Redirect("~/Loginsystem.aspx")
                    '  msgbox("select * from password_reset where random_number='" + Request.QueryString("evilc") + "' and convert(nvarchar(50),userid)='" + decode(Request.QueryString("tevilc")) + "' and status='0'")

                Else

                End If
            End If

        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Function decode(encoded As String) As String
        Dim base64Decoded As String
        Dim data() As Byte
        data = System.Convert.FromBase64String(encoded)
        base64Decoded = System.Text.ASCIIEncoding.ASCII.GetString(data)
        Return base64Decoded
    End Function
    Public Function isvalidurl() As String
        Dim ds As New DataSet
        cmd = New SqlCommand("select * from password_reset where random_number='" + Request.QueryString("evilc") + "' and convert(nvarchar(50),userid)='" + decode(Request.QueryString("tevilc")) + "' and status='0'", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "UserAccounts")
        If (ds.Tables(0).Rows.Count > 0) Then
            Return "Valid"
        Else
            Return "Invalid"
        End If
    End Function

    Protected Sub ASPxButton3_Click(sender As Object, e As EventArgs) Handles ASPxButton3.Click

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

        If txtNewPass.Text = Session("Username") Then
                msgbox("Username cannot be same as Password")
                Exit Sub
            End If
            Dim ds As New DataSet
        cmd = New SqlCommand("select * from systemusers where convert(nvarchar(50),id)='" + decode(Request.QueryString("tevilc")) + "'", cn)
        adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "UserAccounts")
            If (ds.Tables(0).Rows.Count > 0) Then

            Dim Validity As Integer = pp.passrules().Tables(0).Rows(0).Item("Validity").ToString
            cmd = New SqlCommand("Update systemusers set password='" + base64Encode(txtNewPass.Text) + "', passwordExpireyDate='" & Now.Date.AddDays(Validity) & "' where  convert(nvarchar(50),id)='" + decode(Request.QueryString("tevilc")) + "' update password_reset set [status]='1' where userid='" + decode(Request.QueryString("tevilc")) + "'", cn)
            If (cn.State = ConnectionState.Open) Then
                cn.Close()
            End If
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()
            txtConfirmPassword.Text = ""
            txtNewPass.Text = ""
            Session("ddr") = "yes"
            Session("dd") = ""
            Response.Redirect("loginsystem.aspx")
        
            End If
        '   End If


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


End Class
