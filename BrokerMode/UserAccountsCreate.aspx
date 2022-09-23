<%@ Page Language="VB" MasterPageFile="~/CDSUser.master" AutoEventWireup="false" CodeFile="UserAccountsCreate.aspx.vb" Inherits="BrokerMode_UserAccountsCreate" %>

<asp:Content id="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<asp:Panel id="Panel1" runat="server">
    
<table style="border-right: #000033 thin solid; border-top: #000033 thin solid; border-left: #000033 thin solid; width: 832px; border-bottom: #000033 thin solid; background-color: #ffffff">
    <tr>
        <td style="width: 712px; height: 226px" valign="top">
            <table>
            <tr>
                <td style="width: 870px" align="center">
                    <asp:Label id="Label4" runat="server" backcolor="#8080FF" font-bold="True" font-names="Arial"
                        text="User Accounts Creation" width="848px"></asp:Label></td>
            </tr>
                <tr>
                    <td valign="top">
                    
                        <table>
                            <tr>
                                <td></td>
                                <td></td>
                                <td></td>
                                <td><asp:CheckBox autopostback="true" id="chkedit" text="Edit user accounts" runat="server"></asp:CheckBox></td>
                            </tr>
                            <tr>

                                    <td></td>
                                <td></td>
                                <td>
                                    <asp:Label ID="Label11" runat="server" text="Select User:"></asp:Label>
                                    </td>
                                <td>
                                    <asp:DropDownList ID="cmbSavedUsers" runat="server" autopostback="True" width="200px">
                                    </asp:DropDownList>
                                    </td>
                            </tr>
                            <tr>

                                <td>
                                    <asp:Label runat="server" text="Organization"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="cmbCompany" runat="server" autopostback="True" width="200px">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:Label ID="Label5" runat="server" text="Organization Type"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="cmbOrganizationType" runat="server" autopostback="True" width="200px">
                                    </asp:DropDownList>
                                </td>

                            </tr>
                            <tr>

                                <td><asp:Label runat="server" id="lblcompanyCode" Visible="False"></asp:Label></td>
                                <td></td>
                                <td></td>
                                <td></td>
                            </tr>
                            <tr>

                                <td>
                                    <asp:Label runat="server" text="Department"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="cmbDepartment" runat="server" autopostback="True" width="200px">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:Label ID="Label6" runat="server" text="User Type"></asp:Label>
                                </td>
                                <td>
                                    <asp:RadioButton ID="rdSystemUser" runat="server" AutoPostBack="True" GroupName="userType" Text="System User" />
                                    <asp:RadioButton ID="rdSystemAdmin" runat="server" AutoPostBack="True" GroupName="userType" Text="System Admin" />
                                </td>

                            </tr>
                            <tr>

                                <td>
                                    <asp:Label runat="server" text="Forenames"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtForenames" runat="server" width="200px"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:Label runat="server" text="Surname"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtSurname" runat="server" width="200px"></asp:TextBox>
                                </td>

                            </tr>
                            <tr>

                                <td>
                                    <asp:Label runat="server" text="User name"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtUsername" runat="server" autopostback="True" Width="200px"></asp:TextBox>
                                </td>
                                <td></td>
                                <td></td>

                            </tr>
                            <tr>

                                <td>
                                    <asp:Label ID="Label7" runat="server" text="email"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtemail" runat="server" autopostback="True" Width="200px"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:Label ID="Label8" runat="server" text="mobile 1"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtmobile1" runat="server" autopostback="True" Width="200px"></asp:TextBox>
                                </td>

                            </tr>
                            <tr>

                                <td>
                                    <asp:Label ID="Label9" runat="server" text="telephone"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtTelephone" runat="server" autopostback="True" Width="200px"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:Label ID="Label10" runat="server" text="mobile 2"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtmobile2" runat="server" autopostback="True" Width="200px"></asp:TextBox>
                                </td>

                            </tr>
                            <tr>

                                <td></td>
                                <td></td>
                                <td></td>
                                <td></td>

                            </tr>
                            <tr>

                                <td colspan ="4" style ="text-align:center;"><asp:RadioButton id="rdCreateNew" groupname="AccOptions" autopostback="true" text="Create New" runat="server"></asp:RadioButton>
                                    <asp:RadioButton ID="rdUpdateAccount" runat="server" autopostback="true" groupname="AccOptions" text="Update Account" />
                                    <asp:RadioButton ID="rdResetPass" runat="server" autopostback="true" groupname="AccOptions" text="Reset Password" />
                                    <asp:RadioButton ID="rdDeleteAccount" runat="server" autopostback="true" groupname="AccOptions" text="Delete Account" />
                                    <asp:RadioButton ID="rdAccountReport" runat="server" autopostback="true" groupname="AccOptions" text="View Account(s) Report" />
                                </td>

                            </tr>
                            <tr>

                                    <td colspan ="4" style="text-align:center;">
                                        <asp:Button ID="btnSave" runat="server" Text="Save" />
                                    </td>
                            </tr>
                      
             
                
            </table>
        </td>
    </tr>
</table>
    </asp:Panel>

</asp:Content>

