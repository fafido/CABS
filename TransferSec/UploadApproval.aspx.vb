Imports System.Collections.Generic
Imports DevExpress.Web.ASPxEditors
Imports DevExpress.Web.ASPxGridView

Partial Class UploadApproval
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
            If (Not IsPostBack) = True Then
                checkSessionState()
                loadcomboforassetmanagers()


                getpending("", "")
            End If
            If Session("finish") = "yes" Then
                Session("finish") = ""
                msgbox("Successful")
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub loadcomboforassetmanagers()
        Dim dsport As New DataSet
        cmd = New SqlCommand("select * from (select 1 as nr, AssetManagerCode as code, p.AssetMananger from  para_AssetManager p) j order by nr", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(dsport, "trans")
        If (dsport.Tables(0).Rows.Count > 0) Then

            cmbassetmanager0.DataSource = dsport
            cmbassetmanager0.TextField = "AssetMananger"
            cmbassetmanager0.ValueField = "code"
            cmbassetmanager0.DataBind()

        End If
    End Sub



    Public Function pending(assetmanager As String, dat As String) As DataSet

        Dim ds As New DataSet
        If assetmanager = "" And dat = "" Then
            cmd = New SqlCommand("select * from Recon_AssetManager_Approvals where [CurrentStatus]='Pending' ", cn)
        Else
            cmd = New SqlCommand("select * from Recon_AssetManager_Approvals where [CurrentStatus]='Pending' and convert(date, recondate)='" + dat + "' and AssetManager='" + assetmanager + "'", cn)
        End If


        '    cmd = New SqlCommand("select * from Recon_AssetManager_Approvals where [CurrentStatus]='Pending' and convert(date, recondate)='" + dat + "' and AssetManager='" + assetmanager + "' and CurrentStatus='Pending'", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "Accounts_Audit2")
        If (ds.Tables(0).Rows.Count > 0) Then
            Return ds

        Else
            Return Nothing

        End If
    End Function

    Public Sub getpending(assetmanager As String, dat As String)

        Dim ds As New DataSet
        If assetmanager = "" And dat = "" Then
            cmd = New SqlCommand("select * from Recon_AssetManager_Approvals where [CurrentStatus]='Pending' ", cn)
        Else
            cmd = New SqlCommand("select * from Recon_AssetManager_Approvals where [CurrentStatus]='Pending' and convert(date, recondate)='" + dat + "' and AssetManager='" + assetmanager + "' and CurrentStatus='Pending'", cn)
        End If

        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "Accounts_Audit2")
        If (ds.Tables(0).Rows.Count > 0) Then
            grddocuments.DataSource = ds

            grddocuments.DataBind()
        Else
            grddocuments.DataSource = Nothing

            grddocuments.DataBind()

        End If
    End Sub



    Protected Sub ASPxButton5_Click(sender As Object, e As EventArgs) Handles ASPxButton5.Click
        Dim keys As List(Of Object) = grddocuments.GetCurrentPageRowValues(New String() {"ID"})
        For Each key As Object In keys
            Dim chk As ASPxCheckBox = TryCast(grddocuments.FindRowCellTemplateControlByKey(key, TryCast(grddocuments.Columns("Selec"), GridViewDataColumn), "chk1"), ASPxCheckBox)

            Dim check As Boolean = chk.Checked
            If check = True Then
                approvetransaction(key.ToString)

            End If
        Next
        loadd()

        msgbox("Records Approved")

    End Sub
    Public Sub approvetransaction(transkey As String)
        Try

            cmd = New SqlCommand("UPDATE Recon_AssetManager_Approvals set [Currentstatus]='APPROVED', AuthorizedBy='" + Session("Username") + "', DateAuthorized= getdate() where   id='" + transkey + "' AND currentStatus='Pending'", cn)
            If (cn.State = ConnectionState.Open) Then
                cn.Close()
            End If
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()



        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub DECLINE(transkey As String)
        Try

            cmd = New SqlCommand("UPDATE Recon_AssetManager_Approvals set [Currentstatus]='REJECTED', AuthorizedBy='" + Session("Username") + "', DateAuthorized= getdate()  where  id='" + transkey + "' AND currentStatus='Pending'", cn)
            If (cn.State = ConnectionState.Open) Then
                cn.Close()
            End If
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()



        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Private Sub grddocuments_RowCommand(sender As Object, e As ASPxGridViewRowCommandEventArgs) Handles grddocuments.RowCommand
        Dim id As String = e.KeyValue.ToString
        If e.CommandArgs.CommandName.ToString = "Approve Transaction" Then
            approvetransaction(id)
            loadd()
            msgbox("Recon Record Successfully Approved")
            'msgbox(id)
        ElseIf e.CommandArgs.CommandName.ToString = "Decline Transaction" Then
            DECLINE(id)
            loadd()
            msgbox("Recon Record Declined")
        End If
    End Sub
    Protected Sub ASPxButton6_Click(sender As Object, e As EventArgs) Handles ASPxButton6.Click
        Dim keys As List(Of Object) = grddocuments.GetCurrentPageRowValues(New String() {"ID"})
        For Each key As Object In keys
            Dim chk As ASPxCheckBox = TryCast(grddocuments.FindRowCellTemplateControlByKey(key, TryCast(grddocuments.Columns("Selec"), GridViewDataColumn), "chk1"), ASPxCheckBox)

            Dim check As Boolean = chk.Checked
            If check = True Then
                DECLINE(key.ToString)

            End If
        Next
        loadd()
        msgbox("Records Rejected")



    End Sub

    Private Sub grddocuments_DataBinding(sender As Object, e As EventArgs) Handles grddocuments.DataBinding
        If cmbassetmanager0.SelectedIndex = -1 And dtdateview.Text = "" Then
            grddocuments.DataSource = pending("", "")
        Else
            grddocuments.DataSource = pending(cmbassetmanager0.SelectedItem.Value.ToString, dtdateview.Date.ToString)
        End If

    End Sub
    Public Sub loadd()
        If cmbassetmanager0.SelectedIndex = -1 And dtdateview.Text = "" Then
            getpending("", "")
        Else
            getpending(cmbassetmanager0.SelectedItem.Value.ToString, dtdateview.Date.ToString)
        End If
    End Sub
    Protected Sub ASPxButton7_Click(sender As Object, e As EventArgs) Handles ASPxButton7.Click

        getpending(cmbassetmanager0.SelectedItem.Value.ToString, dtdateview.Date.ToString)
        ' msgbox(cmbassetmanager0.SelectedItem.Value.ToString + " " + dtdateview.Date.ToString)
    End Sub
    Protected Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        Dim myGridView As New ASPxGridView
        myGridView = grddocuments
        If CheckBox1.Checked = True Then
            Dim keys As List(Of Object) = myGridView.GetCurrentPageRowValues(New String() {"ID"})
            For Each key As Object In keys
                Dim chk As ASPxCheckBox = TryCast(grddocuments.FindRowCellTemplateControlByKey(key, TryCast(grddocuments.Columns("Selec"), GridViewDataColumn), "chk1"), ASPxCheckBox)
                chk.Checked = True
            Next
        Else
            Dim keys As List(Of Object) = myGridView.GetCurrentPageRowValues(New String() {"ID"})
            For Each key As Object In keys
                Dim chk As ASPxCheckBox = TryCast(grddocuments.FindRowCellTemplateControlByKey(key, TryCast(grddocuments.Columns("Selec"), GridViewDataColumn), "chk1"), ASPxCheckBox)
                chk.Checked = False
            Next
        End If
    End Sub
End Class