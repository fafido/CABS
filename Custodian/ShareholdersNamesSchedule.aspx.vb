Partial Class Custodian_ShareholdersNamesSchedule
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
                lblsitemap.Text = "Reporting >> Shareholders Names Schedule"
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub btnPrintStatement_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPrintStatement.Click
        Try
            If (RadioButton1.Checked = True) Then
                Dim strscript As String
                strscript = "<script langauage=JavaScript>"
                strscript += "window.open('ShareholderAccountsScheduleRep.aspx?nominee=" & Session("BrokerCode").ToString & "&RepType=2');"
                strscript += "</script>"
                ClientScript.RegisterStartupScript(Me.GetType(), "newwin", strscript)

            End If

            If (RadioButton2.Checked = True) Then
                Dim strscript As String
                strscript = "<script langauage=JavaScript>"
                strscript += "window.open('ShareholderAccountsScheduleRep.aspx?nominee=" & Session("BrokerCode").ToString & "&Company=" & DropDownList1.Text & "&RepType=1');"
                strscript += "</script>"
                ClientScript.RegisterStartupScript(Me.GetType(), "newwin", strscript)

            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub


    Protected Sub RadioButton2_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButton2.CheckedChanged
        Try

            If (RadioButton2.Checked = True) Then
                Label5.Visible = True
                DropDownList1.Visible = True
                Dim ds As New DataSet
                cmd = New SqlCommand("select distinct (company) from mast ", cn)
                adp = New SqlDataAdapter(cmd)
                adp.Fill(ds, "mast")

                If (ds.Tables(0).Rows.Count > 0) Then
                    DropDownList1.DataSource = ds.Tables(0)
                    DropDownList1.DataValueField = "company"
                    DropDownList1.DataBind()
                End If


            End If

        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub RadioButton1_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButton1.CheckedChanged
        Try
            If (RadioButton1.Checked = True) Then
                DropDownList1.Items.Clear()
                DropDownList1.Visible = False
                Label5.Visible = False
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
End Class
