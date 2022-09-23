
Partial Class Reporting_adminreports
    Inherits System.Web.UI.Page
    Dim constr As String = (System.Configuration.ConfigurationManager.AppSettings("connpath"))
    Dim cn As New SqlConnection(constr)
    Dim adp As SqlDataAdapter
    Dim cmd As SqlCommand
    Public Sub msgbox(ByVal strMessage As String)
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
            If Session("UserName").ToString = "" Then
                Session.Abandon()
                Response.Cache.SetCacheability(HttpCacheability.NoCache)
                Response.Buffer = True
                Response.ExpiresAbsolute = DateTime.Now.AddDays(-1.0)
                Response.Expires = -1000
                Response.CacheControl = "no-cache"
                Response.Redirect("~/loginsystem.aspx", True)
            End If

            Page.MaintainScrollPositionOnPostBack = True
            If (Not IsPostBack) Then
                checkSessionState()
                checkcomment()

            End If
            If Session("finish") = "yes" Then
                Session("finish") = ""
                msgbox("Comment Sent")
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub checkcomment()
        If Session("usertype") <> "AuditAdmin" Then
            ASPxButton9.Visible = False

        Else
            ASPxButton9.Visible = True

        End If
    End Sub
  

    Protected Sub ASPxButton7_Click(sender As Object, e As EventArgs) Handles ASPxButton7.Click
        Panel6.Visible = False
        ASPxButton9.Visible = True
    End Sub
    Protected Sub ASPxButton4_Click(sender As Object, e As EventArgs) Handles ASPxButton4.Click
        Response.Redirect("~/Reporting/brokeraudit.aspx")
    End Sub

    Protected Sub ASPxButton1_Click(sender As Object, e As EventArgs) Handles ASPxButton1.Click
        Response.Redirect("~/Reporting/participants.aspx")
    End Sub

    Protected Sub ASPxButton2_Click(sender As Object, e As EventArgs) Handles ASPxButton2.Click
        Response.Redirect("~/Reporting/systemusers.aspx")
    End Sub

    Protected Sub ASPxButton3_Click(sender As Object, e As EventArgs) Handles ASPxButton3.Click
        Response.Redirect("~/Reporting/audit.aspx")
    End Sub

    Protected Sub ASPxButton5_Click(sender As Object, e As EventArgs) Handles ASPxButton5.Click
        Response.Redirect("~/CDSMode/Auditlog2.aspx")
    End Sub

    Protected Sub ASPxButton6_Click(sender As Object, e As EventArgs) Handles ASPxButton6.Click
        Response.Redirect("~/Reporting/lenders.aspx")
    End Sub

    Protected Sub ASPxButton8_Click(sender As Object, e As EventArgs) Handles ASPxButton8.Click

        If ASPxMemo1.Text <> "" Then
            cmd = New SqlCommand("insert into audit_comments (auditor, report, comment, date_posted) values ('" + Session("newid") + "','ADMIN REPORTS','" + ASPxMemo1.Text + "',getdate())", cn)
            If (cn.State = ConnectionState.Open) Then
                cn.Close()
            End If
            cn.Open()
            cmd.ExecuteNonQuery()
            Session("finish") = "yes"
            Response.Redirect(Request.RawUrl)
        Else
            msgbox("Please enter the comment!")
        End If


    End Sub

    Protected Sub ASPxButton9_Click(sender As Object, e As EventArgs) Handles ASPxButton9.Click

        ASPxButton9.Visible = False
        Panel6.Visible = True

    End Sub


    Protected Sub ASPxButton10_Click(sender As Object, e As EventArgs) Handles ASPxButton10.Click
        ExportTextFile()

    End Sub

    Protected Sub ExportTextFile()
        Dim constr As String = System.Configuration.ConfigurationManager.AppSettings("connpath")
        Using con As New SqlConnection(constr)
            Using cmd As New SqlCommand("SELECT * FROM names")
                Using sda As New SqlDataAdapter()
                    cmd.Connection = con
                    sda.SelectCommand = cmd
                    Using dt As New DataTable()
                        sda.Fill(dt)

                        'Build the Text file data.
                        Dim txt As String = String.Empty

                        For Each column As DataColumn In dt.Columns
                            'Add the Header row for Text file.
                            txt += column.ColumnName & vbTab & vbTab & vbTab & vbTab & vbTab & vbTab & vbTab & vbTab
                        Next

                        'Add new line.
                        txt += vbCr & vbLf

                        For Each row As DataRow In dt.Rows
                            For Each column As DataColumn In dt.Columns
                                'Add the Data rows.
                                txt += row(column.ColumnName).ToString() & vbTab & vbTab & vbTab & vbTab & vbTab & vbTab & vbTab & vbTab
                            Next

                            'Add new line.
                            txt += vbCr & vbLf
                        Next

                        'Download the Text file.

                        Response.Clear()
                        Response.Buffer = True
                        Response.AddHeader("content-disposition", "attachment;filename=SqlExport.txt")
                        Response.Charset = ""
                        Response.ContentType = "application/text"
                        Response.Output.Write(txt)
                        Response.Flush()
                        Response.End()
                    End Using
                End Using
            End Using
        End Using
    End Sub
End Class
