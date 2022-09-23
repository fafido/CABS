Imports System.Net.Mail
Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Imports System
Imports System.Configuration
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls
Imports System.Web.Services
Imports System.Collections.Generic
Imports DevExpress.Web.ASPxEditors
Imports DevExpress.Web.ASPxGridView

Partial Class Corp_InvoiceMultiple
    Inherits System.Web.UI.Page
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
                getAssetManagers()
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Protected Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        saveDATA()
    End Sub
    Sub getAssetManagers()
        Using cn = New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("connpath"))
            Dim ds As New DataSet
            Dim cmd = New SqlCommand("SELECT * FROM para_assetManager ORDER BY AssetMananger", cn)
            Dim adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "para_assetManager")
            If ds.Tables(0).Rows.Count > 0 Then
                cmbAssetManager.DataSource = ds
                cmbAssetManager.ValueField = "AssetManagerCode"
                cmbAssetManager.TextField = "AssetMananger"
                cmbAssetManager.DataBind()
            Else
                cmbAssetManager.DataSource = Nothing
                cmbAssetManager.DataBind()
            End If
        End Using
    End Sub
    Public Sub getNewInvoices()
        If cmbAssetManager.Text <> "" Then
            Using cn = New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("connpath"))
                Dim ds As New DataSet
                Dim cmd = New SqlCommand(" SELECT *, FORMAT(DateBilled,'dd MMM yyyy HH:mm','en-us') as DateCreated1,FORMAT(DateFrom,'dd MMM yyyy','en-us') as DateFrom1,FORMAT(DateTo,'dd MMM yyyy','en-us') as DateTo1, CASE Posted when 0 then 'New' when 1 then 'Authorised' when 2 then 'Rejected' end as status FROM ClientInvoices WHERE AssetManager=@AssetManager AND ISNULL(POSTED,0)=0 order by id ", cn)
                cmd.CommandType = CommandType.Text
                cmd.Parameters.AddWithValue("@AssetManager", cmbAssetManager.Value)
                Dim adp = New SqlDataAdapter(cmd)
                adp.Fill(ds, "ClientInvoices")
                If ds.Tables(0).Rows.Count > 0 Then
                    grdNewAccountsToBill.DataSource = ds
                    grdNewAccountsToBill.DataBind()
                Else
                    grdNewAccountsToBill.DataSource = Nothing
                    grdNewAccountsToBill.DataBind()
                End If
            End Using
        End If
    End Sub
    Function getNewInvoicesFXN() As DataSet
        If cmbAssetManager.Text <> "" Then
            Using cn = New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("connpath"))
                Dim ds As New DataSet
                Dim cmd = New SqlCommand(" SELECT *, FORMAT(DateBilled,'dd MMM yyyy HH:mm','en-us') as DateCreated1,FORMAT(DateFrom,'dd MMM yyyy','en-us') as DateFrom1,FORMAT(DateTo,'dd MMM yyyy','en-us') as DateTo1, CASE Posted when 0 then 'New' when 1 then 'Authorised' when 2 then 'Rejected' end as status FROM ClientInvoices WHERE AssetManager=@AssetManager AND ISNULL(POSTED,0)=0 order by id ", cn)
                cmd.CommandType = CommandType.Text
                cmd.Parameters.AddWithValue("@AssetManager", cmbAssetManager.Value)
                Dim adp = New SqlDataAdapter(cmd)
                adp.Fill(ds, "ClientInvoices")
                Return ds
            End Using
        End If
    End Function
    Protected Sub grdNewAccountsToBill_DataBinding(sender As Object, e As EventArgs) Handles grdNewAccountsToBill.DataBinding
        grdNewAccountsToBill.DataSource = getNewInvoicesFXN()
    End Sub
    Protected Sub chkSelectAll_CheckedChanged(sender As Object, e As EventArgs) Handles chkSelectAll.CheckedChanged
        Dim myGridView As New ASPxGridView
        myGridView = grdNewAccountsToBill
        If chkSelectAll.Checked = True Then
            Dim keys As List(Of Object) = myGridView.GetCurrentPageRowValues(New String() {"ID"})
            For Each key As Object In keys
                Dim chk As ASPxCheckBox = TryCast(myGridView.FindRowCellTemplateControlByKey(key, TryCast(myGridView.Columns("Selec"), GridViewDataColumn), "chk1"), ASPxCheckBox)
                chk.Checked = True
            Next
        Else
            Dim keys As List(Of Object) = myGridView.GetCurrentPageRowValues(New String() {"ID"})
            For Each key As Object In keys
                Dim chk As ASPxCheckBox = TryCast(myGridView.FindRowCellTemplateControlByKey(key, TryCast(myGridView.Columns("Selec"), GridViewDataColumn), "chk1"), ASPxCheckBox)
                chk.Checked = False
            Next
        End If
    End Sub
    Sub saveDATA()
        Dim myGridView As New ASPxGridView
        myGridView = grdNewAccountsToBill
        Dim keys As List(Of Object) = myGridView.GetCurrentPageRowValues(New String() {"ID"})
        For Each key As Object In keys
            If TryCast(myGridView.FindRowCellTemplateControlByKey(key, TryCast(myGridView.Columns("Selec"), GridViewDataColumn), "chk1"), ASPxCheckBox).Checked = True Then
                Dim RecordID As String = ""
                RecordID = TryCast(myGridView.FindRowCellTemplateControlByKey(key, TryCast(myGridView.Columns("ID"), GridViewDataColumn), "lblID"), ASPxLabel).Text
                Dim stmnt As String = " "
                stmnt = stmnt & " UPDATE [ClientInvoices] set Posted=1,AuthBy=@AuthBy,AuthDate=Getdate() WHERE ID=@RecordID "
                Using cn = New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("connpath"))
                    Using cmd As New SqlCommand(stmnt, cn)
                        cmd.CommandType = CommandType.Text
                        cmd.CommandTimeout = 0
                        cmd.Parameters.AddWithValue("@RecordID", RecordID)
                        cmd.Parameters.AddWithValue("@AuthBy", Session("Username"))
                        If cn.State = ConnectionState.Open Then cn.Close()
                        cn.Open()
                        cmd.ExecuteNonQuery()
                        cn.Close()
                    End Using
                End Using
            End If
        Next
        getNewInvoices()
        msgbox("Invoice/s Authorized successfully")
    End Sub
    Protected Sub grdNewAccountsToBill_RowCommand(sender As Object, e As DevExpress.Web.ASPxGridView.ASPxGridViewRowCommandEventArgs) Handles grdNewAccountsToBill.RowCommand
        Dim myID As String = e.KeyValue.ToString
        If e.CommandArgs.CommandName = "Select" Then
            Dim strscript As String
            strscript = "<script langauage=JavaScript>"
            strscript += "window.open('frmInvoiceReport.aspx?keyid=" & myID & "');"
            strscript += "</script>"
            ClientScript.RegisterStartupScript(Me.GetType(), "newwin", strscript)
        ElseIf e.CommandArgs.CommandName = "Authorise" Then
            Try
                If TransactionOriginisMySession(myID) = True Then
                    msgbox("Cannot Authorise/Reject own Transaction")
                    Exit Sub
                End If
                If InvoiceAlreadyActioned(myID) = True Then
                    msgbox("Invoice Already Authorised/Rejected")
                    Exit Sub
                End If
                Using cn = New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("connpath"))
                    Using cmd As New SqlCommand("UPDATE [ClientInvoices] set Posted=1,AuthBy=@AuthBy,AuthDate=Getdate() WHERE ID='" & myID & "'", cn)
                        cmd.Parameters.AddWithValue("@AuthBy", Session("Username"))
                        If cn.State = ConnectionState.Open Then cn.Close()
                        cn.Open()
                        cmd.ExecuteNonQuery()
                        cn.Close()
                    End Using
                End Using
                getNewInvoices()
                msgbox("Invoice Authorised successfully")
            Catch ex As Exception
                ErrorLogging.WriteLogFile(Session("Username"), "grdNewAccountsToBill_RowCommand", ex.ToString)
            End Try
        ElseIf e.CommandArgs.CommandName = "Reject" Then
            Try
                If TransactionOriginisMySession(myID) = True Then
                    msgbox("Cannot Authorise/Reject own Transaction")
                    Exit Sub
                End If
                If InvoiceAlreadyActioned(myID) = True Then
                    msgbox("Invoice Already Authorised/Rejected")
                    Exit Sub
                End If
                Using cn = New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("connpath"))
                    Using cmd As New SqlCommand("UPDATE [ClientInvoices] set Posted=2,AuthBy=@AuthBy,AuthDate=Getdate() WHERE ID='" & myID & "'", cn)
                        cmd.Parameters.AddWithValue("@AuthBy", Session("Username"))
                        If cn.State = ConnectionState.Open Then cn.Close()
                        cn.Open()
                        cmd.ExecuteNonQuery()
                        cn.Close()
                    End Using
                End Using
                getNewInvoices()
                msgbox("Invoice has been rejected")
            Catch ex As Exception
                ErrorLogging.WriteLogFile(Session("Username"), "grdNewAccountsToBill_RowCommand", ex.ToString)
            End Try
        End If
    End Sub
    Private Function TransactionOriginisMySession(ByVal myIDD As String) As Boolean
        Using cn = New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("connpath"))
            Dim ds As New DataSet
            Dim cmd = New SqlCommand("SELECT * FROM ClientInvoices WHERE ID='" & myIDD & "'  ", cn)
            cmd.CommandType = CommandType.Text
            Dim adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "ClientInvoices")
            If ds.Tables(0).Rows.Count > 0 Then
                If ds.Tables(0).Rows(0).Item("BilledBy").ToString = Session("Username") Then
                    Return True
                Else
                    Return False
                End If
            Else
                Return True
            End If
        End Using
    End Function
    Private Function InvoiceAlreadyActioned(ByVal myIDD As String) As Boolean
        Using cn = New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("connpath"))
            Dim ds As New DataSet
            Dim cmd = New SqlCommand("SELECT *,CASE Posted when 0 then 'New' when 1 then 'Authorised' when 2 then 'Rejected' end as status FROM ClientInvoices WHERE ID='" & myIDD & "'  ", cn)
            cmd.CommandType = CommandType.Text
            Dim adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "ClientInvoices")
            If ds.Tables(0).Rows.Count > 0 Then
                If ds.Tables(0).Rows(0).Item("status").ToString <> "New" Then
                    Return True
                Else
                    Return False
                End If
            Else
                Return True
            End If
        End Using
    End Function
    Protected Sub cmbAssetManager_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbAssetManager.SelectedIndexChanged
        getNewInvoices()
    End Sub
    Protected Sub btnDiscard_Click(sender As Object, e As EventArgs) Handles btnDiscard.Click
        RejectTrxn()
    End Sub
    Sub RejectTrxn()
        Dim myGridView As New ASPxGridView
        myGridView = grdNewAccountsToBill
        Dim keys As List(Of Object) = myGridView.GetCurrentPageRowValues(New String() {"ID"})
        For Each key As Object In keys
            If TryCast(myGridView.FindRowCellTemplateControlByKey(key, TryCast(myGridView.Columns("Selec"), GridViewDataColumn), "chk1"), ASPxCheckBox).Checked = True Then
                Dim RecordID As String = ""
                RecordID = TryCast(myGridView.FindRowCellTemplateControlByKey(key, TryCast(myGridView.Columns("ID"), GridViewDataColumn), "lblID"), ASPxLabel).Text
                Dim stmnt As String = " "
                stmnt = stmnt & " UPDATE [ClientInvoices] set Posted=2,AuthBy=@AuthBy,AuthDate=Getdate() WHERE ID=@RecordID "
                Using cn = New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("connpath"))
                    Using cmd As New SqlCommand(stmnt, cn)
                        cmd.CommandType = CommandType.Text
                        cmd.CommandTimeout = 0
                        cmd.Parameters.AddWithValue("@RecordID", RecordID)
                        cmd.Parameters.AddWithValue("@AuthBy", Session("Username"))
                        If cn.State = ConnectionState.Open Then cn.Close()
                        cn.Open()
                        cmd.ExecuteNonQuery()
                        cn.Close()
                    End Using
                End Using
            End If
        Next
        getNewInvoices()
        msgbox("Invoice/s have been rejected")
    End Sub
End Class
