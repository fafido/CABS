<%@ Page Language="VB" MasterPageFile="~/CDSUser.master" AutoEventWireup="false" CodeFile="FreezeUnfreezeAudit.aspx.vb" Inherits="Pledges_FreezeUnfreezeAudit" title="Deposit Securities" %>
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
                        Text="Freeze / Unfreeze Accounts Authorization" width="848px"></asp:Label></td>
            </tr>
            <tr>
                <td colspan ="2">
                    <asp:Label id="Label8" runat="server" font-names="Verdana" font-size="Small" 
                        Height="16px" Text="Select Acount Number" width="168px"></asp:Label>
                    <asp:DropDownList id="DropDownList1" runat="server" autopostback="True" 
                        width="183px">
                    </asp:DropDownList>
                </td>
                <td colspan ="2"></td>
            </tr>
                <tr>
                    <td colspan ="4" valign="top">
                        <asp:Label id="Label1" runat="server" Text="Shareholder Number:" width="160px" 
                            font-names="Verdana" font-size="Small"></asp:Label>
                        &nbsp;
                        <asp:TextBox id="txtshareholder" runat="server"></asp:TextBox>
                        <asp:Button id="btnHolderNumSearch" runat="server" Text=">>" /></td>
                </tr>
                
            </table>
            <table>
                <tr>
                    <td style="width: 165px">
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
                        <asp:ListBox id="lstNames" runat="server" Height="136px" width="328px"></asp:ListBox></td>
                </tr>
                <tr>
                    <td></td>
                    <td align="center">
                        <asp:Button id="btnSelect" runat="server" Text="Select" /></td>
                </tr>
                <tr>
                    <td style="height: 24px">
                        <asp:Label id="Label2" runat="server" Text="Company"></asp:Label></td>
                    <td style="height: 24px">
                        <asp:DropDownList id="cmbCompany" runat="server" width="192px" autopostback="True">
                        </asp:DropDownList></td>
                </tr>
                <tr>
                    <td>
                        &nbsp;</td>
                        <td>
                            &nbsp;</td>
                </tr>
                <tr>
                    <td>
                        <asp:Label id="Label6" runat="server" Text="Options"></asp:Label></td>
                        <td>
                            <asp:RadioButton id="rdEdit" runat="server" GroupName="PledgeOptions" Text="Freeze Account" autopostback="True" /><asp:RadioButton id="rdClear"
                                runat="server" GroupName="PledgeOptions" Text="Unfreeze Account" 
                                autopostback="True" /></td>
                </tr>
                <tr>
                    <td>
                        <asp:Label id="Label7" runat="server" Text="Freeze / Unfreeze Reason"></asp:Label></td>
                    <td>
                        <asp:TextBox id="txtPledgesShares" runat="server" Height="110px" 
                            TextMode="MultiLine" width="339px"></asp:TextBox></td>
                </tr>
            </table>
            <table>
            <tr>
                    <td colspan ="4" style="width: 850px" align="center">
                        &nbsp;</td>                
                </tr>
                <tr>
                    <td colspan ="4" style="width: 850px" align="center">
                        <asp:Button id="btnSave" runat="server" Text="Authorize" width="96px" />
                        <asp:Button id="btnSave0" runat="server" Text="Decline" width="96px" />
                    </td>                
                </tr>
            </table>
        </td>
    </tr>
</table>
</asp:Panel>
</div>
</asp:Content>

