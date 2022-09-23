Imports System.Data
Imports System.Data.SqlClient
Partial Class Warehousecons
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
            Try
                If RadioButtonList1.SelectedItem.Text = "By Warehouse" Then
                    Getwarehouseall(dtfrom.Text, dtto.Text)

                ElseIf RadioButtonList1.SelectedItem.Text = "By Warehouse Operator" Then
                    Getwarehouseoperatorall(dtfrom.Text, dtto.Text)
                ElseIf RadioButtonList1.SelectedItem.Text = "By City" Then
                    Getcountyall(dtfrom.Text, dtto.Text)

                End If
            Catch ex As Exception

            End Try

        End If
        If Session("finish") = "yes" Then
            Session("finish") = ""
            msgbox("Sent for Approval")
        End If
    End Sub

    Public Sub Getcountyall(opendate As String, closedate As String)
        Dim ds As New DataSet
        cmd = New SqlCommand("select a.CDS_Number AS [ClientNo],a.Surname+' '+a.Forenames as [Names], Commodity as [Commodity],Grade, ReceiptNo, InsurancePolicy, format(Quantity,'#,0.00') as Quantity,UnitMeasure, Convert(date, date_issued) as [Issue Date], Convert(date, expiry) as [Expiry]  from WR w, Accounts_Clients a WHERE A.cds_number=w.holder  and Convert(date, date_issued)>='" + opendate + "' and Convert(date, date_issued)<='" + closedate + "' and Warehouse in  (select warehousecode from Warehousecreation where city= '" + DropDownList1.SelectedItem.Text + "')", cn)
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
    Public Sub Getwarehouseoperatorall(opendate As String, closedate As String)
        Dim ds As New DataSet
        cmd = New SqlCommand("select a.CDS_Number AS [ClientNo],a.Surname+' '+a.Forenames as [Names], Commodity as [Commodity],Grade, ReceiptNo, InsurancePolicy,  format(Quantity,'#,0.00') as Quantity,  UnitMeasure, Convert(date, date_issued) as [Issue Date], Convert(date, expiry) as [Expiry]  from WR w, Accounts_Clients a WHERE A.cds_number=w.holder  and Convert(date, date_issued)>='" + opendate + "' and Convert(date, date_issued)<='" + closedate + "' and Warehouse='" + DropDownList1.SelectedItem.Text + "'", cn)
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



    Public Sub Getwarehouseall(opendate As String, closedate As String)
        Dim ds As New DataSet
        cmd = New SqlCommand("select a.CDS_Number AS [ClientNo],a.Surname+' '+a.Forenames as [Names], Commodity as [Commodity],Grade, ReceiptNo, InsurancePolicy, format(Quantity,'#,0.00') as Quantity,  UnitMeasure, Convert(date, date_issued) as [Issue Date], Convert(date, expiry) as [Expiry]  from WR w, Accounts_Clients a WHERE A.cds_number=w.holder  and Convert(date, date_issued)>='" + opendate + "' and Convert(date, date_issued)<='" + closedate + "' and WarehousePhysical='" + DropDownList1.SelectedItem.Text + "'", cn)
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
    Public Sub getcounty()
        Dim ds As New DataSet
        cmd = New SqlCommand("select distinct city from Warehousecreation", cn)
        adp = New SqlDataAdapter(cmd)
        cmd.CommandTimeout = 99999
        adp.Fill(ds, "para_lendingRules")

        If (ds.Tables(0).Rows.Count > 0) Then
            DropDownList1.DataSource = ds
            DropDownList1.DataTextField = "city"
            DropDownList1.DataValueField = "city"
            DropDownList1.DataBind()

        End If

    End Sub
    Public Sub getwarehouse()
        Dim ds As New DataSet
        cmd = New SqlCommand("select Warehousecode from warehousecreation", cn)
        adp = New SqlDataAdapter(cmd)
        cmd.CommandTimeout = 99999
        adp.Fill(ds, "para_lendingRules")

        If (ds.Tables(0).Rows.Count > 0) Then
            DropDownList1.DataSource = ds
            DropDownList1.DataTextField = "warehousecode"
            DropDownList1.DataValueField = "warehousecode"
            DropDownList1.DataBind()

        End If

    End Sub
    Public Sub getwarehouseoperators()
        Dim ds As New DataSet
        cmd = New SqlCommand("select company_code from client_companies where company_type='WAREHOUSE'", cn)
        adp = New SqlDataAdapter(cmd)
        cmd.CommandTimeout = 99999
        adp.Fill(ds, "para_lendingRules")

        If (ds.Tables(0).Rows.Count > 0) Then
            DropDownList1.DataSource = ds
            DropDownList1.DataTextField = "company_code"
            DropDownList1.DataValueField = "company_code"
            DropDownList1.DataBind()

        End If

    End Sub


    Protected Sub ASPxButton1_Click(sender As Object, e As EventArgs) Handles ASPxButton1.Click
        If RadioButtonList1.SelectedItem.Text = "By Warehouse" Then
            Getwarehouseall(dtfrom.Text, dtto.Text)

        ElseIf RadioButtonList1.SelectedItem.Text = "By Warehouse Operator" Then
            Getwarehouseoperatorall(dtfrom.Text, dtto.Text)
        ElseIf RadioButtonList1.SelectedItem.Text = "By City" Then
            Getcountyall(dtfrom.Text, dtto.Text)

        End If

    End Sub


    Protected Sub ASPxButton8_Click(sender As Object, e As EventArgs) Handles ASPxButton8.Click
        If RadioButtonList1.SelectedItem.Text = "By Warehouse" Then
            Getwarehouseall(dtfrom.Text, dtto.Text)

        ElseIf RadioButtonList1.SelectedItem.Text = "By Warehouse Operator" Then
            Getwarehouseoperatorall(dtfrom.Text, dtto.Text)
        ElseIf RadioButtonList1.SelectedItem.Text = "By City" Then
            Getcountyall(dtfrom.Text, dtto.Text)

        End If

        ASPxGridViewExporter1.WriteXlsToResponse()
    End Sub
    Protected Sub RadioButtonList1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles RadioButtonList1.SelectedIndexChanged
        If RadioButtonList1.SelectedItem.Text = "By Warehouse" Then
            getwarehouse()

        ElseIf RadioButtonList1.SelectedItem.Text = "By Warehouse Operator" Then
            getwarehouseoperators()
        ElseIf RadioButtonList1.SelectedItem.Text = "By City" Then
            getcounty()

        End If
    End Sub

End Class
