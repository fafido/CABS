Imports System.Net.Mail
Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Imports System
Imports System.Configuration
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls
Imports System.Web.Services
Imports System.Collections.Generic
Imports DevExpress.Web.ASPxEditors
Imports DevExpress.Web.ASPxGridView

Partial Class Corp_BankUploadsOther
    Inherits System.Web.UI.Page
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
    Protected Sub btnPost_Click(sender As Object, e As EventArgs) Handles btnPost.Click
        If fileupload1.HasFile = False Then
            msgbox("Select File")
            Exit Sub
        End If
        If IsDate(txtASAT.Text) = False Then
            msgbox("Select Upload Date")
            Exit Sub
        End If
        Dim connectionString As String = ""
        Dim fileName2 As String = Path.GetFileName(fileupload1.PostedFile.FileName)
        Dim fileLocation As String = Server.MapPath("~/uploads/bank_" & Date.Now.ToString("ddMMyyyymmsss") & fileName2)
        fileupload1.SaveAs(fileLocation)
        Dim fileExtension As String = Path.GetExtension(fileupload1.PostedFile.FileName)
        If fileExtension = ".xls" Then
            connectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & fileLocation & ";Extended Properties=""Excel 8.0;HDR=Yes;IMEX=1"""
        ElseIf fileExtension = ".xlsx" Then
            connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & fileLocation & ";Extended Properties=""Excel 12.0;HDR=Yes;IMEX=1"""
        Else
            msgbox("File Type Invalid")
            Exit Sub
        End If
        'Create OleDB Connection and OleDb Command
        Dim conn As New OleDbConnection(connectionString)
        Dim cmd As New OleDbCommand()
        cmd.CommandType = System.Data.CommandType.Text
        cmd.Connection = conn
        Dim dAdapter As New OleDbDataAdapter(cmd)
        Dim dtExcelRecords As New DataTable()
        conn.Open()
        Dim dtExcelSheetName As DataTable = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, Nothing)
        Dim getExcelSheetName As String = dtExcelSheetName.Rows(0)("Table_Name").ToString()
        cmd.CommandText = "Select * FROM [" & getExcelSheetName & "]"
        dAdapter.SelectCommand = cmd
        dAdapter.Fill(dtExcelRecords)
        Dim x As Integer = 0
        Try
            btnPost.Enabled = False
            For x = 0 To dtExcelRecords.Rows.Count - 1
                Dim dr = dtExcelRecords.Rows(x)
                If IsNumeric(dr.Item(1)) = True Then
                    Dim cmdStr As String = " "
                    cmdStr = cmdStr & "      DELETE H FROM Account_Balances_History H WHERE H.AccountNumber=@AccountNumber and H.Currency=@Currency AND H.Bank=@Bank AND H.datecreated=convert(date,@datecreated)   "
                    cmdStr = cmdStr & "      insert into Account_Balances_History ([AccountName],[Balance],[Currency],[Category],[Status],[ClientType],[Branch],[AccountNumber],[datecreated],[Bank],[UploadBy])values(@AccountName,@Balance,@Currency,@Category,@Status,@ClientType,@Branch,@AccountNumber,@datecreated,@Bank,@UploadBy)         "
                    cmdStr = cmdStr & "      insert into Account_Balances_HistoryAUDIT ([AccountName],[Balance],[Currency],[Category],[Status],[ClientType],[Branch],[AccountNumber],[datecreated],[Bank],[UploadBy])values(@AccountName,@Balance,@Currency,@Category,@Status,@ClientType,@Branch,@AccountNumber,@datecreated,@Bank,@UploadBy)    "

                    Using cn = New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("connpath"))
                        Using cmd2 As New SqlCommand(cmdStr, cn)
                            cmd2.Parameters.AddWithValue("@AccountName", dr.Item(0).ToString)
                            cmd2.Parameters.AddWithValue("@Balance", dr.Item(1))
                            cmd2.Parameters.AddWithValue("@Currency", dr.Item(2).ToString)
                            cmd2.Parameters.AddWithValue("@Category", dr.Item(3).ToString)
                            cmd2.Parameters.AddWithValue("@Status", dr.Item(4).ToString)
                            cmd2.Parameters.AddWithValue("@ClientType", dr.Item(5).ToString)
                            cmd2.Parameters.AddWithValue("@Branch", dr.Item(6).ToString)
                            cmd2.Parameters.AddWithValue("@AccountNumber", dr.Item(7).ToString)
                            cmd2.Parameters.AddWithValue("@datecreated", txtASAT.Text)
                            cmd2.Parameters.AddWithValue("@Bank", dr.Item(8).ToString)
                            cmd2.Parameters.AddWithValue("@UploadBy", Session("Username"))
                            cn.Open()
                            cmd2.ExecuteNonQuery()
                            cn.Close()
                        End Using
                    End Using
                End If
            Next
            conn.Close()
        Catch ex As Exception
            conn.Close()
            ErrorLogging.WriteLogFile2(ex.ToString)
            msgbox("Error occured, check file format: " & ex.Message.ToString)
        End Try
        Response.Write("<script>alert('upload successful') ; location.href='BankUploadsOther.aspx'</script>")
    End Sub
    Protected Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        If IsDate(txtASAT.Text) = True Then
            Dim queryString As String = ""
            queryString = "BankUploadsReport.aspx?ASATDate=" & txtASAT.Text & ""
            Dim newWin As String = "window.open('" + queryString + "','_blank');"
            ClientScript.RegisterStartupScript(Me.GetType(), "pop", newWin, True)
        Else
            msgbox("Select date")
        End If
    End Sub
End Class
