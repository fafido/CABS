Imports System.Data
Imports System.Data.SqlClient
Partial Class Trading_OrdersReporting
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
            cmd = New SqlCommand("select distinct (orderNumber) from OrdersSummary where status<>'X'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "TransAudit")
            If (ds.Tables(0).Rows.Count > 0) Then
                CmbBatchNumber.DataSource = ds.Tables(0)
                CmbBatchNumber.DataValueField = "ORDERnUMBER"
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
            cmd = New SqlCommand("select orderNumber from OrdersSummary where orderNumber='" & txtOrderSearch.Text & "'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "OrdersSummary")
            If (ds.Tables(0).Rows.Count > 0) Then
                lblBatchSearch.Text = ds.Tables(0).Rows(0).Item("OrderNumber").ToString
            Else
                MsgBox("Invalid OrderNumber")
                lblBatchSearch.Text = "0"
                lblCompany.Text = ""
                lblBatchshares.Text = ""
                txtOrderSearch.Text = "0"
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
            If (txtOrderSearch.Text = "") Then
                lblBatchSearch.Text = CmbBatchNumber.Text
            Else
                lblBatchSearch.Text = txtOrderSearch.Text
            End If
            If (lblBatchSearch.Text <> "") Then
                cmd = New SqlCommand("Select * from OrdersSummary where ORDERNumber = '" & CStr(lblBatchSearch.Text) & "'", cn)
                adp = New SqlDataAdapter(cmd)
                adp.Fill(ds, "OrdersSummary")
                lblCompany.Text = ds.Tables(0).Rows(0).Item("company").ToString
                lblBatchshares.Text = ds.Tables(0).Rows(0).Item("Order_Quantity").ToString

                getTransDetails()
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub getTransDetails()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("Select * from OrdersSummary where orderNumber='" & lblBatchSearch.Text & "'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "OrdersSummary")
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
            If (txtOrderSearch.Text = "") Then
                MsgBox("Enter a valid order reference number")
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
            txtOrderSearch.Text = ""
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
                txtOrderSearch.Enabled = True
                btnBatchSearch.Enabled = True
                lblCompany.Enabled = True
                lblBatchshares.Enabled = True
                btnApprove.Enabled = True
                getBatchRef()
                getbatchdetails()
                getTransDetails()
                grdAddedCertificate.Visible = True
                gdAddedHoldersto.Visible = False
                'Disable the All summary 
                btnApproveall.Enabled = False
            Else
                lblBatchSearch.Enabled = False
                CmbBatchNumber.Enabled = False
                txtOrderSearch.Enabled = False
                btnBatchSearch.Enabled = False
                lblCompany.Enabled = False
                lblBatchshares.Enabled = False
                btnApprove.Enabled = False
                'Enable the All summary 
                btnApproveall.Enabled = True
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
                txtOrderSearch.Enabled = False
                btnBatchSearch.Enabled = False
                lblCompany.Enabled = False
                lblBatchshares.Enabled = False
                btnApprove.Enabled = False
                lblCompany.Text = ""
                lblBatchSearch.Text = ""
                lblBatchshares.Text = ""

                'Enable the All summary 
                btnApproveall.Enabled = True
                grdAddedCertificate.Visible = False
                gdAddedHoldersto.Visible = True
                'getBatchSummary()
            Else
                lblBatchSearch.Enabled = True
                CmbBatchNumber.Enabled = True
                txtOrderSearch.Enabled = True
                btnBatchSearch.Enabled = True
                lblCompany.Enabled = True
                lblBatchshares.Enabled = True
                btnApprove.Enabled = True
                getBatchRef()
                getbatchdetails()
                getTransDetails()
                grdAddedCertificate.Visible = True
                'Disable the All summary 
                btnApproveall.Enabled = False
                gdAddedHoldersto.Visible = False
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Protected Sub btnApprove_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnApprove.Click
        If (lblBatchSearch.Text <> "") Then
            Dim strscript As String
            strscript = "<script langauage=JavaScript>"
            strscript += "window.open('OrdersSummaryOne.aspx?orderNumber=" & lblBatchSearch.Text & "');"
            strscript += "</script>"
            ClientScript.RegisterStartupScript(Me.GetType(), "newwin", strscript)
        Else
            msgbox("Enter Requiered Values")
            Exit Sub
        End If
    End Sub

    Protected Sub btnApproveall_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnApproveall.Click
        Try

            Dim strscript As String
            strscript = "<script langauage=JavaScript>"
            strscript += "window.open('AllOrdersReportCall.aspx');"
            strscript += "</script>"
            ClientScript.RegisterStartupScript(Me.GetType(), "newwin", strscript)

        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
End Class