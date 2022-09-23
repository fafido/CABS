Partial Class TransferSec_addtrades
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


                getcompanies()
                getbrokers()


            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub getdetails()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select Broker_Code as [Broker],BrokerRef, ClientName, Company ,Quantity, Baseprice,OrderStatus  from testcds_router.dbo.pre_order_Live where convert(date, create_date)>='" + txtdatefrom.Text + "' and convert(date, create_date)<='" + txtdateto.Text + "' and broker_code='" + cmbbroker.SelectedItem.Text + "' and company='" + cmbcompany.SelectedItem.Text + "' and orderstatus in ('OPEN','PENDING CANCELLATION') order by orderno desc", cn)
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
        ASPxPopupControl1.PopupHorizontalAlign = DevExpress.Web.ASPxClasses.PopupHorizontalAlign.WindowCenter
        ASPxPopupControl1.PopupVerticalAlign = DevExpress.Web.ASPxClasses.PopupVerticalAlign.WindowCenter
        ASPxPopupControl1.AllowDragging = True
        ASPxPopupControl1.ShowCloseButton = True
        ASPxPopupControl1.ShowOnPageLoad = True
        txtbrokerref.Text = grdApps.SelectedRow.Cells(2).Text.Trim
        txtquantity.Text = grdApps.SelectedRow.Cells(5).Text.Trim
        txtprice.Text = grdApps.SelectedRow.Cells(6).Text.Trim

        ' ASPxDateEdit1.Text = grdApps.SelectedRow.Cells(8).Text.Trim

        'Response.Redirect("AccountsCreationsB.aspx?acctype=" + grdApps.SelectedRow.Cells(6).Text.Trim + "&ID=" + grdApps.SelectedRow.Cells(2).Text.Trim + "&cds=" + grdApps.SelectedRow.Cells(1).Text.Trim + "")
    End Sub

    Protected Sub ASPxButton3_Click(sender As Object, e As EventArgs) Handles ASPxButton3.Click
        getdetails()


    End Sub

    Protected Sub ASPxButton4_Click(sender As Object, e As EventArgs) Handles ASPxButton4.Click
       

        cmd = New SqlCommand("testcds_router.dbo.Update_matched", cn)
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.AddWithValue("@brokerref", txtbrokerref.Text)
        cmd.Parameters.AddWithValue("@quantity", txtquantity.Text)
        cmd.Parameters.AddWithValue("@date_created", txtmatchdate.Text)
        cmd.Parameters.AddWithValue("@exec_price", txtprice.Text)
        cmd.Parameters.AddWithValue("@zse_exec_id", txtexchangeref.Text)
        If (cn.State = ConnectionState.Open) Then
            cn.Close()
        End If
        cn.Open()
        cmd.ExecuteNonQuery()
        cn.Close()
        getdetails()
        msgbox("Updated")
        ASPxPopupControl1.ShowOnPageLoad = False


    End Sub

  
    Public Sub getcompanies()
        Dim ds As New DataSet
        cmd = New SqlCommand("select company from cds_router.dbo.para_company", cn)
        ' cmd = New SqlCommand("select ID , Account1 as [Buyer],(select isnull(surname,'')+' '+isnull(forenames,'') from accounts_clients where cds_number=tblMatchedOrders.Account1) as [Buyer Names],  Account2 as [Seller], (select isnull(surname,'')+' '+isnull(forenames,'') from accounts_clients where cds_number=tblMatchedOrders.Account2) as [Seller Names], tradeprice as Price, tradeqty as [Quantity], SettlementDate from tblmatchedorders where (Ack<>'SETTLED' or Error_details is not NULL) AND  date_posted<='" + txtdateto.Text + "' and Date_posted>='" + txtdatefrom.Text + "'", cn)

        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "para_company")
        If ds.Tables("para_company").Rows.Count > 0 Then
            cmbcompany.DataSource = ds
            cmbcompany.TextField = "company"
            cmbcompany.ValueField = "company"
            cmbcompany.DataBind()
        End If
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

   
End Class
