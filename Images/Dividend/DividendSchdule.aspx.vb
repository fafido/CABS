Partial Class Pledges_PledgeEnquiry
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
    Public Sub getcompany()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("Select distinct (company) from div_instr", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "div_instr")
            If (ds.Tables(0).Rows.Count > 0) Then
                cmbCompany.DataSource = ds.Tables(0)
                cmbCompany.DataValueField = "company"
                cmbCompany.DataBind()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Public Sub getDivno()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select distinct (div_no) from div_instr where company='" & cmbCompany.Text & "'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "div_instr")
            If (ds.Tables(0).Rows.Count > 0) Then
                cmbDividend.DataSource = ds.Tables(0)
                cmbDividend.DataValueField = "div_no"
                cmbDividend.DataBind()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Protected Sub cmbCompany_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbCompany.SelectedIndexChanged
        Try
            getDivno()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Page.MaintainScrollPositionOnPostBack = True
            If (Not IsPostBack) Then
                getcompany()
                getDivno()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Protected Sub btnSearchName_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearchName.Click
        Try
            Dim ds As New DataSet
            If (txtSearch.Text = "") Then
                MsgBox("Enter a valid holder number")
                Exit Sub
            End If
            cmd = New SqlCommand("Select * from dividend where company='" & cmbCompany.Text & "' and div_no=" & cmbDividend.Text & " and shareholder='" & txtSearch.Text & "'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "dividend")
            If (ds.Tables(0).Rows.Count > 0) Then
                GdStatisticsView.DataSource = ds.Tables(0)
                GdStatisticsView.DataBind()
            Else
                GdStatisticsView.DataSource = Nothing
                GdStatisticsView.DataBind()
                MsgBox("Invalid Holder number")
                Exit Sub
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Class

