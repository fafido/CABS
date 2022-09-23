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
                <td colspan ="1" align="right" style="width: 258px">
                    <dx:ASPxLabel ID="ASPxLabel13" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Search Name/Account No/Mobile" Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                <td colspan ="1" width="301">
                    <dx:ASPxTextBox ID="txtSeachName" runat="server" Theme="BlackGlass" Width="400px">
                    </dx:ASPxTextBox>
                </td>
                <td colspan ="1">
                    &nbsp;</td>
                <td colspan ="1">
                    <dx:ASPxButton ID="btnSearch" runat="server" Text="&gt;&gt;" Theme="BlackGlass" Width="80px">
                    </dx:ASPxButton>
                </td>
                <td colspan ="1"></td>

            </tr>
             <tr>
                <td colspan ="1" align="right" style="width: 258px">
                    &nbsp;</td>
                <td colspan ="1" width="301">
                    <dx:ASPxListBox ID="lstSearchAcc" runat="server" AutoPostBack="True" Theme="Glass" ValueType="System.String" Width="400px">
                    </dx:ASPxListBox>
                 </td>
                <td colspan ="1">
                    &nbsp;</td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>

            </tr>
            <tr>
                <td colspan ="1" style="width: 258px"></td>
                <td colspan ="2">
                    <dx:ASPxLabel ID="lblCDsNumber" runat="server" Theme="BlackGlass">
                    </dx:ASPxLabel>
                    <dx:ASPxLabel ID="lblCDsAccount" runat="server" Theme="BlackGlass">
                    </dx:ASPxLabel>
                </td>
                
                <td colspan ="1"></td>
                <td colspan ="1"></td>

            </tr>
            <tr>
                <td colspan="4">
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
                                    <asp:LinkButton ID="ViewDoc1" runat="server" CommandArgument='<%# Eval("ID") %>' CommandName="View Document" Text="View Document">
                                                              </asp:LinkButton>
                                </DataItemTemplate>
                            </dx:GridViewDataColumn>
                            <dx:GridViewDataColumn Caption="" VisibleIndex="0">
                                <DataItemTemplate>
                                    <asp:LinkButton ID="DeleteID0" runat="server" CommandArgument='<%# Eval("ID") %>' CommandName="Remove Document" OnClientClick="if ( !confirm('Are you sure you want to remove document? ')) return false;" Text="Remove Document">
                                                              </asp:LinkButton>
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
                            <dx:GridViewDataColumn Caption="Reference">
                                <DataItemTemplate>
                                    <dx:ASPxLabel runat="server" Text='<%# Eval("Reference") %>'>
                                    </dx:ASPxLabel>
                                </DataItemTemplate>
                            </dx:GridViewDataColumn>
                        </Columns>
                        <%-- W.EWR_Holder as [Account No], W.Company as [Details], W.ReceiptID AS [EWR No.], 
                                case when W.approvedby is NULL then 'Pending' else 'Approved' end as  [Status],  W.[Date],
                                 W.amount_to_withdraw ,wr.Commodity, wr.Grade, wr.WarehousePhysical, wr.Date_Issued, wr.[Status] --%>
                    </dx:ASPxGridView>
                </td>
                <td colspan="1">&nbsp;</td>
            </tr>
            <tr>
                <td colspan="5">&nbsp;</td>
            </tr>
            <tr>
                <td colspan="1" style="width: 258px">
                </td>
                <td colspan="1">
                    &nbsp;<dx:ASPxButton ID="btnPrint0" runat="server" Text="Clear" Theme="BlackGlass" Width="150px">
                    </dx:ASPxButton>
                </td>
            </tr>

        </table>

    </asp:panel>
         
</asp:Panel>
  
</div>
</asp:Content>

