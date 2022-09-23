<%@ Page Language="VB" MasterPageFile="~/CDSUser.master" AutoEventWireup="false" CodeFile="AccountsVerification.aspx.vb" Inherits="CDSMode_AccountsVerification" title="Account Verification" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<asp:Content id="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Panel id="Panel1" runat="server" Width="100%" Font-Names="Cambria" BackColor="White" GroupingText="Pending Verification Accounts">
       <table>
           <tr> 
              <td style="width: 208px">
                  <dx:ASPxLabel ID="ASPxLabel56" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Select Account" Theme="Glass">
                                </dx:ASPxLabel>
                            </td>
                        <td style="width: 212px">
                            <dx:ASPxComboBox ID="cmbPendingAccounts" runat="server" Theme="BlackGlass" ValueType="System.String" AnimationType="Slide" IncrementalFilteringMode="Contains" AutoPostBack="True" Width="250px">
                            </dx:ASPxComboBox>
                            </td>
                    </tr>
           <tr id="Tr4" runat="server">
                <td colspan="4">
                    <dx:ASPxLabel ID="ASPxLabel3" runat="server" Font-Names="Cambria" Font-Size="Small" Font-Bold="true" Text="" Theme="Glass">
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
                            <dx:ASPxTextBox ID="TXTClientID" runat="server" BackColor="#E4E4E4" ReadOnly="True" Theme="BlackGlass" Width="250px">
                                </dx:ASPxTextBox>
                            </td>
                            <td style="width: 208px">
                                <dx:ASPxLabel ID="ASPxLabel14" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Entry Type" Theme="Glass">
                                </dx:ASPxLabel>
                            </td>
                        <td style="width: 212px">
                            <dx:ASPxLabel ID="lblUpdateType" runat="server">
                            </dx:ASPxLabel>
                            </td>
                    </tr>
           <tr id="pnhide" runat="server" visible="false">
                        <td style="width: 208px"></td>
                    <td colspan ="3" align="center">
                        <dx:ASPxLabel ID="ASPxLabel59" runat="server" Font-Italic="True" Font-Size="X-Small" ForeColor="Red" Text="*NB Highlighted fields indicate the updated sections on an account amendment" Theme="Office2003Blue">
                        </dx:ASPxLabel>
                        </td>
                </tr>
           <tr id="Panel10g" runat="server">
                <td style="width: 208px">
                    <dx:ASPxLabel ID="ASPxLabel1" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Account Type" Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                <td style="width: 212px">
                    <dx:ASPxTextBox ID="rdAccountType" runat="server" ReadOnly="true" BackColor="#E4E4E4" MaxLength="50" Theme="Glass" Width="250px">
                          </dx:ASPxTextBox>
                </td>
                <td style="width: 208px">
                    <dx:ASPxLabel ID="ASPxLabel15" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Created/Updated By" Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                <td style="width: 212px">
                    <dx:ASPxTextBox ID="txtUpdateBy" runat="server" ReadOnly="true" BackColor="#E4E4E4" MaxLength="50" Theme="Glass" Width="250px">
                          </dx:ASPxTextBox>
                </td>
            </tr> 
           <tr id="Panel13a" runat="server">
                      <td style="width: 208px">
                          <dx:ASPxLabel ID="ASPxLabel31" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Identification Type" Theme="Glass">
                          </dx:ASPxLabel>
                      </td>
                      <td style="width: 212px">
                          <dx:ASPxTextBox ID="cmbIDType" runat="server" ReadOnly="true" BackColor="#E4E4E4" MaxLength="50" Theme="Glass" Width="250px">
                          </dx:ASPxTextBox>
                      </td>
                      <td style="width: 208px">
                          <dx:ASPxLabel ID="ASPxLabel30" runat="server" Font-Names="Cambria" Font-Size="Small" Text="National ID No./Passport No." Theme="Glass">
                          </dx:ASPxLabel>
                      </td>
                      <td style="width: 212px">
                          <dx:ASPxTextBox ID="txtIDNo" runat="server" ReadOnly="true" BackColor="#E4E4E4" MaxLength="50" Theme="Glass" Width="250px">
                          </dx:ASPxTextBox>
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
                    </td>
                    <td style="width: 212px">
                        <dx:ASPxTextBox ID="txtSurname0" runat="server" ReadOnly="true" BackColor="#E4E4E4" Theme="Glass" Width="250px">
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
                            <dx:ASPxTextBox ID="cmbTitle" runat="server" BackColor="#E4E4E4" ReadOnly="True" Theme="BlackGlass" Width="250px">
                                </dx:ASPxTextBox>
                    </td>
                    <td style="width: 208px">
                        <dx:ASPxLabel ID="ASPxLabel138" runat="server" Font-Names="Cambria" Font-Size="Small" Text="National ID No." Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td style="width: 212px">
                        <dx:ASPxTextBox ID="txtCNIC" runat="server" BackColor="#E4E4E4" ReadOnly="True" Theme="BlackGlass" Width="250px">
                        </dx:ASPxTextBox>
                    </td>
                </tr>
           <tr id="Panel8d" runat="server" visible="false">
                    <td style="width: 208px">
                        <dx:ASPxLabel ID="ASPxLabel5" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Forenames" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td style="width: 212px">
                        <dx:ASPxTextBox ID="txtOthernames" runat="server" BackColor="#E4E4E4" ReadOnly="True" Theme="BlackGlass" Width="250px">
                        </dx:ASPxTextBox>
                    </td>
                    <td style="width: 208px">
                        <dx:ASPxLabel ID="ASPxLabel26" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Surname" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td style="width: 212px">
                        <dx:ASPxTextBox ID="txtSurname" runat="server" BackColor="#E4E4E4" ReadOnly="True" Theme="BlackGlass" Width="250px">
                        </dx:ASPxTextBox>
                    </td>
                </tr>
           <tr id="Panel8l" runat="server" visible="false">
                    <td style="width: 208px">
                        <dx:ASPxLabel ID="ASPxLabel32" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Date Of Birth" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td style="width: 212px">
                        <dx:ASPxTextBox ID="txtDOB" runat="server" BackColor="#E4E4E4" ReadOnly="True" Theme="BlackGlass" Width="250px">
                        </dx:ASPxTextBox>
                    </td>
                    <td style="width: 208px">
                        <dx:ASPxLabel ID="ASPxLabel33" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Gender" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td style="width: 212px;">
                        <dx:ASPxTextBox ID="txtGender" runat="server" BackColor="#E4E4E4" ReadOnly="True" Theme="BlackGlass" Width="250px">
                        </dx:ASPxTextBox>
                    </td>
                </tr>
           <tr id="Panel8f" runat="server" visible="false">
                    <td style="width: 208px">
                        <dx:ASPxLabel ID="ASPxLabel27" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Type of Account" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td style="width: 212px">
                        <dx:ASPxTextBox ID="cmbTypeofAccount" runat="server" BackColor="#E4E4E4" ReadOnly="True" Theme="BlackGlass" Width="250px">
                        </dx:ASPxTextBox>
                    </td>
                    <%--<td style="width: 208px">
                        <dx:ASPxLabel ID="ASPxLabel39" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Asset Manager" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td style="width: 212px">
                        <dx:ASPxTextBox ID="cmbAssetManager" runat="server" BackColor="#E4E4E4" ReadOnly="True" Theme="BlackGlass" Width="250px">
                        </dx:ASPxTextBox>
                    </td>--%>
                </tr>
           <tr id="Panel8k" runat="server" visible="false">
                    <td style="width: 208px">
                        <dx:ASPxLabel ID="ASPxLabel44" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Nationality" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td style="width: 212px">
                        <dx:ASPxTextBox ID="cmbNationality" runat="server" BackColor="#E4E4E4" ReadOnly="True" Theme="BlackGlass" Width="250px">
                        </dx:ASPxTextBox>
                    </td>
                    <td style="width: 208px">
                        <dx:ASPxLabel ID="ASPxLabel1318" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Passport No." Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td style="width: 212px">
                    <dx:ASPxTextBox ID="txtpassport" runat="server" BackColor="#E4E4E4" ReadOnly="True" Theme="BlackGlass" Width="250px">
                    </dx:ASPxTextBox>
                    </td>
                </tr>
           <tr id="Panel3bb" runat="server" visible="false">
                <td colspan="4">
                    <dx:ASPxLabel ID="ASPxLabel39" runat="server" Font-Names="Cambria" Font-Size="Small" Font-Bold="true" Text="Asset Manager/s" Theme="Glass">
                    </dx:ASPxLabel>
                   <hr/>
                </td>
            </tr>
           <tr id="Panel3bbbb" runat="server" visible="false">
                    <td style="width:208px"></td>
                        <td colspan="3">
                            <dx:ASPxGridView ID="grdAsertManagersClients" runat="server" KeyFieldName="ID" Theme="Glass" Width="470px">
                        <Columns >
                            <dx:GridViewDataColumn VisibleIndex="0" Visible="false">
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
                            <dx:GridViewDataColumn HeaderStyle-Font-Bold="true" Caption="AssetManager">
                                    <DataItemTemplate>
                                        <dx:ASPxLabel Text='<%# Eval("AssetManager") %>' runat="server"></dx:ASPxLabel>
                                    </DataItemTemplate>
                            </dx:GridViewDataColumn>
                            <dx:GridViewDataColumn HeaderStyle-Font-Bold="true" Caption="Bank">
                                    <DataItemTemplate>
                                        <dx:ASPxLabel Text='<%# Eval("BankName") %>' runat="server"></dx:ASPxLabel>
                                    </DataItemTemplate>
                            </dx:GridViewDataColumn>
                            <dx:GridViewDataColumn HeaderStyle-Font-Bold="true" Caption="Branch">
                                    <DataItemTemplate>
                                        <dx:ASPxLabel Text='<%# Eval("BankBranch") %>' runat="server"></dx:ASPxLabel>
                                    </DataItemTemplate>
                            </dx:GridViewDataColumn>
                            <dx:GridViewDataColumn HeaderStyle-Font-Bold="true" Caption="Account">
                                    <DataItemTemplate>
                                        <dx:ASPxLabel Text='<%# Eval("BankAccount") %>' runat="server"></dx:ASPxLabel>
                                    </DataItemTemplate>
                            </dx:GridViewDataColumn>
                        </Columns>
                            </dx:ASPxGridView>
                        </td>
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
                    </td>
                <td style="width: 212px">
                    <dx:ASPxTextBox ID="cmbCountry" runat="server" BackColor="#E4E4E4" ReadOnly="True" Theme="BlackGlass" Width="250px">
                    </dx:ASPxTextBox>
                    </td>
                    <td style="width: 208px">
                        <dx:ASPxLabel ID="ASPxLabel714" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Source of Income" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td style="width: 212px">
                        <dx:ASPxTextBox ID="txtsourceofIncome" runat="server" BackColor="#E4E4E4" ReadOnly="True" Theme="BlackGlass" Width="250px">
                        </dx:ASPxTextBox>
                    </td>
                </tr>
           <tr id="Panel3b" runat="server" visible="false">
               <td style="width: 208px">
                   <dx:ASPxLabel ID="ASPxLabel6" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Address" Theme="Glass">
                   </dx:ASPxLabel>
               </td>
               <td style="width: 212px">
                   <dx:ASPxTextBox ID="txtAddress1" runat="server" BackColor="#E4E4E4" ReadOnly="True" Theme="BlackGlass" Width="250px">
                   </dx:ASPxTextBox>
               </td>
                <td style="width: 208px">
                    <dx:ASPxLabel ID="ASPxLabel8" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Telephone" Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                <td style="width: 212px">
                    <dx:ASPxTextBox ID="txtTel" runat="server" BackColor="#E4E4E4" ReadOnly="True" Theme="BlackGlass" Width="250px">
                    </dx:ASPxTextBox>
                </td>
           </tr>
           <tr id="Panel3l" runat="server" visible="false">
                <td style="width: 208px">
                    <dx:ASPxLabel ID="ASPxLabel118" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Fax" Theme="Glass">
                    </dx:ASPxLabel>
                </td>
            <td style="width: 212px">
                <dx:ASPxTextBox ID="txtFax" runat="server" BackColor="#E4E4E4" ReadOnly="True" Theme="BlackGlass" Width="250px">
                </dx:ASPxTextBox>
                </td>
                <td style="width:208px">
                    <dx:ASPxLabel ID="ASPxLabel10" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Email Address" Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                <td style="width:212px">
                    <dx:ASPxTextBox ID="txtEmail" runat="server" BackColor="#E4E4E4" ReadOnly="True" Theme="BlackGlass" Width="250px">
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
                </td>
                <td style="width:212px">
                    <dx:ASPxTextBox ID="txtPayee2" runat="server" BackColor="#E4E4E4" ReadOnly="True" Theme="BlackGlass" Width="250px">
                    </dx:ASPxTextBox>
                </td>
                <td style="width:208px">
                    <dx:ASPxLabel ID="ASPxLabel20" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Account No." Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                <td style="width:212px">
                    <dx:ASPxTextBox ID="txtIBAN" runat="server" BackColor="#E4E4E4" ReadOnly="True" Theme="BlackGlass" Width="250px">
                    </dx:ASPxTextBox>
                </td>
            </tr>
           <tr id="Panel4c" runat="server" visible="false">
                <td style="width:208px">
                    <dx:ASPxLabel ID="ASPxLabel49" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Bank Name" Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                <td style="width:212px">
                    <dx:ASPxTextBox ID="cmbBankDiv" runat="server" BackColor="#E4E4E4" ReadOnly="True" Theme="BlackGlass" Width="250px">
                    </dx:ASPxTextBox>
                </td>
                <td style="width:208px">
                    <dx:ASPxLabel ID="ASPxLabel50" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Branch" Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                <td style="width:212px">
                    <dx:ASPxTextBox ID="txtBranchDiv" runat="server" BackColor="#E4E4E4" ReadOnly="True" Theme="BlackGlass" Width="250px">
                    </dx:ASPxTextBox>
                </td>
            </tr>
           <tr id="Panel4d" runat="server" visible="false">
                <td style="width:208px">
                    <dx:ASPxLabel ID="ASPxLabel7" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Swift Code (if foreign)" Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                <td style="width:212px">
                    <dx:ASPxTextBox ID="txtSwiftCode" runat="server" BackColor="#E4E4E4" ReadOnly="True" Theme="BlackGlass" Width="250px">
                    </dx:ASPxTextBox>
                </td>
                <td style="width:208px">
                    <dx:ASPxLabel ID="ASPxLabel51" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Bank Address(if foreign)" Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                <td style="width:212px">
                    <dx:ASPxTextBox ID="txtbankAddress" runat="server" BackColor="#E4E4E4" ReadOnly="True" Theme="BlackGlass" Width="250px">
                    </dx:ASPxTextBox>
                </td>
            </tr>
           <tr id="Panel4e" runat="server" visible="false">
                <td style="width:208px">
                    <dx:ASPxLabel ID="ASPxLabel23" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Date/Time stamp" Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                <td style="width:212px">
                    <dx:ASPxTextBox ID="txtDateTimeStamp" runat="server" BackColor="#E4E4E4" ReadOnly="True" Theme="BlackGlass" Width="250px">
                    </dx:ASPxTextBox>
                </td>
            </tr>
           <tr id="Panel20a" runat="server" visible="false">
                <td colspan="4">
                    <dx:ASPxLabel ID="ASPxLabel126" runat="server" Font-Names="Cambria" Font-Size="Small" Font-Bold="true" Text="Joint Members" Theme="Glass">
                    </dx:ASPxLabel>
                   <hr/>
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

           <tr id="PanelCORP1" runat="server" visible="false">
                    <td colspan="4">
                        <dx:ASPxLabel ID="ASPxLabel2" runat="server" Font-Names="Cambria" Font-Size="Small" Font-Bold="true" Text="Company Details" Theme="Glass">
                        </dx:ASPxLabel>
                       <hr/>
                    </td>
                </tr>
           <tr id="PanelCORP2" runat="server" visible="false">
                    <td style="width: 208px">
                        <dx:ASPxLabel ID="ASPxLabel4" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Name of Company" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td style="width: 212px">
                        <dx:ASPxTextBox ID="txtCORPSurname" runat="server" BackColor="#E4E4E4" ReadOnly="True" Theme="BlackGlass" Width="250px">
                        </dx:ASPxTextBox>
                    </td>
                    <td style="width: 208px">
                        <dx:ASPxLabel ID="ASPxLabel9" runat="server" Font-Names="Cambria" Font-Size="Small"  Text="Account Type" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td style="width: 212px">
                        <dx:ASPxTextBox ID="cmbCORPTypeofAccount" runat="server" BackColor="#E4E4E4" ReadOnly="True" Theme="BlackGlass" Width="250px">
                        </dx:ASPxTextBox>
                    </td>
                </tr>
           <tr id="PanelCORP3" runat="server" visible="false">
                    <td colspan="4">
                        <dx:ASPxLabel ID="ASPxLabel11" runat="server" Font-Names="Cambria" Font-Size="Small" Font-Bold="true" Text="Registered Office/Head Office Address" Theme="PlasticBlue">
                        </dx:ASPxLabel>
                       <hr/>
                    </td>
                </tr>
           <tr id="PanelCORP4" runat="server" visible="false">
               <td style="width: 208px">
                   <dx:ASPxLabel ID="ASPxLabel13" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Physical Address" Theme="Glass">
                   </dx:ASPxLabel>
               </td>
               <td style="width: 212px">
                   <dx:ASPxTextBox ID="txtCORPAddress1" runat="server" BackColor="#E4E4E4" ReadOnly="True" Theme="BlackGlass" Width="250px">
                   </dx:ASPxTextBox>
               </td>
                    <td style="width: 208px">
                        <dx:ASPxLabel ID="ASPxLabel67" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Postal Address" Theme="Glass">
                   </dx:ASPxLabel>
                        </td>
                <td style="width: 212px">
                    <dx:ASPxTextBox ID="txtCORPAddress2" runat="server" BackColor="#E4E4E4" ReadOnly="True" Theme="BlackGlass" Width="250px">
                    </dx:ASPxTextBox>
                    </td>
           </tr>
           <tr id="PanelCORP5" runat="server" visible="false">
                    <td style="width: 208px">
                        <dx:ASPxLabel ID="ASPxLabel16" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Country of Registration" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                <td style="width: 212px">
                    <dx:ASPxTextBox ID="cmbCORPCountry" runat="server" BackColor="#E4E4E4" ReadOnly="True" Theme="BlackGlass" Width="250px">
                    </dx:ASPxTextBox>
                    </td>
                    <td style="width: 208px">
                        <dx:ASPxLabel ID="ASPxLabel17" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Country of Tax Residence" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td style="width: 212px">
                    <dx:ASPxTextBox ID="cmbCORPCountryTaxResidence" runat="server" BackColor="#E4E4E4" ReadOnly="True" Theme="BlackGlass" Width="250px">
                    </dx:ASPxTextBox>
                    </td>
            </tr>
           <tr id="PanelCORP6" runat="server" visible="false">
                       <td style="width: 208px">
                        <dx:ASPxLabel ID="ASPxLabel18" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Nature of Business" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td style="width: 212px">
                        <dx:ASPxTextBox ID="txtCORPNatureOfBusiness" runat="server" BackColor="#E4E4E4" ReadOnly="True" Theme="BlackGlass" Width="250px">
                        </dx:ASPxTextBox>
                    </td>
                    <td style="width: 208px">
                        <dx:ASPxLabel ID="ASPxLabel19" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Date of Incorporation" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td style="width: 212px">
                        <dx:ASPxTextBox ID="txtCORPDOB" runat="server" BackColor="#E4E4E4" ReadOnly="True" Theme="BlackGlass" Width="250px">
                        </dx:ASPxTextBox>
                    </td>
                </tr>
           <tr id="PanelCORP7" runat="server" visible="false">
                    <td style="width: 208px">
                        <dx:ASPxLabel ID="ASPxLabel34" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Source of Funds" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td style="width: 212px">
                        <dx:ASPxTextBox ID="txtCORPSourceofFunds" runat="server" BackColor="#E4E4E4" ReadOnly="True" Theme="BlackGlass" Width="250px">
                        </dx:ASPxTextBox>
                    </td>
                    <td style="width: 208px">
                        <dx:ASPxLabel ID="ASPxLabel21" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Investor Type" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td style="width: 212px">
                        <dx:ASPxTextBox ID="cmbCORPInvestorType" runat="server" BackColor="#E4E4E4" ReadOnly="True" Theme="BlackGlass" Width="250px">
                        </dx:ASPxTextBox>
                    </td>
                </tr>
           <tr id="PanelCORP8" runat="server" visible="false">
                <td colspan="4">
                    <dx:ASPxLabel ID="ASPxLabel22" runat="server" Font-Names="Cambria" Font-Size="Small" Font-Bold="true" Text="Contact Person's Details (authorized representative)" Theme="PlasticBlue">
                    </dx:ASPxLabel>
                   <hr/>
                </td>
            </tr>
           <tr id="PanelCORP9" runat="server" visible="false">
                    <td style="width: 208px">
                        <dx:ASPxLabel ID="ASPxLabel24" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Full Name of Contact Person" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td style="width: 212px">
                        <dx:ASPxTextBox ID="txtCORPfullname" runat="server" BackColor="#E4E4E4" ReadOnly="True" Theme="BlackGlass" Width="250px">
                        </dx:ASPxTextBox>
                    </td>
                    <td style="width: 208px">
                        <dx:ASPxLabel ID="ASPxLabel25" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Telephone" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                <td style="width: 212px">
                    <dx:ASPxTextBox ID="txtCORPTel" runat="server" BackColor="#E4E4E4" ReadOnly="True" Theme="BlackGlass" Width="250px">
                    </dx:ASPxTextBox>
                    </td>
                </tr>
           <tr id="PanelCORP10" runat="server" visible="false">
                <td style="width: 208px">
                        <dx:ASPxLabel ID="ASPxLabel28" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Fax" Theme="Glass">
                    </dx:ASPxLabel>
                    </td>
                <td style="width: 212px">
                    <dx:ASPxTextBox ID="txtCORPFax" runat="server" BackColor="#E4E4E4" ReadOnly="True" Theme="BlackGlass" Width="250px">
                    </dx:ASPxTextBox>
                    </td>
                <td style="width: 208px">
                    <dx:ASPxLabel ID="ASPxLabel40" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Email Address" Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                <td style="width: 212px">
                    <dx:ASPxTextBox ID="txtCORPEmail" runat="server" BackColor="#E4E4E4" ReadOnly="True" Theme="BlackGlass" Width="250px">
                    </dx:ASPxTextBox>
                </td>
            </tr>
           <tr id="PanelCORP11" runat="server" visible="false">
                <td colspan="4">
                    <dx:ASPxLabel ID="ASPxLabel35" runat="server" Font-Names="Cambria" Font-Size="Small" Font-Bold="true" Text="Banking Details" Theme="PlasticBlue">
                    </dx:ASPxLabel>
                   <hr/>
                </td>
            </tr>
           <tr id="PanelCORP12" runat="server" visible="false">
                <td style="width: 208px">
                    <dx:ASPxLabel ID="ASPxLabel36" Visible="true"   runat="server" Font-Names="Cambria" Font-Size="Small" Text="Account Name" Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                <td style="width: 212px">
                    <dx:ASPxTextBox ID="txtCORPPayee2" Visible="true" runat="server" BackColor="#E4E4E4" ReadOnly="True" Theme="BlackGlass" Width="250px">
                    </dx:ASPxTextBox>
                </td>
                <td style="width: 208px">
                    <dx:ASPxLabel ID="ASPxLabel37" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Account No." Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                <td style="width: 212px">
                    <dx:ASPxTextBox ID="txtCORPIBAN" runat="server" BackColor="#E4E4E4" ReadOnly="True" Theme="BlackGlass" Width="250px">
                    </dx:ASPxTextBox></td>
            </tr>
           <tr id="PanelCORP13" runat="server" visible="false">
                               <td style="width: 208px">
                                   <dx:ASPxLabel ID="ASPxLabel38" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Bank Name" Theme="Glass">
                                   </dx:ASPxLabel>
                               </td>
                               <td style="width: 212px">
                                   <dx:ASPxTextBox ID="cmbCORPBankDiv" runat="server" BackColor="#E4E4E4" ReadOnly="True" Theme="BlackGlass" Width="250px">
                                   </dx:ASPxTextBox>
                               </td>
                               <td style="width: 208px">
                                   <dx:ASPxLabel ID="ASPxLabel41" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Branch" Theme="Glass">
                                   </dx:ASPxLabel>
                               </td>
                               <td style="width: 212px">
                                   <dx:ASPxTextBox ID="txtCORPBranchDiv" Visible="true" runat="server" BackColor="#E4E4E4" ReadOnly="True" Theme="BlackGlass" Width="250px">
                                   </dx:ASPxTextBox>
                               </td>
                           </tr>
           <tr id="PanelCORP14" runat="server" visible="false">
                               <td style="width: 208px">
                                   <dx:ASPxLabel ID="ASPxLabel42" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Bank Address (If Foreign)" Theme="Glass">
                                   </dx:ASPxLabel>
                               </td>
                               <td style="width: 212px">
                                 <dx:ASPxTextBox ID="txtCORPBankAddress" runat="server" BackColor="#E4E4E4" ReadOnly="True" Theme="BlackGlass" Width="250px">
                                    </dx:ASPxTextBox>
                               </td>
                                <td style="width: 208px">
                                    <dx:ASPxLabel ID="ASPxLabel43" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Swift Code (If Foreign)" Theme="Glass">
                                    </dx:ASPxLabel>
                                </td>
                                <td style="width: 212px">
                                    <dx:ASPxTextBox ID="txtCORPSwiftCode" runat="server" BackColor="#E4E4E4" ReadOnly="True" Theme="BlackGlass" Width="250px">
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
           <tr id="panelSave5" runat="server" visible="false">
               <td style="width: 208px"></td>
               <td colspan="3">
                   <dx:ASPxGridView ID="grdEvent" runat="server" KeyFieldName="ID" Theme="Glass">
                       <Columns>
                           <dx:GridViewDataColumn Caption="" VisibleIndex="0">
                               <DataItemTemplate>
                                   <asp:LinkButton ID="ViewDoc1" runat="server" CommandArgument='<%# Eval("ID") %>' CommandName="View Document" Text="View Document">
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
           <tr id="panelLastSection1" runat="server" visible="false">
                    <td style="width:208px"></td>
                        <td colspan="3">
                            <dx:ASPxRadioButton ID="rdApprove" runat="server" AutoPostBack="True" GroupName="Approval" Text="Approve" Theme="DevEx">
                            </dx:ASPxRadioButton>
                            <dx:ASPxRadioButton ID="rdReject" runat="server" AutoPostBack="True" GroupName="Approval" Text="Reject" Theme="DevEx">
                            </dx:ASPxRadioButton>
                        </td>
                    </tr>
           <tr id="panelLastSection2" runat="server" visible="false">
                        <td style="width:208px">
                            <dx:ASPxLabel ID="lblRejection" runat="server" Text="Rejection Reason" Visible="False">
                            </dx:ASPxLabel>
                        </td>
                        <td colspan="3">
                            <dx:ASPxMemo ID="txtReasons" runat="server" Height="80px" Theme="BlackGlass" Visible="False" Width="400px">
                            </dx:ASPxMemo>
                        </td>
                    </tr>
           <tr id="p19new" runat="server" visible="False">
               <td style="width: 208px; height: 44px;">
                   <dx:ASPxLabel ID="ASPxLabel7115" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Charge" Theme="Glass">
                   </dx:ASPxLabel>
               </td>
               <td style="width: 212px; height: 44px;">
                   <dx:ASPxTextBox ID="txtcharge" runat="server" BackColor="#E4E4E4" ReadOnly="true" Theme="BlackGlass" Width="250px">
                   </dx:ASPxTextBox>
               </td>
               <td style="width: 208px; height: 44px;">&nbsp;</td>
               <td style="width: 212px; height: 44px;">&nbsp;</td>
           </tr>
           <tr id="panelLastSection3" runat="server" visible="false">
                    <td style="width:208px"></td>
                    <td style="width:212px">
                        <dx:ASPxButton ID="ASPxButton1" runat="server" Text="Submit" Theme="BlackGlass" style="height: 23px">
                        </dx:ASPxButton>
                    </td>
            </tr>
           <tr id="Tr1" runat="server"><td style="width:208px"></td></tr>
           <tr id="Tr2" runat="server"><td style="width:208px"></td></tr>
           <tr id="Tr3" runat="server"><td style="width:208px"></td></tr>
        </table> 
      </asp:Panel>
</asp:Content>

