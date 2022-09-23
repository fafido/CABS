<%@ Page Language="VB" MasterPageFile="~/CDSMain.master" AutoEventWireup="false" CodeFile="CDSUserAccounts.aspx.vb" Inherits="CDSUserAccounts" %>

<asp:Content id="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<asp:Panel id="Panel1" runat="server">
    
<table style="border-right: #000033 thin solid; border-top: #000033 thin solid; border-left: #000033 thin solid; width: 832px; border-bottom: #000033 thin solid; background-color: #ffffff">
    <tr>
        <td style="width: 712px; height: 226px" valign="top">
            <table>
            <tr>
                <td style="width: 870px" align="center">
                    <asp:Label id="Label4" runat="server" backcolor="#8080FF" font-bold="True" font-names="Arial"
                        text="User Accounts Permissions Management" width="848px"></asp:Label></td>
            </tr>
                <tr>
                    <td valign="top">
                    
                        <table>
                        <tr>
                            <td colspan ="2">
                                <asp:Label id="Label5" runat="server" text="User name"></asp:Label>
                            </td>
                            <td colspan ="2">
                                <asp:DropDownList id="DropDownList1" runat="server" autopostback="True" 
                                    width="130px">
                                </asp:DropDownList>
                            </td>
                            <td colspan ="2"></td>
                            <td colspan ="2"></td>
                        </tr>
                            <tr>
                                <td colspan ="2"><asp:Label runat="server" text="User name"></asp:Label></td>
                                <td colspan ="2"><asp:TextBox runat="server" id="txtUsername" autopostback="True"></asp:TextBox></td>
                                <td colspan = "1">
                                    <asp:Label id="lblPasswordValidation" runat="server"></asp:Label>
                                </td>
                                <td colspan = "1"></td>
                                <td colspan ="2">
                                    <asp:CheckBox id="chkRejectedAccounts" runat="server" autopostback="True" 
                                        Text="Rejected Accounts" />
                                </td>
                                <td colspan ="2">
                                    <asp:DropDownList id="cmbRejections" runat="server" autopostback="True" 
                                        Enabled="False" width="134px">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td colspan ="2"><asp:Label runat="server" text="Forenames"></asp:Label></td>
                                <td colspan ="2"><asp:TextBox runat="server" id="txtForenames" width="130px"></asp:TextBox></td>
                                <td colspan = "1">
                                    <asp:Label id="lblCompanyCode" runat="server" visible="False"></asp:Label>
                                </td>
                                <td colspan = "1"></td>
                                <td colspan ="2"><asp:Label runat="server" text="Surname"></asp:Label></td>
                                <td colspan ="2"><asp:TextBox runat="server" id="txtSurname" width="130px"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td colspan ="2"><asp:Label runat="server" text="Organization"></asp:Label></td>
                                <td colspan ="2"><asp:DropDownList runat="server" autopostback="True" width="130px" 
                                        id="cmbCompany"></asp:DropDownList></td>
                                <td colspan = "1">
                                    <asp:Label id="lblCompanytype" runat="server" Visible="False"></asp:Label>
                                </td>
                                <td colspan = "1"></td>
                                <td colspan ="2"><asp:Label runat="server" text="Department"></asp:Label></td>
                                <td colspan ="2"><asp:DropDownList runat="server" autopostback="True" width="130px" 
                                        id="cmbDepartment"></asp:DropDownList></td>
                            </tr>
                            <tr>
                                <td colspan ="2"><asp:Label runat="server" text="User role"></asp:Label></td>
                                <td colspan ="2"><asp:DropDownList runat="server" autopostback="True" width="130px" 
                                        id="cmbRoles"></asp:DropDownList></td>
                                <td colspan = "1"></td>
                                <td colspan = "1"></td>
                                <td colspan ="2"></td>
                                <td colspan ="2"></td>
                            </tr>
                            <tr>
                                <td colspan ="2"><asp:Label runat="server" text="Email" width="130px"></asp:Label></td>
                                <td colspan ="2"><asp:TextBox runat="server" width="130px" id="txtEmail"></asp:TextBox></td>
                                <td colspan = "1"></td>
                                <td colspan = "1"></td>
                                <td colspan ="2"><asp:Label runat="server" Text="Telephone - Ext"></asp:Label></td>
                                <td colspan ="2"><asp:TextBox width="130px" runat="server" id="txtTelephone"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td colspan ="2"><asp:Label runat="server" text="Mobile 1" width="130px"></asp:Label></td>
                                <td colspan ="2"><asp:TextBox runat="server" width="130px" id="txtMobile1"></asp:TextBox></td>
                                <td colspan = "1"></td>
                                <td colspan = "1"></td>
                                <td colspan ="2"><asp:Label runat="server" Text="Mobile 2"></asp:Label></td>
                                <td colspan ="2"><asp:TextBox width="130px" runat="server" id="txtMobile2"></asp:TextBox></td>
                            </tr>
                            
                            <tr>
                                <td colspan ="10"><asp:Label runat="server"></asp:Label></td>
                            </tr>
                 
                            <tr>
                               <td colspan ="2">
                                   <asp:CheckBox runat="server" id="chkAccountsCre" 
                                        text="Accounts Creations" Visible="False"></asp:CheckBox>
                                   <asp:CheckBox id="chkBatchesAuthorizations" runat="server" 
                                       text="Batch Authorizations" />
                                </td>
                                    <td colspan ="2"><asp:CheckBox runat="server" id="chkNewAccountsAuth" 
                                        text="Accounts Authorizations"></asp:CheckBox></td>
                                    <td colspan ="2">
                                        <asp:CheckBox runat="server" id="chkAccountsUpdate" 
                                        text="Accounts Updates" Visible="False"></asp:CheckBox>
                                        <asp:CheckBox id="ChkPledgeCreUp" runat="server" text="Pledges Management" />
                                </td>
                                    <td colspan ="2"><asp:CheckBox runat="server" id="chkAccountsUpdatesAuth" 
                                        text="Updates Authorizations"></asp:CheckBox></td>
                                    <td colspan ="2">
                                        <asp:CheckBox runat="server" id="chkBatchCreations" 
                                        text="Batch Creations" Visible="False"></asp:CheckBox>
                                        <asp:CheckBox id="chkAccountsLockUn" runat="server" 
                                            text="Accounts Locking/Unlocking" />
                                </td>
                            </tr>
                            <tr>
                                <td colspan ="2" style="height: 38px">
                                    <asp:CheckBox id="chkPortfolioEnq" runat="server" text="Portfolio Enquiries" />
                                </td>
                                    <td colspan ="2" style="height: 38px"><asp:CheckBox runat="server" id="chkEnquiries" 
                                        text="Account Details Enquiries"></asp:CheckBox></td>
                                    <td colspan ="2" style="height: 38px">
                                        <asp:CheckBox id="ChkTransactionsCre" runat="server" 
                                            text="Transactions Creations" />
                                </td>
                                    <td colspan ="2" style="height: 38px"><asp:CheckBox runat="server" id="ChkPledgeAuth" 
                                        text="Pledges Authorizations"></asp:CheckBox></td>
                                    <td colspan ="2" style="height: 38px">
                                        <asp:CheckBox id="chkCorporateEnquiries" runat="server" 
                                            text="Corporate Actions Enquiries" />
                                </td>
                                </tr>
                                <tr>
                                <td colspan ="2">
                                    <asp:CheckBox id="chkTransactionsAuth" runat="server" 
                                        text="Transactions Authorizations" />
                                    </td>
                                    <td colspan ="2">
                                        <asp:CheckBox id="chkReports" runat="server" text="Reports Printing" />
                                    </td>
                                    <td colspan ="2">
                                        <asp:CheckBox id="chkFilesExport" runat="server" text="Files Export" />
                                    </td>
                                    <td colspan ="2">
                                        <asp:CheckBox id="ChkFilesImport" runat="server" text="Files Imports" />
                                    </td>
                                    <td colspan ="2">
                                        <asp:CheckBox runat="server" id="chkOrdersPosting" 
                                        text="Orders Posting" Visible="False"></asp:CheckBox></td>
                                </tr>
                                <tr>
                                <td colspan ="2">
                                    <asp:CheckBox runat="server" id="ChkOrdersUpdates" 
                                        text="Orders Updates" Visible="False"></asp:CheckBox></td>
                                    <td colspan ="2">
                                        <asp:CheckBox runat="server" id="chkOrdersAuth" 
                                        text="Orders Authorizations" Visible="False"></asp:CheckBox></td>
                                    <td colspan ="2">&nbsp;</td>
                                    <td colspan ="2">
                                        &nbsp;</td>
                                    <td colspan ="2">&nbsp;</td>
                                </tr>
                                
                                <tr>
                                <td colspan ="10"><asp:Label runat="server" Text=""></asp:Label></td>
                            </tr>
                            <tr>
                                <td colspan ="2"><asp:CheckBox runat="server" id="chkSystemAccounts" 
                                        text="Users Creation"></asp:CheckBox></td>
                                    <td colspan ="2"><asp:CheckBox runat="server" id="chkSystemAccAuth" 
                                        text="User Accounts Authorizations"></asp:CheckBox></td>
                                    <td colspan ="2"><asp:CheckBox runat="server" id="chkParaset" 
                                        text="Parameters Setting"></asp:CheckBox></td>
                                    <td colspan ="2"><asp:CheckBox runat="server" id="chkEventsCalender" 
                                        text="Events Diary"></asp:CheckBox></td>
                                    <td colspan ="2"></td>
                                </tr>
                                <tr>
                                <td colspan ="10" align="center"><asp:Button runat="server" Text="Save" 
                                        onclick="Unnamed17_Click"></asp:Button>
                                    <asp:Button id="btnDel" runat="server" Text="Delete" />
                                    </td>
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

