Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Imports DevExpress.Web.ASPxEditors
Imports DevExpress.Web.ASPxGridView

Partial Class Assetmanfixed
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

            '     loadcomboforassetmanagers()

            '  firstcombo()

        End If
        If Session("finish") = "yes" Then
            Session("finish") = ""
            msgbox("Sent for Approval")
        End If
    End Sub




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
                Dim cmdStr As String = "insert into Recon_AssetManager_Fixed ([DateUploaded] ,[ForDate] ,[AccountNumber] ,[CSDAccount] ,[Name] ,[AssetManager],[Details] ,[Cost] ,[MarketValue],[UploadedBy],[SystemUploadBy], [RecordDate]) values (@DateUploaded ,@ForDate ,@AccountNumber ,'' ,@Name ,@AssetManager,@Details ,@Cost ,@MarketValue,@UploadedBy,@SystemUploadBy, getdate())"
                cmd2 = New SqlCommand(cmdStr, cn)
                cmd2.Parameters.AddWithValue("@DateUploaded", dr.Item(0).ToString)
                cmd2.Parameters.AddWithValue("@ForDate", dtdate.Text)
                cmd2.Parameters.AddWithValue("@AccountNumber", dr.Item(1).ToString)
                cmd2.Parameters.AddWithValue("@Name", dr.Item(2).ToString)
                cmd2.Parameters.AddWithValue("@AssetManager", dr.Item(3).ToString)
                cmd2.Parameters.AddWithValue("@Details", dr.Item(4).ToString)
                cmd2.Parameters.AddWithValue("@Cost", dr.Item(5).ToString)
                cmd2.Parameters.AddWithValue("@MarketValue", dr.Item(6).ToString)
                cmd2.Parameters.AddWithValue("@UploadedBy", dr.Item(7).ToString)
                cmd2.Parameters.AddWithValue("@SystemUploadBy", Session("Username"))




                Try

                    cn.Open()
                    cmd2.ExecuteNonQuery()
                    cn.Close()
                Catch ex As Exception

                End Try


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





    Public Sub loadModules()
        Try
            cmd = New SqlCommand("SELECT Company as company, CDS_Number as cdsnumber, Date_Created as datecreated, Shares as shares FROM [CDS_Router].[dbo].[trans] WHERE CDS_Number NOT IN (SELECT CDS_Number FROM trans)", cn)
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
            cmd = New SqlCommand("SELECT Company as company, CDS_Number as cdsnumber, Date_Created as datecreated, Shares as shares FROM [trans] WHERE CDS_Number NOT IN (SELECT CDS_Number FROM  [CDS_Router].[dbo].[trans] )", cn)
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
    Public Function datas_authorized() As DataSet
        Try

            ASPxGridView2.SettingsText.Title = cmbtype.SelectedItem.Text

            cmd = New SqlCommand("declare @dateracho date='" + dtdateview.Date.ToString + "' select * from Recon_AssetManager_Fixed_Approvals where convert(date,ForDate)=@dateracho and Approved='1'", cn)
            adp = New SqlDataAdapter(cmd)
            Dim ds1 As New DataSet
            ds1.Clear()
            adp.Fill(ds1, "company")
            If ds1.Tables(0).Rows.Count > 0 Then
                Return ds1
            Else
                Return Nothing
            End If

        Catch ex As Exception
            ' msgbox(ex.Message)
        End Try
    End Function
    Public Sub getview_authorized()
        Try

            ASPxGridView2.SettingsText.Title = cmbtype.SelectedItem.Text

            cmd = New SqlCommand("declare @dateracho date='" + dtdateview.Date.ToString + "' select * from Recon_AssetManager_Fixed_Approvals where convert(date,ForDate)=@dateracho and Approved='1'", cn)
            adp = New SqlDataAdapter(cmd)
            Dim ds1 As New DataSet
            ds1.Clear()
            adp.Fill(ds1, "company")
            If ds1.Tables(0).Rows.Count > 0 Then
                ASPxGridView3.DataSource = ds1.Tables(0)
            Else
                ASPxGridView3.DataSource = Nothing
            End If
            ASPxGridView3.DataBind()
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Function datas() As DataSet
        Try

            ASPxGridView2.SettingsText.Title = cmbtype.SelectedItem.Text

            cmd = New SqlCommand("declare @dateracho date='" + dtdateview.Date.ToString + "' select replace(replace([Security],'ROLLOVER',''),'RES','')+''+[Account No]+''+AssetManager+''+CONVERT(nvarchar(50),@dateracho) as [ID], [Account No], Names, replace(replace([Security],'ROLLOVER',''),'RES','') as [Security], AssetManager ,Holding as [C-Trade Cost], [Asset Manager Cost], Holding-[Asset Manager Cost] as [Cost Variance],  case when holding>[Asset Manager Cost] then 'More Cost on C-trade' when holding<[Asset Manager Cost] then 'Less Cost on C-Trade' when Holding=[Asset Manager Cost] then 'Trade Costs Balancing' end as [Cost Status], InterestAmount as [C-Trade Value], AssetManagerValue,InterestAmount-AssetManagerValue as [Value Variance] , case when holding>AssetManagerValue then 'More Value on C-trade' when holding<AssetManagerValue then 'Less Value on C-Trade' when Holding=AssetManagerValue then 'Value Balancing' end as [Value Status] from (select  m.ClientNo as [Account No], a.Surname+' '+a.Forenames as [Names], m.[Description] as [Security], Amount as [Holding],Amount + case DaycountBasis when 'actual/365' then ((FixedRate/100*Amount)/365)*DATEDIFF(day, TradeDate ,@dateracho) when 'actual/360' then ((FixedRate/100*Amount)/360)*DATEDIFF(day, TradeDate ,@dateracho) else ((FixedRate/100*Amount)/365)*DATEDIFF(day, TradeDate ,getdate()) end as [InterestAmount],isnull((select top 1 Cost from Recon_AssetManager_Fixed where AccountNumber=m.ClientNo and AssetManager=m.AssetManager and replace(replace(replace(details,'ROLLOVER',''),'RES',''),' ','')=replace(m.Description,' ','') and convert(date, ForDate)=@dateracho order by id desc),0) as [Asset Manager Cost],isnull((select top 1 MarketValue from Recon_AssetManager_Fixed where AccountNumber=m.ClientNo and AssetManager=m.AssetManager and replace(replace(replace(details,'ROLLOVER',''),'RES',''),' ','')=replace(m.Description,' ','') and convert(date, ForDate)=@dateracho order by id desc),0) as AssetManagerValue,   m.AssetManager    from MoneyMarket m inner join  Accounts_Clients A on a.CDS_Number=m.ClientNo where TradeStatus='ON-GOING' and m.maturitydate>=@dateracho) m where m.[Security]  in (select details from Recon_AssetManager_Fixed where convert(date, ForDate)=@dateracho) and replace(replace([Security],'ROLLOVER',''),'RES','')+''+[Account No]+''+AssetManager+''+CONVERT(nvarchar(50),@dateracho) not in (select reference from Recon_AssetManager_Fixed_Approvals where approved is NULL and Rejected is NULL)", cn)
            adp = New SqlDataAdapter(cmd)
            Dim ds1 As New DataSet
            ds1.Clear()
            adp.Fill(ds1, "company")
            If ds1.Tables(0).Rows.Count > 0 Then
                Return ds1
            Else
                Return Nothing
            End If

        Catch ex As Exception
            ' msgbox(ex.Message)
        End Try
    End Function

    Public Function datas_notuploaded() As DataSet
        Try

            ASPxGridView2.SettingsText.Title = cmbtype.SelectedItem.Text

            cmd = New SqlCommand("declare @dateracho date='" + dtdateview.Date.ToString + "' select replace(replace([Security],'ROLLOVER',''),'RES','')+''+[Account No]+''+AssetManager+''+CONVERT(nvarchar(50),@dateracho) as [ID], [Account No], Names, replace(replace([Security],'ROLLOVER',''),'RES','') as [Security], AssetManager ,Holding as [C-Trade Cost], [Asset Manager Cost], Holding-[Asset Manager Cost] as [Cost Variance],  case when holding>[Asset Manager Cost] then 'More Cost on C-trade' when holding<[Asset Manager Cost] then 'Less Cost on C-Trade' when Holding=[Asset Manager Cost] then 'Trade Costs Balancing' end as [Cost Status], InterestAmount as [C-Trade Value], AssetManagerValue,InterestAmount-AssetManagerValue as [Value Variance] , case when holding>AssetManagerValue then 'More Value on C-trade' when holding<AssetManagerValue then 'Less Value on C-Trade' when Holding=AssetManagerValue then 'Value Balancing' end as [Value Status] from (select  m.ClientNo as [Account No], a.Surname+' '+a.Forenames as [Names], m.[Description] as [Security], Amount as [Holding],Amount + case DaycountBasis when 'actual/365' then ((FixedRate/100*Amount)/365)*DATEDIFF(day, TradeDate ,@dateracho) when 'actual/360' then ((FixedRate/100*Amount)/360)*DATEDIFF(day, TradeDate ,@dateracho) else ((FixedRate/100*Amount)/365)*DATEDIFF(day, TradeDate ,getdate()) end as [InterestAmount],isnull((select top 1 Cost from Recon_AssetManager_Fixed where AccountNumber=m.ClientNo and AssetManager=m.AssetManager and replace(replace(replace(details,'ROLLOVER',''),'RES',''),' ','')=replace(m.Description,' ','') and convert(date, ForDate)=@dateracho order by id desc),0) as [Asset Manager Cost],isnull((select top 1 MarketValue from Recon_AssetManager_Fixed where AccountNumber=m.ClientNo and AssetManager=m.AssetManager and replace(replace(replace(details,'ROLLOVER',''),'RES',''),' ','')=replace(m.Description,' ','') and convert(date, ForDate)=@dateracho order by id desc),0) as AssetManagerValue,   m.AssetManager    from MoneyMarket m inner join  Accounts_Clients A on a.CDS_Number=m.ClientNo where TradeStatus='ON-GOING' and m.maturitydate>=@dateracho) m where m.[Security] not  in (select details from Recon_AssetManager_Fixed where convert(date, ForDate)=@dateracho) and replace(replace([Security],'ROLLOVER',''),'RES','')+''+[Account No]+''+AssetManager+''+CONVERT(nvarchar(50),@dateracho) not in (select reference from Recon_AssetManager_Fixed_Approvals where approved is NULL and Rejected is NULL)", cn)
            adp = New SqlDataAdapter(cmd)
            Dim ds1 As New DataSet
            ds1.Clear()
            adp.Fill(ds1, "company")
            If ds1.Tables(0).Rows.Count > 0 Then
                Return ds1
            Else
                Return Nothing
            End If

        Catch ex As Exception
            ' msgbox(ex.Message)
        End Try
    End Function
    Public Sub getview()
        Try

            ASPxGridView2.SettingsText.Title = cmbtype.SelectedItem.Text

            cmd = New SqlCommand("declare @dateracho date='" + dtdateview.Date.ToString + "' select replace(replace([Security],'ROLLOVER',''),'RES','')+''+[Account No]+''+AssetManager+''+CONVERT(nvarchar(50),@dateracho) as [ID], [Account No], Names, replace(replace([Security],'ROLLOVER',''),'RES','') as [Security], AssetManager ,Holding as [C-Trade Cost], [Asset Manager Cost], Holding-[Asset Manager Cost] as [Cost Variance],  case when holding>[Asset Manager Cost] then 'More Cost on C-trade' when holding<[Asset Manager Cost] then 'Less Cost on C-Trade' when Holding=[Asset Manager Cost] then 'Trade Costs Balancing' end as [Cost Status], InterestAmount as [C-Trade Value], AssetManagerValue,InterestAmount-AssetManagerValue as [Value Variance] , case when holding>AssetManagerValue then 'More Value on C-trade' when holding<AssetManagerValue then 'Less Value on C-Trade' when Holding=AssetManagerValue then 'Value Balancing' end as [Value Status] from (select  m.ClientNo as [Account No], a.Surname+' '+a.Forenames as [Names], m.[Description] as [Security], Amount as [Holding],Amount + case DaycountBasis when 'actual/365' then ((FixedRate/100*Amount)/365)*DATEDIFF(day, TradeDate ,@dateracho) when 'actual/360' then ((FixedRate/100*Amount)/360)*DATEDIFF(day, TradeDate ,@dateracho) else ((FixedRate/100*Amount)/365)*DATEDIFF(day, TradeDate ,getdate()) end as [InterestAmount],isnull((select top 1 Cost from Recon_AssetManager_Fixed where AccountNumber=m.ClientNo and AssetManager=m.AssetManager and replace(replace(replace(details,'ROLLOVER',''),'RES',''),' ','')=replace(m.Description,' ','') and convert(date, ForDate)=@dateracho order by id desc),0) as [Asset Manager Cost],isnull((select top 1 MarketValue from Recon_AssetManager_Fixed where AccountNumber=m.ClientNo and AssetManager=m.AssetManager and replace(replace(replace(details,'ROLLOVER',''),'RES',''),' ','')=replace(m.Description,' ','') and convert(date, ForDate)=@dateracho order by id desc),0) as AssetManagerValue,   m.AssetManager    from MoneyMarket m inner join  Accounts_Clients A on a.CDS_Number=m.ClientNo where TradeStatus='ON-GOING' and m.maturitydate>=@dateracho) m where m.[Security]  in (select details from Recon_AssetManager_Fixed where convert(date, ForDate)=@dateracho) and replace(replace([Security],'ROLLOVER',''),'RES','')+''+[Account No]+''+AssetManager+''+CONVERT(nvarchar(50),@dateracho) not in (select reference from Recon_AssetManager_Fixed_Approvals where approved is NULL and Rejected is NULL)", cn)
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
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub getview_notuploaded()
        Try

            ASPxGridView2.SettingsText.Title = cmbtype.SelectedItem.Text

            cmd = New SqlCommand("declare @dateracho date='" + dtdateview.Date.ToString + "' select replace(replace([Security],'ROLLOVER',''),'RES','')+''+[Account No]+''+AssetManager+''+CONVERT(nvarchar(50),@dateracho) as [ID], [Account No], Names, replace(replace([Security],'ROLLOVER',''),'RES','') as [Security], AssetManager ,Holding as [C-Trade Cost], [Asset Manager Cost], Holding-[Asset Manager Cost] as [Cost Variance],  case when holding>[Asset Manager Cost] then 'More Cost on C-trade' when holding<[Asset Manager Cost] then 'Less Cost on C-Trade' when Holding=[Asset Manager Cost] then 'Trade Costs Balancing' end as [Cost Status], InterestAmount as [C-Trade Value], AssetManagerValue,InterestAmount-AssetManagerValue as [Value Variance] , case when holding>AssetManagerValue then 'More Value on C-trade' when holding<AssetManagerValue then 'Less Value on C-Trade' when Holding=AssetManagerValue then 'Value Balancing' end as [Value Status] from (select  m.ClientNo as [Account No], a.Surname+' '+a.Forenames as [Names], m.[Description] as [Security], Amount as [Holding],Amount + case DaycountBasis when 'actual/365' then ((FixedRate/100*Amount)/365)*DATEDIFF(day, TradeDate ,@dateracho) when 'actual/360' then ((FixedRate/100*Amount)/360)*DATEDIFF(day, TradeDate ,@dateracho) else ((FixedRate/100*Amount)/365)*DATEDIFF(day, TradeDate ,getdate()) end as [InterestAmount],isnull((select top 1 Cost from Recon_AssetManager_Fixed where AccountNumber=m.ClientNo and AssetManager=m.AssetManager and replace(replace(replace(details,'ROLLOVER',''),'RES',''),' ','')=replace(m.Description,' ','') and convert(date, ForDate)=@dateracho order by id desc),0) as [Asset Manager Cost],isnull((select top 1 MarketValue from Recon_AssetManager_Fixed where AccountNumber=m.ClientNo and AssetManager=m.AssetManager and replace(replace(replace(details,'ROLLOVER',''),'RES',''),' ','')=replace(m.Description,' ','') and convert(date, ForDate)=@dateracho order by id desc),0) as AssetManagerValue,   m.AssetManager    from MoneyMarket m inner join  Accounts_Clients A on a.CDS_Number=m.ClientNo where TradeStatus='ON-GOING' and m.maturitydate>=@dateracho) m where m.[Security] not in (select details from Recon_AssetManager_Fixed where convert(date, ForDate)=@dateracho) and replace(replace([Security],'ROLLOVER',''),'RES','')+''+[Account No]+''+AssetManager+''+CONVERT(nvarchar(50),@dateracho) not in (select reference from Recon_AssetManager_Fixed_Approvals where approved is NULL and Rejected is NULL)", cn)
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
            msgbox(ex.Message)
        End Try
    End Sub
    Protected Sub cmbtype_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbtype.SelectedIndexChanged

    End Sub
    Private Sub ASPxGridView2_DataBinding(sender As Object, e As EventArgs) Handles ASPxGridView2.DataBinding
        If cmbtype.SelectedItem.Text = "Exceptions - Uploaded" Then

            ASPxGridView2.DataSource = datas()

        Else

            ASPxGridView2.DataSource = datas_notuploaded()


        End If


    End Sub
    Private Sub ASPxGridView3_DataBinding(sender As Object, e As EventArgs) Handles ASPxGridView3.DataBinding

        ASPxGridView3.DataSource = datas_authorized()




    End Sub
    Public Sub gv()
        If RadioButtonList1.SelectedItem.Text = "Un-Authorized" Then
            ASPxGridView2.Visible = True
            ASPxGridView3.Visible = False

            If cmbtype.SelectedItem.Text = "Exceptions - Uploaded" Then
                getview()

            Else
                getview_notuploaded()

            End If

        Else
            ASPxGridView2.Visible = False
            ASPxGridView3.Visible = True

            getview_authorized()

        End If
    End Sub
    Protected Sub btnupload0_Click(sender As Object, e As EventArgs) Handles btnupload0.Click
        gv()
    End Sub

    Protected Sub btnupload1_Click(sender As Object, e As EventArgs) Handles btnupload1.Click
        If ASPxGridView2.Visible = True Then
            gv()
            ASPxGridViewExporter1.WriteXlsToResponse()
        Else
            gv()

            ASPxGridViewExporter2.WriteXlsToResponse()
        End If


    End Sub

    Private Sub ASPxGridView2_RowCommand(sender As Object, e As ASPxGridViewRowCommandEventArgs) Handles ASPxGridView2.RowCommand
        If RadioButtonList1.SelectedItem.Text = "Authorized" Then
            msgbox("You cannot comment on an Authorized Transaction!")
            Exit Sub
        End If
        Dim id As String = e.KeyValue.ToString
        If e.CommandArgs.CommandName.ToString = "Comment" Then
            lbltransid.Text = id
            ASPxPopupControl1.PopupHorizontalAlign = DevExpress.Web.ASPxClasses.PopupHorizontalAlign.WindowCenter
            ASPxPopupControl1.PopupVerticalAlign = DevExpress.Web.ASPxClasses.PopupVerticalAlign.WindowCenter

            ASPxPopupControl1.AllowDragging = True
            ASPxPopupControl1.ShowCloseButton = True
            ASPxPopupControl1.ShowOnPageLoad = True
            Page.MaintainScrollPositionOnPostBack = True
        ElseIf e.CommandArgs.CommandName.ToString = "Send for Authorization" Then
            sendforauthorization(id, "No Comment")
            gv()

            msgbox("Sent for Authorization")
            ' msgbox(id.ToString)
        End If
    End Sub
    Public Sub sendforauthorization(id As String, comment As String)

        cmd = New SqlCommand("declare @dateracho date='" + dtdateview.Date.ToString + "' insert into Recon_AssetManager_Fixed_Approvals  ([Account No] ,[Names],[Security],[AssetManager],[C-Trade Cost],[Asset Manager Cost] ,[Cost Variance],[Cost Status] ,[C-Trade Value],[AssetManagerValue] ,[Value Variance],[Value Status] ,[Reference],[SentBy],[Approved] ,[ApprovedBy] ,[Rejected],[Comments], [ForDate])	  select  [Account No], Names, replace(replace([Security],'ROLLOVER',''),'RES','') as [Security], AssetManager ,Holding as [C-Trade Cost], [Asset Manager Cost], Holding-[Asset Manager Cost] as [Cost Variance],  case when holding>[Asset Manager Cost] then 'More Cost on C-trade' when holding<[Asset Manager Cost] then 'Less Cost on C-Trade' when Holding=[Asset Manager Cost] then 'Trade Costs Balancing' end as [Cost Status], InterestAmount as [C-Trade Value], AssetManagerValue,InterestAmount-AssetManagerValue as [Value Variance] , case when holding>AssetManagerValue then 'More Value on C-trade' when holding<AssetManagerValue then 'Less Value on C-Trade' when Holding=AssetManagerValue then 'Value Balancing' end as [Value Status], '" + id + "','" + Session("Username") + "',NULL,NULL, NULL, '" + comment + "', @dateracho  from (select  m.ClientNo as [Account No], a.Surname+' '+a.Forenames as [Names], m.[Description] as [Security], Amount as [Holding],Amount + case DaycountBasis when 'actual/365' then ((FixedRate/100*Amount)/365)*DATEDIFF(day, TradeDate ,@dateracho) when 'actual/360' then ((FixedRate/100*Amount)/360)*DATEDIFF(day, TradeDate ,@dateracho) else ((FixedRate/100*Amount)/365)*DATEDIFF(day, TradeDate ,getdate()) end as [InterestAmount],isnull((select top 1 Cost from Recon_AssetManager_Fixed where AccountNumber=m.ClientNo and AssetManager=m.AssetManager and replace(replace(replace(details,'ROLLOVER',''),'RES',''),' ','')=replace(m.Description,' ','') and convert(date, ForDate)=@dateracho order by id desc),0) as [Asset Manager Cost],isnull((select top 1 MarketValue from Recon_AssetManager_Fixed where AccountNumber=m.ClientNo and AssetManager=m.AssetManager and replace(replace(replace(details,'ROLLOVER',''),'RES',''),' ','')=replace(m.Description,' ','') and convert(date, ForDate)=@dateracho order by id desc),0) as AssetManagerValue,   m.AssetManager    from MoneyMarket m inner join  Accounts_Clients A on a.CDS_Number=m.ClientNo where TradeStatus='ON-GOING' and m.maturitydate>=@dateracho) m where replace(replace([Security],'ROLLOVER',''),'RES','')+''+[Account No]+''+AssetManager+''+CONVERT(nvarchar(50),@dateracho)='" + id + "'", cn)
        If (cn.State = ConnectionState.Open) Then
            cn.Close()
        End If
        cn.Open()
        cmd.ExecuteNonQuery()
        cn.Close()

    End Sub
    Protected Sub btnSaveContract1_Click(sender As Object, e As EventArgs) Handles btnSaveContract1.Click
        If txtotp.Text = "" Then
            msgbox("Please enter comment to proceed!")
        Else
            If lbltransid.Text = "multiple" Then
                Dim keys As List(Of Object) = ASPxGridView2.GetCurrentPageRowValues(New String() {"ID"})
                For Each key As Object In keys
                    Dim chk As ASPxCheckBox = TryCast(ASPxGridView2.FindRowCellTemplateControlByKey(key, TryCast(ASPxGridView2.Columns("Selec"), GridViewDataColumn), "chk1"), ASPxCheckBox)

                    Dim check As Boolean = chk.Checked
                    If check = True Then
                        sendforauthorization(key, txtotp.Text)


                    End If
                Next
                ASPxPopupControl1.AllowDragging = False
                ASPxPopupControl1.ShowCloseButton = False
                ASPxPopupControl1.ShowOnPageLoad = False
                Page.MaintainScrollPositionOnPostBack = False
                txtotp.Text = ""
                gv()

                msgbox("Sent for Authorization")
            Else
                sendforauthorization(lbltransid.Text, txtotp.Text)
                ASPxPopupControl1.AllowDragging = False
                ASPxPopupControl1.ShowCloseButton = False
                ASPxPopupControl1.ShowOnPageLoad = False
                Page.MaintainScrollPositionOnPostBack = False
                txtotp.Text = ""
                gv()

                msgbox("Sent for Authorization")
            End If

        End If
    End Sub
    Protected Sub btnupload2_Click(sender As Object, e As EventArgs) Handles btnupload2.Click
        If RadioButtonList1.SelectedItem.Text = "Authorized" Then
            msgbox("You cannot comment on an Authorized Transaction!")
            Exit Sub
        End If
        Dim keys As List(Of Object) = ASPxGridView2.GetCurrentPageRowValues(New String() {"ID"})
        For Each key As Object In keys
            Dim chk As ASPxCheckBox = TryCast(ASPxGridView2.FindRowCellTemplateControlByKey(key, TryCast(ASPxGridView2.Columns("Selec"), GridViewDataColumn), "chk1"), ASPxCheckBox)

            Dim check As Boolean = chk.Checked
            If check = True Then
                sendforauthorization(key, "No Comment")


            End If
        Next
        gv()

        msgbox("Status Successfully Updated!")
    End Sub
    Protected Sub btnupload3_Click(sender As Object, e As EventArgs) Handles btnupload3.Click

        lbltransid.Text = "multiple"
        ASPxPopupControl1.PopupHorizontalAlign = DevExpress.Web.ASPxClasses.PopupHorizontalAlign.WindowCenter
        ASPxPopupControl1.PopupVerticalAlign = DevExpress.Web.ASPxClasses.PopupVerticalAlign.WindowCenter

        ASPxPopupControl1.AllowDragging = True
        ASPxPopupControl1.ShowCloseButton = True
        ASPxPopupControl1.ShowOnPageLoad = True
        Page.MaintainScrollPositionOnPostBack = True

    End Sub
End Class
