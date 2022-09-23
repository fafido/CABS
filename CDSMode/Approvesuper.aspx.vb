Imports System.Data
Imports System.Data.SqlClient
Imports System.Net.Mail
Imports System.IO
Imports System
Imports System.Configuration
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls
Partial Class CDSMode_Approvesuper
    Inherits System.Web.UI.Page
    Dim constr As String = (System.Configuration.ConfigurationManager.AppSettings("connpath"))
    Dim cn As New SqlConnection(constr)
    Dim adp As SqlDataAdapter
    Dim cmd As SqlCommand
    Dim Mail As New MailMessage
    Dim SMTP As New SmtpClient("smtp.googlemail.com")
    Public email, subject, body As String

    Public Sub msgbox(ByVal strMessage As String)

        'finishes server processing, returns to client.
        Dim strScript As String = "<script language=JavaScript>"
        strScript += "window.alert(""" & strMessage & """);"
        strScript += "</script>"
        Dim lbl As New System.Web.UI.WebControls.Label
        lbl.Text = strScript
        Page.Controls.Add(lbl)

    End Sub
    Public Sub GetParticipants()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select distinct (category) from tbl_uncommitted where status='0' and sender<>'" + Session("Username").ToString + "'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "Client_Companies")
            If (ds.Tables(0).Rows.Count > 0) Then
                cmbParticipants.DataSource = ds.Tables(0)
                cmbparticipants.ValueField = "category"
                cmbparticipants.TextField = "category"
                cmbParticipants.DataBind()
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
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
                GetParticipants()
                '     GetSelectedParticipants()

                GetParticipantUsers()

            End If
            If Session("finish2") = "true" Then
                Session("finish2") = ""
                msgbox("Successfully Declined")
            End If
            If Session("finish") = "true" Then
                Session("finish") = ""
                msgbox("Successfully Executed")
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub GetSelectedParticipants()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select id,  category+' '+convert(nvarchar(10), id) as fnm from tbl_uncommitted where category='" & cmbParticipants.SelectedItem.Text & "' and status='0' and sender<>'" + Session("Username").ToString + "'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "client_companies")
            If (ds.Tables(0).Rows.Count > 0) Then
                ListBox1.DataSource = ds
                ListBox1.DataTextField = "fnm"
                ListBox1.DataValueField = "id"
                ListBox1.DataBind()
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Function Alreadyapproved(ID As String) As Boolean
        Dim ds As New DataSet
        cmd = New SqlCommand("select * from tbl_uncommitted where status='0' and id='" + ID + "'", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "SystemUsers1")
        If (ds.Tables(0).Rows.Count > 0) Then
            Return False
        Else
            Return True
        End If
    End Function
    Protected Sub ASPxButton1_Click(sender As Object, e As EventArgs) Handles ASPxButton1.Click
        If txtapproveid.Text = "" Then
            msgbox("Nothing Selected")
            Exit Sub
        End If
        If Alreadyapproved(txtapproveid.Text) = True Then
            msgbox("Record already actioned!")
            Exit Sub
        Else

            cmd = New SqlCommand("" + txtscript.Text + "  update tbl_uncommitted set status='1', comment='" + txtcomment.Text + "' where id='" + txtapproveid.Text + "'", cn)
            If (cn.State = ConnectionState.Open) Then
                cn.Close()
            End If
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()

            Try
                If txtemail.Text = "" Then

                Else
                    Dim m As New sendmail
                    m.sendmail(txtemail.Text, txtsubject.Text, txtbody.Text)
                End If


            Catch ex As Exception

            End Try

            Session("finish") = "true"
            Response.Redirect(Request.RawUrl)
        End If

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
    Public Sub GetParticipantUsers()
        Try
            Dim ds As New DataSet
            '      cmd = New SqlCommand("select id, userName as [User Account], Department ,mobile1,email, case activation when 0 then 'Not Active' when 1 then 'Active' else 'Unknown' end as [Activation Status] , forenames+' '+surname as [Names] from SystemUsers  where companyCode ='" & txtParticipant.Text & "'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "SystemUsers")
            If (ds.Tables(0).Rows.Count > 0) Then

            Else

            End If

        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub getselecteduserdetails()
        Dim ds As New DataSet
        cmd = New SqlCommand("select * from tbl_uncommitted where id='" + ListBox1.SelectedValue.ToString + "'", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "SystemUsers1")
        If (ds.Tables(0).Rows.Count > 0) Then
            txtapproveid.Text = ListBox1.SelectedValue.ToString
            If IsDBNull(ds.Tables(0).Rows(0).Item("description")) = True Then txtdescription.Text = "" Else txtdescription.Text = ds.Tables(0).Rows(0).Item("description")
            If IsDBNull(ds.Tables(0).Rows(0).Item("script")) = True Then txtscript.Text = "" Else txtscript.Text = ds.Tables(0).Rows(0).Item("script")
            If IsDBNull(ds.Tables(0).Rows(0).Item("sender")) = True Then txtinitiator.Text = "" Else txtinitiator.Text = ds.Tables(0).Rows(0).Item("sender")
            If IsDBNull(ds.Tables(0).Rows(0).Item("status")) = True Then txtstatus.Text = "" Else txtstatus.Text = ds.Tables(0).Rows(0).Item("status")
            If IsDBNull(ds.Tables(0).Rows(0).Item("date_inserted")) = True Then txtdate.Text = "" Else txtdate.Text = ds.Tables(0).Rows(0).Item("date_inserted")

            txtemail.Text = ds.Tables(0).Rows(0).Item("email_to")
            txtbody.Text = ds.Tables(0).Rows(0).Item("email_body")
            txtsubject.Text = ds.Tables(0).Rows(0).Item("email_subject")
      
            If txtstatus.Text = "0" Then
                txtstatus.Text = "Uncommitted/Pending"
            Else
                txtstatus.Text = "Executed/Successful/Rejected"
            End If
        End If
    End Sub

    Protected Sub cmbParticipants_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbParticipants.SelectedIndexChanged
        Try
            GetSelectedParticipants()

        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub




    Protected Sub ASPxButton2_Click(sender As Object, e As EventArgs) Handles ASPxButton2.Click
        Try
            cmd = New SqlCommand("update tbl_uncommitted set status='2', comment='" + txtcomment.Text + "' where id='" + txtapproveid.Text + "'", cn)
            If (cn.State = ConnectionState.Open) Then
                cn.Close()
            End If
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()
            Session("finish2") = "true"
            Response.Redirect(Request.RawUrl)
        Catch ex As Exception

        End Try
    End Sub

   
    Protected Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged
        getselecteduserdetails()

    End Sub
End Class
