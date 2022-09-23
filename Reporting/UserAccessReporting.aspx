<%@ Page Language="VB" MasterPageFile="~/CDSUser.master" AutoEventWireup="false" CodeFile="UserAccessReporting.aspx.vb" Inherits="Reporting_BatchSummary" title="Batching Report" %>
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
                        Text="User Access Reporting" width="848px"></asp:Label></td>
            </tr>
                <tr>
                    <td colspan ="4" valign="top" style="height: 24px">
                        </td>
                </tr>
                
            </table>
            <table>
                <tr>
                    <td style="width: 172px; height: 26px;">
                        <asp:Label id="Label5" runat="server" Text="Search Account" font-names="Verdana" font-size="Small"></asp:Label></td>
                        <td style="width: 3px; height: 26px;">
                            <asp:TextBox id="txtAccountNum" runat="server"></asp:TextBox></td>
                            <td style="width: 3px; height: 26px;">
                                <asp:Button id="btnSearch" runat="server" Text=">>" /></td>
                                <td style="height: 26px">
                                    </td>
                                    <td style="width: 90px; height: 26px;">
                                        </td>
                                            <td style="width: 141px; height: 26px;">
                                        </td>
                </tr> 
                <tr>
                    <td style="height: 31px; width: 172px">
                        <asp:Label id="Label2" runat="server" font-names="Verdana" font-size="Small" Text="Scroll Account Search"></asp:Label></td>
                    <td style="height: 31px">
                        <asp:DropDownList id="cmbAccountScrol" runat="server" autopostback="True" width="152px">
                        </asp:DropDownList></td>
                </tr>               
            </table>
            <table>
                <tr>
                    <td style="width: 146px">
                        </td>
                    <td style="width: 432px" align="center">
                        </td>
                </tr>
                <tr>
                    <td style="width: 146px">
                        </td>
                    <td style="width: 432px" align="center">
                        <asp:Button id="btnSelect" runat="server" Text="Print Report" /></td>
                </tr>
                <tr>
                    <td style="width: 146px">
                        </td>
                    <td style="width: 432px">
                        </td>
                </tr>
                <tr>
                    <td></td>
                    <td align="center" style="width: 432px">
                        </td>
                </tr>
                <tr>
                    <td></td>
                    <td style="width: 432px">
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

