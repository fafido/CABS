


Imports DevExpress.Web.ASPxGridView

Partial Class Parameters_graddingComponets
    Inherits System.Web.UI.Page
    Dim constr As String = (System.Configuration.ConfigurationManager.AppSettings("connpath"))
    Dim cn As New SqlConnection(constr)
    Dim adp As SqlDataAdapter
    Dim cmd As SqlCommand
    Public Sub msgbox(ByVal strMessage As String)

        'finishes server processing, returns to client.
        Dim strScript As String = "<script language=JavaScript>"
        strScript += "window.alert(""" & strMessage & """);"
        strScript += "</script>"
        Dim lbl As New System.Web.UI.WebControls.Label
        lbl.Text = strScript
        Page.Controls.Add(lbl)

    End Sub
    Public Sub checkSessionState()
        Try
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Protected Sub cmbType_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbType.SelectedIndexChanged
        Try

            getSecurities_Categories(cmbType.Text)
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Page.MaintainScrollPositionOnPostBack = True
            If (Not IsPostBack) Then
                checkSessionState()


                GetSec_Types()
                getSecurities_Categories(cmbType.Text)
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub GetSec_Types()
        Try
            cmd = New SqlCommand("  select * from para_commodity_type", cn)
            Dim ds As New DataSet
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "Para_Security_Type")
            If ds.Tables(0).Rows.Count > 0 Then
                cmbType.DataSource = ds.Tables(0)
                cmbType.DataTextField = "commodity_TYPE"
                cmbType.DataValueField = "commodity_TYPE"
            Else
                cmbType.DataSource = Nothing
            End If
            cmbType.DataBind()
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Protected Sub clearall()
        txtComponent.Text = ""

        '  getSecurities_Categories(cmbType.Text)
        ASPxButton7.Text = "Save"
    End Sub
    Protected Sub ASPxButton7_Click(sender As Object, e As EventArgs) Handles ASPxButton7.Click
        If ASPxButton7.Text = "Save" Then


            If txtComponent.Text = "" Then
                msgbox("Please enter commodity Parameter")
                Exit Sub
            End If


            cmd = New SqlCommand("select * from [gradingComponents] where component='" & txtComponent.Text & "' AND commodity='" + cmbType.Text + "'", cn)
            Dim ds As New DataSet
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "Para_Security_Type")
            If ds.Tables(0).Rows.Count <= 0 Then
                cmd = New SqlCommand("insert into [gradingComponents] ([commodity],[component]) values ('" & cmbType.Text & "','" & txtComponent.Text & "')", cn)
                If cn.State = ConnectionState.Open Then
                    cn.Close()
                End If
                cn.Open()
                Dim y As Integer = cmd.ExecuteNonQuery()
                cn.Close()
                getSecurities_Categories(cmbType.Text)
                msgbox("Details Successfully Saved")
                clearall()
            Else
                msgbox("component Already Exists")
                Exit Sub
            End If
        Else

            cmd = New SqlCommand("update [gradingComponents] set  [commodity]='" + cmbType.Text + "',[component]='" + txtComponent.Text + "' where id='" + lblid.Text + "'", cn)
            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If
            cn.Open()
            Dim y As Integer = cmd.ExecuteNonQuery()
            cn.Close()
            getSecurities_Categories(cmbType.Text)
            msgbox("Details Successfully Saved")
            clearall()
        End If

    End Sub

    Protected Sub getSecurities_Categories(commodity As String)
        Try
            cmd = New SqlCommand("select * from gradingComponents  where [commodity] ='" & commodity & "'", cn)
            Dim ds As New DataSet
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "Para_Security_Category1")
            If ds.Tables(0).Rows.Count > 0 Then
                ASPxGridView2.DataSource = ds.Tables(0)
            Else
                ASPxGridView2.DataSource = Nothing
            End If
            ASPxGridView2.DataBind()
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Private Sub ASPxGridView2_RowCommand(sender As Object, e As ASPxGridViewRowCommandEventArgs) Handles ASPxGridView2.RowCommand
        Dim id As String = e.KeyValue.ToString
        If e.CommandArgs.CommandName.ToString = "Edit" Then
            getinfortoedit(id)
        ElseIf e.CommandArgs.CommandName.ToString = "Delete" Then
            ' Try
            cmd = New SqlCommand("delete from gradingcomponents where id='" + id.ToString + "'", cn)
            If cn.State = ConnectionState.Open Then
                    cn.Close()
                End If
                cn.Open()
                Dim y As Integer = cmd.ExecuteNonQuery()
                cn.Close()
                clearall()
                getSecurities_Categories(cmbType.Text)
            'Catch ex As Exception

            'End Try
        End If
    End Sub
    Public Sub getinfortoedit(id As String)
        cmd = New SqlCommand("select * from gradingcomponents where id='" + id + "'", cn)
        Dim ds As New DataSet
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "pc")
        If ds.Tables(0).Rows.Count > 0 Then
            cmbType.SelectedValue = ds.Tables(0).Rows(0).Item("commodity").ToString
            txtComponent.Text = ds.Tables(0).Rows(0).Item("component").ToString
            ASPxButton7.Text = "Update"
            lblid.Text = id
        End If
    End Sub
    Protected Sub ASPxButton8_Click(sender As Object, e As EventArgs) Handles ASPxButton8.Click
        Response.Redirect(Request.RawUrl)
    End Sub
End Class

