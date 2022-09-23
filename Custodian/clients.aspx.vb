Imports System.Data
Imports System.Data.SqlClient
Partial Class clients
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

        End If
        If Session("finish") = "yes" Then
            Session("finish") = ""
            msgbox("Sent for Approval")
        End If
    End Sub




    Public Sub getdeliveries()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select Holder, a.surname+' '+a.forenames as [Names], Commodity, Quantity as [Available Quantity], OriginalQuantity, UnitMeasure, Warehouse, WarehouseOperator  from warehoursedeliveries w, Accounts_Clients a where a.cds_number=w.holder and convert(date, w.Date_Issued)>='" + dtfrom.Text + "' and convert(date, w.Date_Issued)<='" + dtto.Text + "'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "para_lendingRules")
            If (ds.Tables(0).Rows.Count > 0) Then
                grdRules.DataSource = ds.Tables(0)
                grdRules.DataBind()
            Else
                grdRules.DataSource = Nothing
                grdRules.DataBind()
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub getreceipts()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select Holder, a.surname+' '+a.forenames as [Names], Commodity,Grade,ReceiptNo, Quantity as [Available Quantity], OriginalQuantity, UnitMeasure, Warehouse as [Warehouse Operator], Warehousephysical as [Warehouse]  from wr w, Accounts_Clients a where a.cds_number=w.holder and convert(date, w.Date_Issued)>='" + dtfrom.Text + "' and convert(date, w.Date_Issued)<='" + dtto.Text + "'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "para_lendingRules")
            If (ds.Tables(0).Rows.Count > 0) Then
                grdRules.DataSource = ds.Tables(0)
                grdRules.DataBind()
            Else
                grdRules.DataSource = Nothing
                grdRules.DataBind()
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub











    Protected Sub ASPxButton1_Click(sender As Object, e As EventArgs) Handles ASPxButton1.Click
        Try

            If RadioButtonList1.SelectedItem.Text = "RECEIPT HOLDERS" Then
            getreceipts()
        ElseIf RadioButtonList1.SelectedItem.Text = "DEPOSITORS" Then
            getdeliveries()

        End If


        Catch ex As Exception

        End Try


    End Sub


    Protected Sub ASPxButton8_Click(sender As Object, e As EventArgs) Handles ASPxButton8.Click
        Try

            If RadioButtonList1.SelectedItem.Text = "RECEIPT HOLDERS" Then
                getreceipts()
            ElseIf RadioButtonList1.SelectedItem.Text = "DEPOSITORS" Then
                getdeliveries()

            End If


        Catch ex As Exception

        End Try
        ASPxGridViewExporter1.WriteXlsToResponse()
    End Sub
End Class
