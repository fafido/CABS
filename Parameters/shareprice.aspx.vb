
Imports System.Data
Imports System.Data.SqlClient

Partial Class Parameters_stockexchange
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
                GetBanks()
                Getcountries()

            End If
            If Session("finish") = "yes" Then
                Session("finish") = ""
                msgbox("Successful")
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try

    End Sub


    Public Sub GetBanks()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("Select * from para_stock_exchange", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "para_bank")
            GridView1.DataSource = ds.Tables("para_bank")
            GridView1.DataBind()
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub Getcountries()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select country from para_country", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "para_country")

            If ds.Tables(0).Rows.Count > 0 Then
                DropDownList1.DataSource = ds
                DropDownList1.DataTextField = "country"
                DropDownList1.DataBind()
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub btnSave_click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Try
            If txtCode.Text = "" Then
                msgbox("Enter Stock Exchange Code")
                txtCode.Focus()
                Exit Sub
            End If
            If txtFname.Text = "" Then
                msgbox("Enter Stock Exchange Name")
                txtFname.Focus()
                Exit Sub
            End If
            If txtFname0.Text = "" Then
                msgbox("Enter Stock Exchange Short Name")
                txtFname0.Focus()
                Exit Sub
            End If
            cmd = New SqlCommand("insert into para_stock_exchange  values('" & txtFname.Text & "','" & txtFname0.Text & "','" + DropDownList1.SelectedItem.Text + "','" & txtCode.Text & "')", cn)
            If (cn.State = ConnectionState.Open) Then
                cn.Close()
            End If
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()


            Session("finish") = "yes"
            Response.Redirect(Request.RawUrl)
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
End Class
