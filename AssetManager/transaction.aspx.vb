
Partial Class Reporting_transaction
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
        If Session("UserName").ToString = "" Then
            Session.Abandon()
            Response.Cache.SetCacheability(HttpCacheability.NoCache)
            Response.Buffer = True
            Response.ExpiresAbsolute = DateTime.Now.AddDays(-1.0)
            Response.Expires = -1000
            Response.CacheControl = "no-cache"
            Response.Redirect("~/loginsystem.aspx", True)
        End If
        Try
            Page.MaintainScrollPositionOnPostBack = True
            If (Not IsPostBack) Then
                checkSessionState()
                Getparticipants()
                Getproduce()
                'GetHolder()
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub




    Public Sub Getparticipants()
        Try
            Dim ds As New DataSet
            Dim status As String
            cmd = New SqlCommand("SELECT DISTINCT C.Status FROM( select 'WITHDRAWAL' as Category,wd.Receiptid AS [EWR No.], w.Commodity as [Produce], w.Grade, wd.amount_to_withdraw AS Quantity, w.Price,CASE WHEN wd.ApprovedBy is NULL AND wd.Rejected IS NULL THEN 'Pending' when wd.ApprovedBy is NOT NULL AND wd.Rejected IS NULL then 'Approved' When wd.ApprovedBy is NULL AND wd.Rejected IS NOT NULL THEN'Rejected' end as [Status],wd.ApprovedDate as CaptureDate from withdrawals wd join wr w on wd.ReceiptID=w.ReceiptNo UNION select 'TRANSFER' as Category,s.Receiptid AS [EWR No.], w.Commodity as [Produce], w.Grade, s.amount_to_transfer AS Quantity, w.Price,CASE WHEN s.ApprovedBy is NULL AND s.Rejected IS NULL THEN 'Pending' when s.ApprovedBy is NOT NULL AND s.Rejected IS NULL then 'Approved' When s.ApprovedBy is NULL AND s.Rejected IS NOT NULL THEN'Rejected' end as [Status],s.ApprovedDate as CaptureDate  from share_transfer s join wr w ON s.ReceiptID=w.ReceiptNo UNION Select 'SPLIT' as Category,b.WRParentPrefix+'-'+b.WRChildSuffix AS [EWR No.],a.Commodity as [Produce],a.Grade, b.ChildQTY AS Quantity,'0' as Price ,CASE WHEN b.[State]='A' THEN 'Approved' when b.[State]='I' then 'Pending' else 'Rejected' end as [Status],b.AuthDate as CaptureDate from WR a inner join tblWRSplits b on a.ReceiptNo= b.OriginalWRNo UNION Select 'PLEDGE' as Category,b.Collateral AS [EWR No.],a.Commodity as [Produce],a.Grade, b.AvailableQuantity AS Quantity,B.Unit_Price as Price,CASE WHEN b.Approved is NULL AND B.Rejected IS NULL THEN 'Pending' when b.Approved is NOT NULL AND b.Rejected IS NULL then 'Approved' When b.Approved is NULL AND b.Rejected IS NOT NULL THEN'Rejected' end as [Status],b.CapturedDate as CaptureDate from WR a inner join BorrowingRequest b on a.ReceiptNo= b.Collateral )C", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds)

            cmdparticipants.DataSource = ds
            cmdparticipants.TextField = "Status"
            cmdparticipants.ValueField = "Status"
            cmdparticipants.DataBind()
            cmdparticipants.Items.Insert(0, New DevExpress.Web.ASPxEditors.ListEditItem("All", "All"))

        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

  
    Public Sub Getproduce()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select distinct(commodity) from wr where isnull (commodity,'') <>''", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds)
            cmdpart.DataSource = ds
            cmdpart.TextField = "commodity"
            cmdpart.ValueField = "commodity"
            cmdpart.DataBind()
            cmdpart.Items.Insert(0, New DevExpress.Web.ASPxEditors.ListEditItem("All", "All"))
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    ' Public Sub GetHolder()
    '    Try
    '        Dim ds As New DataSet
    '        cmd = New SqlCommand("select distinct(Holder) from wr where isnull (Holder,'') <>''", cn)
    '        adp = New SqlDataAdapter(cmd)
    '        adp.Fill(ds)
    '        cmdhold.DataSource = ds
    '        cmdhold.DataTextField = "Holder"
    '        cmdhold.DataBind()
    '    Catch ex As Exception
    '        msgbox(ex.Message)
    '    End Try
    'End Sub

    Protected Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        Try


            If txtDateFrom.Text = "" Or txtDateTo.Text = "" Then
                msgbox("Invalid Report Parameters Selected")
                Exit Sub
            End If




            Dim strscript As String
            strscript = "<script langauage=JavaScript>"
            strscript += "window.open('rpttransaction.aspx?ActivityPerformed=" & cmbactivity.SelectedItem.Text & "&Datefrom=" & txtDateFrom.Text & "&commodity=" & cmdpart.SelectedItem.Text & "&status=" & cmdparticipants.SelectedItem.Text & "&Dateto=" & txtDateTo.Text & "');"
            strscript += "</script>"
            ClientScript.RegisterStartupScript(Me.GetType(), "newwin", strscript)

        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

End Class
