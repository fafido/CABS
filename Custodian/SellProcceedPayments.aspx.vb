
Imports System.IO
Imports System.Net
Imports System.Xml

Partial Class Custodian_SellProcceedPayments
    Inherits System.Web.UI.Page
    Shared constr As String = (System.Configuration.ConfigurationManager.AppSettings("connpath"))
    Shared cn As New SqlConnection(constr)
    Dim adp As SqlDataAdapter
    Dim cmd As SqlCommand
    Dim ds As New DataSet
    Public password, numb, codec As String
    Dim dst As New DataSet
 
    Public Sub generateSSBfile()
        Dim csv As String = String.Empty
        Dim header, trailer, record As String

        Dim header_Header_ID, header_Process_Date, header_Sender_ID, header_Receiver_ID, header_File_ID, header_Work_Code, header_SFI_Version, header_Sender_Name, header_Receiver_Name, header_Package_Name As String
        header_Header_ID = String.Format("{0,-3}", "UHL")
        header_Process_Date = CDate(Date.UtcNow).ToString("yyyyMMdd")
        header_Sender_ID = String.Format("{0,-9}", "LICFIN")
        header_Receiver_ID = String.Format("{0,-9}", "CABS")
        header_File_ID = Format("test", "000000")
        header_Work_Code = String.Format("{0,-15}", "LOAN REPAYMENT")
        header_SFI_Version = Format(4, "000")
        header_Sender_Name = String.Format("{0,-30}", Session("Brokercode"))
        header_Receiver_Name = String.Format("{0,-30}", "")
        header_Package_Name = String.Format("{0,-30}", "CUSTODIAL")
        header = header_Header_ID & header_Process_Date & header_Sender_ID & header_Receiver_ID & header_File_ID & header_Work_Code & header_SFI_Version & header_Sender_Name & header_Receiver_Name & header_Package_Name

        Dim trailer_Trailer_ID, trailer_Currency_Code, trailer_Debit_Value, trailer_Credit_Value, trailer_Debit_Rec_Cnt, trailer_Credit_Rec_Cnt As String
        trailer_Trailer_ID = String.Format("{0,-3}", "UTL")
        trailer_Currency_Code = String.Format("{0,-3}", "USD")
        trailer_Credit_Value = Format(0, "000000000000000000000000")
        trailer_Credit_Rec_Cnt = Format(0, "000000")


        'sr.WriteLine(header)
        csv += header
        ' csv += vbCr & vbLf
        '  Try
        Dim cmd As SqlCommand
        Dim adp As SqlDataAdapter
        cmd = New SqlCommand("select  RANK() OVER (PARTITION BY cds_number ORDER BY cds_number ASC) AS id,sum(amount)*-1 as [PREMIUMAMT], (select top 1 div_branch from accounts_clients where cds_number=cashtrans.CDS_Number) as [Bankbranch],(select top 1 Div_AccountNo from accounts_clients where cds_number=cashtrans.CDS_Number) as [BankAccountNo] from CDSC.DBO.cashtrans where isnull(paid,0)='0' and transtype='withdraw' and cds_number in (select cds_number from accounts_clients where Custodian='" + Session("Brokercode") + "') and convert(date,datecreated)>='" + ddateFrom.Text + "' and convert(date, datecreated)<='" + ddto.Text + "' group by cds_number", cn)
        Dim ds As New DataSet
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "datas")
        If ds.Tables(0).Rows.Count > 0 Then
            Dim totRec As Integer = 0
            Dim totamt As Double = 0
            For Each dr As DataRow In ds.Tables(0).Rows
                Dim amt As Double = CDbl(dr.Item("PREMIUMAMT"))
                Dim record_Rec_Type, record_Dest_Sort, record_Dest_Account, record_Dest_Acc_Type, record_Dest_Curr_Code, record_Dest_Curr_Rate, record_Trans_Code, record_Orig_Sort, record_Orig_Account, record_Orig_Acc_Type, record_Orig_Curr_Code, record_Orig_Curr_Rate, record_Reference_1, record_Dest_Name, record_Amount, record_Amount_Curr_Code, record_Power_10, record_Process_Date, record_Unpaid_reason, record_Reference_2, record_Reference_3, record_Reference_4 As String
                record_Rec_Type = String.Format("{0,-3}", "PAY")
                record_Dest_Sort = String.Format("{0,7}", "CABS") 'Format(cmbBranch.SelectedValue, "0000000") ' selected branch
                record_Dest_Account = String.Format("{0,-20}", "10039080122") ' to enter account
                record_Dest_Acc_Type = String.Format("{0,-2}", "51") 'GET LIC ACCOUNT TYPE
                record_Dest_Curr_Code = String.Format("{0,-3}", "USD") ' GET LIC ACCOUNT CURRENCY CODE set to USD by default
                record_Dest_Curr_Rate = String.Format("{0,-24}", "") ' SET TO blank by default
                record_Trans_Code = String.Format("{0,-2}", "01") ' set to 01 by default
                record_Orig_Sort = String.Format("{0,-7}", dr.Item("BankBranch").ToString)
                record_Orig_Account = String.Format("{0,-20}", dr.Item("BankAccountNo").ToString)
                record_Orig_Acc_Type = String.Format("{0,-2}", "51") ' set to 01 by default
                record_Orig_Curr_Code = String.Format("{0,-3}", "USD") ' set to USD by default
                record_Orig_Curr_Rate = String.Format("{0,-24}", "") ' SET TO blank by default
                record_Reference_1 = Format(CLng(dr.Item("ID")), "000000000000000") 'String.Format("{0,-15}", dr.Item("ID").ToString) ' have set loan id
                record_Dest_Name = String.Format("{0,-30}", Session("Brokercode")) ' have set LIC FINANCE PVT LTD
                record_Amount = Format(amt, "000000000000000000000000")
                record_Amount_Curr_Code = String.Format("{0,-3}", "USD") ' set to USD by default
                record_Power_10 = String.Format("{0,-3}", "") ' SET TO blank by default
                record_Process_Date = CDate(ddateFrom.Text).ToString("yyyyMMdd")
                record_Unpaid_reason = ""
                record_Reference_2 = ""
                record_Reference_3 = ""
                record_Reference_4 = ""

                record = record_Rec_Type & record_Dest_Sort & record_Dest_Account & record_Dest_Acc_Type & record_Dest_Curr_Code & record_Dest_Curr_Rate & record_Trans_Code & record_Orig_Sort & record_Orig_Account & record_Orig_Acc_Type & record_Orig_Curr_Code & record_Orig_Curr_Rate & record_Reference_1 & record_Dest_Name & record_Amount & record_Amount_Curr_Code & record_Power_10 & record_Process_Date & record_Unpaid_reason & record_Reference_2 & record_Reference_3 & record_Reference_4
                csv += vbCr & vbLf
                csv += record
                totamt = totamt + amt
            Next

            markpaid()

            totRec = ds.Tables(0).Rows.Count

            trailer_Debit_Rec_Cnt = Format(totRec, "000000")
            trailer_Debit_Value = Format(totamt, "000000000000000000000000")
            trailer = trailer_Trailer_ID & trailer_Currency_Code & trailer_Debit_Value & trailer_Credit_Value & trailer_Debit_Rec_Cnt & trailer_Credit_Rec_Cnt
            csv += vbCr & vbLf
            csv += trailer
            csv += vbCr & vbLf

            'updateSentTOSSB(GetFileNo)
            Dim filenammm As String = Date.Now.ToString("yyyyMddms") & ".fin"
            Response.Clear()
            Response.Buffer = True
            Response.AddHeader("content-disposition", "attachment;filename*=UTF-8''" + Uri.EscapeDataString(filenammm))
            Response.Charset = ""
            Response.ContentType = "application/notepad"
            Response.Headers.Set(filenammm, filenammm)
            Response.Output.Write(csv)
            Response.Flush()
            Response.End()



        Else
            MsgBox("No Pending Payments")
            Exit Sub
        End If
        'Catch ex As Exception
        '    msgbox(ex.Message)
        'End Try
    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        generateSSBfile()

    End Sub
    Public Sub markpaid()
        cmd = New SqlCommand("update cdsc.dbo.cashtrans set paid='1' where convert(date,datecreated)>='" + ddateFrom.Text + "' and convert(date, datecreated)<='" + ddto.Text + "' and transtype='withdraw'", cn)
        cn.Open()
        cmd.ExecuteNonQuery()
        cn.Close()
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
End Class
