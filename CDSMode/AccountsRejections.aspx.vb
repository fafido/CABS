Imports System.Data
Imports System.Data.SqlClient

Partial Class CDSMode_AccountsRejections
    Inherits System.Web.UI.Page

    Dim constr As String = (System.Configuration.ConfigurationManager.AppSettings("connpath"))
    Dim cn As New SqlConnection(constr)
    Dim cmd As SqlCommand
    Dim adp As SqlDataAdapter

    Protected Sub OnPageIndexChanging(sender As Object, e As GridViewPageEventArgs)
        grdvCharges.PageIndex = e.NewPageIndex
        FillGrid()
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


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Try
            Page.MaintainScrollPositionOnPostBack = True
            If (Not IsPostBack) Then
                FillGrid()
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try

    End Sub

    Public Sub FillGrid()
        Dim ds As New DataSet
        cmd = New SqlCommand("select Description,Sender,Date_inserted as [Date],Comment,Category from tbl_uncommitted where Status = '2'", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "tbl_uncommitted")

        If (ds.Tables(0).Rows.Count > 0) Then
            grdvCharges.DataSource = ds.Tables(0)
            grdvCharges.DataBind()
        Else
            'msgbox("not found")
        End If
    End Sub


End Class
