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
    Protected Sub grdDividend_RowCommand(sender As Object, e As DevExpress.Web.ASPxGridView.ASPxGridViewRowCommandEventArgs) Handles grdDividend.RowCommand
        Try
            Dim myID As String = e.KeyValue.ToString
            If e.CommandArgs.CommandName = "Editing" Then
                Using cn = New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("connpath"))
                    Using cmd As New SqlCommand("UPDATE div_instr SET Authorize=0 WHERE ID=@IDD", cn)
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
                    Using cmd As New SqlCommand("UPDATE div_instr SET Authorize=4 WHERE ID=@IDD", cn)
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
            ErrorLogging.WriteLogFile(Session("Username"), "grdDividend_RowCommand", ex.ToString)
        End Try
    End Sub
    Protected Sub grdBonus_RowCommand(sender As Object, e As DevExpress.Web.ASPxGridView.ASPxGridViewRowCommandEventArgs) Handles grdBonus.RowCommand
        Try
            Dim myID As String = e.KeyValue.ToString
            If e.CommandArgs.CommandName = "Editing" Then
                Using cn = New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("connpath"))
                    Using cmd As New SqlCommand("UPDATE Bonus SET Authorize=0 WHERE ID=@IDD", cn)
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
                    Using cmd As New SqlCommand("UPDATE Bonus SET Authorize=4 WHERE ID=@IDD", cn)
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
            ErrorLogging.WriteLogFile(Session("Username"), "grdBonus_RowCommand", ex.ToString)
        End Try
    End Sub
    Protected Sub grdRights_RowCommand(sender As Object, e As DevExpress.Web.ASPxGridView.ASPxGridViewRowCommandEventArgs) Handles grdRights.RowCommand
        Try
            Dim myID As String = e.KeyValue.ToString
            If e.CommandArgs.CommandName = "Editing" Then
                Using cn = New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("connpath"))
                    Using cmd As New SqlCommand("UPDATE Rights_Instr SET Authorize=0 WHERE ID=@IDD", cn)
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
                    Using cmd As New SqlCommand("UPDATE Rights_Instr SET Authorize=4 WHERE ID=@IDD", cn)
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
            ErrorLogging.WriteLogFile(Session("Username"), "grdRights_RowCommand", ex.ToString)
        End Try
    End Sub
    Protected Sub grdSplit_RowCommand(sender As Object, e As DevExpress.Web.ASPxGridView.ASPxGridViewRowCommandEventArgs) Handles grdSplit.RowCommand
        Try
            Dim myID As String = e.KeyValue.ToString
            If e.CommandArgs.CommandName = "Editing" Then
                Using cn = New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("connpath"))
                    Using cmd As New SqlCommand("UPDATE Split_instr SET Authorize=0 WHERE ID=@IDD", cn)
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
                    Using cmd As New SqlCommand("UPDATE Split_instr SET Authorize=4 WHERE ID=@IDD", cn)
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
            ErrorLogging.WriteLogFile(Session("Username"), "grdSplit_RowCommand", ex.ToString)
        End Try
    End Sub
    Protected Sub grdConsol_RowCommand(sender As Object, e As DevExpress.Web.ASPxGridView.ASPxGridViewRowCommandEventArgs) Handles grdConsol.RowCommand
        Try
            Dim myID As String = e.KeyValue.ToString
            If e.CommandArgs.CommandName = "Editing" Then
                Using cn = New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("connpath"))
                    Using cmd As New SqlCommand("UPDATE Consol_instr SET Authorize=0 WHERE ID=@IDD", cn)
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
                    Using cmd As New SqlCommand("UPDATE Consol_instr SET Authorize=4 WHERE ID=@IDD", cn)
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
            ErrorLogging.WriteLogFile(Session("Username"), "grdConsol_RowCommand", ex.ToString)
        End Try
    End Sub
    Sub GetDividends()
        Using cn = New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("connpath"))
            Dim ds As New DataSet
            Dim cmd = New SqlCommand("SELECT *,format(date_declared,'dd MMMM yyyy','en-us') as date_declared1,format(date_closed,'dd MMMM yyyy','en-us') as date_closed1,format(date_payment,'dd MMMM yyyy','en-us') as date_payment1,format(date_Yearending,'dd MMMM yyyy','en-us') as date_Yearending1,case when scrip_round='M' then 'Middle' when scrip_round='D' then 'Down' else 'Up' end as scrip_round1,format(datecreated,'dd MMMM yyyy HH:mm:ss','en-us') as datecreated1 FROM div_instr ORDER BY ID DESC", cn)
            Dim adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "div_instr")
            If ds.Tables(0).Rows.Count > 0 Then
                grdDividend.DataSource = ds
                grdDividend.DataBind()
            Else
                grdDividend.DataSource = Nothing
                grdDividend.DataBind()
            End If
        End Using
    End Sub
    Sub GetBonus()
        Using cn = New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("connpath"))
            Dim ds As New DataSet
            Dim cmd = New SqlCommand("SELECT *,format(date_declared,'dd MMMM yyyy','en-us') as date_declared1,format(date_closed,'dd MMMM yyyy','en-us') as date_closed1,format(date_payment,'dd MMMM yyyy','en-us') as date_payment1,format(date_Yearending,'dd MMMM yyyy','en-us') as date_Yearending1,case when scrip_round='M' then 'Middle' when scrip_round='D' then 'Down' else 'Up' end as scrip_round1,format(datecreated,'dd MMMM yyyy HH:mm:ss','en-us') as datecreated1 FROM Bonus ORDER BY ID DESC", cn)
            Dim adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "Bonus_instr")
            If ds.Tables(0).Rows.Count > 0 Then
                grdBonus.DataSource = ds
                grdBonus.DataBind()
            Else
                grdBonus.DataSource = Nothing
                grdBonus.DataBind()
            End If
        End Using
    End Sub
    Sub GetRights()
        Using cn = New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("connpath"))
            Dim ds As New DataSet
            Dim cmd = New SqlCommand("SELECT *,format(date_declared,'dd MMMM yyyy','en-us') as date_declared1,format(date_closed,'dd MMMM yyyy','en-us') as date_closed1,format(date_payment,'dd MMMM yyyy','en-us') as date_payment1,format(date_Yearending,'dd MMMM yyyy','en-us') as date_Yearending1,case when scrip_round='M' then 'Middle' when scrip_round='D' then 'Down' else 'Up' end as scrip_round1,format(datecreated,'dd MMMM yyyy HH:mm:ss','en-us') as datecreated1 FROM Rights_Instr ORDER BY ID DESC", cn)
            Dim adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "Rights_instr")
            If ds.Tables(0).Rows.Count > 0 Then
                grdRights.DataSource = ds
                grdRights.DataBind()
            Else
                grdRights.DataSource = Nothing
                grdRights.DataBind()
            End If
        End Using
    End Sub
    Sub GetSplit()
        Using cn = New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("connpath"))
            Dim ds As New DataSet
            Dim cmd = New SqlCommand("SELECT *,format(date_declared,'dd MMMM yyyy','en-us') as date_declared1,format(date_closed,'dd MMMM yyyy','en-us') as date_closed1,format(date_payment,'dd MMMM yyyy','en-us') as date_payment1,format(date_Yearending,'dd MMMM yyyy','en-us') as date_Yearending1,case when scrip_round='M' then 'Middle' when scrip_round='D' then 'Down' else 'Up' end as scrip_round1,format(datecreated,'dd MMMM yyyy HH:mm:ss','en-us') as datecreated1 FROM Split_instr ORDER BY ID DESC", cn)
            Dim adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "Split_instr")
            If ds.Tables(0).Rows.Count > 0 Then
                grdSplit.DataSource = ds
                grdSplit.DataBind()
            Else
                grdSplit.DataSource = Nothing
                grdSplit.DataBind()
            End If
        End Using
    End Sub
    Sub GetConsolidation()
        Using cn = New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("connpath"))
            Dim ds As New DataSet
            Dim cmd = New SqlCommand("SELECT *,format(date_declared,'dd MMMM yyyy','en-us') as date_declared1,format(date_closed,'dd MMMM yyyy','en-us') as date_closed1,format(date_payment,'dd MMMM yyyy','en-us') as date_payment1,format(date_Yearending,'dd MMMM yyyy','en-us') as date_Yearending1,case when scrip_round='M' then 'Middle' when scrip_round='D' then 'Down' else 'Up' end as scrip_round1,format(datecreated,'dd MMMM yyyy HH:mm:ss','en-us') as datecreated1 FROM Consol_instr ORDER BY ID DESC", cn)
            Dim adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "Consol_instr")
            If ds.Tables(0).Rows.Count > 0 Then
                grdConsol.DataSource = ds
                grdConsol.DataBind()
            Else
                grdConsol.DataSource = Nothing
                grdConsol.DataBind()
            End If
        End Using
    End Sub
    Protected Sub cmbEvent_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbEvent.SelectedIndexChanged
        If cmbEvent.Text = "Dividend" Then
            GetDividends()
            Panel001Div.Visible = True
            Panel002Rights.Visible = False
            Panel003Bonus.Visible = False
            Panel004Split.Visible = False
            Panel005Consol.Visible = False
        ElseIf cmbEvent.Text = "Rights" Then
            GetRights()
            Panel001Div.Visible = False
            Panel002Rights.Visible = True
            Panel003Bonus.Visible = False
            Panel004Split.Visible = False
            Panel005Consol.Visible = False
        ElseIf cmbEvent.Text = "Bonus" Then
            GetBonus()
            Panel001Div.Visible = False
            Panel002Rights.Visible = False
            Panel003Bonus.Visible = True
            Panel004Split.Visible = False
            Panel005Consol.Visible = False
        ElseIf cmbEvent.Text = "Split" Then
            GetSplit()
            Panel001Div.Visible = False
            Panel002Rights.Visible = False
            Panel003Bonus.Visible = False
            Panel004Split.Visible = True
            Panel005Consol.Visible = False
        ElseIf cmbEvent.Text = "Consolidation" Then
            GetConsolidation()
            Panel001Div.Visible = False
            Panel002Rights.Visible = False
            Panel003Bonus.Visible = False
            Panel004Split.Visible = False
            Panel005Consol.Visible = True
        End If
    End Sub
End Class
