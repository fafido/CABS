<%@ Page Language="VB" MasterPageFile="~/CDSUser.master" AutoEventWireup="false" CodeFile="AccountsCreations_corp.aspx.vb" Inherits="TransferSec_AccountsCreations_corp" title="Corporate Account" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<%@ Register assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxUploadControl" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxLoadingPanel" tagprefix="dx" %>
<asp:Content id="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Panel id="Panel1" runat="server" Width="100%" Font-Names="Cambria" BackColor="White" GroupingText="Accounts Creation">
        <table>
           <tr id="Panel10g" runat="server">
                <td style="width: 208px">
                    <dx:ASPxLabel ID="ASPxLabel24" runat="server" Font-Names="Cambria" Font-Size="Small" Font-Bold="true" Text="Account Type" Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                <td style="width: 212px; font-family:Cambria; font-size:small">
                    <asp:RadioButton ID="rdCorprate" runat="server" AutoPostBack="False" Checked="true" GroupName="AccountType" Text="Corporate/Pension Fund" />
                </td>
                <td style="width: 208px"></td>
                <td style="width: 212px"></td>
            </tr> 
            <tr>
                <td colspan="4">
                    <dx:ASPxLabel ID="ASPxLabel1101" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Identification Verification" Theme="PlasticBlue">
                    </dx:ASPxLabel>
                   <hr/>
                </td>
            </tr>
                  <tr id="CORP1" runat="server">
                      <td  style="width: 208px">
                          <dx:ASPxLabel ID="ASPxLabel31" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Identification Type" Theme="Glass">
                          </dx:ASPxLabel>
                      </td>
                      <td style="width: 212px">
                          <dx:ASPxComboBox ID="cmbIDType" runat="server" Theme="BlackGlass" Width="250px" AutoPostBack="True">
                              <Items>
                                  <dx:ListEditItem Text="Certificate of Incorporation No" Value="Certificate of Incorporation No" />
                                  <dx:ListEditItem Text="IPEC Registration Certificate No" Value="IPEC Registration Certificate No" />
                                  <dx:ListEditItem Text="Trustee Deed No" Value="Trustee Deed No" />
                              </Items>
                          </dx:ASPxComboBox>
                      </td>
                      <td style="width: 208px">
                          <dx:ASPxLabel ID="ASPxLabel30" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Incorporation/Registration Number" Theme="Glass">
                          </dx:ASPxLabel>
                      </td>
                      <td style="width: 212px">
                          <dx:ASPxTextBox ID="txtIDNo" runat="server" BackColor="White" MaxLength="50" Theme="BlackGlass" Width="250px">
                          </dx:ASPxTextBox>
                      </td>
                  </tr>
                  <tr id="CORP2" runat="server">
                      <td style="width: 208px"></td>
                      <td style="width: 212px"></td>
                      <td style="width: 208px"></td>
                      <td style="width: 212px">
                          <dx:ASPxButton ID="btnJadd0" runat="server" Text="Validate Identification Details" Theme="BlackGlass">
                          </dx:ASPxButton>
                      </td>
                  </tr>
               <tr id="Panel8a" runat="server" visible="false">
                    <td colspan="4">
                        <dx:ASPxLabel ID="ASPxLabel117" runat="server" Font-Names="Cambria" Font-Size="Small" Font-Bold="true" Text="Company Details" Theme="Glass">
                        </dx:ASPxLabel>
                       <hr/>
                    </td>
                </tr>
                <tr id="p1" runat="server" visible="false">
                    <td style="width: 208px">
                        <dx:ASPxLabel ID="ASPxLabel26" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Name of Company" Theme="Glass">
                        </dx:ASPxLabel>
                        <dx:ASPxLabel ID="ASPxLabel56" runat="server" ForeColor="Red" Text="*">
                        </dx:ASPxLabel>
                    </td>
                    <td style="width: 212px">
                        <dx:ASPxTextBox ID="txtSurname" runat="server" BackColor="White" Theme="BlackGlass" Width="250px">
                        </dx:ASPxTextBox>
                    </td>
                    <td style="width: 208px">
                        <dx:ASPxLabel ID="ASPxLabel5" runat="server" Font-Names="Cambria" Font-Size="Small"  Text="Account Type" Theme="Glass">
                        </dx:ASPxLabel>
                        <dx:ASPxLabel ID="ASPxLabel63" runat="server" ForeColor="Red" Text="*">
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
                <tr id="p7" runat="server" visible="false">
                    <td colspan="4">
                        <dx:ASPxLabel ID="ASPxLabel1" runat="server" Font-Names="Cambria" Font-Size="Small" Font-Bold="true" Text="Registered Office/Head Office Address" Theme="PlasticBlue">
                        </dx:ASPxLabel>
                       <hr/>
                    </td>
                </tr>
                <tr id="p8" runat="server" visible="false">
               <td style="width: 208px">
                   <dx:ASPxLabel ID="ASPxLabel6" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Physical Address" Theme="Glass">
                   </dx:ASPxLabel>
                   <dx:ASPxLabel ID="ASPxLabel58" runat="server" ForeColor="Red" Text="*">
                   </dx:ASPxLabel>
               </td>
               <td style="width: 212px">
                   <dx:ASPxTextBox ID="txtAddress1" runat="server" BackColor="White" Theme="BlackGlass" Width="250px">
                   </dx:ASPxTextBox>
               </td>
                    <td style="width: 208px">
                        <dx:ASPxLabel ID="ASPxLabel67" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Postal Address" Theme="Glass">
                   </dx:ASPxLabel>
                        <dx:ASPxLabel ID="ASPxLabel33" runat="server" ForeColor="Red" Text="*">
                        </dx:ASPxLabel>
                        </td>
                <td style="width: 212px">
                    <dx:ASPxTextBox ID="txtAddress2" runat="server" BackColor="White" Theme="BlackGlass" Width="250px">
                    </dx:ASPxTextBox>
                    </td>
           </tr>
                <tr id="p10" runat="server" visible="false">
                    <td style="width: 208px">
                        <dx:ASPxLabel ID="ASPxLabel54" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Country of Registration" Theme="Glass">
                        </dx:ASPxLabel>
                        <dx:ASPxLabel ID="ASPxLabel59" runat="server" ForeColor="Red" Text="*">
                        </dx:ASPxLabel>
                    </td>
                <td style="width: 212px">
                    <dx:ASPxComboBox ID="cmbCountry" runat="server" Theme="BlackGlass" ValueType="System.String" Width="250px" PopupVerticalAlign="TopSides" IncrementalFilteringMode="Contains" AnimationType="Slide">
                    </dx:ASPxComboBox>
                    </td>
                    <td style="width: 208px">
                        <dx:ASPxLabel ID="ASPxLabel13" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Country of Tax Residence" Theme="Glass">
                        </dx:ASPxLabel>
                        <dx:ASPxLabel ID="ASPxLabel14" runat="server" ForeColor="Red" Text="*">
                        </dx:ASPxLabel>
                    </td>
                    <td style="width: 212px">
                        <dx:ASPxComboBox ID="cmbCountryTaxResidence" runat="server" Theme="BlackGlass" ValueType="System.String" Width="250px" IncrementalFilteringMode="Contains" AnimationType="Slide">
                        </dx:ASPxComboBox>
                    </td>
            </tr>
                <tr id="p5" runat="server" visible="false">
                       <td style="width: 208px">
                        <dx:ASPxLabel ID="ASPxLabel17" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Nature of Business" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td style="width: 212px">
                        <dx:ASPxTextBox ID="txtNatureOfBusiness" runat="server" BackColor="White" Theme="BlackGlass" Width="250px">
                        </dx:ASPxTextBox>
                    </td>
                    <td style="width: 208px">
                        <dx:ASPxLabel ID="ASPxLabel32" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Date of Incorporation" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td style="width: 212px">
                        <dx:ASPxDateEdit ID="txtDOB" runat="server" EditFormat="Custom" EditFormatString="dd MMMM yyyy" Theme="BlackGlass" Width="250px">
                        </dx:ASPxDateEdit>
                    </td>
                </tr>
                <tr id="p6" runat="server" visible="false">
                    <td style="width: 208px">
                        <dx:ASPxLabel ID="ASPxLabel34" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Source of Funds" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td style="width: 212px">
                        <dx:ASPxTextBox ID="txtSourceofFunds" runat="server" BackColor="White" Theme="BlackGlass" Width="250px">
                        </dx:ASPxTextBox>
                    </td>
                    <td style="width: 208px">
                        <dx:ASPxLabel ID="ASPxLabel7" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Investor Type" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td style="width: 212px">
                        <dx:ASPxComboBox ID="cmbInvestorType" runat="server" Theme="BlackGlass" ValueType="System.String" Width="250px" IncrementalFilteringMode="Contains" AnimationType="Slide">
                            <Items>
                                <dx:ListEditItem Text="" Value="" />
                                <dx:ListEditItem Text="Local Investor" Value="Local Investor" />
                                <dx:ListEditItem Text="Foreign Investor" Value="Foreign Investor" />
                            </Items>
                        </dx:ASPxComboBox>
                    </td>
                </tr>
               <tr id="Panel3bb" runat="server" visible="false">
                <td colspan="4">
                    <dx:ASPxLabel ID="ASPxLabel2" runat="server" Font-Names="Cambria" Font-Size="Small" Font-Bold="true" Text="Asset Manager/s" Theme="Glass">
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
            <tr id="Panel3bbbbn" runat="server" visible="false">
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
                           <dx:GridViewDataColumn VisibleIndex="0">
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
                <tr id="p30" runat="server" visible="false">
                <td colspan="4">
                    <dx:ASPxLabel ID="ASPxLabel22" runat="server" Font-Names="Cambria" Font-Size="Small" Font-Bold="true" Text="Contact Person's Details (authorized representative)" Theme="PlasticBlue">
                    </dx:ASPxLabel>
                   <hr/>
                </td>
            </tr>
                <tr id="p12" runat="server" visible="false">
                    <td style="width: 208px">
                        <dx:ASPxLabel ID="ASPxLabel15" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Full Name of Contact Person" Theme="Glass">
                        </dx:ASPxLabel>
                        <dx:ASPxLabel ID="ASPxLabel16" runat="server" ForeColor="Red" Text="*">
                        </dx:ASPxLabel>
                    </td>
                    <td style="width: 212px">
                        <dx:ASPxTextBox ID="txtfullname" runat="server" BackColor="White" Theme="BlackGlass" Width="250px">
                        </dx:ASPxTextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtfullname" Display="None" ErrorMessage="fullname Required" ValidationGroup="Submit"></asp:RequiredFieldValidator>
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
                <tr id="p13" runat="server" visible="false">
                <td style="width: 208px">
                        <dx:ASPxLabel ID="ASPxLabel9" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Fax" Theme="Glass">
                    </dx:ASPxLabel>
                    </td>
                <td style="width: 212px">
                    <dx:ASPxTextBox ID="txtFax" runat="server" BackColor="White" Theme="BlackGlass" Width="250px">
                    </dx:ASPxTextBox>
                    </td>
                <td style="width: 208px">
                    <dx:ASPxLabel ID="ASPxLabel40" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Email Address" Theme="Glass">
                    </dx:ASPxLabel>
                    <dx:ASPxLabel ID="ASPxLabel41" runat="server" ForeColor="Red" Text="*">
                    </dx:ASPxLabel>
                </td>
                <td style="width: 212px">
                    <dx:ASPxTextBox ID="txtEmail" runat="server" BackColor="White" Theme="BlackGlass" Width="250px">
                         <ValidationSettings ErrorText="Invalid Email" SetFocusOnError="True">
                                <RegularExpression ErrorText="Invalid Email" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" />
                                <RequiredField IsRequired="True" />
                            </ValidationSettings>
                    </dx:ASPxTextBox>
                </td>
            </tr>
                <tr id="p20" runat="server" visible="false">
                <td colspan="4">
                    <dx:ASPxLabel ID="ASPxLabel3" runat="server" Font-Names="Cambria" Font-Size="Small" Font-Bold="true" Text="Banking Details" Theme="PlasticBlue">
                    </dx:ASPxLabel>
                   <hr/>
                </td>
            </tr>
                         <tr id="p21" runat="server" visible="false">
                               <td style="width: 208px">
                                   <dx:ASPxLabel ID="ASPxLabel62" Visible="true"   runat="server" Font-Names="Cambria" Font-Size="Small" Text="Account Name" Theme="Glass">
                                   </dx:ASPxLabel>
                                   <dx:ASPxLabel ID="ASPxLabel91"  Visible="true"   runat="server" ForeColor="Red" Text="*">
                                   </dx:ASPxLabel>
                               </td>
                               <td style="width: 212px">
                                   <dx:ASPxTextBox ID="txtPayee2" Visible="true" runat="server" BackColor="White" Theme="BlackGlass" Width="250px">
                                   </dx:ASPxTextBox>
                               </td>
                               <td style="width: 208px">
                                   <dx:ASPxLabel ID="ASPxLabel35" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Account No." Theme="Glass">
                                   </dx:ASPxLabel>
                                   <dx:ASPxLabel ID="ASPxLabel36" runat="server" ForeColor="Red" Text="*">
                                   </dx:ASPxLabel>
                               </td>
                               <td style="width: 212px">
                                   <dx:ASPxTextBox ID="txtIBAN" runat="server" BackColor="White" Theme="BlackGlass" Width="250px">
                                   </dx:ASPxTextBox></td>
                           </tr>
                           <tr id="p22" runat="server" visible="false">
                               <td style="width: 208px">
                                   <dx:ASPxLabel ID="ASPxLabel49" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Bank Name" Theme="Glass">
                                   </dx:ASPxLabel>
                                   <dx:ASPxLabel ID="ASPxLabel92" runat="server" ForeColor="Red" Text="*">
                                   </dx:ASPxLabel>
                               </td>
                               <td style="width: 212px">
                                   <dx:ASPxComboBox ID="cmbBankDiv" runat="server" AutoPostBack="False" Theme="BlackGlass" ValueType="System.String" Width="250px" CallbackPageSize="15" EnableCallbackMode="True" DropDownStyle="DropDownList"  IncrementalFilteringMode="Contains"  AnimationType="Slide">
                                   </dx:ASPxComboBox>
                               </td>
                               <td style="width: 208px">
                                   <dx:ASPxLabel ID="ASPxLabel50" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Branch" Theme="Glass">
                                   </dx:ASPxLabel>
                                   <dx:ASPxLabel ID="ASPxLabel88" runat="server" ForeColor="Red" Text="*">
                                   </dx:ASPxLabel>
                               </td>
                               <td style="width: 212px">
                                   <dx:ASPxTextBox ID="txtBranchDiv" Visible="true" runat="server" BackColor="White" Theme="BlackGlass" Width="250px">
                                   </dx:ASPxTextBox>
                               </td>
                           </tr>
                           <tr id="p23" runat="server" visible="false">
                               <td style="width: 208px">
                                   <dx:ASPxLabel ID="ASPxLabel37" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Bank Address (If Foreign)" Theme="Glass">
                                   </dx:ASPxLabel>
                               </td>
                               <td style="width: 212px">
                                 <dx:ASPxTextBox ID="txtBankAddress" runat="server" BackColor="White" Theme="BlackGlass" Width="250px">
                                    </dx:ASPxTextBox>
                               </td>
                                <td style="width: 208px">
                                    <dx:ASPxLabel ID="ASPxLabel51" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Swift Code (If Foreign)" Theme="Glass">
                                    </dx:ASPxLabel>
                                </td>
                                <td style="width: 212px">
                                    <dx:ASPxTextBox ID="txtSwiftCode" runat="server" BackColor="White" Theme="BlackGlass" Width="250px">
                                    </dx:ASPxTextBox>
                                </td>
                           </tr>
             <tr id="p24" runat="server" visible="false">
                <td colspan="4">
                    <dx:ASPxLabel ID="ASPxLabel4" runat="server" Font-Names="Cambria" Font-Size="Small" Font-Bold="true" Text="Attachments" Theme="PlasticBlue">
                    </dx:ASPxLabel>
                   <hr/>
                </td>
            </tr>
                           <tr id="p25" runat="server" visible="false">
                               <td style="width: 208px">
                                   <dx:ASPxLabel ID="ASPxLabel70" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Document Name" Theme="Glass">
                                   </dx:ASPxLabel>
                                    <dx:ASPxLabel ID="ASPxLabel20" runat="server" ForeColor="Red" Text="*">
                                    </dx:ASPxLabel>
                               </td>
                               <td style="width: 212px">
                                   <dx:ASPxComboBox ID="txtdocumentname" runat="server" AnimationType="Slide" AutoPostBack="True" CallbackPageSize="15" DropDownStyle="DropDownList" EnableCallbackMode="True" IncrementalFilteringMode="Contains" Theme="BlackGlass" ValueType="System.String" Width="250px">
                                       <Items>
                                        <dx:ListEditItem Text="Client Acceptance/Takeon Requirements" Value="Client Acceptance/Takeon Requirements" />
                                        <dx:ListEditItem Text="Trust Deed (For Trusteeship Account)" Value="Trust Deed (For Trusteeship Account)" />
                                        <dx:ListEditItem Text="Certificate Of Incorporation Or Equivalent" Value="Certificate Of Incorporation Or Equivalent" />
                                        <dx:ListEditItem Text="Memorandum And Articles Of Association/ Constitution/ Partnership Deed Etc." Value="Memorandum And Articles Of Association/ Constitution/ Partnership Deed Etc." />
                                        <dx:ListEditItem Text="Directors (Cr14 Form Or Equivalent)" Value="Directors (Cr14 Form Or Equivalent)" />
                                        <dx:ListEditItem Text="Address Of Registered Office (Copy Of Cr6 Or Equivalent If Foreign)" Value="Address Of Registered Office (Copy Of Cr6 Or Equivalent If Foreign)" />
                                        <dx:ListEditItem Text="National Identity Copies Of Authorized, Signatories And Directors" Value="National Identity Copies Of Authorized, Signatories And Directors" />
                                        <dx:ListEditItem Text="Passport Copies Of Authorized, Signatories And Directors (If Foreign)" Value="Passport Copies Of Authorized, Signatories And Directors (If Foreign)" />
                                        <dx:ListEditItem Text="Proof Of Residence Of Authorized Signatories (Within 3 Months)" Value="Proof Of Residence Of Authorized Signatories (Within 3 Months)    " />
                                        <dx:ListEditItem Text="Passport Sized Photo (Of Authorized Signatories)" Value="Passport Sized Photo (Of Authorized Signatories)" />
                                        <dx:ListEditItem Text="Board Resolution To Open A Trustee Account" Value="Board Resolution To Open A Trustee Account" />
                                        <dx:ListEditItem Text="Letter Of Reference From Bank (If Foreign)" Value="Letter Of Reference From Bank (If Foreign)" />
                                        <dx:ListEditItem Text="Other" Value="Other" />
                                      </Items>
                                   </dx:ASPxComboBox>
                                   <dx:ASPxTextBox ID="txtotherdoc" runat="server" BackColor="White" Theme="BlackGlass" Width="250px" Visible="False">
                                   </dx:ASPxTextBox>
                               </td>
                               <td style="width: 208px">
                                   <dx:ASPxLabel ID="ASPxLabel74" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Select Document" Theme="Glass">
                                   </dx:ASPxLabel>
                               </td>
                               <td style="width: 212px">
                                   <asp:FileUpload ID="FileUpload1" runat="server" />
                               </td>
                           </tr>
                           <tr id="p26" runat="server" visible="false">
                               <td style="width: 208px"></td>
                               <td style="width: 212px">
                                   <dx:ASPxButton ID="ASPxButton10" ValidationGroup="uploadCoop" runat="server" Text="Upload" Theme="BlackGlass">
                                   </dx:ASPxButton>
                                   &nbsp;</td>
                           </tr>
                           <tr id="p27" runat="server" visible="false">
                               <td align="center" colspan="4">
                                   <dx:ASPxGridView ID="ASPxGridView1" runat="server" KeyFieldName="ID" Theme="Glass">
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
              <tr id="p28" runat="server" visible="false">
                <td colspan="4" align ="center">
                    <dx:ASPxLabel ID="ASPxLabel23" runat="server" Font-Names="Cambria" Font-Size="Small" Font-Bold="true" Text="" Theme="PlasticBlue">
                    </dx:ASPxLabel>
                   <hr/>
                </td>
            </tr>
                <tr id="p29" runat="server" visible="false">
                        <td colspan ="4" align ="center">
                            <dx:ASPxButton ID="ASPxButton9" runat="server" Text="Save &amp; Submit" Theme="BlackGlass">
                        <ClientSideEvents Click="function(s,e){ e.processOnServer = confirm('Confirm you want to Save and Submit');}" />
                                  </dx:ASPxButton>
                            &nbsp;
                            <dx:ASPxButton ID="btnSaveWIP" runat="server" Text="Save Work in progress" Theme="BlackGlass" ValidationGroup="submitWIP">
                            </dx:ASPxButton>
                            &nbsp;
                            <dx:ASPxButton ID="btnPrint" ValidationGroup="printform" runat="server" Text="Print" Theme="BlackGlass" Visible="true">
                            </dx:ASPxButton>
                        </td>
                </tr>
              <tr id="panel00002" runat="server" visible="true">
              <td colspan="4">
                    <dx:ASPxLabel ID="ASPxLabel27" runat="server" Font-Names="Cambria" Font-Size="Small" Font-Bold="true" Text="Work in progress " Theme="Glass">
                    </dx:ASPxLabel>
                    <hr/>
                </td>
              </tr>
            <tr id="panel00003" runat="server" visible="true">
                <td  style="width: 208px"></td>
                <td colspan="3">
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
                            <dx:GridViewDataColumn HeaderStyle-Font-Bold="true" Caption="Company Name">
                                    <DataItemTemplate>
                                        <dx:ASPxLabel Text='<%# Eval("Surname") %>' runat="server"></dx:ASPxLabel>
                                    </DataItemTemplate>
                            </dx:GridViewDataColumn>
                            <dx:GridViewDataColumn HeaderStyle-Font-Bold="true" Caption="Certificate of Incorporation No.">
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
                <td style="width: 208px"></td>
                <td style="width: 212px"></td>
                <td style="width: 208px"></td>
                <td style="width: 212px"></td>
            </tr>
            <tr>
                <td style="width: 208px"></td>
                <td style="width: 212px"></td>
                <td style="width: 208px"></td>
                <td style="width: 212px"></td>
            </tr>
        </table>
    </asp:Panel>
</asp:Content>

