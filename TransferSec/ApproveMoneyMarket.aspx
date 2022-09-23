<%@ Page Language="VB" MasterPageFile="~/CDSUser.master" AutoEventWireup="false" CodeFile="ApproveMoneyMarket.aspx.vb" Inherits="TransferSec_ApproveMoneyMarket" title="Approve Money Market" %>
<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<%@ Register assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxRoundPanel" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxPanel" tagprefix="dx" %>

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
                       <dx:ASPxLabel ID="ASPxLabel1" runat="server" Text="Trading&gt;&gt;Money Market Approval" Font-Names="Cambria" Font-Size="Small" Theme="PlasticBlue"></dx:ASPxLabel>

                   </td>
            </tr>
        </table>

        
        <asp:Panel ID="Panel3" runat="server" Font-Names="Cambria" Font-Size="Medium" GroupingText="Money Market Approval">
            <table width="100%">
                <tr>
                    <td colspan="7" style="height: 26px">
                        <dx:ASPxGridView ID="grddocuments" Width="100%" runat="server" KeyFieldName="id" Settings-ShowTitlePanel="true" Theme="Glass">
                            <SettingsBehavior AllowSelectByRowClick="True" ProcessSelectionChangedOnServer="True" />
                            <SettingsPager PageSizeItemSettings-ShowAllItem="true" Visible="True">
                                <PageSizeItemSettings ShowAllItem="True">
                                </PageSizeItemSettings>
                            </SettingsPager>
                            <Settings ShowTitlePanel="True" />
                            <SettingsPopup>
                                <EditForm AllowResize="True" Modal="True" />
                            </SettingsPopup>
                            <SettingsCommandButton>
                                <SelectButton Text="Select">
                                </SelectButton>
                            </SettingsCommandButton>
                            <Columns>
                                  <dx:GridViewDataColumn Caption="Select" FieldName="Selec"  VisibleIndex="0">
                                    <DataItemTemplate>
                                        <dx:aspxcheckbox ID="chk1" runat="server" >
                                                              </dx:aspxcheckbox>
                                    </DataItemTemplate>
                                </dx:GridViewDataColumn>

                          
                                <dx:GridViewDataColumn Caption="" VisibleIndex="0">
                                    <DataItemTemplate>
                                        <asp:LinkButton ID="ViewDoc1" runat="server" CommandArgument='<%# Eval("ID") %>' CommandName="View Money Market" Text="View Money Market">
                                                              </asp:LinkButton>
                                    </DataItemTemplate>
                                </dx:GridViewDataColumn>
                                <dx:GridViewDataColumn Caption="" VisibleIndex="0">
                                    <DataItemTemplate>
                                        <asp:LinkButton ID="DeleteID0" runat="server" CommandArgument='<%# Eval("ID") %>' CommandName="Approve Transaction" OnClientClick="if ( !confirm('Are you sure you want to post this Transaction? ')) return false;" Text="Approve Transaction">
                                                              </asp:LinkButton>
                                    </DataItemTemplate>
                                </dx:GridViewDataColumn>
                                  <dx:GridViewDataColumn Caption="" VisibleIndex="0">
                                    <DataItemTemplate>
                                        <asp:LinkButton ID="DeleteID1" runat="server" CommandArgument='<%# Eval("ID") %>' CommandName="Decline Transaction" OnClientClick="if ( !confirm('Are you sure you want to decline this Transaction? ')) return false;" Text="Decline Transaction">
                                                              </asp:LinkButton>
                                    </DataItemTemplate>
                                </dx:GridViewDataColumn>
                         <%--       <dx:GridViewDataColumn Caption="ID" FieldName ="ID">
                                    <DataItemTemplate>
                                        <dx:ASPxLabel runat="server" Text='<%# Eval("ID") %>'>
                                        </dx:ASPxLabel>
                                    </DataItemTemplate>
                                </dx:GridViewDataColumn>--%>
                                <dx:GridViewDataColumn Caption="Client">
                                    <DataItemTemplate>
                                        <dx:ASPxLabel runat="server" Text='<%# Eval("ClientNo") %>'>
                                        </dx:ASPxLabel>
                                    </DataItemTemplate>
                                </dx:GridViewDataColumn>

                                    <dx:GridViewDataColumn Caption="ClientName">
                                    <DataItemTemplate>
                                        <dx:ASPxLabel ID="meme" runat="server" Text='<%# Eval("ClientName") %>'>
                                        </dx:ASPxLabel>
                                    </DataItemTemplate>
                                </dx:GridViewDataColumn>
                                  
                                <dx:GridViewDataColumn Caption="Description">
                                    <DataItemTemplate>
                                        <dx:ASPxLabel runat="server" Text='<%# Eval("Description") %>'>
                                        </dx:ASPxLabel>
                                    </DataItemTemplate>
                                </dx:GridViewDataColumn>
                                <dx:GridViewDataColumn Caption="Amount">
                                    <DataItemTemplate>
                                        <dx:ASPxLabel runat="server" Text='<%# String.Format("{0:#,##0.00}", Eval("Amount")) %>'>
                                        </dx:ASPxLabel>
                                    </DataItemTemplate>
                                </dx:GridViewDataColumn>
                                <dx:GridViewDataColumn Caption="FixedRate">
                                    <DataItemTemplate>
                                        <dx:ASPxLabel runat="server" Text='<%# String.Format("{0:#,##0.00}", Eval("fixedRate")) %>'>
                                        </dx:ASPxLabel>
                                    </DataItemTemplate>
                                </dx:GridViewDataColumn>
                                  <dx:GridViewDataColumn Caption="MaturityDate">
                                    <DataItemTemplate>
                                        <dx:ASPxLabel runat="server" Text='<%# Eval("MaturityDate") %>'>
                                        </dx:ASPxLabel>
                                    </DataItemTemplate>
                                </dx:GridViewDataColumn>
                                <dx:GridViewDataColumn Caption="Currency">
                                    <DataItemTemplate>

                                        <dx:ASPxLabel runat="server" Text='<%# Eval("Currency") %>'>
                                        </dx:ASPxLabel>
                                    </DataItemTemplate>
                                </dx:GridViewDataColumn>
                                <dx:GridViewDataColumn Caption="Asset Manager">
                                    <DataItemTemplate>
                                        <dx:ASPxLabel runat="server" Text='<%# Eval("AssetManager") %>'>
                                        </dx:ASPxLabel>
                                    </DataItemTemplate>
                                </dx:GridViewDataColumn>
                                <dx:GridViewDataColumn Caption="Status">
                                    <DataItemTemplate>
                                        <dx:ASPxLabel runat="server" Text='<%# Eval("TradeStatus") %>'>
                                        </dx:ASPxLabel>
                                    </DataItemTemplate>
                                </dx:GridViewDataColumn>
                                  <dx:GridViewDataColumn Caption="Captured By">
                                    <DataItemTemplate>
                                        <dx:ASPxLabel runat="server" Text='<%# Eval("CapturedBy") %>'>
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
                    <td align="center" colspan="7">
                        <dx:ASPxButton ID="ASPxButton15" runat="server" style="height: 23px" Text="Approve Selected" Theme="Glass">
                        </dx:ASPxButton>
                        &nbsp;
                        <dx:ASPxButton ID="ASPxButton16" runat="server" style="height: 23px" Width="200px" Text="Decline Selected for Edit" Theme="Glass">
                        </dx:ASPxButton>
                    </td>
                </tr>
                <tr>
                    <td colspan="1">
                        <asp:Label ID="lblid" Visible="false" runat="server"></asp:Label>
                    </td>
                    <td colspan="1">&nbsp;</td>
                    <td colspan="1">&nbsp;</td>
                    <td colspan="1">&nbsp;</td>
                    <td colspan="1">&nbsp;</td>
                    <td colspan="1">&nbsp;</td>
                    <td colspan="1">&nbsp;</td>
                </tr>
                <tr>
                    <td align="left" colspan="7">
                        <dx:ASPxPopupControl ID="ASPxPopupControl1" runat="server" BackColor="#DDECFE" CloseAction="CloseButton" EnableCallbackAnimation="True" HeaderText="Trade Details" ShowCollapseButton="True" ShowPageScrollbarWhenModal="True" ShowPinButton="True" Theme="Glass" Width="900px">
                            <contentcollection>
                                <dx:PopupControlContentControl runat="server" SupportsDisabledAttribute="True">
                                    <dx:ASPxRoundPanel ID="ASPxRoundPanel6" runat="server" BackColor="White" ShowHeader="False" Width="100%">
                                        <panelcollection>
                                            <dx:PanelContent runat="server" SupportsDisabledAttribute="True">
                                                <table style="width: 100%">
                                                    <tr>
                                                        <td align="left" style="height: 26px">
                                                            <table style="width:100%">
                                                                  <tr>
                    <td colspan="1" style="width: 231px">
                        <dx:ASPxLabel ID="ASPxLabel9" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Name of Client" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td colspan="1">
                        <dx:ASPxTextBox ID="txtewrholder" runat="server" Height="19px" ReadOnly="True" Theme="BlackGlass" Width="250px">
                            <ValidationSettings>
                                <RequiredField IsRequired="True" />
                            </ValidationSettings>
                        </dx:ASPxTextBox>
                    </td>
                    <td colspan="1">
                        <dx:ASPxLabel ID="ASPxLabel10" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Account No" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td colspan="1">
                        <dx:ASPxTextBox ID="txtewraccountno" runat="server" Height="19px" ReadOnly="True" Theme="BlackGlass" Width="250px">
                       <ValidationSettings>
                                <RequiredField IsRequired="True" />
                            </ValidationSettings>
                             </dx:ASPxTextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="1" style="width: 231px">
                        <dx:ASPxLabel ID="ASPxLabel66" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Description" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td colspan="1">
                        <dx:ASPxTextBox ID="txtdescription" runat="server" Height="19px" ReadOnly="True" style="margin-bottom: 0px" Theme="BlackGlass" Width="250px">
                       
                             </dx:ASPxTextBox>
                    </td>
                    <td colspan="1">
                        <dx:ASPxLabel ID="ASPxLabel67" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Asset Manager" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td colspan="1">
                        <dx:ASPxComboBox ID="cmbassetmanager" runat="server" ReadOnly="True"  EnableCallbackMode="True" Theme="Glass" Width="250px">
                            <ValidationSettings>
                                <RequiredField IsRequired="True" />
                            </ValidationSettings>
                        </dx:ASPxComboBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="1" style="height: 26px; width: 231px;">
                        <dx:ASPxLabel ID="ASPxLabel27" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Interest Type" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td colspan="1" style="height: 26px">
                        <dx:ASPxComboBox ID="cmbinteresttype" runat="server"  ReadOnly="True" Width="250px" Theme="Glass">
                      
                            <Items>
                                <dx:ListEditItem Text="Fixed" Value="Fixed" />
                                 <dx:ListEditItem Text="On Call" Value="On Call" />
                            </Items>
                            <ValidationSettings>
                                <RequiredField IsRequired="True" />
                            </ValidationSettings>
                      
                        </dx:ASPxComboBox>
                    </td>
                    <td colspan="1" style="height: 26px">
                        <dx:ASPxLabel ID="ASPxLabel11" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Trade Amount " Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td colspan="1" style="height: 26px">
                        <dx:ASPxTextBox ID="txtamount" runat="server" Height="19px"  ReadOnly="True" DisplayFormatString="n" style="margin-bottom: 0px" Theme="BlackGlass" Width="250px">
                       <ValidationSettings>
                                <RequiredField IsRequired="True" />
                            </ValidationSettings>
                             </dx:ASPxTextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="1" style="height: 26px; width: 231px;">
                        <dx:ASPxLabel ID="ASPxLabel36" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Settlement Amount" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td colspan="1" style="height: 26px">
                        <dx:ASPxTextBox ID="txtsettlementamount" runat="server"  Height="19px" ReadOnly="True" DisplayFormatString="n" Theme="BlackGlass" Width="250px">
                       <ValidationSettings>
                                <RequiredField IsRequired="True" />
                            </ValidationSettings>
                             </dx:ASPxTextBox>
                    </td>
                    <td colspan="1" style="height: 26px">
                        <dx:ASPxLabel ID="ASPxLabel68" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Trade Currency" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td colspan="1" style="height: 26px">
                        <dx:ASPxComboBox ID="cmbcurrency" runat="server"  ReadOnly="True" EnableCallbackMode="True" Theme="Glass" Width="250px">
                      <ValidationSettings>
                                <RequiredField IsRequired="True" />
                            </ValidationSettings>
                              </dx:ASPxComboBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="1" style="height: 26px; width: 231px;">
                        <dx:ASPxLabel ID="ASPxLabel80" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Settlement Currency" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td colspan="1" style="height: 26px">
                        <dx:ASPxComboBox ID="cmbcurrencysett" runat="server"  ReadOnly="True" EnableCallbackMode="True" Theme="Glass" Width="250px">
                            <ValidationSettings>
                                <RequiredField IsRequired="True" />
                            </ValidationSettings>
                        </dx:ASPxComboBox>
                    </td>
                    <td colspan="1" style="height: 26px">
                        <dx:ASPxLabel ID="ASPxLabel2" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Trade Date" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td colspan="1" style="height: 26px">
                        <dx:ASPxDateEdit ID="dttradedate" runat="server"  ReadOnly="True" Width="250px">
                       <ValidationSettings>
                                <RequiredField IsRequired="True" />
                            </ValidationSettings>
                             </dx:ASPxDateEdit>
                    </td>
                </tr>
                <tr>
                    <td colspan="1" style="height: 26px; width: 231px;">
                        <dx:ASPxLabel ID="ASPxLabel3" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Settlement Date" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td colspan="1" style="height: 26px">
                        <dx:ASPxDateEdit ID="dtsettlementdate" runat="server"  ReadOnly="True" Width="250px">
                       <ValidationSettings>
                                <RequiredField IsRequired="True" />
                            </ValidationSettings>
                             </dx:ASPxDateEdit>
                    </td>
                    <td colspan="1" style="height: 26px">
                        <dx:ASPxLabel ID="ASPxLabel69" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Fixed Rate" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td colspan="1" style="height: 26px">
                        <dx:ASPxTextBox ID="txtfixedrate" runat="server"  ReadOnly="True" Height="19px" DisplayFormatString="n" style="margin-bottom: 0px" Theme="BlackGlass" Width="250px">
                       <ValidationSettings>
                                <RequiredField IsRequired="True" />
                            </ValidationSettings>
                             </dx:ASPxTextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="1" style="height: 26px; width: 231px;">
                        <dx:ASPxLabel ID="ASPxLabel79" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Number of Days" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td colspan="1" style="height: 26px">
                        <dx:ASPxTextBox ID="txtnumberofdays" runat="server"  ReadOnly="True" AutoPostBack="True" Height="19px" style="margin-bottom: 0px" Theme="BlackGlass" Width="250px">
                       
                             </dx:ASPxTextBox>
                    </td>
                    <td colspan="1" style="height: 26px">
                        <dx:ASPxLabel ID="ASPxLabel65" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Reference" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td colspan="1" style="height: 26px">
                        <dx:ASPxTextBox ID="txtereference" runat="server" Height="19px" ReadOnly="True" style="margin-bottom: 0px" Theme="BlackGlass" Width="250px">
                            <ValidationSettings>
                                <RequiredField IsRequired="True" />
                            </ValidationSettings>
                        </dx:ASPxTextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="1" style="height: 26px; width: 231px;">
                        <dx:ASPxLabel ID="ASPxLabel70" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Day Count Basis" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td colspan="1" style="height: 26px">
                        <dx:ASPxComboBox ID="cmbdaycount" runat="server"  ReadOnly="True" EnableCallbackMode="True" Theme="Glass" Width="250px">
                      <Items>
                                            <dx:ListEditItem Text="actual/360" Value="actual/360" />
                                            <dx:ListEditItem Text="actual/365" Value="actual/365" />
                                          
                                        </Items>
                            <ValidationSettings>
                                <RequiredField IsRequired="True" />
                            </ValidationSettings>
                              </dx:ASPxComboBox>
                    </td>
                    <td colspan="1" style="height: 26px">
                        <dx:ASPxLabel ID="ASPxLabel71" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Payment Frequency" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td colspan="1" style="height: 26px">
                        <dx:ASPxComboBox ID="cmbpaymentfrequency" runat="server"  ReadOnly="True" EnableCallbackMode="True" Theme="Glass" Width="250px">
                            <Items>
                                <dx:ListEditItem Text="Daily" Value="Daily" />
                                <dx:ListEditItem Text="Monthly" Value="Monthly" />
                                <dx:ListEditItem Text="On Maturity" Value="On Maturity" />
                            </Items>
                            <ValidationSettings>
                                <RequiredField IsRequired="True" />
                            </ValidationSettings>
                        </dx:ASPxComboBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="1" style="height: 26px; width: 231px;">
                        <dx:ASPxLabel ID="ASPxLabel72" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Maturity Date" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td colspan="1" style="height: 26px">
                        <dx:ASPxDateEdit ID="dtmaturitydate" runat="server"  ReadOnly="True" Width="250px">
                            <ValidationSettings>
                                <RequiredField IsRequired="True" />
                            </ValidationSettings>
                        </dx:ASPxDateEdit>
                    </td>
                    <td colspan="1" style="height: 26px">
                        <dx:ASPxLabel ID="ASPxLabel73" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Tax" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td colspan="1" style="height: 26px">
                        <dx:ASPxTextBox ID="txttax" runat="server" Height="19px"  ReadOnly="True" DisplayFormatString="n" style="margin-bottom: 0px" Theme="BlackGlass" Width="250px">
                      <ValidationSettings>
                                <RequiredField IsRequired="True" />
                            </ValidationSettings>
                              </dx:ASPxTextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="1" style="height: 26px; width: 231px;">
                        <dx:ASPxLabel ID="ASPxLabel62" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Trade Charges" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td colspan="1" style="height: 26px">
                        <dx:ASPxTextBox ID="txttranscharge" runat="server" Height="19px" DisplayFormatString="n"  ReadOnly="True" style="margin-bottom: 0px" Theme="BlackGlass" Width="250px">
                      <ValidationSettings>
                                <RequiredField IsRequired="True" />
                            </ValidationSettings>
                              </dx:ASPxTextBox>
                    </td>
                    <td colspan="1" style="height: 26px">
                        <dx:ASPxLabel ID="ASPxLabel74" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Type" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td colspan="1" style="height: 26px">
                        <dx:ASPxComboBox ID="cmbordertype" runat="server"  ReadOnly="True" EnableCallbackMode="True" Theme="Glass" Width="250px">
                            <Items>
                                <dx:ListEditItem Text="RVP" Value="RVP" />
                                <dx:ListEditItem Text="RF" Value="RF" />
                            </Items>
                            <ValidationSettings>
                                <RequiredField IsRequired="True" />
                            </ValidationSettings>
                        </dx:ASPxComboBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="1" style="height: 26px; width: 231px;">
                        <dx:ASPxLabel ID="ASPxLabel75" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Counter Part Bank" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td colspan="1" style="height: 26px">
                        <dx:ASPxComboBox ID="cmbbank" runat="server"  ReadOnly="True" EnableCallbackMode="True" Theme="Glass" Width="250px" AutoPostBack="True">
                           <ValidationSettings>
                                <RequiredField IsRequired="True" />
                            </ValidationSettings>
                        </dx:ASPxComboBox>
                    </td>
                    <td colspan="1" style="height: 26px">
                        <dx:ASPxLabel ID="ASPxLabel76" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Account Name" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td colspan="1" style="height: 26px">
                        <dx:ASPxTextBox ID="txtAccountName" runat="server"  ReadOnly="True" Height="19px" style="margin-bottom: 0px" Theme="BlackGlass" Width="250px">
                       <ValidationSettings>
                                <RequiredField IsRequired="True" />
                            </ValidationSettings>
                             </dx:ASPxTextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="1" style="height: 26px; width: 231px;">
                        <dx:ASPxLabel ID="ASPxLabel77" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Bank Account Number" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td colspan="1" style="height: 26px">
                        <dx:ASPxTextBox ID="txtaccountnumber" runat="server"  ReadOnly="True" Height="19px" style="margin-bottom: 0px" Theme="BlackGlass" Width="250px">
                       <ValidationSettings>
                                <RequiredField IsRequired="True" />
                            </ValidationSettings>
                             </dx:ASPxTextBox>
                    </td>
                    <td colspan="1" style="height: 26px">
                        <dx:ASPxLabel ID="ASPxLabel78" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Maturity Value" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td colspan="1" style="height: 26px">
                        <dx:ASPxTextBox ID="txtmaturityvalue" runat="server"  ReadOnly="True" DisplayFormatString="n" Height="19px" style="margin-bottom: 0px" Theme="BlackGlass" Width="250px">
                        </dx:ASPxTextBox>
                    </td>
                </tr>
                                                                  <tr>
                                                                      <td colspan="1" style="height: 26px; width: 231px;">
                                                                          <dx:ASPxLabel ID="lblsettlementcurr" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Settlement Currency" Theme="Glass">
                                                                          </dx:ASPxLabel>
                                                                      </td>
                                                                      <td colspan="1" style="height: 26px">
                                                                          <dx:ASPxTextBox ID="txtsettlementcurrency" runat="server" Height="19px" ReadOnly="True" style="margin-bottom: 0px" Theme="BlackGlass" Width="250px">
                                                                          </dx:ASPxTextBox>
                                                                      </td>
                                                                      <td colspan="1" style="height: 26px">
                                                                          <dx:ASPxLabel ID="ASPxLabel421" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Exchange Rate" Theme="Glass">
                                                                          </dx:ASPxLabel>
                                                                      </td>
                                                                      <td colspan="1" style="height: 26px">
                                                                          <dx:ASPxTextBox ID="txtexchangerate" DisplayFormatString="n" runat="server" Height="19px" ReadOnly="True" style="margin-bottom: 0px" Theme="BlackGlass" Width="250px">
                                                                          </dx:ASPxTextBox>
                                                                      </td>
                                                                  </tr>
                <tr>
                    <td colspan="1" style="height: 26px; width: 231px;">
                        &nbsp;</td>
                    <td colspan="3" style="height: 26px">
                        <dx:ASPxGridView ID="ASPxGridView1" runat="server" AutoGenerateColumns="False" KeyFieldName="id" Theme="Glass">
                            <Columns>
                                <dx:GridViewDataColumn ShowInCustomizationForm="True" VisibleIndex="0">
                                    <DataItemTemplate>
                                        <asp:LinkButton ID="ViewDoc1" runat="server" CommandArgument='<%# Eval("ID") %>' CommandName="View Document" Text="View Document">
                                                              </asp:LinkButton>
                                    </DataItemTemplate>
                                </dx:GridViewDataColumn>
                                <dx:GridViewDataColumn ShowInCustomizationForm="True" VisibleIndex="0">
                                    <DataItemTemplate>
                                        <asp:LinkButton ID="DeleteID0" runat="server" CommandArgument='<%# Eval("ID") %>' CommandName="Remove Document" OnClientClick="if ( !confirm('Are you sure you want to remove document? ')) return false;" Text="Remove Document">
                                                              </asp:LinkButton>
                                    </DataItemTemplate>
                                </dx:GridViewDataColumn>
                                <dx:GridViewDataColumn Caption="Document Type" ShowInCustomizationForm="True" VisibleIndex="1">
                                    <DataItemTemplate>
                                        <dx:ASPxLabel runat="server" Text='<%# Eval("DocumentName") %>'>
                                        </dx:ASPxLabel>
                                    </DataItemTemplate>
                                </dx:GridViewDataColumn>
                                <dx:GridViewDataColumn Caption="File Name" ShowInCustomizationForm="True" VisibleIndex="2">
                                    <DataItemTemplate>
                                        <dx:ASPxLabel runat="server" Text='<%# Eval("FileName") %>'>
                                        </dx:ASPxLabel>
                                    </DataItemTemplate>
                                </dx:GridViewDataColumn>
                                <dx:GridViewDataColumn Caption="File Extension" ShowInCustomizationForm="True" VisibleIndex="3">
                                    <DataItemTemplate>
                                        <dx:ASPxLabel runat="server" Text='<%# Eval("Extension") %>'>
                                        </dx:ASPxLabel>
                                    </DataItemTemplate>
                                </dx:GridViewDataColumn>
                            </Columns>
                            <SettingsBehavior AllowSelectByRowClick="True" AllowSelectSingleRowOnly="True" ProcessSelectionChangedOnServer="True" />
                            <SettingsPager>
                                <PageSizeItemSettings ShowAllItem="True">
                                </PageSizeItemSettings>
                            </SettingsPager>
                            <Settings ShowTitlePanel="True" />
                            <SettingsPopup>
                                <EditForm AllowResize="True" Modal="True" />
                            </SettingsPopup>
                            <SettingsCommandButton>
                                <SelectButton Text="Select">
                                </SelectButton>
                            </SettingsCommandButton>
                        </dx:ASPxGridView>
                    </td>
                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center" style="height: 26px">
                                                            <dx:ASPxButton ID="ASPxButton13" runat="server" style="height: 23px" Text="Approve" Theme="Glass">
                                                            </dx:ASPxButton>
                                                            &nbsp;<dx:ASPxButton ID="ASPxButton14" runat="server" style="height: 23px" Text="Decline for Edit" Theme="Glass">
                                                            </dx:ASPxButton>
                                                            &nbsp;&nbsp;</td>
                                                    </tr>
                                                </table>
                                            </dx:PanelContent>
                                        </panelcollection>
                                    </dx:ASPxRoundPanel>
                                </dx:PopupControlContentControl>
                            </contentcollection>
                        </dx:ASPxPopupControl>
                    </td>
                </tr>
            </table>
        </asp:Panel>
               
</asp:Panel>
  
</div>
</asp:Content>

