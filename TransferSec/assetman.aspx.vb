Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Imports DevExpress.Web.ASPxEditors
Imports DevExpress.Web.ASPxGridView

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

        Page.MaintainScrollPositionOnPostBack = True
        If (Not IsPostBack) Then

            'getcompanies()
            ' loadcomboforassetmanagers()
            '  firstcombo()
        Else

        End If
        If Session("finish") = "yes" Then
            Session("finish") = ""
            msgbox("Sent for Approval")
        End If
    End Sub


    Public Function correctaccounts(cdsno As String) As Boolean
        Dim dsport As New DataSet
        cmd = New SqlCommand("select * from accounts_clients where cds_number='" + cdsno + "'", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(dsport, "trans")
        If (dsport.Tables(0).Rows.Count > 0) Then
            Return True
        Else
            Return False

        End If

    End Function
    Public Function correctassetmanager(assetmanager As String) As Boolean
        Dim dsport As New DataSet
        cmd = New SqlCommand("select * from para_assetManager where AssetManagerCode='" + assetmanager + "'", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(dsport, "trans")
        If (dsport.Tables(0).Rows.Count > 0) Then
            Return True
        Else
            Return False

        End If

    End Function
    Public Function correctcompany(company As String) As Boolean
        Dim dsport As New DataSet
        cmd = New SqlCommand("select * from para_company where company='" + company + "'", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(dsport, "trans")
        If (dsport.Tables(0).Rows.Count > 0) Then
            Return True
        Else
            Return False

        End If

    End Function
    'Public Sub firstcombo()
    '    Dim dsport As New DataSet
    '    cmd = New SqlCommand("select AssetManagerCode as code, p.AssetMananger from  para_AssetManager p", cn)
    '    adp = New SqlDataAdapter(cmd)
    '    adp.Fill(dsport, "trans")
    '    If (dsport.Tables(0).Rows.Count > 0) Then
    '        cmbassetmanager.DataSource = dsport
    '        cmbassetmanager.TextField = "AssetMananger"
    '        cmbassetmanager.ValueField = "code"
    '        cmbassetmanager.DataBind()
    '    End If

    'End Sub
    Public Sub deleteprev(assetmanager As String, company As String, accountnumber As String)
        cmd = New SqlCommand("delete from recon_AssetManager where AssetManager='" + assetmanager + "' and Company='" + company + "' and AccountNumber='" + accountnumber + "' ", cn)
        If (cn.State = ConnectionState.Open) Then
            cn.Close()
        End If
        cn.Open()
        cmd.ExecuteNonQuery()
        cn.Close()
    End Sub

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
                If correctaccounts(dr.Item(1).ToString) = False Then
                    msgbox("There is an invalid Account in the system. Invalid account is " + dr.Item(1).ToString + "")
                    Exit Sub
                End If
                If correctassetmanager(dr.Item(4).ToString) = False Then
                    msgbox("There is an invalid Asset Manager in the system. Invalid Asset Manager is " + dr.Item(4).ToString + "")
                    Exit Sub
                End If

                If correctcompany(dr.Item(5).ToString) = False Then
                    msgbox("There is an invalid Company in the system. Invalid Company is " + dr.Item(5).ToString + "")
                    Exit Sub
                End If


                Dim cmd2 As New SqlCommand
                Dim cmdStr As String = "insert into Recon_AssetManager ([DateUploaded] ,[ForDate] ,[AccountNumber] ,[CSDAccount] ,[Name] ,[AssetManager],[Company] ,[Units] ,[MarketValue],[UploadedBy],[SystemUploadBy], [RecordDate]) values (@DateUploaded ,@ForDate ,@AccountNumber ,@CSDAccount ,@Name ,@AssetManager,@Company ,@Units ,@MarketValue,@UploadedBy,@SystemUploadBy, getdate())"
                deleteprev(dr.Item(4).ToString, dr.Item(5).ToString, dr.Item(1).ToString)
                cmd2 = New SqlCommand(cmdStr, cn)
                cmd2.Parameters.AddWithValue("@DateUploaded", dr.Item(0).ToString)
                cmd2.Parameters.AddWithValue("@ForDate", dtdate.Text)
                cmd2.Parameters.AddWithValue("@AccountNumber", dr.Item(1).ToString)
                cmd2.Parameters.AddWithValue("@CSDAccount", dr.Item(2).ToString)
                cmd2.Parameters.AddWithValue("@Name", dr.Item(3).ToString)
                cmd2.Parameters.AddWithValue("@AssetManager", dr.Item(4).ToString)
                cmd2.Parameters.AddWithValue("@Company", dr.Item(5).ToString)
                cmd2.Parameters.AddWithValue("@Units", dr.Item(6).ToString.Replace(",", ""))
                cmd2.Parameters.AddWithValue("@MarketValue", dr.Item(7).ToString.Replace(",", ""))
                cmd2.Parameters.AddWithValue("@UploadedBy", dr.Item(8).ToString)
                cmd2.Parameters.AddWithValue("@SystemUploadBy", Session("Username"))




                Try
                    cn.Open()
                    cmd2.ExecuteNonQuery()
                    cn.Close()
                Catch ex As Exception

                End Try



            Next
            conn.Close()

        Else

        End If
        msgbox("Upload Successful")

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




    Private Sub MesgBox(ByVal sMessage As String)
        Dim msg As String
        msg = "<script language='javascript'>"
        msg += "alert('" & sMessage & "');"
        msg += "<" & "/script>"
        Response.Write(msg)
    End Sub

    Protected Sub cmbtype_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbtype.SelectedIndexChanged

    End Sub
    Protected Sub btnupload0_Click(sender As Object, e As EventArgs) Handles btnupload0.Click
        If RadioButtonList1.SelectedItem.Text = "Un-Authorized" Then

            ASPxGridView2.DataSource = Nothing
            ASPxGridView2.DataBind()

            getview()
            ASPxGridView2_auth.Visible = False
            ASPxGridView2.Visible = True
            CheckBox1.Visible = True


        Else


            getview_authorized()
            ASPxGridView2_auth.Visible = True
            ASPxGridView2.Visible = False
            CheckBox1.Visible = False


        End If




    End Sub

    Public Sub getview()

        Try

            ASPxGridView2.DataSource = Nothing
            ASPxGridView2.DataBind()


            If cmbtype.SelectedItem.Text = "Exceptions - Not Uploaded" Then

                cmd = New SqlCommand(" declare @company nvarchar(50)='ALL';  declare @date date='" + dtdateview.Date.ToString + "' select '' as Selec,*, [C-Trade Value]-[Asset Manager Value] as [Value Variance], case when [C-Trade Value]-[Asset Manager Value]>0 then 'Less Value at Asset Manager' when  [C-Trade Value]-[Asset Manager Value]<0  then 'More Value at Asset Manager' when [C-Trade Value]-[Asset Manager Value]=0 then 'Balancing' end as [Value Status] from (select *, [Account No]+' '+ [Security]+' '+Assetmanager+''+convert(nvarchar(50),@date) as [ID], [C-Trade Holding]*ISNULL((select top 1 Current_price  from Market_data_history where ticker=z.[Security] and convert(date, [date])<=@date order by [date] desc,id desc),0) as [C-Trade Value], MarketValue as [Asset Manager Value]  from (select *, case when j.variance>0 then 'Less units at Asset Manager' when j.Variance<0 then 'More units at Asset Manager' else 'Balancing' end as [Status] from ( select t.cds_number as [Account No], a.Surname+' '+a.Forenames as [Names],   t.Company as [Security], AssetManager, isnull(sum(t.shares),0) as [C-Trade Holding] , 0 as [Asset Manager Holding],0  as [MarketValue]  ,isnull(sum(t.shares),0)- 0 as [Variance]   from trans_recon t, Accounts_Clients a where a.CDS_Number = t.CDS_Number    and convert(date, t.date_created)<=@date  group by t.CDS_Number, a.Surname, a.Forenames, t.Company,t.AssetManager) j) z) zz  where   [Account No]+' '+ [Security]+' '+Assetmanager+''+convert(nvarchar(50),@date) not in (select  [Account No]+' '+ [Security]+' '+Assetmanager+''+convert(nvarchar(50),@date) from Recon_AssetManager where ForDate=@date) and   [Account No]+' '+ [Security]+' '+Assetmanager+''+convert(nvarchar(50),@date) NOT IN (select Reference from Recon_AssetManager_Approvals where CurrentStatus in ('Pending','APPROVED'))  order by [Account No]", cn)
            ElseIf cmbtype.SelectedItem.Text = "Exceptions - Uploaded" Then

                cmd = New SqlCommand(" declare @company nvarchar(50)='ALL';  declare @date date='" + dtdateview.Date.ToString + "' select '' as Selec,zz.*, convert(numeric(18,2),[C-Trade Value])-convert(numeric(18,2),[Asset Manager Value]) as [Value Variance], case when [C-Trade Value]-[Asset Manager Value]>0 then 'Less Value at Asset Manager' when  [C-Trade Value]-[Asset Manager Value]<0  then 'More Value at Asset Manager' when [C-Trade Value]-[Asset Manager Value]=0 then 'Balancing' end as [Value Status] from (select *, [Account No]+' '+ [Security]+' '+Assetmanager+''+convert(nvarchar(50),@date) as [ID], [C-Trade Holding]*ISNULL((select top 1 Current_price  from Market_data_history where ticker=z.[Security] and convert(date, [date])<=@date order by [date] desc,id desc),0) as [C-Trade Value], MarketValue as [Asset Manager Value]  from (select *, case when j.variance>0 then 'Less units at Asset Manager' when j.Variance<0 then 'More units at Asset Manager' else 'Balancing' end as [Status] from ( select t.cds_number as [Account No], a.Surname+' '+a.Forenames as [Names],   t.Company as [Security], r.AssetManager, isnull(sum(t.shares),0) as [C-Trade Holding] , isnull(units,0) as [Asset Manager Holding],isnull(MarketValue,0) as [MarketValue]  ,isnull(sum(t.shares),0)-isnull(units,0) as [Variance]   from trans_recon t inner join Accounts_Clients a on a.CDS_Number = t.CDS_Number  inner join Recon_AssetManager  r on r.AccountNumber=t.cds_number and r.AssetManager=t.AssetManager  and r.Company=t.company where convert(date, t.date_created)<=@date and r.ForDate=@date group by t.CDS_Number, a.Surname, a.Forenames, t.Company,t.AssetManager, r.AssetManager, R.Units, r.MarketValue ) j) z) zz where  [Account No]+' '+ [Security]+' '+zz.Assetmanager+''+convert(nvarchar(50),@date) NOT IN (select Reference from Recon_AssetManager_Approvals where CurrentStatus in ('Pending','APPROVED'))  order by [Account No]", cn)

            End If

            'ElseIf cmbtype.SelectedItem.Text = "Not found in C-Trade" Then
            '    cmd = New SqlCommand("select AccountNumber as [Account No], [Name], AssetManager, Company as [Security], Units, MarketValue, RecordDate from Recon_AssetManager where company='ALL'  and convert(date, Dateuploaded)<='" + dtdateview.Text + "' and AccountNumber not in (select cds_number from Accounts_clients)", cn)
            'ElseIf cmbtype.SelectedItem.Text = "Values Exceptions" Then
            '    cmd = New SqlCommand("declare @company nvarchar(50)='ALL';  declare @date date='" + dtdateview.Text + "' select * from (select *, case when j.variance>0 then 'Less value at Asset Manager' when j.Variance<0 then 'More value at Asset Manager' else 'Balancing' end as [Status] from ( select t.cds_number as [Account No], a.Surname+' '+a.Forenames as [Names],   t.Company as [Security], AssetManager, case p.Currency when 'ZWL' then  isnull(sum(t.shares),0)*ISNULL((select top 1 Current_price  from Market_data_history where ticker=t.Company and convert(date, [date])<=@date order by [date] desc,id desc),0) else isnull(sum(t.shares),0)*ISNULL((select top 1 Current_price  from Market_data_history where ticker=t.Company and convert(date, [date])<=@date order by [date] desc,id desc),0)*isnull((select top 1 RateToBase  from para_CurrencyRates where CurrencyCode=p.currency  and convert(date, DateFrom)<=convert(date,@date) order by rateid desc),0) end as [C-Trade Value],   (select isnull(sum(Marketvalue),0) from Recon_AssetManager where company=t.Company and AssetManager=t.AssetManager and AccountNumber=t.CDS_Number and convert(date, ForDate)='" + dtdateview.Date + "' ) as [Asset Manager Value]  ,case p.currency when 'ZWL' then  isnull(sum(t.shares),0)*ISNULL((select top 1 Current_price  from Market_data_history where ticker=t.Company and convert(date, [date])<=@date order by [date] desc,id desc),0) else  isnull(sum(t.shares),0)*ISNULL((select top 1 Current_price  from Market_data_history where ticker=t.Company and convert(date, [date])<=@date order by [date] desc,id desc),0)*isnull((select top 1 RateToBase  from para_CurrencyRates where CurrencyCode=p.currency  and convert(date, DateFrom)<=convert(date,@date) order by rateid desc),0) end-  (select isnull(sum(MarketValue),0) from Recon_AssetManager where company=t.Company and AssetManager=t.AssetManager and AccountNumber=t.CDS_Number and convert(date, ForDate)='" + dtdateview.Date + "' ) as [Variance]  from trans_recon t, Accounts_Clients a, para_company p  where p.company=t.company and a.CDS_Number = t.CDS_Number   and convert(date, t.date_created)<=@date   group by t.CDS_Number, a.Surname, a.Forenames, t.Company,t.AssetManager,P.currency) j) z", cn)
            'End If





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
    Public Function view() As DataSet
        Try


            If cmbtype.SelectedItem.Text = "Exceptions - Not Uploaded" Then

                cmd = New SqlCommand(" declare @company nvarchar(50)='ALL';  declare @date date='" + dtdateview.Date.ToString + "' select '' as Selec,*, [C-Trade Value]-[Asset Manager Value] as [Value Variance], case when [C-Trade Value]-[Asset Manager Value]>0 then 'Less Value at Asset Manager' when  [C-Trade Value]-[Asset Manager Value]<0  then 'More Value at Asset Manager' when [C-Trade Value]-[Asset Manager Value]=0 then 'Balancing' end as [Value Status] from (select *, [Account No]+' '+ [Security]+' '+Assetmanager+''+convert(nvarchar(50),@date) as [ID], [C-Trade Holding]*ISNULL((select top 1 Current_price  from Market_data_history where ticker=z.[Security] and convert(date, [date])<=@date order by [date] desc,id desc),0) as [C-Trade Value], MarketValue as [Asset Manager Value]  from (select *, case when j.variance>0 then 'Less units at Asset Manager' when j.Variance<0 then 'More units at Asset Manager' else 'Balancing' end as [Status] from ( select t.cds_number as [Account No], a.Surname+' '+a.Forenames as [Names],   t.Company as [Security], AssetManager, isnull(sum(t.shares),0) as [C-Trade Holding] , 0 as [Asset Manager Holding],0  as [MarketValue]  ,isnull(sum(t.shares),0)- 0 as [Variance]   from trans_recon t, Accounts_Clients a where a.CDS_Number = t.CDS_Number    and convert(date, t.date_created)<=@date  group by t.CDS_Number, a.Surname, a.Forenames, t.Company,t.AssetManager) j) z) zz  where   [Account No]+' '+ [Security]+' '+Assetmanager+''+convert(nvarchar(50),@date) not in (select  [Account No]+' '+ [Security]+' '+Assetmanager+''+convert(nvarchar(50),@date) from Recon_AssetManager where ForDate=@date) and   [Account No]+' '+ [Security]+' '+Assetmanager+''+convert(nvarchar(50),@date) NOT IN (select Reference from Recon_AssetManager_Approvals where CurrentStatus in ('Pending','APPROVED'))  order by [Account No]", cn)
            ElseIf cmbtype.SelectedItem.Text = "Exceptions - Uploaded" Then

                cmd = New SqlCommand("declare @company nvarchar(50)='ALL';  declare @date date='" + dtdateview.Date.ToString + "' select '' as Selec,zz.*, convert(numeric(18,2),[C-Trade Value])-convert(numeric(18,2),[Asset Manager Value]) as [Value Variance], case when [C-Trade Value]-[Asset Manager Value]>0 then 'Less Value at Asset Manager' when  [C-Trade Value]-[Asset Manager Value]<0  then 'More Value at Asset Manager' when [C-Trade Value]-[Asset Manager Value]=0 then 'Balancing' end as [Value Status] from (select *, [Account No]+' '+ [Security]+' '+Assetmanager+''+convert(nvarchar(50),@date) as [ID], [C-Trade Holding]*ISNULL((select top 1 Current_price  from Market_data_history where ticker=z.[Security] and convert(date, [date])<=@date order by [date] desc,id desc),0) as [C-Trade Value], MarketValue as [Asset Manager Value]  from (select *, case when j.variance>0 then 'Less units at Asset Manager' when j.Variance<0 then 'More units at Asset Manager' else 'Balancing' end as [Status] from ( select t.cds_number as [Account No], a.Surname+' '+a.Forenames as [Names],   t.Company as [Security], r.AssetManager, isnull(sum(t.shares),0) as [C-Trade Holding] , isnull(units,0) as [Asset Manager Holding],isnull(MarketValue,0) as [MarketValue]  ,isnull(sum(t.shares),0)-isnull(units,0) as [Variance]   from trans_recon t inner join Accounts_Clients a on a.CDS_Number = t.CDS_Number  inner join Recon_AssetManager  r on r.AccountNumber=t.cds_number and r.AssetManager=t.AssetManager  and r.Company=t.company where convert(date, t.date_created)<=@date and r.ForDate=@date group by t.CDS_Number, a.Surname, a.Forenames, t.Company,t.AssetManager, r.AssetManager, R.Units, r.MarketValue ) j) z) zz where  [Account No]+' '+ [Security]+' '+zz.Assetmanager+''+convert(nvarchar(50),@date) NOT IN (select Reference from Recon_AssetManager_Approvals where CurrentStatus in ('Pending','APPROVED'))  order by [Account No]", cn)

            End If





            adp = New SqlDataAdapter(cmd)
            Dim ds1 As New DataSet
            ds1.Clear()
            adp.Fill(ds1, "company")
            If ds1.Tables(0).Rows.Count > 0 Then
                Return ds1
            Else
                Return ds1
            End If

        Catch ex As Exception
            msgbox(ex.Message)
        End Try

    End Function
    Public Function view_auth() As DataSet
        Try


            cmd = New SqlCommand("select '' as Selec,*,[CtradeValue] as [C-Trade Value]     ,[AssetManagerValue] as [Asset Manager Value]      ,[ValueVariance]    as [Value Variance]   ,[ValueStatus] as [Value Status] , Comment from Recon_AssetManager_Approvals where CurrentStatus='Approved' and convert(date, ReconDate)='" + dtdateview.Date.ToString + "' order by [Account No]", cn)




            adp = New SqlDataAdapter(cmd)
            Dim ds1 As New DataSet
            ds1.Clear()
            adp.Fill(ds1, "company")
            If ds1.Tables(0).Rows.Count > 0 Then
                Return ds1
            Else
                Return ds1
            End If

        Catch ex As Exception
            msgbox(ex.Message)
        End Try

    End Function
    Public Sub getview_authorized()

        Try



            cmd = New SqlCommand("select '' as Selec,*,[CtradeValue] as [C-Trade Value]     ,[AssetManagerValue] as [Asset Manager Value]      ,[ValueVariance]    as [Value Variance]   ,[ValueStatus] as [Value Status] , Comment from Recon_AssetManager_Approvals where CurrentStatus='Approved' and convert(date, ReconDate)='" + dtdateview.Date.ToString + "' order by [Account No]", cn)




                adp = New SqlDataAdapter(cmd)
            Dim ds1 As New DataSet
            ds1.Clear()
            adp.Fill(ds1, "company")
            If ds1.Tables(0).Rows.Count > 0 Then
                ASPxGridView2_auth.DataSource = ds1.Tables(0)
            Else
                ASPxGridView2_auth.DataSource = Nothing
            End If
            ASPxGridView2_auth.DataBind()
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub


    Protected Sub btnupload1_Click(sender As Object, e As EventArgs) Handles btnupload1.Click
        ' getview()
        If RadioButtonList1.SelectedItem.Text = "Un-Authorized" Then

            ASPxGridView2.DataSource = Nothing
            ASPxGridView2.DataBind()

            getview()
            ASPxGridView2_auth.Visible = False
            ASPxGridView2.Visible = True
            CheckBox1.Visible = True


        Else


            getview_authorized()
            ASPxGridView2_auth.Visible = True
            ASPxGridView2.Visible = False
            CheckBox1.Visible = False


        End If




        ASPxGridViewExporter1.WriteXlsToResponse()


    End Sub
    Public Sub sendforauthorization(id As String, comment As String)

        cmd = New SqlCommand("declare @company nvarchar(50)='ALL';  declare @date date='" + dtdateview.Text + "' INSERT INTO Recon_AssetManager_Approvals  ([Account No]      ,[Names]      ,[Security]      ,[AssetManager]      ,[C-Trade Holding]      ,[Asset Manager Holding] ,    [Variance] ,[AssetManagerValue]       ,[Status]      ,[Reference]      ,[DateAuthorized]      ,[AuthorizedBy]      ,[CurrentStatus]      ,[Comment]      ,[ReconDate]      ,[CtradeValue]        ,[ValueVariance]      ,[ValueStatus]) select *,[C-Trade Value]-MarketValue  as [Variance], case when [C-Trade Value]-[MarketValue]>0 then 'Less Value at Asset Manager' when  [C-Trade Value]-[MarketValue]<0  then 'More Value at Asset Manager' when [C-Trade Value]-[MarketValue]=0 then 'Balancing' end as [Value Status] from ( select *, [Account No]+' '+ [Security]+' '+Assetmanager+''+convert(nvarchar(50),@date) as [Reference], NULL AS [DateAuthorized], NULL as AuthorizedBy,'Pending' as [CurrentStatus], '" + comment + "' AS Comment, @date as recdate, [C-Trade Holding]*ISNULL((select top 1 Current_price  from Market_data_history where ticker=z.[Security] and convert(date, [date])<=@date order by [date] desc,id desc),0) as [C-Trade Value]    from (select *, case when j.variance>0 then 'Less units at Asset Manager' when j.Variance<0 then 'More units at Asset Manager' else 'Balancing' end as [Status] from ( select t.cds_number as [Account No], a.Surname+' '+a.Forenames as [Names],   t.Company as [Security], AssetManager, isnull(sum(t.shares),0) as [C-Trade Holding],  (select isnull(units,0) from Recon_AssetManager where company=t.Company and AssetManager=t.AssetManager and AccountNumber=t.CDS_Number and convert(date, ForDate)=@date  ) as [Asset Manager Holding] ,isnull(sum(t.shares),0)-  (select isnull(units,0) from Recon_AssetManager where company=t.Company and AssetManager=t.AssetManager and AccountNumber=t.CDS_Number and convert(date, ForDate)=@date) as [Variance], (select isnull(MarketValue,0) from Recon_AssetManager where company=t.Company and AssetManager=t.AssetManager and AccountNumber=t.CDS_Number and convert(date, ForDate)=@date) as [MarketValue]    from trans_recon t, Accounts_Clients a where a.CDS_Number = t.CDS_Number    and convert(date, t.date_created)<=@date  group by t.CDS_Number, a.Surname, a.Forenames, t.Company,t.AssetManager) j) z) zz  where  [Account No]+' '+ [Security]+' '+Assetmanager+''+convert(nvarchar(50),@date)='" + id + "'", cn)
        If (cn.State = ConnectionState.Open) Then
            cn.Close()
        End If
        cn.Open()
        cmd.ExecuteNonQuery()
        cn.Close()

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
            getview()

            msgbox("Sent for Authorization")
            '  msgbox(id.ToString)
        End If

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
                getview()
                msgbox("Sent for Authorization")
            Else
                sendforauthorization(lbltransid.Text, txtotp.Text)
                ASPxPopupControl1.AllowDragging = False
                ASPxPopupControl1.ShowCloseButton = False
                ASPxPopupControl1.ShowOnPageLoad = False
                Page.MaintainScrollPositionOnPostBack = False
                txtotp.Text = ""
                getview()
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
        getview()
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

    Private Sub ASPxGridView2_DataBinding(sender As Object, e As EventArgs) Handles ASPxGridView2.DataBinding
        ASPxGridView2.DataSource = view()

    End Sub
    Protected Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged

        Dim myGridView As New ASPxGridView
        myGridView = ASPxGridView2
        If CheckBox1.Checked = True Then
            Dim keys As List(Of Object) = myGridView.GetCurrentPageRowValues(New String() {"ID"})
            For Each key As Object In keys
                Dim chk As ASPxCheckBox = TryCast(ASPxGridView2.FindRowCellTemplateControlByKey(key, TryCast(ASPxGridView2.Columns("Selec"), GridViewDataColumn), "chk1"), ASPxCheckBox)
                chk.Checked = True
            Next
        Else
            Dim keys As List(Of Object) = myGridView.GetCurrentPageRowValues(New String() {"ID"})
            For Each key As Object In keys
                Dim chk As ASPxCheckBox = TryCast(ASPxGridView2.FindRowCellTemplateControlByKey(key, TryCast(ASPxGridView2.Columns("Selec"), GridViewDataColumn), "chk1"), ASPxCheckBox)
                chk.Checked = False
            Next
        End If

    End Sub

    Private Sub ASPxGridView3_DataBinding(sender As Object, e As EventArgs) Handles ASPxGridView3.DataBinding

    End Sub

    Private Sub ASPxGridView2_auth_DataBinding(sender As Object, e As EventArgs) Handles ASPxGridView2_auth.DataBinding
        ASPxGridView2_auth.DataSource = view_auth()

    End Sub
End Class
