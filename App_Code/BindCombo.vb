Imports System.Data.SqlClient
Imports Microsoft.VisualBasic
Imports System.Web.UI.Page
Imports System.Data
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System

Public Class BindCombo
    Dim cmd As SqlCommand
    Dim adp As SqlDataAdapter
    Dim cnstr As String = (System.Configuration.ConfigurationManager.AppSettings("connpath"))
    Dim cn As New SqlConnection(cnstr)
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
    Public Sub BindCombinedValCombo(ByVal tnam As String, ByVal fnam As String, ByVal code As String, ByVal cnam As DropDownList)
        Dim dss As New DataSet
        Dim i As Integer
        Try
            cn.Open()
            dss.Clear()
            cmd = New SqlCommand("select " & fnam & "," & code & " from " & tnam & " order by " & fnam, cn)
            cmd.Connection = cn
            adp = New SqlDataAdapter(cmd)
            adp.Fill(dss, tnam)
            For i = 0 To dss.Tables(0).Rows.Count - 1

                cnam.Items.Add(dss.Tables(0).Rows(i).Item(0).ToString & "    " & dss.Tables(0).Rows(i).Item(1).ToString)
                cnam.Items(i).Value = dss.Tables(0).Rows(i).Item(1).ToString
            Next
            'cnam.DataSource = dss.Tables(tnam)
            'cnam.DataValueField = fnam
            'cnam.DataMember = fnam
            ' cnam.DataBind()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        cn.Close()
    End Sub
    Public Sub bindBactchRefcombo(ByVal cmbname As DropDownList, ByVal fil As String)
        Dim dsss As New DataSet
        Try
            dsss.Clear()
            'cmd = New SqlCommand(" select batch_ref from batch_header where type = '" & fil & "' and status in ('C') ", cn)
            cmd = New SqlCommand(" select distinct batch_ref from batch_header,batchcertvari where batch_header.type = '" & fil & "' and batch_header.status in ('C') and batch_header.batch_ref=batchcertvari.batchref order by batch_header.batch_ref", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(dsss, "batch_header")
            cmbname.DataSource = dsss.Tables(0)
            cmbname.DataValueField = "batch_ref"
            cmbname.DataBind()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Public Sub bindBactchcombo(ByVal cmbname As DropDownList, ByVal fil As String)
        Dim dsss As New DataSet
        Try
            dsss.Clear()
            'cmd = New SqlCommand(" select batch_ref from batch_header where type = '" & fil & "' and status in ('C') ", cn)
            cmd = New SqlCommand(" select distinct batch_ref from batch_header where batch_header.type = '" & fil & "' and batch_header.status in ('C') order by batch_header.batch_ref", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(dsss, "batch_header")
            cmbname.DataSource = dsss.Tables(0)
            cmbname.DataValueField = "batch_ref"
            cmbname.DataBind()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Public Function checkcode(ByVal codeval As String, ByVal tblname As String, ByVal code As String) As Boolean
        Try
            Dim dscode As New DataSet
            cmd = New SqlCommand("select * from " & tblname & " where " & code & " ='" & codeval & "'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(dscode, tblname)
            If dscode.Tables(0).Rows.Count > 0 Then
                MsgBox(code & " already exists." & vbLf & "Enter Different " & code)
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function
    Public Shared Function AuditTrail(ByVal updateno As String, ByVal dateoftransfer As String, ByVal transferfrom As String, ByVal transferto As String, ByVal certfrom As String, ByVal cdfrom As String, ByVal certto As String, ByVal cdto As String, ByVal noofshares As String, ByVal trantype As String, ByVal tranby As String, ByVal batch_ref As Integer, ByVal company As String) As Integer
        Try
            Dim cmd As SqlCommand
            ' Dim adp As SqlDataAdapter
            Dim cnstr As String = (System.Configuration.ConfigurationManager.AppSettings("connpath"))
            Dim cn As New SqlConnection(cnstr)
            cmd = New SqlCommand("insert into TransferAudit (updateno, dateoftransfer ,transferfrom ,transferto ,certfrom,cdfrom,certto,cdto,noofshares , trantype , tranby,batch_ref,company ) values(" & updateno & ",'" & dateoftransfer & "','" & transferfrom & "','" & transferto & "'," & certfrom & "," & cdfrom & "," & certto & ", " & cdto & "," & noofshares & ",'" & trantype & "','" & tranby & "'," & batch_ref & ",'" & company & "')", cn)
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return 0
    End Function
    'Public Shared Function AuditTrailtran(ByVal updateno As String, ByVal dateoftransfer As String, ByVal transferfrom As String, ByVal transferto As String, ByVal certfrom As String, ByVal certto As String, ByVal noofshares As String, ByVal trantype As String, ByVal tranby As String, ByVal trnwho As String, ByVal batch_ref As Integer, ByVal company As String) As Integer
    Public Shared Function AuditTrailtran(ByVal updateno As String, ByVal dateoftransfer As String, ByVal transferfrom As String, ByVal transferto As String, ByVal certfrom As String, ByVal cdfrom As String, ByVal certto As String, ByVal cdto As String, ByVal noofshares As String, ByVal trantype As String, ByVal tranby As String, ByVal trnwho As String, ByVal batch_ref As Integer, ByVal company As String) As Integer
        Try
            Dim cmd As SqlCommand
            ' Dim adp As SqlDataAdapter
            Dim cnstr As String = (System.Configuration.ConfigurationManager.AppSettings("connpath"))
            Dim cn As New SqlConnection(cnstr)
            cmd = New SqlCommand("insert into TransferAudit(updateno, dateoftransfer ,transferfrom ,transferto ,certfrom, cdfrom ,certto,cdto ,noofshares , trantype , tranby,tranfrom,batch_ref,company) values(" & updateno & ",'" & dateoftransfer & "','" & transferfrom & "','" & transferto & "'," & certfrom & ", " & cdfrom & "," & certto & "," & cdto & "," & noofshares & ",'" & trantype & "','" & tranby & "','" & trnwho & "'," & batch_ref & ",'" & company & "')", cn)
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return 0
    End Function
    'Public Function CheckCert(ByVal cert As Double, ByVal company As String) As Boolean
    Public Function CheckCert(ByVal cert As Double, ByVal company As String) As Boolean
        Try
            Dim cmd As SqlCommand
            Dim dscode As New DataSet
            ' Dim adp As SqlDataAdapter
            Dim cnstr As String = (System.Configuration.ConfigurationManager.AppSettings("connpath"))
            Dim cn As New SqlConnection(cnstr)
            cmd = New SqlCommand("select * from masttemp where cert=" & cert & " and company='" & company & "' and shares <0 ", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(dscode, "masttemp")
            If dscode.Tables(0).Rows.Count > 0 Then

                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function

End Class

