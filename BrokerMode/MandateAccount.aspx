<%@ Page Language="VB" MasterPageFile="~/CDSUser.master" AutoEventWireup="false" CodeFile="MandateAccount.aspx.vb" Inherits="BrokerMode_MandateAccount" title="Mandates Creation" %>
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
                        Text="Mandates Creation" width="848px"></asp:Label></td>
            </tr>
                <tr>
                    <td colspan ="4" valign="top">
                        &nbsp;</td>
                </tr>
                
            </table>
            <table>
                <tr>
                    <td style="width: 165px">
                        <asp:Label id="Label1" runat="server" font-names="Verdana" font-size="Small" 
                            Text="Shareholder Number:" width="156px" Height="16px"></asp:Label>
                    </td>
                        <td style="width: 3px">
                            <asp:TextBox id="txtshareholder" runat="server"></asp:TextBox>
                    </td>
                            <td style="width: 3px">
                                <asp:Button id="btnHolderNumSearch" runat="server" Text="&gt;&gt;" />
                    </td>
                                <td>
                                    &nbsp;</td>
                                    <td style="width: 141px">
                                        &nbsp;</td>
                </tr>                
                <tr>
                    <td style="width: 165px">
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
                    <td style="width: 165px"></td>
                    <td style="width: 148px">
                        <asp:ListBox id="ListBox1" runat="server" Height="60px" width="328px"></asp:ListBox></td>
                </tr>
                <tr>
                    <td style="width: 165px"></td>
                    <td align="right">
                        <asp:Button id="btnSelect" runat="server" Text="Select" /></td>
                </tr>
                <tr>
                    <td colspan="2">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:CheckBox id="chkThirdParty" runat="server" font-names="Verdana" 
                            font-size="Small" Text="Third Party Mandate" />
                        <asp:CheckBox id="chkBankMandate" runat="server" font-names="Verdana" 
                            font-size="Small" Text="Bank Mandate" />
                    </td>
                </tr>
            </table>
            <table>
                <tr>
                    <td colspan ="1" style="width: 172px">
                        <asp:Label id="Label2" runat="server" Text="Surname" font-names="Verdana" font-size="Small"></asp:Label></td>
                        <td colspan="1" style="width: 203px">
                            <asp:TextBox id="txtSurname" runat="server"></asp:TextBox></td>
                            <td colspan ="1" style="width: 172px">
                                <asp:Label id="Label3" runat="server" Text="Fornames" font-names="Verdana" font-size="Small"></asp:Label></td>
                                <td colspan ="1" style="width: 316px">
                                    <asp:TextBox id="txtforenames" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="width: 172px">
                        <asp:Label id="Label6" runat="server" Text="id Number" font-names="Verdana" font-size="Small"></asp:Label></td>
                        <td>
                            <asp:TextBox id="txtID" runat="server"></asp:TextBox></td>
                            <td>
                            </td>
                            <td>&nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 172px"></td>
                    <td></td>
                    <td></td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 172px">
                        <asp:Label id="Label7" runat="server" Text="Address:" font-names="Verdana" font-size="Small"></asp:Label></td>
                        <td>
                            <asp:TextBox id="txtAdd1" runat="server"></asp:TextBox></td>
                            <td>
                                <asp:Label id="Label9" runat="server" font-names="Verdana" font-size="Small" 
                                    Text="City/Town"></asp:Label>
                    </td>
                            <td>
                                <asp:DropDownList id="CmbCity" runat="server" width="142px">
                                </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td style="width: 172px"></td>
                    <td>
                        <asp:TextBox id="txtadd3" runat="server"></asp:TextBox></td>
                        <td>
                            <asp:Label id="Label11" runat="server" font-names="Verdana" font-size="Small" 
                                Text="Cellphone"></asp:Label>
                    </td>
                        <td>
                            <asp:TextBox id="txtCell" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="width: 172px">
                        &nbsp;</td>
                    <td>
                        <asp:TextBox id="txtAdd2" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:Label id="Label13" runat="server" font-names="Verdana" font-size="Small" 
                            Text="Fax"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox id="txtFax" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="width: 172px">
                        &nbsp;</td>
                    <td>
                        <asp:TextBox id="txtadd4" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 172px">
                        <asp:Label id="Label8" runat="server" Text="Country" font-names="Verdana" font-size="Small"></asp:Label></td>
                        <td>
                            <asp:DropDownList id="cmbCountry" runat="server" width="142px">
                            </asp:DropDownList></td>
                            <td>
                                <asp:Label id="Label15" runat="server" font-names="Verdana" font-size="Small" 
                                    Text="Branch"></asp:Label>
                    </td>
                                <td>
                                    <asp:DropDownList id="cmbBranch" runat="server" width="142px">
                                    </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td style="width: 172px">
                        <asp:Label id="Label10" runat="server" Text="Telephone:" font-names="Verdana" font-size="Small"></asp:Label></td>
                        <td>
                            <asp:TextBox id="txtTel" runat="server"></asp:TextBox></td>
                            <td>
                                <asp:Label id="Label17" runat="server" font-names="Verdana" font-size="Small" 
                                    Text="Account Type"></asp:Label>
                    </td>
                                <td>
                                    <asp:DropDownList id="cmbAccType" runat="server" width="142px">
                                    </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td style="width: 172px">
                        <asp:Label id="Label12" runat="server" Text="Email" font-names="Verdana" font-size="Small"></asp:Label></td>
                        <td>
                            <asp:TextBox id="txtEmail" runat="server"></asp:TextBox></td>
                            <td>
                                <asp:Label id="Label14" runat="server" font-names="Verdana" font-size="Small" 
                                    Text="Bank"></asp:Label>
                    </td>
                                <td>
                                    <asp:DropDownList id="cmbBank" runat="server" width="142px">
                                    </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td style="width: 172px">
                        <asp:Label id="Label16" runat="server" font-names="Verdana" font-size="Small" 
                            Text="Account Number"></asp:Label>
                        </td>
                    <td>
                        <asp:TextBox id="txtBnkAccount" runat="server"></asp:TextBox>
                    </td>
                    <td></td>
                    <td></td>
                </tr>
                
            </table>
            <table>
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

