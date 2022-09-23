<%@ Page Language="VB" MasterPageFile="~/CDSUser.master" AutoEventWireup="false" CodeFile="ClientCompanies.aspx.vb" Inherits="CDSMode_ClientCompanies" title="TSec Home" %>
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
                        font-names="Arial" width="851px" Height="17px">Client Companies Set up</asp:Label></td>
            </tr>
                               
            </table>
            <table>
                    <tr>
                            <td colspan ="1">
                                <asp:Label ID="Label8" runat="server" Text="Company Code"></asp:Label>
                            </td>
                        <td colspan ="1">
                            <asp:TextBox ID="txtCompanyCode" runat="server" Width="200px"></asp:TextBox>
                            </td>
                        <td colspan ="1">&nbsp;</td>
                        <td colspan ="1"></td>
                        <td colspan ="1">
                            <asp:Label ID="Label9" runat="server" Text="Company Name"></asp:Label>
                            </td>
                        <td colspan ="1">
                            <asp:TextBox ID="txtCompanyName" runat="server" Width="200px"></asp:TextBox>
                            </td>

                    </tr>
                <tr>
                        <td colspan ="1">
                            <asp:Label ID="Label10" runat="server" Text="Company Type"></asp:Label>
                        </td>
                    <td colspan ="1">
                        <asp:DropDownList ID="cmbCompanyTypes" runat="server" AutoPostBack="True" Width="200px">
                        </asp:DropDownList>
                        </td>
                    <td colspan ="1"></td>
                    <td colspan ="1"></td>
                    <td colspan ="1"></td>
                    <td colspan ="1"></td>

                </tr>
                <tr>
                        <td colspan ="1">
                            <asp:Label ID="Label11" runat="server" Text="Company Address"></asp:Label>
                        </td>
                    <td colspan ="1">
                        <asp:TextBox ID="txtCompanyAddress" runat="server" Height="78px" TextMode="MultiLine" Width="200px"></asp:TextBox>
                        </td>
                    <td colspan ="1"></td>
                    <td colspan ="1"></td>
                    <td colspan ="1">
                        <asp:Label ID="Label12" runat="server" Text="Email"></asp:Label>
                        </td>
                    <td colspan ="1">
                        <asp:TextBox ID="txtCompanyEmail" runat="server" Width="200px"></asp:TextBox>
                        </td>

                </tr>
                <tr>
                        <td colspan ="1">
                            <asp:Label ID="Label13" runat="server" Text="Telephone"></asp:Label>
                        </td>
                    <td colspan ="1">
                        <asp:TextBox ID="txtTel" runat="server" Width="200px"></asp:TextBox>
                        </td>
                    <td colspan ="1"></td>
                    <td colspan ="1"></td>
                    <td colspan ="1">
                        <asp:Label ID="Label15" runat="server" Text="Mobile"></asp:Label>
                        </td>
                    <td colspan ="1">
                        <asp:TextBox ID="txtmobile" runat="server" Width="200px"></asp:TextBox>
                        </td>

                </tr>
                <tr>
                        <td colspan ="1"></td>
                    <td colspan ="1"></td>
                    <td colspan ="1"></td>
                    <td colspan ="1"></td>
                    <td colspan ="1"></td>
                    <td colspan ="1"></td>

                </tr>
                <tr>
                        <td colspan ="1"></td>
                    <td colspan ="1"></td>
                    <td colspan ="1"></td>
                    <td colspan ="1"></td>
                    <td colspan ="1"></td>
                    <td colspan ="1"></td>

                </tr>
                <tr>
                        <td colspan ="1"></td>
                    <td colspan ="1"></td>
                    <td colspan ="1"></td>
                    <td colspan ="1"></td>
                    <td colspan ="1"></td>
                    <td colspan ="1">
                        <asp:Label ID="lblCode" runat="server" Visible="False"></asp:Label>
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
                            <asp:Label ID="Label14" runat="server" Text="Company Name Search"></asp:Label>
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
                            <asp:Label ID="Label1" runat="server" Text="Company Code Search"></asp:Label>
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

