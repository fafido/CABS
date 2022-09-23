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

Partial Class Corp_Enquiries
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
                cmbEvent.SelectedIndex = 0
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Sub GetDividendsCASH()
        Using cn = New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("connpath"))
            Dim ds As New DataSet
            Dim cmd = New SqlCommand("SELECT a.Company,a.Div_No,format(a.date_payment,'dd-MMMM-yyyy','en-us') as [Payment Date],a.shareholder as [Holder No.],a.holder as [Names],a.AssetManager as [Asset Manager],a.Shares_held as [Shares Held],a.actual_gross as Gross,a.actual_tax as [Tax],a.actual_nett as [Net Amount],isnull(c.PaidAmount,0) as [Paid Amount],a.actual_nett-isnull(c.PaidAmount,0) as [Remaining Amount],ISNULL(c.WriteffAmt,0) as [Write-off Amount] FROM dividend a left outer join (SELECT P.company,P.Div_No,P.Shareholder,P.AssetManager,sum(P.PaidAmount) as PaidAmount,SUM(WriteoffAmount) AS WriteffAmt FROM (SELECT b.Company,b.Div_No,b.Shareholder,b.AssetManager,case when b.PaymentType='Write-off' then b.AmountPaid else 0 end as WriteoffAmount,case when b.PaymentType='Cash Dividend' then b.AmountPaid else 0 end as PaidAmount FROM DivPayments b WHERE ISNULL(b.Authorized,0) in (0,1)) P GROUP BY P.company,P.Div_No,P.Shareholder,P.AssetManager) c On a.company=c.Company and a.div_no=c.Div_No and a.shareholder=c.Shareholder and a.AssetManager=c.AssetManager join div_instr yy on a.company=yy.company and a.div_no=yy.div_no where a.shareholder=@shareholder and yy.Instr_type='Cash' ORDER BY a.Company,a.div_no desc", cn)
            cmd.Parameters.AddWithValue("@shareholder", lstNameSearch.SelectedItem.Value)
            Dim adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "dividend")
            If ds.Tables(0).Rows.Count > 0 Then
                grdDividend.DataSource = ds
                grdDividend.DataBind()
            Else
                grdDividend.DataSource = Nothing
                grdDividend.DataBind()
            End If
        End Using
    End Sub
    Sub GetDividendsSCRIP()
        Using cn = New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("connpath"))
            Dim ds As New DataSet
            Dim cmd = New SqlCommand("SELECT a.Company,a.Div_No,format(a.date_payment,'dd-MMMM-yyyy','en-us') as [Payment Date],a.shareholder as [Holder No.],a.holder as [Names],a.AssetManager as [Asset Manager],a.Shares_held as [Shares Held],a.actual_gross as Gross,a.actual_tax as [Tax],a.actual_nett as [Offered Net Amount],a.offer_shares as [Offered Shares],a.Actual_shares as [Accepted Shares],c.ScripShares as [Scrip Shares],a.offer_cash as [Accepted Cash],isnull(c.PaidAmount,0) as [Paid Amount],a.actual_nett-isnull(c.PaidAmount,0) as [Remaining Amount],c.WriteffAmt as [Write-off Amount] FROM dividend a left outer join (SELECT P.company,P.Div_No,P.Shareholder,P.AssetManager,sum(P.PaidAmount) as PaidAmount,sum(P.Shares) as ScripShares,sum(P.WriteoffAmount) AS WriteffAmt FROM (SELECT b.Company,b.Div_No,b.Shareholder,b.AssetManager,case when b.PaymentType='Cash Dividend' then b.AmountPaid else 0 end as PaidAmount,case when b.PaymentType='Write-off' then b.AmountPaid else 0 end as WriteoffAmount,b.shares FROM DivPayments b WHERE ISNULL(b.Authorized,0) in (0,1)) P GROUP BY P.company,P.Div_No,P.Shareholder,P.AssetManager) c On a.company=c.Company and a.div_no=c.Div_No and a.shareholder=c.Shareholder and a.AssetManager=c.AssetManager join div_instr yy on a.company=yy.company and a.div_no=yy.div_no where a.shareholder=@shareholder and yy.Instr_type='Scrip' ORDER BY a.Company,a.div_no desc", cn)
            cmd.Parameters.AddWithValue("@shareholder", lstNameSearch.SelectedItem.Value)
            Dim adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "dividend")
            If ds.Tables(0).Rows.Count > 0 Then
                grdDividendScrip.DataSource = ds
                grdDividendScrip.DataBind()
            Else
                grdDividendScrip.DataSource = Nothing
                grdDividendScrip.DataBind()
            End If
        End Using
    End Sub
    Sub GetDividendsSpecie()
        Using cn = New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("connpath"))
            Dim ds As New DataSet
            Dim cmd = New SqlCommand("SELECT a.Company,a.Div_No,format(a.date_payment,'dd-MMMM-yyyy','en-us') as [Payment Date],a.shareholder as [Holder No.],a.holder as [Names],a.AssetManager as [Asset Manager],a.Shares_held as [Shares Held],a.SpecieGross as Gross,a.SpecieTax as [Tax],a.DivSpecieShares as [New Shares] FROM dividend a join div_instr yy on a.company=yy.company and a.div_no=yy.div_no where a.shareholder=@shareholder and yy.Instr_type='Specie' ORDER BY a.Company,a.div_no desc", cn)
            cmd.Parameters.AddWithValue("@shareholder", lstNameSearch.SelectedItem.Value)
            Dim adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "dividend")
            If ds.Tables(0).Rows.Count > 0 Then
                grdDividendSpecie.DataSource = ds
                grdDividendSpecie.DataBind()
            Else
                grdDividendSpecie.DataSource = Nothing
                grdDividendSpecie.DataBind()
            End If
        End Using
    End Sub
    Sub GetBonus()
        Using cn = New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("connpath"))
            Dim ds As New DataSet
            Dim cmd = New SqlCommand("SELECT a.Company,a.Bonus_No AS [Issue No.],format(yy.date_payment,'dd-MMMM-yyyy','en-us') as [Payment Date],a.shareholder as [Holder No.],a.holder as [Names],a.AssetManager as [Asset Manager],a.Shares_held as [Shares Held],a.Bonus_Shares as [Bonus Shares],a.Scaled_Shares as [Rounded Shares],a.Shares_Held+a.Scaled_Shares as [New Shares] FROM Bonus_Issue a join Bonus yy on a.company=yy.company and a.Bonus_No=yy.div_no where a.shareholder=@shareholder ORDER BY a.Company,a.Bonus_No desc", cn)
            cmd.Parameters.AddWithValue("@shareholder", lstNameSearch.SelectedItem.Value)
            Dim adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "Bonus_Issue")
            If ds.Tables(0).Rows.Count > 0 Then
                grdBonus.DataSource = ds
                grdBonus.DataBind()
            Else
                grdBonus.DataSource = Nothing
                grdBonus.DataBind()
            End If
        End Using
    End Sub
    Sub GetRights()
        Using cn = New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("connpath"))
            Dim ds As New DataSet
            Dim cmd = New SqlCommand("SELECT a.Company,a.Issue_no AS [Issue No.],format(yy.date_payment,'dd-MMMM-yyyy','en-us') as [Payment Date],a.Origin as [Holder No.],a.holder as [Names],a.AssetManager as [Asset Manager],a.La_No,a.Shares as [Shares Held],a.Rights as [Rights Offered],a.Cost,a.AcceptedRights as [Accepted Rights],a.AcceptedCost as [Accepted Cost], a.AmountPaid,a.Bank,a.BankBranch,a.BankAccount FROM rights_dets a join Rights_Instr yy on a.company=yy.company and a.Issue_no=yy.div_no where a.Origin=@shareholder ORDER BY a.Company,a.Issue_no desc", cn)
            cmd.Parameters.AddWithValue("@shareholder", lstNameSearch.SelectedItem.Value)
            Dim adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "Rights_dets")
            If ds.Tables(0).Rows.Count > 0 Then
                grdRights.DataSource = ds
                grdRights.DataBind()
            Else
                grdRights.DataSource = Nothing
                grdRights.DataBind()
            End If
        End Using
    End Sub
    Sub GetSplit()
        Using cn = New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("connpath"))
            Dim ds As New DataSet
            Dim cmd = New SqlCommand("SELECT a.Company,a.Split_No AS [Issue No.],format(yy.date_payment,'dd-MMMM-yyyy','en-us') as [Payment Date],a.shareholder as [Holder No.],a.holder as [Names],a.AssetManager as [Asset Manager],a.Shares_held as [Shares Held],a.Split_Shares as [Split Shares],a.Scaled_Shares as [Rounded Shares],a.Scaled_Shares as [New Shares] FROM Split_Issue a join Split_instr yy on a.company=yy.company and a.Split_No=yy.div_no where a.shareholder=@shareholder ORDER BY a.Company,a.Split_No desc", cn)
            cmd.Parameters.AddWithValue("@shareholder", lstNameSearch.SelectedItem.Value)
            Dim adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "Split_issue")
            If ds.Tables(0).Rows.Count > 0 Then
                grdSplit.DataSource = ds
                grdSplit.DataBind()
            Else
                grdSplit.DataSource = Nothing
                grdSplit.DataBind()
            End If
        End Using
    End Sub
    Sub GetConsolidation()
        Using cn = New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("connpath"))
            Dim ds As New DataSet
            Dim cmd = New SqlCommand("SELECT a.Company,a.Consol_No AS [Issue No.],format(yy.date_payment,'dd-MMMM-yyyy','en-us') as [Payment Date],a.shareholder as [Holder No.],a.holder as [Names],a.AssetManager as [Asset Manager],a.Shares_held as [Shares Held],a.Consol_Shares as [Consolidated Shares],a.Scaled_Shares as [Rounded Shares],a.Scaled_Shares as [New Shares] FROM Consol_Issue a join Consol_instr yy on a.company=yy.company and a.Consol_No=yy.div_no where a.shareholder=@shareholder ORDER BY a.Company,a.Consol_No desc", cn)
            cmd.Parameters.AddWithValue("@shareholder", lstNameSearch.SelectedItem.Value)
            Dim adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "Consol_Issue")
            If ds.Tables(0).Rows.Count > 0 Then
                grdConsol.DataSource = ds
                grdConsol.DataBind()
            Else
                grdConsol.DataSource = Nothing
                grdConsol.DataBind()
            End If
        End Using
    End Sub
    Sub GetMerge()
        Using cn = New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("connpath"))
            Dim ds As New DataSet
            Dim cmd = New SqlCommand("SELECT a.Company,a.Merger_No AS [Issue No.],format(yy.date_payment,'dd-MMMM-yyyy','en-us') as [Payment Date],a.shareholder as [Holder No.],a.holder as [Names],a.AssetManager as [Asset Manager],a.Shares_held as [Shares Held],a.Merger_Shares as [Merge Shares],a.Scaled_Shares as [Rounded Shares],a.Scaled_Shares as [New Shares],yy.SpecieNewCompany as [New Company] FROM Merger_Issue a join Merger_instr yy on a.company=yy.company and a.Merger_No=yy.div_no where a.shareholder=@shareholder ORDER BY a.Company,a.Merger_No desc", cn)
            cmd.Parameters.AddWithValue("@shareholder", lstNameSearch.SelectedItem.Value)
            Dim adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "Merger_issue")
            If ds.Tables(0).Rows.Count > 0 Then
                grdMerger.DataSource = ds
                grdMerger.DataBind()
            Else
                grdMerger.DataSource = Nothing
                grdMerger.DataBind()
            End If
        End Using
    End Sub
    Protected Sub cmbEvent_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbEvent.SelectedIndexChanged
        If lstNameSearch.SelectedIndex = -1 Then
            msgbox("Search for Account")
            Exit Sub
        End If
        If cmbEvent.Text = "Dividend" Then
            GetDividendsCASH()
            GetDividendsSCRIP()
            GetDividendsSpecie()
            Panel001Div.Visible = True
            Panel001DivScrip.Visible = True
            Panel001DivSpecie.Visible = True
            Panel002Rights.Visible = False
            Panel003Bonus.Visible = False
            Panel004Split.Visible = False
            Panel005Consol.Visible = False
            Panel006Merger.Visible = False
            Tr11merge.Visible = False
            Tr3consol.Visible = False
            Tr4split.Visible = False
            Tr5bonus.Visible = False
            Tr6rights.Visible = False
            Tr7div.Visible = True
            Tr8div.Visible = True
            Tr9div.Visible = True
        ElseIf cmbEvent.Text = "Rights" Then
            GetRights()
            Panel001Div.Visible = False
            Panel001DivScrip.Visible = False
            Panel001DivSpecie.Visible = False
            Panel002Rights.Visible = True
            Panel003Bonus.Visible = False
            Panel004Split.Visible = False
            Panel005Consol.Visible = False
            Panel006Merger.Visible = False
            Tr11merge.Visible = False
            Tr3consol.Visible = False
            Tr4split.Visible = False
            Tr5bonus.Visible = False
            Tr6rights.Visible = True
            Tr7div.Visible = False
            Tr8div.Visible = False
            Tr9div.Visible = False
        ElseIf cmbEvent.Text = "Bonus" Then
            GetBonus()
            Panel001Div.Visible = False
            Panel001DivScrip.Visible = False
            Panel001DivSpecie.Visible = False
            Panel002Rights.Visible = False
            Panel003Bonus.Visible = True
            Panel004Split.Visible = False
            Panel005Consol.Visible = False
            Panel006Merger.Visible = False
            Tr11merge.Visible = False
            Tr3consol.Visible = False
            Tr4split.Visible = False
            Tr5bonus.Visible = True
            Tr6rights.Visible = False
            Tr7div.Visible = False
            Tr8div.Visible = False
            Tr9div.Visible = False
        ElseIf cmbEvent.Text = "Split" Then
            GetSplit()
            Panel001Div.Visible = False
            Panel001DivScrip.Visible = False
            Panel001DivSpecie.Visible = False
            Panel002Rights.Visible = False
            Panel003Bonus.Visible = False
            Panel004Split.Visible = True
            Panel005Consol.Visible = False
            Panel006Merger.Visible = False
            Tr11merge.Visible = False
            Tr3consol.Visible = False
            Tr4split.Visible = True
            Tr5bonus.Visible = False
            Tr6rights.Visible = False
            Tr7div.Visible = False
            Tr8div.Visible = False
            Tr9div.Visible = False
        ElseIf cmbEvent.Text = "Consolidation" Then
            GetConsolidation()
            Panel001Div.Visible = False
            Panel001DivScrip.Visible = False
            Panel001DivSpecie.Visible = False
            Panel002Rights.Visible = False
            Panel003Bonus.Visible = False
            Panel004Split.Visible = False
            Panel005Consol.Visible = True
            Panel006Merger.Visible = False
            Tr11merge.Visible = False
            Tr3consol.Visible = True
            Tr4split.Visible = False
            Tr5bonus.Visible = False
            Tr6rights.Visible = False
            Tr7div.Visible = False
            Tr8div.Visible = False
            Tr9div.Visible = False
        ElseIf cmbEvent.Text = "Merger" Then
            GetMerge()
            Panel001Div.Visible = False
            Panel001DivScrip.Visible = False
            Panel001DivSpecie.Visible = False
            Panel002Rights.Visible = False
            Panel003Bonus.Visible = False
            Panel004Split.Visible = False
            Panel005Consol.Visible = False
            Panel006Merger.Visible = True
            Tr11merge.Visible = True
            Tr3consol.Visible = False
            Tr4split.Visible = False
            Tr5bonus.Visible = False
            Tr6rights.Visible = False
            Tr7div.Visible = False
            Tr8div.Visible = False
            Tr9div.Visible = False
        ElseIf cmbEvent.Text = "All" Then
            GetDividendsCASH()
            GetDividendsSCRIP()
            GetDividendsSpecie()
            GetBonus()
            GetConsolidation()
            GetSplit()
            GetRights()
            GetMerge()
            Panel001Div.Visible = True
            Panel001DivScrip.Visible = True
            Panel001DivSpecie.Visible = True
            Panel002Rights.Visible = True
            Panel003Bonus.Visible = True
            Panel004Split.Visible = True
            Panel005Consol.Visible = True
            Panel006Merger.Visible = True
            Tr11merge.Visible = True
            Tr3consol.Visible = True
            Tr4split.Visible = True
            Tr5bonus.Visible = True
            Tr6rights.Visible = True
            Tr7div.Visible = True
            Tr8div.Visible = True
            Tr9div.Visible = True
        End If
    End Sub
    Protected Sub ASPxButton11_Click(sender As Object, e As EventArgs) Handles ASPxButton11.Click
        Try
            lstNameSearch.Items.Clear()
            lstNameSearch.DataSource = Nothing
            lstNameSearch.DataBind()
            Using cn = New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("connpath"))
                Dim ds As New DataSet
                Dim cmd = New SqlCommand("select a.cds_number,a.cds_number+' '+case when a.AccountType IN ('C','P') THEN isnull(a.Surname,'') else isnull(forenames,'')+' '+isnull(surname,'') end as namess from accounts_clients a where isnull(a.surname,'')+' '+isnull(a.middlename,'')+' '+isnull(a.forenames,'') +' '+a.cds_number+' '+ISNULL(a.IDNoPP,'') like '%'+ @searchText +'%' order by cds_number", cn)
                cmd.Parameters.AddWithValue("@searchText", txtnamesearch.Text)
                Dim adp = New SqlDataAdapter(cmd)
                adp.Fill(ds, "accounts_clients")
                If ds.Tables(0).Rows.Count > 0 Then
                    lstNameSearch.DataSource = ds.Tables(0)
                    lstNameSearch.TextField = "namess"
                    lstNameSearch.ValueField = "cds_number"
                    lstNameSearch.DataBind()
                Else
                    lstNameSearch.Items.Clear()
                    lstNameSearch.DataSource = Nothing
                    lstNameSearch.DataBind()
                End If
            End Using
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Protected Sub lstNameSearch_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstNameSearch.SelectedIndexChanged
        cmbEvent_SelectedIndexChanged(sender:=New Object, e:=New EventArgs)
    End Sub
End Class
