Partial Class TransferSec_BatchAuthorizations
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
                loadbatches()
            End If
            If Session("finish") = "yes" Then
                Session("finish") = ""
                msgbox("Successful")
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    'Protected Sub ASPxButton6_Click(sender As Object, e As EventArgs) Handles ASPxButton6.Click
    '    Dim dsi As New DataSet
    '    cmd = New SqlCommand("select * from client_companies where company_type='CUSTODIAN'", cn)
    '    adp = New SqlDataAdapter(cmd)

    '    adp.Fill(dsi, "para_cust")
    '    If (dsi.Tables(0).Rows.Count > 0) Then
    '        dsi.WriteXml(System.AppDomain.CurrentDomain.BaseDirectory() & "\XML_Report_Files\report.xml", XmlWriteMode.WriteSchema)
    '    End If
    '    msgbox("success")
    'End Sub

    Protected Sub cmbSavedBatches_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbSavedBatches.SelectedIndexChanged
        getdetails()

    End Sub
    Public Sub loadbatches()
        Dim ds As New DataSet
        cmd = New SqlCommand("select b.batch_no as [Batch No],b.Company as [Company], b.Batch_Shares as [Batch Shares],b.security_type as [Security Type], convert(date,b.Batch_date) as [Date], b.Lodger as [Lodger],cc.company_name as [Broker] from Batch_receipt b, Client_Companies cc where cc.Company_Code= b.broker_code and b.balanced='1' and b.broker_code='" + Session("brokercode") + "' and b.verified='0'", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "para_cust")
        If (ds.Tables(0).Rows.Count > 0) Then
            cmbSavedBatches.DataSource = ds
            cmbSavedBatches.TextField = "batch no"
            cmbSavedBatches.ValueField = "batch no"
            cmbSavedBatches.DataBind()
        End If
    End Sub
    Public Sub getdetails()
        Dim ds As New DataSet
        cmd = New SqlCommand("select id, batch_no, company, batch_shares, shareprice, batch_value, batch_date, lodger, balanced, verified, successful,(select company_name from Client_Companies where company_code=(broker_code)) as [Broker], batch_type, masttemp, isnull(security_type,'') as security_type from batch_receipt where batch_no='" + cmbSavedBatches.Text + "' and balanced='1'", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "para_cust1")
        If (ds.Tables(0).Rows.Count > 0) Then
            txtbatchno.Text = ds.Tables(0).Rows(0).Item("batch_no")
            txtbatchdate.Text = ds.Tables(0).Rows(0).Item("batch_date")
            txtBatchShares.Text = ds.Tables(0).Rows(0).Item("batch_shares")
            txtbatchtype.Text = ds.Tables(0).Rows(0).Item("batch_type")
            txtBatchValue.Text = ds.Tables(0).Rows(0).Item("batch_value")
            txtbroker.Text = ds.Tables(0).Rows(0).Item("broker")
            txtcompany.Text = ds.Tables(0).Rows(0).Item("company")
            txtshareprice.Text = ds.Tables(0).Rows(0).Item("shareprice")
            txtClientNo2.Text = ds.Tables(0).Rows(0).Item("lodger")
            txtsecuritytype.Text = ds.Tables(0).Rows(0).Item("security_type")
            getcerts()

        End If
    End Sub
    Public Sub getcerts()
        Dim ds As New DataSet
        cmd = New SqlCommand("select id as [Entry ID], Batch_no as [Batch No], cds_number as [CDS Number], shares as [Shares] from batch_certs where batch_no='" + txtbatchno.Text + "'", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "para_cust2")
        If (ds.Tables(0).Rows.Count > 0) Then
            grdBatchedRecords.DataSource = ds
            grdBatchedRecords.DataBind()

        End If
    End Sub

    Protected Sub ASPxButton2_Click(sender As Object, e As EventArgs) Handles ASPxButton2.Click
        cmd = New SqlCommand("update batch_receipt set verified='1' where batch_no='" + txtbatchno.Text + "'", cn)
        If (cn.State = ConnectionState.Open) Then
            cn.Close()
        End If
        cn.Open()
        cmd.ExecuteNonQuery()
        Session("finish") = "yes"
        Response.Redirect(Request.RawUrl)

    End Sub

    Protected Sub ASPxButton3_Click(sender As Object, e As EventArgs) Handles ASPxButton3.Click

    End Sub
End Class
