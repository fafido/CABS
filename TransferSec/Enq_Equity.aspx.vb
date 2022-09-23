Imports System.Net.Mail
Imports System.IO
Imports System
Imports System.Configuration
Imports System.Web
Imports System.Web.Security
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Collections.Generic
Imports DevExpress.Web.ASPxEditors
Imports DevExpress.Web.ASPxGridView

Partial Class TransferSec_Enq_Equity
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

            If Session("finish") = "true" Then
                Session("finish") = ""
                msgbox("Columns saved, you can re-print your report!")
            End If
            If (Not IsPostBack) Then

                Try


                    filtersload()
                    filtersloadDate()
                    getcolumns()


                Catch ex As Exception

                End Try

            End If

        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Function qry() As String
        Dim ds1 As New DataSet
        cmd = New SqlCommand("select * from custodian_trades_report where ReportName='Custodian_Trades'", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds1, "Accounts_Clients1")
        If (ds1.Tables("Accounts_Clients1").Rows.Count > 0) Then
            Dim constructer As String = ""
            For i As Integer = 0 To ds1.Tables("Accounts_Clients1").Rows.Count - 1
                constructer &= "[" + ds1.Tables("Accounts_Clients1").Rows(i).Item("report_column").ToString + "],"
            Next
            Return constructer.Substring(0, constructer.Length - 1)

        End If
    End Function

    Public Sub loaddata(mro As String)
        If cmbvalue.SelectedItem.Value.ToString = "ALL" Then
            Dim ds1 As New DataSet
            cmd = New SqlCommand("  select " + qry() + "  from vw_Custodian_Trades  where  convert(date, " + cmbdatetype.SelectedItem.Text + ")<='" + dtto.Date + "'  and  convert(date, " + cmbdatetype.SelectedItem.Text + ")>='" + dtfrom.Date + "'", cn)


            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds1, "Accounts_Clients1")

            ASPxGridView1.Caption = "Equity Trades from " + cmbdatetype.SelectedItem.Text + " " + dtfrom.Date.ToString("dd MMM yyyy") + " to " + cmbdatetype.SelectedItem.Text + " " + dtto.Date.ToString("dd MMM yyyy") + ""
            If (ds1.Tables("Accounts_Clients1").Rows.Count > 0) Then

                ASPxGridView1.DataSource = ds1
                ASPxGridView1.DataBind()
            Else
                ASPxGridView1.DataSource = Nothing
                ASPxGridView1.DataBind()

            End If
        Else

            Dim ds1 As New DataSet
            cmd = New SqlCommand("  select " + qry() + "  from vw_Custodian_Trades  where [" + mro + "]='" + cmbvalue.SelectedItem.Text.ToString + "' and convert(date, " + cmbdatetype.SelectedItem.Text + ")<='" + dtto.Date + "'  and  convert(date, " + cmbdatetype.SelectedItem.Text + ")>='" + dtfrom.Date + "'", cn)


            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds1, "Accounts_Clients1")
            If (ds1.Tables("Accounts_Clients1").Rows.Count > 0) Then
                ASPxGridView1.DataSource = ds1
                ASPxGridView1.DataBind()
            Else
                ASPxGridView1.DataSource = Nothing
                ASPxGridView1.DataBind()

            End If
        End If

    End Sub

    Public Function datas(mro As String) As DataSet
        If cmbvalue.SelectedItem.Value.ToString = "ALL" Then
            Dim ds1 As New DataSet
            cmd = New SqlCommand("  select " + qry() + "  from vw_Custodian_Trades  where  convert(date, " + cmbdatetype.SelectedItem.Text + ")<='" + dtto.Date + "'  and  convert(date, " + cmbdatetype.SelectedItem.Text + ")>='" + dtfrom.Date + "'", cn)


            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds1, "Accounts_Clients1")
            If (ds1.Tables("Accounts_Clients1").Rows.Count > 0) Then
                Return ds1

            Else
                Return Nothing


            End If
        Else

            Dim ds1 As New DataSet
            cmd = New SqlCommand("  select " + qry() + "  from vw_Custodian_Trades  where [" + mro + "]='" + cmbvalue.SelectedItem.Text.ToString + "' and convert(date, " + cmbdatetype.SelectedItem.Text + ")<='" + dtto.Date + "'  and  convert(date, " + cmbdatetype.SelectedItem.Text + ")>='" + dtfrom.Date + "'", cn)


            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds1, "Accounts_Clients1")
            If (ds1.Tables("Accounts_Clients1").Rows.Count > 0) Then
                Return ds1

            Else
                Return Nothing


            End If
        End If

    End Function
    Public Sub addcols(col As String)
        cmd = New SqlCommand("insert into Custodian_Trades_Report (report_column, ReportName ) values ('" + col + "','Custodian_Trades')", cn)
        If (cn.State = ConnectionState.Open) Then
            cn.Close()
        End If
        cn.Open()
        cmd.ExecuteNonQuery()
        cn.Close()
    End Sub
    Public Sub deletecol(col As String)
        cmd = New SqlCommand("delete Custodian_Trades_Report where reportname='Custodian_Trades'", cn)
        If (cn.State = ConnectionState.Open) Then
            cn.Close()
        End If
        cn.Open()
        cmd.ExecuteNonQuery()
        cn.Close()
    End Sub

    Public Sub filtersload()
        Dim ds1 As New DataSet
        cmd = New SqlCommand("SELECT * FROM (select 1 AS NR, 'ALL' as COLUMN_NAME UNION SELECT 2 AS NR, COLUMN_NAME   FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = N'vw_Custodian_Trades' AND DATA_TYPE not like '%date%') j order by j.NR", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds1, "Accounts_Clients1")
        If (ds1.Tables("Accounts_Clients1").Rows.Count > 0) Then
            cmbfilter.DataSource = ds1
            cmbfilter.TextField = "COLUMN_NAME"
            cmbfilter.DataBind()

        End If
    End Sub
    Public Sub filtersloadDate()
        Dim ds1 As New DataSet
        cmd = New SqlCommand("SELECT COLUMN_NAME   FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = N'vw_Custodian_Trades' AND DATA_TYPE like '%date%'", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds1, "Accounts_Clients1")
        If (ds1.Tables("Accounts_Clients1").Rows.Count > 0) Then
            cmbdatetype.DataSource = ds1
            cmbdatetype.TextField = "COLUMN_NAME"
            cmbdatetype.DataBind()

        End If
    End Sub

    Public Sub getfiltervalues(columnname As String)
        Dim ds1 As New DataSet
        cmd = New SqlCommand("select distinct " + columnname + " as val from vw_Custodian_Trades", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds1, "Accounts_Clients1")
        If (ds1.Tables("Accounts_Clients1").Rows.Count > 0) Then
            cmbvalue.DataSource = ds1
            cmbvalue.TextField = "val"
            cmbvalue.DataBind()

        End If
    End Sub
    Public Sub getcolumns()
        Dim ds1 As New DataSet
        cmd = New SqlCommand("  SELECT s.COLUMN_NAME as report_column, case when (select count(*) from Custodian_Trades_Report where ReportName='Custodian_Trades' and report_column=s.COLUMN_NAME)=0 then 'False' else 'True' end as chk   FROM INFORMATION_SCHEMA.COLUMNS s WHERE s.TABLE_NAME = N'vw_Custodian_Trades'", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds1, "Accounts_Clients1")
        If (ds1.Tables("Accounts_Clients1").Rows.Count > 0) Then
            grdcols.DataSource = ds1
            grdcols.DataBind()

        End If
    End Sub




    Protected Sub cmbfilter_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbfilter.SelectedIndexChanged
        Try

            If cmbfilter.SelectedItem.Value.ToString = "ALL" Then
                cmbvalue.Items.Add("ALL")
                cmbvalue.Value = "ALL"
            Else
                getfiltervalues(cmbfilter.SelectedItem.Text)
            End If

        Catch ex As Exception

        End Try

    End Sub
    Protected Sub btnSaveContract1_Click(sender As Object, e As EventArgs) Handles btnSaveContract1.Click
        Try

            ASPxGridView1.DataSource = Nothing
        ASPxGridView1.DataBind()

        loaddata(cmbfilter.SelectedItem.Text)

        Catch ex As Exception
            msgbox("No Data Available")
        End Try

    End Sub

    Private Sub ASPxGridView1_DataBinding(sender As Object, e As EventArgs) Handles ASPxGridView1.DataBinding
        ASPxGridView1.DataSource = datas(cmbfilter.SelectedItem.Text)

    End Sub
    Protected Sub btnSaveContract2_Click(sender As Object, e As EventArgs) Handles btnSaveContract2.Click
        Try


            loaddata(cmbfilter.SelectedItem.Text)
            If cmbexport.SelectedItem.Text = "EXCEL" Then
                ASPxGridViewExporter1.WriteXlsToResponse()
            ElseIf cmbexport.SelectedItem.Text = "PDF" Then
                ASPxGridViewExporter1.WritePdfToResponse()
            ElseIf cmbexport.SelectedItem.Text = "RTF" Then
                ASPxGridViewExporter1.WriteRtfToResponse()
            ElseIf cmbexport.SelectedItem.Text = "CSV" Then
                ASPxGridViewExporter1.WriteCsvToResponse()
            End If

        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Protected Sub btnSaveContract3_Click(sender As Object, e As EventArgs) Handles btnSaveContract3.Click

        ASPxPopupControl1.AllowDragging = True
        ASPxPopupControl1.ShowCloseButton = True
        ASPxPopupControl1.ShowOnPageLoad = True
        ASPxPopupControl1.PopupHorizontalAlign = DevExpress.Web.ASPxClasses.PopupHorizontalAlign.WindowCenter
        ASPxPopupControl1.PopupVerticalAlign = DevExpress.Web.ASPxClasses.PopupVerticalAlign.WindowCenter

        Page.MaintainScrollPositionOnPostBack = True
    End Sub
    Protected Sub btnSaveContract4_Click(sender As Object, e As EventArgs) Handles btnSaveContract4.Click

        deletecol("")
        Dim keys As List(Of Object) = grdcols.GetCurrentPageRowValues(New String() {"report_column"})

        For Each key As Object In keys
            Dim chk As ASPxCheckBox = TryCast(grdcols.FindRowCellTemplateControlByKey(key, TryCast(grdcols.Columns("Selec"), GridViewDataColumn), "chk1"), ASPxCheckBox)

            Dim check As Boolean = chk.Checked
            If check = True Then

                addcols(key)
            End If

        Next
        Session("finish") = "true"
        Response.Redirect(Request.RawUrl)
    End Sub
End Class
