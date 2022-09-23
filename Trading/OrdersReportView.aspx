<%@ Page Language="VB" MasterPageFile="~/CDSUser.master" AutoEventWireup="false" CodeFile="OrdersReportView.aspx.vb" Inherits="Trading_OrdersReportView" title="Orders Reporting" %>

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
                        Text="Placed orders Summary" width="848px"></asp:Label></td>
            </tr>
                <tr>
                    <td colspan ="4" valign="top">
                        &nbsp;</td>
                </tr>
                
            </table>
            <table>
            <tr>
                    <td style="width: 146px">
                        <asp:Label id="Label8" runat="server" Text="Company" font-names="Verdana" 
                            font-size="Small"></asp:Label></td>
                        <td style="width: 117px">
                            <asp:DropDownList ID="cmbCountry" runat="server" Width="200px">
                            </asp:DropDownList>
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
                        <asp:Label id="Label5" runat="server" Text="Orders as at" font-names="Verdana" 
                            font-size="Small"></asp:Label></td>
                        <td style="width: 117px">
                            <BDP:BasicDatePicker id="BasicDatePicker2" runat="server" ReadOnly="True" 
                                Width="200px">
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
                        &nbsp;</td>
                        <td  colspan ="4">
                            <asp:RadioButton id="rdCleared" runat="server" autopostback="True" 
                                groupname="OrdersType" text="Cleared Orders" />
                            <asp:RadioButton id="rdUnCleared" runat="server" autopostback="True" 
                                goupname="OrdersType" text="uncleared Orders" GroupName="OrdersType" />
                    </td>
                            
                                
                </tr>                
            </table>
            <table>
                <tr>
                    <td style="width: 146px">
                        </td>
                    <td style="width: 192px">
                        <asp:Button id="btnSelect" runat="server" Text="View Orders" /></td>
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

