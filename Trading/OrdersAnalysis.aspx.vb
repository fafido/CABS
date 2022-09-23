Imports System.Data
Imports System.Data.SqlClient
Partial Class Trading_OrdersAnalysis
    Inherits System.Web.UI.Page
    Dim constr As String = (System.Configuration.ConfigurationManager.AppSettings("connpath"))
    Dim cn As New SqlConnection(constr)
    Dim cmd As SqlCommand
    Dim adp As SqlDataAdapter
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
        If (Not IsPostBack) Then
            
        End If
    End Sub
    Protected Sub btnApproveall_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnApproveall.Click
        Try

            Dim strscript As String
            strscript = "<script langauage=JavaScript>"
            strscript += "window.open('AllOrdersReportCall.aspx');"
            strscript += "</script>"
            ClientScript.RegisterStartupScript(Me.GetType(), "newwin", strscript)

        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub btnApprove_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnApprove.Click
        Try
            If (rdAll.Checked = True) Then
                Dim strscript As String
                strscript = "<script langauage=JavaScript>"
                strscript += "window.open('OrdersAnalysisRep.aspx?Rep=1&DateFrom=" & BasicDatePicker1.Text & "&DateTo=" & BasicDatePicker2.Text & "');"
                strscript += "</script>"
                ClientScript.RegisterStartupScript(Me.GetType(), "newwin", strscript)
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
End Class