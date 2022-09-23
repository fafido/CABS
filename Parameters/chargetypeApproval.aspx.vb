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
Imports System.Web.Services
Imports DevExpress.Web.ASPxGridView

Partial Class TransferSec_ChargeTypeApproval
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
                getChargeIntervals()
                getAllParticipantTypes()
                getChargeTypes()
                loadALLChargeCodes()
                loadactivecharges()

                getcurrencies()
                gettypesnames()

                If Session("finish") = "true" Then
                    Session("finish") = ""
                    msgbox("Change successfully effected!")
                End If
                If Session("finishU") = "yes" Then
                    Session("finishU") = ""
                    msgbox("Charge Successfully updated, awaiting approval")
                End If
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Sub getChargeIntervals()
        Using cn = New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("connpath"))
            Dim ds As New DataSet
            Dim cmd = New SqlCommand("select * from para_chargetype order by charge_type", cn)
            Dim adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "para_othercharges")
            If ds.Tables(0).Rows.Count > 0 Then
                cmbChargeInterval.DataSource = ds
                cmbChargeInterval.ValueField = "charge_type"
                cmbChargeInterval.TextField = "charge_type"
                cmbChargeInterval.DataBind()
            Else
            End If
        End Using
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
    Sub gettypesnames()
        Using cn = New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("connpath"))
            Dim ds As New DataSet
            Dim cmd = New SqlCommand("select * from para_BillingProfiles", cn)
            Dim adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "tbl_ParticipantsType")
            If ds.Tables(0).Rows.Count > 0 Then
                cmbbillname.DataSource = ds
                cmbbillname.ValueField = "ProfileCode"
                cmbbillname.TextField = "ProfileName"
                cmbbillname.DataBind()
            Else
            End If
        End Using
    End Sub

    Sub getChargeTypes()
        Using cn = New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("connpath"))
            Dim ds As New DataSet
            Dim cmd = New SqlCommand("select distinct fee_type from tbl_fee_type order by fee_type", cn)
            Dim adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "tbl_fee_type")
            If ds.Tables(0).Rows.Count > 0 Then
                cmbChargeType.DataSource = ds
                cmbChargeType.ValueField = "fee_type"
                cmbChargeType.TextField = "fee_type"
                cmbChargeType.DataBind()
            Else
            End If
        End Using
    End Sub
    Protected Sub cmbChargeType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbChargeType.SelectedIndexChanged
        getSubTypes()
        If cmbChargeType.SelectedItem.Text = "Portfolio Value" Then
            cmbChargeInterval.ReadOnly = False
        Else
            cmbChargeInterval.Value = "OnceOff (Transactional)"
            cmbChargeInterval.ReadOnly = True
        End If


    End Sub
    Sub getSubTypes()
        Dim strSQL As String = ""
        strSQL = "SELECT * FROM tbl_fee_type where fee_type=@fee_type order by ID"
        Using cn = New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("connpath"))
            Dim ds As New DataSet
            Dim cmd = New SqlCommand(strSQL, cn)
            cmd.Parameters.AddWithValue("@fee_type", cmbChargeType.Text)
            Dim adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "tbl_fee_type")
            If ds.Tables(0).Rows.Count > 0 Then
                cmbChargeSubType.DataSource = Nothing
                cmbChargeSubType.DataBind()
                cmbChargeSubType.Items.Clear()
                cmbChargeSubType.Text = ""
                cmbChargeSubType.Items.Add("", "")
                cmbChargeSubType.DataSource = ds
                cmbChargeSubType.ValueField = "fee_subType"
                cmbChargeSubType.TextField = "fee_subType"
                cmbChargeSubType.DataBind()
            Else
            End If
        End Using
    End Sub
    Protected Sub rdbIndicator_SelectedIndexChanged(sender As Object, e As EventArgs) Handles rdbIndicator.SelectedIndexChanged
        If rdbIndicator.SelectedValue = "Flat" Then
            ASPxLabel7.Text = "Amount"
            ASPxLabel274.Visible = False
            txtUptoMax.Visible = False
            cmbchargecurrency.Visible = True
        Else
            ASPxLabel7.Text = "Percentage"
            ASPxLabel274.Visible = True
            txtUptoMax.Visible = True
            cmbchargecurrency.Visible = False
        End If
    End Sub
    Sub saveCharge()
        If cmbChargeType.Text = "" Then
            msgbox("Select charge type")
            Exit Sub
        End If
        If cmbChargeSubType.Text = "" Then
            msgbox("Select fee type")
            Exit Sub
        End If
        'If cmbAccrualsonBehalfof.Text = "" Then
        '    msgbox("Select Accruals on Behalf of")
        '    Exit Sub
        'End If
        If rdbIndicator.SelectedIndex = -1 Then
            msgbox("Select charge indicator")
            Exit Sub
        End If
        If IsNumeric(txtPercAmount.Text) = False Then
            msgbox("Enter rate/flat amount")
            Exit Sub
        End If
        If cmbChargeInterval.Text = "" Then
            msgbox("Select charge interval")
            Exit Sub
        End If

        If cmbChargeType.SelectedItem.Text = "Portfolio Value" Then
            If txtFrom.Text = "" Then
                msgbox("Select Range from!")
                Exit Sub
            End If
            If txtTo.Text = "" Then
                msgbox("Select Range to!")
                Exit Sub
            End If
            Try
                If cmbcurrency.SelectedItem.Text = "" Then
                    msgbox("Please select the range currency!")
                    Exit Sub
                End If
            Catch ex As Exception
                msgbox("Please select the range currency!")
                Exit Sub
            End Try

        End If


        Dim max As String

        If txtTo.Text = "" Then
            max = "0"
        Else
            max = txtTo.Text
        End If

        Dim min As String

        If txtFrom.Text = "" Then
            min = "0"

        Else
            min = txtTo.Text
        End If


        Dim currency As String

        Try
            currency = cmbcurrency.SelectedItem.Text
        Catch ex As Exception
            currency = "ALL"
        End Try

        Dim chargecurrency As String
        Try
            If rdbIndicator.SelectedItem.Text = "%" Then
                chargecurrency = ""
            Else
                Try
                    chargecurrency = cmbchargecurrency.SelectedItem.Text
                Catch ex As Exception
                    msgbox("Please select Charge Currency")
                    Exit Sub
                End Try
            End If
        Catch ex As Exception
            chargecurrency = ""
        End Try

        Dim ChargeCode As String = "CHG" & Session("Username").ToString.ToUpper & Date.Now.ToString("ddMMMyyyyhhmmfff").ToUpper
        Using cn = New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("connpath"))
            Dim stmnt As String = " INSERT INTO ParachargeAudit ([ChargeCode],[ParticipantType], [ChargeType], [ChargeSUBType], [AccrualsonBehalfof], [RangeFrom], [RangeTo], [Indicator], [PercAmount], [UptoMax], [ChargeInterval],[CreatedBy],[Currency],[Name],[ChargeCurrency], UpdateType, CapturedBy, CaptureDate,Status)  VALUES('" & ChargeCode & "','','" & cmbChargeType.Value & "','" & cmbChargeSubType.Value & "','','" & min & "','" & max & "','" & rdbIndicator.SelectedValue & "','" & validateNumeric(txtPercAmount.Text) & "','" & validateNumeric(txtUptoMax.Text) & "','" & cmbChargeInterval.Value & "','" & Session("Username") & "','" + currency + "','" + cmbbillname.SelectedItem.Value.ToString + "','" + chargecurrency + "','NEW','" + Session("Username") + "',getdate(),'PENDING' ) "
            Using cmd As New SqlCommand(stmnt, cn)
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
        'Return IIf(IsNumeric(toMoney(inp)), DBNull.Value, inp)
        inp = inp.Replace(",", "")
        Return IIf(IsNumeric(Trim(inp)) = False, 0, inp)
    End Function
    Public Sub loadALLChargeCodes()
        Dim ds As New DataSet
        cmd = New SqlCommand("  Select *,PercAmount AS PercAmount1 from ParachargeAudit where Rejected is NULL and Active is NULL AND [Status]='PENDING' order by id desc", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "ParachargeAudit")
        If (ds.Tables(0).Rows.Count > 0) Then
            grdChargesCreated.DataSource = ds
            grdChargesCreated.DataBind()
        End If
    End Sub
    Public Sub loadactivecharges()
        Dim ds As New DataSet
        cmd = New SqlCommand("  Select *,PercAmount AS PercAmount1 from Paracharge order by id desc", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "ParachargeAudit")
        If (ds.Tables(0).Rows.Count > 0) Then
            grdactivecharges.DataSource = ds
            grdactivecharges.DataBind()
        End If
    End Sub
    Public Sub approvetrans(id As String)
        Dim ds As New DataSet
        cmd = New SqlCommand(" select * from parachargeAudit where id='" + id + "'", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "ParachargeAudit")
        If (ds.Tables(0).Rows.Count > 0) Then
            Dim updatetype As String = ds.Tables(0).Rows(0).Item("UpdateType").ToString
            If updatetype = "NEW" Then
                insertdata("insert into ParaCharge ( [ParticipantType]      ,[Participant]      ,[ChargeType]      ,[ChargeSUBType]      ,[AccrualsonBehalfof]      ,[LeviedON]      ,[RangeFrom]      ,[RangeTo]      ,[Indicator]      ,[PercAmount]      ,[UptoMax]      ,[ChargeInterval]      ,[ChargeCode]      ,[CreatedBy]      ,[DateCreated]      ,[Active]      ,[Currency]      ,[Name]      ,[ChargeCurrency]      ,[ApprovedBy])select   [ParticipantType]      ,[Participant]      ,[ChargeType]      ,[ChargeSUBType]      ,[AccrualsonBehalfof]      ,[LeviedON]      ,[RangeFrom]      ,[RangeTo]      ,[Indicator]      ,[PercAmount]      ,[UptoMax]      ,[ChargeInterval]      ,[ChargeCode]      ,[CreatedBy]      ,[DateCreated]      ,[Active]      ,[Currency]      ,[Name]      ,[ChargeCurrency]      ,'" + Session("Username") + "'	  from ParaChargeAudit  where id ='" + id + "' update paraChargeAudit set [status]='APPROVED' where id='" + id + "'")
            ElseIf updatetype = "UPDATE" Then
                insertdata("insert into ParaCharge ( [ParticipantType]      ,[Participant]      ,[ChargeType]      ,[ChargeSUBType]      ,[AccrualsonBehalfof]      ,[LeviedON]      ,[RangeFrom]      ,[RangeTo]      ,[Indicator]      ,[PercAmount]      ,[UptoMax]      ,[ChargeInterval]      ,[ChargeCode]      ,[CreatedBy]      ,[DateCreated]      ,[Active]      ,[Currency]      ,[Name]      ,[ChargeCurrency]      ,[ApprovedBy])select   [ParticipantType]      ,[Participant]      ,[ChargeType]      ,[ChargeSUBType]      ,[AccrualsonBehalfof]      ,[LeviedON]      ,[RangeFrom]      ,[RangeTo]      ,[Indicator]      ,[PercAmount]      ,[UptoMax]      ,[ChargeInterval]      ,[ChargeCode]      ,[CreatedBy]      ,[DateCreated]      ,[Active]      ,[Currency]      ,[Name]      ,[ChargeCurrency]      ,'" + Session("Username") + "'	  from ParaChargeAudit  where id ='" + id + "' delete from paracharge where id=(select ref2 from parachargeaudit where id='" + id + "') update paraChargeAudit set [status]='APPROVED' where id='" + id + "'")
            ElseIf updatetype = "DELETE" Then
                insertdata("delete from paracharge where id=(select ref2 from parachargeaudit where id='" + id + "') update paraChargeAudit set [status]='APPROVED' where id='" + id + "'")
            End If
        End If
    End Sub
    Protected Sub btnSaveCharge_Click(sender As Object, e As EventArgs) Handles btnSaveCharge.Click
        If btnSaveCharge.Text = "Save" Then
            saveCharge()
        ElseIf btnSaveCharge.Text = "Update Pending" Then
            UpdatePendingCharge()
        ElseIf btnSaveCharge.Text = "Approve" Then
            approvetrans(lblid.Text)
            Session("finish") = "true"
            Response.Redirect(Request.RawUrl)

        End If

    End Sub
    Public Sub getcurrencies()
        Dim dsport As New DataSet
        cmd = New SqlCommand("select * from para_currencies", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(dsport, "trans")
        If (dsport.Tables(0).Rows.Count > 0) Then
            cmbcurrency.DataSource = dsport
            cmbcurrency.TextField = "currencycode"
            cmbcurrency.ValueField = "currencycode"
            cmbcurrency.DataBind()

            cmbchargecurrency.DataSource = dsport
            cmbchargecurrency.TextField = "currencycode"
            cmbchargecurrency.ValueField = "currencycode"
            cmbchargecurrency.DataBind()

        End If
    End Sub


    Sub getExistingChargeCode(ByVal recID As String, type As String)
        Dim sql_str As String = ""
        sql_str = "select B.*,B.PercAmount AS PercAmount1,B.RangeFrom AS RangeFrom1,B.RangeTo AS RangeTo1 from ParachargeAudit B WHERE B.ID=@recID"
        Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("conpath").ConnectionString)
            Using cmd As New SqlCommand(sql_str, con)
                cmd.Parameters.AddWithValue("@recID", recID)
                Dim dss As New DataSet
                Dim adp = New SqlDataAdapter(cmd)
                adp.Fill(dss, "ParachargeAudit")
                If dss.Tables(0).Rows.Count > 0 Then
                    Session("updateID") = recID
                    Dim dr As DataRow = dss.Tables(0).Rows(0)
                    Session("updateChargeCode") = dr.Item("ChargeCode").ToString
                    Try
                        cmbChargeType.Value = dr.Item("ChargeType").ToString
                    Catch ex As Exception
                    End Try
                    cmbChargeType_SelectedIndexChanged(DBNull.Value, New EventArgs)
                    Try
                        cmbChargeSubType.Value = dr.Item("ChargeSubType").ToString
                    Catch ex As Exception
                    End Try

                    Try
                        rdbIndicator.SelectedValue = dr.Item("Indicator").ToString
                    Catch ex As Exception
                    End Try
                    rdbIndicator_SelectedIndexChanged(DBNull.Value, New EventArgs)
                    txtFrom.Text = dr.Item("RangeFrom1").ToString
                    txtTo.Text = dr.Item("RangeTo1").ToString
                    txtPercAmount.Text = dr.Item("PercAmount1").ToString
                    cmbbillname.Value = dr.Item("Name").ToString
                    txtupdatetype.Text = dr.Item("UpdateType").ToString

                    If dr.Item("Currency").ToString <> "ALL" Then
                        cmbcurrency.Value = dr.Item("Currency").ToString
                    End If




                    Try
                        cmbChargeInterval.Value = dr.Item("ChargeInterval").ToString
                    Catch ex As Exception
                    End Try
                    txtUptoMax.Text = dr.Item("UptoMax").ToString

                    Try
                        If rdbIndicator.SelectedValue = "Flat" Then
                            ASPxLabel7.Text = "Amount"
                            ASPxLabel274.Visible = False
                            txtUptoMax.Visible = False
                            cmbchargecurrency.Visible = True
                            cmbchargecurrency.Value = dr.Item("ChargeCurrency").ToString
                        Else
                            ASPxLabel7.Text = "Percentage"
                            ASPxLabel274.Visible = True
                            txtUptoMax.Visible = True
                            cmbchargecurrency.Visible = False
                            cmbchargecurrency.Value = ""
                        End If
                    Catch ex As Exception

                    End Try
                    btnSaveCharge.Text = "Approve"
                End If
            End Using
        End Using
    End Sub


    Sub UpdatePendingCharge()
        If cmbChargeType.Text = "" Then
            msgbox("Select charge type")
            Exit Sub
        End If
        If cmbChargeSubType.Text = "" Then
            msgbox("Select fee type")
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
        If cmbChargeInterval.Text = "" Then
            msgbox("Select charge interval")
            Exit Sub
        End If

        If cmbChargeType.SelectedItem.Text = "Portfolio Value" Then
            If txtFrom.Text = "" Then
                msgbox("Select Range from!")
                Exit Sub
            End If
            If txtTo.Text = "" Then
                msgbox("Select Range to!")
                Exit Sub
            End If
            Try
                If cmbcurrency.SelectedItem.Text = "" Then
                    msgbox("Please select the range currency!")
                    Exit Sub
                End If
            Catch ex As Exception
                msgbox("Please select the range currency!")
                Exit Sub
            End Try

        End If


        Dim max As String

        If txtTo.Text = "" Then
            max = "0"
        Else
            max = txtTo.Text
        End If

        Dim min As String

        If txtFrom.Text = "" Then
            min = "0"

        Else
            min = txtTo.Text
        End If


        Dim currency As String

        Try
            currency = cmbcurrency.SelectedItem.Text
        Catch ex As Exception
            currency = "ALL"
        End Try

        Dim chargecurrency As String
        Try
            If rdbIndicator.SelectedItem.Text = "%" Then
                chargecurrency = ""
            Else
                Try
                    chargecurrency = cmbchargecurrency.SelectedItem.Text
                Catch ex As Exception
                    msgbox("Please select Charge Currency")
                    Exit Sub
                End Try
            End If
        Catch ex As Exception
            chargecurrency = ""
        End Try

        Using cn = New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("connpath"))
            Dim stmnt As String = "UPDATE ParachargeAudit SET  [ChargeType]='" & cmbChargeType.Value & "', [ChargeSUBType]='" & cmbChargeSubType.Value & "', [RangeFrom]='" & min & "', [RangeTo]='" & max & "', [Indicator]='" & rdbIndicator.SelectedValue & "', [PercAmount]='" & validateNumeric(txtPercAmount.Text) & "', [UptoMax]='" & validateNumeric(txtUptoMax.Text) & "', [ChargeInterval]='" & cmbChargeInterval.Value & "', Currency='" + currency + "', ChargeCurrency='" + chargecurrency + "', status='PENDING', CapturedBy='" + Session("Username") + "' WHERE ID='" & lblid.Text & "' "
            Using cmd As New SqlCommand(stmnt, cn)
                If cn.State = ConnectionState.Open Then cn.Close()
                cn.Open()
                cmd.ExecuteNonQuery()
                cn.Close()
            End Using
        End Using

        Session("finishU") = "yes"
        Response.Redirect(Request.RawUrl)
    End Sub



    Protected Sub cmbChargeInterval_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbChargeInterval.SelectedIndexChanged

    End Sub
    Protected Sub cmbcurrency_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbcurrency.SelectedIndexChanged

    End Sub

    Private Sub grdChargesCreated_RowCommand(sender As Object, e As ASPxGridViewRowCommandEventArgs) Handles grdChargesCreated.RowCommand
        Dim id As String = e.KeyValue.ToString
        If e.CommandArgs.CommandName.ToString = "View" Then
            getExistingChargeCode(id, "Pending")
            lblid.Text = id
        ElseIf e.CommandArgs.CommandName.ToString = "Delete" Then
            Using cn = New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("connpath"))
                Dim stmnt As String = "delete from  ParachargeAudit  WHERE ID='" & id & "' "
                Using cmd As New SqlCommand(stmnt, cn)
                    If cn.State = ConnectionState.Open Then cn.Close()
                    cn.Open()
                    cmd.ExecuteNonQuery()
                    cn.Close()
                    loadALLChargeCodes()
                    msgbox("Pending Charge Removed Successfully")
                End Using
            End Using
        End If
    End Sub
    Public Sub insertdata(qry As String)
        Using cn = New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("connpath"))
            Using cmd As New SqlCommand(qry, cn)
                If cn.State = ConnectionState.Open Then cn.Close()
                cn.Open()
                cmd.ExecuteNonQuery()
                cn.Close()
            End Using
        End Using
    End Sub
End Class
