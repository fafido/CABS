Partial Class TransferSec_SettlementStatsDashBoard
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
    Public Sub GetSellersDashData(ByVal Datefrom As Date, ByVal DateTo As Date)
        Try
            Dim ds As New DataSet
            'cmd = New SqlCommand("select Tbl_MatchedOrders .Sellercdsno as [CDS No.] , Accounts_Clients.Surname +' '+Accounts_Clients .Forenames as [Client], Tbl_MatchedOrders .Quantity as [Quantity], Tbl_MatchedOrders.DealPrice as [Price], Tbl_MatchedOrders .Trade as [Trade Date] from Tbl_MatchedOrders , Accounts_Clients where Tbl_MatchedOrders.Sellercdsno = Accounts_Clients .CDS_Number and trade between '" & Datefrom & "' and '" & DateTo & "'", cn)
            cmd = New SqlCommand("select tbl_matchedOrders.Company as Company, Tbl_MatchedOrders .Sellercdsno as [CDS No.] ,  replace(CAST(CONVERT(varchar, CAST(tbl_matchedOrders.quantity AS money), 1) AS varchar),'.00','') as [Quantity], Tbl_MatchedOrders.DealPrice as [Price], convert(varchar,Tbl_MatchedOrders .Trade,103) as [Trade Date] from Tbl_MatchedOrders , Accounts_Clients where Tbl_MatchedOrders.Sellercdsno = Accounts_Clients .CDS_Number and trade between '" & Datefrom & "' and '" & DateTo & "'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "tbl_MatchedOrders")
            If (ds.Tables(0).Rows.Count > 0) Then
                grdSellers.DataSource = ds.Tables(0)
                grdSellers.DataBind()
            Else
                grdSellers.DataSource = Nothing
                grdSellers.DataBind()
            End If

        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub GetBuyersDashData(ByVal Datefrom As Date, ByVal DateTo As Date)
        Try
            Dim ds As New DataSet
            'cmd = New SqlCommand("select Tbl_MatchedOrders .Buyercdsno as [CDS No.] , Accounts_Clients.Surname +' '+Accounts_Clients .Forenames as [Client], Tbl_MatchedOrders .Quantity as [Quantity], Tbl_MatchedOrders.DealPrice as [Price], Tbl_MatchedOrders .Trade as [Trade Date] from Tbl_MatchedOrders , Accounts_Clients where Tbl_MatchedOrders.Buyercdsno  = Accounts_Clients .CDS_Number and trade between '" & Datefrom & "' and '" & DateTo & "'", cn)
            cmd = New SqlCommand("select tbl_MatchedOrders.company as Company,Tbl_MatchedOrders .Buyercdsno as [CDS No.] ,  replace(CAST(CONVERT(varchar, CAST(tbl_matchedOrders.quantity AS money), 1) AS varchar),'.00','') as [Quantity],Tbl_MatchedOrders.DealPrice as [Price], convert(varchar,Tbl_MatchedOrders .Trade,103) as [Trade Date] from Tbl_MatchedOrders , Accounts_Clients where Tbl_MatchedOrders.Buyercdsno  = Accounts_Clients .CDS_Number and trade between '" & Datefrom & "' and '" & DateTo & "'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "tbl_MatchedOrders")
            If (ds.Tables(0).Rows.Count > 0) Then
                grdBuyers.DataSource = ds.Tables(0)
                grdBuyers.DataBind()
            Else
                grdBuyers.DataSource = Nothing
                grdBuyers.DataBind()

            End If

        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub GetPendingSettlements(ByVal Datefrom As Date, ByVal Dateto As Date)
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select tbl_SettlementSummary.company as Company, tbl_SettlementSummary.cds_number, tbl_SettlementSummary.client_name ,convert(varchar,Tbl_SettlementSummary .Settlement_date,103) as [Date of Trade], replace(CAST(CONVERT(varchar, CAST(tbl_settlementSummary.quantity AS money), 1) AS varchar),'.00','') as Quantity , tbl_SettlementSummary .Amount_due , convert(varchar, tbl_SettlementSummary .Settlement_date,103) as [Date of Settlement] , case tbl_SettlementSummary .OrderType when 'B' then 'Purchase' when 'S' then 'Sell' else 'Unknown' end as [Order Type] from tbl_SettlementSummary  where Status_Flag ='O' AND trade_date between '" & Datefrom & "' and '" & Dateto & "'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "tbl_SettlementSummary")
            If (ds.Tables(0).Rows.Count > 0) Then
                grdPendingSettlements.DataSource = ds.Tables(0)
                grdPendingSettlements.DataBind()
            Else
                grdPendingSettlements.DataSource = Nothing
                grdPendingSettlements.DataBind()
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub GetSettledRecords(ByVal datefrom As Date, ByVal dateto As Date)
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select trans.company as Company, trans.CDS_Number, Accounts_Clients.Surname+' '+Accounts_Clients .Forenames as [Client],replace(CAST(CONVERT(varchar, CAST(sum(shares) AS money), 1) AS varchar),'.00','') as [Quantity]   from trans, Accounts_Clients where trans.Created_by ='SETTLEMT' and trans.CDS_Number = Accounts_Clients.CDS_Number and trans.Date_Created between '" & datefrom & "' and '" & dateto & "' group by Accounts_Clients.Surname , Accounts_Clients .Forenames , trans.CDS_Number, trans.company ", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "trans")
            If (ds.Tables(0).Rows.Count > 0) Then
                grdSettledTrades.DataSource = ds.Tables(0)
                grdSettledTrades.DataBind()
            Else
                grdSettledTrades.DataSource = Nothing
                grdSettledTrades.DataBind()
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
                checkSessionState()
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub btnView_Click(sender As Object, e As EventArgs) Handles btnView.Click
        Try
            If (txtDateFrom.Text = "" Or txtDateTo.Text = "") Then
                msgbox("Enter a correct date range")
                Exit Sub
            Else
                GetBuyersDashData(txtDateFrom.Text, txtDateTo.Text)
                GetSellersDashData(txtDateFrom.Text, txtDateTo.Text)
                GetPendingSettlements(txtDateFrom.Text, txtDateTo.Text)
                GetSettledRecords(txtDateFrom.Text, txtDateTo.Text)
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
End Class
