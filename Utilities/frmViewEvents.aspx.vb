Imports System.Data
Imports System.Data.SqlClient
Partial Class frmViewEvents
    Inherits System.Web.UI.Page
    Dim constr As String = (System.Configuration.ConfigurationManager.AppSettings("connpath"))
    Dim cn As New SqlConnection(constr)
    Dim cmd As SqlCommand
    Dim adp As SqlDataAdapter

    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        GetEvents()
    End Sub


    Public Sub GetEvents()
        Try
            Dim ds As New DataSet
            If RadioButtonList1.SelectedIndex = 0 Then
                cmd = New SqlCommand("Select * from tbl_EventsDiary", cn)
            ElseIf RadioButtonList1.SelectedIndex = 1 Then
                cmd = New SqlCommand("Select * from tbl_EventsDiary where EventDate < getdate() order by eventdate", cn)
            Else
                cmd = New SqlCommand("Select * from tbl_EventsDiary  where EventDate >= getdate() order by eventdate", cn)

            End If

            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "tbl_EventsDiary")
            GridView1.DataSource = ds.Tables("tbl_EventsDiary")
            GridView1.DataBind()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

End Class
