Imports System.Data
Imports System.Data.SqlClient

Partial Class Parameters_frmIndustry
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
                GetIndustries()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub


    Public Sub GetIndustries()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("Select * from para_industry", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "para_industry")
            GridView1.DataSource = ds.Tables("para_Industry")
            GridView1.DataBind()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Protected Sub btnSave_click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Try
            If txtCode.Text = "" Then
                MsgBox("Enter Industry Code")
                txtCode.Focus()
                Exit Sub
            End If
            If txtFname.Text = "" Then
                MsgBox("Enter Industry Name")
                txtFname.Focus()
                Exit Sub
            End If


            cmd = New SqlCommand("insert into para_Industry (Code,Fnam) values('" & txtCode.Text & "','" & txtFname.Text & "')", cn)
            If (cn.State = ConnectionState.Open) Then
                cn.Close()
            End If
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()
            GetIndustries()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Class
