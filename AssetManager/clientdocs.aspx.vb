
Imports DevExpress.Web.ASPxGridView

Partial Class Reporting_clientdocs
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
        If Session("UserName").ToString = "" Then
            Session.Abandon()
            Response.Cache.SetCacheability(HttpCacheability.NoCache)
            Response.Buffer = True
            Response.ExpiresAbsolute = DateTime.Now.AddDays(-1.0)
            Response.Expires = -1000
            Response.CacheControl = "no-cache"
            Response.Redirect("~/loginsystem.aspx", True)
        End If
        Try
            Page.MaintainScrollPositionOnPostBack = True
            If (Not IsPostBack) Then
                checkSessionState()
            Else
                Try
                    getdocsforclient()

                Catch ex As Exception

                End Try

            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub



    Protected Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        ' Try
        If Session("usertype") = "CMCAdmin" Or Session("usertype") = "CMCUser" Or Session("usertype") = "CMCUSER" Or Session("usertype") = "CMCADMIN" Then
            '     msgbox("cmc")
            lstSearchAcc.Items.Clear()
            lblCDsAccount.Text = ""
            lblCDsNumber.Text = ""
            Dim ds As New DataSet
            cmd = New SqlCommand("select cds_number, left(cds_number,100)+' '+forenames+ ' '+surname as namess from Accounts_clients where cds_number+' '+surname+ ' '+forenames+' '+mobile like '%" & txtSeachName.Text & "%' order by cds_Number", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "names")
            If (ds.Tables(0).Rows.Count > 0) Then
                lstSearchAcc.DataSource = ds.Tables(0)
                lstSearchAcc.TextField = "namess"
                lstSearchAcc.ValueField = "cds_number"
                lstSearchAcc.DataBind()
            Else
                lstSearchAcc.Items.Clear()
            End If
        ElseIf Session("Companytype") = "CUSTODIAN" Then

            lstSearchAcc.Items.Clear()
            lblCDsAccount.Text = ""
            lblCDsNumber.Text = ""
            Dim ds As New DataSet
            cmd = New SqlCommand("select cds_number, left(cds_number,100)+' '+forenames+ ' '+surname as namess from Accounts_clients where cds_number+' '+surname+ ' '+forenames+' '+tel like '%" & txtSeachName.Text & "%'  and Custodian='" + Session("BrokerCode") + "' order by cds_number", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "names")
            If (ds.Tables(0).Rows.Count > 0) Then
                lstSearchAcc.DataSource = ds.Tables(0)
                lstSearchAcc.TextField = "namess"
                lstSearchAcc.ValueField = "cds_number"
                lstSearchAcc.DataBind()
            Else
                lstSearchAcc.Items.Clear()
            End If

        Else

            lstSearchAcc.Items.Clear()
            lblCDsAccount.Text = ""
            lblCDsNumber.Text = ""
            Dim ds As New DataSet
            cmd = New SqlCommand("select cds_number,  cds_number+' '+forenames+ ' '+surname as namess from aCCOUNTs_CLIENTS where cds_number+' '+surname+ ' '+forenames+' '+MOBILE like '%" & txtSeachName.Text & "%' order by cds_number", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "names")
            If (ds.Tables(0).Rows.Count > 0) Then
                lstSearchAcc.DataSource = ds.Tables(0)
                lstSearchAcc.TextField = "namess"
                lstSearchAcc.ValueField = "cds_number"
                lstSearchAcc.DataBind()
            Else
                lstSearchAcc.Items.Clear()
            End If
        End If

        'Catch ex As Exception
        '    msgbox(ex.Message)
        'End Try
    End Sub

    Protected Sub lstSearchAcc_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstSearchAcc.SelectedIndexChanged
        Try
            If Session("usertype") = "CDSAdmin" Or Session("usertype") = "CDSUser" Then
                Dim ds As New DataSet
                cmd = New SqlCommand("select FORENAMES, SURNAME, LEFT(CDS_NUMBER,100) AS CDS_NUMBER from Accounts_clients where LEFT(cds_number,100)+' '+forenames+ ' '+surname = '" & lstSearchAcc.SelectedItem.Text & "'", cn)
                adp = New SqlDataAdapter(cmd)
                adp.Fill(ds, "names")
                If (ds.Tables(0).Rows.Count > 0) Then
                    lblCDsNumber.Text = ds.Tables(0).Rows(0).Item("cds_number").ToString
                    lblCDsAccount.Text = ds.Tables(0).Rows(0).Item("Forenames").ToString & " " & ds.Tables(0).Rows(0).Item("Surname").ToString

                    getdocsforclient()


                Else
                    lblCDsAccount.Text = ""
                    lblCDsNumber.Text = ""
                End If
            Else
                Dim ds As New DataSet
                cmd = New SqlCommand("select FORENAMES, SURNAME, CDS_NUMBER AS CDS_NUMBER from names where cds_number+' '+surname+ ' '+forenames = '" & lstSearchAcc.SelectedItem.Text & "'", cn)
                adp = New SqlDataAdapter(cmd)
                adp.Fill(ds, "names")
                If (ds.Tables(0).Rows.Count > 0) Then
                    lblCDsNumber.Text = ds.Tables(0).Rows(0).Item("cds_number").ToString
                    lblCDsAccount.Text = ds.Tables(0).Rows(0).Item("Forenames").ToString & " " & ds.Tables(0).Rows(0).Item("Surname").ToString

                    getdocsforclient()


                Else
                    lblCDsAccount.Text = ""
                    lblCDsNumber.Text = ""
                End If
            End If

        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub getdocsforclient()

        Dim ds1 As New DataSet
        cmd = New SqlCommand("select *,CASE t.TransactionType when 'EWR Cancellation' then (select ReceiptID  from ReceiptCancel where id=left(t.TransactionRef,8))	  when 'Withdrawal' then  (select ReceiptID  from ReceiptCancel where id=left(t.TransactionRef,8)) 	  when 'Transfer' then  (select ReceiptID  from share_transfer where id=left(t.TransactionRef,8) )	  else '' 	  end as  [Reference]  from Transaction_Documents2 t where AccountNo='" + lstSearchAcc.SelectedItem.Value + "'", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds1, "trns")
        If ds1.Tables("trns").Rows.Count > 0 Then
            grddocuments.DataSource = ds1
            grddocuments.DataBind()
        Else
            grddocuments.DataSource = Nothing
            grddocuments.DataBind()
        End If
    End Sub
    Protected Sub btnPrint0_Click(sender As Object, e As EventArgs) Handles btnPrint0.Click

        Response.Redirect(Request.RawUrl)
    End Sub
    Public Function GetData(ByVal cmd As SqlCommand) As DataTable
        Dim dt As New DataTable
        Dim strConnString As String = (System.Configuration.ConfigurationManager.AppSettings("connpath"))
        Dim con As New SqlConnection(strConnString)
        Dim sda As New SqlDataAdapter
        cmd.CommandType = CommandType.Text
        cmd.Connection = con
        Try
            con.Open()
            sda.SelectCommand = cmd
            sda.Fill(dt)
            Return dt
        Catch ex As Exception
            Response.Write(ex.Message)
            Return Nothing
        Finally
            con.Close()
            sda.Dispose()
            con.Dispose()
        End Try
    End Function
    Public Sub pd(id As String, transtype As String)
        Dim strQuery As String = "select [filename] as nm, [data],Extension from Transaction_Documents2 where id='" + id + "'"
        Dim cmd As SqlCommand = New SqlCommand(strQuery)
        cmd.Parameters.Add("@id", SqlDbType.Int).Value = 4
        Dim dt As DataTable = GetData(cmd)
        If dt IsNot Nothing Then
            download(dt)
        End If
    End Sub
    Public Sub word(id As String, transtype As String)
        Dim strQuery As String = "select [filename] as nm, [data],Extension from Transaction_Documents2 where id='" + id + "'"
        Dim cmd As SqlCommand = New SqlCommand(strQuery)
        cmd.Parameters.Add("@id", SqlDbType.Int).Value = 1
        Dim dt As DataTable = GetData(cmd)
        If dt IsNot Nothing Then
            download(dt)
        End If
    End Sub
    Public Sub xls(id As String, transtype As String)
        Dim strQuery As String = "select [filename] as nm, [data],Extension from Transaction_Documents2 where id='" + id + "'"
        Dim cmd As SqlCommand = New SqlCommand(strQuery)
        cmd.Parameters.Add("@id", SqlDbType.Int).Value = 2
        Dim dt As DataTable = GetData(cmd)
        If dt IsNot Nothing Then
            download(dt)
        End If
    End Sub
    Public Sub Img(id As String, transtype As String)
        Dim strQuery As String = "select [filename] as nm, [data],Extension from Transaction_Documents2 where id='" + id + "'"
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
                pd(id, "Withdrawal")
            Catch ex As Exception
            End Try
            Try
                word(id, "Withdrawal")
            Catch ex As Exception
            End Try
            Try
                xls(id, "Withdrawal")
            Catch ex As Exception
            End Try
            Try
                Img(id, "Withdrawal")
            Catch ex As Exception
            End Try
        ElseIf e.CommandArgs.CommandName.ToString = "Remove Document" Then
            'deletedocument(Session("autogen"), "Withdrawal")
            'getdocuments(Session("autogen"), "Withdrawal")
            msgbox("Cannot be deleted!")
        End If
    End Sub
End Class
