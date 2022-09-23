Imports System.Data
Imports System.Data.SqlClient
Imports System.Net.Mail
Imports System.IO
Imports System
Imports System.Configuration
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls
Imports DevExpress.Web.ASPxGridView

Partial Class CDSMode_UserAccountsApproval
    Inherits System.Web.UI.Page
    Dim constr As String = (System.Configuration.ConfigurationManager.AppSettings("connpath"))
    Dim cn As New SqlConnection(constr)
    Dim adp As SqlDataAdapter
    Dim cmd, cmmd As SqlCommand

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
        FillGrid()
        FillGrid1()
    End Sub
    Public Sub FillGrid()
        Dim status As String
        status = "Pending"
        Dim ds As New DataSet
        cmd = New SqlCommand("SELECT * from Unit_Trust_Funding where status ='" & status & "'", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "Unit_Trust_Funding")
        If (ds.Tables(0).Rows.Count > 0) Then
            grdvCharges.DataSource = ds.Tables(0)
            grdvCharges.DataBind()
        Else
            'msgbox("not found")
        End If
    End Sub
    Public Sub FillGrid1()

        Dim ds As New DataSet
        cmd = New SqlCommand("SELECT * from Approved_Unit_Trust_Funding ", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "Unit_Trust_Funding")
        If (ds.Tables(0).Rows.Count > 0) Then
            grdvCharges1.DataSource = ds.Tables(0)
            grdvCharges1.DataBind()
        Else
            'msgbox("not found")
        End If
    End Sub

    Protected Sub grdvCharges_RowCommand(sender As Object, e As DevExpress.Web.ASPxGridView.ASPxGridViewRowCommandEventArgs)
        Dim myID As String = e.KeyValue.ToString
        If e.CommandArgs.CommandName = "Select" Then
            getExistingUnitTrustDetails(myID)

        End If
    End Sub

    Sub getExistingUnitTrustDetails(ByVal myID As String)
        Dim sql_str As String = ""
        Dim status As String
        status = "Pending"
        sql_str = "SELECT * from Unit_Trust_Funding where status ='" & status & "'AND ID ='" & myID & "'"
        Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("conpath").ConnectionString)
            Using cmd As New SqlCommand(sql_str, con)

                Dim dss As New DataSet
                Dim adp = New SqlDataAdapter(cmd)
                adp.Fill(dss, "Unit_Trust_Funding")
                If dss.Tables(0).Rows.Count > 0 Then

                    Dim dr As DataRow = dss.Tables(0).Rows(0)

                    txtDescription.Text = dr.Item("description").ToString
                    txtFunding_Code.Text = dr.Item("Funding_Code").ToString
                    txtFunding_Name.Text = dr.Item("Funding_Name").ToString
                    txtIssuer.Text = dr.Item("issuer").ToString
                    txtunits.Text = dr.Item("Units").ToString
                End If
            End Using
        End Using
    End Sub

    Protected Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim status As String
        status = "Accepted"
        cn.Open()
        cmd = New SqlCommand("insert into Approved_Unit_Trust_Funding(Funding_Code,Funding_Name,description,issuer,status, Units) values('" & txtFunding_Code.Text & "','" & txtFunding_Name.Text & "','" & txtDescription.Text & "','" & txtIssuer.Text & "','" & status & "','" + txtunits.Text + "')", cn)
        cmmd = New SqlCommand("UPDATE Unit_Trust_Funding set [status] ='" + status + "' where  issuer='" & txtIssuer.Text & "'", cn)
        If (cn.State = ConnectionState.Open) Then
            cmd.ExecuteNonQuery()
            cn.Close()
            cn.Open()

            cmd = New SqlCommand("UPDATE Unit_Trust_Funding set [status] ='" + status + "' where  issuer='" & txtIssuer.Text & "'", cn)
            cmd.ExecuteNonQuery()
            cn.Close()
        End If

        clear()

        FillGrid1()
        FillGrid()

        msgbox("Fund successfully Accepted")
    End Sub
    Public Sub clear()
        txtDescription.Text = ""
        txtFunding_Code.Text = ""
        txtFunding_Name.Text = ""
        txtIssuer.Text = ""

    End Sub

    Protected Sub btnReject_Click(sender As Object, e As EventArgs) Handles btnReject.Click
        Dim status As String
        status = "Rejected"
        cn.Open()
        cmd = New SqlCommand("Update Unit_Trust_Funding set status='" & status & "'where issuer ='" & txtIssuer.Text & "' ", cn)
        If (cn.State = ConnectionState.Open) Then
            cn.Close()
        End If
        cn.Open()
        cmd.ExecuteNonQuery()
        msgbox("Fund successfully Rejected ")
        clear()
        cn.Close()
        FillGrid()
        FillGrid1()
    End Sub
End Class
