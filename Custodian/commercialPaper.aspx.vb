Partial Class Commercialpaper
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
    Protected Sub CalculateDiscountedAMT()
        If txtDiscountYield.Text <> "" And txtFaceValue.Text <> "" And txtMaturityDate.Text <> "" And txtIssueDate.Text <> "" Then

            Dim issueancePrice As Double = 0
            Dim daysTomaturity As Integer = 0
            daysTomaturity = DateDiff(DateInterval.Day, CDate(txtIssueDate.Text), CDate(txtMaturityDate.Text))
            issueancePrice = (CDbl(txtFaceValue.Text) * (1 - daysTomaturity / 360 * CDbl(txtDiscountYield.Text)))
            issueancePrice = Math.Round(issueancePrice, 2)
            txtIssuePrice.Text = issueancePrice
        End If
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Page.MaintainScrollPositionOnPostBack = True
            If Session("finish") = "true" Then
                Session("finish") = ""
                msgbox("Commercial Paper Successfully saved")
            End If
            If (Not IsPostBack) Then
                checkSessionState()
                loadTreasuryBills()
                loadCompanies()
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Protected Sub loadCompanies()
        cmd = New SqlCommand("select fnam, company from para_issuer", cn)
        Dim ds As New DataSet
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "Client_Companies")
        If ds.Tables(0).Rows.Count > 0 Then
            cmbIssuer.DataSource = ds
            cmbIssuer.TextField = "fnam"
            cmbIssuer.ValueField = "Company"
            cmbIssuer.DataBind()
        End If
    End Sub
    Protected Sub clearall()
        txtDiscountYield.Text = ""
        txtFaceValue.Text = ""
        txtTenure.Text = ""
        txtSeries.Text = ""
        txtDesc.Text = ""
        txtMaturityDate.Text = ""
        txtIssueDate.Text = ""
        txtNoofNotes.Text = ""

        cmbIssuer.Text = ""
        txtIssuePrice.Text = ""
    End Sub
    Protected Sub loadTreasuryBills()
        cmd = New SqlCommand("select [Issuer],[Series],[Face_value] as [Face Value],[NoofNotes] as [No. of Notes],[DiscountedYield] as [Discounted Yield],FORMAT([IssueDate],'dd-MMM-yyyy') as [Issue Date],FORMAT([MaturityDate],'dd-MMM-yyyy') as [Maturity Date],[Tenure],[DiscountAmount] as [Issue Price] from CommercialPaper order by ID desc", cn)
        Dim ds As New DataSet
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "TreasuryBills")
        If ds.Tables(0).Rows.Count > 0 Then
            ASPxGridView2.DataSource = ds
            ASPxGridView2.DataBind()
        End If
    End Sub
  
    Protected Sub btnSaveContract_Click(sender As Object, e As EventArgs) Handles btnSaveTB.Click
        If txtDesc.Text <> "" And txtDiscountYield.Text <> "" And txtIssueDate.Text <> "" And txtMaturityDate.Text <> "" And txtNoofNotes.Text <> "" And txtSeries.Text <> "" And txtTenure.Text <> "" And txtFaceValue.Text <> "" And txtIssuePrice.Text <> "" Then
            If txtisin.Text.Length = 12 Then

            Else
                msgbox("Please enter a 12 character ISIN!")
                txtisin.Focus()
                Exit Sub
            End If
           
            cmd = New SqlCommand("begin transaction insert into CommercialPaper ([Issuer],[Series],[Face_value],[NoofNotes],[DiscountedYield],[IssueDate],[MaturityDate],[Tenure],[CapitalRepaymentDate],[Decsription],[CreatedBy],[DateCreated],[DiscountAmount],[multiples],[mode],[min],[max],[ISIN],[NC_OpeningDate]      ,[NC_ClosingDate]      ,[NC_OpeningTime]      ,[NC_ClosingTime],[fomart])values('" & cmbIssuer.SelectedItem.Value & "','" & txtSeries.Text & "','" & txtFaceValue.Text & "','" & txtNoofNotes.Text & "','" & txtDiscountYield.Text & "','" & txtIssueDate.Text & "','" & txtMaturityDate.Text & "','" & txtTenure.Text & "','','" & txtDesc.Text & "','" & Session("Username") & "',GETDATE(),'" & txtIssuePrice.Text & "','" + cmbmultiples.SelectedItem.Value.ToString + "','Non-Competitive','" + txtminimum.Text + "','" + txtmaximum.Text + "','" + txtisin.Text + "','" + txtNC_openingdate.Text + "','" + txtNC_closingdate.Text + "','" + txtNC_openingtime.Text + "','" + txtNC_closingtime.Text + "','FP') commit transaction", cn)
            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()

            cmd = New SqlCommand("insert into para_company (company, fnam, date_created, Issued_shares, [status],CDS_Ac_No, registrar,sec_type, isin, year_listed, issued_capital, nominal_value, ISSUER_CODE, series) values ('" + txtisin.Text + "','" + cmbIssuer.SelectedItem.Text + "',getdate(),'" + txtNoofNotes.Text + "','1', '0','','CP','" + txtisin.Text + "','" + txtIssueDate.Text + "','" + txtNoofNotes.Text + "','" + txtFaceValue.Text + "','" + cmbIssuer.SelectedItem.Value.ToString + "','" + txtSeries.Text + "')", cn)
            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()


            cmd = New SqlCommand("insert into testcds.dbo.para_company (company, sector, Issued_shares, [status], Date_created, Contact_Person, Cellphone, email, isin_no, Market_Segment, Instrument, Index_Type, fhl, fel, swl, InitialPrice, fnam,Board) values ('" + txtisin.Text + "','0','" + txtNoofNotes.Text + "','0',getdate(),'ADMIN','0','0', '" + txtisin.Text + "','0','CP','20 SHARE INDEX','0','0','0','" + txtIssuePrice.Text + "','" + cmbIssuer.SelectedItem.Text + "','Money Market Board') declare @price numeric(18,4)='" + txtIssuePrice.Text + "' insert into testcds.dbo.companyprices (company, SHARESINISSUE, LASTPRICE, CHANGEPercent, CHANGEValue, CurrentPrice, [ShareVOL],sharevalue, highestprice, LowestPrice, UpdatedDate, OpeningPrice, bestprice) select company, issued_shares, @price,'0','0',@price,'0','0',@price, @price, getdate(), @price, @price from para_company where company='" + txtisin.Text + "'", cn)
            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()

            Session("finish") = "true"
            Response.Redirect(Request.RawUrl)
            '  loadTreasuryBills()

        Else
            msgbox("Enter All Information Please")
            Exit Sub
        End If
    End Sub

    Protected Sub txtMaturityDate_DateChanged(sender As Object, e As EventArgs) Handles txtMaturityDate.DateChanged
        'CalculateDiscountedAMT()
        Dim DT As Date = txtIssueDate.Text
        Dim MD As Date = txtMaturityDate.Text

        txtTenure.Text = DateDiff(DateInterval.Day, DT, MD).ToString()
        Dim TENURE As Decimal = txtTenure.Text
        If TENURE > 270 Then
            txtTenure.Text = ""
            txtMaturityDate.Text = ""
            msgbox("Invalid Date, Tenure for Commercial Paper cannot be above 270days!")
        End If
    End Sub

    Protected Sub txtIssueDate_DateChanged(sender As Object, e As EventArgs) Handles txtIssueDate.DateChanged
        'CalculateDiscountedAMT()
        Dim opdate As Date = txtIssueDate.Text
        '   Dim closdate As Date = opdate.AddDays()
        '   txtMaturityDate.Text = closdate.ToString("M/d/yyyy")
    End Sub

    Protected Sub txtDiscountYield_TextChanged(sender As Object, e As EventArgs) Handles txtDiscountYield.TextChanged
        '   CalculateDiscountedAMT()
        'If txtNoofNotes.Text <> "" And txtDiscountYield.Text <> "" And txtFaceValue.Text <> "" Then
        '    Try
        '        Dim face As Decimal = txtFaceValue.Text
        '        Dim no_of_notes As Decimal = txtNoofNotes.Text
        '        Dim disc_perc As Decimal = txtDiscountYield.Text
        '        Dim discount As Decimal = disc_perc / 100 * face
        '        Dim face_less_discount As Decimal = face - discount
        '        Dim price As Decimal = face_less_discount / no_of_notes
        '        txtIssuePrice.Text = price.ToString
        '    Catch ex As Exception
        '        msgbox(ex.Message)
        '    End Try
        'Else
        '    txtDiscountYield.Text = ""
        '    msgbox("Please enter Number of Notes before you proceed")
        'End If
    End Sub

    Protected Sub txtFaceValue_TextChanged(sender As Object, e As EventArgs) Handles txtFaceValue.TextChanged
        'CalculateDiscountedAMT()

        If cmbmultiples.SelectedIndex.ToString <> "-1" Then
            Try
                Dim multip As Decimal = cmbmultiples.SelectedItem.Value
                Dim facevalue As Decimal = txtFaceValue.Text
                Dim resul As Decimal = facevalue / multip
                txtNoofNotes.Text = resul.ToString
            Catch ex As Exception
                msgbox(ex.Message)
            End Try

        End If
    End Sub

 

    Protected Sub cmbmultiples_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbmultiples.SelectedIndexChanged
        If txtFaceValue.Text = "" Then
            cmbmultiples.Value = ""
            msgbox("Please enter face value before you choose Multiples!")
        Else
            Try
                Dim multip As Decimal = cmbmultiples.SelectedItem.Value
                Dim facevalue As Decimal = txtFaceValue.Text
                Dim resul As Decimal = facevalue / multip
                txtNoofNotes.Text = resul.ToString
            Catch ex As Exception
                msgbox(ex.Message)
            End Try
        End If
    End Sub
End Class
