Partial Class CDSMode_TradesEnquiries
    Inherits System.Web.UI.Page
    Dim constr As String = (System.Configuration.ConfigurationManager.AppSettings("connpath"))
    Dim cn As New SqlConnection(constr)
    Dim cmd As SqlCommand
    Dim adp As SqlDataAdapter
    Protected Sub btnHolderNumSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnHolderNumSearch.Click
        Try
            If (txtshareholder.Text = "") Then
                msgbox("Enter a valid Shareholder Number")
                Exit Sub
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub getcompany()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select distinct (company) from para_company", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "para_company")

            If (ds.Tables(0).Rows.Count > 0) Then
                cmbCompany.DataSource = ds.Tables(0)
                cmbCompany.DataValueField = "company"
                cmbCompany.DataBind()
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

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If (Not IsPostBack) Then
                getcompany()
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub Hidecontrols()
        Try
            Label6.Visible = False
            BasicDatePicker1.Visible = False
            Label7.Visible = False
            BasicDatePicker2.Visible = False
            Label8.Visible = False
            cmdTransType.Visible = False
            Label2.Visible = False
            cmbCompany.Visible = False
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Protected Sub rdDate_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdDate.CheckedChanged
        Try
            If (rdDate.Checked = True) Then
                Hidecontrols()
                Label6.Visible = True
                BasicDatePicker1.Visible = True
                Label7.Visible = True
                BasicDatePicker2.Visible = True
            End If
            

        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub rdDate0_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdDate0.CheckedChanged
        Try
            If (rdDate0.Checked = True) Then
                Hidecontrols()
                Label8.Visible = True
                cmdTransType.Visible = True
            End If
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub rdDate1_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdDate1.CheckedChanged
        Try
            If (rdDate1.Checked = True) Then
                Hidecontrols()
                Label2.Visible = True
                cmbCompany.Visible = True
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
End Class
