Imports System.Data
Imports System.Data.SqlClient
Partial Class Trading_BrokerBatchCapturing
    Inherits System.Web.UI.Page
    Dim constr As String = (System.Configuration.ConfigurationManager.AppSettings("connpath"))
    Dim cn As New SqlConnection(constr)
    Dim cmd As SqlCommand
    Dim adp As SqlDataAdapter
    Dim maxbatchref As Integer
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Page.MaintainScrollPositionOnPostBack = True
        If (Not IsPostBack) Then
        End If
    End Sub
    Public Sub getmaxBatchref()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("Select max(batch_ref) as batch_ref from broker_batch_header", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "broker_batch_header")
            maxbatchref = ((ds.Tables(0).Rows(0).Item("batch_ref").ToString) + 1)
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
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
    Public Sub UpdateForwardingBatch()
        Try
            cmd = New SqlCommand("Update broker_batch_header set status='F' where batch_ref=" & lblBatchRef.Text & "", cn)
            If (cn.State = ConnectionState.Open) Then
                cn.Close()
            End If
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()

            cmd = New SqlCommand("Update broker_batch_ref set status='F' where batch_ref=" & lblBatchRef.Text & "", cn)
            If (cn.State = ConnectionState.Open) Then
                cn.Close()
            End If
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()

            SaveTSecBatch()
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub SaveTSecBatch()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select company,batch_ref,batch_type,Created_on,shares,Lodger,status from broker_batch_header where batch_ref=" & lblbatchref.Text & "", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "broker_batch_header")
            If (ds.Tables(0).Rows.Count > 0) Then
                'MsgBox("Begin Saving TSec Batch Header")
                cmd = New SqlCommand("insert into TSec_Batch_Header (Company,batch_ref,batch_type,batch_date,batch_total,batch_Broker,Batch_Forwarded_By,Batch_Forwarded_On,Status) values ('" & ds.Tables(0).Rows(0).Item("company").ToString & "'," & ds.Tables(0).Rows(0).Item("batch_ref").ToString & ",'" & ds.Tables(0).Rows(0).Item("Batch_type").ToString & "','" & ds.Tables(0).Rows(0).Item("Created_On").ToString & "'," & ds.Tables(0).Rows(0).Item("shares").ToString & ",'" & ds.Tables(0).Rows(0).Item("LODGER").ToString & "','" & Session("BrokerCode") & "','" & Date.Now & "','F')", cn)
                If (cn.State = ConnectionState.Open) Then
                    cn.Close()
                End If
                cn.Open()
                cmd.ExecuteNonQuery()
                cn.Close()
                msgbox("Batch Forwarded For Approval")
            Else
                msgbox("Nothing To Save in TSec Batch Header")
            End If

        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub BtnPrint_Click(sender As Object, e As EventArgs) Handles BtnPrint.Click

    End Sub
End Class
