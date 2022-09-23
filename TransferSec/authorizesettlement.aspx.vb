Partial Class TransferSec_authorizesettlement
    Inherits System.Web.UI.Page
    Dim constr As String = (System.Configuration.ConfigurationManager.AppSettings("connpath"))
    Dim cn As New SqlConnection(constr)
    Dim adp As SqlDataAdapter
    Dim cmd As SqlCommand
    Public allrec As String
    Public customernumber, customermessage As String

    Public Sub msgbox(ByVal strMessage As String)

        'finishes server processing, returns to client.
        Dim strScript As String = "<script language=JavaScript>"
        strScript += "window.alert(""" & strMessage & """);"
        strScript += "</script>"
        Dim lbl As New System.Web.UI.WebControls.Label
        lbl.Text = strScript
        Page.Controls.Add(lbl)

    End Sub
    Public Sub getpendingauth()
        Try
            Dim ds As New DataSet
            'cmd = New SqlCommand("select Tbl_MatchedOrders .Sellercdsno as [CDS No.] , Accounts_Clients.Surname +' '+Accounts_Clients .Forenames as [Client], Tbl_MatchedOrders .Quantity as [Quantity], Tbl_MatchedOrders.DealPrice as [Price], Tbl_MatchedOrders .Trade as [Trade Date] from Tbl_MatchedOrders , Accounts_Clients where Tbl_MatchedOrders.Sellercdsno = Accounts_Clients .CDS_Number and trade between '" & Datefrom & "' and '" & DateTo & "'", cn)
            cmd = New SqlCommand("select DISTINCT deal, mo.tocdsnumber as buyercdsno, (select surname+' '+forenames from cds.dbo.accounts_clients where cds_number=mo.tocdsnumber) as [Buyer Name],   mo.fromcdsnumber as sellercdsno,(select surname+' '+forenames from cds.dbo.accounts_clients where cds_number=mo.fromcdsnumber) as [Seller Name] , mo.quantity, mo.company from [CDS].[dbo].[tbl_units_move] mo where status=0", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "tbl_MatchedOrders")
            If (ds.Tables(0).Rows.Count > 0) Then
                grdSellers.DataSource = ds.Tables(0)
                grdsellers.DataBind()
                If (ds.Tables(0).Rows.Count > 1) Then
                    Button1.Visible = True

                End If
            Else
                grdsellers.DataSource = Nothing
                grdsellers.DataBind()
                msgbox("No Pending Records")
            End If

        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub GetMatchedOrders()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select * from tbl_matchedorders where dealFlag<>'C'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "tbl_matchedorders")
            If (ds.Tables(0).Rows.Count > 0) Then
                Dim i As Integer = 0
                For i = 0 To ds.Tables(0).Rows.Count - 1
                    cmd = New SqlCommand()
                Next
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
                getpendingauth()
                '  MovingOrders()

                checkSessionState()

            End If
            If Session("finish") = "yes" Then
                Session("finish") = ""
                msgbox("Successfully Authorized")
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

   
    Protected Sub grdSellers_SelectedIndexChanged(sender As Object, e As EventArgs) Handles grdSellers.SelectedIndexChanged
        allrec = "AND deal_reference='S/" + grdsellers.SelectedValue.ToString + "' or deal_reference='P/" + grdsellers.SelectedValue.ToString + "'"
        GetMaturedRec()
        Session("finish") = "yes"
        Response.Redirect(Request.RawUrl)
    End Sub
    Public Sub MovingOrders()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select * from tbl_MatchedOrders where AccountsStatus='O'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "tbl_MatchedOrders")
            If (ds.Tables(0).Rows.Count > 0) Then
                Dim i As Integer = 0
                For i = 0 To ds.Tables(0).Rows.Count - 1

                    Dim adddress As String = ""
                    Dim dealRef As String = ""
                    Dim BrokersAmount As Double = 0.0
                    Dim Brokrage As Double = 0.0
                    Dim basicCharge As Double = 0.0
                    Dim stampDuty As Double = 0.0
                    Dim capitalGainsTax As Double = 0.0
                    Dim vat As Double = 0.0
                    Dim AmountDue As Double = 0.0
                    Dim SettlementDate As Date
                    Dim BrokerageTotal As Double = 0.0
                    Dim SubTotal As Double = 0.0
                    Dim AccountName As String = ""
                    Dim Address As String = ""
                    Dim company As String = ds.Tables(0).Rows(i).Item("company").ToString

                    BrokersAmount = CDbl(ds.Tables(0).Rows(i).Item("quantity").ToString * ds.Tables(0).Rows(i).Item("dealPrice").ToString)
                    Brokrage = CDbl(BrokersAmount * 0.01)
                    basicCharge = 2.0
                    capitalGainsTax = CDbl(BrokersAmount * 0.05)
                    vat = CDbl((Brokrage + basicCharge) * 0.15)

                    AmountDue = CDbl(BrokersAmount - (Brokrage + basicCharge + capitalGainsTax + vat))
                    SettlementDate = CDate(ds.Tables(0).Rows(i).Item("trade").ToString).AddDays(7)
                    BrokerageTotal = Brokrage
                    SubTotal = BrokerageTotal + basicCharge

                    Dim rec As New DataSet

                    cmd = New SqlCommand("select * from Accounts_Clients where cds_number='" & ds.Tables(0).Rows(i).Item("sellercdsno").ToString & "'", cn)
                    adp = New SqlDataAdapter(cmd)
                    adp.Fill(rec, "Accounts_Clients")

                    If (rec.Tables(0).Rows.Count > 0) Then
                        AccountName = rec.Tables(0).Rows(0).Item("surname").ToString & " " & rec.Tables(0).Rows(0).Item("forenames").ToString
                        adddress = rec.Tables(0).Rows(0).Item("add_1").ToString & " " & rec.Tables(0).Rows(0).Item("add_2").ToString & " " & rec.Tables(0).Rows(0).Item("add_3").ToString & " " & rec.Tables(0).Rows(0).Item("add_4").ToString
                    End If
                    cmd = New SqlCommand("insert into tbl_settlementSummary (cds_number,deal_reference,client_name,client_address,trade_date,Quantity,unit_price,Broker_Amount,Broker_Charge,Stamp_Duty,Capital_Gain_Tax,vat,Amount_due,Settlement_date,Brokerage_Total,Sub_total,OrderType,company) values ('" & ds.Tables(0).Rows(i).Item("sellercdsno").ToString & "','" & "S/" & ds.Tables(0).Rows(i).Item("Deal").ToString & "','" & AccountName & "','" & adddress & "','" & ds.Tables(0).Rows(i).Item("trade").ToString & "'," & ds.Tables(0).Rows(i).Item("quantity").ToString & "," & ds.Tables(0).Rows(i).Item("DealPrice").ToString & "," & BrokersAmount & "," & basicCharge & ",0," & capitalGainsTax & "," & vat & "," & AmountDue & ",'" & SettlementDate & "'," & BrokerageTotal & "," & SubTotal & ",'S','" & company & "')", cn)
                    If (cn.State = ConnectionState.Open) Then
                        cn.Close()
                    End If
                    cn.Open()
                    cmd.ExecuteNonQuery()
                    cn.Close()

                    rec.Clear()

                    cmd = New SqlCommand("select * from Accounts_Clients where cds_number='" & ds.Tables(0).Rows(i).Item("buyercdsno").ToString & "'", cn)
                    adp = New SqlDataAdapter(cmd)
                    adp.Fill(rec, "Accounts_Clients")

                    If (rec.Tables(0).Rows.Count > 0) Then
                        AccountName = rec.Tables(0).Rows(0).Item("surname").ToString & " " & rec.Tables(0).Rows(0).Item("forenames").ToString
                        adddress = rec.Tables(0).Rows(0).Item("add_1").ToString & " " & rec.Tables(0).Rows(0).Item("add_2").ToString & " " & rec.Tables(0).Rows(0).Item("add_3").ToString & " " & rec.Tables(0).Rows(0).Item("add_4").ToString
                    End If
                    AmountDue = 0
                    stampDuty = 2
                    'AmountDue = CDbl(BrokersAmount + (Brokrage + basicCharge + capitalGainsTax + vat))
                    AmountDue = CDbl(BrokersAmount + (Brokrage + basicCharge + vat + stampDuty))

                    cmd = New SqlCommand("insert into tbl_settlementSummary (cds_number,deal_reference,client_name,client_address,trade_date,Quantity,unit_price,Broker_Amount,Broker_Charge,Stamp_Duty,Capital_Gain_Tax,vat,Amount_due,Settlement_date,Brokerage_Total,Sub_total,OrderType,company) values ('" & ds.Tables(0).Rows(i).Item("Buyercdsno").ToString & "','" & "P/" & ds.Tables(0).Rows(i).Item("Deal").ToString & "','" & AccountName & "','" & adddress & "','" & ds.Tables(0).Rows(i).Item("trade").ToString & "'," & ds.Tables(0).Rows(i).Item("quantity").ToString & "," & ds.Tables(0).Rows(i).Item("DealPrice").ToString & "," & BrokersAmount & "," & basicCharge & ",'" & stampDuty & "',0," & vat & "," & AmountDue & ",'" & SettlementDate & "'," & BrokerageTotal & "," & SubTotal & ",'B','" & company & "')", cn)
                    If (cn.State = ConnectionState.Open) Then
                        cn.Close()
                    End If
                    cn.Open()
                    cmd.ExecuteNonQuery()
                    cn.Close()



                    cmd = New SqlCommand("insert into trans select company, tocdsnumber, getdate(), getdate(), quantity, 'DEAL','SETTLEMENT', '0', 'D', '0', '' FROM tbl_units_move where status=0  insert into trans select company, fromcdsnumber, getdate(), getdate(), quantity*-1, 'DEAL','SETTLEMENT', '0', 'D', '0', '' FROM tbl_units_move where status=0  update tbl_units_move set status='1' where status='0'", cn)
                    If (cn.State = ConnectionState.Open) Then
                        cn.Close()
                    End If
                    cn.Open()
                    cmd.ExecuteNonQuery()
                    cn.Close()


                Next

                msgbox("Settlements Ready For Authorization")

            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub MOVESHARES()
        cmd = New SqlCommand("insert into trans select company, tocdsnumber, getdate(), getdate(), quantity, 'DEAL','SETTLEMENT', '0', 'D', '0', '' FROM tbl_units_move where status=0  insert into trans select company, fromcdsnumber, getdate(), getdate(), quantity*-1, 'DEAL','SETTLEMENT', '0', 'D', '0', '' FROM tbl_units_move where status=0", cn)
        If (cn.State = ConnectionState.Open) Then
            cn.Close()
        End If
        cn.Open()
        cmd.ExecuteNonQuery()
        cn.Close()

    End Sub
    Public Sub finish()
        cmd = New SqlCommand("update tbl_units_move set status='1' where status='0'", cn)
        If (cn.State = ConnectionState.Open) Then
            cn.Close()
        End If
        cn.Open()
        cmd.ExecuteNonQuery()
        cn.Close()

    End Sub
    Public Sub GetMaturedRec()
        '   Try
        Dim ds As New DataSet
        cmd = New SqlCommand("select company, tocdsnumber, (select MOBILE from Accounts_Clients where cds_number=tbl_units_move.tocdsnumber) as mobile, (select sum(shares) from trans where CDS_Number=tbl_units_move.tocdsnumber and company=tbl_units_move.company) as newbalance, quantity  FROM tbl_units_move where status=0", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "tbl_SettlementSummary")
        If (ds.Tables(0).Rows.Count > 0) Then
            Dim i As Integer = 0
            For i = 0 To ds.Tables(0).Rows.Count - 1
                Dim request = TryCast(System.Net.WebRequest.Create("http://45.55.246.121:8083/api/send?id=m6brnkdgdhti7kc6d3ea&secret=cdd065d4a323f21d097521348864ccdc&message_from=mAKIBA&message_to=" & ds.Tables("tbl_SettlementSummary").Rows(i).Item("mobile") & "&message_body=Your Buy Order is complete and your CDS Account has been credited with  " + ds.Tables("tbl_SettlementSummary").Rows(i).Item("quantity").ToString + " Bond Notes. Your new Balance is " + ds.Tables("tbl_SettlementSummary").Rows(i).Item("newbalance").ToString + " Bond Notes&delivery_time=1 day&delivery_report=1&priority=0"), System.Net.HttpWebRequest)
                request.Method = "POST"
                request.ContentLength = 0
                Dim responseContent As String
                Using response = TryCast(request.GetResponse(), System.Net.HttpWebResponse)
                    Using reader = New System.IO.StreamReader(response.GetResponseStream())
                        responseContent = reader.ReadToEnd()
                    End Using
                End Using
            Next
        End If

    End Sub
    Public Sub Getsells()
        '   Try
        Dim ds2 As New DataSet
        cmd = New SqlCommand("select company, fromcdsnumber, (select MOBILE from Accounts_Clients where cds_number=tbl_units_move.fromcdsnumber ) as mobile, (select sum(shares) from trans where CDS_Number=tbl_units_move.fromcdsnumber  and company=tbl_units_move.company) as newbalance, quantity  FROM tbl_units_move where status=0", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds2, "tbl_SettlementSummary2")
        If (ds2.Tables(0).Rows.Count > 0) Then
            Dim i As Integer = 0
            For i = 0 To ds2.Tables(0).Rows.Count - 1
                Dim request = TryCast(System.Net.WebRequest.Create("http://45.55.246.121:8083/api/send?id=m6brnkdgdhti7kc6d3ea&secret=cdd065d4a323f21d097521348864ccdc&message_from=mAKIBA&message_to=" & ds2.Tables("tbl_SettlementSummary2").Rows(i).Item("mobile") & "&message_body=Your Sell Order is complete and your CDS Account has been debited with  " + ds2.Tables("tbl_SettlementSummary2").Rows(i).Item("quantity").ToString + " Bond Notes. Your new Balance is " + ds2.Tables("tbl_SettlementSummary2").Rows(i).Item("newbalance").ToString + " Bond Notes&delivery_time=1 day&delivery_report=1&priority=0"), System.Net.HttpWebRequest)
                request.Method = "POST"
                request.ContentLength = 0
                Dim responseContent As String
                Using response = TryCast(request.GetResponse(), System.Net.HttpWebResponse)
                    Using reader = New System.IO.StreamReader(response.GetResponseStream())
                        responseContent = reader.ReadToEnd()
                    End Using
                End Using
            Next
        End If

    End Sub
    Protected Function getMaxCert() As Double
        Try
            Dim maxCert As Double = 0
            cmd = New SqlCommand("select max(cert) as maxCert from mast", cn)
            If (cn.State = ConnectionState.Open) Then
                cn.Close()
            End If
            cn.Open()
            maxCert = CDbl(cmd.ExecuteScalar())
            cn.Close()
            Return maxCert
        Catch ex As Exception

        End Try
    End Function

    Protected Function sharesValid(cds As String, shares As Double) As Boolean
        Try
            Dim availShares As Double = 0
            cmd = New SqlCommand("select isnull(SUM(Shares),0) as Shares from trans where CDS_Number='" & cds & "'", cn)
            If (cn.State = ConnectionState.Open) Then
                cn.Close()
            End If
            cn.Open()
            availShares = CDbl(cmd.ExecuteScalar())
            cn.Close()
            If availShares - shares >= 0 Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False

        End Try
    End Function

    Protected Function isInMast(cds As String) As Boolean
        Try
            Dim cdsNo As String = ""
            cmd = New SqlCommand("select isnull(cds_number,'') as cds_number from mast where CDS_Number='" & cds & "'", cn)
            If (cn.State = ConnectionState.Open) Then
                cn.Close()
            End If
            cn.Open()
            cdsNo = cmd.ExecuteScalar().ToString
            cn.Close()
            If Trim(cdsNo) <> "" Then
                Return True
            Else
                Return False
            End If

        Catch ex As Exception
            Return False
        End Try
    End Function

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        MOVESHARES()
        GetMaturedRec()
        Getsells()
        finish()
        Session("finish") = "yes"
        Response.Redirect(Request.RawUrl)
    End Sub

    Public Sub TestAirtelMessage()
        ' Dim request = TryCast(System.Net.WebRequest.Create("/send?message_from=AKIBA&message_to=254736812921&message_body=Fari is Testing...Confirm This Message please&delivery_time=1 day&delivery_report=1&priority=0"), System.Net.HttpWebRequest)
        Dim request = TryCast(System.Net.WebRequest.Create("http://45.55.246.121:8083/api/send?id=m6brnkdgdhti7kc6d3ea&secret=cdd065d4a323f21d097521348864ccdc&message_from=mAKIBA&message_to=" & customernumber & "&message_body=" & customermessage & "&delivery_time=1 day&delivery_report=1&priority=0"), System.Net.HttpWebRequest)

        request.Method = "POST"

        'request.Headers.Add("account_id", "m6brnkdgdhti7kc6d3ea")
        'request.Headers.Add("account_secre", "cdd065d4a323f21d097521348864ccdc")

        request.ContentLength = 0
        Dim responseContent As String
        Using response = TryCast(request.GetResponse(), System.Net.HttpWebResponse)
            Using reader = New System.IO.StreamReader(response.GetResponseStream())
                responseContent = reader.ReadToEnd()
            End Using
        End Using
        '  Return "" 'responseContent
    End Sub
End Class
