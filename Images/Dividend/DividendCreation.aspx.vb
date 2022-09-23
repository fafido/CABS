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
            cmd = New SqlCommand("Select distinct (company ) from div_Instr", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "div_Instr")
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
            cmd = New SqlCommand("Select div_no from div_instr where company='" & cmbCompany.Text & "' order by div_no desc", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "div_instr")
            If (ds.Tables(0).Rows.Count > 0) Then
                cmbDividend.DataSource = ds.Tables(0)
                cmbDividend.DataValueField = "div_no"
                cmbDividend.DataBind()
                getDivdata()
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
                getDivdata()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Protected Sub cmbCompany_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbCompany.SelectedIndexChanged
        getLastDiv()
    End Sub
    Public Sub CreateDividend()

        Try
            If (cmbCompany.Text <> "" And cmbDividend.Text <> "") Then
                Dim command As SqlCommand = New SqlCommand("Proc_Create_Div", cn)
                command.CommandType = CommandType.StoredProcedure

                cn.Open()
                command.CommandTimeout = 3000
                command.Parameters.Add("@szUser", SqlDbType.VarChar).Value = Session("username")
                command.Parameters.Add("@wk_comp", SqlDbType.VarChar).Value = cmbCompany.Text
                command.Parameters.Add("@wk_div", SqlDbType.Decimal).Value = CInt(cmbDividend.Text)
                'msgbox(Session("username"))
                command.ExecuteNonQuery()
                cn.Close()
                MsgBox("Created")
            Else
                MsgBox("Enter the Necessary Fields")
                Exit Sub
            End If

        Catch ex As Exception
            cn.Close()
            msgbox(ex.Message)
        End Try

    End Sub
    Public Sub getDivdata()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("Select company,div_no,div_type,date_declared,date_closed,date_payment,rate,mess_1,scrip_offer,scrip_price,scrip_round,entered_by,bank_accNo,date_yearending,Instruction_Date from div_instr  where company='" & cmbCompany.Text & "' and div_no=" & cmbDividend.Text & "", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "div_instr")
            If (ds.Tables(0).Rows.Count > 0) Then
                txtDivTypes.Text = ds.Tables(0).Rows(0).Item("Div_Type").ToString
                txtDateAnn.Text = ds.Tables(0).Rows(0).Item("date_declared").ToString
                txtRecordDate.Text = ds.Tables(0).Rows(0).Item("date_closed").ToString
                txtPayments.Text = ds.Tables(0).Rows(0).Item("date_payment").ToString
                txtYearEnding.Text = ds.Tables(0).Rows(0).Item("date_Yearending").ToString
                txtDivRate.Text = ds.Tables(0).Rows(0).Item("rate").ToString
                txtBankAc.Text = ds.Tables(0).Rows(0).Item("bank_accNo").ToString
                txtDivNote.Text = ds.Tables(0).Rows(0).Item("mess_1").ToString
                TxtScrip.Text = ds.Tables(0).Rows(0).Item("scrip_price").ToString
                txtScripRound.Text = ds.Tables(0).Rows(0).Item("scrip_round").ToString
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Protected Sub btnSaveDiv_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSaveDiv.Click
        Try
            CreateDividend()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Protected Sub cmbDividend_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbDividend.SelectedIndexChanged
        Try
            getDivdata()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Class
