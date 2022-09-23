Partial Class Enquiries_BorrowersRecording
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
                'GetCompanies()
                'GetSec_Types()
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub ASPxButton3_Click(sender As Object, e As EventArgs) Handles ASPxButton3.Click
        Try
            Dim Transshares As Integer = 0
            Dim PledgeShares As Integer = 0
            Dim Availshares As Integer = 0
            Dim dsishv As New DataSet
            'cmd = New SqlCommand("select * from trans where cds_number ='" & lblClientID.Text & "' and company='" & cmbCompany.SelectedItem.Text & "'", cn)
            'adp = New SqlDataAdapter(cmd)
            'adp.Fill(dsishv, "trans")
            'If (dsishv.Tables(0).Rows.Count > 0) Then
            'Dim ds As New DataSet
            'cmd = New SqlCommand("select sum(shares) as shares from trans where  cds_number='" & lblClientID.Text & "' and company='" & cmbCompany.SelectedItem.Text & "'", cn)
            'adp = New SqlDataAdapter(cmd)
            'adp.Fill(ds, "trans")
            'If (ds.Tables(0).Rows.Count > 0) Then
            'Transshares = ds.Tables(0).Rows(0).Item("shares").ToString
            'End If

            'Dim dspl As New DataSet
            'cmd = New SqlCommand("select * from Pledges_Recording where cds_number ='" & lblClientID.Text & "' and company='" & cmbCompany.SelectedItem.Text & "' and pledge_status='C'", cn)
            'adp = New SqlDataAdapter(cmd)
            'adp.Fill(dspl, "Pledges_Recording")
            'If (dspl.Tables(0).Rows.Count > 0) Then
            '    Dim dsplsh As New DataSet
            '    cmd = New SqlCommand("select sum(quantity) as shares from pledges_recording where  cds_number ='" & lblClientID.Text & "' and company='" & cmbCompany.SelectedItem.Text & "' AND pledge_status='C'", cn)
            '    adp = New SqlDataAdapter(cmd)
            '    adp.Fill(dsplsh, "pledges_recording")

            '    PledgeShares = dsplsh.Tables(0).Rows(0).Item("shares").ToString

            'End If
            'Availshares = Transshares - PledgeShares
            'If (Availshares > CInt(txtQuantity.Text)) Then

            'Else
            '    msgbox("Pledged shares are greater than available shares")
            '    Exit Sub
            'End If

            'Else
            'msgbox("Selected account has no valid securities in the selected counter")
            'Exit Sub
            'End If

        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub SaveBorrower()
        Try
            cmd = New SqlCommand("Insert into BorrowersRegister (cds_number,surname,forenames,company,quantity,EffectiveDate,ExpiryDate,Status) values ('" & lblClientID.Text & "','" & txtSurname.Text & "','" & txtForenames.Text & "','',0,'','','O')", cn)
            If (cn.State = ConnectionState.Open) Then
                cn.Close()
            End If
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()
            msgbox("Borrower Record Saved")
            txtcds_number_search.Text = ""
            'txtEffectiveDate.Text = ""
            'txtExpiryDate.Text = ""
            txtForenames.Text = ""
            txtNameSearch.Text = ""
            'txtQuantity.Text = ""
            txtSurname.Text = ""
            lstNameSearch.Items.Clear()
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub ASPxButton6_Click(sender As Object, e As EventArgs) Handles ASPxButton6.Click
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select distinct cds_number+' '+surname+' '+forenames as namess from Accounts_clients where surname like '" & txtNameSearch.Text & "%'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "Accounts_clients")
            If (ds.Tables(0).Rows.Count > 0) Then
                lstNameSearch.DataSource = ds.Tables(0)
                lstNameSearch.TextField = "namess"
                lstNameSearch.ValueField = "namess"
                lstNameSearch.DataBind()
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    'Public Sub GetSec_Types()
    '    Try
    '        Dim ds As New DataSet
    '        cmd = New SqlCommand("select distinct (seccode) as seccode from sec_types ", cn)
    '        adp = New SqlDataAdapter(cmd)
    '        adp.Fill(ds, "sec_types")
    '        If (ds.Tables(0).Rows.Count > 0) Then
    '            cmbSecType.DataSource = ds.Tables(0)
    '            cmbSecType.TextField = "seccode"
    '            cmbSecType.ValueField = "seccode"
    '            cmbSecType.DataBind()
    '        End If
    '    Catch ex As Exception
    '        msgbox(ex.Message)
    '    End Try
    'End Sub
    'Public Sub GetCompanies()
    '    Try
    '        Dim ds As New DataSet
    '        cmd = New SqlCommand("select distinct (company) from trans", cn)
    '        adp = New SqlDataAdapter(cmd)
    '        adp.Fill(ds, "trans")
    '        If (ds.Tables(0).Rows.Count > 0) Then
    '            cmbCompany.DataSource = ds.Tables(0)
    '            cmbCompany.TextField = "company"
    '            cmbCompany.ValueField = "company"
    '            cmbCompany.DataBind()
    '        End If
    '    Catch ex As Exception
    '        msgbox(ex.Message)
    '    End Try
    'End Sub

    Protected Sub lstNameSearch_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstNameSearch.SelectedIndexChanged
        Try
            'If (lstNameSearch.SelectedIndex.ToString > 1) Then
            Dim ds As New DataSet
            cmd = New SqlCommand("select * from Accounts_Clients where cds_number+' '+surname+' '+forenames ='" & lstNameSearch.SelectedItem.Text & "'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "Accounts_Clients")
            If (ds.Tables(0).Rows.Count > 0) Then
                lblClientID.Text = ds.Tables(0).Rows(0).Item("cds_number").ToString
                txtSurname.Text = ds.Tables(0).Rows(0).Item("surname").ToString
                txtForenames.Text = ds.Tables(0).Rows(0).Item("forenames").ToString
            Else
                lblClientID.Text = ""
                txtSurname.Text = ""
                txtForenames.Text = ""
            End If
            'End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
End Class
