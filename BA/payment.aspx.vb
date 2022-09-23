Partial Class BA_payment
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
    Public Sub GetLenders()
        Try
            Dim ds As New DataSet
            'cmd = New SqlCommand("select distinct (convert(varchar,id)+' '+cds_number+' '+company) as namess from lendersRegister where expirydate <='" & Now.Date & "'", cn)
            cmd = New SqlCommand("select distinct (convert(varchar,id)+' '+cds_number+' '+company) as namess from lendersRegister where expirydate >='" & Now.Date & "'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "lendersRegister")
            If (ds.Tables(0).Rows.Count > 0) Then

            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub GetSectype()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select distinct (SecCode) from sec_types", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "sec_types")
            If (ds.Tables(0).Rows.Count > 0) Then

            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub getcollateral()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select distinct (collateral_name) from para_collateral", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "trans1")
            If (ds.Tables(0).Rows.Count > 0) Then

            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub GetCompany()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select distinct (company) from trans", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "trans")
            If (ds.Tables(0).Rows.Count > 0) Then

            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub checkSessionState()
        Try
            GetCompany()
            GetSectype()
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
                '  GetLenders()
                getcollateral()
                GetDetails()

            End If
            If Session("finish") = "Yes" Then
                Session("finish") = ""
                msgbox("Successful")
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub


    Public Sub GetDetails()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select * from Accepted_offers a,offers o, client_companies c, bas b where a.ba_number=b.BA_number and a.from_participant=c.Company_Code and o.id=a.offer_number and a.to_participant='" + Session("Brokercode") + "' and a.payment_notification<>1", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "Accounts_Clients")
            If (ds.Tables(0).Rows.Count > 0) Then
                grdEvent0.DataSource = ds
                grdEvent0.DataBind()
            Else
                grdEvent0.DataSource = Nothing
                grdEvent0.DataBind()
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub



    Protected Sub grdEvent0_SelectedIndexChanged(sender As Object, e As EventArgs) Handles grdEvent0.SelectedIndexChanged
       
        Response.Redirect("BATrans.aspx?ba_number=" + grdEvent0.Rows(0).Cells(0).Text + "&type=payment&id=" + grdEvent0.SelectedValue.ToString + "")
        '       msgbox()

        'Panel3.Visible = True

    End Sub

    'Public Sub insert_accept()
    '    Dim ds As New DataSet
    '    cmd = New SqlCommand("select * from offers o, client_companies c, Client_Companies c1, bas b where o.offer_by= c.Company_Code and c1.Company_Code=b.issuer and b.BA_number=o.ba_number and o.id='" + txtofferid.Text + "'", cn)
    '    adp = New SqlDataAdapter(cmd)
    '    adp.Fill(ds, "Accounts_Clients3")
    '    If (ds.Tables("Accounts_clients3").Rows.Count > 0) Then
    '        cmd = New SqlCommand("insert into Accepted_offers values ('" + ds.Tables(0).Rows(0).Item("ba_number") + "','" + txtofferid.Text + "',0,'" + ds.Tables(0).Rows(0).Item("Issuer") + "','" + ds.Tables(0).Rows(0).Item("company_code") + "',0)", cn)
    '        If (cn.State = ConnectionState.Open) Then
    '            cn.Close()
    '        End If
    '        cn.Open()
    '        cmd.ExecuteNonQuery()
    '        cn.Close()
    '    End If
    '    Session("finish") = "Yes"
    '    Response.Redirect(Request.RawUrl)
    'End Sub

   
End Class
