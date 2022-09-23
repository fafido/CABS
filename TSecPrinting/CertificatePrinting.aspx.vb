Partial Class TSecPrinting_CertificatePrinting
    Inherits System.Web.UI.Page
    Dim cn As SqlConnection
    Dim cmd As SqlCommand
    Dim adp As New SqlDataAdapter
    Dim cnstr As String

    Public Function Authenticity() As Integer
        Try
            Dim dschk As New DataSet
            cmd = New SqlCommand("select userid from usermanagement where userid='" & Session("Username") & "' and UpdateCert=1", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(dschk, "usermanagement")
            If (dschk.Tables(0).Rows.Count > 0) Then
                Return 1
            Else
                Return 0
            End If

        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Function

    Protected Sub btnGetlist_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGetlist.Click
        If (rbUpdated.Checked) Then
            Dim dsUpdateno As New DataSet
            Try

                Dim i As Integer = 0
                i = Authenticity()

                If (i = 0) Then
                    msgbox("You are not an Authenticated User For Certificate Printing")
                    Exit Sub
                End If
                'cmd = New SqlCommand("select distinct update_no,convert(varchar,update_no)+' '+company+' '+convert(varchar,datepart(month,date_created))+'/'+convert(varchar,datepart(day,date_created))+'/'+convert(varchar,datepart(year,date_created)) as updatenos from mast where printed=1 and update_no<>0 and mast.shareholder not in(select cds_Ac_no from para_company)", cn)
                cmd = New SqlCommand("select distinct update_no,convert(varchar,update_no)+' '+company+' '+convert(varchar,datepart(month,date_created))+'/'+convert(varchar,datepart(day,date_created))+'/'+convert(varchar,datepart(year,date_created)) as updatenos from mast where printed=1 and update_no<>0 order by update_no", cn)
                adp = New SqlDataAdapter(cmd)
                adp.Fill(dsUpdateno, "mast")
                ddlUpdateno.DataSource = dsUpdateno
                ddlUpdateno.DataValueField = "update_no"
                ddlUpdateno.DataTextField = "updatenos"
                ddlUpdateno.DataBind()

            Catch ex As Exception
                msgbox(ex.Message)
            End Try
        ElseIf (rbnotUpdated.Checked) Then

            Dim dsUpdateno As New DataSet
            Try
                Dim i As Integer = 0
                i = Authenticity()

                If (i = 0) Then
                    msgbox("You are not Authenticated User For Certificate Updating")
                    Exit Sub
                End If

                'cmd = New SqlCommand("select distinct update_no ,convert(varchar,update_no)+' '+company as updatenos from mast where printed=0 and update_no<>0", cn)
                cmd = New SqlCommand("select distinct update_no ,convert(varchar,update_no)+' '+company as updatenos from mast where printed=0 and update_no<>0", cn)

                adp = New SqlDataAdapter(cmd)
                adp.Fill(dsUpdateno, "mast")
                ddlUpdateno.DataSource = Nothing

                ddlUpdateno.DataSource = dsUpdateno

                ddlUpdateno.DataValueField = "update_no"
                ddlUpdateno.DataTextField = "updatenos"
                ddlUpdateno.DataBind()

            Catch ex As Exception
                msgbox(ex.Message)
            End Try

        End If
        ' btnPrint.Enabled = False

        ''populate the company combo
        'Dim dscompany As New DataSet
        'Try
        '    cmd = New SqlCommand("select distinct company  from mast ", cn)
        '    adp = New SqlDataAdapter(cmd)
        '    adp.Fill(dscompany, "mast")
        '    ddlCompany.DataSource = dscompany
        '    ddlCompany.DataValueField = "company"
        '    ddlCompany.DataBind()

        'Catch ex As Exception
        '     msgbox(ex.Message)
        'End Try


    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        rbUpdated.Focus()

        Page.MaintainScrollPositionOnPostBack = True
        cnstr = (System.Configuration.ConfigurationManager.AppSettings("connpath"))
        cn = New SqlConnection(cnstr)
        If Not IsPostBack Then
            selectTemplate()
        End If

        Page.MaintainScrollPositionOnPostBack = True

    End Sub
    Public Sub selectTemplate()
        Dim i As Integer

        If IO.Directory.Exists(Server.MapPath("CertReportTemplate")) Then
            Dim strFiles() As String = IO.Directory.GetFiles(Server.MapPath("CertReportTemplate"), "*.rpt")
            Dim strfileName(strFiles.Length - 1) As String
            For i = 0 To strFiles.Length - 1
                strfileName(i) = IO.Path.GetFileName(strFiles(i))
            Next
            drTemplate.DataSource = strfileName
            drTemplate.DataBind()
        Else
            IO.Directory.CreateDirectory(Server.MapPath("CertReportTemplate"))
        End If
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

    Protected Sub btnChange_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnChange.Click
        Try
            If ddlUpdateno.SelectedValue <> "" Then

                Dim i As Integer = 0
                i = Authenticity()

                If (i = 0) Then
                    msgbox("You are not Authenticated User For Certificate Updating")
                    Exit Sub
                End If

                cn.Open()

                cmd = New SqlCommand("Update mast set printed= 1 where update_no=" & ddlUpdateno.SelectedValue, cn)
                cmd.ExecuteNonQuery()
                cn.Close()
                'btnGetlist_Click(Me, New System.EventArgs)
                btnPrint.Enabled = True

            Else
                msgbox("No Update no selected")
            End If

            'If (rbUpdated.Checked) Then
            '    Dim dsUpdateno As New DataSet
            '    Try
            '        cmd = New SqlCommand("select distinct update_no,convert(varchar,update_no)+' '+company+' '+convert(varchar,datepart(month,date_created))+'/'+convert(varchar,datepart(day,date_created))+'/'+convert(varchar,datepart(year,date_created)) as updatenos from mast where printed=1 and update_no<>0", cn)
            '        adp = New SqlDataAdapter(cmd)
            '        adp.Fill(dsUpdateno, "mast")
            '        ddlUpdateno.DataSource = dsUpdateno
            '        ddlUpdateno.DataValueField = "update_no"
            '        ddlUpdateno.DataTextField = "updatenos"
            '        ddlUpdateno.DataBind()

            '    Catch ex As Exception
            '         msgbox(ex.Message)
            '    End Try
            'ElseIf (rbnotUpdated.Checked) Then

            '    Dim dsUpdateno As New DataSet
            '    Try
            '        cmd = New SqlCommand("select distinct update_no ,convert(varchar,update_no)+' '+company as updatenos from mast where printed=0 and update_no<>0", cn)
            '        adp = New SqlDataAdapter(cmd)
            '        adp.Fill(dsUpdateno, "mast")
            '        ddlUpdateno.DataSource = Nothing

            '        ddlUpdateno.DataSource = dsUpdateno

            '        ddlUpdateno.DataValueField = "update_no"
            '        ddlUpdateno.DataTextField = "updatenos"
            '        ddlUpdateno.DataBind()

            '    Catch ex As Exception
            '         msgbox(ex.Message)
            '    End Try

            'End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub ddlUpdateno_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlUpdateno.SelectedIndexChanged
        'Try
        '    Dim dscomp As New DataSet
        '    Try
        '        cmd = New SqlCommand("select company  from mast where pupdate_no", cn)
        '        adp = New SqlDataAdapter(cmd)
        '        adp.Fill(dsUpdateno, "mast")
        '    Catch ex As Exception

        '    End Try
        '    lblcompany.Text = ddlUpdateno.Text

    End Sub

    Protected Sub btnPrint_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        Try

            Dim j As Integer = 0
            j = Authenticity()

            If (j = 0) Then
                msgbox("You are not Authenticated User For Certificate Updating")
                Exit Sub
            End If

            'audit trail
            Dim dsaudit As New DataSet
            cmd = New SqlCommand("select * from mast where update_no=" & ddlUpdateno.Text, cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(dsaudit, "mast")



            Dim i As Integer
            For i = 0 To dsaudit.Tables(0).Rows.Count - 1
                cmd = New SqlCommand("insert into printedcertaudit (certno,shareholder,shares,company,tranno,printedon,printedby) values (" & dsaudit.Tables(0).Rows(i).Item("cert").ToString() & "," & dsaudit.Tables(0).Rows(i).Item("shareholder").ToString() & "," & dsaudit.Tables(0).Rows(i).Item("shares").ToString() & ",'" & dsaudit.Tables(0).Rows(i).Item("company").ToString() & "'," & dsaudit.Tables(0).Rows(i).Item("xfer").ToString() & ",'" & Date.Now & "','" & Session("username") & "')", cn)
                cn.Open()
                cmd.ExecuteNonQuery()
                cn.Close()
            Next





            If ddlUpdateno.SelectedValue <> "" Then
                Dim strscript As String
                strscript = "<script langauage=JavaScript>"
                strscript += "window.open('frmrptupdatecertprint.aspx?updateno=" & ddlUpdateno.SelectedValue & "&fname=" & drTemplate.Text & "');"
                strscript += "</script>"
                ClientScript.RegisterStartupScript(Me.GetType(), "newwin", strscript)
                ' btnPrint.Enabled = False
            Else
                msgbox("No Update no selected")
            End If

        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
End Class
