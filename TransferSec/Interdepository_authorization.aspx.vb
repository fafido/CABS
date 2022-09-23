Partial Class TransferSec_interdepository_authorization
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
            cmd = New SqlCommand("select id from inter_depository_trans where authorized1='0' and broker='" + Session("brokercode") + "'", cn)
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
           
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub getdet()
        Dim ds As New DataSet
        cmd = New SqlCommand("select * from inter_depository_trans where id='" + ASPxComboBox1.SelectedItem.Text + "'", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "Accounts_Clients")
        If (ds.Tables(0).Rows.Count > 0) Then
            If ds.Tables(0).Rows(0).Item("stockexchange") = "ALTX" Then
                Dim ds1 As New DataSet
                cmd = New SqlCommand(" Select '' as 'Origin Details', D.from_cds_Number as [CDS Number], bd.surname+' '+bd.middlename+' '+bd.surname  as [Full Name], '' as 'Beneficiary Details', d.to_cds_number as [CDS Number],OD.FULL_NAME  as [Full Names], '' as [Interdepository Details], d.company as [Company], d.from_isin as [Origin ISIN], d.to_isin as [Beneficiary ISIN], d.Stockexchange as [Origin Stock Exchange], d.Quantity as [Amount of Shares], d.Reason_for_transfer as [Reason for Transfer] from inter_depository_trans d, accounts_clients bd, interdepository  od where d.from_cds_number=bd.cds_number and d.to_cds_number=od.CDS_Number and d.id='" + ASPxComboBox1.SelectedItem.Text + "'", cn)
                adp = New SqlDataAdapter(cmd)
                adp.Fill(ds1, "Accounts_Clients2")
                If (ds1.Tables(0).Rows.Count > 0) Then
                    dtlBankDetail.DataSource = ds1
                    dtlBankDetail.DataBind()
                End If
            Else
                Dim ds3 As New DataSet
                cmd = New SqlCommand("Select '' as 'Origin Details', D.from_cds_Number as [Origin CDS], OD.FULL_NAME as [Origin Full Name], '' as 'Beneficiary Details', d.to_cds_number as [CDS Number], bd.surname+' '+bd.middlename+' '+bd.surname as [Beneficiary Full Names], '' as [Interdepository Details], d.company as [Company], d.from_isin as [Origin ISIN], d.to_isin as [Beneficiary ISIN], d.Stockexchange as [Origin Stock Exchange], d.Quantity as [Amount of Shares], d.Reason_for_transfer as [Reason for Transfer] from inter_depository_trans d, accounts_clients bd, interdepository  od where d.from_cds_number=od.cds_number and d.to_cds_number=bd.CDS_Number and d.id='" + ASPxComboBox1.SelectedItem.Text + "'", cn)
                adp = New SqlDataAdapter(cmd)
                adp.Fill(ds3, "Accounts_Clients4")
                If (ds.Tables(0).Rows.Count > 0) Then
                    dtlBankDetail.DataSource = ds3
                    dtlBankDetail.DataBind()
                End If
            End If
        End If
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
        getdet()


    End Sub

    Protected Sub ASPxButton1_Click(sender As Object, e As EventArgs) Handles ASPxButton1.Click
        saveupdate()
        Session("finish") = "yes"
        Response.Redirect(Request.RawUrl)
    End Sub
    Public Sub saveupdate()
        cmd = New SqlCommand("update inter_depository_trans set Authorized1='1' where id='" + ASPxComboBox1.SelectedItem.Text + "'", cn)
        If (cn.State = ConnectionState.Open) Then
            cn.Close()
        End If
        cn.Open()
        cmd.ExecuteNonQuery()
        cn.Close()
    End Sub
End Class
