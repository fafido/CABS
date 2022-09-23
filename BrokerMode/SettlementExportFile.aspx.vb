Imports System.Windows.Forms
Imports System.IO
Imports System.Threading

Partial Class BrokerMode_SettlementExportFile
    Inherits System.Web.UI.Page
    Dim constr As String = (System.Configuration.ConfigurationManager.AppSettings("connpath"))
    Dim cn As New SqlConnection(constr)
    Dim cmd As SqlCommand
    Dim adp As SqlDataAdapter
    Dim shinda As Threading.Thread
    Public Sub MyThreadTest()
        Try
            Do
                Threading.Thread.Sleep(1000)
                Label5.Text = Label5.Text + 1
            Loop
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

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Page.MaintainScrollPositionOnPostBack = True
            '  MovingOrders()
            If (Not IsPostBack) Then
                Try
                    If (Session("Brokercode") = Nothing) Then
                        Response.Redirect("~\Loginsystem.aspx")
                    End If
                    shinda = New Threading.Thread(AddressOf MyThreadTest)
                    shinda.Start()
                    cmd = New SqlCommand("insert into UserActivityLog (UserName,Activity,TimeOfActivity,DateDone,CompanyCode) values ('" & Session("Username") & "','Accessed Trades Export File Creation Form','" & Date.Now & "','" & Now.Date & "','" & Session("BrokerCode") & "')", cn)
                    If (cn.State = ConnectionState.Open) Then
                        cn.Close()
                    End If
                    cn.Open()
                    cmd.ExecuteNonQuery()
                    cn.Close()
                    '     GetOrdersLoad()
                    '   MovingOrders()
                    '  GetMaturedRec()
                    Call Button1_Click(Nothing, EventArgs.Empty)

                Catch ex As Exception
                    msgbox(ex.Message)
                End Try

                LDGRD()

            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
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
                    SettlementDate = CDate(ds.Tables(0).Rows(i).Item("trade").ToString).AddDays(0)
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



                    cmd = New SqlCommand("update tbl_matchedOrders set AccountsStatus='C' where deal=" & ds.Tables(0).Rows(i).Item("deal").ToString & "", cn)
                    If (cn.State = ConnectionState.Open) Then
                        cn.Close()
                    End If
                    cn.Open()
                    cmd.ExecuteNonQuery()
                    cn.Close()


                Next

                '   msgbox("Settlements Ready For Authorization")

            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub GetMaturedRec()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select * from tbl_SettlementSummary where settlement_date <='" & Now.Date & "' and status_flag='O'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "tbl_SettlementSummary")
            If (ds.Tables(0).Rows.Count > 0) Then
                Dim i As Integer = 0
                For i = 0 To ds.Tables(0).Rows.Count - 1

                    If (ds.Tables(0).Rows(i).Item("OrderType").ToString = "S") Then
                        If sharesValid(ds.Tables(0).Rows(i).Item("cds_number"), ds.Tables(0).Rows(i).Item("Quantity")) Then
                            cmd = New SqlCommand("insert into trans (company, cds_number, date_created,trans_time, shares, update_type, created_by, batch_ref, source, pledge_shares, Reference) values ('" & ds.Tables(0).Rows(i).Item("company").ToString & "','" & ds.Tables(0).Rows(i).Item("cds_number").ToString & "','" & Now.Date & "','" & Now.TimeOfDay.ToString & "'," & CInt(ds.Tables(0).Rows(i).Item("Quantity").ToString) * -1 & ",'DEAL','SETTLEMENT',0,'D',0,'" & ds.Tables(0).Rows(i).Item("deal_reference").ToString & "')", cn)
                            If (cn.State = ConnectionState.Open) Then
                                cn.Close()
                            End If
                            cn.Open()
                            cmd.ExecuteNonQuery()
                            cn.Close()
                            'mast update
                            Dim cmdMast As New SqlCommand
                            'If isInMast(ds.Tables(0).Rows(i).Item("cds_number")) Then
                            'cmdMast = New SqlCommand("update mast set Shares=Shares-" & ds.Tables(0).Rows(i).Item("Quantity") & ",Reference='" & ds.Tables(0).Rows(i).Item("deal_reference").ToString & "' where CDS_Number='" & ds.Tables(0).Rows(i).Item("cds_number") & "'", cn)
                            ''Else
                            ''    cmdMast = New SqlCommand("insert into mast ([company],[CDS_Number],[Date_Created],[Shares],[Update_Type],[Pladge],[Pledge_Shares],[Created_By],[Updated_On],[Updated_By],[Locked],[Lock_Reason],[Batch_Ref],[SecType],[cert],[Reference]) values ('" & ds.Tables(0).Rows(i).Item("company").ToString & "','" & ds.Tables(0).Rows(i).Item("cds_number").ToString & "','" & ds.Tables(0).Rows(i).Item("Settlement_date").ToString & "'," & ds.Tables(0).Rows(i).Item("Quantity") * -1 & ",'DEAL','0','0','SETTLEMENT',GETDATE(),'" & Session("UserName") & "','0','-','0','0'," & getMaxCert() + 1 & ",'" & ds.Tables(0).Rows(i).Item("deal_reference").ToString & "')", cn)
                            ''End If
                            'If (cn.State = ConnectionState.Open) Then
                            '    cn.Close()
                            'End If
                            'cn.Open()
                            'cmdMast.ExecuteNonQuery()
                            'cn.Close()

                        Else
                            'Shares not available
                        End If
                    End If
                    If (ds.Tables(0).Rows(i).Item("OrderType").ToString = "B") Then
                        cmd = New SqlCommand("insert into trans (company, cds_number, date_created,trans_time ,shares, update_type, created_by, batch_ref, source, pledge_shares,Reference) values ('" & ds.Tables(0).Rows(i).Item("company").ToString & "','" & ds.Tables(0).Rows(i).Item("cds_number").ToString & "','" & Now.Date & "','" & Now.TimeOfDay.ToString & "'," & CInt(ds.Tables(0).Rows(i).Item("Quantity").ToString) & ",'DEAL','SETTLEMENT',0,'D',0,'" & ds.Tables(0).Rows(i).Item("deal_reference").ToString & "')", cn)
                        If (cn.State = ConnectionState.Open) Then
                            cn.Close()
                        End If
                        cn.Open()
                        cmd.ExecuteNonQuery()
                        cn.Close()
                        'mast update
                        Dim cmdMast As New SqlCommand
                        'If isInMast(ds.Tables(0).Rows(i).Item("cds_number")) Then
                        '    cmdMast = New SqlCommand("update mast set Shares=Shares+" & ds.Tables(0).Rows(i).Item("Quantity") & ",Reference='" & ds.Tables(0).Rows(i).Item("deal_reference").ToString & "' where CDS_Number='" & ds.Tables(0).Rows(i).Item("cds_number") & "'", cn)
                        'Else
                        '    cmdMast = New SqlCommand("insert into mast ([company],[CDS_Number],[Date_Created],[Shares],[Update_Type],[Pladge],[Pledge_Shares],[Created_By],[Updated_On],[Updated_By],[Locked],[Lock_Reason],[Batch_Ref],[SecType],[cert],[Reference]) values ('" & ds.Tables(0).Rows(i).Item("company").ToString & "','" & ds.Tables(0).Rows(i).Item("cds_number").ToString & "','" & ds.Tables(0).Rows(i).Item("Settlement_date").ToString & "','" & ds.Tables(0).Rows(i).Item("Quantity").ToString & "','DEAL','0','0','SETTLEMENT',GETDATE(),'SETTLEMENT','0','-','0','0'," & getMaxCert() + 1 & ",'" & ds.Tables(0).Rows(i).Item("deal_reference").ToString & "')", cn)
                        'End If
                        'If (cn.State = ConnectionState.Open) Then
                        '    cn.Close()
                        'End If
                        'cn.Open()
                        'cmdMast.ExecuteNonQuery()
                        'cn.Close()
                    End If

                    cmd = New SqlCommand("update tbl_SettlementSummary set status_flag='C' where deal_reference='" & ds.Tables(0).Rows(i).Item("deal_reference").ToString & "' and cds_number='" & ds.Tables(0).Rows(i).Item("cds_number").ToString & "'", cn)
                    If (cn.State = ConnectionState.Open) Then
                        cn.Close()
                    End If
                    cn.Open()
                    cmd.ExecuteNonQuery()
                    cn.Close()
                Next
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
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
            cmd = New SqlCommand("select isnull(SUM(Shares),0) as Shares from mast where CDS_Number='" & cds & "'", cn)
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
    Public Sub TransactSettledOrders()
        Try

        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub GetOrdersLoad()
        Try
            Dim ds As New DataSet
            'cmd = New SqlCommand("select * from ordersSummary where PurchasingBroker='" & Session("BrokerCode").ToString & "' and status='O' and ApprovalFlag=1", cn)
            cmd = New SqlCommand("select * from tbl_SettlementSummary where Eft_File_Status='O' and tbl_SettlementSummary .OrderType ='S'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "tbl_SettlementSummary")
            btnSelect.Enabled = False
            If (ds.Tables(0).Rows.Count > 0) Then
                txtFileName.Text = Session("BrokerCode").ToString & "" & DateString.ToString.Replace("-", "")
                'btnSelect.Enabled = True
                Button1.Enabled = True
                lblFileloadstatus.Text = "You have " & ds.Tables(0).Rows.Count & " orders ready for export."
                lblFileloadstatus.ForeColor = Drawing.Color.Green
            Else
                lblFileloadstatus.Text = "No ready orders for export"
                lblFileloadstatus.ForeColor = Drawing.Color.Red
                'btnSelect.Enabled = False
                Button1.Enabled = False

            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub msgbox(ByVal strMessage As String)
        'finishes server processing, returns to client.
        Dim strScript As String = "<script language=JavaScript>"
        strScript += "window.alert(""" & strMessage & """);"
        strScript += "</script>"
        Dim lbl As New System.Web.UI.WebControls.Label
        lbl.Text = strScript
        Page.Controls.Add(lbl)

    End Sub

    Protected Sub btnSelect_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSelect.Click
        Try
            If (txtFileName.Text = "") Then
                msgbox("Enter a valid export file name")
                Exit Sub
            End If

            Dim res As New DataSet
            Dim i As Integer = 0
            Dim EFT As New DataSet
            Dim OrderRef As String = ""
            Dim OrderNum As String = ""
            Dim company As String = ""
            Dim holdernum As String = ""
            Dim orderQuant As String = ""
            Dim orderVal As Double
            Dim orderType As String = ""
            Dim orderDate As String = ""
            Dim Broker As String = ""
            Dim holder As String = ""
            Dim holdername As String = ""
            Dim amount As String = ""
            Dim comp As String = ""
            Dim bank As String = ""
            Dim branch As String = ""
            Dim acc As String = ""
            Dim pdate As String = ""
            Dim line As String = ""
            Dim file As New DataSet
            Dim fname As String = ""
            Dim shareholder As String = ""
            Dim taxcode As String = ""
            Dim transTyp As String = ""
            Dim trns As String = ""
            Dim basePrice As String = ""
            Dim orderAtt As String = ""
            Dim dealdate As String = ""
            Dim targetdate As String = ""
            Dim expdate As String = ""
            Dim TRanTpye As String = ""
            Dim OrderPref As String = ""
            Dim rex As New DataSet
            cmd = New SqlCommand("select count (OrderRef) as orders from ordersSummary where purchasingbroker='" & Session("BrokerCode").ToString & "' and status='O'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(rex, "ordersSummary")

            'Dim filecmd As New SqlCommand("select * from ordersSummary where orderdate>='" & BasicDatePicker1.Text & "' and orderdate <= '" & BasicDatePicker2.Text & "' and status='C'", cn)
            Dim filecmd As New SqlCommand("select * from ordersSummary where purchasingbroker='" & Session("BrokerCode").ToString & "' and status='O'", cn)
            Dim fileadp As New SqlDataAdapter(filecmd)
            Dim tempAmt As String = ""
            fileadp.Fill(file, "OrdersSummary")
            fname = txtFileName.Text + ".txt"
            Dim iRowNo As Integer
            Dim txAmt As String
            line = Left("ORDER FILE" & Space(11), 11) & Left(txtFileName.Text & Space(14), 14) & Left(rex.Tables(0).Rows(0).Item("Orders").ToString.PadLeft(4, " "c) & Space(4), 4) & Left(" RECORDS" & Space(8), 8) & vbCrLf
            iRowNo = 0
            If (file.Tables(0).Rows.Count > 0) Then
                For i = 0 To file.Tables(0).Rows.Count - 1
                    Dim ros As New DataSet
                    cmd = New SqlCommand("select * from names where cds_number ='" & file.Tables(0).Rows(i).Item("cds_number").ToString & "'", cn)
                    adp = New SqlDataAdapter(cmd)
                    adp.Fill(ros, "names")


                    orderAtt = (file.Tables(0).Rows(i).Item("OrderAttribute").ToString.PadLeft(3, " "c))
                    If (file.Tables(0).Rows(i).Item("OrderType").ToString = "PUR") Then
                        TRanTpye = "BUY"

                    End If
                    If (file.Tables(0).Rows(i).Item("OrderType").ToString = "SAL") Then
                        TRanTpye = "SELL"

                    End If
                    'transTyp = (file.Tables(0).Rows(i).Item("OrderType").ToString.PadLeft(4, " "c))
                    transTyp = (TRanTpye.ToString.PadLeft(4, " "c))

                    'trns = (file.Tables(0).Rows(i).Item("OrderType").ToString.PadLeft(1, " "c))
                    trns = ("E".ToString.PadLeft(1, " "c))
                    shareholder = ((ros.Tables(0).Rows(0).Item("surname").ToString & "" & ros.Tables(0).Rows(0).Item("forenames").ToString).ToString.PadLeft(30, " "c))
                    taxcode = ros.Tables(0).Rows(0).Item("tax").ToString.PadLeft(2, "0"c)
                    OrderRef = (file.Tables(0).Rows(i).Item("OrderRef").ToString.PadLeft(6, "0"c))
                    holdernum = CStr(file.Tables(0).Rows(i).Item("cds_number").ToString.PadLeft(13, " "c))
                    OrderNum = (file.Tables(0).Rows(i).Item("OrderNumber").ToString.PadLeft(6, "0"c))
                    txAmt = file.Tables(0).Rows(i).Item("OrderValue").ToString
                    txAmt = Left(file.Tables(0).Rows(i).Item("OrderValue"), InStrRev(file.Tables(0).Rows(i).Item("OrderValue"), ".") + 2)
                    txAmt = Replace(txAmt, ".", "")
                    orderVal = txAmt.PadLeft(12, "0"c)
                    orderQuant = (file.Tables(0).Rows(i).Item("Order_Quantity").ToString).PadLeft(6, " "c)
                    basePrice = (file.Tables(0).Rows(i).Item("BasePrice").ToString).PadLeft(12, " "c)
                    orderType = file.Tables(0).Rows(i).Item("OrderType").ToString.PadLeft(3, "0"c)
                    Broker = file.Tables(0).Rows(i).Item("PurchasingBroker").ToString.PadLeft(8, " "c)
                    comp = file.Tables(0).Rows(i).Item("company").ToString.PadLeft(6, " "c)
                    orderDate = file.Tables(0).Rows(i).Item("OrderDate")
                    dealdate = CDate(file.Tables(0).Rows(i).Item("OrderDate").ToString.PadLeft(10, " "c))
                    targetdate = CDate((file.Tables(0).Rows(i).Item("TargetDate").ToString.PadLeft(10, " "c)))
                    expdate = CDate((file.Tables(0).Rows(i).Item("ExpiryDate").ToString.PadLeft(10, " "c)))
                    OrderPref = (file.Tables(0).Rows(i).Item("OrderPreference").ToString.PadLeft(1, " "c))

                    iRowNo = i + 1
                    'line = line + Left("ORD" & Space(3), 3) & Left(OrderRef & Space(6), 6) & Left(holdernum & Space(8), 8) & Left(OrderNum & Space(6), 6) & Left(orderQuant & Space(10), 10) & orderVal & Left(orderType & Space(3), 3) & Left(comp & Space(6), 6) & Left(Broker & Space(8), 8) & Left(orderDate & Space(8), 8)
                    'line = line + Left(transTyp & Space(4), 4) & Left(comp & Space(6), 6) & Left(Left(trns, 1) & Space(1), 1) & Left(Broker & Space(8), 8) & Left(taxcode & Space(2), 2) & Left(holdernum & Space(13), 13) & Left(shareholder & Space(30), 30) & Left(orderQuant & Space(6), 6) & Left(basePrice & Space(12), 12) & Left(orderAtt & Space(4), 4) & Left(dealdate & Space(10), 10) & Left(targetdate & Space(10), 10) & Left(expdate & Space(10), 10)
                    'msgbox(Left(expdate & Space(10), 10))

                    line = line + Left(transTyp & Space(4), 4) & Left(comp & Space(6), 6) & Left(Left(trns, 1) & Space(1), 1) & Left(Broker & Space(8), 8) & Left(taxcode & Space(2), 2) & Left(holdernum & Space(13), 13) & Left(shareholder & Space(30), 30) & Left(orderQuant & Space(6), 6) & Left(basePrice & Space(12), 12) & Left(OrderPref & Space(1), 1) & Left("IOC" & Space(3), 3) & Left(orderAtt & Space(3), 3) & Left(dealdate & Space(10), 10) & Left(targetdate & Space(10), 10) & Left(expdate & Space(10), 10)

                    My.Computer.FileSystem.WriteAllText("C:\" & fname, line & vbCrLf, True)
                    line = ""
                Next
                My.Computer.FileSystem.WriteAllText("C:\" & fname, line & vbCrLf, True)

                cmd = New SqlCommand("update ordersSummary set status='C' where purchasingbroker='" & Session("BrokerCode").ToString & "' and status='O'", cn)
                If (cn.State = ConnectionState.Open) Then
                    cn.Close()
                End If
                cn.Open()
                cmd.ExecuteNonQuery()
                cn.Close()
                cmd = New SqlCommand("insert into UserActivityLog (UserName,Activity,TimeOfActivity,DateDone,CompanyCode) values ('" & Session("Username") & "','Created a trades export file','" & Date.Now & "','" & Now.Date & "','" & Session("BrokerCode") & "')", cn)
                If (cn.State = ConnectionState.Open) Then
                    cn.Close()
                End If
                cn.Open()
                cmd.ExecuteNonQuery()
                cn.Close()
                msgbox("Electronic file exported successfully")
            Else
                msgbox("no data to export in the trades section for the specified period")
                Exit Sub
            End If

        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    '    Public Sub bulkimport()
    '        BULK()
    '        INSERT(CSVTest)
    '        FROM() 'c:\csvtest.txt'
    'WITH
    '(
    'FIELDTERMINATOR = ',',
    'ROWTERMINATOR = '\n'
    ')
    '            GO()
    '--Check the content of the table.
    'SELECT *
    'FROM CSVTest
    'GO
    '--Drop the table to clean up database.
    'DROP TABLE CSVTest
    'GO
    '    End Sub
    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        'exportCsv()

        'ExportExcel()
        'NewCsv()

        Dim ds As New DataSet

        ''''cmd = New SqlCommand("select OrdersSummary.OrderNumber, OrdersSummary.OrderType, OrdersSummary.Company, 'E' as SecurityType,OrdersSummary.PurchasingBroker , 10 as TaxType, OrdersSummary.cds_number ,names.Surname +' '+names.Forenames  as shareholdername,  OrdersSummary.Order_Quantity, OrdersSummary.BasePrice , OrdersSummary.OrderPreference , OrdersSummary.OrderQualifier as [ORDERQUALIFIER], OrdersSummary.orderAttribute as TIMEFORCE, convert(varchar, OrdersSummary.OrderDate,120) as createdate,CONVERT(varchar, OrdersSummary.TargetDate,101) as targetdate ,CONVERT(varchar, OrdersSummary.ExpiryDate,101) as expirydate from OrdersSummary, names where names.CDS_Number = OrdersSummary.CDS_Number and OrdersSummary .ApprovalFlag =0 and Updated=0  order by OrderRef desc", cn)
        ''''cmd = New SqlCommand("select OrdersSummary.OrderNumber, OrdersSummary.OrderType, OrdersSummary.Company, 'E' as SecurityType,OrdersSummary.PurchasingBroker , 10 as TaxType, OrdersSummary.cds_number ,left(names.Surname +' '+names.Forenames,20)  as shareholdername,  OrdersSummary.Order_Quantity, OrdersSummary.BasePrice , OrdersSummary.OrderPreference , OrdersSummary.OrderQualifier as [ORDERQUALIFIER], OrdersSummary.orderAttribute as TIMEFORCE, convert(varchar, OrdersSummary.OrderDate,120) as createdate,convert(varchar, OrdersSummary.OrderDate,120) as targetdate ,CONVERT(varchar, OrdersSummary.ExpiryDate,101) as expirydate from OrdersSummary, names where names.CDS_Number = OrdersSummary.CDS_Number and OrdersSummary .ApprovalFlag =0 and Updated=0  order by OrderRef desc", cn)

        'cmd = New SqlCommand("select OrdersSummary.OrderNumber, OrdersSummary.OrderType, OrdersSummary.Company, 'E' as SecurityType,OrdersSummary.PurchasingBroker , 10 as TaxType, OrdersSummary.cds_number ,'CDS ACCOUNT HOLDER'  as shareholdername,  OrdersSummary.Order_Quantity, OrdersSummary.BasePrice , OrdersSummary.OrderPreference , OrdersSummary.OrderQualifier as [ORDERQUALIFIER], OrdersSummary.orderAttribute as TIMEFORCE, convert(varchar, OrdersSummary.OrderDate,120) as createdate,convert(varchar, OrdersSummary.OrderDate,120) as targetdate ,CONVERT(varchar, OrdersSummary.ExpiryDate,101) as expirydate from OrdersSummary, names where names.CDS_Number = OrdersSummary.CDS_Number and OrdersSummary .ApprovalFlag =0 and Updated=0  order by OrderRef desc", cn)
        '   cmd = New SqlCommand("select convert(varchar,tbl_SettlementSummary.Settlement_date,120) as settlement_date, (select top 1 trading_branch from client_companies where company_code=(select top 1 BrokerCode from Accounts_Clients where cds_number=tbl_SettlementSummary.cds_number)) as [Div_branch],(select top 1 trading_account from client_companies where company_code=(select top 1 BrokerCode from Accounts_Clients where cds_number=tbl_SettlementSummary.cds_number)) as [Div_accountno], (select top 1 trading_account_name from client_companies where company_code=(select top 1 BrokerCode from Accounts_Clients where cds_number=tbl_SettlementSummary.cds_number)) as [Accountname], (select top 1 main_branch from client_companies where company_code=(select top 1 BrokerCode from Accounts_Clients where cds_number=(select top 1 cds_number from tbl_SettlementSummary where ordertype='S' AND RIGHT(DEAL_REFERENCE,LEN(deal_reference)-2)=RIGHT(tbl_SettlementSummary.DEAL_REFERENCE,LEN(tbl_SettlementSummary.deal_reference)-2)))) as [to_branch],(select top 1 main_account from client_companies where company_code=(select top 1 BrokerCode from Accounts_Clients where cds_number=(select top 1 cds_number from tbl_SettlementSummary where ordertype='S' AND RIGHT(DEAL_REFERENCE,LEN(deal_reference)-2)=RIGHT(tbl_SettlementSummary.DEAL_REFERENCE,LEN(tbl_SettlementSummary.deal_reference)-2)))) as [to_ACCOUNTNo],(select top 1 main_account_name from client_companies where company_code=(select top 1 BrokerCode from Accounts_Clients where cds_number=(select top 1 cds_number from tbl_SettlementSummary where ordertype='S' AND RIGHT(DEAL_REFERENCE,LEN(deal_reference)-2)=RIGHT(tbl_SettlementSummary.DEAL_REFERENCE,LEN(tbl_SettlementSummary.deal_reference)-2)))) as [to_ACCOUNTname], tbl_SettlementSummary.Amount_due, 'USD' as usd  from tbl_SettlementSummary , Accounts_Clients where tbl_SettlementSummary .cds_number = Accounts_Clients.CDS_Number and tbl_SettlementSummary .OrderType ='B' AND Eft_File_Status='O' ", cn)

        ' cmd = New SqlCommand("select getdate() as [Date], (select  trading_branch from client_companies where company_code=(select  BrokerCode from Accounts_Clients where cds_number=mo.buyercdsno)) as [From Branch], (select  trading_account from client_companies where company_code=(select  BrokerCode from Accounts_Clients where cds_number=mo.buyercdsno)) as [From Account No],(select  trading_account_name  from client_companies where company_code=(select  BrokerCode from Accounts_Clients where cds_number=mo.buyercdsno)) as [From Account Name], (select  trading_branch from client_companies where company_code=(select  BrokerCode from Accounts_Clients where cds_number=mo.Sellercdsno)) as [To Branch], (select  trading_account from client_companies where company_code=(select  BrokerCode from Accounts_Clients where cds_number=mo.Sellercdsno)) as [To Account No],(select  trading_account_name  from client_companies where company_code=(select  BrokerCode from Accounts_Clients where cds_number=mo.Sellercdsno)) as [To Account Name], ss.Amount_due as [Amount], 'USD' as [USD]   from tbl_matchedorders mo, tbl_SettlementSummary ss where right(ss.deal_reference, LEN(SS.deal_reference)-2)=convert(varchar(30),mo.deal) and ss.OrderType ='B' AND ss.Eft_File_Status='O'", cn)
        cmd = New SqlCommand("select convert(date, getdate()) as [Date], (select branch from para_branch where bank=(select bank from para_bank where bank_name=(select div_bank from Accounts_Clients where CDS_Number=tbl_units_move.fromcdsnumber)) and branch_name=(select Div_Branch from Accounts_Clients where CDS_Number=tbl_units_move.fromcdsnumber)) as Branch, (select div_accountno from Accounts_Clients where CDS_Number=tbl_units_move.fromcdsnumber) as [Account No],  (select DivPayee from Accounts_Clients where CDS_Number=tbl_units_move.fromcdsnumber) as [Account Name], Amount, 'USD' as [Currency],'Settlement' as [Description] from tbl_units_move order by id desc", cn)



        ''''cmd = New SqlCommand("select OrderNumber, OrderType, Company from OrdersSummary", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "tbl_SettlementSummary")

        If (ds.Tables(0).Rows.Count > 0) Then
            grdData1.DataSource = ds.Tables(0)
            grdData1.DataBind()
            grdData1.Visible = True
        Else
            msgbox("No orders to export")
        End If

        'cmd = New SqlCommand("Update tbl_SettlementSummary set Eft_File_Status= 'C' where Eft_File_Status= 'O' ", cn)
        'If (cn.State = ConnectionState.Open) Then
        '    cn.Close()
        'End If
        'cn.Open()
        'cmd.ExecuteNonQuery()
        'cn.Close()

        Csv1()
        '    GetOrdersLoad()
    End Sub
    Public Sub LDGRD()

        Dim ds As New DataSet

        ''''cmd = New SqlCommand("select OrdersSummary.OrderNumber, OrdersSummary.OrderType, OrdersSummary.Company, 'E' as SecurityType,OrdersSummary.PurchasingBroker , 10 as TaxType, OrdersSummary.cds_number ,names.Surname +' '+names.Forenames  as shareholdername,  OrdersSummary.Order_Quantity, OrdersSummary.BasePrice , OrdersSummary.OrderPreference , OrdersSummary.OrderQualifier as [ORDERQUALIFIER], OrdersSummary.orderAttribute as TIMEFORCE, convert(varchar, OrdersSummary.OrderDate,120) as createdate,CONVERT(varchar, OrdersSummary.TargetDate,101) as targetdate ,CONVERT(varchar, OrdersSummary.ExpiryDate,101) as expirydate from OrdersSummary, names where names.CDS_Number = OrdersSummary.CDS_Number and OrdersSummary .ApprovalFlag =0 and Updated=0  order by OrderRef desc", cn)
        ''''cmd = New SqlCommand("select OrdersSummary.OrderNumber, OrdersSummary.OrderType, OrdersSummary.Company, 'E' as SecurityType,OrdersSummary.PurchasingBroker , 10 as TaxType, OrdersSummary.cds_number ,left(names.Surname +' '+names.Forenames,20)  as shareholdername,  OrdersSummary.Order_Quantity, OrdersSummary.BasePrice , OrdersSummary.OrderPreference , OrdersSummary.OrderQualifier as [ORDERQUALIFIER], OrdersSummary.orderAttribute as TIMEFORCE, convert(varchar, OrdersSummary.OrderDate,120) as createdate,convert(varchar, OrdersSummary.OrderDate,120) as targetdate ,CONVERT(varchar, OrdersSummary.ExpiryDate,101) as expirydate from OrdersSummary, names where names.CDS_Number = OrdersSummary.CDS_Number and OrdersSummary .ApprovalFlag =0 and Updated=0  order by OrderRef desc", cn)

        'cmd = New SqlCommand("select OrdersSummary.OrderNumber, OrdersSummary.OrderType, OrdersSummary.Company, 'E' as SecurityType,OrdersSummary.PurchasingBroker , 10 as TaxType, OrdersSummary.cds_number ,'CDS ACCOUNT HOLDER'  as shareholdername,  OrdersSummary.Order_Quantity, OrdersSummary.BasePrice , OrdersSummary.OrderPreference , OrdersSummary.OrderQualifier as [ORDERQUALIFIER], OrdersSummary.orderAttribute as TIMEFORCE, convert(varchar, OrdersSummary.OrderDate,120) as createdate,convert(varchar, OrdersSummary.OrderDate,120) as targetdate ,CONVERT(varchar, OrdersSummary.ExpiryDate,101) as expirydate from OrdersSummary, names where names.CDS_Number = OrdersSummary.CDS_Number and OrdersSummary .ApprovalFlag =0 and Updated=0  order by OrderRef desc", cn)
        '   cmd = New SqlCommand("select getdate() as [Date], (select  trading_branch from client_companies where company_code=(select  BrokerCode from Accounts_Clients where cds_number=mo.buyercdsno)) as [From Branch], (select  trading_account from client_companies where company_code=(select  BrokerCode from Accounts_Clients where cds_number=mo.buyercdsno)) as [From Account No],(select  trading_account_name  from client_companies where company_code=(select  BrokerCode from Accounts_Clients where cds_number=mo.buyercdsno)) as [From Account Name], (select  trading_branch from client_companies where company_code=(select  BrokerCode from Accounts_Clients where cds_number=mo.Sellercdsno)) as [To Branch], (select  trading_account from client_companies where company_code=(select  BrokerCode from Accounts_Clients where cds_number=mo.Sellercdsno)) as [To Account No],(select  trading_account_name  from client_companies where company_code=(select  BrokerCode from Accounts_Clients where cds_number=mo.Sellercdsno)) as [To Account Name], ss.Amount_due as [Amount], 'USD' as [USD]   from tbl_matchedorders mo, tbl_SettlementSummary ss where right(ss.deal_reference, LEN(SS.deal_reference)-2)=convert(varchar(30),mo.deal) and ss.OrderType ='B' AND ss.Eft_File_Status='O'", cn)

        cmd = New SqlCommand("select convert(date, getdate()) as [Date], (select branch from para_branch where bank=(select bank from para_bank where bank_name=(select div_bank from Accounts_Clients where CDS_Number=tbl_units_move.fromcdsnumber)) and branch_name=(select Div_Branch from Accounts_Clients where CDS_Number=tbl_units_move.fromcdsnumber)) as Branch, (select div_accountno from Accounts_Clients where CDS_Number=tbl_units_move.fromcdsnumber) as [Account No],  (select DivPayee from Accounts_Clients where CDS_Number=tbl_units_move.fromcdsnumber) as [Account Name], Amount, 'USD' as [Currency],'Settlement' as [Description] from tbl_units_move order by id desc", cn)


        ''''cmd = New SqlCommand("select OrderNumber, OrderType, Company from OrdersSummary", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "tbl_SettlementSummary")

        If (ds.Tables(0).Rows.Count > 0) Then
            grdData1.DataSource = ds.Tables(0)
            grdData1.DataBind()
            grdData1.Visible = True
        Else
            msgbox("No orders to export")
        End If


    End Sub
    Public Sub exportCsv()
        Try
            Dim ds As New DataSet
            Dim grdData As New GridView
            cmd = New SqlCommand("select OrderNumber, OrderType, Company, 'E' as SecurityType,PurchasingBroker , 10 as TaxType, cds_number , 'testname' as shareholdername,  Order_Quantity as [shares], BasePrice , OrderPreference ,'IOC' AS [ORDERQUALIFIER], orderAttribute as TIMEFORCE,OrderDate as createdate,TargetDate , ExpiryDate     from OrdersSummary", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "OrdersSummary")
            If (ds.Tables(0).Rows.Count > 0) Then
                grdData.DataSource = ds.Tables(0)
                grdData.DataBind()

                Dim strexport As String = ""
                For Each c As DataGridColumn In grdData.Columns
                    strexport &= """" & c.HeaderText & ""","
                    strexport = strexport.Substring(0, strexport.Length - 1)
                    strexport &= Environment.NewLine

                    For Each R As DataGridViewRow In grdData.Rows
                        For Each ci As DataGridViewCell In R.Cells
                            If Not ci.Value Is Nothing Then
                                strexport &= """" & ci.Value.ToString & ""","
                            Else
                                'strexport &= """" & "" & ""","
                            End If
                        Next
                        strexport = strexport.Substring(0, strexport.Length - 1)
                        strexport &= Environment.NewLine
                    Next

                Next
                Dim tw As IO.TextWriter = New IO.StreamWriter("j:\RAJ.CSV")
                msgbox("File Saved")
                tw.Write(strexport)
                tw.Close()
            End If

        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Public Sub ExportExcel()
        Try
            Dim ds As New DataSet
            Dim grdData As New GridView
            cmd = New SqlCommand("select OrderNumber, OrderType, Company, 'E' as SecurityType,PurchasingBroker , 10 as TaxType, cds_number , 'testname' as shareholdername,  Order_Quantity as [shares], BasePrice , OrderPreference ,'IOC' AS [ORDERQUALIFIER], orderAttribute as TIMEFORCE,OrderDate as createdate,TargetDate , ExpiryDate     from OrdersSummary", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "OrdersSummary")

            If (ds.Tables(0).Rows.Count > 0) Then
                grdData.DataSource = ds.Tables(0)
                grdData.DataBind()

                If (grdData.Rows.Count > 0) Then
                    Response.ClearContent()
                    Response.AddHeader("content-disposition", String.Format("attachment; filename={0}", "orders1.csv"))
                    Response.ContentType = "application/text"
                    grdData.AllowPaging = False

                    Dim strbldr As New StringBuilder
                    'For i = 0 To grdData.Columns.Count - 1
                    '    strbldr.Append(grdData.Columns(i).HeaderText & ",")
                    'Next
                    'strbldr.Append("\n")
                    For j = 0 To grdData.Rows.Count - 1
                        For k = 0 To grdData.Columns.Count - 1
                            strbldr.Append(grdData.Rows(j).Cells(k).Text & ",")
                        Next
                        'strbldr.Append("\n")
                    Next

                    Response.Write(strbldr.ToString)
                    Response.End()
                End If

            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub NewCsv()
        Try
            Dim strDelimiterType As String = ","
            Dim blnWriteColumnHeaderNames As Boolean = False
            Dim ds As New DataSet
            Dim grdData As New DataGridView
            cmd = New SqlCommand("select OrderNumber, OrderType, Company, 'E' as SecurityType,PurchasingBroker , 10 as TaxType, cds_number , 'testname' as shareholdername,  Order_Quantity as [shares], BasePrice , OrderPreference ,'IOC' AS [ORDERQUALIFIER], orderAttribute as TIMEFORCE,OrderDate as createdate,TargetDate , ExpiryDate     from OrdersSummary", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "OrdersSummary")

            grdData.DataSource = ds.Tables(0)
            'grdData.DataBind()


            Dim sr As StreamWriter = File.CreateText("Orderscsv")
            Dim strDelimiter As String = strDelimiterType
            Dim intColumnCount As Integer = grdData.Columns.Count - 1
            Dim strRowData As String = ""

            If blnWriteColumnHeaderNames Then
                For intX As Integer = 0 To intColumnCount
                    strRowData += Replace(grdData.Columns(intX).Name, strDelimiter, "") & IIf(intX < intColumnCount, strDelimiter, "")
                Next intX
                sr.WriteLine(strRowData)
            End If

            For intX As Integer = 0 To grdData.Rows.Count - 1
                strRowData = ""
                For intRowData As Integer = 0 To intColumnCount
                    strRowData += Replace(grdData.Rows(intX).Cells(intRowData).Value, strDelimiter, "") & IIf(intRowData < intColumnCount, strDelimiter, "") '''''''''highlights this row
                Next intRowData
                sr.WriteLine(strRowData)
            Next intX
            sr.Close()
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub Csv1()
        Try
            'Dim ds As New DataSet
            'cmd = New SqlCommand("select OrderNumber, OrderType, Company, 'E' as SecurityType,PurchasingBroker , 10 as TaxType, cds_number , 'testname' as shareholdername,  Order_Quantity as [shares], BasePrice , OrderPreference ,'IOC' AS [ORDERQUALIFIER], orderAttribute as TIMEFORCE,OrderDate as createdate,TargetDate , ExpiryDate     from OrdersSummary", cn)
            'adp = New SqlDataAdapter(cmd)
            'adp.Fill(ds, "OrdersSummary")

            'If (ds.Tables(0).Rows.Count > 0) Then
            '    grdData1.DataSource = ds.Tables(0)
            '    grdData1.DataBind()
            'End If

            Response.Clear()

            Response.Buffer = True

            Response.AddHeader("content-disposition", "attachment;filename=" & Now.Date & "Settlement_Eft_File.csv")
            Response.Charset = ""
            Response.ContentType = "application/text"
            grdData1.AllowPaging = False
            grdData1.DataBind()

            Dim sb As New StringBuilder()

            For k As Integer = 0 To grdData1.Columns.Count - 1

                'add separator

                sb.Append(grdData1.Columns(k).HeaderText + ","c)

            Next

            'append new line

            sb.Append(vbCr & vbLf)

            For i As Integer = 0 To grdData1.Rows.Count - 1

                For k As Integer = 0 To grdData1.Columns.Count - 1

                    'add separator

                    sb.Append(grdData1.Rows(i).Cells(k).Text + ","c)

                Next

                'append new line

                sb.Append(vbCr & vbLf)

            Next

            Response.Output.Write(sb.ToString())

            Response.Flush()

            Response.End()
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            Dim str As String = ""
            str = TextBox1.Text
            msgbox(str.Length)
            msgbox((str.Substring(20, str.Length - 20)))
            'msgbox(TextBox1.Text.Substring(15, 17))
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
End Class
