Partial Class CaptureAML
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


    Public Function Idexists() As Boolean

        Dim dsport As New DataSet
        cmd = New SqlCommand("select * from AML_List where id_number='" + txtIdNo.Text + "'", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(dsport, "trans")
        If (dsport.Tables(0).Rows.Count > 0) Then
            Return True
        Else
            Return False
        End If
    End Function
    Public Function mobileexists() As Boolean

        Dim dsport As New DataSet
        cmd = New SqlCommand("select * from AML_List where mobile='" + txtmobile.Text + "'", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(dsport, "trans")
        If (dsport.Tables(0).Rows.Count > 0) Then
            Return True
        Else
            Return False
        End If
    End Function
    Protected Sub getlist()
        Dim dsport As New DataSet
        cmd = New SqlCommand("select id as [System ID], Account_name as [Last Name], other_name as [Other Names], Mobile, ID_NUMBER AS [Identification], [Type] from AML_List", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(dsport, "trans")
        If (dsport.Tables(0).Rows.Count > 0) Then
            grdPortfolios.DataSource = dsport.Tables(0)
            grdPortfolios.DataBind()
            '    GetCashBal()
        Else
            grdPortfolios.DataSource = Nothing
            grdPortfolios.DataBind()

        End If
    End Sub


    Protected Sub ASPxButton5_Click(sender As Object, e As EventArgs) Handles ASPxButton5.Click
        If txtIdNo.Text <> "" And txtForenames.Text <> "" And txtSurnames.Text <> "" Then
            If mobileexists() = True Then
                msgbox("Mobile Number already exist!")
                Exit Sub
            End If
            If Idexists() = True Then
                msgbox("ID Number already exist!")
                Exit Sub
            End If
            cmd = New SqlCommand("insert into AML_List (account_name, other_name, mobile, captured_by, id_number, [Type]) values ('" + txtSurnames.Text + "','" + txtForenames.Text + "','" + txtmobile.Text + "','" + Session("userid") + "','" + txtIdNo.Text + "','" + cmbtype.SelectedItem.Text + "')", cn)
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()
            Session("finish") = "done"
            Response.Redirect(Request.RawUrl)
        Else
            msgbox("Please enter all details!")
            Exit Sub
        End If

    End Sub


    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Session("finish") = "done" Then
            Session("finish") = ""
            msgbox("Successful!")
        End If
        If Not IsPostBack = True Then
            getlist()
        End If
    End Sub
End Class
