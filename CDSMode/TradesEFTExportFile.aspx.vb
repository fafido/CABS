Imports System.Windows.Forms
Imports System.IO

Partial Class CDSMode_TradesEFTExportFile
    Inherits System.Web.UI.Page
    Dim constr As String = (System.Configuration.ConfigurationManager.AppSettings("connpath"))
    Dim cn As New SqlConnection(constr)
    Dim cmd As SqlCommand
    Dim adp As SqlDataAdapter
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Page.MaintainScrollPositionOnPostBack = True
            If (Not IsPostBack) Then
                Try
                    If (Session("Brokercode") = Nothing) Then
                        Response.Redirect("~\Loginsystem.aspx")
                    End If
                    cmd = New SqlCommand("insert into UserActivityLog (UserName,Activity,TimeOfActivity,DateDone,CompanyCode) values ('" & Session("Username") & "','Accessed Trades Export File Creation Form','" & Date.Now & "','" & Now.Date & "','" & Session("BrokerCode") & "')", cn)
                    If (cn.State = ConnectionState.Open) Then
                        cn.Close()
                    End If
                    cn.Open()
                    cmd.ExecuteNonQuery()
                    cn.Close()
                    GetOrdersLoad()
                Catch ex As Exception
                    msgbox(ex.Message)
                End Try
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub GetOrdersLoad()
        Try
            Dim ds As New DataSet
            'cmd = New SqlCommand("select * from ordersSummary where PurchasingBroker='" & Session("BrokerCode").ToString & "' and status='O' and ApprovalFlag=1", cn)
            cmd = New SqlCommand("select * from settlement_movement where updatestate=0 and trans_type='BUY'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "settlement_movement")
            btnSelect.Enabled = False
            If (ds.Tables(0).Rows.Count > 0) Then
                txtFileName.Text = Session("BrokerCode").ToString & "" & DateString.ToString.Replace("-", "")
                'btnSelect.Enabled = True
                Button1.Enabled = True
                lblFileloadstatus.Text = "You have " & ds.Tables(0).Rows.Count & " orders ready for export."
                lblFileloadstatus.ForeColor = Drawing.Color.Green
            Else
                lblFileloadstatus.Text = "No ready orders for export"
                lblFileloadstatus.ForeColor = Drawing.Color.Red
                'btnSelect.Enabled = False
                Button1.Enabled = False

            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
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
    Protected Sub btnSelect_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSelect.Click
        Try
            If (txtFileName.Text = "") Then
                msgbox("Enter a valid export file name")
                Exit Sub
            End If

            Dim res As New DataSet
            Dim i As Integer = 0
            Dim EFT As New DataSet
            Dim OrderRef As String = ""
            Dim OrderNum As String = ""
            Dim company As String = ""
            Dim holdernum As String = ""
            Dim orderQuant As String = ""
            Dim orderVal As Double
            Dim orderType As String = ""
            Dim orderDate As String = ""
            Dim Broker As String = ""
            Dim holder As String = ""
            Dim holdername As String = ""
            Dim amount As String = ""
            Dim comp As String = ""
            Dim bank As String = ""
            Dim branch As String = ""
            Dim acc As String = ""
            Dim pdate As String = ""
            Dim line As String = ""
            Dim file As New DataSet
            Dim fname As String = ""
            Dim shareholder As String = ""
            Dim taxcode As String = ""
            Dim transTyp As String = ""
            Dim trns As String = ""
            Dim basePrice As String = ""
            Dim orderAtt As String = ""
            Dim dealdate As String = ""
            Dim targetdate As String = ""
            Dim expdate As String = ""
            Dim TRanTpye As String = ""
            Dim OrderPref As String = ""
            Dim rex As New DataSet
            cmd = New SqlCommand("select count (OrderRef) as orders from ordersSummary where purchasingbroker='" & Session("BrokerCode").ToString & "' and status='O'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(rex, "ordersSummary")

            'Dim filecmd As New SqlCommand("select * from ordersSummary where orderdate>='" & BasicDatePicker1.Text & "' and orderdate <= '" & BasicDatePicker2.Text & "' and status='C'", cn)
            Dim filecmd As New SqlCommand("select * from ordersSummary where purchasingbroker='" & Session("BrokerCode").ToString & "' and status='O'", cn)
            Dim fileadp As New SqlDataAdapter(filecmd)
            Dim tempAmt As String = ""
            fileadp.Fill(file, "OrdersSummary")
            fname = txtFileName.Text + ".txt"
            Dim iRowNo As Integer
            Dim txAmt As String
            line = Left("ORDER FILE" & Space(11), 11) & Left(txtFileName.Text & Space(14), 14) & Left(rex.Tables(0).Rows(0).Item("Orders").ToString.PadLeft(4, " "c) & Space(4), 4) & Left(" RECORDS" & Space(8), 8) & vbCrLf
            iRowNo = 0
            If (file.Tables(0).Rows.Count > 0) Then
                For i = 0 To file.Tables(0).Rows.Count - 1
                    Dim ros As New DataSet
                    cmd = New SqlCommand("select * from names where cds_number ='" & file.Tables(0).Rows(i).Item("cds_number").ToString & "'", cn)
                    adp = New SqlDataAdapter(cmd)
                    adp.Fill(ros, "names")


                    orderAtt = (file.Tables(0).Rows(i).Item("OrderAttribute").ToString.PadLeft(3, " "c))
                    If (file.Tables(0).Rows(i).Item("OrderType").ToString = "PUR") Then
                        TRanTpye = "BUY"

                    End If
                    If (file.Tables(0).Rows(i).Item("OrderType").ToString = "SAL") Then
                        TRanTpye = "SELL"

                    End If
                    'transTyp = (file.Tables(0).Rows(i).Item("OrderType").ToString.PadLeft(4, " "c))
                    transTyp = (TRanTpye.ToString.PadLeft(4, " "c))

                    'trns = (file.Tables(0).Rows(i).Item("OrderType").ToString.PadLeft(1, " "c))
                    trns = ("E".ToString.PadLeft(1, " "c))
                    shareholder = ((ros.Tables(0).Rows(0).Item("surname").ToString & "" & ros.Tables(0).Rows(0).Item("forenames").ToString).ToString.PadLeft(30, " "c))
                    taxcode = ros.Tables(0).Rows(0).Item("tax").ToString.PadLeft(2, "0"c)
                    OrderRef = (file.Tables(0).Rows(i).Item("OrderRef").ToString.PadLeft(6, "0"c))
                    holdernum = CStr(file.Tables(0).Rows(i).Item("cds_number").ToString.PadLeft(13, " "c))
                    OrderNum = (file.Tables(0).Rows(i).Item("OrderNumber").ToString.PadLeft(6, "0"c))
                    txAmt = file.Tables(0).Rows(i).Item("OrderValue").ToString
                    txAmt = Left(file.Tables(0).Rows(i).Item("OrderValue"), InStrRev(file.Tables(0).Rows(i).Item("OrderValue"), ".") + 2)
                    txAmt = Replace(txAmt, ".", "")
                    orderVal = txAmt.PadLeft(12, "0"c)
                    orderQuant = (file.Tables(0).Rows(i).Item("Order_Quantity").ToString).PadLeft(6, " "c)
                    basePrice = (file.Tables(0).Rows(i).Item("BasePrice").ToString).PadLeft(12, " "c)
                    orderType = file.Tables(0).Rows(i).Item("OrderType").ToString.PadLeft(3, "0"c)
                    Broker = file.Tables(0).Rows(i).Item("PurchasingBroker").ToString.PadLeft(8, " "c)
                    comp = file.Tables(0).Rows(i).Item("company").ToString.PadLeft(6, " "c)
                    orderDate = file.Tables(0).Rows(i).Item("OrderDate")
                    dealdate = CDate(file.Tables(0).Rows(i).Item("OrderDate").ToString.PadLeft(10, " "c))
                    targetdate = CDate((file.Tables(0).Rows(i).Item("TargetDate").ToString.PadLeft(10, " "c)))
                    expdate = CDate((file.Tables(0).Rows(i).Item("ExpiryDate").ToString.PadLeft(10, " "c)))
                    OrderPref = (file.Tables(0).Rows(i).Item("OrderPreference").ToString.PadLeft(1, " "c))

                    iRowNo = i + 1
                    'line = line + Left("ORD" & Space(3), 3) & Left(OrderRef & Space(6), 6) & Left(holdernum & Space(8), 8) & Left(OrderNum & Space(6), 6) & Left(orderQuant & Space(10), 10) & orderVal & Left(orderType & Space(3), 3) & Left(comp & Space(6), 6) & Left(Broker & Space(8), 8) & Left(orderDate & Space(8), 8)
                    'line = line + Left(transTyp & Space(4), 4) & Left(comp & Space(6), 6) & Left(Left(trns, 1) & Space(1), 1) & Left(Broker & Space(8), 8) & Left(taxcode & Space(2), 2) & Left(holdernum & Space(13), 13) & Left(shareholder & Space(30), 30) & Left(orderQuant & Space(6), 6) & Left(basePrice & Space(12), 12) & Left(orderAtt & Space(4), 4) & Left(dealdate & Space(10), 10) & Left(targetdate & Space(10), 10) & Left(expdate & Space(10), 10)
                    'msgbox(Left(expdate & Space(10), 10))

                    line = line + Left(transTyp & Space(4), 4) & Left(comp & Space(6), 6) & Left(Left(trns, 1) & Space(1), 1) & Left(Broker & Space(8), 8) & Left(taxcode & Space(2), 2) & Left(holdernum & Space(13), 13) & Left(shareholder & Space(30), 30) & Left(orderQuant & Space(6), 6) & Left(basePrice & Space(12), 12) & Left(OrderPref & Space(1), 1) & Left("IOC" & Space(3), 3) & Left(orderAtt & Space(3), 3) & Left(dealdate & Space(10), 10) & Left(targetdate & Space(10), 10) & Left(expdate & Space(10), 10)

                    My.Computer.FileSystem.WriteAllText("C:\" & fname, line & vbCrLf, True)
                    line = ""
                Next
                My.Computer.FileSystem.WriteAllText("C:\" & fname, line & vbCrLf, True)

                cmd = New SqlCommand("update ordersSummary set status='C' where purchasingbroker='" & Session("BrokerCode").ToString & "' and status='O'", cn)
                If (cn.State = ConnectionState.Open) Then
                    cn.Close()
                End If
                cn.Open()
                cmd.ExecuteNonQuery()
                cn.Close()
                cmd = New SqlCommand("insert into UserActivityLog (UserName,Activity,TimeOfActivity,DateDone,CompanyCode) values ('" & Session("Username") & "','Created a trades export file','" & Date.Now & "','" & Now.Date & "','" & Session("BrokerCode") & "')", cn)
                If (cn.State = ConnectionState.Open) Then
                    cn.Close()
                End If
                cn.Open()
                cmd.ExecuteNonQuery()
                cn.Close()
                msgbox("Electronic file exported successfully")
            Else
                msgbox("no data to export in the trades section for the specified period")
                Exit Sub
            End If

        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    '    Public Sub bulkimport()
    '        BULK()
    '        INSERT(CSVTest)
    '        FROM() 'c:\csvtest.txt'
    'WITH
    '(
    'FIELDTERMINATOR = ',',
    'ROWTERMINATOR = '\n'
    ')
    '            GO()
    '--Check the content of the table.
    'SELECT *
    'FROM CSVTest
    'GO
    '--Drop the table to clean up database.
    'DROP TABLE CSVTest
    'GO
    '    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        'exportCsv()

        'ExportExcel()
        'NewCsv()

        Dim ds As New DataSet
        Dim ros As New DataSet
        cmd = New SqlCommand("select max(uploadid) AS uploadid from settlement_movement where updatestate=0", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ros, "settlement_movement")

        'cmd = New SqlCommand("select OrdersSummary.OrderNumber, OrdersSummary.OrderType, OrdersSummary.Company, 'E' as SecurityType,OrdersSummary.PurchasingBroker , 10 as TaxType, OrdersSummary.cds_number ,names.Surname +' '+names.Forenames  as shareholdername,  OrdersSummary.Order_Quantity, OrdersSummary.BasePrice , OrdersSummary.OrderPreference , OrdersSummary.OrderQualifier as [ORDERQUALIFIER], OrdersSummary.orderAttribute as TIMEFORCE, convert(varchar, OrdersSummary.OrderDate,120) as createdate,CONVERT(varchar, OrdersSummary.TargetDate,101) as targetdate ,CONVERT(varchar, OrdersSummary.ExpiryDate,101) as expirydate from OrdersSummary, names where names.CDS_Number = OrdersSummary.CDS_Number and OrdersSummary .ApprovalFlag =0 and Updated=0  order by OrderRef desc", cn)
        'cmd = New SqlCommand("select OrdersSummary.OrderNumber, OrdersSummary.OrderType, OrdersSummary.Company, 'E' as SecurityType,OrdersSummary.PurchasingBroker , 10 as TaxType, OrdersSummary.cds_number ,left(names.Surname +' '+names.Forenames,20)  as shareholdername,  OrdersSummary.Order_Quantity, OrdersSummary.BasePrice , OrdersSummary.OrderPreference , OrdersSummary.OrderQualifier as [ORDERQUALIFIER], OrdersSummary.orderAttribute as TIMEFORCE, convert(varchar, OrdersSummary.OrderDate,120) as createdate,convert(varchar, OrdersSummary.OrderDate,120) as targetdate ,CONVERT(varchar, OrdersSummary.ExpiryDate,101) as expirydate from OrdersSummary, names where names.CDS_Number = OrdersSummary.CDS_Number and OrdersSummary .ApprovalFlag =0 and Updated=0  order by OrderRef desc", cn)
        'cmd = New SqlCommand("select OrdersSummary.OrderNumber, OrdersSummary.OrderType, OrdersSummary.Company, 'E' as SecurityType,OrdersSummary.PurchasingBroker , 10 as TaxType, OrdersSummary.cds_number ,'CDS ACCOUNT HOLDER'  as shareholdername,  OrdersSummary.Order_Quantity, OrdersSummary.BasePrice , OrdersSummary.OrderPreference , OrdersSummary.OrderQualifier as [ORDERQUALIFIER], OrdersSummary.orderAttribute as TIMEFORCE, convert(varchar, OrdersSummary.OrderDate,120) as createdate,convert(varchar, OrdersSummary.OrderDate,120) as targetdate ,CONVERT(varchar, OrdersSummary.ExpiryDate,101) as expirydate from OrdersSummary, names where names.CDS_Number = OrdersSummary.CDS_Number and OrdersSummary .ApprovalFlag =0 and Updated=0  order by OrderRef desc", cn)
        cmd = New SqlCommand("select settlement_movement .id as [DealNo], (settlement_movement.quantity * settlement_movement.Order_Quantity)*-1 as [Amount], settlement_movement .company, names.Account, names.Branch_Code from settlement_movement , names where names .CDS_Number  = settlement_movement .cds_number and settlement_movement.UpdateState = 0 and settlement_movement.trans_type='BUY' and uploadid=" & ros.Tables(0).Rows(0).Item("uploadid").ToString & "", cn)
        'cmd = New SqlCommand("select OrderNumber, OrderType, Company from OrdersSummary", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "settlement_movement")

        If (ds.Tables(0).Rows.Count > 0) Then
            grdData1.DataSource = ds.Tables(0)
            grdData1.DataBind()
            grdData1.Visible = True
        Else
            msgbox("No orders to export")
        End If

        cmd = New SqlCommand("Update settlement_movement set updateState= 1 where uploadid=" & ros.Tables(0).Rows(0).Item("uploadid").ToString & " ", cn)
        If (cn.State = ConnectionState.Open) Then
            cn.Close()
        End If
        cn.Open()
        cmd.ExecuteNonQuery()
        cn.Close()

        If (grdData1.Rows.Count > 0) Then
            Csv1()
        End If

        'GetOrdersLoad()
    End Sub
    Public Sub exportCsv()
        Try
            Dim ds As New DataSet
            Dim grdData As New GridView
            cmd = New SqlCommand("select OrderNumber, OrderType, Company, 'E' as SecurityType,PurchasingBroker , 10 as TaxType, cds_number , 'testname' as shareholdername,  Order_Quantity as [shares], BasePrice , OrderPreference ,'IOC' AS [ORDERQUALIFIER], orderAttribute as TIMEFORCE,OrderDate as createdate,TargetDate , ExpiryDate     from OrdersSummary", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "OrdersSummary")
            If (ds.Tables(0).Rows.Count > 0) Then
                grdData.DataSource = ds.Tables(0)
                grdData.DataBind()

                Dim strexport As String = ""
                For Each c As DataGridColumn In grdData.Columns
                    strexport &= """" & c.HeaderText & ""","
                    strexport = strexport.Substring(0, strexport.Length - 1)
                    strexport &= Environment.NewLine

                    For Each R As DataGridViewRow In grdData.Rows
                        For Each ci As DataGridViewCell In R.Cells
                            If Not ci.Value Is Nothing Then
                                strexport &= """" & ci.Value.ToString & ""","
                            Else
                                'strexport &= """" & "" & ""","
                            End If
                        Next
                        strexport = strexport.Substring(0, strexport.Length - 1)
                        strexport &= Environment.NewLine
                    Next

                Next
                Dim tw As IO.TextWriter = New IO.StreamWriter("j:\RAJ.CSV")
                msgbox("File Saved")
                tw.Write(strexport)
                tw.Close()
            End If

        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub ExportExcel()
        Try
            Dim ds As New DataSet
            Dim grdData As New GridView
            cmd = New SqlCommand("select OrderNumber, OrderType, Company, 'E' as SecurityType,PurchasingBroker , 10 as TaxType, cds_number , 'testname' as shareholdername,  Order_Quantity as [shares], BasePrice , OrderPreference ,'IOC' AS [ORDERQUALIFIER], orderAttribute as TIMEFORCE,OrderDate as createdate,TargetDate , ExpiryDate     from OrdersSummary", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "OrdersSummary")

            If (ds.Tables(0).Rows.Count > 0) Then
                grdData.DataSource = ds.Tables(0)
                grdData.DataBind()

                If (grdData.Rows.Count > 0) Then
                    Response.ClearContent()
                    Response.AddHeader("content-disposition", String.Format("attachment; filename={0}", "orders1.csv"))
                    Response.ContentType = "application/text"
                    grdData.AllowPaging = False

                    Dim strbldr As New StringBuilder
                    'For i = 0 To grdData.Columns.Count - 1
                    '    strbldr.Append(grdData.Columns(i).HeaderText & ",")
                    'Next
                    'strbldr.Append("\n")
                    For j = 0 To grdData.Rows.Count - 1
                        For k = 0 To grdData.Columns.Count - 1
                            strbldr.Append(grdData.Rows(j).Cells(k).Text & ",")
                        Next
                        'strbldr.Append("\n")
                    Next

                    Response.Write(strbldr.ToString)
                    Response.End()
                End If

            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub NewCsv()
        Try
            Dim strDelimiterType As String = ","
            Dim blnWriteColumnHeaderNames As Boolean = False
            Dim ds As New DataSet
            Dim grdData As New DataGridView
            cmd = New SqlCommand("select OrderNumber, OrderType, Company, 'E' as SecurityType,PurchasingBroker , 10 as TaxType, cds_number , 'testname' as shareholdername,  Order_Quantity as [shares], BasePrice , OrderPreference ,'IOC' AS [ORDERQUALIFIER], orderAttribute as TIMEFORCE,OrderDate as createdate,TargetDate , ExpiryDate     from OrdersSummary", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "OrdersSummary")

            grdData.DataSource = ds.Tables(0)
            'grdData.DataBind()


            Dim sr As StreamWriter = File.CreateText("Orderscsv")
            Dim strDelimiter As String = strDelimiterType
            Dim intColumnCount As Integer = grdData.Columns.Count - 1
            Dim strRowData As String = ""

            If blnWriteColumnHeaderNames Then
                For intX As Integer = 0 To intColumnCount
                    strRowData += Replace(grdData.Columns(intX).Name, strDelimiter, "") & IIf(intX < intColumnCount, strDelimiter, "")
                Next intX
                sr.WriteLine(strRowData)
            End If

            For intX As Integer = 0 To grdData.Rows.Count - 1
                strRowData = ""
                For intRowData As Integer = 0 To intColumnCount
                    strRowData += Replace(grdData.Rows(intX).Cells(intRowData).Value, strDelimiter, "") & IIf(intRowData < intColumnCount, strDelimiter, "") '''''''''highlights this row
                Next intRowData
                sr.WriteLine(strRowData)
            Next intX
            sr.Close()
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub Csv1()
        Try
            'Dim ds As New DataSet
            'cmd = New SqlCommand("select OrderNumber, OrderType, Company, 'E' as SecurityType,PurchasingBroker , 10 as TaxType, cds_number , 'testname' as shareholdername,  Order_Quantity as [shares], BasePrice , OrderPreference ,'IOC' AS [ORDERQUALIFIER], orderAttribute as TIMEFORCE,OrderDate as createdate,TargetDate , ExpiryDate     from OrdersSummary", cn)
            'adp = New SqlDataAdapter(cmd)
            'adp.Fill(ds, "OrdersSummary")

            'If (ds.Tables(0).Rows.Count > 0) Then
            '    grdData1.DataSource = ds.Tables(0)
            '    grdData1.DataBind()
            'End If

            Response.Clear()

            Response.Buffer = True

            Response.AddHeader("content-disposition", "attachment;filename=" & Now.Date & "CDSC_Debit_order.csv")
            Response.Charset = ""
            Response.ContentType = "application/text"
            grdData1.AllowPaging = False
            grdData1.DataBind()

            Dim sb As New StringBuilder()

            For k As Integer = 0 To grdData1.Columns.Count - 1

                'add separator

                sb.Append(grdData1.Columns(k).HeaderText + ","c)

            Next

            'append new line

            sb.Append(vbCr & vbLf)

            For i As Integer = 0 To grdData1.Rows.Count - 1

                For k As Integer = 0 To grdData1.Columns.Count - 1

                    'add separator

                    sb.Append(grdData1.Rows(i).Cells(k).Text + ","c)

                Next

                'append new line

                sb.Append(vbCr & vbLf)

            Next

            Response.Output.Write(sb.ToString())

            Response.Flush()

            Response.End()
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
End Class
