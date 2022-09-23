Imports System.IO
Imports System.Array
Imports System.Data.SqlClient
Imports System.Data
Imports System.Net.Sockets
Partial Class CDSMode_WSDLATSConfirmation
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
    Dim wk_shares, wk_shareholder As Long
    Dim validChars As String = "1"
    Dim strClientIP As String
    Dim msocClient As New Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)
    Dim szIPSelected As String = "127.0.0.1"
    Dim szPort As String = "4510"
    Dim alPort As Int32 = System.Convert.ToInt16(szPort, 10)

    Dim remoteIPAddress As System.Net.IPAddress = System.Net.IPAddress.Parse(szIPSelected)
    Dim remoteEndPoint As New System.Net.IPEndPoint(remoteIPAddress, alPort)
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

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If (Not IsPostBack) Then
                GetOTCTrades()
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub GetOTCTrades()
        Try
            Dim ds As New DataSet
            'cmd = New SqlCommand("select * from OTC_Data_Import ", cn)
            cmd = New SqlCommand("select  company as [Company], orderNumber as [OrderNumber],OrderType as [Order Type] ,Cds_number as [CDS Number],Order_Quantity as [Quantity],OrderDate as [Order Date], CASE STATUS WHEN 'O' then 'PENDING' WHEN 'C' THEN 'CONFIRMED' WHEN 'X'then 'INVALID' END AS STATUS FROM OrdersSummary order by OrderDate desc", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "OTC_Data_Import")
            If (ds.Tables(0).Rows.Count > 0) Then
                grdOrdersSummary.DataSource = ds.Tables(0)
                grdOrdersSummary.DataBind()
            Else
                grdOrdersSummary.DataSource = Nothing
                grdOrdersSummary.DataBind()
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub ASPxButton1_Click(sender As Object, e As EventArgs) Handles ASPxButton1.Click
        Response.Redirect("~/cdsmode/confirmedOrdersByBroker.aspx")
    End Sub

    Protected Sub ASPxButton2_Click(sender As Object, e As EventArgs) Handles ASPxButton2.Click
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

                    Dim byData As Byte() = System.Text.Encoding.ASCII.GetBytes(line)
                    msocClient.Send(byData)

                    line = ""
                Next
                'Dim msocClient As Socket
                'msocClient = New Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)
                'Dim szIPSelected As String = "127.0.0.1"
                'Dim szPort As String = "4510"
                'Dim alPort As Int32 = System.Convert.ToInt16(szPort, 10)

                'Dim remoteIPAddress As System.Net.IPAddress = System.Net.IPAddress.Parse(szIPSelected)
                'Dim remoteEndPoint As New System.Net.IPEndPoint(remoteIPAddress, alPort)
                'msocClient.Connect(remoteEndPoint)

                'Dim byData As Byte() = System.Text.Encoding.ASCII.GetBytes(line)
                'msocClient.Send(byData)
                Dim EOF As String = "EOF" & vbCrLf
                Dim EOFbyData As Byte() = System.Text.Encoding.ASCII.GetBytes(EOF)
                msocClient.Send(EOFbyData)
                msgbox("End of Transmissiong")
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
End Class
