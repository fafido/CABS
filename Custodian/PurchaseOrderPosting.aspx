<%@ Page Language="VB" MasterPageFile="~/CDSUser.master" AutoEventWireup="false" CodeFile="PurchaseOrderPosting.aspx.vb" Inherits="Custodian_PurchaseOrderPosting" title="Purchase Order Placement Form" %>
<%@ Register assembly="BasicFrame.WebControls.BasicDatePicker" namespace="BasicFrame.WebControls" tagprefix="BDP" %>
<asp:Content id="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
    <asp:Panel id="Panel1" runat="server">
    
<table style="border-right: #000033 thin solid; border-top: #000033 thin solid; border-left: #000033 thin solid; width: 832px; border-bottom: #000033 thin solid; background-color: #ffffff">
    <tr>
        <td style="width: 712px; height: 230px" valign="top">
            <table>
            <tr>
                <td style="width: 870px" align="center">
                    <asp:Label id="Label4" runat="server" backcolor="#8080FF" font-bold="True" font-names="Arial"
                        Text="Purchase Order Placement" width="848px"></asp:Label></td>
            </tr>
            <tr>
                    <td colspan ="4" valign="top">
                        <asp:Label id="Label11" runat="server" Text="Order Number:" width="144px" font-names="Verdana" font-size="Small"></asp:Label>
                        <asp:TextBox id="txtOrderNumber" runat="server" width="134px"></asp:TextBox>
                        <asp:Button id="btnOrderSearch" runat="server" Text=">>" /></td>
                </tr>
            <tr>
                    <td colspan ="4" valign="top">
                        <asp:Label id="Label1" runat="server" Text="Shareholder Number:" width="144px" font-names="Verdana" font-size="Small"></asp:Label>
                        <asp:TextBox id="txtshareholder" runat="server" width="136px"></asp:TextBox>
                        <asp:Button id="btnHolderNumSearch" runat="server" Text=">>" /></td>
                </tr>
                
            </table>
            <table>
                <tr>
                    <td style="width: 138px">
                        <asp:Label id="Label5" runat="server" Text="Shareholder Name:" font-names="Verdana" font-size="Small"></asp:Label></td>
                        <td style="width: 3px">
                            <asp:TextBox id="txtSearch" runat="server" width="136px"></asp:TextBox></td>
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
                        <asp:ListBox id="lstNames" runat="server" Height="136px" width="328px" 
                            autopostback="True"></asp:ListBox></td>
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
                            <asp:DropDownList id="cmbCompany" runat="server" width="152px" autopostback="True">
                            </asp:DropDownList></td>
                            <td align="left">
                                <asp:Label id="Label3" runat="server" font-bold="False" font-names="Verdana" 
                                    font-size="Small" style="text-align: left" Text="Price:" width="104px"></asp:Label>
                                </td>
                            <td style="width: 424px">
                                <asp:TextBox id="txtSharePrice" runat="server" ReadOnly="True"></asp:TextBox>
                    </td>
                                    <td>
                                        <asp:Label id="Label43" runat="server" font-bold="False" font-names="Verdana" 
                                            font-size="Small" style="text-align: left" Text="Order Attribute" width="104px"></asp:Label>
                    </td>
                                    <td>
                                        <asp:DropDownList id="cmbOrderAttribute" runat="server" autopostback="True" 
                                            width="175px">
                                        </asp:DropDownList>
                    </td>
                </tr> 
                <tr>
                    <td>
                        <asp:Label id="Label6" runat="server" Text="Order Quantity" width="112px" font-bold="False" font-names="Verdana" font-size="Small"></asp:Label></td>
                    <td>
                        <asp:TextBox id="txtOrderShares" runat="server" autopostback="True"></asp:TextBox></td>
                    <td>
                        <asp:Label id="Label8" runat="server" Text="Order Amount" width="192px" font-names="Verdana" font-size="Small"></asp:Label></td>
                    <td style="width: 424px">
                        <asp:TextBox id="txtOrderAmount" runat="server" autopostback="True"></asp:TextBox></td>
                    <td></td>
                    <td>
                        <asp:Label id="lblOrderType" runat="server" font-bold="False" 
                            font-names="Verdana" font-size="Small" style="text-align: left" width="104px"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td><asp:Label id="Label7" runat="server" font-size="Small" font-names="Verdana" font-bold="False" Text="Shareholder"></asp:Label></td>
                    <td><asp:TextBox id="txtHolder" runat="server" ReadOnly="True"></asp:TextBox></td>
                    <td><asp:Label id="Label16" runat="server" width="104px" font-size="Small" font-names="Verdana" font-bold="False" Text="Order number"></asp:Label></td>
                    <td style="width: 424px"><asp:TextBox id="txtOrderNum" runat="server" ReadOnly="True" Enabled="False"></asp:TextBox></td>
                    <td><asp:Label id="Label26" runat="server" width="104px" font-size="Small" font-names="Verdana" font-bold="False" backcolor="Transparent">Holder Names</asp:Label></td>
                    <td><asp:TextBox id="txtNames" runat="server" autopostback="true" ReadOnly="true" Enabled="false" font-bold="True" Height="40px" TextMode="MultiLine"></asp:TextBox></td>
                </tr>
                <tr>
                    <td><asp:Label id="Label33" runat="server" font-size="Small" font-names="Verdana" font-bold="False" Text="Basic Fee"></asp:Label></td>
                    <td><asp:TextBox id="txtBasicCharges" runat="server" ReadOnly="True"></asp:TextBox></td>
                    <td><asp:Label id="Label34" runat="server" font-size="Small" font-names="Verdana" font-bold="False" Text="Stamp Duty"></asp:Label></td>
                    <td style="width: 424px"><asp:TextBox id="txtStamp" runat="server" ReadOnly="True"></asp:TextBox></td>
                    <td><asp:Label id="Label35" runat="server" width="104px" font-size="Small" font-names="Verdana" font-bold="False" backcolor="Transparent">P/Registration</asp:Label></td>
                    <td><asp:TextBox id="txtPReg" runat="server" ReadOnly="True"></asp:TextBox></td>
                </tr>
                <tr>
                    <td><asp:Label id="Label36" runat="server" font-size="Small" font-names="Verdana" font-bold="False" Text="M/Brokerage"></asp:Label></td>
                    <td><asp:TextBox id="txtMinBroke" runat="server" ReadOnly="True"></asp:TextBox></td>
                    <td><asp:Label id="Label37" runat="server" font-size="Small" font-names="Verdana" font-bold="False" Text="Transfer Fees"></asp:Label></td>
                    <td><asp:TextBox id="txtTfees" runat="server" ReadOnly="True"></asp:TextBox></td>
                    <td><asp:Label id="Label38" runat="server" width="96px" font-size="Small" font-names="Verdana" font-bold="False" backcolor="Transparent">Sec Levy</asp:Label></td>
                    <td>
                        <asp:TextBox id="txtSecLevel" runat="server" ReadOnly="True"></asp:TextBox></td>
                </tr>
                <tr>
                    <td><asp:Label id="Label39" runat="server" font-size="Small" font-names="Verdana" font-bold="False" Text="V.B.C"></asp:Label></td>
                    <td>
                        <asp:TextBox id="txtValueB4" runat="server" ReadOnly="True"></asp:TextBox></td>
                    <td><asp:Label id="Label40" runat="server" width="96px" font-size="Small" font-names="Verdana" font-bold="False" Text="Charges"></asp:Label></td>
                    <td>
                        <asp:TextBox id="txtTotCharges" runat="server" ReadOnly="True"></asp:TextBox></td>
                    <td><asp:Label id="Label41" runat="server" width="96px" font-size="Small" font-names="Verdana" font-bold="False" backcolor="Transparent">Total Cost</asp:Label></td>
                    <td>
                        <asp:TextBox id="txtTotalCost" runat="server" ReadOnly="True"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>
                        <asp:Label id="Label44" runat="server" font-bold="False" font-names="Verdana" 
                            font-size="Small" Text="Target Date"></asp:Label>
                    </td>
                    <td>
                        <BDP:BasicDatePicker id="TargetDate" runat="server" />
                    </td>
                    <td>
                        <asp:Label id="Label45" runat="server" font-bold="False" font-names="Verdana" 
                            font-size="Small" Text="Expiry Date"></asp:Label>
                    </td>
                    <td>
                        <BDP:BasicDatePicker id="ExpiryDate" runat="server" />
                    </td>
                    <td></td>
                    <td></td>
                </tr>
                <tr>
                    <td style="height: 35px"><asp:Label id="Label42" runat="server" font-size="Small" font-names="Verdana" font-bold="False" Text="Total Net Value" width="104px"></asp:Label></td>
                    <td style="height: 35px">
                        <asp:TextBox id="TextBox13" runat="server"></asp:TextBox></td>
                        <td style="height: 35px">
                            <asp:Label id="Label9" runat="server" Text="Purchase Made by:" font-bold="False" font-names="Verdana" font-size="Small"></asp:Label></td>
                        <td colspan="2" style="height: 35px">
                            <asp:Label id="lblBuyer" runat="server" font-bold="False" font-names="Verdana" font-size="Small" width="296px"></asp:Label></td>
                </tr>
                <tr>
                    <td colspan="6" align="center" bgcolor="#8080ff" style="height: 13px">
                        <asp:Label id="Label10" runat="server" Text="..................................................................................................................................................................................................." width="832px"></asp:Label></td>
                </tr>
                <tr>
                    <td colspan ="1" style="width: 147px">
                        </td>
                        <td colspan="1" style="width: 203px">
                                <asp:Button id="btnPrintStatement" runat="server" Text="Save Purchase Order" /></td>
                            <td colspan ="1" style="width: 172px">
                                <asp:Button id="btnUpdateOrder" runat="server" Text="Update Purchase Order" /></td>
                                <td colspan ="1" style="width: 424px"><asp:Button id="btnCancelOrder" runat="server" Text="Cancel Purchase Order" /></td>
                                <td colspan ="1" style="width: 424px"><asp:Button id="btnClear" runat="server" Text="Clear Purchase Order" /></td>
                                <td colspan ="1" style="width: 424px"></td>
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

