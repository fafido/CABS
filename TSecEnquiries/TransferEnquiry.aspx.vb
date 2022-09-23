Partial Class TSecEnquiries_TransferEnquiry
    Inherits System.Web.UI.Page
    Dim cn As SqlConnection
    Dim cmd As SqlCommand
    Dim adp As New SqlDataAdapter
    Dim cnstr As String
    Dim dmbOb As New BindCombo
    Dim flag As Integer
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Page.MaintainScrollPositionOnPostBack = True
        cmbCompany.Focus()
        Try
            cnstr = (System.Configuration.ConfigurationManager.AppSettings("connpath"))
            cn = New SqlConnection(cnstr)
            If (Not IsPostBack) Then
                dmbOb.BindCombo("para_company", "company", cmbCompany)
                BindCertCombo()
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
    Public Sub BindCertCombo()
        Dim dsComTran As New DataSet

        Try
            dsComTran.Clear()
            If (cmbCompany.Text <> "") Then
                cmd = New SqlCommand("select distinct(xfer) from mast where xfer <> 0 and company = '" & cmbCompany.SelectedValue & "' order by xfer", cn)
                adp = New SqlDataAdapter(cmd)
                adp.Fill(dsComTran, "mast")
                If (dsComTran.Tables("mast").Rows.Count > 0) Then
                    cmbTransferno.DataSource = dsComTran.Tables("mast")
                    cmbTransferno.DataValueField = "xfer"
                    cmbTransferno.DataBind()
                Else
                    cmbTransferno.DataSource = dsComTran.Tables("mast")
                    cmbTransferno.DataValueField = Nothing
                    cmbTransferno.DataBind()
                End If
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub BindGrid()
        Dim dsGrid As New DataSet
        grdEnqTran.DataSource = Nothing
        grdEnqTran.DataBind()
        Try
            If (cmbTransferno.Text <> "") Then
                cmd = New SqlCommand("select trans.company,trans.xfer,names.shareholder,names.short,names.surname,names.forenames,trans.cert,trans.shares from names,trans where names.shareholder=trans.shareholder and trans.tran_type='xfer' and trans.xfer=" & Convert.ToInt32(cmbTransferno.SelectedValue) & " and trans.shares < 0 and company='" & cmbCompany.Text & "'", cn)
                adp = New SqlDataAdapter(cmd)
                adp.Fill(dsGrid, "trans")
                If (dsGrid.Tables(0).Rows.Count > 0) Then
                    grdEnqTran.DataSource = dsGrid
                    grdEnqTran.DataBind()
                End If
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub BindGrid1()
        Dim dsGrid1 As New DataSet
        grdbatchto.DataSource = Nothing
        grdbatchto.DataBind()
        Try
            If (cmbTransferno.Text <> "") Then
                'cmd = New SqlCommand("select trans.xfer,names.shareholder,names.short,names.surname,names.forenames,trans.cert,trans.shares,trans.update_no,trans.batch_ref from names,trans where names.shareholder=trans.shareholder and trans.xfer=" & Convert.ToInt32(cmbTransferno.SelectedValue), cn)
                cmd = New SqlCommand("select trans.company,trans.xfer,names.shareholder,names.short,names.surname,names.forenames,trans.cert,trans.shares from names,trans where names.shareholder=trans.shareholder and trans.tran_type='xfer' and trans.xfer=" & Convert.ToInt32(cmbTransferno.SelectedValue) & " and trans.shares > 0 and company='" & cmbCompany.Text & "'", cn)
                adp = New SqlDataAdapter(cmd)
                adp.Fill(dsGrid1, "trans")
                If (dsGrid1.Tables(0).Rows.Count > 0) Then
                    grdbatchto.DataSource = dsGrid1
                    grdbatchto.DataBind()
                Else

                    msgbox("No Relevant Data Exists")
                    Exit Sub
                End If
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub cmbCompany_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbCompany.SelectedIndexChanged
        BindCertCombo()
    End Sub



    Protected Sub grdEnqTran_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles grdEnqTran.PageIndexChanging
        Try
            grdEnqTran.PageIndex = e.NewPageIndex
            BindGrid()
        Catch ex As Exception
            msgbox(ex.Message)
        End Try

    End Sub

    Protected Sub grdbatchto_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles grdbatchto.PageIndexChanging
        Try
            grdbatchto.PageIndex = e.NewPageIndex
            BindGrid1()
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Protected Sub b_search_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles b_search.Click
        BindGrid()
        BindGrid1()
    End Sub
End Class
