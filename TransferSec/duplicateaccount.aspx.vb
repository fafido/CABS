Partial Class TransferSec_duplicateaccount
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
                '      getpending()
                GetSelectedDetails()
                msgbox("One of the identification you used already exists, please duplicate the Account if you wish to")
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub


    Public Sub getpending()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("", cn)
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
        ' Try
        Dim ds As New DataSet
        cmd = New SqlCommand("select * from accounts_audit where idnopp='" + Request.QueryString("id1") + "' or idnopp='" + Request.QueryString("id2") + "' or idnopp2='" + Request.QueryString("id1") + "' or idnopp2='" + Request.QueryString("id2") + "'", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "Accounts_Clients")
        If (ds.Tables(0).Rows.Count > 0) Then
            dtlBankDetail.DataSource = ds
            dtlBankDetail.DataBind()
        End If
        'Catch ex As Exception
        '    msgbox(ex.Message)
        'End Try
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
        saveduplicate()
        Response.Redirect("accountscreations.aspx?duplicate=1")
    End Sub
    Public Sub saveduplicate()
        cmd = New SqlCommand("insert into accounts_audit select '" + Session("brokercode") + "'+''+cds_number, '" + Session("brokercode") + "', Accounttype, surname, middlename, forenames, initials, title, IDNoPP, idtype, nationality, dob, gender, Add_1, Add_2, add_3, add_4, country, city, tel, mobile, email, Category,Custodian,tradingstatus, Industry,tax, div_bank, div_branch, Div_AccountNo, cash_bank, cash_branch, Cash_AccountNo, client_image, documents, BioMatrix,attached_documents, Date_Created, update_type, '" + Session("username") + "','O', comments, VerificationCode, divpayee, settlementpayee, idnopp2, idtype2,'','','','' from accounts_audit where idnopp='" + Request.QueryString("id1") + "' or idnopp='" + Request.QueryString("id2") + "' or idnopp2='" + Request.QueryString("id1") + "' or idnopp2='" + Request.QueryString("id2") + "'", cn)
        If (cn.State = ConnectionState.Open) Then
            cn.Close()
        End If
        cn.Open()
        cmd.ExecuteNonQuery()
        cn.Close()
    End Sub
End Class
