Imports System.Data
Imports System.Data.SqlClient
Partial Class Administration_AccountPermisions
    Inherits System.Web.UI.Page
    Dim constr As String = (System.Configuration.ConfigurationManager.AppSettings("connpath"))
    Dim cn As New SqlConnection(constr)
    Dim cmd As SqlCommand
    Dim adp As SqlDataAdapter
    Dim ds As New DataSet
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

    End Sub
    Protected Sub BtnSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnSearch.Click
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("Select * from permissions where username = '" & txtSearchUser.Text & "'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "permissions")

            If (ds.Tables(0).Rows.Count > 0) Then
                txtUsername.Text = ds.Tables(0).Rows(0).Item("username").ToString
                txtSurname.Text = ds.Tables(0).Rows(0).Item("surname").ToString
                txtforenames.Text = ds.Tables(0).Rows(0).Item("Forenames").ToString
                txtID.Text = ds.Tables(0).Rows(0).Item("EmployeeCode").ToString
                tctDept.Text = ds.Tables(0).Rows(0).Item("Department").ToString
                txtCompany.Text = ds.Tables(0).Rows(0).Item("Company").ToString
                chkAudBatchCre.Checked = ds.Tables(0).Rows(0).Item("AudBatchCre").ToString
                chkAudBatchProce.Checked = ds.Tables(0).Rows(0).Item("AudBatchProc").ToString
                chkAuditSystemPerm.Checked = ds.Tables(0).Rows(0).Item("AudSystUserPerm").ToString
                chkAudMemberAccCre.Checked = ds.Tables(0).Rows(0).Item("AudMemberAccCre").ToString
                chkAudOrderCre.Checked = ds.Tables(0).Rows(0).Item("AudOrderCre").ToString
                chkAudOrderUpdate.Checked = ds.Tables(0).Rows(0).Item("AudOrdUp").ToString
                ChkAudSysUserAccessSchd.Checked = ds.Tables(0).Rows(0).Item("").ToString
                chkAudSysUserCre.Checked = ds.Tables(0).Rows(0).Item("").ToString
                chkAudSysUserProMan.Checked = ds.Tables(0).Rows(0).Item("").ToString
                ChkCorpAGMNote.Checked = ds.Tables(0).Rows(0).Item("CorpAGMNote").ToString
                chkCorpAnnualRep.Checked = ds.Tables(0).Rows(0).Item("CorpAnnRepUpload").ToString
                chkCorpBonusCreat.Checked = ds.Tables(0).Rows(0).Item("CorpBonusCre").ToString
                chkCorpBonusNotePrint.Checked = ds.Tables(0).Rows(0).Item("CorpBonusNotePrint").ToString
                ChkCorpBonusProce.Checked = ds.Tables(0).Rows(0).Item("CorpBonusProc").ToString
                chkCorpCheqAlloc.Checked = ds.Tables(0).Rows(0).Item("CorpCheqNumAllot").ToString
                chkCorpCheqRepl.Checked = ds.Tables(0).Rows(0).Item("CorpCheqRepl").ToString
                chkCorpDivCrea.Checked = ds.Tables(0).Rows(0).Item("CorpDivCreate").ToString
                chkCorpDivProc.Checked = ds.Tables(0).Rows(0).Item("CorpDivProc").ToString
                chkCorpDivRecon.Checked = ds.Tables(0).Rows(0).Item("CorpDivRecon").ToString
                ChkCorpOtherActions.Checked = ds.Tables(0).Rows(0).Item("CorpOtherEvents").ToString
                chkCorpRightLa.Checked = ds.Tables(0).Rows(0).Item("CorpRightsLaPrint").ToString
                chkCorpRightsAccpt.Checked = ds.Tables(0).Rows(0).Item("CorpRightsAccCap").ToString
                chkCorpRightsCreat.Checked = ds.Tables(0).Rows(0).Item("CorpRightsCre").ToString
                chkcorprightsplit.Checked = ds.Tables(0).Rows(0).Item("CorpRightsSplit").ToString
                chkCreateMemberAcc.Checked = ds.Tables(0).Rows(0).Item("CreateMemberAcc").ToString
                ChkEnqBatchHist.Checked = ds.Tables(0).Rows(0).Item("EnqBatchHist").ToString
                ChkEnqBonusAllot.Checked = ds.Tables(0).Rows(0).Item("EnqBonusAllot").ToString
                ChkEnqDivHist.Checked = ds.Tables(0).Rows(0).Item("EnqDivHist").ToString
                ChkEnqMemberAccDetail.Checked = ds.Tables(0).Rows(0).Item("EnqMemberAccDe").ToString
                chkEnqRightsAllot.Checked = ds.Tables(0).Rows(0).Item("EnqRightsAllot").ToString
                ChkEnqSystemAcc.Checked = ds.Tables(0).Rows(0).Item("EnqSystUserAcc").ToString
                chkEnqTradesSettlements.Checked = ds.Tables(0).Rows(0).Item("EnqTradesSett").ToString
                ChkEnqTransHist.Checked = ds.Tables(0).Rows(0).Item("EnqTransHist").ToString
                ChkEqnSystemUserAudit.Checked = ds.Tables(0).Rows(0).Item("EnqSystUserAudit").ToString
                chkFileATSUp.Checked = ds.Tables(0).Rows(0).Item("FileATSettUp").ToString
                chkFileEFTDivDown.Checked = ds.Tables(0).Rows(0).Item("FileSettEFTDown").ToString
                chkFileEFTsettleUp.Checked = ds.Tables(0).Rows(0).Item("FileSettEFTCon").ToString
                chkFileMemberAccdown.Checked = ds.Tables(0).Rows(0).Item("FileMemberAccDown").ToString
                chkFileMemberAccUp.Checked = ds.Tables(0).Rows(0).Item("FileMemberAccUp").ToString
                chkFileOrderDownl.Checked = ds.Tables(0).Rows(0).Item("FileOrdSumDown").ToString
                chkFileSettleEftDown.Checked = ds.Tables(0).Rows(0).Item("FileSettEFTDown").ToString
                chkMAudemberAccUp.Checked = ds.Tables(0).Rows(0).Item("AudMemberAccUp").ToString
                ChkMemberAccPort.Checked = ds.Tables(0).Rows(0).Item("EnqMemberAccPo").ToString
                chkOrdPurchasePos.Checked = ds.Tables(0).Rows(0).Item("OrdSalePos").ToString
                chkOrdRev.Checked = ds.Tables(0).Rows(0).Item("OrdRev").ToString
                chkOrdSalePos.Checked = ds.Tables(0).Rows(0).Item("OrdSalePos").ToString
                chkOrdUpdate.Checked = ds.Tables(0).Rows(0).Item("OrdUpdate").ToString
                chkPermissionAllot.Checked = ds.Tables(0).Rows(0).Item("AllotPermissions").ToString
                chkRptCompnySch.Checked = ds.Tables(0).Rows(0).Item("RptCompPortSchd").ToString
                chkRptCorpSch.Checked = ds.Tables(0).Rows(0).Item("RptCorpActSch").ToString
                chkRptMemberAccsAudit.Checked = ds.Tables(0).Rows(0).Item("RptMemberAccAud").ToString
                ChkRptMemberSchd.Checked = ds.Tables(0).Rows(0).Item("RptMemberAccSchd").ToString
                chkRptMemberTrans.Checked = ds.Tables(0).Rows(0).Item("RptSattSumSch").ToString
                chkRptOrderSumry.Checked = ds.Tables(0).Rows(0).Item("RptOrdSumSch").ToString
                chkRptSattlementSummary.Checked = ds.Tables(0).Rows(0).Item("RptSattSumSch").ToString
                chkRptTransBatchSummarySchd.Checked = ds.Tables(0).Rows(0).Item("RptTransBatchSum").ToString
                ChkTransBatchCre.Checked = ds.Tables(0).Rows(0).Item("TransBatchCre").ToString
                ChkTransBatchProc.Checked = ds.Tables(0).Rows(0).Item("TransBatchProc").ToString
                ChkTransBatchReve.Checked = ds.Tables(0).Rows(0).Item("TransBatchRev").ToString
                chkTransBatchUpdate.Checked = ds.Tables(0).Rows(0).Item("TransBatchUpdate").ToString
                ChkUpdateMemberAcc.Checked = ds.Tables(0).Rows(0).Item("UpdateMemberAcc").ToString
                chkUpdateSystemUser.Checked = ds.Tables(0).Rows(0).Item("UpdateSystemAccounts").ToString
                chkUserCreation.Checked = ds.Tables(0).Rows(0).Item("CreateSystemAccounts").ToString
            Else
                msgbox("User not found")
                txtUsername.Text = ""
                txtSurname.Text = ""
                txtforenames.Text = ""
                txtforenames.Text = ""
                txtID.Text = ""
                txtCompany.Text = ""
                tctDept.Text = ""
                chkAudBatchCre.Checked = False
                chkAudBatchProce.Checked = False
                chkAuditSystemPerm.Checked = False
                chkAudMemberAccCre.Checked = False
                chkAudOrderCre.Checked = False
                chkAudOrderUpdate.Checked = False
                ChkAudSysUserAccessSchd.Checked = False
                chkAudSysUserCre.Checked = False
                chkAudSysUserProMan.Checked = False
                ChkCorpAGMNote.Checked = False
                chkCorpAnnualRep.Checked = False
                chkCorpBonusCreat.Checked = False
                chkCorpBonusNotePrint.Checked = False
                ChkCorpBonusProce.Checked = False
                chkCorpCheqAlloc.Checked = False
                chkCorpCheqRepl.Checked = False
                chkCorpDivCrea.Checked = False
                chkCorpDivProc.Checked = False
                chkCorpDivRecon.Checked = False
                ChkCorpOtherActions.Checked = False
                chkCorpRightLa.Checked = False
                chkCorpRightsAccpt.Checked = False
                chkCorpRightsCreat.Checked = False
                chkcorprightsplit.Checked = False
                chkCreateMemberAcc.Checked = False
                ChkEnqBatchHist.Checked = False
                ChkEnqBonusAllot.Checked = False
                ChkEnqDivHist.Checked = False
                ChkEnqMemberAccDetail.Checked = False
                chkEnqRightsAllot.Checked = False
                ChkEnqSystemAcc.Checked = False
                chkEnqTradesSettlements.Checked = False
                ChkEnqTransHist.Checked = False
                ChkEqnSystemUserAudit.Checked = False
                chkFileATSUp.Checked = False
                chkFileEFTDivDown.Checked = False
                chkFileEFTsettleUp.Checked = False
                chkFileMemberAccdown.Checked = False
                chkFileMemberAccUp.Checked = False
                chkFileOrderDownl.Checked = False
                chkFileSettleEftDown.Checked = False
                chkMAudemberAccUp.Checked = False
                ChkMemberAccPort.Checked = False
                chkOrdPurchasePos.Checked = False
                chkOrdRev.Checked = False
                chkOrdSalePos.Checked = False
                chkOrdUpdate.Checked = False
                chkPermissionAllot.Checked = False
                chkRptCompnySch.Checked = False
                chkRptCorpSch.Checked = False
                chkRptMemberAccsAudit.Checked = False
                ChkRptMemberSchd.Checked = False
                chkRptMemberTrans.Checked = False
                chkRptOrderSumry.Checked = False
                chkRptSattlementSummary.Checked = False
                chkRptTransBatchSummarySchd.Checked = False
                ChkTransBatchCre.Checked = False
                ChkTransBatchProc.Checked = False
                ChkTransBatchReve.Checked = False
                chkTransBatchUpdate.Checked = False
                ChkUpdateMemberAcc.Checked = False
                chkUpdateSystemUser.Checked = False
                chkUserCreation.Checked = False
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub validation()
        Try
            Dim abatchcre, abacthpro, asysperm, amemberaccper, aordercre, aorderup, asys

        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Try
            Dim ds As New DataSet
            If (txtUsername.Text = "") Then
                msgbox("Select a user account")
                Exit Sub
            End If
            cmd = New SqlCommand("Update permissions set AudBatchCre=")
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
End Class
