Imports System.Data
Imports System.Data.SqlClient
Partial Class Participants
    Inherits System.Web.UI.Page
    Dim constr As String = (System.Configuration.ConfigurationManager.AppSettings("connpath"))
    Dim cn As New SqlConnection(constr)
    Dim cmd As SqlCommand
    Dim adp As SqlDataAdapter
    Dim ds As New DataSet
    Dim validate As Boolean = False
    Dim maxholder As Integer = 0
    Public Sub msgbox(ByVal strMessage As String)

        'finishes server processing, returns to client.
        Dim strScript As String = "<script language=JavaScript>"
        strScript += "window.alert(""" & strMessage & """);"
        strScript += "</script>"
        Dim lbl As New System.Web.UI.WebControls.Label
        lbl.Text = strScript
        Page.Controls.Add(lbl)

    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Page.MaintainScrollPositionOnPostBack = True
        If (Not IsPostBack) Then

            '   Getorders()
        Else
            'If RadioButtonList2.SelectedItem.Text = "Fidelity Insurance" Then
            '    GetAll(dtfrom.Text, dtto.Text)
            'Else
            '    GetAll_A(dtfrom.Text, dtto.Text)
            'End If
        End If
        If Session("finish") = "yes" Then
            Session("finish") = ""
            msgbox("Sent for Approval")
        End If
    End Sub

    Public Sub GetAll(opendate As String, closedate As String)
        Dim ds As New DataSet
        cmd = New SqlCommand("  SELECT Company_name as [Participant Name], company_code as [Participant Code], AccountManager as [Representative], [Contact_phone] as [Phone], case [status] when 1 then 'Active' else 'Suspended' end as [Status], i.PolicyNumber as [Policy No.], i.InsuranceCompany as [Insured By], i.Expiry as [Expiry]    from client_companies C, InsurancePolicies i where company_type='WAREHOUSE' and i.Participant=c.Company_Code and i.Expiry>='" + dtfrom.Text + "' and i.Expiry<='" + dtto.Text + "'", cn)
        adp = New SqlDataAdapter(cmd)
        cmd.CommandTimeout = 99999
        adp.Fill(ds, "para_lendingRules")
        If (ds.Tables(0).Rows.Count > 0) Then
            grdRules.DataSource = ds.Tables(0)
            grdRules.DataBind()
        Else
            grdRules.DataSource = Nothing
            grdRules.DataBind()
        End If
    End Sub
    Public Sub GetAll_A(opendate As String, closedate As String)
        Dim ds As New DataSet
        cmd = New SqlCommand("  SELECT Company_name as [Participant Name], company_code as [Participant Code], AccountManager as [Representative], [Contact_phone] as [Phone], case [status] when 1 then 'Active' else 'Suspended' end as [Status], i.A_PolicyNumber as [Policy No.], i.A_InsuranceCompany as [Insured By], i.A_Expiry as [Expiry]    from client_companies C, InsurancePolicies i where company_type='WAREHOUSE' and i.Participant=c.Company_Code and i.A_Expiry>='" + dtfrom.Text + "' and i.A_Expiry<='" + dtto.Text + "'", cn)
        adp = New SqlDataAdapter(cmd)
        cmd.CommandTimeout = 99999
        adp.Fill(ds, "para_lendingRules")
        If (ds.Tables(0).Rows.Count > 0) Then
            grdRules.DataSource = ds.Tables(0)
            grdRules.DataBind()
        Else
            grdRules.DataSource = Nothing
            grdRules.DataBind()
        End If
    End Sub









    Protected Sub ASPxButton1_Click(sender As Object, e As EventArgs) Handles ASPxButton1.Click
        grdRules.DataSource = Nothing
        grdRules.DataBind()

        If RadioButtonList2.SelectedItem.Text = "Fidelity Insurance" Then
            GetAll(dtfrom.Text, dtto.Text)
        Else
            GetAll_A(dtfrom.Text, dtto.Text)
        End If





    End Sub


    Protected Sub ASPxButton8_Click(sender As Object, e As EventArgs) Handles ASPxButton8.Click
        If RadioButtonList2.SelectedItem.Text = "Fidelity Insurance" Then
            GetAll(dtfrom.Text, dtto.Text)
            ASPxGridViewExporter1.WriteXlsToResponse()
        Else
            GetAll_A(dtfrom.Text, dtto.Text)
            ASPxGridViewExporter1.WriteXlsToResponse()
        End If

    End Sub


End Class
