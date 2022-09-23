Imports System.IO

Partial Class authorizeorders
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
            cmd = New SqlCommand("select * from testcds_router.dbo.pre_order_Live_rej where Action_='Authorize Transaction' and Orderstatus='OPEN'  and cds_ac_no in (select cds_number from accounts_clients where custodian='" + Session("Brokercode") + "')", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "tbl_MatchedOrders")
            If (ds.Tables(0).Rows.Count > 0) Then
                grdsellers.DataSource = ds.Tables(0)
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


    
   
    Public Sub finish()
      
    End Sub

    Protected Sub grdsellers_SelectedIndexChanged(sender As Object, e As EventArgs) Handles grdsellers.SelectedIndexChanged
        cmd = New SqlCommand("insert into testcds.dbo.order_live ([OrderType] ,[Company] ,[SecurityType],[CDS_AC_No] ,[Broker_Code] ,[Client_Type],[Tax] ,[Shareholder],[ClientName],[TotalShareHolding],[OrderStatus],[Create_date],[Deal_Begin_Date],[Expiry_Date] ,[Quantity],[BasePrice] ,[AvailableShares],[OrderPref],[OrderAttribute],[Marketboard] ,[TimeInForce],[OrderQualifier],[BrokerRef] ,[ContraBrokerId] ,[MaxPrice],[MiniPrice],[Flag_oldorder] ,[OrderNumber] ,[Currency] ,[FOK] ,[Affirmation])  select [OrderType] ,[Company] ,[SecurityType],[CDS_AC_No] ,[Broker_Code] ,[Client_Type],[Tax] ,[Shareholder],[ClientName],[TotalShareHolding],[OrderStatus],[Create_date],[Deal_Begin_Date],[Expiry_Date] ,[Quantity],[BasePrice] ,[AvailableShares],[OrderPref],[OrderAttribute],[Marketboard] ,[TimeInForce],[OrderQualifier],[BrokerRef] ,[ContraBrokerId] ,[MaxPrice],[MiniPrice],[Flag_oldorder] ,[OrderNumber] ,[Currency] ,[FOK] ,[Affirmation] from testcds_router.dbo.Pre_Order_Live_rej where OrderNo='" + grdsellers.SelectedValue.ToString + "' update testcds_router.dbo.pre_order_live_rej set  orderstatus='Authorized' where orderno='" + grdsellers.SelectedValue.ToString + "' ", cn)
        If (cn.State = ConnectionState.Open) Then
            cn.Close()
        End If
        cn.Open()
        cmd.ExecuteNonQuery()
        cn.Close()
        msgbox("Order Successfully Authorized")
        getpendingauth()


    End Sub
End Class
