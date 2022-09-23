Partial Class Parameters_Securities
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
                getSecurities()
                GetSec_Types()
                getAllcategories()
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Protected Sub clearall()
        txtSecurityname.Text = ""
        cmbCategory.SelectedIndex = 0
        cmbCdssetup.SelectedIndex = 0
        cmbType.SelectedIndex = 0
        txtDesc.Text = ""
        getSecurities()
    End Sub
    Protected Sub ASPxButton7_Click(sender As Object, e As EventArgs) Handles ASPxButton7.Click
        If cmbCategory.Text <> "" And cmbCdssetup.Text <> "" And cmbType.Text <> "" And txtSecurityname.Text <> "" Then
            cmd = New SqlCommand("select * from Para_Securities where Security_Name='" & txtSecurityname.Text & "'", cn)
            Dim ds As New DataSet
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "Para_Securities")
            If ds.Tables(0).Rows.Count <= 0 Then
                cmd = New SqlCommand("insert into Para_Securities([Security_Type],[Sub_Category],[Security_Name],[Description],[CDS_setup])values('" & cmbType.Text & "','" & cmbCategory.Text & "','" & txtSecurityname.Text & "','" & txtDesc.Text & "','" & cmbCdssetup.Text & "')", cn)
                If cn.State = ConnectionState.Open Then
                    cn.Close()
                End If
                cn.Open()
                Dim y As Integer = cmd.ExecuteNonQuery()
                cn.Close()
                clearall()
            Else
                msgbox("Security Already Exists")
                Exit Sub
            End If
        Else
            msgbox("Enter All Details")
            Exit Sub
        End If
    End Sub
    Protected Sub getSecurities()
        Try
            cmd = New SqlCommand("select ID,Security_Type as [Type],Security_Name as Security,CDS_setup as [CDS Set-up],[Description] from Para_Securities", cn)
            Dim ds As New DataSet
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "Securities")
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
    Protected Sub GetSec_Types()
        Try
            cmd = New SqlCommand("select distinct Security_Type from Para_Security_Type", cn)
            Dim ds As New DataSet
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "Para_Security_Type")
            If ds.Tables(0).Rows.Count > 0 Then
                cmbType.DataSource = ds.Tables(0)
                cmbType.TextField = "Security_Type"
                cmbType.ValueField = "Security_Type"
            Else
                cmbType.DataSource = Nothing
            End If
            cmbType.DataBind()
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Protected Sub getAllcategories()
        Try
            cmbCategory.Items.Clear()
            cmbCategory.Text = ""
            If cmbType.Text <> "" Then
                cmd = New SqlCommand("select * from Para_Security_Category where Security_Type='" & cmbType.Text & "'", cn)
                Dim ds As New DataSet
                adp = New SqlDataAdapter(cmd)
                adp.Fill(ds, "Para_Security_Category")
                If ds.Tables(0).Rows.Count > 0 Then
                    cmbCategory.DataSource = ds.Tables(0)
                    cmbCategory.TextField = "Security_Category"
                    cmbCategory.ValueField = "Security_Category"
                Else
                    cmbCategory.DataSource = Nothing
                End If
                cmbCategory.DataBind()
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Protected Sub cmbType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbType.SelectedIndexChanged
        getAllcategories()
    End Sub
End Class
