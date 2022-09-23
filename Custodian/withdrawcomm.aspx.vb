Partial Class withdrawcomm

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


    Public Sub Getapendingaffirmation()

        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select p.ID, p.cds_number AS [Client No], a.surname+' '+a.forenames as [Names] , p.Quantity , p.CreatedDate as withdrawaldate ,right(p.Commodity , charindex('/', reverse(p.commodity)) - 1)  as [grade],SUBSTRING(p.commodity,0, CHARINDEX('/',p.commodity))  as Commodity, 'KG' as UnitofMeasure  from [CDS_ROUTER].[dbo].[PendingWithdrawals] p, cds_router.dbo.Accounts_Clients_Web a where Approved is NULL and a.CDS_Number=p.CDS_Number", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "Permissions")
            If (ds.Tables(0).Rows.Count > 0) Then
                Gridview1.DataSource = ds
                Gridview1.DataBind()
            Else
                Gridview1.DataSource = Nothing
                Gridview1.DataBind()
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Page.MaintainScrollPositionOnPostBack = True
            If (Not IsPostBack) Then


                Getapendingaffirmation()



            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub



    Protected Sub GridView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Gridview1.SelectedIndexChanged

        Dim id As String = Gridview1.SelectedRow.Cells(0).Text


        'processcharges("BUY", val, buyordernumber, company)
        'processcharges("SELL", val, sellordernumber, company)



        '  Dim buymsg As String = "8=FIXT.1.19=33135=834=849=FIX_GATEWAY52=20180718-09:18:13.22956=ESCROUTER1128=71=180625032933-000111=" + Gridview1.SelectedRow.Cells(6).Text + "14=" + Gridview1.SelectedRow.Cells(2).Text + "17=6031=" + Gridview1.SelectedRow.Cells(3).Text + "37=6038=3039=240=244=" + Gridview1.SelectedRow.Cells(3).Text + "54=155=" + Gridview1.SelectedRow.Cells(4).Text + "59=060=20180718-09:18:13150=F151=0167=CS198=81537453=3448=180625032933-0001447=D452=3448=EFESZWHX447=D452=1448=CBCSZWHX447=D452=4527=427341093=210=11423000=" + chargeamount + "23100=BUY"
        ' Dim sellmsg As String = "8=FIXT.1.19=33135=834=849=FIX_GATEWAY52=20180718-09:18:13.22956=ESCROUTER1128=71=180625032933-000111=" + Gridview1.SelectedRow.Cells(7).Text + "14=" + Gridview1.SelectedRow.Cells(2).Text + "17=6031=" + Gridview1.SelectedRow.Cells(3).Text + "37=6038=3039=240=244=" + Gridview1.SelectedRow.Cells(3).Text + "54=155=" + Gridview1.SelectedRow.Cells(4).Text + "59=060=20180718-09:18:13150=F151=0167=CS198=81537453=3448=180625032933-0001447=D452=3448=EFESZWHX447=D452=1448=CBCSZWHX447=D452=4527=427341093=210=11423000=" + chargeamount + "23100=SELL"


        cmd = New SqlCommand("update [CDS_ROUTER].[dbo].[PendingWithdrawals] set approved='1' where id='" + id + "'", cn)
        If (cn.State = ConnectionState.Open) Then
            cn.Close()
        End If
        cn.Open()
        cmd.ExecuteNonQuery()
        cn.Close()

        Getapendingaffirmation()
        msgbox("Withdrawal Successfully affirmed!")
        '  msgbox(Gridview1.SelectedRow.Cells(0).Text)
    End Sub




    'Public Sub inserttocharges(Transactioncode As String, chargename As String, totalcharges As String)
    '    cmd = New SqlCommand("insert into cds_router.dbo.TransactionCharges (transactionCode, chargecode, Charges, [Date]) values ('" + Transactioncode + "','" + chargename + "','" + totalcharges + "',getdate())", cn)
    '    If (cn.State = ConnectionState.Open) Then
    '        cn.Close()
    '    End If
    '    cn.Open()
    '    cmd.ExecuteNonQuery()
    '    cn.Close()
    'End Sub

End Class

