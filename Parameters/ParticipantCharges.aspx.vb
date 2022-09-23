
Partial Class Parameters_ParticipantCharges
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
                Getpart1()
                Getpart2()
                Getpart3()
                FillGrid()
                If Session("finish") = "yes" Then
                    Session("finish") = ""
                    msgbox("participation charges deleted successfully")

               
                ElseIf  Session("finish") = "no" Then
                    Session("finish") = ""
                    msgbox("participation charges updated successfully")

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
        If txtdescription.Text = "" Then
            msgbox("Please enter Charge Description")
            Exit Sub
        Else
            If txtAmt.Text = "" Then
                msgbox("Please enter  Amount")
                Exit Sub

            End If
        
            If txtcode.Text = "" Then
                msgbox("Please enter  Code")
                Exit Sub

            End If
        End If

        Dim indicator As String = "PERCENT"

         If Me.RadioButtonList1.Items(1).Selected = True Then

            indicator = "FLAT_VALUE"
        Else
            indicator = "Percentage"
        End If
        

      

        Dim stmnt As String = "insert into para_charges (participant_type,participant_charge,description_charge,charge_type,charge_code,amount,indicator,limit) values (''" & ASPxTextBox1.SelectedItem.Text & "'',''" & cmdwadi.SelectedItem.Text & "'',''" & txtdescription.Text & "'',''" & cmbchargestage.SelectedItem.Text & "'',''" & txtcode.Text & "'',''" & txtAmt.Text & "'',''" & indicator & "'',''" & txtlimit.Text & "'')"
        Dim descr As String = "New Billing Parameter added with Participant Type:" + ASPxTextBox1.Text + " Participant Charge:" + cmdwadi.SelectedItem.Text +  " Charge Type:" + cmbchargestage.SelectedItem.Text + " Charge code:" + txtcode.Text + " Amount:" + txtAmt.Text + ""
        cmd = New SqlCommand("insert into tbl_uncommitted ([description], script, [status], sender, date_inserted, comment, email_body, email_subject, email_to, category) values ('" + descr + "' , '" + stmnt + "', '0','" + Session("Username") + "', getdate(), '','','', '','New Billing Parameter')", cn)

        If (cn.State = ConnectionState.Open) Then
            cn.Close()
        End If
        cn.Open()
        cmd.ExecuteNonQuery()
        cn.Close()
        FillGrid()

        'ASPxTextBox1.Text = ""
        cmbchargestage.SelectedItem.Text = ""
        txtdescription.Text = ""
        txtAmt.Text = ""
        cmdwadi.SelectedItem.Text=""
        txtcode.Text=""
        ASPxTextBox1.SelectedItem.Text=""
        RadioButtonList1.Items(0).Selected = True

        '   radlistChargeTo.Items(0).Selected = True


        msgbox("Sent for Approval")
       


    End Sub

    Protected Sub ASPxButton1_Click(sender As Object, e As EventArgs) Handles ASPxButton1.Click
        
        Dim indicator As String = "Percentage"

         If Me.RadioButtonList1.Items(1).Selected = True Then

            indicator = "FLAT_VALUE"
        Else
            indicator = "Percentage"
        End If



        Dim stmnt1 As String = "update para_charges set participant_type = '" & ASPxTextBox1.SelectedItem.Text & "',participant_charge='" & cmdwadi.SelectedItem.Text & "',description_charge='" & txtdescription.Text & "',charge_type='" & cmbchargestage.SelectedItem.Text & "',charge_code='" & txtcode.Text & "',amount='"&txtAmt.Text &"',indicator='" & indicator & "',limit='"& txtlimit.Text & "' where id='" & Session("deleteid") & "'"


        Dim cmd1 = New SqlCommand(stmnt1, cn)
        If (cn.State = ConnectionState.Open) Then
            cn.Close()
        End If
        cn.Open()
        cmd1.ExecuteNonQuery()
        cn.Close()

        FillGrid()
        ASPxTextBox1.SelectedItem.Text = ""
        cmbchargestage.SelectedItem.Text = ""
        txtdescription.Text = ""
        txtAmt.Text = ""
        cmdwadi.SelectedItem.Text=""
        txtcode.Text=""
        



       
        Session("finish") = "no"
        Response.Redirect("ParticipantCharges.aspx")
    End Sub


    Protected Sub ASPxButton2_Click(sender As Object, e As EventArgs) Handles ASPxButton2.Click



        Dim stmnt1 As String = "delete from para_charges where id = '" & Session("deleteid") & "'"


        Dim cmd1 = New SqlCommand(stmnt1, cn)
        If (cn.State = ConnectionState.Open) Then
            cn.Close()
        End If
        cn.Open()
        cmd1.ExecuteNonQuery()
        cn.Close()

        FillGrid()
        ASPxTextBox1.SelectedItem.Text = ""
        cmbchargestage.SelectedItem.Text = ""
        txtdescription.Text = ""
        txtAmt.Text = ""
        cmdwadi.SelectedItem.Text=""
        txtcode.Text=""
         RadioButtonList1.Items(0).Selected = True

        Session("finish") = "yes"
        Response.Redirect("ParticipantCharges.aspx")
    End Sub
    Public Sub Getpart1()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select distinct(CompanyType) as Type from tbl_ParticipantsType", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "tbl_ParticipantsType")
            If (ds.Tables(0).Rows.Count > 0) Then
                ASPxTextBox1.Items .Clear()
                ASPxTextBox1.AppendDataBoundItems =true
                ASPxTextBox1.Items .Add(New ListItem ("",""))
                ASPxTextBox1.DataSource = ds.Tables(0)
                ASPxTextBox1.DataValueField = "Type"
                'cmbType.ValueField = "Type"
                ASPxTextBox1.DataBind()
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub Getpart2()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select distinct(chargeType) from tbl_type", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "tbl_type")
            If (ds.Tables(0).Rows.Count > 0) Then
                cmdwadi.Items .Clear()
                cmdwadi.AppendDataBoundItems =true
                cmdwadi.Items .Add(New ListItem ("",""))
                cmdwadi.DataSource = ds.Tables(0)
                cmdwadi.DataValueField = "chargeType"
                'cmbType.ValueField = "Type"
                cmdwadi.DataBind()
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
     Public Sub Getpart3()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select distinct(charge_type) from para_chargetype", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "para_chargetype")
            If (ds.Tables(0).Rows.Count > 0) Then
                cmbchargestage.Items .Clear()
                cmbchargestage.AppendDataBoundItems =true
                cmbchargestage.Items .Add(New ListItem ("",""))
                cmbchargestage.DataSource = ds.Tables(0)
                cmbchargestage.DataValueField = "charge_type"
                'cmbType.ValueField = "Type"
                cmbchargestage.DataBind()
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub FillGrid()
        Dim ds As New DataSet
        cmd = New SqlCommand("SELECT  participant_type as [Participant Type],participant_charge as [Participant Charge], description_charge as [Charge Description] ,charge_type as [Charge Type],charge_code as [Charge Code],amount as [Value/Percentage],indicator,limit As Maximum,ID as [S.No] from para_charges ", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "para_charges")

        If (ds.Tables(0).Rows.Count > 0) Then
            grdvCharges.DataSource = ds.Tables(0)
            grdvCharges.DataBind()
        Else
            'msgbox("not found")
        End If
    End Sub




    Protected Sub grdvCharges_SelectedIndexChanged(sender As Object, e As EventArgs) Handles grdvCharges.SelectedIndexChanged

        ASPxTextBox1.SelectedItem.Text = grdvCharges.SelectedRow.Cells(1).Text
        cmdwadi.SelectedItem.Text = grdvCharges.SelectedRow.Cells(2).Text
        txtdescription.Text = grdvCharges.SelectedRow.Cells(3).Text
        cmbchargestage.SelectedItem.Text = grdvCharges.SelectedRow.Cells(4).Text
        txtcode.Text= grdvCharges.SelectedRow.Cells(5).Text
        txtAmt.Text = grdvCharges.SelectedRow.Cells(6).Text
        Select Case grdvCharges.SelectedRow.Cells(7).Text
            Case "Percentage"
                RadioButtonList1.Items(0).Selected = True
                txtlimit.Visible=True
                lbllimit.Visible=True
            Case "FLAT_VALUE"
               
                RadioButtonList1.Items(1).Selected = True
                 txtlimit.Visible=False
                lbllimit.Visible=False
        End Select
        txtlimit.Text = grdvCharges.SelectedRow.Cells(8).Text.Replace("&nbsp;","")
        Session("deleteid") = grdvCharges.SelectedRow.Cells(9).Text

        ASPxButton1.Visible = True
        ASPxButton2.Visible=True
        ASPxButton4.Visible=False

        

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

    Protected Sub RadioButtonList1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles RadioButtonList1.SelectedIndexChanged
        If RadioButtonList1.SelectedValue= "Percentage"
            lbllimit.Visible =True
            txtlimit.Visible =True

            Else
            lbllimit.Visible =False
            txtlimit.Visible =False
        End If
    End Sub
End Class

