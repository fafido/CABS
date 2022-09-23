<%@ Page Language="VB" MasterPageFile="~/CDSUser.master" AutoEventWireup="false" CodeFile="StaleTrades.aspx.vb" Inherits="Trading_StaleTrades" title="Order Amendments Form" %>

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
                        Text="Trading Statistics" width="848px"></asp:Label></td>
            </tr>
            <tr>
                <td>
                    <asp:Label id="Label3" runat="server" Text="Trading Report Type:" font-names="Verdana" font-size="Small"></asp:Label>
                        <asp:RadioButton id="rdPurchase" runat="server" font-names="Verdana" font-size="Small" GroupName="OrderType" Text="Purchases" />
                            <asp:RadioButton id="rdSales" runat="server" font-names="Verdana" font-size="Small" GroupName="OrderType" Text="Sales" />
                    &nbsp;<asp:RadioButton id="rdAll" runat="server" font-names="Verdana" font-size="Small"
                        GroupName="OrderType" Text="All Trades" />
                    <asp:RadioButton id="rdHolderStats" runat="server" font-names="Verdana" font-size="Small"
                        GroupName="OrderType" Text="Holder Statistics" /></td>                    
            </tr>
            <tr>
                    <td colspan ="4" valign="top">
                        <asp:Label id="Label1" runat="server" Text="Shareholder Number:" width="144px" font-names="Verdana" font-size="Small"></asp:Label>
                        <asp:TextBox id="txtshareholder" runat="server"></asp:TextBox>
                        <asp:Button id="btnHolderNumSearch" runat="server" Text=">>" /></td>
                </tr>
                
            </table>
            <table>
                <tr>
                    <td style="width: 146px">
                        <asp:Label id="Label5" runat="server" Text="Shareholder Name:" font-names="Verdana" font-size="Small"></asp:Label></td>
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
                    <td style="width: 146px"></td>
                    <td style="width: 148px">
                        <asp:ListBox id="ListBox1" runat="server" Height="136px" width="328px"></asp:ListBox></td>
                </tr>
                <tr>
                    <td></td>
                    <td align="center">
                        <asp:Button id="btnSelect" runat="server" Text="Select" /></td>
                </tr>
                <tr>
                    <td>
                        <asp:Label id="Label11" runat="server" Text="Trade Date"></asp:Label></td>
                    <td>
                        <BDP:BasicDatePicker id="BasicDatePicker1" runat="server">
                        </BDP:BasicDatePicker>
                        </td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <asp:Button id="btnViewStats" runat="server" Text="View Statistics" /><asp:Button
                            id="BtnPrintStats" runat="server" Text="Print Statistics Report" /></td>
                </tr>
            </table>
            <table>
            <tr>
                    <td colspan="6" align="center" bgcolor="#8080ff">
                        <asp:Label id="Label12" runat="server" Text="..................................................................................................................................................................................................." width="832px"></asp:Label></td>
                </tr>            
                <tr>
                  <td colspan ="4">
                      <asp:GridView id="GdStatisticsView" runat="server" Height="120px" width="832px">
                          <RowStyle font-names="Verdana" font-size="Small" />
                          <HeaderStyle font-bold="True" font-names="Calibri" font-size="Medium" Font-Underline="True"
                              forecolor="#0000C0" HorizontalAlign="Left" />
                      </asp:GridView>
                  </td>  
                </tr>
                <tr>
                    <td colspan="6" align="center" bgcolor="#8080ff">
                        <asp:Label id="Label10" runat="server" Text="..................................................................................................................................................................................................." width="832px"></asp:Label></td>
                </tr>
                <tr>
                    <td colspan ="1" style="width: 147px">
                        </td>
                        <td colspan="1" style="width: 203px">
                            </td>
                            <td colspan ="1" style="width: 172px">
                                </td>
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

