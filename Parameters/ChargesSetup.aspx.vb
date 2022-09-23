



Partial Class Parameters_ChargesSetup
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
        Public Sub checkSessionState()
            Try
            Catch ex As Exception
                msgbox(ex.Message)
            End Try
        End Sub
        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            Try
                Page.MaintainScrollPositionOnPostBack = True
                If (Not IsPostBack) Then
                    checkSessionState()

            End If
            Catch ex As Exception
                msgbox(ex.Message)
            End Try
        End Sub
    Protected Sub clearall()
        txtAmount.Text = ""
        transSecurityType.SelectedIndex = 0
        currency.SelectedIndex = 0
    End Sub
    Public Sub getcharge(transactiontype As String)
        cmd = New SqlCommand("select * from [CDSC].[dbo].[paraCharges] where transtype ='" & transactiontype & "'", cn)
        Dim ds As New DataSet
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "para_AllSecurityTypes")
        If ds.Tables(0).Rows.Count > 0 Then
            txtAmount.Text = ds.Tables(0).Rows(0).Item("value")
            currency.Text = ds.Tables(0).Rows(0).Item("curreuncy")
        Else
            txtAmount.Text = "0"
        End If
    End Sub
    Protected Sub ASPxButton7_Click(sender As Object, e As EventArgs) Handles ASPxButton7.Click
        If transSecurityType.SelectedItem.Value <> "" And txtAmount.Text <> "" Then
            cmd = New SqlCommand("Select * from [CDSC].[dbo].[paraCharges] where transtype ='" & transSecurityType.SelectedItem.Value & "'", cn)
            Dim ds As New DataSet
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "para_AllSecurityTypes")
            If ds.Tables(0).Rows.Count <= 0 Then
                cmd = New SqlCommand("insert into [CDSC].[dbo].[paraCharges] ([transtype],[curreuncy],[value],[datecaptured])values('" & transSecurityType.SelectedItem.Value & "','" & currency.SelectedItem.Value & "','" & txtAmount.Text & "',getdate())", cn)
                If cn.State = ConnectionState.Open Then

                    cn.Close()
                End If
                cn.Open()
                Dim y As Integer = cmd.ExecuteNonQuery()
                If y = 1 Then
                    msgbox("Details Successufully Inserted")
                End If

                cn.Close()
                clearall()
            Else
                cmd = New SqlCommand("update  [CDSC].[dbo].[paraCharges] set  [value] = '" & txtAmount.Text & "' , [datecaptured] = getdate() where [transtype] = '" & transSecurityType.SelectedItem.Value & "' and [curreuncy] = '" & currency.SelectedItem.Value & "'", cn)
                If cn.State = ConnectionState.Open Then

                    cn.Close()
                End If
                cn.Open()
                Dim y As Integer = cmd.ExecuteNonQuery()
                If y = 1 Then
                    msgbox("Details Successufully Inserted")
                End If

                cn.Close()
                clearall()
                Exit Sub
            End If
        Else
            msgbox("Enter All Details")
                Exit Sub
            End If
        End Sub

    Private Sub transSecurityType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles transSecurityType.SelectedIndexChanged
        getcharge(transSecurityType.SelectedItem.Value)
    End Sub
End Class

