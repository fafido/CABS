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
Imports System.Collections.Generic
Imports DevExpress.Web.ASPxEditors
Imports DevExpress.Web.ASPxGridView

Partial Class Corp_InvoiceMultiple
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
                getAssetManagers()
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Protected Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        saveDATA()
    End Sub
    Sub getAssetManagers()
        Using cn = New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("connpath"))
            Dim ds As New DataSet
            Dim cmd = New SqlCommand("SELECT * FROM para_assetManager ORDER BY AssetMananger", cn)
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
    Function getTransactionCharges(ByVal CDSNo As String) As Double
        If cmbAssetManager.Text <> "" Then
            Using cn = New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("connpath"))
                Dim ds As New DataSet
                Dim cmd = New SqlCommand("select ISNULL(ABS(SUM(Q.Amount)),0) AS ChargeAmountTransactions from CashTrans_Billing Q where Q.CDS_Number=@CDS_Number AND Q.AssetManager=@AssetManager AND CONVERT(DATE,Q.DateCreated) BETWEEN @DateFrom AND @DateTo ", cn)
                cmd.CommandType = CommandType.Text
                cmd.Parameters.AddWithValue("@CDS_Number", CDSNo)
                cmd.Parameters.AddWithValue("@AssetManager", cmbAssetManager.Value)
                cmd.Parameters.AddWithValue("@DateFrom", txtFromDate.Text)
                cmd.Parameters.AddWithValue("@DateTo", txtToDate.Text)
                Dim adp = New SqlDataAdapter(cmd)
                adp.Fill(ds, "CashTrans_Billing")
                If ds.Tables(0).Rows.Count > 0 Then
                    Dim dr As DataRow = ds.Tables(0).Rows(0)
                    Dim ChargedAmount As Double = CDbl(dr.Item("ChargeAmountTransactions"))
                    Return ChargedAmount
                Else
                    Return 0
                End If
            End Using
        End If
    End Function
    Sub InsertChargeDetails()
        btnGetDetails.Enabled = False
        btnSave.Enabled = False
        removeDATA()
        Using cn3 = New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("connpath"))
            Dim ds3 As New DataSet
            Dim cmd3 = New SqlCommand("SELECT *,CASE WHEN H.AccountType IN ('C','P') THEN ISNULL(H.Surname,'') ELSE ISNULL(H.Forenames,'')+' '+ISNULL(h.Surname,'') END AS Names FROM Accounts_Clients H WHERE H.CDS_Number IN (SELECT DISTINCT G.ClientNo FROM Client_AssetManagers G WHERE G.AssetManager=@AssetManager) AND H.CDS_Number NOT IN (SELECT DISTINCT ClientNo FROM ClientInvoices WHERE AssetManager=@AssetManager and ISNULL(Posted,0) in (0,1) AND (DateFrom BETWEEN @DateFrom AND @DateTo or DateTo BETWEEN @DateFrom AND @DateTo)) ORDER BY H.CDS_Number", cn3)
            cmd3.CommandType = CommandType.Text
            cmd3.Parameters.AddWithValue("@AssetManager", cmbAssetManager.Value)
            cmd3.Parameters.AddWithValue("@DateFrom", txtFromDate.Text)
            cmd3.Parameters.AddWithValue("@DateTo", txtToDate.Text)
            Dim adp3 = New SqlDataAdapter(cmd3)
            adp3.Fill(ds3, "Accounts_Clients")
            If ds3.Tables(0).Rows.Count > 0 Then
                For Each dr3 As DataRow In ds3.Tables(0).Rows
                    Dim PortfolioValueAmount As Double = 0
                    Try
                        Using cn = New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("connpath"))
                            Dim ds As New DataSet
                            Dim cmd = New SqlCommand("PortfolioValuation_total", cn)
                            cmd.CommandType = CommandType.StoredProcedure
                            cmd.Parameters.AddWithValue("@clientno", dr3.Item("CDS_NUMBER").ToString)
                            cmd.Parameters.AddWithValue("@AssetManager", cmbAssetManager.Value)
                            cmd.Parameters.AddWithValue("@date", txtToDate.Text)
                            Dim adp = New SqlDataAdapter(cmd)
                            adp.Fill(ds, "portvalue")
                            If ds.Tables(0).Rows.Count > 0 Then
                                PortfolioValueAmount = CDbl(ds.Tables(0).Rows(0).Item(0))
                            Else
                                PortfolioValueAmount = 0
                            End If
                        End Using
                    Catch ex As Exception
                        PortfolioValueAmount = 0
                    End Try
                    Using cn2 = New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("connpath"))
                        Dim ds2 As New DataSet
                        Dim cmd2 = New SqlCommand("SELECT ISNULL(B.UptoMax,0) AS UptoMax1,* FROM ParaCharge B WHERE B.ChargeType=@ChargeDesc AND case Currency when 'ZWL' THEN B.RangeFrom ELSE B.RangeFrom*(SELECT TOP 1 RateToBase  FROM para_CurrencyRates WHERE CurrencyCode=Currency  AND convert(date, datefrom)<=@closdate order by datefrom desc, rateid desc) END<= @PortTotal and case Currency when 'ZWL' THEN B.RangeTo ELSE B.RangeTo*(SELECT TOP 1 RateToBase  FROM para_CurrencyRates WHERE CurrencyCode=Currency  AND convert(date, datefrom)<=@closdate order by datefrom desc, rateid desc) END >= @PortTotal AND [Name] in (select billingprofile from accounts_clients where cds_number=@cdsnumber)", cn2)
                        cmd2.CommandType = CommandType.Text
                        cmd2.Parameters.AddWithValue("@ChargeDesc", "Portfolio Value")
                        cmd2.Parameters.AddWithValue("@PortTotal", PortfolioValueAmount)
                        cmd2.Parameters.AddWithValue("@cdsnumber", dr3.Item("CDS_NUMBER").ToString)
                        cmd2.Parameters.AddWithValue("@closdate", txtToDate.Text)
                        Dim adp2 = New SqlDataAdapter(cmd2)
                        adp2.Fill(ds2, "ParaCharge")
                        If ds2.Tables(0).Rows.Count > 0 Then
                            Dim dr2 As DataRow = ds2.Tables(0).Rows(0)
                            Dim indicator As String = dr2.Item("Indicator").ToString
                            Dim PercAmount As Double = CDbl(dr2.Item("PercAmount")) / 100
                            Dim MaxAmount As Double = CDbl(dr2.Item("UptoMax1"))
                            Dim chargeCode As String = dr2.Item("chargeCode").ToString
                            Dim NewCharge As Double = 0
                            If indicator = "%" Then
                                NewCharge = (PercAmount * PortfolioValueAmount) / 12
                            Else
                                NewCharge = PercAmount
                            End If
                            If MaxAmount > 0 And NewCharge > MaxAmount Then
                                NewCharge = MaxAmount
                            End If
                            'insert
                            Dim TotalCharges As Double = 0
                            Dim ChargeAmountT As Double = 0
                            ChargeAmountT = getTransactionCharges(dr3.Item("CDS_NUMBER").ToString)
                            TotalCharges = ChargeAmountT + NewCharge
                            If TotalCharges > 0 Then
                                Dim InterCompanyAccountName = "", InterCompanyAccountNumber = ""
                                Dim dssIntCompAccss As DataSet = getInterCompACCS(dr3.Item("CDS_NUMBER").ToString)
                                If dssIntCompAccss.Tables(0).Rows.Count > 0 Then
                                    InterCompanyAccountName = dssIntCompAccss.Tables(0).Rows(0).Item("AccountName").ToString
                                    InterCompanyAccountNumber = dssIntCompAccss.Tables(0).Rows(0).Item("AccountNumber").ToString
                                Else
                                    InterCompanyAccountName = ""
                                    InterCompanyAccountNumber = ""
                                End If
                                Dim stmnt As String = " "
                                stmnt = stmnt & " INSERT INTO ClientInvoices_Temp ([ClientNo],[AssetManager],[DateFrom],[DateTo],[BilledBy],[ChargeCode],[PortfolioValue],[ChargeAmount],[Holder],[ChargesTransactions],[TotalCharges],[InterCompanyAccountName],[InterCompanyAccountNumber])VALUES(@ClientNo,@AssetManager,@DateFrom,@DateTo,@BilledBy,@ChargeCode,@PortfolioValue,@ChargeAmount,@Holder,@ChargesTransactions,@TotalCharges,@InterCompanyAccountName,@InterCompanyAccountNumber) "
                                Using cn4 = New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("connpath"))
                                    Using cmd4 As New SqlCommand(stmnt, cn4)
                                        cmd4.CommandType = CommandType.Text
                                        cmd4.CommandTimeout = 0
                                        cmd4.Parameters.AddWithValue("@ClientNo", dr3.Item("CDS_NUMBER").ToString)
                                        cmd4.Parameters.AddWithValue("@AssetManager", cmbAssetManager.Value)
                                        cmd4.Parameters.AddWithValue("@DateFrom", txtFromDate.Text)
                                        cmd4.Parameters.AddWithValue("@DateTo", txtToDate.Text)
                                        cmd4.Parameters.AddWithValue("@BilledBy", Session("Username"))
                                        cmd4.Parameters.AddWithValue("@ChargeCode", chargeCode)
                                        cmd4.Parameters.AddWithValue("@PortfolioValue", PortfolioValueAmount)
                                        cmd4.Parameters.AddWithValue("@ChargeAmount", NewCharge)
                                        cmd4.Parameters.AddWithValue("@ChargesTransactions", ChargeAmountT)
                                        cmd4.Parameters.AddWithValue("@TotalCharges", TotalCharges)
                                        cmd4.Parameters.AddWithValue("@Holder", dr3.Item("Names").ToString)
                                        cmd4.Parameters.AddWithValue("@InterCompanyAccountName", InterCompanyAccountName)
                                        cmd4.Parameters.AddWithValue("@InterCompanyAccountNumber", InterCompanyAccountNumber)
                                        If cn4.State = ConnectionState.Open Then cn4.Close()
                                        cn4.Open()
                                        cmd4.ExecuteNonQuery()
                                        cn4.Close()
                                    End Using
                                End Using
                            End If
                            'insert
                        End If
                    End Using
                Next
                getNewInvoices()
            End If
        End Using
        btnGetDetails.Enabled = True
        btnSave.Enabled = True
    End Sub
    Function getInterCompACCS(ByVal CDSNumber As String) As DataSet
        Using cn = New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("connpath"))
            Dim ds As New DataSet
            Dim cmd = New SqlCommand("SELECT B.AccountName,B.AccountNumber FROM (SELECT TOP 1 InterCompanyAccount FROM Client_AssetManagers where ClientNo=@ClientNo and AssetManager=@AssetManager and ISNULL(InterCompanyAccount,'')<>'') A JOIN Para_InterCompanyAccounts B ON A.InterCompanyAccount=B.AccountNumber", cn)
            cmd.Parameters.AddWithValue("@ClientNo", CDSNumber)
            cmd.Parameters.AddWithValue("@AssetManager", cmbAssetManager.Value)
            Dim adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "ClientInvoices")
            Return ds
        End Using
    End Function
    Public Sub getNewInvoices()
        If cmbAssetManager.Text <> "" And IsDate(txtToDate.Text) = True And IsDate(txtFromDate.Text) = True Then
            Using cn = New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("connpath"))
                Dim ds As New DataSet
                Dim cmd = New SqlCommand(" SELECT *, FORMAT(DateBilled,'dd MMM yyyy HH:mm','en-us') as DateCreated1,FORMAT(DateFrom,'dd MMM yyyy','en-us') as DateFrom1,FORMAT(DateTo,'dd MMM yyyy','en-us') as DateTo1, CASE Posted when 0 then 'New' when 1 then 'Authorised' when 2 then 'Rejected' end as status FROM ClientInvoices_Temp WHERE AssetManager=@AssetManager AND ISNULL(LivePosted,0)<>1 order by Holder ", cn)
                cmd.CommandType = CommandType.Text
                cmd.Parameters.AddWithValue("@AssetManager", cmbAssetManager.Value)
                Dim adp = New SqlDataAdapter(cmd)
                adp.Fill(ds, "ClientInvoices_Temp")
                If ds.Tables(0).Rows.Count > 0 Then
                    grdNewAccountsToBill.DataSource = ds
                    grdNewAccountsToBill.DataBind()
                Else
                    grdNewAccountsToBill.DataSource = Nothing
                    grdNewAccountsToBill.DataBind()
                End If
            End Using
        End If
    End Sub
    Function getNewInvoicesFXN() As DataSet
        If cmbAssetManager.Text <> "" And IsDate(txtToDate.Text) = True Then
            Using cn = New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("connpath"))
                Dim ds As New DataSet
                Dim cmd = New SqlCommand(" SELECT *, FORMAT(DateBilled,'dd MMM yyyy HH:mm','en-us') as DateCreated1,FORMAT(DateFrom,'dd MMM yyyy','en-us') as DateFrom1,FORMAT(DateTo,'dd MMM yyyy','en-us') as DateTo1, CASE Posted when 0 then 'New' when 1 then 'Authorised' when 2 then 'Rejected' end as status FROM ClientInvoices_Temp WHERE AssetManager=@AssetManager AND ISNULL(LivePosted,0)<>1  order by Holder ", cn)
                cmd.CommandType = CommandType.Text
                cmd.Parameters.AddWithValue("@AssetManager", cmbAssetManager.Value)
                Dim adp = New SqlDataAdapter(cmd)
                adp.Fill(ds, "ClientInvoices_Temp")
                Return ds
            End Using
        End If
    End Function
    Protected Sub grdNewAccountsToBill_DataBinding(sender As Object, e As EventArgs) Handles grdNewAccountsToBill.DataBinding
        grdNewAccountsToBill.DataSource = getNewInvoicesFXN()
    End Sub
    Protected Sub chkSelectAll_CheckedChanged(sender As Object, e As EventArgs) Handles chkSelectAll.CheckedChanged
        Dim myGridView As New ASPxGridView
        myGridView = grdNewAccountsToBill
        If chkSelectAll.Checked = True Then
            Dim keys As List(Of Object) = myGridView.GetCurrentPageRowValues(New String() {"ID"})
            For Each key As Object In keys
                Dim chk As ASPxCheckBox = TryCast(myGridView.FindRowCellTemplateControlByKey(key, TryCast(myGridView.Columns("Selec"), GridViewDataColumn), "chk1"), ASPxCheckBox)
                chk.Checked = True
            Next
        Else
            Dim keys As List(Of Object) = myGridView.GetCurrentPageRowValues(New String() {"ID"})
            For Each key As Object In keys
                Dim chk As ASPxCheckBox = TryCast(myGridView.FindRowCellTemplateControlByKey(key, TryCast(myGridView.Columns("Selec"), GridViewDataColumn), "chk1"), ASPxCheckBox)
                chk.Checked = False
            Next
        End If
    End Sub
    Sub saveDATA()
        If SomeInvoicesDontHaveInterCompanyAccounts() = True Then
            msgbox("Some selected invoices do not have Inter Company Accounts")
            Exit Sub
        End If
        Dim myGridView As New ASPxGridView
        myGridView = grdNewAccountsToBill
        Dim keys As List(Of Object) = myGridView.GetCurrentPageRowValues(New String() {"ID"})
        For Each key As Object In keys
            If TryCast(myGridView.FindRowCellTemplateControlByKey(key, TryCast(myGridView.Columns("Selec"), GridViewDataColumn), "chk1"), ASPxCheckBox).Checked = True Then
                Dim RecordID As String = ""
                RecordID = TryCast(myGridView.FindRowCellTemplateControlByKey(key, TryCast(myGridView.Columns("ID"), GridViewDataColumn), "lblID"), ASPxLabel).Text
                Dim stmnt As String = " "
                stmnt = stmnt & " INSERT INTO ClientInvoices ([ClientNo],[AssetManager],[DateFrom],[DateTo],[BilledBy],[ChargeCode],[PortfolioValue],[ChargeAmount],[Holder],[ChargesTransactions],[TotalCharges],[InterCompanyAccountName],[InterCompanyAccountNumber]) "
                stmnt = stmnt & " SELECT [ClientNo],[AssetManager],[DateFrom],[DateTo],[BilledBy],[ChargeCode],[PortfolioValue],[ChargeAmount],[Holder],[ChargesTransactions],[TotalCharges],[InterCompanyAccountName],[InterCompanyAccountNumber] FROM ClientInvoices_Temp WHERE ID=@RecordID "
                stmnt = stmnt & "  AND ISNULL(LivePosted,0)=0 AND ClientNo NOT IN (SELECT DISTINCT ClientNo FROM ClientInvoices WHERE AssetManager=@AssetManager and ISNULL(Posted,0) in (0,1) AND (DateFrom BETWEEN @DateFrom AND @DateTo or DateTo BETWEEN @DateFrom AND @DateTo)) "
                stmnt = stmnt & " UPDATE ClientInvoices_Temp SET LivePosted=1 WHERE ID=@RecordID "
                Using cn = New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("connpath"))
                    Using cmd As New SqlCommand(stmnt, cn)
                        cmd.CommandType = CommandType.Text
                        cmd.CommandTimeout = 0
                        cmd.Parameters.AddWithValue("@RecordID", RecordID)
                        cmd.Parameters.AddWithValue("@AssetManager", cmbAssetManager.Value)
                        cmd.Parameters.AddWithValue("@DateFrom", txtFromDate.Text)
                        cmd.Parameters.AddWithValue("@DateTo", txtToDate.Text)
                        If cn.State = ConnectionState.Open Then cn.Close()
                        cn.Open()
                        cmd.ExecuteNonQuery()
                        cn.Close()
                    End Using
                End Using
            End If
        Next
        getNewInvoices()
        msgbox("Invoice/s Posted successfully,awaiting authorization")
        'Response.Write("<script>alert('Invoice/s Posted successfully,awaiting authorization') ; location.href='frmInvoiceMultiple.aspx'</script>")
    End Sub
    Function SomeInvoicesDontHaveInterCompanyAccounts() As Boolean
        Dim myGridView As New ASPxGridView
        myGridView = grdNewAccountsToBill
        Dim numRecs As Long = 0
        Dim keys As List(Of Object) = myGridView.GetCurrentPageRowValues(New String() {"ID"})
        For Each key As Object In keys
            If TryCast(myGridView.FindRowCellTemplateControlByKey(key, TryCast(myGridView.Columns("Selec"), GridViewDataColumn), "chk1"), ASPxCheckBox).Checked = True Then
                Dim ACCNUM As String = ""
                ACCNUM = TryCast(myGridView.FindRowCellTemplateControlByKey(key, TryCast(myGridView.Columns("InterCompanyAccountNumberC"), GridViewDataColumn), "lblInterCompanyAccountNumber"), ASPxLabel).Text
                If ACCNUM.Trim = "" Then
                    numRecs += 1
                End If
            End If
        Next
        If numRecs > 0 Then
            Return True
        Else
            Return False
        End If
    End Function
    Sub removeDATA()
        Using cn = New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("connpath"))
            Dim ds As New DataSet
            Dim cmd = New SqlCommand("DELETE FROM ClientInvoices_Temp where AssetManager=@AssetManager", cn)
            cmd.CommandType = CommandType.Text
            cmd.Parameters.AddWithValue("@AssetManager", cmbAssetManager.Value)
            If cn.State = ConnectionState.Open Then cn.Close()
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()
        End Using
    End Sub
    Protected Sub btnGetDetails_Click(sender As Object, e As EventArgs) Handles btnGetDetails.Click
        If IsDate(txtFromDate.Text) = False Or IsDate(txtToDate.Text) = False Then
            msgbox("Select Date Range")
            Exit Sub
        ElseIf CDate(txtFromDate.Text) > CDate(txtToDate.Text) Then
            msgbox("Select valid Date Range")
            Exit Sub
        Else
            InsertChargeDetails()
        End If
    End Sub
    Function accountAlreadyBilledinPeriod(ByVal CDSNo As String) As Boolean
        Using cn = New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("connpath"))
            Dim ds As New DataSet
            Dim cmd = New SqlCommand("SELECT * FROM ClientInvoices WHERE ClientNo=@ClientNo and AssetManager=@AssetManager and ISNULL(Posted,0) in (0,1) AND (DateFrom BETWEEN @DateFrom AND @DateTo or DateTo BETWEEN @DateFrom AND @DateTo) ORDER BY ID DESC", cn)
            cmd.Parameters.AddWithValue("@ClientNo", CDSNo)
            cmd.Parameters.AddWithValue("@AssetManager", cmbAssetManager.Value)
            cmd.Parameters.AddWithValue("@DateFrom", txtFromDate.Text)
            cmd.Parameters.AddWithValue("@DateTo", txtToDate.Text)
            Dim adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "ClientInvoices")
            If ds.Tables(0).Rows.Count > 0 Then
                Return True
            Else
                Return False
            End If
        End Using
    End Function
End Class
