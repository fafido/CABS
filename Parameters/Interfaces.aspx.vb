Imports System.Net.Mail
Imports System.IO
Partial Class Parameters_Default
    Inherits System.Web.UI.Page
    Dim constr As String = (System.Configuration.ConfigurationManager.AppSettings("connpath"))
    Dim cn As New SqlConnection(constr)
    Dim adp As SqlDataAdapter
    Dim cmd As SqlCommand
    Shared random As New Random()
    Dim Mail As New MailMessage
    Dim SMTP As New SmtpClient("smtp.googlemail.com")
    
    Public Sub FillGrid()

        Dim ds As New DataSet
        cmd = New SqlCommand("SELECT * from para_Interfaces", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "para_Interfaces")

        'If (ds.Tables(0).Rows.Count > 0) Then
        grdvInterfaces.DataSource = ds.Tables(0)
        grdvInterfaces.DataBind()
        'Else
        'msgbox("not found")
        'End If

    End Sub

    Protected Sub btnTradingSave_Click(sender As Object, e As EventArgs) Handles btnTradingSave.Click
        Dim dsid As New DataSet



        Dim cmd1 = New SqlCommand("insert into para_Interfaces (Category,RouteID,LocalListenerIP,LocalListenerPort,LocalSenderIP,LocalSenderPort,RemoteListenerIP,RemoteListenerPort,RemoteSenderIP,RemoteSenderPort) values ('TRADING','" & txtTradingRoute.Text & "','" & txtTradingLocalListenerIP.Text & "','" & txtTradingLocalListenerPort.Text & "','" & txtTradingLocalSenderIP.Text & "','" & txtTradingLocalSenderPort.Text & "','" & txtTradingRemoteReceiverIP.Text & "','" & txtTradingRemoteReceiverPort.Text & "','" & txtTradingRemoteSenderIP.Text & "','" & txtTradingRemoteSenderPort.Text & "')", cn)
        If (cn.State = ConnectionState.Open) Then
            cn.Close()
        End If
        cn.Open()
        cmd1.ExecuteNonQuery()
        cn.Close()

        FillGrid()

        txtTradingRoute.Text = ""
        txtTradingLocalListenerIP.Text = ""
        txtTradingLocalListenerPort.Text = ""
        txtTradingLocalSenderIP.Text = ""
        txtTradingLocalSenderPort.Text = ""
        txtTradingRemoteReceiverIP.Text = ""
        txtTradingRemoteReceiverPort.Text = ""
        txtTradingRemoteSenderIP.Text = ""
        txtTradingRemoteSenderPort.Text = ""

    End Sub

    Protected Sub btnAddSettlement_Click(sender As Object, e As EventArgs) Handles btnAddSettlement.Click
        Dim dsid As New DataSet



        Dim cmd1 = New SqlCommand("insert into para_Interfaces (Category,RouteID,LocalListenerIP,LocalListenerPort,LocalSenderIP,LocalSenderPort,RemoteListenerIP,RemoteListenerPort,RemoteSenderIP,RemoteSenderPort) values ('SETTLEMENT','" & txtSettlementRoute.Text & "','" & txtSettlementLocalListenerIP.Text & "','" & txtSettlementLocalListenerPort.Text & "','" & txtSettlementLocalSenderIP.Text & "','" & txtSettlementLocalSenderPort.Text & "','" & txtSettlementRemoteReceiverIP.Text & "','" & txtSettlementRemoteReceiverPort.Text & "','" & txtSettlementRemoteSenderIP.Text & "','" & txtSettlementRemoteSenderPort.Text & "')", cn)
        If (cn.State = ConnectionState.Open) Then
            cn.Close()
        End If
        cn.Open()
        cmd1.ExecuteNonQuery()
        cn.Close()

        FillGrid()

        txtSettlementRoute.Text = ""
        txtSettlementLocalListenerIP.Text = ""
        txtSettlementLocalListenerPort.Text = ""
        txtSettlementLocalSenderIP.Text = ""
        txtSettlementLocalSenderPort.Text = ""
        txtSettlementRemoteReceiverIP.Text = ""
        txtSettlementRemoteReceiverPort.Text = ""
        txtSettlementRemoteSenderIP.Text = ""
        txtSettlementRemoteSenderPort.Text = ""

    End Sub

    Protected Sub btnSaveInterDepository_Click(sender As Object, e As EventArgs) Handles btnSaveInterDepository.Click
        Dim dsid As New DataSet



        Dim cmd1 = New SqlCommand("insert into para_Interfaces (Category,RouteID,LocalListenerIP,LocalListenerPort,LocalSenderIP,LocalSenderPort,RemoteListenerIP,RemoteListenerPort,RemoteSenderIP,RemoteSenderPort) values ('INTERDEPOSITORY','" & txtInterDepRoute.Text & "','" & txtInterDepLocalListenerIP.Text & "','" & txtInterDepLocalListenerPort.Text & "','" & txtInterDepLocalSenderIP.Text & "','" & txtInterDepLocalSenderPort.Text & "','" & txtInterDepRemoteReceiverIP.Text & "','" & txtInterDepRemoteReceiverPort.Text & "','" & txtInterDepRemoteSenderIP.Text & "','" & txtInterDepRemoteSenderPort.Text & "')", cn)
        If (cn.State = ConnectionState.Open) Then
            cn.Close()
        End If
        cn.Open()
        cmd1.ExecuteNonQuery()
        cn.Close()

        FillGrid()

        txtInterDepRoute.Text = ""
        txtInterDepLocalListenerIP.Text = ""
        txtInterDepLocalListenerPort.Text = ""
        txtInterDepLocalSenderIP.Text = ""
        txtInterDepLocalSenderPort.Text = ""
        txtInterDepRemoteReceiverIP.Text = ""
        txtInterDepRemoteReceiverPort.Text = ""
        txtInterDepRemoteSenderIP.Text = ""
        txtInterDepRemoteSenderPort.Text = ""
    End Sub

    Protected Sub grdvInterfaces_SelectedIndexChanged(sender As Object, e As EventArgs) Handles grdvInterfaces.SelectedIndexChanged
        'If Not IsPostBack = True Then

        Select Case grdvInterfaces.SelectedRow.Cells(1).Text
            Case "TRADING"
                txtTradingRoute.Text = grdvInterfaces.SelectedRow.Cells(2).Text
                txtTradingLocalListenerIP.Text = grdvInterfaces.SelectedRow.Cells(3).Text
                txtTradingLocalListenerPort.Text = grdvInterfaces.SelectedRow.Cells(4).Text
                txtTradingLocalSenderIP.Text = grdvInterfaces.SelectedRow.Cells(5).Text
                txtTradingLocalSenderPort.Text = grdvInterfaces.SelectedRow.Cells(6).Text
                txtTradingRemoteReceiverIP.Text = grdvInterfaces.SelectedRow.Cells(7).Text
                txtTradingRemoteReceiverPort.Text = grdvInterfaces.SelectedRow.Cells(8).Text
                txtTradingRemoteSenderIP.Text = grdvInterfaces.SelectedRow.Cells(9).Text
                txtTradingRemoteSenderPort.Text = grdvInterfaces.SelectedRow.Cells(10).Text
            Case "SETTLEMENT"
                txtSettlementRoute.Text = grdvInterfaces.SelectedRow.Cells(2).Text
                txtSettlementLocalListenerIP.Text = grdvInterfaces.SelectedRow.Cells(3).Text
                txtSettlementLocalListenerPort.Text = grdvInterfaces.SelectedRow.Cells(4).Text
                txtSettlementLocalSenderIP.Text = grdvInterfaces.SelectedRow.Cells(5).Text
                txtSettlementLocalSenderPort.Text = grdvInterfaces.SelectedRow.Cells(6).Text
                txtSettlementRemoteReceiverIP.Text = grdvInterfaces.SelectedRow.Cells(7).Text
                txtSettlementRemoteReceiverPort.Text = grdvInterfaces.SelectedRow.Cells(8).Text
                txtSettlementRemoteSenderIP.Text = grdvInterfaces.SelectedRow.Cells(9).Text
                txtSettlementRemoteSenderPort.Text = grdvInterfaces.SelectedRow.Cells(10).Text
            Case "INTERDEPOSITORY"
                txtInterDepRoute.Text = grdvInterfaces.SelectedRow.Cells(2).Text
                txtInterDepLocalListenerIP.Text = grdvInterfaces.SelectedRow.Cells(3).Text
                txtInterDepLocalListenerPort.Text = grdvInterfaces.SelectedRow.Cells(4).Text
                txtInterDepLocalSenderIP.Text = grdvInterfaces.SelectedRow.Cells(5).Text
                txtInterDepLocalSenderPort.Text = grdvInterfaces.SelectedRow.Cells(6).Text
                txtInterDepRemoteReceiverIP.Text = grdvInterfaces.SelectedRow.Cells(7).Text
                txtInterDepRemoteReceiverPort.Text = grdvInterfaces.SelectedRow.Cells(8).Text
                txtInterDepRemoteSenderIP.Text = grdvInterfaces.SelectedRow.Cells(9).Text
                txtInterDepRemoteSenderPort.Text = grdvInterfaces.SelectedRow.Cells(10).Text

        End Select
        'If Not IsPostBack Then
        Dim cmd1 = New SqlCommand("Delete from para_Interfaces where RouteID = '" & grdvInterfaces.SelectedRow.Cells(2).Text & "'", cn)
        If (cn.State = ConnectionState.Open) Then
            cn.Close()
        End If
        cn.Open()
        cmd1.ExecuteNonQuery()
        cn.Close()

        FillGrid()
        'End If
    End Sub

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        FillGrid()
    End Sub
End Class
