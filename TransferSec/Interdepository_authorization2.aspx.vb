Partial Class TransferSec_interdepository_authorization2
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
            cmd = New SqlCommand("select id from inter_depository_trans where authorized1='1' and authorized2='0' and quantity>'0'", cn)
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
            cmd = New SqlCommand("  Select '' as 'Origin Details', D.from_cds_Number as [Origin CDS], OD.FULL_NAME as [Origin Full Name], '' as 'Beneficiary Details', d.to_cds_number as [CDS Number], bd.surname+' '+bd.middlename+' '+bd.surname as [Beneficiary Full Names], '' as [Interdepository Details], d.company as [Company], d.from_isin as [Origin ISIN], d.to_isin as [Beneficiary ISIN], d.Stockexchange as [Origin Stock Exchange], d.Quantity as [Amount of Shares], d.Reason_for_transfer as [Reason for Transfer] from inter_depository_trans d, accounts_clients bd, interdepository  od where d.from_cds_number=od.cds_number and d.to_cds_number=bd.CDS_Number and d.id='" + ASPxComboBox1.SelectedItem.Text + "'", cn)
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

        '  msgbox(dtlBankDetail.Rows(2).Cells(1).Text)
    End Sub
    Public Sub saveupdate()
        'Updating the Trans table to record the transaction
        cmd = New SqlCommand("insert into trans (company, cds_number, date_created, trans_time, shares, update_type, created_by,batch_ref, source, pledge_shares) values ('" + dtlBankDetail.Rows(7).Cells(1).Text + "','" + dtlBankDetail.Rows(4).Cells(1).Text + "',getdate(),cast(getdate() as time),'" + dtlBankDetail.Rows(11).Cells(1).Text + "','Cross Border','" + Session("Username").ToString + "','0','S','0')", cn)
        If (cn.State = ConnectionState.Open) Then
            cn.Close()
        End If
        cn.Open()
        cmd.ExecuteNonQuery()
        cn.Close()


        ' Update the mast to deduct or add shares
        Dim ds As New DataSet
        cmd = New SqlCommand("select * from mast where cds_number='" + dtlBankDetail.Rows(4).Cells(1).Text + "' and company='" + dtlBankDetail.Rows(7).Cells(1).Text + "'", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "mast_av")

        If ds.Tables(0).Rows.Count > 0 Then
            cmd = New SqlCommand("update mast set shares=(select shares from mast where cds_number='" + dtlBankDetail.Rows(4).Cells(1).Text + "')+" + dtlBankDetail.Rows(11).Cells(1).Text + " where CDS_Number='" + dtlBankDetail.Rows(4).Cells(1).Text + "'", cn)
            If (cn.State = ConnectionState.Open) Then
                cn.Close()
            End If
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()
        Else
            cmd = New SqlCommand("insert into mast (company, CDS_Number, Date_Created, shares, Update_Type, pladge, Pledge_Shares,Created_By,Updated_On, Updated_By,locked, Lock_Reason,Batch_Ref, PledgeReason,SecType) values ('" + dtlBankDetail.Rows(7).Cells(1).Text + "','" + dtlBankDetail.Rows(4).Cells(1).Text + "',getdate(),'" + dtlBankDetail.Rows(11).Cells(1).Text + "','Cross Border','0','0','" + Session("username") + "',getdate(),'" + Session("username") + "','0','-','0','','')", cn)
            If (cn.State = ConnectionState.Open) Then
                cn.Close()
            End If
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()
        End If
     
        'Update para_company and para_cross listed

        cmd = New SqlCommand("update para_company_crosslisted set Issued_shares= (select Issued_shares from para_company_crosslisted where isin='" + dtlBankDetail.Rows(8).Cells(1).Text + "')-" + dtlBankDetail.Rows(11).Cells(1).Text + " where isin='" + dtlBankDetail.Rows(8).Cells(1).Text + "'                              update para_company set Issued_shares= (select Issued_shares from para_company where isin='" + dtlBankDetail.Rows(9).Cells(1).Text + "')+" + dtlBankDetail.Rows(11).Cells(1).Text + " where isin='" + dtlBankDetail.Rows(9).Cells(1).Text + "'", cn)
        If (cn.State = ConnectionState.Open) Then
            cn.Close()
        End If
        cn.Open()
        cmd.ExecuteNonQuery()
        cn.Close()

        cmd = New SqlCommand("update Interdepository set quantity=(select quantity from Interdepository where CDS_number='" + dtlBankDetail.Rows(2).Cells(1).Text + "' and isin='" + dtlBankDetail.Rows(8).Cells(1).Text + "')-'" + dtlBankDetail.Rows(11).Cells(1).Text + "', locked='0' where CDS_number='" + dtlBankDetail.Rows(2).Cells(1).Text + "' and isin='" + dtlBankDetail.Rows(8).Cells(1).Text + "'", cn)
        If (cn.State = ConnectionState.Open) Then
            cn.Close()
        End If
        cn.Open()
        cmd.ExecuteNonQuery()
        cn.Close()




        'Updating Interdepository table to mark the transfer as done 
        cmd = New SqlCommand("update inter_depository_trans set Authorized2='1' where id='" + ASPxComboBox1.SelectedItem.Text + "'", cn)
        If (cn.State = ConnectionState.Open) Then
            cn.Close()
        End If
        cn.Open()
        cmd.ExecuteNonQuery()
        cn.Close()
    End Sub
End Class
