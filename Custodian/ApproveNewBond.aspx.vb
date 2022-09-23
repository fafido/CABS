Imports DevExpress.Web.ASPxGridView

Partial Class ApproveNewBond

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
        '  Try
        Page.MaintainScrollPositionOnPostBack = True
        If (Not IsPostBack) Then
            checkSessionState()
            loadBonds()
            loadCompanies()
            getcurrencies()
            txtMaturityDate.MinDate = DateAdd(DateInterval.Day, 1, Date.UtcNow)
            txtIssueDate.MinDate = DateAdd(DateInterval.Day, -1, Date.UtcNow)

        End If
        If Session("finish") = "true" Then
            Session("finish") = ""
            msgbox("Bond Series Successfully Approved!")
        End If
        'Catch ex As Exception
        '    msgbox(ex.Message)
        'End Try
    End Sub
    Protected Sub loadCompanies()
        cmd = New SqlCommand("select * from para_issuer", cn)
        Dim ds As New DataSet
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "Client_Companies")
        If ds.Tables(0).Rows.Count > 0 Then
            cmbIssuer.DataSource = ds
            cmbIssuer.TextField = "Company"
            cmbIssuer.ValueField = "Issuer_Code"
            cmbIssuer.DataBind()
        End If
    End Sub

    Protected Sub loadBonds()
        cmd = New SqlCommand("  select ID,  Issuer, Code AS Series,[Type], DayCountBasis, Currency, FaceValue, Rate, IssueDate, MaturityDate,[Status] FROM Bond where Category='BOND' and [Status]='PENDING'", cn)
        Dim ds As New DataSet
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "Bonds")
        If ds.Tables(0).Rows.Count > 0 Then
            ASPxGridView2.DataSource = ds
            ASPxGridView2.DataBind()
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
        End If
    End Sub
    Public Function seriesexists(series As String) As Boolean
        Dim dsport As New DataSet
        cmd = New SqlCommand("select code from Bond where code='" + series + "'", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(dsport, "trans")
        If (dsport.Tables(0).Rows.Count > 0) Then
            Return True
        Else
            Return False
        End If

    End Function
    Protected Sub btnSaveContract_Click(sender As Object, e As EventArgs) Handles btnSaveTB.Click
        If btnSaveTB.Text = "Save Bond" Then
            Dim query As String = " insert Bond (Code, Issuer, FaceValue, Units, Rate, IssueDate, MaturityDate, DateCreated, [Type], ISIN, multiples, Category, SinkingFund, CouponPayments, DayCountBasis, CreatedBy, CreateDate, [Status], Currency) values (@Code, @Issuer,@FaceValue,NULL, @CouponRate, @IssueDate, @MaturityDate, getdate(), @Type,@ISIN, NULL, 'BOND', NULL, @CouponPayments, @DayCountBasis, @CreatedBy, getdate(), @Status, @currency)"
            Using conny As New SqlConnection(constr)
                Using comm As New SqlCommand()
                    With comm
                        .Connection = conny
                        .CommandType = CommandType.Text
                        .CommandText = query
                        .Parameters.AddWithValue("@Code", txtSeries.Text)
                        .Parameters.AddWithValue("@Issuer", cmbIssuer.SelectedItem.Value)
                        .Parameters.AddWithValue("@FaceValue", txtFaceValue.Text)
                        .Parameters.AddWithValue("@CouponRate", txtcoupnRate.Text)
                        .Parameters.AddWithValue("@IssueDate", txtIssueDate.Date.ToString)
                        .Parameters.AddWithValue("@MaturityDate", txtMaturityDate.Date.ToString)
                        .Parameters.AddWithValue("@Type", cmbType.SelectedItem.Value.ToString)
                        .Parameters.AddWithValue("@Category", "NORMAL BOND")
                        .Parameters.AddWithValue("@ISIN", txtisin.Text)
                        .Parameters.AddWithValue("@CouponPayments", cmbannualcoupon.SelectedItem.Text)
                        .Parameters.AddWithValue("@DayCountBasis", cmbdaycountbasis.SelectedItem.Text)
                        .Parameters.AddWithValue("@CreatedBy", Session("Username"))
                        .Parameters.AddWithValue("@Status", "PENDING")
                        .Parameters.AddWithValue("@Currency", cmbcurrency.SelectedItem.Text)
                    End With

                    conny.Open()
                    comm.ExecuteNonQuery()

                    Session("finish") = "true"
                    Response.Redirect(Request.RawUrl)

                End Using
            End Using
        ElseIf btnSaveTB.Text = "Update" Then


        End If

    End Sub
    Protected Sub btnSaveTB0_Click(sender As Object, e As EventArgs) Handles btnSaveTB0.Click
        Response.Redirect(Request.RawUrl)
    End Sub
    Protected Sub btnSaveTB1_Click(sender As Object, e As EventArgs) Handles btnSaveTB1.Click
        Try
            cmd = New SqlCommand("Update Bond set [Status]='ACTIVE', ApprovedBy='" + Session("Username") + "', ApprovedDate=getdate() where id='" + lbltransid.Text + "'", cn)
            If (cn.State = ConnectionState.Open) Then
                cn.Close()
            End If
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()
            Session("finish") = "true"
            Response.Redirect(Request.RawUrl)
        Catch ex As Exception

        End Try

    End Sub
    Protected Sub freezefields()
        cmbdaycountbasis.Enabled = False
        txtFaceValue.Enabled = False
        '    txtDesc.Text = False


    End Sub
    Protected Sub txtpaymentdate_DateChanged(sender As Object, e As EventArgs) Handles txtpaymentdate.DateChanged
        calculate()

    End Sub
    Public Sub calculate()
        Dim rate As Decimal = txtcoupnRate.Text
        Dim amount As Decimal = txtFaceValue.Text
        Dim numberofdays As Decimal = DateDiff(DateInterval.Day, txtIssueDate.Date, txtpaymentdate.Date)
        Dim dailyrate, totalgain, maturityamount As Decimal
        If cmbdaycountbasis.SelectedItem.Text = "actual/360" Then
            dailyrate = rate / 360
            totalgain = dailyrate * numberofdays
            maturityamount = totalgain / 100 * amount
        ElseIf cmbdaycountbasis.SelectedItem.Text = "actual/365" Then
            dailyrate = rate / 365
            totalgain = dailyrate * numberofdays
            maturityamount = totalgain / 100 * amount
        End If



        txtamount.Text = maturityamount.ToString("N") - getcurr_amt(txtSeries.Text)
    End Sub
    Protected Sub btnSaveContract1_Click(sender As Object, e As EventArgs) Handles btnSaveContract1.Click
        Dim amt As Decimal = txtamount.Text
        If amt <= 0 Then
            msgbox("Amount cannot be below or equal to 0!")
            Exit Sub
        End If
        cmd = New SqlCommand("insert into Bond_InterestPayment (Code, PaymentDate, PaymentNo, Amount, Saved, Other) values ('" + txtSeries.Text + "','" + txtpaymentdate.Date.ToString + "','" + txtpaymentno.Text + "','" + txtamount.Text + "','0','" + cmboption.SelectedItem.Text + "','" + txtDesc.Text + "')", cn)
        If (cn.State = ConnectionState.Open) Then
            cn.Close()
        End If
        cn.Open()
        cmd.ExecuteNonQuery()
        cn.Close()
        txtpaymentdate.Text = ""
        txtamount.Text = ""
        cmboption.Text = ""
        txtpaymentno.Text = getmaxid(txtSeries.Text).ToString
        getpayments()

    End Sub
    Public Sub getpayments()
        Dim dsport As New DataSet
        cmd = New SqlCommand("select id, PaymentNo, PaymentDate, Amount, Other as [Details], Code from Bond_InterestPayment where code='" + txtSeries.Text + "'", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(dsport, "trans")
        If (dsport.Tables(0).Rows.Count > 0) Then
            ASPxGridView3.DataSource = dsport
            ASPxGridView3.DataBind()

        End If
    End Sub
    Public Function getmaxid(series As String) As String
        Dim dsport As New DataSet
        cmd = New SqlCommand("select isnull(max(paymentNo),0)+1 as paymentNo from Bond_InterestPayment where code='" + series + "'", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(dsport, "trans")
        If (dsport.Tables(0).Rows.Count > 0) Then
            Return dsport.Tables(0).Rows(0).Item("paymentNo").ToString
        End If

    End Function
    Public Function getcurr_amt(series As String) As Decimal
        Dim dsport As New DataSet
        cmd = New SqlCommand("select isnull(sum(amount),0) as  amt from bond_interestpayment where Code='" + series + "'", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(dsport, "trans")
        If (dsport.Tables(0).Rows.Count > 0) Then
            Return dsport.Tables(0).Rows(0).Item("amt").ToString
        End If

    End Function

    Private Sub ASPxGridView2_RowCommand(sender As Object, e As ASPxGridViewRowCommandEventArgs) Handles ASPxGridView2.RowCommand
        Dim id As String = e.KeyValue.ToString
        If e.CommandArgs.CommandName.ToString = "Details" Then
            getdetails(id)
        End If

    End Sub
    Public Sub getdetails(id As String)
        '  Try
        Dim dsport As New DataSet
        cmd = New SqlCommand("select * from Bond where id='" + id + "'", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(dsport, "trans")
        If (dsport.Tables(0).Rows.Count > 0) Then
            If dsport.Tables(0).Rows(0).Item("Status").ToString <> "PENDING" Then
                msgbox("You cannot edit a Bond that is not in pending state")
                Exit Sub
            End If
            lbltransid.Text = id
            cmbannualcoupon.Value = dsport.Tables(0).Rows(0).Item("CouponPayments").ToString
            cmbcurrency.Value = dsport.Tables(0).Rows(0).Item("Currency").ToString
            cmbdaycountbasis.Value = dsport.Tables(0).Rows(0).Item("DayCountBasis").ToString
            cmbIssuer.Value = dsport.Tables(0).Rows(0).Item("Issuer").ToString
            cmbType.Value = dsport.Tables(0).Rows(0).Item("Type").ToString
            txtSeries.Text = dsport.Tables(0).Rows(0).Item("Code").ToString
            txtcoupnRate.Text = dsport.Tables(0).Rows(0).Item("Rate").ToString
            txtDesc.Text = dsport.Tables(0).Rows(0).Item("Other").ToString
            txtFaceValue.Text = dsport.Tables(0).Rows(0).Item("FaceValue").ToString
            txtisin.Text = dsport.Tables(0).Rows(0).Item("ISIN").ToString
            txtIssueDate.Date = dsport.Tables(0).Rows(0).Item("IssueDate").ToString
            txtMaturityDate.Date = dsport.Tables(0).Rows(0).Item("MaturityDate").ToString
            getpayments()


        End If
    End Sub

    Protected Sub cmboption_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmboption.SelectedIndexChanged
        If cmboption.SelectedItem.Text = "Include Capital" Then
            ASPxLabel68.Visible = True
            txtcapitalamount.Visible = True
            txtcapitalpercentage.Visible = True
            txtcapitalamount.Text = ""
            txtcapitalpercentage.Text = ""
        Else
            ASPxLabel68.Visible = False
            txtcapitalamount.Visible = False
            txtcapitalpercentage.Visible = False
            txtcapitalamount.Text = "0"
            txtcapitalpercentage.Text = "0"
        End If
    End Sub
    Protected Sub txtcapitalamount_TextChanged(sender As Object, e As EventArgs) Handles txtcapitalamount.TextChanged
        Try
            Dim perc As Decimal
            Dim repayamount As Decimal = txtcapitalamount.Text
            Dim totalamt As Decimal = txtFaceValue.Text
            perc = repayamount / totalamt * 100
            txtcapitalpercentage.Text = perc.ToString
        Catch ex As Exception

        End Try


    End Sub
    Protected Sub txtcapitalpercentage_TextChanged(sender As Object, e As EventArgs) Handles txtcapitalpercentage.TextChanged
        Try


            Dim amt As Decimal
            Dim perc As Decimal = txtcapitalpercentage.Text
            Dim totalamt As Decimal = txtFaceValue.Text
            amt = perc / 100 * totalamt

            txtcapitalamount.Text = amt.ToString
        Catch ex As Exception

        End Try
    End Sub
End Class
