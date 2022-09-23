<%@ Page Language="VB" MasterPageFile="~/CDSUser.master" AutoEventWireup="false" CodeFile="Sinkingfund.aspx.vb" Inherits="TransferSec_Sinkingfund" title="Sinking Fund" %>
<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<%@ Register assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxRoundPanel" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxPanel" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.Aspxdateedit" tagprefix="dx" %>

<%@ Register assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxFormLayout" tagprefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView.Export" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxRibbon" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxFormLayout" TagPrefix="dx" %>

<%@ Register assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxDocking" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxPopupControl" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxTabControl" tagprefix="dx1" %>
<%@ Register assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxRibbon" tagprefix="dx" %>
<asp:Content id="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
    <asp:Panel id="Panel1" runat="server" Width="100%" Font-Names="Arial" Font-Size="Medium" BackColor="White">
    
        <table width ="100%">
            <tr>
                   <td style ="text-align :left;" align="left">
                       <dx:ASPxLabel ID="ASPxLabel1" runat="server" Text="Bond&gt;&gt;Sinking Fund Administration" Font-Names="Cambria" Font-Size="Small" Theme="PlasticBlue"></dx:ASPxLabel>

                   </td>
            </tr>
        </table>

        
        <asp:Panel ID="Panel3" runat="server" Font-Names="Cambria" Font-Size="Medium" GroupingText="Sinking Fund">
            <table width="100%">
                <tr>
                    <td colspan="7" style="height: 26px">
                        <table class="dxflInternalEditorTable_Glass">
                            <tr>
                                <td style="width: 158px">
                                    <dx:ASPxLabel ID="ASPxLabel44" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Select Bond Series" Theme="Glass">
                                    </dx:ASPxLabel>
                                </td>
                                <td>
                                    <dx:ASPxComboBox ID="cmbIssuer" runat="server" AutoPostBack="True" Height="23px" Width="250px">
                                        <ValidationSettings>
                                            <RequiredField IsRequired="True" />
                                        </ValidationSettings>
                                    </dx:ASPxComboBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 158px">&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td colspan="7" style="height: 26px">
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
                                <dx:GridViewDataColumn Caption="Series">
                                    <DataItemTemplate>
                                        <dx:ASPxLabel runat="server" Text='<%# Eval("Series") %>'>
                                        </dx:ASPxLabel>
                                    </DataItemTemplate>
                                </dx:GridViewDataColumn>
                                <dx:GridViewDataColumn Caption="PaymentNo">
                                    <DataItemTemplate>
                                        <dx:ASPxLabel runat="server" Text='<%# Eval("PaymentNo") %>'>
                                        </dx:ASPxLabel>
                                    </DataItemTemplate>
                                </dx:GridViewDataColumn>
                                <dx:GridViewDataColumn Caption="Target Amount">
                                    <DataItemTemplate>
                                        <dx:ASPxLabel runat="server" Text='<%# Eval("TotalAmount") %>'>
                                        </dx:ASPxLabel>
                                    </DataItemTemplate>
                                </dx:GridViewDataColumn>
                                <dx:GridViewDataColumn Caption="Intervals">
                                    <DataItemTemplate>
                                        <dx:ASPxLabel runat="server" Text='<%# Eval("Intervals") %>'>
                                        </dx:ASPxLabel>
                                    </DataItemTemplate>
                                </dx:GridViewDataColumn>
                                <dx:GridViewDataColumn Caption="Amount">
                                    <DataItemTemplate>
                                        <dx:ASPxLabel runat="server" Text='<%# Eval("Amount") %>'>
                                        </dx:ASPxLabel>
                                    </DataItemTemplate>
                                </dx:GridViewDataColumn>
                                <dx:GridViewDataColumn Caption="Paid">
                                    <DataItemTemplate>
                                        <dx:ASPxLabel runat="server" Text='<%# Eval("Paid") %>'>
                                        </dx:ASPxLabel>
                                    </DataItemTemplate>
                                </dx:GridViewDataColumn>
                                <dx:GridViewDataColumn Caption="PaymentDate">
                                    <DataItemTemplate>
                                        <dx:ASPxLabel runat="server" Text='<%# Eval("PaymentDate") %>'>
                                        </dx:ASPxLabel>
                                    </DataItemTemplate>
                                </dx:GridViewDataColumn>
                                <dx:GridViewDataColumn Caption="" VisibleIndex="9">
                                    <DataItemTemplate>
                                        <asp:LinkButton ID="DeleteID0" runat="server" CommandArgument='<%# Eval("ID") %>' CommandName="Mark Paid" OnClientClick="if ( !confirm('Are you sure you want to mark this as Paid? ')) return false;" Text="Mark Paid">
                                                              </asp:LinkButton>
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
                    <td align="left" colspan="7">
                        <table class="dxflInternalEditorTable_Glass" style="width: 19%">
                            <tr>
                                <td style="height: 27px; width: 192px">
                                    <dx:ASPxComboBox ID="cmbexport" runat="server" DropDownstyle="DropDown" EnableIncrementalFiltering="True" HelpText="Export to" IncrementalFilteringMode="StartsWith" style="height: 19px" Theme="Glass" Width="250px">
                                        <Items>
                                            <dx:ListEditItem Text="PDF" Value="PDF" />
                                            <dx:ListEditItem Text="EXCEL" Value="EXCEL" />
                                            <dx:ListEditItem Text="RTF" Value="RTF" />
                                            <dx:ListEditItem Text="CSV" Value="CSV" />
                                        </Items>
                                        <HelpTextSettings Position="Top">
                                        </HelpTextSettings>
                                    </dx:ASPxComboBox>
                                </td>
                                <td valign="bottom" style="height: 27px">
                                    <dx:ASPxButton ID="btnSaveContract2" runat="server" CausesValidation="False" Height="20px" text="Export" Theme="Glass">
                                    </dx:ASPxButton>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td colspan="1" style="height: 27px">
                        <asp:Label ID="lblid" runat="server" Visible="False"></asp:Label>
                        <dx:ASPxGridViewExporter ID="ASPxGridViewExporter1" FileName="SinkingFund" runat="server" GridViewID="ASPxGridView1">
                        </dx:ASPxGridViewExporter>
                    </td>
                    <td colspan="1" style="height: 27px"></td>
                    <td colspan="1" style="height: 27px"></td>
                    <td colspan="1" style="height: 27px"></td>
                    <td colspan="1" style="height: 27px"></td>
                    <td colspan="1" style="height: 27px"></td>
                    <td colspan="1" style="height: 27px"></td>
                </tr>
                <tr>
                    <td align="center" colspan="7">
                        <dx:ASPxGridView ID="ASPxGridView1" runat="server" Theme="Glass" Visible="False" Width="100%">
                            <Settings ShowFilterRow="True" />
                            <%--<Columns>
                                   <dx:GridViewDataTextColumn Name="Trade Date" FieldName="TradeDate" Settings-AutoFilterCondition="Contains">    </dx:GridViewDataTextColumn>
                                 <dx:GridViewDataTextColumn Name="Settlement Date" FieldName="SettlementDate" Settings-AutoFilterCondition="Contains">    </dx:GridViewDataTextColumn>
                                      <dx:GridViewDataTextColumn Name="Company" FieldName="Company" Settings-AutoFilterCondition="Contains">    </dx:GridViewDataTextColumn>
                                      <dx:GridViewDataTextColumn Name="Client No" FieldName="ClientNo" Settings-AutoFilterCondition="Contains">    </dx:GridViewDataTextColumn>
                                      <dx:GridViewDataTextColumn Name="Names" FieldName="Names" Settings-AutoFilterCondition="Contains">    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn Name="Asset Manager" FieldName="AssetManager" Settings-AutoFilterCondition="Contains">    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn Name="Trade Type" FieldName="TradeType" Settings-AutoFilterCondition="Contains">    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn Name="Quantity" FieldName="Quantity" PropertiesTextEdit-DisplayFormatString="n" Settings-AutoFilterCondition="Equals">    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn Name="Price" FieldName="Price" Settings-AutoFilterCondition="Equals">    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn Name="Gross" FieldName="Gross" PropertiesTextEdit-DisplayFormatString="n" Settings-AutoFilterCondition="Equals">    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn Name="Settlement Amount" PropertiesTextEdit-DisplayFormatString="n" FieldName="SettlementAmount" Settings-AutoFilterCondition="Equals">    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn Name="Trade Currency" FieldName="TradeCurrency" Settings-AutoFilterCondition="Contains">    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn Name="Settlement Currency" FieldName="SettlementCurrency" Settings-AutoFilterCondition="Contains">    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn Name="Trade Status" FieldName="TradeStatus" Settings-AutoFilterCondition="Contains">    </dx:GridViewDataTextColumn>
                            </Columns>--%>
                        </dx:ASPxGridView>
                    </td>
                </tr>
            </table>
        </asp:Panel>
               
</asp:Panel>
  
</div>
</asp:Content>

