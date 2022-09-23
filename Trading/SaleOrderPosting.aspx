<%@ Page Language="VB" MasterPageFile="~/CDSUser.master" AutoEventWireup="false" CodeFile="SaleOrderPosting.aspx.vb" Inherits="Trading_SaleOrderPosting" title="Order Placement Form" %>

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
                        Text="Sale Order Placement" width="848px"></asp:Label></td>
            </tr>
                
            </table>
            <table>
                <tr>
                    <td style="width: 186px">
                        <asp:Label id="Label11" runat="server" font-names="Verdana" font-size="Small" 
                            Text="Order Number:" width="108px"></asp:Label>
                    </td>
                        <td colspan ="4">
                            <asp:TextBox id="txtOrderNumberSearch" runat="server" Width="300px"></asp:TextBox>
                            <asp:Button ID="btnOrderSearch" runat="server" Text="&gt;&gt;" />
                    </td>
                            
                </tr>                
                <tr>
                    <td style="width: 186px">
                        <asp:Label id="Label1" runat="server" font-names="Verdana" font-size="Small" 
                            Text="Shareholder Number:" width="144px"></asp:Label>
                    </td>
                    <td colspan="4">
                        <asp:TextBox id="txtholder" runat="server" Width="300px"></asp:TextBox>
                        <asp:Button ID="btnHolderNumSearch" runat="server" Text="&gt;&gt;" />
                    </td>
                    
                </tr>
                <tr>
                    <td style="width: 186px">
                        <asp:Label id="Label5" runat="server" font-names="Verdana" font-size="Small" 
                            Text="Shareholder Name:"></asp:Label>
                    </td>
                    <td colspan="4">
                        <asp:TextBox id="txtSearch" runat="server" width="300px"></asp:TextBox>
                        <asp:Button id="btnSearchName" runat="server" Text="&gt;&gt;" />
                        
                    </td>
                 </tr>
            </table>
            <table>
                <tr>
                    <td style="width: 185px"></td>
                    <td style="width: 148px">
                        <asp:ListBox id="lstNames" runat="server" Height="59px" width="328px" 
                            autopostback="True"></asp:ListBox></td>
                </tr>
                <tr>
                    <td style="width: 185px"></td>
                    <td align="right">
                        <asp:Button id="btnSelect" runat="server" Text="Select" /></td>
                </tr>
                <tr>
                    <td style="width: 185px"></td>
                    <td>
                        </td>
                </tr>
            </table>
            <br />
            <table style="width: 100%">
                <tr>
                    <td>
                        <asp:Label id="Label2" runat="server" font-bold="False" font-names="Verdana" 
                            font-size="Small" Text="Company"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList id="cmbCompany" runat="server" autopostback="True" 
                            width="152px">
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:Label id="Label16" runat="server" font-bold="False" font-names="Verdana" 
                            font-size="Small" Text="Order number" width="104px"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox id="txtOrderNum" runat="server" Enabled="False" ReadOnly="True"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label id="Label6" runat="server" font-bold="False" font-names="Verdana" 
                            font-size="Small" Text="Quantity" width="96px"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox id="txtOrderNumber" runat="server" autopostback="True"></asp:TextBox>
                    </td>
                    <td>
                        <asp:Label id="Label34" runat="server" font-bold="False" font-names="Verdana" 
                            font-size="Small" Text="Transfer Fees"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox id="txtTfees" runat="server" ReadOnly="True"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label id="Label7" runat="server" font-bold="False" font-names="Verdana" 
                            font-size="Small" Text="Shareholder"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox id="txtShareholder" runat="server" ReadOnly="True"></asp:TextBox>
                    </td>
                    <td>
                        <asp:Label id="Label40" runat="server" font-bold="False" font-names="Verdana" 
                            font-size="Small" Text="Stamp Duty" width="96px"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox id="txtStamp" runat="server" ReadOnly="True"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td><asp:Label runat="server" text="Market board" font-bold="False" font-names="Verdana" 
                            font-size="Small"></asp:Label></td>
                    <td><asp:DropDownList runat="server" id="cmbMarketboard" Width="150px">
                        <asp:ListItem>None</asp:ListItem>
                        <asp:ListItem>Normal Board</asp:ListItem>
                        <asp:ListItem>Odd Lot</asp:ListItem>
                        <asp:ListItem>Prompt Board</asp:ListItem>
                        </asp:DropDownList></td>
                    <td><asp:Label runat="server" text="Order Qualifier" font-bold="False" font-names="Verdana" 
                            font-size="Small"></asp:Label></td>
                    <td><asp:DropDownList runat="server" id="cmbOrderQualifier" Width="150px">
                        <asp:ListItem>None</asp:ListItem>
                        <asp:ListItem Value="IOC">Immediate /Cancel Order</asp:ListItem>
                        </asp:DropDownList></td>
                </tr>
                <tr>
                    <td><asp:Label runat="server" Text="Order Preference" font-bold="False" font-names="Verdana" 
                            font-size="Small"></asp:Label></td>
                    <td>
                        <asp:DropDownList ID="cmbOrderPref" runat="server" AutoPostBack="True" 
                            style="height: 22px" width="150px">
                            <asp:ListItem>M</asp:ListItem>
                            <asp:ListItem>L</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:Label ID="Label44" runat="server" backcolor="Transparent" 
                            font-bold="False" font-names="Verdana" font-size="Small" width="104px">Time 
                        in Force</asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="cmbOrderAttribute" runat="server" autopostback="True" 
                            width="150px">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <asp:Label ID="lblOrderType" runat="server" font-bold="False" 
                            font-names="Verdana" font-size="Small" Height="16px" style="text-align: left" 
                            Visible="False" width="104px"></asp:Label>
                    </td>
                    <td></td>
                    <td></td>
                </tr>
                <tr>
                    <td>
                        <asp:Label id="Label33" runat="server" font-bold="False" font-names="Verdana" 
                            font-size="Small" Text="Sec Levy"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox id="txtSecLevel" runat="server" ReadOnly="True"></asp:TextBox>
                    </td>
                    <td>
                        <asp:Label id="Label36" runat="server" font-bold="False" font-names="Verdana" 
                            font-size="Small" Text="Total Charges"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox id="txtCharges" runat="server" ReadOnly="True"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label id="Label37" runat="server" font-bold="False" font-names="Verdana" 
                            font-size="Small" Text="Brokerage"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox id="txtBrokerage" runat="server" ReadOnly="True"></asp:TextBox>
                    </td>
                    <td>
                        <asp:Label id="Label12" runat="server" font-bold="False" font-names="Verdana" 
                            font-size="Small" Text="Expiry Date"></asp:Label>
                    </td>
                    <td>
                        <BDP:BasicDatePicker id="txtExpiryDate" runat="server">
                        </BDP:BasicDatePicker>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label id="Label8" runat="server" font-bold="False" font-names="Verdana" 
                            font-size="Small" Text="Gross Amount"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox id="txtTotGross" runat="server" ReadOnly="True"></asp:TextBox>
                    </td>
                    <td>
                        <asp:Label id="Label9" runat="server" font-bold="False" font-names="Verdana" 
                            font-size="Small" Text="Purchase Made by:"></asp:Label>
                    </td>
                    <td>
                        <asp:Label id="lblBuyer" runat="server" font-bold="False" font-names="Verdana" 
                            font-size="Small" width="83px"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label id="Label43" runat="server" font-bold="False" font-names="Verdana" 
                            font-size="Small" Text="Target Date"></asp:Label>
                    </td>
                    <td>
                        <BDP:BasicDatePicker id="txtTargetDate" runat="server">
                        </BDP:BasicDatePicker>
                    </td>
                    <td>
                        <asp:Label id="Label3" runat="server" backcolor="Transparent" font-bold="False" 
                            font-names="Verdana" font-size="Small" width="104px">Share Price</asp:Label>
                    </td>
                    <td>
                        <asp:TextBox id="txtSharePrice" runat="server" width="144px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label id="Label42" runat="server" font-bold="False" font-names="Verdana" 
                            font-size="Small" Text="Total Net Value" width="104px"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox id="TextBox13" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:Label ID="Label38" runat="server" backcolor="Transparent" 
                            font-bold="False" font-names="Verdana" font-size="Small" width="96px">Basic 
                        Charges</asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtBasicCharges" runat="server" ReadOnly="True"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label id="Label35" runat="server" backcolor="Transparent" 
                            font-bold="False" font-names="Verdana" font-size="Small" width="144px">Minimum 
                        Brokerage</asp:Label>
                    </td>
                    <td>
                        <asp:TextBox id="txtMinBroke" runat="server" ReadOnly="True"></asp:TextBox>
                    </td>
                    <td>
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td>
                        <asp:Label id="Label41" runat="server" backcolor="Transparent" 
                            font-bold="False" font-names="Verdana" font-size="Small" width="96px">Total 
                        Payable</asp:Label>
                    </td>
                    <td>
                        <asp:TextBox id="txtTotpay" runat="server" ReadOnly="True"></asp:TextBox>
                    </td>
                    <td>
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td valign="top">
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                    <td>
                        <asp:Label ID="Label26" runat="server" backcolor="Transparent" 
                            font-bold="False" font-names="Verdana" font-size="Small" width="104px">Holder 
                        Names</asp:Label>
                    </td>
                    <td valign="top">
                        <asp:TextBox ID="txtNames" runat="server" autopostback="true" Enabled="false" 
                            Height="46px" ReadOnly="true" TextMode="MultiLine" width="196px"></asp:TextBox>
                    </td>
                </tr>
            </table>
            <br />
            <table>
                <tr>
                        <td colspan="1" style="width: 203px">
                                <asp:Button id="btnPrintStatement" runat="server" Text="Save Sale Order" /></td>
                            <td colspan ="1" style="width: 172px">
                                <asp:Button id="btnUpdateOrder" runat="server" Text="Update Sale Order" /></td>
                                <td colspan ="1" style="width: 172px">
                                <asp:Button id="btnCancelOrder" runat="server" Text="Cancel Sale Order" /></td>
                                <td colspan ="1" style="width: 424px"><asp:Button id="btnClear" runat="server" 
                                        Text="Clear Sale Order" /></td>
                                <td colspan ="1" style="width: 424px">
                                    <asp:Button id="btnClear0" runat="server" Text="Print Order Statement" />
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

