Partial Class tbtype
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
        txtDesc.Text = ""
        txtType.Text = ""
        txtdaystomaturity.Text = ""
        '     getSecurities_Types()
    End Sub
    Protected Sub ASPxButton7_Click(sender As Object, e As EventArgs) Handles ASPxButton7.Click
        If txtType.Text <> "" And txtDesc.Text <> "" And txtdaystomaturity.Text <> "" Then
            Try
                cmd = New SqlCommand("insert into para_billtypes (bill_type, number_of_days, create_date) values ('" + txtType.Text + "','" + txtdaystomaturity.Text + "',getdate())", cn)
                If cn.State = ConnectionState.Open Then
                    cn.Close()
                End If
                cn.Open()
                Dim y As Integer = cmd.ExecuteNonQuery()
                cn.Close()
                gebill_types()
                clearall()
                msgbox("Treasury Bill Term Successfully Captured!")
            Catch ex As Exception
                msgbox(ex.Message)
            End Try
        
        Else
            msgbox("Enter All Details")
            Exit Sub
        End If
    End Sub
    Protected Sub gebill_types()
        Try
            cmd = New SqlCommand("select Bill_type as [Term], number_of_days as [No of Days], CREATE_DATE AS [Date Created] from para_billtypes", cn)
            Dim ds As New DataSet
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "Para_Security_Type")
            If ds.Tables(0).Rows.Count > 0 Then
                ASPxGridView2.DataSource = ds.Tables(0)
            Else
                ASPxGridView2.DataSource = Nothing
            End If
            ASPxGridView2.DataBind()
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
End Class
