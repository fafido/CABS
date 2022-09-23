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

Partial Class Corp_Invoice
    Inherits System.Web.UI.Page
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
                txtToDate.MaxDate = Date.Now()
                loadALLInvoices()
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Protected Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        If (txtShareholder.Text <> "") Then
            BindComboShort()
        Else
            msgbox("Enter search name/holder No.")
        End If
    End Sub
    Public Sub BindComboShort()
        Dim strSQL As String = ""
        strSQL = "select distinct A.CDS_Number ,CASE WHEN A.AccountType IN ('C','P') THEN ISNULL(A.Surname,'') ELSE ISNULL(A.Forenames,'')+' '+ISNULL(A.Surname,'') END as DisplayNames from Accounts_Clients A where ISNULL(A.Forenames,'')+' '+ISNULL(A.Surname,'') +' '+ ISNULL(A.CDS_Number,'') LIKE '%'+ @SearchText +'%' order by DisplayNames"
        Using cn = New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("connpath"))
            Dim ds As New DataSet
            Dim cmd = New SqlCommand(strSQL, cn)
            cmd.Parameters.AddWithValue("@SearchText", txtShareholder.Text)
            Dim adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "Accounts_Clients")
            If ds.Tables(0).Rows.Count > 0 Then
                lstNAME.DataSource = ds
                lstNAME.ValueField = "CDS_Number"
                lstNAME.TextField = "DisplayNames"
                lstNAME.DataBind()
            Else
                lstNAME.DataSource = Nothing
                lstNAME.DataBind()

                'ASPxGridViewExporter1.WriteXlsx()
            End If
        End Using
    End Sub
    Protected Sub lstNAME_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstNAME.SelectedIndexChanged
        Try
            txtCDSNo.Text = lstNAME.SelectedItem.Value.ToString
            txtNames.Text = lstNAME.SelectedItem.Text.ToString
            getAssetManagers()
        Catch ex As Exception
            msgbox(ex.Message.ToString)
        End Try
    End Sub
    Protected Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If txtCDSNo.Text <> "" Then
            If lstNAME.SelectedIndex < 0 Then
                msgbox("Select Holder")
                Exit Sub
            End If
            If IsDate(txtFromDate.Text) = False Or IsDate(txtToDate.Text) = False Then
                msgbox("Select Date Range")
                Exit Sub
            End If
            If CDate(txtFromDate.Text) > CDate(txtToDate.Text) Then
                msgbox("Select valid Date Range")
                Exit Sub
            End If
            'If DateDiff(DateInterval.Month, CDate(txtFromDate.Text), CDate(txtToDate.Text)) <> 1 Then
            '    msgbox("Selected date range should be a month")
            '    Exit Sub
            'End If
            If IsNumeric(txtChargeAmount.Text) = False Then
                msgbox("Charge (portfolio) missing")
                Exit Sub
            End If
            If IsNumeric(txtChargeAmountTransactions.Text) = False Then
                msgbox("Charge (transactions) missing")
                Exit Sub
            End If
            If IsNumeric(txtTotalCharges.Text) = False Then
                msgbox("Total Charges missing")
                Exit Sub
            End If
            If CDbl(txtTotalCharges.Text) <= 0 Then
                msgbox("Total Charges missing")
                Exit Sub
            End If
            If txtInterCompanyAccName.Text = "" Or txtInterCompanyAccNumber.Text = "" Then
                msgbox("Kindly provide InterCompany account and account name")
                Exit Sub
            End If
            Dim strCMD As String = "  "
            strCMD = strCMD & " INSERT INTO ClientInvoices ([ClientNo],[AssetManager],[DateFrom],[DateTo],[BilledBy],[ChargeCode],[PortfolioValue],[ChargeAmount],[Holder],[ChargesTransactions],[TotalCharges],[InterCompanyAccountName],[InterCompanyAccountNumber])VALUES(@ClientNo,@AssetManager,@DateFrom,@DateTo,@BilledBy,@ChargeCode,@PortfolioValue,@ChargeAmount,@Holder,@ChargesTransactions,@TotalCharges,@InterCompanyAccountName,@InterCompanyAccountNumber) "
            Using cn = New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("connpath"))
                Using cmd As New SqlCommand(strCMD, cn)
                    cmd.Parameters.AddWithValue("@ClientNo", txtCDSNo.Text)
                    cmd.Parameters.AddWithValue("@AssetManager", cmbAssetManager.Value)
                    cmd.Parameters.AddWithValue("@DateFrom", txtFromDate.Text)
                    cmd.Parameters.AddWithValue("@DateTo", txtToDate.Text)
                    cmd.Parameters.AddWithValue("@BilledBy", Session("Username"))
                    cmd.Parameters.AddWithValue("@ChargeCode", txtChargeCode.Text)
                    cmd.Parameters.AddWithValue("@PortfolioValue", txtPortValue.Text)
                    cmd.Parameters.AddWithValue("@ChargeAmount", txtChargeAmount.Text)
                    cmd.Parameters.AddWithValue("@ChargesTransactions", txtChargeAmountTransactions.Text)
                    cmd.Parameters.AddWithValue("@TotalCharges", txtTotalCharges.Text)
                    cmd.Parameters.AddWithValue("@Holder", txtNames.Text)
                    cmd.Parameters.AddWithValue("@InterCompanyAccountName", txtInterCompanyAccName.Text)
                    cmd.Parameters.AddWithValue("@InterCompanyAccountNumber", txtInterCompanyAccNumber.Text)
                    If cn.State = ConnectionState.Open Then cn.Close()
                    cn.Open()
                    cmd.ExecuteNonQuery()
                    cn.Close()
                End Using
            End Using
                Response.Write("<script>alert('Invoice Posted successfully,awaiting authorization') ; location.href='frmInvoice.aspx'</script>")
            Else
                msgbox("Please search for account")
            Exit Sub
        End If
    End Sub
    Sub ClearAll()
        txtCDSNo.Text = ""
        txtNames.Text = ""
        txtChargeAmount.Text = ""
        txtChargeAmountTransactions.Text = ""
        txtChargeCode.Text = ""
        lstNAME.Items.Clear()
        lstNAME.DataSource = Nothing
        lstNAME.DataBind()
        txtInterCompanyAccName.Text = ""
        txtInterCompanyAccNumber.Text = ""
    End Sub
    Sub getAssetManagers()
        cmbAssetManager.Items.Clear()
        cmbAssetManager.DataSource = Nothing
        cmbAssetManager.DataBind()
        Using cn = New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("connpath"))
            Dim ds As New DataSet
            Dim cmd = New SqlCommand("SELECT * FROM para_assetManager where AssetManagerCode in (select distinct k.AssetManager from Client_AssetManagers k where k.ClientNo=@ClientNo) ORDER BY AssetMananger", cn)
            cmd.Parameters.AddWithValue("@ClientNo", txtCDSNo.Text)
            Dim adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "para_assetManager")
            If ds.Tables(0).Rows.Count > 0 Then
                cmbAssetManager.DataSource = ds
                cmbAssetManager.ValueField = "AssetManagerCode"
                cmbAssetManager.TextField = "AssetMananger"
                cmbAssetManager.DataBind()
            Else
                cmbAssetManager.DataSource = Nothing
                cmbAssetManager.DataBind()
            End If
        End Using
    End Sub
    Sub getSetMinBillDate()
        Using cn = New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("connpath"))
            Dim ds As New DataSet
            Dim cmd = New SqlCommand("SELECT TOP 1 DateTo as LastDateBilled FROM ClientInvoices WHERE ClientNo=@ClientNo and AssetManager=@AssetManager and ISNULL(Posted,0) in (0,1) ORDER BY ID DESC", cn)
            cmd.Parameters.AddWithValue("@ClientNo", txtCDSNo.Text)
            cmd.Parameters.AddWithValue("@AssetManager", cmbAssetManager.Value)
            Dim adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "ClientInvoices")
            If ds.Tables(0).Rows.Count > 0 Then
                txtFromDate.MinDate = CDate(ds.Tables(0).Rows(0).Item("LastDateBilled"))
                txtToDate.Text = ""
            Else
            End If
        End Using
    End Sub
    Sub getInterCompanyAccDetails()
        Using cn = New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("connpath"))
            Dim ds As New DataSet
            Dim cmd = New SqlCommand("SELECT B.AccountName,B.AccountNumber FROM (SELECT TOP 1 InterCompanyAccount FROM Client_AssetManagers where ClientNo=@ClientNo and AssetManager=@AssetManager and ISNULL(InterCompanyAccount,'')<>'') A JOIN Para_InterCompanyAccounts B ON A.InterCompanyAccount=B.AccountNumber", cn)
            cmd.Parameters.AddWithValue("@ClientNo", txtCDSNo.Text)
            cmd.Parameters.AddWithValue("@AssetManager", cmbAssetManager.Value)
            Dim adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "ClientInvoices")
            If ds.Tables(0).Rows.Count > 0 Then
                txtInterCompanyAccNumber.Text = ds.Tables(0).Rows(0).Item("AccountNumber").ToString
                txtInterCompanyAccName.Text = ds.Tables(0).Rows(0).Item("AccountName").ToString
            Else
                txtInterCompanyAccNumber.Text = ""
                txtInterCompanyAccName.Text = ""
            End If
        End Using
    End Sub
    Protected Sub cmbAssetManager_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbAssetManager.SelectedIndexChanged
        getSetMinBillDate()
        getInterCompanyAccDetails()
    End Sub
    Protected Sub txtToDate_DateChanged(sender As Object, e As EventArgs) Handles txtToDate.DateChanged
        getchargeDetails()
        getTransactionCharges()
        getTotal()
    End Sub
    Sub getchargeDetails()
        If cmbAssetManager.Text <> "" Then
            Using cn = New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("connpath"))
                Dim ds As New DataSet
                Dim cmd = New SqlCommand("PortfolioValuation_total", cn)
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("@clientno", txtCDSNo.Text)
                cmd.Parameters.AddWithValue("@AssetManager", cmbAssetManager.Value)
                cmd.Parameters.AddWithValue("@date", txtToDate.Text)
                Dim adp = New SqlDataAdapter(cmd)
                adp.Fill(ds, "portvalue")
                If ds.Tables(0).Rows.Count > 0 Then
                    Dim amount As String = ds.Tables(0).Rows(0).Item(0).ToString()
                    If IsNumeric(amount) = True Then
                        txtPortValue.Text = FormatNumber(amount)
                        getCharges(amount)
                    Else
                        txtPortValue.Text = "0"
                        txtChargeAmount.Text = "0"
                    End If
                Else
                    txtPortValue.Text = "0"
                    txtChargeAmount.Text = "0"
                End If
            End Using
        End If
    End Sub
    Sub getCharges(ByVal Amount As String)
        Using cn = New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("connpath"))
            Dim ds As New DataSet
            Dim cmd = New SqlCommand("SELECT ISNULL(B.UptoMax,0) AS UptoMax1,* FROM ParaCharge B WHERE B.ChargeType=@ChargeDesc AND case Currency when 'ZWL' THEN B.RangeFrom ELSE B.RangeFrom*(SELECT TOP 1 RateToBase  FROM para_CurrencyRates WHERE CurrencyCode=Currency  AND convert(date, datefrom)<=@closdate order by datefrom desc, rateid desc) END<= @PortTotal and case Currency when 'ZWL' THEN B.RangeTo ELSE B.RangeTo*(SELECT TOP 1 RateToBase  FROM para_CurrencyRates WHERE CurrencyCode=Currency  AND convert(date, datefrom)<=@closdate order by datefrom desc, rateid desc) END >= @PortTotal AND [Name] in (select billingprofile from accounts_clients where cds_number=@cdsnumber)", cn)
            cmd.CommandType = CommandType.Text
            cmd.Parameters.AddWithValue("@ChargeDesc", "Portfolio Value")
            cmd.Parameters.AddWithValue("@PortTotal", Amount.Replace(",", ""))
            cmd.Parameters.AddWithValue("@cdsnumber", txtCDSNo.Text)
            cmd.Parameters.AddWithValue("@closdate", txttodate.text)
            Dim adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "ParaCharge")
            If ds.Tables(0).Rows.Count > 0 Then
                Dim dr As DataRow = ds.Tables(0).Rows(0)
                Dim indicator As String = dr.Item("Indicator").ToString
                Dim PercAmount As Double = CDbl(dr.Item("PercAmount")) / 100
                Dim MaxAmount As Double = CDbl(dr.Item("UptoMax1"))
                Dim chargeCode As String = dr.Item("chargeCode").ToString
                Dim NewCharge As Double = 0
                If indicator = "%" Then
                    NewCharge = (PercAmount * CDbl(Amount.Replace(",", ""))) / 12
                Else
                    NewCharge = PercAmount
                End If
                If MaxAmount > 0 And NewCharge > MaxAmount Then
                    NewCharge = MaxAmount
                End If
                txtChargeAmount.Text = FormatNumber(NewCharge)
                txtChargeCode.Text = chargeCode
            Else
                txtChargeCode.Text = ""
                txtChargeAmount.Text = "0"
            End If
        End Using
    End Sub
    Sub getTransactionCharges()
        If cmbAssetManager.Text <> "" Then
            Using cn = New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("connpath"))
                Dim ds As New DataSet
                Dim cmd = New SqlCommand("select ISNULL(ABS(SUM(Q.Amount)),0) AS ChargeAmountTransactions from CashTrans_Billing Q where Q.CDS_Number=@CDS_Number AND Q.AssetManager=@AssetManager AND CONVERT(DATE,Q.DateCreated) BETWEEN @DateFrom AND @DateTo ", cn)
                cmd.CommandType = CommandType.Text
                cmd.Parameters.AddWithValue("@CDS_Number", txtCDSNo.Text)
                cmd.Parameters.AddWithValue("@AssetManager", cmbAssetManager.Value)
                cmd.Parameters.AddWithValue("@DateFrom", txtFromDate.Text)
                cmd.Parameters.AddWithValue("@DateTo", txtToDate.Text)
                Dim adp = New SqlDataAdapter(cmd)
                adp.Fill(ds, "CashTrans_Billing")
                If ds.Tables(0).Rows.Count > 0 Then
                    Dim dr As DataRow = ds.Tables(0).Rows(0)
                    Dim ChargedAmount As Double = CDbl(dr.Item("ChargeAmountTransactions"))
                    txtChargeAmountTransactions.Text = FormatNumber(ChargedAmount)
                Else
                    txtChargeAmountTransactions.Text = "0"
                End If
            End Using
        End If
    End Sub
    Private Function TransactionOriginisMySession(ByVal myIDD As String) As Boolean
        Using cn = New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("connpath"))
            Dim ds As New DataSet
            Dim cmd = New SqlCommand("SELECT * FROM ClientInvoices WHERE ID='" & myIDD & "'  ", cn)
            cmd.CommandType = CommandType.Text
            Dim adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "ClientInvoices")
            If ds.Tables(0).Rows.Count > 0 Then
                If ds.Tables(0).Rows(0).Item("BilledBy").ToString = Session("Username") Then
                    Return True
                Else
                    Return False
                End If
            Else
                Return True
            End If
        End Using
    End Function
    Private Function InvoiceAlreadyActioned(ByVal myIDD As String) As Boolean
        Using cn = New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("connpath"))
            Dim ds As New DataSet
            Dim cmd = New SqlCommand("SELECT *,CASE Posted when 0 then 'New' when 1 then 'Authorised' when 2 then 'Rejected' end as status FROM ClientInvoices WHERE ID='" & myIDD & "'  ", cn)
            cmd.CommandType = CommandType.Text
            Dim adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "ClientInvoices")
            If ds.Tables(0).Rows.Count > 0 Then
                If ds.Tables(0).Rows(0).Item("status").ToString <> "New" Then
                    Return True
                Else
                    Return False
                End If
            Else
                Return True
            End If
        End Using
    End Function
    Public Sub loadALLInvoices()
        Using cn = New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("connpath"))
            Dim ds As New DataSet
            Dim cmd = New SqlCommand("SELECT *, FORMAT(DateBilled,'dd MMM yyyy HH:mm','en-us') as DateCreated1,FORMAT(DateFrom,'dd MMM yyyy','en-us') as DateFrom1,FORMAT(DateTo,'dd MMM yyyy','en-us') as DateTo1, CASE Posted when 0 then 'New' when 1 then 'Authorised' when 2 then 'Rejected' end as status FROM ClientInvoices where ISNULL(Posted,0) in (0) order by id desc ", cn)
            cmd.CommandType = CommandType.Text
            Dim adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "ClientInvoices")
            If ds.Tables(0).Rows.Count > 0 Then
                grdChargesCreated.DataSource = ds
                grdChargesCreated.DataBind()
            Else
                grdChargesCreated.DataSource = Nothing
                grdChargesCreated.DataBind()
            End If
        End Using
    End Sub
    Private Sub getTotal()
        Dim TotalCharges As Double = 0, ChargeAmount As Double = 0, ChargeAmountTransaction As Double = 0
        Try
            ChargeAmount = CDbl(txtChargeAmount.Text.Replace(",", ""))
        Catch ex As Exception
        End Try
        Try
            ChargeAmountTransaction = CDbl(txtChargeAmountTransactions.Text.Replace(",", ""))
        Catch ex As Exception
        End Try
        TotalCharges = ChargeAmount + ChargeAmountTransaction
        txtTotalCharges.Text = FormatNumber(TotalCharges)
    End Sub
    Protected Sub grdChargesCreated_RowCommand(sender As Object, e As DevExpress.Web.ASPxGridView.ASPxGridViewRowCommandEventArgs) Handles grdChargesCreated.RowCommand
        Dim myID As String = e.KeyValue.ToString
        If e.CommandArgs.CommandName = "Select" Then
            Dim strscript As String
            strscript = "<script langauage=JavaScript>"
            strscript += "window.open('frmInvoiceReport.aspx?keyid=" & myID & "');"
            strscript += "</script>"
            ClientScript.RegisterStartupScript(Me.GetType(), "newwin", strscript)
        ElseIf e.CommandArgs.CommandName = "Authorise" Then
            Try
                If TransactionOriginisMySession(myID) = True Then
                    msgbox("Cannot Authorise/Reject own Transaction")
                    Exit Sub
                End If
                If InvoiceAlreadyActioned(myID) = True Then
                    msgbox("Invoice Already Authorised/Rejected")
                    Exit Sub
                End If
                Using cn = New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("connpath"))
                    Using cmd As New SqlCommand("UPDATE [ClientInvoices] set Posted=1,AuthBy=@AuthBy,AuthDate=Getdate() WHERE ID='" & myID & "'", cn)
                        cmd.Parameters.AddWithValue("@AuthBy", Session("Username"))
                        If cn.State = ConnectionState.Open Then cn.Close()
                        cn.Open()
                        cmd.ExecuteNonQuery()
                        cn.Close()
                    End Using
                End Using
                msgbox("Invoice Authorised successfully")
                loadALLInvoices()
            Catch ex As Exception
                ErrorLogging.WriteLogFile(Session("Username"), "grdChargesCreated_RowCommand", ex.ToString)
            End Try
        ElseIf e.CommandArgs.CommandName = "Reject" Then
            Try
                If TransactionOriginisMySession(myID) = True Then
                    msgbox("Cannot Authorise/Reject own Transaction")
                    Exit Sub
                End If
                If InvoiceAlreadyActioned(myID) = True Then
                    msgbox("Invoice Already Authorised/Rejected")
                    Exit Sub
                End If
                Using cn = New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("connpath"))
                    Using cmd As New SqlCommand("UPDATE [ClientInvoices] set Posted=2,AuthBy=@AuthBy,AuthDate=Getdate() WHERE ID='" & myID & "'", cn)
                        cmd.Parameters.AddWithValue("@AuthBy", Session("Username"))
                        If cn.State = ConnectionState.Open Then cn.Close()
                        cn.Open()
                        cmd.ExecuteNonQuery()
                        cn.Close()
                    End Using
                End Using
                msgbox("Invoice has been rejected")
                loadALLInvoices()
            Catch ex As Exception
                ErrorLogging.WriteLogFile(Session("Username"), "grdChargesCreated_RowCommand", ex.ToString)
            End Try
        End If
    End Sub
    Protected Sub grdChargesCreated_DataBinding(sender As Object, e As EventArgs) Handles grdChargesCreated.DataBinding
        grdChargesCreated.DataSource = getmyDs()
    End Sub
    Function getmyDs() As DataSet
        Using cn = New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("connpath"))
            Dim ds As New DataSet
            Dim cmd = New SqlCommand("SELECT *, FORMAT(DateBilled,'dd MMM yyyy HH:mm','en-us') as DateCreated1,FORMAT(DateFrom,'dd MMM yyyy','en-us') as DateFrom1,FORMAT(DateTo,'dd MMM yyyy','en-us') as DateTo1, CASE Posted when 0 then 'New' when 1 then 'Authorised' when 2 then 'Rejected' end as status FROM ClientInvoices where ISNULL(Posted,0) in (0) order by id desc", cn)
            cmd.CommandType = CommandType.Text
            Dim adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "ClientInvoices")
            Return ds
        End Using
    End Function
End Class
