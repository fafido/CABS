Imports Microsoft.VisualBasic
Imports System.IO
Imports System.Web

Public Class ErrorLogging

    Public Shared Sub WriteLogFile(ByVal userName As String, pageName As String, ByVal message As String)
        Try

            If message <> "" And message <> "Thread was being aborted." And Not message.Contains("Thread was being aborted") Then
                Using file As New FileStream(HttpContext.Current.Server.MapPath("~/systemlog/log.txt"), FileMode.Append, FileAccess.Write)
                    Dim streamWriter As New StreamWriter(file)
                    streamWriter.WriteLine((((System.DateTime.Now & " - ") + userName & " - " + pageName & " - ")) + message)
                    streamWriter.Close()

                End Using
            End If
        Catch
        End Try
    End Sub
    Public Shared Sub WriteLogFile2(ByVal message As String)
        Using file As New FileStream(HttpContext.Current.Server.MapPath("~/systemlog/log.txt"), FileMode.Append, FileAccess.Write)
            Dim streamWriter As New StreamWriter(file)
            streamWriter.WriteLine(message)
            streamWriter.Close()
        End Using
    End Sub
End Class
