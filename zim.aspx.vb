
Imports System.IO
Imports System.Net
Imports Microsoft.VisualBasic.FileIO

Partial Class Defaultet
    Inherits System.Web.UI.Page
    Dim cnstr As String = System.Configuration.ConfigurationManager.AppSettings("connpathTEST")
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        test2()
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
    Public Function GetCSV(ByVal url As String) As String
        Dim results As String
        Dim req As HttpWebRequest = CType(WebRequest.Create(url), HttpWebRequest)
        Dim resp As HttpWebResponse = CType(req.GetResponse(), HttpWebResponse)
        Dim sr As StreamReader = New StreamReader(resp.GetResponseStream())
        results = sr.ReadToEnd()
        sr.Close()
        Return results
    End Function
    Sub test2()
        Dim line As String
        Dim FilePath As String = "C:\CTRADE\20211012.txt"
        ' Create new StreamReader instance with Using block.
        Using reader As StreamReader = New StreamReader(FilePath)
            ' Read one line from file
            line = reader.ReadLine
        End Using
        msgbox(line)
        ' Write the line we read from "file.txt"
        'Console.WriteLine(line)
    End Sub
    Public Sub UploadACC()
        Dim fileList As String
        Dim tempStr As String()
        fileList = GetCSV("C:\inetpub\wwwroot\CTRADE\fido.txt")
        tempStr = fileList.Split(","c)
        Dim i As Integer = 0
        For Each row As String In fileList.Split(ControlChars.Lf)
            Dim records = row.Split(","c)
            msgbox(records(1).ToString.Replace("'", "''"))
        Next
    End Sub
End Class
