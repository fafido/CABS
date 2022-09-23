Imports System.Data.SqlClient
Imports System.Threading
Imports System.Data
Partial Class BrokerUser
    Inherits System.Web.UI.MasterPage
    Dim constr As String = (System.Configuration.ConfigurationManager.AppSettings("connpath"))
    Dim cn As New SqlConnection(constr)
    Dim cmd As SqlCommand
    Dim ds As New DataSet
    Dim adp As SqlDataAdapter
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If ((Session("UserName").ToString) <> "") Then
                Label1.Text = "Broker Access level, " & Session("BrokerCode").ToString & " ," & Session("UserCompany").ToString & " :" & Session("Username").ToString
                TreeView1.Enabled = True
                TreeView1.CollapseAll()
                Dim worker As New HouseKeepingTasks()
                'AddHandler worker.GetMaturedRec, AddressOf worker_DoWork
            Else
                Response.Redirect("~\loginsystem.aspx")
                Label1.Text = "Please log in with valid credidentials"
                TreeView1.Enabled = False
                TreeView1.CollapseAll()

            End If

        Catch ex As Exception
            Label1.Text = "Please log in with valid credidentials"
            Response.Redirect("~\loginsystem.aspx")
            TreeView1.Enabled = False
            'MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub worker_DoWork(ByRef progress As Integer, ByRef result As Object, ByVal ParamArray arguments As Object())
        ' Get the value which passed to this operation.
        Dim input As String = String.Empty
        If arguments.Length > 0 Then
            input = arguments(0).ToString()
        End If

        ' Need 10 seconds to complete this operation.
        For i As Integer = 0 To 99
            Thread.Sleep(100)

            progress += 1
        Next

        ' The operation is completed.
        progress = 100
        result = "Operation is completed. The input is """ & input & """."
    End Sub

    Protected Sub TreeView1_SelectedNodeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TreeView1.SelectedNodeChanged
        Try
            TreeView1.Nodes(3).Collapse()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Class

