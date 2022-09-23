Partial Class Parameters_BillingPara
    Inherits System.Web.UI.Page
    Dim constr As String = (System.Configuration.ConfigurationManager.AppSettings("connpath"))
    Dim cn As New SqlConnection(constr)
    Dim adp As SqlDataAdapter
    Dim cmd As SqlCommand
    Dim chargeperiod As String
    Dim chargelevel As String
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
                getIssuers()
                'getMainAccounts()
                'getSubProduct()

            End If


        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub








    'Protected Sub grdvCharges_SelectedIndexChanged(sender As Object, e As EventArgs) Handles grdvCharges.SelectedIndexChanged
    '    'txtChargeCode.Text = grdvCharges.SelectedRow.Cells(1).Text
    '    'txtChargeCode.ReadOnly = True

    '    'Dim cmd1 = New SqlCommand("Delete from  para_billing where ChargeCode = '" & grdvCharges.SelectedRow.Cells(1).Text & "'", cn)
    '    'If (cn.State = ConnectionState.Open) Then
    '    '    cn.Close()
    '    'End If
    '    'cn.Open()
    '    'cmd1.ExecuteNonQuery()
    '    'cn.Close()
    '    'FillGrid()
    'End Sub



    'Public Sub RemoveCurrenctPara()
    '    Dim cmd1 = New SqlCommand("Update para_Billing set chargename = '" + txtChargeName.Text + "', PercentageOrValue =  '" + txtPercent.Text + "',Period =  '" + txtperiod.Text + "', chargelevel =  '" + rdChargelevel.SelectedItem.Value + "' where chargename='" + txtupdate.Text + "' and    account_type='" + txtAccountType.Text + "'", cn)
    '    If (cn.State = ConnectionState.Open) Then
    '        cn.Close()
    '    End If
    '    cn.Open()
    '    cmd1.ExecuteNonQuery()
    '    cn.Close()
    'End Sub
    'Public Sub SetNewPara()
    '    Dim selectedPara As String
    '    selectedPara = radlistBillingParameters.SelectedItem.Text
    '    Dim cmd1 = New SqlCommand("Update para_BillingParameter set Active=True Where BillingParameter = '" & selectedPara & "'", cn)
    '    If (cn.State = ConnectionState.Open) Then
    '        cn.Close()
    '    End If
    '    cn.Open()
    '    cmd1.ExecuteNonQuery()
    '    cn.Close()
    'End Sub






    Protected Sub grdvCharges_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles grdvCharges.PageIndexChanging
        grdvCharges.PageIndex = e.NewPageIndex
        FillGrid(txtPeriodFrom.Text, txtPeriodTo.Text)
        ' GetAccounts()
    End Sub
    Protected Sub ASPxButton1_Click(sender As Object, e As EventArgs)
        FillGrid(txtPeriodFrom.Text, txtPeriodTo.Text)
    End Sub
    Public Function FillGrid(ByVal datefrom, ByVal dateto)
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand(" select id, fixeddeposit_number as Batchno, InstrumentType as [Instrument Type],principal_name as Issuer ,Principal_Code as [Issuer Code], Maturity_Date as MaturityDate ,Interest_Earned as [Interest Value], Issue_Date as [Issue Date]     from  MoneyMarketInstruments where callables='1' and convert(date,'" + datefrom + "')  <  convert(date, Maturity_Date)  and     convert(date,Maturity_Date) <= convert(date,'" + dateto + "') and callbackdate is null and Expired='no'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "para_lendingRules")
            If (ds.Tables(0).Rows.Count > 0) Then
                grdvCharges.DataSource = ds.Tables(0)
                grdvCharges.DataBind()
            Else
                grdvCharges.DataSource = Nothing
                grdvCharges.DataBind()
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try

        Return 0
    End Function

    Public Sub lnkedit(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim idd As String = (CType(sender, LinkButton)).CommandArgument
        txtId.Text = idd
        Panel10.Visible = True

    End Sub

    Protected Sub ASPxButton2_Click(sender As Object, e As EventArgs)
        SaveCallBackDate(txtId.Text)
        getSubscribers(txtbatchnumber.Text, txtinstrument.Text, txtcounter.Text)
        msgbox("Call Back Successful")
    End Sub
    Public Function SaveCallBackDate(ByVal id As String)
        Dim cmd1 = New SqlCommand("Update  MoneyMarketInstruments set callbackdate='" + txtCallBackDate.Text + "'      where id='" + id + "' ", cn)
        If (cn.State = ConnectionState.Open) Then
            cn.Close()
        End If
        cn.Open()
        cmd1.ExecuteNonQuery()
        cn.Close()

        Return 0
    End Function
    Public Function getSubscribers(ByVal batchnumber, ByVal instrument, ByVal Counter)

        cn.Close()
        cn.Open()
        Dim clientnumber As String
        Dim Query As String = " select distinct(CDS_Number) as clientnumber from [CDSC].[dbo].[CashTrans]  where batchnumber='" + batchnumber + "' and counter='" + Counter + "' and instrument='" + instrument + "' "
        Dim cmd As SqlCommand = New SqlCommand(Query, cn)
        Dim da As SqlDataAdapter = New SqlDataAdapter(cmd)
        Dim ds As DataSet = New DataSet("ds")
        da.Fill(ds)
        Dim dt As DataTable = ds.Tables(0)

        If dt.Rows.Count > 0 Then

            For Each dr As DataRow In dt.Rows
                clientnumber = dr("clientnumber").ToString()
                GetPayableValue(clientnumber, txtCallBackDate.Text, instrument, batchnumber, Counter)
                ' sendEmail(email)
                ' UpdatesentEmail(email)
            Next

            'seczLevy()
        End If



      

    End Function
    'Public Sub getRecepiants()
    '    Dim cmd As SqlCommand = New SqlCommand("select RecepientEmail  from Regulator_MailingList  where  convert(date,getdate()) >  convert(date,lastsent)   ", cn)
    '    Dim da As SqlDataAdapter = New SqlDataAdapter(cmd)
    '    Dim ds As DataSet = New DataSet("ds")
    '    da.Fill(ds)
    '    Dim dt As DataTable = ds.Tables(0)

    '    If dt.Rows.Count > 0 Then

    '        For Each dr As DataRow In dt.Rows
    '            email = dr("RecepientEmail").ToString()
    '            sendEmail(email)
    '            UpdatesentEmail(email)
    '        Next

    '        seczLevy()
    '    End If
    'End Sub

    Public Function ThrowDuable(ByVal clientnumber As String, ByVal calleddate As String, ByVal value As String, ByVal instrument As String, ByVal batchno As String, ByVal counter As String)
        Dim result As Integer
        Dim done As Boolean = False
        Dim type As String = instrument + "-" + "CallBack"
        Dim amount = Convert.ToDouble(value) * -1
        cmd = New SqlCommand("insert into CashTrans ([Description],TransType, Amount, DateCreated, TransStatus , cds_Number, PAID, Reference ,batchnumber ,counter) VALUES   ('Money Market Call Back','" + type + "','" & amount & "',GETDATE(),'1','" + clientnumber + "',NULL, NULL , '" + batchno + "','" + counter + "')", cn)
        If (cn.State = ConnectionState.Open) Then
            cn.Close()
        End If
        cn.Open()
        result = cmd.ExecuteNonQuery()
        If (result = 1) Then
            done = True
        End If


        Return 0
    End Function
    Public Function GetPayableValue(ByVal clientnumber As String, ByVal calleddate As String, ByVal instrument As String, ByVal batchno As String, ByVal counter As String)
        cn.Close()
        cn.Open()

        Dim issuedate As Date = (txtIssueDate.Text)
        Dim callbackdate As Date = (txtCallBackDate.Text)
        Dim interestamount As Double = 0
        Dim numberofdays As Double = DateDiff("d", issuedate, callbackdate)
        Dim amounttobepaid As String = Nothing
        Dim Query As String = "select sum(quantity * price) as amounttobepaid from transactions  where Reference='" + batchno + "'and cds_number='" + clientnumber + "' and convert(date,Date_Created) <= convert(date,'" + calleddate + "') and company='" + cmbCounter.SelectedItem.Value + "')"
        Dim cmd As SqlCommand = New SqlCommand(Query, cn)
        Dim dr As SqlDataReader = cmd.ExecuteReader()

        If dr.Read() = True Then
            interestamount = Convert.ToDouble(dr("amounttobepaid").ToString()) * (Convert.ToDouble(txtInterest.Text) / 100) * numberofdays
            amounttobepaid = Convert.ToDouble(dr("amounttobepaid").ToString()) + interestamount



        End If

        ThrowDuable(clientnumber, calleddate, amounttobepaid, instrument, batchno, counter)
        RecordInterest(clientnumber, calleddate, amounttobepaid, instrument, batchno, counter)

        Return 0
    End Function
    Public Sub getIssuers()
        Dim ds As New DataSet
        cmd = New SqlCommand("select * from para_issuer ", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "para_lendingRules")
        If (ds.Tables(0).Rows.Count > 0) Then
            cmbCounter.DataSource = ds
            cmbCounter.TextField = "company"
            cmbCounter.ValueField = "issuer_code"
            cmbCounter.DataBind()
        End If
    End Sub
    Protected Sub grdvCharges_SelectedIndexChanged(sender As Object, e As EventArgs) Handles grdvCharges.SelectedIndexChanged
        'txtChargeCode.Text = grdvCharges.SelectedRow.Cells(1).Text
        'txtChargeCode.ReadOnly = True
        ' msgbox(grdvCharges.SelectedRow.Cells(1).Text)
        txtId.Text = grdvCharges.SelectedRow.Cells(1).Text
        txtbatchnumber.Text = grdvCharges.SelectedRow.Cells(2).Text
        txtcounter.Text = grdvCharges.SelectedRow.Cells(5).Text
        txtinstrument.Text = grdvCharges.SelectedRow.Cells(3).Text
        txtIssueDate.Text = grdvCharges.SelectedRow.Cells(8).Text
        txtInterest.Text = grdvCharges.SelectedRow.Cells(7).Text
        Panel10.Visible = True
        'txtChargeName.Text = grdvCharges.SelectedRow.Cells(6).Text
        'getMainAccounts()
        'cmbProductType.Value = grdvCharges.SelectedRow.Cells(1).Text
        'txtAccountType.Text = grdvCharges.SelectedRow.Cells(7).Text

        'txtPercent.Text = grdvCharges.SelectedRow.Cells(2).Text

        'ASPxButton4.Visible = False
        'UpdatePanel.Visible = True
    End Sub


    Public Function RecordInterest(ByVal clientnumber As String, ByVal calleddate As String, ByVal value As String, ByVal instrument As String, ByVal batchno As String, ByVal counter As String)
        Dim result As Integer
        Dim done As Boolean = False
        Dim type As String = instrument + "-" + "Interest"
        Dim amount = Convert.ToDouble(value) * -1
        cmd = New SqlCommand("insert into cashtrans ([Description],TransType, Amount, DateCreated, TransStatus , cds_Number, PAID, Reference ,batchnumber ,counter , instrument) VALUES   ('Interest Payable','" + type + "','" & amount & "',GETDATE(),'1','" + clientnumber + "',NULL, NULL , '" + batchno + "','" + counter + "','" + instrument + "')", cn)
        If (cn.State = ConnectionState.Open) Then
            cn.Close()
        End If
        cn.Open()
        result = cmd.ExecuteNonQuery()
        If (result = 1) Then
            done = True
        End If


        Return 0
    End Function
End Class
