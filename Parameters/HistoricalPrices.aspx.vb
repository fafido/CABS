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
                'getprices(cmbParaCompany.Text)

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
    Public Sub getprices(ByVal company As String, ByVal datefrom As String, ByVal dateto As String)
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select company_name as Company,price_open  as Price,convert(date,price_date) as Date from testcds_router.dbo.prices where company_name ='" + company + "' and convert(date,'" + datefrom + "')  < convert(date,price_date) and convert(date,price_date) < = convert(date,'" + dateto + "') order by priceid desc ", cn)
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

        getprices(cmbParaCompany.SelectedItem.Text, txtdatefrom.Text, txtdate.Text)

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

    End Sub
End Class
