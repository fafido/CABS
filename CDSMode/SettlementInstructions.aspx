﻿<%@ Page Language="VB" MasterPageFile="~/CDSMain.master" AutoEventWireup="false" CodeFile="SettlementInstructions.aspx.vb" Inherits="CDSMode_SettlementInstructions" title="Untitled Page" %>

<asp:Content id="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="border-right: #000033 thin solid; border-top: #000033 thin solid; border-left: #000033 thin solid; width: 832px; border-bottom: #000033 thin solid; background-color: #ffffff" 
            __designer:mapid="21f">
        <tr align="center" __designer:mapid="220">
            <td style="width: 712px; height: 226px" valign="top" __designer:mapid="221">
                <table __designer:mapid="222">
                    <tr __designer:mapid="223">
                        <td style="width: 870px" align="center" __designer:mapid="224">
                            <asp:Label id="Label4" runat="server" backcolor="#8080FF" font-bold="True" font-names="Arial"
                        Text="Settlement Instructions" width="848px"></asp:Label>
                        </td>
                    </tr>
                </table>
                <table __designer:mapid="226" style="width: 375px">
                    <tr __designer:mapid="227">
                        <td align="left" __designer:mapid="228" style="width: 225px">
                            <asp:Label id="Label1" runat="server" Text="Settlement Duration" font-names="Arial" 
                            font-size="Small"></asp:Label>
                        </td>
                        <td __designer:mapid="22a">
                            <asp:Label id="Label11" runat="server" Text="T +"></asp:Label>
                            <asp:DropDownList id="DropDownList1" runat="server" autopostback="True" 
                                width="40px">
                                <asp:ListItem>1</asp:ListItem>
                                <asp:ListItem>2</asp:ListItem>
                                <asp:ListItem>3</asp:ListItem>
                                <asp:ListItem>4</asp:ListItem>
                                <asp:ListItem>5</asp:ListItem>
                                <asp:ListItem>6</asp:ListItem>
                                <asp:ListItem>7</asp:ListItem>
                            </asp:DropDownList>
                            <asp:Label id="Label12" runat="server" Text="(days)"></asp:Label>
                        </td>
                    </tr>
                    <tr __designer:mapid="22c">
                        <td align="left" __designer:mapid="22d" style="width: 225px">
                            &nbsp;</td>
                        <td __designer:mapid="22f" style="text-align: left">
                            &nbsp;</td>
                    </tr>
                    <tr __designer:mapid="22c">
                        <td align="left" __designer:mapid="22d" style="width: 225px">
                            &nbsp;</td>
                        <td __designer:mapid="22f" style="text-align: left">
                            &nbsp;</td>
                    </tr>
                    <tr __designer:mapid="22c">
                        <td align="left" __designer:mapid="22d" style="width: 225px">
                            &nbsp;</td>
                        <td __designer:mapid="22f" style="text-align: left">
                            &nbsp;</td>
                    </tr>
                    <tr __designer:mapid="231">
                        <td align="left" __designer:mapid="232" colspan="2" style="text-align: center">
                            <asp:Button id="btnSave" runat="server" Text="Save" width="64px" 
                                style="height: 26px; text-align: center" />
                        </td>
                    </tr>
                </table>
                <table __designer:mapid="249">
                    <tr __designer:mapid="24a">
                        <td colspan="3" align="center" bgcolor="#8080ff" style="height: 13px" 
                        __designer:mapid="24b">
                            <asp:Label id="Label10" runat="server" 
                            Text="..................................................................................................................................................................................................." 
                            width="848px"></asp:Label>
                        </td>
                    </tr>
                    <tr __designer:mapid="24d">
                        <td colspan ="1" style="width: 147px" __designer:mapid="24e">
                        </td>
                        <td __designer:mapid="24f">
                            &nbsp;</td>
                        <td colspan ="1" style="width: 424px" __designer:mapid="252">
                        </td>
                    </tr>
                </table>
                <table __designer:mapid="253">
                    <tr __designer:mapid="254">
                        <td style="width: 850px" align="center" __designer:mapid="255">
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>

