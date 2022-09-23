Partial Class TransferSec_ApproveSplitEWR
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
        ' Try
        If Session("finish") = "yes" Then
                Session("finish") = ""
                msgbox("Split Transaction authorised successfully")

            End If
            If Session("finish") = "no" Then
                Session("finish") = ""
                msgbox("Split Transaction was rejected")

            End If
            Page.MaintainScrollPositionOnPostBack = True
        If (Not IsPostBack) Then
            grdAvailableWRs.Attributes.Add("bordercolor", "#B7D8DC")
            grdSplits.Attributes.Add("bordercolor", "#B7D8DC")
            checkSessionState()
            LoadGlobalSplits()

        End If
        'Catch ex As Exception
        'msgbox(ex.Message)
        'End Try
    End Sub


    Public Function GetMaxSplit(WRNo As String) As Integer
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select max(convert(int,[WRChildSuffix])) as MaxSplit from [CDS].[dbo].[tblWRSplits] where [OriginalWRNo]= '" & WRNo & "'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "WRSplit")
            If (ds.Tables(0).Rows.Count > 0) Then
                Return ds.Tables(0).Rows(0).Item("MaxSplit")
            Else
                Return 0
            End If

        Catch ex As Exception
            Return 0
            msgbox(ex.Message)
        End Try

    End Function






    Protected Sub ASPxButton12_Click(sender As Object, e As EventArgs) Handles ASPxButton12.Click
        'Try
        Try
            Try


                Dim m As New NaymatBilling
                Dim transcharge As Double = m.Splitcharges("BILL", "DEPOSITOR", grdAvailableWRs.SelectedRow.Cells(4).Text, grdAvailableWRs.SelectedRow.Cells(1).Text, grdAvailableWRs.SelectedRow.Cells(0).Text)

            Catch ex As Exception

            End Try




            cmd = New SqlCommand("insert into WarehourseDeliveries ([Holder]      ,[Commodity]      ,[Grade]      ,[Warehouse]      ,[Expiry]      ,[Date_Issued]      ,[Quantity]      ,[InsurancePolicy]      ,[Price]      ,[Issued_By]      ,[Approved_By]      ,[Financier]      ,[ApprovedBy]      ,[ApprovedOn]      ,[ReceiptNo]      ,[HarvestDate]      ,[UnitMeasure]      ,[InsuranceCompany]      ,[InsuranceDetails]      ,[InsuranceExpiry]      ,[MoistureContent]      ,[Broken]      ,[Damage]      ,[ForeignMatters]      ,[transportcharges]      ,[warehouseNo]      ,[shelfNo]      ,[boxNo]      ,[compatimentNo]      ,[WarehouseOperator]      ,[Status]      ,[SystemType]      ,[Reference]      ,[OriginalQuantity]      ,[Marks]      ,[LotNo]      ,[SiloNo]      ,[MarketValue]      ,[Wastage]      ,[OtherCharges]      ,[Packaging]      ,[Packages]      ,[Unit_Weight]      ,[Remarks]      ,[StorageCharge]      ,[ReceiptID])SELECT [Holder]      ,[Commodity]      ,[Grade]      ,[Warehouse]      ,[Expiry]      ,[Date_Issued]      ,b.ChildQTY/b.OriginalQTY *a.Quantity       ,[InsurancePolicy]      ,[Price]      ,[Issued_By]      ,[Approved_By]      ,[Financier]      ,[ApprovedBy]      ,[ApprovedOn]      ,[ReceiptNo]      ,[HarvestDate]      ,[UnitMeasure]      ,[InsuranceCompany]      ,[InsuranceDetails]      ,[InsuranceExpiry]      ,[MoistureContent]      ,[Broken]      ,[Damage]      ,[ForeignMatters]      ,[transportcharges]      ,[warehouseNo]      ,[shelfNo]      ,[boxNo]      ,[compatimentNo]      ,[WarehouseOperator]      ,[Status]      ,[SystemType]      ,[Reference]      ,[OriginalQuantity]      ,[Marks]      ,[LotNo]      ,[SiloNo]      ,b.ChildQTY/b.OriginalQTY *[MarketValue]      ,[Wastage]      ,[OtherCharges]      ,[Packaging]      ,b.ChildQTY/b.OriginalQTY *[Packages]      ,[Unit_Weight]      ,a.[Remarks]      ,[StorageCharge]      ,b.WRParentPrefix +'-'+b.WRChildSuffix from WarehourseDeliveries  a inner join [CDS].[dbo].[tblWRSplits] b on a.Receiptid=b.[OriginalWRNo] where a.ReceiptID = '" & grdAvailableWRs.SelectedRow.Cells(0).Text & "'", cn)
            If (cn.State = ConnectionState.Open) Then
                cn.Close()
            End If
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()

        Catch ex As Exception
            msgbox(ex.Message)
        End Try


        cmd = New SqlCommand("insert into [CDS].[dbo].[WR] ([Holder],[Commodity],[Grade],[Warehouse],[Expiry],[Date_Issued],[Quantity],[InsurancePolicy],[Price],[Issued_By],[Approved_By] ,[Financier],[ApprovedBy],[ApprovedOn],[ReceiptNo],[HarvestDate],[UnitMeasure],[InsuranceCompany],[InsuranceDetails],[InsuranceExpiry],[MoistureContent],[Broken],[Damage],[ForeignMatters],[transportcharges],[WarehousePhysical],[Status],[DeliveryID],[OriginalQuantity],[Approve1],[Approve2])   (select [Holder],[Commodity],[Grade],[Warehouse],[Expiry],b.TransactionDate,b.ChildQTY,[InsurancePolicy],[Price],[Issued_By],[Approved_By] ,[Financier],[ApprovedBy],[ApprovedOn],b.WRParentPrefix + '-' + b.WRChildSuffix,[HarvestDate],[UnitMeasure],[InsuranceCompany],[InsuranceDetails],[InsuranceExpiry],[MoistureContent],[Broken],[Damage],[ForeignMatters],[transportcharges],[WarehousePhysical],[Status],[DeliveryID],[OriginalQuantity],[Approve1],[Approve2] from wr a inner join [CDS].[dbo].[tblWRSplits] b on a.ReceiptNo=b.[OriginalWRNo] where a.ReceiptNo = '" & grdAvailableWRs.SelectedRow.Cells(0).Text & "')", cn)
        If (cn.State = ConnectionState.Open) Then
            cn.Close()
        End If
        cn.Open()
        cmd.ExecuteNonQuery()
        cn.Close()






        cmd = New SqlCommand("Insert into trans select commodity + '/' + grade, holder,getdate(),GetDate(),quantity*-1,'Split','USER',22,'W',0,ReceiptNo,'COMMODITY',Warehouse,null,warehousephysical,Warehouse  from WR   where ReceiptNo='" & grdAvailableWRs.SelectedRow.Cells(0).Text & "'", cn)
        If (cn.State = ConnectionState.Open) Then
            cn.Close()
        End If
        cn.Open()
        cmd.ExecuteNonQuery()
        cn.Close()


        cmd = New SqlCommand("Insert into trans Select  a.commodity + '/' + a.grade, a.holder,b.transactiondate,GetDate(),b.childqty,'Split',b.inputter,22,'W',0,b.WRParentPrefix + '-' + b.WRChildSuffix,'COMMODITY',b.Participant, null,a.warehousephysical,b.participant  From WR a inner Join tblwrsplits b on a.ReceiptNo=b.originalwrno   where a.ReceiptNo='" & grdAvailableWRs.SelectedRow.Cells(0).Text & "'", cn)
        If (cn.State = ConnectionState.Open) Then
            cn.Close()
        End If
        cn.Open()
        cmd.ExecuteNonQuery()
        cn.Close()



        cmd = New SqlCommand("Update [CDS].[dbo].[WR] set Status='SPLIT', Quantity=0 where [ReceiptNo]='" & grdAvailableWRs.SelectedRow.Cells(0).Text & "'  insert into CashTrans([Description],TransType,Amount,DateCreated,TransStatus,CDS_Number,Reference,ChargeCode) select a.[Description]+' - Reversed',a.TransType,-1*Amount,getdate(),TransStatus,CDS_Number,Reference,ChargeCode from CashTransComb a where a.[Description] in ('Warehouse Storage Rental Fee NCMCL','Warehouse Storage Rental WHO')  and a.Reference='" + grdAvailableWRs.SelectedRow.Cells(0).Text + "'", cn)
        If (cn.State = ConnectionState.Open) Then
            cn.Close()
        End If
        cn.Open()
        cmd.ExecuteNonQuery()
        cn.Close()

        settlecharges(grdAvailableWRs.SelectedRow.Cells(0).Text)


        cmd = New SqlCommand("Update [CDS].[dbo].[tblWRSplits] Set State='A' where [OriginalWRNo]='" & grdAvailableWRs.SelectedRow.Cells(0).Text & "'", cn)
        If (cn.State = ConnectionState.Open) Then
            cn.Close()
        End If
        cn.Open()
        cmd.ExecuteNonQuery()
        cn.Close()

        msgbox("Split Transaction for WR " & grdAvailableWRs.SelectedRow.Cells(0).Text & " authorised successfully")


        Try
            Dim em As New sendmail
            em.sendmail(getemail(grdAvailableWRs.SelectedRow.Cells(1).Text), "EWR Split", "Split Transaction For EWR " & grdAvailableWRs.SelectedRow.Cells(0).Text & " authorised successfully")
        Catch ex As Exception
            msgbox("Error Sending email!")
        End Try

        Try
            Dim a As New passmanagement
            a.auditlog(Session("BrokerCode"), Session("Username"), "Approved a Split Request", grdAvailableWRs.SelectedRow.Cells(1).Text, grdAvailableWRs.SelectedRow.Cells(0).Text)
        Catch ex As Exception

        End Try




        Session("finish") = "yes"
        Response.Redirect(Request.RawUrl)






        'Catch ex As Exception
        '    msgbox("Transaction failed To commit, please check all details")
        '    End Try

    End Sub
    Public Sub settlecharges(ewrnumber As String)
        Dim ds As New DataSet
        cmd = New SqlCommand("Select  a.commodity + '/' + a.grade,b.OriginalQTY, a.holder,b.transactiondate,GetDate(),b.childqty,'Split',b.inputter,22,'W',0,b.WRParentPrefix + '-' + b.WRChildSuffix as newwr,'COMMODITY',b.Participant, null,a.warehousephysical,b.participant  From WR a inner Join tblwrsplits b on a.ReceiptNo=b.originalwrno   where a.ReceiptNo='" + ewrnumber + "'", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "names")
        If (ds.Tables(0).Rows.Count > 0) Then
            For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                Dim splitwrnumber As String = ds.Tables(0).Rows(i).Item("newwr").ToString
                Dim originalqty As Decimal = ds.Tables(0).Rows(i).Item("OriginalQTY").ToString
                Dim splitqty As Decimal = ds.Tables(0).Rows(i).Item("childqty").ToString
                Dim rati As Decimal = splitqty / originalqty
                cmd = New SqlCommand("insert into CashTrans([Description],TransType,Amount,DateCreated,TransStatus,CDS_Number,Reference,ChargeCode) select a.[Description]+' - Split',a.TransType," + rati.ToString + "* Amount,getdate(),TransStatus,CDS_Number,'" + splitwrnumber + "',ChargeCode from CashTransComb a where a.[Description] in ('Warehouse Storage Rental Fee NCMCL','Warehouse Storage Rental WHO')  and a.Reference='" + ewrnumber + "' and A.Amount>0", cn)
                If (cn.State = ConnectionState.Open) Then
                    cn.Close()
                End If
                cn.Open()
                cmd.ExecuteNonQuery()
                cn.Close()
            Next
        End If
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

    Public Sub LoadGlobalSplits()
        Dim dsport As New DataSet
        Dim xyz As New Common
        If xyz.OTPenabled = True Then
            cmd = New SqlCommand("SELECT a.ID, ReceiptNo, a.Holder as DepositorAcc, b.Forenames + ' ' + b.Surname as  DepositorName, Commodity, Quantity  FROM [CDS].[dbo].[WR] a   inner join [CDS].[dbo].[Accounts_Clients] b   on a.Holder=b.CDS_Number Where a.ReceiptNo in (Select OriginalWRNo from  [CDS].[dbo].[tblWRSplits] where State='C' and OTPStatus='Approved' and Participant='" & Session("BrokerCode") & "')", cn)
        Else
            cmd = New SqlCommand("SELECT a.ID, ReceiptNo, a.Holder as DepositorAcc, b.Forenames + ' ' + b.Surname as  DepositorName, Commodity, Quantity  FROM [CDS].[dbo].[WR] a   inner join [CDS].[dbo].[Accounts_Clients] b   on a.Holder=b.CDS_Number Where a.ReceiptNo in (Select OriginalWRNo from  [CDS].[dbo].[tblWRSplits] where State='C' and Participant='" & Session("BrokerCode") & "')", cn)
        End If

        adp = New SqlDataAdapter(cmd)
        adp.Fill(dsport, "trans")
        If (dsport.Tables(0).Rows.Count > 0) Then
            grdAvailableWRs.DataSource = dsport
            grdAvailableWRs.DataBind()
        Else
            grdAvailableWRs.DataSource = Nothing
            grdAvailableWRs.DataBind()

        End If
    End Sub
    Protected Sub ASPxButton1_Click(sender As Object, e As EventArgs) Handles ASPxButton1.Click
        Dim dsport As New DataSet
        Dim xyz As New Common
        'If xyz.OTPenabled = True Then
        '    cmd = New SqlCommand("SELECT a.ID, ReceiptNo, a.Holder as DepositorAcc, b.Forenames + ' ' + b.Surname as  DepositorName, Commodity, Quantity   FROM [CDS].[dbo].[WR] a   inner join [CDS].[dbo].[Accounts_Clients] b   on a.Holder=b.CDS_Number inner join  [CDS].[dbo].[tblWRSplits] c on a.ReceiptNo=c.[OriginalWRNo]   where a.Status='ISSUED' and c.State='C' and c.OTPStatus='Approved' and ReceiptNo like '%" + txtWRNo.Text.ToString() + "%'", cn)
        'Else
        '    cmd = New SqlCommand("SELECT a.ID, ReceiptNo, a.Holder as DepositorAcc, b.Forenames + ' ' + b.Surname as  DepositorName, Commodity, Quantity   FROM [CDS].[dbo].[WR] a   inner join [CDS].[dbo].[Accounts_Clients] b   on a.Holder=b.CDS_Number inner join  [CDS].[dbo].[tblWRSplits] c on a.ReceiptNo=c.[OriginalWRNo]   where a.Status='ISSUED' and c.State='C' and ReceiptNo like '%" + txtWRNo.Text.ToString() + "%'", cn)
        'End If

        If xyz.OTPenabled = True Then
            cmd = New SqlCommand("SELECT a.ID, ReceiptNo, a.Holder as DepositorAcc, b.Forenames + ' ' + b.Surname as  DepositorName, Commodity, Quantity  FROM [CDS].[dbo].[WR] a   inner join [CDS].[dbo].[Accounts_Clients] b   on a.Holder=b.CDS_Number Where a.ReceiptNo in (Select OriginalWRNo from  [CDS].[dbo].[tblWRSplits] where State='C' and OTPStatus='Approved' and Participant='" & Session("BrokerCode") & "' and ReceiptNo like '%" + txtWRNo.Text.ToString() + "%')", cn)
        Else
            cmd = New SqlCommand("SELECT a.ID, ReceiptNo, a.Holder as DepositorAcc, b.Forenames + ' ' + b.Surname as  DepositorName, Commodity, Quantity  FROM [CDS].[dbo].[WR] a   inner join [CDS].[dbo].[Accounts_Clients] b   on a.Holder=b.CDS_Number Where a.ReceiptNo in (Select OriginalWRNo from  [CDS].[dbo].[tblWRSplits] where State='C' and Participant='" & Session("BrokerCode") & "' and ReceiptNo like '%" + txtWRNo.Text.ToString() + "%')", cn)
        End If

        adp = New SqlDataAdapter(cmd)
        adp.Fill(dsport, "trans")
        If (dsport.Tables(0).Rows.Count > 0) Then
            grdAvailableWRs.DataSource = dsport
            grdAvailableWRs.DataBind()
        Else
            grdAvailableWRs.DataSource = Nothing
            grdAvailableWRs.DataBind()

        End If
    End Sub

    Protected Sub ASPxButton2_Click(sender As Object, e As EventArgs) Handles ASPxButton2.Click
        Dim dsport As New DataSet
        Dim xyz As New Common
        'If xyz.OTPenabled = True Then
        '    cmd = New SqlCommand("SELECT a.ID, ReceiptNo, a.Holder as DepositorAcc, b.Forenames + ' ' + b.Surname as  DepositorName, Commodity, Quantity   FROM [CDS].[dbo].[WR] a   inner join [CDS].[dbo].[Accounts_Clients] b   on a.Holder=b.CDS_Number inner join [CDS].[dbo].[tblWRSplits] c on a.ReceiptNo=c.[OriginalWRNo]   where a.Status='ISSUED' and C.State='C' and b.Forenames + ' ' + b.Surname like '%" + txtClientName.Text.ToString() + "%' ", cn)
        'Else
        '    cmd = New SqlCommand("SELECT a.ID, ReceiptNo, a.Holder as DepositorAcc, b.Forenames + ' ' + b.Surname as  DepositorName, Commodity, Quantity   FROM [CDS].[dbo].[WR] a   inner join [CDS].[dbo].[Accounts_Clients] b   on a.Holder=b.CDS_Number inner join [CDS].[dbo].[tblWRSplits] c on a.ReceiptNo=c.[OriginalWRNo]   where a.Status='ISSUED' and C.State='C' and C.OTPStatus='Approved' and b.Forenames + ' ' + b.Surname like '%" + txtClientName.Text.ToString() + "%' ", cn)
        'End If

        If xyz.OTPenabled = True Then
            cmd = New SqlCommand("SELECT a.ID, ReceiptNo, a.Holder as DepositorAcc, b.Forenames + ' ' + b.Surname as  DepositorName, Commodity, Quantity  FROM [CDS].[dbo].[WR] a   inner join [CDS].[dbo].[Accounts_Clients] b   on a.Holder=b.CDS_Number Where a.ReceiptNo in (Select OriginalWRNo from  [CDS].[dbo].[tblWRSplits] where State='C' and OTPStatus='Approved' and Participant='" & Session("BrokerCode") & "') and b.Forenames + ' ' + b.Surname like '%" + txtClientName.Text.ToString() + "%' ", cn)
        Else
            cmd = New SqlCommand("SELECT a.ID, ReceiptNo, a.Holder as DepositorAcc, b.Forenames + ' ' + b.Surname as  DepositorName, Commodity, Quantity  FROM [CDS].[dbo].[WR] a   inner join [CDS].[dbo].[Accounts_Clients] b   on a.Holder=b.CDS_Number Where a.ReceiptNo in (Select OriginalWRNo from  [CDS].[dbo].[tblWRSplits] where State='C' and Participant='" & Session("BrokerCode") & "') and b.Forenames + ' ' + b.Surname like '%" + txtClientName.Text.ToString() + "%' ", cn)
        End If

        adp = New SqlDataAdapter(cmd)
        adp.Fill(dsport, "trans")
        If (dsport.Tables(0).Rows.Count > 0) Then
            grdAvailableWRs.DataSource = dsport
            grdAvailableWRs.DataBind()
        Else
            grdAvailableWRs.DataSource = Nothing
            grdAvailableWRs.DataBind()

        End If
    End Sub

    Protected Sub grdAvailableWRs_SelectedIndexChanged(sender As Object, e As EventArgs) Handles grdAvailableWRs.SelectedIndexChanged
        LoadSplits(grdAvailableWRs.SelectedRow.Cells(0).Text)
    End Sub
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
    'Protected Sub ASPxButton16_Click(sender As Object, e As EventArgs) Handles ASPxButton16.Click
    '    ' Try


    '    If Not IsNumeric(txtSplitQty.Text) Then
    '        msgbox("Please numeric value for splits")
    '        Exit Sub
    '    End If
    '    'Dim splitquant As Decimal = txtSplitQty.Text
    '    'Dim allquant As Decimal = lblOGQty.Text
    '    If splitquant >= allquant Then
    '        msgbox("Split Quantity must be less than WR quantity")
    '        Exit Sub
    '    End If

    '    'Dim wrbal As Decimal = lblWRBal.Text
    '    'Dim totalsplits As Decimal = lblSplitTotal.Text

    '    Dim newbal As Decimal = splitquant + totalsplits

    '    If newbal > allquant Then

    '        msgbox("The remaining balance is insufficient to cover this split")
    '        Exit Sub
    '    End If

    '    Dim maxsplit As Integer = GetMaxSplit(lblWRNo.Text) + 1

    '    Dim i As Integer = 1
    '    Dim wrsuffix As String = "" & maxsplit

    '    For i = Len(maxsplit.ToString) To 2
    '        wrsuffix = "0" & wrsuffix

    '    Next i
    '    If fromEdit = False Then
    '        cmd = New SqlCommand(" insert into [CDS].[dbo].[tblWRSplits] ([TransactionRef],[Inputter],[TransactionDate],[OriginalWRNo],[OriginalQTY],[ChildQTY],[State],[Authoriser],[AuthDate],[WRParentPrefix] ,[WRChildSuffix],[Participant]) values ('" & CreateRandomPassword(12) & "','" & Session("UserName") & "','" & DateAndTime.Now() & "','" & lblWRNo.Text & "'," & lblOGQty.Text & "," & txtSplitQty.Text & ",'I',null,null,'" & Mid(lblWRNo.Text, 1, 7) & "','" & wrsuffix & "','" & Session("BrokerCode") & "')", cn)
    '        If (cn.State = ConnectionState.Open) Then
    '            cn.Close()
    '        End If
    '        cn.Open()
    '        cmd.ExecuteNonQuery()
    '        cn.Close()
    '    Else
    '        cmd = New SqlCommand("Update [CDS].[dbo].[tblWRSplits] set [ChildQTY]=" & txtSplitQty.Text & " where [TransactionRef] = '" & TransRef.Text & "')", cn)
    '        If (cn.State = ConnectionState.Open) Then
    '            cn.Close()
    '        End If
    '        cn.Open()
    '        cmd.ExecuteNonQuery()
    '        cn.Close()
    '    End If
    '    fromEdit = False
    '    txtSplitQty.Text = ""
    '    LoadSplits()
    '    GetTotalandBal()
    '    '  Catch ex As Exception
    '    ' msgbox("Please select correct splits")
    '    ' End Try

    'End Sub
    Public Sub LoadSplits(ewrno As String)
        Dim dsport As New DataSet
        cmd = New SqlCommand("SELECT [ID],[TransactionRef], [WRChildSuffix],  [ChildQTY]   FROM [CDS].[dbo].[tblWRSplits]   where [OriginalWRNo] = '" & ewrno & " ' ", cn)
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
    Public Sub GetTotalandBal()
        Dim i As Integer
        Dim totalSplits As Decimal
        Dim splititem As Decimal
        Dim fullqty As Decimal

        '  fullqty = lblOGQty.Text
        For i = 0 To grdSplits.Rows.Count() - 1
            splititem = grdSplits.Rows(i).Cells(2).Text
            totalSplits = totalSplits + splititem
        Next
        'lblSplitTotal.Text = totalSplits
        'lblWRBal.Text = fullqty - totalSplits
    End Sub

    Protected Sub grdSplits_SelectedIndexChanged(sender As Object, e As EventArgs) Handles grdSplits.SelectedIndexChanged
        'fromEdit = True
        'txtSplitQty.Text = grdSplits.SelectedRow.Cells(2).Text
        'TransRef.Text = grdSplits.SelectedRow.Cells(0).Text
    End Sub

    Protected Sub ASPxButton13_Click(sender As Object, e As EventArgs) Handles ASPxButton13.Click

        cmd = New SqlCommand("Update [CDS].[dbo].[tblWRSplits] set State='R',Remarks='" & txtRemarks.Text & "' where [OriginalWRNo]='" & grdAvailableWRs.SelectedRow.Cells(0).Text & "'", cn)
        If (cn.State = ConnectionState.Open) Then
            cn.Close()
        End If
        cn.Open()
        cmd.ExecuteNonQuery()
        cn.Close()
        Session("finish") = "no"
        Response.Redirect(Request.RawUrl)
    End Sub
End Class
