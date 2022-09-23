Partial Class Dividend_DividendInstructions
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
    Public Sub getCompany()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("Select distinct (company ) from para_company", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "para_company")
            If (ds.Tables(0).Rows.Count > 0) Then
                cmbCompany.DataSource = ds.Tables(0)
                cmbCompany.DataValueField = "company"
                cmbCompany.DataBind()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Public Sub getLastDiv()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("Select top 1 div_no from div_instr where company='" & cmbCompany.Text & "' order by div_no desc", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "div_instr")
            If (ds.Tables(0).Rows.Count > 0) Then
                txtDivNo.Text = ((ds.Tables(0).Rows(0).Item("Div_No").ToString) + 1)
            Else
                txtDivNo.Text = "1"
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Public Sub getDivTypes()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("Select distinct(Divtype) from para_DivTypes", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "para_DivTypes")
            If (ds.Tables(0).Rows.Count > 0) Then
                cmdDivType.DataSource = ds.Tables(0)
                cmdDivType.DataValueField = "divType"
                cmdDivType.DataBind()
                getDividendFulType()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Public Sub getDividendFulType()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("Select distinct (DiviTypeName) from para_DivTypes where divType='" & cmdDivType.Text & "'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "divTypes")
            If (ds.Tables(0).Rows.Count > 0) Then
                LblDivType.Text = ds.Tables(0).Rows(0).Item("DiviTypeName").ToString
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Page.MaintainScrollPositionOnPostBack = True
            If (Not IsPostBack) Then
                getCompany()
                getLastDiv()
                getDivTypes()
                TxtScrip.Text = "0"
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Protected Sub cmdDivType_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdDivType.SelectedIndexChanged
        getDividendFulType()
    End Sub

    Protected Sub cmbCompany_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbCompany.SelectedIndexChanged
        getLastDiv()
    End Sub

    Protected Sub btnSaveDiv_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSaveDiv.Click
        Try
            Dim scrip As Integer
            If (BasicDatePicker1.Text = "") Then
                MsgBox("Select Dividend Annocment Date")
                Exit Sub
            End If
            If (BasicDatePicker2.Text = "") Then
                MsgBox("Select Dividend Record Date")
                Exit Sub
            End If
            If (BasicDatePicker3.Text = "") Then
                MsgBox("Select Dividend Payment Date")
                Exit Sub
            End If
            If (BasicDatePicker4.Text = "") Then
                MsgBox("Select Yearending Date")
                Exit Sub
            End If
            If (txtDivRate.Text = "") Then
                MsgBox("Enter a Dividend Rate")
                Exit Sub
            End If
            If (Not IsNumeric(txtBankAc.Text)) Then
                MsgBox("Enter a valid account Number")
                Exit Sub
            End If
            If (chkScrip.Checked = True) Then
                scrip = "1"
            Else
                Scrip = "0"
            End If
            cmd = New SqlCommand("insert into Div_Instr (company,div_no,div_type,date_declared,date_closed,date_payment,rate,mess_1,scrip_offer,scrip_price,scrip_round,entered_by,bank_accNo,date_yearending,Instruction_Date) values('" & cmbCompany.Text & "'," & txtDivNo.Text & ",'" & LblDivType.Text & "','" & BasicDatePicker1.Text & "','" & BasicDatePicker2.Text & "','" & BasicDatePicker3.Text & "'," & txtDivRate.Text & ",'" & txtDivNote.Text & "'," & scrip & "," & TxtScrip.Text & ",'" & CmbScripRound.Text & "','" & Session("UserName") & "'," & txtBankAc.Text & ",'" & BasicDatePicker4.Text & "','" & Date.Now & "')", cn)
            If (cn.State = ConnectionState.Open) Then
                cn.Close()
            End If
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()
            MsgBox("Instruction Created")
            getLastDiv()
            BasicDatePicker1.Clear()
            BasicDatePicker2.Clear()
            BasicDatePicker3.Clear()
            BasicDatePicker4.Clear()
            txtDivRate.Text = ""
            txtBankAc.Text = ""
            txtDivNote.Text = ""
            TxtScrip.Text = "0"
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Class
