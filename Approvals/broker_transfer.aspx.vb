Partial Class TransferSec_broker_transfer
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
        cmd = New SqlCommand("select cds_number  from account_transfer where authorized='0' and from_broker='" + Session("brokercode") + "'", cn)
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
        
            getclasses()

       
        End If
    End Sub
    Public Sub getclasses()
        txtbrokercode.Text = Session("brokercode")
        txtcurrentbroker.Text = Session("usercompany")

        Dim ds1 As New DataSet
        cmd = New SqlCommand("select c.company_name as company, a.comment, a.part_portfolio, a.company as comptrans from Client_Companies c, account_transfer a where c.Company_Code= a.to_broker and a.cds_number='" + txtclientid.Text + "'", cn)
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

        cmd = New SqlCommand("Update account_transfer set authorized='1' where cds_number='" + txtclientid.Text + "'", cn)
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

    Protected Sub txtComments_TextChanged(sender As Object, e As EventArgs) Handles txtComments.TextChanged

    End Sub
End Class