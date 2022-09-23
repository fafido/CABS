Partial Class Enquiries_Cash_Deposits
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
            If session("finish") = "true" Then
                session("finish") = ""
                Response.Write("<script>alert('Update sent for Authorization!') ; location.href='CtradeAccountsLock.aspx'</script>")
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub ClearData()
        Try
            txtClientNo.Text = ""

            txtIDno.Text = ""
            txtForenames.Text = ""
            txtSurname.Text = ""
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Protected Sub ASPxButton2_Click(sender As Object, e As EventArgs) Handles ASPxButton2.Click
        Try
            ' If (txtClientNameSearch.Text <> "") Then
            Dim ds As New DataSet
            cmd = New SqlCommand("select cds_Number,cds_number+' '+forenames+' '+surname as namess from Accounts_Clients where cds_number+' '+forenames+' '+surname like '%" & txtClientNameSearch.Text & "%' and cds_number not in (select cds_number from accountslock where rejected is NULL and ApprovedBy is NULL) order by cds_number", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "Accounts_Clients")
            If (ds.Tables(0).Rows.Count > 0) Then
                lstNamesSearch.DataSource = ds.Tables(0)
                lstNamesSearch.TextField = "namess"
                lstNamesSearch.ValueField = "cds_Number"
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
        Try
            If (lstNamesSearch.Items.Count > 0) Then
                Dim ds As New DataSet
                cmd = New SqlCommand("select * from Accounts_Clients where cds_number = '" & lstNamesSearch.SelectedItem.Value.ToString & "'", cn)
                adp = New SqlDataAdapter(cmd)
                adp.Fill(ds, "Accounts_Clients")
                If (ds.Tables(0).Rows.Count > 0) Then
                    txtClientNo.Text = ds.Tables(0).Rows(0).Item("cds_number").ToString.ToUpper
                    '  txtTitle.Text = ds.Tables(0).Rows(0).Item("title").ToString.ToUpper
                    txtIDno.Text = ds.Tables(0).Rows(0).Item("CNIC").ToString.ToUpper
                    txtForenames.Text = ds.Tables(0).Rows(0).Item("forenames").ToString.ToUpper
                    txtSurname.Text = ds.Tables(0).Rows(0).Item("surname").ToString.ToUpper
                    ' getCashBal()
                    buttontext(txtClientNo.Text)

                Else
                    txtClientNo.Text = ""
                    ' txtTitle.Text = ""
                    txtIDno.Text = ""
                    txtForenames.Text = ""
                    txtSurname.Text = ""

                End If
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub buttontext(accountno As String)
        Dim ds As New DataSet
        cmd = New SqlCommand("select AccountState from accounts_clients where cds_Number='" + accountno + "'", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "Accounts_Clients")

        If (ds.Tables(0).Rows.Count > 0) Then
            Dim state As String = ds.Tables(0).Rows(0).Item("AccountState").ToString
            If state = "A" Then
                ASPxButton3.Text = "Block"
            Else
                ASPxButton3.Text = "Un-Block"
            End If
        End If
    End Sub

    Public Sub GetCashBal()
        Dim ds As New DataSet
        cmd = New SqlCommand("select isnull(sum(Amount),0.0) as total from cdsc.dbo.cashtrans where cds_Number = '" & txtClientNo.Text & "'", cn)
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

        If txtReason.Text = "" Then
            msgbox("Enter Reason")
            Exit Sub
        End If
        Dim result As Integer
        Dim stt As String
        If ASPxButton3.Text = "Block" Then
            stt = "BLOCKED"
        Else
            stt = "UN-BLOCKED"
        End If
        cmd = New SqlCommand("insert into [AccountsLock] (cds_number,reason,status,blockedby, blockdate, ApprovedBy,approveddate) values('" + txtClientNo.Text + "','" + txtReason.Text + "','" + stt + "','" + Session("Username") + "',getdate(), NULL, NULL) ", cn)
        If (cn.State = ConnectionState.Open) Then
            cn.Close()
        End If
        cn.Open()
        result = cmd.ExecuteNonQuery()
        If result > 0 Then
            Try
                Dim a As New passmanagement
                a.auditlog(Session("BrokerCode"), Session("Username"), "" + stt + " an Account", txtClientNo.Text, "0")
            Catch ex As Exception

            End Try

            Session("finish") = "true"
            Response.Redirect(Request.RawUrl)

        End If
        cn.Close()

        'updateaccountsclients()
        ' 
        ' 
    End Sub
    Public Sub updateaccountsclients()
        cmd = New SqlCommand("update cds_router.dbo.Accounts_Clients set AccountState='locked' where cds_number = '" + txtClientNo.Text + "' ", cn)
        If (cn.State = ConnectionState.Open) Then
            cn.Close()
        End If
        cn.Open()
        cmd.ExecuteNonQuery()
        ClearFields()

    End Sub

    Public Sub ClearFields()
        'txtAmount.Text = ""
        txtClientNo.Text = ""
        txtForenames.Text = ""
        txtIDno.Text = ""
        txtSurname.Text = ""

    End Sub
    Protected Sub ASPxButton4_Click(sender As Object, e As EventArgs)
        If txtReason.Text = "" Then
            msgbox("Enter Reason")
            Exit Sub
        End If
        Dim result As Integer
        cmd = New SqlCommand("insert into [AccountsLock](name,surname,cdsnumber,reason,status) values('" + txtForenames.Text + "' ,'" + txtSurname.Text + "' ,'" + txtClientNo.Text + "','" + txtReason.Text + "','active') ", cn)
        If (cn.State = ConnectionState.Open) Then
            cn.Close()
        End If
        cn.Open()
        result = cmd.ExecuteNonQuery()
        If result > 0 Then
            Session("finish") = "true"
            'response.redirect(request.rawurl)

        End If
        cn.Close()
        'updateaccountsclients()
        Response.Write("<script>alert('Account " + ASPxButton3.Text + "  Now Awaits Authorisation') ; location.href='CtradeAccountsLock.aspx'</script>")
    End Sub
    Public Sub unlock()
        cmd = New SqlCommand("update cds_router.dbo.Accounts_Clients set AccountState='active' where cds_number = '" + txtClientNo.Text + "' ", cn)
        If (cn.State = ConnectionState.Open) Then
            cn.Close()
        End If
        cn.Open()
        cmd.ExecuteNonQuery()
        ClearFields()

    End Sub

End Class
