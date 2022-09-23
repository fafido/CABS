<%@ Page Language="VB" MasterPageFile="~/CDSUser.master" AutoEventWireup="false" CodeFile="AdminUserAccounts.aspx.vb" Inherits="CDSMode_AdminUserAccounts" title="TSec Home" %>
<asp:Content id="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
    <asp:Panel id="Panel1" runat="server">
    
<table style="border-right: #000033 thin solid; border-top: #000033 thin solid; border-left: #000033 thin solid; width: 832px; border-bottom: #000033 thin solid; background-color: #ffffff">
    <tr>
        <td style="width: 759px; height: 226px" valign="top">
            <table>
            <tr>
                <td style="width: 870px" align="center">
                    <asp:Label id="Label4" runat="server" backcolor="#8080FF" font-bold="True" 
                        font-names="Arial" width="851px" Height="17px">User Accounts</asp:Label></td>
            </tr>
                               
            </table>
            <table>
                    <tr>
                            <td colspan ="1">
                                <asp:Label ID="Label9" runat="server" Text="Company Name"></asp:Label>
                            </td>
                        <td colspan ="1">
                            <asp:DropDownList ID="cmbCompany" runat="server" AutoPostBack="True" Width="200px">
                            </asp:DropDownList>
                            </td>
                        <td colspan ="1">&nbsp;</td>
                        <td colspan ="1"></td>
                        <td colspan ="1">
                            <asp:Label ID="Label8" runat="server" Text="Company Code"></asp:Label>
                            </td>
                        <td colspan ="1">
                            <asp:TextBox ID="txtCompanyCode" runat="server" Enabled="False" Width="200px"></asp:TextBox>
                            </td>

                    </tr>
                <tr>
                        <td colspan ="1">
                            <asp:Label ID="Label10" runat="server" Text="Company Type"></asp:Label>
                        </td>
                    <td colspan ="1">
                        <asp:Label ID="lblCompanyType" runat="server"></asp:Label>
                        </td>
                    <td colspan ="1"></td>
                    <td colspan ="1"></td>
                    <td colspan ="1">&nbsp;</td>
                    <td colspan ="1">
                        <asp:Label ID="lblUsername" runat="server"></asp:Label>
                        </td>

                </tr>
                <tr>
                        <td colspan ="1">
                            <asp:Label ID="Label11" runat="server" Text="User name"></asp:Label>
                        </td>
                    <td colspan ="1">
                        <asp:TextBox ID="txtUsername" runat="server" Width="200px"></asp:TextBox>
                        </td>
                    <td colspan ="1"></td>
                    <td colspan ="1"></td>
                    <td colspan ="1">
                        <asp:Label ID="Label12" runat="server" Text="User Type"></asp:Label>
                        </td>
                    <td colspan ="1">
                        <asp:DropDownList ID="cmbusertype" runat="server" AutoPostBack="True" Width="200px">
                            <asp:ListItem> </asp:ListItem>
                            <asp:ListItem>ADMIN</asp:ListItem>
                            <asp:ListItem>USER</asp:ListItem>
                        </asp:DropDownList>
                        </td>

                </tr>
                <tr>
                        <td colspan ="1">
                            <asp:Label ID="Label13" runat="server" Text="Forenames"></asp:Label>
                        </td>
                    <td colspan ="1">
                        <asp:TextBox ID="txtForenames" runat="server" Width="200px"></asp:TextBox>
                        </td>
                    <td colspan ="1"></td>
                    <td colspan ="1"></td>
                    <td colspan ="1">
                        <asp:Label ID="Label15" runat="server" Text="Surname"></asp:Label>
                        </td>
                    <td colspan ="1">
                        <asp:TextBox ID="txtSurname" runat="server" Width="200px"></asp:TextBox>
                        </td>

                </tr>
                <tr>
                        <td colspan ="1">
                            <asp:Label ID="Label17" runat="server" Text="Email"></asp:Label>
                        </td>
                    <td colspan ="1">
                        <asp:TextBox ID="txtEmail" runat="server" Width="200px"></asp:TextBox>
                        </td>
                    <td colspan ="1"></td>
                    <td colspan ="1"></td>
                    <td colspan ="1">
                        <asp:Label ID="Label18" runat="server" Text="Mobile"></asp:Label>
                        </td>
                    <td colspan ="1">
                        <asp:TextBox ID="txtMobile" runat="server" Width="200px"></asp:TextBox>
                        </td>

                </tr>
                <tr>
                        <td colspan ="1">
                            <asp:Label ID="Label19" runat="server" Text="Department"></asp:Label>
                        </td>
                    <td colspan ="1">
                        <asp:DropDownList ID="cmbDepartment" runat="server" AutoPostBack="True" Width="200px">
                            <asp:ListItem> </asp:ListItem>
                            <asp:ListItem>ADMIN</asp:ListItem>
                            <asp:ListItem>ACCOUNTS</asp:ListItem>
                            <asp:ListItem>BACK OFFICE</asp:ListItem>
                            <asp:ListItem>CALL CENTER</asp:ListItem>
                            <asp:ListItem>OPERATIONS</asp:ListItem>
                            <asp:ListItem>IT</asp:ListItem>
                        </asp:DropDownList>
                        </td>
                    <td colspan ="1"></td>
                    <td colspan ="1"></td>
                    <td colspan ="1"></td>
                    <td colspan ="1">
                        <asp:Label ID="lblCode" runat="server" Visible="False"></asp:Label>
                        </td>

                </tr>
                <tr>
                        <td colspan ="1">
                            <asp:Label ID="Label20" runat="server" Text="Account Status"></asp:Label>
                        </td>
                    <td colspan ="1">
                        <asp:RadioButton ID="rdActive" runat="server" AutoPostBack="True" GroupName="AccountStatus" Text="Active" />
                        <asp:RadioButton ID="rdInActive" runat="server" AutoPostBack="True" GroupName="AccountStatus" Text="In-Active" />
                        </td>
                    <td colspan ="1"></td>
                    <td colspan ="1"></td>
                    <td colspan ="1"></td>
                    <td colspan ="1">
                        <asp:CheckBox ID="chkPasswordReset" runat="server" Text="Reset Password" />
                        </td>

                </tr>
                <tr>
                        <td colspan ="6" style="text-align:center;">
                            <asp:Button ID="Button1" runat="server" Text="Save" />
                            <asp:Button ID="Button2" runat="server" Text="New" />
                        </td>

                </tr>
                <tr>
                    <td colspan="1"></td>
                    <td colspan="1"></td>
                    <td colspan="1"></td>
                    <td colspan="1"></td>

                    <td colspan="1"></td>
                    <td colspan="1"></td>
                    

                </tr>
                <tr>
                        <td colspan ="1">
                            <asp:Label ID="Label14" runat="server" Text="Username Search"></asp:Label>
                        </td>
                    <td colspan ="4">
                        <asp:TextBox ID="txtNameSearch" runat="server" Width="300px"></asp:TextBox>
                        </td>
                    <td colspan ="1">
                        <asp:Button ID="btnNameSearch" runat="server" Text="&gt;&gt;" />
                        </td>

                </tr>
                <tr>
                        <td colspan ="1">
                            <asp:Label ID="Label1" runat="server" Text="Full names Search"></asp:Label>
                        </td>
                    <td colspan ="4">
                        <asp:TextBox ID="txtcodeSearch" runat="server" Width="300px"></asp:TextBox>
                        </td>
                    <td colspan ="1">
                        <asp:Button ID="btnCodeSearch" runat="server" Text="&gt;&gt;" />
                        </td>

                </tr>
                <tr>
                        <td colspan ="1"></td>
                    <td colspan ="4">
                        <asp:ListBox ID="lstNameSearch" runat="server" AutoPostBack="True" Width="323px"></asp:ListBox>
                        </td>
                    <td colspan ="1"></td>

                </tr>

            </table>
       
            <table>
                <tr>
                    <td></td>
                </tr>
            </table>
            <table>
                <tr>
                    <td colspan ="4" style="width: 850px" align="center">
                        <dx: CreateDatabaseControl>

                            </dx:>
                        </td>                
                </tr>
            </table>
        </td>
    </tr>
</table>
</asp:Panel>
</div>
</asp:Content>

