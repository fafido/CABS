
Partial Class Parameters_accreditation
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
                'GetTypes()
                'Getpart1()
                'GetTypes1()
                'GetTypes2()
                Getpart3()
               ' Getpart4()
                FillGrid()
                If Session("finish") = "yes" Then
                    Session("finish") = ""
                    msgbox("Billing Charges deleted successfully")
                
                ElseIf  Session("finish") = "no" Then
                    Session("finish") = ""
                    msgbox("Billing Charges updated successfully")


                End If
            End If


        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

  

    Protected Sub ASPxButton4_Click(sender As Object, e As EventArgs) Handles ASPxButton4.Click
       'If txtcapacity.Text = "" Then
       '     msgbox("Please Enter Capacity")
       '     Exit Sub
        If txtminamt.Text="" Then
            msgbox("Please Enter Application Amount")
            Exit Sub
        ElseIf txtmaxamt.Text="" Then
            msgbox("Please Enter Additional Amount")
            Exit Sub
        ElseIf txtAmount.Text=""Then
            msgbox("Please Enter Renewal Amount")
            Exit Sub
            ElseIf txtcode.Text=""Then
            msgbox("Please Enter Code")
            Exit Sub
        ElseIf cmdcap.Text="" Then
             msgbox("Please Enter From  Capacity")
            Exit Sub
         ElseIf txtto.Text="" Then
             msgbox("Please Enter To  Capacity")
            Exit Sub
        End If

        Dim stmnt As String = "insert into para_accreditation (from_capacity,to_capacity,AppCharges,AddCharges,RenewalCharges,ChargeType,charge_code) values (''" + cmdcap.Text + "'',''"+ txtto.Text +"'',''" & txtminamt.Text & "'',''" & txtmaxamt.Text & "'',''" & txtAmount.Text & "'',''"+ ASPxComboBox1.SelectedItem.Text +"'',''"& txtcode.Text &"'')"
        Dim descr As String = "New Billing Parameter added with From Capacity:" + cmdcap.Text + "  To Capacity:" + txtto.Text + "  ChargeType:" + ASPxComboBox1.SelectedItem.Text + "  Charge Code:" + txtcode.Text + ""
        cmd = New SqlCommand("insert into tbl_uncommitted ([description], script, [status], sender, date_inserted, comment, email_body, email_subject, email_to, category) values ('" + descr + "' , '" + stmnt + "', '0','" + Session("Username") + "', getdate(), '','','', '','New Billing Parameter')", cn)


        '  Dim cmd1 = New SqlCommand("insert into para_Billing (ChargeCode,ChargeName,PercentageOrValue,ApplyTo,Indicator) values ('" & txtChargeCode.Text & "','" & txtChargeName.Text & "'," & txtPercent.Text & ",'" & applyChgTo & "','" & indicator & "')", cn)
        If (cn.State = ConnectionState.Open) Then
            cn.Close()
        End If
        cn.Open()
        cmd.ExecuteNonQuery()
        cn.Close()
        FillGrid()

        cmdcap.Text = ""
        txtto.Text=""
        txtminamt.Text = ""
        txtmaxamt.Text = ""
        txtAmount.Text=""
        ASPxComboBox1.SelectedItem.Text=""
        txtcode.Text=""
        '   radlistChargeTo.Items(0).Selected = True
        

        msgbox("Sent for Approval")
        


    End Sub

     Public Sub Getpart3()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("  select distinct(charge_type) from para_chargetype", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "para_chargetype")
            If (ds.Tables(0).Rows.Count > 0) Then
                 ASPxComboBox1.Items .Clear()
                ASPxComboBox1.AppendDataBoundItems =true
                ASPxComboBox1.Items .Add(New ListItem ("",""))
                ASPxComboBox1.DataSource = ds.Tables(0)
                ASPxComboBox1.DataValueField = "charge_type"
                'cmbType.ValueField = "Type"
                ASPxComboBox1.DataBind()
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    ' Public Sub Getpart4()
    '    Try
    '        Dim ds As New DataSet
    '        cmd = New SqlCommand("select capacity_type from para_capacity order by id asc", cn)
    '        adp = New SqlDataAdapter(cmd)
    '        adp.Fill(ds, "para_capacity")
    '        If (ds.Tables(0).Rows.Count > 0) Then
    '             cmdcap.Items .Clear()
    '            cmdcap.AppendDataBoundItems =true
    '            cmdcap.Items .Add(New ListItem ("",""))
    '            cmdcap.DataSource = ds.Tables(0)
    '            cmdcap.DataValueField = "capacity_type"
    '            'cmbType.ValueField = "Type"
    '            cmdcap.DataBind()
    '        End If
    '    Catch ex As Exception
    '        msgbox(ex.Message)
    '    End Try
    'End Sub

    Public Sub FillGrid()
        Dim ds As New DataSet
        cmd = New SqlCommand("SELECT from_capacity as [From Capacity],to_capacity as [To Capacity], AppCharges as [Application Charges], AddCharges as [Additional Charges], RenewalCharges, ChargeType,charge_code as [Charge Code], ID as [S.No] from para_accreditation", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "para_accreditation")

        If (ds.Tables(0).Rows.Count > 0) Then
            grdvCharges.DataSource = ds.Tables(0)
            grdvCharges.DataBind()
        Else
            'msgbox("not found")
        End If
    End Sub

    Protected Sub ASPxButton2_Click(sender As Object, e As EventArgs) Handles ASPxButton2.Click



        Dim stmnt1 As String = "delete from para_accreditation  where id = '" & Session("deleteid") & "'"


        Dim cmd1 = New SqlCommand(stmnt1, cn)
        If (cn.State = ConnectionState.Open) Then
            cn.Close()
        End If
        cn.Open()
        cmd1.ExecuteNonQuery()
        cn.Close()

        FillGrid()
        cmdcap.Text = ""
        txtto.Text=""
        txtminamt.Text = ""
        txtmaxamt.Text = ""
        txtAmount.Text=""
        ASPxComboBox1.SelectedItem.Text=""
        txtcode.Text=""
        Session("finish") = "yes"
        Response.Redirect("accreditation.aspx")

    End Sub


    Protected Sub ASPxButton1_Click(sender As Object, e As EventArgs) Handles ASPxButton1.Click



        Dim stmnt1 As String = "update para_accreditation set from_capacity = '" & cmdcap.Text & "',to_capacity='" & txtto.Text & "',AppCharges='" & txtminamt.Text & "',AddCharges='" & txtmaxamt.Text & "',RenewalCharges='" & txtAmount.Text & "',ChargeType='" & ASPxComboBox1.SelectedItem.Text & "',charge_code='"&txtcode.Text &"' where id='"& Session("deleteid") &"'"


        Dim cmd1 = New SqlCommand(stmnt1, cn)
        If (cn.State = ConnectionState.Open) Then
            cn.Close()
        End If
        cn.Open()
        cmd1.ExecuteNonQuery()
        cn.Close()

        FillGrid()
        cmdcap.Text = ""
        txtto.Text=""
        txtminamt.Text = ""
        txtmaxamt.Text = ""
        txtAmount.Text=""
        ASPxComboBox1.SelectedItem.Text=""
        txtcode.Text=""
        Session("finish") = "no"
        Response.Redirect("accreditation.aspx")

    End Sub

    Protected Sub grdvCharges_SelectedIndexChanged(sender As Object, e As EventArgs) Handles grdvCharges.SelectedIndexChanged
        cmdcap.Text = grdvCharges.SelectedRow.Cells(1).Text
        txtto.Text = grdvCharges.SelectedRow.Cells(2).Text
        txtminamt.Text = grdvCharges.SelectedRow.Cells(3).Text
        txtmaxamt.Text = grdvCharges.SelectedRow.Cells(4).Text
        txtAmount.Text = grdvCharges.SelectedRow.Cells(5).Text
        ASPxComboBox1.SelectedItem.Text = grdvCharges.SelectedRow.Cells(6).Text
        txtcode.Text = grdvCharges.SelectedRow.Cells(7).Text
        Session("deleteid") = grdvCharges.SelectedRow.Cells(8).Text
        ASPxButton2.Visible = True
        ASPxButton1.Visible=True
        ASPxButton4.Visible = False
        

        
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
