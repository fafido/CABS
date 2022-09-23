Imports System.Data
Imports System.Data.SqlClient
Partial Class Trading_OrdersAudit
    Inherits System.Web.UI.Page
    Dim constr As String = (System.Configuration.ConfigurationManager.AppSettings("connpath"))
    Dim cn As New SqlConnection(constr)
    Dim cmd As SqlCommand
    Dim adp As SqlDataAdapter
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Page.MaintainScrollPositionOnPostBack = True
        If (Not IsPostBack) Then

        End If
    End Sub
    Public Sub getHolder()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("Select Surname,Fornames,CDS_Number from names where CDS_Number= '" & txtHolder.Text & "' and Locked=0", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "names")
            If (ds.Tables(0).Rows.Count > 0) Then
                If (ds.Tables(0).Rows(0).Item("Locked").ToString = 1) Then
                    MsgBox("Holder's Account is blocked, Please Contact the HOD for assistance on this account")
                    Exit Sub
                End If
                txtHolder.Text = ds.Tables(0).Rows(0).Item("CDS_Number").ToString

            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Protected Sub btnSelect_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSelect.Click

    End Sub
End Class
