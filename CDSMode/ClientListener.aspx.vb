Imports System.IO
Imports System.Array
Imports System.Net
Imports System.Net.Sockets

Partial Class CDSMode_ClientListener
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

    Private Property cmd1 As SqlCommand
        Get
            Return _cmd1
        End Get
        Set(value As SqlCommand)
            _cmd1 = value
        End Set
    End Property

    Public Sub msgbox(ByVal strMessage As String)

        'finishes server processing, returns to client.
        Dim strScript As String = "<script language=JavaScript>"
        strScript += "window.alert(""" & strMessage & """);"
        strScript += "</script>"
        Dim lbl As New System.Web.UI.WebControls.Label
        lbl.Text = strScript
        Page.Controls.Add(lbl)

    End Sub

    Protected Sub ASPxButton1_Click(sender As Object, e As EventArgs) Handles ASPxButton1.Click
        StartServer()
    End Sub
    Public Sub StartServer()
        Dim host As String
        Dim port As Integer = 4510

        Dim ipAdd As IPAddress = IPAddress.Parse("127.0.0.1")
        Dim tcpListener As New TcpListener(ipAdd, port)

        tcpListener.Start()
        'Dim locations As String = tcpListener.LocalEndpoint
        ServiceID.Text = "Server started"

        sock = tcpListener.AcceptSocket()
        'ConnectionID.Text = "Connection accepted from : " + sock.RemoteEndPoint

        rtfMessage.Text = FetchMessage()

    End Sub
    Private Function FetchMessage() As String
        Dim bytesReceived As [Byte]() = New Byte(255) {}

        Dim s As Socket = sock
        Dim bytes As Integer = 0
        Dim msg As String = Nothing
        Do
            bytes = s.Receive(bytesReceived, bytesReceived.Length, 0)

            msg = msg & Encoding.ASCII.GetString(bytesReceived, 0, bytes)
        Loop While bytes = bytesReceived.Length
        Return msg
    End Function
    Public Sub GetSavedData()
        Try

        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            StartServer()
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
End Class
