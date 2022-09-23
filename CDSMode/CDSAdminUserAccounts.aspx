<%@ Page Language="VB" MasterPageFile="~/CDSMain.master" AutoEventWireup="false" CodeFile="CDSAdminUserAccounts.aspx.vb" Inherits="CDSAdminUserAccounts" %>

<asp:Content id="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<asp:Panel id="Panel1" runat="server">
    
<table style="border-right: #000033 thin solid; border-top: #000033 thin solid; border-left: #000033 thin solid; width: 832px; border-bottom: #000033 thin solid; background-color: #ffffff">
    <tr>
        <td style="width: 712px; height: 226px" valign="top">
            <table>
            <tr>
                <td style="width: 870px" align="center">
                    <asp:Label id="Label4" runat="server" backcolor="#8080FF" font-bold="True" font-names="Arial"
                        text="System User Account Creation" width="848px"></asp:Label></td>
            </tr>
                <tr>
                    <td valign="top">
                    
                        <table>
                            <tr>
                                <td colspan ="2"><asp:Label runat="server" text="User name"></asp:Label></td>
                                <td colspan ="2">
                                    <asp:TextBox runat="server" id="txtUsername" autopostback="True" 
                                        width="170px"></asp:TextBox></td>
                                <td colspan = "1">
                                    <asp:Label id="lblPasswordValidation" runat="server"></asp:Label>
                                </td>
                                <td colspan = "1"></td>
                                <td colspan ="2">
                                    <asp:CheckBox id="chkRejectedAccounts" runat="server" autopostback="True" 
                                        Text="Rejected Accounts" Visible="False" />
                                </td>
                                <td colspan ="2">
                                    <asp:DropDownList id="cmbRejections" runat="server" autopostback="True" 
                                        Enabled="False" width="130px" Visible="False">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td colspan ="2"><asp:Label runat="server" text="Forenames"></asp:Label></td>
                                <td colspan ="2"><asp:TextBox runat="server" id="txtForenames" width="167px"></asp:TextBox></td>
                                <td colspan = "1">
                                    <asp:Label id="lblCompanyCode" runat="server" visible="False"></asp:Label>
                                </td>
                                <td colspan = "1"></td>
                                <td colspan ="2"><asp:Label runat="server" text="Surname"></asp:Label></td>
                                <td colspan ="2"><asp:TextBox runat="server" id="txtSurname" width="178px"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td colspan ="2"><asp:Label runat="server" text="Organization"></asp:Label></td>
                                <td colspan ="2">
                                    <asp:DropDownList runat="server" autopostback="True" width="167px" 
                                        id="cmbCompany"></asp:DropDownList></td>
                                <td colspan = "1">
                                    <asp:Label id="lblCompanytype" runat="server" Visible="False"></asp:Label>
                                </td>
                                <td colspan = "1"></td>
                                <td colspan ="2"><asp:Label runat="server" text="Department"></asp:Label></td>
                                <td colspan ="2">
                                    <asp:DropDownList runat="server" autopostback="True" width="175px" 
                                        id="cmbDepartment"></asp:DropDownList></td>
                            </tr>
                            <tr>
                                <td colspan ="2"><asp:Label runat="server" text="User role" Visible="False"></asp:Label></td>
                                <td colspan ="2">
                                    <asp:DropDownList runat="server" autopostback="True" width="130px" 
                                        id="cmbRoles" Visible="False"></asp:DropDownList></td>
                                <td colspan = "1">
                                    <asp:Label id="lblCompanyCodee" runat="server" Visible="False"></asp:Label>
                                </td>
                                <td colspan = "1"></td>
                                <td colspan ="2"></td>
                                <td colspan ="2"></td>
                            </tr>
                            <tr>
                                <td colspan ="2"><asp:Label runat="server" text="Email" width="130px"></asp:Label></td>
                                <td colspan ="2"><asp:TextBox runat="server" width="168px" id="txtEmail"></asp:TextBox></td>
                                <td colspan = "1"></td>
                                <td colspan = "1"></td>
                                <td colspan ="2"><asp:Label runat="server" Text="Telephone - Ext"></asp:Label></td>
                                <td colspan ="2"><asp:TextBox width="177px" runat="server" id="txtTelephone"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td colspan ="2"><asp:Label runat="server" text="Mobile 1" width="130px"></asp:Label></td>
                                <td colspan ="2"><asp:TextBox runat="server" width="165px" id="txtMobile1"></asp:TextBox></td>
                                <td colspan = "1"></td>
                                <td colspan = "1"></td>
                                <td colspan ="2"><asp:Label runat="server" Text="Mobile 2"></asp:Label></td>
                                <td colspan ="2"><asp:TextBox width="174px" runat="server" id="txtMobile2"></asp:TextBox></td>
                            </tr>
                            
                            <tr>
                                <td colspan ="10" align="center"><asp:Label runat="server"></asp:Label>
                                    <asp:RadioButton id="rdSuperAdmin" runat="server" autopostback="True" 
                                        GroupName="Adminlevel" Text="Super Administrator" />
                                    <asp:RadioButton id="rdAdmin" runat="server" autopostback="True" 
                                        GroupName="Adminlevel" Text="Administrator" />
                                    <asp:RadioButton id="rdStandard" runat="server" autopostback="True" 
                                        GroupName="Adminlevel" Text="Standard User" />
                                </td>
                            </tr>
                            <tr>
                            <td align="center" colspan ="10">
                                <asp:CheckBox id="chkAssign" runat="server" autopostback="True" 
                                    Text="Allocate Permission at Company Level" />
                                </td>
                            </tr>
                 
                            <tr>
                               <td colspan ="2">&nbsp;</td>
                                    <td colspan ="2">
                                        &nbsp;</td>
                                    <td colspan ="2">&nbsp;</td>
                                    <td colspan ="2">
                                        &nbsp;</td>
                                    <td colspan ="2">
                                        &nbsp;</td>
                            </tr>
                            
                            
                                <tr>
                                <td colspan ="2">&nbsp;</td>
                                    <td colspan ="2">&nbsp;</td>
                                    <td colspan ="2">
                                        &nbsp;</td>
                                    <td colspan ="2">
                                        &nbsp;</td>
                                    <td colspan ="2">&nbsp;</td>
                                </tr>
                                
                                <tr>
                                <td colspan ="10"><asp:Label runat="server" Text=""></asp:Label></td>
                            </tr>
                            <tr>
                                <td colspan ="2">&nbsp;</td>
                                    <td colspan ="2">&nbsp;</td>
                                    <td colspan ="2">&nbsp;</td>
                                    <td colspan ="2">&nbsp;</td>
                                    <td colspan ="2"></td>
                                </tr>
                                <tr>
                                <td colspan ="10" align="center"><asp:Button runat="server" Text="Save" 
                                        onclick="Unnamed17_Click"></asp:Button></td>
                                </tr>
                        </table>
                        &nbsp;</td>
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
        </td>
    </tr>
</table>
</asp:Panel>

</asp:Content>

