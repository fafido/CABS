

<%@ Page Language="VB" MasterPageFile="~/CDSUser.master" AutoEventWireup="false" CodeFile="Enq_VaultAv.aspx.vb" Inherits="TransferSec_Enq_VaultAv" title="Vault Report" %>

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
     <asp:Panel id="Panel1" runat="server" Width="100%" Font-Names="Arial" Font-Size="Medium" BackColor="White">
    
        <table width ="100%">
            <tr>
                   <td style ="text-align :left;" align="left">
                       <dx:ASPxLabel ID="ASPxLabel1" runat="server" Text="Vault&gt;&gt;Equity" Font-Names="Cambria" Font-Size="Small" Theme="PlasticBlue"></dx:ASPxLabel>

                   </td>
            </tr>
        </table>
           <asp:Panel ID="Panel3" runat="server" Font-Names="Cambria" Font-Size="Medium" GroupingText="Vault Enquiry">
            <table width="100%">
              
                <tr><td> 
                    <table class="dxflInternalEditorTable_Glass">
                        <tr>
                            <td style="width: 104px">
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width: 104px">
                                <dx:ASPxLabel ID="ASPxLabel4" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Filter Type" Theme="Glass">
                                </dx:ASPxLabel>
                            </td>
                            <td>
                                <dx:ASPxComboBox ID="cmbfilter" runat="server" AutoPostBack="true" DropDownstyle="DropDown" IncrementalFilteringMode="StartsWith" Theme="Glass" Width="250px">
                                </dx:ASPxComboBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 104px">
                                <dx:ASPxLabel ID="ASPxLabel5" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Value" Theme="Glass">
                                </dx:ASPxLabel>
                            </td>
                            <td>
                                <dx:ASPxComboBox ID="cmbvalue" runat="server" DropDownstyle="DropDown" IncrementalFilteringMode="StartsWith" Theme="Glass" Width="250px">
                                </dx:ASPxComboBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 104px">
                                <dx:ASPxLabel ID="ASPxLabel6" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Date Type" Theme="Glass">
                                </dx:ASPxLabel>
                            </td>
                            <td>
                                <dx:ASPxComboBox ID="cmbdatetype" runat="server" DropDownstyle="DropDown" IncrementalFilteringMode="StartsWith" Theme="Glass" Width="250px">
                                    <ValidationSettings RequiredField-IsRequired="true" ></ValidationSettings>
                                </dx:ASPxComboBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 104px">
                                <dx:ASPxLabel ID="ASPxLabel8" runat="server" Font-Names="Cambria" Font-Size="Small" Text="As at" Theme="Glass">
                                </dx:ASPxLabel>
                            </td>
                            <td>
                                <dx:ASPxDateEdit ID="dtto" runat="server"  DisplayFormatString="dd-MM-yyyy" Width="250px">
                                    <ValidationSettings>
                                        <RequiredField IsRequired="True" />
                                    </ValidationSettings>
                                </dx:ASPxDateEdit>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 104px">&nbsp;</td>
                            <td>
                                <dx:ASPxButton ID="btnSaveContract1" runat="server" CausesValidation="False" Text="View" Theme="Glass">
                                </dx:ASPxButton>
                                &nbsp;&nbsp;
                                <dx:ASPxButton ID="btnSaveContract3" runat="server" CausesValidation="False" Text="Edit Columns" Theme="Glass">
                                </dx:ASPxButton>
                            </td>
                        </tr>
                    </table>
                    </td></tr>
                <tr>
                    <td>
                        <dx:ASPxGridView ID="ASPxGridView1" runat="server" Theme="Glass" Width="100%">
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
                <tr>
                    <td align="LEFT">
                        <table>
                            <tr>
                                <td style="width: 55px">
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
                                <td style="vertical-align:bottom">
                                    <dx:ASPxButton ID="btnSaveContract2" runat="server" CausesValidation="False"  Height="20px" text="Export" Theme="Glass">
                                    </dx:ASPxButton>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td align="LEFT">
                        <dx:ASPxGridViewExporter ID="ASPxGridViewExporter1" runat="server" GridViewID="ASPxGridView1">
                        </dx:ASPxGridViewExporter>
                    </td>
                </tr>
                <tr>
                    <td align="center">
                        <dx:ASPxPopupControl ID="ASPxPopupControl1" runat="server" BackColor="#DDECFE" CloseAction="CloseButton" EnableCallbackAnimation="True" HeaderText="Enquiry Columns" Modal="true" ShowCollapseButton="False" ShowMaximizeButton="False" ShowPageScrollbarWhenModal="True" ShowPinButton="False" ShowRefreshButton="False" Theme="Glass">
                            <contentcollection>
                                <dx:PopupControlContentControl runat="server" SupportsDisabledAttribute="True">
                                    <dx:aspxroundpanel ID="ASPxRoundPanel8" runat="server" ShowHeader="False" Theme="Glass" Width="100%">
                            <panelcollection>
                                <dx:panelcontent runat="server" SupportsDisabledAttribute="True">
                                    <table class="dxflInternalEditorTable_Moderno" style="width: 100%">
                                        <tr>
                                            <td>
                                                <dx:ASPxGridView ID="grdcols" runat="server" AutoGenerateColumns="False" KeyFieldName="report_column" Theme="Glass" Width="100%">
                                                    <Columns>
                                                         <dx:GridViewDataColumn Caption="Select" FieldName="Selec"  VisibleIndex="0">
                                    <DataItemTemplate>
                                        <dx:aspxcheckbox ID="chk1" Checked='<%# Eval("chk") %>' runat="server" >
                                                              </dx:aspxcheckbox>
                                    </DataItemTemplate>
                                </dx:GridViewDataColumn>
                                                        
                                                                                                         <dx:GridViewDataColumn Caption="Column" ShowInCustomizationForm="True" VisibleIndex="2">
                                                            <DataItemTemplate>
                                                                <dx:ASPxLabel runat="server" Text='<%# Eval("report_column") %>'>
                                                                </dx:ASPxLabel>
                                                            </DataItemTemplate>
                                                            <HeaderStyle Font-Bold="True" />
                                                        </dx:GridViewDataColumn>
                                                    </Columns>
                                                    <SettingsPager Mode="ShowAllRecords" Visible="False">
                                                    </SettingsPager>
                                                </dx:ASPxGridView>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <dx:ASPxButton ID="btnSaveContract4" runat="server" CausesValidation="False" Text="Save Change" Theme="Glass">
                                                </dx:ASPxButton>
                                            </td>
                                        </tr>
                                    </table>
                                </dx:panelcontent>
                            </panelcollection>
              </dx:aspxroundpanel>
                                </dx:PopupControlContentControl>
                            </contentcollection>
                        </dx:ASPxPopupControl>
                    </td>
                </tr>
                </table>

               </asp:Panel>
   <%-- 

   
</table>
--%>

         </asp:Panel>
   

</asp:Content>
