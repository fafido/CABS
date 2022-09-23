Imports System.Data
Imports System.Data.SqlClient
Partial Class Pledges_TransferToLandingPool
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
            lblShareholder.Text = (ds.Tables(0).Rows(0).Item("cds_number").ToString)
            'txtSearch.Text = (ds.Tables(0).Rows(0).Item("cds_number").ToString)
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
                cmbCounter.DataSource = ds.Tables(0)
                cmbCounter.DataValueField = "company"
                cmbCounter.DataBind()
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Page.MaintainScrollPositionOnPostBack = True
            If (Not IsPostBack) Then
                cmd = New SqlCommand("insert into UserActivityLog (UserName,Activity,TimeOfActivity,DateDone,CompanyCode) values ('" & Session("Username") & "','Accessed Transfer to Lending Pool Form','" & Date.Now & "','" & Now.Date & "','" & Session("BrokerCode") & "')", cn)
                If (cn.State = ConnectionState.Open) Then
                    cn.Close()
                End If
                cn.Open()
                cmd.ExecuteNonQuery()
                cn.Close()
                GetSecurities()
                ControlsVisibility()
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub GetSecurities()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select distinct (ItemDescrip) from LendingSecurities", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "LendingSecurities")
            If (ds.Tables(0).Rows.Count > 0) Then
                cmbSecurityType.DataSource = ds.Tables(0)
                cmbSecurityType.DataValueField = "ItemDescrip"
                cmbSecurityType.DataBind()
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub ControlsVisibility()
        Try
            Label17.Visible = False
            cmbCounter.Visible = False
            Label18.Visible = False
            txtSharePrice.Visible = False
            Label19.Visible = False
            txtSharesTrans.Visible = False
            Label20.Visible = False
            txtAssetType.Visible = False
            Label21.Visible = False
            Label22.Visible = False
            txtAssetDescr.Visible = False

            If (cmbSecurityType.SelectedValue.ToString = "SHARES") Then
                getCounters()
                Label17.Visible = True
                Label19.Text = "Shares"
                Label18.Text = "Share Price"
                cmbCounter.Visible = True
                Label18.Visible = True
                txtSharePrice.Visible = True
                Label19.Visible = True
                txtSharesTrans.Visible = True
                Label20.Visible = False
                txtAssetType.Visible = False
                Label21.Visible = False
                Label22.Visible = False
                txtAssetDescr.Visible = False
            End If
            If (cmbSecurityType.SelectedValue.ToString = "BONDS") Then
                getCounters()
                Label19.Text = "Units"
                Label18.Text = "Unit Price"
                Label17.Visible = True
                cmbCounter.Visible = True
                Label18.Visible = True
                txtSharePrice.Visible = True
                Label19.Visible = True
                txtSharesTrans.Visible = True
                Label20.Visible = False
                txtAssetType.Visible = False
                Label21.Visible = False
                Label22.Visible = False
                txtAssetDescr.Visible = False
            End If
            If (cmbSecurityType.SelectedValue.ToString = "PROPERTY") Then
                Label17.Visible = False
                cmbCounter.Visible = False
                Label18.Visible = False
                txtSharePrice.Visible = True
                Label19.Visible = False
                txtSharesTrans.Visible = False
                Label20.Visible = True
                txtAssetType.Visible = True
                Label21.Visible = True
                Label22.Visible = True
                txtAssetDescr.Visible = True
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub getCurrentBal()
        Try
            Dim ds, ds1 As New DataSet
            If (lblShareholder.Text <> "") Then
                cmd = New SqlCommand("Select * from mast where cds_number = '" & lblShareholder.Text & "' and company ='" & cmbCounter.Text & "'", cn)
                adp = New SqlDataAdapter(cmd)
                adp.Fill(ds1, "mast ")
                If (ds1.Tables(0).Rows.Count > 0) Then
                    cmd = New SqlCommand("Select sum(Shares) as Shares,sum(Pledge_Shares) as Pledges from mast where cds_number='" & lblShareholder.Text & "' and company='" & cmbCounter.Text & "'", cn)
                    adp = New SqlDataAdapter(cmd)
                    adp.Fill(ds, "mast")
                    Dim CurrentHolding, Pledges As Integer
                    CurrentHolding = ds.Tables(0).Rows(0).Item("Shares").ToString
                    Pledges = ds.Tables(0).Rows(0).Item("Pledges").ToString
                    'txtBalance.Text = CInt(CurrentHolding - Pledges)
                Else
                    'txtBalance.Text = "0"
                End If

            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            cmd = New SqlCommand("insert into UserActivityLog (UserName,Activity,TimeOfActivity,DateDone,CompanyCode) values ('" & Session("Username") & "','Saved a transfer to landing pool record','" & Date.Now & "','" & Now.Date & "','" & Session("BrokerCode") & "')", cn)
            If (cn.State = ConnectionState.Open) Then
                cn.Close()
            End If
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()
            Dim Security As String = ""
            If (cmbSecurityType.SelectedValue.ToString = "PROPERTY") Then
                Security = txtAssetDescr.Text
            ElseIf (cmbSecurityType.SelectedValue.ToString = "SHARES") Then
                Security = "SHARES"
            Else
                Security = "BONDS"

            End If
            If (cmbSecurityType.SelectedValue.ToString = "PROPERTY") Then
                'msgbox("insert into LendingMast (LendingHolder, Security,Counter, UnitsShares, UnitPrice, SecurityDescr, SecurityComments, SecurityValue, Date_Created, ReturnDueDate,CreatedBy) values ('" & lblShareholder.Text & "', '" & cmbSecurityType.Text & "', '" & cmbCounter.Text & "', " & txtSharesTrans.Text & ", " & txtSharePrice.Text & ",'" & cmbSecurityType.SelectedValue.ToString & "','" & Security & "'," & CDbl(CInt(txtSharesTrans.Text) * CDbl(txtSharePrice.Text)) & " ,'" & Now.Date & "','" & ReturnDueDate.Text & "','" & Session("Username") & "')")
                cmd = New SqlCommand("insert into LendingMast (LendingHolder, Security,Counter, UnitsShares, UnitPrice, SecurityDescr, SecurityComments, SecurityValue, Date_Created, ReturnDueDate,CreatedBy) values ('" & lblShareholder.Text & "', '" & cmbSecurityType.Text & "', '" & cmbCounter.Text & "', 0, 0,'" & cmbSecurityType.SelectedValue.ToString & "','" & Security & "'," & CDbl(CDbl(txtSharePrice.Text)) & " ,'" & Now.Date & "','" & ReturnDueDate.Text & "','" & Session("Username") & "')", cn)
                If (cn.State = ConnectionState.Open) Then
                    cn.Close()
                End If
                cn.Open()
                cmd.ExecuteNonQuery()
                cn.Close()

                msgbox("Record Saved")
                ControlsVisibility()
                txtAssetDescr.Text = ""
                txtAssetType.Text = ""
                txtSearch.Text = ""
                txtSharePrice.Text = ""
                txtSharesTrans.Text = ""
                lblShareholder.Text = ""
                lstNames.Items.Clear()
                ReturnDueDate.Clear()
            Else
                'Is holder there ?

                Dim dsx As New DataSet
                cmd = New SqlCommand("select distinct (cds_number) from mast where company='" & cmbCounter.Text & "' and cds_number='" & lblShareholder.Text & "'", cn)
                adp = New SqlDataAdapter(cmd)
                adp.Fill(dsx, "mast")

                If (dsx.Tables(0).Rows.Count > 0) Then
                    'Validation
                    Dim dsi As New DataSet
                    cmd = New SqlCommand("Select  sum (mast.shares)as shares from mast where company='" & cmbCounter.Text & "' and cds_Number='" & lblShareholder.Text & "'", cn)
                    adp = New SqlDataAdapter(cmd)
                    adp.Fill(dsi, "mast")

                    If (CInt(dsi.Tables(0).Rows(0).Item("shares").ToString) < CInt(txtSharesTrans.Text)) Then
                        msgbox("Entered shares/bond units are greater than the current portfolio holding")
                        txtSharesTrans.Focus()
                        Exit Sub
                    End If

                    cmd = New SqlCommand("insert into LendingMast (LendingHolder, Security,Counter, UnitsShares, UnitPrice, SecurityDescr, SecurityComments, SecurityValue, Date_Created, ReturnDueDate,CreatedBy) values ('" & lblShareholder.Text & "', '" & cmbSecurityType.Text & "', '" & cmbCounter.Text & "', " & txtSharesTrans.Text & ", " & txtSharePrice.Text & ",'" & cmbSecurityType.SelectedValue.ToString & "','" & Security & "'," & CDbl(CInt(txtSharesTrans.Text) * CDbl(txtSharePrice.Text)) & " ,'" & Now.Date & "','" & ReturnDueDate.Text & "','" & Session("Username") & "')", cn)
                    If (cn.State = ConnectionState.Open) Then
                        cn.Close()
                    End If
                    cn.Open()
                    cmd.ExecuteNonQuery()
                    cn.Close()

                    If (cmbSecurityType.SelectedValue.ToString = "SHARES" Or cmbSecurityType.SelectedValue.ToString = "BONDS") Then
                        cmd = New SqlCommand("insert into mast (company,cds_number,date_created,shares,update_type,created_by,updated_on,updated_by) values('" & cmbCounter.Text & "', '" & lblShareholder.Text & "','" & Now.Date & "'," & CInt(txtSharesTrans.Text) * -1 & ", 'TRANSFER TO LENDING','" & Session("uSERnAME") & "', '" & Now.Date & "','" & Session("uSERnAME") & "')", cn)
                        If (cn.State = ConnectionState.Open) Then
                            cn.Close()
                        End If
                        cn.Open()
                        cmd.ExecuteNonQuery()
                        cn.Close()
                    End If

                    msgbox("Record Saved")
                    ControlsVisibility()
                    txtAssetDescr.Text = ""
                    txtAssetType.Text = ""
                    txtSearch.Text = ""
                    txtSharePrice.Text = ""
                    txtSharesTrans.Text = ""
                    lblShareholder.Text = ""
                    lstNames.Items.Clear()
                    ReturnDueDate.Clear()
                Else
                    msgbox("Selected account has no valid shares/bonds")
                End If
            End If
            
            
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub getCounters()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select distinct (company) from mast", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "mast")
            If (ds.Tables(0).Rows.Count > 0) Then
                cmbCounter.DataSource = ds.Tables(0)
                cmbCounter.DataValueField = "company"
                cmbCounter.DataBind()
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Protected Sub cmbSecurityType_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbSecurityType.SelectedIndexChanged
        Try
            ControlsVisibility()
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub lstNames_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstNames.SelectedIndexChanged
        Dim ds As New DataSet
        If (lstNames.SelectedIndex < 0) Then
            msgbox("Select atleast one name")
            Exit Sub
        End If
        cmd = New SqlCommand("Select cds_number from names where surname+' '+forenames+' '+cds_number ='" & lstNames.SelectedItem.Text & "'", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "names")
        lblShareholder.Text = (ds.Tables(0).Rows(0).Item("cds_number").ToString)
    End Sub
End Class
