<%@ Page Language="VB" MasterPageFile="~/CDSUser.master" AutoEventWireup="false" CodeFile="BatchSummary.aspx.vb" Inherits="Reporting_BatchSummary" title="Batching Report" %>
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
                        Text="Batch Summary Reporting" width="848px"></asp:Label></td>
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
                    <td style="width: 146px; height: 40px;">
                        <asp:Label id="Label5" runat="server" Text="Print Options" font-names="Verdana" font-size="Small"></asp:Label></td>
                        <td style="width: 3px; height: 40px;">
                            <asp:RadioButton id="RdInd" runat="server" font-names="Verdana" font-size="Small"
                                Text="Batch Selection" width="128px" GroupName="Classifiction" /></td>
                            <td style="width: 3px; height: 40px;">
                                <asp:RadioButton id="rdJoint" runat="server" font-names="Verdana" font-size="Small"
                                    Text="All Batches" width="120px" GroupName="Classifiction" /></td>
                                <td style="height: 40px">
                                    </td>
                                    <td style="width: 90px; height: 40px;">
                                        </td>
                                            <td style="width: 141px; height: 40px;">
                                        </td>
                </tr> 
                <tr>
                    <td>
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

