Imports DevExpress.Web.ASPxGridView

Partial Class Parameters_AssetManagerBanks
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
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Page.MaintainScrollPositionOnPostBack = True
            If (Not IsPostBack) Then
                getassetmanagers()
                getbanks()
                getcurrencies()

                getSecurities_Categories()
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Protected Sub clearall()

        txtFname.Text = ""

        getSecurities_Categories()
    End Sub
    Protected Sub ASPxButton7_Click(sender As Object, e As EventArgs) Handles ASPxButton7.Click
        If ASPxButton7.Text = "Save" Then
            If txtaccountname.Text = "" Then
                msgbox("Please enter Account Name!")
                Exit Sub
            End If
            If cmbassetmanager.SelectedItem.Text <> "" Then

                cmd = New SqlCommand("insert into para_AssetManager_Banks  (AssetManagerCode,AccountNo, Bank, Branch, AccountName,Currency) values ('" & cmbassetmanager.SelectedValue.ToString & "','" & txtFname.Text & "','" + cmbbank.SelectedValue.ToString + "','" + cmbbranch.SelectedValue.ToString + "','" + txtaccountname.Text + "', '" + cmbcurrency.SelectedValue.ToString + "')", cn)
                If cn.State = ConnectionState.Open Then
                    cn.Close()
                End If
                cn.Open()
                Dim y As Integer = cmd.ExecuteNonQuery()
                cn.Close()
                getSecurities_Categories()
                clearall()
            Else
                msgbox("Enter All Details")
                Exit Sub
            End If
        Else
            If txtaccountname.Text = "" Then
                msgbox("Please enter Account Name!")
                Exit Sub
            End If
            If txtFname.Text <> "" Then
                cmd = New SqlCommand("update para_AssetManager_Banks set  AssetManagerCode='" & cmbassetmanager.SelectedValue.ToString & "',AccountNo='" & txtFname.Text & "', Bank='" + cmbbank.SelectedValue.ToString + "',Branch='" + cmbbranch.SelectedValue.ToString + "', AccountName='" + txtaccountname.Text + "', Currency='" + cmbcurrency.SelectedValue.ToString + "' where ID='" + Label2.Text + "'", cn)
                If cn.State = ConnectionState.Open Then
                    cn.Close()
                End If
                cn.Open()
                Dim y As Integer = cmd.ExecuteNonQuery()
                cn.Close()
                ASPxButton7.Text = "Save"
                clearall()
                getSecurities_Categories()
                msgbox("Update Successfully!")
            Else
                msgbox("Enter All Details")
                Exit Sub
            End If
        End If
    End Sub
    Public Sub getassetmanagers()
        cmd = New SqlCommand("select * from para_AssetManager ", cn)
        Dim ds As New DataSet
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "para_Country")
        If ds.Tables(0).Rows.Count > 0 Then
            cmbassetmanager.DataSource = ds
            cmbassetmanager.DataTextField = "AssetMananger"
            cmbassetmanager.DataValueField = "AssetManagerCode"
            cmbassetmanager.DataBind()
        End If
    End Sub
    Public Sub getbanks()
        cmd = New SqlCommand("select * from para_bank ", cn)
        Dim ds As New DataSet
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "para_Country")
        If ds.Tables(0).Rows.Count > 0 Then
            cmbbank.DataSource = ds
            cmbbank.DataTextField = "bank_name"
            cmbbank.DataValueField = "bank"
            cmbbank.DataBind()
        End If
    End Sub
    Public Sub getcurrencies()
        cmd = New SqlCommand("select * from para_currencies", cn)
        Dim ds As New DataSet
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "para_Country")
        If ds.Tables(0).Rows.Count > 0 Then
            cmbcurrency.DataSource = ds
            cmbcurrency.DataTextField = "CurrencyCode"
            cmbcurrency.DataValueField = "CurrencyCode"
            cmbcurrency.DataBind()
        End If
    End Sub
    Protected Sub getSecurities_Categories()
        Try
            cmd = New SqlCommand("select * from para_AssetManager_Banks WHERE assetmanagercode='" + cmbassetmanager.SelectedValue.ToString + "'", cn)
            Dim ds As New DataSet
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "para_Country")
            If ds.Tables(0).Rows.Count > 0 Then
                ASPxGridView2.DataSource = ds.Tables(0)
            Else
                ASPxGridView2.DataSource = Nothing
            End If
            ASPxGridView2.DataBind()
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub getinfortoedit(id As String)
        cmd = New SqlCommand("select * from para_AssetManager_Banks where id='" + id.ToString + "'", cn)
        Dim ds As New DataSet
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "info")
        If ds.Tables(0).Rows.Count > 0 Then
            ' txtCode.Text = ds.Tables(0).Rows(0).Item("AssetManagerCode").ToString
            cmbassetmanager.SelectedValue = ds.Tables(0).Rows(0).Item("AssetManagerCode").ToString
            cmbbank.SelectedValue = ds.Tables(0).Rows(0).Item("Bank").ToString
            getbranches()

            cmbbranch.SelectedValue = ds.Tables(0).Rows(0).Item("Branch").ToString
            txtaccountname.Text = ds.Tables(0).Rows(0).Item("AccountName").ToString
            txtFname.Text = ds.Tables(0).Rows(0).Item("AccountNo").ToString

            Label2.Text = id
            ASPxButton7.Text = "Update"
        End If
    End Sub
    Private Sub ASPxGridView2_RowCommand(sender As Object, e As ASPxGridViewRowCommandEventArgs) Handles ASPxGridView2.RowCommand
        Dim idd As String = e.CommandArgs.CommandArgument.ToString
        If e.CommandArgs.CommandName.ToString = "Edit" Then
            getinfortoedit(idd)
        ElseIf e.CommandArgs.CommandName.ToString = "Delete" Then
            cmd = New SqlCommand("DELETE FROM para_AssetManager_Banks where id='" + e.KeyValue.ToString + "' ", cn)
            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()
            getSecurities_Categories()
            msgbox("Asset Manager Bank Removed!")
        End If
    End Sub
    Protected Sub cmbassetmanager_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbassetmanager.SelectedIndexChanged
        getSecurities_Categories()
    End Sub
    Protected Sub cmbbank_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbbank.SelectedIndexChanged
        getbranches()
    End Sub
    Public Sub getbranches()
        cmd = New SqlCommand("select * from para_branch WHERE bank='" + cmbbank.SelectedValue.ToString + "'", cn)
        Dim ds As New DataSet
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "para_Country")
        If ds.Tables(0).Rows.Count > 0 Then
            cmbbranch.DataSource = ds
            cmbbranch.DataTextField = "branch_name"
            cmbbranch.DataValueField = "branch"
            cmbbranch.DataBind()
        End If

    End Sub
End Class
