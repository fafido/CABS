Imports System.Data
Imports System.Data.SqlClient
Imports System.IO

Partial Class BrokerMode_AccountUpdate
    Inherits System.Web.UI.Page
    Dim constr As String = (System.Configuration.ConfigurationManager.AppSettings("connpath"))
    Dim cn As New SqlConnection(constr)
    Dim cmd As SqlCommand
    Dim adp As SqlDataAdapter
    Dim ds As New DataSet
    Public Sub msgbox(ByVal strMessage As String)

        'finishes server processing, returns to client.
        Dim strScript As String = "<script language=JavaScript>"
        strScript += "window.alert(""" & strMessage & """);"
        strScript += "</script>"
        Dim lbl As New System.Web.UI.WebControls.Label
        lbl.Text = strScript
        Page.Controls.Add(lbl)

    End Sub
    Protected Sub btnHolderNumSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnHolderNumSearch.Click
        Try
            findShareholderNumber()
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Page.MaintainScrollPositionOnPostBack = True
        If (Not IsPostBack) Then
            If (Session("Username") = Nothing) Then
                Response.Redirect("~\loginsystem.aspx")
                Exit Sub
            End If
            cmd = New SqlCommand("insert into UserActivityLog (UserName,Activity,TimeOfActivity,DateDone,CompanyCode) values ('" & Session("Username") & "','Accessed Accounts Update Form','" & Date.Now & "','" & Now.Date & "','" & Session("BrokerCode") & "')", cn)
            If (cn.State = ConnectionState.Open) Then
                cn.Close()
            End If
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()
            getBank()
            getCountry()
            getCity()
        End If
    End Sub
    Public Sub getCountry()
        Try
            cmd = New SqlCommand("Select Country from para_country order by country", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "para_country")
            cmbCountry.DataSource = ds.Tables(0)
            cmbCountry.DataValueField = "country"
            cmbCountry.DataBind()
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub getCoutryShort()
        Try
            cmd = New SqlCommand("Select fnam from para_country where country='" & cmbCountry.Text & "'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "para_country")
            lblCountry.Text = ds.Tables(0).Rows(0).Item("fnam").ToString
            getCity()
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub getCity()
        Try
            Dim ds1 As New DataSet
            cmd = New SqlCommand("Select city from para_city where country='" & cmbCountry.Text & "'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds1, "para_city")
            CmbCity.DataSource = ds1.Tables(0)
            CmbCity.DataValueField = "city"
            CmbCity.DataBind()
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub getBank()
        Try
            Dim ds1 As New DataSet
            'MsgBox("TEST")
            cmd = New SqlCommand("select distinct(bank_name) from para_bank", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds1, "para_bank")
            cmbBank.DataSource = ds1.Tables(0)
            cmbBank.DataValueField = "bank_name"
            cmbBank.DataBind()
            getBankShort()
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub getBankShort()
        Try
            Dim ds1 As New DataSet
            cmd = New SqlCommand("select bank_code from para_bank where bank_name='" & cmbBank.Text & "'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds1, "para_bank")
            lblBank.Text = (ds1.Tables(0).Rows(0).Item("bank_code").ToString)
            getBranch()
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Public Sub getBranch()
        Try
            Dim ds1 As New DataSet
            cmd = New SqlCommand("select branch_name from para_branch where bank ='" & lblBank.Text & "'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds1, "para_branch")
            cmbBranch.DataSource = ds1.Tables(0)
            cmbBranch.DataValueField = "branch_name"
            cmbBranch.DataBind()
            getBranchShort()
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub getBranchShort()
        Try
            Dim ds1 As New DataSet
            cmd = New SqlCommand("select branch_code from para_branch where branch_name='" & cmbBranch.Text & "' and bank='" & lblBank.Text & "'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds1, "para_branch")
            lblBranch.Text = ds1.Tables(0).Rows(0).Item("branch_code")
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub cmbCountry_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbCountry.SelectedIndexChanged
        getCoutryShort()
    End Sub

    Protected Sub cmbBank_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbBank.SelectedIndexChanged
        getBankShort()
    End Sub

    Protected Sub chkBank_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkBank.CheckedChanged
        If (chkBank.Checked = True) Then
            ChkRemoveBank.Checked = False
            cmbBank.Enabled = True
            cmbBranch.Enabled = True
            cmbAccType.Enabled = True
            txtBnkAccount.Enabled = True
        End If

    End Sub

    Protected Sub ChkRemoveBank_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChkRemoveBank.CheckedChanged
        If (ChkRemoveBank.Checked = True) Then
            chkBank.Checked = False
            cmbBank.Enabled = False
            cmbBranch.Enabled = False
            cmbAccType.Enabled = False
            txtBnkAccount.Text = ""
            txtBnkAccount.Enabled = False
        End If
    End Sub
    Public Sub findShareholderNumber()
        Try
            Dim ds1 As New DataSet
            If (txtshareholderSerch.Text = "") Then
                msgbox("Enter a valid Shareholder Number")
                Exit Sub
            End If
            cmd = New SqlCommand("select * from names where cds_number='" & txtshareholderSerch.Text & "'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds1, "names")

            If (ds1.Tables(0).Rows.Count > 0) Then
                txtShareholder.Text = ds1.Tables(0).Rows(0).Item("cds_number").ToString
                txtSurname.Text = ds1.Tables(0).Rows(0).Item("Surname").ToString
                txtforenames.Text = ds1.Tables(0).Rows(0).Item("Forenames").ToString
                txtID.Text = ds1.Tables(0).Rows(0).Item("IDpp").ToString
                txtAdd1.Text = ds1.Tables(0).Rows(0).Item("Add_1").ToString
                txtAdd2.Text = ds1.Tables(0).Rows(0).Item("Add_2").ToString
                txtadd3.Text = ds1.Tables(0).Rows(0).Item("Add_3").ToString
                txtadd4.Text = ds1.Tables(0).Rows(0).Item("Add_4").ToString
                txtTel.Text = ds1.Tables(0).Rows(0).Item("Telephone").ToString
                txtCell.Text = ds1.Tables(0).Rows(0).Item("Cellphone").ToString
                txtEmail.Text = ds1.Tables(0).Rows(0).Item("Email").ToString
                txtFax.Text = ds1.Tables(0).Rows(0).Item("Fax").ToString
                BasicDatePicker1.SelectedDate = CDate(ds1.Tables(0).Rows(0).Item("dob").ToString)
                txtBnkAccount.Text = ds1.Tables(0).Rows(0).Item("Account").ToString
                lblBank.Text = ds1.Tables(0).Rows(0).Item("Bank_Name").ToString
                lblBranch.Text = ds1.Tables(0).Rows(0).Item("Branch_Name").ToString

                Dim signpath As String = ConfigurationManager.AppSettings("Signatures").ToString
                Image1.ImageUrl = signpath & ds1.Tables(0).Rows(0).Item("ImageId").ToString
                Image1.Width = "200"


                If (ds1.Tables(0).Rows(0).Item("Holder_Type").ToString = "1") Then
                    rdIndividual.Checked = True
                End If
                If (ds1.Tables(0).Rows(0).Item("Holder_Type").ToString = "2") Then
                    rdJoint.Checked = True
                End If
                If (ds1.Tables(0).Rows(0).Item("Holder_Type").ToString = "3") Then
                    rdNominee.Checked = True
                End If
                If (ds1.Tables(0).Rows(0).Item("Holder_Type").ToString = "4") Then
                    rdCompany.Checked = True
                End If
                Dim ds4 As New DataSet
                cmd = New SqlCommand("select country from para_country where fnam='" & ds1.Tables(0).Rows(0).Item("country").ToString & "'", cn)
                adp = New SqlDataAdapter(cmd)
                adp.Fill(ds4, "para_country")
                If (ds4.Tables(0).Rows.Count > 0) Then
                    cmbCountry.Text = ds4.Tables(0).Rows(0).Item("country").ToString
                    lblCountry.Text = ds1.Tables(0).Rows(0).Item("Country").ToString

                    CmbCity.Text = ds1.Tables(0).Rows(0).Item("city").ToString
                End If

            Else
                msgbox("Shareholder not found")
                cleartext()
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub cleartext()
        Try
            txtshareholderSerch.Text = ""
            txtSearch.Text = ""
            txtSurname.Text = ""
            txtforenames.Text = ""
            txtID.Text = ""
            txtAdd1.Text = ""
            txtAdd2.Text = ""
            txtadd3.Text = ""
            txtadd4.Text = ""
            txtBnkAccount.Text = ""
            txtTel.Text = ""
            txtCell.Text = ""
            txtEmail.Text = ""
            txtFax.Text = ""
            getCountry()
            getCity()
            getBank()

        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub getShortName()
        Try
            Dim ds1 As New DataSet
            Dim str As String
            If (txtSearch.Text = "") Then
                msgbox("Enter a valid name")
                Exit Sub
            End If
            str = txtSearch.Text
            cmd = New SqlCommand("select distinct surname +' '+ forenames+' '+names.cds_number as namess from names where  surname like '" & str & "%' ", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds1, "names")
            cmbShort.DataSource = ds1.Tables("names")
            cmbShort.DataValueField = "namess"
            cmbShort.DataBind()
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub btnSearchName_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearchName.Click
        Try
            getShortName()
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub BindGrid()
        Dim ds As New DataSet
        Try
            Dim str As String
            If cmbShort.SelectedValue.Contains("'") Then
                str = cmbShort.SelectedValue.Replace("'", "''")
            Else
                str = cmbShort.SelectedValue
            End If
            cmd = New SqlCommand("select cds_number as Shareholder,surname as Surname,forenames as Forenames from names where surname +' '+ forenames+' '+cds_number ='" & cmbShort.SelectedItem.Text & "'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "names")
            If (ds.Tables(0).Rows.Count > 0) Then
                txtshareholderSerch.Text = ds.Tables(0).Rows(0).Item("shareholder").ToString

                findShareholderNumber()
            Else
                msgbox("No Relevant Data Exists")
                Exit Sub
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub btnSelect_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSelect.Click
        BindGrid()
    End Sub
    Public Sub SaveUpdateRecord()
        Try
            If (txtShareholder.Text = "") Then
                msgbox("Select a valid Shareholder")
                Exit Sub
            End If
            If (txtSurname.Text = "") Then
                msgbox("Field for 'Surname' can not be left blank ")
                Exit Sub
            End If
            Dim Lock, HFC As Integer
            If (chkHFC.Checked = True) Then
                HFC = 1
            Else
                HFC = 0
            End If
            If (rdLock.Checked = True) Then
                Lock = 1
            End If
            If (rdUnlock.Checked = True) Then
                Lock = 0
            End If

            'Dim HolderImage As String
            'If (TextBox1.Text = "") Then
            '    HolderImage = ""
            'Else

            '    Dim lastchar As Integer = CInt(TextBox1.Text.ToString.LastIndexOf("\"))
            '    HolderImage = Right(TextBox3.Text, (TextBox1.Text.Length - lastchar))
            'End If
            If (Session("Username") = Nothing) Then
                Response.Redirect("~\loginsystem.aspx")
                Exit Sub
            End If
            Dim dspr As New DataSet
            cmd = New SqlCommand("select * from names where cds_number='" & txtShareholder.Text & "'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(dspr, "names")

            If ((Trim(txtEmail.Text) <> dspr.Tables(0).Rows(0).Item("email").ToString) And (Trim(txtCell.Text) <> dspr.Tables(0).Rows(0).Item("cellphone").ToString)) Then
                msgbox("Cannot change both email address and mobile number at the same time")
                Exit Sub
            End If

            If (ChkRemoveBank.Checked = False) Then
                'msgbox("insert into pre_names_Creation(shareholder,brokercode,CDS_Number,Surname,Forenames,IDpp,DOB,add_1,add_2,add_3,add_4,city,country,Telephone,Cellphone,fax,email,Bank_Name,Bank_Code,Branch_Name,Branch_Code,Account,Tax,HFC,Locked,Updated_by,Update_on,Industry,RecType,ImageID) values(0,'" & Session("BrokerCode") & "','" & txtShareholder.Text & "','" & txtSurname.Text & "','" & txtforenames.Text & "','" & txtID.Text & "','" & BasicDatePicker1.Text & "','" & txtAdd1.Text & "','" & txtAdd2.Text & "','" & txtadd3.Text & "','" & txtadd4.Text & "','" & CmbCity.Text & "','" & cmbCountry.Text & "','" & txtTel.Text & "','" & txtCell.Text & "','" & txtFax.Text & "','" & txtEmail.Text & "','" & cmbBank.Text & "','" & lblBank.Text & "','" & cmbBranch.Text & "','" & lblBranch.Text & "','" & txtBnkAccount.Text & "'," & cmbTax.Text & "," & HFC & "," & Lock & ",'" & Session("UserName") & "','" & Now.Date & "','" & cmbIndustry.Text & "','UPDATE','" & HolderImage & "'")
                cmd = New SqlCommand("insert into pre_names_Creation(shareholder,brokercode,CDS_Number,Surname,Forenames,IDpp,DOB,add_1,add_2,add_3,add_4,city,country,Telephone,Cellphone,fax,email,Bank_Name,Bank_Code,Branch_Name,Branch_Code,Account,Tax,HFC,Locked,Updated_by,Update_on,Industry,Approved,RecType) values(0,'" & Session("BrokerCode") & "','" & txtShareholder.Text & "','" & txtSurname.Text & "','" & txtforenames.Text & "','" & txtID.Text & "','" & BasicDatePicker1.Text & "','" & txtAdd1.Text & "','" & txtAdd2.Text & "','" & txtadd3.Text & "','" & txtadd4.Text & "','" & CmbCity.Text & "','" & cmbCountry.Text & "','" & txtTel.Text & "','" & txtCell.Text & "','" & txtFax.Text & "','" & txtEmail.Text & "','" & cmbBank.Text & "','" & lblBank.Text & "','" & cmbBranch.Text & "','" & lblBranch.Text & "','" & txtBnkAccount.Text & "',0," & HFC & "," & Lock & ",'" & Session("UserName") & "','" & Now.Date & "','0',4,'UPDATE')", cn)
                If (cn.State = ConnectionState.Open) Then
                    cn.Close()
                End If
                cn.Open()
                cmd.ExecuteNonQuery()
                cn.Close()
            End If
            If (ChkRemoveBank.Checked = True) Then
                cmd = New SqlCommand("insert into pre_names_Creation(shareholder,brokercode,CDS_Number,Surname,Forenames,IDpp,DOB,add_1,add_2,add_3,add_4,city,country,Telephone,Cellphone,fax,email,Bank_Name,Bank_Code,Branch_Name,Branch_Code,Account,Tax,HFC,Locked,Updated_by,Update_on,Industry,Approved,RecType) values(0,'" & Session("BrokerCode") & "','" & txtShareholder.Text & "','" & txtSurname.Text & "','" & txtforenames.Text & "','" & txtID.Text & "','" & BasicDatePicker1.Text & "','" & txtAdd1.Text & "','" & txtAdd2.Text & "','" & txtadd3.Text & "','" & txtadd4.Text & "','" & CmbCity.Text & "','" & cmbCountry.Text & "','" & txtTel.Text & "','" & txtCell.Text & "','" & txtFax.Text & "','" & txtEmail.Text & "','0','0','0','0','',0," & HFC & "," & Lock & ",'" & Session("UserName") & "','" & Now.Date & "','0',4,'UPDATE')", cn)
                'cmd = New SqlCommand("insert into pre_names_Creation(shareholder,brokercode,CDS_Number,Surname,Forenames,IDpp,DOB,add_1,add_2,add_3,add_4,city,country,Telephone,Cellphone,fax,email,Bank_Name,Bank_Code,Branch_Name,Branch_Code,Account,Tax,HFC,Locked,Updated_by,Update_on,Industry,RecType) values(0,'" & Session("BrokerCode") & "','" & txtShareholder.Text & "','" & txtSurname.Text & "','" & txtforenames.Text & "','" & txtID.Text & "','" & BasicDatePicker1.Text & "','" & txtAdd1.Text & "','" & txtAdd2.Text & "','" & txtadd3.Text & "','" & txtadd4.Text & "','" & CmbCity.Text & "','" & cmbCountry.Text & "','" & txtTel.Text & "','" & txtCell.Text & "','" & txtFax.Text & "','" & txtEmail.Text & "','" & cmbBank.Text & "','" & lblBank.Text & "','" & cmbBranch.Text & "','" & lblBranch.Text & "','" & txtBnkAccount.Text & "'," & cmbTax.Text & "," & HFC & "," & Lock & ",'" & Session("UserName") & "','" & Now.Date & "','" & cmbIndustry.Text & "','UPDATE'", cn)
                'cmd = New SqlCommand("Insert into NamesUpdateAuth (UpdatingBroker,CDS_Number,Surname,Forenames,Idpp,Add_1,Add_2,Add_3,Add_4,City,Country,Telephone,Fax,Email,Bank_Code,Bank_Name,Branch_Code,Branch_Name,Account,Tax,Updated_By,Update_On) values('" & Session("BrokerCode") & "','" & txtShareholder.Text & "','" & txtSurname.Text & "','" & txtforenames.Text & "','" & txtID.Text & "','" & txtAdd1.Text & "','" & txtAdd2.Text & "','" & txtadd3.Text & "','" & txtadd4.Text & "','" & CmbCity.Text & "','" & lblCountry.Text & "','" & txtTel.Text & "','" & txtFax.Text & "','" & txtEmail.Text & "','','','','',''," & cmbTax.Text & ",'" & Session("Username") & "','" & Date.Now & "')", cn)
                If (cn.State = ConnectionState.Open) Then
                    cn.Close()
                End If
                cn.Open()
                cmd.ExecuteNonQuery()
                cn.Close()
            End If
            msgbox("Record update awaiting authorization")
            txtShareholder.Text = ""
            txtSurname.Text = ""
            txtforenames.Text = ""
            txtID.Text = ""
            txtAdd1.Text = ""
            txtAdd2.Text = ""
            txtadd3.Text = ""
            txtadd4.Text = ""
            txtTel.Text = ""
            txtFax.Text = ""
            txtEmail.Text = ""

            txtCell.Text = ""
            cmd = New SqlCommand("insert into UserActivityLog (UserName,Activity,TimeOfActivity,DateDone,CompanyCode) values ('" & Session("Username") & "','Saved an account Update','" & Date.Now & "','" & Now.Date & "','" & Session("BrokerCode") & "')", cn)
            If (cn.State = ConnectionState.Open) Then
                cn.Close()
            End If
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        SaveUpdateRecord()
    End Sub

    Protected Sub txtShareholder_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtShareholder.TextChanged

    End Sub
    Public Sub SaveImage()
        Try
            If (rdID.Checked = False And rdPhoto.Checked = False And rdOther.Checked = False) Then
                msgbox("select a document type you wish to upload")
                Exit Sub
            End If
            If (rdOther.Checked = True And txtOther.Text = "") Then
                msgbox("Enter the type of the document you wish to uplaod")
                txtOther.Visible = True
                txtOther.Focus()
                Exit Sub
            End If
            If (fileuploadImage.HasFile) Then
                Dim length As Integer = fileuploadImage.PostedFile.ContentLength
                Dim fs As Stream = fileuploadImage.PostedFile.InputStream
                Dim br As New BinaryReader(fs)
                Dim bytes As Byte() = br.ReadBytes(fs.Length)
                Dim contenttype As String = String.Empty
                Dim ext = fileuploadImage.PostedFile.ContentType
                'Set the contenttype based on File Extension
                Select Case ext
                    Case ".doc"
                        contenttype = "application/vnd.ms-word"
                        Exit Select
                    Case ".docx"
                        contenttype = "application/vnd.ms-word"
                        Exit Select
                    Case ".xls"
                        contenttype = "application/vnd.ms-excel"
                        Exit Select
                    Case ".xlsx"
                        contenttype = "application/vnd.ms-excel"
                        Exit Select
                    Case ".jpg"
                        contenttype = "image/jpg"
                        Exit Select
                    Case ".png"
                        contenttype = "image/png"
                        Exit Select
                    Case ".gif"
                        contenttype = "image/gif"
                        Exit Select
                    Case ".pdf"
                        contenttype = "application/pdf"
                        Exit Select
                End Select



                Dim imgbyte As Byte() = New Byte(length - 1) {}
                Dim img As HttpPostedFile = fileuploadImage.PostedFile
                img.InputStream.Read(imgbyte, 0, length)
                Dim ImageName As String = ""
                If (rdID.Checked = True) Then
                    ImageName = "ID"
                End If
                If (rdPhoto.Checked = True) Then
                    ImageName = "PHOTO"
                End If
                If (rdOther.Checked = True) Then
                    ImageName = txtOther.Text
                End If
                cmd = New SqlCommand("insert into account_documents (cds_number,image_data,imagetype,imagelength,document_Type) values ('" & txtShareholder.Text & "',@imagedata,'" & ext & "','200','" & ImageName & "')", cn)
                'cmd.Parameters.Add("@imagedata", SqlDbType.Binary).Value = imgbyte
                cmd.Parameters.Add("@imagedata", SqlDbType.Binary).Value = bytes
                If (cn.State = ConnectionState.Open) Then
                    cn.Close()
                End If
                cn.Open()
                cmd.ExecuteNonQuery()
                cn.Close()

                Dim ros As New DataSet
                cmd = New SqlCommand("select document_Type,image_data,id from account_documents where cds_number='" & txtShareholder.Text & "'", cn)
                adp = New SqlDataAdapter(cmd)
                adp.Fill(ros, "account_documents")
                If (ros.Tables(0).Rows.Count > 0) Then
                    imgGrid.DataSource = ros.Tables(0)
                    imgGrid.DataBind()
                Else
                    imgGrid.DataSource = Nothing
                    imgGrid.DataBind()
                End If

                rdID.Checked = False
                rdPhoto.Checked = False
                rdOther.Checked = False
                txtOther.Text = ""
                txtOther.Visible = False
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.Click
        Try
            SaveImage()
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub rdOther_CheckedChanged(sender As Object, e As EventArgs) Handles rdOther.CheckedChanged
        Try
            If (rdOther.Checked = True) Then
                txtOther.Text = ""
                txtOther.Visible = True
                txtOther.Focus()
            Else
                txtOther.Text = ""
                txtOther.Visible = False
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub rdID_CheckedChanged(sender As Object, e As EventArgs) Handles rdID.CheckedChanged
        If (rdID.Checked = True) Then
            txtOther.Text = ""
            txtOther.Visible = False
        End If
    End Sub

    Protected Sub rdPhoto_CheckedChanged(sender As Object, e As EventArgs) Handles rdPhoto.CheckedChanged
        If (rdPhoto.Checked = True) Then
            txtOther.Text = ""
            txtOther.Visible = False
        End If
    End Sub
End Class
