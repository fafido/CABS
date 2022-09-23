Partial Class TransferSec_AccountsTransfer
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
                getclasses_param()

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

    Protected Sub ASPxButton1_Click(sender As Object, e As EventArgs) Handles ASPxButton1.Click
        Try

     
        Dim ds As New DataSet
        cmd = New SqlCommand("select cds_number+' '+surname+' '+middlename+' '+forenames as names from accounts_clients where surname like '%' + @surname + '%'  and cds_number not in (select cds_number from account_transfer)", cn)
        cmd.Parameters.AddWithValue("@surname", ASPxTextBox2.Text)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "Accounts_Audit")
        If (ds.Tables(0).Rows.Count > 0) Then
            ASPxListBox1.DataSource = ds
            ASPxListBox1.TextField = "names"
            ASPxListBox1.DataBind()
            End If


        Catch ex As Exception

        End Try
    End Sub

    Protected Sub ASPxButton6_Click(sender As Object, e As EventArgs) Handles ASPxButton6.Click
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select cds_number+' '+surname+' '+middlename+' '+forenames as names from accounts_clients where cds_number like '%' + @cdsnumber + '%' and cds_number not in (select cds_number from account_transfer)", cn)
            cmd.Parameters.AddWithValue("@cdsnumber", txtClientNo8.Text)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "Accounts_Audit2")
            If (ds.Tables(0).Rows.Count > 0) Then
                ASPxListBox1.DataSource = ds
                ASPxListBox1.TextField = "names"
                ASPxListBox1.DataBind()
            End If
        Catch ex As Exception

        End Try
      
    End Sub

    Protected Sub ASPxListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ASPxListBox1.SelectedIndexChanged
        ASPxComboBox1.Items.Clear()
        resetclass()
        loadnames()
    End Sub
    Public Sub loadnames()
        Dim ds As New DataSet
        cmd = New SqlCommand("select cds_number, surname+' '+middlename+' '+forenames as surname, brokercode from accounts_clients where cds_number+' '+surname+' '+middlename+' '+forenames='" + ASPxListBox1.SelectedItem.Text + "'", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "Accounts_Audit2")
        If (ds.Tables(0).Rows.Count > 0) Then
            txtclientid.Text = ds.Tables(0).Rows(0).Item("cds_number")
            txtsurname.Text = ds.Tables(0).Rows(0).Item("surname")
            txtbrokercode.Text = ds.Tables(0).Rows(0).Item("brokercode")
            txtcurrentbroker.Text = ds.Tables(0).Rows(0).Item("brokercode")
            getclasses()
            Dim ds1 As New DataSet
            cmd = New SqlCommand("select distinct company as company from trans where cds_number = '" & txtclientid.Text & "'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds1, "trns")
            If ds1.Tables("trns").Rows.Count > 0 Then
                ASPxComboBox1.DataSource = ds1
                ASPxComboBox1.TextField = "company"
                ASPxComboBox1.DataBind()
            End If

        End If
    End Sub
    Public Sub getclasses()
        'txtbrokercode.Text = Session("brokercode")
        'txtcurrentbroker.Text = Session("usercompany")
    End Sub
    Public Sub getclasses_param()
        Dim ds1 As New DataSet
        cmd = New SqlCommand("select company_name, company_code from client_companies where company_type='Broker' and company_name<>'" + Session("usercompany") + "'", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds1, "Accounts_Audit2")
        If (ds1.Tables(0).Rows.Count > 0) Then
            cmbbrokers.DataSource = ds1
            cmbbrokers.TextField = "company_name"
            cmbbrokers.DataBind()

        End If
    End Sub
    Public Sub savenewclass()
        Dim ds1 As New DataSet
        cmd = New SqlCommand("select cds_number from account_transfer where cds_number=@cdsnumber", cn)
        cmd.Parameters.AddWithValue("@cdsnumber", txtclientid.Text)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds1, "Accounts_Audit3")
        If (ds1.Tables(0).Rows.Count > 0) Then
            cmd = New SqlCommand("Update account_transfer set to_broker=(select company_code  from client_companies where company_name='" + cmbbrokers.SelectedItem.Text + "') where cds_number=@cdsnumber", cn)
            cmd.Parameters.AddWithValue("@cdsnumber", txtclientid.Text)
            If (cn.State = ConnectionState.Open) Then
                cn.Close()
            End If
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()

           
            Try
                cmd = New SqlCommand("insert into audit_log ([userid],[date],[time],[name],[activity], [userid_2], [request_id],[Browser],[IP],[Machine],[Broker_id]) values((select id from systemusers where username='" & Session("username") & "' and companycode='" + Session("Brokercode") + "'),'" & Date.Now.Date & "','" & Date.Now.Hour & ":" & Date.Now.Minute & ":" & Date.Now.Second & "','" + Session("username") + "','Transferred an Account to another Broker',0,@clientid,'" + HttpContext.Current.Request.UserAgent + "','" + HttpContext.Current.Request.UserHostAddress + "','" + HttpContext.Current.Request.UserHostName + "','" + Session("brokercode") + "')", cn)
                cmd.Parameters.AddWithValue("@clientid", txtclientid.Text)
                If (cn.State = ConnectionState.Open) Then
                    cn.Close()
                End If
                cn.Open()
                cmd.ExecuteNonQuery()
                cn.Close()

            Catch ex As Exception

            End Try
            Session("finish") = "yes"
            Response.Redirect(Request.RawUrl)
        Else
            cmd = New SqlCommand("insert into account_transfer values ('" + txtclientid.Text + "','" + txtcurrentbroker.Text + "',(select company_code  from client_companies where company_name='" + cmbbrokers.SelectedItem.Text + "'), @comments,GEtdate(),0,@transferrable,'" + ASPxComboBox1.Text + "')", cn)
            cmd.Parameters.AddWithValue("@comments", ASPxTextBox4.Text)
            cmd.Parameters.AddWithValue("@transferrable", ASPxTextBox4.Text)
            If (cn.State = ConnectionState.Open) Then
                cn.Close()
            End If
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()

            Try
                cmd = New SqlCommand("insert into audit_log ([userid],[date],[time],[name],[activity], [userid_2], [request_id],[Browser],[IP],[Machine],[Broker_id]) values((select id from systemusers where username='" & Session("username") & "' and companycode=(select company_code from client_companies where company_name='" + +"')),'" & Date.Now.Date & "','" & Date.Now.Hour & ":" & Date.Now.Minute & ":" & Date.Now.Second & "','" + Session("username") + "','Transferred an Account to another Broker',0,'" + txtclientid.Text + "','" + HttpContext.Current.Request.UserAgent + "','" + HttpContext.Current.Request.UserHostAddress + "','" + HttpContext.Current.Request.UserHostName + "','" + Session("brokercode") + "')", cn)
                If (cn.State = ConnectionState.Open) Then
                    cn.Close()
                End If
                cn.Open()
                cmd.ExecuteNonQuery()
                cn.Close()

            Catch ex As Exception

            End Try
            Session("finish") = "yes"
            Response.Redirect(Request.RawUrl)
        End If
    End Sub

    Protected Sub ASPxButton5_Click(sender As Object, e As EventArgs) Handles ASPxButton5.Click
        Dim av As Decimal = ASPxTextBox3.Text
        Dim trans As Decimal = ASPxTextBox4.Text

        If trans > av Then
            msgbox("Transferrable Shares cannot be above portfolio!")
        Else
            savenewclass()
        End If


    End Sub
    Public Sub resetclass()
        txtbrokercode.Text = ""
        txtcurrentbroker.Text = ""
    End Sub

    Protected Sub ASPxButton7_Click(sender As Object, e As EventArgs) Handles ASPxButton7.Click
        Try

      
        Dim ds As New DataSet
        cmd = New SqlCommand("select cds_number+' '+surname+' '+forenames as names from accounts_clients where IDNOPP+' '+COALESCE(IDNOPP2,'') like '%' + @longstring + '%' order by date_created asc", cn)
        cmd.Parameters.AddWithValue("@longstring", txtClientNo9.Text)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "accounts_clients")
        If (ds.Tables(0).Rows.Count > 0) Then
            ASPxListBox1.DataSource = ds.Tables(0)
            ASPxListBox1.TextField = "names"
            ASPxListBox1.ValueField = "names"
            ASPxListBox1.DataBind()
            End If
        Catch ex As Exception

        End Try

    End Sub

    Protected Sub ASPxComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ASPxComboBox1.SelectedIndexChanged
        Dim ds As New DataSet
        cmd = New SqlCommand("select sum(shares) as shares from trans where cds_number = @clientid and company=@company", cn)
        cmd.Parameters.AddWithValue("@clientid", txtclientid.Text)
        cmd.Parameters.AddWithValue("@company", ASPxComboBox1.Text)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "accounts_clients1")
        If (ds.Tables(0).Rows.Count > 0) Then
            Try
                ASPxTextBox3.Text = ds.Tables(0).Rows(0).Item("shares")
                ASPxTextBox4.Text = ASPxTextBox3.Text
            Catch ex As Exception
                ASPxTextBox3.Text = 0
                ASPxTextBox4.Text = 0
            End Try
           
        End If
    End Sub

    Protected Sub cmbbrokers_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbbrokers.SelectedIndexChanged
        If ASPxComboBox1.Text <> "" And ASPxTextBox3.Text <> "" And ASPxTextBox4.Text <> "" Then
            ASPxButton5.Visible = True
        Else
            msgbox("Please fill all the required details!")
        End If
    End Sub
End Class