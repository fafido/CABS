Partial Class ChargeParticipantsAdhoc
    Inherits System.Web.UI.Page
    Dim constr As String = (System.Configuration.ConfigurationManager.AppSettings("connpath"))
    Dim cn As New SqlConnection(constr)
    Dim adp As SqlDataAdapter
    Dim cmd As SqlCommand
    Public Sub msgbox(ByVal strMessage As String)

        'finishes server processing, returns to client.
        Dim strScript As String = "<script language=JavaScript>"
        strScript += "window.alert(""" & strMessage & """);"
        strScript += "</script>"
        Dim lbl As New System.Web.UI.WebControls.Label
        lbl.Text = strScript
        Page.Controls.Add(lbl)

    End Sub
    Public Sub checkSessionState()
        Try

        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Page.MaintainScrollPositionOnPostBack = True
            'GetChargeCodes()
            If (Not IsPostBack) Then
                checkSessionState()
            End If
            If Session("finish") = "true" Then
                Session("finish") = ""
                msgbox("Deposit Saved")
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub GetChargeCodes()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("declare @ChargeType nvarchar(500)='Additional Fee (Other)' DECLARE @ParticipantType nvarchar(500)='" & getAccountType(txtClientNo.Text) & "' DECLARE @AccountID nvarchar(500) = '" & txtClientNo.Text & "' SELECT DISTINCT B.ChargeSUBType + ' ' +format(B.PercAmount,'#,###.00','en-us')+' '+B.ChargeInterval as chargeDesc,ChargeSUBType FROM (SELECT * FROM ParaCharge A WHERE A.ParticipantType=@ParticipantType AND A.ChargeType=@ChargeType )B  JOIN ParaChargeParticipant D ON B.ChargeCode=D.ChargeCode WHERE D.ParticipantCode IN ('ALL',@AccountID) --ORDER BY B.ID DESC", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "para_charges")
            If (ds.Tables(0).Rows.Count > 0) Then
                ' msgbox("Filled")
                cmbCounter.DataSource = ds.Tables(0)
                cmbCounter.ValueField = "ChargeSUBType"
                cmbCounter.TextField = "chargeDesc"
                cmbCounter.DataBind()
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub ClearData()
        Try
            txtClientNo.Text = ""
            '  txtTitle.Text = ""
            txtIDno.Text = ""
            txtForenames.Text = ""
            '  txtSurname.Text = ""
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Protected Sub ASPxButton2_Click(sender As Object, e As EventArgs) Handles ASPxButton2.Click
        Try
            ' If (txtClientNameSearch.Text <> "") Then
            Dim ds As New DataSet
            cmd = New SqlCommand("select company_code+' '+company_name as namess, company_code from client_companies where  company_code+' '+company_name  like '%" & txtClientNameSearch.Text & "%'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "Accounts_Clients")
            If (ds.Tables(0).Rows.Count > 0) Then
                lstNamesSearch.DataSource = ds.Tables(0)
                lstNamesSearch.TextField = "namess"
                lstNamesSearch.ValueField = "company_code"
                lstNamesSearch.DataBind()
            Else
                lstNamesSearch.Items.Clear()
            End If
            '  End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub lstNamesSearch_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstNamesSearch.SelectedIndexChanged

        If (lstNamesSearch.Items.Count > 0) Then
            Dim ds As New DataSet
            cmd = New SqlCommand("select * from client_companies where company_code = '" & lstNamesSearch.SelectedItem.Value.ToString & "'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "Accounts_Clients")
            If (ds.Tables(0).Rows.Count > 0) Then
                txtClientNo.Text = ds.Tables(0).Rows(0).Item("company_code").ToString.ToUpper
                ' txtTitle.Text = ds.Tables(0).Rows(0).Item("title").ToString.ToUpper
                txtIDno.Text = ds.Tables(0).Rows(0).Item("SECP").ToString.ToUpper
                txtForenames.Text = ds.Tables(0).Rows(0).Item("company_name").ToString.ToUpper
                '  txtSurname.Text = ds.Tables(0).Rows(0).Item("surname").ToString.ToUpper
                GetCashBal()
                GetChargeCodes()
            Else
                txtClientNo.Text = ""
                '  txtTitle.Text = ""
                txtIDno.Text = ""
                txtForenames.Text = ""
                '  txtSurname.Text = ""
            End If
        End If
    End Sub
    Public Sub GetCashBal()
        Dim ds As New DataSet
        cmd = New SqlCommand("select isnull(sum(Amount),0.0) as total from cashtrans where cds_Number = '" & txtClientNo.Text & "'", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "Accounts_Clients")
        If (ds.Tables(0).Rows.Count > 0) Then
            lblCashBal.Text = ds.Tables(0).Rows(0).Item("total").ToString.ToUpper
            If lblCashBal.Text > 0 Then
                lblCashBal.ForeColor = Drawing.Color.Green
                lblCashBal0.Visible = True
            Else
                lblCashBal.ForeColor = Drawing.Color.Red
                lblCashBal0.Visible = False
            End If
        End If
    End Sub
    Protected Sub ASPxButton3_Click(sender As Object, e As EventArgs) Handles ASPxButton3.Click
        If txtClientNo.Text = "" Then
            msgbox("Client Number Cannot Be Blank")
            Exit Sub
        End If

        If cmbCounter.Text = "" Then
            msgbox("Please select a charge code")
            Exit Sub
        End If

        If Not IsNumeric(txtAmount.Text) Then
            msgbox("Amount must be numbers only")
            Exit Sub
        End If

        Dim AccountType As String = getAccountType(txtClientNo.Text)
        Dim mycharge As New NaymatBilling
        mycharge.othercharges("BILL", AccountType, cmbCounter.Value, txtClientNo.Text, cmbCounter.Text, "No", 0)
        Session("finish") = "true"
        Response.Redirect(Request.RawUrl)
        ' End If
        cn.Close()
        ClearFields()
    End Sub

    Public Sub DepositReg()
        Dim result As Integer
        cmd = New SqlCommand("Update Deposits_Reg  Set Flag_Status='Closed' where CDS_Number='" & txtClientNo.Text & "'", cn)
        If (cn.State = ConnectionState.Open) Then
            cn.Close()
        End If
        cn.Open()
        cmd.ExecuteNonQuery()
        Dim cashbal As Double
        Dim ds As New DataSet
        cmd = New SqlCommand("select isnull(sum(Deposit_Amount),0.0) as total from Deposits_Reg where CDS_Number = '" & txtClientNo.Text & "'", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "Accounts_Clients")
        If (ds.Tables(0).Rows.Count > 0) Then
            cashbal = CDbl(ds.Tables(0).Rows(0).Item(0).ToString) + CDbl(txtAmount.Text)
        Else
            cashbal = txtAmount.Text
        End If
        cmd = New SqlCommand("insert into  Deposits_Reg (ORDER_Number, CDS_Number, Deposit_Amount, Date_of_Deposit, Flag_Status) values (999999,'" & txtClientNo.Text & "'," & cashbal & ",GetDate(),'Open')", cn)
        If (cn.State = ConnectionState.Open) Then
            cn.Close()
        End If
        cn.Open()
        result = cmd.ExecuteNonQuery()
    End Sub
    Public Sub ClearFields()
        txtAmount.Text = ""
        txtClientNo.Text = ""
        txtForenames.Text = ""
        txtIDno.Text = ""

        cmbCounter.SelectedIndex = -1
        chkCounter.Checked = False
    End Sub
    Function getAccountType(ByVal accNumber As String) As String
        Dim ds As New DataSet
        cmd = New SqlCommand("select Company_type from Client_Companies where Company_Code = '" & accNumber & "'", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "Client_Companies")
        If (ds.Tables(0).Rows.Count > 0) Then
            Return ds.Tables(0).Rows(0).Item("Company_type").ToString
        Else
            Return ""
        End If
    End Function
    Protected Sub cmbCounter_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbCounter.SelectedIndexChanged
        Try
            Dim AccountType As String = getAccountType(txtClientNo.Text)
            Dim mycharge As New NaymatBilling
            txtAmount.Text = Format(mycharge.othercharges("ENQUIRE", AccountType, cmbCounter.Value, txtClientNo.Text, cmbCounter.Text, "No", 0), "#,##0.00")
        Catch ex As Exception
        End Try
    End Sub
End Class
