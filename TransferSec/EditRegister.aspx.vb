
Partial Class TransferSec_EditRegister
    Inherits System.Web.UI.Page

    Dim constr As String = (System.Configuration.ConfigurationManager.AppSettings("connpath"))
    Dim cn As New SqlConnection(constr)
    Dim adp As SqlDataAdapter
    Dim cmd As SqlCommand

    Protected Sub ASPxButton2_Click(sender As Object, e As EventArgs) Handles ASPxButton2.Click
        Try
            Session("cusAdd") = ""
            If Session("usertype") = "CDSAdmin" Or Session("usertype") = "CDSUser" Then
                Dim ds As New DataSet
                cmd = New SqlCommand("SELECT Id, [IdNumber]+' '+[Surname]+' '+[Forenames] as namess  FROM [CDS].[dbo].[CertNames] where Surname+' '+Forenames like '%" & txtClientName.Text & "%'", cn)
                adp = New SqlDataAdapter(cmd)
                adp.Fill(ds, "Accounts_Clients")
                If (ds.Tables(0).Rows.Count > 0) Then
                    lstNames.DataSource = ds.Tables(0)
                    lstNames.TextField = "namess"
                    lstNames.ValueField = "Id"
                    ' Session("idAx") = ds.Tables(0).Rows(0).Item("Id").ToString.Trim().ToUpper
                    lstNames.DataBind()
                End If
            Else
                Dim ds As New DataSet
                cmd = New SqlCommand("SELECT Id, [IdNumber]+' '+[Surname]+' '+[Forenames] as namess  FROM [CDS].[dbo].[CertNames] where Surname+' '+Forenames like '%" & txtClientName.Text & "%'", cn)
                adp = New SqlDataAdapter(cmd)
                adp.Fill(ds, "Accounts_Clients")
                If (ds.Tables(0).Rows.Count > 0) Then
                    lstNames.DataSource = ds.Tables(0)
                    lstNames.TextField = "namess"
                    lstNames.ValueField = "Id"
                    lstNames.DataBind()
                End If
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Protected Sub lstNames_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstNames.SelectedIndexChanged
        getportfolio()
    End Sub

    Public Sub getportfolio()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select * from CertNames where [IdNumber]+' '+[Surname]+' '+[Forenames] = '" & lstNames.SelectedItem.Text & "'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "Accounts_Clients")
            If (ds.Tables(0).Rows.Count > 0) Then
                ASPxTextBox1.Text = ds.Tables(0).Rows(0).Item("surname").ToString.ToUpper + " " + ds.Tables(0).Rows(0).Item("forenames").ToString.ToUpper
                ASPxTextBox2.Text = ds.Tables(0).Rows(0).Item("IdNumber").ToString.Trim().ToUpper
                Session("idAx") = ds.Tables(0).Rows(0).Item("Id").ToString.Trim().ToUpper

                '  msgbox(ds.Tables(0).Rows(0).Item("Id").ToString.Trim().ToUpper)
                'Session("cusAdd") = ds.Tables(0).Rows(0).Item("Custodian").ToString.ToUpper
                'Session("idAdd") = ds.Tables(0).Rows(0).Item("IDNoPP").ToString.ToUpper

                '   msgbox(Session("idAdd").ToString)
                '    txtSurnames.Text = ds.Tables(0).Rows(0).Item("surname").ToString.ToUpper
                '    rdBonds.Checked = True


            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Protected Sub btnView0_Click(sender As Object, e As EventArgs) Handles btnView0.Click

        Dim cmnd As SqlCommand
        cmnd = New SqlCommand("Update [CDS].[dbo].[CertNames] SET [IdNumber] = '" & ASPxTextBox2.Text & "' Where Id='" & Session("idAx") & "'", cn)
        If (cn.State = ConnectionState.Open) Then
            cn.Close()
        End If
        Try
            cn.Open()
            cmnd.ExecuteNonQuery()
            msgbox("Update successfully")
            ASPxTextBox1.Text = ""
            ASPxTextBox2.Text = ""
        Catch ex As Exception
            msgbox("Something went wrong, Please try again")
        End Try
    End Sub

    Public Sub msgbox(ByVal strMessage As String)

        'finishes server processing, returns to client.
        Dim strScript As String = "<script language=JavaScript>"
        strScript += "window.alert(""" & strMessage & """);"
        strScript += "</script>"
        Dim lbl As New System.Web.UI.WebControls.Label
        lbl.Text = strScript
        Page.Controls.Add(lbl)

    End Sub
End Class
