Imports System.Data
Imports System.Data.SqlClient
Partial Class Pledges_BorrowerRequestApproval
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
    Public Sub getCompany()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select distinct (company) from para_company", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "para_company")
            If (ds.Tables(0).Rows.Count > 0) Then
                cmbCompany.DataSource = ds.Tables(0)
                cmbCompany.DataValueField = "company"
                cmbCompany.DataBind()
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Page.MaintainScrollPositionOnPostBack = True
            If (Not IsPostBack) Then
                cmd = New SqlCommand("insert into UserActivityLog (UserName,Activity,TimeOfActivity,DateDone,CompanyCode) values ('" & Session("Username") & "','Accessed Borrower Request Approval Form','" & Date.Now & "','" & Now.Date & "','" & Session("BrokerCode") & "')", cn)
                If (cn.State = ConnectionState.Open) Then
                    cn.Close()
                End If
                cn.Open()
                cmd.ExecuteNonQuery()
                cn.Close()
                getCompany()
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub getCurrentBal()
        Try
            Dim ds, ds1 As New DataSet
            If (lblShareholder.Text <> "") Then
                cmd = New SqlCommand("Select * from mast where cds_number = '" & lblShareholder.Text & "' and company ='" & cmbCompany.Text & "'", cn)
                adp = New SqlDataAdapter(cmd)
                adp.Fill(ds1, "mast ")
                If (ds1.Tables(0).Rows.Count > 0) Then
                    cmd = New SqlCommand("Select sum(Shares) as Shares,sum(Pledge_Shares) as Pledges from mast where cds_number='" & lblShareholder.Text & "' and company='" & cmbCompany.Text & "'", cn)
                    adp = New SqlDataAdapter(cmd)
                    adp.Fill(ds, "mast")
                    Dim CurrentHolding, Pledges As Integer
                    CurrentHolding = ds.Tables(0).Rows(0).Item("Shares").ToString
                    Pledges = ds.Tables(0).Rows(0).Item("Pledges").ToString
                    'txtBalance.Text = CInt(CurrentHolding - Pledges)
                Else
                    'txtBalance.Text = "0"
                End If

            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Protected Sub cmbCompany_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbCompany.SelectedIndexChanged
        Try
            getCurrentBal()
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            cmd = New SqlCommand("insert into UserActivityLog (UserName,Activity,TimeOfActivity,DateDone,CompanyCode) values ('" & Session("Username") & "','Saved a borrower request approval record','" & Date.Now & "','" & Now.Date & "','" & Session("BrokerCode") & "')", cn)
            If (cn.State = ConnectionState.Open) Then
                cn.Close()
            End If
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()

        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
End Class
