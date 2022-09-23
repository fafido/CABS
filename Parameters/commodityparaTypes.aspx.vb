Imports DevExpress.Web.ASPxGridView

Partial Class Parameters_Commodity_type
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
    Protected Sub loadmeasurements()
        Try
            cmd = New SqlCommand("select unit_of_measurement from para_measurements order by unit_of_measurement", cn)
            Dim ds As New DataSet
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "sec")
            If ds.Tables(0).Rows.Count > 0 Then
                cmbmeasurement.DataSource = ds
                cmbmeasurement.DataTextField = "unit_of_measurement"

            Else
                cmbmeasurement.DataSource = Nothing
            End If
            cmbmeasurement.DataBind()
        Catch ex As Exception

        End Try
    End Sub
    Public Sub checkSessionState()
        Try
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Page.MaintainScrollPositionOnPostBack = True
            If (Not IsPostBack) Then
                checkSessionState()
                getSecurities_Types()
                loadmeasurements()
            End If

            getSecurities_Types()

            If Session("finish") = "delete" Then
                Session("finish") = ""
                msgbox("Successfully Deleted!")
            End If
            If Session("finish") = "update" Then
                Session("finish") = ""
                msgbox("Successfully Updated!")
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Protected Sub clearall()
        txtDesc.Text = ""
        txtType.Text = ""
        getSecurities_Types()
    End Sub
    Protected Sub ASPxButton7_Click(sender As Object, e As EventArgs) Handles ASPxButton7.Click
        If ASPxButton7.Text = "Save" Then


            If txtType.Text <> "" And txtDesc.Text <> "" Then
                If IsNumeric(txtminlot.Text) = False Then
                    msgbox("Please enter numeric value!")
                    Exit Sub
                End If
                cmd = New SqlCommand("select * from Para_Commodity_Type where Commodity_Type='" & txtType.Text & "'", cn)
                Dim ds As New DataSet
                adp = New SqlDataAdapter(cmd)
                adp.Fill(ds, "Para_Security_Type")
                If ds.Tables(0).Rows.Count <= 0 Then

                    cmd = New SqlCommand("insert into Para_Commodity_Type([Commodity_Type],[Description],[Min_Lot],[UnitOfMeasure])values('" & txtType.Text & "','" & txtDesc.Text & "','" + txtminlot.Text + "','" + cmbmeasurement.Text + "')", cn)
                    If cn.State = ConnectionState.Open Then
                        cn.Close()
                    End If
                    cn.Open()
                    Dim y As Integer = cmd.ExecuteNonQuery()
                    cn.Close()
                    clearall()
                Else
                    msgbox("Type Already Exists")
                    Exit Sub
                End If
            Else
                msgbox("Enter All Details")
                Exit Sub
            End If
        Else

            If txtType.Text <> "" And txtDesc.Text <> "" Then
                If IsNumeric(txtminlot.Text) = False Then
                    msgbox("Please enter numeric value!")
                    Exit Sub
                End If


                cmd = New SqlCommand("update Para_Commodity_Type set commodity_type='" & txtType.Text & "',[description]='" & txtDesc.Text & "',Min_Lot='" + txtminlot.Text + "',UnitOfMeasure='" + cmbmeasurement.Text + "' where id='" + lblid.Text + "'", cn)
                If cn.State = ConnectionState.Open Then
                        cn.Close()
                    End If
                    cn.Open()
                    Dim y As Integer = cmd.ExecuteNonQuery()
                    cn.Close()

                Session("finish") = "update"
                Response.Redirect(Request.RawUrl)

            Else
                msgbox("Enter All Details")
                Exit Sub
            End If
        End If

    End Sub
    Protected Sub getSecurities_Types()
        Try
            cmd = New SqlCommand("select ID,Commodity_Type,[Description],FORMAT(Min_Lot,'#,0.00') AS [Min_Lot], UnitOfMeasure from Para_Commodity_Type ORDER BY ID DESC", cn)
            Dim ds As New DataSet
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "Para_Security_Type")
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
        If e.CommandArgs.CommandName = "Edit" Then
            getdetails(e.KeyValue.ToString)

        ElseIf e.CommandArgs.CommandName = "Delete" Then
            cmd = New SqlCommand("delete from Para_Commodity_Type   where id='" + e.KeyValue.ToString + "' ", cn)
            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If
            cn.Open()
            cmd.ExecuteNonQuery()

            Session("finish") = "delete"
            Response.Redirect(Request.RawUrl)
        End If
    End Sub
    Public Sub getdetails(ref As String)
        cmd = New SqlCommand("select ID,Commodity_Type,[Description],Min_Lot, UnitOfMeasure from Para_Commodity_Type where id='" + ref + "'", cn)
        Dim ds As New DataSet
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "Para_Security_Type")
        If ds.Tables(0).Rows.Count > 0 Then
            txtType.Text = ds.Tables(0).Rows(0).Item("Commodity_Type").ToString
            txtDesc.Text = ds.Tables(0).Rows(0).Item("Description").ToString
            Dim min As Decimal = ds.Tables(0).Rows(0).Item("Min_Lot").ToString
            txtminlot.Text = min.ToString("N")
            'cmbmeasurement.SelectedItem.Text = ds.Tables(0).Rows(0).Item("UnitOfMeasure").ToString
            cmbmeasurement.SelectedValue = ds.Tables(0).Rows(0).Item("UnitOfMeasure").ToString
            ASPxButton7.Text = "Update"
            lblid.Text = ref
        End If
    End Sub
    Protected Sub ASPxButton8_Click(sender As Object, e As EventArgs) Handles ASPxButton8.Click
        Response.Redirect(Request.RawUrl)
    End Sub
End Class
