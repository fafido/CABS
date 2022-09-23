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

Partial Class Corp_RightsCompute
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
                getCompanies()
                getBanks()
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Sub getCompanies()
        Using cn = New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("connpath"))
            Dim ds As New DataSet
            Dim cmd = New SqlCommand("SELECT DISTINCT company FROM Rights_instr where Authorize=3 order by company", cn)
            Dim adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "Rights_instr")
            If ds.Tables(0).Rows.Count > 0 Then
                cmbCompany.DataSource = ds
                cmbCompany.ValueField = "company"
                cmbCompany.TextField = "company"
                cmbCompany.DataBind()
            Else
                cmbCompany.DataSource = Nothing
                cmbCompany.DataBind()
            End If
        End Using
    End Sub
    Protected Sub cmbCompany_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbCompany.SelectedIndexChanged
        getDivnumber()
    End Sub
    Sub getDivnumber()
        cmbIssueNo.SelectedIndex = -1
        Dim strSQL As String = ""
        strSQL = "SELECT DISTINCT div_no FROM Rights_instr where Authorize=3 and company=@company order by div_no desc"
        Using cn = New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("connpath"))
            Dim ds As New DataSet
            Dim cmd = New SqlCommand(strSQL, cn)
            cmd.Parameters.AddWithValue("@Company", cmbCompany.Value)
            Dim adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "Rights_instr")
            If ds.Tables(0).Rows.Count > 0 Then
                cmbIssueNo.DataSource = ds
                cmbIssueNo.ValueField = "div_no"
                cmbIssueNo.TextField = "div_no"
                cmbIssueNo.DataBind()
            Else
                cmbIssueNo.DataSource = Nothing
                cmbIssueNo.DataBind()
            End If
        End Using
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
        strSQL = "select distinct A.RightsId ,isnull(A.Holder,'')+' '+ isnull(convert(nvarchar,A.Origin),'') as namess from rights_dets A where isnull(A.Holder,'')+' '+ ISNULL(convert(nvarchar,A.Origin),'') like '%'+ @strsearch +'%' AND A.Company=@Company AND A.Issue_no=@Issue_no"
        Using cn = New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("connpath"))
            Dim ds As New DataSet
            Dim cmd = New SqlCommand(strSQL, cn)
            cmd.Parameters.AddWithValue("@Company", cmbCompany.Value)
            cmd.Parameters.AddWithValue("@Issue_no", cmbIssueNo.Value)
            cmd.Parameters.AddWithValue("@strsearch", txtShareholder.Text)
            Dim adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "rights_dets")
            If ds.Tables(0).Rows.Count > 0 Then
                lstNAME.DataSource = ds
                lstNAME.ValueField = "RightsId"
                lstNAME.TextField = "namess"
                lstNAME.DataBind()
            Else
                lstNAME.DataSource = Nothing
                lstNAME.DataBind()
            End If
        End Using
    End Sub
    Protected Sub lstNAME_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstNAME.SelectedIndexChanged
        Try
            BindGrid1()
        Catch ex As Exception
            msgbox(ex.Message.ToString)
        End Try
    End Sub
    Public Sub BindGrid1()
        Using con As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("connpath"))
            Using cmd As New SqlCommand("select A.*,(select top 1 b.rate from Rights_instr b where b.company=a.Company and b.div_no=a.Issue_no) as priceperShare from rights_dets A where A.RightsId=@RightsId and a.company=@company and A.Issue_no=@Issue_no", con)
                Dim dsmast As New DataSet
                cmd.Parameters.AddWithValue("@Company", cmbCompany.Value)
                cmd.Parameters.AddWithValue("@Issue_no", cmbIssueNo.Value)
                cmd.Parameters.AddWithValue("@RightsId", lstNAME.Value)
                Dim adp = New SqlDataAdapter(cmd)
                adp.Fill(dsmast, "rights_dets")
                If dsmast.Tables(0).Rows.Count > 0 Then
                    Dim dr As DataRow = dsmast.Tables(0).Rows(0)
                    txtLANo.Text = dr.Item("La_No").ToString
                    txtCDSNo.Text = dr.Item("Origin").ToString
                    txtNames.Text = dr.Item("Holder").ToString
                    txtSharesheld.Text = dr.Item("Shares").ToString
                    txtRights.Text = dr.Item("Rights").ToString
                    txtRightsCost.Text = dr.Item("Cost").ToString
                    txtAcceptedShares.Text = dr.Item("AcceptedRights").ToString
                    txtAcceptedCost.Text = dr.Item("AcceptedCost").ToString
                    txtAmountPaid.Text = dr.Item("AmountPaid").ToString
                    txtPrice.Text = dr.Item("priceperShare").ToString
                    Try
                        cmbBank.Value = dr.Item("Bank").ToString
                    Catch ex As Exception
                        cmbBank.SelectedIndex = -1
                    End Try
                    txtBranch.Text = dr.Item("BankBranch").ToString
                    txtAccount.Text = dr.Item("BankAccount").ToString
                Else
                    txtLANo.Text = ""
                    txtCDSNo.Text = ""
                    txtNames.Text = ""
                    txtSharesheld.Text = ""
                    txtRights.Text = ""
                    txtRightsCost.Text = ""
                    txtAcceptedShares.Text = ""
                    txtAcceptedCost.Text = ""
                    txtAmountPaid.Text = ""
                    txtPrice.Text = ""
                    cmbBank.SelectedIndex = -1
                    txtBranch.Text = ""
                    txtAccount.Text = ""
                    lstNAME.Items.Clear()
                    lstNAME.DataSource = Nothing
                    lstNAME.DataBind()
                End If
            End Using
        End Using
    End Sub
    Protected Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        If txtCDSNo.Text <> "" And cmbCompany.Text <> "" And cmbIssueNo.Text <> "" Then
            If IsNumeric(txtAcceptedShares.Text.Replace(",", "")) = False Then
                msgbox("Enter Accepted rights")
                Exit Sub
            End If
            If lstNAME.SelectedIndex < 0 Then
                msgbox("Select Shareholder")
                Exit Sub
            End If
            If CLng(txtAcceptedShares.Text) > CLng(txtRights.Text) Or CLng(txtAcceptedShares.Text) <= 0 Then
                msgbox("Accepted shares must be greater than zero and less than or eaual to " & txtRights.Text)
                Exit Sub
            End If
            If CDbl(txtAmountPaid.Text) < CDbl(txtAcceptedCost.Text) Then
                msgbox("Amount Paid should be greater than or equal to " & txtAcceptedCost.Text)
                Exit Sub
            End If

            Dim BankDiv As String = ""
            If (cmbBank.Text.Trim <> "") Then
                BankDiv = cmbBank.Value
            Else
                BankDiv = ""
            End If
            If BankDiv.Trim = "" Then
                msgbox("Select Bank")
                Exit Sub
            End If

            If txtAccount.Text.Trim = "" Then
                msgbox("Enter Bank Account")
                Exit Sub
            End If

            Dim strCMD As String = "  "
            strCMD = strCMD & " update rights_dets set Bank=@Bank,BankBranch=@BankBranch,BankAccount=@BankAccount,AcceptedDate=getdate(),accepted=1,AcceptedRights=@AcceptedRights,AcceptedCost=@AcceptedCost,AmountPaid=@AmountPaid,Accepted_By_ID=@Accepted_By where Company=@Company AND Issue_no=@Issue_no and Origin=@Origin and La_No=@La_No "
            Using cn = New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("connpath"))
                Using cmd As New SqlCommand(strCMD, cn)
                    cmd.Parameters.AddWithValue("@company", cmbCompany.Value)
                    cmd.Parameters.AddWithValue("@Issue_no", cmbIssueNo.Value)
                    cmd.Parameters.AddWithValue("@Origin", txtCDSNo.Text)
                    cmd.Parameters.AddWithValue("@La_No", txtLANo.Text)
                    cmd.Parameters.AddWithValue("@AcceptedRights", txtAcceptedShares.Text)
                    cmd.Parameters.AddWithValue("@AcceptedCost", txtAcceptedCost.Text)
                    cmd.Parameters.AddWithValue("@AmountPaid", txtAmountPaid.Text)
                    cmd.Parameters.AddWithValue("@Accepted_By", Session("Username"))
                    cmd.Parameters.AddWithValue("@Bank", BankDiv)
                    cmd.Parameters.AddWithValue("@BankBranch", txtBranch.Text)
                    cmd.Parameters.AddWithValue("@BankAccount", txtAccount.Text)
                    If cn.State = ConnectionState.Open Then cn.Close()
                    cn.Open()
                    cmd.ExecuteNonQuery()
                    cn.Close()
                End Using
            End Using
            msgbox("Acceptance Updated Successfully")
            ClearAll()
        Else
            msgbox("Please search for account to accept")
                Exit Sub
            End If
    End Sub
    Sub ClearAll()
        txtLANo.Text = ""
        txtCDSNo.Text = ""
        txtNames.Text = ""
        txtSharesheld.Text = ""
        txtRights.Text = ""
        txtRightsCost.Text = ""
        txtAcceptedShares.Text = ""
        txtAcceptedCost.Text = ""
        txtAmountPaid.Text = ""
        txtPrice.Text = ""
        cmbBank.SelectedIndex = -1
        txtBranch.Text = ""
        txtAccount.Text = ""
        lstNAME.Items.Clear()
        lstNAME.DataSource = Nothing
        lstNAME.DataBind()
    End Sub
    Protected Sub txtAcceptedShares_TextChanged(sender As Object, e As EventArgs) Handles txtAcceptedShares.TextChanged
        If IsNumeric(txtAcceptedShares.Text.Replace(",", "")) = True And IsNumeric(txtPrice.Text) = True Then
            If CLng(txtAcceptedShares.Text) <= CLng(txtRights.Text) And CLng(txtAcceptedShares.Text) > 0 Then
                txtAcceptedCost.Text = (CDbl(txtPrice.Text) * CLng(txtAcceptedShares.Text))
            Else
                txtAcceptedShares.Text = ""
            End If
        Else
            txtAcceptedShares.Text = ""
        End If
    End Sub
    Sub getBanks()
        Using cn = New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("connpath"))
            Dim ds As New DataSet
            Dim cmd = New SqlCommand("SELECT ISNULL(BANK,'') +'|'+ ISNULL(bank_name,'') AS DispName,bank FROM para_bank ORDER BY DispName", cn)
            Dim adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "para_bank")
            If ds.Tables(0).Rows.Count > 0 Then
                cmbBank.DataSource = ds
                cmbBank.ValueField = "bank"
                cmbBank.TextField = "DispName"
                cmbBank.DataBind()
            Else
                cmbBank.DataSource = Nothing
                cmbBank.DataBind()
            End If
        End Using
    End Sub
End Class
