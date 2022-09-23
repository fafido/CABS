Imports System.Data
Imports System.Data.SqlClient
Partial Class TSecTrading_BatchAudit
    Inherits System.Web.UI.Page
    Dim constr As String = (System.Configuration.ConfigurationManager.AppSettings("connpath"))
    Dim cn As New SqlConnection(constr)
    Dim cmd As SqlCommand
    Dim adp As SqlDataAdapter
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
            rdBatchAuth.Checked = True
            If (rdBatchAuth.Checked = True) Then
                getBatchRef()
                getbatchdetails()
                getTransDetails()
            End If
        End If
    End Sub
    Public Sub getBatchRef()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select distinct (batch_ref) from TransAudit where Audit=1", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "TransAudit")
            If (ds.Tables(0).Rows.Count > 0) Then
                CmbBatchNumber.DataSource = ds.Tables(0)
                CmbBatchNumber.DataValueField = "batch_ref"
                CmbBatchNumber.DataBind()
            Else
                CmbBatchNumber.DataSource = Nothing
                CmbBatchNumber.DataBind()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Public Sub getBatchRefTextSearch()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select distinct (batch_ref) from TransAudit where Audit=1 and batch_ref=" & txtBatchSearch.Text & "", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "TransAudit")
            If (ds.Tables(0).Rows.Count > 0) Then
                lblBatchSearch.Text = ds.Tables(0).Rows(0).Item("Batch_ref").ToString
            Else

                MsgBox("Invalid Batch")
                lblBatchSearch.Text = "0"
                lblCompany.Text = ""
                lblBatchshares.Text = ""
                txtBatchSearch.Text = "0"
                grdAddedCertificate.DataSource = Nothing
                grdAddedCertificate.DataBind()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Public Sub getbatchdetails()
        Try
            Dim ds As New DataSet
            If (txtBatchSearch.Text = "") Then
                lblBatchSearch.Text = CmbBatchNumber.Text
            Else
                lblBatchSearch.Text = txtBatchSearch.Text
            End If
            If (lblBatchSearch.Text > 0) Then
                cmd = New SqlCommand("Select * from TSec_Batch_Header where batch_ref = " & lblBatchSearch.Text & "", cn)
                adp = New SqlDataAdapter(cmd)
                adp.Fill(ds, "Tsec_Batch_Header")
                lblCompany.Text = ds.Tables(0).Rows(0).Item("company").ToString
                lblBatchshares.Text = ds.Tables(0).Rows(0).Item("Batch_Total").ToString
                getTransDetails()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Public Sub getTransDetails()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("Select * from TransAudit where company = '" & lblCompany.Text & "' and batch_ref='" & lblBatchSearch.Text & "'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "TransAudit")
            If (ds.Tables(0).Rows.Count > 0) Then
                grdAddedCertificate.DataSource = ds.Tables(0)
                grdAddedCertificate.DataBind()
            Else
                grdAddedCertificate.DataSource = Nothing
                grdAddedCertificate.DataBind()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Public Sub getBatchSummary()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("Select sum(shares) as shares,company,Batch_Ref,audit from TransAudit where audit=1 and shares > 0 group by company, batch_ref,audit", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "TransAudit")
            If (ds.Tables(0).Rows.Count > 0) Then
                gdAddedHoldersto.DataSource = ds.Tables(0)
                gdAddedHoldersto.DataBind()
            Else
                gdAddedHoldersto.DataSource = Nothing
                gdAddedHoldersto.DataBind()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Protected Sub btnBatchSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBatchSearch.Click
        Try
            If (txtBatchSearch.Text = "") Then
                MsgBox("Enter a valid batch reference number")
                Exit Sub
            End If
            getBatchRefTextSearch()
            getbatchdetails()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Protected Sub CmbBatchNumber_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbBatchNumber.SelectedIndexChanged
        Try
            txtBatchSearch.Text = ""
            getbatchdetails()
            getTransDetails()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Public Sub getCapturedto()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select cds_number as [Holder Number], shares as [Shares], batch_ref as [Batch Ref],date_of_capture as [Captured Date] from TempTransFrom where company='" & lblCompany.Text & "' and batch_ref=" & lblBatchSearch.Text & "", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "TempTransFrom")
            If (ds.Tables(0).Rows.Count > 0) Then
                grdAddedCertificate.DataSource = ds.Tables(0)
                grdAddedCertificate.DataBind()
            Else
                grdAddedCertificate.DataSource = Nothing
                grdAddedCertificate.DataBind()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Public Sub getCaptured2()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select cds_number as [Holder Number], shares as [Shares], batch_ref as [Batch Ref],date_of_capture as [Captured Date] from TempTransTo where company='" & lblCompany.Text & "' and batch_ref=" & lblBatchSearch.Text & "", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "TempTransTo")
            If (ds.Tables(0).Rows.Count > 0) Then
                gdAddedHoldersto.DataSource = ds.Tables(0)
                gdAddedHoldersto.DataBind()
            Else
                gdAddedHoldersto.DataSource = Nothing
                gdAddedHoldersto.DataBind()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Protected Sub rdBatchAuth_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdBatchAuth.CheckedChanged
        Try
            If (rdBatchAuth.Checked = True) Then
                lblBatchSearch.Enabled = True
                CmbBatchNumber.Enabled = True
                txtBatchSearch.Enabled = True
                btnBatchSearch.Enabled = True
                lblCompany.Enabled = True
                lblBatchshares.Enabled = True
                btnApprove.Enabled = True
                btnDeclineBatch.Enabled = True
                getBatchRef()
                getbatchdetails()
                getTransDetails()
                grdAddedCertificate.Visible = True
                gdAddedHoldersto.Visible = False
                'Disable the All summary 
                btnApproveall.Enabled = False
                btnDeclineall.Enabled = False
            Else
                lblBatchSearch.Enabled = False
                CmbBatchNumber.Enabled = False
                txtBatchSearch.Enabled = False
                btnBatchSearch.Enabled = False
                lblCompany.Enabled = False
                lblBatchshares.Enabled = False
                btnApprove.Enabled = False
                btnDeclineBatch.Enabled = False
                'Enable the All summary 
                btnApproveall.Enabled = True
                btnDeclineall.Enabled = True
                gdAddedHoldersto.Visible = True

            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Protected Sub rdAuthoriseAll_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdAuthoriseAll.CheckedChanged
        Try
            If (rdAuthoriseAll.Checked = True) Then
                lblBatchSearch.Enabled = False
                CmbBatchNumber.Enabled = False
                txtBatchSearch.Enabled = False
                btnBatchSearch.Enabled = False
                lblCompany.Enabled = False
                lblBatchshares.Enabled = False
                btnApprove.Enabled = False
                btnDeclineBatch.Enabled = False
                lblCompany.Text = ""
                lblBatchSearch.Text = ""
                lblBatchshares.Text = ""

                'Enable the All summary 
                btnApproveall.Enabled = True
                btnDeclineall.Enabled = True
                grdAddedCertificate.Visible = False
                gdAddedHoldersto.Visible = True
                getBatchSummary()
            Else
                lblBatchSearch.Enabled = True
                CmbBatchNumber.Enabled = True
                txtBatchSearch.Enabled = True
                btnBatchSearch.Enabled = True
                lblCompany.Enabled = True
                lblBatchshares.Enabled = True
                btnApprove.Enabled = True
                btnDeclineBatch.Enabled = True
                getBatchRef()
                getbatchdetails()
                getTransDetails()
                grdAddedCertificate.Visible = True
                'Disable the All summary 
                btnApproveall.Enabled = False
                btnDeclineall.Enabled = False
                gdAddedHoldersto.Visible = False
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Protected Sub btnApprove_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnApprove.Click
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("Select * from TransAudit where company='" & lblCompany.Text & "' and batch_ref=" & lblBatchSearch.Text & "", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "TransAudit")
            If (ds.Tables(0).Rows.Count > 0) Then
                Dim i, j As Integer
                For i = 0 To ds.Tables(0).Rows.Count - 1
                    cmd = New SqlCommand("insert into masttemp (company,cds_number,Date_Created,Shares,Update_Type,Created_By,Batch_Ref,Source) values ('" & ds.Tables(0).Rows(i).Item("company").ToString & "','" & ds.Tables(0).Rows(i).Item("cds_number").ToString & "','" & Date.Now & "'," & ds.Tables(0).Rows(i).Item("shares").ToString & ",'XFER','" & Session("UserName") & "'," & ds.Tables(0).Rows(i).Item("batch_ref") & ",'S')", cn)
                    If (cn.State = ConnectionState.Open) Then
                        cn.Close()
                    End If
                    cn.Open()
                    cmd.ExecuteNonQuery()
                    cn.Close()
                Next

                For j = 0 To ds.Tables(0).Rows.Count - 1
                    cmd = New SqlCommand("update TransAudit set audit = 0 where company='" & lblCompany.Text & "' and batch_ref=" & lblBatchSearch.Text & "", cn)
                    If (cn.State = ConnectionState.Open) Then
                        cn.Close()
                    End If
                    cn.Open()
                    cmd.ExecuteNonQuery()
                    cn.Close()
                Next
                MsgBox("Records Updated")
                getBatchRef()
                getbatchdetails()
                getTransDetails()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Protected Sub btnApproveall_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnApproveall.Click
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("Select * from TransAudit where audit=1", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "TransAudit")
            If (ds.Tables(0).Rows.Count > 0) Then
                Dim i, j As Integer
                For i = 0 To ds.Tables(0).Rows.Count - 1
                    cmd = New SqlCommand("insert into masttemp (company,cds_number,Date_Created,Shares,Update_Type,Created_By,Batch_Ref,Source) values ('" & ds.Tables(0).Rows(i).Item("company").ToString & "','" & ds.Tables(0).Rows(i).Item("cds_number").ToString & "','" & Date.Now & "'," & ds.Tables(0).Rows(i).Item("shares").ToString & ",'XFER','" & Session("UserName") & "'," & ds.Tables(0).Rows(i).Item("batch_ref") & ",'S')", cn)
                    If (cn.State = ConnectionState.Open) Then
                        cn.Close()
                    End If
                    cn.Open()
                    cmd.ExecuteNonQuery()
                    cn.Close()
                Next

                For j = 0 To ds.Tables(0).Rows.Count - 1
                    cmd = New SqlCommand("update TransAudit set audit = 0 where audit=1", cn)
                    If (cn.State = ConnectionState.Open) Then
                        cn.Close()
                    End If
                    cn.Open()
                    cmd.ExecuteNonQuery()
                    cn.Close()
                Next
                MsgBox("Records Updated")
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Class