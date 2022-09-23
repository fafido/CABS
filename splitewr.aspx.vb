
Imports DevExpress.Web.ASPxEditors
Imports DevExpress.Web.ASPxGridView


Partial Class TransferSec_splitewr
    Inherits System.Web.UI.Page
    Dim constr As String = (System.Configuration.ConfigurationManager.AppSettings("connpath"))
    Dim cn As New SqlConnection(constr)
    Dim adp As SqlDataAdapter
    Dim cmd As SqlCommand
    Dim fromEdit As Boolean = False
    Public Sub msgbox(ByVal strMessage As String)

        'finishes server processing, returns to client.
        Dim strScript As String = "<script language=JavaScript>"
        strScript += "window.alert(""" & strMessage & """);"
        strScript += "</script>"
        Dim lbl As New System.Web.UI.WebControls.Label
        lbl.Text = strScript
        Page.Controls.Add(lbl)

    End Sub
    Public Sub getApproved()

        Dim ds As New DataSet
        cmd = New SqlCommand("SELECT a.id, ReceiptNo, a.Holder as DepositorAcc, b.Forenames + ' ' + b.Surname as DepositorName, Commodity, Quantity,'Approved' as Status FROM [CDS].[dbo].[WR] a inner join [CDS].[dbo].[Accounts_Clients] b on a.Holder=b.CDS_Number Where a.ReceiptNo in (Select OriginalWRNo from [CDS].[dbo].[tblWRSplits] s join [CDS].[dbo].wr w on s.OriginalWRNo =w.ReceiptNo  where State='C' and w.Holder = '" + getDEPCDS(Session("Username")) + "'  and   isnull(OTPStatus,'') = 'APPROVED' and isnull(Authoriser,'') <> '' )", cn)
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
    Protected Sub btn_accept(ByVal sender As Object, ByVal e As EventArgs)
        Dim btn As ASPxButton = CType(sender, ASPxButton)
        Dim container As GridViewDataItemTemplateContainer = CType(btn.NamingContainer, GridViewDataItemTemplateContainer)
        Dim ds As New DataSet
        cmd = New SqlCommand("select * from [tblWRSplits] where  OriginalWRNo='" + container.KeyValue.ToString() + "' and isnull(OTPStatus,'') = ''  ", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "names")
        If (ds.Tables(0).Rows.Count > 0) Then
            ViewState("trnsid") = container.KeyValue.ToString()

            otptable.Visible = True
            otptable2.Visible = True

        Else

            msgbox("The transaction is on pending for approval")
            otptable.Visible = False
            otptable2.Visible = False
        End If

    End Sub
    Protected Sub btn_reject(ByVal sender As Object, ByVal e As EventArgs)
        Dim btn As ASPxButton = CType(sender, ASPxButton)
        Dim container As GridViewDataItemTemplateContainer = CType(btn.NamingContainer, GridViewDataItemTemplateContainer)
        ViewState("idReject") = container.KeyValue.ToString()

        If ViewState("idReject") <> "" Then

            cmd = New SqlCommand("update [CDS].[dbo].[tblWRSplits] set OTPStatus ='REJECTED' where id='" + ViewState("idReject") + "'", cn)
            If (cn.State = ConnectionState.Open) Then
                cn.Close()
            End If
            cn.Open()
            If cmd.ExecuteNonQuery() = 1 Then
                msgbox("Rejected Successfull ")
                txtotp.Text = ""
            End If

        End If
        loadgrid()

        getApproved()
        otptable.Visible = False
        otptable2.Visible = False

    End Sub

    Public Sub checkSessionState()
        Try

            ' loadgrid()

        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
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





            cmd = New SqlCommand("update [CDS].[dbo].[tblWRSplits] set OTPStatus ='APPROVED' where OriginalWRNo ='" + ViewState("trnsid") + "'", cn)
            If (cn.State = ConnectionState.Open) Then
                cn.Close()
            End If
            cn.Open()
            cmd.ExecuteNonQuery()
            msgbox("Transaction Successfully Authorized Waiting For Authorization")


                txtotp.Text = ""




            cn.Close()

            getApproved()
            loadgrid()
        Catch ex As Exception
            msgbox("Please make sure you entered all values")
        End Try

    End Sub
    Public Sub loadgrid()
        Dim ds As New DataSet
        cmd = New SqlCommand("SELECT a.id, ReceiptNo, a.Holder as DepositorAcc, b.Forenames + ' ' + b.Surname as DepositorName, Commodity, Quantity,'Pending' as Status FROM [CDS].[dbo].[WR] a inner join [CDS].[dbo].[Accounts_Clients] b on a.Holder=b.CDS_Number Where a.ReceiptNo in (Select OriginalWRNo from [CDS].[dbo].[tblWRSplits] s join [CDS].[dbo].wr w on s.OriginalWRNo =w.ReceiptNo  where State='C' and w.Holder = '" + getDEPCDS(Session("Username")) + "' and isnull(OTPStatus,'') <> 'REJECTED' and   isnull(Authoriser,'') = '' )", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "names")
        If (ds.Tables(0).Rows.Count > 0) Then
            ASPxGridView3.DataSource = ds
            ASPxGridView3.DataBind()

        End If

    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Session("finish") = "yes" Then
                Session("finish") = ""
                msgbox("The split initiation for WR has been submitted for approval.")
            End If
            Page.MaintainScrollPositionOnPostBack = True
            If (Not IsPostBack) Then
                checkSessionState()
                getdetails()
                loadgrid()
                getApproved()

            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub


    Public Function GetMaxSplit(WRNo As String) As Integer
        'Try
        Dim ds As New DataSet
        Dim maxmainstr As String = Mid(WRNo, 11, 3)
        Dim maxmain As Long = CLng(maxmainstr)
        Dim maxmini As Integer


        cmd = New SqlCommand("select isnull(max(convert(int,[WRChildSuffix])),0) as MaxSplit from [CDS].[dbo].[tblWRSplits] where substring([OriginalWRNo],1,9)= '" & Mid(WRNo, 1, 9) & "'", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "WRSplit")


        If (ds.Tables(0).Rows.Count > 0) Then
            maxmini = ds.Tables(0).Rows(0).Item("MaxSplit")
        Else
            maxmini = 0
        End If



        If maxmini > maxmain Then
            Return maxmini
        ElseIf maxmain > maxmini Then
            Return maxmain
        Else
            Return 0
        End If
        'Catch ex As Exception
        '    Return 0
        '    msgbox(ex.Message)
        'End Try

    End Function

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

    Protected Sub getdetails()
        Try
            Dim dsport As New DataSet

            cmd = New SqlCommand("SELECT a.ID, ReceiptNo, a.Holder as DepositorAcc, b.Forenames + ' ' + b.Surname as  DepositorName, Commodity, Quantity   FROM [CDS].[dbo].[WR] a   inner join [CDS].[dbo].[Accounts_Clients] b   on a.Holder=b.CDS_Number   where a.Status='ISSUED' and b.CDS_Number like '" + getDEPCDS(Session("Username")) + "' ", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(dsport, "trans")
            If (dsport.Tables(0).Rows.Count > 0) Then
                grdAvailableWRs.DataSource = dsport
                grdAvailableWRs.DataBind()
            Else
                grdAvailableWRs.DataSource = Nothing
                grdAvailableWRs.DataBind()

            End If



        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub




    Protected Sub ASPxButton12_Click(sender As Object, e As EventArgs) Handles ASPxButton12.Click
        Try
            Dim totalspits As Decimal = lblSplitTotal.Text
            Dim ogqty As Decimal = lblOGQty.Text



            If totalspits <> ogqty Then
                msgbox("Transaction can not commit. There is a remaining balance that has not been allocated")
                Exit Sub
            End If

            'cmd = New SqlCommand("Update [CDS].[dbo].[tblWRSplits] set State='C' where [OriginalWRNo]='" & lblWRNo.Text & "'", cn)
            If (cn.State = ConnectionState.Open) Then
                cn.Close()
            End If
            cn.Open()

            Dim xyz As New Common
                If xyz.OTPenabled = True Then


                    Dim OTP As String = CreateOTP(4)
                    Dim z As New sendmail
                    Try
                        z.sendmail(getemail(getDEPCDS(Session("Username"))).ToString, "Split Authorization Request", "A Split on EWR No. " + lblWRNo.Text + " has been initiated in your account. Please authorize using OTP: " + OTP + "")
                    Catch ex As Exception
                        msgbox("Error Sending Email:" + ex.Message + "")
                    End Try

                    cmd = New SqlCommand("Update [CDS].[dbo].[tblWRSplits] set State='C', OTP='" + OTP + "', OTPSent='1', OTPCreateTime=getdate() where [OriginalWRNo]='" & lblWRNo.Text & "'", cn)
                Else

                    cmd = New SqlCommand("Update [CDS].[dbo].[tblWRSplits] set State='C' where [OriginalWRNo]='" & lblWRNo.Text & "'", cn)
                End If

            cmd.ExecuteNonQuery()
            cn.Close()

            msgbox("The split initiation for WR " & lblWRNo.Text & " has successfully been submitted for authorisation")

            Session("finish") = "yes"
            Response.Redirect(Request.RawUrl)

        Catch ex As Exception
            msgbox("Transaction failed to commit, please check all details")
        End Try

    End Sub


    Protected Sub ASPxButton1_Click(sender As Object, e As EventArgs) Handles ASPxButton1.Click
        Dim dsport As New DataSet

        If rblTranType.SelectedIndex = 0 Then
            cmd = New SqlCommand("SELECT a.ID, ReceiptNo, a.Holder as DepositorAcc, b.Forenames + ' ' + b.Surname as  DepositorName, Commodity, Quantity   FROM [CDS].[dbo].[WR] a   inner join [CDS].[dbo].[Accounts_Clients] b   on a.Holder=b.CDS_Number   where a.Status='ISSUED' and ReceiptNo like '%" + txtWRNo.Text.ToString() + "%' ", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(dsport, "trans")
            If (dsport.Tables(0).Rows.Count > 0) Then
                grdAvailableWRs.DataSource = dsport
                grdAvailableWRs.DataBind()
            Else
                grdAvailableWRs.DataSource = Nothing
                grdAvailableWRs.DataBind()

            End If
        Else
            cmd = New SqlCommand("SELECT a.ID, ReceiptNo, a.Holder as DepositorAcc, b.Forenames + ' ' + b.Surname as  DepositorName, Commodity, Quantity   FROM [CDS].[dbo].[WR] a   inner join [CDS].[dbo].[Accounts_Clients] b   on a.Holder=b.CDS_Number   where a.Status='ISSUED' and ReceiptNo like '%" + txtWRNo.Text.ToString() + "%' and ReceiptNo in (Select [OriginalWRNo] From [CDS].[dbo].[tblWRSplits] where State='R') ", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(dsport, "trans")
            If (dsport.Tables(0).Rows.Count > 0) Then
                grdAvailableWRs.DataSource = dsport
                grdAvailableWRs.DataBind()
            Else
                grdAvailableWRs.DataSource = Nothing
                grdAvailableWRs.DataBind()
            End If

        End If
    End Sub

    Protected Sub ASPxButton2_Click(sender As Object, e As EventArgs) Handles ASPxButton2.Click
        Dim dsport As New DataSet
        If rblTranType.SelectedIndex = 0 Then
            cmd = New SqlCommand("SELECT a.ID, ReceiptNo, a.Holder as DepositorAcc, b.Forenames + ' ' + b.Surname as  DepositorName, Commodity, Quantity   FROM [CDS].[dbo].[WR] a   inner join [CDS].[dbo].[Accounts_Clients] b   on a.Holder=b.CDS_Number   where a.Status='ISSUED' and b.Forenames + ' ' + b.Surname like '%" + txtClientName.Text.ToString() + "%' ", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(dsport, "trans")
            If (dsport.Tables(0).Rows.Count > 0) Then
                grdAvailableWRs.DataSource = dsport
                grdAvailableWRs.DataBind()
            Else
                grdAvailableWRs.DataSource = Nothing
                grdAvailableWRs.DataBind()

            End If
        Else
            cmd = New SqlCommand("SELECT a.ID, ReceiptNo, a.Holder as DepositorAcc, b.Forenames + ' ' + b.Surname as  DepositorName, Commodity, Quantity   FROM [CDS].[dbo].[WR] a   inner join [CDS].[dbo].[Accounts_Clients] b   on a.Holder=b.CDS_Number   where a.Status='ISSUED' and b.Forenames + ' ' + b.Surname like '%" + txtClientName.Text.ToString() + "%' and ReceiptNo in (Select [OriginalWRNo] From [CDS].[dbo].[tblWRSplits] where State='R') ", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(dsport, "trans")
            If (dsport.Tables(0).Rows.Count > 0) Then
                grdAvailableWRs.DataSource = dsport
                grdAvailableWRs.DataBind()
            Else
                grdAvailableWRs.DataSource = Nothing
                grdAvailableWRs.DataBind()

            End If
        End If
    End Sub

    Protected Sub grdAvailableWRs_SelectedIndexChanged(sender As Object, e As EventArgs) Handles grdAvailableWRs.SelectedIndexChanged
        Dim checksplits As Boolean
        lblWRNo.Text = grdAvailableWRs.SelectedRow.Cells(0).Text
        lblOGQty.Text = grdAvailableWRs.SelectedRow.Cells(4).Text
        checksplits = CheckOpenSplits(lblWRNo.Text)
        If checksplits = True Then
            msgbox("The are pending spits on this WR, awaiting approval, you can not proceed")
            Exit Sub
        End If
        LoadSplits()
        GetTotalandBal()
        If rblTranType.SelectedIndex = 1 Then
            TextBox1.Text = GetRejectionRemark(lblWRNo.Text)
        End If
    End Sub
    Public Function GetRejectionRemark(wrno As String) As String
        Dim dsport As New DataSet
        cmd = New SqlCommand("SELECT TOP 1 Remarks   FROM [CDS].[dbo].[tblWRSplits]   where State='R' and [OriginalWRNo] = '" & wrno & "' ", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(dsport, "Splits")
        If (dsport.Tables(0).Rows.Count > 0) Then
            Return dsport.Tables(0).Rows(0).Item("Remarks")
        Else
            Return ""
        End If
    End Function
    Public Shared Function CreateRandomPassword(ByVal PasswordLength As Integer) As String
        Dim _allowedChars As String = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz"
        Dim randomNumber As New Random()
        Dim chars(PasswordLength - 1) As Char
        Dim allowedCharCount As Integer = _allowedChars.Length
        For i As Integer = 0 To PasswordLength - 1
            chars(i) = _allowedChars.Chars(CInt(Fix((_allowedChars.Length) * randomNumber.NextDouble())))
        Next i
        Return New String(chars)
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
    Protected Sub ASPxButton16_Click(sender As Object, e As EventArgs) Handles ASPxButton16.Click
        ' Try
        If ASPxButton16.Text = "Add(+)" Then



            If Not IsNumeric(txtSplitQty.Text) Then
                msgbox("Please numeric value for splits")
                Exit Sub
            End If
            Dim splitquant As Decimal = txtSplitQty.Text
            Dim allquant As Decimal = lblOGQty.Text
            If splitquant >= allquant Then
                msgbox("Split Quantity must be less than WR quantity")
                Exit Sub
            End If

            Dim wrbal As Decimal = lblWRBal.Text
            Dim totalsplits As Decimal = lblSplitTotal.Text

            Dim newbal As Decimal = splitquant + totalsplits

            If newbal > allquant Then

                msgbox("The remaining balance is insufficient to cover this split")
                Exit Sub
            End If

            Dim maxsplit As Integer = GetMaxSplit(lblWRNo.Text) + 1

            Dim i As Integer = 1
            Dim wrsuffix As String = "" & maxsplit

            For i = Len(maxsplit.ToString) To 2
                wrsuffix = "0" & wrsuffix

            Next i


            cmd = New SqlCommand(" insert into [CDS].[dbo].[tblWRSplits] ([TransactionRef],[Inputter],[TransactionDate],[OriginalWRNo],[OriginalQTY],[ChildQTY],[State],[Authoriser],[AuthDate],[WRParentPrefix] ,[WRChildSuffix],[Participant]) values ('" & CreateRandomPassword(12) & "','" & Session("UserName") & "','" & DateAndTime.Now() & "','" & lblWRNo.Text & "'," & lblOGQty.Text & "," & txtSplitQty.Text & ",'I',null,null,'" & Mid(lblWRNo.Text, 1, 9) & "','" & wrsuffix & "','" & getoperator(getDEPCDS(Session("Username"))) & "')", cn)
            If (cn.State = ConnectionState.Open) Then
                cn.Close()
            End If
            cn.Open()
            If cmd.ExecuteNonQuery() = 1 Then

            End If
            cn.Close()
        Else




            cmd = New SqlCommand("Update [CDS].[dbo].[tblWRSplits] set State='I', [ChildQTY]=" & txtSplitQty.Text & " where [TransactionRef] = '" & TransRef.Text & "'", cn)
            If (cn.State = ConnectionState.Open) Then
                cn.Close()
            End If
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()
            ASPxButton16.Text = "Add(+)"
        End If
        fromEdit = False
        txtSplitQty.Text = ""
        LoadSplits()
        GetTotalandBal()
        loadgrid()
        getApproved()
        '  Catch ex As Exception
        ' msgbox("Please select correct splits")
        ' End Try

    End Sub
    Public Sub LoadSplits()
        Dim dsport As New DataSet
        cmd = New SqlCommand("SELECT [ID],[TransactionRef], [WRChildSuffix],  [ChildQTY]   FROM [CDS].[dbo].[tblWRSplits]   where State IN ('I','R') and [OriginalWRNo] = '" & lblWRNo.Text & " ' ", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(dsport, "Splits")
        If (dsport.Tables(0).Rows.Count > 0) Then
            grdSplits.DataSource = dsport
            grdSplits.DataBind()
        Else
            grdSplits.DataSource = Nothing
            grdSplits.DataBind()

        End If
    End Sub

    Public Function checkotp(otp As String) As Boolean
        Dim ds As New DataSet

        cmd = New SqlCommand("select *  FROM [CDS].[dbo].[tblWRSplits] where isnull(OTP,'')='" + otp.Trim + "' and OriginalWRNo ='" + ViewState("trnsid") + "' ", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "otp")
        If (ds.Tables(0).Rows.Count > 0) Then
            Return False
        Else


            Return True

        End If
    End Function
    Public Function CheckOpenSplits(wrnum As String) As Boolean
        Dim dsport As New DataSet
        cmd = New SqlCommand("SELECT *   FROM [CDS].[dbo].[tblWRSplits]   where State ='C' and [OriginalWRNo] = '" & wrnum & " ' ", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(dsport, "Splits")
        If (dsport.Tables(0).Rows.Count > 0) Then
            Return True
        Else
            Return False
        End If

    End Function
    Public Sub GetTotalandBal()
        Dim i As Integer
        Dim totalSplits As Decimal
        Dim splititem As Decimal
        Dim fullqty As Decimal

        fullqty = lblOGQty.Text
        For i = 0 To grdSplits.Rows.Count() - 1
            splititem = grdSplits.Rows(i).Cells(2).Text
            totalSplits = totalSplits + splititem
        Next
        lblSplitTotal.Text = totalSplits
        lblWRBal.Text = fullqty - totalSplits
    End Sub

    Protected Sub grdSplits_SelectedIndexChanged(sender As Object, e As EventArgs) Handles grdSplits.SelectedIndexChanged
        fromEdit = True
        txtSplitQty.Text = grdSplits.SelectedRow.Cells(2).Text
        TransRef.Text = grdSplits.SelectedRow.Cells(0).Text
        ASPxButton16.Text = "Update"
    End Sub
End Class
