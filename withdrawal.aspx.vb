Imports DevExpress.ExpressApp
Imports DevExpress.Web.ASPxEditors
Imports DevExpress.Web.ASPxGridView

Partial Class TransferSec_Withdrawal
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

    Public Function getDEPCDS(CDSno As String) As String
        Dim ds As New DataSet
        cmd = New SqlCommand("select Role  FROM [CDS].[dbo].[SystemUsers] where UserName='" + CDSno + "'", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "Accounts_Clients")
        If (ds.Tables(0).Rows.Count > 0) Then
            Return ds.Tables(0).Rows(0).Item("Role").ToString
        Else
            Return ""

        End If
    End Function
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
                msgbox("Batch successfully captured")
            End If
            Page.MaintainScrollPositionOnPostBack = True
            If (Not IsPostBack) Then
                checkSessionState()
                ' getCompany()
                getdetails()
                getpending()

                getApproved()


            End If


        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    'Public Sub getCompany()
    '    Try
    '        Dim ds As New DataSet
    '        cmd = New SqlCommand("Select company from para_company", cn)
    '        adp = New SqlDataAdapter(cmd)
    '        adp.Fill(ds, "para_company")
    '        cmbparaCompany.DataSource = ds.Tables(0)
    '        cmbparaCompany.TextField = "company"
    '        cmbparaCompany.ValueField = "company"
    '        cmbparaCompany.DataBind()
    '    Catch ex As Exception
    '        msgbox(ex.Message)
    '    End Try
    'End Sub


    Public Function getholder(wr As String) As String
        Dim ds As New DataSet
        cmd = New SqlCommand("select holder from wr where receiptno='" + wr + "'", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "names")
        If (ds.Tables(0).Rows.Count > 0) Then
            Return ds.Tables(0).Rows(0).Item("holder").ToString
        Else
            Return ""
        End If
    End Function

    Public Function getemail(cdsnumber As String) As String
        Dim ds As New DataSet
        cmd = New SqlCommand("select email from accounts_clients where cds_Number='" + cdsnumber + "'", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "names")
        If (ds.Tables(0).Rows.Count > 0) Then
            Return ds.Tables(0).Rows(0).Item("email").ToString
        Else
            Return ""
        End If
    End Function

    Protected Sub ASPxButton13_Click(sender As Object, e As EventArgs) Handles ASPxButton13.Click
        Try
            Dim av As Double = txtavailableshares.Text
            Dim totrans As Double = txtshares.Text




            If av < totrans Then
                msgbox("Please enter units less or equal to available units!")
                Exit Sub

            Else


                Dim bal As Decimal = av - pendingbalance(cmbparaCompany.SelectedItem.Value.ToString)
                If bal < totrans Then
                    msgbox("Account has a Pending Transaction of " + pendingbalance(cmbparaCompany.SelectedItem.Value.ToString).ToString + " Units.")
                    Exit Sub
                End If

                msgbox("Batch successfully captured")
                    Dim xyz As New Common
                    If xyz.OTPenabled = True Then


                        Dim OTP As String = CreateOTP(4)
                        Dim z As New sendmail
                        Try
                            z.sendmail(getemail(getDEPCDS(Session("Username"))).ToString, "Withdrawal Authorization Request", "A Withdrawal on EWR No. " + cmbparaCompany.SelectedItem.Value.ToString + " has been initiated in your account. Please authorize using OTP: " + OTP + "")
                        Catch ex As Exception
                            msgbox("Error Sending Email:" + ex.Message + "")
                        End Try

                    cmd = New SqlCommand("insert into withdrawals (OTP,OTPSent,amount_to_withdraw,EWR_holder, [date], [status], query, company, ReceiptID, CapturedBy, CaptureDate, ParticipantCode) values ('" + OTP + "','1','" + txtshares.Text + "','" + txtewraccountno.Text + "',getdate(),'C','0','" + cmbparaCompany.Text + "','" + cmbparaCompany.SelectedItem.Value.ToString + "','" + Session("Username") + "',getdate(),'" + getoperator(getDEPCDS(Session("Username"))) + "')", cn)
                    If (cn.State = ConnectionState.Open) Then
                            cn.Close()
                        End If
                        cn.Open()
                        cmd.ExecuteNonQuery()


                    Else


                    cmd = New SqlCommand("insert into withdrawals (amount_to_withdraw,EWR_holder, [date], [status], query, company, ReceiptID, CapturedBy, CaptureDate, ParticipantCode) values ('" + txtshares.Text + "','" + txtewraccountno.Text + "',getdate(),'C','0','" + cmbparaCompany.Text + "','" + cmbparaCompany.SelectedItem.Value.ToString + "','" + Session("Username") + "',getdate(),'" + getoperator(getDEPCDS(Session("Username"))) + "')", cn)
                    If (cn.State = ConnectionState.Open) Then
                            cn.Close()
                        End If
                        cn.Open()
                        cmd.ExecuteNonQuery()

                    End If
                End If
            cn.Close()
            getpending()

            getApproved()
            'Session("finish") = "yes"
            'Response.Redirect(Request.RawUrl)


        Catch ex As Exception
            msgbox("Please select the relevant Account to Transfer from and Transfer to! Units to transfer should also be numeric")
        End Try

    End Sub

    Public Function getoperator(cdsnumber As String) As String
        Dim ds As New DataSet
        cmd = New SqlCommand("select BrokerCode from accounts_clients where cds_number='" + cdsnumber + "'", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "Accounts_Clients")
        If (ds.Tables(0).Rows.Count > 0) Then
            Return ds.Tables(0).Rows(0).Item("BrokerCode").ToString
        Else
            Return ""
        End If

    End Function


    'Protected Sub ASPxGridView3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ASPxGridView3.SelectedIndexChanged

    '    ViewState("trnsid") = ASPxGridView3.SelectedRow.Cells(1).Text
    '    ViewState("idReject") = ""



    '    otptable.Visible = True
    '    otptable2.Visible = True

    'End Sub

    Public Function checkotp(otp As String) As Boolean
        Dim ds As New DataSet

        cmd = New SqlCommand("select *  FROM [CDS].[dbo].[withdrawals] where isnull(OTP,'')='" + otp.Trim + "'  and id in ('" + ViewState("trnsid") + "')", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "otp")
        If (ds.Tables(0).Rows.Count > 0) Then
            Return False
        Else


            Return True

        End If
    End Function

    Protected Sub btnotp_Click(sender As Object, e As EventArgs) Handles btnotp.Click
        Try



            ' Dim m As String = getDEPCDS(Session("Username"))






            If txtotp.Text = "" Then
                    msgbox("Please enter otp")
                    Exit Sub
                End If

                If checkotp(txtotp.Text.ToLower.ToString.Trim) Then
                    msgbox("OTP incorrect please try again")
                    Exit Sub
                End If

                cmd = New SqlCommand("update [CDS].[dbo].[withdrawals] set OTPStatus ='APPROVED' where id ='" + ViewState("trnsid") + "'", cn)
                If (cn.State = ConnectionState.Open) Then
                    cn.Close()
                End If
                cn.Open()
                If cmd.ExecuteNonQuery() = 1 Then
                    msgbox("Transaction Successfully Authorized Waiting For Authorization")

                    txtotp.Text = ""
                End If



            cn.Close()

            getpending()


            getApproved()
        Catch ex As Exception
            msgbox("Please make sure you entered all values")
        End Try

    End Sub


    Public Sub getpending()

        Dim ds As New DataSet
        cmd = New SqlCommand("select s.ID [S.No], s.id,EWR_Holder as [Account No], Commodity ,Grade , ReceiptID,amount_to_withdraw , 'Pending'   [Status],  CONVERT(VARCHAR(10),Date,6) as [Trns. Date] from withdrawals s , wr w  where w.ReceiptNo=s.ReceiptID and EWR_holder='" + getDEPCDS(Session("Username")) + "' and isnull(OTPStatus,'') <> 'REJECTED' and  isnull(S.ApprovedBy,'') = '' ", cn)
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
    Public Shared Function CreateOTP(ByVal PasswordLength As Integer) As String
        Dim _allowedChars As String = "0123456789"
        Dim randomNumber As New Random()
        Dim chars(PasswordLength - 1) As Char
        Dim allowedCharCount As Integer = _allowedChars.Length
        For i As Integer = 0 To PasswordLength - 1
            chars(i) = _allowedChars.Chars(CInt(Fix((_allowedChars.Length) * randomNumber.NextDouble())))
        Next i
        Return New String(chars)
    End Function

    Protected Sub btn_accept(ByVal sender As Object, ByVal e As EventArgs)
        Dim btn As ASPxButton = CType(sender, ASPxButton)
        Dim container As GridViewDataItemTemplateContainer = CType(btn.NamingContainer, GridViewDataItemTemplateContainer)

        ViewState("trnsid") = container.KeyValue.ToString()

        otptable.Visible = True
        otptable2.Visible = True
    End Sub
    Protected Sub btn_reject(ByVal sender As Object, ByVal e As EventArgs)
        Dim btn As ASPxButton = CType(sender, ASPxButton)
        Dim container As GridViewDataItemTemplateContainer = CType(btn.NamingContainer, GridViewDataItemTemplateContainer)
        ViewState("idReject") = container.KeyValue.ToString()

        If ViewState("idReject") <> "" Then

            cmd = New SqlCommand("update [CDS].[dbo].[withdrawals] set OTPStatus ='REJECTED' where id='" + ViewState("idReject") + "'", cn)
            If (cn.State = ConnectionState.Open) Then
                cn.Close()
            End If
            cn.Open()
            If cmd.ExecuteNonQuery() = 1 Then
                msgbox("Rejected Successfull ")

            End If
        End If
        getpending()

        getApproved()
        otptable.Visible = False
        otptable2.Visible = False

    End Sub

    Public Sub getApproved()

        Dim ds As New DataSet
        cmd = New SqlCommand("select s.ID [S.No], s.id,EWR_Holder as [Account No], Commodity ,Grade , ReceiptID,amount_to_withdraw , 'Approved'   [Status],  CONVERT(VARCHAR(10),Date,6) as [Trns. Date] from withdrawals s , wr w  where w.ReceiptNo=s.ReceiptID and EWR_holder='" + getDEPCDS(Session("Username")) + "' and   isnull(OTPStatus,'') = 'APPROVED'  and   isnull(s.ApprovedBy,'')<>''", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "names")
        If (ds.Tables(0).Rows.Count > 0) Then
            ASPxGridView1.DataSource = ds
            ASPxGridView1.DataBind()



        Else
            ASPxGridView1.DataSource = Nothing
            ASPxGridView1.DataBind()
        End If
    End Sub
    Public Function pendingbalance(receipt As String) As Double
        Dim ds As New DataSet
        cmd = New SqlCommand("select isnull(sum(amount_to_withdraw),0) as [pending] from withdrawals where ReceiptID='" + receipt + "' and rejected is NULL AND APPROVEDBY is NULL", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "names")
        If (ds.Tables(0).Rows.Count > 0) Then
            Return ds.Tables(0).Rows(0).Item("pending").ToString
        Else
            Return 0
        End If
    End Function



    Protected Sub ASPxButton4_Click(sender As Object, e As EventArgs) Handles ASPxButton4.Click
        If txtclientnumber0.Text = "" Then
            msgbox("Please enter Account No./Name to search")
            Exit Sub
        End If

        Dim ds As New DataSet
        cmd = New SqlCommand("select cds_number+' '+isnull(surname,'')+' '+isnull(middlename,'')+' '+isnull(forenames,'') as names, cds_number from accounts_clients where cds_number+' '+isnull(surname,'')+' '+isnull(middlename,'')+' '+isnull(forenames,'') like '%" + txtclientnumber0.Text + "%' and brokercode='" + Session("BrokerCode") + "'", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "names")
        If (ds.Tables(0).Rows.Count > 0) Then
            ListBox1.DataSource = ds
            ListBox1.DataTextField = "names"
            ListBox1.DataValueField = "cds_number"
            ListBox1.DataBind()

        End If
    End Sub

    Protected Sub cmbparaCompany_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbparaCompany.SelectedIndexChanged
        Dim dsport As New DataSet
        cmd = New SqlCommand("select isnull(sum(shares),0) as available from trans where reference='" + cmbparaCompany.SelectedItem.Value.ToString + "' and cds_Number='" + txtewraccountno.Text + "'", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(dsport, "trans")
        If (dsport.Tables(0).Rows.Count > 0) Then
            txtavailableshares.Text = dsport.Tables("trans").Rows(0).Item("available")
            txtshares.Text = txtavailableshares.Text
        Else
            txtavailableshares.Text = 0

        End If
    End Sub



    'Protected Sub ASPxGridView3_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles ASPxGridView3.RowDataBound
    '    If e.Row.RowType = DataControlRowType.DataRow Then

    '        Dim id = DirectCast(e.Row.FindControl("id"), Label).Text




    '        Dim btnView As ImageButton = CType(e.Row.FindControl("LinkButton2"), ImageButton)




    '        e.Row.Enabled = getvalue(id)


    '    End If
    ' End Sub


    Public Function getvalue(id As String) As Boolean
        Dim ds As New DataSet
        cmd = New SqlCommand("select * from [CDS].[dbo].[withdrawals] where  id ='" + id + "' and isnull(OTPStatus,'') not in ('REJECTED' ,'APPROVED') ", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "aft")
        If (ds.Tables(0).Rows.Count > 0) Then
            Return True
        Else
            Return False

        End If
    End Function

    'Protected Sub ASPxGridView3_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles ASPxGridView3.RowCommand



    '    ViewState("idReject") = e.CommandArgument






    '    otptable.Visible = True
    '    otptable2.Visible = True







    'End Sub




    Protected Sub getdetails()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select forenames+' '+surname as [Name], c.company_code, c.Company_name  from Accounts_Clients a, Client_Companies c where a.BrokerCode=c.Company_Code and a.cds_number='" + getDEPCDS(Session("Username")) + "'", cn)
            ''Commodity+'/'+Grade as [Prod] from WR where holder='" + ListBox1.SelectedItem.Value.ToString + "' and quantity>0 AND ([status]='ISSUED' OR [status]='SPLIT')", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "names1")
            If (ds.Tables(0).Rows.Count > 0) Then
                txtparticipantname.Text = ds.Tables(0).Rows(0).Item("Company_name")
                txtAccountNo.Text = ds.Tables(0).Rows(0).Item("Company_Code")
                txtewrholder.Text = ds.Tables(0).Rows(0).Item("name")
                txtewraccountno.Text = getDEPCDS(Session("Username"))
                loadcomboforreceipts(getDEPCDS(Session("Username")))
            End If

        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged
        Dim ds As New DataSet
        cmd = New SqlCommand("select forenames+' '+surname as [Name], c.company_code, c.Company_name  from Accounts_Clients a, Client_Companies c where a.BrokerCode=c.Company_Code and a.cds_number='" + ListBox1.SelectedValue.ToString + "'", cn)
        ''Commodity+'/'+Grade as [Prod] from WR where holder='" + ListBox1.SelectedItem.Value.ToString + "' and quantity>0 AND ([status]='ISSUED' OR [status]='SPLIT')", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "names1")
        If (ds.Tables(0).Rows.Count > 0) Then
            txtparticipantname.Text = ds.Tables(0).Rows(0).Item("Company_name")
            txtAccountNo.Text = ds.Tables(0).Rows(0).Item("Company_Code")
            txtewrholder.Text = ds.Tables(0).Rows(0).Item("name")
            txtewraccountno.Text = ListBox1.SelectedValue.ToString
            loadcomboforreceipts(ListBox1.SelectedValue.ToString)
        End If
    End Sub
    Public Sub loadcomboforreceipts(holder As String)
        Dim dsport As New DataSet
        cmd = New SqlCommand("select ReceiptNo, ReceiptNo+' '+ convert(nvarchar(50),Quantity) +' '+ UnitMeasure  +' '+Commodity+'/'+Grade AS [Name]  from WR where holder='" + holder + "' and [Status]='ISSUED'", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(dsport, "trans")
        If (dsport.Tables(0).Rows.Count > 0) Then
            cmbparaCompany.DataSource = dsport
            cmbparaCompany.TextField = "Name"
            cmbparaCompany.ValueField = "ReceiptNo"
            cmbparaCompany.DataBind()
        End If
    End Sub

End Class
