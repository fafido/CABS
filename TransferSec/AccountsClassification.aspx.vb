Partial Class TransferSec_AccountsClassification
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
        Dim ds As New DataSet
        cmd = New SqlCommand("select cds_number+' '+surname+' '+middlename+' '+forenames as names from accounts_clients where surname like '%" + ASPxTextBox2.Text + "%' and brokercode='" + Session("brokercode") + "'", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "Accounts_Audit")
        If (ds.Tables(0).Rows.Count > 0) Then
            ASPxListBox1.DataSource = ds
            ASPxListBox1.TextField = "names"
            ASPxListBox1.DataBind()
        End If
    End Sub

    Protected Sub ASPxButton6_Click(sender As Object, e As EventArgs) Handles ASPxButton6.Click
        Dim ds As New DataSet
        cmd = New SqlCommand("select cds_number+' '+surname+' '+middlename+' '+forenames as names from accounts_clients where cds_number like '%" + txtClientNo8.Text + "%' and brokercode='" + Session("brokercode") + "'", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "Accounts_Audit2")
        If (ds.Tables(0).Rows.Count > 0) Then
            ASPxListBox1.DataSource = ds
            ASPxListBox1.TextField = "names"
            ASPxListBox1.DataBind()
        End If
    End Sub

    Protected Sub ASPxListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ASPxListBox1.SelectedIndexChanged

        resetclass()
        loadnames()
    End Sub
    Public Sub loadnames()
        Dim ds As New DataSet
        cmd = New SqlCommand("select * from accounts_clients where cds_number+' '+surname+' '+middlename+' '+forenames='" + ASPxListBox1.SelectedItem.Text + "'", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "Accounts_Audit2")
        If (ds.Tables(0).Rows.Count > 0) Then
            txtclientid.Text = ds.Tables(0).Rows(0).Item("cds_number")
            txtsurname.Text = ds.Tables(0).Rows(0).Item("surname")
           

            getclasses()

        

        End If
    End Sub
    Public Sub getclasses()
        Dim ds1 As New DataSet
        cmd = New SqlCommand("select class from accounts_classes where cds_number='" + txtclientid.Text + "'", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds1, "Accounts_Audit2")
        If (ds1.Tables(0).Rows.Count > 0) Then
            txtclasscode.Text = ds1.Tables(0).Rows(0).Item("class")
            Dim ds2 As New DataSet
            cmd = New SqlCommand("select class_name from para_brokerclasses where class_code='" + txtclasscode.Text + "'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds2, "Accounts_Auditnew")
            If (ds2.Tables(0).Rows.Count > 0) Then
                txtcurrentclass.Text = ds2.Tables(0).Rows(0).Item("class_name")

            End If
        End If
    End Sub
    Public Sub getclasses_param()
        Dim ds1 As New DataSet
        cmd = New SqlCommand("select class_name from para_brokerclasses", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds1, "Accounts_Audit2")
        If (ds1.Tables(0).Rows.Count > 0) Then
            cmbclasstype.DataSource = ds1
            cmbclasstype.TextField = "class_name"
            cmbclasstype.DataBind()

        End If
    End Sub
    Public Sub savenewclass()
        Dim ds1 As New DataSet
        cmd = New SqlCommand("select cds_number from accounts_classes where cds_number='" + txtclientid.Text + "'", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds1, "Accounts_Audit3")
        If (ds1.Tables(0).Rows.Count > 0) Then
            cmd = New SqlCommand("Update accounts_classes set class=(select class_code from para_brokerclasses where class_name='" + cmbclasstype.SelectedItem.Text + "') where cds_number='" + txtclientid.Text + "'", cn)
            If (cn.State = ConnectionState.Open) Then
                cn.Close()
            End If
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()
            Try
                cmd = New SqlCommand("insert into audit_log ([userid],[date],[time],[name],[activity], [userid_2], [request_id],[Browser],[IP],[Machine],[Broker_id]) values((select id from systemusers where username='" & Session("username") & "' and companycode='" + Session("Brokercode") + "'),'" & Date.Now.Date & "','" & Date.Now.Hour & ":" & Date.Now.Minute & ":" & Date.Now.Second & "','" + Session("username") + "','Classified a Shareholder',0,'" + txtclientid.Text + "','" + HttpContext.Current.Request.UserAgent + "','" + HttpContext.Current.Request.UserHostAddress + "','" + HttpContext.Current.Request.UserHostName + "','" + Session("brokercode") + "')", cn)
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
            cmd = New SqlCommand("insert into accounts_classes values ('" + txtclientid.Text + "',(select class_code from para_brokerclasses where class_name='" + cmbclasstype.SelectedItem.Text + "'), '" + txtComments.Text + "')", cn)
            If (cn.State = ConnectionState.Open) Then
                cn.Close()
            End If
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()
            Try
                cmd = New SqlCommand("insert into audit_log ([userid],[date],[time],[name],[activity], [userid_2], [request_id],[Browser],[IP],[Machine],[Broker_id]) values((select id from systemusers where username='" & Session("username") & "' and companycode='" + Session("Brokercode") + "'),'" & Date.Now.Date & "','" & Date.Now.Hour & ":" & Date.Now.Minute & ":" & Date.Now.Second & "','" + Session("username") + "','Classified a Shareholder',0,'" + txtclientid.Text + "','" + HttpContext.Current.Request.UserAgent + "','" + HttpContext.Current.Request.UserHostAddress + "','" + HttpContext.Current.Request.UserHostName + "','" + Session("brokercode") + "')", cn)
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
        savenewclass()

    End Sub
    Public Sub resetclass()
        txtclasscode.Text = ""
        txtcurrentclass.Text = ""
    End Sub

    Protected Sub ASPxButton7_Click(sender As Object, e As EventArgs) Handles ASPxButton7.Click
        Dim ds As New DataSet
        cmd = New SqlCommand("select cds_number+' '+surname+' '+forenames as namess from accounts_clients where IDNOPP+' '+COALESCE(IDNOPP2,'') like '%" & txtClientNo9.Text & "%' and brokercode='" + Session("brokercode") + "' order by date_created asc", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "accounts_clients")
        If (ds.Tables(0).Rows.Count > 0) Then
            ASPxListBox1.DataSource = ds.Tables(0)
            ASPxListBox1.TextField = "namess"
            ASPxListBox1.ValueField = "namess"
            ASPxListBox1.DataBind()
        End If
    End Sub
End Class
