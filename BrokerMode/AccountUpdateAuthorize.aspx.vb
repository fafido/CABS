Imports System.Data
Imports System.Data.SqlClient
Partial Class BrokerMode_AccountUpdateAuthorize
    Inherits System.Web.UI.Page
    Dim constr As String = (System.Configuration.ConfigurationManager.AppSettings("connpath"))
    Dim cn As New SqlConnection(constr)
    Dim cmd As SqlCommand
    Dim adp As SqlDataAdapter
    Dim ds As New DataSet
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Page.MaintainScrollPositionOnPostBack = True
        If (Not IsPostBack) Then
        End If
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
    'Public Sub SaveUpdateRecord()
    '    Try
    '        If (txtShareholder.Text = "") Then
    '            MsgBox("Select a valid Shareholder")
    '            Exit Sub
    '        End If
    '        If (txtSurname.Text = "") Then
    '            MsgBox("Field for 'Surname' can not be left blank ")
    '            Exit Sub
    '        End If
    '        If (ChkRemoveBank.Checked = False) Then
    '            cmd = New SqlCommand("Insert into NamesUpdateAuth (UpdatingBroker,CDS_Number,Surname,Forenames,Idpp,Add_1,Add_2,Add_3,Add_4,City,Country,Telephone,Fax,Email,Bank_Code,Bank_Name,Branch_Code,Branch_Name,Account,Tax,Updated_By,Update_On) values('" & Session("BrokerCode") & "','" & txtShareholder.Text & "','" & txtSurname.Text & "','" & txtforenames.Text & "','" & txtID.Text & "','" & txtAdd1.Text & "','" & txtAdd2.Text & "','" & txtadd3.Text & "','" & txtadd4.Text & "','" & CmbCity.Text & "','" & lblCountry.Text & "','" & txtTel.Text & "','" & txtFax.Text & "','" & txtEmail.Text & "','" & lblBank.Text & "','" & cmbBank.Text & "','" & lblBranch.Text & "','" & cmbBranch.Text & "','" & txtBnkAccount.Text & "'," & cmbTax.Text & ",'" & Session("Username") & "','" & Date.Now & "')", cn)
    '            If (cn.State = ConnectionState.Open) Then
    '                cn.Close()
    '            End If
    '            cn.Open()
    '            cmd.ExecuteNonQuery()
    '            cn.Close()
    '        End If
    '        If (ChkRemoveBank.Checked = True) Then
    '            cmd = New SqlCommand("Insert into NamesUpdateAuth (UpdatingBroker,CDS_Number,Surname,Forenames,Idpp,Add_1,Add_2,Add_3,Add_4,City,Country,Telephone,Fax,Email,Bank_Code,Bank_Name,Branch_Code,Branch_Name,Account,Tax,Updated_By,Update_On) values('" & Session("BrokerCode") & "','" & txtShareholder.Text & "','" & txtSurname.Text & "','" & txtforenames.Text & "','" & txtID.Text & "','" & txtAdd1.Text & "','" & txtAdd2.Text & "','" & txtadd3.Text & "','" & txtadd4.Text & "','" & CmbCity.Text & "','" & lblCountry.Text & "','" & txtTel.Text & "','" & txtFax.Text & "','" & txtEmail.Text & "','','','','',''," & cmbTax.Text & ",'" & Session("Username") & "','" & Date.Now & "')", cn)
    '            If (cn.State = ConnectionState.Open) Then
    '                cn.Close()
    '            End If
    '            cn.Open()
    '            cmd.ExecuteNonQuery()
    '            cn.Close()
    '        End If
    '        MsgBox("Record update awaiting authorization")
    '        txtShareholder.Text = ""
    '        txtSurname.Text = ""
    '        txtforenames.Text = ""
    '        txtID.Text = ""
    '        txtAdd1.Text = ""
    '        txtAdd2.Text = ""
    '        txtadd3.Text = ""
    '        txtadd4.Text = ""
    '        txtTel.Text = ""
    '        txtFax.Text = ""
    '        txtEmail.Text = ""
    '        txtCell.Text = ""
    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '    End Try
    'End Sub

    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        Try
            If (BasicDatePicker1.Text = "") Then
                MsgBox("Select Date Range: Date From")
                Exit Sub
            End If
            If (BasicDatePicker2.Text = "") Then
                MsgBox("Select Date Range: Date To")
            End If
            Dim ds As New DataSet
            Dim dr As SqlDataReader

            cmd = New SqlCommand("Select namesUpdateAuth.CDS_Number,namesUpdateAuth.Surname as [New Name],namesUpdateAuth.Forenames as [New Forenames],namesUpdateAuth.ADD_1+' '+namesUpdateAuth.add_2+' '+namesUpdateAuth.add3+' '+namesUpdateAuth.add4+' '+namesUpdateAuth.city+' '+namesUpdateAuth.country AS [New Add],names.Surname+ ' +names.forenames as [Old Names],names.add_1+' '+names.add_2+' '+names.add_3+' '+names.add_4+' '+names.city+' '+names.country as [Old Add] from NamesUpdateAuth,names where namesUpdateAuth.Update_on between '" & BasicDatePicker1.Text & "' and DATEADD(DAY,+1,'" & BasicDatePicker2.Text & "' and UpdatingBroker='" & Session("BrokerCode") & "' and namesUpdateAuth.CDS_Number=names.CDS_Number", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "NamesUpdateAuth")
            If (ds.Tables(0).Rows.Count > 0) Then
                dr = cmd.ExecuteReader
                Dim dt As New DataTable
                dt.Load(dr)
                gvTransactions.DataSource = dt
                gvTransactions.DataBind()
                dr.Close()
                dr = Nothing
            Else
                gvTransactions.DataSource = Nothing
                gvTransactions.DataBind()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Protected Sub linkAuthorize_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim id As String = CType(sender, LinkButton).CommandArgument
        Dim sql As String = "select * from namesUpdateAuth where FKey=" & id
        Dim DividendUpdateQuery As String = ""
        Dim dr As SqlDataReader
        Try
            cmd = New SqlCommand(sql, cn)
            cn.Open()
            dr = cmd.ExecuteReader
            If (dr.Read()) Then
                cmd = New SqlCommand("update names set surname='',forenames='',idpp='',add_1='',add_2='',add_3='',add_4='',city='',country='',telephone='',fax='',email='',bank_code='',bank_name='',branch_code='',branch_name='',account='',tax='',updated_by='',updated_on='' where cds_number='' and brokercode=''", cn)
                If (cn.State = ConnectionState.Open) Then
                    cn.Close()
                End If
                'sql = dr("UpdateQuery")
                'DividendUpdateQuery = dr("DividendUpdateQuery")
            End If
            dr.Close()
            dr = Nothing
            cmd = New SqlCommand(sql, cn)
            cmd.ExecuteNonQuery()
            cmd = New SqlCommand(DividendUpdateQuery, cn)
            cmd.ExecuteNonQuery()
            sql = "update names_audit set AuditStatus=1 where FKey=" & id
            cmd = New SqlCommand(sql, cn)
            cmd.ExecuteNonQuery()
            MsgBox("Authorized successfully")
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            cn.Close()
        End Try
    End Sub
    Protected Sub linkDiscard_Click(ByVal sender As Object, ByVal e As System.EventArgs)

        Dim id As String = CType(sender, LinkButton).CommandArgument
        Dim sql As String = "delete from names_audit where FKey=" & id

        Try
            cmd = New SqlCommand(sql, cn)
            cn.Open()
            cmd.ExecuteReader()
            msgbox("declined successfully")
        Catch ex As Exception
            msgbox(ex.Message)
        Finally
            cn.Close()
        End Try


    End Sub

    Protected Sub gvTransactions_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gvTransactions.SelectedIndexChanged

    End Sub
End Class
