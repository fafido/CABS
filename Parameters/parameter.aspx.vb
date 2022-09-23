
Partial Class Parameters_parameter
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
                Getpart3()
                Getpart4()
                Getpart5()
                'GetTypes2()
                FillGrid()
                If Session("finish") = "yes" Then
                    Session("finish") = ""
                    msgbox("Additional Charges deleted successfully")

                ElseIf  Session("finish") = "no" Then
                    Session("finish") = ""
                    msgbox("Additional Charges updated successfully")

                End If
            End If


        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub ASPxButton4_Click(sender As Object, e As EventArgs) Handles ASPxButton4.Click

        If txtCharge.Text = "" Then
            msgbox("Please Enter Charge Type")
            Exit Sub
        Else
            If txtdep.Text = "" Then
                msgbox("Please Fill Charge Description")
                Exit Sub
            Else
                If txtAmt.Text = "" Then
            msgbox("Please Enter Amount ")
            Exit Sub
                End If
            End If


        End If
        Dim indicator As String 

         If RadioButtonList1.Items(1).Selected = True Then

            indicator = "FLAT_VALUE"
        Else If RadioButtonList1.Items(0).Selected = True Then
            indicator = "Percentage"
        End If
        


        

        Dim stmnt As String = "insert into para_bill (charge_name,charge_descriprion,charge_type,Amount,apply_to,participant_type,indicator,limit) values (''" & txtCharge.Text & "'',''" & txtdep.Text & "'',''" + cmdtype.SelectedItem.Text + "'',''" & txtAmt.Text & "'',''" + txtapp.SelectedItem.Text + "'',''" + cmdtypes.SelectedItem.Text + "'',''" & indicator & "'',''"& txtlimit.Text &"'')"
        Dim descr As String = "New Billing Parameter added with Charge Name:" + txtCharge.Text + " Charge Type:" + cmdtype.SelectedItem.Text + "  Apply To:" + txtapp.SelectedItem.Text + "  Amount:" + txtAmt.Text + ""
        cmd = New SqlCommand("insert into tbl_uncommitted ([description], script, [status], sender, date_inserted, comment, email_body, email_subject, email_to, category) values ('" + descr + "' , '" + stmnt + "', '0','" + Session("Username") + "', getdate(), '','','', '','New Billing Parameter')", cn)


         If (cn.State = ConnectionState.Open) Then
            cn.Close()
        End If
        cn.Open()
        cmd.ExecuteNonQuery()
        cn.Close()
        
        FillGrid()

        txtCharge.Text = ""
        txtapp.SelectedItem.Text = ""
        txtCharge.Text=""
        cmdtype.SelectedItem.Text =""
        txtAmt.Text = ""
        cmdtypes.SelectedItem.Text=""
        RadioButtonList1.Items(0).Selected = True





        msgbox("Sent for Approval")
        

    End Sub
    Public Sub Getpart3()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select distinct(charge_type) from para_chargetype", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "para_chargetype")
            If (ds.Tables(0).Rows.Count > 0) Then
                 cmdtype.Items .Clear()
                cmdtype.AppendDataBoundItems =true
                cmdtype.Items .Add(New ListItem ("",""))
                cmdtype.DataSource = ds.Tables(0)
                cmdtype.DataValueField = "charge_type"
                'cmbType.ValueField = "Type"
                cmdtype.DataBind()
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

     Public Sub Getpart4()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select distinct(participant_types) from para_parttype", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "para_parttype")
            If (ds.Tables(0).Rows.Count > 0) Then
                 txtapp.Items .Clear()
                txtapp.AppendDataBoundItems =true
                txtapp.Items .Add(New ListItem ("",""))
                txtapp.DataSource = ds.Tables(0)
                txtapp.DataValueField = "participant_types"
                'cmbType.ValueField = "Type"
                txtapp.DataBind()
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
     Public Sub Getpart5()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select distinct(CompanyType) as Type from tbl_ParticipantsType", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "tbl_ParticipantsType")
            If (ds.Tables(0).Rows.Count > 0) Then
                 cmdtypes.Items .Clear()
                cmdtypes.AppendDataBoundItems =true
                cmdtypes.Items .Add(New ListItem ("",""))
                cmdtypes.DataSource = ds.Tables(0)
                cmdtypes.DataValueField = "Type"
                'cmbType.ValueField = "Type"
                cmdtypes.DataBind()
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

     Public Sub txtapp_selectedIndexChange() Handles txtapp.SelectedIndexChanged
        If txtapp.SelectedItem.Value = "Participant" Then
            tc.Visible=True
        Else
            tc.Visible=False

        End If
    End Sub

    
    Protected Sub ASPxButton1_Click(sender As Object, e As EventArgs) Handles ASPxButton1.Click

        Dim indicator As String 

         If RadioButtonList1.Items(1).Selected = True Then

            indicator = "FLAT_VALUE"
        Else If RadioButtonList1.Items(0).Selected = True Then
            indicator = "Percentage"
        End If




        Dim stmnt1 As String = "update para_bill set charge_name = '" & txtCharge.Text & "',charge_descriprion='" & txtdep.Text & "',charge_type='" & cmdtype.SelectedItem.Text & "',Amount='" & txtAmt.Text & "',apply_to='" & txtapp.SelectedItem.Text & "',participant_type='" & cmdtypes.SelectedItem.Text & "',indicator='" & indicator & "',limit='" & txtlimit.Text & "'where id='" & Session("deleteid") & "'"


        Dim cmd1 = New SqlCommand(stmnt1, cn)
        If (cn.State = ConnectionState.Open) Then
            cn.Close()
        End If
        cn.Open()
        cmd1.ExecuteNonQuery()
        cn.Close()

        FillGrid()
        txtCharge.Text = ""
        txtapp.SelectedItem.Text = ""
        txtCharge.Text=""
        cmdtype.SelectedItem.Text =""
        txtAmt.Text = ""
        cmdtypes.SelectedItem.Text=""
        RadioButtonList1.Items(0).Selected = True





        '   radlistChargeTo.Items(0).Selected = True
        Session("finish") = "no"
        Response.Redirect("parameter.aspx")




    End Sub

    Protected Sub ASPxButton2_Click(sender As Object, e As EventArgs) Handles ASPxButton2.Click



        Dim stmnt1 As String = "delete from para_bill  where id = '" & Session("deleteid") & "'"


        Dim cmd1 = New SqlCommand(stmnt1, cn)
        If (cn.State = ConnectionState.Open) Then
            cn.Close()
        End If
        cn.Open()
        cmd1.ExecuteNonQuery()
        cn.Close()

        FillGrid()
        txtCharge.Text = ""
        txtapp.SelectedItem.Text = ""
        txtCharge.Text=""
        cmdtype.SelectedItem.Text =""
        txtAmt.Text = ""
        cmdtypes.SelectedItem.Text=""
        RadioButtonList1.Items(0).Selected = True





        '   radlistChargeTo.Items(0).Selected = True
        Session("finish") = "yes"
        Response.Redirect("parameter.aspx")




    End Sub
    Public Sub FillGrid()
        Dim ds As New DataSet
        cmd = New SqlCommand("SELECT charge_name as [Charge Name],charge_descriprion as [Charge Description],charge_type as [Charge Type],Amount as [Amount/Percentage],apply_to as [Apply To],participant_type as [Participant Type],indicator,limit as [Maximum],ID as [S.No] from para_bill ", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "para_bill")

        If (ds.Tables(0).Rows.Count > 0) Then
            grdvCharges.DataSource = ds.Tables(0)
            grdvCharges.DataBind()
        Else
            'msgbox("not found")
        End If
    End Sub




    Protected Sub grdvCharges_SelectedIndexChanged(sender As Object, e As EventArgs) Handles grdvCharges.SelectedIndexChanged

        txtCharge.Text = grdvCharges.SelectedRow.Cells(1).Text
        txtdep.Text = grdvCharges.SelectedRow.Cells(2).Text
        cmdtype.SelectedItem.Text = grdvCharges.SelectedRow.Cells(3).Text
        txtAmt.Text = grdvCharges.SelectedRow.Cells(4).Text
        txtapp.SelectedItem.Text = grdvCharges.SelectedRow.Cells(5).Text
        cmdtypes.SelectedItem.Text= grdvCharges.SelectedRow.Cells(6).Text
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
        ASPxButton2.Visible = True
        ASPxButton1.Visible=True
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
