Partial Class TB_commit

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
                gebill_types()
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Protected Sub clearall()
        '     getSecurities_Types()
    End Sub
    Protected Sub ASPxButton7_Click(sender As Object, e As EventArgs) Handles ASPxButton7.Click
        '     Try
        cmd = New SqlCommand("declare @isin nvarchar(50)='" + ASPxComboBox1.SelectedItem.Value.ToString + "' insert into trans select isin, cds_number, getdate(), getdate(), value/(select top 1 multiples from TreasuryBills where isin=@isin), 'Auction', 'ATS', '0','S','0', NULL, 'TB' from bids_TB where isin=@isin  and status_flag is null update bids_TB set status_flag='1' where isin=@isin and status_flag is null", cn)
        If cn.State = ConnectionState.Open Then
            cn.Close()
        End If
        cn.Open()
        Dim y As Integer = cmd.ExecuteNonQuery()
        cn.Close()
        ' gebill_types()
        clearall()
        msgbox("TB Register Successfully Captured!")
        'Catch ex As Exception
        '    msgbox(ex.Message)
        'End Try
    End Sub
    Protected Sub gebill_types()
        Try
            cmd = New SqlCommand("select fnam+' '+company as [fnm], COMPANY  from para_company where company in (select isin from bids_TB where status_flag='0' or status_flag is null)", cn)
            Dim ds As New DataSet
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "Para_Security_Type")
            If ds.Tables(0).Rows.Count > 0 Then
                ASPxComboBox1.DataSource = ds
                ASPxComboBox1.TextField = "fnm"
                ASPxComboBox1.ValueField = "COMPANY"
                ASPxComboBox1.DataBind()
            Else

            End If

        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub ASPxButton8_Click(sender As Object, e As EventArgs) Handles ASPxButton8.Click
        Dim strscript As String
        strscript = "<script langauage=JavaScript>"
        strscript += "window.open('tb_schedule.aspx?Company=" & ASPxComboBox1.SelectedItem.Value.ToString & "');"
        strscript += "</script>"
        ClientScript.RegisterStartupScript(Me.GetType(), "newwin", strscript)
    End Sub
End Class
