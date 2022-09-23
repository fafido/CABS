Imports System.Collections.Generic

Partial Class depositWDR
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
                loadContractNo()
                loadDrivatives()
                writerdetails()
                loadassets()

                '       loadAssets()
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Protected Sub clearall()
        txtAssetDesc.Text = ""
        cmbassetname.Text = ""
        txtAssetQuality.Text = ""
        txtAssetQuantity.Text = ""
        txtAssetUnits.Text = ""
        txtAssetValue.Text = ""
        txtContractNo.Text = ""
        txtSearchName.Text = ""
        txtWaddress.Text = ""
        txtStrikePrice.Text = ""
        txtTermsCond.Text = ""
        txtWCds.Text = ""
        txtWforename.Text = ""
        txtWsurname.Text = ""
        lstNames.Items.Clear()
        lstNames.Visible = False
        dtpMaturityDate.Text = ""
        dtpSettlementDate.Text = ""
        cmbassettype.Text = ""
        txtAssetLocation.Text = ""
        txtWIDNo.Text = ""
        txtHIDNo.Text = ""
        lstNames0.Items.Clear()
        lstNames0.Visible = False
        cmbContrType.SelectedIndex = 0
        txtWEmail.Text = ""
        txtWPhone.Text = ""
        txtHCds.Text = ""
        txtHaddress.Text = ""
        txtHEmail.Text = ""
        txtHforename.Text = ""
        txtHPhone.Text = ""
        txtHsurname.Text = ""
    End Sub

    Protected Sub btnSearchName_Click(sender As Object, e As EventArgs) Handles btnSearchName.Click
        Dim ds As New DataSet
        '   If RadioButtonList1.SelectedIndex = 0 Then
        cmd = New SqlCommand(" select company, fnam from para_company where company+' '+fnam like '%" & txtSearchName.Text & "%'", cn)
        'Else
        '    cmd = New SqlCommand("select cds_number+' '+surname+' '+forenames as namess,cds_number  from Accounts_Clients where surname+' '+forenames+' '+cds_number like '%" & txtSearchName.Text & "%' and AccountType<>'I'", cn)
        'End If
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "Accounts_Clients")
        If (ds.Tables(0).Rows.Count > 0) Then
            lstNames.DataSource = ds.Tables(0)
            lstNames.TextField = "fnam"
            lstNames.ValueField = "company"
            lstNames.DataBind()
            lstNames.Visible = True
        End If
    End Sub
    Protected Sub loadassets()
        cmd = New SqlCommand("  select assetname from Assets", cn)
        Dim ds As New DataSet
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "deriv_contract")
        If ds.Tables(0).Rows.Count > 0 Then
            cmbassettype.DataSource = ds
            cmbassettype.TextField = "assetname"
            cmbassettype.DataBind()
        End If
    End Sub
    Protected Sub loadContractNo()
        cmd = New SqlCommand("select isnull(max(id),0)+1 as nextID from deriv_contract", cn)
        Dim ds As New DataSet
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "deriv_contract")
        If ds.Tables(0).Rows.Count > 0 Then
            Dim contractNo As String = String.Concat("DV", ds.Tables(0).Rows(0).Item("nextID").ToString.PadLeft(10, "0"))
            txtContractNo.Text = contractNo
        End If
    End Sub
    Protected Sub writerdetails()
        cmd = New SqlCommand("select * from client_companies where company_name='" + Session("UserCompany") + "'", cn)
        Dim ds As New DataSet
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "deriv_contract")
        If ds.Tables(0).Rows.Count > 0 Then
            txtWIDNo.Text = ds.Tables("deriv_contract").Rows(0).Item("ID")
            txtWEmail.Text = ds.Tables("deriv_contract").Rows(0).Item("contact_email")
            txtWCds.Text = ds.Tables("deriv_contract").Rows(0).Item("ID")
            txtWforename.Text = ds.Tables("deriv_contract").Rows(0).Item("company_name")
            txtWsurname.Text = ds.Tables("deriv_contract").Rows(0).Item("company_name")
            txtWaddress.Text = "" + ds.Tables("deriv_contract").Rows(0).Item("adress_1") + " " + ds.Tables("deriv_contract").Rows(0).Item("adress_2") + " " + ds.Tables("deriv_contract").Rows(0).Item("adress_3") + ""
            txtWPhone.Text = ds.Tables("deriv_contract").Rows(0).Item("contact_phone")
        End If
    End Sub

    Protected Sub loadDrivatives()
        cmd = New SqlCommand("select ContractNo as [Contract No.],writerforename + ' ' + writersurname as Writer,holderforename + ' ' + holdersurname as Holder,Assetname as [Asset Name],AssetValue as [Value],FORMAT(ExpiryMaturityDate,'dd-MMM-yyyy') as [Maturity date],StrikeExercisePrice as [Strike Price] from deriv_contract order by ID desc", cn)
        Dim ds As New DataSet
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "deriv_contract")
        If ds.Tables(0).Rows.Count > 0 Then
            ASPxGridView2.DataSource = ds
            ASPxGridView2.DataBind()
        End If
    End Sub
    Public Function checknames(cdsnum As String) As String
        cmd = New SqlCommand("select * from accounts_clients where cds_number='" + cdsnum + "'", cn)
        Dim ds As New DataSet
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "deriv_contract")
        If ds.Tables(0).Rows.Count > 0 Then
            Return "available"
        Else
            Return "notavailable"
        End If
    End Function
    'Protected Sub loadAssets()
    '    cmd = New SqlCommand("select * from Assets order by ID desc", cn)
    '    Dim ds As New DataSet
    '    adp = New SqlDataAdapter(cmd)
    '    adp.Fill(ds, "Assets")
    '    If ds.Tables(0).Rows.Count > 0 Then
    '        cmbAssetName.DataSource = ds
    '        cmbAssetName.TextField = "AssetName"
    '        cmbAssetName.ValueField = "AssetName"
    '        cmbAssetName.DataBind()
    '    End If
    'End Sub
    Protected Sub btnSaveContract_Click(sender As Object, e As EventArgs) Handles btnSaveContract.Click
        If txtAssetDesc.Text <> "" And txtAssetLocation.Text <> "" And cmbassetname.Text <> "" And txtAssetQuality.Text <> "" And txtAssetQuantity.Text <> "" And txtAssetUnits.Text <> "" And txtAssetValue.Text <> "" And txtContractNo.Text <> "" And txtStrikePrice.Text <> "" And txtTermsCond.Text <> "" And txtWaddress.Text <> "" And txtWCds.Text <> "" And txtWsurname.Text <> "" And dtpMaturityDate.Text <> "" And dtpSettlementDate.Text <> "" And cmbassettype.Text <> "" Then

            cmd = New SqlCommand("select isnull(max(id),0)+1 as nextID from deriv_contract", cn)
            Dim ds As New DataSet
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "deriv_contract")
            If ds.Tables(0).Rows.Count > 0 Then
                If checknames(txtWCds.Text) = "available" Then
                    Dim contractNo As String = String.Concat("DV", ds.Tables(0).Rows(0).Item("nextID").ToString.PadLeft(10, "0"))
                    cmd = New SqlCommand("begin transaction insert into deriv_contract([ContractNo],[writerNo],[writerforename],[writersurname],[Assetname],[AssetDescription],[AssetType],[AssetQuantity],[AssetQuality],[AssetValue],[SettlementDate],[ExpiryMaturityDate],[StrikeExercisePrice],[Terms_Conditions],[SI_Unit],[AssetAddress],[writerAddress],[Company],[Created_By],[Created_On],[writeremail],[writerphone],[writerIDNo],[holderemail],[holderphone],[holderIDNo],[contractType],[HolderNo],[Holderforename],[Holdersurname])values('" & contractNo & "','" & txtWCds.Text & "','" & txtWforename.Text & "','" & txtWsurname.Text & "','" & cmbassetname.Text & "','" & txtAssetDesc.Text & "','" & cmbassettype.Text & "','" & txtAssetQuantity.Text & "','" & txtAssetQuality.Text & "','" & txtAssetValue.Text & "','" & dtpSettlementDate.Text & "','" & dtpMaturityDate.Text & "','" & txtStrikePrice.Text & "','" & txtTermsCond.Text & "','" & txtAssetUnits.Text & "','" & txtAssetLocation.Text & "','" & txtWaddress.Text & "','" & txtWCds.Text & "','" & Session("Username") & "',GETDATE(),'" & txtWEmail.Text & "','" & txtWPhone.Text & "','" & txtWIDNo.Text & "','" & txtHEmail.Text & "','" & txtHPhone.Text & "','" & txtHIDNo.Text & "','" & cmbContrType.Text & "','" & txtHCds.Text & "','" & txtHforename.Text & "','" & txtHsurname.Text & "') insert into trans([Company],[CDS_Number],[Date_Created],[Trans_Time],[Shares],[Update_Type],[Created_By],[Source],[Pledge_shares],[Reference],[Instrument])values('" & txtHCds.Text & "','" & txtHCds.Text & "',GETDATE(),GETDATE(),'" & txtAssetValue.Text & "','Allot','" & Session("Username") & "','S',0,'" & txtContractNo.Text & "','DERIVATIVE') insert into mast([company],[CDS_Number],[Date_Created],[Shares],[Update_Type],[Pladge],[Pledge_Shares],[Created_By],[Updated_On],[Updated_By],[Locked],[Lock_Reason],[Batch_Ref],[PledgeReason],[SecType])values('" & txtHCds.Text & "','" & txtHCds.Text & "',GETDATE(),'" & txtAssetValue.Text & "','ALLOT',0,0,'" & Session("Username") & "',GETDATE(),'" & Session("Username") & "',0,'-',0,'" & txtContractNo.Text & "','DERIVATIVE') commit transaction     insert into trans (company, cds_number, date_created, trans_time, shares, update_type, created_by, batch_ref, [source], Pledge_shares, Reference, instrument) values ('" + txtContractNo.Text + "','" + txtWCds.Text + "',getdate(),getdate(),'" + txtAssetQuantity.Text + "','ALLOT','DERIVATVE ISSUANCE','0','S','0','" + txtContractNo.Text + "','DERIVATIVE')", cn)
                    If cn.State = ConnectionState.Open Then
                        cn.Close()
                    End If
                    cn.Open()
                    cmd.ExecuteNonQuery()
                    cn.Close()
                    clearall()
                    msgbox("Contract Successfully saved, Contract Number is " & contractNo)
                    loadContractNo()
                    loadDrivatives()
                Else
                    Dim contractNo As String = String.Concat("DV", ds.Tables(0).Rows(0).Item("nextID").ToString.PadLeft(10, "0"))
                    cmd = New SqlCommand("begin transaction insert into deriv_contract([ContractNo],[writerNo],[writerforename],[writersurname],[Assetname],[AssetDescription],[AssetType],[AssetQuantity],[AssetQuality],[AssetValue],[SettlementDate],[ExpiryMaturityDate],[StrikeExercisePrice],[Terms_Conditions],[SI_Unit],[AssetAddress],[writerAddress],[Company],[Created_By],[Created_On],[writeremail],[writerphone],[writerIDNo],[holderemail],[holderphone],[holderIDNo],[contractType],[HolderNo],[Holderforename],[Holdersurname])values('" & contractNo & "','" & txtWCds.Text & "','" & txtWforename.Text & "','" & txtWsurname.Text & "','" & cmbassetname.Text & "','" & txtAssetDesc.Text & "','" & cmbassettype.Text & "','" & txtAssetQuantity.Text & "','" & txtAssetQuality.Text & "','" & txtAssetValue.Text & "','" & dtpSettlementDate.Text & "','" & dtpMaturityDate.Text & "','" & txtStrikePrice.Text & "','" & txtTermsCond.Text & "','" & txtAssetUnits.Text & "','" & txtAssetLocation.Text & "','" & txtWaddress.Text & "','" & txtWCds.Text & "','" & Session("Username") & "',GETDATE(),'" & txtWEmail.Text & "','" & txtWPhone.Text & "','" & txtWIDNo.Text & "','" & txtHEmail.Text & "','" & txtHPhone.Text & "','" & txtHIDNo.Text & "','" & cmbContrType.Text & "','" & txtHCds.Text & "','" & txtHforename.Text & "','" & txtHsurname.Text & "') insert into trans([Company],[CDS_Number],[Date_Created],[Trans_Time],[Shares],[Update_Type],[Created_By],[Source],[Pledge_shares],[Reference],[Instrument])values('" & txtHCds.Text & "','" & txtHCds.Text & "',GETDATE(),GETDATE(),'" & txtAssetValue.Text & "','Allot','" & Session("Username") & "','S',0,'" & txtContractNo.Text & "','DERIVATIVE') insert into mast([company],[CDS_Number],[Date_Created],[Shares],[Update_Type],[Pladge],[Pledge_Shares],[Created_By],[Updated_On],[Updated_By],[Locked],[Lock_Reason],[Batch_Ref],[PledgeReason],[SecType])values('" & txtHCds.Text & "','" & txtHCds.Text & "',GETDATE(),'" & txtAssetValue.Text & "','ALLOT',0,0,'" & Session("Username") & "',GETDATE(),'" & Session("Username") & "',0,'-',0,'" & txtContractNo.Text & "','DERIVATIVE') commit transaction    insert into accounts_clients (cds_number, brokercode, accounttype, surname, middlename, forenames, initials, title, idnopp, idtype, nationality, dob, gender, add_1, add_2,add_3,  add_4, country, city, tel, mobile, email, category, custodian, tradingstatus, industry, tax, div_bank, div_branch, div_accountno, cash_bank, cash_branch, cash_accountno, date_created, update_type, created_by, accountstate) values ('" + txtWCds.Text + "','AIG','C','" + txtWforename.Text + "','','" + txtWsurname.Text + "','','','" + txtWIDNo.Text + "','CDS','','20 Jan 1900','M','" + txtWaddress.Text + "','','','','','','" + txtWPhone.Text + "','" + txtWPhone.Text + "','" + txtWEmail.Text + "','N','','TRADING','LC','5','','','','','','',getdate(),'NEW','NEW DERIVITIVE','A')    insert into trans (company, cds_number, date_created, trans_time, shares, update_type, created_by, batch_ref, [source], Pledge_shares, Reference, instrument) values ('" + txtContractNo.Text + "','" + txtWCds.Text + "',getdate(),getdate(),'" + txtAssetQuantity.Text + "','ALLOT','DERIVATVE ISSUANCE','0','S','0','" + txtContractNo.Text + "','DERIVATIVE')", cn)
                    If cn.State = ConnectionState.Open Then
                        cn.Close()
                    End If
                    cn.Open()
                    cmd.ExecuteNonQuery()
                    cn.Close()
                    clearall()
                    msgbox("Contract Successfully saved, Contract Number is " & contractNo)
                    loadContractNo()
                    loadDrivatives()
                End If


            Else
                msgbox("Contract Already Exists")
                Exit Sub
            End If
        Else
            msgbox("Enter All Information Please")
            Exit Sub
        End If
    End Sub

    Protected Sub lstNames_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstNames.SelectedIndexChanged
        getportfolio()
        ASPxLabel49.Text = "Reg No."
        '  txtWforename.Visible = False

        ASPxLabel24.Text = "Corporate Name"
    End Sub
    Public Sub getportfolio()
        '  Try
        Dim ds As New DataSet
        cmd = New SqlCommand("select * from para_company where company='" & lstNames.SelectedItem.Value & "'", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "Accounts_Clients")
        If (ds.Tables(0).Rows.Count > 0) Then
            Try
                txtWCds.Text = ds.Tables("Accounts_clients").Rows(0).Item("company").ToString.ToUpper
            Catch ex As Exception

            End Try
            Try
                txtWIDNo.Text = ds.Tables("Accounts_clients").Rows(0).Item("isin").ToString.ToUpper
            Catch ex As Exception

            End Try
            Try
                txtWEmail.Text = ds.Tables("Accounts_clients").Rows(0).Item("Email").ToString
            Catch ex As Exception

            End Try
            Try
                txtWPhone.Text = ds.Tables("Accounts_clients").Rows(0).Item("Telephone").ToString.ToUpper
            Catch ex As Exception

            End Try
            Try
                txtWsurname.Text = ds.Tables("Accounts_clients").Rows(0).Item("fnam").ToString.ToUpper
            Catch ex As Exception

            End Try
            Try

                txtWforename.Text = ds.Tables("Accounts_clients").Rows(0).Item("fnam").ToString.ToUpper
            Catch ex As Exception

            End Try
            Try
                txtWaddress.Text = String.Concat(ds.Tables("Accounts_clients").Rows(0).Item("Add_1").ToString.ToUpper, " ", ds.Tables("Accounts_clients").Rows(0).Item("Add_2").ToString.ToUpper, " ", ds.Tables("Accounts_clients").Rows(0).Item("Add_3").ToString.ToUpper)

            Catch ex As Exception

            End Try

        Else
            msgbox("nothing")
        End If
        'Catch ex As Exception
        '    msgbox(ex.Message)
        'End Try
    End Sub
    Protected Sub txtAssetQuantity_TextChanged(sender As Object, e As EventArgs) Handles txtAssetQuantity.TextChanged
        If txtAssetQuantity.Text <> "" And txtStrikePrice.Text <> "" Then
            If IsNumeric(txtAssetQuantity.Text) = True And IsNumeric(txtStrikePrice.Text) = True Then
                txtAssetValue.Text = Math.Round((CDbl(txtAssetQuantity.Text) * CDbl(txtStrikePrice.Text)), 2)
            End If
        End If
    End Sub

    Protected Sub txtStrikePrice_TextChanged(sender As Object, e As EventArgs) Handles txtStrikePrice.TextChanged
        If txtAssetQuantity.Text <> "" And txtStrikePrice.Text <> "" Then
            If IsNumeric(txtAssetQuantity.Text) = True And IsNumeric(txtStrikePrice.Text) = True Then
                txtAssetValue.Text = Math.Round((CDbl(txtAssetQuantity.Text) * CDbl(txtStrikePrice.Text)), 2)
            End If
        End If
    End Sub

    Protected Sub btnSearchName0_Click(sender As Object, e As EventArgs) Handles btnSearchName0.Click
        Dim ds As New DataSet
        If RadioButtonList2.SelectedIndex = 0 Then
            cmd = New SqlCommand("select cds_number+' '+surname+' '+forenames as namess,cds_number  from Accounts_Clients where surname+' '+forenames+' '+cds_number like '%" & txtSearchName0.Text & "%' and AccountType='I'", cn)
        Else
            cmd = New SqlCommand("select cds_number+' '+surname+' '+forenames as namess,cds_number  from Accounts_Clients where surname+' '+forenames+' '+cds_number like '%" & txtSearchName0.Text & "%' and AccountType<>'I'", cn)
        End If
        '   cmd = New SqlCommand("select cds_number+' '+surname+' '+forenames as namess,cds_number  from Accounts_Audit where surname+' '+forenames+' '+cds_number like '%" & txtSearchName0.Text & "%'", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "Accounts_Clients")
        If (ds.Tables(0).Rows.Count > 0) Then
            lstNames0.DataSource = ds.Tables(0)
            lstNames0.TextField = "namess"
            lstNames0.ValueField = "cds_number"
            lstNames0.DataBind()
            lstNames0.Visible = True
        End If
    End Sub

    Protected Sub lstNames0_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstNames0.SelectedIndexChanged
        'getportfolio1()
    End Sub

    Protected Sub RadioButtonList1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles RadioButtonList1.SelectedIndexChanged
        If RadioButtonList1.SelectedIndex = 0 Then
            ASPxLabel49.Text = "ID No."
            ASPxLabel23.Visible = True
            txtWforename.Visible = True
            ASPxLabel24.Text = "Writer Surname"
        Else
            ASPxLabel49.Text = "Reg No."
            ASPxLabel23.Visible = False
            txtWforename.Visible = False
            ASPxLabel24.Text = "Corporate Name"
        End If
    End Sub

    Protected Sub RadioButtonList2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles RadioButtonList2.SelectedIndexChanged
        If RadioButtonList2.SelectedIndex = 0 Then
            ASPxLabel50.Text = "ID No."
            ASPxLabel43.Visible = True
            txtHforename.Visible = True
            ASPxLabel45.Text = "Writer Surname"
        Else
            ASPxLabel50.Text = "Reg No."
            ASPxLabel43.Visible = False
            txtHforename.Visible = False
            ASPxLabel45.Text = "Corporate Name"
        End If
    End Sub

    Protected Sub ASPxGridView2_FocusedRowChanged(sender As Object, e As EventArgs) Handles ASPxGridView2.FocusedRowChanged
        txtAssetQuality.Text = "CorporateName"
    End Sub

    Protected Sub ASPxGridView2_SelectionChanged(sender As Object, e As EventArgs) Handles ASPxGridView2.SelectionChanged

        txtAssetQuality.Text = "CorporateName"
    End Sub
    Private Sub Page_PreRender(sender As Object, e As EventArgs)

    End Sub

    Protected Sub btnSaveContract0_Click(sender As Object, e As EventArgs) Handles btnSaveContract0.Click
        'Dim keys As List(Of Object) = ASPxGridView2.GetSelectedFieldValues(ASPxGridView2.KeyFieldName)

        'txtAssetQuality.Text = keys(0).ToString
        Page.MaintainScrollPositionOnPostBack = False
        ASPxPopupControl1.PopupHorizontalAlign = DevExpress.Web.ASPxClasses.PopupHorizontalAlign.WindowCenter
        ASPxPopupControl1.PopupVerticalAlign = DevExpress.Web.ASPxClasses.PopupVerticalAlign.Below
        ASPxPopupControl1.AllowDragging = True
        ASPxPopupControl1.ShowCloseButton = True
        ASPxPopupControl1.ShowOnPageLoad = True
        Page.MaintainScrollPositionOnPostBack = False
    End Sub

    Protected Sub ASPxButton8_Click(sender As Object, e As EventArgs) Handles ASPxButton8.Click

    End Sub
End Class

