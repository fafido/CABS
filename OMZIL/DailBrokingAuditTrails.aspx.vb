Partial Class Reporting_DailBrokingAuditTrails
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
        Try
            Page.MaintainScrollPositionOnPostBack = True
            If (Not IsPostBack) Then
                checkSessionState()
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        Try
            'Dim repType As String = ""
            'If (rdByBroker.Checked = True) Then
            '    repType = "B"
            'End If
            'If (rdAllTransactions.Checked = True) Then
            '    repType = "A"
            'End If

            cmd = New SqlCommand("delete from tbl_dailystats", cn)
            If (cn.State = ConnectionState.Open) Then
                cn.Close()
            End If
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()

            Dim ds As New DataSet
            cmd = New SqlCommand("SELECT names.CDS_Number , NAMES.Surname , NAMES.Forenames , 'P/'+ CONVERT (VARCHAR, Tbl_MatchedOrders .Deal) as [transactionref] , Tbl_MatchedOrders.Quantity , Tbl_MatchedOrders.DealPrice , round (Tbl_MatchedOrders.Quantity * Tbl_MatchedOrders.DealPrice,2) as [GrossProceeds], Tbl_MatchedOrders .Trade from names, Tbl_MatchedOrders where names.CDS_Number = Tbl_MatchedOrders .Buyercdsno  and Tbl_MatchedOrders.Trade >='" & txtDateFrom.Text & "' and Tbl_MatchedOrders .Trade <='" & txtDateTo.Text & "'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "tbl_matchedOrders")
            If (ds.Tables(0).Rows.Count > 0) Then
                Dim i As Integer = 0
                For i = 0 To ds.Tables(0).Rows.Count - 1
                    cmd = New SqlCommand("insert into tbl_dailystats (cds_number,surname,forenames,transactionref,quantity,dealprice,GrossProceeds,trade) values ('" & ds.Tables(0).Rows(i).Item("cds_number").ToString & "','" & ds.Tables(0).Rows(i).Item("surname").ToString & "','" & ds.Tables(0).Rows(i).Item("forenames").ToString & "','" & ds.Tables(0).Rows(i).Item("transactionref").ToString & "'," & ds.Tables(0).Rows(i).Item("Quantity").ToString & "," & ds.Tables(0).Rows(i).Item("DealPrice").ToString & "," & ds.Tables(0).Rows(i).Item("Grossproceeds").ToString & ",'" & ds.Tables(0).Rows(i).Item("trade").ToString & "')", cn)
                    If (cn.State = ConnectionState.Open) Then
                        cn.Close()
                    End If
                    cn.Open()
                    cmd.ExecuteNonQuery()
                    cn.Close()
                Next

            End If
            Dim dsi As New DataSet
            cmd = New SqlCommand("SELECT names.CDS_Number , NAMES.Surname , NAMES.Forenames , 'S/'+ CONVERT (VARCHAR, Tbl_MatchedOrders .Deal) as [transactionref] , Tbl_MatchedOrders.Quantity , Tbl_MatchedOrders.DealPrice , round (Tbl_MatchedOrders.Quantity * Tbl_MatchedOrders.DealPrice,2) as [GrossProceeds], Tbl_MatchedOrders .Trade from names, Tbl_MatchedOrders where names.CDS_Number = Tbl_MatchedOrders .Sellercdsno  and Tbl_MatchedOrders.Trade >='" & txtDateFrom.Text & "' and Tbl_MatchedOrders .Trade <='" & txtDateTo.Text & "'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(dsi, "tbl_matchedOrders")
            If (dsi.Tables(0).Rows.Count > 0) Then
                Dim z As Integer = 0
                For z = 0 To dsi.Tables(0).Rows.Count - 1
                    cmd = New SqlCommand("insert into tbl_dailystats(cds_number,surname,forenames,transactionref,quantity,dealprice,GrossProceeds,trade) values ('" & dsi.Tables(0).Rows(z).Item("cds_number").ToString & "','" & dsi.Tables(0).Rows(z).Item("surname").ToString & "','" & dsi.Tables(0).Rows(z).Item("forenames").ToString & "','" & dsi.Tables(0).Rows(z).Item("transactionref").ToString & "'," & dsi.Tables(0).Rows(z).Item("Quantity").ToString & "," & dsi.Tables(0).Rows(z).Item("DealPrice").ToString & "," & dsi.Tables(0).Rows(z).Item("Grossproceeds").ToString & ",'" & dsi.Tables(0).Rows(z).Item("trade").ToString & "')", cn)
                    If (cn.State = ConnectionState.Open) Then
                        cn.Close()
                    End If
                    cn.Open()
                    cmd.ExecuteNonQuery()
                    cn.Close()
                Next

            End If

            Dim strscript As String
            strscript = "<script langauage=JavaScript>"
            strscript += "window.open('DailyBrokingAuditTrailsReport.aspx?Datefrom=" & txtDateFrom.Text & "&Dateto=" & txtDateTo.Text & "');"
            strscript += "</script>"
            ClientScript.RegisterStartupScript(Me.GetType(), "newwin", strscript)

        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
End Class
