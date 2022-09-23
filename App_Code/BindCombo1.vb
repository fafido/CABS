Imports System.Web
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.ComponentModel
Imports System.Data.SqlClient
Imports Microsoft.VisualBasic
Imports System.Web.UI.Page
Imports System.Data
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System

Public Class BindCombo1
    Dim cmd As SqlCommand
    Dim adp As SqlDataAdapter
    Dim cnstr As String = (System.Configuration.ConfigurationManager.AppSettings("connpath"))
    Public cn As New SqlConnection(cnstr)
    Shared script As ClientScriptManager
    Public Sub BindCombo(ByVal tnam As String, ByVal fnam As String, ByVal cnam As DropDownList)
        Dim dss As New DataSet
        Try
            cn.Open()
            dss.Clear()
            cmd = New SqlCommand("select distinct(" & fnam & ") from " & tnam & " order by " & fnam, cn)
            cmd.Connection = cn
            adp = New SqlDataAdapter(cmd)
            adp.Fill(dss, tnam)
            cnam.DataSource = dss.Tables(tnam)
            cnam.DataValueField = fnam
            cnam.DataMember = fnam
            cnam.DataBind()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        cn.Close()
    End Sub


End Class
