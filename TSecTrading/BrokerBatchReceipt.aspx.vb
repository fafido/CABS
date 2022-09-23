Imports System.Data
Imports System.Data.SqlClient
Partial Class TSecTrading_BrokerBatchReceipt
    Inherits System.Web.UI.Page
    Dim cn As SqlConnection
    Dim cmd As SqlCommand
    Dim adp As New SqlDataAdapter
    Dim cnstr As String = (System.Configuration.ConfigurationManager.AppSettings("connpath"))
    Dim dmbOb As New BindCombo
    Dim bmflag As Boolean
    Dim hold As Integer
    Dim totalshares As Double
    Dim bClearAll As Boolean

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Page.MaintainScrollPositionOnPostBack = True
        Dim dsCmbComp As New DataSet
        Dim bBatchAll As Integer
        Session("bClearAll") = False
        Calendar1.Visible = False
        Try
            cnstr = (System.Configuration.ConfigurationManager.AppSettings("connpath"))
            cn = New SqlConnection(cnstr)
            'John 22 May 2010
            If cn.State = 0 Then cn.Open()
            cmd = New SqlCommand("select BatchPermission from UserManageMent Where UserId='" & Session("Username") & "'", cn)
            bBatchAll = cmd.ExecuteScalar()

            'adp.SelectCommand = cmd
            'adp.Fill(dsCmbComp, "batch_header")
            'If dsCmbComp.Tables(0).Rows.Count > 0 Then
            '    cn.Open()
            '    cmd = New SqlCommand("select max(batch_ref) from batch_header", cn)
            '    Dim batchref As Integer = CInt(cmd.ExecuteScalar())
            '    txtBatchRef.Text = batchref + 1
            'Else
            '    txtBatchRef.Text = 1
            'End If

            If (Not IsPostBack) Then
                dmbOb.BindCombo("para_company", "company", cmbCOmpany)
                If bBatchAll = 1 Then 'John 22 May 2010
                    dmbOb.BindCombo("batch_types", "type", cmbBatchType)
                Else
                    cmbBatchType.Items.Clear()
                    cmbBatchType.Items.Add("Xfer")
                End If
                dmbOb.BindCombinedValCombo("para_broker", "fnam", "code", cmbBroker1)
                dmbOb.BindCombo("para_company", "company", drSearchCompany)
                txtCertNo.Enabled = False
                btnAddCert.Enabled = False
                cmbCOmpany.Enabled = True
                ' SelectPricePerShare()
            End If
            'txtBatchRef.Focus()
            cn.Close()
        Catch ex As Exception
            cn.Close()
            msgbox(ex.Message)

        End Try
    End Sub
    Public Function autocodegenerate() As Integer
        Dim dsCmbComp As New DataSet

        cn = New SqlConnection(cnstr)
        cmd = New SqlCommand("select * from batch_header", cn)
        adp.SelectCommand = cmd
        adp.Fill(dsCmbComp, "batch_header")
        If dsCmbComp.Tables(0).Rows.Count > 0 Then
            cn.Open()
            cmd = New SqlCommand("select max(batch_ref) from batch_header", cn)
            Dim batchref As Integer = CInt(cmd.ExecuteScalar())
            cn.Close()
            txtBatchRef.Text = batchref + 1
        Else
            txtBatchRef.Text = 1
        End If
        Return CInt(txtBatchRef.Text)
        'txtBatchRef.Focus()

    End Function
    Public Sub msgbox(ByVal strMessage As String)
        Dim strScript As String = "<script language=JavaScript>"
        strScript += "window.alert(""" & strMessage & """);"
        strScript += "</script>"
        Dim lbl As New System.Web.UI.WebControls.Label
        lbl.Text = strScript
        Page.Controls.Add(lbl)
    End Sub
    Public Sub ClearAll()
        Session("bClearAll") = True
        'txtBatchRef.Text = ""
        txtBatchType.Text = ""
        'txtBatchValue.Text = ""
        'txtBroker.Text = ""
        txtBrokerRef.Text = ""
        txtLodger.Text = ""
        txtShares.Text = ""
        txtdate.Text = ""
        cmbBatchType.Text = "-Select-"
        txtTransferno.Text = ""
        txtBatchValue.Text = 0
        chkAdvicereq.Checked = False
        chkHold.Checked = False
        txtPricePerShare.Text = 0
        txtBatchRef.Focus()
        Session("bClearAll") = False
    End Sub
    Protected Sub cmbBatchType_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbBatchType.SelectedIndexChanged
        Dim dsFnam As New DataSet
        'If (cmbBatchType.SelectedValue = "XFER" Or cmbBatchType.SelectedValue = "CDS") Then
        '    MaxXferNO1()
        'Else
        '    txtTransferno.Text = 0
        'End If
        Try
            If (cmbBatchType.Text <> "") Then
                cmd = New SqlCommand("select fnam from batch_types where type='" & cmbBatchType.SelectedValue & "'", cn)
                adp = New SqlDataAdapter(cmd)
                adp.Fill(dsFnam, "batch_types")
                If (dsFnam.Tables(0).Rows.Count > 0) Then
                    txtBatchType.Text = dsFnam.Tables(0).Rows(0).Item(0).ToString()
                End If
            Else
                msgbox("Please Select The batch Type")
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try

    End Sub
    'Public Sub MaxXferNO()
    '    Try
    '        Dim dss As New DataSet
    '        cmd = New SqlCommand("select * from batch_header", cn)
    '        adp = New SqlDataAdapter(cmd)
    '        adp.Fill(dss, "batch_header")
    '        If (dss.Tables(0).Rows.Count > 0) Then
    '            cn.Open()
    '            cmd = New SqlCommand("select max(xfer) from batch_header", cn)
    '            Dim batcmax As Integer = cmd.ExecuteScalar()
    '            txtTransferno.Text = batcmax + 1
    '            cn.Close()
    '        Else
    '            txtTransferno.Text = 1
    '        End If

    '    Catch ex As Exception
    '        cn.Close()
    '        msgbox(ex.Message)

    '    End Try
    'End Sub
    Public Function MaxXferNO1() As Integer
        Try
            Dim dss As New DataSet
            Dim batchds As New DataSet
            Dim xferno As Integer
            If cmbCOmpany.Text <> "" Then
                cmd = New SqlCommand("select * from para_company where company='" & cmbCOmpany.Text & "'", cn)
                adp = New SqlDataAdapter(cmd)
                adp.Fill(dss, "para_company")
                cmd = New SqlCommand("select * from batch_header where company='" & cmbCOmpany.Text & "' and xfer > 0", cn)
                adp = New SqlDataAdapter(cmd)
                adp.Fill(batchds, "batch_header")
                If (batchds.Tables(0).Rows.Count <= 0) Then
                    If (dss.Tables(0).Rows.Count > 0) Then
                        xferno = CInt(dss.Tables(0).Rows(0).Item("last_xfer")) + 1
                    Else
                        xferno = 1
                    End If
                Else
                    cn.Open()
                    cmd = New SqlCommand("select max(xfer) from batch_header", cn)
                    Dim batcmax As Integer = cmd.ExecuteScalar()
                    xferno = batcmax + 1
                    cn.Close()
                End If
            Else

            End If
            Return xferno
        Catch ex As Exception
            cn.Close()
            msgbox(ex.Message)

        End Try
    End Function
    'Protected Sub cmbBroker1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbBroker1.SelectedIndexChanged
    '    Dim dsBindBroker As New DataSet
    '    Try
    '        If (cmbBroker1.Text <> "") Then
    '            cmd = New SqlCommand("select fnam from para_broker where code='" & cmbBroker1.SelectedItem.Text & "'", cn)
    '            adp = New SqlDataAdapter(cmd)
    '            adp.Fill(dsBindBroker, "para_broker")
    '            If (dsBindBroker.Tables(0).Rows.Count > 0) Then
    '                'txtBroker.Text = dsBindBroker.Tables(0).Rows(0).Item(0).ToString()
    '            End If
    '        End If

    '    Catch ex As Exception
    '        msgbox(ex.Message)
    '    End Try
    'End Sub
    Protected Sub Button1_Click1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            'If Len(Trim(cmbCOmpany.Text)) > 0 Then
            '    szCurCompany = cmbCOmpany.Text
            'End If
            'If Len(Trim(txtdate.Text)) > 0 Then
            '    szCurDate = txtdate.Text
            'End If
            Dim szDate As String = Session("CurDate")
            Dim szComp As String = Session("CurComp")
            If (szDate <> "" And szComp <> "") Then
                'txtBatchRef.Text = "111"
                Response.Redirect("batchrefprint.aspx?comp=" & szComp & "&szDate=" & CDate(szDate))
            Else
                msgbox("Please Select Date and Company Name")
                Exit Sub
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try

    End Sub
    Protected Sub btnAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        'If Console.ReadKey = Keys.Enter Then
        '    Exit Sub
        'End If

        Session("bClearAll") = False
        Try


            'If txtBatchValue.Text = "" And txtPricePerShare.Text = "" Then

            '     msgbox("Enter any One field from batch value or price per share")
            '    txtBatchValue.Focus()
            '    Exit Sub

            'End If
            'If txtBatchValue.Text <> "" And txtPricePerShare.Text <> "" Then

            '     msgbox("Enter any One field from batch value or price per share")
            '    txtBatchValue.Focus()
            '    Exit Sub

            'End If
            Page.Validate()
            If Not Page.IsValid Then
                Exit Sub
            End If
            If (txtdate.Text = "") Then
                msgbox("Select Date")
                Exit Sub

            End If
            If Not IsNumeric(txtShares.Text) Then
                msgbox("only numbers are allowed")
                txtShares.Text = ""
                txtShares.Focus()
                Exit Sub
            End If

            If Not IsNumeric(txtShares.Text) Then
                msgbox("only numbers are allowed")
                txtShares.Text = ""
                txtShares.Focus()
                Exit Sub
            End If

            If (chkHold.Checked) Then
                hold = 1
            Else
                hold = 0
            End If
            If txtBatchValue.Text = "" Then
                txtBatchValue.Text = CDbl(txtPricePerShare.Text) * CDbl(txtShares.Text)

            End If
            If txtPricePerShare.Text = "" Then
                txtPricePerShare.Text = CDbl(txtBatchValue.Text) / CDbl(txtShares.Text)

            End If

            If (txtTransferno.Text = "") Then
                txtTransferno.Text = 0
            End If

            'Chech For Batchref's Certificates shares
            'If cmbBatchType.Text = "CD" Or cmbBatchType.Text = "CDS" Or cmbBatchType.Text = "INDEM" Or cmbBatchType.Text = "XFER" Then
            '    If (CDbl(txtShares.Text) <> CDbl(ViewState("shares"))) Then
            '        msgbox("Shares are not same as the shares in batchref's Certificates")
            '        ViewState("shares") = 0
            '        cmd = New SqlCommand("delete from batchcertno where batchref=" & txtBatchRef.Text & " and company='" & cmbCOmpany.Text & "'", cn)
            '        cn.Open()
            '        cmd.ExecuteNonQuery()
            '        cn.Close()
            '        Exit Sub
            '    End If
            'End If
            Dim xferno As Integer
            Dim batchref As Integer = autocodegenerate()
            'John 2 Sep 2010
            If (UCase(cmbBatchType.SelectedValue) = "XFER" Or cmbBatchType.SelectedValue = "CDS" Or cmbBatchType.SelectedValue = "WITHDRAW") Then
                xferno = MaxXferNO1()
                txtTransferno.Text = xferno
            Else
                txtTransferno.Text = 0
                xferno = 0
            End If
            Dim bmflag As Boolean = True
            txtBatchRef.Text = batchref

            'If cmbBatchType.Text = "CD" Or cmbBatchType.Text = "CDS" Or cmbBatchType.Text = "INDEM" Or cmbBatchType.Text = "XFER" Then
            '    If (CDbl(txtShares.Text) <> CDbl(ViewState("shares"))) Then
            '        msgbox("Shares are not same as the shares in batchref's Certificates")
            '        ViewState("shares") = 0
            '        cmd = New SqlCommand("delete from batchcertno where batchref=" & batchref & " and company='" & cmbCOmpany.Text & "'", cn)
            '        cn.Open()
            '        cmd.ExecuteNonQuery()
            '        cn.Close()
            '        Exit Sub
            '    End If
            'End If

            cmd = New SqlCommand("insert into batch_header(batch_ref,company,date,xfer,type,shares,shareprice,broker,brokerref,lodger,created_on,created_by,hold) values(" & CDbl(txtBatchRef.Text) & ",'" & cmbCOmpany.Text & "','" & txtdate.Text & "'," & CInt(txtTransferno.Text) & ",'" & cmbBatchType.Text & "'," & CInt(txtShares.Text) & "," & CInt(txtPricePerShare.Text) & ",'" & cmbBroker1.SelectedItem.Value & "','" & txtBrokerRef.Text & "','" & txtLodger.Text & "','" & txtdate.Text & "','" & Session("UserId") & "'," & CInt(hold) & " )", cn)
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()

            'cmd = New SqlCommand("select max(batch_ref) from batch_header", cn)
            'cn.Open()
            'Dim batchref As Integer = cmd.ExecuteScalar()
            'cn.Close()

            'cmd = New SqlCommand("update para_company set last_xfer=" &  & " where company='" & cmbCOmpany.Text & "'", cn)
            'cn.Open()
            'cmd.ExecuteNonQuery()
            'cn.Close()

            ' Response.Redirect("")
            'adp = New SqlDataAdapter(cmd)
            msgbox("Added BatchRef:- " & batchref & " XFERNO:- " & xferno)
            If UCase(cmbBatchType.Text) = "CD" Or UCase(cmbBatchType.Text) = "CDS" Or UCase(cmbBatchType.Text) = "INDEM" Or UCase(cmbBatchType.Text) = "XFER" Or UCase(cmbBatchType.Text) = "WITHDRAW" Then
                msgbox("ADD CERTIFICATES FOR VERIFICATION")
                txtCertNo.Enabled = True
                btnAddCert.Enabled = True
                cmbCOmpany.Enabled = False
            Else
                ClearAll()
            End If



            'txtBatchRef.Text = batchref + 1

            ViewState("shares") = 0

        Catch ex As Exception
            cn.Close()
            msgbox(ex.Message)
        End Try
    End Sub
    'Public Sub SelectPricePerShare()
    '    Try
    '        Dim dsSelPri As New DataSet
    '        cmd = New SqlCommand("select PricePerShare from PortFolio where company='" & cmbCOmpany.Text & "' and dateTOday ='" & Date.Now().Date & "'", cn)
    '        adp = New SqlDataAdapter(cmd)
    '        adp.Fill(dsSelPri, "PortFolio")
    '        If dsSelPri.Tables(0).Rows.Count > 0 Then
    '            txtPricePerShare.Text = CDbl(dsSelPri.Tables(0).Rows(0).Item(0).ToString())
    '        Else
    '             msgbox("The Price Of Today Is Not Entered")
    '            Exit Sub
    '        End If
    '    Catch ex As Exception
    '         msgbox(ex.Message)
    '    End Try
    'End Sub
    Protected Sub cmbCOmpany_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbCOmpany.SelectedIndexChanged
        'SelectPricePerShare()
        If Session("bClearAll") = True Then Exit Sub
        Session("CurComp") = cmbCOmpany.Text
    End Sub

    Protected Sub btnValidate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnValidate.Click
        Try
            Dim batch_ref As String
            batch_ref = CDbl(txtBatchRef.Text)
            Dim str As String
            Dim ds1 As New DataSet
            ds1.Clear()
            str = "Select batch_ref from document where batch_ref=" & batch_ref & " and reason='printrecipt' AND  datetoday='" & Date.Now().Date() & "'"
            cmd = New SqlCommand(str, cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds1, "document")



            If ds1.Tables(0).Rows.Count <= 0 Then
                msgbox("Doucment is not scanned.Please press Scan button to Scan.")
                Exit Sub
            Else
                msgbox("Document is scanned succesfully")
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.Click
        Response.Redirect("~/Document.aspx")
    End Sub

    Protected Sub btnAddCert_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAddCert.Click
        Try
            Dim dssharescert, dscertvari As New DataSet
            Dim str, str1 As String
            If (txtCertNo.Text <> "" And cmbCOmpany.Text <> "") Then
                If dmbOb.CheckCert(CDbl(txtCertNo.Text), cmbCOmpany.Text) = False Then
                    msgbox("Certificate Processed")
                    Exit Sub
                End If

                'If dmbOb.checkDBLCert(CDbl(txtCertNo.Text), cmbCOmpany.Text, "batchcertvari", txtBatchRef.Text) = True Then
                '    msgbox("Certificate already Entered")
                '    Exit Sub
                'End If
                Dim dscert As New DataSet

                cmd = New SqlCommand("select certno from batchcertno where batchref=" & txtBatchRef.Text & " and company='" & cmbCOmpany.Text & "' and certno=" & txtCertNo.Text, cn)
                adp = New SqlDataAdapter(cmd)
                adp.Fill(dscert, "batchcertno")
                If dscert.Tables(0).Rows.Count > 0 Then
                    msgbox("Certificate already Entered")
                    Exit Sub
                End If
                If cmbBatchType.Text = "WITHDRAW" Then
                    str = "Select shares from mast where cert=" & txtCertNo.Text & " and company = '" & cmbCOmpany.Text & "' and locked<>1 and shares>0 and shareholder=(select cds_Ac_no from para_company where company='" & cmbCOmpany.Text & "')"
                    cmd = New SqlCommand(str, cn)
                    adp = New SqlDataAdapter(cmd)
                    adp.Fill(dssharescert, "mast")
                Else
                    str = "Select shares from mast where cert=" & txtCertNo.Text & " and company = '" & cmbCOmpany.Text & "' and shares>0 and locked<>1"
                    cmd = New SqlCommand(str, cn)
                    adp = New SqlDataAdapter(cmd)
                    adp.Fill(dssharescert, "mast")
                End If




                If (dssharescert.Tables(0).Rows.Count > 0) Then
                    ViewState("shares") = ViewState("shares") + CDbl(dssharescert.Tables(0).Rows(0).Item(0).ToString())
                    If ViewState("shares") > txtShares.Text Then
                        msgbox("OUT OF BALANCE")
                        ViewState("shares") = ViewState("shares") - CDbl(dssharescert.Tables(0).Rows(0).Item(0).ToString())
                        txtCertNo.Text = ""
                        'cmd = New SqlCommand("delete from batchcertno where batchref=" & txtBatchRef.Text & " and company='" & cmbCOmpany.Text & "' and vari=0", cn)
                        'cn.Open()
                        'cmd.ExecuteNonQuery()
                        'cn.Close()

                        Exit Sub

                    End If
                    'CDbl(dssharescert.Tables(0).Rows(0).Item(0).ToString())
                    cmd = New SqlCommand("insert into batchcertno(certno,batchref,company,shares) values(" & txtCertNo.Text & "," & txtBatchRef.Text & ",'" & cmbCOmpany.Text & "'," & CDbl(dssharescert.Tables(0).Rows(0).Item(0).ToString()) & ")", cn)
                    cn.Open()
                    cmd.ExecuteNonQuery()
                    cn.Close()
                    dscertvari.Clear()

                    str1 = "Select batchref as BATCHREFNO,certno as CERT,company as COMPANY from batchcertno where company = '" & cmbCOmpany.Text & "' and batchref=" & txtBatchRef.Text
                    cmd = New SqlCommand(str1, cn)
                    adp = New SqlDataAdapter(cmd)
                    adp.Fill(dscertvari, "batchcertno")
                    grdAddedCertificate.DataSource = dscertvari.Tables(0)
                    grdAddedCertificate.DataBind()

                    If ViewState("shares") = txtShares.Text Then
                        msgbox("BALANCED")
                        ViewState("totalshares") = CDbl(txtShares.Text)
                        ClearAll()
                        txtCertNo.Enabled = False
                        btnAddCert.Enabled = False
                        cmbCOmpany.Enabled = True

                    End If
                    'If bmflag = False Then
                    '    cmd = New SqlCommand("insert into batch_header(batch_ref,company,date,xfer,type,shares,shareprice,broker,brokerref,lodger,created_on,created_by,hold) values(" & CDbl(txtBatchRef.Text) & ",'" & cmbCOmpany.Text & "','" & txtdate.Text & "'," & CInt(txtTransferno.Text) & ",'" & cmbBatchType.Text & "'," & CInt(txtShares.Text) & "," & CInt(txtPricePerShare.Text) & ",'" & cmbBroker.Text & "','" & txtBrokerRef.Text & "','" & txtLodger.Text & "','" & txtdate.Text & "','" & Session("UserId") & "'," & CInt(hold) & " )", cn)
                    '    cn.Open()
                    '    cmd.ExecuteNonQuery()
                    '    cn.Close()
                    'End If
                Else
                    msgbox("Enter valid Cert Number")
                    Exit Sub
                End If
                txtCertNo.Text = ""
                txtCertNo.Focus()
            Else
                msgbox("Enter Valid Certificate number and company")
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub Button3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button3.Click
        Calendar1.Visible = True
    End Sub
    Protected Sub Calendar1_VisibleMonthChanged(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.MonthChangedEventArgs) Handles Calendar1.VisibleMonthChanged
        Calendar1.Visible = True
    End Sub
    Protected Sub Calendar1_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Calendar1.SelectionChanged
        Try
            txtdate.Text = Calendar1.SelectedDate
            Calendar1.SelectedDate = Nothing
            Calendar1.Visible = False
            If Session("bClearAll") = True Then Exit Sub
            Session("CurDate") = txtdate.Text
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub txtBatchValue_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtBatchValue.TextChanged

    End Sub
    Protected Sub btnUpdate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUpdate.Click

        Try
            Dim hold As Integer
            If (chkHold.Checked) Then
                hold = 1
            Else
                hold = 0
            End If
            If txtSearchbatchref.Text <> "" Then
                cmd = New SqlCommand("update batch_header Set company='" & cmbCOmpany.Text & "',[date]='" & txtdate.Text & "',type='" & cmbBatchType.Text & "',xfer=" & txtTransferno.Text & ",shares=" & txtShares.Text & ",shareprice=" & txtPricePerShare.Text & ",broker='" & cmbBroker1.SelectedItem.Value & "',brokerref='" & txtBrokerRef.Text & "',lodger='" & txtLodger.Text & "',hold=" & hold & "  where batch_ref=" & txtSearchbatchref.Text, cn)
                cn.Open()
                cmd.ExecuteNonQuery()
                cn.Close()
                msgbox("Updated")
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try

    End Sub
    Public Function selectRecord() As Boolean
        Dim dssearch, dsbroker As New DataSet
        Try

            If txtSearchbatchref.Text <> "" And drSearchCompany.Text <> "" Then
                cmd = New SqlCommand("select * from batch_header where batch_ref='" & txtSearchbatchref.Text & "' and company='" & drSearchCompany.Text & "'", cn)
                adp = New SqlDataAdapter(cmd)
                adp.Fill(dssearch, "batch_header")
                If dssearch.Tables(0).Rows.Count > 0 Then
                    cmbCOmpany.Text = dssearch.Tables(0).Rows(0).Item("company").ToString
                    txtdate.Text = dssearch.Tables(0).Rows(0).Item("date").ToString
                    cmbBatchType.Text = dssearch.Tables(0).Rows(0).Item("type").ToString

                    txtTransferno.Text = dssearch.Tables(0).Rows(0).Item("xfer").ToString
                    txtShares.Text = dssearch.Tables(0).Rows(0).Item("shares").ToString
                    txtPricePerShare.Text = dssearch.Tables(0).Rows(0).Item("shareprice").ToString
                    cmbbroker.Text = dssearch.Tables(0).Rows(0).Item("broker").ToString
                    cmd = New SqlCommand("select * from para_broker where code='" & dssearch.Tables(0).Rows(0).Item("broker").ToString & "'", cn)
                    adp = New SqlDataAdapter(cmd)
                    adp.Fill(dsbroker, "batch_header")
                    cmbBroker1.Items(0).Text = dsbroker.Tables(0).Rows(0).Item("fnam") & "    " & dsbroker.Tables(0).Rows(0).Item("code")
                    ' cmbBroker1.Text.ad\(Str)

                    txtBrokerRef.Text = dssearch.Tables(0).Rows(0).Item("brokerref").ToString
                    txtLodger.Text = dssearch.Tables(0).Rows(0).Item("lodger").ToString
                    chkHold.Checked = CBool(dssearch.Tables(0).Rows(0).Item("hold"))
                    txtBatchRef.Text = dssearch.Tables(0).Rows(0).Item("batch_ref").ToString
                    Return True
                Else
                    msgbox("BATCHREF INVALID")
                    msgbox("Enter Batch Ref OR Company To Search")
                    Return False
                End If

            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Function

    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        Dim str1, str As String
        Dim dscertvari, dssharescert As New DataSet
        Dim i As Integer
        If selectRecord() = True Then
            ViewState("shares") = 0
            str1 = "Select batchref as BATCHREFNO,certno as CERT,company as COMPANY from batchcertno where company = '" & cmbCOmpany.Text & "' and batchref=" & txtBatchRef.Text
            cmd = New SqlCommand(str1, cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(dscertvari, "batchcertno")
            grdAddedCertificate.DataSource = dscertvari.Tables(0)
            grdAddedCertificate.DataBind()

            For i = 0 To dscertvari.Tables(0).Rows.Count - 1
                str = "Select shares from mast where cert=" & dscertvari.Tables(0).Rows(i).Item("cert") & " and company = '" & cmbCOmpany.Text & "' and shares>0"
                cmd = New SqlCommand(str, cn)
                adp = New SqlDataAdapter(cmd)
                adp.Fill(dssharescert, "mast")
                If dssharescert.Tables(0).Rows.Count > 0 Then
                    ViewState("shares") = ViewState("shares") + CDbl(dssharescert.Tables(0).Rows(0).Item("shares"))
                End If
            Next
            txtCertNo.Enabled = True
            btnAddCert.Enabled = True
        End If
    End Sub

    Public Sub bindcertUpdate()
        Dim str As String
        Dim dssharescert As New DataSet
        Dim str1 As String
        Dim dscertvari As New DataSet
        Dim i As Integer
        ViewState("shares") = 0
        str1 = "Select batchref as BATCHREFNO,certno as CERT,company as COMPANY from batchcertno where company = '" & cmbCOmpany.Text & "' and batchref=" & txtBatchRef.Text
        cmd = New SqlCommand(str1, cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(dscertvari, "batchcertno")
        grdAddedCertificate.DataSource = dscertvari.Tables(0)
        grdAddedCertificate.DataBind()
        ViewState("totshares") = txtShares.Text
        'For i = 0 To dscertvari.Tables(0).Rows.Count - 1
        '    str = "Select shares from mast where cert=" & dscertvari.Tables(0).Rows(i).item("cert") & " and company = '" & cmbCOmpany.Text & "' and shares>0"
        '    cmd = New SqlCommand(str, cn)
        '    adp = New SqlDataAdapter(cmd)
        '    adp.Fill(dssharescert, "mast")
        '    If dssharescert.Tables(0).Rows.Count > 0 Then
        '        ViewState("shares") = ViewState("shares") + CDbl(dssharescert.Tables(0).Rows(0).Item("shares"))
        '    End If
        'Next
        If ViewState("shares") = ViewState("totalshares") Then
            msgbox("SHARES BALANCED")
            ClearAll()
            txtCertNo.Enabled = False
            btnAddCert.Enabled = False
            cmbCOmpany.Enabled = True
            ViewState("totalshares") = 0
            ViewState("shares") = 0

        ElseIf ViewState("shares") <> ViewState("totalshares") Then
            msgbox("SHARES NOT BALANCED")
            txtCertNo.Enabled = True
            btnAddCert.Enabled = True
            cmbCOmpany.Enabled = False
            txtShares.Text = ViewState("totalshares")
        End If
    End Sub
    Protected Sub btndeletecert_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btndeletecert.Click
        Dim i, j As Integer
        Dim str, str1 As String
        Dim dssharescert, dscertvari As New DataSet
        j = grdAddedCertificate.Rows.Count
        For i = 0 To j - 1
            j = grdAddedCertificate.Rows.Count
            Dim chk As CheckBox
            chk = CType(grdAddedCertificate.Rows(i).Cells(0).FindControl("checkbox1"), CheckBox)
            If chk.Checked = True Then
                cmd = New SqlCommand("delete from batchcertno where batchref=" & grdAddedCertificate.Rows(i).Cells(1).Text & " and certno=" & grdAddedCertificate.Rows(i).Cells(2).Text & " and company='" & grdAddedCertificate.Rows(i).Cells(3).Text & "'", cn)
                cn.Open()
                cmd.ExecuteNonQuery()
                cn.Close()

                str = "Select shares from mast where cert=" & grdAddedCertificate.Rows(i).Cells(2).Text & " and company = '" & cmbCOmpany.Text & "' and shares>0"
                cmd = New SqlCommand(str, cn)
                adp = New SqlDataAdapter(cmd)
                adp.Fill(dssharescert, "mast")
                If dssharescert.Tables(0).Rows.Count > 0 Then
                    ViewState("shares") = ViewState("shares") - CDbl(dssharescert.Tables(0).Rows(0).Item("shares"))
                End If

            End If
        Next
        str1 = "Select batchref as BATCHREFNO,certno as CERT,company as COMPANY from batchcertno where company = '" & cmbCOmpany.Text & "' and batchref=" & txtBatchRef.Text
        cmd = New SqlCommand(str1, cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(dscertvari, "batchcertno")
        grdAddedCertificate.DataSource = dscertvari.Tables(0)
        grdAddedCertificate.DataBind()

        If ViewState("shares") = ViewState("totalshares") Then
            msgbox("SHARES BALANCE")
            ClearAll()
            txtCertNo.Enabled = False
            btnAddCert.Enabled = False
            cmbCOmpany.Enabled = True
            ViewState("totalshares") = 0
            ViewState("shares") = 0

        ElseIf ViewState("shares") <> ViewState("totalshares") Then
            msgbox("SHARES NOT BALANCE")

            txtCertNo.Enabled = True
            btnAddCert.Enabled = True
            cmbCOmpany.Enabled = False
            txtShares.Text = ViewState("totalshares")
        End If

    End Sub
    End Class
