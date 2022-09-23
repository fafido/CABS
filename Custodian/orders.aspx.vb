Imports System.Data
Imports System.Data.SqlClient
Partial Class Orders
    Inherits System.Web.UI.Page
    Dim constr As String = (System.Configuration.ConfigurationManager.AppSettings("connpath"))
    Dim cn As New SqlConnection(constr)
    Dim cmd As SqlCommand
    Dim adp As SqlDataAdapter
    Dim ds As New DataSet
    Dim validate As Boolean = False
    Dim maxholder As Integer = 0
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
        Page.MaintainScrollPositionOnPostBack = True
        If (Not IsPostBack) Then

        Else
            Try


                If RadioButtonList1.SelectedItem.Text = "All Warehouse Receipts" Then
                    GetAll(dtfrom.Text, dtto.Text)
                ElseIf RadioButtonList1.SelectedItem.Text = "Expired" Then
                    GetAllexpired(dtfrom.Text, dtto.Text)
                ElseIf RadioButtonList1.SelectedItem.Text = "Approved" Then
                    GetAllApproved(dtfrom.Text, dtto.Text)
                ElseIf RadioButtonList1.SelectedItem.Text = "Pending Approval" Then
                    GetAllPENDING(dtfrom.Text, dtto.Text)
                ElseIf RadioButtonList1.SelectedItem.Text = "Stolen" Then
                    GetAllstatuss(dtfrom.Text, dtto.Text, "Stolen")
                ElseIf RadioButtonList1.SelectedItem.Text = "Cancelled" Then
                    GetAllstatuss(dtfrom.Text, dtto.Text, "Cancelled")
                ElseIf RadioButtonList1.SelectedItem.Text = "Lost" Then
                    GetAllstatuss(dtfrom.Text, dtto.Text, "Lost")

                End If
            Catch ex As Exception

            End Try
        End If
        If Session("finish") = "yes" Then
            Session("finish") = ""
            msgbox("Sent for Approval")
            else
        End If
    End Sub




    Public Sub Getorders()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select BrokerRef as [Order Ref],CDS_ac_no as [CDS Number], Broker_Code as [Broker], ClientName,convert(date, create_date) as [Date Created], Quantity, BasePrice as [Price], Quantity*BasePrice as [Value]   from testcds_ROUTER.dbo.Pre_Order_Live ", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "para_lendingRules")
            If (ds.Tables(0).Rows.Count > 0) Then
                grdRules.DataSource = ds.Tables(0)
                grdRules.DataBind()
            Else
                grdRules.DataSource = Nothing
                grdRules.DataBind()
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Public Sub GetAll(opendate As String, closedate As String)
        Dim ds As New DataSet
        cmd = New SqlCommand("select (select top 1 operator from warehousecreation where warehousecode=w.warehouse) as [Warehouse Operator],(select top 1 WarehouseName from warehousecreation where warehousecode=w.warehouse) as [Warehouse], a.CDS_Number AS [ClientNo],a.Surname+' '+a.Forenames as [Names], Commodity as [Commodity],Grade, ReceiptNo, InsurancePolicy, Quantity, 'Metric Tonnes' AS UnitMeasure, Convert(date, date_issued) as [Issue Date], Convert(date, expiry) as [Expiry], w.[Status], case w.[Status] when 'PLEDGED'  then (select top 1 ApprovedBy from BorrowingRequest where Collateral=w.receiptno and [status]='PLEDGED' order by id desc) when 'SPLIT' then (select top 1 Inputter  from tblWRSplits where OriginalWRNo=w.ReceiptNo and [state]='A' order by id desc) when 'WITHDRAWN' then (select TOP 1 CapturedBy  from withdrawals where ReceiptID=w.ReceiptNo AND ApprovedBy is not NULL) else  Issued_By end as [Initiator]    from WR w, Accounts_Clients a WHERE A.cds_number=w.holder  and Convert(date, date_issued)>='" + opendate + "' and Convert(date, date_issued)<='" + closedate + "'", cn)
        adp = New SqlDataAdapter(cmd)
        cmd.CommandTimeout = 99999
        adp.Fill(ds, "para_lendingRules")
        If (ds.Tables(0).Rows.Count > 0) Then
            grdRules.DataSource = ds.Tables(0)
            grdRules.DataBind()
        Else
            grdRules.DataSource = Nothing
            grdRules.DataBind()
        End If
        ' ''Catch ex As Exception
        ' ''    msgbox(ex.Message)
        ' ''End Try
    End Sub
    Public Sub GetAllexpired(opendate As String, closedate As String)
        Dim ds As New DataSet
        cmd = New SqlCommand("select (select top 1 operator from warehousecreation where warehousecode=w.warehouse) as [Warehouse Operator],(select top 1 WarehouseName from warehousecreation where warehousecode=w.warehouse) as [Warehouse], a.CDS_Number AS [ClientNo],a.Surname+' '+a.Forenames as [Names],Commodity as [Commodity],Grade, ReceiptNo, InsurancePolicy, Quantity, 'Metric Tonnes' AS UnitMeasure, Convert(date, date_issued) as [Issue Date], Convert(date, expiry) as [Expiry], case w.[Status] when 'PLEDGED'  then (select top 1 ApprovedBy from BorrowingRequest where Collateral=w.receiptno and [status]='PLEDGED' order by id desc) when 'SPLIT' then (select top 1 Inputter  from tblWRSplits where OriginalWRNo=w.ReceiptNo and [state]='A' order by id desc) when 'WITHDRAWN' then (select TOP 1 CapturedBy  from withdrawals where ReceiptID=w.ReceiptNo AND ApprovedBy is not NULL) else  Issued_By end as [Initiator]   from WR w, Accounts_Clients a WHERE A.cds_number=w.holder and expiry<convert(date,getdate())  and Convert(date, date_issued)>='" + opendate + "' and Convert(date, date_issued)<='" + closedate + "'", cn)
        adp = New SqlDataAdapter(cmd)
        cmd.CommandTimeout = 99999
        adp.Fill(ds, "para_lendingRules")
        If (ds.Tables(0).Rows.Count > 0) Then
            grdRules.DataSource = ds.Tables(0)
            grdRules.DataBind()
        Else
            grdRules.DataSource = Nothing
            grdRules.DataBind()
        End If
        ' ''Catch ex As Exception
        ' ''    msgbox(ex.Message)
        ' ''End Try
    End Sub
    Public Sub GetAllApproved(opendate As String, closedate As String)
        Dim ds As New DataSet
        cmd = New SqlCommand("select (select top 1 operator from warehousecreation where warehousecode=w.warehouse) as [Warehouse Operator],(select top 1 WarehouseName from warehousecreation where warehousecode=w.warehouse) as [Warehouse],a.CDS_Number AS [ClientNo],a.Surname+' '+a.Forenames as [Names], Commodity as [Commodity],Grade, ReceiptNo, InsurancePolicy, Quantity, 'Metric Tonnes' AS UnitMeasure, Convert(date, date_issued) as [Issue Date], Convert(date, expiry) as [Expiry], case w.[Status] when 'PLEDGED'  then (select top 1 ApprovedBy from BorrowingRequest where Collateral=w.receiptno and [status]='PLEDGED' order by id desc) when 'SPLIT' then (select top 1 Inputter  from tblWRSplits where OriginalWRNo=w.ReceiptNo and [state]='A' order by id desc) when 'WITHDRAWN' then (select TOP 1 CapturedBy  from withdrawals where ReceiptID=w.ReceiptNo AND ApprovedBy is not NULL) else  Issued_By end as [Initiator]    from WR w, Accounts_Clients a WHERE A.cds_number=w.holder and approvedby is not NULL and Convert(date, date_issued)>='" + opendate + "' and Convert(date, date_issued)<='" + closedate + "'", cn)
        adp = New SqlDataAdapter(cmd)
        cmd.CommandTimeout = 99999
        adp.Fill(ds, "para_lendingRules")
        If (ds.Tables(0).Rows.Count > 0) Then
            grdRules.DataSource = ds.Tables(0)
            grdRules.DataBind()
        Else
            grdRules.DataSource = Nothing
            grdRules.DataBind()
        End If
        ' ''Catch ex As Exception
        ' ''    msgbox(ex.Message)
        ' ''End Try
    End Sub
    Public Sub GetAllstatuss(opendate As String, closedate As String, statuss As String)
        Dim ds As New DataSet
        cmd = New SqlCommand("select (select top 1 operator from warehousecreation where warehousecode=w.warehouse) as [Warehouse Operator],(select top 1 WarehouseName from warehousecreation where warehousecode=w.warehouse) as [Warehouse],a.CDS_Number AS [ClientNo],a.Surname+' '+a.Forenames as [Names], Commodity as [Commodity],Grade, ReceiptNo, InsurancePolicy, Quantity, 'Metric Tonnes' AS UnitMeasure,(select initialPrice from para_company where company=w.commodity+'/'+w.grade) as [Indicative Price], Convert(date, date_issued) as [Issue Date], Convert(date, expiry) as [Expiry], case w.[Status] when 'PLEDGED'  then (select top 1 ApprovedBy from BorrowingRequest where Collateral=w.receiptno and [status]='PLEDGED' order by id desc) when 'SPLIT' then (select top 1 Inputter  from tblWRSplits where OriginalWRNo=w.ReceiptNo and [state]='A' order by id desc) when 'WITHDRAWN' then (select TOP 1 CapturedBy  from withdrawals where ReceiptID=w.ReceiptNo AND ApprovedBy is not NULL) else  Issued_By end as [Initiator]   from WR w, Accounts_Clients a WHERE A.cds_number=w.holder and approvedby is not NULL and Convert(date, date_issued)>='" + opendate + "' and Convert(date, date_issued)<='" + closedate + "' and w.[status]='" + statuss + "'", cn)
        adp = New SqlDataAdapter(cmd)
        cmd.CommandTimeout = 99999
        adp.Fill(ds, "para_lendingRules")
        If (ds.Tables(0).Rows.Count > 0) Then
            grdRules.DataSource = ds.Tables(0)
            grdRules.DataBind()
        Else
            grdRules.DataSource = Nothing
            grdRules.DataBind()
        End If
        ' ''Catch ex As Exception
        ' ''    msgbox(ex.Message)
        ' ''End Try
    End Sub
    Public Sub GetAllPENDING(opendate As String, closedate As String)
        Dim ds As New DataSet
        cmd = New SqlCommand("select (select top 1 operator from warehousecreation where warehousecode=w.warehouse) as [Warehouse Operator],(select top 1 WarehouseName from warehousecreation where warehousecode=w.warehouse) as [Warehouse],a.CDS_Number AS [ClientNo],a.Surname+' '+a.Forenames as [Names], Commodity as [Commodity],Grade, ReceiptNo, InsurancePolicy, Quantity,'Metric Tonnes' AS UnitMeasure, Convert(date, date_issued) as [Issue Date], Convert(date, expiry) as [Expiry], case w.[Status] when 'PLEDGED'  then (select top 1 ApprovedBy from BorrowingRequest where Collateral=w.receiptno and [status]='PLEDGED' order by id desc) when 'SPLIT' then (select top 1 Inputter  from tblWRSplits where OriginalWRNo=w.ReceiptNo and [state]='A' order by id desc) when 'WITHDRAWN' then (select TOP 1 CapturedBy  from withdrawals where ReceiptID=w.ReceiptNo AND ApprovedBy is not NULL) else  Issued_By end as [Initiator]   from WR w, Accounts_Clients a WHERE A.cds_number=w.holder and approvedby is NULL and Convert(date, date_issued)>='" + opendate + "' and Convert(date, date_issued)<='" + closedate + "'", cn)
        adp = New SqlDataAdapter(cmd)
        cmd.CommandTimeout = 99999
        adp.Fill(ds, "para_lendingRules")
        If (ds.Tables(0).Rows.Count > 0) Then
            grdRules.DataSource = ds.Tables(0)
            grdRules.DataBind()
        Else
            grdRules.DataSource = Nothing
            grdRules.DataBind()
        End If
        ' ''Catch ex As Exception
        ' ''    msgbox(ex.Message)
        ' ''End Try
    End Sub








    Protected Sub ASPxButton1_Click(sender As Object, e As EventArgs) Handles ASPxButton1.Click
        If RadioButtonList1.SelectedItem.Text = "All Warehouse Receipts" Then
            GetAll(dtfrom.Text, dtto.Text)
        ElseIf RadioButtonList1.SelectedItem.Text = "Expired" Then
            GetAllexpired(dtfrom.Text, dtto.Text)
        ElseIf RadioButtonList1.SelectedItem.Text = "Approved" Then
            GetAllApproved(dtfrom.Text, dtto.Text)
        ElseIf RadioButtonList1.SelectedItem.Text = "Pending Approval" Then
            GetAllPENDING(dtfrom.Text, dtto.Text)
        ElseIf RadioButtonList1.SelectedItem.Text = "Stolen" Then
            GetAllstatuss(dtfrom.Text, dtto.Text, "Stolen")
        ElseIf RadioButtonList1.SelectedItem.Text = "Cancelled" Then
            GetAllstatuss(dtfrom.Text, dtto.Text, "CANCELLED")
        ElseIf RadioButtonList1.SelectedItem.Text = "Lost" Then
            GetAllstatuss(dtfrom.Text, dtto.Text, "Lost")

        End If


    End Sub


    Protected Sub ASPxButton8_Click(sender As Object, e As EventArgs) Handles ASPxButton8.Click
        If RadioButtonList1.SelectedItem.Text = "All Warehouse Receipts" Then
            GetAll(dtfrom.Text, dtto.Text)
        ElseIf RadioButtonList1.SelectedItem.Text = "Expired" Then
            GetAllexpired(dtfrom.Text, dtto.Text)
        ElseIf RadioButtonList1.SelectedItem.Text = "Approved" Then
            GetAllApproved(dtfrom.Text, dtto.Text)
        ElseIf RadioButtonList1.SelectedItem.Text = "Pending Approval" Then
            GetAllPENDING(dtfrom.Text, dtto.Text)
        End If
        ASPxGridViewExporter1.WriteXlsToResponse()
    End Sub


    Protected Sub RadioButtonList1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles RadioButtonList1.SelectedIndexChanged

    End Sub
End Class
