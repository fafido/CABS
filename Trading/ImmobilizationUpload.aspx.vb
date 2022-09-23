Imports System.Data
Imports System.Data.SqlClient
Partial Class Trading_ImmobilizationUpload
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
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Page.MaintainScrollPositionOnPostBack = True
        If (Not IsPostBack) Then
            getCompany()
            txtCd.Text = 0
            GetBatchTypes()
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
            If (txtBatchShares.Text = "") Then
                msgbox("Enter total batch shares")
                Exit Sub
            End If
            If (BasicDatePicker1.Text = "") Then
                msgbox("Select a valid date")
                Exit Sub
            End If
            getmaxBatchref()
            cmd = New SqlCommand("insert into Broker_batch_header(batch_ref,company,batch_type,shares,lodger,created_by,created_on,status)values(" & maxbatchref & ",'" & cmbParaCompany.Text & "','" & CmbBatchType.Text & "'," & txtBatchShares.Text & ",'" & Session("BrokerCode") & "','" & Session("UserName") & "','" & BasicDatePicker1.Text & "','C')", cn)
            If (cn.State = ConnectionState.Open) Then
                cn.Close()
            End If
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()
            lblbatchref.Text = maxbatchref
            grdAddedCertificate.DataSource = Nothing
            grdAddedCertificate.DataBind()
            msgbox("Batch Created, Enter batch shares")
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Protected Sub btnBatchSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBatchSearch.Click
        Try
            getBatch()
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub getBatch()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("Select * from broker_batch_header where batch_ref=" & txtSearch.Text & "", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "Broker_batch_header")
            If (ds.Tables(0).Rows.Count > 0) Then
                CmbBatchType.Text = ds.Tables(0).Rows(0).Item("Batch_Type").ToString
                cmbParaCompany.Text = ds.Tables(0).Rows(0).Item("company").ToString
                lblbatchref.Text = ds.Tables(0).Rows(0).Item("batch_ref").ToString
                txtBatchShares.Text = ds.Tables(0).Rows(0).Item("Shares").ToString
                BtnUpdate.Enabled = True
                Dim ds1 As New DataSet
                cmd = New SqlCommand("Select Batch_ref,Company,Batch_Type,Shareholder as [Old Holder Number],Shares,Certificate,CD,CDS_Number from broker_Batch_Ref where batch_ref=" & txtSearch.Text & "", cn)
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
                txtSearch.Text = ""
                lblbatchref.Text = ""
                txtShares.Text = ""
                txtBatchShares.Text = ""
                BtnUpdate.Enabled = False
                Exit Sub
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub btnNumberSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnNumberSearch.Click
        Try
            getHolderNumber()
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub getHolderNumber()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("Select CDS_Number,Surname,Forenames from names where CDS_Number='" & txtShareholderSearch.Text & "'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "names")
            If (ds.Tables(0).Rows.Count > 0) Then
                lblSelctedNames.Text = (ds.Tables(0).Rows(0).Item("Surname").ToString & " " & ds.Tables(0).Rows(0).Item("Forenames").ToString)
                LblShareholder.Text = ds.Tables(0).Rows(0).Item("CDS_Number").ToString
            Else
                msgbox("Invalid Shareholder Number")
                lblSelctedNames.Text = ""
                LblShareholder.Text = ""
                Exit Sub
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Protected Sub btnAddCerts_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAddCerts.Click
        Try
            If (LblShareholder.Text = "") Then
                msgbox("Select A Holder First")
                Exit Sub
            End If
            If (lblbatchref.Text = "") Then
                msgbox("Select a batch, or create one first")
                Exit Sub
            End If
            If (txtShareholder.Text = "") Then
                msgbox("Enter a valid old holder number ")
                Exit Sub
            End If
            Dim totBatch As Integer = 0
            Dim capBatch As Integer = 0
            Dim ds As New DataSet
            cmd = New SqlCommand("Select * from broker_batch_ref where batch_ref=" & lblbatchref.Text & "", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "broker_batch_ref")
            If (ds.Tables(0).Rows.Count > 0) Then
                Dim res As New DataSet
                cmd = New SqlCommand("Select sum(shares) as shares from broker_batch_ref where batch_ref=" & lblbatchref.Text & "", cn)
                adp = New SqlDataAdapter(cmd)
                adp.Fill(res, "broker_batch_ref")
                If (res.Tables(0).Rows.Count > 0) Then
                    capBatch = CInt(res.Tables(0).Rows(0).Item("shares").ToString)
                Else
                    capBatch = 0
                End If
                totBatch = CInt(CInt(txtShares.Text) + capBatch)
                If (CInt(totBatch) < CInt(txtBatchShares.Text)) Then
                    SaveBatchCerts()
                    displaydata()
                End If
                If (CInt(totBatch) = CInt(txtBatchShares.Text)) Then
                    SaveBatchCerts()
                    FlagBalancedBatch()
                    cleardata()
                    msgbox("Batch Balanced")
                End If
                If (CInt(totBatch) > CInt(txtBatchShares.Text)) Then
                    msgbox("Batch not balanced")
                    Exit Sub
                End If
            Else
                'MsgBox("In Else")
                If (CInt(txtShares.Text) < CInt(txtBatchShares.Text)) Then
                    SaveBatchCerts()
                    displaydata()
                End If
                If (CInt(txtBatchShares.Text = CInt(txtShares.Text))) Then
                    SaveBatchCerts()
                    FlagBalancedBatch()
                    cleardata()
                    msgbox("Batch Balanced")
                    displaydata()
                End If
                If (CInt(txtShares.Text) > CInt(txtBatchShares.Text)) Then
                    msgbox("Batch Not Balanced")
                    Exit Sub
                End If
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub cleardata()
        Try
            txtBatchShares.Text = ""
            txtShareholderName.Text = ""
            txtShareholderSearch.Text = ""
            lblSelctedNames.Text = ""
            LblShareholder.Text = ""

            grdAddedCertificate.DataSource = Nothing
            grdAddedCertificate.DataBind()

            BasicDatePicker1.Clear()
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub BatchSumValidation()
        Try
            Dim totBatch As Integer = 0
            Dim ds As New DataSet
            cmd = New SqlCommand("Select * from broker_batch_ref where batch_ref=" & lblbatchref.Text & "", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "broker_batch_ref")
            If (ds.Tables(0).Rows.Count > 0) Then
                Dim res As New DataSet
                cmd = New SqlCommand("Select sum(shares) as shares from broker_batch_ref where batch_ref=" & lblbatchref.Text & "", cn)
                adp = New SqlDataAdapter(cmd)
                adp.Fill(res, "broker_batch_ref")
                If (CInt(txtBatchShares.Text) = CInt(res.Tables(0).Rows(0).Item("shares").ToString)) Then
                    msgbox("Batch Balanced")
                End If
                If (CInt(res.Tables(0).Rows(0).Item("shares").ToString) > CInt(txtBatchShares.Text)) Then
                    msgbox("Batch not balanced")
                    Exit Sub
                End If
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub FlagBalancedBatch()
        Try
            cmd = New SqlCommand("Update broker_batch_header set status='B' where batch_ref=" & lblbatchref.Text & " and company='" & cmbParaCompany.Text & "' and batch_type='" & CmbBatchType.Text & "'", cn)
            If (cn.State = ConnectionState.Open) Then
                cn.Close()
            End If
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()

            cmd = New SqlCommand("Update broker_batch_ref set status='B' where batch_ref=" & lblbatchref.Text & " and company='" & cmbParaCompany.Text & "' and batch_type='" & CmbBatchType.Text & "'", cn)
            If (cn.State = ConnectionState.Open) Then
                cn.Close()
            End If
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()

        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub SaveBatchCerts()
        Try
            cmd = New SqlCommand("Insert into broker_batch_ref (batch_ref,company,batch_type,shareholder,shares,Certificate,Cd,CDS_Number,HolderNames,Status) values(" & lblbatchref.Text & ",'" & cmbParaCompany.Text & "','" & CmbBatchType.Text & "'," & txtShareholder.Text & "," & txtShares.Text & "," & txtCert.Text & "," & txtCd.Text & ",'" & LblShareholder.Text & "','" & lblSelctedNames.Text & "','C')", cn)
            If (cn.State = ConnectionState.Open) Then
                cn.Close()
            End If
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()

            txtShares.Text = ""
            txtCert.Text = ""
            txtCd.Text = "0"
            txtShareholder.Text = ""
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

    Protected Sub BtnDelCert_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnDelCert.Click
        Try
            Dim i, j As Integer

            Dim dssharescert, dscertvari As New DataSet
            j = grdAddedCertificate.Rows.Count
            For i = 0 To j - 1
                j = grdAddedCertificate.Rows.Count
                Dim chk As CheckBox
                chk = CType(grdAddedCertificate.Rows(i).Cells(0).FindControl("checkbox1"), CheckBox)
                If chk.Checked = True Then
                    cmd = New SqlCommand("delete from Broker_Batch_Ref where batch_ref=" & grdAddedCertificate.Rows(i).Cells(1).Text & " and certificate=" & grdAddedCertificate.Rows(i).Cells(6).Text & " and cd = " & grdAddedCertificate.Rows(i).Cells(7).Text & " and company='" & grdAddedCertificate.Rows(i).Cells(2).Text & "' and CDS_Number='" & grdAddedCertificate.Rows(i).Cells(8).Text & "' and status='C'", cn)
                    cn.Open()
                    cmd.ExecuteNonQuery()
                    cn.Close()
                End If
            Next
            displaydata()
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub GetNames()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("Select surname+' '+forenames+' '+cds_number as namess from names where surname like '" & txtShareholderName.Text & "%'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "names")
            If (ds.Tables(0).Rows.Count > 0) Then
                lstName.DataSource = ds.Tables(0)
                lstName.DataValueField = "namess"
                lstName.DataBind()
            Else
                lstName.DataSource = Nothing
                lstName.DataValueField = ""
                lstName.DataBind()
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Protected Sub btnNameSearch1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnNameSearch1.Click
        Try
            GetNames()
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub btnSelect_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSelect.Click
        Try
            If (lstName.SelectedIndex < 0) Then
                msgbox("Select a a name to search")
                Exit Sub
            End If
            Dim ds As New DataSet
            cmd = New SqlCommand("select cds_number,surname,forenames from names where surname+' '+forenames+' '+cds_number = '" & lstName.SelectedItem.Text & "'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "names")
            'txtShareholder.Text = ds.Tables(0).Rows(0).Item("cds_number").ToString
            txtShareholderSearch.Text = ds.Tables(0).Rows(0).Item("cds_number").ToString
            lblSelctedNames.Text = (ds.Tables(0).Rows(0).Item("Surname").ToString & " " & ds.Tables(0).Rows(0).Item("Forenames").ToString)
            LblShareholder.Text = ds.Tables(0).Rows(0).Item("CDS_Number").ToString
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub BtnPrint_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnPrint.Click
        Try
            Dim strscript As String
            strscript = "<script langauage=JavaScript>"
            strscript += "window.open('BatchReceiptingCall.aspx?batchRef=" & lblbatchref.Text & "');"
            strscript += "</script>"
            ClientScript.RegisterStartupScript(Me.GetType(), "newwin", strscript)
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub CmbBatchType_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbBatchType.SelectedIndexChanged

    End Sub
End Class
