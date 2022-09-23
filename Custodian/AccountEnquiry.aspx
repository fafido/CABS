<%@ Page Language="VB" MasterPageFile="~/CDSUser.master" AutoEventWireup="false" CodeFile="AccountEnquiry.aspx.vb" Inherits="Custodian_AccountEnquiry" title="Account Details Enquiry" %>
<asp:Content id="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
    <asp:Panel id="Panel1" runat="server">
    
<table style="border-right: #000033 thin solid; border-top: #000033 thin solid; border-left: #000033 thin solid; width: 832px; border-bottom: #000033 thin solid; background-color: #ffffff">
    <tr>
        <td style="width: 712px; height: 226px" valign="top">
            <table>
            <tr>
                <td>
                    <asp:Label id="lblsitemap" runat="server"></asp:Label></td>
            </tr>
            <tr>
                <td style="width: 870px" align="center">
                    <asp:Label id="Label4" runat="server" backcolor="#8080FF" font-bold="True" font-names="Arial"
                        Text="Register Accounts  Enquiry" width="848px" Height="16px"></asp:Label></td>
            </tr>
            <tr>
                    <td colspan ="4" valign="top">
                        &nbsp;</td>
                </tr>
                
            </table>
            <table>
                <tr>
                    <td style="width: 162px; height: 30px;">
                        &nbsp;</td>
                        <td style="width: 3px; height: 30px;">
                            <asp:TextBox id="txtshareholder" runat="server" Width="140px"></asp:TextBox>
                    </td>
                            <td style="width: 3px; height: 30px;">
                                <asp:Button id="btnHolderNumSearch" runat="server" Text="&gt;&gt;" Visible="False" />
                    </td>
                                <td style="height: 30px">
                                    </td>
                                    <td style="width: 141px; height: 30px;">
                                        </td>
                </tr>                
                <tr>
                    <td style="width: 162px">
                        <asp:Label id="Label5" runat="server" font-names="Verdana" font-size="Small" 
                            Text="Shareholder Name:"></asp:Label>
                    </td>
                    <td style="width: 3px">
                        <asp:TextBox id="txtSearch" runat="server" width="144px"></asp:TextBox>
                    </td>
                    <td style="width: 3px">
                        <asp:Button id="btnSearchName" runat="server" Text="&gt;&gt;" BackColor="#666666" ForeColor="White" />
                    </td>
                    <td>
                    </td>
                    <td style="width: 141px">
                    </td>
                </tr>
            </table>
            <table>
                <tr>
                    <td style="width: 162px"></td>
                    <td style="width: 148px">
                        <asp:ListBox id="lstNames" runat="server" Height="63px" width="277px" 
                            autopostback="True"></asp:ListBox></td>
                </tr>
                <tr>
                    <td style="width: 162px"></td>
                    <td align="center">
                        <asp:Button id="btnSelect" runat="server" Text="Select" Visible="False" /></td>
                </tr>
                <tr>
                    <td style="width: 162px"></td>
                    <td align ="center">
                    <asp:Button id="btnPrintStatement" runat="server" Text="Print Account Statement" BackColor="#666666" ForeColor="White"></asp:Button></td>
                </tr>
            </table>
            <table>
                <tr>
                    <td colspan ="1" style="width: 147px">
                        </td>
                        <td colspan="1" style="width: 203px">
                            </td>
                            <td colspan ="1" style="width: 172px">
                                </td>
                                <td colspan ="1" style="width: 316px">
                                    </td>
                </tr>
                
            </table>
            <table>
            <tr>
                <td colspan ="4" style=" width : 850px" align ="center">
                    &nbsp;</td>
            </tr>
                <tr>
                    <td colspan ="4" style="width: 850px" align="center">
                        <asp:GridView id="gdPortfolioResults" runat="server" width="584px">
                        </asp:GridView>
                        </td>                
                </tr>
            </table>
        </td>
    </tr>
</table>
</asp:Panel>
</div>
</asp:Content>

