Imports System.Data
Imports System.Data.SqlClient
Partial Class deposits
    Inherits System.Web.UI.Page
    Dim constr As String = (System.Configuration.ConfigurationManager.AppSettings("connpath"))
    Dim cn As New SqlConnection(constr)
    Dim cmd As SqlCommand
    Dim adp As SqlDataAdapter
    Dim ds As New DataSet
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


   

    Public Sub Getorders()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select BrokerRef as [Order Ref],CDS_ac_no as [CDS Number], Broker_Code as [Broker], ClientName,convert(date, create_date) as [Date Created], Quantity, BasePrice as [Price], Quantity*BasePrice as [Value]   from testcds_ROUTER.dbo.Pre_Order_Live ", cn)
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
    Public Sub Getordersfiltered(ByVal opendate As String, closedate As String)
        '       Try
        Dim ds As New DataSet
        'cmd = New SqlCommand("select OrderNumber as [Order Ref],CDS_ac_no as [CDS Number], Broker_Code as [Broker], ClientName,convert(date, create_date) as [Date Created], Quantity, BasePrice as [Price], Quantity*BasePrice as [Value]   from testcds_ROUTER.dbo.Pre_Order_Live where company='" + company + "' and orderstatus='" + status + "' and convert(date,Create_date)>=convert(date,'" + opendate + "') and convert(date,Create_date)<=convert(date,'" + closedate + "') and ordertype='" + ordertype + "'", cn)
        If RadioButtonList1.SelectedValue = "Deposits" Then
            cmd = New SqlCommand("SELECT *FROM [CDSC].[dbo].[custodial_deposits] where [Type]='DEPOSIT' and convert(date,date)>=convert(date,'" + opendate + "') and convert(date,date)<=convert(date,'" + closedate + "')", cn)
        ElseIf RadioButtonList1.SelectedValue = "Withdrawals" Then
            cmd = New SqlCommand("SELECT *FROM [CDSC].[dbo].[custodial_deposits] where type='WITHDRAW' and convert(date,date)>=convert(date,'" + opendate + "') and convert(date,date)<=convert(date,'" + closedate + "')", cn)
        ElseIf RadioButtonList1.SelectedValue = "Totals" Then
            cmd = New SqlCommand("SELECT [ClientNumber],[Full Name],sum([Amount]) as Amount FROM [CDSC].[dbo].[custodial_deposits] where  convert(date,date)>=convert(date,'" + opendate + "') and convert(date,date)<=convert(date,'" + closedate + "') group by clientnumber, [full name]", cn)
        ElseIf RadioButtonList1.SelectedValue = "Uncleared" Then
            cmd = New SqlCommand("SELECT [ClientNumber],[Full Name],sum([Amount]) as Amount FROM [CDSC].[dbo].[custodial_deposits] where [status]='Uncleared'and convert(date,date)>=convert(date,'" + opendate + "') and convert(date,date)<=convert(date,'" + closedate + "') group by clientnumber, [full name]", cn)
        ElseIf RadioButtonList1.SelectedValue = "Cleared" Then
            cmd = New SqlCommand("SELECT [ClientNumber],[Full Name],sum([Amount]) as Amount FROM [CDSC].[dbo].[custodial_deposits] where [status]='cleared' and convert(date,date)>=convert(date,'" + opendate + "') and convert(date,date)<=convert(date,'" + closedate + "') group by clientnumber, [full name]", cn)
        End If
        adp = New SqlDataAdapter(cmd)

        adp.Fill(ds, "para_lendingRules")
        If (ds.Tables(0).Rows.Count > 0) Then
            grdRules.DataSource = ds.Tables(0)
            grdRules.DataBind()
        Else
            grdRules.DataSource = Nothing
            grdRules.DataBind()
        End If
        ' ''Catch ex As Exception
        ' ''    msgbox(ex.Message)
        ' ''End Try
    End Sub

    Protected Sub RadioButtonList1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles RadioButtonList1.SelectedIndexChanged
        lbltitle.Text = "" + RadioButtonList1.SelectedItem.Value + " Orders from"
    End Sub

    Protected Sub dtfrom_DateChanged(sender As Object, e As EventArgs) Handles dtfrom.DateChanged
        If lbltitle.Text <> "" Then
            lbltitle.Text = "" + lbltitle.Text + " " + dtfrom.Text + " to "
        End If
    End Sub

    Protected Sub dtto_DateChanged(sender As Object, e As EventArgs) Handles dtto.DateChanged

        If lbltitle.Text <> "" Then
            lbltitle.Text = "" + lbltitle.Text + " " + dtto.Text + ""
        End If
    End Sub

   

    Protected Sub ASPxButton1_Click(sender As Object, e As EventArgs) Handles ASPxButton1.Click
        Getordersfiltered(dtfrom.Text, dtto.Text)

    End Sub
 Protected Sub ASPxButton8_Click(sender As Object, e As EventArgs) Handles ASPxButton8.Click

		
        Getordersfiltered(dtfrom.Text, dtto.Text)

       
        ASPxGridViewExporter1.WriteXlsToResponse()
    End Sub

End Class
