Partial Class Reporting_Sharebalance
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
    Public Sub SaveClientStatementView(ByVal comp As String)
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("delete from tbl_ShareBalanceView where company='" & comp & "'", cn)
            If (cn.State = ConnectionState.Open) Then
                cn.Close()
            End If
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()


            cmd = New SqlCommand("select names.surname, names.forenames, tbl_matchedOrders.trade, Tbl_MatchedOrders.Quantity, Tbl_MatchedOrders.DealPrice, (Tbl_MatchedOrders.Quantity * Tbl_MatchedOrders.DealPrice) as [Purchase], 'P/'+CONVERT (varchar,Tbl_MatchedOrders.Deal) as [DealNo] ,(Tbl_MatchedOrders .DealPrice * Tbl_MatchedOrders .Quantity )as [Gross] from names , Tbl_MatchedOrders where names.CDS_Number = Tbl_MatchedOrders .Buyercdsno ", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "Tbl_MatchedOrders")
            If (ds.Tables(0).Rows.Count > 0) Then
                Dim i As Integer
                For i = 0 To ds.Tables(0).Rows.Count - 1
                    cmd = New SqlCommand("insert into tbl_ShareBalanceView (Holder,Trade_Date,Company,Quantity,Price,Purchase,Sale,DealNo,Gross) values ('" & ds.Tables(0).Rows(i).Item("surname").ToString & " " & ds.Tables(0).Rows(i).Item("forenames").ToString & "','" & ds.Tables(0).Rows(i).Item("trade").ToString & "','OMZL'," & ds.Tables(0).Rows(i).Item("Quantity").ToString & "," & ds.Tables(0).Rows(i).Item("DealPrice").ToString & "," & CDbl(ds.Tables(0).Rows(i).Item("Purchase").ToString) & ",0,'" & ds.Tables(0).Rows(i).Item("DealNo").ToString & "'," & ds.Tables(0).Rows(i).Item("Gross").ToString & ")", cn)
                    If (cn.State = ConnectionState.Open) Then
                        cn.Close()
                    End If
                    cn.Open()
                    cmd.ExecuteNonQuery()
                    cn.Close()
                Next
            End If

            'msgbox("test")
            Dim dsr As New DataSet
            cmd = New SqlCommand("select names.surname, names.forenames, tbl_matchedOrders.trade, Tbl_MatchedOrders.Quantity, Tbl_MatchedOrders.DealPrice, Tbl_MatchedOrders.Quantity * Tbl_MatchedOrders.DealPrice as [Sales], 'S/'+CONVERT (varchar,Tbl_MatchedOrders.Deal) as [DealNo] ,Tbl_MatchedOrders .DealPrice * Tbl_MatchedOrders .Quantity as [Gross] from names , Tbl_MatchedOrders where names.CDS_Number = Tbl_MatchedOrders .sellercdsno ", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(dsr, "Tbl_MatchedOrders")
            If (dsr.Tables(0).Rows.Count > 0) Then
                Dim x As Integer
                For x = 0 To dsr.Tables(0).Rows.Count - 1
                    cmd = New SqlCommand("insert into tbl_ShareBalanceView (Holder,Trade_Date,Company,Quantity,Price,Purchase,Sale,DealNo,Gross) values ('" & dsr.Tables(0).Rows(x).Item("surname").ToString & " " & dsr.Tables(0).Rows(x).Item("forenames").ToString & "','" & dsr.Tables(0).Rows(x).Item("trade").ToString & "','OMZL'," & dsr.Tables(0).Rows(x).Item("Quantity").ToString & "," & dsr.Tables(0).Rows(x).Item("DealPrice").ToString & ",0.0," & dsr.Tables(0).Rows(x).Item("Sales").ToString & ",'" & dsr.Tables(0).Rows(x).Item("DealNo").ToString & "'," & (dsr.Tables(0).Rows(x).Item("Gross").ToString) * -1 & ")", cn)
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

            If (txtDateFrom.Text = "" Or txtDateTo.Text = "") Then
                msgbox("Invalid Report Parameters Selected")
                Exit Sub
            End If

            SaveClientStatementView("OMZL")
            Dim strscript As String
            strscript = "<script langauage=JavaScript>"
            strscript += "window.open('ShareBalanceViewReport.aspx?Datefrom=" & txtDateFrom.Text & "&Dateto=" & txtDateTo.Text & "');"
            strscript += "</script>"
            ClientScript.RegisterStartupScript(Me.GetType(), "newwin", strscript)

        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Try

            lstSearchAcc.Items.Clear()
            lblCDsAccount.Text = ""
            lblCDsNumber.Text = ""
            Dim ds As New DataSet
            cmd = New SqlCommand("select cds_number+' '+surname+ ' '+forenames as namess from names where surname like '" & txtSeachName.Text & "%'", cn)
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
            Else
                lblCDsAccount.Text = ""
                lblCDsNumber.Text = ""
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
End Class
