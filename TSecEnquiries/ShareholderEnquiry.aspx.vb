Partial Class TSecEnquiries_ShareholderEnquiry
    Inherits System.Web.UI.Page
    Dim cn As SqlConnection
    Dim cmd As SqlCommand
    Dim adp As New SqlDataAdapter
    Dim cnstr As String
    Dim dmbOb As New BindCombo
    Dim bool1 As Boolean = False

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Page.MaintainScrollPositionOnPostBack = True
        cmbCompany.Focus()
        Dim dsCmbComp As New DataSet
        Try
            cnstr = (System.Configuration.ConfigurationManager.AppSettings("connpath"))
            cn = New SqlConnection(cnstr)
            If (Not IsPostBack) Then
                dmbOb.BindCombo("para_company", "company", cmbCompany)

            End If
            lblShareholder.Text = ""
            lblShares.Text = ""
            Label6.Visible = False
            Label7.Visible = False
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub msgbox(ByVal strMessage As String)

        'finishes server processing, returns to client.
        Dim strScript As String = "<script language=JavaScript>"
        strScript += "window.alert(""" & strMessage & """);"
        strScript += "</script>"
        Dim lbl As New System.Web.UI.WebControls.Label
        lbl.Text = strScript
        Page.Controls.Add(lbl)

    End Sub
    Public Sub BindGrid()
        Dim dsGrid, dsShares As New DataSet
        Try
            dsGrid.Clear()
            If (ViewState("bool1") = False) Then
                msgbox("Please Select Record From List")
                ViewState("bool1") = False
                Exit Sub
            End If
            If lstName.Items.Count > 0 Then
                If (lstName.SelectedItem.Text <> "" And cmbCompany.Text <> "") Then
                    'If (cmbShareHolderNo.Text <> "" And cmbCompany.Text <> "") Then
                    Dim str As String
                    If lstName.SelectedItem.Text.Contains("'") Then
                        str = lstName.SelectedItem.Text.Replace("'", "''")
                    Else
                        str = lstName.SelectedItem.Text
                    End If

                    Dim dscertin As New DataSet 'for collecting the certificates
                    Dim i As Integer
                    Dim strcertinbatch, strcertnotin As String

                    strcertinbatch = ""
                    strcertnotin = ""

                    cmd = New SqlCommand("select cert,shares from mast,names where surname +' '+ forenames+' '+convert(varchar(50),names.shareholder)='" & str & "' and company = '" & cmbCompany.Text & "' and mast.shareholder=names.shareholder and names.compny='" & cmbCompany.Text & "'", cn)
                    adp = New SqlDataAdapter(cmd)
                    adp.Fill(dscertin, "mast")

                    For i = 0 To dscertin.Tables(0).Rows.Count - 1
                        Dim dscertinBaTCHVARI As New DataSet
                        cmd = New SqlCommand("select certno from batchcertvari where company='" & cmbCompany.Text & "' and certno = " & dscertin.Tables(0).Rows(i).Item(0).ToString(), cn)
                        adp = New SqlDataAdapter(cmd)
                        adp.Fill(dscertinBaTCHVARI, "batchcertvari")


                        If (dscertinBaTCHVARI.Tables(0).Rows.Count > 0 And dscertin.Tables(0).Rows(i).Item(1).ToString <> "0") Then
                            strcertinbatch = strcertinbatch + dscertin.Tables(0).Rows(i).Item(0).ToString() + ","
                        Else
                            strcertnotin = strcertnotin + dscertin.Tables(0).Rows(i).Item(0).ToString() + ","
                        End If

                    Next



                    If (strcertinbatch <> "") Then
                        cmd = New SqlCommand("select mast.company,mast.shareholder,cert,date_created,shares,names.idrno as IDnumber,AccStatus = case locked when 1 then 'Blocked' else ' ',mast.lockreason as LockReason end from mast,names where surname +' '+ forenames+' '+convert(varchar(50),names.shareholder)='" & str & "' and company = '" & cmbCompany.Text & "' and mast.shareholder=names.shareholder and names.compny='" & cmbCompany.Text & "' and mast.cert in (" & strcertinbatch.Substring(0, strcertinbatch.Length - 1) & ")", cn)
                        adp = New SqlDataAdapter(cmd)
                        adp.Fill(dsGrid, "mast")
                    End If

                    If (strcertnotin <> "") Then
                        If (strcertinbatch <> "") Then
                            cmd = New SqlCommand("select mast.company,mast.shareholder,cert,date_created,shares,names.idrno as IDnumber,AccStatus = case locked when 1 then 'Blocked' else ' ' end,mast.lockreason as LockReason  from mast,names where surname +' '+ forenames+' '+convert(varchar(50),names.shareholder)='" & str & "' and company = '" & cmbCompany.Text & "' and mast.shareholder=names.shareholder and names.compny='" & cmbCompany.Text & "' and mast.cert in (" & strcertnotin.Substring(0, strcertnotin.Length - 1) & ")", cn)
                            adp = New SqlDataAdapter(cmd)
                            adp.Fill(dsGrid, "mast")
                        Else
                            cmd = New SqlCommand("select mast.company,mast.shareholder,cert,date_created,shares,names.idrno as IDnumber,AccStatus = case locked when 1 then 'Blocked' else ' ' end,mast.lockreason as LockReason  from mast,names where surname +' '+ forenames+' '+convert(varchar(50),names.shareholder)='" & str & "' and company = '" & cmbCompany.Text & "' and mast.shareholder=names.shareholder and names.compny='" & cmbCompany.Text & "' and mast.cert in (" & strcertnotin.Substring(0, strcertnotin.Length - 1) & ")", cn)
                            adp = New SqlDataAdapter(cmd)
                            adp.Fill(dsGrid, "mast")
                        End If
                    End If

                    cmd = New SqlCommand("select mast.company,mast.shareholder,sum(shares) as Tshares from mast,names where surname +' '+ forenames+' '+convert(varchar(50),names.shareholder)='" & str & "' and company = '" & cmbCompany.Text & "' and mast.shareholder=names.shareholder and names.compny='" & cmbCompany.Text & "' group by mast.company,mast.shareholder", cn)
                    adp = New SqlDataAdapter(cmd)
                    adp.Fill(dsShares, "mast")

                    If (dsShares.Tables(0).Rows.Count > 0) Then
                        Label6.Visible = True
                        Label7.Visible = True
                        lblShareholder.Text = CInt(dsShares.Tables(0).Rows(0).Item("Shareholder"))
                        lblShares.Text = CInt(dsShares.Tables(0).Rows(0).Item("TShares"))
                    Else
                        lblShareholder.Text = ""
                        lblShares.Text = ""
                        Label6.Visible = False
                        Label7.Visible = False
                    End If
                    grdShareHolderEnquiry.DataSource = dsGrid
                    grdShareHolderEnquiry.DataBind()
                Else
                    msgbox("Name Is Not Selected")
                    grdShareHolderEnquiry.DataSource = Nothing
                    grdShareHolderEnquiry.DataBind()
                End If

            Else
                msgbox("Name Is Not Selected")
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub


    Public Sub BindShareHolderCombo()
        Dim dsComShareHold As New DataSet
        Try
            ' If (cmbCompany.Text <> "" And cmbSurName.Text <> "") Then

            dsComShareHold.Clear()
            Dim str As String
            If txtShort.Text.Contains("'") Then
                str = txtShort.Text.Replace("'", "''")
            Else
                str = txtShort.Text
            End If
            cmd = New SqlCommand("select distinct surname +' '+ forenames+' '+convert(varchar(50),names.shareholder) as namess  from names,mast where  surname like '" & str & "%' and mast.company='" & cmbCompany.Text & "' and mast.shareholder=names.shareholder and names.compny='" & cmbCompany.Text & "'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(dsComShareHold, "names")
            ' If (dsComShareHold.Tables("names").Rows.Count > 0) Then
            lstName.DataSource = dsComShareHold.Tables("names")
            lstName.DataValueField = "namess"
            lstName.DataBind()
            'End If
            ' End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub



    Protected Sub grdShareHolderEnquiry_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles grdShareHolderEnquiry.PageIndexChanging
        Try
            grdShareHolderEnquiry.PageIndex = e.NewPageIndex
            BindGrid()
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        BindGrid()
    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        ViewState("bool1") = False
        If (txtShort.Text <> "") Then
            BindShareHolderCombo()
        Else
            msgbox("No surname entered")
        End If

    End Sub

    Protected Sub lstName_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstName.SelectedIndexChanged
        ViewState("bool1") = True
    End Sub

    Protected Sub btnHolder_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnHolder.Click
        Try
            grdShareHolderEnquiry.DataSource = Nothing
            grdShareHolderEnquiry.DataBind()
        Catch ex As Exception
            msgbox(ex.Message)
        End Try

        If (txtShareholder.Text <> "") Then
            BindComboShareholder()
        Else
            msgbox("No shareholder no entered")
        End If
        lblShareholder.Text = ""
        lblShares.Text = ""
        Label6.Visible = False
        Label7.Visible = False
    End Sub
    Public Sub BindComboShareholder()
        Dim dsShort As New DataSet
        Try
            cmd = New SqlCommand("select distinct surname +' '+ forenames+' '+convert(varchar(50),names.shareholder) as namess from names where  shareholder =" & txtShareholder.Text & " and compny='" & cmbCompany.Text & "'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(dsShort, "names")
            lstName.DataSource = dsShort.Tables("names")
            lstName.DataValueField = "namess"
            lstName.DataBind()
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
End Class
