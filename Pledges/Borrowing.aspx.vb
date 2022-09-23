Imports System.Data
Imports System.Data.SqlClient
Partial Class Pledges_Borrowing
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
            If (txtshareholder.Text = "") Then
                msgbox("Enter a valid Shareholder Number")
                Exit Sub
            End If
            getholderDetails()
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub getholderDetails()
        Try
            Dim ds, ds1 As New DataSet
            cmd = New SqlCommand("Select * from mast where cds_number='" & txtshareholder.Text & "'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "mast")
            If (ds.Tables(0).Rows.Count > 0) Then
                cmd = New SqlCommand("select names.CDS_Number,names.surname,names.forenames,names.IDpp,names.add_1,names.add_2,names.add_3,names.add_4,names.city,names.country,names.telephone,names.cellphone,mast.shares,mast.CDS_Number from names,mast where names.cds_number=mast.cds_number and mast.cds_number='" & txtshareholder.Text & "'", cn)
                adp = New SqlDataAdapter(cmd)
                adp.Fill(ds1, "mast")
                'If (ds.Tables(0).Rows.Count > 0) Then
                txtshareholder.Text = ds1.Tables(0).Rows(0).Item("cds_number").ToString
                txtSurname.Text = (ds1.Tables(0).Rows(0).Item("surname").ToString + " " + ds1.Tables(0).Rows(0).Item("forenames").ToString)
                txtID.Text = ds1.Tables(0).Rows(0).Item("idpp").ToString
                txtAdd1.Text = (ds1.Tables(0).Rows(0).Item("add_1").ToString + " " + ds1.Tables(0).Rows(0).Item("add_2").ToString + " " + ds1.Tables(0).Rows(0).Item("add_3").ToString + " " + ds1.Tables(0).Rows(0).Item("add_4").ToString + " " + ds1.Tables(0).Rows(0).Item("city").ToString)
                getPledges()
                getCurrentBal()
                'Else
                'MsgBox("Invalid Shareholder number")
                'End If
            Else
                msgbox("Selected shareholder has no balances")
                txtshareholder.Focus()
                txtAdd1.Text = ""
                txtSurname.Text = ""
                txtID.Text = ""
                GdStatisticsView.DataSource = Nothing
                GdStatisticsView.DataBind()
                Exit Sub
            End If

        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub getPledges()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select sum(Pledge_Shares) as Pledges,mast.cds_number,names.surname,names.forenames,mast.company from names, mast where NAMES.CDS_Number = '" & txtshareholder.Text & "' and names.CDS_Number=mast.CDS_Number group by mast.CDS_number,names.surname,names.forenames,mast.company", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "mast")
            If (ds.Tables(0).Rows.Count > 0) Then
                GdStatisticsView.DataSource = ds.Tables(0)
                GdStatisticsView.DataBind()
            Else
                GdStatisticsView.DataSource = Nothing
                GdStatisticsView.DataBind()
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Try
            Dim ds As New DataSet
            Dim newshares, NewPledge As Integer
            cmd = New SqlCommand("select shares,pledge_Shares from mast where company='" & cmbCompany.Text & "' and cds_number='" & txtshareholder.Text & "'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "mast")
            If (ds.Tables(0).Rows.Count > 0) Then
                If (CInt(txtPledge.Text) > CInt(ds.Tables(0).Rows(0).Item("shares").ToString)) Then
                    msgbox("Pledge Shares Greater than current holding")
                    Exit Sub
                Else
                    newshares = CInt((ds.Tables(0).Rows(0).Item("shares").ToString) - (txtPledge.Text))
                    NewPledge = CInt((ds.Tables(0).Rows(0).Item("Pledge_shares").ToString) + (txtPledge.Text))
                    cmd = New SqlCommand("Update mast set shares=" & newshares & ", pledge_shares=" & NewPledge & ",Updated_On='" & Date.Now & "',Updated_By='" & Session("UserName") & "' where cds_number='" & txtshareholder.Text & "' and company='" & cmbCompany.Text & "'", cn)
                    If (cn.State = ConnectionState.Open) Then
                        cn.Close()
                    End If
                    cn.Open()
                    cmd.ExecuteNonQuery()
                    cn.Close()
                    SavePledges()
                    msgbox("Pledge Saved")
                    getPledges()
                End If
            Else
                msgbox("Shareholder has not valid shares in Selected Company")
                txtPledge.Text = ""
                txtPledgeReason.Text = ""
                Exit Sub
            End If

        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub SavePledges()
        Try
            cmd = New SqlCommand("insert into pledges (CDS_Number,Company,Shares,Pledgee,Pledged_reason,updated_by,Date_Created,PledgeState) values ('" & txtshareholder.Text & "','" & cmbCompany.Text & "'," & txtPledge.Text & ",'" & txtSurname.Text & "','" & txtPledgeReason.Text & "','" & Session("UserName") & "','" & Date.Now & "','C')", cn)
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
    Protected Sub btnSearchName_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearchName.Click
        Try
            Dim ds As New DataSet
            If (txtSearch.Text = "") Then
                msgbox("Enter a valid shareholder")
                Exit Sub
            End If
            cmd = New SqlCommand("Select surname+' '+forenames+' '+cds_number as namess from names where surname like '" & txtSearch.Text & "%'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "names")
            If (ds.Tables(0).Rows.Count > 0) Then
                lstNames.DataSource = ds.Tables("names")
                lstNames.DataValueField = "namess"
                lstNames.DataBind()
            Else
                lstNames.DataSource = Nothing
                lstNames.DataBind()
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub btnSelect_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSelect.Click
        Try
            Dim ds As New DataSet
            If (lstNames.SelectedIndex < 0) Then
                msgbox("Select atleast one name")
                Exit Sub
            End If
            cmd = New SqlCommand("Select cds_number from names where surname+' '+forenames+' '+cds_number ='" & lstNames.SelectedItem.Text & "'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "names")
            txtshareholder.Text = (ds.Tables(0).Rows(0).Item("cds_number").ToString)
            getholderDetails()
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub getCompany()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select distinct (company) from para_company", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "para_company")
            If (ds.Tables(0).Rows.Count > 0) Then
                cmbCompany.DataSource = ds.Tables(0)
                cmbCompany.DataValueField = "company"
                cmbCompany.DataBind()
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Page.MaintainScrollPositionOnPostBack = True
            If (Not IsPostBack) Then
                getCompany()
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub getCurrentBal()
        Try
            Dim ds, ds1 As New DataSet
            If (txtshareholder.Text <> "") Then
                cmd = New SqlCommand("Select * from mast where cds_number = '" & txtshareholder.Text & "' and company ='" & cmbCompany.Text & "'", cn)
                adp = New SqlDataAdapter(cmd)
                adp.Fill(ds1, "mast ")
                If (ds1.Tables(0).Rows.Count > 0) Then
                    cmd = New SqlCommand("Select sum(Shares) as Shares,sum(Pledge_Shares) as Pledges from mast where cds_number='" & txtshareholder.Text & "' and company='" & cmbCompany.Text & "'", cn)
                    adp = New SqlDataAdapter(cmd)
                    adp.Fill(ds, "mast")
                    Dim CurrentHolding, Pledges As Integer
                    CurrentHolding = ds.Tables(0).Rows(0).Item("Shares").ToString
                    Pledges = ds.Tables(0).Rows(0).Item("Pledges").ToString
                    txtBalance.Text = CInt(CurrentHolding - Pledges)
                Else
                    txtBalance.Text = "0"
                End If

            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Protected Sub cmbCompany_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbCompany.SelectedIndexChanged
        Try
            getCurrentBal()
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
End Class
