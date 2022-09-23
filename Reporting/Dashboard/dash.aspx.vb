
Partial Class Reporting_Dashboard_dash
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
    Public Sub getstats()
        Dim ds As New DataSet
        Dim i As Integer = 0
        '  cmd = New SqlCommand("declare @custodian nvarchar(50)='" + Session("Brokercode") + "';declare @company nvarchar(50)='" + Session("comp") + "'; select isnull((select count(*) from accounts_clients where custodian=@custodian),0) AS [TotalRegistration] ,ISNULL((select sum(amount) from cdsc.dbo.cashtrans where cds_number in (select cds_number from accounts_clients where custodian=@custodian)),0) as [totalfunds], isnull((select sum(shares) from trans where cds_number in (select cds_number from accounts_clients where custodian=@custodian) and company=@company),0) as [totalholdings], 0 AS CDCHOLDINGS, ISNULL((SELECT SUM(quantity) FROM LIVETRADINGMASTER  where cds_ac_no in (select cds_number from accounts_clients where custodian=@custodian) and company=@company and OrderType='SELL'),0) AS [Incomingsells],ISNULL((SELECT SUM(quantity) FROM LIVETRADINGMASTER  where cds_ac_no in (select cds_number from accounts_clients where custodian=@custodian) and company=@company and OrderType='BUY'),0) AS [Incomingbuys],(  select isnull(sum(tradeqty),0) from tblmatchedorders where banksent='0' and (account1 in (select cds_number from accounts_clients where custodian=@custodian) or account2 in (select cds_number from accounts_clients where custodian=@custodian)) and company=@company) as [Pendingsettlement],(  select isnull(sum(tradeqty),0) from tblmatchedorders where ack='SETTLED' and (account1 in (select cds_number from accounts_clients where custodian=@custodian) or account2 in (select cds_number from accounts_clients where custodian=@custodian)) and company=@company and convert(date,SettlementDate)=convert(date,getdate()))  as [todaysettlement]", cn)
        cmd = New SqlCommand("declare @custodian nvarchar(50)='" + Session("Brokercode") + "';declare @company nvarchar(50)='" + Session("comp") + "';select isnull((select count(*) from accounts_clients where custodian=@custodian),0) AS [TotalRegistration] ,ISNULL((select sum(amount) from cdsc.dbo.cashtrans where  cds_number in (select cds_number from accounts_clients where custodian=@custodian)),0) as [totalfunds], isnull((select sum(shares) from trans where cds_number in (select cds_number from accounts_clients where custodian=@custodian) and company=@company),0) as [totalholdings], (SELECT ISNULL(sum(quantity),0) from testcds.dbo.Tbl_MatchedDeals where convert(date,trade)=convert(date,getdate()) and BuyCompany=@company and (Buyercdsno in (select cds_number from accounts_clients where custodian=@custodian) or Sellercdsno in (select cds_number from accounts_clients where custodian=@custodian))) AS CDCHOLDINGS, ISNULL((SELECT SUM(quantity) FROM testcds.dbo.LIVETRADINGMASTER  where cds_ac_no in (select cds_number from accounts_clients where custodian=@custodian) and company=@company and OrderType='SELL'),0) AS [Incomingsells],ISNULL((SELECT SUM(quantity) FROM testcds.dbo.LIVETRADINGMASTER  where cds_ac_no in (select cds_number from accounts_clients where custodian=@custodian) and company=@company and OrderType='BUY'),0) AS [Incomingbuys],(  select isnull(sum(tradeqty),0) from tblmatchedorders where banksent='0' and (account1 in (select cds_number from accounts_clients where custodian=@custodian) or account2 in (select cds_number from accounts_clients where custodian=@custodian)) and company=@company) as [Pendingsettlement],(  select isnull(sum(tradeqty),0) from tblmatchedorders where ack='SETTLED' and (account1 in (select cds_number from accounts_clients where custodian=@custodian) or account2 in (select cds_number from accounts_clients where custodian=@custodian)) and company=@company and convert(date,SettlementDate)=convert(date,getdate()))  as [todaysettlement], (select count(*) from Accounts_clients where custodian=@custodian and cds_number in (select cds_Number from CDS_ROUTER.dbo.Accounts_Clients_Web where SourceName='online')) as [Online], (select count(*) from Accounts_clients where custodian=@custodian and cds_number in (select cds_Number from CDS_ROUTER.dbo.Accounts_Clients_Web where SourceName='USSD')) as [USSD], (select count(*) from Accounts_clients where custodian=@custodian and cds_number in (select cds_Number from CDS_ROUTER.dbo.Accounts_Clients_Web where SourceName='MOBILE')) as [Mobile], ISNULL((select sum(amount) from cdsc.dbo.cashtrans where cds_number in (select cds_number from cds_router.dbo.Accounts_Clients_Web where SourceName='online') AND cds_number in (select cds_Number from accounts_clients where custodian=@custodian)),0) as [onlinefunds],ISNULL((select sum(amount) from cdsc.dbo.cashtrans where  cds_number in (select cds_number from cds_router.dbo.Accounts_Clients_Web where SourceName='USSD') AND cds_number in (select cds_Number from accounts_clients where custodian=@custodian)),0) as [USSDfunds],ISNULL((select sum(amount) from cdsc.dbo.cashtrans where cds_number in (select cds_number from cds_router.dbo.Accounts_Clients_Web where SourceName='MOBILE') AND cds_number in (select cds_Number from accounts_clients where custodian=@custodian)),0) as [MOBILEfunds]", cn)

        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "stats")

        If ds.Tables(0).Rows.Count > 0 Then
            lbltotal_registrations.InnerText = ds.Tables("stats").Rows(0).Item("TotalRegistration")
            lblfinsec.InnerText = ds.Tables("stats").Rows(0).Item("totalholdings")
            lbltotal_funds.InnerText = "$" + Math.Round(ds.Tables("stats").Rows(0).Item("totalfunds"), 2).ToString
            lbldepositoryholdings.InnerText = ds.Tables("stats").Rows(0).Item("CDCHOLDINGS")
            lbltotal_holdings.InnerText = ds.Tables("stats").Rows(0).Item("totalholdings")
            lblincomingsells.InnerText = ds.Tables("stats").Rows(0).Item("Incomingsells")
            lblincomingbuys.InnerText = ds.Tables("stats").Rows(0).Item("Incomingbuys")
            lblpendingsettlement.InnerText = ds.Tables("stats").Rows(0).Item("Pendingsettlement")
            lbltodaysettled.InnerText = ds.Tables("stats").Rows(0).Item("todaysettlement")
            lblussd.InnerText = ds.Tables("stats").Rows(0).Item("USSD")
            lblonline.InnerText = ds.Tables("stats").Rows(0).Item("Online")
            lblmobile.InnerText = ds.Tables("stats").Rows(0).Item("Mobile")
            lblussdfunds.InnerText = "$" + Math.Round(ds.Tables("stats").Rows(0).Item("USSDfunds"), 2).ToString
            lblonlinefunds.InnerText = "$" + Math.Round(ds.Tables("stats").Rows(0).Item("Onlinefunds"), 2).ToString
            lblmobilefunds.InnerText = "$" + Math.Round(ds.Tables("stats").Rows(0).Item("MOBILEfunds"), 2).ToString


        End If
    End Sub
    Public Sub getpercentagestats()
        Dim ds1 As New DataSet
        Dim i As Integer = 0
        '  cmd = New SqlCommand("declare @custodian nvarchar(50)='" + Session("Brokercode") + "';declare @company nvarchar(50)='" + Session("comp") + "'; select isnull((select count(*) from accounts_clients where custodian=@custodian),0) AS [TotalRegistration] ,ISNULL((select sum(amount) from cdsc.dbo.cashtrans where cds_number in (select cds_number from accounts_clients where custodian=@custodian)),0) as [totalfunds], isnull((select sum(shares) from trans where cds_number in (select cds_number from accounts_clients where custodian=@custodian) and company=@company),0) as [totalholdings], 0 AS CDCHOLDINGS, ISNULL((SELECT SUM(quantity) FROM LIVETRADINGMASTER  where cds_ac_no in (select cds_number from accounts_clients where custodian=@custodian) and company=@company and OrderType='SELL'),0) AS [Incomingsells],ISNULL((SELECT SUM(quantity) FROM LIVETRADINGMASTER  where cds_ac_no in (select cds_number from accounts_clients where custodian=@custodian) and company=@company and OrderType='BUY'),0) AS [Incomingbuys],(  select isnull(sum(tradeqty),0) from tblmatchedorders where banksent='0' and (account1 in (select cds_number from accounts_clients where custodian=@custodian) or account2 in (select cds_number from accounts_clients where custodian=@custodian)) and company=@company) as [Pendingsettlement],(  select isnull(sum(tradeqty),0) from tblmatchedorders where ack='SETTLED' and (account1 in (select cds_number from accounts_clients where custodian=@custodian) or account2 in (select cds_number from accounts_clients where custodian=@custodian)) and company=@company and convert(date,SettlementDate)=convert(date,getdate()))  as [todaysettlement]", cn)
        cmd = New SqlCommand("declare @custodian nvarchar(50)='" + Session("Brokercode") + "';declare @company nvarchar(50)='" + Session("comp") + "'; select isnull((select count(*) from cds_router.dbo.accounts_clients_web where country like '%zimbabwe%' and cds_number in (select cds_number from accounts_clients where Custodian=@custodian)),0) AS [Local], isnull((select count(*) from accounts_clients where custodian=@custodian),0) as [Totalreg], isnull((select count(*) from AccountC_FailedReg where cdsc_number in (select cds_Number from CDS_ROUTER.dbo.Accounts_Clients_Web where Custodian=@custodian)),0) as [Failedreg], isnull((select count(*) from accounts_clients where custodian=@custodian and cds_number in (select cds_number from trans where company=@company group by cds_number having sum(shares)>0)),0) as [withshares], (select count(*) from Accounts_clients where custodian=@custodian and cds_number in (select cds_Number from CDS_ROUTER.dbo.Accounts_Clients_Web where SourceName='online')) as [Online], (select count(*) from Accounts_clients where custodian=@custodian and cds_number in (select cds_Number from CDS_ROUTER.dbo.Accounts_Clients_Web where SourceName='USSD')) as [USSD], (select count(*) from Accounts_clients where custodian=@custodian and cds_number in (select cds_Number from CDS_ROUTER.dbo.Accounts_Clients_Web where SourceName='MOBILE')) as [Mobile]", cn)

        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds1, "stats2")

        If ds1.Tables(0).Rows.Count > 0 Then
            Dim local As Decimal = ds1.Tables("stats2").Rows(0).Item("local")
            Dim totalreg As Decimal = ds1.Tables("stats2").Rows(0).Item("totalreg")
            Dim failedreg As Decimal = ds1.Tables("stats2").Rows(0).Item("failedreg")
            Dim withshares As Decimal = ds1.Tables("stats2").Rows(0).Item("withshares")
            Dim online As Decimal = ds1.Tables("stats2").Rows(0).Item("online")
            Dim ussd As Decimal = ds1.Tables("stats2").Rows(0).Item("USSD")
            Dim mobile As Decimal = ds1.Tables("stats2").Rows(0).Item("mobile")

            Dim localregperc As Decimal = local / totalreg * 100
            Dim failedregperc As Decimal = failedreg / totalreg * 100
            Dim withsharesperc As Decimal = withshares / totalreg * 100
            Dim mobileper As Decimal = mobile / totalreg * 100
            Dim ussdperc As Decimal = ussd / totalreg * 100
            Dim onlineperc As Decimal = online / totalreg * 100

            lbllocalregistrations1.Attributes("style") = "width: " + localregperc.ToString + "%;"
            lblfailedreg1.Attributes("style") = "width: " + failedregperc.ToString + "%;"
            lblaccountswithholdings1.Attributes("style") = "width: " + withsharesperc.ToString + "%;"
            lblmobile1.Attributes("style") = "width: " + mobileper.ToString + "%;"
            lblussd1.Attributes("style") = "width: " + ussd.ToString + "%;"
            lblonline1.Attributes("style") = "width: " + onlineperc.ToString + "%;"

            lbllocalregistrations.InnerText = Math.Round(localregperc, 2).ToString + "%"
            lblfailedregistrations.InnerText = Math.Round(failedregperc, 2).ToString + "%"
            lblwithholdings.InnerText = Math.Round(withsharesperc, 2).ToString + "%"
            lblmobileper.InnerText = Math.Round(mobileper, 2).ToString + "%"
            lblussdperc.InnerText = Math.Round(ussd, 2).ToString + "%"
            lblonlineper.InnerText = Math.Round(onlineperc, 2).ToString + "%"

        End If
    End Sub
    Public Sub loadgriview()
        Dim ds As New DataSet
        Dim i As Integer = 0
        cmd = New SqlCommand("select isnull(cds_number,'NIL') AS cds_number, isnull(brokercode,'NIL') as brokercode,  ISNULL(left(isnull(surname,'')+' '+isnull(forenames,''),20),'NIL') as [fullname], ISNULL(idnopp,'NIL') as idnopp, ISNULL(custodian,'NULL') as custodian, ISNULL(mobile,'NIL') as mobile from accounts_clients where custodian='" + Session("Brokercode") + "' ORDER BY ID DESC", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "namesclients")

        If ds.Tables(0).Rows.Count > 0 Then
            'BIND NAMES
            Try


                name1.InnerText = ds.Tables(0).Rows(0).Item("fullname")
                name2.InnerText = ds.Tables(0).Rows(1).Item("fullname")
                name3.InnerText = ds.Tables(0).Rows(2).Item("fullname")
                name4.InnerText = ds.Tables(0).Rows(3).Item("fullname")
                name5.InnerText = ds.Tables(0).Rows(4).Item("fullname")
                name6.InnerText = ds.Tables(0).Rows(5).Item("fullname")
                name7.InnerText = ds.Tables(0).Rows(6).Item("fullname")

            Catch ex As Exception

            End Try
            Try

                'BIND CDS NUMBERS
                cds1.InnerText = ds.Tables(0).Rows(0).Item("cds_Number")
                cds2.InnerText = ds.Tables(0).Rows(1).Item("cds_Number")
                cds3.InnerText = ds.Tables(0).Rows(2).Item("cds_Number")
                cds4.InnerText = ds.Tables(0).Rows(3).Item("cds_Number")
                cds5.InnerText = ds.Tables(0).Rows(4).Item("cds_Number")
                cds6.InnerText = ds.Tables(0).Rows(5).Item("cds_Number")
                cds7.InnerText = ds.Tables(0).Rows(6).Item("cds_Number")

            Catch ex As Exception

            End Try
            Try

                'BIND MOBILE NUMBERS
                phone1.InnerText = ds.Tables(0).Rows(0).Item("mobile")
                phone2.InnerText = ds.Tables(0).Rows(1).Item("mobile")
                phone3.InnerText = ds.Tables(0).Rows(2).Item("mobile")
                phone4.InnerText = ds.Tables(0).Rows(3).Item("mobile")
                phone5.InnerText = ds.Tables(0).Rows(4).Item("mobile")
                phone6.InnerText = ds.Tables(0).Rows(5).Item("mobile")
                phone7.InnerText = ds.Tables(0).Rows(6).Item("mobile")


            Catch ex As Exception

            End Try


            Try

                'BIND BROKERS
                broker1.InnerText = ds.Tables(0).Rows(0).Item("brokercode")
                broker2.InnerText = ds.Tables(0).Rows(1).Item("brokercode")
                broker3.InnerText = ds.Tables(0).Rows(2).Item("brokercode")
                broker4.InnerText = ds.Tables(0).Rows(3).Item("brokercode")
                broker5.InnerText = ds.Tables(0).Rows(4).Item("brokercode")
                broker6.InnerText = ds.Tables(0).Rows(5).Item("brokercode")
                broker7.InnerText = ds.Tables(0).Rows(6).Item("brokercode")

            Catch ex As Exception

            End Try

            Try

                'BIND ID NUMBER
                idnumber1.InnerText = ds.Tables(0).Rows(0).Item("idnopp")
                idnumber2.InnerText = ds.Tables(0).Rows(1).Item("idnopp")
                idnumber3.InnerText = ds.Tables(0).Rows(2).Item("idnopp")
                idnumber4.InnerText = ds.Tables(0).Rows(3).Item("idnopp")
                idnumber5.InnerText = ds.Tables(0).Rows(4).Item("idnopp")
                idnumber6.InnerText = ds.Tables(0).Rows(5).Item("idnopp")
                idnumber7.InnerText = ds.Tables(0).Rows(6).Item("idnopp")


            Catch ex As Exception

            End Try

            'BIND CUSTODIANS 

            'custodian1.InnerText = ""
            'custodian2.InnerText = ""
            'custodian3.InnerText = ""
            'custodian4.InnerText = ""
            'custodian5.InnerText = ""
            'custodian6.InnerText = ""
            'custodian7.InnerText = ""
        End If
    End Sub
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        '   Try

        loadgriview()

        getpercentagestats()

        'Catch ex As Exception
        '    '  msgbox(ex.Message)
        'End Try
        Try
            getstats()
        Catch ex As Exception

        End Try
    End Sub
End Class
