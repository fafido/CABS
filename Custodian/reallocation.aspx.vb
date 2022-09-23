Partial Class TransferSec_reallocation
    Inherits System.Web.UI.Page
    Dim constr As String = (System.Configuration.ConfigurationManager.AppSettings("connpath"))
    Dim cn As New SqlConnection(constr)
    Dim adp As SqlDataAdapter
    Dim cmd As SqlCommand
    Dim myreport As CrystalDecisions.CrystalReports.Engine.ReportDocument
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

                ASPxRadioButtonList1.SelectedIndex = 0


            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub getCompany()
        Try
            Dim ds As New DataSet
            'cmd = New SqlCommand("select ID , Account1 as [Buyer],(select isnull(surname,'')+' '+isnull(forenames,'') from accounts_clients where cds_number=tblMatchedOrders.Account1) as [Buyer Names],  Account2 as [Seller], (select isnull(surname,'')+' '+isnull(forenames,'') from accounts_clients where cds_number=tblMatchedOrders.Account2) as [Seller Names], tradeprice as Price, tradeqty as [Quantity], SettlementDate from tblmatchedorders", cn)
            cmd = New SqlCommand("select ID , Account1 as [Buyer],(select isnull(surname,'')+' '+isnull(forenames,'') from accounts_clients where cds_number=tblMatchedOrders.Account1) as [Buyer Names],  Account2 as [Seller], (select isnull(surname,'')+' '+isnull(forenames,'') from accounts_clients where cds_number=tblMatchedOrders.Account2) as [Seller Names], tradeprice as Price, tradeqty as [Quantity], SettlementDate from tblmatchedorders where (isnull(Ack,'')<>'SETTLED' or Error_details is not NULL) AND settlementdate>=convert(date,getdate()) and convert(date,date_posted)<=convert(date,'" + txtdateto.Text + "') and convert(date,Date_posted)>=convert(date,'" + txtdatefrom.Text + "') AND isnull(ack,'')<>'SETTLED'", cn)


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
        ASPxTextBox1.Text = grdApps.SelectedRow.Cells(1).Text.Trim
        ' ASPxDateEdit1.Text = grdApps.SelectedRow.Cells(8).Text.Trim

        'Response.Redirect("AccountsCreationsB.aspx?acctype=" + grdApps.SelectedRow.Cells(6).Text.Trim + "&ID=" + grdApps.SelectedRow.Cells(2).Text.Trim + "&cds=" + grdApps.SelectedRow.Cells(1).Text.Trim + "")
    End Sub

    Protected Sub ASPxButton3_Click(sender As Object, e As EventArgs) Handles ASPxButton3.Click
        getCompany()

    End Sub

    Protected Sub ASPxButton4_Click(sender As Object, e As EventArgs) Handles ASPxButton4.Click
        Dim strsql As String
        Dim type As String
        If ASPxRadioButtonList1.SelectedIndex = 0 Then
            strsql = "account1"
            type = "buyer"
        Else
            strsql = "account2"
            type = "seller"
        End If
        trail(strsql)



        cmd = New SqlCommand("update  tblmatchedorders set " + strsql + "='" + lstclients.SelectedItem.Value.ToString + "', type='" + type + "', AllocatedAccount= '" + lstclients.SelectedItem.Value.ToString + "' where id='" + ASPxTextBox1.Text + "'", cn)
        If (cn.State = ConnectionState.Open) Then
            cn.Close()
        End If
        cn.Open()
        cmd.ExecuteNonQuery()
        cn.Close()
        getCompany()
        msgbox("Updated")
        ASPxPopupControl1.ShowOnPageLoad = False


    End Sub
    Public Sub trail(ByVal original As String)

        cmd = New SqlCommand("update  tblmatchedorders set  originalaccount=" + original.ToString + " where id='" + ASPxTextBox1.Text + "'", cn)
        If (cn.State = ConnectionState.Open) Then
            cn.Close()
        End If
        cn.Open()
        cmd.ExecuteNonQuery()
        cn.Close()


    End Sub

    Protected Sub ASPxButton5_Click(sender As Object, e As EventArgs) Handles ASPxButton5.Click
        Dim ds As New DataSet
        cmd = New SqlCommand("select cds_number, surname+' '+forenames+' '+cds_number AS NAMES from accounts_clients where surname+' '+forenames+' '+cds_number like '%" + txtsearch.Text + "%'", cn)
        ' cmd = New SqlCommand("select ID , Account1 as [Buyer],(select isnull(surname,'')+' '+isnull(forenames,'') from accounts_clients where cds_number=tblMatchedOrders.Account1) as [Buyer Names],  Account2 as [Seller], (select isnull(surname,'')+' '+isnull(forenames,'') from accounts_clients where cds_number=tblMatchedOrders.Account2) as [Seller Names], tradeprice as Price, tradeqty as [Quantity], SettlementDate from tblmatchedorders where (Ack<>'SETTLED' or Error_details is not NULL) AND  date_posted<='" + txtdateto.Text + "' and Date_posted>='" + txtdatefrom.Text + "'", cn)

        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "para_company")
        If ds.Tables("para_company").Rows.Count > 0 Then
            lstclients.DataSource = ds
            lstclients.TextField = "NAMES"
            lstclients.ValueField = "cds_number"
            lstclients.DataBind()
        End If
    End Sub

End Class
