<%@ Page Language="VB" MasterPageFile="~/CDSUser.master" AutoEventWireup="false" CodeFile="AccountsCreations.aspx.vb" Inherits="TransferSec_AccountsCreations" title="Account Details Enquiry" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<asp:Content id="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
    <asp:Panel id="Panel1" runat="server" Width="840px" Font-Names="Arial" Font-Size="Medium" BackColor="White">
    
        <table width ="810px">
            <tr>
                   <td style ="text-align :left;" align="left">
                       <dx:ASPxLabel ID="ASPxLabel1" runat="server" Text="Accounts Maintenance&gt;&gt;Accounts Creations" Font-Names="Cambria" Font-Size="Small" Theme="PlasticBlue"></dx:ASPxLabel>

                   </td>
            </tr>
        </table>
          <asp:panel id="Panel10" runat="server" GroupingText="Account Type" Font-Names="Cambria">
        <table width="810px">
            <tr>
                    <td colspan ="10" align="center">
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
               <td colspan ="9">
                   <dx:ASPxTextBox ID="txtJsurname" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="710px" Visible="False">
                   </dx:ASPxTextBox>
               </td>

           </tr>
             <tr>
               <td colspan ="1">
                   <dx:ASPxLabel ID="lblJforenames" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Forenames" Theme="Glass" Visible="False">
                   </dx:ASPxLabel>
                 </td>
               <td colspan ="9">
                   <dx:ASPxTextBox ID="txtJforenames" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="710px" Visible="False">
                   </dx:ASPxTextBox>
               </td>

           </tr>
                <tr>
                <td colspan ="1">
                    <dx:ASPxLabel ID="lblJID" runat="server" Font-Names="Cambria" Font-Size="Small" Text="ID No./Pin" Theme="Glass" Visible="False">
                    </dx:ASPxLabel>
                </td>
                <td>
                    <dx:ASPxTextBox ID="TXTjiD" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="30px" Visible="False" Height="16px">
                    </dx:ASPxTextBox>
                </td>
                    <td>
                        <dx:ASPxTextBox ID="TXTjiD0" runat="server" BackColor="#E4E4E4" Height="16px" Theme="BlackGlass" Visible="False" Width="100px">
                        </dx:ASPxTextBox>
                    </td>
                    <td>
                        <dx:ASPxTextBox ID="TXTjiD1" runat="server" BackColor="#E4E4E4" Height="16px" Theme="BlackGlass" Visible="False" Width="50px">
                        </dx:ASPxTextBox>
                    </td>
                <td colspan ="1">
                    <dx:ASPxLabel ID="LBLJIDTYPE" runat="server" Font-Names="Cambria" Font-Size="Small" Text="ID Type" Theme="Glass" Visible="False">
                    </dx:ASPxLabel>
                </td>
                <td colspan ="1">
                    <dx:ASPxComboBox ID="cmbJIDType" runat="server" Theme="BlackGlass" Width="200px" Visible="False">
                    </dx:ASPxComboBox>
                </td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>

            </tr>
            <tr>
                    <td colspan ="1">
                        <dx:ASPxLabel ID="lblJnationality" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Nationality" Theme="Glass" Visible="False">
                        </dx:ASPxLabel>
                    </td>
                <td colspan ="3">
                    <dx:ASPxComboBox ID="cmbJnationality" runat="server" Theme="BlackGlass" ValueType="System.String" Width="250px" Visible="False">
                    </dx:ASPxComboBox>
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
                    <dx:ASPxLabel ID="lblJdob" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Date Of Birth" Theme="Glass" Visible="False">
                    </dx:ASPxLabel>
                </td>
                <td colspan ="3">
                    <dx:ASPxDateEdit ID="txtJdob" runat="server" Theme="BlackGlass" Width="250px" Visible="False" DisplayFormatString="dd/MMMM/yyyy" EditFormat="Custom" EditFormatString="dd/MMMM/yyyy" AutoPostBack="True">
                    </dx:ASPxDateEdit>
                </td>
                <td colspan ="1">
                    <dx:ASPxLabel ID="lbljGender" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Gender" Theme="Glass" Visible="False">
                    </dx:ASPxLabel>
                </td>
                <td colspan ="1">
                    <asp:RadioButton ID="rdJmale" runat="server" AutoPostBack="True" GroupName="Gender2" Text="Male" Visible="False" />
                    <asp:RadioButton ID="rdJfemale" runat="server" AutoPostBack="True" GroupName="Gender2" Text="Female" Visible="False" />
                    <asp:RadioButton ID="rdJNa" runat="server" AutoPostBack="True" GroupName="Gender2" Text="N/A" Visible="False" />
                </td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>

            </tr>
        
            <tr>
                    <td colspan ="1"></td>
                <td colspan ="9" align="center">
                    <dx:ASPxButton ID="btnJadd" runat="server" Text="Add" Theme="BlackGlass" Visible="False">
                    </dx:ASPxButton>
                    </td>

            </tr>
            <tr>
                    <td colspan ="10" align ="center">
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
                    <dx:ASPxLabel ID="ASPxLabel25" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Client ID." Theme="Glass" Visible="False">
                    </dx:ASPxLabel>
                </td>
                <td colspan ="3">
                    <dx:ASPxTextBox ID="txtCDSNo" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="250px" ReadOnly="True" Visible="False">
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
                   <dx:ASPxLabel ID="ASPxLabel56" runat="server" ForeColor="Red" Text="*">
                   </dx:ASPxLabel>
               </td>
               <td colspan ="9">
                   <dx:ASPxTextBox ID="txtSurname" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="710px">
                   </dx:ASPxTextBox>
               </td>

           </tr>
            <tr>
               <td colspan ="1">
                   <dx:ASPxLabel ID="ASPxLabel5" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Firstname" Theme="Glass">
                   </dx:ASPxLabel>
                   
                   <dx:ASPxLabel ID="ASPxLabel63" runat="server" ForeColor="Red" Text="*">
                   </dx:ASPxLabel>
                   
               </td>
               <td colspan ="9">
                   <dx:ASPxTextBox ID="txtOthernames" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="710px">
                   </dx:ASPxTextBox>
               </td>

           </tr>
            <tr>
                    <td colspan ="1">
                        <dx:ASPxLabel ID="ASPxLabel27" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Other Names" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                <td colspan ="9">
                    <dx:ASPxTextBox ID="txtMiddleName" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="710px">
                    </dx:ASPxTextBox>
                    </td>

            </tr>
            <tr>
                    <td colspan ="1">
                        <dx:ASPxLabel ID="ASPxLabel28" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Initials" Theme="Glass" Visible="False">
                        </dx:ASPxLabel>
                    </td>
                <td colspan ="3">
                    <dx:ASPxTextBox ID="txtInitials" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="250px" Visible="False">
                    </dx:ASPxTextBox>
                    </td>
                <td colspan ="1">
                    <dx:ASPxLabel ID="ASPxLabel29" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Title" Theme="Glass">
                    </dx:ASPxLabel>
                    </td>
                <td colspan ="1">
                    <dx:ASPxComboBox ID="cmbTitle" runat="server" Theme="BlackGlass" Width="200px">
                        <Items>
                            <dx:ListEditItem Text="Mr." Value="Mr." />
                            <dx:ListEditItem Text="Mrs." Value="Mrs." />
                            <dx:ListEditItem Text="Miss." Value="Miss" />
                            <dx:ListEditItem Text="Ms." Value="Ms." />
                            <dx:ListEditItem Text="Sir." Value="Sir" />
                            <dx:ListEditItem Text="Esq." Value="Esq." />
                            <dx:ListEditItem Text="Rev." Value="Rev." />
                            <dx:ListEditItem Text="Dr." Value="Dr." />
                            <dx:ListEditItem Text="Prof." Value="Prof." />
                        </Items>
                    </dx:ASPxComboBox>
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
                    <dx:ASPxLabel ID="ASPxLabel57" runat="server" ForeColor="Red" Text="*">
                    </dx:ASPxLabel>
                </td>
                <td>
                    <dx:ASPxTextBox ID="txtIDNo" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="30px" MaxLength="2">
                    </dx:ASPxTextBox>
                </td>
                <td style="width: 83px">
                    <dx:ASPxTextBox ID="txtIDNo0" runat="server" BackColor="#E4E4E4" MaxLength="7" Theme="BlackGlass" Width="100px">
                    </dx:ASPxTextBox>
                </td>
                <td>
                    <dx:ASPxTextBox ID="txtIDNo1" runat="server" BackColor="#E4E4E4" MaxLength="3" Theme="BlackGlass" Width="50px">
                    </dx:ASPxTextBox>
                </td>
                <td colspan ="1">
                    <dx:ASPxLabel ID="ASPxLabel31" runat="server" Font-Names="Cambria" Font-Size="Small" Text="ID Type" Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                <td colspan ="1">
                    <dx:ASPxComboBox ID="cmbIDType" runat="server" Theme="BlackGlass" ValueType="System.String" Width="200px">
                    </dx:ASPxComboBox>
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
                <td colspan ="3">
                    <dx:ASPxComboBox ID="cmbNationality" runat="server" Theme="BlackGlass" ValueType="System.String" Width="250px">
                    </dx:ASPxComboBox>
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
                <td colspan ="3">
                    <dx:ASPxDateEdit ID="txtDOB" runat="server" Theme="BlackGlass" Width="250px" EditFormat="Custom" EditFormatString="dd/MMMM/yyyy">
                    </dx:ASPxDateEdit>
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
                <td colspan ="3"></td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>
            </tr>
            <tr>
                    <td colspan ="1"></td>
                <td colspan ="9" align="center"></td>

            </tr>

        </table>

    </asp:panel>
        <asp:panel id="Panel3" runat="server" GroupingText="Contact Details" Font-Names="Cambria">
        <table width="810px">
      
           <tr>
               <td colspan ="1">
                   <dx:ASPxLabel ID="ASPxLabel6" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Address" Theme="Glass">
                   </dx:ASPxLabel>
                   <dx:ASPxLabel ID="ASPxLabel58" runat="server" ForeColor="Red" Text="*">
                   </dx:ASPxLabel>
               </td>
               <td colspan ="7">
                   <dx:ASPxTextBox ID="txtAddress1" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="710px">
                   </dx:ASPxTextBox>
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
                    <td colspan ="1">
                        &nbsp;</td>
                <td colspan ="7">
                    <dx:ASPxTextBox ID="txtAdd3" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="710px">
                    </dx:ASPxTextBox>
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
                    <td colspan ="1">
                        <dx:ASPxLabel ID="ASPxLabel54" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Country" Theme="Glass">
                        </dx:ASPxLabel>
                        <dx:ASPxLabel ID="ASPxLabel59" runat="server" ForeColor="Red" Text="*">
                        </dx:ASPxLabel>
                    </td>
                <td colspan ="1">
                    
                    <dx:ASPxComboBox ID="cmbCountry" runat="server" Theme="BlackGlass" ValueType="System.String" Width="250px" AutoPostBack="True">
                    </dx:ASPxComboBox>
                    
                    </td>
                    <td colspan ="1">
                    
                        <dx:ASPxLabel ID="ASPxLabel55" runat="server" Font-Names="Cambria" Font-Size="Small" Text="City" Theme="Glass">
                        </dx:ASPxLabel>
                    
                        <dx:ASPxLabel ID="ASPxLabel60" runat="server" ForeColor="Red" Text="*">
                        </dx:ASPxLabel>
                    
                    </td>
                    <td colspan ="1">
                    
                        <dx:ASPxComboBox ID="cmbCity" runat="server" Theme="BlackGlass" ValueType="System.String" Width="250px">
                        </dx:ASPxComboBox>
                    
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
          
        </table>

    </asp:panel>
        <asp:panel id="Panel11" runat="server" GroupingText="Accounts Category" Font-Names="Cambria">
        <table width="810px">
            <tr>
                    <td colspan ="8" align="center">
                        <asp:RadioButton ID="rdControlled" runat="server" AutoPostBack="True" GroupName="Controlling" Text="Controlled" />
                        <asp:RadioButton ID="rdNonControlled" runat="server" AutoPostBack="True" GroupName="Controlling" Text="Non Controlled" />
                    </td>

            </tr>
         
           <tr>
               <td colspan ="1">
                   <dx:ASPxLabel ID="lblCoust" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Custodian" Theme="Glass" Visible="False">
                   </dx:ASPxLabel>
               </td>
               <td colspan ="7">
                   <dx:ASPxComboBox ID="cmbCustodian" runat="server" Theme="BlackGlass" ValueType="System.String" Width="710px" Visible="False">
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
                    <dx:ASPxLabel ID="ASPxLabel48" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Sector" Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                <td colspan ="1">
                    <dx:ASPxComboBox ID="cmbIndustry" runat="server" Theme="BlackGlass" ValueType="System.String" Width="250px">
                    </dx:ASPxComboBox>
                </td>
                <td colspan ="1">
                    <dx:ASPxLabel ID="ASPxLabel47" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Tax" Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                <td colspan ="1">
                    <dx:ASPxComboBox ID="cmbTax" runat="server" Theme="BlackGlass" Width="250px">
                        <Items>
                            <dx:ListEditItem Text="0" Value="0" />
                            <dx:ListEditItem Text="5" Value="5" />
                            <dx:ListEditItem Text="10" Value="10" />
                            <dx:ListEditItem Text="15" Value="15" />
                        </Items>
                    </dx:ASPxComboBox>
                </td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>

            </tr>

        </table>
             </asp:panel>
        <asp:panel id="Panel4" runat="server" GroupingText="Payment Instructions" Font-Names="Cambria">
        <table width="810px">
           <tr>
               <td>
                   <asp:Panel ID="Panel12" runat="server" Font-Bold="True" Font-Names="Cambria" Font-Size="10pt" GroupingText="Dividend Payment Mandate" Width="785px">
                       <table style="width: 780px">
                           <tr>
                               <td colspan="1">
                                   <dx:ASPxLabel ID="ASPxLabel62" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Payee" Theme="Glass">
                                   </dx:ASPxLabel>
                               </td>
                               <td colspan="1">
                                   <dx:ASPxTextBox ID="txtPayee2" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="250px">
                                   </dx:ASPxTextBox>
                               </td>
                               <td colspan="1">&nbsp;</td>
                               <td colspan="1">
                                   <dx:ASPxCheckBox ID="chkPayee2" runat="server" AutoPostBack="True" Text="Use Account Name">
                                   </dx:ASPxCheckBox>
                                   &nbsp;&nbsp; </td>
                               <td colspan="1">&nbsp;</td>
                               <td colspan="1">&nbsp;</td>
                               <td colspan="1">&nbsp;</td>
                               <td colspan="1">&nbsp;</td>
                           </tr>
                           <tr>
                               <td colspan="1">
                                   <dx:ASPxLabel ID="ASPxLabel49" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Bank Name" Theme="Glass">
                                   </dx:ASPxLabel>
                               </td>
                               <td colspan="1">
                                   <dx:ASPxComboBox ID="cmbBankDiv" runat="server" AutoPostBack="True" Theme="BlackGlass" ValueType="System.String" Width="250px">
                                   </dx:ASPxComboBox>
                               </td>
                               <td colspan="1">
                                   <dx:ASPxLabel ID="ASPxLabel50" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Branch" Theme="Glass">
                                   </dx:ASPxLabel>
                               </td>
                               <td colspan="1">
                                   <dx:ASPxComboBox ID="cmbBranchDiv" runat="server" Theme="BlackGlass" ValueType="System.String" Width="250px">
                                   </dx:ASPxComboBox>
                               </td>
                               <td colspan="1"></td>
                               <td colspan="1"></td>
                               <td colspan="1"></td>
                               <td colspan="1"></td>
                           </tr>
                           <tr>
                               <td colspan="1">
                                   <dx:ASPxLabel ID="ASPxLabel51" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Account No." Theme="Glass">
                                   </dx:ASPxLabel>
                               </td>
                               <td colspan="1">
                                   <dx:ASPxTextBox ID="txtAccountNoDiv" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="250px">
                                   </dx:ASPxTextBox>
                               </td>
                               <td colspan="1"></td>
                               <td colspan="1"></td>
                               <td colspan="1"></td>
                               <td colspan="1"></td>
                               <td colspan="1"></td>
                               <td colspan="1"></td>
                           </tr>
                           <tr>
                               <td colspan="1"></td>
                               <td colspan="1">
                                   <dx:ASPxLabel ID="lblBankCode" runat="server" Font-Names="Cambria" Font-Size="Small" Theme="Glass">
                                   </dx:ASPxLabel>
                               </td>
                               <td colspan="1"></td>
                               <td colspan="1"></td>
                               <td colspan="1"></td>
                               <td colspan="1"></td>
                               <td colspan="1"></td>
                               <td colspan="1"></td>
                           </tr>
                           <tr>
                               <td colspan="1"></td>
                               <td colspan="1"></td>
                               <td colspan="1"></td>
                               <td colspan="1"></td>
                               <td colspan="1"></td>
                               <td colspan="1"></td>
                               <td colspan="1"></td>
                               <td colspan="1"></td>
                           </tr>
                       </table>
                   </asp:Panel>
                   <asp:Panel ID="Panel2" runat="server" Font-Bold="True" Font-Names="Cambria" Font-Size="10pt" GroupingText="Settlement  Account Mandate" Width="785px">
                       <table style="width: 780px">
                           <tr>
                               <td colspan="1">
                                   <dx:ASPxLabel ID="ASPxLabel61" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Payee" Theme="Glass">
                                   </dx:ASPxLabel>
                               </td>
                               <td colspan="1">
                                   <dx:ASPxTextBox ID="txtPayee1" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="250px">
                                   </dx:ASPxTextBox>
                               </td>
                               <td colspan="1">&nbsp;</td>
                               <td colspan="1">
                                   <dx:ASPxCheckBox ID="chkDiv" runat="server" AutoPostBack="True" Text="Use Dividend Details">
                                   </dx:ASPxCheckBox>
                                   <dx:ASPxCheckBox ID="chkPayee1" runat="server" AutoPostBack="True" Text="Use Account Name">
                                   </dx:ASPxCheckBox>
                               </td>
                               <td colspan="1">&nbsp;</td>
                               <td colspan="1">&nbsp;</td>
                               <td colspan="1">&nbsp;</td>
                               <td colspan="1">&nbsp;</td>
                           </tr>
                           <tr>
                               <td colspan="1">
                                   <dx:ASPxLabel ID="ASPxLabel2" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Bank Name" Theme="Glass">
                                   </dx:ASPxLabel>
                               </td>
                               <td colspan="1">
                                   <dx:ASPxComboBox ID="cmbBankNameCash" runat="server" AutoPostBack="True" Theme="BlackGlass" ValueType="System.String" Width="250px">
                                   </dx:ASPxComboBox>
                               </td>
                               <td colspan="1">
                                   <dx:ASPxLabel ID="ASPxLabel3" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Branch" Theme="Glass">
                                   </dx:ASPxLabel>
                               </td>
                               <td colspan="1">
                                   <dx:ASPxComboBox ID="cmbBranchCash" runat="server" Theme="BlackGlass" ValueType="System.String" Width="250px">
                                   </dx:ASPxComboBox>
                               </td>
                               <td colspan="1"></td>
                               <td colspan="1"></td>
                               <td colspan="1"></td>
                               <td colspan="1"></td>
                           </tr>
                           <tr>
                               <td colspan="1">
                                   <dx:ASPxLabel ID="ASPxLabel4" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Account No." Theme="Glass">
                                   </dx:ASPxLabel>
                               </td>
                               <td colspan="1">
                                   <dx:ASPxTextBox ID="txtAccountNoCash" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="250px">
                                   </dx:ASPxTextBox>
                               </td>
                               <td colspan="1"></td>
                               <td colspan="1"></td>
                               <td colspan="1"></td>
                               <td colspan="1"></td>
                               <td colspan="1"></td>
                               <td colspan="1"></td>
                           </tr>
                           <tr>
                               <td colspan="1"></td>
                               <td colspan="1">
                                   <dx:ASPxLabel ID="lblBankCode2" runat="server" Font-Names="Cambria" Font-Size="Small" Theme="Glass">
                                   </dx:ASPxLabel>
                               </td>
                               <td colspan="1"></td>
                               <td colspan="1"></td>
                               <td colspan="1"></td>
                               <td colspan="1"></td>
                               <td colspan="1"></td>
                               <td colspan="1"></td>
                           </tr>
                           <tr>
                               <td colspan="1"></td>
                               <td colspan="1"></td>
                               <td colspan="1"></td>
                               <td colspan="1"></td>
                               <td colspan="1"></td>
                               <td colspan="1"></td>
                               <td colspan="1"></td>
                               <td colspan="1"></td>
                           </tr>
                       </table>
                   </asp:Panel>
               </td>
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
                     <dx:ASPxButton ID="ASPxButton6" runat="server" Text="Capture" Theme="BlackGlass">
                     </dx:ASPxButton>
                 </td>
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
                     <dx:ASPxButton ID="ASPxButton7" runat="server" Text="Attach" Theme="BlackGlass">
                     </dx:ASPxButton>
                  </td>
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
                     <dx:ASPxButton ID="ASPxButton8" runat="server" Text="Scan" Theme="BlackGlass">
                     </dx:ASPxButton>
                  </td>
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
                            <dx:ASPxButton ID="ASPxButton5" runat="server" Text="save" Theme="BlackGlass">
                            </dx:ASPxButton>
                        </td>

                </tr>

            </table>
        </asp:Panel>  
                 
</asp:Panel>
  
</div>
</asp:Content>

