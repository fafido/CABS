Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.IO

Partial Class Administration_AccountCreation
    Inherits System.Web.UI.Page
    Dim constr As String = (System.Configuration.ConfigurationManager.AppSettings("connpath"))
    Dim cn As New SqlConnection(constr)
    Dim cmd As SqlCommand
    Shared adp As SqlDataAdapter
    Dim ds As New DataSet
    Dim uploaded As Boolean = False

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Try
        Dim con As New SqlConnection()
        Page.MaintainScrollPositionOnPostBack = True
        con = New SqlConnection(constr)
        ' Dim surl As String = HttpContext.Current.Request.Url.AbsoluteUri
        ' surl = Mid(surl, surl.LastIndexOf("/") + 2)
        If Not IsPostBack Then

            getCompany()

        End If
        'Catch ex As Exception
        '    msgbox(ex.Message)
        'End Try

    End Sub




    Public Sub msgbox(ByVal strMessage As String)

        'finishes server processing, returns to client.
        Dim strScript As String = "<script language=JavaScript>"
        strScript += "window.alert(""" & strMessage & """);"
        strScript += "</script>"
        Dim lbl As New System.Web.UI.WebControls.Label
        lbl.Text = strScript
        Page.Controls.Add(lbl)

    End Sub
    Public Sub loadCountries(cmb As DropDownList)
        Try
            Using con As New SqlConnection(constr)
                Using cmd = New SqlCommand("select * from para_country", con)
                    Dim ds As New DataSet
                    adp = New SqlDataAdapter(cmd)
                    adp.Fill(ds, "BNCH")
                    loadCombo(ds.Tables(0), cmb, "country", "country")
                End Using
            End Using
        Catch ex As Exception
            cmb.ClearSelection()
        End Try
    End Sub
    Public Sub loadCombo(ByVal dt As DataTable, ByVal cmb As DropDownList, ByVal textField As String, ByVal valField As String)
        cmb.AppendDataBoundItems = True
        cmb.Items.Clear()
        cmb.Items.Add("")
        If dt.Rows.Count > 0 Then
            cmb.DataSource = dt
            cmb.DataTextField = textField
            cmb.DataValueField = valField
        Else
            cmb.DataSource = Nothing
        End If
        cmb.DataBind()
    End Sub





    'Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
    '    If accType.SelectedIndex = 0 Then
    '        Try

    '            Dim type As String = "Individual"
    '            Dim ds As New DataSet
    '            cmd = New SqlCommand("select national_id from SanctionedList where national_id='" & Natid.Text & "' ", cn)
    '            adp = New SqlDataAdapter(cmd)
    '            adp.Fill(ds, "SanctionedList")
    '            If (ds.Tables(0).Rows.Count > 0) Then
    '                msgbox("Person  already Exists, Chose another person")

    '                Exit Sub
    '            End If
    '            cmd = New SqlCommand("insert into SanctionedList (names,surname,address,birthdate,national_id,nationality,passport_number,account_type) values ('" & txtforenames.Text & "','" & txtSurname.Text & "','" & txtAdd1.Text & "','" & BasicDatePicker1.Text & "','" & Natid.Text & "','" & cmbCountry.Text & "','" & passnumber.Text & "','" & type & "' )", cn)
    '            If (cn.State = ConnectionState.Open) Then
    '                cn.Close()

    '            End If
    '            cn.Open()
    '            cmd.ExecuteNonQuery()
    '            cn.Close()

    '            msgbox("Person added")
    '            Response.Redirect("Sanctionedlist.aspx")

    '        Catch ex As Exception
    '            msgbox(ex.Message)
    '        End Try
    '    ElseIf accType.SelectedIndex = 1 Then
    '        Try

    '            Dim type As String = "Joint"
    '            Dim ds As New DataSet
    '            cmd = New SqlCommand("select surname from SanctionedList where surname='" & TextBox12.Text & "'", cn)
    '            adp = New SqlDataAdapter(cmd)
    '            adp.Fill(ds, "SanctionedList")
    '            If (ds.Tables(0).Rows.Count > 0) Then
    '                msgbox("Company  already Exists, Chose another name")

    '                Exit Sub
    '            End If
    '            cmd = New SqlCommand("insert into SanctionedList (surname,account_type) values ('" & TextBox12.Text & "','" & type & "' )", cn)
    '            If (cn.State = ConnectionState.Open) Then
    '                cn.Close()

    '            End If
    '            cn.Open()
    '            cmd.ExecuteNonQuery()
    '            cn.Close()

    '            msgbox("Details added")
    '            Response.Redirect("Sanctionedlist.aspx")


    '        Catch ex As Exception
    '            msgbox(ex.Message)
    '        End Try
    '    ElseIf accType.SelectedIndex = 2 Then
    '        Try

    '            Dim type As String = "Cooperate"
    '            Dim ds As New DataSet
    '            cmd = New SqlCommand("select surname from SanctionedList where surname='" & TextBox12.Text & "'", cn)
    '            adp = New SqlDataAdapter(cmd)
    '            adp.Fill(ds, "SanctionedList")
    '            If (ds.Tables(0).Rows.Count > 0) Then
    '                msgbox("Company  already Exists, Chose another name")

    '                Exit Sub
    '            End If
    '            cmd = New SqlCommand("insert into SanctionedList (surname,national_id,account_type) values ('" & TextBox13.Text & "', '" & TextBox14.Text & "'      ,'" & type & "' )", cn)
    '            If (cn.State = ConnectionState.Open) Then
    '                cn.Close()

    '            End If
    '            cn.Open()
    '            cmd.ExecuteNonQuery()
    '            cn.Close()

    '            msgbox("Details added")
    '            Response.Redirect("Sanctionedlist.aspx")


    '        Catch ex As Exception
    '            msgbox(ex.Message)
    '        End Try
    '    End If
    'End Sub
    'Public Sub getCompany()
    '    'Try
    '    Dim ds As New DataSet
    '    cmd = New SqlCommand("SELECT id, names,surname,national_id,nationality from [SanctionedList] order by id desc ", cn)
    '    adp = New SqlDataAdapter(cmd)
    '    adp.Fill(ds, "para_company")
    '    If ds.Tables("para_company").Rows.Count > 0 Then
    '        grdApps.DataSource = ds
    '        grdApps.DataBind()
    '    Else
    '        grdApps.DataSource = Nothing
    '        grdApps.DataBind()
    '    End If

    '    'Catch ex As Exception
    '    '    msgbox(ex.Message)
    '    'End Try
    'End Sub
    'Public Sub linkDiscard(ByVal sender As Object, ByVal e As System.EventArgs)
    '    Dim idd As String = CType(sender, LinkButton).CommandArgument
    '    cmd = New SqlCommand("Delete from [SanctionedList] where Id='" & idd & "' ", cn)
    '    If (cn.State = ConnectionState.Open) Then
    '        cn.Close()
    '    End If
    '    cn.Open()
    '    cmd.ExecuteNonQuery()
    '    cn.Close()
    '    msgbox("Delete Successful")
    '    Response.Redirect("Sanctionedlist.aspx")

    'End Sub


    'Protected Sub grdApps_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles grdApps.PageIndexChanging
    '    grdApps.PageIndex = e.NewPageIndex
    '    getCompany()
    'End Sub

    'Protected Sub Search_Click(sender As Object, e As EventArgs) Handles Search.Click
    '    gridsearch(SearchTxt.Text)
    'End Sub
    'Public Sub gridsearch(ByVal search As String)
    '    Dim ds As New DataSet
    '    cmd = New SqlCommand("SELECT id, names,surname,national_id,nationality from [SanctionedList] where surname like '%" + search + " %' or names like '%" + search + "%' ", cn)
    '    adp = New SqlDataAdapter(cmd)
    '    adp.Fill(ds, "para_company")
    '    If ds.Tables("para_company").Rows.Count > 0 Then
    '        grdApps.DataSource = ds
    '        grdApps.DataBind()
    '    Else
    '        grdApps.DataSource = Nothing
    '        grdApps.DataBind()
    '    End If


    'End Sub
    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        uploaded = Load_GSM_TRANS()
        If (uploaded) Then

            msgbox("upload successful")
            getCompany()
        End If

    End Sub
    Private Function Load_GSM_TRANS() As Boolean


        If FileUpload1.HasFile Then
            Dim connectionString As String = ""
            Dim fileName2 As String = Path.GetFileName(FileUpload1.PostedFile.FileName)

            Dim company As String = txtFor.Text
            Dim description As String = txtDescription.Text
            Dim fileLocation As String = ("C:\fila\") + fileName2 ' & Date.Now.ToString("ddMMyyyymmsss") & fileName2)
            FileUpload1.SaveAs(fileLocation)
            'cmd = New SqlCommand("insert into filing (name,uploader,location , company_id,description) values ('" & fileName2 & "', '" & Session("username") & "', '" & fileLocation & "','" & company & "' ,'" & description & "')", cn)
            'If (cn.State = ConnectionState.Open) Then
            '    cn.Close()

            'End If
            'cn.Open()
            'cmd.ExecuteNonQuery()
            'cn.Close()

            Return True
        Else
            Return False
        End If

    End Function
    Public Sub getCompany()
        'Try
        Dim ds As New DataSet
        cmd = New SqlCommand("SELECT id,name,description,company_id as [Document Owner] ,location from [filing]  where uploader='" & Session("username") & "'", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "para_company")
        If ds.Tables("para_company").Rows.Count > 0 Then
            grdApps.DataSource = ds
            grdApps.DataBind()
        Else
            grdApps.DataSource = Nothing
            grdApps.DataBind()
        End If

        'Catch ex As Exception
        '    msgbox(ex.Message)
        'End Try
    End Sub
    Protected Sub DownloadFile(ByVal sender As Object, ByVal e As EventArgs)
        Dim filePath As String = (TryCast(sender, LinkButton)).CommandArgument
        Response.ContentType = ContentType
        Response.AppendHeader("Content-Disposition", "attachment; filename=" & Path.GetFileName(filePath))
        Response.WriteFile(filePath)
        Response.[End]()
    End Sub
    Protected Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Response.Redirect("scann.aspx")
    End Sub

    Protected Sub grdApps_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles grdApps.PageIndexChanging
        grdApps.PageIndex = e.NewPageIndex
        getCompany()
    End Sub
End Class
