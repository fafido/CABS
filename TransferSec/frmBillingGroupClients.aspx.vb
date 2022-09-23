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
                getBillingGroups()
                getAssetManagers()
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
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
    Sub getBillingGroups()
        Using cn = New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("connpath"))
            Dim ds As New DataSet
            Dim cmd = New SqlCommand("select * from para_BillingGroups ORDER BY GroupName", cn)
            Dim adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "para_BillingGroups")
            If ds.Tables(0).Rows.Count > 0 Then
                cmbBillingGroup.DataSource = ds
                cmbBillingGroup.ValueField = "GroupName"
                cmbBillingGroup.TextField = "GroupName"
                cmbBillingGroup.DataBind()
            Else
                cmbBillingGroup.DataSource = Nothing
                cmbBillingGroup.DataBind()
            End If
        End Using
    End Sub
    Public Sub getNewInvoices()
        If cmbBillingGroup.Text <> "" Then
            Using cn = New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("connpath"))
                Dim ds As New DataSet
                Dim cmd = New SqlCommand(" SELECT * FROM BillingGroupClients A WHERE A.GroupName=@GroupName ORDER BY ClientName ", cn)
                cmd.CommandType = CommandType.Text
                cmd.Parameters.AddWithValue("@GroupName", cmbBillingGroup.Value)
                Dim adp = New SqlDataAdapter(cmd)
                adp.Fill(ds, "BillingGroupClients")
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
        If cmbBillingGroup.Text <> "" Then
            Using cn = New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("connpath"))
                Dim ds As New DataSet
                Dim cmd = New SqlCommand(" SELECT * FROM BillingGroupClients A WHERE A.GroupName=@GroupName ORDER BY ClientName ", cn)
                cmd.CommandType = CommandType.Text
                cmd.Parameters.AddWithValue("@GroupName", cmbBillingGroup.Value)
                Dim adp = New SqlDataAdapter(cmd)
                adp.Fill(ds, "BillingGroupClients")
                Return ds
            End Using
        End If
    End Function
    Protected Sub grdNewAccountsToBill_DataBinding(sender As Object, e As EventArgs) Handles grdNewAccountsToBill.DataBinding
        grdNewAccountsToBill.DataSource = getNewInvoicesFXN()
    End Sub
    Protected Sub cmbBillingGroup_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbBillingGroup.SelectedIndexChanged
        getNewInvoices()
    End Sub
    Protected Sub grdNewAccountsToBill_RowCommand(sender As Object, e As DevExpress.Web.ASPxGridView.ASPxGridViewRowCommandEventArgs) Handles grdNewAccountsToBill.RowCommand
        Dim myID As String = e.KeyValue.ToString
        If e.CommandArgs.CommandName = "Authorise" Then
            Try
                Using cn = New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("connpath"))
                    Using cmd As New SqlCommand("DELETE FROM BillingGroupClients WHERE ID='" & myID & "'", cn)
                        If cn.State = ConnectionState.Open Then cn.Close()
                        cn.Open()
                        cmd.ExecuteNonQuery()
                        cn.Close()
                    End Using
                End Using
                getNewInvoices()
                msgbox("Client Removed from group")
            Catch ex As Exception
                ErrorLogging.WriteLogFile(Session("Username"), "grdChargesCreated_RowCommand", ex.ToString)
            End Try
        End If
    End Sub
    Protected Sub cmbAssetManager_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbAssetManager.SelectedIndexChanged
        getAssetManagerClients()
        showOTPPopUp()
    End Sub
    Sub showOTPPopUp()
        ASPxPopupControl1.PopupHorizontalAlign = DevExpress.Web.ASPxClasses.PopupHorizontalAlign.WindowCenter
        ASPxPopupControl1.PopupVerticalAlign = DevExpress.Web.ASPxClasses.PopupVerticalAlign.WindowCenter
        ASPxPopupControl1.AllowDragging = True
        ASPxPopupControl1.ShowCloseButton = True
        ASPxPopupControl1.ShowOnPageLoad = True
        Page.MaintainScrollPositionOnPostBack = False
    End Sub
    Sub hidePopUP()
        ASPxPopupControl1.AllowDragging = False
        ASPxPopupControl1.ShowCloseButton = False
        ASPxPopupControl1.ShowOnPageLoad = False
    End Sub
    Public Sub getAssetManagerClients()
        If cmbAssetManager.Text <> "" Then
            Using cn = New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("connpath"))
                Dim ds As New DataSet
                Dim cmd = New SqlCommand(" select a.cds_number,case when a.AccountType IN ('C') THEN isnull(a.Surname,'') else isnull(forenames,'')+' '+isnull(surname,'') end as namess from accounts_clients a where a.CDS_Number in (select distinct b.ClientNo from Client_AssetManagers b where b.AssetManager=@AssetManager)  order by namess ", cn)
                cmd.CommandType = CommandType.Text
                cmd.Parameters.AddWithValue("@AssetManager", cmbAssetManager.Value)
                Dim adp = New SqlDataAdapter(cmd)
                adp.Fill(ds, "accounts_clients")
                If ds.Tables(0).Rows.Count > 0 Then
                    grdSelectFromGrid.DataSource = ds
                    grdSelectFromGrid.DataBind()
                Else
                    grdSelectFromGrid.DataSource = Nothing
                    grdSelectFromGrid.DataBind()
                End If
            End Using
        End If
    End Sub
    Function getAssetManagerClientsFXN() As DataSet
        If cmbAssetManager.Text <> "" Then
            Using cn = New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("connpath"))
                Dim ds As New DataSet
                Dim cmd = New SqlCommand(" select a.cds_number,case when a.AccountType IN ('C') THEN isnull(a.Surname,'') else isnull(forenames,'')+' '+isnull(surname,'') end as namess from accounts_clients a where a.CDS_Number in (select distinct b.ClientNo from Client_AssetManagers b where b.AssetManager=@AssetManager)  order by namess ", cn)
                cmd.CommandType = CommandType.Text
                cmd.Parameters.AddWithValue("@AssetManager", cmbAssetManager.Value)
                Dim adp = New SqlDataAdapter(cmd)
                adp.Fill(ds, "accounts_clients")
                Return ds
            End Using
        End If
    End Function
    Protected Sub grdSelectFromGrid_DataBinding(sender As Object, e As EventArgs) Handles grdSelectFromGrid.DataBinding
        grdSelectFromGrid.DataSource = getAssetManagerClientsFXN()
    End Sub
    Protected Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim myGridView As New ASPxGridView
        myGridView = grdSelectFromGrid
        Dim keys As List(Of Object) = myGridView.GetCurrentPageRowValues(New String() {"cds_number"})
        For Each key As Object In keys
            If TryCast(myGridView.FindRowCellTemplateControlByKey(key, TryCast(myGridView.Columns("Selec"), GridViewDataColumn), "chk1"), ASPxCheckBox).Checked = True Then
                Dim RecordID As String = "", HolerNames As String = ""
                RecordID = TryCast(myGridView.FindRowCellTemplateControlByKey(key, TryCast(myGridView.Columns("cds_number"), GridViewDataColumn), "lblID"), ASPxLabel).Text
                HolerNames = TryCast(myGridView.FindRowCellTemplateControlByKey(key, TryCast(myGridView.Columns("namess"), GridViewDataColumn), "lblHolder"), ASPxLabel).Text
                Dim stmnt As String = " "
                stmnt = stmnt & " IF NOT EXISTS (SELECT TOP 1 * FROM BillingGroupClients WHERE [ClientNo]=@ClientNo AND [AssetManager]=@AssetManager) BEGIN INSERT BillingGroupClients([ClientNo], [ClientName], [GroupName], [AssetManager], [AddedBy])VALUES(@ClientNo,@ClientName,@GroupName,@AssetManager,@AddedBy) END "
                Using cn = New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("connpath"))
                    Using cmd As New SqlCommand(stmnt, cn)
                        cmd.CommandType = CommandType.Text
                        cmd.CommandTimeout = 0
                        cmd.Parameters.AddWithValue("@ClientNo", RecordID)
                        cmd.Parameters.AddWithValue("@AddedBy", Session("Username"))
                        cmd.Parameters.AddWithValue("@ClientName", HolerNames)
                        cmd.Parameters.AddWithValue("@GroupName", cmbBillingGroup.Value)
                        cmd.Parameters.AddWithValue("@AssetManager", cmbAssetManager.Value)
                        If cn.State = ConnectionState.Open Then cn.Close()
                        cn.Open()
                        cmd.ExecuteNonQuery()
                        cn.Close()
                    End Using
                End Using
            End If
        Next
        getNewInvoices()
        hidePopUP()
        msgbox("Accounts added successfully")
    End Sub
    Protected Sub chkSelectAll_CheckedChanged(sender As Object, e As EventArgs) Handles chkSelectAll.CheckedChanged
        Dim myGridView As New ASPxGridView
        myGridView = grdSelectFromGrid
        If chkSelectAll.Checked = True Then
            Dim keys As List(Of Object) = myGridView.GetCurrentPageRowValues(New String() {"cds_number"})
            For Each key As Object In keys
                Dim chk As ASPxCheckBox = TryCast(myGridView.FindRowCellTemplateControlByKey(key, TryCast(myGridView.Columns("Selec"), GridViewDataColumn), "chk1"), ASPxCheckBox)
                chk.Checked = True
            Next
        Else
            Dim keys As List(Of Object) = myGridView.GetCurrentPageRowValues(New String() {"cds_number"})
            For Each key As Object In keys
                Dim chk As ASPxCheckBox = TryCast(myGridView.FindRowCellTemplateControlByKey(key, TryCast(myGridView.Columns("Selec"), GridViewDataColumn), "chk1"), ASPxCheckBox)
                chk.Checked = False
            Next
        End If
    End Sub
End Class
