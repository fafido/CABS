Imports DevExpress.Web.ASPxGridView

Partial Class TransferSec_UTSetup
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
        GetIssuer()
        FillGrid()
    End Sub


    Public Sub GetIssuer()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select CDS_Number,Surname,Forenames From Accounts_Clients ", cn)
            'cmd = New SqlCommand("select a.CDS_Number+' '+ case  when a.AccountType IN ('C') THEN isnull(a.Surname,'') else isnull(Forenames,'')+' '+isnull(Surname,'') end as namess from Accounts_Clients order by a.CDS_Number", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "Accounts_Clients")
            If (ds.Tables(0).Rows.Count > 0) Then
                cmbIssuer.DataSource = ds.Tables(0)

                cmbIssuer.TextField = "Surname"
                cmbIssuer.ValueField = "CDS_Number"
                cmbIssuer.DataBind()
            Else
                cmbIssuer.DataSource = Nothing
                cmbIssuer.DataBind()
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Protected Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If btnSave.Text <> "Update" Then
            Dim status As String
            status = "Pending"
            If txtFundingName.Text = "" Then
                msgbox("Enter Funding Name")
                Exit Sub
            End If
            If txtFundingCode.Text = "" Then
                msgbox("Enter Funding Code")
                Exit Sub
            End If
            If txtDescription.Text = "" Then
                msgbox("Enter Description")
                Exit Sub
            End If
            If isnumeric(txtunits.text) = False Then
                msgbox("Please enter numeric number on units")
                Exit Sub
            End If
            Dim ds As New DataSet
            cmd = New SqlCommand("SELECT * from Unit_Trust_Funding where Funding_Code ='" & txtFundingCode.Text & "'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "Unit_Trust_Funding")
            If (ds.Tables(0).Rows.Count > 0) Then
                msgbox("Funding Already Exist")
                Exit Sub
            Else
                cn.Open()
                cmd = New SqlCommand("insert into Unit_Trust_Funding(Funding_Code,Funding_Name,description,issuer,status, Units) values('" & txtFundingCode.Text & "','" & txtFundingName.Text & "','" & txtDescription.Text & "','" & cmbIssuer.SelectedItem.Value & "','" & status & "',replace('" + txtunits.Text + "',',',''))", cn)
                If (cn.State = ConnectionState.Open) Then
                    cn.Close()
                End If
                cn.Open()
                cmd.ExecuteNonQuery()
                msgbox("You have successfully added data")
                FillGrid()
                clear()
                cn.Close()
            End If
        Else

            Dim status As String
            status = "Pending"
            If txtFundingName.Text = "" Then
                msgbox("Enter Funding Name")
                Exit Sub
            End If
            If txtFundingCode.Text = "" Then
                msgbox("Enter Funding Code")
                Exit Sub
            End If
            If txtDescription.Text = "" Then
                msgbox("Enter Description")
                Exit Sub
            End If
            If isnumeric(txtunits.text) = False Then
                msgbox("Please enter numeric number on units")
                Exit Sub
            End If

            cn.Open()
            cmd = New SqlCommand("Update Unit_Trust_Funding set Funding_Code= '" + txtFundingCode.Text + "',Funding_Name='" + txtFundingName.Text + "',description='" + txtDescription.Text + "',issuer='" + cmbIssuer.SelectedItem.Value.ToString + "',status='Pending', Units=replace('" + txtunits.Text + "',',','') where id='" + lblid.Text + "'", cn)
            If (cn.State = ConnectionState.Open) Then
                cn.Close()
            End If
            cn.Open()
            cmd.ExecuteNonQuery()
            msgbox("You have successfully updated fund!")
            FillGrid()
            clear()
            cn.Close()

        End If



    End Sub
    Public Sub clear()
        txtDescription.Text = ""
        txtFundingCode.Text = ""
        txtFundingName.Text = ""

    End Sub
    Public Sub FillGrid()
        Dim status As String
        status = "Pending"
        Dim ds As New DataSet
        cmd = New SqlCommand("SELECT * from Unit_Trust_Funding", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "Unit_Trust_Funding")
        If (ds.Tables(0).Rows.Count > 0) Then
            grdvCharges.DataSource = ds.Tables(0)
            grdvCharges.DataBind()
        Else
            'msgbox("not found")
        End If
    End Sub

    Private Sub grdvCharges_RowCommand(sender As Object, e As ASPxGridViewRowCommandEventArgs) Handles grdvCharges.RowCommand
        Dim id As String = e.KeyValue.ToString
        If e.CommandArgs.CommandName.ToString = "Edit" Then
            getdetails(id)
        End If


    End Sub
    Public Sub getdetails(id As String)
        '  Try
        Dim dsport As New DataSet
        cmd = New SqlCommand("select * from [Unit_Trust_Funding] where id='" + id + "'", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(dsport, "trans")
        If (dsport.Tables(0).Rows.Count > 0) Then
            If dsport.Tables(0).Rows(0).Item("Status").ToString = "Pending" Or dsport.Tables(0).Rows(0).Item("Status").ToString = "Rejected" Then

                txtFundingName.Text = dsport.Tables(0).Rows(0).Item("Funding_Name").ToString
                txtFundingCode.Text = dsport.Tables(0).Rows(0).Item("Funding_Code").ToString
                txtDescription.Text = dsport.Tables(0).Rows(0).Item("description").ToString
                cmbIssuer.Value = dsport.Tables(0).Rows(0).Item("Issuer").ToString
                txtunits.Text = dsport.Tables(0).Rows(0).Item("Units").ToString



                btnSave.Text = "Update"
                lblid.Text = dsport.Tables(0).Rows(0).Item("id").ToString

            Else

                msgbox("You cannot edit a fund that is not in pending state")
                Exit Sub
            End If

        End If
    End Sub

End Class
