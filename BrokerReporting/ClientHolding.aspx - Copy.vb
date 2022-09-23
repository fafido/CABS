
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
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
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

            cmd = New SqlCommand("select top 1*  FROM [CDS].[dbo].[Deposits_Reg] where CDS_Number ='" & cdsnu & "' and Date_of_Deposit <='" & txtDateFrom.Text & "' order by id desc", cn)
            adp = New SqlDataAdapter(cmd)
            Dim ri As New DataSet
            adp.Fill(ri, "deposits_Reg")

            If (ri.Tables(0).Rows.Count > 0) Then
                cmd = New SqlCommand("insert into tbl_ClientStatementsView (trans_date,ref,trans_type,details,debit,credit,balance,cds_number,company) values ('" & txtDateFrom.Text & "','B/F','B/FWD','B/FWD',0.00,0.00," & ri.Tables(0).Rows(0).Item("Deposit_Amount").ToString & ",'" & cdsnu & "','" + ASPxComboBox1.SelectedItem.Text + "')", cn)
                If (cn.State = ConnectionState.Open) Then
                    cn.Close()
                End If
                cn.Open()
                cmd.ExecuteNonQuery()
                cn.Close()
            Else
                cmd = New SqlCommand("insert into tbl_ClientStatementsView (trans_date,ref,trans_type,details,debit,credit,balance,cds_number,company) values ('" & txtDateFrom.Text & "','B/F','B/FWD','B/FWD',0.00,0.00,0,'" & cdsnu & "','" + ASPxComboBox1.SelectedItem.Text + "')", cn)
                If (cn.State = ConnectionState.Open) Then
                    cn.Close()
                End If
                cn.Open()
                cmd.ExecuteNonQuery()
                cn.Close()
            End If

            cmd = New SqlCommand("select Tbl_MatchedOrders .Trade as [TradeDate] , 'P/'+convert(varchar ,deal) as [Deal],'PAYMENT' as [Type],  convert(varchar,Tbl_MatchedOrders.Quantity )+' '+'" + ASPxComboBox1.SelectedItem.Text + " @'+  convert(varchar,Tbl_MatchedOrders.DealPrice) as [Details], Tbl_MatchedOrders.Quantity * Tbl_MatchedOrders .DealPrice as [Debit] ,  0.0 as [Credit]  from Tbl_MatchedOrders where Buyercdsno ='" & cdsnu & "'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "Tbl_MatchedOrders")
            If (ds.Tables(0).Rows.Count > 0) Then
                Dim i As Integer
                For i = 0 To ds.Tables(0).Rows.Count - 1

                    cmd = New SqlCommand("select top 1 id, debit, credit, balance from tbl_ClientStatementsView where cds_number='" & cdsnu & "' group by debit, credit, balance, id order by id desc", cn)
                    adp = New SqlDataAdapter(cmd)
                    Dim ros As New DataSet
                    adp.Fill(ros, "tbl_clientStatementsView")

                    cmd = New SqlCommand("insert into tbl_ClientStatementsView (trans_date,ref,trans_type,details,Debit,Credit,Balance,cds_number,company) values ('" & ds.Tables(0).Rows(i).Item("tradeDate").ToString & "','" & ds.Tables(0).Rows(i).Item("Deal").ToString & "','" & ds.Tables(0).Rows(i).Item("Type").ToString & "','" & ds.Tables(0).Rows(i).Item("Details").ToString & "'," & ds.Tables(0).Rows(i).Item("Debit").ToString & "," & ds.Tables(0).Rows(i).Item("credit").ToString & "," & CDbl((CDbl(ros.Tables(0).Rows(0).Item("balance").ToString) + CDbl(ds.Tables(0).Rows(i).Item("Debit").ToString)) - CDbl(ds.Tables(0).Rows(i).Item("credit").ToString)) & ",'" & cdsnu & "','" + ASPxComboBox1.SelectedItem.Text + "')", cn)
                    If (cn.State = ConnectionState.Open) Then
                        cn.Close()
                    End If
                    cn.Open()
                    cmd.ExecuteNonQuery()
                    cn.Close()
                Next
            End If


            Dim dsr As New DataSet
            cmd = New SqlCommand("select Tbl_MatchedOrders .Trade as [TradeDate] , 'S/'+convert(varchar ,deal) as [Deal],'SALE' as [Type],  convert(varchar,Tbl_MatchedOrders.Quantity )+' '+'" + ASPxComboBox1.SelectedItem.Text + " @'+  convert(varchar,Tbl_MatchedOrders.DealPrice) as [Details], Tbl_MatchedOrders.Quantity * Tbl_MatchedOrders .DealPrice as [Credit] ,  0.0 as [DEBIT],  (Tbl_MatchedOrders.Quantity * Tbl_MatchedOrders .DealPrice )*-1 as [Balance]  from Tbl_MatchedOrders where sellercdsno ='" & cdsnu & "'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(dsr, "Tbl_MatchedOrders")
            If (dsr.Tables(0).Rows.Count > 0) Then
                Dim x As Integer
                For x = 0 To dsr.Tables(0).Rows.Count - 1
                    cmd = New SqlCommand("insert into tbl_ClientStatementsView (trans_date,ref,trans_type,details,Debit,Credit,Balance,cds_number,company) values ('" & dsr.Tables(0).Rows(x).Item("tradeDate").ToString & "','" & dsr.Tables(0).Rows(x).Item("Deal").ToString & "','" & dsr.Tables(0).Rows(x).Item("Type").ToString & "','" & dsr.Tables(0).Rows(x).Item("Details").ToString & "'," & dsr.Tables(0).Rows(x).Item("Debit").ToString & "," & dsr.Tables(0).Rows(x).Item("credit").ToString & "," & dsr.Tables(0).Rows(x).Item("Balance").ToString & ",'" & cdsnu & "','" + ASPxComboBox1.SelectedItem.Text + "')", cn)
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

            If (lblCDsNumber.Text = "" Or txtDateFrom.Text = "" Or txtDateTo.Text = "") Then
                msgbox("Invalid Report Parameters Selected")
                Exit Sub
            End If

            SaveClientStatementView(lblCDsNumber.Text, "" + ASPxComboBox1.SelectedItem.Text + "")
            Session("par_cdsno") = lblCDsNumber.Text
            Dim strscript As String
            strscript = "<script langauage=JavaScript>"
            strscript += "window.open('ClientHoldingReport.aspx?Datefrom=" & txtDateFrom.Text & "&Dateto=" & txtDateTo.Text & "&company=" + ASPxComboBox1.SelectedItem.Text + "');"
            strscript += "</script>"
            ClientScript.RegisterStartupScript(Me.GetType(), "newwin", strscript)

        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Try
            If Session("usertype") = "CDSAdmin" Or Session("usertype") = "CDSUser" Then
                lstSearchAcc.Items.Clear()
                lblCDsAccount.Text = ""
                lblCDsNumber.Text = ""
                Dim ds As New DataSet
                cmd = New SqlCommand("select cds_number+' '+surname+ ' '+forenames as namess from names where cds_number+' '+surname+ ' '+forenames+' '+cellphone like '%" & txtSeachName.Text & "%'", cn)
                adp = New SqlDataAdapter(cmd)
                adp.Fill(ds, "names")
                If (ds.Tables(0).Rows.Count > 0) Then
                    lstSearchAcc.DataSource = ds.Tables(0)
                    lstSearchAcc.TextField = "namess"
                    lstSearchAcc.ValueField = "namess"
                    lstSearchAcc.DataBind()
                Else
                    lstSearchAcc.Items.Clear()
                End If
            Else
                lstSearchAcc.Items.Clear()
                lblCDsAccount.Text = ""
                lblCDsNumber.Text = ""
                Dim ds As New DataSet
                cmd = New SqlCommand("select cds_number+' '+surname+ ' '+forenames as namess from names where cds_number+' '+surname+ ' '+forenames+' '+cellphone like '%" & txtSeachName.Text & "%' and Broker_code='" + Session("BrokerCode") + "'", cn)
                adp = New SqlDataAdapter(cmd)
                adp.Fill(ds, "names")
                If (ds.Tables(0).Rows.Count > 0) Then
                    lstSearchAcc.DataSource = ds.Tables(0)
                    lstSearchAcc.TextField = "namess"
                    lstSearchAcc.ValueField = "namess"
                    lstSearchAcc.DataBind()
                Else
                    lstSearchAcc.Items.Clear()
                End If
            End If
           
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub lstSearchAcc_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstSearchAcc.SelectedIndexChanged
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select * from names where cds_number+' '+surname+ ' '+forenames = '" & lstSearchAcc.SelectedItem.Text & "'", cn)
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
                    ASPxComboBox1.DataSource = ds1
                    ASPxComboBox1.TextField = "company"
                    ASPxComboBox1.DataBind()
                End If

            Else
                lblCDsAccount.Text = ""
                lblCDsNumber.Text = ""
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub btnPrint0_Click(sender As Object, e As EventArgs) Handles btnPrint0.Click
        Response.Redirect(Request.RawUrl)
    End Sub
End Class
