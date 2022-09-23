<%@ Page Language="VB" MasterPageFile="~/CDSUser.master" AutoEventWireup="false" CodeFile="Copy of AccountsUpdate.aspx.vb" Inherits="TransferSec_AccountsCreations" title="Account Details Enquiry" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<asp:Content id="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
    <asp:Panel id="Panel1" runat="server" Width="840px" Font-Names="Arial" Font-Size="Medium" BackColor="White">
    
        <table width ="810px">
            <tr>
                   <td style ="text-align :left;" align="left">
                       <dx:ASPxLabel ID="ASPxLabel1" runat="server" Text="Accounts Maintenance&gt;&gt;Accounts Update" Font-Names="Cambria" Font-Size="Small" Theme="PlasticBlue"></dx:ASPxLabel>

                   </td>
            </tr>
        </table>
<asp:Panel runat="server" ID="panelSearch" Font-Names="Cambria" GroupingText="Search">
    <table>
            <tr>
                    <td colspan ="4" align ="right" >
                        <dx:ASPxLabel ID="ASPxLabel54" runat="server" Text="Client ID Search" Theme="Office2003Silver">
                        </dx:ASPxLabel>
                    </td>
                <td colspan ="3" align ="left">
                    <dx:ASPxTextBox ID="txtClientNo8" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="250px">
                    </dx:ASPxTextBox>
                    </td>
                <td colspan ="1" align ="left" >
                    <dx:ASPxButton ID="ASPxButton6" runat="server" Text="&gt;&gt;" Theme="BlackGlass">
                    </dx:ASPxButton>
                    </td>

            </tr>
                 <tr>
                    <td colspan ="4" align ="right" >
                        <dx:ASPxLabel ID="ASPxLabel5" runat="server" Text="Client Name Search" Theme="Office2003Silver">
                        </dx:ASPxLabel>
                    </td>
                <td colspan ="3" align ="left">
                    <dx:ASPxTextBox ID="ASPxTextBox2" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="250px">
                    </dx:ASPxTextBox>
                    </td>
                <td colspan ="1" align ="left" >
                    <dx:ASPxButton ID="ASPxButton1" runat="server" Text="&gt;&gt;" Theme="BlackGlass">
                    </dx:ASPxButton>
                    </td>

            </tr>

    </table>

</asp:Panel>
        <asp:panel id="Panel8" runat="server" GroupingText="Personal Details" Font-Names="Cambria">
        <table width="810px">
            <tr>
                <td colspan ="1">
                    <dx:ASPxLabel ID="ASPxLabel25" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Client ID." Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                <td colspan ="1">
                    <dx:ASPxTextBox ID="txtClientNo4" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="250px">
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
                   <dx:ASPxTextBox ID="ASPxTextBox12" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="710px">
                   </dx:ASPxTextBox>
               </td>

           </tr>
            <tr>
                    <td colspan ="1">
                        <dx:ASPxLabel ID="ASPxLabel27" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Other Names" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                <td colspan ="7">
                    <dx:ASPxTextBox ID="ASPxTextBox13" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="710px">
                    </dx:ASPxTextBox>
                    </td>

            </tr>
            <tr>
                    <td colspan ="1">
                        <dx:ASPxLabel ID="ASPxLabel28" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Initials" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                <td colspan ="1">
                    <dx:ASPxTextBox ID="txtClientNo5" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="250px">
                    </dx:ASPxTextBox>
                    </td>
                <td colspan ="1">
                    <dx:ASPxLabel ID="ASPxLabel29" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Title" Theme="Glass">
                    </dx:ASPxLabel>
                    </td>
                <td colspan ="1">
                    <dx:ASPxComboBox ID="cmbTitle" runat="server" Theme="BlackGlass" ValueType="System.String" Width="200px">
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
                </td>
                <td colspan ="1">
                    <dx:ASPxTextBox ID="txtClientNo6" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="250px">
                    </dx:ASPxTextBox>
                </td>
                <td colspan ="1">
                    <dx:ASPxLabel ID="ASPxLabel31" runat="server" Font-Names="Cambria" Font-Size="Small" Text="ID Type" Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                <td colspan ="1">
                    <dx:ASPxComboBox ID="cmbTitle0" runat="server" Theme="BlackGlass" ValueType="System.String" Width="200px">
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
                <td colspan ="1">
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
                <td colspan ="1">
                    <dx:ASPxDateEdit ID="txtDOB" runat="server" Theme="BlackGlass" Width="250px">
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
                   <dx:ASPxTextBox ID="ASPxTextBox3" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="710px">
                   </dx:ASPxTextBox>
               </td>

           </tr>
            <tr>
                    <td colspan ="1">
                        &nbsp;</td>
                <td colspan ="7">
                    <dx:ASPxTextBox ID="ASPxTextBox4" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="710px">
                    </dx:ASPxTextBox>
                    </td>

            </tr>
                <tr>
                    <td colspan ="1">
                        &nbsp;</td>
                <td colspan ="7">
                    <dx:ASPxTextBox ID="ASPxTextBox5" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="710px">
                    </dx:ASPxTextBox>
                    </td>

            </tr>
                <tr>
                    <td colspan ="1">
                        &nbsp;</td>
                <td colspan ="7">
                    <dx:ASPxTextBox ID="ASPxTextBox7" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="710px">
                    </dx:ASPxTextBox>
                    </td>

            </tr>
                <tr>
                    <td colspan ="1">
                        <dx:ASPxLabel ID="ASPxLabel7" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Country" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                <td colspan ="1">
                    
                    <dx:ASPxComboBox ID="ASPxComboBox6" runat="server" Theme="BlackGlass" ValueType="System.String" Width="250px">
                    </dx:ASPxComboBox>
                    
                    </td>
                    <td colspan ="1">
                    
                        <dx:ASPxLabel ID="ASPxLabel55" runat="server" Font-Names="Cambria" Font-Size="Small" Text="City" Theme="Glass">
                        </dx:ASPxLabel>
                    
                    </td>
                    <td colspan ="1">
                    
                        <dx:ASPxComboBox ID="ASPxComboBox7" runat="server" Theme="BlackGlass" ValueType="System.String" Width="250px">
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
                    <dx:ASPxTextBox ID="ASPxTextBox6" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="250px">
                    </dx:ASPxTextBox>
                    </td>
                <td colspan ="1">
                    <dx:ASPxLabel ID="ASPxLabel9" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Mobile" Theme="Glass">
                    </dx:ASPxLabel>
                    </td>
                <td colspan ="1">
                    <dx:ASPxTextBox ID="ASPxTextBox14" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="250px">
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
                    <dx:ASPxTextBox ID="ASPxTextBox8" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="250px">
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
        <asp:panel id="Panel10" runat="server" GroupingText="Account Type" Font-Names="Cambria">
        <table width="810px">
            <tr>
                    <td colspan ="8" align="center">
                        <asp:RadioButton ID="rdIndividual" runat="server" AutoPostBack="True" GroupName="AccountType" Text="Individual" />
                        <asp:RadioButton ID="rdJoint" runat="server" AutoPostBack="True" GroupName="AccountType" Text="Joint" />
                        <asp:RadioButton ID="rdCorporate" runat="server" AutoPostBack="True" GroupName="AccountType" Text="Corporate" />
                        <asp:RadioButton ID="rdBroker" runat="server" AutoPostBack="True" GroupName="AccountType" Text="Broker" />
                    </td>

            </tr>
         
           <tr>
               <td colspan ="1">
                   <dx:ASPxLabel ID="lblJsurname" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Surname" Theme="Glass" Visible="False">
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
                    <dx:ASPxComboBox ID="cmbIndustry" runat="server" Theme="BlackGlass" ValueType="System.String" Width="250px">
                    </dx:ASPxComboBox>
                </td>
                <td colspan ="1">
                    <dx:ASPxLabel ID="ASPxLabel47" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Tax" Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                <td colspan ="1">
                    <dx:ASPxComboBox ID="cmbTax" runat="server" Theme="BlackGlass" ValueType="System.String" Width="250px">
                    </dx:ASPxComboBox>
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
                   <dx:ASPxLabel ID="ASPxLabel49" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Bank Name" Theme="Glass">
                   </dx:ASPxLabel>
               </td>
               <td colspan ="1">
                   <dx:ASPxComboBox ID="cmbIndustry0" runat="server" Theme="BlackGlass" ValueType="System.String" Width="250px">
                   </dx:ASPxComboBox>
               </td>
               <td colspan ="1">
                   <dx:ASPxLabel ID="ASPxLabel50" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Branch" Theme="Glass">
                   </dx:ASPxLabel>
               </td>
               <td colspan ="1">
                   <dx:ASPxComboBox ID="cmbTax0" runat="server" Theme="BlackGlass" ValueType="System.String" Width="250px">
                   </dx:ASPxComboBox>
               </td>
               <td colspan ="1"></td>
               <td colspan ="1"></td>
               <td colspan ="1"></td>
               <td colspan ="1"></td>
           </tr>
                <tr>
               <td colspan ="1">
                   <dx:ASPxLabel ID="ASPxLabel51" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Account No." Theme="Glass">
                   </dx:ASPxLabel>
                    </td>
               <td colspan ="1">
                   <dx:ASPxTextBox ID="txtClientNo7" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="250px">
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
        <asp:panel id="Panel2" runat="server" GroupingText="Cash Account Mandate" Font-Names="Cambria">
        <table width="810px">
           <tr>
               <td colspan ="1">
                   <dx:ASPxLabel ID="ASPxLabel2" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Bank Name" Theme="Glass">
                   </dx:ASPxLabel>
               </td>
               <td colspan ="1">
                   <dx:ASPxComboBox ID="ASPxComboBox1" runat="server" Theme="BlackGlass" ValueType="System.String" Width="250px">
                   </dx:ASPxComboBox>
               </td>
               <td colspan ="1">
                   <dx:ASPxLabel ID="ASPxLabel3" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Branch" Theme="Glass">
                   </dx:ASPxLabel>
               </td>
               <td colspan ="1">
                   <dx:ASPxComboBox ID="ASPxComboBox2" runat="server" Theme="BlackGlass" ValueType="System.String" Width="250px">
                   </dx:ASPxComboBox>
               </td>
               <td colspan ="1"></td>
               <td colspan ="1"></td>
               <td colspan ="1"></td>
               <td colspan ="1"></td>
           </tr>
                <tr>
               <td colspan ="1">
                   <dx:ASPxLabel ID="ASPxLabel4" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Account No." Theme="Glass">
                   </dx:ASPxLabel>
                    </td>
               <td colspan ="1">
                   <dx:ASPxTextBox ID="ASPxTextBox1" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="250px">
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
                    <td>
                        <dx:ASPxLabel ID="ASPxLabel52" runat="server" Text="____________________________________________________________________________________________________________________" Theme="BlackGlass">
                        </dx:ASPxLabel>
                    </td>

             </tr>
                <tr>
                        <td colspan ="8" align ="center" style="height: 24px">
                            <asp:RadioButton ID="RadioButton1" runat="server" AutoPostBack="True" GroupName="Attachments" Text="Capture Image" />
                            <asp:RadioButton ID="RadioButton2" runat="server" AutoPostBack="True" GroupName="Attachments" Text="Scan Document" />
                            <asp:RadioButton ID="RadioButton3" runat="server" AutoPostBack="True" GroupName="Attachments" Text="Biomatrix" />
                        </td>

                </tr>
             <tr>
                    <td colspan ="8" align ="center">
                        <dx:ASPxButton ID="ASPxButton4" runat="server" Text="Capture" Theme="BlackGlass">
                        </dx:ASPxButton>
                    </td>
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

