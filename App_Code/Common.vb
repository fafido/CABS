Imports System.IO
Imports Microsoft.VisualBasic

Public Class Common
    Dim constr As String = (System.Configuration.ConfigurationManager.AppSettings("connpath"))
    Dim cn As New SqlConnection(constr)
    Dim adp As SqlDataAdapter
    Dim cmd As SqlCommand
    Public Function OTPenabled() As Boolean
        Dim ds As New DataSet
        cmd = New SqlCommand("select * from para_settings where Setting_Code='007'", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "names")
        If (ds.Tables(0).Rows.Count > 0) Then
            If ds.Tables(0).Rows(0).Item("Status").ToString = "Active" Then
                Return True
            Else
                Return False

            End If
        Else
            Return False
        End If
    End Function
    Public Function Document_Upload(str As Stream, Filepath As String, Documentname As String, ext As String, FileName As String, TransactionType As String, AccountNo As String, TransactionRef As String, Data As Byte()) As String
        Dim contenttype As String = String.Empty
        Select Case ext
            Case ".doc"
                contenttype = ".doc"
                Exit Select
            Case ".docx"
                contenttype = ".docx"
                Exit Select
            Case ".xls"
                contenttype = ".xls"
                Exit Select
            Case ".xlsx"
                contenttype = ".xlsx"
                Exit Select
            Case ".jpg"
                contenttype = ".jpg"
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

        If contenttype <> String.Empty Then


            'insert the file into database 
            Dim strQuery As String = " insert into Transaction_Documents (AccountNo, DocumentName, [FileName],Extension, TransactionType, TransactionRef, [Data], DateCreated) values (@AccountNo, @DocumentName, @Filename, @Extension, @TransactionType, @TransactionRef, @Data,getdate())"
            Dim cmd As New SqlCommand(strQuery)
            cmd.Parameters.Add("@AccountNo", SqlDbType.VarChar).Value = AccountNo
            cmd.Parameters.Add("@DocumentName", SqlDbType.VarChar).Value = Documentname
            cmd.Parameters.Add("@FileName", SqlDbType.VarChar).Value = FileName
            cmd.Parameters.Add("@Extension", SqlDbType.VarChar).Value = contenttype
            cmd.Parameters.Add("@TransactionType", SqlDbType.VarChar).Value = TransactionType
            cmd.Parameters.Add("@TransactionRef", SqlDbType.VarChar).Value = TransactionRef
            cmd.Parameters.Add("@Data", SqlDbType.Binary).Value = Data

            InsertUpdateData(cmd)

            Return "Upload Successful"
        Else

            Return "Error Upload"
        End If
    End Function
    Public Function InsertUpdateData(ByVal cmd As SqlCommand) As Boolean
        Dim strConnString As String = (System.Configuration.ConfigurationManager.AppSettings("connpath"))
        Dim con As New SqlConnection(strConnString)
        cmd.CommandType = CommandType.Text
        cmd.Connection = con
        'Try
        con.Open()
            cmd.ExecuteNonQuery()
            Return True
        'Catch ex As Exception
        '    Return False
        'Finally
        '    con.Close()
        '    con.Dispose()
        'End Try
    End Function



End Class
