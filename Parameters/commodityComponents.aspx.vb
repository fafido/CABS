


Imports DevExpress.Web.ASPxGridView

Partial Class Parameters_commodityComponents
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
    Protected Sub loadGrade(commodity As String)
        Try
            cmd = New SqlCommand("select [grade] from [Para_Commodity_grades] where commodity='" + cmbType.Text + "'", cn)
            Dim ds As New DataSet
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "sec")
            If ds.Tables(0).Rows.Count > 0 Then
                cmbGrade.DataSource = ds
                cmbGrade.DataTextField = "grade"

            Else
                cmbGrade.DataSource = Nothing
            End If
            cmbGrade.DataBind()
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub loadComponent(commodity As String)
        Try
            cmbComponent.DataSource = Nothing
            cmd = New SqlCommand("select [component] from [gradingComponents] where [commodity] ='" & cmbType.Text & "'", cn)
            Dim ds As New DataSet
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "sec")
            If ds.Tables(0).Rows.Count > 0 Then
                cmbComponent.DataSource = ds
                cmbComponent.DataTextField = "component"

            Else
                cmbComponent.DataSource = Nothing
                cmbComponent.Text = ""
            End If
            cmbComponent.DataBind()

        Catch ex As Exception

        End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Page.MaintainScrollPositionOnPostBack = True
            If (Not IsPostBack) Then
                checkSessionState()
                GetSec_Types()
                getSecurities_Categories(cmbType.Text)
                loadComponent(cmbType.Text)
                loadGrade(cmbType.Text)
                loadParaMeasure()
                If Session("finish") = "update" Then
                    Session("finish") = ""
                    msgbox("Successfully Updated!")
                End If
                If Session("finish") = "delete" Then
                    Session("finish") = ""
                    msgbox("Successfully Deleted!")
                End If
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Protected Sub clearall()
        txtValue.Text = ""
        minmax.SelectedIndex = 0
        cmbMeasure.ClearSelection()
        cmbComponent.ClearSelection()

    End Sub
    Protected Sub cmbType_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbType.SelectedIndexChanged
        Try
            loadComponent(cmbType.SelectedItem.Value)
            loadGrade(cmbType.SelectedItem.Value)
            getSecurities_Categories(cmbType.Text)
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Protected Sub ASPxButton7_Click(sender As Object, e As EventArgs) Handles ASPxButton7.Click
        If txtValue.Text = "" Then
            msgbox("")
        End If
        If minmax.Text <> "Absolute" Then
            If IsNumeric(txtValue.Text) = False Then
                msgbox("Please enter numeric values for Non-Absolute values")
                Exit Sub
            End If
        End If
        If ASPxButton7.Text = "Save" Then


            If txtValue.Text = "" Then
                msgbox("Please Insert Value")
                Exit Sub
            End If
            If cmbComponent.SelectedValue = "" Then
                msgbox("Please Select Component")
                Exit Sub
            End If
            If cmbGrade.SelectedValue = "" Then
                msgbox("Please Select Grade")
                Exit Sub
            End If
            If minmax.SelectedItem.Value = "" Then
                msgbox("Please Select Min/Max/Absolute")
                Exit Sub
            End If
            If minmax.SelectedItem.Text <> "Absolute" Then
                If cmbMeasure.Text = "" Then
                    msgbox("Please Select Measure!")
                    Exit Sub
                End If
            End If



            cmd = New SqlCommand("select * from [para_commodity_components] where grade='" & cmbGrade.Text & "' AND commodity='" + cmbType.Text + "' and Component='" + cmbComponent.Text + "'", cn)
            Dim ds As New DataSet
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "Para_Security_Type")
            If ds.Tables(0).Rows.Count <= 0 Then
                cmd = New SqlCommand("insert into [para_commodity_components]([commodity],[Grade],[Component],[minmax],[value],[Measure]) values ('" & cmbType.Text & "','" & cmbGrade.Text & "','" & cmbComponent.Text & "','" + minmax.SelectedItem.Value + "','" + txtValue.Text + "','" + cmbMeasure.SelectedValue + "')", cn)
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
                msgbox("Grade Component Already Exists")
                Exit Sub
            End If
        Else
            cmd = New SqlCommand("update  para_commodity_components  set [Value]='" + txtValue.Text + "', measure='" + cmbMeasure.Text + "'  where id='" + lblid.Text + "' ", cn)
            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If
            cn.Open()
            cmd.ExecuteNonQuery()
            getSecurities_Categories(cmbType.Text)
            Session("finish") = "update"
            Response.Redirect(Request.RawUrl)
            ' clearall()

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
    Protected Sub getSecurities_Categories(commodity As String)
        Try
            cmd = New SqlCommand("select [id]   as [ID]   ,[commodity]      ,[Grade]      ,[Component], [minmax] as [Min/Max]  ,[value],[Measure] from para_commodity_components where  [commodity] ='" & commodity & "' ", cn)
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
    Protected Sub loadParaMeasure()
        Try
            cmbMeasure.Items.Clear()
            cmbMeasure.DataSource = Nothing
            cmbMeasure.DataBind()
            cmd = New SqlCommand("select [ParaMeasure] from [ParaMeasure] ", cn)
            Dim ds As New DataSet
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "sec")
            If ds.Tables(0).Rows.Count > 0 Then
                cmbMeasure.DataSource = ds
                cmbMeasure.DataTextField = "ParaMeasure"
                cmbMeasure.DataValueField = "ParaMeasure"
            Else
                cmbMeasure.DataSource = Nothing
            End If
            cmbMeasure.DataBind()

        Catch ex As Exception

        End Try
    End Sub
    Protected Sub ASPxButton8_Click(sender As Object, e As EventArgs) Handles ASPxButton8.Click
        Response.Redirect(Request.RawUrl)
    End Sub

    Private Sub ASPxGridView2_RowCommand(sender As Object, e As ASPxGridViewRowCommandEventArgs) Handles ASPxGridView2.RowCommand
        Dim id As String = e.KeyValue.ToString
        If e.CommandArgs.CommandName.ToString = "Edit" Then
            getinfortoedit(id)
        ElseIf e.CommandArgs.CommandName.ToString = "Delete" Then
            cmd = New SqlCommand("delete from para_commodity_components   where id='" + e.KeyValue.ToString + "' ", cn)
            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If
            cn.Open()
            cmd.ExecuteNonQuery()
            getSecurities_Categories(cmbType.Text)
            Session("finish") = "delete"
            Response.Redirect(Request.RawUrl)
        End If

    End Sub
    Public Sub getinfortoedit(id As String)
        cmd = New SqlCommand("select * from para_commodity_components where id='" + id + "'", cn)
        Dim ds As New DataSet
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "pc")
        If ds.Tables(0).Rows.Count > 0 Then
            cmbType.SelectedValue = ds.Tables(0).Rows(0).Item("commodity").ToString
            cmbGrade.SelectedValue = ds.Tables(0).Rows(0).Item("grade").ToString
            cmbComponent.SelectedValue = ds.Tables(0).Rows(0).Item("component").ToString
            minmax.Value = ds.Tables(0).Rows(0).Item("minmax").ToString
            cmbMeasure.SelectedValue = ds.Tables(0).Rows(0).Item("measure").ToString
            txtValue.Text = ds.Tables(0).Rows(0).Item("value").ToString
            cmbType.Enabled = False
            cmbGrade.Enabled = False
            cmbComponent.Enabled = False
            minmax.Enabled = False
            ASPxButton7.Text = "Update"
            lblid.Text = id
        End If
    End Sub

    Protected Sub btnCommitNewMeasure_Click(sender As Object, e As EventArgs) Handles btnCommitNewMeasure.Click
        If Len(txtAddMeasure.Text) < 1 Then
            msgbox("Enter Measure")
            Exit Sub
        End If
        If ChargeDescExists() = True Then
            msgbox("Measure already exists")
            Exit Sub
        End If
        Using cn = New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("connpath"))
            Dim stmnt As String = "IF NOT EXISTS (SELECT TOP 1 K.* FROM ParaMeasure K WHERE K.ParaMeasure=@ParaMeasure) BEGIN INSERT INTO ParaMeasure(ParaMeasure) "
            stmnt = stmnt & " VALUES(@ParaMeasure) END "
            Using cmd As New SqlCommand(stmnt, cn)
                cmd.Parameters.AddWithValue("@ParaMeasure", txtAddMeasure.Text)
                If cn.State = ConnectionState.Open Then cn.Close()
                cn.Open()
                cmd.ExecuteNonQuery()
                cn.Close()
                txtAddMeasure.Text = ""
                loadParaMeasure()
                msgbox("parameter saved successfully")
            End Using
        End Using
    End Sub
    Function ChargeDescExists() As Boolean
        Dim strSQL As String = ""
        strSQL = "SELECT * from ParaMeasure where ParaMeasure=@ParaMeasure"
        Using cn = New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("connpath"))
            Dim ds As New DataSet
            Dim cmd = New SqlCommand(strSQL, cn)
            cmd.Parameters.AddWithValue("@ParaMeasure", txtAddMeasure.Text)
            Dim adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "ParaMeasure")
            If ds.Tables(0).Rows.Count > 0 Then
                Return True
            Else
                Return False
            End If
        End Using
    End Function
    Protected Sub btnAddChargeType_Click(sender As Object, e As EventArgs) Handles btnAddChargeType.Click
        ASPxPopupControl1.PopupHorizontalAlign = DevExpress.Web.ASPxClasses.PopupHorizontalAlign.WindowCenter
        ASPxPopupControl1.PopupVerticalAlign = DevExpress.Web.ASPxClasses.PopupVerticalAlign.WindowCenter
        ASPxPopupControl1.AllowDragging = True
        ASPxPopupControl1.ShowCloseButton = True
        ASPxPopupControl1.ShowOnPageLoad = True
        Page.MaintainScrollPositionOnPostBack = False
    End Sub
End Class
