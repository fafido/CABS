Imports Microsoft.VisualBasic

Public Class Trackchanges
    Dim constr As String = (System.Configuration.ConfigurationManager.AppSettings("connpath"))
    Dim cn As New SqlConnection(constr)
    Dim adp As SqlDataAdapter
    Dim cmd As SqlCommand
    Dim adp1 As SqlDataAdapter
    Dim cmd1 As SqlCommand
    Dim fromEdit As Boolean = False
    Public Function ChangesEquire(maintable As String, temptable As String, changedfieldname As String, changedfieldvalue As String) As String
        Dim changedfields As String = ""
        Dim ds As New DataSet
        Dim ds1 As New DataSet

        On Error Resume Next

        cmd = New SqlCommand("Select * from " & maintable & " where " & changedfieldname & " = '" & changedfieldvalue & "'", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "main")

        If (ds.Tables(0).Rows.Count = 1) Then
            For Each dc As DataColumn In ds.Tables(0).Columns

                cmd1 = New SqlCommand("Select Top 1 * from " & temptable & " where " & changedfieldname & " = '" & changedfieldvalue & "' order by ID Desc", cn)
                adp1 = New SqlDataAdapter(cmd1)
                adp1.Fill(ds1, "temp")

                For Each dc1 As DataColumn In ds1.Tables(0).Columns
                    If dc1.ColumnName = dc.ColumnName Then
                        If ds.Tables(0).Rows(0).Item(dc.ColumnName).ToString <> ds1.Tables(0).Rows(0).Item(dc1.ColumnName).ToString Then
                            changedfields = changedfields & dc.ColumnName & " changed from " & ds.Tables(0).Rows(0).Item(dc.ColumnName).ToString & " to " & ds1.Tables(0).Rows(0).Item(dc1.ColumnName).ToString & "-"
                        End If
                    End If

                Next
            Next
        ElseIf (ds.Tables(0).Rows.Count > 1) Then
            changedfields = "E01"
        Else
            changedfields = "E02"
        End If

        Return changedfields

    End Function
End Class
