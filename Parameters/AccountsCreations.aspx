<%@ Page Language="VB" MasterPageFile="~/CDSUser.master" AutoEventWireup="false" CodeFile="AccountsCreations.aspx.vb" Inherits="TransferSec_AccountsCreations" title="Accounts Creation" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<%@ Register assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxUploadControl" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxLoadingPanel" tagprefix="dx" %>
<asp:Content id="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Panel id="Panel1" runat="server" Width="100%" Font-Names="Cambria" BackColor="White" GroupingText="Accounts Creation">
       <table>
           <tr id="Panel10g" runat="server">
                <td style="width: 208px">
                    <dx:ASPxLabel ID="ASPxLabel1" runat="server" Font-Names="Cambria" Font-Size="Small" Font-Bold="true" Text="Account Type" Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                <td style="font-family:Cambria; font-size:small" colspan="2">
                    <asp:RadioButton ID="rdIndividual" runat="server" AutoPostBack="True" GroupName="AccountType" Text="Individual" />
                    <asp:RadioButton ID="rdJoint" runat="server" AutoPostBack="True" GroupName="AccountType" Text="Joint" />
                    <asp:RadioButton ID="rdCorprate" runat="server" AutoPostBack="True" GroupName="AccountType" Text="Corporate/Pension Fund" />
                </td>
            </tr> 
           <tr id="Panel0a" runat="server" visible="false">
                <td colspan="4">
                    <dx:ASPxLabel ID="ASPxLabel110" runat="server" Font-Names="Cambria" Font-Size="Small" Font-Bold="true" Text="Identification Verification" Theme="Glass">
                    </dx:ASPxLabel>
                   <hr/>
                </td>
            </tr>
           <tr id="Panel13a" runat="server">
                      <td style="width: 208px">
                          <dx:ASPxLabel ID="ASPxLabel31" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Identification Type" Theme="Glass">
                          </dx:ASPxLabel>
                      </td>
                      <td style="width: 212px">
                          <dx:ASPxComboBox ID="cmbIDType" runat="server" Theme="BlackGlass" Width="250px"  CallbackPageSize="15" EnableCallbackMode="True" DropDownStyle="DropDownList"  IncrementalFilteringMode="Contains"  AnimationType="Slide" AutoPostBack="False">
                          </dx:ASPxComboBox>
                      </td>
                      <td style="width: 208px">
                          <dx:ASPxLabel ID="ASPxLabel30" runat="server" Font-Names="Cambria" Font-Size="Small" Text="National ID No./Passport No." Theme="Glass">
                          </dx:ASPxLabel>
                      </td>
                      <td style="width: 212px">
                          <dx:ASPxTextBox ID="txtIDNo" runat="server" BackColor="White" MaxLength="50" Theme="Glass" Width="250px">
                          </dx:ASPxTextBox>
                      </td>
                  </tr>
           <tr id="Panel13d" runat="server">
                      <td style="width: 208px"></td>
                      <td style="width: 212px"></td>
                      <td style="width: 208px"></td>
                      <td style="width: 212px">
                          <dx:ASPxButton ID="btnJadd0" runat="server" Text="Validate Identification Details" Theme="BlackGlass" Width="250px">
                          </dx:ASPxButton>
                      </td>
                  </tr>
           <tr id="Panel15a" runat="server" visible="false">
                <td colspan="4">
                    <dx:ASPxLabel ID="ASPxLabel119" runat="server" Font-Names="Cambria" Font-Size="Small" Font-Bold="true" Text="Joint Account Details" Theme="Glass">
                    </dx:ASPxLabel>
                   <hr/>
                </td>
            </tr>
           <tr id="Panel15b" runat="server" visible="false">
                    <td style="width: 208px">
                        <dx:ASPxLabel ID="ASPxLabel72" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Joint Name" Theme="Glass">
                        </dx:ASPxLabel>
                        <dx:ASPxLabel ID="ASPxLabel73" runat="server" ForeColor="Red" Text="*">
                        </dx:ASPxLabel>
                    </td>
                    <td style="width: 212px">
                        <dx:ASPxTextBox ID="txtSurname0" runat="server" BackColor="White" Theme="Glass" Width="250px">
                        </dx:ASPxTextBox>
                    </td>
               <td style="width: 208px"></td>
               <td style="width: 212px"></td>
           </tr>
           <tr id="Panel15d" runat="server" visible="false">
               <td style="width: 208px"></td>     
               <td style="width: 212px">
                        <dx:ASPxButton ID="btnJadd4" runat="server" Height="22px" Text="Validate Joint Account Name" ValidationGroup="vakp" Theme="BlackGlass" Width="201px">
                        </dx:ASPxButton>
                    </td>
           </tr>
           <tr id="Panel8a" runat="server" visible="false">
                <td colspan="4">
                    <dx:ASPxLabel ID="ASPxLabel117" runat="server" Font-Names="Cambria" Font-Size="Small" Font-Bold="true" Text="Personal Details" Theme="Glass">
                    </dx:ASPxLabel>
                   <hr/>
                </td>
            </tr>
           <tr id="Panel8b" runat="server" visible="false">
                    <td style="width: 208px">
                        <dx:ASPxLabel ID="ASPxLabel29" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Title" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td style="width: 212px">
                        <dx:ASPxComboBox ID="cmbTitle" runat="server" Theme="BlackGlass" CallbackPageSize="15" EnableCallbackMode="True" DropDownStyle="DropDownList"  IncrementalFilteringMode="Contains" Width="250px"  AnimationType="Slide">
                            <Items>
                                <dx:ListEditItem Text="Mr." Value="Mr." />
                                <dx:ListEditItem Text="Mrs." Value="Mrs." />
                                <dx:ListEditItem Text="Miss." Value="Miss" />
                                <dx:ListEditItem Text="Ms." Value="Ms." />
                                <dx:ListEditItem Text="Sir." Value="Sir." />
                                <dx:ListEditItem Text="Esq." Value="Esq." />
                                <dx:ListEditItem Text="Rev." Value="Rev." />
                                <dx:ListEditItem Text="Dr." Value="Dr." />
                                <dx:ListEditItem Text="Prof." Value="Prof." />
                            </Items>
                        </dx:ASPxComboBox>
                    </td>
                    <td style="width: 208px">
                        <dx:ASPxLabel ID="ASPxLabel138" runat="server" Font-Names="Cambria" Font-Size="Small" Text="National ID No." Theme="Glass">
                        </dx:ASPxLabel>
                        <dx:ASPxLabel ID="ASPxLabel3" runat="server" ForeColor="Red" Text="*">
                        </dx:ASPxLabel>
                    </td>
                    <td style="width: 212px">
                        <dx:ASPxTextBox ID="txtCNIC" runat="server" BackColor="White" Theme="BlackGlass" Width="250px">
                        </dx:ASPxTextBox>
                    </td>
                </tr>
           <tr id="Panel8d" runat="server" visible="false">
                    <td style="width: 208px">
                        <dx:ASPxLabel ID="ASPxLabel5" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Forenames" Theme="Glass">
                        </dx:ASPxLabel>
                        <dx:ASPxLabel ID="ASPxLabel63" runat="server" ForeColor="Red" Text="*">
                        </dx:ASPxLabel>
                    </td>
                    <td style="width: 212px">
                        <dx:ASPxTextBox ID="txtOthernames" runat="server" BackColor="White" Theme="Glass" Width="250px">
                        </dx:ASPxTextBox>
                        <asp:RequiredFieldValidator ID="req_Pwd0" runat="server" ControlToValidate="txtOthernames" Display="None" ErrorMessage="First Name is Required" ValidationGroup="Submit"></asp:RequiredFieldValidator>
                    </td>
                    <td style="width: 208px">
                        <dx:ASPxLabel ID="ASPxLabel26" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Surname" Theme="Glass">
                        </dx:ASPxLabel>
                        <dx:ASPxLabel ID="ASPxLabel56" runat="server" ForeColor="Red" Text="*">
                        </dx:ASPxLabel>
                    </td>
                    <td style="width: 212px">
                        <dx:ASPxTextBox ID="txtSurname" runat="server" BackColor="White" Width="250px">
                        </dx:ASPxTextBox>
                        <asp:RequiredFieldValidator ID="req_Pwd" runat="server" ControlToValidate="txtsurname" Display="None" ErrorMessage="Surname Required" ValidationGroup="Submit"></asp:RequiredFieldValidator>
                    </td>
                </tr>
           <tr id="Panel8l" runat="server" visible="false">
                    <td style="width: 208px">
                        <dx:ASPxLabel ID="ASPxLabel32" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Date Of Birth" Theme="Glass">
                        </dx:ASPxLabel>
                        <dx:ASPxLabel ID="ASPxLabel79" runat="server" ForeColor="Red" Text="*">
                        </dx:ASPxLabel>
                    </td>
                    <td style="width: 212px">
                        <dx:ASPxDateEdit ID="txtDOB" runat="server" EditFormat="Custom" EditFormatString="dd MMMM yyyy" Theme="BlackGlass" Width="250px">
                        </dx:ASPxDateEdit>
                    </td>
                    <td style="width: 208px">
                        <dx:ASPxLabel ID="ASPxLabel33" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Gender" Theme="Glass">
                        </dx:ASPxLabel>
                        <dx:ASPxLabel ID="ASPxLabel82" runat="server" ForeColor="Red" Text="*">
                        </dx:ASPxLabel>
                    </td>
                    <td style="width: 212px; font-family:Cambria; font-size:small">
                        <asp:RadioButton ID="rdMale" runat="server" AutoPostBack="False" GroupName="Gender" Text="Male" />
                        <asp:RadioButton ID="rdFemale" runat="server" AutoPostBack="False" GroupName="Gender" Text="Female" />
                        <asp:RadioButton ID="rdNa" runat="server" AutoPostBack="False" GroupName="Gender" Text="N/A" />
                    </td>
                </tr>
           <tr id="Panel8f" runat="server" visible="false">
                    <td style="width: 208px">
                        <dx:ASPxLabel ID="ASPxLabel27" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Type of Account" Theme="Glass">
                        </dx:ASPxLabel>
                        <dx:ASPxLabel ID="ASPxLabel28" runat="server" ForeColor="Red" Text="*">
                        </dx:ASPxLabel>
                    </td>
                    <td style="width: 212px">
                        <dx:ASPxComboBox ID="cmbTypeofAccount" runat="server" Theme="BlackGlass" ValueType="System.String" Width="250px" CallbackPageSize="15" EnableCallbackMode="True" DropDownStyle="DropDownList"  IncrementalFilteringMode="Contains"  AnimationType="Slide">
                            <Items>
                                <dx:ListEditItem Text="Custody" Value="Custody" />
                                <dx:ListEditItem Text="Trustee" Value="Trustee" />
                            </Items>
                        </dx:ASPxComboBox>
                    </td>
                </tr>
           <tr id="Panel8k" runat="server" visible="false">
                    <td style="width: 208px">
                        <dx:ASPxLabel ID="ASPxLabel44" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Nationality" Theme="Glass">
                        </dx:ASPxLabel>
                        <dx:ASPxLabel ID="ASPxLabel81" runat="server" ForeColor="Red" Text="*">
                        </dx:ASPxLabel>
                    </td>
                    <td style="width: 212px">
                        <dx:ASPxComboBox ID="cmbNationality" runat="server" Theme="BlackGlass" ValueType="System.String" Width="250px" CallbackPageSize="15" EnableCallbackMode="True" DropDownStyle="DropDownList"  IncrementalFilteringMode="Contains"  AnimationType="Slide">
                        </dx:ASPxComboBox>
                    </td>
                    <td style="width: 208px">
                        <dx:ASPxLabel ID="ASPxLabel1318" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Passport No." Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td style="width: 212px">
                    <dx:ASPxTextBox ID="txtpassport" runat="server" BackColor="White" Theme="BlackGlass" Width="250px">
                    </dx:ASPxTextBox>
                    </td>
                </tr>
            <tr id="Panel3bb" runat="server" visible="false">
                <td colspan="4">
                    <dx:ASPxLabel ID="ASPxLabel9" runat="server" Font-Names="Cambria" Font-Size="Small" Font-Bold="true" Text="Asset Manager/s" Theme="Glass">
                    </dx:ASPxLabel>
                   <hr/>
                </td>
            </tr>
           <tr id="Panel3bbb" runat="server" visible="false">
                <td style="width: 208px">
                    <dx:ASPxLabel ID="ASPxLabel39" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Asset Manager" Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                <td style="width: 212px">
                    <dx:ASPxComboBox ID="cmbAssetManager" AutoPostBack="true" runat="server" Theme="BlackGlass" ValueType="System.String" Width="250px" CallbackPageSize="15" EnableCallbackMode="True" DropDownStyle="DropDownList"  IncrementalFilteringMode="Contains"  AnimationType="Slide">
                    </dx:ASPxComboBox>
                </td>
             <td colspan="2">
          <asp:Panel ID="dfPanel2" runat="server" ScrollBars="Vertical" Visible="false">
            <asp:Repeater ID="grdSelectFromAssetmanagers" runat="server">
                <HeaderTemplate>
                   <table style="margin-left: 10px; font-family:Cambria; font-size:small;" id="table_example2">
                       <thead>
                            <tr>
                                <th style="width:100px">
                                    <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                                </th>
                                <th align="left" style="width:100px">
                                    <asp:Label ID="Label5" runat="server" Text="Bank"></asp:Label>
                                </th>
                                <th align="left" style="width:100px">
                                    <asp:Label ID="Label7" runat="server" Text="Branch"></asp:Label>
                                </th>
                                <th align="left" style="width:100px">
                                    <asp:Label ID="Label2" runat="server" Text="AccountNo"></asp:Label>
                                </th>
                                <th id="Th1" runat="server" visible="false">
                                </th>
                            </tr>
                        </thead>
                        <tbody>
                    </HeaderTemplate>
                    <ItemTemplate>
                            <tr>
                                <td>
                                   <asp:CheckBox ID="chkSelect" runat="server"/>
                                </td>
                                <td>
                                    <asp:Label ID="lblBank" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Bank")%>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblBranch" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Branch")%>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblAccountNumber" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "AccountNo")%>'></asp:Label>
                                </td>
                                <td id="tbHide" runat="server" visible="false">
                                     <asp:Label ID="lblAssetManagerCode" runat="server" Text='<%# Eval("AssetManagerCode") %>' Visible="false"></asp:Label>
                                </td>
                            </tr>
                    </ItemTemplate>
                    <FooterTemplate>
                        </tbody>
                        </table>
                    </FooterTemplate>
                </asp:Repeater>
           </asp:Panel>
               </td>
           </tr>
           
           <tr id="Panel3bbbbx" runat="server" visible="false">
                    <td style="width:208px">
                        <dx:ASPxLabel ID="ASPxLabel1319" runat="server" Font-Names="Cambria" Font-Size="Small" Text="CDC Number" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                        <td colspan="3">
                            <dx:ASPxTextBox ID="txtcdcnumber" runat="server" BackColor="White" Theme="BlackGlass" Width="250px">
                            </dx:ASPxTextBox>
                        </td>
                </tr> 
           <tr id="Panel3bbbb2" runat="server" visible="false">
               <td style="width:208px">&nbsp;</td>
               <td colspan="3">
                   <dx:ASPxButton ID="btnAddAMs" runat="server" Text="Add" Theme="BlackGlass" ValidationGroup="addams">
                   </dx:ASPxButton>
               </td>
           </tr>
           <tr id="Panel3bbbb" runat="server" visible="false">
               <td style="width:208px">
               </td>
               <td colspan="3">
                   <dx:ASPxGridView ID="grdAsertManagersClients" runat="server" KeyFieldName="ID" Theme="Glass" Width="470px">
                       <Columns>
                           <dx:GridViewDataColumn Visible="false" VisibleIndex="0">
                               <DataItemTemplate>
                                   <asp:LinkButton ID="SelectID" runat="server" CommandArgument='<%# Eval("ID") %>' CommandName="Delete" OnClientClick="if ( !confirm('Are you sure you want to delete ? ')) return false;" Text="Delete">
                                        </asp:LinkButton>
                               </DataItemTemplate>
                           </dx:GridViewDataColumn>
                           <dx:GridViewDataColumn Caption="ID" HeaderStyle-Font-Bold="true">
                               <DataItemTemplate>
                                   <dx:ASPxLabel runat="server" Text='<%# Eval("ID") %>'>
                                   </dx:ASPxLabel>
                               </DataItemTemplate>
                           </dx:GridViewDataColumn>
                           <dx:GridViewDataColumn Caption="AssetManager" HeaderStyle-Font-Bold="true">
                               <DataItemTemplate>
                                   <dx:ASPxLabel runat="server" Text='<%# Eval("AssetManager") %>'>
                                   </dx:ASPxLabel>
                               </DataItemTemplate>
                           </dx:GridViewDataColumn>
                           <dx:GridViewDataColumn Caption="Bank" HeaderStyle-Font-Bold="true">
                               <DataItemTemplate>
                                   <dx:ASPxLabel runat="server" Text='<%# Eval("BankName") %>'>
                                   </dx:ASPxLabel>
                               </DataItemTemplate>
                           </dx:GridViewDataColumn>
                           <dx:GridViewDataColumn Caption="Branch" HeaderStyle-Font-Bold="true">
                               <DataItemTemplate>
                                   <dx:ASPxLabel runat="server" Text='<%# Eval("BankBranch") %>'>
                                   </dx:ASPxLabel>
                               </DataItemTemplate>
                           </dx:GridViewDataColumn>
                           <dx:GridViewDataColumn Caption="Account" HeaderStyle-Font-Bold="true">
                               <DataItemTemplate>
                                   <dx:ASPxLabel runat="server" Text='<%# Eval("BankAccount") %>'>
                                   </dx:ASPxLabel>
                               </DataItemTemplate>
                           </dx:GridViewDataColumn>

                              <dx:GridViewDataColumn Caption="CDC Number" HeaderStyle-Font-Bold="true">
                               <DataItemTemplate>
                                   <dx:ASPxLabel runat="server" Text='<%# Eval("cdcnumber") %>'>
                                   </dx:ASPxLabel>
                               </DataItemTemplate>
                           </dx:GridViewDataColumn>

                       </Columns>
                   </dx:ASPxGridView>
               </td>
           </tr>
           <tr id="Panel3bbbbc" runat="server" visible="false">
               <td style="width:208px">&nbsp;</td>
               <td colspan="3">&nbsp;</td>
           </tr>
           <tr id="Panel3a" runat="server" visible="false">
                <td colspan="4">
                    <dx:ASPxLabel ID="ASPxLabel121" runat="server" Font-Names="Cambria" Font-Size="Small" Font-Bold="true" Text="Contact Details" Theme="Glass">
                    </dx:ASPxLabel>
                   <hr/>
                </td>
            </tr>
           <tr id="Panel8i" runat="server" visible="false">
                    <td style="width: 208px">
                        <dx:ASPxLabel ID="ASPxLabel54" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Country of Domicile" Theme="Glass">
                        </dx:ASPxLabel>
                   <dx:ASPxLabel ID="ASPxLabel22" runat="server" ForeColor="Red" Text="*">
                   </dx:ASPxLabel>
                    </td>
                <td style="width: 212px">
                    <dx:ASPxComboBox ID="cmbCountry" AutoPostBack="false" runat="server" Theme="BlackGlass" ValueType="System.String" Width="250px" CallbackPageSize="15" EnableCallbackMode="True" DropDownStyle="DropDownList"  IncrementalFilteringMode="Contains"  AnimationType="Slide">
                    </dx:ASPxComboBox>
                    </td>
                    <td style="width: 208px">
                        <dx:ASPxLabel ID="ASPxLabel714" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Source of Income" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td style="width: 212px">
                        <dx:ASPxTextBox ID="txtsourceofIncome" runat="server" BackColor="White" Theme="BlackGlass" Width="250px">
                        </dx:ASPxTextBox>
                    </td>
                </tr>
           <tr id="Panel3b" runat="server" visible="false">
               <td style="width: 208px">
                   <dx:ASPxLabel ID="ASPxLabel6" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Address" Theme="Glass">
                   </dx:ASPxLabel>
                   <dx:ASPxLabel ID="ASPxLabel58" runat="server" ForeColor="Red" Text="*">
                   </dx:ASPxLabel>
               </td>
               <td style="width: 212px">
                   <dx:ASPxTextBox ID="txtAddress1" runat="server" BackColor="White" Theme="BlackGlass" Width="250px">
                   </dx:ASPxTextBox>
                   <asp:RequiredFieldValidator ID="req_Pwd2" runat="server" ControlToValidate="txtaddress1" Display="None" ErrorMessage="address Required" ValidationGroup="Submit"></asp:RequiredFieldValidator>
               </td>
                <td style="width: 208px">
                    <dx:ASPxLabel ID="ASPxLabel8" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Telephone" Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                <td style="width: 212px">
                    <dx:ASPxTextBox ID="txtTel" runat="server" BackColor="White" Theme="BlackGlass" Width="250px">
                    </dx:ASPxTextBox>
                </td>
           </tr>
           <tr id="Panel3l" runat="server" visible="false">
                <td style="width: 208px">
                    <dx:ASPxLabel ID="ASPxLabel118" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Fax" Theme="Glass">
                    </dx:ASPxLabel>
                </td>
            <td style="width: 212px">
                <dx:ASPxTextBox ID="txtFax" runat="server" BackColor="White" Theme="BlackGlass" Width="250px">
                </dx:ASPxTextBox>
                </td>
                <td style="width:208px">
                    <dx:ASPxLabel ID="ASPxLabel10" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Email Address" Theme="Glass">
                    </dx:ASPxLabel>
                    <dx:ASPxLabel ID="ASPxLabel78" runat="server" ForeColor="Red" Text="*">
                    </dx:ASPxLabel>
                </td>
                <td style="width:212px">
                    <dx:ASPxTextBox ID="txtEmail" runat="server" BackColor="White" Theme="BlackGlass" Width="250px">
		                  <ValidationSettings ErrorText="Invalid Email" SetFocusOnError="True">
                            <RegularExpression ErrorText="Invalid Email" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" />
                            <RequiredField IsRequired="True" />
                        </ValidationSettings>
                    </dx:ASPxTextBox>
                </td>
            </tr>
           <tr id="Panel4a" runat="server" visible="false">
                <td colspan="4">
                    <dx:ASPxLabel ID="ASPxLabel127" runat="server" Font-Names="Cambria" Font-Size="Small" Font-Bold="true" Text="Banking Details" Theme="Glass">
                    </dx:ASPxLabel>
                   <hr/>
                </td>
            </tr>
           <tr id="Panel4b" runat="server" visible="false">
                <td style="width:208px">
                    <dx:ASPxLabel ID="ASPxLabel62" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Account Name" Theme="Glass">
                    </dx:ASPxLabel>
                    <dx:ASPxLabel ID="b_ASPxLabel37" runat="server" ForeColor="Red" Text="*">
                    </dx:ASPxLabel>
                </td>
                <td style="width:212px">
                    <dx:ASPxTextBox ID="txtPayee2" runat="server" BackColor="White" Theme="BlackGlass" Width="250px">
                    </dx:ASPxTextBox>
                </td>
                <td style="width:208px">
                    <dx:ASPxLabel ID="ASPxLabel20" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Account No." Theme="Glass">
                    </dx:ASPxLabel>
                    <dx:ASPxLabel ID="b_ASPxLabel40" runat="server" ForeColor="Red" Text="*">
                    </dx:ASPxLabel>
                </td>
                <td style="width:212px">
                    <dx:ASPxTextBox ID="txtIBAN" runat="server" BackColor="White" Theme="BlackGlass" Width="250px">
                    </dx:ASPxTextBox>
                </td>
            </tr>
           <tr id="Panel4c" runat="server" visible="false">
                <td style="width:208px">
                    <dx:ASPxLabel ID="ASPxLabel49" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Bank Name" Theme="Glass">
                    </dx:ASPxLabel>
                    <dx:ASPxLabel ID="b_ASPxLabel38" runat="server" ForeColor="Red" Text="*">
                    </dx:ASPxLabel>
                </td>
                <td style="width:212px">
                    <dx:ASPxComboBox ID="cmbBankDiv" runat="server" AutoPostBack="False" Theme="BlackGlass" ValueType="System.String" Width="250px" CallbackPageSize="15" EnableCallbackMode="True" DropDownStyle="DropDownList"  IncrementalFilteringMode="Contains"  AnimationType="Slide">
                    </dx:ASPxComboBox>
                </td>
                <td style="width:208px">
                    <dx:ASPxLabel ID="ASPxLabel50" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Branch" Theme="Glass">
                    </dx:ASPxLabel>
                    <dx:ASPxLabel ID="b_ASPxLabel39" runat="server" ForeColor="Red" Text="*">
                    </dx:ASPxLabel>
                </td>
                <td style="width:212px">
                    <dx:ASPxTextBox ID="txtBranchDiv" runat="server" BackColor="White" Theme="BlackGlass" Width="250px">
                    </dx:ASPxTextBox>
                </td>
            </tr>
           <tr id="Panel4d" runat="server" visible="false">
                <td style="width:208px">
                    <dx:ASPxLabel ID="ASPxLabel2" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Swift Code (if foreign)" Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                <td style="width:212px">
                    <dx:ASPxTextBox ID="txtSwiftCode" runat="server" BackColor="White" Theme="BlackGlass" Width="250px">
                    </dx:ASPxTextBox>
                </td>
                <td style="width:208px">
                    <dx:ASPxLabel ID="ASPxLabel51" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Bank Address(if foreign)" Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                <td style="width:212px">
                    <dx:ASPxTextBox ID="txtbankAddress" runat="server" BackColor="White" Theme="BlackGlass" Width="250px">
                    </dx:ASPxTextBox>
                </td>
            </tr>
           <tr id="Panel4e" runat="server" visible="false">
                <td style="width:208px">
                    <dx:ASPxLabel ID="ASPxLabel23" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Date/Time stamp" Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                <td style="width:212px">
                    <dx:ASPxTextBox ID="txtDateTimeStamp" runat="server" BackColor="White" Theme="BlackGlass" Width="250px">
                    </dx:ASPxTextBox>
                </td>
            </tr>

           <tr id="panelSave1" runat="server" visible="false">
                <td colspan="4">
                    <dx:ASPxLabel ID="ASPxLabel52" runat="server" Font-Names="Cambria" Font-Size="Small" Font-Bold="true" Text="Attachments" Theme="Glass">
                    </dx:ASPxLabel>
                   <hr/>
                </td>
            </tr>
           <tr id="panelSave2" runat="server" visible="false"> 
                 <td style="width:208px">
                     <dx:ASPxLabel ID="ASPxLabel70" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Document Name" Theme="Glass">
                     </dx:ASPxLabel>
                        <dx:ASPxLabel ID="ASPxLabel4" runat="server" ForeColor="Red" Text="*">
                        </dx:ASPxLabel>
                  </td>
                 <td style="width:212px">
                     <dx:ASPxComboBox ID="txtdocumentname" runat="server" ValidationSettings-ValidationGroup="upload11" AnimationType="Slide" AutoPostBack="true" CallbackPageSize="15" DropDownStyle="DropDownList" EnableCallbackMode="True" IncrementalFilteringMode="Contains" Theme="BlackGlass" ValueType="System.String" Width="250px">
                         <Items>
                             <dx:ListEditItem Text="" Value="" />
                             <dx:ListEditItem Text="Proof of residence(within 3 months)" Value="Proof of residence(within 3 months)" />
                             <dx:ListEditItem Text="Certified ID Copy" Value="Certified ID Copy" />
                             <dx:ListEditItem Text="Certified passport copy(if foreign)" Value="Certified passport copy(if foreign)" />
                             <dx:ListEditItem Text="Other" Value="Other" />
                         </Items>
                     </dx:ASPxComboBox>
                    <dx:ASPxTextBox ID="txtotherdoc" runat="server" BackColor="White" Theme="BlackGlass" Width="250px" Visible="False">
                    </dx:ASPxTextBox>
                  </td>
             </tr>
           <tr id="panelSave3" runat="server" visible="false">  
                 <td style="width:208px">
                     <dx:ASPxLabel ID="ASPxLabel74" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Select Document" Theme="Glass">
                     </dx:ASPxLabel>
                  </td>
                 <td style="width:212px">
                     <asp:FileUpload ID="FileUpload1" runat="server" />
                  </td>
             </tr>
           <tr id="panelSave4" runat="server" visible="false">
                    <td style="width:208px"></td>
                    <td style="width:212px">
                        <dx:ASPxButton ID="ASPxButton10" runat="server" ValidationGroup="upload11" Text="Upload" Theme="BlackGlass">
                        </dx:ASPxButton>
                    </td>
             </tr>
           <tr id="panelSave5" runat="server" visible="false">
                    <td style="width:208px"></td>
                        <td colspan="3">
                            <dx:ASPxGridView ID="ASPxGridView1" runat="server" KeyFieldName="ID" Theme="Glass" Width="470px">
                        <Columns >
                            <dx:GridViewDataColumn VisibleIndex="0">
                                    <DataItemTemplate>
                                        <asp:LinkButton ID="SelectID" Text="Delete"  OnClientClick="if ( !confirm('Are you sure you want to delete ? ')) return false;" CommandName="Delete" CommandArgument='<%# Eval("ID") %>' runat="server">
                                        </asp:LinkButton>
                                    </DataItemTemplate>
                            </dx:GridViewDataColumn>
                            <dx:GridViewDataColumn HeaderStyle-Font-Bold="true" Caption="ID">
                                    <DataItemTemplate>
                                        <dx:ASPxLabel Text='<%# Eval("ID") %>' runat="server"></dx:ASPxLabel>
                                    </DataItemTemplate>
                            </dx:GridViewDataColumn>
                            <dx:GridViewDataColumn HeaderStyle-Font-Bold="true" Caption="Name">
                                    <DataItemTemplate>
                                        <dx:ASPxLabel Text='<%# Eval("name") %>' runat="server"></dx:ASPxLabel>
                                    </DataItemTemplate>
                            </dx:GridViewDataColumn>
                            <dx:GridViewDataColumn HeaderStyle-Font-Bold="true" Caption="Content Type">
                                    <DataItemTemplate>
                                        <dx:ASPxLabel Text='<%# Eval("contenttype") %>' runat="server"></dx:ASPxLabel>
                                    </DataItemTemplate>
                            </dx:GridViewDataColumn>
                        </Columns>
                            </dx:ASPxGridView>
                        </td>
                </tr> 

           <tr id="Panel20a" runat="server" visible="false">
                <td colspan="4">
                    <dx:ASPxLabel ID="ASPxLabel126" runat="server" Font-Names="Cambria" Font-Size="Small" Font-Bold="true" Text="Joint Members" Theme="Glass">
                    </dx:ASPxLabel>
                   <hr/>
                </td>
            </tr> 

           <tr id="Panel20b" runat="server" visible="false">
                               <td style="width:208px">
                                   <dx:ASPxLabel ID="ASPxLabel113" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Full Name" Theme="Glass">
                                   </dx:ASPxLabel>
                                    <dx:ASPxLabel ID="ASPxLabel12" runat="server" ForeColor="Red" Text="*">
                                    </dx:ASPxLabel>
                               </td>
                                <td style="width:212px">
                                   <dx:ASPxTextBox ID="txtnexofkeenName" runat="server" BackColor="White" Theme="BlackGlass" Width="250px">
                                   </dx:ASPxTextBox>
                               </td>
                                <td style="width:208px">
                                    <dx:ASPxLabel ID="ASPxLabel66" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Relationship to the Holder" Theme="Glass">
                                    </dx:ASPxLabel>
                                    <dx:ASPxLabel ID="ASPxLabel19" runat="server" ForeColor="Red" Text="*">
                                    </dx:ASPxLabel>
                                </td>
                                <td style="width:212px">
                                    <dx:ASPxTextBox ID="txtrelation" runat="server" BackColor="White" Theme="BlackGlass" Width="250px">
                                    </dx:ASPxTextBox>
                                </td>
                           </tr>
           <tr id="Panel20c" runat="server" visible="false">
                                    <td style="width:208px">
                                        <dx:ASPxLabel ID="ASPxLabel69" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Mailing address" Theme="Glass">
                                        </dx:ASPxLabel>
                                        <dx:ASPxLabel ID="ASPxLabel13" runat="server" ForeColor="Red" Text="*">
                                        </dx:ASPxLabel>
                                    </td>
                                    <td style="width:212px">
                                        <dx:ASPxTextBox ID="txtnexofkeenAddress" runat="server" BackColor="White" Theme="BlackGlass" Width="250px">
                                        </dx:ASPxTextBox>
                                    </td>
                                    <td style="width:208px">
                                        <dx:ASPxLabel ID="ASPxLabel97" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Cell No." Theme="Glass">
                                        </dx:ASPxLabel>
                                        <dx:ASPxLabel ID="ASPxLabel14" runat="server" ForeColor="Red" Text="*">
                                        </dx:ASPxLabel>
                                    </td>
                                    <td style="width:212px">
                                       <dx:ASPxTextBox ID="txtnextofKeenMobile" runat="server" BackColor="White" Theme="BlackGlass" Width="250px">
                                        </dx:ASPxTextBox>
                                    </td>
                                </tr>
           <tr id="Panel20d" runat="server" visible="false">
                            <td style="width:208px">
                                <dx:ASPxLabel ID="ASPxLabel99" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Email id" Theme="Glass">
                                </dx:ASPxLabel>
                                <dx:ASPxLabel ID="ASPxLabel15" runat="server" ForeColor="Red" Text="*">
                                </dx:ASPxLabel>
                            </td>
                            <td style="width:212px">
                                <dx:ASPxTextBox ID="txtnomineemail" runat="server" BackColor="White" Theme="BlackGlass" Width="250px">
                                    <ValidationSettings ErrorText="Invalid Email" SetFocusOnError="True" ValidationGroup="addholder">
                                    <RegularExpression ErrorText="Invalid Email" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" />
                                </ValidationSettings>
                                </dx:ASPxTextBox>
                            </td>
                            <td style="width:208px">
                                <dx:ASPxLabel ID="ASPxLabel65" runat="server" Font-Names="Cambria" Font-Size="Small" Text="National ID No./Passport No." Theme="Glass">
                                </dx:ASPxLabel>
                                <dx:ASPxLabel ID="ASPxLabel16" runat="server" ForeColor="Red" Text="*">
                                </dx:ASPxLabel>
                            </td>
                            <td style="width:212px">
                                    <dx:ASPxTextBox ID="txtnomineepass" runat="server" BackColor="White" Theme="BlackGlass" Width="250px">
                                </dx:ASPxTextBox>
                            </td>
                        </tr>
           <tr id="panel20e" runat="server" visible="false">
                        <td style="width:208px"></td>
                        <td style="width:212px">
                            <dx:ASPxButton ID="ASPxButton9" runat="server" Text="Add Holder" ValidationGroup="addholder" Theme="BlackGlass">
                            </dx:ASPxButton>
                        </td>
                </tr>  

           <tr id="panel20f" runat="server" visible="false">
                                <td style="width:208px"></td>
                                    <td colspan="3">
                                        <dx:ASPxGridView ID="grdJointAccounts" runat="server" Theme="Glass">
                                            <Columns >
                                                <dx:GridViewDataColumn VisibleIndex="0">
                                                        <DataItemTemplate>
                                                            <asp:LinkButton ID="SelectID" Text="Delete"  OnClientClick="if ( !confirm('Are you sure you want to delete ? ')) return false;" CommandName="Delete" CommandArgument='<%# Eval("ID") %>' runat="server">
                                                            </asp:LinkButton>
                                                        </DataItemTemplate>
                                                </dx:GridViewDataColumn>
                                                <dx:GridViewDataColumn HeaderStyle-Font-Bold="true" Caption="ID">
                                                        <DataItemTemplate>
                                                            <dx:ASPxLabel Text='<%# Eval("ID") %>' runat="server"></dx:ASPxLabel>
                                                        </DataItemTemplate>
                                                </dx:GridViewDataColumn>
                                                <dx:GridViewDataColumn HeaderStyle-Font-Bold="true" Caption="Fullname">
                                                        <DataItemTemplate>
                                                            <dx:ASPxLabel Text='<%# Eval("Surname") %>' runat="server"></dx:ASPxLabel>
                                                        </DataItemTemplate>
                                                </dx:GridViewDataColumn>
                                                <dx:GridViewDataColumn HeaderStyle-Font-Bold="true" Caption="National ID No./Passport No.">
                                                        <DataItemTemplate>
                                                            <dx:ASPxLabel Text='<%# Eval("IDNoPP") %>' runat="server"></dx:ASPxLabel>
                                                        </DataItemTemplate>
                                                </dx:GridViewDataColumn>
                                                <dx:GridViewDataColumn HeaderStyle-Font-Bold="true" Caption="Address">
                                                        <DataItemTemplate>
                                                            <dx:ASPxLabel Text='<%# Eval("Add_1") %>' runat="server"></dx:ASPxLabel>
                                                        </DataItemTemplate>
                                                </dx:GridViewDataColumn>
                                                <dx:GridViewDataColumn HeaderStyle-Font-Bold="true" Caption="Mobile">
                                                        <DataItemTemplate>
                                                            <dx:ASPxLabel Text='<%# Eval("Mobile") %>' runat="server"></dx:ASPxLabel>
                                                        </DataItemTemplate>
                                                </dx:GridViewDataColumn>
                                                <dx:GridViewDataColumn HeaderStyle-Font-Bold="true" Caption="Email">
                                                        <DataItemTemplate>
                                                            <dx:ASPxLabel Text='<%# Eval("Email") %>' runat="server"></dx:ASPxLabel>
                                                        </DataItemTemplate>
                                                </dx:GridViewDataColumn>
                                                <dx:GridViewDataColumn HeaderStyle-Font-Bold="true" Caption="Relation">
                                                        <DataItemTemplate>
                                                            <dx:ASPxLabel Text='<%# Eval("nomineerelation") %>' runat="server"></dx:ASPxLabel>
                                                        </DataItemTemplate>
                                                </dx:GridViewDataColumn>
                                            </Columns>
                                        </dx:ASPxGridView>
                                    </td>
                            </tr> 
           <tr id="panelsaving2a" runat="server" visible="false">
                <td colspan="4">
                    <dx:ASPxLabel ID="ASPxLabel7" runat="server" Font-Names="Cambria" Font-Size="Small" Font-Bold="true" Text="" Theme="Glass">
                    </dx:ASPxLabel>
                   <hr/>
                </td>
            </tr>
           <tr id="panelsaving2" runat="server" visible="false">
                        <td style="width:208px"></td>
                        <td style="width:212px" runat="server">
                            &nbsp;<dx:ASPxButton ID="btnSaveWIP" ValidationGroup="submitWIP" runat="server" Text="Save Work in progress" Theme="BlackGlass">
                            </dx:ASPxButton>
                        </td>
                        <td style="width:208px">
                            <dx:ASPxButton ID="ASPxButton5" runat="server" Text="Save and Submit" Theme="BlackGlass">
                        <ClientSideEvents Click="function(s,e){ e.processOnServer = confirm('Confirm you want to Save and Submit');}" />
                            </dx:ASPxButton>
                        </td>
                        <td style="width:208px">
                            <dx:ASPxButton ID="btnPrint" ValidationGroup="printform" runat="server" Text="Print" Theme="BlackGlass">
                            </dx:ASPxButton>
                        </td>
                </tr>         
            <tr>
              <td colspan="4" style="height: 18px;">
                    <dx:ASPxLabel ID="ASPxLabel25" runat="server" Font-Names="Cambria" Font-Size="Small" Font-Bold="true" Text="Work in progress " Theme="Glass">
                    </dx:ASPxLabel>
                    <hr/>
                </td>
              </tr>
            <tr>
                <td style="height: 18px;"></td>
                <td colspan="3" style="height: 18px">
                    <dx:ASPxGridView ID="grdWIP" runat="server" AutoGenerateColumns="true" OnRowCommand="grdWIP_RowCommand" KeyFieldName="ID" Theme="Glass">
                        <SettingsPager Visible="False">
                        </SettingsPager>
                        <Columns >
                            <dx:GridViewDataColumn VisibleIndex="0">
                                    <DataItemTemplate>
                                        <asp:LinkButton ID="SelectID" Text="Edit" CommandName="Select" CommandArgument='<%# Eval("ID") %>' runat="server">
                                        </asp:LinkButton>
                                    </DataItemTemplate>
                            </dx:GridViewDataColumn>
                            <dx:GridViewDataColumn HeaderStyle-Font-Bold="true" Caption="Forenames">
                                    <DataItemTemplate>
                                        <dx:ASPxLabel Text='<%# Eval("Forenames") %>' runat="server"></dx:ASPxLabel>
                                    </DataItemTemplate>
                            </dx:GridViewDataColumn>
                            <dx:GridViewDataColumn HeaderStyle-Font-Bold="true" Caption="Surname">
                                    <DataItemTemplate>
                                        <dx:ASPxLabel Text='<%# Eval("Surname") %>' runat="server"></dx:ASPxLabel>
                                    </DataItemTemplate>
                            </dx:GridViewDataColumn>
                            <dx:GridViewDataColumn HeaderStyle-Font-Bold="true" Caption="National ID No./Passport No.">
                                    <DataItemTemplate>
                                        <dx:ASPxLabel Text='<%# Eval("IDNoPP") %>' runat="server"></dx:ASPxLabel>
                                    </DataItemTemplate>
                            </dx:GridViewDataColumn>
                            <dx:GridViewDataColumn HeaderStyle-Font-Bold="true" Caption="Address">
                                    <DataItemTemplate>
                                        <dx:ASPxLabel Text='<%# Eval("Add_1") %>' runat="server"></dx:ASPxLabel>
                                    </DataItemTemplate>
                            </dx:GridViewDataColumn>
                        </Columns>
                    </dx:ASPxGridView>
                </td>
            </tr> 
           <tr>
                 <td style="width:208px"></td>
            </tr>
            <tr>
                 <td style="width:208px"></td>
            </tr>
        </table> 
      </asp:Panel>
</asp:Content>

