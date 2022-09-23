Partial Class TransferSec_changesettlement
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

                '  getCompany()

            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub getCompany()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select ID , Account1 as [Buyer],(select isnull(surname,'')+' '+isnull(forenames,'') from accounts_clients where cds_number=tblMatchedOrders.Account1) as [Buyer Names],  Account2 as [Seller], (select isnull(surname,'')+' '+isnull(forenames,'') from accounts_clients where cds_number=tblMatchedOrders.Account2) as [Seller Names], tradeprice as Price, tradeqty as [Quantity], SettlementDate from tblmatchedorders where (isnull(Ack,'')<>'SETTLED' or Error_details is not NULL) AND settlementdate>=convert(date,getdate()) and convert(date,date_posted)<=convert(date,'" + txtdateto.Text + "') and convert(date,Date_posted)>=convert(date,'" + txtdatefrom.Text + "') AND isnull(ack,'')<>'SETTLED'", cn)
            ' cmd = New SqlCommand("select ID , Account1 as [Buyer],(select isnull(surname,'')+' '+isnull(forenames,'') from accounts_clients where cds_number=tblMatchedOrders.Account1) as [Buyer Names],  Account2 as [Seller], (select isnull(surname,'')+' '+isnull(forenames,'') from accounts_clients where cds_number=tblMatchedOrders.Account2) as [Seller Names], tradeprice as Price, tradeqty as [Quantity], SettlementDate from tblmatchedorders where (Ack<>'SETTLED' or Error_details is not NULL) AND  date_posted<='" + txtdateto.Text + "' and Date_posted>='" + txtdatefrom.Text + "'", cn)

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
        If ASPxDateEdit1.Text = "" Then
            msgbox("Please select the date!")
            Exit Sub
        Else
            cmd = New SqlCommand("update  tblmatchedorders set settlementdate='" + ASPxDateEdit1.Text + "' where id='" + ASPxTextBox1.Text + "'", cn)
            If (cn.State = ConnectionState.Open) Then
                cn.Close()
            End If
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()
            getCompany()
            ASPxPopupControl1.ShowOnPageLoad = False

            msgbox("Successfully Updated!")
        End If
    End Sub
End Class
