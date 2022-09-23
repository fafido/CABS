Imports System.IO
Imports System.Array
Imports System.Net
Imports System.Net.Sockets

Partial Class CDSMode_accessreport
    Inherits System.Web.UI.Page
    Dim cnstr As String = (System.Configuration.ConfigurationManager.AppSettings("connpath"))
    Dim conn As New SqlConnection(cnstr)
    Dim cn As New SqlConnection(cnstr)
    Dim cmd As SqlCommand
    Dim comm As SqlCommand
    Dim adp As SqlDataAdapter
    Dim wk_rec As String, sw_first As Boolean, fs, f
    Dim wk_head_shares As Double, wk_head_cnt As Integer, wk_tot_shares As Double
    Dim wk_tot_cnt As Integer, wk_err As Integer, wk_date As Date, wk_sys_cds As Double, wk_cds_ac As Long
    Dim wk_dets_shareholder As Long, wk_work_shareholder As Long
    Dim sock As Socket
    Dim wk_shares, wk_shareholder As Long
    Private _cmd1 As SqlCommand

   

    Public Sub msgbox(ByVal strMessage As String)

        'finishes server processing, returns to client.
        Dim strScript As String = "<script language=JavaScript>"
        strScript += "window.alert(""" & strMessage & """);"
        strScript += "</script>"
        Dim lbl As New System.Web.UI.WebControls.Label
        lbl.Text = strScript
        Page.Controls.Add(lbl)

    End Sub

   

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        msgbox("Cannot load Access report in a test environment, please setup the live environment first")
    End Sub
End Class
