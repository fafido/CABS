Partial Class TransferSec_ordercancel
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
    Public Sub checkSessionState()
        Try

        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Session("finish") = "yes" Then
                Session("finish") = ""
                msgbox("Batch successfully captured")
            End If
            Page.MaintainScrollPositionOnPostBack = True
            If (Not IsPostBack) Then
                checkSessionState()



                getbrokers()


            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub getdetails()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select Brokerref as OrderNo,OrderType, Quantity, Baseprice, Company, CDS_AC_nO AS CDS,ClientName, convert(date, Create_dATE) AS [Date]  from CDS_ROUTER.DBO.pendingcancellations where sendstatus<>'Matched' and brokerref in (select brokerref from testcds_router.dbo.pre_order_Live where broker_code='" + cmbbroker.SelectedItem.Value.ToString + "')", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "para_company")
            If ds.Tables("para_company").Rows.Count > 0 Then
                grdApps.DataSource = ds
                grdApps.DataBind()
            Else
                grdApps.DataSource = Nothing
                grdApps.DataBind()
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub grdApps_SelectedIndexChanged(sender As Object, e As EventArgs) Handles grdApps.SelectedIndexChanged
      
        

        cmd = New SqlCommand("insert into cds_router.dbo.successful_cancellation values ('" + grdApps.SelectedRow.Cells(1).Text.Trim + "')", cn)
        If (cn.State = ConnectionState.Open) Then
            cn.Close()
        End If
        cn.Open()
        cmd.ExecuteNonQuery()
        cn.Close()

        getdetails()

        msgbox("Successfully Cancelled")
    End Sub

    Protected Sub ASPxButton3_Click(sender As Object, e As EventArgs) Handles ASPxButton3.Click
        getdetails()


    End Sub

    Protected Sub ASPxButton4_Click(sender As Object, e As EventArgs) Handles ASPxButton4.Click


  

    End Sub


    
    Public Sub getbrokers()
        Dim ds As New DataSet
        cmd = New SqlCommand("select company_code from cds_router.dbo.client_companies where company_type='BROKER'", cn)
        ' cmd = New SqlCommand("select ID , Account1 as [Buyer],(select isnull(surname,'')+' '+isnull(forenames,'') from accounts_clients where cds_number=tblMatchedOrders.Account1) as [Buyer Names],  Account2 as [Seller], (select isnull(surname,'')+' '+isnull(forenames,'') from accounts_clients where cds_number=tblMatchedOrders.Account2) as [Seller Names], tradeprice as Price, tradeqty as [Quantity], SettlementDate from tblmatchedorders where (Ack<>'SETTLED' or Error_details is not NULL) AND  date_posted<='" + txtdateto.Text + "' and Date_posted>='" + txtdatefrom.Text + "'", cn)

        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "para_company")
        If ds.Tables("para_company").Rows.Count > 0 Then
            cmbbroker.DataSource = ds
            cmbbroker.TextField = "company_code"
            cmbbroker.ValueField = "company_code"
            cmbbroker.DataBind()
        End If
    End Sub


    Protected Sub ASPxButton3_Click1(sender As Object, e As EventArgs)

    End Sub
End Class
