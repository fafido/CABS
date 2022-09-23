<%@ Page Language="VB" MasterPageFile="~/CDSUser.master" AutoEventWireup="false" CodeFile="frmInvoiceMultipleAuthorization.aspx.vb" Inherits="Corp_InvoiceMultiple" title="Invoice" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView.Export" TagPrefix="dx" %>

<asp:Content id="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Panel id="Panel1" runat="server" Width="90%" Font-Names="Cambria" BackColor="White" GroupingText="Invoice">
       <table>
           <tr id="Tr1" runat="server">
                <td colspan="6">
                    <dx:ASPxLabel ID="ASPxLabel1" runat="server" Font-Names="Cambria" Font-Size="Small" Text="" Theme="Glass">
                    </dx:ASPxLabel>
                   <hr/>
                </td>
            </tr>
           <tr id="Tr5" runat="server">
                    <td style="width: 208px">
                        <dx:ASPxLabel ID="ASPxLabel72d" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Asset Manager" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td style="width: 212px">
                        <dx:ASPxComboBox ID="cmbAssetManager" runat="server" Theme="Glass" Width="250px"  CallbackPageSize="15" EnableCallbackMode="True" DropDownStyle="DropDownList"  IncrementalFilteringMode="Contains"  AnimationType="Slide" AutoPostBack="True">
                            <Items>
                                <dx:ListEditItem Text="" Value="" /> 
                            </Items>
                        </dx:ASPxComboBox>
                    </td>
               <td style="width: 208px"></td>
               <td style="width: 212px"></td>
               <td style="width: 208px"></td>
                  </tr>
           <tr id="Tr11" runat="server">
                <td colspan="6">
                    <dx:ASPxLabel ID="ASPxLabel26" runat="server" Font-Names="Cambria" Font-Size="Small" Text="" Theme="Glass">
                    </dx:ASPxLabel>
                   <hr/>
                </td>
            </tr>
           <tr id="Tr12" runat="server">
                <td style="width: 208px">
                  <asp:CheckBox ID="chkSelectAll" runat="server" Text="Select All" Font-Size="Small" Font-Names="Cambria" AutoPostBack ="true"/>
                </td>
           </tr>
           <tr id="panel00003" runat="server">
                <td colspan="5" style="height: 18px">
                    <dx:ASPxGridView ID="grdNewAccountsToBill" SettingsPager-Mode="ShowAllRecords" runat="server" KeyFieldName="ID" Theme="Glass" Width="100%">
                        <SettingsPager Visible="False">
                        </SettingsPager>
                        <Columns >
                            <dx:GridViewDataColumn Caption="Select" FieldName="Selec"  VisibleIndex="0">
                                    <DataItemTemplate>
                                        <dx:aspxcheckbox ID="chk1" Checked="false" Enabled="true" runat="server" >
                                                              </dx:aspxcheckbox>
                                    </DataItemTemplate>
                            </dx:GridViewDataColumn>
                            <dx:GridViewDataColumn VisibleIndex="0">
                                    <DataItemTemplate>
                                        <asp:LinkButton ID="SelectID" Text="Preview" CommandName="Select" CommandArgument='<%# Eval("ID") %>' runat="server">
                                        </asp:LinkButton>
                                    </DataItemTemplate>
                            </dx:GridViewDataColumn>
                            <dx:GridViewDataColumn VisibleIndex="0">
                                    <DataItemTemplate>
                                        <asp:LinkButton ID="LinkButton1" Text="Authorise"  OnClientClick="if ( !confirm('Are you sure you want to authorise this invoice ? ')) return false;" CommandName="Authorise" CommandArgument='<%# Eval("ID") %>' runat="server">
                                        </asp:LinkButton>
                                    </DataItemTemplate>
                            </dx:GridViewDataColumn>
                            <dx:GridViewDataColumn VisibleIndex="0">
                                    <DataItemTemplate>
                                        <asp:LinkButton ID="LinkButton2" Text="Reject"  OnClientClick="if ( !confirm('Are you sure you want to reject this invoice ? ')) return false;" CommandName="Reject" CommandArgument='<%# Eval("ID") %>' runat="server">
                                        </asp:LinkButton>
                                    </DataItemTemplate>
                            </dx:GridViewDataColumn>
                            <dx:GridViewDataColumn FieldName="ID" HeaderStyle-Font-Bold="true" Caption="ID">
                                    <DataItemTemplate>
                                        <dx:ASPxLabel ID="lblID" Text='<%# Eval("ID") %>' runat="server"></dx:ASPxLabel>
                                    </DataItemTemplate>
                            </dx:GridViewDataColumn>
                            <dx:GridViewDataColumn HeaderStyle-Font-Bold="true" Caption="Client No.">
                                    <DataItemTemplate>
                                        <dx:ASPxLabel Text='<%# Eval("ClientNo") %>' runat="server"></dx:ASPxLabel>
                                    </DataItemTemplate>
                            </dx:GridViewDataColumn>
                            <dx:GridViewDataColumn HeaderStyle-Font-Bold="true" Caption="Names">
                                    <DataItemTemplate>
                                        <dx:ASPxLabel Text='<%# Eval("Holder") %>' runat="server"></dx:ASPxLabel>
                                    </DataItemTemplate>
                            </dx:GridViewDataColumn>
                            <dx:GridViewDataColumn HeaderStyle-Font-Bold="true" Caption="Asset Manager">
                                    <DataItemTemplate>
                                        <dx:ASPxLabel Text='<%# Eval("AssetManager") %>' runat="server"></dx:ASPxLabel>
                                    </DataItemTemplate>
                            </dx:GridViewDataColumn>
                            <dx:GridViewDataColumn HeaderStyle-Font-Bold="true" Caption="Date From">
                                    <DataItemTemplate>
                                        <dx:ASPxLabel Text='<%# Eval("DateFrom1") %>' runat="server"></dx:ASPxLabel>
                                    </DataItemTemplate>
                            </dx:GridViewDataColumn>
                            <dx:GridViewDataColumn HeaderStyle-Font-Bold="true" Caption="Date To">
                                    <DataItemTemplate>
                                        <dx:ASPxLabel Text='<%# Eval("DateTo1") %>' runat="server"></dx:ASPxLabel>
                                    </DataItemTemplate>
                            </dx:GridViewDataColumn>
                            <dx:GridViewDataColumn HeaderStyle-Font-Bold="true" Caption="Portfolio Value" CellStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Right">
                                    <DataItemTemplate>
                                        <dx:ASPxLabel Text='<%# Eval("PortfolioValue") %>' runat="server"></dx:ASPxLabel>
                                    </DataItemTemplate>
                            </dx:GridViewDataColumn>
                            <dx:GridViewDataColumn HeaderStyle-Font-Bold="true" Caption="Portfolio Charges" CellStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Right">
                                    <DataItemTemplate>
                                        <dx:ASPxLabel Text='<%# Eval("ChargeAmount") %>' runat="server"></dx:ASPxLabel>
                                    </DataItemTemplate>
                            </dx:GridViewDataColumn>
                            <dx:GridViewDataColumn HeaderStyle-Font-Bold="true" Caption="Transaction Charges" CellStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Right">
                                    <DataItemTemplate>
                                        <dx:ASPxLabel Text='<%# Eval("ChargesTransactions") %>' runat="server"></dx:ASPxLabel>
                                    </DataItemTemplate>
                            </dx:GridViewDataColumn>
                            <dx:GridViewDataColumn HeaderStyle-Font-Bold="true" Caption="Total Charges" CellStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Right">
                                    <DataItemTemplate>
                                        <dx:ASPxLabel Text='<%# Eval("TotalCharges") %>' runat="server"></dx:ASPxLabel>
                                    </DataItemTemplate>
                            </dx:GridViewDataColumn>
                            <dx:GridViewDataColumn HeaderStyle-Font-Bold="true" Caption="InterCompany A/C Name" CellStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Right">
                                    <DataItemTemplate>
                                        <dx:ASPxLabel Text='<%# Eval("InterCompanyAccountName") %>' runat="server"></dx:ASPxLabel>
                                    </DataItemTemplate>
                            </dx:GridViewDataColumn>
                            <dx:GridViewDataColumn HeaderStyle-Font-Bold="true" Caption="InterCompany A/C Number" CellStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Right">
                                    <DataItemTemplate>
                                        <dx:ASPxLabel Text='<%# Eval("InterCompanyAccountNumber") %>' runat="server"></dx:ASPxLabel>
                                    </DataItemTemplate>
                            </dx:GridViewDataColumn>
                        </Columns>
                    </dx:ASPxGridView>
                </td>
            </tr>
           <tr id="Tr2" runat="server">
                <td colspan="6">
                    <dx:ASPxLabel ID="ASPxLabel2" runat="server" Font-Names="Cambria" Font-Size="Small" Text="" Theme="Glass">
                    </dx:ASPxLabel>
                   <hr/>
                </td>
            </tr>
           <tr id="PanelSAVE" runat="server" visible="true">
                        <td style="width:208px"></td>
                        <td style="width:212px">
                            &nbsp;<dx:ASPxButton ID="btnSave" runat="server" Text="Authorize" Theme="Glass">
                            </dx:ASPxButton>
                        </td>
                        <td style="width:208px"></td>
                        <td style="width:212px">
                            &nbsp;<dx:ASPxButton ID="btnDiscard" runat="server" Text="Reject" Theme="Glass">
                            </dx:ASPxButton>
                        </td>
                </tr>
        </table> 
      </asp:Panel>
</asp:Content>

