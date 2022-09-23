<%@ Page Language="VB" MasterPageFile="~/CDSUser.master" AutoEventWireup="false" CodeFile="BrokerNewsBoard.aspx.vb" Inherits="BrokerMode_BrokerNewsBoard" title="Newz Board" %>
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
                        Text="Newz, Events Update" width="848px"></asp:Label></td>
            </tr>
                <tr>
                    <td colspan ="4" valign="top">
                        <asp:Label id="Label1" runat="server" Text="Date" width="144px" font-names="Verdana" font-size="Small"></asp:Label>
                        <asp:Label id="lblDtate" runat="server" font-names="Verdana" font-size="Small"></asp:Label></td>
                </tr>
                
            </table>
            <table>
                <tr>
                    <td style="width: 143px">
                        </td>
                        <td style="width: 2px">
                            <asp:Label id="lblNewzStatus" runat="server" font-names="Arial" font-size="Small"
                                forecolor="Red" width="312px"></asp:Label></td>
                            <td>
                                </td>
                                <td>
                                    </td>
                                    <td style="width: 141px">
                                        </td>
                </tr>
            </table>
            <table style="width: 856px">
                <tr>
                    <td colspan ="1" style="width: 175px">
                        <asp:GridView id="gdNewzUpdate" runat="server" font-names="Arial" font-size="Small"
                            ShowFooter="True" width="848px">
                            <HeaderStyle backcolor="#0000C0" BorderColor="White" BorderStyle="Solid" font-bold="True"
                                font-names="Verdana" font-size="Small" forecolor="White" />
                            <EditRowStyle font-names="Arial" font-size="Small" />
                        </asp:GridView>
                        </td>                        
                </tr>               
                
            </table>
            <table>
                <tr>
                    <td colspan ="4" style="width: 957px" align="center">
                        </td>                
                </tr>
            </table>
        </td>
    </tr>
</table>
</asp:Panel>
</div>
</asp:Content>

