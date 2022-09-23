Partial Class TransferSec_incoming_interdepository
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
                getdepositories()

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
            If ASPxComboBox1.SelectedIndex <> -1 Then
                getinteraccounts()
            Else
                msgbox("Please select the origin Depository")
            End If


        Catch ex As Exception
            msgbox(ex.Message)

        End Try
    End Sub
    Public Sub getinteraccounts()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select full_name+' '+cds_number as names, cds_number from interdepository where cds_number like '%" + txtclientnumber.Text + "%' and locked!='1' and stockexchange=(select name from para_stock_exchange where fnam='" + ASPxComboBox1.SelectedItem.Text + "') order by full_name", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "inter_accounts")
            If (ds.Tables(0).Rows.Count > 0) Then
                ListBox1.DataSource = ds
                ListBox1.DataTextField = "names"
                ListBox1.DataValueField = "cds_number"
                ListBox1.DataBind()
            Else
                ListBox1.Items.Clear()

            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select Company, Quantity as [Total Shares],cds_number as [CDS Number], Full_name as [Full Name], Stockexchange as [Stock Exchange] from interdepository where cds_number='" + ListBox1.SelectedValue.ToString + "'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "account")
            If (ds.Tables(0).Rows.Count > 0) Then
                grdTranShareholder.DataSource = ds
                grdTranShareholder.DataBind()

            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub ListBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox2.SelectedIndexChanged
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("  select cds_number as [CDS Number], Surname+' '+Middlename+' '+forenames as [Full Name],idnopp as [Identification No], Email as Email from Accounts_clients where cds_number+' '+surname+' '+middlename+' '+forenames='" + ListBox2.SelectedItem.Text + "' and brokercode='" + Session("brokercode") + "'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "account1")
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
            cmd = New SqlCommand("select cds_number+' '+surname+' '+middlename+' '+forenames as Names, cds_number from accounts_clients where cds_number like '%" + txtclientnumber0.Text + "%' and brokercode='" + Session("brokercode") + "'", cn)
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
    Public Sub getdepositories()

        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select Fnam from para_stock_exchange where fnam<>'ALTX'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "depository")
            If (ds.Tables(0).Rows.Count > 0) Then
                ASPxComboBox1.DataSource = ds
                ASPxComboBox1.TextField = "fnam"
                ASPxComboBox1.DataBind()
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
                        cmd = New SqlCommand("insert into inter_depository_trans (from_isin,to_isin, company, stockexchange, from_cds_number, to_cds_number, quantity, reason_for_transfer, authorized1, authorized2,broker) values ((select ISIN from para_company_crosslisted where company='" + grdTranShareholder.Rows(0).Cells(0).Text + "' and stockexchange='" + grdTranShareholder.Rows(0).Cells(4).Text + "'),(select ISIN from para_company where company='" + grdTranShareholder.Rows(0).Cells(0).Text + "'), '" + grdTranShareholder.Rows(0).Cells(0).Text + "','" + grdTranShareholder.Rows(0).Cells(4).Text + "','" + grdTranShareholder.Rows(0).Cells(2).Text + "','" + ListBox2.SelectedValue.ToString + "','" + quantity.ToString + "','" + txtreasonfortrans.Text + "','0','0','" + Session("brokercode") + "')                              update interdepository set locked='1' where cds_number='" + grdTranShareholder.Rows(0).Cells(2).Text + "'", cn)
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
End Class
