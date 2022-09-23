Partial Class Enquiries_sells
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
            If (Not IsPostBack) Then
                checkSessionState()
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub ClearData()
        Try
            txtClientNo.Text = ""
            txtTitle.Text = ""
            txtIDno.Text = ""
            txtForenames.Text = ""
            txtSurname.Text = ""
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Protected Sub ASPxButton2_Click(sender As Object, e As EventArgs) Handles ASPxButton2.Click
        Try
            If (txtClientNameSearch.Text <> "") Then
                Dim ds As New DataSet
                cmd = New SqlCommand("select cds_number+' '+surname+' '+forenames as namess from Accounts_Clients where surname+' '+forenames like '%" & txtClientNameSearch.Text & "%'", cn)
                adp = New SqlDataAdapter(cmd)
                adp.Fill(ds, "Accounts_Clients")
                If (ds.Tables(0).Rows.Count > 0) Then
                    lstNamesSearch.DataSource = ds.Tables(0)
                    lstNamesSearch.TextField = "namess"
                    lstNamesSearch.ValueField = "namess"
                    lstNamesSearch.DataBind()
                Else
                    lstNamesSearch.Items.Clear()
                End If
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub lstNamesSearch_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstNamesSearch.SelectedIndexChanged
        Try
            If (lstNamesSearch.Items.Count > 0) Then
                Dim ds As New DataSet
                cmd = New SqlCommand("select * from Accounts_Clients where cds_number+' '+surname+' '+forenames = '" & lstNamesSearch.SelectedItem.Text & "'", cn)
                adp = New SqlDataAdapter(cmd)
                adp.Fill(ds, "Accounts_Clients")
                If (ds.Tables(0).Rows.Count > 0) Then
                    txtClientNo.Text = ds.Tables(0).Rows(0).Item("cds_number").ToString.ToUpper
                    txtTitle.Text = ds.Tables(0).Rows(0).Item("title").ToString.ToUpper
                    txtIDno.Text = ds.Tables(0).Rows(0).Item("idnopp").ToString.ToUpper
                    txtForenames.Text = ds.Tables(0).Rows(0).Item("forenames").ToString.ToUpper
                    txtSurname.Text = ds.Tables(0).Rows(0).Item("surname").ToString.ToUpper
                    GetCashBal()
                    getissuers()
                    getinstruments()
                    getinstrumentstrans()

                Else
                    txtClientNo.Text = ""
                    txtTitle.Text = ""
                    txtIDno.Text = ""
                    txtForenames.Text = ""
                    txtSurname.Text = ""

                End If
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Public Sub GetCashBal()
        Dim ds As New DataSet
        cmd = New SqlCommand("select isnull(sum(Amount),0.0) as total from tbl_CashBalance where ClientID = '" & txtClientNo.Text & "'", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "Accounts_Clients")
        If (ds.Tables(0).Rows.Count > 0) Then

        End If

    End Sub
    Protected Sub ASPxButton3_Click(sender As Object, e As EventArgs) Handles ASPxButton3.Click
        If txtClientNo.Text = "" Then
            msgbox("Client Number Cannot Be Blank")
            Exit Sub
        End If

        If Not IsNumeric(txtunits.Text) Then
            msgbox("Units must be numbers only")
        End If

        If validatesellav.ToString = "Nothing" Then
            msgbox("You cannot sell more than your available Units")
            Exit Sub

        Else

        End If

        cmd = New SqlCommand("insert into trans_instruments (instrument, issuer, period, principal, face_value, maturity_date, purpose, units, client_no, date_added, update_status, price) values ('" + cmbinstrument.SelectedItem.Text + "', '" + cmbissuer.SelectedItem.Text + "','0', '0','0','01-01-1900','','-" + txtunits.Text + "','" + txtClientNo.Text + "',getdate(),0,'" + txtsellprice.Text + "')", cn)
        If (cn.State = ConnectionState.Open) Then
            cn.Close()
        End If
        cn.Open()
        cmd.ExecuteNonQuery()

        cn.Close()

        clearfields2()
        getinstrumentstrans()
        msgbox("Sent For Approval")

    End Sub
    Public Function validatesellav() As String
        Dim ds As New DataSet
        cmd = New SqlCommand("select isnull(sum(shares),0) as available from trans where cds_number='" + txtClientNo.Text + "' and company='" + cmbissuer.SelectedItem.Text + "' and instrument='" + cmbinstrument.SelectedItem.Text + "'", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "Accounts_Clients")
        If (ds.Tables(0).Rows.Count > 0) Then
            Dim ava As Decimal = ds.Tables(0).Rows(0).Item("available")
            Dim req As Decimal = txtunits.Text
            If ava < req Then
                Return "Nothing"
            Else
                Return "Something"
            End If
        Else
            Return "Nothing"
        End If
    End Function

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
            cashbal = CDbl(ds.Tables(0).Rows(0).Item(0).ToString) + CDbl(txtunits.Text)
        Else
            cashbal = txtunits.Text
        End If
        cmd = New SqlCommand("insert into  Deposits_Reg (ORDER_Number, CDS_Number, Deposit_Amount, Date_of_Deposit, Flag_Status) values (999999,'" & txtClientNo.Text & "'," & cashbal & ",GetDate(),'Open')", cn)
        If (cn.State = ConnectionState.Open) Then
            cn.Close()
        End If
        cn.Open()
        result = cmd.ExecuteNonQuery()
    End Sub
    Public Sub ClearFields()

        txtClientNo.Text = ""
        txtForenames.Text = ""
        txtIDno.Text = ""
        txtSurname.Text = ""
        txtTitle.Text = ""

    End Sub
    Public Sub clearfields2()
        cmbissuer.SelectedIndex = -1
        cmbinstrument.SelectedIndex = -1
        txtunits.Text = ""


    End Sub

    Protected Sub ASPxButton1_Click(sender As Object, e As EventArgs) Handles ASPxButton1.Click
        Try
            If (txtClientNameSearch.Text <> "") Then
                Dim ds As New DataSet
                cmd = New SqlCommand("select cds_number+' '+surname+' '+forenames as namess from Accounts_Clients where cds_number like '%" & txtClientNoSe.Text & "%'", cn)
                adp = New SqlDataAdapter(cmd)
                adp.Fill(ds, "Accounts_Clients")
                If (ds.Tables(0).Rows.Count > 0) Then
                    lstNamesSearch.DataSource = ds.Tables(0)
                    lstNamesSearch.TextField = "namess"
                    lstNamesSearch.ValueField = "namess"
                    lstNamesSearch.DataBind()
                Else
                    lstNamesSearch.Items.Clear()
                End If
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub getissuers()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select company from para_company where [status]='1'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "Accounts_Clients")
            If (ds.Tables(0).Rows.Count > 0) Then
                cmbissuer.DataSource = ds
                cmbissuer.TextField = "company"
                cmbissuer.DataBind()
            Else
                cmbissuer.Items.Clear()
            End If
        Catch ex As Exception

        End Try
    End Sub
    Public Sub getinstruments()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select code from para_instruments", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "Accounts_Clients")
            If (ds.Tables(0).Rows.Count > 0) Then
                cmbinstrument.DataSource = ds
                cmbinstrument.TextField = "code"
                cmbinstrument.DataBind()
            Else
                cmbinstrument.Items.Clear()
            End If
        Catch ex As Exception

        End Try
    End Sub
    Public Sub getinstrumentstrans()
        '     Try
        Dim ds As New DataSet
        cmd = New SqlCommand("select Instrument, Issuer, Period as [Period(Months)], principal as [Principal Amt], Face_value as [Face Value], Units, Price, Purpose, Maturity_date as [Maturity Date] from trans_instruments where client_no='" + txtClientNo.Text + "' and update_status='1'", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "Accounts_Clients")
        If (ds.Tables(0).Rows.Count > 0) Then
            ASPxGridView1.DataSource = ds
            ASPxGridView1.DataBind()

        Else

        End If
        'Catch ex As Exception

        'End Try
    End Sub
End Class
