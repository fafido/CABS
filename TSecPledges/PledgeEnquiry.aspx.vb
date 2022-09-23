Partial Class TSecPledges_PledgeEnquiry
    Inherits System.Web.UI.Page
    Dim constr As String = (System.Configuration.ConfigurationManager.AppSettings("connpath"))
    Dim cn As New SqlConnection(constr)
    Dim cmd As SqlCommand
    Dim adp As SqlDataAdapter
    Protected Sub btnHolderNumSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnHolderNumSearch.Click
        Try
            getPledgeDetails()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Public Sub getPledgeDetails()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select pledge_no as [Reference],CDS_Number as [Shareholder],Company,Shares,Pledgee,Pledged_Reason,Date_Created from pledges where CDS_Number='" & txtshareholder.Text & "'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "pledges")
            If (ds.Tables(0).Rows.Count > 0) Then
                GdStatisticsView.DataSource = ds.Tables(0)
                GdStatisticsView.DataBind()
            Else
                GdStatisticsView.DataSource = Nothing
                GdStatisticsView.DataBind()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Protected Sub btnSearchName_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearchName.Click
        Try
            If (txtSearch.Text = "") Then
                MsgBox("Enter a valid search name")
                Exit Sub
            End If
            Dim ds As New DataSet
            cmd = New SqlCommand("Select surname+' '+forenames+' '+cds_number as namess from names where surname like '" & txtSearch.Text & "%'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "names")
            If (ds.Tables(0).Rows.Count > 0) Then
                lstName.DataSource = ds.Tables("names")
                lstName.DataValueField = "namess"
                lstName.DataBind()
            Else
                lstName.DataSource = Nothing
                lstName.DataValueField = ""
                lstName.DataBind()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Protected Sub btnSelect_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSelect.Click
        Try
            Dim ds As New DataSet
            If (lstName.SelectedIndex < 0) Then
                MsgBox("Select a name")
                Exit Sub
            End If
            cmd = New SqlCommand("Select CDS_Number from names where surname+' '+forenames+' '+cds_number = '" & lstName.SelectedItem.Text & "'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "names")
            txtshareholder.Text = (ds.Tables(0).Rows(0).Item("CDS_Number").ToString)
            getPledgeDetails()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Public Sub getPledges()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("Select CDS_Number,Company,SharesPledgee,Pledged_Reason,Date_Created from pledges where CDS_Number ='" & txtshareholder.Text & "'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "pledges")
            If (ds.Tables(0).Rows.Count > 0) Then
                GdStatisticsView.DataSource = ds.Tables(0)
                GdStatisticsView.DataBind()
            Else
                GdStatisticsView.DataSource = Nothing
                GdStatisticsView.DataBind()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Class
