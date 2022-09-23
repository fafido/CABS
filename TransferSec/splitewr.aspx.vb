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
                msgbox("The split initiation for WR has been submitted for approval.")
            End If
            Page.MaintainScrollPositionOnPostBack = True
            If (Not IsPostBack) Then
                grdAvailableWRs.Attributes.Add("bordercolor", "#B7D8DC")
                grdSplits.Attributes.Add("bordercolor", "#B7D8DC")
                grdOTP.Attributes.Add("bordercolor", "#B7D8DC")

                checkSessionState()
                loadOTPsplits()


            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub


    Public Function GetMaxSplit(WRNo As String) As Integer
        Dim ds As New DataSet
        cmd = New SqlCommand("select isnull(count(*),0)+(SELECT count(*) from tblWRSplits where state<>'A' and [OriginalWRNo]='" + WRNo + "')  as tot from wr where LEFT(receiptno,LEN(receiptno)-4)=LEFT('" + WRNo + "',LEN('" + WRNo + "')-4)", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "names")
        If (ds.Tables(0).Rows.Count > 0) Then

            Dim rec As Decimal = ds.Tables(0).Rows(0).Item("tot")

            Return rec - 1
        End If

    End Function


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



    Protected Sub ASPxButton12_Click(sender As Object, e As EventArgs) Handles ASPxButton12.Click
        Try
            Dim totalspits As Decimal = lblSplitTotal.Text
            Dim ogqty As Decimal = lblOGQty.Text

            If totalspits <> ogqty Then
                msgbox("Transaction can not commit. There is a remaining balance that has not been allocated")
                Exit Sub
            End If

            Dim xyz As New Common
            If xyz.OTPenabled = True Then
                Dim OTP As String = CreateOTP(4)
                Dim z As New sendmail
                Try
                    z.sendmail(getemail(getholder(lblWRNo.Text)).ToString, "Split Authorization Request", "A Split on EWR No. " + lblWRNo.Text + "  has been initiated in your account. Please authorize using OTP: " + OTP + "")
                Catch ex As Exception
                    msgbox("Error Sending Email:" + ex.Message + "")
                End Try

                cmd = New SqlCommand("Update [CDS].[dbo].[tblWRSplits] set State='C', OTP='" + OTP + "', OTPSent='1', OTPCreateTime=getdate() where [OriginalWRNo]='" & lblWRNo.Text & "'", cn)
            Else
                cmd = New SqlCommand("Update [CDS].[dbo].[tblWRSplits] set State='C' where [OriginalWRNo]='" & lblWRNo.Text & "'", cn)
            End If



            If (cn.State = ConnectionState.Open) Then
                cn.Close()
            End If
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()

            Try
                Dim a As New passmanagement
                a.auditlog(Session("BrokerCode"), Session("Username"), "Submitted a Split Request", grdAvailableWRs.SelectedRow.Cells(1).Text, lblWRNo.Text)
            Catch ex As Exception

            End Try

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
            cmd = New SqlCommand("SELECT a.ID, ReceiptNo, a.Holder as DepositorAcc, b.Forenames + ' ' + b.Surname as  DepositorName, Commodity, Format(Quantity,'#,0.00') as [Quantity]    FROM [CDS].[dbo].[WR] a   inner join [CDS].[dbo].[Accounts_Clients] b   on a.Holder=b.CDS_Number   where a.Status='ISSUED' AND b.AccountState='A' and ReceiptNo like '%" + txtWRNo.Text.ToString() + "%'  and quantity>0 and receiptno not in (select receiptid from pendingtrans) AND warehouse='" + Session("BrokerCode") + "'", cn)
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
            cmd = New SqlCommand("SELECT a.ID, ReceiptNo, a.Holder as DepositorAcc, b.Forenames + ' ' + b.Surname as  DepositorName, Commodity, Format(Quantity,'#,0.00') as [Quantity]    FROM [CDS].[dbo].[WR] a   inner join [CDS].[dbo].[Accounts_Clients] b   on a.Holder=b.CDS_Number   where a.Status='ISSUED' and ReceiptNo like '%" + txtWRNo.Text.ToString() + "%' and ReceiptNo in (Select [OriginalWRNo] From [CDS].[dbo].[tblWRSplits] where State='R') ", cn)
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
        searchwr()

    End Sub
    Public Sub searchwr()
        Dim dsport As New DataSet
        If rblTranType.SelectedIndex = 0 Then
            cmd = New SqlCommand("SELECT a.ID, ReceiptNo, a.Holder as DepositorAcc, b.Forenames + ' ' + b.Surname as  DepositorName, Commodity, Format(Quantity,'#,0.00') as [Quantity]  FROM [CDS].[dbo].[WR] a   inner join [CDS].[dbo].[Accounts_Clients] b   on a.Holder=b.CDS_Number   where a.Status='ISSUED' AND b.AccountState='A' and b.Forenames + ' ' + b.Surname +' '+ a.receiptno like '%" + txtClientName.Text.ToString() + "%'  and quantity>0 and receiptno not in (select receiptid from pendingtrans) AND warehouse='" + Session("BrokerCode") + "'", cn)
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
            cmd = New SqlCommand("SELECT a.ID, ReceiptNo, a.Holder as DepositorAcc, b.Forenames + ' ' + b.Surname as  DepositorName, Commodity, Format(Quantity,'#,0.00') as [Quantity]    FROM [CDS].[dbo].[WR] a   inner join [CDS].[dbo].[Accounts_Clients] b   on a.Holder=b.CDS_Number   where a.Status='ISSUED' and b.Forenames + ' ' + b.Surname +' '+a.receiptno like '%" + txtClientName.Text.ToString() + "%' and ReceiptNo in (Select [OriginalWRNo] From [CDS].[dbo].[tblWRSplits] where State='R') ", cn)
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
        Dim holder As String = grdAvailableWRs.SelectedRow.Cells(1).Text

        Dim m As New NaymatBilling
        Dim transcharge As Double = m.Splitcharges("ENQUIRE", "DEPOSITOR", lblOGQty.Text, holder, lblWRNo.Text)
        Dim acccharges As Double = m.getEWRBAL(lblWRNo.Text, holder).ToString
        lbltransactioncharges.Text = transcharge.ToString("N")
        lblaccumulatedcharges.Text = acccharges.ToString("N")

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
            Dim wrsuffix As String = maxsplit

            For i = Len(maxsplit.ToString) To 2
                wrsuffix = "0" & wrsuffix

            Next i


            cmd = New SqlCommand(" insert into [CDS].[dbo].[tblWRSplits] ([TransactionRef],[Inputter],[TransactionDate],[OriginalWRNo],[OriginalQTY],[ChildQTY],[State],[Authoriser],[AuthDate],[WRParentPrefix] ,[WRChildSuffix],[Participant]) values ('" & CreateRandomPassword(12) & "','" & Session("UserName") & "','" & DateAndTime.Now() & "','" & lblWRNo.Text & "'," & lblOGQty.Text & "," & txtSplitQty.Text & ",'I',null,null,'" & Mid(lblWRNo.Text, 1, 9) & "','" & wrsuffix & "','" & Session("BrokerCode") & "')", cn)
            If (cn.State = ConnectionState.Open) Then
                cn.Close()
            End If
            cn.Open()
            cmd.ExecuteNonQuery()
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
        GetTotalandBal
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
    Public Sub loadOTPsplits()

        Dim xyz As New Common
        If xyz.OTPenabled = True Then
            Dim dsport As New DataSet
            cmd = New SqlCommand("SELECT a.ID, ReceiptNo, a.Holder as DepositorAcc, b.Forenames + ' ' + b.Surname as  DepositorName, Commodity, Quantity  FROM [CDS].[dbo].[WR] a   inner join [CDS].[dbo].[Accounts_Clients] b   on a.Holder=b.CDS_Number Where a.ReceiptNo in (Select OriginalWRNo from  [CDS].[dbo].[tblWRSplits] where State='C' and OTPStatus is NULL and Participant='" & Session("BrokerCode") & "')", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(dsport, "Splits")
            If (dsport.Tables(0).Rows.Count > 0) Then
                grdOTP.DataSource = dsport
                grdOTP.DataBind()
            Else
                grdOTP.DataSource = Nothing
                grdOTP.DataBind()
            End If
        Else
            Panel10.Visible = False
        End If

    End Sub
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
    Protected Sub grdOTP_SelectedIndexChanged(sender As Object, e As EventArgs) Handles grdOTP.SelectedIndexChanged

        ASPxPopupControl1.PopupHorizontalAlign = DevExpress.Web.ASPxClasses.PopupHorizontalAlign.WindowCenter
        ASPxPopupControl1.PopupVerticalAlign = DevExpress.Web.ASPxClasses.PopupVerticalAlign.WindowCenter

        ASPxPopupControl1.AllowDragging = True
        ASPxPopupControl1.ShowCloseButton = True
        ASPxPopupControl1.ShowOnPageLoad = True
        Page.MaintainScrollPositionOnPostBack = True
        lbltransid.Text = grdOTP.SelectedValue.ToString
    End Sub
    Public Function getotp(id As String) As String
        Dim dsport As New DataSet
        cmd = New SqlCommand("select isnull(OTP,'') as OTP from [tblWRSplits] where [OriginalWRNo]='" + id + "'", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(dsport, "trans")
        If (dsport.Tables(0).Rows.Count > 0) Then
            Return dsport.Tables(0).Rows(0).Item("OTP").ToString
        End If
    End Function

    Protected Sub btnSaveContract1_Click(sender As Object, e As EventArgs) Handles btnSaveContract1.Click
        If getotp(lbltransid.Text) <> txtotp.Text Then
            msgbox("Invalid OTP!")
            Exit Sub
        ElseIf getotp(lbltransid.Text) = txtotp.Text Then
            cmd = New SqlCommand("update [tblWRSplits] set OTPStatus='Approved', OTPResponseTime=getdate()   where [OriginalWRNo]='" + lbltransid.Text + "'", cn)
            If (cn.State = ConnectionState.Open) Then
                cn.Close()
            End If
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()


            ASPxPopupControl1.AllowDragging = False
            ASPxPopupControl1.ShowCloseButton = False
            ASPxPopupControl1.ShowOnPageLoad = False
            Page.MaintainScrollPositionOnPostBack = False
            loadOTPsplits()



            msgbox("OTP Correct! Split sent for approval")


        Else
            msgbox("Failed")
        End If
    End Sub

    Public Sub grdAvailableWRs_PageIndexChanged(sender As Object, e As EventArgs) Handles grdAvailableWRs.PageIndexChanged
        '  grdAvailableWRs.PageIndex = e.newpageindex
        searchwr()
    End Sub

    Private Sub grdAvailableWRs_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles grdAvailableWRs.PageIndexChanging
        grdAvailableWRs.PageIndex = e.NewPageIndex
        searchwr()
    End Sub
End Class
