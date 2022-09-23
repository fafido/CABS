<%@ Page Language="VB" MasterPageFile="~/CDSUser.master" AutoEventWireup="false" CodeFile="OrdersAuditApproval.aspx.vb" Inherits="Trading_OrdersAuditApproval" title="Orders Approval Audit" %>
<%@ Register assembly="BasicFrame.WebControls.BasicDatePicker" namespace="BasicFrame.WebControls" tagprefix="BDP" %>
<asp:Content id="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
    <asp:Panel id="Panel1" runat="server" width="851px">
    
<table style="border-right: #000033 thin solid; border-top: #000033 thin solid; border-left: #000033 thin solid; width: 832px; border-bottom: #000033 thin solid; background-color: #ffffff">
    <tr>
        <td style="width: 712px; height: 230px" valign="top">
            <table>
            <tr>
                <td style="width: 573px" align="center">
                    <asp:Label id="Label4" runat="server" backcolor="#8080FF" font-bold="True" font-names="Arial"
                        Text="Orders Approval Audit" width="847px" Height="16px"></asp:Label></td>
            </tr>
            
                
            </table>
            
            <table style="width: 118%">
                <tr>
                    <td style="width: 120px">
                        <asp:Label id="Label11" runat="server" font-names="Verdana" font-size="Small" 
                            Text="Order Number:" width="144px"></asp:Label>
                    </td>
                    <td style="width: 186px">
                        <asp:TextBox id="txtOrderNumber" runat="server" width="99px"></asp:TextBox>
                        <asp:Button id="btnOrderSearch" runat="server" Text="&gt;&gt;" />
                    </td>
                    <td style="width: 200px">
                        <asp:Label id="Label47" runat="server" font-names="Verdana" font-size="Small" 
                            Text="Scroll Order Number:" width="184px"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList id="cmbOrders" runat="server" autopostback="True" 
                            width="173px">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td style="width: 120px">
                        &nbsp;</td>
                    <td style="width: 186px">
                        <asp:Label id="lblOrderNum" runat="server"></asp:Label>
                    </td>
                    <td style="width: 200px">
                        <asp:Label id="Label43" runat="server" font-bold="False" font-names="Verdana" 
                            font-size="Small" style="text-align: left" Text="Order Attribute" 
                            width="143px"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox id="cmbOrderAttribute" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="width: 120px">
                        <asp:Label id="Label2" runat="server" font-bold="False" font-names="Verdana" 
                            font-size="Small" Text="Company"></asp:Label>
                    </td>
                    <td style="width: 186px">
                        <asp:TextBox id="cmbCompany" runat="server"></asp:TextBox>
                    </td>
                    <td style="width: 200px">
                        <asp:Label id="Label3" runat="server" font-bold="False" font-names="Verdana" 
                            font-size="Small" style="text-align: left" Text="Base Price:" width="104px"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox id="txtSharePrice" runat="server" ReadOnly="True"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="width: 120px">
                        <asp:Label id="Label6" runat="server" font-bold="False" font-names="Verdana" 
                            font-size="Small" Text="Order Quantity" width="112px"></asp:Label>
                    </td>
                    <td style="width: 186px">
                        <asp:TextBox id="txtOrderShares" runat="server" autopostback="True"></asp:TextBox>
                    </td>
                    <td style="width: 200px">
                        <asp:Label id="Label8" runat="server" font-names="Verdana" font-size="Small" 
                            Text="Order Amount" width="127px"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox id="txtOrderAmount" runat="server" autopostback="True"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="width: 120px">
                        <asp:Label id="Label48" runat="server" font-names="Verdana" font-size="Small" 
                            Text="Order Type" width="137px"></asp:Label>
                    </td>
                    <td style="width: 186px">
                        <asp:TextBox id="txtOrderType" runat="server"></asp:TextBox>
                    </td>
                    <td style="width: 200px">
                        <asp:Label id="Label16" runat="server" font-bold="False" font-names="Verdana" 
                            font-size="Small" Text="Order number" width="104px"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox id="txtOrderNum" runat="server" Enabled="False" ReadOnly="True"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="width: 120px">
                        <asp:Label id="Label7" runat="server" font-bold="False" font-names="Verdana" 
                            font-size="Small" Text="CDS Number"></asp:Label>
                    </td>
                    <td style="width: 186px">
                        <asp:TextBox id="txtHolder" runat="server" ReadOnly="True"></asp:TextBox>
                    </td>
                    <td valign="top" style="width: 200px">
                        <asp:Label id="Label26" runat="server" backcolor="Transparent" 
                            font-bold="False" font-names="Verdana" font-size="Small" width="104px">Holder Names</asp:Label>
                    </td>
                    <td>
                        <asp:TextBox id="txtNames" runat="server" autopostback="true" Enabled="false" 
                            font-bold="True" Height="40px" ReadOnly="true" TextMode="MultiLine"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="width: 120px">
                        <asp:Label id="Label33" runat="server" font-bold="False" font-names="Verdana" 
                            font-size="Small" Text="Broker"></asp:Label>
                    </td>
                    <td style="width: 186px">
                        <asp:TextBox id="txtBroker" runat="server" ReadOnly="True"></asp:TextBox>
                    </td>
                    <td style="width: 200px">
                        <asp:Label id="Label49" runat="server" font-bold="False" font-names="Verdana" 
                            font-size="Small" Text="Date Order Placed"></asp:Label>
                    </td>
                    <td>
                        <BDP:BasicDatePicker id="dateplaced" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td style="width: 120px">
                        <asp:Label id="Label44" runat="server" font-bold="False" font-names="Verdana" 
                            font-size="Small" Text="Target Date"></asp:Label>
                    </td>
                    <td style="width: 186px">
                        <BDP:BasicDatePicker id="TargetDate" runat="server" />
                    </td>
                    <td style="width: 200px">
                        <asp:Label id="Label45" runat="server" font-bold="False" font-names="Verdana" 
                            font-size="Small" Text="Expiry Date"></asp:Label>
                    </td>
                    <td>
                        <BDP:BasicDatePicker id="ExpiryDate" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td style="width: 120px; height: 28px">
                        <asp:Label id="Label50" runat="server" font-bold="False" font-names="Verdana" 
                            font-size="Small" Text="Order Placed By"></asp:Label>
                    </td>
                    <td style="width: 186px; height: 28px">
                        <asp:Label id="lblBuyer" runat="server" font-bold="False" font-names="Verdana" 
                            font-size="Small" style="margin-bottom: 0px" width="70px"></asp:Label>
                    </td>
                    <td style="height: 28px; width: 200px">
                        <asp:Label id="Label9" runat="server" font-bold="False" font-names="Verdana" 
                            font-size="Small" Text="Shareholder Account State"></asp:Label>
                    </td>
                    <td style="height: 28px">
                        <asp:Label id="lblBuyer0" runat="server" font-bold="False" font-names="Verdana" 
                            font-size="Medium" Height="16px" style="margin-bottom: 0px" width="203px"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="width: 120px">
                        &nbsp;</td>
                    <td style="width: 186px">
                        &nbsp;</td>
                    <td style="width: 200px">
                        <asp:RadioButton id="rdApprove" runat="server" autopostback="True" 
                            GroupName="AccountsApprove" Text="Approve" />
                        <asp:RadioButton id="rdApprove0" runat="server" autopostback="True" 
                            GroupName="AccountsApprove" Text="Reject" />
                    </td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td align="center" valign="top" colspan="4">
                        <asp:Label id="Label51" runat="server" font-bold="False" font-names="Verdana" 
                            font-size="Small" Text="Rejection Reason" Visible="False"></asp:Label>
                        <br />
                        <asp:TextBox id="txtRejectionReason" runat="server" Height="65px" 
                            TextMode="MultiLine" Visible="False" width="637px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="width: 120px">
                        &nbsp;</td>
                    <td style="width: 186px">
                        &nbsp;</td>
                    <td style="width: 200px">
                        <asp:Button id="Save" runat="server" Text="Save" />
                    </td>
                    <td>
                        &nbsp;</td>
                </tr>
            </table>
            <br />
            
            <table>
                <tr>
                    <td colspan ="4" style="width: 850px" align="center">
                        &nbsp;</td>                
                </tr>
            </table>
        </td>
    </tr>
</table>
</asp:Panel>
</div>
</asp:Content>

