Imports System.Net.Mail
Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Imports System
Imports System.Configuration
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls
Partial Class TransferSec_ChargesDiscounts
    Inherits System.Web.UI.Page
    Dim constr As String = (System.Configuration.ConfigurationManager.AppSettings("connpath"))
    Dim cn As New SqlConnection(constr)
    Dim adp As SqlDataAdapter
    Dim cmd As SqlCommand
    Shared random As New Random()
    Dim Mail As New MailMessage
    Public password, numb, codec As String
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
                getAllParticipantTypes()
                loadALLDiscountCodes()
                If Session("finish") = "yes" Then
                    Session("finish") = ""
                    msgbox("Discount Successfully submitted, awaiting approval")
                End If
                If Session("finishU") = "yes" Then
                    Session("finishU") = ""
                    msgbox("Discount Successfully updated, awaiting approval")
                End If
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Sub getAllParticipantTypes()
        Using cn = New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("connpath"))
            Dim ds As New DataSet
            Dim cmd = New SqlCommand("select * from tbl_ParticipantsType order by CompanyType", cn)
            Dim adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "tbl_ParticipantsType")
            If ds.Tables(0).Rows.Count > 0 Then
                cmbParticipantType.DataSource = ds
                cmbParticipantType.ValueField = "CompanyType"
                cmbParticipantType.TextField = "CompanyType"
                cmbParticipantType.DataBind()
            Else
            End If
        End Using
    End Sub
    Sub getChargeCodes()
        Using cn = New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("connpath"))
            Dim ds As New DataSet
            Dim cmd = New SqlCommand("select ChargeSUBType + ' ' +format(PercAmount,'#,###.00','en-us')+' '+ChargeInterval as chargeDesc,ChargeCode from ParaCharge WHERE ParticipantType=@ParticipantType order by ID DESC", cn)
            cmd.Parameters.AddWithValue("@ParticipantType", cmbParticipantType.Value)
            Dim adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "ParaCharge")
            If ds.Tables(0).Rows.Count > 0 Then
                cmbChargeCode.Text = ""
                cmbChargeCode.DataSource = ds
                cmbChargeCode.ValueField = "ChargeCode"
                cmbChargeCode.TextField = "chargeDesc"
                cmbChargeCode.DataBind()
            Else
            End If
        End Using
    End Sub
    Protected Sub cmbParticipantType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbParticipantType.SelectedIndexChanged
        getParticipants()
        getChargeCodes()
    End Sub
    Sub getParticipants()
        Dim strSQL As String = ""
        If cmbParticipantType.Text = "DEPOSITOR" Then
            strSQL = "SELECT 'ALL' as Company_Code,'ALL' AS Company_name,'' as ChargeCd,'' as DiscountCd UNION SELECT CDS_Number as Company_Code,ISNULL(Surname,'')+' '+ISNULL(Forenames,'') AS Company_name,'' as ChargeCd,'' as DiscountCd from Accounts_Clients --order by Surname"
        Else
            strSQL = "SELECT * FROM (SELECT 'ALL' as Company_Code,'ALL' AS Company_name,'' as ChargeCd,'' as DiscountCd UNION SELECT Company_Code,Company_name,'' as ChargeCd,'' as DiscountCd FROM Client_Companies WHERE Company_type='" & cmbParticipantType.Text & "')A ORDER BY A.Company_name"
        End If
        Using cn = New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("connpath"))
            Dim ds As New DataSet
            Dim cmd = New SqlCommand(strSQL, cn)
            Dim adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "Client_Companies")
            If ds.Tables(0).Rows.Count > 0 Then
                grdParticipants.DataSource = ds
                grdParticipants.DataBind()
                dfPanel.Visible = True
            Else
            End If
        End Using
    End Sub
    Protected Sub rdbIndicator_SelectedIndexChanged(sender As Object, e As EventArgs) Handles rdbIndicator.SelectedIndexChanged
        If rdbIndicator.SelectedValue = "Flat" Then
            ASPxLabel7.Text = "Amount"
        Else
            ASPxLabel7.Text = "Percentage"
        End If
    End Sub
    Sub saveDiscount()
        If cmbChargeCode.Text = "" Then
            msgbox("Select charge code")
            Exit Sub
        End If
        If rdbIndicator.SelectedIndex = -1 Then
            msgbox("Select charge indicator")
            Exit Sub
        End If
        If IsNumeric(txtPercAmount.Text) = False Then
            msgbox("Enter rate/flat amount")
            Exit Sub
        End If
        If cmbParticipantType.Text = "" Then
            msgbox("Select Participant Type")
            Exit Sub
        End If
        If ParticipantSelected() = False Then
            msgbox("Select participants")
            Exit Sub
        End If
        If IsDate(txtExpiryDate.Text) = False Then
            msgbox("Select Expiry date")
            Exit Sub
        End If
        If discountAlreadyExists() = True Then
            msgbox("Discount on that charge already exists for the some selected participants")
            Exit Sub
        End If
        Dim DiscountCode As String = "DISC" & Session("Username").ToString.ToUpper & Date.Now.ToString("ddMMMyyyyhhmmfff").ToUpper
        Using cn = New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("connpath"))
            Dim stmnt As String = " INSERT INTO ParaChargeDiscounts([ExpiryDate],[ParticipantType], [ChargeCode], [ChargeDesc], [Indicator], [PercAmount], [CreatedBy], [DiscountCode]) "
            stmnt = stmnt & " VALUES(''" & validateDate(txtExpiryDate.Text) & "'',''" & cmbParticipantType.Value & "'',''" & cmbChargeCode.Value & "'',''" & cmbChargeCode.Text & "'',''" & rdbIndicator.SelectedValue & "'',''" & validateNumeric(txtPercAmount.Text) & "'',''" & Session("Username") & "'',''" & DiscountCode & "'') "
            stmnt = stmnt & getParticipantInsertString(cmbChargeCode.Value, DiscountCode)
            Dim descr As String = "New Charge Discount added with Charge code:" + cmbChargeCode.Text + " Amount/% :" + txtPercAmount.Text + ""
            Using cmd As New SqlCommand("insert into tbl_uncommitted ([description], script, [status], sender, date_inserted, comment, email_body, email_subject, email_to, category) values ('" + descr + "' , '" + stmnt + "', '0','" + Session("Username") + "', getdate(), '','','', '','New Billing Parameter')", cn)
                If cn.State = ConnectionState.Open Then cn.Close()
                cn.Open()
                cmd.ExecuteNonQuery()
                cn.Close()
            End Using
        End Using
        Session("finish") = "yes"
        Response.Redirect(Request.RawUrl)
    End Sub
    Function validateNumeric(inp As String) As Object
        inp = inp.Replace(",", "")
        Return IIf(IsNumeric(Trim(inp)) = False, 0, inp)
    End Function
    Public Sub loadALLDiscountCodes()
        Dim ds As New DataSet
        cmd = New SqlCommand("  Select *,format(PercAmount,'#,###.00','en-us') AS PercAmount1,format(ExpiryDate,'dd MMMM yyyy','en-us') as ExpiryDate1 from ParaChargeDiscounts order by id desc", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "ParaCharge")
        If (ds.Tables(0).Rows.Count > 0) Then
            grdChargesCreated.DataSource = ds
            grdChargesCreated.DataBind()
        End If
    End Sub
    Protected Sub grdChargesCreated_RowCommand(sender As Object, e As DevExpress.Web.ASPxGridView.ASPxGridViewRowCommandEventArgs)
        Dim myID As String = e.KeyValue.ToString
        If e.CommandArgs.CommandName = "Select" Then
            getExistingChargeCode(myID)
        ElseIf e.CommandArgs.CommandName = "Delete" Then
            Try
                Using cn = New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("connpath"))
                    Using cmd As New SqlCommand("DELETE B FROM ParaChargeDiscounts A JOIN ParaChargeDiscountsParticipant B ON A.ChargeCode=B.ChargeCode AND A.DiscountCode=B.DiscountCode WHERE A.ID='" & myID & "' DELETE FROM ParaChargeDiscounts WHERE ID='" & myID & "'", cn)
                        If cn.State = ConnectionState.Open Then cn.Close()
                        cn.Open()
                        cmd.ExecuteNonQuery()
                        cn.Close()
                    End Using
                End Using
            Catch ex As Exception
            End Try
        End If
    End Sub
    Sub getExistingChargeCode(ByVal recID As String)
        Dim sql_str As String = ""
        sql_str = "select B.*,format(B.PercAmount,'#,###.00','en-us') AS PercAmount1,format(ExpiryDate,'dd MMMM yyyy','en-us') as ExpiryDate1 from ParaChargeDiscounts B WHERE B.ID=@recID"
        Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("conpath").ConnectionString)
            Using cmd As New SqlCommand(sql_str, con)
                cmd.Parameters.AddWithValue("@recID", recID)
                Dim dss As New DataSet
                Dim adp = New SqlDataAdapter(cmd)
                adp.Fill(dss, "ParaCharge")
                If dss.Tables(0).Rows.Count > 0 Then
                    Session("updateID") = recID
                    Dim dr As DataRow = dss.Tables(0).Rows(0)
                    Try
                        cmbParticipantType.Value = dr.Item("ParticipantType").ToString
                    Catch ex As Exception
                    End Try
                    getChargeCodes()
                    Session("updateChargeCode") = dr.Item("ChargeCode").ToString
                    Session("updateDiscountCode") = dr.Item("DiscountCode").ToString
                    Try
                        cmbChargeCode.Value = dr.Item("ChargeCode").ToString
                    Catch ex As Exception
                    End Try
                    Try
                        rdbIndicator.SelectedValue = dr.Item("Indicator").ToString
                    Catch ex As Exception
                    End Try
                    rdbIndicator_SelectedIndexChanged(DBNull.Value, New EventArgs)
                    txtPercAmount.Text = dr.Item("PercAmount1").ToString
                    Try
                        txtExpiryDate.Text = dr.Item("ExpiryDate1").ToString
                    Catch ex As Exception
                    End Try
                    getParticipantsUpdate()
                    panelUPDATE.Visible = True
                    PanelSAVE.Visible = False
                End If
            End Using
        End Using
    End Sub
    Sub getParticipantsUpdate()
        Dim strSQL As String = ""
        If cmbParticipantType.Text = "DEPOSITOR" Then
            strSQL = "SELECT DISTINCT Company_Code,Company_name,ChargeCd,DiscountCd FROM (SELECT Company_Code,Company_name,'' as ChargeCd,'' as DiscountCd FROM (SELECT 'ALL' as Company_Code,'ALL' AS Company_name,'' as ChargeCd,'' as DiscountCd UNION SELECT CDS_Number as Company_Code,ISNULL(Surname,'')+' '+ISNULL(Forenames,'') AS Company_name,'' as ChargeCd,'' as DiscountCd from Accounts_Clients)C WHERE C.Company_Code NOT IN (SELECT DISTINCT ParticipantCode FROM ParaChargeDiscountsParticipant WHERE DiscountCode='" & Session("updateDiscountCode") & "') UNION  SELECT ParticipantCode AS Company_Code,Participant AS Company_name,ChargeCode as ChargeCd,DiscountCode as DiscountCd FROM ParaChargeDiscountsParticipant WHERE DiscountCode='" & Session("updateDiscountCode") & "' )A ORDER BY A.Company_name"
        Else
            strSQL = "SELECT DISTINCT Company_Code,Company_name,ChargeCd,DiscountCd FROM (SELECT Company_Code,Company_name,'' as ChargeCd,'' as DiscountCd FROM (SELECT 'ALL' as Company_Code,'ALL' AS Company_name,'' as ChargeCd,'' as DiscountCd UNION SELECT Company_Code,Company_name,'' as ChargeCd,'' as DiscountCd FROM Client_Companies WHERE Company_type='" & cmbParticipantType.Text & "' )C WHERE C.Company_Code NOT IN (SELECT DISTINCT ParticipantCode FROM ParaChargeDiscountsParticipant WHERE DiscountCode='" & Session("updateDiscountCode") & "') UNION  SELECT ParticipantCode AS Company_Code,Participant AS Company_name,ChargeCode as ChargeCd,DiscountCode as DiscountCd FROM ParaChargeDiscountsParticipant WHERE DiscountCode='" & Session("updateDiscountCode") & "' )A ORDER BY A.Company_name"
        End If
        Using cn = New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("connpath"))
            Dim ds As New DataSet
            Dim cmd = New SqlCommand(strSQL, cn)
            Dim adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "Client_Companies")
            If ds.Tables(0).Rows.Count > 0 Then
                grdParticipants.DataSource = ds
                grdParticipants.DataBind()
                dfPanel.Visible = True
            Else
            End If
        End Using
    End Sub
    Protected Sub btnSaveDiscount_Click(sender As Object, e As EventArgs) Handles btnSaveDiscount.Click
        saveDiscount()
    End Sub
    Protected Sub btnUpdateDiscount_Click(sender As Object, e As EventArgs) Handles btnUpdateDiscount.Click
        UpdateDiscount()
    End Sub
    Sub UpdateDiscount()
        If cmbChargeCode.Text = "" Then
            msgbox("Select charge code")
            Exit Sub
        End If

        If rdbIndicator.SelectedIndex = -1 Then
            msgbox("Select charge indicator")
            Exit Sub
        End If
        If IsNumeric(txtPercAmount.Text) = False Then
            msgbox("Enter rate/flat amount")
            Exit Sub
        End If
        If cmbParticipantType.Text = "" Then
            msgbox("Select Participant Type")
            Exit Sub
        End If
        If ParticipantSelected() = False Then
            msgbox("Select participants")
            Exit Sub
        End If
        If IsDate(txtExpiryDate.Text) = False Then
            msgbox("Select Expiry date")
            Exit Sub
        End If
        Using cn = New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("connpath"))
            Dim stmnt As String = " UPDATE ParaChargeDiscounts SET [ExpiryDate]=''" & validateDate(txtExpiryDate.Text) & "'',[ParticipantType]=''" & cmbParticipantType.Value & "'', [ChargeCode]=''" & cmbChargeCode.Value & "'', [ChargeDesc]=''" & cmbChargeCode.Text & "'', [Indicator]=''" & rdbIndicator.SelectedValue & "'', [PercAmount]=''" & validateNumeric(txtPercAmount.Text) & "'' WHERE ID=''" & Session("updateID") & "'' "
            stmnt = stmnt & getParticipantInsertStringUPDATE(Session("updateChargeCode"), Session("updateDiscountCode"))
            Dim descr As String = "Charge Discount Updated with Charge code:" + cmbChargeCode.Text + " Amount/% :" + txtPercAmount.Text + ""
            Using cmd As New SqlCommand("insert into tbl_uncommitted ([description], script, [status], sender, date_inserted, comment, email_body, email_subject, email_to, category) values ('" + descr + "' , '" + stmnt + "', '0','" + Session("Username") + "', getdate(), '','','', '','New Billing Parameter')", cn)
                If cn.State = ConnectionState.Open Then cn.Close()
                cn.Open()
                cmd.ExecuteNonQuery()
                cn.Close()
            End Using
        End Using
        Session("updateID") = ""
        Session("updateChargeCode") = ""
        Session("updateDiscountCode") = ""
        Session("finishU") = "yes"
        Response.Redirect(Request.RawUrl)
    End Sub
    Function getParticipantInsertString(ByVal ChargeCode As String, ByVal DiscountCode As String) As String
        Dim insertSTR As String = ""
        For Each row As RepeaterItem In grdParticipants.Items
            Dim chkView As CheckBox = DirectCast(row.FindControl("chkSelect"), CheckBox)
            Dim Company_Code As Label = CType(row.FindControl("lblCompany_Code"), Label)
            Dim Company_name As Label = CType(row.FindControl("lblCompany_name"), Label)
            If chkView.Checked = True Then
                'insertPermissionAudit 
                insertSTR = insertSTR & " INSERT INTO ParaChargeDiscountsParticipant(ParticipantCode,Participant,ChargeCode,DiscountCode)VALUES(''" & Company_Code.Text & "'',''" & Company_name.Text & "'',''" & ChargeCode & "'',''" & DiscountCode & "'')"
            End If
        Next
        Return insertSTR
    End Function
    Function getParticipantInsertStringUPDATE(ByVal ChargeCode As String, ByVal DiscountCode As String) As String
        Dim insertSTR As String = ""
        For Each row As RepeaterItem In grdParticipants.Items
            Dim chkView As CheckBox = DirectCast(row.FindControl("chkSelect"), CheckBox)
            Dim Company_Code As Label = CType(row.FindControl("lblCompany_Code"), Label)
            Dim Company_name As Label = CType(row.FindControl("lblCompany_name"), Label)
            If chkView.Checked = True Then
                'insertPermissionAudit 
                insertSTR = insertSTR & " IF NOT EXISTS (SELECT TOP 1 A.* FROM ParaChargeDiscountsParticipant A WHERE A.ParticipantCode=''" & Company_Code.Text & "'' AND A.ChargeCode=''" & ChargeCode & "'' AND DiscountCode=''" & DiscountCode & "'') BEGIN INSERT INTO ParaChargeDiscountsParticipant(ParticipantCode,Participant,ChargeCode)VALUES(''" & Company_Code.Text & "'',''" & Company_name.Text & "'',''" & ChargeCode & "'',''" & DiscountCode & "'') END"
            End If
            If chkView.Checked = False Then
                insertSTR = insertSTR & " DELETE FROM ParaChargeDiscountsParticipant WHERE ParticipantCode=''" & Company_Code.Text & "'' AND ChargeCode=''" & ChargeCode & "'' AND DiscountCode=''" & DiscountCode & "'' "
            End If
        Next
        Return insertSTR
    End Function
    Function ParticipantSelected() As Boolean
        Dim recSelected As Long = 0
        For Each row As RepeaterItem In grdParticipants.Items
            Dim chkView As CheckBox = DirectCast(row.FindControl("chkSelect"), CheckBox)
            If chkView.Checked = True Then
                recSelected = recSelected + 1
            End If
        Next
        If recSelected > 0 Then
            Return True
        Else
            Return False
        End If
    End Function
    Protected Function getModuleUserPermissions(ByVal Company_Code As String, ByVal chargeCode As String, ByVal DiscountCode As String) As Boolean
        Using con As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("connpath"))
            Using cmd As New SqlCommand("select ID from ParaChargeDiscountsParticipant where chargeCode='" & chargeCode & "' and ParticipantCode='" & Company_Code & "' and DiscountCode='" & DiscountCode & "'", con)
                con.Open()
                If cmd.ExecuteScalar Then
                    Return True
                Else
                    Return False
                End If
            End Using
        End Using
    End Function
    Protected Sub grdParticipants_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.RepeaterItemEventArgs) Handles grdParticipants.ItemDataBound
        If e.Item.ItemType = ListItemType.Item OrElse e.Item.ItemType = ListItemType.AlternatingItem Then
            Dim chkView As CheckBox
            chkView = DirectCast(e.Item.FindControl("chkSelect"), CheckBox)
            Dim Company_Code = DirectCast(e.Item.FindControl("lblCompany_Code"), Label).Text
            Dim chargeCode = DirectCast(e.Item.FindControl("lblChargeCd"), Label).Text
            Dim DiscountCode = DirectCast(e.Item.FindControl("lblDiscountCd"), Label).Text
            chkView.Checked = getModuleUserPermissions(Company_Code, chargeCode, DiscountCode)
        End If
    End Sub
    Protected Sub chkSelect_CheckedChanged(sender As Object, e As EventArgs)
        allisSelected()
    End Sub
    Sub allisSelected()
        Dim recSelected As Long = 0
        Dim allwasSelected As Long = 0
        For Each row As RepeaterItem In grdParticipants.Items
            Dim chkView As CheckBox = DirectCast(row.FindControl("chkSelect"), CheckBox)
            Dim Company_Code = DirectCast(row.FindControl("lblCompany_Code"), Label).Text
            If chkView.Checked = True Then
                If Company_Code = "ALL" Then
                    recSelected = recSelected + 1
                End If
            End If
        Next
        If recSelected > 0 Then
            For Each row As RepeaterItem In grdParticipants.Items
                Dim chkView As CheckBox = DirectCast(row.FindControl("chkSelect"), CheckBox)
                Dim Company_Code = DirectCast(row.FindControl("lblCompany_Code"), Label).Text
                If Company_Code <> "ALL" Then
                    chkView.Checked = True
                End If
            Next
        End If
    End Sub
    Function validateDate(inp As String) As Object
        'Return IIf(IsNumeric(toMoney(inp)), DBNull.Value, inp)
        Return IIf(Trim(inp) = "" Or Not IsDate(inp), DBNull.Value, inp)
    End Function
    Function discountAlreadyExists() As Boolean
        Dim reCount As Long = 0
        For Each row As RepeaterItem In grdParticipants.Items
            Dim chkView As CheckBox = DirectCast(row.FindControl("chkSelect"), CheckBox)
            Dim Company_Code = DirectCast(row.FindControl("lblCompany_Code"), Label).Text
            If chkView.Checked = True Then
                If ExistsinSub(Company_Code) = True Then
                    reCount += 1
                End If
            End If
        Next
        If reCount > 0 Then
            Return True
        Else
            Return False
        End If
    End Function
    Function ExistsinSub(ByVal participant As String) As Boolean
        Dim ds As New DataSet
        cmd = New SqlCommand("  Select b.* from ParaChargeDiscounts a join ParaChargeDiscountsParticipant b on a.ChargeCode=b.ChargeCode and a.DiscountCode=b.DiscountCode where a.ChargeCode=@ChargeCode and a.ParticipantType=@ParticipantType AND a.ExpiryDate>convert(date,getdate()) and b.ParticipantCode=@ParticipantCode ", cn)
        cmd.Parameters.AddWithValue("@ChargeCode", cmbChargeCode.Value)
        cmd.Parameters.AddWithValue("@ParticipantType", cmbParticipantType.Value)
        cmd.Parameters.AddWithValue("@ParticipantCode", participant)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "ParaCharge")
        If (ds.Tables(0).Rows.Count > 0) Then
            Return True
        Else
            Return False
        End If
    End Function
End Class
