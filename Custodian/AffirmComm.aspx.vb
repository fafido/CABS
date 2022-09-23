Partial Class AffirmComm

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


    Public Sub Getapendingaffirmation()

        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select ps.CDS_AC_No as [SellerCDS],pb.CDS_AC_No as [BuyerCDS], F.Quantity, F.Price,'KG' as UnitofMeasure,  f.company  as [grade],SUBSTRING(f.company,0, CHARINDEX('/',f.company))  as Company, f.ID as [traderef], f.sellorder, f.buyorder, date_matched, f.BuyCharges, f.SellCharges  from cds_router.dbo.finsec_order_reception_comm f, testcds_ROUTER.dbo.Pre_Order_Live ps, testcds_ROUTER.dbo.Pre_Order_Live pb where f.Affirmed is NULL and  f.buyorder=pb.BrokerRef and f.sellorder=ps.BrokerRef ", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "Permissions")
            If (ds.Tables(0).Rows.Count > 0) Then
                Gridview1.DataSource = ds
                Gridview1.DataBind()
            Else
                Gridview1.DataSource = Nothing
                Gridview1.DataBind()
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Page.MaintainScrollPositionOnPostBack = True
            If (Not IsPostBack) Then


                Getapendingaffirmation()
                processcharges()


            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub



    Protected Sub GridView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Gridview1.SelectedIndexChanged
        Dim buyordernumber As String = Gridview1.SelectedRow.Cells(7).Text
        Dim sellordernumber As String = Gridview1.SelectedRow.Cells(8).Text
        Dim quantity As Decimal = Gridview1.SelectedRow.Cells(2).Text
        Dim price As Decimal = Gridview1.SelectedRow.Cells(3).Text
        Dim company As String = Gridview1.SelectedRow.Cells(4).Text
        Dim val As Decimal = quantity * price

        'processcharges("BUY", val, buyordernumber, company)
        'processcharges("SELL", val, sellordernumber, company)

        Dim chargeamount As String = 0

        Dim buymsg As String = "8=FIXT.1.19=33135=834=849=FIX_GATEWAY52=20180718-09:18:13.22956=ESCROUTER1128=71=180625032933-000111=" + Gridview1.SelectedRow.Cells(6).Text + "14=" + Gridview1.SelectedRow.Cells(2).Text + "17=6031=" + Gridview1.SelectedRow.Cells(3).Text + "37=6038=3039=240=244=" + Gridview1.SelectedRow.Cells(3).Text + "54=155=" + Gridview1.SelectedRow.Cells(4).Text + "59=060=20180718-09:18:13150=F151=0167=CS198=81537453=3448=180625032933-0001447=D452=3448=EFESZWHX447=D452=1448=CBCSZWHX447=D452=4527=427341093=210=11423000=" + chargeamount + "23100=BUY"
        Dim sellmsg As String = "8=FIXT.1.19=33135=834=849=FIX_GATEWAY52=20180718-09:18:13.22956=ESCROUTER1128=71=180625032933-000111=" + Gridview1.SelectedRow.Cells(7).Text + "14=" + Gridview1.SelectedRow.Cells(2).Text + "17=6031=" + Gridview1.SelectedRow.Cells(3).Text + "37=6038=3039=240=244=" + Gridview1.SelectedRow.Cells(3).Text + "54=155=" + Gridview1.SelectedRow.Cells(4).Text + "59=060=20180718-09:18:13150=F151=0167=CS198=81537453=3448=180625032933-0001447=D452=3448=EFESZWHX447=D452=1448=CBCSZWHX447=D452=4527=427341093=210=11423000=" + chargeamount + "23100=SELL"


        cmd = New SqlCommand("insert into [CDS_ROUTER].[dbo].[MessageLog] ([TimeStamp], [Message], Processed) values (getdate(),'" + buymsg + "','0')  insert into [CDS_ROUTER].[dbo].[MessageLog] ([TimeStamp], [Message], Processed) values (getdate(),'" + sellmsg + "','0')", cn)
        If (cn.State = ConnectionState.Open) Then
            cn.Close()
        End If
        cn.Open()
        cmd.ExecuteNonQuery()
        cn.Close()

        cmd = New SqlCommand("UPDATE  [CDS_ROUTER].[dbo].[finsec_order_reception_comm] SET MessageCreated='1', Affirmed='1' WHERE ID='" + Gridview1.SelectedValue.ToString + "'", cn)
        If (cn.State = ConnectionState.Open) Then
            cn.Close()
        End If
        cn.Open()
        cmd.ExecuteNonQuery()
        cn.Close()

        Getapendingaffirmation()
        msgbox("Deal Successfully affirmed!")
        '  msgbox(Gridview1.SelectedRow.Cells(0).Text)
    End Sub

    Public Sub processcharges()
        Dim ds As New DataSet
        cmd = New SqlCommand("select * from cds_router.dbo.finsec_order_reception_comm where BuyCharges is NULL and SellCharges is NULL ", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "Permissions")
        If (ds.Tables(0).Rows.Count > 0) Then
            For I As Integer = 0 To ds.Tables(0).Rows.Count - 1
                Dim ref As String = ds.Tables(0).Rows(I).Item("id")
                Dim buyordernum As String = ds.Tables(0).Rows(I).Item("buyorder")
                Dim sellordernum As String = ds.Tables(0).Rows(I).Item("sellorder")
                Dim price As Decimal = ds.Tables(0).Rows(I).Item("price")
                Dim quant As Decimal = ds.Tables(0).Rows(I).Item("quantity")
                Dim company As String = ds.Tables(0).Rows(I).Item("quantity")
                Dim va As Decimal = price * quant

                Dim buycharge As Decimal = billorder(ordernumber:=buyordernum, dealvalue:=va, processtype:="BUYER", securitytype:=sectype_(company).ToString)
                Dim sellcharge As Decimal = billorder(ordernumber:=sellordernum, dealvalue:=va, processtype:="SELLER", securitytype:=sectype_(company).ToString)
                updatecharged(buycharge, sellcharge, ref)

            Next

        End If






    End Sub
    Public Sub updatecharged(buycharge As String, sellcharge As String, id As String)
        cmd = New SqlCommand("update  [CDS_ROUTER].[dbo].[finsec_order_reception_comm] set BuyCharges='" + buycharge + "', SellCharges='" + sellcharge + "' where id='" + id + "'", cn)
        If (cn.State = ConnectionState.Open) Then
            cn.Close()
        End If
        cn.Open()
        cmd.ExecuteNonQuery()
        cn.Close()
    End Sub
    Public Function billorder(ordernumber As String, dealvalue As Decimal, processtype As String, securitytype As String) As Decimal
        Dim connectionString2 As String = constr
        Dim sql2 As String = "select * from cds_router.dbo.para_billing where (ApplyTo='BOTH' or ApplyTo='" + processtype + "') and Security_Type='" + securitytype + "'"
        Dim connection2 As New SqlConnection(connectionString2)
        Dim dataadapter2 As New SqlDataAdapter(sql2, connection2)
        Dim ds1 As New DataSet()
        ds1.Clear()
        connection2.Open()
        dataadapter2.Fill(ds1, "start2")
        connection2.Close()

        If ds1.Tables("start2").Rows.Count > 0 Then
            Dim totalcharge As Decimal
            For i As Integer = 0 To ds1.Tables("start2").Rows.Count - 1
                Dim chargename As String = ds1.Tables("start2").Rows(i).Item("Chargecode")
                Dim percentage As Decimal = ds1.Tables("start2").Rows(i).Item("PercentageOrValue") / 100
                totalcharge = percentage * dealvalue

                totalcharge += +totalcharge

            Next
            Return totalcharge
        Else
            Return 0
        End If
    End Function
    'Public Sub inserttocharges(Transactioncode As String, chargename As String, totalcharges As String)
    '    cmd = New SqlCommand("insert into cds_router.dbo.TransactionCharges (transactionCode, chargecode, Charges, [Date]) values ('" + Transactioncode + "','" + chargename + "','" + totalcharges + "',getdate())", cn)
    '    If (cn.State = ConnectionState.Open) Then
    '        cn.Close()
    '    End If
    '    cn.Open()
    '    cmd.ExecuteNonQuery()
    '    cn.Close()
    'End Sub
    Public Function sectype_(company As String) As String
        Dim connectionString2 As String = constr
        Dim sql2 As String = "select ISNULL(sec_type,'') AS sec_type from cds_router.dbo.para_company where company='" + company + "'"
        Dim connection2 As New SqlConnection(connectionString2)
        Dim dataadapter2 As New SqlDataAdapter(sql2, connection2)
        Dim ds1 As New DataSet()
        ds1.Clear()
        connection2.Open()
        dataadapter2.Fill(ds1, "start2")
        connection2.Close()

        If ds1.Tables("start2").Rows.Count > 0 Then
            Return ds1.Tables("start2").Rows(0).Item("sec_type")
        Else
            Return "EQUITY"
        End If
    End Function
End Class

