
Partial Class Parameters_charges
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
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Page.MaintainScrollPositionOnPostBack = True
            If (Not IsPostBack) Then
                checkSessionState()
                FillGrid()
                If Session("finish") = "yes" Then
                    Session("finish") = ""
                    msgbox("warehouse fees deleted successfully")

                End If
            End If


        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    'Public Sub GetBillingParamenter()
    '    Dim ds As New DataSet
    '    Dim i As Integer = 0
    '    cmd = New SqlCommand("SELECT * from para_BillingParameter where Active=TRUE", cn)
    '    adp = New SqlDataAdapter(cmd)
    '    adp.Fill(ds, "para_BillingParameter")

    '    If ds.Tables(0).Rows.Count > 1 Then
    '        msgbox("More than one billing option was set kindly select only one option")
    '    End If
    '    For i = 0 To ds.Tables(0).Rows.Count
    '        Select Case ds.Tables(0).Rows(i).Item("BillingParamenter").ToString
    '            Case "Exclude Charges"
    '                radlistBillingParameters.Items(i).Selected = True
    '            Case "Auto - Include Charges"
    '                radlistBillingParameters.Items(i).Selected = True
    '            Case "Auto - Exclude Trading Charges"
    '                radlistBillingParameters.Items(i).Selected = True
    '            Case "Invoice at end of Period"
    '                radlistBillingParameters.Items(i).Selected = True
    '            Case Else
    '                msgbox(ds.Tables(0).Rows(i).Item("BillingParamenter").ToString & " is not catered for in the system, notify Support")
    '        End Select
    '    Next i
    'End Sub

    Protected Sub ASPxButton4_Click(sender As Object, e As EventArgs) Handles ASPxButton4.Click

        If txtAmt.Text = "" Then
            msgbox("Please enter the Amount")
            Exit Sub

        End If

        'Dim applyChgTo As String = "BOTH"
        'Dim indicator As String = "PERCENT"
        'Dim dsid As New DataSet
        'cmd = New SqlCommand("Select * from para_Billing where ChargeCode='" & txtChargeCode.Text & "'", cn)
        'adp = New SqlDataAdapter(cmd)
        'adp.Fill(dsid, "para_Billing")
        'If (dsid.Tables(0).Rows.Count > 0) Then
        '    'msgbox("Entered ID has been saved before")
        '    Exit Sub
        'End If

        'If Me.RadioButtonList1.Items(1).Selected = True Then

        '    indicator = "FLAT_VALUE"
        'Else
        '    indicator = "PERCENT"
        'End If

        'If radlistChargeTo.Items(0).Selected = True Then
        '    applyChgTo = "BOTH"
        'End If
        'If radlistChargeTo.Items(1).Selected = True Then
        '    applyChgTo = "SELLER"
        'End If

        'If radlistChargeTo.Items(2).Selected = True Then
        '    applyChgTo = "BUYER"
        'End If
        'If (dsid.Tables(0).Rows.Count > 0) Then
        '    'msgbox("Entered ID has been saved before")
        '    Exit Sub
        'End If

        Dim stmnt As String = "insert into para_ncmcl_charges (accreditation_type,Amount) values ('" & ASPxTextBox1.Text & "','" & txtAmt.Text & "')"
        ' Dim descr As String = "New Billing Parameter added with Charge Code:" + txtChargeCode.Text + " Charge Name:" + txtChargeName.Text + "  Value/Percentage:" + txtPercent.Text + "  Applied to:" + applyChgTo + " Indicator:" + indicator + ""
        ' cmd = New SqlCommand("insert into tbl_uncommitted ([description], script, [status], sender, date_inserted, comment, email_body, email_subject, email_to, category) values ('" + stmnt + "', '0','" + Session("Username") + "', getdate(), '','','', '','New Billing Parameter')", cn)


        Dim cmd1 = New SqlCommand(stmnt, cn)
        If (cn.State = ConnectionState.Open) Then
            cn.Close()
        End If
        cn.Open()
        cmd1.ExecuteNonQuery()
        cn.Close()
        FillGrid()

        ASPxTextBox1.Text = ""
        'cmbchargestage.Text = ""
        'txtdescription.Text = ""
        txtAmt.Text = ""

        '   radlistChargeTo.Items(0).Selected = True


        msgbox("warehouse fees added successfully")
        ''Dim ds As New DataSet
        'cmd = New SqlCommand("SELECT * from para_Billing", cn)
        'adp = New SqlDataAdapter(cmd)
        'adp.Fill(ds, "para_Billing")

        'If (ds.Tables(0).Rows.Count > 0) Then
        '    grdvCharges.DataSource = ds.Tables(0)
        '    grdvCharges.DataBind()
        'Else
        '    'msgbox("not found")
        'End If



    End Sub

    Protected Sub ASPxButton1_Click(sender As Object, e As EventArgs) Handles ASPxButton1.Click



        Dim stmnt1 As String = "delete from para_ncmcl_charges  where id = '" & Session("deleteid") & "'"


        Dim cmd1 = New SqlCommand(stmnt1, cn)
        If (cn.State = ConnectionState.Open) Then
            cn.Close()
        End If
        cn.Open()
        cmd1.ExecuteNonQuery()
        cn.Close()

        FillGrid()
        ASPxTextBox1.Text = ""
        txtAmt.Text = ""


        '   radlistChargeTo.Items(0).Selected = True
        Session("finish") = "yes"
        Response.Redirect("charges.aspx")




    End Sub
    Public Sub FillGrid()
        Dim ds As New DataSet
        cmd = New SqlCommand("SELECT  accreditation_type as [Accreditation Type],Amount,ID from para_ncmcl_charges ", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "para_ncmcl_charges")

        If (ds.Tables(0).Rows.Count > 0) Then
            grdvCharges.DataSource = ds.Tables(0)
            grdvCharges.DataBind()
        Else
            'msgbox("not found")
        End If
    End Sub




    Protected Sub grdvCharges_SelectedIndexChanged(sender As Object, e As EventArgs) Handles grdvCharges.SelectedIndexChanged

        ASPxTextBox1.Text = grdvCharges.SelectedRow.Cells(1).Text
        'cmbchargestage.Text = grdvCharges.SelectedRow.Cells(2).Text
        'txtdescription.Text = grdvCharges.SelectedRow.Cells(3).Text
        txtAmt.Text = grdvCharges.SelectedRow.Cells(2).Text
        Session("deleteid") = grdvCharges.SelectedRow.Cells(3).Text
        ASPxButton1.Visible = True
        ' txtPercent.Text = grdvCharges.SelectedRow.Cells(3).Text
        'Select Case grdvCharges.SelectedRow.Cells(4).Text
        '    Case "BOTH"
        '        radlistChargeTo.Items(0).Selected = True
        '    Case "SELLER"
        '        radlistChargeTo.Items(1).Selected = True
        '    Case "BUYER"
        '        radlistChargeTo.Items(0).Selected = True
        'End Select

        Dim cmd1 = New SqlCommand("Delete from  para_billing where ChargeCode = '" & grdvCharges.SelectedRow.Cells(1).Text & "'", cn)
        If (cn.State = ConnectionState.Open) Then
            cn.Close()
        End If
        cn.Open()
        cmd1.ExecuteNonQuery()
        cn.Close()
        FillGrid()
    End Sub



    Public Sub RemoveCurrenctPara()
        Dim cmd1 = New SqlCommand("Update para_BillingParamete set Active=FALSE Where Active=True", cn)
        If (cn.State = ConnectionState.Open) Then
            cn.Close()
        End If
        cn.Open()
        cmd1.ExecuteNonQuery()
        cn.Close()
    End Sub

End Class


