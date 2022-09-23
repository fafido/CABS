Partial Class TransferSec_AccountsClassifications
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
            getclasses()

            If (Not IsPostBack) Then
                checkSessionState()
            End If
            If Session("finish") = "yes" Then
                Session("finish") = ""
                msgbox("Class Captured")
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub ASPxButton6_Click(sender As Object, e As EventArgs) Handles ASPxButton6.Click
        If txtclasscode.Text <> "" And txtclassdescription.Text <> "" And txtclassname.Text <> "" Then
            cmd = New SqlCommand("  insert into para_brokerclasses values ('" + Session("brokercode") + "','" + txtclassname.Text + "','" + txtclasscode.Text + "','" + txtclassdescription.Text + "')", cn)
            If (cn.State = ConnectionState.Open) Then
                cn.Close()
            End If
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()

            Try
                cmd = New SqlCommand("insert into audit_log ([userid],[date],[time],[name],[activity], [userid_2], [request_id],[Browser],[IP],[Machine],[Broker_id]) values((select id from systemusers where username='" & Session("username") & "' and companycode='" + Session("Brokercode") + "'),'" & Date.Now.Date & "','" & Date.Now.Hour & ":" & Date.Now.Minute & ":" & Date.Now.Second & "','" + Session("username") + "','Created a new " + txtclassname.Text + " class',0,'','" + HttpContext.Current.Request.UserAgent + "','" + HttpContext.Current.Request.UserHostAddress + "','" + HttpContext.Current.Request.UserHostName + "','" + Session("brokercode") + "')", cn)
                If (cn.State = ConnectionState.Open) Then
                    cn.Close()
                End If
                cn.Open()
                cmd.ExecuteNonQuery()
                cn.Close()

            Catch ex As Exception

            End Try
            Session("finish") = "yes"
            Response.Redirect(Request.RawUrl)

        Else
            msgbox("Please fill all the required fields")
        End If
       
    End Sub
    Public Sub getclasses()
        Dim ds As New DataSet
        cmd = New SqlCommand("select Id as ID, Broker as Broker, Class_name as [Class Name], Class_code as [Class Code], Description as [Description] from para_brokerclasses", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "Accounts_Audit")
        If (ds.Tables(0).Rows.Count > 0) Then
            grdClassTypes.DataSource = ds
            grdClassTypes.DataBind()

        End If
    End Sub
End Class
