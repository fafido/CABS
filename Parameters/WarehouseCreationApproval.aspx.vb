Imports System.Collections.Generic
Imports System.IO

Partial Class Custodian_WarehouseCreation
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
    Public Sub getCity()
        'Try
        '    Dim ds As New DataSet '
        '    cmd = New SqlCommand("select distinct (city) as cityy from para_city where country='" & txtCountry.Text & "' order by cityy", cn)
        '    adp = New SqlDataAdapter(cmd)
        '    adp.Fill(ds, "para_city")
        '    If (ds.Tables(0).Rows.Count > 0) Then
        '        txtCity.DataSource = ds.Tables(0)
        '        txtCity.TextField = "cityy"
        '        cmbCity.ValueField = "cityy"
        '        cmbCity.DataBind()
        '    End If
        'Catch ex As Exception
        '    msgbox(ex.Message)
        'End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Page.MaintainScrollPositionOnPostBack = True
            If (Not IsPostBack) Then
                loadall()
                loadwarehouses()
                ' loadallWIP()
                GetCountry()
                'getCity()
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub Clearall()
        'cmboperator.ClearSelection()
        txtoperator.Text = ""
        ' cmbCity.SelectedIndex = -1
        txtCity.Text = ""
        txtCountry.Text = ""
        txtWarehouseName.Text = ""
        txtWarehouseCode.Text = ""
        owned.Checked = False
        leased.Checked = False
        txtRepresentative.Text = ""
        txtAddresses.Text = ""
        'txtinsurance.Text = ""
        'txtinsurancePolicyNo.Text = ""
        'txtinsuranceA.Text = ""
        'txtinsurancePolicyNoA.Text = ""
        txtpastRegulatory.Text = ""
        txtNomberofStorage.Text = ""
        txtmake_model.Text = ""
        txtcontactpersonMobileno.Text = ""
        txtcontactpersonPhoneno.Text = ""
        txtgooglelocation.Text = ""
        txtindivcapacity.Text = ""
        txtPhone.Text = ""
        txtEmail.Text = ""
        txtwegcapacity.Text = ""
        ' cmbwegcalibration.ClearSelection()
        txtwegcalibration.Text = ""
        txtNoStorageunits.Text = ""
        txtdeminsionsunits.Text = ""
        txtDurationoflease.Text = ""
        txtpolice.Text = ""
        txtentry.Text = ""
        txtExit.Text = ""
        txtsecurityguards.Text = ""
        'txtsumInsured.Text = ""
        'txtpolicyexpirydate.Text = ""
        'txtsumInsuredA.Text = ""
        'txtpolicyexpirydateA.Text = ""
        txtWarehouseName.Text = ""
        txtWarehouseCode.Text = ""
        txtDesignation.Text = ""
        txtCNICno.Text = ""
        txtPEmail.Text = ""
        txtMobile.Text = ""
        txtRepresentative.Text = ""
        txtNomberofStorage.Text = ""
        txtAddresses.Text = ""
        txtpastRegulatory.Text = ""
        'txtinsurance.Text = ""
        txtscalename.Text = ""
        txtCNICno.Text = ""
        txtpersonnelDesignation.Text = ""
        txtPName.Text = ""
        txtscaleDescription.Text = ""
        txtbountwithfance.Text = ""
        btnsave.Text = "Approve"
        txtduedate.Text = ""
        txtdateInst.Text = ""
        txtTotalCapacityMetricTons.Text = ""
        txtOnwername.Text = ""
        txtdistance.Text = ""
        txtdatecalibration.Text = ""
        txtweighbridgeaddress.Text = ""
        txtcode1.Text = ""
        txtcode2.Text = ""
        txtcode4.Text = ""
        txtcode5.Text = ""
        grdDocuments.DataSource = Nothing
        grdDocuments.DataBind()
        grdLoanBreakDown.DataSource = Nothing
        grdLoanBreakDown.DataBind()
        grdCommodityToBeStored.DataSource = Nothing
        grdCommodityToBeStored.DataBind()
        grdPersonnel.DataSource = Nothing
        grdPersonnel.DataBind()
        grdscale.DataSource = Nothing
        grdscale.DataBind()
        txtAgreementDate.Text = ""
        'btnsaveWIP.Enabled = True
    End Sub
    'Protected Sub btnsavesacle_Click(sender As Object, e As EventArgs) Handles btnsavesacle.Click
    '    If txtWarehouseName.Text = "" Then
    '        msgbox("Please Enter Warehourse Name")
    '        Exit Sub
    '    End If
    '    If txtWarehouseCode.Text = "" Then
    '        msgbox("Please Enter Accreditation Number")
    '        Exit Sub

    '    End If
    '    If txtscalename.Text = "" Then
    '        msgbox("Please Enter scale name")
    '        Exit Sub
    '    End If
    '    If txtscaleDescription.Text = "" Then
    '        msgbox("Please Enter scale Description")
    '        Exit Sub
    '    End If
    '    Try
    '        cmd = New SqlCommand("Insert into scales ([CreatedBy],[name] ,[description],[compname] ,[compcode])  values ('" & Session("Username") & "','" + txtscalename.Text + "', '" + txtscaleDescription.Text + "','" + txtWarehouseName.Text + "','" + txtWarehouseCode.Text + "')", cn)
    '        If cn.State = ConnectionState.Open Then
    '            cn.Close()
    '        End If
    '        cn.Open()
    '        Dim i As Int16 = cmd.ExecuteNonQuery()
    '        If i = 1 Then
    '            txtscalename.Text = ""
    '            txtscaleDescription.Text = ""
    '            msgbox("Scale Successfully Added")
    '            loadscale()
    '        Else
    '            msgbox("Failed to Add Scale")
    '        End If
    '    Catch ex As Exception
    '        msgbox(ex.Message)
    '    End Try
    'End Sub
    Protected Sub btnPersonel_Click(sender As Object, e As EventArgs) Handles btnPersonel.Click
        If txtWarehouseName.Text = "" Then
            msgbox("Please Enter Warehourse Name")
            Exit Sub
        End If
        If txtWarehouseCode.Text = "" Then
            msgbox("Enter Accreditation Number")
            Exit Sub

        End If
        If txtPName.Text = "" Then
            msgbox("Please Enter personnel Name")
            Exit Sub
        End If
        If txtCNICno.Text = "" Then
            msgbox("Please Enter CNIC No")
            Exit Sub
        End If
        If txtpersonnelDesignation.Text = "" Then
            msgbox("Please Enter Designation")
            Exit Sub
        End If
        Try
            cmd = New SqlCommand("Insert into personnel (Designation,[name] ,[email] ,[CNICno] ,[CellNo],WarehouseCode,compname)  values ('" + txtpersonnelDesignation.Text + "', '" + txtPName.Text + "','" + txtPEmail.Text + "','" + txtCNICno.Text + "','" + txtCellNo.Text + "','" + txtWarehouseName.Text + "','" + txtWarehouseCode.Text + "')", cn)
            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If
            cn.Open()
            Dim i As Int16 = cmd.ExecuteNonQuery()
            If i = 1 Then
                msgbox("Personnel Successfully Added")
                loadaPersonnel()
            Else
                msgbox("Failed to Add Personnel")
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    'Protected Sub btnUpload_Click(sender As Object, e As EventArgs) Handles btnUpload.Click
    '    If txtWarehouseName.Text = "" Then
    '        msgbox("Please Enter Warehourse Name")
    '        Exit Sub
    '    End If
    '    If txtWarehouseCode.Text = "" Then
    '        msgbox("Enter Accreditation Number")
    '        Exit Sub
    '    End If
    '    If cmbDocument.Text = "" Then
    '        msgbox("Please Select Document Type")
    '        Exit Sub
    '    End If
    '    If cmbDocument.Text = "Other" Then
    '        If txtDocDescription.Text.Trim = "" Then
    '            msgbox("Enter Document Description")
    '            Exit Sub
    '        End If
    '    End If
    '    Dim filePath As String = FileUpload4.PostedFile.FileName
    '    Dim filename As String = Path.GetFileName(filePath)
    '    Dim ext As String = Path.GetExtension(filename)
    '    Dim contenttype As String = String.Empty
    '    'Set the contenttype based on File Extension
    '    Select Case ext
    '        Case ".doc"
    '            contenttype = ".doc"
    '            Exit Select
    '        Case ".docx"
    '            contenttype = ".docx"
    '            Exit Select
    '        Case ".xls"
    '            contenttype = ".xls"
    '            Exit Select
    '        Case ".xlsx"
    '            contenttype = ".xlsx"
    '            Exit Select
    '        Case ".jpg"
    '            contenttype = ".jpg"
    '            Exit Select
    '        Case ".png"
    '            contenttype = ".png"
    '            Exit Select
    '        Case ".gif"
    '            contenttype = ".gif"
    '            Exit Select
    '        Case ".pdf"
    '            contenttype = ".pdf"
    '            Exit Select
    '    End Select

    '    If contenttype <> String.Empty Then
    '        Dim fs As Stream = FileUpload4.PostedFile.InputStream
    '        Dim br As New BinaryReader(fs)
    '        Dim bytes As Byte() = br.ReadBytes(fs.Length)
    '        Dim docDesc As String = ""
    '        If cmbDocument.Text = "Other" Then
    '            docDesc = txtDocDescription.Text
    '        Else
    '            docDesc = cmbDocument.Text
    '        End If
    '        'insert the file into database 
    '        Dim strQuery As String = " insert into [warehousedocuments] (filename,[compname], compcode, ContentType, Data, doctype,DateUploaded,CreatedBy)" _
    '        & " values (@docname,@compname,@compcode,@ContentType, @Data, @doctype, getdate(),@CreatedBy)"
    '        Dim cmd As New SqlCommand(strQuery)
    '        cmd.Parameters.Add("@CreatedBy", SqlDbType.VarChar).Value = Session("Username")
    '        cmd.Parameters.Add("@docname", SqlDbType.VarChar).Value = filename
    '        cmd.Parameters.Add("@compname", SqlDbType.VarChar).Value = txtWarehouseName.Text
    '        cmd.Parameters.Add("@compcode", SqlDbType.VarChar).Value = txtWarehouseCode.Text
    '        cmd.Parameters.Add("@ContentType", SqlDbType.VarChar).Value = contenttype
    '        cmd.Parameters.Add("@Data", SqlDbType.Binary).Value = bytes
    '        cmd.Parameters.Add("@doctype", SqlDbType.VarChar).Value = docDesc 'cmbDocument.SelectedItem.Value
    '        If InsertUpdateData(cmd) Then
    '            msgbox("Document Successully Uploaded")
    '            loadUploadedFiles()
    '        Else
    '            msgbox("Failed to upload document")
    '        End If
    '    Else
    '        msgbox("File format not recognised." _
    '        & " Upload Image/Word/PDF/Excel formats")
    '    End If
    'End Sub
    Protected Sub grdDocuments_RowDeleting(sender As Object, e As GridViewDeleteEventArgs) Handles grdDocuments.RowDeleting
        Try
            Dim docUploadEditID = DirectCast(grdDocuments.Rows(e.RowIndex).FindControl("txtDocId"), TextBox).Text
            Using con As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("connpath"))
                Using cmd = New SqlCommand("delete from warehousedocuments where ID='" & docUploadEditID & "'", con)
                    If con.State = ConnectionState.Open Then
                        con.Close()
                    End If
                    con.Open()
                    If cmd.ExecuteNonQuery Then
                        msgbox("Document Successufully deleted")
                        loadUploadedFiles()
                    Else
                    End If
                    con.Close()
                End Using
            End Using
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub grdDocuments_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles grdDocuments.RowCommand
        If e.CommandName = "Select" Then
            Dim docID = e.CommandArgument
            Dim strscript As String
            strscript = "<script language=JavaScript>"
            strscript += "window.open('viewDocument.aspx?id=" & docID & "');"
            strscript += "</script>"
            ClientScript.RegisterStartupScript(Me.GetType(), "newwin", strscript)
        End If
    End Sub
    Protected Sub btnsave_Click(sender As Object, e As EventArgs) Handles btnsave.Click
        Try
            If btnsave.Text = "Approve" Then
                'getNExtWarehouseCode()
            End If
            If IsNumeric(txtTotalCapacityMetricTons.Text.Replace(",", "")) = False Then
                txtTotalCapacityMetricTons.Text = "0"
            End If
            'If cmboperator.Text = "" Then
            '    msgbox("Select Operator")
            '    Exit Sub
            'End If

            If txtCountry.Text = "" Then
                msgbox("Please select a warehouse to approve")
                txtCountry.Focus()
                Exit Sub
            End If
            If txtCity.Text = "" Then
                msgbox("Please select a warehouse to approve")
                txtCity.Focus()
                Exit Sub
            End If
            If grdLoanBreakDown.Rows.Count < 0 Then
                msgbox("Select Storage Facility Types")
                Exit Sub
            End If
            If txtWarehouseName.Text = "" Then
                msgbox("Please select a warehouse to approve")
                Exit Sub
            End If
            If txtWarehouseCode.Text = "" Then
                msgbox("Please select a warehouse to approve")
                Exit Sub
            End If
            If txtDesignation.Text = "" Then
                msgbox("Please select a warehouse to approve")
                Exit Sub
            End If
            If txtRepresentative.Text = "" Then
                msgbox("Please select a warehouse to approve")
                Exit Sub
            End If
            'If txtinsurance.Text = "" Then
            '    msgbox("Please Enter Insurance Company Name")
            '    Exit Sub
            'End If
            'If IsNumeric(txtsumInsured.Text.Replace(",", "")) = False Then
            '    msgbox("Please Enter sum Insured")
            '    Exit Sub
            'End If
            'If txtinsurancePolicyNo.Text = "" Then
            '    msgbox("Please Enter Policy No")
            '    Exit Sub
            'End If
            'If txtpolicyexpirydate.Text = "" Then
            '    msgbox("Please Select Policy Expiry Date")
            '    Exit Sub
            'End If
            If leased.Checked = False And owned.Checked = False Then
                msgbox("Please select Whether the storage facility is owned/leased ")
                Exit Sub
            End If
            If ckweighbridgeyes.Checked = False And ckweighbridgeNo.Checked = False Then
                msgbox("Please Select weather Weighbridge is available or not")
                Exit Sub
            End If
            If txtPhone.Text.Trim <> "" Then
                If txtPhone.Text.Length > 12 Then
                    msgbox("Please enter less than or equal to 12 digits for phone number!")
                    Exit Sub
                End If
                If IsNumeric(txtPhone.Text) = False Then
                    msgbox("Please enter numeric for phone!")
                    Exit Sub
                End If
            End If
            'If Len(txtPhone.Text) > 0 And Len(txtPhone.Text) <> 10 Then
            '    msgbox("10 Digits expected for phone number")
            '    Exit Sub
            'End If
            If Len(txtMobile.Text) > 0 And Len(txtMobile.Text) <> 10 Then
                msgbox("10 Digits expected for Mobile number")
                Exit Sub
            End If
            'If Len(txtcontactpersonPhoneno.Text) > 0 And Len(txtcontactpersonPhoneno.Text) <> 10 Then
            '    msgbox("10 Digits expected for contact person Phone number")
            '    Exit Sub
            'End If
            If txtcontactpersonPhoneno.Text.Trim <> "" Then
                If txtcontactpersonPhoneno.Text.Length > 12 Then
                    msgbox("Please enter less than or equal to 12 digits for contact person phone number!")
                    Exit Sub
                End If
                If IsNumeric(txtcontactpersonPhoneno.Text) = False Then
                    msgbox("Please enter numeric for contact person phone!")
                    Exit Sub
                End If
            End If
            If Len(txtcontactpersonMobileno.Text) > 0 And Len(txtcontactpersonMobileno.Text) <> 10 Then
                msgbox("10 Digits expected for contact person mobile number")
                Exit Sub
            End If
            Dim weighbridge As String
            If ckweighbridgeyes.Checked = True Then
                weighbridge = "Yes"
            Else
                weighbridge = "No"
            End If
            Dim lease_onwed As String
            If owned.Checked = False Then
                lease_onwed = "leased"
            Else
                lease_onwed = "owned"
            End If
            Dim subject As String
            Dim body As String
            Dim strQuery As String
            If IsDate(txtAgreementDate.Text) = False Then
                msgbox("please select agreement date")
                Exit Sub
            End If
            If btnsave.Text = "Approve" Then
                subject = "" + txtWarehouseName.Text + " Warehouse Added"
                body = "Your " + txtWarehouseName.Text + " Warehouse . has been successfully added on Central Depository System. Warehouse under the " + txtWarehouseName.Text + " shall be created and Credentials will be sent to the respective Account Holders"
                ' atoryActions] ,[Nostoragefacilities] ,Onwed_Lease,tel,[Onwername] ,[weighbridgeaddress] ,[distance] ,[datecalibration] ,[wegcapacity] ,[wegcalibration] ,[duedate] ,[dateInst] ,[make_model],[OPERATOR],[Status])" & " values (''" & cmbCountry.Text & "'',''" & cmbCity.Text & "'',''" & txtAgreementDate.Text & "'',''" & Session("Username") & "'',''" & txtTotalCapacityMetricTons.Text.Replace(",", "") & "'',''" & txtbountwithfance.Text & "'',''" & weighbridge & "'',getdate(), ''" & txtWarehouseName.Text & "'',''" & txtWarehouseCode.Text & "'',''" & txtAddresses.Text & "'',''" & txtRepresentative.Text & "'', ''" & txtindivcapacity.Text & "'',''" & txtPhone.Text & "'', ''" & txtMobile.Text & "'',''" & txtEmail.Text & "'',''" & txtDesignation.Text & "'',''" & txtgooglelocation.Text & "'', ''" & txtcontactpersonPhoneno.Text & "'',''" & txtcontactpersonMobileno.Text & "'','' '', ''" & txtNoStorageunits.Text & "'',''" & txtdeminsionsunits.Text & "'',''" & txtDurationoflease.Text & "'',''" & txtpolice.Text & "'', ''" & txtentry.Text & "'',''" & txtExit.Text & "'',''" & txtsecurityguards.Text & "'',''" & txtpastRegulatory.Text & "'',''" & txtNomberofStorage.Text & "'',''" & lease_onwed & "'', ''" & txtPhone.Text & "'',''" & txtOnwername.Text & "'',''" & txtweighbridgeaddress.Text & "'' ,''" & txtdistance.Text & "'',''" & txtdatecalibration.Text & "'' ,''" & txtwegcapacity.Text & "'' ,''" & cmbwegcalibration.SelectedValue & "'' ,''" & validateDate(txtduedate.Text) & "'',''" & validateDate(txtdateInst.Text) & "'' ,''" & txtmake_model.Text & "'',''" + cmboperator.SelectedValue + "'','Authorisation')"                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                [compoundwall],             [Weighingscalespresent],  [Dateposted] ,   [WarehouseName],                 [WarehouseCode] ,            [WarehouseAddresses],             [Representative] ,            [Indicapacityperunit] ,                 [Phone],                   [Mobileno] ,            ,         [Email],                [Designation] ,                 [Googlelocation] ,                    [contactpersonPhoneno] ,              [contactpersonMobileno],                commoditystored,                  [noStorageUnits] ,            [DimOfGodown] ,                     [DurationLease] ,                   [PoliceStation] ,               [noEntry] ,             [NoExit] ,              [SecurityArragements] ,                 [InsurancePolicyNo] ,                [SumInsured] ,                  [Coverage] ,               [ExpirydateInsuarnce] ,             [RegulatoryActions] ,               [Nostoragefacilities] ,             Onwed_Lease,                tel,                 [Onwername] ,              [weighbridgeaddress] ,                   [distance] ,                [datecalibration] ,                 [wegcapacity] ,                  [wegcalibration] ,                    [duedate] ,                 [dateInst] ,                 [make_model],                      [OPERATOR]
                'strQuery = "insert into [WarehouseCreation] (Country,City,AgreementDate,A_InsurancePolicyNo,A_Coverage,A_SumInsured,A_ExpirydateInsuarnce,[CreatedBy],[TotalCapacityMetricTons],[compoundwall],[Weighingscalespresent],[Dateposted] ,[WarehouseName],[WarehouseCode] ,[WarehouseAddresses],[Representative] ,[Indicapacityperunit] ,[Phone],[Mobileno] ,[Email], [Designation] ,[Googlelocation] ,[contactpersonPhoneno] ,[contactpersonMobileno], commoditystored,[noStorageUnits] ,[DimOfGodown] ,[DurationLease] ,[PoliceStation] ,[noEntry] ,[NoExit] ,[SecurityArragements] ,[InsurancePolicyNo] ,[SumInsured] ,[Coverage] ,[ExpirydateInsuarnce] , [RegulatoryActions] ,[Nostoragefacilities] ,Onwed_Lease,tel,[Onwername] ,[weighbridgeaddress] ,[distance] ,[datecalibration] ,[wegcapacity] ,[wegcalibration] ,[duedate] ,[dateInst] ,[make_model],[OPERATOR])" & " values (''" & cmbCountry.Text & "'',''" & cmbCity.Text & "'',''" & txtAgreementDate.Text & "'',''" & txtinsurancePolicyNoA.Text & "'',''" & txtinsuranceA.Text & "'',''" & txtsumInsuredA.Text & "'',''" & validateDate(txtpolicyexpirydateA.Text) & "'',''" & Session("Username") & "'',''" & txtTotalCapacityMetricTons.Text.Replace(",", "") & "'',''" & txtbountwithfance.Text & "'',''" & weighbridge & "'',getdate(), ''" & txtWarehouseName.Text & "'',''" & txtWarehouseCode.Text & "'',''" & txtAddresses.Text & "'',''" & txtRepresentative.Text & "'', ''" & txtindivcapacity.Text & "'',''" & txtPhone.Text & "'', ''" & txtMobile.Text & "'',''" & txtEmail.Text & "'',''" & txtDesignation.Text & "'',''" & txtgooglelocation.Text & "'', ''" & txtcontactpersonPhoneno.Text & "'',''" & txtcontactpersonMobileno.Text & "'','' '', ''" & txtNoStorageunits.Text & "'',''" & txtdeminsionsunits.Text & "'',''" & txtDurationoflease.Text & "'',''" & txtpolice.Text & "'', ''" & txtentry.Text & "'',''" & txtExit.Text & "'',''" & txtsecurityguards.Text & "'',''" & txtinsurancePolicyNo.Text & "'',''" & txtsumInsured.Text & "'' ,''" & txtinsurance.Text & "'',''" & validateDate(txtpolicyexpirydate.Text) & "'',''" & txtpastRegulatory.Text & "'',''" & txtNomberofStorage.Text & "'',''" & lease_onwed & "'', ''" & txtPhone.Text & "'',''" & txtOnwername.Text & "'',''" & txtweighbridgeaddress.Text & "'' ,''" & txtdistance.Text & "'',''" & txtdatecalibration.Text & "'' ,''" & txtwegcapacity.Text & "'' ,''" & cmbwegcalibration.SelectedValue & "'' ,''" & validateDate(txtduedate.Text) & "'',''" & validateDate(txtdateInst.Text) & "'' ,''" & txtmake_model.Text & "'',''" + cmboperator.SelectedValue + "'')"
                'strQuery = "insert into [WarehouseCreation] (Country,City,AgreementDate,[CreatedBy],[TotalCapacityMetricTons],[compoundwall],[Weighingscalespresent],[Dateposted] ,[WarehouseName],[WarehouseCode] ,[WarehouseAddresses],[Representative] ,[Indicapacityperunit] ,[Phone],[Mobileno] ,[Email], [Designation] ,[Googlelocation] ,[contactpersonPhoneno] ,[contactpersonMobileno], commoditystored,[noStorageUnits] ,[DimOfGodown] ,[DurationLease] ,[PoliceStation] ,[noEntry] ,[NoExit] ,[SecurityArragements] , [RegulatoryActions] ,[Nostoragefacilities] ,Onwed_Lease,tel,[Onwername] ,[weighbridgeaddress] ,[distance] ,[datecalibration] ,[wegcapacity] ,[wegcalibration] ,[duedate] ,[dateInst] ,[make_model],[OPERATOR])" & " values (''" & cmbCountry.Text & "'',''" & cmbCity.Text & "'',''" & txtAgreementDate.Text & "'',''" & Session("Username") & "'',''" & txtTotalCapacityMetricTons.Text.Replace(",", "") & "'',''" & txtbountwithfance.Text & "'',''" & weighbridge & "'',getdate(), ''" & txtWarehouseName.Text & "'',''" & txtWarehouseCode.Text & "'',''" & txtAddresses.Text & "'',''" & txtRepresentative.Text & "'', ''" & txtindivcapacity.Text & "'',''" & txtPhone.Text & "'', ''" & txtMobile.Text & "'',''" & txtEmail.Text & "'',''" & txtDesignation.Text & "'',''" & txtgooglelocation.Text & "'', ''" & txtcontactpersonPhoneno.Text & "'',''" & txtcontactpersonMobileno.Text & "'','' '', ''" & txtNoStorageunits.Text & "'',''" & txtdeminsionsunits.Text & "'',''" & txtDurationoflease.Text & "'',''" & txtpolice.Text & "'', ''" & txtentry.Text & "'',''" & txtExit.Text & "'',''" & txtsecurityguards.Text & "'',''" & txtpastRegulatory.Text & "'',''" & txtNomberofStorage.Text & "'',''" & lease_onwed & "'', ''" & txtPhone.Text & "'',''" & txtOnwername.Text & "'',''" & txtweighbridgeaddress.Text & "'' ,''" & txtdistance.Text & "'',''" & txtdatecalibration.Text & "'' ,''" & txtwegcapacity.Text & "'' ,''" & cmbwegcalibration.SelectedValue & "'' ,''" & validateDate(txtduedate.Text) & "'',''" & validateDate(txtdateInst.Text) & "'' ,''" & txtmake_model.Text & "'',''" + cmboperator.SelectedValue + "'')"

                Try
                    cmd = New SqlCommand("insert into [WarehouseCreation] (Country,City,AgreementDate,[CreatedBy],[TotalCapacityMetricTons],[compoundwall],[Weighingscalespresent],[Dateposted] ,[WarehouseName],[WarehouseCode] ,[WarehouseAddresses],[Representative] ,[Indicapacityperunit] ,[Phone],[Mobileno] ,[Email], [Designation] ,[Googlelocation] ,[contactpersonPhoneno] ,[contactpersonMobileno], commoditystored,[noStorageUnits] ,[DimOfGodown] ,[DurationLease] ,[PoliceStation] ,[noEntry] ,[NoExit] ,[SecurityArragements] , [RegulatoryActions] ,[Nostoragefacilities] ,Onwed_Lease,tel,[Onwername] ,[weighbridgeaddress] ,[distance] ,[datecalibration] ,[wegcapacity] ,[wegcalibration] ,[duedate] ,[dateInst] ,[make_model],[OPERATOR]) values ('" & txtCountry.Text & "','" & txtCity.Text & "','" & txtAgreementDate.Text & "','" & Session("Username") & "','" & txtTotalCapacityMetricTons.Text.Replace(",", "") & "','" & txtbountwithfance.Text & "','" & weighbridge & "',getdate(), '" & txtWarehouseName.Text & "','" & txtWarehouseCode.Text & "','" & txtAddresses.Text & "','" & txtRepresentative.Text & "','" & txtindivcapacity.Text & "','" & txtPhone.Text & "', '" & txtMobile.Text & "','" & txtEmail.Text & "','" & txtDesignation.Text & "','" & txtgooglelocation.Text & "', '" & txtcontactpersonPhoneno.Text & "','" & txtcontactpersonMobileno.Text & "','', '" & txtNoStorageunits.Text & "','" & txtdeminsionsunits.Text & "','" & txtDurationoflease.Text & "','" & txtpolice.Text & "', '" & txtentry.Text & "','" & txtExit.Text & "','" & txtsecurityguards.Text & "','" & txtpastRegulatory.Text & "','" & txtNomberofStorage.Text & "','" & lease_onwed & "', '" & txtPhone.Text & "','" & txtOnwername.Text & "','" & txtweighbridgeaddress.Text & "' ,'" & txtdistance.Text & "','" & txtdatecalibration.Text & "' ,'" & txtwegcapacity.Text & "' ,'" & txtwegcalibration.Text & "' ,'" & validateDate(txtduedate.Text) & "','" & validateDate(txtdateInst.Text) & "' ,'" & txtmake_model.Text & "','" + txtoperator.Text + "')", cn)
                    If cn.State = ConnectionState.Open Then
                        cn.Close()
                    End If
                    cn.Open()

                    Dim i As Int16 = cmd.ExecuteNonQuery()

                    'If i = 1 Then

                    ' msgbox("Warehouse Added")
                    'msgbox(" ")
                    'Clearall()
                    'loadall()
                    ' Else
                    'msgbox("Failed to Add Warehouse")
                    ' End If
                Catch ex As Exception
                    msgbox(ex.Message)
                End Try

                Try

                    cmd = New SqlCommand("update WarehouseCreation_temp set Status='Authorised Successfully' WHERE [WarehouseCode]='" & txtWarehouseCode.Text & "' AND Operator='" + txtoperator.Text + "'", cn)
                    If (cn.State = ConnectionState.Open) Then
                        cn.Close()
                    End If
                    cn.Open()
                    cmd.ExecuteNonQuery()
                    cn.Close()

                    Clearall()
                    loadall()
                    msgbox("Warehouse Details Approved ")
                    'Session("finish2") = "true"
                    'Response.Redirect(Request.RawUrl)
                Catch ex As Exception
                    msgbox(ex.ToString())
                End Try
            Else
                subject = "" + txtWarehouseName.Text + " Warehouse Updated"
                body = "Your " + txtWarehouseName.Text + " Warehouse . has been successfully updated on Central Depository System. Warehouse under the " + txtWarehouseName.Text + " shall be created And Credentials will be sent to the respective Account Holders"
                'strQuery = "UPDATE [WarehouseCreation] SET Country=''" & cmbCountry.Text & "'',City=''" & cmbCity.Text & "'',AgreementDate=''" & txtAgreementDate.Text & "'',A_InsurancePolicyNo=''" & txtinsurancePolicyNoA.Text & "'',A_Coverage=''" & txtinsuranceA.Text & "'',A_SumInsured=''" & txtsumInsuredA.Text.Replace(",", "") & "'',A_ExpirydateInsuarnce=''" & validateDate(txtpolicyexpirydateA.Text) & "'',[TotalCapacityMetricTons]=''" & txtTotalCapacityMetricTons.Text.Replace(",", "") & "'',[compoundwall]=''" & txtbountwithfance.Text & "'',[Weighingscalespresent]=''" & weighbridge & "'',[WarehouseName]=''" & txtWarehouseName.Text & "'',[WarehouseAddresses]=''" & txtAddresses.Text & "'',[Representative]=''" & txtRepresentative.Text & "'',[Indicapacityperunit]=''" & txtindivcapacity.Text & "'',[Phone]=''" & txtPhone.Text & "'' ,[Mobileno] =''" & txtMobile.Text & "'',[Email]=''" & txtEmail.Text & "'',[Designation]=''" & txtDesignation.Text & "'' ,[Googlelocation] =''" & txtgooglelocation.Text & "'',[contactpersonPhoneno]=''" & txtcontactpersonPhoneno.Text & "'' ,[contactpersonMobileno]=''" & txtcontactpersonMobileno.Text & "'', commoditystored='' '',[noStorageUnits]=''" & txtNoStorageunits.Text & "'' ,[DimOfGodown]=''" & txtdeminsionsunits.Text & "'' ,[DurationLease]=''" & txtDurationoflease.Text & "'' ,[PoliceStation]=''" & txtpolice.Text & "'' ,[noEntry]=''" & txtentry.Text & "'' ,[NoExit]=''" & txtExit.Text & "'' ,[SecurityArragements]=''" & txtsecurityguards.Text & "'' ,[InsurancePolicyNo]=''" & txtinsurancePolicyNo.Text & "'' ,[SumInsured]=''" & txtsumInsured.Text.Replace(",", "") & "'' ,[Coverage]=''" & txtinsurance.Text & "'' ,[ExpirydateInsuarnce] =''" & validateDate(txtpolicyexpirydate.Text) & "'', [RegulatoryActions]=''" & txtpastRegulatory.Text & "'' ,[Nostoragefacilities]=''" & txtNomberofStorage.Text & "'' ,Onwed_Lease=''" & lease_onwed & "'',tel=''" & txtPhone.Text & "'',[Onwername]=''" & txtOnwername.Text & "'' ,[weighbridgeaddress]=''" & txtweighbridgeaddress.Text & "'' ,[distance]=''" & txtdistance.Text & "'' ,[datecalibration]=''" & txtdatecalibration.Text & "'' ,[wegcapacity]=''" & txtwegcapacity.Text & "'' ,[wegcalibration]=''" & cmbwegcalibration.SelectedValue & "'' ,[duedate]=''" & validateDate(txtduedate.Text) & "'' ,[dateInst]=''" & validateDate(txtdateInst.Text) & "'' ,[make_model]=''" & txtmake_model.Text & "'' " & "  WHERE [WarehouseCode]=''" & txtWarehouseCode.Text & "'' AND Operator=''" + cmboperator.SelectedValue + "''"
                    'strQuery = "UPDATE [WarehouseCreation] SET Country=''" & cmbCountry.Text & "'',City=''" & cmbCity.Text & "'',AgreementDate=''" & txtAgreementDate.Text & "'',[TotalCapacityMetricTons]=''" & txtTotalCapacityMetricTons.Text.Replace(",", "") & "'',[compoundwall]=''" & txtbountwithfance.Text & "'',[Weighingscalespresent]=''" & weighbridge & "'',[WarehouseName]=''" & txtWarehouseName.Text & "'',[WarehouseAddresses]=''" & txtAddresses.Text & "'',[Representative]=''" & txtRepresentative.Text & "'',[Indicapacityperunit]=''" & txtindivcapacity.Text & "'',[Phone]=''" & txtPhone.Text & "'' ,[Mobileno] =''" & txtMobile.Text & "'',[Email]=''" & txtEmail.Text & "'',[Designation]=''" & txtDesignation.Text & "'' ,[Googlelocation] =''" & txtgooglelocation.Text & "'',[contactpersonPhoneno]=''" & txtcontactpersonPhoneno.Text & "'' ,[contactpersonMobileno]=''" & txtcontactpersonMobileno.Text & "'', commoditystored='' '',[noStorageUnits]=''" & txtNoStorageunits.Text & "'' ,[DimOfGodown]=''" & txtdeminsionsunits.Text & "'' ,[DurationLease]=''" & txtDurationoflease.Text & "'' ,[PoliceStation]=''" & txtpolice.Text & "'' ,[noEntry]=''" & txtentry.Text & "'' ,[NoExit]=''" & txtExit.Text & "'' ,[SecurityArragements]=''" & txtsecurityguards.Text & "'', [RegulatoryActions]=''" & txtpastRegulatory.Text & "'' ,[Nostoragefacilities]=''" & txtNomberofStorage.Text & "'' ,Onwed_Lease=''" & lease_onwed & "'',tel=''" & txtPhone.Text & "'',[Onwername]=''" & txtOnwername.Text & "'' ,[weighbridgeaddress]=''" & txtweighbridgeaddress.Text & "'' ,[distance]=''" & txtdistance.Text & "'' ,[datecalibration]=''" & txtdatecalibration.Text & "'' ,[wegcapacity]=''" & txtwegcapacity.Text & "'' ,[wegcalibration]=''" & cmbwegcalibration.SelectedValue & "'' ,[duedate]=''" & validateDate(txtduedate.Text) & "'' ,[dateInst]=''" & validateDate(txtdateInst.Text) & "'' ,[make_model]=''" & txtmake_model.Text & "'' " & "  WHERE [WarehouseCode]=''" & txtWarehouseCode.Text & "'' AND Operator=''" + cmboperator.SelectedValue + "''"
                    Try
                    cmd = New SqlCommand("UPDATE [WarehouseCreation] SET Country='" & txtCountry.Text & "',City='" & txtCity.Text & "',AgreementDate='" & txtAgreementDate.Text & "',[TotalCapacityMetricTons]='" & txtTotalCapacityMetricTons.Text.Replace(",", "") & "',[compoundwall]='" & txtbountwithfance.Text & "',[Weighingscalespresent]='" & weighbridge & "',[WarehouseName]='" & txtWarehouseName.Text & "',[WarehouseAddresses]='" & txtAddresses.Text & "',[Representative]='" & txtRepresentative.Text & "'',[Indicapacityperunit]='" & txtindivcapacity.Text & "',[Phone]='" & txtPhone.Text & "' ,[Mobileno] ='" & txtMobile.Text & "',[Email]='" & txtEmail.Text & "',[Designation]='" & txtDesignation.Text & "' ,[Googlelocation] ='" & txtgooglelocation.Text & "',[contactpersonPhoneno]='" & txtcontactpersonPhoneno.Text & "' ,[contactpersonMobileno]='" & txtcontactpersonMobileno.Text & "', commoditystored='',[noStorageUnits]='" & txtNoStorageunits.Text & "' ,[DimOfGodown]='" & txtdeminsionsunits.Text & "' ,[DurationLease]='" & txtDurationoflease.Text & "' ,[PoliceStation]='" & txtpolice.Text & "' ,[noEntry]='" & txtentry.Text & "' ,[NoExit]='" & txtExit.Text & "' ,[SecurityArragements]='" & txtsecurityguards.Text & "', [RegulatoryActions]='" & txtpastRegulatory.Text & "' ,[Nostoragefacilities]='" & txtNomberofStorage.Text & "' ,Onwed_Lease='" & lease_onwed & "',tel='" & txtPhone.Text & "',[Onwername]='" & txtOnwername.Text & "' ,[weighbridgeaddress]='" & txtweighbridgeaddress.Text & "' ,[distance]='" & txtdistance.Text & "' ,[datecalibration]='" & txtdatecalibration.Text & "' ,[wegcapacity]='" & txtwegcapacity.Text & "' ,[wegcalibration]='" & txtwegcalibration.Text & "' ,[duedate]='" & validateDate(txtduedate.Text) & "' ,[dateInst]='" & validateDate(txtdateInst.Text) & "' ,[make_model]='" & txtmake_model.Text & "' " & "  WHERE [WarehouseCode]='" & txtWarehouseCode.Text & "' AND Operator='" + txtoperator.Text + "')", cn)
                    If cn.State = ConnectionState.Open Then
                        cn.Close()
                    End If
                    cn.Open()
                    ' Dim i As Int16 = cmd.ExecuteNonQuery()
                    ' Dim state As Boolean = False
                    'If i = 1 Then
                    cmd.ExecuteNonQuery()

                    ' msgbox("Warehouse Added")

                    msgbox("Warehouse Details Approved")
                        Clearall()
                        loadall()
                    'Else
                    '    msgbox("Failed To Update Warehouse")
                    'End If
                Catch ex As Exception
                    msgbox(ex.Message)
                End Try

            End If


            If btnsave.Text = "Save and Submit" Then
                Try
                    Dim m As New NaymatBilling
                    m.warehouseAccreditationCharges("BILL", "WAREHOUSE", "Initial application charges - Non-refundable", txtTotalCapacityMetricTons.Text, txtWarehouseCode.Text, "0")
                Catch ex As Exception
                    msgbox("Charge Error " + ex.Message)
                End Try

            End If
            'cmd = New SqlCommand("insert into tbl_uncommitted ([description], script, [status], sender, date_inserted, comment, email_body, email_subject, email_to, category,warehouseOperator,warehouseCode) values ('Created a new Warehouse called: " + txtWarehouseName.Text + " and Accreditation Number  : " + txtWarehouseCode.Text + "  Warehouse email is " + txtEmail.Text + ". Address is " + txtAddresses.Text + "  Email Is " + txtEmail.Text + "', '" + strQuery + "', '0','" + Session("Username") + "', getdate(), '','" + body + "','" + subject + "', '" + txtEmail.Text + "','New Warehouse','" & cmboperator.SelectedValue & "','" & txtWarehouseCode.Text & "') UPDATE WarehouseCreation_Temp SET Closed=1 where CreatedBy='" & Session("Username") & "' and Closed=0 AND WarehouseCode='" & txtWarehouseCode.Text & "' ", cn)
            'If InsertUpdateData(cmd) Then
            '    msgbox("Warehouse Details Saved Waiting for approval")
            '    Clearall()
            '    loadall()
            'End If
        Catch ex As Exception
            ErrorLogging.WriteLogFile(Session("Username"), Request.Url.ToString, ex.ToString)
        End Try
    End Sub
    Protected Sub owned_CheckedChanged(sender As Object, e As EventArgs) Handles owned.CheckedChanged
        If owned.Checked = False Then
            leased.Checked = True
            ASPxLabel35.Visible = True
            txtDurationoflease.Visible = True
        Else
            leased.Checked = False
            ASPxLabel35.Visible = False
            txtDurationoflease.Visible = False
        End If
    End Sub
    Protected Sub leased_CheckedChanged(sender As Object, e As EventArgs) Handles leased.CheckedChanged
        If leased.Checked = False Then
            owned.Checked = True
            ASPxLabel35.Visible = False
            txtDurationoflease.Visible = False
        Else
            ASPxLabel35.Visible = True
            txtDurationoflease.Visible = True
            owned.Checked = False
        End If
    End Sub
    Protected Sub ckweighbridgeyes_CheckedChanged(sender As Object, e As EventArgs) Handles ckweighbridgeyes.CheckedChanged
        If ckweighbridgeyes.Checked = False Then
            ckweighbridgeNo.Checked = True
            ASPxLabel57.Visible = True
            txtdatecalibration.Visible = True
            ASPxLabel56.Visible = True
            txtdistance.Visible = True
            ASPxLabel54.Visible = True
            txtOnwername.Visible = True
            ASPxLabel55.Visible = True
            txtweighbridgeaddress.Visible = True
            ASPxLabel52.Visible = False
            txtduedate.Visible = False
            ASPxLabel51.Visible = False
            txtdateInst.Visible = False
        Else
            ckweighbridgeNo.Checked = False
            ASPxLabel57.Visible = False
            txtdatecalibration.Visible = False
            ASPxLabel56.Visible = False
            txtdistance.Visible = False
            ASPxLabel54.Visible = False
            txtOnwername.Visible = False
            ASPxLabel55.Visible = False
            txtweighbridgeaddress.Visible = False
            ASPxLabel52.Visible = True
            txtduedate.Visible = True
            ASPxLabel51.Visible = True
            txtdateInst.Visible = True
        End If
    End Sub
    Protected Sub ckweighbridgeNo_CheckedChanged(sender As Object, e As EventArgs) Handles ckweighbridgeNo.CheckedChanged
        If ckweighbridgeNo.Checked = False Then
            ckweighbridgeyes.Checked = True
            ASPxLabel57.Visible = False
            txtdatecalibration.Visible = False
            ASPxLabel56.Visible = False
            txtdistance.Visible = False
            ASPxLabel54.Visible = False
            txtOnwername.Visible = False
            ASPxLabel55.Visible = False
            txtweighbridgeaddress.Visible = False
            ASPxLabel52.Visible = True
            txtduedate.Visible = True
            ASPxLabel51.Visible = True
            txtdateInst.Visible = True
        Else
            ckweighbridgeyes.Checked = False
            ckweighbridgeNo.Checked = True
            ASPxLabel57.Visible = True
            txtdatecalibration.Visible = True
            ASPxLabel56.Visible = True
            txtdistance.Visible = True
            ASPxLabel54.Visible = True
            txtOnwername.Visible = True
            ASPxLabel55.Visible = True
            txtweighbridgeaddress.Visible = True
            ASPxLabel52.Visible = False
            txtduedate.Visible = False
            ASPxLabel51.Visible = False
            txtdateInst.Visible = False
        End If
    End Sub
    Public Function InsertUpdateData(ByVal cmd As SqlCommand) As Boolean
        Dim strConnString As String = (System.Configuration.ConfigurationManager.AppSettings("connpath"))
        Dim con As New SqlConnection(strConnString)
        cmd.CommandType = CommandType.Text
        cmd.Connection = con
        con.Open()
        cmd.ExecuteNonQuery()
        Return True
        Return False
        con.Close()
        con.Dispose()
    End Function
    Public Function fileupload(filepath As String) As String
        Dim filename As String = Path.GetFileName(filepath)
        Dim ext As String = Path.GetExtension(filename)
        Dim contenttype As String = String.Empty
        'Set the contenttype based on File Extension
        Select Case ext
            Case ".doc"
                contenttype = ".doc"
                Exit Select
            Case ".docx"
                contenttype = ".docx"
                Exit Select
            Case ".xls"
                contenttype = ".xls"
                Exit Select
            Case ".xlsx"
                contenttype = ".xlsx"
                Exit Select
            Case ".jpg"
                contenttype = ".jpg"
                Exit Select
            Case ".png"
                contenttype = ".png"
                Exit Select
            Case ".gif"
                contenttype = ".gif"
                Exit Select
            Case ".pdf"
                contenttype = ".pdf"
                Exit Select
        End Select
        Return contenttype
    End Function
    'Public Sub loadinsurance(oper As String)
    '    Dim ds As New DataSet
    '    cmd = New SqlCommand("select *,format(Expiry,'dd MMM yyyy','en-us') as Expiry1,format(A_Expiry,'dd MMM yyyy','en-us') as Expiry2 from insurancePolicies where participant='" + oper + "' ORDER BY ID DESC", cn)
    '    adp = New SqlDataAdapter(cmd)
    '    adp.Fill(ds, "Ware")
    '    If (ds.Tables(0).Rows.Count > 0) Then
    '        txtinsurancePolicyNo.Text = ds.Tables(0).Rows(0).Item("PolicyNumber").ToString
    '        txtinsurance.Text = ds.Tables(0).Rows(0).Item("InsuranceCompany").ToString
    '        txtsumInsured.Text = ds.Tables(0).Rows(0).Item("Amount").ToString
    '        txtpolicyexpirydate.Text = ds.Tables(0).Rows(0).Item("Expiry1").ToString

    '        txtinsurancePolicyNoA.Text = ds.Tables(0).Rows(0).Item("A_PolicyNumber").ToString
    '        txtinsuranceA.Text = ds.Tables(0).Rows(0).Item("A_InsuranceCompany").ToString
    '        txtsumInsuredA.Text = ds.Tables(0).Rows(0).Item("A_Amount").ToString
    '        txtpolicyexpirydateA.Text = ds.Tables(0).Rows(0).Item("Expiry2").ToString
    '    End If
    'End Sub
    Public Sub loadall()
        Dim ds As New DataSet
        cmd = New SqlCommand("  Select ID,[WarehouseName],[WarehouseCode],[WarehouseAddresses],[WarehouseCode] as [Accreditation Number],[Representative],[Type],[Insurance],[Phone],Coverage  from WarehouseCreation_temp where status = 'Authorisation' order by id desc", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "WarehouseCreation")
        If (ds.Tables(0).Rows.Count > 0) Then
            ASPxGridView3.DataSource = ds
            ASPxGridView3.DataBind()
        End If
    End Sub
    Public Sub loadaPersonnel()
        Dim ds As New DataSet
        cmd = New SqlCommand("select  [name] ,[email] ,[CNICno] ,[CellNo] from [personnel]   where [compname] = '" + txtWarehouseName.Text + "' order by id desc", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "personnel")
        If (ds.Tables(0).Rows.Count > 0) Then
            grdPersonnel.DataSource = ds
            grdPersonnel.DataBind()
        End If
    End Sub
    Public Sub loadwarehouses()

        'Dim ds As New DataSet
        'cmd = New SqlCommand("select company_name, company_code from client_companies where company_type='WAREHOUSE' and key_letter<>'WAREHOUSE'", cn)
        'adp = New SqlDataAdapter(cmd)
        'adp.Fill(ds, "personnel")
        'If (ds.Tables(0).Rows.Count > 0) Then
        '    cmboperator.DataSource = ds
        '    cmboperator.DataTextField = "company_name"
        '    cmboperator.DataValueField = "company_code"
        '    cmboperator.DataBind()
        'End If
    End Sub
    Public Sub loadscale()
        Dim ds As New DataSet
        cmd = New SqlCommand("select   [Name],[Description] from [scales] where [compname] = '" + txtWarehouseName.Text + "'  order by id desc", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "personnel")
        If (ds.Tables(0).Rows.Count > 0) Then
            grdscale.DataSource = ds
            grdscale.DataBind()
        End If
    End Sub
    Protected Sub loadUploadedFiles()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select  * from [warehousedocuments] where [compname] = '" + txtWarehouseName.Text + "'  order by id desc", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "personnel")
            If (ds.Tables(0).Rows.Count > 0) Then
                grdDocuments.DataSource = ds
                grdDocuments.DataBind()
            End If
        Catch ex As Exception
        End Try
    End Sub
    'Protected Sub cmboperator_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmboperator.SelectedIndexChanged
    '    Clearall_ChangeOperator()
    '    getNExtWarehouseCode()
    '    loadaPersonnel()
    '    loadscale()
    '    loadUploadedFiles()
    '    getLoanbreakdown(txtWarehouseCode.Text)
    '    getCommodityToBeStored(txtWarehouseCode.Text)
    '    'loadinsurance(cmboperator.SelectedValue)
    '    getphonecodes()
    'End Sub
    Protected Sub LinkDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("conpath").ConnectionString)
            Dim Recordid As String = CType(sender, LinkButton).CommandArgument
            cmd = New SqlCommand("delete from WarehouseStorageFacility where ID='" & Recordid & "'", con)
            If con.State = ConnectionState.Open Then con.Close()
            con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
            getLoanbreakdown(txtWarehouseCode.Text)
            msgbox("Facility successfully removed")
        End Using
    End Sub
    Protected Sub LinkCTBSDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("conpath").ConnectionString)
            Dim Recordid As String = CType(sender, LinkButton).CommandArgument
            cmd = New SqlCommand("delete from CommodityToBeStored where ID='" & Recordid & "'", con)
            If con.State = ConnectionState.Open Then con.Close()
            con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
            getCommodityToBeStored(txtWarehouseCode.Text)
            msgbox("Commodity successfully removed")
        End Using
    End Sub
    Protected Sub Add(ByVal sender As Object, ByVal e As EventArgs)
        Dim control As Control = Nothing
        If (Not (grdLoanBreakDown.FooterRow) Is Nothing) Then
            control = grdLoanBreakDown.FooterRow
        Else
            control = grdLoanBreakDown.Controls(0).Controls(0)
        End If
        Dim ClientApp As String = txtWarehouseCode.Text
        If ClientApp = "" Then
            msgbox("Enter Accreditation Number")
            Exit Sub
        End If
        Dim StorageFacility As String = CType(control.FindControl("cmbStorageFacility"), DropDownList).SelectedValue
        If StorageFacility = "Other" Then
            StorageFacility = CType(control.FindControl("txtStorageFacilityOther"), TextBox).Text.Trim
        End If
        If StorageFacility = "" Then
            msgbox("select Storage Facility")
            Exit Sub
        End If
        Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("conpath").ConnectionString)
            Using cmd As SqlCommand = New SqlCommand
                cmd.Connection = con
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "IF NOT EXISTS (SELECT TOP 1 * FROM WarehouseStorageFacility C WHERE C.warehouseCode=@warehouseCode AND StorageFacility=@StorageFacility) BEGIN INSERT INTO WarehouseStorageFacility(warehouseCode,StorageFacility,CreatedBy) VALUES(@warehouseCode,@StorageFacility,@CreatedBy) END"
                cmd.Parameters.AddWithValue("@warehouseCode", ClientApp)
                cmd.Parameters.AddWithValue("@StorageFacility", StorageFacility)
                cmd.Parameters.AddWithValue("@CreatedBy", Session("Username"))
                con.Open()
                Dim XV As Integer = cmd.ExecuteNonQuery()
                con.Close()
                getLoanbreakdown(txtWarehouseCode.Text)
                If XV > 0 Then
                    msgbox("facility Succesfully Added")
                Else
                    msgbox("facility already exists")
                End If
            End Using
        End Using
    End Sub
    Protected Sub AddCTBS(ByVal sender As Object, ByVal e As EventArgs)
        Dim control As Control = Nothing
        If (Not (grdCommodityToBeStored.FooterRow) Is Nothing) Then
            control = grdCommodityToBeStored.FooterRow
        Else
            control = grdCommodityToBeStored.Controls(0).Controls(0)
        End If
        Dim ClientApp As String = txtWarehouseCode.Text
        If ClientApp = "" Then
            msgbox("Enter Accreditation Number")
            Exit Sub
        End If
        Dim CommodityToBe As String = CType(control.FindControl("cmbCommodityToBeStored"), DropDownList).SelectedValue
        'If CommodityToBe = "Other" Then
        '    CommodityToBe = CType(control.FindControl("txtCommodityToBeStoredOther"), TextBox).Text.Trim
        'End If
        If CommodityToBe = "" Then
            msgbox("select Commodity")
            Exit Sub
        End If
        Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("conpath").ConnectionString)
            Using cmd As SqlCommand = New SqlCommand
                cmd.Connection = con
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "IF NOT EXISTS (SELECT TOP 1 * FROM CommodityToBeStored C WHERE C.warehouseCode=@warehouseCode AND Commodity=@Commodity) BEGIN INSERT INTO CommodityToBeStored(warehouseCode,Commodity,CreatedBy) VALUES(@warehouseCode,@Commodity,@CreatedBy) END"
                cmd.Parameters.AddWithValue("@warehouseCode", ClientApp)
                cmd.Parameters.AddWithValue("@Commodity", CommodityToBe)
                cmd.Parameters.AddWithValue("@CreatedBy", Session("Username"))
                con.Open()
                Dim XV As Integer = cmd.ExecuteNonQuery()
                con.Close()
                getCommodityToBeStored(txtWarehouseCode.Text)
                If XV > 0 Then
                    msgbox("Commodity Succesfully Added")
                Else
                    msgbox("Commodity already exists")
                End If
            End Using
        End Using
    End Sub
    Sub getLoanbreakdown(ByVal AppNo As String)
        Dim sql_str As String = ""
        If AppNo <> "" Then
            sql_str = "DECLARE @warehouseCode nvarchar(500) = '" & AppNo & "' select B.ID,B.StorageFacility from WarehouseStorageFacility B WHERE B.warehouseCode=@warehouseCode"
            Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("conpath").ConnectionString)
                Using cmd As New SqlCommand(sql_str, con)
                    Dim dss As New DataSet
                    Dim adp = New SqlDataAdapter(cmd)
                    adp.Fill(dss, "WarehouseStorageFacility")
                    If dss.Tables(0).Rows.Count > 0 Then
                        grdLoanBreakDown.DataSource = dss
                    Else
                        grdLoanBreakDown.DataSource = Nothing
                    End If
                    grdLoanBreakDown.DataBind()
                End Using
            End Using
        Else
            grdLoanBreakDown.DataSource = Nothing
            grdLoanBreakDown.DataBind()
        End If
    End Sub
    Sub getCommodityToBeStored(ByVal AppNo As String)
        Dim sql_str As String = ""
        If AppNo <> "" Then
            sql_str = "DECLARE @warehouseCode nvarchar(500) = '" & AppNo & "' select B.ID,B.Commodity from CommodityToBeStored B WHERE B.warehouseCode=@warehouseCode"
            Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("conpath").ConnectionString)
                Using cmd As New SqlCommand(sql_str, con)
                    Dim dss As New DataSet
                    Dim adp = New SqlDataAdapter(cmd)
                    adp.Fill(dss, "CommodityToBeStored")
                    If dss.Tables(0).Rows.Count > 0 Then
                        grdCommodityToBeStored.DataSource = dss
                    Else
                        grdCommodityToBeStored.DataSource = Nothing
                    End If
                    grdCommodityToBeStored.DataBind()
                End Using
            End Using
        Else
            grdCommodityToBeStored.DataSource = Nothing
            grdCommodityToBeStored.DataBind()
        End If
    End Sub
    Protected Sub grdLoanBreakDown_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdLoanBreakDown.RowDataBound
        Dim cmbStorageFacilit = DirectCast(e.Row.FindControl("cmbStorageFacility"), DropDownList)
        Try
            GETListofAllStorageFacil(cmbStorageFacilit)
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub grdCommodityToBeStored_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdCommodityToBeStored.RowDataBound
        Dim cmbCommodityToBeStored = DirectCast(e.Row.FindControl("cmbCommodityToBeStored"), DropDownList)
        Try
            GETListofAllCommoditiestoBeStored(cmbCommodityToBeStored)
        Catch ex As Exception
        End Try
    End Sub
    Public Sub GETListofAllStorageFacil(ByVal cmbf As DropDownList)
        Dim ds As New DataSet
        cmd = New SqlCommand("select * from Para_StorageFacility order by id asc", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "Para_StorageFacility")
        If (ds.Tables(0).Rows.Count > 0) Then
            cmbf.AppendDataBoundItems = True
            cmbf.Items.Clear()
            cmbf.Items.Add(New ListItem("", ""))
            cmbf.DataSource = ds
            cmbf.DataTextField = "StorageFacility"
            cmbf.DataTextField = "StorageFacility"
            cmbf.DataBind()
        End If
    End Sub
    Public Sub GETListofAllCommoditiestoBeStored(ByVal cmbf As DropDownList)
        Dim ds As New DataSet
        cmd = New SqlCommand("select commodity_type from para_commodity_type order by id asc", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "para_commodity_type")
        If (ds.Tables(0).Rows.Count > 0) Then
            cmbf.AppendDataBoundItems = True
            cmbf.Items.Clear()
            cmbf.Items.Add(New ListItem("", ""))
            cmbf.DataSource = ds
            cmbf.DataTextField = "commodity_type"
            cmbf.DataTextField = "commodity_type"
            cmbf.DataBind()
        End If
    End Sub
    Public Sub getphonecodes()
        Dim ds As New DataSet
        cmd = New SqlCommand("select phonecode from para_country where country='" & txtCountry.Text & "'", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "para_city")
        If (ds.Tables(0).Rows.Count > 0) Then
            txtcode1.Text = ds.Tables(0).Rows(0).Item("phonecode")
            txtcode2.Text = ds.Tables(0).Rows(0).Item("phonecode")
            txtcode4.Text = ds.Tables(0).Rows(0).Item("phonecode")
            txtcode5.Text = ds.Tables(0).Rows(0).Item("phonecode")
        End If
    End Sub
    Protected Sub ASPxGridView3_RowCommand(sender As Object, e As DevExpress.Web.ASPxGridView.ASPxGridViewRowCommandEventArgs)
        Dim myID As String = e.KeyValue.ToString
        getExistingRecord(myID)
    End Sub
    Sub getExistingRecord(ByVal recID As String)
        Dim sql_str As String = ""
        ' sql_str = "select FORMAT(AgreementDate,'dd MMM yyyy','en-us') AS AgreementDat,FORMAT(duedate,'dd MMM yyyy','en-us') AS duedat,FORMAT(dateInst,'dd MMM yyyy','en-us') AS dateIns,FORMAT(B.ExpirydateInsuarnce,'dd MMM yyyy','en-us') AS ExpirydateInsuarnc,FORMAT(B.A_ExpirydateInsuarnce,'dd MMM yyyy','en-us') AS A_ExpirydateInsuarnc,B.* from WarehouseCreation_temp B WHERE B.ID=@recID"
        sql_str = "select AgreementDate AS AgreementDat,duedate AS duedat,dateInst AS dateIns,B.ExpirydateInsuarnce AS ExpirydateInsuarnc,B.A_ExpirydateInsuarnce AS A_ExpirydateInsuarnc,B.* from WarehouseCreation_temp B WHERE B.ID=@recID"
        Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("conpath").ConnectionString)
            Using cmd As New SqlCommand(sql_str, con)
                cmd.Parameters.AddWithValue("@recID", recID)
                Dim dss As New DataSet
                Dim adp = New SqlDataAdapter(cmd)
                adp.Fill(dss, "WarehouseCreation")
                If dss.Tables(0).Rows.Count > 0 Then
                    Dim dr As DataRow = dss.Tables(0).Rows(0)
                    Try
                        txtoperator.Text = dr.Item("Operator").ToString
                    Catch ex As Exception
                    End Try
                    Try
                        txtCountry.Text = dr.Item("Country").ToString
                    Catch ex As Exception
                        txtCountry.Text = -1
                    End Try
                    getCity()
                    Try
                        txtCity.Value = dr.Item("City").ToString
                    Catch ex As Exception
                        txtCity.Text = -1
                    End Try
                    txtWarehouseName.Text = dr.Item("WarehouseName").ToString
                    txtWarehouseCode.Text = dr.Item("WarehouseCode").ToString
                    txtMobile.Text = dr.Item("Mobileno").ToString
                    txtPhone.Text = dr.Item("Phone").ToString
                    'txtpolicyexpirydate.Text = ""
                    txtEmail.Text = dr.Item("Email").ToString
                    txtgooglelocation.Text = dr.Item("Googlelocation").ToString

                    getCommodityToBeStored(txtWarehouseCode.Text)
                    getLoanbreakdown(txtWarehouseCode.Text)
                    txtindivcapacity.Text = dr.Item("Indicapacityperunit").ToString
                    txtRepresentative.Text = dr.Item("Representative").ToString
                    txtDesignation.Text = dr.Item("Designation").ToString
                    txtcontactpersonPhoneno.Text = dr.Item("contactpersonPhoneno").ToString
                    txtcontactpersonMobileno.Text = dr.Item("contactpersonMobileno").ToString
                    txtNoStorageunits.Text = dr.Item("noStorageUnits").ToString
                    txtdeminsionsunits.Text = dr.Item("DimOfGodown").ToString
                    txtbountwithfance.Text = dr.Item("compoundwall").ToString
                    txtAddresses.Text = dr.Item("WarehouseAddresses").ToString
                    txtpolice.Text = dr.Item("PoliceStation").ToString
                    Dim Onwed_Lease As String = dr.Item("Onwed_Lease").ToString
                    If Onwed_Lease = "owned" Then
                        owned.Checked = True
                        leased.Checked = False
                    Else
                        owned.Checked = False
                        leased.Checked = True
                    End If
                    owned_CheckedChanged(DBNull.Value, New EventArgs)
                    leased_CheckedChanged(DBNull.Value, New EventArgs)
                    Dim Weighingscalespresent As String = dr.Item("Weighingscalespresent").ToString
                    If Weighingscalespresent = "Yes" Then
                        ckweighbridgeyes.Checked = True
                        ckweighbridgeNo.Checked = False
                    Else
                        ckweighbridgeyes.Checked = False
                        ckweighbridgeNo.Checked = True
                    End If
                    ckweighbridgeyes_CheckedChanged(DBNull.Value, New EventArgs)
                    ckweighbridgeNo_CheckedChanged(DBNull.Value, New EventArgs)
                    txtDurationoflease.Text = dr.Item("DurationLease").ToString
                    txtOnwername.Text = dr.Item("Onwername").ToString
                    txtweighbridgeaddress.Text = dr.Item("weighbridgeaddress").ToString
                    txtdistance.Text = dr.Item("distance").ToString
                    txtdatecalibration.Text = dr.Item("datecalibration").ToString
                    txtwegcapacity.Text = dr.Item("wegcapacity").ToString
                    Try
                        txtwegcalibration.Text = dr.Item("wegcalibration").ToString
                    Catch ex As Exception
                    End Try
                    Try
                        txtduedate.Text = dr.Item("duedat").ToString
                    Catch ex As Exception
                    End Try
                    Try
                        txtdateInst.Text = dr.Item("dateIns").ToString
                    Catch ex As Exception
                    End Try
                    txtmake_model.Text = dr.Item("make_model").ToString
                    txtentry.Text = dr.Item("noEntry").ToString
                    txtExit.Text = dr.Item("NoExit").ToString
                    txtsecurityguards.Text = dr.Item("SecurityArragements").ToString
                    'txtinsurancePolicyNo.Text = dr.Item("InsurancePolicyNo").ToString
                    'txtinsurance.Text = dr.Item("Coverage").ToString
                    'txtsumInsured.Text = dr.Item("SumInsured").ToString
                    'Try
                    '    txtpolicyexpirydate.Text = dr.Item("ExpirydateInsuarnc").ToString
                    'Catch ex As Exception
                    'End Try

                    'txtinsurancePolicyNoA.Text = dr.Item("A_InsurancePolicyNo").ToString
                    'txtinsuranceA.Text = dr.Item("A_Coverage").ToString
                    'txtsumInsuredA.Text = dr.Item("A_SumInsured").ToString
                    'Try
                    '    txtpolicyexpirydateA.Text = dr.Item("A_ExpirydateInsuarnc").ToString
                    'Catch ex As Exception
                    'End Try

                    txtpastRegulatory.Text = dr.Item("RegulatoryActions").ToString
                    txtNomberofStorage.Text = dr.Item("Nostoragefacilities").ToString
                    txtTotalCapacityMetricTons.Text = dr.Item("TotalCapacityMetricTons").ToString
                    Try
                        txtAgreementDate.Text = dr.Item("AgreementDat").ToString
                    Catch ex As Exception
                    End Try
                    loadscale()
                    loadUploadedFiles()
                    getphonecodes()
                    loadaPersonnel()
                    'loadinsurance(cmboperator.SelectedValue)
                    ' btnsaveWIP.Enabled = False
                    btnsave.Text = "Approve"
                End If
            End Using
        End Using
    End Sub
    Sub getNExtWarehouseCode()
        Dim sql_str As String = ""
        'sql_str = "select COUNT(B.ID) AS cntRec from WarehouseCreation B WHERE B.Operator=@recID"
        sql_str = "select COUNT(B.ID) AS cntRec from tbl_uncommitted B WHERE B.warehouseOperator=@recID"
        Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("conpath").ConnectionString)
            Using cmd As New SqlCommand(sql_str, con)
                cmd.Parameters.AddWithValue("@recID", txtoperator.Text)
                Dim dss As New DataSet
                Dim adp = New SqlDataAdapter(cmd)
                adp.Fill(dss, "WarehouseCreation")
                If dss.Tables(0).Rows.Count > 0 Then
                    Dim nextNumber As Long = CLng(dss.Tables(0).Rows(0).Item("cntRec")) + 1
                    txtWarehouseCode.Text = txtoperator.Text & "-" & nextNumber.ToString.PadLeft(3, "0")
                End If
            End Using
        End Using
    End Sub
    Protected Sub cmbStorageFacility_SelectedIndexChanged(sender As Object, e As EventArgs)
        Try
            Dim control As Control = Nothing
            If (Not (grdLoanBreakDown.FooterRow) Is Nothing) Then
                control = grdLoanBreakDown.FooterRow
            Else
                control = grdLoanBreakDown.Controls(0).Controls(0)
            End If
            Dim StoragFacilityBox = CType(control.FindControl("txtStorageFacilityOther"), TextBox)
            Dim StorageFacilityItem As String = CType(control.FindControl("cmbStorageFacility"), DropDownList).SelectedValue
            If StorageFacilityItem = "Other" Then
                StoragFacilityBox.Visible = True
            Else
                StoragFacilityBox.Visible = False
            End If
        Catch ex As Exception
        End Try
    End Sub
    'Protected Sub btnsaveWIP_Click(sender As Object, e As EventArgs) Handles btnsaveWIP.Click
    '    Dim weighbridge As String
    '    If ckweighbridgeyes.Checked = True Then
    '        weighbridge = "Yes"
    '    Else
    '        weighbridge = "No"
    '    End If
    '    Dim lease_onwed As String
    '    If owned.Checked = False Then
    '        lease_onwed = "leased"
    '    Else
    '        lease_onwed = "owned"
    '    End If
    '    Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("conpath").ConnectionString)
    '        Using cmd As SqlCommand = New SqlCommand
    '            cmd.Connection = con
    '            cmd.CommandType = CommandType.Text
    '            Dim STRSQL As String = ""
    '            STRSQL = "IF NOT EXISTS (SELECT TOP 1 H.* FROM WarehouseCreation_temp H WHERE H.WarehouseCode=@WarehouseCode AND H.Operator=@Operator AND H.CreatedBy=@CreatedBy AND H.status = 'Work In Progress') BEGIN insert into [WarehouseCreation_temp] ([City],[AgreementDate],[CreatedBy],[TotalCapacityMetricTons],[compoundwall],[Weighingscalespresent],[Dateposted] ,[WarehouseName],[WarehouseCode] ,[WarehouseAddresses],[Representative] ,[Indicapacityperunit] ,[Phone],[Mobileno] ,[Email], [Designation] ,[Googlelocation] ,[contactpersonPhoneno] ,[contactpersonMobileno], commoditystored,[noStorageUnits] ,[DimOfGodown] ,[DurationLease] ,[PoliceStation] ,[noEntry] ,[NoExit] ,[SecurityArragements] , [RegulatoryActions] ,[Nostoragefacilities] ,Onwed_Lease,tel,[Onwername] ,[weighbridgeaddress] ,[distance] ,[datecalibration] ,[wegcapacity] ,[wegcalibration] ,[duedate] ,[dateInst] ,[make_model],[OPERATOR],[status])values (@City,@AgreementDate,@CreatedBy,@TotalCapacityMetricTons,@compoundwall,@Weighingscalespresent,GETDATE() ,@WarehouseName,@WarehouseCode ,@WarehouseAddresses,@Representative ,@Indicapacityperunit ,@Phone,@Mobileno,@Email ,@Designation,@Googlelocation,@contactpersonPhoneno,@contactpersonMobileno,@commoditystored,@noStorageUnits,@DimOfGodown,@DurationLease,@PoliceStation,@noEntry,@NoExit,@SecurityArragements,@RegulatoryActions,@Nostoragefacilities,@Onwed_Lease,@tel,@Onwername,@weighbridgeaddress,@distance,@datecalibration,@wegcapacity,@wegcalibration,@duedate,@dateInst,@make_model,@OPERATOR, 'Work in Progress') END "
    '            STRSQL = STRSQL & "ELSE BEGIN UPDATE WarehouseCreation_temp SET City=@City,AgreementDate=@AgreementDate,TotalCapacityMetricTons=@TotalCapacityMetricTons,compoundwall=@compoundwall,Weighingscalespresent=@Weighingscalespresent,Dateposted=GETDATE(),WarehouseName=@WarehouseName,WarehouseAddresses=@WarehouseAddresses,Representative=@Representative,Indicapacityperunit=@Indicapacityperunit,Phone=@Phone,Mobileno=@Mobileno,Email=@Email,Designation=@Designation,Googlelocation=@Googlelocation,contactpersonPhoneno=@contactpersonPhoneno,contactpersonMobileno=@contactpersonMobileno,commoditystored=@commoditystored,noStorageUnits=@noStorageUnits,DimOfGodown=@DimOfGodown,DurationLease=@DurationLease,PoliceStation=@PoliceStation,noEntry=@noEntry,NoExit=@NoExit,SecurityArragements=@SecurityArragements,RegulatoryActions=@RegulatoryActions,Nostoragefacilities=@Nostoragefacilities,Onwed_Lease=@Onwed_Lease,tel=@tel,Onwername=@Onwername,weighbridgeaddress=@weighbridgeaddress,distance=@distance,datecalibration=@datecalibration,wegcapacity=@wegcapacity,wegcalibration=@wegcalibration,duedate=@duedate,dateInst=@dateInst,make_model=@make_model,OPERATOR=@OPERATOR, status = 'Work in Progress' WHERE CreatedBy=@CreatedBy AND OPERATOR=@OPERATOR AND WarehouseCode=@WarehouseCode END "
    '            cmd.CommandText = STRSQL
    '            cmd.Parameters.AddWithValue("@CreatedBy", Session("Username"))
    '            cmd.Parameters.AddWithValue("@TotalCapacityMetricTons", txtTotalCapacityMetricTons.Text)
    '            cmd.Parameters.AddWithValue("@compoundwall", txtbountwithfance.Text)
    '            cmd.Parameters.AddWithValue("@Weighingscalespresent", weighbridge)
    '            cmd.Parameters.AddWithValue("@WarehouseName", txtWarehouseName.Text)
    '            cmd.Parameters.AddWithValue("@WarehouseCode ", txtWarehouseCode.Text)
    '            cmd.Parameters.AddWithValue("@WarehouseAddresses", txtAddresses.Text)
    '            cmd.Parameters.AddWithValue("@Representative", txtRepresentative.Text)
    '            cmd.Parameters.AddWithValue("@Indicapacityperunit ", txtindivcapacity.Text)
    '            cmd.Parameters.AddWithValue("@Phone", txtPhone.Text)
    '            cmd.Parameters.AddWithValue("@Mobileno", txtMobile.Text)
    '            cmd.Parameters.AddWithValue("@Email", txtEmail.Text)
    '            cmd.Parameters.AddWithValue("@Designation", txtDesignation.Text)
    '            cmd.Parameters.AddWithValue("@Googlelocation", txtgooglelocation.Text)
    '            cmd.Parameters.AddWithValue("@contactpersonPhoneno", txtcontactpersonPhoneno.Text)
    '            cmd.Parameters.AddWithValue("@contactpersonMobileno", txtcontactpersonMobileno.Text)
    '            cmd.Parameters.AddWithValue("@commoditystored", "")
    '            cmd.Parameters.AddWithValue("@noStorageUnits", txtNoStorageunits.Text)
    '            cmd.Parameters.AddWithValue("@DimOfGodown", txtdeminsionsunits.Text)
    '            cmd.Parameters.AddWithValue("@DurationLease", txtDurationoflease.Text)
    '            cmd.Parameters.AddWithValue("@PoliceStation", txtpolice.Text)
    '            cmd.Parameters.AddWithValue("@noEntry", txtentry.Text)
    '            cmd.Parameters.AddWithValue("@NoExit", txtExit.Text)
    '            cmd.Parameters.AddWithValue("@SecurityArragements", txtsecurityguards.Text)
    '            'cmd.Parameters.AddWithValue("@InsurancePolicyNo", txtinsurancePolicyNo.Text)
    '            'cmd.Parameters.AddWithValue("@SumInsured", txtsumInsured.Text)
    '            'cmd.Parameters.AddWithValue("@Coverage", txtinsurance.Text)
    '            'cmd.Parameters.AddWithValue("@ExpirydateInsuarnce", txtpolicyexpirydate.Text)

    '            'cmd.Parameters.AddWithValue("@A_InsurancePolicyNo", txtinsurancePolicyNoA.Text)
    '            'cmd.Parameters.AddWithValue("@A_SumInsured", txtsumInsuredA.Text)
    '            'cmd.Parameters.AddWithValue("@A_Coverage", txtinsuranceA.Text)
    '            'cmd.Parameters.AddWithValue("@A_ExpirydateInsuarnce", txtpolicyexpirydateA.Text)

    '            cmd.Parameters.AddWithValue("@RegulatoryActions", txtpastRegulatory.Text)
    '            cmd.Parameters.AddWithValue("@Nostoragefacilities", txtNomberofStorage.Text)
    '            cmd.Parameters.AddWithValue("@Onwed_Lease", lease_onwed)
    '            cmd.Parameters.AddWithValue("@tel", txtPhone.Text)
    '            cmd.Parameters.AddWithValue("@Onwername", txtOnwername.Text)
    '            cmd.Parameters.AddWithValue("@weighbridgeaddress", txtweighbridgeaddress.Text)
    '            cmd.Parameters.AddWithValue("@distance", txtdistance.Text)
    '            cmd.Parameters.AddWithValue("@datecalibration", txtdatecalibration.Text)
    '            cmd.Parameters.AddWithValue("@wegcapacity", txtwegcapacity.Text)
    '            cmd.Parameters.AddWithValue("@wegcalibration", txtwegcalibration.Text)
    '            cmd.Parameters.AddWithValue("@duedate", txtduedate.Text)
    '            cmd.Parameters.AddWithValue("@dateInst", txtdateInst.Text)
    '            cmd.Parameters.AddWithValue("@make_model", txtmake_model.Text)
    '            cmd.Parameters.AddWithValue("@OPERATOR", txtoperator.Text)
    '            cmd.Parameters.AddWithValue("@AgreementDate", txtAgreementDate.Text)
    '            cmd.Parameters.AddWithValue("@City", txtCity.Text)
    '            cmd.Parameters.AddWithValue("@Country", txtCountry.Text)
    '            con.Open()
    '            cmd.ExecuteNonQuery()
    '            con.Close()
    '            'loadallWIP()
    '            msgbox("Work in progress updated")
    '        End Using
    '    End Using
    'End Sub
    Sub getExistingWIP(ByVal recID As String)
        Dim sql_str As String = ""
        sql_str = "select CASE WHEN ISNULL(AgreementDate,'') ='' THEN '' ELSE FORMAT(CONVERT(DATE,AgreementDate),'dd MMM yyyy','en-us') END AS AgreementDat,CASE WHEN ISNULL(duedate,'') ='' THEN '' ELSE FORMAT(CONVERT(DATE,duedate),'dd MMM yyyy','en-us') END AS duedat,CASE WHEN ISNULL(dateInst,'') ='' THEN '' ELSE FORMAT(CONVERT(DATE,dateInst),'dd MMM yyyy','en-us') END AS dateIns,CASE WHEN ISNULL(ExpirydateInsuarnce,'') ='' THEN '' ELSE FORMAT(CONVERT(DATE,B.ExpirydateInsuarnce),'dd MMM yyyy','en-us') END AS ExpirydateInsuarnc,CASE WHEN ISNULL(A_ExpirydateInsuarnce,'') ='' THEN '' ELSE FORMAT(CONVERT(DATE,B.A_ExpirydateInsuarnce),'dd MMM yyyy','en-us') END AS A_ExpirydateInsuarnc,B.* from WarehouseCreation_Temp B WHERE B.ID=@recID and status = 'Work in Progress'"
        Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("conpath").ConnectionString)
            Using cmd As New SqlCommand(sql_str, con)
                cmd.Parameters.AddWithValue("@recID", recID)
                Dim dss As New DataSet
                Dim adp = New SqlDataAdapter(cmd)
                adp.Fill(dss, "WarehouseCreation")
                If dss.Tables(0).Rows.Count > 0 Then
                    Dim dr As DataRow = dss.Tables(0).Rows(0)
                    Try
                        txtoperator.Text = dr.Item("Operator").ToString
                    Catch ex As Exception
                    End Try
                    Try
                        txtCountry.Text = dr.Item("Country").ToString
                    Catch ex As Exception
                        txtCountry.Text = -1
                    End Try
                    getCity()
                    Try
                        txtCity.Text = dr.Item("City").ToString
                    Catch ex As Exception
                        txtCity.Text = -1
                    End Try
                    txtWarehouseName.Text = dr.Item("WarehouseName").ToString
                    txtWarehouseCode.Text = dr.Item("WarehouseCode").ToString
                    txtMobile.Text = dr.Item("Mobileno").ToString
                    txtPhone.Text = dr.Item("Phone").ToString
                    'txtpolicyexpirydate.Text = ""
                    txtEmail.Text = dr.Item("Email").ToString
                    txtgooglelocation.Text = dr.Item("Googlelocation").ToString
                    getCommodityToBeStored(txtWarehouseCode.Text)
                    getLoanbreakdown(txtWarehouseCode.Text)
                    txtindivcapacity.Text = dr.Item("Indicapacityperunit").ToString
                    txtRepresentative.Text = dr.Item("Representative").ToString
                    txtDesignation.Text = dr.Item("Designation").ToString
                    txtcontactpersonPhoneno.Text = dr.Item("contactpersonPhoneno").ToString
                    txtcontactpersonMobileno.Text = dr.Item("contactpersonMobileno").ToString
                    txtNoStorageunits.Text = dr.Item("noStorageUnits").ToString
                    txtdeminsionsunits.Text = dr.Item("DimOfGodown").ToString
                    txtbountwithfance.Text = dr.Item("compoundwall").ToString
                    txtAddresses.Text = dr.Item("WarehouseAddresses").ToString
                    txtpolice.Text = dr.Item("PoliceStation").ToString
                    Dim Onwed_Lease As String = dr.Item("Onwed_Lease").ToString
                    If Onwed_Lease = "owned" Then
                        owned.Checked = True
                        leased.Checked = False
                    Else
                        owned.Checked = False
                        leased.Checked = True
                    End If
                    owned_CheckedChanged(DBNull.Value, New EventArgs)
                    leased_CheckedChanged(DBNull.Value, New EventArgs)
                    Dim Weighingscalespresent As String = dr.Item("Weighingscalespresent").ToString
                    If Weighingscalespresent = "Yes" Then
                        ckweighbridgeyes.Checked = True
                        ckweighbridgeNo.Checked = False
                    Else
                        ckweighbridgeyes.Checked = False
                        ckweighbridgeNo.Checked = True
                    End If
                    ckweighbridgeyes_CheckedChanged(DBNull.Value, New EventArgs)
                    ckweighbridgeNo_CheckedChanged(DBNull.Value, New EventArgs)
                    txtDurationoflease.Text = dr.Item("DurationLease").ToString
                    txtOnwername.Text = dr.Item("Onwername").ToString
                    txtweighbridgeaddress.Text = dr.Item("weighbridgeaddress").ToString
                    txtdistance.Text = dr.Item("distance").ToString
                    txtdatecalibration.Text = dr.Item("datecalibration").ToString
                    txtwegcapacity.Text = dr.Item("wegcapacity").ToString
                    Try
                        txtwegcalibration.Text = dr.Item("wegcalibration").ToString
                    Catch ex As Exception
                    End Try
                    Try
                        txtduedate.Text = dr.Item("duedat").ToString
                    Catch ex As Exception
                    End Try
                    Try
                        txtdateInst.Text = dr.Item("dateIns").ToString
                    Catch ex As Exception
                    End Try
                    txtmake_model.Text = dr.Item("make_model").ToString
                    txtentry.Text = dr.Item("noEntry").ToString
                    txtExit.Text = dr.Item("NoExit").ToString
                    txtsecurityguards.Text = dr.Item("SecurityArragements").ToString
                    'txtinsurancePolicyNo.Text = dr.Item("InsurancePolicyNo").ToString
                    'txtinsurance.Text = dr.Item("Coverage").ToString
                    'txtsumInsured.Text = dr.Item("SumInsured").ToString
                    'Try
                    '    txtpolicyexpirydate.Text = dr.Item("ExpirydateInsuarnc").ToString
                    'Catch ex As Exception
                    'End Try

                    'txtinsurancePolicyNoA.Text = dr.Item("A_InsurancePolicyNo").ToString
                    'txtinsuranceA.Text = dr.Item("A_Coverage").ToString
                    'txtsumInsuredA.Text = dr.Item("A_SumInsured").ToString
                    'Try
                    '    txtpolicyexpirydateA.Text = dr.Item("A_ExpirydateInsuarnc").ToString
                    'Catch ex As Exception
                    'End Try

                    txtpastRegulatory.Text = dr.Item("RegulatoryActions").ToString
                    txtNomberofStorage.Text = dr.Item("Nostoragefacilities").ToString
                    txtTotalCapacityMetricTons.Text = dr.Item("TotalCapacityMetricTons").ToString
                    Try
                        txtAgreementDate.Text = dr.Item("AgreementDat").ToString
                    Catch ex As Exception
                    End Try
                    loadscale()
                    loadUploadedFiles()
                    getphonecodes()
                    loadaPersonnel()
                    'loadinsurance(cmboperator.SelectedValue)
                End If
            End Using
        End Using
    End Sub
    Protected Sub grdWIP_RowCommand(sender As Object, e As DevExpress.Web.ASPxGridView.ASPxGridViewRowCommandEventArgs)
        Dim myID As String = e.KeyValue.ToString
        getExistingWIP(myID)
    End Sub
    'Public Sub loadallWIP()
    '    Dim ds As New DataSet
    '    cmd = New SqlCommand("  Select ID,[WarehouseName],[WarehouseCode],[WarehouseAddresses],[WarehouseCode] as [Accreditation Number],[Representative],[Type],[Insurance],[Phone],Coverage  from WarehouseCreation_Temp where status =  'work in progress' and  CreatedBy='" & Session("Username") & "' and Closed=0 order by id desc", cn)
    '    adp = New SqlDataAdapter(cmd)
    '    adp.Fill(ds, "WarehouseCreation")
    '    If (ds.Tables(0).Rows.Count > 0) Then
    '        grdWIP.DataSource = ds
    '        grdWIP.DataBind()
    '    End If
    'End Sub
    Function validateDate(inp As String) As Object
        'Return IIf(IsNumeric(toMoney(inp)), DBNull.Value, inp)
        Return IIf(Trim(inp) = "" Or Not IsDate(inp), DBNull.Value, inp)
    End Function
    Public Sub Clearall_ChangeOperator()
        txtWarehouseName.Text = ""
        txtWarehouseCode.Text = ""
        owned.Checked = False
        leased.Checked = False
        txtRepresentative.Text = ""
        txtAddresses.Text = ""
        'txtinsurance.Text = ""
        'txtinsurancePolicyNo.Text = ""
        'txtinsuranceA.Text = ""
        'txtinsurancePolicyNoA.Text = ""
        txtpastRegulatory.Text = ""
        txtNomberofStorage.Text = ""
        txtmake_model.Text = ""
        txtcontactpersonMobileno.Text = ""
        txtcontactpersonPhoneno.Text = ""
        txtgooglelocation.Text = ""
        txtindivcapacity.Text = ""
        txtPhone.Text = ""
        txtEmail.Text = ""
        txtwegcapacity.Text = ""
        ' cmbwegcalibration.ClearSelection()
        txtwegcalibration.Text = ""
        txtNoStorageunits.Text = ""
        txtdeminsionsunits.Text = ""
        txtDurationoflease.Text = ""
        txtpolice.Text = ""
        txtentry.Text = ""
        txtExit.Text = ""
        txtsecurityguards.Text = ""
        'txtsumInsured.Text = ""
        'txtpolicyexpirydate.Text = ""
        'txtsumInsuredA.Text = ""
        'txtpolicyexpirydateA.Text = ""
        txtWarehouseName.Text = ""
        txtWarehouseCode.Text = ""
        txtDesignation.Text = ""
        txtCNICno.Text = ""
        txtPEmail.Text = ""
        txtMobile.Text = ""
        txtRepresentative.Text = ""
        txtNomberofStorage.Text = ""
        txtAddresses.Text = ""
        txtpastRegulatory.Text = ""
        'txtinsurance.Text = ""
        txtscalename.Text = ""
        txtCNICno.Text = ""
        txtpersonnelDesignation.Text = ""
        txtPName.Text = ""
        txtscaleDescription.Text = ""
        txtbountwithfance.Text = ""
        btnsave.Text = "Approve"
        txtduedate.Text = ""
        txtdateInst.Text = ""
        txtTotalCapacityMetricTons.Text = ""
        txtOnwername.Text = ""
        txtdistance.Text = ""
        txtdatecalibration.Text = ""
        txtweighbridgeaddress.Text = ""
        txtcode1.Text = ""
        txtcode2.Text = ""
        txtcode4.Text = ""
        txtcode5.Text = ""
        ' cmbCity.SelectedIndex = -1
        txtCity.Text = ""
        txtAgreementDate.Text = ""
        grdDocuments.DataSource = Nothing
        grdDocuments.DataBind()
        grdLoanBreakDown.DataSource = Nothing
        grdLoanBreakDown.DataBind()
        grdCommodityToBeStored.DataSource = Nothing
        grdCommodityToBeStored.DataBind()
        grdPersonnel.DataSource = Nothing
        grdPersonnel.DataBind()
        grdscale.DataSource = Nothing
        grdscale.DataBind()
    End Sub
    'Protected Sub cmbDocument_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbDocument.SelectedIndexChanged
    '    If cmbDocument.Text = "Other" Then
    '        otherHide1.Visible = True
    '    Else
    '        otherHide1.Visible = False
    '    End If
    'End Sub
    Public Sub GetCountry()
        'Try
        '    Dim ds As New DataSet
        '    cmd = New SqlCommand("select * from para_country ORDER BY country", cn)
        '    adp = New SqlDataAdapter(cmd)
        '    adp.Fill(ds, "para_country")
        '    If (ds.Tables(0).Rows.Count > 0) Then
        '        txtCountry.DataSource = ds.Tables(0)
        '        txtCountry.TextField = "country"
        '        txtCountry.ValueField = "country"
        '        txtCountry.DataBind()
        '    Else
        '        txtCountry.Items.Clear()
        '    End If
        'Catch ex As Exception
        '    msgbox(ex.Message)
        'End Try
    End Sub
    'Protected Sub cmbCountry_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbCountry.SelectedIndexChanged
    '    cmbCity.Items.Clear()
    '    getCity()
    '    Try
    '        cmbCity.Text = ""
    '    Catch ex As Exception
    '    End Try
    '    getphonecodes()
    'End Sub
    Protected Sub btnReject_Click(sender As Object, e As EventArgs) Handles btnReject.Click


        If txtCountry.Text = "" Then
            msgbox("Please select a warehouse to reject")
            txtoperator.Focus()
            Exit Sub
        End If
        If txtCity.Text = "" Then
            msgbox("Please select a warehouse to reject")
            txtCity.Focus()
            Exit Sub
        End If
        If grdLoanBreakDown.Rows.Count < 0 Then
            msgbox("Select Storage Facility Types")
            Exit Sub
        End If
        If txtWarehouseName.Text = "" Then
            msgbox("Please select a warehouse to reject")
            Exit Sub
        End If
        If txtWarehouseCode.Text = "" Then
            msgbox("Please select a warehouse to reject")
            Exit Sub
        End If
        If txtDesignation.Text = "" Then
            msgbox("Please select a warehouse to reject")
            Exit Sub
        End If
        If txtRepresentative.Text = "" Then
            msgbox("Please select a warehouse to reject")
            Exit Sub
        End If
        'If txtinsurance.Text = "" Then
        '    msgbox("Please Enter Insurance Company Name")
        '    Exit Sub
        'End If
        'If IsNumeric(txtsumInsured.Text.Replace(",", "")) = False Then
        '    msgbox("Please Enter sum Insured")
        '    Exit Sub
        'End If
        'If txtinsurancePolicyNo.Text = "" Then
        '    msgbox("Please Enter Policy No")
        '    Exit Sub
        'End If
        'If txtpolicyexpirydate.Text = "" Then
        '    msgbox("Please Select Policy Expiry Date")
        '    Exit Sub
        'End If
        If leased.Checked = False And owned.Checked = False Then
            msgbox("Please select Whether the storage facility is owned/leased ")
            Exit Sub
        End If
        If ckweighbridgeyes.Checked = False And ckweighbridgeNo.Checked = False Then
            msgbox("Please Select weather Weighbridge is available or not")
            Exit Sub
        End If
        If txtPhone.Text.Trim <> "" Then
            If txtPhone.Text.Length > 12 Then
                msgbox("Please enter less than or equal to 12 digits for phone number!")
                Exit Sub
            End If
            If IsNumeric(txtPhone.Text) = False Then
                msgbox("Please enter numeric for phone!")
                Exit Sub
            End If
        End If
        'If Len(txtPhone.Text) > 0 And Len(txtPhone.Text) <> 10 Then
        '    msgbox("10 Digits expected for phone number")
        '    Exit Sub
        'End If
        If Len(txtMobile.Text) > 0 And Len(txtMobile.Text) <> 10 Then
            msgbox("10 Digits expected for Mobile number")
            Exit Sub
        End If
        'If Len(txtcontactpersonPhoneno.Text) > 0 And Len(txtcontactpersonPhoneno.Text) <> 10 Then
        '    msgbox("10 Digits expected for contact person Phone number")
        '    Exit Sub
        'End If
        If txtcontactpersonPhoneno.Text.Trim <> "" Then
            If txtcontactpersonPhoneno.Text.Length > 12 Then
                msgbox("Please enter less than or equal to 12 digits for contact person phone number!")
                Exit Sub
            End If
            If IsNumeric(txtcontactpersonPhoneno.Text) = False Then
                msgbox("Please enter numeric for contact person phone!")
                Exit Sub
            End If
        End If
        If Len(txtcontactpersonMobileno.Text) > 0 And Len(txtcontactpersonMobileno.Text) <> 10 Then
            msgbox("10 Digits expected for contact person mobile number")
            Exit Sub
        End If
        Dim weighbridge As String
        If ckweighbridgeyes.Checked = True Then
            weighbridge = "Yes"
        Else
            weighbridge = "No"
        End If
        Dim lease_onwed As String
        If owned.Checked = False Then
            lease_onwed = "leased"
        Else
            lease_onwed = "owned"
        End If
        Dim subject As String
        Dim body As String
        Dim strQuery As String
        If IsDate(txtAgreementDate.Text) = False Then
            msgbox("please select agreement date")
            Exit Sub
        End If

        If txtcomment.Text = "" Then
            msgbox("Please enter your reason for rejection in the commment area")
            txtcomment.Focus()
            Exit Sub
        End If
        Try

            cmd = New SqlCommand("update WarehouseCreation_temp set Status='Rejected', comments='" + txtcomment.Text + "'  WHERE [WarehouseCode]='" & txtWarehouseCode.Text & "' AND Operator='" + txtoperator.Text + "'", cn)
            If (cn.State = ConnectionState.Open) Then
                cn.Close()
            End If
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()

            Clearall()
            loadall()
            msgbox("Warehouse Details Rejected ")
            'Session("finish2") = "true"
            'Response.Redirect(Request.RawUrl)
        Catch ex As Exception
            msgbox(ex.ToString())
        End Try
    End Sub
End Class

