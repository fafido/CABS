Partial Class Parameters_tax
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
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Page.MaintainScrollPositionOnPostBack = True
            If (Not IsPostBack) Then
                Getpart2()
                Getpart3()
                FillGrid()
                If Session("finish") = "yes" Then
                    Session("finish") = ""
                    msgbox("Tax Charges added successfully, awaiting approval")
                ElseIf Session("finish") = "uyes" Then
                    Session("finish") = ""
                    msgbox(" Tax Charges updated successfully")
                ElseIf Session("finish") = "dyes" Then
                    Session("finish") = ""
                    msgbox(" Tax Charges removed successfully")
                End If
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub Getpart2()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select distinct(CompanyType) from  tbl_ParticipantsType", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "tbl_ParticipantsType")
            If (ds.Tables(0).Rows.Count > 0) Then
                cmbParticipanttype.DataSource = ds.Tables(0)
                cmbParticipanttype.DataValueField = "CompanyType"
                cmbParticipanttype.DataTextField = "CompanyType"
                cmbParticipanttype.DataBind()
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub Getpart3()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select distinct (state) from para_states where country='Pakistan'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "para_city_location")
            If (ds.Tables(0).Rows.Count > 0) Then
                cmbCustLocation.DataSource = ds.Tables(0)
                cmbCustLocation.DataValueField = "state"
                cmbCustLocation.DataTextField = "state"
                cmbCustLocation.DataBind()
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Protected Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If IsNumeric(txtSalesTax.Text) = False Or IsNumeric(txtSalesTaxWithholding.Text) = False Or IsNumeric(txtIncomeTaxWithholding.Text) = False Then
            msgbox("Please enter the rates")
            Exit Sub
        End If
        Dim indicator As String = "Percentage"
        Dim LocationSave As String = ""
        Dim ParticipantCategory As String = ""
        If cmbsecuritytype.SelectedValue = "Indirect" Then
            If cmbCustLocation.Text = "" Then
                msgbox("Select Participant Location")
                Exit Sub
            End If
            LocationSave = cmbCustLocation.SelectedValue
        Else
            LocationSave = ""
        End If
        If cmbParticipanttype.SelectedValue = "DEPOSITOR" Or cmbParticipanttype.SelectedValue = "WAREHOUSE" Then
            If cmbParticipantCategory.Text = "" Then
                msgbox("Select Participant Category")
                Exit Sub
            End If
            ParticipantCategory = cmbParticipantCategory.SelectedValue
        Else
            ParticipantCategory = ""
        End If
        Dim stmnt As String = "insert into para_taxes (SalesTax,IncomeTaxWithholding,SalesTaxWithholding,tax_type,applyto,participant_type,location,indicator) values (''" + txtSalesTax.Text + "'',''" + txtIncomeTaxWithholding.Text + "'',''" + txtSalesTaxWithholding.Text + "'',''" + cmbsecuritytype.SelectedValue + "'',''" + ParticipantCategory + "'',''" + cmbParticipanttype.SelectedValue + "'',''" + LocationSave + "'',''" & indicator & "'')"
        Dim descr As String = "New Tax Parameter added with Tax Type:" + cmbsecuritytype.SelectedValue + " Apply To:" + cmbParticipantCategory.SelectedValue + "  SalesTax:" + txtSalesTax.Text + ", Income Tax Withholding:" + txtIncomeTaxWithholding.Text + ",Sales Tax Withholding:" + txtSalesTaxWithholding.Text + " "
        cmd = New SqlCommand("insert into tbl_uncommitted ([description], script, [status], sender, date_inserted, comment, email_body, email_subject, email_to, category) values ('" + descr + "' , '" + stmnt + "', '0','" + Session("Username") + "', getdate(), '','','', '','New Billing Parameter')", cn)
        If (cn.State = ConnectionState.Open) Then
            cn.Close()
        End If
        cn.Open()
        cmd.ExecuteNonQuery()
        cn.Close()
        Session("finish") = "yes"
        Response.Redirect(Request.RawUrl)
    End Sub
    Protected Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        If IsNumeric(txtSalesTax.Text) = False Or IsNumeric(txtSalesTaxWithholding.Text) = False Or IsNumeric(txtIncomeTaxWithholding.Text) = False Then
            msgbox("Please enter the rates")
            Exit Sub
        End If
        Dim indicator As String = "Percentage"
        Dim LocationSave As String = ""
        Dim ParticipantCategory As String = ""
        If cmbsecuritytype.SelectedValue = "Indirect" Then
            If cmbCustLocation.Text = "" Then
                msgbox("Select Participant Location")
                Exit Sub
            End If
            LocationSave = cmbCustLocation.SelectedValue
        Else
            LocationSave = ""
        End If
        If cmbParticipanttype.SelectedValue = "DEPOSITOR" Or cmbParticipanttype.SelectedValue = "WAREHOUSE" Then
            If cmbParticipantCategory.Text = "" Then
                msgbox("Select Participant Category")
                Exit Sub
            End If
            ParticipantCategory = cmbParticipantCategory.SelectedValue
        Else
            ParticipantCategory = ""
        End If
        Dim stmnt1 As String = "update para_taxes set applyto='" & ParticipantCategory & "',location='" & LocationSave & "',IncomeTaxWithholding='" & txtIncomeTaxWithholding.Text & "',SalesTaxWithholding='" & txtSalesTaxWithholding.Text & "',tax_type = '" & cmbsecuritytype.SelectedValue & "',SalesTax='" & txtSalesTax.Text & "',indicator='" & indicator & "' where id='" & Session("updateID") & "'"
        Dim cmd1 = New SqlCommand(stmnt1, cn)
        If (cn.State = ConnectionState.Open) Then
            cn.Close()
        End If
        cn.Open()
        cmd1.ExecuteNonQuery()
        cn.Close()
        FillGrid()
        Session("updateID") = ""
        Session("finish") = "uyes"
        Response.Redirect(Request.RawUrl)
    End Sub
    Public Sub FillGrid()
        Dim ds As New DataSet
        cmd = New SqlCommand("SELECT *,FORMAT(SalesTaxWithholding,'#,###.00','en-us') as SalesTaxWithholding1,FORMAT(SalesTax,'#,###.00','en-us') as SalesTax1,FORMAT(IncomeTaxWithholding,'#,###.00','en-us') as IncomeTaxWithholding1 FROM para_taxes order by id desc", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "para_taxes")
        If (ds.Tables(0).Rows.Count > 0) Then
            grdvCharges.DataSource = ds.Tables(0)
            grdvCharges.DataBind()
        Else
            'msgbox("not found")
        End If
    End Sub
    Protected Sub grdvCharges_RowCommand(sender As Object, e As DevExpress.Web.ASPxGridView.ASPxGridViewRowCommandEventArgs)
        Dim myID As String = e.KeyValue.ToString
        If e.CommandArgs.CommandName = "Select" Then
            getExistingChargeCode(myID)
        ElseIf e.CommandArgs.CommandName = "Delete" Then
            Try
                Using cn = New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("connpath"))
                    Using cmd As New SqlCommand("DELETE FROM para_taxes WHERE ID='" & myID & "'", cn)
                        If cn.State = ConnectionState.Open Then cn.Close()
                        cn.Open()
                        cmd.ExecuteNonQuery()
                        cn.Close()
                    End Using
                End Using
            Catch ex As Exception
            End Try
            Session("finish") = "dyes"
            Response.Redirect(Request.RawUrl)
        End If
    End Sub
    Sub getExistingChargeCode(ByVal recID As String)
        Dim sql_str As String = ""
        sql_str = "SELECT *,FORMAT(SalesTaxWithholding,'#,###.00','en-us') as SalesTaxWithholding1,FORMAT(SalesTax,'#,###.00','en-us') as SalesTax1,FORMAT(IncomeTaxWithholding,'#,###.00','en-us') as IncomeTaxWithholding1 FROM para_taxes B WHERE B.ID=@recID"
        Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("conpath").ConnectionString)
            Using cmd As New SqlCommand(sql_str, con)
                cmd.Parameters.AddWithValue("@recID", recID)
                Dim dss As New DataSet
                Dim adp = New SqlDataAdapter(cmd)
                adp.Fill(dss, "para_taxes")
                If dss.Tables(0).Rows.Count > 0 Then
                    Session("updateID") = recID
                    Dim dr As DataRow = dss.Tables(0).Rows(0)
                    Try
                        cmbsecuritytype.SelectedValue = dr.Item("tax_type").ToString
                    Catch ex As Exception
                    End Try
                    Try
                        cmbParticipantCategory.SelectedValue = dr.Item("applyto").ToString
                    Catch ex As Exception
                    End Try
                    Try
                        cmbParticipanttype.SelectedValue = dr.Item("participant_type").ToString
                    Catch ex As Exception
                    End Try
                    Try
                        cmbCustLocation.SelectedValue = dr.Item("location").ToString
                    Catch ex As Exception
                    End Try
                    txtSalesTax.Text = dr.Item("SalesTax1").ToString
                    txtIncomeTaxWithholding.Text = dr.Item("IncomeTaxWithholding1").ToString
                    txtSalesTaxWithholding.Text = dr.Item("SalesTaxWithholding1").ToString
                    cmbsecuritytype_SelectedIndexChanged(DBNull.Value, New EventArgs)
                    cmbParticipanttype_SelectedIndexChanged(DBNull.Value, New EventArgs)
                    btnUpdate.Visible = True
                    btnSave.Visible = False
                End If
            End Using
        End Using
    End Sub
    Protected Sub cmbsecuritytype_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbsecuritytype.SelectedIndexChanged
        If cmbsecuritytype.SelectedValue = "Direct" Then
            cmbCustLocation.Visible = False
            ASPxLabel3.Visible = False
        Else
            cmbCustLocation.Visible = True
            ASPxLabel3.Visible = True
        End If
    End Sub
    Protected Sub cmbParticipanttype_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbParticipanttype.SelectedIndexChanged
        If cmbParticipanttype.SelectedValue = "DEPOSITOR" Or cmbParticipanttype.SelectedValue = "WAREHOUSE" Then
            ASPxLabel2.Visible = True
            cmbParticipantCategory.Visible = True
        Else
            ASPxLabel2.Visible = False
            cmbParticipantCategory.Visible = False
        End If
    End Sub
End Class
