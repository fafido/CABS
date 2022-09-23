Imports System.Data
Imports System.Data.SqlClient

Partial Class Auditlog2
    Inherits System.Web.UI.Page
    Dim constr As String = (System.Configuration.ConfigurationManager.AppSettings("connpath"))
    Dim cn As New SqlConnection(constr)
    Dim cmd As SqlCommand
    Dim adp As SqlDataAdapter
    Public Sub getaudit()
        If Session("Companytype") = "BROKER" Or Session("Companytype") = "CUSTODIAN" Then
            'Dim ds As New DataSet
            'cmd = New SqlCommand("  select userid, [date], name, Activity, [time], ip, machine, left(browser,11), broker_id from audit_log where [date] between '" + txtDateFrom.Text + "' and '" + txtDateTo.Text + "' AND broker_id='" + Session("BrokerCode") + "' order by date desc", cn)
            'adp = New SqlDataAdapter(cmd)
            'adp.Fill(ds, "audit")

            'If ds.Tables("audit").Rows.Count > 0 Then
            '    ASPxGridView1.DataSource = ds
            '    ASPxGridView1.DataBind()
            'Else
            '    msgbox("No information")
            'End If
        Else
            Dim ds As New DataSet
            cmd = New SqlCommand("select userid as [User ID], [date] AS [Date], name as [Username], Activity,  ip as [IP Address], Machine, left(browser,11) as [Browser], broker_id as [Participant], request_id as [Affected Account],AffectedTrans as [Reference]  from audit_log where convert(date,[date]) >= '" + txtDateFrom.Text + "' and convert(date,[date]) <= '" + txtDateTo.Text + "'  order by date desc", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "audit")

            If ds.Tables("audit").Rows.Count > 0 Then
                ASPxGridView1.DataSource = ds
                ASPxGridView1.DataBind()
            Else
                msgbox("No information")
            End If
        End If

    End Sub
 


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack = True Then
            If txtDateFrom.Text <> "" And txtDateTo.Text <> "" Then
                getaudit()
            End If
        Else
            If txtDateFrom.Text <> "" And txtDateTo.Text <> "" Then
                getaudit()
            End If
        End If


    End Sub
    Public Sub msgbox(ByVal strMessage As String)

        'finishes server processing, returns to client.
        Dim strScript As String = "<script language=JavaScript>"
        strScript += "window.alert(""" & strMessage & """);"
        strScript += "</script>"
        Dim lbl As New System.Web.UI.WebControls.Label
        lbl.Text = strScript
        Page.Controls.Add(lbl)

    End Sub

    Protected Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        If txtDateFrom.Text <> "" And txtDateTo.Text <> "" Then
            getaudit()

        Else
            msgbox("Please select Date from and Date to!")
        End If
        


    End Sub
End Class
