Partial Class TransferSec_settledrecords
    Inherits System.Web.UI.Page
    Dim constr As String = (System.Configuration.ConfigurationManager.AppSettings("connpath"))
    Dim cn As New SqlConnection(constr)
    Dim adp As SqlDataAdapter
    Dim cmd As SqlCommand
    Public allrec As String
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
            cmd = New SqlCommand("select trans.company as Company,(select top 1 company_name from Client_Companies where company_code=(select top 1 BrokerCode from Accounts_Clients where cds_number=trans.CDS_Number)) as Broker,  trans.CDS_Number, Accounts_Clients.Surname+' '+Accounts_Clients .Forenames as [Client],CONVERT(VARCHAR(11),getdate(),106) as [Date],case when SUM(SHARES)<0 then sum(shares)*-1 else sum(shares)*-1 end as [Amount(Ksh)],replace(CAST(CONVERT(varchar, CAST(sum(shares) AS money), 1) AS varchar),'.00','') as [Units]   from trans, Accounts_Clients   where  trans.Created_by ='SETTLEMENT' and trans.CDS_Number = Accounts_Clients.CDS_Number and trans.Date_Created between '" + txtDateFrom.Text + "' and '" + txtDateFrom0.Text + "'   group by Accounts_Clients.Surname , Accounts_Clients .Forenames , trans.CDS_Number, trans.company,trans.date_created,trans.trans_time     order by trans.date_created desc, trans.trans_time desc", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "tbl_MatchedOrders")
            If (ds.Tables(0).Rows.Count > 0) Then
                grdsellers.DataSource = ds.Tables(0)
                grdsellers.DataBind()

            Else
                grdsellers.DataSource = Nothing
                grdsellers.DataBind()
                msgbox("No Records")
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
                'getpendingauth()


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



                    cmd = New SqlCommand("update tbl_matchedOrders set AccountsStatus='C' where deal=" & ds.Tables(0).Rows(i).Item("deal").ToString & "", cn)
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
    Public Sub GetMaturedRec()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select * from tbl_SettlementSummary where settlement_date <='" & Now.Date & "' and status_flag='O' " + allrec + "", cn)
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
                            cmdMast = New SqlCommand("update mast set Shares=Shares-" & ds.Tables(0).Rows(i).Item("Quantity") & ",Reference='" & ds.Tables(0).Rows(i).Item("deal_reference").ToString & "' where CDS_Number='" & ds.Tables(0).Rows(i).Item("cds_number") & "'", cn)
                            'Else
                            '    cmdMast = New SqlCommand("insert into mast ([company],[CDS_Number],[Date_Created],[Shares],[Update_Type],[Pladge],[Pledge_Shares],[Created_By],[Updated_On],[Updated_By],[Locked],[Lock_Reason],[Batch_Ref],[SecType],[cert],[Reference]) values ('" & ds.Tables(0).Rows(i).Item("company").ToString & "','" & ds.Tables(0).Rows(i).Item("cds_number").ToString & "','" & ds.Tables(0).Rows(i).Item("Settlement_date").ToString & "'," & ds.Tables(0).Rows(i).Item("Quantity") * -1 & ",'DEAL','0','0','SETTLEMENT',GETDATE(),'" & Session("UserName") & "','0','-','0','0'," & getMaxCert() + 1 & ",'" & ds.Tables(0).Rows(i).Item("deal_reference").ToString & "')", cn)
                            'End If
                            If (cn.State = ConnectionState.Open) Then
                                cn.Close()
                            End If
                            cn.Open()
                            cmdMast.ExecuteNonQuery()
                            cn.Close()

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
                        If isInMast(ds.Tables(0).Rows(i).Item("cds_number")) Then
                            cmdMast = New SqlCommand("update mast set Shares=Shares+" & ds.Tables(0).Rows(i).Item("Quantity") & ",Reference='" & ds.Tables(0).Rows(i).Item("deal_reference").ToString & "' where CDS_Number='" & ds.Tables(0).Rows(i).Item("cds_number") & "'", cn)
                        Else
                            cmdMast = New SqlCommand("insert into mast ([company],[CDS_Number],[Date_Created],[Shares],[Update_Type],[Pladge],[Pledge_Shares],[Created_By],[Updated_On],[Updated_By],[Locked],[Lock_Reason],[Batch_Ref],[SecType],[cert],[Reference]) values ('" & ds.Tables(0).Rows(i).Item("company").ToString & "','" & ds.Tables(0).Rows(i).Item("cds_number").ToString & "','" & ds.Tables(0).Rows(i).Item("Settlement_date").ToString & "','" & ds.Tables(0).Rows(i).Item("Quantity").ToString & "','DEAL','0','0','SETTLEMENT',GETDATE(),'SETTLEMENT','0','-','0','0'," & getMaxCert() + 1 & ",'" & ds.Tables(0).Rows(i).Item("deal_reference").ToString & "')", cn)
                        End If
                        If (cn.State = ConnectionState.Open) Then
                            cn.Close()
                        End If
                        cn.Open()
                        cmdMast.ExecuteNonQuery()
                        cn.Close()
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

   
    Protected Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If txtDateFrom.Text <> "" And txtDateFrom0.Text <> "" Then
            getpendingauth()
        Else
            msgbox("Please select the Opening date and the closing date!")
        End If


    End Sub
End Class
