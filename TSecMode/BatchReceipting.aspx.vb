Partial Class TsecMode_BatchReceipting
    Inherits System.Web.UI.Page
    Dim constr As String = (System.Configuration.ConfigurationManager.AppSettings("connpath"))
    Dim cnstr As String
    Dim cn As New SqlConnection(constr)
    Dim adp As SqlDataAdapter
    Dim cmd As SqlCommand
    Public Sub checkSessionState()
        Try

        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub GetPermissions()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select * from Capture_Permissions where user_id='" & Session("username") & "'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "Capture_Permissions")
            If (ds.Tables(0).Rows.Count > 0) Then
                If (ds.Tables(0).Rows(0).Item("Batch_header").ToString = 1) Then
                Else
                    Response.Redirect("~\mainpage.aspx")

                End If
            Else
                Response.Redirect("~\mainpage.aspx")
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Page.MaintainScrollPositionOnPostBack = True
        Dim dsCmbComp As New DataSet
        Try
            cnstr = (System.Configuration.ConfigurationManager.AppSettings("connpath"))
            cn = New SqlConnection(cnstr)
            'Calvin 22 May 2010
            If cn.State = 0 Then cn.Open()
            If (Not IsPostBack) Then
                'If Session("username") = "" Then
                '    Response.Redirect("~\loginPage.aspx")
                'End If
                txtdate.SelectedDate = Today
                GetPermissions()
                'User Audit
                Dim strClientIP As String
                strClientIP = Request.UserHostAddress()

                'cmd = New SqlCommand("insert into TblUserAudit (UserID,ActionType,ActionDate,ActionDateTime,LocationFrom,AccessMode) values ('" & Session("Username").ToString & "','Accessed batch receipting form', '" & Format(Now.Date, "M/d/yyyy") & "','" & Date.Now & "','" & strClientIP & "','" & Request.UserAgent & "')", cn)

                'If (cn.State = ConnectionState.Open) Then
                '    cn.Close()
                'End If
                'cn.Open()
                'cmd.ExecuteNonQuery()
                'cn.Close()
                'dmbOb.BindComboCompany("para_company", "company", cmbCOmpany)  ' 23 Feb 2011
                'dmbOb.BindCombinedValCombo("para_broker", "fnam", "code", cmbBroker1)
                cmbCOmpany.Enabled = True
                getBatch()
                getBatchTypes()
                Label35.Visible = False
                txtsubcert.Visible = False
                cmbBatchType.SelectedValue = "XFER"
                ' SelectPricePerShare()
            End If
            'txtBatchRef.Focus()
            cn.Close()
        Catch ex As Exception
            cn.Close()
            msgbox(ex.Message)

        End Try
    End Sub
    Public Sub getBatchTypes()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select distinct (type) from batch_types ", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "batch_types")

            If (ds.Tables(0).Rows.Count > 0) Then
                cmbBatchType.DataSource = ds.Tables(0)
                cmbBatchType.DataValueField = "type"
                cmbBatchType.DataBind()
            End If
        Catch ex As Exception
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
        getBatch()
        txtBatchType.Text = ""
        Label17.Text = ""
        txtComments.Text = ""
        txtTransfereeHolderSearch.Text = ""
        lstTransferee.Items.Clear()
        txtTransfereeBatchShares.Text = ""
        txtTransfereeSearch.Text = ""
        txtLodger.Text = ""
        chkLodger.Checked = False
        txtShares.Text = ""
        txtsubcert.Text = ""
        Label36.Text = ""
        Label36.Visible = False
        txtsubcert.Visible = False
        txtdate.Clear()
        txtCertSearch.Text = ""
        txtCd.Text = 0
        cmbBatchType.Text = "-Select-"
        txtBatchValue.Text = 0
        txtBatchRef.Focus()
        cmbbroker.Text = ""
        rdEnterNow.Checked = False
        rdPost.Checked = False
        grdAddedCertificate.DataSource = Nothing
        grdAddedCertificate.DataBind()
        grdTransshares.DataSource = Nothing
        grdTransshares.DataBind()
        btnBalance.Visible = False
        Session("bClearAll") = False
    End Sub
    Protected Sub cmbBatchType_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbBatchType.SelectedIndexChanged
        Dim dsFnam As New DataSet
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
            If (cmbBatchType.SelectedItem.Text = "SUB XFER") Then
                rdPost.Checked = True
                Label35.Visible = True
                txtsubcert.Visible = True
                If (rdPost.Checked = True) Then
                    HideControls()
                End If
            End If
            If (cmbBatchType.SelectedItem.Text <> "SUB XFER") Then
                Label35.Visible = False
                txtsubcert.Visible = False
                txtsubcert.Text = ""
                Label36.Text = ""
            End If
            If (cmbBatchType.SelectedItem.Text = "CD") Then

            End If

        Catch ex As Exception
            msgbox(ex.Message)
        End Try

    End Sub
    Protected Sub Button1_Click1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            Dim szDate As String = txtdate.Text
            Dim szComp As String = cmbCOmpany.SelectedItem.Text
            If (szDate <> "" And szComp <> "") Then
                Dim strscript As String
                strscript = "<script langauage=JavaScript>"
                Dim compnayname As String = ""
                compnayname = cmbCOmpany.SelectedItem.Text
                strscript += "window.open('batchrefprint.aspx?company=" & cmbCOmpany.SelectedItem.Text & "&batchref=" & txtBatchRef.Text & "');"
                'strscript += "window.open('batchrefprint.aspx?batchref=" & txtBatchRef.Text & "');"
                strscript += "</script>"
                ClientScript.RegisterStartupScript(Me.GetType(), "newwin", strscript)
            Else
                msgbox("Please Select Date and Company Name")
                Exit Sub
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try

    End Sub
    Public Sub PrintReport()
        Try
            Dim szDate As String = txtdate.Text
            Dim szComp As String = cmbCOmpany.SelectedItem.Text
            If (szDate <> "" And szComp <> "") Then
                Dim strscript As String
                strscript = "<script langauage=JavaScript>"
                Dim compnayname As String = ""
                compnayname = cmbCOmpany.SelectedItem.Text
                strscript += "window.open('batchrefprint.aspx?company=" & cmbCOmpany.SelectedItem.Text & "&batchref=" & txtBatchRef.Text & "');"
                'strscript += "window.open('batchrefprint.aspx?batchref=" & txtBatchRef.Text & "');"
                strscript += "</script>"
                ClientScript.RegisterStartupScript(Me.GetType(), "newwin", strscript)
            Else

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
            If (cmbBatchType.SelectedItem.Text = "SUB XFER") Then
                If (txtsubcert.Text = "" Or Label36.Text <> "Balanced") Then
                    msgbox("Enter a valid certificate")
                    txtsubcert.Focus()
                    txtsubcert.BackColor = Drawing.Color.Red
                End If
            End If

            SaveBatchDetails()
        Catch ex As Exception
            cn.Close()
            msgbox(ex.Message)
        End Try
    End Sub
    Protected Sub cmbCOmpany_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbCOmpany.SelectedIndexChanged
        'SelectPricePerShare()
        If Session("bClearAll") = True Then Exit Sub
        Session("CurComp") = cmbCOmpany.SelectedItem.Text
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
    Protected Sub btnUpdate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUpdate.Click

        Try
            If (rdEnterNow.Checked = False And rdPost.Checked = False) Then
                msgbox("Select a batching option")
                Exit Sub
            End If
            Dim Broker, BrokingType As String
            Dim BatchingOption As Integer


            If (chkLodger.Checked = True) Then
                BrokingType = "Lodger"
                Broker = txtLodger.Text
            Else
                BrokingType = "Broker"
                Broker = cmbBroker1.Text
            End If

            If (rdEnterNow.Checked = True) Then
                BatchingOption = 0
            Else
                BatchingOption = 1
            End If

            Dim xferNum As Integer
            Dim dsxf As New DataSet
            If (cmbBatchType.SelectedItem.Text = "XFER") Then
                If (txtBatchRef.Text = "2") Then
                    xferNum = "1"
                Else
                    cmd = New SqlCommand("select max (xfer) as xfer from batch_head", cn)
                    adp = New SqlDataAdapter(cmd)
                    adp.Fill(dsxf, "batch_head")

                    xferNum = CInt(dsxf.Tables(0).Rows(0).Item("xfer").ToString) + 1
                End If
            Else
                xferNum = 0
            End If

            If (cmbBatchType.SelectedItem.Text = "SUB XFER") Then
                Dim ROS As New DataSet
                cmd = New SqlCommand("select * from batched_certs where batch_ref=" & txtBatchRef.Text & "", cn)
                adp = New SqlDataAdapter(cmd)
                adp.Fill(ROS, "batched_certs")

                If (ROS.Tables(0).Rows.Count > 0) Then
                    cmd = New SqlCommand("delete from batched_certs where batch_ref=" & txtBatchRef.Text & "", cn)
                    If (cn.State = ConnectionState.Open) Then
                        cn.Close()
                    End If
                    cn.Open()
                    cmd.ExecuteNonQuery()
                    cn.Close()

                End If

                If (txtsubcert.Text <> "" And Label36.Text = "Balanced") Then
                    'Sub main certSaving
                    If (cmbBatchType.SelectedItem.Text = "SUB XFER") Then
                        cmd = New SqlCommand("update batch_head set status='B' where company='" & cmbCOmpany.SelectedItem.Text & "' and batch_ref=" & txtBatchRef.Text & "", cn)
                        If (cn.State = ConnectionState.Open) Then
                            cn.Close()
                        End If
                        cn.Open()
                        cmd.ExecuteNonQuery()
                        cn.Close()

                        Dim Rex As New DataSet
                        cmd = New SqlCommand("select * from sub_mast where cert = " & txtsubcert.Text & " and company='" & cmbCOmpany.SelectedItem.Text & "' and shares > 0 ", cn)
                        adp = New SqlDataAdapter(cmd)
                        adp.Fill(Rex, "mast")
                        If (Rex.Tables(0).Rows.Count > 0) Then
                            'msgbox("Insert into Batched_Certs (batch_ref,cert,cd,shareholder,shares,company,status,batch_date,batched_by) values (" & txtBatchRef.Text & "," & txtsubcert.Text & ",0," & Rex.Tables(0).Rows(0).Item("shareholder").ToString & "," & Rex.Tables(0).Rows(0).Item("shares").ToString & ",'" & cmbCOmpany.SelectedItem.Text & "',1,'" & txtdate.Text & "','" & Session("username") & "')")

                            cmd = New SqlCommand("Insert into Batched_Certs (batch_ref,cert,cd,shareholder,shares,company,status,batch_date,batched_by) values (" & txtBatchRef.Text & "," & txtsubcert.Text & ",0," & Rex.Tables(0).Rows(0).Item("shareholder").ToString & "," & Rex.Tables(0).Rows(0).Item("shares").ToString & ",'" & cmbCOmpany.SelectedItem.Text & "',1,'" & Format(Now.Date, "M/d/yyyy") & "','" & Session("username") & "')", cn)
                            If (cn.State = ConnectionState.Open) Then
                                cn.Close()
                            End If
                            cn.Open()
                            cmd.ExecuteNonQuery()
                            cn.Close()
                        End If
                    End If
                End If



            End If

            Dim hold As Integer
            If txtBatchRef.Text <> "" Then
                'cmd = New SqlCommand("update batch_header Set company='" & cmbCOmpany.SelectedItem.Text & "',[date]='" & txtdate.Text & "',type='" & cmbBatchType.Text & "',xfer=" & txtTransferno.Text & ",shares=" & txtShares.Text & ",shareprice=" & txtPricePerShare.Text & ",broker='" & cmbBroker1.SelectedItem.Value & "',brokerref='" & txtBrokerRef.Text & "',lodger='" & txtLodger.Text & "',hold=" & hold & "  where batch_ref=" & txtSearchbatchref.Text, cn)
                cmd = New SqlCommand("update batch_head Set company='" & cmbCOmpany.SelectedItem.Text & "',shares=" & txtShares.Text & ",batch_date='" & txtdate.SelectedDate & "',batch_type='" & cmbBatchType.SelectedItem.Text & "',batched_by='" & Session("Username") & "',batch_option=" & BatchingOption & ",broker_lodger='" & Broker & "' where batch_ref=" & txtBatchRef.Text, cn)
                cn.Open()
                cmd.ExecuteNonQuery()
                cn.Close()

                'User Audit
                Dim strClientIP As String
                strClientIP = Request.UserHostAddress()

                cmd = New SqlCommand("insert into TblUserAudit (UserID,ActionType,ActionDate,ActionDateTime,LocationFrom,AccessMode) values ('" & Session("Username").ToString & "','Updated a batch header information', '" & Now.Date & "','" & Date.Now & "','" & strClientIP & "','" & Request.UserAgent & "')", cn)

                If (cn.State = ConnectionState.Open) Then
                    cn.Close()
                End If
                cn.Open()
                cmd.ExecuteNonQuery()
                cn.Close()
                msgbox("Updated")
                btnUpdate.Visible = False
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try

    End Sub
    Protected Sub rdEnterNow_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles rdEnterNow.CheckedChanged
        Try

            'If (rdEnterNow.Checked = True) Then
            '    BatchNowShow()
            '    If (cmbBatchType.SelectedItem.Text = "ALLOT") Then
            '        If (rdEnterNow.Checked = True) Then
            '            BatchNowShow()
            '            Label33.Text = "Name"
            '            lstNamesSelect.Visible = True
            '            lstNamesSelect.Items.Clear()

            '            Label30.Visible = True
            '            Label29.Visible = True

            '            txtToBatchShares.Visible = True
            '            btnToBatchShares.Visible = True
            '        End If
            '    End If
            'Else
            '    HideControls()
            'End If

        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub BatchNowShow()
        Try
            'Label28.Visible = True
            Label33.Visible = True
            'txtNameSearch.Visible = True
            txtCertSearch.Visible = True
            txtCd.Visible = True
            'btnHolderSearch.Visible = True
            btnCertSearch.Visible = True
            'Button4.Visible = True
            'Button5.Visible = True
            'Label30.Visible = True
            'lstNamesSelect.Visible = True
            'grdAddedCertificate0.Visible = True
            'Label29.Visible = True
            'txtToBatchShares.Visible = True
            'btnToBatchShares.Visible = True
            'grdAddedCertificate.Visible = True

            If (cmbBatchType.SelectedItem.Text = "XFER") Then

                'Transfering shares

                Label32.Visible = True
                Label16.Visible = True
                txtTransfereeSearch.Visible = True
                btnTranssearch.Visible = True
                Label37.Visible = True
                txtTransfereeHolderSearch.Visible = True
                btnTranssearch0.Visible = True
                Label17.Visible = True
                lstTransferee.Visible = True
                Label18.Visible = True
                txtTransfereeBatchShares.Visible = True
                btnBatchTransshares.Visible = True
                grdTransshares.Visible = True

            ElseIf (cmbBatchType.SelectedItem.Text = "WITHDRAW") Then
                Label32.Visible = True
                Label16.Visible = True
                txtTransfereeSearch.Visible = True
                btnTranssearch.Visible = True
                Label37.Visible = True
                txtTransfereeHolderSearch.Visible = True
                btnTranssearch0.Visible = True
                Label17.Visible = True
                lstTransferee.Visible = True
                Label18.Visible = True
                txtTransfereeBatchShares.Visible = True
                btnBatchTransshares.Visible = True
                grdTransshares.Visible = True
                btnBalance.Visible = True


            Else
                Label32.Visible = False
                Label16.Visible = False
                txtTransfereeSearch.Visible = False
                btnTranssearch.Visible = False
                Label37.Visible = False
                txtTransfereeHolderSearch.Visible = False
                btnTranssearch0.Visible = False
                Label17.Visible = False
                lstTransferee.Visible = False
                Label18.Visible = False
                txtTransfereeBatchShares.Visible = False
                btnBatchTransshares.Visible = False
                grdTransshares.Visible = False
                btnBalance.Visible = False
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub HideControls()
        Try
            Label28.Visible = False
            Label33.Visible = False
            txtCertSearch.Visible = False
            txtCd.Visible = False
            txtNameSearch.Visible = False
            btnHolderSearch.Visible = False
            btnCertSearch.Visible = False
            Label30.Visible = False
            lstNamesSelect.Visible = False
            grdAddedCertificate0.Visible = False
            Label29.Visible = False
            txtToBatchShares.Visible = False
            btnToBatchShares.Visible = False
            grdAddedCertificate.Visible = False

            Label32.Visible = False
            Label16.Visible = False
            txtTransfereeSearch.Visible = False
            btnTranssearch.Visible = False
            Label37.Visible = False
            txtTransfereeHolderSearch.Visible = False
            btnTranssearch0.Visible = False
            Label17.Visible = False
            lstTransferee.Visible = False
            Label18.Visible = False
            txtTransfereeBatchShares.Visible = False
            btnBatchTransshares.Visible = False
            grdTransshares.Visible = False

        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Protected Sub rdPost_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles rdPost.CheckedChanged
        Try
            If (rdPost.Checked = True) Then
                HideControls()
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Protected Sub cmbBroker1_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cmbBroker1.SelectedIndexChanged
        Try
            If (cmbBroker1.Text <> "") Then
                cmbbroker.Text = cmbBroker1.SelectedItem.Text
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub getBatch()
        Try
            Dim dsi As New DataSet
            cmd = New SqlCommand("select * from batch_head", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(dsi, "batch_head")
            If (dsi.Tables(0).Rows.Count > 0) Then
                Dim ds As New DataSet
                cmd = New SqlCommand("select max (batch_ref)  as batch_ref from batch_head", cn)
                adp = New SqlDataAdapter(cmd)
                adp.Fill(ds, "batch_head")

                txtBatchRef.Text = CInt(ds.Tables(0).Rows(0).Item("batch_ref").ToString) + 1
            Else
                txtBatchRef.Text = CInt("1")
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub GetMaxBATCHREF()
        Try
            Dim rex As New DataSet
            Dim x As Integer = 0
            cmd = New SqlCommand("select * from batch_ref", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(rex, "batch_ref")
            If (rex.Tables(0).Rows.Count > 0) Then
                Dim ds As New DataSet
                cmd = New SqlCommand("select max(batch_ref) as batch_ref from batch_head", cn)
                adp = New SqlDataAdapter(cmd)
                adp.Fill(ds, "batch_head")
                x = ds.Tables(0).Rows(0).Item("batch_ref").ToString + 1
            Else
                x = x + 1
            End If


        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub SaveBatchDetails()
        Try
            If (rdEnterNow.Checked = False And rdPost.Checked = False) Then
                msgbox("Select a batching option")
                Exit Sub
            End If
            Dim Broker, BrokingType As String
            Dim BatchingOption As Integer


            If (chkLodger.Checked = True) Then
                BrokingType = "Lodger"
                Broker = txtLodger.Text
            Else
                BrokingType = "Broker"
                Broker = cmbbroker.Text
            End If

            If (rdEnterNow.Checked = True) Then
                BatchingOption = 0
            Else
                BatchingOption = 1
            End If

            Dim xferNum As Integer
            Dim dsxf As New DataSet
            If (cmbBatchType.SelectedItem.Text = "XFER") Then
                If (txtBatchRef.Text <= "2") Then
                    xferNum = "1"
                Else
                    cmd = New SqlCommand("select max (xfer) as xfer from batch_head", cn)
                    adp = New SqlDataAdapter(cmd)
                    adp.Fill(dsxf, "batch_head")

                    xferNum = CInt(dsxf.Tables(0).Rows(0).Item("xfer").ToString) + 1
                End If
            Else
                xferNum = 0
            End If


            cmd = New SqlCommand("insert into batch_head (Company,Shares,Batch_date,Batch_Type,Batched_By,Status,Batch_Option,Xfer,Created_On,Broker_Lodger,Comments) values ('" & cmbCOmpany.SelectedItem.Text & "'," & txtShares.Text & ",'" & Format(txtdate.SelectedDate, "M/d/yyyy") & "','" & cmbBatchType.Text & "','" & Session("Username") & "','O'," & BatchingOption & "," & xferNum & ",'" & Format(Now.Date, "M/d/yyyy") & "','" & Broker & "','" & txtComments.Text & "')", cn)
            If (cn.State = ConnectionState.Open) Then
                cn.Close()
            End If
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()


            'Sub main certSaving
            If (cmbBatchType.SelectedItem.Text = "SUB XFER") Then
                cmd = New SqlCommand("update batch_head set status='B' where company='" & cmbCOmpany.SelectedItem.Text & "' and batch_ref=" & txtBatchRef.Text & "", cn)
                If (cn.State = ConnectionState.Open) Then
                    cn.Close()
                End If
                cn.Open()
                cmd.ExecuteNonQuery()
                cn.Close()

                Dim Rex As New DataSet
                cmd = New SqlCommand("select * from sub_mast where cert = " & txtsubcert.Text & " and company='" & cmbCOmpany.SelectedItem.Text & "' and shares > 0 ", cn)
                adp = New SqlDataAdapter(cmd)
                adp.Fill(Rex, "mast")
                If (Rex.Tables(0).Rows.Count > 0) Then
                    'msgbox("Insert into Batched_Certs (batch_ref,cert,cd,shareholder,shares,company,status,batch_date,batched_by) values (" & txtBatchRef.Text & "," & txtsubcert.Text & ",0," & Rex.Tables(0).Rows(0).Item("shareholder").ToString & "," & Rex.Tables(0).Rows(0).Item("shares").ToString & ",'" & cmbCOmpany.SelectedItem.Text & "',1,'" & txtdate.Text & "','" & Session("username") & "')")

                    cmd = New SqlCommand("Insert into Batched_Certs (batch_ref,cert,cd,shareholder,shares,company,status,batch_date,batched_by) values (" & txtBatchRef.Text & "," & txtsubcert.Text & ",0," & Rex.Tables(0).Rows(0).Item("shareholder").ToString & "," & Rex.Tables(0).Rows(0).Item("shares").ToString & ",'" & cmbCOmpany.SelectedItem.Text & "',1,'" & Format(Now.Date, "M/d/yyyy") & "','" & Session("username") & "')", cn)
                    If (cn.State = ConnectionState.Open) Then
                        cn.Close()
                    End If
                    cn.Open()
                    cmd.ExecuteNonQuery()
                    cn.Close()
                End If
            End If



            'Processing Controls

            If (rdEnterNow.Checked = True) Then
                If (cmbBatchType.SelectedItem.Text = "XFER" Or cmbBatchType.SelectedItem.Text = "WITHDRAW") Then
                    Label35.Visible = False
                    txtsubcert.Visible = False
                    txtsubcert.Text = ""
                    Label36.Text = ""
                    If (rdEnterNow.Checked = True) Then
                        BatchNowShow()
                    Else
                        BatchNowShow()
                    End If
                End If
                If (cmbBatchType.SelectedItem.Text = "CDS") Then
                    Label35.Visible = False
                    txtsubcert.Visible = False
                    txtsubcert.Text = ""
                    Label36.Text = ""
                    If (rdEnterNow.Checked = True) Then
                        BatchNowShow()
                        Label37.Visible = False
                        txtTransfereeHolderSearch.Visible = False
                        btnTranssearch0.Visible = False
                        Label16.Visible = False
                        txtTransfereeSearch.Visible = False
                        btnTranssearch.Visible = False
                        lstTransferee.Visible = False
                        Label18.Visible = False
                        txtTransfereeBatchShares.Visible = False
                        btnBatchTransshares.Visible = False
                        txtToBatchShares.Visible = False
                        btnToBatchShares.Visible = False
                    Else
                        BatchNowShow()
                    End If
                End If
                If (cmbBatchType.SelectedItem.Text = "ALLOT") Then
                    If (rdEnterNow.Checked = True) Then
                        BatchNowShow()
                        Label33.Text = "Name"
                        lstNamesSelect.Visible = True
                        lstNamesSelect.Items.Clear()
                        Label35.Visible = False
                        txtsubcert.Visible = False
                        Label36.Text = ""
                        txtsubcert.Text = ""
                        Label30.Visible = True
                        Label29.Visible = True

                        txtToBatchShares.Visible = True
                        btnToBatchShares.Visible = True
                    End If
                End If

                If (cmbBatchType.SelectedItem.Text <> "ALLOT" And cmbBatchType.SelectedItem.Text <> "XFER" And cmbBatchType.SelectedItem.Text <> "CDS" And cmbBatchType.SelectedItem.Text <> "WITHDRAW") Then
                    If (rdEnterNow.Checked = True) Then
                        BatchNowShow()
                        Label33.Text = "Certificate"
                        lstNamesSelect.Visible = False
                        lstNamesSelect.Items.Clear()
                        Label35.Visible = False
                        txtsubcert.Visible = False
                        Label36.Text = ""
                        txtsubcert.Text = ""
                        Label30.Visible = False
                        Label30.Text = ""
                        Label29.Visible = False

                        txtToBatchShares.Visible = True
                        btnToBatchShares.Visible = True
                        If (cmbBatchType.SelectedItem.Text = "INDEM") Then
                            txtToBatchShares.Visible = False
                            btnToBatchShares.Visible = False
                        End If
                    End If
                End If

                If (cmbBatchType.SelectedItem.Text = "SUB XFER") Then
                    rdPost.Checked = True
                    Label35.Visible = True
                    txtsubcert.Visible = True
                    If (rdPost.Checked = True) Then
                        HideControls()
                    End If
                End If
                If (cmbBatchType.SelectedItem.Text <> "SUB XFER") Then
                    Label35.Visible = False
                    txtsubcert.Visible = False
                    txtsubcert.Text = ""
                    Label36.Text = ""
                End If
                If (cmbBatchType.SelectedItem.Text = "CD") Then
                    rdCDs.Visible = True
                    rdBalance.Visible = True
                    Label29.Text = "Main Certificate Shares"
                    Label29.Visible = True
                    txtToBatchShares.Visible = True
                    btnToBatchShares.Visible = False

                    Label32.Visible = True
                    Label37.Visible = True
                    Label37.Text = "CD Shares"
                    txtTransfereeHolderSearch.Visible = True
                    btnTranssearch0.Visible = True
                    Label16.Text = "Create Balance Shares"
                    Label16.Visible = True
                    txtTransfereeSearch.Visible = False
                    btnTranssearch.Visible = True

                End If
            End If

            'End Processing Controls

            'User Audit
            Dim strClientIP As String
            strClientIP = Request.UserHostAddress()

            cmd = New SqlCommand("insert into TblUserAudit (UserID,ActionType,ActionDate,ActionDateTime,LocationFrom,AccessMode) values ('" & Session("Username").ToString & "','Saved a new batch " & txtBatchRef.Text & "', '" & Format(Now.Date, "M/d/yyyy") & "','" & Date.Now & "','" & strClientIP & "','" & Request.UserAgent & "')", cn)

            If (cn.State = ConnectionState.Open) Then
                cn.Close()
            End If
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()


            If (BatchingOption = 1) Then
                msgbox("Batch Saved")
                PrintReport()
                ClearAll()
            Else
                msgbox("Batch Saved, Enter Batch Details")
            End If

        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Protected Sub btnCertSearch_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCertSearch.Click
        Try
            If (cmbBatchType.SelectedItem.Text = "ALLOT") Then
                Dim dsname As New DataSet
                cmd = New SqlCommand("select surname+' '+forenames+' '+convert(varchar , shareholder) as names from AccountsMain where surname like '" & txtCertSearch.Text & "%' and status= 1 and lock_Status= 0", cn)
                adp = New SqlDataAdapter(cmd)
                adp.Fill(dsname, "AccountsMain")
                If (dsname.Tables(0).Rows.Count > 0) Then
                    lstNamesSelect.DataSource = dsname.Tables(0)
                    lstNamesSelect.DataValueField = "names"
                    lstNamesSelect.DataBind()


                    'User Audit
                    Dim strClientIP As String
                    strClientIP = Request.UserHostAddress()

                    cmd = New SqlCommand("insert into TblUserAudit (UserID,ActionType,ActionDate,ActionDateTime,LocationFrom,AccessMode) values ('" & Session("Username").ToString & "','Seached for an account for allotment', '" & Now.Date & "','" & Date.Now & "','" & strClientIP & "','" & Request.UserAgent & "')", cn)

                    If (cn.State = ConnectionState.Open) Then
                        cn.Close()
                    End If
                    cn.Open()
                    cmd.ExecuteNonQuery()
                    cn.Close()
                Else
                    lstNamesSelect.Items.Clear()
                    Label30.Text = ""
                End If
            Else

                Dim BatchStatus As String = "O"
                Dim ds As New DataSet
                cmd = New SqlCommand("select distinct (cert),cd,shares, shareholder from mast where cert=" & txtCertSearch.Text & " and cd = " & txtCd.Text & " and company='" & cmbCOmpany.SelectedItem.Text & "' and locked= 0 and shares > 0 ", cn)
                adp = New SqlDataAdapter(cmd)
                adp.Fill(ds, "mast")
                'msgbox("test1")
                If (ds.Tables(0).Rows.Count > 0) Then

                    'Checking if its a certified account 
                    If (cmbBatchType.SelectedItem.Text = "CDS") Then
                        If (ds.Tables(0).Rows(0).Item("shareholder").ToString < 0) Then
                            msgbox("Cannot batch non certified accounts under batch type CDS")
                            Exit Sub
                        End If
                    End If

                    If (cmbBatchType.SelectedItem.Text = "CD") Then
                        If (ds.Tables(0).Rows(0).Item("shares").ToString <> CInt(txtShares.Text)) Then
                            msgbox("Batched shares and certificate shares do not match for a CD batch")
                            Exit Sub
                        End If
                    End If

                    If (cmbBatchType.SelectedItem.Text = "WITHDRAW") Then

                        Dim dscds As New DataSet
                        cmd = New SqlCommand("select cds_ac_no from para_company where company='" & Trim(cmbCOmpany.SelectedItem.Text) & "'", cn)

                        adp = New SqlDataAdapter(cmd)
                        adp.Fill(dscds, "para_company")
                        If (dscds.Tables(0).Rows.Count > 0) Then
                            If (ds.Tables(0).Rows(0).Item("shareholder").ToString <> dscds.Tables(0).Rows(0).Item("cds_ac_no").ToString) Then
                                msgbox("Cannot batch a non csd certificate for a batch withdraw")
                                Exit Sub
                            End If
                        End If

                    End If




                    'End certified Check
                    'msgbox("test1a")
                    'Checking if cert is currently in use

                    Dim dsc As New DataSet
                    cmd = New SqlCommand("select * from batched_certs where cert=" & txtCertSearch.Text & " and cd=" & txtCd.Text & " and company='" & cmbCOmpany.Text & "'", cn)
                    adp = New SqlDataAdapter(cmd)
                    adp.Fill(dsc, "batched_certs")

                    If (dsc.Tables(0).Rows.Count > 0) Then
                        Dim x As Integer
                        For x = 0 To dsc.Tables(0).Rows.Count - 1
                            If (dsc.Tables(0).Rows(x).Item("status").ToString = "1" Or dsc.Tables(0).Rows(x).Item("status").ToString = "0") Then
                                msgbox("selected certificate is currently under a batch process")
                                Exit Sub
                            End If
                        Next
                    End If


                    'Balancing Verifications
                    Dim dsi As New DataSet
                    cmd = New SqlCommand("select * from batched_certs where company='" & cmbCOmpany.SelectedItem.Text & "' and batch_ref=" & txtBatchRef.Text & "", cn)
                    adp = New SqlDataAdapter(cmd)
                    adp.Fill(dsi, "batched_certs")
                    'msgbox("test2")
                    If (dsi.Tables(0).Rows.Count > 0) Then
                        'msgbox("test2a")
                        Dim rex As New DataSet
                        rex.Clear()

                        cmd = New SqlCommand("select sum(shares) as shares from batched_certs where company='" & cmbCOmpany.SelectedItem.Text & "' and batch_ref=" & txtBatchRef.Text & "", cn)
                        adp = New SqlDataAdapter(cmd)
                        adp.Fill(rex, "batched_certs")

                        Dim Sharestobatch As Integer = 0
                        Sharestobatch = CInt(rex.Tables(0).Rows(0).Item("shares").ToString) + CInt(ds.Tables(0).Rows(0).Item("shares").ToString)
                        If (CInt(Sharestobatch) > CInt(txtShares.Text)) Then
                            msgbox("Selected Shares would exceed batch balance")
                            Exit Sub
                        End If


                        If (CInt(CInt(Sharestobatch) < CInt(txtShares.Text))) Then
                            cmd = New SqlCommand("insert into Batched_Certs (batch_ref,cert,cd,shareholder,shares,Company,Status,Batch_date,Batched_By) values (" & txtBatchRef.Text & "," & ds.Tables(0).Rows(0).Item("cert").ToString & "," & ds.Tables(0).Rows(0).Item("cd").ToString & "," & ds.Tables(0).Rows(0).Item("shareholder").ToString & "," & ds.Tables(0).Rows(0).Item("shares").ToString & ",'" & cmbCOmpany.SelectedItem.Text & "',0,'" & Now.Date & "','" & Session("Username") & "')", cn)
                            If (cn.State = ConnectionState.Open) Then
                                cn.Close()
                            End If
                            cn.Open()
                            cmd.ExecuteNonQuery()
                            cn.Close()

                            msgbox("Record Saved")
                            txtCertSearch.Text = ""
                            txtCd.Text = 0
                            getBatchedPrimary()
                        End If

                        If (CInt(CInt(Sharestobatch) = CInt(txtShares.Text))) Then
                            BatchStatus = "B"
                            cmd = New SqlCommand("insert into Batched_Certs (batch_ref,cert,cd,shareholder,shares,Company,Status,Batch_date,Batched_By) values (" & txtBatchRef.Text & "," & ds.Tables(0).Rows(0).Item("cert").ToString & "," & ds.Tables(0).Rows(0).Item("cd").ToString & "," & ds.Tables(0).Rows(0).Item("shareholder").ToString & "," & ds.Tables(0).Rows(0).Item("shares").ToString & ",'" & cmbCOmpany.SelectedItem.Text & "',0,'" & Now.Date & "','" & Session("Username") & "')", cn)
                            If (cn.State = ConnectionState.Open) Then
                                cn.Close()
                            End If
                            cn.Open()
                            cmd.ExecuteNonQuery()
                            cn.Close()

                            cmd = New SqlCommand("update batched_certs set status=1 where batch_ref=" & txtBatchRef.Text & " and company='" & cmbCOmpany.Text & "'", cn)
                            If (cn.State = ConnectionState.Open) Then
                                cn.Close()
                            End If
                            cn.Open()
                            cmd.ExecuteNonQuery()
                            cn.Close()

                            If (cmbBatchType.SelectedItem.Text = "XFER" Or cmbBatchType.SelectedItem.Text = "CD") Then
                                cmd = New SqlCommand("update batch_head set status='" & BatchStatus & "' where batch_ref=" & txtBatchRef.Text & " and company='" & cmbCOmpany.SelectedItem.Text & "'", cn)
                                If (cn.State = ConnectionState.Open) Then
                                    cn.Close()
                                End If
                                cn.Open()
                                cmd.ExecuteNonQuery()
                                cn.Close()

                                txtCertSearch.Text = ""
                                txtCd.Text = 0
                                getBatchedPrimary()
                            Else
                                cmd = New SqlCommand("update batch_head set status='" & BatchStatus & "', batchprocesslevel='P' where batch_ref=" & txtBatchRef.Text & " and company='" & cmbCOmpany.SelectedItem.Text & "'", cn)
                                If (cn.State = ConnectionState.Open) Then
                                    cn.Close()
                                End If
                                cn.Open()
                                cmd.ExecuteNonQuery()
                                cn.Close()

                                txtCertSearch.Text = ""
                                txtCd.Text = 0
                                getBatchedPrimary()
                            End If



                            'Mast Temp Saving
                            If (cmbBatchType.SelectedItem.Text = "INDEM") Then

                                Dim dsbatxh As New DataSet
                                cmd = New SqlCommand("select * from batch_head where company='" & cmbCOmpany.SelectedItem.Text & "' and batch_ref=" & txtBatchRef.Text & " and status='B'", cn)
                                adp = New SqlDataAdapter(cmd)
                                adp.Fill(dsbatxh, "batch_head")

                                If (dsbatxh.Tables(0).Rows.Count > 0) Then
                                    Dim dsx As New DataSet
                                    cmd = New SqlCommand("select * from Batched_Certs where company='" & cmbCOmpany.SelectedItem.Text & "' and batch_ref=" & txtBatchRef.Text & " and status=1", cn)
                                    adp = New SqlDataAdapter(cmd)
                                    adp.Fill(dsx, "Batched_Certs")

                                    If (dsx.Tables(0).Rows.Count > 0) Then
                                        Dim i As Integer
                                        For i = 0 To dsx.Tables(0).Rows.Count - 1
                                            cmd = New SqlCommand("insert into masttemp(company,shareholder,cert,cd,date_created,shares,locked,part_ind,tran_type,printed,xfer,cert_type,batch_ref) values ('" & dsx.Tables(0).Rows(i).Item("company").ToString & "'," & dsx.Tables(0).Rows(i).Item("shareholder").ToString & "," & dsx.Tables(0).Rows(i).Item("cert").ToString & "," & dsx.Tables(0).Rows(i).Item("cd").ToString & ",'" & Now.Date & "'," & CInt(dsx.Tables(0).Rows(i).Item("shares").ToString) * -1 & ",0,1,'" & dsbatxh.Tables(0).Rows(0).Item("Batch_Type").ToString & "',0," & dsbatxh.Tables(0).Rows(0).Item("xfer").ToString & ",'N'," & txtBatchRef.Text & ")", cn)
                                            If (cn.State = ConnectionState.Open) Then
                                                cn.Close()
                                            End If
                                            cn.Open()
                                            cmd.ExecuteNonQuery()
                                            cn.Close()

                                            cmd = New SqlCommand("insert into masttemp(company,shareholder,cert,cd,date_created,shares,locked,part_ind,tran_type,printed,xfer,cert_type,batch_ref) values ('" & dsx.Tables(0).Rows(i).Item("company").ToString & "'," & dsx.Tables(0).Rows(i).Item("shareholder").ToString & ",0,0,'" & Now.Date & "'," & CInt(dsx.Tables(0).Rows(i).Item("shares").ToString) & ",0,1,'" & dsbatxh.Tables(0).Rows(0).Item("Batch_Type").ToString & "',0,0,'N'," & txtBatchRef.Text & ")", cn)
                                            If (cn.State = ConnectionState.Open) Then
                                                cn.Close()
                                            End If
                                            cn.Open()
                                            cmd.ExecuteNonQuery()
                                            cn.Close()
                                        Next

                                        txtCertSearch.Text = ""
                                        txtCd.Text = 0
                                        getBatchedPrimary()

                                        'audit trail

                                        Dim dsaudit As New DataSet
                                        cmd = New SqlCommand("select * from masttemp where batch_ref = " & txtBatchRef.Text & "", cn)
                                        adp = New SqlDataAdapter(cmd)
                                        adp.Fill(dsaudit, "masttemp")

                                        Dim j As Integer
                                        For j = 0 To dsaudit.Tables(0).Rows.Count - 1
                                            BindCombo.AuditTrail(dsaudit.Tables(0).Rows(j).Item("update_no").ToString, Date.Now(), "0", dsaudit.Tables(0).Rows(j).Item("shareholder").ToString, "0", "0", dsaudit.Tables(0).Rows(j).Item("cert").ToString, 0, dsaudit.Tables(0).Rows(j).Item("shares").ToString, dsaudit.Tables(0).Rows(j).Item("tran_type").ToString, Session("Username"), txtBatchRef.Text, Trim(cmbCOmpany.SelectedItem.Text))
                                        Next

                                    End If
                                Else
                                    Dim dsx As New DataSet
                                    cmd = New SqlCommand("select * from Batched_Certs where company='" & cmbCOmpany.SelectedItem.Text & "' and batch_ref=" & txtBatchRef.Text & " and status=1", cn)
                                    adp = New SqlDataAdapter(cmd)
                                    adp.Fill(dsx, "Batched_Certs")

                                    If (dsx.Tables(0).Rows.Count > 0) Then
                                        Dim i As Integer
                                        For i = 0 To dsx.Tables(0).Rows.Count - 1
                                            cmd = New SqlCommand("insert into masttemp(company,shareholder,cert,cd,date_created,shares,locked,part_ind,tran_type,printed,xfer,cert_type,batch_ref) values ('" & dsx.Tables(0).Rows(i).Item("company").ToString & "'," & dsx.Tables(0).Rows(i).Item("shareholder").ToString & ",0,0,'" & Now.Date & "'," & CInt(dsx.Tables(0).Rows(i).Item("shares").ToString) & ",0,1,'" & dsbatxh.Tables(0).Rows(0).Item("Batch_Type").ToString & "',0,0,'N'," & txtBatchRef.Text & ")", cn)
                                            If (cn.State = ConnectionState.Open) Then
                                                cn.Close()
                                            End If
                                            cn.Open()
                                            cmd.ExecuteNonQuery()
                                            cn.Close()

                                        Next
                                    End If
                                End If
                            End If

                            'End Indem Transaction

                            'Start CDS Transaction

                            If (cmbBatchType.SelectedItem.Text = "CDS") Then

                                Dim dsbatxh As New DataSet
                                cmd = New SqlCommand("select * from batch_head where company='" & cmbCOmpany.SelectedItem.Text & "' and batch_ref=" & txtBatchRef.Text & " and status='B'", cn)
                                adp = New SqlDataAdapter(cmd)
                                adp.Fill(dsbatxh, "batch_head")

                                If (dsbatxh.Tables(0).Rows.Count > 0) Then
                                    Dim dsx As New DataSet
                                    cmd = New SqlCommand("select * from Batched_Certs where company='" & cmbCOmpany.SelectedItem.Text & "' and batch_ref=" & txtBatchRef.Text & " and status=1", cn)
                                    adp = New SqlDataAdapter(cmd)
                                    adp.Fill(dsx, "Batched_Certs")

                                    If (dsx.Tables(0).Rows.Count > 0) Then
                                        Dim i As Integer
                                        For i = 0 To dsx.Tables(0).Rows.Count - 1
                                            cmd = New SqlCommand("insert into masttemp(company,shareholder,cert,cd,date_created,shares,locked,part_ind,tran_type,printed,xfer,cert_type,batch_ref) values ('" & dsx.Tables(0).Rows(i).Item("company").ToString & "'," & dsx.Tables(0).Rows(i).Item("shareholder").ToString & "," & dsx.Tables(0).Rows(i).Item("cert").ToString & "," & dsx.Tables(0).Rows(i).Item("cd").ToString & ",'" & Now.Date & "'," & CInt(dsx.Tables(0).Rows(i).Item("shares").ToString) * -1 & ",0,1,'" & dsbatxh.Tables(0).Rows(0).Item("Batch_Type").ToString & "',0," & dsbatxh.Tables(0).Rows(0).Item("xfer").ToString & ",'N'," & txtBatchRef.Text & ")", cn)
                                            If (cn.State = ConnectionState.Open) Then
                                                cn.Close()
                                            End If
                                            cn.Open()
                                            cmd.ExecuteNonQuery()
                                            cn.Close()

                                            Dim dscds As New DataSet
                                            cmd = New SqlCommand("select cds_ac_no from para_company where company='" & cmbCOmpany.SelectedItem.Text & "'", cn)
                                            adp = New SqlDataAdapter(cmd)
                                            adp.Fill(dscds, "para_company")
                                            Dim cdsacc As Integer = 0
                                            If (dscds.Tables(0).Rows.Count > 0) Then
                                                cdsacc = dscds.Tables(0).Rows(0).Item("cds_ac_no").ToString
                                            End If

                                            cmd = New SqlCommand("insert into masttemp(company,shareholder,cert,cd,date_created,shares,locked,part_ind,tran_type,printed,xfer,cert_type,batch_ref) values ('" & dsx.Tables(0).Rows(i).Item("company").ToString & "'," & cdsacc & ",0,0,'" & Now.Date & "'," & CInt(dsx.Tables(0).Rows(i).Item("shares").ToString) & ",0,1,'" & dsbatxh.Tables(0).Rows(0).Item("Batch_Type").ToString & "',0,0,'N'," & txtBatchRef.Text & ")", cn)
                                            If (cn.State = ConnectionState.Open) Then
                                                cn.Close()
                                            End If
                                            cn.Open()
                                            cmd.ExecuteNonQuery()
                                            cn.Close()
                                        Next

                                        txtCertSearch.Text = ""
                                        txtCd.Text = 0
                                        getBatchedPrimary()

                                        'audit trail

                                        Dim dsaudit As New DataSet
                                        cmd = New SqlCommand("select * from masttemp where batch_ref = " & txtBatchRef.Text & "", cn)
                                        adp = New SqlDataAdapter(cmd)
                                        adp.Fill(dsaudit, "masttemp")

                                        Dim j As Integer
                                        For j = 0 To dsaudit.Tables(0).Rows.Count - 1
                                            BindCombo.AuditTrail(dsaudit.Tables(0).Rows(j).Item("update_no").ToString, Date.Now(), "0", dsaudit.Tables(0).Rows(j).Item("shareholder").ToString, "0", "0", dsaudit.Tables(0).Rows(j).Item("cert").ToString, 0, dsaudit.Tables(0).Rows(j).Item("shares").ToString, dsaudit.Tables(0).Rows(j).Item("tran_type").ToString, Session("Username"), txtBatchRef.Text, Trim(cmbCOmpany.SelectedItem.Text))
                                        Next

                                    End If
                                    'Else
                                    '    Dim dsx As New DataSet
                                    '    cmd = New SqlCommand("select * from Batched_Certs where company='" & cmbCOmpany.SelectedItem.Text & "' and batch_ref=" & txtBatchRef.Text & " and status=1", cn)
                                    '    adp = New SqlDataAdapter(cmd)
                                    '    adp.Fill(dsx, "Batched_Certs")

                                    '    If (dsx.Tables(0).Rows.Count > 0) Then
                                    '        Dim i As Integer
                                    '        For i = 0 To dsx.Tables(0).Rows.Count - 1
                                    '            cmd = New SqlCommand("insert into masttemp(company,shareholder,cert,cd,date_created,shares,locked,part_ind,tran_type,printed,xfer,cert_type,batch_ref) values ('" & dsx.Tables(0).Rows(i).Item("company").ToString & "'," & dsx.Tables(0).Rows(i).Item("shareholder").ToString & ",0,0,'" & Now.Date & "'," & CInt(dsx.Tables(0).Rows(i).Item("shares").ToString) & ",0,1,'" & dsbatxh.Tables(0).Rows(0).Item("Batch_Type").ToString & "',0,0,'N'," & txtBatchRef.Text & ")", cn)
                                    '            If (cn.State = ConnectionState.Open) Then
                                    '                cn.Close()
                                    '            End If
                                    '            cn.Open()
                                    '            cmd.ExecuteNonQuery()
                                    '            cn.Close()

                                    '        Next
                                    'End If
                                End If
                            End If

                            'End CDS Transaction

                            If (cmbBatchType.SelectedItem.Text = "XFER") Then
                                msgbox("Batch balanced, enter transferee details")
                                txtCertSearch.Text = ""
                                txtCd.Text = 0
                                getBatchedPrimary()
                            Else
                                msgbox("Batch balanced")
                                txtCertSearch.Text = ""
                                txtCertSearch.Text = ""
                                txtCd.Text = 0
                                getBatchedPrimary()
                                'ClearAll()
                            End If
                        End If

                        'If (BatchStatus = "B") Then
                        '    cmd = New SqlCommand("update batch_head set status='" & BatchStatus & "' where batch_ref=" & txtBatchRef.Text & " and company='" & cmbCOmpany.SelectedItem.Text & "'", cn)
                        '    If (cn.State = ConnectionState.Open) Then
                        '        cn.Close()
                        '    End If
                        '    cn.Open()
                        '    cmd.ExecuteNonQuery()
                        '    cn.Close()

                        '    msgbox("Batch Balanced")
                        'Else
                        '    msgbox("Record Added")
                        '    getBatchedPrimary()
                        'End If

                    Else
                        'msgbox("test")
                        'msgbox("test3")
                        If (CInt(ds.Tables(0).Rows(0).Item("shares").ToString) > CInt(txtShares.Text)) Then

                            msgbox("Selected Shares would exceed batch balance")
                            Exit Sub
                        End If

                        If (CInt(ds.Tables(0).Rows(0).Item("shares").ToString) < CInt(txtShares.Text)) Then
                            BatchStatus = "O"

                            cmd = New SqlCommand("insert into Batched_Certs (batch_ref,cert,cd,shareholder,shares,Company,Status,Batch_date,Batched_By) values (" & txtBatchRef.Text & "," & ds.Tables(0).Rows(0).Item("cert").ToString & "," & ds.Tables(0).Rows(0).Item("cd").ToString & "," & ds.Tables(0).Rows(0).Item("shareholder").ToString & "," & ds.Tables(0).Rows(0).Item("shares").ToString & ",'" & cmbCOmpany.SelectedItem.Text & "',0,'" & Now.Date & "','" & Session("Username") & "')", cn)
                            If (cn.State = ConnectionState.Open) Then
                                cn.Close()
                            End If
                            cn.Open()
                            cmd.ExecuteNonQuery()
                            cn.Close()
                            msgbox("Record Saved")
                            txtCertSearch.Text = ""
                            txtCd.Text = 0
                            getBatchedPrimary()
                        End If

                        If (CInt(ds.Tables(0).Rows(0).Item("shares").ToString) = CInt(txtShares.Text)) Then
                            'msgbox("test3a")
                            BatchStatus = "B"
                            cmd = New SqlCommand("insert into Batched_Certs (batch_ref,cert,cd,shareholder,shares,Company,Status,Batch_date,Batched_By) values (" & txtBatchRef.Text & "," & ds.Tables(0).Rows(0).Item("cert").ToString & "," & ds.Tables(0).Rows(0).Item("cd").ToString & "," & ds.Tables(0).Rows(0).Item("shareholder").ToString & "," & ds.Tables(0).Rows(0).Item("shares").ToString & ",'" & cmbCOmpany.SelectedItem.Text & "',0,'" & Now.Date & "','" & Session("Username") & "')", cn)
                            If (cn.State = ConnectionState.Open) Then
                                cn.Close()
                            End If
                            cn.Open()
                            cmd.ExecuteNonQuery()
                            cn.Close()

                            cmd = New SqlCommand("update batch_head set status='" & BatchStatus & "' where batch_ref=" & txtBatchRef.Text & " and company='" & cmbCOmpany.SelectedItem.Text & "'", cn)
                            If (cn.State = ConnectionState.Open) Then
                                cn.Close()
                            End If
                            cn.Open()
                            cmd.ExecuteNonQuery()
                            cn.Close()



                            cmd = New SqlCommand("update batched_certs set status=1 where batch_ref=" & txtBatchRef.Text & " and company='" & cmbCOmpany.Text & "'", cn)
                            If (cn.State = ConnectionState.Open) Then
                                cn.Close()
                            End If
                            cn.Open()
                            cmd.ExecuteNonQuery()
                            cn.Close()

                            If (cmbBatchType.SelectedItem.Text = "XFER") Then
                                cmd = New SqlCommand("update batch_head set status='" & BatchStatus & "' where batch_ref=" & txtBatchRef.Text & " and company='" & cmbCOmpany.SelectedItem.Text & "'", cn)
                                If (cn.State = ConnectionState.Open) Then
                                    cn.Close()
                                End If
                                cn.Open()
                                cmd.ExecuteNonQuery()
                                cn.Close()
                            Else
                                cmd = New SqlCommand("update batch_head set status='" & BatchStatus & "', batchprocesslevel='P' where batch_ref=" & txtBatchRef.Text & " and company='" & cmbCOmpany.SelectedItem.Text & "'", cn)
                                If (cn.State = ConnectionState.Open) Then
                                    cn.Close()
                                End If
                                cn.Open()
                                cmd.ExecuteNonQuery()
                                cn.Close()

                                cmd = New SqlCommand("update batched_certs set status= 1 where company='" & cmbCOmpany.Text & "' and batch_ref = " & txtBatchRef.Text & "", cn)
                                If (cn.State = ConnectionState.Open) Then
                                    cn.Close()
                                End If
                                cn.Open()
                                cmd.ExecuteNonQuery()
                                cn.Close()
                            End If



                            'Mast Temp Saving
                            'msgbox("test4")
                            If (cmbBatchType.SelectedItem.Text = "INDEM") Then

                                Dim dsbatxh As New DataSet
                                cmd = New SqlCommand("select * from batch_head where company='" & cmbCOmpany.SelectedItem.Text & "' and batch_ref=" & txtBatchRef.Text & " and status='B'", cn)
                                adp = New SqlDataAdapter(cmd)
                                adp.Fill(dsbatxh, "batch_head")

                                If (dsbatxh.Tables(0).Rows.Count > 0) Then
                                    'msgbox("test4a")
                                    Dim dsx As New DataSet
                                    cmd = New SqlCommand("select * from Batched_Certs where company='" & cmbCOmpany.SelectedItem.Text & "' and batch_ref=" & txtBatchRef.Text & " and status=1", cn)
                                    adp = New SqlDataAdapter(cmd)
                                    adp.Fill(dsx, "Batched_Certs")

                                    If (dsx.Tables(0).Rows.Count > 0) Then
                                        Dim i As Integer
                                        For i = 0 To dsx.Tables(0).Rows.Count - 1
                                            cmd = New SqlCommand("insert into masttemp(company,shareholder,cert,cd,date_created,shares,locked,part_ind,tran_type,printed,xfer,cert_type,batch_ref) values ('" & dsx.Tables(0).Rows(i).Item("company").ToString & "'," & dsx.Tables(0).Rows(i).Item("shareholder").ToString & "," & dsx.Tables(0).Rows(i).Item("cert").ToString & "," & dsx.Tables(0).Rows(i).Item("cd").ToString & ",'" & Now.Date & "'," & CInt(dsx.Tables(0).Rows(i).Item("shares").ToString) * -1 & ",0,1,'" & dsbatxh.Tables(0).Rows(0).Item("Batch_Type").ToString & "',0," & dsbatxh.Tables(0).Rows(0).Item("xfer").ToString & ",'N'," & txtBatchRef.Text & ")", cn)
                                            If (cn.State = ConnectionState.Open) Then
                                                cn.Close()
                                            End If
                                            cn.Open()
                                            cmd.ExecuteNonQuery()
                                            cn.Close()

                                            cmd = New SqlCommand("insert into masttemp(company,shareholder,cert,cd,date_created,shares,locked,part_ind,tran_type,printed,xfer,cert_type,batch_ref) values ('" & dsx.Tables(0).Rows(i).Item("company").ToString & "'," & dsx.Tables(0).Rows(i).Item("shareholder").ToString & ",0,0,'" & Now.Date & "'," & CInt(dsx.Tables(0).Rows(i).Item("shares").ToString) & ",0,1,'" & dsbatxh.Tables(0).Rows(0).Item("Batch_Type").ToString & "',0,0,'N'," & txtBatchRef.Text & ")", cn)
                                            If (cn.State = ConnectionState.Open) Then
                                                cn.Close()
                                            End If
                                            cn.Open()
                                            cmd.ExecuteNonQuery()
                                            cn.Close()
                                        Next
                                    End If
                                Else
                                    'msgbox("test5")
                                    Dim dsx As New DataSet
                                    cmd = New SqlCommand("select * from Batched_Certs where company='" & cmbCOmpany.SelectedItem.Text & "' and batch_ref=" & txtBatchRef.Text & " and status=1", cn)
                                    adp = New SqlDataAdapter(cmd)
                                    adp.Fill(dsx, "Batched_Certs")

                                    If (dsx.Tables(0).Rows.Count > 0) Then

                                        Dim i As Integer
                                        For i = 0 To dsx.Tables(0).Rows.Count - 1
                                            'msgbox("test5a")
                                            'msgbox(",0,0,'N'," & txtBatchRef.Text & ")")
                                            cmd = New SqlCommand("insert into masttemp(company,shareholder,cert,cd,date_created,shares,locked,part_ind,tran_type,printed,xfer,cert_type,batch_ref) values ('" & dsx.Tables(0).Rows(i).Item("company").ToString & "'," & dsx.Tables(0).Rows(i).Item("shareholder").ToString & ",0,0,'" & Now.Date & "'," & CInt(dsx.Tables(0).Rows(i).Item("shares").ToString) & ",0,1,'" & dsbatxh.Tables(0).Rows(0).Item("Batch_Type").ToString & "',0,0,'N'," & txtBatchRef.Text & ")", cn)
                                            If (cn.State = ConnectionState.Open) Then
                                                cn.Close()
                                            End If
                                            cn.Open()
                                            cmd.ExecuteNonQuery()
                                            cn.Close()

                                        Next


                                        'audit trail

                                        Dim dsaudit As New DataSet
                                        cmd = New SqlCommand("select * from masttemp where batch_ref = " & txtBatchRef.Text & "", cn)
                                        adp = New SqlDataAdapter(cmd)
                                        adp.Fill(dsaudit, "masttemp")

                                        Dim j As Integer
                                        For j = 0 To dsaudit.Tables(0).Rows.Count - 1
                                            BindCombo.AuditTrail(dsaudit.Tables(0).Rows(j).Item("update_no").ToString, Date.Now(), "0", dsaudit.Tables(0).Rows(j).Item("shareholder").ToString, "0", "0", dsaudit.Tables(0).Rows(j).Item("cert").ToString, 0, dsaudit.Tables(0).Rows(j).Item("shares").ToString, dsaudit.Tables(0).Rows(j).Item("tran_type").ToString, Session("Username"), txtBatchRef.Text, Trim(cmbCOmpany.SelectedItem.Text))
                                        Next
                                    End If
                                End If
                            End If


                            'CDS Transaction

                            If (cmbBatchType.SelectedItem.Text = "CDS") Then

                                Dim dsbatxh As New DataSet
                                cmd = New SqlCommand("select * from batch_head where company='" & cmbCOmpany.SelectedItem.Text & "' and batch_ref=" & txtBatchRef.Text & " and status='B'", cn)
                                adp = New SqlDataAdapter(cmd)
                                adp.Fill(dsbatxh, "batch_head")

                                If (dsbatxh.Tables(0).Rows.Count > 0) Then
                                    'msgbox("test4a")
                                    Dim dsx As New DataSet
                                    cmd = New SqlCommand("select * from Batched_Certs where company='" & cmbCOmpany.SelectedItem.Text & "' and batch_ref=" & txtBatchRef.Text & " and status=1", cn)
                                    adp = New SqlDataAdapter(cmd)
                                    adp.Fill(dsx, "Batched_Certs")

                                    If (dsx.Tables(0).Rows.Count > 0) Then
                                        Dim i As Integer
                                        For i = 0 To dsx.Tables(0).Rows.Count - 1
                                            cmd = New SqlCommand("insert into masttemp(company,shareholder,cert,cd,date_created,shares,locked,part_ind,tran_type,printed,xfer,cert_type,batch_ref) values ('" & dsx.Tables(0).Rows(i).Item("company").ToString & "'," & dsx.Tables(0).Rows(i).Item("shareholder").ToString & "," & dsx.Tables(0).Rows(i).Item("cert").ToString & "," & dsx.Tables(0).Rows(i).Item("cd").ToString & ",'" & Now.Date & "'," & CInt(dsx.Tables(0).Rows(i).Item("shares").ToString) * -1 & ",0,1,'" & dsbatxh.Tables(0).Rows(0).Item("Batch_Type").ToString & "',0," & dsbatxh.Tables(0).Rows(0).Item("xfer").ToString & ",'N'," & txtBatchRef.Text & ")", cn)
                                            If (cn.State = ConnectionState.Open) Then
                                                cn.Close()
                                            End If
                                            cn.Open()
                                            cmd.ExecuteNonQuery()
                                            cn.Close()


                                            Dim dscds As New DataSet
                                            cmd = New SqlCommand("select cds_ac_no from para_company where company='" & cmbCOmpany.SelectedItem.Text & "'", cn)
                                            adp = New SqlDataAdapter(cmd)
                                            adp.Fill(dscds, "para_company")
                                            Dim cdsacc As Integer = 0
                                            If (dscds.Tables(0).Rows.Count > 0) Then
                                                cdsacc = dscds.Tables(0).Rows(0).Item("cds_ac_no").ToString
                                            End If


                                            cmd = New SqlCommand("insert into masttemp(company,shareholder,cert,cd,date_created,shares,locked,part_ind,tran_type,printed,xfer,cert_type,batch_ref) values ('" & dsx.Tables(0).Rows(i).Item("company").ToString & "'," & dscds.Tables(0).Rows(0).Item("cds_ac_no").ToString & ",0,0,'" & Now.Date & "'," & CInt(dsx.Tables(0).Rows(i).Item("shares").ToString) & ",0,1,'" & dsbatxh.Tables(0).Rows(0).Item("Batch_Type").ToString & "',0,0,'N'," & txtBatchRef.Text & ")", cn)
                                            If (cn.State = ConnectionState.Open) Then
                                                cn.Close()
                                            End If
                                            cn.Open()
                                            cmd.ExecuteNonQuery()
                                            cn.Close()
                                        Next
                                    End If
                                Else
                                    'msgbox("test5")
                                    Dim dsx As New DataSet
                                    cmd = New SqlCommand("select * from Batched_Certs where company='" & cmbCOmpany.SelectedItem.Text & "' and batch_ref=" & txtBatchRef.Text & " and status=1", cn)
                                    adp = New SqlDataAdapter(cmd)
                                    adp.Fill(dsx, "Batched_Certs")

                                    If (dsx.Tables(0).Rows.Count > 0) Then

                                        Dim i As Integer
                                        For i = 0 To dsx.Tables(0).Rows.Count - 1
                                            'msgbox("test5a")
                                            'msgbox(",0,0,'N'," & txtBatchRef.Text & ")")
                                            cmd = New SqlCommand("insert into masttemp(company,shareholder,cert,cd,date_created,shares,locked,part_ind,tran_type,printed,xfer,cert_type,batch_ref) values ('" & dsx.Tables(0).Rows(i).Item("company").ToString & "'," & dsx.Tables(0).Rows(i).Item("shareholder").ToString & ",0,0,'" & Now.Date & "'," & CInt(dsx.Tables(0).Rows(i).Item("shares").ToString) & ",0,1,'" & dsbatxh.Tables(0).Rows(0).Item("Batch_Type").ToString & "',0,0,'N'," & txtBatchRef.Text & ")", cn)
                                            If (cn.State = ConnectionState.Open) Then
                                                cn.Close()
                                            End If
                                            cn.Open()
                                            cmd.ExecuteNonQuery()
                                            cn.Close()

                                        Next


                                        'audit trail

                                        Dim dsaudit As New DataSet
                                        cmd = New SqlCommand("select * from masttemp where batch_ref = " & txtBatchRef.Text & "", cn)
                                        adp = New SqlDataAdapter(cmd)
                                        adp.Fill(dsaudit, "masttemp")

                                        Dim j As Integer
                                        For j = 0 To dsaudit.Tables(0).Rows.Count - 1
                                            BindCombo.AuditTrail(dsaudit.Tables(0).Rows(j).Item("update_no").ToString, Date.Now(), "0", dsaudit.Tables(0).Rows(j).Item("shareholder").ToString, "0", "0", dsaudit.Tables(0).Rows(j).Item("cert").ToString, 0, dsaudit.Tables(0).Rows(j).Item("shares").ToString, dsaudit.Tables(0).Rows(j).Item("tran_type").ToString, Session("Username"), txtBatchRef.Text, Trim(cmbCOmpany.SelectedItem.Text))
                                        Next
                                    End If
                                End If
                            End If

                            'End CDS Transaction
                            If (cmbBatchType.SelectedItem.Text = "XFER") Then
                                msgbox("Batch balanced, enter receiving details")
                                txtCertSearch.Text = ""
                                txtCd.Text = 0
                                getBatchedPrimary()
                            Else
                                If (cmbBatchType.SelectedItem.Text = "CD") Then
                                    cmd = New SqlCommand("update batch_head set batchprocesslevel='O' where batch_ref=" & txtBatchRef.Text & " and company='" & cmbCOmpany.SelectedItem.Text & "'", cn)
                                    If (cn.State = ConnectionState.Open) Then
                                        cn.Close()
                                    End If
                                    cn.Open()
                                    cmd.ExecuteNonQuery()
                                    cn.Close()
                                End If
                                msgbox("Batch balanced")
                                txtCertSearch.Text = ""
                                'ClearAll()
                                txtCertSearch.Text = ""
                                txtCd.Text = 0
                                getBatchedPrimary()
                            End If
                        End If

                    End If

                Else
                    msgbox("Certificate not found")


                End If

                'If (BatchStatus = "B") Then
                '    cmd = New SqlCommand("update batch_head set status='" & BatchStatus & "' where batch_ref=" & txtBatchRef.Text & " and company='" & cmbCOmpany.SelectedItem.Text & "'", cn)
                '    If (cn.State = ConnectionState.Open) Then
                '        cn.Close()
                '    End If
                '    cn.Open()
                '    cmd.ExecuteNonQuery()
                '    cn.Close()

                '    msgbox("Batch Balanced")
                'Else
                '    msgbox("Record Added")
                '    getBatchedPrimary()
                'End If

                'User Audit
                Dim strClientIP As String
                strClientIP = Request.UserHostAddress()

                cmd = New SqlCommand("insert into TblUserAudit (UserID,ActionType,ActionDate,ActionDateTime,LocationFrom,AccessMode) values ('" & Session("Username").ToString & "','Entered a batch certificate for batch " & txtBatchRef.Text & "', '" & Now.Date & "','" & Date.Now & "','" & strClientIP & "','" & Request.UserAgent & "')", cn)

                If (cn.State = ConnectionState.Open) Then
                    cn.Close()
                End If
                cn.Open()
                cmd.ExecuteNonQuery()
                cn.Close()
            End If

        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub getBatchedPrimary()
        Try
            Dim ds As New DataSet
            'cmd = New SqlCommand("select batch_ref as [Batch Ref], Cert as [Certificate], cd as [CD], Shareholder as [Shareholder], shares as [Shares], Company as [Company] from batched_Certs where company='" & cmbCOmpany.SelectedItem.Text & "' and batch_ref=" & txtBatchRef.Text & "", cn)

            cmd = New SqlCommand("select batched_Certs.Shareholder as [Shareholder], AccountsMain.Surname +' '+AccountsMain .Forenames as [Holder], batched_Certs.Cert as [Certificate], batched_Certs.cd as [CD],  batched_Certs.shares as [Shares] from batched_Certs, AccountsMain where batched_Certs.company='" & cmbCOmpany.SelectedItem.Text & "' and batched_Certs.batch_ref=" & txtBatchRef.Text & " and batched_Certs.shareholder=AccountsMain.shareholder", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "batched_certs")
            If (ds.Tables(0).Rows.Count > 0) Then
                If (cmbBatchType.SelectedItem.Text = "CD") Then
                    Dim RemainingShares As Integer = 0
                    Dim BatchedShares As Integer = 0
                    Dim CertShares As Integer = 0

                    CertShares = ds.Tables(0).Rows(0).Item("shares").ToString

                    Dim dsi As New DataSet
                    cmd = New SqlCommand("select * from tmpCDs where batch_ref=" & txtBatchRef.Text & " and company='" & cmbCOmpany.SelectedItem.Text & "'", cn)
                    adp = New SqlDataAdapter(cmd)
                    adp.Fill(dsi, "tmpCDs")
                    If (dsi.Tables(0).Rows.Count > 0) Then
                        For x2 = 0 To dsi.Tables(0).Rows.Count - 1
                            BatchedShares = BatchedShares + CInt(dsi.Tables(0).Rows(x2).Item("shares").ToString)
                        Next
                        RemainingShares = CertShares - BatchedShares
                    Else
                        RemainingShares = CertShares
                    End If


                    txtToBatchShares.Text = CInt(RemainingShares)
                End If
                grdAddedCertificate.Visible = True
                'Button4.Visible = True
                grdAddedCertificate.DataSource = ds.Tables(0)
                grdAddedCertificate.DataBind()
            Else
                Button4.Visible = False
                grdAddedCertificate.DataSource = Nothing
                grdAddedCertificate.DataBind()
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Protected Sub btnNew_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnNew.Click
        Try
            Label29.Text = "Shares"
            Label37.Text = "Shareholder No."
            Label16.Text = "Name"
            Response.Redirect("~\Capture\CaptureHome.aspx")
            'getBatchedPrimary()
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub Refresh()
        Try
            rdCDs.Visible = False
            rdBalance.Visible = False
            Label29.Text = "Shares"
            Label37.Text = "Shareholder No."
            Label16.Text = "Name"
            Response.Redirect("~\Capture\CaptureHome.aspx")
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Protected Sub btnBatchSearch_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnBatchSearch.Click
        Try
            getSearchedBatch()
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub getSearchedBatch()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select * from batch_head where batch_ref=" & txtBatchSearch.Text & "", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "batch_head")
            If (ds.Tables(0).Rows.Count > 0) Then
                If (ds.Tables(0).Rows(0).Item("BatchProcesslevel").ToString = "P") Then
                    msgbox("selected batch has been processed")
                    ClearAll()
                    getBatch()
                    Exit Sub
                End If
                btnUpdate.Visible = True
                txtBatchRef.Text = ds.Tables(0).Rows(0).Item("batch_ref").ToString

                cmbCOmpany.SelectedItem.Text = ds.Tables(0).Rows(0).Item("company").ToString

                txtdate.SelectedDate = ds.Tables(0).Rows(0).Item("batch_date").ToString

                cmbBatchType.SelectedItem.Text = ds.Tables(0).Rows(0).Item("Batch_type").ToString
                txtComments.Text = ds.Tables(0).Rows(0).Item("comments").ToString
                'msgbox(ds.Tables(0).Rows(0).Item("batch_ref").ToString)
                Dim dsfnam As New DataSet
                cmd = New SqlCommand("select fnam from batch_types where type='" & cmbBatchType.SelectedValue & "'", cn)
                adp = New SqlDataAdapter(cmd)
                adp.Fill(dsfnam, "batch_types")
                If (dsfnam.Tables(0).Rows.Count > 0) Then
                    txtBatchType.Text = dsfnam.Tables(0).Rows(0).Item(0).ToString()
                End If
                txtShares.Text = ds.Tables(0).Rows(0).Item("shares").ToString
                cmbbroker.Text = ds.Tables(0).Rows(0).Item("Broker_Lodger").ToString
                cmbBroker1.SelectedItem.Text = ds.Tables(0).Rows(0).Item("Broker_lodger").ToString
                If (ds.Tables(0).Rows(0).Item("batch_option").ToString = 0) Then
                    rdEnterNow.Checked = True
                    rdPost.Checked = False
                Else
                    rdEnterNow.Checked = False
                    rdPost.Checked = True
                End If

                btnAdd.Enabled = False
                getBatchedPrimary()
                GetReceivingAccounts()
                If (cmbBatchType.SelectedItem.Text = "SUB XFER") Then
                    rdCDs.Visible = False
                    rdBalance.Visible = False
                    Label29.Text = "Shares"
                    Label37.Text = "Shareholder No."
                    Label16.Text = "Name"
                    rdPost.Checked = True
                    Label35.Visible = True
                    txtsubcert.Visible = True
                    If (rdPost.Checked = True) Then
                        HideControls()
                    End If
                End If
                If (cmbBatchType.SelectedItem.Text <> "SUB XFER") Then
                    rdCDs.Visible = False
                    rdBalance.Visible = False
                    Label29.Text = "Shares"
                    Label37.Text = "Shareholder No."
                    Label16.Text = "Name"
                    Label35.Visible = False
                    txtsubcert.Visible = False
                    txtsubcert.Text = ""
                    Label36.Text = ""
                End If
                If (cmbBatchType.SelectedItem.Text = "XFER") Then
                    rdCDs.Visible = False
                    rdBalance.Visible = False
                    Label29.Text = "Shares"
                    Label37.Text = "Shareholder No."
                    Label16.Text = "Name"
                    If (rdEnterNow.Checked = True) Then
                        BatchNowShow()
                    Else
                        BatchNowShow()
                    End If
                End If

                If (rdEnterNow.Checked = True) Then
                    BatchNowShow()
                    If (cmbBatchType.SelectedItem.Text = "ALLOT") Then
                        rdCDs.Visible = False
                        rdBalance.Visible = False
                        Label29.Text = "Shares"
                        Label37.Text = "Shareholder No."
                        Label16.Text = "Name"
                        If (rdEnterNow.Checked = True) Then
                            BatchNowShow()
                            Label33.Text = "Name"
                            lstNamesSelect.Visible = True
                            lstNamesSelect.Items.Clear()

                            Label30.Visible = True
                            Label29.Visible = True

                            txtToBatchShares.Visible = True
                            btnToBatchShares.Visible = True
                        End If
                    End If
                Else
                    HideControls()
                End If
                If (cmbBatchType.SelectedItem.Text = "CD") Then
                    rdCDs.Visible = True
                    rdBalance.Visible = True
                    Label29.Text = "Main Certificate Shares"
                    Label29.Visible = True
                    txtToBatchShares.Visible = True
                    btnToBatchShares.Visible = False

                    Label32.Visible = True
                    Label37.Visible = True
                    Label37.Text = "CD Shares"
                    txtTransfereeHolderSearch.Visible = True
                    btnTranssearch0.Visible = True
                    Label16.Text = "Create Balance Shares"
                    Label16.Visible = True
                    txtTransfereeSearch.Visible = False
                    btnTranssearch.Visible = True

                    Dim ri As New DataSet
                    cmd = New SqlCommand("select * from tmpCDs where company='" & cmbCOmpany.SelectedItem.Text & "' and batch_ref=" & txtBatchRef.Text & "", cn)
                    adp = New SqlDataAdapter(cmd)
                    adp.Fill(ri, "tmpCDs")
                    If (ri.Tables(0).Rows.Count > 0) Then
                        Dim jam As New DataSet
                        cmd = New SqlCommand("select sum(shares) as shares from tmpCDs where company='" & cmbCOmpany.SelectedItem.Text & "' and batch_ref=" & txtBatchRef.Text & "", cn)
                        adp = New SqlDataAdapter(cmd)
                        adp.Fill(jam, "tmpCDs")

                        Dim Newshares As Integer = 0
                        Newshares = CInt(grdAddedCertificate.Rows(0).Cells(5).Text) - CInt(jam.Tables(0).Rows(0).Item("shares").ToString)
                        txtToBatchShares.Text = Newshares

                        Dim Ts As New DataSet
                        cmd = New SqlCommand("select shareholder as [Shareholder], cert as [Certificate],cd as [CD], tranType as [Trans], shares as [Shares],Batch_ref as [Batch] from tmpCDs where company='" & cmbCOmpany.SelectedItem.Text & "' and batch_ref=" & txtBatchRef.Text & "", cn)
                        adp = New SqlDataAdapter(cmd)
                        adp.Fill(Ts, "tmpCDs")
                        If (Ts.Tables(0).Rows.Count > 0) Then
                            grdTransshares.Visible = True
                            grdTransshares.DataSource = Ts.Tables(0)
                            grdTransshares.DataBind()
                            txtTransfereeHolderSearch.Text = ""
                        Else
                            grdTransshares.DataSource = Nothing
                            grdTransshares.DataBind()
                        End If

                    Else
                        txtToBatchShares.Text = grdAddedCertificate.Rows(0).Cells(5).Text
                    End If

                End If

            Else
                btnAdd.Enabled = True
                ClearAll()
                getBatch()
                msgbox("Batch not found")
            End If

        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Protected Sub Button4_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button4.Click
        Try
            Dim i, j As Integer
            Dim dssharescert, dscertvari As New DataSet
            j = grdAddedCertificate.Rows.Count
            If (cmbBatchType.SelectedItem.Text = "ALLOT") Then
                For i = 0 To j - 1
                    j = grdAddedCertificate.Rows.Count
                    Dim chk As CheckBox
                    chk = CType(grdAddedCertificate.Rows(i).Cells(0).FindControl("checkbox1"), CheckBox)
                    If chk.Checked = True Then
                        'cmd = New SqlCommand("delete from batched_certs where batch_ref=" & grdAddedCertificate.Rows(i).Cells(1).Text & " and shareholder=" & grdAddedCertificate.Rows(i).Cells(4).Text & " and company='" & grdAddedCertificate.Rows(i).Cells(6).Text & "' and shareholder=" & grdAddedCertificate.Rows(i).Cells(4).Text & " and shares=" & grdAddedCertificate.Rows(i).Cells(5).Text & "", cn)
                        cmd = New SqlCommand("delete from batched_certs where batch_ref=" & CInt(txtBatchRef.Text) & " and shareholder=" & grdAddedCertificate.Rows(i).Cells(2).Text & " and company='" & Trim(cmbCOmpany.SelectedItem.Text) & "' and shareholder=" & grdAddedCertificate.Rows(i).Cells(2).Text & " and shares=" & grdAddedCertificate.Rows(i).Cells(6).Text & "", cn)
                        cn.Open()
                        cmd.ExecuteNonQuery()
                        cn.Close()

                        'msgbox("test")
                        Dim dsi As New DataSet
                        cmd = New SqlCommand("select sum(shares)as shares from batched_certs where batch_ref = " & txtBatchRef.Text & " and company='" & cmbCOmpany.SelectedItem.Text & "'", cn)
                        adp = New SqlDataAdapter(cmd)
                        adp.Fill(dsi, "batched_certs")

                        If (CInt(dsi.Tables(0).Rows(0).Item("shares").ToString) <> CInt(txtShares.Text)) Then
                            cmd = New SqlCommand("updated batch_head set status ='O' where batch_ref=" & txtBatchRef.Text & " and company='" & cmbCOmpany.SelectedItem.Text & "'", cn)
                            If (cn.State = ConnectionState.Open) Then
                                cn.Close()
                            End If
                            cn.Open()
                            cmd.ExecuteNonQuery()
                            cn.Close()
                            'msgbox("test1")
                        End If
                    End If
                Next

            Else
                'msgbox("test2")
                For i = 0 To j - 1
                    j = grdAddedCertificate.Rows.Count
                    Dim chk As CheckBox
                    chk = CType(grdAddedCertificate.Rows(i).Cells(0).FindControl("checkbox1"), CheckBox)
                    If chk.Checked = True Then
                        'msgbox("delete from batched_certs where batch_ref=" & CInt(txtBatchRef.Text) & " and cert=" & grdAddedCertificate.Rows(i).Cells(2).Text & " and company='" & Trim(cmbCOmpany.SelectedItem.Text) & "' and shareholder=" & grdAddedCertificate.Rows(i).Cells(4).Text & " and shares=" & grdAddedCertificate.Rows(i).Cells(5).Text & "")
                        cmd = New SqlCommand("delete from batched_certs where batch_ref=" & CInt(txtBatchRef.Text) & " and cert=" & grdAddedCertificate.Rows(i).Cells(2).Text & " and company='" & Trim(cmbCOmpany.SelectedItem.Text) & "' and shareholder=" & grdAddedCertificate.Rows(i).Cells(4).Text & " and shares=" & grdAddedCertificate.Rows(i).Cells(5).Text & "", cn)
                        cn.Open()
                        cmd.ExecuteNonQuery()
                        cn.Close()


                        Dim dsz As New DataSet
                        cmd = New SqlCommand("select * from batched_certs where batch_ref = " & txtBatchRef.Text & " and company='" & cmbCOmpany.SelectedItem.Text & "'", cn)
                        adp = New SqlDataAdapter(cmd)
                        adp.Fill(dsz, "batched_certs")
                        'msgbox("test3")
                        If (dsz.Tables(0).Rows.Count > 0) Then
                            Dim dsi As New DataSet
                            cmd = New SqlCommand("select sum(shares)as shares from batched_certs where batch_ref = " & txtBatchRef.Text & " and company='" & cmbCOmpany.SelectedItem.Text & "'", cn)
                            adp = New SqlDataAdapter(cmd)
                            adp.Fill(dsi, "batched_certs")

                            If (CInt(dsi.Tables(0).Rows(0).Item("shares").ToString) <> CInt(txtShares.Text)) Then
                                cmd = New SqlCommand("updated batch_head set status ='O' where batch_ref=" & txtBatchRef.Text & " and company='" & cmbCOmpany.SelectedItem.Text & "'", cn)
                                If (cn.State = ConnectionState.Open) Then
                                    cn.Close()
                                End If
                                cn.Open()
                                cmd.ExecuteNonQuery()
                                cn.Close()
                            End If
                        Else
                            'msgbox("test4")
                            'msgbox("update batch_head set status ='O' where batch_ref=" & txtBatchRef.Text & " and company='" & cmbCOmpany.SelectedItem.Text & "'")
                            cmd = New SqlCommand("update batch_head set status ='O' where batch_ref=" & txtBatchRef.Text & " and company='" & Trim(cmbCOmpany.SelectedItem.Text) & "'", cn)
                            If (cn.State = ConnectionState.Open) Then
                                cn.Close()
                            End If
                            cn.Open()
                            cmd.ExecuteNonQuery()
                            cn.Close()
                        End If

                    End If
                Next

            End If
            getBatchedPrimary()

        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Protected Sub btnToBatchShares_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnToBatchShares.Click
        Try
            If (Label30.Text = "") Then
                msgbox("Select a valid shareholder account")
                Exit Sub
            End If

            Dim ds As New DataSet
            cmd = New SqlCommand("select * from batched_Certs where batch_ref=" & txtBatchRef.Text & " order by cert desc", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "batched_certs")

            If (ds.Tables(0).Rows.Count > 0) Then
                Dim dsi As New DataSet
                cmd = New SqlCommand("select sum(shares) as shares from batched_certs where batch_ref =" & txtBatchRef.Text & " and company='" & cmbCOmpany.SelectedItem.Text & "'", cn)
                adp = New SqlDataAdapter(cmd)
                adp.Fill(dsi, "batched_certs")

                If (CInt(CInt(dsi.Tables(0).Rows(0).Item("shares").ToString) + CInt(txtToBatchShares.Text)) > CInt(txtShares.Text)) Then
                    msgbox("shares would exceed batch shares")
                    Exit Sub
                End If


                If (CInt(CInt(dsi.Tables(0).Rows(0).Item("shares").ToString) + CInt(txtToBatchShares.Text)) < CInt(txtShares.Text)) Then
                    cmd = New SqlCommand("insert into Batched_Certs (batch_ref,cert,cd,shareholder,shares,Company,Status,Batch_date,Batched_By) values (" & txtBatchRef.Text & "," & ds.Tables(0).Rows(0).Item("cert").ToString + 1 & ",0," & Label30.Text & "," & CInt(txtToBatchShares.Text) & ",'" & cmbCOmpany.SelectedItem.Text & "',0,'" & Now.Date & "','" & Session("Username") & "')", cn)
                    If (cn.State = ConnectionState.Open) Then
                        cn.Close()
                    End If
                    cn.Open()
                    cmd.ExecuteNonQuery()
                    cn.Close()

                    msgbox("Record added")
                    Dim strClientIP As String
                    strClientIP = Request.UserHostAddress()

                    cmd = New SqlCommand("insert into TblUserAudit (UserID,ActionType,ActionDate,ActionDateTime,LocationFrom,AccessMode) values ('" & Session("Username").ToString & "','Added batch shares  to allotment batch', '" & Now.Date & "','" & Date.Now & "','" & strClientIP & "','" & Request.UserAgent & "')", cn)

                    If (cn.State = ConnectionState.Open) Then
                        cn.Close()
                    End If
                    cn.Open()
                    cmd.ExecuteNonQuery()
                    cn.Close()
                    Label30.Text = ""
                    txtCertSearch.Text = ""
                    txtCd.Text = 0
                    lstNamesSelect.Items.Clear()
                    txtToBatchShares.Text = ""
                    getBatchedPrimary()
                End If


                If (CInt(CInt(dsi.Tables(0).Rows(0).Item("shares").ToString) + CInt(txtToBatchShares.Text)) = CInt(txtShares.Text)) Then
                    cmd = New SqlCommand("insert into Batched_Certs (batch_ref,cert,cd,shareholder,shares,Company,Status,Batch_date,Batched_By) values (" & txtBatchRef.Text & "," & ds.Tables(0).Rows(0).Item("cert").ToString + 1 & ",0," & Label30.Text & "," & txtToBatchShares.Text & ",'" & cmbCOmpany.SelectedItem.Text & "',0,'" & Now.Date & "','" & Session("Username") & "')", cn)
                    If (cn.State = ConnectionState.Open) Then
                        cn.Close()
                    End If
                    cn.Open()
                    cmd.ExecuteNonQuery()
                    cn.Close()


                    msgbox("Batch balanced")

                    Dim strClientIP As String
                    strClientIP = Request.UserHostAddress()

                    cmd = New SqlCommand("insert into TblUserAudit (UserID,ActionType,ActionDate,ActionDateTime,LocationFrom,AccessMode) values ('" & Session("Username").ToString & "','Added balancing shares to allotment batch " & txtBatchRef.Text & " ', '" & Now.Date & "','" & Date.Now & "','" & strClientIP & "','" & Request.UserAgent & "')", cn)

                    If (cn.State = ConnectionState.Open) Then
                        cn.Close()
                    End If
                    cn.Open()
                    cmd.ExecuteNonQuery()
                    cn.Close()


                    cmd = New SqlCommand("update batched_certs set status=1 where batch_ref=" & txtBatchRef.Text & " and company='" & cmbCOmpany.SelectedItem.Text & "'", cn)
                    If (cn.State = ConnectionState.Open) Then
                        cn.Close()
                    End If
                    cn.Open()
                    cmd.ExecuteNonQuery()
                    cn.Close()


                    cmd = New SqlCommand("update batch_head set status='B', batchprocesslevel='P' where batch_ref=" & txtBatchRef.Text & " and company='" & cmbCOmpany.SelectedItem.Text & "'", cn)
                    If (cn.State = ConnectionState.Open) Then
                        cn.Close()
                    End If
                    cn.Open()
                    cmd.ExecuteNonQuery()
                    cn.Close()



                    Dim dsx As New DataSet
                    cmd = New SqlCommand("select * from Batched_Certs where company='" & cmbCOmpany.SelectedItem.Text & "' and batch_ref=" & txtBatchRef.Text & " and status=1", cn)
                    adp = New SqlDataAdapter(cmd)
                    adp.Fill(dsx, "Batched_Certs")

                    If (dsx.Tables(0).Rows.Count > 0) Then
                        Dim i As Integer
                        For i = 0 To dsx.Tables(0).Rows.Count - 1
                            cmd = New SqlCommand("insert into masttemp(company,shareholder,cert,cd,date_created,shares,locked,part_ind,tran_type,printed,xfer,cert_type,batch_ref) values ('" & dsx.Tables(0).Rows(i).Item("company").ToString & "'," & dsx.Tables(0).Rows(i).Item("shareholder").ToString & ",0,0,'" & Now.Date & "'," & CInt(dsx.Tables(0).Rows(i).Item("shares").ToString) & ",0,1,'" & cmbBatchType.SelectedItem.Text & "',0,0,'N'," & txtBatchRef.Text & ")", cn)
                            If (cn.State = ConnectionState.Open) Then
                                cn.Close()
                            End If
                            cn.Open()
                            cmd.ExecuteNonQuery()
                            cn.Close()

                        Next
                    End If

                    Label30.Text = ""
                    txtCertSearch.Text = ""
                    txtCd.Text = 0
                    lstNamesSelect.Items.Clear()
                    txtToBatchShares.Text = ""



                End If

            Else

                If (CInt(txtToBatchShares.Text) > CInt(txtShares.Text)) Then
                    msgbox("shares would exceed batch shares")
                    Exit Sub
                End If

                If (CInt(txtToBatchShares.Text) < CInt(CInt(txtShares.Text))) Then

                    cmd = New SqlCommand("insert into Batched_Certs (batch_ref,cert,cd,shareholder,shares,Company,Status,Batch_date,Batched_By) values (" & txtBatchRef.Text & ",0,0," & Label30.Text & "," & CInt(txtToBatchShares.Text) & ",'" & cmbCOmpany.SelectedItem.Text & "',0,'" & Now.Date & "','" & Session("Username") & "')", cn)
                    If (cn.State = ConnectionState.Open) Then
                        cn.Close()
                    End If
                    cn.Open()
                    cmd.ExecuteNonQuery()
                    cn.Close()

                    msgbox("Recored added")

                    Dim strClientIP As String
                    strClientIP = Request.UserHostAddress()

                    cmd = New SqlCommand("insert into TblUserAudit (UserID,ActionType,ActionDate,ActionDateTime,LocationFrom,AccessMode) values ('" & Session("Username").ToString & "','Added shares to allotment batch " & txtBatchRef.Text & " ', '" & Now.Date & "','" & Date.Now & "','" & strClientIP & "','" & Request.UserAgent & "')", cn)

                    If (cn.State = ConnectionState.Open) Then
                        cn.Close()
                    End If
                    cn.Open()
                    cmd.ExecuteNonQuery()
                    cn.Close()

                    Label30.Text = ""
                    txtCertSearch.Text = ""
                    txtCd.Text = 0
                    lstNamesSelect.Items.Clear()
                    txtToBatchShares.Text = ""

                    getBatchedPrimary()
                End If

                If (CInt(txtToBatchShares.Text) = CInt(CInt(txtShares.Text))) Then
                    cmd = New SqlCommand("insert into Batched_Certs (batch_ref,cert,cd,shareholder,shares,Company,Status,Batch_date,Batched_By) values (" & txtBatchRef.Text & ",0,0," & Label30.Text & "," & CInt(txtToBatchShares.Text) & ",'" & cmbCOmpany.SelectedItem.Text & "',0,'" & Now.Date & "','" & Session("Username") & "')", cn)
                    If (cn.State = ConnectionState.Open) Then
                        cn.Close()
                    End If
                    cn.Open()
                    cmd.ExecuteNonQuery()
                    cn.Close()

                    msgbox("Batch balanced")

                    Dim strClientIP As String
                    strClientIP = Request.UserHostAddress()

                    cmd = New SqlCommand("insert into TblUserAudit (UserID,ActionType,ActionDate,ActionDateTime,LocationFrom,AccessMode) values ('" & Session("Username").ToString & "','Added balancing shares to allotment batch " & txtBatchRef.Text & " ', '" & Now.Date & "','" & Date.Now & "','" & strClientIP & "','" & Request.UserAgent & "')", cn)

                    If (cn.State = ConnectionState.Open) Then
                        cn.Close()
                    End If
                    cn.Open()
                    cmd.ExecuteNonQuery()
                    cn.Close()


                    cmd = New SqlCommand("update batched_certs set status=1 where batch_ref=" & txtBatchRef.Text & " and company='" & cmbCOmpany.SelectedItem.Text & "'", cn)
                    If (cn.State = ConnectionState.Open) Then
                        cn.Close()
                    End If
                    cn.Open()
                    cmd.ExecuteNonQuery()
                    cn.Close()


                    cmd = New SqlCommand("update batch_head set status='B', batchprocesslevel='P' where batch_ref=" & txtBatchRef.Text & " and company='" & cmbCOmpany.SelectedItem.Text & "'", cn)
                    If (cn.State = ConnectionState.Open) Then
                        cn.Close()
                    End If
                    cn.Open()
                    cmd.ExecuteNonQuery()
                    cn.Close()


                    Dim dsx As New DataSet
                    cmd = New SqlCommand("select * from Batched_Certs where company='" & cmbCOmpany.SelectedItem.Text & "' and batch_ref=" & txtBatchRef.Text & " and status=1", cn)
                    adp = New SqlDataAdapter(cmd)
                    adp.Fill(dsx, "Batched_Certs")

                    If (dsx.Tables(0).Rows.Count > 0) Then
                        Dim i As Integer
                        For i = 0 To dsx.Tables(0).Rows.Count - 1
                            cmd = New SqlCommand("insert into masttemp(company,shareholder,cert,cd,date_created,shares,locked,part_ind,tran_type,printed,xfer,cert_type,batch_ref) values ('" & dsx.Tables(0).Rows(i).Item("company").ToString & "'," & dsx.Tables(0).Rows(i).Item("shareholder").ToString & ",0,0,'" & Now.Date & "'," & CInt(dsx.Tables(0).Rows(i).Item("shares").ToString) & ",0,1,'" & cmbBatchType.SelectedItem.Text & "',0,0,'N'," & txtBatchRef.Text & ")", cn)
                            If (cn.State = ConnectionState.Open) Then
                                cn.Close()
                            End If
                            cn.Open()
                            cmd.ExecuteNonQuery()
                            cn.Close()

                        Next
                    End If

                    Label30.Text = ""
                    txtCertSearch.Text = ""
                    txtCd.Text = 0
                    lstNamesSelect.Items.Clear()
                    txtToBatchShares.Text = ""

                End If

            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Protected Sub btnTranssearch_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnTranssearch.Click
        Try
            If (cmbBatchType.SelectedItem.Text = "CD") Then
                If (CInt(txtToBatchShares.Text) > 0) Then
                    cmd = New SqlCommand("insert into TmpCDs (shareholder,Cert,CD,TranType,Shares,Company,Batch_Ref,date_created,Status) values (" & grdAddedCertificate.Rows(0).Cells(1).Text & ",0,0,'CD'," & CInt(txtToBatchShares.Text) & ",'" & cmbCOmpany.SelectedItem.Text & "'," & txtBatchRef.Text & ",'" & Now.Date & "',0)", cn)
                    If (cn.State = ConnectionState.Open) Then
                        cn.Close()
                    End If
                    cn.Open()
                    cmd.ExecuteNonQuery()
                    cn.Close()

                    cmd = New SqlCommand("update batched_certs set status = 1 where company='" & cmbCOmpany.SelectedItem.Text & "' and batch_ref=" & txtBatchRef.Text & " and cert=" & grdAddedCertificate.Rows(0).Cells(3).Text & "", cn)
                    If (cn.State = ConnectionState.Open) Then
                        cn.Close()
                    End If
                    cn.Open()
                    cmd.ExecuteNonQuery()
                    cn.Close()

                    cmd = New SqlCommand("update batch_head set BatchProcessLevel='P' where company='" & cmbCOmpany.SelectedItem.Text & "' and batch_ref=" & txtBatchRef.Text & "", cn)
                    If (cn.State = ConnectionState.Open) Then
                        cn.Close()
                    End If
                    cn.Open()
                    cmd.ExecuteNonQuery()
                    cn.Close()

                    cmd = New SqlCommand("insert into masttemp (company,shareholder,cert,cd,date_created,shares,locked,part_ind,tran_type,printed,xfer,cert_type,batch_ref) values ('" & cmbCOmpany.SelectedItem.Text & "'," & grdAddedCertificate.Rows(0).Cells(1).Text & "," & grdAddedCertificate.Rows(0).Cells(3).Text & "," & grdAddedCertificate.Rows(0).Cells(4).Text & ",'" & Now.Date & "'," & CInt(grdAddedCertificate.Rows(0).Cells(5).Text) * -1 & ",0,1,'CD',1,0,'N'," & txtBatchRef.Text & ")", cn)
                    If (cn.State = ConnectionState.Open) Then
                        cn.Close()
                    End If
                    cn.Open()
                    cmd.ExecuteNonQuery()
                    cn.Close()

                    Dim ros As New DataSet
                    cmd = New SqlCommand("select * from tmpCDs where company='" & cmbCOmpany.SelectedItem.Text & "' and batch_ref=" & txtBatchRef.Text & "", cn)
                    adp = New SqlDataAdapter(cmd)
                    adp.Fill(ros, "tmpCDs")
                    If (ros.Tables(0).Rows.Count > 0) Then
                        Dim f As Integer
                        For f = 0 To ros.Tables(0).Rows.Count - 1
                            'msgbox("test")
                            cmd = New SqlCommand("insert into masttemp (company,shareholder,cert,cd,date_created,shares,locked,part_ind,tran_type,printed,xfer,cert_type,batch_ref) values ('" & cmbCOmpany.SelectedItem.Text & "'," & ros.Tables(0).Rows(f).Item("shareholder").ToString & "," & ros.Tables(0).Rows(f).Item("Cert").ToString & "," & ros.Tables(0).Rows(f).Item("Cd").ToString & ",'" & Now.Date & "'," & CInt(ros.Tables(0).Rows(f).Item("shares").ToString) & ",0,1,'" & ros.Tables(0).Rows(f).Item("tranType").ToString & "',1,0,'N'," & txtBatchRef.Text & ")", cn)
                            If (cn.State = ConnectionState.Open) Then
                                cn.Close()
                            End If
                            cn.Open()
                            cmd.ExecuteNonQuery()
                            cn.Close()
                        Next
                        msgbox("Batch Balanced")
                    End If
                    Refresh()
                Else
                    msgbox("Invalid Balance Shares")
                    Exit Sub
                End If
            Else
                Dim dsi As New DataSet
                cmd = New SqlCommand("select * from batch_head where company='" & cmbCOmpany.SelectedItem.Text & "' and batch_ref=" & txtBatchRef.Text & "", cn)
                adp = New SqlDataAdapter(cmd)
                adp.Fill(dsi, "batch_head")

                If (dsi.Tables(0).Rows.Count > 0) Then

                    If (dsi.Tables(0).Rows(0).Item("Status").ToString <> "B") Then
                        msgbox("Balance the first part of the batch")
                        Exit Sub
                    Else
                        Dim ds As New DataSet
                        'msgbox("select surname+' '+forenames+' '+convert(varchar,shareholder) as holder, shareholder from names where surname like '" & txtTransfereeSearch.Text & "%'")
                        cmd = New SqlCommand("select surname+' '+forenames+' '+convert(varchar,shareholder) as holder, shareholder from AccountsMain where surname like '" & txtTransfereeSearch.Text & "%' and status = 1 and lock_status = 0 ", cn)
                        adp = New SqlDataAdapter(cmd)
                        adp.Fill(ds, "AccountsMain")
                        If (ds.Tables(0).Rows.Count > 0) Then
                            lstTransferee.DataSource = ds.Tables(0)
                            lstTransferee.DataValueField = "holder"
                            lstTransferee.DataBind()
                        Else
                            lstTransferee.DataSource = Nothing
                            lstTransferee.DataBind()
                        End If
                    End If
                Else
                    lstTransferee.DataSource = Nothing
                    lstTransferee.DataBind()

                    lstTransferee.Items.Clear()
                    msgbox("select a relevant batch")

                End If

            End If

        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Protected Sub lstTransferee_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles lstTransferee.SelectedIndexChanged
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select shareholder from AccountsMain where surname+' '+forenames+' '+convert(varchar,shareholder) = '" & lstTransferee.SelectedItem.Text & "'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "Accountsmain")
            If (ds.Tables(0).Rows.Count > 0) Then
                Label17.Text = ds.Tables(0).Rows(0).Item("shareholder").ToString
                txtTransfereeBatchShares.Focus()
            Else
                Label17.Text = ""
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Protected Sub btnBatchTransshares_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnBatchTransshares.Click
        Try
            If (Session("username") = "") Then
                Response.Redirect("~\loginPage.aspx")
            End If

            Dim dsz As New DataSet
            cmd = New SqlCommand("select * from batch_head where company='" & cmbCOmpany.SelectedItem.Text & "' and batch_ref =" & txtBatchRef.Text & "", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(dsz, "batch_head")
            If (dsz.Tables(0).Rows.Count > 0) Then
                If (dsz.Tables(0).Rows(0).Item("status").ToString <> "B") Then
                    msgbox("Balance the first part of the batch before adding the transferees")
                    Exit Sub
                End If
            End If
            If (Label17.Text = "") Then
                msgbox("Select a shareholder to receive shares")
                Exit Sub
            End If
            If (CInt(Label17.Text) < 0) Then
                msgbox("Cannot transfer to a csd account")
                Exit Sub
            End If

            'verification point
            Dim ds As New DataSet
            cmd = New SqlCommand("Select * from BatchedReceiving where batch_ref=" & txtBatchRef.Text & " and company='" & cmbCOmpany.SelectedItem.Text & "'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "BatchedReceiving")
            If (ds.Tables(0).Rows.Count > 0) Then

                Dim rex As New DataSet
                cmd = New SqlCommand("select sum(shares) as shares from BatchedReceiving where batch_ref=" & txtBatchRef.Text & " and company='" & cmbCOmpany.SelectedItem.Text & "'", cn)
                adp = New SqlDataAdapter(cmd)
                adp.Fill(rex, "BatchedReceiving")

                Dim Batchedshares As Integer = rex.Tables(0).Rows(0).Item("shares").ToString

                If (CInt(Batchedshares) + CInt(txtTransfereeBatchShares.Text) > CInt(txtShares.Text)) Then
                    msgbox("Entered shares will exceed batch total")
                    Exit Sub
                End If

                If (CInt(Batchedshares) + CInt(txtTransfereeBatchShares.Text) < CInt(txtShares.Text)) Then
                    cmd = New SqlCommand("insert into BatchedReceiving (Batch_ref,Company,Shareholder,Shares,Batched_By,Status) values (" & txtBatchRef.Text & ",'" & cmbCOmpany.SelectedItem.Text & "'," & Label17.Text & "," & CInt(txtTransfereeBatchShares.Text) & ",'" & Session("Username").ToString & "',0)", cn)
                    If (cn.State = ConnectionState.Open) Then
                        cn.Close()
                    End If
                    cn.Open()
                    cmd.ExecuteNonQuery()
                    cn.Close()

                    msgbox("Record is added")
                    'Label34.Text = CInt(Batchedshares)
                    Label17.Text = ""
                    lstTransferee.Items.Clear()
                    txtTransfereeBatchShares.Text = ""
                    txtTransfereeSearch.Text = ""
                    txtTransfereeHolderSearch.Text = ""
                    GetReceivingAccounts()
                    txtTransfereeSearch.Focus()
                End If

                If (CInt(Batchedshares) + CInt(txtTransfereeBatchShares.Text) = CInt(txtShares.Text)) Then
                    cmd = New SqlCommand("insert into BatchedReceiving (Batch_ref,Company,Shareholder,Shares,Batched_By,Status) values (" & txtBatchRef.Text & ",'" & cmbCOmpany.SelectedItem.Text & "'," & Label17.Text & "," & CInt(txtTransfereeBatchShares.Text) & ",'" & Session("Username").ToString & "',0)", cn)
                    If (cn.State = ConnectionState.Open) Then
                        cn.Close()
                    End If
                    cn.Open()
                    cmd.ExecuteNonQuery()
                    cn.Close()

                    cmd = New SqlCommand("update batch_head set BatchProcesslevel = 'P' where batch_ref=" & txtBatchRef.Text & " and company='" & cmbCOmpany.SelectedItem.Text & "'", cn)
                    If (cn.State = ConnectionState.Open) Then
                        cn.Close()
                    End If
                    cn.Open()
                    cmd.ExecuteNonQuery()
                    cn.Close()

                    cmd = New SqlCommand("update batchedReceiving set status= 1 where batch_ref=" & txtBatchRef.Text & " and company='" & cmbCOmpany.SelectedItem.Text & "'", cn)
                    If (cn.State = ConnectionState.Open) Then
                        cn.Close()
                    End If
                    cn.Open()
                    cmd.ExecuteNonQuery()
                    cn.Close()

                    cmd = New SqlCommand("update batched_certs set status= 1 where batch_ref=" & txtBatchRef.Text & " and company='" & cmbCOmpany.SelectedItem.Text & "'", cn)
                    If (cn.State = ConnectionState.Open) Then
                        cn.Close()
                    End If
                    cn.Open()
                    cmd.ExecuteNonQuery()
                    cn.Close()

                    'Saving Mast temp for update

                    Dim dsbatxh As New DataSet
                    cmd = New SqlCommand("select * from batch_head where batch_ref=" & txtBatchRef.Text & " and company='" & cmbCOmpany.SelectedItem.Text & "'", cn)
                    adp = New SqlDataAdapter(cmd)
                    adp.Fill(dsbatxh, "batch_head")


                    If (cmbBatchType.SelectedItem.Text = "XFER") Then 'If its a transfer
                        Dim dsx As New DataSet
                        cmd = New SqlCommand("select * from Batched_Certs where company='" & cmbCOmpany.SelectedItem.Text & "' and batch_ref=" & txtBatchRef.Text & " and status=1", cn)
                        adp = New SqlDataAdapter(cmd)
                        adp.Fill(dsx, "Batched_Certs")

                        If (dsx.Tables(0).Rows.Count > 0) Then
                            Dim i As Integer
                            For i = 0 To dsx.Tables(0).Rows.Count - 1
                                cmd = New SqlCommand("insert into masttemp(company,shareholder,cert,cd,date_created,shares,locked,part_ind,tran_type,printed,xfer,cert_type,batch_ref) values ('" & dsx.Tables(0).Rows(i).Item("company").ToString & "'," & dsx.Tables(0).Rows(i).Item("shareholder").ToString & "," & dsx.Tables(0).Rows(i).Item("cert").ToString & ",0,'" & Now.Date & "'," & CInt(dsx.Tables(0).Rows(i).Item("shares").ToString) * -1 & ",0,1,'" & dsbatxh.Tables(0).Rows(0).Item("Batch_Type").ToString & "',0," & dsbatxh.Tables(0).Rows(0).Item("xfer").ToString & ",'N'," & txtBatchRef.Text & ")", cn)
                                If (cn.State = ConnectionState.Open) Then
                                    cn.Close()
                                End If
                                cn.Open()
                                cmd.ExecuteNonQuery()
                                cn.Close()
                            Next
                        End If

                        Dim dsxi As New DataSet
                        cmd = New SqlCommand("select * from BatchedReceiving where company='" & cmbCOmpany.SelectedItem.Text & "' and batch_ref=" & txtBatchRef.Text & " and status=1", cn)
                        adp = New SqlDataAdapter(cmd)
                        adp.Fill(dsxi, "BatchedReceiving")

                        If (dsxi.Tables(0).Rows.Count > 0) Then
                            Dim x As Integer
                            For x = 0 To dsxi.Tables(0).Rows.Count - 1
                                cmd = New SqlCommand("insert into masttemp(company,shareholder,cert,cd,date_created,shares,locked,part_ind,tran_type,printed,xfer,cert_type,batch_ref) values ('" & dsxi.Tables(0).Rows(x).Item("company").ToString & "'," & dsxi.Tables(0).Rows(x).Item("shareholder").ToString & ",0,0,'" & Now.Date & "'," & dsxi.Tables(0).Rows(x).Item("shares").ToString & ",0,1,'" & dsbatxh.Tables(0).Rows(0).Item("Batch_Type").ToString & "',0," & dsbatxh.Tables(0).Rows(0).Item("xfer").ToString & ",'N'," & txtBatchRef.Text & ")", cn)
                                If (cn.State = ConnectionState.Open) Then
                                    cn.Close()
                                End If
                                cn.Open()
                                cmd.ExecuteNonQuery()
                                cn.Close()
                            Next
                        End If

                    ElseIf (cmbBatchType.SelectedItem.Text = "INDEM") Then 'INDEM TRANSACTION TYPE

                        Dim dsx As New DataSet
                        cmd = New SqlCommand("select * from Batched_Certs where company='" & cmbCOmpany.SelectedItem.Text & "' and batch_ref=" & txtBatchRef.Text & " and status=1", cn)
                        adp = New SqlDataAdapter(cmd)
                        adp.Fill(dsx, "Batched_Certs")

                        If (dsx.Tables(0).Rows.Count > 0) Then
                            Dim i As Integer
                            For i = 0 To dsx.Tables(0).Rows.Count - 1
                                cmd = New SqlCommand("insert into masttemp(company,shareholder,cert,cd,date_created,shares,locked,part_ind,tran_type,printed,xfer,cert_type,batch_ref) values ('" & dsx.Tables(0).Rows(i).Item("company").ToString & "'," & dsx.Tables(0).Rows(i).Item("shareholder").ToString & "," & dsx.Tables(0).Rows(i).Item("cert").ToString & ",0,'" & Now.Date & "'," & CInt(dsx.Tables(0).Rows(i).Item("shares").ToString) * -1 & ",0,1,'" & dsbatxh.Tables(0).Rows(0).Item("Batch_Type").ToString & "',0," & dsbatxh.Tables(0).Rows(0).Item("xfer").ToString & ",'N'," & txtBatchRef.Text & ")", cn)
                                If (cn.State = ConnectionState.Open) Then
                                    cn.Close()
                                End If
                                cn.Open()
                                cmd.ExecuteNonQuery()
                                cn.Close()

                                cmd = New SqlCommand("insert into masttemp(company,shareholder,cert,cd,date_created,shares,locked,part_ind,tran_type,printed,xfer,cert_type,batch_ref) values ('" & dsx.Tables(0).Rows(i).Item("company").ToString & "'," & dsx.Tables(0).Rows(i).Item("shareholder").ToString & ",0,0,'" & Now.Date & "'," & CInt(dsx.Tables(0).Rows(i).Item("shares").ToString) & ",0,1,'" & dsbatxh.Tables(0).Rows(0).Item("Batch_Type").ToString & "',0,0,'N'," & txtBatchRef.Text & ")", cn)
                                If (cn.State = ConnectionState.Open) Then
                                    cn.Close()
                                End If
                                cn.Open()
                                cmd.ExecuteNonQuery()
                                cn.Close()
                            Next
                        End If
                    Else
                        Dim dsx As New DataSet
                        cmd = New SqlCommand("select * from Batched_Certs where company='" & cmbCOmpany.SelectedItem.Text & "' and batch_ref=" & txtBatchRef.Text & " and status=1", cn)
                        adp = New SqlDataAdapter(cmd)
                        adp.Fill(dsx, "Batched_Certs")

                        If (dsx.Tables(0).Rows.Count > 0) Then
                            Dim i As Integer
                            For i = 0 To dsx.Tables(0).Rows.Count - 1
                                cmd = New SqlCommand("insert into masttemp(company,shareholder,cert,cd,date_created,shares,locked,part_ind,tran_type,printed,xfer,cert_type,batch_ref) values ('" & dsx.Tables(0).Rows(i).Item("company").ToString & "'," & dsx.Tables(0).Rows(i).Item("shareholder").ToString & ",0,0,'" & Now.Date & "'," & CInt(dsx.Tables(0).Rows(i).Item("shares").ToString) & ",0,1,'" & dsbatxh.Tables(0).Rows(0).Item("Batch_Type").ToString & "',0,0,'N'," & txtBatchRef.Text & ")", cn)
                                If (cn.State = ConnectionState.Open) Then
                                    cn.Close()
                                End If
                                cn.Open()
                                cmd.ExecuteNonQuery()
                                cn.Close()

                            Next
                        End If
                    End If

                    msgbox("Batch Balanced")
                    ClearAll()
                    Response.Redirect("~\Capture\CaptureHome.aspx")
                End If

            Else

                If (CInt(txtTransfereeBatchShares.Text) > CInt(txtShares.Text)) Then
                    msgbox("Entered shares will exceed batch total")
                    Exit Sub
                End If

                If (CInt(txtTransfereeBatchShares.Text) < CInt(txtShares.Text)) Then

                    cmd = New SqlCommand("insert into BatchedReceiving (Batch_ref,Company,Shareholder,Shares,Batched_By,Status) values (" & txtBatchRef.Text & ",'" & cmbCOmpany.SelectedItem.Text & "'," & Label17.Text & "," & CInt(txtTransfereeBatchShares.Text) & ",'" & Session("Username").ToString & "',0)", cn)
                    If (cn.State = ConnectionState.Open) Then
                        cn.Close()
                    End If
                    cn.Open()
                    cmd.ExecuteNonQuery()
                    cn.Close()

                    msgbox("Record is added")
                    Label17.Text = ""
                    lstTransferee.Items.Clear()
                    txtTransfereeBatchShares.Text = ""
                    txtTransfereeSearch.Text = ""
                    GetReceivingAccounts()
                    txtTransfereeSearch.Focus()
                End If

                If (CInt(txtTransfereeBatchShares.Text) = CInt(txtShares.Text)) Then
                    cmd = New SqlCommand("insert into BatchedReceiving (Batch_ref,Company,Shareholder,Shares,Batched_By,Status) values (" & txtBatchRef.Text & ",'" & cmbCOmpany.SelectedItem.Text & "'," & Label17.Text & "," & CInt(txtTransfereeBatchShares.Text) & ",'" & Session("Username").ToString & "',0)", cn)
                    If (cn.State = ConnectionState.Open) Then
                        cn.Close()
                    End If
                    cn.Open()
                    cmd.ExecuteNonQuery()
                    cn.Close()

                    'msgbox("Batch Balanced")
                    cmd = New SqlCommand("update batch_head set BatchProcesslevel = 'P' where batch_ref=" & txtBatchRef.Text & " and company='" & cmbCOmpany.SelectedItem.Text & "'", cn)
                    If (cn.State = ConnectionState.Open) Then
                        cn.Close()
                    End If
                    cn.Open()
                    cmd.ExecuteNonQuery()
                    cn.Close()

                    cmd = New SqlCommand("update batchedReceiving set status= 1 where batch_ref=" & txtBatchRef.Text & " and company='" & cmbCOmpany.SelectedItem.Text & "'", cn)
                    If (cn.State = ConnectionState.Open) Then
                        cn.Close()
                    End If
                    cn.Open()
                    cmd.ExecuteNonQuery()
                    cn.Close()

                    cmd = New SqlCommand("update batched_certs set status= 1 where batch_ref=" & txtBatchRef.Text & " and company='" & cmbCOmpany.SelectedItem.Text & "'", cn)
                    If (cn.State = ConnectionState.Open) Then
                        cn.Close()
                    End If
                    cn.Open()
                    cmd.ExecuteNonQuery()
                    cn.Close()


                    'Saving Mast temp for update

                    Dim dsbatxh As New DataSet
                    cmd = New SqlCommand("select * from batch_head where batch_ref=" & txtBatchRef.Text & " and company='" & cmbCOmpany.SelectedItem.Text & "'", cn)
                    adp = New SqlDataAdapter(cmd)
                    adp.Fill(dsbatxh, "batch_head")


                    If (cmbBatchType.SelectedItem.Text = "XFER") Then 'if its a transfer
                        Dim dsx As New DataSet
                        cmd = New SqlCommand("select * from Batched_Certs where company='" & cmbCOmpany.SelectedItem.Text & "' and batch_ref=" & txtBatchRef.Text & " and status=1", cn)
                        adp = New SqlDataAdapter(cmd)
                        adp.Fill(dsx, "Batched_Certs")

                        If (dsx.Tables(0).Rows.Count > 0) Then
                            Dim i As Integer
                            For i = 0 To dsx.Tables(0).Rows.Count - 1
                                cmd = New SqlCommand("insert into masttemp(company,shareholder,cert,cd,date_created,shares,locked,part_ind,tran_type,printed,xfer,cert_type,batch_ref) values ('" & dsx.Tables(0).Rows(i).Item("company").ToString & "'," & dsx.Tables(0).Rows(i).Item("shareholder").ToString & "," & dsx.Tables(0).Rows(i).Item("cert").ToString & ",0,'" & Now.Date & "'," & CInt(dsx.Tables(0).Rows(i).Item("shares").ToString) * -1 & ",0,1,'" & dsbatxh.Tables(0).Rows(0).Item("Batch_Type").ToString & "',0," & dsbatxh.Tables(0).Rows(0).Item("xfer").ToString & ",'N'," & txtBatchRef.Text & ")", cn)
                                If (cn.State = ConnectionState.Open) Then
                                    cn.Close()
                                End If
                                cn.Open()
                                cmd.ExecuteNonQuery()
                                cn.Close()
                            Next
                        End If

                        Dim dsxi As New DataSet
                        cmd = New SqlCommand("select * from BatchedReceiving where company='" & cmbCOmpany.SelectedItem.Text & "' and batch_ref=" & txtBatchRef.Text & " and status=1", cn)
                        adp = New SqlDataAdapter(cmd)
                        adp.Fill(dsxi, "BatchedReceiving")

                        If (dsxi.Tables(0).Rows.Count > 0) Then
                            Dim x As Integer
                            For x = 0 To dsxi.Tables(0).Rows.Count - 1
                                cmd = New SqlCommand("insert into masttemp(company,shareholder,cert,cd,date_created,shares,locked,part_ind,tran_type,printed,xfer,cert_type,batch_ref) values ('" & dsxi.Tables(0).Rows(x).Item("company").ToString & "'," & dsxi.Tables(0).Rows(x).Item("shareholder").ToString & ",0,0,'" & Now.Date & "'," & dsxi.Tables(0).Rows(x).Item("shares").ToString & ",0,1,'" & dsbatxh.Tables(0).Rows(0).Item("Batch_Type").ToString & "',0," & dsbatxh.Tables(0).Rows(0).Item("xfer").ToString & ",'N'," & txtBatchRef.Text & ")", cn)
                                If (cn.State = ConnectionState.Open) Then
                                    cn.Close()
                                End If
                                cn.Open()
                                cmd.ExecuteNonQuery()
                                cn.Close()
                            Next
                        End If

                    ElseIf (cmbBatchType.SelectedItem.Text = "INDEM") Then 'INDEM TRANSACTION TYPE

                        Dim dsx As New DataSet
                        cmd = New SqlCommand("select * from Batched_Certs where company='" & cmbCOmpany.SelectedItem.Text & "' and batch_ref=" & txtBatchRef.Text & " and status=1", cn)
                        adp = New SqlDataAdapter(cmd)
                        adp.Fill(dsx, "Batched_Certs")

                        If (dsx.Tables(0).Rows.Count > 0) Then
                            Dim i As Integer
                            For i = 0 To dsx.Tables(0).Rows.Count - 1
                                cmd = New SqlCommand("insert into masttemp(company,shareholder,cert,cd,date_created,shares,locked,part_ind,tran_type,printed,xfer,cert_type,batch_ref) values ('" & dsx.Tables(0).Rows(i).Item("company").ToString & "'," & dsx.Tables(0).Rows(i).Item("shareholder").ToString & "," & dsx.Tables(0).Rows(i).Item("cert").ToString & ",0,'" & Now.Date & "'," & CInt(dsx.Tables(0).Rows(i).Item("shares").ToString) * -1 & ",0,1,'" & dsbatxh.Tables(0).Rows(0).Item("Batch_Type").ToString & "',0," & dsbatxh.Tables(0).Rows(0).Item("xfer").ToString & ",'N'," & txtBatchRef.Text & ")", cn)
                                If (cn.State = ConnectionState.Open) Then
                                    cn.Close()
                                End If
                                cn.Open()
                                cmd.ExecuteNonQuery()
                                cn.Close()

                                cmd = New SqlCommand("insert into masttemp(company,shareholder,cert,cd,date_created,shares,locked,part_ind,tran_type,printed,xfer,cert_type,batch_ref) values ('" & dsx.Tables(0).Rows(i).Item("company").ToString & "'," & dsx.Tables(0).Rows(i).Item("shareholder").ToString & ",0,0,'" & Now.Date & "'," & CInt(dsx.Tables(0).Rows(i).Item("shares").ToString) & ",0,1,'" & dsbatxh.Tables(0).Rows(0).Item("Batch_Type").ToString & "',0," & dsbatxh.Tables(0).Rows(0).Item("xfer").ToString & ",'N'," & txtBatchRef.Text & ")", cn)
                                If (cn.State = ConnectionState.Open) Then
                                    cn.Close()
                                End If
                                cn.Open()
                                cmd.ExecuteNonQuery()
                                cn.Close()
                            Next
                        End If

                    Else
                        Dim dsx As New DataSet
                        cmd = New SqlCommand("select * from Batched_Certs where company='" & cmbCOmpany.SelectedItem.Text & "' and batch_ref=" & txtBatchRef.Text & " and status=1", cn)
                        adp = New SqlDataAdapter(cmd)
                        adp.Fill(dsx, "Batched_Certs")

                        If (dsx.Tables(0).Rows.Count > 0) Then
                            Dim i As Integer
                            For i = 0 To dsx.Tables(0).Rows.Count - 1
                                'cmd = New SqlCommand("insert into masttemp(company,shareholder,cert,cd,date_created,shares,locked,part_ind,tran_type,printed,xfer,cert_type,batch_ref) values ('" & dsx.Tables(0).Rows(i).Item("company").ToString & "'," & dsx.Tables(0).Rows(i).Item("shareholder").ToString & "," & dsx.Tables(0).Rows(i).Item("cert").ToString & ",0,'" & Now.Date & "'," & CInt(dsx.Tables(0).Rows(i).Item("shares").ToString) * -1 & ",0,1,'" & dsbatxh.Tables(0).Rows(0).Item("Batch_Type").ToString & "',0," & dsbatxh.Tables(0).Rows(0).Item("xfer").ToString & ",'N'," & txtBatchRef.Text & ")", cn)
                                'If (cn.State = ConnectionState.Open) Then
                                '    cn.Close()
                                'End If
                                'cn.Open()
                                'cmd.ExecuteNonQuery()
                                'cn.Close()

                                cmd = New SqlCommand("insert into masttemp(company,shareholder,cert,cd,date_created,shares,locked,part_ind,tran_type,printed,xfer,cert_type,batch_ref) values ('" & dsx.Tables(0).Rows(i).Item("company").ToString & "'," & dsx.Tables(0).Rows(i).Item("shareholder").ToString & ",0,0,'" & Now.Date & "'," & CInt(dsx.Tables(0).Rows(i).Item("shares").ToString) & ",0,1,'" & dsbatxh.Tables(0).Rows(0).Item("Batch_Type").ToString & "',0," & dsbatxh.Tables(0).Rows(0).Item("xfer").ToString & ",'N'," & txtBatchRef.Text & ")", cn)
                                If (cn.State = ConnectionState.Open) Then
                                    cn.Close()
                                End If
                                cn.Open()
                                cmd.ExecuteNonQuery()
                                cn.Close()
                            Next
                        End If

                    End If

                    msgbox("Batch Balanced")
                    ClearAll()

                End If

            End If

        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub GetReceivingAccounts()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select Batch_ref as [Batch Ref], Company as [Company], shareholder as [Shareholder], shares as [Shares] from BatchedReceiving where batch_ref=" & txtBatchRef.Text & " and company='" & cmbCOmpany.SelectedItem.Text & "'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "BatchedReceiving")
            If (ds.Tables(0).Rows.Count > 0) Then
                'Button5.Visible = True
                grdTransshares.Visible = True
                grdTransshares.DataSource = ds.Tables(0)
                grdTransshares.DataBind()
            Else
                Button5.Visible = False
                grdTransshares.DataSource = Nothing
                grdTransshares.DataBind()
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Protected Sub Button5_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button5.Click
        Dim i, j As Integer
        Dim dssharescert, dscertvari As New DataSet
        j = grdTransshares.Rows.Count
        For i = 0 To j - 1
            j = grdTransshares.Rows.Count
            Dim chk As CheckBox
            chk = CType(grdTransshares.Rows(i).Cells(0).FindControl("checkbox1"), CheckBox)
            If chk.Checked = True Then
                cmd = New SqlCommand("delete from BatchedReceiving where batch_ref=" & grdTransshares.Rows(i).Cells(1).Text & " and company='" & grdTransshares.Rows(i).Cells(2).Text & "' and shareholder=" & grdTransshares.Rows(i).Cells(3).Text & " ", cn)
                cn.Open()
                cmd.ExecuteNonQuery()
                cn.Close()
            End If
        Next
        GetReceivingAccounts()
    End Sub
    Protected Sub txtTransfereeSearch_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtTransfereeSearch.TextChanged
        Try
            If (txtTransfereeSearch.Text <> "") Then
                Dim ds As New DataSet
                cmd = New SqlCommand("select surname+' '+forenames+' '+convert(varchar,shareholder) as holder, shareholder from names where surname like '" & txtTransfereeSearch.Text & "%'", cn)
                adp = New SqlDataAdapter(cmd)
                adp.Fill(ds, "names")
                If (ds.Tables(0).Rows.Count > 0) Then
                    lstTransferee.DataSource = ds.Tables(0)
                    lstTransferee.DataValueField = "holder"
                    lstTransferee.DataBind()
                Else
                    lstTransferee.DataSource = Nothing
                    lstTransferee.DataBind()
                End If
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Protected Sub txtBatchSearch_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtBatchSearch.TextChanged
        If (txtBatchSearch.Text <> "") Then
            getSearchedBatch()
        End If
    End Sub
    Protected Sub lstNamesSelect_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstNamesSelect.SelectedIndexChanged
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select shareholder from AccountsMain where surname+' '+forenames+' '+convert(varchar,shareholder) = '" & lstNamesSelect.SelectedItem.Text & "'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "AccountsMain")
            If (ds.Tables(0).Rows.Count > 0) Then
                Label30.Text = ds.Tables(0).Rows(0).Item("shareholder").ToString
            Else
                Label30.Text = ""
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Protected Sub txtsubcert_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtsubcert.TextChanged
        Try
            If (txtsubcert.Text <> "") Then

                If (IsNumeric(txtsubcert.Text)) Then

                    If (cmbBatchType.SelectedItem.Text = "SUB XFER") Then

                        Dim ros As New DataSet
                        cmd = New SqlCommand("select * from sub_mast where company='" & cmbCOmpany.SelectedItem.Text & "' and cert =" & txtsubcert.Text & "", cn)
                        adp = New SqlDataAdapter(cmd)
                        adp.Fill(ros, "sub_mast")
                        If (ros.Tables(0).Rows.Count > 0) Then
                            Dim ds As New DataSet
                            cmd = New SqlCommand("select sum(shares) as shares from sub_mast where company='" & cmbCOmpany.SelectedItem.Text & "' and cert=" & txtsubcert.Text & "", cn)
                            adp = New SqlDataAdapter(cmd)
                            adp.Fill(ds, "sub_mast")
                            If (ds.Tables(0).Rows.Count > 0) Then
                                btnAdd.Enabled = True
                                If (CInt(ds.Tables(0).Rows(0).Item("shares").ToString) <> CInt(txtShares.Text)) Then
                                    Label36.Text = "Entered certificate has " & ds.Tables(0).Rows(0).Item("shares").ToString & " shares."
                                    Label36.ForeColor = Drawing.Color.Red
                                    'msgbox("test")
                                Else
                                    'msgbox("test1")
                                    Label36.Text = "Balanced"
                                    Label36.ForeColor = Drawing.Color.Green
                                End If
                            Else
                                Label36.Visible = True
                                Label36.Text = "Invalid Certificate"
                                'msgbox("Invalid certificate")
                                Exit Sub
                                btnAdd.Enabled = False
                            End If
                        Else
                            Label36.Visible = True
                            Label36.Text = "Invalid Certificate"
                        End If
                    Else
                        Dim ros As New DataSet
                        cmd = New SqlCommand("select * from mast where company='" & cmbCOmpany.SelectedItem.Text & "' and cert =" & txtsubcert.Text & "", cn)
                        adp = New SqlDataAdapter(cmd)
                        adp.Fill(ros, "mast")
                        If (ros.Tables(0).Rows.Count > 0) Then
                            Dim ds As New DataSet
                            cmd = New SqlCommand("select sum(shares) as shares from mast where company='" & cmbCOmpany.SelectedItem.Text & "' and cert=" & txtsubcert.Text & "", cn)
                            adp = New SqlDataAdapter(cmd)
                            adp.Fill(ds, "mast")
                            If (ds.Tables(0).Rows.Count > 0) Then
                                btnAdd.Enabled = True
                                If (CInt(ds.Tables(0).Rows(0).Item("shares").ToString) <> CInt(txtShares.Text)) Then
                                    Label36.Text = "Entered certificate has " & ds.Tables(0).Rows(0).Item("shares").ToString & " shares."
                                    Label36.ForeColor = Drawing.Color.Red
                                Else
                                    Label36.Text = "Balanced"
                                    Label36.ForeColor = Drawing.Color.Green
                                End If
                            Else
                                Label36.Text = "Invalid Certificate"
                                'msgbox("Invalid certificate")
                                Exit Sub
                                btnAdd.Enabled = False
                            End If
                        Else
                            Label36.Text = "Invalid Certificate"
                        End If
                    End If



                Else
                    msgbox("Enter a numeric value for certificate number")
                End If
            Else
                Label36.Text = ""
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Protected Sub linkAuthorize_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            '            If (cmbBatchType.SelectedItem.Text = "CD") Then

            '            Else

            Dim id As String = CType(sender, LinkButton).CommandArgument
            Dim sql As String = " delete from batched_certs where cert=" & id & ""
            cn.ConnectionString = cnstr
            cmd = New SqlCommand(sql, cn)
            If (cn.State = ConnectionState.Open) Then
                cn.Close()
            End If
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()
            'End If

            msgbox("Record Removed")
        Catch ex As Exception
            msgbox(ex.Message)
        Finally
            cn.Close()
        End Try
        getBatchedPrimary()
    End Sub
    Protected Sub linkAuthorizeReceive_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            If (cmbBatchType.SelectedItem.Text = "CD") Then
                Dim id As String = CType(sender, LinkButton).CommandArgument
                Dim sql As String = " delete from tmpCDs where shareholder=" & id & ""

                cn.ConnectionString = cnstr
                cmd = New SqlCommand(sql, cn)
                If (cn.State = ConnectionState.Open) Then
                    cn.Close()
                End If
                cn.Open()
                cmd.ExecuteNonQuery()
                cn.Close()
                msgbox("Removed")
            Else
                Dim id As String = CType(sender, LinkButton).CommandArgument
                Dim sql As String = " delete from BatchedReceiving where shareholder=" & id & ""
                cn.ConnectionString = cnstr
                cmd = New SqlCommand(sql, cn)
                If (cn.State = ConnectionState.Open) Then
                    cn.Close()
                End If
                cn.Open()
                cmd.ExecuteNonQuery()
                cn.Close()
                msgbox("Record Removed")
            End If

        Catch ex As Exception
            msgbox(ex.Message)
        Finally
            cn.Close()
        End Try
        GetReceivingAccounts()
    End Sub
    Protected Sub btnTranssearch0_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnTranssearch0.Click
        Try
            If (cmbBatchType.SelectedItem.Text = "CD") Then
                If (rdCDs.Checked = True) Then
                    If (txtTransfereeHolderSearch.Text <> "" And IsNumeric(txtTransfereeHolderSearch.Text)) Then
                        If (CInt(txtTransfereeHolderSearch.Text) > CInt(Replace(txtToBatchShares.Text, ",", ""))) Then
                            msgbox("Cannot create a cd with more shares than the original Certificate")
                            Exit Sub
                        Else
                            'msgbox(grdAddedCertificate.Rows(0).Cells(3).Text)
                            Dim dscd As New DataSet
                            Dim cdcount As Integer = 0
                            cmd = New SqlCommand("select * from tmpCDs where batch_ref=" & txtBatchRef.Text & " and company='" & cmbCOmpany.SelectedItem.Text & "' and trantype='CD' and cert<> 0", cn)
                            adp = New SqlDataAdapter(cmd)
                            adp.Fill(dscd, "tmpCDs")
                            If (dscd.Tables(0).Rows.Count > 0) Then
                                cdcount = dscd.Tables(0).Rows.Count + 1
                            Else
                                cdcount = 1
                            End If
                            cmd = New SqlCommand("insert into tmpCDs (shareholder,Cert,CD,TranType,Shares,Company,Batch_Ref,date_created,Status) values (" & grdAddedCertificate.Rows(0).Cells(1).Text & "," & grdAddedCertificate.Rows(0).Cells(3).Text & "," & cdcount & ",'CD'," & CInt(txtTransfereeHolderSearch.Text) & ",'" & cmbCOmpany.SelectedItem.Text & "'," & txtBatchRef.Text & ",'" & Now.Date & "',0)", cn)
                            If (cn.State = ConnectionState.Open) Then
                                cn.Close()
                            End If
                            cn.Open()
                            cmd.ExecuteNonQuery()
                            cn.Close()

                            'Counting Batched Shares
                            Dim dscnt As New DataSet
                            cmd = New SqlCommand("select sum(shares) as shares from tmpCDs where company='" & cmbCOmpany.SelectedItem.Text & "' and batch_ref=" & txtBatchRef.Text & "", cn)
                            adp = New SqlDataAdapter(cmd)
                            adp.Fill(dscnt, "tmpCDs")

                            If (CInt(dscnt.Tables(0).Rows(0).Item("shares").ToString) = grdAddedCertificate.Rows(0).Cells(5).Text) Then
                                cmd = New SqlCommand("update batched_certs set status = 1 where company='" & cmbCOmpany.SelectedItem.Text & "' and batch_ref=" & txtBatchRef.Text & " and cert=" & grdAddedCertificate.Rows(0).Cells(3).Text & "", cn)
                                If (cn.State = ConnectionState.Open) Then
                                    cn.Close()
                                End If
                                cn.Open()
                                cmd.ExecuteNonQuery()
                                cn.Close()

                                cmd = New SqlCommand("update batch_head set BatchProcessLevel='P' where company='" & cmbCOmpany.SelectedItem.Text & "' and batch_ref=" & txtBatchRef.Text & "", cn)
                                If (cn.State = ConnectionState.Open) Then
                                    cn.Close()
                                End If
                                cn.Open()
                                cmd.ExecuteNonQuery()
                                cn.Close()

                                cmd = New SqlCommand("insert into masttemp (company,shareholder,cert,cd,date_created,shares,locked,part_ind,tran_type,printed,xfer,cert_type,batch_ref) values ('" & cmbCOmpany.SelectedItem.Text & "'," & grdAddedCertificate.Rows(0).Cells(1).Text & "," & grdAddedCertificate.Rows(0).Cells(3).Text & "," & grdAddedCertificate.Rows(0).Cells(4).Text & ",'" & Now.Date & "'," & CInt(grdAddedCertificate.Rows(0).Cells(5).Text) * -1 & ",0,1,'CD',1,0,'N'," & txtBatchRef.Text & ")", cn)
                                If (cn.State = ConnectionState.Open) Then
                                    cn.Close()
                                End If
                                cn.Open()
                                cmd.ExecuteNonQuery()
                                cn.Close()

                                Dim ros As New DataSet
                                cmd = New SqlCommand("select * from tmpCDs where company='" & cmbCOmpany.SelectedItem.Text & "' and batch_ref=" & txtBatchRef.Text & "", cn)
                                adp = New SqlDataAdapter(cmd)
                                adp.Fill(ros, "tmpCDs")
                                If (ros.Tables(0).Rows.Count > 0) Then
                                    Dim f As Integer
                                    For f = 0 To ros.Tables(0).Rows.Count - 1
                                        cmd = New SqlCommand("insert into masttemp (company,shareholder,cert,cd,date_created,shares,locked,part_ind,tran_type,printed,xfer,cert_type,batch_ref) values ('" & cmbCOmpany.SelectedItem.Text & "'," & ros.Tables(0).Rows(f).Item("shareholder").ToString & "," & ros.Tables(0).Rows(f).Item("Cert").ToString & "," & ros.Tables(0).Rows(f).Item("Cd").ToString & ",'" & Now.Date & "'," & CInt(ros.Tables(0).Rows(f).Item("shares").ToString) & ",0,1,'" & ros.Tables(0).Rows(f).Item("tranType").ToString & "',1,0,'N'," & txtBatchRef.Text & ")", cn)
                                        If (cn.State = ConnectionState.Open) Then
                                            cn.Close()
                                        End If
                                        cn.Open()
                                        cmd.ExecuteNonQuery()
                                        cn.Close()
                                    Next
                                    msgbox("Batch Balanced")
                                End If
                                Refresh()
                            Else
                                Dim jam As New DataSet
                                cmd = New SqlCommand("select sum(shares) as shares from tmpCDs where company='" & cmbCOmpany.SelectedItem.Text & "' and batch_ref=" & txtBatchRef.Text & "", cn)
                                adp = New SqlDataAdapter(cmd)
                                adp.Fill(jam, "tmpCDs")

                                Dim Newshares As Integer = 0
                                Newshares = (CInt(grdAddedCertificate.Rows(0).Cells(5).Text) - CInt(jam.Tables(0).Rows(0).Item("shares").ToString))
                                'msgbox(CInt(jam.Tables(0).Rows(0).Item("shares").ToString))
                                'msgbox(CInt(txtToBatchShares.Text))
                                txtToBatchShares.Text = Newshares

                                Dim Ts As New DataSet
                                cmd = New SqlCommand("select shareholder as [Shareholder], cert as [Certificate],cd as [CD], tranType as [Trans], shares as [Shares],Batch_ref as [Batch] from tmpCDs where company='" & cmbCOmpany.SelectedItem.Text & "' and batch_ref=" & txtBatchRef.Text & "", cn)
                                adp = New SqlDataAdapter(cmd)
                                adp.Fill(Ts, "tmpCDs")
                                If (Ts.Tables(0).Rows.Count > 0) Then
                                    grdTransshares.Visible = True
                                    grdTransshares.DataSource = Ts.Tables(0)
                                    grdTransshares.DataBind()
                                    txtTransfereeHolderSearch.Text = ""
                                Else
                                    grdTransshares.DataSource = Nothing
                                    grdTransshares.DataBind()
                                End If


                            End If

                        End If


                    Else
                        msgbox("Enter a valid number of shares")
                    End If


                End If
                If (rdBalance.Checked = True) Then
                    If (txtTransfereeHolderSearch.Text <> "" And IsNumeric(txtTransfereeHolderSearch.Text)) Then
                        If (CInt(txtTransfereeHolderSearch.Text) > CInt(Replace(txtToBatchShares.Text, ",", ""))) Then
                            msgbox("Cannot create a cd with more shares than the original Certificate")
                            Exit Sub
                        Else
                            'msgbox(grdAddedCertificate.Rows(0).Cells(3).Text)
                            Dim dscd As New DataSet
                            Dim cdcount As Integer = 0
                            cmd = New SqlCommand("select * from tmpCDs where batch_ref=" & txtBatchRef.Text & " and company='" & cmbCOmpany.SelectedItem.Text & "' and trantype='CD' and cert<> 0", cn)
                            adp = New SqlDataAdapter(cmd)
                            adp.Fill(dscd, "tmpCDs")
                            If (dscd.Tables(0).Rows.Count > 0) Then
                                cdcount = dscd.Tables(0).Rows.Count + 1
                            Else
                                cdcount = 1
                            End If
                            cmd = New SqlCommand("insert into tmpCDs (shareholder,Cert,CD,TranType,Shares,Company,Batch_Ref,date_created,Status) values (" & grdAddedCertificate.Rows(0).Cells(1).Text & ",0,0,'CD'," & CInt(txtTransfereeHolderSearch.Text) & ",'" & cmbCOmpany.SelectedItem.Text & "'," & txtBatchRef.Text & ",'" & Now.Date & "',0)", cn)
                            If (cn.State = ConnectionState.Open) Then
                                cn.Close()
                            End If
                            cn.Open()
                            cmd.ExecuteNonQuery()
                            cn.Close()

                            'Counting Batched Shares
                            Dim dscnt As New DataSet
                            cmd = New SqlCommand("select sum(shares) as shares from tmpCDs where company='" & cmbCOmpany.SelectedItem.Text & "' and batch_ref=" & txtBatchRef.Text & "", cn)
                            adp = New SqlDataAdapter(cmd)
                            adp.Fill(dscnt, "tmpCDs")

                            If (CInt(dscnt.Tables(0).Rows(0).Item("shares").ToString) = grdAddedCertificate.Rows(0).Cells(5).Text) Then
                                cmd = New SqlCommand("update batched_certs set status = 1 where company='" & cmbCOmpany.SelectedItem.Text & "' and batch_ref=" & txtBatchRef.Text & " and cert=" & grdAddedCertificate.Rows(0).Cells(3).Text & "", cn)
                                If (cn.State = ConnectionState.Open) Then
                                    cn.Close()
                                End If
                                cn.Open()
                                cmd.ExecuteNonQuery()
                                cn.Close()

                                cmd = New SqlCommand("update batch_head set BatchProcessLevel='P' where company='" & cmbCOmpany.SelectedItem.Text & "' and batch_ref=" & txtBatchRef.Text & "", cn)
                                If (cn.State = ConnectionState.Open) Then
                                    cn.Close()
                                End If
                                cn.Open()
                                cmd.ExecuteNonQuery()
                                cn.Close()

                                cmd = New SqlCommand("insert into masttemp (company,shareholder,cert,cd,date_created,shares,locked,part_ind,tran_type,printed,xfer,cert_type,batch_ref) values ('" & cmbCOmpany.SelectedItem.Text & "'," & grdAddedCertificate.Rows(0).Cells(1).Text & "," & grdAddedCertificate.Rows(0).Cells(3).Text & "," & grdAddedCertificate.Rows(0).Cells(4).Text & ",'" & Now.Date & "'," & CInt(grdAddedCertificate.Rows(0).Cells(5).Text) * -1 & ",0,1,'CD',1,0,'N'," & txtBatchRef.Text & ")", cn)
                                If (cn.State = ConnectionState.Open) Then
                                    cn.Close()
                                End If
                                cn.Open()
                                cmd.ExecuteNonQuery()
                                cn.Close()

                                Dim ros As New DataSet
                                cmd = New SqlCommand("select * from tmpCDs where company='" & cmbCOmpany.SelectedItem.Text & "' and batch_ref=" & txtBatchRef.Text & "", cn)
                                adp = New SqlDataAdapter(cmd)
                                adp.Fill(ros, "tmpCDs")
                                If (ros.Tables(0).Rows.Count > 0) Then
                                    Dim f As Integer
                                    For f = 0 To ros.Tables(0).Rows.Count - 1
                                        cmd = New SqlCommand("insert into masttemp (company,shareholder,cert,cd,date_created,shares,locked,part_ind,tran_type,printed,xfer,cert_type,batch_ref) values ('" & cmbCOmpany.SelectedItem.Text & "'," & ros.Tables(0).Rows(f).Item("shareholder").ToString & "," & ros.Tables(0).Rows(f).Item("Cert").ToString & "," & ros.Tables(0).Rows(f).Item("Cd").ToString & ",'" & Now.Date & "'," & CInt(ros.Tables(0).Rows(f).Item("shares").ToString) & ",0,1,'" & ros.Tables(0).Rows(f).Item("tranType").ToString & "',1,0,'N'," & txtBatchRef.Text & ")", cn)
                                        If (cn.State = ConnectionState.Open) Then
                                            cn.Close()
                                        End If
                                        cn.Open()
                                        cmd.ExecuteNonQuery()
                                        cn.Close()
                                    Next
                                    msgbox("Batch Balanced")
                                End If
                                Refresh()
                            Else
                                Dim jam As New DataSet
                                cmd = New SqlCommand("select sum(shares) as shares from tmpCDs where company='" & cmbCOmpany.SelectedItem.Text & "' and batch_ref=" & txtBatchRef.Text & "", cn)
                                adp = New SqlDataAdapter(cmd)
                                adp.Fill(jam, "tmpCDs")

                                Dim Newshares As Integer = 0
                                Newshares = (CInt(grdAddedCertificate.Rows(0).Cells(5).Text) - CInt(jam.Tables(0).Rows(0).Item("shares").ToString))
                                'msgbox(CInt(jam.Tables(0).Rows(0).Item("shares").ToString))
                                'msgbox(CInt(txtToBatchShares.Text))
                                txtToBatchShares.Text = Newshares

                                Dim Ts As New DataSet
                                cmd = New SqlCommand("select shareholder as [Shareholder], cert as [Certificate],cd as [CD], tranType as [Trans], shares as [Shares],Batch_ref as [Batch] from tmpCDs where company='" & cmbCOmpany.SelectedItem.Text & "' and batch_ref=" & txtBatchRef.Text & "", cn)
                                adp = New SqlDataAdapter(cmd)
                                adp.Fill(Ts, "tmpCDs")
                                If (Ts.Tables(0).Rows.Count > 0) Then
                                    grdTransshares.Visible = True
                                    grdTransshares.DataSource = Ts.Tables(0)
                                    grdTransshares.DataBind()
                                    txtTransfereeHolderSearch.Text = ""
                                Else
                                    grdTransshares.DataSource = Nothing
                                    grdTransshares.DataBind()
                                End If


                            End If

                        End If


                    Else
                        msgbox("Enter a valid number of shares")
                    End If

                End If
                Exit Sub
            Else
                Dim ds As New DataSet
                cmd = New SqlCommand("select shareholder from AccountsMain where shareholder=" & txtTransfereeHolderSearch.Text & "", cn)
                adp = New SqlDataAdapter(cmd)
                adp.Fill(ds, "Accountsmain")
                If (ds.Tables(0).Rows.Count > 0) Then
                    Label17.Text = ds.Tables(0).Rows(0).Item("shareholder").ToString
                    txtTransfereeBatchShares.Focus()
                Else
                    Label17.Text = ""
                End If
            End If

        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Protected Sub btnBalance_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBalance.Click
        Try
            CreatingBalance()
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub CreatingBalance()
        Try
            Dim CSDAcc As Integer = 0
            Dim Balanceshares As Integer = 0

            If (cmbBatchType.SelectedItem.Text = "WITHDRAW") Then
                Dim dsi As New DataSet
                cmd = New SqlCommand("select * from BatchedReceiving where company='" & Trim(cmbCOmpany.SelectedItem.Text) & "' and batch_ref=" & txtBatchRef.Text & "", cn)
                adp = New SqlDataAdapter(cmd)
                adp.Fill(dsi, "BatchedReceiving")
                If (dsi.Tables(0).Rows.Count > 0) Then
                    cmd = New SqlCommand("select sum(shares) as shares from batchedReceiving where company='" & Trim(cmbCOmpany.SelectedItem.Text) & "' and batch_ref=" & txtBatchRef.Text & "", cn)
                    Dim ds As New DataSet
                    adp = New SqlDataAdapter(cmd)
                    adp.Fill(ds, "BatchedReceiving")

                    If ((CInt(ds.Tables(0).Rows(0).Item("shares").ToString)) < CInt(txtShares.Text)) Then
                        Dim dsbatxh As New DataSet
                        cmd = New SqlCommand("select * from batch_head where batch_ref=" & txtBatchRef.Text & " and company='" & cmbCOmpany.SelectedItem.Text & "'", cn)
                        adp = New SqlDataAdapter(cmd)
                        adp.Fill(dsbatxh, "batch_head")

                        Dim rex As New DataSet
                        cmd = New SqlCommand("select cds_ac_no from para_company where company='" & Trim(cmbCOmpany.SelectedItem.Text) & "'", cn)
                        adp = New SqlDataAdapter(cmd)
                        adp.Fill(rex, "para_company")
                        CSDAcc = CInt(rex.Tables(0).Rows(0).Item("cds_ac_no").ToString)
                        Balanceshares = CInt(txtShares.Text) - CInt(ds.Tables(0).Rows(0).Item("shares").ToString)

                        cmd = New SqlCommand("insert into BatchedReceiving (Batch_ref,Company,Shareholder,Shares,Batched_By,Status) values (" & txtBatchRef.Text & ",'" & cmbCOmpany.SelectedItem.Text & "'," & CSDAcc & "," & CInt(Balanceshares) & ",'" & Session("Username").ToString & "',0)", cn)
                        If (cn.State = ConnectionState.Open) Then
                            cn.Close()
                        End If
                        cn.Open()
                        cmd.ExecuteNonQuery()
                        cn.Close()


                        cmd = New SqlCommand("update BatchedReceiving set status = 1 where company='" & cmbCOmpany.SelectedItem.Text & "' and batch_ref=" & txtBatchRef.Text & "", cn)
                        If (cn.State = ConnectionState.Open) Then
                            cn.Close()
                        End If
                        cn.Open()
                        cmd.ExecuteNonQuery()
                        cn.Close()

                        Dim dsx As New DataSet
                        cmd = New SqlCommand("select * from Batched_Certs where company='" & cmbCOmpany.SelectedItem.Text & "' and batch_ref=" & txtBatchRef.Text & " and status=1", cn)
                        adp = New SqlDataAdapter(cmd)
                        adp.Fill(dsx, "Batched_Certs")

                        If (dsx.Tables(0).Rows.Count > 0) Then
                            Dim i As Integer
                            For i = 0 To dsx.Tables(0).Rows.Count - 1
                                cmd = New SqlCommand("insert into masttemp(company,shareholder,cert,cd,date_created,shares,locked,part_ind,tran_type,printed,xfer,cert_type,batch_ref) values ('" & dsx.Tables(0).Rows(i).Item("company").ToString & "'," & dsx.Tables(0).Rows(i).Item("shareholder").ToString & "," & dsx.Tables(0).Rows(i).Item("cert").ToString & ",0,'" & Now.Date & "'," & CInt(dsx.Tables(0).Rows(i).Item("shares").ToString) * -1 & ",0,1,'" & dsbatxh.Tables(0).Rows(0).Item("Batch_Type").ToString & "',0," & dsbatxh.Tables(0).Rows(0).Item("xfer").ToString & ",'N'," & txtBatchRef.Text & ")", cn)
                                If (cn.State = ConnectionState.Open) Then
                                    cn.Close()
                                End If
                                cn.Open()
                                cmd.ExecuteNonQuery()
                                cn.Close()
                            Next
                        End If

                        Dim dsxi As New DataSet
                        cmd = New SqlCommand("select * from BatchedReceiving where company='" & cmbCOmpany.SelectedItem.Text & "' and batch_ref=" & txtBatchRef.Text & " and status=1", cn)
                        adp = New SqlDataAdapter(cmd)
                        adp.Fill(dsxi, "BatchedReceiving")

                        If (dsxi.Tables(0).Rows.Count > 0) Then
                            Dim x As Integer
                            For x = 0 To dsxi.Tables(0).Rows.Count - 1
                                If (dsxi.Tables(0).Rows(x).Item("shareholder").ToString = CSDAcc) Then
                                    cmd = New SqlCommand("insert into masttemp(company,shareholder,cert,cd,date_created,shares,locked,part_ind,tran_type,printed,xfer,cert_type,batch_ref) values ('" & dsxi.Tables(0).Rows(x).Item("company").ToString & "'," & dsxi.Tables(0).Rows(x).Item("shareholder").ToString & ",0,0,'" & Now.Date & "'," & dsxi.Tables(0).Rows(x).Item("shares").ToString & ",0,1,'BALANCE',1," & dsbatxh.Tables(0).Rows(0).Item("xfer").ToString & ",'N'," & txtBatchRef.Text & ")", cn)
                                    If (cn.State = ConnectionState.Open) Then
                                        cn.Close()
                                    End If
                                    cn.Open()
                                    cmd.ExecuteNonQuery()
                                    cn.Close()
                                Else
                                    cmd = New SqlCommand("insert into masttemp(company,shareholder,cert,cd,date_created,shares,locked,part_ind,tran_type,printed,xfer,cert_type,batch_ref) values ('" & dsxi.Tables(0).Rows(x).Item("company").ToString & "'," & dsxi.Tables(0).Rows(x).Item("shareholder").ToString & ",0,0,'" & Now.Date & "'," & dsxi.Tables(0).Rows(x).Item("shares").ToString & ",0,1,'WITHDRAW',0," & dsbatxh.Tables(0).Rows(0).Item("xfer").ToString & ",'N'," & txtBatchRef.Text & ")", cn)
                                    If (cn.State = ConnectionState.Open) Then
                                        cn.Close()
                                    End If
                                    cn.Open()
                                    cmd.ExecuteNonQuery()
                                    cn.Close()
                                End If

                            Next
                        End If



                    End If

                    cmd = New SqlCommand("update batch_head set BatchProcesslevel = 'P' where batch_ref=" & txtBatchRef.Text & " and company='" & cmbCOmpany.SelectedItem.Text & "'", cn)
                    If (cn.State = ConnectionState.Open) Then
                        cn.Close()
                    End If
                    cn.Open()
                    cmd.ExecuteNonQuery()
                    cn.Close()


                    msgbox("Batch Balanced")
                    ClearAll()

                End If

            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub



End Class
