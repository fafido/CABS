Imports DevExpress.Web.ASPxGridView

Partial Class Parameters_comm_grades
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
    Protected Sub loadmeasurements()
        Try
            cmd = New SqlCommand("select unit_of_measurement from para_measurements", cn)
            Dim ds As New DataSet
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "sec")
            If ds.Tables(0).Rows.Count > 0 Then
                cmbmeasurement.DataSource = ds
                cmbmeasurement.DataTextField = "unit_of_measurement"
                cmbmeasurement.DataValueField = "unit_of_measurement"

            Else
                cmbmeasurement.DataSource = Nothing
            End If
            cmbmeasurement.DataBind()
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Page.MaintainScrollPositionOnPostBack = True
            If (Not IsPostBack) Then
                checkSessionState()
                getSecurities_Categories()
                GetSec_Types()
                loadmeasurements()

            End If
            getSecurities_Categories()

        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Protected Sub clearall()
        txtDesc.Text = ""
        txtCategory.Text = ""
        getSecurities_Categories()
    End Sub
    Protected Sub ASPxButton7_Click(sender As Object, e As EventArgs) Handles ASPxButton7.Click
        If ASPxButton7.Text = "Save" Then



            If txtCategory.Text <> "" And txtDesc.Text <> "" And cmbType.Text <> "" Then
                If cmbType.Text = "-Select-" Then
                    msgbox("Please select Commodity!")
                    Exit Sub
                End If
                If cmbmeasurement.Text = "-Select-" Then
                    msgbox("Please select Measurement!")
                    Exit Sub
                End If

                cmd = New SqlCommand("select * from Para_Commodity_grades where grade='" & txtCategory.Text & "' AND commodity='" + cmbType.Text + "'", cn)
                Dim ds As New DataSet
                adp = New SqlDataAdapter(cmd)
                adp.Fill(ds, "Para_Security_Type")
                If ds.Tables(0).Rows.Count <= 0 Then
                    cmd = New SqlCommand("insert into para_commodity_grades([Commodity],[Grade],[Comments],[Measurement],[Rank]) values ('" & cmbType.Text & "','" & txtCategory.Text & "','" & txtDesc.Text & "','" + unitofmeas() + "','1')", cn)
                    If cn.State = ConnectionState.Open Then
                        cn.Close()
                    End If
                    cn.Open()
                    Dim y As Integer = cmd.ExecuteNonQuery()
                    cn.Close()
                    getSecurities_Categories()

                    clearall()
                Else
                    msgbox("Grade Already Exists")
                    Exit Sub
                End If
            Else
                msgbox("Enter All Details")
                Exit Sub
            End If
        Else
            If cmbType.Text = "-Select-" Then
                msgbox("Please select Commodity!")
                Exit Sub
            End If
            If cmbmeasurement.Text = "-Select-" Then
                msgbox("Please select Measurement!")
                Exit Sub
            End If

            cmd = New SqlCommand("update para_commodity_grades set grade='" + txtCategory.Text + "', comments='" + txtDesc.Text + "' where id='" + Label2.Text + "'", cn)
            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If
            cn.Open()
            Dim y As Integer = cmd.ExecuteNonQuery()
            cn.Close()

            ASPxButton7.Text = "Save"


            ' cmbmeasurement.Enabled = True
            '   cmbType.Items.Clear()

            cmbType.Enabled = True
            clearall()
            getSecurities_Categories()
        End If

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
    Protected Sub getSecurities_Categories()
        Try
            cmd = New SqlCommand("select [id]   as [ID]   ,[Commodity]      ,[Grade] , [Measurement],[Rank] [Grade Rank]     ,[comments] as [Variety] from Para_Commodity_grades", cn)
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
    Protected Sub cmbType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbType.SelectedIndexChanged
        cmd = New SqlCommand("SELECT unitofmeasure from Para_Commodity_Type where Commodity_Type='" + cmbType.Text + "'", cn)
        Dim ds As New DataSet
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "Para_Security_Category1")
        If ds.Tables(0).Rows.Count > 0 Then
            cmbmeasurement.SelectedItem.Text = ds.Tables(0).Rows(0).Item("UnitOfMeasure").ToString
        End If
    End Sub
    Public Function unitofmeas() As String
        cmd = New SqlCommand("SELECT unitofmeasure from Para_Commodity_Type where Commodity_Type='" + cmbType.Text + "'", cn)
        Dim ds As New DataSet
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "Para_Security_Category1")
        If ds.Tables(0).Rows.Count > 0 Then
            Return ds.Tables(0).Rows(0).Item("UnitOfMeasure").ToString
        End If
    End Function
    Public Sub getinfortoedit(id As String)
        cmd = New SqlCommand("select * from para_commodity_grades where id='" + id.ToString + "'", cn)
        Dim ds As New DataSet
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "info")
        If ds.Tables(0).Rows.Count > 0 Then
            cmbType.SelectedValue = ds.Tables(0).Rows(0).Item("commodity").ToString
            cmbType.Enabled = False

            cmbmeasurement.SelectedValue = ds.Tables(0).Rows(0).Item("Measurement").ToString
            txtCategory.Text = ds.Tables(0).Rows(0).Item("Grade").ToString
            txtDesc.Text = ds.Tables(0).Rows(0).Item("comments").ToString
            Label2.Text = id
            ASPxButton7.Text = "Update"
        End If
    End Sub

    Private Sub ASPxGridView2_RowCommand(sender As Object, e As ASPxGridViewRowCommandEventArgs) Handles ASPxGridView2.RowCommand
        Dim id As String = e.KeyValue.ToString
        If e.CommandArgs.CommandName.ToString = "Edit" Then
            getinfortoedit(id)
        ElseIf e.CommandArgs.CommandName.ToString = "Delete" Then
            cmd = New SqlCommand("DELETE FROM para_commodity_grades where id='" + e.KeyValue.ToString + "' ", cn)
            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If
            cn.Open()
            cmd.ExecuteNonQuery()
            getSecurities_Categories()

            msgbox("Grade Deleted!")
        End If

    End Sub
    Protected Sub ASPxButton8_Click(sender As Object, e As EventArgs) Handles ASPxButton8.Click
        Response.Redirect(Request.RawUrl)
    End Sub
End Class
