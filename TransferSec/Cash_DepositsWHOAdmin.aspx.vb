Imports System.IO

Partial Class Enquiries_Cash_DepositsWHOAdmin
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

                GetCompany(txtClientNo.Text)
                EWR.Visible = True
                cmbCounter.Visible = True
                txtcharges.Visible = True
                EWR0.Visible = True

            End If
            If Session("finish") = "true" Then
                Session("finish") = ""
                msgbox("Deposit Saved")
            End If


        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub ClearData()
        Try
            txtClientNo.Text = ""
            txtTitle.Text = ""
            txtIDno.Text = ""
            txtForenames.Text = ""
            txtSurname.Text = ""
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Protected Sub ASPxButton2_Click(sender As Object, e As EventArgs) Handles ASPxButton2.Click
        Try
            ' If (txtClientNameSearch.Text <> "") Then
            Dim ds As New DataSet
            cmd = New SqlCommand("select cds_number+' '+forenames+' '+surname as namess from Accounts_Clients where cds_number+' '+surname+' '+forenames like '%" & txtClientNameSearch.Text & "%' and AccountState='A' order by cds_number", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "Accounts_Clients")
            If (ds.Tables(0).Rows.Count > 0) Then
                lstNamesSearch.DataSource = ds.Tables(0)
                lstNamesSearch.TextField = "namess"
                lstNamesSearch.ValueField = "namess"
                lstNamesSearch.DataBind()
            Else
                lstNamesSearch.Items.Clear()
            End If
            '  End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub lstNamesSearch_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstNamesSearch.SelectedIndexChanged

        If (lstNamesSearch.Items.Count > 0) Then
            Dim ds As New DataSet
            cmd = New SqlCommand("select * from Accounts_Clients where cds_number+' '+forenames+' '+surname = '" & lstNamesSearch.SelectedItem.Text & "'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "Accounts_Clients")
            If (ds.Tables(0).Rows.Count > 0) Then
                txtClientNo.Text = ds.Tables(0).Rows(0).Item("cds_number").ToString.ToUpper
                txtTitle.Text = ds.Tables(0).Rows(0).Item("title").ToString.ToUpper
                txtIDno.Text = ds.Tables(0).Rows(0).Item("idnopp").ToString.ToUpper
                txtForenames.Text = ds.Tables(0).Rows(0).Item("forenames").ToString.ToUpper
                txtSurname.Text = ds.Tables(0).Rows(0).Item("surname").ToString.ToUpper
                ' GetCashBal()
                GetCompany(txtClientNo.Text)
            Else
                txtClientNo.Text = ""
                txtTitle.Text = ""
                txtIDno.Text = ""
                txtForenames.Text = ""
                txtSurname.Text = ""

            End If
        End If

    End Sub

    Public Sub GetCashBal()
        Dim ds As New DataSet
        cmd = New SqlCommand("select isnull(sum(Amount),0.0) as total from cashtransCOMB where cds_Number = '" & txtClientNo.Text & "'", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "Accounts_Clients")
        If (ds.Tables(0).Rows.Count > 0) Then
            Dim csh As Decimal = ds.Tables(0).Rows(0).Item("total").ToString
            lblCashBal.Text = csh.ToString("N")
            If lblCashBal.Text > 0 Then
                lblCashBal.ForeColor = Drawing.Color.Green
                lblCashBal0.Visible = False
            Else
                lblCashBal.ForeColor = Drawing.Color.Red
                lblCashBal0.Visible = False
            End If
        End If

    End Sub
    Public Function Document_Upload(str As Stream, Filepath As String, Documentname As String, ext As String, FileName As String, TransactionType As String, AccountNo As String, TransactionRef As String, Data As Byte()) As String
        Dim contenttype As String = String.Empty
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

        If contenttype <> String.Empty Then


            'insert the file into database 
            Dim strQuery As String = "insert into CashTrans_audit ([Description],TransType, Amount, DateCreated, TransStatus , cds_Number, PAID, Reference,Data, Type, Extension) VALUES   ('" + cmbcharge.SelectedItem.Text + "','" + cmbcharge.SelectedItem.Text + "','" & txtAmount.Text & "',GETDATE(),'0','" + txtClientNo.Text + "',NULL, '" + cmbCounter.Value.ToString + "',@Data,'WAREHOUSE UPLOAD','" + contenttype + "')"
            Dim cmd As New SqlCommand(strQuery)
            cmd.Parameters.Add("@Data", SqlDbType.Binary).Value = Data
            Dim m As New Common
            m.InsertUpdateData(cmd)

            Return "Upload Successful"
        Else

            Return "Error Upload"
        End If
    End Function
    Public Sub uploa()

        Dim filePath As String = FileUpload1.PostedFile.FileName
        Dim filename As String = Path.GetFileName(filePath)
        Dim ext As String = Path.GetExtension(filename)
        Dim contenttype As String = String.Empty

        If filePath = "" Then
            msgbox("Please select document to upload!")
            Exit Sub
        End If
        Dim fs As Stream = FileUpload1.PostedFile.InputStream
        Dim br As New BinaryReader(fs)
        Dim bytes As Byte() = br.ReadBytes(fs.Length)



        If Document_Upload(fs, filePath, "", ext, filename, "Withdrawal", "", Session("autogen"), bytes).ToString <> "Upload Successful" Then
            msgbox("Document Upload failed!")
            Exit Sub
        Else
            Session("finish") = "true"
            Response.Redirect(Request.RawUrl)
        End If
    End Sub
    Protected Sub ASPxButton3_Click(sender As Object, e As EventArgs) Handles ASPxButton3.Click
        Try

            If txtClientNo.Text = "" Then
                msgbox("Client Number Cannot Be Blank")
                Exit Sub
            End If

            If Not IsNumeric(txtAmount.Text) Then
                msgbox("Amount must be numbers only")
            End If


            'Dim result As Integer

            'cmd = New SqlCommand("insert into CashTrans_audit ([Description],TransType, Amount, DateCreated, TransStatus , cds_Number, PAID, Reference) VALUES   ('" + cmbcharge.SelectedItem.Text + "','" + cmbcharge.SelectedItem.Text + "','" & txtAmount.Text & "',GETDATE(),'0','" + txtClientNo.Text + "',NULL, '" + cmbCounter.Value.ToString + "')", cn)


            'If (cn.State = ConnectionState.Open) Then
            '    cn.Close()
            'End If
            'cn.Open()
            'result = cmd.ExecuteNonQuery()
            'If result > 0 Then
            '    Session("finish") = "true"
            '    Response.Redirect(Request.RawUrl)

            'End If
            'cn.Close()
            'ClearFields()
            uploa()


        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Public Sub DepositReg()
        Dim result As Integer
        cmd = New SqlCommand("Update Deposits_Reg  Set Flag_Status='Closed' where CDS_Number='" & txtClientNo.Text & "'", cn)
        If (cn.State = ConnectionState.Open) Then
            cn.Close()
        End If
        cn.Open()
        cmd.ExecuteNonQuery()
        Dim cashbal As Double
        Dim ds As New DataSet
        cmd = New SqlCommand("select isnull(sum(Deposit_Amount),0.0) as total from Deposits_Reg where CDS_Number = '" & txtClientNo.Text & "'", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "Accounts_Clients")
        If (ds.Tables(0).Rows.Count > 0) Then
            cashbal = CDbl(ds.Tables(0).Rows(0).Item(0).ToString) + CDbl(txtAmount.Text)
        Else
            cashbal = txtAmount.Text
        End If
        cmd = New SqlCommand("insert into  Deposits_Reg (ORDER_Number, CDS_Number, Deposit_Amount, Date_of_Deposit, Flag_Status) values (999999,'" & txtClientNo.Text & "'," & cashbal & ",GetDate(),'Open')", cn)
        If (cn.State = ConnectionState.Open) Then
            cn.Close()
        End If
        cn.Open()
        result = cmd.ExecuteNonQuery()
    End Sub
    Public Sub ClearFields()
        txtAmount.Text = ""
        txtClientNo.Text = ""
        txtForenames.Text = ""
        txtIDno.Text = ""
        txtSurname.Text = ""
        txtTitle.Text = ""
        cmbCounter.SelectedIndex = -1

    End Sub

    Public Sub GetCompany(holder As String)
        Try
            Dim dsport As New DataSet
            cmd = New SqlCommand("select * from WR where   receiptno in (  select reference from cashtranscomb where CDS_NUMBER='" + holder + "' group by reference having sum(amount)<0) order by id desc", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(dsport, "trans")
            If (dsport.Tables(0).Rows.Count > 0) Then
                cmbCounter.DataSource = dsport

                cmbCounter.DataBind()
            End If
        Catch ex As Exception
            msgbox("Error extracting receipts for holder : " + ex.Message)
        End Try
    End Sub
    Public Function ewrbal(EWRNumber As String, cdsnumber As String, transtype As String) As Decimal
        Dim dsport As New DataSet
        cmd = New SqlCommand("select isnull(sum(amount),0)*-1 as AVAI from CashtransComb where  reference='" + EWRNumber + "' and cds_number='" + cdsnumber + "' and Transtype='" + transtype + "'", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(dsport, "trans")
        If (dsport.Tables(0).Rows.Count > 0) Then
            Return dsport.Tables(0).Rows(0).Item("AVAI").ToString
        End If

    End Function
    Public Sub getchag(EWRNumber As String, cdsnumber As String, transtype As String)
        Dim dsport As New DataSet
        cmd = New SqlCommand("select distinct TransType from CashtransComb where  reference='" + EWRNumber + "' and cds_number='" + cdsnumber + "' and Transtype like '%Warehouse Storage%'", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(dsport, "trans")
        If (dsport.Tables(0).Rows.Count > 0) Then

            cmbcharge.DataSource = dsport
            cmbcharge.TextField = "TransType"
            cmbcharge.ValueField = "TransType"
            cmbcharge.DataBind()
        Else
            cmbcharge.DataSource = Nothing
            cmbcharge.DataBind()
        End If
    End Sub
    Protected Sub cmbCounter_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbCounter.SelectedIndexChanged
        GetCompany(txtClientNo.Text)
        getchag(cmbCounter.Value.ToString, txtClientNo.Text, "")




    End Sub


    Protected Sub cmbcharge_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbcharge.SelectedIndexChanged
        Try
            Dim m As New NaymatBilling
            ' Dim transcharge As Double = m.withdrawalcharges("ENQUIRE", "DEPOSITOR", txtshares.Text, txtewraccountno.Text, cmbparaCompany.Value.ToString)
            Dim charge As Double = Math.Ceiling(ewrbal(cmbCounter.Value.ToString, txtClientNo.Text, cmbcharge.SelectedItem.Value.ToString) - pendingbal(cmbcharge.SelectedItem.Value.ToString, txtClientNo.Text, cmbCounter.Value.ToString))

            ' txtaccumulatedcharges.Text = charge.ToString
            txtcharges.Text = charge.ToString("N")

        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Protected Sub ASPxButton1_Click(sender As Object, e As EventArgs) Handles ASPxButton1.Click
        Dim ds As New DataSet
        cmd = New SqlCommand("select cds_number+' '+forenames+' '+surname as namess from Accounts_Clients where cds_number+' '+surname+' '+forenames like '%" & txtClientNoSe.Text & "%' and AccountState='A' order by cds_number", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "Accounts_Clients")
        If (ds.Tables(0).Rows.Count > 0) Then
            lstNamesSearch.DataSource = ds.Tables(0)
            lstNamesSearch.TextField = "namess"
            lstNamesSearch.ValueField = "namess"
            lstNamesSearch.DataBind()
        Else
            lstNamesSearch.Items.Clear()
        End If
    End Sub
    Public Function pendingbal(type As String, cds_number As String, ref As String) As Decimal
        Dim ds As New DataSet
        cmd = New SqlCommand("select ISNULL(sum(amount),0) as amt from CashTrans_Audit where cds_number='" + cds_number + "' and TransType='" + type + "' and TransStatus='0' and reference='" + ref + "'", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "Accounts_Clients")
        If (ds.Tables(0).Rows.Count > 0) Then
            Return ds.Tables(0).Rows(0).Item("amt").ToString
        Else

            Return 0
        End If

    End Function
End Class
