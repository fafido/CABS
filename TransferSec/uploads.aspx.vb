Imports System.IO
Imports ClosedXML.Excel

Partial Class Depositor_uploads
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
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Page.MaintainScrollPositionOnPostBack = True
            If (Not IsPostBack) Then



            End If

        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub


    Protected Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click


        'Try

        If FileUpload1.HasFile Then

            If FileUpload1.HasFile Then

                    Dim cmdix As New SqlCommand
                    Dim adpix As New SqlDataAdapter

                    Dim savePath As String = Server.MapPath("~/Uploads/")
                    Dim strY As String = savePath
                    ' Get the name of the file to upload.
                    Dim fileName As String = FileUpload1.FileName
                    ' Append the name of the file to upload to the path.
                    savePath += fileName
                    ' Call the SaveAs method to save the uploaded
                    ' file to the specified directory.
                    FileUpload1.SaveAs(savePath)
                    ' txtFileLocation.Text = savePath.ToString

                    Dim conn As String = ""
                    'Server.MapPath("cdsimportedfile/
                    Dim fileName2 As String = Path.GetFileName(FileUpload1.PostedFile.FileName)
                    Dim addtofilename As String = "tab" & Date.Now.ToString("ddMMHmmss")
                    Dim fileLocation As String = Server.MapPath("~/Uploads/" & addtofilename & fileName2)
                    FileUpload1.SaveAs(fileLocation)
                    Dim fileExtension As String = Path.GetExtension(FileUpload1.PostedFile.FileName)

                    'Check whether file extension is xls or xslx

                    If fileExtension = ".xls" Then
                        conn = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & fileLocation & ";Extended Properties=""Excel 12.0;HDR=No;IMEX=1"""
                    ElseIf fileExtension = ".xlsx" Then
                        conn = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & fileLocation & ";Extended Properties=""Excel 12.0;HDR=No;IMEX=1"""
                    ElseIf fileExtension = ".csv" Then
                        conn = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & strY & ";Extended Properties=""text;HDR=No;FMT=Delimited"";"
                    Else
                        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "script", "alert('File Type Invalid');", True)
                        Exit Sub
                    End If
                    'Create OleDB Connection and OleDb Command
                    Dim conny As New OleDbConnection(conn)
                    Dim cmd As New OleDbCommand()

                    cmd.CommandType = System.Data.CommandType.Text
                    cmd.Connection = conny

                    Dim dAdapter As New OleDbDataAdapter(cmd)

                    Dim dtExcelRecords As New DataTable()

                    conny.Open()


                    Dim dtExcelSheetName As DataTable = conny.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, Nothing)
                    Dim getExcelSheetName As String = dtExcelSheetName.Rows(0)("Table_Name").ToString()
                    cmd.CommandText = "SELECT * FROM [" & getExcelSheetName & "]"
                    dAdapter.SelectCommand = cmd
                    dAdapter.Fill(dtExcelRecords)
                    Dim x As Integer
                For x = 5 To dtExcelRecords.Rows.Count - 1
                    '  Try


                    Dim cmd1 As New SqlCommand
                    Dim cmdStr As String = "INSERT INTO CashTrans_Audit (Description, TransType, Amount, DateCreated, TransStatus, CDS_Number,Paid, Reference,ChargeCode, Type  ) VALUES(@description,@transtype,@amount,getdate(),'0',@cds_No,NULL,@EWR_No,NULL,'BANK UPLOAD')"
                    cn.Open()
                    cmd1 = New SqlCommand(cmdStr, cn)

                    Dim ReferenceNo = fileName

                    Dim depdate = dtExcelRecords.Rows(x).Item(0).ToString.Replace("'", "''")
                    Dim name = dtExcelRecords.Rows(x).Item(1).ToString.Replace("'", "''")
                    Dim transId = dtExcelRecords.Rows(x).Item(2).ToString.Replace("'", "''")
                    Dim transRef = dtExcelRecords.Rows(x).Item(3).ToString.Replace("'", "''")
                    Dim cds_No = dtExcelRecords.Rows(x).Item(4).ToString.Replace("'", "''")
                    Dim EWR_No = dtExcelRecords.Rows(x).Item(5).ToString.Replace("'", "''")
                    Dim Amount = dtExcelRecords.Rows(x).Item(6).ToString.Replace("'", "''")

                    cmd1.Parameters.AddWithValue("@description", "Bank Upload")
                    cmd1.Parameters.AddWithValue("@transtype", "Bank Upload")
                    cmd1.Parameters.AddWithValue("@amount", Amount)
                    cmd1.Parameters.AddWithValue("@cds_No", cds_No)
                    cmd1.Parameters.AddWithValue("@EWR_No", EWR_No)




                    If cmd1.ExecuteNonQuery() Then

                    End If

                    cn.Close()
                    ' msgbox(updata)

                Next

                msgbox("Successfully Added! Awaiting Approval")
            Else
                msgbox("Please select File")
                Exit Sub
                End If

        End If

    End Sub




End Class
