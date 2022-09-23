Imports System.Data
Imports System.Data.SqlClient
Partial Class defaulters

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
            Try
                Dim a As New passmanagement
                a.auditlog(Session("BrokerCode"), Session("Username"), "Opened Pledges Report", "", "")
            Catch ex As Exception

            End Try
        Else
            If RadioButtonList1.SelectedItem.Text = "Active Pledges" Then
                Getwarehouseall(dtfrom.Text, dtto.Text, "PLEDGED")

            ElseIf RadioButtonList1.SelectedItem.Text = "Foreclosure Pledges" Then
                Getwarehouseall(dtfrom.Text, dtto.Text, "FORECLOSURE")
            ElseIf RadioButtonList1.SelectedItem.Text = "Released Pledges" Then
                Getwarehouseall(dtfrom.Text, dtto.Text, "RELEASED")

            End If

        End If
        If Session("finish") = "yes" Then
            Session("finish") = ""
            msgbox("Sent for Approval")
        End If
    End Sub
    Public Sub Getwarehouseall(opendate As String, closedate As String, Type As String)
        Dim ds As New DataSet
        cmd = New SqlCommand("  select Borrower, a.forenames+' '+a.surname as Names, Collateral, Format(AvailableQuantity,'#,0.00') as [Quantity], format(p.InterestRate,'#,0.00') as [Interest Rate],format(b.ServiceCharge,'#,0.00') as [Service Charges],  format(LoanAmount,'#,0.00') as [Requested Amount], format(AmountApproved,'#,0.00') as  [Approved Amount], format(isnull(AmountPaid,0),'#,0.00') as [Repaid Amount],  p.OptionName as [Option], CONVERT(NVARCHAR, EffectiveDate, 106) as EffectiveDate    from BorrowingRequest b, Accounts_Clients a, Para_lendingrules p where p.Bank+' '+p.OptionName=b.OptionName and a.CDS_Number=b.Borrower and b.bank='" + Session("BrokerCode") + "' and b.[status]='" + Type + "' ", cn)
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
        If RadioButtonList1.SelectedItem.Text = "Active Pledges" Then
            Getwarehouseall(dtfrom.Text, dtto.Text, "PLEDGED")

        ElseIf RadioButtonList1.SelectedItem.Text = "Foreclosure Pledges" Then
            Getwarehouseall(dtfrom.Text, dtto.Text, "FORECLOSURE")
        ElseIf RadioButtonList1.SelectedItem.Text = "Released Pledges" Then
            Getwarehouseall(dtfrom.Text, dtto.Text, "RELEASED")

        End If

    End Sub


    Protected Sub ASPxButton8_Click(sender As Object, e As EventArgs) Handles ASPxButton8.Click
        If RadioButtonList1.SelectedItem.Text = "Active Pledges" Then
            Getwarehouseall(dtfrom.Text, dtto.Text, "PLEDGED")

        ElseIf RadioButtonList1.SelectedItem.Text = "Foreclosure Pledges" Then
            Getwarehouseall(dtfrom.Text, dtto.Text, "FORECLOSURE")
        ElseIf RadioButtonList1.SelectedItem.Text = "Released Pledges" Then
            Getwarehouseall(dtfrom.Text, dtto.Text, "RELEASED")

        End If

        ASPxGridViewExporter1.WriteXlsToResponse()
    End Sub
    Protected Sub RadioButtonList1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles RadioButtonList1.SelectedIndexChanged
        If RadioButtonList1.SelectedItem.Text = "By Warehouse" Then


        ElseIf RadioButtonList1.SelectedItem.Text = "By Warehouse Operator" Then

        ElseIf RadioButtonList1.SelectedItem.Text = "By County" Then


        End If
    End Sub

End Class
