
Imports System.Data
Imports System.Data.SqlClient

Partial Class Parameters_frmBank
    Inherits System.Web.UI.Page
    Dim constr As String = (System.Configuration.ConfigurationManager.AppSettings("connpath"))
    Dim cn As New SqlConnection(constr)
    Dim cmd As SqlCommand
    Dim adp As SqlDataAdapter
    Public Sub msgbox(ByVal strMessage As String)

        'finishes server processing, returns to client.
        Dim strScript As String = "<script language=JavaScript>"
        strScript += "window.alert(""" & strMessage & """);"
        strScript += "</script>"
        Dim lbl As New System.Web.UI.WebControls.Label
        lbl.Text = strScript
        Page.Controls.Add(lbl)

    End Sub


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Try
            Page.MaintainScrollPositionOnPostBack = True
            If (Not IsPostBack) Then
                GridView1.Attributes.Add("bordercolor", "#B7D8DC")
                GetBanks()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub


    Public Sub GetBanks()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("Select ID,Bank,Bank_name as [Full Name],Bank_code AS [Code] from para_bank", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "para_bank")
            GridView1.DataSource = ds.Tables("para_bank")
            GridView1.DataBind()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Protected Sub btnSave_click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        'Try
        If txtCode.Text = "" Then
                MsgBox("Enter Bank Code")
                txtCode.Focus()
                Exit Sub
            End If
            If txtshortname.Text = "" Then
                msgbox("Enter Bank Name")
                txtshortname.Focus()
                Exit Sub
            End If
        If txtName.Text = "" Then
            msgbox("Enter Bank Name")
            txtName.Focus()
            Exit Sub
        End If

        If btnSave.Text = "Add" Then
            cmd = New SqlCommand("insert into para_Bank (Bank,Bank_name,Bank_code) values('" & txtshortname.Text & "','" & txtName.Text & "','" & txtCode.Text & "')", cn)
            If (cn.State = ConnectionState.Open) Then
                cn.Close()
            End If
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()
            GetBanks()
            txtCode.Text = ""
            txtName.Text = ""
            txtshortname.Text = ""

        Else

            cmd = New SqlCommand("Update para_Bank set Bank='" & txtshortname.Text & "',Bank_name='" & txtName.Text & "',Bank_code='" & txtCode.Text & "'  where ID =" & GridView1.SelectedRow.Cells(1).Text & "", cn)
            If (cn.State = ConnectionState.Open) Then
                cn.Close()
            End If
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()
            GetBanks()
            txtCode.Text = ""
            txtName.Text = ""
            txtshortname.Text = ""

        End If

        'Catch ex As Exception
        '   msgbox(ex.Message)
        'End Try
    End Sub
    Protected Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Try


            Dim cmd1 = New SqlCommand("delete  para_Bank  where ID = '" & GridView1.SelectedRow.Cells(1).Text & "'", cn)
            If (cn.State = ConnectionState.Open) Then
                cn.Close()
            End If
            cn.Open()
            cmd1.ExecuteNonQuery()
            cn.Close()
            GetBanks()

            msgbox("Bank  Deleted")
        Catch ex As Exception
            msgbox("Please select Bank to delete")
        End Try
    End Sub
    Protected Sub GridView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GridView1.SelectedIndexChanged
        btnSave.Text = "Update Bank"
        btnDelete.Visible = True
        btnClear.Visible = True
        txtCode.Text = GridView1.SelectedRow.Cells(4).Text
        txtshortname.Text = GridView1.SelectedRow.Cells(2).Text
        txtName.Text = GridView1.SelectedRow.Cells(3).Text
    End Sub
    Protected Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        btnSave.Text = "Add"
        txtCode.Text = ""
        txtshortname.Text = ""
        txtName.Text = ""
        btnDelete.Visible = False
        btnClear.Visible = False
    End Sub
End Class
