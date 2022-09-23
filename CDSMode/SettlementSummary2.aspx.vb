Partial Class CDSMode_SettlementSummary2
    Inherits System.Web.UI.Page
    Dim constr As String = (System.Configuration.ConfigurationManager.AppSettings("connpath"))
    Dim cn As New SqlConnection(constr)
    Dim cmd As SqlCommand
    Dim adp As SqlDataAdapter


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
        Try
            If (Not IsPostBack) Then
                Label1.Visible = True
                Label6.Visible = True
                BasicDatePicker1.Visible = True
                BasicDatePicker2.Visible = True
                Label7.Visible = True
                Label8.Visible = False
                cmbTransactionList.Visible = False
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub rdDate_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdDate.CheckedChanged
        Try
            If (rdDate.Checked = True) Then
                Label1.Visible = True
                Label6.Visible = True
                BasicDatePicker1.Visible = True
                BasicDatePicker2.Visible = True
                Label7.Visible = True
                Label8.Visible = False
                cmbTransactionList.Visible = False
            End If
            If (rdDate0.Checked = True) Then
                Label1.Visible = False
                Label6.Visible = False
                BasicDatePicker1.Visible = False
                BasicDatePicker2.Visible = False
                Label7.Visible = False
                Label8.Visible = True
                cmbTransactionList.Visible = True
            End If


        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub getTransID()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("Select distinct (UploadID) from TblSettlementData where UpdateFlag=1", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "TblSettlementData")
            If (ds.Tables(0).Rows.Count > 0) Then
                cmbTransactionList.DataSource = ds.Tables(0)
                cmbTransactionList.DataValueField = "UploadID"
                cmbTransactionList.DataBind()
            Else
                cmbTransactionList.Items.Clear()
                cmbTransactionList.DataSource = Nothing
                cmbTransactionList.DataBind()
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub rdDate0_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdDate0.CheckedChanged
        Try
            If (rdDate0.Checked = True) Then
                Label1.Visible = False
                Label6.Visible = False
                BasicDatePicker1.Visible = False
                BasicDatePicker2.Visible = False
                Label7.Visible = False
                Label8.Visible = True
                cmbTransactionList.Visible = True
                getTransID()
            End If
            If (rdDate.Checked = True) Then
                Label1.Visible = True
                Label6.Visible = True
                BasicDatePicker1.Visible = True
                BasicDatePicker2.Visible = True
                Label7.Visible = True
                Label8.Visible = False
                cmbTransactionList.Visible = False
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try

    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            If (rdDate.Checked = True) Then
                Dim strscript As String
                strscript = "<script langauage=JavaScript>"
                strscript += "window.open('SettlementAnalysisDate.aspx?Datefrom=" & BasicDatePicker1.Text & "&Dateto=" & BasicDatePicker2.Text & "');"
                strscript += "</script>"
                ClientScript.RegisterStartupScript(Me.GetType(), "newwin", strscript)
            End If
            If (rdDate0.Checked = True) Then
                Dim strscript As String
                strscript = "<script langauage=JavaScript>"
                strscript += "window.open('SettlementAnalysisTrans.aspx?Transid=" & cmbTransactionList.Text & "');"
                strscript += "</script>"
                ClientScript.RegisterStartupScript(Me.GetType(), "newwin", strscript)
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
End Class
