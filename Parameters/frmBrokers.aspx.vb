Imports System.Data
Imports System.Data.SqlClient

Partial Class Parameters_frmBrokers
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
                GetBokers()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub


    Public Sub GetBokers()
        Try
            Dim ds As New DataSet
            Dim dtable As New DataTable
            cmd = New SqlCommand("Select Broker_Code,Fnam,Address,Comments as 'Contact Detail' from para_Broker", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "para_Broker")
            GridView1.DataSource = ds.Tables("para_Broker")
            GridView1.DataBind()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Try

            If txtCode.Text = "" Then
                MsgBox("Enter Broker Code")
                txtCode.Focus()
                Exit Sub
            End If
            If txtFname.Text = "" Then
                MsgBox("Enter Broker Name")
                txtFname.Focus()
                Exit Sub
            End If
          
            cmd = New SqlCommand("insert into para_broker (BrokerCode,Fnam,Address,Comments) values('" & txtCode.Text & "'," & txtFname.Text & "','" & txtAddress.Text & " " & txtCity.Text & "','" & txtPhoneNo.Text & "   " & txtEmail.Text & "')", cn)
            If (cn.State = ConnectionState.Open) Then
                cn.Close()
            End If
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()
            GetBokers()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Class
