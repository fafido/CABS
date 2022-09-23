Imports System.IO
Imports System.Array
Partial Class TransferSec_Regulatordates
    Inherits System.Web.UI.Page
    Dim cnstr As String = (System.Configuration.ConfigurationManager.AppSettings("connpath2"))
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

    'Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    '    Try
    '        If (Not IsPostBack) Then
    '            GetOTCTrades()
    '            GetBrokersNet()

    '        End If
    '    Catch ex As Exception
    '        msgbox(ex.Message)
    '    End Try
    'End Sub

    'Public Sub GetOTCTrades()
    '    Try
    '        Dim ds As New DataSet
    '        'cmd = New SqlCommand("select * from OTC_Data_Import ", cn)
    '        cmd = New SqlCommand("select company as [Company], BuyOrderNum as [Buyer Order No.], Quantity as [Quantity], SellOrderNum as [Seller Order No.], Price as [Base Price], case SettlementStatus when 1 then 'PENDING' when 2 then 'CONFIRMED' ELSE 'FAILED' END as [Clearance Status] from OTC_Data_Import ", cn)
    '        adp = New SqlDataAdapter(cmd)
    '        adp.Fill(ds, "OTC_Data_Import")
    '        If (ds.Tables(0).Rows.Count > 0) Then
    '            grdOrdersSummary.DataSource = ds.Tables(0)
    '            grdOrdersSummary.DataBind()
    '        Else
    '            grdOrdersSummary.DataSource = Nothing
    '            grdOrdersSummary.DataBind()
    '        End If
    '    Catch ex As Exception
    '        msgbox(ex.Message)
    '    End Try
    'End Sub
    'Public Sub GetBrokersNet()
    '    Try
    '        Dim ds As New DataSet
    '        cmd = New SqlCommand("select OrdersSummary .Company as company ,OrdersSummary.OrderType  , sum(OrdersSummary.Order_Quantity) as [Quantity], sum(OrdersSummary .BasePrice * OrdersSummary.Order_Quantity) as [Amount], OrdersSummary .PurchasingBroker as [Broker] from OrdersSummary where Company in (select distinct (company) from OTC_Data_Import) group by OrdersSummary .PurchasingBroker , OrdersSummary .Company , OrdersSummary.OrderType ", cn)
    '        adp = New SqlDataAdapter(cmd)
    '        adp.Fill(ds, "ordersSummary")
    '        If (ds.Tables(0).Rows.Count > 0) Then
    '            grdBrokersNet.DataSource = ds.Tables(0)
    '            grdBrokersNet.DataBind()
    '        Else
    '            grdBrokersNet.DataSource = Nothing
    '            grdBrokersNet.DataBind()
    '        End If
    '    Catch ex As Exception
    '        msgbox(ex.Message)
    '    End Try
    'End Sub


    Protected Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If Not IsPostBack = True Then
            getbuyorders()
            getsellorders()
            getmatchedunsettled()
            getmarketactivity()
            getmarketviewer()
          

           
        End If
    End Sub
   
  
    Protected Sub ASPxButton11_Click(sender As Object, e As EventArgs) Handles ASPxButton11.Click


        ASPxRoundPanel10.Visible = True
        ASPxButton11.Visible = False

    End Sub
    Public Sub getbuyorders()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select orderno, broker_code as [Broker], company as [Counter], case baseprice when '0.00' then (select initialprice from para_company where company=Audit_Order_Posted_Log.company) else baseprice end as [Price], quantity as [Quantity], case baseprice when '0.00'  then Quantity*(select initialprice from para_company where company=testcds.dbo.Audit_Order_Posted_Log.Company) else Quantity*BasePrice   end as [Value]  from testcds.dbo.Audit_Order_Posted_Log where ordertype='BUY' and inserted_datetime between '" + ASPxDateEdit1.Text + "' and '" + ASPxDateEdit2.Text + "' order by orderno desc", cn)
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
    Public Sub getsellorders()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select  broker_code as [Broker], company as [Counter],case baseprice when '0.00' then (select initialprice from para_company where company=Audit_Order_Posted_Log.company) else baseprice end as [Price], quantity as [Quantity], case baseprice when '0.00'  then Quantity*(select initialprice from para_company where company=testcds.dbo.Audit_Order_Posted_Log.Company) else Quantity*BasePrice   end as [Value]  from testcds.dbo.Audit_Order_Posted_Log where ordertype='SELL' and inserted_datetime between '" + ASPxDateEdit1.Text + "' and '" + ASPxDateEdit2.Text + "' order by orderno desc", cn)
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
            Dim ds As New DataSet
            cmd = New SqlCommand("  select Company, BuyOrderNumber as [Buy Order No], Quantity, case dealprice when '0.00' then (select initialprice from para_company where company=Orders_Executed.company) else dealprice end as [Price],case dealprice when '0.00' then (select initialprice from para_company where company=Orders_Executed.company)*quantity else dealprice*Quantity  end as [Value],sellordernumber as [Sell Order], TargetDealNo as [Deal No] from Orders_Executed where DealDateTime between '" + ASPxDateEdit1.Text + "' and '" + ASPxDateEdit2.Text + "' ", cn)
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
    Public Sub getmarketactivity()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("SELECT A.Activity AS [Activity], A.ActivityDate, A.IpAddress as [IP Address], a.PageUrl 	FROM ActivityLog A INNER JOIN ATS_UserManagement B	ON A.Uid = B.Uid WHERE  Activity LIKE '%Order%' and a.ActivityDate between '" + ASPxDateEdit1.Text + "' and '" + ASPxDateEdit2.Text + "' 	ORDER BY A.ActivityDate DESC ", cn)
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
    Public Sub getmarketviewer()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select company, sum(price*quantity) as [Market Turnover], sum(Quantity) as [Total Quantities], max(price) as [Highest Price], min(price) as [Lowest Price], avg(price) as [Average Price]  from statsnew where company=company and  DealDateTime between '" + ASPxDateEdit1.Text + "' and '" + ASPxDateEdit2.Text + "'  group by company ", cn)
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

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack = True Then
         

            ASPxRoundPanel10.Visible = True
            ASPxRoundPanel2.Visible = False
            ASPxRoundPanel6.Visible = False
            ASPxRoundPanel7.Visible = False
            ASPxRoundPanel8.Visible = False
            ASPxRoundPanel9.Visible = False
            ASPxButton11.Visible = False

        End If


    End Sub

    Protected Sub ASPxButton19_Click(sender As Object, e As EventArgs) Handles ASPxButton19.Click
        ASPxRoundPanel10.Visible = False
        ASPxRoundPanel2.Visible = True
        ASPxRoundPanel6.Visible = True
        ASPxRoundPanel7.Visible = True
        ASPxRoundPanel8.Visible = True
        ASPxRoundPanel9.Visible = True
        ASPxButton11.Visible = True

        getbuyorders()
        getsellorders()
        getmatchedunsettled()
        getmarketactivity()
        getmarketviewer()
    End Sub

   

   

    Protected Sub ASPxButton16_Click(sender As Object, e As EventArgs) Handles ASPxButton16.Click
        Dim strscript As String
        strscript = "<script langauage=JavaScript>"
        strscript += "window.open('regulatorviewmore.aspx?buysell=matched&for=');"
        strscript += "</script>"
        ClientScript.RegisterStartupScript(Me.GetType(), "newwin", strscript)
    End Sub

    Protected Sub ASPxButton15_Click(sender As Object, e As EventArgs) Handles ASPxButton15.Click
        Dim strscript As String
        strscript = "<script langauage=JavaScript>"
        strscript += "window.open('regulatorviewmore.aspx?buysell=sells&for=');"
        strscript += "</script>"
        ClientScript.RegisterStartupScript(Me.GetType(), "newwin", strscript)
    End Sub




    Protected Sub ASPxButton4_Click(sender As Object, e As EventArgs) Handles ASPxButton4.Click
        Dim strscript As String
        strscript = "<script langauage=JavaScript>"
        strscript += "window.open('regulatorviewmore.aspx?buysell=buys&for=');"
        strscript += "</script>"
        ClientScript.RegisterStartupScript(Me.GetType(), "newwin", strscript)
    End Sub
End Class
