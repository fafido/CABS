Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports DevExpress.Web.ASPxEditors
Imports DevExpress.Web.ASPxGridView

Partial Class CDSMode_CDSHome
    Inherits System.Web.UI.Page
    Dim constr As String = (System.Configuration.ConfigurationManager.AppSettings("connpath"))
    Dim cn As New SqlConnection(constr)
    Dim cmd As SqlCommand
    Dim adp As SqlDataAdapter
    Dim ds As New DataSet
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
            '  msgbox(Session("role"))
            getcolumns()



            If Session("role") = "CMCADMIN" Then
                connectdashadmin()
                panelview.Visible = True
            ElseIf Session("role") = "WAREHOUSEUSER" Then
                connectdashwarehouse_user()
                panelview.Visible = True
            ElseIf Session("role") = "CABSADMIN" Then
                connectdashwarehouse_ADMIN()
                panelview.Visible = True
                btnSaveContract3.Visible = True
            ElseIf Session("role") = "CUSTODYUSER" Then
                connectdashwarehouse_USERNEW()
                panelview.Visible = True
                btnSaveContract3.Visible = True
            ElseIf Session("role") = "BANKADMIN" Or Session("role") = "ISLAMICBANKADMIN" Then
                connectdashBANKadmin()
                panelview.Visible = True
            ElseIf Session("role") = "BANKUSER" Or Session("role") = "ISLAMICBANKUSER" Then
                connectdash_BANKuser()
                panelview.Visible = True
            End If

            If Session("finish") = "true" Then
                Session("finish") = ""
                msgbox("Dashboard Updated to your preference.")
            End If

            '   GetEventsData()

        End If
        ' msgbox(Session("Companytype"))
    End Sub
    Public Sub getcolumns()
        Dim ds1 As New DataSet
        cmd = New SqlCommand("  SELECT s.title  as title, case when (select count(*) from dash_pref where username='" + Session("Username") + "' and title=s.title)=0 then 'False' else 'True' end as chk   FROM dash_items s", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds1, "Accounts_Clients1")
        If (ds1.Tables("Accounts_Clients1").Rows.Count > 0) Then
            grdcols.DataSource = ds1
            grdcols.DataBind()

        End If
    End Sub
    Public Sub GetEventsData()
        Try

        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub connectdashadmin()
        Dim ds As New DataSet
        cmd = New SqlCommand("select UPPER(title) AS title, [All],Pending, url from Admindash", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "tbl_SettlementSummary2")
        If (ds.Tables(0).Rows.Count > 0) Then
            onebyone_title.InnerText = ds.Tables(0).Rows(0).Item("Title")
            onebyone_value.InnerText = ds.Tables(0).Rows(0).Item("All")
            onebyone_pending.InnerText = ds.Tables(0).Rows(0).Item("pending").ToString + " Pending Approval"
            onebyone_link.HRef = ds.Tables(0).Rows(0).Item("url")


            onebytwo_title.InnerText = ds.Tables(0).Rows(1).Item("Title")
            onebytwo_value.InnerText = ds.Tables(0).Rows(1).Item("All")
            onebytwo_pending.InnerText = ds.Tables(0).Rows(1).Item("pending").ToString + " Pending Approval"
            onebytwo_link.HRef = ds.Tables(0).Rows(1).Item("url")


            onebythree_title.InnerText = ds.Tables(0).Rows(2).Item("Title")
            onebythree_value.InnerText = ds.Tables(0).Rows(2).Item("All")
            onebythree_pending.InnerText = ds.Tables(0).Rows(2).Item("pending").ToString + " Pending Approval"
            onebythree_link.HRef = ds.Tables(0).Rows(2).Item("url")

            twobyone_title.InnerText = ds.Tables(0).Rows(3).Item("Title")
            twobyone_value.InnerText = ds.Tables(0).Rows(3).Item("All")
            twobyone_pending.InnerText = ds.Tables(0).Rows(3).Item("pending").ToString + " Pending Approval"
            twobyone_link.HRef = ds.Tables(0).Rows(3).Item("url")



            twobytwo_title.InnerText = ds.Tables(0).Rows(4).Item("Title")
            twobytwo_value.InnerText = ds.Tables(0).Rows(4).Item("All")
            twobytwo_pending.InnerText = ds.Tables(0).Rows(4).Item("pending").ToString + " Pending Approval"
            twobytwo_link.HRef = ds.Tables(0).Rows(4).Item("url")

            twobythree_title.InnerText = ds.Tables(0).Rows(5).Item("Title")
            twobythree_value.InnerText = ds.Tables(0).Rows(5).Item("All")
            twobythree_pending.InnerText = ds.Tables(0).Rows(5).Item("pending").ToString + " Pending Approval"
            twobythree_link.HRef = ds.Tables(0).Rows(5).Item("url")


            threebyone_title.InnerText = ds.Tables(0).Rows(6).Item("Title")
            threebyone_value.InnerText = ds.Tables(0).Rows(6).Item("All")
            threebyone_pending.InnerText = ds.Tables(0).Rows(6).Item("pending").ToString + " Pending Approval"
            threebyone_link.HRef = ds.Tables(0).Rows(6).Item("url")

            threebytwo_title.InnerText = ds.Tables(0).Rows(7).Item("Title")
            threebytwo_value.InnerText = ds.Tables(0).Rows(7).Item("All")
            threebytwo_pending.InnerText = ds.Tables(0).Rows(7).Item("pending").ToString + " Pending Approval"
            threebytwo_link.HRef = ds.Tables(0).Rows(7).Item("url")


            threebythree_title.InnerText = ds.Tables(0).Rows(8).Item("Title")
            threebythree_value.InnerText = ds.Tables(0).Rows(8).Item("All")
            threebythree_pending.InnerText = ds.Tables(0).Rows(8).Item("pending").ToString + " Pending Approval"
            threebythree_link.HRef = ds.Tables(0).Rows(8).Item("url")










        End If
    End Sub
    Public Sub connectdashBANKadmin()
        Dim ds As New DataSet
        cmd = New SqlCommand("declare @bank nvarchar(50)='" + Session("BrokerCode") + "' select 'Total Pledges' as [Title], convert(numeric(18,0),count(*)) as [All], '' as [Pending], '~/TransferSec/BorrowersAccept.aspx' as url from BorrowingRequest  where  Bank=@bank  union select 'Pending Pledges' as [Title], convert(numeric(18,0),count(*)) as [All], '' as [Pending], '~/TransferSec/BorrowersAccept.aspx' as url from BorrowingRequest where Approved is NULL and Deleted is NULL  and Bank=@bank union select 'Approved Pledges' as [Title], convert(numeric(18,0),count(*)) as [All], '' as [Pending], '~/TransferSec/BorrowersAccept.aspx' as url from BorrowingRequest where Approved is NOT NULL and Bank=@bank  union select 'Rejected Pledges' as [Title], convert(numeric(18,0),count(*)) as [All], '' as [Pending], '' as url from BorrowingRequest where Rejected is NOT NULL and Bank=@bank union select 'Released Pledges' as [Title], convert(numeric(18,0),count(*)) as [All], (select count(*) from BorrowingRequest where [status]='RELEASE PENDING' and Bank=@bank) as [Pending], '~/TransferSec/releaseFIN.aspx' as url from BorrowingRequest where [Status]='RELEASED'   and Bank=@bank union select 'Foreclosure Pledges' as [Title], convert(numeric(18,0),count(*)) as [All], (select count(*) from BorrowingRequest where [status]='FORECLOSURE PENDING' and Bank=@bank) as [Pending], '~/TransferSec/foreclosureFIN.aspx' as url from BorrowingRequest where [Status]='FORECLOSURE'   and Bank=@bank union select 'Unsuccessful Pledges' as [Title], convert(numeric(18,0),count(*)) as [All], '' as [Pending], '' as url from BorrowingRequest where Deleted is NOT NULL union select 'My Interest Rate' as [Title],	isnull((select top 1 convert(numeric(18,0),InterestRate) from Para_lendingRules where bank=@bank),0) as [All],''  as [Pending], '~/BrokerMode/LendingandBorrowingPara.aspx' as url union select 'My Service Charge' as [Title],	isnull((select top 1 convert(numeric(18,0),ServiceCharges ) as [All] from Para_lendingRules where Bank=@bank),0) as [All], ''  as [Pending], '~/BrokerMode/LendingandBorrowingPara.aspx' as url", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "tbl_SettlementSummary2")
        If (ds.Tables(0).Rows.Count > 0) Then
            onebyone_title.InnerText = ds.Tables(0).Rows(0).Item("Title")
            onebyone_value.InnerText = ds.Tables(0).Rows(0).Item("All")
            onebyone_pending.InnerText = ""
            onebyone_link.HRef = ds.Tables(0).Rows(0).Item("url")


            onebytwo_title.InnerText = ds.Tables(0).Rows(1).Item("Title")
            onebytwo_value.InnerText = ds.Tables(0).Rows(1).Item("All")
            onebytwo_pending.InnerText = ""
            onebytwo_link.HRef = ds.Tables(0).Rows(1).Item("url")


            onebythree_title.InnerText = ds.Tables(0).Rows(2).Item("Title")
            onebythree_value.InnerText = ds.Tables(0).Rows(2).Item("All")
            onebythree_pending.InnerText = ""
            onebythree_link.HRef = ds.Tables(0).Rows(2).Item("url")

            twobyone_title.InnerText = ds.Tables(0).Rows(3).Item("Title")
            twobyone_value.InnerText = ds.Tables(0).Rows(3).Item("All")
            twobyone_pending.InnerText = ""
            twobyone_link.HRef = ds.Tables(0).Rows(3).Item("url")



            twobytwo_title.InnerText = ds.Tables(0).Rows(4).Item("Title")
            twobytwo_value.InnerText = ds.Tables(0).Rows(4).Item("All")
            twobytwo_pending.InnerText = ""
            twobytwo_link.HRef = ds.Tables(0).Rows(4).Item("url")

            twobythree_title.InnerText = ds.Tables(0).Rows(5).Item("Title")
            twobythree_value.InnerText = ds.Tables(0).Rows(5).Item("All")
            twobythree_pending.InnerText = ""
            twobythree_link.HRef = ds.Tables(0).Rows(5).Item("url")


            threebyone_title.InnerText = ds.Tables(0).Rows(6).Item("Title")
            threebyone_value.InnerText = ds.Tables(0).Rows(6).Item("All")
            threebyone_pending.InnerText = ""
            threebyone_link.HRef = ds.Tables(0).Rows(6).Item("url")

            threebytwo_title.InnerText = ds.Tables(0).Rows(7).Item("Title")
            threebytwo_value.InnerText = ds.Tables(0).Rows(7).Item("All")
            threebytwo_pending.InnerText = ""
            threebytwo_link.HRef = ds.Tables(0).Rows(7).Item("url")


            threebythree_title.InnerText = ds.Tables(0).Rows(8).Item("Title")
            threebythree_value.InnerText = ds.Tables(0).Rows(8).Item("All")
            threebythree_pending.InnerText = ""
            threebythree_link.HRef = ds.Tables(0).Rows(8).Item("url")










        End If
    End Sub
    Public Sub connectdash_BANKuser()
        Dim ds As New DataSet
        cmd = New SqlCommand("declare @bank nvarchar(50)='" + Session("BrokerCode") + "' select 'Total Pledges' as [Title], convert(numeric(18,0),count(*)) as [All], '' as [Pending], '' as url from BorrowingRequest  where  Bank=@bank  union select 'Pending Pledges' as [Title], convert(numeric(18,0),count(*)) as [All], '' as [Pending], '' as url from BorrowingRequest where Approved is NULL and Deleted is NULL  and Bank=@bank union select 'Approved Pledges' as [Title], convert(numeric(18,0),count(*)) as [All], '' as [Pending], '' as url from BorrowingRequest where Approved is NOT NULL and Bank=@bank  union select 'Rejected Pledges' as [Title], convert(numeric(18,0),count(*)) as [All], '' as [Pending], '' as url from BorrowingRequest where Rejected is NOT NULL and Bank=@bank union select 'Released Pledges' as [Title], convert(numeric(18,0),count(*)) as [All], (select count(*) from BorrowingRequest where [status]='RELEASE PENDING' and Bank=@bank) as [Pending], '' as url from BorrowingRequest where [Status]='RELEASED'   and Bank=@bank union select 'Foreclosure Pledges' as [Title], convert(numeric(18,0),count(*)) as [All], (select count(*) from BorrowingRequest where [status]='FORECLOSURE PENDING' and Bank=@bank) as [Pending], '' as url from BorrowingRequest where [Status]='FORECLOSURE'   and Bank=@bank union select 'Unsuccessful Pledges' as [Title], convert(numeric(18,0),count(*)) as [All], '' as [Pending], '' as url from BorrowingRequest where Deleted is NOT NULL union select 'My Interest Rate' as [Title],	isnull((select top 1 convert(numeric(18,0),InterestRate) from Para_lendingRules where bank=@bank),0) as [All],''  as [Pending], '' as url union select 'My Service Charge' as [Title],	isnull((select top 1 convert(numeric(18,0),ServiceCharges ) as [All] from Para_lendingRules where Bank=@bank),0) as [All], ''  as [Pending], '' as url ", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "tbl_SettlementSummary2")
        If (ds.Tables(0).Rows.Count > 0) Then
            onebyone_title.InnerText = ds.Tables(0).Rows(0).Item("Title")
            onebyone_value.InnerText = ds.Tables(0).Rows(0).Item("All")
            onebyone_pending.InnerText = ""
            onebyone_link.HRef = ds.Tables(0).Rows(0).Item("url")


            onebytwo_title.InnerText = ds.Tables(0).Rows(1).Item("Title")
            onebytwo_value.InnerText = ds.Tables(0).Rows(1).Item("All")
            onebytwo_pending.InnerText = ""
            onebytwo_link.HRef = ds.Tables(0).Rows(1).Item("url")


            onebythree_title.InnerText = ds.Tables(0).Rows(2).Item("Title")
            onebythree_value.InnerText = ds.Tables(0).Rows(2).Item("All")
            onebythree_pending.InnerText = ""
            onebythree_link.HRef = ds.Tables(0).Rows(2).Item("url")

            twobyone_title.InnerText = ds.Tables(0).Rows(3).Item("Title")
            twobyone_value.InnerText = ds.Tables(0).Rows(3).Item("All")
            twobyone_pending.InnerText = ""
            twobyone_link.HRef = ds.Tables(0).Rows(3).Item("url")



            twobytwo_title.InnerText = ds.Tables(0).Rows(4).Item("Title")
            twobytwo_value.InnerText = ds.Tables(0).Rows(4).Item("All")
            twobytwo_pending.InnerText = ""
            twobytwo_link.HRef = ds.Tables(0).Rows(4).Item("url")

            twobythree_title.InnerText = ds.Tables(0).Rows(5).Item("Title")
            twobythree_value.InnerText = ds.Tables(0).Rows(5).Item("All")
            twobythree_pending.InnerText = ""
            twobythree_link.HRef = ds.Tables(0).Rows(5).Item("url")


            threebyone_title.InnerText = ds.Tables(0).Rows(6).Item("Title")
            threebyone_value.InnerText = ds.Tables(0).Rows(6).Item("All")
            threebyone_pending.InnerText = ""
            threebyone_link.HRef = ds.Tables(0).Rows(6).Item("url")

            threebytwo_title.InnerText = ds.Tables(0).Rows(7).Item("Title")
            threebytwo_value.InnerText = ds.Tables(0).Rows(7).Item("All")
            threebytwo_pending.InnerText = ""
            threebytwo_link.HRef = ds.Tables(0).Rows(7).Item("url")


            threebythree_title.InnerText = ds.Tables(0).Rows(8).Item("Title")
            threebythree_value.InnerText = ds.Tables(0).Rows(8).Item("All")
            threebythree_pending.InnerText = ""
            threebythree_link.HRef = ds.Tables(0).Rows(8).Item("url")










        End If
    End Sub
    Public Sub connectdash_cdsuser()
        Dim ds As New DataSet
        cmd = New SqlCommand("select UPPER(title) AS title, [All],Pending, url from cdsuserdash", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "tbl_SettlementSummary2")
        If (ds.Tables(0).Rows.Count > 0) Then
            onebyone_title.InnerText = ds.Tables(0).Rows(0).Item("Title")
            onebyone_value.InnerText = ds.Tables(0).Rows(0).Item("All")
            onebyone_pending.InnerText = ds.Tables(0).Rows(0).Item("pending").ToString + " Pending Approval"
            onebyone_link.HRef = ds.Tables(0).Rows(0).Item("url")


            onebytwo_title.InnerText = ds.Tables(0).Rows(1).Item("Title")
            onebytwo_value.InnerText = ds.Tables(0).Rows(1).Item("All")
            onebytwo_pending.InnerText = ds.Tables(0).Rows(1).Item("pending").ToString + " Pending Approval"
            onebytwo_link.HRef = ds.Tables(0).Rows(1).Item("url")


            onebythree_title.InnerText = ds.Tables(0).Rows(2).Item("Title")
            onebythree_value.InnerText = ds.Tables(0).Rows(2).Item("All")
            onebythree_pending.InnerText = ds.Tables(0).Rows(2).Item("pending").ToString + " Pending Approval"
            onebythree_link.HRef = ds.Tables(0).Rows(2).Item("url")

            twobyone_title.InnerText = ds.Tables(0).Rows(3).Item("Title")
            twobyone_value.InnerText = ds.Tables(0).Rows(3).Item("All")
            twobyone_pending.InnerText = ds.Tables(0).Rows(3).Item("pending").ToString + " Pending Approval"
            twobyone_link.HRef = ds.Tables(0).Rows(3).Item("url")



            twobytwo_title.InnerText = ds.Tables(0).Rows(4).Item("Title")
            twobytwo_value.InnerText = ds.Tables(0).Rows(4).Item("All")
            twobytwo_pending.InnerText = ds.Tables(0).Rows(4).Item("pending").ToString + " Pending Approval"
            twobytwo_link.HRef = ds.Tables(0).Rows(4).Item("url")

            twobythree_title.InnerText = ds.Tables(0).Rows(5).Item("Title")
            twobythree_value.InnerText = ds.Tables(0).Rows(5).Item("All")
            twobythree_pending.InnerText = ds.Tables(0).Rows(5).Item("pending").ToString + " Pending Approval"
            twobythree_link.HRef = ds.Tables(0).Rows(5).Item("url")


            threebyone_title.InnerText = ds.Tables(0).Rows(6).Item("Title")
            threebyone_value.InnerText = ds.Tables(0).Rows(6).Item("All")
            threebyone_pending.InnerText = ds.Tables(0).Rows(6).Item("pending").ToString + " Pending Approval"
            threebyone_link.HRef = ds.Tables(0).Rows(6).Item("url")

            threebytwo_title.InnerText = ds.Tables(0).Rows(7).Item("Title")
            threebytwo_value.InnerText = ds.Tables(0).Rows(7).Item("All")
            threebytwo_pending.InnerText = ds.Tables(0).Rows(7).Item("pending").ToString + " Pending Approval"
            threebytwo_link.HRef = ds.Tables(0).Rows(7).Item("url")


            threebythree_title.InnerText = ds.Tables(0).Rows(8).Item("Title")
            threebythree_value.InnerText = ds.Tables(0).Rows(8).Item("All")
            threebythree_pending.InnerText = ds.Tables(0).Rows(8).Item("pending").ToString + " Pending Approval"
            threebythree_link.HRef = ds.Tables(0).Rows(8).Item("url")










        End If
    End Sub
    Public Sub connectdashwarehouse_user()
        Dim ds As New DataSet
        cmd = New SqlCommand("declare @warehouse nvarchar(50)='" + Session("BrokerCode") + "' select 'Withdrawals' as [Title], count(*) as [All], (select count(*) from withdrawals   where ApprovedBy is NULL AND Rejected is NULL AND ParticipantCode=@warehouse and OTPStatus='Approved') as [Pending], '' as url from withdrawals where ParticipantCode=@warehouse  union select 'Client Accounts' as [Title], count(*) as [All], (select count(*) from Accounts_Audit  where AuthorizationState<>'C' and brokercode=@warehouse ) as [Pending], '' as url from Accounts_Clients where brokercode=@warehouse  union select 'Warehouse Receipts' as [Title], count(*) as [All], (select count(*) from WR  where Approved_By IS NULL and warehouse=@warehouse) as [Pending], '' as url from WR where Approved_By is NOT NULL  and warehouse=@warehouse union select 'Pledges' as [Title], count(*) as [All], (select count(*) from BorrowingRequest   where Approved IS NULL and OTPStatus='Approved' and Collateral  in (select receiptno from wr where Warehouse=@warehouse)) as [Pending], '' as url from BorrowingRequest  where Approved is NOT NULL  and Collateral   in (select receiptno from wr where Warehouse =@warehouse) union select 'Fore Closures' as [Title], count(*) as [All], (select count(*) from BorrowingRequest where [status]='FORECLOSURE PENDING' and Participant=@warehouse and OTPStatus='Approved' and Collateral   in (select receiptno from wr where Warehouse =@warehouse)) as [Pending], '' as url from BorrowingRequest  where [Status]='ForeClosure'  and Collateral   in (select receiptno from wr where Warehouse =@warehouse) union select 'Total Users' as [Title], count(*) as [All], (select count(*) from SystemUsers_Temp where companyCode=@warehouse  and ApprovedBy is NULL AND Rejected IS NULL) as [Pending],'' as url from SystemUsers where companyCode=@warehouse union  select 'Deposits' as [Title], count(*) as [All], '0' as [Pending], '' as url from WarehourseDeliveries where WarehouseOperator=@warehouse union select 'PMEX Trades' as [Title], count(*) as [All], (select count(*) from Pmextrans  where ApprovedBy IS NULL and rejected is NULL and deleted is NULL and ParticipantCode=@warehouse) as [Pending], '' as url from Pmextrans  where ParticipantCode=@warehouse  union select 'My Pending Transfers' as [Title], count(*) as [All], (select count(*) from share_transfer where ApprovedBy is NULL AND Rejected IS NULL and Deleted is NULL AND ParticipantCode=@warehouse and OTPStatus='Approved') as [Pending], '' as url from share_transfer where ParticipantCode=@warehouse ", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "tbl_SettlementSummary2")
        If (ds.Tables(0).Rows.Count > 0) Then
            onebyone_title.InnerText = ds.Tables(0).Rows(0).Item("Title")
            onebyone_value.InnerText = ds.Tables(0).Rows(0).Item("All")
            onebyone_pending.InnerText = ds.Tables(0).Rows(0).Item("pending").ToString + " Pending Approval"
            onebyone_link.HRef = ds.Tables(0).Rows(0).Item("url")


            onebytwo_title.InnerText = ds.Tables(0).Rows(1).Item("Title")
            onebytwo_value.InnerText = ds.Tables(0).Rows(1).Item("All")
            onebytwo_pending.InnerText = ds.Tables(0).Rows(1).Item("pending").ToString + " Pending Approval"
            onebytwo_link.HRef = ds.Tables(0).Rows(1).Item("url")


            onebythree_title.InnerText = ds.Tables(0).Rows(2).Item("Title")
            onebythree_value.InnerText = ds.Tables(0).Rows(2).Item("All")
            onebythree_pending.InnerText = ds.Tables(0).Rows(2).Item("pending").ToString + " Pending Approval"
            onebythree_link.HRef = ds.Tables(0).Rows(2).Item("url")

            twobyone_title.InnerText = ds.Tables(0).Rows(3).Item("Title")
            twobyone_value.InnerText = ds.Tables(0).Rows(3).Item("All")
            twobyone_pending.InnerText = ds.Tables(0).Rows(3).Item("pending").ToString + " Pending Approval"
            twobyone_link.HRef = ds.Tables(0).Rows(3).Item("url")



            twobytwo_title.InnerText = ds.Tables(0).Rows(4).Item("Title")
            twobytwo_value.InnerText = ds.Tables(0).Rows(4).Item("All")
            twobytwo_pending.InnerText = ds.Tables(0).Rows(4).Item("pending").ToString + " Pending Approval"
            twobytwo_link.HRef = ds.Tables(0).Rows(4).Item("url")

            twobythree_title.InnerText = ds.Tables(0).Rows(5).Item("Title")
            twobythree_value.InnerText = ds.Tables(0).Rows(5).Item("All")
            twobythree_pending.InnerText = ds.Tables(0).Rows(5).Item("pending").ToString + " Pending Approval"
            twobythree_link.HRef = ds.Tables(0).Rows(5).Item("url")


            threebyone_title.InnerText = ds.Tables(0).Rows(6).Item("Title")
            threebyone_value.InnerText = ds.Tables(0).Rows(6).Item("All")
            threebyone_pending.InnerText = ds.Tables(0).Rows(6).Item("pending").ToString + " Pending Approval"
            threebyone_link.HRef = ds.Tables(0).Rows(6).Item("url")

            threebytwo_title.InnerText = ds.Tables(0).Rows(7).Item("Title")
            threebytwo_value.InnerText = ds.Tables(0).Rows(7).Item("All")
            threebytwo_pending.InnerText = ds.Tables(0).Rows(7).Item("pending").ToString + " Pending Approval"
            threebytwo_link.HRef = ds.Tables(0).Rows(7).Item("url")


            threebythree_title.InnerText = ds.Tables(0).Rows(8).Item("Title")
            threebythree_value.InnerText = ds.Tables(0).Rows(8).Item("All")
            threebythree_pending.InnerText = ds.Tables(0).Rows(8).Item("pending").ToString + " Pending Approval"
            threebythree_link.HRef = ds.Tables(0).Rows(8).Item("url")










        End If
    End Sub

    Public Sub connectdashwarehouse_USERNEW()
        Dim ds As New DataSet
        cmd = New SqlCommand(" SELECT * from (select 'Equity Trades' as [Title], count(*) as [All], (SELECT COUNT(*) FROM Custodian_Trades where TradeStatus='OUTSTANDING' and ApprovedBy is NULL) as [Pending], '' as url from Custodian_Trades union select 'Bond Trades' as [Title], count(*) as [All], (SELECT COUNT(*) FROM Bond_Trades  where TradeStatus='OUTSTANDING' and ApprovedBy is NULL) as [Pending], '' as url from Bond_Trades   union select 'Client Accounts' as [Title], count(*) as [All], (select count(*) from accounts_audit a where (a.AuthorizationState='A' or a.AuthorizationState='O') AND CASE WHEN ISNULL(a.OTP,'0')='0' THEN 'APPROVED' ELSE ISNULL(a.OTPStatus,'') END='APPROVED') as [Pending], '' as url from Accounts_Clients  union select 'Vault' as [Title], count(*) as [All], (SELECT COUNT(*) FROM Deposit_Cert where [Status]='0' and DepType='DEPOSIT' and Rejected is NULL) as [Pending], '' as url from Deposit_Cert where [status]='Approved' and DepType='DEPOSIT'  union select 'Money Market' as [Title], count(*) as [All], (SELECT COUNT(*) FROM MoneyMarket where  approveddate is null and Rejected is NULL) as [Pending], '' as url from MoneyMarket where TradeStatus='ON-GOING' and approveddate is not null and Rejected is NULL union select 'Cash Allocation' as [Title], count(*) as [All], (select Count(*) from trans_bank_alloc where Allocated='PENDING' and ApprovedBy is NULL) as [Pending], '' as url from trans_bank_alloc   where [Allocated]='ALLOCATED' union select 'Money Market Redemption' as [Title], count(*) as [All], (select count(*) from MoneyMarketRedemption where ApprovedBy IS NULL and Rejected is NULL) as [Pending],'' as url from MoneyMarketRedemption where ApprovedBy IS NOT NULL  union  select 'Money Market Rollover' as [Title], count(*) as [All], (select count(*) from MoneyMarketRollover where ApprovedBy IS NULL and Rejected is NULL) as [Pending],'' as url from MoneyMarketRollover where ApprovedBy IS NOT NULL  union   select 'Bond Reconciliation' as [Title], count(*) as [All], (select COUNT(*) from Recon_AssetManager_Fixed_Approvals where   [Security] in (select code from bond) and Approved IS null and Rejected is NULL ) as [Pending], '' as url from Recon_AssetManager_Fixed_Approvals WHERE [Security] in (select code from bond) and Approved='1' and Rejected is NULL union select 'Equity Reconciliation' as [Title], count(*) as [All], (select COUNT(*) from Recon_AssetManager_Approvals where CurrentStatus='Pending' ) as [Pending], '' as url from Recon_AssetManager_Approvals where CurrentStatus='APPROVED' union select 'Money Market Reconciliation' as [Title], count(*) as [All], (select COUNT(*) from Recon_AssetManager_Fixed_Approvals where   [Security] not in (select code from bond) and Approved IS null and Rejected is NULL ) as [Pending], '' as url from Recon_AssetManager_Fixed_Approvals WHERE [Security] not in (select code from bond) and Approved='1' and Rejected is NULL union   select 'CDC Reconciliation' as [Title], count(*) as [All], (select COUNT(*) from Recon_cdc_Approvals  where CurrentStatus='Pending' ) as [Pending], '' as url from Recon_cdc_Approvals  where CurrentStatus='APPROVED' union select 'Cash Reconciliation' as [Title], count(*) as [All], (select COUNT(*) from Bank_Recon_Approval   where [Status]='PENDING' ) as [Pending], '' as url from Bank_Recon_Approval  where [Status]='APPROVED'UNION select 'Participants Approval' as [Title], count(*) as [All], (select COUNT(*) from client_companies_audit where approvedby is NULL AND rejectedby is NULL) as [Pending], '' as url from Client_Companies UNION select 'Rejected Participants' as [Title], count(*) as [All], 0 as [Pending], '' as url from Client_Companies_Audit where RejectedBy is NOT NULL union select 'Users' as [Title], count(*) as [All], (select count(*) from SystemUsers_Temp WHERE ApprovedBy is NULL and Rejected is NULL) as [Pending], '' as url from SystemUsers  union  select 'Other Approvals', count(*) as [All], (select count(*) from tbl_uncommitted where [status]='0') as [Pending], '' as url from tbl_uncommitted) j where title in (select title from dash_pref where username='" + Session("Username") + "')", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "tbl_SettlementSummary2")
        If (ds.Tables(0).Rows.Count > 0) Then
            onebyone_title.InnerText = ds.Tables(0).Rows(0).Item("Title")
            onebyone_value.InnerText = ds.Tables(0).Rows(0).Item("All")
            onebyone_pending.InnerText = ds.Tables(0).Rows(0).Item("pending").ToString + " Pending Approval"
            onebyone_link.HRef = ds.Tables(0).Rows(0).Item("url")


            onebytwo_title.InnerText = ds.Tables(0).Rows(1).Item("Title")
            onebytwo_value.InnerText = ds.Tables(0).Rows(1).Item("All")
            onebytwo_pending.InnerText = ds.Tables(0).Rows(1).Item("pending").ToString + " Pending Approval"
            onebytwo_link.HRef = ds.Tables(0).Rows(1).Item("url")


            onebythree_title.InnerText = ds.Tables(0).Rows(2).Item("Title")
            onebythree_value.InnerText = ds.Tables(0).Rows(2).Item("All")
            onebythree_pending.InnerText = ds.Tables(0).Rows(2).Item("pending").ToString + " Pending Approval"
            onebythree_link.HRef = ds.Tables(0).Rows(2).Item("url")

            twobyone_title.InnerText = ds.Tables(0).Rows(3).Item("Title")
            twobyone_value.InnerText = ds.Tables(0).Rows(3).Item("All")
            twobyone_pending.InnerText = ds.Tables(0).Rows(3).Item("pending").ToString + " Pending Approval"
            twobyone_link.HRef = ds.Tables(0).Rows(3).Item("url")



            twobytwo_title.InnerText = ds.Tables(0).Rows(4).Item("Title")
            twobytwo_value.InnerText = ds.Tables(0).Rows(4).Item("All")
            twobytwo_pending.InnerText = ds.Tables(0).Rows(4).Item("pending").ToString + " Pending Approval"
            twobytwo_link.HRef = ds.Tables(0).Rows(4).Item("url")

            twobythree_title.InnerText = ds.Tables(0).Rows(5).Item("Title")
            twobythree_value.InnerText = ds.Tables(0).Rows(5).Item("All")
            twobythree_pending.InnerText = ds.Tables(0).Rows(5).Item("pending").ToString + " Pending Approval"
            twobythree_link.HRef = ds.Tables(0).Rows(5).Item("url")


            threebyone_title.InnerText = ds.Tables(0).Rows(6).Item("Title")
            threebyone_value.InnerText = ds.Tables(0).Rows(6).Item("All")
            threebyone_pending.InnerText = ds.Tables(0).Rows(6).Item("pending").ToString + " Pending Approval"
            threebyone_link.HRef = ds.Tables(0).Rows(6).Item("url")

            threebytwo_title.InnerText = ds.Tables(0).Rows(7).Item("Title")
            threebytwo_value.InnerText = ds.Tables(0).Rows(7).Item("All")
            threebytwo_pending.InnerText = ds.Tables(0).Rows(7).Item("pending").ToString + " Pending Approval"
            threebytwo_link.HRef = ds.Tables(0).Rows(7).Item("url")


            threebythree_title.InnerText = ds.Tables(0).Rows(8).Item("Title")
            threebythree_value.InnerText = ds.Tables(0).Rows(8).Item("All")
            threebythree_pending.InnerText = ds.Tables(0).Rows(8).Item("pending").ToString + " Pending Approval"
            threebythree_link.HRef = ds.Tables(0).Rows(8).Item("url")



            fourby1_title.InnerText = ds.Tables(0).Rows(9).Item("Title")
            fourby1_value.InnerText = ds.Tables(0).Rows(9).Item("All")
            fourby1_pending.InnerText = ds.Tables(0).Rows(9).Item("pending").ToString + " Pending Approval"
            fourby1_link.HRef = ds.Tables(0).Rows(9).Item("url")

            fourby2_title.InnerText = ds.Tables(0).Rows(10).Item("Title")
            fourby2_value.InnerText = ds.Tables(0).Rows(10).Item("All")
            fourby2_pending.InnerText = ds.Tables(0).Rows(10).Item("pending").ToString + " Pending Approval"
            fourby2_link.HRef = ds.Tables(0).Rows(10).Item("url")


            fourby3_title.InnerText = ds.Tables(0).Rows(11).Item("Title")
            fourby3_value.InnerText = ds.Tables(0).Rows(11).Item("All")
            fourby3_pending.InnerText = ds.Tables(0).Rows(11).Item("pending").ToString + " Pending Approval"
            fourby3_link.HRef = ds.Tables(0).Rows(11).Item("url")

        Else
            connectdashwarehouse_USER_default()
        End If
    End Sub
    Public Sub connectdashwarehouse_ADMIN()
        Dim ds As New DataSet
        cmd = New SqlCommand(" SELECT * from (select 'Equity Trades' as [Title], count(*) as [All], (SELECT COUNT(*) FROM Custodian_Trades where TradeStatus='OUTSTANDING' and ApprovedBy is NULL) as [Pending], '~/TransferSec/ApproveNewTrade.aspx' as url from Custodian_Trades union select 'Bond Trades' as [Title], count(*) as [All], (SELECT COUNT(*) FROM Bond_Trades  where TradeStatus='OUTSTANDING' and ApprovedBy is NULL) as [Pending], '~/TransferSec/ApproveBondTrade.aspx' as url from Bond_Trades   union select 'Client Accounts' as [Title], count(*) as [All], (select count(*) from accounts_audit a where (a.AuthorizationState='A' or a.AuthorizationState='O') AND CASE WHEN ISNULL(a.OTP,'0')='0' THEN 'APPROVED' ELSE ISNULL(a.OTPStatus,'') END='APPROVED') as [Pending], '~/TransferSec/AccountsVerification.aspx' as url from Accounts_Clients  union select 'Vault' as [Title], count(*) as [All], (SELECT COUNT(*) FROM Deposit_Cert where [Status]='0' and DepType='DEPOSIT' and Rejected is NULL) as [Pending], '~/Custodian/depositapproval.aspx' as url from Deposit_Cert where [status]='Approved' and DepType='DEPOSIT'  union select 'Money Market' as [Title], count(*) as [All], (SELECT COUNT(*) FROM MoneyMarket where  approveddate is null and Rejected is NULL) as [Pending], '~/TransferSec/ApproveMoneyMarket.aspx' as url from MoneyMarket where TradeStatus='ON-GOING' and approveddate is not null and Rejected is NULL union select 'Cash Allocation' as [Title], count(*) as [All], (select Count(*) from trans_bank_alloc where Allocated='PENDING' and ApprovedBy is NULL) as [Pending], '~/TransferSec/CashAllocationApproval.aspx' as url from trans_bank_alloc   where [Allocated]='ALLOCATED' union select 'Money Market Redemption' as [Title], count(*) as [All], (select count(*) from MoneyMarketRedemption where ApprovedBy IS NULL and Rejected is NULL) as [Pending],'~/TransferSec/ApproveMoneyMarketRedemption.aspx' as url from MoneyMarketRedemption where ApprovedBy IS NOT NULL  union  select 'Money Market Rollover' as [Title], count(*) as [All], (select count(*) from MoneyMarketRollover where ApprovedBy IS NULL and Rejected is NULL) as [Pending],'~/TransferSec/ApproveRollover.aspx' as url from MoneyMarketRollover where ApprovedBy IS NOT NULL  union   select 'Bond Reconciliation' as [Title], count(*) as [All], (select COUNT(*) from Recon_AssetManager_Fixed_Approvals where   [Security] in (select code from bond) and Approved IS null and Rejected is NULL ) as [Pending], '~/TransferSec/UploadApprovalBond.aspx' as url from Recon_AssetManager_Fixed_Approvals WHERE [Security] in (select code from bond) and Approved='1' and Rejected is NULL union select 'Equity Reconciliation' as [Title], count(*) as [All], (select COUNT(*) from Recon_AssetManager_Approvals where CurrentStatus='Pending' ) as [Pending], '~/TransferSec/uploadapproval.aspx' as url from Recon_AssetManager_Approvals where CurrentStatus='APPROVED' union select 'Money Market Reconciliation' as [Title], count(*) as [All], (select COUNT(*) from Recon_AssetManager_Fixed_Approvals where   [Security] not in (select code from bond) and Approved IS null and Rejected is NULL ) as [Pending], '~/TransferSec/mmapproval.aspx' as url from Recon_AssetManager_Fixed_Approvals WHERE [Security] not in (select code from bond) and Approved='1' and Rejected is NULL union   select 'CDC Reconciliation' as [Title], count(*) as [All], (select COUNT(*) from Recon_cdc_Approvals  where CurrentStatus='Pending' ) as [Pending], '~/TransferSec/cdcapproval.aspx' as url from Recon_cdc_Approvals  where CurrentStatus='APPROVED' union select 'Cash Reconciliation' as [Title], count(*) as [All], (select COUNT(*) from Bank_Recon_Approval   where [Status]='PENDING' ) as [Pending], '~/TransferSec/bankapproval.aspx' as url from Bank_Recon_Approval  where [Status]='APPROVED'UNION select 'Participants Approval' as [Title], count(*) as [All], (select COUNT(*) from client_companies_audit where approvedby is NULL AND rejectedby is NULL) as [Pending], '~/Parameters/ClientCompanySetupAccept.aspx' as url from Client_Companies UNION select 'Rejected Participants' as [Title], count(*) as [All], 0 as [Pending], '~/Parameters/ClientCompanySetupRejected.aspx' as url from Client_Companies_Audit where RejectedBy is NOT NULL union select 'Users' as [Title], count(*) as [All], (select count(*) from SystemUsers_Temp WHERE ApprovedBy is NULL and Rejected is NULL) as [Pending], '~/CDSMode/UserAccountsApproval.aspx' as url from SystemUsers  union  select 'Other Approvals', count(*) as [All], (select count(*) from tbl_uncommitted where [status]='0') as [Pending], '~/CDSMode/approvesuper.aspx' as url from tbl_uncommitted) j where title in (select title from dash_pref where username='" + Session("Username") + "')", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "tbl_SettlementSummary2")
        If (ds.Tables(0).Rows.Count > 0) Then
            onebyone_title.InnerText = ds.Tables(0).Rows(0).Item("Title")
            onebyone_value.InnerText = ds.Tables(0).Rows(0).Item("All")
            onebyone_pending.InnerText = ds.Tables(0).Rows(0).Item("pending").ToString + " Pending Approval"
            onebyone_link.HRef = ds.Tables(0).Rows(0).Item("url")


            onebytwo_title.InnerText = ds.Tables(0).Rows(1).Item("Title")
            onebytwo_value.InnerText = ds.Tables(0).Rows(1).Item("All")
            onebytwo_pending.InnerText = ds.Tables(0).Rows(1).Item("pending").ToString + " Pending Approval"
            onebytwo_link.HRef = ds.Tables(0).Rows(1).Item("url")


            onebythree_title.InnerText = ds.Tables(0).Rows(2).Item("Title")
            onebythree_value.InnerText = ds.Tables(0).Rows(2).Item("All")
            onebythree_pending.InnerText = ds.Tables(0).Rows(2).Item("pending").ToString + " Pending Approval"
            onebythree_link.HRef = ds.Tables(0).Rows(2).Item("url")

            twobyone_title.InnerText = ds.Tables(0).Rows(3).Item("Title")
            twobyone_value.InnerText = ds.Tables(0).Rows(3).Item("All")
            twobyone_pending.InnerText = ds.Tables(0).Rows(3).Item("pending").ToString + " Pending Approval"
            twobyone_link.HRef = ds.Tables(0).Rows(3).Item("url")



            twobytwo_title.InnerText = ds.Tables(0).Rows(4).Item("Title")
            twobytwo_value.InnerText = ds.Tables(0).Rows(4).Item("All")
            twobytwo_pending.InnerText = ds.Tables(0).Rows(4).Item("pending").ToString + " Pending Approval"
            twobytwo_link.HRef = ds.Tables(0).Rows(4).Item("url")

            twobythree_title.InnerText = ds.Tables(0).Rows(5).Item("Title")
            twobythree_value.InnerText = ds.Tables(0).Rows(5).Item("All")
            twobythree_pending.InnerText = ds.Tables(0).Rows(5).Item("pending").ToString + " Pending Approval"
            twobythree_link.HRef = ds.Tables(0).Rows(5).Item("url")


            threebyone_title.InnerText = ds.Tables(0).Rows(6).Item("Title")
            threebyone_value.InnerText = ds.Tables(0).Rows(6).Item("All")
            threebyone_pending.InnerText = ds.Tables(0).Rows(6).Item("pending").ToString + " Pending Approval"
            threebyone_link.HRef = ds.Tables(0).Rows(6).Item("url")

            threebytwo_title.InnerText = ds.Tables(0).Rows(7).Item("Title")
            threebytwo_value.InnerText = ds.Tables(0).Rows(7).Item("All")
            threebytwo_pending.InnerText = ds.Tables(0).Rows(7).Item("pending").ToString + " Pending Approval"
            threebytwo_link.HRef = ds.Tables(0).Rows(7).Item("url")


            threebythree_title.InnerText = ds.Tables(0).Rows(8).Item("Title")
            threebythree_value.InnerText = ds.Tables(0).Rows(8).Item("All")
            threebythree_pending.InnerText = ds.Tables(0).Rows(8).Item("pending").ToString + " Pending Approval"
            threebythree_link.HRef = ds.Tables(0).Rows(8).Item("url")



            fourby1_title.InnerText = ds.Tables(0).Rows(9).Item("Title")
            fourby1_value.InnerText = ds.Tables(0).Rows(9).Item("All")
            fourby1_pending.InnerText = ds.Tables(0).Rows(9).Item("pending").ToString + " Pending Approval"
            fourby1_link.HRef = ds.Tables(0).Rows(9).Item("url")

            fourby2_title.InnerText = ds.Tables(0).Rows(10).Item("Title")
            fourby2_value.InnerText = ds.Tables(0).Rows(10).Item("All")
            fourby2_pending.InnerText = ds.Tables(0).Rows(10).Item("pending").ToString + " Pending Approval"
            fourby2_link.HRef = ds.Tables(0).Rows(10).Item("url")


            fourby3_title.InnerText = ds.Tables(0).Rows(11).Item("Title")
            fourby3_value.InnerText = ds.Tables(0).Rows(11).Item("All")
            fourby3_pending.InnerText = ds.Tables(0).Rows(11).Item("pending").ToString + " Pending Approval"
            fourby3_link.HRef = ds.Tables(0).Rows(11).Item("url")

        Else
            connectdashwarehouse_ADMIN_default()
        End If
    End Sub
    Public Sub connectdashwarehouse_ADMIN_default()
        Dim ds As New DataSet
        cmd = New SqlCommand("SELECT * from (select 'Equity Trades' as [Title], count(*) as [All], (SELECT COUNT(*) FROM Custodian_Trades where TradeStatus='OUTSTANDING' and ApprovedBy is NULL) as [Pending], '~/TransferSec/ApproveNewTrade.aspx' as url from Custodian_Trades union select 'Bond Trades' as [Title], count(*) as [All], (SELECT COUNT(*) FROM Bond_Trades  where TradeStatus='OUTSTANDING' and ApprovedBy is NULL) as [Pending], '~/TransferSec/ApproveBondTrade.aspx' as url from Bond_Trades   union select 'Client Accounts' as [Title], count(*) as [All], (select count(*) from accounts_audit a where (a.AuthorizationState='A' or a.AuthorizationState='O') AND CASE WHEN ISNULL(a.OTP,'0')='0' THEN 'APPROVED' ELSE ISNULL(a.OTPStatus,'') END='APPROVED' ) as [Pending], '~/TransferSec/AccountsVerification.aspx' as url from Accounts_Clients  union select 'Vault' as [Title], count(*) as [All], (SELECT COUNT(*) FROM Deposit_Cert where [Status]='0' and DepType='DEPOSIT' and Rejected is NULL) as [Pending], '~/Custodian/depositapproval.aspx' as url from Deposit_Cert where [status]='Approved' and DepType='DEPOSIT'  union select 'Money Market' as [Title], count(*) as [All], (SELECT COUNT(*) FROM MoneyMarket where  approveddate is null and Rejected is NULL) as [Pending], '~/TransferSec/ApproveMoneyMarket.aspx' as url from MoneyMarket where TradeStatus='ON-GOING' and approveddate is not null and Rejected is NULL union select 'Cash Allocation' as [Title], count(*) as [All], (select Count(*) from trans_bank_alloc where Allocated='PENDING' and ApprovedBy is NULL) as [Pending], '~/TransferSec/CashAllocationApproval.aspx' as url from trans_bank_alloc   where [Allocated]='ALLOCATED' union select 'Money Market Redemption' as [Title], count(*) as [All], (select count(*) from MoneyMarketRedemption where ApprovedBy IS NULL and Rejected is NULL) as [Pending],'~/TransferSec/ApproveMoneyMarketRedemption.aspx' as url from MoneyMarketRedemption where ApprovedBy IS NOT NULL  union  select 'Money Market Rollover' as [Title], count(*) as [All], (select count(*) from MoneyMarketRollover where ApprovedBy IS NULL and Rejected is NULL) as [Pending],'~/TransferSec/ApproveRollover.aspx' as url from MoneyMarketRollover where ApprovedBy IS NOT NULL  union   select 'Bond Reconciliation' as [Title], count(*) as [All], (select COUNT(*) from Recon_AssetManager_Fixed_Approvals where   [Security] in (select code from bond) and Approved IS null and Rejected is NULL ) as [Pending], '~/TransferSec/UploadApprovalBond.aspx' as url from Recon_AssetManager_Fixed_Approvals WHERE [Security] in (select code from bond) and Approved='1' and Rejected is NULL union select 'Equity Reconciliation' as [Title], count(*) as [All], (select COUNT(*) from Recon_AssetManager_Approvals where CurrentStatus='Pending' ) as [Pending], '~/TransferSec/uploadapproval.aspx' as url from Recon_AssetManager_Approvals where CurrentStatus='APPROVED' union select 'Money Market Reconciliation' as [Title], count(*) as [All], (select COUNT(*) from Recon_AssetManager_Fixed_Approvals where   [Security] not in (select code from bond) and Approved IS null and Rejected is NULL ) as [Pending], '~/TransferSec/mmapproval.aspx' as url from Recon_AssetManager_Fixed_Approvals WHERE [Security] not in (select code from bond) and Approved='1' and Rejected is NULL union   select 'CDC Reconciliation' as [Title], count(*) as [All], (select COUNT(*) from Recon_cdc_Approvals  where CurrentStatus='Pending' ) as [Pending], '~/TransferSec/cdcapproval.aspx' as url from Recon_cdc_Approvals  where CurrentStatus='APPROVED' union select 'Cash Reconciliation' as [Title], count(*) as [All], (select COUNT(*) from Bank_Recon_Approval   where [Status]='PENDING' ) as [Pending], '~/TransferSec/bankapproval.aspx' as url from Bank_Recon_Approval  where [Status]='APPROVED'UNION select 'Participants Approval' as [Title], count(*) as [All], (select COUNT(*) from client_companies_audit where approvedby is NULL AND rejectedby is NULL) as [Pending], '~/Parameters/ClientCompanySetupAccept.aspx' as url from Client_Companies UNION select 'Rejected Participants' as [Title], count(*) as [All], 0 as [Pending], '~/Parameters/ClientCompanySetupRejected.aspx' as url from Client_Companies_Audit where RejectedBy is NOT NULL union select 'Users' as [Title], count(*) as [All], (select count(*) from SystemUsers_Temp WHERE ApprovedBy is NULL and Rejected is NULL) as [Pending], '~/CDSMode/UserAccountsApproval.aspx' as url from SystemUsers  union  select 'Other Approvals', count(*) as [All], (select count(*) from tbl_uncommitted where [status]='0') as [Pending], '~/CDSMode/approvesuper.aspx' as url from tbl_uncommitted) j", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "tbl_SettlementSummary2")
        If (ds.Tables(0).Rows.Count > 0) Then
            onebyone_title.InnerText = ds.Tables(0).Rows(0).Item("Title")
            onebyone_value.InnerText = ds.Tables(0).Rows(0).Item("All")
            onebyone_pending.InnerText = ds.Tables(0).Rows(0).Item("pending").ToString + " Pending Approval"
            onebyone_link.HRef = ds.Tables(0).Rows(0).Item("url")


            onebytwo_title.InnerText = ds.Tables(0).Rows(1).Item("Title")
            onebytwo_value.InnerText = ds.Tables(0).Rows(1).Item("All")
            onebytwo_pending.InnerText = ds.Tables(0).Rows(1).Item("pending").ToString + " Pending Approval"
            onebytwo_link.HRef = ds.Tables(0).Rows(1).Item("url")


            onebythree_title.InnerText = ds.Tables(0).Rows(2).Item("Title")
            onebythree_value.InnerText = ds.Tables(0).Rows(2).Item("All")
            onebythree_pending.InnerText = ds.Tables(0).Rows(2).Item("pending").ToString + " Pending Approval"
            onebythree_link.HRef = ds.Tables(0).Rows(2).Item("url")

            twobyone_title.InnerText = ds.Tables(0).Rows(3).Item("Title")
            twobyone_value.InnerText = ds.Tables(0).Rows(3).Item("All")
            twobyone_pending.InnerText = ds.Tables(0).Rows(3).Item("pending").ToString + " Pending Approval"
            twobyone_link.HRef = ds.Tables(0).Rows(3).Item("url")



            twobytwo_title.InnerText = ds.Tables(0).Rows(4).Item("Title")
            twobytwo_value.InnerText = ds.Tables(0).Rows(4).Item("All")
            twobytwo_pending.InnerText = ds.Tables(0).Rows(4).Item("pending").ToString + " Pending Approval"
            twobytwo_link.HRef = ds.Tables(0).Rows(4).Item("url")

            twobythree_title.InnerText = ds.Tables(0).Rows(5).Item("Title")
            twobythree_value.InnerText = ds.Tables(0).Rows(5).Item("All")
            twobythree_pending.InnerText = ds.Tables(0).Rows(5).Item("pending").ToString + " Pending Approval"
            twobythree_link.HRef = ds.Tables(0).Rows(5).Item("url")


            threebyone_title.InnerText = ds.Tables(0).Rows(6).Item("Title")
            threebyone_value.InnerText = ds.Tables(0).Rows(6).Item("All")
            threebyone_pending.InnerText = ds.Tables(0).Rows(6).Item("pending").ToString + " Pending Approval"
            threebyone_link.HRef = ds.Tables(0).Rows(6).Item("url")

            threebytwo_title.InnerText = ds.Tables(0).Rows(7).Item("Title")
            threebytwo_value.InnerText = ds.Tables(0).Rows(7).Item("All")
            threebytwo_pending.InnerText = ds.Tables(0).Rows(7).Item("pending").ToString + " Pending Approval"
            threebytwo_link.HRef = ds.Tables(0).Rows(7).Item("url")


            threebythree_title.InnerText = ds.Tables(0).Rows(8).Item("Title")
            threebythree_value.InnerText = ds.Tables(0).Rows(8).Item("All")
            threebythree_pending.InnerText = ds.Tables(0).Rows(8).Item("pending").ToString + " Pending Approval"
            threebythree_link.HRef = ds.Tables(0).Rows(8).Item("url")



            fourby1_title.InnerText = ds.Tables(0).Rows(9).Item("Title")
            fourby1_value.InnerText = ds.Tables(0).Rows(9).Item("All")
            fourby1_pending.InnerText = ds.Tables(0).Rows(9).Item("pending").ToString + " Pending Approval"
            fourby1_link.HRef = ds.Tables(0).Rows(9).Item("url")

            fourby2_title.InnerText = ds.Tables(0).Rows(10).Item("Title")
            fourby2_value.InnerText = ds.Tables(0).Rows(10).Item("All")
            fourby2_pending.InnerText = ds.Tables(0).Rows(10).Item("pending").ToString + " Pending Approval"
            fourby2_link.HRef = ds.Tables(0).Rows(10).Item("url")


            fourby3_title.InnerText = ds.Tables(0).Rows(11).Item("Title")
            fourby3_value.InnerText = ds.Tables(0).Rows(11).Item("All")
            fourby3_pending.InnerText = ds.Tables(0).Rows(11).Item("pending").ToString + " Pending Approval"
            fourby3_link.HRef = ds.Tables(0).Rows(11).Item("url")


        End If
    End Sub
    Public Sub connectdashwarehouse_USER_default()
        Dim ds As New DataSet
        cmd = New SqlCommand("SELECT * from (select 'Equity Trades' as [Title], count(*) as [All], (SELECT COUNT(*) FROM Custodian_Trades where TradeStatus='OUTSTANDING' and ApprovedBy is NULL) as [Pending], '' as url from Custodian_Trades union select 'Bond Trades' as [Title], count(*) as [All], (SELECT COUNT(*) FROM Bond_Trades  where TradeStatus='OUTSTANDING' and ApprovedBy is NULL) as [Pending], '' as url from Bond_Trades   union select 'Client Accounts' as [Title], count(*) as [All], (select count(*) from accounts_audit a where (a.AuthorizationState='A' or a.AuthorizationState='O') AND CASE WHEN ISNULL(a.OTP,'0')='0' THEN 'APPROVED' ELSE ISNULL(a.OTPStatus,'') END='APPROVED' ) as [Pending], '' as url from Accounts_Clients  union select 'Vault' as [Title], count(*) as [All], (SELECT COUNT(*) FROM Deposit_Cert where [Status]='0' and DepType='DEPOSIT' and Rejected is NULL) as [Pending], '' as url from Deposit_Cert where [status]='Approved' and DepType='DEPOSIT'  union select 'Money Market' as [Title], count(*) as [All], (SELECT COUNT(*) FROM MoneyMarket where  approveddate is null and Rejected is NULL) as [Pending], '' as url from MoneyMarket where TradeStatus='ON-GOING' and approveddate is not null and Rejected is NULL union select 'Cash Allocation' as [Title], count(*) as [All], (select Count(*) from trans_bank_alloc where Allocated='PENDING' and ApprovedBy is NULL) as [Pending], '' as url from trans_bank_alloc   where [Allocated]='ALLOCATED' union select 'Money Market Redemption' as [Title], count(*) as [All], (select count(*) from MoneyMarketRedemption where ApprovedBy IS NULL and Rejected is NULL) as [Pending],'' as url from MoneyMarketRedemption where ApprovedBy IS NOT NULL  union  select 'Money Market Rollover' as [Title], count(*) as [All], (select count(*) from MoneyMarketRollover where ApprovedBy IS NULL and Rejected is NULL) as [Pending],'' as url from MoneyMarketRollover where ApprovedBy IS NOT NULL  union   select 'Bond Reconciliation' as [Title], count(*) as [All], (select COUNT(*) from Recon_AssetManager_Fixed_Approvals where   [Security] in (select code from bond) and Approved IS null and Rejected is NULL ) as [Pending], '' as url from Recon_AssetManager_Fixed_Approvals WHERE [Security] in (select code from bond) and Approved='1' and Rejected is NULL union select 'Equity Reconciliation' as [Title], count(*) as [All], (select COUNT(*) from Recon_AssetManager_Approvals where CurrentStatus='Pending' ) as [Pending], '' as url from Recon_AssetManager_Approvals where CurrentStatus='APPROVED' union select 'Money Market Reconciliation' as [Title], count(*) as [All], (select COUNT(*) from Recon_AssetManager_Fixed_Approvals where   [Security] not in (select code from bond) and Approved IS null and Rejected is NULL ) as [Pending], '' as url from Recon_AssetManager_Fixed_Approvals WHERE [Security] not in (select code from bond) and Approved='1' and Rejected is NULL union   select 'CDC Reconciliation' as [Title], count(*) as [All], (select COUNT(*) from Recon_cdc_Approvals  where CurrentStatus='Pending' ) as [Pending], '' as url from Recon_cdc_Approvals  where CurrentStatus='APPROVED' union select 'Cash Reconciliation' as [Title], count(*) as [All], (select COUNT(*) from Bank_Recon_Approval   where [Status]='PENDING' ) as [Pending], '' as url from Bank_Recon_Approval  where [Status]='APPROVED'UNION select 'Participants Approval' as [Title], count(*) as [All], (select COUNT(*) from client_companies_audit where approvedby is NULL AND rejectedby is NULL) as [Pending], '' as url from Client_Companies UNION select 'Rejected Participants' as [Title], count(*) as [All], 0 as [Pending], '' as url from Client_Companies_Audit where RejectedBy is NOT NULL union select 'Users' as [Title], count(*) as [All], (select count(*) from SystemUsers_Temp WHERE ApprovedBy is NULL and Rejected is NULL) as [Pending], '' as url from SystemUsers  union  select 'Other Approvals', count(*) as [All], (select count(*) from tbl_uncommitted where [status]='0') as [Pending], '' as url from tbl_uncommitted) j", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "tbl_SettlementSummary2")
        If (ds.Tables(0).Rows.Count > 0) Then
            onebyone_title.InnerText = ds.Tables(0).Rows(0).Item("Title")
            onebyone_value.InnerText = ds.Tables(0).Rows(0).Item("All")
            onebyone_pending.InnerText = ds.Tables(0).Rows(0).Item("pending").ToString + " Pending Approval"
            onebyone_link.HRef = ds.Tables(0).Rows(0).Item("url")


            onebytwo_title.InnerText = ds.Tables(0).Rows(1).Item("Title")
            onebytwo_value.InnerText = ds.Tables(0).Rows(1).Item("All")
            onebytwo_pending.InnerText = ds.Tables(0).Rows(1).Item("pending").ToString + " Pending Approval"
            onebytwo_link.HRef = ds.Tables(0).Rows(1).Item("url")


            onebythree_title.InnerText = ds.Tables(0).Rows(2).Item("Title")
            onebythree_value.InnerText = ds.Tables(0).Rows(2).Item("All")
            onebythree_pending.InnerText = ds.Tables(0).Rows(2).Item("pending").ToString + " Pending Approval"
            onebythree_link.HRef = ds.Tables(0).Rows(2).Item("url")

            twobyone_title.InnerText = ds.Tables(0).Rows(3).Item("Title")
            twobyone_value.InnerText = ds.Tables(0).Rows(3).Item("All")
            twobyone_pending.InnerText = ds.Tables(0).Rows(3).Item("pending").ToString + " Pending Approval"
            twobyone_link.HRef = ds.Tables(0).Rows(3).Item("url")



            twobytwo_title.InnerText = ds.Tables(0).Rows(4).Item("Title")
            twobytwo_value.InnerText = ds.Tables(0).Rows(4).Item("All")
            twobytwo_pending.InnerText = ds.Tables(0).Rows(4).Item("pending").ToString + " Pending Approval"
            twobytwo_link.HRef = ds.Tables(0).Rows(4).Item("url")

            twobythree_title.InnerText = ds.Tables(0).Rows(5).Item("Title")
            twobythree_value.InnerText = ds.Tables(0).Rows(5).Item("All")
            twobythree_pending.InnerText = ds.Tables(0).Rows(5).Item("pending").ToString + " Pending Approval"
            twobythree_link.HRef = ds.Tables(0).Rows(5).Item("url")


            threebyone_title.InnerText = ds.Tables(0).Rows(6).Item("Title")
            threebyone_value.InnerText = ds.Tables(0).Rows(6).Item("All")
            threebyone_pending.InnerText = ds.Tables(0).Rows(6).Item("pending").ToString + " Pending Approval"
            threebyone_link.HRef = ds.Tables(0).Rows(6).Item("url")

            threebytwo_title.InnerText = ds.Tables(0).Rows(7).Item("Title")
            threebytwo_value.InnerText = ds.Tables(0).Rows(7).Item("All")
            threebytwo_pending.InnerText = ds.Tables(0).Rows(7).Item("pending").ToString + " Pending Approval"
            threebytwo_link.HRef = ds.Tables(0).Rows(7).Item("url")


            threebythree_title.InnerText = ds.Tables(0).Rows(8).Item("Title")
            threebythree_value.InnerText = ds.Tables(0).Rows(8).Item("All")
            threebythree_pending.InnerText = ds.Tables(0).Rows(8).Item("pending").ToString + " Pending Approval"
            threebythree_link.HRef = ds.Tables(0).Rows(8).Item("url")



            fourby1_title.InnerText = ds.Tables(0).Rows(9).Item("Title")
            fourby1_value.InnerText = ds.Tables(0).Rows(9).Item("All")
            fourby1_pending.InnerText = ds.Tables(0).Rows(9).Item("pending").ToString + " Pending Approval"
            fourby1_link.HRef = ds.Tables(0).Rows(9).Item("url")

            fourby2_title.InnerText = ds.Tables(0).Rows(10).Item("Title")
            fourby2_value.InnerText = ds.Tables(0).Rows(10).Item("All")
            fourby2_pending.InnerText = ds.Tables(0).Rows(10).Item("pending").ToString + " Pending Approval"
            fourby2_link.HRef = ds.Tables(0).Rows(10).Item("url")


            fourby3_title.InnerText = ds.Tables(0).Rows(11).Item("Title")
            fourby3_value.InnerText = ds.Tables(0).Rows(11).Item("All")
            fourby3_pending.InnerText = ds.Tables(0).Rows(11).Item("pending").ToString + " Pending Approval"
            fourby3_link.HRef = ds.Tables(0).Rows(11).Item("url")


        End If
    End Sub
    Protected Sub btnSaveContract3_Click(sender As Object, e As EventArgs) Handles btnSaveContract3.Click
        ASPxPopupControl1.AllowDragging = True
        ASPxPopupControl1.ShowCloseButton = True
        ASPxPopupControl1.ShowOnPageLoad = True
        ASPxPopupControl1.PopupHorizontalAlign = DevExpress.Web.ASPxClasses.PopupHorizontalAlign.WindowCenter
        ASPxPopupControl1.PopupVerticalAlign = DevExpress.Web.ASPxClasses.PopupVerticalAlign.WindowCenter

        Page.MaintainScrollPositionOnPostBack = True
    End Sub
    Protected Sub btnSaveContract5_Click(sender As Object, e As EventArgs) Handles btnSaveContract5.Click

        Dim keys As List(Of Object) = grdcols.GetCurrentPageRowValues(New String() {"title"})

        Dim ct As Integer = 0
        For Each key As Object In keys
            Dim chk As ASPxCheckBox = TryCast(grdcols.FindRowCellTemplateControlByKey(key, TryCast(grdcols.Columns("Selec"), GridViewDataColumn), "chk1"), ASPxCheckBox)

            Dim check As Boolean = chk.Checked

            If check = True Then
                ct = ct + 1

            End If


        Next
        If ct <> 12 Then
            msgbox("Please tick 12 Items to show on the dashboard!")
            Exit Sub
        Else
            deletecurr(Session("Username"))

            For Each key As Object In keys
                Dim chk As ASPxCheckBox = TryCast(grdcols.FindRowCellTemplateControlByKey(key, TryCast(grdcols.Columns("Selec"), GridViewDataColumn), "chk1"), ASPxCheckBox)

                Dim check As Boolean = chk.Checked
                If check = True Then

                    addcols(key)


                End If

            Next
        End If

        Session("finish") = "true"
        Response.Redirect(Request.RawUrl)
    End Sub
    Public Sub deletecurr(username As String)
        cmd = New SqlCommand("delete from dash_pref where username='" + Session("Username") + "'", cn)
        If (cn.State = ConnectionState.Open) Then
            cn.Close()
        End If
        cn.Open()
        cmd.ExecuteNonQuery()
        cn.Close()
    End Sub
    Public Sub addcols(col As String)
        cmd = New SqlCommand("insert into dash_pref (title, username, dateset ) values ('" + col + "','" + Session("Username") + "',getdate())", cn)
        If (cn.State = ConnectionState.Open) Then
            cn.Close()
        End If
        cn.Open()
        cmd.ExecuteNonQuery()
        cn.Close()
    End Sub
End Class
