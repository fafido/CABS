Imports System.Data
Imports System.Data.SqlClient
Partial Class Parameters_BrokerFees
    Inherits System.Web.UI.Page
    Dim constr As String = (System.Configuration.ConfigurationManager.AppSettings("connpath"))
    Dim cn As New SqlConnection(constr)
    Dim cmd As SqlCommand
    Dim adp As SqlDataAdapter

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Page.MaintainScrollPositionOnPostBack = True
            If (Not IsPostBack) Then
                getCompany()
                cmbParaCompany.Text = "OMUT BALANCED FUND"
                ' getprices()
                getprices(cmbParaCompany.Text)

            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Public Sub getCompany()
        Try
            Dim ds As New DataSet
            If (Session("usertype") = "UNITTRUSTADMIN") Then
                cmd = New SqlCommand("select company, fnam from [testcds_ROUTER].[dbo].[para_company] where BOARD='UNIT TRUST' AND ISIN_No='OMUT'", cn)
            Else
                cmd = New SqlCommand("Select company from testcds_router.dbo.para_company", cn)

            End If

            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "para_company")
            cmbParaCompany.DataSource = ds.Tables(0)
            cmbParaCompany.DataValueField = "company"
            cmbParaCompany.DataBind()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Public Sub getprices(ByVal company As String)
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select company as Company,initialprice as CurrentPrice from testcds_router.dbo.para_company where company ='" + company + "'  ", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "para_company")
            ASPxGridView1.DataSource = ds
            ASPxGridView1.DataBind()

        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub btnPrintStatement_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPrintStatement.Click
        '    Try

        If cmbParaCompany.Text = "" Then
            MsgBox("Select Company")
            cmbParaCompany.Focus()
            Exit Sub
        End If

        If txtPrice.Text = "" Then
            MsgBox("Enter Share Price")
            txtPrice.Focus()
            Exit Sub
        End If
        If txtdate.Text = "" Then
            msgbox("Enter Share Price Date")
            txtPrice.Focus()
            Exit Sub
        End If
        Dim company As String = cmbParaCompany.SelectedItem.Text
        Dim pricedate As String = txtdate.Text
        Dim bidprice As String = txtPrice0.Text
        Dim askprice As String = txtPrice1.Text

        Dim price As String = txtPrice.Text
        cmd = New SqlCommand("insert into Market_Data (price_today,bid_price,ask_price,date,company) values ('" + price + "', '" + bidprice + "','" + askprice + "','" + pricedate + "', '" + company + "' )", cn)
        'cmd = New SqlCommand("update cds_router.dbo.ZSE_market_data set best_ask='" + price + "', best_bid='" + price + "', current_price='" + price + "' where ticker='" + company + "' update [testcds_ROUTER].[dbo].[para_company] set InitialPrice='" + price + "' where company='" + company + "' insert into testcds_router.dbo.prices(company_name, price_close, price_open, price_high, price_low, price_best,price_volume, price_date, price_time, havesent) values ('" + company + "','" + price + "','" + price + "','" + price + "','" + price + "','" + price + "','" + price + "',getdate(), getdate(),'1')", cn)
        If (cn.State = ConnectionState.Open) Then
            cn.Close()
        End If
        cn.Open()
        cmd.ExecuteNonQuery()
        cn.Close()
        getprices(cmbParaCompany.SelectedItem.Text)
        txtPrice.Text = ""

        msgbox("Price added successfully and now  awaits authorisation")

        'Catch ex As Exception
        '    MsgBox(ex.Message)
        'End Try
    End Sub
    Public Sub msgbox(ByVal strMessage As String)

        'finishes server processing, returns to client.
        Dim strScript As String = "<script language=JavaScript>"
        strScript += "window.alert(""" & strMessage & """);"
        strScript += "</script>"
        Dim lbl As New System.Web.UI.WebControls.Label
        lbl.Text = strScript
        Page.Controls.Add(lbl)

    End Sub
    Protected Sub cmbParaCompany_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbParaCompany.SelectedIndexChanged
        'msgbox("hie")
        getprices(cmbParaCompany.SelectedItem.Text)
    End Sub
End Class
