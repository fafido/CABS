Partial Class TransferSec_BorrowersRequest_authorization
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
            If Session("finish") = "yes" Then
                Session("finish") = ""
                msgbox("Successful")
            End If
            If (Not IsPostBack) Then
                checkSessionState()
                getpending()

            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

  
    Public Sub getpending()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select id from lendingpool where borroweraccept='0' and borrower_broker='" + Session("brokercode") + "'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "Accounts_Clients")
            If (ds.Tables(0).Rows.Count > 0) Then
                ASPxComboBox1.DataSource = ds
                ASPxComboBox1.TextField = "Id"
                ASPxComboBox1.DataBind()
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub GetSelectedDetails()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select '' as [Borrower Details], a.cds_number as [CDS Number], a.Surname+' '+a.Middlename+' '+a.forenames as Names, '' as [Lender Details], b.cds_number as [CDS Number], b.Surname+' '+b.Middlename+' '+b.forenames as Names, '' as [Request Details], l.Sectype as [Security Type], l.company as [Company], l.Quantity, l.FeeType as [Fee Type], l.Fee,l.RepaymentDate as [Repayment Date], l.InterestRate as [Interest Rate],l.Collateral_Type as [Collateral Type], l.Collateral_name as [Collateral Detail], collateral_value as [Collateral Value]    from accounts_clients a, Accounts_Clients b, LendingPool l where a.CDS_Number= l.BorrowerCDSNo and b.CDS_Number=l.LenderCDSNo and l.id='" + ASPxComboBox1.Text + "' ", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "Accounts_Clients")
            If (ds.Tables(0).Rows.Count > 0) Then
                dtlBankDetail.DataSource = ds
                dtlBankDetail.DataBind()
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

  

    'Protected Sub ASPxButton8_Click(sender As Object, e As EventArgs) Handles ASPxButton8.Click
    '    Try
    '        Dim ds As New DataSet
    '        Dim shares As Long = txtquantity.Text
    '        lstLenders.Items.Clear()

    '        cmd = New SqlCommand("select surname+' '+forenames+' '+company as names, cds_number from lendersregister where company='" + cmbCompany.SelectedItem.Text + "' and quantity>='" + shares.ToString + "'", cn)
    '        adp = New SqlDataAdapter(cmd)
    '        adp.Fill(ds, "lenders")
    '        If (ds.Tables(0).Rows.Count > 0) Then
    '            lstLenders.DataSource = ds
    '            lstLenders.TextField = "cds_number"
    '            lstLenders.ValueField = "cds_number"
    '            lstLenders.DataBind()
    '        Else
    '            msgbox("No match found!")
    '        End If
    '    Catch ex As Exception
    '        msgbox(ex.Message)

    '    End Try

    'End Sub

  
  
    Protected Sub ASPxComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ASPxComboBox1.SelectedIndexChanged
        GetSelectedDetails()

    End Sub

    Protected Sub ASPxButton1_Click(sender As Object, e As EventArgs) Handles ASPxButton1.Click
        saveupdate()
        Session("finish") = "yes"
        Response.Redirect(Request.RawUrl)
    End Sub
    Public Sub saveupdate()
        cmd = New SqlCommand("update lendingpool set BorrowerAccept='1' where id='" + ASPxComboBox1.SelectedItem.Text + "'", cn)
        If (cn.State = ConnectionState.Open) Then
            cn.Close()
        End If
        cn.Open()
        cmd.ExecuteNonQuery()
        cn.Close()
    End Sub
End Class
