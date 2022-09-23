Partial Class Tsec
    Inherits System.Web.UI.MasterPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Not IsPostBack Then
                If ((Session("UserName").ToString) <> "") Then
                    Label1.Text = "Registrar Access level, " & Session("BrokerCode").ToString & " ," & Session("UserCompany").ToString & " :" & Session("Username").ToString
                    TreeView1.Enabled = True
                    TreeView1.CollapseAll()
                Else
                    Response.Redirect("~\loginsystem.aspx")
                    Label1.Text = "Please log in with valid credidentials"
                    TreeView1.Enabled = False
                    TreeView1.CollapseAll()

                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Class

