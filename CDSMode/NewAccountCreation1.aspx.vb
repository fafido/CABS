
Imports System.Linq
Imports System.Threading
Imports DevExpress.Utils.OAuth

Partial Class TSecMode_NewAccountCreation
    Inherits System.Web.UI.Page
    Dim constr As String = (System.Configuration.ConfigurationManager.AppSettings("connpath"))
    Dim cn As New SqlConnection(constr)
    Dim cmd As SqlCommand
    Dim adp As SqlDataAdapter
    Dim ds As New DataSet
    Dim dst As New DataSet
    Dim password As Integer
    Dim totalSahres As Integer

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load

        If Not IsPostBack Then


            '            If Not String.IsNullOrEmpty(Session("CreatedNumber")) Then
            If Session("SavedSuccess1") = "SavedSuccess" Then
                msgbox("Account Saved Successfully. The allocated ATP Number is " + Session("CreatedNumber").ToString())
                lastCreatedCds.Text ="Last ATP number is " + Session("CreatedNumber").ToString()
            End If

            Session("SavedSuccess1") = ""
            Session("CreatedNumber") = ""

            GetBankName()
            jointName.Visible = False
            Panel8.Visible = False
            accType.SelectedIndex = 0
            Panel1.Visible = False
            '            Panel2.Visible = False
        End If
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
            cmd = New SqlCommand("  select distinct Company FROM [CDS].[dbo].[CertMaster]", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "para_bank")
            If (ds.Tables(0).Rows.Count > 0) Then
                certCompany.DataSource = ds.Tables(0)
                certCompany.DataValueField = "Company"
                certCompany.DataTextField = "Company"
                certCompany.DataBind()
            End If
            certCompany.Items.Insert(0, New ListItem("--Select Company--", "0"))
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Protected Sub Unnamed13_Click(sender As Object, e As EventArgs)


        If accType.SelectedIndex = 0 Then
            If (Len(idNumberTxt.Text) < 1) Then
                msgbox("Please enter a valid Id Number")
                idNumberTxt.Focus()
                Exit Sub
            End If

            If (Len(surnameTxt.Text) < 1) Then
                msgbox("Please enter a valid Surname")
                surnameTxt.Focus()
                Exit Sub
            End If

            If (Len(forenameTxt.Text) < 1) Then
                msgbox("Please enter a valid Forename")
                forenameTxt.Focus()
                Exit Sub
            End If
        ElseIf accType.SelectedIndex = 1 Then

            If (Len(jointName.Text) < 1) Then
                msgbox("Please enter a valid Joint Acount Name")
                jointName.Focus()
                Exit Sub
            End If

        ElseIf accType.SelectedIndex = 2 Then
            '            If (Len(certNumberTxt.Text) < 1) Then
            '                msgbox("Please enter a valid Certificate Number")
            '                certNumberTxt.Focus()
            '                Exit Sub
            '            End If
            '
            '            If (Len(holderTxt.Text) < 1) Then
            '                msgbox("Please enter a valid Holder")
            '                holderTxt.Focus()
            '                Exit Sub
            '            End If
            '
            '            If (Len(certCompany.SelectedValue.Equals("0")) < 1) Then
            '                msgbox("Please enter a valid Company")
            '                certCompany.Focus()
            '                Exit Sub
            '            End If
        End If




        '        msgbox(certCompany.SelectedValue)

        Dim userAdded As Boolean = False
        Dim certAdded As Boolean = False
        Dim certValid As Boolean = False


        Dim cdsNo As String = ""
        Dim dsi As New DataSet
        cmd = New SqlCommand("select * from Accounts_Audit", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(dsi, "Accounts_Audit")
        If (dsi.Tables(0).Rows.Count > 0) Then
            Dim dsh As New DataSet
            cmd = New SqlCommand("select max(ID) as ID from Accounts_Audit", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(dsh, "Accounts_Audit")

            password = 3
            password = CreateRandomPassword(Integer.Parse(password))
            cdsNo = (CInt(dsh.Tables(0).Rows(0).Item("ID").ToString + 1)).ToString.PadLeft(10, "0") & clientcompanyid(Session("BrokerCode")).ToString & password
        Else
            cdsNo = Session("BrokerCode").ToString & "0000001"
        End If


        Using Cony As New SqlConnection(constr)
            Cony.Open()
            Using Comy As New SqlCommand("SELECT * from [dbo].[AccountNewDetails] where IdNumber='" & idNumberTxt.Text & "'", Cony)
                Using RDR = Comy.ExecuteReader()
                    If RDR.HasRows Then
                        Do While RDR.Read
                            userAdded = True
                        Loop
                    End If
                End Using
            End Using
            Cony.Close()
        End Using

        Using Cony As New SqlConnection(constr)
            Cony.Open()
            Using Comy As New SqlCommand("SELECT * from [dbo].[AccountNewCertificates] where CertificateNumber='" & certNumberTxt.Text & "' and Holder='" & holderTxt.Text & "'", Cony)
                Using RDR = Comy.ExecuteReader()
                    If RDR.HasRows Then
                        Do While RDR.Read
                            certAdded = True
                        Loop
                    End If
                End Using
            End Using
            Cony.Close()
        End Using

        If accType0.SelectedIndex = 1 Then



            If Not userAdded Then
                Dim queryQ = "INSERT INTO [dbo].[AccountNewDetails] ([CdsNumber], [IdNumber], [Surname], [Forename], [Date], [CapturedBy], [CompanyCode], [ISIN], [DateOfInc]) VALUES (@CdsNumber, @IdNumber, @Surname, @Forename, @Date, @CapturedBy, @CompanyCode, @ISIN, @DateOfInc)"
                Using con As New SqlConnection(constr)
                    Using com As New SqlCommand()
                        With com
                            .Connection = con
                            .CommandType = CommandType.Text
                            .CommandText = queryQ

                            .Parameters.AddWithValue("@CdsNumber", cdsNo)

                            If accType.SelectedIndex = 0 Then
                                .Parameters.AddWithValue("@IdNumber", idNumberTxt.Text)
                                .Parameters.AddWithValue("@Surname", surnameTxt.Text)
                                .Parameters.AddWithValue("@Forename", forenameTxt.Text)
                                .Parameters.AddWithValue("@CompanyCode", "")
                                .Parameters.AddWithValue("@ISIN", "")
                                .Parameters.AddWithValue("@DateOfInc", "")
                            ElseIf accType.SelectedIndex = 1 Then
                                .Parameters.AddWithValue("@IdNumber", jointName.Text)
                                .Parameters.AddWithValue("@Surname", jointName.Text)
                                .Parameters.AddWithValue("@Forename", jointName.Text)
                                .Parameters.AddWithValue("@CompanyCode", jointName.Text)
                                .Parameters.AddWithValue("@ISIN", jointName.Text)
                                '                                .Parameters.AddWithValue("@CompanyCode", "")
                                '                                .Parameters.AddWithValue("@ISIN", "")
                                .Parameters.AddWithValue("@DateOfInc", "")
                            ElseIf accType.SelectedIndex = 2 Then
                                .Parameters.AddWithValue("@IdNumber", txtMiddleName0.Text)
                                .Parameters.AddWithValue("@Surname", txtSurname.Text)
                                .Parameters.AddWithValue("@Forename", "")
                                .Parameters.AddWithValue("@CompanyCode", txtMiddleName.Text)
                                .Parameters.AddWithValue("@ISIN", txtMiddleName.Text)
                                .Parameters.AddWithValue("@DateOfInc", txtDOB.Text)
                            End If

                            .Parameters.AddWithValue("@Date", DateTime.Now)
                            .Parameters.AddWithValue("@CapturedBy", Session("Username").ToString())
                        End With
                        Try
                            con.Open()
                            com.ExecuteNonQuery()
                        Catch ex As SqlException
                            msgbox(ex.ToString())
                            '                    Logs(ex.ToString())
                        End Try
                    End Using
                End Using
            Else
                msgbox("Account already added")
            End If

        ElseIf accType0.SelectedIndex = 0 Then

            '            msgbox(certCompany.SelectedValue)

            If (certCompany.SelectedValue.Equals("0")) Then
                msgbox("Please enter a valid Company")
                certCompany.Focus()
                Exit Sub
            End If



            Using Cony As New SqlConnection(constr)
                Cony.Open()

                Dim styInd = ""

                If accType.SelectedIndex = 0 Then
                    styInd = "SELECT * from [CDS].[dbo].[CertMaster] cm join [CDS].[dbo].[CertNames] cn on cm.Shareholder=cn.Shareholder where (cm.CertNumber='" & certNumberTxt.Text & "' and cm.Shareholder='" & holderTxt.Text & "' and cm.Company='" & certCompany.Text & "' and cn.IdNumber='" & idNumberTxt.Text & "') or (cm.CertNumber='" & certNumberTxt.Text & "' and cn.OldId='" & holderTxt.Text & "' and cm.Company='" & certCompany.Text & "' and cn.IdNumber='" & idNumberTxt.Text & "')"
                Else
                    styInd = "SELECT * from [CDS].[dbo].[CertMaster] cm join [CDS].[dbo].[CertNames] cn on cm.Shareholder=cn.Shareholder where (cm.CertNumber='" & certNumberTxt.Text & "' and cm.Shareholder='" & holderTxt.Text & "' and cm.Company='" & certCompany.Text & "') or (cm.CertNumber='" & certNumberTxt.Text & "' and cn.OldId='" & holderTxt.Text & "' and cm.Company='" & certCompany.Text & "')"
                End If
                

                Using Comy As New SqlCommand(styInd, Cony)
                    Using RDR = Comy.ExecuteReader()
                        If RDR.HasRows Then
                            'INSERTING INTWO NAMES
                            If Not userAdded Then
                                Dim queryQ = "INSERT INTO [dbo].[AccountNewDetails] ([CdsNumber], [IdNumber], [Surname], [Forename], [Date], [CapturedBy], [CompanyCode], [ISIN], [DateOfInc]) VALUES (@CdsNumber, @IdNumber, @Surname, @Forename, @Date, @CapturedBy, @CompanyCode, @ISIN, @DateOfInc)"
                                Using con As New SqlConnection(constr)
                                    Using com As New SqlCommand()
                                        With com
                                            .Connection = con
                                            .CommandType = CommandType.Text
                                            .CommandText = queryQ

                                            .Parameters.AddWithValue("@CdsNumber", cdsNo)

                                            If accType.SelectedIndex = 0 Then
                                                .Parameters.AddWithValue("@IdNumber", idNumberTxt.Text.Replace(" ", "").Replace("-", ""))
                                                .Parameters.AddWithValue("@Surname", surnameTxt.Text)
                                                .Parameters.AddWithValue("@Forename", forenameTxt.Text)
                                                .Parameters.AddWithValue("@CompanyCode", "")
                                                .Parameters.AddWithValue("@ISIN", "")
                                                .Parameters.AddWithValue("@DateOfInc", "")
                                            ElseIf accType.SelectedIndex = 1 Then
                                                .Parameters.AddWithValue("@IdNumber", jointName.Text)
                                                .Parameters.AddWithValue("@Surname", jointName.Text)
                                                .Parameters.AddWithValue("@Forename", jointName.Text)
                                                .Parameters.AddWithValue("@CompanyCode", jointName.Text)
                                                .Parameters.AddWithValue("@ISIN", jointName.Text)
                                                .Parameters.AddWithValue("@DateOfInc", "")
                                            ElseIf accType.SelectedIndex = 2 Then
                                                .Parameters.AddWithValue("@IdNumber", txtMiddleName0.Text)
                                                .Parameters.AddWithValue("@Surname", txtSurname.Text)
                                                .Parameters.AddWithValue("@Forename", "")
                                                .Parameters.AddWithValue("@CompanyCode", txtMiddleName.Text)
                                                .Parameters.AddWithValue("@ISIN", txtMiddleName.Text)
                                                .Parameters.AddWithValue("@DateOfInc", txtDOB.Text)
                                            End If
                                            .Parameters.AddWithValue("@Date", DateTime.Now)
                                            .Parameters.AddWithValue("@CapturedBy", Session("Username").ToString())
                                        End With
                                        Try
                                            con.Open()
                                            com.ExecuteNonQuery()

                                        Catch ex As SqlException
                                            '                    Logs(ex.ToString())
                                        End Try
                                    End Using
                                End Using
                            Else
                                '                            msgbox("User already added")
                            End If



                            cmd = New SqlCommand("SELECT cm.Company, cm.Shareholder, cm.CertNumber, cm.Shares FROM [CDS].[dbo].[CertMaster] cm left outer join [CDS].[dbo].[CertNames] cn on cm.Shareholder = cn.Shareholder where (CertNumber='" & certNumberTxt.Text & "' and cm.Shareholder='" & holderTxt.Text & "' and cm.Company='" & certCompany.Text & "') or (CertNumber='" & certNumberTxt.Text & "' and cn.OldId='" & holderTxt.Text & "' and cm.Company='" & certCompany.Text & "')", cn)
                            adp = New SqlDataAdapter(cmd)
                            adp.Fill(ds, "APP")
                            Dim total As Integer = 0


                            For Each dr As DataRow In ds.Tables(0).Rows

                                '1. Check if it has not been inserted already
                                '2. insert
                                '3. retrieve


                                Dim holder =  holderTxt.Text

                                'dr.Item("Shareholder").ToString()


                                Dim cert = dr.Item("CertNumber").ToString()

                                Using Conz As New SqlConnection(constr)
                                    Conz.Open()
                                    Using Comz As New SqlCommand("SELECT * from [dbo].[AccountNewCertificates] where CertificateNumber='" & cert & "' and Holder='" & holder & "'", Conz)
                                        Using RDRZ = Comz.ExecuteReader()

                                            If Not RDRZ.HasRows Then
                                                Dim query1 = "INSERT INTO [dbo].[AccountNewCertificates] ([IdNumber], [CertificateNumber], [Holder], [Units], [Company]) VALUES (@IdNumber, @CertificateNumber, @Holder, @Units, @Company)"
                                                Using conn As New SqlConnection(constr)
                                                    Using comm As New SqlCommand()
                                                        With comm
                                                            .Connection = conn
                                                            .CommandType = CommandType.Text
                                                            .CommandText = query1
                                                            If accType.SelectedIndex = 0 Then
                                                                .Parameters.AddWithValue("@IdNumber", idNumberTxt.Text.Replace(" ", "").Replace("-", ""))
                                                            ElseIf accType.SelectedIndex = 1 Then
                                                                .Parameters.AddWithValue("@IdNumber", jointName.Text)
                                                            ElseIf accType.SelectedIndex = 2 Then
                                                                .Parameters.AddWithValue("@IdNumber", txtMiddleName0.Text)
                                                            End If
                                                            .Parameters.AddWithValue("@CertificateNumber", dr.Item("CertNumber").ToString())
                                                            .Parameters.AddWithValue("@Holder", dr.Item("Shareholder").ToString())
                                                            .Parameters.AddWithValue("@Units", dr.Item("Shares").ToString())
                                                            .Parameters.AddWithValue("@Company", dr.Item("Company").ToString())
                                                        End With
                                                        Try
                                                            conn.Open()
                                                            comm.ExecuteNonQuery()
                                                            msgbox("Certficate Added Successfully")


                                                            If accType.SelectedIndex = 0 Then
                                                                cmd = New SqlCommand("SELECT * FROM [CDS].[dbo].[AccountNewCertificates] where [IdNumber]='" + idNumberTxt.Text.Replace(" ", "").Replace("-", "") + "' order by id desc", cn)
                                                            ElseIf accType.SelectedIndex = 1 Then
                                                                cmd = New SqlCommand("SELECT * FROM [CDS].[dbo].[AccountNewCertificates] where [IdNumber]='" + jointName.Text + "' order by id desc", cn)
                                                            ElseIf accType.SelectedIndex = 2 Then
                                                                cmd = New SqlCommand("SELECT * FROM [CDS].[dbo].[AccountNewCertificates] where [IdNumber]='" + txtMiddleName0.Text + "' order by id desc", cn)
                                                            End If


                                                            adp = New SqlDataAdapter(cmd)
                                                            adp.Fill(dst, "APP")
                                                            If dst.Tables(0).Rows.Count > 0 Then
                                                                grdApps.DataSource = dst.Tables(0)
                                                            Else
                                                                grdApps.DataSource = Nothing
                                                            End If
                                                            grdApps.DataBind()

                                                            Dim total1 As Integer = 0
                                                            For Each d1r As DataRow In dst.Tables(0).Rows
                                                                total += Int64.Parse(d1r.Item("Units"))
                                                                totalSahres += Int64.Parse(d1r.Item("Units"))
                                                                '                                                            msgbox(total.ToString())
                                                            Next

                                                            Session("totalShares") = total
                                                            grdApps.FooterRow.Cells(3).Text = "Shares"
                                                            grdApps.FooterRow.Cells(3).HorizontalAlign = HorizontalAlign.Left
                                                            grdApps.FooterRow.Cells(4).Text = total.ToString()

                                                        Catch ex As SqlException
                                                            msgbox("Something went wrong try again")
                                                        End Try
                                                    End Using
                                                End Using
                                            Else
                                                msgbox("Certificate already added")
                                                Exit Sub
                                            End If
                                        End Using
                                    End Using
                                    Conz.Close()
                                End Using
                            Next
                        Else
                            msgbox("Certificate not found")
                            Exit Sub
                        End If
                    End Using
                End Using
                Cony.Close()
            End Using
        End If
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
    Public Function clientcompanyid(ByVal companycode As String) As String
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select RIGHT('00000'+ISNULL(id,''),5) as ids from client_companies where company_code='" + companycode + "'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "ids")
            If (ds.Tables(0).Rows.Count > 0) Then
                Return ds.Tables(0).Rows(0).Item("ids").ToString
            Else
                Return companycode
            End If

        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Function
    '    Public Sub ClearTextBox(parent As Control)
    '
    '        For Each child As Control In parent.Controls
    '            ClearTextBox(child)
    '        Next
    '
    '        If TryCast(parent, TextBox) IsNot Nothing Then
    '            TryCast(parent, TextBox).Text = [String].Empty
    '        End If
    '
    '    End Sub
    Protected Sub Unnamed12_Click(sender As Object, e As EventArgs)
        Dim ind = ""
        Dim userAdded As Boolean = False
        Dim certAdded As Boolean = False
        Dim certValid As Boolean = False
        Dim acccreated As Boolean = False
        Dim cdsNo As String = ""
        Session("SavedSuccess1") = ""



        If accType0.SelectedIndex < 0 Then
            msgbox("Please select")
            '            idNumberTxt.Focus()
            Exit Sub
        End If

        If accType.SelectedIndex = 0 Then
            If accType.SelectedIndex < 0 Then
                msgbox("Please enter a valid Account Type")
                idNumberTxt.Focus()
                Exit Sub
            Else
                ind = idNumberTxt.Text.Replace(" ", "").Replace("-", "")
            End If

            If accType0.SelectedIndex = 0 Then

                '                If (Len(custodyText.Text) < 1) Then
                '                    msgbox("Please enter a valid Custody shares")
                '                    custodyText.Focus()
                '                    Exit Sub
                '                End If
                '                If (Len(tradingText.Text) < 1) Then
                '                    msgbox("Please enter a valid Trading Shares")
                '                    tradingText.Focus()
                '                    Exit Sub
                '                End If

            End If


        ElseIf accType.SelectedIndex = 1 Then
            '            If accType0.SelectedIndex = 0 Then


            If (Len(jointName.Text) < 1) Then
                msgbox("Please enter a valid Joint Acount Name")
                jointName.Focus()
                Exit Sub
            Else
                ind = jointName.Text

                '                End If
            End If
        ElseIf accType.SelectedIndex = 2 Then
            If (Len(txtMiddleName0.Text) < 1) Then
                msgbox("Please enter a valid Certificate of Incorporation Number")
                txtSurname.Focus()
                Exit Sub
            Else
                ind = txtMiddleName0.Text
            End If

            '                ind = jointName.Text

        End If






        Try
            Using Cony As New SqlConnection(constr)
                Cony.Open()
                Using Comy As New SqlCommand("SELECT *   FROM [CDS].[dbo].[Accounts_Clients] where IDNoPP='" & ind & "'", Cony)
                    Using RDR = Comy.ExecuteReader()
                        If RDR.HasRows Then
                            Do While RDR.Read
                                acccreated = True
                                '                                    msgbox("1")
                            Loop
                        End If
                    End Using
                End Using
                Cony.Close()
            End Using
        Catch ex As Exception
            msgbox(ex.ToString())
        End Try



        If Not acccreated Then
            If accType0.SelectedIndex = 1 Then

                Dim dsi As New DataSet
                cmd = New SqlCommand("select * from Accounts_Audit", cn)
                adp = New SqlDataAdapter(cmd)
                adp.Fill(dsi, "Accounts_Audit")
                If (dsi.Tables(0).Rows.Count > 0) Then
                    Dim dsh As New DataSet
                    cmd = New SqlCommand("select max(ID) as ID from Accounts_Audit", cn)
                    adp = New SqlDataAdapter(cmd)
                    adp.Fill(dsh, "Accounts_Audit")

                    password = 3
                    password = CreateRandomPassword(Integer.Parse(password))
                    cdsNo = (CInt(dsh.Tables(0).Rows(0).Item("ID").ToString + 1)).ToString.PadLeft(10, "0") & clientcompanyid(Session("BrokerCode")).ToString & password
                Else
                    cdsNo = Session("BrokerCode").ToString & "0000001"
                End If

                Try
                    Using Cony As New SqlConnection(constr)
                        Cony.Open()
                        Using Comy As New SqlCommand("SELECT * from [dbo].[AccountNewDetails] where IdNumber='" & ind & "'", Cony)
                            Using RDR = Comy.ExecuteReader()
                                If RDR.HasRows Then
                                    Do While RDR.Read
                                        userAdded = True
                                        '                                    msgbox("1")
                                    Loop
                                End If
                            End Using
                        End Using
                        Cony.Close()
                    End Using
                Catch ex As Exception
                    msgbox(ex.ToString())
                End Try

                '            If userAdded
                '                  msgbox("1" + ind)
                '                Else
                '                msgbox("Nothing f")
                '            End If



                If Not userAdded Then
                    Dim queryQ = "INSERT INTO [dbo].[AccountNewDetails] ([CdsNumber], [IdNumber], [Surname], [Forename], [Date], [CapturedBy], [CompanyCode], [ISIN], [DateOfInc], AccountType) VALUES (@CdsNumber, @IdNumber, @Surname, @Forename, @Date, @CapturedBy, @CompanyCode, @ISIN, @DateOfInc, @AccountType)"
                    Using con As New SqlConnection(constr)
                        Using com As New SqlCommand()
                            With com
                                .Connection = con
                                .CommandType = CommandType.Text
                                .CommandText = queryQ
                                '                            msgbox("1" + ind)
                                .Parameters.AddWithValue("@CdsNumber", cdsNo)

                                If accType.SelectedIndex = 0 Then
                                    '                                msgbox("2" + ind)
                                    .Parameters.AddWithValue("@IdNumber", idNumberTxt.Text.Replace(" ", "").Replace("-", ""))
                                    .Parameters.AddWithValue("@Surname", surnameTxt.Text)
                                    .Parameters.AddWithValue("@Forename", forenameTxt.Text)
                                    .Parameters.AddWithValue("@CompanyCode", "")
                                    .Parameters.AddWithValue("@ISIN", "")
                                    .Parameters.AddWithValue("@DateOfInc", "")
                                    .Parameters.AddWithValue("@AccountType", accType.SelectedValue)

                                ElseIf accType.SelectedIndex = 1 Then
                                    .Parameters.AddWithValue("@IdNumber", jointName.Text)
                                    .Parameters.AddWithValue("@Surname", jointName.Text)
                                    .Parameters.AddWithValue("@Forename", jointName.Text)
                                    .Parameters.AddWithValue("@CompanyCode", jointName.Text)
                                    .Parameters.AddWithValue("@ISIN", jointName.Text)
                                    .Parameters.AddWithValue("@DateOfInc", "")
                                    .Parameters.AddWithValue("@AccountType", accType.SelectedValue)

                                ElseIf accType.SelectedIndex = 2 Then
                                    .Parameters.AddWithValue("@IdNumber", txtMiddleName0.Text)
                                    .Parameters.AddWithValue("@Surname", txtSurname.Text)
                                    .Parameters.AddWithValue("@Forename", "")
                                    .Parameters.AddWithValue("@CompanyCode", txtMiddleName.Text)
                                    .Parameters.AddWithValue("@ISIN", txtMiddleName.Text)
                                    .Parameters.AddWithValue("@DateOfInc", txtDOB.Text)
                                    .Parameters.AddWithValue("@AccountType", accType.SelectedValue)
                                End If

                                .Parameters.AddWithValue("@Date", DateTime.Now)
                                .Parameters.AddWithValue("@CapturedBy", Session("Username").ToString())
                            End With
                            Try
                                con.Open()
                                com.ExecuteNonQuery()
                                '                                msgbox("Account added successfully")

                                Session("CreatedNumber") = cdsNo


                                Session("SavedSuccess1") = "SavedSuccess"
                                Response.Redirect(Request.RawUrl)

                                lastCreatedCds.Text = cdsNo




                                txtDOB.Text = ""
                                txtMiddleName.Text = ""
                                txtOthernames.Text = ""
                                txtSurname.Text = ""
                                txtMiddleName0.Text = ""
                                idNumberTxt.Text = ""
                                jointName.Text = ""
                                surnameTxt.Text = ""
                                forenameTxt.Text = ""
                                Page_Load(Me, e)

                                '                            Thread.Sleep(2000)
                                '                            Response.Redirect(HttpContext.Current.Request.Url.ToString(), True)
                                ClearAll()
                            Catch ex As SqlException
                                msgbox(ex.ToString())
                                '                    Logs(ex.ToString())
                            End Try
                        End Using
                    End Using
                Else
                    msgbox("Account already added")
                End If

                '             Session("totalShares") = total

            ElseIf accType0.SelectedIndex = 0 Then

                Dim custody As Integer
                Dim trading As Integer


                If Not String.IsNullOrEmpty(Session("totalShares").ToString()) Then
                    If Integer.TryParse(Session("totalShares").ToString(), trading) Then
                        If Integer.TryParse(Session("totalShares").ToString(), custody) Then
                            Dim tot = trading + custody
                            '                    If Session("totalShares") = tot Then
                            Dim cmnd As SqlCommand
                            cmnd = New SqlCommand("Update [CDS].[dbo].[AccountNewDetails] SET [Custody] = '" & custody & "', [Trading] = '" & trading & "', [Total] = '" & Integer.Parse(Session("totalShares").ToString()) & "', AccountType='" & accType.SelectedValue & "' Where IdNumber='" & ind & "'", cn)
                            If (cn.State = ConnectionState.Open) Then
                                cn.Close()
                            End If
                            Try
                                cn.Open()
                                cmnd.ExecuteNonQuery()
                                cn.Close()

                                lastCreatedCds.Text = cdsNo
                                Session("CreatedNumber") = cdsNo

                                '                            msgbox("Account added succesfully")

                                Session("SavedSuccess1") = "SavedSuccess"
                                Response.Redirect(Request.RawUrl)

                                txtDOB.Text = ""
                                txtMiddleName.Text = ""
                                txtOthernames.Text = ""
                                txtSurname.Text = ""
                                txtMiddleName0.Text = ""
                                idNumberTxt.Text = ""
                                jointName.Text = ""
                                surnameTxt.Text = ""
                                forenameTxt.Text = ""


                                '***SJ 14/08/2014
                                'txtIDNo0.Text = ""
                                'txtIDNo1.Text = ""


                                Page_Load(Me, e)
                                '                        Thread.Sleep(2000)
                                '                        Response.Redirect(HttpContext.Current.Request.Url.ToString(), True)
                            Catch ex As Exception
                                msgbox("Something went wrong, Please try again")
                            End Try
                            '                    Else
                            '                        msgbox("Shares are not balanced")
                            '                    End If
                        Else
                            msgbox("Please enter a valid Trading Shares")
                        End If
                    Else
                        msgbox("Please enter a valid Trading Shares")
                    End If
                Else
                    msgbox("Please save certficates first")
                End If
            End If
        Else
            msgbox("The ID you entered is already used")
        End If
    End Sub


    Protected Sub ClearAll()
        For Each eCtl As Control In Controls
            If TypeOf eCtl Is TextBox Then
                Dim txtControl = DirectCast(eCtl, TextBox)
                txtControl.Text = "I've changed"
            End If
        Next
    End Sub
    Protected Sub accType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles accType.SelectedIndexChanged
        If accType.SelectedIndex = 1 Then
            jointName.Visible = True
            Panel8.Visible = False
            Panel10.Visible = True
            idNumberTxt.Visible = False
            surnameTxt.Visible = False
            forenameTxt.Visible = False
            indSurname.Visible = False
            indForeName.Visible = False
            accNameType.Text = "Enter Joint Name"
        ElseIf accType.SelectedIndex = 0 Then
            Panel8.Visible = False
            Panel10.Visible = False
            Panel10.Visible = True
            jointName.Visible = False
            idNumberTxt.Visible = True
            surnameTxt.Visible = True
            forenameTxt.Visible = True
            indSurname.Visible = True
            indForeName.Visible = True
            accNameType.Text = "Enter ID Number"
        ElseIf accType.SelectedIndex = 2 Then
            Panel8.Visible = True
            Panel10.Visible = False
        End If
    End Sub
    Protected Sub grdApps_SelectedIndexChanged(sender As Object, e As EventArgs) Handles grdApps.SelectedIndexChanged

    End Sub
    Protected Sub accType0_SelectedIndexChanged(sender As Object, e As EventArgs) Handles accType0.SelectedIndexChanged
        If accType0.SelectedIndex = 0 Then
            Panel1.Visible = True
            '            Panel2.Visible = True
        ElseIf accType0.SelectedIndex = 1 Then
            Panel1.Visible = False
            '            Panel2.Visible = False
        End If
    End Sub
End Class
