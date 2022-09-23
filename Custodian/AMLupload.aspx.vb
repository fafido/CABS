Imports System.Data
Imports System.Data.SqlClient
Imports System.IO

Partial Class AMLupload
    Inherits System.Web.UI.Page
    Dim constr As String = (System.Configuration.ConfigurationManager.AppSettings("connpath"))
    Dim cn As New SqlConnection(constr)
    Dim cmd As SqlCommand
    Dim cmd1 As New SqlCommand
    Dim adp As SqlDataAdapter
    Dim ds As New DataSet
    Dim maxholder As Integer = 0
    Dim cnstr As String = (System.Configuration.ConfigurationManager.AppSettings("connpath"))
    Dim cn1 As New SqlConnection(cnstr)
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
        Page.MaintainScrollPositionOnPostBack = True
        If (Not IsPostBack) Then
            If (Session("Username") = Nothing) Then
                Response.Redirect("~\loginsystem.aspx")
                Exit Sub
            End If
            'Label4.Text = "Logged on as " & Session("UserName").ToString & " of " & Session("UserCompany")
            Dim HourofDay As Integer = 0
            HourofDay = TimeOfDay.Hour
            If (HourofDay < 12) Then
                Label4.Text = "Good Morning " & Session("Username").ToString
            ElseIf (HourofDay >= 12 And HourofDay <= 17) Then
                Label4.Text = "Good Afternoon " & Session("Username").ToString
            Else
                Label4.Text = "Good Evening " & Session("username").ToString
            End If
            UpdatePastEvents()
            getlist()
            ASPxGridView1.Visible = True
        End If
    End Sub
    Public Sub UpdatePastEvents()
        Try
            cmd = New SqlCommand("update tbl_EventsDiary set EventFlag = 'C' where EventEndDate < '" & Now.Date & "'", cn)
            If (cn.State = ConnectionState.Open) Then
                cn.Close()
            End If
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub GetSecurities()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select distinct (security_name) from security_type", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "security_type")
            If (ds.Tables(0).Rows.Count > 0) Then

            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub ASPxButton2_Click(sender As Object, e As EventArgs) Handles ASPxButton2.Click
        Dim cmdix As New SqlCommand
        Dim adpix As New SqlDataAdapter

        Dim savePath As String = Server.MapPath("~\UPLOADS\")
        ' Get the name of the file to upload.
        Dim fileName As String = FileUpload1.FileName
        ' Append the name of the file to upload to the path.
        savePath += fileName
        ' Call the SaveAs method to save the uploaded
        ' file to the specified directory.
        FileUpload1.SaveAs(savePath)


        Dim connectionString As String = ""
        If FileUpload1.HasFile Then
            Dim fileName2 As String = Path.GetFileName(FileUpload1.PostedFile.FileName)
            Dim fileLocation As String = Server.MapPath("~/UPLOADS/" & fileName2)
            FileUpload1.SaveAs(fileLocation)
            Dim fileExtension As String = Path.GetExtension(FileUpload1.PostedFile.FileName)

            'Check whether file extension is xls or xslx

            If fileExtension = ".xls" Then
                connectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & fileLocation & ";Extended Properties=""Excel 8.0;HDR=Yes;IMEX=2"""
            ElseIf fileExtension = ".xlsx" Then
                connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & fileLocation & ";Extended Properties=""Excel 12.0;HDR=Yes;IMEX=2"""
            End If

            'Create OleDB Connection and OleDb Command

            Dim con As New OleDbConnection(connectionString)
            Dim cmd As New OleDbCommand()

            cmd.CommandType = System.Data.CommandType.Text
            cmd.Connection = con

            Dim dAdapter As New OleDbDataAdapter(cmd)

            Dim dtExcelRecords As New DataTable()

            con.Open()


            Dim dtExcelSheetName As DataTable = con.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, Nothing)
            Dim getExcelSheetName As String = dtExcelSheetName.Rows(0)("Table_Name").ToString()
            cmd.CommandText = "SELECT * FROM [" & getExcelSheetName & "]"
            dAdapter.SelectCommand = cmd
            dAdapter.Fill(dtExcelRecords)

            Dim x As Integer = 0
            For x = 0 To dtExcelRecords.Rows.Count - 1

                cmd1 = New SqlCommand("insert into AML_List (Account_name, Other_name, Mobile, Captured_by, id_number, [Type] ) values ('" & dtExcelRecords.Rows(x).Item(0).ToString & "','" & dtExcelRecords.Rows(x).Item(1).ToString & "','" & dtExcelRecords.Rows(x).Item(2).ToString & "','" & dtExcelRecords.Rows(x).Item(3).ToString & "','" & dtExcelRecords.Rows(x).Item(4).ToString & "','" + cmbtype.SelectedItem.Text + "')", cn1)
                cn1.Open()
                cmd1.ExecuteNonQuery()
                cn1.Close()
            Next
            getlist()

            msgbox("Successfully Uploaded!")
        End If

    End Sub
    Protected Sub getlist()
        cmd = New SqlCommand("select id as [System ID], Account_name as [Last Name], other_name as [Other Names], Mobile, ID_NUMBER AS [Identification], [Type] from AML_List", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "trans")
        If (ds.Tables(0).Rows.Count > 0) Then
            ASPxGridView1.DataSource = ds
            ASPxGridView1.DataBind()
            '    GetCashBal()
        Else
            ASPxGridView1.DataSource = Nothing
            ASPxGridView1.DataBind()

        End If
    End Sub
End Class
