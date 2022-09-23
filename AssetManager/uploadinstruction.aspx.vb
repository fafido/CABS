Imports System.IO
Imports ErrorLogging

Partial Class uploadinstruction
    Inherits System.Web.UI.Page
    Dim constr As String = (System.Configuration.ConfigurationManager.AppSettings("connpath"))
    Dim cn As New SqlConnection(constr)
    Dim adp As SqlDataAdapter
    Dim cmd As SqlCommand
    Public password, numb, codec As String
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

                getuploaded()

            End If




        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Shared Function CreateRandomPassword(ByVal PasswordLength As Integer) As String
        Dim _allowedChars As String = "0123456789"
        Dim randomNumber As New Random()
        Dim chars(PasswordLength - 1) As Char
        Dim allowedCharCount As Integer = _allowedChars.Length
        For i As Integer = 0 To PasswordLength - 1
            chars(i) = _allowedChars.Chars(CInt(Fix((_allowedChars.Length) * randomNumber.NextDouble())))
        Next i
        Return New String(chars)
    End Function
    Public Function checkupload() As Boolean
        Dim filePath As String = FileUpload1.PostedFile.FileName
        Dim filename As String = Path.GetFileName(filePath)
        Dim ext As String = Path.GetExtension(filename)
        Dim contenttype As String = String.Empty
        'Set the contenttype based on File Extension
        Select Case ext
            Case ".doc"
                contenttype = ".doc"
                Exit Select
            Case ".docx"
                contenttype = ".docx"
                Exit Select
            Case ".jpg"
                contenttype = ".jpg"
                Exit Select
            Case ".jpeg"
                contenttype = ".jpeg"
                Exit Select
            Case ".png"
                contenttype = ".png"
                Exit Select
            Case ".gif"
                contenttype = ".gif"
                Exit Select
            Case ".pdf"
                contenttype = ".pdf"
                Exit Select
        End Select
        'If Session("numb") = "" Then
        '    numb = 5
        '    codec = CreateRandomPassword(Integer.Parse(numb))
        '    Session("numb") = codec
        'End If
        Dim docname As String = ""
        If txtdocumentname.SelectedItem.Text = "Other" Then
            docname = txtotherdoc.Text
            If docname = "" Then
                msgbox("Please enter document name!")
                Return False
            End If
        Else
            docname = txtdocumentname.Text
        End If
        If contenttype <> String.Empty Then
            Dim fs As Stream = FileUpload1.PostedFile.InputStream
            Dim br As New BinaryReader(fs)
            Dim bytes As Byte() = br.ReadBytes(fs.Length)

            'insert the file into database 
            Dim strQuery As String = "insert into Accounts_Documents" & "(doc_generated, Name, ContentType, Data,CreatedBy)" & " values (@doc_generated,@Name, @ContentType, @Data,@CreatedBy)"
            Dim cmd As New SqlCommand(strQuery)
            cmd.Parameters.Add("@doc_generated", SqlDbType.VarChar).Value = Session("Username")
            cmd.Parameters.Add("@Name", SqlDbType.VarChar).Value = "" + docname + ""
            cmd.Parameters.Add("@ContentType", SqlDbType.VarChar).Value = contenttype
            cmd.Parameters.Add("@Data", SqlDbType.Binary).Value = bytes

            cmd.Parameters.Add("@CreatedBy", SqlDbType.VarChar).Value = "" + Session("Username") + ""
            InsertUpdateData(cmd)
            Return True
        Else
            msgbox("File format not recognised." _
            & " Upload Image/Word/PDF formats")
            Return False
        End If
    End Function
    Public Function InsertUpdateData(ByVal cmd As SqlCommand) As Boolean
        Dim strConnString As String = (System.Configuration.ConfigurationManager.AppSettings("connpath"))
        Dim con As New SqlConnection(strConnString)
        cmd.CommandType = CommandType.Text
        cmd.Connection = con
        Try
            con.Open()
            cmd.ExecuteNonQuery()
            Return True
        Catch ex As Exception
            Response.Write(ex.Message)
            Return False
        Finally
            con.Close()
            con.Dispose()
        End Try
    End Function
    Public Sub pd()
        Dim strQuery As String = "select Name, ContentType, Data from accounts_documents where id='" + ViewState("ID").ToString + "'"
        Dim cmd As SqlCommand = New SqlCommand(strQuery)
        cmd.Parameters.Add("@id", SqlDbType.Int).Value = 4
        Dim dt As DataTable = GetData(cmd)
        If dt IsNot Nothing Then
            download(dt)
        End If
    End Sub
    Public Sub word()
        Dim strQuery As String = "select Name, ContentType, Data from accounts_documents where id='" + ViewState("ID").ToString + "'"
        Dim cmd As SqlCommand = New SqlCommand(strQuery)
        cmd.Parameters.Add("@id", SqlDbType.Int).Value = 1
        Dim dt As DataTable = GetData(cmd)
        If dt IsNot Nothing Then
            download(dt)
        End If
    End Sub
    Public Sub xls()
        Dim strQuery As String = "select Name, ContentType, Data from accounts_documents where id='" + ViewState("ID").ToString + "'"
        Dim cmd As SqlCommand = New SqlCommand(strQuery)
        cmd.Parameters.Add("@id", SqlDbType.Int).Value = 2
        Dim dt As DataTable = GetData(cmd)
        If dt IsNot Nothing Then
            download(dt)
        End If
    End Sub
    Public Sub Img()
        Dim strQuery As String = "select Name, ContentType, Data from accounts_documents where id='" + ViewState("ID").ToString + "'"
        Dim cmd As SqlCommand = New SqlCommand(strQuery)
        cmd.Parameters.Add("@id", SqlDbType.Int).Value = 3
        Dim dt As DataTable = GetData(cmd)
        If dt IsNot Nothing Then
            download(dt)
        End If
    End Sub
    Protected Sub download(ByVal dt As DataTable)

        '  If ds.Tables("ck").Rows.Count > 0 Then
        Dim bytes() As Byte = CType(dt.Rows(0)("Data"), Byte())
        Response.Buffer = True
        Response.Charset = ""
        Response.Cache.SetCacheability(HttpCacheability.NoCache)
        Response.ContentType = dt.Rows(0)("ContentType").ToString()

        ' Response.ContentType = ds.Tables("ck").Rows(0).Item("ContentType").ToString
        'Response.AddHeader("content-disposition", "attachment;filename=" & dt.Rows(0)("Name").ToString())
        Response.AddHeader("content-disposition", "attachment;filename=""" + dt.Rows(0)("Name").ToString() + "" + dt.Rows(0)("ContentType").ToString() + "")
        Response.BinaryWrite(bytes)
        Response.Flush()
        Response.End()

        ' End If

    End Sub

    Public Function GetData(ByVal cmd As SqlCommand) As DataTable
        Dim dt As New DataTable
        Dim strConnString As String = (System.Configuration.ConfigurationManager.AppSettings("connpath"))
        Dim con As New SqlConnection(strConnString)
        Dim sda As New SqlDataAdapter
        cmd.CommandType = CommandType.Text
        cmd.Connection = con
        Try
            con.Open()
            sda.SelectCommand = cmd
            sda.Fill(dt)
            Return dt
        Catch ex As Exception
            Response.Write(ex.Message)
            Return Nothing
        Finally
            con.Close()
            sda.Dispose()
            con.Dispose()
        End Try
    End Function
    Protected Sub ASPxGridView1_RowCommand(sender As Object, e As DevExpress.Web.ASPxGridView.ASPxGridViewRowCommandEventArgs) Handles ASPxGridView1.RowCommand
        Try
            Dim myID As String = e.CommandArgs.CommandArgument.ToString
            ViewState("ID") = myID.ToString
            If e.CommandArgs.CommandName = "Delete" Then
                Using cn = New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("connpath"))
                    Using cmd As New SqlCommand("DELETE FROM Accounts_Documents WHERE ID='" & myID & "'", cn)
                        If cn.State = ConnectionState.Open Then cn.Close()
                        cn.Open()
                        cmd.ExecuteNonQuery()
                        cn.Close()
                        getuploaded()
                    End Using
                End Using

            ElseIf e.CommandArgs.CommandName = "view" Then
                Try
                    pd()
                Catch ex As Exception

                End Try
                Try
                    word()
                Catch ex As Exception

                End Try

                Try
                    xls()
                Catch ex As Exception

                End Try
                Try
                    Img()
                Catch ex As Exception

                End Try

            End If
        Catch ex As Exception
        End Try
    End Sub

    Public Sub getuploaded()
        Dim dsid2 As New DataSet

        cmd = New SqlCommand("select id, name, contenttype from accounts_documents where CreatedBy='" & Session("Username") & "' and doc_generated='" + Session("Username") + "'", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(dsid2, "jointn")
        If (dsid2.Tables(0).Rows.Count > 0) Then
            ASPxGridView1.DataSource = dsid2
            ASPxGridView1.DataBind()
        Else
            ASPxGridView1.DataSource = Nothing
            ASPxGridView1.DataBind()
        End If
    End Sub
    Protected Sub ASPxButton10_Click(sender As Object, e As EventArgs) Handles ASPxButton10.Click
        If checkupload() = True Then
            getuploaded()
            txtdocumentname.Text = ""
            txtotherdoc.Text = ""
            msgbox("Document Uploaded")
        End If
    End Sub

End Class
