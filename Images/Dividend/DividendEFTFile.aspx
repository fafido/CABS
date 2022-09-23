<%@ Page Language="VB" MasterPageFile="~/Tsec.master" AutoEventWireup="false" CodeFile="DividendEFTFile.aspx.vb" Inherits="Dividend_DividendEFTFile" title="Dividend EFT File Generation" %>
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
                        Text="Dividend EFT File Generation" width="848px"></asp:Label></td>
            </tr>
                <tr>
                    <td colspan ="4" valign="top">
                        <asp:Label id="Label1" runat="server" Text="Company" width="144px" font-names="Verdana" font-size="Small"></asp:Label>&nbsp;<asp:DropDownList
                            id="cmbCompany" runat="server" width="192px" autopostback="True">
                        </asp:DropDownList></td>
                </tr>
                
            </table>
            <table>
                <tr>
                    <td style="width: 146px">
                        <asp:Label id="Label5" runat="server" Text="Dividend Number" font-names="Verdana" font-size="Small"></asp:Label></td>
                        <td style="width: 3px">
                            <asp:DropDownList id="cmbDividend" runat="server" width="192px">
                            </asp:DropDownList></td>
                            <td style="width: 3px">
                                </td>
                                <td>
                                    </td>
                                    <td style="width: 141px">
                                        </td>
                </tr>                
            </table>
            <table>
                <tr>
                    <td style="width: 146px">
                        <asp:Label id="Label2" runat="server" font-names="Verdana" font-size="Small" Text="File Name"></asp:Label></td>
                    <td style="width: 192px">
                        <asp:TextBox id="txtFileName" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="width: 146px">
                        <asp:Label id="Label3" runat="server" font-names="Verdana" font-size="Small"></asp:Label></td>
                    <td style="width: 192px">
                        <asp:TextBox id="txteft" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="width: 146px">
                        <asp:Label id="Label6" runat="server" font-names="Verdana" font-size="Small"></asp:Label></td>
                    <td style="width: 192px">
                        <asp:TextBox id="txteftholders" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td></td>
                    <td align="center" style="width: 192px">
                        <asp:Button id="btnSelect" runat="server" Text="Create File" /></td>
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

