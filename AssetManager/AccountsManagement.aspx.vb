Partial Class Reporting_AccountsManagement
    Inherits System.Web.UI.Page
    Dim constr As String = (System.Configuration.ConfigurationManager.AppSettings("connpath"))
    Dim cn As New SqlConnection(constr)
    Dim cmd As SqlCommand
    Dim adp As SqlDataAdapter
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Page.MaintainScrollPositionOnPostBack = True
            If (Not IsPostBack) Then
                If (Session("Username") = Nothing) Then
                    Response.Redirect("~\loginsystem.aspx")
                    Exit Sub
                End If
                getcompany()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Public Sub getcompany()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("Select distinct (company) from para_company", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "para_company")
            If (ds.Tables(0).Rows.Count > 0) Then
                cmbCompany.DataSource = ds.Tables(0)
                cmbCompany.DataValueField = "company"
                cmbCompany.DataBind()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
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
            If rdCompany.Checked = True Then
                ClassType = "4"
            End If
            If rdNominee.Checked = True Then
                ClassType = "3"
            End If
            If rdJoint.Checked = True Then
                ClassType = "2"
            End If
            If RdInd.Checked = True Then
                ClassType = "1"
            End If
            If (ClassType <> "") Then
                If (ClassType = 1) Then
                    Dim strscript As String
                    strscript = "<script langauage=JavaScript>"
                    'strscript += "window.open('HolderClassificationIndividual.aspx?company=" & cmbCompany.Text & "&Classfication=" & ClassType & "');"
                    strscript += "window.open('Accountmaintenanceall.aspx?Classfication=" & ClassType & "&Datefrom=" & BasicDatePicker1.Text & "&dateto=" & BasicDatePicker2.Text & "&Sort1=" & cmb1.Text & "&Sort2=" & cmb2.Text & "');"
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
End Class
