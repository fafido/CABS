<%@ Page Language="VB"  MasterPageFile="~/CDSUser.master" AutoEventWireup="false" CodeFile="tax.aspx.vb" Title="Tax Charges" Inherits="Parameters_tax" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<asp:Content id="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Panel id="Panel1" runat="server" Width="100%" Font-Names="Arial" Font-Size="Medium" GroupingText="Parameters>>Tax Charges" BackColor="White">
        <table>
            <tr id="Tr1" runat="server">
              <td colspan="5" style="height: 18px;">
                    <dx:ASPxLabel ID="ASPxLabel1" runat="server" Font-Names="Cambria" Font-Size="Small" Font-Bold="true" Text="" Theme="Glass">
                    </dx:ASPxLabel>
                    <hr/>
                </td>
              </tr>
             <tr>
                <td style="width: 208px;">
                    <dx:ASPxLabel ID="ASPxLabel19" runat="server" Font-Names="Cambria" Font-Size="Small"  Text="Tax Type" Theme="Glass">
                    </dx:ASPxLabel>
                 </td>
                 <td style="width: 212px;">
                     <asp:DropDownList ID="cmbsecuritytype" runat="server" AutoPostBack="True" Height="20px" Theme="Glass" Width="250px">
                         <asp:ListItem Text="" Value=""></asp:ListItem>
                         <asp:ListItem Text="Direct" Value="Direct"></asp:ListItem>
                         <asp:ListItem Text="Indirect" Value="Indirect"></asp:ListItem>
                    </asp:DropDownList>
                 </td>
              </tr>
            <tr>
                <td style="width: 208px;">
                    <dx:ASPxLabel ID="ASPxLabel18" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Partcipant Type" Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                <td style="width: 212px;">
                  <asp:DropDownList ID="cmbParticipanttype" runat="server" AppendDataBoundItems="true" AutoPostBack="True" Height="20px" Theme="Glass" Width="250px">
                      <asp:ListItem Text="" Value=""></asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td style="width: 208px;">
                    <dx:ASPxLabel ID="ASPxLabel2" runat="server" Font-Names="Cambria" Font-Size="Small" Visible="false"  Text="Participant Category" Theme="Glass">
                    </dx:ASPxLabel>
                 </td>
                 <td style="width: 212px;">
                     <asp:DropDownList ID="cmbParticipantCategory" runat="server" AutoPostBack="False" Height="20px" Visible="false" Theme="Glass" Width="250px">
                         <asp:ListItem Text="" Value=""></asp:ListItem>
                         <asp:ListItem Text="Corporate" Value="Corporate"></asp:ListItem>
                         <asp:ListItem Text="Individual" Value="Individual"></asp:ListItem>
                    </asp:DropDownList>
                 </td>
            </tr>
            <tr>
                <td style="width: 208px;">
                    <dx:ASPxLabel ID="ASPxLabel3" runat="server" Font-Names="Cambria" Font-Size="Small"  Text="Participant Location" Theme="Glass" Visible="false">
                    </dx:ASPxLabel>
                </td>
                <td style="width: 212px;">
                   <asp:DropDownList ID="cmbCustLocation" runat="server" AppendDataBoundItems="true" AutoPostBack="false" Height="20px" Theme="Glass" Width="250px" Visible="false">
                       <asp:ListItem Text="" Value=""></asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
           <tr>
                 <td style="width: 208px;">
                    <dx:ASPxLabel ID="ASPxLabel4" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Sales Tax(%)" Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                <td style="width: 212px;">
                    <dx:ASPxTextBox ID="txtSalesTax" runat="server" Height="16px" Theme="Glass" Width="250px">
                    </dx:ASPxTextBox>
                </td>
            </tr>
           <tr>
                 <td style="width: 208px;">
                    <dx:ASPxLabel ID="ASPxLabel41" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Income Tax Withholding(%)" Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                <td style="width: 212px;">
                    <dx:ASPxTextBox ID="txtIncomeTaxWithholding" runat="server" Height="16px" Theme="Glass" Width="249px">
                    </dx:ASPxTextBox>
                </td>
            </tr>
           <tr>
                 <td style="width: 208px;">
                    <dx:ASPxLabel ID="ASPxLabel412" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Sales Tax Withholding(%)" Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                <td style="width: 212px;">
                    <dx:ASPxTextBox ID="txtSalesTaxWithholding" runat="server" Height="16px" Theme="Glass" Width="250px">
                    </dx:ASPxTextBox>
                </td>
            </tr>
            <tr>
               <td style="width: 208px;"></td>
                <td style="width: 212px;">
                    <dx:ASPxButton ID="btnSave" runat="server" Text="Add" Theme="Glass">
                    </dx:ASPxButton>
                </td>
            </tr>
          <tr>
              <td style="width: 208px;"></td>
                <td style="width: 212px;">
                    <dx:ASPxButton ID="btnUpdate" runat="server" Visible="false" Text="Update" Theme="Glass">
                    </dx:ASPxButton>
                </td>
            </tr>
            <tr id="panel00002" runat="server">
              <td colspan="5" style="height: 18px;">
                    <dx:ASPxLabel ID="ASPxLabel25" runat="server" Font-Names="Cambria" Font-Size="Small" Font-Bold="true" Text="List of all Tax charges" Theme="Glass">
                    </dx:ASPxLabel>
                    <hr/>
                </td>
              </tr>
                <tr>
                  <td style="width: 208px;"></td>
                    <td colspan="3">
                     <dx:ASPxGridView ID="grdvCharges" runat="server" AutoGenerateColumns="true" OnRowCommand="grdvCharges_RowCommand" KeyFieldName="ID" Theme="Glass" Width="840px">
                        <SettingsPager Visible="False">
                        </SettingsPager>
                        <Columns >
                            <dx:GridViewDataColumn VisibleIndex="0">
                                    <DataItemTemplate>
                                        <asp:LinkButton ID="SelectID" Text="Edit" CommandName="Select" CommandArgument='<%# Eval("ID") %>' runat="server">
                                        </asp:LinkButton>
                                    </DataItemTemplate>
                            </dx:GridViewDataColumn>
                            <dx:GridViewDataColumn VisibleIndex="0">
                                    <DataItemTemplate>
                                        <asp:LinkButton ID="SelectID" Text="Delete"  OnClientClick="if ( !confirm('Are you sure you want to delete ? ')) return false;" CommandName="Delete" CommandArgument='<%# Eval("ID") %>' runat="server">
                                        </asp:LinkButton>
                                    </DataItemTemplate>
                            </dx:GridViewDataColumn>
                            <dx:GridViewDataColumn HeaderStyle-Font-Bold="true" Caption="Tax Type">
                                    <DataItemTemplate>
                                        <dx:ASPxLabel Text='<%# Eval("tax_type") %>' runat="server"></dx:ASPxLabel>
                                    </DataItemTemplate>
                            </dx:GridViewDataColumn>
                            <dx:GridViewDataColumn HeaderStyle-Font-Bold="true" Caption="Location">
                                    <DataItemTemplate>
                                        <dx:ASPxLabel Text='<%# Eval("Location") %>' runat="server"></dx:ASPxLabel>
                                    </DataItemTemplate>
                            </dx:GridViewDataColumn>
                            <dx:GridViewDataColumn HeaderStyle-Font-Bold="true" Caption="Participant Type">
                                    <DataItemTemplate>
                                        <dx:ASPxLabel Text='<%# Eval("participant_type") %>' runat="server"></dx:ASPxLabel>
                                    </DataItemTemplate>
                            </dx:GridViewDataColumn>
                            <dx:GridViewDataColumn HeaderStyle-Font-Bold="true" Caption="Participant Category">
                                    <DataItemTemplate>
                                        <dx:ASPxLabel Text='<%# Eval("applyto") %>' runat="server"></dx:ASPxLabel>
                                    </DataItemTemplate>
                            </dx:GridViewDataColumn>
                            <dx:GridViewDataColumn HeaderStyle-Font-Bold="true" Caption="Sales Tax" CellStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Right">
                                    <DataItemTemplate>
                                        <dx:ASPxLabel Text='<%# Eval("SalesTax1") %>' runat="server"></dx:ASPxLabel>
                                    </DataItemTemplate>
                            </dx:GridViewDataColumn>
                            <dx:GridViewDataColumn HeaderStyle-Font-Bold="true" Caption="Income Tax Withholding" CellStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Right">
                                    <DataItemTemplate>
                                        <dx:ASPxLabel Text='<%# Eval("IncomeTaxWithholding1") %>' runat="server"></dx:ASPxLabel>
                                    </DataItemTemplate>
                            </dx:GridViewDataColumn>
                            <dx:GridViewDataColumn HeaderStyle-Font-Bold="true" Caption="Sales Tax Withholding" CellStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Right">
                                    <DataItemTemplate>
                                        <dx:ASPxLabel Text='<%# Eval("SalesTaxWithholding1") %>' runat="server"></dx:ASPxLabel>
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
