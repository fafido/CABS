Imports System.Data
Imports System.Data.SqlClient

Partial Class CDSMode_FRMcOUNTRY
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
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub



    Public Sub GetCountries()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("Select * from para_Country", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "para_Country")
            GridView1.DataSource = ds.Tables("para_Country")
            GridView1.DataBind()
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Try
            If txtCode.Text = "" Then
                msgbox("Enter country Short Name")
                txtCode.Focus()
                Exit Sub
            End If
            If txtFname.Text = "" Then
                msgbox("Enter Countrry Full Name")
                txtFname.Focus()
                Exit Sub
            End If

            cmd = New SqlCommand("insert into para_Country (Fnam,Country) values('" & txtCode.Text & "','" & txtFname.Text & "')", cn)
            If (cn.State = ConnectionState.Open) Then
                cn.Close()
            End If
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()
            GetCountries()
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
End Class
