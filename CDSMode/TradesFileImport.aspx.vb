Imports System.IO
Imports System.Array
Partial Class CDSMode_TradesFileImport
    Inherits System.Web.UI.Page
    Dim cnstr As String = (System.Configuration.ConfigurationManager.AppSettings("connpath"))
    Dim conn As New SqlConnection(cnstr)
    Dim cn As New SqlConnection(cnstr)
    Dim cmd As SqlCommand
    Dim comm As SqlCommand
    Dim adp As SqlDataAdapter
    Dim wk_rec As String, sw_first As Boolean, fs, f
    Dim wk_head_shares As Double, wk_head_cnt As Integer, wk_tot_shares As Double
    Dim wk_tot_cnt As Integer, wk_err As Integer, wk_date As Date, wk_sys_cds As Double, wk_cds_ac As Long
    Dim wk_dets_shareholder As Long, wk_work_shareholder As Long
    Dim wk_shares, wk_shareholder As Long
    Private _cmd1 As SqlCommand

    Private Property cmd1 As SqlCommand
        Get
            Return _cmd1
        End Get
        Set(value As SqlCommand)
            _cmd1 = value
        End Set
    End Property

    Public Sub msgbox(ByVal strMessage As String)

        'finishes server processing, returns to client.
        Dim strScript As String = "<script language=JavaScript>"
        strScript += "window.alert(""" & strMessage & """);"
        strScript += "</script>"
        Dim lbl As New System.Web.UI.WebControls.Label
        lbl.Text = strScript
        Page.Controls.Add(lbl)

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If (Not IsPostBack) Then

            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            If (rdSettlemts.Checked = True) Then
                ImportFile()
                Update1()
            End If
            If (rdSettlemts0.Checked = True) Then
                SettlementFileExport()
            End If
            If (rdSettlemts1.Checked = True) Then
                UpdateAccounts()
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub TransferProcess()
        Try
            Dim ds As New DataSet
            Dim Rex As New DataSet
            cmd = New SqlCommand("select max(UploadID) from TblTradesUpload where UpdateFlag=0", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(Rex, "TblTradesUpload")

            If (Rex.Tables(0).Rows.Count > 0) Then
                cmd = New SqlCommand("select initDealNo, quantity, Broker_Init , InitDealType, Company from TblTradesUpload where uploadID=" & Rex.Tables(0).Rows(0).Item("uploadid").ToString & "", cn)
                adp = New SqlDataAdapter(cmd)
                adp.Fill(ds, "TblTradesUpload")

            End If

            'select initDealNo, quantity, Broker_Init , InitDealType, Company from TblTradesUpload 

            'select quantity, Broker_Target, Company, TargetDealType from TblTradesUpload 

        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Public Sub UpdateAccounts()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select * from TblSettlementData where updateflag=2", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "tblSettlementData")

            If (ds.Tables(0).Rows.Count > 0) Then
                Dim i As Integer
                For i = 0 To ds.Tables(0).Rows.Count - 1
                    If (ds.Tables(0).Rows(i).Item("trans_type").ToString = "BUY") Then

                        cmd = New SqlCommand("insert into mast (company,cds_number,date_created,shares,update_type,pladge,pledge_shares,created_by,updated_by,locked,lock_reason,batch_ref,cert) values ('" & ds.Tables(0).Rows(i).Item("company").ToString & "','" & ds.Tables(0).Rows(i).Item("cds_number").ToString & "','" & Now.Date & "'," & ds.Tables(0).Rows(i).Item("shares").ToString & ",'TRADES',0,0,'" & Session("username") & "','" & Session("Username") & "',0,'',0,0)", cn)
                        If (cn.State = ConnectionState.Open) Then
                            cn.Close()
                        End If
                        cn.Open()
                        cmd.ExecuteNonQuery()
                        cn.Close()


                    End If

                    If (ds.Tables(0).Rows(i).Item("trans_type").ToString = "SELL") Then

                        cmd = New SqlCommand("insert into mast (company,cds_number,date_created,shares,update_type,pladge,pledge_shares,created_by,updated_by,locked,lock_reason,batch_ref,cert) values ('" & ds.Tables(0).Rows(i).Item("company").ToString & "','" & ds.Tables(0).Rows(i).Item("cds_number").ToString & "','" & Now.Date & "'," & ds.Tables(0).Rows(i).Item("shares").ToString & ",'TRADES',0,0,'" & Session("username") & "','" & Session("Username") & "',0,'',0,0)", cn)
                        If (cn.State = ConnectionState.Open) Then
                            cn.Close()
                        End If
                        cn.Open()
                        cmd.ExecuteNonQuery()
                        cn.Close()


                    End If

                Next

                cmd = New SqlCommand("Update TblSettlementData set updateflag=3 where updateflag= 2", cn)
                If (cn.State = ConnectionState.Open) Then
                    cn.Close()
                End If
                cn.Open()
                cmd.ExecuteNonQuery()
                cn.Close()

                msgbox("Accounts Update Complete")
            End If

        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub SettlementFileExport()
        Try
            If (txtSettlementExport.Text = "") Then
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
            Dim Bankcode As String = ""
            Dim Branchcode As String = ""
            Dim Accnum As String = ""

            Dim rex As New DataSet
            Dim dsi As New DataSet
            cmd = New SqlCommand("select max(uploadid) as uploadid from TblSettlementData where updateflag=1", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(dsi, "TblSettlementData")

            If (dsi.Tables(0).Rows.Count > 0) Then
                cmd = New SqlCommand("select COUNT (trans_type) AS ORDERS  from TblSettlementData where updateFlag=1", cn)
                adp = New SqlDataAdapter(cmd)
                Dim dsi1 As New DataSet
                adp.Fill(dsi1, "tblsettlementData")


                Dim filecmd As New SqlCommand("select TblSettlementData .cds_number ,TblSettlementData.shares ,TblSettlementData .trans_type ,TblSettlementData .company ,TblSettlementData .UploadID , TblSettlementData .dealPrice , names.surname, names.Forenames, names.Bank_Code , names.Branch_Code , names.Account  from TblSettlementData , names where names.CDS_Number= TblSettlementData .cds_number and TblSettlementData .UpdateFlag = 1", cn)
                Dim fileadp As New SqlDataAdapter(filecmd)
                Dim tempAmt As String = ""
                fileadp.Fill(file, "tblSettlementData")
                fname = txtSettlementExport.Text + ".txt"
                Dim iRowNo As Integer
                line = Left("SETTLEMENT DATA FILE" & Space(20), 20) & Left(txtSettlementExport.Text & Space(14), 14) & Left(dsi1.Tables(0).Rows(0).Item("Orders").ToString.PadLeft(4, " "c) & Space(4), 4) & Left(" RECORDS" & Space(8), 8) & Left(Date.Now & Space(10), 10) & vbCrLf
                iRowNo = 0
                If (file.Tables(0).Rows.Count > 0) Then
                    For i = 0 To file.Tables(0).Rows.Count - 1
                        Dim ros As New DataSet
                        cmd = New SqlCommand("select * from names where cds_number ='" & file.Tables(0).Rows(i).Item("cds_number").ToString & "'", cn)
                        adp = New SqlDataAdapter(cmd)
                        adp.Fill(ros, "names")

                        Dim holdernames As String = ""
                        Dim sharevalue As Double = 0
                        holdernames = (file.Tables(0).Rows(i).Item("surname").ToString & " " & file.Tables(0).Rows(i).Item("forenames").ToString).ToString.PadLeft(30, " "c)
                        holdernum = CStr(file.Tables(0).Rows(i).Item("cds_number").ToString.PadLeft(13, " "c))
                        comp = file.Tables(0).Rows(i).Item("company").ToString.PadLeft(6, " "c)
                        basePrice = (file.Tables(0).Rows(i).Item("DealPrice").ToString).PadLeft(12, " "c)
                        orderQuant = (file.Tables(0).Rows(i).Item("shares").ToString).PadLeft(6, " "c)
                        orderType = file.Tables(0).Rows(i).Item("trans_type").ToString.PadLeft(4, " "c)
                        sharevalue = (CDbl(file.Tables(0).Rows(i).Item("shares").ToString * file.Tables(0).Rows(i).Item("DealPrice").ToString)).ToString.PadLeft(12, " "c)
                        Bankcode = file.Tables(0).Rows(i).Item("bank_code").ToString.PadLeft(5, " "c)
                        Branchcode = file.Tables(0).Rows(i).Item("branch_code").ToString().PadLeft(5, " "c)
                        Accnum = file.Tables(0).Rows(i).Item("account").ToString.PadLeft(13, " "c)
                        iRowNo = i + 1
                        'line = line + Left("ORD" & Space(3), 3) & Left(OrderRef & Space(6), 6) & Left(holdernum & Space(8), 8) & Left(OrderNum & Space(6), 6) & Left(orderQuant & Space(10), 10) & orderVal & Left(orderType & Space(3), 3) & Left(comp & Space(6), 6) & Left(Broker & Space(8), 8) & Left(orderDate & Space(8), 8)
                        'line = line + Left(transTyp & Space(4), 4) & Left(comp & Space(6), 6) & Left(Left(trns, 1) & Space(1), 1) & Left(Broker & Space(8), 8) & Left(taxcode & Space(2), 2) & Left(holdernum & Space(13), 13) & Left(shareholder & Space(30), 30) & Left(orderQuant & Space(6), 6) & Left(basePrice & Space(12), 12) & Left(orderAtt & Space(4), 4) & Left(dealdate & Space(10), 10) & Left(targetdate & Space(10), 10) & Left(expdate & Space(10), 10)
                        line = line + Left(iRowNo & Space(4), 4) & Left(holdernum & Space(13), 13) & Left(holdernames & Space(30), 30) & Left(comp & Space(6), 6) & Left(basePrice & Space(12), 12) & Left(orderQuant & Space(6), 6) & Left(orderType & Space(4), 4) & Left(sharevalue & Space(12), 12) & Left(Bankcode & Space(5), 5) & Left(Branchcode & Space(5), 5) & Left(Accnum & Space(13), 13) & Left("1" & Space(1), 1)
                        My.Computer.FileSystem.WriteAllText("C:\" & fname, line & vbCrLf, True)
                        line = ""
                    Next
                    My.Computer.FileSystem.WriteAllText("C:\" & fname, line & vbCrLf, True)

                    cmd = New SqlCommand("update tblsettlementdata set updateflag=2 where updateflag=1 and uploadid=" & dsi.Tables(0).Rows(0).Item("uploadid").ToString & "", cn)
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
            End If

        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub GetOTCData()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select * from otc_data_import")
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub UpdateMast()
        Try
            Dim ds As New DataSet
            Dim dsx As New DataSet
            cmd = New SqlCommand("select max(uploadid) as uploadid from tblsettlementdata where updateflag=2", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(dsx, "tblsettlementdata")

            cmd = New SqlCommand("select * from TblSettlementData where updateflag=2", cn)
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Protected Function valid(myreader As OleDbDataReader, stval As Integer) As String
        'this method checks for null values in the .CSV file, if there are null replace them with 0
        Dim val As Object = myreader(stval)
        If val IsNot DBNull.Value Then

            Return val.ToString()
        Else
            Return Convert.ToString(0)
        End If


    End Function
    'Public Sub GetCSVData()
    '    Try

    '        If FileUpload1.HasFile Then
    '            'Upload file here

    '            Dim fileExt As String = System.IO.Path.GetExtension(FileUpload1.FileName)
    '            'Get extension
    '            If fileExt = ".csv" Then
    '                'check to see if its a .csv file


    '                Dim fileName2 As String = Path.GetFileName(FileUpload1.PostedFile.FileName)
    '                Dim fileLocation As String = Server.MapPath("~/CDSMode/ImportFiles/" & fileName2)
    '                FileUpload1.SaveAs(fileLocation)

    '                'FileUpload1.SaveAs("~\cdsmode\importfiles\" + FileUpload1.FileName)
    '                'Dim fileName2 As String = Path.GetFileName(FileUpload1.PostedFile.FileName)
    '                'Dim fileLocation As String = Server.MapPath("~/CDSMode/ImportFiles/" & fileName2)
    '                'save file to the specified folder

    '                'Dim oconn As New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & fileLocation & "; Extended Properties='text; HDR=Yes; FMT=Delimited'")
    '                Dim oconn As New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=D:\SystemFolders\cds\CentralDepDesign\CDSMode\ImportFiles\OTC Trades__31012014.csv; Extended Properties='text; HDR=Yes; FMT=Delimited'")
    '                'string connection for .CSV OR Text file

    '                Try
    '                    'Dim ocmd As New OleDbCommand("SELECT * FROM [" + FileUpload1.FileName & "]", oconn)
    '                    Dim ocmd As New OleDbCommand("SELECT * FROM [OTCTrades__31012014]", oconn)
    '                    'Select statement, if your using .CSV...put the name of the file NOT the excel tab

    '                    oconn.Open()

    '                    Dim odr As OleDbDataReader = ocmd.ExecuteReader()

    '                    'msgbox("text")
    '                    'Exit Sub
    '                    Dim d2 As New DataSet
    '                    cmd1 = New SqlCommand("select * from otc_data_import", cn1)
    '                    adp = New SqlDataAdapter(cmd1)
    '                    adp.Fill(d2, "otc_data_import")
    '                    Dim ImportID As Integer = 0
    '                    If (d2.Tables(0).Rows.Count > 0) Then
    '                        cmd1 = New SqlCommand("select max (importId) as importId from otc_data_import", cn1)
    '                        adp = New SqlDataAdapter(cmd1)
    '                        Dim d3 As New DataSet
    '                        adp.Fill(d3, "otc_data_import")

    '                        ImportID = d3.Tables(0).Rows(0).Item("importid").ToString + 1
    '                    Else
    '                        ImportID = 1
    '                    End If

    '                    Dim company As String = ""
    '                    Dim BuyOrderNum As String = ""
    '                    Dim Quantity As String = ""
    '                    Dim sellorderNumber As String = ""
    '                    Dim price As String = ""
    '                    Dim tradedate As String = ""
    '                    Dim settlementstatus As Integer = 0
    '                    Dim imprtid As Integer = ImportID



    '                    While odr.Read()


    '                        company = valid(odr, 0)
    '                        'Call the valid method...see below
    '                        BuyOrderNum = valid(odr, 1)
    '                        Quantity  = valid(odr, 2)
    '                        sellorderNumber = valid(odr, 3)
    '                        price = valid(odr, 4)
    '                        tradedate = valid(odr, 5)


    '                        InsertDataIntoSql(company, BuyOrderNum, Quantity, sellorderNumber, price, tradedate, settlementstatus, ImportID)
    '                        'Call the InsertDataIntoSql method...see below
    '                        'Dispose the file

    '                        FileUpload1.Dispose()
    '                    End While

    '                    'Close connection
    '                    oconn.Close()

    '                Catch ee As Exception
    '                    Label1.Text = ee.Message
    '                    Label1.ForeColor = System.Drawing.Color.Red
    '                Finally
    '                    Label1.Text = "Data Inserted Successfully"

    '                    Label1.ForeColor = System.Drawing.Color.Green

    '                End Try
    '            Else


    '                Label1.Text = "Only .csv files allowed!"

    '            End If
    '        Else



    '            Label1.Text = "You have not specified a file!"
    '        End If
    '    Catch ex As Exception
    '        msgbox(ex.Message)
    '    End Try
    'End Sub
    Public Sub InsertDataIntoSql(company As String, buyordernum As String, quantity As String, sellordernum As String, price As String, tradedate As String, _
        settlementstatus As Integer, importid As Integer)
        'method to insert data into database
        'Dim conn As New SqlConnection("Server=CI0000000879107\BENSON; Database=PRClips Mail; Trusted_Connection=True")
        'SQL connection
        Dim cmd As New SqlCommand()
        'SQL command
        cmd.Connection = cn

        cmd.CommandText = "INSERT INTO otc_data_import(Company, BuyOrderNum, Quantity, SellOrderNum, Price, TradeDate, SettlementStatus,importid) VALUES(@COMPANY, @BuyOrderNum, @Quantity, @SellOrderNum, @Price, @TradeDate, " & settlementstatus & "," & importid & ")"
        cmd.Parameters.Add("@Company", System.Data.SqlDbType.NVarChar).Value = company
        cmd.Parameters.Add("@BuyOrderNum", System.Data.SqlDbType.NVarChar).Value = buyordernum
        cmd.Parameters.Add("@Quantity", System.Data.SqlDbType.Int).Value = quantity
        cmd.Parameters.Add("@SellOrderNum", System.Data.SqlDbType.NVarChar).Value = sellordernum
        cmd.Parameters.Add("@Price", System.Data.SqlDbType.Money).Value = price
        cmd.Parameters.Add("@TradeDate", System.Data.SqlDbType.Date).Value = tradedate
        'cmd.Parameters.Add("@Subject", System.Data.SqlDbType.NVarChar).Value = Subject
        cmd.CommandType = System.Data.CommandType.Text
        cn.Open()
        cmd.ExecuteNonQuery()
        cn.Close()

    End Sub
    'Public Sub CSVTradesImport()
    '    Try
    '        Dim savePath As String = Server.MapPath("~\CDSMode\ImportFiles\")
    '        ' Get the name of the file to upload.
    '        Dim fileName As String = FileUpload1.FileName
    '        ' Append the name of the file to upload to the path.
    '        savePath += fileName
    '        ' Call the SaveAs method to save the uploaded
    '        ' file to the specified directory.
    '        FileUpload1.SaveAs(savePath)
    '        txtFileLocation.Text = savePath.ToString


    '        Dim connectionString As String = ""
    '        If FileUpload1.HasFile Then
    '            Dim fileName2 As String = Path.GetFileName(FileUpload1.PostedFile.FileName)
    '            Dim fileLocation As String = Server.MapPath("~/CDSMode/ImportFiles/" & fileName2)
    '            FileUpload1.SaveAs(fileLocation)
    '            Dim fileExtension As String = Path.GetExtension(FileUpload1.PostedFile.FileName)

    '            'Check whether file extension is xls or xslx
    '            If fileExtension = ".csv" Then
    '                'connectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & fileLocation & ";Extended Properties=""Excel 8.0;HDR=Yes;IMEX=2"""
    '                connectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & fileLocation & ";Extended Properties='text;HDR=Yes;IMEX=2,FMT=Delimited'"""
    '            ElseIf fileExtension = ".xlsx" Then
    '                connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & fileLocation & ";Extended Properties=""Excel 12.0;HDR=Yes;IMEX=2"""
    '            End If

    '            'Create OleDB Connection and OleDb Command

    '            Dim con As New OleDbConnection(connectionString)
    '            Dim cmd As New OleDbCommand()
    '            cmd.CommandType = System.Data.CommandType.Text
    '            cmd.Connection = con
    '            Dim dAdapter As New OleDbDataAdapter(cmd)
    '            Dim dtExcelRecords As New DataTable()
    '            con.Open()
    '            Dim dtExcelSheetName As DataTable = con.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, Nothing)
    '            Dim getExcelSheetName As String = dtExcelSheetName.Rows(0)("Table_Name").ToString()
    '            'cmd.CommandText = "SELECT * FROM [" & getExcelSheetName & "]"
    '            cmd.CommandText = "SELECT * FROM [" & fileLocation & "]"
    '            dAdapter.SelectCommand = cmd
    '            dAdapter.Fill(dtExcelRecords)


    '            Dim d2 As New DataSet
    '            cmd1 = New SqlCommand("select * from otc_data_import", cn1)
    '            adp = New SqlDataAdapter(cmd1)
    '            adp.Fill(d2, "otc_data_import")
    '            Dim ImportID As Integer = 0
    '            If (d2.Tables(0).Rows.Count > 0) Then
    '                cmd1 = New SqlCommand("select max (importId) as importId from otc_data_import", cn1)
    '                adp = New SqlDataAdapter(cmd1)
    '                Dim d3 As New DataSet
    '                adp.Fill(d3, "otc_data_import")

    '                ImportID = d3.Tables(0).Rows(0).Item("importid").ToString + 1
    '            Else
    '                ImportID = 1
    '            End If

    '            Dim x As Integer = 0
    '            For x = 0 To dtExcelRecords.Rows.Count - 1
    '                'cmd1 = New SqlCommand("insert into trades_Data_Import (ImportID,Company,Date_trade,CDS_Ref,Date_Settlement,Client_Id,Other_Names,Surname,Buy_Sell,Quantity,Price) values (" & ImportID & ",'" & dtExcelRecords.Rows(x).Item(0).ToString & "','" & dtExcelRecords.Rows(x).Item(1).ToString & "','" & dtExcelRecords.Rows(x).Item(2).ToString & "','" & dtExcelRecords.Rows(x).Item(3).ToString & "','" & dtExcelRecords.Rows(x).Item(4).ToString & "','" & dtExcelRecords.Rows(x).Item(5).ToString & "','" & dtExcelRecords.Rows(x).Item(6).ToString & "','" & dtExcelRecords.Rows(x).Item(7).ToString & "','" & dtExcelRecords.Rows(x).Item(8).ToString & "','" & dtExcelRecords.Rows(x).Item(9).ToString & "')", cn1)
    '                'cmd1 = New SqlCommand("insert into trades_Data_Import (ImportID,Company,Date_trade,CDS_Ref,Date_Settlement,Client_Id,Other_Names,Surname,Buy_Sell,Quantity,Price,UploadDate) values (" & ImportID & ",'" & Trim(wk_comp.SelectedItem.Text) & "','" & dtExcelRecords.Rows(x).Item(1).ToString & "','" & dtExcelRecords.Rows(x).Item(2).ToString & "','" & dtExcelRecords.Rows(x).Item(3).ToString & "','" & dtExcelRecords.Rows(x).Item(4).ToString & "','" & dtExcelRecords.Rows(x).Item(5).ToString & "','" & dtExcelRecords.Rows(x).Item(6).ToString & "','" & dtExcelRecords.Rows(x).Item(7).ToString & "','" & dtExcelRecords.Rows(x).Item(8).ToString & "','" & dtExcelRecords.Rows(x).Item(9).ToString & "','" & TextBox2.Text & "')", cn1)
    '                cmd1 = New SqlCommand("insert into otc_data_import (Company,BuyOrderNum,Quantity,SellOrderNum,Price,TradeDate,SettlementStatus,importid) values ('" & dtExcelRecords.Rows(x).Item(1).ToString & "','" & dtExcelRecords.Rows(x).Item(2).ToString & "','" & dtExcelRecords.Rows(x).Item(3).ToString & "','" & dtExcelRecords.Rows(x).Item(4).ToString & "','" & dtExcelRecords.Rows(x).Item(5).ToString & "','" & dtExcelRecords.Rows(x).Item(6).ToString & "',0," & ImportID & ")", cn1)
    '                cn1.Open()
    '                cmd1.ExecuteNonQuery()
    '                cn1.Close()
    '            Next
    '            con.Close()
    '            'msgbox("Upload Complete")
    '            'UpdateAccountsInformation()
    '            'UploadTransactions()
    '            msgbox("Upload Complete")
    '        End If
    '    Catch ex As Exception
    '        msgbox(ex.Message)
    '    End Try

    'End Sub
    Sub ImportFile()
        Try


            Dim ds1, ds2, ds3, ds4, ds5, ds6, ds7, ds8, ds9, ds15, ds16, ds17, ds18, ds19 As New DataSet
            Dim i, j, k, l, m, o, p, q As Integer

            fDocument.PostedFile.SaveAs(Server.MapPath("cdsimportedfile\" & fDocument.Value))
            TextBox1.Text = Server.MapPath("cdsimportedfile\" & fDocument.Value)
            If Not IO.File.Exists(TextBox1.Text) Then
                wk_status.Visible = True
                wk_status.Text = "Error..No File"
                msgbox("No File Found")

                Exit Sub
            End If


            Dim filname, ext As String
            ext = IO.Path.GetExtension(TextBox1.Text)

            filname = IO.Path.GetFileName(TextBox1.Text)


            ''newcomment
            'If filname.Remove(filname.IndexOf(".")) <> wk_comp.Text And filname.Remove(filname.IndexOf(".")).ToUpper <> wk_comp.Text And filname.Remove(filname.IndexOf(".")).ToLower <> wk_comp.Text Then
            '    msgbox("SELECT CORRECT COMPANY")
            '    Exit Sub
            'End If
            ''endnewcomment

            'wk_path.Text = "cdsimportedfile\" & IO.Path.GetFileName(TextBox1.Text)
            wk_path.Text = "cdsimportedfile\" & IO.Path.GetFileName(TextBox1.Text)

            wk_status.Visible = True
            wk_status.Text = "Processing..."

            sw_first = True
            Dim dsrec As New DataSet
            cmd = New SqlCommand("select * from TblTradesUpload ", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(dsrec, "TblTradesUpload")
            Dim UploadID As Integer
            If (dsrec.Tables(0).Rows.Count > 0) Then
                Dim dsreci As New DataSet
                cmd = New SqlCommand("select max(UploadID) as UploadID from TblTradesUpload", cn)
                adp = New SqlDataAdapter(cmd)
                adp.Fill(dsreci, "TblTradesUpload")
                UploadID = CInt(dsreci.Tables(0).Rows(0).Item("UploadID").ToString) + 1
            Else
                UploadID = 1
            End If



            fs = CreateObject("scripting.filesystemobject")
            If Not fs.FileExists(Server.MapPath(wk_path.Text)) Then
                wk_status.Visible = True
                wk_status.Text = "Error..No File"
                msgbox("FILE NOT FOUND")
                Exit Sub
            End If
            comm = New SqlCommand

            If conn.State = ConnectionState.Closed Then
                conn.ConnectionString = cnstr
                conn.Open()
            End If

            fs = CreateObject("Scripting.FileSystemObject")
            f = fs.OpenTextFile(TextBox1.Text, 1)

            wk_rec = f.readline

            Do Until Mid(wk_rec, wk_rec.Length) = "2"
                If sw_first Then
                    sw_first = False
                    If Mid(wk_rec, wk_rec.Length) <> "1" Then
                        msgbox("TEXT FILE FORMAT ERROR #0")
                        Exit Sub
                    End If
                End If

                If Mid(wk_rec, wk_rec.Length) = "0" Then
                    'GoTo proc_header
                Else
                    GoTo proc_record

                End If
looping:
                wk_rec = f.readline

            Loop
            f.Close()

            If wk_err = 1 Then
                Exit Sub
            End If
aftervalidate:

afterproc_mast_etc:

            If wk_err = 0 Then
                Me.wk_status.Text = "Completed"

            Else
                Me.wk_status.Text = "Completed with ERRORS"
            End If

            Exit Sub
            '--------------------------------- WRITE HEADER -------
            GoTo looping
            '---------------------------------  WRITE DETAILS -----------
proc_record:

            'Dim company1 = Me.wk_comp.Text
            Dim TransID As Integer = Mid(wk_rec, 1, 8)
            Dim InitDealNo As String = Mid(wk_rec, 9, 8)
            Dim InitSuffixNo As String = Mid(wk_rec, 17, 4)
            Dim Quantity As Integer = Mid(wk_rec, 22, 4)
            Dim Dealprice As Double = Mid(wk_rec, 26, 9)
            Dim DealDate As String = Mid(wk_rec, 34, 10)
            Dim BrokerInt As String = Mid(wk_rec, 44, 13)
            Dim BrokerTarget As String = Mid(wk_rec, 57, 13)
            Dim company As String = Mid(wk_rec, 70, 50)
            Dim DealInit As String = Mid(wk_rec, 120, 4)
            Dim DealTarget As String = Mid(wk_rec, 124, 4)
            Dim DealTargetNo As String = Mid(wk_rec, 128, 8)
            Dim TargetSuffix As String = Mid(wk_rec, 136, 4)

            comm = New SqlCommand
            If (conn.State = ConnectionState.Open) Then
                conn.Close()
            End If
            comm.Connection = conn
            comm.CommandText = "insert into TblTradesUpload values ('" & TransID & "','" & Trim(InitDealNo) & "','" & Trim(InitSuffixNo) & "'," & Quantity & "," & Dealprice & ",'" & DealDate & "','" & Trim(BrokerInt) & "','" & Trim(BrokerTarget) & "','" & Trim(company) & "','" & Trim(DealInit) & "','" & Trim(DealTarget) & "','" & Trim(DealTargetNo) & "','" & Trim(TargetSuffix) & "',1," & UploadID & ")"
            conn.Open()
            comm.ExecuteNonQuery()
            conn.Close()
            GoTo looping
            '-------------------------------------- VALIDATION ----------
            GoTo aftervalidate

            '-----------------------------------------------
        Catch ex As Exception
            msgbox(ex.Message)

        End Try
    End Sub
    Public Sub Update1()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select max(uploadid) as uploadid from TblTradesUpload where updateFlag=1", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "TblTradesUpload")
            If (ds.Tables(0).Rows.Count > 0) Then
                Dim i As Integer
                Dim dsi As New DataSet
                cmd = New SqlCommand("select * from TblTradesUpload where updateflag=1 and uploadid=" & ds.Tables(0).Rows(0).Item("uploadid").ToString & "", cn)
                adp = New SqlDataAdapter(cmd)
                adp.Fill(dsi, "TblTradesUpload")

                For i = 0 To dsi.Tables(0).Rows.Count - 1
                    If (dsi.Tables(0).Rows(i).Item("initDealType").ToString = "BUY") Then
                        cmd = New SqlCommand("insert into TblSettlementData values ('" & dsi.Tables(0).Rows(i).Item("broker_init").ToString & "','" & dsi.Tables(0).Rows(i).Item("InitDealType").ToString & "'," & dsi.Tables(0).Rows(i).Item("Quantity").ToString & ",'" & dsi.Tables(0).Rows(i).Item("company").ToString & "'," & dsi.Tables(0).Rows(i).Item("uploadid").ToString & ",'" & dsi.Tables(0).Rows(i).Item("DealDateTime").ToString & "',1," & dsi.Tables(0).Rows(i).Item("DealPrice").ToString & ",'" & dsi.Tables(0).Rows(i).Item("TransID").ToString & "')", cn)
                        If (cn.State = ConnectionState.Open) Then
                            cn.Close()
                        End If
                        cn.Open()
                        cmd.ExecuteNonQuery()
                        cn.Close()

                        cmd = New SqlCommand("insert into TblSettlementData values ('" & dsi.Tables(0).Rows(i).Item("broker_Target").ToString & "','" & dsi.Tables(0).Rows(i).Item("TargetDealType").ToString & "'," & dsi.Tables(0).Rows(i).Item("Quantity").ToString * -1 & ",'" & dsi.Tables(0).Rows(i).Item("company").ToString & "'," & dsi.Tables(0).Rows(i).Item("uploadid").ToString & ",'" & dsi.Tables(0).Rows(i).Item("DealDateTime").ToString & "',1," & dsi.Tables(0).Rows(i).Item("DealPrice").ToString & ",'" & dsi.Tables(0).Rows(i).Item("TransID").ToString & "')", cn)
                        If (cn.State = ConnectionState.Open) Then
                            cn.Close()
                        End If
                        cn.Open()
                        cmd.ExecuteNonQuery()
                        cn.Close()

                    End If

                    If (dsi.Tables(0).Rows(i).Item("initDealType").ToString = "SELL") Then
                        cmd = New SqlCommand("insert into TblSettlementData values ('" & dsi.Tables(0).Rows(i).Item("broker_init").ToString & "','" & dsi.Tables(0).Rows(i).Item("InitDealType").ToString & "'," & dsi.Tables(0).Rows(i).Item("Quantity").ToString * -1 & ",'" & dsi.Tables(0).Rows(i).Item("company").ToString & "'," & dsi.Tables(0).Rows(i).Item("uploadid").ToString & ",'" & dsi.Tables(0).Rows(i).Item("DealDateTime").ToString & "',1," & dsi.Tables(0).Rows(i).Item("DealPrice").ToString & ",'" & dsi.Tables(0).Rows(i).Item("TransID").ToString & "')", cn)
                        If (cn.State = ConnectionState.Open) Then
                            cn.Close()
                        End If
                        cn.Open()
                        cmd.ExecuteNonQuery()
                        cn.Close()

                        cmd = New SqlCommand("insert into TblSettlementData values ('" & dsi.Tables(0).Rows(i).Item("broker_Target").ToString & "','" & dsi.Tables(0).Rows(i).Item("TargetDealType").ToString & "'," & dsi.Tables(0).Rows(i).Item("Quantity").ToString & ",'" & dsi.Tables(0).Rows(i).Item("company").ToString & "'," & dsi.Tables(0).Rows(i).Item("uploadid").ToString & ",'" & dsi.Tables(0).Rows(i).Item("DealDateTime").ToString & "',1," & dsi.Tables(0).Rows(i).Item("DealPrice").ToString & ",'" & dsi.Tables(0).Rows(i).Item("TransID").ToString & "')", cn)
                        If (cn.State = ConnectionState.Open) Then
                            cn.Close()
                        End If
                        cn.Open()
                        cmd.ExecuteNonQuery()
                        cn.Close()

                    End If

                Next

                '    Dim x As Integer
                '    Dim dsx As New DataSet
                '    cmd = New SqlCommand("select * from TblTradesUpload where updateflag=1 and uploadid=" & ds.Tables(0).Rows(0).Item("uploadid").ToString & " and initDealType='SELL'", cn)
                '    adp = New SqlDataAdapter(cmd)
                '    adp.Fill(dsx, "tbltradesupload")
                '    If (dsx.Tables(0).Rows.Count > 0) Then
                '        For x = 0 To dsx.Tables(0).Rows.Count - 1
                '            cmd = New SqlCommand("insert into TblSettlementData values ('" & dsx.Tables(0).Rows(x).Item("broker_target").ToString & "','" & dsx.Tables(0).Rows(x).Item("InitDealType").ToString & "'," & CInt(dsx.Tables(0).Rows(x).Item("Quantity").ToString) & ",'" & dsx.Tables(0).Rows(x).Item("company").ToString & "'," & dsx.Tables(0).Rows(x).Item("uploadid").ToString & ",'" & dsx.Tables(0).Rows(x).Item("DealDateTime").ToString & "',1," & dsx.Tables(0).Rows(x).Item("DealPrice").ToString & ")", cn)
                '            If (cn.State = ConnectionState.Open) Then
                '                cn.Close()
                '            End If
                '            cn.Open()
                '            cmd.ExecuteNonQuery()
                '            cn.Close()

                '        Next
                '    End If

            End If


            cmd = New SqlCommand("Update tblTradesUpload set UpdateFlag=0 where uploadID =" & ds.Tables(0).Rows(0).Item("uploadid").ToString & "", cn)
            If (cn.State = ConnectionState.Open) Then
                cn.Close()
            End If
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()
            getUploadStats()
            msgbox("Upload Complete")
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub Update()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select max(uploadid) as uploadid from TblTradesUpload where updateFlag=1", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "TblTradesUpload")
            If (ds.Tables(0).Rows.Count > 0) Then
                Dim i As Integer
                Dim dsi As New DataSet
                cmd = New SqlCommand("select * from TblTradesUpload where updateflag=1 and uploadid=" & ds.Tables(0).Rows(0).Item("uploadid").ToString & " and initDealType='BUY'", cn)
                adp = New SqlDataAdapter(cmd)
                adp.Fill(dsi, "TblTradesUpload")

                For i = 0 To dsi.Tables(0).Rows.Count - 1
                    cmd = New SqlCommand("insert into TblSettlementData values ('" & dsi.Tables(0).Rows(i).Item("broker_init").ToString & "','" & dsi.Tables(0).Rows(i).Item("InitDealType").ToString & "'," & dsi.Tables(0).Rows(i).Item("Quantity").ToString & ",'" & dsi.Tables(0).Rows(i).Item("company").ToString & "'," & dsi.Tables(0).Rows(i).Item("uploadid").ToString & ",'" & dsi.Tables(0).Rows(i).Item("DealDateTime").ToString & "',1," & dsi.Tables(0).Rows(i).Item("DealPrice").ToString & ",'" & dsi.Tables(0).Rows(i).Item("broker_init").ToString & "')", cn)
                    If (cn.State = ConnectionState.Open) Then
                        cn.Close()
                    End If
                    cn.Open()
                    cmd.ExecuteNonQuery()
                    cn.Close()

                Next

                Dim x As Integer
                Dim dsx As New DataSet
                cmd = New SqlCommand("select * from TblTradesUpload where updateflag=1 and uploadid=" & ds.Tables(0).Rows(0).Item("uploadid").ToString & " and initDealType='SELL'", cn)
                adp = New SqlDataAdapter(cmd)
                adp.Fill(dsx, "tbltradesupload")
                If (dsx.Tables(0).Rows.Count > 0) Then
                    For x = 0 To dsx.Tables(0).Rows.Count - 1
                        cmd = New SqlCommand("insert into TblSettlementData values ('" & dsx.Tables(0).Rows(x).Item("broker_target").ToString & "','" & dsx.Tables(0).Rows(x).Item("InitDealType").ToString & "'," & CInt(dsx.Tables(0).Rows(x).Item("Quantity").ToString) & ",'" & dsx.Tables(0).Rows(x).Item("company").ToString & "'," & dsx.Tables(0).Rows(x).Item("uploadid").ToString & ",'" & dsx.Tables(0).Rows(x).Item("DealDateTime").ToString & "',1," & dsx.Tables(0).Rows(x).Item("DealPrice").ToString & ")", cn)
                        If (cn.State = ConnectionState.Open) Then
                            cn.Close()
                        End If
                        cn.Open()
                        cmd.ExecuteNonQuery()
                        cn.Close()

                    Next
                End If

            End If


            cmd = New SqlCommand("Update tblTradesUpload set UpdateFlag=0 where uploadID =" & ds.Tables(0).Rows(0).Item("uploadid").ToString & "", cn)
            If (cn.State = ConnectionState.Open) Then
                cn.Close()
            End If
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()
            getUploadStats()
            msgbox("Upload Complete")
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub getUploadStats()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select max(uploadid) as uploadid from tbltradesUpload ", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "tblTradesUpload")


            Dim dsi As New DataSet
            cmd = New SqlCommand("select distinct count(transId) as [Trades], Company ,SUM(Quantity) as [Traded Volumes] from TblTradesUpload where uploadid=" & ds.Tables(0).Rows(0).Item("uploadid").ToString & " group by  Company ", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(dsi, "tblTradesUpload")

            If (dsi.Tables(0).Rows.Count > 0) Then
                grdUploadStats.DataSource = dsi.Tables(0)
                grdUploadStats.DataBind()
            Else
                grdUploadStats.DataSource = Nothing
                grdUploadStats.DataBind()
            End If


        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub rdSettlemts_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdSettlemts.CheckedChanged
        Try
            If (rdSettlemts.Checked = True) Then
                txtSettlementExport.Visible = False
                txtSettlementExport.Text = ""
                fDocument.Visible = True
                Label5.Text = "File Location"
                wk_status.Text = ""

            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub rdSettlemts0_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdSettlemts0.CheckedChanged
        Try
            If (rdSettlemts0.Checked = True) Then
                fDocument.Visible = False
                txtSettlementExport.Text = ""
                txtSettlementExport.Visible = True
                Label5.Text = "File Name"
                wk_status.Text = ""
                txtSettlementExport.Text = Session("brokercode").ToString
            End If

        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub rdSettlemts1_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdSettlemts1.CheckedChanged
        Try
            If (rdSettlemts1.Checked = True) Then
                txtSettlementExport.Visible = False
                txtSettlementExport.Text = ""
                fDocument.Visible = True
                Label5.Text = "File Location"
                wk_status.Text = ""
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    'Private Function cn1() As Object
    '    Throw New NotImplementedException
    'End Function

   
    Protected Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        'CSVTradesImport()
        'GetCSVData()
        CsvImport1()
        If (gv_gridview.Rows.Count > 0) Then
            Dim d2 As New DataSet
            cmd1 = New SqlCommand("select * from otc_data_import", cn)
            adp = New SqlDataAdapter(cmd1)
            adp.Fill(d2, "otc_data_import")
            Dim ImportID As Integer = 0
            If (d2.Tables(0).Rows.Count > 0) Then
                cmd1 = New SqlCommand("select max (importId) as importId from otc_data_import", cn)
                adp = New SqlDataAdapter(cmd1)
                Dim d3 As New DataSet
                adp.Fill(d3, "otc_data_import")

                ImportID = d3.Tables(0).Rows(0).Item("importid").ToString + 1
            Else
                ImportID = 1
            End If
            Dim i As Integer
            For i = 0 To gv_gridview.Rows.Count - 1
                cmd = New SqlCommand("Insert into OTC_Data_Import (company,buyorderNum,Quantity,SellOrderNum,Price,TradeDate,SettlementStatus,Importid) values ('" & gv_gridview.Rows(i).Cells(0).Text & "','" & gv_gridview.Rows(i).Cells(1).Text & "'," & CInt(gv_gridview.Rows(i).Cells(2).Text) & ",'" & gv_gridview.Rows(i).Cells(3).Text & "'," & CDbl(gv_gridview.Rows(i).Cells(4).Text) & ",'" & CDate(gv_gridview.Rows(i).Cells(5).Text) & "',0," & ImportID & ")", cn)
                If (cn.State = ConnectionState.Open) Then
                    cn.Close()
                End If
                cn.Open()
                cmd.ExecuteNonQuery()
                cn.Close()
            Next
            SettlementProcess()
            msgbox("Upload Complete")

        End If
    End Sub
    Public Sub SettlementProcess()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select * from otc_data_import where settlementStatus=0", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "otc_data_import")
            If (ds.Tables(0).Rows.Count > 0) Then
                Dim i As Integer = 0
                For i = 0 To ds.Tables(0).Rows.Count - 1
                    Dim dsi As New DataSet
                    cmd = New SqlCommand("select * from OrdersSummary where orderNumber='" & ds.Tables(0).Rows(i).Item("BuyOrderNum").ToString & "' and ApprovalFlag = 1", cn)
                    adp = New SqlDataAdapter(cmd)
                    adp.Fill(dsi, "OrdersSummary")
                    If (dsi.Tables(0).Rows.Count > 0) Then
                        Dim TplusDate As Date = CDate(ds.Tables(0).Rows(i).Item("tradedate").ToString).AddDays(3)
                        cmd = New SqlCommand("insert into settlement_movement (company,cds_number,trans_type,quantity,date,source,uploadId,UpdateState,Order_Quantity,TplusDealDate) values ('" & ds.Tables(0).Rows(i).Item("company").ToString & "','" & dsi.Tables(0).Rows(0).Item("cds_number").ToString & "','BUY'," & ds.Tables(0).Rows(i).Item("quantity").ToString & ",'" & ds.Tables(0).Rows(i).Item("tradedate").ToString & "','" & ds.Tables(0).Rows(i).Item("sellOrderNum").ToString & "'," & ds.Tables(0).Rows(i).Item("importid").ToString & ",0," & ds.Tables(0).Rows(i).Item("price").ToString & ",'" & TplusDate & "')", cn)
                        If (cn.State = ConnectionState.Open) Then
                            cn.Close()
                        End If
                        cn.Open()
                        cmd.ExecuteNonQuery()
                        cn.Close()

                        cmd = New SqlCommand("insert into trans (company,cds_number,date_created,trans_time,shares,update_type,created_by,batch_ref,source,pledge_shares) values ('" & ds.Tables(0).Rows(i).Item("company").ToString & "','" & dsi.Tables(0).Rows(0).Item("cds_number").ToString & "','" & Now.Date & "','" & Date.Now.TimeOfDay.ToString & "'," & ds.Tables(0).Rows(i).Item("quantity").ToString & ",'BUY','SETTLEMENT',0,'S',0)", cn)
                        If (cn.State = ConnectionState.Open) Then
                            cn.Close()
                        End If
                        cn.Open()
                        cmd.ExecuteNonQuery()
                        cn.Close()
                    End If
                    'msgbox("Test")
                    Dim ros As New DataSet
                    cmd = New SqlCommand("select * from ordersSummary where orderNumber='" & ds.Tables(0).Rows(i).Item("SellOrderNum").ToString & "' and ApprovalFlag = 1", cn)
                    adp = New SqlDataAdapter(cmd)
                    adp.Fill(ros, "OrdersSummary")
                    If (ros.Tables(0).Rows.Count > 0) Then
                        Dim TplusDate1 As Date = CDate(ds.Tables(0).Rows(i).Item("tradedate").ToString).AddDays(3)
                        cmd = New SqlCommand("insert into settlement_movement (company,cds_number,trans_type,quantity,date,source,uploadId,updateState,Order_Quantity,TplusDealDate) values ('" & ds.Tables(0).Rows(i).Item("company").ToString & "','" & ros.Tables(0).Rows(0).Item("cds_number").ToString & "','SELL'," & CInt(ds.Tables(0).Rows(i).Item("quantity").ToString * -1) & ",'" & ds.Tables(0).Rows(i).Item("tradedate").ToString & "','" & ds.Tables(0).Rows(i).Item("BuyOrderNum").ToString & "'," & ds.Tables(0).Rows(i).Item("importid").ToString & ",0," & ds.Tables(0).Rows(i).Item("price").ToString & ",'" & TplusDate1 & "')", cn)
                        If (cn.State = ConnectionState.Open) Then
                            cn.Close()
                        End If
                        cn.Open()
                        cmd.ExecuteNonQuery()
                        cn.Close()

                        cmd = New SqlCommand("insert into trans (company,cds_number,date_created,trans_time,shares,update_type,created_by,batch_ref,source,pledge_shares) values ('" & ds.Tables(0).Rows(i).Item("company").ToString & "','" & ros.Tables(0).Rows(0).Item("cds_number").ToString & "','" & Now.Date & "','" & Date.Now.TimeOfDay.ToString & "'," & CInt(ds.Tables(0).Rows(i).Item("quantity").ToString * -1) & ",'SELL','SETTLEMENT',0,'S',0)", cn)
                        If (cn.State = ConnectionState.Open) Then
                            cn.Close()
                        End If
                        cn.Open()
                        cmd.ExecuteNonQuery()
                        cn.Close()
                    End If
                Next
            Else
                msgbox("Orders in file already exits")
                Exit Sub
            End If

            cmd = New SqlCommand("Update otc_data_import set settlementStatus= 1 where settlementStatus= 0", cn)
            If (cn.State = ConnectionState.Open) Then
                cn.Close()
            End If
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()

            cmd = New SqlCommand("Update OrdersSummary set Updated= 2, Approvalflag=2 where updated= 1 and Approvalflag=1", cn)
            If (cn.State = ConnectionState.Open) Then
                cn.Close()
            End If
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()

            Dim rex As New DataSet
            cmd = New SqlCommand("select sum(OrdersSummary .Order_Quantity) AS [InitOrders],OrdersSummary .OrderType , OrdersSummary .CDS_Number , sum(settlement_movement.quantity) as [SettledOrders], settlement_movement .cds_number,  OrdersSummary.Company  from OrdersSummary , settlement_movement where OrdersSummary.CDS_Number = settlement_movement.cds_number and settlement_movement.company = OrdersSummary.Company  and OrdersSummary .Updated = 1 and OrdersSummary .ApprovalFlag = 2 group by OrdersSummary .CDS_Number , settlement_movement .cds_number ,OrdersSummary .OrderType, OrdersSummary .Company ", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(rex, "OrdersSummary")
            If (rex.Tables(0).Rows.Count > 0) Then
                Dim p As Integer
                For p = 0 To rex.Tables(0).Rows.Count - 1
                    Dim InitOrder As Integer = 0
                    If (rex.Tables(0).Rows(p).Item("InitOrders").ToString < 0) Then
                        InitOrder = rex.Tables(0).Rows(p).Item("InitOrders").ToString * -1
                    Else
                        InitOrder = rex.Tables(0).Rows(p).Item("InitOrders").ToString
                    End If
                    Dim SettledOrders As Integer = 0
                    If (rex.Tables(0).Rows(p).Item("SettledOrders").ToString < 0) Then
                        SettledOrders = rex.Tables(0).Rows(p).Item("SettledOrders").ToString * -1
                    Else
                        SettledOrders = rex.Tables(0).Rows(p).Item("SettledOrders").ToString
                    End If

                    'msgbox("going to next")
                    If InitOrder - SettledOrders > 0 Then
                        Dim getMaxOrderNumber As Integer = 0
                        Dim ri As New DataSet
                        cmd = New SqlCommand("select max (orderRef) as orderRef from ordersSummary", cn)
                        adp = New SqlDataAdapter(cmd)

                        adp.Fill(ri, "Orderssummary")

                        getMaxOrderNumber = CInt(ri.Tables(0).Rows(0).Item("OrderRef").ToString) + 1

                        cmd = New SqlCommand("insert into OrdersSummary (OrderNumber,Company,Cds_Number,Order_Quantity,OrderValue,OrderType,OrderDate,PurchasingBroker,CapturedBy,Status,Updated,BasePrice,TargetDate,ExpiryDate,Orderattribute,OrderPreference,ApprovalFlag,MarketBoard,OrderQualifier) values (" & getMaxOrderNumber & ",'" & rex.Tables(0).Rows(p).Item("company").ToString & "','" & rex.Tables(0).Rows(p).Item("cds_number").ToString & "'," & CInt(InitOrder - SettledOrders) & ",0.0,'" & rex.Tables(0).Rows(p).Item("OrderType").ToString & "','" & Date.Now & "','" & Session("BrokerCode") & "','" & Session("Username") & "','C',0,0,'" & Now.Date & "','" & Now.Date & "','DAY ORDER','M',0,'NORMAL BOARD','IOC')", cn)
                        If cn.State = ConnectionState.Open Then
                            cn.Close()
                        End If
                        cn.Open()
                        cmd.ExecuteNonQuery()
                        cn.Close()
                    End If

                    'cmd = New SqlCommand()
                Next
            End If

        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub CsvImport1()
        Try
            Dim filePath As String = String.Empty
            Dim fileName2 As String = Path.GetFileName(FileUpload1.PostedFile.FileName)
            Dim fileLocation As String = Server.MapPath("~/CDSMode/ImportFiles/" & fileName2)
            FileUpload1.SaveAs(fileLocation)
            Try
                If FileUpload1.HasFile AndAlso FileUpload1.PostedFile.ContentType.Equals("application/vnd.ms-excel") Then
                    'gv_GridView.DataSource = DirectCast(ReadToEnd(FileUpload1.PostedFile.FileName), DataTable)
                    gv_gridview.DataSource = DirectCast(ReadToEnd(fileLocation), DataTable)
                    gv_gridview.DataBind()
                    lbl_ErrorMsg.Visible = False
                Else
                    'lbl_ErrorMsg.Text = "Please check the selected file type"
                    gv_gridview.DataSource = DirectCast(ReadToEnd(fileLocation), DataTable)
                    gv_gridview.DataBind()
                    'lbl_ErrorMsg.Visible = True
                End If
            Catch p As Exception
                lbl_ErrorMsg.Text = p.Message
            End Try
            
        Catch ex As Exception
            lbl_ErrorMsg.Text = ex.Message
            msgbox(ex.Message)
        End Try
    End Sub
    Private Function ReadToEnd(filePath As String) As Object
        Dim dtDataSource As New DataTable()
        Dim fileContent As String() = File.ReadAllLines(filePath)
        If fileContent.Length > 0 Then
            'Create data table columns
            Dim columns As String() = fileContent(0).Split(","c)
            For i As Integer = 0 To columns.Length - 1
                dtDataSource.Columns.Add(columns(i))
            Next

            'Add row data
            For i As Integer = 1 To fileContent.Length - 1
                Dim rowData As String() = fileContent(i).Split(","c)
                dtDataSource.Rows.Add(rowData)
            Next
        End If
        Return dtDataSource
    End Function

    Protected Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Try
            Dim rex As New DataSet
            cmd = New SqlCommand("select sum(OrdersSummary .Order_Quantity) AS [InitOrders],OrdersSummary .OrderType , OrdersSummary .CDS_Number , sum(settlement_movement.quantity) as [SettledOrders], settlement_movement .cds_number,  OrdersSummary.Company  from OrdersSummary , settlement_movement where OrdersSummary.CDS_Number = settlement_movement.cds_number and settlement_movement.company = OrdersSummary.Company  and OrdersSummary .Updated = 1 and OrdersSummary .ApprovalFlag = 2 group by OrdersSummary .CDS_Number , settlement_movement .cds_number ,OrdersSummary .OrderType, OrdersSummary .Company ", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(rex, "OrdersSummary")
            If (rex.Tables(0).Rows.Count > 0) Then
                Dim p As Integer
                For p = 0 To rex.Tables(0).Rows.Count - 1
                    Dim InitOrder As Integer = 0
                    If (rex.Tables(0).Rows(p).Item("InitOrders").ToString < 0) Then
                        InitOrder = rex.Tables(0).Rows(p).Item("InitOrders").ToString * -1
                    Else
                        InitOrder = rex.Tables(0).Rows(p).Item("InitOrders").ToString
                    End If
                    Dim SettledOrders As Integer = 0
                    If (rex.Tables(0).Rows(p).Item("SettledOrders").ToString < 0) Then
                        SettledOrders = rex.Tables(0).Rows(p).Item("SettledOrders").ToString * -1
                    Else
                        SettledOrders = rex.Tables(0).Rows(p).Item("SettledOrders").ToString
                    End If

                    If InitOrder - SettledOrders > 0 Then
                        Dim getMaxOrderNumber As Integer = 0
                        Dim ri As New DataSet
                        cmd = New SqlCommand("select max (orderRef) as orderRef from ordersSummary", cn)
                        adp = New SqlDataAdapter(cmd)

                        adp.Fill(ri, "Orderssummary")

                        getMaxOrderNumber = CInt(ri.Tables(0).Rows(0).Item("OrderRef").ToString) + 1

                        cmd = New SqlCommand("insert into OrdersSummary (OrderNumber,Company,Cds_Number,Order_Quantity,OrderValue,OrderType,OrderDate,PurchasingBroker,CapturedBy,Status,Updated,BasePrice,TargetDate,ExpiryDate,Orderattribute,OrderPreference,ApprovalFlag,MarketBoard,OrderQualifier) values (" & getMaxOrderNumber & ",'" & rex.Tables(0).Rows(p).Item("company").ToString & "','" & rex.Tables(0).Rows(p).Item("cds_number").ToString & "'," & CInt(InitOrder - SettledOrders) & ",0.0,'" & rex.Tables(0).Rows(p).Item("OrderType").ToString & "','" & Date.Now & "','" & Session("BrokerCode") & "','" & Session("Username") & "','C',0,0,'" & Now.Date & "','" & Now.Date & "','DAY ORDER','M',0,'NORMAL BOARD','IOC')", cn)
                        If cn.State = ConnectionState.Open Then
                            cn.Close()
                        End If
                        cn.Open()
                        cmd.ExecuteNonQuery()
                        cn.Close()
                    End If

                    'cmd = New SqlCommand()
                Next
                msgbox("complete")
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
End Class
