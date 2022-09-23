<%@ Page Language="VB" MasterPageFile="~/CDSUser.master" AutoEventWireup="false" CodeFile="SaleOrderPosting.aspx.vb" Inherits="Custodian_SaleOrderPosting" title="Order Placement Form" %>

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
            <tr>
                    <td colspan ="4" valign="top">
                        <asp:Label id="Label11" runat="server" Text="Order Number:" width="144px" font-names="Verdana" font-size="Small"></asp:Label>
                        <asp:TextBox id="txtOrderNumberSearch" runat="server"></asp:TextBox>
                        <asp:Button id="btnOrderSearch" runat="server" Text=">>" /></td>
                </tr>
            <tr>
                    <td colspan ="4" valign="top">
                        <asp:Label id="Label1" runat="server" Text="Shareholder Number:" width="144px" font-names="Verdana" font-size="Small"></asp:Label>
                        <asp:TextBox id="txtholder" runat="server"></asp:TextBox>
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
                            <td align="right">
                                </td>
                            <td style="width: 424px">
                                <asp:Label id="lblOrderType" runat="server" font-bold="False" 
                                    font-names="Verdana" font-size="Small" style="text-align: left" Visible="False" 
                                    width="104px"></asp:Label>
                    </td>
                                    <td>
                                        <asp:Label id="Label3" runat="server" backcolor="Transparent" font-bold="False" 
                                            font-names="Verdana" font-size="Small" width="104px">Share Price</asp:Label>
                    </td>
                                    <td>
                                        <asp:TextBox id="txtSharePrice" runat="server" ReadOnly="True" width="96px"></asp:TextBox>
                    </td>
                </tr> 
                <tr>
                    <td>
                        <asp:Label id="Label6" runat="server" Text="Quantity" width="96px" font-bold="False" font-names="Verdana" font-size="Small"></asp:Label></td>
                    <td>
                        <asp:TextBox id="txtOrderNumber" runat="server" autopostback="True"></asp:TextBox></td>
                    <td>
                        </td>
                    <td style="width: 424px">
                        </td>
                    <td>
                        <asp:Label id="Label44" runat="server" backcolor="Transparent" 
                            font-bold="False" font-names="Verdana" font-size="Small" width="104px">Order Attribute</asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList id="cmbOrderAttribute" runat="server" autopostback="True" 
                            width="175px">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td><asp:Label id="Label7" runat="server" font-size="Small" font-names="Verdana" font-bold="False" Text="Shareholder"></asp:Label></td>
                    <td><asp:TextBox id="txtShareholder" runat="server" ReadOnly="True"></asp:TextBox></td>
                    <td><asp:Label id="Label16" runat="server" width="104px" font-size="Small" font-names="Verdana" font-bold="False" Text="Order number"></asp:Label></td>
                    <td style="width: 424px"><asp:TextBox id="txtOrderNum" runat="server" ReadOnly="True" Enabled="False"></asp:TextBox></td>
                    <td><asp:Label id="Label26" runat="server" width="104px" font-size="Small" font-names="Verdana" font-bold="False" backcolor="Transparent">Holder Names</asp:Label></td>
                    <td><asp:TextBox id="txtNames" runat="server" autopostback="true" ReadOnly="true" 
                            Enabled="false" Height="46px" TextMode="MultiLine" width="196px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td><asp:Label id="Label33" runat="server" font-size="Small" font-names="Verdana" font-bold="False" Text="Sec Levy"></asp:Label></td>
                    <td><asp:TextBox id="txtSecLevel" runat="server" ReadOnly="True"></asp:TextBox></td>
                    <td><asp:Label id="Label34" runat="server" font-size="Small" font-names="Verdana" font-bold="False" Text="Transfer Fees"></asp:Label></td>
                    <td style="width: 424px"><asp:TextBox id="txtTfees" runat="server" ReadOnly="True"></asp:TextBox></td>
                    <td><asp:Label id="Label35" runat="server" width="104px" font-size="Small" font-names="Verdana" font-bold="False" backcolor="Transparent">Minimum Brokerage</asp:Label></td>
                    <td><asp:TextBox id="txtMinBroke" runat="server" ReadOnly="True"></asp:TextBox></td>
                </tr>
                <tr>
                    <td><asp:Label id="Label37" runat="server" font-size="Small" font-names="Verdana" font-bold="False" Text="Brokerage"></asp:Label></td>
                    <td><asp:TextBox id="txtBrokerage" runat="server" ReadOnly="True"></asp:TextBox></td>
                    <td><asp:Label id="Label40" runat="server" width="96px" font-size="Small" font-names="Verdana" font-bold="False" Text="Stamp Duty"></asp:Label></td>
                    <td>
                        <asp:TextBox id="txtStamp" runat="server" ReadOnly="True"></asp:TextBox></td>
                    <td><asp:Label id="Label38" runat="server" width="96px" font-size="Small" font-names="Verdana" font-bold="False" backcolor="Transparent">Basic Charges</asp:Label></td>
                    <td>
                        <asp:TextBox id="txtBasicCharges" runat="server" ReadOnly="True"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>
                        <asp:Label id="Label8" runat="server" font-bold="False" font-names="Verdana" font-size="Small"
                            Text="Gross Amount"></asp:Label></td>
                    <td>
                        <asp:TextBox id="txtTotGross" runat="server" ReadOnly="True"></asp:TextBox></td>
                    <td>
                        <asp:Label id="Label36" runat="server" font-bold="False" font-names="Verdana" font-size="Small"
                            Text="Total Charges"></asp:Label></td>
                    <td>
                        <asp:TextBox id="txtCharges" runat="server" ReadOnly="True"></asp:TextBox></td>
                    <td><asp:Label id="Label41" runat="server" width="96px" font-size="Small" font-names="Verdana" font-bold="False" backcolor="Transparent">Total Payable</asp:Label></td>
                    <td>
                        <asp:TextBox id="txtTotpay" runat="server" ReadOnly="True"></asp:TextBox></td>
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
                    <td><asp:Label id="Label12" runat="server" font-bold="False" font-names="Verdana" 
                            font-size="Small" Text="Expiry Date"></asp:Label></td>
                    <td>
                        <BDP:BasicDatePicker id="txtExpiryDate" runat="server">
                        </BDP:BasicDatePicker>
                    </td>
                    <td></td>
                    <td></td>
                </tr>
                <tr>
                    <td><asp:Label id="Label42" runat="server" font-size="Small" font-names="Verdana" font-bold="False" Text="Total Net Value" width="104px"></asp:Label></td>
                    <td>
                        <asp:TextBox id="TextBox13" runat="server"></asp:TextBox></td>
                        <td>
                            <asp:Label id="Label9" runat="server" Text="Purchase Made by:" font-bold="False" font-names="Verdana" font-size="Small"></asp:Label></td>
                        <td colspan="2">
                            <asp:Label id="lblBuyer" runat="server" font-bold="False" font-names="Verdana" font-size="Small" width="296px"></asp:Label></td>
                </tr>
                <tr>
                    <td colspan="6" align="center" bgcolor="#8080ff" style="height: 31px">
                        <asp:Label id="Label10" runat="server" Text="..................................................................................................................................................................................................." width="832px"></asp:Label></td>
                </tr>
                <tr>
                    <td colspan ="1" style="width: 147px">
                        </td>
                        <td colspan="1" style="width: 203px">
                                <asp:Button id="btnPrintStatement" runat="server" Text="Save Sale Order" /></td>
                            <td colspan ="1" style="width: 172px">
                                <asp:Button id="btnUpdateOrder" runat="server" Text="Update Purchase Order" /></td>
                                <td colspan ="1" style="width: 172px">
                                <asp:Button id="btnCancelOrder" runat="server" Text="Cancel Purchase Order" /></td>
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

