Imports System.Data
Imports System.Data.SqlClient
Partial Class Pledges_FreezeUnfreezeAudit
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
    Protected Sub btnHolderNumSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnHolderNumSearch.Click
        Try
            getHolderNumber()
            getPledgecompany()
            getPledgeShares()
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub getHolderNumber()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("Select * from pledges where CDS_Number ='" & txtshareholder.Text & "'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "pledges")
            If (ds.Tables(0).Rows.Count > 0) Then
                getPledgecompany()
                getPledgeShares()
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub getPledgeShares()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("Select sum(shares) as shares from pledges where company='" & cmbCompany.Text & "' and cds_number='" & txtshareholder.Text & "'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "pledges")
            If (ds.Tables(0).Rows.Count > 0) Then

            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub rdEdit_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdEdit.CheckedChanged
        Try
            If (rdEdit.Enabled = True) Then
                Label7.Visible = True
                txtPledgesShares.Visible = True
                txtPledgesShares.Text = ""
            Else
                Label7.Visible = False
                txtPledgesShares.Visible = False
                txtPledgesShares.Text = ""
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub getPledgecompany()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("Select distinct (company) from pledges where cds_number = '" & txtshareholder.Text & "'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "pledges")
            If (ds.Tables(0).Rows.Count > 0) Then
                cmbCompany.DataSource = ds.Tables(0)
                cmbCompany.DataValueField = "company"
                cmbCompany.DataBind()
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Protected Sub rdClear_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdClear.CheckedChanged
        Try
            If (rdClear.Checked = True) Then
                Label7.Visible = False
                txtPledgesShares.Text = ""
                txtPledgesShares.Visible = False
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub btnSelect_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSelect.Click
        Try
            Dim ds As New DataSet
            If (lstNames.SelectedIndex > 0) Then
                cmd = New SqlCommand("Select CDS_number from names where surname+' '+forenames+' '+cds_number = '" & lstNames.SelectedItem.Text & "'", cn)
                adp = New SqlDataAdapter(cmd)
                adp.Fill(ds, "names")
                txtshareholder.Text = (ds.Tables(0).Rows(0).Item("CDS_Number").ToString)
                getPledgecompany()
                getPledgeShares()
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub cmbCompany_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbCompany.SelectedIndexChanged
        Try
            getPledgeShares()
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub btnSearchName_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearchName.Click
        Try
            Dim ds As New DataSet
            If (txtSearch.Text = "") Then
                msgbox("Enter a valid search name")
                Exit Sub
            End If
            cmd = New SqlCommand("Select surname+' '+forenames+' '+cds_number as namess from names where surname like '" & txtSearch.Text & "%'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "names")
            If (ds.Tables(0).Rows.Count > 0) Then
                lstNames.DataSource = ds.Tables(0)
                lstNames.DataValueField = "namess"
                lstNames.DataBind()
            Else
                lstNames.DataSource = Nothing
                lstNames.DataValueField = ""
                lstNames.DataBind()
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Try
            If (rdClear.Checked = True) Then
                cmd = New SqlCommand("update mast set Pledge_Shares=0 where CDS_Number='" & txtshareholder.Text & "' AND company='" & cmbCompany.Text & "'", cn)
                If (cn.State = ConnectionState.Open) Then
                    cn.Close()
                End If
                cn.Open()
                cmd.ExecuteNonQuery()
                cn.Close()
            End If
            If (rdEdit.Checked = True) Then
                Dim ds As New DataSet
                Dim CurrentPledge As Integer
                cmd = New SqlCommand("Select sum(shares) as shares from mast where CDS_Number='" & txtshareholder.Text & "' and company='" & cmbCompany.Text & "'", cn)
                adp = New SqlDataAdapter(cmd)
                adp.Fill(ds, "mast")
                CurrentPledge = CInt((ds.Tables(0).Rows(0).Item("Shares").ToString) - (txtPledgesShares.Text))
                cmd = New SqlCommand("update mast set Pledge_Shares=" & txtPledgesShares.Text & " where cds_number='" & txtshareholder.Text & "' company='" & cmbCompany.Text & "'", cn)
                If (cn.State = ConnectionState.Open) Then
                    cn.Close()
                End If
                cn.Open()
                cmd.ExecuteNonQuery()
                cn.Close()
            End If
            cmd = New SqlCommand("insert into UserActivityLog (UserName,Activity,TimeOfActivity,DateDone,CompanyCode) values ('" & Session("Username") & "','Authorized an account freeze/unfreeze status','" & Date.Now & "','" & Now.Date & "','" & Session("BrokerCode") & "')", cn)
            If (cn.State = ConnectionState.Open) Then
                cn.Close()
            End If
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Not IsPostBack = True Then
                cmd = New SqlCommand("insert into UserActivityLog (UserName,Activity,TimeOfActivity,DateDone,CompanyCode) values ('" & Session("Username") & "','Accessed Freeze/Unfreeze Authorization Form','" & Date.Now & "','" & Now.Date & "','" & Session("BrokerCode") & "')", cn)
                If (cn.State = ConnectionState.Open) Then
                    cn.Close()
                End If
                cn.Open()
                cmd.ExecuteNonQuery()
                cn.Close()
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub btnSave0_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave0.Click

    End Sub
End Class
