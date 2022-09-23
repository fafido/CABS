﻿
Partial Class Reporting_participantlist
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
        If Session("UserName").ToString = "" Then
            Session.Abandon()
            Response.Cache.SetCacheability(HttpCacheability.NoCache)
            Response.Buffer = True
            Response.ExpiresAbsolute = DateTime.Now.AddDays(-1.0)
            Response.Expires = -1000
            Response.CacheControl = "no-cache"
            Response.Redirect("~/loginsystem.aspx", True)
        End If
        Try
            Page.MaintainScrollPositionOnPostBack = True
            If (Not IsPostBack) Then
                checkSessionState()
                Getparticipants()
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Public Sub Getparticipants()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select DISTINCT Company_type from Client_Companies where Company_type  NOT IN ('DEPOSITOR','CMC')   UNION SELECT 'WAREHOUSE OPERATOR' AS Company_Type", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds)
            cmdparticipants.DataSource = ds
            cmdparticipants.DataTextField = "company_type"
            cmdparticipants.DataBind()
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        Try

            If cmdparticipants.Text = "" Then
                msgbox("Invalid Report Parameters Selected")
                Exit Sub
            End If



            Dim strscript As String
            strscript = "<script langauage=JavaScript>"
            strscript += "window.open('rptparticipantlist.aspx?Participant=" & cmdparticipants.SelectedItem.Text & "');"
            strscript += "</script>"
            ClientScript.RegisterStartupScript(Me.GetType(), "newwin", strscript)

        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub


End Class



