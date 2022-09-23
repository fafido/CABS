<%@ Page Language="VB"  MasterPageFile="~/CDSUser.master" AutoEventWireup="false" CodeFile="~/TransferSec/UTSetup.vb" Title="Unit Trust Fund" Inherits="TransferSec_UTSetup" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<asp:Content id="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Panel id="Panel1" runat="server" Width="100%" Font-Names="Arial" Font-Size="Medium" GroupingText="Fund>>Unit Trust Fund" BackColor="White">
        <table>
            <tr id="Tr1" runat="server">
              <td colspan="2" style="height: 18px;">
                    <dx:ASPxLabel ID="ASPxLabel1" runat="server" Font-Names="Cambria" Font-Size="Small" Font-Bold="true" Text="" Theme="Glass">
                    </dx:ASPxLabel>
                    <hr/>
                </td>
              </tr>
             <tr>
                <td style="width: 208px;">
                     <dx:ASPxLabel ID="ASPxLabel2" runat="server" Font-Names="Cambria" Font-Size="Small" Font-Bold="false" Text="Fund Name" Theme="Glass">
                    </dx:ASPxLabel></td>
                 <td style="width: 212px;">
                     <asp:TextBox ID="txtFundingName" runat="server" Width="237px"></asp:TextBox>
                 </td>
              </tr>
            <tr>
                <td style="width: 208px;">
               <dx:ASPxLabel ID="ASPxLabel16" runat="server" Font-Names="Cambria" Font-Size="Small" Font-Bold="false" Text="Fund Code" Theme="Glass">
                    </dx:ASPxLabel></td>
                <td style="width: 212px;">
                    <asp:TextBox ID="txtFundingCode" runat="server" Width="239px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 208px;">
                    <dx:ASPxLabel ID="ASPxLabel5" runat="server" Font-Names="Cambria" Font-Size="Small" Font-Bold="false" Text="Description" Theme="Glass">
                    </dx:ASPxLabel></td>
                 <td style="width: 212px;">
                     <asp:TextBox ID="txtDescription" runat="server" Width="240px"></asp:TextBox>
                 </td>
            </tr>
            <tr>
                <td style="width: 208px;">
                   <dx:ASPxLabel ID="ASPxLabel3" runat="server" Font-Names="Cambria" Font-Size="Small" Font-Bold="false" Text="Issuer" Theme="Glass">
                    </dx:ASPxLabel> </td>
                <td style="width: 212px;">
                    <dx:ASPxComboBox ID="cmbIssuer" runat="server" AnimationType="Slide" AutoPostBack="True" IncrementalFilteringMode="Contains" Theme="BlackGlass" ValueType="System.String" Width="250px">
                    </dx:ASPxComboBox>
                </td>
            </tr>
           <tr>
                 <td style="width: 208px;">
                     <dx:ASPxLabel ID="ASPxLabel26" runat="server" Font-Bold="false" Font-Names="Cambria" Font-Size="Small" Text="Fund Units" Theme="Glass">
                     </dx:ASPxLabel>
                 </td>
                <td style="width: 212px;">
                    <asp:TextBox ID="txtunits"  runat="server" Width="240px"></asp:TextBox>
                 </td>
            </tr>
           <tr>
                 <td style="width: 208px;">
                     &nbsp;</td>
                <td style="width: 212px;">
                    <dx:ASPxButton ID="btnSave" runat="server" Text="Add" Theme="Glass" Width="181px">
                    </dx:ASPxButton>
                 </td>
            </tr>
           <tr>
                 <td style="width: 208px;">
                     &nbsp;</td>
                <td style="width: 212px;">
                    <dx:ASPxLabel ID="lblid" runat="server" Font-Bold="true" Font-Names="Cambria" Font-Size="Small" Theme="Glass" Visible="False">
                    </dx:ASPxLabel>
                 </td>
            </tr>
          <tr>
              <td style="width: 208px;"></td>
                <td style="width: 212px;">
                    &nbsp;</td>
            </tr>
            <tr id="panel00002" runat="server">
              <td colspan="2" style="height: 18px;">
                    <dx:ASPxLabel ID="ASPxLabel25" runat="server" Font-Names="Cambria" Font-Size="Small" Font-Bold="true" Text="List of all Funds" Theme="Glass">
                    </dx:ASPxLabel>
                    <hr/>
                </td>
              </tr>
                <tr>
                  <td style="width: 208px;"></td>
                    <td>
                     <dx:ASPxGridView ID="grdvCharges" runat="server" AutoGenerateColumns="true"  KeyFieldName="ID" Theme="Glass" Width="840px">
                        <SettingsPager Visible="False">
                        </SettingsPager>
                        <Columns >
                           <dx:GridViewDataColumn ShowInCustomizationForm="True" VisibleIndex="0">
                              <DataItemTemplate>
                                            <asp:LinkButton ID="ViewDoc2" runat="server" CommandArgument='<%# Eval("ID") %>' CommandName="Edit" Text="Edit">
                                                              </asp:LinkButton>
                                        </DataItemTemplate>
                                       </dx:GridViewDataColumn>
                            <dx:GridViewDataColumn HeaderStyle-Font-Bold="true" Caption="Fund Code">
                                    <DataItemTemplate>
                                        <dx:ASPxLabel Text='<%# Eval("Funding_Code") %>' runat="server"></dx:ASPxLabel>
                                    </DataItemTemplate>
                            </dx:GridViewDataColumn>
                            <dx:GridViewDataColumn HeaderStyle-Font-Bold="true" Caption="Fund Name">
                                    <DataItemTemplate>
                                        <dx:ASPxLabel Text='<%# Eval("Funding_Name") %>' runat="server"></dx:ASPxLabel>
                                    </DataItemTemplate>
                            </dx:GridViewDataColumn>
                              <dx:GridViewDataColumn HeaderStyle-Font-Bold="true" Caption="Units">
                                    <DataItemTemplate>
                                        <dx:ASPxLabel Text='<%# Eval("Units") %>' runat="server"></dx:ASPxLabel>
                                    </DataItemTemplate>
                            </dx:GridViewDataColumn>
                            <dx:GridViewDataColumn HeaderStyle-Font-Bold="true" Caption="Description">
                                    <DataItemTemplate>
                                        <dx:ASPxLabel Text='<%# Eval("description") %>' runat="server"></dx:ASPxLabel>
                                    </DataItemTemplate>
                            </dx:GridViewDataColumn>
                            <dx:GridViewDataColumn HeaderStyle-Font-Bold="true" Caption="Issuer">
                                    <DataItemTemplate>
                                        <dx:ASPxLabel Text='<%# Eval("issuer") %>' runat="server"></dx:ASPxLabel>
                                    </DataItemTemplate>
                            </dx:GridViewDataColumn>
                            <dx:GridViewDataColumn HeaderStyle-Font-Bold="true" Caption="Status">
                                    <DataItemTemplate>
                                        <dx:ASPxLabel Text='<%# Eval("status") %>' runat="server"></dx:ASPxLabel>
                                    </DataItemTemplate>
                            </dx:GridViewDataColumn>
                            
                             </Columns>
                    </dx:ASPxGridView>
                      </td>
                  </tr>
                  <tr>
                      <td colspan="1"></td>
                  </tr>
                  <tr>
                      <td colspan="1"></td>
                  </tr>
                  <tr>
                      <td colspan="1"></td>
                  </tr>
        </table>
    </asp:Panel>
</asp:Content>
