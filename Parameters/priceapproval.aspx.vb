Imports System.Collections.Generic
Imports System.IO
Imports DevExpress.Web.ASPxEditors
Imports DevExpress.Web.ASPxGridView

Partial Class Parameters_priceapproval
    Inherits System.Web.UI.Page
    Dim constr As String = (System.Configuration.ConfigurationManager.AppSettings("connpath"))
    Dim cn As New SqlConnection(constr)
    Dim adp As SqlDataAdapter
    Dim cmd As SqlCommand
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
                getSecurities_Categories()
                '    loadcompanies()

            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Public Sub approve(id As String)
        cmd = New SqlCommand("declare @id nvarchar(50)='" + id + "' delete from Market_data_History where ticker=(select ticker from Market_data_History_audit where id=@id) and convert(date,[Date])=(select [date] from Market_data_History_audit where id=@id) insert into Market_data_History (Ticker, Current_price, counter_type, [Date], CaptureDate) select Ticker, Current_price, counter_type, [Date], CaptureDate from Market_data_History_audit where id=@id update Market_Data_History_audit set ApprovedBy='" + Session("Username") + "', ApprovalDate=getdate() where id=@id", cn)
        If cn.State = ConnectionState.Open Then
            cn.Close()
        End If
        cn.Open()
        Dim y As Integer = cmd.ExecuteNonQuery()
        cn.Close()

    End Sub
    Public Sub decline(id As String)
        cmd = New SqlCommand("update Market_Data_History_audit set ApprovedBy='" + Session("Username") + "', ApprovalDate=getdate(), rejected='1' where id=@id", cn)
        If cn.State = ConnectionState.Open Then
            cn.Close()
        End If
        cn.Open()
        Dim y As Integer = cmd.ExecuteNonQuery()
        cn.Close()

    End Sub
    Protected Sub getSecurities_Categories()
        Try
            cmd = New SqlCommand("select * from Market_Data_History_audit where rejected is NULL and ApprovedBy is NULL", cn)
            Dim ds As New DataSet
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "para_Country")
            If ds.Tables(0).Rows.Count > 0 Then
                ASPxGridView2.DataSource = ds.Tables(0)
            Else
                ASPxGridView2.DataSource = Nothing
            End If
            ASPxGridView2.DataBind()
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Public Function dt() As DataSet
        cmd = New SqlCommand("select * from Market_Data_History_audit where rejected is NULL and ApprovedBy is NULL", cn)
        Dim ds As New DataSet
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "para_Country")
        If ds.Tables(0).Rows.Count > 0 Then
            Return ds
        Else
            Return Nothing
        End If

    End Function

    Private Sub ASPxGridView2_DataBinding(sender As Object, e As EventArgs) Handles ASPxGridView2.DataBinding
        ASPxGridView2.DataSource = dt()

    End Sub
    Public Sub deleteexistingfordate(ByVal dt As String, ByVal company As String)
        cmd = New SqlCommand("delete from Market_data_History where ticker='" + company + "' and convert(date, [date])=convert(date,'" + dt + "')", cn)
        If cn.State = ConnectionState.Open Then
            cn.Close()
        End If
        cn.Open()
        cmd.ExecuteNonQuery()
        cn.Close()

    End Sub

    Private Sub ASPxGridView2_RowCommand(sender As Object, e As ASPxGridViewRowCommandEventArgs) Handles ASPxGridView2.RowCommand
        Dim id As String = e.KeyValue.ToString
        If e.CommandArgs.CommandName.ToString = "Approve" Then
            approve(id)
            getSecurities_Categories()
            msgbox("Successfully Approved")
        ElseIf e.CommandArgs.CommandName.ToString = "Decline" Then
            decline(id)
            getSecurities_Categories()
            msgbox("Successfully Declined")
        End If
    End Sub
    Protected Sub ASPxButton5_Click(sender As Object, e As EventArgs) Handles ASPxButton5.Click
        Dim keys As List(Of Object) = ASPxGridView2.GetCurrentPageRowValues(New String() {"id"})
        For Each key As Object In keys
            Dim chk As ASPxCheckBox = TryCast(ASPxGridView2.FindRowCellTemplateControlByKey(key, TryCast(ASPxGridView2.Columns("Selec"), GridViewDataColumn), "chk1"), ASPxCheckBox)

            Dim check As Boolean = chk.Checked
            If check = True Then
                approve(key.ToString)

            End If
        Next
        getSecurities_Categories()
        msgbox("Records Successfully Approved")
    End Sub
    Protected Sub ASPxButton6_Click(sender As Object, e As EventArgs) Handles ASPxButton6.Click
        Dim keys As List(Of Object) = ASPxGridView2.GetCurrentPageRowValues(New String() {"id"})
        For Each key As Object In keys
            Dim chk As ASPxCheckBox = TryCast(ASPxGridView2.FindRowCellTemplateControlByKey(key, TryCast(ASPxGridView2.Columns("Selec"), GridViewDataColumn), "chk1"), ASPxCheckBox)

            Dim check As Boolean = chk.Checked
            If check = True Then
                decline(key.ToString)

            End If
        Next
        getSecurities_Categories()
        msgbox("Records Successfully Declined")
    End Sub
    Protected Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        Dim myGridView As New ASPxGridView
        myGridView = ASPxGridView2
        If CheckBox1.Checked = True Then
            Dim keys As List(Of Object) = myGridView.GetCurrentPageRowValues(New String() {"id"})
            For Each key As Object In keys
                Dim chk As ASPxCheckBox = TryCast(ASPxGridView2.FindRowCellTemplateControlByKey(key, TryCast(ASPxGridView2.Columns("Selec"), GridViewDataColumn), "chk1"), ASPxCheckBox)
                chk.Checked = True
            Next
        Else
            Dim keys As List(Of Object) = myGridView.GetCurrentPageRowValues(New String() {"id"})
            For Each key As Object In keys
                Dim chk As ASPxCheckBox = TryCast(ASPxGridView2.FindRowCellTemplateControlByKey(key, TryCast(ASPxGridView2.Columns("Selec"), GridViewDataColumn), "chk1"), ASPxCheckBox)
                chk.Checked = False
            Next
        End If
    End Sub
End Class
