<%@ Page Language="VB" MasterPageFile="~/CDSUser.master" AutoEventWireup="false" CodeFile="frmTranTypes.aspx.vb" Inherits="Parameters_frmTranTypes" title="Untitled Page" %>

<asp:Content id="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="border-right: #000033 thin solid; border-top: #000033 thin solid; border-left: #000033 thin solid; width: 832px; border-bottom: #000033 thin solid; background-color: #ffffff" 
            __designer:mapid="182">
        <tr align="center" __designer:mapid="183">
            <td style="width: 712px; height: 226px" valign="top" __designer:mapid="184">
                <table __designer:mapid="185">
                    <tr __designer:mapid="186">
                        <td style="width: 870px" align="center" __designer:mapid="187">
                            <asp:Label id="Label4" runat="server" backcolor="#8080FF" font-bold="True" font-names="Arial"
                        Text="Transaction Types" width="848px"></asp:Label>
                        </td>
                    </tr>
                </table>
                <table __designer:mapid="189" style="font-family: Verdana; width: 304px">
                    <tr __designer:mapid="18a">
                        <td align="left" __designer:mapid="18b" colspan="2">
                            <asp:RadioButtonList id="RadioButtonList1" runat="server" Height="18px" 
                                RepeatDirection="Horizontal" style="text-align: center; font-size: small" 
                                Visible="False" width="260px">
                                <asp:ListItem>Edit</asp:ListItem>
                                <asp:ListItem>New</asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                    <tr __designer:mapid="18f">
                        <td align="left" __designer:mapid="190" style="width: 125px">
                            <asp:Label id="Label2" runat="server" Text="Code" font-names="Arial" 
                            font-size="Small"></asp:Label>
                        </td>
                        <td __designer:mapid="192">
                            <asp:TextBox id="txtCode" runat="server" width="165px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr __designer:mapid="194">
                        <td align="left" __designer:mapid="195" style="width: 125px">
                            <asp:Label id="Label3" runat="server" Text="Full Name" 
                            font-names="Arial" font-size="Small"></asp:Label>
                        </td>
                        <td __designer:mapid="197">
                            <asp:TextBox id="txtFname" runat="server" width="160px"></asp:TextBox>
                        </td>
                    </tr>
                </table>
                <table __designer:mapid="1a8">
                    <tr __designer:mapid="1a9">
                        <td style="width: 3px" __designer:mapid="1aa">
                            &nbsp;</td>
                    </tr>
                </table>
                <table __designer:mapid="1ac">
                    <tr __designer:mapid="1ad">
                        <td colspan="4" align="center" bgcolor="#8080ff" style="height: 13px" 
                        __designer:mapid="1ae">
                            <asp:Label id="Label10" runat="server" 
                            Text="..................................................................................................................................................................................................." 
                            width="848px"></asp:Label>
                        </td>
                    </tr>
                    <tr __designer:mapid="1b0">
                        <td colspan ="1" style="width: 147px" __designer:mapid="1b1">
                        </td>
                        <td colspan="1" style="width: 170px" __designer:mapid="1b2">
                        </td>
                        <td colspan ="1" style="width: 172px; text-align: left;" __designer:mapid="1b3">
                            <asp:Button id="btnSave" runat="server" Text="Save" width="64px" />
                        </td>
                        <td colspan ="1" style="width: 424px" __designer:mapid="1b5">
                        </td>
                    </tr>
                </table>
                <table __designer:mapid="1b6">
                    <tr __designer:mapid="1b7">
                        <td style="width: 850px" align="center" __designer:mapid="1b8">
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>

