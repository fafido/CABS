Partial Class Enquiries_PledgeRecording
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
            Page.MaintainScrollPositionOnPostBack = True
            If (Not IsPostBack) Then
                checkSessionState()
                GetCompanies()
                GetSec_Types()
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub ASPxButton3_Click(sender As Object, e As EventArgs) Handles ASPxButton3.Click
        Try
            Dim Transshares As Integer = 0
            Dim PledgeShares As Integer = 0
            Dim Availshares As Integer = 0
            Dim dsishv As New DataSet
            cmd = New SqlCommand("select * from trans where cds_number ='" & lblClientID.Text & "' and company='" & cmbCompany.SelectedItem.Text & "'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(dsishv, "trans")
            If (dsishv.Tables(0).Rows.Count > 0) Then
                Dim ds As New DataSet
                cmd = New SqlCommand("select sum(shares) as shares from trans where  cds_number='" & lblClientID.Text & "' and company='" & cmbCompany.SelectedItem.Text & "'", cn)
                adp = New SqlDataAdapter(cmd)
                adp.Fill(ds, "trans")
                If (ds.Tables(0).Rows.Count > 0) Then
                    Transshares = ds.Tables(0).Rows(0).Item("shares").ToString
                End If

                Dim dspl As New DataSet
                cmd = New SqlCommand("select * from Pledges_Recording where cds_number ='" & lblClientID.Text & "' and company='" & cmbCompany.SelectedItem.Text & "' and pledge_status='C'", cn)
                adp = New SqlDataAdapter(cmd)
                adp.Fill(dspl, "Pledges_Recording")
                If (dspl.Tables(0).Rows.Count > 0) Then
                    Dim dsplsh As New DataSet
                    cmd = New SqlCommand("select sum(quantity) as shares from pledges_recording where  cds_number ='" & lblClientID.Text & "' and company='" & cmbCompany.SelectedItem.Text & "' AND pledge_status='C'", cn)
                    adp = New SqlDataAdapter(cmd)
                    adp.Fill(dsplsh, "pledges_recording")

                    PledgeShares = dsplsh.Tables(0).Rows(0).Item("shares").ToString

                End If
                Availshares = Transshares - PledgeShares
                If (Availshares > CInt(txtQuantity.Text)) Then
                    SavePleadge()
                Else
                    msgbox("Pledged shares are greater than available shares")
                    Exit Sub
                End If

            Else
                msgbox("Selected account has no valid securities in the selected counter")
                Exit Sub
            End If
            
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub SavePleadge()
        Try
            Dim PledgeType As String = ""
            If (rdForced.Checked = True) Then
                PledgeType = "Forced"
            End If
            If (rdVoluntary.Checked = True) Then
                PledgeType = "Voluntary"
            End If
            Dim PlegeeType As String = ""
            If (rdAccHolder.Checked = True) Then
                PlegeeType = "Account Holder"
            End If
            If (rdnonAccountHolder.Checked = True) Then
                PlegeeType = "Non account holder"
            End If
            'cmd = New SqlCommand("insert into Pledges_Recording (                                                                                                                                                                                                                                                                                                                                                                                     PledgeType,             PledgeReason,                               ,Cds_Number,                Surname,                    Forenames,                  Company,                            SecurityType,                           Quantity,                   EffectiveDate,                  ExpiryDate,                 Pledgee_Type,                       Pledgee_Cds_number,                     Pledgee_Surname,            Pledgee_Forenames,                  Pledgeee_Add_1,             Pledgee_Add_2,                  Pledgee_Add_3,                 Pledgee_City,                    Pledgee_Country,    Pledge_Status,  Pledge_Created_on,  Pledge_Created_By) values ('" & PledgeType & "','" & txtPledgeReason.Text.ToString.ToUpper & "','" & lblClientID.Text & "','" & txtSurname.Text & "','" & txtForenames.Text & "','" & cmbCompany.SelectedItem.Text & "','" & cmbSecType.SelectedItem.Text & "'," & txtQuantity.Text & ",'" & txtEffectiveDate.Text & "','" & txtExpiryDate.Text & "','" & PlegeeType.ToString.ToUpper & "','" & lblPledgeeClientID.Text & "','" & txtPledgeeSurname.Text & "','" & txtPledgeeforenames.Text & "','" & txtPledgeeAdd_1.Text & "','" & txtPledgeeAdd_2.Text & "','" & txtPledgeeAdd_3.Text & "','" & txtPledgeeCity.Text & "','" & txtPledgeeCounutry.Text & "','O','" & Now.Date & "','" & Session("username") & "')", cn)
            cmd = New SqlCommand("insert into Pledges_Recording (PledgeType,PledgeReason,Cds_Number,Surname,Forenames,Company,SecurityType,Quantity,EffectiveDate,ExpiryDate,Pledgee_Type,Pledgee_Cds_number,Pledgee_Surname,Pledgee_Forenames,Pledgeee_Add_1,Pledgee_Add_2,Pledgee_Add_3,Pledgee_City,Pledgee_Country,Pledge_Status,Pledge_Created_on,Pledge_Created_By, Pledge_with_income, Pledge_capital_benefits, release_option) values ('" & PledgeType & "','" & txtPledgeReason.Text.ToString.ToUpper & "','" & lblClientID.Text & "','" & txtaccountname.Text & "','','" & cmbCompany.SelectedItem.Text & "','" & cmbSecType.SelectedItem.Text & "'," & txtQuantity.Text & ",'" & txtEffectiveDate.Text & "','" & txtExpiryDate.Text & "','" & PlegeeType.ToString.ToUpper & "','" & lblPledgeeClientID.Text & "','" & txtPledgeeforenames.Text & "','','" & txtPledgeeAdd_1.Text & "','" & txtPledgeeAdd_2.Text & "','" & txtPledgeeAdd_3.Text & "','" & txtPledgeeCity.Text & "','" & txtPledgeeCounutry.Text & "','O','" & Now.Date & "','" & Session("username") & "', '" + cmb_withincome.Value.ToString + "','" + cmbcapital_benefits.Value.ToString + "','" + cmbreleaseoption.SelectedItem.Text + "')", cn)
            If (cn.State = ConnectionState.Open) Then
                cn.Close()
            End If
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()

            Try
                cmd = New SqlCommand("insert into audit_log ([userid],[date],[time],[name],[activity], [userid_2], [request_id],[Browser],[IP],[Machine],[Broker_id]) values((select id from systemusers where username='" & Session("username") & "' and companycode='" + Session("Brokercode") + "'),'" & Date.Now.Date & "','" & Date.Now.Hour & ":" & Date.Now.Minute & ":" & Date.Now.Second & "','" + Session("username") + "','Captured a New Pledge Request',0,'" + lblClientID.Text + "','" + HttpContext.Current.Request.UserAgent + "','" + HttpContext.Current.Request.UserHostAddress + "','" + HttpContext.Current.Request.UserHostName + "','" + Session("brokercode") + "')", cn)
                If (cn.State = ConnectionState.Open) Then
                    cn.Close()
                End If
                cn.Open()
                cmd.ExecuteNonQuery()
                cn.Close()

            Catch ex As Exception

            End Try
            msgbox("Pledge Record Saved")
            txtcds_number_search.Text = ""
            txtEffectiveDate.Text = ""
            txtExpiryDate.Text = ""
            txtExpiryDate.Text = ""
            txtaccountname.Text = ""
            txtNameSearch.Text = ""
            txtPledgeeAdd_1.Text = ""
            txtPledgeeAdd_2.Text = ""
            txtPledgeeAdd_3.Text = ""
            txtPledgeeCity.Text = ""
            txtPledgeeCounutry.Text = ""
            txtPledgeeforenames.Text = ""
            txtPledgeeNameSearch.Text = ""
            txtPledgeeNoSearch.Text = ""
            txtPledgeepin.Text = ""
            txtPledgeReason.Text = ""
            txtQuantity.Text = ""
            txtpin_no.Text = ""
            lblClientID.Text = ""
            lblPledgeeClientID.Text = ""
            lstNameSearch.Items.Clear()
            lstPledgeeSearch.Items.Clear()
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub ASPxButton6_Click(sender As Object, e As EventArgs) Handles ASPxButton6.Click
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select distinct cds_number+' '+surname+' '+forenames as namess from Accounts_clients where surname like '" & txtNameSearch.Text & "%'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "Accounts_clients")
            If (ds.Tables(0).Rows.Count > 0) Then
                lstNameSearch.DataSource = ds.Tables(0)
                lstNameSearch.TextField = "namess"
                lstNameSearch.ValueField = "namess"
                lstNameSearch.DataBind()
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub GetSec_Types()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select distinct (seccode) as seccode from sec_types ", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "sec_types")
            If (ds.Tables(0).Rows.Count > 0) Then
                cmbSecType.DataSource = ds.Tables(0)
                cmbSecType.TextField = "seccode"
                cmbSecType.ValueField = "seccode"
                cmbSecType.DataBind()
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub GetCompanies()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select distinct (company) from trans", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "trans")
            If (ds.Tables(0).Rows.Count > 0) Then
                cmbCompany.DataSource = ds.Tables(0)
                cmbCompany.TextField = "company"
                cmbCompany.ValueField = "company"
                cmbCompany.DataBind()
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub lstNameSearch_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstNameSearch.SelectedIndexChanged
        Try
            'If (lstNameSearch.SelectedIndex.ToString > 1) Then
            Dim ds As New DataSet
            cmd = New SqlCommand("select * from Accounts_Clients where cds_number+' '+surname+' '+forenames ='" & lstNameSearch.SelectedItem.Text & "'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "Accounts_Clients")
            If (ds.Tables(0).Rows.Count > 0) Then
                lblClientID.Text = ds.Tables(0).Rows(0).Item("cds_number").ToString
                txtpin_no.Text = ds.Tables(0).Rows(0).Item("cds_number").ToString
                txtaccountname.Text = "" + ds.Tables(0).Rows(0).Item("surname").ToString + " " + ds.Tables(0).Rows(0).Item("forenames").ToString + ""
            Else
                lblClientID.Text = ""
                txtpin_no.Text = ""
                txtaccountname.Text = ""
            End If
            'End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub ASPxButton2_Click(sender As Object, e As EventArgs) Handles ASPxButton2.Click
        Try
            Dim ds As New DataSet '
            cmd = New SqlCommand("select cds_number+' '+surname+' '+forenames as namess from Accounts_Clients where surname like '" & txtPledgeeNameSearch.Text & "%'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "Accounts_Clients")
            If (ds.Tables(0).Rows.Count > 0) Then
                lstPledgeeSearch.DataSource = ds.Tables(0)
                lstPledgeeSearch.TextField = "namess"
                lstPledgeeSearch.ValueField = "namess"
                lstPledgeeSearch.DataBind()
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub lstPledgeeSearch_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstPledgeeSearch.SelectedIndexChanged
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select * from Accounts_Clients where cds_number+' '+surname+' '+forenames = '" & lstPledgeeSearch.SelectedItem.Text & "'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "Accounts_Clients")
            If (ds.Tables(0).Rows.Count > 0) Then
                lblPledgeeClientID.Text = ds.Tables(0).Rows(0).Item("cds_number").ToString
                txtPledgeepin.Text = ds.Tables(0).Rows(0).Item("cds_number").ToString
                txtPledgeeforenames.Text = "" + ds.Tables(0).Rows(0).Item("forenames").ToString + " " + ds.Tables(0).Rows(0).Item("surname").ToString + ""
                txtPledgeeAdd_1.Text = ds.Tables(0).Rows(0).Item("add_1").ToString
                txtPledgeeAdd_2.Text = ds.Tables(0).Rows(0).Item("add_2").ToString
                txtPledgeeAdd_3.Text = ds.Tables(0).Rows(0).Item("add_3").ToString
                txtPledgeeCity.Text = ds.Tables(0).Rows(0).Item("city").ToString
                txtPledgeeCounutry.Text = ds.Tables(0).Rows(0).Item("country").ToString
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub ASPxButton5_Click(sender As Object, e As EventArgs) Handles ASPxButton5.Click
        Try
            Dim dscds As New DataSet
            cmd = New SqlCommand("select distinct cds_number+' '+surname+' '+forenames as namess from Accounts_clients where CDS_Number like '" & txtcds_number_search.Text & "%'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(dscds, "Accounts_clients1")
            If (dscds.Tables(0).Rows.Count > 0) Then
                lstNameSearch.DataSource = dscds.Tables(0)
                lstNameSearch.TextField = "namess"
                lstNameSearch.ValueField = "namess"
                lstNameSearch.DataBind()
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub ASPxButton1_Click(sender As Object, e As EventArgs) Handles ASPxButton1.Click
        Try
            Dim dscdsno As New DataSet '
            cmd = New SqlCommand("select cds_number+' '+surname+' '+forenames as namess from Accounts_Clients where cds_number like '" & txtPledgeeNoSearch.Text & "%'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(dscdsno, "Accounts_Clients3")
            If (dscdsno.Tables(0).Rows.Count > 0) Then
                lstPledgeeSearch.DataSource = dscdsno.Tables(0)
                lstPledgeeSearch.TextField = "namess"
                lstPledgeeSearch.ValueField = "namess"
                lstPledgeeSearch.DataBind()
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub cmb_withincome_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmb_withincome.SelectedIndexChanged

    End Sub

    Protected Sub rdnonAccountHolder_CheckedChanged(sender As Object, e As EventArgs) Handles rdnonAccountHolder.CheckedChanged
        Response.Redirect("~/TransferSec/AccountsCreations.aspx")
    End Sub
End Class
