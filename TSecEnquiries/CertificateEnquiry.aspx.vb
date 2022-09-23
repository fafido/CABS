Partial Class TSecEnquiries_CertificateEnquiry
    Inherits System.Web.UI.Page
    Dim cn As SqlConnection
    Dim cmd As SqlCommand
    Dim adp As New SqlDataAdapter
    Dim cnstr As String
    Dim dmbOb As New BindCombo

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Page.MaintainScrollPositionOnPostBack = True
        cmbCompany.Focus()
        Dim dsCmbComp As New DataSet
        Try
            cnstr = (System.Configuration.ConfigurationManager.AppSettings("connpath"))
            cn = New SqlConnection(cnstr)
            If (Not IsPostBack) Then
                dmbOb.BindCombo("para_company", "company", cmbCompany)

                BindGrid()
            End If
            'BindGrid()
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

    Protected Sub DropDownList1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbCompany.SelectedIndexChanged

        BindGrid()
    End Sub

    Public Sub BindGrid()
        Dim dsGrid, dscert, dscertmast As New DataSet
        Try
            If (txtCert.Text <> "") Then
                Dim str As String = ""

                cmd = New SqlCommand("select certno from batchcertvari where company='" & cmbCompany.SelectedItem.Value & "' and certno =" & txtCert.Text & " and vari=1", cn)
                adp = New SqlDataAdapter(cmd)
                adp.Fill(dscert, "batchcertvari")

                cmd = New SqlCommand("select cert from mast where company='" & cmbCompany.SelectedItem.Value & "' and cert =" & txtCert.Text & " and shares>0", cn)
                adp = New SqlDataAdapter(cmd)
                adp.Fill(dscertmast, "batchcertvari")


                If (dscert.Tables(0).Rows.Count > 0) And dscertmast.Tables(0).Rows.Count > 0 Then
                    str = "select names.shareholder,names.short,names.surname,names.forenames,mast.cert,mast.shares,locked,lockreason,'H' as Verified from names,mast where names.shareholder=mast.shareholder and mast.cert=" & txtCert.Text & " and company= '" & cmbCompany.SelectedItem.Text & "' and names.compny=mast.company"
                Else
                    str = "select names.shareholder,names.short,names.surname,names.forenames,mast.cert,mast.shares,locked,lockreason from names,mast where names.shareholder=mast.shareholder and mast.cert=" & txtCert.Text & " and company= '" & cmbCompany.SelectedItem.Text & "' and names.compny=mast.company"
                End If


                cmd = New SqlCommand(str, cn)
                adp = New SqlDataAdapter(cmd)
                adp.Fill(dsGrid, "mast")
                If (dsGrid.Tables(0).Rows.Count > 0) Then
                    grdCertiEnqu.DataSource = dsGrid
                    grdCertiEnqu.DataBind()
                Else
                    msgbox("Records Not Found")
                    grdCertiEnqu.DataSource = Nothing
                    grdCertiEnqu.DataBind()
                End If

            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Protected Sub grdCertiEnqu_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles grdCertiEnqu.PageIndexChanging
        Try
            grdCertiEnqu.PageIndex = e.NewPageIndex
            BindGrid()
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Protected Sub btnSerch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSerch.Click
        Try
            If (txtCert.Text = "") Then
                msgbox("Please Enter The Value Of Certificate")
                txtCert.Focus()
                Exit Sub
            End If
            If (Not IsNumeric(txtCert.Text)) Then
                msgbox("Please Enter valid Certificate")
                txtCert.Focus()
                Exit Sub
            End If
            BindGrid()
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Protected Sub grdCertiEnqu_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdCertiEnqu.SelectedIndexChanged

    End Sub

End Class
