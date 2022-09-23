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
Partial Class TransferSec_AccountsCreations
    Inherits System.Web.UI.Page
    Dim constr As String = (System.Configuration.ConfigurationManager.AppSettings("connpath"))
    Dim cn As New SqlConnection(constr)
    Dim adp As SqlDataAdapter
    Dim cmd As SqlCommand
    Shared random As New Random()
    Dim Mail As New MailMessage
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
            cmd = New SqlCommand("select distinct bank,bank_name from para_bank order by Bank_name", cn)
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
    Public Sub GetCountry()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select * from para_country order by country", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "para_country")
            If (ds.Tables(0).Rows.Count > 0) Then
                cmbCountry.DataSource = ds.Tables(0)
                cmbCountry.TextField = "country"
                cmbCountry.ValueField = "country"
                cmbCountry.DataBind()
            Else
                cmbCountry.Items.Clear()
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub GetNationality()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select distinct (Nationality) from para_country order by Nationality", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "para_country")
            If (ds.Tables(0).Rows.Count > 0) Then
                cmbNationality.DataSource = ds.Tables(0)
                cmbNationality.ValueField = "Nationality"
                cmbNationality.TextField = "Nationality"
                cmbNationality.DataBind()
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Page.MaintainScrollPositionOnPostBack = True
            If (Not IsPostBack) Then
                rdIndividual.Checked = True
                GetCountry()
                GetNationality()
                getAssetmanagers()
                GetBankName()
                cmbIDType.Items.Add("ID No.")
                cmbIDType.Items.Add("Passport No.")
                txtDOB.MaxDate = Date.UtcNow.ToString
                Try
                    cmbCountry.Value = "Zimbabwe"
                    cmbNationality.Value = "Zimbabwe"
                Catch ex As Exception
                End Try
                If Session("finish") = "yes" Then
                    Session("finish") = ""
                    msgbox(Session("updatemsg"))
                    Session("updatemsg") = ""
                End If
                loadallWIP()
            End If
        Catch ex As Exception
            ErrorLogging.WriteLogFile("", "", ex.ToString)
        End Try
    End Sub
    Protected Sub rdIndividual_CheckedChanged(sender As Object, e As EventArgs) Handles rdIndividual.CheckedChanged
        Try
            If (rdIndividual.Checked = True) Then
                ShowHide_Joint1("Hide")
                ShowHide_Single("Show")
                ShowHide_Joint("Hide")
                ShowHideAll("Hide")
                panel13Enable()
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Protected Sub rdJoint_CheckedChanged(sender As Object, e As EventArgs) Handles rdJoint.CheckedChanged
        Try
            If (rdJoint.Checked = True) Then
                ShowHide_Single("Hide")
                ShowHide_Joint("Hide")
                ShowHideAll("Hide")
                ShowHide_Joint1("Show")
                panel13Enable()
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Protected Sub rdCorprate_CheckedChanged(sender As Object, e As EventArgs) Handles rdCorprate.CheckedChanged
        Try
            If rdCorprate.Checked = True Then
                Session("type") = "C"
                Response.Redirect("~/TransferSec/AccountsCreations_corp.aspx")
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Protected Sub ASPxButton5_Click(sender As Object, e As EventArgs) Handles ASPxButton5.Click
        If validateIndividualFields() = False Then
        Else
            SaveNewAccount()
        End If
    End Sub
    Public Sub validateidnumber()
        Dim vid1 As String
        Dim vid2 As String = ""
        Try
            vid1 = cmbIDType.SelectedItem.Text
        Catch ex As Exception
            vid1 = ""
        End Try
        If vid1 <> "" Then
            If (txtIDNo.Text.Trim <> "") Then
                Dim dsid As New DataSet
                cmd = New SqlCommand("Select IDNoPP from Accounts_Audit where idnopp=@idnopp union Select IDNoPP from Accounts_Clients where idnopp=@idnopp", cn)
                cmd.Parameters.AddWithValue("@idnopp", txtIDNo.Text)
                adp = New SqlDataAdapter(cmd)
                adp.Fill(dsid, "Accounts_Audit")
                If (dsid.Tables(0).Rows.Count > 0) Then
                    msgbox("Identification already exists")
                    Exit Sub
                Else
                    panel13disable()
                    txtCNIC.Enabled = False
                    txtCNIC.Text = txtIDNo.Text.Trim
                    ShowHide_Single("Show")
                    ShowHide_Joint("Hide")
                    ShowHideAll("Show")
                End If
            Else
                msgbox("Please first provide all the details required!")
            End If
        Else
        End If
    End Sub
    Sub panel13disable()
        txtSurname0.Enabled = False
        txtIDNo.Enabled = False
        cmbIDType.Enabled = False
        btnJadd0.Enabled = False
        btnJadd4.Enabled = False
    End Sub
    Sub panel13Enable()
        txtSurname0.Enabled = True
        txtIDNo.Enabled = True
        cmbIDType.Enabled = True
        btnJadd0.Enabled = True
        btnJadd4.Enabled = True
    End Sub
    Public Sub SaveNewAccount()
        Try
            If ASPxGridView1.VisibleRowCount > 0 Then
            Else
                msgbox("Please add attachments")
                Exit Sub
            End If
            Dim IDD As String = ""
            Dim BankDiv As String = ""
            If (cmbBankDiv.Text.Trim <> "") Then
                BankDiv = cmbBankDiv.Value
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

            Dim AccountType As String = ""
            Dim Gender As String = "N"
            If (rdMale.Checked = True) Then
                Gender = "M"
            End If
            If (rdFemale.Checked = True) Then
                Gender = "F"
            End If
            If (rdNa.Checked = True) Then
                Gender = "N"
            End If
            Dim myIDGlob As String = ""
            Dim myJointName As String = ""
            If (rdIndividual.Checked = True) Then
                AccountType = "I"
                myJointName = " "
                myIDGlob = txtIDNo.Text
            End If
            If (rdJoint.Checked = True) Then
                AccountType = "J"
                myJointName = txtSurname0.Text
                myIDGlob = txtCNIC.Text
            End If
            cmd = New SqlCommand("insert into Accounts_Audit (JointName,AgreementDate,PlaceofBirth,CDS_Number,BrokerCode,AccountType,Surname,Middlename,Forenames,Initials,Title,IDNoPP,IDtype,Nationality,DOB,Gender,Add_1,Add_2,Add_3,Add_4,Country,City,Tel,Mobile,Email,Category,Custodian,TradingStatus,Industry,Tax,Div_Bank,Div_Branch,Div_AccountNo,Cash_Bank,Cash_Branch,Cash_AccountNo,Date_Created,Update_Type,Created_By,AuthorizationState,DivPayee,SettlementPayee,idnopp2, idtype2, mobile_money, mobile_number,FH,marital_status,Occupations,SOI,GAI,CNIC,CNIC_expiry_date,Passport,Password_expiry_date,NTN,Permanet_Address,Permanet_Address1,Permanet_Address2,Permanet_Address3,Provinces,PostCode,Designation,Resident_Status,IBAN,BankAccount_Type,Confirmation,FirstWitnessName , FirstWitnessCNIC , SecondWitnessName , SecondWitnessCNIC, FathersName,Tax_exemption,placeofissue ) values (@JointName,@AgreementDate,@PlaceofBirth,@CDS_Number,@BrokerCode,@AccountType,@Surname,@Middlename,@Forenames,@Initials,@Title,@IDNoPP,@IDtype,@Nationality,@DOB,@Gender,@Add_1,@Add_2,@Add_3,@Add_4,@Country,@City,@Tel,@Mobile,@Email,@Category,@Custodian,@TradingStatus,@Industry,@Tax,@Div_Bank,@Div_Branch,@Div_AccountNo,@Cash_Bank,@Cash_Branch,@Cash_AccountNo,@Date_Created,@Update_Type,@Created_By,@AuthorizationState,@DivPayee,@SettlementPayee,@idnopp2, @idtype2, @mobile_money, @mobile_number,@FH,@marital_status,@Occupations,@SOI,@GAI,@CNIC,@CNIC_expiry_date,@Passport,@Password_expiry_date,@NTN,@Permanet_Address,@Permanet_Address1,@Permanet_Address2,@Permanet_Address3,@Provinces,@PostCode,@Designation,@Resident_Status,@IBAN,@BankAccount_Type,@Confirmation,@FirstWitnessName , @FirstWitnessCNIC , @SecondWitnessName , @SecondWitnessCNIC, @FathersName,@Tax_exemption,@placeofissue)", cn)
            cmd.Parameters.AddWithValue("@AccountType", AccountType)
            cmd.Parameters.AddWithValue("@IDtype", cmbIDType.Text)
            cmd.Parameters.AddWithValue("@IDNoPP", myIDGlob)
            cmd.Parameters.AddWithValue("@JointName", myJointName)
            cmd.Parameters.AddWithValue("@Title", cmbTitle.Text)
            cmd.Parameters.AddWithValue("@CNIC", myIDGlob)
            cmd.Parameters.AddWithValue("@Forenames", txtOthernames.Text.ToUpper)
            cmd.Parameters.AddWithValue("@Surname", txtSurname.Text.ToUpper)
            cmd.Parameters.AddWithValue("@DOB", validateDate(txtDOB.Text))
            cmd.Parameters.AddWithValue("@Gender", Gender)
            cmd.Parameters.AddWithValue("@BankAccount_Type", cmbTypeofAccount.Text)
            cmd.Parameters.AddWithValue("@Custodian", cmbAssetManager.Text)
            cmd.Parameters.AddWithValue("@Nationality", cmbNationality.Text)
            cmd.Parameters.AddWithValue("@Passport", txtpassport.Text)
            cmd.Parameters.AddWithValue("@Country", cmbCountry.Text)
            cmd.Parameters.AddWithValue("@SOI", txtsourceofIncome.Text)
            cmd.Parameters.AddWithValue("@Add_1", txtAddress1.Text)
            cmd.Parameters.AddWithValue("@Tel", txtTel.Text)
            cmd.Parameters.AddWithValue("@Mobile", txtTel.Text)
            cmd.Parameters.AddWithValue("@PostCode", txtFax.Text)
            cmd.Parameters.AddWithValue("@Email", txtEmail.Text.ToString.ToLower)
            cmd.Parameters.AddWithValue("@DivPayee", txtPayee2.Text.ToUpper)
            cmd.Parameters.AddWithValue("@Div_AccountNo", txtIBAN.Text)
            cmd.Parameters.AddWithValue("@IBAN", txtIBAN.Text)
            cmd.Parameters.AddWithValue("@Div_Bank", BankDiv)
            cmd.Parameters.AddWithValue("@Div_Branch", txtBranchDiv.Text)
            cmd.Parameters.AddWithValue("@Cash_AccountNo", txtSwiftCode.Text)
            cmd.Parameters.AddWithValue("@SettlementPayee", txtbankAddress.Text.ToUpper)
            cmd.Parameters.AddWithValue("@NTN", txtDateTimeStamp.Text)
            cmd.Parameters.AddWithValue("@CDS_Number", cdsNo)
            cmd.Parameters.AddWithValue("@BrokerCode", Session("BrokerCode"))
            cmd.Parameters.AddWithValue("@Date_Created", Now.Date)
            cmd.Parameters.AddWithValue("@Update_Type", "NEW")
            cmd.Parameters.AddWithValue("@Created_By", Session("username"))
            cmd.Parameters.AddWithValue("@AuthorizationState", "O")
            cmd.Parameters.AddWithValue("@TradingStatus", "Trading")
            cmd.Parameters.AddWithValue("@AgreementDate", validateDate(" "))
            cmd.Parameters.AddWithValue("@PlaceofBirth", " ")
            cmd.Parameters.AddWithValue("@Middlename", " ")
            cmd.Parameters.AddWithValue("@Initials", " ")
            cmd.Parameters.AddWithValue("@Add_2", " ")
            cmd.Parameters.AddWithValue("@Add_3", " ")
            cmd.Parameters.AddWithValue("@Add_4", " ")
            cmd.Parameters.AddWithValue("@City", " ")
            cmd.Parameters.AddWithValue("@Category", " ")
            cmd.Parameters.AddWithValue("@Industry", " ")
            cmd.Parameters.AddWithValue("@Tax", " ")
            cmd.Parameters.AddWithValue("@Cash_Bank", " ")
            cmd.Parameters.AddWithValue("@Cash_Branch", " ")
            cmd.Parameters.AddWithValue("@idnopp2", " ")
            cmd.Parameters.AddWithValue("@idtype2", " ")
            cmd.Parameters.AddWithValue("@mobile_money", " ")
            cmd.Parameters.AddWithValue("@mobile_number", " ")
            cmd.Parameters.AddWithValue("@FH", " ")
            cmd.Parameters.AddWithValue("@marital_status", " ")
            cmd.Parameters.AddWithValue("@Occupations", " ")
            cmd.Parameters.AddWithValue("@GAI", " ")
            cmd.Parameters.AddWithValue("@CNIC_expiry_date", validateDate(" "))
            cmd.Parameters.AddWithValue("@Password_expiry_date", validateDate(" "))
            cmd.Parameters.AddWithValue("@Permanet_Address", " ")
            cmd.Parameters.AddWithValue("@Permanet_Address1", " ")
            cmd.Parameters.AddWithValue("@Permanet_Address2", " ")
            cmd.Parameters.AddWithValue("@Permanet_Address3", " ")
            cmd.Parameters.AddWithValue("@Provinces", " ")
            cmd.Parameters.AddWithValue("@Designation", " ")
            cmd.Parameters.AddWithValue("@Resident_Status", " ")
            cmd.Parameters.AddWithValue("@Confirmation", " ")
            cmd.Parameters.AddWithValue("@FirstWitnessName", " ")
            cmd.Parameters.AddWithValue("@FirstWitnessCNIC", " ")
            cmd.Parameters.AddWithValue("@SecondWitnessName", " ")
            cmd.Parameters.AddWithValue("@SecondWitnessCNIC", " ")
            cmd.Parameters.AddWithValue("@FathersName", " ")
            cmd.Parameters.AddWithValue("@Tax_exemption", " ")
            cmd.Parameters.AddWithValue("@placeofissue", " ")

            If (cn.State = ConnectionState.Open) Then
                cn.Close()
            End If
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()
            Dim CommitString As String = ""
            CommitString = CommitString & "  UPDATE Accounts_Joint_Audit SET CDS_Number='" & cdsNo & "' WHERE JointName='" & myJointName & "'  "
            CommitString = CommitString & "  UPDATE Client_AssetManagersAudit SET ClientNo='" & cdsNo & "' WHERE IDNo='" & txtIDNo.Text & "'  "
            CommitString = CommitString & "update accounts_documents set doc_generated='" & cdsNo & "' where CreatedBy='" & Session("Username") & "' and idno='" & myIDGlob & "'"
            cmd = New SqlCommand(CommitString, cn)
            If (cn.State = ConnectionState.Open) Then
                cn.Close()
            End If
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()
            Try
                cmd = New SqlCommand("insert into audit_log ([userid],[date],[time],[name],[activity], [userid_2], [request_id],[Browser],[IP],[Machine],[Broker_id]) values((select id from systemusers where username='" & Session("username") & "' and companycode='" + Session("Brokercode") + "'),'" & Date.Now.Date & "','" & Date.Now.Hour & ":" & Date.Now.Minute & ":" & Date.Now.Second & "','" + Session("username") + "','Created a new account',0,'" + cdsNo + "','" + HttpContext.Current.Request.UserAgent + "','" + HttpContext.Current.Request.UserHostAddress + "','" + HttpContext.Current.Request.UserHostName + "','" + Session("brokercode") + "')", cn)
                If (cn.State = ConnectionState.Open) Then
                    cn.Close()
                End If
                cn.Open()
                cmd.ExecuteNonQuery()
                cn.Close()
            Catch ex As Exception
            End Try
            If AccountType = "J" Then
                Session("updatemsg") = "You have successfully submitted a New Joint Account, Account No. " & cdsNo & " pending authorisation"
            Else
                Session("updatemsg") = "You have successfully submitted a New Single Account, Account No. " & cdsNo & " pending authorisation"
            End If
            Session("numb") = ""
            Session("finish") = "yes"
            Response.Redirect(Request.RawUrl)
        Catch ex As Exception
            ErrorLogging.WriteLogFile(Session("Username"), Request.Url.ToString, ex.ToString)
        End Try
    End Sub
    Public Function validateIndividualFields() As Boolean
        If rdJoint.Checked = True Then
            If (txtSurname0.Text.Trim = "") Then
                msgbox("Please Enter Joint Name")
                txtSurname0.Focus()
                Return False
            End If
            txtIDNo.Text = txtCNIC.Text
            If JointmembersLessthanONE() = True Then
                msgbox("Add at least 1 Member to Joint Account")
                Return False
            End If
        End If
        If (Len(txtSurname.Text.Trim) < 1) Then
            msgbox("Please enter a valid surname")
            txtSurname.Focus()
            Return False
        End If
        If (Len(txtOthernames.Text.Trim) < 1) Then
            msgbox("Please enter Firstname")
            txtOthernames.Focus()
            Return False
        End If
        If cmbNationality.Text = "" Then
            msgbox("Please select Nationality")
            cmbNationality.Focus()
            Return False
        End If
        If cmbCountry.Text = "" Then
            msgbox("Please select Country")
            cmbCountry.Focus()
            Return False
        End If
        If IsDate(txtDOB.Text) = False Then
            msgbox("Please select Date of Birth")
            txtDOB.Focus()
            Return False
        End If
        If rdMale.Checked = False And rdFemale.Checked = False And rdNa.Checked = False Then
            msgbox("Please select Gender")
            rdMale.Focus()
            Return False
        End If
        If (Len(txtIDNo.Text) < 1) Then
            msgbox("Please enter National ID No./Passport number")
            txtIDNo.Focus()
            Return False
        End If
        If (Len(txtAddress1.Text) < 1) Then
            msgbox("Please enter at least one line of the address")
            txtAddress1.Focus()
            Return False
        End If
        If (Len(cmbNationality.Text) < 1) Then
            msgbox("Select nationality")
            Return False
        End If
        If (txtTel.Text = "") Then
            msgbox("Please Enter Tel No.")
            txtTel.Focus()
            Return False
        End If
        If (txtEmail.Text = "") Then
            msgbox("Please Enter Email")
            txtEmail.Focus()
            Return False
        End If
        If (txtCNIC.Text = "") Then
            msgbox("Please Enter National ID No./Passport No.")
            txtCNIC.Focus()
            Return False
        End If
        If CNICExits() = True Then
            msgbox("National ID No./Passport No. already exists")
            txtCNIC.Focus()
            Return False
        End If
        If EMAILExits() = True Then
            msgbox("Email already exists")
            txtEmail.Focus()
            Return False
        End If
        If Len(txtIBAN.Text) <= 0 Then
            msgbox("Enter bank account number")
            txtIBAN.Focus()
            Return False
        End If
        If Len(txtPayee2.Text.Trim) = 0 Then
            msgbox("Please enter Account Name")
            txtPayee2.Focus()
            Return False
        End If
        If Len(cmbBankDiv.Text.Trim) = 0 Then
            msgbox("Please select Bank")
            cmbBankDiv.Focus()
            Return False
        End If
        If Len(txtBranchDiv.Text.Trim) = 0 Then
            msgbox("Please enter Branch")
            txtBranchDiv.Focus()
            Return False
        End If
        Return True
    End Function
    Protected Sub btnJadd0_Click(sender As Object, e As EventArgs) Handles btnJadd0.Click
        validateidnumber()
    End Sub
    Protected Sub btnJadd4_Click(sender As Object, e As EventArgs) Handles btnJadd4.Click
        If txtSurname0.Text.Trim <> "" Then
            validate_joint_name()
        Else
            msgbox("Please fill the required fields")
        End If
    End Sub
    Public Sub validate_joint_name()
        Dim dsid2 As New DataSet
        cmd = New SqlCommand("select * from Accounts_audit where JointName=@JointName AND AccountType='J'", cn)
        cmd.Parameters.AddWithValue("@JointName", txtSurname0.Text)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(dsid2, "jointname")
        If (dsid2.Tables(0).Rows.Count > 0) Then
            msgbox("Joint Name already exists")
        Else
            Dim dsid3 As New DataSet
            cmd = New SqlCommand("select * from Accounts_clients where JointName=@JointName AND AccountType='J'", cn)
            cmd.Parameters.AddWithValue("@JointName", txtSurname0.Text)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(dsid3, "jointname2")
            If (dsid3.Tables(0).Rows.Count > 0) Then
                msgbox("Joint Name already exists")
            Else
                txtCNIC.Enabled = True
                txtCNIC.Text = ""
                panel13disable()
                ShowHide_Single("Hide")
                ShowHide_Joint("Show")
                ShowHideAll("Show")
                getJointHolders()
            End If
        End If
    End Sub
    Protected Sub ASPxButton9_Click(sender As Object, e As EventArgs) Handles ASPxButton9.Click
        If validateJOINTFields() = False Then
            Exit Sub
        Else
            SaveNewAccountJOINT()
        End If
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
    Public Function checkupload() As Boolean
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
            Case ".jpeg"
                contenttype = ".jpeg"
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
                Return False
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
            Dim IDNOJoinName As String = ""
            If rdIndividual.Checked = True Then
                IDNOJoinName = txtIDNo.Text
            Else
                IDNOJoinName = txtSurname0.Text
            End If
            cmd.Parameters.Add("@idno", SqlDbType.VarChar).Value = "" + IDNOJoinName + ""
            cmd.Parameters.Add("@CreatedBy", SqlDbType.VarChar).Value = "" + Session("Username") + ""
            InsertUpdateData(cmd)
            Return True
        Else
            msgbox("File format not recognised." _
            & " Upload Image/Word/PDF formats")
            Return False
        End If
    End Function
    Protected Sub ASPxButton10_Click(sender As Object, e As EventArgs) Handles ASPxButton10.Click
        If checkupload() = True Then
            getuploaded()
            txtdocumentname.Text = ""
            txtotherdoc.Text = ""
            msgbox("Document Uploaded")
        End If
    End Sub
    Public Sub getuploaded()
        Dim dsid2 As New DataSet
        Dim IDNOJoinName As String = ""
        If rdIndividual.Checked = True Then
            IDNOJoinName = txtIDNo.Text
        Else
            IDNOJoinName = txtSurname0.Text
        End If
        cmd = New SqlCommand("select id, name, contenttype from accounts_documents where CreatedBy='" & Session("Username") & "' and idno='" + IDNOJoinName + "'", cn)
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
    Public Sub SaveNewAccountJOINT()
        Try
            cmd = New SqlCommand("insert into Accounts_Joint_Audit (JointName,BrokerCode,Surname,nomineerelation,Add_1,Tel,Mobile,Email,IDNoPP,Passport,Update_Type,Created_By,AuthorizationState,CNIC,Date_Created) values (@JointName,@BrokerCode,@Surname,@nomineerelation,@Add_1,@Tel,@Mobile,@Email,@IDNoPP,@Passport,@Update_Type,@Created_By,@AuthorizationState,@CNIC,getdate())", cn)
            cmd.Parameters.AddWithValue("@JointName", txtSurname0.Text)
            cmd.Parameters.AddWithValue("@BrokerCode", Session("BrokerCode"))
            cmd.Parameters.AddWithValue("@Surname", txtnexofkeenName.Text.ToString.ToUpper)
            cmd.Parameters.AddWithValue("@nomineerelation", txtrelation.Text)
            cmd.Parameters.AddWithValue("@Add_1", txtnexofkeenAddress.Text)
            cmd.Parameters.AddWithValue("@Tel", txtnextofKeenMobile.Text)
            cmd.Parameters.AddWithValue("@Mobile", txtnextofKeenMobile.Text)
            cmd.Parameters.AddWithValue("@Email", txtnomineemail.Text.ToString.ToLower)
            cmd.Parameters.AddWithValue("@IDNoPP", txtnomineepass.Text)
            cmd.Parameters.AddWithValue("@Passport", txtnomineepass.Text)
            cmd.Parameters.AddWithValue("@Update_Type", "NEW")
            cmd.Parameters.AddWithValue("@Created_By", Session("username"))
            cmd.Parameters.AddWithValue("@AuthorizationState", "O")
            cmd.Parameters.AddWithValue("@CNIC", txtnomineepass.Text)
            If (cn.State = ConnectionState.Open) Then
                cn.Close()
            End If
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()
            txtnexofkeenName.Text = ""
            txtrelation.Text = ""
            txtnexofkeenAddress.Text = ""
            txtnextofKeenMobile.Text = ""
            txtnomineemail.Text = ""
            txtnomineepass.Text = ""
            getJointHolders()
            msgbox("Joint Member Successfully Added")
        Catch ex As Exception
            ErrorLogging.WriteLogFile(Session("Username"), Request.Url.ToString, ex.ToString)
        End Try
    End Sub
    Function validateDate(inp As String) As Object
        'Return IIf(IsNumeric(toMoney(inp)), DBNull.Value, inp)
        Return IIf(Trim(inp) = "" Or Not IsDate(inp), DBNull.Value, inp)
    End Function
    Sub getJointHolders()
        Dim dsid2 As New DataSet
        cmd = New SqlCommand("select ID,Surname,IDNoPP,Add_1,Mobile,Email,nomineerelation from Accounts_Joint_AUDIT where JointName=@JointName", cn)
        cmd.Parameters.AddWithValue("@JointName", txtSurname0.Text)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(dsid2, "jointn")
        If (dsid2.Tables(0).Rows.Count > 0) Then
            grdJointAccounts.DataSource = dsid2
            grdJointAccounts.DataBind()
        Else
            grdJointAccounts.DataSource = Nothing
            grdJointAccounts.DataBind()
        End If
    End Sub
    Protected Sub btnSaveWIP_Click(sender As Object, e As EventArgs) Handles btnSaveWIP.Click
        saveWIPSINGLE()
    End Sub
    Protected Sub grdWIP_RowCommand(sender As Object, e As DevExpress.Web.ASPxGridView.ASPxGridViewRowCommandEventArgs)
        Dim myID As String = e.KeyValue.ToString
        getExistingWIP(myID)
    End Sub
    Public Sub loadallWIP()
        Dim accType As String = ""
        Dim ds As New DataSet
        cmd = New SqlCommand("  Select ID,Forenames,Surname,IDNoPP,Add_1,JointName,CNIC  from Accounts_Audit_temp where AccountType in ('I') AND CreatedBy='" & Session("Username") & "' and IDNoPP NOT IN (SELECT DISTINCT r.IDNoPP FROM Accounts_Audit r UNION SELECT DISTINCT p.IDNoPP FROM Accounts_Clients p) UNION SELECT A.ID,A.Surname,A.Forenames,A.IDNoPP,A.Add_1,A.JointName,A.CNIC FROM( Select ID,case when isnull(Surname,'')='' then JointName else Surname end as Surname,Forenames,IDNoPP,Add_1,JointName,CNIC from Accounts_Audit_temp where AccountType in ('J') AND CreatedBy='" & Session("Username") & "' and JointName NOT IN (SELECT DISTINCT r.JointName FROM Accounts_Audit r WHERE r.AccountType='J' UNION SELECT DISTINCT p.JointName FROM Accounts_Clients p WHERE p.AccountType='J')) A LEFT OUTER JOIN Accounts_Joint_Audit B ON A.JointName=B.JointName AND A.CNIC=B.CNIC WHERE B.CNIC IS NULL  order by id desc ", cn)
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
        cmd = New SqlCommand("select ISNULL(FORMAT(TRY_PARSE(GrossIncome as money),'#,###.##','en-us'),GrossIncome) as GrossIncome1,FORMAT(TRY_PARSE(CNIC_expiry_date as date),'dd MMMM yyyy','en-us') as CNICExpiry1,FORMAT(TRY_PARSE(Password_expiry_date as date),'dd MMMM yyyy','en-us') as PassportExpiry1, CASE WHEN AgreementDate IS NULL THEN '' ELSE FORMAT(CONVERT(DATE,AgreementDate),'dd MMMM yyyy','en-us')  END AS AgreementDate1,CASE WHEN DOB IS NULL THEN '' ELSE FORMAT(CONVERT(DATE,DOB),'dd MMMM yyyy','en-us')  END AS DOB1,*,CASE WHEN AccountType='I' THEN 'Single' when AccountType='J' THEN 'Joint' when AccountType='C' THEN 'Corporate' else AccountType end as myAccType from Accounts_Audit_temp where ID='" & RecID & "'", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "Accounts_Audit_temp")
        If (ds.Tables(0).Rows.Count > 0) Then
            Try
                cmbIDType.Value = ds.Tables(0).Rows(0).Item("IDtype").ToString
            Catch ex As Exception
                cmbIDType.SelectedIndex = -1
            End Try
            txtIDNo.Text = ds.Tables(0).Rows(0).Item("IDNoPP").ToString
            panel13disable()
            txtSurname0.Text = ds.Tables(0).Rows(0).Item("JointName").ToString
            If ds.Tables(0).Rows(0).Item("AccountType").ToString = "I" Or (ds.Tables(0).Rows(0).Item("AccountType").ToString = "J" And CNICExits_inAUDIT(ds.Tables(0).Rows(0).Item("CNIC").ToString, ds.Tables(0).Rows(0).Item("JointName").ToString) = False) Then
                Try
                    cmbTitle.Value = ds.Tables(0).Rows(0).Item("Title").ToString
                Catch ex As Exception
                    cmbTitle.SelectedIndex = -1
                End Try
                txtSurname.Text = ds.Tables(0).Rows(0).Item("surname").ToString
                txtOthernames.Text = ds.Tables(0).Rows(0).Item("Forenames").ToString
                txtsourceofIncome.Text = ds.Tables(0).Rows(0).Item("SOI").ToString
                Try
                    cmbNationality.Value = ds.Tables(0).Rows(0).Item("Nationality").ToString
                Catch ex As Exception
                    cmbNationality.SelectedIndex = -1
                End Try
                txtDOB.Text = ds.Tables(0).Rows(0).Item("DOB1").ToString
                If ds.Tables(0).Rows(0).Item("Gender").ToString.ToUpper = "M" Or ds.Tables(0).Rows(0).Item("Gender").ToString.ToUpper = "MALE" Then
                    rdMale.Checked = True
                    rdFemale.Checked = False
                    rdNa.Checked = False
                ElseIf ds.Tables(0).Rows(0).Item("Gender").ToString.ToUpper = "F" Or ds.Tables(0).Rows(0).Item("Gender").ToString.ToUpper = "FEMALE" Then
                    rdMale.Checked = False
                    rdFemale.Checked = True
                    rdNa.Checked = False
                Else
                    rdMale.Checked = False
                    rdFemale.Checked = False
                    rdNa.Checked = True
                End If
                txtAddress1.Text = ds.Tables(0).Rows(0).Item("Add_1").ToString
                Try
                    cmbCountry.Value = ds.Tables(0).Rows(0).Item("Country").ToString
                Catch ex As Exception
                    cmbCountry.SelectedIndex = -1
                End Try
                txtCNIC.Text = ds.Tables(0).Rows(0).Item("CNIC").ToString
                txtpassport.Text = ds.Tables(0).Rows(0).Item("Passport").ToString
                txtTel.Text = ds.Tables(0).Rows(0).Item("Tel").ToString
                txtEmail.Text = ds.Tables(0).Rows(0).Item("Email").ToString
                txtnexofkeenName.Text = ds.Tables(0).Rows(0).Item("Nominee_Name").ToString
                txtnexofkeenAddress.Text = ds.Tables(0).Rows(0).Item("Nominee_Address").ToString
                txtnextofKeenMobile.Text = ds.Tables(0).Rows(0).Item("Nominee_Mobile").ToString
                txtnomineemail.Text = ds.Tables(0).Rows(0).Item("Nominee_Email").ToString
                txtnomineepass.Text = ds.Tables(0).Rows(0).Item("Nominee_CNIC").ToString
                txtrelation.Text = ds.Tables(0).Rows(0).Item("nomineerelation").ToString
                txtPayee2.Text = ds.Tables(0).Rows(0).Item("DivPayee").ToString
                Try
                    cmbBankDiv.Value = ds.Tables(0).Rows(0).Item("Div_Bank").ToString
                Catch ex As Exception
                    cmbBankDiv.SelectedIndex = -1
                End Try
                txtBranchDiv.Text = ds.Tables(0).Rows(0).Item("Div_Branch").ToString
                txtIBAN.Text = ds.Tables(0).Rows(0).Item("IBAN").ToString
            End If
            getuploaded()
            If ds.Tables(0).Rows(0).Item("AccountType").ToString = "I" Then
                rdIndividual.Checked = True
                rdJoint.Checked = False
                ShowHide_Single("Show")
                ShowHide_Joint("Hide")
                ShowHideAll("Show")
                Session("WIP") = "WIP"
                btnJadd0_Click(sender:=New Object, e:=New EventArgs)
                Session("WIP") = ""
            End If
            If ds.Tables(0).Rows(0).Item("AccountType").ToString = "J" Then
                rdIndividual.Checked = False
                rdJoint.Checked = True
                rdJoint_CheckedChanged(sender:=New Object, e:=New EventArgs)
                Session("WIP") = "WIP"
                btnJadd4_Click(sender:=New Object, e:=New EventArgs)
                Session("WIP") = ""
                getJointHolders()
            End If
        End If
    End Sub
    Sub saveWIPSINGLE()
        Try
            Dim BankDiv As String = ""
            If (cmbBankDiv.Text.Trim <> "") Then
                BankDiv = cmbBankDiv.Value
            Else
                BankDiv = ""
            End If

            Dim AccountType As String = ""
            Dim Gender As String = "N"
            If (rdMale.Checked = True) Then
                Gender = "M"
            End If
            If (rdFemale.Checked = True) Then
                Gender = "F"
            End If
            If (rdNa.Checked = True) Then
                Gender = "N"
            End If
            Dim myIDGlob As String = ""
            Dim myJointName As String = ""
            If (rdIndividual.Checked = True) Then
                AccountType = "I"
                myJointName = " "
                myIDGlob = txtIDNo.Text
            End If
            If (rdJoint.Checked = True) Then
                AccountType = "J"
                myJointName = txtSurname0.Text
                myIDGlob = txtCNIC.Text
            End If

            Dim strCMD As String = ""
            strCMD = strCMD & " if not exists(select top 1 * from Accounts_Audit_temp where IDNoPP=@IDNoPP AND CreatedBy=@Created_By) begin "
            strCMD = strCMD & " insert into Accounts_Audit_temp (JointName,GrossIncome,AgreementDate,CreatedBy,PlaceofBirth,CDS_Number,BrokerCode,AccountType,Surname,Middlename,Forenames,Initials,Title,IDNoPP,IDtype,Nationality,DOB,Gender,Add_1,Add_2,Add_3,Add_4,Country,City,Tel,Mobile,Email,Category,Custodian,TradingStatus,Industry,Tax,Div_Bank,Div_Branch,Div_AccountNo,Cash_Bank,Cash_Branch,Cash_AccountNo,Date_Created,Update_Type,Created_By,AuthorizationState,DivPayee,SettlementPayee,idnopp2, idtype2, mobile_money, mobile_number,FH,marital_status,Occupations,SOI,GAI,CNIC,CNIC_expiry_date,Passport,Password_expiry_date,NTN,Permanet_Address,Permanet_Address1,Permanet_Address2,Permanet_Address3,Provinces,PostCode,Designation,Resident_Status,IBAN,BankAccount_Type,Confirmation,FirstWitnessName , FirstWitnessCNIC , SecondWitnessName , SecondWitnessCNIC, FathersName,Nominee_Name,[Nominee_Account_Id],[Nominee_Email],[Nominee_Mobile],[Nominee_Father_Husband_Name],[Nominee_CNIC],[Nominee_Address],[Nominee_Gender],nomineerelation,Tax_exemption,placeofissue ) values (@JointName,@GAI,@AgreementDate,@Created_By,@PlaceofBirth,@CDS_Number,@BrokerCode,@AccountType,@Surname,@Middlename,@Forenames,@Initials,@Title,@IDNoPP,@IDtype,@Nationality,@DOB,@Gender,@Add_1,@Add_2,@Add_3,@Add_4,@Country,@City,@Tel,@Mobile,@Email,@Category,@Custodian,@TradingStatus,@Industry,@Tax,@Div_Bank,@Div_Branch,@Div_AccountNo,@Cash_Bank,@Cash_Branch,@Cash_AccountNo,@Date_Created,@Update_Type,@Created_By,@AuthorizationState,@DivPayee,@SettlementPayee,@idnopp2, @idtype2, @mobile_money, @mobile_number,@FH,@marital_status,@Occupations,@SOI,@GAI,@CNIC,@CNIC_expiry_date,@Passport,@Password_expiry_date,@NTN,@Permanet_Address,@Permanet_Address1,@Permanet_Address2,@Permanet_Address3,@Provinces,@PostCode,@Designation,@Resident_Status,@IBAN,@BankAccount_Type,@Confirmation,@FirstWitnessName , @FirstWitnessCNIC , @SecondWitnessName , @SecondWitnessCNIC, @FathersName,@Nominee_Name,@Nominee_Account_Id,@Nominee_Email,@Nominee_Mobile,@Nominee_Father_Husband_Name,@Nominee_CNIC,@Nominee_Address,@Nominee_Gender,@nomineerelation,@Tax_exemption,@placeofissue) "
            strCMD = strCMD & " end else begin "
            strCMD = strCMD & " UPDATE Accounts_Audit_temp SET JointName=@JointName,GrossIncome=@GAI,AgreementDate=@AgreementDate,PlaceofBirth=@PlaceofBirth,CDS_Number=@CDS_Number,BrokerCode=@BrokerCode,AccountType=@AccountType,Surname=@Surname,Middlename=@Middlename,Forenames=@Forenames,Initials=@Initials,Title=@Title,IDtype=@IDtype,Nationality=@Nationality,DOB=@DOB,Gender=@Gender,Add_1=@Add_1,Add_2=@Add_2,Add_3=@Add_3,Add_4=@Add_4,Country=@Country,City=@City,Tel=@Tel,Mobile=@Mobile,Email=@Email,Category=@Category,Custodian=@Custodian,TradingStatus=@TradingStatus,Industry=@Industry,Tax=@Tax,Div_Bank=@Div_Bank,Div_Branch=@Div_Branch,Div_AccountNo=@Div_AccountNo,Cash_Bank=@Cash_Bank,Cash_Branch=@Cash_Branch,Cash_AccountNo=@Cash_AccountNo,DivPayee=@DivPayee,SettlementPayee=@SettlementPayee,idnopp2=@idnopp2, idtype2=@idtype2, mobile_money=@mobile_money, mobile_number=@mobile_number,FH=@FH,marital_status=@marital_status,Occupations=@Occupations,SOI=@SOI,GAI=@GAI,CNIC=@CNIC,CNIC_expiry_date=@CNIC_expiry_date,Passport=@Passport,Password_expiry_date=@Password_expiry_date,NTN=@NTN,Permanet_Address=@Permanet_Address,Permanet_Address1=@Permanet_Address1,Permanet_Address2=@Permanet_Address2,Permanet_Address3=@Permanet_Address3,Provinces=@Provinces,PostCode=@PostCode,Designation=@Designation,Resident_Status=@Resident_Status,IBAN=@IBAN,BankAccount_Type=@BankAccount_Type,Confirmation=@Confirmation,FirstWitnessName=@FirstWitnessName , FirstWitnessCNIC=@FirstWitnessCNIC , SecondWitnessName=@SecondWitnessName , SecondWitnessCNIC=@SecondWitnessCNIC, FathersName=@FathersName,Nominee_Name=@Nominee_Name,[Nominee_Account_Id]=@Nominee_Account_Id,[Nominee_Email]=@Nominee_Email,[Nominee_Mobile]=@Nominee_Mobile,[Nominee_Father_Husband_Name]=@Nominee_Father_Husband_Name,[Nominee_CNIC]=@Nominee_CNIC,[Nominee_Address]=@Nominee_Address,[Nominee_Gender]=@Nominee_Gender,nomineerelation=@nomineerelation,Tax_exemption=@Tax_exemption,placeofissue=@placeofissue WHERE IDNoPP=@IDNoPP AND CreatedBy=@Created_By "
            strCMD = strCMD & " end "
            cmd = New SqlCommand(strCMD, cn)
            cmd.Parameters.AddWithValue("@AccountType", AccountType)
            cmd.Parameters.AddWithValue("@IDtype", cmbIDType.Text)
            cmd.Parameters.AddWithValue("@IDNoPP", myIDGlob)
            cmd.Parameters.AddWithValue("@JointName", myJointName)
            cmd.Parameters.AddWithValue("@Title", cmbTitle.Text)
            cmd.Parameters.AddWithValue("@CNIC", myIDGlob)
            cmd.Parameters.AddWithValue("@Forenames", txtOthernames.Text.ToUpper)
            cmd.Parameters.AddWithValue("@Surname", txtSurname.Text.ToUpper)
            cmd.Parameters.AddWithValue("@DOB", validateDate(txtDOB.Text))
            cmd.Parameters.AddWithValue("@Gender", Gender)
            cmd.Parameters.AddWithValue("@BankAccount_Type", cmbTypeofAccount.Text)
            cmd.Parameters.AddWithValue("@Custodian", cmbAssetManager.Text)
            cmd.Parameters.AddWithValue("@Nationality", cmbNationality.Text)
            cmd.Parameters.AddWithValue("@Passport", txtpassport.Text)
            cmd.Parameters.AddWithValue("@Country", cmbCountry.Text)
            cmd.Parameters.AddWithValue("@SOI", txtsourceofIncome.Text)
            cmd.Parameters.AddWithValue("@Add_1", txtAddress1.Text)
            cmd.Parameters.AddWithValue("@Tel", txtTel.Text)
            cmd.Parameters.AddWithValue("@Mobile", txtTel.Text)
            cmd.Parameters.AddWithValue("@PostCode", txtFax.Text)
            cmd.Parameters.AddWithValue("@Email", txtEmail.Text.ToString.ToLower)
            cmd.Parameters.AddWithValue("@DivPayee", txtPayee2.Text.ToUpper)
            cmd.Parameters.AddWithValue("@Div_AccountNo", txtIBAN.Text)
            cmd.Parameters.AddWithValue("@IBAN", txtIBAN.Text)
            cmd.Parameters.AddWithValue("@Div_Bank", BankDiv)
            cmd.Parameters.AddWithValue("@Div_Branch", txtBranchDiv.Text)
            cmd.Parameters.AddWithValue("@Cash_AccountNo", txtSwiftCode.Text)
            cmd.Parameters.AddWithValue("@SettlementPayee", txtbankAddress.Text.ToUpper)
            cmd.Parameters.AddWithValue("@NTN", txtDateTimeStamp.Text)
            cmd.Parameters.AddWithValue("@CDS_Number", " ")
            cmd.Parameters.AddWithValue("@BrokerCode", Session("BrokerCode"))
            cmd.Parameters.AddWithValue("@Date_Created", Now.Date)
            cmd.Parameters.AddWithValue("@Update_Type", "NEW")
            cmd.Parameters.AddWithValue("@Created_By", Session("username"))
            cmd.Parameters.AddWithValue("@AuthorizationState", "O")
            cmd.Parameters.AddWithValue("@TradingStatus", "Trading")
            cmd.Parameters.AddWithValue("@AgreementDate", validateDate(" "))
            cmd.Parameters.AddWithValue("@PlaceofBirth", " ")
            cmd.Parameters.AddWithValue("@Middlename", " ")
            cmd.Parameters.AddWithValue("@Initials", " ")
            cmd.Parameters.AddWithValue("@Add_2", " ")
            cmd.Parameters.AddWithValue("@Add_3", " ")
            cmd.Parameters.AddWithValue("@Add_4", " ")
            cmd.Parameters.AddWithValue("@City", " ")
            cmd.Parameters.AddWithValue("@Category", " ")
            cmd.Parameters.AddWithValue("@Industry", " ")
            cmd.Parameters.AddWithValue("@Tax", " ")
            cmd.Parameters.AddWithValue("@Cash_Bank", " ")
            cmd.Parameters.AddWithValue("@Cash_Branch", " ")
            cmd.Parameters.AddWithValue("@idnopp2", " ")
            cmd.Parameters.AddWithValue("@idtype2", " ")
            cmd.Parameters.AddWithValue("@mobile_money", " ")
            cmd.Parameters.AddWithValue("@mobile_number", " ")
            cmd.Parameters.AddWithValue("@FH", " ")
            cmd.Parameters.AddWithValue("@marital_status", " ")
            cmd.Parameters.AddWithValue("@Occupations", " ")
            cmd.Parameters.AddWithValue("@GAI", " ")
            cmd.Parameters.AddWithValue("@CNIC_expiry_date", validateDate(" "))
            cmd.Parameters.AddWithValue("@Password_expiry_date", validateDate(" "))
            cmd.Parameters.AddWithValue("@Permanet_Address", " ")
            cmd.Parameters.AddWithValue("@Permanet_Address1", " ")
            cmd.Parameters.AddWithValue("@Permanet_Address2", " ")
            cmd.Parameters.AddWithValue("@Permanet_Address3", " ")
            cmd.Parameters.AddWithValue("@Provinces", " ")
            cmd.Parameters.AddWithValue("@Designation", " ")
            cmd.Parameters.AddWithValue("@Resident_Status", " ")
            cmd.Parameters.AddWithValue("@Confirmation", " ")
            cmd.Parameters.AddWithValue("@FirstWitnessName", " ")
            cmd.Parameters.AddWithValue("@FirstWitnessCNIC", " ")
            cmd.Parameters.AddWithValue("@SecondWitnessName", " ")
            cmd.Parameters.AddWithValue("@SecondWitnessCNIC", " ")
            cmd.Parameters.AddWithValue("@FathersName", " ")
            cmd.Parameters.AddWithValue("@Tax_exemption", " ")
            cmd.Parameters.AddWithValue("@placeofissue", " ")
            cmd.Parameters.AddWithValue("@Nominee_Name", " ")
            cmd.Parameters.AddWithValue("@Nominee_Account_Id", " ")
            cmd.Parameters.AddWithValue("@Nominee_Email", " ")
            cmd.Parameters.AddWithValue("@Nominee_Mobile", " ")
            cmd.Parameters.AddWithValue("@Nominee_Father_Husband_Name", " ")
            cmd.Parameters.AddWithValue("@Nominee_CNIC", " ")
            cmd.Parameters.AddWithValue("@Nominee_Address", " ")
            cmd.Parameters.AddWithValue("@Nominee_Gender", " ")
            cmd.Parameters.AddWithValue("@nomineerelation", " ")

            If (cn.State = ConnectionState.Open) Then
                cn.Close()
            End If
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()
            loadallWIP()
            msgbox("Work In progress saved")
        Catch ex As Exception
            ErrorLogging.WriteLogFile("", "", ex.ToString)
        End Try
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
    Function JointmembersLessthanONE() As Boolean
        Dim sql_str As String = ""
        sql_str = "SELECT * FROM Accounts_Joint_Audit A WHERE A.JointName=@JointName"
        Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("conpath").ConnectionString)
            Using cmd As New SqlCommand(sql_str, con)
                cmd.Parameters.AddWithValue("@JointName", txtSurname0.Text)
                Dim dss As New DataSet
                Dim adp = New SqlDataAdapter(cmd)
                adp.Fill(dss, "Accounts_Joint_Audit")
                If dss.Tables(0).Rows.Count < 1 Then
                    Return True
                Else
                    Return False
                End If
            End Using
        End Using
    End Function
    Protected Sub txtdocumentname_SelectedIndexChanged(sender As Object, e As EventArgs) Handles txtdocumentname.SelectedIndexChanged
        If txtdocumentname.SelectedItem.Text = "Other" Then
            txtotherdoc.Visible = True
        Else
            txtotherdoc.Visible = False
        End If
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

            Dim AccountType As String = ""
            Dim Gender As String = "N"
            If (rdMale.Checked = True) Then
                Gender = "M"
            End If
            If (rdFemale.Checked = True) Then
                Gender = "F"
            End If
            If (rdNa.Checked = True) Then
                Gender = "N"
            End If
            Dim myIDGlob As String = ""
            Dim myJointName As String = ""
            If (rdIndividual.Checked = True) Then
                AccountType = "I"
                myJointName = " "
                myIDGlob = txtIDNo.Text
            End If
            If (rdJoint.Checked = True) Then
                AccountType = "J"
                myJointName = txtSurname0.Text
                myIDGlob = txtCNIC.Text
            End If
            cmd = New SqlCommand("insert into Accounts_Print (JointName,PrintBy,AgreementDate,PlaceofBirth,CDS_Number,BrokerCode,AccountType,Surname,Middlename,Forenames,Initials,Title,IDNoPP,IDtype,Nationality,DOB,Gender,Add_1,Add_2,Add_3,Add_4,Country,City,Tel,Mobile,Email,Category,Custodian,TradingStatus,Industry,Tax,Div_Bank,Div_Branch,Div_AccountNo,Cash_Bank,Cash_Branch,Cash_AccountNo,Date_Created,Update_Type,Created_By,DivPayee,SettlementPayee,idnopp2, idtype2, mobile_money, mobile_number,status,Occupation,SOI,GrossIncome,CNIC,CNICExpiry,Passport,PassportExpiry,NTN,Permanet_Address,Permanet_Address1,Permanet_Address2,Permanet_Address3,Provinces,PostCode,Designation,Resident_Status,IBAN,BankAccount_Type,Confirmation,FirstWitnessName , FirstWitnessCNIC , SecondWitnessName , SecondWitnessCNIC, FathersName,Nominee_Name,[Nominee_Account_Id],[Nominee_Email],[Nominee_Mobile],[Nominee_Father_Husband_Name],[Nominee_CNIC],[Nominee_ress],[Nominee_Gender],nomineerelation,Tax_exemption,placeofissue ) values (@JointName,@PrintBy,@AgreementDate,@PlaceofBirth,@CDS_Number,@BrokerCode,@AccountType,@Surname,@Middlename,@Forenames,@Initials,@Title,@IDNoPP,@IDtype,@Nationality,@DOB,@Gender,@Add_1,@Add_2,@Add_3,@Add_4,@Country,@City,@Tel,@Mobile,@Email,@Category,@Custodian,@TradingStatus,@Industry,@Tax,@Div_Bank,@Div_Branch,@Div_AccountNo,@Cash_Bank,@Cash_Branch,@Cash_AccountNo,@Date_Created,@Update_Type,@Created_By,@DivPayee,@SettlementPayee,@idnopp2, @idtype2, @mobile_money, @mobile_number,@marital_status,@Occupations,@SOI,@GAI,@CNIC,@CNIC_expiry_date,@Passport,@Password_expiry_date,@NTN,@Permanet_Address,@Permanet_Address1,@Permanet_Address2,@Permanet_Address3,@Provinces,@PostCode,@Designation,@Resident_Status,@IBAN,@BankAccount_Type,@Confirmation,@FirstWitnessName , @FirstWitnessCNIC , @SecondWitnessName , @SecondWitnessCNIC, @FathersName,@Nominee_Name,@Nominee_Account_Id,@Nominee_Email,@Nominee_Mobile,@Nominee_Father_Husband_Name,@Nominee_CNIC,@Nominee_Address,@Nominee_Gender,@nomineerelation,@Tax_exemption,@placeofissue)", cn)
            cmd.Parameters.AddWithValue("@PrintBy", Session("username"))
            cmd.Parameters.AddWithValue("@AccountType", AccountType)
            cmd.Parameters.AddWithValue("@IDtype", cmbIDType.Text)
            cmd.Parameters.AddWithValue("@IDNoPP", myIDGlob)
            cmd.Parameters.AddWithValue("@JointName", myJointName)
            cmd.Parameters.AddWithValue("@Title", cmbTitle.Text)
            cmd.Parameters.AddWithValue("@CNIC", myIDGlob)
            cmd.Parameters.AddWithValue("@Forenames", txtOthernames.Text.ToUpper)
            cmd.Parameters.AddWithValue("@Surname", txtSurname.Text.ToUpper)
            cmd.Parameters.AddWithValue("@DOB", validateDate(txtDOB.Text))
            cmd.Parameters.AddWithValue("@Gender", Gender)
            cmd.Parameters.AddWithValue("@BankAccount_Type", cmbTypeofAccount.Text)
            cmd.Parameters.AddWithValue("@Custodian", cmbAssetManager.Text)
            cmd.Parameters.AddWithValue("@Nationality", cmbNationality.Text)
            cmd.Parameters.AddWithValue("@Passport", txtpassport.Text)
            cmd.Parameters.AddWithValue("@Country", cmbCountry.Text)
            cmd.Parameters.AddWithValue("@SOI", txtsourceofIncome.Text)
            cmd.Parameters.AddWithValue("@Add_1", txtAddress1.Text)
            cmd.Parameters.AddWithValue("@Tel", txtTel.Text)
            cmd.Parameters.AddWithValue("@Mobile", txtTel.Text)
            cmd.Parameters.AddWithValue("@PostCode", txtFax.Text)
            cmd.Parameters.AddWithValue("@Email", txtEmail.Text.ToString.ToLower)
            cmd.Parameters.AddWithValue("@DivPayee", txtPayee2.Text.ToUpper)
            cmd.Parameters.AddWithValue("@Div_AccountNo", txtIBAN.Text)
            cmd.Parameters.AddWithValue("@IBAN", txtIBAN.Text)
            cmd.Parameters.AddWithValue("@Div_Bank", BankDiv)
            cmd.Parameters.AddWithValue("@Div_Branch", txtBranchDiv.Text)
            cmd.Parameters.AddWithValue("@Cash_AccountNo", txtSwiftCode.Text)
            cmd.Parameters.AddWithValue("@SettlementPayee", txtbankAddress.Text.ToUpper)
            cmd.Parameters.AddWithValue("@NTN", txtDateTimeStamp.Text)
            cmd.Parameters.AddWithValue("@CDS_Number", " ")
            cmd.Parameters.AddWithValue("@BrokerCode", Session("BrokerCode"))
            cmd.Parameters.AddWithValue("@Date_Created", Now.Date)
            cmd.Parameters.AddWithValue("@Update_Type", "NEW")
            cmd.Parameters.AddWithValue("@Created_By", Session("username"))
            cmd.Parameters.AddWithValue("@AuthorizationState", "O")
            cmd.Parameters.AddWithValue("@TradingStatus", "Trading")
            cmd.Parameters.AddWithValue("@AgreementDate", validateDate(" "))
            cmd.Parameters.AddWithValue("@PlaceofBirth", " ")
            cmd.Parameters.AddWithValue("@Middlename", " ")
            cmd.Parameters.AddWithValue("@Initials", " ")
            cmd.Parameters.AddWithValue("@Add_2", " ")
            cmd.Parameters.AddWithValue("@Add_3", " ")
            cmd.Parameters.AddWithValue("@Add_4", " ")
            cmd.Parameters.AddWithValue("@City", " ")
            cmd.Parameters.AddWithValue("@Category", " ")
            cmd.Parameters.AddWithValue("@Industry", " ")
            cmd.Parameters.AddWithValue("@Tax", " ")
            cmd.Parameters.AddWithValue("@Cash_Bank", " ")
            cmd.Parameters.AddWithValue("@Cash_Branch", " ")
            cmd.Parameters.AddWithValue("@idnopp2", " ")
            cmd.Parameters.AddWithValue("@idtype2", " ")
            cmd.Parameters.AddWithValue("@mobile_money", " ")
            cmd.Parameters.AddWithValue("@mobile_number", " ")
            cmd.Parameters.AddWithValue("@FH", " ")
            cmd.Parameters.AddWithValue("@marital_status", " ")
            cmd.Parameters.AddWithValue("@Occupations", " ")
            cmd.Parameters.AddWithValue("@GAI", " ")
            cmd.Parameters.AddWithValue("@CNIC_expiry_date", validateDate(" "))
            cmd.Parameters.AddWithValue("@Password_expiry_date", validateDate(" "))
            cmd.Parameters.AddWithValue("@Permanet_Address", " ")
            cmd.Parameters.AddWithValue("@Permanet_Address1", " ")
            cmd.Parameters.AddWithValue("@Permanet_Address2", " ")
            cmd.Parameters.AddWithValue("@Permanet_Address3", " ")
            cmd.Parameters.AddWithValue("@Provinces", " ")
            cmd.Parameters.AddWithValue("@Designation", " ")
            cmd.Parameters.AddWithValue("@Resident_Status", " ")
            cmd.Parameters.AddWithValue("@Confirmation", " ")
            cmd.Parameters.AddWithValue("@FirstWitnessName", " ")
            cmd.Parameters.AddWithValue("@FirstWitnessCNIC", " ")
            cmd.Parameters.AddWithValue("@SecondWitnessName", " ")
            cmd.Parameters.AddWithValue("@SecondWitnessCNIC", " ")
            cmd.Parameters.AddWithValue("@FathersName", " ")
            cmd.Parameters.AddWithValue("@Tax_exemption", " ")
            cmd.Parameters.AddWithValue("@placeofissue", " ")
            cmd.Parameters.AddWithValue("@Nominee_Name", " ")
            cmd.Parameters.AddWithValue("@Nominee_Account_Id", " ")
            cmd.Parameters.AddWithValue("@Nominee_Email", " ")
            cmd.Parameters.AddWithValue("@Nominee_Mobile", " ")
            cmd.Parameters.AddWithValue("@Nominee_Father_Husband_Name", " ")
            cmd.Parameters.AddWithValue("@Nominee_CNIC", " ")
            cmd.Parameters.AddWithValue("@Nominee_Address", " ")
            cmd.Parameters.AddWithValue("@Nominee_Gender", " ")
            cmd.Parameters.AddWithValue("@nomineerelation", " ")
            If (cn.State = ConnectionState.Open) Then
                cn.Close()
            End If
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()
            Dim queryString As String = ""
            If rdIndividual.Checked = True Then
                queryString = "AccountPrintReport.aspx?Username=" + Session("Username") + "&AccType=I"
            ElseIf rdJoint.Checked = True Then
                queryString = "AccountPrintReport.aspx?Username=" + Session("Username") + "&AccType=J"
            End If
            Dim newWin As String = "window.open('" + queryString + "','_blank');"
            ClientScript.RegisterStartupScript(Me.GetType(), "pop", newWin, True)
        Catch ex As Exception
            ErrorLogging.WriteLogFile(Session("Username"), Request.Url.ToString, ex.ToString)
        End Try
    End Sub
    Private Function CNICExits() As Boolean
        Dim ds As New DataSet
        cmd = New SqlCommand("Select CNIC from Accounts_Audit where REPLACE(CNIC,'-','')= REPLACE(@idnopp,'-','') union Select CNIC from Accounts_Clients where REPLACE(CNIC,'-','')= REPLACE(@idnopp,'-','') ", cn)
        cmd.Parameters.AddWithValue("@idnopp", txtCNIC.Text)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "Accounts")
        If (ds.Tables(0).Rows.Count > 0) Then
            Return True
        Else
            Return False
        End If
    End Function
    Private Function CNICExits_inAUDIT(ByVal CNIC As String, ByVal JointName As String) As Boolean
        Dim ds As New DataSet
        cmd = New SqlCommand(" SELECT * FROM Accounts_Joint_Audit WHERE JointName=@JointName AND REPLACE(CNIC,'-','')= REPLACE(@CNIC,'-','') ", cn)
        cmd.Parameters.AddWithValue("@CNIC", CNIC)
        cmd.Parameters.AddWithValue("@JointName", JointName)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "Accounts_Joint_Audit")
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
    Sub ShowHide_Single(ByVal action As String)
        If action = "Show" Then
            Panel13a.Visible = True
            Panel13d.Visible = True
            ASPxLabel117.Text = "Personal Details"
            txtCNIC.Enabled = False
        ElseIf action = "Hide" Then
            Panel13a.Visible = False
            Panel13d.Visible = False
        End If
    End Sub
    Sub ShowHide_Joint(ByVal action As String)
        If action = "Show" Then
            Panel15a.Visible = True
            Panel15b.Visible = True
            Panel15d.Visible = True
            ASPxLabel117.Text = "Personal Details (Principal Member)"
            txtCNIC.Enabled = True
            Panel20a.Visible = True
            Panel20b.Visible = True
            Panel20c.Visible = True
            Panel20d.Visible = True
            panel20e.Visible = True
            panel20f.Visible = True
        ElseIf action = "Hide" Then
            Panel15a.Visible = False
            Panel15b.Visible = False
            Panel15d.Visible = False
            Panel20a.Visible = False
            Panel20b.Visible = False
            Panel20c.Visible = False
            Panel20d.Visible = False
            panel20e.Visible = False
            panel20f.Visible = False
        End If
    End Sub
    Sub ShowHideAll(ByVal action As String)
        If action = "Show" Then
            Panel8a.Visible = True
            Panel8b.Visible = True
            Panel8d.Visible = True
            Panel8l.Visible = True
            Panel8f.Visible = True
            Panel8k.Visible = True
            Panel3a.Visible = True
            Panel8i.Visible = True
            Panel3b.Visible = True
            Panel3bb.Visible = True
            Panel3bbb.Visible = True
            Panel3bbbb.Visible = True
            Panel3l.Visible = True
            Panel4a.Visible = True
            Panel4b.Visible = True
            Panel4c.Visible = True
            Panel4d.Visible = True
            Panel4e.Visible = True
            panelSave1.Visible = True
            panelSave2.Visible = True
            panelSave3.Visible = True
            panelSave4.Visible = True
            panelSave5.Visible = True
            panelsaving2.Visible = True
            panelsaving2a.Visible = True
        ElseIf action = "Hide" Then
            Panel8a.Visible = False
            Panel8b.Visible = False
            Panel8d.Visible = False
            Panel8l.Visible = False
            Panel8f.Visible = False
            Panel8k.Visible = False
            Panel3a.Visible = False
            Panel8i.Visible = False
            Panel3b.Visible = False
            Panel3bb.Visible = False
            Panel3bbb.Visible = False
            Panel3bbbb.Visible = False
            Panel3l.Visible = False
            Panel4a.Visible = False
            Panel4b.Visible = False
            Panel4c.Visible = False
            Panel4d.Visible = False
            Panel4e.Visible = False
            panelSave1.Visible = False
            panelSave2.Visible = False
            panelSave3.Visible = False
            panelSave4.Visible = False
            panelSave5.Visible = False
            panelsaving2.Visible = False
            panelsaving2a.Visible = False
        End If
    End Sub
    Sub ShowHide_Joint1(ByVal action As String)
        If action = "Show" Then
            Panel15a.Visible = True
            Panel15b.Visible = True
            Panel15d.Visible = True
        ElseIf action = "Hide" Then
            Panel15a.Visible = False
            Panel15b.Visible = False
            Panel15d.Visible = False
        End If
    End Sub
    Public Function validateJOINTFields() As Boolean
        If (Len(txtnexofkeenName.Text.Trim) < 1) Then
            msgbox("Please enter a Fullname")
            txtnexofkeenName.Focus()
            Return False
        End If
        If (Len(txtrelation.Text.Trim) < 1) Then
            msgbox("Please enter Relation")
            txtrelation.Focus()
            Return False
        End If
        If txtnexofkeenAddress.Text = "" Then
            msgbox("Please enter mailing address")
            txtnexofkeenAddress.Focus()
            Return False
        End If
        If txtnextofKeenMobile.Text = "" Then
            msgbox("Please enter mobile")
            txtnextofKeenMobile.Focus()
            Return False
        End If
        Return True
    End Function
    Protected Sub grdJointAccounts_RowCommand(sender As Object, e As DevExpress.Web.ASPxGridView.ASPxGridViewRowCommandEventArgs) Handles grdJointAccounts.RowCommand
        Try
            Dim myID As String = e.CommandArgs.CommandArgument.ToString
            If e.CommandArgs.CommandName = "Delete" Then
                Using cn = New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("connpath"))
                    Using cmd As New SqlCommand("DELETE FROM Accounts_Joint_Audit WHERE ID='" & myID & "'", cn)
                        If cn.State = ConnectionState.Open Then cn.Close()
                        cn.Open()
                        cmd.ExecuteNonQuery()
                        cn.Close()
                        getJointHolders()
                    End Using
                End Using
            End If
        Catch ex As Exception
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
                    Using cmd As New SqlCommand("IF NOT EXISTS(SELECT TOP 1 * FROM Client_AssetManagersAudit H WHERE H.IDNo=@IDNo AND H.AssetManager=@AssetManager AND H.BankAccount=@BankAccount) BEGIN INSERT INTO Client_AssetManagersAudit([IDNo], [AssetManager], [BankAccount], [BankName], [BankBranch], [DateLinked], [LinkedBy])VALUES(@IDNo, @AssetManager,@BankAccount,@BankName,@BankBranch,getdate(),@LinkedBy) END", cn)
                        '@ClientNo, @AssetManager,@BankAccount,@BankName,@BankBranch,@DateLinked,@LinkedBy
                        cmd.Parameters.AddWithValue("@IDNo", txtIDNo.Text)
                        cmd.Parameters.AddWithValue("@AssetManager", AssetManagerCode)
                        cmd.Parameters.AddWithValue("@BankAccount", AccountNumber)
                        cmd.Parameters.AddWithValue("@BankName", BankCode)
                        cmd.Parameters.AddWithValue("@BankBranch", BranchCode)
                        cmd.Parameters.AddWithValue("@LinkedBy", Session("Username"))
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
        strSQL = "SELECT * FROM Client_AssetManagersAudit WHERE IDNo='" & txtIDNo.Text & "'"
        Using cn = New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("connpath"))
            Dim ds As New DataSet
            Dim cmd = New SqlCommand(strSQL, cn)
            Dim adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "Client_AssetManagersAudit")
            If ds.Tables(0).Rows.Count > 0 Then
                grdAsertManagersClients.DataSource = ds
                grdAsertManagersClients.DataBind()
            Else
                grdAsertManagersClients.DataSource = Nothing
                grdAsertManagersClients.DataBind()
            End If
        End Using
    End Sub
End Class
