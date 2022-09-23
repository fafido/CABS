Partial Class TransferSec_UserPermissions
    Inherits System.Web.UI.Page
    Dim constr As String = (System.Configuration.ConfigurationManager.AppSettings("connpath"))
    Dim cn As New SqlConnection(constr)
    Dim adp As SqlDataAdapter
    Dim cmd As SqlCommand
    Public Sub msgbox(ByVal strMessage As String)

        'finishes server processing, returns to client.
        Dim strScript As String = "<script language=JavaScript>"
        strScript += "window.alert(""" & strMessage & """);"
        strScript += "</script>"
        Dim lbl As New System.Web.UI.WebControls.Label
        lbl.Text = strScript
        Page.Controls.Add(lbl)

    End Sub
    Public Sub GetUsers()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select Username+' '+forenames+' '+surname as namee from SystemUsers where companyCode ='" & Session("BrokerCode").ToString & "'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "systemUsers")
            If (ds.Tables(0).Rows.Count > 0) Then
                With ds.Tables(0).Rows
                    lstUsersList.DataSource = ds.Tables(0)
                    lstUsersList.TextField = "namee"
                    lstUsersList.ValueField = "namee"
                    lstUsersList.DataBind()
                End With
            Else
                lstSystemPermissions.Items.Clear()
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub checkSessionState()
        Try

        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Page.MaintainScrollPositionOnPostBack = True
            If (Not IsPostBack) Then
                checkSessionState()
                GetUsers()
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try

    End Sub
    Public Sub GetSelectedAccount()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select * from systemusers where username+' '+forenames+ ' '+surname='" & lstUsersList.SelectedItem.Text & "'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "systemsUsers")
            If (ds.Tables(0).Rows.Count > 0) Then
                With ds.Tables(0).Rows(0)
                    txtUsername.Text = .Item("username").ToString
                    txtForenames.Text = .Item("forenames").ToString
                    txtSurname.Text = .Item("surname").ToString
                    txtIDNo.Text = .Item("idnopp").ToString
                    If (.Item("gender").ToString = "F") Then
                        rdMale.Checked = False
                        rdFemale.Checked = True
                        rdNa.Checked = False
                    End If
                    If (.Item("gender").ToString = "M") Then
                        rdMale.Checked = True
                        rdFemale.Checked = False
                        rdNa.Checked = False
                    End If
                    If (.Item("gender").ToString <> "F" And .Item("gender").ToString <> "M") Then
                        rdMale.Checked = False
                        rdFemale.Checked = False
                        rdNa.Checked = True
                    End If
                    txtRole.Text = .Item("role").ToString
                    txtDepartment.Text = .Item("department").ToString
                End With
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub lstUsersList_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstUsersList.SelectedIndexChanged
        GetSelectedAccount()
    End Sub
End Class
