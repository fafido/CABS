Imports Microsoft.VisualBasic
Imports System
Imports System.Web.UI
Imports DevExpress.Web.ASPxEditors
Imports DevExpress.XtraReports.Web
Partial Class Enquiries_AccountStatementReport
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
            If (Not IsPostBack) Then
                checkSessionState()

            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Protected Sub DocumentViewer1_Load(ByVal sender As Object, ByVal e As EventArgs)
        AddHandler Me.DocumentViewer1.CustomizeParameterEditors, AddressOf CustomizeParameterEditors
    End Sub
    Private Sub CustomizeParameterEditors(ByVal sender As Object, ByVal e As CustomizeParameterEditorsEventArgs)
        If TypeOf e.Editor Is DevExpress.Web.ASPxEditors.ASPxSpinEdit Then
            Dim editor As ASPxSpinEdit = TryCast(e.Editor, ASPxSpinEdit)
            If editor Is Nothing Then
                Return
            End If
            Select Case e.Parameter.Name
                Case "OrderIdParameter"
                    SetSpinEditParametrs(editor, 10248, 11077)
                Case "MaxRowCountParameter"
                    SetSpinEditParametrs(editor, 1, Int32.MaxValue)
            End Select
            e.Editor = editor
        End If
    End Sub

    Private Sub SetSpinEditParametrs(ByVal editor As ASPxSpinEdit, ByVal minValue As Integer, ByVal maxValue As Integer)
        editor.MinValue = minValue
        editor.MaxValue = maxValue
        editor.AllowNull = False
    End Sub

    Public Sub ClearData()
        Try
            txtClientNo.Text = ""
            txtTitle.Text = ""
            txtIDno.Text = ""
            txtForenames.Text = ""
            txtSurname.Text = ""
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Protected Sub ASPxButton2_Click(sender As Object, e As EventArgs) Handles ASPxButton2.Click
        Try
            If (txtClientNameSearch.Text <> "") Then
                Dim ds As New DataSet
                cmd = New SqlCommand("select cds_number+' '+surname+' '+forenames as namess from Accounts_Clients where surname like '" & txtClientNameSearch.Text & "%'", cn)
                adp = New SqlDataAdapter(cmd)
                adp.Fill(ds, "Accounts_Clients")
                If (ds.Tables(0).Rows.Count > 0) Then
                    lstNamesSearch.DataSource = ds.Tables(0)
                    lstNamesSearch.TextField = "namess"
                    lstNamesSearch.ValueField = "namess"
                    lstNamesSearch.DataBind()
                Else
                    lstNamesSearch.Items.Clear()
                End If
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub lstNamesSearch_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstNamesSearch.SelectedIndexChanged
        Try
            If (lstNamesSearch.Items.Count > 0) Then
                Dim ds As New DataSet
                cmd = New SqlCommand("select * from Accounts_Clients where cds_number+' '+surname+' '+forenames = '" & lstNamesSearch.SelectedItem.Text & "'", cn)
                adp = New SqlDataAdapter(cmd)
                adp.Fill(ds, "Accounts_Clients")
                If (ds.Tables(0).Rows.Count > 0) Then
                    txtClientNo.Text = ds.Tables(0).Rows(0).Item("cds_number").ToString.ToUpper
                    txtTitle.Text = ds.Tables(0).Rows(0).Item("title").ToString.ToUpper
                    txtIDno.Text = ds.Tables(0).Rows(0).Item("idnopp").ToString.ToUpper
                    txtForenames.Text = ds.Tables(0).Rows(0).Item("forenames").ToString.ToUpper
                    txtSurname.Text = ds.Tables(0).Rows(0).Item("surname").ToString.ToUpper

                Else
                    txtClientNo.Text = ""
                    txtTitle.Text = ""
                    txtIDno.Text = ""
                    txtForenames.Text = ""
                    txtSurname.Text = ""
                End If
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
End Class
