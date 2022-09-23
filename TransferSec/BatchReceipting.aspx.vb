Partial Class TransferSec_BatchReceipting
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
                getCompany()
                GetBatchTypes()
                Getbrokers()
                GetSecuritytypes()

            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub getCompany()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("Select Company as [Short Name], fnam as [Full Company Name] from para_company", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "para_company")
            cmbparaCompany.DataSource = ds.Tables(0)
            cmbparaCompany.TextField = "Short Name"
            cmbparaCompany.ValueField = "Short Name"
            cmbParaCompany.DataBind()
        Catch ex As Exception
            MsgBox(ex.Message)
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
    Public Sub GetSecuritytypes()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("Select security_name from security_type", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "para_batch_type")
            If (ds.Tables(0).Rows.Count > 0) Then
                cmbsecuritytype.DataSource = ds.Tables(0)
                cmbsecuritytype.ValueField = "security_name"
                cmbsecuritytype.TextField = "security_name"
                cmbsecuritytype.DataBind()
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
        'Dim shares As Double = txtBatchShares.Text
        'Dim shareprice As Decimal = txtShareprice.Text
        'Dim value As Double = shares * shareprice
        'txtBatchValue.Text = value

        cmd = New SqlCommand("insert into batch_receipt (id,company, batch_shares, shareprice, batch_value, batch_date, lodger, balanced, verified, successful, batch_type, masttemp,broker_code, security_type) values ('0','" + cmbparaCompany.Text + "','" + txtBatchShares.Text + "','0','0',Getdate(),'" + txtClientNo2.Text + "','0','0','0','Immobilization','0','" + Session("brokercode") + "','" + cmbsecuritytype.Text + "')", cn)
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
        Panel9.Enabled = True


        msgbox("Batch Number:" + txtClientNo.Text + " has been successfully created. Please add some Shares and Share Certificates to the batch")


    End Sub

    Protected Sub ASPxButton10_Click(sender As Object, e As EventArgs) Handles ASPxButton10.Click
        Dim ds As New DataSet
        cmd = New SqlCommand("select cds_number+' '+surname+' '+middlename+' '+forenames as names, cds_number from accounts_clients where cds_number like '%" + txtclientnumber.Text + "%' and brokercode='" + Session("brokercode") + "'", cn)
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
        'Dim ds1 As New DataSet
        'cmd = New SqlCommand("select  b.cds_number  from batch_certs b where batch_no='" + txtClientNo.Text + "' and b.cds_number='" + ListBox1.SelectedValue.ToString + "'", cn)
        'adp = New SqlDataAdapter(cmd)
        'adp.Fill(ds1, "gridcerts2")
        'If (ds1.Tables("gridcerts2").Rows.Count > 0) Then
        '    msgbox("Cannot duplicate CDS number in the same batch!")
        'Else
        Try
            cmd = New SqlCommand("insert into batch_certs values ('" + txtClientNo.Text + "','" + ListBox1.SelectedValue.ToString + "','" + txtshares.Text + "','" + txtcertno.Text + "')", cn)
            If (cn.State = ConnectionState.Open) Then
                cn.Close()
            End If
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()

            Dim ds As New DataSet
            cmd = New SqlCommand("select b.id,a.surname+' '+a.middlename+' '+a.forenames as name, b.cds_number, b.batch_no, b.certificate_no, b.shares  from accounts_clients a, batch_certs b where b.cds_number=a.CDS_Number and batch_no='" + txtClientNo.Text + "'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "gridcerts")
            If (ds.Tables(0).Rows.Count > 0) Then
                grdTranShareholder.DataSource = ds
                grdTranShareholder.DataBind()
            End If
            txtcertno.Text = ""
            txtshares.Text = ""
            ListBox1.Items.Clear()
        Catch ex As Exception

        End Try
     

        ' End If




    End Sub

    Protected Sub ASPxButton13_Click(sender As Object, e As EventArgs) Handles ASPxButton13.Click
        Dim ds As New DataSet
        cmd = New SqlCommand("select (select sum(shares) from batch_certs where batch_no=" + txtClientNo.Text + ") as certs_total, (select batch_shares from Batch_receipt where batch_no=" + txtClientNo.Text + ") as batch_tot", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "totals")
        If (ds.Tables(0).Rows.Count > 0) Then
            If ds.Tables(0).Rows(0).Item("certs_total") = ds.Tables(0).Rows(0).Item("batch_tot") Then
                cmd = New SqlCommand("update batch_receipt set balanced='1' where batch_no='" + txtClientNo.Text + "'", cn)
                If (cn.State = ConnectionState.Open) Then
                    cn.Close()
                End If
                cn.Open()
                cmd.ExecuteNonQuery()
                cn.Close()
                Session("finish") = "yes"
                Response.Redirect(Request.RawUrl)
            Else
                msgbox("Specified batch total not balancing with the total shares you added!")
            End If
        End If
    End Sub
End Class
