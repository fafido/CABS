Imports System.Net.Mail
Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Imports System
Imports System.Configuration
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls
Partial Class TransferSec_AccountsCreations_corp
    Inherits System.Web.UI.Page
    Protected Sub btnJadd0_Click(sender As Object, e As EventArgs) Handles btnJadd0.Click
        validateidnumber()
    End Sub
    Dim constr As String = (System.Configuration.ConfigurationManager.AppSettings("connpath"))
    Dim cn As New SqlConnection(constr)
    Dim adp As SqlDataAdapter
    Dim cmd As SqlCommand
    Shared random As New Random()
    Dim Mail As New MailMessage
    Dim SMTP As New SmtpClient("smtp.googlemail.com")
    Public password, numb, codec As String

    Public Sub msgbox(ByVal strMessage As String)

        'finishes server processing, returns to client.
        Dim strScript As String = "<script language=JavaScript>"
        strScript += "window.alert(""" & strMessage & """);"
        strScript += "</script>"
        Dim lbl As New System.Web.UI.WebControls.Label
        lbl.Text = strScript
        Page.Controls.Add(lbl)

    End Sub
    Public Shared Function CreateRandomPassword(ByVal PasswordLength As Integer) As String
        Dim _allowedChars As String = "0123456789"
        Dim randomNumber As New Random()
        Dim chars(PasswordLength - 1) As Char
        Dim allowedCharCount As Integer = _allowedChars.Length
        For i As Integer = 0 To PasswordLength - 1
            chars(i) = _allowedChars.Chars(CInt(Fix((_allowedChars.Length) * randomNumber.NextDouble())))
        Next i
        Return New String(chars)
    End Function
    Public Sub GetBankName()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select distinct bank,bank_name from para_bank ORDER BY bank_name", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "para_bank")
            If (ds.Tables(0).Rows.Count > 0) Then
                cmbBankDiv.DataSource = ds.Tables(0)
                cmbBankDiv.TextField = "bank_name"
                cmbBankDiv.ValueField = "bank"
                cmbBankDiv.DataBind()
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub GetCountry()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select distinct (country) from para_country order by Country", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "para_country")
            If (ds.Tables(0).Rows.Count > 0) Then
                cmbCountry.DataSource = ds.Tables(0)
                cmbCountry.TextField = "country"
                cmbCountry.ValueField = "country"
                cmbCountry.DataBind()

                cmbCountryTaxResidence.DataSource = ds.Tables(0)
                cmbCountryTaxResidence.TextField = "country"
                cmbCountryTaxResidence.ValueField = "country"
                cmbCountryTaxResidence.DataBind()
            Else
                cmbCountry.Items.Clear()
                cmbCountryTaxResidence.Items.Clear()
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Page.MaintainScrollPositionOnPostBack = True
        If (Not IsPostBack) Then
            GetCountry()
            getAssetmanagers()
            cmbIDType.SelectedIndex = 0
            GetBankName()
            txtDOB.MaxDate = Date.UtcNow.ToString
            If Session("finish") = "yes" Then
                Session("finish") = ""
                msgbox(Session("updatemsg"))
                Session("updatemsg") = ""
            End If
            loadallWIP()
        End If
    End Sub
    Public Sub SaveNewAccount()
        Try
            If ASPxGridView1.VisibleRowCount > 0 Then
            Else
                msgbox("Please add attachments")
                Exit Sub
            End If
            'Validation State
            If (Len(txtSurname.Text) < 1) Then
                msgbox("Please enter Corporate Name")
                txtSurname.Focus()
                Exit Sub
            End If

            If CNICExits() = True Then
                msgbox("Registration No./Incorporation No. already exists")
                txtIDNo.Focus()
                Exit Sub
            End If
            If IDBlacklistedAML() = True Then
                msgbox("Registration No./Incorporation No. is black listed under AML.")
                txtIDNo.Focus()
                Exit Sub
            End If
            If EMAILExits() = True Then
                msgbox("Email already exists")
                txtEmail.Focus()
                Exit Sub
            End If
            If (Len(cmbCountry.Text) < 1) Then
                msgbox("Select country of Incorporation")
                cmbCountry.Focus()
                Exit Sub
            End If
            If (Len(txtAddress1.Text) < 1) Then
                msgbox("Please enter Office Address")
                txtAddress1.Focus()
                Exit Sub
            End If
            If (Len(txtfullname.Text) < 1) Then
                msgbox("Please Enter full name")
                txtfullname.Focus()
                Exit Sub
            End If
            If (Len(txtEmail.Text) < 1) Then
                msgbox("Please Enter Email")
                txtEmail.Focus()
                Exit Sub
            End If
            If (Len(cmbBankDiv.Text) < 1) Then
                msgbox("Please Select bank")
                cmbBankDiv.Focus()
                Exit Sub
            End If
            If (Len(txtBranchDiv.Text) < 1) Then
                msgbox("Please Enter branch")
                txtBranchDiv.Focus()
                Exit Sub
            End If
            If (Len(txtPayee2.Text) < 1) Then
                msgbox("Please enter Account Name")
                txtPayee2.Focus()
                Exit Sub
            End If
            If Len(txtIBAN.Text) < 1 Then
                msgbox("Enter Account Number")
                txtIBAN.Focus()
                Exit Sub
            End If
            If txtTel.Text.Trim = "" Then
                msgbox("Please enter telephone number")
                Exit Sub
            End If
            'End validations
            Dim BankDiv As String = ""
            If (cmbBankDiv.Text.Trim <> "") Then
                BankDiv = cmbBankDiv.SelectedItem.Value
            Else
                BankDiv = ""
            End If

            Dim cdsNo As String = ""
            Dim dsi As New DataSet
            cmd = New SqlCommand("SELECT 'EWH'+RIGHT('00000000000'+CONVERT(NVARCHAR(50),CASE WHEN ISNULL(MAX(dbo.udf_GetNumeric(A.CDS_Number)),0)=0 THEN 1 ELSE ISNULL(MAX(dbo.udf_GetNumeric(A.CDS_Number)),0)+1 END),7) as NewCDS FROM (SELECT DISTINCT CDS_Number FROM Accounts_Audit UNION SELECT DISTINCT CDS_Number FROM Accounts_Clients)A", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(dsi, "Accounts_Audit")
            If (dsi.Tables(0).Rows.Count > 0) Then
                cdsNo = dsi.Tables(0).Rows(0).Item("NewCDS").ToString
            Else
                cdsNo = "EWH0000000"
            End If

            cmd = New SqlCommand("insert into Accounts_Audit (cdcnumber,SOI,Nominee_CNIC,AgreementDate,Nominee_Address,CNIC_expiry_date,placeofissue,resident_status,Provinces,BusCommenceDate,PostCode,CDS_Number,BrokerCode,AccountType,Surname,Middlename,Forenames,Initials,Title,IDNoPP,IDtype,Nationality,DOB,Gender,Add_1,Add_2,Add_3,Add_4,Country,City,Tel,Mobile,Email,Category,Custodian,TradingStatus,Industry,Tax,Div_Bank,Div_Branch,Div_AccountNo,Cash_Bank,Cash_Branch,Cash_AccountNo,Date_Created,Update_Type,Created_By,AuthorizationState,DivPayee,SettlementPayee,idnopp2, idtype2, isin, company_code,IBAN,BankAccount_Type,Confirmation,FirstWitnessName , FirstWitnessCNIC , SecondWitnessName , SecondWitnessCNIC,contactpersonname,NationalTax,SalesTaxRegistration,Passport,Password_expiry_date,CNIC,Designation,ExpectedRevenueCurrentYear,NetAssets) values(@cdcnumber,@SOI,@Nominee_CNIC,@AgreementDate,@Nominee_Address,@CNIC_expiry_date,@placeofissue,@resident_status,@Provinces,@BusCommenceDate,@PostCode,@CDS_Number,@BrokerCode,@AccountType,@Surname,@Middlename,@Forenames,@Initials,@Title,@IDNoPP,@IDtype,@Nationality,@DOB,@Gender,@Add_1,@Add_2,@Add_3,@Add_4,@Country,@City,@Tel,@Mobile,@Email,@Category,@Custodian,@TradingStatus,@Industry,@Tax,@Div_Bank,@Div_Branch,@Div_AccountNo,@Cash_Bank,@Cash_Branch,@Cash_AccountNo,@Date_Created,@Update_Type,@Created_By,@AuthorizationState,@DivPayee,@SettlementPayee,@idnopp2,@idtype2, @isin, @company_code,@IBAN,@BankAccount_Type,@Confirmation,@FirstWitnessName,@FirstWitnessCNIC,@SecondWitnessName,@SecondWitnessCNIC,@contactpersonname,@NationalTax,@SalesTaxRegistration,@Passport,@Password_expiry_date,@CNIC,@Designation,@ExpectedRevenueCurrentYear,@NetAssets) ", cn)
            cmd.Parameters.AddWithValue("@IDtype", cmbIDType.Text)
            cmd.Parameters.AddWithValue("@IDNoPP", txtIDNo.Text)
            cmd.Parameters.AddWithValue("@CNIC", txtIDNo.Text)
            cmd.Parameters.AddWithValue("@Surname", txtSurname.Text.ToUpper)
            cmd.Parameters.AddWithValue("@BankAccount_Type", cmbTypeofAccount.Text)
            cmd.Parameters.AddWithValue("@Add_1", txtAddress1.Text.ToUpper)
            cmd.Parameters.AddWithValue("@Add_2", txtAddress2.Text.ToUpper)
            cmd.Parameters.AddWithValue("@Country", cmbCountry.Text)
            cmd.Parameters.AddWithValue("@Nationality", cmbCountryTaxResidence.Text)
            cmd.Parameters.AddWithValue("@Designation", txtNatureOfBusiness.Text)
            cmd.Parameters.AddWithValue("@DOB", validateDate(txtDOB.Text))
            cmd.Parameters.AddWithValue("@SOI", txtSourceofFunds.Text)
            cmd.Parameters.AddWithValue("@Industry", cmbInvestorType.Text)
            cmd.Parameters.AddWithValue("@contactpersonname", txtfullname.Text)
            cmd.Parameters.AddWithValue("@Tel", txtTel.Text)
            cmd.Parameters.AddWithValue("@Mobile", txtTel.Text)
            cmd.Parameters.AddWithValue("@PostCode", txtFax.Text)
            cmd.Parameters.AddWithValue("@Email", txtEmail.Text.ToString.ToLower)
            cmd.Parameters.AddWithValue("@DivPayee", txtPayee2.Text.ToUpper)
            cmd.Parameters.AddWithValue("@Div_AccountNo", txtIBAN.Text)
            cmd.Parameters.AddWithValue("@IBAN", txtIBAN.Text)
            cmd.Parameters.AddWithValue("@Div_Bank", BankDiv)
            cmd.Parameters.AddWithValue("@Div_Branch", txtBranchDiv.Text)
            cmd.Parameters.AddWithValue("@SettlementPayee", txtBankAddress.Text.ToUpper)
            cmd.Parameters.AddWithValue("@Cash_AccountNo", txtSwiftCode.Text)
            cmd.Parameters.AddWithValue("@CDS_Number", cdsNo)
            cmd.Parameters.AddWithValue("@BrokerCode", Session("BrokerCode"))
            cmd.Parameters.AddWithValue("@AccountType", "C")
            cmd.Parameters.AddWithValue("@Date_Created", Now.Date)
            cmd.Parameters.AddWithValue("@Update_Type", "NEW")
            cmd.Parameters.AddWithValue("@Created_By", Session("username"))
            cmd.Parameters.AddWithValue("@AuthorizationState", "O")
            cmd.Parameters.AddWithValue("@TradingStatus", "Trading")
            cmd.Parameters.AddWithValue("@idnopp2", " ")
            cmd.Parameters.AddWithValue("@idtype2", " ")
            cmd.Parameters.AddWithValue("@isin", " ")
            cmd.Parameters.AddWithValue("@company_code", " ")
            cmd.Parameters.AddWithValue("@AgreementDate", validateDate(" "))
            cmd.Parameters.AddWithValue("@Nominee_Address", " ")
            cmd.Parameters.AddWithValue("@CNIC_expiry_date", validateDate(" "))
            cmd.Parameters.AddWithValue("@placeofissue", " ")
            cmd.Parameters.AddWithValue("@resident_status", " ")
            cmd.Parameters.AddWithValue("@Provinces", " ")
            cmd.Parameters.AddWithValue("@BusCommenceDate", validateDate(" "))
            cmd.Parameters.AddWithValue("@Middlename", " ")
            cmd.Parameters.AddWithValue("@Forenames", " ")
            cmd.Parameters.AddWithValue("@Initials", " ")
            cmd.Parameters.AddWithValue("@Title", " ")
            cmd.Parameters.AddWithValue("@Gender", " ")
            cmd.Parameters.AddWithValue("@Add_3", " ")
            cmd.Parameters.AddWithValue("@Add_4", " ")
            cmd.Parameters.AddWithValue("@City", " ")
            cmd.Parameters.AddWithValue("@Category", " ")
            cmd.Parameters.AddWithValue("@Custodian", " ")
            cmd.Parameters.AddWithValue("@Tax", " ")
            cmd.Parameters.AddWithValue("@Cash_Bank", " ")
            cmd.Parameters.AddWithValue("@Cash_Branch", " ")
            cmd.Parameters.AddWithValue("@Confirmation", " ")
            cmd.Parameters.AddWithValue("@FirstWitnessName", " ")
            cmd.Parameters.AddWithValue("@FirstWitnessCNIC", " ")
            cmd.Parameters.AddWithValue("@SecondWitnessName", " ")
            cmd.Parameters.AddWithValue("@SecondWitnessCNIC", " ")
            cmd.Parameters.AddWithValue("@NationalTax", " ")
            cmd.Parameters.AddWithValue("@SalesTaxRegistration", " ")
            cmd.Parameters.AddWithValue("@Passport", " ")
            cmd.Parameters.AddWithValue("@Password_expiry_date", validateDate(" "))
            cmd.Parameters.AddWithValue("@Nominee_CNIC", " ")
            cmd.Parameters.AddWithValue("@ExpectedRevenueCurrentYear", " ")
            cmd.Parameters.AddWithValue("@NetAssets", " ")
            cmd.Parameters.AddWithValue("@cdcnumber", txtcdcnumber.Text)
            If (cn.State = ConnectionState.Open) Then
                cn.Close()
            End If
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()
            Dim CommitString = "  UPDATE Client_AssetManagers SET ClientNo='" & cdsNo & "' WHERE IDNo='" & txtIDNo.Text & "' and isnull(ClientNo,'')=''  "
            CommitString = CommitString & "  UPDATE Client_AssetManagersAudit SET ClientNo='" & cdsNo & "' WHERE IDNo='" & txtIDNo.Text & "' and isnull(ClientNo,'')='' "
            cmd = New SqlCommand(" update accounts_documents Set doc_generated='" + cdsNo + "' where CreatedBy='" & Session("Username") & "' and idno='" + txtIDNo.Text + "' " & CommitString, cn)
            If (cn.State = ConnectionState.Open) Then
                cn.Close()
            End If
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()
            Session("numb") = ""
            Session("finish") = "yes"
            Session("updatemsg") = "You have successfully submitted a New Corporate Account, Account No. " & cdsNo & " pending authorisation"
            Response.Redirect(Request.RawUrl)
        Catch ex As Exception
            ErrorLogging.WriteLogFile(Session("Username"), Request.Url.ToString, ex.ToString)
        End Try
    End Sub
    Protected Sub ASPxButton9_Click(sender As Object, e As EventArgs) Handles ASPxButton9.Click
        SaveNewAccount()
    End Sub
    Public Function InsertUpdateData(ByVal cmd As SqlCommand) As Boolean
        Dim strConnString As String = (System.Configuration.ConfigurationManager.AppSettings("connpath"))
        Dim con As New SqlConnection(strConnString)
        cmd.CommandType = CommandType.Text
        cmd.Connection = con
        Try
            con.Open()
            cmd.ExecuteNonQuery()
            Return True
        Catch ex As Exception
            Response.Write(ex.Message)
            Return False
        Finally
            con.Close()
            con.Dispose()
        End Try
    End Function
    Public Sub checkupload()
        Dim filePath As String = FileUpload1.PostedFile.FileName
        Dim filename As String = Path.GetFileName(filePath)
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
        If Session("numb") = "" Then
            numb = 5
            codec = CreateRandomPassword(Integer.Parse(numb))
            Session("numb") = codec
        End If
        Dim docname As String = ""
        If txtdocumentname.SelectedItem.Text = "Other" Then
            docname = txtotherdoc.Text
            If docname = "" Then
                msgbox("Please enter document name!")
                Exit Sub
            End If
        Else
            docname = txtdocumentname.Text
        End If
        If contenttype <> String.Empty Then
            Dim fs As Stream = FileUpload1.PostedFile.InputStream
            Dim br As New BinaryReader(fs)
            Dim bytes As Byte() = br.ReadBytes(fs.Length)

            'insert the file into database 
            Dim strQuery As String = "insert into Accounts_Documents" & "(doc_generated, Name, ContentType, Data,idno,CreatedBy)" & " values (@doc_generated,@Name, @ContentType, @Data,@idno,@CreatedBy)"
            Dim cmd As New SqlCommand(strQuery)
            cmd.Parameters.Add("@doc_generated", SqlDbType.VarChar).Value = Session("numb")
            cmd.Parameters.Add("@Name", SqlDbType.VarChar).Value = "" + docname + ""
            cmd.Parameters.Add("@ContentType", SqlDbType.VarChar).Value = contenttype
            cmd.Parameters.Add("@Data", SqlDbType.Binary).Value = bytes
            cmd.Parameters.Add("@idno", SqlDbType.VarChar).Value = "" + txtIDNo.Text + ""
            cmd.Parameters.Add("@CreatedBy", SqlDbType.VarChar).Value = "" + Session("Username") + ""
            InsertUpdateData(cmd)
            getuploaded()
            txtdocumentname.Text = ""
            txtotherdoc.Text = ""
            txtotherdoc.Visible = False
            msgbox("Document Uploaded")
        Else
            msgbox("File format not recognised." _
            & " Upload Image/Word/PDF formats")
        End If
    End Sub
    Protected Sub ASPxButton10_Click(sender As Object, e As EventArgs) Handles ASPxButton10.Click
        checkupload()
    End Sub
    Public Sub getuploaded()
        Dim dsid2 As New DataSet
        cmd = New SqlCommand("select id, name, contenttype from accounts_documents where CreatedBy='" & Session("Username") & "' and idno='" + txtIDNo.Text + "'", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(dsid2, "jointn")
        If (dsid2.Tables(0).Rows.Count > 0) Then
            ASPxGridView1.DataSource = dsid2
            ASPxGridView1.DataBind()
        Else
            ASPxGridView1.DataSource = Nothing
            ASPxGridView1.DataBind()
        End If
    End Sub
    Public Sub validateidnumber()
        If (txtIDNo.Text <> "") Then
            Dim dsid As New DataSet
            cmd = New SqlCommand("Select IDNoPP from Accounts_Audit where idnopp=@idnopp  union Select IDNoPP from Accounts_Clients where idnopp=@idnopp", cn) 'idnopp2='" & txtIDNo.Text & "' or idnopp='" + txtIDNo.Text + "'
            cmd.Parameters.AddWithValue("@idnopp", txtIDNo.Text)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(dsid, "Accounts_Audit")
            If (dsid.Tables(0).Rows.Count > 0) Then
                msgbox("Identification already exists")
                Exit Sub
            Else
                'check aml list 
                Dim dsid2 As New DataSet
                cmd = New SqlCommand("Select * from AML_List where id_number=@id_number", cn)
                cmd.Parameters.AddWithValue("@id_number", txtIDNo.Text)
                adp = New SqlDataAdapter(cmd)
                adp.Fill(dsid2, "AMList")
                If (dsid2.Tables(0).Rows.Count > 0) Then
                    msgbox("ID Number is black listed under AML.")
                    Exit Sub
                    'check aml list
                Else
                    btnJadd0.Enabled = False
                    txtIDNo.Enabled = False
                    cmbIDType.Enabled = False
                    show()
                End If
            End If
        Else
            msgbox("Please first provide all the details required!")
        End If
    End Sub
    Sub show()
        Panel10g.Visible = True
        CORP1.Visible = True
        CORP2.Visible = True
        p1.Visible = True
        p5.Visible = True
        p6.Visible = True
        p7.Visible = True
        p8.Visible = True
        Panel8a.Visible = True
        p10.Visible = True
        p12.Visible = True
        p13.Visible = True
        p20.Visible = True
        p21.Visible = True
        p22.Visible = True
        p23.Visible = True
        p24.Visible = True
        p25.Visible = True
        p26.Visible = True
        p27.Visible = True
        p28.Visible = True
        p29.Visible = True
        p30.Visible = True
        Panel3bbbbc.Visible = True
        Panel3bbbbn.Visible = True
        Panel3bbbbx.Visible = True
        panel00002.Visible = True
        panel00003.Visible = True
        Panel3bb.Visible = True
        Panel3bbb.Visible = True
        Panel3bbbb.Visible = True
    End Sub
    Function validateDate(inp As String) As Object
        'Return IIf(IsNumeric(toMoney(inp)), DBNull.Value, inp)
        Return IIf(Trim(inp) = "" Or Not IsDate(inp), DBNull.Value, inp)
    End Function
    Protected Sub btnSaveWIP_Click(sender As Object, e As EventArgs) Handles btnSaveWIP.Click
        saveWIPCOOP()
    End Sub
    Protected Sub grdWIP_RowCommand(sender As Object, e As DevExpress.Web.ASPxGridView.ASPxGridViewRowCommandEventArgs)
        Dim myID As String = e.KeyValue.ToString
        getExistingWIP(myID)
    End Sub
    Public Sub loadallWIP()
        Dim ds As New DataSet
        cmd = New SqlCommand("  Select *  from Accounts_Audit_temp where AccountType IN ('C') AND CreatedBy='" & Session("Username") & "' and IDNoPP NOT IN (SELECT DISTINCT r.IDNoPP FROM Accounts_Audit r UNION SELECT DISTINCT p.IDNoPP FROM Accounts_Clients p) and Closed=0 order by id desc ", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "Accounts_Audit_temp")
        If (ds.Tables(0).Rows.Count > 0) Then
            grdWIP.DataSource = ds
            grdWIP.DataBind()
        Else
            grdWIP.DataSource = Nothing
            grdWIP.DataBind()
        End If
    End Sub
    Public Sub getExistingWIP(ByVal RecID As String)
        Dim ds As New DataSet
        cmd = New SqlCommand("select FORMAT(TRY_PARSE(CNIC_expiry_date as date),'dd MMMM yyyy','en-us') as CNICExpiry1,FORMAT(TRY_PARSE(Password_expiry_date as date),'dd MMMM yyyy','en-us') as PassportExpiry1,CASE WHEN AgreementDate IS NULL THEN '' ELSE FORMAT(CONVERT(DATE,AgreementDate),'dd MMMM yyyy','en-us')  END AS AgreementDate1,CASE WHEN BusCommenceDate IS NULL THEN '' ELSE FORMAT(CONVERT(DATE,BusCommenceDate),'dd MMMM yyyy','en-us')  END AS BusCommenceDate1,CASE WHEN DOB IS NULL THEN '' ELSE FORMAT(CONVERT(DATE,DOB),'dd MMMM yyyy','en-us')  END AS DOB1,*,CASE WHEN AccountType='I' THEN 'Single' when AccountType='J' THEN 'Joint' when AccountType='C' THEN 'Corporate' else AccountType end as myAccType from Accounts_Audit_temp where ID='" & RecID & "'", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "Accounts_Audit_temp")
        If (ds.Tables(0).Rows.Count > 0) Then
            Try
                cmbIDType.Value = ds.Tables(0).Rows(0).Item("IDtype").ToString
            Catch ex As Exception
                cmbIDType.SelectedIndex = -1
            End Try
            txtIDNo.Text = ds.Tables(0).Rows(0).Item("IDNoPP").ToString
            Try
                cmbIDType.Value = ds.Tables(0).Rows(0).Item("IDtype").ToString
            Catch ex As Exception
                cmbIDType.SelectedIndex = -1
            End Try
            txtIDNo.Text = ds.Tables(0).Rows(0).Item("IDNoPP").ToString
            txtSurname.Text = ds.Tables(0).Rows(0).Item("surname").ToString
            txtDOB.Text = ds.Tables(0).Rows(0).Item("DOB1").ToString
            txtAddress1.Text = ds.Tables(0).Rows(0).Item("Add_1").ToString
            Try
                cmbCountry.Value = ds.Tables(0).Rows(0).Item("Country").ToString
            Catch ex As Exception
                cmbCountry.SelectedIndex = -1
            End Try
            txtfullname.Text = ds.Tables(0).Rows(0).Item("contactpersonname").ToString
            txtTel.Text = ds.Tables(0).Rows(0).Item("Tel").ToString
            txtEmail.Text = ds.Tables(0).Rows(0).Item("Email").ToString
            txtPayee2.Text = ds.Tables(0).Rows(0).Item("DivPayee").ToString
            Try
                cmbBankDiv.Value = ds.Tables(0).Rows(0).Item("Div_Bank").ToString
            Catch ex As Exception
                cmbBankDiv.SelectedIndex = -1
            End Try
            txtBranchDiv.Value = ds.Tables(0).Rows(0).Item("Div_Branch").ToString
            txtIBAN.Text = ds.Tables(0).Rows(0).Item("IBAN").ToString
            getuploaded()
            Session("WIP") = "WIP"
            btnJadd0_Click(sender:=New Object, e:=New EventArgs)
            Session("WIP") = ""
        End If
    End Sub
    Public Sub saveWIPCOOP()
        Dim BankDiv As String = ""
        If (cmbBankDiv.Items.Count > 0) Then
            If (cmbBankDiv.SelectedIndex > -1) Then
                BankDiv = cmbBankDiv.SelectedItem.Value
            Else
                BankDiv = ""
            End If
        Else
            BankDiv = ""
        End If


        Dim strCMD As String = ""
        strCMD = strCMD & " if not exists(select top 1 * from Accounts_Audit_temp where IDNoPP=@IDNoPP AND CreatedBy=@CreatedBy AND AccountType='C') begin "
        strCMD = strCMD & " insert into Accounts_Audit_Temp (SOI,Nominee_CNIC,AgreementDate,CreatedBy,Nominee_Address,CNIC_expiry_date,placeofissue,resident_status,Provinces,BusCommenceDate,PostCode,CDS_Number,BrokerCode,AccountType,Surname,Middlename,Forenames,Initials,Title,IDNoPP,IDtype,Nationality,DOB,Gender,Add_1,Add_2,Add_3,Add_4,Country,City,Tel,Mobile,Email,Category,Custodian,TradingStatus,Industry,Tax,Div_Bank,Div_Branch,Div_AccountNo,Cash_Bank,Cash_Branch,Cash_AccountNo,Date_Created,Update_Type,Created_By,AuthorizationState,DivPayee,SettlementPayee,idnopp2, idtype2, isin, company_code,IBAN,BankAccount_Type,Confirmation,FirstWitnessName , FirstWitnessCNIC , SecondWitnessName , SecondWitnessCNIC,contactpersonname,NationalTax,SalesTaxRegistration,Passport,Password_expiry_date,CNIC,Designation,ExpectedRevenueCurrentYear,NetAssets) values(@SOI,@Nominee_CNIC,@AgreementDate,@CreatedBy,@Nominee_Address,@CNIC_expiry_date,@placeofissue,@resident_status,@Provinces,@BusCommenceDate,@PostCode,@CDS_Number,@BrokerCode,@AccountType,@Surname,@Middlename,@Forenames,@Initials,@Title,@IDNoPP,@IDtype,@Nationality,@DOB,@Gender,@Add_1,@Add_2,@Add_3,@Add_4,@Country,@City,@Tel,@Mobile,@Email,@Category,@Custodian,@TradingStatus,@Industry,@Tax,@Div_Bank,@Div_Branch,@Div_AccountNo,@Cash_Bank,@Cash_Branch,@Cash_AccountNo,@Date_Created,@Update_Type,@Created_By,@AuthorizationState,@DivPayee,@SettlementPayee,@idnopp2,@idtype2, @isin, @company_code,@IBAN,@BankAccount_Type,@Confirmation,@FirstWitnessName,@FirstWitnessCNIC,@SecondWitnessName,@SecondWitnessCNIC,@contactpersonname,@NationalTax,@SalesTaxRegistration,@Passport,@Password_expiry_date,@CNIC,@Designation,@ExpectedRevenueCurrentYear,@NetAssets) "
        strCMD = strCMD & " end else begin "
        strCMD = strCMD & " UPDATE Accounts_Audit_Temp SET  SOI=@SOI,Nominee_CNIC=@Nominee_CNIC,AgreementDate=@AgreementDate,Nominee_Address=@Nominee_Address,CNIC_expiry_date=@CNIC_expiry_date,placeofissue=@placeofissue,resident_status=@resident_status,Provinces=@Provinces,BusCommenceDate=@BusCommenceDate,PostCode=@PostCode,CDS_Number=@CDS_Number,BrokerCode=@BrokerCode,Surname=@Surname,Middlename=@Middlename,Forenames=@Forenames,Initials=@Initials,Title=@Title,IDtype=@IDtype,Nationality=@Nationality,DOB=@DOB,Gender=@Gender,Add_1=@Add_1,Add_2=@Add_2,Add_3=@Add_3,Add_4=@Add_4,Country=@Country,City=@City,Tel=@Tel,Mobile=@Mobile,Email=@Email,Category=@Category,Custodian=@Custodian,TradingStatus=@TradingStatus,Industry=@Industry,Tax=@Tax,Div_Bank=@Div_Bank,Div_Branch=@Div_Branch,Div_AccountNo=@Div_AccountNo,Cash_Bank=@Cash_Bank,Cash_Branch=@Cash_Branch,Cash_AccountNo=@Cash_AccountNo,DivPayee=@DivPayee,SettlementPayee=@SettlementPayee,idnopp2=@idnopp2, idtype2=@idtype2, isin=@isin, company_code=@company_code,IBAN=@IBAN,BankAccount_Type=@BankAccount_Type,Confirmation=@Confirmation,FirstWitnessName=@FirstWitnessName , FirstWitnessCNIC=@FirstWitnessCNIC , SecondWitnessName=@SecondWitnessName , SecondWitnessCNIC=@SecondWitnessCNIC,contactpersonname=@contactpersonname,NationalTax=@NationalTax,SalesTaxRegistration=@SalesTaxRegistration,Passport=@Passport,Password_expiry_date=@Password_expiry_date,CNIC=@CNIC,Designation=@Designation,ExpectedRevenueCurrentYear=ExpectedRevenueCurrentYear,NetAssets=@NetAssets  WHERE IDNoPP=@IDNoPP AND CreatedBy=@CreatedBy AND AccountType='C' "
        strCMD = strCMD & "  end "
        cmd = New SqlCommand(strCMD, cn)
        cmd.Parameters.AddWithValue("@IDtype", cmbIDType.Text)
        cmd.Parameters.AddWithValue("@IDNoPP", txtIDNo.Text)
        cmd.Parameters.AddWithValue("@Surname", txtSurname.Text.ToUpper)
        cmd.Parameters.AddWithValue("@BankAccount_Type", cmbTypeofAccount.Text)
        cmd.Parameters.AddWithValue("@Add_1", txtAddress1.Text.ToUpper)
        cmd.Parameters.AddWithValue("@Add_2", txtAddress2.Text.ToUpper)
        cmd.Parameters.AddWithValue("@Country", cmbCountry.Text)
        cmd.Parameters.AddWithValue("@Nationality", cmbCountryTaxResidence.Text)
        cmd.Parameters.AddWithValue("@Designation", txtNatureOfBusiness.Text)
        cmd.Parameters.AddWithValue("@DOB", validateDate(txtDOB.Text))
        cmd.Parameters.AddWithValue("@SOI", txtSourceofFunds.Text)
        cmd.Parameters.AddWithValue("@Industry", cmbInvestorType.Text)
        cmd.Parameters.AddWithValue("@contactpersonname", txtfullname.Text)
        cmd.Parameters.AddWithValue("@Tel", txtTel.Text)
        cmd.Parameters.AddWithValue("@PostCode", txtFax.Text)
        cmd.Parameters.AddWithValue("@Email", txtEmail.Text.ToString.ToLower)
        cmd.Parameters.AddWithValue("@DivPayee", txtPayee2.Text.ToUpper)
        cmd.Parameters.AddWithValue("@Div_AccountNo", txtIBAN.Text)
        cmd.Parameters.AddWithValue("@Div_Bank", BankDiv)
        cmd.Parameters.AddWithValue("@Div_Branch", txtBranchDiv.Text)
        cmd.Parameters.AddWithValue("@SettlementPayee", txtBankAddress.Text.ToUpper)
        cmd.Parameters.AddWithValue("@Cash_AccountNo", txtSwiftCode.Text)
        cmd.Parameters.AddWithValue("@CDS_Number", " ")
        cmd.Parameters.AddWithValue("@BrokerCode", Session("BrokerCode"))
        cmd.Parameters.AddWithValue("@AccountType", "C")
        cmd.Parameters.AddWithValue("@Mobile", txtTel.Text)
        cmd.Parameters.AddWithValue("@IBAN", txtIBAN.Text)
        cmd.Parameters.AddWithValue("@CNIC", txtIDNo.Text)
        cmd.Parameters.AddWithValue("@Date_Created", Now.Date)
        cmd.Parameters.AddWithValue("@Update_Type", "NEW")
        cmd.Parameters.AddWithValue("@Created_By", Session("username"))
        cmd.Parameters.AddWithValue("@AuthorizationState", "O")
        cmd.Parameters.AddWithValue("@TradingStatus", "Trading")
        cmd.Parameters.AddWithValue("@idnopp2", " ")
        cmd.Parameters.AddWithValue("@idtype2", " ")
        cmd.Parameters.AddWithValue("@isin", " ")
        cmd.Parameters.AddWithValue("@company_code", " ")
        cmd.Parameters.AddWithValue("@AgreementDate", validateDate(" "))
        cmd.Parameters.AddWithValue("@Nominee_Address", " ")
        cmd.Parameters.AddWithValue("@CNIC_expiry_date", validateDate(" "))
        cmd.Parameters.AddWithValue("@placeofissue", " ")
        cmd.Parameters.AddWithValue("@resident_status", " ")
        cmd.Parameters.AddWithValue("@Provinces", " ")
        cmd.Parameters.AddWithValue("@BusCommenceDate", validateDate(" "))
        cmd.Parameters.AddWithValue("@Middlename", " ")
        cmd.Parameters.AddWithValue("@Forenames", " ")
        cmd.Parameters.AddWithValue("@Initials", " ")
        cmd.Parameters.AddWithValue("@Title", " ")
        cmd.Parameters.AddWithValue("@Gender", " ")
        cmd.Parameters.AddWithValue("@Add_3", " ")
        cmd.Parameters.AddWithValue("@Add_4", " ")
        cmd.Parameters.AddWithValue("@City", " ")
        cmd.Parameters.AddWithValue("@Category", " ")
        cmd.Parameters.AddWithValue("@Custodian", " ")
        cmd.Parameters.AddWithValue("@Tax", " ")
        cmd.Parameters.AddWithValue("@Cash_Bank", " ")
        cmd.Parameters.AddWithValue("@Cash_Branch", " ")
        cmd.Parameters.AddWithValue("@Confirmation", " ")
        cmd.Parameters.AddWithValue("@FirstWitnessName", " ")
        cmd.Parameters.AddWithValue("@FirstWitnessCNIC", " ")
        cmd.Parameters.AddWithValue("@SecondWitnessName", " ")
        cmd.Parameters.AddWithValue("@SecondWitnessCNIC", " ")
        cmd.Parameters.AddWithValue("@NationalTax", " ")
        cmd.Parameters.AddWithValue("@SalesTaxRegistration", " ")
        cmd.Parameters.AddWithValue("@Passport", " ")
        cmd.Parameters.AddWithValue("@Password_expiry_date", validateDate(" "))
        cmd.Parameters.AddWithValue("@Nominee_CNIC", " ")
        cmd.Parameters.AddWithValue("@ExpectedRevenueCurrentYear", " ")
        cmd.Parameters.AddWithValue("@NetAssets", " ")
        If (cn.State = ConnectionState.Open) Then
            cn.Close()
        End If
        cn.Open()
        cmd.ExecuteNonQuery()
        cn.Close()
        loadallWIP()
        msgbox("Work in progress saved")
    End Sub
    Protected Sub txtdocumentname_SelectedIndexChanged(sender As Object, e As EventArgs) Handles txtdocumentname.SelectedIndexChanged
        If txtdocumentname.SelectedItem.Text = "Other" Then
            txtotherdoc.Visible = True
        Else
            txtotherdoc.Visible = False
        End If
    End Sub
    Protected Sub ASPxGridView1_RowCommand(sender As Object, e As DevExpress.Web.ASPxGridView.ASPxGridViewRowCommandEventArgs) Handles ASPxGridView1.RowCommand
        Try
            Dim myID As String = e.CommandArgs.CommandArgument.ToString
            If e.CommandArgs.CommandName = "Delete" Then
                Using cn = New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("connpath"))
                    Using cmd As New SqlCommand("DELETE FROM Accounts_Documents WHERE ID='" & myID & "'", cn)
                        If cn.State = ConnectionState.Open Then cn.Close()
                        cn.Open()
                        cmd.ExecuteNonQuery()
                        cn.Close()
                        getuploaded()
                    End Using
                End Using
            End If
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        Try
            cmd = New SqlCommand("delete Accounts_Print where PrintBy=@PrintBy", cn)
            cmd.Parameters.AddWithValue("@PrintBy", Session("Username"))
            If (cn.State = ConnectionState.Open) Then
                cn.Close()
            End If
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()
            Dim BankDiv As String = ""
            If (cmbBankDiv.Text.Trim <> "") Then
                BankDiv = cmbBankDiv.Value
            Else
                BankDiv = ""
            End If

            cmd = New SqlCommand("insert into Accounts_Print (SOI,PrintBy,Nominee_CNIC,AgreementDate,Nominee_ress,CNICExpiry,placeofissue,resident_status,Provinces,BusCommenceDate,PostCode,CDS_Number,BrokerCode,AccountType,Surname,Middlename,Forenames,Initials,Title,IDNoPP,IDtype,Nationality,DOB,Gender,Add_1,Add_2,Add_3,Add_4,Country,City,Tel,Mobile,Email,Category,Custodian,TradingStatus,Industry,Tax,Div_Bank,Div_Branch,Div_AccountNo,Cash_Bank,Cash_Branch,Cash_AccountNo,Date_Created,Update_Type,Created_By,DivPayee,SettlementPayee,idnopp2, idtype2, isin, company_code,IBAN,BankAccount_Type,Confirmation,FirstWitnessName , FirstWitnessCNIC , SecondWitnessName , SecondWitnessCNIC,contactpersonname,NationalTax,SalesTaxRegistration,Passport,PassportExpiry,CNIC,Designation,ExpectedRevenueCurrentYear,NetAssets) values(@SOI,@PrintBy,@Nominee_CNIC,@AgreementDate,@Nominee_Address,@CNIC_expiry_date,@placeofissue,@resident_status,@Provinces,@BusCommenceDate,@PostCode,@CDS_Number,@BrokerCode,@AccountType,@Surname,@Middlename,@Forenames,@Initials,@Title,@IDNoPP,@IDtype,@Nationality,@DOB,@Gender,@Add_1,@Add_2,@Add_3,@Add_4,@Country,@City,@Tel,@Mobile,@Email,@Category,@Custodian,@TradingStatus,@Industry,@Tax,@Div_Bank,@Div_Branch,@Div_AccountNo,@Cash_Bank,@Cash_Branch,@Cash_AccountNo,@Date_Created,@Update_Type,@Created_By,@DivPayee,@SettlementPayee,@idnopp2,@idtype2, @isin, @company_code,@IBAN,@BankAccount_Type,@Confirmation,@FirstWitnessName,@FirstWitnessCNIC,@SecondWitnessName,@SecondWitnessCNIC,@contactpersonname,@NationalTax,@SalesTaxRegistration,@Passport,@Password_expiry_date,@CNIC,@Designation,@ExpectedRevenueCurrentYear,@NetAssets) ", cn)
            cmd.Parameters.AddWithValue("@PrintBy", Session("username"))
            cmd.Parameters.AddWithValue("@IDtype", cmbIDType.Text)
            cmd.Parameters.AddWithValue("@IDNoPP", txtIDNo.Text)
            cmd.Parameters.AddWithValue("@Surname", txtSurname.Text.ToUpper)
            cmd.Parameters.AddWithValue("@BankAccount_Type", cmbTypeofAccount.Text)
            cmd.Parameters.AddWithValue("@Add_1", txtAddress1.Text.ToUpper)
            cmd.Parameters.AddWithValue("@Add_2", txtAddress2.Text.ToUpper)
            cmd.Parameters.AddWithValue("@Country", cmbCountry.Text)
            cmd.Parameters.AddWithValue("@Nationality", cmbCountryTaxResidence.Text)
            cmd.Parameters.AddWithValue("@Designation", txtNatureOfBusiness.Text)
            cmd.Parameters.AddWithValue("@DOB", validateDate(txtDOB.Text))
            cmd.Parameters.AddWithValue("@SOI", txtSourceofFunds.Text)
            cmd.Parameters.AddWithValue("@Industry", cmbInvestorType.Text)
            cmd.Parameters.AddWithValue("@contactpersonname", txtfullname.Text)
            cmd.Parameters.AddWithValue("@Tel", txtTel.Text)
            cmd.Parameters.AddWithValue("@PostCode", txtFax.Text)
            cmd.Parameters.AddWithValue("@Email", txtEmail.Text.ToString.ToLower)
            cmd.Parameters.AddWithValue("@DivPayee", txtPayee2.Text.ToUpper)
            cmd.Parameters.AddWithValue("@Div_AccountNo", txtIBAN.Text)
            cmd.Parameters.AddWithValue("@Div_Bank", BankDiv)
            cmd.Parameters.AddWithValue("@Div_Branch", txtBranchDiv.Text)
            cmd.Parameters.AddWithValue("@SettlementPayee", txtBankAddress.Text.ToUpper)
            cmd.Parameters.AddWithValue("@Cash_AccountNo", txtSwiftCode.Text)
            cmd.Parameters.AddWithValue("@CDS_Number", " ")
            cmd.Parameters.AddWithValue("@BrokerCode", Session("BrokerCode"))
            cmd.Parameters.AddWithValue("@AccountType", "C")
            cmd.Parameters.AddWithValue("@Mobile", txtTel.Text)
            cmd.Parameters.AddWithValue("@IBAN", txtIBAN.Text)
            cmd.Parameters.AddWithValue("@CNIC", txtIDNo.Text)
            cmd.Parameters.AddWithValue("@Date_Created", Now.Date)
            cmd.Parameters.AddWithValue("@Update_Type", "NEW")
            cmd.Parameters.AddWithValue("@Created_By", Session("username"))
            cmd.Parameters.AddWithValue("@AuthorizationState", "O")
            cmd.Parameters.AddWithValue("@TradingStatus", "Trading")
            cmd.Parameters.AddWithValue("@idnopp2", " ")
            cmd.Parameters.AddWithValue("@idtype2", " ")
            cmd.Parameters.AddWithValue("@isin", " ")
            cmd.Parameters.AddWithValue("@company_code", " ")
            cmd.Parameters.AddWithValue("@AgreementDate", validateDate(" "))
            cmd.Parameters.AddWithValue("@Nominee_Address", " ")
            cmd.Parameters.AddWithValue("@CNIC_expiry_date", validateDate(" "))
            cmd.Parameters.AddWithValue("@placeofissue", " ")
            cmd.Parameters.AddWithValue("@resident_status", " ")
            cmd.Parameters.AddWithValue("@Provinces", " ")
            cmd.Parameters.AddWithValue("@BusCommenceDate", validateDate(" "))
            cmd.Parameters.AddWithValue("@Middlename", " ")
            cmd.Parameters.AddWithValue("@Forenames", " ")
            cmd.Parameters.AddWithValue("@Initials", " ")
            cmd.Parameters.AddWithValue("@Title", " ")
            cmd.Parameters.AddWithValue("@Gender", " ")
            cmd.Parameters.AddWithValue("@Add_3", " ")
            cmd.Parameters.AddWithValue("@Add_4", " ")
            cmd.Parameters.AddWithValue("@City", " ")
            cmd.Parameters.AddWithValue("@Category", " ")
            cmd.Parameters.AddWithValue("@Custodian", " ")
            cmd.Parameters.AddWithValue("@Tax", " ")
            cmd.Parameters.AddWithValue("@Cash_Bank", " ")
            cmd.Parameters.AddWithValue("@Cash_Branch", " ")
            cmd.Parameters.AddWithValue("@Confirmation", " ")
            cmd.Parameters.AddWithValue("@FirstWitnessName", " ")
            cmd.Parameters.AddWithValue("@FirstWitnessCNIC", " ")
            cmd.Parameters.AddWithValue("@SecondWitnessName", " ")
            cmd.Parameters.AddWithValue("@SecondWitnessCNIC", " ")
            cmd.Parameters.AddWithValue("@NationalTax", " ")
            cmd.Parameters.AddWithValue("@SalesTaxRegistration", " ")
            cmd.Parameters.AddWithValue("@Passport", " ")
            cmd.Parameters.AddWithValue("@Password_expiry_date", validateDate(" "))
            cmd.Parameters.AddWithValue("@Nominee_CNIC", " ")
            cmd.Parameters.AddWithValue("@ExpectedRevenueCurrentYear", " ")
            cmd.Parameters.AddWithValue("@NetAssets", " ")
            If (cn.State = ConnectionState.Open) Then
                cn.Close()
            End If
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()
            Dim queryString As String = "AccountPrintReport.aspx?Username=" + Session("Username") + "&AccType=C"
            Dim newWin As String = "window.open('" + queryString + "','_blank');"
            ClientScript.RegisterStartupScript(Me.GetType(), "pop", newWin, True)
        Catch ex As Exception
            ErrorLogging.WriteLogFile(Session("Username"), Request.Url.ToString, ex.ToString)
        End Try
    End Sub
    Private Function CNICExits() As Boolean
        Dim ds As New DataSet
        cmd = New SqlCommand("Select CNIC from Accounts_Audit where REPLACE(CNIC,'-','')= REPLACE(@idnopp,'-','') union Select CNIC from Accounts_Clients where REPLACE(CNIC,'-','')= REPLACE(@idnopp,'-','') ", cn)
        cmd.Parameters.AddWithValue("@idnopp", txtIDNo.Text)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "Accounts")
        If (ds.Tables(0).Rows.Count > 0) Then
            Return True
        Else
            Return False
        End If
    End Function
    Private Function EMAILExits() As Boolean
        Dim ds As New DataSet
        cmd = New SqlCommand("Select distinct Email from Accounts_Audit where Email= @Email union Select distinct Email from Accounts_Clients where Email= @Email union Select distinct Email from SystemUsers where Email= @Email ", cn)
        cmd.Parameters.AddWithValue("@email", txtEmail.Text)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "Accounts")
        If (ds.Tables(0).Rows.Count > 0) Then
            Return True
        Else
            Return False
        End If
    End Function
    Public Sub getAssetmanagers()
        Try
            Dim ds As New DataSet '
            cmd = New SqlCommand("select * from para_assetManager order by AssetMananger", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "para_assetManager")
            If (ds.Tables(0).Rows.Count > 0) Then
                cmbAssetManager.DataSource = ds.Tables(0)
                cmbAssetManager.TextField = "AssetMananger"
                cmbAssetManager.ValueField = "AssetManagerCode"
                cmbAssetManager.DataBind()
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Protected Sub cmbAssetManager_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbAssetManager.SelectedIndexChanged
        getAssetmanagersBanks()
    End Sub
    Sub getAssetmanagersBanks()
        Dim strSQL As String = ""
        strSQL = "SELECT * FROM para_assetManager_Banks WHERE AssetManagerCode='" & cmbAssetManager.Value & "'"
        Using cn = New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("connpath"))
            Dim ds As New DataSet
            Dim cmd = New SqlCommand(strSQL, cn)
            Dim adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "para_assetManager_Banks")
            If ds.Tables(0).Rows.Count > 0 Then
                grdSelectFromAssetmanagers.DataSource = ds
                grdSelectFromAssetmanagers.DataBind()
                dfPanel2.Visible = True
            Else
                grdSelectFromAssetmanagers.DataSource = Nothing
                grdSelectFromAssetmanagers.DataBind()
                dfPanel2.Visible = False
            End If
        End Using
    End Sub
    Protected Sub btnAddAMs_Click(sender As Object, e As EventArgs) Handles btnAddAMs.Click
        'Try
        For Each row As RepeaterItem In grdSelectFromAssetmanagers.Items
            Dim chkView As CheckBox = DirectCast(row.FindControl("chkSelect"), CheckBox)
            Dim BankCode As String = CType(row.FindControl("lblBank"), Label).Text
            Dim BranchCode As String = CType(row.FindControl("lblBranch"), Label).Text
            Dim AccountNumber As String = CType(row.FindControl("lblAccountNumber"), Label).Text
            Dim AssetManagerCode As String = CType(row.FindControl("lblAssetManagerCode"), Label).Text
            If chkView.Checked = True Then
                Using cn = New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("connpath"))
                    Using cmd As New SqlCommand("IF NOT EXISTS(SELECT TOP 1 * FROM Client_AssetManagers H WHERE H.IDNo=@IDNo AND H.AssetManager=@AssetManager AND H.BankAccount=@BankAccount) BEGIN INSERT INTO Client_AssetManagersAudit([IDNo], [AssetManager], [BankAccount], [BankName], [BankBranch], [DateLinked], [LinkedBy],[cdcnumber])VALUES(@IDNo, @AssetManager,@BankAccount,@BankName,@BankBranch,getdate(),@LinkedBy, @cdcnumber) INSERT INTO Client_AssetManagers([IDNo], [AssetManager], [BankAccount], [BankName], [BankBranch], [DateLinked], [LinkedBy], [cdcnumber])VALUES(@IDNo, @AssetManager,@BankAccount,@BankName,@BankBranch,getdate(),@LinkedBy,@cdcnumber) END", cn)
                        cmd.Parameters.AddWithValue("@IDNo", txtIDNo.Text)
                        cmd.Parameters.AddWithValue("@AssetManager", AssetManagerCode)
                        cmd.Parameters.AddWithValue("@BankAccount", AccountNumber)
                        cmd.Parameters.AddWithValue("@BankName", BankCode)
                        cmd.Parameters.AddWithValue("@BankBranch", BranchCode)
                        cmd.Parameters.AddWithValue("@LinkedBy", Session("Username"))
                        cmd.Parameters.AddWithValue("@cdcnumber", txtcdcnumber.Text)
                        If cn.State = ConnectionState.Open Then cn.Close()
                        cn.Open()
                        cmd.ExecuteNonQuery()
                        cn.Close()
                    End Using
                End Using
            End If
        Next
        getAssetmanagersClients()
        'Catch ex As Exception

        'End Try
    End Sub
    Sub getAssetmanagersClients()
        Dim strSQL As String = ""
        strSQL = "SELECT * FROM Client_AssetManagers WHERE IDNo='" & txtIDNo.Text & "'"
        Using cn = New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("connpath"))
            Dim ds As New DataSet
            Dim cmd = New SqlCommand(strSQL, cn)
            Dim adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "Client_AssetManagers")
            If ds.Tables(0).Rows.Count > 0 Then
                grdAsertManagersClients.DataSource = ds
                grdAsertManagersClients.DataBind()
            Else
                grdAsertManagersClients.DataSource = Nothing
                grdAsertManagersClients.DataBind()
            End If
        End Using
    End Sub
    Protected Sub grdAsertManagersClients_RowCommand(sender As Object, e As DevExpress.Web.ASPxGridView.ASPxGridViewRowCommandEventArgs) Handles grdAsertManagersClients.RowCommand
        Try
            Dim myID As String = e.CommandArgs.CommandArgument.ToString
            If e.CommandArgs.CommandName = "Delete" Then
                Using cn = New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("connpath"))
                    Using cmd As New SqlCommand("DELETE FROM Client_AssetManagers WHERE ID='" & myID & "'", cn)
                        If cn.State = ConnectionState.Open Then cn.Close()
                        cn.Open()
                        cmd.ExecuteNonQuery()
                        cn.Close()
                        getAssetmanagersClients()
                    End Using
                End Using
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Function IDBlacklistedAML() As Boolean
        Dim ds As New DataSet
        cmd = New SqlCommand("Select * from AML_List where id_number=@id_number ", cn)
        cmd.Parameters.AddWithValue("@id_number", txtIDNo.Text)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "AML_List")
        If (ds.Tables(0).Rows.Count > 0) Then
            Return True
        Else
            Return False
        End If
    End Function
    Protected Sub cmbIDType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbIDType.SelectedIndexChanged
        ASPxLabel30.Text = cmbIDType.SelectedItem.Text
    End Sub
End Class
