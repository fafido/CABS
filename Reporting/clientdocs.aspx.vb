
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
    Public Sub GETALLPENDING()
        Try

            Dim ds1 As New DataSet
            cmd = New SqlCommand("select T.[id]     ,[AccountNo]      ,[DocumentName]      ,[FileName]      ,[Extension]      ,[TransactionType]      ,[TransactionRef]      ,T.[CreatedBy]      ,[Data]      ,T.[DateCreated]      ,T.[Status]      ,[ClientNo]      ,[ReceivedBy]      ,[ReceivedDate] , ac.Surname+' '+ac.Forenames as [ClientName] from Transaction_Documents2 t, Accounts_clients ac  where ac.cds_number=t.ClientNo and t.[Status]='SENT'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds1, "trns")
            If ds1.Tables("trns").Rows.Count > 0 Then
                grddocuments.DataSource = ds1
                grddocuments.DataBind()
            Else
                grddocuments.DataSource = Nothing
                grddocuments.DataBind()
            End If
        Catch ex As Exception

        End Try

    End Sub
    Public Sub getall()
        Try

            Dim ds1 As New DataSet
            cmd = New SqlCommand("select  T.[id]      ,[AccountNo]      ,[DocumentName]      ,[FileName]      ,[Extension]      ,[TransactionType]      ,[TransactionRef]      ,T.[CreatedBy]      ,[Data]      ,T.[DateCreated]      ,T.[Status]      ,[ClientNo]      ,[ReceivedBy]      ,[ReceivedDate] , ac.Surname+' '+ac.Forenames as [ClientName] from Transaction_Documents2 t, Accounts_clients ac  where ac.cds_number=t.ClientNo and t.[Status] is not null", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds1, "trns")
            If ds1.Tables("trns").Rows.Count > 0 Then
                grddocuments0.DataSource = ds1
                grddocuments0.DataBind()
            Else
                grddocuments0.DataSource = Nothing
                grddocuments0.DataBind()
            End If
        Catch ex As Exception

        End Try

    End Sub
    Public Function pending() As DataSet
        Try

            Dim ds1 As New DataSet
            cmd = New SqlCommand("select  T.[id]   ,[AccountNo]      ,[DocumentName]      ,[FileName]      ,[Extension]      ,[TransactionType]      ,[TransactionRef]      ,T.[CreatedBy]      ,[Data]      ,T.[DateCreated]      ,T.[Status]      ,[ClientNo]      ,[ReceivedBy]      ,[ReceivedDate] , t.id as idd, ac.Surname+' '+ac.Forenames as [ClientName] from Transaction_Documents2 t, Accounts_clients ac  where ac.cds_number=t.ClientNo and t.[Status]='SENT'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds1, "trns")
            If ds1.Tables("trns").Rows.Count > 0 Then
                Return ds1

            Else
                Return ds1
            End If
        Catch ex As Exception

        End Try

    End Function
    Public Function all() As DataSet
        Try

            Dim ds1 As New DataSet
            cmd = New SqlCommand("select  T.[id]     ,[AccountNo]      ,[DocumentName]      ,[FileName]      ,[Extension]      ,[TransactionType]      ,[TransactionRef]      ,T.[CreatedBy]      ,[Data]      ,T.[DateCreated]      ,T.[Status]      ,[ClientNo]      ,[ReceivedBy]      ,[ReceivedDate] ,t.id as idd, ac.Surname+' '+ac.Forenames as [ClientName] from Transaction_Documents2 t, Accounts_clients ac  where ac.cds_number=t.ClientNo and t.[Status] is not null", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds1, "trns")
            If ds1.Tables("trns").Rows.Count > 0 Then
                Return ds1
            Else
                Return ds1
            End If
        Catch ex As Exception

        End Try

    End Function
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
                GETALLPENDING()
                getall()

            Else
                Try
                    ' getdocsforclient()

                Catch ex As Exception

                End Try

            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
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
        Dim strQuery As String = "select * from Transaction_Documents2 where id='" + id + "'"
        Dim cmd As SqlCommand = New SqlCommand(strQuery)
        cmd.Parameters.Add("@id", SqlDbType.Int).Value = 4
        Dim dt As DataTable = GetData(cmd)
        If dt IsNot Nothing Then
            download(dt)
        End If
    End Sub
    Public Sub word(id As String, transtype As String)
        Dim strQuery As String = "select * from Transaction_Documents2 where id='" + id + "'"
        Dim cmd As SqlCommand = New SqlCommand(strQuery)
        cmd.Parameters.Add("@id", SqlDbType.Int).Value = 1
        Dim dt As DataTable = GetData(cmd)
        If dt IsNot Nothing Then
            download(dt)
        End If
    End Sub
    Public Sub xls(id As String, transtype As String)
        Dim strQuery As String = "select * from Transaction_Documents2 where id='" + id + "'"
        Dim cmd As SqlCommand = New SqlCommand(strQuery)
        cmd.Parameters.Add("@id", SqlDbType.Int).Value = 2
        Dim dt As DataTable = GetData(cmd)
        If dt IsNot Nothing Then
            download(dt)
        End If
    End Sub
    Public Sub Img(id As String, transtype As String)
        Dim strQuery As String = "select * from Transaction_Documents2 where id='" + id + "'"
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
        Response.AddHeader("content-disposition", "attachment;filename=""" + dt.Rows(0)("FileName").ToString() + "")
        Response.BinaryWrite(bytes)
        Response.Flush()
        Response.End()
    End Sub

    Private Sub grddocuments_RowCommand(sender As Object, e As ASPxGridViewRowCommandEventArgs) Handles grddocuments.RowCommand
        Dim id As String = e.KeyValue.ToString
        If e.CommandArgs.CommandName.ToString = "View Document" Then

            '  msgbox(id.ToString)
            ''  msgbox("download")
            ' Try
            pd(id, "Withdrawal")
            'Catch ex As Exception
            'End Try
            'Try
            '    word(id, "Withdrawal")
            'Catch ex As Exception
            'End Try
            'Try
            '    xls(id, "Withdrawal")
            'Catch ex As Exception
            'End Try
            'Try
            '    Img(id, "Withdrawal")
            'Catch ex As Exception
            'End Try
        ElseIf e.CommandArgs.CommandName.ToString = "Remove Document" Then
            'deletedocument(Session("autogen"), "Withdrawal")
            'getdocuments(Session("autogen"), "Withdrawal")
            msgbox("Cannot be deleted!")
        ElseIf e.CommandArgs.CommandName.ToString = "Mark As Received" Then
            Try
                cmd = New SqlCommand("Update Accounts_Documents set [Status]='Received', ReceivedBy='" + Session("Username") + "', ReceivedDate=getdate() where id = '" + id + "'", cn)
                If (cn.State = ConnectionState.Open) Then
                    cn.Close()
                End If
                cn.Open()
                cmd.ExecuteNonQuery()
                cn.Close()
                GETALLPENDING()

                msgbox("Marked as Received")
            Catch ex As Exception

            End Try
        End If
    End Sub
    Private Sub grddocuments0_RowCommand(sender As Object, e As ASPxGridViewRowCommandEventArgs) Handles grddocuments0.RowCommand
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
        ElseIf e.CommandArgs.CommandName.ToString = "Mark As Received" Then
            Try
                cmd = New SqlCommand("Update Accounts_Documents set [Status]='Received', ReceivedBy='" + Session("Username") + "', ReceivedDate=getdate() where id = '" + id + "'", cn)
                If (cn.State = ConnectionState.Open) Then
                    cn.Close()
                End If
                cn.Open()
                cmd.ExecuteNonQuery()
                cn.Close()
                GETALLPENDING()

                msgbox("Marked as Received")
            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub grddocuments_DataBinding(sender As Object, e As EventArgs) Handles grddocuments.DataBinding
        grddocuments.DataSource = pending()

    End Sub

    Private Sub grddocuments0_DataBinding(sender As Object, e As EventArgs) Handles grddocuments0.DataBinding
        grddocuments0.DataSource = all()

    End Sub
End Class
