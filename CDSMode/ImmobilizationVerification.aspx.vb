Imports System.Data
Imports System.Data.SqlClient
Partial Class CDSMode_ImmobilizationVerification
    Inherits System.Web.UI.Page
    Dim constr As String = (System.Configuration.ConfigurationManager.AppSettings("connpath"))
    Dim cn As New SqlConnection(constr)
    Dim cmd As SqlCommand
    Dim adp As SqlDataAdapter
    Dim maxbatchref As Integer
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Page.MaintainScrollPositionOnPostBack = True
        If (Not IsPostBack) Then
            getCompany()
        End If
    End Sub
    Public Sub getmaxBatchref()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("Select max(batch_ref) as batch_ref from broker_batch_header", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "broker_batch_header")
            maxbatchref = ((ds.Tables(0).Rows(0).Item("batch_ref").ToString) + 1)
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub getCompany()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("Select batch_ref from broker_batch_header where status='F' and batch_type='IMMOB' order by batch_ref", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "broker_Batch_Header")
            If (ds.Tables(0).Rows.Count > 0) Then
                cmbBatch.DataSource = ds.Tables(0)
                cmbBatch.DataValueField = "batch_ref"
                cmbBatch.DataBind()
                txtSearch.Text = cmbBatch.SelectedValue
                getBatch()
            Else
                txtSearch.Text = ""
                cmbBatch.DataSource = Nothing
                cmbBatch.DataBind()
            End If

        Catch ex As Exception
            msgbox(ex.Message)
        End Try
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
    Protected Sub btnBatchSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBatchSearch.Click
        Try
            If (txtSearch.Text = "") Then
                msgbox("Enter a batch Reference Number")
                Exit Sub
            End If
            getBatch()
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub getBatch()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("Select * from broker_batch_header where batch_ref=" & txtSearch.Text & " and status='F' and batch_type='IMMOB'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "Broker_batch_header")
            If (ds.Tables(0).Rows.Count > 0) Then
                LblBatchDate.Text = ds.Tables(0).Rows(0).Item("Created_On").ToString
                lblBatchTotal.Text = ds.Tables(0).Rows(0).Item("Shares").ToString
                lblbatchref.Text = ds.Tables(0).Rows(0).Item("Batch_ref").ToString
                lblBatchBy.Text = ds.Tables(0).Rows(0).Item("Created_By").ToString
                lblBrokercode.Text = ds.Tables(0).Rows(0).Item("lodger").ToString
                Dim ds1 As New DataSet
                cmd = New SqlCommand("Select Company as [Company],Batch_Type as [Batch Type],Shareholder as [Old Holder Number],Shares,Certificate,CD,CDS_Number as [CDS Number],HolderNames from broker_Batch_Ref where batch_ref=" & lblbatchref.Text & " AND status='F' and batch_type='IMMOB'", cn)
                adp = New SqlDataAdapter(cmd)
                adp.Fill(ds1, "broker_batch_ref")
                If (ds1.Tables(0).Rows.Count > 0) Then
                    grdAddedCertificate.DataSource = ds1.Tables(0)
                    grdAddedCertificate.DataBind()
                Else
                    grdAddedCertificate.DataSource = Nothing
                    grdAddedCertificate.DataBind()
                End If
            Else
                msgbox("Batch invalid")
                LblBatchDate.Text = ""
                lblBatchTotal.Text = ""
                lblbatchref.Text = ""
                lblBatchBy.Text = ""
                grdAddedCertificate.DataSource = Nothing
                grdAddedCertificate.DataBind()
                Exit Sub
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub displaydata()
        Try
            Dim ds1 As New DataSet
            cmd = New SqlCommand("Select Batch_ref,Company,Batch_Type,Shareholder as [Old Holder Number],Shares,Certificate,CD,CDS_Number from broker_Batch_Ref where batch_ref=" & lblbatchref.Text & "", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds1, "broker_batch_ref")
            If (ds1.Tables(0).Rows.Count > 0) Then
                grdAddedCertificate.DataSource = ds1.Tables(0)
                grdAddedCertificate.DataBind()
            Else
                grdAddedCertificate.DataSource = Nothing
                grdAddedCertificate.DataBind()
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub cmbBatch_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbBatch.SelectedIndexChanged
        Try
            txtSearch.Text = cmbBatch.SelectedValue
            getBatch()
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub UpdateForwardingBatch()
        Try
            cmd = New SqlCommand("Update broker_batch_header set status='V' where batch_ref=" & lblbatchref.Text & "", cn)
            If (cn.State = ConnectionState.Open) Then
                cn.Close()
            End If
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()

            cmd = New SqlCommand("Update broker_batch_ref set status='V' where batch_ref=" & lblbatchref.Text & "", cn)
            If (cn.State = ConnectionState.Open) Then
                cn.Close()
            End If
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()

            SaveTSecBatch()
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub SaveTSecBatch()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select company,batch_ref,batch_type,Created_on,shares,Lodger,status from broker_batch_header where batch_ref=" & lblbatchref.Text & "", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "broker_batch_header")
            If (ds.Tables(0).Rows.Count > 0) Then
                'msgbox("Begin Saving TSec Batch Header")
                Dim j As Integer = 0

                j = grdAddedCertificate.Rows.Count - 1
                For j = 0 To grdAddedCertificate.Rows.Count - 1

                    cmd = New SqlCommand("Insert into mast (company, cds_number, date_created, shares, update_type, pladge, pledge_shares, created_by, updated_on, updated_by, locked, Lock_Reason, Batch_Ref) values ('" & grdAddedCertificate.Rows(j).Cells(1).Text & "','" & grdAddedCertificate.Rows(j).Cells(7).Text & "','" & Date.Now & "'," & grdAddedCertificate.Rows(j).Cells(4).Text & ",'" & grdAddedCertificate.Rows(j).Cells(2).Text & "',0,0,'" & Session("Username") & "','" & Date.Now & "','" & Session("Username") & "',0,'XXXXXX'," & lblbatchref.Text & ")", cn)
                    'cmd = New SqlCommand("insert into TSec_Batch_Header (Company,batch_ref,batch_type,batch_date,batch_total,batch_Broker,Batch_Forwarded_By,Batch_Forwarded_On,Status) values ('" & ds.Tables(0).Rows(0).Item("company").ToString & "'," & ds.Tables(0).Rows(0).Item("batch_ref").ToString & ",'" & ds.Tables(0).Rows(0).Item("Batch_type").ToString & "','" & ds.Tables(0).Rows(0).Item("Created_On").ToString & "'," & ds.Tables(0).Rows(0).Item("shares").ToString & ",'" & ds.Tables(0).Rows(0).Item("LODGER").ToString & "','" & Session("BrokerCode") & "','" & Now.Date & "','F')", cn)
                    If (cn.State = ConnectionState.Open) Then
                        cn.Close()
                    End If
                    cn.Open()
                    cmd.ExecuteNonQuery()
                    cn.Close()

                Next

                Dim i As Integer = 0

                i = grdAddedCertificate.Rows.Count - 1
                For i = 0 To grdAddedCertificate.Rows.Count - 1
                    cmd = New SqlCommand("Insert into trans (company, cds_number, date_created, trans_time, shares, update_type,Created_By,Batch_Ref,Source,Pledge_Shares) values ('" & grdAddedCertificate.Rows(i).Cells(1).Text & "','" & grdAddedCertificate.Rows(i).Cells(7).Text & "','" & Date.Now & "','" & Now.TimeOfDay.ToString & "'," & grdAddedCertificate.Rows(i).Cells(4).Text & ",'" & grdAddedCertificate.Rows(i).Cells(2).Text & "','" & Session("username") & "'," & lblbatchref.Text & ",'C',0)", cn)
                    'cmd = New SqlCommand("insert into TSec_Batch_Header (Company,batch_ref,batch_type,batch_date,batch_total,batch_Broker,Batch_Forwarded_By,Batch_Forwarded_On,Status) values ('" & ds.Tables(0).Rows(0).Item("company").ToString & "'," & ds.Tables(0).Rows(0).Item("batch_ref").ToString & ",'" & ds.Tables(0).Rows(0).Item("Batch_type").ToString & "','" & ds.Tables(0).Rows(0).Item("Created_On").ToString & "'," & ds.Tables(0).Rows(0).Item("shares").ToString & ",'" & ds.Tables(0).Rows(0).Item("LODGER").ToString & "','" & Session("BrokerCode") & "','" & Now.Date & "','F')", cn)
                    If (cn.State = ConnectionState.Open) Then
                        cn.Close()
                    End If
                    cn.Open()
                    cmd.ExecuteNonQuery()
                    cn.Close()
                Next
                'TSecBatchDetail()
                msgbox("Record Saved")
                getCompany()
            Else
                msgbox("Nothing To Save in TSec Batch Header")
            End If

        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub TSecBatchDetail()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("Select company,CDS_Number,Shareholder,HolderNames,Batch_Type,Batch_Ref,Certificate,CD,Shares from broker_Batch_Ref where batch_ref=" & lblbatchref.Text & "", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "broker_batch_ref")
            If (ds.Tables(0).Rows.Count > 0) Then
                Dim i As Integer
                For i = 0 To ds.Tables(0).Rows.Count - 1
                    cmd = New SqlCommand("insert into TSec_Batch_Ref (company,CDS_Number,Shareholder,HolderNames,Batch_Type,Batch_Ref,Certificate,CD,Shares,Forwarded_On,Forwarded_By,Status) values ('" & ds.Tables(0).Rows(i).Item("company").ToString & "','" & ds.Tables(0).Rows(i).Item("CDS_Number").ToString & "'," & ds.Tables(0).Rows(i).Item("Shareholder").ToString & ",'" & ds.Tables(0).Rows(i).Item("HolderNames").ToString & "','" & ds.Tables(0).Rows(i).Item("Batch_Type").ToString & "'," & ds.Tables(0).Rows(i).Item("Batch_Ref").ToString & "," & ds.Tables(0).Rows(i).Item("Certificate").ToString & "," & ds.Tables(0).Rows(i).Item("CD").ToString & "," & ds.Tables(0).Rows(i).Item("Shares").ToString & ",'" & Now.Date & "','" & Session("BrokerCode") & "','F')", cn)
                    If (cn.State = ConnectionState.Open) Then
                        cn.Close()
                    End If
                    cn.Open()
                    cmd.ExecuteNonQuery()
                    cn.Close()
                Next
                LblBatchDate.Text = ""
                lblBatchTotal.Text = ""
                lblbatchref.Text = ""
                lblBatchBy.Text = ""
                grdAddedCertificate.DataSource = Nothing
                grdAddedCertificate.DataBind()
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Protected Sub btnForward_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnForward.Click
        Try
            UpdateForwardingBatch()
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub UpdateDecliningBatch()
        Try
            cmd = New SqlCommand("Update broker_batch_header set status='X' where batch_ref=" & lblbatchref.Text & "", cn)
            If (cn.State = ConnectionState.Open) Then
                cn.Close()
            End If
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()

            cmd = New SqlCommand("Update broker_batch_ref set status='X' where batch_ref=" & lblbatchref.Text & "", cn)
            If (cn.State = ConnectionState.Open) Then
                cn.Close()
            End If
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()
            getCompany()
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Protected Sub btnDecline_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDecline.Click
        Try
            UpdateDecliningBatch()
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
End Class
