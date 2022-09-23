Imports System.Data
Imports System.Data.SqlClient
Partial Class Charges
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

            getalltypes()

            '   Getorders()
        Else
            If RadioButtonList1.SelectedItem.Text = "Depositor" Then
                GetAllPENDING_dep(dtfrom.Text, dtto.Text)
            Else
                GetAllPENDING_part(dtfrom.Text, dtto.Text)
            End If
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
    Public Sub getalltypes()
        Dim ds As New DataSet
        cmd = New SqlCommand("select distinct [Description] from cashtranscomb", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "para_lendingRules")
        If (ds.Tables(0).Rows.Count > 0) Then
            DropDownList1.DataSource = ds
            DropDownList1.DataTextField = "description"
            DropDownList1.DataValueField = "description"
            DropDownList1.DataBind()

        End If
    End Sub
    Public Sub GetAll(opendate As String, closedate As String)
        Dim ds As New DataSet
        cmd = New SqlCommand("select a.CDS_Number AS [ClientNo],a.Surname+' '+a.Forenames as [Names], Commodity as [Commodity],Grade, ReceiptNo, InsurancePolicy, Quantity, 'KG' AS UnitMeasure, Convert(date, date_issued) as [Issue Date], Convert(date, expiry) as [Expiry]  from WR w, Accounts_Clients a WHERE A.cds_number=w.holder  and Convert(date, date_issued)>='" + opendate + "' and Convert(date, date_issued)<='" + closedate + "'", cn)
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
        ' ''Catch ex As Exception
        ' ''    msgbox(ex.Message)
        ' ''End Try
    End Sub
    Public Sub GetAllexpired(opendate As String, closedate As String)
        Dim ds As New DataSet
        cmd = New SqlCommand("select a.CDS_Number AS [ClientNo],a.Surname+' '+a.Forenames as [Names],Commodity as [Commodity],Grade, ReceiptNo, InsurancePolicy, Quantity, 'KG' AS UnitMeasure, Convert(date, date_issued) as [Issue Date], Convert(date, expiry) as [Expiry]  from WR w, Accounts_Clients a WHERE A.cds_number=w.holder and expiry<convert(date,getdate())  and Convert(date, date_issued)>='" + opendate + "' and Convert(date, date_issued)<='" + closedate + "'", cn)
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
        ' ''Catch ex As Exception
        ' ''    msgbox(ex.Message)
        ' ''End Try
    End Sub
    Public Sub GetAllApproved(opendate As String, closedate As String)
        Dim ds As New DataSet
        cmd = New SqlCommand("select a.CDS_Number AS [ClientNo],a.Surname+' '+a.Forenames as [Names], Commodity as [Commodity],Grade, ReceiptNo, InsurancePolicy, Quantity, 'KG' AS UnitMeasure, Convert(date, date_issued) as [Issue Date], Convert(date, expiry) as [Expiry]  from WR w, Accounts_Clients a WHERE A.cds_number=w.holder and approvedby is not NULL and Convert(date, date_issued)>='" + opendate + "' and Convert(date, date_issued)<='" + closedate + "'", cn)
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
        ' ''Catch ex As Exception
        ' ''    msgbox(ex.Message)
        ' ''End Try
    End Sub
    Public Sub GetAllstatuss(opendate As String, closedate As String, statuss As String)
        Dim ds As New DataSet
        cmd = New SqlCommand("select a.CDS_Number AS [ClientNo],a.Surname+' '+a.Forenames as [Names], Commodity as [Commodity],Grade, ReceiptNo, InsurancePolicy, Quantity, 'KG' AS UnitMeasure, Convert(date, date_issued) as [Issue Date], Convert(date, expiry) as [Expiry]  from WR w, Accounts_Clients a WHERE A.cds_number=w.holder and approvedby is not NULL and Convert(date, date_issued)>='" + opendate + "' and Convert(date, date_issued)<='" + closedate + "' and [status]='" + statuss + "'", cn)
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
        ' ''Catch ex As Exception
        ' ''    msgbox(ex.Message)
        ' ''End Try
    End Sub
    Public Sub GetAllPENDING_dep(opendate As String, closedate As String)
        Dim ds As New DataSet
        If DropDownList2.SelectedItem.Text = "All" Then
            If DropDownList1.SelectedItem.Text = "All Charges" Then
                cmd = New SqlCommand("select ID AS [S No.],[Description], TransType as [TransactionType],  convert(date,datecreated) as [Date], Format(Amount, '#,0.00') as [Amount], CDS_Number as [Charged To] from cashtranscomb where  convert(date, datecreated)>='" + opendate + "' and convert(date, datecreated)<='" + closedate + "' and cds_number in (select cds_number from Accounts_clients)", cn)
            Else
                cmd = New SqlCommand("select ID AS [S No.],[Description], TransType as [TransactionType],  convert(date,datecreated) as [Date], Format(Amount, '#,0.00') as [Amount], CDS_Number as [Charged To] from cashtranscomb where Description='" + DropDownList1.Text + "' and convert(date, datecreated)>='" + opendate + "' and convert(date, datecreated)<='" + closedate + "' and cds_number in (select cds_number from Accounts_clients)", cn)
            End If
        Else
            If DropDownList1.SelectedItem.Text = "All Charges" Then
                cmd = New SqlCommand("select ID AS [S No.],[Description], TransType as [TransactionType],  convert(date,datecreated) as [Date], Format(Amount, '#,0.00') as [Amount], CDS_Number as [Charged To] from cashtranscomb where  convert(date, datecreated)>='" + opendate + "' and convert(date, datecreated)<='" + closedate + "' and cds_number='" + DropDownList2.SelectedValue.ToString + "'", cn)
            Else
                cmd = New SqlCommand("select ID AS [S No.],[Description], TransType as [TransactionType],  convert(date,datecreated) as [Date], Format(Amount, '#,0.00') as [Amount], CDS_Number as [Charged To] from cashtranscomb where Description='" + DropDownList1.Text + "' and convert(date, datecreated)>='" + opendate + "' and convert(date, datecreated)<='" + closedate + "' and cds_number='" + DropDownList2.SelectedValue.ToString + "'", cn)
            End If
        End If


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
        ' ''Catch ex As Exception
        ' ''    msgbox(ex.Message)
        ' ''End Try
    End Sub
    Public Sub GetAllPENDING_part(opendate As String, closedate As String)
        Dim ds As New DataSet
        If DropDownList2.SelectedItem.Text = "All" Then
            If DropDownList1.SelectedItem.Text = "All Charges" Then
                cmd = New SqlCommand("select ID AS [S No.],[Description], TransType as [TransactionType],  convert(date,datecreated) as [Date], Format(Amount, '#,0.00') as [Amount], CDS_Number as [Charged To] from cashtranscomb where  convert(date, datecreated)>='" + opendate + "' and convert(date, datecreated)<='" + closedate + "' and cds_number in (select company_code from client_companies)", cn)
            Else
                cmd = New SqlCommand("select ID AS [S No.],[Description], TransType as [TransactionType],  convert(date,datecreated) as [Date], Format(Amount, '#,0.00') as [Amount], CDS_Number as [Charged To] from cashtranscomb where Description='" + DropDownList1.Text + "' and convert(date, datecreated)>='" + opendate + "' and convert(date, datecreated)<='" + closedate + "' and cds_number in (select company_code from client_companies)", cn)
            End If
        Else
            If DropDownList1.SelectedItem.Text = "All Charges" Then
                cmd = New SqlCommand("select ID AS [S No.],[Description], TransType as [TransactionType],  convert(date,datecreated) as [Date], Format(Amount, '#,0.00') as [Amount], CDS_Number as [Charged To] from cashtranscomb where  convert(date, datecreated)>='" + opendate + "' and convert(date, datecreated)<='" + closedate + "' and cds_number='" + DropDownList2.SelectedValue.ToString + "'", cn)
            Else
                cmd = New SqlCommand("select ID AS [S No.],[Description], TransType as [TransactionType],  convert(date,datecreated) as [Date], Format(Amount, '#,0.00') as [Amount], CDS_Number as [Charged To] from cashtranscomb where Description='" + DropDownList1.Text + "' and convert(date, datecreated)>='" + opendate + "' and convert(date, datecreated)<='" + closedate + "' and cds_number='" + DropDownList2.SelectedValue.ToString + "'", cn)
            End If
        End If


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
        ' ''Catch ex As Exception
        ' ''    msgbox(ex.Message)
        ' ''End Try
    End Sub



    Public Sub getdepositors()
        Dim ds As New DataSet
        cmd = New SqlCommand("select cds_number, forenames+' '+surname as names from Accounts_clients", cn)
        adp = New SqlDataAdapter(cmd)
        cmd.CommandTimeout = 99999
        adp.Fill(ds, "para_lendingRules")
        If (ds.Tables(0).Rows.Count > 0) Then
            DropDownList2.DataSource = ds
            DropDownList2.DataTextField = "names"
            DropDownList2.DataValueField = "cds_number"
            DropDownList2.DataBind()

        End If
    End Sub
    Public Sub getparticipants()
        Dim ds As New DataSet
        cmd = New SqlCommand("select company_code, company_name from client_companies", cn)
        adp = New SqlDataAdapter(cmd)
        cmd.CommandTimeout = 99999
        adp.Fill(ds, "para_lendingRules")
        If (ds.Tables(0).Rows.Count > 0) Then
            DropDownList2.DataSource = ds
            DropDownList2.DataTextField = "company_name"
            DropDownList2.DataValueField = "company_code"
            DropDownList2.DataBind()

        End If
    End Sub






    Protected Sub ASPxButton1_Click(sender As Object, e As EventArgs) Handles ASPxButton1.Click
        If RadioButtonList1.SelectedItem.Text = "Depositor" Then
            GetAllPENDING_dep(dtfrom.Text, dtto.Text)
        Else
            GetAllPENDING_part(dtfrom.Text, dtto.Text)
        End If


    End Sub
    Protected Sub ASPxButton8_Click(sender As Object, e As EventArgs) Handles ASPxButton8.Click
        If RadioButtonList1.SelectedItem.Text = "Depositor" Then
            GetAllPENDING_dep(dtfrom.Text, dtto.Text)
            ASPxGridViewExporter1.WriteXlsToResponse()
        Else
            GetAllPENDING_part(dtfrom.Text, dtto.Text)
            ASPxGridViewExporter1.WriteXlsToResponse()
        End If

    End Sub
    Protected Sub RadioButtonList1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles RadioButtonList1.SelectedIndexChanged

        If RadioButtonList1.SelectedItem.Text = "Depositor" Then

            DropDownList2.Items.Clear()
            DropDownList2.Items.Add("All")
            getdepositors()
        Else
            DropDownList2.Items.Clear()
            DropDownList2.Items.Add("All")
            getparticipants()
        End If
    End Sub
End Class
