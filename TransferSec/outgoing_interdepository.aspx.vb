Partial Class TransferSec_outgoing_interdepository
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
            If Session("finish") = "yes" Then
                Session("finish") = ""
                msgbox("Successful")
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Protected Sub ASPxButton10_Click(sender As Object, e As EventArgs) Handles ASPxButton10.Click
        Try
            getinteraccounts()

        Catch ex As Exception
            msgbox(ex.Message)

        End Try
    End Sub
    Public Sub getinteraccounts()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select surname+' '+middlename+' '+surname+' '+cds_number as names, cds_number from accounts_clients where cds_number like '%" + txtclientnumber.Text + "%' and brokercode='" + Session("brokercode") + "'  order by surname", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "inter_accounts")
            If (ds.Tables(0).Rows.Count > 0) Then
                ListBox1.DataSource = ds
                ListBox1.DataTextField = "names"
                ListBox1.DataValueField = "cds_number"
                ListBox1.DataBind()
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select m.Company, sum(m.shares) as [Shares], m.cds_number as [CDS Number], a.surname+' '+a.middlename+' '+a.surname as [Full Name],'ALTX' AS [Stock Exchange] from TRANS m, accounts_clients a where a.CDS_Number=m.CDS_Number and m.cds_number='" + ListBox1.SelectedValue.ToString + "' group by m.Company, m.CDS_Number,a.surname,a.middlename", cn)

            ' cmd = New SqlCommand("select Company, Quantity as [Total Shares],cds_number as [CDS Number], Full_name as [Full Name], Stockexchange as [Stock Exchange] from interdepository where cds_number='" + ListBox1.SelectedValue.ToString + "'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "account")
            If (ds.Tables(0).Rows.Count > 0) Then
                ASPxComboBox1.DataSource = ds
                ASPxComboBox1.TextField = "company"
                ASPxComboBox1.DataBind()

            Else
                msgbox("This user has no shares")
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub getcompanies()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select m.Company, sum(m.shares) as [Shares], m.cds_number as [CDS Number], a.surname+' '+a.middlename+' '+a.surname as [Full Name],'ALTX' AS [Stock Exchange] from TRANS m, accounts_clients a where a.CDS_Number=m.CDS_Number and m.cds_number='" + ListBox1.SelectedValue.ToString + "' and m.company='" + ASPxComboBox1.SelectedItem.Text + "' group by m.Company, m.CDS_Number,a.surname,a.middlename", cn)

            ' cmd = New SqlCommand("select Company, Quantity as [Total Shares],cds_number as [CDS Number], Full_name as [Full Name], Stockexchange as [Stock Exchange] from interdepository where cds_number='" + ListBox1.SelectedValue.ToString + "'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "account")
            If (ds.Tables(0).Rows.Count > 0) Then
                grdTranShareholder.DataSource = ds
                grdTranShareholder.DataBind()
            Else
                msgbox("This user has no shares")
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub ListBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox2.SelectedIndexChanged
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select Company, Quantity as [Total Shares],cds_number as [CDS Number], Full_name as [Full Name], Stockexchange as [Stock Exchange] from interdepository where cds_number='" + ListBox2.SelectedValue.ToString + "'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "accountz")
            If (ds.Tables(0).Rows.Count > 0) Then
                grdTranShareholder0.DataSource = ds
                grdTranShareholder0.DataBind()

            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub ASPxButton11_Click(sender As Object, e As EventArgs) Handles ASPxButton11.Click
        getlocalaccounts()

    End Sub
    Public Sub getlocalaccounts()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select cds_number+' '+full_name as Names, cds_number from interdepository where cds_number like '%" + txtclientnumber0.Text + "%'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "local_accounts")
            If (ds.Tables(0).Rows.Count > 0) Then
                ListBox2.DataSource = ds
                ListBox2.DataTextField = "names"
                ListBox2.DataValueField = "cds_number"
                ListBox2.DataBind()
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub ASPxButton12_Click(sender As Object, e As EventArgs) Handles ASPxButton12.Click

        If ListBox1.SelectedIndex.ToString = -1 Then
            msgbox("Please select Origin Account")
            Exit Sub
        Else
            If ListBox2.SelectedIndex.ToString = -1 Then
                msgbox("Please select Beneficiary Account")
                Exit Sub
            Else
                If txtquantity.Text <> "" And txtreasonfortrans.Text <> "" Then
                    Dim quantity, tot_shares As Long
                    quantity = txtquantity.Text
                    tot_shares = grdTranShareholder.Rows(0).Cells(1).Text

                    If quantity > tot_shares Then
                        msgbox("You have specified more shares than the total shares from the Origin account")
                    Else
                        cmd = New SqlCommand("insert into inter_depository_trans (from_isin,to_isin, company, stockexchange, from_cds_number, to_cds_number, quantity, reason_for_transfer, authorized1, authorized2,broker) values ((select ISIN from para_company where company='" + grdTranShareholder.Rows(0).Cells(0).Text + "'),(select ISIN from para_company_crosslisted where company='" + grdTranShareholder.Rows(0).Cells(0).Text + "'), '" + grdTranShareholder.Rows(0).Cells(0).Text + "','" + grdTranShareholder.Rows(0).Cells(4).Text + "','" + grdTranShareholder.Rows(0).Cells(2).Text + "','" + ListBox2.SelectedValue.ToString + "','-" + quantity.ToString + "','" + txtreasonfortrans.Text + "','0','0','" + Session("brokercode") + "')                              update mast set locked='1' where cds_number='" + grdTranShareholder.Rows(0).Cells(2).Text + "'", cn)
                        If (cn.State = ConnectionState.Open) Then
                            cn.Close()
                        End If
                        cn.Open()
                        cmd.ExecuteNonQuery()
                        cn.Close()
                        Session("finish") = "yes"
                        Response.Redirect(Request.RawUrl)
                    End If
                Else
                    msgbox("Please Provide all the required fields")
                End If


            End If
        End If



        '     msgbox(grdTranShareholder.Rows(0).Cells(1).Text)




    End Sub

    Protected Sub ASPxComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ASPxComboBox1.SelectedIndexChanged
        getcompanies()

    End Sub
End Class
