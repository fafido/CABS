Partial Class Reporting_CompanySchedule
    Inherits System.Web.UI.Page
    Dim constr As String = (System.Configuration.ConfigurationManager.AppSettings("connpath"))
    Dim cn As New SqlConnection(constr)
    Dim cmd As SqlCommand
    Dim adp As SqlDataAdapter
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Page.MaintainScrollPositionOnPostBack = True
        If (Not IsPostBack) Then
            txtTargetDate.MaximumDate = Date.UtcNow
            RadioButtonList1.SelectedIndex = 0

            If RadioButtonList1.SelectedItem.Text = "Series" Then
                loadcomp("Series")
            Else
                loadcomp("Unit Trust")
            End If

        End If

    End Sub
    Public Sub loadcomp(type As String)
        cmbCompany.Items.Clear()

        Dim ds As New DataSet
        If type = "Series" Then
            cmd = New SqlCommand("Select company from Comps where Category='Bond'", cn)
        Else
            cmd = New SqlCommand("Select company from Comps where Category='Unit Trust'", cn)
        End If

        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "para_company")
        If (ds.Tables(0).Rows.Count > 0) Then
            cmbCompany.DataSource = ds.Tables(0)
            cmbCompany.DataTextField = "company"
            cmbCompany.DataValueField = "company"
            cmbCompany.DataBind()
        Else

            'msgbox("new")
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
    Public Sub getcompany()
 
            Dim ds As New DataSet
            cmd = New SqlCommand("Select company, fnam from testcds_router.dbo.para_company", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "para_company")
            If (ds.Tables(0).Rows.Count > 0) Then
                cmbCompany.DataSource = ds.Tables(0)
				 cmbCompany.DataTextField = "fnam"
                cmbCompany.DataValueField = "company"
                cmbCompany.DataBind()
                Else

                msgbox("new")
            End If
      
    End Sub
    Protected Sub cmbCompany_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbCompany.SelectedIndexChanged
        Try

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Protected Sub btnSelect_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSelect.Click
        Try
            Dim ClassType As String = ""
            If (rdAll.Checked = True) Then
                ClassType = "5"
            End If
            If (cmbCompany.Text <> "" And ClassType <> "") Then
                Session("coo") = cmbCompany.Text
                If CheckBox1.Checked = True Then
                    Dim strscript As String
                    strscript = "<script langauage=JavaScript>"
                    'strscript += "window.open('HolderClassificationIndividual.aspx?company=" & cmbCompany.Text & "&Classfication=" & ClassType & "');"
                    strscript += "window.open('HolderClassificationIndividual.aspx?Classfication=" & ClassType & "&company=" & cmbCompany.SelectedItem.Value.tostring & "&RepDate=" & txtTargetDate.Text & "&locked=True');"
                    strscript += "</script>"
                    ClientScript.RegisterStartupScript(Me.GetType(), "newwin", strscript)

                Else
                    Dim strscript As String
                    strscript = "<script langauage=JavaScript>"
                    'strscript += "window.open('HolderClassificationIndividual.aspx?company=" & cmbCompany.Text & "&Classfication=" & ClassType & "');"
                    strscript += "window.open('HolderClassificationIndividual.aspx?Classfication=" & ClassType & "&company=" & cmbCompany.SelectedItem.Value.ToString & "&RepDate=" & txtTargetDate.Text & "&xlocked=False&newtype=" + RadioButtonList1.SelectedItem.Text + "');"
                    strscript += "</script>"
                    ClientScript.RegisterStartupScript(Me.GetType(), "newwin", strscript)
                End If
              

            Else
                MsgBox("Please Enter Requiered Values")
                Exit Sub
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Protected Sub RadioButtonList1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles RadioButtonList1.SelectedIndexChanged
        If RadioButtonList1.SelectedItem.Text = "Series" Then
            loadcomp("Series")
        Else
            loadcomp("Unit Trust")
        End If
    End Sub
End Class
