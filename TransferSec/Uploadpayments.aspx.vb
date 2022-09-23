Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Imports System.Text
Imports Microsoft.VisualBasic.FileIO
Imports System.Net

Partial Class TransferSec_uploadpayments
    Inherits System.Web.UI.Page
    Dim constr As String = (System.Configuration.ConfigurationManager.AppSettings("connpath"))
    Dim cn As New SqlConnection(constr)
    Dim adp As SqlDataAdapter
    Dim cmd As SqlCommand
    Public allrec As String
    Public customernumber, customermessage As String

    Public Sub msgbox(ByVal strMessage As String)

        'finishes server processing, returns to client.
        Dim strScript As String = "<script language=JavaScript>"
        strScript += "window.alert(""" & strMessage & """);"
        strScript += "</script>"
        Dim lbl As New System.Web.UI.WebControls.Label
        lbl.Text = strScript
        Page.Controls.Add(lbl)

    End Sub
    Public Sub getpendingauth()
        Try
            Dim ds As New DataSet
            'cmd = New SqlCommand("select Tbl_MatchedOrders .Sellercdsno as [CDS No.] , Accounts_Clients.Surname +' '+Accounts_Clients .Forenames as [Client], Tbl_MatchedOrders .Quantity as [Quantity], Tbl_MatchedOrders.DealPrice as [Price], Tbl_MatchedOrders .Trade as [Trade Date] from Tbl_MatchedOrders , Accounts_Clients where Tbl_MatchedOrders.Sellercdsno = Accounts_Clients .CDS_Number and trade between '" & Datefrom & "' and '" & DateTo & "'", cn)
            cmd = New SqlCommand("select min(id) as min, max(id) as max from payment_SellOrder where Payment_Status='0'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "ids")
            If (ds.Tables("ids").Rows.Count > 0) Then

                For value As Integer = ds.Tables("ids").Rows(0).Item("min") To ds.Tables("ids").Rows(0).Item("max")


                    Dim ds1 As New DataSet
                    cmd = New SqlCommand("select * from payment_SellOrder where Payment_Status='0' and id='" + value.ToString + "'", cn)
                    adp = New SqlDataAdapter(cmd)
                    adp.Fill(ds1, "mobile")


                    If ds1.Tables("mobile").Rows.Count > 0 Then

                        '        sendsoapfile("" + ds1.Tables("mobile").Rows(0).Item("mobile") + "", ds1.Tables("mobile").Rows(0).Item("amount"), "" + ds1.Tables("mobile").Rows(0).Item("id") + "1030032234", "You have received " + ds1.Tables("mobile").Rows(0).Item("amount") + "Ksh from your sell of " + ds1.Tables("mobile").Rows(0).Item("quantity") + " Units. Thank You for using our services.")

                        sendsoapfile("254736812921", 66, "641030032234", "You have received using our services.")


                    End If

                Next

            Else

            End If

        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub pay2()
        Dim ds2 As New DataSet
        cmd = New SqlCommand("select * from payment_SellOrder where Payment_Status='0'", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds2, "tbl_SettlementSummary2")
        If (ds2.Tables(0).Rows.Count > 0) Then
            Dim i As Integer = 0
            For i = 0 To ds2.Tables(0).Rows.Count - 1
                Dim mystr As String = sendsoapfile("" + ds2.Tables("tbl_SettlementSummary2").Rows(i).Item("mobile").ToString + "", ds2.Tables("tbl_SettlementSummary2").Rows(i).Item("amount"), "" + ds2.Tables("tbl_SettlementSummary2").Rows(i).Item("id").ToString + "1233276882200", "You have received " + ds2.Tables("tbl_SettlementSummary2").Rows(i).Item("amount").ToString + "Ksh from your sell of " + ds2.Tables("tbl_SettlementSummary2").Rows(i).Item("quantity").ToString + " Units. Thank You for using our services.")
                ' msgbox(i)
            Next
            cmd = New SqlCommand("update payment_sellorder set payment_status='1'", cn)
            If (cn.State = ConnectionState.Open) Then
                cn.Close()
            End If
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()
        End If
    End Sub
    Public Sub insertAccounts()
        Try
            'Dim bankCode = cmbBanks.SelectedValue
            'Dim bankName = cmbBanks.SelectedItem.Text
            Dim fd As New DataSet
            fd = GetData()
            Dim rowcount As Integer = fd.Tables(0).Rows.Count
            Dim colcount As Integer = fd.Tables(0).Columns.Count
            For i = 0 To rowcount - 1
                Dim ID2 As Integer = 0
                Dim mobile As String = removeNULL(fd, i, 0)
                Dim quantity As String = removeNULL(fd, i, 2)
                Dim amount As String = removeNULL(fd, i, 1)

                cmd = New SqlCommand("insert into Payment_SellOrder (Mobile, Amount, Quantity, payment_status) values ('" + mobile + "','" + amount + "','" + quantity + "','0')", cn)
                If (cn.State = ConnectionState.Open) Then
                    cn.Close()
                End If
                cn.Open()
                cmd.ExecuteNonQuery()
                cn.Close()
               
            Next
            '  msgbox("Import successful")
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Private Function GetData() As DataSet
        'msgbox(Server.MapPath(FileUpload1.FileName).ToString)
        'Exit Function
        Dim strLine As String
        Dim strArray() As String
        Dim charArray() As Char = {"	"c}
        Dim ds As New DataSet()
        Dim dt As DataTable = ds.Tables.Add("TheData")
        FileUpload1.SaveAs(Server.MapPath("UploadFile/" & FileUpload1.FileName))
        createTabbedFile(Server.MapPath("UploadFile/" & FileUpload1.FileName), Server.MapPath("UploadFile/tab" & FileUpload1.FileName))
        Dim aFile As New FileStream(Server.MapPath("UploadFile/tab" & FileUpload1.FileName), FileMode.Open)
        Dim sr As New StreamReader(aFile)

        strLine = sr.ReadLine()
        strArray = strLine.Split(charArray)

        For x As Integer = 0 To strArray.GetUpperBound(0)
            dt.Columns.Add(strArray(x).Trim())
        Next x

        strLine = sr.ReadLine()
        Do While strLine IsNot Nothing
            strArray = strLine.Split(charArray)
            Dim dr As DataRow = dt.NewRow()
            For i As Integer = 0 To strArray.GetUpperBound(0)
                dr(i) = strArray(i).Trim()
            Next i
            dt.Rows.Add(dr)
            strLine = sr.ReadLine()
        Loop
        sr.Close()
        Return ds
    End Function
    Public Sub checkSessionState()
        Try

        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Page.MaintainScrollPositionOnPostBack = True
            If (Not IsPostBack) Then
                '       getpendingauth()
                '  MovingOrders()

                checkSessionState()

            End If
            If Session("finish") = "yes" Then
                Session("finish") = ""
                msgbox("Successfully Authorized")
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub









    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            insertAccounts()

            pay2()

        Catch ex As Exception

        End Try
       

    End Sub
    


 
    Public Sub createTabbedFile(ByVal csvFileFullPath As String, ByVal tabFileFullPath As String)
        'This routine uses the VB TextFieldParser class to properly parse the csv file and convert to a 
        'tab delimited file and subsequent tasks in the package can read from the tab file. Apparently the 
        'TaskFieldParser class does not have this limitation and it works as we expected. Besides it also 
        'provides an added feature where by you can trim extra spaces from text  fields. 

        Using tabStreamWriter As New StreamWriter(tabFileFullPath)
            Using csvFileReader As New TextFieldParser(csvFileFullPath)
                csvFileReader.TextFieldType = FieldType.Delimited
                csvFileReader.Delimiters = New String() {","}
                csvFileReader.HasFieldsEnclosedInQuotes = True
                csvFileReader.TrimWhiteSpace = True
                Dim currentRow As String()
                While Not (csvFileReader.EndOfData)
                    Try
                        Dim i As Int32 = 1
                        Dim outputRow As New Text.StringBuilder()
                        currentRow = csvFileReader.ReadFields()
                        For Each currentField As String In currentRow
                            'currentField = currentField.Replace(Chr(34), Chr(39)) 'replace double quote with single quote if needed
                            outputRow.Append(currentField)
                            If i < currentRow.Length Then
                                outputRow.Append(Chr(9)) 'add a tab for each field except last one
                            End If
                            i = i + 1
                        Next
                        tabStreamWriter.WriteLine(outputRow.ToString())
                    Catch ex As Microsoft.VisualBasic.FileIO.MalformedLineException
                        'Dts.TaskResult = Dts.Results.Failure
                    End Try
                End While
            End Using
        End Using
        'Dts.TaskResult = Dts.Results.Success
    End Sub
    Function removeNULL(ByVal myreader As DataSet, ByVal j As Integer, ByVal stval As Integer) As String

        Dim val As Object = myreader.Tables(0).Rows(j).Item(stval)
        If val IsNot DBNull.Value And val <> "" Then
            Return val.ToString()
        Else
            Return Convert.ToString(0)
        End If
    End Function
    Function sendsoapfile(ByVal CustMobile As String, ByVal CustAMT As String, ByVal CustREF As String, ByVal msg As String) As String
        System.Net.ServicePointManager.ServerCertificateValidationCallback = Function(se As Object, cert As System.Security.Cryptography.X509Certificates.X509Certificate, chain As System.Security.Cryptography.X509Certificates.X509Chain, sslerror As System.Net.Security.SslPolicyErrors) True
        Dim request As HttpWebRequest = WebRequest.Create("https://41.223.56.58:7203/BulkPayment.asmx")
        Dim bytes As Byte()
        Dim strXmlInputData As String = String.Empty
        'strXmlInputData &= "<?xml version='1.0' encoding='utf-8'?>"
        strXmlInputData &= "<soapenv:Envelope xmlns:soapenv='http://schemas.xmlsoap.org/soap/envelope/' xmlns:zain='http://www.zain.com/'>"
        strXmlInputData &= "<soapenv:Header/>"
        strXmlInputData &= "<soapenv:Body>"
        strXmlInputData &= "<zain:TrxPayment>"
        strXmlInputData &= "<zain:referenceid>" & CustREF & "</zain:referenceid>"
        strXmlInputData &= "<zain:customermsisdn>" & CustMobile & "</zain:customermsisdn>"
        strXmlInputData &= " <zain:nickname>MAKIBA</zain:nickname>"
        strXmlInputData &= "<zain:amount>" & CDbl(CustAMT) & "</zain:amount>"
        strXmlInputData &= "<zain:batchref>" & CustREF & "</zain:batchref>"
        strXmlInputData &= "<zain:username>MAKIBA</zain:username>"
        strXmlInputData &= "<zain:password>MAKIBA@4321</zain:password>"
        strXmlInputData &= "<zain:narrative>" & msg & "</zain:narrative>"
        strXmlInputData &= "</zain:TrxPayment>"
        strXmlInputData &= "</soapenv:Body>"
        strXmlInputData &= "</soapenv:Envelope>"
        bytes = System.Text.Encoding.ASCII.GetBytes(strXmlInputData)
        request.ContentType = "text/xml; encoding='utf-8'"
        request.ContentLength = bytes.Length
        request.Method = "POST"
        Dim requestStream As Stream = request.GetRequestStream()
        requestStream.Write(bytes, 0, bytes.Length)
        requestStream.Close()

        Using myWebResponse As WebResponse = request.GetResponse()
            Using myResponseStream As Stream = myWebResponse.GetResponseStream()
                Using myStreamReader As StreamReader = New StreamReader(myResponseStream)
                    Return myStreamReader.ReadToEnd()
                End Using
            End Using
        End Using
    End Function
End Class
