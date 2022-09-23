Partial Class Custodian_AccountEnquiry
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
                checkSessionState()
                lblsitemap.Text = "Enquiries >> Account Details Enquiry"
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub btnHolderNumSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnHolderNumSearch.Click
        Try
            Dim ds As New DataSet
            'cmd = New SqlCommand("Select sum(shares) as shaeres,mast.cds_number,names.surname+' '+names.forenames as Holder,mast.company,mast.locked from mast,names where mast.cds_number = '" & txtshareholder.Text & "' and names.cds_number=mast.cds_number group by mast.cds_number,names.surname,names.forenames,mast.company,mast.locked", cn)
            cmd = New SqlCommand("Select sum(shares) as shaeres,mast.cds_number,names.surname+' '+names.forenames as Holder,mast.company,mast.locked from mast,names where mast.cds_number = '" & txtshareholder.Text & "' and names.cds_number=mast.cds_number and names.nominee_code='" & Session("Brokercode").ToString & "' group by mast.cds_number,names.surname,names.forenames,mast.company,mast.locked", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "mast")
            If (ds.Tables(0).Rows.Count > 0) Then
                gdPortfolioResults.DataSource = ds.Tables(0)
                gdPortfolioResults.DataBind()
            Else
                gdPortfolioResults.DataSource = Nothing
                gdPortfolioResults.DataBind()
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub BindGridData()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("Select sum(shares) as shaeres,mast.cds_number,names.surname+' '+names.forenames as Holder,mast.company,mast.locked from mast,names where mast.cds_number = '" & txtshareholder.Text & "' and names.cds_number=mast.cds_number", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "mast")
            If (ds.Tables(0).Rows.Count > 0) Then
                gdPortfolioResults.DataSource = ds.Tables(0)
                gdPortfolioResults.DataBind()
            Else
                gdPortfolioResults.DataSource = Nothing
                gdPortfolioResults.DataBind()
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Protected Sub btnSearchName_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearchName.Click
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("Select distinct surname+' '+forenames+' '+cds_number as holder from Accounts_Clients  where surname like '%" + txtSearch.Text + "%' and cds_number in (select cds_number from Accounts_Clients where Custodian='" + Session("usercompany") + "')", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "names")
            If (ds.Tables(0).Rows.Count > 0) Then
                lstNames.DataSource = ds.Tables("names")
                lstNames.DataValueField = "holder"
                lstNames.DataBind()
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub getNamelike()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select CDS_Number from accounts_clients where surname+' '+forenames+' '+cds_number = '" & lstNames.SelectedItem.Text & "'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "names")
            txtshareholder.Text = ds.Tables(0).Rows(0).Item("CDS_number").ToString
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Protected Sub btnSelect_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSelect.Click
        Try
            getNamelike()
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub btnPrintStatement_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPrintStatement.Click
        Try
            If (txtshareholder.Text <> "") Then
                Dim strscript As String
                strscript = "<script langauage=JavaScript>"
                strscript += "window.open('ShareholderStatement.aspx?shareholder=" & txtshareholder.Text & "');"
                strscript += "</script>"
                ClientScript.RegisterStartupScript(Me.GetType(), "newwin", strscript)

            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub lstNames_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstNames.SelectedIndexChanged
        Try
            getNamelike()
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
End Class
