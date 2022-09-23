Partial Class history


    Inherits System.Web.UI.Page
    Dim constr As String = (System.Configuration.ConfigurationManager.AppSettings("connpath"))
    Dim cn As New SqlConnection(constr)
    Dim adp As SqlDataAdapter
    Dim cmd As SqlCommand
    Public sort As String
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
                msgbox("Successfully captured! Request sent for approval ")
            End If
            If (Not IsPostBack) Then
                checkSessionState()
                '  GetLenders()
                getcollateral()
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub



   


    Protected Sub ASPxButton5_Click(sender As Object, e As EventArgs) Handles ASPxButton5.Click
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select ba_number from bas where issuer='" + Session("brokercode") + "' and ba_number like '%" + txtcompany_name.Text + "%'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "Accounts_Clients")
            If (ds.Tables(0).Rows.Count > 0) Then
                ASPxListBox1.DataSource = ds
                ASPxListBox1.TextField = "ba_number"
                ASPxListBox1.DataBind()

            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub ASPxListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ASPxListBox1.SelectedIndexChanged
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select b.ba_number as [BA Number], b.date_sent as [Date], c.company_name as [Holder], b.Maturity_Date as [Maturity Date], b.face_value as [Face Value] from bas b, Client_Companies c where b.issuer=c.Company_Code  and b.BA_number='23840' union all select b.BA_number as [BA Number], b.date_received as [Date],  c.company_name as [Holder], d.Maturity_Date as [Maturity Date], d.face_value as [Face Value] from ba_mast b, client_companies c, bas d where b.ba_number='23840' and b.ba_number=d.ba_number and c.company_code= b.holder", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "Accounts_Clients")
            If (ds.Tables(0).Rows.Count > 0) Then
                grdEvent0.DataSource = ds
                grdEvent0.DataBind()

            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub ASPxButton4_Click(sender As Object, e As EventArgs) Handles ASPxButton4.Click

    End Sub
End Class
