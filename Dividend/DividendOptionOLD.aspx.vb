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

Partial Class Corp_DivOption
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
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Sub getCompanies()
        Using cn = New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("connpath"))
            Dim ds As New DataSet
            Dim cmd = New SqlCommand("SELECT DISTINCT a.company,b.Fnam FROM div_instr a join para_company b on a.company=b.Company where a.Authorize=3 and a.Instr_type='Option' order by b.Fnam", cn)
            Dim adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "Div_instr")
            If ds.Tables(0).Rows.Count > 0 Then
                cmbCompany.DataSource = ds
                cmbCompany.ValueField = "company"
                cmbCompany.TextField = "Fnam"
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
        cmbDivNo.SelectedIndex = -1
        Dim strSQL As String = ""
        strSQL = "SELECT DISTINCT a.div_no, format(a.date_payment,'MMMM-yyyy','en-us') + ' ' + a.div_type +' '+a.Instr_type +' div no. ' + convert(nvarchar(100),a.div_no) AS displayname FROM div_instr a WHERE a.Authorize=3 and a.company=@company and a.Instr_type='Option' order by a.div_no desc"
        Using cn = New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("connpath"))
            Dim ds As New DataSet
            Dim cmd = New SqlCommand(strSQL, cn)
            cmd.Parameters.AddWithValue("@Company", cmbCompany.Value)
            Dim adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "div_instr")
            If ds.Tables(0).Rows.Count > 0 Then
                cmbDivNo.DataSource = ds
                cmbDivNo.ValueField = "div_no"
                cmbDivNo.TextField = "displayname"
                cmbDivNo.DataBind()
            Else
                cmbDivNo.DataSource = Nothing
                cmbDivNo.DataBind()
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
        strSQL = "select distinct A.SEQ ,isnull(A.Holder,'')+' '+ isnull(convert(nvarchar,A.shareholder),'') as namess from dividend A where isnull(A.Holder,'')+' '+ ISNULL(convert(nvarchar,A.shareholder),'') like '%'+ @strsearch +'%' AND A.Company=@Company AND A.div_no=@divNo"
        Using cn = New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("connpath"))
            Dim ds As New DataSet
            Dim cmd = New SqlCommand(strSQL, cn)
            cmd.Parameters.AddWithValue("@Company", cmbCompany.Value)
            cmd.Parameters.AddWithValue("@divNo", cmbDivNo.Value)
            cmd.Parameters.AddWithValue("@strsearch", txtShareholder.Text)
            Dim adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "dividend")
            If ds.Tables(0).Rows.Count > 0 Then
                lstNAME.DataSource = ds
                lstNAME.ValueField = "SEQ"
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
            Using cmd As New SqlCommand("select A.*,B.rate,B.scrip_price from dividend A join div_instr B on A.company=B.company AND A.div_no=B.div_no where A.SEQ=@ID and A.company=@company and A.div_no=@divNo", con)
                Dim dsmast As New DataSet
                cmd.Parameters.AddWithValue("@Company", cmbCompany.Value)
                cmd.Parameters.AddWithValue("@divNo", cmbDivNo.Value)
                cmd.Parameters.AddWithValue("@ID", lstNAME.Value)
                Dim adp = New SqlDataAdapter(cmd)
                adp.Fill(dsmast, "dividend")
                If dsmast.Tables(0).Rows.Count > 0 Then
                    Dim dr As DataRow = dsmast.Tables(0).Rows(0)
                    txtCDSNo.Text = dr.Item("Shareholder").ToString
                    txtNames.Text = dr.Item("Holder").ToString
                    txtAssetManager.Text = dr.Item("AssetManager").ToString
                    txtSharesheld.Text = dr.Item("Shares_Held").ToString
                    txtDivRate.Text = dr.Item("rate").ToString
                    txtScripPrice.Text = dr.Item("scrip_price").ToString
                    txtGross.Text = dr.Item("actual_gross").ToString
                    txtTax.Text = dr.Item("actual_tax").ToString
                    txtNetOffered.Text = dr.Item("actual_nett").ToString
                    txtOfferedShares.Text = dr.Item("offer_shares").ToString
                    txtAcceptedCash.Text = dr.Item("offer_cash").ToString
                    txtAcceptedShares.Text = dr.Item("actual_shares").ToString
                Else
                    txtCDSNo.Text = ""
                    txtNames.Text = ""
                    txtAssetManager.Text = ""
                    txtSharesheld.Text = ""
                    txtDivRate.Text = ""
                    txtScripPrice.Text = ""
                    txtAcceptedShares.Text = ""
                    txtGross.Text = ""
                    txtTax.Text = ""
                    txtNetOffered.Text = ""
                    txtOfferedShares.Text = ""
                    txtAcceptedCash.Text = ""
                    txtAcceptedShares.Text = ""
                End If
            End Using
        End Using
    End Sub
    Protected Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        If txtCDSNo.Text <> "" And cmbCompany.Text <> "" And cmbDivNo.Text <> "" Then
            If IsNumeric(txtAcceptedShares.Text.Replace(",", "")) = False Then
                msgbox("Enter Accepted shares")
                Exit Sub
            End If
            If lstNAME.SelectedIndex < 0 Then
                msgbox("Select Shareholder")
                Exit Sub
            End If
            Dim strCMD As String = "  "
            strCMD = strCMD & " INSERT DivAcceptAudit(CreatedBy,Company,Div_no,AssetManager,Shareholder,AcceptedShares,AcceptedCash)VALUES(@CreatedBy,@Company,@Div_no,@AssetManager,@Shareholder,@actual_shares,@offer_cash) "
            strCMD = strCMD & " update dividend set offer_cash=@offer_cash,actual_shares=@actual_shares where Company=@Company AND Div_no=@Div_no and Shareholder=@Shareholder and AssetManager=@AssetManager "
            Using cn = New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("connpath"))
                Using cmd As New SqlCommand(strCMD, cn)
                    cmd.Parameters.AddWithValue("@company", cmbCompany.Value)
                    cmd.Parameters.AddWithValue("@Div_no", cmbDivNo.Value)
                    cmd.Parameters.AddWithValue("@Shareholder", txtCDSNo.Text)
                    cmd.Parameters.AddWithValue("@AssetManager", txtAssetManager.Text)
                    cmd.Parameters.AddWithValue("@offer_cash", txtAcceptedCash.Text)
                    cmd.Parameters.AddWithValue("@actual_shares", txtAcceptedShares.Text)
                    cmd.Parameters.AddWithValue("@CreatedBy", Session("Username"))
                    If cn.State = ConnectionState.Open Then cn.Close()
                    cn.Open()
                    cmd.ExecuteNonQuery()
                    cn.Close()
                End Using
            End Using
            msgbox("Option Updated Successfully")
            ClearAll()
        Else
            msgbox("Please search for account to update option")
            Exit Sub
        End If
    End Sub
    Sub ClearAll()
        txtCDSNo.Text = ""
        txtNames.Text = ""
        txtAssetManager.Text = ""
        txtSharesheld.Text = ""
        txtDivRate.Text = ""
        txtScripPrice.Text = ""
        txtAcceptedShares.Text = ""
        txtGross.Text = ""
        txtTax.Text = ""
        txtNetOffered.Text = ""
        txtOfferedShares.Text = ""
        txtAcceptedCash.Text = ""
        txtAcceptedShares.Text = ""
        txtShareholder.Text = ""
        lstNAME.Items.Clear()
        lstNAME.DataSource = Nothing
        lstNAME.DataBind()
    End Sub
    Protected Sub txtAcceptedCash_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAcceptedCash.TextChanged
        Try
            If (txtAcceptedCash.Text <> "") Then
                'If (CDbl(txtAcceptedCash.Text) <= CDbl(txtNetOffered.Text)) Then
                '    txtAcceptedShares.Text = CLng(((CDbl(txtNetOffered.Text) - CDbl(txtAcceptedCash.Text)) / CDbl(txtNetOffered.Text)) * CLng(txtOfferedShares.Text))
                'Else
                '    msgbox("Accepted value cannot be greater than offer value")
                '    txtAcceptedCash.Text = ""
                'End If

                If (CDbl(txtAcceptedCash.Text) = CDbl(txtNetOffered.Text)) Then
                    txtAcceptedShares.Text = CLng(((CDbl(txtNetOffered.Text) - CDbl(txtAcceptedCash.Text)) / CDbl(txtNetOffered.Text)) * CLng(txtOfferedShares.Text))
                Else
                    msgbox("Accepted value should be equal to offered value")
                    txtAcceptedCash.Text = ""
                End If
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Protected Sub txtAcceptedShares_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAcceptedShares.TextChanged
        Try
            If (txtAcceptedShares.Text <> "") Then
                'If (CLng(txtAcceptedShares.Text) <= CLng(txtOfferedShares.Text)) Then
                '    Dim AcceptedShares As Long = CLng(txtAcceptedShares.Text)
                '    Dim NewNet As Double = ((((CLng(txtOfferedShares.Text) - AcceptedShares) * CDbl(txtNetOffered.Text)) / CLng(txtOfferedShares.Text)))
                '    txtAcceptedCash.Text = Replace(FormatNumber(NewNet, 2), ",", "")
                'Else
                '    msgbox("Accepted shares cannot be greater than offer shares")
                '    txtAcceptedShares.Text = ""
                'End If

                If (CLng(txtAcceptedShares.Text) = CLng(txtOfferedShares.Text)) Then
                    Dim AcceptedShares As Long = CLng(txtAcceptedShares.Text)
                    Dim NewNet As Double = ((((CLng(txtOfferedShares.Text) - AcceptedShares) * CDbl(txtNetOffered.Text)) / CLng(txtOfferedShares.Text)))
                    txtAcceptedCash.Text = Replace(FormatNumber(NewNet, 2), ",", "")
                Else
                    msgbox("Accepted shares should be equal to offered shares")
                    txtAcceptedShares.Text = ""
                End If
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
End Class
