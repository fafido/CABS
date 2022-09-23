Partial Class Dividend_DividendEFTFile
    Inherits System.Web.UI.Page
    Dim constr As String = (System.Configuration.ConfigurationManager.AppSettings("connpath"))
    Dim cn As New SqlConnection(constr)
    Dim cmd As SqlCommand
    Dim adp As SqlDataAdapter
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
                getcompany()
                getDivno()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Public Sub getcompany()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("Select distinct (company) from div_instr", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "div_instr")
            If (ds.Tables(0).Rows.Count > 0) Then
                cmbCompany.DataSource = ds.Tables(0)
                cmbCompany.DataValueField = "company"
                cmbCompany.DataBind()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Public Sub getDivno()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select distinct (div_no) from div_instr where company='" & cmbCompany.Text & "'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "div_instr")
            If (ds.Tables(0).Rows.Count > 0) Then
                cmbDividend.DataSource = ds.Tables(0)
                cmbDividend.DataValueField = "div_no"
                cmbDividend.DataBind()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Protected Sub cmbCompany_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbCompany.SelectedIndexChanged
        Try
            getDivno()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Protected Sub btnSelect_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSelect.Click
        Try
            If (txtFileName.Text = "") Then
                MsgBox("Enter a valid export file name")
                Exit Sub
            End If
            Dim totholders As String
            Dim toteft As String
            Dim res As New DataSet
            Dim dTotEFT As Double
            cmd = New SqlCommand("select sum(actual_nett) as toteft,count(shareholder) as totholders from dividend where company='" & cmbCompany.Text & "' and div_no=" & cmbDividend.Text & " and eft =1", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(res, "dividend")
            dTotEFT = Left(res.Tables(0).Rows(0).Item("toteft"), InStrRev(res.Tables(0).Rows(0).Item("toteft"), ".") + 2)
            txteft.Text = dTotEFT
            toteft = Replace(CStr(txteft.Text), ".", "")
            txteftholders.Text = res.Tables(0).Rows(0).Item("totholders").ToString
            totholders = CStr(txteftholders.Text)

            Dim i As Integer = 0
            Dim EFT As New DataSet
            Dim divno As Integer
            ' Dim paymentdate As Date
            Dim paymentdate As String
            Dim holder As String = ""
            Dim holdername As String = ""
            Dim amount As String = ""
            Dim shares As Integer
            Dim comp As String = ""
            Dim bank As String = ""
            Dim branch As String = ""
            Dim acc As String = ""
            Dim pdate As String = ""
            Dim line As String = ""
            Dim file As New DataSet
            Dim fname As String = ""
            Dim filecmd As New SqlCommand("Select * from dividend where eft=1 and company='" & cmbCompany.Text & "' and div_no=" & cmbDividend.Text & "", cn)
            Dim fileadp As New SqlDataAdapter(filecmd)
            Dim tempAmt As String = ""
            fileadp.Fill(file, "dividend")
            fname = txtFileName.Text + ".txt"
            Dim iRowNo As Integer
            Dim txAmt As String
            iRowNo = 0
            If (file.Tables(0).Rows.Count > 0) Then
                For i = 0 To file.Tables(0).Rows.Count - 1
                    divno = (file.Tables(0).Rows(i).Item("div_no").ToString.PadLeft(4, "0"c))
                    holder = CStr(file.Tables(0).Rows(i).Item("shareholder").ToString.PadLeft(8, "0"c))
                    holdername = CStr(file.Tables(0).Rows(i).Item("holder").ToString.PadRight(50, " "c))
                    txAmt = file.Tables(0).Rows(i).Item("actual_nett").ToString
                    txAmt = Left(file.Tables(0).Rows(i).Item("actual_nett"), InStrRev(file.Tables(0).Rows(i).Item("actual_nett"), ".") + 2)
                    txAmt = Replace(txAmt, ".", "")
                    amount = txAmt.PadLeft(12, "0"c)
                    shares = (file.Tables(0).Rows(i).Item("shares_held").ToString)
                    bank = file.Tables(0).Rows(i).Item("bank").ToString.PadLeft(2, "0"c)
                    branch = file.Tables(0).Rows(i).Item("bank_branch").ToString.PadLeft(3, "0"c)
                    acc = file.Tables(0).Rows(i).Item("bank_ac").ToString.PadLeft(15, "0"c)
                    comp = file.Tables(0).Rows(i).Item("company").ToString.PadLeft(0, "x"c)
                    paymentdate = Format(file.Tables(0).Rows(i).Item("date_payment"), "yyyyMMdd")
                    iRowNo = i + 1
                    line = line + Left("DIV" & Space(3), 3) & CStr(iRowNo.ToString.PadLeft(4, "0"c)) & Left(branch & Space(6), 6) & Left(acc & Space(15), 15) & Left(holdername & Space(50), 50) & holder & amount & Left(paymentdate & Space(8), 8) & Left("Dividend Payment" & Space(16), 16)
                    My.Computer.FileSystem.WriteAllText("C:\" & fname, line & vbCrLf, True)
                    line = ""
                Next
                toteft = toteft.PadLeft(12, "0"c)
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
