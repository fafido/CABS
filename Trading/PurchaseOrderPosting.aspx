<%@ Page Language="VB" MasterPageFile="~/CDSUser.master" AutoEventWireup="false" CodeFile="PurchaseOrderPosting.aspx.vb" Inherits="Trading_PurchaseOrderPosting" title="Purchase Order Placement Form" %>
<%@ Register assembly="BasicFrame.WebControls.BasicDatePicker" namespace="BasicFrame.WebControls" tagprefix="BDP" %>
<asp:Content id="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
    <asp:Panel id="Panel1" runat="server">
    
<table style="border-right: #000033 thin solid; border-top: #000033 thin solid; border-left: #000033 thin solid; width: 832px; border-bottom: #000033 thin solid; background-color: #ffffff">
    <tr>
        <td style="width: 712px; height: 230px" valign="top">
            <table>
            <tr>
                <td style="width: 573px" align="center">
                    <asp:Label id="Label4" runat="server" backcolor="#8080FF" font-bold="True" font-names="Arial"
                        Text="Purchase Order Placement" width="842px"></asp:Label></td>
            </tr>
                
            </table>
            <table>
                <tr>
                    <td style="width: 209px">
                        <asp:Label id="Label11" runat="server" font-names="Verdana" font-size="Small" 
                            Text="Order Number:" width="144px"></asp:Label>
                    </td>
                        <td colspan="4">
                            <asp:TextBox id="txtOrderNumber" runat="server" width="300px"></asp:TextBox>
                            <asp:Button id="btnOrderSearch" runat="server" Text="&gt;&gt;" />
                    </td>
                </tr>                
                <tr>
                    <td style="width: 209px">
                        <asp:Label id="Label1" runat="server" font-names="Verdana" font-size="Small" 
                            Text="Shareholder Number:" width="144px"></asp:Label>
                    </td>
                    <td colspan="4">
                        <asp:TextBox id="txtshareholder" runat="server" width="300px"></asp:TextBox>
                        <asp:Button id="btnHolderNumSearch" runat="server" Text="&gt;&gt;" />
                    </td>
                    
                </tr>
                <tr>
                    <td style="width: 209px">
                        <asp:Label id="Label5" runat="server" font-names="Verdana" font-size="Small" 
                            Text="Shareholder Name:"></asp:Label>
                    </td>
                    <td colspan="4">
                        <asp:TextBox id="txtSearch" runat="server" style="margin-left: 2px" 
                            width="300px"></asp:TextBox>
                            <asp:Button id="btnSearchName" runat="server" Text="&gt;&gt;" />
                    </td>
                    
                </tr>
            </table>
            <table>
                <tr>
                    <td style="width: 210px"></td>
                    <td style="width: 148px">
                        <asp:ListBox id="lstNames" runat="server" Height="67px" width="273px" 
                            autopostback="True"></asp:ListBox></td>
                </tr>
                <tr>
                    <td style="width: 210px"></td>
                    <td align="right">
                        <asp:Button id="btnSelect" runat="server" Text="Select" /></td>
                </tr>
                <tr>
                    <td style="width: 210px"></td>
                    <td>
                        </td>
                </tr>
            </table>
            <br />
            <table style="width: 113%">
                <tr>
                    <td>
                        <asp:Label id="Label2" runat="server" font-bold="False" font-names="Verdana" 
                            font-size="Small" Text="Company"></asp:Label>
                    </td>
                    <td style="width: 252px">
                        <asp:DropDownList id="cmbCompany" runat="server" autopostback="True" 
                            Height="22px" width="150px">
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:Label id="Label3" runat="server" font-bold="False" font-names="Verdana" 
                            font-size="Small" style="text-align: left" Text="Price:" width="104px"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox id="txtSharePrice" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td>
                        <asp:Label id="Label6" runat="server" font-bold="False" font-names="Verdana" 
                            font-size="Small" Text="Order Quantity" width="112px"></asp:Label>
                    </td>
                    <td style="width: 252px">
                        <asp:TextBox id="txtOrderShares" runat="server" autopostback="True"></asp:TextBox>
                    </td>
                    <td>
                        <asp:Label id="Label8" runat="server" font-names="Verdana" font-size="Small" 
                            Text="Order Amount" width="125px"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox id="txtOrderAmount" runat="server" autopostback="True"></asp:TextBox>
                    </td>
                    <td>
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td>
                        <asp:Label id="Label7" runat="server" font-bold="False" font-names="Verdana" 
                            font-size="Small" Text="Shareholder"></asp:Label>
                    </td>
                    <td style="width: 252px">
                        <asp:TextBox id="txtHolder" runat="server" ReadOnly="True"></asp:TextBox>
                    </td>
                    <td>
                        <asp:Label id="Label16" runat="server" font-bold="False" font-names="Verdana" 
                            font-size="Small" Text="Order number" width="104px"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox id="txtOrderNum" runat="server" Enabled="False" ReadOnly="True"></asp:TextBox>
                    </td>
                    <td>
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td>
                        <asp:Label id="Label33" runat="server" font-bold="False" font-names="Verdana" 
                            font-size="Small" Text="Basic Fee"></asp:Label>
                    </td>
                    <td style="width: 252px">
                        <asp:TextBox id="txtBasicCharges" runat="server" ReadOnly="True"></asp:TextBox>
                    </td>
                    <td>
                        <asp:Label id="Label34" runat="server" font-bold="False" font-names="Verdana" 
                            font-size="Small" Text="Stamp Duty"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox id="txtStamp" runat="server" ReadOnly="True"></asp:TextBox>
                    </td>
                    <td>
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label47" runat="server" font-bold="False" font-names="Verdana" 
                            font-size="Small" text="Market board"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="cmbMarketboard" runat="server" Width="150px">
                            <asp:ListItem>None</asp:ListItem>
                            <asp:ListItem>Normal Board</asp:ListItem>
                            <asp:ListItem>Odd Lot</asp:ListItem>
                            <asp:ListItem>Prompt Board</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:Label ID="Label48" runat="server" font-bold="False" font-names="Verdana" 
                            font-size="Small" text="Order Qualifier"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="cmbOrderQualifier" runat="server" Width="150px">
                            <asp:ListItem>None</asp:ListItem>
                            <asp:ListItem Value="IOC">Immediate /Cancel Order</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label46" runat="server" backcolor="Transparent" 
                            font-bold="False" font-names="Verdana" font-size="Small" width="138px">Order 
                        Preference</asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="cmbOrderPref" runat="server" AutoPostBack="True" 
                            width="150px">
                            <asp:ListItem>M</asp:ListItem>
                            <asp:ListItem>L</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:Label ID="Label43" runat="server" font-bold="False" font-names="Verdana" 
                            font-size="Small" style="text-align: left; margin-top: 0px;" 
                            Text="Time in Force" width="104px"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="cmbOrderAttribute" runat="server" autopostback="True" 
                            Height="22px" width="150px">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label id="Label36" runat="server" font-bold="False" font-names="Verdana" 
                            font-size="Small" Text="M/Brokerage"></asp:Label>
                    </td>
                    <td style="width: 252px">
                        <asp:TextBox id="txtMinBroke" runat="server" ReadOnly="True"></asp:TextBox>
                    </td>
                    <td>
                        <asp:Label id="Label37" runat="server" font-bold="False" font-names="Verdana" 
                            font-size="Small" Text="Transfer Fees"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox id="txtTfees" runat="server" ReadOnly="True"></asp:TextBox>
                    </td>
                    <td>
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td>
                        <asp:Label id="Label39" runat="server" font-bold="False" font-names="Verdana" 
                            font-size="Small" Text="V.B.C"></asp:Label>
                    </td>
                    <td style="width: 252px">
                        <asp:TextBox id="txtValueB4" runat="server" ReadOnly="True"></asp:TextBox>
                    </td>
                    <td>
                        <asp:Label id="Label40" runat="server" font-bold="False" font-names="Verdana" 
                            font-size="Small" Text="Charges" width="96px"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox id="txtTotCharges" runat="server" ReadOnly="True"></asp:TextBox>
                    </td>
                    <td>
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td>
                        <asp:Label id="Label44" runat="server" font-bold="False" font-names="Verdana" 
                            font-size="Small" Text="Target Date"></asp:Label>
                    </td>
                    <td style="width: 252px">
                        <BDP:BasicDatePicker id="txtTargetDate" runat="server" />
                    </td>
                    <td>
                        <asp:Label id="Label45" runat="server" font-bold="False" font-names="Verdana" 
                            font-size="Small" Text="Expiry Date"></asp:Label>
                    </td>
                    <td>
                        <BDP:BasicDatePicker id="txtExpiryDate" runat="server" />
                    </td>
                    <td>
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td>
                        <asp:Label id="Label42" runat="server" font-bold="False" font-names="Verdana" 
                            font-size="Small" Text="Total Net Value" width="104px"></asp:Label>
                    </td>
                    <td style="width: 252px">
                        <asp:TextBox id="TextBox13" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:Label ID="Label9" runat="server" font-bold="False" font-names="Verdana" 
                            font-size="Small" Text="Purchase  by:"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblBuyer" runat="server" font-bold="False" font-names="Verdana" 
                            font-size="Small" width="99px"></asp:Label>
                    </td>
                    <td>
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label38" runat="server" backcolor="Transparent" 
                            font-bold="False" font-names="Verdana" font-size="Small" width="96px">Sec 
                        Levy</asp:Label>
                    </td>
                    <td style="width: 252px">
                        <asp:TextBox ID="txtSecLevel" runat="server" ReadOnly="True"></asp:TextBox>
                    </td>
                    <td>
                        <asp:Label ID="Label41" runat="server" backcolor="Transparent" 
                            font-bold="False" font-names="Verdana" font-size="Small" width="96px">Total 
                        Cost</asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtTotalCost" runat="server" ReadOnly="True"></asp:TextBox>
                    </td>
                    <td>
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td>
                        <asp:Label id="Label35" runat="server" backcolor="Transparent" 
                            font-bold="False" font-names="Verdana" font-size="Small" width="104px">P/Registration</asp:Label>
                    </td>
                    <td style="width: 252px">
                        <asp:TextBox id="txtPReg" runat="server" ReadOnly="True"></asp:TextBox>
                    </td>
                    <td>
                        <asp:Label ID="Label26" runat="server" backcolor="Transparent" 
                            font-bold="False" font-names="Verdana" font-size="Small" Height="16px" 
                            width="104px">Holder Names</asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtNames" runat="server" autopostback="true" Enabled="false" 
                            font-bold="True" Height="40px" ReadOnly="true" TextMode="MultiLine" 
                            width="148px"></asp:TextBox>
                    </td>
                    <td>
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td valign="top">
                        &nbsp;</td>
                    <td valign="top" style="width: 252px">
                        &nbsp;</td>
                    <td valign="top">
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td>
                        &nbsp;</td>
                    <td style="width: 252px">
                        <asp:Label id="lblOrderType" runat="server" font-bold="False" 
                            font-names="Verdana" font-size="Small" style="text-align: left" width="104px"></asp:Label>
                    </td>
                    <td>
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
            </table>
            <br />
            <br />
            <table style="width: 100%">
                <tr>
                    <td>
                        <asp:Button id="btnPrintStatement" runat="server" Text="Save Purchase Order" 
                            width="169px" />
                    </td>
                    <td>
                        <asp:Button id="btnUpdateOrder" runat="server" Text="Update Purchase Order" 
                            width="165px" />
                    </td>
                    <td>
                        <asp:Button id="btnCancelOrder" runat="server" Text="Cancel Purchase Order" 
                            width="161px" />
                    </td>
                    <td>
                        <asp:Button id="btnClear" runat="server" Text="Clear Purchase Order" 
                            width="167px" />
                    </td>
                    <td>
                        <asp:Button id="btnClear0" runat="server" Text="Print Order Statement" />
                    </td>
                </tr>
            </table>
            <br />
            <br />
        </td>
    </tr>
</table>
</asp:Panel>
</div>
</asp:Content>

