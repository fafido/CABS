Partial Class TSecEnquiries_ChequeStatusEnquiry
    Inherits System.Web.UI.Page
    Dim cn As SqlConnection
    Dim cmd As SqlCommand
    Dim adp As New SqlDataAdapter
    Dim cnstr As String
    Dim dmbOb As New BindCombo
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Page.MaintainScrollPositionOnPostBack = True

        Dim dsCmbComp As New DataSet

        Try
            cnstr = (System.Configuration.ConfigurationManager.AppSettings("connpath"))
            cn = New SqlConnection(cnstr)

            If (Not IsPostBack) Then
                dmbOb.BindCombo("div_instr", "company", cmbCompany)
                BindDivCombo()


                ' BindCompany()
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

    Public Sub BindDivCombo()
        Try
            Dim dsDivno As New DataSet

            If cmbCompany.Text <> "" Then
                cmd = New SqlCommand("select distinct div_no from div_instr where company = '" & cmbCompany.SelectedValue.ToString() & "'", cn)
                adp = New SqlDataAdapter(cmd)
                adp.Fill(dsDivno, "div_instr")
                cmbDivno.DataSource = dsDivno.Tables("div_instr")
                cmbDivno.DataValueField = "div_no"
                cmbDivno.DataMember = "div_no"
                cmbDivno.DataBind()

            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub btnShow_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnShow.Click
        Try

            Dim dsSearch As New DataSet

            If txtChequeNo.Text <> "" And cmbCompany.Text <> "" And cmbDivno.Text <> "" Then
                cmd = New SqlCommand("select Cheq_no as ChequeNo,payee as Payee,cheq_dets .Shareholder as Shareholder,amount as Amount,Status = case status when 'C' then 'Paid Cheque' when 'o' then 'Unclaimed Cheque' when 'x' then 'Cancelled Cheque' when 'w' then 'Warrant Not Presentable' end ,convert(varchar,ActionDate,103) as DatePaid, case names.DomantState when  0 then 'Account Active' when  1 then 'Account Active' when  2 then 'Account Active' else 'Account Dormant' end as [Account Status] from cheq_dets, names where  cheq_no =" & txtChequeNo.Text & " and company = '" & cmbCompany.SelectedValue.ToString() & "' and names.shareholder = cheq_dets .Shareholder and names.compny = cheq_dets .Company  and div_no =" & cmbDivno.SelectedValue.ToString() & "", cn)
                adp = New SqlDataAdapter(cmd)
                adp.Fill(dsSearch, "cheq_dets")
                If dsSearch.Tables(0).Rows.Count > 0 Then
                    dtlList.DataSource = dsSearch
                    dtlList.DataBind()
                Else
                    msgbox("Record not found")
                End If
            Else
                msgbox("select Company,Divno and Enter cheque no")
                Exit Sub

            End If


        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub cmbCompany_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbCompany.SelectedIndexChanged
        Try
            BindDivCombo()

        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub dtlList_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DetailsViewPageEventArgs) Handles dtlList.PageIndexChanging

    End Sub
End Class
