Partial Class Parameters_SettlementParameters
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
                lblAccountNo1.Visible = False
                lblGuaranteeBankName.Visible = False
                lblGuaranteeBranchName.Visible = False
                lblSettlementBankName.Visible = False
                lblSettlemtnBranchName.Visible = False
                'cmbSettlementBank.Visible = False
                cmbSettlemntBanks.Visible = False
                cmbGuaranteeBanks.Visible = False
                SettlementBankCode.Visible = False
                GuaranteeBankCode.Visible = False
                cmbSettlemntBranchs.Visible = False
                cmbGuaranteeBranches.Visible = False
                txtSettlemntAccounts.Visible = False
                txtGuaranteeAccounts.Visible = False
                lblGuaranteeAccNo.Visible = False
                checkSessionState()
                GetSavedTplus()
                GetSavedCriteria()
                GetsavedSettlementTypes()
                GetBanks()
                GetBranches()
                GetGuaranteeBanks()
                GetGuaranteeBranches()
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub ASPxButton9_Click(sender As Object, e As EventArgs) Handles ASPxButton9.Click
        Try
            If (txtTplusDay.Text <> "") Then
                If IsNumeric(txtTplusDay.Text) Then
                    Dim rx As New DataSet
                    cmd = New SqlCommand("Select * from para_tplus where tplus = " & CInt(txtTplusDay.Text) & "", cn)
                    adp = New SqlDataAdapter(cmd)
                    adp.Fill(rx, "para_tplus")
                    If (rx.Tables(0).Rows.Count > 0) Then
                        msgbox("Parameter with the same setting already exists")
                        Exit Sub
                    End If
                    cmd = New SqlCommand("insert into para_Tplus(Tplus,Status) values (" & txtTplusDay.Text & ",'C')", cn)
                    If (cn.State = ConnectionState.Open) Then
                        cn.Close()
                    End If
                    cn.Open()
                    cmd.ExecuteNonQuery()
                    cn.Close()
                    txtTplusDay.Text = ""
                    GetSavedTplus()
                End If
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub GetSavedTplus()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select distinct (Tplus) as Tplus,status from para_Tplus order by status", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "para_Tplus")
            If (ds.Tables(0).Rows.Count > 0) Then
                'cmbTplus.DataSource = ds.Tables(0)
                'cmbTplus.ValueField = "Tplus"
                'cmbTplus.TextField = "Tplus"
                cmbCycle.DataSource = ds.Tables(0)
                cmbCycle.ValueField = "Tplus"
                cmbCycle.TextField = "Tplus"
                cmbCycle.DataBind()


            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub btnCycleSaveRules_Click(sender As Object, e As EventArgs) Handles btnCycleSaveRules.Click
        Try
            If (cmbCycle.SelectedItem.Text <> "") Then
                cmd = New SqlCommand("select * from tbl_SettlementCycle", cn)
                adp = New SqlDataAdapter(cmd)
                Dim dsi As New DataSet
                adp.Fill(dsi, "tbl_SettlementCycle")
                If (dsi.Tables(0).Rows.Count > 0) Then
                    cmd = New SqlCommand("delete from tbl_SettlementCycle", cn)
                    If (cn.State = ConnectionState.Open) Then
                        cn.Close()
                    End If
                    cn.Open()
                    cmd.ExecuteNonQuery()
                    cn.Close()


                End If
                cmd = New SqlCommand("insert into tbl_SettlementCycle (TplusDays,Updated_on) values (" & cmbCycle.SelectedItem.Text & ",'" & Now.Date & "')", cn)
                If (cn.State = ConnectionState.Open) Then
                    cn.Close()
                End If
                cn.Open()
                cmd.ExecuteNonQuery()
                cn.Close()

                If (cmbCycle.SelectedItem.Text <> "") Then
                    cmd = New SqlCommand("select * from tbl_settlementCycle where tplusDays=" & cmbCycle.SelectedItem.Text & "", cn)
                    adp = New SqlDataAdapter(cmd)
                    Dim ds As New DataSet
                    adp.Fill(ds, "tbl_settlementCycle")
                    If (ds.Tables(0).Rows.Count > 0) Then
                        CycleStatus.Text = "Active"
                    Else
                        CycleStatus.Text = "Inactive"
                    End If
                End If
                msgbox("Rule saved")
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub cmbCycle_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbCycle.SelectedIndexChanged
        Try
            If (cmbCycle.SelectedItem.Text <> "") Then
                cmd = New SqlCommand("select * from tbl_settlementCycle where tplusDays=" & cmbCycle.SelectedItem.Text & "", cn)
                adp = New SqlDataAdapter(cmd)
                Dim ds As New DataSet
                adp.Fill(ds, "tbl_settlementCycle")
                If (ds.Tables(0).Rows.Count > 0) Then
                    CycleStatus.Text = "Active"
                Else
                    CycleStatus.Text = "Inactive"
                End If
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub ASPxButton5_Click(sender As Object, e As EventArgs) Handles ASPxButton5.Click
        Try
            If (txtCriteriaName.Text <> "") Then
                Dim ds As New DataSet
                cmd = New SqlCommand("select * from para_criteria where criterianame='" & Trim(txtCriteriaName.Text) & "'", cn)
                adp = New SqlDataAdapter(cmd)
                adp.Fill(ds, "para_criteria")
                If (ds.Tables(0).Rows.Count > 0) Then
                    msgbox("Enterted Criteria already exits")
                    Exit Sub
                End If
                cmd = New SqlCommand("insert into para_criteria (CriteriaName,Status) values ('" & txtCriteriaName.Text & "','C')", cn)
                If (cn.State = ConnectionState.Open) Then
                    cn.Close()
                End If
                cn.Open()
                cmd.ExecuteNonQuery()
                cn.Close()

                msgbox("Record Saved")
                txtCriteriaName.Text = ""
                GetSavedCriteria()
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub GetSavedCriteria()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select distinct (criterianame),status from para_criteria order by status", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "para_criteria")
            If (ds.Tables(0).Rows.Count > 0) Then
                cmbCriteria.DataSource = ds.Tables(0)
                cmbCriteria.ValueField = "criterianame"
                cmbCriteria.TextField = "criterianame"
                cmbCriteria.DataBind()
            Else
                cmbCriteria.Items.Clear()
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub ASPxButton11_Click(sender As Object, e As EventArgs) Handles ASPxButton11.Click
        Try
            If (txtSettlementBank.Text <> "") Then
                Dim ds As New DataSet
                cmd = New SqlCommand("select * from para_settlementBankType where para_SettlementBank='" & txtSettlementBank.Text & "'", cn)
                adp = New SqlDataAdapter(cmd)
                adp.Fill(ds, "para_settlementBankType")
                If (ds.Tables(0).Rows.Count > 0) Then
                    msgbox("entered bank type already Exist")
                    Exit Sub
                End If
                If (txtSettlementBank.Text = "Commercial Bank" Or txtSettlementBank.Text = "Central Bank") Then
                Else

                    msgbox("Enter either a Commercial Bank or a Central Bank")
                    Exit Sub
                End If
                cmd = New SqlCommand("insert into para_settlementBankType(para_SettlementBank,status) values ('" & txtSettlementBank.Text & "','C')", cn)
                If (cn.State = ConnectionState.Open) Then
                    cn.Close()
                End If
                cn.Open()
                cmd.ExecuteNonQuery()
                cn.Close()
                msgbox("Bank Type Saved")
                txtSettlementBank.Text = ""
                GetsavedSettlementTypes()
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub GetsavedSettlementTypes()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select distinct (para_SettlementBank) from para_settlementBankType", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "para_SettlementBank")
            If (ds.Tables(0).Rows.Count > 0) Then
                cmbSettlementBank.DataSource = ds.Tables(0)
                cmbSettlementBank.ValueField = "para_SettlementBank"
                cmbSettlementBank.TextField = "para_settlementBank"
                cmbSettlementBank.DataBind()
            Else
                cmbSettlementBank.Items.Clear()
            End If

        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub


    Protected Sub cmbSettlementBank_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbSettlementBank.SelectedIndexChanged
        Try
            If (cmbSettlementBank.SelectedItem.Text <> "Central Bank") Then
                lblAccountNo1.Visible = True
                lblGuaranteeBankName.Visible = True
                lblGuaranteeBranchName.Visible = True
                lblSettlementBankName.Visible = True
                lblSettlemtnBranchName.Visible = True
                cmbSettlemntBanks.Visible = True
                cmbGuaranteeBanks.Visible = True
                SettlementBankCode.Visible = True
                GuaranteeBankCode.Visible = True
                cmbSettlemntBranchs.Visible = True
                cmbGuaranteeBranches.Visible = True
                txtSettlemntAccounts.Visible = True
                txtGuaranteeAccounts.Visible = True
                lblGuaranteeAccNo.Visible = True
            Else
                lblAccountNo1.Visible = True
                lblGuaranteeBankName.Visible = False
                lblGuaranteeBranchName.Visible = False
                lblSettlementBankName.Visible = False
                lblSettlemtnBranchName.Visible = False
                cmbSettlemntBanks.Visible = False
                cmbGuaranteeBanks.Visible = False
                SettlementBankCode.Visible = False
                GuaranteeBankCode.Visible = False
                cmbSettlemntBranchs.Visible = False
                cmbGuaranteeBranches.Visible = False
                txtSettlemntAccounts.Visible = True
                txtGuaranteeAccounts.Visible = False
                lblGuaranteeAccNo.Visible = False
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub GetBanks()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select distinct (bank_name) from para_bank", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "para_bank")
            If (ds.Tables(0).Rows.Count > 0) Then
                cmbSettlemntBanks.DataSource = ds.Tables(0)
                cmbSettlemntBanks.ValueField = "bank_Name"
                cmbSettlemntBanks.TextField = "bank_name"
                cmbSettlemntBanks.DataBind()
                GetSelectedBankCode()

            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub GetSelectedBankCode()
        Try
            Dim d As New DataSet
            cmd = New SqlCommand("select distinct (bank) from para_bank where bank_name='" & cmbSettlemntBanks.SelectedItem.Text & "'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(d, "para_bank")
            If (d.Tables(0).Rows.Count > 0) Then
                SettlementBankCode.Text = d.Tables(0).Rows(0).Item("bank").ToString
            Else
                SettlementBankCode.Text = ""
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub GetBranches()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select distinct (branch_name),bank from para_branch where bank='" & SettlementBankCode.Text & "'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "para_branch")
            If (ds.Tables(0).Rows.Count > 0) Then
                cmbSettlemntBranchs.DataSource = ds.Tables(0)
                cmbSettlemntBranchs.ValueField = "branch_name"
                cmbSettlemntBranchs.TextField = "branch_name"
                cmbSettlemntBranchs.DataBind()
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub cmbSettlemntBanks_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbSettlemntBanks.SelectedIndexChanged
        Try
            GetSelectedBankCode()
            GetBranches()
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Public Sub GetGuaranteeBanks()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select distinct (bank_name) from para_bank", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "para_bank")
            If (ds.Tables(0).Rows.Count > 0) Then
                cmbGuaranteeBanks.DataSource = ds.Tables(0)
                cmbGuaranteeBanks.ValueField = "bank_Name"
                cmbGuaranteeBanks.TextField = "bank_name"
                cmbGuaranteeBanks.DataBind()
                GetSelectedGuaranteeBankCode()

            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub GetSelectedGuaranteeBankCode()
        Try
            Dim d As New DataSet
            cmd = New SqlCommand("select distinct (bank) from para_bank where bank_name='" & cmbGuaranteeBanks.SelectedItem.Text & "'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(d, "para_bank")
            If (d.Tables(0).Rows.Count > 0) Then
                GuaranteeBankCode.Text = d.Tables(0).Rows(0).Item("bank").ToString
            Else
                GuaranteeBankCode.Text = ""
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub GetGuaranteeBranches()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select distinct (branch_name),bank from para_branch where bank='" & GuaranteeBankCode.Text & "'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "para_branch")
            If (ds.Tables(0).Rows.Count > 0) Then
                cmbGuaranteeBranches.DataSource = ds.Tables(0)
                cmbGuaranteeBranches.ValueField = "branch_name"
                cmbGuaranteeBranches.TextField = "branch_name"
                cmbGuaranteeBranches.DataBind()
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub cmbGuaranteeBanks_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbGuaranteeBanks.SelectedIndexChanged
        GetSelectedGuaranteeBankCode()
        GetGuaranteeBranches()
    End Sub

    Protected Sub ASPxButton14_Click(sender As Object, e As EventArgs) Handles ASPxButton14.Click
        Try
            cmd = New SqlCommand("insert into para_VerificationCriterias (Criteria,Status) values ('" & txtOrderVerification.Text & "','C')", cn)
            If (cn.State = ConnectionState.Open) Then
                cn.Close()
            End If
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()
            msgbox("Saved")
            txtOrderVerification.Text = ""
            GetOrdersVerificationCriterias()
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub GetOrdersVerificationCriterias()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select distinct (Criteria) from para_VerificationCriterias ", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "para_VerificationCriterias")
            If (ds.Tables(0).Rows.Count > 0) Then
                cmbOrdersVifications.DataSource = ds.Tables(0)
                cmbOrdersVifications.ValueField = "Criteria"
                cmbOrdersVifications.TextField = "Criteria"
                cmbOrdersVifications.DataBind()
            Else
                cmbOrdersVifications.Items.Clear()
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
End Class
