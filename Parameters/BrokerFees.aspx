<%@ Page Language="VB" MasterPageFile="~/CDSUser.master" AutoEventWireup="false" CodeFile="BrokerFees.aspx.vb" Inherits="Parameters_BrokerFees" title="Brokerage Fee Maitenance" %>
<asp:Content id="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
    <asp:Panel id="Panel1" runat="server">
    
<table style="border-right: #000033 thin solid; border-top: #000033 thin solid; border-left: #000033 thin solid; width: 832px; border-bottom: #000033 thin solid; background-color: #ffffff">
    <tr align="center">
        <td style="width: 712px; height: 226px" valign="top">
            <table>
            <tr>
                <td style="width: 870px" align="center">
                    <asp:Label id="Label4" runat="server" backcolor="#8080FF" font-bold="True" font-names="Arial"
                        Text="Fee Maintenance" width="848px"></asp:Label></td>
            </tr>                
            </table>
            <table>
                <tr>
                    <td align="left">
                        <asp:Label id="Label1" runat="server" Text="Basic Fee" font-names="Arial" font-size="Small"></asp:Label></td>
                        <td>
                            <asp:TextBox id="txtBasicFee" runat="server"></asp:TextBox></td>
                </tr>    
                <tr>
                    <td align="left">
                        <asp:Label id="Label2" runat="server" Text="Revenue Stamp Duty" font-names="Arial" font-size="Small"></asp:Label></td>
                        <td>
                            <asp:TextBox id="txtStampDuty" runat="server"></asp:TextBox></td>
                </tr>            
                <tr>
                    <td align="left">
                        <asp:Label id="Label3" runat="server" Text="Purchase Registration" font-names="Arial" font-size="Small"></asp:Label></td>
                        <td>
                            <asp:TextBox id="txtPurchaseReg" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td align="left">
                        <asp:Label id="Label5" runat="server" Text="Minimum Brokerage" font-names="Arial" font-size="Small"></asp:Label></td>
                        <td>
                            <asp:TextBox id="txtMiniMumBrokerage" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td align="left">
                        <asp:Label id="Label6" runat="server" Text="Transfer Fees" font-names="Arial" font-size="Small"></asp:Label></td>
                        <td>
                            <asp:TextBox id="TxtTransferFees" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td align="left">
                        <asp:Label id="Label7" runat="server" Text="Withholding Tax" font-names="Arial" font-size="Small"></asp:Label></td>
                        <td>
                            <asp:TextBox id="txtWithholding" runat="server"></asp:TextBox></td>
                </tr>
            </table>
            <table>
                <tr>
                    <td style="width: 3px">
                        <asp:Label id="lblUpdateDate" runat="server" font-names="Arial" font-size="Small" width="328px"></asp:Label></td>
                </tr>
            </table>
            <table>
            <tr>                    
                    <td colspan="6" align="center" bgcolor="#8080ff" style="height: 13px">
                        <asp:Label id="Label10" runat="server" Text="..................................................................................................................................................................................................." width="848px"></asp:Label></td>
                </tr>
                <tr>
                    <td colspan ="1" style="width: 147px">
                        </td>
                        <td colspan="1" style="width: 203px">
                            </td>
                            <td colspan ="1" style="width: 172px">
                                <asp:Button id="btnPrintStatement" runat="server" Text="Save" width="64px" /></td>
                                <td colspan ="1" style="width: 424px">
                                    </td>
                </tr>
                               
            </table>
            <table>
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

