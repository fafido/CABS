Partial Class TransferSec_retrievepayments
    Inherits System.Web.UI.Page
    Dim constr As String = (System.Configuration.ConfigurationManager.AppSettings("connpath"))
    Dim cn As New SqlConnection(constr)
    Dim adp As SqlDataAdapter
    Dim cmd As SqlCommand
    Public allrec As String
    Public customernumber, customermessage As String

    Public Sub msgbox(ByVal strMessage As String)

        'finishes server processing, returns to client.
        Dim strScript As String = "<script language=JavaScript>"
        strScript += "window.alert(""" & strMessage & """);"
        strScript += "</script>"
        Dim lbl As New System.Web.UI.WebControls.Label
        lbl.Text = strScript
        Page.Controls.Add(lbl)

    End Sub
    Public Sub getpendingauth()
        Try
            Dim ds As New DataSet
            'cmd = New SqlCommand("select Tbl_MatchedOrders .Sellercdsno as [CDS No.] , Accounts_Clients.Surname +' '+Accounts_Clients .Forenames as [Client], Tbl_MatchedOrders .Quantity as [Quantity], Tbl_MatchedOrders.DealPrice as [Price], Tbl_MatchedOrders .Trade as [Trade Date] from Tbl_MatchedOrders , Accounts_Clients where Tbl_MatchedOrders.Sellercdsno = Accounts_Clients .CDS_Number and trade between '" & Datefrom & "' and '" & DateTo & "'", cn)
            cmd = New SqlCommand("select company, fromcdsnumber, (select MOBILE from Accounts_Clients where cds_number=tbl_units_move.fromcdsnumber ) as mobile, (select sum(shares) from trans where CDS_Number=tbl_units_move.fromcdsnumber  and company=tbl_units_move.company) as newbalance, quantity, amount  FROM tbl_units_move", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "tbl_MatchedOrders")
            If (ds.Tables(0).Rows.Count > 0) Then
                grdSellers.DataSource = ds.Tables(0)
                grdsellers.DataBind()
                If (ds.Tables(0).Rows.Count > 1) Then
                    Button1.Visible = True

                End If
            Else
                grdsellers.DataSource = Nothing
                grdsellers.DataBind()
                msgbox("No Pending Sell Records")
            End If

        Catch ex As Exception
            msgbox(ex.Message)
        End Try
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
                getpendingauth()
                '  MovingOrders()

                checkSessionState()

            End If
            If Session("finish") = "yes" Then
                Session("finish") = ""
                msgbox("Successfully Authorized")
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub


    
  
    
   
    
   

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Csv1()

    End Sub
    Public Sub Csv1()
        Try
            Dim ds1 As New DataSet
            cmd = New SqlCommand("select company, fromcdsnumber, (select MOBILE from Accounts_Clients where cds_number=tbl_units_move.fromcdsnumber ) as mobile, (select sum(shares) from trans where CDS_Number=tbl_units_move.fromcdsnumber  and company=tbl_units_move.company) as newbalance, quantity, amount  FROM tbl_units_move", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds1, "tbl_MatchedOrders")
            If (ds1.Tables(0).Rows.Count > 0) Then
                grdsellers.DataSource = ds1.Tables(0)
                grdsellers.DataBind()
            Else
                grdsellers.DataSource = Nothing
                grdsellers.DataBind()
                msgbox("No Pending Sell Records")
            End If

            Response.Clear()

            Response.Buffer = True

            Response.AddHeader("content-disposition", "attachment;filename=" & Now.Date & "_Payments_")
            Response.Charset = ""
            Response.ContentType = "application/text"
            grdsellers.AllowPaging = False
            grdsellers.DataBind()

            Dim sb As New StringBuilder()

            For k As Integer = 0 To grdsellers.Columns.Count - 1

                'add separator

                sb.Append(grdsellers.Columns(k).HeaderText + ","c)

            Next

            'append new line

            sb.Append(vbCr & vbLf)

            For i As Integer = 0 To grdsellers.Rows.Count - 1

                For k As Integer = 0 To grdsellers.Columns.Count - 1

                    'add separator

                    sb.Append(grdsellers.Rows(i).Cells(k).Text + ","c)

                Next

                'append new line

                sb.Append(vbCr & vbLf)

            Next

            Response.Output.Write(sb.ToString())

            Response.Flush()

            Response.End()
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
  
    Protected Sub grdsellers0_SelectedIndexChanged(sender As Object, e As EventArgs) Handles grdsellers0.SelectedIndexChanged

    End Sub
End Class
