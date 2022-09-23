<%@ Page Language="VB" MasterPageFile="~/CDSUser.master" AutoEventWireup="false" CodeFile="AccountsCreationsB.aspx.vb" Inherits="TransferSec_AccountsCreationsB" title="Account Details Enquiry" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<%@ Register assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxUploadControl" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxLoadingPanel" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dx1" %>
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
          
          <asp:panel id="Panel10" runat="server" GroupingText="Client Suffix" Font-Names="Cambria">
        <table width="810px">
            <tr>
                    <td colspan ="10" align="center">
                        <asp:RadioButton ID="rdIndividual" runat="server" AutoPostBack="True" GroupName="AccountType" Text="Individual" />
                        <asp:RadioButton ID="rdJoint" runat="server" AutoPostBack="True" GroupName="AccountType" Text="Joint" />
                        <asp:RadioButton ID="rdJoint0" runat="server" AutoPostBack="True" GroupName="AccountType" Text="Nominee" Visible="False" />
                        <asp:RadioButton ID="rdCorprate" runat="server" AutoPostBack="True" GroupName="AccountType" Text="Corporate" />
                        <asp:RadioButton ID="rdBroker" runat="server" AutoPostBack="True" GroupName="AccountType" Text="Broker" Visible="False" />
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
                <td colspan ="1">
                    
                    </td>
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
                        &nbsp;</td>

            </tr>
        </table>

    </asp:panel>
        <asp:Panel ID="Panel13" runat="server" Font-Names="Cambria" GroupingText="Identification Verification">
              <table width="810px">
                  <tr>
                      <td colspan="8" align="center" style="height: 18px;">
                          </td>
                  </tr>
                  <tr>
                      <td colspan="1" style="width: 97px">
                          <dx:ASPxLabel ID="ASPxLabel31" runat="server" Font-Names="Cambria" Font-Size="Small" Text="ID Type 1" Theme="Glass">
                          </dx:ASPxLabel>
                      </td>
                      <td colspan="1">
                          <dx:ASPxComboBox ID="cmbIDType" runat="server" Theme="BlackGlass" Width="200px"  CallbackPageSize="15" EnableCallbackMode="True" DropDownStyle="DropDownList"  IncrementalFilteringMode="Contains"  AnimationType="Slide" AutoPostBack="True">
                             
                          </dx:ASPxComboBox>
                      </td>
                      <td colspan="1">
                          <dx:ASPxLabel ID="ASPxLabel30" runat="server" Font-Names="Cambria" Font-Size="Small" Text="ID No 1" Theme="Glass">
                          </dx:ASPxLabel>
                      </td>
                      <td colspan="1">
                          <dx:ASPxTextBox ID="txtIDNo" runat="server" BackColor="#E4E4E4" MaxLength="50" Theme="BlackGlass" Width="180px">
                            
                          </dx:ASPxTextBox>
                      </td>
                      <td colspan="1"></td>
                      <td colspan="1"></td>
                      <td colspan="1"></td>
                      <td colspan="1"></td>
                  </tr>
                  <tr>
                      <td colspan="1" style="width: 97px">&nbsp;</td>
                      <td colspan="1">
                          <asp:CheckBox ID="CheckBox1" runat="server" AutoPostBack="True" Font-Size="Smaller" Text="Foreign Account Holder" />
                      </td>
                      <td colspan="1">&nbsp;</td>
                      <td colspan="1">&nbsp;</td>
                      <td colspan="1">&nbsp;</td>
                      <td colspan="1">&nbsp;</td>
                      <td colspan="1">&nbsp;</td>
                      <td colspan="1">&nbsp;</td>
                  </tr>
                  <tr>
                      <td colspan="1" style="width: 97px; height: 23px;">
                          <dx:ASPxLabel ID="ASPxLabel68" runat="server" Font-Names="Cambria" Font-Size="Small" Text="ID Type 2" Theme="Glass" Visible="False">
                          </dx:ASPxLabel>
                      </td>
                      <td colspan="1" style="height: 23px">
                          <dx:ASPxComboBox ID="cmbIDType0" runat="server" Theme="BlackGlass" ValueType="System.String" Width="200px" CallbackPageSize="15" EnableCallbackMode="True" DropDownStyle="DropDownList"  IncrementalFilteringMode="Contains"  AnimationType="Slide" Visible="False">
                          </dx:ASPxComboBox>
                      </td>
                      <td colspan="1" style="height: 23px">
                          <dx:ASPxLabel ID="ASPxLabel67" runat="server" Font-Names="Cambria" Font-Size="Small" Text="ID No 2" Theme="Glass" Visible="False">
                          </dx:ASPxLabel>
                      </td>
                      <td colspan="1" style="height: 23px">
                          <dx:ASPxTextBox ID="txtIDNo0" runat="server" BackColor="#E4E4E4" MaxLength="50" Theme="BlackGlass" Width="180px" Visible="False">
                          </dx:ASPxTextBox>
                      </td>
                      <td colspan="1" style="height: 23px"></td>
                      <td colspan="1" style="height: 23px"></td>
                      <td colspan="1" style="height: 23px"></td>
                      <td colspan="1" style="height: 23px"></td>
                  </tr>
                  <tr>
                      <td align="center" colspan="8">
                          <dx:ASPxButton ID="btnJadd0" runat="server" Height="22px" Text="Validate Identification Details" Theme="BlackGlass" Width="201px">
                          </dx:ASPxButton>
                      </td>
                  </tr>
              </table>
        </asp:Panel>
        <asp:Panel ID="Panel8" runat="server" Font-Names="Cambria" GroupingText="Personal Details" Visible="False">
            <table width="810px">
                <tr>
                    <td colspan="1">
                        <dx:ASPxLabel ID="ASPxLabel25" runat="server" Font-Names="Cambria" Font-Size="Small" Text="CDS Number" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td>
                        <dx:ASPxTextBox ID="txtCDSNo" runat="server" BackColor="#E4E4E4" ReadOnly="True" Theme="BlackGlass" Width="250px">
                        </dx:ASPxTextBox>
                    </td>
                    <td colspan="1" style="width: 223px"></td>
                    <td colspan="1"></td>
                    <td colspan="1"></td>
                    <td colspan="1"></td>
                    <td colspan="1"></td>
                    <td colspan="1"></td>
                </tr>
                <tr>
                    <td colspan="1" style="height: 37px">
                        <dx:ASPxLabel ID="ASPxLabel26" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Surname" Theme="Glass">
                        </dx:ASPxLabel>
                        <dx:ASPxLabel ID="ASPxLabel56" runat="server" ForeColor="Red" Text="*">
                        </dx:ASPxLabel>
                    </td>
                    <td colspan="7" style="height: 37px">
                        <dx:ASPxTextBox ID="txtSurname" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="710px">
                        </dx:ASPxTextBox>
                        <asp:RequiredFieldValidator ID="req_Pwd" runat="server" ControlToValidate="txtsurname" Display="None" ErrorMessage="Surname Required" ValidationGroup="Submit"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td colspan="1">
                        <dx:ASPxLabel ID="ASPxLabel5" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Firstname" Theme="Glass">
                        </dx:ASPxLabel>
                        <dx:ASPxLabel ID="ASPxLabel63" runat="server" ForeColor="Red" Text="*">
                        </dx:ASPxLabel>
                    </td>
                    <td colspan="7">
                        <dx:ASPxTextBox ID="txtOthernames" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="710px">
                        </dx:ASPxTextBox>
                        <asp:RequiredFieldValidator ID="req_Pwd0" runat="server" ControlToValidate="txtdob" Display="None" ErrorMessage="First Name is Required" ValidationGroup="Submit"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td colspan="1">
                        <dx:ASPxLabel ID="ASPxLabel27" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Other Names" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td colspan="7">
                        <dx:ASPxTextBox ID="txtMiddleName" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="710px">
                        </dx:ASPxTextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="1">
                        <dx:ASPxLabel ID="ASPxLabel29" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Title" Theme="Glass">
                        </dx:ASPxLabel>
                        <dx:ASPxLabel ID="ASPxLabel80" runat="server" ForeColor="Red" Text="*">
                        </dx:ASPxLabel>
                    </td>
                    <td>
                        <dx:ASPxComboBox ID="cmbTitle" runat="server" Theme="BlackGlass" Width="250px" CallbackPageSize="15" EnableCallbackMode="True" DropDownStyle="DropDownList"  IncrementalFilteringMode="Contains"  AnimationType="Slide">
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
                    <td colspan="1" style="width: 223px">
                        <dx:ASPxLabel ID="ASPxLabel28" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Initials" Theme="Glass" Visible="False">
                        </dx:ASPxLabel>
                    </td>
                    <td colspan="1">
                        <dx:ASPxTextBox ID="txtInitials" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Visible="False" Width="250px">
                        </dx:ASPxTextBox>
                    </td>
                    <td colspan="1"></td>
                    <td colspan="1"></td>
                    <td colspan="1"></td>
                    <td colspan="1"></td>
                </tr>
                <tr>
                    <td colspan="1">
                        <dx:ASPxLabel ID="ASPxLabel44" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Nationality" Theme="Glass">
                        </dx:ASPxLabel>
                        <dx:ASPxLabel ID="ASPxLabel81" runat="server" ForeColor="Red" Text="*">
                        </dx:ASPxLabel>
                    </td>
                    <td>
                        <dx:ASPxComboBox ID="cmbNationality" runat="server" Theme="BlackGlass" ValueType="System.String" Width="250px" CallbackPageSize="15" EnableCallbackMode="True" DropDownStyle="DropDownList"  IncrementalFilteringMode="Contains"  AnimationType="Slide">
                        </dx:ASPxComboBox>
                    </td>
                    <td align="right" colspan="1" style="width: 223px">
                        <dx:ASPxLabel ID="ASPxLabel94" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Place of Birth" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td colspan="1">
                        <dx:ASPxTextBox ID="txtInitials0" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="250px">
                        </dx:ASPxTextBox>
                    </td>
                    <td colspan="1"></td>
                    <td colspan="1"></td>
                    <td colspan="1"></td>
                    <td colspan="1"></td>
                </tr>
                <tr>
                    <td colspan="1" style="height: 16px">
                        <dx:ASPxLabel ID="ASPxLabel32" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Date Of Birth" Theme="Glass">
                        </dx:ASPxLabel>
                        <dx:ASPxLabel ID="ASPxLabel79" runat="server" ForeColor="Red" Text="*">
                        </dx:ASPxLabel>
                    </td>
                    <td style="height: 16px">
                        <dx:ASPxDateEdit ID="txtDOB" runat="server" EditFormat="Custom" EditFormatString="dd/MMMM/yyyy" Theme="BlackGlass" Width="250px">
                        </dx:ASPxDateEdit>
                    </td>
                    <td align="right" colspan="1" style="height: 16px; width: 223px;">
                        <dx:ASPxLabel ID="ASPxLabel33" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Gender" Theme="Glass">
                        </dx:ASPxLabel>
                        <dx:ASPxLabel ID="ASPxLabel82" runat="server" ForeColor="Red" Text="*">
                        </dx:ASPxLabel>
                    </td>
                    <td colspan="1" style="height: 16px">
                        <asp:RadioButton ID="rdMale" runat="server" AutoPostBack="True" GroupName="Gender" Text="Male" />
                        <asp:RadioButton ID="rdFemale" runat="server" AutoPostBack="True" GroupName="Gender" Text="Female" />
                        <asp:RadioButton ID="rdNa" runat="server" AutoPostBack="True" GroupName="Gender" Text="N/A" />
                    </td>
                    <td colspan="1" style="height: 16px"></td>
                    <td colspan="1" style="height: 16px"></td>
                    <td colspan="1" style="height: 16px"></td>
                    <td colspan="1" style="height: 16px"></td>
                </tr>
                <tr>
                    <td colspan="1"></td>
                    <td>
                        <asp:RequiredFieldValidator ID="req_Pwd1" runat="server" ControlToValidate="txtsurname" Display="None" ErrorMessage="Surname Required" ValidationGroup="Submit"></asp:RequiredFieldValidator>
                    </td>
                    <td colspan="1" style="width: 223px"></td>
                    <td colspan="1"></td>
                    <td colspan="1"></td>
                    <td colspan="1"></td>
                    <td colspan="1"></td>
                    <td colspan="1"></td>
                </tr>
                <tr>
                    <td align="center"  colspan="8">
                        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="Submit" />
                    </td>
                </tr>
            </table>
        </asp:Panel>
        <asp:Panel ID="Panel15" runat="server" Font-Names="Cambria" GroupingText="Joint Account Details" Visible="False">
            <table width="810px">
                <tr>
                    <td colspan="1" style="width: 61px">&nbsp;</td>
                    <td>&nbsp;</td>
                    <td colspan="1"></td>
                    <td colspan="1"></td>
                    <td colspan="1"></td>
                    <td colspan="1"></td>
                    <td colspan="1"></td>
                    <td colspan="1"></td>
                </tr>
                <tr>
                    <td colspan="1" style="width: 61px">
                        <dx:ASPxLabel ID="ASPxLabel72" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Names" Theme="Glass">
                        </dx:ASPxLabel>
                        <dx:ASPxLabel ID="ASPxLabel73" runat="server" ForeColor="Red" Text="*">
                        </dx:ASPxLabel>
                    </td>
                    <td colspan="7">
                        <dx:ASPxTextBox ID="txtSurname0" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="710px">
                        </dx:ASPxTextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="1" style="width: 61px"></td>
                    <td></td>
                    <td colspan="1"></td>
                    <td colspan="1"></td>
                    <td colspan="1"></td>
                    <td colspan="1"></td>
                    <td colspan="1"></td>
                    <td colspan="1"></td>
                </tr>
                <tr>
                    <td align="center"  colspan="8">
                        <dx:ASPxButton ID="btnJadd4" runat="server" Height="22px" Text="Validate Joint Account Name" Theme="BlackGlass" Width="201px">
                        </dx:ASPxButton>
                    </td>
                </tr>
            </table>
        </asp:Panel>
        <asp:panel id="Panel3" runat="server" GroupingText="Contact Details" Font-Names="Cambria" Visible="False">
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
                   <asp:RequiredFieldValidator ID="req_Pwd2" runat="server" ControlToValidate="txtaddress1" Display="None" ErrorMessage="Surname Required" ValidationGroup="Submit"></asp:RequiredFieldValidator>
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
                    
                    <dx:ASPxComboBox ID="cmbCountry" runat="server" Theme="BlackGlass" ValueType="System.String" Width="250px" CallbackPageSize="15" EnableCallbackMode="True" DropDownStyle="DropDownList"  IncrementalFilteringMode="Contains"  AnimationType="Slide">
                    </dx:ASPxComboBox>
                    
                    <asp:RequiredFieldValidator ID="req_Pwd3" runat="server" ControlToValidate="cmbcountry" Display="None" ErrorMessage="Country Required" ValidationGroup="Submit"></asp:RequiredFieldValidator>
                    
                    </td>
                    <td colspan ="1">
                    
                        &nbsp;</td>
                    <td colspan ="1">
                    
                        <dx:ASPxComboBox ID="cmbCity" runat="server" Theme="BlackGlass" ValueType="System.String" Width="250px" Visible="False" CallbackPageSize="15" EnableCallbackMode="True" DropDownStyle="DropDownList"  IncrementalFilteringMode="Contains"  AnimationType="Slide">
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
                    <dx:ASPxLabel ID="ASPxLabel77" runat="server" ForeColor="Red" Text="*">
                    </dx:ASPxLabel>
                    </td>
                <td colspan ="1">
                    <dx:ASPxTextBox ID="txtMobile" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="250px">
                        <MaskSettings ErrorText="Invalid Mobile" Mask="(+263) 000 000 000" />
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
                    <dx:ASPxLabel ID="ASPxLabel78" runat="server" ForeColor="Red" Text="*">
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
                        <asp:RadioButton ID="rdControlled" runat="server" AutoPostBack="True" GroupName="Controlling" Text="Controlled" Enabled="False" />
                        <asp:RadioButton ID="rdNonControlled" runat="server" AutoPostBack="True" GroupName="Controlling" Text="Non Controlled" Enabled="False" />
                    </td>

            </tr>
         
           <tr>
               <td colspan ="1">
                   <dx:ASPxLabel ID="lblCoust" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Custodian" Theme="Glass" Visible="False">
                   </dx:ASPxLabel>
               </td>
               <td colspan ="7">
                   <dx:ASPxComboBox ID="cmbCustodian" runat="server" Theme="BlackGlass" Width="710px" Visible="False" ValueField = "Custodian" TextFormatString = "{1}" >
                    
                       <Columns>
                           <dx:ListBoxColumn FieldName="Custodian" Name="Custodian Name" />
                           <dx:ListBoxColumn FieldName="Custodian Code" Name="Custodian Code" />
                           <dx:ListBoxColumn FieldName="Country" Name="Country" />
                           <dx:ListBoxColumn FieldName="Contact Person" Name="Phone" />
                           <dx:ListBoxColumn FieldName="Phone" Name="Phone" />
                       </Columns>
                    
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
      
        <asp:Panel ID="Panel17" runat="server" Font-Names="Cambria" GroupingText="Holdings(Units)">
            <table width="810px">
                <tr>
                    <td align="center" colspan="2">
                        <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" ShowFooter="True" Width="100%">
                            <AlternatingRowStyle BackColor="White" />
                            <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />
                            <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                            <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
                            <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                            <SortedAscendingCellStyle BackColor="#FDF5AC" />
                            <SortedAscendingHeaderStyle BackColor="#4D0000" />
                            <SortedDescendingCellStyle BackColor="#FCF6C0" />
                            <SortedDescendingHeaderStyle BackColor="#820000" />
                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td colspan="1">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
            </table>
        </asp:Panel>
      
        <asp:panel id="Panel9" runat="server" GroupingText="Attributes" Font-Names="Cambria" Visible="False">
        <table width="810px">
         <tr>
                <td colspan ="1">
                    <dx:ASPxLabel ID="ASPxLabel46" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Trading Status" Theme="Glass">
                    </dx:ASPxLabel>
                </td>
             <td colspan ="1">
                 <asp:RadioButton ID="rdTrading" runat="server" AutoPostBack="True" GroupName="TradingStatus" Text="Dealing Allowed" />
                 <asp:RadioButton ID="rdNonTrading" runat="server" AutoPostBack="True" GroupName="TradingStatus" Text="NON-TRADING" />
                </td>
             <td colspan ="1">
                 &nbsp;</td>
             <td colspan ="1">&nbsp;</td>
             <td colspan ="1"></td>
             <td colspan ="1"></td>
             <td colspan ="1"></td>
             <td colspan ="1"></td>

         </tr>
            <tr>

                <td colspan ="1">
                    <dx:ASPxLabel ID="ASPxLabel48" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Client Type" Theme="Glass">
                    </dx:ASPxLabel>
                    <dx:ASPxLabel ID="ASPxLabel89" runat="server" ForeColor="Red" Text="*">
                    </dx:ASPxLabel>
                </td>
                <td colspan ="1">
                    <dx:ASPxComboBox ID="cmbIndustry"  runat="server" Theme="BlackGlass" ValueType="System.String" Width="250px" CallbackPageSize="15" EnableCallbackMode="True" DropDownStyle="DropDownList"  IncrementalFilteringMode="Contains"  AnimationType="Slide" AutoPostBack="True">
                    </dx:ASPxComboBox>
                </td>
                <td colspan ="1">
                    <dx:ASPxLabel ID="ASPxLabel95" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Tax" Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                <td colspan ="1">
                    <dx:ASPxComboBox ID="cmbTax" runat="server" Theme="BlackGlass" Width="250px">
                       
                    </dx:ASPxComboBox>
                </td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>

            </tr>

        </table>
             </asp:panel>
        <asp:panel id="Panel4" runat="server" GroupingText="Payment Instructions" Font-Names="Cambria" Visible="False">
        <table width="810px">
           <tr>
               <td>
                   <asp:Panel ID="Panel12" runat="server" Font-Bold="True" Font-Names="Cambria" Font-Size="10pt" GroupingText="Dividend Payment Mandate" Width="785px" Visible="False">
                       <table style="width: 780px">
                           <tr>
                               <td colspan="1">
                                   <dx:ASPxLabel ID="ASPxLabel62" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Payee" Theme="Glass">
                                   </dx:ASPxLabel>
                                   <dx:ASPxLabel ID="ASPxLabel91" runat="server" ForeColor="Red" Text="*">
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
                               <td colspan="1" style="height: 23px">
                                   <dx:ASPxLabel ID="ASPxLabel49" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Bank Name" Theme="Glass">
                                   </dx:ASPxLabel>
                                   <dx:ASPxLabel ID="ASPxLabel92" runat="server" ForeColor="Red" Text="*">
                                   </dx:ASPxLabel>
                               </td>
                               <td colspan="1" style="height: 23px">
                                   <dx:ASPxComboBox ID="cmbBankDiv" runat="server" AutoPostBack="True" Theme="BlackGlass" ValueType="System.String" Width="250px" CallbackPageSize="15" EnableCallbackMode="True" DropDownStyle="DropDownList"  IncrementalFilteringMode="Contains"  AnimationType="Slide">
                                   </dx:ASPxComboBox>
                               </td>
                               <td colspan="1" style="height: 23px">
                                   <dx:ASPxLabel ID="ASPxLabel50" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Branch" Theme="Glass">
                                   </dx:ASPxLabel>
                                   <dx:ASPxLabel ID="ASPxLabel88" runat="server" ForeColor="Red" Text="*">
                                   </dx:ASPxLabel>
                               </td>
                               <td colspan="1" style="height: 23px">
                                   <dx:ASPxComboBox ID="cmbBranchDiv" runat="server" Theme="BlackGlass" ValueType="System.String" Width="250px">
                                   </dx:ASPxComboBox>
                               </td>
                               <td colspan="1" style="height: 23px"></td>
                               <td colspan="1" style="height: 23px"></td>
                               <td colspan="1" style="height: 23px"></td>
                               <td colspan="1" style="height: 23px"></td>
                           </tr>
                           <tr>
                               <td colspan="1" style="height: 23px">
                                   <dx:ASPxLabel ID="ASPxLabel51" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Account No." Theme="Glass">
                                   </dx:ASPxLabel>
                                   <dx:ASPxLabel ID="ASPxLabel93" runat="server" ForeColor="Red" Text="*">
                                   </dx:ASPxLabel>
                               </td>
                               <td colspan="1" style="height: 23px">
                                   <dx:ASPxTextBox ID="txtAccountNoDiv" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="250px">
                                   </dx:ASPxTextBox>
                               </td>
                               <td colspan="1" style="height: 23px"></td>
                               <td colspan="1" style="height: 23px"></td>
                               <td colspan="1" style="height: 23px"></td>
                               <td colspan="1" style="height: 23px"></td>
                               <td colspan="1" style="height: 23px"></td>
                               <td colspan="1" style="height: 23px"></td>
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
                   <asp:Panel ID="Panel2" runat="server" Font-Bold="True" Font-Names="Cambria" Font-Size="10pt" GroupingText="Settlement  Account Mandate" Width="785px" Visible="False">
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
                                   <dx:ASPxLabel ID="ASPxLabel85" runat="server" ForeColor="Red" Text="*">
                                   </dx:ASPxLabel>
                               </td>
                               <td colspan="1">
                                   <dx:ASPxComboBox ID="cmbBankNameCash" runat="server" AutoPostBack="True" Theme="BlackGlass" ValueType="System.String" Width="250px">
                                   </dx:ASPxComboBox>
                               </td>
                               <td colspan="1">
                                   <dx:ASPxLabel ID="ASPxLabel3" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Branch" Theme="Glass">
                                   </dx:ASPxLabel>
                                   &nbsp;<dx:ASPxLabel ID="ASPxLabel87" runat="server" ForeColor="Red" Text="*">
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
                                   <dx:ASPxLabel ID="ASPxLabel86" runat="server" ForeColor="Red" Text="*">
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
                   <asp:Panel ID="Panel16" runat="server" Font-Bold="True" Font-Names="Cambria" Font-Size="10pt" GroupingText="Mobile Money Details" Visible="False" Width="785px">
                       <table style="width: 780px; height:30px;">
                           <tr>
                               <td colspan="1" style="height: 46px; width: 98px">
                                   <dx:ASPxLabel ID="ASPxLabel76" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Mobile Money" Theme="Glass">
                                   </dx:ASPxLabel>
                                   <dx:ASPxLabel ID="ASPxLabel83" runat="server" ForeColor="Red" Text="*">
                                   </dx:ASPxLabel>
                               </td>
                               <td colspan="1" style="height: 46px; width: 249px">
                                   <dx:ASPxComboBox ID="cmbmobilemoney" runat="server" AutoPostBack="True" Theme="BlackGlass" ValueType="System.String" Width="250px">
                                   </dx:ASPxComboBox>
                               </td>
                               <td colspan="2" style="height: 46px">&nbsp;</td>
                               <td colspan="1" style="height: 46px">&nbsp;</td>
                               <td colspan="1" style="height: 46px">&nbsp;</td>
                               <td colspan="1" style="height: 46px">&nbsp;</td>
                               <td colspan="1" style="height: 46px">&nbsp;</td>
                           </tr>
                           <tr>
                               <td colspan="1" style="height: 46px; width: 98px">
                                   <dx:ASPxLabel ID="ASPxLabel75" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Mobile Number" Theme="Glass">
                                   </dx:ASPxLabel>
                                   <dx:ASPxLabel ID="ASPxLabel84" runat="server" ForeColor="Red" Text="*">
                                   </dx:ASPxLabel>
                               </td>
                               <td colspan="1" style="height: 46px; width: 249px">
                                   <dx:ASPxTextBox ID="txtmobilemonephone" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="250px">
                                    
                                   </dx:ASPxTextBox>
                               </td>
                               <td colspan="2" style="height: 46px">
                                   <dx:ASPxCheckBox ID="chkmobilemoney" runat="server" AutoPostBack="True" Text="Use Mobile Number">
                                   </dx:ASPxCheckBox>
                               </td>
                               <td colspan="1" style="height: 46px"></td>
                               <td colspan="1" style="height: 46px"></td>
                               <td colspan="1" style="height: 46px"></td>
                               <td colspan="1" style="height: 46px"></td>
                           </tr>
                           <tr>
                               <td colspan="1" style="width: 98px"></td>
                               <td colspan="1" style="width: 249px"></td>
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

        <asp:Panel ID="Panel7" runat="server" font-bold="True" font-names="Cambria" font-size="10pt" groupingtext="Empowerment Segment Declarations" width="840px">
            <table style="width: 748px; height:30px;">
                <tr>
                    <td colspan="1" style="height: 9px; width: 429px">
                        <dx1:ASPxLabel ID="ASPxLabel96" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Indigenous Zimbabwean?" Theme="Glass">
                        </dx1:ASPxLabel>
                        <dx1:ASPxLabel ID="ASPxLabel97" runat="server" ForeColor="Red" Text="*">
                        </dx1:ASPxLabel>
                    </td>
                    <td colspan="1" style="height: 9px; width: 249px"><%--                                   <asp:RadioButtonList runat="server">--%>
                        <asp:RadioButtonList ID="RadioButtonList2" runat="server" RepeatDirection="Horizontal" RepeatLayout="Table">
                            <asp:ListItem Text="Yes" Value="Yes"></asp:ListItem>
                            <asp:ListItem Text="No" Value="No"></asp:ListItem>
                        </asp:RadioButtonList>
                        <%--                                   </asp:RadioButtonList>--%><%--                                   <dx:ASPxComboBox ID="ASPxComboBox1" runat="server" AutoPostBack="True" Theme="BlackGlass" ValueType="System.String" Width="250px">--%><%--                                   </dx:ASPxComboBox>--%></td>
                    <td colspan="2" style="height: 9px"></td>
                    <td colspan="1" style="height: 9px"></td>
                    <td colspan="1" style="height: 9px"></td>
                    <td colspan="1" style="height: 9px"></td>
                    <td colspan="1" style="height: 9px"></td>
                </tr>
                <tr>
                    <td colspan="1" style="height: 20px; width: 429px">
                        <dx1:ASPxLabel ID="ASPxLabel98" runat="server" Font-Names="Cambria" Font-Size="Small" Text="State your Race" Theme="Glass">
                        </dx1:ASPxLabel>
                        <dx1:ASPxLabel ID="ASPxLabel99" runat="server" ForeColor="Red" Text="*">
                        </dx1:ASPxLabel>
                    </td>
                    <td colspan="1" style="height: 20px; width: 249px">
                        <dx1:ASPxTextBox ID="raceText0" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="250px">
                        </dx1:ASPxTextBox>
                        <asp:RequiredFieldValidator ID="req_Pwd4" runat="server" ControlToValidate="racetext0" Display="None" ErrorMessage="State your Race" ValidationGroup="Submit"></asp:RequiredFieldValidator>
                    </td>
                    <td colspan="2" style="height: 20px"><%--                                   <dx:ASPxCheckBox ID="ASPxCheckBox1" runat="server" AutoPostBack="True" Text="Use Mobile Number">--%><%--                                   </dx:ASPxCheckBox>--%></td>
                    <td colspan="1" style="height: 20px"></td>
                    <td colspan="1" style="height: 20px"></td>
                    <td colspan="1" style="height: 20px"></td>
                    <td colspan="1" style="height: 20px"></td>
                </tr>
                <tr>
                    <td colspan="1" style="height: 18px; width: 429px">
                        <dx1:ASPxLabel ID="ASPxLabel100" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Was your race previously disadvantaged?" Theme="Glass">
                        </dx1:ASPxLabel>
                        <dx1:ASPxLabel ID="ASPxLabel101" runat="server" ForeColor="Red" Text="*">
                        </dx1:ASPxLabel>
                    </td>
                    <td colspan="1" style="height: 18px; width: 249px">
                        <asp:RadioButtonList ID="dis" runat="server" RepeatDirection="Horizontal" RepeatLayout="Table">
                            <asp:ListItem Text="Yes" Value="Yes"></asp:ListItem>
                            <asp:ListItem Text="No" Value="No"></asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                    <td colspan="2" style="height: 18px"><%--                                   <dx:ASPxCheckBox ID="ASPxCheckBox2" runat="server" AutoPostBack="True" Text="Use Mobile Number">--%><%--                                   </dx:ASPxCheckBox>--%></td>
                    <td colspan="1" style="height: 18px"></td>
                    <td colspan="1" style="height: 18px"></td>
                    <td colspan="1" style="height: 18px"></td>
                    <td colspan="1" style="height: 18px"></td>
                </tr>
                <tr>
                    <td colspan="1" style="height: 4px; width: 429px">
                        <dx1:ASPxLabel ID="ASPxLabel102" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Nationality By?" Theme="Glass">
                        </dx1:ASPxLabel>
                        <dx1:ASPxLabel ID="ASPxLabel103" runat="server" ForeColor="Red" Text="*">
                        </dx1:ASPxLabel>
                    </td>
                    <td colspan="7" style="height: 4px; ">
                        <asp:RadioButtonList ID="natBy" runat="server" RepeatDirection="Horizontal" RepeatLayout="Table">
                            <asp:ListItem Text="Birth" Value="Birth"></asp:ListItem>
                            <asp:ListItem Text="Descendancy" Value="Descendancy"></asp:ListItem>
                            <asp:ListItem Text="Adoption" Value="Adoption"></asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                </tr>
                <tr>
                    <td colspan="1" style="width: 429px"></td>
                    <td colspan="1" style="width: 249px">
                        &nbsp;</td>
                    <td colspan="1"></td>
                    <td colspan="1"></td>
                    <td colspan="1"></td>
                    <td colspan="1"></td>
                    <td colspan="1"></td>
                    <td colspan="1"></td>
                </tr>
            </table>
        </asp:Panel>

      <asp:Panel runat="server" ID="panelSave" Font-Names="Cambria" GroupingText="Attachments" Visible="False">
         <table width="100%">
             <tr>
                    <td colspan ="8">
                        &nbsp;</td>

             </tr>
             <tr>                 
                 <td colspan ="1">
                     &nbsp;</td>
                 <td colspan ="1"></td>
                 <td colspan ="1">
                     &nbsp;</td>
                 <td colspan ="1">
                     &nbsp;</td>
                 <td colspan ="1">
                     &nbsp;</td>
                 <td colspan ="1">
                     &nbsp;</td>
                 <td colspan ="1"></td>
                 <td colspan ="1"></td>

             </tr>
              <tr>                 
                 <td colspan ="1">
                     &nbsp;</td>
                 <td colspan ="1"></td>
                 <td colspan ="1">
                     &nbsp;</td>
                 <td colspan ="1">
                     &nbsp;</td>
                 <td align="right" colspan ="1">
                     <dx:ASPxLabel ID="ASPxLabel70" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Document Name" Theme="Glass">
                     </dx:ASPxLabel>
                  </td>
                 <td colspan ="1">
                     <dx:ASPxComboBox ID="txtdocumentname" runat="server" AnimationType="Slide" AutoPostBack="True" CallbackPageSize="15" DropDownStyle="DropDownList" EnableCallbackMode="True" IncrementalFilteringMode="Contains" Theme="BlackGlass" ValueType="System.String" Width="250px">
                     </dx:ASPxComboBox>
                  </td>
                 <td colspan ="1"></td>
                 <td colspan ="1"></td>

             </tr>
              <tr>                 
                 <td colspan ="1">
                     &nbsp;</td>
                 <td colspan ="1"></td>
                 <td colspan ="1">
                     &nbsp;</td>
                 <td colspan ="1">
                     &nbsp;</td>
                 <td colspan align="right" ="1">
                     <dx:ASPxLabel ID="ASPxLabel74" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Select Document" Theme="Glass">
                     </dx:ASPxLabel>
                  </td>
                 <td colspan ="1">
                     <asp:FileUpload ID="FileUpload1" runat="server" />
                  </td>
                 <td colspan ="1"></td>
                 <td colspan ="1"></td>

             </tr>
                <tr>
                    <td colspan="1">&nbsp;</td>
                    <td colspan="1">&nbsp;</td>
                    <td colspan="1">&nbsp;</td>
                    <td colspan="1">&nbsp;</td>
                    <td ="1"="" align="right" colspan="">&nbsp;</td>
                    <td colspan="1">
                        <dx:ASPxButton ID="ASPxButton10" runat="server" Text="Upload" Theme="BlackGlass">
                        </dx:ASPxButton>
                    </td>
                    <td colspan="1">&nbsp;</td>
                    <td colspan="1">&nbsp;</td>
             </tr>
                <tr>
                        <td colspan ="8" align ="center" style="height: 24px">
                            <dx:ASPxGridView ID="ASPxGridView1" runat="server" Theme="BlackGlass" Width="470px">
                            </dx:ASPxGridView>
                        </td>

                </tr>
             <tr>
                    <td colspan ="8" align ="center">
                        &nbsp;</td>
             </tr>
             <tr>
                    <td colspan ="8" align ="center">  
                         <dx:ASPxLoadingPanel ID="LoadingPanel" runat="server" ClientInstanceName="LoadingPanel"
        Modal="True">
    </dx:ASPxLoadingPanel>
                    </td>

             </tr>

         </table>

     </asp:Panel>  
        <asp:Panel runat="server" ID="panelsaving" GroupingText=".">
            <table style="width: 832px">
                    <tr>
                            <td colspan ="8" align="center" style="height: 16px">
                                &nbsp;</td>


                    </tr>
                <tr>
                        <td colspan ="8" align ="center">
                            <dx:ASPxButton ID="ASPxButton5" runat="server" Text="save" Theme="BlackGlass" Visible="False">
                            </dx:ASPxButton>
                            &nbsp;<dx:ASPxButton ID="ASPxButton9" runat="server" Text="Add Holders" Theme="BlackGlass" Visible="False">
                            </dx:ASPxButton>
                        </td>

                </tr>

            </table>
        </asp:Panel>  
                 
        <asp:Panel ID="panelsaving0" runat="server" GroupingText="Joint Account Holders" Visible="False">
            <table>
                <tr>
                    <td align="center" colspan="8" style="height: 17px; width: 812px;">
                        <asp:Panel ID="Panel14" runat="server" Font-Names="Cambria" GroupingText="Details" style="height: 176px">
                            <table width="810px">
                                <tr>
                                    <td align="center" colspan="9">
                                        <asp:Label ID="Label2" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" colspan="1">
                                        <dx:ASPxLabel ID="lblJSurname0" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Surname" Theme="Glass">
                                        </dx:ASPxLabel>
                                    </td>
                                    <td align="left" colspan="8">
                                        <dx:ASPxTextBox ID="txtJsurname0" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="710px">
                                        </dx:ASPxTextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" colspan="1">
                                        <dx:ASPxLabel ID="lblJforenames0" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Forenames" Theme="Glass">
                                        </dx:ASPxLabel>
                                    </td>
                                    <td align="left" colspan="8">
                                        <dx:ASPxTextBox ID="txtJforenames0" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="710px">
                                        </dx:ASPxTextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" colspan="1">
                                        <dx:ASPxLabel ID="lblJforenames1" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Email" Theme="Glass">
                                        </dx:ASPxLabel>
                                    </td>
                                    <td align="left" colspan="8">
                                        <dx:ASPxTextBox ID="txtJemail1" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="710px">
                                        </dx:ASPxTextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" colspan="1">
                                        <dx:ASPxLabel ID="LBLJIDTYPE0" runat="server" Font-Names="Cambria" Font-Size="Small" Text="ID Type" Theme="Glass">
                                        </dx:ASPxLabel>
                                    </td>
                                    <td align="left" >
                                        <dx:ASPxComboBox ID="cmbJIDType0" runat="server" Theme="BlackGlass" Width="200px">
                                        </dx:ASPxComboBox>
                                    </td>
                                    <td>&nbsp;</td>
                                    <td align="left" colspan="1">
                                        <dx:ASPxLabel ID="lblJID0" runat="server" Font-Names="Cambria" Font-Size="Small" Text="ID No" Theme="Glass">
                                        </dx:ASPxLabel>
                                    </td>
                                    <td align="left" colspan="1">
                                        <dx:ASPxTextBox ID="TXTjiD3" runat="server" BackColor="#E4E4E4" Height="16px" Theme="BlackGlass" Width="244px">
                                        </dx:ASPxTextBox>
                                    </td>
                                    <td colspan="1"></td>
                                    <td colspan="1"></td>
                                    <td colspan="1"></td>
                                    <td colspan="1"></td>
                                </tr>
                                <tr>
                                    <td align="left" colspan="1">
                                        <dx:ASPxLabel ID="lblJnationality0" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Country" Theme="Glass">
                                        </dx:ASPxLabel>
                                    </td>
                                    <td align="left" colspan="2">
                                        <dx:ASPxComboBox ID="cmbJnationality0" runat="server" Theme="BlackGlass" ValueType="System.String" Width="250px">
                                        </dx:ASPxComboBox>
                                    </td>
                                    <td colspan="1"></td>
                                    <td colspan="1">&nbsp;</td>
                                    <td colspan="1"></td>
                                    <td colspan="1"></td>
                                    <td colspan="1"></td>
                                    <td colspan="1"></td>
                                </tr>
                                <tr>
                                    <td align="left" colspan="1">
                                        <dx:ASPxLabel ID="lblJdob0" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Date Of Birth" Theme="Glass">
                                        </dx:ASPxLabel>
                                    </td>
                                    <td align="left" colspan="2">
                                        <dx:ASPxDateEdit ID="txtJdob0" runat="server" AutoPostBack="True" DisplayFormatString="dd/MMMM/yyyy" EditFormat="Custom" EditFormatString="dd/MMMM/yyyy" Theme="BlackGlass" Width="250px">
                                        </dx:ASPxDateEdit>
                                    </td>
                                    <td align="left" colspan="1">
                                        <dx:ASPxLabel ID="lbljGender0" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Gender" Theme="Glass">
                                        </dx:ASPxLabel>
                                    </td>
                                    <td align="left" colspan="1">
                                        <asp:RadioButton ID="rdJmale0" runat="server" AutoPostBack="True" GroupName="Gender2" Text="Male" />
                                        <asp:RadioButton ID="rdJfemale0" runat="server" AutoPostBack="True" GroupName="Gender2" Text="Female" />
                                        <asp:RadioButton ID="rdJNa0" runat="server" AutoPostBack="True" GroupName="Gender2" Text="N/A" />
                                    </td>
                                    <td colspan="1"></td>
                                    <td colspan="1"></td>
                                    <td colspan="1"></td>
                                    <td colspan="1"></td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </td>
                </tr>
                <tr>
                    <td align="center" colspan="8" style="width: 812px">
                        <br />
                        <dx:ASPxButton ID="btnJadd2" runat="server" Text="Add" Theme="BlackGlass">
                        </dx:ASPxButton>
                        <br />
                        <dx:ASPxGridView ID="grdJointAccounts" runat="server" Theme="Aqua" Width="600px">
                        </dx:ASPxGridView>
                        <br />
                        <dx:ASPxButton ID="btnJadd3" runat="server" Text="Done" Theme="BlackGlass">
                        </dx:ASPxButton>
                        <br />
                    </td>
                </tr>
            </table>
        </asp:Panel>
                 
</asp:Panel>
  
</div>
</asp:Content>

