Imports System.IO
Imports DevExpress.Web.ASPxGridView

Partial Class Parameters_PortSummary
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

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Page.MaintainScrollPositionOnPostBack = True
            If (Not IsPostBack) Then


            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub getSecurities_Categories()
        Try
            cmd = New SqlCommand("declare @date date='" + dtdate.Date.ToString + "' select j.t as [Asset],sum(j.[Market Value] ) as [Market Value], case t when 'Equities' then (SELECT COUNT ( DISTINCT Client ) from (select 'Equities' as t, p.Category as [Type],  p.Fnam  , sum(t.Shares) as Units, 0  as [Book Cost], isnull(m.current_price,isnull((select top 1 current_price from Market_data_History where convert(date,[date])<=@date AND Ticker=T.Company order by [date] desc, id desc),0)) as [Market Price],pc.currency  AS [Price Currency],case pc.currency when 'ZWL' then isnull(m.current_price,isnull((select top 1 current_price from Market_data_History where convert(date,[date])<=@date AND Ticker=t.Company order by [date] desc, id desc),0))*sum(t.Shares) else (isnull(m.current_price,isnull((select top 1 current_price from Market_data_History where convert(date,[date])<=@date AND Ticker=t.Company order by [date] desc, id desc),0))*sum(t.Shares))*isnull((select top 1 RateToBase  from para_CurrencyRates where CurrencyCode=pc.currency  and convert(date, DateFrom)<=convert(date,@date) order by rateid desc),0) end as [Market Value], NULL as [Purchase Date], NULL as [Interest Rate], NULL as [Acrual Days], isnull(m.current_price,isnull((select top 1 current_price from Market_data_History where convert(date,[date])<=@date AND Ticker=t.Company order by [date] desc, id desc),0))*sum(t.Shares)/NULLIF(10000,0) *100 as Perc, 0 as [AccruedInterest], t.CDS_Number as [Client] from para_company pc,  trans t  left join Market_data_History  m on m.ticker=t.Company AND convert(date,m.[date])=@date  inner join para_company p on p.Company=t.Company  WHERE convert(date, t.date_created)<=@date and pc.company=t.Company    group by t.Company, p.Fnam ,m.current_price, p.Category, pc.currency, t.CDS_Number   having sum(shares)>0) m) when 'Fixed Deposits' THEN (SELECT COUNT ( DISTINCT Client ) from (select  'Fixed Deposits' as t, 'Money Market' as [Type],  t.Description as [Company] , 0 as Units, t.SettlementAmount  as [Book Cost], 0 as [Market Price],Currency  AS [Price Currency],CASE CURRENCY WHEN 'ZWL' then  custodial.dbo.moneymarketgain(TradeDate,FixedRate,DayCountBasis,Amount , Tax , @date)+Amount else ( custodial.dbo.moneymarketgain(TradeDate,FixedRate,DayCountBasis,Amount , Tax , @date)+Amount)*isnull((select top 1 RateToBase  from para_CurrencyRates where CurrencyCode=t.Currency   and convert(date, DateFrom)<=convert(date,@date) order by rateid desc),0) end as [Market Value], t.SettlementDate  as [Purchase Date], FixedRate  as [Interest Rate],DAtediff(day, TradeDate, convert(date, @date)) as [Acrual Days],(CASE CURRENCY WHEN 'ZWL' then  custodial.dbo.moneymarketgain(TradeDate,FixedRate,DayCountBasis,Amount , Tax , @date)+Amount else ( custodial.dbo.moneymarketgain(TradeDate,FixedRate,DayCountBasis,Amount , Tax , @date)+Amount)*isnull((select top 1 RateToBase  from para_CurrencyRates where CurrencyCode=t.Currency   and convert(date, DateFrom)<=convert(date,@date) order by rateid desc),0) end)/NULLIF(10000,0) *100 as Perc, CASE CURRENCY WHEN 'ZWL' then  custodial.dbo.moneymarketgain(TradeDate,FixedRate,DayCountBasis,Amount , Tax , @date) else ( custodial.dbo.moneymarketgain(TradeDate,FixedRate,DayCountBasis,Amount , Tax , @date))*isnull((select top 1 RateToBase  from para_CurrencyRates where CurrencyCode=t.Currency   and convert(date, DateFrom)<=convert(date,@date) order by rateid desc),0) end  as [AccruedInterest], t.ClientNo as [Client]  from MoneyMarket  t  WHERE TradeStatus='ON-GOING' AND convert(date, t.TradeDate)<=@date) D) when 'Bonds' THEN (SELECT COUNT ( DISTINCT Client ) from (    select 'Bonds' as t,  'Bonds' as [Type],  t.Company , sum(t.Shares) as Units, isnull(sum(c.SettlementAmount),0)  as [Book Cost], 0 as [Market Price],b.currency  AS [Price Currency],case b.currency when 'ZWL' then  custodial.dbo.moneymarketgain(b.IssueDate,b.Rate,b.DayCountBasis,sum(t.Shares) , 0 , @date)+sum(t.Shares) else custodial.dbo.moneymarketgain(b.IssueDate,b.Rate,b.DayCountBasis,sum(t.Shares) , 0 , @date)+sum(t.Shares)*isnull((select top 1 RateToBase  from para_CurrencyRates where CurrencyCode=b.currency   and convert(date, DateFrom)<=convert(date,@date) order by rateid desc),0) end as [Market Value], NULL as [Purchase Date] , b.Rate as [FixedRate], DAtediff(day, b.IssueDate, convert(date, @date)) as [Acrual Days], (case b.currency when 'ZWL' then  custodial.dbo.moneymarketgain(b.IssueDate,b.Rate,b.DayCountBasis,sum(t.Shares) , 0 , @date)+sum(t.Shares) else custodial.dbo.moneymarketgain(b.IssueDate,b.Rate,b.DayCountBasis,sum(t.Shares) , 0 , @date)+sum(t.Shares)*isnull((select top 1 RateToBase  from para_CurrencyRates where CurrencyCode=b.currency   and convert(date, DateFrom)<=convert(date,@date) order by rateid desc),0) end)/NULLIF(10000,0)*100   as Perc, case b.currency when 'ZWL' then  custodial.dbo.moneymarketgain(b.IssueDate,b.Rate,b.DayCountBasis,sum(t.Shares) , 0 , @date) else custodial.dbo.moneymarketgain(b.IssueDate,b.Rate,b.DayCountBasis,sum(t.Shares) , 0 , @date)*isnull((select top 1 RateToBase  from para_CurrencyRates where CurrencyCode=b.currency   and convert(date, DateFrom)<=convert(date,@date) order by rateid desc),0) end as [AccruedInterest], t.CDS_Number as [Client]     from trans t left join Bond_Trades  c on c.company=t.Company and c.ClientNo=t.CDS_Number inner join bond b on b.code=c.Company   WHERE convert(date, t.date_created)<=@date   group by t.Company, b.IssueDate, b.rate, b.DayCountBasis, b.currency, t.CDS_Number    having sum(shares)>0) F) when 'Cash' THEN (SELECT COUNT ( DISTINCT Client ) from ( select 'Cash' as t,  'Cash Available' as [Type],  'Cash' as Company ,  case currency when 'ZWL' THEN  sum(t.amount) else sum(t.amount)*isnull((select top 1 RateToBase  from para_CurrencyRates where CurrencyCode=t.Currency   and convert(date, DateFrom)<=convert(date,@date) order by rateid desc),0) end as Units, 0  as [Book Cost], 0 as [Market Price],Currency  AS [Price Currency], case currency when 'ZWL' THEN  sum(t.amount) else sum(t.amount)*isnull((select top 1 RateToBase  from para_CurrencyRates where CurrencyCode=t.Currency   and convert(date, DateFrom)<=convert(date,@date) order by rateid desc),0) end as [Market Value], NULL as [Purchase Date], NULL as [Interest Rate], NULL as [Acrual Days] ,( case currency when 'ZWL' THEN  sum(t.amount) else sum(t.amount)*isnull((select top 1 RateToBase  from para_CurrencyRates where CurrencyCode=t.Currency   and convert(date, DateFrom)<=convert(date,@date) order by rateid desc),0) end)/NULLIF(10000,0)*100 as [Perc], 0 as [AccruedInterest], t.CDS_Number as [Client] from cashtrans t   WHERE convert(date, t.DateCreated )<=@date  group by currency, CDS_Number) EE)  end as [Count] from (    select 'Equities' as t, p.Category as [Type],  p.Fnam  , sum(t.Shares) as Units, 0  as [Book Cost], isnull(m.current_price,isnull((select top 1 current_price from Market_data_History where convert(date,[date])<=@date AND Ticker=T.Company order by [date] desc, id desc),0)) as [Market Price],pc.currency  AS [Price Currency],case pc.currency when 'ZWL' then isnull(m.current_price,isnull((select top 1 current_price from Market_data_History where convert(date,[date])<=@date AND Ticker=t.Company order by [date] desc, id desc),0))*sum(t.Shares) else (isnull(m.current_price,isnull((select top 1 current_price from Market_data_History where convert(date,[date])<=@date AND Ticker=t.Company order by [date] desc, id desc),0))*sum(t.Shares))*isnull((select top 1 RateToBase  from para_CurrencyRates where CurrencyCode=pc.currency  and convert(date, DateFrom)<=convert(date,@date) order by rateid desc),0) end as [Market Value], NULL as [Purchase Date], NULL as [Interest Rate], NULL as [Acrual Days], isnull(m.current_price,isnull((select top 1 current_price from Market_data_History where convert(date,[date])<=@date AND Ticker=t.Company order by [date] desc, id desc),0))*sum(t.Shares)/NULLIF(10000,0) *100 as Perc, 0 as [AccruedInterest], t.CDS_Number as [Client] from para_company pc,  trans t  left join Market_data_History  m on m.ticker=t.Company AND convert(date,m.[date])=@date  inner join para_company p on p.Company=t.Company  WHERE convert(date, t.date_created)<=@date and pc.company=t.Company    group by t.Company, p.Fnam ,m.current_price, p.Category, pc.currency, t.CDS_Number   having sum(shares)>0 	union     select  'Fixed Deposits' as t, 'Money Market' as [Type],  t.Description as [Company] , 0 as Units, t.SettlementAmount  as [Book Cost], 0 as [Market Price],Currency  AS [Price Currency],CASE CURRENCY WHEN 'ZWL' then  custodial.dbo.moneymarketgain(TradeDate,FixedRate,DayCountBasis,Amount , Tax , @date)+Amount else ( custodial.dbo.moneymarketgain(TradeDate,FixedRate,DayCountBasis,Amount , Tax , @date)+Amount)*isnull((select top 1 RateToBase  from para_CurrencyRates where CurrencyCode=t.Currency   and convert(date, DateFrom)<=convert(date,@date) order by rateid desc),0) end as [Market Value], t.SettlementDate  as [Purchase Date], FixedRate  as [Interest Rate],DAtediff(day, TradeDate, convert(date, @date)) as [Acrual Days],(CASE CURRENCY WHEN 'ZWL' then  custodial.dbo.moneymarketgain(TradeDate,FixedRate,DayCountBasis,Amount , Tax , @date)+Amount else ( custodial.dbo.moneymarketgain(TradeDate,FixedRate,DayCountBasis,Amount , Tax , @date)+Amount)*isnull((select top 1 RateToBase  from para_CurrencyRates where CurrencyCode=t.Currency   and convert(date, DateFrom)<=convert(date,@date) order by rateid desc),0) end)/NULLIF(10000,0) *100 as Perc, CASE CURRENCY WHEN 'ZWL' then  custodial.dbo.moneymarketgain(TradeDate,FixedRate,DayCountBasis,Amount , Tax , @date) else ( custodial.dbo.moneymarketgain(TradeDate,FixedRate,DayCountBasis,Amount , Tax , @date))*isnull((select top 1 RateToBase  from para_CurrencyRates where CurrencyCode=t.Currency   and convert(date, DateFrom)<=convert(date,@date) order by rateid desc),0) end  as [AccruedInterest], t.ClientNo as [Client]  from MoneyMarket  t  WHERE TradeStatus='ON-GOING' AND convert(date, t.TradeDate)<=@date 	union	    select 'Bonds' as t,  'Bonds' as [Type],  t.Company , sum(t.Shares) as Units, isnull(sum(c.SettlementAmount),0)  as [Book Cost], 0 as [Market Price],b.currency  AS [Price Currency],case b.currency when 'ZWL' then  custodial.dbo.moneymarketgain(b.IssueDate,b.Rate,b.DayCountBasis,sum(t.Shares) , 0 , @date)+sum(t.Shares) else custodial.dbo.moneymarketgain(b.IssueDate,b.Rate,b.DayCountBasis,sum(t.Shares) , 0 , @date)+sum(t.Shares)*isnull((select top 1 RateToBase  from para_CurrencyRates where CurrencyCode=b.currency   and convert(date, DateFrom)<=convert(date,@date) order by rateid desc),0) end as [Market Value], NULL as [Purchase Date] , b.Rate as [FixedRate], DAtediff(day, b.IssueDate, convert(date, @date)) as [Acrual Days], (case b.currency when 'ZWL' then  custodial.dbo.moneymarketgain(b.IssueDate,b.Rate,b.DayCountBasis,sum(t.Shares) , 0 , @date)+sum(t.Shares) else custodial.dbo.moneymarketgain(b.IssueDate,b.Rate,b.DayCountBasis,sum(t.Shares) , 0 , @date)+sum(t.Shares)*isnull((select top 1 RateToBase  from para_CurrencyRates where CurrencyCode=b.currency   and convert(date, DateFrom)<=convert(date,@date) order by rateid desc),0) end)/NULLIF(10000,0)*100   as Perc, case b.currency when 'ZWL' then  custodial.dbo.moneymarketgain(b.IssueDate,b.Rate,b.DayCountBasis,sum(t.Shares) , 0 , @date) else custodial.dbo.moneymarketgain(b.IssueDate,b.Rate,b.DayCountBasis,sum(t.Shares) , 0 , @date)*isnull((select top 1 RateToBase  from para_CurrencyRates where CurrencyCode=b.currency   and convert(date, DateFrom)<=convert(date,@date) order by rateid desc),0) end as [AccruedInterest], t.CDS_Number as [Client]     from trans t left join Bond_Trades  c on c.company=t.Company and c.ClientNo=t.CDS_Number inner join bond b on b.code=c.Company   WHERE convert(date, t.date_created)<=@date   group by t.Company, b.IssueDate, b.rate, b.DayCountBasis, b.currency, t.CDS_Number    having sum(shares)>0 union	    select 'Cash' as t,  'Cash Available' as [Type],  'Cash' as Company ,  case currency when 'ZWL' THEN  sum(t.amount) else sum(t.amount)*isnull((select top 1 RateToBase  from para_CurrencyRates where CurrencyCode=t.Currency   and convert(date, DateFrom)<=convert(date,@date) order by rateid desc),0) end as Units, 0  as [Book Cost], 0 as [Market Price],Currency  AS [Price Currency], case currency when 'ZWL' THEN  sum(t.amount) else sum(t.amount)*isnull((select top 1 RateToBase  from para_CurrencyRates where CurrencyCode=t.Currency   and convert(date, DateFrom)<=convert(date,@date) order by rateid desc),0) end as [Market Value], NULL as [Purchase Date], NULL as [Interest Rate], NULL as [Acrual Days] ,( case currency when 'ZWL' THEN  sum(t.amount) else sum(t.amount)*isnull((select top 1 RateToBase  from para_CurrencyRates where CurrencyCode=t.Currency   and convert(date, DateFrom)<=convert(date,@date) order by rateid desc),0) end)/NULLIF(10000,0)*100 as [Perc], 0 as [AccruedInterest], t.CDS_Number as [Client] from cashtrans t   WHERE convert(date, t.DateCreated )<=@date  group by currency, CDS_Number ) j		GROUP BY J.t", cn)
            Dim ds As New DataSet
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "para_Country")
            If ds.Tables(0).Rows.Count > 0 Then
                ASPxGridView2.DataSource = ds.Tables(0)
            Else
                ASPxGridView2.DataSource = Nothing
            End If
            ASPxGridView2.DataBind()
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub





    Protected Sub ASPxButton7_Click(sender As Object, e As EventArgs) Handles ASPxButton7.Click
        getSecurities_Categories()

    End Sub
    Protected Sub ASPxButton8_Click(sender As Object, e As EventArgs) Handles ASPxButton8.Click
        ASPxGridViewExporter1.WriteXlsToResponse()
    End Sub
End Class