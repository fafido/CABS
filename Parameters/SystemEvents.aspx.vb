
Imports System.IO
Partial Class Parameters_Default
    Inherits System.Web.UI.Page
    Dim constr As String = (System.Configuration.ConfigurationManager.AppSettings("connpath"))
    Dim cn As New SqlConnection(constr)
    Dim adp As SqlDataAdapter
    Dim cmd As SqlCommand
    Shared random As New Random()
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        FillGrid()
    End Sub
    Public Sub FillGrid()
        Dim ds As New DataSet
        cmd = New SqlCommand("SELECT * from para_SystemEvents", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "para_SystemEvents")

        If (ds.Tables(0).Rows.Count > 0) Then
            grdvEvents.DataSource = ds.Tables(0)
            grdvEvents.DataBind()
        Else
            'msgbox("not found")
        End If
    End Sub


    Protected Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim dsid As New DataSet



        Dim cmd1 = New SqlCommand("insert into para_SystemEvents (Event,EventTime,LastRun) values ('" & txtEvent.Text & "','" & tpEventTime.SelectedTime.ToString & "','" & Date.Now.ToString & "')", cn)


        If (cn.State = ConnectionState.Open) Then
            cn.Close()
        End If
        cn.Open()
        cmd1.ExecuteNonQuery()
        cn.Close()

        FillGrid()

        txtEvent.Text = ""
        'tpEventTime.SelectedTime = ""
        txtLastRun.Text = ""
    End Sub

    Protected Sub grdvEvents_SelectedIndexChanged(sender As Object, e As EventArgs) Handles grdvEvents.SelectedIndexChanged
        'If Not IsPostBack = True Then

        txtEvent.Text = grdvEvents.SelectedRow.Cells(1).Text
        'tpEventTime.SelectedTime = grdvEvents.SelectedRow.Cells(2).Text
        txtLastRun.Text = grdvEvents.SelectedRow.Cells(3).Text



        Dim cmd1 = New SqlCommand("Delete from para_SystemEvents where Event = '" & grdvEvents.SelectedRow.Cells(1).Text & "'", cn)
        If (cn.State = ConnectionState.Open) Then
            cn.Close()
        End If
        cn.Open()
        cmd1.ExecuteNonQuery()
        cn.Close()
        If Not IsPostBack = True Then
            FillGrid()
        End If
        ' End If
    End Sub
End Class
