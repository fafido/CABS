Imports System.IO
Imports DevExpress.Web.ASPxGridView

Partial Class TransferSec_ApproveBondStat

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



            Else
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
        cmd = New SqlCommand("select * from Bond_Trades_Comm where ApprovedBy is NULL and rejected is NULL", cn)
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
            Try



                cmd = New SqlCommand("update Bond_Trades_Comm set ApprovedBy='" + Session("Username") + "', ApprovedDate=getdate() where id='" + id + "'", cn)
                If (cn.State = ConnectionState.Open) Then
                    cn.Close()
                End If
                cn.Open()
                cmd.ExecuteNonQuery()

                cmd = New SqlCommand("insert into trans (Company, CDS_Number, Date_Created, Trans_Time, Shares  , Update_Type, Created_By, Batch_Ref, Source, Pledge_shares, Reference, Instrument, [Broker], Custodian, AssetManager) select Company, ClientNo , getdate(), getdate(), CASE TradeType when 'RVP'  then Units when 'RF' then Units when 'DVP' then Units*-1  when 'DF' then Units*-1 else 0  end as [Shares], 'EQUITY TRADE', '" + Session("Username") + "', id, 'D', '0', TradeRef , 'EQUITY', [Broker], 'CABS', AssetManager from Bond_Trades where id=(select top 1 ref2 from Bond_Trades_Comm where id='" + id + "')", cn)
                If (cn.State = ConnectionState.Open) Then
                    cn.Close()
                End If
                cn.Open()
                cmd.ExecuteNonQuery()

                cmd = New SqlCommand("insert into cashtrans ([Description], TransType , Amount, DateCreated , TransStatus , CDS_Number, Reference,AssetManager, BankName, BankAccount, Ref2, PostedBy, Currency)  select TradeType+ ' - '+ convert(nvarchar(50),Units)+ ' '+ Company +' @ '+ convert(nvarchar(50),price) , 'DVP Equity Trade' , SettlementAmount, getdate() , '1' , c.ClientNo , c.id,c.AssetManager, BankName, BankAccount, TradeRef , '" + Session("Username") + "', SettlementCurrency from Bond_Trades c, Client_AssetManagers ca where ca.clientno=c.ClientNo and c.AssetManager=ca.AssetManager and c.id=(select top 1 ref2 from Bond_Trades_Comm where id='" + id + "') AND TradeType='DVP'", cn)
                If (cn.State = ConnectionState.Open) Then
                    cn.Close()
                End If
                cn.Open()
                cmd.ExecuteNonQuery()
                cn.Close()


                cmd = New SqlCommand("Update Bond_Trades set TradeStatus='SETTLED' where id=(select top 1 ref2 from Bond_Trades_Comm where id='" + id + "')", cn)
                If (cn.State = ConnectionState.Open) Then
                    cn.Close()
                End If
                cn.Open()
                cmd.ExecuteNonQuery()

                cn.Close()
                getpending()
                msgbox("Transaction Successfully Approved")

            Catch ex As Exception
                msgbox(ex.Message)
            End Try

        ElseIf e.CommandArgs.CommandName.ToString = "Decline Transaction" Then
            'Dim m As New sendmail
            'Dim transtyp As String = pendtrans(id).Tables(0).Rows(0).Item("transtype").ToString
            'Dim amt As String = pendtrans(id).Tables(0).Rows(0).Item("Amount").ToString
            'Dim emaill As String = pendtrans(id).Tables(0).Rows(0).Item("email").ToString

            'Try
            '    m.sendmail(emaill, "Trade Declined", "Your trade of " + amt.ToString() + " for " + transtyp + " has been declined, kindly re-submit your deposit and attach proof of payment!")

            'Catch ex As Exception

            'End Try


            cmd = New SqlCommand("update Bond_Trades_Comm set Rejected='1', RejectionReason='REJECTED BY ADMIN' where id='" + id + "'", cn)
            If (cn.State = ConnectionState.Open) Then
                cn.Close()
            End If
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()

            cmd = New SqlCommand("Update Bond_Trades set TradeStatus='SETTLED' where id=(select top 1 ref2 from Bond_Trades_Comm where id='" + id + "')", cn)
            If (cn.State = ConnectionState.Open) Then
                cn.Close()
            End If
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()

            getpending()
            msgbox("Transaction Declined")

        End If

    End Sub
End Class