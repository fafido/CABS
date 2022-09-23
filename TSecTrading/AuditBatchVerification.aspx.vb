Imports System.Data
Imports System.Data.SqlClient
Partial Class TSecTrading_AuditBatchVerification
    Inherits System.Web.UI.Page
    Dim constr As String = (System.Configuration.ConfigurationManager.AppSettings("connpath"))
    Dim cn As New SqlConnection(constr)
    Dim cmd As SqlCommand
    Dim adp As SqlDataAdapter
    Dim maxbatchref As Integer
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
            If (Session("Username") = Nothing) Then
                Response.Redirect("~\loginsystem.aspx")
            End If
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
            cmd = New SqlCommand("Select batch_ref from TSec_batch_header where status='V' and batch_type in ('IMMOB','KUUMBA')order by batch_ref", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "TSec_Batch_Header")
            If (ds.Tables(0).Rows.Count > 0) Then
                cmbBatch.DataSource = ds.Tables(0)
                cmbBatch.DataValueField = "batch_ref"
                cmbBatch.DataBind()
                txtSearch.Text = cmbBatch.SelectedValue
                getBatch()
            End If

        Catch ex As Exception
            msgbox(ex.Message)
        End Try
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
            cmd = New SqlCommand("Select * from TSec_batch_header where batch_ref=" & txtSearch.Text & " and status='V'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "TSec_batch_header")
            If (ds.Tables(0).Rows.Count > 0) Then
                LblBatchDate.Text = FormatDateTime(ds.Tables(0).Rows(0).Item("Batch_Date").ToString, DateFormat.LongDate)
                lblBatchTotal.Text = FormatNumber(ds.Tables(0).Rows(0).Item("Batch_Total").ToString, 0)
                lblbatchref.Text = ds.Tables(0).Rows(0).Item("Batch_ref").ToString
                lblBatchBy.Text = ds.Tables(0).Rows(0).Item("Batch_Broker").ToString
                Dim ds1 As New DataSet
                cmd = New SqlCommand("Select company as Company,CDS_Number as [CDS Account],HolderNames as [Holder],Batch_Type as [Batch Type],Batch_Ref as [Batch Ref],Certificate,cast (Shares as int) as Shares,convert(varchar (20),Forwarded_On,106) as [Forward Date],Forwarded_By from TSec_Batch_Ref where batch_ref=" & lblbatchref.Text & " AND status='V'", cn)
                adp = New SqlDataAdapter(cmd)
                adp.Fill(ds1, "TSec_batch_ref")
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
    Public Sub UpdateDeclinedBatch()
        Try
            cmd = New SqlCommand("Update TSec_batch_header set status='Z',Accepted_By='USER',Accepted_On='" & Date.Now & "' where batch_ref=" & lblbatchref.Text & " and status='F'", cn)
            If (cn.State = ConnectionState.Open) Then
                cn.Close()
            End If
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()

            cmd = New SqlCommand("Update TSec_batch_ref set status='Z' where batch_ref=" & lblbatchref.Text & "", cn)
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
    Public Sub UpdateForwardingBatch()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select * from TSec_batch_ref where batch_ref=" & lblbatchref.Text & " and status='V'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "TSec_batch_ref")
            If (ds.Tables(0).Rows.Count > 0) Then
                cmd = New SqlCommand("Update TSec_batch_header set status='VI',Accepted_By='" & Session("username") & "',Accepted_On='" & Date.Now & "' where batch_ref=" & lblbatchref.Text & "", cn)
                If (cn.State = ConnectionState.Open) Then
                    cn.Close()
                End If
                cn.Open()
                cmd.ExecuteNonQuery()
                cn.Close()

                cmd = New SqlCommand("Update TSec_batch_ref set status='VI' where batch_ref=" & lblbatchref.Text & "", cn)
                If (cn.State = ConnectionState.Open) Then
                    cn.Close()
                End If
                cn.Open()
                cmd.ExecuteNonQuery()
                cn.Close()
                SaveTSecBatch()
            Else
                msgbox("Selected Batch has invalid flagging")
                Exit Sub
            End If

        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub SaveTSecBatch()
        Try


            Dim ds As New DataSet
            cmd = New SqlCommand("select Company, cds_number, holdernames, batch_type, batch_ref , shares, certificate from TSec_Batch_Ref where batch_ref=" & lblbatchref.Text & " and status ='VI'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "TSec_batch_header")
            If (ds.Tables(0).Rows.Count > 0) Then
                Dim i As Integer
                For i = 0 To ds.Tables(0).Rows.Count - 1
                    cmd = New SqlCommand("Update mast set shares=0 where cds_number='" & ds.Tables(0).Rows(i).Item("cds_number").ToString & "' and company='" & ds.Tables(0).Rows(i).Item("company").ToString & "' and cert='" & ds.Tables(0).Rows(i).Item("certificate").ToString & "'", cn)
                    If (cn.State = ConnectionState.Open) Then
                        cn.Close()
                    End If
                    cn.Open()
                    cmd.ExecuteNonQuery()
                    cn.Close()

                    cmd = New SqlCommand("insert into mast (company,cds_number,date_created,shares,update_type,Pladge,Pledge_shares,Created_By,Updated_on,Updated_By,locked,lock_reason,Batch_ref,cert) values('" & ds.Tables(0).Rows(i).Item("company").ToString & "','" & ds.Tables(0).Rows(i).Item("cds_number").ToString & "','" & Now.Date & "'," & ds.Tables(0).Rows(i).Item("shares").ToString & ",'" & ds.Tables(0).Rows(i).Item("batch_type").ToString & "',0,0,'" & Session("Username").ToString & "', '" & Now.Date & "','" & Session("Brokercode") & "',0,'-'," & ds.Tables(0).Rows(i).Item("batch_ref").ToString & ",0)", cn)
                    If (cn.State = ConnectionState.Open) Then
                        cn.Close()
                    End If
                    cn.Open()
                    cmd.ExecuteNonQuery()
                    cn.Close()


                    'cmd = New SqlCommand("insert into masttemp(Company,CDS_Number,Date_Created,Trans_Time,Shares,Update_Type,Created_By,Batch_Ref,Source) values ('" & ds.Tables(0).Rows(i).Item("company").ToString & "','" & ds.Tables(0).Rows(i).Item("CDS_Number").ToString & "','" & Date.Now & "','" & TimeOfDay & "'," & ds.Tables(0).Rows(0).Item("shares").ToString & ",'" & ds.Tables(0).Rows(0).Item("Batch_Type").ToString & "','USER'," & ds.Tables(0).Rows(i).Item("Batch_Ref").ToString & ",'IMMOBILIZATION')", cn)
                    'If (cn.State = ConnectionState.Open) Then
                    '    cn.Close()
                    'End If
                    'cn.Open()
                    'cmd.ExecuteNonQuery()
                    'cn.Close()
                Next
                msgbox("Batch Updated")
                SaveTrans()
                getCompany()
            Else
                msgbox("Nothing To Save in TSec Batch Header")
            End If

        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub SaveTrans()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select company,CDS_Number,Shareholder,HolderNames,Batch_Type,Batch_Ref,Certificate,CD,Shares,Status from TSec_batch_Ref where batch_ref=" & lblbatchref.Text & " and status ='VI'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "TSec_batch_header")
            If (ds.Tables(0).Rows.Count > 0) Then
                Dim i As Integer
                For i = 0 To ds.Tables(0).Rows.Count - 1
                    cmd = New SqlCommand("insert into trans(Company,CDS_Number,Date_Created,Trans_Time,Shares,Update_Type,Pledge_Shares,Created_By,Batch_Ref,Source) values ('" & ds.Tables(0).Rows(i).Item("company").ToString & "','" & ds.Tables(0).Rows(i).Item("CDS_Number").ToString & "','" & Date.Now & "','" & TimeOfDay & "'," & ds.Tables(0).Rows(0).Item("shares").ToString & ",'" & ds.Tables(0).Rows(0).Item("Batch_Type").ToString & "','0','USER'," & ds.Tables(0).Rows(i).Item("Batch_Ref").ToString & ",'IMMOBILIZATION')", cn)
                    If (cn.State = ConnectionState.Open) Then
                        cn.Close()
                    End If
                    cn.Open()
                    cmd.ExecuteNonQuery()
                    cn.Close()
                    getCompany()
                Next
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
                    cmd = New SqlCommand("insert into TSec_Batch_Ref (company,CDS_Number,Shareholder,HolderNames,Batch_Type,Batch_Ref,Certificate,CD,Shares,Forwarded_On,Forwarded_By,Status) values ('" & ds.Tables(0).Rows(i).Item("company").ToString & "','" & ds.Tables(0).Rows(i).Item("CDS_Number").ToString & "'," & ds.Tables(0).Rows(i).Item("Shareholder").ToString & ",'" & ds.Tables(0).Rows(i).Item("HolderNames").ToString & "','" & ds.Tables(0).Rows(i).Item("Batch_Type").ToString & "'," & ds.Tables(0).Rows(i).Item("Batch_Ref").ToString & "," & ds.Tables(0).Rows(i).Item("Certificate").ToString & "," & ds.Tables(0).Rows(i).Item("CD").ToString & "," & ds.Tables(0).Rows(i).Item("Shares").ToString & ",'" & Now.Date & "','USER','F')", cn)
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
            If (Session("Username") = Nothing) Then
                Response.Redirect("~\loginsystem.aspx")
            End If
            UpdateForwardingBatch()
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Protected Sub btnDecline_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDecline.Click
        Try
            UpdateDeclinedBatch()
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
End Class
