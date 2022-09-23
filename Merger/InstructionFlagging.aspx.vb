Imports System.Net.Mail
Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Imports System
Imports System.Configuration
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls
Imports System.Web.Services

Partial Class Corp_divInstrAUTH
    Inherits System.Web.UI.Page
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

            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Protected Sub grdMerger_RowCommand(sender As Object, e As DevExpress.Web.ASPxGridView.ASPxGridViewRowCommandEventArgs) Handles grdMerger.RowCommand
        Try
            Dim myID As String = e.KeyValue.ToString
            If e.CommandArgs.CommandName = "Editing" Then
                Using cn = New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("connpath"))
                    Using cmd As New SqlCommand("UPDATE Merger_instr SET Authorize=0 WHERE ID=@IDD", cn)
                        cmd.Parameters.AddWithValue("@IDD", myID)
                        If cn.State = ConnectionState.Open Then cn.Close()
                        cn.Open()
                        cmd.ExecuteNonQuery()
                        cn.Close()
                    End Using
                End Using
                Response.Write("<script>alert('Instruction Updated') ; location.href='InstructionFlagging.aspx'</script>")
            ElseIf e.CommandArgs.CommandName = "Paid" Then
                Using cn = New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("connpath"))
                    Using cmd As New SqlCommand("UPDATE Merger_instr SET Authorize=4 WHERE ID=@IDD", cn)
                        cmd.Parameters.AddWithValue("@IDD", myID)
                        If cn.State = ConnectionState.Open Then cn.Close()
                        cn.Open()
                        cmd.ExecuteNonQuery()
                        cn.Close()
                    End Using
                End Using
                Response.Write("<script>alert('Instruction Updated') ; location.href='InstructionFlagging.aspx'</script>")
            End If
        Catch ex As Exception
            ErrorLogging.WriteLogFile(Session("Username"), "grdMerger_RowCommand", ex.ToString)
        End Try
    End Sub
    Sub GetMerger()
        Using cn = New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("connpath"))
            Dim ds As New DataSet
            Dim cmd = New SqlCommand("SELECT *,format(date_declared,'dd MMMM yyyy','en-us') as date_declared1,format(date_closed,'dd MMMM yyyy','en-us') as date_closed1,format(date_payment,'dd MMMM yyyy','en-us') as date_payment1,format(date_Yearending,'dd MMMM yyyy','en-us') as date_Yearending1,case when scrip_round='M' then 'Middle' when scrip_round='D' then 'Down' else 'Up' end as scrip_round1,format(datecreated,'dd MMMM yyyy HH:mm:ss','en-us') as datecreated1 FROM Merger_instr ORDER BY ID DESC", cn)
            Dim adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "Merger_instr")
            If ds.Tables(0).Rows.Count > 0 Then
                grdMerger.DataSource = ds
                grdMerger.DataBind()
            Else
                grdMerger.DataSource = Nothing
                grdMerger.DataBind()
            End If
        End Using
    End Sub
    Protected Sub cmbEvent_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbEvent.SelectedIndexChanged
        If cmbEvent.Text = "Merger" Then
            GetMerger()
            Panel004Merger.Visible = True
        End If
    End Sub
End Class
