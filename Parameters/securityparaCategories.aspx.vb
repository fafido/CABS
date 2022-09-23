Partial Class Parameters_Securities_type
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
                getSecurities_Categories()
                GetSec_Types()
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Protected Sub clearall()
        txtDesc.Text = ""
        txtCategory.Text = ""
        getSecurities_Categories()
    End Sub
    Protected Sub ASPxButton7_Click(sender As Object, e As EventArgs) Handles ASPxButton7.Click
        If txtCategory.Text <> "" And txtDesc.Text <> "" And cmbType.Text <> "" Then
            cmd = New SqlCommand("select * from Para_Security_Category where Security_Category='" & txtCategory.Text & "' and Security_Type='" & cmbType.Text & "'", cn)
            Dim ds As New DataSet
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "Para_Security_Type")
            If ds.Tables(0).Rows.Count <= 0 Then
                cmd = New SqlCommand("insert into Para_Security_Category([Security_Type],[Security_Category],[Description])values('" & cmbType.Text & "','" & txtCategory.Text & "','" & txtDesc.Text & "')", cn)
                If cn.State = ConnectionState.Open Then
                    cn.Close()
                End If
                cn.Open()
                Dim y As Integer = cmd.ExecuteNonQuery()
                cn.Close()
                clearall()
            Else
                msgbox("Category Already Exists")
                Exit Sub
            End If
        Else
            msgbox("Enter All Details")
            Exit Sub
        End If
    End Sub
    Protected Sub GetSec_Types()
        Try
            cmd = New SqlCommand("select distinct Security_Type from Para_Security_Type", cn)
            Dim ds As New DataSet
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "Para_Security_Type")
            If ds.Tables(0).Rows.Count > 0 Then
                cmbType.DataSource = ds.Tables(0)
                cmbType.DataTextField = "Security_Type"
                cmbType.DataValueField = "Security_Type"
            Else
                cmbType.DataSource = Nothing
            End If
            cmbType.DataBind()
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Protected Sub getSecurities_Categories()
        Try
            cmd = New SqlCommand("select ID,[Security_Type] as [Type],Security_Category AS Category,[Description] from Para_Security_Category", cn)
            Dim ds As New DataSet
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "Para_Security_Category")
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
