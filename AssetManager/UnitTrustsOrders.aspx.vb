﻿
Partial Class Reporting_affirmationreport
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
                getcompanies()

            End If

        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        Try

            If cmbFund.Text = "" Then
                msgbox("Select Fund")
            End If
            If ASPxDateEdit1.Text = "" Then
                msgbox("Invalid Report Parameters Selected")
                Exit Sub
            End If
            If ASPxDateEdit2.Text = "" Then
                msgbox("Invalid Report Parameters Selected")
                Exit Sub
            End If


            Dim strscript As String
            strscript = "<script langauage=JavaScript>"
            strscript += "window.open('rptUnitTrustsOrders.aspx?datefrom=" + ASPxDateEdit1.Text + "&dateto=" + ASPxDateEdit2.Text + "&company=" + cmbFund.SelectedItem.Value + "');"
            strscript += "</script>"
            ClientScript.RegisterStartupScript(Me.GetType(), "newwin", strscript)


        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub getcompanies()
        Dim ds As New DataSet

        If (Session("usertype") = "UNITTRUSTADMIN") Then

            cmd = New SqlCommand("select company, fnam from [testcds_ROUTER].[dbo].[para_company] where BOARD='UNIT TRUST' AND ISIN_No='OMUT'", cn)
        Else
            cmd = New SqlCommand("select * from (select 1 as ranc, 'All' as fnam, 'ALL' as company union select 2 as ranc, fnam, company from testcds_Router.dbo.para_company) j order by j.ranc", cn)
        End If

        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "para_lendingRules")
        If (ds.Tables(0).Rows.Count > 0) Then
            cmbFund.DataSource = ds
            cmbFund.TextField = "fnam"
            cmbFund.ValueField = "company"
            cmbFund.DataBind()
        End If
    End Sub
End Class
