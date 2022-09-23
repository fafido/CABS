<%@ Page Language="VB" MasterPageFile="~/Tsec.master" AutoEventWireup="false" CodeFile="DividendSchdule.aspx.vb" Inherits="Pledges_PledgeEnquiry" title="Deposit Securities" %>
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
                        Text="Dividend Enquiry" width="848px"></asp:Label></td>
            </tr>
                <tr>
                    <td colspan ="4" valign="top">
                        <asp:Label id="Label1" runat="server" Text="Company" width="144px" font-names="Verdana" font-size="Small"></asp:Label>&nbsp;<asp:DropDownList
                            id="cmbCompany" runat="server" width="192px" autopostback="True">
                        </asp:DropDownList>
                        </td>
                       </tr>
                
            </table>
            <table>
            <tr>
                    <td style="width: 146px">
                        <asp:Label id="Label2" runat="server" Text="Dividend Number" font-names="Verdana" font-size="Small"></asp:Label></td>
                        <td style="width: 3px">
                            <asp:DropDownList id="cmbDividend" runat="server" width="152px">
                            </asp:DropDownList></td>
                            <td style="width: 3px">
                                </td>
                                <td>
                                    </td>
                                    <td style="width: 141px">
                                        </td>
                </tr>                
                <tr>
                    <td style="width: 146px">
                        <asp:Label id="Label5" runat="server" Text="Shareholder Number" font-names="Verdana" font-size="Small"></asp:Label></td>
                        <td style="width: 3px">
                            <asp:TextBox id="txtSearch" runat="server" width="144px"></asp:TextBox></td>
                            <td style="width: 3px">
                                <asp:Button id="btnSearchName" runat="server" Text=">>" /></td>
                                <td>
                                    </td>
                                    <td style="width: 141px">
                                        </td>
                </tr>                
            </table>
            
            <table>
            <tr>
                    <td colspan ="4" style="width: 850px" align="center">
                        <asp:GridView id="GdStatisticsView" runat="server" Height="120px" width="832px">
                            <RowStyle font-names="Verdana" font-size="Small" />
                            <HeaderStyle font-bold="True" font-names="Calibri" font-size="Medium" Font-Underline="True"
                                forecolor="#0000C0" HorizontalAlign="Left" />
                        </asp:GridView>
                    </td>                
                </tr>
                <tr>
                    <td colspan ="4" style="width: 850px" align="center">
                        <asp:Button id="btnSave" runat="server" Text="Print Report" width="96px" /></td>                
                </tr>
            </table>
        </td>
    </tr>
</table>
</asp:Panel>
</div>
</asp:Content>

