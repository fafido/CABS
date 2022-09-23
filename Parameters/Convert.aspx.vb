Partial Class Parameters_convert
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
            Page.MaintainScrollPositionOnPostBack = True
            If (Not IsPostBack) Then
                checkSessionState()


            End If
            If Session("finish") = "yes" Then
                Session("finish") = ""
                msgbox("Successfully Converted")
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub getdetails()
        cmd = New SqlCommand("select *,(select top 1 surname+' '+forenames from cds_router.dbo.Accounts_clients_web where cds_number=[CDSC].[dbo].[CashTrans_forex].cds_Number) as [CDS Number] from  [CDSC].[dbo].[CashTrans_forex] where TransType='Withdraw' and convert(date, datecreated)>='" + cmbfrom.Text + "' and convert(date, datecreated)<='" + cmbto.Text + "' and isnull(processed,'0')='0'", cn)
        Dim ds As New DataSet
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "companies")
        If ds.Tables(0).Rows.Count > 0 Then
            Gridview1.DataSource = ds
            Gridview1.DataBind()
        End If
    End Sub

    Protected Sub creditctrade(amount As String, cdsnumber As String)

        cmd = New SqlCommand("insert into [CDSC].[dbo].[CashTrans] ([description],TransType, Amount, DateCreated, TransStatus, CDS_Number) SELECT 'Forex Conversion','Conversion','" + amount + "',getdate(), '1','" + cdsnumber + "'   update cdsc.dbo.cashtrans_forex set processed='1' where id='" + Gridview1.SelectedValue.ToString + "'", cn)
        'cmd = New SqlCommand("insert into cdsc.dbo.pending_reversals values ('" + id.ToString + "', getdate(),'" + Session("Userid") + "')", cn)
        If cn.State = ConnectionState.Open Then
            cn.Close()
        End If
        cn.Open()
        Dim y As Integer = cmd.ExecuteNonQuery()
        cn.Close()
    End Sub
    Protected Sub ASPxButton7_Click(sender As Object, e As EventArgs) Handles ASPxButton7.Click
        getdetails()

    End Sub

    Protected Sub Gridview1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Gridview1.SelectedIndexChanged
        '  creditctrade(Gridview1.SelectedValue.ToString)
        ASPxPopupControl1.PopupHorizontalAlign = DevExpress.Web.ASPxClasses.PopupHorizontalAlign.WindowCenter
        ASPxPopupControl1.PopupVerticalAlign = DevExpress.Web.ASPxClasses.PopupVerticalAlign.WindowCenter
        ASPxPopupControl1.AllowDragging = True
        ASPxPopupControl1.ShowCloseButton = True
        ASPxPopupControl1.ShowOnPageLoad = True
        ' txtamount.Text = Gridview1.SelectedRow.Cells(3).Text.Trim
        txtctradeno.Text = Gridview1.SelectedRow.Cells(1).Text.Trim

    End Sub
    Protected Sub ASPxButton4_Click(sender As Object, e As EventArgs) Handles ASPxButton4.Click
        Try
            If txtamount.Text <> "" Then
                creditctrade(amount:=txtamount.Text, cdsnumber:=txtctradeno.Text)
            Else
                msgbox("Please enter amount!")
            End If
            getdetails()
            ASPxPopupControl1.ShowOnPageLoad = False

            msgbox("Successful")
        Catch ex As Exception
            msgbox(ex.Message)
        End Try

    End Sub
End Class
