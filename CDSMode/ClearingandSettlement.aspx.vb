Imports System.IO
Imports System.Array
Partial Class CDSMode_ClearingandSettlement
    Inherits System.Web.UI.Page
    Dim cnstr As String = (System.Configuration.ConfigurationManager.AppSettings("connpath"))
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

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If (Not IsPostBack) Then
                GetOTCTrades()
                GetBrokersNet()

            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Public Sub GetOTCTrades()
        Try
            Dim ds As New DataSet
            'cmd = New SqlCommand("select * from OTC_Data_Import ", cn)
            cmd = New SqlCommand("select company as [Company], BuyOrderNum as [Buyer Order No.], Quantity as [Quantity], SellOrderNum as [Seller Order No.], Price as [Base Price], case SettlementStatus when 1 then 'PENDING' when 2 then 'CONFIRMED' ELSE 'FAILED' END as [Clearance Status] from OTC_Data_Import ", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "OTC_Data_Import")
            If (ds.Tables(0).Rows.Count > 0) Then
                grdOrdersSummary.DataSource = ds.Tables(0)
                grdOrdersSummary.DataBind()
            Else
                grdOrdersSummary.DataSource = Nothing
                grdOrdersSummary.DataBind()
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub GetBrokersNet()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select OrdersSummary .Company as company ,OrdersSummary.OrderType  , sum(OrdersSummary.Order_Quantity) as [Quantity], sum(OrdersSummary .BasePrice * OrdersSummary.Order_Quantity) as [Amount], OrdersSummary .PurchasingBroker as [Broker] from OrdersSummary where Company in (select distinct (company) from OTC_Data_Import) group by OrdersSummary .PurchasingBroker , OrdersSummary .Company , OrdersSummary.OrderType ", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "ordersSummary")
            If (ds.Tables(0).Rows.Count > 0) Then
                grdBrokersNet.DataSource = ds.Tables(0)
                grdBrokersNet.DataBind()
            Else
                grdBrokersNet.DataSource = Nothing
                grdBrokersNet.DataBind()
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub


End Class
