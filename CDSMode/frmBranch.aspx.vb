Imports System.Data
Imports System.Data.SqlClient

Partial Class CDSMode_frmBranch
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
                GetBanks()
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try

    End Sub


    Public Sub GetBanks()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("Select Bank,Bank_name,Bank_code from para_bank", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "para_bank")

            cmbBank.DataSource = ds.Tables("para_bank")
            cmbBank.DataValueField = "Bank_Name"
            cmbBank.DataMember = "Bank_Name"
            cmbBank.DataBind()
            'GridView1.DataSource = ds.Tables("para_bank")
            'GridView1.DataBind()
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Public Sub GetBanks2()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("Select Bank,Bank_name,Bank_code from para_bank where bank_name = '" & cmbBank.Text & "'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "para_bank")

            cmbBank.DataSource = ds.Tables("para_bank")
            GridView1.DataSource = ds.Tables("para_bank")
            GridView1.DataBind()
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub btnSave_click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Try
            If txtCode.Text = "" Then
                msgbox("Enter Branch Code")
                txtCode.Focus()
                Exit Sub
            End If
            If txtFname.Text = "" Then
                msgbox("Enter Branch Name")
                txtFname.Focus()
                Exit Sub
            End If
            If txtBankCode.Text = "" Then
                msgbox("Enter Bank Code")
                txtBankCode.Focus()
                Exit Sub
            End If
            If txtName.Text = "" Then
                msgbox("Enter Branch Name")
                txtName.Focus()
                Exit Sub
            End If
            cmd = New SqlCommand("insert into para_Branch (Bank,Branch,Branch_name,Branch_Code) values('" & txtBankCode.Text & "','" & txtFname.Text & "','" & txtName.Text & "','" & txtCode.Text & "')", cn)
            If (cn.State = ConnectionState.Open) Then
                cn.Close()
            End If
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()
            GetBanks()
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub cmbBank_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbBank.SelectedIndexChanged

        Dim ds As New DataSet
        cmd = New SqlCommand("Select Bank_code from para_bank where bank_name = '" & cmbBank.Text & "'", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "para_bank")
        txtBankCode.Text = ds.Tables("para_bank").Rows(0).Item(1)
        GetBanks2()

    End Sub
End Class
