
Partial Class ATS_bondsetup2
    Inherits System.Web.UI.Page
    Dim conn As String = System.Configuration.ConfigurationManager.AppSettings("connpath")
    'Dim constr As String = (System.Configuration.ConfigurationManager.AppSettings("connpath"))
    Protected Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim Issuer As String
        Dim Series As String
        Dim FaceValue As Integer
        Dim NumberOfNotesIssued As String
        Dim CouponRate As Double
        Dim NumberCouponPyts As Integer
        Dim Code1 As String
        Dim BondValue As String
        Dim CurrentDate As DateTime
        Dim MaturityDate As DateTime
        Dim IssuedDate As DateTime
        Dim CouponPaymentDate As Integer
        Dim CouponPayments As Integer
        Dim CurrentCuoponPytDate As Date
        Dim Type As String
        Dim Tenure As String
        Dim CapitalPyt As String
        Dim CapitalPytArray As String()
        Dim kcN As String

        kcN = Convert.ToInt32(TextBox1.Text)




        If txtFaceValue.Text = "" Or txtSeries.Text = "" Or txtNumOfNotes.Text = "" Or txtCouponRate.Text = "" Or txtNumOfCouponPyts.Text = "" Or txtIssueDate.Text = "" Or txtMaturityDate.Text = "" Or kcN.ToString = "" Then
            '   error1.Visible = False
            btnSave.Enabled = True
        Else

            CapitalPyt = TextArea1.Text
            CapitalPytArray = CapitalPyt.Split(New String() {Environment.NewLine}, StringSplitOptions.None)
            FaceValue = Convert.ToInt64(txtFaceValue.Text)
            Issuer = txtIssuer.SelectedItem.Value
            Series = txtSeries.Text
            Type = day.SelectedItem.Text
            NumberOfNotesIssued = txtNumOfNotes.Text
            CouponRate = txtCouponRate.Text
            NumberCouponPyts = txtNumOfCouponPyts.Text
            IssuedDate = txtIssueDate.Text
            MaturityDate = txtMaturityDate.Text
            CurrentDate = DateTime.Now

            Tenure = Math.Floor(((MaturityDate - IssuedDate).TotalDays.ToString) / 300)

            'Date Caluculations
            'CouponPaymentDate = 365 / NumberCouponPyts
            CouponPayments = NumberCouponPyts * Tenure


            BondValue = FaceValue * NumberOfNotesIssued
            Code1 = GetRandom(0, 1000000000)
            Dim Code As String
            '  Code = "BOND" + Code1
            Code = Issuer + Series

            Session("code") = Code

            Dim query As String = "INSERT INTO Bond (Code, Issuer, FaceValue, NumberOfNotesIssued, CouponRate, NumberOfCouponPaymentsInAYear, IssueDate, MaturityDate, Tenure, BondValue, Date, Type) VALUES (@Code, @Issuer, @FaceValue, @NumberOfNotesIssued, @CouponRate, @NumberOfCouponPaymentsInAYear, @IssueDate, @MaturityDate, @Tenure, @BondValue, @Date, @Type)"
            Using conny As New SqlConnection(conn)
                Using comm As New SqlCommand()
                    With comm
                        .Connection = conny
                        .CommandType = CommandType.Text
                        .CommandText = query
                        .Parameters.AddWithValue("@Code", Code)
                        .Parameters.AddWithValue("@Issuer", Issuer)
                        .Parameters.AddWithValue("@FaceValue", FaceValue)
                        .Parameters.AddWithValue("@NumberOfNotesIssued", NumberOfNotesIssued)
                        .Parameters.AddWithValue("@CouponRate", CouponRate)
                        .Parameters.AddWithValue("@NumberOfCouponPaymentsInAYear", NumberCouponPyts)
                        .Parameters.AddWithValue("@IssueDate", IssuedDate)
                        .Parameters.AddWithValue("@MaturityDate", MaturityDate)
                        .Parameters.AddWithValue("@Tenure", Tenure)
                        .Parameters.AddWithValue("@BondValue", BondValue)
                        .Parameters.AddWithValue("@Date", CurrentDate)
                        .Parameters.AddWithValue("@Type", Type)


                    End With
                    Try
                        conny.Open()
                        comm.ExecuteNonQuery()
                    Catch ex As SqlException
                    End Try
                End Using
            End Using



            Dim num As Integer = 0
            If Type = "Corporate" Then
                Dim Year1 As Integer = IssuedDate.Year
                If Year1 Mod 4 = 0 Then
                    CurrentCuoponPytDate = IssuedDate
                    CouponPaymentDate = 366 / NumberCouponPyts
                Else
                    CurrentCuoponPytDate = IssuedDate
                    CouponPaymentDate = 365 / NumberCouponPyts
                End If

                While num < CouponPayments
                    CurrentCuoponPytDate = CurrentCuoponPytDate.AddDays(CouponPaymentDate)
                    num += 1
                    Dim query1 As String = "INSERT INTO Bond_InterestPayment (Code, PaymentDate, Payment) VALUES (@Code, @PaymentDate, @Payment)"
                    Using connyy As New SqlConnection(conn)
                        Using commy As New SqlCommand()
                            With commy
                                .Connection = connyy
                                .CommandType = CommandType.Text
                                .CommandText = query1
                                .Parameters.AddWithValue("@Code", Code)
                                .Parameters.AddWithValue("@PaymentDate", CurrentCuoponPytDate.ToString("MM/dd/yyyy"))
                                .Parameters.AddWithValue("@Payment", num)
                            End With
                            Try
                                connyy.Open()
                                commy.ExecuteNonQuery()
                            Catch ex As SqlException
                            End Try
                        End Using
                    End Using
                End While
            End If


            Dim kc As Integer = 0

            While kc < kcN
                'CurrentCuoponPytDate = CurrentCuoponPytDate.AddDays(CouponPaymentDate)

                Dim query1 As String = "INSERT INTO Bond_CapitalRepayment (Code, CapitalPayment, Payment) VALUES (@Code, @CapitalPayment, @Payment)"
                Using connyy As New SqlConnection(conn)
                    Using commy As New SqlCommand()
                        With commy
                            .Connection = connyy
                            .CommandType = CommandType.Text
                            .CommandText = query1
                            .Parameters.AddWithValue("@Code", Code)
                            .Parameters.AddWithValue("@CapitalPayment", CapitalPytArray(kc + 1))
                            .Parameters.AddWithValue("@Payment", kc + 1)
                        End With
                        Try
                            connyy.Open()
                            commy.ExecuteNonQuery()
                        Catch ex As SqlException
                        End Try
                    End Using
                End Using
                kc += 1
            End While

            Response.Redirect("../ATS/Bondset.aspx")
        End If

    End Sub
    Public Function GetRandom(ByVal Min As Integer, ByVal Max As Integer) As Integer
        Dim Generator As System.Random = New System.Random()
        Return Generator.Next(Min, Max)
    End Function
    'Protected Sub btnAdd_Click(sender As Object, e As EventArgs)
    '    Dim Dates As String
    '    Dates = txtCapital.Text
    '    TextArea1.Text = TextArea1.Text + Environment.NewLine + txtCapital.Text
    'End Sub
    Protected Sub txtMaturityDate_TextChanged(sender As Object, e As EventArgs) Handles txtMaturityDate.TextChanged
        Dim Tenure As String
        Dim MaturityDate As DateTime
        Dim IssuedDate As DateTime

        IssuedDate = txtIssueDate.Text
        MaturityDate = txtMaturityDate.Text
        Tenure = Math.Floor(((MaturityDate - IssuedDate).TotalDays.ToString) / 300)

        txtTenure.Text = Tenure.ToString
    End Sub
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        btnSave.Enabled = False
        TextArea1.Enabled = False
        txtTenure.Enabled = False
        ' error1.Visible = False
        'txtCouponRate.Enabled = False
        If Not Me.IsPostBack Then
            Using con As New SqlConnection(conn)
                Using cmd As New SqlCommand("SELECT * FROM para_company")
                    cmd.CommandType = CommandType.Text
                    cmd.Connection = con
                    con.Open()
                    txtIssuer.DataSource = cmd.ExecuteReader()
                    txtIssuer.DataTextField = "Company"
                    txtIssuer.DataValueField = "Company"
                    txtIssuer.DataBind()
                    con.Close()
                End Using
            End Using
        End If

    End Sub
    Protected Sub btnAdd_Click1(sender As Object, e As EventArgs) Handles btnAdd.Click
        Dim Dates As String
        Dim before As String
        Dim after As String
        Dim num As Integer = Convert.ToInt32(TextBox1.Text)
        Dim CapitalPyt As String
        Dates = txtCapital.Text
        before = TextArea1.Text + vbCrLf + txtCapital.Text
        TextArea1.Text = before
        after = TextArea1.Text
        CapitalPyt = before
        Dim CapitalPytArray As String() = CapitalPyt.Split(New String() {Environment.NewLine}, StringSplitOptions.None)

        If num + 1 = CapitalPytArray.Length Then
            btnAdd.Enabled = False
            btnSave.Enabled = True
        End If



    End Sub
    Protected Sub day_SelectedIndexChanged(sender As Object, e As EventArgs) Handles day.SelectedIndexChanged
        If Day.SelectedValue = "Municipal" Then
            txtCouponRate.Text = 0
            txtNumOfCouponPyts.Text = 0
            txtCouponRate.Enabled = False
            txtNumOfCouponPyts.Enabled = False
        Else
            txtCouponRate.Enabled = True
            txtCouponRate.Text = ""
            txtNumOfCouponPyts.Enabled = True
            txtNumOfCouponPyts.Text = ""
        End If
    End Sub

    Protected Sub txtFaceValue_TextChanged(sender As Object, e As EventArgs) Handles txtFaceValue.TextChanged

    End Sub

    Protected Sub txtNumOfNotes_TextChanged(sender As Object, e As EventArgs) Handles txtNumOfNotes.TextChanged

    End Sub

    Protected Sub txtCouponRate_TextChanged(sender As Object, e As EventArgs) Handles txtCouponRate.TextChanged

    End Sub

    Protected Sub txtNumOfCouponPyts_TextChanged(sender As Object, e As EventArgs) Handles txtNumOfCouponPyts.TextChanged

    End Sub

    Protected Sub txtIssueDate_TextChanged(sender As Object, e As EventArgs) Handles txtIssueDate.TextChanged

    End Sub
End Class

