
Imports System.Data
Imports System.Data.SqlClient

Partial Class Utilities_formsadd
    Inherits System.Web.UI.Page
    Dim constr As String = (System.Configuration.ConfigurationManager.AppSettings("connpath"))
    Dim cn As New SqlConnection(constr)
    Dim cmd As SqlCommand
    Dim adp As SqlDataAdapter
    Public Sub msgbox(ByVal strMessage As String)

        'finishes server processing, returns to client.
        Dim strScript As String = "<script language=JavaScript>"
        strScript += "window.alert(""" & strMessage & """);"
        strScript += "</script>"
        Dim lbl As New System.Web.UI.WebControls.Label
        lbl.Text = strScript
        Page.Controls.Add(lbl)

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Try
            Page.MaintainScrollPositionOnPostBack = True
            If (Not IsPostBack) Then
                GetCountries()
                getusertypes()
                getfolders()
                getmodules()

            End If
            If Session("finish") = "yes" Then
                Session("finish") = ""
                msgbox("Successful")
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub



    Public Sub GetCountries()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("  select ms.name as [Form Name], m.Name as [Module Name],  ms.folder as Folder,ms.user_type as [For User] from ModuleSubs ms,modules m where ms.ModuleID= m.Id", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "para_Country")
            GridView1.DataSource = ds.Tables("para_Country")
            GridView1.DataBind()
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub getusertypes()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("Select distinct user_type from modulesubs where user_type is not null and user_type<>''", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "para_Country")
            DropDownList3.DataSource = ds
            DropDownList3.DataTextField = "user_type"
            DropDownList3.DataBind()

        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub getfolders()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("Select distinct folder from modulesubs where folder<>''", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "para_Country")
            DropDownList1.DataSource = ds
            DropDownList1.DataTextField = "folder"
            DropDownList1.DataBind()

        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub getmodules()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("Select name, id from modules", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "para_Country")
            DropDownList2.DataSource = ds
            DropDownList2.DataTextField = "name"
            DropDownList2.DataValueField = "id"
            DropDownList2.DataBind()

        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        cmd = New SqlCommand("insert into modulesubs (id, name, ModuleID, url, folder, user_type ) values (((select max(id) from ModuleSubs)+1),'" + txtFname.Text + "'," + DropDownList2.SelectedValue + ",'" + txturl.Text + "','" + DropDownList1.SelectedItem.Text + "','" + DropDownList3.SelectedItem.Text + "')", cn)
        If (cn.State = ConnectionState.Open) Then
            cn.Close()
        End If
        cn.Open()
        cmd.ExecuteNonQuery()
        cn.Close()
        Session("finish") = "yes"
        Response.Redirect(Request.RawUrl)
    End Sub
End Class
