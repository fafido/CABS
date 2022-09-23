Imports System.Collections.Generic
Imports System.IO
Imports System.Net
Imports System.Web.Script.Serialization
Imports System.Xml
Imports Newtonsoft

Partial Class DividendPayAuthorize_New
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Page.MaintainScrollPositionOnPostBack = True
        If (Me.IsPostBack = False) Then
            PostRTGSTransaction()
        End If
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

    Private Sub PostRTGSTransaction()
        Dim rawResponse As String = String.Empty
        Dim strXmlInputData As String = String.Empty
        ' Try
            System.Net.ServicePointManager.ServerCertificateValidationCallback = Function(se As Object, cert As System.Security.Cryptography.X509Certificates.X509Certificate, chain As System.Security.Cryptography.X509Certificates.X509Chain, sslerror As System.Net.Security.SslPolicyErrors) True
            Dim request As HttpWebRequest = HttpWebRequest.Create("http://172.16.5.90:7006/T24CTRADE/services?wsdl")
            Dim bytes As Byte()
            strXmlInputData &= "<soapenv:Envelope xmlns:soapenv='http://schemas.xmlsoap.org/soap/envelope/' xmlns:ctr='http://temenos.com/ctrade'>"
            strXmlInputData &= "<soapenv:Header/>"
            strXmlInputData &= "<soapenv:Body>"
            strXmlInputData &= "<ctr:CTRADEBAL>"
            strXmlInputData &= "<WebRequestCommon>"
            strXmlInputData &= "<company>ZW0010001</company>"
            strXmlInputData &= "<password>Bcon@1212</password>"
            strXmlInputData &= "<userName>TCHISANDURO01</userName>"
            strXmlInputData &= "</WebRequestCommon>"
            strXmlInputData &= "<GETBALType>"
            strXmlInputData &= "<enquiryInputCollection>"
            strXmlInputData &= "<columnName>ACCT.NO</columnName>"
            strXmlInputData &= "<criteriaValue>1128888165</criteriaValue>"
            strXmlInputData &= "<operand>EQ</operand>"
            strXmlInputData &= "</enquiryInputCollection>"
            strXmlInputData &= "</GETBALType>"
            strXmlInputData &= "</ctr:CTRADEBAL>"
            strXmlInputData &= "</soapenv:Body>"
            strXmlInputData &= "</soapenv:Envelope>"
            bytes = System.Text.Encoding.ASCII.GetBytes(strXmlInputData)
            request.ContentType = "text/xml; encoding='utf-8'"
            request.ContentLength = bytes.Length
            request.Method = "POST"
            Dim requestStream As Stream = request.GetRequestStream()
            requestStream.Write(bytes, 0, bytes.Length)
            requestStream.Close()

            Dim FailedFlexiCube As New System.Xml.XmlDocument

            Using myWebResponse As WebResponse = request.GetResponse()
                Using myResponseStream As Stream = myWebResponse.GetResponseStream()
                    Using myStreamReader As StreamReader = New StreamReader(myResponseStream)
                        rawResponse = myStreamReader.ReadToEnd()
                        'rawResponse = Replace(rawResponse, "&lt;", "<")
                        'rawResponse = Replace(rawResponse, "&gt;", ">")
                    End Using
                End Using
            End Using
        ' Catch ex As Exception
            ' rawResponse = ex.Message.ToString
        ' End Try
    End Sub
End Class
