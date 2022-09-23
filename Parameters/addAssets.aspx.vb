Partial Class addNewAssets
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
                getSecurities_Types()
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Protected Sub clearall()
        txtDesc.Text = ""
        txtAssetName.Text = ""
        getSecurities_Types()
    End Sub
    Protected Sub ASPxButton7_Click(sender As Object, e As EventArgs) Handles ASPxButton7.Click
        If txtAssetName.Text <> "" And txtDesc.Text <> "" Then
            cmd = New SqlCommand("select * from Assets where AssetName='" & txtAssetName.Text & "'", cn)
            Dim ds As New DataSet
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "Assets")
            If ds.Tables(0).Rows.Count <= 0 Then
                cmd = New SqlCommand("insert into Assets([AssetName],[AssetDescription])values('" & txtAssetName.Text & "','" & txtDesc.Text & "')", cn)
                If cn.State = ConnectionState.Open Then
                    cn.Close()
                End If
                cn.Open()
                Dim y As Integer = cmd.ExecuteNonQuery()
                cn.Close()
                clearall()
            Else
                msgbox("Asset Already Exists")
                Exit Sub
            End If
        Else
            msgbox("Enter All Details")
            Exit Sub
        End If
    End Sub
    Protected Sub getSecurities_Types()
        Try
            cmd = New SqlCommand("select ID,AssetName as [Asset],[AssetDescription] as [Asset Description] from Assets", cn)
            Dim ds As New DataSet
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "Asset")
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
