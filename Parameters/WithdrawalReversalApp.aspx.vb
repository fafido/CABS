Partial Class Parameters_withdrawalreversalApp
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
                getdetails()


            End If
            If Session("finish") = "true" Then
                Session("finish") = ""
                msgbox("Successfully Reversed")
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub getdetails()
        cmd = New SqlCommand("select *,(select top 1 surname+' '+forenames from cds_router.dbo.Accounts_clients_web where cds_number=[CDSC].[dbo].[CashTrans].cds_Number) as [CDS Number] from  [CDSC].[dbo].[CashTrans] where TransType='Withdraw'  and id not in (select reversal_id from cdsc.dbo.reversed_withdrawals) and id in (select reversal_id from cdsc.dbo.pending_reversals)", cn)
        Dim ds As New DataSet
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "companies")
        If ds.Tables(0).Rows.Count > 0 Then
            Gridview1.DataSource = ds
            Gridview1.DataBind()
        Else
            msgbox("No pending Reversals")
        End If
    End Sub

    Protected Sub creditctrade(id As String)

        cmd = New SqlCommand("insert into [CDSC].[dbo].[CashTrans] ([description],TransType, Amount, DateCreated, TransStatus, CDS_Number) SELECT 'REVERSAL','Withdrawal Reversal',amount*-1,getdate(), '1',cds_number  FROM [CDSC].[dbo].[CashTrans] WHERE ID='" + id + "'    insert into cdsc.dbo.reversed_withdrawals (reversal_id, date_created, reversed_by) values ('" + Gridview1.SelectedValue.ToString + "',getdate(),'" + Session("Userid") + "')", cn)


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
        creditctrade(Gridview1.SelectedValue.ToString)
        getdetails()
        msgbox("Successfully Reversed!")
    End Sub
End Class
