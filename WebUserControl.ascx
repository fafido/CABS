<%@ Control Language="VB" AutoEventWireup="false" CodeFile="WebUserControl.ascx.vb"
    Inherits="WebUserControl" %>
    
    <script language="javascript" type="text/javascript">
        setTimeout(function(){ alert("System Timed Out!"); window.location='<%= LoginURL %>'; }, 5000 * 180);
        
    </script>
    
<table>
    <tr>
        <td>
            <asp:Image ID="Image1" runat="server" Height="88px" ImageUrl="~/img/EscroShare.jpg"
                Style="z-index: 100; left: 10px; position: absolute; top: 16px" Width="312px" />
                </td>
            <td style="width: 300px; height: 91px;">
                <asp:Image ID="Image2" runat="server" Height="88px" ImageUrl="~/img/EscrowShareHeader1.jpg"
                    Style="z-index: 100; left: 320px; position: absolute; top: 16px; border-bottom-width: thick;
                    border-bottom-color: black;" Width="912px" />
            </td>        
    </tr>
    <tr style="width: 300px;">
        <td colspan="2" style="height: 538px">
            <asp:Menu ID="Menu2" runat="server" Width="136px" Style="direction: ltr; background-color: background;
                border-bottom-style: none" BackColor="#d8e4f8" Font-Bold="False" Font-Names="Calibri"
                Font-Size="Small" Height="528px" BorderColor="#000040" ForeColor="Black">
                <StaticMenuStyle BackColor="White" BorderStyle="Solid" />
                <LevelMenuItemStyles>
                    <asp:MenuItemStyle Font-Underline="False" />
                    <asp:MenuItemStyle Font-Underline="False" />
                    <asp:MenuItemStyle Font-Underline="False" />
                    <asp:MenuItemStyle Font-Underline="False" />
                </LevelMenuItemStyles>
                <StaticMenuItemStyle BackColor="#D8E4F8" BorderColor="Black" Font-Bold="True" Font-Size="Medium"
                    BorderWidth="0px" Font-Names="Times New Roman" ForeColor="Black" />
                <DynamicHoverStyle BackColor="#D8E4F8" BorderColor="#404040" ForeColor="Black" />
                <DynamicMenuStyle BorderStyle="None" BackColor="Black" BorderColor="#404040" BorderWidth="1px" />
                <StaticSelectedStyle BackColor="White" />
                <DynamicMenuItemStyle BackColor="#004E98" BorderColor="#404040" BorderStyle="None"
                    BorderWidth="1px" ForeColor="White" />
                <Items>
                    <asp:MenuItem Text=" " Value="0" ImageUrl="~/img/menulogout.jpg"></asp:MenuItem>
                    <asp:MenuItem Text=" " Value="1" ImageUrl="~/img/menuCapture.jpg" ToolTip="Capture">
                        <asp:MenuItem Text="Batch Receipt" Value="New Item" NavigateUrl="~/Capture/BatchReceipt.aspx">
                        </asp:MenuItem>
                        <asp:MenuItem NavigateUrl="~/Capture/batchEnquiry.aspx" Text="Batch Enquiry" Value="BatchStats">
                        </asp:MenuItem>
                        <asp:MenuItem NavigateUrl="~/Capture/Bonus.aspx" Text="Batches" Value="New Item">
                        </asp:MenuItem>
                        <asp:MenuItem NavigateUrl="~/Capture/frmCD.aspx" Text="CD" Value="New Item"></asp:MenuItem>
                        <asp:MenuItem NavigateUrl="~/Capture/frmCDScapture.aspx" Text="CDS" Value="CDS">
                        </asp:MenuItem>
                        <asp:MenuItem NavigateUrl="~/Capture/NewTransfer.aspx" Text="Transfer" Value="Print Updated Stats">
                        </asp:MenuItem>
                        <asp:MenuItem NavigateUrl="~/Capture/Indeminity.aspx" Text="Indemnity" Value="Indem">
                        </asp:MenuItem>
                        <asp:MenuItem NavigateUrl="~/Capture/frmAllotment.aspx" Text="Allotment" Value="Allotment">
                        </asp:MenuItem>
                        <asp:MenuItem NavigateUrl="~/Capture/frmRemoval.aspx" Text="Removal" Value="Removal">
                        </asp:MenuItem>
                        <asp:MenuItem NavigateUrl="~/Cheque Recon/ChangeChequeNo.aspx" Text="Cheque Posting"
                            Value="Cheque Posting"></asp:MenuItem>
                        <asp:MenuItem NavigateUrl="~/Cheque Recon/ChequeReplacementManual.aspx" Text="Manual Cheque Replacement"
                            Value="Manual Cheque Replacement"></asp:MenuItem>
                        <asp:MenuItem NavigateUrl="~/Consolidation/ConsolidationUpdate.aspx" Text="Consolidation Posting"
                            Value="Consolidation Posting"></asp:MenuItem>
                        <asp:MenuItem NavigateUrl="~/Cheque Recon/ShareHolderhfccheq.aspx" Text="HFC Update for Cheques"
                            Value="HFC Update for Cheques"></asp:MenuItem>
                        <asp:MenuItem NavigateUrl="~/Capture/Scheme2.aspx" Text="Scheme 2" 
                            Value="Scheme 2"></asp:MenuItem>
                        <asp:MenuItem NavigateUrl="~/Capture/SplitCertificates.aspx" Text="SPLIT" 
                            Value="SPLIT"></asp:MenuItem>
                        <asp:MenuItem NavigateUrl="~/Capture/frmCDCapture.aspx" Text="CD Capture" Value="CD Capture"></asp:MenuItem>
                    </asp:MenuItem>
                    <asp:MenuItem Text=" " Value="2" ToolTip="Enquiries" ImageUrl="~/img/menuEnquiries.jpg">
                        <asp:MenuItem Text="Enquire By Company" Value="New Item" NavigateUrl="~/Enquiry/ShareHolderCompany.aspx">
                        </asp:MenuItem>
                        <asp:MenuItem NavigateUrl="~/Enquiry/ShareHolderEnq.aspx" Text="Enquire By All Companies"
                            Value="Enquire By All Companies"></asp:MenuItem>
                        <asp:MenuItem NavigateUrl="~/Enquiry/EnquireCerificates.aspx" Text="Certificates"
                            Value="Certificates"></asp:MenuItem>
                        <asp:MenuItem NavigateUrl="~/Enquiry/EnqByTransfer.aspx" Text="Transfers" Value="Transfers">
                        </asp:MenuItem>
                        <asp:MenuItem NavigateUrl="~/Enquiry/BatchStatusEnq.aspx" Text="Batch Enquiry" 
                            Value="Batch Enquiry"></asp:MenuItem>
                        <asp:MenuItem NavigateUrl="~/Capture/batchEnquiry.aspx" 
                            Text="Batch Receipt Enquiry" Value="Batch Receipt Enquiry"></asp:MenuItem>
                        <asp:MenuItem NavigateUrl="~/Cheque Recon/Print Statement Report.aspx" Text="Dividends History Report"
                            Value="Dividends History Report"></asp:MenuItem>
                        <asp:MenuItem NavigateUrl="~/Dividend/DividendEnquiryR1.aspx" Text="Dividend Enquiry"
                            Value="Dividend Enquiry"></asp:MenuItem>
                        <asp:MenuItem NavigateUrl="~/Dividend/PPCDividendEnquiryR1.aspx" Text="PPC Dividend Enquiry"
                            Value="PPC Dividend Enquiry"></asp:MenuItem>
                        <asp:MenuItem NavigateUrl="~/Cheque Recon/ChequeReconEnquiry.aspx" Text="Cheque Status Enquiry"
                            Value="Cheque Status Enquiry"></asp:MenuItem>
                        <asp:MenuItem NavigateUrl="~/Cheque Recon/PPCChequeReconEnquiry.aspx" 
                            Text="PPC Cheque Status Enquiry" Value="PPC Cheque Status Enquiry">
                        </asp:MenuItem>
                        <asp:MenuItem NavigateUrl="~/Enquiry/BuyersandSellersHistory.aspx" Text="Buyers And Sellers"
                            Value="Buyers And Sellers"></asp:MenuItem>
                        <asp:MenuItem NavigateUrl="~/Names/NameInquiry1.aspx" Text="Name Enquiry" Value="Name Enquiry">
                        </asp:MenuItem>
                        <asp:MenuItem NavigateUrl="~/Enquiry/EnquireCertTransfer.aspx" Text="Certificates Transfer Tracking"
                            Value="Certificates Transfer Tracking"></asp:MenuItem>
                        <asp:MenuItem NavigateUrl="~/Enquiry/HoldingReport.aspx" Text="Holding Report Enquiry"
                            Value="Holding Report Enquiry"></asp:MenuItem>
                        <asp:MenuItem NavigateUrl="~/Enquiry/LDRStaticData.aspx" Text="LDR Static Details Enquiry"
                            Value="LDR Static Details Enquiry"></asp:MenuItem>
                        <asp:MenuItem NavigateUrl="~/Enquiry/ShareholderStaticDetail.aspx" 
                            Text="Static Detail Maintenance" Value="Static Detail Maintenance">
                        </asp:MenuItem>
                        <asp:MenuItem NavigateUrl="~/Reports(Normal)/Transfers100000.aspx" 
                            Text="Transfers Above Ten Thousand" Value="Transfers Above Ten Thousand">
                        </asp:MenuItem>
                        <asp:MenuItem NavigateUrl="~/Capture/AllotmentsReport.aspx" 
                            Text="Allotments Schedule" Value="Allotments Schedule"></asp:MenuItem>
                    </asp:MenuItem>
                    <asp:MenuItem Text=" " Value="4" ToolTip="Dividend" ImageUrl="~/img/menuDividend.jpg">
                        <asp:MenuItem Text="PPC Dividend"
                            Value="PPC Dividend Instructions">
                            <asp:MenuItem NavigateUrl="~/Dividend/PPCDividentInstr.aspx" Text="Dividend Instructions"
                                Value="Dividend Instructions"></asp:MenuItem>
                            <asp:MenuItem NavigateUrl="~/Dividend/PPCDividendCalculation.aspx" Text="Dividend Calculation"
                                Value="Dividend Calculation"></asp:MenuItem>
                            <asp:MenuItem NavigateUrl="~/Dividend/PPCCreateDividend.aspx" Text="Create PPC Dividend"
                                Value="Create PPC Dividend"></asp:MenuItem>
                            <asp:MenuItem NavigateUrl="~/Dividend/PPCCreateDivCheqnumber.aspx" Text="Create Cheque Number"
                                Value="Create Cheque Number"></asp:MenuItem>
                            <asp:MenuItem NavigateUrl="~/Dividend/PPCClearChequeNumber.aspx" Text="Clear Cheque Numbers"
                                Value="Clear Cheque Numbers"></asp:MenuItem>
                            <asp:MenuItem NavigateUrl="~/Dividend/PPCCreateEFT.aspx" Text="Download EFT File"
                                Value="Download EFT File"></asp:MenuItem>
                            <asp:MenuItem NavigateUrl="~/Dividend/PPCPrintCheques.aspx" Text="Print Cheques"
                                Value="Print Cheques"></asp:MenuItem>
                            <asp:MenuItem NavigateUrl="~/Dividend/PPCDividendSchedule.aspx" Text="Dividend Schedule"
                                Value="Dividend Schedule"></asp:MenuItem>
                            <asp:MenuItem NavigateUrl="~/Dividend/PPCFullChequeschedule.aspx" Text="Cheque Schedule"
                                Value="Cheque Schedule"></asp:MenuItem>
                            <asp:MenuItem NavigateUrl="~/Dividend/PPCDividendlabelsD.aspx" Text="Dividend Labels"
                                Value="Dividend Labels"></asp:MenuItem>
                            <asp:MenuItem NavigateUrl="~/Dividend/PPCDividendEnquiryR1.aspx" Text="Enquiries "
                                Value="Enquiries "></asp:MenuItem>
                            <asp:MenuItem NavigateUrl="~/Dividend/PPCDividendEFT.aspx" Text="Dividend EFT Details"
                                Value="Dividend EFT Details"></asp:MenuItem>
                            <asp:MenuItem NavigateUrl="~/Dividend/PPCForeignDividendSchedule.aspx" Text="Foreigners Dividend Schedule"
                                Value="Foreigners Dividend Schedule"></asp:MenuItem>
                            <asp:MenuItem NavigateUrl="~/Dividend/PPCDividendCalculation.aspx" Text="Dividend Control Summary"
                                Value="Dividend Control Summary"></asp:MenuItem>
                            <asp:MenuItem NavigateUrl="~/Dividend/PPCDividendEFT.aspx" Text="EFT Schedule" Value="EFT Schedule">
                            </asp:MenuItem>
                            <asp:MenuItem NavigateUrl="~/Dividend/PPCfrmEftStatement.aspx" Text="EFT Advice slips"
                                Value="EFT Advice slips"></asp:MenuItem>
                            <asp:MenuItem NavigateUrl="~/Dividend/PPCfrmFEftStatement.aspx" Text="Foreigners Advice Slips"
                                Value="Foreigners Advice Slips"></asp:MenuItem>
                            <asp:MenuItem NavigateUrl="~/Dividend/TaxFileCreation.aspx" 
                                Text="PPC Tax File (Sars)" Value="PPC Tax File (Sars)"></asp:MenuItem>
                            <asp:MenuItem NavigateUrl="~/Dividend/PPCWNPDividendSchedule.aspx" 
                                Text="WNP Schedule" Value="WNP Schedule"></asp:MenuItem>
                        </asp:MenuItem>
                        <asp:MenuItem NavigateUrl="~/Dividend/DividentInstr.aspx" Text="Dividend Instructions"
                            Value="Dividend Instructions"></asp:MenuItem>
                        <asp:MenuItem NavigateUrl="~/Dividend/DividendCalculation.aspx" Text="Dividend Control Summary"
                            Value="Dividend Calculation"></asp:MenuItem>
                        <asp:MenuItem NavigateUrl="~/Dividend/CreateDividend.aspx" Text="Create Dividend"
                            Value="New Item"></asp:MenuItem>
                        <asp:MenuItem NavigateUrl="~/Dividend/CreateDivCheqnumber.aspx" Text="Create Cheque Numbers"
                            Value="New Item"></asp:MenuItem>
                        <asp:MenuItem NavigateUrl="~/Dividend/CheckChequenumbers.aspx" Text="Check Cheque Numbers"
                            Value="New Item"></asp:MenuItem>
                        <asp:MenuItem NavigateUrl="~/Dividend/ClearChequeNumber.aspx" Text="Clear Cheque Numbers"
                            Value="New Item"></asp:MenuItem>
                        <asp:MenuItem NavigateUrl="~/Dividend/PrintCheques.aspx" Text="Print Cheques" Value="Print Cheques">
                        </asp:MenuItem>
                        <asp:MenuItem NavigateUrl="~/Dividend/FullChequeschedule.aspx" Text="Cheque Schedule"
                            Value="Cheque Schedule"></asp:MenuItem>
                        <asp:MenuItem NavigateUrl="~/Dividend/DividendSchedule.aspx" Text="Dividend Schedule"
                            Value="Dividend Schedule"></asp:MenuItem>
                        <asp:MenuItem NavigateUrl="~/Dividend/ForeignDividendSchedule.aspx" Text="Foreigners Dividend Schedule"
                            Value="Foreigners Dividend Schedule"></asp:MenuItem>
                        <asp:MenuItem NavigateUrl="~/Dividend/WNPDividendSchedule.aspx" Text="WNP Dividend Schedule"
                            Value="WNP Dividend Schedule"></asp:MenuItem>
                        <asp:MenuItem NavigateUrl="~/Dividend/DividendlabelsD.aspx" Text="Dividend Labels"
                            Value="Dividend Labels New"></asp:MenuItem>
                        <asp:MenuItem NavigateUrl="~/Dividend/DividendEnquiryR1.aspx" Text="Dividend Enquiry Report"
                            Value="Dividend Enquiry Report"></asp:MenuItem>
                        <asp:MenuItem NavigateUrl="~/Dividend/CreateZimEFT.aspx" Text="Create EFT File (2nd Format)"
                            Value="Create EFT File (2nd Format)"></asp:MenuItem>
                        <asp:MenuItem NavigateUrl="~/Dividend/CreateEFT.aspx" Text="Create EFT" Value="Create EFT">
                        </asp:MenuItem>
                        <asp:MenuItem NavigateUrl="~/Dividend/DividendEFT.aspx" Text="EFT Details" Value="EFT Details">
                        </asp:MenuItem>
                        <asp:MenuItem NavigateUrl="~/Dividend/FullEFTSchedule.aspx" Text="Full EFT Schedule"
                            Value="Full EFT Schedule"></asp:MenuItem>
                        <asp:MenuItem NavigateUrl="~/Dividend/EFTSchedule1.aspx" Text="EFT Schedule By Bank" Value="EFT PRINT">
                        </asp:MenuItem>                        
                        <asp:MenuItem NavigateUrl="~/Dividend/frmEftStatement.aspx" Text="E. F. T Advice Slips"
                            Value="E. F. T Statements"></asp:MenuItem>
                        <asp:MenuItem NavigateUrl="~/Dividend/frmShareholderEftStatement.aspx" Text="EFT Statement By Shareholder"
                            Value="EFT Statement By Shareholder"></asp:MenuItem>
                        <asp:MenuItem NavigateUrl="~/Dividend/CreateScriptBatch.aspx" Text="Create Scrip Batch"
                            Value="Create Script Batch"></asp:MenuItem>
                        <asp:MenuItem NavigateUrl="~/Dividend/EditScriptDetails.aspx" Text="Edit Scrip details"
                            Value="Edit Script details"></asp:MenuItem>
                        <asp:MenuItem NavigateUrl="~/Dividend/PrintScriptAccepted.aspx" Text="Print Scrip"
                            Value="Print Script"></asp:MenuItem>
                        <asp:MenuItem NavigateUrl="~/Dividend/HoldingReport.aspx" Text="Holding Report" Value="Holding Report">
                        </asp:MenuItem>
                        <asp:MenuItem NavigateUrl="~/Dividend/RefreshNames.aspx" Text="Refresh Names" Value="Refresh Names">
                        </asp:MenuItem>
                        <asp:MenuItem NavigateUrl="~/Dividend/RemoveBanks.aspx" Text="Remove Banks" Value="Remove Banks">
                        </asp:MenuItem>
                        <asp:MenuItem NavigateUrl="~/Dividend/AmalgamateChequesByind.aspx" Text="Amalgamate Cheqs By Ind"
                            Value="New Item"></asp:MenuItem>
                        <asp:MenuItem NavigateUrl="~/Dividend/CreateNewEFTFormat.aspx" Text="SFI Dividend File Format"
                            Value="SFI Dividend File Format"></asp:MenuItem>
                        <asp:MenuItem NavigateUrl="~/Dividend/frmFEftStatement.aspx" Text="Foreigner's EFT Advice Slips"
                            Value="Foreigner's EFT Advice Slips"></asp:MenuItem>
                        <asp:MenuItem NavigateUrl="~/Dividend/frmAccept.aspx" Text="Scrip Acceptance" 
                            Value="Scrip Acceptance"></asp:MenuItem>
                        <asp:MenuItem NavigateUrl="~/Dividend/ScripDividendAdvice.aspx" 
                            Text="Scrip advice" Value="Scrip advice"></asp:MenuItem>
                        <asp:MenuItem NavigateUrl="~/Dividend/AcceptanceStats.aspx" 
                            Text="Scrip Statistics" Value="Scrip Statistics"></asp:MenuItem>
                        <asp:MenuItem NavigateUrl="~/Dividend/ScripDividendBatching.aspx" 
                            Text="Scrip Batching" Value="Scrip Batching"></asp:MenuItem>
                        <asp:MenuItem NavigateUrl="~/Dividend/ScripAcceptanceSchedule.aspx" 
                            Text="Scrip Acceptance Schedule" Value="Scrip Acceptance Schedule">
                        </asp:MenuItem>
                        <asp:MenuItem NavigateUrl="~/Dividend/ScripDividendLabels.aspx" 
                            Text="Scrip Reports" Value="Scrip Reports"></asp:MenuItem>
                    </asp:MenuItem>
                    <asp:MenuItem Text=" " Value="3" ToolTip="Portfolio" ImageUrl="~/img/menuPortfolio.jpg">
                        <asp:MenuItem NavigateUrl="~/Portfolio.aspx" Text="PortFolio" Value="PortFolio">
                        </asp:MenuItem>
                        <asp:MenuItem NavigateUrl="~/Companyshares.aspx" Text="PortFolio Report" Value="PortFolio Report">
                        </asp:MenuItem>
                        <asp:MenuItem NavigateUrl="~/frmGainLoss.aspx" Text="PortFolioGainLoss" Value="PortFolioGainLoss">
                        </asp:MenuItem>
                    </asp:MenuItem>
                    <asp:MenuItem Text=" " Value="6" ImageUrl="~/img/menuDivRecon.jpg" ToolTip="Dividend Reconciliation">
                        <asp:MenuItem Text="PPC RECON" Value="PPC RECON">
                            <asp:MenuItem NavigateUrl="~/Cheque Recon/PPCaddcheqmaster.aspx" Text="Create Recon Event"
                                Value="Create Recon Event"></asp:MenuItem>
                            <asp:MenuItem NavigateUrl="~/Cheque Recon/PPCCreateChequeRecon.aspx" Text="Create Dividend Reconciliation"
                                Value="Create Dividend Reconciliation"></asp:MenuItem>
                            <asp:MenuItem NavigateUrl="~/Cheque Recon/PPCSummaryReportForDividend.aspx" 
                                Text="Dividend Summary Report" Value="Dividend Summary Report">
                            </asp:MenuItem>
                            <asp:MenuItem NavigateUrl="~/Cheque Recon/ChequeSchedule_ppc.aspx" Text="Cheque Schdule Test" Value="Cheque Schdule Test"></asp:MenuItem>
                            <asp:MenuItem NavigateUrl="~/Cheque Recon/PPCChequeSchedule.aspx" 
                                Text="Cheque Schedule" Value="Cheque Schedule"></asp:MenuItem>
                            <asp:MenuItem NavigateUrl="~/Cheque Recon/PPCChequeSummary.aspx" 
                                Text="Cheque Summary" Value="Cheque Summary"></asp:MenuItem>
                            <asp:MenuItem NavigateUrl="~/BankReconcilation/PPCImportFormCDS.aspx" 
                                Text="Electronic Statement Update" Value="Electronic Statement Update">
                            </asp:MenuItem>
                            <asp:MenuItem NavigateUrl="~/BankReconcilation/PPCErrorReport.aspx" 
                                Text="Error Report" Value="Error Report"></asp:MenuItem>
                            <asp:MenuItem NavigateUrl="~/Cheque Recon/PPCChequeReconcillation.aspx" 
                                Text="Manual Reconciliation" Value="Manual Reconciliation"></asp:MenuItem>
                            <asp:MenuItem NavigateUrl="~/Reports(Normal)/PPCFullReport.aspx" 
                                Text="Unclaimed Summary" Value="Unclaimed Summary"></asp:MenuItem>
                            <asp:MenuItem NavigateUrl="~/Cheque Recon/PPCMergeCheque.aspx" 
                                Text="Merge Cheque" Value="Merge Cheque"></asp:MenuItem>
                        </asp:MenuItem>
                        <asp:MenuItem NavigateUrl="~/Cheque Recon/addcheqmaster.aspx" Text="Create Reconciliation Event"
                            Value="Create New Event"></asp:MenuItem>
                        <asp:MenuItem NavigateUrl="~/Cheque Recon/CreateChequeRecon.aspx" Text="Create Dividend Reconciliation"
                            Value="Create Cheque Recon"></asp:MenuItem>
                        <asp:MenuItem NavigateUrl="~/Cheque Recon/SummaryReportForDividend.aspx" Text="Dividend Summary Report"
                            Value="Summary Report For Dividend"></asp:MenuItem>
                        <asp:MenuItem NavigateUrl="~/Cheque Recon/ChequeSchedule.aspx" Text="Cheque Schedules"
                            Value="Cheque Schedule"></asp:MenuItem>
                        <asp:MenuItem NavigateUrl="~/Cheque Recon/ChequeSummary.aspx" Text="Cheque Summary"
                            Value="Cheque Summary"></asp:MenuItem>
                        <asp:MenuItem NavigateUrl="~/BankReconcilation/ImportFormCDS.aspx" Text="Electronic Statement Update"
                            Value="Statement Update Report"></asp:MenuItem>
                        <asp:MenuItem NavigateUrl="~/BankReconcilation/ErrorReport.aspx" Text="Error Report"
                            Value="Statement Error Report"></asp:MenuItem>
                        <asp:MenuItem NavigateUrl="~/Cheque Recon/ChequeReconcillation.aspx" Text="Manual Reconciliation"
                            Value="Manual Reconciliation"></asp:MenuItem>
                        <asp:MenuItem NavigateUrl="~/Reports(Normal)/FullReport.aspx" Text="Unclaimed Summaries"
                            Value="Total Unclaimed"></asp:MenuItem>
                        <asp:MenuItem NavigateUrl="~/Cheque Recon/MergeCheque.aspx" Text="Merge Cheque" Value="Merge Cheque">
                        </asp:MenuItem>
                        <asp:MenuItem NavigateUrl="~/Cheque Recon/PrintChanged.aspx" Text="Print Changed"
                            Value="Print Changed"></asp:MenuItem>
                    </asp:MenuItem>
                    <asp:MenuItem Text=" " Value="7" ImageUrl="~/img/menuRights.jpg" ToolTip="Rights">
                        <asp:MenuItem Text="Rights Instructions" Value="New Item" NavigateUrl="~/Rights/CreateRights.aspx">
                        </asp:MenuItem>
                        <asp:MenuItem NavigateUrl="~/Rights/rightsInstr.aspx" Text="Create Rights"
                            Value="New Item"></asp:MenuItem>
                        <asp:MenuItem NavigateUrl="~/Rights/frmAccept.aspx" Text="Acceptence" Value="Acceptence">
                        </asp:MenuItem>
                        <asp:MenuItem NavigateUrl="~/Rights/ProductionStats.aspx" Text="Production Stats"
                            Value="New Item"></asp:MenuItem>
                        <asp:MenuItem NavigateUrl="~/Rights/frmSplitRights.aspx" Text="Split L/As" Value="New Item">
                        </asp:MenuItem>
                        <asp:MenuItem NavigateUrl="~/Rights/Rightsbatchprint.aspx" Text="Print Rights Batch"
                            Value="Print Rights Batch"></asp:MenuItem>
                        <asp:MenuItem NavigateUrl="~/Rights/ViewRightsInstr.aspx" Text="Rights Instructions"
                            Value="Rights Instructions"></asp:MenuItem>
                        <asp:MenuItem NavigateUrl="~/Rights/RightsOfferSchd.aspx" Text="Rights Schedule"
                            Value="Rights Schedule"></asp:MenuItem>
                        <asp:MenuItem NavigateUrl="~/Rights/RightsAcceptence.aspx" Text="Acceptence Schedule"
                            Value="Acceptence Schedule"></asp:MenuItem>
                        <asp:MenuItem NavigateUrl="~/Rights/RightsLAltr.aspx" Text="LA Statements" Value="LA Statements">
                        </asp:MenuItem>
                        <asp:MenuItem NavigateUrl="~/Rights/RightsLAByHolder.aspx" Text="Shareholder LA's"
                            Value="Shareholder LA's"></asp:MenuItem>
                        <asp:MenuItem NavigateUrl="~/Rights/BatchBalance.aspx" Text="Batch Balancing" Value="Batch Balancing">
                        </asp:MenuItem>
                        <asp:MenuItem NavigateUrl="~/Rights/frmPrintRightsLabels.aspx" 
                            Text="Print Labels" Value="Print Labels"></asp:MenuItem>
                    </asp:MenuItem>
                    <asp:MenuItem Text=" " Value="8" ImageUrl="~/img/menuNames.jpg" ToolTip="Names">
                        <asp:MenuItem NavigateUrl="~/Names/NamesUpdate1.aspx" Text="Names" Value="Names">
                        </asp:MenuItem>
                        <asp:MenuItem NavigateUrl="~/Names/NameInquiry1.aspx" Text="Name Enquiry" Value="Name Enquiry">
                        </asp:MenuItem>
                        <asp:MenuItem NavigateUrl="~/Names/MandateUpdate1.aspx" Text="Mandates Update" Value="Mandate Update">
                        </asp:MenuItem>
                        <asp:MenuItem NavigateUrl="~/Names/NamesAudit.aspx" Text="Names Audit" Value="Names Audit">
                        </asp:MenuItem>
                        <asp:MenuItem NavigateUrl="~/Names/ShareHolderhfcmast.aspx" Text="H.F.C Certificates Flagging"
                            Value="H.F.C Certificates Flagging"></asp:MenuItem>
                        <asp:MenuItem NavigateUrl="~/Names/NameConsolidation.aspx" 
                            Text="Account Consolidations" Value="Account Consolidations"></asp:MenuItem>
                        <asp:MenuItem NavigateUrl="~/Dividend/StaticStatements.aspx" 
                            Text="Static Detail Statements" Value="Static Detail Statements">
                        </asp:MenuItem>
                    </asp:MenuItem>
                    <asp:MenuItem Text=" " Value="9" ImageUrl="~/img/menucds.jpg" ToolTip="C.D.S.">
                        <asp:MenuItem Text="Import From C.D.S" Value="New Item" NavigateUrl="~/CDS/ImportFromCDS.aspx">
                        </asp:MenuItem>
                        <asp:MenuItem Text="Export To C.D.S." Value="New Item" NavigateUrl="~/CDS/ExportToCDS.aspx">
                        </asp:MenuItem>
                        <asp:MenuItem NavigateUrl="~/CDS/CDSEnquiry.aspx" Text="CDS Nominees Acc Balance"
                            Value="CDS Nominees Acc Balance"></asp:MenuItem>
                        <asp:MenuItem NavigateUrl="~/CDS/WITHDRAWAL.aspx" Text="CDS Withdrawal" Value="CDS Cert Split">
                        </asp:MenuItem>
                        <asp:MenuItem NavigateUrl="~/CDS/UpdateIndustryCOde.aspx" Text="Update Industry Codes"
                            Value="Update Industry Codes"></asp:MenuItem>
                        <asp:MenuItem NavigateUrl="~/CDS/CDSCPosted.aspx" Text="Posted CDS" Value="Posted CDS">
                        </asp:MenuItem>
                        <asp:MenuItem NavigateUrl="~/CDS/PrintCDSrep.aspx" Text="Summary Report" Value="Summary Report">
                        </asp:MenuItem>
                        <asp:MenuItem NavigateUrl="~/CDS/UpdateBANKCOde.aspx" Text="Update Banks for Mandates"
                            Value="Update Banks for Mandates"></asp:MenuItem>
                        <asp:MenuItem NavigateUrl="~/CDS/ImmobilizedCerts.aspx" Text="Confirmed Certificates"  Value="Confirmed Certificates"></asp:MenuItem>
                    </asp:MenuItem>
                    <asp:MenuItem Text=" " Value="16" ImageUrl="~/img/menureports.jpg" ToolTip=" Reports">
                        <asp:MenuItem NavigateUrl="~/Reports(Normal)/CompanyRepTry.aspx" Text="Full Company Schedule"
                            Value="SA Company Schd"></asp:MenuItem>
                        <asp:MenuItem NavigateUrl="~/Reports(Normal)/CompanyStats.aspx" Text="Company Stats"
                            Value="Company Stats"></asp:MenuItem>
                        <asp:MenuItem NavigateUrl="~/Enquiry/Batch_Summary_Details.aspx" 
                            Text="Transactions Stats" Value="Transactions Stats"></asp:MenuItem>
                        <asp:MenuItem NavigateUrl="~/Reports(Normal)/CompanytTopHolders.aspx" Text="Top Holder Report"
                            Value="Top Holder Report"></asp:MenuItem>
                        <asp:MenuItem NavigateUrl="~/Reports(Normal)/percentageShareHeld.aspx" Text="Summary Of Ownership"
                            Value="Percentage Of Shares Held"></asp:MenuItem>
                        <asp:MenuItem NavigateUrl="~/Reports(Normal)/AnnualReturnReport.aspx" Text="Annual Return Report"
                            Value="Annual Return Report"></asp:MenuItem>
                        <asp:MenuItem NavigateUrl="~/TransferReport.aspx" Text="Full Transaction Report"
                            Value="Full Transaction Report"></asp:MenuItem>
                        <asp:MenuItem NavigateUrl="~/Enquiry/Transaction.aspx" Text="Transaction Report"
                            Value="Transaction Report"></asp:MenuItem>
                        <asp:MenuItem NavigateUrl="~/Enquiry/transactionHistory.aspx" Text="Certificate History"
                            Value="Certificate History"></asp:MenuItem>
                        <asp:MenuItem NavigateUrl="~/Enquiry/TransferCheckList.aspx" Text="Transfers Sealing Checklist"
                            Value="Transfers Sealing Checklist"></asp:MenuItem>
                        <asp:MenuItem NavigateUrl="~/Enquiry/TransferChecklistIndem.aspx" Text="Duplicates Sealing Checklist"
                            Value="Duplicates Sealing Checklist"></asp:MenuItem>
                        <asp:MenuItem NavigateUrl="~/Enquiry/CertificatesProducedEnquiry.aspx" Text="Produced Certificates "
                            Value="Produced Certificates "></asp:MenuItem>
                        <asp:MenuItem NavigateUrl="~/Enquiry/transactionmovementHistory.aspx" Text="Shareholder Movement Summary"
                            Value="Movement Summary"></asp:MenuItem>
                        <asp:MenuItem NavigateUrl="~/Enquiry/TopMovements.aspx" Text="Top Movements" Value="Top Movements">
                        </asp:MenuItem>
                        <asp:MenuItem NavigateUrl="~/Enquiry/TradesHistory.aspx" Text="Purchases and Sales" Value="Net Movements">
                        </asp:MenuItem>
                        <asp:MenuItem NavigateUrl="~/Enquiry/TransactionList.aspx" Text="Transaction List By Type"
                            Value="Transaction List Summary"></asp:MenuItem>
                        <asp:MenuItem NavigateUrl="~/Reports(Normal)/AllotmentsReport.aspx" 
                            Text="Allotments" Value="Allotments"></asp:MenuItem>
                    </asp:MenuItem>
                    <asp:MenuItem Text=" " Value="5" ImageUrl="~/img/menuBonus.jpg" ToolTip="Bonus">
                        <asp:MenuItem Text="Bonus Instruction" Value="Bonus Instruction" 
                            NavigateUrl="~/Bonus/BonusInstruction.aspx">
                        </asp:MenuItem>
                        <asp:MenuItem Text="Create Bonus" Value="Create Bonus" 
                            NavigateUrl="~/Bonus/CreateBonus.aspx">
                        </asp:MenuItem>
                        <asp:MenuItem Text="Bonus Schedule & Batching" Value="Bonus Schedule & Batching" 
                            NavigateUrl="~/Bonus/ViewCreatedBonusBatch.aspx">
                        </asp:MenuItem>
                        <asp:MenuItem Text="Bonus Certificates" Value="Bonus Certificates" 
                            NavigateUrl="~/Bonus/frmUpdateCertprint.aspx">
                        </asp:MenuItem>
                        <asp:MenuItem Text="Bonus Batch Bonus" Value="Bonus Batch Bonus" 
                            NavigateUrl="~/Bonus/AuditCreatesBonus.aspx">
                        </asp:MenuItem>
                        <asp:MenuItem Text="Bonus Schedule" Value="Bonus Schedule" 
                            NavigateUrl="~/Reports(Normal)/bonusSchedule.aspx">
                        </asp:MenuItem>
                        <asp:MenuItem Text="Bonus Download File" Value="Bonus Download File" 
                            NavigateUrl="~/Bonus/CreateBonusFile.aspx">
                        </asp:MenuItem>
                        <asp:MenuItem Text="Bonus Control Summary" Value="Bonus Control Summary" 
                            NavigateUrl="~/Bonus/BonusSchedule.aspx">
                        </asp:MenuItem>
                    </asp:MenuItem>
                    <asp:MenuItem Text=" " Value="24" ImageUrl="~/img/menuSplit.jpg">
                    
                        <asp:MenuItem Text="Event Instructions" Value="Event Instruction" 
                            NavigateUrl="~/SplitDiv/BonusInstruction.aspx">
                        </asp:MenuItem>
                        
                        <asp:MenuItem Text="Create Event" Value="Create Event" 
                            NavigateUrl="~/SplitDiv/AuditCreatesBonus.aspx">
                        </asp:MenuItem>
                        
                        <asp:MenuItem Text="Event Schedule" Value="Event Schedule" 
                            NavigateUrl="~/SplitDiv/ViewCreatedBonusBatch.aspx">
                        </asp:MenuItem>
                        
                        <asp:MenuItem Text="Reverse Event" Value="Reverse Event" 
                            NavigateUrl="~/SplitDiv/frmUpdateCertprint.aspx">
                        </asp:MenuItem>
                        
                                            
                    </asp:MenuItem>
                    <asp:MenuItem Text=" " Value="21" ImageUrl="~/img/menuAudit.jpg" ToolTip="Audit ">
                        <asp:MenuItem NavigateUrl="~/frmAuditSelect.aspx" Text="Audit Trail Reports" Value="Audit trail reports">
                        </asp:MenuItem>
                        <asp:MenuItem NavigateUrl="~/frmAuditCD.aspx" Text="CD Batch Audit" Value="Auditing"></asp:MenuItem>
                        <asp:MenuItem NavigateUrl="~/Utilities/TestCapital.aspx" Text="Issued Share Capital Check"
                            Value="Issued Share capital Report"></asp:MenuItem>
                        <asp:MenuItem NavigateUrl="~/Utilities/IssuedSharesCapital.aspx" Text="Issued Share Capital Report"
                            Value="Issued Share capital check"></asp:MenuItem>
                        <asp:MenuItem NavigateUrl="~/Utilities/LoginDetails.aspx" Text="User  Login Details"
                            Value="User's Login Detail"></asp:MenuItem>
                        <asp:MenuItem NavigateUrl="~/Cheque Recon/ChequeUnpay.aspx" Text="Unpay Cheque" Value="Unpay Cheque">
                        </asp:MenuItem>
                        <asp:MenuItem NavigateUrl="~/Enquiry/CertsIssued.aspx" Text="Issued Certificates"
                            Value="Issued Certificates"></asp:MenuItem>
                        <asp:MenuItem NavigateUrl="~/Enquiry/CapitalChecks.aspx" Text="Share Capital Analysis"
                            Value="Share Capital Analysis"></asp:MenuItem>
                        <asp:MenuItem NavigateUrl="~/Enquiry/DataAnalysis.aspx" Text="Data Analysis" Value="Share Capital Analysis">
                        </asp:MenuItem>
                    </asp:MenuItem>
                    <asp:MenuItem Text=" " Value="22" ImageUrl="~/img/menuAuth.jpg" ToolTip="Authorization">
                        <asp:MenuItem Text="Name Changes" Value="Update and pending Authorization" NavigateUrl="~/Authorization/NamesAuthorization.aspx">
                        </asp:MenuItem>
                        <asp:MenuItem Text="Cheque Unpaying" Value="Unpaid cheques captured" NavigateUrl="~/Authorization/ChequeAuthorization.aspx"></asp:MenuItem>
                        <asp:MenuItem NavigateUrl="~/Names/MandateUpdateAuthorize.aspx" Text="Mandates Authorization"
                            Value="Mandates Authorization"></asp:MenuItem>
                        <asp:MenuItem Text="Dividend Instructions" Value="Dividend Instructions" NavigateUrl="~/Dividend/DividentInstrAuthorize.aspx"></asp:MenuItem>
                        <asp:MenuItem NavigateUrl="~/Dividend/PPCDividentInstrAuthorize.aspx" Text="PPC Dividend instructions"
                            Value="PPC Dividend instructions"></asp:MenuItem>
                        <asp:MenuItem NavigateUrl="~/Names/NameConsolidationAuth.aspx" 
                            Text="Account Consolidations" Value="Account Consolidations"></asp:MenuItem>
                        <asp:MenuItem NavigateUrl="~/SplitDiv/AuthCreateBonus.aspx" 
                            Text="Authorize Split" Value="Authorize Split"></asp:MenuItem>
                        <asp:MenuItem NavigateUrl="~/Scheme/SchemeInstrAuthorization.aspx" 
                            Text="Scheme Instructions" Value="Scheme Instructions"></asp:MenuItem>
                        <asp:MenuItem NavigateUrl="~/Update/SpecialBatchVerification.aspx" 
                            Text="Special Batch Verifications" Value="Special Batch Verifications">
                        </asp:MenuItem>
                    </asp:MenuItem>
                    <asp:MenuItem Text=" " Value="23" ImageUrl="~/img/menuPrinting.jpg" ToolTip="Printing">
                        <asp:MenuItem NavigateUrl="~/Capture/frmUpdateCertprint.aspx" Text="Print Certificates"
                            Value="Update Cert Print"></asp:MenuItem>
                        <asp:MenuItem NavigateUrl="~/Capture/SelectForReprint.aspx" Text="Reprint Certificates"
                            Value="Reprint Certificates"></asp:MenuItem>
                        <asp:MenuItem NavigateUrl="~/Consolidation/ShareHolderEnq.aspx" Text="Consolidations Reports"
                            Value="Consolidations Reports"></asp:MenuItem>
                        <asp:MenuItem NavigateUrl="~/Cheque Recon/ChangeCheueNoAll.aspx" Text="Cheque Replacement"
                            Value="Cheque Replacement"></asp:MenuItem>
                        <asp:MenuItem NavigateUrl="~/Capture/CertsToPrint.aspx" Text="Cert To Print Report"
                            Value="Cert To Print Report"></asp:MenuItem>
                        <asp:MenuItem NavigateUrl="~/CDS/PrintCDSCERT.aspx" Text="Print Jumbo Certificate"
                            Value="Print CDS Certificate"></asp:MenuItem>
                        <asp:MenuItem NavigateUrl="~/Consolidation/Consolidation.aspx" Text="Print Consolidation"
                            Value="Print Consolidation"></asp:MenuItem>
                        <asp:MenuItem NavigateUrl="~/Utilities/labels.aspx" Text="Print Company Labels" Value="Print Company Labels">
                        </asp:MenuItem>
                        <asp:MenuItem NavigateUrl="~/frmAuditPrintEnquiry.aspx" Text="Certificate Schedule"
                            Value="Certificate Schedule"></asp:MenuItem>
                        <asp:MenuItem NavigateUrl="~/frmAuditPrintEnquiry.aspx" Text="Jumbo Certificates Report"
                            Value="Jumbo Certificates Report"></asp:MenuItem>
                        <asp:MenuItem NavigateUrl="~/Update/SuppressedCerts.aspx" 
                            Text="Suppressed Certificates" Value="Suppressed Certificates">
                        </asp:MenuItem>
                    </asp:MenuItem>
                    <asp:MenuItem Text=" " Value="10" ImageUrl="~/img/menumailing.jpg" ToolTip="Mailing List">
                        <asp:MenuItem Text="Maintain" Value="New Item" NavigateUrl="~/Mailing Lists/MainTain.aspx">
                        </asp:MenuItem>
                        <asp:MenuItem Text="Stats" Value="New Item" NavigateUrl="~/Mailing Lists/MailStats.aspx">
                        </asp:MenuItem>
                        <asp:MenuItem NavigateUrl="~/Mailing Lists/MailSchedule.aspx" Text="Mail Schedule"
                            Value="Mail Schedule"></asp:MenuItem>
                    </asp:MenuItem>
                    <asp:MenuItem Text=" " Value="11" ImageUrl="~/img/menuparameters.jpg" ToolTip="Parameters">
                        <asp:MenuItem NavigateUrl="~/ParaMeters/Banks.aspx" Text="Banks" Value="Banks"></asp:MenuItem>
                        <asp:MenuItem NavigateUrl="~/ParaMeters/BranchForm.aspx" Text="Branch" Value="Branch">
                        </asp:MenuItem>
                        <asp:MenuItem NavigateUrl="~/ParaMeters/BrokerCode.aspx" Text="Brokers" Value="Brokers">
                        </asp:MenuItem>
                        <asp:MenuItem NavigateUrl="~/ParaMeters/Industrycode.aspx" Text="Industry" Value="New Item">
                        </asp:MenuItem>
                        <asp:MenuItem NavigateUrl="~/ParaMeters/Ranges.aspx" Text="Ranges" 
                            Value="Ranges"></asp:MenuItem>
                        <asp:MenuItem NavigateUrl="~/ParaMeters/TaxCodes.aspx" Text="Tax Codes" Value="Tax Codes">
                        </asp:MenuItem>
                        <asp:MenuItem NavigateUrl="~/ParaMeters/Languages.aspx" Text="Languages" Value="Languages">
                        </asp:MenuItem>
                        <asp:MenuItem NavigateUrl="~/ParaMeters/Companies.aspx" Text="Companies" Value="Companies">
                        </asp:MenuItem>
                        <asp:MenuItem NavigateUrl="~/ParaMeters/country.aspx" Text="Country" Value="Country">
                        </asp:MenuItem>
                        <asp:MenuItem NavigateUrl="~/ParaMeters/AccountType.aspx" Text="Account Type" Value="Account Type">
                        </asp:MenuItem>
                        <asp:MenuItem NavigateUrl="~/ParaMeters/UpdateIndustryCOde.aspx" Text="Add Post Registration Numbers"
                            Value="Add Post Registration Numbers"></asp:MenuItem>
                        <asp:MenuItem NavigateUrl="~/ParaMeters/BatchMinimumAuthorizationBalance.aspx" 
                            Text="Batch Authorization" Value="Batch Authorization"></asp:MenuItem>
                    </asp:MenuItem>
                    <asp:MenuItem Text=" " Value="12" ImageUrl="~/img/menuUtilities.jpg" ToolTip=" Utilities">
                        <asp:MenuItem NavigateUrl="~/Utilities/CountHolders.aspx" Text="Count Holders" Value="Count Holders">
                        </asp:MenuItem>
                        <asp:MenuItem NavigateUrl="~/Utilities/CreateBatchFromRegister.aspx" Text="Create Batch From Register"
                            Value="New Item"></asp:MenuItem>
                        <asp:MenuItem NavigateUrl="~/Utilities/QuickStats.aspx" Text="Quick Stats" Value="Quick Stats">
                        </asp:MenuItem>
                        <asp:MenuItem NavigateUrl="~/Utilities/DropOldUnusedBatches.aspx" Text="Drop Old Unused Batches"
                            Value="Selected Names For Register"></asp:MenuItem>
                        <asp:MenuItem NavigateUrl="~/Utilities/ReprintCertLockUnlock.aspx" Text="Reprint Certificates"
                            Value="Reprint ,Lock Certs"></asp:MenuItem>
                        <asp:MenuItem Text="Event Diary" Value="Event Diary">
                            <asp:MenuItem NavigateUrl="~/frmEventDiary.aspx" Text="Create Event" Value="Create Event">
                            </asp:MenuItem>
                            <asp:MenuItem NavigateUrl="~/frmViewEvents.aspx" Text="View Event" Value="View Event">
                            </asp:MenuItem>
                        </asp:MenuItem>
                        <asp:MenuItem NavigateUrl="~/Utilities/changeCertNo.aspx" Text="Change Certificate Number"
                            Value="Change Certificate Number"></asp:MenuItem>
                        <asp:MenuItem NavigateUrl="~/Utilities/DeleteProcessedBatchRef.aspx" Text="Reverse Processed Batch"
                            Value="Reverse Processed Batch"></asp:MenuItem>
                    </asp:MenuItem>
                    <asp:MenuItem Text=" " Value="13" ImageUrl="~/img/menuUsermanage.jpg" ToolTip="User Management">
                        <asp:MenuItem NavigateUrl="~/adminLogin.aspx" Text="Add User" Value="Add User"></asp:MenuItem>
                        <asp:MenuItem></asp:MenuItem>
                    </asp:MenuItem>
                    <asp:MenuItem Text=" " Value="14" ImageUrl="~/img/menuUpdate.jpg" ToolTip="Update">
                        <asp:MenuItem NavigateUrl="~/Update/UpdateReport.aspx" Text="Update Report" Value="Update Report">
                        </asp:MenuItem>
                        <asp:MenuItem NavigateUrl="~/Update/SelectForUpdateaspx.aspx" Text="Select For Update"
                            Value="Select For Update"></asp:MenuItem>
                        <asp:MenuItem NavigateUrl="~/Update/SpecialBatchVerification.aspx" 
                            Text="Special Batch Verifications" Value="Special Batch Verifications">
                        </asp:MenuItem>
                    </asp:MenuItem>
                    <asp:MenuItem Text=" " Value="15" ImageUrl="~/img/menuOcr.jpg" ToolTip="OCR">
                        <asp:MenuItem NavigateUrl="~/Document.aspx" Text="Document" Value="Document"></asp:MenuItem>
                        <asp:MenuItem NavigateUrl="~/RetrieveImage.aspx" Text="Search Document" Value="Search Document">
                        </asp:MenuItem>
                    </asp:MenuItem>
                    <asp:MenuItem Text=" " Value="17" NavigateUrl="~/varifications.aspx" ImageUrl="~/img/menuverification.jpg"
                        ToolTip="Verification">
                        <asp:MenuItem Text="Verification" Value="Verification" NavigateUrl="~/varifications.aspx">
                        </asp:MenuItem>
                        <asp:MenuItem NavigateUrl="~/verificationReport.aspx" Text="Verification Report"
                            Value="Verification Report"></asp:MenuItem>
                        <asp:MenuItem NavigateUrl="~/VeriFiedCertEnquiry.aspx" Text="Verification Enquiry"
                            Value="Verification Enquiry"></asp:MenuItem>
                    </asp:MenuItem>
                    <asp:MenuItem Text=" " Value="18" ImageUrl="~/img/menurTS.jpg" ToolTip="RTS">
                        <asp:MenuItem NavigateUrl="~/Utilities/MailReturn.aspx" Text="Mail Return" Value="Mail Return">
                        </asp:MenuItem>
                        <asp:MenuItem NavigateUrl="~/Utilities/MailReturnEnquiry.aspx" Text="Mail Return Enquiry"
                            Value="Mail Return Enquiry"></asp:MenuItem>
                        <asp:MenuItem NavigateUrl="~/Utilities/MailReturnRPTForm.aspx" Text="Mail Return Report"
                            Value="Mail Return Report"></asp:MenuItem>
                        <asp:MenuItem NavigateUrl="~/Utilities/MailRetursCollected.aspx" Text="Mail Collections"
                            Value="Mail Collections"></asp:MenuItem>
                    </asp:MenuItem>
                    <asp:MenuItem Text=" " Value="19" NavigateUrl="~/Standard Correspondence/MailMergeReport.aspx"
                        ImageUrl="~/img/menustandard.jpg" ToolTip="Standard  Correspondence">
                        <asp:MenuItem Text="Mail Merge" Value="Mail Merge" NavigateUrl="~/Standard Correspondence/Mail Merge.aspx">
                        </asp:MenuItem>
                        <asp:MenuItem NavigateUrl="~/Standard Correspondence/MailMergeReport.aspx" Text="Print Mails"
                            Value="Print Mails"></asp:MenuItem>
                    </asp:MenuItem>
                    <asp:MenuItem Text=" " Value="20" ImageUrl="~/img/menulocks.jpg" ToolTip="Locks">
                        <asp:MenuItem NavigateUrl="~/Utilities/LianUpdate.aspx" Text="Lien/Lock &amp; Unlock Certificate"
                            Value="Lien/Lock &amp; Unlock Certificate"></asp:MenuItem>
                        <asp:MenuItem NavigateUrl="~/Utilities/BlockUnBlockAccounts.aspx" Text="Block/Unblock Account"
                            Value="Block/Unblock Account"></asp:MenuItem>
                        <asp:MenuItem NavigateUrl="~/Utilities/LianUpdaterpt.aspx" Text="Locked Accounts Report"
                            Value="Locked Accounts Report"></asp:MenuItem>
                    </asp:MenuItem>
                    <asp:MenuItem Text="Scheme Arrangement" Value="25">
                        <asp:MenuItem NavigateUrl="~/Scheme/CreateScheme.aspx" 
                            Text="Scheme Instructions" Value="Scheme Instructions"></asp:MenuItem>
                        <asp:MenuItem NavigateUrl="~/Scheme/ViewSchemeInstr.aspx" 
                            Text="Instructions Report" Value="Instructions Report"></asp:MenuItem>
                        <asp:MenuItem NavigateUrl="~/Scheme/SchemeInstr.aspx" Text="Create Scheme" 
                            Value="Create Scheme"></asp:MenuItem>
                        <asp:MenuItem NavigateUrl="~/Scheme/SchemeOfferSchd.aspx" 
                            Text="Scheme Schedule" Value="Scheme Schedule"></asp:MenuItem>
                        <asp:MenuItem Text="LE Statements" Value="LE Statements" 
                            NavigateUrl="~/Scheme/SchemeLEltr.aspx"></asp:MenuItem>
                        <asp:MenuItem Text="Acceptance" Value="Acceptance" 
                            NavigateUrl="~/Scheme/frmAccept.aspx"></asp:MenuItem>
                        <asp:MenuItem Text="Acceptance Schedule" Value="Acceptance Schedule" 
                            NavigateUrl="~/Scheme/SchemeAcceptence.aspx">
                        </asp:MenuItem>
                        <asp:MenuItem Text="Batch Reports" Value="Batch Reports" 
                            NavigateUrl="~/Scheme/Schemebatchprint.aspx"></asp:MenuItem>
                        <asp:MenuItem Text="Production Stats" Value="Production Stats" 
                            NavigateUrl="~/Scheme/ProductionStats.aspx"></asp:MenuItem>
                        <asp:MenuItem Text="Create Scheme Batch" Value="Create Scheme Batch" 
                            NavigateUrl="~/Scheme/BatchBalance.aspx">
                        </asp:MenuItem>
                        <asp:MenuItem Text="Print Labels" Value="Print Labels" 
                            NavigateUrl="~/Scheme/frmPrintSchemeLabels.aspx"></asp:MenuItem>
                        <asp:MenuItem Text="Create Cheque Number" Value="Create Cheque Number" 
                            NavigateUrl="~/Scheme/CreateSchCheqNumber.aspx">
                        </asp:MenuItem>
                        <asp:MenuItem Text="Print Cheques" Value="Print Cheques" 
                            NavigateUrl="~/Scheme/PrintCheques.aspx"></asp:MenuItem>
                        <asp:MenuItem Text="Create EFT" Value="Create EFT" 
                            NavigateUrl="~/Scheme/CreateEFT.aspx"></asp:MenuItem>
                    </asp:MenuItem>
                </Items>
                <StaticHoverStyle BackColor="#D8E4F8" />
            </asp:Menu>
            &nbsp;
        </td>
    </tr>
</table>
<asp:Label ID="lblName" runat="server" Visible="False"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp; 