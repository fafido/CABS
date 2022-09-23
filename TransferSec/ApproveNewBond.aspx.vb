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
            getbanks()

            txtMaturityDate.MinDate = DateAdd(DateInterval.Day, 1, Date.UtcNow)
            txtIssueDate.MinDate = DateAdd(DateInterval.Day, -1, Date.UtcNow)

        End If
        If Session("finish") = "true" Then
            Session("finish") = ""
            msgbox("Bond Series Successfully Approved!")
        End If
        If Session("finish") = "rejected" Then
            Session("finish") = ""
            msgbox("Bond Series Rejected!")
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
        cmd = New SqlCommand("  select ID,  Issuer, Code AS Series,[Type], DayCountBasis, Currency, FaceValue, Rate, IssueDate, MaturityDate,[Status] FROM Bond where  [Status]='PENDING'", cn)
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
    Public Function series(id As String) As String
        Dim dsport As New DataSet
        cmd = New SqlCommand("select code from Bond where id='" + id + "'", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(dsport, "trans")
        If (dsport.Tables(0).Rows.Count > 0) Then
            Return dsport.Tables(0).Rows(0).Item("code").ToString
        Else
            Return ""
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
            If txttype.Text = "TRUSTEE" Then
                createsinkingdfundschedule(series(lbltransid.Text))
            End If

            Session("finish") = "true"
            Response.Redirect(Request.RawUrl)


        Catch ex As Exception
            msgbox(ex.Message)
        End Try

    End Sub
    Public Function paymentdate(series As String) As Date
        Dim dsport As New DataSet
        cmd = New SqlCommand("select IssueDate  from bond where code='" + series + "'", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(dsport, "trans")
        If (dsport.Tables(0).Rows.Count > 0) Then
            Return dsport.Tables(0).Rows(0).Item("IssueDate").ToString
        End If
    End Function
    Public Function intervals(series As String) As String
        Dim dsportx As New DataSet
        cmd = New SqlCommand("select case sinkingfund when 'Daily' then 'Day' when 'Monthly' then 'Month' when 'Weekly' then 'Week' else 'Month' end as interval  from bond where code='" + series + "'", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(dsportx, "transx")
        If (dsportx.Tables(0).Rows.Count > 0) Then
            Return dsportx.Tables(0).Rows(0).Item("interval").ToString

        End If
    End Function
    Public Function paymentdatefromprevpayment(series As String, paymentno As String) As Date
        Dim dsportx1 As New DataSet
        cmd = New SqlCommand("select paymentdate from Bond_InterestPayment where PaymentNo='" + paymentno + "' and code='" + series + "' ", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(dsportx1, "transx1")
        If (dsportx1.Tables(0).Rows.Count > 0) Then
            Return dsportx1.Tables(0).Rows(0).Item("paymentdate").ToString
        End If
    End Function
    Public Sub createsinkingdfundschedule(series As String)
        Dim dsport As New DataSet
        cmd = New SqlCommand("select *, isnull(Amount,0)+isnull(CapitalAmount,0) as tot from Bond_InterestPayment where code='" + series + "' order by PaymentNo", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(dsport, "trans")
        If (dsport.Tables(0).Rows.Count > 0) Then
            For i As Integer = 0 To dsport.Tables(0).Rows.Count - 1
                Dim paymentno As Decimal = dsport.Tables(0).Rows(i).Item("PaymentNo").ToString
                Dim datefrom As Date
                Dim dateto As Date = dsport.Tables(0).Rows(i).Item("Paymentdate").ToString
                Dim totamt As Decimal = dsport.Tables(0).Rows(i).Item("tot").ToString


                If paymentno = 1 Then
                    datefrom = paymentdate(series)
                Else
                    Dim payno As Decimal = paymentno - 1
                    datefrom = paymentdatefromprevpayment(series, payno.ToString)
                End If
                Dim intervalamount As Decimal
                If intervals(series) = "Day" Then
                    intervalamount = totamt / DateDiff(DateInterval.Day, datefrom, dateto)
                ElseIf intervals(series) = "Week" Then
                    intervalamount = totamt / DateDiff(DateInterval.Weekday, datefrom, dateto)
                ElseIf intervals(series) = "Month" Then
                    intervalamount = totamt / DateDiff(DateInterval.Month, datefrom, dateto)
                End If

                'msgbox("DECLARE @StartDate date = '" + datefrom.ToString + "'       ,@EndDate   date = '" + dateto.ToString + "';WITH theDates AS     (SELECT @StartDate as theDate      UNION ALL      SELECT DATEADD(week , 1, theDate)        FROM theDates       WHERE DATEADD(week, 1, theDate) <= @EndDate     ) insert into Bond_SinkingFund (series, PaymentNo, TotalAmount, Intervals, Amount,PaymentDate) SELECT '" + series + "', '" + paymentno.ToString + "', '" + totamt.ToString + "', '" + intervals(series) + "', '" + intervalamount.ToString + "',  theDate  FROM theDatesOPTION (MAXRECURSION 0);")

                cmd = New SqlCommand("DECLARE @StartDate date = '" + datefrom.ToString + "'       ,@EndDate   date = '" + dateto.ToString + "';WITH theDates AS     (SELECT @StartDate as theDate      UNION ALL      SELECT DATEADD(" + intervals(series) + " , 1, theDate)        FROM theDates       WHERE DATEADD(" + intervals(series) + ", 1, theDate) <= @EndDate     ) insert into Bond_SinkingFund (series, PaymentNo, TotalAmount, Intervals, Amount,PaymentDate) SELECT '" + series + "', '" + paymentno.ToString + "', '" + totamt.ToString + "', '" + intervals(series) + "', '" + intervalamount.ToString + "',  theDate  FROM theDates OPTION (MAXRECURSION 0);", cn)
                If (cn.State = ConnectionState.Open) Then
                    cn.Close()
                End If
                cn.Open()
                cmd.ExecuteNonQuery()
                cn.Close()
            Next
        End If

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
        cmd = New SqlCommand("select id, PaymentNo, PaymentDate, Format(Amount,'#,0.00') as Amount, Other as [Details],Code,Format(CapitalAmount,'#,0.00') as CapitalAmount,Format(CapitalPercentage,'#,0.00') as CapitalPercentage from Bond_InterestPayment where code='" + txtSeries.Text + "'", cn)
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
            cmbbank.Value = dsport.Tables(0).Rows(0).Item("Bank").ToString
            txtaccountname.Text = dsport.Tables(0).Rows(0).Item("AccountName").ToString
            txtaccountNo.Text = dsport.Tables(0).Rows(0).Item("AccountNo").ToString
            txttype.Text = dsport.Tables(0).Rows(0).Item("Category").ToString
            getpayments()


        End If
    End Sub
    Public Sub getbanks()
        Dim dsport As New DataSet
        cmd = New SqlCommand("select bank, bank_name from para_bank", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(dsport, "trans")
        If (dsport.Tables(0).Rows.Count > 0) Then
            cmbbank.DataSource = dsport
            cmbbank.TextField = "bank_name"
            cmbbank.ValueField = "bank"
            cmbbank.DataBind()


        End If
    End Sub

    Protected Sub btnSaveTB2_Click(sender As Object, e As EventArgs) Handles btnSaveTB2.Click
        Try
            cmd = New SqlCommand("Update Bond set [Status]='REJECTED', ApprovedBy='" + Session("Username") + "', ApprovedDate=getdate() where id='" + lbltransid.Text + "'", cn)
            If (cn.State = ConnectionState.Open) Then
                cn.Close()
            End If
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()

            Session("finish") = "rejected"
            Response.Redirect(Request.RawUrl)

        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
End Class
