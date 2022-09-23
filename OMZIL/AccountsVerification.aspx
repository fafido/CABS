<%@ Page Language="VB" MasterPageFile="~/CDSUser.master" AutoEventWireup="false" CodeFile="AccountsVerification.aspx.vb" Inherits="TransferSec_AccountsVerification" title="Account Details Enquiry" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<asp:Content id="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
    <asp:Panel id="Panel1" runat="server" Width="840px" Font-Names="Arial" Font-Size="Medium" BackColor="White">
    
        <table width ="810px">
            <tr>
                   <td style ="text-align :left;" align="left">
                       <dx:ASPxLabel ID="ASPxLabel1" runat="server" Text="Authorizations&gt;&gt;Accounts Authorizations" Font-Names="Cambria" Font-Size="Small" Theme="PlasticBlue"></dx:ASPxLabel>

                   </td>
            </tr>
        </table>
        <asp:Panel runat="server" ID="Search" Font-Names="Cambria" GroupingText="Pending Verication Accounts">
            <table>
                    <tr>
                            <td colspan ="1">
                                <dx:ASPxLabel ID="ASPxLabel56" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Select Account" Theme="Glass">
                                </dx:ASPxLabel>
                            </td>
                        <td colspan ="7">
                            <dx:ASPxComboBox ID="cmbPendingAccounts" runat="server" Theme="BlackGlass" ValueType="System.String" Width="710px" AutoPostBack="True">
                            </dx:ASPxComboBox>
                            </td>

                    </tr>

                <tr>
                            <td colspan ="1">
                                <dx:ASPxLabel ID="ASPxLabel57" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Update Type" Theme="Glass">
                                </dx:ASPxLabel>
                            </td>
                        <td colspan ="7">
                            <dx:ASPxLabel ID="lblUpdateType" runat="server">
                            </dx:ASPxLabel>
                            </td>

                    </tr>
                <tr>
                        <td colspan ="1"></td>
                    <td colspan ="7" align="center">
                        <dx:ASPxLabel ID="ASPxLabel59" runat="server" Font-Italic="True" Font-Size="X-Small" ForeColor="Red" Text="*NB Highlighted fields indicate the updated sections on an account amendment" Theme="Office2003Blue">
                        </dx:ASPxLabel>
                        </td>

                </tr>

            </table>
            
        </asp:Panel>
        <asp:Panel runat="server" Font-Names="Cambria" GroupingText="Client Verification Code ">
            <table width ="810px">
                <tr>
                    <td colspan="1">
                        <dx:ASPxLabel ID="lblJSurname0" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Verification Code" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td colspan ="7">
                        <dx:ASPxTextBox ID="txtVerificationCode" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="710px">
                        </dx:ASPxTextBox>
                    </td>

                </tr>
            </table>
        </asp:Panel>
        <asp:panel id="Panel10" runat="server" GroupingText="Account Type" Font-Names="Cambria">
        <table width="810px">
            <tr>
                    <td colspan ="8" align="center">
                        <asp:RadioButton ID="rdIndividual" runat="server" AutoPostBack="True" GroupName="AccountType" Text="Individual" />
                        <asp:RadioButton ID="rdJoint" runat="server" AutoPostBack="True" GroupName="AccountType" Text="Joint" />
                        <asp:RadioButton ID="rdCorprate" runat="server" AutoPostBack="True" GroupName="AccountType" Text="Corporate" />
                        <asp:RadioButton ID="rdBroker" runat="server" AutoPostBack="True" GroupName="AccountType" Text="Broker" />
                    </td>

            </tr>
         
           <tr>
               <td colspan ="1">
                   <dx:ASPxLabel ID="lblJSurname" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Surname" Theme="Glass" Visible="False">
                   </dx:ASPxLabel>
               </td>
               <td colspan ="7">
                   <dx:ASPxTextBox ID="txtJsurname" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="710px" Visible="False">
                   </dx:ASPxTextBox>
               </td>

           </tr>
             <tr>
               <td colspan ="1">
                   <dx:ASPxLabel ID="lblJforenames" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Forenames" Theme="Glass" Visible="False">
                   </dx:ASPxLabel>
                 </td>
               <td colspan ="7">
                   <dx:ASPxTextBox ID="txtJforenames" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="710px" Visible="False">
                   </dx:ASPxTextBox>
               </td>

           </tr>
        
            <tr>
                    <td colspan ="1"></td>
                <td colspan ="7" align="center">
                    <dx:ASPxButton ID="btnJadd" runat="server" Text="Add" Theme="BlackGlass" Visible="False">
                    </dx:ASPxButton>
                    </td>

            </tr>
            <tr>
                    <td colspan ="8" align ="center">
                        <dx:ASPxGridView ID="grdJointAccounts" runat="server" Theme="Aqua" Width="600px" Visible="False">
                        </dx:ASPxGridView>
                    </td>

            </tr>
        </table>

    </asp:panel>
        <asp:panel id="Panel8" runat="server" GroupingText="Personal Details" Font-Names="Cambria">
        <table width="810px">
            <tr>
                <td colspan ="1">
                    <dx:ASPxLabel ID="ASPxLabel25" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Client ID." Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                <td colspan ="1">
                    <dx:ASPxTextBox ID="TXTClientID" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="250px">
                    </dx:ASPxTextBox>
                </td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>
                

            </tr>
           <tr>
               <td colspan ="1">
                   <dx:ASPxLabel ID="ASPxLabel26" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Surname" Theme="Glass">
                   </dx:ASPxLabel>
               </td>
               <td colspan ="7">
                   <dx:ASPxTextBox ID="txtSurname" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="710px">
                   </dx:ASPxTextBox>
               </td>

           </tr>
             <tr>
                <td colspan ="1"></td>
                <td colspan ="7">
                    <dx:ASPxLabel ID="lblSurname" runat="server">
                    </dx:ASPxLabel>
                </td>

            </tr>
             <tr>
                    <td colspan ="1">
                        <dx:ASPxLabel ID="ASPxLabel5" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Firstname" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                <td colspan ="7">
                    <dx:ASPxTextBox ID="txtOtherNames" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="710px">
                    </dx:ASPxTextBox>
                    </td>

            </tr>
            <tr>
                    <td colspan ="1"></td>
                <td colspan ="7">
                    <dx:ASPxLabel ID="lblForenames" runat="server">
                    </dx:ASPxLabel>
                    </td>

            </tr>
            <tr>
                    <td colspan ="1">
                        <dx:ASPxLabel ID="ASPxLabel27" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Other Names" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                <td colspan ="7">
                    <dx:ASPxTextBox ID="txtMiddlename" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="710px">
                    </dx:ASPxTextBox>
                    </td>

            </tr>
                 <tr>
                <td colspan ="1"></td>
                <td colspan ="7">
                    <dx:ASPxLabel ID="lblMiddlename" runat="server">
                    </dx:ASPxLabel>
                 </td>

            </tr>
            <tr>
                    <td colspan ="1">
                        <dx:ASPxLabel ID="ASPxLabel28" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Initials" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                <td colspan ="1">
                    <dx:ASPxTextBox ID="txtInitials" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="250px">
                    </dx:ASPxTextBox>
                    </td>
                <td colspan ="1">
                    <dx:ASPxLabel ID="ASPxLabel29" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Title" Theme="Glass">
                    </dx:ASPxLabel>
                    </td>
                <td colspan ="1">
                    <dx:ASPxTextBox ID="txtTitle" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="250px">
                    </dx:ASPxTextBox>
                    </td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>

            </tr>
              <tr>
                <td colspan ="1"></td>
                <td colspan ="1">
                    <dx:ASPxLabel ID="lblInitials" runat="server">
                    </dx:ASPxLabel>
                </td>
                <td colspan ="1"></td>
                <td colspan ="1">
                    <dx:ASPxLabel ID="lblTitle" runat="server">
                    </dx:ASPxLabel>
                </td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>
            </tr>
            <tr>
                <td colspan ="1">
                    <dx:ASPxLabel ID="ASPxLabel30" runat="server" Font-Names="Cambria" Font-Size="Small" Text="ID No./Pin" Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                <td colspan ="1">
                    <dx:ASPxTextBox ID="txtIDNo" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="250px">
                    </dx:ASPxTextBox>
                </td>
                <td colspan ="1">
                    <dx:ASPxLabel ID="ASPxLabel31" runat="server" Font-Names="Cambria" Font-Size="Small" Text="ID Type" Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                <td colspan ="1">
                    <dx:ASPxTextBox ID="txtIDType" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="250px">
                    </dx:ASPxTextBox>
                </td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>

            </tr>
             <tr>
                <td colspan ="1"></td>
                <td colspan ="1">
                    <dx:ASPxLabel ID="lblIdNo" runat="server">
                    </dx:ASPxLabel>
                </td>
                <td colspan ="1"></td>
                <td colspan ="1">
                    <dx:ASPxLabel ID="lblIdtype" runat="server">
                    </dx:ASPxLabel>
                </td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>
            </tr>
            <tr>
                    <td colspan ="1">
                        <dx:ASPxLabel ID="ASPxLabel44" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Nationality" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                <td colspan ="1">
                    <dx:ASPxTextBox ID="txtNationality" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="250px">
                    </dx:ASPxTextBox>
                    </td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>

            </tr>
            <tr>
                <td colspan ="1"></td>
                <td colspan ="1">
                    <dx:ASPxLabel ID="lblNationality" runat="server">
                    </dx:ASPxLabel>
                </td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>
            </tr>
            <tr>
                <td colspan ="1">
                    <dx:ASPxLabel ID="ASPxLabel32" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Date Of Birth" Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                <td colspan ="1">
                    <dx:ASPxTextBox ID="txtDOB" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="250px">
                    </dx:ASPxTextBox>
                </td>
                <td colspan ="1">
                    <dx:ASPxLabel ID="ASPxLabel33" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Gender" Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                <td colspan ="1">
                    <asp:RadioButton ID="rdMale" runat="server" AutoPostBack="True" GroupName="Gender" Text="Male" />
                    <asp:RadioButton ID="rdFemale" runat="server" AutoPostBack="True" GroupName="Gender" Text="Female" />
                    <asp:RadioButton ID="rdNa" runat="server" AutoPostBack="True" GroupName="Gender" Text="N/A" />
                </td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>

            </tr>
             <tr>
                <td colspan ="1"></td>
                <td colspan ="1">
                    <dx:ASPxLabel ID="lblDob" runat="server">
                    </dx:ASPxLabel>
                </td>
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
                <td colspan ="1"></td>
                <td colspan ="1"></td>
            </tr>
            <tr>
                    <td colspan ="1"></td>
                <td colspan ="7" align="center"></td>

            </tr>

        </table>

    </asp:panel>
        <asp:panel id="Panel3" runat="server" GroupingText="Contact Details" Font-Names="Cambria">
        <table width="810px">
      
           <tr>
               <td colspan ="1">
                   <dx:ASPxLabel ID="ASPxLabel6" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Address" Theme="Glass">
                   </dx:ASPxLabel>
               </td>
               <td colspan ="7">
                   <dx:ASPxTextBox ID="txtAdd1" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="710px">
                   </dx:ASPxTextBox>
               </td>

           </tr>
             <tr>
                    <td colspan ="1"></td>
                <td colspan ="7">
                    <dx:ASPxLabel ID="lblAdd1" runat="server">
                    </dx:ASPxLabel>
                    </td>

            </tr>
            <tr>
                    <td colspan ="1">
                        &nbsp;</td>
                <td colspan ="7">
                    <dx:ASPxTextBox ID="txtAdd2" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="710px">
                    </dx:ASPxTextBox>
                    </td>

            </tr>
             <tr>
                    <td colspan ="1"></td>
                <td colspan ="7">
                    <dx:ASPxLabel ID="lblAdd2" runat="server">
                    </dx:ASPxLabel>
                    </td>

            </tr>
                <tr>
                    <td colspan ="1">
                        &nbsp;</td>
                <td colspan ="7">
                    <dx:ASPxTextBox ID="txtAdd3" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="710px">
                    </dx:ASPxTextBox>
                    </td>

            </tr>
             <tr>
                    <td colspan ="1"></td>
                <td colspan ="7">
                    <dx:ASPxLabel ID="lblAdd3" runat="server">
                    </dx:ASPxLabel>
                    </td>

            </tr>
                <tr>
                    <td colspan ="1">
                        &nbsp;</td>
                <td colspan ="7">
                    <dx:ASPxTextBox ID="txtAdd4" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="710px">
                    </dx:ASPxTextBox>
                    </td>

            </tr>
             <tr>
                    <td colspan ="1"></td>
                <td colspan ="7">
                    <dx:ASPxLabel ID="lblAdd4" runat="server">
                    </dx:ASPxLabel>
                    </td>

            </tr>
                <tr>
                    <td colspan ="1">
                        <dx:ASPxLabel ID="ASPxLabel54" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Country" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                <td colspan ="1">
                    
                    <dx:ASPxTextBox ID="txtCountry" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="250px">
                    </dx:ASPxTextBox>
                    
                    </td>
                    <td colspan ="1">
                    
                        <dx:ASPxLabel ID="ASPxLabel55" runat="server" Font-Names="Cambria" Font-Size="Small" Text="City" Theme="Glass">
                        </dx:ASPxLabel>
                    
                    </td>
                    <td colspan ="1">
                    
                        <dx:ASPxTextBox ID="txtCity" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="250px">
                        </dx:ASPxTextBox>
                    
                    </td>
                    <td colspan ="1">
                    
                    </td>
                    <td colspan ="1">
                    
                    </td>
                    <td colspan ="1">
                    
                    </td>
                    <td colspan ="1">
                    
                    </td>

            </tr>
            <tr>
                    <td colspan ="1"></td>
                <td colspan ="1">
                    <dx:ASPxLabel ID="lblCountry" runat="server">
                    </dx:ASPxLabel>
                    </td>
                <td colspan ="1"></td>
                <td colspan ="1">
                    <dx:ASPxLabel ID="lblCity" runat="server">
                    </dx:ASPxLabel>
                    </td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>

            </tr>
            <tr>
                    <td colspan ="1">
                        <dx:ASPxLabel ID="ASPxLabel8" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Telephone" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                <td colspan ="1">
                    <dx:ASPxTextBox ID="txtTel" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="250px">
                    </dx:ASPxTextBox>
                    </td>
                <td colspan ="1">
                    <dx:ASPxLabel ID="ASPxLabel9" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Mobile" Theme="Glass">
                    </dx:ASPxLabel>
                    </td>
                <td colspan ="1">
                    <dx:ASPxTextBox ID="txtMobile" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="250px">
                    </dx:ASPxTextBox>
                    </td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>

            </tr>
              <tr>
                    <td colspan ="1"></td>
                <td colspan ="1">
                    <dx:ASPxLabel ID="lblTel" runat="server">
                    </dx:ASPxLabel>
                    </td>
                <td colspan ="1"></td>
                <td colspan ="1">
                    <dx:ASPxLabel ID="lblMobile" runat="server">
                    </dx:ASPxLabel>
                    </td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>

            </tr>
            <tr>
                <td colspan ="1">
                    <dx:ASPxLabel ID="ASPxLabel10" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Email" Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                <td colspan ="1">
                    <dx:ASPxTextBox ID="txtEmail" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="250px">
                    </dx:ASPxTextBox>
                </td>
                <td colspan ="1">
                    &nbsp;</td>
                <td colspan ="1">
                    &nbsp;</td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>

            </tr>
                  <tr>
                    <td colspan ="1"></td>
                <td colspan ="1">
                    <dx:ASPxLabel ID="lblEmail" runat="server">
                    </dx:ASPxLabel>
                    </td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>

            </tr>
          
        </table>

    </asp:panel>
        <asp:panel id="Panel11" runat="server" GroupingText="Controlled/Non-controlled" Font-Names="Cambria">
        <table width="810px">
            <tr>
                    <td colspan ="8" align="center">
                        <asp:RadioButton ID="rdControlled" runat="server" AutoPostBack="True" GroupName="Controlling" Text="Controlled" />
                        <asp:RadioButton ID="rdNonControlled" runat="server" AutoPostBack="True" GroupName="Controlling" Text="Non Controlled" />
                    </td>

            </tr>
         
           <tr>
               <td colspan ="1">
                   <dx:ASPxLabel ID="ASPxLabel35" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Custodian" Theme="Glass">
                   </dx:ASPxLabel>
               </td>
               <td colspan ="7">
                   <dx:ASPxComboBox ID="cmbCustodian" runat="server" Theme="BlackGlass" ValueType="System.String" Width="710px">
                   </dx:ASPxComboBox>
               </td>

           </tr>
             <tr>
               <td colspan ="1">
                   &nbsp;</td>
               <td colspan ="7">
                   &nbsp;</td>

           </tr>
               
        </table>

    </asp:panel>
        
        <asp:panel id="Panel9" runat="server" GroupingText="Attributes" Font-Names="Cambria">
        <table width="810px">
         <tr>
                <td colspan ="1">
                    <dx:ASPxLabel ID="ASPxLabel46" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Trading Status" Theme="Glass">
                    </dx:ASPxLabel>
                </td>
             <td colspan ="1">
                 <asp:RadioButton ID="rdTrading" runat="server" AutoPostBack="True" GroupName="TradingStatus" Text="Trading" />
                 <asp:RadioButton ID="rdNonTrading" runat="server" AutoPostBack="True" GroupName="TradingStatus" Text="Non-Trading" />
                </td>
             <td colspan ="1">
                 &nbsp;</td>
             <td colspan ="1"></td>
             <td colspan ="1"></td>
             <td colspan ="1"></td>
             <td colspan ="1"></td>
             <td colspan ="1"></td>

         </tr>
            <tr>

                <td colspan ="1">
                    <dx:ASPxLabel ID="ASPxLabel48" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Industry" Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                <td colspan ="1">
                    <dx:ASPxTextBox ID="txtIndustry" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="250px">
                    </dx:ASPxTextBox>
                </td>
                <td colspan ="1">
                    <dx:ASPxLabel ID="ASPxLabel47" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Tax" Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                <td colspan ="1">
                    <dx:ASPxTextBox ID="txtTax" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="250px">
                    </dx:ASPxTextBox>
                </td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>

            </tr>

        </table>
             </asp:panel>
          <asp:panel id="Panel12" runat="server" GroupingText="Dividend Payment Mandate" Font-Names="Cambria">
        <table width="810px">
           <tr>
               <td colspan ="1">
                   <dx:ASPxLabel ID="ASPxLabel61" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Payee" Theme="Glass">
                   </dx:ASPxLabel>
               </td>
               <td colspan ="1">
                   <dx:ASPxTextBox ID="txtPayee2" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="250px">
                   </dx:ASPxTextBox>
               </td>
               <td colspan ="1">
                   &nbsp;</td>
               <td colspan ="1">
                   &nbsp;</td>
               <td colspan ="1">&nbsp;</td>
               <td colspan ="1">&nbsp;</td>
               <td colspan ="1">&nbsp;</td>
               <td colspan ="1">&nbsp;</td>
           </tr>
                <tr>
                    <td colspan="1">
                        <dx:ASPxLabel ID="ASPxLabel49" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Bank Name" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td colspan="1">
                        <dx:ASPxTextBox ID="txtBankName" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="250px">
                        </dx:ASPxTextBox>
                    </td>
                    <td colspan="1">
                        <dx:ASPxLabel ID="ASPxLabel50" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Branch" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td colspan="1">
                        <dx:ASPxTextBox ID="txtBranch" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="250px">
                        </dx:ASPxTextBox>
                    </td>
                    <td colspan="1"></td>
                    <td colspan="1"></td>
                    <td colspan="1"></td>
                    <td colspan="1"></td>
            </tr>
                <tr>
               <td colspan ="1">
                   <dx:ASPxLabel ID="ASPxLabel51" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Account No." Theme="Glass">
                   </dx:ASPxLabel>
                    </td>
               <td colspan ="1">
                   <dx:ASPxTextBox ID="txtAccountNo" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="250px">
                   </dx:ASPxTextBox>
                    </td>
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
               <td colspan ="1"></td>
               <td colspan ="1"></td>
           </tr>
        </table>

    </asp:panel>
        <asp:panel id="Panel2" runat="server" GroupingText="Settlement  Account Mandate" Font-Names="Cambria">
        <table width="810px">
           <tr>
               <td colspan ="1">
                   <dx:ASPxLabel ID="ASPxLabel60" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Payee" Theme="Glass">
                   </dx:ASPxLabel>
               </td>
               <td colspan ="1">
                   <dx:ASPxTextBox ID="txtPayee1" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="250px">
                   </dx:ASPxTextBox>
               </td>
               <td colspan ="1">
                   &nbsp;</td>
               <td colspan ="1">
                   &nbsp;</td>
               <td colspan ="1">&nbsp;</td>
               <td colspan ="1">&nbsp;</td>
               <td colspan ="1">&nbsp;</td>
               <td colspan ="1">&nbsp;</td>
           </tr>
                <tr>
                    <td colspan="1">
                        <dx:ASPxLabel ID="ASPxLabel2" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Bank Name" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td colspan="1">
                        <dx:ASPxTextBox ID="txtCashBank" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="250px">
                        </dx:ASPxTextBox>
                    </td>
                    <td colspan="1">
                        <dx:ASPxLabel ID="ASPxLabel3" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Branch" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td colspan="1">
                        <dx:ASPxTextBox ID="txtCashBrach" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="250px">
                        </dx:ASPxTextBox>
                    </td>
                    <td colspan="1"></td>
                    <td colspan="1"></td>
                    <td colspan="1"></td>
                    <td colspan="1"></td>
            </tr>
                <tr>
               <td colspan ="1">
                   <dx:ASPxLabel ID="ASPxLabel4" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Account No." Theme="Glass">
                   </dx:ASPxLabel>
                    </td>
               <td colspan ="1">
                   <dx:ASPxTextBox ID="txtCashAccount" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="250px">
                   </dx:ASPxTextBox>
                    </td>
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
               <td colspan ="1"></td>
               <td colspan ="1"></td>
           </tr>
        </table>

    </asp:panel>

     <asp:Panel runat="server" ID="panelSave" Font-Names="Cambria" GroupingText="Attachments">
         <table>
             <tr>
                    <td colspan ="8">
                        <dx:ASPxLabel ID="ASPxLabel52" runat="server" Text="____________________________________________________________________________________________________________________" Theme="BlackGlass">
                        </dx:ASPxLabel>
                    </td>

             </tr>
             <tr>                 
                 <td colspan ="1"></td>
                 <td colspan ="1"></td>
                 <td colspan ="1"></td>
                 <td colspan ="1">
                     <dx:ASPxCheckBox ID="ClientImage" runat="server" Text="Client's Image" Theme="Glass">
                     </dx:ASPxCheckBox>
                 </td>
                 <td colspan ="1">
                     &nbsp;</td>
                 <td colspan ="1"></td>
                 <td colspan ="1"></td>
                 <td colspan ="1"></td>

             </tr>
              <tr>                 
                 <td colspan ="1"></td>
                 <td colspan ="1"></td>
                 <td colspan ="1"></td>
                 <td colspan ="1">
                     <dx:ASPxCheckBox ID="Documents" runat="server" Text="Documents" Theme="Glass">
                     </dx:ASPxCheckBox>
                  </td>
                 <td colspan ="1">
                     &nbsp;</td>
                 <td colspan ="1"></td>
                 <td colspan ="1"></td>
                 <td colspan ="1"></td>

             </tr>
              <tr>                 
                 <td colspan ="1"></td>
                 <td colspan ="1"></td>
                 <td colspan ="1"></td>
                 <td colspan ="1">
                     <dx:ASPxCheckBox ID="Biomatrix" runat="server" Text="Biomatrix" Theme="Glass">
                     </dx:ASPxCheckBox>
                  </td>
                 <td colspan ="1">
                     &nbsp;</td>
                 <td colspan ="1"></td>
                 <td colspan ="1"></td>
                 <td colspan ="1"></td>

             </tr>
                <tr>
                        <td colspan ="8" align ="center" style="height: 24px">
                            &nbsp;</td>

                </tr>
             <tr>
                    <td colspan ="8" align ="center">
                        &nbsp;</td>
             </tr>
             <tr>
                    <td colspan ="8" align ="center"></td>

             </tr>

         </table>

     </asp:Panel>  
        <asp:Panel runat="server" ID="panel4" GroupingText=".">
            <table>
                    <tr>
                            <td colspan ="8" align="center">
                                <dx:ASPxLabel ID="ASPxLabel7" runat="server" Text="____________________________________________________________________________________________________________________" Theme="BlackGlass">
                                </dx:ASPxLabel>
                            </td>


                    </tr>
                <tr>
                        <td colspan ="4" align ="center">&nbsp;</td>
                    <td colspan ="4" align ="center">
                        <dx:ASPxRadioButton ID="rdApprove" runat="server" AutoPostBack="True" GroupName="Approval" Text="Approve" Theme="DevEx">
                        </dx:ASPxRadioButton>
                        <dx:ASPxRadioButton ID="rdReject" runat="server" AutoPostBack="True" GroupName="Approval" Text="Reject" Theme="DevEx">
                        </dx:ASPxRadioButton>
                        </td>

                </tr>
                <tr>
                    <td colspan ="1">
                        <dx:ASPxLabel ID="lblRejection" runat="server" Text="Rejection Reason" Visible="False">
                        </dx:ASPxLabel>
                    </td>
                    <td colspan ="7">
                        <dx:ASPxTextBox ID="txtReasons" runat="server" Height="80px" Theme="BlackGlass" Visible="False" Width="700px">
                        </dx:ASPxTextBox>
                    </td>
                </tr>
                <tr>
                        <td colspan ="8" align ="center">
                            <dx:ASPxButton ID="ASPxButton1" runat="server" Text="save" Theme="BlackGlass">
                            </dx:ASPxButton>
                        </td>

                </tr>

            </table>
        </asp:Panel>
        <asp:Panel runat="server" ID="panelsaving" GroupingText=".">
            <table>
                    <tr>
                            <td colspan ="8" align="center">
                                <dx:ASPxLabel ID="ASPxLabel53" runat="server" Text="____________________________________________________________________________________________________________________" Theme="BlackGlass">
                                </dx:ASPxLabel>
                            </td>


                    </tr>
                <tr>
                        <td colspan ="8" align ="center">
                            &nbsp;</td>

                </tr>

            </table>
        </asp:Panel>  
                 
</asp:Panel>
  
</div>
</asp:Content>

