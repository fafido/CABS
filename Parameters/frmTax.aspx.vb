

Imports System.Data
Imports System.Data.SqlClient
Partial Class Parameters_frmTax
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
                GetTaxCodes()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub


    Public Sub GetTaxCodes()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("Select * from para_tax", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "para_tax")
            GridView1.DataSource = ds.Tables("para_tax")
            GridView1.DataBind()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Protected Sub btnSave_click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Try
            If txtFname.Text = "" Then
                msgbox("Enter Tax code FullName")
                txtFname.Focus()
                Exit Sub
            End If
            If txtTaxCode.Text = "" Then
                msgbox("Enter Tac Code")
                txtTaxCode.Focus()
                Exit Sub
            End If

            If txtRate.Text = "" Then
                msgbox("Enter Tax Rate")
                txtRate.Focus()
                Exit Sub
            End If

            cmd = New SqlCommand("insert into para_tax (id,Code,fnam,rate,status) values((select max(id)+1 from para_tax),'" & txtTaxCode.Text & "','" & txtFname.Text & "','" & txtRate.Text & "','" & txtStatus.Text & "')", cn)
            If (cn.State = ConnectionState.Open) Then
                cn.Close()
            End If
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()
            GetTaxCodes()
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
End Class

