Imports System.IO
Imports DevExpress.Web.ASPxGridView

Partial Class Parameters_BankUpload

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
                ASPxGridView3.DataSource = dat()
                ASPxGridView3.DataBind()


            Else


            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub




    Public Function available(reference As String) As Boolean
        cmd = New SqlCommand("select * from trans_bank where reference='" + reference + "' order by id desc", cn)
        Dim ds As New DataSet
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "para_Country")
        If ds.Tables(0).Rows.Count > 0 Then
            Return True
        Else
            Return False
        End If

    End Function
    Public Function dat() As DataSet
        cmd = New SqlCommand("select * from trans_bank order by id desc", cn)
        Dim ds As New DataSet
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "para_Country")
        If ds.Tables(0).Rows.Count > 0 Then
            Return ds
        Else
            Return Nothing

        End If
    End Function
    Public Function available_batch(fnam As String) As Boolean
        cmd = New SqlCommand("select * from trans_bank where FileName='" + fnam + "' order by id desc", cn)
        Dim ds As New DataSet
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "para_Country")
        If ds.Tables(0).Rows.Count > 0 Then
            Return True
        Else
            Return False
        End If

    End Function

    Public Function isallocated(rf As String) As String
        cmd = New SqlCommand("select Allocated from trans_bank where reference='" + rf + "' order by id desc", cn)
        Dim ds As New DataSet
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "para_Country")
        If ds.Tables(0).Rows.Count > 0 Then
            Return ds.Tables(0).Rows(0).Item("Allocated").ToString
        Else
            Return "NOT ALLOCATED"
        End If

    End Function

    Public Sub delete(ref As String)
        cmd = New SqlCommand("delete from trans_bank where reference='" + ref + "'  and Allocated='NOT ALLOCATED'", cn)
        If (cn.State = ConnectionState.Open) Then
            cn.Close()
        End If
        cn.Open()
        cmd.ExecuteNonQuery()
        cn.Close()
    End Sub
    Public Sub delete_batch(name As String)
        cmd = New SqlCommand("delete from trans_bank where FileName='" + name + "' and Allocated='NOT ALLOCATED'", cn)
        If (cn.State = ConnectionState.Open) Then
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

            If available_batch(fileName2) = True Then

                delete_batch(fileName2)
            End If


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

                Dim assetmanager As String = dr.Item(6).ToString
                Dim bankaccount As String = dr.Item(5).ToString
                Dim bankname As String = dr.Item(4).ToString
                Dim Amount As String = dr.Item(3).ToString
                Dim reference As String = dr.Item(1).ToString

                '  Dim otherdetails As String = dr.Item(5).ToString
                Dim descr As String = dr.Item(2).ToString.Replace("'", "")
                Dim transdate As Date = dr.Item(0).ToString
                Dim currency As String = dr.Item(7).ToString
                Dim receivedvia As String = "Upload"

                '  msgbox(reference)
                If available(reference) = True Then

                    delete(reference)
                End If


                If isallocated(reference) = "NOT ALLOCATED" Then


                    Dim cmd2 As New SqlCommand
                    cmd2 = New SqlCommand("insert trans_bank (AssetManager, BankAccount, BankName, Amount, Reference, DateCreated,Allocated, ReceivedVia,Currency, Other_Details, FileName, UploadBy, UploadDate )   values ('" + assetmanager + "','" + bankaccount + "','" + bankname + "','" + Amount + "','" + reference + "','" + transdate + "','NOT ALLOCATED','UPLOAD','" + currency + "','" + descr + "','" + fileName2 + "','" + Session("Username") + "',getdate())", cn)
                    Try
                        cn.Open()
                        cmd2.ExecuteNonQuery()
                        cn.Close()
                    Catch ex As Exception
                        msgbox(ex.Message)
                    End Try
                End If



            Next
            conn.Close()

        Else

        End If
        ASPxGridView3.DataSource = dat()
        ASPxGridView3.DataBind()
        msgbox("Upload Successful")
    End Sub

    Private Sub ASPxGridView3_DataBinding(sender As Object, e As EventArgs) Handles ASPxGridView3.DataBinding
        ASPxGridView3.DataSource = dat()

    End Sub
End Class
