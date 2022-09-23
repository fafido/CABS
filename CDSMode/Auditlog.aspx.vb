Imports System.Data
Imports System.Data.SqlClient
Partial Class Auditlog
    Inherits System.Web.UI.Page
    Dim constr As String = (System.Configuration.ConfigurationManager.AppSettings("connpath"))
    Dim cn As New SqlConnection(constr)
    Dim cmd As SqlCommand
    Dim adp As SqlDataAdapter
    Public Sub getaudit()
        Dim ds As New DataSet
        cmd = New SqlCommand("select Shareholder as [Holder No], Surname+' '+Forenames as [Names], Updated_by as [Updated By], Update_On as [Date Updated] from Pre_Names_Creation ", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "audit")

        If ds.Tables("audit").Rows.Count > 0 Then
            GridView1.DataSource = ds
            GridView1.DataBind()
        Else
            MsgBox("No information")
        End If
    End Sub


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        getaudit()

    End Sub
End Class
