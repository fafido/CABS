Imports System.Collections.Generic
Imports DevExpress.Web.ASPxEditors
Imports DevExpress.Web.ASPxGridView

Partial Class transferapproval2
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
                'getclasses_param()
                getpending()
            End If
            If Session("finish") = "yes" Then
                Session("finish") = ""
                msgbox("Successful")
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub ASPxTextBox12_TextChanged(sender As Object, e As EventArgs) Handles txttransferorname.TextChanged

    End Sub



    Public Sub getpending()

        Dim ds As New DataSet
        cmd = New SqlCommand("select s.*, a1.Surname+' '+a1.Forenames as [FromName],a2.Surname+' '+a2.Forenames as [ToName] from share_transfer s, Accounts_Clients a1, Accounts_Clients a2 where s.transferor=a1.CDS_Number and a2.CDS_Number=s.transferee and s.[Status]='PENDING'", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "Accounts_Audit2")
        If (ds.Tables(0).Rows.Count > 0) Then
            grddocuments.DataSource = ds

            grddocuments.DataBind()

        End If
    End Sub


    Public Sub loadnames()
        Dim ds As New DataSet
        '  cmd = New SqlCommand("select * from share_transfer where id='" + cmbpending.SelectedItem.Value.ToString + "'", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "Accounts_Audit2")
        If (ds.Tables(0).Rows.Count > 0) Then
            txttransferorid.Text = ds.Tables(0).Rows(0).Item("transferor")
            txttransfereeid.Text = ds.Tables(0).Rows(0).Item("transferee")
            txtshares.Text = ds.Tables(0).Rows(0).Item("amount_to_transfer")
            txtcomp.Text = ds.Tables(0).Rows(0).Item("company")
            '       getclasses()


        End If
    End Sub

    Public Sub getnames()
        Dim ds1 As New DataSet
        cmd = New SqlCommand("  select (select ISNULL(surname,'')+' '+isnull(middlename,'')+' '+ isnull(forenames,'') from accounts_clients where cds_number='" + txttransferorid.Text + "') as Transferor, (select isnull(surname,'')+' '+isnull(middlename,'')+' '+ isnull(forenames,'') from accounts_clients where cds_number='" + txttransfereeid.Text + "') as transferee  from accounts_clients ", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds1, "Accounts_Audit2")
        If (ds1.Tables(0).Rows.Count > 0) Then
            txttransferorname.Text = ds1.Tables(0).Rows(0).Item("Transferor")
            txttransfereename.Text = ds1.Tables(0).Rows(0).Item("Transferee")

        End If
    End Sub
    Public Sub savenewclass()
        Dim ds1 As New DataSet
        cmd = New SqlCommand("select cds_number from account_transfer where cds_number='" + txttransferorid.Text + "'", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds1, "Accounts_Audit3")
        If (ds1.Tables(0).Rows.Count > 0) Then
            cmd = New SqlCommand("Update account_transfer set to_broker=(select company_code  from client_companies where company_name='" + +"') where cds_number='" + txttransferorid.Text + "'", cn)
            If (cn.State = ConnectionState.Open) Then
                cn.Close()
            End If
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()

            Session("finish") = "yes"
            Response.Redirect(Request.RawUrl)
        Else
            '   cmd = New SqlCommand("insert into account_transfer values ('" + txtclientid.Text + "','" + Session("brokercode") + "',(select company_code  from client_companies where company_name='" + +"'), '" + txtComments.Text + "',GEtdate(),0)", cn)
            If (cn.State = ConnectionState.Open) Then
                cn.Close()
            End If
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()

            Session("finish") = "yes"
            Response.Redirect(Request.RawUrl)
        End If
    End Sub

    Protected Sub ASPxButton5_Click(sender As Object, e As EventArgs) Handles ASPxButton5.Click
        Dim keys As List(Of Object) = grddocuments.GetCurrentPageRowValues(New String() {"id"})
        For Each key As Object In keys
            Dim chk As ASPxCheckBox = TryCast(grddocuments.FindRowCellTemplateControlByKey(key, TryCast(grddocuments.Columns("Selec"), GridViewDataColumn), "chk1"), ASPxCheckBox)

            Dim check As Boolean = chk.Checked
            If check = True Then
                approvetransaction(key.ToString)

            End If
        Next
        getpending()
        msgbox("Transaction(s) Approved")

    End Sub
    Public Sub approvetransaction(transkey As String)
        Try

            cmd = New SqlCommand("insert into trans (company, cds_number , Date_Created, Trans_Time, shares, Update_Type, Created_By, Batch_Ref, source, Pledge_shares, reference, Instrument, Custodian) select company, transferor  , [date], getdate(), amount_to_transfer*-1 , 'Trustee Re-Allocation', '" + Session("Username") + "', id , 'D', '0', id, 'Unit Trust', 'CABS' from share_transfer WHERE id='" + transkey + "'      insert into trans (company, cds_number , Date_Created, Trans_Time, shares, Update_Type, Created_By, Batch_Ref, source, Pledge_shares, reference, Instrument, Custodian) select company, transferee  , [date], getdate(), amount_to_transfer , 'Trustee Re-Allocation', '" + Session("Username") + "', id , 'D', '0', id, 'Unit Trust', 'CABS' from share_transfer WHERE id='" + transkey + "'    Update share_transfer set status='APPROVED' where id='" + transkey + "'", cn)
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
    Public Sub DECLINE(transkey As String)
        Try

            cmd = New SqlCommand(" Update share_transfer set status='REJECTED' where id='" + transkey + "'", cn)
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

    Private Sub grddocuments_RowCommand(sender As Object, e As ASPxGridViewRowCommandEventArgs) Handles grddocuments.RowCommand
        Dim id As String = e.KeyValue.ToString
        If e.CommandArgs.CommandName.ToString = "Approve Transaction" Then
            approvetransaction(id)
            getpending()
            msgbox("Transaction Successfully Approved")
        ElseIf e.CommandArgs.CommandName.ToString = "Decline Transaction" Then
            DECLINE(id)
            getpending()
            msgbox("Transaction Declined")
        End If
    End Sub
    Protected Sub ASPxButton6_Click(sender As Object, e As EventArgs) Handles ASPxButton6.Click
        Dim keys As List(Of Object) = grddocuments.GetCurrentPageRowValues(New String() {"id"})
        For Each key As Object In keys
            Dim chk As ASPxCheckBox = TryCast(grddocuments.FindRowCellTemplateControlByKey(key, TryCast(grddocuments.Columns("Selec"), GridViewDataColumn), "chk1"), ASPxCheckBox)

            Dim check As Boolean = chk.Checked
            If check = True Then
                DECLINE(key.ToString)

            End If
        Next
        getpending()
        msgbox("Transaction(s) Rejected")

    End Sub
End Class