Imports System.Data
Imports System.Data.SqlClient
Partial Class Pledges_BorrowerRequest
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
            txtSearch.Text = (ds.Tables(0).Rows(0).Item("cds_number").ToString)
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Page.MaintainScrollPositionOnPostBack = True
            If (Not IsPostBack) Then
                cmd = New SqlCommand("insert into UserActivityLog (UserName,Activity,TimeOfActivity,DateDone,CompanyCode) values ('" & Session("Username") & "','Accessed Borrower Request Form','" & Date.Now & "','" & Now.Date & "','" & Session("BrokerCode") & "')", cn)
                If (cn.State = ConnectionState.Open) Then
                    cn.Close()
                End If
                cn.Open()
                cmd.ExecuteNonQuery()
                cn.Close()
                GetSecurities()
                GetLentItem()
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub GetSecurities()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select distinct (Security) from LendingMast where SecurityState='O'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "LendingMast")

            If (ds.Tables(0).Rows.Count > 0) Then
                cmbSecurityType.DataSource = ds.Tables(0)
                cmbSecurityType.DataValueField = "Security"
                cmbSecurityType.DataBind()

                If (cmbSecurityType.Text = "PROPERTY") Then
                    Label19.Text = "Asset"
                Else
                    Label19.Text = "Counter"
                End If
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub GetLentItem()
        Try
            Dim ds As New DataSet
            If (cmbSecurityType.Text = "PROPERTY") Then
                cmd = New SqlCommand("select (SecurityComments) , LendingID as SecurityComments from LendingMast where SecurityDescr='" & cmbSecurityType.Text & "' and SecurityState='O'", cn)
                adp = New SqlDataAdapter(cmd)
                adp.Fill(ds, "LendingMast")
                If (ds.Tables(0).Rows.Count > 0) Then
                    cmbSecurityType0.DataSource = ds.Tables(0)
                    cmbSecurityType0.DataValueField = "SecurityComments"
                    cmbSecurityType0.DataBind()
                Else
                    cmbSecurityType0.Items.Clear()
                End If
            Else
                cmd = New SqlCommand("select distinct (Counter) as Counter from LendingMast where SecurityDescr='" & cmbSecurityType.Text & "' and SecurityState='O'", cn)
                adp = New SqlDataAdapter(cmd)
                adp.Fill(ds, "LendingMast")
                If (ds.Tables(0).Rows.Count > 0) Then
                    cmbSecurityType0.DataSource = ds.Tables(0)
                    cmbSecurityType0.DataValueField = "Counter"
                    cmbSecurityType0.DataBind()
                Else
                    cmbSecurityType0.Items.Clear()
                End If
            End If

            If (cmbSecurityType.Text <> "") Then
                getLentItemValues()
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub getLentItemValues()
        Try
            Dim ds As New DataSet
            If (cmbSecurityType.Text = "PROPERTY") Then
                cmd = New SqlCommand("Select * from LendingMast where security='" & cmbSecurityType.Text & "' and SecurityComments='" & cmbSecurityType0.Text & "'", cn)
                adp = New SqlDataAdapter(cmd)
                adp.Fill(ds, "lendingMast")
                If (ds.Tables(0).Rows.Count > 0) Then
                    Label20.Text = "Asset Value"
                    Label21.Text = FormatCurrency(ds.Tables(0).Rows(0).Item("SecurityValue").ToString)
                    Label22.Text = ""
                    Label23.Text = ""
                Else
                    Label20.Text = ""
                    Label21.Text = ""
                End If
            Else
                Dim dsi As New DataSet
                cmd = New SqlCommand("select sum (UnitsShares) as Unitsshares from lendingMast where counter='" & cmbSecurityType0.Text & "' and Security='" & cmbSecurityType.Text & "' and SecurityState='O'", cn)
                adp = New SqlDataAdapter(cmd)
                adp.Fill(dsi, "LendingMast")

                If (dsi.Tables(0).Rows.Count > 0) Then
                    Label20.Text = "Total Shares/Units"
                    Label21.Text = FormatNumber(dsi.Tables(0).Rows(0).Item("UnitsShares").ToString)

                Else
                    Label20.Text = ""
                    Label21.Text = ""
                End If

                cmd = New SqlCommand("select * from lendingMast where counter='" & cmbSecurityType0.Text & "' and security='" & cmbSecurityType.Text & "' and SecurityState='O'", cn)
                adp = New SqlDataAdapter(cmd)
                adp.Fill(ds, "LendingMast")

                If (ds.Tables(0).Rows.Count > 0) Then
                    Label22.Text = ds.Tables(0).Rows(0).Item("LendingID").ToString
                    Label23.Text = ds.Tables(0).Rows(0).Item("UnitsSHares").ToString
                Else
                    Label22.Text = ""
                    Label23.Text = ""
                End If
                
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try


            Dim ds As New DataSet
            If (cmbSecurityType.Text = "Property".ToUpper) Then
            Else
                If (CInt(txtQuantity.Text) < CInt(Label23.Text)) Then

                    'Borrowings are less than Lending ID
                    cmd = New SqlCommand("insert into mast (company,cds_number,date_created,shares,update_type,created_by,updated_on,updated_by) values ('" & cmbSecurityType0.Text & "', '" & lblShareholder.Text & "','" & Now.Date & "'," & txtQuantity.Text & ",'BORROWED','" & Session("Username") & "','" & Now.Date & "','" & Session("username") & "')", cn)
                    If (cn.State = ConnectionState.Open) Then
                        cn.Close()
                    End If
                    cn.Open()
                    cmd.ExecuteNonQuery()
                    cn.Close()

                    cmd = New SqlCommand("Update lendingmast set UnitsShares=" & CInt(CInt(Label23.Text) - CInt(txtQuantity.Text)) & " where LendingID=" & CInt(Label22.Text) & " and counter='" & cmbSecurityType0.Text & "' and security='" & cmbSecurityType.Text & "'", cn)
                    If (cn.State = ConnectionState.Open) Then
                        cn.Close()
                    End If
                    cn.Open()
                    cmd.ExecuteNonQuery()
                    cn.Close()


                    Dim dsc As New DataSet
                    cmd = New SqlCommand("select * from lendingMast where counter='" & cmbSecurityType0.Text & "' and security='" & cmbSecurityType.Text & "' and SecurityState='O'", cn)
                    adp = New SqlDataAdapter(cmd)
                    adp.Fill(dsc, "LendingMast")

                    If (dsc.Tables(0).Rows.Count > 0) Then
                        Label22.Text = dsc.Tables(0).Rows(0).Item("LendingID").ToString
                        Label23.Text = dsc.Tables(0).Rows(0).Item("UnitsSHares").ToString
                    Else
                        Label22.Text = ""
                        Label23.Text = ""
                    End If

                    msgbox("Record Saved")
                End If
                If (CInt(txtQuantity.Text) > CInt(Label23.Text)) Then
                    cmd = New SqlCommand("insert into mast (company,cds_number,date_created,shares,update_type,created_by,updated_on,updated_by) values ('" & cmbSecurityType0.Text & "', '" & lblShareholder.Text & "','" & Now.Date & "'," & txtQuantity.Text & ",'BORROWED','" & Session("Username") & "','" & Now.Date & "','" & Session("username") & "')", cn)
                    If (cn.State = ConnectionState.Open) Then
                        cn.Close()
                    End If
                    cn.Open()
                    cmd.ExecuteNonQuery()
                    cn.Close()

                    Dim dsb As New DataSet
                    Dim i As Integer = 0

                    Do While i < CInt(txtQuantity.Text)
                        Dim dscount As New DataSet
                        cmd = New SqlCommand("select sum(shares) as shares from mast where cds_Number='" & lblShareholder.Text & "' and Date_Created='" & Now.Date & "' and Updated_Type='BORROWED' and shares > 0 ", cn)
                        adp = New SqlDataAdapter(cmd)
                        adp.Fill(dscount, "mast")

                        cmd = New SqlCommand("select UnitsShares,LendingID from lendingMast where counter='" & cmbSecurityType0.Text & "' and security='" & cmbSecurityType.Text & "' and SecurityState='O' ORDER by LendingID asc", cn)
                        Dim dsx As New DataSet
                        adp = New SqlDataAdapter(cmd)
                        adp.Fill(dsx, "LendingMast")

                        If (dsx.Tables(0).Rows.Count > 0) Then

                            If (dsx.Tables(0).Rows(0).Item("UnitsShares").ToString <= CInt(CInt(txtQuantity.Text) - CInt(dscount.Tables(0).Rows(0).Item("shares").ToString))) Then
                                cmd = New SqlCommand("Update mast set shares = shares + " & dsx.Tables(0).Rows(0).Item("Unitsshares").ToString & " where cds_Number='" & lblShareholder.Text & "' and Date_Created='" & Now.Date & "' and Updated_Type='BORROWED' and shares > 0 ", cn)
                                If (cn.State = ConnectionState.Open) Then
                                    cn.Close()
                                End If
                                cn.Open()
                                cmd.ExecuteNonQuery()
                                cn.Close()

                                cmd = New SqlCommand("Update LendingMast set SecurityState='B',BorrowedUnits=" & dsx.Tables(0).Rows(0).Item("Unitsshares").ToString & ",DateBorrowed='" & Now.Date & "' where lendingID=" & dsx.Tables(0).Rows(0).Item("LendingID").ToString & "", cn)
                                If (cn.State = ConnectionState.Open) Then
                                    cn.Close()
                                End If
                                cn.Open()
                                cmd.ExecuteNonQuery()
                                cn.Close()
                            End If


                            If (dsx.Tables(0).Rows(0).Item("UnitsShares").ToString > CInt(CInt(txtQuantity.Text) - CInt(dscount.Tables(0).Rows(0).Item("shares").ToString))) Then
                                cmd = New SqlCommand("Update mast set shares = shares + " & CInt(CInt(txtQuantity.Text) - CInt(dscount.Tables(0).Rows(0).Item("shares").ToString)) & " where cds_Number='" & lblShareholder.Text & "' and Date_Created='" & Now.Date & "' and Updated_Type='BORROWED' and shares > 0 ", cn)
                                If (cn.State = ConnectionState.Open) Then
                                    cn.Close()
                                End If
                                cn.Open()
                                cmd.ExecuteNonQuery()
                                cn.Close()

                                cmd = New SqlCommand("Update LendingMast set  BorrowedUnits=" & CInt(CInt(txtQuantity.Text) - CInt(dscount.Tables(0).Rows(0).Item("shares").ToString)) & ",DateBorrowed='" & Now.Date & "' where lendingID=" & dsx.Tables(0).Rows(0).Item("LendingID").ToString & "", cn)
                                If (cn.State = ConnectionState.Open) Then
                                    cn.Close()
                                End If
                                cn.Open()
                                cmd.ExecuteNonQuery()
                                cn.Close()

                            End If

                            cmd = New SqlCommand("select sum(shares) as shares from mast where cds_Number='" & lblShareholder.Text & "' and Date_Created='" & Now.Date & "' and Updated_Type='BORROWED' and shares > 0 ", cn)
                            adp = New SqlDataAdapter(cmd)
                            adp.Fill(dsb, "mast")
                            i = dsb.Tables(0).Rows(0).Item("shares").ToString

                        Else
                            msgbox("No more shares to borrow from the lending pool")
                            Exit Do
                        End If
                    Loop
                    

                    

                    cmd = New SqlCommand("Update lendingmast set UnitsShares=" & CInt(CInt(Label23.Text) - CInt(txtQuantity.Text)) & " where LendingID=" & CInt(Label22.Text) & " and counter='" & cmbSecurityType0.Text & "' and security='" & cmbSecurityType.Text & "'", cn)
                    If (cn.State = ConnectionState.Open) Then
                        cn.Close()
                    End If
                    cn.Open()
                    cmd.ExecuteNonQuery()
                    cn.Close()


                    Dim dsc As New DataSet
                    cmd = New SqlCommand("select * from lendingMast where counter='" & cmbSecurityType0.Text & "' and security='" & cmbSecurityType.Text & "' and SecurityState='O'", cn)
                    adp = New SqlDataAdapter(cmd)
                    adp.Fill(dsc, "LendingMast")

                    If (dsc.Tables(0).Rows.Count > 0) Then
                        Label22.Text = dsc.Tables(0).Rows(0).Item("LendingID").ToString
                        Label23.Text = dsc.Tables(0).Rows(0).Item("UnitsSHares").ToString
                    Else
                        Label22.Text = ""
                        Label23.Text = ""
                    End If

                    If (Label22.Text <> "") Then
                        cmd = New SqlCommand("Update mast set shares =  shares + (" & CInt(CInt(txtQuantity.Text)) & " - shares) where cds_number='" & lblShareholder.Text & "' and company='" & cmbSecurityType0.Text & "' AND update_type='BORROWED'", cn)
                        If (cn.State = ConnectionState.Open) Then
                            cn.Close()
                        End If
                        cn.Open()
                        cmd.ExecuteNonQuery()
                        cn.Close()
                    End If

                    msgbox("Record Saved")
                End If
            End If


            cmd = New SqlCommand("insert into BorrowingMast (Cds_Number,Counter_Asset,UnitsShares,Value,Borrowed_Date,SettlementDate,ReturnDueDate,BorrowingStatus) values ('" & lblShareholder.Text & "','" & cmbSecurityType0.Text & "'," & txtQuantity.Text & ",0,'" & Now.Date & "','" & SettlementDate.Text & "','" & SettlementDate0.Text & "','O')", cn)
            If (cn.State = ConnectionState.Open) Then
                cn.Close()
            End If
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()


            '====================
            cmd = New SqlCommand("insert into UserActivityLog (UserName,Activity,TimeOfActivity,DateDone,CompanyCode) values ('" & Session("Username") & "','Saved a borrower request record','" & Date.Now & "','" & Now.Date & "','" & Session("BrokerCode") & "')", cn)
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

    Protected Sub cmbSecurityType_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbSecurityType.SelectedIndexChanged
        Try
            If (cmbSecurityType.Text = "PROPERTY") Then
                Label19.Text = "Asset"
            Else
                Label19.Text = "Counter"
            End If
            GetLentItem()
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub cmbSecurityType0_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbSecurityType0.SelectedIndexChanged
        Try
            getLentItemValues()
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
