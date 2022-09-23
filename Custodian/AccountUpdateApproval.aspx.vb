Imports System.Data
Imports System.Data.SqlClient
Partial Class Custodian_AccountUpdateApproval
    Inherits System.Web.UI.Page
    Dim constr As String = (System.Configuration.ConfigurationManager.AppSettings("connpath"))
    Dim cn As New SqlConnection(constr)
    Dim cmd As SqlCommand
    Dim adp As SqlDataAdapter
    Dim ds As New DataSet
    Dim maxholder As Integer = 0
    Public Sub msgbox(ByVal strMessage As String)

        'finishes server processing, returns to client.
        Dim strScript As String = "<script language=JavaScript>"
        strScript += "window.alert(""" & strMessage & """);"
        strScript += "</script>"
        Dim lbl As New System.Web.UI.WebControls.Label
        lbl.Text = strScript
        Page.Controls.Add(lbl)

    End Sub
    Public Sub GetHolderData()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("Select * from pre_names_Creation where approved=0 and brokercode='" & Session("BrokerCode") & "' and RecType='UPDATE'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "pre_names_creation")
            If (ds.Tables(0).Rows.Count > 0) Then
                cmbCdsNumber.DataSource = ds.Tables(0)
                cmbCdsNumber.DataValueField = "cds_number"
                cmbCdsNumber.DataBind()
            Else
                cmbCdsNumber.DataSource = Nothing
                cmbCdsNumber.DataValueField = ""
                cmbCdsNumber.DataBind()
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub getHolderDetails()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select * from pre_names_creation where cds_number='" & cmbCdsNumber.Text & "' and Approved=0 and brokercode='" & Session("BrokerCode") & "' and RecType='UPDATE'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "pre_names_creation")
            If (ds.Tables(0).Rows.Count > 0) Then

                Dim signpath As String = ConfigurationManager.AppSettings("Signatures").ToString
                Image1.ImageUrl = signpath & ds.Tables(0).Rows(0).Item("ImageId").ToString
                'txtTax.Text = signpath & ds.Tables(0).Rows(0).Item("ImageId").ToString

                txtSurname.Text = ds.Tables(0).Rows(0).Item("surname").ToString
                txtforenames.Text = ds.Tables(0).Rows(0).Item("forenames").ToString
                txtID.Text = ds.Tables(0).Rows(0).Item("IDpp").ToString
                txtDOB.Text = ds.Tables(0).Rows(0).Item("DOB").ToString
                txtAdd1.Text = ds.Tables(0).Rows(0).Item("Add_1").ToString
                txtAdd2.Text = ds.Tables(0).Rows(0).Item("Add_2").ToString
                txtadd3.Text = ds.Tables(0).Rows(0).Item("Add_3").ToString
                txtadd4.Text = ds.Tables(0).Rows(0).Item("Add_4").ToString
                txtCountry.Text = ds.Tables(0).Rows(0).Item("Country").ToString
                txtCity.Text = ds.Tables(0).Rows(0).Item("City").ToString
                txtTel.Text = ds.Tables(0).Rows(0).Item("Telephone").ToString
                txtFax.Text = ds.Tables(0).Rows(0).Item("Fax").ToString
                txtEmail.Text = ds.Tables(0).Rows(0).Item("Email").ToString
                txtCell.Text = ds.Tables(0).Rows(0).Item("Cellphone").ToString
                txtBank.Text = ds.Tables(0).Rows(0).Item("Bank_Name").ToString
                txtBranch.Text = ds.Tables(0).Rows(0).Item("Branch_Name").ToString
                txtBnkAccount.Text = (ds.Tables(0).Rows(0).Item("Account").ToString)
                txtIndustry.Text = ds.Tables(0).Rows(0).Item("Industry").ToString
                txtTax.Text = ds.Tables(0).Rows(0).Item("Tax").ToString



                If (ds.Tables(0).Rows(0).Item("Holder_type").ToString = "1") Then
                    lblAccount.Text = "Individual Account"
                End If
                If (ds.Tables(0).Rows(0).Item("Holder_type").ToString = "2") Then
                    lblAccount.Text = "Joint Account"
                End If
                If (ds.Tables(0).Rows(0).Item("Holder_type").ToString = "3") Then
                    lblAccount.Text = "Nominee Account"
                End If
                If (ds.Tables(0).Rows(0).Item("Holder_type").ToString = "4") Then
                    lblAccount.Text = "Company Account"
                End If


                Image1.width = "100"

            Else
                txtSurname.Text = ""
                txtforenames.Text = ""
                txtID.Text = ""
                txtDOB.Text = ""
                txtAdd1.Text = ""
                txtAdd2.Text = ""
                txtadd3.Text = ""
                txtadd4.Text = ""
                txtCountry.Text = ""
                txtCity.Text = ""
                txtTel.Text = ""
                txtFax.Text = ""
                txtEmail.Text = ""
                txtCell.Text = ""
                txtBank.Text = ""
                txtBranch.Text = ""
                txtBnkAccount.Text = ""
                txtIndustry.Text = ""
                txtTax.Text = ""
                lblAccount.Text = ""
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Try
            Dim AccType As String = ""
            Dim ds As New DataSet
            cmd = New SqlCommand("Select * from pre_names_creation where cds_number='" & cmbCdsNumber.Text & "' and approved=0", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "pre_names_creation")
            If (ds.Tables(0).Rows.Count > 0) Then
                'cmd = New SqlCommand("update names set surname='" & ds.Tables(0).Rows(0).Item("").ToString & "', forenames='" & ds.Tables(0).Rows(0).Item("").ToString & "',iddpp='" & ds.Tables(0).Rows(0).Item("").ToString & "',dob='" & ds.Tables(0).Rows(0).Item("").ToString & "',add_1'" & ds.Tables(0).Rows(0).Item("").ToString & "',add_2='" & ds.Tables(0).Rows(0).Item("").ToString & "',add_3='" & ds.Tables(0).Rows(0).Item("").ToString & "',add_4='" & ds.Tables(0).Rows(0).Item("").ToString & "',city='" & ds.Tables(0).Rows(0).Item("").ToString & "',country='" & ds.Tables(0).Rows(0).Item("").ToString & "',telephone='" & ds.Tables(0).Rows(0).Item("").ToString & "',cellphone='" & ds.Tables(0).Rows(0).Item("").ToString & "',fax='" & ds.Tables(0).Rows(0).Item("").ToString & "',email='" & ds.Tables(0).Rows(0).Item("").ToString & "',bank_name='" & ds.Tables(0).Rows(0).Item("").ToString & "',bank_code='" & ds.Tables(0).Rows(0).Item("").ToString & "',branch_name='" & ds.Tables(0).Rows(0).Item("").ToString & "',branch_code='" & ds.Tables(0).Rows(0).Item("").ToString & "',account='" & ds.Tables(0).Rows(0).Item("").ToString & "',tax='" & ds.Tables(0).Rows(0).Item("").ToString & "',hfc='" & ds.Tables(0).Rows(0).Item("").ToString & "',locked='" & ds.Tables(0).Rows(0).Item("").ToString & "',updated_by='" & ds.Tables(0).Rows(0).Item("").ToString & "',updated_on='" & ds.Tables(0).Rows(0).Item("").ToString & "' where cds_number='" & cmbCdsNumber.Text & "'", cn)
                'MsgBox("Insert into names (shareholder,broker_code,CDS_Number,Surname,Forenames,IDpp,DOB,add_1,add_2,add_3,add_4,city,country,Telephone,Cellphone,fax,email,Bank_Name,Bank_Code,Branch_name,Branch_Code,Account,Tax,Updated_by,Updated_on,Industry,Approved,Approved_by,Approved_On,Holder_type) values(" & ds.Tables(0).Rows(0).Item("Shareholder").ToString & ",'" & ds.Tables(0).Rows(0).Item("BrokerCode").ToString & "','" & ds.Tables(0).Rows(0).Item("CDS_Number").ToString & "','" & ds.Tables(0).Rows(0).Item("Surname").ToString & "','" & ds.Tables(0).Rows(0).Item("Forenames").ToString & "','" & ds.Tables(0).Rows(0).Item("IDPP").ToString & "','" & ds.Tables(0).Rows(0).Item("DOB").ToString & "','" & ds.Tables(0).Rows(0).Item("ADD_1").ToString & "','" & ds.Tables(0).Rows(0).Item("ADD_2").ToString & "','" & ds.Tables(0).Rows(0).Item("ADD_3").ToString & "','" & ds.Tables(0).Rows(0).Item("ADD_4").ToString & "','" & ds.Tables(0).Rows(0).Item("CITY").ToString & "','" & ds.Tables(0).Rows(0).Item("COUNTRY").ToString & "','" & ds.Tables(0).Rows(0).Item("TELEPHONE").ToString & "','" & ds.Tables(0).Rows(0).Item("CELLPHONE").ToString & "','" & ds.Tables(0).Rows(0).Item("FAX").ToString & "','" & ds.Tables(0).Rows(0).Item("EMAIL").ToString & "','" & ds.Tables(0).Rows(0).Item("BANK_NAME").ToString & "','" & ds.Tables(0).Rows(0).Item("BANK_CODE").ToString & "','" & ds.Tables(0).Rows(0).Item("BRANCH_NAME").ToString & "','" & ds.Tables(0).Rows(0).Item("BRANCH_CODE").ToString & "','" & ds.Tables(0).Rows(0).Item("ACCOUNT").ToString & "'," & ds.Tables(0).Rows(0).Item("TAX").ToString & ",'" & ds.Tables(0).Rows(0).Item("Updated_By").ToString & "','" & ds.Tables(0).Rows(0).Item("Update_On").ToString & "','" & ds.Tables(0).Rows(0).Item("Industry").ToString & "',1,'" & Session("UserName") & "','" & Date.Now & "','" & ds.Tables(0).Rows(0).Item("Holder_type").ToString & "')")
                If (cn.State = ConnectionState.Open) Then
                    cn.Close()
                End If
                cn.Open()
                cmd.ExecuteNonQuery()
                cn.Close()

                cmd = New SqlCommand("Update pre_names_creation set Approved=1 where cds_number='" & cmbCdsNumber.Text & "' and brokercode='" & Session("BrokerCode") & "' and approved=0", cn)
                If (cn.State = ConnectionState.Open) Then
                    cn.Close()
                End If
                cn.Open()
                cmd.ExecuteNonQuery()
                cn.Close()

                msgbox("Account Approved")
                cleartext()
                GetHolderData()
                getHolderDetails()
            Else
                msgbox("Unable to Update")
            End If

        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub getHolderNumber()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select max(shareholder) as shareholder from pre_names_creation ", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "pre_names_creation")
            maxholder = CInt(ds.Tables(0).Rows(0).Item("shareholder").ToString) + 1
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Page.MaintainScrollPositionOnPostBack = True
        If (Not IsPostBack) Then
            GetHolderData()
            getHolderDetails()
        End If
    End Sub
    Public Sub cleartext()
        Try
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
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub cmbCdsNumber_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbCdsNumber.SelectedIndexChanged
        Try
            getHolderDetails()
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
End Class
