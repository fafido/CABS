Partial Class AddNewDerivContractt
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
                loadContractNo()
                loadCompanies()
                loadDrivatives()
                loadBanks()
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Protected Sub CalculateDiscountedAMT()
        If txtDiscountPerc.Text <> "" And txtFaceValue.Text <> "" And txtMaturityDate.Text <> "" And txtIssueDate.Text <> "" Then

            Dim issueancePrice As Double = 0
            Dim daysTomaturity As Integer = 0
            Dim newperc As Decimal = txtDiscountPerc.Text
            daysTomaturity = DateDiff(DateInterval.Day, CDate(txtIssueDate.Text), CDate(txtMaturityDate.Text))
            issueancePrice = (CDbl(txtFaceValue.Text) * (1 - daysTomaturity / 360 * CDbl(newperc / 100)))
            issueancePrice = Math.Round(issueancePrice, 2)
            txtDiscountedAmt.Text = issueancePrice
        End If
    End Sub
    Protected Sub clearall()
        txtadd4.Text = ""
        txtadd3.Text = ""
        txtTenor.Text = ""
        txtDiscountedAmt.Text = ""
        txtBANo.Text = ""
        txtSearchName.Text = ""
        txtphone.Text = ""
        txtDiscountPerc.Text = ""
        txtPurpose.Text = ""
        txtcode.Text = ""
        txtfullname.Text = ""
        txtemail.Text = ""
        lstNames.Items.Clear()
        lstNames.Visible = False
        txtMaturityDate.Text = ""
        cmbStatus.SelectedIndex = 0
        txtFaceValue.Text = ""
        cmbIssuer.SelectedIndex = 0
        txtadd1.Text = ""
        txtadd2.Text = ""
        txtAcceptParticipant.Text = ""
        txtBroker.Text = ""
    End Sub
    Protected Sub btnSearchName_Click(sender As Object, e As EventArgs) Handles btnSearchName.Click
        Dim ds As New DataSet
        cmd = New SqlCommand("select fnam, company  from para_company where company like '%" & txtSearchName.Text & "%'", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "Accounts_Clients")
        If (ds.Tables(0).Rows.Count > 0) Then
            lstNames.DataSource = ds.Tables(0)
            lstNames.TextField = "fnam"
            lstNames.ValueField = "company"
            lstNames.DataBind()
            lstNames.Visible = True
        End If
    End Sub
    Protected Sub loadBanks()
        cmd = New SqlCommand("select * from para_bank", cn)
        Dim ds As New DataSet
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "para_bank")
        If ds.Tables(0).Rows.Count > 0 Then
            cmbbankGuarantee.DataSource = ds
            cmbbankGuarantee.TextField = "bank_name"
            cmbbankGuarantee.ValueField = "bank"
            cmbbankGuarantee.DataBind()
        End If
    End Sub
    Protected Sub loadCompanies()
        cmd = New SqlCommand("select distinct Company_Code,Company_name from Client_Companies", cn)
        Dim ds As New DataSet
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "Client_Companies")
        If ds.Tables(0).Rows.Count > 0 Then
            cmbIssuer.DataSource = ds
            cmbIssuer.TextField = "Company_name"
            cmbIssuer.ValueField = "Company_Code"
            cmbIssuer.DataBind()
        End If
    End Sub
    Protected Sub loadContractNo()
        cmd = New SqlCommand("select isnull(max(id),0)+1 as nextID from BAs", cn)
        Dim ds As New DataSet
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "BAs")
        If ds.Tables(0).Rows.Count > 0 Then
            Dim BANo As String = String.Concat("BA", ds.Tables(0).Rows(0).Item("nextID").ToString.PadLeft(10, "0"))
            txtBANo.Text = BANo
        End If
    End Sub
    Protected Sub loadDrivatives()
        cmd = New SqlCommand("select BA_number as [BA No.],Principal_name as [Principal Name],Face_value as [Face Value],Discounted_Amount as [Issue Price],Tenor as [Tenor],FORMAT(Issue_Date,'dd-MMM-yyyy') as [Issue Date],FORMAT(Maturity_Date,'dd-MMM-yyyy') as [Maturity Date] from BAs order by ID ASC", cn)
        Dim ds As New DataSet
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "BAs")
        If ds.Tables(0).Rows.Count > 0 Then
            ASPxGridView2.DataSource = ds
            ASPxGridView2.DataBind()
        End If
    End Sub
    Protected Sub btnSaveContract_Click(sender As Object, e As EventArgs) Handles btnSaveContract.Click
        If txtadd1.Text <> "" And txtFaceValue.Text <> "" And txtadd2.Text <> "" And txtTenor.Text <> "" And txtDiscountedAmt.Text <> "" And txtBANo.Text <> "" And txtDiscountPerc.Text <> "" And txtPurpose.Text <> "" And txtphone.Text <> "" And txtcode.Text <> "" And txtfullname.Text <> "" And txtemail.Text <> "" And txtMaturityDate.Text <> "" And cmbStatus.Text <> "" And cmbIssuer.Text <> "" Then

            cmd = New SqlCommand("select isnull(max(id),0)+1 as nextID from BAs", cn)
            Dim ds As New DataSet
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "BAs")
            If ds.Tables(0).Rows.Count > 0 Then
                Dim BANo As String = String.Concat("BA", ds.Tables(0).Rows(0).Item("nextID").ToString.PadLeft(10, "0"))
                cmd = New SqlCommand("begin transaction insert into BAs([BrokerCode],[BA_number],[Principal_name],[Principal_Code],[Principal_Email],[Principal_Phone],[Principal_Add1],[Principal_Add2],[Principal_Add3],[Principal_Add4],[Face_value],[Tenor],[Maturity_Date],[Discount_Percentage],[Discounted_Amount],[Expired],[Negotiated],[Accept_Participant],[Issuer],[BA_status],[date_sent],[Loan_ref],[de_mat],[broadcast],[purpose],[Created_By],[Created_On],[Bank_Guarantee],[Issue_Date])values('" & txtBroker.Text & "','" & BANo & "','" & txtfullname.Text & "','" & txtcode.Text & "','" & txtemail.Text & "','" & txtphone.Text & "','" & txtadd1.Text & "','" & txtadd2.Text & "','" & txtadd3.Text & "','" & txtadd4.Text & "','" & txtFaceValue.Text & "','" & txtTenor.Text & "','" & txtMaturityDate.Text & "','" & txtDiscountPerc.Text & "','" & txtDiscountedAmt.Text & "','0','0','" & txtAcceptParticipant.Text & "','" & cmbIssuer.SelectedItem.Value & "','" & cmbStatus.Text & "',GETDATE(),'0','0','0','" & txtPurpose.Text & "','" & Session("Username") & "',GETDATE(),'" & cmbbankGuarantee.Text & "','" & txtIssueDate.Text & "') insert into trans([Company],[CDS_Number],[Date_Created],[Trans_Time],[Shares],[Update_Type],[Created_By],[Source],[Pledge_shares],[Reference],[Instrument])values('" & cmbIssuer.SelectedItem.Value & "','" & txtcode.Text & "',GETDATE(),GETDATE(),'" & txtFaceValue.Text & "','Allot','" & Session("Username") & "','S',0,'" & BANo & "','BA') insert into mast([company],[CDS_Number],[Date_Created],[Shares],[Update_Type],[Pladge],[Pledge_Shares],[Created_By],[Updated_On],[Updated_By],[Locked],[Lock_Reason],[Batch_Ref],[PledgeReason],[SecType])values('" & cmbIssuer.SelectedItem.Value & "','" & txtcode.Text & "',GETDATE(),'" & txtFaceValue.Text & "','ALLOT',0,0,'" & Session("Username") & "',GETDATE(),'" & Session("Username") & "',0,'-',0,'','BA') commit transaction", cn)
                If cn.State = ConnectionState.Open Then
                    cn.Close()
                End If
                cn.Open()
                cmd.ExecuteNonQuery()
                cn.Close()
                clearall()
                msgbox("B.A Successfully saved, B.A Number is " & BANo)
                loadContractNo()
                loadDrivatives()
            Else
                msgbox("BA Already Exists")
                Exit Sub
            End If
        Else
            msgbox("Enter All Information Please")
            Exit Sub
        End If
    End Sub
    Public Sub getportfolio()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select * from para_company where company='" & lstNames.SelectedItem.Value & "'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "Accounts_Clients")
            If (ds.Tables(0).Rows.Count > 0) Then
                txtcode.Text = ds.Tables(0).Rows(0).Item("company").ToString.ToUpper
                txtfullname.Text = String.Concat(ds.Tables(0).Rows(0).Item("fnam").ToString.ToUpper)
                txtphone.Text = ds.Tables(0).Rows(0).Item("telephone").ToString.ToUpper
                txtadd1.Text = ds.Tables(0).Rows(0).Item("Add_1").ToString.ToUpper
                txtadd2.Text = ds.Tables(0).Rows(0).Item("Add_2").ToString.ToUpper
                txtadd3.Text = ds.Tables(0).Rows(0).Item("Add_3").ToString.ToUpper
                txtadd4.Text = ds.Tables(0).Rows(0).Item("Add_4").ToString.ToUpper
                txtemail.Text = ds.Tables(0).Rows(0).Item("Email").ToString
                txtBroker.Text = ds.Tables(0).Rows(0).Item("Company").ToString
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Protected Sub lstNames_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstNames.SelectedIndexChanged
        getportfolio()
    End Sub

    Protected Sub txtMaturityDate_DateChanged(sender As Object, e As EventArgs) Handles txtMaturityDate.DateChanged
        CalculateDiscountedAMT()
        If txtIssueDate.Text <> "" Then
            Dim msg As String
            Dim secondDate As Date
            Dim fdt As Date
            '     firstDate = InputBox("Enter a date")
            Try
                secondDate = txtMaturityDate.Text
                fdt = txtIssueDate.Text
                msg = DateDiff(DateInterval.Month, fdt, secondDate)
                txtTenor.Text = msg

            Catch
                msgbox("Not a valid date value.")
            End Try
        End If
    End Sub

    Protected Sub txtDiscountPerc_TextChanged(sender As Object, e As EventArgs) Handles txtDiscountPerc.TextChanged
        CalculateDiscountedAMT()
    End Sub

    Protected Sub txtIssueDate_DateChanged(sender As Object, e As EventArgs) Handles txtIssueDate.DateChanged
        CalculateDiscountedAMT()
        If txtTenor.Text <> "" Then
            Dim Msg, Number, StartDate As String   'Declare variables.
            Dim Months As Double
            Dim SecondDate As Date
            Dim IntervalType As DateInterval
            IntervalType = DateInterval.Month   ' Specifies months as interval.
            '    StartDate = InputBox("Enter a date")
            SecondDate = CDate(txtIssueDate.Text)
            '    Number = InputBox("Enter number of months to add")
            Months = txtTenor.Text
            Msg = DateAdd(IntervalType, Months, SecondDate)
            txtMaturityDate.Text = Msg
        End If
    End Sub

    Protected Sub txtFaceValue_TextChanged(sender As Object, e As EventArgs) Handles txtFaceValue.TextChanged
        CalculateDiscountedAMT()
    End Sub

    Protected Sub txtTenor_TextChanged(sender As Object, e As EventArgs) Handles txtTenor.TextChanged
        If txtIssueDate.Text <> "" Then
            Dim Msg, Number, StartDate As String   'Declare variables.
            Dim Months As Double
            Dim SecondDate As Date
            Dim IntervalType As DateInterval
            IntervalType = DateInterval.Month   ' Specifies months as interval.
            '    StartDate = InputBox("Enter a date")
            SecondDate = CDate(txtIssueDate.Text)
            '    Number = InputBox("Enter number of months to add")
            Months = txtTenor.Text
            Msg = DateAdd(IntervalType, Months, SecondDate)
            txtMaturityDate.Text = Msg
        End If
    End Sub

End Class
