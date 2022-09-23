<%@ Page Language="VB" MasterPageFile="~/CDSMain.master" AutoEventWireup="false" CodeFile="UserAccountsPermissionsManage.aspx.vb" Inherits="UserAccountsPermissionsManage" %>

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
                                <asp:DropDownList id="cmbUsers" runat="server" autopostback="True" 
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
                                <td colspan ="2">
                                    <asp:TextBox id="txtCompany" runat="server"></asp:TextBox>
                                </td>
                                <td colspan = "1">
                                    <asp:Label id="lblCompanytype" runat="server" Visible="False"></asp:Label>
                                </td>
                                <td colspan = "1"></td>
                                <td colspan ="2"><asp:Label runat="server" text="Department"></asp:Label></td>
                                <td colspan ="2">
                                    <asp:TextBox id="txtDepartment" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td colspan ="2"><asp:Label runat="server" text="User role"></asp:Label></td>
                                <td colspan ="2">
                                    <asp:TextBox id="txtUserRole" runat="server"></asp:TextBox>
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
                                <td colspan ="2">
                                    <asp:Label ID="Label6" runat="server" style="font-weight: 700" 
                                        Text="Transactions Creations"></asp:Label>
                                    -</td>
                                <td colspan ="2"></td>
                                <td colspan ="2"></td>
                                <td colspan ="2"></td>
                                <td colspan ="2"></td>
                            </tr>
                            <tr>
                                <td colspan ="2"></td>
                                <td colspan ="2"></td>
                                <td colspan ="2"></td>
                                <td colspan ="2"></td>
                                <td colspan ="2"></td>
                            </tr>
                            <tr>
                                <td colspan ="2">
                                    <asp:CheckBox ID="chkAccountsCre" runat="server" text="Accounts Creations" />
                                </td>
                                <td colspan ="2">
                                
                                    <asp:CheckBox ID="chkAccountsUpdate" runat="server" text="Accounts Updates" />
                                
                                </td>
                                <td colspan="2">
                                
                                    <asp:CheckBox ID="chkBatchCreations" runat="server" text="Batch Creations" />
                                
                                </td>
                                <td colspan="2">
                                
                                    <asp:CheckBox ID="chkAccountsLockUn" runat="server" 
                                        text="Accounts Locking/Unlocking" />
                                
                                </td>
                                <td colspan="2">
                                
                                    <asp:CheckBox ID="ChkFilesImport" runat="server" text="Files Imports" />
                                
                                </td>
                            </tr>
                            <tr>
                                <td colspan ="2">
                                    <asp:CheckBox ID="chkFilesExport" runat="server" text="Files Export" />
                                </td>  
                                <td colspan ="2">
                                    <asp:CheckBox ID="chkLandingBorrowing" runat="server" 
                                        text="Landing &amp; Borrowing" />
                                </td>  
                                <td colspan ="2">
                                    <asp:CheckBox ID="chkEnquiriesDetails" runat="server" 
                                        text="Account Details Enquiries" />
                                </td>  
                                <td colspan ="2">
                                    <asp:CheckBox ID="chkPortfolioEnq" runat="server" text="Portfolio Enquiries" />
                                </td>  
                                <td colspan ="2">
                                    <asp:CheckBox ID="ChkPledgeCreUp" runat="server" text="Pledges Management" />
                                </td>  
                            </tr>
                 <tr>
                    <td colspan ="2">
                        <asp:CheckBox ID="chkOrdersPosting" runat="server" text="Orders Maintenance" />
                     </td>
                    <td colspan ="2">
                        <asp:CheckBox ID="ChkMandates" runat="server" text="Account Mandates" />
                     </td>
                    <td colspan ="2">
                        <asp:CheckBox ID="chkParaset" runat="server" text="Parameters Creation" />
                     </td>
                    <td colspan ="2">
                        <asp:CheckBox ID="chkSystemAccounts" runat="server" 
                            text="System User Accounts" />
                     </td>
                    <td colspan ="2">
                        <asp:CheckBox ID="chkSystemAccPerm" runat="server" 
                            text="System User Permissions" />
                     </td>
                 </tr>
                 <tr>
                    <td colspan ="2">
                        <asp:Label ID="Label7" runat="server" style="font-weight: 700" 
                            Text="Transactions Authorizations"></asp:Label>
                     </td>
                    <td colspan ="2"></td>
                    <td colspan ="2"></td>
                    <td colspan ="2"></td>
                    <td colspan ="2"></td>
                 </tr>
                 <tr>
                                <td colspan ="2"></td>
                                <td colspan ="2"></td>
                                <td colspan ="2"></td>
                                <td colspan ="2"></td>
                                <td colspan ="2"></td>
                            </tr>
                 <tr>
                    <td colspan ="2">
                        <asp:CheckBox ID="chkNewAccountsAuth" runat="server" 
                            text="Accounts Authorizations" />
                     </td>
                    <td colspan ="2">
                        <asp:CheckBox ID="chkAccountsUpdatesAuth" runat="server" 
                            text="Accounts Update " />
                     </td>
                    <td colspan ="2">
                        <asp:CheckBox ID="chkAccountsLockAuth" runat="server" 
                            text="Accounts Locking" />
                     </td>
                    <td colspan ="2">
                        <asp:CheckBox ID="chkBatchesAuthorizations" runat="server" 
                            text="Transaction Batches" />
                     </td>
                    <td colspan ="2">
                        <asp:CheckBox ID="chkLandingBorowAuth" runat="server" 
                            text="Landing &amp; Borrowing" />
                     </td>
                 </tr>
                            <tr>
                               <td colspan ="2">
                                   <asp:CheckBox runat="server" id="ChkPledgeAuth" 
                                        text="Pledges"></asp:CheckBox>
                                </td>
                                    <td colspan ="2">
                                        <asp:CheckBox ID="chkOrdersAuth" runat="server" text="Orders Authorizations" />
                                </td>
                                    <td colspan ="2">
                                        <asp:CheckBox ID="chkAccsMandateAuth" runat="server" text="Account Mandates" />
                                </td>
                                    <td colspan ="2">
                                        <asp:CheckBox ID="chkSystemParaAuth" runat="server" 
                                            text="System Parameters" />
                                </td>
                                    <td colspan ="2">
                                        <asp:CheckBox ID="chkSystemAccCreAuth" runat="server" 
                                            text="User Accounts Creation" />
                                </td>
                            </tr>
                            <tr>
                                <td colspan ="2" style="height: 19px">
                                    <asp:CheckBox ID="chkAccsPermAuth" runat="server" 
                                        text="User Account Permissions" />
                                </td>
                                    <td colspan ="2" style="height: 19px"></td>
                                    <td colspan ="2" style="height: 19px">
                                        </td>
                                    <td colspan ="2" style="height: 19px"></td>
                                    <td colspan ="2" style="height: 19px">
                                        </td>
                                </tr>
                                <tr>
                                <td colspan ="2">
                                    <asp:Label ID="Label8" runat="server" style="font-weight: 700" Text="Utilities"></asp:Label>
                                    </td>
                                    <td colspan ="2">
                                        &nbsp;</td>
                                    <td colspan ="2">
                                        &nbsp;</td>
                                    <td colspan ="2">
                                        &nbsp;</td>
                                    <td colspan ="2">
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                <td colspan ="2"></td>
                                <td colspan ="2"></td>
                                <td colspan ="2">&nbsp;</td>
                                <td colspan ="2">&nbsp;</td>
                                <td colspan ="2"></td>
                            </tr>
                                <tr>
                                <td colspan ="2">
                                    <asp:CheckBox ID="chkReports" runat="server" text="Reports Printing" />
                                    </td>
                                    <td colspan ="2">
                                        <asp:CheckBox ID="chkEventsCalender" runat="server" text="Events Diary" />
                                    </td>
                                    <td colspan ="2">
                                        &nbsp;</td>
                                    <td colspan ="2">
                                        &nbsp;</td>
                                    <td colspan ="2">
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                <td colspan ="10"><asp:Label runat="server" Text=""></asp:Label></td>
                            </tr>
                            <tr>
                                <td colspan ="2">
                                    &nbsp;</td>
                                    <td colspan ="2">
                                        &nbsp;</td>
                                    <td colspan ="2">&nbsp;</td>
                                    <td colspan ="2">&nbsp;</td>
                                    <td colspan ="2"></td>
                                </tr>
                                <tr>
                                <td colspan ="10" align="center">
                                    <asp:Button ID="btnConserve" runat="server" Text="Save" />
                                    
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

