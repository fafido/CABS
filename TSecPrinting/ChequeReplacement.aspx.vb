Partial Class TSecPrinting_ChequeReplacement
    Inherits System.Web.UI.Page
    Dim cn As SqlConnection
    Dim cmd As SqlCommand
    Dim mct As SqlCommand
    Dim nmo As New SqlDataAdapter
    Dim adp As New SqlDataAdapter
    Dim cnstr As String
    Dim dmbOb As New BindCombo

    Public Function Authenticity() As Integer
        Try
            Dim dschk As New DataSet
            cmd = New SqlCommand("select cheqrpl from usermanagement where userid='" & Session("Username") & "' and cheqrpl=1", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(dschk, "usermanagement")
            If (dschk.Tables(0).Rows.Count > 0) Then
                Return 1
            Else
                Return 0
            End If

        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Function

    Protected Sub btn_Print_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_Print.Click
        Try
            Dim l As Integer = 0
            l = Authenticity()

            If (l = 0) Then
                msgbox("You are not an Authenticated User For Cheque Replacements")
                Exit Sub
            End If

            If (Not IsNumeric(txtNewChequeNo.Text)) Then
                msgbox("Please Enter Cheque No in Numeric")
                txtNewChequeNo.Focus()
                Exit Sub
            End If

            If (txtNewChequeNo.Text = "") Then
                msgbox("Please Enter New Cheque Number")
                txtNewChequeNo.Focus()
                Exit Sub
            End If
            Dim cheq_search As New DataSet
            If txtNewChequeNo.Text <> "" Then
                cmd = New SqlCommand("select * from cheq_dets where cheq_no =" & txtNewChequeNo.Text & " and company='" & cmbCompany.Text & "' and div_no = " & cmbDivno.Text & " and r_man=0", cn)
                adp = New SqlDataAdapter(cmd)
                adp.Fill(cheq_search, "cheq_dets")
                If cheq_search.Tables(0).Rows.Count > 0 Then
                    msgbox("Cheque number already exists !")
                    Exit Sub
                End If
            Else
                msgbox("Enter Replacement Cheque Number")
                Exit Sub
            End If
            Dim dsCheque As New DataSet   'Cheque Status
            cmd = New SqlCommand("select distinct cheq_no from cheq_dets where replace=2 and company='" & cmbCompany.Text & "' and Div_no=" & cmbDivno.Text & " and r_man=0", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(dsCheque, "cheq_dets")

            Dim i As Integer = 0
            Dim j As Integer = 0
            For i = 0 To dsCheque.Tables(0).Rows.Count - 1

                cmd = New SqlCommand("insert into AuditCheqDets(id,company,amount,status,payee,date,oldcheqno,updatedby,div_no,shareholder) values(" & cheq_search.Tables(0).Rows(0).Item("id").ToString & ",'" & cmbCompany.Text & "'," & dsCheque.Tables(0).Rows(i).Item("Amount").ToString & ",'" & dsCheque.Tables(0).Rows(i).Item("Status").ToString & "','" & dsCheque.Tables(0).Rows(i).Item("payee").ToString & "','" & Now.Date & "'," & dsCheque.Tables(0).Rows(i).Item("Cheq_no").ToString & ",'" & Session("username") & "'," & cmbDivno.Text & "," & dsCheque.Tables(0).Rows(i).Item("Shareholder").ToString & ")", cn)
                If (cn.State = ConnectionState.Open) Then
                    cn.Close()
                End If
                cn.Open()
                cmd.ExecuteNonQuery()
                cn.Close()

                cmd = New SqlCommand("update cheq_dets set cheq_no=" & CDbl(txtNewChequeNo.Text) + j & ", rdate='" & repdate.Text & "', replace=3 where cheq_no = " & dsCheque.Tables(0).Rows(i).Item(0).ToString & " and company='" & cmbCompany.Text & "' and Div_no=" & cmbDivno.Text & " and r_man=0 ", cn)
                If cn.State = ConnectionState.Open Then
                    cn.Close()
                End If
                cn.Open()
                cmd.ExecuteNonQuery()
                cn.Close()



                j = j + 1
            Next

            msgbox("All non- mandated cheques Replaced")

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

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Page.MaintainScrollPositionOnPostBack = True


        Try
            cnstr = (System.Configuration.ConfigurationManager.AppSettings("connpath"))
            cn = New SqlConnection(cnstr)

            If (Not IsPostBack) Then
                dmbOb.BindCombo("cheq_dets", "company", cmbCompany)
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            'Dim cheqtype As Integer
            If (rdtemp1.Checked = False And rdtemp2.Checked = False) Then
                msgbox("Please Select one of the templates")
                Exit Sub
            End If
            If (rdtemp1.Checked = True) Then
                lbltemp.Text = 0
                'cheqtype = 0
            Else
                'cheqtype = 1
                lbltemp.Text = 1
            End If

            If (rdtemp2.Checked = True) Then
                ' cheqtype = 1
                lbltemp.Text = 1
            Else
                'cheqtype = 0
                lbltemp.Text = 0
            End If

            Dim i As Integer = 0
            Dim cal As SqlCommand
            Dim mun As SqlDataAdapter

            i = Authenticity()

            If (i = 0) Then
                msgbox("You are not Authenticated User For Certificate Updating")
                Exit Sub
            End If

            Dim strscript As String
            If (cmbCompany.Text <> "") Then
                If Nomandate.Checked = True Then
                    Dim ccc As New DataSet
                    ccc.Clear()
                    cal = New SqlCommand("select * from cheq_dets where company='" & cmbCompany.Text & "' and div_no=" & cmbDivno.Text & " and replace = 3 and r_man=0", cn)
                    mun = New SqlDataAdapter(cal)
                    mun.Fill(ccc, "cheq_dets")
                    If ccc.Tables(0).Rows.Count > 0 Then
                        strscript = "<script langauage=JavaScript>"
                        strscript += "window.open('PrintCheques.aspx?company=" & cmbCompany.Text & "&divno=" & cmbDivno.Text & "&templ=" & lbltemp.Text & "');"
                        strscript += "</script>"
                        ClientScript.RegisterStartupScript(Me.GetType(), "newwin", strscript)
                    Else
                        msgbox("There is no data for Replacements !")
                        Exit Sub
                    End If

                End If
                If Mandate.Checked = True Then
                    Dim mhk As New DataSet
                    Dim comps As String
                    Dim divs As Integer
                    If (cmbCompany.Text <> "" And cmbDivno.Text <> "") Then
                        comps = cmbCompany.Text
                        divs = cmbDivno.Text
                        mhk.Clear()
                        cal = New SqlCommand("select * from cheq_dets where company='" & cmbCompany.Text & "' and div_no=" & cmbDivno.Text & " and replace = 3 and r_man= 1 ", cn)
                        mun = New SqlDataAdapter(cal)
                        mun.Fill(mhk, "cheq_dets")
                        If mhk.Tables(0).Rows.Count > 0 Then
                            strscript = "<script langauage=JavaScript>"
                            strscript += "window.open('PrintChequesMan.aspx?company= " & comps & "&divno=" & divs & "&templ=" & lbltemp.Text & "');"
                            strscript += "</script>"
                            ClientScript.RegisterStartupScript(Me.GetType(), "newwin", strscript)
                        Else
                            msgbox("There is no data for Replacements !")
                            Exit Sub
                        End If
                    End If


                End If

                If bankMandate.Checked = True Then
                    Dim dolz As New DataSet
                    dolz.Clear()
                    cal = New SqlCommand("select * from cheq_dets where company='" & cmbCompany.Text & "' and div_no=" & cmbDivno.Text & " and replace = 3 and r_man = 1", cn)
                    mun = New SqlDataAdapter(cal)
                    mun.Fill(dolz, "cheq_dets")
                    If dolz.Tables(0).Rows.Count > 0 Then
                        strscript = "<script langauage=JavaScript>"
                        strscript += "window.open('PrintChequesMandate.aspx?company=" & cmbCompany.Text & "&divno=" & cmbDivno.Text & "&templ=" & lbltemp.Text & "');"
                        strscript += "</script>"
                        ClientScript.RegisterStartupScript(Me.GetType(), "newwin", strscript)
                    Else
                        msgbox("There is no data for Replacements !")
                        Exit Sub
                    End If
                End If

            Else
                msgbox("Please Select The value of Company")
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub BindDivCombo()
        Try
            Dim dsDivno As New DataSet

            If cmbCompany.Text <> "" Then
                cmd = New SqlCommand("select distinct div_no from div_instr where company = '" & cmbCompany.SelectedValue.ToString() & "'", cn)
                adp = New SqlDataAdapter(cmd)
                adp.Fill(dsDivno, "div_instr")
                cmbDivno.DataSource = dsDivno.Tables("div_instr")
                cmbDivno.DataValueField = "div_no"
                cmbDivno.DataMember = "div_no"
                cmbDivno.DataBind()

            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Protected Sub cmbCompany_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbCompany.SelectedIndexChanged
        BindDivCombo()
    End Sub


    Protected Sub Button3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button3.Click
        Calendar1.Visible = True

    End Sub

    Protected Sub Calendar1_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Calendar1.SelectionChanged
        repdate.Text = Calendar1.SelectedDate
        Calendar1.SelectedDate = Nothing
        Calendar1.Visible = False


    End Sub

    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.Click
        Try

            Dim i As Integer = 0
            i = Authenticity()

            If (i = 0) Then
                msgbox("You are not Authenticated User For Certificate Updating")
                Exit Sub
            End If

            Dim clr As SqlCommand
            Dim fclr As SqlDataAdapter

            Dim clearrecords As New DataSet

            clr = New SqlCommand("select * from dividend where replace=3 and company like '" & cmbCompany.Text & "'and div_no=" & cmbDivno.Text, cn)
            fclr = New SqlDataAdapter(clr)
            fclr.Fill(clearrecords, "dividend")
            clr = New SqlCommand("update dividend set replace=0 where company like '" & cmbCompany.Text & "' and replace=3 and div_no=" & cmbDivno.Text, cn)

            If cn.State = ConnectionState.Open Then
                cn.Close()

            End If
            cn.Open()
            clr.ExecuteNonQuery()
            cn.Close()


            Dim cal As SqlCommand
            Dim muna As SqlDataAdapter

            Dim cecilia As New DataSet
            cal = New SqlCommand("select * from cheq_dets where replace=3 and company like '" & cmbCompany.Text & "'and div_no=" & cmbDivno.Text, cn)
            muna = New SqlDataAdapter(cal)
            muna.Fill(cecilia, "cheq_dets")
            cal = New SqlCommand("update cheq_dets set replace=0 where company like '" & cmbCompany.Text & "'and div_no=" & cmbDivno.Text, cn)

            If cn.State = ConnectionState.Open Then
                cn.Close()

            End If
            cn.Open()
            cal.ExecuteNonQuery()
            cn.Close()

        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub


    Protected Sub Button4_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button4.Click
        Try

            Dim i As Integer = 0
            i = Authenticity()

            If (i = 0) Then
                msgbox("You are not Authenticated User For Certificate Updating")
                Exit Sub
            End If

            Dim strscript As String

            strscript = "<script langauage=JavaScript>"
            strscript += "window.open('Replacements.aspx?');"
            strscript += "</script>"
            ClientScript.RegisterStartupScript(Me.GetType(), "newwin", strscript)

        Catch ex As Exception
            msgbox(ex.Message)
        End Try

    End Sub

    Protected Sub Nomandate_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Nomandate.CheckedChanged
        Mandate.Checked = False
        bankMandate.Checked = False
    End Sub
    Protected Sub Mandate_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Mandate.CheckedChanged
        Nomandate.Checked = False
        bankMandate.Checked = False
    End Sub

    Protected Sub bankMandate_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles bankMandate.CheckedChanged
        Nomandate.Checked = False
        Mandate.Checked = False
    End Sub

    Protected Sub btnReplaceMan_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReplaceMan.Click
        Try
            Dim l As Integer = 0
            l = Authenticity()

            If (l = 0) Then
                msgbox("You are not an Authenticated User For Cheque Replacements")
                Exit Sub
            End If

            If (Not IsNumeric(txtNewChequeNo.Text)) Then
                msgbox("Please Enter Cheque No in Numeric")
                txtNewChequeNo.Focus()
                Exit Sub
            End If

            If (txtNewChequeNo.Text = "") Then
                msgbox("Please Enter New Cheque Number")
                txtNewChequeNo.Focus()
                Exit Sub
            End If
            Dim cheq_search As New DataSet
            If txtNewChequeNo.Text <> "" Then
                cmd = New SqlCommand("select * from cheq_dets where cheq_no =" & txtNewChequeNo.Text & " and company='" & cmbCompany.Text & "' and div_no = " & cmbDivno.Text & " and r_man=1", cn)
                adp = New SqlDataAdapter(cmd)
                adp.Fill(cheq_search, "cheq_dets")
                If cheq_search.Tables(0).Rows.Count > 0 Then
                    msgbox("Cheque number already exists !")
                    Exit Sub
                End If
            Else
                msgbox("Enter Replacement Cheque Number")
                Exit Sub
            End If
            Dim dsCheque As New DataSet   'Cheque Status
            cmd = New SqlCommand("select distinct cheq_no from cheq_dets where replace=2 and company='" & cmbCompany.Text & "' and Div_no=" & cmbDivno.Text & " and r_man=1", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(dsCheque, "cheq_dets")

            Dim i As Integer = 0
            Dim j As Integer = 0
            For i = 0 To dsCheque.Tables(0).Rows.Count - 1
                cmd = New SqlCommand("insert into AuditCheqDets(id,company,amount,status,payee,date,oldcheqno,updatedby,div_no,shareholder) values(" & cheq_search.Tables(0).Rows(0).Item("id").ToString & ",'" & cmbCompany.Text & "'," & dsCheque.Tables(0).Rows(i).Item("Amount").ToString & ",'" & dsCheque.Tables(0).Rows(i).Item("Status").ToString & "','" & dsCheque.Tables(0).Rows(i).Item("payee").ToString & "','" & Now.Date & "'," & dsCheque.Tables(0).Rows(i).Item("Cheq_no").ToString & ",'" & Session("username") & "'," & cmbDivno.Text & "," & dsCheque.Tables(0).Rows(i).Item("Shareholder").ToString & ")", cn)
                If (cn.State = ConnectionState.Open) Then
                    cn.Close()
                End If
                cn.Open()
                cmd.ExecuteNonQuery()
                cn.Close()

                cmd = New SqlCommand("update cheq_dets set cheq_no=" & CDbl(txtNewChequeNo.Text) + j & ", rdate='" & repdate.Text & "', replace=3 where cheq_no = " & dsCheque.Tables(0).Rows(i).Item(0).ToString & " and company='" & cmbCompany.Text & "' and Div_no=" & cmbDivno.Text & " and r_man=1 ", cn)
                If cn.State = ConnectionState.Open Then
                    cn.Close()
                End If
                cn.Open()
                cmd.ExecuteNonQuery()
                cn.Close()
                j = j + 1
            Next

            msgbox("All mandated cheques Replaced")

        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub btnMandates_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnMandates.Click
        Try

            Dim i As Integer = 0
            i = Authenticity()

            If (i = 0) Then
                msgbox("You are not Authenticated User For Certificate Updating")
                Exit Sub
            End If

            Dim strscript As String

            strscript = "<script langauage=JavaScript>"
            strscript += "window.open('ReplacementsMan.aspx?');"
            strscript += "</script>"
            ClientScript.RegisterStartupScript(Me.GetType(), "newwin", strscript)

        Catch ex As Exception
            msgbox(ex.Message)
        End Try

    End Sub
End Class
