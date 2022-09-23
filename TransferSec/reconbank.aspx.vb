Imports System.Collections.Generic
Imports System.IO
Imports DevExpress.Web.ASPxEditors
Imports DevExpress.Web.ASPxGridView

Partial Class TransferSec_reconbank




    Inherits System.Web.UI.Page
    Dim constr As String = (System.Configuration.ConfigurationManager.AppSettings("connpath"))
    Dim cn As New SqlConnection(constr)
    Dim adp As SqlDataAdapter

    Dim cmd As SqlCommand
    Public autgen As String
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
            If Session("finish") = "yes" Then
                Session("finish") = ""

                Page.MaintainScrollPositionOnPostBack = True
                msgbox(Session("msg"))
                Session("msg") = ""
            End If

            Page.MaintainScrollPositionOnPostBack = True
            If (Not IsPostBack) Then
                checkSessionState()

            Else
                'getpending(dtfrom.Date)

            End If

        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub



    Public Shared Function CreateRandomPassword(ByVal PasswordLength As Integer) As String
        Dim _allowedChars As String = "0123456789"
        Dim randomNumber As New Random()
        Dim chars(PasswordLength - 1) As Char
        Dim allowedCharCount As Integer = _allowedChars.Length
        For i As Integer = 0 To PasswordLength - 1
            chars(i) = _allowedChars.Chars(CInt(Fix((_allowedChars.Length) * randomNumber.NextDouble())))
        Next i
        Return New String(chars)
    End Function

    Public Sub getpending(dt As String)
        Dim dsport As New DataSet
        'cmd = New SqlCommand("declare @date date='" + dt + "' select BankAccount+''+c.currency+''+convert(nvarchar(50),@date)+''+pb.AssetManagerCode as ID,pb.AssetManagerCode,  BankAccount  as Account, pb.AccountName, c.Currency as [Currency],isnull(sum(Amount),0) as [Ctrade Balance], isnull(a.Balance,0) as [BankBalance], c.Currency,isnull(sum(Amount),0)-isnull(a.Balance,0) as [Variance]  from   para_assetManager_Banks pb,cashtrans c   left outer join  acc_balz a on c.BankAccount=a.AccountNumber and convert(date,a.datecreated)=@date  where BankAccount+''+c.currency not in (select Account from recon_Approval where convert(date, [ReconDate])='" + dt + "') and convert(date, c.datecreated)<=@date and pb.AccountNo=c.BankAccount and BankAccount+''+c.currency+''+convert(nvarchar(50),@date)+''+pb.AssetManagerCode not in (select ID from Bank_Recon_Approval where [Status]  in ('APPROVED','PENDING')) group by c.Currency, BankAccount, a.balance, pb.AccountName, pb.AssetManagerCode ", cn)
        cmd = New SqlCommand("declare @date date='" + dt + "' select pb.AccountNo+''+PB.Currency+''+convert(nvarchar(50),@date)+''+PB.AssetManagerCode AS [ID], pb.AssetManagerCode ,  BankAccount as [Account], pb.AccountName, pb.Currency, isnull(convert(numeric(18,2),sum(c.Amount)),0) as [Ctrade Balance],isnull(convert(numeric(18,2),a.Balance),0) as [BankBalance], pb.Currency ,isnull(convert(numeric(18,2),sum(c.Amount)),0) -isnull(convert(numeric(18,2),a.Balance),0) as [Variance]    from cashtrans c inner join para_assetManager_Banks pb on pb.AccountNo = c.BankAccount and pb.Currency=c.Currency left outer join acc_balz a on a.AccountNumber=pb.AccountNo and a.Currency=pb.Currency and convert(date, a.datecreated)=@date   where convert(date, c.datecreated)<=@date and  pb.AccountNo +''+pb.currency+''+convert(nvarchar(50),@date)+''+pb.AssetManagerCode not in (select ID from Bank_Recon_Approval where [Status]  in ('APPROVED','PENDING'))  group by pb.AccountNo , pb.AccountName , pb.Currency , pb.AssetManagerCode , c.BankAccount, a.Balance ", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(dsport, "trans")
        If (dsport.Tables(0).Rows.Count > 0) Then
            grddocuments.DataSource = dsport
            grddocuments.DataBind()
        Else
            grddocuments.DataSource = Nothing
            grddocuments.DataBind()
        End If
    End Sub
    Public Function variance(dt As String, idd As String) As Decimal
        Dim dsport As New DataSet
        cmd = New SqlCommand("declare @date date='" + dt + "' select variance from (select pb.AccountNo+''+PB.Currency+''+convert(nvarchar(50),@date)+''+PB.AssetManagerCode AS [ID], pb.AssetManagerCode ,  BankAccount as [Account], pb.AccountName, pb.Currency, isnull(convert(numeric(18,2),sum(c.Amount)),0) as [Ctrade Balance],isnull(convert(numeric(18,2),a.Balance),0) as [BankBalance], isnull(convert(numeric(18,2),sum(c.Amount)),0) -isnull(convert(numeric(18,2),a.Balance),0) as [Variance]    from cashtrans c inner join para_assetManager_Banks pb on pb.AccountNo = c.BankAccount and pb.Currency=c.Currency left outer join acc_balz a on a.AccountNumber=pb.AccountNo and a.Currency=pb.Currency and convert(date, a.datecreated)=@date   where convert(date, c.datecreated)<=@date and  pb.AccountNo +''+pb.currency+''+convert(nvarchar(50),@date)+''+pb.AssetManagerCode not in (select ID from Bank_Recon_Approval where [Status]  in ('APPROVED','PENDING'))  group by pb.AccountNo , pb.AccountName , pb.Currency , pb.AssetManagerCode , c.BankAccount, a.Balance  ) j where j.id='" + idd + "'", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(dsport, "trans")
        If (dsport.Tables(0).Rows.Count > 0) Then
            Return dsport.Tables(0).Rows(0).Item("variance").ToString()
        Else
            Return 1
        End If
    End Function
    Public Sub getpending2(dt As String)
        Dim dsport As New DataSet
        cmd = New SqlCommand("declare @date date='" + dt + "' select pb.AccountNo+''+PB.Currency+''+convert(nvarchar(50),@date)+''+PB.AssetManagerCode AS [ID], pb.AssetManagerCode ,  BankAccount as [Account], pb.AccountName, pb.Currency, isnull(convert(numeric(18,2),sum(c.Amount)),0) as [Ctrade Balance],isnull(convert(numeric(18,2),a.Balance),0) as [BankBalance], pb.Currency ,isnull(convert(numeric(18,2),sum(c.Amount)),0) -isnull(convert(numeric(18,2),a.Balance),0) as [Variance]    from cashtrans c inner join para_assetManager_Banks pb on pb.AccountNo = c.BankAccount and pb.Currency=c.Currency left outer join acc_balz a on a.AccountNumber=pb.AccountNo and a.Currency=pb.Currency and convert(date, a.datecreated)=@date   where convert(date, c.datecreated)<=@date and  pb.AccountNo +''+pb.currency+''+convert(nvarchar(50),@date)+''+pb.AssetManagerCode not in (select ID from Bank_Recon_Approval where [Status]  in ('APPROVED','PENDING'))  group by pb.AccountNo , pb.AccountName , pb.Currency , pb.AssetManagerCode , c.BankAccount, a.Balance  ", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(dsport, "trans")
        If (dsport.Tables(0).Rows.Count > 0) Then
            ASPxGridView1.DataSource = dsport
            ASPxGridView1.DataBind()
        Else
            ASPxGridView1.DataSource = Nothing
            ASPxGridView1.DataBind()
        End If
    End Sub
    Public Function pendtrans(idn As String) As DataSet
        Dim dsport As New DataSet
        cmd = New SqlCommand("select email, c.Transtype,c.Amount  from Accounts_Clients A, CashTrans_Audit C where a.CDS_Number=c.CDS_Number and c.id='" + idn + "'", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(dsport, "trans")
        If (dsport.Tables(0).Rows.Count > 0) Then
            Return dsport
        Else
            Return Nothing
        End If

    End Function

    Public Function GetData(ByVal cmd As SqlCommand) As DataTable
        Dim dt As New DataTable
        Dim strConnString As String = (System.Configuration.ConfigurationManager.AppSettings("connpath"))
        Dim con As New SqlConnection(strConnString)
        Dim sda As New SqlDataAdapter
        cmd.CommandType = CommandType.Text
        cmd.Connection = con
        '  Try
        con.Open()
        sda.SelectCommand = cmd
        sda.Fill(dt)
        Return dt
        'Catch ex As Exception
        '    Response.Write(ex.Message)
        '    Return Nothing
        'Finally
        '    con.Close()
        '    sda.Dispose()
        '    con.Dispose()
        'End Try
    End Function
    Public Sub pd(id As String, transtype As String)
        Dim strQuery As String = "select 'Payment Proof'  + Extension as nm, [data],Extension from CashTrans_Audit where ID='" + id + "'"
        Dim cmd As SqlCommand = New SqlCommand(strQuery)
        cmd.Parameters.Add("@id", SqlDbType.Int).Value = 4
        Dim dt As DataTable = GetData(cmd)
        If dt IsNot Nothing Then
            download(dt)
        End If
    End Sub
    Public Sub word(id As String, transtype As String)
        Dim strQuery As String = "select 'Payment Proof'  + Extension as nm, [data],Extension from CashTrans_Audit where ID='" + id + "'"
        Dim cmd As SqlCommand = New SqlCommand(strQuery)
        cmd.Parameters.Add("@id", SqlDbType.Int).Value = 1
        Dim dt As DataTable = GetData(cmd)
        If dt IsNot Nothing Then
            download(dt)
        End If
    End Sub
    Public Sub xls(id As String, transtype As String)
        Dim strQuery As String = "select 'Payment Proof'  + Extension as nm, [data],Extension from CashTrans_Audit where ID='" + id + "'"
        Dim cmd As SqlCommand = New SqlCommand(strQuery)
        cmd.Parameters.Add("@id", SqlDbType.Int).Value = 2
        Dim dt As DataTable = GetData(cmd)
        If dt IsNot Nothing Then
            download(dt)
        End If
    End Sub
    Public Sub Img(id As String, transtype As String)
        Dim strQuery As String = "select 'Payment Proof' + Extension as nm, [data],Extension from CashTrans_Audit where ID='" + id + "'"
        Dim cmd As SqlCommand = New SqlCommand(strQuery)
        cmd.Parameters.Add("@id", SqlDbType.Int).Value = 3
        Dim dt As DataTable = GetData(cmd)
        If dt IsNot Nothing Then
            download(dt)
        End If
    End Sub
    Public Function apptype(type As String) As String
        If type = ".png" Then
            Return "Aplication/vnd.png"
        ElseIf type = ".doc" Or type = ".docx" Then
            Return "Aplication/vnd.ms-word"
        ElseIf type = ".xlsx" Or type = ".xls" Then
            Return "Aplication/vnd.ms-excel"
        ElseIf type = ".jpg" Or type = ".jpeg" Then
            Return "Aplication/vnd.jpg"
        ElseIf type = ".gif" Then
            Return "Aplication/vnd.gif"
        End If
    End Function
    Protected Sub download(ByVal dt As DataTable)
        Dim bytes() As Byte = CType(dt.Rows(0)("Data"), Byte())
        Response.Buffer = True
        Response.Charset = ""
        Response.Cache.SetCacheability(HttpCacheability.NoCache)
        Response.ContentType = apptype(dt.Rows(0)("Extension").ToString())
        Response.AddHeader("content-disposition", "attachment;filename=""" + dt.Rows(0)("nm").ToString() + "")
        Response.BinaryWrite(bytes)
        Response.Flush()
        Response.End()
    End Sub
    Private Sub grddocuments_RowCommand(sender As Object, e As ASPxGridViewRowCommandEventArgs) Handles grddocuments.RowCommand
        Dim id As String = e.KeyValue.ToString
        If e.CommandArgs.CommandName.ToString = "Reconcile" Then

            If Math.Round(variance(dtfrom.Date, id), 2) = 0 Then
                '"declare @date date='" + dt + "' select BankAccount+''+c.currency as ID,pb.AssetManagerCode,  BankAccount  as Account, pb.AccountName, c.Currency as [Currency],isnull(sum(Amount),0) as [Ctrade Balance], isnull(a.Balance,0) as [BankBalance], c.Currency,isnull(sum(Amount),0)-isnull(a.Balance,0) as [Variance]  from   para_assetManager_Banks pb,cashtrans c   left outer join  acc_balz a on c.BankAccount=a.AccountNumber and convert(date,a.datecreated)=@date  where BankAccount+''+c.currency not in (select Account from recon_Approval where convert(date, [ReconDate])='" + dt + "') and convert(date, c.datecreated)<=@date and pb.AccountNo=c.BankAccount group by c.Currency, BankAccount, a.balance, pb.AccountName, pb.AssetManagerCode"

                cmd = New SqlCommand("declare @date date='" + dtfrom.Date.ToString + "' insert into Bank_Recon_Approval ([ID],[AssetManagerCode],[Account],[AccountName],[Currency],[Ctrade Balance],[BankBalance],[Variance],[Status],[ApprovedBy],[ApprovedDate],[SentBy],[SentDate], ForDate) select *, 'PENDING', NULL, NULL, NULL, getdate(), '" + dtfrom.Date.ToString + "' from  (select pb.AccountNo+''+PB.Currency+''+convert(nvarchar(50),@date)+''+PB.AssetManagerCode AS [ID], pb.AssetManagerCode ,  BankAccount as [Account], pb.AccountName, pb.Currency, isnull(convert(numeric(18,2),sum(c.Amount)),0) as [Ctrade Balance],isnull(convert(numeric(18,2),a.Balance),0) as [BankBalance],isnull(convert(numeric(18,2),sum(c.Amount)),0) -isnull(convert(numeric(18,2),a.Balance),0) as [Variance]    from cashtrans c inner join para_assetManager_Banks pb on pb.AccountNo = c.BankAccount and pb.Currency=c.Currency left outer join acc_balz a on a.AccountNumber=pb.AccountNo and a.Currency=pb.Currency and convert(date, a.datecreated)=@date   where convert(date, c.datecreated)<=@date and  pb.AccountNo +''+pb.currency+''+convert(nvarchar(50),@date)+''+pb.AssetManagerCode not in (select ID from Bank_Recon_Approval where [Status]  in ('APPROVED','PENDING'))  group by pb.AccountNo , pb.AccountName , pb.Currency , pb.AssetManagerCode , c.BankAccount, a.Balance ) d where d.ID='" + id + "'", cn)
                ' cmd = New SqlCommand("insert into recon_Approval (ReconDate, Account, ApprovedBy, ApprovedDate) values ('" + dtfrom.Date + "', '" + id + "','" + Session("Username") + "',getdate())", cn)
                If (cn.State = ConnectionState.Open) Then
                    cn.Close()
                End If
                cn.Open()
                cmd.ExecuteNonQuery()
                cn.Close()
                getpending(dtfrom.Date)
                msgbox("Successfully Sent for Approval")

            Else
                msgbox("Cannot authorize when there is a variance!")
            End If



        End If

    End Sub

    Protected Sub btnSaveContract2_Click(sender As Object, e As EventArgs) Handles btnSaveContract2.Click
        ' Try


        getpending2(dtfrom.Date)
        If cmbexport.SelectedItem.Text = "EXCEL" Then
            ASPxGridViewExporter1.WriteXlsToResponse()
        ElseIf cmbexport.SelectedItem.Text = "PDF" Then
            ASPxGridViewExporter1.WritePdfToResponse()
        ElseIf cmbexport.SelectedItem.Text = "RTF" Then
            ASPxGridViewExporter1.WriteRtfToResponse()
        ElseIf cmbexport.SelectedItem.Text = "CSV" Then
            ASPxGridViewExporter1.WriteCsvToResponse()
        End If

        'Catch ex As Exception
        '    msgbox(ex.Message)
        'End Try
    End Sub
    Protected Sub dtfrom_DateChanged(sender As Object, e As EventArgs) Handles dtfrom.DateChanged
        getpending(dtfrom.Date)
    End Sub
    Protected Sub chkSelectAll_CheckedChanged(sender As Object, e As EventArgs) Handles chkSelectAll.CheckedChanged
        Dim myGridView As New ASPxGridView
        myGridView = grddocuments
        If chkSelectAll.Checked = True Then
            Dim keys As List(Of Object) = myGridView.GetCurrentPageRowValues(New String() {"ID"})
            For Each key As Object In keys
                Dim chk As ASPxCheckBox = TryCast(myGridView.FindRowCellTemplateControlByKey(key, TryCast(myGridView.Columns("Selec"), GridViewDataColumn), "chk1"), ASPxCheckBox)
                chk.Checked = True
            Next
        Else
            Dim keys As List(Of Object) = myGridView.GetCurrentPageRowValues(New String() {"ID"})
            For Each key As Object In keys
                Dim chk As ASPxCheckBox = TryCast(myGridView.FindRowCellTemplateControlByKey(key, TryCast(myGridView.Columns("Selec"), GridViewDataColumn), "chk1"), ASPxCheckBox)
                chk.Checked = False
            Next
        End If
    End Sub
    Protected Sub btnupload2_Click(sender As Object, e As EventArgs) Handles btnupload2.Click
        If ISSelectedData() = False Then
            msgbox("Select Records to post")
            Exit Sub
        End If
        Dim keys As List(Of Object) = grddocuments.GetCurrentPageRowValues(New String() {"ID"})
        For Each key As Object In keys
            Dim chk As ASPxCheckBox = TryCast(grddocuments.FindRowCellTemplateControlByKey(key, TryCast(grddocuments.Columns("Selec"), GridViewDataColumn), "chk1"), ASPxCheckBox)
            'Dim check As Boolean = chk.Checked

            If chk.Checked = True Then

                Dim MyID As String = ""
                MyID = key
                If Math.Round(variance(dtfrom.Date, MyID), 2) = 0 Then
                    cmd = New SqlCommand("declare @date date='" + dtfrom.Date.ToString + "' insert into Bank_Recon_Approval ([ID],[AssetManagerCode],[Account],[AccountName],[Currency],[Ctrade Balance],[BankBalance],[Variance],[Status],[ApprovedBy],[ApprovedDate],[SentBy],[SentDate], ForDate) select *, 'PENDING', NULL, NULL, NULL, getdate(), '" + dtfrom.Date.ToString + "' from  (select pb.AccountNo+''+PB.Currency+''+convert(nvarchar(50),@date)+''+PB.AssetManagerCode AS [ID], pb.AssetManagerCode ,  BankAccount as [Account], pb.AccountName, pb.Currency, isnull(convert(numeric(18,2),sum(c.Amount)),0) as [Ctrade Balance],isnull(convert(numeric(18,2),a.Balance),0) as [BankBalance],isnull(convert(numeric(18,2),sum(c.Amount)),0) -isnull(convert(numeric(18,2),a.Balance),0) as [Variance]    from cashtrans c inner join para_assetManager_Banks pb on pb.AccountNo = c.BankAccount and pb.Currency=c.Currency left outer join acc_balz a on a.AccountNumber=pb.AccountNo and a.Currency=pb.Currency and convert(date, a.datecreated)=@date   where convert(date, c.datecreated)<=@date and  pb.AccountNo +''+pb.currency+''+convert(nvarchar(50),@date)+''+pb.AssetManagerCode not in (select ID from Bank_Recon_Approval where [Status]  in ('APPROVED','PENDING'))  group by pb.AccountNo , pb.AccountName , pb.Currency , pb.AssetManagerCode , c.BankAccount, a.Balance ) d where d.ID='" + MyID + "'", cn)
                    If (cn.State = ConnectionState.Open) Then
                        cn.Close()
                    End If
                    cn.Open()
                    cmd.ExecuteNonQuery()
                    cn.Close()
                Else
                End If
            Else
                ' msgbox("YES")
            End If
        Next
        getpending(dtfrom.Date)
        chkSelectAll.Checked = False
        msgbox("Successfully Sent for Approval")
    End Sub
    Private Function ISSelectedData() As Boolean
        Dim myGridView As New ASPxGridView

        myGridView = grddocuments
        Dim SelectedCount As Long = 0
        Dim keys As List(Of Object) = myGridView.GetCurrentPageRowValues(New String() {"ID"})
        For Each key As Object In keys
            Dim chk As ASPxCheckBox = TryCast(myGridView.FindRowCellTemplateControlByKey(key, TryCast(myGridView.Columns("Selec"), GridViewDataColumn), "chk1"), ASPxCheckBox)
            If chk.Checked = True Then
                SelectedCount += 1
            End If
        Next
        If SelectedCount > 0 Then
            Return True
        Else
            Return False
        End If
    End Function
    Protected Sub grddocuments_DataBinding(sender As Object, e As EventArgs) Handles grddocuments.DataBinding
        grddocuments.DataSource = getpendingDSET(dtfrom.Date)
    End Sub
    Function getpendingDSET(dt As String) As DataSet
        Dim dsport As New DataSet
        'cmd = New SqlCommand("declare @date date='" + dt + "' select BankAccount+''+c.currency+''+convert(nvarchar(50),@date)+''+pb.AssetManagerCode as ID,pb.AssetManagerCode,  BankAccount  as Account, pb.AccountName, c.Currency as [Currency],isnull(sum(Amount),0) as [Ctrade Balance], isnull(a.Balance,0) as [BankBalance], c.Currency,isnull(sum(Amount),0)-isnull(a.Balance,0) as [Variance]  from   para_assetManager_Banks pb,cashtrans c   left outer join  acc_balz a on c.BankAccount=a.AccountNumber and convert(date,a.datecreated)=@date  where BankAccount+''+c.currency not in (select Account from recon_Approval where convert(date, [ReconDate])='" + dt + "') and convert(date, c.datecreated)<=@date and pb.AccountNo=c.BankAccount and BankAccount+''+c.currency+''+convert(nvarchar(50),@date)+''+pb.AssetManagerCode not in (select ID from Bank_Recon_Approval where [Status]  in ('APPROVED','PENDING')) group by c.Currency, BankAccount, a.balance, pb.AccountName, pb.AssetManagerCode ", cn)
        cmd = New SqlCommand("declare @date date='" + dt + "' select pb.AccountNo+''+PB.Currency+''+convert(nvarchar(50),@date)+''+PB.AssetManagerCode AS [ID], pb.AssetManagerCode ,  BankAccount as [Account], pb.AccountName, pb.Currency, isnull(convert(numeric(18,2),sum(c.Amount)),0) as [Ctrade Balance],isnull(convert(numeric(18,2),a.Balance),0) as [BankBalance], pb.Currency ,isnull(convert(numeric(18,2),sum(c.Amount)),0) -isnull(convert(numeric(18,2),a.Balance),0) as [Variance]    from cashtrans c inner join para_assetManager_Banks pb on pb.AccountNo = c.BankAccount and pb.Currency=c.Currency left outer join acc_balz a on a.AccountNumber=pb.AccountNo and a.Currency=pb.Currency and convert(date, a.datecreated)=@date   where convert(date, c.datecreated)<=@date and  pb.AccountNo +''+pb.currency+''+convert(nvarchar(50),@date)+''+pb.AssetManagerCode not in (select ID from Bank_Recon_Approval where [Status]  in ('APPROVED','PENDING'))  group by pb.AccountNo , pb.AccountName , pb.Currency , pb.AssetManagerCode , c.BankAccount, a.Balance ", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(dsport, "trans")
        Return dsport
    End Function
End Class