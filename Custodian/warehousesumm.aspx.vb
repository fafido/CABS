Imports System.Data
Imports System.Data.SqlClient
Partial Class Warehousesumm
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

        Else
            If RadioButtonList1.SelectedItem.Text = "By Warehouse" Then
                Getwarehouseall(dtfrom.Text, dtto.Text)

            ElseIf RadioButtonList1.SelectedItem.Text = "By Warehouse Operator" Then
                Getwarehouseoperatorall(dtfrom.Text, dtto.Text)
            ElseIf RadioButtonList1.SelectedItem.Text = "By City" Then
                Getcountyall(dtfrom.Text, dtto.Text)

            End If

        End If
        If Session("finish") = "yes" Then
            Session("finish") = ""
            msgbox("Sent for Approval")
        End If
    End Sub

    Public Sub Getcountyall(opendate As String, closedate As String)
        Dim ds As New DataSet
        cmd = New SqlCommand("  select  c.city as City,Commodity as [Commodity],Grade  , FORMAT(sum(Quantity),'#,0.00') as [Total Holding], UnitMeasure, count(*) as [Number of Receipts]  from warehousecreation c, WR w, Accounts_Clients a WHERE A.cds_number=w.holder and c.warehousecode=w.Warehouse   and Convert(date, date_issued)>='" + opendate + "' and Convert(date, date_issued)<='" + closedate + "'   group by  c.city , Commodity , grade, UnitMeasure", cn)
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
        cmd = New SqlCommand("select  Warehouse as [Warehouse Operator],Commodity as [Commodity],Grade  , FORMAT(sum(Quantity),'#,0.00') as [Total Holding], UnitMeasure, count(*) as [Number of Receipts]   from WR w, Accounts_Clients a WHERE A.cds_number=w.holder  and Convert(date, date_issued)>='" + opendate + "' and Convert(date, date_issued)<='" + closedate + "'   group by warehouse, Commodity , grade, UnitMeasure", cn)
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
        cmd = New SqlCommand("select  WarehousePhysical as [Warehouse],Commodity as [Commodity],Grade  , FORMAT(sum(Quantity),'#,0.00') as [Total Holding],  UnitMeasure , count(*) as [Number of Receipts]  from WR w, Accounts_Clients a WHERE A.cds_number=w.holder  and Convert(date, date_issued)>='" + opendate + "' and Convert(date, date_issued)<='" + closedate + "'   group by warehousephysical, Commodity , grade, UnitMeasure", cn)
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


        ElseIf RadioButtonList1.SelectedItem.Text = "By Warehouse Operator" Then

        ElseIf RadioButtonList1.SelectedItem.Text = "By City" Then


        End If
    End Sub

End Class
