<%@ Page Language="VB" MasterPageFile="~/CDSUser.master" AutoEventWireup="false" CodeFile="PledgeUpdate.aspx.vb" Inherits="Pledges_PledgeUpdate" title="Deposit Securities" %>
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
                        Text="Pledges Update" width="848px"></asp:Label></td>
            </tr>
            <tr>
                <td>
                    <asp:Label id="Label8" runat="server" Text="Pledge From" font-bold="True" 
                        forecolor="Red"></asp:Label></td>
            </tr>
                
            </table>
            <table>
                <tr>
                    <td style="width: 146px; height: 24px;">
                        <asp:Label id="Label1" runat="server" font-names="Verdana" font-size="Small" 
                            Text="Shareholder Number:" width="144px"></asp:Label>
                    </td>
                        <td style="width: 3px; height: 24px;">
                            <asp:TextBox id="txtshareholder" runat="server"></asp:TextBox>
                    </td>
                            <td style="width: 3px; height: 24px;">
                                <asp:Button id="btnHolderNumSearch" runat="server" Text="&gt;&gt;" />
                    </td>
                                <td style="height: 24px">
                                    &nbsp;</td>
                                    <td style="width: 141px; height: 24px;">
                                        &nbsp;</td>
                </tr>                
                <tr>
                    <td style="width: 146px; height: 24px;">
                        <asp:Label id="Label5" runat="server" font-names="Verdana" font-size="Small" 
                            Text="Shareholder Name:"></asp:Label>
                    </td>
                    <td style="width: 3px; height: 24px;">
                        <asp:TextBox id="txtSearch" runat="server" width="144px"></asp:TextBox>
                    </td>
                    <td style="width: 3px; height: 24px;">
                        <asp:Button id="btnSearchName" runat="server" Text="&gt;&gt;" />
                    </td>
                    <td style="height: 24px">
                    </td>
                    <td style="width: 141px; height: 24px;">
                    </td>
                </tr>
            </table>
            <table>
                <tr>
                    <td style="width: 146px"></td>
                    <td style="width: 180px">
                        <asp:ListBox id="lstNames" runat="server" Height="52px" width="268px"></asp:ListBox></td>
                </tr>
                <tr>
                    <td></td>
                    <td align="center" style="width: 180px">
                        <asp:Button id="btnSelect" runat="server" Text="Select" /></td>
                </tr>
                <tr>
                    <td style="height: 24px">
                        <asp:Label id="Label2" runat="server" Text="Company"></asp:Label></td>
                    <td style="height: 24px; width: 180px;">
                        <asp:DropDownList id="cmbCompany" runat="server" width="192px" autopostback="True">
                        </asp:DropDownList></td>
                </tr>
                <tr>
                    <td>
                        <asp:Label id="Label3" runat="server" Text="Pledged Shares"></asp:Label></td>
                        <td style="width: 180px">
                            <asp:TextBox id="txtPledges" runat="server" ReadOnly="True"></asp:TextBox></td>
                </tr>
                <tr>
                    <td colspan ="4" style="height: 24px">
                        <asp:Label id="Label9" runat="server" Text="Pledge To:" font-bold="True" 
                            forecolor="Red"></asp:Label>
                    </td>
                    
                </tr>
                <tr>
                    <td style="width: 146px">
                        <asp:Label id="Label10" runat="server" Text="Shareholder Number:" 
                            font-names="Verdana" font-size="Small"></asp:Label></td>
                        <td style="width: 180px">
                            <asp:TextBox id="TextBox1" runat="server" width="144px"></asp:TextBox>
                            <asp:Button id="Button1" runat="server" Text="&gt;&gt;" />
                    </td>
                            <td style="width: 3px">
                                &nbsp;</td>
                                <td>
                                    </td>
                                    <td style="width: 141px">
                                        </td>
                </tr>                
                <tr>
                    <td style="width: 146px">
                        <asp:Label id="Label11" runat="server" Text="Shareholder Name:" font-names="Verdana" font-size="Small"></asp:Label></td>
                        <td style="width: 180px">
                            <asp:TextBox id="TextBox2" runat="server" width="144px"></asp:TextBox>
                            <asp:Button id="Button2" runat="server" Text="&gt;&gt;" />
                    </td>
                            <td style="width: 3px">
                                &nbsp;</td>
                                <td>
                                    </td>
                                    <td style="width: 141px">
                                        </td>
                </tr> 
                <tr>
                    <td style="width: 146px"></td>
                    <td style="width: 180px">
                        <asp:ListBox id="ListBox1" runat="server" Height="52px" width="268px"></asp:ListBox></td>
                </tr>  
                <tr>
                    <td></td>
                    <td>
                        <asp:Button id="Button3" runat="server" Text="Select" /></td>
                </tr>         
                <tr>
                    <td>
                        <asp:Label id="Label6" runat="server" Text="Options"></asp:Label></td>
                        <td style="width: 180px">
                            <asp:RadioButton id="rdEdit" runat="server" GroupName="PledgeOptions" Text="Edit Pledge" autopostback="True" /><asp:RadioButton id="rdClear"
                                runat="server" GroupName="PledgeOptions" Text="Clear Pledge" autopostback="True" /></td>
                </tr>
                <tr>
                    <td>
                        <asp:Label id="Label7" runat="server" Text="Pledge Update Shares"></asp:Label></td>
                    <td style="width: 180px">
                        <asp:TextBox id="txtPledgesShares" runat="server"></asp:TextBox></td>
                </tr>
            </table>
            <table>
            <tr>
                    <td colspan ="4" style="width: 850px" align="center">
                        &nbsp;</td>                
                </tr>
                <tr>
                    <td colspan ="4" style="width: 850px" align="center">
                        <asp:Button id="btnSave" runat="server" Text="Save" width="96px" /></td>                
                </tr>
            </table>
        </td>
    </tr>
</table>
</asp:Panel>
</div>
</asp:Content>

