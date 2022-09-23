<%@ Page Language="VB" MasterPageFile="~/Tsec.master" AutoEventWireup="false" CodeFile="TradesExportFile.aspx.vb" Inherits="Trading_TradesExportFile" title="Trades File Generation" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<%@ Register Assembly="BasicFrame.WebControls.BasicDatePicker" Namespace="BasicFrame.WebControls"
    TagPrefix="BDP" %>
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
                        Text="Trades Export File Generation" width="848px"></asp:Label></td>
            </tr>
                <tr>
                    <td colspan ="4" valign="top">
                        &nbsp;</td>
                </tr>
                
            </table>
            <table>
            <tr>
                    <td style="width: 146px">
                        <asp:Label id="Label8" runat="server" Text="Trade Date From" font-names="Verdana" font-size="Small"></asp:Label></td>
                        <td style="width: 117px">
                            <BDP:BasicDatePicker id="BasicDatePicker1" runat="server" ReadOnly="True">
                            </BDP:BasicDatePicker>
                        </td>
                            <td style="width: 3px">
                                </td>
                                <td>
                                    </td>
                                    <td style="width: 141px">
                                        </td>
                </tr>                
                <tr>
                    <td style="width: 146px">
                        <asp:Label id="Label5" runat="server" Text="Trade Date To" font-names="Verdana" font-size="Small"></asp:Label></td>
                        <td style="width: 117px">
                            <BDP:BasicDatePicker id="BasicDatePicker2" runat="server" ReadOnly="True">
                            </BDP:BasicDatePicker>
                        </td>
                            <td style="width: 3px">
                                </td>
                                <td>
                                    </td>
                                    <td style="width: 141px">
                                        </td>
                </tr>                
                <tr>
                    <td style="width: 146px; height: 21px;">
                        <asp:Label id="Label2" runat="server" font-names="Verdana" font-size="Small" Text="File Name"></asp:Label></td>
                        <td style="width: 117px; height: 21px;">
                        <asp:TextBox id="txtFileName" runat="server"></asp:TextBox></td>
                            <td style="width: 3px; height: 21px;">
                                </td>
                                <td style="height: 21px">
                                    </td>
                                    <td style="width: 141px; height: 21px;">
                                        </td>
                </tr>                
            </table>
            <table>
                <tr>
                    <td style="width: 146px">
                        </td>
                    <td style="width: 192px">
                        <asp:Button id="btnSelect" runat="server" Text="Create File" /></td>
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

