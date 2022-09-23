Partial Class Parameters_dividendauthorizations
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
                getcompanies()

            End If
            If Session("finish") = "true" Then
                Session("finish") = ""
                msgbox("Instruction Saved!")
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Protected Sub clearall()
        txtDesc.Text = ""
        txtinterest.Text = ""

    End Sub
    Public Sub getcompanies()
        cmd = New SqlCommand("select issuer+' '+convert(nvarchar(50),payment_no) as Dividend from cds_router.dbo.dividend_instr", cn)
        Dim ds As New DataSet
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "companies")
        If ds.Tables(0).Rows.Count > 0 Then
            cmbsecurity.DataSource = ds
            cmbsecurity.TextField = "Dividend"
            cmbsecurity.ValueField = "Dividend"
            cmbsecurity.DataBind()
        End If
    End Sub
    Public Sub det(ByVal details As String)
        cmd = New SqlCommand("select issuer as company, payment_no, date_payment, rate, mess_1 from [CDS_ROUTER].[dbo].[dividend_instr] where issuer+' '+convert(nvarchar(50),payment_no)='" + details + "'", cn)
        Dim ds As New DataSet
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "companies")
        If ds.Tables(0).Rows.Count > 0 Then
            txtpaymentNo.Text = ds.Tables(0).Rows(0).Item("payment_no")
            txtinterest.Text = ds.Tables(0).Rows(0).Item("rate")
            txtDesc.Text = ds.Tables(0).Rows(0).Item("mess_1")
            cmbpaymentsdate.Text = ds.Tables(0).Rows(0).Item("date_payment")
        Else

        End If
    End Sub
    Public Sub getdivschedule(details As String)
        cmd = New SqlCommand("declare @div_detail nvarchar(100)='" + details + "' declare @divamount numeric(18,4)=(select rate from [CDS_ROUTER].[dbo].[dividend_instr] where issuer+' '+convert(nvarchar(50),payment_no)=@div_detail) declare @company as nvarchar(100) =  (select issuer from [CDS_ROUTER].[dbo].[dividend_instr] where issuer+' '+convert(nvarchar(50),payment_no)=@div_detail) declare @datecutoff as date = (select convert(date, date_payment) from  [CDS_ROUTER].[dbo].[dividend_instr] where issuer+' '+convert(nvarchar(50),payment_no)=@div_detail) declare @totalcutoff numeric(18,0)=(select sum(shares) from cds_router.dbo.trans where company=@company and convert(date,date_created)<=@datecutoff) select isnull(a.Surname,'')+' '+isnull(forenames,'') as [Name], t.Cds_number, sum(t.shares) as [Shares], sum(t.shares)/@totalcutoff*@divamount as [Dividend Amount] from cds_router.dbo.trans t, cds_router.dbo.Accounts_Clients_web a where t.company=@company and convert(date,t.date_created)<=convert(date, @datecutoff) and t.cds_number=a.cds_number group by t.cds_number,a.surname, a.forenames having sum(t.shares)>0", cn)
        Dim ds As New DataSet
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "companies")
        If ds.Tables(0).Rows.Count > 0 Then
            ASPxGridView2.DataSource = ds
            ASPxGridView2.DataBind()
        End If
    End Sub

    Protected Sub ASPxButton7_Click(sender As Object, e As EventArgs) Handles ASPxButton7.Click
        getdivschedule(cmbsecurity.SelectedItem.Text)
    End Sub
    Protected Sub creditctrade(details As String)

        cmd = New SqlCommand("declare @div_detail nvarchar(100)='" + details + "' declare @divamount numeric(18,4)=(select rate from [CDS_ROUTER].[dbo].[dividend_instr] where issuer+' '+convert(nvarchar(50),payment_no)=@div_detail) declare @company as nvarchar(100) =  (select issuer from [CDS_ROUTER].[dbo].[dividend_instr] where issuer+' '+convert(nvarchar(50),payment_no)=@div_detail) declare @datecutoff as date = (select convert(date, date_payment) from  [CDS_ROUTER].[dbo].[dividend_instr] where issuer+' '+convert(nvarchar(50),payment_no)=@div_detail) declare @totalcutoff numeric(18,0)=(select sum(shares) from cds_router.dbo.trans where company=@company and convert(date,date_created)<=@datecutoff) declare @div_payment_no nvarchar(50)=(select payment_no from [CDS_ROUTER].[dbo].[dividend_instr] where issuer+' '+convert(nvarchar(50),payment_no)=@div_detail) insert into cds_router.dbo.dividends (cdsnumber, divnumber, issuer,shares, PaymentDate, Net_Paid)  select t.cds_Number, @div_payment_no, @company, sum(t.shares) as [Shares],@datecutoff ,  sum(t.shares)/@totalcutoff*@divamount as [Dividend Amount] from cds_router.dbo.trans t, cds_router.dbo.Accounts_Clients_web a where t.company=@company and convert(date,t.date_created)<=@datecutoff and t.cds_number=a.cds_number group by t.cds_number, a.surname, a.forenames having sum(t.shares)>0 insert into cdsc.dbo.cashtrans ([description],transtype, amount, DateCreated, TransStatus , cds_number)  select 'DIVIDEND',@COMPANY+ 'DIVIDEND',sum(t.shares)/@totalcutoff*@divamount as [Dividend Amount], getdate(), '1',t.cds_number   from cds_router.dbo.trans t, cds_router.dbo.Accounts_Clients_web a where t.company=@company and convert(date,t.date_created)<=@datecutoff and t.cds_number=a.cds_number group by t.cds_number, a.surname, a.forenames having sum(t.shares)>0", cn)
        If cn.State = ConnectionState.Open Then
            cn.Close()
        End If
        cn.Open()
        Dim y As Integer = cmd.ExecuteNonQuery()
        cn.Close()

        ASPxButton8.Visible = False
        msgbox("Successfull")


    End Sub

    Protected Sub cmbsecurity_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbsecurity.SelectedIndexChanged
        det(cmbsecurity.SelectedItem.Text)
        If is_ctrade_credited(cmbsecurity.SelectedItem.Text) = True Then
            ASPxButton8.Visible = False
        Else
            ASPxButton8.Visible = True
        End If
    End Sub

    Protected Sub ASPxButton8_Click(sender As Object, e As EventArgs) Handles ASPxButton8.Click
        creditctrade(cmbsecurity.SelectedItem.Text)

    End Sub
    Private Function is_ctrade_credited(details As String) As Boolean
        cmd = New SqlCommand("select * from CDS_ROUTER.DBO.dividends where issuer+' '+convert(nvarchar(50),divnumber)='" + details + "'", cn)
        Dim ds As New DataSet
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "companies")
        If ds.Tables(0).Rows.Count > 0 Then
            Return True
        Else
            Return False
        End If
    End Function
End Class
