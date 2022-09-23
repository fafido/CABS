Partial Class TransferSec_transfersharesinter
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
                msgbox("Transfer successfully captured")
            End If
            Page.MaintainScrollPositionOnPostBack = True
            If (Not IsPostBack) Then
                checkSessionState()
                getCompany()
                GetBatchTypes()
                Getbrokers()
                getwarehouses()


            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub getCompany()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("Select Company,Id from para_company", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "para_company")
            cmbnewwarehouse.DataSource = ds.Tables(0)
            cmbnewwarehouse.TextField = "Company"
            cmbnewwarehouse.ValueField = "Id"
            cmbnewwarehouse.DataBind()
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub getwarehouses()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select warehousename, warehousecode from warehousecreation", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "warehousecreation")
            cmbparaCompany.DataSource = ds.Tables(0)
            cmbparaCompany.TextField = "warehousename"
            cmbparaCompany.ValueField = "warehousecode"
            cmbparaCompany.DataBind()
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub GetBatchTypes()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("Select distinct (batch_Type) from Para_Batch_type order by Batch_Type", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "para_batch_type")
            If (ds.Tables(0).Rows.Count > 0) Then
                CmbBatchType.DataSource = ds.Tables(0)
                cmbBatchType.ValueField = "batch_Type"
                cmbBatchType.TextField = "batch_Type"
                CmbBatchType.DataBind()
            End If

        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub Getbrokers()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("Select distinct (broker_code), fnam from Para_Broker", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "para_broker")
            If (ds.Tables(0).Rows.Count > 0) Then
                cmbBatchType.DataSource = ds.Tables(0)
                cmbBatchType.ValueField = "broker_code"
                cmbBatchType.TextField = "fnam"
                cmbBatchType.DataBind()
            End If

        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub ASPxButton3_Click(sender As Object, e As EventArgs) Handles ASPxButton3.Click
        Dim shares As Double = txtBatchShares.Text
        Dim shareprice As Decimal = txtShareprice.Text
        Dim value As Double = shares * shareprice
        txtBatchValue.Text = value

        cmd = New SqlCommand("insert into batch_receipt (id,company, batch_shares, shareprice, batch_value, batch_date, lodger, balanced, verified, successful, batch_type, masttemp,broker_code) values ('0','" + cmbparaCompany.Text + "','" + txtBatchShares.Text + "','" + txtShareprice.Text + "','" + txtBatchValue.Text + "',Getdate(),'" + txtClientNo2.Text + "','0','0','0','Withdrawal','0','" + Session("brokercode") + "')", cn)
        If (cn.State = ConnectionState.Open) Then
            cn.Close()
        End If
        cn.Open()
        cmd.ExecuteNonQuery()
        cn.Close()

        Dim ds As New DataSet
        cmd = New SqlCommand("select batch_no from batch_receipt order by batch_no desc", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "batch_no")
        If (ds.Tables(0).Rows.Count > 0) Then
            txtClientNo.Visible = True
            txtClientNo.Text = ds.Tables(0).Rows(0).Item("batch_no")
        End If

        Panel3.Enabled = False
        Panel5.Enabled = True
        ' Panel9.Enabled = True


        msgbox("Batch Number:" + txtClientNo.Text + " has been successfully created. Please add some Shares and Share Certificates to the batch")


    End Sub

    Protected Sub ASPxButton10_Click(sender As Object, e As EventArgs) Handles ASPxButton10.Click
        If txtclientnumber.Text = "" Then
            msgbox("Please enter Account Number/Name to search")
            Exit Sub
        End If
        Dim ds As New DataSet
        cmd = New SqlCommand("select cds_number+' '+isnull(surname,'')+' '+isnull(middlename,'')+' '+isnull(forenames,'') as names, cds_number from accounts_clients where cds_number+' '+isnull(surname,'')+' '+isnull(middlename,'')+' '+isnull(forenames,'') like '%" + txtclientnumber.Text + "%'", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "names")
        If (ds.Tables(0).Rows.Count > 0) Then
            ListBox1.DataSource = ds
            ListBox1.DataTextField = "names"
            ListBox1.DataValueField = "cds_number"
            ListBox1.DataBind()

        End If
    End Sub

    Protected Sub txtClientNo3_TextChanged(sender As Object, e As EventArgs) Handles txtclientnumber.TextChanged

    End Sub

    Protected Sub ASPxButton12_Click(sender As Object, e As EventArgs) Handles ASPxButton12.Click
        Try
            Dim av As Double = txtavailableshares.Text
            Dim totrans As Double = txtshares.Text

            If av < totrans Then
                msgbox("Please enter units less or equal to available units!")
            Else
                Dim m As String = ListBox1.SelectedItem.Text
                If m = "" Then
                    msgbox("Please select the Transferor")
                    Exit Sub
                End If
                Dim n As String = ListBox2.SelectedItem.Text
                If n = "" Then
                    msgbox("Please select the Transferee")
                    Exit Sub
                End If
                cmd = New SqlCommand("insert into share_transfer (amount_to_transfer, transferor, transferee, [date], [status], query, company, ReceiptID) values ('" + txtshares.Text + "', '" + ListBox1.SelectedItem.ToString() + "','" + ListBox2.SelectedItem.ToString() + "',getDate(),'0','" + Session("Id") + "','" + cmbparaCompany.SelectedItem.ToString() + "','" + cmbparaCompany.SelectedIndex.ToString() + "')", cn)
                If (cn.State = ConnectionState.Open) Then
                    cn.Close()
                End If
                cn.Open()
                cmd.ExecuteNonQuery()
                cn.Close()
                Session("finish") = "yes"
                Response.Redirect(Request.RawUrl)
            End If
        Catch ex As Exception
            msgbox("Please select the relevant Account to Transfer from and Transfer to! Units to transfer should also be numeric")
        End Try

    End Sub

    'Protected Sub ASPxButton13_Click(sender As Object, e As EventArgs) Handles ASPxButton13.Click
    '    Dim ds As New DataSet
    '    cmd = New SqlCommand("select (select sum(shares) from batch_certs where batch_no=" + txtClientNo.Text + ") as certs_total, (select batch_shares from Batch_receipt where batch_no=" + txtClientNo.Text + ") as batch_tot", cn)
    '    adp = New SqlDataAdapter(cmd)
    '    adp.Fill(ds, "batch_certs")
    '    If (ds.Tables(0).Rows.Count > 0) Then
    '        If ds.Tables(0).Rows(0).Item("certs_total") = ds.Tables(0).Rows(0).Item("batch_tot") Then
    '            cmd = New SqlCommand("update batch_receipt set balanced='1' where batch_no='" + txtClientNo.Text + "'", cn)
    '            If (cn.State = ConnectionState.Open) Then
    '                cn.Close()
    '            End If
    '            cn.Open()
    '            cmd.ExecuteNonQuery()
    '            cn.Close()
    '            Session("finish") = "yes"
    '            Response.Redirect(Request.RawUrl)
    '        Else
    '            msgbox("Specified batch total not balancing with the total shares you added!")
    '        End If
    '    End If
    'End Sub

    Protected Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged
        Dim ds1 As New DataSet
        cmd = New SqlCommand("SELECT id, Commodity+'/'+Grade as [Prod] from WR where holder='" + ListBox1.SelectedItem.Value.ToString + "' and quantity>0 AND ([status]='ISSUED' OR [status]='SPLIT')", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds1, "names1")
        If (ds1.Tables(0).Rows.Count > 0) Then
            cmbparaCompany.DataSource = ds1
            cmbparaCompany.TextField = "Prod"
            cmbparaCompany.ValueField = "id"
            cmbparaCompany.DataBind()

        End If
    End Sub

    Protected Sub ASPxButton15_Click(sender As Object, e As EventArgs) Handles ASPxButton15.Click
        If txtclientnumber0.Text = "" Then
            msgbox("Please enter Account Number/Name to search")
            Exit Sub
        End If

        Dim ds As New DataSet
        cmd = New SqlCommand("select cds_number+' '+isnull(surname,'')+' '+isnull(middlename,'')+' '+isnull(forenames,'') as names, cds_number from accounts_clients where cds_number+' '+isnull(surname,'')+' '+isnull(middlename,'')+' '+isnull(forenames,'') like '%" + txtclientnumber0.Text + "%'", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "names")
        If (ds.Tables(0).Rows.Count > 0) Then
            ListBox2.DataSource = ds
            ListBox2.DataTextField = "names"
            ListBox2.DataValueField = "cds_number"
            ListBox2.DataBind()

        End If
    End Sub


    Protected Sub cmbparaCompany_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbparaCompany.SelectedIndexChanged
        Dim dsport As New DataSet
        cmd = New SqlCommand("select quantity from wr where warehousephysical='" + cmbparaCompany.SelectedItem.Value.ToString + "' ", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(dsport, "wr")
        If (dsport.Tables(0).Rows.Count > 0) Then
            txtavailableshares.Text = dsport.Tables(0).Rows(0).Item("quantity")
        Else
            txtavailableshares.Text = 0

        End If
    End Sub
End Class
