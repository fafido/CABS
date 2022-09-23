Imports System.Data
Imports System.Data.SqlClient
Partial Class TSecTrading_AllotmentBatch
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
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Page.MaintainScrollPositionOnPostBack = True
        If (Not IsPostBack) Then
            getBatchRef()
            getbatchdetails()
        End If
    End Sub
    Public Sub getBatchRef()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select distinct (batch_ref) from TsEC_Batch_Header where status='V'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "Tsec_Batch_Header")
            If (ds.Tables(0).Rows.Count > 0) Then
                CmbBatchNumber.DataSource = ds.Tables(0)
                CmbBatchNumber.DataValueField = "batch_ref"
                CmbBatchNumber.DataBind()
            Else
                CmbBatchNumber.DataSource = Nothing
                CmbBatchNumber.DataBind()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Public Sub getbatchdetails()
        Try
            Dim ds As New DataSet
            If (txtBatchSearch.Text = "") Then
                lblBatchSearch.Text = CmbBatchNumber.Text
            Else
                lblBatchSearch.Text = txtBatchSearch.Text
            End If
            cmd = New SqlCommand("Select * from TSec_Batch_Header where batch_ref = " & lblBatchSearch.Text & " and  status = 'V'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "Tsec_Batch_Header")
            lblCompany.Text = ds.Tables(0).Rows(0).Item("company").ToString
            lblBatchshares.Text = ds.Tables(0).Rows(0).Item("Batch_Total").ToString
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Protected Sub btnBatchSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBatchSearch.Click
        Try
            If (txtBatchSearch.Text = "") Then
                MsgBox("Enter a valid batch reference number")
                Exit Sub
            End If
            Dim ds As New DataSet
            cmd = New SqlCommand("Select * from Tsec_Batch_Header where batch_ref=" & txtBatchSearch.Text & "", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "Tsec_batch_header")
            If (ds.Tables(0).Rows.Count > 0) Then
                getbatchdetails()
            Else
                MsgBox("Invalid batch Ref")
                Exit Sub
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Protected Sub CmbBatchNumber_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbBatchNumber.SelectedIndexChanged
        Try
            txtBatchSearch.Text = ""
            getbatchdetails()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Protected Sub btnHolderNumto_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnHolderNumto.Click
        Try
            If (txtToHolderNum.Text = "") Then
                MsgBox("Enter a valid holder number")
                Exit Sub
            End If
            Dim ds As New DataSet
            cmd = New SqlCommand("Select * from names where cds_number = '" & txtToHolderNum.Text & "'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "names")
            If (ds.Tables(0).Rows.Count > 0) Then
                lblNameTo.Text = (ds.Tables(0).Rows(0).Item("Surname").ToString + "" + ds.Tables(0).Rows(0).Item("forenames").ToString)
                lblNumberto.Text = (ds.Tables(0).Rows(0).Item("cds_number").ToString)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Protected Sub btnHolderNameto_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnHolderNameto.Click
        Try
            If (txtHolderNameTo.Text = "") Then
                MsgBox("Enter a valid search name")
                Exit Sub
            End If
            Dim ds As New DataSet
            cmd = New SqlCommand("select distinct surname+' '+forenames+' '+cds_number as namess from names where surname like '" & txtHolderNameTo.Text & "%'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "names")
            If (ds.Tables(0).Rows.Count > 0) Then
                lstNameTo.DataSource = ds.Tables(0)
                lstNameTo.DataValueField = "namess"
                lstNameTo.DataBind()
            Else
                lstNameTo.DataSource = Nothing
                lstNameTo.DataValueField = ""
                lstNameTo.DataBind()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Protected Sub btnSelectTo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSelectTo.Click
        Try
            If (lstNameTo.SelectedIndex < 0) Then
                MsgBox("Select a name")
                Exit Sub
            End If
            Dim ds As New DataSet
            cmd = New SqlCommand("Select cds_number,surname,forenames from names where surname+' '+forenames+' '+cds_number = '" & lstNameTo.SelectedItem.Text & "'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "names")
            lblNameTo.Text = ds.Tables(0).Rows(0).Item("surname").ToString + " " + ds.Tables(0).Rows(0).Item("forenames").ToString
            lblNumberto.Text = ds.Tables(0).Rows(0).Item("cds_number").ToString
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Protected Sub btnAddto_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAddto.Click
        Try
            If (txtSharestrans.Text = "") Then
                MsgBox("Enter a valid number of shares")
                Exit Sub
            End If
            cmd = New SqlCommand("Insert into TempAllotments (company,batch_ref,cds_number,shares,TranType,date_of_capture,CapturedBy,Audit) values ('" & lblCompany.Text & "'," & lblBatchSearch.Text & ",'" & lblNumberto.Text & "'," & txtSharestrans.Text & ",'ALLOT','" & Date.Now & "','C','" & Session("UserName") & "',0)", cn)
            If (cn.State = ConnectionState.Open) Then
                cn.Close()
            End If
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()
            getCaptured2()
            txtSharestrans.Text = ""
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Public Sub getCaptured2()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select cds_number as [Holder Number], shares as [Shares], batch_ref as [Batch Ref],date_of_capture as [Captured Date] from TempAllotments where company='" & lblCompany.Text & "' and batch_ref=" & lblBatchSearch.Text & "", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "TempAllotments")
            If (ds.Tables(0).Rows.Count > 0) Then
                gdAddedHoldersto.DataSource = ds.Tables(0)
                gdAddedHoldersto.DataBind()
            Else
                gdAddedHoldersto.DataSource = Nothing
                gdAddedHoldersto.DataBind()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Protected Sub BtnSaveTrans_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnSaveTrans.Click
        Try
            Dim ds, ds1, ds2 As New DataSet
            cmd = New SqlCommand("select sum(shares) as shares from TempAllotments where company='" & lblCompany.Text & "' and batch_ref = " & lblBatchSearch.Text & "", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "TempAllotments")
            If (CInt(ds.Tables(0).Rows(0).Item("shares").ToString) <> CInt(lblBatchshares.Text)) Then
                MsgBox("Cannot save an unbalanced batch")
                Exit Sub
            End If
            If (CInt(ds.Tables(0).Rows(0).Item("shares").ToString) = CInt(lblBatchshares.Text)) Then
                cmd = New SqlCommand("select * from TempAllotments where company='" & lblCompany.Text & "' and batch_ref = " & lblBatchSearch.Text & " and status='C'", cn)
                adp = New SqlDataAdapter(cmd)
                adp.Fill(ds1, "TempTransFrom")
                If (ds1.Tables(0).Rows.Count > 0) Then
                    Dim i As Integer
                    For i = 0 To ds1.Tables(0).Rows.Count - 1
                        cmd = New SqlCommand("insert into TransAudit (company,batch_ref,shares,cds_number,date_of_capture,transBroker,Capturedby,Audit) values ('" & ds1.Tables(0).Rows(i).Item("company").ToString & "'," & ds1.Tables(0).Rows(i).Item("batch_ref").ToString & "," & CInt(ds1.Tables(0).Rows(i).Item("shares").ToString * -1) & ",'" & ds1.Tables(0).Rows(i).Item("cds_number").ToString & "','" & ds1.Tables(0).Rows(i).Item("date_of_capture").ToString & "','" & Session("BrokerCode") & "','" & Session("UserName") & "',1)", cn)
                        If (cn.State = ConnectionState.Open) Then
                            cn.Close()
                        End If
                        cn.Open()
                        cmd.ExecuteNonQuery()
                        cn.Close()
                    Next
                End If

                cmd = New SqlCommand("select * from TempAllotments where company='" & lblCompany.Text & "' and batch_ref=" & lblBatchSearch.Text & " and status = 'C'", cn)
                adp = New SqlDataAdapter(cmd)
                adp.Fill(ds2, "TempAllotments")
                If (ds2.Tables(0).Rows.Count > 0) Then
                    Dim i As Integer
                    For i = 0 To ds2.Tables(0).Rows.Count - 1
                        cmd = New SqlCommand("insert into TransAudit (company,batch_ref,shares,cds_number,date_of_capture,transBroker,Capturedby,Audit) values ('" & ds2.Tables(0).Rows(i).Item("company").ToString & "'," & ds2.Tables(0).Rows(i).Item("batch_ref").ToString & "," & ds2.Tables(0).Rows(i).Item("shares").ToString & ",'" & ds2.Tables(0).Rows(i).Item("cds_number").ToString & "','" & ds2.Tables(0).Rows(i).Item("date_of_capture").ToString & "','" & Session("BrokerCode") & "','" & Session("UserName") & "',1)", cn)
                        If (cn.State = ConnectionState.Open) Then
                            cn.Close()
                        End If
                        cn.Open()
                        cmd.ExecuteNonQuery()
                        cn.Close()
                    Next
                End If

                cmd = New SqlCommand("Update TempAllotments set status='B' where company='" & lblCompany.Text & "' and batch_ref=" & lblBatchSearch.Text & "", cn)
                If (cn.State = ConnectionState.Open) Then
                    cn.Close()
                End If
                cn.Open()
                cmd.ExecuteNonQuery()
                cn.Close()
                MsgBox("Record Saved")
                getBatchRef()
                getbatchdetails()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Class