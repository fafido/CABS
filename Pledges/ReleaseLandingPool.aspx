<%@ Page Language="VB" MasterPageFile="~/CDSUser.master" AutoEventWireup="false" CodeFile="ReleaseLandingPool.aspx.vb" Inherits="Pledges_ReleaseLandingPool" title="Deposit Securities" %>
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
                        Text="Release from Lending Pool" width="848px"></asp:Label></td>
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
                    <td style="width: 167px">
                        <asp:Label id="Label1" runat="server" font-names="Verdana" font-size="Small" 
                            Text="Security" width="144px"></asp:Label>
                    </td>
                        <td style="width: 3px">
                            <asp:DropDownList id="cmbSecurityType" runat="server" autopostback="True" 
                                width="142px">
                            </asp:DropDownList>
                    </td>
                            <td style="width: 3px">
                                &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                    <td style="width: 141px">
                                        &nbsp;</td>
                </tr>                
                <tr>
                    <td style="width: 167px">
                        <asp:Label id="Label5" runat="server" font-names="Verdana" font-size="Small" 
                            Text="Shareholder Name:"></asp:Label>
                    </td>
                    <td style="width: 3px">
                        <asp:TextBox id="txtSearch" runat="server" width="144px"></asp:TextBox>
                    </td>
                    <td style="width: 3px">
                        <asp:Button id="btnSearchName" runat="server" Text="&gt;&gt;" />
                    </td>
                    <td>
                    </td>
                    <td style="width: 141px">
                    </td>
                </tr>
            </table>
            <table>
                <tr>
                    <td style="width: 166px"></td>
                    <td style="width: 148px">
                        <asp:ListBox id="lstNames" runat="server" Height="62px" width="277px"></asp:ListBox></td>
                </tr>
                <tr>
                    <td style="width: 166px"></td>
                    <td align="right">
                        <asp:Button id="btnSelect" runat="server" Text="Select" /></td>
                </tr>
                <tr>
                    <td style="width: 166px"></td>
                    <td>
                        <asp:Label id="lblShareholder" runat="server"></asp:Label>
                        </td>
                </tr>
            </table>
            <table>
                <tr>
                    <td colspan ="1" style="width: 192px; height: 26px;">
                        <asp:Label id="Label2" runat="server" Text="Surname" font-names="Verdana" font-size="Small"></asp:Label></td>
                        <td colspan="1" style="width: 203px; height: 26px;">
                            <asp:TextBox id="txtSurname" runat="server" Height="18px" ReadOnly="True" 
                                width="272px"></asp:TextBox></td>
                            <td colspan ="1" style="width: 172px; height: 26px;">
                                </td>
                                <td colspan ="1" style="width: 316px; height: 26px;">
                                    </td>
                </tr>
                <tr>
                    <td style="width: 192px">
                        <asp:Label id="Label6" runat="server" Text="id Number" font-names="Verdana" 
                            font-size="Small"></asp:Label></td>
                        <td>
                            <asp:TextBox id="txtID" runat="server" ReadOnly="True" width="272px"></asp:TextBox></td>
                            <td>
                            </td>
                            <td></td>
                </tr>
                <tr>
                    <td style="width: 192px">
                        <asp:Label id="Label16" runat="server" Text="Counter"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList id="cmbCompany" runat="server" autopostback="True" 
                            width="150px">
                        </asp:DropDownList>
                    </td>
                    <td></td>
                    <td></td>
                </tr>
                <tr>
                    <td style="width: 192px; height: 35px;">
                        <asp:Label id="Label7" runat="server" Text="Transfer Quantity" 
                            font-names="Verdana" font-size="Small"></asp:Label></td>
                        <td style="height: 35px">
                            <asp:TextBox id="txtQuantity" runat="server" Height="27px" width="272px" 
                                ReadOnly="True"></asp:TextBox></td>
                            <td style="height: 35px"></td>
                            <td style="height: 35px">
                                </td>
                </tr>
                <tr>
                    <td style="width: 192px">
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
                    <td style="width: 192px">
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

