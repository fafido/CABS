Imports System.Collections.Generic
Imports System.IO
Imports DevExpress.Web.ASPxEditors
Imports DevExpress.Web.ASPxGridView

Partial Class TransferSec_ApproveReAllocation

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

                getpending()




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
    Public Sub getpending()
        Dim dsport As New DataSet
        cmd = New SqlCommand(" select r.id, ad.Surname+' '+ad.Forenames as [Transfer From], ac.Surname+' '+ac.Forenames as [Transfer To],  T.Description, t.Amount, t.DateCreated, r.ValueDate, t.BankName, t.BankAccount, t.Currency   from cashtrans t, Reallocations r, Accounts_Clients ad, Accounts_Clients ac where r.TransactionID=t.id and ad.CDS_Number=t.CDS_Number and ac.CDS_Number=r.ReAllocateTo  and r.ApprovedDate is NULL", cn)
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
    Public Function pendtrans(idn As String) As DataSet
        Dim dsport As New DataSet
        cmd = New SqlCommand(" select r.id, ad.Surname+' '+ad.Forenames as [Transfer From], ac.Surname+' '+ac.Forenames as [Transfer To],  T.Description, t.Amount, t.DateCreated, r.ValueDate, t.BankName, t.BankAccount, t.Currency   from cashtrans t, Reallocations r, Accounts_Clients ad, Accounts_Clients ac where r.TransactionID=t.id and ad.CDS_Number=t.CDS_Number and ac.CDS_Number=r.ReAllocateTo  and r.ApprovedDate is NULL", cn)
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
        If e.CommandArgs.CommandName.ToString = "View Document" Then

            Try
                pd(id, "TRADE")
            Catch ex As Exception
            End Try
            Try
                word(id, "TRADE")
            Catch ex As Exception
            End Try
            Try

                xls(id, "TRADE")
                ' msgbox("m")
            Catch ex As Exception
            End Try
            Try
                Img(id, "TRADE")
            Catch ex As Exception
            End Try
        ElseIf e.CommandArgs.CommandName.ToString = "Approve Transaction" Then
            approvetrans(id)
            getpending()
            msgbox("Transaction Successfully Approved")
        ElseIf e.CommandArgs.CommandName.ToString = "Decline Transaction" Then
            rejecttrans(id)
            getpending()
            msgbox("Transaction Declined")

        End If

    End Sub
    Public Sub approvetrans(transid As String)
        Try



            cmd = New SqlCommand("insert into cashtrans ( [Description]      ,[TransType]      ,[Amount]      ,[DateCreated]      ,[TransStatus]      ,[CDS_Number]      ,[Paid]      ,[Reference]      ,[ChargeCode]      ,[AssetManager]      ,[BankName]      ,[BankAccount]      ,[Ref2]      ,[PostedBy]      ,[Currency]) SELECT      [Description]+' - Re-Allocation'      ,[TransType]+' - Re-Allocation'      ,[Amount]*-1      ,r.ValueDate      ,[TransStatus]      ,[CDS_Number]      ,[Paid]      ,[Reference]      ,[ChargeCode]      ,[AssetManager]      ,[BankName]      ,[BankAccount]      ,[Ref2]      ,'" + Session("Username") + "'     ,[Currency]  FROM CashTrans c, Reallocations r  where r.id='" + transid + "' and r.TransactionID=c.id insert into cashtrans ( [Description]      ,[TransType]      ,[Amount]      ,[DateCreated]      ,[TransStatus]      ,[CDS_Number]      ,[Paid]      ,[Reference]      ,[ChargeCode]      ,[AssetManager]      ,[BankName]      ,[BankAccount]      ,[Ref2]      ,[PostedBy]      ,[Currency]) SELECT      [Description]+' - Re-Allocation'      ,[TransType]+' - Re-Allocation'      ,[Amount]      ,r.ValueDate      ,[TransStatus]      ,r.ReAllocateTo       ,[Paid]      ,[Reference]      ,[ChargeCode]      ,[AssetManager]      ,[BankName]      ,[BankAccount]      ,[Ref2]      ,'" + Session("Username") + "'     ,[Currency]  FROM CashTrans c, Reallocations r  where r.id='" + transid + "' and r.TransactionID=c.id update Reallocations set ApprovedBy='" + Session("Username") + "', ApprovedDate=getdate() where id='" + transid + "'", cn)
            If (cn.State = ConnectionState.Open) Then
                cn.Close()
            End If
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()


        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub rejecttrans(transid As String)
        Try
            cmd = New SqlCommand("update Reallocations set rejected='1', ApprovedDate=getdate() where id='" + transid + "'", cn)
            If (cn.State = ConnectionState.Open) Then
                cn.Close()
            End If
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()
        Catch ex As Exception
            msgbox(ex.Message)
        End Try

    End Sub
    Protected Sub ASPxButton15_Click(sender As Object, e As EventArgs) Handles ASPxButton15.Click
        Dim keys As List(Of Object) = grddocuments.GetCurrentPageRowValues(New String() {"id"})

        For Each key As Object In keys
            Dim chk As ASPxCheckBox = TryCast(grddocuments.FindRowCellTemplateControlByKey(key, TryCast(grddocuments.Columns("Selec"), GridViewDataColumn), "chk1"), ASPxCheckBox)

            Dim check As Boolean = chk.Checked
            If check = True Then
                approvetrans(key.ToString)
            End If

        Next
        getpending()
        msgbox("Transaction(s) Successfully Approved")
    End Sub
    Protected Sub ASPxButton16_Click(sender As Object, e As EventArgs) Handles ASPxButton16.Click
        Dim keys As List(Of Object) = grddocuments.GetCurrentPageRowValues(New String() {"id"})

        For Each key As Object In keys
            Dim chk As ASPxCheckBox = TryCast(grddocuments.FindRowCellTemplateControlByKey(key, TryCast(grddocuments.Columns("Selec"), GridViewDataColumn), "chk1"), ASPxCheckBox)

            Dim check As Boolean = chk.Checked
            If check = True Then
                rejecttrans(key.ToString)
            End If

        Next
        getpending()
        msgbox("Transaction(s) Rejected")
    End Sub
End Class