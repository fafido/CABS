<%@ Page Language="VB" MasterPageFile="~/CDSMain.master" AutoEventWireup="false" CodeFile="CompanyAccountsCreation.aspx.vb" Inherits="CompanyAccountsCreation" %>

<asp:Content id="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<asp:Panel id="Panel1" runat="server">
    
<table style="border-right: #000033 thin solid; border-top: #000033 thin solid; border-left: #000033 thin solid; width: 832px; border-bottom: #000033 thin solid; background-color: #ffffff">
    <tr>
        <td style="width: 712px; height: 226px" valign="top">
            <table>
            <tr>
                <td style="width: 870px" align="center">
                    <asp:Label id="Label4" runat="server" backcolor="#8080FF" font-bold="True" font-names="Arial"
                        text="System Company Accounts" width="848px"></asp:Label></td>
            </tr>
            <tr>
                <td align="center">
                    <asp:RadioButton id="rdNewAcc" runat="server" autopostback="True" 
                        GroupName="ActionPerfom" Text="New Accounts" />
                    <asp:RadioButton id="rdNewAcc0" runat="server" autopostback="True" 
                        GroupName="ActionPerfom" Text="Update Accounts" />
                </td>
            </tr>
                <tr>
                    <td valign="top">
                    
                        <table>
                        <tr>
                                <td colspan ="2"></td>
                                <td colspan ="2">
                                    </td>
                                <td colspan = "1">
                                    
                                </td>
                                <td colspan = "1"></td>
                                <td colspan ="2">
                                    
                                </td>
                                <td colspan ="2">
                                    
                                    <asp:DropDownList id="cmbCompanies" runat="server" autopostback="True" 
                                        width="167px">
                                    </asp:DropDownList>
                                    
                                </td>
                            </tr>
                            <tr>
                                <td colspan ="2"><asp:Label runat="server" text="Company"></asp:Label></td>
                                <td colspan ="2">
                                    <asp:TextBox runat="server" id="txtCompany" autopostback="True" 
                                        width="170px"></asp:TextBox></td>
                                <td colspan = "1">
                                    <asp:Label id="lblPasswordValidation" runat="server"></asp:Label>
                                </td>
                                <td colspan = "1"></td>
                                <td colspan ="2">
                                    <asp:Label runat="server" text="Company Type" id="lblCompanyType"></asp:Label>
                                </td>
                                <td colspan ="2">
                                    <asp:DropDownList id="cmbCompanyType" runat="server" autopostback="True" 
                                        width="167px">
                                        <asp:ListItem>CDS</asp:ListItem>
                                        <asp:ListItem>Custodian</asp:ListItem>
                                        <asp:ListItem>Brokerage</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td colspan ="2">
                                    <asp:Label runat="server" text="Company Code"></asp:Label>
                                </td>
                                <td colspan ="2">
                                    <asp:TextBox id="txtCompanyCode" runat="server" width="168px" 
                                        autopostback="True"></asp:TextBox>
                                </td>
                                <td colspan = "1">
                                    &nbsp;</td>
                                <td colspan = "1"></td>
                                <td colspan ="2">&nbsp;</td>
                                <td colspan ="2">
                                    <asp:Label id="lblCompanyCode" runat="server"></asp:Label>
                                </td>
                            </tr>
                            
                            <tr>
                                <td colspan ="10" align="center"><asp:Label runat="server"></asp:Label>
                                    <asp:RadioButton id="rdActive" runat="server" autopostback="True" 
                                        GroupName="Adminlevel" Text="Active" />
                                    <asp:RadioButton id="rdInactive" runat="server" autopostback="True" 
                                        GroupName="Adminlevel" Text="Inactive" />
                                </td>
                            </tr>
                            
                                <tr>
                                <td colspan ="10" align="center">
                                    <asp:Button runat="server" Text="Save" 
                                        onclick="Unnamed17_Click" id="btnSave"></asp:Button></td>
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

