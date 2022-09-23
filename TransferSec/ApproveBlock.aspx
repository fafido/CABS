<%@ Page Language="VB" MasterPageFile="~/CDSUser.master" AutoEventWireup="false" CodeFile="ApproveBlock.aspx.vb" Inherits="TransferSec_ApproveBlock" title="Block/Un-Block Approval" %>
<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<%@ Register assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxRoundPanel" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxPanel" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.Aspxdateedit" tagprefix="dx" %>


<%@ Register assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxFormLayout" tagprefix="dx" %>


<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxRibbon" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxFormLayout" TagPrefix="dx" %>

<%@ Register assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxDocking" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxPopupControl" tagprefix="dx" %>
<asp:Content id="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
    <asp:Panel id="Panel1" runat="server" Width="100%" Font-Names="Arial" Font-Size="Medium" BackColor="White">
    
        <table width ="100%">
            <tr>
                   <td style ="text-align :left;" align="left">
                       <dx:ASPxLabel ID="ASPxLabel1" runat="server" Text="Account Maintenance&gt;&gt;Block/Un-Block Approval" Font-Names="Cambria" Font-Size="Small" Theme="PlasticBlue"></dx:ASPxLabel>

                   </td>
            </tr>
        </table>

        
        <asp:Panel ID="Panel3" runat="server" Font-Names="Cambria" Font-Size="Medium" GroupingText="Block/Un-Block Approval">
            <table width="100%">
                <tr>
                    <td colspan="7" style="height: 26px">
                        <dx:ASPxGridView ID="grddocuments" Width="100%" runat="server" KeyFieldName="id" Settings-ShowTitlePanel="true" Theme="Glass">
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
                                        <asp:LinkButton ID="DeleteID0" runat="server" CommandArgument='<%# Eval("ID") %>' CommandName="Approve" OnClientClick="if ( !confirm('Are you sure you want to approve this action? ')) return false;" Text="Approve">
                                                              </asp:LinkButton>
                                    </DataItemTemplate>
                                </dx:GridViewDataColumn>
                                  <dx:GridViewDataColumn Caption="" VisibleIndex="0">
                                    <DataItemTemplate>
                                        <asp:LinkButton ID="DeleteID1" runat="server" CommandArgument='<%# Eval("ID") %>' CommandName="Decline" OnClientClick="if ( !confirm('Are you sure you want to decline this action? ')) return false;" Text="Decline">
                                                              </asp:LinkButton>
                                    </DataItemTemplate>
                                </dx:GridViewDataColumn>
                                <dx:GridViewDataColumn Caption="Account No.">
                                    <DataItemTemplate>
                                        <dx:ASPxLabel runat="server" Text='<%# Eval("cds_number") %>'>
                                        </dx:ASPxLabel>
                                    </DataItemTemplate>
                                </dx:GridViewDataColumn>
                                <dx:GridViewDataColumn Caption="Names">
                                    <DataItemTemplate>
                                        <dx:ASPxLabel runat="server" Text='<%# Eval("names")%>'>
                                        </dx:ASPxLabel>
                                    </DataItemTemplate>
                                </dx:GridViewDataColumn>
                                <dx:GridViewDataColumn Caption="Action">
                                    <DataItemTemplate>
                                        <dx:ASPxLabel runat="server" Text='<%# Eval("status") %>'>
                                        </dx:ASPxLabel>
                                    </DataItemTemplate>
                                </dx:GridViewDataColumn>
                                <dx:GridViewDataColumn Caption="Action By">
                                    <DataItemTemplate>
                                        <dx:ASPxLabel runat="server" Text='<%# Eval("BlockedBy") %>'>
                                        </dx:ASPxLabel>
                                    </DataItemTemplate>
                                </dx:GridViewDataColumn>
                                <dx:GridViewDataColumn Caption="Action Date">
                                    <DataItemTemplate>
                                        <dx:ASPxLabel runat="server" Text='<%# Eval("blockdate") %>'>
                                        </dx:ASPxLabel>
                                    </DataItemTemplate>
                                </dx:GridViewDataColumn>
                                <dx:GridViewDataColumn Caption="Reason">
                                    <DataItemTemplate>
                                        <dx:ASPxLabel runat="server" Text='<%# Eval("reason") %>'>
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
                    <td align="center" colspan="7">&nbsp;</td>
                </tr>
                <tr>
                    <td colspan="1">
                        <asp:Label ID="lblid" runat="server" Visible="False"></asp:Label>
                    </td>
                    <td colspan="1">&nbsp;</td>
                    <td colspan="1">&nbsp;</td>
                    <td colspan="1">&nbsp;</td>
                    <td colspan="1">&nbsp;</td>
                    <td colspan="1">&nbsp;</td>
                    <td colspan="1">&nbsp;</td>
                </tr>
                <tr>
                    <td align="center" colspan="7">
                        &nbsp;</td>
                </tr>
            </table>
        </asp:Panel>
               
</asp:Panel>
  
</div>
</asp:Content>

