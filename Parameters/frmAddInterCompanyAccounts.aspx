<%@ Page Language="VB" MasterPageFile="~/CDSUser.master" AutoEventWireup="false" CodeFile="frmAddInterCompanyAccounts.aspx.vb" Inherits="Parameters_InterCompanyAccountsSetup" title="Inter-Company Accounts Setup" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<asp:Content id="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
   <asp:Panel id="Panel1" runat="server"  Width="100%" Font-Names="Arial" Font-Size="Medium" BackColor="White" GroupingText="Inter-Company Accounts Setup">
           <table>
               <tr id="Tr4" runat="server">
                    <td colspan="4">
                        <dx:ASPxLabel ID="ASPxLabel3" runat="server" Font-Names="Cambria" Font-Size="Small" Font-Bold="true" Text="" Theme="Glass">
                        </dx:ASPxLabel>
                       <hr/>
                    </td>
                </tr>
                <tr>
                    <td style="width: 208px">
                        <dx:ASPxLabel ID="ASPxLabel7" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Account Name" Theme="Glass"></dx:ASPxLabel>
                    </td>
                    <td style="width: 212px">
                        <dx:ASPxTextBox ID="txtAccountName" runat="server" style="margin-top: 0px" Theme="Glass" Width="250px">
                        <ValidationSettings>
                                <RequiredField IsRequired="True"  />
                            </ValidationSettings>
                                </dx:ASPxTextBox>
                    </td>
                </tr>
                <tr>
                    <td style="width: 208px">
                        <dx:ASPxLabel ID="ASPxLabel22" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Account Number" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td style="width: 212px">
                        <dx:ASPxTextBox ID="txtAccountNumber" runat="server" style="margin-top: 0px" Theme="Glass" Width="250px">
                        <ValidationSettings>
                                <RequiredField IsRequired="True"  />
                            </ValidationSettings>
                                </dx:ASPxTextBox>
                    </td>
                </tr>
                <tr>
                    <td style="width: 208px">
                        <dx:ASPxLabel ID="ASPxLabel2" runat="server" Font-Names="Cambria" Font-Size="Small" Text="ID" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td style="width: 212px">
                        <dx:ASPxTextBox ID="txtRecordID" runat="server" style="margin-top: 0px" Theme="Glass" Enabled="false" Width="250px">
                                </dx:ASPxTextBox>
                    </td>
                </tr>
                <tr>
                    <td style="width: 208px"></td>
                    <td style="width: 212px">
                        <dx:ASPxButton ID="ASPxButton7" runat="server" Text="Save" Theme="BlackGlass">
                        </dx:ASPxButton>
                    </td>
                </tr>
                <tr>
                   <td style="width: 208px"> </td>
                   <td colspan ="3">
                            <dx:ASPxGridView ID="ASPxGridView2"  runat="server" Theme="Glass" Width="640px" KeyFieldName="ID" SettingsPager-Mode="ShowAllRecords" >
                            <Columns>
                                   <dx:GridViewDataColumn VisibleIndex="0" Caption="">
                                                         <DataItemTemplate>
                                                              <asp:LinkButton ID="SelectID" Text="Edit"  CommandName="Edit" CommandArgument='<%# Eval("ID") %>' runat="server">
                                                              </asp:LinkButton>
                                                         </DataItemTemplate>
                                                                                       </dx:GridViewDataColumn>
                                    <dx:GridViewDataColumn VisibleIndex="0" Caption="">
                                                                                           <DataItemTemplate>
                                                              <asp:LinkButton ID="DeleteID" Text="Delete" CommandName="Delete" OnClientClick="if ( !confirm('Are you sure you want to delete ? ')) return false;" CommandArgument='<%# Eval("ID") %>' runat="server">
                                                              </asp:LinkButton>
                                                         </DataItemTemplate>
                                                    </dx:GridViewDataColumn>
                                        <dx:GridViewDataColumn Caption="ID">
                                                         <DataItemTemplate>
                                                              <dx:ASPxLabel Text='<%# Eval("ID") %>' runat="server"></dx:ASPxLabel>
                                                         </DataItemTemplate>
                                                    </dx:GridViewDataColumn>

                                  <dx:GridViewDataColumn Caption="A/c Name">
                                                         <DataItemTemplate>
                                                              <dx:ASPxLabel Text='<%# Eval("AccountName") %>' runat="server"></dx:ASPxLabel>
                                                         </DataItemTemplate>
                                                    </dx:GridViewDataColumn>

                                
                                  <dx:GridViewDataColumn Caption="A/c Number">
                                                         <DataItemTemplate>
                                                              <dx:ASPxLabel Text='<%# Eval("AccountNumber") %>' runat="server"></dx:ASPxLabel>
                                                         </DataItemTemplate>
                                                    </dx:GridViewDataColumn>
                            </Columns>
                            </dx:ASPxGridView>
                            </td>
                    </tr>
                 
        </table>
</asp:Panel>
</asp:Content>

