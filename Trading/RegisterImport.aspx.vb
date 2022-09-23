Imports System.Data
Imports System.Data.SqlClient
Partial Class Trading_RegisterImport
    Inherits System.Web.UI.Page
    Dim constr As String = (System.Configuration.ConfigurationManager.AppSettings("connpath"))
    '  Dim omu As String = (System.Configuration.ConfigurationManager.AppSettings("omzildb"))
    Dim cn As New SqlConnection(constr)
    ' Dim cnom As New SqlConnection(omu)
    Dim cmd As SqlCommand
    Dim adp As SqlDataAdapter
    Dim x As Integer = 0
    Dim j As Integer = 1
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Page.MaintainScrollPositionOnPostBack = True
        If (Not IsPostBack) Then
            getCompany()
            getsecuritytype()

        End If
    End Sub
    Public Sub msgbox(ByVal strMessage As String)
        'finishes server processing, returns to client.
        Dim strScript As String = "<script language=JavaScript>"
        strScript += "window.alert(""" & strMessage & """);"
        strScript += "</script>"
        Dim lbl As New System.Web.UI.WebControls.Label
        lbl.Text = strScript
        Page.Controls.Add(lbl)
    End Sub
    Public Sub getCompany()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("Select company from para_company", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "para_company")
            cmbParaCompany.DataSource = ds.Tables(0)
            cmbParaCompany.DataValueField = "company"
            cmbParaCompany.DataBind()
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub getsecuritytype()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select distinct security_name from  para_securities", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "para_company")
            cmbParaCompany0.DataSource = ds.Tables(0)
            cmbParaCompany0.DataValueField = "security_name"
            cmbParaCompany0.DataBind()
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub BtnDataImport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnDataImport.Click
        Try
            Dim ds As New DataSet
            Dim omds As New DataSet
            cmd = New SqlCommand("select * from para_company where company='" & cmbParaCompany.SelectedItem.Text & "'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "para_company")
            If (ds.Tables(0).Rows.Count > 0) Then
                msgbox("Selected counter has been imported already!")
                Exit Sub
            Else
                cmd = New SqlCommand("select * from para_company where company='" & cmbParaCompany.SelectedItem.Text & "'", cn)
                adp = New SqlDataAdapter(cmd)
                adp.Fill(omds, "para_company")

                If (omds.Tables(0).Rows.Count > 0) Then

                    cmd = New SqlCommand("Insert into para_company (company,fnam,date_created,issued_shares,status,cds_ac_no,registrar,add_1,add_2,add_3,add_4,city,country,contact_person,telephone,cellphone,fax,comments) values('" & omds.Tables(0).Rows(0).Item("company").ToString & "','" & omds.Tables(0).Rows(0).Item("fnam").ToString & "','" & Now.Date & "',0,1,1,'CORPSERVE','" & omds.Tables(0).Rows(0).Item("Address").ToString & "','','','','HARARE','ZIMBABWE','CORPSERVE','754058','','','TEST')", cn)

                    If (cn.State = ConnectionState.Open) Then
                        cn.Close()
                    End If
                    cn.Open()
                    cmd.ExecuteNonQuery()
                    cn.Close()

                    Dim omdsnam As New DataSet
                    cmd = New SqlCommand("select sum(trans.shares) as transshares, sum(mast.shares ) as mastshares, sum (mast.shares)- sum(trans.shares) as[differnce], trans.shareholder, trans.company ,AccountsMain.Surname, AccountsMain.Forenames, AccountsMain.Title, AccountsMain.Active_Address, AccountsMain.IDNo, AccountsMain.Country, AccountsMain.Mobile, AccountsMain.Telephone, AccountsMain.Email, AccountsMain.Bank, AccountsMain.BankCode, AccountsMain.Branch, AccountsMain.BranchCode, AccountsMain.AccountNo, AccountsMain.Industry from trans, mast, AccountsMain  where trans.shareholder = mast.shareholder and trans.company ='omzil' and trans.shareholder = AccountsMain.Shareholder group by trans.shareholder , trans.company ,AccountsMain.Surname , AccountsMain.Forenames , AccountsMain.Title , AccountsMain.Active_Address , AccountsMain.IDNo , AccountsMain.Country , AccountsMain .Mobile , AccountsMain .Telephone , AccountsMain.Email , AccountsMain.Bank , AccountsMain .BankCode , AccountsMain.Branch , AccountsMain.BranchCode , AccountsMain.AccountNo , AccountsMain.Industry having sum (mast.shares)- sum(trans.shares) =0 and sum(trans.shares) > 0 order by differnce ", cn)
                    adp = New SqlDataAdapter(cmd)
                    adp.Fill(omdsnam, "trans")
                    If (omdsnam.Tables(0).Rows.Count > 0) Then
                        msgbox("doing names")
                        Dim i As Integer
                        For i = 0 To omdsnam.Tables(0).Rows.Count - 1
                            cmd = New SqlCommand("insert into names (shareholder,broker_code,cds_number,surname,forenames,idpp,dob,nominee_code,title,add_1,add_2,add_3,add_4,city,country,telephone,cellphone,fax,email,bank_name,bank_code,branch_name,branch_code,account_type,account,tax,mandate,hfc,locked,updated_by,updated_on,industry,approved,approved_by,holder_type,accountstate) values (" & omdsnam.Tables(0).Rows(i).Item("shareholder").ToString & ",'" & Session("brokercode").ToString & "','" & Session("brokercode") & "" & omdsnam.Tables(0).Rows(i).Item("shareholder").ToString & "','" & omdsnam.Tables(0).Rows(i).Item("surname").ToString & "','" & omdsnam.Tables(0).Rows(i).Item("forenames").ToString & "','" & omdsnam.Tables(0).Rows(i).Item("idno").ToString & "','','','" & omdsnam.Tables(0).Rows(i).Item("title").ToString & "','" & omdsnam.Tables(0).Rows(i).Item("active_address").ToString & "','','','','','" & omdsnam.Tables(0).Rows(i).Item("country").ToString & "','" & omdsnam.Tables(0).Rows(i).Item("Telephone").ToString & "','" & omdsnam.Tables(0).Rows(i).Item("mobile").ToString & "','0','" & omdsnam.Tables(0).Rows(i).Item("email").ToString & "','" & omdsnam.Tables(0).Rows(i).Item("bank").ToString & "','" & omdsnam.Tables(0).Rows(i).Item("bankcode").ToString & "','" & omdsnam.Tables(0).Rows(i).Item("branch").ToString & "','" & omdsnam.Tables(0).Rows(i).Item("branchcode").ToString & "','0','" & omdsnam.Tables(0).Rows(i).Item("AccountNo").ToString & "',0,0,0,0,'" & Session("username") & "','" & Now.Date & "','" & omdsnam.Tables(0).Rows(i).Item("industry").ToString & "',0,'" & Session("username") & "','I',1)", cn)
                            If (cn.State = ConnectionState.Open) Then
                                cn.Close()
                            End If
                            cn.Open()
                            cmd.ExecuteNonQuery()
                            cn.Close()

                            'Label5.Text = "insert into mast (company,cds_number,date_created,shares,update_type,pladge,pledge_shares,created_by,updated_on,updated_by,locked,lock_reason,batch_ref,cert) values ('" & cmbParaCompany.SelectedItem.Text & "','" & Session("brokercode") & "" & omdsnam.Tables(0).Rows(i).Item("shareholder").ToString & "','" & Now.Date & "'," & omdsnam.Tables(0).Rows(i).Item("transshares").ToString & ",'TAKE ON',0,0,'" & Session("Username") & "','" & Now.Date & "','" & Session("username") & "',0,'-',0," & i & ""
                            cmd = New SqlCommand("insert into mast (company,cds_number,date_created,shares,update_type,pladge,pledge_shares,created_by,updated_on,updated_by,locked,lock_reason,batch_ref,cert) values ('" & cmbParaCompany.SelectedItem.Text & "','" & Session("brokercode") & "" & omdsnam.Tables(0).Rows(i).Item("shareholder").ToString & "','" & Now.Date & "'," & omdsnam.Tables(0).Rows(i).Item("transshares").ToString & ",'TAKE ON',0,0,'" & Session("Username") & "','" & Now.Date & "','" & Session("username") & "',0,'-',0," & i & ")", cn)
                            If (cn.State = ConnectionState.Open) Then
                                cn.Close()
                            End If
                            cn.Open()
                            cmd.ExecuteNonQuery()
                            cn.Close()

                            cmd = New SqlCommand("insert into trans (company,cds_number,date_created,trans_time,shares,update_type,created_by,batch_ref,source,pledge_shares) values ('" & cmbParaCompany.SelectedItem.Text & "','" & Session("brokercode") & "" & omdsnam.Tables(0).Rows(i).Item("shareholder").ToString & "','" & Now.Date & "','" & Now.Date.TimeOfDay.ToString & "'," & omdsnam.Tables(0).Rows(i).Item("transshares").ToString & ",'TAKE ON','" & Session("Username") & "',0,'T',0)", cn)
                            If (cn.State = ConnectionState.Open) Then
                                cn.Close()
                            End If

                            cn.Open()
                            cmd.ExecuteNonQuery()
                            cn.Close()

                        Next
                        msgbox("Import of data complete")
                    End If
                End If
                
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub cmbParaCompany_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbParaCompany.SelectedIndexChanged

    End Sub

    Protected Sub cmbParaCompany0_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbParaCompany0.SelectedIndexChanged

    End Sub
End Class
