
Partial Class Reporting_ClientHolding
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
    Public Sub checkSessionState()
        Try

        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Session("UserName").ToString = "" Then
            Session.Abandon()
            Response.Cache.SetCacheability(HttpCacheability.NoCache)
            Response.Buffer = True
            Response.ExpiresAbsolute = DateTime.Now.AddDays(-1.0)
            Response.Expires = -1000
            Response.CacheControl = "no-cache"
            Response.Redirect("~/loginsystem.aspx", True)
        End If
        Try
            Page.MaintainScrollPositionOnPostBack = True
            If (Not IsPostBack) Then
                checkSessionState()
                GetSelectedDetails()
                loadwarehouse()




            End If

        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub



    Public Sub Getwahousesfin()
        Try
            Dim a As String

            If cmbwarehouse.SelectedIndex <> 0 Then

                a = " AND Warehouse  ='" + cmbwarehouse.SelectedValue + "'"

            Else
                a = ""
            End If



            Dim ds As New DataSet
            cmd = New SqlCommand("SELECT  w.id ,w.id as [S.No], s.WarehouseName  ,w.Commodity ,w.Grade ,w.Quantity ,w.Price ,w.ReceiptNo AS [EWR No.] ,w.UnitMeasure as [Unit of Measure] FROM [CDS].[dbo].[WR] W ,[CDS].[dbo].[WarehouseCreation] S where s.WarehouseCode = w.WarehousePhysical and w.Holder = '" + getDEPCDS(Session("Username")) + "' and CONVERT(date ,Date_Issued) between '" + txtDateFrom.Text + "' and  '" + txtDateTo.Text + "'   and isnull(Status ,'') ='ISSUED'  " + a + "  ", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "para_lendingRules")
            If (ds.Tables(0).Rows.Count > 0) Then



                GridView1.DataSource = ds.Tables(0)
                GridView1.DataBind()
            Else

                GridView1.DataSource = Nothing
                GridView1.DataBind()

            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub



    Public Sub Getwahouses()
        Try
            Dim a As String

            If cmbwarehouse.SelectedIndex <> 0 Then

                a = " AND Warehouse  ='" + cmbwarehouse.SelectedValue + "'"

            Else
                a = ""
            End If



            Dim ds As New DataSet
            cmd = New SqlCommand("SELECT  w.id ,w.id as [S.No], s.WarehouseName  ,w.Commodity ,w.Grade ,w.Quantity ,w.Price ,w.ReceiptNo AS [EWR No.] ,w.UnitMeasure as [Unit of Measure] FROM [CDS].[dbo].[WR] W ,[CDS].[dbo].[WarehouseCreation] S where s.WarehouseCode = w.WarehousePhysical and w.Holder = '" + getDEPCDS(Session("Username")) + "' and CONVERT(date ,Date_Issued) between '" + txtDateFrom.Text + "' and  '" + txtDateTo.Text + "' and isnull(Status ,'') LIKE '%AFT%' " + a + "", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "para_lendingRules")
            If (ds.Tables(0).Rows.Count > 0) Then
                btnprocess.Visible = True


                grdRules.DataSource = ds.Tables(0)
                grdRules.DataBind()
            Else

                grdRules.DataSource = Nothing
                grdRules.DataBind()

            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim chkView As CheckBox
            chkView = DirectCast(e.Row.FindControl("chkRow"), CheckBox)
            Dim id = DirectCast(e.Row.FindControl("id"), Label).Text


            chkView.Checked = getatfdetailts(id)

        End If
    End Sub

    Protected Sub grdRules_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdRules.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim chkView As CheckBox
            chkView = DirectCast(e.Row.FindControl("chkRow"), CheckBox)
            Dim id = DirectCast(e.Row.FindControl("id"), Label).Text


            chkView.Checked = getatfdetailts(id)

        End If
    End Sub

    Public Function getatfdetailts1(id As String) As Boolean
        Dim ds As New DataSet
        cmd = New SqlCommand("select * from [CDS].[dbo].[WR] where Status='AFT' and Holder ='" + getDEPCDS(Session("Username")) + "'", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "aft")
        If (ds.Tables(0).Rows.Count > 0) Then
            Return True
        Else
            Return False

        End If
    End Function

    Public Function getatfdetailts(id As String) As Boolean
        Dim ds As New DataSet
        cmd = New SqlCommand("select * from [CDS].[dbo].[WR] where Status='AFT' and id ='" + id + "'", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "aft")
        If (ds.Tables(0).Rows.Count > 0) Then
            Return True
        Else
            Return False

        End If
    End Function

    Public Sub SaveClientStatementView(ByVal cdsnu As String, ByVal comp As String)
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("delete from tbl_ClientStatementsView where company='" & comp & "' and cds_number='" & cdsnu & "'", cn)
            If (cn.State = ConnectionState.Open) Then
                cn.Close()
            End If
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()

            cmd = New SqlCommand("select top 1*  FROM [Deposits_Reg] where CDS_Number ='" & cdsnu & "' and Date_of_Deposit <='" & txtDateFrom.Text & "' order by id desc", cn)
            adp = New SqlDataAdapter(cmd)
            Dim ri As New DataSet
            adp.Fill(ri, "deposits_Reg")

            If (ri.Tables(0).Rows.Count > 0) Then
                cmd = New SqlCommand("insert into tbl_ClientStatementsView (trans_date,ref,trans_type,details,debit,credit,balance,cds_number,company) values ('" & txtDateFrom.Text & "','B/F','B/FWD','B/FWD',0.00,0.00," & ri.Tables(0).Rows(0).Item("Deposit_Amount").ToString & ",'" & cdsnu & "','')", cn)
                If (cn.State = ConnectionState.Open) Then
                    cn.Close()
                End If
                cn.Open()
                cmd.ExecuteNonQuery()
                cn.Close()
            Else
                cmd = New SqlCommand("insert into tbl_ClientStatementsView (trans_date,ref,trans_type,details,debit,credit,balance,cds_number,company) values ('" & txtDateFrom.Text & "','B/F','B/FWD','B/FWD',0.00,0.00,0,'" & cdsnu & "','')", cn)
                If (cn.State = ConnectionState.Open) Then
                    cn.Close()
                End If
                cn.Open()
                cmd.ExecuteNonQuery()
                cn.Close()
            End If

            cmd = New SqlCommand("select Tbl_MatchedOrders .Trade as [TradeDate] , 'P/'+convert(varchar ,deal) as [Deal],'PAYMENT' as [Type],  convert(varchar,Tbl_MatchedOrders.Quantity )+' '+''+  convert(varchar,Tbl_MatchedOrders.DealPrice) as [Details], Tbl_MatchedOrders.Quantity * Tbl_MatchedOrders .DealPrice as [Debit] ,  0.0 as [Credit]  from Tbl_MatchedOrders where Buyercdsno ='" & cdsnu & "'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "Tbl_MatchedOrders")
            If (ds.Tables(0).Rows.Count > 0) Then
                Dim i As Integer
                For i = 0 To ds.Tables(0).Rows.Count - 1

                    cmd = New SqlCommand("select top 1 id, debit, credit, balance from tbl_ClientStatementsView where cds_number='" & cdsnu & "' group by debit, credit, balance, id order by id desc", cn)
                    adp = New SqlDataAdapter(cmd)
                    Dim ros As New DataSet
                    adp.Fill(ros, "tbl_clientStatementsView")

                    cmd = New SqlCommand("insert into tbl_ClientStatementsView (trans_date,ref,trans_type,details,Debit,Credit,Balance,cds_number,company) values ('" & ds.Tables(0).Rows(i).Item("tradeDate").ToString & "','" & ds.Tables(0).Rows(i).Item("Deal").ToString & "','" & ds.Tables(0).Rows(i).Item("Type").ToString & "','" & ds.Tables(0).Rows(i).Item("Details").ToString & "'," & ds.Tables(0).Rows(i).Item("Debit").ToString & "," & ds.Tables(0).Rows(i).Item("credit").ToString & "," & CDbl((CDbl(ros.Tables(0).Rows(0).Item("balance").ToString) + CDbl(ds.Tables(0).Rows(i).Item("Debit").ToString)) - CDbl(ds.Tables(0).Rows(i).Item("credit").ToString)) & ",'" & cdsnu & "','')", cn)
                    If (cn.State = ConnectionState.Open) Then
                        cn.Close()
                    End If
                    cn.Open()
                    cmd.ExecuteNonQuery()
                    cn.Close()
                Next
            End If


            Dim dsr As New DataSet
            cmd = New SqlCommand("select Tbl_MatchedOrders .Trade as [TradeDate] , 'S/'+convert(varchar ,deal) as [Deal],'SALE' as [Type],  convert(varchar,Tbl_MatchedOrders.Quantity )+' '+''+  convert(varchar,Tbl_MatchedOrders.DealPrice) as [Details], Tbl_MatchedOrders.Quantity * Tbl_MatchedOrders .DealPrice as [Credit] ,  0.0 as [DEBIT],  (Tbl_MatchedOrders.Quantity * Tbl_MatchedOrders .DealPrice )*-1 as [Balance]  from Tbl_MatchedOrders where sellercdsno ='" & cdsnu & "'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(dsr, "Tbl_MatchedOrders")
            If (dsr.Tables(0).Rows.Count > 0) Then
                Dim x As Integer
                For x = 0 To dsr.Tables(0).Rows.Count - 1
                    cmd = New SqlCommand("insert into tbl_ClientStatementsView (trans_date,ref,trans_type,details,Debit,Credit,Balance,cds_number,company) values ('" & dsr.Tables(0).Rows(x).Item("tradeDate").ToString & "','" & dsr.Tables(0).Rows(x).Item("Deal").ToString & "','" & dsr.Tables(0).Rows(x).Item("Type").ToString & "','" & dsr.Tables(0).Rows(x).Item("Details").ToString & "'," & dsr.Tables(0).Rows(x).Item("Debit").ToString & "," & dsr.Tables(0).Rows(x).Item("credit").ToString & "," & dsr.Tables(0).Rows(x).Item("Balance").ToString & ",'" & cdsnu & "','')", cn)
                    If (cn.State = ConnectionState.Open) Then
                        cn.Close()
                    End If
                    cn.Open()
                    cmd.ExecuteNonQuery()
                    cn.Close()
                Next
            End If

        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Protected Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        Try

            If txtDateFrom.Text = "" Or txtDateTo.Text = "" Then
                msgbox("Invalid Report Parameters Selected")
                Exit Sub
            End If


            Getwahousesfin()
            Getwahouses()
            'SaveClientStatementView(getDEPCDS(Session("Username")), "")
            'Session("par_cdsno") = getDEPCDS(Session("Username"))
            'Dim strscript As String
            'strscript = "<script langauage=JavaScript>"
            'strscript += "window.open('ClientHoldingReport.aspx?Datefrom=" & txtDateFrom.Text & "&Dateto=" & txtDateTo.Text & "');"
            'strscript += "</script>"
            'ClientScript.RegisterStartupScript(Me.GetType(), "newwin", strscript)

        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        ' Try
        If Session("usertype") = "CMCAdmin" Or Session("usertype") = "CMCUser" Then
            lstSearchAcc.Items.Clear()
            lblCDsAccount.Text = ""
            lblCDsNumber.Text = ""
            Dim ds As New DataSet
            cmd = New SqlCommand("select cds_number, left(cds_number,100)+' '+surname+ ' '+forenames as namess from Accounts_clients where cds_number+' '+surname+ ' '+forenames+' '+mobile like '%" & txtSeachName.Text & "%'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "names")
            If (ds.Tables(0).Rows.Count > 0) Then
                lstSearchAcc.DataSource = ds.Tables(0)
                lstSearchAcc.TextField = "namess"
                lstSearchAcc.ValueField = "cds_number"
                lstSearchAcc.DataBind()
            Else
                lstSearchAcc.Items.Clear()
            End If
        ElseIf Session("Companytype") = "CUSTODIAN" Then

            lstSearchAcc.Items.Clear()
            lblCDsAccount.Text = ""
            lblCDsNumber.Text = ""
            Dim ds As New DataSet
            cmd = New SqlCommand("select cds_number, left(cds_number,100)+' '+surname+ ' '+forenames as namess from Accounts_clients where cds_number+' '+surname+ ' '+forenames+' '+tel like '%" & txtSeachName.Text & "%'  and Custodian='" + Session("BrokerCode") + "'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "names")
            If (ds.Tables(0).Rows.Count > 0) Then
                lstSearchAcc.DataSource = ds.Tables(0)
                lstSearchAcc.TextField = "namess"
                lstSearchAcc.ValueField = "cds_number"
                lstSearchAcc.DataBind()
            Else
                lstSearchAcc.Items.Clear()
            End If

        Else

            lstSearchAcc.Items.Clear()
            lblCDsAccount.Text = ""
            lblCDsNumber.Text = ""
            Dim ds As New DataSet
            cmd = New SqlCommand("select cds_number,  cds_number+' '+surname+ ' '+forenames as namess from aCCOUNTs_CLIENTS where cds_number+' '+surname+ ' '+forenames+' '+MOBILE like '%" & txtSeachName.Text & "%' ", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "names")
            If (ds.Tables(0).Rows.Count > 0) Then
                lstSearchAcc.DataSource = ds.Tables(0)
                lstSearchAcc.TextField = "namess"
                lstSearchAcc.ValueField = "cds_number"
                lstSearchAcc.DataBind()
            Else
                lstSearchAcc.Items.Clear()
            End If
        End If

        'Catch ex As Exception
        '    msgbox(ex.Message)
        'End Try
    End Sub

    Public Function getDEPCDS(CDSno As String) As String
        Dim ds As New DataSet
        cmd = New SqlCommand("select Role  FROM [CDS].[dbo].[SystemUsers] where UserName='" + CDSno + "'", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "Accounts_Clients")
        If (ds.Tables(0).Rows.Count > 0) Then
            Return ds.Tables(0).Rows(0).Item("Role").ToString
        Else
            Return ""

        End If
    End Function

    Public Sub GetSelectedDetails()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select FORENAMES, SURNAME, CDS_NUMBER AS CDS_NUMBER from names where cds_numbeR = '" & getDEPCDS(Session("Username")) & "'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "names")
            If (ds.Tables(0).Rows.Count > 0) Then
                lblCDsNumber.Text = ds.Tables(0).Rows(0).Item("cds_number").ToString
                lblCDsAccount.Text = ds.Tables(0).Rows(0).Item("Forenames").ToString & " " & ds.Tables(0).Rows(0).Item("Surname").ToString

                Dim ds1 As New DataSet
                cmd = New SqlCommand("select distinct company as company from trans where cds_number = '" & lblCDsNumber.Text & "'", cn)
                adp = New SqlDataAdapter(cmd)
                adp.Fill(ds1, "trns")
                If ds1.Tables("trns").Rows.Count > 0 Then
                    'ASPxComboBox1.DataSource = ds1
                    'ASPxComboBox1.TextField = "company"
                    'ASPxComboBox1.DataBind()
                End If

            Else
                lblCDsAccount.Text = ""
                lblCDsNumber.Text = ""
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub lstSearchAcc_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstSearchAcc.SelectedIndexChanged
        Try
            If Session("usertype") = "CDSAdmin" Or Session("usertype") = "CDSUser" Then
                Dim ds As New DataSet
                cmd = New SqlCommand("select FORENAMES, SURNAME, LEFT(CDS_NUMBER,100) AS CDS_NUMBER from Accounts_clients where LEFT(cds_number,100)+' '+surname+ ' '+forenames = '" & lstSearchAcc.SelectedItem.Text & "'", cn)
                adp = New SqlDataAdapter(cmd)
                adp.Fill(ds, "names")
                If (ds.Tables(0).Rows.Count > 0) Then
                    lblCDsNumber.Text = ds.Tables(0).Rows(0).Item("cds_number").ToString
                    lblCDsAccount.Text = ds.Tables(0).Rows(0).Item("Forenames").ToString & " " & ds.Tables(0).Rows(0).Item("Surname").ToString

                    Dim ds1 As New DataSet
                    cmd = New SqlCommand("select distinct company as company from trans where cds_number = '" & lblCDsNumber.Text & "'", cn)
                    adp = New SqlDataAdapter(cmd)
                    adp.Fill(ds1, "trns")
                    If ds1.Tables("trns").Rows.Count > 0 Then
                        'ASPxComboBox1.DataSource = ds1
                        'ASPxComboBox1.TextField = "company"
                        'ASPxComboBox1.DataBind()
                    End If

                Else
                    lblCDsAccount.Text = ""
                    lblCDsNumber.Text = ""
                End If
            Else
                Dim ds As New DataSet
                cmd = New SqlCommand("select FORENAMES, SURNAME, CDS_NUMBER AS CDS_NUMBER from names where cds_number+' '+surname+ ' '+forenames = '" & lstSearchAcc.SelectedItem.Text & "'", cn)
                adp = New SqlDataAdapter(cmd)
                adp.Fill(ds, "names")
                If (ds.Tables(0).Rows.Count > 0) Then
                    lblCDsNumber.Text = ds.Tables(0).Rows(0).Item("cds_number").ToString
                    lblCDsAccount.Text = ds.Tables(0).Rows(0).Item("Forenames").ToString & " " & ds.Tables(0).Rows(0).Item("Surname").ToString

                    Dim ds1 As New DataSet
                    cmd = New SqlCommand("select distinct company as company from trans where cds_number = '" & lblCDsNumber.Text & "'", cn)
                    adp = New SqlDataAdapter(cmd)
                    adp.Fill(ds1, "trns")
                    If ds1.Tables("trns").Rows.Count > 0 Then
                        'ASPxComboBox1.DataSource = ds1
                        'ASPxComboBox1.TextField = "company"
                        'ASPxComboBox1.DataBind()
                    End If

                Else
                    lblCDsAccount.Text = ""
                    lblCDsNumber.Text = ""
                End If
            End If
         
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub btnPrint0_Click(sender As Object, e As EventArgs) Handles btnPrint0.Click
        Response.Redirect(Request.RawUrl)
    End Sub



    'Protected Sub cheched(ByVal sender As Object, ByVal e As EventArgs)





    '    For Each row As GridViewRow In grdRules.Rows
    '        If row.RowType = DataControlRowType.DataRow Then
    '            Dim chkRow As CheckBox = TryCast(row.Cells(0).FindControl("chkRow"), CheckBox)

    '            If chkRow.Checked = True Then

    '                Dim tb As TextBox = DirectCast(grdRules.Rows(i).FindControl("id"), TextBox)
    '                Dim Id As String = tb.Text




    '                cmd = New SqlCommand("update  [CDS].[dbo].[WR] set atf = '1' where id = '" + Id.ToString() + "'", cn)
    '                If (cn.State = ConnectionState.Open) Then
    '                    cn.Close()
    '                End If
    '                cn.Open()
    '                If cmd.ExecuteNonQuery() = 1 Then

    '                End If


    '            ElseIf Not chkRow.Checked Then

    '                cmd = New SqlCommand("update  [CDS].[dbo].[WR] set atf = '0' where id = '" + ID.ToString() + "'", cn)
    '                If (cn.State = ConnectionState.Open) Then
    '                    cn.Close()
    '                End If
    '                cn.Open()
    '                If cmd.ExecuteNonQuery() = 1 Then

    '                End If


    '            End If

    '        End If
    '    Next









    '    cn.Close()


    'End Sub



    Protected Sub grdRules_SelectedIndexChanged(sender As Object, e As EventArgs) Handles grdRules.SelectedIndexChanged







        cmd = New SqlCommand("update  [CDS].[dbo].[WR] set Status = 'AFT' where id = '" + ID.ToString() + "'", cn)
        If (cn.State = ConnectionState.Open) Then
            cn.Close()
        End If
        cn.Open()
        If cmd.ExecuteNonQuery() = 1 Then

        End If




        cmd = New SqlCommand("update  [CDS].[dbo].[WR] set Status = 'ISSUED' where id = '" + ID.ToString() + "'", cn)
        If (cn.State = ConnectionState.Open) Then
            cn.Close()
        End If
        cn.Open()
        If cmd.ExecuteNonQuery() = 1 Then

        End If



    End Sub

    Public Sub loadwarehouse()
        Dim ds As New DataSet
        cmd = New SqlCommand("   select distinct Warehouse , c.WarehouseName from [CDS].[dbo].[WR] w join [CDS].[dbo].[WarehouseCreation] c on w.WarehousePhysical = c.WarehouseCode", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "Accounts_Clients")
        If (ds.Tables(0).Rows.Count > 0) Then
            cmbwarehouse.DataSource = ds
            cmbwarehouse.DataValueField = "Warehouse"
            cmbwarehouse.DataTextField = "WarehouseName"



            cmbwarehouse.DataBind()
            cmbwarehouse.Items.Insert(0, New ListItem("ALL", "0"))

        End If
    End Sub

    Protected Sub btnprocess_Click(sender As Object, e As EventArgs) Handles btnprocess.Click
        Dim cnt = 0
        For Each row As GridViewRow In grdRules.Rows
            If row.RowType = DataControlRowType.DataRow Then
                Dim chkRow As CheckBox = TryCast(row.Cells(0).FindControl("chkRow"), CheckBox)
                If chkRow.Checked Then
                    Dim Id As String = row.Cells(2).Text
                    'procedure to reverse
                    cmd = New SqlCommand("update  [CDS].[dbo].[WR] set Status = 'AFT' where id = '" + Id.ToString() + "'", cn)
                    If (cn.State = ConnectionState.Open) Then
                        cn.Close()
                    End If
                    cn.Open()
                    If cmd.ExecuteNonQuery() = 1 Then

                    End If



                Else

                    Dim Id As String = row.Cells(2).Text
                    'procedure to reverse
                    cmd = New SqlCommand("update  [CDS].[dbo].[WR] set Status  ='ISSUED' where id = '" + Id.ToString() + "'", cn)
                    If (cn.State = ConnectionState.Open) Then
                        cn.Close()
                    End If
                    cn.Open()
                    If cmd.ExecuteNonQuery() = 1 Then

                    End If




                End If



            End If
            cnt += 1
        Next
        Dim cnt1 = 0
        For Each row As GridViewRow In GridView1.Rows
            If row.RowType = DataControlRowType.DataRow Then
                Dim chkRow As CheckBox = TryCast(row.Cells(0).FindControl("chkRow"), CheckBox)
                If chkRow.Checked Then
                    Dim Id As String = row.Cells(2).Text
                    'procedure to reverse
                    cmd = New SqlCommand("update  [CDS].[dbo].[WR] set Status = 'AFT' where id = '" + Id.ToString() + "'", cn)
                    If (cn.State = ConnectionState.Open) Then
                        cn.Close()
                    End If
                    cn.Open()
                    If cmd.ExecuteNonQuery() = 1 Then

                    End If



                Else

                    Dim Id As String = row.Cells(2).Text
                    'procedure to reverse
                    cmd = New SqlCommand("update  [CDS].[dbo].[WR] set Status  ='ISSUED' where id = '" + Id.ToString() + "'", cn)
                    If (cn.State = ConnectionState.Open) Then
                        cn.Close()
                    End If
                    cn.Open()
                    If cmd.ExecuteNonQuery() = 1 Then

                    End If




                End If



            End If
            cnt1 += 1
        Next

        Getwahousesfin()
        Getwahouses()

        msgbox("Successfully processed")
    End Sub
End Class
