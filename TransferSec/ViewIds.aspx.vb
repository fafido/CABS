Imports System.Data
Imports System.Data.SqlClient

Partial Class TransferSec_ViewDocument
    Inherits System.Web.UI.Page
    Dim cmd As SqlCommand
    Dim adp As SqlDataAdapter
    'Dim con As New SqlConnection
    Dim connection As String
    Dim constr As String = (System.Configuration.ConfigurationManager.AppSettings("connpath"))
    Dim con As New SqlConnection(constr)

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Page.MaintainScrollPositionOnPostBack = True
        'con = New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
        If Not IsPostBack Then
            Dim docID = Request.QueryString("data")
            cmd = New SqlCommand("Select Data,concat('NationalId',ContentType) as MIMEType from [CDS_ROUTER].[dbo].[Accounts_Documents] where doc_generated = '" & docID & "'", con)
            Dim ds As New DataSet
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "AA")
            If ds.Tables(0).Rows.Count > 0 Then
                'Dim client As New WebClient()
                'Dim buffer As [Byte]() = client.DownloadData(ds.Tables(0).Rows(0).Item("DOC_DATA"))
                'msgbox(docID)
                Dim buffer As [Byte]() = ds.Tables(0).Rows(0).Item("Data")

                If buffer IsNot Nothing Then
                    Try
                        Response.ContentType = ds.Tables(0).Rows(0).Item("MIMEType")
                    Catch ex As Exception
                        Response.ContentType = "application/pdf"
                    End Try
                    Response.AddHeader("content-length", buffer.Length.ToString())
                    Response.BinaryWrite(buffer)
                End If
            End If
        End If
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
End Class
