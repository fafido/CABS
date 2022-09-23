Imports System.Data
Imports System.Data.SqlClient
Imports DevExpress.Web.ASPxGridView

Partial Class BrokerMode_LendingandBorrowingPara
    Inherits System.Web.UI.Page
    Dim constr As String = (System.Configuration.ConfigurationManager.AppSettings("connpath"))
    Dim cn As New SqlConnection(constr)
    Dim cmd As SqlCommand
    Dim adp As SqlDataAdapter
    Dim ds As New DataSet
    Dim maxholder As Integer = 0
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
        Page.MaintainScrollPositionOnPostBack = True
        If (Not IsPostBack) Then
            If (Session("Username") = Nothing) Then
                Response.Redirect("~\loginsystem.aspx")
                Exit Sub
            End If
            'Label4.Text = "Logged on as " & Session("UserName").ToString & " of " & Session("UserCompany")

            GetRules()
            GetSecurities()
        Else

            GetRules()
        End If
        If Session("finish") = "yes" Then
            Session("finish") = ""
            msgbox("Lending Rules Successfully Captured")
        End If
        If Session("finish") = "update" Then
            Session("finish") = ""
            msgbox("Lending Rules Successfully Updated")
        End If
        If Session("finish") = "update" Then
            Session("finish") = ""
            msgbox("Lending Rules Successfully Removed")
        End If
    End Sub
    Public Sub GetSecurities()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select distinct (SecCode) from sec_types", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "security_type")
            If (ds.Tables(0).Rows.Count > 0) Then
                cmbSecurities.DataSource = ds.Tables(0)
                cmbSecurities.TextField = "secCode"
                cmbSecurities.ValueField = "SecCode"
                cmbSecurities.DataBind()
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            SaveRules()

        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub SaveRules()
        Try
            If btnSave.Text = "Save" Then

                'Dim stmnt As String = "insert into para_lendingRules (Security,InterestRate,ServiceCharges,LendingPeriod,MiniAmount,MaxiAmount,DateCreated) values (''" & cmbSecurities.SelectedItem.Text & "''," & txtInterestRate.Text & "," & txtServiceRate.Text & "," & txtLendingPeriod.Text & "," & txtMinimumAmount.Text & "," & txtMaxAmount.Text & ",''" & Now.Date & "'')"
                'Dim descr As String = "Added new Lending and Borrowing Rule for Security Type: " + cmbSecurities.SelectedItem.Text + ". Interest Rate: " + txtInterestRate.Text + "%. Service Charge:" + txtServiceRate.Text + "% . Lending Period=" + txtLendingPeriod.Text + ""
                ' cmd = New SqlCommand(" insert into tbl_uncommitted ([description], script, [status], sender, date_inserted, comment, email_body, email_subject, email_to, category) values ('" + descr + "' , '" + stmnt + "', '0','" + Session("Username") + "', getdate(), '','','', '','New Lending and Borrowing Rule')", cn)
                If txtoption.Text = "" Then
                    msgbox("Please enter option name")
                    Exit Sub

                End If
                If txtInterestRate.Text = "" Then
                    msgbox("Please enter Interest Rate")
                    Exit Sub
                End If
                If txtLendingPeriod.Text = "" Then
                    msgbox("Please enter Lending Period")
                    Exit Sub
                End If
                If txtMaxAmount.Text = "" Then
                    msgbox("Please enter Maximum Amount")
                    Exit Sub
                End If
                If txtMinimumAmount.Text = "" Then
                    msgbox("Please enter Minimum Amount")
                    Exit Sub
                End If
                If txtServiceRate.Text = "" Then
                    msgbox("Please enter Service Amount")
                    Exit Sub
                End If
                If optionexists(txtoption.Text) = True Then
                    msgbox("Option name already exists")
                    Exit Sub
                End If


                cmd = New SqlCommand("insert into para_lendingRules (Security,InterestRate,ServiceCharges,LendingPeriod,MiniAmount,MaxiAmount,DateCreated, Bank, Set_By, haircut, Interest_Interval,OptionName ) values ('Money'," & txtInterestRate.Text & "," & txtServiceRate.Text & "," & txtLendingPeriod.Text & "," & txtMinimumAmount.Text & "," & txtMaxAmount.Text & ",getdate(),'" + Session("BrokerCode") + "','" + Session("Username") + "','" + txthaircut.Text + "','" + RadioButtonList1.SelectedItem.Text + "','" + txtoption.Text + "')", cn)
                If (cn.State = ConnectionState.Open) Then
                    cn.Close()
                End If
                cn.Open()
                cmd.ExecuteNonQuery()
                cn.Close()

                Try
                    Dim a As New passmanagement
                    a.auditlog(Session("BrokerCode"), Session("Username"), "Added a new Bank Option", "", txtoption.Text)
                Catch ex As Exception

                End Try

                txtInterestRate.Text = ""
                txtLendingPeriod.Text = ""
                txtMaxAmount.Text = ""
                txtMinimumAmount.Text = ""
                txtServiceRate.Text = ""
                Session("finish") = "yes"
                Response.Redirect(Request.RawUrl)

            Else
                If txtoption.Text = "" Then
                    msgbox("Please enter option name")
                    Exit Sub

                End If
                If txtInterestRate.Text = "" Then
                    msgbox("Please enter Interest Rate")
                    Exit Sub
                End If
                If txtLendingPeriod.Text = "" Then
                    msgbox("Please enter Lending Period")
                    Exit Sub
                End If
                If txtMaxAmount.Text = "" Then
                    msgbox("Please enter Maximum Amount")
                    Exit Sub
                End If
                If txtMinimumAmount.Text = "" Then
                    msgbox("Please enter Minimum Amount")
                    Exit Sub
                End If
                If txtServiceRate.Text = "" Then
                    msgbox("Please enter Service Amount")
                    Exit Sub
                End If
                'If optionexists(txtoption.Text) = True Then
                '    msgbox("Option name already exists")
                '    Exit Sub
                'End If


                cmd = New SqlCommand("update para_lendingRules set InterestRate='" + txtInterestRate.Text + "',ServiceCharges='" + txtServiceRate.Text + "',LendingPeriod='" + txtLendingPeriod.Text + "',MiniAmount='" + txtMinimumAmount.Text + "',MaxiAmount='" + txtMaxAmount.Text + "', Set_By='" + Session("Username") + "', haircut='" + txthaircut.Text + "', Interest_Interval='" + RadioButtonList1.SelectedItem.Text + "',OptionName='" + txtoption.Text + "' where id='" + lblid.text + "'", cn)
                If (cn.State = ConnectionState.Open) Then
                    cn.Close()
                End If
                cn.Open()
                cmd.ExecuteNonQuery()
                cn.Close()
                Try
                    Dim a As New passmanagement
                    a.auditlog(Session("BrokerCode"), Session("Username"), "Edited a Bank Option", "", txtoption.Text)
                Catch ex As Exception

                End Try

                txtInterestRate.Text = ""
                txtLendingPeriod.Text = ""
                txtMaxAmount.Text = ""
                txtMinimumAmount.Text = ""
                txtServiceRate.Text = ""
                Session("finish") = "update"
                Response.Redirect(Request.RawUrl)

            End If


        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Function optionexists(optionname As String) As Boolean
        Dim ds As New DataSet
        cmd = New SqlCommand("  Select * from Para_lendingRules where bank='" + Session("BrokerCode") + "' and optionname='" + optionname + "'  order by id desc", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "para_lendingRules")
        If (ds.Tables(0).Rows.Count > 0) Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Sub GetRules()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("SELECT  [id]      ,[Security]      ,format([InterestRate],'#,0.00') as InterestRate      ,format([ServiceCharges],'#,0.00')   as [ServiceCharges]   ,[LendingPeriod]      ,format([MiniAmount],'#,0.00') as [MiniAmount]      ,format([MaxiAmount],'#,0.00')  as [MaxiAmount]    ,[DateCreated]      ,[Bank]      ,[Set_By]      ,format([Haircut],'#,0.00') AS [Haircut]      ,[Interest_Interval]      ,[OptionName]  FROM [Para_lendingRules] where bank='" + Session("BrokerCode") + "'  order by id desc", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "para_lendingRules")
            If (ds.Tables(0).Rows.Count > 0) Then
                grdrules.DataSource = ds.Tables(0)
                grdrules.DataBind()
            Else
                grdrules.DataSource = Nothing
                grdrules.DataBind()
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub deleteall(id As String)
        cmd = New SqlCommand("delete from  para_lendingRules where id='" + id + "'", cn)
        If (cn.State = ConnectionState.Open) Then
            cn.Close()
        End If
        cn.Open()
        cmd.ExecuteNonQuery()
        cn.Close()
        txtInterestRate.Text = ""
        txtLendingPeriod.Text = ""
        txtMaxAmount.Text = ""
        txtMinimumAmount.Text = ""
        txtServiceRate.Text = ""
        Try
            Dim a As New passmanagement
            a.auditlog(Session("BrokerCode"), Session("Username"), "Deleted a Bank Option", "", "")
        Catch ex As Exception

        End Try

        Session("finish") = "delete"
        Response.Redirect(Request.RawUrl)
    End Sub

    Private Sub grdrules_RowCommand(sender As Object, e As ASPxGridViewRowCommandEventArgs) Handles grdrules.RowCommand
        Dim id As String = e.KeyValue.ToString

        If e.CommandArgs.CommandName.ToString = "Edit" Then
            details(id)
        End If
        If e.CommandArgs.CommandName.ToString = "Delete" Then
            deleteall(id.ToString)
        End If
    End Sub
    Public Sub details(id As String)
        Dim ds As New DataSet
        cmd = New SqlCommand("Select * from Para_lendingRules where id='" + id + "'", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "para_lendingRules")
        If (ds.Tables(0).Rows.Count > 0) Then
            txtoption.Text = ds.Tables(0).Rows(0).Item("OptionName").ToString
            txtServiceRate.Text = ds.Tables(0).Rows(0).Item("ServiceCharges").ToString
            txtMinimumAmount.Text = ds.Tables(0).Rows(0).Item("MiniAmount").ToString
            txtMaxAmount.Text = ds.Tables(0).Rows(0).Item("MaxiAmount").ToString
            txthaircut.Text = ds.Tables(0).Rows(0).Item("Haircut").ToString
            txtInterestRate.Text = ds.Tables(0).Rows(0).Item("InterestRate").ToString
            txtLendingPeriod.Text = ds.Tables(0).Rows(0).Item("LendingPeriod").ToString
            lblid.Text = id
            If ds.Tables(0).Rows(0).Item("Interest_Interval").ToString = "Monthly" Then
                RadioButtonList1.SelectedIndex = 0
            Else
                RadioButtonList1.SelectedIndex = 1
            End If
            btnSave.Text = "Update"
            End If

    End Sub
    Protected Sub btnSave0_Click(sender As Object, e As EventArgs) Handles btnSave0.Click
        Response.Redirect(Request.RawUrl)
    End Sub
End Class
