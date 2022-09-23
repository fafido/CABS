
Partial Class _Default
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
            If Session("end") = "Yes" Then
                Session("end") = ""
                msgbox("Pledge Approved")
            Else

            End If
            Page.MaintainScrollPositionOnPostBack = True
            If (Not IsPostBack) Then
                checkSessionState()
                getlst()

            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub ASPxButton7_Click(sender As Object, e As EventArgs) Handles ASPxButton7.Click
        Try
            Dim ds As New DataSet '
            cmd = New SqlCommand("select CONVERT(varchar(10), id)+' '+ company+' '+ securitytype+' '+ CONVERT(varchar(10), Quantity ) as pleadgeinf, id from pledges_recording where Pledge_Status='O'  and id like '" & txtpledgeid.Text & "%'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "Accounts_Clients")
            If (ds.Tables(0).Rows.Count > 0) Then
                lstpledgeSearch.DataSource = ds.Tables(0)
                lstpledgeSearch.TextField = "pleadgeinf"
                lstpledgeSearch.ValueField = "id"
                lstpledgeSearch.DataBind()
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub ASPxButton8_Click(sender As Object, e As EventArgs) Handles ASPxButton8.Click
        Try
            Dim dsname As New DataSet '
            cmd = New SqlCommand("select CONVERT(varchar(10), id)+' '+ company+' '+ securitytype+' '+ CONVERT(varchar(10), Quantity ) as pleadgeinf, id from pledges_recording where Pledge_Status='O'  and surname like '" & txtpledgorname.Text & "%'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(dsname, "Accounts_Clients1")
            If (dsname.Tables(0).Rows.Count > 0) Then
                lstpledgeSearch.DataSource = dsname.Tables(0)
                lstpledgeSearch.TextField = "pleadgeinf"
                lstpledgeSearch.ValueField = "id"
                lstpledgeSearch.DataBind()
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub ASPxButton9_Click(sender As Object, e As EventArgs) Handles ASPxButton9.Click
        Try
            Dim dspledgee As New DataSet '
            cmd = New SqlCommand("select CONVERT(varchar(10), id)+' '+ company+' '+ securitytype+' '+ CONVERT(varchar(10), Quantity ) as pleadgeinf, id from pledges_recording where Pledge_Status='O'  and pledgee_surname like '" & txtpledgeename.Text & "%'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(dspledgee, "Accounts_Clients2")
            If (dspledgee.Tables(0).Rows.Count > 0) Then
                lstpledgeSearch.DataSource = dspledgee.Tables(0)
                lstpledgeSearch.TextField = "pleadgeinf"
                lstpledgeSearch.ValueField = "id"
                lstpledgeSearch.DataBind()
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub lstpledgeSearch_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstpledgeSearch.SelectedIndexChanged
        Try
            'If (lstNameSearch.SelectedIndex.ToString > 1) Then
            Dim dsinfor As New DataSet
            cmd = New SqlCommand("select * from pledges_recording where id ='" & lstpledgeSearch.Value.ToString & "'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(dsinfor, "pledge_infor")
            If (dsinfor.Tables(0).Rows.Count > 0) Then
                txtreasons.Text = dsinfor.Tables(0).Rows(0).Item("PledgeReason").ToString

                ' Pledgor Information
                txtpledgor_surname.Text = dsinfor.Tables(0).Rows(0).Item("surname").ToString
                txtpledgor_Id.Text = dsinfor.Tables(0).Rows(0).Item("cds_number").ToString
                txtpledgor_othernames.Text = dsinfor.Tables(0).Rows(0).Item("forenames").ToString

                'Pledge Information
                txtcompany.Text = dsinfor.Tables(0).Rows(0).Item("company").ToString
                txtsecuritytype.Text = dsinfor.Tables(0).Rows(0).Item("SecurityType").ToString
                txtquantity.Text = dsinfor.Tables(0).Rows(0).Item("quantity").ToString
                txtEffectiveDate.Text = dsinfor.Tables(0).Rows(0).Item("effectivedate").ToString
                txtexpirydate.Text = dsinfor.Tables(0).Rows(0).Item("Expirydate").ToString

                'Pledgee Details
                txtpledgee_address.Text = dsinfor.Tables(0).Rows(0).Item("pledgeee_add_1").ToString
                txtpledgee_client_id.Text = dsinfor.Tables(0).Rows(0).Item("pledgee_cds_number").ToString
                txtpledgee_other_names.Text = dsinfor.Tables(0).Rows(0).Item("pledgee_forenames").ToString
                txtpledgee_surname.Text = dsinfor.Tables(0).Rows(0).Item("pledgee_surname").ToString
                txtpledgee_address2.Text = dsinfor.Tables(0).Rows(0).Item("pledgee_add_2").ToString
                txtpledgee_address3.Text = dsinfor.Tables(0).Rows(0).Item("pledgee_add_3").ToString
                txtpledgee_city.Text = dsinfor.Tables(0).Rows(0).Item("pledgee_city").ToString
                txtpledgee_country.Text = dsinfor.Tables(0).Rows(0).Item("pledgee_country").ToString

                If dsinfor.Tables(0).Rows(0).Item("pledgee_type").ToString = "ACCOUNT HOLDER" Then
                    rdAccHolder.Checked = True
                    rdAccHolder0.Checked = False

                Else
                    rdAccHolder.Checked = False
                    rdAccHolder0.Checked = True

                End If
                If dsinfor.Tables(0).Rows(0).Item("pledgetype").ToString = "Voluntary" Then
                    rdVoluntary.Checked = True
                    rdPledgeType.Checked = False

                ElseIf dsinfor.Tables(0).Rows(0).Item("pledgetype").ToString = "FORCED" Then
                    rdVoluntary.Checked = False
                    rdPledgeType.Checked = True

                End If



            Else
                txtreasons.Text = ""
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    'Public Sub GetCompanies()
    '    Try
    '        Dim dscomps As New DataSet
    '        cmd = New SqlCommand("select distinct (company) from trans", cn)
    '        adp = New SqlDataAdapter(cmd)
    '        adp.Fill(dscomps, "trans")
    '        If (dscomps.Tables(0).Rows.Count > 0) Then
    '            cmbcompany.DataSource = dscomps.Tables(0)
    '            cmbcompany.TextField = "company"
    '            cmbcompany.ValueField = "company"
    '            cmbcompany.DataBind()
    '        End If
    '    Catch ex As Exception
    '        msgbox(ex.Message)
    '    End Try
    'End Sub
    'Public Sub GetSec_Types()
    '    Try
    '        Dim ds As New DataSet
    '        cmd = New SqlCommand("select distinct (seccode) as seccode from sec_types ", cn)
    '        adp = New SqlDataAdapter(cmd)
    '        adp.Fill(ds, "sec_types")
    '        If (ds.Tables(0).Rows.Count > 0) Then
    '            cmbsecurity_type.DataSource = ds.Tables(0)
    '            cmbsecurity_type.TextField = "seccode"
    '            cmbsecurity_type.ValueField = "seccode"
    '            cmbsecurity_type.DataBind()
    '        End If
    '    Catch ex As Exception
    '        msgbox(ex.Message)
    '    End Try
    'End Sub

    Public Sub getlst()
        Try
            Dim dsall As New DataSet '
            cmd = New SqlCommand("select CONVERT(varchar(10), id)+' '+ company+' '+ securitytype+' '+ CONVERT(varchar(10), Quantity ) as pleadgeinf, id from pledges_recording where Pledge_Status='O'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(dsall, "Accounts_Clients7")
            If (dsall.Tables(0).Rows.Count > 0) Then
                lstpledgeSearch.DataSource = dsall.Tables(0)
                lstpledgeSearch.TextField = "pleadgeinf"
                lstpledgeSearch.ValueField = "id"
                lstpledgeSearch.DataBind()
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub


    Protected Sub ASPxButton10_Click(sender As Object, e As EventArgs) Handles ASPxButton10.Click
        Try
            cmd = New SqlCommand("update Pledges_recording set pledge_status='A1' where id='" + lstpledgeSearch.Value.ToString + "'", cn)
            If (cn.State = ConnectionState.Open) Then
                cn.Close()
            End If
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()
            Session("end") = "Yes"
            Response.Redirect(Request.RawUrl)
        Catch ex As Exception

        End Try
       
    End Sub

    Protected Sub txtreasons_TextChanged(sender As Object, e As EventArgs) Handles txtreasons.TextChanged

    End Sub
End Class
