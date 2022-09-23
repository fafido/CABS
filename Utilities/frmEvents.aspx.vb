Imports System.Data
Imports System.Data.SqlClient
Partial Class Utilities_frmEvents
    Inherits System.Web.UI.Page
    Dim constr As String = (System.Configuration.ConfigurationManager.AppSettings("connpath"))
    Dim cn As New SqlConnection(constr)
    Dim cmd As SqlCommand
    Dim adp As SqlDataAdapter

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Page.MaintainScrollPositionOnPostBack = True
            If (Not IsPostBack) Then
                getCompany()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Public Sub getCompany()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("Select company from para_company", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "para_company")
            cmbCompany.DataSource = ds.Tables(0)
            cmbCompany.DataValueField = "company"
            cmbCompany.DataBind()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Try
            cmd = New SqlCommand("insert into tbl_EventsDiary (Company,Caption,EventDate,Details) values('" & cmbCompany.Text & "','" & txtCaption.Text & "','" & BasicDatePicker1.Text & "','" & txtDetails.Text & "')", cn)
            If (cn.State = ConnectionState.Open) Then
                cn.Close()
            End If
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()
            MsgBox("Event Saved")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Class
