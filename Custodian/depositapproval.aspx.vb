Imports DevExpress.Web.ASPxGridView

Partial Class Custodian_depositApproval

    Inherits System.Web.UI.Page
    Dim constr As String = (System.Configuration.ConfigurationManager.AppSettings("connpath"))
    Dim cn As New SqlConnection(constr)
    Dim adp As SqlDataAdapter
    Dim cmd As SqlCommand
    Public Sub msgbox(ByVal strMessage As String)
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
            If Session("finish") = "yes" Then
                Session("finish") = ""
                msgbox(Session("msg"))
                Session("msg") = ""
            End If
            If Session("finish") = "rejected" Then
                Session("finish") = ""
                msgbox(Session("msg"))
                Session("msg") = ""
            End If
            If Session("finish") = "otp" Then
                Session("finish") = ""
                msgbox("OTP has been resent!")
            End If
            Page.MaintainScrollPositionOnPostBack = True
            If (Not IsPostBack) Then
                checkSessionState()
                loadreceiptdetails()

                getpending()

                getrejected()

            Else

            End If
            getrejected()
            getpending()

            loadreceiptdetails()

        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Function isOTPsent(ref As String) As Boolean

        Dim ds1 As New DataSet
        cmd = New SqlCommand("select * from Deposit_Cert where id='" + ref + "'", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds1, "account_transfer")
        If (ds1.Tables(0).Rows.Count > 0) Then
            Return False
        Else
            Return True
        End If
    End Function

    Public Sub pd(id As String, transtype As String)
        Dim strQuery As String = "select [filename] as nm, [data],Extension from Transaction_Documents where transactionref='" + id + "' and TransactionType='" + transtype + "'"
        Dim cmd As SqlCommand = New SqlCommand(strQuery)
        cmd.Parameters.Add("@id", SqlDbType.Int).Value = 4
        Dim dt As DataTable = GetData(cmd)
        If dt IsNot Nothing Then
            download(dt)
        End If
    End Sub
    Public Sub word(id As String, transtype As String)
        Dim strQuery As String = "select [filename] as nm, [data],Extension from Transaction_Documents where transactionref='" + id + "' and TransactionType='" + transtype + "'"
        Dim cmd As SqlCommand = New SqlCommand(strQuery)
        cmd.Parameters.Add("@id", SqlDbType.Int).Value = 1
        Dim dt As DataTable = GetData(cmd)
        If dt IsNot Nothing Then
            download(dt)
        End If
    End Sub
    Public Sub xls(id As String, transtype As String)
        Dim strQuery As String = "select [filename] as nm, [data],Extension from Transaction_Documents where transactionref='" + id + "' and TransactionType='" + transtype + "'"
        Dim cmd As SqlCommand = New SqlCommand(strQuery)
        cmd.Parameters.Add("@id", SqlDbType.Int).Value = 2
        Dim dt As DataTable = GetData(cmd)
        If dt IsNot Nothing Then
            download(dt)
        End If
    End Sub
    Public Sub Img(id As String, transtype As String)
        Dim strQuery As String = "select [filename] as nm, [data],Extension from Transaction_Documents where transactionref='" + id + "' and TransactionType='" + transtype + "'"
        Dim cmd As SqlCommand = New SqlCommand(strQuery)
        cmd.Parameters.Add("@id", SqlDbType.Int).Value = 3
        Dim dt As DataTable = GetData(cmd)
        If dt IsNot Nothing Then
            download(dt)
        End If
    End Sub
    Public Function apptype(type As String) As String
        If type = ".png" Then
            Return "Aplication/vnd.png"
        ElseIf type = ".doc" Or type = ".docx" Then
            Return "Aplication/vnd.ms-word"
        ElseIf type = ".xlsx" Or type = ".xls" Then
            Return "Aplication/vnd.ms-excel"
        ElseIf type = ".jpg" Or type = ".jpeg" Then
            Return "Aplication/vnd.jpg"
        ElseIf type = ".gif" Then
            Return "Aplication/vnd.gif"
        End If
    End Function
    Protected Sub download(ByVal dt As DataTable)
        Dim bytes() As Byte = CType(dt.Rows(0)("Data"), Byte())
        Response.Buffer = True
        Response.Charset = ""
        Response.Cache.SetCacheability(HttpCacheability.NoCache)
        Response.ContentType = apptype(dt.Rows(0)("Extension").ToString())
        Response.AddHeader("content-disposition", "attachment;filename=" + dt.Rows(0)("nm").ToString() + "")
        Response.BinaryWrite(bytes)
        Response.Flush()
        Response.End()
    End Sub
    Public Sub getdocuments(ref As String, transtyp As String)
        Dim dsport As New DataSet
        cmd = New SqlCommand("select * from Transaction_Documents where transactionref='" + ref + "' and TransactionType='" + transtyp + "'", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(dsport, "trans")
        If (dsport.Tables(0).Rows.Count > 0) Then
            ASPxGridView1.DataSource = dsport
            ASPxGridView1.DataBind()
        Else
            ASPxGridView1.DataSource = Nothing
            ASPxGridView1.DataBind()
        End If
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



    Protected Sub ASPxButton13_Click(sender As Object, e As EventArgs) Handles ASPxButton13.Click
        Try


            If txttrantype.Text = "DEPOSIT" Then
                Dim OTP As String = CreateRandomPassword(4)
                cmd = New SqlCommand(" update Deposit_Cert set Approvedby='" + Session("Username") + "', status='Approved', approveddate=getdate(), OTP='',OTPSent='1' ,OTPCreateTime=getdate() where id='" + txtid.Text + "'", cn)
                If (cn.State = ConnectionState.Open) Then
                    cn.Close()
                End If
                cn.Open()
                cmd.ExecuteNonQuery()
                cn.Close()
            ElseIf txttrantype.Text = "WITHDRAWAL" Then
                Dim OTP As String = CreateRandomPassword(4)
                cmd = New SqlCommand("update Deposit_Cert set Approvedby='" + Session("Username") + "', status='Approved', approveddate=getdate(), OTP='',OTPSent='1' ,OTPCreateTime=getdate() where id='" + txtid.Text + "'", cn)
                If (cn.State = ConnectionState.Open) Then
                    cn.Close()
                End If
                cn.Open()
                cmd.ExecuteNonQuery()
                cn.Close()
            End If



            Session("finish") = "yes"
            Session("msg") = "Deposit request for Certificate No. " + txtcertificateno.Text + " has been successfully authorized. Transaction ID is " + txtid.Text + ""
            Try
                Dim em As New sendmail
                em.sendmail(getemail(txtewraccountno.Text), "Successful Deposit", Session("msg"))
            Catch ex As Exception
                msgbox("Error Sending email!")
            End Try

            Try
                Dim a As New passmanagement
                a.auditlog(Session("BrokerCode"), Session("Username"), "Approved a Certificate Deposit", txtAccountNo.Text, "")
            Catch ex As Exception

            End Try


            Response.Redirect(Request.RawUrl)
        Catch ex As Exception
            msgbox(ex.Message)
        End Try

    End Sub
    Public Function getemail(accountno As String) As String
        Dim ds As New DataSet
        cmd = New SqlCommand("select email from accounts_clients where cds_number='" + accountno + "'", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "names")
        If (ds.Tables(0).Rows.Count > 0) Then
            Return ds.Tables(0).Rows(0).Item("email").ToString

        End If
    End Function


    Public Function accountbalance(accountno As String) As Decimal
        Dim ds As New DataSet
        cmd = New SqlCommand("select isnull(sum(amount),0) as [totalowing] from cashtransComb where cds_Number='" + accountno + "'", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "names")
        If (ds.Tables(0).Rows.Count > 0) Then
            Return ds.Tables(0).Rows(0).Item("totalowing").ToString
        Else
            Return 0
        End If
    End Function
    Public Sub getpending()

        Dim ds As New DataSet
        cmd = New SqlCommand("select a.Surname+' '+a.forenames as Names,w.id, Price*quantity as value,charge,CaptureDate,Charge,Price, MaturityDate, IssueDate,  w.id,case when w.OTPStatus IS NULL and w.ApprovedBy is NULL THEN 'N/A' else 'N/A' end as [otp] , W.Holder as [Account No], W.Company as [Details], W.Certificate_No AS [Certificate No], case when W.approvedby is NULL and w.rejected is NULL then 'Pending' when w.rejected='1' then 'Rejected' else 'Approved' end as  [Status],  W.[Date], FORMAT(W.quantity,'#,###.##','en-us') AS  quantity ,w.Company   from Deposit_cert W, Accounts_clients a where deleted is NULL AND w.holder=a.cds_number and rejected is NULL", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "names")
        If (ds.Tables(0).Rows.Count > 0) Then
            ASPxGridView3.DataSource = ds
            ASPxGridView3.DataBind()
        Else
            ASPxGridView3.DataSource = Nothing
            ASPxGridView3.DataBind()
        End If
    End Sub
    Public Sub getrejected()

        Dim ds As New DataSet
        cmd = New SqlCommand("select a.Surname+' '+a.forenames as Names,Price*quantity as value,charge,CaptureDate,Charge,Price, MaturityDate, IssueDate,  w.id,case when w.OTPStatus IS NULL and w.ApprovedBy is NULL THEN 'N/A' else 'N/A' end as [otp] , W.Holder as [Account No], W.Company as [Details], W.Certificate_No AS [Certificate No], case when W.approvedby is NULL and w.rejected is NULL then 'Pending' when w.rejected='1' then 'Rejected' else 'Approved' end as  [Status],  W.[Date], FORMAT(W.quantity,'#,###.##','en-us') AS  quantity ,w.Company   from Deposit_cert W, Accounts_Clients a where w.Holder=a.cds_number and deleted is NULL AND rejected is not NULL", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "names")
        If (ds.Tables(0).Rows.Count > 0) Then
            ASPxGridView4.DataSource = ds
            ASPxGridView4.DataBind()
        Else
            ASPxGridView4.DataSource = Nothing
            ASPxGridView4.DataBind()
        End If
    End Sub
    Public Sub loaddetails(holder As String)

        Dim ds As New DataSet
        cmd = New SqlCommand("select forenames+' '+surname as [Name], c.company_code, c.Company_name, a.cds_Number  from Accounts_Clients a, Client_Companies c where a.BrokerCode=c.Company_Code and a.cds_number='" + holder + "'", cn)
        ''Commodity+'/'+Grade as [Prod] from WR where holder='" + ListBox1.SelectedItem.Value.ToString + "' and quantity>0 AND ([status]='ISSUED' OR [status]='SPLIT')", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "names1")
        If (ds.Tables(0).Rows.Count > 0) Then
            '   txtparticipantname.Text = ds.Tables(0).Rows(0).Item("Company_name")
            '  txtAccountNo.Text = ds.Tables(0).Rows(0).Item("Company_Code")
            txtewrholder.Text = ds.Tables(0).Rows(0).Item("name")
            txtewraccountno.Text = ds.Tables(0).Rows(0).Item("cds_number")
            txtAccountNo.Text = Session("BrokerCode")
            txtparticipantname.Text = partname(Session("BrokerCode"))
        End If
    End Sub
    Public Function partname(code As String) As String
        Dim dsport As New DataSet
        cmd = New SqlCommand("select Company_name from client_companies where Company_Code='" + code + "'", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(dsport, "trans")
        If (dsport.Tables(0).Rows.Count > 0) Then
            Return dsport.Tables(0).Rows(0).Item("company_name")
        End If
    End Function
    Public Sub loadcomboforreceipts(holder As String)
        Dim dsport As New DataSet
        cmd = New SqlCommand("select * from WR where holder='" + holder + "' and [Status]='ISSUED' and quantity>0 and status='ISSUED'", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(dsport, "trans")
        If (dsport.Tables(0).Rows.Count > 0) Then

        End If
    End Sub
    Public Sub loadreceiptdetails()
        Dim xyz As New Common
        Dim dsport As New DataSet
        If xyz.OTPenabled = True Then
            cmd = New SqlCommand("select *,FORMAT(QUANTITY,'#,###.##','en-us') AS Quant,FORMAT(QUANTITY*price,'#,###.##','en-us') as value, a.Surname+' '+a.forenames as Names from Deposit_Cert d, Accounts_clients a where a.cds_number=d.holder and rejected is NULL and approvedby is NULL and deleted is NULL", cn)
        Else
            cmd = New SqlCommand("select *,FORMAT(QUANTITY,'#,###.##','en-us') AS Quant,FORMAT(QUANTITY*price,'#,###.##','en-us') as value, a.Surname+' '+a.forenames as Names from Deposit_Cert d, Accounts_clients a where  a.cds_number=d.holder and rejected is NULL and approvedby is NULL and deleted is NULL", cn)
        End If


        adp = New SqlDataAdapter(cmd)
        adp.Fill(dsport, "trans")
        If (dsport.Tables(0).Rows.Count > 0) Then
            ASPxGridView5.DataSource = dsport
            ASPxGridView5.DataBind()

        End If
    End Sub





    Private Sub ASPxGridView5_RowCommand(sender As Object, e As ASPxGridViewRowCommandEventArgs) Handles ASPxGridView5.RowCommand
        Dim id As String = e.KeyValue.ToString

        If e.CommandArgs.CommandName.ToString = "Select" Then
            getinfortoedit(id.ToString)
            Try
                ' Dim m As New NaymatBilling
                ' Dim charge As Double = m.withdrawalcharges("ENQUIRE", "DEPOSITOR", txtshares.Text, txtewraccountno.Text.ToString, cmbparaCompany.Text)
                ' txtassetmanager.Text = "0"


                Dim m As New NaymatBilling
                Dim transcharge As Double = "0"

                'Dim charge As Double = m.getEWRBAL(cmbparaCompany.Value.ToString, txtewraccountno.Text)
                Dim globcharge As Double = m.getholderbal(txtewraccountno.Text, Session("BrokerCode"))
                '  txtcounterpartbank.Text = "0"
                ' txtothercharges.Text = globcharge.ToString("N")
                '  txtassetmanager.Text = "0"
            Catch ex As Exception
                msgbox("Error Charging: " + ex.Message)
            End Try

        End If
    End Sub
    Public Sub getinfortoedit(receipt As String)
        cmd = New SqlCommand("select *,QUANTITY*price as value from Deposit_Cert  where id='" + receipt + "'", cn)
        Dim ds As New DataSet
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "pc")
        If ds.Tables(0).Rows.Count > 0 Then
            txtewrholder.Text = ds.Tables(0).Rows(0).Item("holder").ToString
            loaddetails(txtewrholder.Text)

            txtavailableshares.Text = ds.Tables(0).Rows(0).Item("quantity").ToString
            txtissueddate.Text = ds.Tables(0).Rows(0).Item("issuedate").ToString
            txtmaturitydate.Text = ds.Tables(0).Rows(0).Item("maturitydate").ToString
            txtitem.Text = ds.Tables(0).Rows(0).Item("company").ToString
            txtprice.Text = ds.Tables(0).Rows(0).Item("price").ToString
            txtcapturedate.Text = ds.Tables(0).Rows(0).Item("capturedate").ToString
            txtcapturedby.Text = ds.Tables(0).Rows(0).Item("capturedBy").ToString
            txtvalue.Text = ds.Tables(0).Rows(0).Item("value").ToString
            txttrantype.Text = ds.Tables(0).Rows(0).Item("deptype").ToString
            txtcertificateno.Text = ds.Tables(0).Rows(0).Item("certificate_no").ToString
            txtcounterpartbank.Text = ds.Tables(0).Rows(0).Item("CounterpartBank").ToString
            txtcounterpartaccount.Text = ds.Tables(0).Rows(0).Item("CounterpartAccount").ToString
            txtassetmanager.Text = ds.Tables(0).Rows(0).Item("AssetManager").ToString
            txtid.Text = ds.Tables(0).Rows(0).Item("id").ToString

            txtproducttype.Text = ds.Tables(0).Rows(0).Item("Product").ToString
            If txtproducttype.Text = "Certificate" Then
                lblcertificate.Text = "Certificate No."
                lblcompany.Text = "Company"
                lblissuedate.Text = "Issue Date"
                lblmaturity.Text = "Maturity Date"
                lblprice.Text = "Price Per Unit"
            Else
                lblcertificate.Text = "Serial No."
                lblcompany.Text = "Product"
                lblissuedate.Text = "Registration Date"
                lblmaturity.Text = "Expiry Date"
                lblprice.Text = "Unit Value"
            End If
            getdocuments(receipt.ToString, "Vault")
        End If
    End Sub
    Private Sub ASPxGridView1_RowCommand(sender As Object, e As ASPxGridViewRowCommandEventArgs) Handles ASPxGridView1.RowCommand
        Dim id As String = e.KeyValue.ToString
        If e.CommandArgs.CommandName.ToString = "View Document" Then

            Try
                pd(txtid.Text, "Vault")
            Catch ex As Exception
            End Try
            Try
                word(txtid.Text, "Vault")
            Catch ex As Exception
            End Try
            Try
                xls(txtid.Text, "Vault")
            Catch ex As Exception
            End Try
            Try
                Img(txtid.Text, "Vault")
            Catch ex As Exception
            End Try
        ElseIf e.CommandArgs.CommandName.ToString = "Remove Document" Then
            msgbox("Not Allowed!")
        End If
    End Sub

    Protected Sub ASPxButton14_Click(sender As Object, e As EventArgs) Handles ASPxButton14.Click
        If txtrejectreason.Visible = False Then
            txtrejectreason.Visible = True
            msgbox("Please enter reject reason and press reject!")
        Else
            If txtrejectreason.Text <> "" Then
                Try

                    Try
                        Dim m As New NaymatBilling
                        Dim charge As Double = "0"

                    Catch ex As Exception
                        msgbox("Error Charging: " + ex.Message)
                    End Try


                    cmd = New SqlCommand(" update Deposit_Cert set rejected='1', approveddate=getdate(), rejectionreason='" + txtrejectreason.Text + "' where id='" + txtid.Text + "'", cn)
                    If (cn.State = ConnectionState.Open) Then
                        cn.Close()
                    End If
                    cn.Open()
                    cmd.ExecuteNonQuery()
                    cn.Close()

                    Try
                        Dim a As New passmanagement
                        a.auditlog(Session("BrokerCode"), Session("Username"), "Rejected a withdrawal Request", txtAccountNo.Text, "")
                    Catch ex As Exception

                    End Try

                    Session("finish") = "rejected"

                    Session("msg") = "Vault has been rejected successfully. "
                    Response.Redirect(Request.RawUrl)
                Catch ex As Exception
                    msgbox(ex.Message)
                End Try
            Else
                msgbox("Please enter rejection reason!")
            End If
        End If
    End Sub
    Protected Sub txtcapturedby_TextChanged(sender As Object, e As EventArgs) Handles txtcapturedby.TextChanged

    End Sub

    Private Sub ASPxGridView3_RowCommand(sender As Object, e As ASPxGridViewRowCommandEventArgs) Handles ASPxGridView3.RowCommand
        Dim id As String = e.KeyValue.ToString

        If e.CommandArgs.CommandName.ToString = "Resend" Then
            If isOTPsent(id) = True Then

                msgbox("Transaction status does not allow OTP to be resent!")
            Else
                Dim OTP As String = CreateRandomPassword(4)
                cmd = New SqlCommand(" update Deposit_Cert set  OTP='" + OTP + "',OTPSent='1' ,OTPCreateTime=getdate() where id='" + id.ToString + "'", cn)
                If (cn.State = ConnectionState.Open) Then
                    cn.Close()
                End If
                cn.Open()
                cmd.ExecuteNonQuery()
                cn.Close()



                Session("finish") = "otp"
                Response.Redirect(Request.RawUrl)
            End If



        End If

    End Sub

    Protected Sub ASPxButton15_Click(sender As Object, e As EventArgs) Handles ASPxButton15.Click
        Dim id As String = txtid.Text
        Try
            pd(id, "Deposit")
        Catch ex As Exception
        End Try
        Try
            word(id, "Deposit")
        Catch ex As Exception
        End Try
        Try
            xls(id, "Deposit")
        Catch ex As Exception
        End Try
        Try
            Img(id, "Deposit")
        Catch ex As Exception
        End Try
    End Sub
End Class
