Partial Class TransferSec_retrievepayments_interest
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
            cmd = New SqlCommand("SELECT (SELECT MOBILE FROM CDS.DBO.ACCOUNTS_CLIENTS WHERE CDS_Number=convert(nvarchar(50),m.bondholder))  as mobile , ACTUAL_GROSS as amount, '0' as quantity FROM Kbond.dbo.bond_interest m where issuer='GVT'", cn)
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
            Dim ds As New DataSet
            cmd = New SqlCommand("SELECT (SELECT MOBILE FROM CDS.DBO.ACCOUNTS_CLIENTS WHERE CDS_Number=convert(nvarchar(50),m.bondholder))  as mobile , ACTUAL_GROSS as amount, '0' as quantity FROM Kbond.dbo.bond_interest m where issuer='GVT'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "tbl_MatchedOrders")
            If (ds.Tables(0).Rows.Count > 0) Then
                grdsellers.DataSource = ds.Tables(0)
                grdsellers.DataBind()
                If (ds.Tables(0).Rows.Count > 1) Then
                    Button1.Visible = True

                End If
            Else
                grdsellers.DataSource = Nothing
                grdsellers.DataBind()
                msgbox("No Pending Interest Payment Records")
            End If

            Response.Clear()

            Response.Buffer = True

            Response.AddHeader("content-disposition", "attachment;filename=" & Now.Date & "interest_Payments_")
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

    
End Class
