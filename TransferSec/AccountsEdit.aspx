<%@ Page Language="VB" MasterPageFile="~/CDSUser.master" AutoEventWireup="false" CodeFile="AccountsEdit.aspx.vb" Inherits="AccountsEDIT" title="Accounts Edit" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>

<%@ Register assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxRoundPanel" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxPanel" tagprefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<%@ Register assembly="BasicFrame.WebControls.BasicDatePicker" namespace="BasicFrame.WebControls" tagprefix="BDP" %>
<%@ Register assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxPopupControl" tagprefix="dx" %>

<asp:Content id="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Panel id="Panel1" runat="server" Width="100%" Font-Names="Cambria" BackColor="White" GroupingText="Accounts Edit">
        <table>
            <tr>
                <td colspan="4">
                    <dx:ASPxLabel ID="ASPxLabel119" runat="server" Font-Names="Cambria" Font-Size="Small" Font-Bold="true" Text="" Theme="Glass">
                    </dx:ASPxLabel>
                   <hr/>
                </td>
            </tr>
            <tr>
                <td style="width: 208px"></td>
                <td style="width: 212px">
                    <dx:ASPxListBox ID="lstNameSearch" runat="server" AutoPostBack="True" Theme="BlackGlass" ValueType="System.String" Width="250px">
                    </dx:ASPxListBox>
                </td>
            </tr>
            <tr>
                <td colspan="4">
                    <dx:ASPxLabel ID="ASPxLabel141" runat="server" Font-Names="Cambria" Font-Size="Small" Font-Bold="true" Text="" Theme="Glass">
                    </dx:ASPxLabel>
                   <hr/>
                </td>
            </tr>
            <tr>
                <td style="width: 208px">
                    <dx:ASPxLabel ID="ASPxLabel12" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Account No." Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                    <td style="width: 212px">
                            <dx:ASPxLabel ID="lblRecordID" runat="server" Font-Names="Cambria" Font-Size="Small" Visible="false" Theme="Glass">
                            </dx:ASPxLabel>
                        <dx:ASPxTextBox ReadOnly="True" ID="TXTClientID" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="250px">
                            </dx:ASPxTextBox>
                        </td>
                 <td style="width: 208px">
                     <dx:ASPxLabel ID="ASPxLabel1" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Account Type" Theme="Glass">
                     </dx:ASPxLabel>
                 </td>
                 <td style="width: 212px">
                     <dx:ASPxTextBox ID="rdAccountType" runat="server" ReadOnly="true" BackColor="#E4E4E4" Theme="BlackGlass" Width="250px">
                           </dx:ASPxTextBox>
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
                          <dx:ASPxComboBox ID="cmbIDType" Enabled="false" ReadOnly="true" runat="server" Theme="BlackGlass" Width="250px"  CallbackPageSize="15" EnableCallbackMode="True" DropDownStyle="DropDownList"  IncrementalFilteringMode="Contains"  AnimationType="Slide" AutoPostBack="False">
                          </dx:ASPxComboBox>
                      </td>
                      <td style="width: 208px">
                          <dx:ASPxLabel ID="ASPxLabel30" runat="server" Font-Names="Cambria" Font-Size="Small" Text="National ID No./Passport No." Theme="Glass">
                          </dx:ASPxLabel>
                      </td>
                      <td style="width: 212px">
                          <dx:ASPxTextBox ID="txtIDNo" ReadOnly="true" runat="server" BackColor="White" MaxLength="50" Theme="Glass" Width="250px">
                          </dx:ASPxTextBox>
                      </td>
                  </tr>
           <tr id="Panel15a" runat="server" visible="false">
                <td colspan="4">
                    <dx:ASPxLabel ID="ASPxLabel2" runat="server" Font-Names="Cambria" Font-Size="Small" Font-Bold="true" Text="Joint Account Details" Theme="Glass">
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
                        <dx:ASPxTextBox ID="txtSurname0" ReadOnly="true" runat="server" BackColor="#E4E4E4" Theme="Glass" Width="250px">
                        </dx:ASPxTextBox>
                    </td>
               <td style="width: 208px"></td>
               <td style="width: 212px"></td>
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
                        <dx:ASPxTextBox ID="txtCNIC" ReadOnly="true" runat="server" BackColor="White" Theme="BlackGlass" Width="250px">
                        </dx:ASPxTextBox>
                    </td>
                </tr>
           <tr id="Panel8d" runat="server" visible="false">
                    <td style="width: 208px">
                        <dx:ASPxLabel ID="ASPxLabel4" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Forenames" Theme="Glass">
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
                        <dx:ASPxComboBox ID="cmbTypeofAccount" runat="server" AutoPostBack="true" Theme="BlackGlass" ValueType="System.String" Width="250px" CallbackPageSize="15" EnableCallbackMode="True" DropDownStyle="DropDownList"  IncrementalFilteringMode="Contains"  AnimationType="Slide">
                            <Items>
                                <dx:ListEditItem Text="Custody" Value="Custody" />
                                <dx:ListEditItem Text="Trustee" Value="Trustee" />
                                <dx:ListEditItem Text="Unit Trust" Value="Unit Trust" />
                            </Items>
                        </dx:ASPxComboBox>
                    </td>
                    <td style="width: 208px">
                        <dx:ASPxLabel ID="ASPxLabel116" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Classification" Theme="Glass">
                        </dx:ASPxLabel>
                        <dx:ASPxLabel ID="ASPxLabel120" runat="server" ForeColor="Red" Text="*">
                        </dx:ASPxLabel>
                    </td>
                    <td style="width: 212px">
                        <dx:ASPxComboBox ID="cmbClassification" runat="server" Theme="BlackGlass" ValueType="System.String" Width="250px" CallbackPageSize="15" EnableCallbackMode="True" DropDownStyle="DropDownList"  IncrementalFilteringMode="Contains"  AnimationType="Slide">
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
           <tr id="Panel8kc" runat="server" visible="false">
                    <td style="width: 208px">
                        <dx:ASPxLabel ID="ASPxLabel104" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Billing Profile" Theme="Glass">
                        </dx:ASPxLabel>
                        <dx:ASPxLabel ID="ASPxLabel105" runat="server" ForeColor="Red" Text="*">
                        </dx:ASPxLabel>
                    </td>
                    <td style="width: 212px">
                        <dx:ASPxComboBox ID="cmbBillingProfile" runat="server" Theme="BlackGlass" ValueType="System.String" Width="250px" CallbackPageSize="15" EnableCallbackMode="True" DropDownStyle="DropDownList"  IncrementalFilteringMode="Contains"  AnimationType="Slide">
                        </dx:ASPxComboBox>
                    </td>
                    <td style="width: 208px">
                         <dx:ASPxLabel ID="ASPxLabel125" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Bill Cash Account" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td style="width: 212px">
                        <table width="100%">
                            <tr>
                                 <td>
                                   <asp:CheckBox ID="chkBillCashAccount" runat="server" AutoPostBack ="false"/>
                                 </td>
                                 <td>
                                     <dx:ASPxLabel ID="ASPxLabel36e" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Currency" Theme="Glass">
                                    </dx:ASPxLabel>
                                 </td>
                                 <td>
                                    <dx:ASPxComboBox ID="cmbBillingCurrency" runat="server" Width="110px" Theme="BlackGlass" ValueType="System.String" CallbackPageSize="15" EnableCallbackMode="True" DropDownStyle="DropDownList"  IncrementalFilteringMode="Contains"  AnimationType="Slide">
                                    </dx:ASPxComboBox>
                                 </td>
                            </tr>
                        </table>
                    </td>
               </tr>
            <tr id="Panel8kcA" runat="server" visible="false">
                    <td style="width: 208px">
                        <dx:ASPxLabel ID="ASPxLabel129" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Investor Type" Theme="Glass">
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
             <tr id="Panel8kb" runat="server" visible="false">
                <td colspan="4">
                    <dx:ASPxLabel ID="ASPxLabel108" runat="server" Font-Names="Cambria" Font-Size="Small" Font-Bold="true" Text="Fund" Theme="Glass">
                    </dx:ASPxLabel>
                   <hr/>
                </td>
            </tr>
           <tr id="Panel8kbb" runat="server" visible="false">
              <td style="width: 208px">
                    <dx:ASPxLabel ID="ASPxLabel109" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Select Fund" Theme="Glass">
                    </dx:ASPxLabel>
                        <dx:ASPxLabel ID="ASPxLabel111" runat="server" ForeColor="Red" Text="*">
                        </dx:ASPxLabel>
                </td>
                <td style="width: 212px">
                    <dx:ASPxComboBox ID="cmbUnitTrustFund" AutoPostBack="false" runat="server" Theme="BlackGlass" ValueType="System.String" Width="250px" CallbackPageSize="15" EnableCallbackMode="True" DropDownStyle="DropDownList"  IncrementalFilteringMode="Contains"  AnimationType="Slide">
                    </dx:ASPxComboBox>
                </td>
           </tr>
             <tr id="Panel3bb" runat="server" visible="false">
                <td colspan="4">
                    <dx:ASPxLabel ID="ASPxLabel39" runat="server" Font-Names="Cambria" Font-Size="Small" Font-Bold="true" Text="Asset Manager/s" Theme="Glass">
                    </dx:ASPxLabel>
                   <hr/>
                </td>
            </tr>
           <tr id="Panel3bbb" runat="server" visible="false">
                <td style="width: 208px">
                    <dx:ASPxLabel ID="ASPxLabel95" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Asset Manager" Theme="Glass">
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
                                 <th align="left" style="width:100px">
                                    <asp:Label ID="Label3" runat="server" Text="AccountName"></asp:Label>
                                </th>
                                  <th align="left" style="width:100px">
                                    <asp:Label ID="Label6" runat="server" Text="Currency"></asp:Label>
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
                                 <td>
                                    <asp:Label ID="lblAccountName" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "AccountName")%>'></asp:Label>
                                </td>
                                  <td>
                                    <asp:Label ID="lblCurrency" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Currency")%>'></asp:Label>
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
           
           <tr id="Panel3bbbb1" runat="server" visible="false">
                    <td style="width:208px">
                        <dx:ASPxLabel ID="ASPxLabel1319" runat="server" Font-Names="Cambria" Font-Size="Small" Text="CDC Number" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                        <td style="width:212px">
                            <dx:ASPxTextBox ID="txtcdcnumber" runat="server" BackColor="White" Theme="BlackGlass" Width="250px">
                            </dx:ASPxTextBox>
                        </td>
                    <td style="width:208px">
                        <dx:ASPxLabel ID="ASPxLabel124" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Inter Company A/c" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                        <td  style="width:212px">
                            <dx:ASPxComboBox ID="cmbInterCompanyAccount" runat="server" Theme="BlackGlass" ValueType="System.String" Width="250px" CallbackPageSize="15" EnableCallbackMode="True" DropDownStyle="DropDownList"  IncrementalFilteringMode="Contains"  AnimationType="Slide">
                    </dx:ASPxComboBox>
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
                           <dx:GridViewDataColumn VisibleIndex="0">
                               <DataItemTemplate>
                                   <asp:LinkButton ID="SelectID" runat="server" CommandArgument='<%# Eval("ID") %>' CommandName="Delete" OnClientClick="if ( !confirm('Confirm you want to proceed with action')) return false;" Text="Mark/UnMark for deletion">
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
                             <dx:GridViewDataColumn Caption="AccountName" HeaderStyle-Font-Bold="true">
                               <DataItemTemplate>
                                   <dx:ASPxLabel runat="server" Text='<%# Eval("AccountName") %>'>
                                   </dx:ASPxLabel>
                               </DataItemTemplate>
                           </dx:GridViewDataColumn>
                               <dx:GridViewDataColumn Caption="Currency" HeaderStyle-Font-Bold="true">
                               <DataItemTemplate>
                                   <dx:ASPxLabel runat="server" Text='<%# Eval("Currency") %>'>
                                   </dx:ASPxLabel>
                               </DataItemTemplate>
                           </dx:GridViewDataColumn>
                               <dx:GridViewDataColumn Caption="CDC Number" HeaderStyle-Font-Bold="true">
                               <DataItemTemplate>
                                   <dx:ASPxLabel runat="server" Text='<%# Eval("cdcnumber") %>'>
                                   </dx:ASPxLabel>
                               </DataItemTemplate>
                           </dx:GridViewDataColumn>
                               <dx:GridViewDataColumn Caption="Update Status" HeaderStyle-Font-Bold="true">
                               <DataItemTemplate>
                                   <dx:ASPxLabel runat="server" Text='<%# Eval("UpdateStatus") %>'>
                                   </dx:ASPxLabel>
                               </DataItemTemplate>
                           </dx:GridViewDataColumn>
                               <dx:GridViewDataColumn Caption="InterCompany A/C" HeaderStyle-Font-Bold="true">
                               <DataItemTemplate>
                                   <dx:ASPxLabel runat="server" Text='<%# Eval("DispInterAccNumber") %>'>
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
            <tr id="Panel4e" runat="server" visible="false">
                <td style="width:208px">
                    <dx:ASPxLabel ID="ASPxLabel23u" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Bank Type" Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                <td style="width:212px">
                    <dx:ASPxComboBox ID="cmbBankCat" runat="server" AutoPostBack="True" Theme="BlackGlass" ValueType="System.String" Width="250px" CallbackPageSize="15" EnableCallbackMode="True" DropDownStyle="DropDownList"  IncrementalFilteringMode="Contains"  AnimationType="Slide">
                        <Items>
                            <dx:ListEditItem Text="Local Bank" Value="Local Bank" Selected="true" />
                            <dx:ListEditItem Text="Foreign Bank" Value="Foreign Bank" />
                        </Items>
                    </dx:ASPxComboBox>
                </td>
                <td style="width:208px">
                    <dx:ASPxLabel ID="ASPxLabel23" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Date/Time stamp" Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                <td style="width:212px">
                    <dx:ASPxTextBox ID="txtDateTimeStamp" runat="server" BackColor="White" Theme="BlackGlass" Width="250px">
                    </dx:ASPxTextBox>
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
                    <dx:ASPxTextBox ID="txtBankForeign" Visible="false" runat="server" BackColor="White" Theme="BlackGlass" Width="250px">
                    </dx:ASPxTextBox>
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
                    <dx:ASPxLabel ID="ASPxLabel7" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Swift Code (if foreign)" Theme="Glass">
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
           <%--<tr id="Panel4e" runat="server" visible="false">
                <td style="width:208px">
                    <dx:ASPxLabel ID="ASPxLabel23" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Date/Time stamp" Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                <td style="width:212px">
                    <dx:ASPxTextBox ID="txtDateTimeStamp" runat="server" BackColor="White" Theme="BlackGlass" Width="250px">
                    </dx:ASPxTextBox>
                </td>
            </tr>--%>

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
                        <dx:ASPxLabel ID="ASPxLabel9" runat="server" ForeColor="Red" Text="*">
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
                                        <asp:LinkButton ID="SelectID" Text="Mark/UnMark for Deletion"  OnClientClick="if ( !confirm('Confirm you want to proceed with action ')) return false;" CommandName="Delete" CommandArgument='<%# Eval("ID") %>' runat="server">
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
                            <dx:GridViewDataColumn HeaderStyle-Font-Bold="true" Caption="Update Status">
                                    <DataItemTemplate>
                                        <dx:ASPxLabel Text='<%# Eval("UpdateStatus") %>' runat="server"></dx:ASPxLabel>
                                    </DataItemTemplate>
                            </dx:GridViewDataColumn>
                             <dx:GridViewDataColumn Caption="" VisibleIndex="1">
                               <DataItemTemplate>
                                   <asp:LinkButton ID="ViewDoc1" runat="server" CommandArgument='<%# Eval("ID") %>' CommandName="View Document" Text="View Document">
                                   </asp:LinkButton>
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
                                    <dx:ASPxLabel ID="ASPxLabel11" runat="server" ForeColor="Red" Text="*">
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
                                                            <asp:LinkButton ID="SelectID" Text="Mark/UnMark for deletion"  OnClientClick="if ( !confirm('Confirm you want to proceed with action ')) return false;" CommandName="Delete" CommandArgument='<%# Eval("ID") %>' runat="server">
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
                                                <dx:GridViewDataColumn HeaderStyle-Font-Bold="true" Caption="Update Status">
                                                        <DataItemTemplate>
                                                            <dx:ASPxLabel Text='<%# Eval("UpdateStatus") %>' runat="server"></dx:ASPxLabel>
                                                        </DataItemTemplate>
                                                </dx:GridViewDataColumn>
                                            </Columns>
                                        </dx:ASPxGridView>
                                    </td>
                            </tr> 
           <tr id="panelsaving2a" runat="server" visible="false">
                <td colspan="4">
                    <dx:ASPxLabel ID="ASPxLabel17" runat="server" Font-Names="Cambria" Font-Size="Small" Font-Bold="true" Text="" Theme="Glass">
                    </dx:ASPxLabel>
                   <hr/>
                </td>
            </tr>
           <tr id="panelsaving2" runat="server" visible="false">
                        <td style="width:208px"></td>
                        <td style="width:212px"></td>
                        <td style="width:208px">
                            <dx:ASPxButton ID="ASPxButton5" runat="server" Text="Update" Theme="BlackGlass">
                                <ClientSideEvents Click="function(s,e){ e.processOnServer = confirm('Confirm you want to Update');}" />
                            </dx:ASPxButton>
                        </td>
                        <td style="width:212px">
                            <dx:ASPxButton ID="btnPrint" ValidationGroup="printform" runat="server" Text="Print" Theme="BlackGlass">
                            </dx:ASPxButton>
                        </td>
                </tr> 
                    <tr id="CORP1" runat="server">
                      <td  style="width: 208px">
                          <dx:ASPxLabel ID="ASPxLabel18" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Identification Type" Theme="Glass">
                          </dx:ASPxLabel>
                      </td>
                      <td style="width: 212px">
                          <dx:ASPxComboBox ID="cmbIDTypeCORP" runat="server" Theme="BlackGlass" Width="250px">
                              <Items>
                                  <dx:ListEditItem Text="Certificate of Incorporation Number" Value="Certificate of Incorporation Number" />
                              </Items>
                          </dx:ASPxComboBox>
                      </td>
                      <td style="width: 208px">
                          <dx:ASPxLabel ID="ASPxLabel21" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Incorporation/Registration Number" Theme="Glass">
                          </dx:ASPxLabel>
                      </td>
                      <td style="width: 212px">
                          <dx:ASPxTextBox ID="txtIDNoCORP" runat="server" BackColor="White" MaxLength="50" Theme="BlackGlass" Width="250px">
                          </dx:ASPxTextBox>
                      </td>
                  </tr>
               <tr id="CORP2" runat="server" visible="false">
                    <td colspan="4">
                        <dx:ASPxLabel ID="ASPxLabel24" runat="server" Font-Names="Cambria" Font-Size="Small" Font-Bold="true" Text="Company Details" Theme="Glass">
                        </dx:ASPxLabel>
                       <hr/>
                    </td>
                </tr>
                <tr id="CORP3" runat="server" visible="false">
                    <td style="width: 208px">
                        <dx:ASPxLabel ID="ASPxLabel25" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Name of Company" Theme="Glass">
                        </dx:ASPxLabel>
                        <dx:ASPxLabel ID="ASPxLabel34" runat="server" ForeColor="Red" Text="*">
                        </dx:ASPxLabel>
                    </td>
                    <td style="width: 212px">
                        <dx:ASPxTextBox ID="txtSurnameCORP" runat="server" BackColor="White" Theme="BlackGlass" Width="250px">
                        </dx:ASPxTextBox>
                    </td>
                    <td style="width: 208px">
                        <dx:ASPxLabel ID="ASPxLabel35" runat="server" Font-Names="Cambria" Font-Size="Small"  Text="Account Type" Theme="Glass">
                        </dx:ASPxLabel>
                        <dx:ASPxLabel ID="ASPxLabel36" runat="server" ForeColor="Red" Text="*">
                        </dx:ASPxLabel>
                    </td>
                    <td style="width: 212px">
                        <dx:ASPxComboBox ID="cmbTypeofAccountCORP" AutoPostBack="true" runat="server" Theme="BlackGlass" ValueType="System.String" Width="250px" CallbackPageSize="15" EnableCallbackMode="True" DropDownStyle="DropDownList"  IncrementalFilteringMode="Contains"  AnimationType="Slide">
                            <Items>
                                <dx:ListEditItem Text="Custody" Value="Custody" />
                                <dx:ListEditItem Text="Trustee" Value="Trustee" />
                                <dx:ListEditItem Text="Unit Trust" Value="Unit Trust" />
                            </Items>
                        </dx:ASPxComboBox>
                    </td>
                </tr>
            <tr id="CORP3a" runat="server" visible="false">
                <td style="width: 208px">
                        <dx:ASPxLabel ID="ASPxLabel106" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Billing Profile" Theme="Glass">
                        </dx:ASPxLabel>
                        <dx:ASPxLabel ID="ASPxLabel107" runat="server" ForeColor="Red" Text="*">
                        </dx:ASPxLabel>
                    </td>
                    <td style="width: 212px">
                        <dx:ASPxComboBox ID="cmbBillingProfileCORP" runat="server" Theme="BlackGlass" ValueType="System.String" Width="250px" CallbackPageSize="15" EnableCallbackMode="True" DropDownStyle="DropDownList"  IncrementalFilteringMode="Contains"  AnimationType="Slide">
                        </dx:ASPxComboBox>
                    </td>
                    <td style="width: 208px">
                         <dx:ASPxLabel ID="ASPxLabel5" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Bill Cash Account" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td style="width: 212px">
                        <table width="100%">
                            <tr>
                                 <td>
                                   <asp:CheckBox ID="chkBillCashAccountCORP" runat="server" AutoPostBack ="false"/>
                                 </td>
                                 <td>
                                     <dx:ASPxLabel ID="ASPxLabel128" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Currency" Theme="Glass">
                                    </dx:ASPxLabel>
                                 </td>
                                 <td>
                                    <dx:ASPxComboBox ID="cmbBillingCurrencyCORP" runat="server" Width="110px" Theme="BlackGlass" ValueType="System.String" CallbackPageSize="15" EnableCallbackMode="True" DropDownStyle="DropDownList"  IncrementalFilteringMode="Contains"  AnimationType="Slide">
                                    </dx:ASPxComboBox>
                                 </td>
                            </tr>
                        </table>
                    </td>
            </tr>
            <tr id="CORP3ac" runat="server" visible="false">
                    <td style="width: 208px">
                        <dx:ASPxLabel ID="ASPxLabel122" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Classification" Theme="Glass">
                        </dx:ASPxLabel>
                        <dx:ASPxLabel ID="ASPxLabel123" runat="server" ForeColor="Red" Text="*">
                        </dx:ASPxLabel>
                    </td>
                    <td style="width: 212px">
                        <dx:ASPxComboBox ID="cmbClassificationCORP" runat="server" Theme="BlackGlass" ValueType="System.String" Width="250px" CallbackPageSize="15" EnableCallbackMode="True" DropDownStyle="DropDownList"  IncrementalFilteringMode="Contains"  AnimationType="Slide">
                        </dx:ASPxComboBox>
                    </td>
            </tr>
                <tr id="CORP4" runat="server" visible="false">
                    <td colspan="4">
                        <dx:ASPxLabel ID="ASPxLabel37" runat="server" Font-Names="Cambria" Font-Size="Small" Font-Bold="true" Text="Registered Office/Head Office Address" Theme="PlasticBlue">
                        </dx:ASPxLabel>
                       <hr/>
                    </td>
                </tr>
             <tr id="CORP5" runat="server" visible="false">
               <td style="width: 208px">
                   <dx:ASPxLabel ID="ASPxLabel38" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Physical Address" Theme="Glass">
                   </dx:ASPxLabel>
                   <dx:ASPxLabel ID="ASPxLabel40" runat="server" ForeColor="Red" Text="*">
                   </dx:ASPxLabel>
               </td>
               <td style="width: 212px">
                   <dx:ASPxTextBox ID="txtAddress1CORP" runat="server" BackColor="White" Theme="BlackGlass" Width="250px">
                   </dx:ASPxTextBox>
               </td>
                    <td style="width: 208px">
                        <dx:ASPxLabel ID="ASPxLabel67" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Postal Address" Theme="Glass">
                   </dx:ASPxLabel>
                        <dx:ASPxLabel ID="ASPxLabel41" runat="server" ForeColor="Red" Text="*">
                        </dx:ASPxLabel>
                        </td>
                <td style="width: 212px">
                    <dx:ASPxTextBox ID="txtAddress2CORP" runat="server" BackColor="White" Theme="BlackGlass" Width="250px">
                    </dx:ASPxTextBox>
                    </td>
           </tr>
                <tr id="CORP6" runat="server" visible="false">
                    <td style="width: 208px">
                        <dx:ASPxLabel ID="ASPxLabel42" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Country of Registration" Theme="Glass">
                        </dx:ASPxLabel>
                        <dx:ASPxLabel ID="ASPxLabel59" runat="server" ForeColor="Red" Text="*">
                        </dx:ASPxLabel>
                    </td>
                <td style="width: 212px">
                    <dx:ASPxComboBox ID="cmbCountryCORP" runat="server" Theme="BlackGlass" ValueType="System.String" Width="250px" PopupVerticalAlign="TopSides" IncrementalFilteringMode="Contains" AnimationType="Slide">
                    </dx:ASPxComboBox>
                    </td>
                    <td style="width: 208px">
                        <dx:ASPxLabel ID="ASPxLabel43" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Country of Tax Residence" Theme="Glass">
                        </dx:ASPxLabel>
                        <dx:ASPxLabel ID="ASPxLabel45" runat="server" ForeColor="Red" Text="*">
                        </dx:ASPxLabel>
                    </td>
                    <td style="width: 212px">
                        <dx:ASPxComboBox ID="cmbCountryTaxResidenceCORP" runat="server" Theme="BlackGlass" ValueType="System.String" Width="250px" IncrementalFilteringMode="Contains" AnimationType="Slide">
                        </dx:ASPxComboBox>
                    </td>
            </tr>
                <tr id="CORP7" runat="server" visible="false">
                       <td style="width: 208px">
                        <dx:ASPxLabel ID="ASPxLabel46" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Nature of Business" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td style="width: 212px">
                        <dx:ASPxTextBox ID="txtNatureOfBusinessCORP" runat="server" BackColor="White" Theme="BlackGlass" Width="250px">
                        </dx:ASPxTextBox>
                    </td>
                    <td style="width: 208px">
                        <dx:ASPxLabel ID="ASPxLabel47" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Date of Incorporation" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td style="width: 212px">
                        <dx:ASPxDateEdit ID="txtDOBCORP" runat="server" EditFormat="Custom" EditFormatString="dd MMMM yyyy" Theme="BlackGlass" Width="250px">
                        </dx:ASPxDateEdit>
                    </td>
                </tr>
                <tr id="CORP8" runat="server" visible="false">
                    <td style="width: 208px">
                        <dx:ASPxLabel ID="ASPxLabel48" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Source of Funds" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td style="width: 212px">
                        <dx:ASPxTextBox ID="txtSourceofFundsCORP" runat="server" BackColor="White" Theme="BlackGlass" Width="250px">
                        </dx:ASPxTextBox>
                    </td>
                    <td style="width: 208px">
                        <dx:ASPxLabel ID="ASPxLabel53" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Investor Type" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td style="width: 212px">
                        <dx:ASPxComboBox ID="cmbInvestorTypeCORP" runat="server" Theme="BlackGlass" ValueType="System.String" Width="250px" IncrementalFilteringMode="Contains" AnimationType="Slide">
                            <Items>
                                <dx:ListEditItem Text="" Value="" />
                                <dx:ListEditItem Text="Local Investor" Value="Local Investor" />
                                <dx:ListEditItem Text="Foreign Investor" Value="Foreign Investor" />
                            </Items>
                        </dx:ASPxComboBox>
                    </td>
                </tr>
              <tr id="CORP8a" runat="server" visible="false">
                <td colspan="4">
                    <dx:ASPxLabel ID="ASPxLabel112" runat="server" Font-Names="Cambria" Font-Size="Small" Font-Bold="true" Text="Fund" Theme="Glass">
                    </dx:ASPxLabel>
                   <hr/>
                </td>
            </tr>
           <tr id="CORP8ab" runat="server" visible="false">
              <td style="width: 208px">
                    <dx:ASPxLabel ID="ASPxLabel114" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Select Fund" Theme="Glass">
                    </dx:ASPxLabel>
                        <dx:ASPxLabel ID="ASPxLabel115" runat="server" ForeColor="Red" Text="*">
                        </dx:ASPxLabel>
                </td>
                <td style="width: 212px">
                    <dx:ASPxComboBox ID="cmbUnitTrustFundCORP" AutoPostBack="false" runat="server" Theme="BlackGlass" ValueType="System.String" Width="250px" CallbackPageSize="15" EnableCallbackMode="True" DropDownStyle="DropDownList"  IncrementalFilteringMode="Contains"  AnimationType="Slide">
                    </dx:ASPxComboBox>
                </td>
           </tr>
           <tr id="CORP8b" runat="server" visible="false">
                <td colspan="4">
                    <dx:ASPxLabel ID="ASPxLabel96" runat="server" Font-Names="Cambria" Font-Size="Small" Font-Bold="true" Text="Asset Manager/s" Theme="Glass">
                    </dx:ASPxLabel>
                   <hr/>
                </td>
            </tr>
           <tr id="CORP8c" runat="server" visible="false">
                <td style="width: 208px">
                    <dx:ASPxLabel ID="ASPxLabel98" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Asset Manager" Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                <td style="width: 212px">
                    <dx:ASPxComboBox ID="cmbAssetManagerCORP" AutoPostBack="true" runat="server" Theme="BlackGlass" ValueType="System.String" Width="250px" CallbackPageSize="15" EnableCallbackMode="True" DropDownStyle="DropDownList"  IncrementalFilteringMode="Contains"  AnimationType="Slide">
                    </dx:ASPxComboBox>
                </td>
             <td colspan="2">
          <asp:Panel ID="dfPanel2CORP" runat="server" ScrollBars="Vertical" Visible="false">
            <asp:Repeater ID="grdSelectFromAssetmanagersCORP" runat="server">
                <HeaderTemplate>
                   <table style="margin-left: 10px; font-family:Cambria; font-size:small;" id="table_example2CORP">
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
                                  <th align="left" style="width:100px">
                                    <asp:Label ID="Label4" runat="server" Text="AccountName"></asp:Label>
                                </th>
                                  <th align="left" style="width:100px">
                                    <asp:Label ID="Label3" runat="server" Text="Currency"></asp:Label>
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
                                  <td>
                                    <asp:Label ID="lblAccountName" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "AccountName")%>'></asp:Label>
                                </td>
                                  <td>
                                    <asp:Label ID="lblCurrency" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Currency")%>'></asp:Label>
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
           
           <tr id="CORP8D" runat="server" visible="false">
                    <td style="width:208px">
                        <dx:ASPxLabel ID="ASPxLabel100" runat="server" Font-Names="Cambria" Font-Size="Small" Text="CDC Number" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                        <td style="width:212px">
                            <dx:ASPxTextBox ID="txtcdcnumberCORP" runat="server" BackColor="White" Theme="BlackGlass" Width="250px">
                            </dx:ASPxTextBox>
                        </td>
                    <td style="width:208px">
                        <dx:ASPxLabel ID="ASPxLabel130" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Inter Company A/c" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                        <td style="width:212px">
                           <dx:ASPxComboBox ID="cmbInterCompanyAccountCORP" runat="server" Theme="BlackGlass" ValueType="System.String" Width="250px" CallbackPageSize="15" EnableCallbackMode="True" DropDownStyle="DropDownList"  IncrementalFilteringMode="Contains"  AnimationType="Slide">
                    </dx:ASPxComboBox>
                        </td>
                </tr> 
            <tr id="CORP8Dz" runat="server" visible="false">
                <td style="width:208px">&nbsp;</td>
                <td colspan="3">
                    <dx:ASPxButton ID="btnAddAMsCORP" runat="server" Text="Add" Theme="BlackGlass" ValidationGroup="addams">
                    </dx:ASPxButton>
                </td>
            </tr>
            <tr id="CORP8Dx" runat="server" visible="false">
                <td style="width:208px"></td>
                <td colspan="3">
                    <dx:ASPxGridView ID="grdAsertManagersClientsCORP" runat="server" KeyFieldName="ID" Theme="Glass" Width="470px">
                        <Columns>
                            <dx:GridViewDataColumn VisibleIndex="0">
                                <DataItemTemplate>
                                    <asp:LinkButton ID="SelectID" runat="server" CommandArgument='<%# Eval("ID") %>' CommandName="Delete" OnClientClick="if ( !confirm('Confirm you want to proceed with action')) return false;" Text="Mark/UnMark for Deletion">
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
                               <dx:GridViewDataColumn Caption="Account Name" HeaderStyle-Font-Bold="true">
                               <DataItemTemplate>
                                   <dx:ASPxLabel runat="server" Text='<%# Eval("AccountName") %>'>
                                   </dx:ASPxLabel>
                               </DataItemTemplate>
                           </dx:GridViewDataColumn>
                               <dx:GridViewDataColumn Caption="Currency" HeaderStyle-Font-Bold="true">
                               <DataItemTemplate>
                                   <dx:ASPxLabel runat="server" Text='<%# Eval("Currency") %>'>
                                   </dx:ASPxLabel>
                               </DataItemTemplate>
                           </dx:GridViewDataColumn>
                               <dx:GridViewDataColumn Caption="CDC Number" HeaderStyle-Font-Bold="true">
                               <DataItemTemplate>
                                   <dx:ASPxLabel runat="server" Text='<%# Eval("cdcnumber") %>'>
                                   </dx:ASPxLabel>
                               </DataItemTemplate>
                           </dx:GridViewDataColumn>
                               <dx:GridViewDataColumn Caption="Update Status" HeaderStyle-Font-Bold="true">
                               <DataItemTemplate>
                                   <dx:ASPxLabel runat="server" Text='<%# Eval("UpdateStatus") %>'>
                                   </dx:ASPxLabel>
                               </DataItemTemplate>
                           </dx:GridViewDataColumn>
                               <dx:GridViewDataColumn Caption="InterCompany A/C" HeaderStyle-Font-Bold="true">
                               <DataItemTemplate>
                                   <dx:ASPxLabel runat="server" Text='<%# Eval("DispInterAccNumber") %>'>
                                   </dx:ASPxLabel>
                               </DataItemTemplate>
                           </dx:GridViewDataColumn>
                        </Columns>
                    </dx:ASPxGridView>
                </td>
            </tr>
           <tr id="CORP8E" runat="server" visible="false">
               <td style="width:208px">
                   &nbsp;</td>
               <td colspan="3">
                   &nbsp;</td>
           </tr>
                <tr id="CORP9" runat="server" visible="false">
                <td colspan="4">
                    <dx:ASPxLabel ID="ASPxLabel55" runat="server" Font-Names="Cambria" Font-Size="Small" Font-Bold="true" Text="Contact Person's Details (authorized representative)" Theme="PlasticBlue">
                    </dx:ASPxLabel>
                   <hr/>
                </td>
            </tr>
                <tr id="CORP10" runat="server" visible="false">
                    <td style="width: 208px">
                        <dx:ASPxLabel ID="ASPxLabel57" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Full Name of Contact Person" Theme="Glass">
                        </dx:ASPxLabel>
                        <dx:ASPxLabel ID="ASPxLabel60" runat="server" ForeColor="Red" Text="*">
                        </dx:ASPxLabel>
                    </td>
                    <td style="width: 212px">
                        <dx:ASPxTextBox ID="txtfullnameCORP" runat="server" BackColor="White" Theme="BlackGlass" Width="250px">
                        </dx:ASPxTextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtfullnameCORP" Display="None" ErrorMessage="fullname Required" ValidationGroup="Submit"></asp:RequiredFieldValidator>
                    </td>
                    <td style="width: 208px">
                        <dx:ASPxLabel ID="ASPxLabel61" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Telephone" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                <td style="width: 212px">
                    <dx:ASPxTextBox ID="txtTelCORP" runat="server" BackColor="White" Theme="BlackGlass" Width="250px">
                    </dx:ASPxTextBox>
                    </td>
                </tr>
            <tr id="CORP11" runat="server" visible="false">
                <td style="width: 208px">
                        <dx:ASPxLabel ID="ASPxLabel64" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Fax" Theme="Glass">
                    </dx:ASPxLabel>
                    </td>
                <td style="width: 212px">
                    <dx:ASPxTextBox ID="txtFaxCORP" runat="server" BackColor="White" Theme="BlackGlass" Width="250px">
                    </dx:ASPxTextBox>
                    </td>
                <td style="width: 208px">
                    <dx:ASPxLabel ID="ASPxLabel68" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Email Address" Theme="Glass">
                    </dx:ASPxLabel>
                    <dx:ASPxLabel ID="ASPxLabel71" runat="server" ForeColor="Red" Text="*">
                    </dx:ASPxLabel>
                </td>
                <td style="width: 212px">
                    <dx:ASPxTextBox ID="txtEmailCORP" runat="server" BackColor="White" Theme="BlackGlass" Width="250px">
                         <ValidationSettings ErrorText="Invalid Email" SetFocusOnError="True">
                                <RegularExpression ErrorText="Invalid Email" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" />
                                <RequiredField IsRequired="True" />
                            </ValidationSettings>
                    </dx:ASPxTextBox>
                </td>
            </tr>
                <tr id="CORP12" runat="server" visible="false">
                <td colspan="4">
                    <dx:ASPxLabel ID="ASPxLabel75" runat="server" Font-Names="Cambria" Font-Size="Small" Font-Bold="true" Text="Banking Details" Theme="PlasticBlue">
                    </dx:ASPxLabel>
                   <hr/>
                </td>
            </tr>
             <tr id="CORPTr3" runat="server" visible="false">
                <td style="width:208px">
                    <dx:ASPxLabel ID="ASPxLabel101" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Bank Type" Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                <td style="width:212px">
                    <dx:ASPxComboBox ID="cmbBankCatCORP" runat="server" AutoPostBack="True" Theme="BlackGlass" ValueType="System.String" Width="250px" CallbackPageSize="15" EnableCallbackMode="True" DropDownStyle="DropDownList"  IncrementalFilteringMode="Contains"  AnimationType="Slide">
                        <Items>
                            <dx:ListEditItem Text="Local Bank" Value="Local Bank" Selected="true" />
                            <dx:ListEditItem Text="Foreign Bank" Value="Foreign Bank" />
                        </Items>
                    </dx:ASPxComboBox>
                </td>
            </tr>
                         <tr id="CORP13" runat="server" visible="false">
                               <td style="width: 208px">
                                   <dx:ASPxLabel ID="ASPxLabel76" Visible="true"   runat="server" Font-Names="Cambria" Font-Size="Small" Text="Account Name" Theme="Glass">
                                   </dx:ASPxLabel>
                                   <dx:ASPxLabel ID="ASPxLabel91"  Visible="true"   runat="server" ForeColor="Red" Text="*">
                                   </dx:ASPxLabel>
                               </td>
                               <td style="width: 212px">
                                   <dx:ASPxTextBox ID="txtPayee2CORP" Visible="true" runat="server" BackColor="White" Theme="BlackGlass" Width="250px">
                                   </dx:ASPxTextBox>
                               </td>
                               <td style="width: 208px">
                                   <dx:ASPxLabel ID="ASPxLabel77" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Account No." Theme="Glass">
                                   </dx:ASPxLabel>
                                   <dx:ASPxLabel ID="ASPxLabel80" runat="server" ForeColor="Red" Text="*">
                                   </dx:ASPxLabel>
                               </td>
                               <td style="width: 212px">
                                   <dx:ASPxTextBox ID="txtIBANCORP" runat="server" BackColor="White" Theme="BlackGlass" Width="250px">
                                   </dx:ASPxTextBox></td>
                           </tr>
                           <tr id="CORP14" runat="server" visible="false">
                               <td style="width: 208px">
                                   <dx:ASPxLabel ID="ASPxLabel83" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Bank Name" Theme="Glass">
                                   </dx:ASPxLabel>
                                   <dx:ASPxLabel ID="ASPxLabel92" runat="server" ForeColor="Red" Text="*">
                                   </dx:ASPxLabel>
                               </td>
                               <td style="width: 212px">
                                   <dx:ASPxComboBox ID="cmbBankDivCORP" runat="server" AutoPostBack="False" Theme="BlackGlass" ValueType="System.String" Width="250px" CallbackPageSize="15" EnableCallbackMode="True" DropDownStyle="DropDownList"  IncrementalFilteringMode="Contains"  AnimationType="Slide">
                                   </dx:ASPxComboBox>
                                    <dx:ASPxTextBox ID="txtBankForeignCORP" Visible="false" runat="server" BackColor="White" Theme="BlackGlass" Width="250px">
                                    </dx:ASPxTextBox>
                               </td>
                               <td style="width: 208px">
                                   <dx:ASPxLabel ID="ASPxLabel84" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Branch" Theme="Glass">
                                   </dx:ASPxLabel>
                                   <dx:ASPxLabel ID="ASPxLabel88" runat="server" ForeColor="Red" Text="*">
                                   </dx:ASPxLabel>
                               </td>
                               <td style="width: 212px">
                                   <dx:ASPxTextBox ID="txtBranchDivCORP" Visible="true" runat="server" BackColor="White" Theme="BlackGlass" Width="250px">
                                   </dx:ASPxTextBox>
                               </td>
                           </tr>
                           <tr id="CORP15" runat="server" visible="false">
                               <td style="width: 208px">
                                   <dx:ASPxLabel ID="ASPxLabel85" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Bank Address (If Foreign)" Theme="Glass">
                                   </dx:ASPxLabel>
                               </td>
                               <td style="width: 212px">
                                 <dx:ASPxTextBox ID="txtBankAddressCORP" runat="server" BackColor="White" Theme="BlackGlass" Width="250px">
                                    </dx:ASPxTextBox>
                               </td>
                                <td style="width: 208px">
                                    <dx:ASPxLabel ID="ASPxLabel86" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Swift Code (If Foreign)" Theme="Glass">
                                    </dx:ASPxLabel>
                                </td>
                                <td style="width: 212px">
                                    <dx:ASPxTextBox ID="txtSwiftCodeCORP" runat="server" BackColor="White" Theme="BlackGlass" Width="250px">
                                    </dx:ASPxTextBox>
                                </td>
                           </tr>
             <tr id="CORP17" runat="server" visible="false">
                <td colspan="4">
                    <dx:ASPxLabel ID="ASPxLabel87" runat="server" Font-Names="Cambria" Font-Size="Small" Font-Bold="true" Text="Attachments" Theme="PlasticBlue">
                    </dx:ASPxLabel>
                   <hr/>
                </td>
            </tr>
                           <tr id="CORP18" runat="server" visible="false">
                               <td style="width: 208px">
                                   <dx:ASPxLabel ID="ASPxLabel89" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Document Name" Theme="Glass">
                                   </dx:ASPxLabel>
                                    <dx:ASPxLabel ID="ASPxLabel90" runat="server" ForeColor="Red" Text="*">
                                    </dx:ASPxLabel>
                               </td>
                               <td style="width: 212px">
                                   <dx:ASPxComboBox ID="txtdocumentnameCORP" runat="server" AnimationType="Slide" AutoPostBack="True" CallbackPageSize="15" DropDownStyle="DropDownList" EnableCallbackMode="True" IncrementalFilteringMode="Contains" Theme="BlackGlass" ValueType="System.String" Width="250px">
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
                                   <dx:ASPxTextBox ID="txtotherdocCORP" runat="server" BackColor="White" Theme="BlackGlass" Width="250px" Visible="False">
                                   </dx:ASPxTextBox>
                               </td>
                               <td style="width: 208px">
                                   <dx:ASPxLabel ID="ASPxLabel93" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Select Document" Theme="Glass">
                                   </dx:ASPxLabel>
                               </td>
                               <td style="width: 212px">
                                   <asp:FileUpload ID="FileUpload1CORP" runat="server" />
                               </td>
                           </tr>
                           <tr id="CORP19" runat="server" visible="false">
                               <td style="width: 208px"></td>
                               <td style="width: 212px">
                                   <dx:ASPxButton ID="ASPxButton10CORP" ValidationGroup="uploadCoop" runat="server" Text="Upload" Theme="BlackGlass">
                                   </dx:ASPxButton>
                                   &nbsp;</td>
                           </tr>
                           <tr id="CORP20" runat="server" visible="false">
                               <td align="center" colspan="4">
                                   <dx:ASPxGridView ID="ASPxGridView1CORP" runat="server" KeyFieldName="ID" Theme="Glass">
                                       <Columns >
                                        <dx:GridViewDataColumn VisibleIndex="0">
                                                <DataItemTemplate>
                                                    <asp:LinkButton ID="SelectID" Text="Mark/UnMark for Deletion"  OnClientClick="if ( !confirm('Confirm you want to proceed with action ')) return false;" CommandName="Delete" CommandArgument='<%# Eval("ID") %>' runat="server">
                                                    </asp:LinkButton>
                                                </DataItemTemplate>
                                        </dx:GridViewDataColumn>
                                        <dx:GridViewDataColumn HeaderStyle-Font-Bold="true" Caption="ID">
                                                <DataItemTemplate>
                                                    <dx:ASPxLabel ID="ASPxLabel1" Text='<%# Eval("ID") %>' runat="server"></dx:ASPxLabel>
                                                </DataItemTemplate>
                                        </dx:GridViewDataColumn>
                                        <dx:GridViewDataColumn HeaderStyle-Font-Bold="true" Caption="Name">
                                                <DataItemTemplate>
                                                    <dx:ASPxLabel ID="ASPxLabel2" Text='<%# Eval("name") %>' runat="server"></dx:ASPxLabel>
                                                </DataItemTemplate>
                                        </dx:GridViewDataColumn>
                                        <dx:GridViewDataColumn HeaderStyle-Font-Bold="true" Caption="Content Type">
                                                <DataItemTemplate>
                                                    <dx:ASPxLabel ID="ASPxLabel3" Text='<%# Eval("contenttype") %>' runat="server"></dx:ASPxLabel>
                                                </DataItemTemplate>
                                        </dx:GridViewDataColumn>
                                        <dx:GridViewDataColumn HeaderStyle-Font-Bold="true" Caption="Update Status">
                                                <DataItemTemplate>
                                                    <dx:ASPxLabel ID="ASPxLabel3qa" Text='<%# Eval("UpdateStatus") %>' runat="server"></dx:ASPxLabel>
                                                </DataItemTemplate>
                                        </dx:GridViewDataColumn>
                                         <dx:GridViewDataColumn Caption="" VisibleIndex="1">
                                           <DataItemTemplate>
                                               <asp:LinkButton ID="ViewDoc1" runat="server" CommandArgument='<%# Eval("ID") %>' CommandName="View Document" Text="View Document">
                                               </asp:LinkButton>
                                           </DataItemTemplate>
                                       </dx:GridViewDataColumn>
                                    </Columns>
                                   </dx:ASPxGridView>
                               </td>
                           </tr>
              <tr id="CORP21" runat="server" visible="false">
                <td colspan="4" align ="center">
                    <dx:ASPxLabel ID="ASPxLabel94" runat="server" Font-Names="Cambria" Font-Size="Small" Font-Bold="true" Text="" Theme="PlasticBlue">
                    </dx:ASPxLabel>
                   <hr/>
                </td>
            </tr>
                <tr id="CORP22" runat="server" visible="false">
                        <td colspan ="4" align ="center">
                            <dx:ASPxButton ID="ASPxButton9CORP" runat="server" Text="Update" Theme="BlackGlass">
                        <ClientSideEvents Click="function(s,e){ e.processOnServer = confirm('Confirm you want to Update');}" />
                                  </dx:ASPxButton>
                            &nbsp;
                            <dx:ASPxButton ID="btnPrintCORP" ValidationGroup="printformCORP" runat="server" Text="Print" Theme="BlackGlass">
                            </dx:ASPxButton>
                        </td>
                </tr>
       
          
           <tr id="Tr2" runat="server" visible="true">
                 <td style="width:208px"></td>
            </tr>
            <tr id="Tr2w" runat="server" visible="true">
                 <td style="width:208px"></td>
            </tr>
            <tr>
                    <td align="center">
                        <dx:ASPxPopupControl ID="ASPxPopupControl2x"  runat="server" BackColor="#DDECFE" CloseAction="CloseButton"  PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" EnableCallbackAnimation="True" HeaderText="CDC Number already captured" ShowCollapseButton="True" ShowPageScrollbarWhenModal="True" ShowPinButton="True" Theme="Office2010Blue" Width="400px">
                            <contentcollection>
                                <dx:PopupControlContentControl runat="server" SupportsDisabledAttribute="True">
                                    <dx:ASPxRoundPanel ID="ASPxRoundPanel1x" BackColor="White" runat="server" ShowHeader="False"  Width="100%">
                                         <panelcollection>
                                           <dx:PanelContent runat="server" SupportsDisabledAttribute="True">
                                              <table  style="width: 100%">
                                                  <tr>
                                                    <td align="center" style="height: 57px">
                                                        <dx:ASPxLabel ID="ASPxLabel102" runat="server" Text="CDC Number already captured, proceed to Submit" Theme="iOS">
                                                        </dx:ASPxLabel>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" ></td>
                                                    <td align="left">
                                                        <dx:ASPxButton ID="btnYes" runat="server" CausesValidation="False" Text="Yes" Theme="Glass">
                                                        </dx:ASPxButton>
                                                    </td>
                                                    <td align="left">
                                                        <dx:ASPxButton ID="btnNo" runat="server" CausesValidation="False" Text="No" Theme="Glass">
                                                        </dx:ASPxButton>
                                                    </td>
                                                </tr>
                                            </table>
                                        </dx:PanelContent>
                                    </panelcollection>
                                </dx:ASPxRoundPanel>
                            </dx:PopupControlContentControl>
                        </contentcollection>
                    </dx:ASPxPopupControl>
                  </td>
                </tr>

             <tr>
                    <td align="center">
                        <dx:ASPxPopupControl ID="ASPxPopupControl2CORPX"  runat="server" BackColor="#DDECFE" CloseAction="CloseButton"  PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" EnableCallbackAnimation="True" HeaderText="CDC Number already captured" ShowCollapseButton="True" ShowPageScrollbarWhenModal="True" ShowPinButton="True" Theme="Office2010Blue" Width="400px">
                            <contentcollection>
                                <dx:PopupControlContentControl runat="server" SupportsDisabledAttribute="True">
                                    <dx:ASPxRoundPanel ID="ASPxRoundPanel1CORPX" BackColor="White" runat="server" ShowHeader="False"  Width="100%">
                                         <panelcollection>
                                           <dx:PanelContent runat="server" SupportsDisabledAttribute="True">
                                              <table  style="width: 100%">
                                                  <tr>
                                                    <td align="center" style="height: 57px">
                                                        <dx:ASPxLabel ID="ASPxLabel103" runat="server" Text="CDC Number already captured, proceed to Submit" Theme="iOS">
                                                        </dx:ASPxLabel>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" ></td>
                                                    <td align="left">
                                                        <dx:ASPxButton ID="btnYesCORP" runat="server" CausesValidation="False" Text="Yes" Theme="Glass">
                                                        </dx:ASPxButton>
                                                    </td>
                                                    <td align="left">
                                                        <dx:ASPxButton ID="btnNoCORP" runat="server" CausesValidation="False" Text="No" Theme="Glass">
                                                        </dx:ASPxButton>
                                                    </td>
                                                </tr>
                                            </table>
                                        </dx:PanelContent>
                                    </panelcollection>
                                </dx:ASPxRoundPanel>
                            </dx:PopupControlContentControl>
                        </contentcollection>
                    </dx:ASPxPopupControl>
                  </td>
                </tr>

         </table> 
    </asp:Panel>
</asp:Content>

