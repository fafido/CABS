<%@ Page Title="" Language="VB" MasterPageFile="~/CDSUser.master" AutoEventWireup="false" CodeFile="clientdocs.aspx.vb" Inherits="Reporting_clientdocs" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
    <asp:Panel id="Panel1" runat="server" Width="100%" Font-Names="Arial" Font-Size="Medium" BackColor="White">
    
        <table width ="100%">
            <tr>
                   <td style ="text-align :left;" align="left">
                       <dx:ASPxLabel ID="ASPxLabel1" runat="server" Text="Reporting&gt;&gt;Client Documents" Font-Names="Cambria" Font-Size="Small" Theme="PlasticBlue"></dx:ASPxLabel>

                   </td>
            </tr>
        </table>
        <asp:panel id="Panel5" runat="server" GroupingText="Search Options" Font-Names="Cambria">
        <table width="100%">
           
            <tr>
                <td colspan="5">
                    <dx:ASPxGridView ID="grddocuments" runat="server" KeyFieldName="id" Settings-ShowTitlePanel="true" Theme="Glass" Width="100%">
                        <SettingsBehavior AllowSelectByRowClick="True" AllowSelectSingleRowOnly="True" ProcessSelectionChangedOnServer="True" />
                        <SettingsPager PageSizeItemSettings-ShowAllItem="true" Visible="True">
                        </SettingsPager>
                        <SettingsPopup>
                            <EditForm AllowResize="True" Modal="True" />
                        </SettingsPopup>
                        <SettingsCommandButton>
                            <SelectButton Text="Select">
                            </SelectButton>
                        </SettingsCommandButton>
                        <Columns>
                            <dx:GridViewDataColumn Caption="" VisibleIndex="0">
                                <DataItemTemplate>
                                    <asp:LinkButton ID="ViewDoc1" runat="server" CommandArgument='<%# Eval("ID") %>' CommandName="View Document" Text="View Document">
                                                              </asp:LinkButton>
                                </DataItemTemplate>
                            </dx:GridViewDataColumn>
                         
                            <dx:GridViewDataColumn Caption="" VisibleIndex="0">
                                <DataItemTemplate>
                                    <asp:LinkButton ID="DeleteID1" runat="server" CommandArgument='<%# Eval("ID") %>' CommandName="Mark As Received" OnClientClick="if ( !confirm('Are you sure you want to mark as received? ')) return false;" Text="Mark as Received">
                                                              </asp:LinkButton>
                                </DataItemTemplate>
                            </dx:GridViewDataColumn>
                            <dx:GridViewDataColumn Caption="Client/Fund Name">
                                <DataItemTemplate>
                                    <dx:ASPxLabel ID="ASPxLabel2" runat="server" Text='<%# Eval("ClientName") %>'>
                                    </dx:ASPxLabel>
                                </DataItemTemplate>
                            </dx:GridViewDataColumn>
                            <dx:GridViewDataColumn Caption="Asset Manager">
                                <DataItemTemplate>
                                    <dx:ASPxLabel runat="server" Text='<%# Eval("AccountNo") %>'>
                                    </dx:ASPxLabel>
                                </DataItemTemplate>
                            </dx:GridViewDataColumn>
                            <dx:GridViewDataColumn Caption="Uploaded By">
                                <DataItemTemplate>
                                    <dx:ASPxLabel runat="server" Text='<%# Eval("CreatedBy") %>'>
                                    </dx:ASPxLabel>
                                </DataItemTemplate>
                            </dx:GridViewDataColumn>
                            <dx:GridViewDataColumn Caption="Date Created">
                                <DataItemTemplate>
                                    <dx:ASPxLabel runat="server" Text='<%# Eval("DateCreated") %>'>
                                    </dx:ASPxLabel>
                                </DataItemTemplate>
                            </dx:GridViewDataColumn>
                            <dx:GridViewDataColumn Caption="Document Type">
                                <DataItemTemplate>
                                    <dx:ASPxLabel runat="server" Text='<%# Eval("DocumentName") %>'>
                                    </dx:ASPxLabel>
                                </DataItemTemplate>
                            </dx:GridViewDataColumn>
                            <dx:GridViewDataColumn Caption="File Name">
                                <DataItemTemplate>
                                    <dx:ASPxLabel runat="server" Text='<%# Eval("FileName") %>'>
                                    </dx:ASPxLabel>
                                </DataItemTemplate>
                            </dx:GridViewDataColumn>
                            <dx:GridViewDataColumn Caption="File Extension">
                                <DataItemTemplate>
                                    <dx:ASPxLabel runat="server" Text='<%# Eval("Extension") %>'>
                                    </dx:ASPxLabel>
                                </DataItemTemplate>
                            </dx:GridViewDataColumn>
                        </Columns>
                        <%-- W.EWR_Holder as [Account No], W.Company as [Details], W.ReceiptID AS [EWR No.], 
                                case when W.approvedby is NULL then 'Pending' else 'Approved' end as  [Status],  W.[Date],
                                 W.amount_to_withdraw ,wr.Commodity, wr.Grade, wr.WarehousePhysical, wr.Date_Issued, wr.[Status] --%>
                    </dx:ASPxGridView>
                </td>
              
            </tr>
            <tr>
                <td colspan="5">&nbsp;</td>
            </tr>
            <tr>
                <td colspan="5">
                    <dx:ASPxLabel ID="ASPxLabel15" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Completed Requests" Theme="Glass">
                    </dx:ASPxLabel>
                </td>
            </tr>
            <tr>
                <td colspan="5">
                    <dx:ASPxGridView ID="grddocuments0" runat="server" KeyFieldName="id" Settings-ShowTitlePanel="true" Theme="Glass" Width="100%">
                            <SettingsBehavior AllowSelectByRowClick="True" AllowSelectSingleRowOnly="True" ProcessSelectionChangedOnServer="True" />
                            <SettingsPager PageSizeItemSettings-ShowAllItem="true"   Visible="True">
                            </SettingsPager>
                             <Settings ShowFilterRow="True" />
                            <SettingsPopup>
                                <EditForm AllowResize="True" Modal="True" />
                            </SettingsPopup>
                            <SettingsCommandButton>
                                <SelectButton Text="Select">
                                </SelectButton>
                            </SettingsCommandButton>
                                            <Columns>
                            <dx:GridViewDataColumn Caption="" VisibleIndex="0">
                                <DataItemTemplate>
                                    <asp:LinkButton ID="ViewDoc2" runat="server" CommandArgument='<%# Eval("ID") %>' CommandName="View Document" Text="View Document">
                                                              </asp:LinkButton>
                                </DataItemTemplate>
                            </dx:GridViewDataColumn>
                                                  <dx:GridViewDataTextColumn Name="Client Name" FieldName="ClientName" Settings-AutoFilterCondition="Contains">    </dx:GridViewDataTextColumn>
                               <dx:GridViewDataTextColumn Name="Client No" FieldName="AccountNo" Settings-AutoFilterCondition="Contains">    </dx:GridViewDataTextColumn>
                              <dx:GridViewDataTextColumn Name="Uploaded By" FieldName="CreatedBy" Settings-AutoFilterCondition="Contains">    </dx:GridViewDataTextColumn>
                            <dx:GridViewDataColumn Caption="Date Created">
                                <DataItemTemplate>
                                    <dx:ASPxLabel runat="server" Text='<%# Eval("DateCreated") %>'>
                                    </dx:ASPxLabel>
                                </DataItemTemplate>
                            </dx:GridViewDataColumn>
                               <dx:GridViewDataTextColumn Name="Document Name" FieldName="DocumentName" Settings-AutoFilterCondition="Contains">    </dx:GridViewDataTextColumn>
                               <dx:GridViewDataTextColumn Name="File Name" FieldName="FileName" Settings-AutoFilterCondition="Contains">    </dx:GridViewDataTextColumn>
                              <dx:GridViewDataTextColumn Name="File Extension" FieldName="Extension" Settings-AutoFilterCondition="Contains">    </dx:GridViewDataTextColumn>
                               <dx:GridViewDataTextColumn Name="ReceivedBy" FieldName="ReceivedBy" Settings-AutoFilterCondition="Contains">    </dx:GridViewDataTextColumn>
                                 <dx:GridViewDataTextColumn Name="DateReceived" FieldName="ReceivedDate" Settings-AutoFilterCondition="Contains">    </dx:GridViewDataTextColumn>
                        </Columns>
                        <%-- W.EWR_Holder as [Account No], W.Company as [Details], W.ReceiptID AS [EWR No.], 
                                case when W.approvedby is NULL then 'Pending' else 'Approved' end as  [Status],  W.[Date],
                                 W.amount_to_withdraw ,wr.Commodity, wr.Grade, wr.WarehousePhysical, wr.Date_Issued, wr.[Status] --%>
                    </dx:ASPxGridView>
                </td>
            </tr>
            <tr>
                <td align="center" colspan="3">
            
                    <dx:ASPxButton ID="btnPrint0" runat="server" Text="Clear" Theme="BlackGlass" Width="150px">
                    </dx:ASPxButton>
                </td>
            </tr>

        </table>

    </asp:panel>
         
</asp:Panel>
  
</div>
</asp:Content>

