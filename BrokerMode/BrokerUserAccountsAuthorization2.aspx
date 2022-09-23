<%@ Page Language="VB" MasterPageFile="~/CDSUser.master" AutoEventWireup="false" CodeFile="BrokerUserAccountsAuthorization.aspx.vb" Inherits="BrokerUserAccountsAuthorization" %>

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
                                <td colspan ="2"><asp:Label runat="server" text="User name"></asp:Label></td>
                                <td colspan ="2"><asp:TextBox runat="server" id="txtUsernameSearch"></asp:TextBox></td>
                                <td colspan = "1"><asp:Button runat="server" Text=">>" onclick="Unnamed2_Click"></asp:Button></td>
                                <td colspan = "1"></td>
                                <td colspan ="2"></td>
                                <td colspan ="2">
                                    <asp:DropDownList id="cmbusers" runat="server" autopostback="True" 
                                        width="130px">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td colspan ="2"><asp:Label runat="server" text="User name"></asp:Label></td>
                                <td colspan ="2"><asp:TextBox runat="server" id="txtUsername"></asp:TextBox></td>
                                <td colspan = "1"></td>
                                <td colspan = "1"></td>
                                <td colspan ="2"></td>
                                <td colspan ="2"></td>
                            </tr>
                            <tr>
                                <td colspan ="2"><asp:Label runat="server" text="Forenames"></asp:Label></td>
                                <td colspan ="2"><asp:TextBox runat="server" id="txtForenames" width="130px"></asp:TextBox></td>
                                <td colspan = "1"></td>
                                <td colspan = "1"></td>
                                <td colspan ="2"><asp:Label runat="server" text="Surname"></asp:Label></td>
                                <td colspan ="2"><asp:TextBox runat="server" id="txtSurname" width="130px"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td colspan ="2"><asp:Label runat="server" text="Organization"></asp:Label></td>
                                <td colspan ="2">
                                    <asp:TextBox id="txtOrganization" runat="server"></asp:TextBox>
                                </td>
                                <td colspan = "1"></td>
                                <td colspan = "1"></td>
                                <td colspan ="2"><asp:Label runat="server" text="Department"></asp:Label></td>
                                <td colspan ="2">
                                    <asp:TextBox id="txtDepartment" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td colspan ="2"><asp:Label runat="server" text="User role"></asp:Label></td>
                                <td colspan ="2">
                                    <asp:TextBox id="txtRole" runat="server"></asp:TextBox>
                                </td>
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
                               <td colspan ="2"><asp:CheckBox runat="server" id="chkAccountsCre" 
                                        text="Accounts Creations"></asp:CheckBox></td>
                                    <td colspan ="2"><asp:CheckBox runat="server" id="chkNewAccountsAuth" 
                                        text="Accounts Authorizations"></asp:CheckBox></td>
                                    <td colspan ="2"><asp:CheckBox runat="server" id="chkAccountsUpdate" 
                                        text="Accounts Updates"></asp:CheckBox></td>
                                    <td colspan ="2"><asp:CheckBox runat="server" id="chkAccountsUpdatesAuth" 
                                        text="Updates Authorizations"></asp:CheckBox></td>
                                    <td colspan ="2"><asp:CheckBox runat="server" id="chkBatchCreations" 
                                        text="Batch Creations"></asp:CheckBox></td>
                            </tr>
                            <tr>
                                <td colspan ="2"><asp:CheckBox runat="server" id="chkBatchesAuthorizations" 
                                        text="Batch Authorizations"></asp:CheckBox></td>
                                    <td colspan ="2"><asp:CheckBox runat="server" id="chkEnquiries" 
                                        text="Account Details Enquiries"></asp:CheckBox></td>
                                    <td colspan ="2"><asp:CheckBox runat="server" id="ChkPledgeCreUp" 
                                        text="Pledges Management"></asp:CheckBox></td>
                                    <td colspan ="2"><asp:CheckBox runat="server" id="ChkPledgeAuth" 
                                        text="Pledges Authorizations"></asp:CheckBox></td>
                                    <td colspan ="2"><asp:CheckBox runat="server" id="chkAccountsLockUn" 
                                        text="Accounts Locking/Unlocking"></asp:CheckBox></td>
                                </tr>
                                <tr>
                                <td colspan ="2"><asp:CheckBox runat="server" id="chkPortfolioEnq" 
                                        text="Portfolio Enquiries"></asp:CheckBox></td>
                                    <td colspan ="2"><asp:CheckBox runat="server" id="chkCorporateEnquiries" 
                                        text="Corporate Actions Enquiries"></asp:CheckBox></td>
                                    <td colspan ="2"><asp:CheckBox runat="server" id="ChkTransactionsCre" 
                                        text="Transactions Creations"></asp:CheckBox></td>
                                    <td colspan ="2"><asp:CheckBox runat="server" id="chkTransactionsAuth" 
                                        text="Transactions Authorizations"></asp:CheckBox></td>
                                    <td colspan ="2"><asp:CheckBox runat="server" id="chkOrdersPosting" 
                                        text="Orders Posting"></asp:CheckBox></td>
                                </tr>
                                <tr>
                                <td colspan ="2"><asp:CheckBox runat="server" id="ChkOrdersUpdates" 
                                        text="Orders Updates"></asp:CheckBox></td>
                                    <td colspan ="2"><asp:CheckBox runat="server" id="chkOrdersAuth" 
                                        text="Orders Authorizations"></asp:CheckBox></td>
                                    <td colspan ="2"><asp:CheckBox runat="server" id="chkFilesExport" 
                                        text="Files Export"></asp:CheckBox></td>
                                    <td colspan ="2"><asp:CheckBox runat="server" id="ChkFilesImport" 
                                        text="Orders Imports"></asp:CheckBox></td>
                                    <td colspan ="2"><asp:CheckBox runat="server" id="chkReports" 
                                        text="Reports Printing"></asp:CheckBox></td>
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
                                <td colspan ="10" align="center"><asp:Button runat="server" 
                                        Text="Authorize Account" onclick="Unnamed16_Click"></asp:Button>
                                    <asp:Button id="Button1" runat="server" Text="Reject Account" />
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

