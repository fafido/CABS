Imports Microsoft.VisualBasic
Imports System.Net.Mail
Imports System.Web.Services
Public Class NaymatBilling
    Public conn As String = System.Configuration.ConfigurationManager.AppSettings("connpath")
    Dim cn As New SqlConnection(conn)
    Dim adp As SqlDataAdapter
    Dim cmd As SqlCommand
    Public Function accountMaintanance(ByVal TranType As String, ByVal ParticipantType As String, ByVal MaintainType As String, ByVal accid As String, ByVal TransRef As String) As Double
        Using cn = New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("connpath"))
            Dim ds As New DataSet
            Dim sqlStr As String = ""
            If MaintainType = "Account Opening" Then
                sqlStr = "declare @ChargeType nvarchar(500)='Account Opening & Maintenance Fee' DECLARE @ChargeSubtype nvarchar(500) = 'Account Opening Fee' DECLARE @ParticipantType nvarchar(500)='" & ParticipantType & "' DECLARE @AccountID nvarchar(500) = '" & accid & "' SELECT CASE WHEN B.ChargeType=B.ChargeSUBType THEN B.ChargeType ELSE B.ChargeType+' - '+ B.ChargeSUBType END AS ChargeDesc,B.PercAmount,B.ChargeCode,D.ParticipantCode,B.ID FROM (SELECT * FROM ParaCharge A WHERE A.ParticipantType=@ParticipantType AND A.ChargeType=@ChargeType  AND A.ChargeSUBType=@ChargeSubtype)B  JOIN ParaChargeParticipant D ON B.ChargeCode=D.ChargeCode WHERE D.ParticipantCode IN ('ALL',@AccountID) ORDER BY B.ID DESC"
            ElseIf MaintainType = "Account Closure" Then
                sqlStr = "declare @ChargeType nvarchar(500)='Account Opening & Maintenance Fee' DECLARE @ChargeSubtype nvarchar(500) = 'Account Closure Fee' DECLARE @ParticipantType nvarchar(500)='" & ParticipantType & "' DECLARE @AccountID nvarchar(500) = '" & accid & "' SELECT CASE WHEN B.ChargeType=B.ChargeSUBType THEN B.ChargeType ELSE B.ChargeType+' - '+ B.ChargeSUBType END AS ChargeDesc,B.PercAmount,B.ChargeCode,D.ParticipantCode,B.ID FROM (SELECT * FROM ParaCharge A WHERE A.ParticipantType=@ParticipantType AND A.ChargeType=@ChargeType AND A.ChargeSUBType=@ChargeSubtype)B  JOIN ParaChargeParticipant D ON B.ChargeCode=D.ChargeCode WHERE D.ParticipantCode IN ('ALL',@AccountID) ORDER BY B.ID DESC"
            ElseIf MaintainType = "Account Amendment" Then
                sqlStr = "declare @ChargeType nvarchar(500)='Account Opening & Maintenance Fee' DECLARE @ChargeSubtype nvarchar(500) = 'Account Amendment Fee' DECLARE @ParticipantType nvarchar(500)='" & ParticipantType & "' DECLARE @AccountID nvarchar(500) = '" & accid & "' SELECT CASE WHEN B.ChargeType=B.ChargeSUBType THEN B.ChargeType ELSE B.ChargeType+' - '+ B.ChargeSUBType END AS ChargeDesc,B.PercAmount,B.ChargeCode,D.ParticipantCode,B.ID FROM (SELECT * FROM ParaCharge A WHERE A.ParticipantType=@ParticipantType AND A.ChargeType=@ChargeType AND A.ChargeSUBType=@ChargeSubtype)B  JOIN ParaChargeParticipant D ON B.ChargeCode=D.ChargeCode WHERE D.ParticipantCode IN ('ALL',@AccountID) ORDER BY B.ID DESC"
            End If
            If MaintainType = "Account Opening" And accountOpeningExists(accid) = True Then
                Return 0
            Else
                Dim cmd = New SqlCommand(sqlStr, cn)
                Dim adp = New SqlDataAdapter(cmd)
                adp.Fill(ds, "para_othercharges")
                Dim Amount As Double = 0
                Dim chargeDesc As String = ""
                If (ds.Tables(0).Rows.Count > 0) Then
                    Amount = CDbl(ds.Tables(0).Rows(0).Item("PercAmount"))

                    Dim SalesTax As Double = 0
                    Dim IncomeTAXwithholding As Double = 0
                    Dim SalesTAXWithholding As Double = 0
                    If AccountExempted(accid) = False Then
                        SalesTax = getSALESTAX(Amount, "")
                        IncomeTAXwithholding = getIncomeTAXwithholding(Amount + SalesTax, "")
                        SalesTAXWithholding = getSalesTAXWithholding(SalesTax, "")
                    End If

                    Dim ChargeCode As String = ds.Tables(0).Rows(0).Item("ChargeCode").ToString
                    Dim DiscountAmount As Double = getDISCOUNTAmount(accid, ChargeCode, Amount)

                    If TranType.ToUpper = "ENQUIRE" Then
                        Return Amount + SalesTax - SalesTAXWithholding - IncomeTAXwithholding + DiscountAmount
                    Else
                        chargeDesc = ds.Tables(0).Rows(0).Item("ChargeDesc").ToString
                        Using con = New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("connpath"))
                            Dim InsertSTR As String = ""
                            If Amount > 0 Then
                                InsertSTR = InsertSTR & " insert into CashTrans([Description], TransType, Amount, DateCreated, TransStatus, CDS_Number, Reference,ChargeCode) values('" & chargeDesc & "','" & MaintainType & "','" & -1 * Amount & "',getdate(),'1','" & accid & "','" & TransRef & "','" & ChargeCode & "') "
                            End If
                            If SalesTax > 0 Then
                                InsertSTR = InsertSTR & " insert into CashTrans([Description], TransType, Amount, DateCreated, TransStatus, CDS_Number, Reference,ChargeCode) values('" & chargeDesc & "','Sales Tax','" & -1 * SalesTax & "',getdate(),'1','" & accid & "','" & TransRef & "','" & ChargeCode & "') "
                            End If
                            If IncomeTAXwithholding > 0 Then
                                InsertSTR = InsertSTR & " insert into CashTrans([Description], TransType, Amount, DateCreated, TransStatus, CDS_Number, Reference,ChargeCode) values('" & chargeDesc & "','Income tax withholding','" & IncomeTAXwithholding & "',getdate(),'1','" & accid & "','" & TransRef & "','" & ChargeCode & "') "
                            End If
                            If SalesTAXWithholding > 0 Then
                                InsertSTR = InsertSTR & " insert into CashTrans([Description], TransType, Amount, DateCreated, TransStatus, CDS_Number, Reference,ChargeCode) values('" & chargeDesc & "','Sales Tax Withholding','" & SalesTAXWithholding & "',getdate(),'1','" & accid & "','" & TransRef & "','" & ChargeCode & "') "
                            End If
                            If DiscountAmount > 0 Then
                                InsertSTR = InsertSTR & " insert into CashTrans([Description], TransType, Amount, DateCreated, TransStatus, CDS_Number, Reference,ChargeCode) values('" & chargeDesc & "','Discount','" & DiscountAmount & "',getdate(),'1','" & accid & "','" & TransRef & "','" & ChargeCode & "') "
                            End If
                            Using cmd2 = New SqlCommand(InsertSTR, con)
                                If con.State <> ConnectionState.Closed Then
                                    con.Close()
                                End If
                                con.Open()
                                cmd2.ExecuteNonQuery()
                                con.Close()
                            End Using
                        End Using
                        Return Amount + SalesTax - SalesTAXWithholding - IncomeTAXwithholding + DiscountAmount
                    End If
                Else
                    Return 0
                End If
            End If
        End Using
    End Function
    <WebMethod>
    Public Function transfercharges(ByVal TranType As String, ByVal ParticipantType As String, ByVal quantity As Double, ByVal accid As String, ByVal TransRef As String) As Double
        Using cn = New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("connpath"))
            Dim ds As New DataSet
            Dim sqlStr As String = ""
            If quantity > 50 Then
                sqlStr = "DECLARE @MaxquantitySet numeric(18,4) SET @MaxquantitySet =(SELECT ISNULL(MAX(RangeFrom),0) FROM ParaCharge WHERE ChargeType='EWR transaction fee (Off/On Exchange)' and ChargeSUBType='EWR transaction fee (Off/On Exchange)')  SELECT CASE WHEN ChargeType=ChargeSUBType THEN ChargeType ELSE ChargeType+' - '+ ChargeSUBType END AS ChargeDesc,* FROM ParaCharge WHERE RangeFrom=@MaxquantitySet and ChargeType='EWR transaction fee (Off/On Exchange)' and ChargeSUBType='EWR transaction fee (Off/On Exchange)' ORDER BY ID DESC"
            Else
                sqlStr = "declare @ChargeType nvarchar(500)='EWR transaction fee (Off/On Exchange)' DECLARE @ChargeSubtype nvarchar(500) = 'EWR transaction fee (Off/On Exchange)' DECLARE @ParticipantType nvarchar(500)='" & ParticipantType & "' DECLARE @AccountID nvarchar(500) = '" & accid & "' SELECT CASE WHEN B.ChargeType=B.ChargeSUBType THEN B.ChargeType ELSE B.ChargeType+' - '+ B.ChargeSUBType END AS ChargeDesc,B.PercAmount,B.ChargeCode,D.ParticipantCode,B.ID,B.Indicator,B.UptoMax FROM (SELECT * FROM ParaCharge A WHERE A.ParticipantType=@ParticipantType AND A.ChargeType=@ChargeType  AND A.ChargeSUBType=@ChargeSubtype)B  JOIN ParaChargeParticipant D ON B.ChargeCode=D.ChargeCode WHERE D.ParticipantCode IN ('ALL',@AccountID) AND B.RangeFrom <= " & quantity & " and B.RangeTo >= " & quantity & " ORDER BY B.ID DESC"
            End If

            Dim MaintainType As String = "EWR transaction fee (Off/On Exchange)"
            Dim cmd = New SqlCommand(sqlStr, cn)
            Dim adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "para_othercharges")
            Dim Amount As Double = 0
            Dim chargeDesc As String = ""
            If (ds.Tables(0).Rows.Count > 0) Then
                Dim extraCharges As Double = 0
                If quantity >= 100 Then
                    extraCharges = 5500.0
                    Amount = extraCharges
                ElseIf quantity < 100 And quantity > 50 Then
                    extraCharges = ((quantity - 50) / 10) * 550
                    Amount = CDbl(ds.Tables(0).Rows(0).Item("PercAmount")) + extraCharges
                Else
                    Amount = CDbl(ds.Tables(0).Rows(0).Item("PercAmount"))
                End If

                Dim SalesTax As Double = getSALESTAX(Amount, "")
                Dim IncomeTAXwithholding As Double = getIncomeTAXwithholding(Amount + SalesTax, "")
                Dim SalesTAXWithholding As Double = getSalesTAXWithholding(SalesTax, "")
                Dim ChargeCode As String = ds.Tables(0).Rows(0).Item("ChargeCode").ToString
                Dim DiscountAmount As Double = getDISCOUNTAmount(accid, ChargeCode, Amount)

                If TranType.ToUpper = "ENQUIRE" Then
                    Return Amount + SalesTax - SalesTAXWithholding - IncomeTAXwithholding + DiscountAmount
                Else
                    chargeDesc = ds.Tables(0).Rows(0).Item("ChargeDesc").ToString
                    Using con = New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("connpath"))
                        Dim InsertSTR As String = ""
                        If Amount > 0 Then
                            InsertSTR = InsertSTR & " insert into CashTrans([Description], TransType, Amount, DateCreated, TransStatus, CDS_Number, Reference,ChargeCode) values('" & chargeDesc & "','" & MaintainType & "','" & -1 * Amount & "',getdate(),'1','" & accid & "','" & TransRef & "','" & ChargeCode & "') "
                        End If
                        If SalesTax > 0 Then
                            InsertSTR = InsertSTR & " insert into CashTrans([Description], TransType, Amount, DateCreated, TransStatus, CDS_Number, Reference,ChargeCode) values('" & chargeDesc & "','Sales Tax','" & -1 * SalesTax & "',getdate(),'1','" & accid & "','" & TransRef & "','" & ChargeCode & "') "
                        End If
                        If IncomeTAXwithholding > 0 Then
                            InsertSTR = InsertSTR & " insert into CashTrans([Description], TransType, Amount, DateCreated, TransStatus, CDS_Number, Reference,ChargeCode) values('" & chargeDesc & "','Income tax withholding','" & IncomeTAXwithholding & "',getdate(),'1','" & accid & "','" & TransRef & "','" & ChargeCode & "') "
                        End If
                        If SalesTAXWithholding > 0 Then
                            InsertSTR = InsertSTR & " insert into CashTrans([Description], TransType, Amount, DateCreated, TransStatus, CDS_Number, Reference,ChargeCode) values('" & chargeDesc & "','Sales Tax Withholding','" & SalesTAXWithholding & "',getdate(),'1','" & accid & "','" & TransRef & "','" & ChargeCode & "') "
                        End If
                        If DiscountAmount > 0 Then
                            InsertSTR = InsertSTR & " insert into CashTrans([Description], TransType, Amount, DateCreated, TransStatus, CDS_Number, Reference,ChargeCode) values('" & chargeDesc & "','Discount','" & DiscountAmount & "',getdate(),'1','" & accid & "','" & TransRef & "','" & ChargeCode & "') "
                        End If
                        Using cmd2 = New SqlCommand(InsertSTR, con)
                            If con.State <> ConnectionState.Closed Then
                                con.Close()
                            End If
                            con.Open()
                            cmd2.ExecuteNonQuery()
                            con.Close()
                        End Using
                    End Using
                    Return Amount + SalesTax - SalesTAXWithholding - IncomeTAXwithholding + DiscountAmount
                End If
            Else
                Return 0
            End If
        End Using
    End Function
    Public Function transfercharges_REVERSAL(ByVal TranType As String, ByVal ParticipantType As String, ByVal quantity As Double, ByVal accid As String, ByVal TransRef As String) As Double
        Using cn = New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("connpath"))
            Dim ds As New DataSet
            Dim sqlStr As String = ""
            If quantity > 50 Then
                sqlStr = "DECLARE @MaxquantitySet numeric(18,4) SET @MaxquantitySet =(SELECT ISNULL(MAX(RangeFrom),0) FROM ParaCharge WHERE ChargeType='EWR transaction fee (Off/On Exchange)' and ChargeSUBType='EWR transaction fee (Off/On Exchange)')  SELECT CASE WHEN ChargeType=ChargeSUBType THEN ChargeType ELSE ChargeType+' - '+ ChargeSUBType END AS ChargeDesc,* FROM ParaCharge WHERE RangeFrom=@MaxquantitySet and ChargeType='EWR transaction fee (Off/On Exchange)' and ChargeSUBType='EWR transaction fee (Off/On Exchange)' ORDER BY ID DESC"
            Else
                sqlStr = "declare @ChargeType nvarchar(500)='EWR transaction fee (Off/On Exchange)' DECLARE @ChargeSubtype nvarchar(500) = 'EWR transaction fee (Off/On Exchange)' DECLARE @ParticipantType nvarchar(500)='" & ParticipantType & "' DECLARE @AccountID nvarchar(500) = '" & accid & "' SELECT CASE WHEN B.ChargeType=B.ChargeSUBType THEN B.ChargeType ELSE B.ChargeType+' - '+ B.ChargeSUBType END AS ChargeDesc,B.PercAmount,B.ChargeCode,D.ParticipantCode,B.ID,B.Indicator,B.UptoMax FROM (SELECT * FROM ParaCharge A WHERE A.ParticipantType=@ParticipantType AND A.ChargeType=@ChargeType  AND A.ChargeSUBType=@ChargeSubtype)B  JOIN ParaChargeParticipant D ON B.ChargeCode=D.ChargeCode WHERE D.ParticipantCode IN ('ALL',@AccountID) AND B.RangeFrom <= " & quantity & " and B.RangeTo >= " & quantity & " ORDER BY B.ID DESC"
            End If

            Dim MaintainType As String = "EWR transaction fee (Off/On Exchange)"
            Dim cmd = New SqlCommand(sqlStr, cn)
            Dim adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "para_othercharges")
            Dim Amount As Double = 0
            Dim chargeDesc As String = ""
            If (ds.Tables(0).Rows.Count > 0) Then
                Dim extraCharges As Double = 0
                If quantity >= 100 Then
                    extraCharges = 5500.0
                    Amount = extraCharges
                ElseIf quantity < 100 And quantity > 50 Then
                    extraCharges = ((quantity - 50) / 10) * 550
                    Amount = CDbl(ds.Tables(0).Rows(0).Item("PercAmount")) + extraCharges
                Else
                    Amount = CDbl(ds.Tables(0).Rows(0).Item("PercAmount"))
                End If


                'If ds.Tables(0).Rows(0).Item("indicator").ToString = "Flat" Then
                '    Amount = CDbl(ds.Tables(0).Rows(0).Item("PercAmount"))
                'Else
                '    Amount = (CDbl(ds.Tables(0).Rows(0).Item("PercAmount")) / 100) * quantity
                '    Dim limit As Double = CDbl(ds.Tables(0).Rows(0).Item("UptoMax"))
                '    If Amount > limit Then
                '        Amount = limit
                '    End If
                'End If
                Dim SalesTax As Double = getSALESTAX(Amount, "")
                Dim IncomeTAXwithholding As Double = getIncomeTAXwithholding(Amount + SalesTax, "")
                Dim SalesTAXWithholding As Double = getSalesTAXWithholding(SalesTax, "")
                Dim ChargeCode As String = ds.Tables(0).Rows(0).Item("ChargeCode").ToString
                Dim DiscountAmount As Double = getDISCOUNTAmount(accid, ChargeCode, Amount)

                If TranType.ToUpper = "ENQUIRE" Then
                    Return Amount + SalesTax - SalesTAXWithholding - IncomeTAXwithholding + DiscountAmount
                Else
                    chargeDesc = ds.Tables(0).Rows(0).Item("ChargeDesc").ToString
                    Using con = New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("connpath"))
                        Dim InsertSTR As String = ""
                        If Amount > 0 Then
                            InsertSTR = InsertSTR & " insert into CashTrans([Description], TransType, Amount, DateCreated, TransStatus, CDS_Number, Reference,ChargeCode) values('" & chargeDesc & "','" & MaintainType & " - Reversal','" & Amount & "',getdate(),'1','" & accid & "','" & TransRef & "','" & ChargeCode & "') "
                        End If
                        If SalesTax > 0 Then
                            InsertSTR = InsertSTR & " insert into CashTrans([Description], TransType, Amount, DateCreated, TransStatus, CDS_Number, Reference,ChargeCode) values('" & chargeDesc & "','Sales Tax - Reversal','" & SalesTax & "',getdate(),'1','" & accid & "','" & TransRef & "','" & ChargeCode & "') "
                        End If
                        If IncomeTAXwithholding > 0 Then
                            InsertSTR = InsertSTR & " insert into CashTrans([Description], TransType, Amount, DateCreated, TransStatus, CDS_Number, Reference,ChargeCode) values('" & chargeDesc & "','Income tax withholding - Reversal','" & -1 * IncomeTAXwithholding & "',getdate(),'1','" & accid & "','" & TransRef & "','" & ChargeCode & "') "
                        End If
                        If SalesTAXWithholding > 0 Then
                            InsertSTR = InsertSTR & " insert into CashTrans([Description], TransType, Amount, DateCreated, TransStatus, CDS_Number, Reference,ChargeCode) values('" & chargeDesc & "','Sales Tax Withholding - Reversal','" & -1 * SalesTAXWithholding & "',getdate(),'1','" & accid & "','" & TransRef & "','" & ChargeCode & "') "
                        End If
                        If DiscountAmount > 0 Then
                            InsertSTR = InsertSTR & " insert into CashTrans([Description], TransType, Amount, DateCreated, TransStatus, CDS_Number, Reference,ChargeCode) values('" & chargeDesc & "','Discount - Reversal','" & -1 * DiscountAmount & "',getdate(),'1','" & accid & "','" & TransRef & "','" & ChargeCode & "') "
                        End If
                        Using cmd2 = New SqlCommand(InsertSTR, con)
                            If con.State <> ConnectionState.Closed Then
                                con.Close()
                            End If
                            con.Open()
                            cmd2.ExecuteNonQuery()
                            con.Close()
                        End Using
                    End Using
                    Return Amount + SalesTax - SalesTAXWithholding - IncomeTAXwithholding + DiscountAmount
                End If
            Else
                Return 0
            End If
        End Using
    End Function
    <WebMethod>
    Public Function withdrawalcharges(ByVal TranType As String, ByVal ParticipantType As String, ByVal quantity As Double, ByVal accid As String, ByVal TransRef As String) As Double
        Using cn = New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("connpath"))
            Dim ds As New DataSet
            Dim sqlStr As String = ""
            If quantity > 50 Then
                sqlStr = "DECLARE @MaxquantitySet numeric(18,4) SET @MaxquantitySet =(SELECT ISNULL(MAX(RangeFrom),0) FROM ParaCharge WHERE ChargeType='EWR Closure Fee/Delivery Fee' and ChargeSUBType='EWR Closure Fee/Delivery Fee')  SELECT CASE WHEN ChargeType=ChargeSUBType THEN ChargeType ELSE ChargeType+' - '+ ChargeSUBType END AS ChargeDesc,* FROM ParaCharge WHERE RangeFrom=@MaxquantitySet and ChargeType='EWR Closure Fee/Delivery Fee' and ChargeSUBType='EWR Closure Fee/Delivery Fee' ORDER BY ID DESC"
            Else
                sqlStr = "declare @ChargeType nvarchar(500)='EWR Closure Fee/Delivery Fee' DECLARE @ChargeSubtype nvarchar(500) = 'EWR Closure Fee/Delivery Fee' DECLARE @ParticipantType nvarchar(500)='" & ParticipantType & "' DECLARE @AccountID nvarchar(500) = '" & accid & "' SELECT CASE WHEN B.ChargeType=B.ChargeSUBType THEN B.ChargeType ELSE B.ChargeType+' - '+ B.ChargeSUBType END AS ChargeDesc,B.PercAmount,B.ChargeCode,D.ParticipantCode,B.ID,B.Indicator,B.UptoMax FROM (SELECT * FROM ParaCharge A WHERE A.ParticipantType=@ParticipantType AND A.ChargeType=@ChargeType  AND A.ChargeSUBType=@ChargeSubtype)B  JOIN ParaChargeParticipant D ON B.ChargeCode=D.ChargeCode WHERE D.ParticipantCode IN ('ALL',@AccountID) AND B.RangeFrom <= " & quantity & " and B.RangeTo >= " & quantity & " ORDER BY B.ID DESC"
            End If
            Dim MaintainType As String = "EWR Closure Fee/Delivery Fee"
            Dim cmd = New SqlCommand(sqlStr, cn)
            Dim adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "para_othercharges")
            Dim Amount As Double = 0
            Dim chargeDesc As String = ""
            If (ds.Tables(0).Rows.Count > 0) Then
                Dim extraCharges As Double = 0
                If quantity >= 100 Then
                    extraCharges = 5500.0
                    Amount = extraCharges
                ElseIf quantity < 100 And quantity > 50 Then
                    extraCharges = ((quantity - 50) / 10) * 550
                    Amount = CDbl(ds.Tables(0).Rows(0).Item("PercAmount")) + extraCharges
                Else
                    Amount = CDbl(ds.Tables(0).Rows(0).Item("PercAmount"))
                End If

                'If ds.Tables(0).Rows(0).Item("indicator").ToString = "Flat" Then
                '    Amount = CDbl(ds.Tables(0).Rows(0).Item("PercAmount"))
                'Else
                '    Amount = (CDbl(ds.Tables(0).Rows(0).Item("PercAmount")) / 100) * quantity
                '    Dim limit As Double = CDbl(ds.Tables(0).Rows(0).Item("UptoMax"))
                '    If Amount > limit Then
                '        Amount = limit
                '    End If
                'End If
                Dim SalesTax As Double = getSALESTAX(Amount, "")
                Dim IncomeTAXwithholding As Double = getIncomeTAXwithholding(Amount + SalesTax, "")
                Dim SalesTAXWithholding As Double = getSalesTAXWithholding(SalesTax, "")
                Dim ChargeCode As String = ds.Tables(0).Rows(0).Item("ChargeCode").ToString
                Dim DiscountAmount As Double = getDISCOUNTAmount(accid, ChargeCode, Amount)

                If TranType.ToUpper = "ENQUIRE" Then
                    Return Amount + SalesTax - SalesTAXWithholding - IncomeTAXwithholding + DiscountAmount
                Else
                    chargeDesc = ds.Tables(0).Rows(0).Item("ChargeDesc").ToString
                    Using con = New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("connpath"))
                        Dim InsertSTR As String = ""
                        If Amount > 0 Then
                            InsertSTR = InsertSTR & " insert into CashTrans([Description], TransType, Amount, DateCreated, TransStatus, CDS_Number, Reference,ChargeCode) values('" & chargeDesc & "','" & MaintainType & "','" & -1 * Amount & "',getdate(),'1','" & accid & "','" & TransRef & "','" & ChargeCode & "') "
                        End If
                        If SalesTax > 0 Then
                            InsertSTR = InsertSTR & " insert into CashTrans([Description], TransType, Amount, DateCreated, TransStatus, CDS_Number, Reference,ChargeCode) values('" & chargeDesc & "','Sales Tax','" & -1 * SalesTax & "',getdate(),'1','" & accid & "','" & TransRef & "','" & ChargeCode & "') "
                        End If
                        If IncomeTAXwithholding > 0 Then
                            InsertSTR = InsertSTR & " insert into CashTrans([Description], TransType, Amount, DateCreated, TransStatus, CDS_Number, Reference,ChargeCode) values('" & chargeDesc & "','Income tax withholding','" & IncomeTAXwithholding & "',getdate(),'1','" & accid & "','" & TransRef & "','" & ChargeCode & "') "
                        End If
                        If SalesTAXWithholding > 0 Then
                            InsertSTR = InsertSTR & " insert into CashTrans([Description], TransType, Amount, DateCreated, TransStatus, CDS_Number, Reference,ChargeCode) values('" & chargeDesc & "','Sales Tax Withholding','" & SalesTAXWithholding & "',getdate(),'1','" & accid & "','" & TransRef & "','" & ChargeCode & "') "
                        End If
                        If DiscountAmount > 0 Then
                            InsertSTR = InsertSTR & " insert into CashTrans([Description], TransType, Amount, DateCreated, TransStatus, CDS_Number, Reference,ChargeCode) values('" & chargeDesc & "','Discount','" & DiscountAmount & "',getdate(),'1','" & accid & "','" & TransRef & "','" & ChargeCode & "') "
                        End If
                        Using cmd2 = New SqlCommand(InsertSTR, con)
                            If con.State <> ConnectionState.Closed Then
                                con.Close()
                            End If
                            con.Open()
                            cmd2.ExecuteNonQuery()
                            con.Close()
                        End Using
                    End Using
                    Return Amount + SalesTax - SalesTAXWithholding - IncomeTAXwithholding + DiscountAmount
                End If
            Else
                Return 0
            End If
        End Using
    End Function
    Public Function withdrawalcharges_REVERSAL(ByVal TranType As String, ByVal ParticipantType As String, ByVal quantity As Double, ByVal accid As String, ByVal TransRef As String) As Double
        Using cn = New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("connpath"))
            Dim ds As New DataSet
            Dim sqlStr As String = ""
            If quantity > 50 Then
                sqlStr = "DECLARE @MaxquantitySet numeric(18,4) SET @MaxquantitySet =(SELECT ISNULL(MAX(RangeFrom),0) FROM ParaCharge WHERE ChargeType='EWR Closure Fee/Delivery Fee' and ChargeSUBType='EWR Closure Fee/Delivery Fee')  SELECT CASE WHEN ChargeType=ChargeSUBType THEN ChargeType ELSE ChargeType+' - '+ ChargeSUBType END AS ChargeDesc,* FROM ParaCharge WHERE RangeFrom=@MaxquantitySet and ChargeType='EWR Closure Fee/Delivery Fee' and ChargeSUBType='EWR Closure Fee/Delivery Fee' ORDER BY ID DESC"
            Else
                sqlStr = "declare @ChargeType nvarchar(500)='EWR Closure Fee/Delivery Fee' DECLARE @ChargeSubtype nvarchar(500) = 'EWR Closure Fee/Delivery Fee' DECLARE @ParticipantType nvarchar(500)='" & ParticipantType & "' DECLARE @AccountID nvarchar(500) = '" & accid & "' SELECT CASE WHEN B.ChargeType=B.ChargeSUBType THEN B.ChargeType ELSE B.ChargeType+' - '+ B.ChargeSUBType END AS ChargeDesc,B.PercAmount,B.ChargeCode,D.ParticipantCode,B.ID,B.Indicator,B.UptoMax FROM (SELECT * FROM ParaCharge A WHERE A.ParticipantType=@ParticipantType AND A.ChargeType=@ChargeType  AND A.ChargeSUBType=@ChargeSubtype)B  JOIN ParaChargeParticipant D ON B.ChargeCode=D.ChargeCode WHERE D.ParticipantCode IN ('ALL',@AccountID) AND B.RangeFrom <= " & quantity & " and B.RangeTo >= " & quantity & " ORDER BY B.ID DESC"
            End If
            Dim MaintainType As String = "EWR Closure Fee/Delivery Fee"
            Dim cmd = New SqlCommand(sqlStr, cn)
            Dim adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "para_othercharges")
            Dim Amount As Double = 0
            Dim chargeDesc As String = ""
            If (ds.Tables(0).Rows.Count > 0) Then
                Dim extraCharges As Double = 0
                If quantity >= 100 Then
                    extraCharges = 5500.0
                    Amount = extraCharges
                ElseIf quantity < 100 And quantity > 50 Then
                    extraCharges = ((quantity - 50) / 10) * 550
                    Amount = CDbl(ds.Tables(0).Rows(0).Item("PercAmount")) + extraCharges
                Else
                    Amount = CDbl(ds.Tables(0).Rows(0).Item("PercAmount"))
                End If

                'If ds.Tables(0).Rows(0).Item("indicator").ToString = "Flat" Then
                '    Amount = CDbl(ds.Tables(0).Rows(0).Item("PercAmount"))
                'Else
                '    Amount = (CDbl(ds.Tables(0).Rows(0).Item("PercAmount")) / 100) * quantity
                '    Dim limit As Double = CDbl(ds.Tables(0).Rows(0).Item("UptoMax"))
                '    If Amount > limit Then
                '        Amount = limit
                '    End If
                'End If
                Dim SalesTax As Double = getSALESTAX(Amount, "")
                Dim IncomeTAXwithholding As Double = getIncomeTAXwithholding(Amount + SalesTax, "")
                Dim SalesTAXWithholding As Double = getSalesTAXWithholding(SalesTax, "")
                Dim ChargeCode As String = ds.Tables(0).Rows(0).Item("ChargeCode").ToString
                Dim DiscountAmount As Double = getDISCOUNTAmount(accid, ChargeCode, Amount)

                If TranType.ToUpper = "ENQUIRE" Then
                    Return Amount + SalesTax - SalesTAXWithholding - IncomeTAXwithholding + DiscountAmount
                Else
                    chargeDesc = ds.Tables(0).Rows(0).Item("ChargeDesc").ToString
                    Using con = New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("connpath"))
                        Dim InsertSTR As String = ""
                        If Amount > 0 Then
                            InsertSTR = InsertSTR & " insert into CashTrans([Description], TransType, Amount, DateCreated, TransStatus, CDS_Number, Reference,ChargeCode) values('" & chargeDesc & "','" & MaintainType & " - Reversal','" & Amount & "',getdate(),'1','" & accid & "','" & TransRef & "','" & ChargeCode & "') "
                        End If
                        If SalesTax > 0 Then
                            InsertSTR = InsertSTR & " insert into CashTrans([Description], TransType, Amount, DateCreated, TransStatus, CDS_Number, Reference,ChargeCode) values('" & chargeDesc & "','Sales Tax - Reversal','" & SalesTax & "',getdate(),'1','" & accid & "','" & TransRef & "','" & ChargeCode & "') "
                        End If
                        If IncomeTAXwithholding > 0 Then
                            InsertSTR = InsertSTR & " insert into CashTrans([Description], TransType, Amount, DateCreated, TransStatus, CDS_Number, Reference,ChargeCode) values('" & chargeDesc & "','Income tax withholding - Reversal','" & -1 * IncomeTAXwithholding & "',getdate(),'1','" & accid & "','" & TransRef & "','" & ChargeCode & "') "
                        End If
                        If SalesTAXWithholding > 0 Then
                            InsertSTR = InsertSTR & " insert into CashTrans([Description], TransType, Amount, DateCreated, TransStatus, CDS_Number, Reference,ChargeCode) values('" & chargeDesc & "','Sales Tax Withholding - Reversal','" & -1 * SalesTAXWithholding & "',getdate(),'1','" & accid & "','" & TransRef & "','" & ChargeCode & "') "
                        End If
                        If DiscountAmount > 0 Then
                            InsertSTR = InsertSTR & " insert into CashTrans([Description], TransType, Amount, DateCreated, TransStatus, CDS_Number, Reference,ChargeCode) values('" & chargeDesc & "','Discount - Reversal','" & -1 * DiscountAmount & "',getdate(),'1','" & accid & "','" & TransRef & "','" & ChargeCode & "') "
                        End If
                        Using cmd2 = New SqlCommand(InsertSTR, con)
                            If con.State <> ConnectionState.Closed Then
                                con.Close()
                            End If
                            con.Open()
                            cmd2.ExecuteNonQuery()
                            con.Close()
                        End Using
                    End Using
                    Return Amount + SalesTax - SalesTAXWithholding - IncomeTAXwithholding + DiscountAmount
                End If
            Else
                Return 0
            End If
        End Using
    End Function
    Public Function warehouseAccreditationCharges(ByVal TranType As String, ByVal ParticipantType As String, ByVal AccreditationFeeType As String, ByVal StorageCapacity As Double, ByVal accid As String, ByVal TransRef As String) As Double
        Using cn = New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("connpath"))
            Dim ds As New DataSet
            Dim sqlStr As String = ""

            sqlStr = "declare @ChargeType nvarchar(500)='Warehouse Accreditation Fee' DECLARE @ChargeSubtype nvarchar(500) = '" & AccreditationFeeType & "' DECLARE @ParticipantType nvarchar(500)='" & ParticipantType & "' DECLARE @AccountID nvarchar(500) = '" & accid & "' SELECT CASE WHEN B.ChargeType=B.ChargeSUBType THEN B.ChargeType ELSE B.ChargeType+' - '+ B.ChargeSUBType END AS ChargeDesc,B.PercAmount,B.ChargeCode,D.ParticipantCode,B.ID,B.Indicator FROM (SELECT * FROM ParaCharge A WHERE A.ParticipantType=@ParticipantType AND A.ChargeType=@ChargeType  AND A.ChargeSUBType=@ChargeSubtype)B  JOIN ParaChargeParticipant D ON B.ChargeCode=D.ChargeCode WHERE D.ParticipantCode IN ('ALL',@AccountID) AND B.RangeFrom <= " & StorageCapacity & " and B.RangeTo >= " & StorageCapacity & " ORDER BY B.ID DESC"
            Dim MaintainType As String = AccreditationFeeType
            Dim cmd = New SqlCommand(sqlStr, cn)
            Dim adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "para_othercharges")
            Dim Amount As Double = 0
            Dim chargeDesc As String = ""
            If (ds.Tables(0).Rows.Count > 0) Then
                Amount = CDbl(ds.Tables(0).Rows(0).Item("PercAmount"))
                Dim SalesTax As Double = getSALESTAX(Amount, "")
                Dim IncomeTAXwithholding As Double = getIncomeTAXwithholding(Amount + SalesTax, "")
                Dim SalesTAXWithholding As Double = getSalesTAXWithholding(SalesTax, "")
                Dim ChargeCode As String = ds.Tables(0).Rows(0).Item("ChargeCode").ToString
                Dim DiscountAmount As Double = getDISCOUNTAmount(accid, ChargeCode, Amount)

                If TranType.ToUpper = "ENQUIRE" Then
                    Return Amount + SalesTax - SalesTAXWithholding - IncomeTAXwithholding + DiscountAmount
                Else
                    chargeDesc = ds.Tables(0).Rows(0).Item("ChargeDesc").ToString
                    Using con = New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("connpath"))
                        Dim InsertSTR As String = ""
                        If Amount > 0 Then
                            InsertSTR = InsertSTR & " insert into CashTrans([Description], TransType, Amount, DateCreated, TransStatus, CDS_Number, Reference,ChargeCode) values('" & chargeDesc & "','" & MaintainType & "','" & -1 * Amount & "',getdate(),'1','" & accid & "','" & TransRef & "','" & ChargeCode & "') "
                        End If
                        If SalesTax > 0 Then
                            InsertSTR = InsertSTR & " insert into CashTrans([Description], TransType, Amount, DateCreated, TransStatus, CDS_Number, Reference,ChargeCode) values('" & chargeDesc & "','Sales Tax','" & -1 * SalesTax & "',getdate(),'1','" & accid & "','" & TransRef & "','" & ChargeCode & "') "
                        End If
                        If IncomeTAXwithholding > 0 Then
                            InsertSTR = InsertSTR & " insert into CashTrans([Description], TransType, Amount, DateCreated, TransStatus, CDS_Number, Reference,ChargeCode) values('" & chargeDesc & "','Income tax withholding','" & IncomeTAXwithholding & "',getdate(),'1','" & accid & "','" & TransRef & "','" & ChargeCode & "') "
                        End If
                        If SalesTAXWithholding > 0 Then
                            InsertSTR = InsertSTR & " insert into CashTrans([Description], TransType, Amount, DateCreated, TransStatus, CDS_Number, Reference,ChargeCode) values('" & chargeDesc & "','Sales Tax Withholding','" & SalesTAXWithholding & "',getdate(),'1','" & accid & "','" & TransRef & "','" & ChargeCode & "') "
                        End If
                        If DiscountAmount > 0 Then
                            InsertSTR = InsertSTR & " insert into CashTrans([Description], TransType, Amount, DateCreated, TransStatus, CDS_Number, Reference,ChargeCode) values('" & chargeDesc & "','Discount','" & DiscountAmount & "',getdate(),'1','" & accid & "','" & TransRef & "','" & ChargeCode & "') "
                        End If
                        Using cmd2 = New SqlCommand(InsertSTR, con)
                            If con.State <> ConnectionState.Closed Then
                                con.Close()
                            End If
                            con.Open()
                            cmd2.ExecuteNonQuery()
                            con.Close()
                        End Using
                    End Using
                    Return Amount + SalesTax - SalesTAXWithholding - IncomeTAXwithholding + DiscountAmount
                End If
            Else
                Return 0
            End If
        End Using
    End Function
    Public Function othercharges(ByVal TranType As String, ByVal ParticipantType As String, ByVal chargename As String, ByVal accid As String, ByVal TransRef As String, ByVal RangeApplied As String, ByVal TotalValueQuntity As Double) As Double
        Using cn = New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("connpath"))
            Dim ds As New DataSet
            Dim sqlStr As String = ""
            If RangeApplied = "Yes" Then
                sqlStr = "declare @ChargeType nvarchar(500)='Additional Fee (Other)' DECLARE @ChargeSubtype nvarchar(500) = '" & chargename & "' DECLARE @ParticipantType nvarchar(500)='" & ParticipantType & "' DECLARE @AccountID nvarchar(500) = '" & accid & "' SELECT CASE WHEN B.ChargeType=B.ChargeSUBType THEN B.ChargeType ELSE B.ChargeType+' - '+ B.ChargeSUBType END AS ChargeDesc,B.PercAmount,B.ChargeCode,D.ParticipantCode,B.indicator,B.ID,B.UptoMax FROM (SELECT * FROM ParaCharge A WHERE A.ParticipantType=@ParticipantType AND A.ChargeType=@ChargeType  AND A.ChargeSUBType=@ChargeSubtype)B  JOIN ParaChargeParticipant D ON B.ChargeCode=D.ChargeCode WHERE D.ParticipantCode IN ('ALL',@AccountID) AND B.RangeFrom <= " & TotalValueQuntity & " and B.RangeTo >= " & TotalValueQuntity & " ORDER BY B.ID DESC"
            Else
                sqlStr = "declare @ChargeType nvarchar(500)='Additional Fee (Other)' DECLARE @ChargeSubtype nvarchar(500) = '" & chargename & "' DECLARE @ParticipantType nvarchar(500)='" & ParticipantType & "' DECLARE @AccountID nvarchar(500) = '" & accid & "' SELECT CASE WHEN B.ChargeType=B.ChargeSUBType THEN B.ChargeType ELSE B.ChargeType+' - '+ B.ChargeSUBType END AS ChargeDesc,B.PercAmount,B.ChargeCode,D.ParticipantCode,B.indicator,B.ID,B.UptoMax FROM (SELECT * FROM ParaCharge A WHERE A.ParticipantType=@ParticipantType AND A.ChargeType=@ChargeType  AND A.ChargeSUBType=@ChargeSubtype)B  JOIN ParaChargeParticipant D ON B.ChargeCode=D.ChargeCode WHERE D.ParticipantCode IN ('ALL',@AccountID) ORDER BY B.ID DESC"
            End If
            Dim MaintainType As String = chargename
            Dim cmd = New SqlCommand(sqlStr, cn)
            Dim adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "para_othercharges")
            Dim Amount As Double = 0
            Dim chargeDesc As String = ""
            If (ds.Tables(0).Rows.Count > 0) Then
                If ds.Tables(0).Rows(0).Item("indicator").ToString = "Flat" Then
                    Amount = CDbl(ds.Tables(0).Rows(0).Item("PercAmount"))
                Else
                    Amount = (CDbl(ds.Tables(0).Rows(0).Item("PercAmount")) / 100) * TotalValueQuntity
                    Dim limit As Double = CDbl(ds.Tables(0).Rows(0).Item("UptoMax"))
                    If Amount > limit Then
                        Amount = limit
                    End If
                End If
                Dim SalesTax As Double = getSALESTAX(Amount, "")
                Dim IncomeTAXwithholding As Double = getIncomeTAXwithholding(Amount + SalesTax, "")
                Dim SalesTAXWithholding As Double = getSalesTAXWithholding(SalesTax, "")
                Dim ChargeCode As String = ds.Tables(0).Rows(0).Item("ChargeCode").ToString
                Dim DiscountAmount As Double = getDISCOUNTAmount(accid, ChargeCode, Amount)

                If TranType.ToUpper = "ENQUIRE" Then
                    Return Amount + SalesTax - SalesTAXWithholding - IncomeTAXwithholding + DiscountAmount
                Else
                    chargeDesc = ds.Tables(0).Rows(0).Item("ChargeDesc").ToString
                    Using con = New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("connpath"))
                        Dim InsertSTR As String = ""
                        If Amount > 0 Then
                            InsertSTR = InsertSTR & " insert into CashTrans([Description], TransType, Amount, DateCreated, TransStatus, CDS_Number, Reference,ChargeCode) values('" & chargeDesc & "','" & MaintainType & "','" & -1 * Amount & "',getdate(),'1','" & accid & "','" & TransRef & "','" & ChargeCode & "') "
                        End If
                        If SalesTax > 0 Then
                            InsertSTR = InsertSTR & " insert into CashTrans([Description], TransType, Amount, DateCreated, TransStatus, CDS_Number, Reference,ChargeCode) values('" & chargeDesc & "','Sales Tax','" & -1 * SalesTax & "',getdate(),'1','" & accid & "','" & TransRef & "','" & ChargeCode & "') "
                        End If
                        If IncomeTAXwithholding > 0 Then
                            InsertSTR = InsertSTR & " insert into CashTrans([Description], TransType, Amount, DateCreated, TransStatus, CDS_Number, Reference,ChargeCode) values('" & chargeDesc & "','Income tax withholding','" & IncomeTAXwithholding & "',getdate(),'1','" & accid & "','" & TransRef & "','" & ChargeCode & "') "
                        End If
                        If SalesTAXWithholding > 0 Then
                            InsertSTR = InsertSTR & " insert into CashTrans([Description], TransType, Amount, DateCreated, TransStatus, CDS_Number, Reference,ChargeCode) values('" & chargeDesc & "','Sales Tax Withholding','" & SalesTAXWithholding & "',getdate(),'1','" & accid & "','" & TransRef & "','" & ChargeCode & "') "
                        End If
                        If DiscountAmount > 0 Then
                            InsertSTR = InsertSTR & " insert into CashTrans([Description], TransType, Amount, DateCreated, TransStatus, CDS_Number, Reference,ChargeCode) values('" & chargeDesc & "','Discount','" & DiscountAmount & "',getdate(),'1','" & accid & "','" & TransRef & "','" & ChargeCode & "') "
                        End If
                        Using cmd2 = New SqlCommand(InsertSTR, con)
                            If con.State <> ConnectionState.Closed Then
                                con.Close()
                            End If
                            con.Open()
                            cmd2.ExecuteNonQuery()
                            con.Close()
                        End Using
                    End Using
                    Return Amount + SalesTax - SalesTAXWithholding - IncomeTAXwithholding + DiscountAmount
                End If
            Else
                Return 0
            End If
        End Using
    End Function
    Public Function getSALESTAX(ByVal ChargeTotalAmount As Double, ByVal Location As String) As Double
        Using cn = New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("connpath"))
            Dim ds As New DataSet
            Dim sqlStr As String = ""
            If Location <> "" Then
                sqlStr = "select * from para_taxes where [location]='" & Location & "' order by ID DESC"
            Else
                sqlStr = "select * from para_taxes order by ID DESC"
            End If
            Dim cmd = New SqlCommand(sqlStr, cn)
            Dim adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "para_taxes")
            Dim Amount As Double = 0
            If (ds.Tables(0).Rows.Count > 0) Then
                Amount = (CDbl(ds.Tables(0).Rows(0).Item("SalesTax")) / 100) * ChargeTotalAmount
                Return Amount
            Else
                Return 0
            End If
        End Using
    End Function
    Public Function getIncomeTAXwithholding(ByVal ChargeTotalAmount As Double, ByVal Location As String) As Double
        Using cn = New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("connpath"))
            Dim ds As New DataSet
            Dim sqlStr As String = ""
            If Location <> "" Then
                sqlStr = "select * from para_taxes where [location]='" & Location & "' order by ID DESC"
            Else
                sqlStr = "select * from para_taxes order by ID DESC"
            End If
            Dim cmd = New SqlCommand(sqlStr, cn)
            Dim adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "para_taxes")
            Dim Amount As Double = 0
            If (ds.Tables(0).Rows.Count > 0) Then
                Amount = (CDbl(ds.Tables(0).Rows(0).Item("IncomeTaxWithholding")) / 100) * ChargeTotalAmount
                Return Amount
            Else
                Return 0
            End If
        End Using
    End Function
    Public Function getSalesTAXWithholding(ByVal ChargeTotalAmount As Double, ByVal Location As String) As Double
        Using cn = New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("connpath"))
            Dim ds As New DataSet
            Dim sqlStr As String = ""
            If Location <> "" Then
                sqlStr = "select * from para_taxes where [location]='" & Location & "' order by ID DESC"
            Else
                sqlStr = "select * from para_taxes order by ID DESC"
            End If
            Dim cmd = New SqlCommand(sqlStr, cn)
            Dim adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "para_taxes")
            Dim Amount As Double = 0
            If (ds.Tables(0).Rows.Count > 0) Then
                Amount = (CDbl(ds.Tables(0).Rows(0).Item("SalesTaxWithholding")) / 100) * ChargeTotalAmount
                Return Amount
            Else
                Return 0
            End If
        End Using
    End Function
    Public Function getDISCOUNTAmount(ByVal Account As String, ByVal ChargeCode As String, ByVal ChargeTotalAmount As Double) As Double
        Using cn = New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("connpath"))
            Dim ds As New DataSet
            Dim sqlStr As String = " DECLARE @ChargeCode nvarchar(500)='" & ChargeCode & "' DECLARE @AccountID nvarchar(500)='" & Account & "' "
            sqlStr = sqlStr & " SELECT A.PercAmount,A.Indicator FROM ParaChargeDiscounts A JOIN ParaChargeDiscountsParticipant B ON A.ChargeCode=B.ChargeCode AND A.DiscountCode=B.DiscountCode WHERE B.ParticipantCode IN ('ALL',@AccountID) AND A.ChargeCode=@ChargeCode AND A.ExpiryDate>convert(date,getdate())"
            Dim cmd = New SqlCommand(sqlStr, cn)
            Dim adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "para_taxes")
            Dim Amount As Double = 0
            If (ds.Tables(0).Rows.Count > 0) Then
                If ds.Tables(0).Rows(0).Item("Indicator").ToString = "Flat" Then
                    Amount = CDbl(ds.Tables(0).Rows(0).Item("PercAmount"))
                Else
                    Amount = (CDbl(ds.Tables(0).Rows(0).Item("PercAmount")) / 100) * ChargeTotalAmount
                End If
                Return Amount
            Else
                Return 0
            End If
        End Using
    End Function
    Public Function getEWRBAL(ByVal EWRNo As String, ByVal HolderNo As String) As Double
        Using cn = New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("connpath"))
            Dim ds As New DataSet
            Dim sqlStr As String = ""
            sqlStr = "declare @EWRNo nvarchar(500)='" & EWRNo & "' DECLARE @HolderNo nvarchar(500) = '" & HolderNo & "' SELECT isnull(SUM(A.Amount),0)*-1 AS Bal FROM CashTransComb A WHERE A.TransType<>'Bank Overdraft' and A.CDS_Number=@HolderNo AND A.Reference=@EWRNo"
            Dim cmd = New SqlCommand(sqlStr, cn)
            Dim adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "para_othercharges")
            Dim Amount As Double = 0
            If (ds.Tables(0).Rows.Count > 0) Then
                Return CDbl(ds.Tables(0).Rows(0).Item("Bal"))
            Else
                Return 0
            End If
        End Using
    End Function
    Public Function getEWRBAL_NO_LOAN(ByVal EWRNo As String, ByVal HolderNo As String) As Double
        Using cn = New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("connpath"))
            Dim ds As New DataSet
            Dim sqlStr As String = ""
            sqlStr = "declare @EWRNo nvarchar(500)='" & EWRNo & "' DECLARE @HolderNo nvarchar(500) = '" & HolderNo & "' SELECT isnull(SUM(A.Amount),0)*-1 AS Bal FROM CashTransComb A WHERE A.TransType NOT IN ('Bank Overdraft','Loan Interest','Collateralized volume - Pledged EWR Fee','Service Fee') and A.CDS_Number=@HolderNo AND A.Reference=@EWRNo"
            Dim cmd = New SqlCommand(sqlStr, cn)
            Dim adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "para_othercharges")
            Dim Amount As Double = 0
            If (ds.Tables(0).Rows.Count > 0) Then
                Return CDbl(ds.Tables(0).Rows(0).Item("Bal"))
            Else
                Return 0
            End If
        End Using
    End Function
    Public Function getEWRBAL_LOAN(ByVal EWRNo As String, ByVal HolderNo As String) As Double
        Using cn = New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("connpath"))
            Dim ds As New DataSet
            Dim sqlStr As String = ""
            sqlStr = "declare @EWRNo nvarchar(500)='" & EWRNo & "' DECLARE @HolderNo nvarchar(500) = '" & HolderNo & "' SELECT isnull(SUM(A.Amount),0)*-1 AS Bal FROM CashTransComb A WHERE A.TransType IN ('Bank Overdraft','Loan Interest','Collateralized volume - Pledged EWR Fee','Service Fee') and A.CDS_Number=@HolderNo AND A.Reference=@EWRNo"
            Dim cmd = New SqlCommand(sqlStr, cn)
            Dim adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "para_othercharges")
            Dim Amount As Double = 0
            If (ds.Tables(0).Rows.Count > 0) Then
                Return CDbl(ds.Tables(0).Rows(0).Item("Bal"))
            Else
                Return 0
            End If
        End Using
    End Function
    Public Function getEWRBAL_LOANcharges(ByVal EWRNo As String, ByVal HolderNo As String) As Double
        Using cn = New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("connpath"))
            Dim ds As New DataSet
            Dim sqlStr As String = ""
            sqlStr = "declare @EWRNo nvarchar(500)='" & EWRNo & "' DECLARE @HolderNo nvarchar(500) = '" & HolderNo & "' SELECT isnull(SUM(A.Amount),0)*-1 AS Bal FROM CashTransComb A WHERE A.TransType IN ('Loan Interest','Collateralized volume - Pledged EWR Fee','Service Fee') and A.CDS_Number=@HolderNo AND A.Reference=@EWRNo"
            Dim cmd = New SqlCommand(sqlStr, cn)
            Dim adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "para_othercharges")
            Dim Amount As Double = 0
            If (ds.Tables(0).Rows.Count > 0) Then
                Return CDbl(ds.Tables(0).Rows(0).Item("Bal"))
            Else
                Return 0
            End If
        End Using
    End Function
    Public Function getholderbal(ByVal HolderNo As String, ByVal warehouse As String) As Double
        Using cn = New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("connpath"))
            Dim ds As New DataSet
            Dim sqlStr As String = ""
            sqlStr = "DECLARE @HolderNo nvarchar(500) = '" & HolderNo & "'  declare @warehouse nvarchar(50)='" + warehouse + "' SELECT isnull(SUM(A.Amount),0)*-1 AS Bal FROM CashTransComb_NEW A WHERE A.CDS_Number=@HolderNo and isnull(a.reference,'') not in (select receiptNo from wr where holder=@HolderNo)  and warehouse=@warehouse"
            Dim cmd = New SqlCommand(sqlStr, cn)
            Dim adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "para_othercharges")
            Dim Amount As Double = 0
            If (ds.Tables(0).Rows.Count > 0) Then
                Return CDbl(ds.Tables(0).Rows(0).Item("Bal"))
            Else
                Return 0
            End If
        End Using
    End Function
    Public Function accountOpeningExists(ByVal HolderNo As String) As Boolean
        Using cn = New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("connpath"))
            Dim ds As New DataSet
            Dim sqlStr As String = ""
            sqlStr = "DECLARE @HolderNo nvarchar(500) = '" & HolderNo & "' SELECT top 1 A.* FROM CashTrans A WHERE A.CDS_Number=@HolderNo AND A.[Description] LIKE '%Account Opening%'"
            Dim cmd = New SqlCommand(sqlStr, cn)
            Dim adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "CashTrans")
            Dim Amount As Double = 0
            If (ds.Tables(0).Rows.Count > 0) Then
                Return True
            Else
                Return False
            End If
        End Using
    End Function

    <WebMethod>
    Public Function Splitcharges(ByVal TranType As String, ByVal ParticipantType As String, ByVal quantity As Double, ByVal accid As String, ByVal TransRef As String) As Double
        Using cn = New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("connpath"))
            Dim ds As New DataSet
            Dim sqlStr As String = ""
            If quantity > 50 Then
                sqlStr = "DECLARE @MaxquantitySet numeric(18,4) SET @MaxquantitySet =(SELECT ISNULL(MAX(RangeFrom),0) FROM ParaCharge WHERE ChargeType='EWR Split Fee' and ChargeSUBType='EWR Split Fee')  SELECT CASE WHEN ChargeType=ChargeSUBType THEN ChargeType ELSE ChargeType+' - '+ ChargeSUBType END AS ChargeDesc,* FROM ParaCharge WHERE RangeFrom=@MaxquantitySet and ChargeType='EWR Split Fee' and ChargeSUBType='EWR Split Fee' ORDER BY ID DESC"
            Else
                sqlStr = "declare @ChargeType nvarchar(500)='EWR Split Fee' DECLARE @ChargeSubtype nvarchar(500) = 'EWR Split Fee' DECLARE @ParticipantType nvarchar(500)='" & ParticipantType & "' DECLARE @AccountID nvarchar(500) = '" & accid & "' SELECT CASE WHEN B.ChargeType=B.ChargeSUBType THEN B.ChargeType ELSE B.ChargeType+' - '+ B.ChargeSUBType END AS ChargeDesc,B.PercAmount,B.ChargeCode,D.ParticipantCode,B.ID,B.Indicator,B.UptoMax FROM (SELECT * FROM ParaCharge A WHERE A.ParticipantType=@ParticipantType AND A.ChargeType=@ChargeType  AND A.ChargeSUBType=@ChargeSubtype)B  JOIN ParaChargeParticipant D ON B.ChargeCode=D.ChargeCode WHERE D.ParticipantCode IN ('ALL',@AccountID) AND B.RangeFrom <= " & quantity & " and B.RangeTo >= " & quantity & " ORDER BY B.ID DESC"
            End If

            Dim MaintainType As String = "EWR Split Fee"
            Dim cmd = New SqlCommand(sqlStr, cn)
            Dim adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "para_othercharges")
            Dim Amount As Double = 0
            Dim chargeDesc As String = ""
            If (ds.Tables(0).Rows.Count > 0) Then
                Dim extraCharges As Double = 0
                If quantity >= 100 Then
                    extraCharges = 5500.0
                    Amount = extraCharges
                ElseIf quantity < 100 And quantity > 50 Then
                    extraCharges = ((quantity - 50) / 10) * 550
                    Amount = CDbl(ds.Tables(0).Rows(0).Item("PercAmount")) + extraCharges
                Else
                    Amount = CDbl(ds.Tables(0).Rows(0).Item("PercAmount"))
                End If


                'If ds.Tables(0).Rows(0).Item("indicator").ToString = "Flat" Then
                '    Amount = CDbl(ds.Tables(0).Rows(0).Item("PercAmount"))
                'Else
                '    Amount = (CDbl(ds.Tables(0).Rows(0).Item("PercAmount")) / 100) * quantity
                '    Dim limit As Double = CDbl(ds.Tables(0).Rows(0).Item("UptoMax"))
                '    If Amount > limit Then
                '        Amount = limit
                '    End If
                'End If
                Dim SalesTax As Double = getSALESTAX(Amount, "")
                Dim IncomeTAXwithholding As Double = getIncomeTAXwithholding(Amount + SalesTax, "")
                Dim SalesTAXWithholding As Double = getSalesTAXWithholding(SalesTax, "")
                Dim ChargeCode As String = ds.Tables(0).Rows(0).Item("ChargeCode").ToString
                Dim DiscountAmount As Double = getDISCOUNTAmount(accid, ChargeCode, Amount)

                If TranType.ToUpper = "ENQUIRE" Then
                    Return Amount + SalesTax - SalesTAXWithholding - IncomeTAXwithholding + DiscountAmount
                Else
                    chargeDesc = ds.Tables(0).Rows(0).Item("ChargeDesc").ToString
                    Using con = New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("connpath"))
                        Dim InsertSTR As String = ""
                        If Amount > 0 Then
                            InsertSTR = InsertSTR & " insert into CashTrans([Description], TransType, Amount, DateCreated, TransStatus, CDS_Number, Reference,ChargeCode) values('" & chargeDesc & "','" & MaintainType & "','" & -1 * Amount & "',getdate(),'1','" & accid & "','" & TransRef & "','" & ChargeCode & "') "
                        End If
                        If SalesTax > 0 Then
                            InsertSTR = InsertSTR & " insert into CashTrans([Description], TransType, Amount, DateCreated, TransStatus, CDS_Number, Reference,ChargeCode) values('" & chargeDesc & "','Sales Tax','" & -1 * SalesTax & "',getdate(),'1','" & accid & "','" & TransRef & "','" & ChargeCode & "') "
                        End If
                        If IncomeTAXwithholding > 0 Then
                            InsertSTR = InsertSTR & " insert into CashTrans([Description], TransType, Amount, DateCreated, TransStatus, CDS_Number, Reference,ChargeCode) values('" & chargeDesc & "','Income tax withholding','" & IncomeTAXwithholding & "',getdate(),'1','" & accid & "','" & TransRef & "','" & ChargeCode & "') "
                        End If
                        If SalesTAXWithholding > 0 Then
                            InsertSTR = InsertSTR & " insert into CashTrans([Description], TransType, Amount, DateCreated, TransStatus, CDS_Number, Reference,ChargeCode) values('" & chargeDesc & "','Sales Tax Withholding','" & SalesTAXWithholding & "',getdate(),'1','" & accid & "','" & TransRef & "','" & ChargeCode & "') "
                        End If
                        If DiscountAmount > 0 Then
                            InsertSTR = InsertSTR & " insert into CashTrans([Description], TransType, Amount, DateCreated, TransStatus, CDS_Number, Reference,ChargeCode) values('" & chargeDesc & "','Discount','" & DiscountAmount & "',getdate(),'1','" & accid & "','" & TransRef & "','" & ChargeCode & "') "
                        End If
                        Using cmd2 = New SqlCommand(InsertSTR, con)
                            If con.State <> ConnectionState.Closed Then
                                con.Close()
                            End If
                            con.Open()
                            cmd2.ExecuteNonQuery()
                            con.Close()
                        End Using
                    End Using
                    Return Amount + SalesTax - SalesTAXWithholding - IncomeTAXwithholding + DiscountAmount
                End If
            Else
                Return 0
            End If
        End Using
    End Function
    Public Function Splitcharges_REVERSAL(ByVal TranType As String, ByVal ParticipantType As String, ByVal quantity As Double, ByVal accid As String, ByVal TransRef As String) As Double
        Using cn = New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("connpath"))
            Dim ds As New DataSet
            Dim sqlStr As String = ""
            If quantity > 50 Then
                sqlStr = "DECLARE @MaxquantitySet numeric(18,4) SET @MaxquantitySet =(SELECT ISNULL(MAX(RangeFrom),0) FROM ParaCharge WHERE ChargeType='EWR Split Fee' and ChargeSUBType='EWR Split Fee')  SELECT CASE WHEN ChargeType=ChargeSUBType THEN ChargeType ELSE ChargeType+' - '+ ChargeSUBType END AS ChargeDesc,* FROM ParaCharge WHERE RangeFrom=@MaxquantitySet and ChargeType='EWR Split Fee' and ChargeSUBType='EWR Split Fee' ORDER BY ID DESC"
            Else
                sqlStr = "declare @ChargeType nvarchar(500)='EWR Split Fee' DECLARE @ChargeSubtype nvarchar(500) = 'EWR Split Fee' DECLARE @ParticipantType nvarchar(500)='" & ParticipantType & "' DECLARE @AccountID nvarchar(500) = '" & accid & "' SELECT CASE WHEN B.ChargeType=B.ChargeSUBType THEN B.ChargeType ELSE B.ChargeType+' - '+ B.ChargeSUBType END AS ChargeDesc,B.PercAmount,B.ChargeCode,D.ParticipantCode,B.ID,B.Indicator,B.UptoMax FROM (SELECT * FROM ParaCharge A WHERE A.ParticipantType=@ParticipantType AND A.ChargeType=@ChargeType  AND A.ChargeSUBType=@ChargeSubtype)B  JOIN ParaChargeParticipant D ON B.ChargeCode=D.ChargeCode WHERE D.ParticipantCode IN ('ALL',@AccountID) AND B.RangeFrom <= " & quantity & " and B.RangeTo >= " & quantity & " ORDER BY B.ID DESC"
            End If

            Dim MaintainType As String = "EWR Split Fee"
            Dim cmd = New SqlCommand(sqlStr, cn)
            Dim adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "para_othercharges")
            Dim Amount As Double = 0
            Dim chargeDesc As String = ""
            If (ds.Tables(0).Rows.Count > 0) Then
                Dim extraCharges As Double = 0
                If quantity >= 100 Then
                    extraCharges = 5500.0
                    Amount = extraCharges
                ElseIf quantity < 100 And quantity > 50 Then
                    extraCharges = ((quantity - 50) / 10) * 550
                    Amount = CDbl(ds.Tables(0).Rows(0).Item("PercAmount")) + extraCharges
                Else
                    Amount = CDbl(ds.Tables(0).Rows(0).Item("PercAmount"))
                End If


                'If ds.Tables(0).Rows(0).Item("indicator").ToString = "Flat" Then
                '    Amount = CDbl(ds.Tables(0).Rows(0).Item("PercAmount"))
                'Else
                '    Amount = (CDbl(ds.Tables(0).Rows(0).Item("PercAmount")) / 100) * quantity
                '    Dim limit As Double = CDbl(ds.Tables(0).Rows(0).Item("UptoMax"))
                '    If Amount > limit Then
                '        Amount = limit
                '    End If
                'End If
                Dim SalesTax As Double = getSALESTAX(Amount, "")
                Dim IncomeTAXwithholding As Double = getIncomeTAXwithholding(Amount + SalesTax, "")
                Dim SalesTAXWithholding As Double = getSalesTAXWithholding(SalesTax, "")
                Dim ChargeCode As String = ds.Tables(0).Rows(0).Item("ChargeCode").ToString
                Dim DiscountAmount As Double = getDISCOUNTAmount(accid, ChargeCode, Amount)

                If TranType.ToUpper = "ENQUIRE" Then
                    Return Amount + SalesTax - SalesTAXWithholding - IncomeTAXwithholding + DiscountAmount
                Else
                    chargeDesc = ds.Tables(0).Rows(0).Item("ChargeDesc").ToString
                    Using con = New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("connpath"))
                        Dim InsertSTR As String = ""
                        If Amount > 0 Then
                            InsertSTR = InsertSTR & " insert into CashTrans([Description], TransType, Amount, DateCreated, TransStatus, CDS_Number, Reference,ChargeCode) values('" & chargeDesc & "','" & MaintainType & " - Reversal','" & Amount & "',getdate(),'1','" & accid & "','" & TransRef & "','" & ChargeCode & "') "
                        End If
                        If SalesTax > 0 Then
                            InsertSTR = InsertSTR & " insert into CashTrans([Description], TransType, Amount, DateCreated, TransStatus, CDS_Number, Reference,ChargeCode) values('" & chargeDesc & "','Sales Tax - Reversal','" & SalesTax & "',getdate(),'1','" & accid & "','" & TransRef & "','" & ChargeCode & "') "
                        End If
                        If IncomeTAXwithholding > 0 Then
                            InsertSTR = InsertSTR & " insert into CashTrans([Description], TransType, Amount, DateCreated, TransStatus, CDS_Number, Reference,ChargeCode) values('" & chargeDesc & "','Income tax withholding - Reversal','" & -1 * IncomeTAXwithholding & "',getdate(),'1','" & accid & "','" & TransRef & "','" & ChargeCode & "') "
                        End If
                        If SalesTAXWithholding > 0 Then
                            InsertSTR = InsertSTR & " insert into CashTrans([Description], TransType, Amount, DateCreated, TransStatus, CDS_Number, Reference,ChargeCode) values('" & chargeDesc & "','Sales Tax Withholding - Reversal','" & -1 * SalesTAXWithholding & "',getdate(),'1','" & accid & "','" & TransRef & "','" & ChargeCode & "') "
                        End If
                        If DiscountAmount > 0 Then
                            InsertSTR = InsertSTR & " insert into CashTrans([Description], TransType, Amount, DateCreated, TransStatus, CDS_Number, Reference,ChargeCode) values('" & chargeDesc & "','Discount - Reversal','" & -1 * DiscountAmount & "',getdate(),'1','" & accid & "','" & TransRef & "','" & ChargeCode & "') "
                        End If
                        Using cmd2 = New SqlCommand(InsertSTR, con)
                            If con.State <> ConnectionState.Closed Then
                                con.Close()
                            End If
                            con.Open()
                            cmd2.ExecuteNonQuery()
                            con.Close()
                        End Using
                    End Using
                    Return Amount + SalesTax - SalesTAXWithholding - IncomeTAXwithholding + DiscountAmount
                End If
            Else
                Return 0
            End If
        End Using
    End Function
    Public Function AccountExempted(ByVal AccountNumber As String) As Boolean
        Using cn = New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("connpath"))
            Dim ds As New DataSet
            Dim sqlStr As String = ""
            sqlStr = "select * from Accounts_Clients where [CDS_Number]='" & AccountNumber & "'"
            Dim cmd = New SqlCommand(sqlStr, cn)
            Dim adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "Accounts_Clients")
            Dim Amount As Double = 0
            If (ds.Tables(0).Rows.Count > 0) Then
                If ds.Tables(0).Rows(0).Item("Tax_exemption").ToString.ToUpper = "YES" Then
                    Return True
                Else
                    Return False
                End If
            Else
                Return False
            End If
        End Using
    End Function
End Class
