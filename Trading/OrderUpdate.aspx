<%@ Page Language="VB" MasterPageFile="~/CDSUser.master" AutoEventWireup="false" CodeFile="OrderUpdate.aspx.vb" Inherits="Trading_OrderUpdate" title="Order Amendments Form" %>
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
                        Text="Order Amendment" width="848px"></asp:Label></td>
            </tr>
            <tr>
                <td>
                    <asp:Label id="Label3" runat="server" Text="Order Type:" font-names="Verdana" font-size="Small"></asp:Label>
                        <asp:RadioButton id="rdPurchase" runat="server" font-names="Verdana" font-size="Small" GroupName="OrderType" Text="Purchases" />
                            <asp:RadioButton id="rdSales" runat="server" font-names="Verdana" font-size="Small" GroupName="OrderType" Text="Sales" /></td>                    
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
                    <td></td>
                    <td>
                        </td>
                </tr>
            </table>
            <table>
            <tr>
                    <td>
                        <asp:Label id="Label2" runat="server" Text="Company" font-bold="False" font-names="Verdana" font-size="Small"></asp:Label></td>
                        <td>
                            <asp:DropDownList id="cmbCompany" runat="server" width="152px">
                            </asp:DropDownList></td>
                            <td align="right">
                                </td>
                            <td style="width: 424px">
                                </td>
                                    <td></td>
                                    <td></td>
                </tr> 
                <tr>
                    <td>
                        <asp:Label id="Label6" runat="server" Text="Order Number:" width="96px" font-bold="False" font-names="Verdana" font-size="Small"></asp:Label></td>
                    <td>
                        <asp:TextBox id="txtOrderNumber" runat="server"></asp:TextBox></td>
                    <td></td>
                    <td style="width: 424px">
                        <asp:Label id="Label8" runat="server" Text="  " width="192px"></asp:Label></td>
                    <td></td>
                    <td></td>
                </tr>
                <tr>
                    <td><asp:Label id="Label7" runat="server" font-size="Small" font-names="Verdana" font-bold="False" Text="Shareholder"></asp:Label></td>
                    <td><asp:TextBox id="TextBox1" runat="server"></asp:TextBox></td>
                    <td><asp:Label id="Label16" runat="server" width="104px" font-size="Small" font-names="Verdana" font-bold="False" Text="Order number"></asp:Label></td>
                    <td style="width: 424px"><asp:TextBox id="TextBox2" runat="server" ReadOnly="True" Enabled="False"></asp:TextBox></td>
                    <td><asp:Label id="Label26" runat="server" width="104px" font-size="Small" font-names="Verdana" font-bold="False" backcolor="Transparent">  Order Value</asp:Label></td>
                    <td><asp:TextBox id="TextBox3" runat="server" autopostback="true" ReadOnly="true" Enabled="false"></asp:TextBox></td>
                </tr>
                <tr>
                    <td><asp:Label id="Label33" runat="server" font-size="Small" font-names="Verdana" font-bold="False" Text="Broker Notes"></asp:Label></td>
                    <td><asp:TextBox id="TextBox4" runat="server"></asp:TextBox></td>
                    <td><asp:Label id="Label34" runat="server" font-size="Small" font-names="Verdana" font-bold="False" Text="Deal Ref"></asp:Label></td>
                    <td style="width: 424px"><asp:TextBox id="TextBox5" runat="server"></asp:TextBox></td>
                    <td><asp:Label id="Label35" runat="server" width="104px" font-size="Small" font-names="Verdana" font-bold="False" backcolor="Transparent">Account Type</asp:Label></td>
                    <td><asp:TextBox id="TextBox6" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td><asp:Label id="Label36" runat="server" font-size="Small" font-names="Verdana" font-bold="False" Text="Gross Amount"></asp:Label></td>
                    <td><asp:TextBox id="TextBox7" runat="server" ReadOnly="True" Enabled="False"></asp:TextBox></td>
                    <td><asp:Label id="Label37" runat="server" font-size="Small" font-names="Verdana" font-bold="False" Text="Brokerage"></asp:Label></td>
                    <td><asp:TextBox id="TextBox8" runat="server"></asp:TextBox></td>
                    <td><asp:Label id="Label38" runat="server" width="96px" font-size="Small" font-names="Verdana" font-bold="False" backcolor="Transparent">Basic Charges</asp:Label></td>
                    <td>
                        <asp:TextBox id="TextBox9" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td><asp:Label id="Label39" runat="server" font-size="Small" font-names="Verdana" font-bold="False" Text="V.A.T"></asp:Label></td>
                    <td>
                        <asp:TextBox id="TextBox10" runat="server"></asp:TextBox></td>
                    <td><asp:Label id="Label40" runat="server" width="96px" font-size="Small" font-names="Verdana" font-bold="False" Text="Stamp Duty"></asp:Label></td>
                    <td>
                        <asp:TextBox id="TextBox11" runat="server"></asp:TextBox></td>
                    <td><asp:Label id="Label41" runat="server" width="96px" font-size="Small" font-names="Verdana" font-bold="False" backcolor="Transparent">Captial Gains</asp:Label></td>
                    <td>
                        <asp:TextBox id="TextBox12" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td><asp:Label id="Label42" runat="server" font-size="Small" font-names="Verdana" font-bold="False" Text="Total Net Value" width="104px"></asp:Label></td>
                    <td>
                        <asp:TextBox id="TextBox13" runat="server"></asp:TextBox></td>
                        <td>
                            <asp:Label id="Label9" runat="server" Text="Purchase Made by:" font-bold="False" font-names="Verdana" font-size="Small" width="136px"></asp:Label></td>
                        <td colspan="2">
                            <asp:Label id="lblBuyer" runat="server" font-bold="False" font-names="Verdana" font-size="Small" width="296px"></asp:Label></td>
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
                                <asp:Button id="btnPrintStatement" runat="server" Text="Save Order" width="120px" /></td>
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

