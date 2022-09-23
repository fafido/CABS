Partial Class Parameters_RedemptionSchedule
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
                getcompanies()
                getinterestsrepayments()
            End If
            If Session("finish") = "true" Then
                Session("finish") = ""
                msgbox("Instruction Saved!")
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Protected Sub clearall()
        txtDesc.Text = ""
        txtinterest.Text = ""

    End Sub
    Public Sub getcompanies()
        cmd = New SqlCommand("select issuer+' Payment('+convert(nvarchar(50),payment_no)+')' as pay, id from capital_repayment_instr where Authorized=1", cn)
        Dim ds As New DataSet
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "companies")
        If ds.Tables(0).Rows.Count > 0 Then
            cmbsecurity.DataSource = ds
            cmbsecurity.TextField = "pay"
            cmbsecurity.ValueField = "id"
            cmbsecurity.DataBind()
        End If
    End Sub
    Public Function maxpaymentno(ByVal company As String) As Integer
        cmd = New SqlCommand("select isnull(max(payment_no),0)+1 as [PaymentNo] from capital_repayment_instr where issuer='" + company + "'", cn)
        Dim ds As New DataSet
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "companies")
        If ds.Tables(0).Rows.Count > 0 Then
            Return ds.Tables(0).Rows(0).Item("PaymentNo")
        Else
            Return 0
        End If
    End Function
    Public Sub getinterestsrepayments()
        cmd = New SqlCommand("select Issuer as [Company(ISIN)], PAYMENT_no as [Payment No], date_payment as [Payment Date], datecreated as [Creation Date], Case Authorized when 0 then 'Pending' else 'Completed' end as [Status] from capital_repayment_instr", cn)
        Dim ds As New DataSet
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "companies")
        If ds.Tables(0).Rows.Count > 0 Then
            ASPxGridView2.DataSource = ds
            ASPxGridView2.DataBind()
        End If
    End Sub

    Protected Sub ASPxButton7_Click(sender As Object, e As EventArgs) Handles ASPxButton7.Click
       

        Dim strscript As String
        strscript = "<script langauage=JavaScript>"
        strscript += "window.open('rptred.aspx?issuer=" & isser().ToString & "&payNo=" & payno().ToString & "');"
        strscript += "</script>"
        ClientScript.RegisterStartupScript(Me.GetType(), "newwin", strscript)
       
    End Sub
    Public Function isser() As String
        Try
            cmd = New SqlCommand("select issuer from capital_repayment_instr where id='" + txtid.Text + "'", cn)
            Dim ds As New DataSet
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "Para_Security_Type")
            If ds.Tables(0).Rows.Count > 0 Then
                Return ds.Tables(0).Rows(0).Item("issuer")
            Else
                Return ""
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Function
    Public Function payno() As String
        Try
            cmd = New SqlCommand("select payment_no from capital_repayment_instr where id='" + txtid.Text + "'", cn)
            Dim ds As New DataSet
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "Para_Security_Type")
            If ds.Tables(0).Rows.Count > 0 Then
                Return ds.Tables(0).Rows(0).Item("payment_No")
            Else
                Return ""
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Function
    Protected Sub cmbsecurity_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbsecurity.SelectedIndexChanged
        txtid.Text = cmbsecurity.SelectedItem.Value
        getdetails()
    End Sub
    Public Sub getdetails()
        cmd = New SqlCommand("select * from capital_repayment_instr where id='" + txtid.Text + "'", cn)
        Dim ds As New DataSet
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "Para")
        If ds.Tables(0).Rows.Count > 0 Then
            '  cmbdatedeclared.Text = ds.Tables(0).Rows(0).Item("date_declared")
            ' cmbdateclosed.Text = ds.Tables(0).Rows(0).Item("date_closed")
            cmbpaymentsdate.Text = ds.Tables(0).Rows(0).Item("date_payment")
            ' txtinterest.Text = ds.Tables(0).Rows(0).Item("rate")
            txtDesc.Text = ds.Tables(0).Rows(0).Item("mess_1")
        End If
    End Sub
End Class
