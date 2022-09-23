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
                ' msgbox(" You have successfully Submitted " + cmbparaCompany.SelectedItem.Value.ToString + " for Withdrawal")
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



    Public Function getparticipant(ewr As String) As String
        Dim ds As New DataSet
        cmd = New SqlCommand("select warehouse from wr where ReceiptNo='" + ewr + "'", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "wr")
        If (ds.Tables(0).Rows.Count > 0) Then
            Return ds.Tables(0).Rows(0).Item("warehouse").ToString
        Else
            Return ""
        End If
    End Function

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




    Public Sub getpending()

        Dim ds As New DataSet
        cmd = New SqlCommand("SELECT * FROM [CUSTODIAL].[dbo].[Account_Balances] ", cn)
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

    'Protected Sub ASPxCheckBox1_CheckedChanged1(ByVal sender As Object, ByVal e As EventArgs)

    '    Dim cbChkBox As ASPxCheckBox = TryCast(sender, ASPxCheckBox)
    '    If cbChkBox.Checked = True Then


    '        Dim container As GridViewDataItemTemplateContainer = TryCast(cbChkBox.NamingContainer, GridViewDataItemTemplateContainer)

    '        ViewState("trnsid") = container.KeyValue.ToString()

    '    End If
    '    End If
    '    cbChkBox.Checked = False
    'End Sub






    Public Sub getApproved()

        Dim ds As New DataSet
        cmd = New SqlCommand("select s.ID [S.No], s.id,EWR_Holder as [Account No], Commodity ,Grade , ReceiptID,FORMAT(amount_to_withdraw,'#,0.00') as [amount_to_withdraw] , 'Approved'   [Status],  CONVERT(VARCHAR(10),Date,6) as [Trns. Date] from withdrawals s , wr w  where w.ReceiptNo=s.ReceiptID and EWR_holder='" + getDEPCDS(Session("Username")) + "' and   isnull(OTPStatus,'') = 'APPROVED'  and   isnull(s.ApprovedBy,'')<>''", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "names")
        If (ds.Tables(0).Rows.Count > 0) Then
            '    ASPxGridView1.DataSource = ds
            '    ASPxGridView1.DataBind()



            'Else
            '    ASPxGridView1.DataSource = Nothing
            '    ASPxGridView1.DataBind()
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


    Private Sub ASPxGridView3_RowCommand(sender As Object, e As ASPxGridViewRowCommandEventArgs) Handles ASPxGridView3.RowCommand

        ViewState("trnsid") = e.KeyValue.ToString
        If e.CommandArgs.CommandName.ToString = "OTP" Then


            Dim ds As New DataSet
            cmd = New SqlCommand("select top 1 * from [withdrawals] where  EWR_holder='" + getDEPCDS(Session("Username")) + "' and isnull(OTPStatus,'') <> '' and isnull(ApprovedBy,'') = ''    and isnull(ApprovedDate,'') = ''     and id = '" + ViewState("trnsid") + "' ", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "names")



            If (ds.Tables(0).Rows.Count > 0) Then


                msgbox("The transaction is on pending for approval")
                'ASPxPopupControl1.AllowDragging = False
                'ASPxPopupControl1.ShowCloseButton = False
                'ASPxPopupControl1.ShowOnPageLoad = False
                'Page.MaintainScrollPositionOnPostBack = False



            Else




                'ASPxPopupControl1.PopupHorizontalAlign = DevExpress.Web.ASPxClasses.PopupHorizontalAlign.WindowCenter
                'ASPxPopupControl1.PopupVerticalAlign = DevExpress.Web.ASPxClasses.PopupVerticalAlign.WindowCenter

                'ASPxPopupControl1.AllowDragging = True
                'ASPxPopupControl1.ShowCloseButton = True
                'ASPxPopupControl1.ShowOnPageLoad = True
                'Page.MaintainScrollPositionOnPostBack = True
                'lbltransid.Text = ViewState("trnsid")

            End If
        ElseIf e.CommandArgs.CommandName.ToString = "Re-Send" Then

            Dim ewr As String

            Dim ds1 As New DataSet
            cmd = New SqlCommand("select ReceiptID from  [CDS].[dbo].[withdrawals] where id= '" + ViewState("trnsid") + "'", cn)
            ''Commodity+'/'+Grade as [Prod] from WR where holder='" + ListBox1.SelectedItem.Value.ToString + "' and quantity>0 AND ([status]='ISSUED' OR [status]='SPLIT')", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds1, "names1")
            If (ds1.Tables(0).Rows.Count > 0) Then

                ewr = ds1.Tables(0).Rows(0).Item("ReceiptID").ToString

            End If

            If isOTPsent(ViewState("trnsid")) = True Then

                msgbox("Transaction status does not allow OTP to be resent!")
            Else



                If (cn.State = ConnectionState.Open) Then
                    cn.Close()
                End If
                cn.Open()
                Dim OTP As String = CreateOTP(4)

                Dim xyz As New Common
                If xyz.OTPenabled = True Then



                    Dim z As New sendmail
                    Try
                        z.sendmail(getemail(getDEPCDS(Session("Username"))).ToString, "Withdrawal Authorization Request", "Withdrawal on EWR No. " + ewr + " has been initiated in your account. Please authorize using OTP: " + OTP + "")
                    Catch ex As Exception
                        msgbox("Error Sending Email:" + ex.Message + "")
                    End Try

                    cmd = New SqlCommand("update [CDS].[dbo].[withdrawals] set OTP = '" + OTP + "' WHERE id = '" + ViewState("trnsid") + "'", cn)
                    'ASPxPopupControl1.PopupHorizontalAlign = DevExpress.Web.ASPxClasses.PopupHorizontalAlign.WindowCenter
                    'ASPxPopupControl1.PopupVerticalAlign = DevExpress.Web.ASPxClasses.PopupVerticalAlign.WindowCenter

                    'ASPxPopupControl1.AllowDragging = True
                    'ASPxPopupControl1.ShowCloseButton = True
                    'ASPxPopupControl1.ShowOnPageLoad = True
                    'Page.MaintainScrollPositionOnPostBack = True
                    'lbltransid.Text = ViewState("trnsid")

                    If cmd.ExecuteNonQuery() = 1 Then

                    End If

                End If
            End If

        ElseIf e.CommandArgs.CommandName.ToString = "Delete" Then


            flagdelete(ViewState("trnsid"))




        End If

        cn.Close()
    End Sub


    Public Sub flagdelete(ref As String)
        cmd = New SqlCommand("update  [CDS].[dbo].[withdrawals] set Deleted='1'  where id='" + ref + "' and isnull(ApprovedBy,'')=''", cn)
        If (cn.State = ConnectionState.Open) Then
            cn.Close()
        End If
        cn.Open()
        If cmd.ExecuteNonQuery() = 1 Then
            msgbox("Transaction successfully cancelled")
            getpending()
            getApproved()
        Else
            msgbox("Can not cancel this transaction")
        End If
        cn.Close()



    End Sub
    Public Function isOTPsent(ref As String) As Boolean


        Dim ds1 As New DataSet
        cmd = New SqlCommand("select * from withdrawals where id='" + ref + "' and  OTP is NOT NULL AND isnull(OTPStatus,'') <>'Approved'", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds1, "account_transfer")
        If (ds1.Tables(0).Rows.Count > 0) Then
            Return False
        Else
            Return True
        End If
    End Function

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
            'If (ds.Tables(0).Rows.Count > 0) Then
            '    txtparticipantname.Text = ds.Tables(0).Rows(0).Item("Company_name")
            '    txtAccountNo.Text = ds.Tables(0).Rows(0).Item("Company_Code")
            '    txtewrholder.Text = ds.Tables(0).Rows(0).Item("name")
            '    txtewraccountno.Text = getDEPCDS(Session("Username"))
            '    loadcomboforreceipts(getDEPCDS(Session("Username")))
            'End If

        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

  
End Class
