Partial Class TSecReports_CompanySchedule
    Inherits System.Web.UI.Page
    Dim cnstr As String = System.Configuration.ConfigurationManager.AppSettings("connpath")
    Dim cmd As SqlCommand
    Dim cn As New SqlConnection(cnstr)
    Dim adp As SqlDataAdapter
    Dim Str As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Page.MaintainScrollPositionOnPostBack = True
        dr_company.Focus()
        Calendar1.Visible = False
        If Not IsPostBack Then
            company()
        End If

    End Sub
    Protected Sub btn_Print_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_Print.Click
        If (dtpDateCreated.Text <> "" And dr_company.Text <> "") Then
            Dim strscript As String
            Dim dss4 As New DataSet
            Dim dss5 As New DataSet
            cmd = New SqlCommand("select sum(shares) as shares from mast where company='" & dr_company.Text & "' and shareholder=(select cds_ac_no from para_company where  company='" & dr_company.Text & "')", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(dss4, "mast")

            cmd = New SqlCommand("select sum(shares) as shares from mast where company='" & dr_company.Text & "' and cert=999999999", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(dss5, "mast")

            Dim PendingCDSUpload = CInt((dss4.Tables(0).Rows(0).Item("shares").ToString - dss5.Tables(0).Rows(0).Item("shares").ToString))

            strscript = "<script langauage=JavaScript>"
            strscript += "window.open('companyschedulereport.aspx?company=" & dr_company.SelectedItem.Text & "&date=" & dtpDateCreated.Text & "&PendingUpload=" & PendingCDSUpload & "');"
            strscript += "</script>"
            ClientScript.RegisterStartupScript(Me.GetType(), "newwin", strscript)
        Else
            msgbox("Please Enter Requiered Values")
            Exit Sub
        End If
    End Sub
    Public Sub company()
        Try
            cn = New SqlConnection(cnstr)
            Dim str As String = "select distinct company from para_company"
            cmd = New SqlCommand(str, cn)
            adp = New SqlDataAdapter
            adp.SelectCommand = cmd
            Dim ds As New DataSet
            adp.Fill(ds, "para_company")
            dr_company.DataSource = ds
            dr_company.DataTextField = "company"
            dr_company.DataBind()
        Catch ex As Exception
            msgbox(ex.Message)
        End Try

    End Sub


    Protected Sub Button3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button3.Click
        Calendar1.Visible = True
    End Sub

    Protected Sub Calendar1_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Calendar1.SelectionChanged
        Calendar1.Visible = False
        dtpDateCreated.Text = Calendar1.SelectedDate
        Calendar1.SelectedDate = Nothing
    End Sub

    Protected Sub Calendar1_VisibleMonthChanged(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.MonthChangedEventArgs) Handles Calendar1.VisibleMonthChanged
        Calendar1.Visible = True
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

End Class
