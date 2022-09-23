Imports System.Data
Imports System.Data.SqlClient
Partial Class Trading_BatchReceiptNewver
    Inherits System.Web.UI.Page
    Dim constr As String = (System.Configuration.ConfigurationManager.AppSettings("connpath"))
    Dim omu As String = (System.Configuration.ConfigurationManager.AppSettings("omzildb"))
    Dim cn As New SqlConnection(constr)
    Dim cmd As SqlCommand
    Dim adp As SqlDataAdapter
    Dim x As Integer = 0
    Dim j As Integer = 1
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Page.MaintainScrollPositionOnPostBack = True
        If (Not IsPostBack) Then
            getCompany()
            GetBatchTypes()
            GetBatchRef()
            If (rdBatchDetails.Checked = True) Then
                x = 0
            Else
                x = 1
            End If
            PrimaryHolderDetails()
            SecondaryHolder()
        End If
    End Sub
    Public Sub msgbox(ByVal strMessage As String)
        'finishes server processing, returns to client.
        Dim strScript As String = "<script language=JavaScript>"
        strScript += "window.alert(""" & strMessage & """);"
        strScript += "</script>"
        Dim lbl As New System.Web.UI.WebControls.Label
        lbl.Text = strScript
        Page.Controls.Add(lbl)
    End Sub
    Public Sub PrimaryHolderDetails()
        Try
            If (x = 0) Then
                Label20.Visible = True
                txtNameSearch.Visible = True
                Button3.Visible = True
                Label21.Visible = True
                lstNameSearch.Visible = True
                lblShareholder.Visible = True
                lblHoldingBalance.Visible = True
                lblBalance.Visible = True
                Certificates.Visible = True
                grdHolderCertificates.Visible = True
                Label23.Visible = True
                txtSharesToBatch.Visible = True
                btnBatchSharesSave.Visible = True
            End If
            If (x = 1) Then
                Label20.Visible = False
                txtNameSearch.Visible = False
                Button3.Visible = False
                Label21.Visible = False
                lstNameSearch.Visible = False
                lblShareholder.Visible = False
                lblHoldingBalance.Visible = False
                lblBalance.Visible = False
                Certificates.Visible = False
                grdHolderCertificates.Visible = False
                Label23.Visible = False
                txtSharesToBatch.Visible = False
                btnBatchSharesSave.Visible = False
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub SecondaryHolder()
        Try

            If (j = 0) Then
                LabelTransferee.Visible = True
                txtTransfereeSearch.Visible = True
                btnTransferee.Visible = True
                LabelTransferree.Visible = True
                Sahres.Visible = True
                lstTransfereeSearch.Visible = True
                txtTransfereeShares.Visible = True
                Label24.Visible = True
                lblTransfers.Visible = True
                grdTransfers.Visible = True
                Button4.Visible = True
                btnTransfereeSave.Visible = True
            End If
            If (j = 1) Then
                LabelTransferee.Visible = False
                txtTransfereeSearch.Visible = False
                btnTransferee.Visible = False
                LabelTransferree.Visible = False
                Sahres.Visible = False
                lstTransfereeSearch.Visible = False
                txtTransfereeShares.Visible = False
                Label24.Visible = False
                lblTransfers.Visible = False
                grdTransfers.Visible = False
                Button4.Visible = False
                btnTransfereeSave.Visible = False
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Protected Sub rdBatchDetails_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdBatchDetails.CheckedChanged
        Try
            If (rdBatchDetails.Checked = True) Then
                x = 0
            Else
                x = 1
            End If
            PrimaryHolderDetails()
            If (CmbBatchType.SelectedItem.Text = "XFER") Then
                j = 0
            End If
            SecondaryHolder()
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Protected Sub rdForwardBatch_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdForwardBatch.CheckedChanged
        If (rdForwardBatch.Checked = True) Then
            x = 1
        Else
            x = 0
        End If
        PrimaryHolderDetails()
        If (CmbBatchType.Text = "XFER") Then
            j = 1
        End If
        SecondaryHolder()
    End Sub
    Protected Sub CmbBatchType_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbBatchType.SelectedIndexChanged
        Try
            If (CmbBatchType.Text = "XFER") Then

                j = 0
                SecondaryHolder()
            Else
                j = 1
                SecondaryHolder()

            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub getCompany()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("Select company from para_company", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "para_company")
            cmbParaCompany.DataSource = ds.Tables(0)
            cmbParaCompany.DataValueField = "company"
            cmbParaCompany.DataBind()
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    
    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Try
            If (rdBatchDetails.Checked = False And rdForwardBatch.Checked = False) Then
                msgbox("Select Batching Option")
                Exit Sub
            End If
            If (BasicDatePicker1.SelectedDate < Now.Date) Then
                msgbox("You can not back date a batch")
                Exit Sub
            End If
            Dim BatchOption As Integer = 0
            If (rdBatchDetails.Checked = True) Then
                BatchOption = 0
            End If
            If (rdForwardBatch.Checked = True) Then
                BatchOption = 1
            End If
            If (txtBatchShares.Text = "") Then
                msgbox("Enter total batch shares")
                Exit Sub
            End If

            Dim ds As New DataSet
            cmd = New SqlCommand("select max(batch_ref) as batch_ref from Broker_Batch_Header", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "Broker_Batch_Header")
            Dim Batchref As Integer = ds.Tables(0).Rows(0).Item("batch_ref").ToString

            'cmd = New SqlCommand("insert into Broker_Batch_Header (batch_ref,Company,Batch_Type,Shares,Lodger,Created_By,Created_On,Status,batchingOption)values(" & CInt(ds.Tables(0).Rows(0).Item("Batch_ref").ToString) + 1 & ",'" & cmbParaCompany.Text & "','" & CmbBatchType.Text & "'," & txtBatchShares.Text & ",'" & Session("Username").ToString & "','" & Session("Username").ToString & "','" & Now.Date & "','O'," & BatchOption & ")", cn)
            cmd = New SqlCommand("insert into Broker_Batch_Header (batch_ref,Company,Batch_Type,Shares,Lodger,Created_By,Created_On,Status,batchingOption)values(" & lblBatchRef.Text & ",'" & cmbParaCompany.Text & "','" & CmbBatchType.Text & "'," & txtBatchShares.Text & ",'" & Session("Username").ToString & "','" & Session("Username").ToString & "','" & Now.Date & "','O'," & BatchOption & ")", cn)
            If (cn.State = ConnectionState.Open) Then
                cn.Close()
            End If
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()

            cmd = New SqlCommand("insert into UserActivityLog (UserName,Activity,TimeOfActivity,DateDone,CompanyCode) values ('" & Session("Username") & "','Created batch header " & lblBatchRef.Text & " for " & cmbParaCompany.SelectedItem.Text & "','" & Date.Now & "','" & Now.Date & "','" & Session("BrokerCode") & "')", cn)
            If (cn.State = ConnectionState.Open) Then
                cn.Close()
            End If
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()

            If (BatchOption = 1) Then
                msgbox("Batch saved")
                txtBatchShares.Text = ""
                rdBatchDetails.Checked = False
                rdForwardBatch.Checked = False
                GetBatchRef()
            Else
                msgbox("Batch saved, proceed to enter batch details")
                Dim dsi As New DataSet
                cmd = New SqlCommand("select max(batch_ref) as batch_ref from Broker_Batch_Header group by batch_ref order by batch_ref desc", cn)
                adp = New SqlDataAdapter(cmd)
                adp.Fill(dsi, "batch_ref")
                If (dsi.Tables(0).Rows.Count > 0) Then
                    lblBatchRef.Text = dsi.Tables(0).Rows(0).Item("batch_ref").ToString
                End If
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub GetBatchRef()
        Try

            Dim ds As New DataSet
            cmd = New SqlCommand("select max(Batch_ref) as Batch_ref from Broker_Batch_Header group by batch_ref order by batch_ref desc", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "batch_header")

            If (ds.Tables(0).Rows.Count > 0) Then
                lblBatchRef.Text = CInt(ds.Tables(0).Rows(0).Item("batch_ref").ToString) + 2
            Else
                lblBatchRef.Text = "2"
            End If
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
                CmbBatchType.DataValueField = "batch_Type"
                CmbBatchType.DataBind()
            End If

        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub getBatchedShares()
        Try

            Dim ds As New DataSet
            cmd = New SqlCommand("select Company, Shares, EmployeeNo, Certificate,TransactionID from Batch_Cert where company='" & cmbParaCompany.SelectedItem.Text & "' and batch_ref=" & lblBatchRef.Text & "", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "Batch_Cert")
            If (ds.Tables(0).Rows.Count > 0) Then

                grdBatched.Visible = True
                grdBatched.DataSource = ds.Tables(0)
                grdBatched.DataBind()
            Else
                msgbox("Test")
                grdBatched.DataSource = Nothing
                grdBatched.DataBind()
            End If

        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub getRebatchedshares()
        Try

            Dim ds As New DataSet
            cmd = New SqlCommand("select Company, Shares, EmployeeNo,TransID from TransactionBatches where company='" & cmbParaCompany.SelectedItem.Text & "' and batch_ref=" & lblBatchRef.Text & "", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "TransactionBatches")
            If (ds.Tables(0).Rows.Count > 0) Then

                grdTransfers.Visible = True
                grdTransfers.DataSource = ds.Tables(0)
                grdTransfers.DataBind()
            Else
                grdTransfers.DataSource = Nothing
                grdTransfers.DataBind()
            End If

        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Protected Sub BtnBatchSearch_Click(sender As Object, e As EventArgs) Handles BtnBatchSearch.Click
        Try
            If (txtBatchSearch.Text = "") Then
            Else
                Dim ds As New DataSet
                cmd = New SqlCommand("select * from batch_header where batch_ref=" & txtBatchSearch.Text & "", cn)
                adp = New SqlDataAdapter(cmd)
                adp.Fill(ds, "batch_header")
                If (ds.Tables(0).Rows.Count > 0) Then
                    lblBatchRef.Text = ds.Tables(0).Rows(0).Item("batch_ref").ToString
                    txtBatchShares.Text = ds.Tables(0).Rows(0).Item("shares").ToString
                    cmbParaCompany.SelectedItem.Text = ds.Tables(0).Rows(0).Item("company").ToString
                    CmbBatchType.SelectedItem.Text = ds.Tables(0).Rows(0).Item("Batch_Type").ToString
                    BasicDatePicker1.SelectedDate = ds.Tables(0).Rows(0).Item("Batch_date").ToString
                    If (ds.Tables(0).Rows(0).Item("Batching_Option").ToString = 0) Then
                        rdBatchDetails.Checked = True
                    Else
                        rdForwardBatch.Checked = True
                    End If
                    If (rdBatchDetails.Checked = True) Then
                        x = 0
                    Else
                        x = 1
                    End If
                    PrimaryHolderDetails()
                    If (CmbBatchType.SelectedItem.Text = "XFER") Then
                        j = 0
                    End If
                    SecondaryHolder()
                    If (rdForwardBatch.Checked = True) Then
                        x = 1
                    Else
                        x = 0
                    End If
                    PrimaryHolderDetails()
                    If (CmbBatchType.SelectedItem.Text = "XFER") Then
                        j = 1
                    End If
                    SecondaryHolder()
                End If
                getBatchedShares()
                getRebatchedshares()
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Try
            If (CmbBatchType.SelectedItem.Text <> "XFER") Then
                Dim ds As New DataSet
                If (txtNameSearch.Text = "") Then
                    Exit Sub
                End If
                cmd = New SqlCommand("select surname+' '+forenames+ ' '+CDS_Number as Holder, CDS_Number from names where Surname like '" & txtNameSearch.Text & "%'", cn)
                adp = New SqlDataAdapter(cmd)
                adp.Fill(ds, "names")
                If (ds.Tables(0).Rows.Count > 0) Then
                    lstNameSearch.DataSource = ds.Tables(0)
                    lstNameSearch.DataValueField = "Holder"
                    lstNameSearch.DataBind()
                Else
                    lstNameSearch.Items.Clear()
                End If
            Else
                Dim ds As New DataSet
                If (txtNameSearch.Text = "") Then
                    Exit Sub
                End If
                cmd = New SqlCommand("select surname+' '+forenames+ ' '+CDS_Number as Holder, CDS_Number from names where Surname like '" & txtNameSearch.Text & "%' and company='" & cmbParaCompany.Text & "'", cn)
                adp = New SqlDataAdapter(cmd)
                adp.Fill(ds, "names")
                If (ds.Tables(0).Rows.Count > 0) Then
                    lstNameSearch.DataSource = ds.Tables(0)
                    lstNameSearch.DataValueField = "Holder"
                    lstNameSearch.DataBind()
                Else
                    lstNameSearch.Items.Clear()
                End If
            End If
            
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub lstNameSearch_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstNameSearch.SelectedIndexChanged
        getSelectedHolderBal()
    End Sub
    Public Sub getSelectedHolderBal()
        Try
            If (CmbBatchType.SelectedItem.Text <> "XFER") Then
                Dim ds As New DataSet
                cmd = New SqlCommand("select cds_number from names where surname+' '+forenames+ ' '+CDS_Number = '" & lstNameSearch.SelectedItem.Text & "'", cn)
                adp = New SqlDataAdapter(cmd)
                adp.Fill(ds, "names")
                If (ds.Tables(0).Rows.Count > 0) Then
                    'lblBalance.Text = FormatNumber(CInt(ds.Tables(0).Rows(0).Item("shares").ToString), 0)
                    lblShareholder.Text = ds.Tables(0).Rows(0).Item("CDS_Number").ToString
                    'Dim dsi As New DataSet
                    'cmd = New SqlCommand("select certificateNo as [Certificate], take_on_shares as Shares from mainRegister where surname+' '+firstName+ ' '+EmployeeNo+' '+OriginateReg = '" & lstNameSearch.SelectedItem.Text & "' and CertificateNo >  0 and BatchStatus = 0", cn)
                    'adp = New SqlDataAdapter(cmd)
                    'adp.Fill(dsi, "mainregister")

                    'If (dsi.Tables(0).Rows.Count > 0) Then
                    'grdHolderCertificates.DataSource = dsi.Tables(0)
                    'grdHolderCertificates.DataBind()
                    'Else
                    'grdHolderCertificates.DataSource = Nothing
                    'grdHolderCertificates.DataBind()
                    'End If
                Else
                    lblBalance.Text = "0"
                    lblShareholder.Text = ""
                End If
            Else
                Dim ds As New DataSet
                cmd = New SqlCommand("select sum(Take_on_shares) as shares,EmployeeNo from mainRegister where surname+' '+firstName+ ' '+EmployeeNo+' '+OriginateReg = '" & lstNameSearch.SelectedItem.Text & "' group  by EmployeeNo", cn)
                adp = New SqlDataAdapter(cmd)
                adp.Fill(ds, "mainRegister")
                If (ds.Tables(0).Rows.Count > 0) Then
                    lblBalance.Text = FormatNumber(CInt(ds.Tables(0).Rows(0).Item("shares").ToString), 0)
                    lblShareholder.Text = ds.Tables(0).Rows(0).Item("EmployeeNo").ToString
                    Dim dsi As New DataSet
                    cmd = New SqlCommand("select certificateNo as [Certificate], take_on_shares as Shares from mainRegister where surname+' '+firstName+ ' '+EmployeeNo+' '+OriginateReg = '" & lstNameSearch.SelectedItem.Text & "' and CertificateNo >  0 and BatchStatus = 0", cn)
                    adp = New SqlDataAdapter(cmd)
                    adp.Fill(dsi, "mainregister")

                    If (dsi.Tables(0).Rows.Count > 0) Then
                        grdHolderCertificates.DataSource = dsi.Tables(0)
                        grdHolderCertificates.DataBind()
                    Else
                        grdHolderCertificates.DataSource = Nothing
                        grdHolderCertificates.DataBind()
                    End If
                Else
                    lblBalance.Text = "0"
                    lblShareholder.Text = ""
                End If
            End If

        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Protected Sub btnBatchSharesSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBatchSharesSave.Click
        Try
            If (txtSharesToBatch.Text = "") Then
                Exit Sub
            End If
            Dim ds1 As New DataSet
            cmd = New SqlCommand("select * from batch_cert where batch_ref=" & lblBatchRef.Text & " and company='" & cmbParaCompany.Text & "'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds1, "batch_cert")
            If (ds1.Tables(0).Rows.Count > 0) Then

                Dim shareCounter As Integer = 0
                Dim dsi As New DataSet
                cmd = New SqlCommand("select sum(Shares) as shares from batch_cert where batch_ref=" & lblBatchRef.Text & " and company='" & cmbParaCompany.Text & "'", cn)
                adp = New SqlDataAdapter(cmd)
                adp.Fill(dsi, "batch_cert")
                'msgbox(CInt(CInt(dsi.Tables(0).Rows(0).Item("shares").ToString) + CInt(txtSharesToBatch.Text)) & " " & CInt(txtBatchShares.Text))
                If (CInt(CInt(dsi.Tables(0).Rows(0).Item("shares").ToString) + CInt(txtSharesToBatch.Text)) > CInt(txtBatchShares.Text)) Then
                    msgbox("Batched shares will exceed batch total")
                    getBatchedShares()
                    Exit Sub
                End If

                If (CInt(CInt(dsi.Tables(0).Rows(0).Item("shares").ToString) + CInt(txtSharesToBatch.Text)) < CInt(txtBatchShares.Text)) Then

                    Dim ds As New DataSet
                    cmd = New SqlCommand("insert into Batch_Cert (Batch_ref, Company, Shares, Certificate, EmployeeNo, Status,Verification) values (" & lblBatchRef.Text & ",'" & cmbParaCompany.Text & "'," & CInt(txtSharesToBatch.Text) & ",0,'" & lblShareholder.Text & "','O',0)", cn)
                    If (cn.State = ConnectionState.Open) Then
                        cn.Close()
                    End If
                    cn.Open()
                    cmd.ExecuteNonQuery()
                    cn.Close()
                    msgbox("Record Saved")
                    txtNameSearch.Text = ""
                    lstNameSearch.Items.Clear()
                    getBatchedShares()
                End If

                If (CInt(CInt(dsi.Tables(0).Rows(0).Item("shares").ToString) + CInt(txtSharesToBatch.Text)) = CInt(txtBatchShares.Text)) Then
                    Dim ds As New DataSet
                    cmd = New SqlCommand("insert into Batch_Cert (Batch_ref, Company, Shares, Certificate, EmployeeNo, Status,Verification) values (" & lblBatchRef.Text & ",'" & cmbParaCompany.Text & "'," & CInt(txtSharesToBatch.Text) & ",0,'" & lblShareholder.Text & "','O',0)", cn)
                    If (cn.State = ConnectionState.Open) Then
                        cn.Close()
                    End If
                    cn.Open()
                    cmd.ExecuteNonQuery()
                    cn.Close()

                    cmd = New SqlCommand("update batch_header set Batch_Status='B' where company='" & cmbParaCompany.Text & "' and batch_ref=" & lblBatchRef.Text & "", cn)
                    If (cn.State = ConnectionState.Open) Then
                        cn.Close()
                    End If
                    cn.Open()
                    cmd.ExecuteNonQuery()
                    cn.Close()

                    msgbox("Record Saved and Batch Balanced")
                    txtNameSearch.Text = ""
                    lstNameSearch.Items.Clear()
                    getBatchedShares()
                End If
            Else
                If (CInt(txtSharesToBatch.Text) > CInt(txtBatchShares.Text)) Then
                    msgbox("Batched shares will exceed batch total")
                    Exit Sub
                End If

                If (CInt(txtSharesToBatch.Text) < CInt(txtBatchShares.Text)) Then
                    Dim ds As New DataSet
                    'msgbox("insert into Batch_Cert (Batch_ref, Company, Shares, Certificate, EmployeeNo, Status,Verification) values (" & lblBatchRef.Text & ",'" & cmbParaCompany.Text & "'," & CInt(txtSharesToBatch.Text) & ",0,'" & lblShareholder.Text & "','O',0,)")
                    cmd = New SqlCommand("insert into Batch_Cert (Batch_ref, Company, Shares, Certificate, EmployeeNo, Status,Verification) values (" & lblBatchRef.Text & ",'" & cmbParaCompany.Text & "'," & CInt(txtSharesToBatch.Text) & ",0,'" & lblShareholder.Text & "','O',0)", cn)
                    If (cn.State = ConnectionState.Open) Then
                        cn.Close()
                    End If
                    cn.Open()
                    cmd.ExecuteNonQuery()
                    cn.Close()
                    msgbox("Record Saved")
                    txtNameSearch.Text = ""
                    lstNameSearch.Items.Clear()
                    getBatchedShares()
                End If

                If (CInt(txtSharesToBatch.Text) = CInt(txtBatchShares.Text)) Then
                    Dim ds As New DataSet
                    cmd = New SqlCommand("insert into Batch_Cert (Batch_ref, Company, Shares, Certificate, EmployeeNo, Status,Verification) values (" & lblBatchRef.Text & ",'" & cmbParaCompany.Text & "'," & CInt(txtSharesToBatch.Text) & ",0,'" & lblShareholder.Text & "','O',0)", cn)
                    If (cn.State = ConnectionState.Open) Then
                        cn.Close()
                    End If
                    cn.Open()
                    cmd.ExecuteNonQuery()
                    cn.Close()

                    cmd = New SqlCommand("update batch_header set Batch_Status='B' where company='" & cmbParaCompany.Text & "' and batch_ref=" & lblBatchRef.Text & "", cn)
                    If (cn.State = ConnectionState.Open) Then
                        cn.Close()
                    End If
                    cn.Open()
                    cmd.ExecuteNonQuery()
                    cn.Close()

                    msgbox("Record Saved and Batch Balanced")
                    txtNameSearch.Text = ""
                    lstNameSearch.Items.Clear()
                    getBatchedShares()
                End If

            End If
            lblBalance.Text = ""
            lblShareholder.Text = ""
            txtSharesToBatch.Text = ""
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Protected Sub BtnDataImport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnDataImport.Click
        Try
            Dim ds As New DataSet
            'Checking the shareholders in the accounts_main 
            cmd = New SqlCommand("select * from para_company")
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
End Class
