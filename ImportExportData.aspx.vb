Imports System.IO
Imports OfficeOpenXml

Partial Class Dealing_ImportExportData
    Inherits System.Web.UI.Page
    'Dim objFileImportExport As New ReadOrderFiles
    Dim str As String = (System.Configuration.ConfigurationManager.AppSettings("Connpath"))
    Dim cn As New SqlConnection(str)
    Dim cmd As SqlCommand
    Dim adp As SqlDataAdapter
    Dim strBCode As String
    'Dim objCommon As Common

    'Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    '    Dim ActionType As String
    '    If (Request.QueryString("Type").ToString() <> "") Then
    '        If (Not IsPostBack) Then
    '            ActionType = Request.QueryString("Type").ToString()

    '            If (ActionType = "import") Then
    '                cmdImport.Text = "Import Orders"
    '                'removed by shaju on 25/10/12
    '                ' popupTitle.Text = "Import Orders"
    '                plExport.Visible = False
    '                plImport.Visible = True

    '            Else
    '                'cmdImport.Text = "Export Deals"
    '                'removed by shaju on 25/10/12
    '                'popupTitle.Text = "Export Deals"
    '                plImport.Visible = False
    '                plExport.Visible = True
    '                txtDate.Text = Date.Today.ToString("MM/dd/yyyy")
    '            End If

    '        End If
    '    End If


    'End Sub
    'Public Sub msgbox(ByVal strMessage As String)
    '    'finishes server processing, returns to client.
    '    Dim strScript As String = "<script language=JavaScript>"
    '    strScript += "window.alert(""" & strMessage & """);"
    '    strScript += "</script>"
    '    Dim lbl As New System.Web.UI.WebControls.Label
    '    lbl.Text = strScript
    '    Page.Controls.Add(lbl)
    'End Sub
    'Protected Sub cmdImport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdImport.Click
    '    Dim strFilePath As String = Server.MapPath("~/temp/")
    '    Dim strFileName As String = ""
    '    Dim Note As String = ""
    '    objCommon = New Common()
    '    Try
    '        If txtFile.FileName = "" Then
    '            msgbox("Please select file name to import Orders")
    '            lblmsg.Text = ""
    '            Exit Sub
    '        End If
    '        Dim ext As String = System.IO.Path.GetExtension(txtFile.FileName)
    '        If ext = ".csv" Then
    '            strFileName = txtFile.PostedFile.FileName
    '            strFilePath = strFilePath & strFileName
    '            txtFile.PostedFile.SaveAs(strFilePath)
    '            TextFile(strFilePath)
    '            lblmsg.Visible = True
    '            'lblmsg.Text = "Orders Imported Successfully!"
    '            'objCommon.LogActivity(Convert.ToInt32(Session("Uid").ToString()), "Orders Imported", True)
    '        Else
    '            msgbox("Please select .csv files only")
    '            lblmsg.Text = ""
    '        End If
    '    Catch ex As Exception
    '        ' objCommon.ErrorLog("Error###: " & ex.ToString())
    '    Finally
    '        If File.Exists(strFilePath) Then
    '            File.Delete(strFilePath)
    '        End If
    '    End Try
    'End Sub
    'Public Sub TextFile(ByVal FILENAME As String)
    '    'objCommon = New Common()
    '    Dim Bp As String
    '    Dim note As String = ""
    '    Dim msg As String = ""
    '    Dim dtBestPriceop As New DataTable
    '    'Get a StreamReader class that can be used to read the file
    '    Dim objStreamReader As StreamReader = Nothing
    '    'Open a file for reading
    '    Try
    '        Dim strData As String, iDealNo As Long
    '        Dim strDataSQL As String, strQuery As String, strTransFlds As String = 0, strTransData As String
    '        Dim arr() As String
    '        Dim adp As SqlDataAdapter
    '        Dim cmd As SqlCommand
    '        Dim str As String = (System.Configuration.ConfigurationManager.AppSettings("connpath"))
    '        Dim cn As New SqlConnection(str)
    '        Dim strCreateDate As String
    '        Dim strBeginDate As String
    '        Dim strExpiryDate As String
    '        Dim strsql As String, iRows As Integer, szBannedCompanies As String
    '        'Dim oLT As New LiveTrading
    '        Dim rowno As Integer = 1
    '        Dim rownoout As String = ""
    '        Dim sucessrowcnt As Integer = 0


    '        Dim strcsvarray As String()

    '        szBannedCompanies = ""
    '        strsql = "SELECT Company FROM para_company where status=0 ORDER BY company"
    '        cmd = New SqlCommand(strsql, cn)
    '        Dim dt As New DataTable
    '        adp = New SqlDataAdapter(cmd)
    '        adp.Fill(dt)
    '        If (dt.Rows.Count > 0) Then
    '            For iRows = 0 To dt.Rows.Count - 1
    '                szBannedCompanies = szBannedCompanies & dt.Rows(iRows)("company") & ","
    '            Next
    '        End If

    '        Dim flag As Integer = 0
    '        'If oLT.GetSettings("Trading") = "Manual" Then flag = 1

    '        objStreamReader = File.OpenText(FILENAME)
    '        'Now, read the entire file into a string

    '        If flag = 1 Then
    '            strQuery = "Insert into Order_Posted (DealType,Company,SecurityType,CDS_AC_NO,Broker_Code,Client_Type,Tax,Shareholder,ClientName,TotalShareHolding,DealStatus,Create_date,Deal_Begin_Date,Expiry_Date,Quantity,BasePrice,AvailableShares,OrderPref) Values ("
    '            strTransFlds = "Insert into Orders_Trans (DealNo,SuffixNo,Quantity,BasePrice,Broker_Code,Company,Status) Values ("
    '        Else
    '            strQuery = "Insert into Order_Live (OrderType,Company,SecurityType," & _
    '                                                "Broker_Code,Tax,Shareholder,CDS_AC_NO,ClientName,TotalShareHolding," & _
    '                                                "Quantity,BasePrice,AvailableShares,OrderPref," & _
    '                                                "OrderQualifier,Marketboard,TimeInForce,OrderStatus,OrderAttribute," & _
    '                                                "OrderNumber,Create_date,Deal_Begin_Date,Expiry_Date,BrokerRef,ContraBrokerId,MaxPrice,MiniPrice,Flag_oldorder) Values ("
    '            'strQuery = "Insert into Order_Live (OrderType,Company,SecurityType,CDS_AC_NO,Broker_Code,Client_Type,Tax,Shareholder,ClientName,TotalShareHolding,OrderStatus,Create_date,Deal_Begin_Date,Expiry_Date,Quantity,BasePrice,AvailableShares,OrderPref,OrderAttribute) Values ("
    '            'strQuery = "Insert into Order_Live (OrderType,Company,SecurityType,CDS_AC_NO,Broker_Code,ClientName,Create_date,Deal_Begin_Date,Expiry_Date,Quantity,BasePrice,AvailableShares,OrderPref,OrderAttribute) Values ("
    '        End If
    '        cn.Open()
    '        While objStreamReader.Peek() <> -1


    '            'logic for manual import existing one - Added by Darshana on 03 Nov 2011
    '            If flag = 1 Then
    '                strData = objStreamReader.ReadLine()
    '                arr = Split(strData, vbTab)
    '                If InStr(szBannedCompanies, arr(1), CompareMethod.Text) = 0 Then
    '                    strCreateDate = Mid(arr(11), 3, 2) & "/" & Mid(arr(11), 1, 2) & "/" & Mid(arr(11), 5, 4)
    '                    strBeginDate = Mid(arr(12), 3, 2) & "/" & Mid(arr(12), 1, 2) & "/" & Mid(arr(12), 5, 4)
    '                    strExpiryDate = Mid(arr(13), 3, 2) & "/" & Mid(arr(13), 1, 2) & "/" & Mid(arr(13), 5, 4)
    '                    strDataSQL = strQuery & "'" & arr(0) & "','" & arr(1) & "','" & arr(2) & "','" & arr(3) & "','" & arr(4) & "','" & arr(5) & "'," & arr(6) & "," & arr(7) & ",'" & arr(8) & "'," & arr(9) & ",'" & IIf(arr(10) = "O", "OPEN", arr(10)) & "','" & strCreateDate & "','" & strBeginDate & "','" & strExpiryDate & "'," & arr(14) & "," & arr(15) & "," & arr(16) & ",'" & arr(17) & "Immediate/Cancel Order (IOC)" & "')"
    '                    cmd = New SqlCommand(strDataSQL, cn)
    '                    cmd.ExecuteNonQuery()

    '                    If flag = 1 Then
    '                        strsql = "SELECT TOP 1 DealNo FROM Order_Posted ORDER BY DEALNO DESC"
    '                        cmd = New SqlCommand(strsql, cn)
    '                        dt = New DataTable
    '                        adp = New SqlDataAdapter(cmd)
    '                        adp.Fill(dt)
    '                        If (dt.Rows.Count > 0) Then
    '                            iDealNo = dt.Rows(0)("DealNo")
    '                        End If

    '                        strTransData = strTransFlds & iDealNo & ",1," & arr(14) & "," & arr(15) & ",'" & arr(3) & "','" & arr(1) & "','OPEN')"
    '                        cmd = New SqlCommand(strTransData, cn)
    '                        cmd.ExecuteNonQuery()
    '                    End If
    '                End If
    '            ElseIf flag = 0 Then
    '                ' New logic of import for Amtomated as per new csv file 
    '                Dim sline As String = "OrderNumber"
    '                strData = objStreamReader.ReadLine()

    '                strcsvarray = strData.Split(",")

    '                If (strcsvarray(2) <> "") Then

    '                    If (Not strData.Contains(sline)) And strData <> "" Then
    '                        rowno = rowno + 1
    '                        'Dim iIndxOrdType As Integer = 0
    '                        'Dim iIndxComp As Integer = iIndxOrdType + 4
    '                        'Dim iIndxSecType As Integer = iIndxComp + 6
    '                        'Dim iIndxBroCode As Integer = iIndxSecType + 1
    '                        'Dim iIndxTax As Integer = iIndxBroCode + 8
    '                        'Dim iIndxCdxAcNo As Integer = iIndxTax + 2
    '                        'Dim iIndxClientName As Integer = iIndxCdxAcNo + 13
    '                        'Dim iIndxQty As Integer = iIndxClientName + 30
    '                        'Dim iIndxBasePrice As Integer = iIndxQty + 9
    '                        'Dim iIndxOrdPref As Integer = iIndxBasePrice + 12
    '                        'Dim iIndxOrdQual As Integer = iIndxOrdPref + 1
    '                        'Dim iIndxOrdTIF As Integer = iIndxOrdQual + 3
    '                        'Dim iIndxCreateDate As Integer = iIndxOrdTIF + 3
    '                        'Dim iIndxBegDate As Integer = iIndxCreateDate + 10
    '                        'Dim iIndxExpDate As Integer = iIndxBegDate + 10

    '                        Dim strOrderPref As String = String.Empty
    '                        Dim strOrderQualifier As String = String.Empty
    '                        Dim strTimeInForce As String = String.Empty
    '                        Dim iArrShares(2) As Integer

    '                        If strcsvarray(10).ToUpper.Trim() = "M" Then
    '                            strOrderPref = "M"
    '                        ElseIf strcsvarray(10).ToUpper.Trim() = "L" Then
    '                            strOrderPref = "L"
    '                        End If

    '                        If strcsvarray(11).ToUpper.Trim() = "IOC" Then
    '                            strOrderQualifier = "Immediate/Cancel Order (IOC)"
    '                        End If

    '                        If strcsvarray(12).ToUpper.Trim() = "DO" Or strcsvarray(12).ToUpper.Trim() = "" Then
    '                            strTimeInForce = "Day Order (DO)"
    '                        ElseIf strcsvarray(12).ToUpper.Trim() = "GTC" Then
    '                            strTimeInForce = "Good Till Cancelled (GTC)"
    '                        ElseIf strcsvarray(12).ToUpper.Trim() = "GTD" Then
    '                            strTimeInForce = "Good Till Day (GTD)"
    '                        End If


    '                        Dim Parbestprice As String(,) = {{"@Company", strcsvarray(2).Trim()}, {"@BestPrice", Convert.ToDecimal(strcsvarray(9).Trim())}}
    '                        dtBestPriceop = objCommon.GetDataTableFromSP("sp_ValidBestPrice", Parbestprice)
    '                        Bp = dtBestPriceop.Rows(0)("BestPriceop")

    '                        If Bp = "ValidBpRange" Then

    '                            iArrShares = AvaliableShares(strcsvarray(1), Convert.ToInt32(strcsvarray(8).Trim()), strcsvarray(6).Trim(), strcsvarray(2).Trim())
    '                            strDataSQL = strQuery & "'" & strcsvarray(1) & "','" & _
    '                                                          strcsvarray(2) & "','" & _
    '                                                          IIf(strcsvarray(3) = "B", "BONDS", "EQUITY") & "','" & _
    '                                                          strcsvarray(4) & "','" & _
    '                                                          strcsvarray(5) & "','" & _
    '                                                          strcsvarray(6) & "','" & _
    '                                                          strcsvarray(6) & "','" & _
    '                                                          strcsvarray(7) & "','" & _
    '                                                          iArrShares(1) & "'," & _
    '                                                          strcsvarray(8) & ",'" & _
    '                                                          strcsvarray(9) & "'," & _
    '                                                          iArrShares(0) & ",'" & _
    '                                                          strOrderPref & "','" & _
    '                                                          strOrderQualifier & "','" & _
    '                                                          "Normal Board','" & _
    '                                                          strTimeInForce & "','" & _
    '                                                          "OPEN','','" & _
    '                                                          strcsvarray(0) & "','" & _
    '                                                          strcsvarray(13) & "','" & _
    '                                                          strcsvarray(14) & " " & TimeOfDay & "','" & _
    '                                                          strcsvarray(15) & " " & TimeOfDay & "','" & _
    '                                                          FetchBrokerRef(strcsvarray(4)) & "','" & _
    '                                                          "NONE',0,0,0)"

    '                            If strcsvarray(1) = "SELL" Then
    '                                strDataSQL &= "; Update mast Set shares = " & iArrShares(0) & " where CDS_Number='" & strcsvarray(6) & "' and company='" & strcsvarray(2) & "'"
    '                            End If
    '                            cmd = New SqlCommand(strDataSQL, cn)
    '                            cmd.ExecuteNonQuery()
    '                            sucessrowcnt = sucessrowcnt + 1
    '                        Else
    '                            If rownoout = "" Then
    '                                rownoout = rowno
    '                            Else
    '                                rownoout = rownoout + " ," + rowno.ToString()
    '                            End If
    '                        End If
    '                    End If
    '                End If
    '            End If
    '        End While
    '        cn.Close()
    '        If rownoout <> "" Then
    '            lblmsg.Text = sucessrowcnt.ToString() + " Orders Imported Successfully!" + " Row numbers : " + rownoout + " Not imported (BasePrice Should Not Greater & Less Than Protection Price !)"
    '        Else
    '            lblmsg.Text = "Orders Imported Successfully!"
    '        End If
    '    Catch ex As Exception
    '        objCommon.ErrorLog("Error###: " & ex.ToString())
    '    Finally
    '        objStreamReader.Close()
    '        objStreamReader = Nothing
    '    End Try
    'End Sub
    ' '''''WITH RANK '''''''''''''''
    ''Public Sub TextFile(ByVal FILENAME As String)
    ''    objCommon = New Common()
    ''    Dim Bp As String
    ''    Dim note As String = ""
    ''    Dim msg As String = ""
    ''    Dim dtBestPriceop As New DataTable
    ''    'Get a StreamReader class that can be used to read the file
    ''    Dim objStreamReader As StreamReader = Nothing
    ''    'Open a file for reading
    ''    Try
    ''        Dim strData As String, iDealNo As Long
    ''        Dim strDataSQL As String, strQuery As String, strTransFlds As String = 0, strTransData As String
    ''        Dim arr() As String
    ''        Dim adp As SqlDataAdapter
    ''        Dim cmd As SqlCommand
    ''        Dim str As String = (System.Configuration.ConfigurationManager.AppSettings("connpath"))
    ''        Dim cn As New SqlConnection(str)
    ''        Dim strCreateDate As String
    ''        Dim strBeginDate As String
    ''        Dim strExpiryDate As String
    ''        Dim strsql As String, iRows As Integer, szBannedCompanies As String
    ''        Dim oLT As New LiveTrading
    ''        Dim rowno As Integer = 1
    ''        Dim rownoout As String = ""
    ''        Dim sucessrowcnt As Integer = 0


    ''        Dim strcsvarray As String()

    ''        szBannedCompanies = ""
    ''        strsql = "SELECT Company FROM para_company where status=0 ORDER BY company"
    ''        cmd = New SqlCommand(strsql, cn)
    ''        Dim dt As New DataTable
    ''        adp = New SqlDataAdapter(cmd)
    ''        adp.Fill(dt)
    ''        If (dt.Rows.Count > 0) Then
    ''            For iRows = 0 To dt.Rows.Count - 1
    ''                szBannedCompanies = szBannedCompanies & dt.Rows(iRows)("company") & ","
    ''            Next
    ''        End If

    ''        Dim flag As Integer = 0
    ''        If oLT.GetSettings("Trading") = "Manual" Then flag = 1

    ''        objStreamReader = File.OpenText(FILENAME)
    ''        'Now, read the entire file into a string

    ''        If flag = 1 Then
    ''            strQuery = "Insert into Order_Posted (DealType,Company,SecurityType,CDS_AC_NO,Broker_Code,Client_Type,Tax,Shareholder,ClientName,TotalShareHolding,DealStatus,Create_date,Deal_Begin_Date,Expiry_Date,Quantity,BasePrice,AvailableShares,OrderPref) Values ("
    ''            strTransFlds = "Insert into Orders_Trans (DealNo,SuffixNo,Quantity,BasePrice,Broker_Code,Company,Status) Values ("
    ''        Else
    ''            strQuery = "Insert into Order_Live (OrderType,Company,SecurityType," & _
    ''                                                "Broker_Code,Tax,Shareholder,CDS_AC_NO,ClientName,TotalShareHolding," & _
    ''                                                "Quantity,BasePrice,AvailableShares,OrderPref," & _
    ''                                                "OrderQualifier,Marketboard,TimeInForce,OrderStatus,OrderAttribute," & _
    ''                                                "OrderNumber,Create_date,Deal_Begin_Date,Expiry_Date,BrokerRef,ContraBrokerId,MaxPrice,MiniPrice,Flag_oldorder) Values ("
    ''            'strQuery = "Insert into Order_Live (OrderType,Company,SecurityType,CDS_AC_NO,Broker_Code,Client_Type,Tax,Shareholder,ClientName,TotalShareHolding,OrderStatus,Create_date,Deal_Begin_Date,Expiry_Date,Quantity,BasePrice,AvailableShares,OrderPref,OrderAttribute) Values ("
    ''            'strQuery = "Insert into Order_Live (OrderType,Company,SecurityType,CDS_AC_NO,Broker_Code,ClientName,Create_date,Deal_Begin_Date,Expiry_Date,Quantity,BasePrice,AvailableShares,OrderPref,OrderAttribute) Values ("
    ''        End If
    ''        cn.Open()
    ''        While objStreamReader.Peek() <> -1


    ''            'logic for manual import existing one - Added by Darshana on 03 Nov 2011
    ''            If flag = 1 Then
    ''                strData = objStreamReader.ReadLine()
    ''                arr = Split(strData, vbTab)
    ''                If InStr(szBannedCompanies, arr(1), CompareMethod.Text) = 0 Then
    ''                    strCreateDate = Mid(arr(11), 3, 2) & "/" & Mid(arr(11), 1, 2) & "/" & Mid(arr(11), 5, 4)
    ''                    strBeginDate = Mid(arr(12), 3, 2) & "/" & Mid(arr(12), 1, 2) & "/" & Mid(arr(12), 5, 4)
    ''                    strExpiryDate = Mid(arr(13), 3, 2) & "/" & Mid(arr(13), 1, 2) & "/" & Mid(arr(13), 5, 4)
    ''                    strDataSQL = strQuery & "'" & arr(0) & "','" & arr(1) & "','" & arr(2) & "','" & arr(3) & "','" & arr(4) & "','" & arr(5) & "'," & arr(6) & "," & arr(7) & ",'" & arr(8) & "'," & arr(9) & ",'" & IIf(arr(10) = "O", "OPEN", arr(10)) & "','" & strCreateDate & "','" & strBeginDate & "','" & strExpiryDate & "'," & arr(14) & "," & arr(15) & "," & arr(16) & ",'" & arr(17) & "Immediate/Cancel Order (IOC)" & "')"
    ''                    cmd = New SqlCommand(strDataSQL, cn)
    ''                    cmd.ExecuteNonQuery()

    ''                    If flag = 1 Then
    ''                        strsql = "SELECT TOP 1 DealNo FROM Order_Posted ORDER BY DEALNO DESC"
    ''                        cmd = New SqlCommand(strsql, cn)
    ''                        dt = New DataTable
    ''                        adp = New SqlDataAdapter(cmd)
    ''                        adp.Fill(dt)
    ''                        If (dt.Rows.Count > 0) Then
    ''                            iDealNo = dt.Rows(0)("DealNo")
    ''                        End If

    ''                        strTransData = strTransFlds & iDealNo & ",1," & arr(14) & "," & arr(15) & ",'" & arr(3) & "','" & arr(1) & "','OPEN')"
    ''                        cmd = New SqlCommand(strTransData, cn)
    ''                        cmd.ExecuteNonQuery()
    ''                    End If
    ''                End If
    ''            ElseIf flag = 0 Then
    ''                ' New logic of import for Amtomated as per new csv file 
    ''                Dim sline As String = "Rank"
    ''                strData = objStreamReader.ReadLine()

    ''                strcsvarray = strData.Split(",")

    ''                If (strcsvarray(3) <> "") Then

    ''                    If (Not strData.Contains(sline)) And strData <> "" Then
    ''                        rowno = rowno + 1
    ''                        'Dim iIndxOrdType As Integer = 0
    ''                        'Dim iIndxComp As Integer = iIndxOrdType + 4
    ''                        'Dim iIndxSecType As Integer = iIndxComp + 6
    ''                        'Dim iIndxBroCode As Integer = iIndxSecType + 1
    ''                        'Dim iIndxTax As Integer = iIndxBroCode + 8
    ''                        'Dim iIndxCdxAcNo As Integer = iIndxTax + 2
    ''                        'Dim iIndxClientName As Integer = iIndxCdxAcNo + 13
    ''                        'Dim iIndxQty As Integer = iIndxClientName + 30
    ''                        'Dim iIndxBasePrice As Integer = iIndxQty + 9
    ''                        'Dim iIndxOrdPref As Integer = iIndxBasePrice + 12
    ''                        'Dim iIndxOrdQual As Integer = iIndxOrdPref + 1
    ''                        'Dim iIndxOrdTIF As Integer = iIndxOrdQual + 3
    ''                        'Dim iIndxCreateDate As Integer = iIndxOrdTIF + 3
    ''                        'Dim iIndxBegDate As Integer = iIndxCreateDate + 10
    ''                        'Dim iIndxExpDate As Integer = iIndxBegDate + 10

    ''                        Dim strOrderPref As String = String.Empty
    ''                        Dim strOrderQualifier As String = String.Empty
    ''                        Dim strTimeInForce As String = String.Empty
    ''                        Dim iArrShares(2) As Integer

    ''                        If strcsvarray(11).ToUpper.Trim() = "M" Then
    ''                            strOrderPref = "M"
    ''                        ElseIf strcsvarray(11).ToUpper.Trim() = "L" Then
    ''                            strOrderPref = "L"
    ''                        End If

    ''                        If strcsvarray(12).ToUpper.Trim() = "IOC" Then
    ''                            strOrderQualifier = "Immediate/Cancel Order (IOC)"
    ''                        End If

    ''                        If strcsvarray(13).ToUpper.Trim() = "DO" Or strcsvarray(0).ToUpper.Trim() = "" Then
    ''                            strTimeInForce = "Day Order (DO)"
    ''                        ElseIf strcsvarray(13).ToUpper.Trim() = "GTC" Then
    ''                            strTimeInForce = "Good Till Cancelled (GTC)"
    ''                        ElseIf strcsvarray(13).ToUpper.Trim() = "GTD" Then
    ''                            strTimeInForce = "Good Till Day (GTD)"
    ''                        End If


    ''                        Dim Parbestprice As String(,) = {{"@Company", strcsvarray(3).Trim()}, {"@BestPrice", Convert.ToDecimal(strcsvarray(10).Trim())}}
    ''                        dtBestPriceop = objCommon.GetDataTableFromSP("sp_ValidBestPrice", Parbestprice)
    ''                        Bp = dtBestPriceop.Rows(0)("BestPriceop")

    ''                        If Bp = "ValidBpRange" Then

    ''                            iArrShares = AvaliableShares(strcsvarray(2), Convert.ToInt32(strcsvarray(9).Trim()), strcsvarray(7).Trim(), strcsvarray(3).Trim())
    ''                            strDataSQL = strQuery & "'" & strcsvarray(2) & "','" & _
    ''                                                          strcsvarray(3) & "','" & _
    ''                                                          IIf(strcsvarray(4) = "B", "BONDS", "EQUITY") & "','" & _
    ''                                                          strcsvarray(5) & "','" & _
    ''                                                          strcsvarray(6) & "','" & _
    ''                                                          strcsvarray(7) & "','" & _
    ''                                                          strcsvarray(7) & "','" & _
    ''                                                          strcsvarray(8) & "','" & _
    ''                                                          iArrShares(1) & "'," & _
    ''                                                          strcsvarray(9) & ",'" & _
    ''                                                          strcsvarray(10) & "'," & _
    ''                                                          iArrShares(0) & ",'" & _
    ''                                                          strOrderPref & "','" & _
    ''                                                          strOrderQualifier & "','" & _
    ''                                                          "Normal Board','" & _
    ''                                                          strTimeInForce & "','" & _
    ''                                                          "OPEN','','" & _
    ''                                                          strcsvarray(1) & "','" & _
    ''                                                          strcsvarray(14) & "','" & _
    ''                                                          strcsvarray(15) & " " & TimeOfDay & "','" & _
    ''                                                          strcsvarray(16) & " " & TimeOfDay & "','" & _
    ''                                                          FetchBrokerRef(strcsvarray(5)) & "','" & _
    ''                                                          "NONE',0,0,0)"

    ''                            If strcsvarray(2) = "SELL" Then
    ''                                strDataSQL &= "; Update mast Set shares = " & iArrShares(0) & " where CDS_Number='" & strcsvarray(7) & "' and company='" & strcsvarray(3) & "'"
    ''                            End If
    ''                            cmd = New SqlCommand(strDataSQL, cn)
    ''                            cmd.ExecuteNonQuery()
    ''                            sucessrowcnt = sucessrowcnt + 1
    ''                        Else
    ''                            If rownoout = "" Then
    ''                                rownoout = rowno
    ''                            Else
    ''                                rownoout = rownoout + " ," + rowno.ToString()
    ''                            End If
    ''                        End If
    ''                    End If
    ''                End If
    ''                End If
    ''        End While
    ''        cn.Close()
    ''        If rownoout <> "" Then
    ''            lblmsg.Text = sucessrowcnt.ToString() + " Orders Imported Successfully!" + " Row numbers : " + rownoout + " Not imported (BasePrice Should Not Greater & Less Than Protection Price !)"
    ''        Else
    ''            lblmsg.Text = "Orders Imported Successfully!"
    ''        End If
    ''    Catch ex As Exception
    ''        objCommon.ErrorLog("Error###: " & ex.ToString())
    ''    Finally
    ''        objStreamReader.Close()
    ''        objStreamReader = Nothing
    ''    End Try
    ''End Sub

    ''Public Sub TextFile(ByVal FILENAME As String)
    ''    objCommon = New Common()
    ''    Dim Bp As String
    ''    Dim note As String = ""
    ''    Dim msg As String = ""
    ''    Dim dtBestPriceop As New DataTable
    ''    'Get a StreamReader class that can be used to read the file
    ''    Dim objStreamReader As StreamReader = Nothing
    ''    'Open a file for reading
    ''    Try
    ''        Dim strData As String, iDealNo As Long
    ''        Dim strDataSQL As String, strQuery As String, strTransFlds As String = 0, strTransData As String
    ''        Dim arr() As String
    ''        Dim adp As SqlDataAdapter
    ''        Dim cmd As SqlCommand
    ''        Dim str As String = (System.Configuration.ConfigurationManager.AppSettings("connpath"))
    ''        Dim cn As New SqlConnection(str)
    ''        Dim strCreateDate As String
    ''        Dim strBeginDate As String
    ''        Dim strExpiryDate As String
    ''        Dim strsql As String, iRows As Integer, szBannedCompanies As String
    ''        Dim oLT As New LiveTrading
    ''        Dim rowno As Integer = 1
    ''        Dim rownoout As String = ""
    ''        Dim sucessrowcnt As Integer = 0
    ''        szBannedCompanies = ""
    ''        strsql = "SELECT Company FROM para_company where status=0 ORDER BY company"
    ''        cmd = New SqlCommand(strsql, cn)
    ''        Dim dt As New DataTable
    ''        adp = New SqlDataAdapter(cmd)
    ''        adp.Fill(dt)
    ''        If (dt.Rows.Count > 0) Then
    ''            For iRows = 0 To dt.Rows.Count - 1
    ''                szBannedCompanies = szBannedCompanies & dt.Rows(iRows)("company") & ","
    ''            Next
    ''        End If

    ''        Dim flag As Integer = 0
    ''        If oLT.GetSettings("Trading") = "Manual" Then flag = 1

    ''        objStreamReader = File.OpenText(FILENAME)
    ''        'Now, read the entire file into a string

    ''        If flag = 1 Then
    ''            strQuery = "Insert into Order_Posted (DealType,Company,SecurityType,CDS_AC_NO,Broker_Code,Client_Type,Tax,Shareholder,ClientName,TotalShareHolding,DealStatus,Create_date,Deal_Begin_Date,Expiry_Date,Quantity,BasePrice,AvailableShares,OrderPref) Values ("
    ''            strTransFlds = "Insert into Orders_Trans (DealNo,SuffixNo,Quantity,BasePrice,Broker_Code,Company,Status) Values ("
    ''        Else
    ''            strQuery = "Insert into Order_Live (OrderType,Company,SecurityType," & _
    ''                                                "Broker_Code,Tax,Shareholder,CDS_AC_NO,ClientName,TotalShareHolding," & _
    ''                                                "Quantity,BasePrice,AvailableShares,OrderPref," & _
    ''                                                "OrderQualifier,Marketboard,TimeInForce,OrderStatus,OrderAttribute," & _
    ''                                                "Create_date,Deal_Begin_Date,Expiry_Date,BrokerRef,ContraBrokerId,MaxPrice,MiniPrice,Flag_oldorder) Values ("
    ''            'strQuery = "Insert into Order_Live (OrderType,Company,SecurityType,CDS_AC_NO,Broker_Code,Client_Type,Tax,Shareholder,ClientName,TotalShareHolding,OrderStatus,Create_date,Deal_Begin_Date,Expiry_Date,Quantity,BasePrice,AvailableShares,OrderPref,OrderAttribute) Values ("
    ''            'strQuery = "Insert into Order_Live (OrderType,Company,SecurityType,CDS_AC_NO,Broker_Code,ClientName,Create_date,Deal_Begin_Date,Expiry_Date,Quantity,BasePrice,AvailableShares,OrderPref,OrderAttribute) Values ("
    ''        End If
    ''        cn.Open()
    ''        While objStreamReader.Peek() <> -1


    ''            'logic for manual import existing one - Added by Darshana on 03 Nov 2011
    ''            If flag = 1 Then
    ''                strData = objStreamReader.ReadLine()
    ''                arr = Split(strData, vbTab)
    ''                If InStr(szBannedCompanies, arr(1), CompareMethod.Text) = 0 Then
    ''                    strCreateDate = Mid(arr(11), 3, 2) & "/" & Mid(arr(11), 1, 2) & "/" & Mid(arr(11), 5, 4)
    ''                    strBeginDate = Mid(arr(12), 3, 2) & "/" & Mid(arr(12), 1, 2) & "/" & Mid(arr(12), 5, 4)
    ''                    strExpiryDate = Mid(arr(13), 3, 2) & "/" & Mid(arr(13), 1, 2) & "/" & Mid(arr(13), 5, 4)
    ''                    strDataSQL = strQuery & "'" & arr(0) & "','" & arr(1) & "','" & arr(2) & "','" & arr(3) & "','" & arr(4) & "','" & arr(5) & "'," & arr(6) & "," & arr(7) & ",'" & arr(8) & "'," & arr(9) & ",'" & IIf(arr(10) = "O", "OPEN", arr(10)) & "','" & strCreateDate & "','" & strBeginDate & "','" & strExpiryDate & "'," & arr(14) & "," & arr(15) & "," & arr(16) & ",'" & arr(17) & "Immediate/Cancel Order (IOC)" & "')"
    ''                    cmd = New SqlCommand(strDataSQL, cn)
    ''                    cmd.ExecuteNonQuery()

    ''                    If flag = 1 Then
    ''                        strsql = "SELECT TOP 1 DealNo FROM Order_Posted ORDER BY DEALNO DESC"
    ''                        cmd = New SqlCommand(strsql, cn)
    ''                        dt = New DataTable
    ''                        adp = New SqlDataAdapter(cmd)
    ''                        adp.Fill(dt)
    ''                        If (dt.Rows.Count > 0) Then
    ''                            iDealNo = dt.Rows(0)("DealNo")
    ''                        End If

    ''                        strTransData = strTransFlds & iDealNo & ",1," & arr(14) & "," & arr(15) & ",'" & arr(3) & "','" & arr(1) & "','OPEN')"
    ''                        cmd = New SqlCommand(strTransData, cn)
    ''                        cmd.ExecuteNonQuery()
    ''                    End If
    ''                End If
    ''            ElseIf flag = 0 Then
    ''                ' New logic of import for Amtomated as per new csv file 
    ''                Dim sline As String = "ORDER FILE"
    ''                strData = objStreamReader.ReadLine()
    ''                If (Not strData.Contains(sline)) And strData <> "" Then
    ''                    rowno = rowno + 1
    ''                    Dim iIndxOrdType As Integer = 0
    ''                    Dim iIndxComp As Integer = iIndxOrdType + 4
    ''                    Dim iIndxSecType As Integer = iIndxComp + 6
    ''                    Dim iIndxBroCode As Integer = iIndxSecType + 1
    ''                    Dim iIndxTax As Integer = iIndxBroCode + 8
    ''                    Dim iIndxCdxAcNo As Integer = iIndxTax + 2
    ''                    Dim iIndxClientName As Integer = iIndxCdxAcNo + 13
    ''                    Dim iIndxQty As Integer = iIndxClientName + 30
    ''                    Dim iIndxBasePrice As Integer = iIndxQty + 9
    ''                    Dim iIndxOrdPref As Integer = iIndxBasePrice + 12
    ''                    Dim iIndxOrdQual As Integer = iIndxOrdPref + 1
    ''                    Dim iIndxOrdTIF As Integer = iIndxOrdQual + 3
    ''                    Dim iIndxCreateDate As Integer = iIndxOrdTIF + 3
    ''                    Dim iIndxBegDate As Integer = iIndxCreateDate + 10
    ''                    Dim iIndxExpDate As Integer = iIndxBegDate + 10

    ''                    Dim strOrderPref As String = String.Empty
    ''                    Dim strOrderQualifier As String = String.Empty
    ''                    Dim strTimeInForce As String = String.Empty
    ''                    Dim iArrShares(2) As Integer

    ''                    If strData.Substring(iIndxOrdPref, 1).ToUpper.Trim() = "M" Then
    ''                        strOrderPref = "M"
    ''                    ElseIf strData.Substring(iIndxOrdPref, 1).ToUpper.Trim() = "L" Then
    ''                        strOrderPref = "L"
    ''                    End If

    ''                    If strData.Substring(iIndxOrdQual, 3).ToUpper.Trim() = "IOC" Then
    ''                        strOrderQualifier = "Immediate/Cancel Order (IOC)"
    ''                    End If

    ''                    If strData.Substring(iIndxOrdTIF, 3).ToUpper.Trim() = "DO" Or strData.Substring(iIndxOrdTIF, 3).ToUpper.Trim() = "" Then
    ''                        strTimeInForce = "Day Order (DO)"
    ''                    ElseIf strData.Substring(iIndxOrdTIF, 3).ToUpper.Trim() = "GTC" Then
    ''                        strTimeInForce = "Good Till Cancelled (GTC)"
    ''                    ElseIf strData.Substring(iIndxOrdTIF, 3).ToUpper.Trim() = "GTD" Then
    ''                        strTimeInForce = "Good Till Day (GTD)"
    ''                    End If


    ''                    Dim Parbestprice As String(,) = {{"@Company", strData.Substring(iIndxComp, 6).Trim()}, {"@BestPrice", Convert.ToDecimal(strData.Substring(iIndxBasePrice, 12).Trim())}}
    ''                    dtBestPriceop = objCommon.GetDataTableFromSP("sp_ValidBestPrice", Parbestprice)
    ''                    Bp = dtBestPriceop.Rows(0)("BestPriceop")

    ''                    If Bp = "ValidBpRange" Then

    ''                        iArrShares = AvaliableShares(strData.Substring(iIndxOrdType, 4).Trim(), Convert.ToInt32(strData.Substring(iIndxQty, 6).Trim()), strData.Substring(iIndxCdxAcNo, 13).Trim(), strData.Substring(iIndxComp, 6).Trim())
    ''                        strDataSQL = strQuery & "'" & strData.Substring(iIndxOrdType, 4).Trim() & "','" & _
    ''                                                      strData.Substring(iIndxComp, 6).Trim() & "','" & _
    ''                                                      IIf(strData.Substring(iIndxSecType, 1).Trim() = "B", "BONDS", "EQUITY") & "','" & _
    ''                                                      strData.Substring(iIndxBroCode, 8).Trim() & "','" & _
    ''                                                      strData.Substring(iIndxTax, 2).Trim() & "','" & _
    ''                                                      strData.Substring(iIndxCdxAcNo, 13).Trim() & "','" & _
    ''                                                      strData.Substring(iIndxCdxAcNo, 13).Trim() & "','" & _
    ''                                                      strData.Substring(iIndxClientName, 30).Trim() & "'," & _
    ''                                                      iArrShares(1) & "," & _
    ''                                                      strData.Substring(iIndxQty, 6).Trim() & ",'" & _
    ''                                                      strData.Substring(iIndxBasePrice, 12).Trim() & "'," & _
    ''                                                      iArrShares(0) & ",'" & _
    ''                                                      strOrderPref & "','" & _
    ''                                                      strOrderQualifier & "','" & _
    ''                                                      "Normal Board','" & _
    ''                                                      strTimeInForce & "','" & _
    ''                                                      "OPEN','','" & _
    ''                                                      strData.Substring(iIndxCreateDate, 10).Trim() & " " & TimeOfDay & "','" & _
    ''                                                      strData.Substring(iIndxBegDate, 10).Trim() & " " & TimeOfDay & "','" & _
    ''                                                      strData.Substring(iIndxExpDate, 10).Trim() & " " & TimeOfDay & "','" & _
    ''                                                      FetchBrokerRef(strData.Substring(iIndxBroCode, 8).Trim()) & "','" & _
    ''                                                      "NONE',0,0,0)"

    ''                        If strData.Substring(iIndxOrdType, 4).Trim() = "SELL" Then
    ''                            strDataSQL &= "; Update mast Set shares = " & iArrShares(0) & " where CDS_Number='" & strData.Substring(iIndxCdxAcNo, 13).Trim() & "' and company='" & strData.Substring(iIndxComp, 6).Trim() & "'"
    ''                        End If
    ''                        cmd = New SqlCommand(strDataSQL, cn)
    ''                        cmd.ExecuteNonQuery()
    ''                        sucessrowcnt = sucessrowcnt + 1
    ''                    Else
    ''                        If rownoout = "" Then
    ''                            rownoout = rowno
    ''                        Else
    ''                            rownoout = rownoout + " ," + rowno.ToString()
    ''                        End If
    ''                    End If
    ''                End If
    ''            End If
    ''        End While
    ''        cn.Close()
    ''        If rownoout <> "" Then
    ''            lblmsg.Text = sucessrowcnt.ToString() + " Orders Imported Successfully!" + " Row numbers : " + rownoout + " Not imported (BasePrice Should Not Greater & Less Than Protection Price !)"
    ''        Else
    ''            lblmsg.Text = "Orders Imported Successfully!"
    ''        End If
    ''    Catch ex As Exception
    ''        objCommon.ErrorLog("Error###: " & ex.ToString())
    ''    Finally
    ''        objStreamReader.Close()
    ''        objStreamReader = Nothing
    ''    End Try
    ''End Sub
    'Public Function FetchBrokerRef(ByVal BrokerCode As String) As String
    '    Dim strsql As String
    '    'Dim objCommon As New Common
    '    Dim strBrokerRef As String = ""
    '    Try
    '        strsql = "Select ISNULL(MAX(OrderNo),0) + 1 As OrderNo from Order_Live"
    '        Dim dt As New DataTable
    '        dt = objCommon.SelectRows(strsql)
    '        If (dt.Rows.Count > 0) Then
    '            strBrokerRef = BrokerCode & "ord" & dt.Rows(0)("OrderNo").ToString()
    '        End If
    '    Catch ex As Exception
    '        objCommon.ErrorLog("Error###: " & ex.ToString())
    '    End Try
    '    Return strBrokerRef
    'End Function
    'Public Function AvaliableShares(ByVal OderType As String, ByVal Qty As Integer, ByVal CDSNo As String, ByVal Company As String) As Integer()
    '    Dim strsql As String
    '    'Dim objCommon As New Common
    '    Dim iAvalShares As Integer = 0
    '    Dim itotalShares As Integer = 0
    '    Dim Shares(2) As Integer
    '    Try
    '        strsql = "Select * from mast where CDS_Number= '" & CDSNo & "' and company='" & Company & "'"
    '        Dim dt As New DataTable
    '        dt = objCommon.SelectRows(strsql)
    '        If (dt.Rows.Count > 0) Then
    '            If OderType = "SELL" Then
    '                iAvalShares = Convert.ToInt32(dt.Rows(0)("shares").ToString()) - Qty
    '                itotalShares = Convert.ToInt32(dt.Rows(0)("shares").ToString())
    '                Shares(0) = iAvalShares
    '                Shares(1) = itotalShares
    '            Else
    '                iAvalShares = Convert.ToInt32(dt.Rows(0)("shares").ToString())
    '                itotalShares = 0
    '                Shares(0) = iAvalShares
    '                Shares(1) = itotalShares
    '            End If
    '        End If
    '    Catch ex As Exception
    '        objCommon.ErrorLog("Error###: " & ex.ToString())
    '    End Try
    '    Return Shares
    'End Function
    ''Protected Sub cmdExportDeals_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdExportDeals.Click
    ''    Dim objCommon As New Common()
    ''    Dim dt As New DataTable
    ''    Dim strsql As String = ""
    ''    Dim strFilePath As String = ""
    ''    Try
    ''        If Convert.ToString(Session("UserType")).ToUpper() = "BROKER" Then
    ''            strFilePath = Server.MapPath("..\temp\")
    ''            strsql = "SELECT BROKER_CODE FROM BrokerLogin WHERE USERNAME='" & System.Web.HttpContext.Current.Session("username").ToString() & "'"
    ''            dt = objCommon.SelectRows(strsql)
    ''            If (dt.Rows.Count > 0) Then
    ''                strBCode = dt.Rows(0)("BROKER_CODE").ToString()
    ''                Dim strFileName As String = objFileImportExport.ExportClosedDeals(txtDate.Text, strBCode, strFilePath, "BROKER")
    ''                objCommon.LogActivity(Convert.ToInt32(Session("Uid").ToString()), "Closed Deals are exported to local", True)
    ''                Response.ContentType = "plain/text"
    ''                Response.AppendHeader("Content-Disposition", "attachment; filename=" & strFileName)
    ''                Response.TransmitFile(strFilePath & strFileName)
    ''                Response.End()
    ''            End If
    ''        ElseIf Convert.ToString(Session("UserType")).ToUpper() = "ADMIN" Then
    ''            strFilePath = Server.MapPath(".\CLOSED_DEALS\")
    ''            Dim strFileName As String = objFileImportExport.ExportClosedDeals(txtDate.Text, "", strFilePath, "ADMIN")
    ''            lblmsg.Visible = True
    ''            lblmsg.Text = "Closed Deals are exported to server Successfully!"
    ''            objCommon.LogActivity(Convert.ToInt32(Session("Uid").ToString()), "Closed Deals are exported to server", True)
    ''        End If
    ''    Catch ex As Exception
    ''        objCommon.ErrorLog("Error###: " & ex.ToString())
    ''    End Try
    ''End Sub
    'Protected Sub cmdExportDeals_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdExportDeals.Click
    '    'Dim objCommon As New Common()
    '    Dim dt As New DataTable
    '    Dim strsql As String = ""
    '    Dim strFilePath As String = ""

    '    Try
    '        If Convert.ToString(Session("UserType")).ToUpper() = "ADMIN" Then
    '            strFilePath = Server.MapPath(".\CLOSED_DEALS\")
    '            Dim strFileName As String = objFileImportExport.ExportClosedDeals(txtDate.Text, "", strFilePath, "ADMIN")
    '            lblmsg.Visible = True
    '            If strFileName = "No Deals" Then
    '                lblmsg.Text = " No Deals In The Date"
    '            Else
    '                lblmsg.Text = " Closed Deals are exported to server Successfully!"
    '                objCommon.LogActivity(Convert.ToInt32(Session("Uid").ToString()), "Closed Deals are exported to server", True)
    '            End If
    '        Else
    '            strFilePath = Server.MapPath(".\CLOSED_DEALS\")
    '            strsql = "SELECT BROKER_CODE FROM BrokerLogin WHERE USERNAME='" & System.Web.HttpContext.Current.Session("username").ToString() & "'"
    '            dt = objCommon.SelectRows(strsql)
    '            If (dt.Rows.Count > 0) Then
    '                strBCode = dt.Rows(0)("BROKER_CODE").ToString()
    '                Dim strFileName As String = objFileImportExport.ExportClosedDeals(txtDate.Text, strBCode, strFilePath, "BROKER")
    '                lblmsg.Visible = True
    '                If strFileName = "No Deals" Then
    '                    lblmsg.Text = " No Deals In The Date"
    '                Else
    '                    lblmsg.Text = " Closed Deals are exported to server Successfully!"
    '                    objCommon.LogActivity(Convert.ToInt32(Session("Uid").ToString()), "Closed Deals are exported to Server", True)

    '                    'Response.ContentType = "plain/text"
    '                    'Response.AppendHeader("Content-Disposition", "attachment; filename=" & strFileName)
    '                    'Response.TransmitFile(strFilePath & strFileName)
    '                    'Response.End()


    '                    'Response.ContentType = "plain/text"
    '                    'Response.AppendHeader("Content-Disposition", "attachment; filename=" & strFileName)
    '                    'Response.TransmitFile(strFilePath & strFileName)
    '                    'Response.End()

    '                    'Response.Clear()
    '                    'Response.ContentType = "application/CSV"
    '                    'Response.AddHeader("content-disposition", "attachment; filename=\"" + filename + ".csv \ "")
    '                    'Response.Write(t.ToString())
    '                    'Response.End()

    '                End If
    '            End If
    '        End If
    '    Catch ex As Exception
    '        objCommon.ErrorLog("Error###: " & ex.ToString())
    '    End Try
    'End Sub
    'Private Sub OnExportGridToCSV(ByVal sender As Object, ByVal e As System.EventArgs)
    '    ' Create the CSV file to which grid data will be exported. 
    '    Dim sw As New StreamWriter(Server.MapPath("~/GridData.txt"), False)
    '    Dim szData As String
    '    ' First we will write the headers. 
    '    'Dim dt As DataTable = m_dsProducts.Tables(0)
    '    'Dim iColCount As Integer = dt.Columns.Count
    '    'For i As Integer = 0 To iColCount - 1
    '    '    sw.Write(dt.Columns(i))
    '    '    If i < iColCount - 1 Then
    '    '        sw.Write(",")
    '    '    End If
    '    'Next
    '    szData = "ABC BBC  DBDB"
    '    sw.Write(szData)
    '    sw.Write(sw.NewLine)
    '    '' Now write all the rows. 
    '    'For Each dr As DataRow In dt.Rows
    '    '    For i As Integer = 0 To iColCount - 1
    '    '        If Not Convert.IsDBNull(dr(i)) Then
    '    '            sw.Write(dr(i).ToString())
    '    '        End If
    '    '        If i < iColCount - 1 Then
    '    '            sw.Write(",")
    '    '        End If
    '    '    Next
    '    szData = "ABC1 BBC1  DBDB1"
    '    sw.Write(szData)
    '    sw.Write(sw.NewLine)
    '    'Next
    '    sw.Close()
    'End Sub
    'Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
    '    Response.ContentType = "image/gif"
    '    Response.AppendHeader("Content-Disposition", "attachment; filename=asc.gif")
    '    Response.TransmitFile(Server.MapPath("~/images/asc.gif"))
    '    Response.End()
    'End Sub
    ''Protected Sub cmdExportDeals_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdExportDeals.Click
    ''    Dim objCommon As New Common()
    ''    Try
    ''        ' Dim sw As New StreamWriter(Server.MapPath(".\CLOSED_DEALS\newfile1.txt"), False)
    ''        ' Dim szData As String
    ''        ' First we will write the headers. 
    ''        'Dim dt As DataTable = m_dsProducts.Tables(0)
    ''        'Dim iColCount As Integer = dt.Columns.Count
    ''        'For i As Integer = 0 To iColCount - 1
    ''        '    sw.Write(dt.Columns(i))
    ''        '    If i < iColCount - 1 Then
    ''        '        sw.Write(",")
    ''        '    End If
    ''        'Next
    ''        'szData = "ABC BBC  DBDB"
    ''        'sw.Write(szData)
    ''        ' sw.Write(sw.NewLine)
    ''        '' Now write all the rows. 
    ''        'For Each dr As DataRow In dt.Rows
    ''        '    For i As Integer = 0 To iColCount - 1
    ''        '        If Not Convert.IsDBNull(dr(i)) Then
    ''        '            sw.Write(dr(i).ToString())
    ''        '        End If
    ''        '        If i < iColCount - 1 Then
    ''        '            sw.Write(",")
    ''        '        End If
    ''        '    Next
    ''        '   szData = "ABC1 BBC1  DBDB1"
    ''        ' Dim sw As New StreamWriter(Server.MapPath(".\CLOSED_DEALS\newfile1.txt"), False)
    ''        ' sw.Write(szData)
    ''        '  sw.Write(sw.NewLine)
    ''        'Next
    ''        ' sw.Close()
    ''        'Dim currentContext As System.Web.HttpContext = System.Web.HttpContext.Current

    ''        'Response.Clear()
    ''        'Response.AddHeader("content-disposition", "attachment;filename=" & currentContext.Server.MapPath(".\CLOSED_DEALS\newfile1.txt"))
    ''        'Response.Charset = ""
    ''        'Response.Cache.SetCacheability(HttpCacheability.NoCache)
    ''        'Response.ContentType = "application/vnd.text"
    ''        'str = "Test One Two Three"
    ''        'Dim stringWrite As New System.IO.StringWriter()
    ''        'Dim htmlWrite = New HtmlTextWriter(stringWrite)

    ''        'Response.Write(str.ToString())
    ''        'Response.End()

    ''        ' Exit Sub
    ''        'If fileUpEx.FileName = "" Then
    ''        'msgbox("Please select file name to write the closed deals")
    ''        ' Exit Sub
    ''        'End If
    ''        Dim strsql As String
    ''        strsql = "SELECT BROKER_CODE FROM BrokerLogin WHERE USERNAME='" & System.Web.HttpContext.Current.Session("username").ToString() & "'"
    ''        cmd = New SqlCommand(strsql, cn)
    ''        Dim dt As New DataTable
    ''        adp = New SqlDataAdapter(cmd)
    ''        adp.Fill(dt)
    ''        If (dt.Rows.Count > 0) Then
    ''            strBCode = dt.Rows(0)("BROKER_CODE").ToString()
    ''        End If
    ''        Dim strPath As String = objFileImportExport.ExportDealsClosed(txtDate.Text, strBCode)

    ''        Response.ContentType = "plain/text"

    ''        Response.AppendHeader("Content-Disposition", "attachment; filename=" & strPath)

    ''        Response.TransmitFile(Server.MapPath(".\CLOSED_DEALS\" & strPath))

    ''        Response.End()

    ''        'lblmsg.Visible = True
    ''        'lblmsg.Text = "Closed Deals are exported to server Successfully!"

    ''    Catch ex As Exception
    ''        objCommon.ErrorLog("Error###: " & ex.ToString())
    ''    End Try

    ''End Sub
    ''Protected Sub CalDate_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CalDate.SelectionChanged
    ''    txtDate.Text = CalDate.SelectedDate.ToString("MM/dd/yyyy")

    ''    Dim div As System.Web.UI.Control = Page.FindControl("divCalendar")

    ''    If TypeOf div Is HtmlGenericControl Then
    ''        CType(div, HtmlGenericControl).Style.Add("display", "none")
    ''    End If
    ''End Sub
End Class
