Imports System.Net.Mail
Imports System.IO
Imports System
Imports System.Configuration
Imports System.Web
Imports System.Web.Security
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Partial Class TransferSec_MoneyMarket
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
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Page.MaintainScrollPositionOnPostBack = True
            If (Not IsPostBack) Then

                '   loaddata()
                Try
                    filtersload()

                Catch ex As Exception

                End Try


            End If

        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub


    Public Sub loaddata(mro As String)
        Dim ds1 As New DataSet
        cmd = New SqlCommand("  select [TradeDate], [SettlementDate], [Description] , ClientNo, a.Surname+' '+a.forenames as [Names], AssetManager, TradeType, Amount , FixedRate , DayCountBasis, MaturityValue ,  SettlementAmount, c.Currency as TradeCurrency, SettlementCurrency, TradeStatus  from MoneyMarket c, Accounts_clients a where a.CDS_Number=c.ClientNo and c.[" + mro + "]='" + cmbvalue.SelectedItem.Text.ToString + "'", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds1, "Accounts_Clients1")
        If (ds1.Tables("Accounts_Clients1").Rows.Count > 0) Then
            ASPxGridView1.DataSource = ds1
            ASPxGridView1.DataBind()

        End If
    End Sub

    Public Sub filtersload()
        Dim ds1 As New DataSet
        cmd = New SqlCommand("SELECT COLUMN_NAME  FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = N'MoneyMarket'", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds1, "Accounts_Clients1")
        If (ds1.Tables("Accounts_Clients1").Rows.Count > 0) Then
            cmbfilter.DataSource = ds1
            cmbfilter.TextField = "COLUMN_NAME"
            cmbfilter.DataBind()

        End If
    End Sub

    Public Sub getfiltervalues(columnname As String)
        Dim ds1 As New DataSet
        cmd = New SqlCommand("select distinct " + columnname + " as val from MoneyMarket", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds1, "Accounts_Clients1")
        If (ds1.Tables("Accounts_Clients1").Rows.Count > 0) Then
            cmbvalue.DataSource = ds1
            cmbvalue.TextField = "val"
            cmbvalue.DataBind()

        End If
    End Sub




    Protected Sub cmbfilter_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbfilter.SelectedIndexChanged
        Try
            getfiltervalues(cmbfilter.SelectedItem.Text)
        Catch ex As Exception

        End Try

    End Sub
    Protected Sub btnSaveContract1_Click(sender As Object, e As EventArgs) Handles btnSaveContract1.Click
        Try

            loaddata(cmbfilter.SelectedItem.Text)

        Catch ex As Exception
            msgbox("No data Available")
        End Try
    End Sub
End Class
