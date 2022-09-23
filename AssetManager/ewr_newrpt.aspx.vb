
Partial Class Reporting_ewr_newrpt
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
                getstatus()
                Getproduce()
                GetParticipants()
                getEWRs()
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub getstatus()
        Try
            Dim ds As New DataSet
            Dim status As String
            cmd = New SqlCommand("select distinct (status) from wr", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds)
            cmdstatus.DataSource = ds
            cmdstatus.TextField = "Status"
            cmdstatus.ValueField = "Status"
            cmdStatus.DataBind()
            cmdStatus.Items.Insert(0, New DevExpress.Web.ASPxEditors.ListEditItem("All", "All"))
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Public Sub Getproduce()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select distinct(commodity) from wr where isnull (commodity,'') <>''", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds)
            cmdproduce.DataSource = ds
            cmdproduce.TextField = "commodity"
            cmdproduce.ValueField = "commodity"
            cmdProduce.DataBind()
            cmdProduce.Items.Insert(0, New DevExpress.Web.ASPxEditors.ListEditItem("All", "All"))
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Public Sub GetParticipants()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select distinct A.Warehouse,ISNULL(B.WarehouseName,'') AS Names from wr A JOIN WarehouseCreation B ON A.Warehouse=B.WarehouseCode", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds)
            cmbParticipantCode.DataSource = ds
            cmbParticipantCode.TextField = "Names"
            cmbParticipantCode.ValueField = "Warehouse"
            cmbParticipantCode.DataBind()
            cmbParticipantCode.Items.Insert(0, New DevExpress.Web.ASPxEditors.ListEditItem("All", "All"))
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Public Sub getEWRs()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select distinct(ReceiptNo) from wr", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds)
            cmbEWRs.DataSource = ds
            cmbEWRs.TextField = "ReceiptNo"
            cmbEWRs.ValueField = "ReceiptNo"
            cmbEWRs.DataBind()
            cmbEWRs.Items.Insert(0, New DevExpress.Web.ASPxEditors.ListEditItem("All", "All"))
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        Try
            'If txtDateFrom.Text = "" Or txtDateTo.Text = "" Then
            '    msgbox("Invalid Report Parameters Selected")
            '    Exit Sub
            'End If

            Dim strscript As String
            strscript = "<script langauage=JavaScript>"
            strscript += "window.open('rptewr.aspx?Datefrom=" & txtDateFrom.Text & "&Dateto=" & txtDateTo.Text & "&commodity=" & cmdProduce.Value & "&status=" & cmdStatus.Value & "&ewr=" & cmbEWRs.Value & "&code=" & cmbParticipantCode.Value & "');"
            strscript += "</script>"
            ClientScript.RegisterStartupScript(Me.GetType(), "newwin", strscript)

        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
End Class
