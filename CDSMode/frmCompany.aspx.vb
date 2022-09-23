Imports System.Data
Imports System.Data.SqlClient
Partial Class CDSMode_frmCompany
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
                GetCompanies()
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub


    Public Sub GetCompanies()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("Select [Company],[Fnam] ,[Date_created],[Issued_shares],[CDS_Ac_No] ,[registrar],[Add_1] ,[City],[Country],[Contact_Person],[Telephone],[Fax],[Comments] from para_company", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "para_company")
            GridView1.DataSource = ds.Tables("para_company")
            GridView1.DataBind()
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub btnPrintStatement_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPrintStatement.Click
        Try

            If txtFname.Text = "" Then
                msgbox("Enter Company Name")
                txtFname.Focus()
                Exit Sub
            End If
            If txtCDSNo.Text = "" Then
                msgbox("Enter CDS Number")
                txtCDSNo.Focus()
                Exit Sub
            End If
            If txtShort.Text = "" Then
                msgbox("Enter company Short Name")
                txtShort.Focus()
                Exit Sub
            End If
            If txtInitShares.Text = "" Then
                msgbox("Enter Initial Share Capital")
                txtInitShares.Focus()
                Exit Sub
            End If

            cmd = New SqlCommand("insert into para_company ([Company],[Fnam] ,[Date_created],[Issued_shares],[CDS_Ac_No] ,[registrar],[Add_1] ,[City],[Country],[Contact_Person],[Fax],[Comments]) values('" & txtShort.Text & "','" & txtFname.Text & "','" & BasicDatePicker1.Text & "','" & txtInitShares.Text & "','" & txtCDSNo.Text & "','" & txtTSec.Text & "','" & txtAddress.Text & "','" & txtCity.Text & "','" & txtCountry.Text & "','" & txtcontact.Text & "','" & txtFax.Text & "','" & txtComments.Text & "')", cn)
            If (cn.State = ConnectionState.Open) Then
                cn.Close()
            End If
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()
            GetCompanies()
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
End Class
