Imports Microsoft.VisualBasic
Imports System.Threading
Public Class HouseKeepingTasks
    Inherits System.Web.UI.Page
    Dim constr As String = (System.Configuration.ConfigurationManager.AppSettings("connpath"))
    Dim cn As New SqlConnection(constr)
    Dim cmd As SqlCommand
    Dim adp As SqlDataAdapter
    Public Delegate Sub DoWorkEventHandler(ByRef progress As Integer, ByRef _result As Object, ByVal arguments As Object())
    Public Event DoWork As DoWorkEventHandler
    Public Event PerformTask()
    Private _innerThread As Thread = Nothing

    Private _arguments As Object() = Nothing
    Public ReadOnly Property Progress() As Integer
        Get
            Return _progress
        End Get
    End Property
    Private _progress As Integer = 0
    Private _result As Object = Nothing


    ''' <summary>
    ''' A object that you can use it to save the result of the operation.
    ''' </summary>
    Public ReadOnly Property Result() As Object
        Get
            Return _result
        End Get
    End Property
    Public Sub RunWorker(ByVal arguments As Object())
        _arguments = arguments
        _innerThread = New Thread(AddressOf Worker)
        _innerThread.Start()
    End Sub
    Private Sub Worker()
        _progress = 0
        RaiseEvent DoWork(_progress, _result, _arguments)
        _progress = 100
    End Sub

    Public Function GetMaturedRec()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select * from tbl_SettlementSummary where settlement_date >='" & Now.Date & "'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "tbl_SettlementSummary")
            If (ds.Tables(0).Rows.Count > 0) Then
                Dim i As Integer = 0
                For i = 0 To ds.Tables(0).Rows.Count - 1
                    If (ds.Tables(0).Rows(i).Item("OrderType").ToString = "S") Then
                        cmd = New SqlCommand("insert into trans (company, cd_number, date_created, shares, update_type, created_by, batch_ref, source, pledge_shares) values ('OMZIL','" & ds.Tables(0).Rows(i).Item("cds_number").ToString & "','" & Now.Date & "'," & CInt(ds.Tables(0).Rows(i).Item("Amount_due").ToString) * -1 & ",'DEAL','SETTLEMT',0,'D',0)", cn)
                        If (cn.State = ConnectionState.Open) Then
                            cn.Close()
                        End If
                        cn.Open()
                        cmd.ExecuteNonQuery()
                        cn.Close()
                    End If
                    If (ds.Tables(0).Rows(i).Item("OrderType").ToString = "B") Then
                        cmd = New SqlCommand("insert into trans (company, cd_number, date_created, shares, update_type, created_by, batch_ref, source, pledge_shares) values ('OMZIL','" & ds.Tables(0).Rows(i).Item("cds_number").ToString & "','" & Now.Date & "'," & CInt(ds.Tables(0).Rows(i).Item("Amount_due").ToString) & ",'DEAL','SETTLEMT',0,'D',0)", cn)
                        If (cn.State = ConnectionState.Open) Then
                            cn.Close()
                        End If
                        cn.Open()
                        cmd.ExecuteNonQuery()
                        cn.Close()
                    End If

                    cmd = New SqlCommand("update tbl_SettlementSummary set status_flag='C' where deal_reference='" & ds.Tables(0).Rows(i).Item("deal_reference").ToString & "'", cn)
                    If (cn.State = ConnectionState.Open) Then
                        cn.Close()
                    End If
                    cn.Open()
                    cmd.ExecuteNonQuery()
                    cn.Close()

                Next
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function
End Class
