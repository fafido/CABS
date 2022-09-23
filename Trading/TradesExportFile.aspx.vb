Partial Class Trading_TradesExportFile
    Inherits System.Web.UI.Page
    Dim constr As String = (System.Configuration.ConfigurationManager.AppSettings("connpath"))
    Dim cn As New SqlConnection(constr)
    Dim cmd As SqlCommand
    Dim adp As SqlDataAdapter
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Page.MaintainScrollPositionOnPostBack = True
            If (Not IsPostBack) Then
               
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
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
    Protected Sub btnSelect_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSelect.Click
        Try
            If (txtFileName.Text = "") Then
                MsgBox("Enter a valid export file name")
                Exit Sub
            End If
            If (BasicDatePicker1.Text = "") Then
                MsgBox("Select a valid Date Range")
                Exit Sub
            End If
            If (BasicDatePicker2.Text = "") Then
                MsgBox("Select a valid Date Range")
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
            Dim orderVal As Double
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
            Dim filecmd As New SqlCommand("select * from ordersSummary where orderdate>='" & BasicDatePicker1.Text & "' and orderdate <= '" & BasicDatePicker2.Text & "' and status='C'", cn)
            Dim fileadp As New SqlDataAdapter(filecmd)
            Dim tempAmt As String = ""
            fileadp.Fill(file, "OrdersSummary")
            fname = txtFileName.Text + ".txt"
            Dim iRowNo As Integer
            Dim txAmt As String
            iRowNo = 0
            If (file.Tables(0).Rows.Count > 0) Then
                For i = 0 To file.Tables(0).Rows.Count - 1
                    OrderRef = (file.Tables(0).Rows(i).Item("OrderRef").ToString.PadLeft(6, "0"c))
                    holdernum = CStr(file.Tables(0).Rows(i).Item("cds_number").ToString.PadLeft(8, "0"c))
                    OrderNum = (file.Tables(0).Rows(i).Item("OrderNumber").ToString.PadLeft(6, "0"c))
                    txAmt = file.Tables(0).Rows(i).Item("OrderValue").ToString
                    txAmt = Left(file.Tables(0).Rows(i).Item("OrderValue"), InStrRev(file.Tables(0).Rows(i).Item("OrderValue"), ".") + 2)
                    txAmt = Replace(txAmt, ".", "")
                    orderVal = txAmt.PadLeft(12, "0"c)
                    orderQuant = (file.Tables(0).Rows(i).Item("Order_Quantity").ToString)
                    orderType = file.Tables(0).Rows(i).Item("OrderType").ToString.PadLeft(3, "0"c)
                    Broker = file.Tables(0).Rows(i).Item("PurchasingBroker").ToString.PadLeft(8, "0"c)
                    comp = file.Tables(0).Rows(i).Item("company").ToString.PadLeft(6, "x"c)
                    orderDate = Format(file.Tables(0).Rows(i).Item("OrderDate"), "yyyyMMdd")
                    iRowNo = i + 1
                    line = line + Left("ORD" & Space(3), 3) & Left(OrderRef & Space(6), 6) & Left(holdernum & Space(8), 8) & Left(OrderNum & Space(6), 6) & Left(orderQuant & Space(10), 10) & orderVal & Left(orderType & Space(3), 3) & Left(comp & Space(6), 6) & Left(Broker & Space(8), 8) & Left(orderDate & Space(8), 8)
                    My.Computer.FileSystem.WriteAllText("C:\" & fname, line & vbCrLf, True)
                    line = ""
                Next
                My.Computer.FileSystem.WriteAllText("C:\" & fname, line & vbCrLf, True)
                MsgBox("Electronic file exported successfully")
            Else
                MsgBox("no data to export in the trades section for the specified period")
                Exit Sub
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Class
