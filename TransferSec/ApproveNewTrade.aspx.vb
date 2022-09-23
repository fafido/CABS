Imports System.Collections.Generic
Imports System.IO
Imports DevExpress.Web.ASPxEditors
Imports DevExpress.Web.ASPxGridView

Partial Class TransferSec_ApproveNewTrade

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
                GETREJECTED()
                getauthorized()



            Else
                '  getpending()
                GETREJECTED()
                getauthorized()
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
        cmd = New SqlCommand("select *, a.surname+' '+a.forenames as [ClientName] from Custodian_Trades c, Accounts_clients a   where c.ApprovedBy is NULL and c.rejected is NULL and c.clientNo=a.cds_number", cn)
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
    Public Function pendingdataset() As DataSet
        Dim dsport As New DataSet
        cmd = New SqlCommand("select *, a.surname+' '+a.forenames as [ClientName] from Custodian_Trades c, Accounts_clients a   where c.ApprovedBy is NULL and c.rejected is NULL and c.clientNo=a.cds_number", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(dsport, "trans")
        If (dsport.Tables(0).Rows.Count > 0) Then
            Return dsport

        Else
            Return Nothing

        End If
    End Function
    Public Sub getauthorized()
        Dim dsport As New DataSet
        cmd = New SqlCommand("select *, a.surname+' '+a.forenames as [ClientName] from Custodian_Trades c, Accounts_clients a where c.ApprovedBy is NOT NULL and c.rejected is NULL and c.clientNo=a.cds_number", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(dsport, "trans")
        If (dsport.Tables(0).Rows.Count > 0) Then
            grdauthorized.DataSource = dsport
            grdauthorized.DataBind()
        Else
            grdauthorized.DataSource = Nothing
            grdauthorized.DataBind()
        End If
    End Sub
    Public Sub GETREJECTED()
        Dim dsport As New DataSet
        cmd = New SqlCommand("select *, a.surname+' '+a.forenames as [ClientName] from Custodian_Trades c, Accounts_clients a   where c.ApprovedBy is NULL and c.rejected is NOT NULL and c.clientNo=a.cds_number", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(dsport, "trans")
        If (dsport.Tables(0).Rows.Count > 0) Then
            grdrejected.DataSource = dsport
            grdrejected.DataBind()
        Else
            grdrejected.DataSource = Nothing
            grdrejected.DataBind()
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
        Dim strQuery As String = "select  DocumentName+''+ Extension as nm, [data],Extension from Transaction_Documents where TransactionRef='" + id + "' and TransactionType='" + transtype + "'"
        Dim cmd As SqlCommand = New SqlCommand(strQuery)
        cmd.Parameters.Add("@id", SqlDbType.Int).Value = 4
        Dim dt As DataTable = GetData(cmd)
        If dt IsNot Nothing Then
            download(dt)
        End If
    End Sub
    Public Sub word(id As String, transtype As String)
        Dim strQuery As String = "select  DocumentName+''+ Extension as nm, [data],Extension from Transaction_Documents where TransactionRef='" + id + "' and TransactionType='" + transtype + "'"
        Dim cmd As SqlCommand = New SqlCommand(strQuery)
        cmd.Parameters.Add("@id", SqlDbType.Int).Value = 1
        Dim dt As DataTable = GetData(cmd)
        If dt IsNot Nothing Then
            download(dt)
        End If
    End Sub
    Public Sub xls(id As String, transtype As String)
        Dim strQuery As String = "select  DocumentName+''+ Extension as nm, [data],Extension from Transaction_Documents where TransactionRef='" + id + "' and TransactionType='" + transtype + "'"
        Dim cmd As SqlCommand = New SqlCommand(strQuery)
        cmd.Parameters.Add("@id", SqlDbType.Int).Value = 2
        Dim dt As DataTable = GetData(cmd)
        If dt IsNot Nothing Then
            download(dt)
        End If
    End Sub
    Public Sub Img(id As String, transtype As String)
        Dim strQuery As String = "select  DocumentName+''+ Extension as nm, [data],Extension from Transaction_Documents where TransactionRef='" + id + "' and TransactionType='" + transtype + "'"
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
    Public Function docexists(id As String, transtype As String) As Boolean
        Dim dsport As New DataSet
        cmd = New SqlCommand("select  DocumentName+''+ Extension as nm, [data],Extension from Transaction_Documents where TransactionRef='" + id + "' and TransactionType='" + transtype + "'", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(dsport, "trans")
        If (dsport.Tables(0).Rows.Count > 0) Then
            Return True
        Else
            Return False
        End If
    End Function
    Public Sub getdetails(id As String)
        Dim dsport As New DataSet
        cmd = New SqlCommand("select * from custodian_trades c, accounts_clients a where c.id='" + id + "' and c.clientNo=a.cds_number", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(dsport, "trans")
        If (dsport.Tables(0).Rows.Count > 0) Then
            txtavailableshares.Text = dsport.Tables(0).Rows(0).Item("Units").ToString
            txtereference.Text = dsport.Tables(0).Rows(0).Item("TradeRef").ToString
            txtewraccountno.Text = dsport.Tables(0).Rows(0).Item("ClientNo").ToString
            txtewrholder.Text = dsport.Tables(0).Rows(0).Item("Surname").ToString + " " + dsport.Tables(0).Rows(0).Item("forenames").ToString
            txtprice.Text = dsport.Tables(0).Rows(0).Item("Price").ToString
            Dim grss As Decimal
            Dim price As Decimal = txtprice.Text
            Dim quant As Decimal = txtavailableshares.Text
            grss = price * quant

            txttranscharge.Text = dsport.Tables(0).Rows(0).Item("TradeCharge").ToString
            cmbassetmanager.Text = dsport.Tables(0).Rows(0).Item("AssetManager").ToString
            cmbcurrency.Text = dsport.Tables(0).Rows(0).Item("Currency").ToString
            cmbordertype.Text = dsport.Tables(0).Rows(0).Item("TradeType").ToString
            cmbparaCompany.Text = dsport.Tables(0).Rows(0).Item("Company").ToString
            dtfrom.Date = dsport.Tables(0).Rows(0).Item("TradeDate").ToString
            dtsettlementdate.Date = dsport.Tables(0).Rows(0).Item("SettlementDate").ToString
            txtcapturedby.Text = dsport.Tables(0).Rows(0).Item("CapturedBy").ToString
            txtcdcaccount.Text = dsport.Tables(0).Rows(0).Item("CDCAccount").ToString
            txtstatus.Text = dsport.Tables(0).Rows(0).Item("TradeStatus").ToString
            txtsettlementamount.Text = dsport.Tables(0).Rows(0).Item("SettlementAmount").ToString
            dtcaptured.Date = dsport.Tables(0).Rows(0).Item("CapturedDate").ToString
            txtgross.Text = grss.ToString
            txtexchangerate.Text = dsport.Tables(0).Rows(0).Item("ExchangeRate").ToString
            txtsettlementcurrency.Text = dsport.Tables(0).Rows(0).Item("SettlementCurrency").ToString

        End If
    End Sub
    Private Sub grddocuments_RowCommand(sender As Object, e As ASPxGridViewRowCommandEventArgs) Handles grddocuments.RowCommand
        Dim id As String = e.KeyValue.ToString
        If e.CommandArgs.CommandName.ToString = "View Document" Then
            lblidshow.Text = id
            getdetails(id)

            ASPxPopupControl1.PopupHorizontalAlign = DevExpress.Web.ASPxClasses.PopupHorizontalAlign.WindowCenter
            ASPxPopupControl1.PopupVerticalAlign = DevExpress.Web.ASPxClasses.PopupVerticalAlign.WindowCenter

            ASPxPopupControl1.AllowDragging = True
            ASPxPopupControl1.ShowCloseButton = True
            ASPxPopupControl1.ShowOnPageLoad = True
            Page.MaintainScrollPositionOnPostBack = True

            ASPxButton13.Visible = True
            ASPxButton14.Visible = True
            ASPxButton15.Visible = True
            ASPxButton16.Visible = True
        ElseIf e.CommandArgs.CommandName.ToString = "Approve Transaction" Then
            approvetrans(id)
            getpending()
            GETREJECTED()
            getauthorized()
            msgbox("Transaction Successfully Approved")
        ElseIf e.CommandArgs.CommandName.ToString = "Decline Transaction" Then

            rejections(id)
            getpending()
            GETREJECTED()
            getauthorized()
            msgbox("Transaction Declined")


        End If

    End Sub
    Public Sub approvetrans(id As String)
        Try

            cmd = New SqlCommand("update Custodian_Trades set ApprovedBy='" + Session("Username") + "', ApprovedDate=getdate() where id='" + id + "'", cn)
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
    Public Sub rejections(id As String)
        cmd = New SqlCommand("update Custodian_Trades set Rejected='1', TradeStatus='EDIT', RejectionReason='REJECTED BY ADMIN' where id='" + id + "'", cn)
        If (cn.State = ConnectionState.Open) Then
            cn.Close()
        End If
        cn.Open()
        cmd.ExecuteNonQuery()
        cn.Close()

    End Sub
    Public Sub rejections_CDS(id As String)
        cmd = New SqlCommand("update Custodian_Trades set Rejected='1', TradeStatus='FAILED', RejectionReason='REJECTED BY ADMIN' where id='" + id + "'", cn)
        If (cn.State = ConnectionState.Open) Then
            cn.Close()
        End If
        cn.Open()
        cmd.ExecuteNonQuery()
        cn.Close()

    End Sub
    Protected Sub ASPxButton13_Click(sender As Object, e As EventArgs) Handles ASPxButton13.Click
        approvetrans(lblidshow.Text)
        Session("finish") = "yes"
        Session("msg") = "Transaction Successfully Approved"
        Response.Redirect(Request.RawUrl)
    End Sub
    Protected Sub ASPxButton14_Click(sender As Object, e As EventArgs) Handles ASPxButton14.Click
        rejections(lblidshow.Text)
        Session("finish") = "yes"
        Session("msg") = "Transaction Rejected for Edit"
        Response.Redirect(Request.RawUrl)
    End Sub
    Protected Sub ASPxButton16_Click(sender As Object, e As EventArgs) Handles ASPxButton16.Click
        rejections_CDS(lblidshow.Text)
        Session("finish") = "yes"
        Session("msg") = "Transaction Rejected for CDS"
        Response.Redirect(Request.RawUrl)
    End Sub
    Protected Sub ASPxButton15_Click(sender As Object, e As EventArgs) Handles ASPxButton15.Click
        Dim ids As String = lblidshow.Text
        If docexists(ids, "TRADE") = False Then
            msgbox("There is no attached document!")
            Exit Sub
        End If
        Try
            pd(ids, "TRADE")
        Catch ex As Exception
        End Try
        Try
            word(ids, "TRADE")
        Catch ex As Exception
        End Try
        Try

            xls(ids, "TRADE")
            ' msgbox("m")
        Catch ex As Exception
        End Try
        Try
            Img(ids, "TRADE")
        Catch ex As Exception
        End Try
    End Sub

    Private Sub grdauthorized_RowCommand(sender As Object, e As ASPxGridViewRowCommandEventArgs) Handles grdauthorized.RowCommand
        Dim id As String = e.KeyValue.ToString
        If e.CommandArgs.CommandName.ToString = "View Document" Then
            lblidshow.Text = id
            getdetails(id)

            ASPxPopupControl1.PopupHorizontalAlign = DevExpress.Web.ASPxClasses.PopupHorizontalAlign.WindowCenter
            ASPxPopupControl1.PopupVerticalAlign = DevExpress.Web.ASPxClasses.PopupVerticalAlign.WindowCenter

            ASPxPopupControl1.AllowDragging = True
            ASPxPopupControl1.ShowCloseButton = True
            ASPxPopupControl1.ShowOnPageLoad = True
            Page.MaintainScrollPositionOnPostBack = True

            ASPxButton13.Visible = False
            ASPxButton14.Visible = False
            ASPxButton15.Visible = False
            ASPxButton16.Visible = False
        End If
    End Sub

    Private Sub grdrejected_RowCommand(sender As Object, e As ASPxGridViewRowCommandEventArgs) Handles grdrejected.RowCommand
        Dim id As String = e.KeyValue.ToString
        If e.CommandArgs.CommandName.ToString = "View Document" Then
            lblidshow.Text = id
            getdetails(id)

            ASPxPopupControl1.PopupHorizontalAlign = DevExpress.Web.ASPxClasses.PopupHorizontalAlign.WindowCenter
            ASPxPopupControl1.PopupVerticalAlign = DevExpress.Web.ASPxClasses.PopupVerticalAlign.WindowCenter

            ASPxPopupControl1.AllowDragging = True
            ASPxPopupControl1.ShowCloseButton = True
            ASPxPopupControl1.ShowOnPageLoad = True
            Page.MaintainScrollPositionOnPostBack = True
            ASPxButton13.Visible = False
            ASPxButton14.Visible = False
            ASPxButton15.Visible = False
            ASPxButton16.Visible = False
        End If
    End Sub
    Protected Sub ASPxButton1_Click(sender As Object, e As EventArgs) Handles ASPxButton1.Click
        Dim keys As List(Of Object) = grddocuments.GetCurrentPageRowValues(New String() {"id"})

        For Each key As Object In keys
            Dim chk As ASPxCheckBox = TryCast(grddocuments.FindRowCellTemplateControlByKey(key, TryCast(grddocuments.Columns("Selec"), GridViewDataColumn), "chk1"), ASPxCheckBox)

            Dim check As Boolean = chk.Checked
            If check = True Then
                approvetrans(key.ToString)

            End If


        Next
        getpending()
        GETREJECTED()
        getauthorized()
        msgbox("Transaction(s) Successfully Approved")
    End Sub
    Protected Sub ASPxButton2_Click(sender As Object, e As EventArgs) Handles ASPxButton2.Click
        Dim keys As List(Of Object) = grddocuments.GetCurrentPageRowValues(New String() {"id"})
        For Each key As Object In keys
            Dim chk As ASPxCheckBox = TryCast(grddocuments.FindRowCellTemplateControlByKey(key, TryCast(grddocuments.Columns("Selec"), GridViewDataColumn), "chk1"), ASPxCheckBox)

            Dim check As Boolean = chk.Checked
            If check = True Then
                rejections(key.ToString)
            End If
        Next
        getpending()
        GETREJECTED()
        getauthorized()
        msgbox("Transaction(s) Rejected for edit!")
    End Sub
    Protected Sub ASPxButton17_Click(sender As Object, e As EventArgs) Handles ASPxButton17.Click
        Dim keys As List(Of Object) = grddocuments.GetCurrentPageRowValues(New String() {"id"})
        For Each key As Object In keys
            Dim chk As ASPxCheckBox = TryCast(grddocuments.FindRowCellTemplateControlByKey(key, TryCast(grddocuments.Columns("Selec"), GridViewDataColumn), "chk1"), ASPxCheckBox)

            Dim check As Boolean = chk.Checked
            If check = True Then
                rejections_CDS(key.ToString)
            End If
        Next
        getpending()
        GETREJECTED()
        getauthorized()
        msgbox("Transaction(s) Rejected CDS!")
    End Sub

    Private Sub grddocuments_DataBinding(sender As Object, e As EventArgs) Handles grddocuments.DataBinding
        grddocuments.DataSource = pendingdataset()

    End Sub
End Class