
Imports System.Linq

Partial Class Regulator_surve
    Inherits System.Web.UI.Page
    Dim cnstr As String = (System.Configuration.ConfigurationManager.AppSettings("connpath2"))
    Dim conCds = (System.Configuration.ConfigurationManager.AppSettings("connpath"))
    Dim cnCds As New SqlConnection(conCds)

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
    Public Sub getmarketactivity()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("SELECT A.Activity AS [Activity], A.ActivityDate, A.IpAddress as [IP Address], a.PageUrl 	FROM ActivityLog A INNER JOIN ATS_UserManagement B	ON A.Uid = B.Uid WHERE  Activity LIKE '%Order%' 	ORDER BY A.ActivityDate DESC ", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "ordersSummary")
            If (ds.Tables(0).Rows.Count > 0) Then
                grdOrdersSummary5.DataSource = ds
                grdOrdersSummary5.DataBind()

            Else
                grdOrdersSummary5.DataSource = Nothing
                grdOrdersSummary5.DataBind()
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub getsellorders()
        Try
            Dim ext As String
            If ASPxDateEdit3.Text <> "" And ASPxDateEdit4.Text <> "" Then
                ext = "and Inserted_datetime between '" + ASPxDateEdit3.Text + " 00:00' and '" + ASPxDateEdit4.Text + " 23:59'"
            Else
                ext = ""
            End If

            Dim ds As New DataSet
            cmd = New SqlCommand("select orderno, broker_code as [Broker], shareholder as [Investor] ,company as [Counter],  BasePrice as [Price], quantity as [Quantity],  convert(numeric(18,2),Quantity*BasePrice)  as [Value], Inserted_datetime as [Date]  from testcds.dbo.Audit_Order_Posted_Log where ordertype='SELL' and Inserted_datetime>='01 Dec 2016 00:00' " + ext + " order by Inserted_datetime desc", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "ordersSummary")
            If (ds.Tables(0).Rows.Count > 0) Then
                grdOrdersSummary9.DataSource = ds
                grdOrdersSummary9.DataBind()
            Else
                grdOrdersSummary9.DataSource = Nothing
                grdOrdersSummary9.DataBind()
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub getmatchedunsettled()
        Try
            Dim ext As String
            If ASPxDateEdit5.Text <> "" And ASPxDateEdit6.Text <> "" Then
                ext = "and trade between '" + ASPxDateEdit5.Text + " 00:00' and '" + ASPxDateEdit6.Text + " 23:59'"
            Else
                ext = ""
            End If

            Dim ds As New DataSet
            cmd = New SqlCommand("select deal as [Deal ID], Buycompany as [Company], Buyercdsno as [Buyer CDS], Sellercdsno as [Seller CDS], Quantity,DealPrice as [Price], convert(numeric(18,2),Dealprice*Quantity) as [Value], Trade as [Date], 'Matched' as [Status] from testcds.dbo.tbl_matcheddeals where trade>='01 Dec 2016 00:00' " + ext + " order by deal desc", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "ordersSummary")
            If (ds.Tables(0).Rows.Count > 0) Then
                grdOrdersSummary10.DataSource = ds
                grdOrdersSummary10.DataBind()

            Else
                grdOrdersSummary10.DataSource = Nothing
                grdOrdersSummary10.DataBind()
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub getbuyorders()
        Try
            Dim ext As String
            If ASPxDateEdit1.Text <> "" And ASPxDateEdit2.Text <> "" Then
                ext = "and Inserted_datetime between '" + ASPxDateEdit1.Text + " 00:00' and '" + ASPxDateEdit2.Text + " 23:59'"
            Else
                ext = ""
            End If
            Dim ds As New DataSet
            cmd = New SqlCommand("select orderno, broker_code as [Broker], shareholder as [Investor] ,company as [Counter], baseprice as [Price], quantity as [Quantity], case baseprice when '0.00'  then convert(numeric(18,2),Quantity*(select initialprice from testcds.dbo.para_company where company=testcds.dbo.Audit_Order_Posted_Log.Company)) else convert(numeric(18,2),Quantity*BasePrice)   end as [Value], Inserted_datetime as [Date] from testcds.dbo.Audit_Order_Posted_Log where ordertype='BUY' and Inserted_datetime>='01 Dec 2016 00:00' " + ext + "  order by Inserted_datetime desc", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "ordersSummary")
            If (ds.Tables(0).Rows.Count > 0) Then
                grdOrdersSummary0.DataSource = ds
                grdOrdersSummary0.DataBind()

            Else
                grdOrdersSummary0.DataSource = Nothing
                grdOrdersSummary0.DataBind()
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        getbuyorders()
        getsellorders()
        getmatchedunsettled()
        getmarketactivity()
        getmarketviewer()
        getsettlement()
        getsettlementpurchase()
        getsettlementrejected()
        getsettlementcharges()

        If IsPostBack Then
            getTheCharges()
            GetTheLevies()
        Else
            GetChargeCode()
        End If
    End Sub
    Public Sub getLevies()


        Dim datefrom = ASPxDateEdit13.Text
        Dim dateto = ASPxDateEdit14.Text

        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select Company_Code, Company_name,      isnull((Select SUM(TRADEQTY) from tblMatchedOrders where Broker1=CC.COMPANY_CODE and Ack !='FAILED' and Date_posted between convert(date,'" + datefrom + "') and convert(date,'" + dateto + "')), 0) as [Buy Volume], isnull((SELECT SUM(TRADEQTY*TradePrice) FROM tblMatchedOrders WHERE Broker1=CC.COMPANY_CODE and Ack !='FAILED' and Date_posted between convert(date,'" + datefrom + "') and convert(date,'" + dateto + "')),0) as [Buy Value],   isnull((SELECT SUM(TRADEQTY) FROM tblMatchedOrders WHERE Broker2=CC.COMPANY_CODE and Ack !='FAILED' and Date_posted between convert(date,'" + datefrom + "') and convert(date,'" + dateto + "')),0) as [Sell Volume],   isnull((SELECT SUM(TRADEQTY*TradePrice) FROM tblMatchedOrders WHERE Broker2=CC.COMPANY_CODE and Ack !='FAILED' and Date_posted between convert(date,'" + datefrom + "') and convert(date,'" + dateto + "')),0) as [Sell Value],    isnull((SELECT count(Id) FROM tblMatchedOrders WHERE Broker1=CC.COMPANY_CODE and Ack !='FAILED' and Date_posted between convert(date,'" + datefrom + "') and convert(date,'" + dateto + "')),0) as [Number of Buy Trades],    isnull((SELECT count(Id) FROM tblMatchedOrders WHERE Broker2=CC.COMPANY_CODE and Ack !='FAILED' and Date_posted between convert(date,'" + datefrom + "') and convert(date,'" + dateto + "')),0) as [Number of Sell Trades],  isnull((select sum(BuyCharges) from [CDS].[dbo].[TransactionCharges] where transactionCode in     (select Id from tblMatchedOrders where (Broker1=CC.COMPANY_CODE and Ack !='FAILED')  and Date_posted between convert(date,'" + datefrom + "') and convert(date,'" + dateto + "')) and [ChargeCode]='SECZ Levy') , 0) +isnull((select sum(SellCharges) from [CDS].[dbo].[TransactionCharges] where transactionCode in     (select Id from tblMatchedOrders where (broker2=CC.COMPANY_CODE and Ack !='FAILED') and Date_posted between convert(date,'" + datefrom + "') and convert(date,'" + dateto + "')) and [ChargeCode]='SECZ Levy') , 0) as [SECZ Levy] --, isnull((select sum(SellCharges) from [CDS].[dbo].[TransactionCharges] where transactionCode in --    (select Id from tblMatchedOrders where (broker2=CC.COMPANY_CODE and Ack !='FAILED') and Date_posted between convert(date,'" + datefrom + "') and convert(date,'" + datefrom + "')) and [ChargeCode]='SECZ Levy') --, 0) as [Sell SECZ Levy] ,isnull((select sum(BuyCharges)  from [CDS].[dbo].[TransactionCharges] where transactionCode in   (select Id from tblMatchedOrders where (Broker1=CC.COMPANY_CODE  and Ack !='FAILED') and Date_posted between convert(date,'" + datefrom + "') and convert(date,'" + dateto + "')) and [ChargeCode]='VAT') , 0) +isnull((select  sum(SellCharges) from [CDS].[dbo].[TransactionCharges] where transactionCode in   (select Id from tblMatchedOrders where (broker2=CC.COMPANY_CODE and Ack !='FAILED') and Date_posted between convert(date,'" + datefrom + "') and convert(date,'" + dateto + "')) and [ChargeCode]='VAT') , 0) as [VAT], isnull((select sum(BuyCharges)  from [CDS].[dbo].[TransactionCharges] where transactionCode in   (select Id from tblMatchedOrders where (Broker1=CC.COMPANY_CODE and Ack !='FAILED')  and Date_posted between convert(date,'" + datefrom + "') and convert(date,'" + dateto + "')) and [ChargeCode]='Capital gains with holding Tax') , 0) + isnull((select sum(SellCharges) from [CDS].[dbo].[TransactionCharges] where transactionCode in   (select Id from tblMatchedOrders where  (broker2=CC.COMPANY_CODE and Ack !='FAILED') and Date_posted between convert(date,'" + datefrom + "') and convert(date,'" + dateto + "')) and [ChargeCode]='Capital gains with holding Tax') , 0)  as [CGT TAX],  isnull((select sum(BuyCharges)  from [CDS].[dbo].[TransactionCharges] where transactionCode in   (select Id from tblMatchedOrders where (Broker1=CC.COMPANY_CODE and Ack !='FAILED')  and Date_posted between convert(date,'" + datefrom + "') and convert(date,'" + dateto + "')) and [ChargeCode]='Investor Protection Levy') , 0) + isnull((select sum(SellCharges) from [CDS].[dbo].[TransactionCharges] where transactionCode in  (select Id from tblMatchedOrders where  (broker2=CC.COMPANY_CODE and Ack !='FAILED') and Date_posted between convert(date,'" + datefrom + "') and convert(date,'" + dateto + "')) and [ChargeCode]='Investor Protection Levy') , 0) as [Investor Levy], isnull((select sum(BuyCharges) from [CDS].[dbo].[TransactionCharges] where transactionCode in   (select Id from tblMatchedOrders where (Broker1=CC.COMPANY_CODE and Ack !='FAILED')  and Date_posted between convert(date,'" + datefrom + "') and convert(date,'" + dateto + "')) and [ChargeCode]='Brokerage fees') , 0)+isnull((select  sum(SellCharges) from [CDS].[dbo].[TransactionCharges] where transactionCode in  (select Id from tblMatchedOrders where  (broker2=CC.COMPANY_CODE and Ack !='FAILED') and Date_posted between convert(date,'" + datefrom + "') and convert(date,'" + dateto + "')) and [ChargeCode]='Brokerage fees') , 0) as [Brokerage Levy], isnull((select sum(BuyCharges)  from [CDS].[dbo].[TransactionCharges] where transactionCode in  (select Id from tblMatchedOrders where (Broker1=CC.COMPANY_CODE and Ack !='FAILED')  and Date_posted between convert(date,'" + datefrom + "') and convert(date,'" + dateto + "')) and [ChargeCode]='Stamp duty') , 0) + isnull((select sum(SellCharges) from [CDS].[dbo].[TransactionCharges] where transactionCode in   (select Id from tblMatchedOrders where  (broker2=CC.COMPANY_CODE and Ack !='FAILED') and Date_posted between convert(date,'" + datefrom + "') and convert(date,'" + dateto + "')) and [ChargeCode]='Stamp duty') , 0) as [Stamp Duty],  isnull((select sum(BuyCharges)  from [CDS].[dbo].[TransactionCharges] where transactionCode in  (select Id from tblMatchedOrders where (Broker1=CC.COMPANY_CODE and Ack !='FAILED')  and Date_posted between convert(date,'" + datefrom + "') and convert(date,'" + dateto + "')) and [ChargeCode]='Settlement Levy') , 0) +  isnull((select sum(SellCharges) from [CDS].[dbo].[TransactionCharges] where transactionCode in  (select Id from tblMatchedOrders where  (broker2=CC.COMPANY_CODE and Ack !='FAILED') and Date_posted between convert(date,'" + datefrom + "') and convert(date,'" + dateto + "')) and [ChargeCode]='Settlement Levy') , 0)as [ZSE Levy],  isnull((select sum(BuyCharges)  from [CDS].[dbo].[TransactionCharges] where transactionCode in  (select Id from tblMatchedOrders where (Broker1=CC.COMPANY_CODE and Ack !='FAILED') and Date_posted between convert(date,'" + datefrom + "') and convert(date,'" + dateto + "')) and [ChargeCode]='Platform Levy') , 0) + isnull((select sum(SellCharges) from [CDS].[dbo].[TransactionCharges] where transactionCode in   (select Id from tblMatchedOrders where  (broker2=CC.COMPANY_CODE and Ack !='FAILED')  and Date_posted between convert(date,'" + datefrom + "') and convert(date,'" + dateto + "')) and [ChargeCode]='Platform Levy') , 0) as [CSD Levy] , isnull((select sum(BuyCharges)  from [CDS].[dbo].[TransactionCharges] where transactionCode in  (select Id from tblMatchedOrders where (Broker1=CC.COMPANY_CODE and Ack !='FAILED') and Date_posted between convert(date,'" + datefrom + "') and convert(date,'" + dateto + "'))) , 0) + isnull((select sum(SellCharges) from [CDS].[dbo].[TransactionCharges] where transactionCode in  (select Id from tblMatchedOrders where  (broker2=CC.COMPANY_CODE and Ack !='FAILED') and Date_posted between convert(date,'" + datefrom + "') and convert(date,'" + dateto + "'))) , 0) as [Total] from client_companies CC where cOMPANY_type='BROKER' and (isnull((select sum(BuyCharges)  from [CDS].[dbo].[TransactionCharges] where transactionCode in  (select Id from tblMatchedOrders where (Broker1=CC.COMPANY_CODE and Ack !='FAILED') and Date_posted between convert(date,'" + datefrom + "') and convert(date,'" + dateto + "'))) , 0) + isnull((select sum(SellCharges) from [CDS].[dbo].[TransactionCharges] where transactionCode in  (select Id from tblMatchedOrders where  (broker2=CC.COMPANY_CODE and Ack !='FAILED') and Date_posted between convert(date,'" + datefrom + "') and convert(date,'" + dateto + "'))) , 0))>0", cn)

            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "ordersSummary")
            If (ds.Tables(0).Rows.Count > 0) Then
                grdOrdersSummary16.DataSource = ds
                grdOrdersSummary16.DataBind()

            Else
                grdOrdersSummary16.DataSource = Nothing
                grdOrdersSummary16.DataBind()
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub



    Public Sub getmarketviewer()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("   Select Company, Lastmatched as [Last Traded Price], lastvolume as [Last Volume Traded], TotalVolume as [Volume Traded], Turnover, [Open], High, Low, convert(numeric(18,2),[Average Price]) as [Price (VWA)], Change, convert(numeric(18,2),(select Issued_shares from para_company where company=j.company)*[Average Price]) as [Market Capitalization]  from (select Company,(select bestprice from companyprices where company=marketwatcher.company) as [Last Traded Price], isnull((select top 1 dealprice from tbl_matcheddeals where BuyCompany=marketwatcher.company and trade=convert(date,getdate()) order by id desc),0) as [Lastmatched],isnull((select top 1 Quantity from tbl_matcheddeals where BuyCompany=marketwatcher.company and trade=convert(date,getdate()) order by id desc),0) as [lastvolume], isnull((select sum(Quantity) from tbl_matcheddeals where BuyCompany=marketwatcher.company And trade=convert(date,getdate())),0) as [TotalVolume] ,isnull((select sum(Quantity*DealPrice) from tbl_matcheddeals where BuyCompany=marketwatcher.company And trade=convert(date,getdate())),0) as [Turnover], (select top 1 OpeningPrice from CompanyPrices where company=marketwatcher.company) as [Open],isnull((select  max(DealPrice) from tbl_matcheddeals where BuyCompany= marketwatcher.company and trade=convert(date,getdate())),0) as [High],isnull((select  min(DealPrice) from tbl_matcheddeals where BuyCompany= marketwatcher.company and trade=convert(date,getdate())),0) as [Low], (select top 1 BestPrice from CompanyPrices where company=marketwatcher.company) as [Average Price],(select top 1 bestprice from CompanyPrices where company=marketwatcher.company) - (select top 1 OpeningPrice from CompanyPrices where company=marketwatcher.company) as [Change],((select top 1 bestprice from CompanyPrices where company=marketwatcher.company) - (select top 1 OpeningPrice from CompanyPrices where company=marketwatcher.company))/(select top 1 openingprice from CompanyPrices where company=marketwatcher.company)*100 as [percchange]     from testcds.dbo.marketwatcher) j", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "ordersSummary")
            If (ds.Tables(0).Rows.Count > 0) Then
                grdOrdersSummary11.DataSource = ds
                grdOrdersSummary11.DataBind()

            Else
                grdOrdersSummary11.DataSource = Nothing
                grdOrdersSummary11.DataBind()
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub getsettlement()
        Try
            Dim ext As String
            If ASPxDateEdit9.Text <> "" And ASPxDateEdit10.Text <> "" Then
                ext = "and date_posted between '" + ASPxDateEdit9.Text + " 00:00' and '" + ASPxDateEdit10.Text + " 23:59'"
            Else
                ext = ""
            End If

            Dim ds As New DataSet
            cmd = New SqlCommand("Select *,(select top 1 deal from cds.dbo.tbl_units_move where id=cds.dbo.tblmatchedorders.reportid) as dealnr, tradeqty*tradeprice as [Value],isnull((select sum(SellCharges) from cds.dbo.transactioncharges where transactionCode=cds.dbo.tblmatchedorders.id),0) as [Charges], (select top 1 Surname+' '+isnull(forenames,'') from cds.dbo.accounts_clients where cds_Number=cds.dbo.tblmatchedorders.Account2) as name, tradeqty*tradeprice-isnull((select sum(SellCharges) from cds.dbo.transactioncharges where transactionCode=cds.dbo.tblmatchedorders.id),0) as [Net],case when BankSent='1' AND Ack is null THEN 'SENT TO BANK' when banksent='0' then 'PENDING SETTLEMENT' when Error_details is not null then 'FAILED' when ack='SETTLED' Then 'SETTLED'  end as [Status],cds.dbo.DAYSADDNOWK(Date_posted, 5) as [T4] from cds.dbo.tblmatchedorders where (sellaffirm='1' or sellaffirm is null)  and Date_posted>='01 Dec 2016' " + ext + " order by reportid desc", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "ordersSummary")
            If (ds.Tables(0).Rows.Count > 0) Then
                grdOrdersSummary12.DataSource = ds
                grdOrdersSummary12.DataBind()

            Else
                grdOrdersSummary12.DataSource = Nothing
                grdOrdersSummary12.DataBind()
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub getsettlementpurchase()
        Try
            Dim ext As String
            If ASPxDateEdit11.Text <> "" And ASPxDateEdit12.Text <> "" Then
                ext = "and date_posted between '" + ASPxDateEdit11.Text + " 00:00' and '" + ASPxDateEdit12.Text + " 23:59'"
            Else
                ext = ""
            End If

            Dim ds As New DataSet
            cmd = New SqlCommand("Select *,(select top 1 deal from cds.dbo.tbl_units_move where id=cds.dbo.tblmatchedorders.reportid) as dealnr, tradeqty*tradeprice as [Value],isnull((select sum(SellCharges) from cds.dbo.transactioncharges where transactionCode=cds.dbo.tblmatchedorders.id),0) as [Charges], (select top 1 Surname+' '+isnull(forenames,'') from cds.dbo.accounts_clients where cds_Number=cds.dbo.tblmatchedorders.Account1) as name, tradeqty*tradeprice-isnull((select sum(SellCharges) from cds.dbo.transactioncharges where transactionCode=cds.dbo.tblmatchedorders.id),0) as [Net],case when BankSent='1' AND Ack is null THEN 'SENT TO BANK' when banksent='0' then 'PENDING SETTLEMENT' when Error_details is not null then 'FAILED' when ack='SETTLED' Then 'SETTLED'  end as [Status],cds.dbo.DAYSADDNOWK(Date_posted, 5) as [T4] from cds.dbo.tblmatchedorders where (sellaffirm='1' or sellaffirm is null)  and Date_posted>='01 Dec 2016' " + ext + " order by reportid desc", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "ordersSummary")
            If (ds.Tables(0).Rows.Count > 0) Then
                grdOrdersSummary13.DataSource = ds
                grdOrdersSummary13.DataBind()

            Else
                grdOrdersSummary13.DataSource = Nothing
                grdOrdersSummary13.DataBind()
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub getsettlementrejected()
        Try
            Dim ext As String
            If ASPxDateEdit13.Text <> "" And ASPxDateEdit14.Text <> "" Then
                ext = "and date_posted between '" + ASPxDateEdit13.Text + " 00:00' and '" + ASPxDateEdit14.Text + " 23:59'"
            Else
                ext = ""
            End If

            Dim ds As New DataSet
            cmd = New SqlCommand("Select *,(select top 1 deal from cds.dbo.tbl_units_move where id=cds.dbo.tblmatchedorders.reportid) as dealnr, tradeqty*tradeprice as [Value],isnull((select sum(SellCharges) from cds.dbo.transactioncharges where transactionCode=cds.dbo.tblmatchedorders.id),0) as [Charges], (select top 1 Surname+' '+isnull(forenames,'') from cds.dbo.accounts_clients where cds_Number=cds.dbo.tblmatchedorders.Account1) as name, tradeqty*tradeprice-isnull((select sum(SellCharges) from cds.dbo.transactioncharges where transactionCode=cds.dbo.tblmatchedorders.id),0) as [Net],case when BankSent='1' AND Ack is null THEN 'SENT TO BANK' when banksent='0' then 'PENDING SETTLEMENT' when Error_details is not null then 'FAILED' when ack='SETTLED' Then 'SETTLED'  end as [Status],cds.dbo.DAYSADDNOWK(Date_posted, 5) as [T4] from cds.dbo.tblmatchedorders where (sellaffirm='1' or sellaffirm is null)  and Date_posted>='01 Dec 2016' AND (buyaffirm='0' or sellaffirm='0') " + ext + " order by reportid desc", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "ordersSummary")
            If (ds.Tables(0).Rows.Count > 0) Then
                grdOrdersSummary14.DataSource = ds
                grdOrdersSummary14.DataBind()

            Else
                grdOrdersSummary14.DataSource = Nothing
                grdOrdersSummary14.DataBind()
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub getsettlementcharges()
        Try
            Dim ext As String
            If ASPxDateEdit15.Text <> "" And ASPxDateEdit16.Text <> "" Then
                ext = "and date_posted between '" + ASPxDateEdit15.Text + " 00:00' and '" + ASPxDateEdit16.Text + " 23:59'"
            Else
                ext = ""
            End If

            Dim ds As New DataSet
            cmd = New SqlCommand("Select *,(select top 1 deal from cds.dbo.tbl_units_move where id=cds.dbo.tblmatchedorders.reportid) as dealnr, tradeqty*tradeprice as [Value],isnull((select sum(SellCharges) from cds.dbo.transactioncharges where transactionCode=cds.dbo.tblmatchedorders.id),0) as [Charges],isnull((select sum(buyCharges) from cds.dbo.transactioncharges where transactionCode=cds.dbo.tblmatchedorders.id),0) as [Buy], (select top 1 Surname+' '+isnull(forenames,'') from cds.dbo.accounts_clients where cds_Number=cds.dbo.tblmatchedorders.Account1) as name, tradeqty*tradeprice-isnull((select sum(SellCharges) from cds.dbo.transactioncharges where transactionCode=cds.dbo.tblmatchedorders.id),0) as [Net],case when BankSent='1' AND Ack is null THEN 'SENT TO BANK' when banksent='0' then 'PENDING SETTLEMENT' when Error_details is not null then 'FAILED' when ack='SETTLED' Then 'SETTLED'  end as [Status],cds.dbo.DAYSADDNOWK(Date_posted, 5) as [T4] from cds.dbo.tblmatchedorders where (sellaffirm='1' or sellaffirm is null)  and Date_posted>='01 Dec 2016' " + ext + " order by reportid desc", cn)

            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "ordersSummary")
            If (ds.Tables(0).Rows.Count > 0) Then
                grdOrdersSummary15.DataSource = ds
                grdOrdersSummary15.DataBind()

            Else
                grdOrdersSummary15.DataSource = Nothing
                grdOrdersSummary15.DataBind()
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub ASPxButton1_Click(sender As Object, e As EventArgs) Handles ASPxButton1.Click
        getbuyorders()

    End Sub

    Protected Sub ASPxButton3_Click(sender As Object, e As EventArgs) Handles ASPxButton3.Click
        getmatchedunsettled()

    End Sub

    Protected Sub ASPxButton5_Click(sender As Object, e As EventArgs) Handles ASPxButton5.Click
        getsettlement()
    End Sub

    Protected Sub ASPxButton8_Click(sender As Object, e As EventArgs) Handles ASPxButton8.Click
        ASPxGridViewExporter1.WriteXlsToResponse()
    End Sub

    Protected Sub ASPxButton9_Click(sender As Object, e As EventArgs) Handles ASPxButton9.Click
        ASPxGridViewExporter2.WriteXlsToResponse()
    End Sub

    Protected Sub ASPxButton10_Click(sender As Object, e As EventArgs) Handles ASPxButton10.Click
        ASPxGridViewExporter3.WriteXlsToResponse()
    End Sub

    Protected Sub ASPxButton11_Click(sender As Object, e As EventArgs) Handles ASPxButton11.Click
        ASPxGridViewExporter4.WriteXlsToResponse()
    End Sub

    Protected Sub ASPxButton12_Click(sender As Object, e As EventArgs) Handles ASPxButton12.Click
        ASPxGridViewExporter5.WriteXlsToResponse()
    End Sub

    Protected Sub ASPxButton13_Click(sender As Object, e As EventArgs) Handles ASPxButton13.Click
        ASPxGridViewExporter6.WriteXlsToResponse()
    End Sub

    Protected Sub ASPxButton14_Click(sender As Object, e As EventArgs) Handles ASPxButton14.Click
        ASPxGridViewExporter7.WriteXlsToResponse()
    End Sub

    Protected Sub ASPxButton6_Click(sender As Object, e As EventArgs) Handles ASPxButton6.Click

    End Sub

    Protected Sub ASPxButton15_Click(sender As Object, e As EventArgs) Handles ASPxButton15.Click
        getsettlementcharges()
    End Sub

    Protected Sub ASPxButton16_Click(sender As Object, e As EventArgs) Handles ASPxButton16.Click
        ASPxGridViewExporter8.WriteXlsToResponse()
    End Sub
    Protected Sub ASPxButton7_Click(sender As Object, e As EventArgs) Handles ASPxButton7.Click
        getLevies()
    End Sub
    Protected Sub ASPxButton20_Click(sender As Object, e As EventArgs) Handles ASPxButton20.Click

        Dim dateFrom = ASPxDateEdit19.Text
        Dim dateTo = ASPxDateEdit20.Text
        Dim adp1 As New SqlDataAdapter
        Dim cmd1 As New SqlCommand
        Dim chargeCode = ""
        If cmbJnationality1.SelectedIndex >= 0 Then
            chargeCode = cmbJnationality1.SelectedItem.ToString().Trim()
        End If
         '   msgbox(dateFrom + "  " + dateTo)


        '   WHERE cds.[dbo].[tblMatchedOrders].Date_posted between convert(date,'" + dateFrom + "') and convert(date,'" + dateTo + "')

        Try
            cmd1 = New SqlCommand("SELECT cds.[dbo].[tblMatchedOrders].ID,   cds.[dbo].[tblMatchedOrders].TradePrice,   cds.[dbo].[tblMatchedOrders].TradeQty,   (cds.[dbo].[tblMatchedOrders].TradePrice * cds.[dbo].[tblMatchedOrders].TradeQty) AS [DealValue],   cds.[dbo].[tblMatchedOrders].CommonRef,   cds.[dbo].[TransactionCharges].ChargeCode,   cds.[dbo].[tblMatchedOrders].Account1,   cds.[dbo].[tblMatchedOrders].Account2,   cds.[dbo].[tblMatchedOrders].Broker1,   cds.[dbo].[tblMatchedOrders].Broker2,   [tblMatchedOrders].Date_posted,  cds.[dbo].[TransactionCharges].BuyCharges,  cds.[dbo].[TransactionCharges].SellCharges,   cds.[dbo].[TransactionCharges].[Date] FROM cds.[dbo].[tblMatchedOrders] JOIN cds.[dbo].[TransactionCharges]   ON [dbo].[tblMatchedOrders].ID = cds.[dbo].[TransactionCharges].transactionCode WHERE cds.[dbo].[tblMatchedOrders].Date_posted between convert(date,'" + dateFrom + "') and convert(date,'" + dateTo + "') and RTRIM(LTRIM(cds.[dbo].[TransactionCharges].[ChargeCode]))='" + chargeCode + "' order by cds.[dbo].[tblMatchedOrders].Date_posted", cnCds)
            Dim ds1 As New DataSet
            adp1 = New SqlDataAdapter(cmd1)
            adp1.Fill(ds1, "chargez")
            If (ds1.Tables(0).Rows.Count > 0) Then
                grdOrdersSummary17.DataSource = ds1
                grdOrdersSummary17.DataBind()
            Else
                grdOrdersSummary17.DataSource = Nothing
                grdOrdersSummary17.DataBind()
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try




    End Sub

    Public Sub getTheCharges()
        Dim dateFrom = ASPxDateEdit19.Text
        Dim dateTo = ASPxDateEdit20.Text
        Dim adp1 As New SqlDataAdapter
        Dim cmd1 As New SqlCommand
        Dim chargeCode = ""
        If cmbJnationality1.SelectedIndex >= 0 Then
            chargeCode = cmbJnationality1.SelectedItem.ToString().Trim()
        Else

        End If



        '   WHERE cds.[dbo].[tblMatchedOrders].Date_posted between convert(date,'" + dateFrom + "') and convert(date,'" + dateTo + "')

        Try
            cmd1 = New SqlCommand("SELECT cds.[dbo].[tblMatchedOrders].ID,   cds.[dbo].[tblMatchedOrders].TradePrice,   cds.[dbo].[tblMatchedOrders].TradeQty,   (cds.[dbo].[tblMatchedOrders].TradePrice * cds.[dbo].[tblMatchedOrders].TradeQty) AS [DealValue],   cds.[dbo].[tblMatchedOrders].CommonRef,   cds.[dbo].[TransactionCharges].ChargeCode,   cds.[dbo].[tblMatchedOrders].Account1,   cds.[dbo].[tblMatchedOrders].Account2,   cds.[dbo].[tblMatchedOrders].Broker1,   cds.[dbo].[tblMatchedOrders].Broker2,   [tblMatchedOrders].Date_posted,  cds.[dbo].[TransactionCharges].BuyCharges, cds.[dbo].[TransactionCharges].SellCharges,  cds.[dbo].[TransactionCharges].[Date] FROM cds.[dbo].[tblMatchedOrders] JOIN cds.[dbo].[TransactionCharges]   ON [dbo].[tblMatchedOrders].ID = cds.[dbo].[TransactionCharges].transactionCode WHERE cds.[dbo].[tblMatchedOrders].Date_posted between convert(date,'" + dateFrom + "') and convert(date,'" + dateTo + "') and RTRIM(LTRIM(cds.[dbo].[TransactionCharges].[ChargeCode]))='" + chargeCode + "' order by cds.[dbo].[tblMatchedOrders].Date_posted", cnCds)
            Dim ds1 As New DataSet
            adp1 = New SqlDataAdapter(cmd1)
            adp1.Fill(ds1, "chargez")
            If (ds1.Tables(0).Rows.Count > 0) Then
                grdOrdersSummary17.DataSource = ds1
                grdOrdersSummary17.DataBind()
            Else
                grdOrdersSummary17.DataSource = Nothing
                grdOrdersSummary17.DataBind()
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub


    Protected Sub grdOrdersSummary17_PageIndexChanging(sender As Object, e As EventArgs) Handles grdOrdersSummary17.PageIndexChanged
        '  grdOrdersSummary17.PageIndex = e.
        Dim adp1 As New SqlDataAdapter
        Dim cmd1 As New SqlCommand
        Dim ds As New DataSet

        Dim dateFrom = ASPxDateEdit19.Text
        Dim dateTo = ASPxDateEdit20.Text
        Dim chargeCode = cmbJnationality1.SelectedItem.ToString().Trim()


        cmd = New SqlCommand("SELECT cds.[dbo].[tblMatchedOrders].ID,   cds.[dbo].[tblMatchedOrders].TradePrice,   cds.[dbo].[tblMatchedOrders].TradeQty,   (cds.[dbo].[tblMatchedOrders].TradePrice * cds.[dbo].[tblMatchedOrders].TradeQty) AS [DealValue],   cds.[dbo].[tblMatchedOrders].CommonRef,   cds.[dbo].[TransactionCharges].ChargeCode,   cds.[dbo].[tblMatchedOrders].Account1,   cds.[dbo].[tblMatchedOrders].Account2,   cds.[dbo].[tblMatchedOrders].Broker1,   cds.[dbo].[tblMatchedOrders].Broker2,   [tblMatchedOrders].Date_posted, cds.[dbo].[TransactionCharges].BuyCharges, cds.[dbo].[TransactionCharges].SellCharges,    cds.[dbo].[TransactionCharges].[Date] FROM cds.[dbo].[tblMatchedOrders] JOIN cds.[dbo].[TransactionCharges]   ON [dbo].[tblMatchedOrders].ID = cds.[dbo].[TransactionCharges].transactionCode WHERE cds.[dbo].[tblMatchedOrders].Date_posted between convert(date,'" + dateFrom + "') and convert(date,'" + dateTo + "') and RTRIM(LTRIM(cds.[dbo].[TransactionCharges].[ChargeCode]))='" + chargeCode + "' order by cds.[dbo].[tblMatchedOrders].Date_posted", cnCds)

        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "APP")
        If ds.Tables(0).Rows.Count > 0 Then
            grdOrdersSummary17.DataSource = ds
            grdOrdersSummary17.DataBind()
        Else
            grdOrdersSummary17.DataSource = Nothing
            grdOrdersSummary17.DataBind()
        End If

        '        End If
    End Sub

    '
    '    protected void ASPxGridVwQry_PageIndexChanged(object sender, EventArgs e)
    '
    '{
    '
    '           Binding of your code
    '
    '}

    Protected Sub ASPxButton21_Click(sender As Object, e As EventArgs) Handles ASPxButton21.Click
        
        ASPxGridViewExporter10.WriteXlsToResponse()
    End Sub
    Protected Sub ASPxButton18_Click(sender As Object, e As EventArgs) Handles ASPxButton18.Click
        Dim dateFrom = ASPxDateEdit17.Text
        Dim dateTo = ASPxDateEdit18.Text
        Dim adp1 As New SqlDataAdapter
        Dim cmd1 As New SqlCommand
        Dim ds As New DataSet


        cmd = New SqlCommand("select Company_Code, Company_name,      isnull((Select SUM(TRADEQTY) from tblMatchedOrders where Broker1=CC.COMPANY_CODE and Ack !='FAILED' and Date_posted between convert(date,'" + dateFrom + "') and convert(date,'" + dateTo + "')), 0) as [Buy Volume], isnull((SELECT SUM(TRADEQTY*TradePrice) FROM tblMatchedOrders WHERE Broker1=CC.COMPANY_CODE and Ack !='FAILED' and Date_posted between convert(date,'" + dateFrom + "') and convert(date,'" + dateTo + "')),0) as [Buy Value],   isnull((SELECT SUM(TRADEQTY) FROM tblMatchedOrders WHERE Broker2=CC.COMPANY_CODE and Ack !='FAILED' and Date_posted between convert(date,'" + dateFrom + "') and convert(date,'" + dateTo + "')),0) as [Sell Volume],   isnull((SELECT SUM(TRADEQTY*TradePrice) FROM tblMatchedOrders WHERE Broker2=CC.COMPANY_CODE and Ack !='FAILED' and Date_posted between convert(date,'" + dateFrom + "') and convert(date,'" + dateTo + "')),0) as [Sell Value],    isnull((SELECT count(Id) FROM tblMatchedOrders WHERE Broker1=CC.COMPANY_CODE and Ack !='FAILED' and Date_posted between convert(date,'" + dateFrom + "') and convert(date,'" + dateTo + "')),0) as [Number of Buy Trades],    isnull((SELECT count(Id) FROM tblMatchedOrders WHERE Broker2=CC.COMPANY_CODE and Ack !='FAILED' and Date_posted between convert(date,'" + dateFrom + "') and convert(date,'" + dateTo + "')),0) as [Number of Sell Trades],   isnull((select sum(BuyCharges) from [CDS].[dbo].[TransactionCharges] where transactionCode in     (select Id from tblMatchedOrders where (Broker1=CC.COMPANY_CODE and Ack !='FAILED')  and Date_posted between convert(date,'" + dateFrom + "') and convert(date,'" + dateTo + "')) and [ChargeCode]='SECZ Levy') , 0) +isnull((select sum(SellCharges) from [CDS].[dbo].[TransactionCharges] where transactionCode in     (select Id from tblMatchedOrders where (broker2=CC.COMPANY_CODE and Ack !='FAILED') and Date_posted between convert(date,'" + dateFrom + "') and convert(date,'" + dateTo + "')) and [ChargeCode]='SECZ Levy') , 0) as [SECZ Levy]  ,isnull((select sum(BuyCharges)  from [CDS].[dbo].[TransactionCharges] where transactionCode in   (select Id from tblMatchedOrders where (Broker1=CC.COMPANY_CODE  and Ack !='FAILED') and Date_posted between convert(date,'" + dateFrom + "') and convert(date,'" + dateTo + "')) and [ChargeCode]='VAT') , 0) +isnull((select  sum(SellCharges) from [CDS].[dbo].[TransactionCharges] where transactionCode in   (select Id from tblMatchedOrders where (broker2=CC.COMPANY_CODE and Ack !='FAILED') and Date_posted between convert(date,'" + dateFrom + "') and convert(date,'" + dateTo + "')) and [ChargeCode]='VAT') , 0) as [VAT], isnull((select sum(BuyCharges)  from [CDS].[dbo].[TransactionCharges] where transactionCode in   (select Id from tblMatchedOrders where (Broker1=CC.COMPANY_CODE and Ack !='FAILED')  and Date_posted between convert(date,'" + dateFrom + "') and convert(date,'" + dateTo + "')) and [ChargeCode]='Capital gains with holding Tax') , 0) + isnull((select sum(SellCharges) from [CDS].[dbo].[TransactionCharges] where transactionCode in   (select Id from tblMatchedOrders where  (broker2=CC.COMPANY_CODE and Ack !='FAILED') and Date_posted between convert(date,'" + dateFrom + "') and convert(date,'" + dateTo + "')) and [ChargeCode]='Capital gains with holding Tax') , 0)  as [CGT TAX],  isnull((select sum(BuyCharges)  from [CDS].[dbo].[TransactionCharges] where transactionCode in   (select Id from tblMatchedOrders where (Broker1=CC.COMPANY_CODE and Ack !='FAILED')  and Date_posted between convert(date,'" + dateFrom + "') and convert(date,'" + dateTo + "')) and [ChargeCode]='Investor Protection Levy') , 0) + isnull((select sum(SellCharges) from [CDS].[dbo].[TransactionCharges] where transactionCode in   (select Id from tblMatchedOrders where  (broker2=CC.COMPANY_CODE and Ack !='FAILED') and Date_posted between convert(date,'" + dateFrom + "') and convert(date,'" + dateTo + "')) and [ChargeCode]='Investor Protection Levy') , 0) as [Investor Levy], isnull((select sum(BuyCharges) from [CDS].[dbo].[TransactionCharges] where transactionCode in  (select Id from tblMatchedOrders where (Broker1=CC.COMPANY_CODE and Ack !='FAILED')  and Date_posted between convert(date,'" + dateFrom + "') and convert(date,'" + dateTo + "')) and [ChargeCode]='Brokerage fees') , 0)+isnull((select  sum(SellCharges) from [CDS].[dbo].[TransactionCharges] where transactionCode in   (select Id from tblMatchedOrders where  (broker2=CC.COMPANY_CODE and Ack !='FAILED') and Date_posted between convert(date,'" + dateFrom + "') and convert(date,'" + dateTo + "')) and [ChargeCode]='Brokerage fees') , 0) as [Brokerage Levy], isnull((select sum(BuyCharges)  from [CDS].[dbo].[TransactionCharges] where transactionCode in   (select Id from tblMatchedOrders where (Broker1=CC.COMPANY_CODE and Ack !='FAILED')  and Date_posted between convert(date,'" + dateFrom + "') and convert(date,'" + dateTo + "')) and [ChargeCode]='Stamp duty') , 0) + isnull((select sum(SellCharges) from [CDS].[dbo].[TransactionCharges] where transactionCode in   (select Id from tblMatchedOrders where  (broker2=CC.COMPANY_CODE and Ack !='FAILED') and Date_posted between convert(date,'" + dateFrom + "') and convert(date,'" + dateTo + "')) and [ChargeCode]='Stamp duty') , 0) as [Stamp Duty],  isnull((select sum(BuyCharges)  from [CDS].[dbo].[TransactionCharges] where transactionCode in   (select Id from tblMatchedOrders where (Broker1=CC.COMPANY_CODE and Ack !='FAILED')  and Date_posted between convert(date,'" + dateFrom + "') and convert(date,'" + dateTo + "')) and [ChargeCode]='Settlement Levy') , 0) +  isnull((select sum(SellCharges) from [CDS].[dbo].[TransactionCharges] where transactionCode in   (select Id from tblMatchedOrders where  (broker2=CC.COMPANY_CODE and Ack !='FAILED') and Date_posted between convert(date,'" + dateFrom + "') and convert(date,'" + dateTo + "')) and [ChargeCode]='Settlement Levy') , 0)as [ZSE Levy],  isnull((select sum(BuyCharges)  from [CDS].[dbo].[TransactionCharges] where transactionCode in   (select Id from tblMatchedOrders where (Broker1=CC.COMPANY_CODE and Ack !='FAILED') and Date_posted between convert(date,'" + dateFrom + "') and convert(date,'" + dateTo + "')) and [ChargeCode]='Platform Levy') , 0) + isnull((select sum(SellCharges) from [CDS].[dbo].[TransactionCharges] where transactionCode in  (select Id from tblMatchedOrders where  (broker2=CC.COMPANY_CODE and Ack !='FAILED')  and Date_posted between convert(date,'" + dateFrom + "') and convert(date,'" + dateTo + "')) and [ChargeCode]='Platform Levy') , 0) as [CSD Levy] , isnull((select sum(BuyCharges)  from [CDS].[dbo].[TransactionCharges] where transactionCode in   (select Id from tblMatchedOrders where (Broker1=CC.COMPANY_CODE and Ack !='FAILED') and Date_posted between convert(date,'" + dateFrom + "') and convert(date,'" + dateTo + "'))) , 0) + isnull((select sum(SellCharges) from [CDS].[dbo].[TransactionCharges] where transactionCode in  (select Id from tblMatchedOrders where  (broker2=CC.COMPANY_CODE and Ack !='FAILED') and Date_posted between convert(date,'" + dateFrom + "') and convert(date,'" + dateTo + "'))) , 0) as [Total]  from client_companies CC where cOMPANY_type='BROKER' and (isnull((select sum(BuyCharges)  from [CDS].[dbo].[TransactionCharges] where transactionCode in   (select Id from tblMatchedOrders where (Broker1=CC.COMPANY_CODE and Ack !='FAILED') and Date_posted between convert(date,'" + dateFrom + "') and convert(date,'" + dateTo + "'))) , 0) + isnull((select sum(SellCharges) from [CDS].[dbo].[TransactionCharges] where transactionCode in   (select Id from tblMatchedOrders where  (broker2=CC.COMPANY_CODE and Ack !='FAILED') and Date_posted between convert(date,'" + dateFrom + "') and convert(date,'" + dateTo + "'))) , 0))>0", cnCds)

        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "APP")
        If ds.Tables(0).Rows.Count > 0 Then
            grdOrdersSummary16.DataSource = ds
            grdOrdersSummary16.DataBind()
        Else
            grdOrdersSummary16.DataSource = Nothing
            grdOrdersSummary16.DataBind()
        End If

    End Sub
    Protected Sub ASPxButton19_Click(sender As Object, e As EventArgs) Handles ASPxButton19.Click
        ASPxGridViewExporter9.WriteXlsxToResponse()
    End Sub

    Public Sub GetTheLevies()
        Dim dateFrom = ASPxDateEdit17.Text
        Dim dateTo = ASPxDateEdit18.Text
        Dim adp1 As New SqlDataAdapter
        Dim cmd1 As New SqlCommand
        Dim ds As New DataSet


        cmd = New SqlCommand("select Company_Code, Company_name,      isnull((Select SUM(TRADEQTY) from tblMatchedOrders where Broker1=CC.COMPANY_CODE and Ack !='FAILED' and Date_posted between convert(date,'" + dateFrom + "') and convert(date,'" + dateTo + "')), 0) as [Buy Volume], isnull((SELECT SUM(TRADEQTY*TradePrice) FROM tblMatchedOrders WHERE Broker1=CC.COMPANY_CODE and Ack !='FAILED' and Date_posted between convert(date,'" + dateFrom + "') and convert(date,'" + dateTo + "')),0) as [Buy Value],   isnull((SELECT SUM(TRADEQTY) FROM tblMatchedOrders WHERE Broker2=CC.COMPANY_CODE and Ack !='FAILED' and Date_posted between convert(date,'" + dateFrom + "') and convert(date,'" + dateTo + "')),0) as [Sell Volume],   isnull((SELECT SUM(TRADEQTY*TradePrice) FROM tblMatchedOrders WHERE Broker2=CC.COMPANY_CODE and Ack !='FAILED' and Date_posted between convert(date,'" + dateFrom + "') and convert(date,'" + dateTo + "')),0) as [Sell Value],    isnull((SELECT count(Id) FROM tblMatchedOrders WHERE Broker1=CC.COMPANY_CODE and Ack !='FAILED' and Date_posted between convert(date,'" + dateFrom + "') and convert(date,'" + dateTo + "')),0) as [Number of Buy Trades],    isnull((SELECT count(Id) FROM tblMatchedOrders WHERE Broker2=CC.COMPANY_CODE and Ack !='FAILED' and Date_posted between convert(date,'" + dateFrom + "') and convert(date,'" + dateTo + "')),0) as [Number of Sell Trades],   isnull((select sum(BuyCharges) from [CDS].[dbo].[TransactionCharges] where transactionCode in     (select Id from tblMatchedOrders where (Broker1=CC.COMPANY_CODE and Ack !='FAILED')  and Date_posted between convert(date,'" + dateFrom + "') and convert(date,'" + dateTo + "')) and [ChargeCode]='SECZ Levy') , 0) +isnull((select sum(SellCharges) from [CDS].[dbo].[TransactionCharges] where transactionCode in     (select Id from tblMatchedOrders where (broker2=CC.COMPANY_CODE and Ack !='FAILED') and Date_posted between convert(date,'" + dateFrom + "') and convert(date,'" + dateTo + "')) and [ChargeCode]='SECZ Levy') , 0) as [SECZ Levy]  ,isnull((select sum(BuyCharges)  from [CDS].[dbo].[TransactionCharges] where transactionCode in   (select Id from tblMatchedOrders where (Broker1=CC.COMPANY_CODE  and Ack !='FAILED') and Date_posted between convert(date,'" + dateFrom + "') and convert(date,'" + dateTo + "')) and [ChargeCode]='VAT') , 0) +isnull((select  sum(SellCharges) from [CDS].[dbo].[TransactionCharges] where transactionCode in   (select Id from tblMatchedOrders where (broker2=CC.COMPANY_CODE and Ack !='FAILED') and Date_posted between convert(date,'" + dateFrom + "') and convert(date,'" + dateTo + "')) and [ChargeCode]='VAT') , 0) as [VAT], isnull((select sum(BuyCharges)  from [CDS].[dbo].[TransactionCharges] where transactionCode in   (select Id from tblMatchedOrders where (Broker1=CC.COMPANY_CODE and Ack !='FAILED')  and Date_posted between convert(date,'" + dateFrom + "') and convert(date,'" + dateTo + "')) and [ChargeCode]='Capital gains with holding Tax') , 0) + isnull((select sum(SellCharges) from [CDS].[dbo].[TransactionCharges] where transactionCode in   (select Id from tblMatchedOrders where  (broker2=CC.COMPANY_CODE and Ack !='FAILED') and Date_posted between convert(date,'" + dateFrom + "') and convert(date,'" + dateTo + "')) and [ChargeCode]='Capital gains with holding Tax') , 0)  as [CGT TAX],  isnull((select sum(BuyCharges)  from [CDS].[dbo].[TransactionCharges] where transactionCode in   (select Id from tblMatchedOrders where (Broker1=CC.COMPANY_CODE and Ack !='FAILED')  and Date_posted between convert(date,'" + dateFrom + "') and convert(date,'" + dateTo + "')) and [ChargeCode]='Investor Protection Levy') , 0) + isnull((select sum(SellCharges) from [CDS].[dbo].[TransactionCharges] where transactionCode in   (select Id from tblMatchedOrders where  (broker2=CC.COMPANY_CODE and Ack !='FAILED') and Date_posted between convert(date,'" + dateFrom + "') and convert(date,'" + dateTo + "')) and [ChargeCode]='Investor Protection Levy') , 0) as [Investor Levy], isnull((select sum(BuyCharges) from [CDS].[dbo].[TransactionCharges] where transactionCode in  (select Id from tblMatchedOrders where (Broker1=CC.COMPANY_CODE and Ack !='FAILED')  and Date_posted between convert(date,'" + dateFrom + "') and convert(date,'" + dateTo + "')) and [ChargeCode]='Brokerage fees') , 0)+isnull((select  sum(SellCharges) from [CDS].[dbo].[TransactionCharges] where transactionCode in   (select Id from tblMatchedOrders where  (broker2=CC.COMPANY_CODE and Ack !='FAILED') and Date_posted between convert(date,'" + dateFrom + "') and convert(date,'" + dateTo + "')) and [ChargeCode]='Brokerage fees') , 0) as [Brokerage Levy], isnull((select sum(BuyCharges)  from [CDS].[dbo].[TransactionCharges] where transactionCode in   (select Id from tblMatchedOrders where (Broker1=CC.COMPANY_CODE and Ack !='FAILED')  and Date_posted between convert(date,'" + dateFrom + "') and convert(date,'" + dateTo + "')) and [ChargeCode]='Stamp duty') , 0) + isnull((select sum(SellCharges) from [CDS].[dbo].[TransactionCharges] where transactionCode in   (select Id from tblMatchedOrders where  (broker2=CC.COMPANY_CODE and Ack !='FAILED') and Date_posted between convert(date,'" + dateFrom + "') and convert(date,'" + dateTo + "')) and [ChargeCode]='Stamp duty') , 0) as [Stamp Duty],  isnull((select sum(BuyCharges)  from [CDS].[dbo].[TransactionCharges] where transactionCode in   (select Id from tblMatchedOrders where (Broker1=CC.COMPANY_CODE and Ack !='FAILED')  and Date_posted between convert(date,'" + dateFrom + "') and convert(date,'" + dateTo + "')) and [ChargeCode]='Settlement Levy') , 0) +  isnull((select sum(SellCharges) from [CDS].[dbo].[TransactionCharges] where transactionCode in   (select Id from tblMatchedOrders where  (broker2=CC.COMPANY_CODE and Ack !='FAILED') and Date_posted between convert(date,'" + dateFrom + "') and convert(date,'" + dateTo + "')) and [ChargeCode]='Settlement Levy') , 0)as [ZSE Levy],  isnull((select sum(BuyCharges)  from [CDS].[dbo].[TransactionCharges] where transactionCode in   (select Id from tblMatchedOrders where (Broker1=CC.COMPANY_CODE and Ack !='FAILED') and Date_posted between convert(date,'" + dateFrom + "') and convert(date,'" + dateTo + "')) and [ChargeCode]='Platform Levy') , 0) + isnull((select sum(SellCharges) from [CDS].[dbo].[TransactionCharges] where transactionCode in  (select Id from tblMatchedOrders where  (broker2=CC.COMPANY_CODE and Ack !='FAILED')  and Date_posted between convert(date,'" + dateFrom + "') and convert(date,'" + dateTo + "')) and [ChargeCode]='Platform Levy') , 0) as [CSD Levy] , isnull((select sum(BuyCharges)  from [CDS].[dbo].[TransactionCharges] where transactionCode in   (select Id from tblMatchedOrders where (Broker1=CC.COMPANY_CODE and Ack !='FAILED') and Date_posted between convert(date,'" + dateFrom + "') and convert(date,'" + dateTo + "'))) , 0) + isnull((select sum(SellCharges) from [CDS].[dbo].[TransactionCharges] where transactionCode in  (select Id from tblMatchedOrders where  (broker2=CC.COMPANY_CODE and Ack !='FAILED') and Date_posted between convert(date,'" + dateFrom + "') and convert(date,'" + dateTo + "'))) , 0) as [Total]  from client_companies CC where cOMPANY_type='BROKER' and (isnull((select sum(BuyCharges)  from [CDS].[dbo].[TransactionCharges] where transactionCode in   (select Id from tblMatchedOrders where (Broker1=CC.COMPANY_CODE and Ack !='FAILED') and Date_posted between convert(date,'" + dateFrom + "') and convert(date,'" + dateTo + "'))) , 0) + isnull((select sum(SellCharges) from [CDS].[dbo].[TransactionCharges] where transactionCode in   (select Id from tblMatchedOrders where  (broker2=CC.COMPANY_CODE and Ack !='FAILED') and Date_posted between convert(date,'" + dateFrom + "') and convert(date,'" + dateTo + "'))) , 0))>0", cnCds)

        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "APP")
        If ds.Tables(0).Rows.Count > 0 Then
            grdOrdersSummary16.DataSource = ds
            grdOrdersSummary16.DataBind()
        Else
            grdOrdersSummary16.DataSource = Nothing
            grdOrdersSummary16.DataBind()
        End If
    End Sub

    Public Sub GetChargeCode()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("SELECT distinct ChargeCode  FROM [CDS].[dbo].[para_Billing]", cnCds)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "tbl_IdentityDocuments")
            If (ds.Tables(0).Rows.Count > 0) Then
                'cmbIDType.DataSource = ds.Tables(0)
                'cmbIDType.TextField = "type"
                'cmbIDType.ValueField = "type"
                'cmbIDType.DataBind()

                'cmbIDType0.DataSource = ds.Tables(0)
                'cmbIDType0.TextField = "type"
                'cmbIDType0.ValueField = "type"
                'cmbIDType0.DataBind()

                cmbJnationality1.DataSource = ds.Tables(0)
                cmbJnationality1.TextField = "ChargeCode"
                cmbJnationality1.ValueField = "ChargeCode"
                cmbJnationality1.DataBind()
                cmbJnationality1.Text = "Select Charge Code"
                '                cmbJnationality1.SelectedItem = "Select"

            End If

        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
End Class
