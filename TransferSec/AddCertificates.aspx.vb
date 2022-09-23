
Partial Class TransferSec_Add_Certificates
    Inherits System.Web.UI.Page
    Dim constr As String = (System.Configuration.ConfigurationManager.AppSettings("connpath"))
    Dim cn As New SqlConnection(constr)
    Dim constr2 As String = (System.Configuration.ConfigurationManager.AppSettings("conKshares"))
    Dim cn2 As New SqlConnection(constr2)
    Dim adp As SqlDataAdapter
    Dim cmd As SqlCommand

    Protected Sub ASPxButton2_Click(sender As Object, e As EventArgs) Handles ASPxButton2.Click
        Try

            Session("cusAdd") = ""
            If Session("usertype") = "CDSAdmin" Or Session("usertype") = "CDSUser" Or Session("usertype") = "TransferSecUser" Then
                Dim ds As New DataSet
                cmd = New SqlCommand("select CDS_Number+' '+surname+' '+forenames as namess,CDS_Number  from Accounts_Clients where surname+' '+forenames+' '+IDNoPP like '%" & txtClientName.Text & "%'", cn)
                adp = New SqlDataAdapter(cmd)
                adp.Fill(ds, "Accounts_Clients")
                If (ds.Tables(0).Rows.Count > 0) Then
                    lstNames.DataSource = ds.Tables(0)
                    lstNames.TextField = "namess"
                    lstNames.ValueField = "CDS_Number"
                    lstNames.DataBind()
                End If
            Else
                Dim ds As New DataSet
                cmd = New SqlCommand("select CDS_Number+' '+surname+' '+forenames as namess,CDS_Number  from Accounts_Clients where surname+' '+forenames+' '+IDNoPP like '%" & txtClientName.Text & "%' and Custodian='" + Session("BrokerCode") + "'", cn)
                adp = New SqlDataAdapter(cmd)
                adp.Fill(ds, "Accounts_Clients")
                If (ds.Tables(0).Rows.Count > 0) Then
                    lstNames.DataSource = ds.Tables(0)
                    lstNames.TextField = "namess"
                    lstNames.ValueField = "CDS_Number"
                    lstNames.DataBind()
                End If
            End If

        Catch ex As Exception
            msgbox(ex.Message)
        End Try
        '   MSGBOX(Session("usertype"))
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

    Protected Sub loadSecurities()
        cmd = New SqlCommand("select distinct Company from CertMaster", cn)
        Dim ds As New DataSet
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "para_securities")
        If ds.Tables(0).Rows.Count > 0 Then
            cmbSecurities.DataSource = ds
            cmbSecurities.TextField = "Company"
            cmbSecurities.ValueField = "Company"
            cmbSecurities.DataBind()
        End If
    End Sub
    Public Sub getportfolio()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select * from Accounts_Clients where CDS_Number+' '+surname+' '+forenames = '" & lstNames.SelectedItem.Text & "'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "Accounts_Clients")
            If (ds.Tables(0).Rows.Count > 0) Then
                ASPxTextBox1.Text = ds.Tables(0).Rows(0).Item("surname").ToString.ToUpper + " " + ds.Tables(0).Rows(0).Item("forenames").ToString.ToUpper
                ASPxTextBox2.Text = ds.Tables(0).Rows(0).Item("CDS_Number").ToString.ToUpper
                Session("cusAdd") = ds.Tables(0).Rows(0).Item("Custodian").ToString.ToUpper
                Session("idAdd") = ds.Tables(0).Rows(0).Item("IDNoPP").ToString.ToUpper

                ' msgbox(Session("idAdd").ToString)
                '    txtSurnames.Text = ds.Tables(0).Rows(0).Item("surname").ToString.ToUpper
                '    rdBonds.Checked = True


            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        loadSecurities()
    End Sub
    Protected Sub lstNames_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstNames.SelectedIndexChanged
        getportfolio()
    End Sub
    Protected Sub btnView0_Click(sender As Object, e As EventArgs) Handles btnView0.Click
        If txtHolder.Text.Length < 1 Then
            msgbox("Enter Holder number")
            Exit Sub
        End If

        If txtCertNumber.Text.Length < 1 Then
            msgbox("Enter Certificate Number Number")
            Exit Sub
        End If

        If cmbSecurities.Text <> "" Then
            Dim certAdded = False

            Using Cony As New SqlConnection(constr)
                Cony.Open()
                Using Comy As New SqlCommand("SELECT * from [dbo].[AccountNewCertificates] where CertificateNumber='" & txtCertNumber.Text & "' and Holder='" & txtHolder.Text & "'", Cony)
                    Using RDR = Comy.ExecuteReader()
                        If RDR.HasRows Then
                            Do While RDR.Read
                                certAdded = True
                            Loop
                        End If
                    End Using
                End Using
                Cony.Close()
            End Using


            If Not certAdded Then
                Using Cony As New SqlConnection(constr2)
                    Cony.Open()
                    '  Using Comy As New SqlCommand("SELECT * from [dbo].[CertMaster] where CertNumber='" & txtCertNumber.Text & "' and (Shareholder='" & txtHolder.Text & "' or OldId='" & txtHolder.Text & "') and Company='" & cmbSecurities.SelectedItem.Text & "'", Cony)
                    Using Comy As New SqlCommand("select * from mast where company='" & cmbSecurities.SelectedItem.Text & "' and Cert='" & txtCertNumber.Text & "' and (shareholder='" & txtHolder.Text & "' OR  shareholder IN (select top 1 shareholder from names where old_id='" + txtholder.text + "'))", Cony)
                        Using RDR = Comy.ExecuteReader()
                            If RDR.HasRows Then
                                Do While RDR.Read

                                    'ISERTING INTO CERTIFICATE

                                    Dim query1 = "INSERT INTO [dbo].[AccountNewCertificates] ([IdNumber], [CertificateNumber], [Holder], [Units], [Company]) VALUES (@IdNumber, @CertificateNumber, @Holder, @Units, @Company)"
                                    Using conn As New SqlConnection(constr)
                                        Using comm As New SqlCommand()
                                            With comm
                                                .Connection = conn
                                                .CommandType = CommandType.Text
                                                .CommandText = query1
                                                .Parameters.AddWithValue("@IdNumber", Session("idAdd").ToString)
                                                .Parameters.AddWithValue("@CertificateNumber", txtCertNumber.Text)
                                                .Parameters.AddWithValue("@Holder", txtHolder.Text)
                                                .Parameters.AddWithValue("@Units", RDR.Item("Shares").ToString())
                                                .Parameters.AddWithValue("@Company", cmbSecurities.Text)
                                            End With

                                            Try
                                                conn.Open()
                                                comm.ExecuteNonQuery()
                                            Catch ex As SqlException
                                                msgbox("Something went wrong try again")
                                            End Try
                                        End Using
                                    End Using

                                    '--------------------------------

                                    Dim queryQ = "INSERT INTO [dbo].[trans] ([Company], [CDS_Number], [Date_Created], [Trans_Time], [Shares], [Update_Type], [Created_By], [Batch_Ref], [Source], [Pledge_shares], [Reference], [Instrument], [Broker], [Custodian]) VALUES (@Company, @CDS_Number, @Date_Created, @Trans_Time, @Shares, @Update_Type, @Created_By, @Batch_Ref, @Source, @Pledge_shares, @Reference, @Instrument, @Broker, @Custodian)"
                                    Using conq As New SqlConnection(constr)
                                        Using comq As New SqlCommand()
                                            With comq
                                                .Connection = conq
                                                .CommandType = CommandType.Text
                                                .CommandText = queryQ

                                                'msgbox("Inserting into trans")
                                                Try
                                                    .Parameters.AddWithValue("@Company", cmbSecurities.Text)
                                                    .Parameters.AddWithValue("@CDS_Number", ASPxTextBox2.Text)
                                                    .Parameters.AddWithValue("@Date_Created", Date.Now)
                                                    .Parameters.AddWithValue("@Trans_Time", Date.Now)
                                                    .Parameters.AddWithValue("@Shares", Integer.Parse(RDR.Item("Shares").ToString()))
                                                    .Parameters.AddWithValue("@Update_Type", "DEMAT")
                                                    .Parameters.AddWithValue("@Created_By", Session("Username").ToString())
                                                    .Parameters.AddWithValue("@Batch_Ref", "0")
                                                    .Parameters.AddWithValue("@Source", "S")
                                                    .Parameters.AddWithValue("@Pledge_shares", 0)
                                                    .Parameters.AddWithValue("@Reference", "")
                                                    .Parameters.AddWithValue("@Instrument", "EQUITY")
                                                    .Parameters.AddWithValue("@Broker", Session("BrokerCode").ToString)
                                                    .Parameters.AddWithValue("@Custodian", Session("cusAdd").ToString)
                                                Catch ex As Exception
                                                    msgbox(ex.ToString())
                                                End Try
                                            End With

                                            Try
                                                conq.Open()
                                                comq.ExecuteNonQuery()
                                                msgbox("Certificate added successfully")

                                                ASPxTextBox2.Text = ""
                                                ASPxTextBox1.Text = ""
                                                txtCertNumber.Text = ""
                                                txtHolder.Text = ""

                                            Catch ex As SqlException
                                                msgbox(ex.ToString())
                                            End Try
                                        End Using
                                    End Using

                                Loop
                            Else
                                msgbox("Certificate not found")
                            End If
                        End Using
                    End Using
                    Cony.Close()
                End Using
            Else
                msgbox("Certificate Already Added")
                Exit Sub
            End If
        Else
            msgbox("Select Company")
            Exit Sub
        End If
    End Sub
End Class
