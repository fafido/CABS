Imports System.Data
Imports System.Data.SqlClient
Partial Class Orders
    Inherits System.Web.UI.Page
    Dim constr As String = (System.Configuration.ConfigurationManager.AppSettings("connpath"))
    Dim cn As New SqlConnection(constr)
    Dim cmd As SqlCommand
    Dim query As SqlCommand
    Dim adp As SqlDataAdapter
    Dim ds As New DataSet
    Dim maxholder As Integer = 0
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
        If (Not IsPostBack) Then



            Getorders()

            '   Getorders()

        End If
        If Session("finish") = "yes" Then
            Session("finish") = ""
            msgbox("Sent for Approval")
        End If
    End Sub
    Public Sub authorise(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim idd As String = CType(sender, LinkButton).CommandArgument
        'cmd = New SqlCommand("insert into [CDS_ROUTER].[dbo].[trans] (company,CDS_Number,Date_Created,Trans_Time,shares,Update_Type,Created_By,Batch_Ref ) (select company,cds_number,date_created,trans_time,shares,update_type,created_by,batch_ref from [CDS_ROUTER].[dbo].[oddlots] where trans_id='" & idd & "') ", cn)
        'If (cn.State = ConnectionState.Open) Then
        '    cn.Close()
        'End If
        'cn.Open()
        'cmd.ExecuteNonQuery()
        'cn.Close()
        getdetails(idd)
        updateauthorisation(idd)
        updatelockAccountClients(txtcdsnumber.Text, txtrequest.Text)
        updatelockAccountClientsWeb(txtcdsnumber.Text, txtrequest.Text)

        msgbox("Authorisation Successful")
        Getorders()


    End Sub










    Public Sub Getorders()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select id, name,surname,cdsnumber,reason,status from   [CDS_ROUTER].[dbo].[AccountsLock] where active='1'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "para_lendingRules")
            If (ds.Tables(0).Rows.Count > 0) Then
                grdRules.DataSource = ds.Tables(0)
                grdRules.DataBind()
            Else
                grdRules.DataSource = Nothing
                grdRules.DataBind()
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub


    Public Function updateauthorisation(ByVal id As String)

        cmd = New SqlCommand("update [CDS_ROUTER].[dbo].[AccountsLock] set active='0' where id='" & id & "' ", cn)
        If (cn.State = ConnectionState.Open) Then
            cn.Close()
        End If
        cn.Open()
        cmd.ExecuteNonQuery()
        cn.Close()

        Return 0
    End Function
    Public Function updatelockAccountClientsWeb(ByVal cdsnumber As String, ByVal request As String)

        cmd = New SqlCommand("update cds_router.dbo.Accounts_Clients_Web set AccountState='" + request + "' where cds_number = '" + cdsnumber + "'", cn)
        If (cn.State = ConnectionState.Open) Then
            cn.Close()
        End If
        cn.Open()
        cmd.ExecuteNonQuery()
        cn.Close()

        Return 0
    End Function
    Public Sub getdetails(ByVal id As String)
        Dim ds As New DataSet
        cmd = New SqlCommand("select * from[CDS_ROUTER].[dbo].[AccountsLock] where id= '" & id & "'", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "Pending_Prices")
        If (ds.Tables(0).Rows.Count > 0) Then
            txtcdsnumber.Text = ds.Tables(0).Rows(0).Item("cdsnumber").ToString
            txtrequest.Text = ds.Tables(0).Rows(0).Item("status").ToString


        End If


    End Sub
    Public Function updatelockAccountClients(ByVal cdsnumber As String, ByVal request As String)

        cmd = New SqlCommand("update cds_router.dbo.Accounts_Clients set AccountState='" + request + "' where cds_number = '" + cdsnumber + "'", cn)
        If (cn.State = ConnectionState.Open) Then
            cn.Close()
        End If
        cn.Open()
        cmd.ExecuteNonQuery()
        cn.Close()

        Return 0
    End Function



    Public Sub linkDiscard(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim idd As String = CType(sender, LinkButton).CommandArgument
        cmd = New SqlCommand("Delete from [CDS_ROUTER].[dbo].[AccountsLock] where id='" & idd & "' ", cn)
        If (cn.State = ConnectionState.Open) Then
            cn.Close()
        End If
        cn.Open()
        cmd.ExecuteNonQuery()
        cn.Close()
        msgbox("Rejection Successful")
        Getorders()

    End Sub




End Class
