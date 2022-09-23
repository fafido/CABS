Imports System.Data
Imports System.Data.SqlClient
Imports System.Net

Partial Class Credit_viewDocument
    Inherits System.Web.UI.Page
    Dim adp As SqlDataAdapter
    Dim cmd As SqlCommand
    Dim con As New SqlConnection
    Dim connection As String

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Page.MaintainScrollPositionOnPostBack = True
        con = New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("connpath"))
        If Not IsPostBack Then
            Dim docID = Request.QueryString("id")
            cmd = New SqlCommand("Select * from [warehousedocuments] where id = '" & docID & "'", con)
            Dim ds As New DataSet
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "QD")
            Dim client As New WebClient()
            'Dim buffer As [Byte]() = client.DownloadData(ds.Tables(0).Rows(0).Item("DOC_DATA"))
            Dim buffer As [Byte]() = ds.Tables(0).Rows(0).Item("Data")

            If buffer IsNot Nothing Then
                'Response.ContentType = "application/pdf"
                Response.ContentType = ds.Tables(0).Rows(0).Item("ContentType")
                Response.AddHeader("content-length", buffer.Length.ToString())
                Response.BinaryWrite(buffer)
            End If
        End If
    End Sub
End Class