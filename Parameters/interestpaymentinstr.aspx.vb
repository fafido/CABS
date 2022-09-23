Partial Class Parameters_interestpaymentinstr
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
        getSecurities_Types()
    End Sub
    Public Sub getcompanies()
        cmd = New SqlCommand("select company, series from para_company", cn)
        Dim ds As New DataSet
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "companies")
        If ds.Tables(0).Rows.Count > 0 Then
            cmbsecurity.DataSource = ds
            cmbsecurity.TextField = "series"
            cmbsecurity.ValueField = "company"
            cmbsecurity.DataBind()
        End If
    End Sub
    Public Function maxpaymentno(ByVal company As String) As Integer
        cmd = New SqlCommand("select isnull(max(payment_no),0)+1 as [PaymentNo] from interest_instr where issuer='" + company + "'", cn)
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
        cmd = New SqlCommand("select Issuer as [Company(ISIN)], PAYMENT_no as [Payment No], date_payment as [Payment Date], rate as [Interest Rate], datecreated as [Creation Date], Case Authorized when 0 then 'Pending' else 'Completed' end as [Status] from interest_instr", cn)
        Dim ds As New DataSet
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "companies")
        If ds.Tables(0).Rows.Count > 0 Then
            ASPxGridView2.DataSource = ds
            ASPxGridView2.DataBind()
        End If
    End Sub

    Protected Sub ASPxButton7_Click(sender As Object, e As EventArgs) Handles ASPxButton7.Click
        If IsNumeric(txtinterest.Text) = False Then
            msgbox("Interest Should be numeric!")
            Exit Sub
        End If
        If IsNumeric(txttaxrate.Text) = False Then
            msgbox("Tax  Should be numeric!")
            Exit Sub
        End If
        If txtinterest.Text <> "" And txtDesc.Text <> "" Then
            cmd = New SqlCommand("insert into interest_instr (issuer, issue_no, payment_No, date_declared, date_closed, date_payment, rate, mess_1, mess_2,bank_accno, datecreated, createdby, authorized, tax_new) values ('" + cmbsecurity.SelectedItem.Value.ToString + "',1," + txtpaymentNo.Text + ",NULL,NULL,'" + cmbpaymentsdate.Text + "','" + txtinterest.Text + "','" + txtDesc.Text + "','','255647',getdate(),'" + Session("Username") + "',0,'" + txttaxrate.Text + "')", cn)
            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If
            cn.Open()
            Dim y As Integer = cmd.ExecuteNonQuery()
            cn.Close()
            Session("finish") = "true"
            Response.Redirect(Request.RawUrl)

        Else
            msgbox("Enter All Details")
            Exit Sub
        End If
    End Sub
    Protected Sub getSecurities_Types()
        Try
            cmd = New SqlCommand("select ID,Security_Type as [TYPE],[Description] from Para_Security_Type", cn)
            Dim ds As New DataSet
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "Para_Security_Type")
            If ds.Tables(0).Rows.Count > 0 Then
                ASPxGridView2.DataSource = ds.Tables(0)
            Else
                ASPxGridView2.DataSource = Nothing
            End If
            ASPxGridView2.DataBind()
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub cmbsecurity_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbsecurity.SelectedIndexChanged
        txtpaymentNo.Text = maxpaymentno(cmbsecurity.SelectedItem.Value)
    End Sub
End Class
