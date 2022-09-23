Imports System.Net.Mail
Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Imports System
Imports System.Configuration
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls
Imports DevExpress.Web.ASPxGridView

Partial Class TransferSec_AccountsPendingAuthList
    Inherits System.Web.UI.Page
    Dim constr As String = (System.Configuration.ConfigurationManager.AppSettings("connpath"))
    Dim cn As New SqlConnection(constr)
    Dim adp As SqlDataAdapter
    Dim cmd As SqlCommand
    Shared random As New Random()
    Dim Mail As New MailMessage
    Public password, numb, codec As String
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
                loadallWIP()
            End If
        Catch ex As Exception
            ErrorLogging.WriteLogFile("", "", ex.ToString)
        End Try
    End Sub
    Protected Sub grdWIP_RowCommand(sender As Object, e As DevExpress.Web.ASPxGridView.ASPxGridViewRowCommandEventArgs) Handles grdWIP.RowCommand
        Dim myID As String = e.CommandArgs.CommandArgument.ToString
        If e.CommandArgs.CommandName = "Select" Then
            Dim myAccType As String = getAccType(myID)
            If myAccType = "I" Or myAccType = "C" Or myAccType = "P" Or myAccType = "J" Then
                Response.Redirect("~/TransferSec/AccountsEdit.aspx?MyID=" & myID & "")
            Else
                msgbox("Authorizer has already Reviewed the account")
            End If
        End If
    End Sub
    Public Sub loadallWIP()
        Dim ds As New DataSet
        cmd = New SqlCommand("  Select ID,Forenames,Surname,IDNoPP,Add_1,JointName,IDNOPP,case when AccountType='I' then 'Individual' when AccountType='C' then 'Corporate' when AccountType='P' then 'Pension Fund' ELSE 'Joint' END AS AccType  from Accounts_Audit where ISNULL(ViewedAuth,0)=0 AND ISNULL(AuthorizationState,'') IN ('O') AND Created_By=@Created_By and CDS_Number NOT IN (SELECT DISTINCT p.CDS_Number FROM Accounts_Clients p) order by id desc ", cn)
        adp = New SqlDataAdapter(cmd)
        cmd.Parameters.AddWithValue("@Created_By", Session("Username"))
        adp.Fill(ds, "Accounts_Audit")
        If (ds.Tables(0).Rows.Count > 0) Then
            grdWIP.DataSource = ds
            grdWIP.DataBind()
        Else
            grdWIP.DataSource = Nothing
            grdWIP.DataBind()
        End If
    End Sub
    Private Function getAccType(ByVal RecID As String) As String
        Dim ds As New DataSet
        cmd = New SqlCommand(" Select * from Accounts_Audit where ID=@RecID AND ISNULL(ViewedAuth,0)=0 AND ISNULL(AuthorizationState,'') IN ('O') AND Created_By=@Created_By and CDS_Number NOT IN (SELECT DISTINCT p.CDS_Number FROM Accounts_Clients p)", cn)
        adp = New SqlDataAdapter(cmd)
        cmd.Parameters.AddWithValue("@RecID", RecID)
        cmd.Parameters.AddWithValue("@Created_By", Session("Username"))
        adp.Fill(ds, "Accounts_Audit")
        If (ds.Tables(0).Rows.Count > 0) Then
            Return ds.Tables(0).Rows(0).Item("AccountType").ToString
        Else
            Return ""
        End If
    End Function
End Class
