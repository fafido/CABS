Imports System.Data
Imports System.Data.SqlClient
Imports System.IO

Partial Class BrokerMode_TradesMessaging
    Inherits System.Web.UI.Page
    Dim constr As String = (System.Configuration.ConfigurationManager.AppSettings("connpath"))
    Dim cn As New SqlConnection(constr)
    Dim cmd As SqlCommand
    Dim adp As SqlDataAdapter
    Dim ds As New DataSet
    Dim maxholder As Integer = 0
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
            If (Session("Username") = Nothing) Then
                Response.Redirect("~\loginsystem.aspx")
                Exit Sub
            End If
            'Label4.Text = "Logged on as " & Session("UserName").ToString & " of " & Session("UserCompany")
            Dim HourofDay As Integer = 0
            HourofDay = TimeOfDay.Hour
            If (HourofDay < 12) Then
                Label4.Text = "Good Morning " & Session("Username").ToString
            ElseIf (HourofDay >= 12 And HourofDay <= 17) Then
                Label4.Text = "Good Afternoon " & Session("Username").ToString
            Else
                Label4.Text = "Good Evening " & Session("username").ToString
            End If
            GetBanks()
        End If
    End Sub

    Public Sub GetBanks()
        Try
            Dim ds As New DataSet

            cmd = New SqlCommand("select distinct (bank_name) from para_bank", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "para_bank")
            If (ds.Tables(0).Rows.Count > 0) Then
                cmbBank.DataSource = ds.Tables(0)
                cmbBank.ValueField = "bank_name"
                cmbBank.TextField = "bank_name"
                cmbBank.DataBind()
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Public Sub WriteDatatoPort()
        Try
            Dim Serial1 As New System.IO.Ports.SerialPort("80", 9600, System.IO.Ports.Parity.None, 8, System.IO.Ports.StopBits.One)
            Serial1.DtrEnable = True
            Serial1.RtsEnable = True
            Serial1.ReadTimeout = 3000

            Dim MessageBufferRequest = New Byte(7) {1, 3, 0, 28, 0, 1, _
                69, 204}
            Dim MessageBufferReply = New Byte(7) {0, 0, 0, 0, 0, 0, _
                0, 0}
            Dim BufferLength As Integer = 8

            If Not Serial1.IsOpen Then
                Serial1.Open()
            End If

            Try
                Serial1.Write(MessageBufferRequest, 0, BufferLength)
            Catch ex As Exception
                msgbox(ex.Message)
                'Return ""
            End Try

            System.Threading.Thread.Sleep(100)

            Serial1.Read(MessageBufferReply, 0, 7)


            'Return MessageBufferReply(3).ToString()
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Protected Sub btnSave0_Click(sender As Object, e As EventArgs) Handles btnSave0.Click
        Try
            WriteDatatoPort()
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
End Class
