Partial Class Enquiries_StaticDetailsEnquiry
    Inherits System.Web.UI.Page
    Dim constr As String = (System.Configuration.ConfigurationManager.AppSettings("connpath"))
    Dim cn As New SqlConnection(constr)
    Dim adp As SqlDataAdapter
    Dim cmd As SqlCommand
    Public industry1 As String

    Public Sub msgbox(ByVal strMessage As String)

        'finishes server processing, returns to client.
        Dim strScript As String = "<script language=JavaScript>"
        strScript += "window.alert(""" & strMessage & """);"
        strScript += "</script>"
        Dim lbl As New System.Web.UI.WebControls.Label
        lbl.Text = strScript
        Page.Controls.Add(lbl)

    End Sub
    Public Sub GetPendingAccounts_clientid()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select cds_number+' '+surname+' '+forenames as namess from Accounts_clients where Accountstate='A' and brokercode='" + Session("brokercode") + "' and cds_number like '%" + txtClientNoSe.Text + "%'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "Accounts_Audit")
            If (ds.Tables(0).Rows.Count > 0) Then
                cmbPendingAccounts.DataSource = ds.Tables(0)
                cmbPendingAccounts.TextField = "namess"
                cmbPendingAccounts.ValueField = "namess"
                cmbPendingAccounts.DataBind()
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub GetPendingAccounts_clientname()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select cds_number+' '+surname+' '+forenames as namess from Accounts_clients where Accountstate='A' and brokercode='" + Session("brokercode") + "' and surname+' '+middlename+' '+forenames like '%" + txtClientName.Text + "%'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "Accounts_Audit")
            If (ds.Tables(0).Rows.Count > 0) Then
                cmbPendingAccounts.DataSource = ds.Tables(0)
                cmbPendingAccounts.TextField = "namess"
                cmbPendingAccounts.ValueField = "namess"
                cmbPendingAccounts.DataBind()
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
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
                ' GetPendingAccounts()
            End If
            If Session("finish_n") = "yes" Then
                Session("finish_n") = ""
                msgbox("New Account Submitted for Aprroval")
            End If

            If Session("finish_u") = "yes" Then
                Session("finish_u") = ""
                msgbox("Account Update Submitted for Aprroval")
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Protected Sub rdIndividual_CheckedChanged(sender As Object, e As EventArgs) Handles rdIndividual.CheckedChanged
        Try
            If (rdIndividual.Checked = True) Then
                txtJforenames.Visible = False
                txtJsurname.Visible = False
                lblJforenames.Visible = False
                lblJSurname.Visible = False
                btnJadd.Visible = False
                grdJointAccounts.Visible = False
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Protected Sub rdJoint_CheckedChanged(sender As Object, e As EventArgs) Handles rdJoint.CheckedChanged
        Try
            If (rdJoint.Checked = True) Then
                txtJforenames.Visible = True
                txtJsurname.Visible = True
                lblJforenames.Visible = True
                lblJSurname.Visible = True
                btnJadd.Visible = True
                grdJointAccounts.Visible = True
            Else
                txtJforenames.Visible = False
                txtJsurname.Visible = False
                lblJforenames.Visible = False
                lblJSurname.Visible = False
                btnJadd.Visible = False
                grdJointAccounts.Visible = False
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Protected Sub rdJoint0_CheckedChanged(sender As Object, e As EventArgs) Handles rdCorprate.CheckedChanged
        Try
            If rdCorprate.Checked = True Then
                txtJforenames.Visible = False
                txtJsurname.Visible = False
                lblJforenames.Visible = False
                lblJSurname.Visible = False
                btnJadd.Visible = False
                grdJointAccounts.Visible = False
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Protected Sub rdBroker_CheckedChanged(sender As Object, e As EventArgs) Handles rdBroker.CheckedChanged
        If (rdBroker.Checked = True) Then
            txtJforenames.Visible = False
            txtJsurname.Visible = False
            lblJforenames.Visible = False
            lblJSurname.Visible = False
            btnJadd.Visible = False
            grdJointAccounts.Visible = False
        End If
    End Sub
    Protected Sub cmbPendingAccounts_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbPendingAccounts.SelectedIndexChanged
        getAccountDetails()
        If rdJoint.Checked = True Then
            grdJointAccounts.DataSource = Nothing
            grdJointAccounts.DataBind()
            getjoint()
            Panel8.Visible = False
        ElseIf rdBroker.Checked = True Then
            grdJointAccounts.DataSource = Nothing
            grdJointAccounts.DataBind()
            Panel8.Visible = False
            getjoint()


        ElseIf rdCorprate.Checked = True Then
            grdJointAccounts.DataSource = Nothing
            grdJointAccounts.DataBind()
            Panel8.Visible = False
              getjoint()
        Else
            Panel8.Visible = True
            grdJointAccounts.DataSource = Nothing
            grdJointAccounts.DataBind()
            grdJointAccounts.Visible = False

        End If
    End Sub
    Public Sub getjoint()

        Dim dsi As New DataSet
        cmd = New SqlCommand("select id as ID, Surname+' '+Forenames as Names, IDNo as [ID Number], IDTYPE AS [ID Type], Nationality, DateofBirth as [DOB],Gender from Accounts_Joint where CDSNo=(select TOP 1 cds_number from Accounts_audit where cds_number+' '+surname+' '+forenames='" & cmbPendingAccounts.SelectedItem.Text & "')", cn)
        adp = New SqlDataAdapter(cmd)

        adp.Fill(dsi, "para_cust1")
        If (dsi.Tables(0).Rows.Count > 0) Then
            grdJointAccounts.DataSource = dsi
            grdJointAccounts.DataBind()
            grdJointAccounts.Visible = True
        End If


    End Sub
    Public Sub getcorp()
        Dim dsi2 As New DataSet
        cmd = New SqlCommand("select id as ID, Surname+' '+forenames+' '+Middlename as Names, idnopp as [ID Number], idtype as [ID Type], Nationality, DOB, Gender from Accounts_audit where CDS_Number=(select TOP 1 cds_number from Accounts_audit where cds_number+' '+surname+' '+forenames='" & cmbPendingAccounts.SelectedItem.Text & "')", cn)
        adp = New SqlDataAdapter(cmd)

        adp.Fill(dsi2, "para_cust2")
        If (dsi2.Tables(0).Rows.Count > 0) Then
            grdJointAccounts.DataSource = dsi2
            grdJointAccounts.DataBind()
            grdJointAccounts.Visible = True

        End If
    End Sub
    Public Sub getAccountDetails()
        Try
            lblSurname.Text = ""
            lblForenames.Text = ""
            lblMiddlename.Text = ""
            lblIdNo.Text = ""
            lblIdtype.Text = ""
            lblInitials.Text = ""
            lblTitle.Text = ""
            lblNationality.Text = ""
            lblDob.Text = ""
            lblAdd1.Text = ""
            lblAdd2.Text = ""
            lblAdd3.Text = ""
            lblAdd4.Text = ""
            lblCountry.Text = ""
            lblCity.Text = ""
            txtJsurname.Text = ""
            lblJSurname.Visible = False
            txtJsurname.Visible = False
            lblJSurname.Text = "Surname"

            Dim ds As New DataSet
            cmd = New SqlCommand("select * from Accounts_clients where cds_number+' '+surname+' '+forenames='" & cmbPendingAccounts.SelectedItem.Text & "'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "Accounts_Audit")
            If (ds.Tables(0).Rows.Count > 0) Then
                'If (ds.Tables(0).Rows(0).Item("Update_Type").ToString = "NEW") Then
                '    lblUpdateType.Text = "NEW"
                '    TXTClientID.Text = ""
                'Else
                '    lblUpdateType.Text = "UPDATE"
                '    TXTClientID.Text = ds.Tables(0).Rows(0).Item("cds_number").ToString
                'End If

                txtSurname.Text = ds.Tables(0).Rows(0).Item("surname").ToString
                txtMiddlename.Text = ds.Tables(0).Rows(0).Item("Middlename").ToString
                txtOtherNames.Text = ds.Tables(0).Rows(0).Item("Forenames").ToString
                txtInitials.Text = ds.Tables(0).Rows(0).Item("Initials").ToString
                txtIDNo.Text = ds.Tables(0).Rows(0).Item("IDNoPP").ToString
                TXTClientID.Text = ds.Tables(0).Rows(0).Item("cds_number").ToString
                txtDOB.Text = FormatDateTime(ds.Tables(0).Rows(0).Item("DOB").ToString, DateFormat.longdate)

                getuploaded()



                If (ds.Tables(0).Rows(0).Item("GENDER").ToString = "M") Then
                    rdMale.Checked = True
                    rdFemale.Checked = False
                    rdNa.Checked = False
                End If
                If (ds.Tables(0).Rows(0).Item("GENDER").ToString = "F") Then
                    rdMale.Checked = False
                    rdFemale.Checked = True
                    rdNa.Checked = False
                End If
                If (ds.Tables(0).Rows(0).Item("GENDER").ToString = "N") Then
                    rdMale.Checked = False
                    rdFemale.Checked = False
                    rdNa.Checked = True
                End If
                If (ds.Tables(0).Rows(0).Item("AccountType").ToString = "I") Then
                    rdIndividual.Checked = True
                    rdJoint.Checked = False
                    rdCorprate.Checked = False
                    rdBroker.Checked = False
                End If
                If (ds.Tables(0).Rows(0).Item("AccountType").ToString = "J") Then
                    rdIndividual.Checked = False
                    rdJoint.Checked = True
                    rdCorprate.Checked = False
                    rdBroker.Checked = False
                    txtJsurname.Text = ds.Tables(0).Rows(0).Item("Surname").ToString
                    lblJSurname.Visible = True
                    txtJsurname.Visible = True
                    lblJSurname.Text = "Account Name"
                End If
                If (ds.Tables(0).Rows(0).Item("AccountType").ToString = "C") Then
                    rdIndividual.Checked = False
                    rdJoint.Checked = True
                    rdCorprate.Checked = True
                    rdBroker.Checked = False
                    txtJsurname.Text = ds.Tables(0).Rows(0).Item("Surname").ToString
                    lblJSurname.Visible = True
                    txtJsurname.Visible = True
                    lblJSurname.Text = "Account Name"
                End If
                If (ds.Tables(0).Rows(0).Item("AccountType").ToString = "B") Then
                    rdIndividual.Checked = False
                    rdJoint.Checked = False
                    rdCorprate.Checked = False
                    rdBroker.Checked = True
                    txtJsurname.Text = ds.Tables(0).Rows(0).Item("Surname").ToString
                    lblJSurname.Visible = True
                    txtJsurname.Visible = True
                    lblJSurname.Text = "Broker Name"
                End If
                txtAdd1.Text = ds.Tables(0).Rows(0).Item("Add_1").ToString
                txtAdd2.Text = ds.Tables(0).Rows(0).Item("Add_2").ToString
                txtAdd3.Text = ds.Tables(0).Rows(0).Item("Add_3").ToString
                txtAdd4.Text = ds.Tables(0).Rows(0).Item("Add_4").ToString
                txtMobile.Text = ds.Tables(0).Rows(0).Item("Mobile").ToString
                txtTel.Text = ds.Tables(0).Rows(0).Item("Tel").ToString
                'txtDOB.Text = ds.Tables(0).Rows(0).Item("DOB").ToString
                If (ds.Tables(0).Rows(0).Item("Category").ToString = "C") Then
                    rdControlled.Checked = True
                    rdNonControlled.Checked = False
                Else
                    rdNonControlled.Checked = True
                    rdControlled.Checked = False

                End If
                If (ds.Tables(0).Rows(0).Item("TradingStatus").ToString = "Trading") Then
                    rdTrading.Checked = True
                    rdNonTrading.Checked = False
                Else
                    rdNonTrading.Checked = True
                    rdTrading.Checked = False
                End If

                txtNationality.Text = ds.Tables(0).Rows(0).Item("Nationality").ToString
                txtcust.Text = ds.Tables(0).Rows(0).Item("Custodian").ToString
                txtCountry.Text = ds.Tables(0).Rows(0).Item("Country").ToString
                txtCity.Text = ds.Tables(0).Rows(0).Item("City").ToString
                industry1 = ds.Tables(0).Rows(0).Item("Industry").ToString
                getindustryfull()
                txtTax.Text = ds.Tables(0).Rows(0).Item("tax").ToString
                txtTitle.Text = ds.Tables(0).Rows(0).Item("title").ToString
                txtIDType.Text = ds.Tables(0).Rows(0).Item("IDtype").ToString
                txtBankName.Text = ds.Tables(0).Rows(0).Item("div_bank").ToString
                txtBranch.Text = ds.Tables(0).Rows(0).Item("div_branch").ToString
                txtAccountNo.Text = ds.Tables(0).Rows(0).Item("div_AccountNo").ToString
                txtCashAccount.Text = ds.Tables(0).Rows(0).Item("Cash_AccountNo").ToString
                txtCashBank.Text = ds.Tables(0).Rows(0).Item("Cash_Bank").ToString
                txtCashBrach.Text = ds.Tables(0).Rows(0).Item("Cash_Branch").ToString
                txtEmail.Text = ds.Tables(0).Rows(0).Item("email").ToString.tolower
                txtPayee1.Text = ds.Tables(0).Rows(0).Item("SettlementPayee").ToString
                txtPayee2.Text = ds.Tables(0).Rows(0).Item("DivPayee").ToString

                Try
                    cmd = New SqlCommand("insert into audit_log ([userid],[date],[time],[name],[activity], [userid_2], [request_id],[Browser],[IP],[Machine],[Broker_id]) values((select id from systemusers where username='" & Session("username") & "' and companycode='" + Session("Brokercode") + "'),'" & Date.Now.Date & "','" & Date.Now.Hour & ":" & Date.Now.Minute & ":" & Date.Now.Second & "','" + Session("username") + "','Enquired about a shareholder',0,'" + TXTClientID.Text + "','" + HttpContext.Current.Request.UserAgent + "','" + HttpContext.Current.Request.UserHostAddress + "','" + HttpContext.Current.Request.UserHostName + "','" + Session("brokercode") + "')", cn)
                    If (cn.State = ConnectionState.Open) Then
                        cn.Close()
                    End If
                    cn.Open()
                    cmd.ExecuteNonQuery()
                    cn.Close()

                Catch ex As Exception

                End Try
                '   cmbCustodian.SelectedItem.Text = ds.Tables(0).Rows(0).Item("custodian").ToString

                ' If (lblUpdateType.Text = "UPDATE") Then
                'Dim rod As New DataSet
                'cmd = New SqlCommand("select * from Accounts_Clients where cds_number = '" & Trim(TXTClientID.Text) & "'", cn)
                'adp = New SqlDataAdapter(cmd)
                'adp.Fill(rod, "Accounts_Clients")
                'If (rod.Tables(0).Rows.Count > 0) Then
                '    If (ds.Tables(0).Rows(0).Item("surname").ToString <> rod.Tables(0).Rows(0).Item("surname").ToString) Then
                '        lblSurname.Text = rod.Tables(0).Rows(0).Item("surname").ToString
                '        lblSurname.ForeColor = Drawing.Color.Red
                '    End If
                '    If (ds.Tables(0).Rows(0).Item("forenames").ToString <> rod.Tables(0).Rows(0).Item("forenames").ToString) Then
                '        lblForenames.Text = rod.Tables(0).Rows(0).Item("forenames").ToString
                '        lblForenames.ForeColor = Drawing.Color.Red
                '    End If
                '    If (ds.Tables(0).Rows(0).Item("initials").ToString <> rod.Tables(0).Rows(0).Item("initials").ToString) Then
                '        lblInitials.Text = rod.Tables(0).Rows(0).Item("initials").ToString
                '        lblInitials.ForeColor = Drawing.Color.Red
                '    End If
                '    If (ds.Tables(0).Rows(0).Item("idnopp").ToString <> rod.Tables(0).Rows(0).Item("idnopp").ToString) Then
                '        lblIdNo.Text = rod.Tables(0).Rows(0).Item("idnopp").ToString
                '        lblIdNo.ForeColor = Drawing.Color.Red
                '    End If
                '    If (ds.Tables(0).Rows(0).Item("nationality").ToString <> rod.Tables(0).Rows(0).Item("nationality").ToString) Then
                '        lblNationality.Text = rod.Tables(0).Rows(0).Item("nationality").ToString
                '        lblNationality.ForeColor = Drawing.Color.Red
                '    End If
                '    If (ds.Tables(0).Rows(0).Item("add_1").ToString <> rod.Tables(0).Rows(0).Item("add_1").ToString) Then
                '        lblAdd1.Text = rod.Tables(0).Rows(0).Item("add_1").ToString
                '        lblAdd1.ForeColor = Drawing.Color.Red
                '    End If
                '    If (ds.Tables(0).Rows(0).Item("add_2").ToString <> rod.Tables(0).Rows(0).Item("add_2").ToString) Then
                '        lblAdd2.Text = rod.Tables(0).Rows(0).Item("add_2").ToString
                '        lblAdd2.ForeColor = Drawing.Color.Red
                '    End If
                '    If (ds.Tables(0).Rows(0).Item("add_3").ToString <> rod.Tables(0).Rows(0).Item("add_3").ToString) Then
                '        lblAdd3.Text = rod.Tables(0).Rows(0).Item("add_3").ToString
                '        lblAdd3.ForeColor = Drawing.Color.Red
                '    End If
                '    If (ds.Tables(0).Rows(0).Item("add_4").ToString <> rod.Tables(0).Rows(0).Item("add_4").ToString) Then
                '        lblAdd4.Text = rod.Tables(0).Rows(0).Item("add_4").ToString
                '        lblAdd4.ForeColor = Drawing.Color.Red
                '    End If
                '    If (ds.Tables(0).Rows(0).Item("tel").ToString <> rod.Tables(0).Rows(0).Item("tel").ToString) Then
                '        lblTel.Text = rod.Tables(0).Rows(0).Item("tel").ToString
                '        lblTel.ForeColor = Drawing.Color.Red
                '    End If
                '    If (ds.Tables(0).Rows(0).Item("mobile").ToString <> rod.Tables(0).Rows(0).Item("mobile").ToString) Then
                '        lblMobile.Text = rod.Tables(0).Rows(0).Item("mobile").ToString
                '        lblMobile.ForeColor = Drawing.Color.Red
                '    End If
                'If (ds.Tables(0).Rows(0).Item("").ToString <> rod.Tables(0).Rows(0).Item("").ToString) Then

                'End If
                'If (ds.Tables(0).Rows(0).Item("").ToString <> rod.Tables(0).Rows(0).Item("").ToString) Then

                'End If
                'If (ds.Tables(0).Rows(0).Item("").ToString <> rod.Tables(0).Rows(0).Item("").ToString) Then

                'End If
                'Else
                lblSurname.Text = ""
                lblForenames.Text = ""
                lblMiddlename.Text = ""
                lblIdNo.Text = ""
                lblIdtype.Text = ""
                lblInitials.Text = ""
                lblTitle.Text = ""
                lblNationality.Text = ""
                lblDob.Text = ""
                lblAdd1.Text = ""
                lblAdd2.Text = ""
                lblAdd3.Text = ""
                lblAdd4.Text = ""
                lblCountry.Text = ""
                lblCity.Text = ""

                '  End If


            End If

        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Protected Sub rdReject_CheckedChanged(sender As Object, e As EventArgs) Handles rdReject.CheckedChanged
        Try
            If (rdReject.Checked = True) Then
                lblRejection.Visible = True
                txtReasons.Visible = True
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Protected Sub rdApprove_CheckedChanged(sender As Object, e As EventArgs) Handles rdApprove.CheckedChanged
        Try
            If (rdApprove.Checked = True) Then
                lblRejection.Visible = False
                txtReasons.Visible = False
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
   
    Public Sub UpdateAccount()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select * from Accounts_Audit where CDS_Number+' '+surname+' '+forenames='" & cmbPendingAccounts.SelectedItem.Text & "' and Update_Type='UPDATE' order by Date_Created desc", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "Accounts_Audit")
            If (ds.Tables(0).Rows.Count > 0) Then

                If (ds.Tables(0).Rows(0).Item("VerificationCode").ToString = txtVerificationCode.Text) Then
                Else
                    msgbox("Invalid Verification Code")
                    Exit Sub
                End If

                'cmd = New SqlCommand("Update Accounts_Clients set broker_code='" & ds.Tables(0).Rows(0).Item("BrokerCode").ToString.ToString.ToUpper & "',AccountType='" & ds.Tables(0).Rows(0).Item("AccountType").ToString.ToString.ToUpper & "',surname='" & ds.Tables(0).Rows(0).Item("surname").ToString.ToString.ToUpper & "',middlename='" & ds.Tables(0).Rows(0).Item("middlename").ToString.ToString.ToUpper & "',forenames='" & ds.Tables(0).Rows(0).Item("forenames").ToString.ToString.ToUpper & "',initials='" & ds.Tables(0).Rows(0).Item("initials").ToString.ToString.ToUpper & "','" & ds.Tables(0).Rows(0).Item("title").ToString.ToString.ToUpper & "',idnopp='" & ds.Tables(0).Rows(0).Item("idnopp").ToString.ToString.ToUpper & "',idtype='" & ds.Tables(0).Rows(0).Item("idtype").ToString.ToString.ToUpper & "',nationality='" & ds.Tables(0).Rows(0).Item("nationality").ToString.ToString.ToUpper & "',DOB='" & ds.Tables(0).Rows(0).Item("DOB").ToString.ToString.ToUpper & "',GENDER='" & ds.Tables(0).Rows(0).Item("gender").ToString.ToString.ToUpper & "',add_1='" & ds.Tables(0).Rows(0).Item("add_1").ToString.ToString.ToUpper & "',add_2='" & ds.Tables(0).Rows(0).Item("add_2").ToString.ToString.ToUpper & "',add_3='" & ds.Tables(0).Rows(0).Item("add_3").ToString.ToString.ToUpper & "',add_4='" & ds.Tables(0).Rows(0).Item("add_4").ToString.ToString.ToUpper & "',country='" & ds.Tables(0).Rows(0).Item("country").ToString.ToString.ToUpper & "',city='" & ds.Tables(0).Rows(0).Item("city").ToString.ToString.ToUpper & "',tel='" & ds.Tables(0).Rows(0).Item("tel").ToString.ToString.ToUpper & "',mobile='" & ds.Tables(0).Rows(0).Item("mobile").ToString.ToString.ToUpper & "',email='" & ds.Tables(0).Rows(0).Item("email").ToString.ToString.ToUpper & "',Category='" & ds.Tables(0).Rows(0).Item("Category").ToString.ToString.ToUpper & "',Custodian='" & ds.Tables(0).Rows(0).Item("Custodian").ToString.ToString.ToUpper & "',TradingStatus='" & ds.Tables(0).Rows(0).Item("TradingStatus").ToString.ToString.ToUpper & "',Industry='" & ds.Tables(0).Rows(0).Item("Industry").ToString.ToString.ToUpper & "',Tax='" & ds.Tables(0).Rows(0).Item("tax").ToString.ToString.ToUpper & "',Div_Bank='" & ds.Tables(0).Rows(0).Item("Div_Bank").ToString.ToString.ToUpper & "',Div_branch='" & ds.Tables(0).Rows(0).Item("Div_branch").ToString.ToString.ToUpper & "',Div_AccountNo='" & ds.Tables(0).Rows(0).Item("Div_AccountNo").ToString.ToString.ToUpper & "',Cash_bank='" & ds.Tables(0).Rows(0).Item("Cash_Bank").ToString.ToString.ToUpper & "',Cash_Branch='" & ds.Tables(0).Rows(0).Item("Cash_Branch").ToString.ToString.ToUpper & "',Cash_Account='" & ds.Tables(0).Rows(0).Item("Cash_Accounts").ToString.ToString.ToUpper & "',Client_Image='" & ds.Tables(0).Rows(0).Item("Client_Image").ToString.ToString.ToUpper & "',Documents='" & ds.Tables(0).Rows(0).Item("Documents").ToString.ToString.ToUpper & "',BioMatrix='" & ds.Tables(0).Rows(0).Item("BioMatrix").ToString.ToString.ToUpper & "',Attached_Documents='" & ds.Tables(0).Rows(0).Item("Attached_Documents").ToString.ToString.ToUpper & "',Date_Created='" & ds.Tables(0).Rows(0).Item("Date_Created").ToString.ToString.ToUpper & "',Update_Type='UPDATE','" & Session("Username") & "',AccountState ='A' WHERE cds_number='" & ds.Tables(0).Rows(0).Item("cds_number").ToString & "'", cn)
                'If (cn.State = ConnectionState.Open) Then
                'cn.Close()
                'End If
                'cn.Open()
                'cmd.ExecuteNonQuery()
                'cn.Close()

                'cmd = New SqlCommand("Update Accounts_Audit set AuthorizationState='C' where cds_number+' '+surname+' '+forenames='" & cmbPendingAccounts.SelectedItem.Text & "'", cn)
                cmd = New SqlCommand("Update Accounts_Audit set AuthorizationState='A' where id=" & ds.Tables(0).Rows(0).Item("id").ToString & "", cn)
                If (cn.State = ConnectionState.Open) Then
                    cn.Close()
                End If
                cn.Open()
                cmd.ExecuteNonQuery()
                cn.Close()

                '      msgbox("Account Submited for approval")
                txtAdd1.Text = ""
                txtAdd2.Text = ""
                txtAdd3.Text = ""
                txtAdd4.Text = ""
                txtCity.Text = ""
                TXTClientID.Text = ""
                txtAccountNo.Text = ""
                txtCountry.Text = ""
                txtDOB.Text = ""
                txtIDNo.Text = ""
                txtInitials.Text = ""
                txtJforenames.Text = ""
                txtMiddlename.Text = ""
                txtMobile.Text = ""
                txtNationality.Text = ""
                txtOtherNames.Text = ""
                txtReasons.Text = ""
                txtSurname.Text = ""
                txtTel.Text = ""
                '  GetPendingAccounts()

                Session("finish_u") = "yes"
                Response.Redirect(Request.RawUrl)
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub SaveNewAccount()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select * from Accounts_Audit where CDS_Number+' '+surname+' '+forenames='" & cmbPendingAccounts.SelectedItem.Text & "'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "Accounts_Audit")
            If (ds.Tables(0).Rows.Count > 0) Then
                'Dim cdsNo As String = ""
                'Dim dsi As New DataSet
                'cmd = New SqlCommand("select * from Accounts_Clients", cn)
                'adp = New SqlDataAdapter(cmd)
                'adp.Fill(dsi, "Accounts_Clients")
                'If (dsi.Tables(0).Rows.Count > 0) Then
                '    Dim ros As New DataSet
                '    cmd = New SqlCommand("select max(id) as id from Accounts_Clients", cn)
                '    adp = New SqlDataAdapter(cmd)
                '    adp.Fill(ros, "Accounts_Clients")
                '    cdsNo = Session("BrokerCode") & (CInt(ros.Tables(0).Rows(0).Item("id").ToString + 1)).ToString.PadLeft(6, "0")
                'Else
                '    cdsNo = Session("BrokerCode") & CInt(1).ToString.PadLeft(6, "0")
                'End If
                ''cmd = New SqlCommand("insert into Accounts_Clients (                                                                                                                                                                                                                                                                                                                                                                                                                   CDS_Number,             BrokerCode,                                                                 AccountType,                                                            Surname,                                                                Middlename,                                                                         Forenames,                                                          Initials,                                                                   Title,                                                                              IDNoPP,                                                         IDtype,                                                                             Nationality,                                                            DOB,                                                                            Gender,                                                                     Add_1,                                                          Add_2,                                                          Add_3,                                                                          Add_4,                                                                  Country,                                                City,                                                                   Tel,                                                            Mobile,                                                                         Email,                                                      Category,                                                                   Custodian,                                                              TradingStatus,                                                                      Industry,                                                               Tax,                                                            Div_Bank,                                                                                       Div_Branch,                                                     Div_AccountNo,                                                              Cash_Bank,                                                              Cash_Branch,                                                                Cash_AccountNo,                                                                 Client_Image,                                                               Documents,BioMatrix,Attached_Documents,Date_Created,Update_Type,Created_By,AccountState,Comments) values ('" & cdsNo & "','" & ds.Tables(0).Rows(0).Item("BrokerCode").ToString.ToString.ToUpper & "','" & ds.Tables(0).Rows(0).Item("AccountType").ToString.ToString.ToUpper & "','" & ds.Tables(0).Rows(0).Item("AccountType").ToString.ToString.ToUpper & "','" & ds.Tables(0).Rows(0).Item("surname").ToString.ToString.ToUpper & "','" & ds.Tables(0).Rows(0).Item("Middlename").ToString.ToString.ToUpper & "','" & ds.Tables(0).Rows(0).Item("Forenames").ToString.ToString.ToUpper & "','" & ds.Tables(0).Rows(0).Item("Initials").ToString.ToString.ToUpper & "','" & ds.Tables(0).Rows(0).Item("title").ToString.ToString.ToUpper & "','" & ds.Tables(0).Rows(0).Item("IDNoPP").ToString.ToString.ToUpper & "','" & ds.Tables(0).Rows(0).Item("IDtype").ToString.ToString.ToUpper & "','" & ds.Tables(0).Rows(0).Item("Nationality").ToString.ToString.ToUpper & "','" & ds.Tables(0).Rows(0).Item("DOB").ToString.ToString.ToUpper & "','" & ds.Tables(0).Rows(0).Item("Gender").ToString.ToString.ToUpper & "','" & ds.Tables(0).Rows(0).Item("Add_1").ToString.ToString.ToUpper & "','" & ds.Tables(0).Rows(0).Item("Add_2").ToString.ToString.ToUpper & "','" & ds.Tables(0).Rows(0).Item("Add_3").ToString.ToString.ToUpper & "','" & ds.Tables(0).Rows(0).Item("Add_4").ToString.ToString.ToUpper & "','" & ds.Tables(0).Rows(0).Item("Country").ToString.ToString.ToUpper & "','" & ds.Tables(0).Rows(0).Item("City").ToString.ToString.ToUpper & "','" & ds.Tables(0).Rows(0).Item("Tel").ToString.ToString.ToUpper & "','" & ds.Tables(0).Rows(0).Item("Mobile").ToString.ToString.ToUpper & "','" & ds.Tables(0).Rows(0).Item("Email").ToString.ToString.ToUpper & "','" & ds.Tables(0).Rows(0).Item("Category").ToString.ToString.ToUpper & "','" & ds.Tables(0).Rows(0).Item("Custodian").ToString.ToString.ToUpper & "','" & ds.Tables(0).Rows(0).Item("TradingStatus").ToString.ToString.ToUpper & "','" & ds.Tables(0).Rows(0).Item("Industry").ToString.ToString.ToUpper & "','" & ds.Tables(0).Rows(0).Item("Tax").ToString.ToString.ToUpper & "','" & ds.Tables(0).Rows(0).Item("Div_Bank").ToString.ToString.ToUpper & "','" & ds.Tables(0).Rows(0).Item("Div_Branch").ToString.ToString.ToUpper & "','" & ds.Tables(0).Rows(0).Item("Div_AccountNo").ToString.ToString.ToUpper & "','" & ds.Tables(0).Rows(0).Item("Cash_Bank").ToString.ToString.ToUpper & "','" & ds.Tables(0).Rows(0).Item("Cash_Branch").ToString.ToString.ToUpper & "','" & ds.Tables(0).Rows(0).Item("Cash_AccountNo").ToString.ToString.ToUpper & "','" & ds.Tables(0).Rows(0).Item("Client_Image").ToString.ToString.ToUpper & "','" & ds.Tables(0).Rows(0).Item("Documents").ToString.ToString.ToUpper & "','" & ds.Tables(0).Rows(0).Item("BioMatrix").ToString.ToString.ToUpper & "','" & ds.Tables(0).Rows(0).Item("Attached_Documents").ToString.ToString.ToUpper & "','" & Now.Date & "','NEW','" & Session("USERNAME") & "','A','')", cn)
                'cmd = New SqlCommand("insert into Accounts_Clients (CDS_Number,BrokerCode,AccountType,Surname,Middlename,Forenames,Initials,Title,IDNoPP,IDtype,Nationality,DOB,Gender,Add_1,Add_2,Add_3,Add_4,Country,City,Tel,Mobile,Email,Category,Custodian,TradingStatus,Industry,Tax,Div_Bank,Div_Branch,Div_AccountNo,Cash_Bank,Cash_Branch,Cash_AccountNo,Client_Image,Documents,BioMatrix,Attached_Documents,Date_Created,Update_Type,Created_By,AccountState,Comments) values ('" & cdsNo & "','" & ds.Tables(0).Rows(0).Item("BrokerCode").ToString.ToString.ToUpper & "','" & ds.Tables(0).Rows(0).Item("AccountType").ToString.ToString.ToUpper & "','" & ds.Tables(0).Rows(0).Item("surname").ToString.ToString.ToUpper & "','" & ds.Tables(0).Rows(0).Item("Middlename").ToString.ToString.ToUpper & "','" & ds.Tables(0).Rows(0).Item("Forenames").ToString.ToString.ToUpper & "','" & ds.Tables(0).Rows(0).Item("Initials").ToString.ToString.ToUpper & "','" & ds.Tables(0).Rows(0).Item("title").ToString.ToString.ToUpper & "','" & ds.Tables(0).Rows(0).Item("IDNoPP").ToString.ToString.ToUpper & "','" & ds.Tables(0).Rows(0).Item("IDtype").ToString.ToString.ToUpper & "','" & ds.Tables(0).Rows(0).Item("Nationality").ToString.ToString.ToUpper & "','" & ds.Tables(0).Rows(0).Item("DOB").ToString.ToString.ToUpper & "','" & ds.Tables(0).Rows(0).Item("Gender").ToString.ToString.ToUpper & "','" & ds.Tables(0).Rows(0).Item("Add_1").ToString.ToString.ToUpper & "','" & ds.Tables(0).Rows(0).Item("Add_2").ToString.ToString.ToUpper & "','" & ds.Tables(0).Rows(0).Item("Add_3").ToString.ToString.ToUpper & "','" & ds.Tables(0).Rows(0).Item("Add_4").ToString.ToString.ToUpper & "','" & ds.Tables(0).Rows(0).Item("Country").ToString.ToString.ToUpper & "','" & ds.Tables(0).Rows(0).Item("City").ToString.ToString.ToUpper & "','" & ds.Tables(0).Rows(0).Item("Tel").ToString.ToString.ToUpper & "','" & ds.Tables(0).Rows(0).Item("Mobile").ToString.ToString.ToUpper & "','" & ds.Tables(0).Rows(0).Item("Email").ToString.ToString.ToUpper & "','" & ds.Tables(0).Rows(0).Item("Category").ToString.ToString.ToUpper & "','" & ds.Tables(0).Rows(0).Item("Custodian").ToString.ToString.ToUpper & "','" & ds.Tables(0).Rows(0).Item("TradingStatus").ToString.ToString.ToUpper & "','" & ds.Tables(0).Rows(0).Item("Industry").ToString.ToString.ToUpper & "','" & ds.Tables(0).Rows(0).Item("Tax").ToString.ToString.ToUpper & "','" & ds.Tables(0).Rows(0).Item("Div_Bank").ToString.ToString.ToUpper & "','" & ds.Tables(0).Rows(0).Item("Div_Branch").ToString.ToString.ToUpper & "','" & ds.Tables(0).Rows(0).Item("Div_AccountNo").ToString.ToString.ToUpper & "','" & ds.Tables(0).Rows(0).Item("Cash_Bank").ToString.ToString.ToUpper & "','" & ds.Tables(0).Rows(0).Item("Cash_Branch").ToString.ToString.ToUpper & "','" & ds.Tables(0).Rows(0).Item("Cash_AccountNo").ToString.ToString.ToUpper & "','" & ds.Tables(0).Rows(0).Item("Client_Image").ToString.ToString.ToUpper & "','" & ds.Tables(0).Rows(0).Item("Documents").ToString.ToString.ToUpper & "','" & ds.Tables(0).Rows(0).Item("BioMatrix").ToString.ToString.ToUpper & "','" & ds.Tables(0).Rows(0).Item("Attached_Documents").ToString.ToString.ToUpper & "','" & Now.Date & "','NEW','" & Session("USERNAME") & "','A','')", cn)
                'If (cn.State = ConnectionState.Open) Then
                '    cn.Close()
                'End If
                'cn.Open()
                'cmd.ExecuteNonQuery()
                'cn.Close()

                cmd = New SqlCommand("Update Accounts_Audit set AuthorizationState='A' where cds_number+' '+surname+' '+forenames='" & cmbPendingAccounts.SelectedItem.Text & "'", cn)
                If (cn.State = ConnectionState.Open) Then
                    cn.Close()
                End If
                cn.Open()
                cmd.ExecuteNonQuery()
                cn.Close()

                '    msgbox("New account submitted for approval")
                txtAdd1.Text = ""
                txtAdd2.Text = ""
                txtAdd3.Text = ""
                txtAdd4.Text = ""
                txtCity.Text = ""
                TXTClientID.Text = ""
                txtAccountNo.Text = ""
                txtCountry.Text = ""
                txtDOB.Text = ""
                txtIDNo.Text = ""
                txtInitials.Text = ""
                txtJforenames.Text = ""
                txtMiddlename.Text = ""
                txtMobile.Text = ""
                txtNationality.Text = ""
                txtOtherNames.Text = ""
                txtReasons.Text = ""
                txtSurname.Text = ""
                txtTel.Text = ""
                ' GetPendingAccounts()

                Session("finish_n") = "yes"
                Response.Redirect(Request.RawUrl)

            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub RejectAccount()
        Try
            cmd = New SqlCommand("update Accounts_Audit set AuthorizationState='X',Comments='" & txtReasons.Text & "' where cds_number+' '+surname+' '+forenames='" & cmbPendingAccounts.SelectedItem.Text & "'", cn)
            If (cn.State = ConnectionState.Open) Then
                cn.Close()
            End If
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()
            msgbox("Account Rejected")
            txtAdd1.Text = ""
            txtAdd2.Text = ""
            txtAdd3.Text = ""
            txtAdd4.Text = ""
            txtCity.Text = ""
            TXTClientID.Text = ""
            txtAccountNo.Text = ""
            txtCountry.Text = ""
            txtDOB.Text = ""
            txtIDNo.Text = ""
            txtInitials.Text = ""
            txtJforenames.Text = ""
            txtMiddlename.Text = ""
            txtMobile.Text = ""
            txtNationality.Text = ""
            txtOtherNames.Text = ""
            txtReasons.Text = ""
            txtSurname.Text = ""
            txtTel.Text = ""
            '      GetPendingAccounts()
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub getindustryfull()
        Dim dsi As New DataSet
        cmd = New SqlCommand("select fnam from para_industry where code='" + industry1 + "'", cn)
        adp = New SqlDataAdapter(cmd)

        adp.Fill(dsi, "para_cu")
        If (dsi.Tables(0).Rows.Count > 0) Then
            txtIndustry.Text = dsi.Tables(0).Rows(0).Item("fnam")
        End If
    End Sub

    Protected Sub txtReasons_TextChanged(sender As Object, e As EventArgs) Handles txtReasons.TextChanged

    End Sub

    Protected Sub txtVerificationCode_TextChanged(sender As Object, e As EventArgs) Handles txtVerificationCode.TextChanged

    End Sub

    Protected Sub ASPxButton3_Click(sender As Object, e As EventArgs) Handles ASPxButton3.Click
        If txtClientNoSe.Text <> "" Then
            GetPendingAccounts_clientid()
        Else
            msgbox("Please provide the client number")
        End If

    End Sub

    Protected Sub ASPxButton2_Click(sender As Object, e As EventArgs) Handles ASPxButton2.Click
        If txtClientName.Text <> "" Then
            GetPendingAccounts_clientname()
        Else
            msgbox("Please provide the client name")
        End If

    End Sub

    Protected Sub ASPxButton4_Click(sender As Object, e As EventArgs) Handles ASPxButton4.Click
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select cds_number+' '+surname+' '+forenames as namess from accounts_clients where IDNOPP+' '+COALESCE(IDNOPP2,'') like '%" & txtClientNoSe0.Text & "%' and brokercode='" + Session("brokercode") + "'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "accounts_clients")
            If (ds.Tables(0).Rows.Count > 0) Then
                cmbPendingAccounts.DataSource = ds.Tables(0)
                cmbPendingAccounts.TextField = "namess"
                cmbPendingAccounts.ValueField = "namess"
                cmbPendingAccounts.DataBind()
            End If

        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub pd()
        Dim strQuery As String = "select Name, ContentType, Data from accounts_documents where id='" + grdEvent.SelectedValue.ToString + "'"
        Dim cmd As SqlCommand = New SqlCommand(strQuery)
        cmd.Parameters.Add("@id", SqlDbType.Int).Value = 4
        Dim dt As DataTable = GetData(cmd)
        If dt IsNot Nothing Then
            download(dt)
        End If
    End Sub
    Public Sub word()
        Dim strQuery As String = "select Name, ContentType, Data from accounts_documents where id='" + grdEvent.SelectedValue.ToString + "'"
        Dim cmd As SqlCommand = New SqlCommand(strQuery)
        cmd.Parameters.Add("@id", SqlDbType.Int).Value = 1
        Dim dt As DataTable = GetData(cmd)
        If dt IsNot Nothing Then
            download(dt)
        End If
    End Sub
    Public Sub xls()
        Dim strQuery As String = "select Name, ContentType, Data from accounts_documents where id='" + grdEvent.SelectedValue.ToString + "'"
        Dim cmd As SqlCommand = New SqlCommand(strQuery)
        cmd.Parameters.Add("@id", SqlDbType.Int).Value = 2
        Dim dt As DataTable = GetData(cmd)
        If dt IsNot Nothing Then
            download(dt)
        End If
    End Sub
    Public Sub Img()
        Dim strQuery As String = "select Name, ContentType, Data from accounts_documents where id='" + grdEvent.SelectedValue.ToString + "'"
        Dim cmd As SqlCommand = New SqlCommand(strQuery)
        cmd.Parameters.Add("@id", SqlDbType.Int).Value = 3
        Dim dt As DataTable = GetData(cmd)
        If dt IsNot Nothing Then
            download(dt)
        End If
    End Sub
    Protected Sub download(ByVal dt As DataTable)

        '  If ds.Tables("ck").Rows.Count > 0 Then
        Dim bytes() As Byte = CType(dt.Rows(0)("Data"), Byte())
        Response.Buffer = True
        Response.Charset = ""
        Response.Cache.SetCacheability(HttpCacheability.NoCache)
        Response.ContentType = dt.Rows(0)("ContentType").ToString()

        ' Response.ContentType = ds.Tables("ck").Rows(0).Item("ContentType").ToString
        'Response.AddHeader("content-disposition", "attachment;filename=" & dt.Rows(0)("Name").ToString())
        Response.AddHeader("content-disposition", "attachment;filename=""" + dt.Rows(0)("Name").ToString() + "" + dt.Rows(0)("ContentType").ToString() + "")
        Response.BinaryWrite(bytes)
        Response.Flush()
        Response.End()

        ' End If

    End Sub

    Public Function GetData(ByVal cmd As SqlCommand) As DataTable
        Dim dt As New DataTable
        Dim strConnString As String = (System.Configuration.ConfigurationManager.AppSettings("connpath"))
        Dim con As New SqlConnection(strConnString)
        Dim sda As New SqlDataAdapter
        cmd.CommandType = CommandType.Text
        cmd.Connection = con
        Try
            con.Open()
            sda.SelectCommand = cmd
            sda.Fill(dt)
            Return dt
        Catch ex As Exception
            Response.Write(ex.Message)
            Return Nothing
        Finally
            con.Close()
            sda.Dispose()
            con.Dispose()
        End Try
    End Function
    Public Sub getuploaded()

        Dim dsid2 As New DataSet
        cmd = New SqlCommand("select ID, Name, ContentType from accounts_documents where doc_generated='" + TXTClientID.Text + "'", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(dsid2, "jointn")
        If (dsid2.Tables(0).Rows.Count > 0) Then
            grdEvent.DataSource = dsid2
            grdEvent.DataBind()

        End If
    End Sub

    Protected Sub grdEvent_SelectedIndexChanged(sender As Object, e As EventArgs) Handles grdEvent.SelectedIndexChanged
        Try
            pd()
        Catch ex As Exception

        End Try
        Try
            word()
        Catch ex As Exception

        End Try

        Try
            xls()
        Catch ex As Exception

        End Try
        Try
            Img()
        Catch ex As Exception

        End Try
    End Sub
End Class
