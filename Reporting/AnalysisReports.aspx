<%@ Page Language="VB" MasterPageFile="~/CDSUser.master" AutoEventWireup="false" CodeFile="AnalysisReports.aspx.vb" Inherits="Reporting_AnalysisReports" title="Analysis Reports" %>
<%@ Register assembly="BasicFrame.WebControls.BasicDatePicker" namespace="BasicFrame.WebControls" tagprefix="BDP" %>
<asp:Content id="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div>
    <asp:Panel id="Panel1" runat="server">
    
<table style="border-right: #000033 thin solid; border-top: #000033 thin solid; border-left: #000033 thin solid; width: 832px; border-bottom: #000033 thin solid; background-color: #ffffff">
    <tr>
        <td style="width: 712px; height: 226px" valign="top">
            <table>
            <tr>
                <td style="width: 870px" align="center">
                    <asp:Label id="Label4" runat="server" backcolor="#8080FF" font-bold="True" font-names="Arial"
                        Text="Analysis Reports" width="848px"></asp:Label></td>
            </tr>
                <tr>
                    <td colspan ="4" valign="top" style="height: 24px">
                        <asp:Label id="Label1" runat="server" Text="Company" width="144px" font-names="Verdana" font-size="Small"></asp:Label>&nbsp;<asp:DropDownList
                            id="cmbCompany" runat="server" width="192px" autopostback="True">
                        </asp:DropDownList></td>
                </tr>
                
            </table>
            <table>
                <tr>
                    <td style="width: 172px; height: 40px;">
                        <asp:Label id="Label5" runat="server" Text="Print Options" font-names="Verdana" font-size="Small"></asp:Label></td>
                        <td style="width: 3px; height: 40px;">
                            <asp:RadioButton id="RdInd" runat="server" font-names="Verdana" font-size="Small"
                                Text="Trade Reports" width="128px" GroupName="Classifiction" /></td>
                            <td style="width: 3px; height: 40px;">
                                <asp:RadioButton id="rdJoint" runat="server" font-names="Verdana" font-size="Small"
                                    Text="Company Schedule Reports" width="224px" GroupName="Classifiction" /></td>
                                <td style="height: 40px; width: 34px;">
                                    <asp:RadioButton id="rdJoint0" runat="server" font-names="Verdana" 
                                        font-size="Small" GroupName="Classifiction" Text="Transaction Reports" 
                                        width="224px" />
                                    </td>
                                    <td style="width: 90px; height: 40px;">
                                        <asp:RadioButton id="rdJoint1" runat="server" font-names="Verdana" 
                                            font-size="Small" GroupName="Classifiction" Text="Client Analysis Reports" 
                                            width="224px" />
                                        </td>
                                            <td style="width: 141px; height: 40px;">
                                                <asp:RadioButton id="rdJoint2" runat="server" font-names="Verdana" 
                                                    font-size="Small" GroupName="Classifiction" Text="Fee Transaction Reports" 
                                                    width="224px" />
                                        </td>
                </tr> 
                
                 <tr>
                    <td style="width: 250px; height: 40px;">
                        <asp:Label id="Label7" runat="server" Text="Date Ranges" width ="146px" 
                            font-names="Verdana" font-size="Small"></asp:Label></td>
                        <td style="width: 3px; height: 40px;">
                            <asp:Label id="Label8" width ="100px" runat="server" Text="Date From"></asp:Label>
                     </td>
                            <td style="width: 3px; height: 40px; margin-left: 40px;">
                                <BDP:BasicDatePicker id="BasicDatePicker1" width ="120px" runat="server" />
                     </td>
                                <td style="height: 40px; width: 34px;">
                                    <asp:Label id="Label9" runat="server" Text="Date To" width="100px"></asp:Label>
                     </td>
                                    <td style="width: 90px; height: 40px;">
                                        <BDP:BasicDatePicker id="BasicDatePicker2" runat="server" width="120px" />
                     </td>
                                            <td style="width: 141px; height: 40px;">
                                                &nbsp;</td>
                </tr> 
                
                 <tr>
                    <td style="width: 250px; height: 40px;">
                        <asp:Label id="Label3" runat="server" Text="Sub Options" width ="146px" 
                            font-names="Verdana" font-size="Small"></asp:Label></td>
                        <td style="width: 3px; height: 40px;">
                            <asp:RadioButton id="RadioButton1" runat="server" font-names="Verdana" font-size="Small"
                                Text="Trade Settlement" width="201px" GroupName="Trading" /></td>
                            <td style="width: 3px; height: 40px;">
                                <asp:RadioButton id="RadioButton2" runat="server" font-names="Verdana" 
                                    font-size="Small" GroupName="Trading" Text="Trade Details" width="201px" />
                     </td>
                                <td style="height: 40px; width: 34px;">
                                    <asp:RadioButton id="RadioButton3" runat="server" font-names="Verdana" 
                                        font-size="Small" GroupName="Trading" 
                                        Text="Trade Amendments &amp; Cancellations" width="201px" />
                     </td>
                                    <td style="width: 90px; height: 40px;">
                                        <asp:RadioButton id="RadioButton4" runat="server" font-names="Verdana" 
                                            font-size="Small" GroupName="Trading" Text="Failed Trades" width="201px" />
                     </td>
                                            <td style="width: 141px; height: 40px;">
                                                <asp:RadioButton id="RadioButton5" runat="server" font-names="Verdana" 
                                                    font-size="Small" GroupName="Trading" Text="Unallocated Trades" width="201px" />
                     </td>
                </tr> 
                <tr>
                    <td style="width: 250px; height: 40px;">
                        <asp:Label id="Label6" runat="server" Text="Sub Options" width ="146px" 
                            font-names="Verdana" font-size="Small"></asp:Label></td>
                        <td style="width: 3px; height: 40px;">
                            <asp:RadioButton id="RadioButton6" runat="server" font-names="Verdana" font-size="Small"
                                Text="Certificates" width="201px" GroupName="Transactions" /></td>
                            <td style="width: 3px; height: 40px;">
                                <asp:RadioButton id="RadioButton7" runat="server" font-names="Verdana" 
                                    font-size="Small" GroupName="Transactions" Text="Immobilizations" width="201px" />
                     </td>
                                <td style="height: 40px; width: 34px;">
                                    <asp:RadioButton id="RadioButton8" runat="server" font-names="Verdana" 
                                        font-size="Small" GroupName="Transactions" Text="Allotments" width="201px" />
                    </td>
                                    <td style="width: 90px; height: 40px;">
                                        <asp:RadioButton id="RadioButton9" runat="server" font-names="Verdana" 
                                            font-size="Small" GroupName="Transactions" Text="Withdrawals" width="201px" />
                    </td>
                                            <td style="width: 141px; height: 40px;">
                                                <asp:RadioButton id="RadioButton10" runat="server" font-names="Verdana" 
                                                    font-size="Small" GroupName="Transactions" Text="Transfers" width="201px" />
                    </td>
                </tr>
                <tr>
                    <td style="width: 172px">
                        <asp:Label id="Label2" runat="server" font-names="Verdana" font-size="Small" Text="Batch Number"></asp:Label></td>
                    <td>
                        <asp:TextBox id="txtBatching" runat="server"></asp:TextBox></td>
                </tr>               
            </table>
            <table>
                <tr>
                    <td style="width: 146px">
                        </td>
                    <td style="width: 192px" align="center">
                        <asp:Button id="btnSelect" runat="server" Text="Print Report" /></td>
                </tr>
                <tr>
                    <td style="width: 146px">
                        </td>
                    <td style="width: 192px">
                        </td>
                </tr>
                <tr>
                    <td style="width: 146px">
                        </td>
                    <td style="width: 192px">
                        </td>
                </tr>
                <tr>
                    <td></td>
                    <td align="center" style="width: 192px">
                        </td>
                </tr>
                <tr>
                    <td></td>
                    <td style="width: 192px">
                        </td>
                </tr>
            </table>
            <table>
            <tr>
                    <td colspan ="4" style="width: 850px" align="center">
                        &nbsp;</td>                
                </tr>
                <tr>
                    <td colspan ="4" style="width: 850px" align="center">
                        </td>                
                </tr>
            </table>
        </td>
    </tr>
</table>
</asp:Panel>
</div>
</asp:Content>

