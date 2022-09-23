Imports System.IO
Imports DevExpress.Web.ASPxGridView

Partial Class Parameters_InsurancePolicies
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
                getSecurities_Types()
                loadparticipants()
                If Session("finish") = "true" Then
                    Session("finish") = ""
                    msgbox("Successfully Uploaded")
                End If
                If Session("finish") = "update" Then
                    Session("finish") = ""
                    msgbox("Successfully Updated")
                End If
            End If
            getSecurities_Types()
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Protected Sub clearall()
        txtnotes.Text = ""
        txtpolicynumber.Text = ""
        getSecurities_Types()
    End Sub
    Protected Sub ASPxButton7_Click(sender As Object, e As EventArgs) Handles ASPxButton7.Click
        Try
            Try
                If cmbparticipant.SelectedItem.Text = "" Then
                    msgbox("Please select participant")
                    Exit Sub
                End If
            Catch ex As Exception
                msgbox("Please select participant")
                Exit Sub
            End Try

            If txtpolicynumber.Text <> "" And txtnotes.Text <> "" And txtamount.Text <> "" And txtinsurancecompany.Text <> "" Then
                If IsNumeric(txtamount.Text) = False Then
                    msgbox("Please enter correct amount on Fidelity Insurance!")
                    Exit Sub
                End If
                If IsNumeric(txtamount0.Text) = False Then
                    msgbox("Please enter correct amount on Allied Insurance!")
                    Exit Sub
                End If
                If ASPxButton7.Text = "save" Then
                    checkupload()
                Else
                    update()

                End If


            Else
                msgbox("Enter All Details")
                Exit Sub
            End If

        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub checkupload()



        Dim filePath As String = FileUpload1.PostedFile.FileName
        Dim filename As String = Path.GetFileName(filePath)
        Dim ext As String = Path.GetExtension(filename)
        Dim contenttype As String = String.Empty

        'Set the contenttype based on File Extension
        Select Case ext
            Case ".doc"
                contenttype = ".doc"
                Exit Select
            Case ".docx"
                contenttype = ".docx"
                Exit Select
            Case ".xls"
                contenttype = ".xls"
                Exit Select
            Case ".xlsx"
                contenttype = ".xlsx"
                Exit Select
            Case ".jpg"
                contenttype = ".jpg"
                Exit Select
            Case ".png"
                contenttype = ".png"
                Exit Select
            Case ".gif"
                contenttype = ".gif"
                Exit Select
            Case ".pdf"
                contenttype = ".pdf"
                Exit Select
        End Select


        Dim filePath1 As String = FileUpload2.PostedFile.FileName
        Dim filename1 As String = Path.GetFileName(filePath1)
        Dim ext1 As String = Path.GetExtension(filename1)
        Dim contenttype1 As String = String.Empty

        'Set the contenttype based on File Extension
        Select Case ext1
            Case ".doc"
                contenttype1 = ".doc"
                Exit Select
            Case ".docx"
                contenttype1 = ".docx"
                Exit Select
            Case ".xls"
                contenttype1 = ".xls"
                Exit Select
            Case ".xlsx"
                contenttype1 = ".xlsx"
                Exit Select
            Case ".jpg"
                contenttype1 = ".jpg"
                Exit Select
            Case ".png"
                contenttype1 = ".png"
                Exit Select
            Case ".gif"
                contenttype1 = ".gif"
                Exit Select
            Case ".pdf"
                contenttype1 = ".pdf"
                Exit Select
        End Select

        If contenttype <> String.Empty And contenttype1 <> String.Empty Then
            Dim fs As Stream = FileUpload1.PostedFile.InputStream
            Dim br As New BinaryReader(fs)
            Dim bytes As Byte() = br.ReadBytes(fs.Length)

            Dim fs1 As Stream = FileUpload2.PostedFile.InputStream
            Dim br1 As New BinaryReader(fs1)
            Dim bytes1 As Byte() = br1.ReadBytes(fs1.Length)

            'insert the file into database 
            Dim strQuery As String = " insert into InsurancePolicies (PolicyNumber, Expiry, Notes, ContentType, Data, Participant, DateUploaded, Used,Amount,InsuranceCompany, A_PolicyNumber, A_Expiry, A_Notes, A_ContentType, A_Data, A_Amount,A_InsuranceCompany)" _
            & " values (@policynumber,@expiry,@Notes, @ContentType, @Data, @participant, getdate(), '0',@amount,@insurancecompany,   @PolicyNumber1, @Expiry1, @Notes1, @ContentType1, @Data1, @Amount1,@InsuranceCompany1)"
            Dim cmd As New SqlCommand(strQuery)
            cmd.Parameters.Add("@policynumber", SqlDbType.VarChar).Value = txtpolicynumber.Text
            cmd.Parameters.Add("@expiry", SqlDbType.Date).Value = txtexpiry.Text
            cmd.Parameters.Add("@ContentType", SqlDbType.VarChar).Value = contenttype
            cmd.Parameters.Add("@Data", SqlDbType.Binary).Value = bytes
            cmd.Parameters.Add("@notes", SqlDbType.VarChar).Value = txtnotes.Text
            cmd.Parameters.Add("@participant", SqlDbType.VarChar).Value = cmbparticipant.SelectedItem.Value
            cmd.Parameters.Add("@amount", SqlDbType.Money).Value = txtamount.Text
            cmd.Parameters.Add("@insurancecompany", SqlDbType.VarChar).Value = txtinsurancecompany.Text

            cmd.Parameters.Add("@policynumber1", SqlDbType.VarChar).Value = txtpolicynumber0.Text
            cmd.Parameters.Add("@expiry1", SqlDbType.Date).Value = txtexpiry1.Text
            cmd.Parameters.Add("@ContentType1", SqlDbType.VarChar).Value = contenttype1
            cmd.Parameters.Add("@Data1", SqlDbType.Binary).Value = bytes1
            cmd.Parameters.Add("@notes1", SqlDbType.VarChar).Value = txtnotes0.Text
            cmd.Parameters.Add("@amount1", SqlDbType.Money).Value = txtamount0.Text
            cmd.Parameters.Add("@insurancecompany1", SqlDbType.VarChar).Value = txtinsurancecompany0.Text
            InsertUpdateData(cmd)
            Session("finish") = "true"
            Response.Redirect(Request.RawUrl)
        Else

            msgbox("File format not recognised." _
            & " Upload Image/Word/PDF/Excel formats")
        End If

    End Sub
    Public Sub update()



        Dim filePath As String = FileUpload1.PostedFile.FileName
        Dim filename As String = Path.GetFileName(filePath)
        Dim ext As String = Path.GetExtension(filename)
        Dim contenttype As String = String.Empty

        'Set the contenttype based on File Extension
        Select Case ext
            Case ".doc"
                contenttype = ".doc"
                Exit Select
            Case ".docx"
                contenttype = ".docx"
                Exit Select
            Case ".xls"
                contenttype = ".xls"
                Exit Select
            Case ".xlsx"
                contenttype = ".xlsx"
                Exit Select
            Case ".jpg"
                contenttype = ".jpg"
                Exit Select
            Case ".png"
                contenttype = ".png"
                Exit Select
            Case ".gif"
                contenttype = ".gif"
                Exit Select
            Case ".pdf"
                contenttype = ".pdf"
                Exit Select
        End Select


        Dim filePath1 As String = FileUpload2.PostedFile.FileName
        Dim filename1 As String = Path.GetFileName(filePath1)
        Dim ext1 As String = Path.GetExtension(filename1)
        Dim contenttype1 As String = String.Empty

        'Set the contenttype based on File Extension
        Select Case ext1
            Case ".doc"
                contenttype1 = ".doc"
                Exit Select
            Case ".docx"
                contenttype1 = ".docx"
                Exit Select
            Case ".xls"
                contenttype1 = ".xls"
                Exit Select
            Case ".xlsx"
                contenttype1 = ".xlsx"
                Exit Select
            Case ".jpg"
                contenttype1 = ".jpg"
                Exit Select
            Case ".png"
                contenttype1 = ".png"
                Exit Select
            Case ".gif"
                contenttype1 = ".gif"
                Exit Select
            Case ".pdf"
                contenttype1 = ".pdf"
                Exit Select
        End Select

        ' If contenttype <> String.Empty And contenttype1 <> String.Empty Then
        Dim fs As Stream = FileUpload1.PostedFile.InputStream
            Dim br As New BinaryReader(fs)
            Dim bytes As Byte() = br.ReadBytes(fs.Length)

            Dim fs1 As Stream = FileUpload2.PostedFile.InputStream
            Dim br1 As New BinaryReader(fs1)
            Dim bytes1 As Byte() = br1.ReadBytes(fs1.Length)

            'insert the file into database 
            Dim strQuery As String = "update InsurancePolicies set PolicyNumber=@policynumber, Expiry=@expiry, Notes=@Notes, ContentType=@ContentType, Data=@Data, Participant= @participant, DateUploaded=getdate(), Amount=@amount,InsuranceCompany=@insurancecompany, A_PolicyNumber=@PolicyNumber1, A_Expiry=@Expiry1, A_Notes=@Notes1, A_ContentType=@ContentType1, A_Data=@Data1, A_Amount=@Amount1,A_InsuranceCompany=@InsuranceCompany1 where id='" + lblid.Text + "'"
            Dim cmd As New SqlCommand(strQuery)
            cmd.Parameters.Add("@policynumber", SqlDbType.VarChar).Value = txtpolicynumber.Text
            cmd.Parameters.Add("@expiry", SqlDbType.Date).Value = txtexpiry.Text
            cmd.Parameters.Add("@ContentType", SqlDbType.VarChar).Value = contenttype
            cmd.Parameters.Add("@Data", SqlDbType.Binary).Value = bytes
            cmd.Parameters.Add("@notes", SqlDbType.VarChar).Value = txtnotes.Text
            cmd.Parameters.Add("@participant", SqlDbType.VarChar).Value = cmbparticipant.SelectedItem.Value
            cmd.Parameters.Add("@amount", SqlDbType.Money).Value = txtamount.Text
            cmd.Parameters.Add("@insurancecompany", SqlDbType.VarChar).Value = txtinsurancecompany.Text

            cmd.Parameters.Add("@policynumber1", SqlDbType.VarChar).Value = txtpolicynumber0.Text
            cmd.Parameters.Add("@expiry1", SqlDbType.Date).Value = txtexpiry1.Text
            cmd.Parameters.Add("@ContentType1", SqlDbType.VarChar).Value = contenttype1
            cmd.Parameters.Add("@Data1", SqlDbType.Binary).Value = bytes1
            cmd.Parameters.Add("@notes1", SqlDbType.VarChar).Value = txtnotes0.Text
            cmd.Parameters.Add("@amount1", SqlDbType.Money).Value = txtamount0.Text
            cmd.Parameters.Add("@insurancecompany1", SqlDbType.VarChar).Value = txtinsurancecompany0.Text
            InsertUpdateData(cmd)
        Session("finish") = "update"
        Response.Redirect(Request.RawUrl)

        'Else

        '    msgbox("File format not recognised." _
        '    & " Upload Image/Word/PDF/Excel formats")
        'End If

    End Sub

    Public Function InsertUpdateData(ByVal cmd As SqlCommand) As Boolean
        Dim strConnString As String = (System.Configuration.ConfigurationManager.AppSettings("connpath"))
        Dim con As New SqlConnection(strConnString)
        cmd.CommandType = CommandType.Text
        cmd.Connection = con
        Try
            con.Open()
            cmd.ExecuteNonQuery()
            Return True
        Catch ex As Exception
            Response.Write(ex.Message)
            Return False
        Finally
            con.Close()
            con.Dispose()
        End Try
    End Function
    Public Function fidelityexist(policynumber As String, policynumber2 As String) As Boolean
        cmd = New SqlCommand("select * from insurancepolicies where PolicyNumber='" + policynumber + "' or policynumber='" + policynumber2 + "'", cn)
        Dim ds As New DataSet
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "Para_Security_Type")
        If ds.Tables(0).Rows.Count > 0 Then
            Return True
        Else
            Return False
        End If
    End Function

    Protected Sub getSecurities_Types()
        Try
            cmd = New SqlCommand("select id, InsuranceCompany,PolicyNumber, Expiry,  format(Amount,'#,0.00') as [Amount] ,A_insuranceCompany ,A_PolicyNumber , A_Expiry , format(A_Amount,'#,0.00') as A_Amount,Participant, DateUploaded from insurancepolicies", cn)
            Dim ds As New DataSet
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "Para_Security_Type")
            If ds.Tables(0).Rows.Count > 0 Then
                ASPxGridView2.DataSource = ds.Tables(0)
            Else
                ASPxGridView2.DataSource = Nothing
            End If
            ASPxGridView2.DataBind()
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub loadparticipants()
        cmd = New SqlCommand("  select company_name, company_code from client_companies where company_type='WAREHOUSE'", cn)
        Dim ds As New DataSet
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "Para_Security_Type")
        If ds.Tables(0).Rows.Count > 0 Then
            cmbparticipant.DataSource = ds
            cmbparticipant.TextField = "company_name"
            cmbparticipant.ValueField = "company_code"
            cmbparticipant.DataBind()
        End If
    End Sub

    Private Sub ASPxGridView2_RowCommand(sender As Object, e As ASPxGridViewRowCommandEventArgs) Handles ASPxGridView2.RowCommand
        Dim id As String = e.KeyValue.ToString
        If e.CommandArgs.CommandName.ToString = "Edit" Then
            getinfortoedit(id)
        End If
    End Sub
    Public Sub getinfortoedit(id As String)
        cmd = New SqlCommand("select * from insurancepolicies where id='" + id + "'", cn)
        Dim ds As New DataSet
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "pc")
        If ds.Tables(0).Rows.Count > 0 Then
            txtinsurancecompany.Text = ds.Tables(0).Rows(0).Item("InsuranceCompany").ToString
            txtpolicynumber.Text = ds.Tables(0).Rows(0).Item("PolicyNumber").ToString
            txtexpiry.Value = ds.Tables(0).Rows(0).Item("Expiry").ToString
            txtnotes.Text = ds.Tables(0).Rows(0).Item("Notes").ToString
            Dim am As Decimal = ds.Tables(0).Rows(0).Item("Amount").ToString
            txtamount.Text = am.ToString("N")

            txtinsurancecompany0.Text = ds.Tables(0).Rows(0).Item("A_InsuranceCompany").ToString
            txtpolicynumber0.Text = ds.Tables(0).Rows(0).Item("A_PolicyNumber").ToString
            txtexpiry1.Value = ds.Tables(0).Rows(0).Item("A_Expiry").ToString
            txtnotes0.Text = ds.Tables(0).Rows(0).Item("A_Notes").ToString
            Dim aam As Decimal = ds.Tables(0).Rows(0).Item("A_Amount").ToString
            txtamount0.Text = aam.ToString("N")

            ASPxButton7.Text = "Update"
            lblid.Text = id
        End If
    End Sub
End Class
