Partial Class TransferSec_broker_transfer2
    Inherits System.Web.UI.Page
    Dim constr As String = (System.Configuration.ConfigurationManager.AppSettings("connpath"))
    Dim cn As New SqlConnection(constr)
    Dim adp As SqlDataAdapter
    Dim cmd As SqlCommand
    Public brok As String
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
                getclasses_param()
                getpending()
            End If
            If Session("finish") = "yes" Then
                Session("finish") = ""
                msgbox("Successful")
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub ASPxTextBox12_TextChanged(sender As Object, e As EventArgs) Handles txtsurname.TextChanged

    End Sub



    Public Sub getpending()

        Dim ds As New DataSet
        cmd = New SqlCommand("select cds_number  from account_transfer where authorized='1'", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "Accounts_Audit2")
        If (ds.Tables(0).Rows.Count > 0) Then
            cmbpending.DataSource = ds
            cmbpending.TextField = "cds_number"
            cmbpending.DataBind()

        End If
    End Sub


    Public Sub loadnames()
        Dim ds As New DataSet
        cmd = New SqlCommand("select * from accounts_clients where cds_number='" + cmbpending.SelectedItem.Text + "'", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "Accounts_Audit2")
        If (ds.Tables(0).Rows.Count > 0) Then
            txtclientid.Text = ds.Tables(0).Rows(0).Item("cds_number")
            txtsurname.Text = ds.Tables(0).Rows(0).Item("surname")
            brok = ds.Tables(0).Rows(0).Item("brokercode")
            getclasses()
            loadcurr()
            

        End If
    End Sub
    Public Sub loadcurr()
        Dim ds As New DataSet
        cmd = New SqlCommand("select company_name from client_companies where company_code='" + brok + "'", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "Accounts_Audit3")
        If (ds.Tables(0).Rows.Count > 0) Then
            txtcurrentbroker.Text = ds.Tables(0).Rows(0).Item("company_name")

        End If
    End Sub
    Public Sub getclasses()
        txtbrokercode.Text = Session("brokercode")


        Dim ds1 As New DataSet
        cmd = New SqlCommand("select c.company_name as company, a.comment, a.company as comptrans, a.part_portfolio from Client_Companies c, account_transfer a where c.Company_Code= a.to_broker and a.cds_number='" + txtclientid.Text + "'", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds1, "Accounts_Audit2")
        If (ds1.Tables(0).Rows.Count > 0) Then
            txtnewbroker.Text = ds1.Tables(0).Rows(0).Item("company")
            txtComments.Text = ds1.Tables(0).Rows(0).Item("comment")
            txtcompany.Text = ds1.Tables(0).Rows(0).Item("comptrans")
            txtportfolio.Text = ds1.Tables(0).Rows(0).Item("part_portfolio")
        End If
    End Sub
    Public Sub getclasses_param()
        Dim ds1 As New DataSet
        cmd = New SqlCommand("select company_name, company_code from client_companies where company_type='Broker' and company_name<>'" + Session("usercompany") + "'", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds1, "Accounts_Audit2")
        If (ds1.Tables(0).Rows.Count > 0) Then


        End If
    End Sub
    Public Sub savenewclass()
        Dim ds1 As New DataSet
        cmd = New SqlCommand("select cds_number from account_transfer where cds_number='" + txtclientid.Text + "'", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds1, "Accounts_Audit3")
        If (ds1.Tables(0).Rows.Count > 0) Then
            cmd = New SqlCommand("Update account_transfer set to_broker=(select company_code  from client_companies where company_name='" + +"') where cds_number='" + txtclientid.Text + "'", cn)
            If (cn.State = ConnectionState.Open) Then
                cn.Close()
            End If
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()

            Session("finish") = "yes"
            Response.Redirect(Request.RawUrl)
        Else
            cmd = New SqlCommand("insert into account_transfer values ('" + txtclientid.Text + "','" + Session("brokercode") + "',(select company_code  from client_companies where company_name='" + +"'), '" + txtComments.Text + "',GEtdate(),0)", cn)
            If (cn.State = ConnectionState.Open) Then
                cn.Close()
            End If
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()

            Session("finish") = "yes"
            Response.Redirect(Request.RawUrl)
        End If
    End Sub

    Protected Sub ASPxButton5_Click(sender As Object, e As EventArgs) Handles ASPxButton5.Click
        '     Dim 

        'cmd = New SqlCommand(" update accounts_clients set brokercode=(select company_code from client_companies where company_name='" + txtnewbroker.Text + "') where cds_number='" + txtclientid.Text + "'", cn)
        'If (cn.State = ConnectionState.Open) Then
        '    cn.Close()
        'End If
        'cn.Open()
        'cmd.ExecuteNonQuery()
        'cn.Close()

        'cmd = New SqlCommand("update names set broker_code=(select company_code from client_companies where company_name='" + txtnewbroker.Text + "') where cds_number='" + txtclientid.Text + "'", cn)
        'If (cn.State = ConnectionState.Open) Then
        '    cn.Close()
        'End If
        'cn.Open()
        'cmd.ExecuteNonQuery()
        'cn.Close()

        cmd = New SqlCommand("insert into accounts_clients SELECT top 1 REPLACE(cds_number,(select id from client_companies where company_name='" + txtcurrentbroker.Text + "'),(select id from client_companies where company_name='" + txtnewbroker.Text + "')),(select company_code from client_companies where company_name='" + txtnewbroker.Text + "'),[AccountType]      ,[Surname]      ,[Middlename]      ,[Forenames]      ,[Initials]      ,[Title]      ,[IDNoPP]      ,[IDtype]      ,[Nationality]      ,[DOB]      ,[Gender]      ,[Add_1]      ,[Add_2]      ,[Add_3]      ,[Add_4]      ,[Country]      ,[City]      ,[Tel]      ,[Mobile]      ,[Email]      ,[Category]      ,[Custodian]      ,[TradingStatus]      ,[Industry]      ,[Tax]      ,[Div_Bank]      ,[Div_Branch]      ,[Div_AccountNo]      ,[Cash_Bank]      ,[Cash_Branch]      ,[Cash_AccountNo]      ,[Client_Image]      ,[Documents]      ,[BioMatrix]      ,[Attached_Documents]      ,[Date_Created]      ,[Update_Type]      ,[Created_By]      ,[AccountState]      ,[Comments]      ,[DivPayee]      ,[SettlementPayee]      ,[Account_class]      ,[idnopp2]      ,[idtype2]      ,[client_image2]      ,[documents2]      ,[isin]      ,[company_code]      ,[mobile_money]      ,[mobile_number],'1',currency  FROM [Accounts_Clients] where cds_number='" + txtclientid.Text + "' insert into trans (company, cds_number, date_created, trans_time, shares, Update_Type, Created_By,Batch_Ref,Source, Pledge_shares, Instrument)  select top 1 '" + txtcompany.Text + "', cds_number, getdate(),'" & Date.Now.Hour & ":" & Date.Now.Minute & "',-" + txtportfolio.Text + ", 'BT','" + Session("username") + "',0,'S','0','' from Accounts_Clients  where cds_number= '" + txtclientid.Text + "' insert into trans (company, cds_number, date_created, trans_time, shares, Update_Type, Created_By,Batch_Ref,Source, Pledge_shares, INSTRUMENT)  select top 1 '" + txtcompany.Text + "', REPLACE(cds_number,(select id from client_companies where company_name='" + txtcurrentbroker.Text + "'),(select id from client_companies where company_name='" + txtnewbroker.Text + "')), getdate(),'" & Date.Now.Hour & ":" & Date.Now.Minute & "'," + txtportfolio.Text + ", 'BT','" + Session("username") + "',0,'S','0', '' from Accounts_Clients where cds_number ='" + txtclientid.Text + "'", cn)
        If (cn.State = ConnectionState.Open) Then
            cn.Close()
        End If
        cn.Open()
        cmd.ExecuteNonQuery()
        cn.Close()

        cmd = New SqlCommand("insert into broker_transfers select cds_number, from_broker, to_broker, comment, date_sent, authorized, part_portfolio, company from account_transfer where cds_number='" + txtclientid.Text + "'   delete from account_transfer where cds_number='" + txtclientid.Text + "'", cn)
        If (cn.State = ConnectionState.Open) Then
            cn.Close()
        End If
        cn.Open()
        cmd.ExecuteNonQuery()
        cn.Close()

        Session("finish") = "yes"
        Response.Redirect(Request.RawUrl)

    End Sub
    Public Sub resetclass()
        txtbrokercode.Text = ""
        txtcurrentbroker.Text = ""
    End Sub

    Protected Sub cmbpending_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbpending.SelectedIndexChanged
        resetclass()
        loadnames()
        getclasses()

    End Sub
End Class