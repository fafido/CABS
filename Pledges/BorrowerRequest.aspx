<%@ Page Language="VB" MasterPageFile="~/CDSUser.master" AutoEventWireup="false" CodeFile="BorrowerRequest.aspx.vb" Inherits="Pledges_BorrowerRequest" title="BorrowerRequest" %>
<%@ Register assembly="BasicFrame.WebControls.BasicDatePicker" namespace="BasicFrame.WebControls" tagprefix="BDP" %>
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
                        Text="Borrower Request" width="848px"></asp:Label></td>
            </tr>
                            <tr>
                    <td valign="top">
                        &nbsp;</td>
                </tr>
                
                <tr>
                    <td valign="top">
                        &nbsp;</td>
                </tr>
                
            </table>
            <table>
            <tr>
                <td colspan ="1" style="height: 18px; width: 144px;"></td>
                <td colspan ="1" style="height: 18px; width: 271px;"></td>
                <td colspan ="1" style="height: 18px"></td>
                <td colspan ="1" style="height: 18px"></td>
            </tr>
                <tr>
                    <td colspan="1" style="width: 144px">
                        <asp:Label id="Label1" runat="server" font-names="Verdana" font-size="Small" 
                            Text="Security" width="144px"></asp:Label>
                    </td>
                        <td colspan="1" style="width: 271px">
                            <asp:DropDownList id="cmbSecurityType" runat="server" autopostback="True" 
                                width="173px">
                            </asp:DropDownList>
                    </td>
                            <td colspan="1">
                                <asp:Label ID="Label19" runat="server" font-names="Verdana" font-size="Small" 
                                    width="174px" style="text-align: right"></asp:Label>
                    </td>
                                <td colspan="1">
                                    <asp:DropDownList ID="cmbSecurityType0" runat="server" autopostback="True" 
                                        width="142px">
                                    </asp:DropDownList>
                    </td>
                    
                                    
                </tr>                
                <tr>
                    <td colspan ="1" style="width: 144px">
                        <asp:Label ID="Label20" runat="server" font-names="Verdana" font-size="Small" 
                            width="144px"></asp:Label>
                    </td>
                    <td colspan ="1" style="width: 271px">
                        <asp:Label ID="Label21" runat="server" font-names="Verdana" font-size="Small" 
                            width="144px"></asp:Label>
                    </td>
                    <td colspan ="1">
                        <asp:Label ID="Label22" runat="server" font-names="Verdana" font-size="Small" 
                            style="text-align: right" width="170px"></asp:Label>
                    </td>
                    <td colspan ="1">
                        <asp:Label ID="Label23" runat="server" font-names="Verdana" font-size="Small" 
                            width="170px"></asp:Label>
                    </td>                    
                </tr>
                <tr>
                    <td colspan="1" style="width: 144px">
                        <asp:Label id="Label5" runat="server" font-names="Verdana" font-size="Small" 
                            Text="Name:"></asp:Label>
                    </td>
                    <td colspan="1" style="width: 271px">
                        <asp:TextBox id="txtSearch" runat="server" width="144px"></asp:TextBox>
                        <asp:Button ID="btnSearchName" runat="server" Text="&gt;&gt;" />
                    </td>
                    <td colspan="1">
                        &nbsp;</td>
                    <td colspan="1">
                    </td>
                    
                </tr>
            </table>
            <table>
                <tr>
                    <td style="width: 140px"></td>
                    <td style="width: 148px">
                        <asp:ListBox id="lstNames" runat="server" Height="62px" width="277px" 
                            AutoPostBack="True"></asp:ListBox></td>
                </tr>
                <tr>
                    <td style="width: 140px"></td>
                    <td align="right">
                        <asp:Button id="btnSelect" runat="server" Text="Select" /></td>
                </tr>
                <tr>
                    <td style="width: 140px"></td>
                    <td>
                        <asp:Label id="lblShareholder" runat="server"></asp:Label>
                        </td>
                </tr>
            </table>
            <table>
           <tr>
                    <td style="width: 143px; height: 35px;">
                        <asp:Label id="Label7" runat="server" Text="Quantity Required" 
                            font-names="Verdana" font-size="Small"></asp:Label></td>
                        <td style="height: 35px">
                            <asp:TextBox id="txtQuantity" runat="server" Height="27px" width="272px"></asp:TextBox></td>
                            <td style="height: 35px"></td>
                            <td style="height: 35px">
                                </td>
                </tr>
                
                <tr>
                    <td style="width: 143px">
                        <asp:Label id="Label17" runat="server" font-names="Verdana" font-size="Small" 
                            Text="Settlement Date"></asp:Label>
                    </td>
                    <td>
                        
                        <BDP:BasicDatePicker id="SettlementDate" runat="server" />
                        
                    </td>
                    <td></td>
                    <td></td>
                </tr>
                <tr>
                    <td style="width: 143px">
                        <asp:Label id="Label18" runat="server" font-names="Verdana" font-size="Small" 
                            Text="Return Date"></asp:Label>
                    </td>
                    <td>
                       
                        <BDP:BasicDatePicker id="SettlementDate0" runat="server" />
                       
                    </td>
                    <td></td>
                    <td></td>
                </tr>
                
                <tr>
                    <td style="width: 143px">
                        &nbsp;</td>
                        <td>
                            <asp:Button id="Button1" runat="server" Text="Save" />
                    </td>
                            <td>
                                </td>
                                <td>
                                    </td>
                </tr>
                <tr>
                    <td style="width: 143px">
                        &nbsp;</td>
                        <td>
                            &nbsp;</td>
                            <td>
                                </td>
                                <td>
                                    </td>
                </tr>
                
          
                
            </table>
    
        </td>
    </tr>
</table>
</asp:Panel>
</div>
</asp:Content>

