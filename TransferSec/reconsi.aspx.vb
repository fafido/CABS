Imports System.Data
Imports System.Data.SqlClient
Imports System.IO

Partial Class Orders
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
        'loadModules()

        Page.MaintainScrollPositionOnPostBack = True
        If (Not IsPostBack) Then
            'getcompanies()
            ' Getorders()
            'loadModules()
        End If
        If Session("finish") = "yes" Then
            Session("finish") = ""
            msgbox("Sent for Approval")
        End If
    End Sub


    'Public Sub getcompanies()
    '    Dim ds As New DataSet
    '    cmd = New SqlCommand("select * from para_company", cn)
    '    adp = New SqlDataAdapter(cmd)
    '    adp.Fill(ds, "para_lendingRules")
    '    If (ds.Tables(0).Rows.Count > 0) Then
    '        ASPxComboBox1.DataSource = ds
    '        ASPxComboBox1.TextField = "fnam"
    '        ASPxComboBox1.ValueField = "company"
    '        ASPxComboBox1.DataBind()
    '    End If
    'End Sub

    'Public Sub Getorders()
    '    Try
    '        Dim ds As New DataSet
    '        cmd = New SqlCommand("select fund,Client_Account ,Client_Name , Total_Units ,TransType from UnitAccounts ", cn)
    '        adp = New SqlDataAdapter(cmd)
    '        adp.Fill(ds, "para_lendingRules")
    '        If (ds.Tables(0).Rows.Count > 0) Then
    '            grdRules.DataSource = ds.Tables(0)
    '            grdRules.DataBind()
    '        Else
    '            grdRules.DataSource = Nothing
    '            grdRules.DataBind()
    '        End If
    '    Catch ex As Exception
    '        msgbox(ex.Message)
    '    End Try
    'End Sub















    Protected Sub btnupload_Click(sender As Object, e As EventArgs)
        
        If fileupload1.HasFile Then
            Dim connectionString As String = ""
            Dim fileName2 As String = Path.GetFileName(fileupload1.PostedFile.FileName)


            Dim fileLocation As String = Server.MapPath("~/uploads/recon_" & Date.Now.ToString("ddMMyyyymmsss") & fileName2)
            fileupload1.SaveAs(fileLocation)
            Dim fileExtension As String = Path.GetExtension(fileupload1.PostedFile.FileName)
            If fileExtension = ".xls" Then
                connectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & fileLocation & ";Extended Properties=""Excel 8.0;HDR=No;IMEX=1"""
            ElseIf fileExtension = ".xlsx" Then
                connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & fileLocation & ";Extended Properties=""Excel 12.0;HDR=No;IMEX=1"""
            Else
                msgbox("File Type Invalid")
                Exit Sub
            End If
            'Create OleDB Connection and OleDb Command

            Dim conn As New OleDbConnection(connectionString)
            Dim cmd As New OleDbCommand()

            cmd.CommandType = System.Data.CommandType.Text
            cmd.Connection = conn

            Dim dAdapter As New OleDbDataAdapter(cmd)

            Dim dtExcelRecords As New DataTable()

            conn.Open()

            Dim dtExcelSheetName As DataTable = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, Nothing)
            Dim getExcelSheetName As String = dtExcelSheetName.Rows(0)("Table_Name").ToString()
            cmd.CommandText = "Select * FROM [" & getExcelSheetName & "]"
            dAdapter.SelectCommand = cmd
            dAdapter.Fill(dtExcelRecords)





            Dim x As Integer = 0
            For x = 1 To dtExcelRecords.Rows.Count - 1                                                                                                                                                                                      '                                                                                                                                                                                                                                                                                                                               ImportID,Company,Date_trade,CDS_Ref,Date_Settlement,Client_Id,Other_Names,Surname,Buy_Sell,Quantity,Price,UploadDate)
                '                                                                                                                                                                                                                  ImportID,                      Date_trade,                                         CDS_Ref,                                             Date_Settlement,                                        Client_Id,                             Surname,                                        Buy_Sell,                                        Quantity,                                   Price,                                              UploadDate
                Dim dr = dtExcelRecords.Rows(x)

                Dim cmd2 As New SqlCommand
                Dim cmdStr As String = "insert into trans ([Company], [CDS_Number], [Date_Created],shares)"
                cmdStr = cmdStr & "values(@company, @cdsnumber,@datecreated,@shares)"
                cmd2 = New SqlCommand(cmdStr, cn)
                cmd2.Parameters.AddWithValue("@company", dr.Item(0).ToString)
                cmd2.Parameters.AddWithValue("@cdsnumber", dr.Item(1).ToString)
                cmd2.Parameters.AddWithValue("@datecreated", dr.Item(2).ToString)

                cmd2.Parameters.AddWithValue("@shares", dr.Item(4).ToString)


                'cmd2.Parameters.AddWithValue("@custodian", dr.Item(13).ToString)


                cn.Open()
                cmd2.ExecuteNonQuery()
                cn.Close()

            Next
            conn.Close()
            'Return True
        Else
            'Return False
        End If
        msgbox("upload successful")
        'inserttoTrans()
        'cleartable()

        ' Getorders()

    End Sub

    Public Sub cleartable()
        cmd = New SqlCommand("truncate table unitAccounts  ", cn)
        If (cn.State = ConnectionState.Open) Then
            cn.Close()
        End If
        cn.Open()
        cmd.ExecuteNonQuery()
        cn.Close()
    End Sub
    'Public Sub inserttoTrans()
    '    cmd = New SqlCommand("insert into [CDS_ROUTER].[dbo].[trans](Company, CDS_Number, Update_Type, Shares, Date_Created, Trans_Time, Created_By, source) (Select  u.fund,u.client_Account,'crediting' , CASE TRANSTYPE  WHEN  'Purchase'   THEN convert(numeric (18,10) ,replace(total_units,',','')) ELSE  convert(numeric (18,10) ,replace(total_units,',','')) * -1 END AS totalunits ,getdate(),getdate(),'Escrow' ,'unittrusts' from unitAccounts u  where u.client_Account in (select CDS_Number from  [CDS_ROUTER].[dbo].[Accounts_Clients_Web])) ", cn)
    '    If (cn.State = ConnectionState.Open) Then
    '        cn.Close()
    '    End If
    '    cn.Open()
    '    cmd.ExecuteNonQuery()
    '    cn.Close()
    'End Sub
    Dim sCommand As SqlCommand
    Dim sAdapter As SqlDataAdapter
    Dim sBuilder As SqlCommandBuilder
    Dim sDs As DataSet
    Dim sTable As DataTable




    Protected Sub GridView2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ASPxGridView2.SelectionChanged

    End Sub
    Protected Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        loadModules()
    End Sub
    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        loadModules3()
    End Sub
    Public Sub loadModules()
        Try
            cmd = New SqlCommand("SELECT Company,cds_number as Clientnumber,date_created as [Date],Shares FROM [CDS_Router].[dbo].[trans] WHERE CDS_Number NOT IN (SELECT CDS_Number FROM trans)", cn)
            adp = New SqlDataAdapter(cmd)
            Dim ds1 As New DataSet
            ds1.Clear()
            adp.Fill(ds1, "company")
            If ds1.Tables(0).Rows.Count > 0 Then
                ASPxGridView2.DataSource = ds1.Tables(0)
            Else
                ASPxGridView2.DataSource = Nothing
            End If
            ASPxGridView2.DataBind()
        Catch ex As Exception

            MesgBox(ex.Message)
        End Try
    End Sub
    Public Sub loadModules2()
        Try
            cmd = New SqlCommand("SELECT  Company,cds_number as Clientnumber,date_created as [Date],Shares FROM trans WHERE CDS_Number NOT IN (SELECT CDS_Number FROM  [CDS_Router].[dbo].[trans] )", cn)
            adp = New SqlDataAdapter(cmd)
            Dim ds1 As New DataSet
            ds1.Clear()
            adp.Fill(ds1, "company")
            If ds1.Tables(0).Rows.Count > 0 Then
                ASPxGridView2.DataSource = ds1.Tables(0)
            Else
                ASPxGridView2.DataSource = Nothing
            End If
            ASPxGridView2.DataBind()
        Catch ex As Exception

            MesgBox(ex.Message)
        End Try
    End Sub
    Public Sub loadModules3()
        Try
            cmd = New SqlCommand("Select sum(Shares) as [shares], (select '500') as CDC_Balance, cds_number from trans group by cds_number having sum(shares)>0", cn)
            adp = New SqlDataAdapter(cmd)
            Dim ds1 As New DataSet
            ds1.Clear()
            adp.Fill(ds1, "company")
            If ds1.Tables(0).Rows.Count > 0 Then
                ASPxGridView2.DataSource = ds1.Tables(0)
            Else
                ASPxGridView2.DataSource = Nothing
            End If
            ASPxGridView2.DataBind()
        Catch ex As Exception

            MesgBox(ex.Message)
        End Try
    End Sub
    Private Sub MesgBox(ByVal sMessage As String)
        Dim msg As String
        msg = "<script language='javascript'>"
        msg += "alert('" & sMessage & "');"
        msg += "<" & "/script>"
        Response.Write(msg)
    End Sub
    Protected Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        loadModules2()
    End Sub
End Class
