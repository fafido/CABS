Imports System.IO
Imports DevExpress.Web.ASPxGridView

Partial Class Parameters_price
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
    Public Sub loadcompanies()
        Dim dsport As New DataSet
        cmd = New SqlCommand("select * from para_company", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(dsport, "trans")
        If (dsport.Tables(0).Rows.Count > 0) Then
            cmbparaCompany.DataSource = dsport
            cmbparaCompany.TextField = "fnam"
            cmbparaCompany.ValueField = "company"
            cmbparaCompany.DataBind()
        End If
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Page.MaintainScrollPositionOnPostBack = True
            If (Not IsPostBack) Then
                getSecurities_Categories()
                loadcompanies()
            Else
                getSecurities_Categories()

            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Protected Sub clearall()

        txtprice.Text = ""

        getSecurities_Categories()
    End Sub
    Protected Sub ASPxButton7_Click(sender As Object, e As EventArgs) Handles ASPxButton7.Click
        Dim tody As Date = Date.UtcNow
        Dim cal As Date = dtdate.Date

        'If tody.ToString("ddMMMyyyy") = cal.ToString("ddMMMyyyy") Then

        '    cmd = New SqlCommand("update [Market_Data] set Current_price='" + txtprice.Text + "' where ticker='" + cmbparaCompany.SelectedItem.Value.ToString + "' insert into [Market_Data_History] (ticker, Current_price, counter_type, [date], CaptureDate ) values ('" + cmbparaCompany.SelectedItem.Value.ToString + "','" + txtprice.Text + "','equity','" + dtdate.Date.ToString + "',getdate())", cn)
        'Else
        cmd = New SqlCommand(" insert into [Market_Data_History_Audit] (ticker, Current_price, counter_type, [date], CaptureDate, CapturedBy ) values ('" + cmbparaCompany.SelectedItem.Value.ToString + "','" + txtprice.Text + "','equity','" + dtdate.Date.ToString + "',getdate(),'" + Session("Username") + "')", cn)
        ' End If



        If cn.State = ConnectionState.Open Then
            cn.Close()
        End If
        cn.Open()
        Dim y As Integer = cmd.ExecuteNonQuery()
        cn.Close()
        getSecurities_Categories()
        cmbparaCompany.Value = ""
        txtprice.Text = ""
        dtdate.Text = ""
        msgbox("Sent for Authorization!")

    End Sub
    Protected Sub getSecurities_Categories()
        Try
            cmd = New SqlCommand("select * from Market_Data_History order by id desc", cn)
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
        cmd = New SqlCommand("select * from Market_Data_History order by id desc", cn)
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

    Protected Sub ASPxButton8_Click(sender As Object, e As EventArgs) Handles ASPxButton8.Click
        If FileUpload1.HasFile Then
            Dim connectionString As String = ""
            Dim fileName2 As String = Path.GetFileName(FileUpload1.PostedFile.FileName)


            Dim fileLocation As String = Server.MapPath("~/uploads/recon_" & Date.Now.ToString("ddMMyyyymmsss") & fileName2)
            FileUpload1.SaveAs(fileLocation)
            Dim fileExtension As String = Path.GetExtension(FileUpload1.PostedFile.FileName)
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
                
                Dim dr = dtExcelRecords.Rows(x)
                Dim tody As Date = Date.UtcNow

                Dim cal As Date = dr.Item(2).ToString
                Dim comp As String = dr.Item(0).ToString
                Dim price As String = dr.Item(1).ToString
                Dim typ As String = dr.Item(3).ToString

                Dim cmd2 As New SqlCommand

                If tody.ToString("ddMMMyyyy") = cal.ToString("ddMMMyyyy") Then
                    cmd2 = New SqlCommand("insert into [Market_Data_History_audit] (ticker, Current_price, counter_type, [date], CaptureDate, CapturedBy ) values ('" + comp + "','" + price + "','equity','" + cal + "',getdate(),'" + Session("Username") + "')", cn)
                    '  cmd2 = New SqlCommand("update [Market_Data] set Current_price='" + txtprice.Text + "' where ticker='" + comp + "' insert into [Market_Data_History] (ticker, Current_price, counter_type, [date], CaptureDate ) values ('" + comp + "','" + price + "','equity','" + cal + "',getdate())", cn)
                Else
                    ' deleteexistingfordate(dr.Item(2).ToString, dr.Item(0).ToString)
                    cmd2 = New SqlCommand(" insert into [Market_Data_History_audit] (ticker, Current_price, counter_type, [date], CaptureDate, CapturedBy) values ('" + comp + "','" + price + "','equity','" + cal + "',getdate(),'" + Session("Username") + "')", cn)
                End If


                'Dim cmdStr As String = "insert into Recon_AssetManager ([DateUploaded] ,[ForDate] ,[AccountNumber] ,[CSDAccount] ,[Name] ,[AssetManager],[Company] ,[Units] ,[MarketValue],[UploadedBy],[SystemUploadBy], [RecordDate]) values (@DateUploaded ,@ForDate ,@AccountNumber ,@CSDAccount ,@Name ,@AssetManager,@Company ,@Units ,@MarketValue,@UploadedBy,@SystemUploadBy, getdate())"
                ''deleteprev(dr.Item(4).ToString, dr.Item(5).ToString, dr.Item(1).ToString)
                'cmd2 = New SqlCommand(cmdStr, cn)
                'cmd2.Parameters.AddWithValue("@DateUploaded", dr.Item(0).ToString)
                'cmd2.Parameters.AddWithValue("@ForDate", dtdate.Text)
                'cmd2.Parameters.AddWithValue("@AccountNumber", dr.Item(1).ToString)
                'cmd2.Parameters.AddWithValue("@CSDAccount", dr.Item(2).ToString)
                'cmd2.Parameters.AddWithValue("@Name", dr.Item(3).ToString)
                'cmd2.Parameters.AddWithValue("@AssetManager", dr.Item(4).ToString)
                'cmd2.Parameters.AddWithValue("@Company", dr.Item(5).ToString)
                'cmd2.Parameters.AddWithValue("@Units", dr.Item(6).ToString.Replace(",", ""))
                'cmd2.Parameters.AddWithValue("@MarketValue", dr.Item(7).ToString.Replace(",", ""))
                'cmd2.Parameters.AddWithValue("@UploadedBy", dr.Item(8).ToString)
                'cmd2.Parameters.AddWithValue("@SystemUploadBy", Session("Username"))




                Try
                    cn.Open()
                    cmd2.ExecuteNonQuery()
                    cn.Close()
                Catch ex As Exception
                    cn.Close()
                    msgbox(ex.Message + " >> " + cal.ToString + " " + comp.ToString + " " + price.ToString)
                End Try



            Next
            cn.Close()

        Else

        End If
        msgbox("upload successful")
    End Sub
End Class
