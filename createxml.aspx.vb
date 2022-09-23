Partial Class createxml
    Inherits System.Web.UI.Page
    Dim constr As String = (System.Configuration.ConfigurationManager.AppSettings("connpath"))
    Dim cn As New SqlConnection(constr)
    Dim adp As SqlDataAdapter
    Dim cmd As SqlCommand
    Public allrec As String
    Public customernumber, customermessage As String

    Public Sub msgbox(ByVal strMessage As String)

        'finishes server processing, returns to client.
        Dim strScript As String = "<script language=JavaScript>"
        strScript += "window.alert(""" & strMessage & """);"
        strScript += "</script>"
        Dim lbl As New System.Web.UI.WebControls.Label
        lbl.Text = strScript
        Page.Controls.Add(lbl)

        'End Sub
        'Public Sub getpendingauth()
        '    Try
        '        Dim ds As New DataSet
        '        'cmd = New SqlCommand("select Tbl_MatchedOrders .Sellercdsno as [CDS No.] , Accounts_Clients.Surname +' '+Accounts_Clients .Forenames as [Client], Tbl_MatchedOrders .Quantity as [Quantity], Tbl_MatchedOrders.DealPrice as [Price], Tbl_MatchedOrders .Trade as [Trade Date] from Tbl_MatchedOrders , Accounts_Clients where Tbl_MatchedOrders.Sellercdsno = Accounts_Clients .CDS_Number and trade between '" & Datefrom & "' and '" & DateTo & "'", cn)
        '        cmd = New SqlCommand(TextBox1.Text, cn)
        '        adp = New SqlDataAdapter(cmd)
        '        adp.Fill(ds, "tbl_MatchedOrders")
        '        If (ds.Tables(0).Rows.Count > 0) Then
        '            grdSellers.DataSource = ds.Tables(0)
        '            grdsellers.DataBind()

        '        Else
        '            grdsellers.DataSource = Nothing
        '            grdsellers.DataBind()
        '            msgbox("No Pending Records")
        '        End If

        '    Catch ex As Exception
        '        msgbox(ex.Message)
        '    End Try
        'End Sub

        'Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load

        'End Sub

        'Protected Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        '    Try
        '        getpendingauth()
        '    Catch ex As Exception
        '        msgbox(ex.Message)
        '    End Try


        'End Sub

        'Protected Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim strXmlInputData As String = String.Empty

        strXmlInputData &= "<?xml version='1.0' encoding='utf-16'?> "
        strXmlInputData &= "<RequestPayload xmlns:xsi='http://www.w3.org/2001/XMLSchema-instance'  xmlns:xsd='http://www.w3.org/2001/XMLSchema'  xmlns='SWIFTNetBusinessEnvelope'>   <AppHdr xmlns:xsi='http://www.w3.org/2001/XMLSchema-instance'   xmlns:xsd='http://www.w3.org/2001/XMLSchema'           xmlns='urn:iso:std:iso:20022:tech:xsd:head.001.001.01'> "
        'var
        strXmlInputData &= "<Fr>       <OrgId>         <Id>           <OrgId>             <AnyBIC>STTCSDJJXXX</AnyBIC>           </OrgId>         </Id>       </OrgId>     </Fr> "

        'var
        strXmlInputData &= " <To>       <OrgId>         <Id>           <OrgId>             <AnyBIC>STTATSZAJAX</AnyBIC>           </OrgId>         </Id>       </OrgId>     </To>"

        'var
        strXmlInputData &= " <MsgDefIdr>semt.002.001.05.xsd</MsgDefIdr> "

        'var
        strXmlInputData &= " <CreDt>2014-10-21T07:14:13.6240304Z</CreDt>   </AppHdr> "

        strXmlInputData &= "  <Document xmlns:xsi='http://www.w3.org/2001/XMLSchema-instance'              xmlns:xsd='http://www.w3.org/2001/XMLSchema'              xmlns='urn:iso:std:iso:20022:tech:xsd:semt.002.001.05'>     <SctiesBalCtdyRpt> "

        'var
        strXmlInputData &= " <Pgntn>         <PgNb>1</PgNb>         <LastPgInd>true</LastPgInd>       </Pgntn> "

        'var
        strXmlInputData &= " <StmtGnlDtls>         <StmtDtTm>           <DtTm>2014-10-21T09:14:13.3540358+02:00</DtTm>         </StmtDtTm>"

        'var
        strXmlInputData &= "  <Frqcy>           <Cd>ADHO</Cd>         </Frqcy> "

        'var
        strXmlInputData &= " <UpdTp>           <Cd>DELT</Cd>         </UpdTp>"

        'var
        strXmlInputData &= " <StmtBsis>           <Cd>SETT</Cd>         </StmtBsis> "

        'var
        strXmlInputData &= "   <ActvtyInd>true</ActvtyInd>         <SubAcctInd>true</SubAcctInd>  </StmtGnlDtls> "

        'var
        strXmlInputData &= " <AcctOwnr>         <PrtryId>           <Id>B01/0000000008737</Id>           <Issr>DSECSD</Issr>           <SchmeNm>STTSCHEME</SchmeNm>         </PrtryId>       </AcctOwnr>"

        'var
        strXmlInputData &= "<AcctSvcr>  <PrtryId>           <Id>DSECSD</Id>           <Issr>DSECSD</Issr>           <SchmeNm>STTSCHEME</SchmeNm>         </PrtryId>       </AcctSvcr>"

        'var
        strXmlInputData &= " <SfkpgAcct>         <Id>B01/0000000008737</Id>         <Tp>           <Cd>CEND</Cd>         </Tp>         <Nm>WILFRED GIDEON MAGOVA</Nm>         <Dsgnt>TANZANIA SECURITIES LIMITED</Dsgnt>       </SfkpgAcct>"

        'var importnt
        strXmlInputData &= " <BalForAcct>         <FinInstrmId>           <ISIN>TZETTP000039</ISIN>           <Desc>TATEPA</Desc>         </FinInstrmId>         <FinInstrmAttrbts>           <PlcOfListg>             <Desc>TZ</Desc>           </PlcOfListg>           <DnmtnCcy>TZS</DnmtnCcy>           <IsseDt>2006-11-23</IsseDt>         </FinInstrmAttrbts>         <AggtBal>           <ShrtLngInd>LONG</ShrtLngInd> "

        'var importnt
        strXmlInputData &= "  <Qty>             <Qty>               <Qty>                 <Unit>319.00</Unit>               </Qty>             </Qty>           </Qty>         </AggtBal>         <AvlblBal>           <Qty>             <Unit>319.00</Unit>           </Qty>         </AvlblBal>         <NotAvlblBal>           <Qty>             <Unit>0</Unit>           </Qty>         </NotAvlblBal> "

        'var importnt
        strXmlInputData &= " <SfkpgPlc>           <TpAndId>             <SfkpgPlcTp>NCSD</SfkpgPlcTp>             <Id>CDSDTZJJ</Id>           </TpAndId>         </SfkpgPlc> "

        'var price
        strXmlInputData &= "  <PricDtls>           <Tp>             <Cd>INDC</Cd>           </Tp>           <Val>             <Rate>650.00</Rate>           </Val>           <ValTp>             <ValTp>PARV</ValTp>           </ValTp>           <SrcOfPric> "

        'var 
        strXmlInputData &= " <Id>               <Desc>STT ATS</Desc>  </Id>  "

        'var
        strXmlInputData &= " <Tp>               <Cd>LMAR</Cd>             </Tp>           </SrcOfPric>           <QtnDt>             <Dt>2014-03-24</Dt>           </QtnDt>         </PricDtls>         <BalBrkdwn>           <SubBalTp>             <Cd>PEND</Cd>           </SubBalTp> "

        'var
        strXmlInputData &= " <Qty>             <QtyAndAvlbty>               <Qty>                 <Unit>0</Unit>               </Qty>               <AvlbtyInd>false</AvlbtyInd>             </QtyAndAvlbty>           </Qty>         </BalBrkdwn>         <BalBrkdwn>           <SubBalTp>             <Cd>LOAN</Cd>           </SubBalTp>           <Qty>             <QtyAndAvlbty>               <Qty>                 <Unit>0</Unit>               </Qty>               <AvlbtyInd>false</AvlbtyInd>             </QtyAndAvlbty>           </Qty>  </BalBrkdwn>  "

        'var
        strXmlInputData &= " <BalBrkdwn>           <SubBalTp>             <Cd>BORR</Cd>           </SubBalTp>           <Qty>             <QtyAndAvlbty>               <Qty>                 <Unit>0</Unit>               </Qty>               <AvlbtyInd>true</AvlbtyInd>             </QtyAndAvlbty>           </Qty>         </BalBrkdwn> "

        'var
        strXmlInputData &= "  <BalBrkdwn>           <SubBalTp>             <Cd>PLED</Cd>           </SubBalTp>           <Qty>             <QtyAndAvlbty>               <Qty>                 <Unit>0</Unit>               </Qty>               <AvlbtyInd>false</AvlbtyInd>             </QtyAndAvlbty>           </Qty>         </BalBrkdwn>         <BalBrkdwn>           <SubBalTp>             <Cd>COLO</Cd>           </SubBalTp> "

        'var
        strXmlInputData &= " <Qty>             <QtyAndAvlbty>               <Qty>                 <Unit>0</Unit>               </Qty>               <AvlbtyInd>false</AvlbtyInd>             </QtyAndAvlbty>           </Qty>         </BalBrkdwn>         <BalBrkdwn>           <SubBalTp>             <Cd>WDOC</Cd>           </SubBalTp>           <Qty>             <QtyAndAvlbty>               <Qty>                 <Unit>0</Unit>               </Qty>               <AvlbtyInd>false</AvlbtyInd>             </QtyAndAvlbty>           </Qty>         </BalBrkdwn>       </BalForAcct>     </SctiesBalCtdyRpt>   </Document> </RequestPayload> "
      


        msgbox(strXmlInputData)
    End Sub
End Class
