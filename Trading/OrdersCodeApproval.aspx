<%@ Page Language="VB" MasterPageFile="~/CDSUser.master" AutoEventWireup="false" CodeFile="OrdersCodeApproval.aspx.vb" Inherits="Trading_OrdersCodeApproval" title="Orders Approval Audit" %>
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
                        Text="Orders Approval Audit" width="836px"></asp:Label></td>
            </tr>
            <tr>
                    <td colspan ="4" valign="top" style="height: 33px">
                        &nbsp;</td>
                </tr>
            
                
            </table>
            
            <table style="width: 88%; height: 546px;">
                <tr>
                    <td>
                        <asp:Label id="Label11" runat="server" font-names="Verdana" font-size="Small" 
                            Text="Order Number:" width="144px"></asp:Label>
                    </td>
                        <td>
                            <asp:TextBox id="txtOrderNumber" runat="server" width="99px"></asp:TextBox>
                            <asp:Button id="btnOrderSearch" runat="server" Text="&gt;&gt;" />
                    </td>
                            <td align="left">
                                <asp:Label id="lblOrderNum" runat="server"></asp:Label>
                    </td>
                            <td style="width: 468px">
                                </td>
                                   
                </tr> 
                <tr>
                    <td>
                        <asp:Label id="Label47" runat="server" font-names="Verdana" font-size="Small" 
                            Text="Scroll Order Number:" width="144px"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList id="cmbOrders" runat="server" autopostback="True" 
                            width="173px">
                        </asp:DropDownList>
                    </td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>
                        <asp:Label id="Label2" runat="server" Text="Company" font-bold="False" font-names="Verdana" font-size="Small"></asp:Label></td>
                        <td>
                            <asp:TextBox id="cmbCompany" runat="server"></asp:TextBox>
                    </td>
                            <td align="left">
                                <asp:Label id="Label3" runat="server" font-bold="False" font-names="Verdana" 
                                    font-size="Small" style="text-align: left" Text="Base Price:" 
                                    width="104px"></asp:Label>
                                </td>
                            <td style="width: 468px">
                                <asp:TextBox id="txtSharePrice" runat="server" ReadOnly="True"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label id="Label43" runat="server" font-bold="False" font-names="Verdana" 
                            font-size="Small" style="text-align: left" Text="Order Attribute" width="104px"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox id="cmbOrderAttribute" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:Label id="Label6" runat="server" font-bold="False" font-names="Verdana" 
                            font-size="Small" Text="Order Quantity" width="112px"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox id="txtOrderShares" runat="server" autopostback="True"></asp:TextBox>
                    </td>
                </tr> 
                <tr>
                    <td>
                        <asp:Label id="Label8" runat="server" font-names="Verdana" font-size="Small" 
                            Text="Order Amount" width="192px"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox id="txtOrderAmount" runat="server" autopostback="True"></asp:TextBox>
                    </td>
                    <td>
                        <asp:Label id="Label48" runat="server" font-names="Verdana" font-size="Small" 
                            Text="Order Type" width="192px"></asp:Label>
                    </td>
                    <td style="width: 468px">
                        <asp:TextBox id="txtOrderType" runat="server"></asp:TextBox>
                    </td>
                    
                </tr>
               
                <tr>
                    <td>
                        <asp:Label id="Label16" runat="server" font-bold="False" font-names="Verdana" 
                            font-size="Small" Text="Order number" width="104px"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox id="txtOrderNum" runat="server" Enabled="False" ReadOnly="True"></asp:TextBox>
                    </td>
                    <td>
                        <asp:Label id="Label7" runat="server" font-bold="False" font-names="Verdana" 
                            font-size="Small" Text="CDS Number"></asp:Label>
                    </td>
                    <td style="width: 468px">
                        <asp:TextBox id="txtHolder" runat="server" ReadOnly="True"></asp:TextBox>
                    </td>
                    </tr>
                <tr>
                    <td>
                        <asp:Label id="Label26" runat="server" backcolor="Transparent" 
                            font-bold="False" font-names="Verdana" font-size="Small" width="104px">Holder 
                        Names</asp:Label>
                    </td>
                    <td>
                        <asp:TextBox id="txtNames" runat="server" autopostback="true" Enabled="false" 
                            font-bold="True" Height="40px" ReadOnly="true" TextMode="MultiLine"></asp:TextBox>
                    </td>
                    <td>
                        <asp:Label id="Label33" runat="server" font-bold="False" font-names="Verdana" 
                            font-size="Small" Text="Broker"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox id="txtBroker" runat="server" ReadOnly="True"></asp:TextBox>
                    </td>
                </tr> 
                
                <tr>
                    <td>
                        <asp:Label id="Label49" runat="server" font-bold="False" font-names="Verdana" 
                            font-size="Small" Text="Date Order Placed"></asp:Label>
                    </td>
                    <td>
                        <BDP:BasicDatePicker id="dateplaced" runat="server" />
                    </td>
                    <td>
                        <asp:Label id="Label44" runat="server" font-bold="False" font-names="Verdana" 
                            font-size="Small" Text="Target Date"></asp:Label>
                    </td>
                    <td style="width: 468px">
                        <BDP:BasicDatePicker id="TargetDate" runat="server" />
                    </td>
                    </tr>
                <tr>
                    <td>
                        <asp:Label id="Label45" runat="server" font-bold="False" font-names="Verdana" 
                            font-size="Small" Text="Expiry Date"></asp:Label>
                    </td>
                    <td>
                        <BDP:BasicDatePicker id="ExpiryDate" runat="server" />
                    </td>
                    <td>&nbsp;</td>
                    <td></td>
                </tr> 
                <tr>
                    <td style="height: 35px">
                        <asp:Label id="Label50" runat="server" font-bold="False" font-names="Verdana" 
                            font-size="Small" Text="Order Placed By"></asp:Label>
                    </td>
                    <td style="height: 35px">
                        <asp:Label id="lblBuyer" runat="server" font-bold="False" font-names="Verdana" 
                            font-size="Small" style="margin-bottom: 0px" width="171px"></asp:Label>
                    </td>
                        <td style="height: 35px">
                            <asp:Label id="Label9" runat="server" Text="Shareholder Account State" 
                                font-bold="False" font-names="Verdana" font-size="Small"></asp:Label></td>
                        <td colspan="2" style="height: 35px">
                            <asp:Label id="lblBuyer0" runat="server" font-bold="False" font-names="Verdana" 
                                font-size="Medium" style="margin-bottom: 0px" width="396px" Height="25px"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td></td>
                    <td></td>
                    <td></td>
                </tr> 
                <tr>
                    <td>
                        <asp:Label id="Label52" runat="server" font-bold="False" font-names="Verdana" 
                            font-size="Small" Text="Activation Code"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox id="txtCodeActivation" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RadioButton id="rdApprove" runat="server" autopostback="True" 
                            GroupName="AccountsApprove" Text="Approve" Visible="False" />
                        <asp:RadioButton id="rdApprove0" runat="server" autopostback="True" 
                            GroupName="AccountsApprove" Text="Reject" Visible="False" />
                    </td>
                    <td></td>       
                 </tr>
                <tr>
                    <td></td>
                    <td></td>
                    <td></td>
                    <td></td>
                </tr> 
                <tr>
                    <td colspan ="1">
                        <asp:Label id="Label51" runat="server" font-bold="False" font-names="Verdana" 
                            font-size="Small" Text="Rejection Reason" Visible="False"></asp:Label>
                    </td>
                    <td colspan ="5">
                        <asp:TextBox id="txtRejectionReason" runat="server" Height="65px" 
                            TextMode="MultiLine" Visible="False" width="300px"></asp:TextBox>
                    </td>
                    
                </tr>
                
                <%--<tr>
                    <td colspan="4" align="center" bgcolor="#8080ff" style="height: 13px">
                        <asp:Label id="Label10" runat="server" 
                            Text="..................................................................................................................................................................................................." 
                            Height="16px"></asp:Label></td>
                </tr>--%>
                <tr>
                    <td colspan ="6" align="center">
                        <asp:Button id="Save" runat="server" Text="Save" />
                        </td>
                     
                </tr>
            </table>
            <br />
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

