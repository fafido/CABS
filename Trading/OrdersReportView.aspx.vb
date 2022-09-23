Partial Class Trading_OrdersReportView
    Inherits System.Web.UI.Page
    Dim constr As String = (System.Configuration.ConfigurationManager.AppSettings("connpath"))
    Dim cn As New SqlConnection(constr)
    Dim cmd As SqlCommand
    Dim adp As SqlDataAdapter
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Page.MaintainScrollPositionOnPostBack = True
            If (Not IsPostBack) Then
                GetCompany()
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
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
    Public Sub GetCompany()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select distinct (company) from ordersSummary where ApprovalFlag in (0,1)", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "ordersSummary")
            If (ds.Tables(0).Rows.Count > 0) Then
                cmbCountry.DataSource = ds.Tables(0)
                cmbCountry.DataValueField = "company"
                cmbCountry.DataBind()
            Else
                cmbCountry.Items.Clear()
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub btnSelect_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSelect.Click
        Try
            If (rdCleared.Checked = False And rdUnCleared.Checked = False) Then
                msgbox("Please select a valid print option")
                Exit Sub
            End If
            Dim ClassType As Integer = 0
            If (rdCleared.Checked = True) Then
                ClassType = 1
            End If
            If (rdUnCleared.Checked = True) Then
                ClassType = 0
            End If
            If (cmbCountry.SelectedItem.Text <> "" And BasicDatePicker2.Text <> "") Then
                Dim strscript As String
                strscript = "<script langauage=JavaScript>"
                strscript += "window.open('PostedOrdersReportView.aspx?Classfication=" & ClassType & "&company=" & cmbCountry.SelectedItem.Text & "&RepDate=" & BasicDatePicker2.SelectedDate.ToString & "');"
                strscript += "</script>"
                ClientScript.RegisterStartupScript(Me.GetType(), "newwin", strscript)

            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
End Class
