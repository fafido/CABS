<%@ Page Language="VB" MasterPageFile="~/CDSUser.master" AutoEventWireup="false" CodeFile="ApproveBondTrade.aspx.vb" Inherits="TransferSec_ApproveBondTrade" title="Trade Bond Approval" %>
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
                       <dx:ASPxLabel ID="ASPxLabel1" runat="server" Text="Trading&gt;&gt;Trade Approval" Font-Names="Cambria" Font-Size="Small" Theme="PlasticBlue"></dx:ASPxLabel>

                   </td>
            </tr>
        </table>

        
        <asp:Panel ID="Panel3" runat="server" Font-Names="Cambria" Font-Size="Medium" GroupingText="Trade Approval">
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
                                 <dx:GridViewDataColumn Caption="Select" FieldName="Selec"  VisibleIndex="0">
                                    <DataItemTemplate>
                                        <dx:aspxcheckbox ID="chk1" runat="server" >
                                                              </dx:aspxcheckbox>
                                    </DataItemTemplate>
                                </dx:GridViewDataColumn>
                                <dx:GridViewDataColumn Caption="" VisibleIndex="0">
                                    <DataItemTemplate>
                                        <asp:LinkButton ID="ViewDoc1" runat="server" CommandArgument='<%# Eval("ID") %>' CommandName="View Document" Text="View More Details">
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
                                <dx:GridViewDataColumn Caption="Client">
                                    <DataItemTemplate>
                                        <dx:ASPxLabel runat="server" Text='<%# Eval("ClientNo") %>'>
                                        </dx:ASPxLabel>
                                    </DataItemTemplate>
                                </dx:GridViewDataColumn>
                                 <dx:GridViewDataColumn Caption="Client Name">
                                        <DataItemTemplate>
                                            <dx:ASPxLabel runat="server" Text='<%# Eval("ClientName") %>'>
                                            </dx:ASPxLabel>
                                        </DataItemTemplate>
                                    </dx:GridViewDataColumn>
                                   <dx:GridViewDataColumn Caption="Trade Type">
                                    <DataItemTemplate>
                                        <dx:ASPxLabel runat="server" Text='<%# Eval("TradeType") %>'>
                                        </dx:ASPxLabel>
                                    </DataItemTemplate>
                                </dx:GridViewDataColumn>
                                <dx:GridViewDataColumn Caption="Series">
                                    <DataItemTemplate>
                                        <dx:ASPxLabel runat="server" Text='<%# Eval("Company") %>'>
                                        </dx:ASPxLabel>
                                    </DataItemTemplate>
                                </dx:GridViewDataColumn>
                                <dx:GridViewDataColumn Caption="Amount">
                                    <DataItemTemplate>
                                        <dx:ASPxLabel runat="server" Text='<%# Eval("Units") %>'>
                                        </dx:ASPxLabel>
                                    </DataItemTemplate>
                                </dx:GridViewDataColumn>
                             
                                <dx:GridViewDataColumn Caption="Charges">
                                    <DataItemTemplate>
                                        <dx:ASPxLabel runat="server" Text='<%# Eval("TradeCharge") %>'>
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
                    <td align="center" colspan="7">      <dx:ASPxButton ID="ASPxButton1" runat="server" style="height: 23px" Text="Approve Selected" Theme="Glass">
                        </dx:ASPxButton>
                        &nbsp;
                        <dx:ASPxButton ID="ASPxButton2" runat="server" style="height: 23px" Width="200px" Text="Decline Selected for Edit" Theme="Glass">
                        </dx:ASPxButton>&nbsp;<dx:ASPxButton ID="ASPxButton17" runat="server" Width="170px" style="height: 23px" Text="Reject Selected CDS" Theme="Glass" Visible="False">
                        </dx:ASPxButton>
                    </td>
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
                    <td colspan="7">
                        <asp:Panel ID="Panel4" runat="server" GroupingText="Authorized Bond Trades">
                      
                        <dx:ASPxGridView ID="grdauthorized" runat="server" KeyFieldName="id" Theme="Glass" Width="100%">
                            
                       
                                           <Columns>
                                <dx:GridViewDataColumn Caption="" VisibleIndex="0">
                                    <DataItemTemplate>
                                        <asp:LinkButton ID="ViewDoc2" runat="server" CommandArgument='<%# Eval("ID") %>' CommandName="View Document" Text="View More Details">
                                                              </asp:LinkButton>
                                    </DataItemTemplate>
                                </dx:GridViewDataColumn>
                                <dx:GridViewDataColumn Caption="Client">
                                    <DataItemTemplate>
                                        <dx:ASPxLabel runat="server" Text='<%# Eval("ClientNo") %>'>
                                        </dx:ASPxLabel>
                                    </DataItemTemplate>
                                </dx:GridViewDataColumn>
                                   <dx:GridViewDataColumn Caption="Client Name">
                                    <DataItemTemplate>
                                        <dx:ASPxLabel runat="server" Text='<%# Eval("ClientName") %>'>
                                        </dx:ASPxLabel>
                                    </DataItemTemplate>
                                </dx:GridViewDataColumn>
                                <dx:GridViewDataColumn Caption="Trade Type">
                                    <DataItemTemplate>
                                        <dx:ASPxLabel runat="server" Text='<%# Eval("TradeType") %>'>
                                        </dx:ASPxLabel>
                                    </DataItemTemplate>
                                </dx:GridViewDataColumn>
                                <dx:GridViewDataColumn Caption="Series">
                                    <DataItemTemplate>
                                        <dx:ASPxLabel runat="server" Text='<%# Eval("Company") %>'>
                                        </dx:ASPxLabel>
                                    </DataItemTemplate>
                                </dx:GridViewDataColumn>
                                <dx:GridViewDataColumn Caption="Amount">
                                    <DataItemTemplate>
                                        <dx:ASPxLabel runat="server" Text='<%# Eval("Units") %>'>
                                        </dx:ASPxLabel>
                                    </DataItemTemplate>
                                </dx:GridViewDataColumn>
                              
                                <dx:GridViewDataColumn Caption="Charges">
                                    <DataItemTemplate>
                                        <dx:ASPxLabel runat="server" Text='<%# Eval("TradeCharge") %>'>
                                        </dx:ASPxLabel>
                                    </DataItemTemplate>
                                </dx:GridViewDataColumn>
                                <dx:GridViewDataColumn Caption="Settlement Amt">
                                    <DataItemTemplate>
                                        <dx:ASPxLabel runat="server" Text='<%# Eval("SettlementAmount") %>'>
                                        </dx:ASPxLabel>
                                    </DataItemTemplate>
                                </dx:GridViewDataColumn>
                                <dx:GridViewDataColumn Caption="Asset Manager">
                                    <DataItemTemplate>
                                        <dx:ASPxLabel runat="server" Text='<%# Eval("AssetManager") %>'>
                                        </dx:ASPxLabel>
                                    </DataItemTemplate>
                                </dx:GridViewDataColumn>
                                <dx:GridViewDataColumn Caption="Broker">
                                    <DataItemTemplate>
                                        <dx:ASPxLabel runat="server" Text='<%# Eval("Broker") %>'>
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
                              </asp:Panel>
                    </td>
                </tr>
                <tr>
                    <td colspan="7">
                        <br />
                        <asp:Panel ID="Panel5" runat="server" GroupingText="Rejected Bond Trades">
                            <dx:ASPxGridView ID="grdrejected" runat="server" KeyFieldName="id" Settings-ShowTitlePanel="true" Theme="Glass" Width="100%">
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
                                            <asp:LinkButton ID="ViewDoc3" runat="server" CommandArgument='<%# Eval("ID") %>' CommandName="View Document" Text="View More Details">
                                                              </asp:LinkButton>
                                        </DataItemTemplate>
                                    </dx:GridViewDataColumn>
                                    <dx:GridViewDataColumn Caption="Client">
                                        <DataItemTemplate>
                                            <dx:ASPxLabel runat="server" Text='<%# Eval("ClientNo") %>'>
                                            </dx:ASPxLabel>
                                        </DataItemTemplate>
                                    </dx:GridViewDataColumn>
                                    <dx:GridViewDataColumn Caption="Client Name">
                                        <DataItemTemplate>
                                            <dx:ASPxLabel runat="server" Text='<%# Eval("ClientName") %>'>
                                            </dx:ASPxLabel>
                                        </DataItemTemplate>
                                    </dx:GridViewDataColumn>
                                    <dx:GridViewDataColumn Caption="Trade Type">
                                        <DataItemTemplate>
                                            <dx:ASPxLabel runat="server" Text='<%# Eval("TradeType") %>'>
                                            </dx:ASPxLabel>
                                        </DataItemTemplate>
                                    </dx:GridViewDataColumn>
                                    <dx:GridViewDataColumn Caption="Series">
                                        <DataItemTemplate>
                                            <dx:ASPxLabel runat="server" Text='<%# Eval("Company") %>'>
                                            </dx:ASPxLabel>
                                        </DataItemTemplate>
                                    </dx:GridViewDataColumn>
                                    <dx:GridViewDataColumn Caption="Amount">
                                        <DataItemTemplate>
                                            <dx:ASPxLabel runat="server" Text='<%# Eval("Units") %>'>
                                            </dx:ASPxLabel>
                                        </DataItemTemplate>
                                    </dx:GridViewDataColumn>
                                  
                                    <dx:GridViewDataColumn Caption="Charges">
                                        <DataItemTemplate>
                                            <dx:ASPxLabel runat="server" Text='<%# Eval("TradeCharge") %>'>
                                            </dx:ASPxLabel>
                                        </DataItemTemplate>
                                    </dx:GridViewDataColumn>
                                    <dx:GridViewDataColumn Caption="Settlement Amt">
                                        <DataItemTemplate>
                                            <dx:ASPxLabel runat="server" Text='<%# Eval("SettlementAmount") %>'>
                                            </dx:ASPxLabel>
                                        </DataItemTemplate>
                                    </dx:GridViewDataColumn>
                                    <dx:GridViewDataColumn Caption="Asset Manager">
                                        <DataItemTemplate>
                                            <dx:ASPxLabel runat="server" Text='<%# Eval("AssetManager") %>'>
                                            </dx:ASPxLabel>
                                        </DataItemTemplate>
                                    </dx:GridViewDataColumn>
                                    <dx:GridViewDataColumn Caption="Broker">
                                        <DataItemTemplate>
                                            <dx:ASPxLabel runat="server" Text='<%# Eval("Broker") %>'>
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
                        </asp:Panel>
                    </td>
                </tr>
                <tr>
                    <td colspan="1">&nbsp;</td>
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
                    <td colspan="1">
                        <dx:ASPxLabel ID="ASPxLabel9" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Name of Client" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td colspan="1">
                        <dx:ASPxTextBox ID="txtewrholder"  runat="server" Height="19px" ReadOnly="True" Theme="BlackGlass" Width="250px">
                        </dx:ASPxTextBox>
                    </td>
                    <td colspan="1">
                        <dx:ASPxLabel ID="ASPxLabel10" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Account No" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td colspan="1">
                        <dx:ASPxTextBox ID="txtewraccountno" runat="server" Height="19px" ReadOnly="True" Theme="BlackGlass" Width="250px">
                        </dx:ASPxTextBox>
                    </td>
                    <td colspan="1">&nbsp;</td>
                    <td colspan="1">&nbsp;</td>
                    <td colspan="1">&nbsp;</td>
                </tr>
                <tr>
                    <td colspan="1">
                        <dx:ASPxLabel ID="ASPxLabel66" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Order Type" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td colspan="1">
                        <dx:ASPxComboBox ID="cmbordertype" ReadOnly="true" runat="server"  EnableCallbackMode="True" Theme="Glass"  Width="250px">
                         
                            <Items>
                                <dx:ListEditItem Text="RVP" Value="RVP" />
                                <dx:ListEditItem Text="DVP" Value="DVP" />
                                <dx:ListEditItem Text="RF" Value="RF" />
                                <dx:ListEditItem Text="DF" Value="DF" />
                            </Items>
                         
                        </dx:ASPxComboBox>
                    </td>
                    <td colspan="1">
                        <dx:ASPxLabel ID="ASPxLabel67" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Asset Manager" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td colspan="1">
                        <dx:ASPxComboBox ID="cmbassetmanager" ReadOnly="true" runat="server" EnableCallbackMode="True" Theme="Glass" Width="250px">
                            
                        </dx:ASPxComboBox>
                    </td>
                    <td colspan="1">&nbsp;</td>
                    <td colspan="1">&nbsp;</td>
                    <td colspan="1">&nbsp;</td>
                </tr>
                <tr>
                    <td colspan="1" style="height: 26px">
                        <dx:ASPxLabel ID="ASPxLabel27" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Series" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td colspan="1" style="height: 26px">
                        <dx:ASPxComboBox ID="cmbparaCompany" runat="server" DropDownWidth="550" ReadOnly="true"  Width="250px" Theme="Glass">
                      
                        </dx:ASPxComboBox>
                    </td>
                    <td colspan="1" style="height: 26px">
                        <dx:ASPxLabel ID="ASPxLabel11" runat="server" Font-Names="Cambria" Font-Size="Small" Text="No of Units" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td colspan="1" style="height: 26px">
                        <dx:ASPxTextBox ID="txtavailableshares" ReadOnly="true" runat="server" Height="19px" style="margin-bottom: 0px" Theme="BlackGlass" Width="250px">
                        </dx:ASPxTextBox>
                    </td>
                    <td colspan="1" style="height: 26px"></td>
                    <td colspan="1" style="height: 26px"></td>
                    <td colspan="1" style="height: 26px"></td>
                </tr>
                <tr>
                    <td colspan="1" style="height: 26px">
                        <dx:ASPxLabel ID="ASPxLabel36" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Price" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td colspan="1" style="height: 26px">
                        <dx:ASPxTextBox ID="txtprice" runat="server" Height="19px" ReadOnly="True" Theme="BlackGlass" Width="250px">
                        </dx:ASPxTextBox>
                    </td>
                    <td colspan="1" style="height: 26px">
                        <dx:ASPxLabel ID="ASPxLabel68" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Currency" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td colspan="1" style="height: 26px">
                        <dx:ASPxComboBox ID="cmbcurrency" ReadOnly="true" runat="server" EnableCallbackMode="True" Theme="Glass" Width="250px">
                        </dx:ASPxComboBox>
                    </td>
                    <td colspan="1" style="height: 26px">&nbsp;</td>
                    <td colspan="1" style="height: 26px">&nbsp;</td>
                    <td colspan="1" style="height: 26px">&nbsp;</td>
                </tr>
                <tr>
                    <td colspan="1" style="height: 26px">
                        <dx:ASPxLabel ID="ASPxLabel2" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Trade Date" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td colspan="1" style="height: 26px">
                        <dx:ASPxDateEdit ID="dtfrom" Width="250px" ReadOnly="true" runat="server" AutoPostBack="True">
                                            </dx:ASPxDateEdit>
                    </td>
                    <td colspan="1" style="height: 26px">
                        <dx:ASPxLabel ID="ASPxLabel65" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Trade Reference" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td colspan="1" style="height: 26px">
                        <dx:ASPxTextBox ID="txtereference"  runat="server" Height="19px" ReadOnly="True" style="margin-bottom: 0px" Theme="BlackGlass" Width="250px">
                        </dx:ASPxTextBox>
                    </td>
                    <td colspan="1" style="height: 26px">&nbsp;</td>
                    <td colspan="1" style="height: 26px">&nbsp;</td>
                    <td colspan="1" style="height: 26px">&nbsp;</td>
                </tr>
                <tr>
                    <td colspan="1" style="height: 26px">
                        <dx:ASPxLabel ID="ASPxLabel3" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Settlement Date" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td colspan="1" style="height: 26px">
                        <dx:ASPxDateEdit ID="dtsettlementdate" ReadOnly="true" runat="server" Width="250px">
                        </dx:ASPxDateEdit>
                    </td>
                    <td colspan="1" style="height: 26px">
                        <dx:ASPxLabel ID="ASPxLabel62" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Trade Charges" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td colspan="1" style="height: 26px">
                        <dx:ASPxTextBox ID="txttranscharge" ReadOnly="true" runat="server" Height="19px" style="margin-bottom: 0px" Theme="BlackGlass" Width="250px">
                        </dx:ASPxTextBox>
                    </td>
                    <td colspan="1" style="height: 26px">&nbsp;</td>
                    <td colspan="1" style="height: 26px">&nbsp;</td>
                    <td colspan="1" style="height: 26px">&nbsp;</td>
                </tr>
                                                     <tr>
                                                         <td colspan="1" style="height: 26px">
                                                             <dx:ASPxLabel ID="ASPxLabel69" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Settlement Amount" Theme="Glass">
                                                             </dx:ASPxLabel>
                                                         </td>
                                                         <td colspan="1" style="height: 26px">
                                                             <dx:ASPxTextBox ID="txtsettlementamount" runat="server" Height="19px" ReadOnly="True" style="margin-bottom: 0px" Theme="BlackGlass" Width="250px">
                                                             </dx:ASPxTextBox>
                                                         </td>
                                                         <td colspan="1" style="height: 26px">
                                                             <dx:ASPxLabel ID="Status" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Status" Theme="Glass">
                                                             </dx:ASPxLabel>
                                                         </td>
                                                         <td colspan="1" style="height: 26px">
                                                             <dx:ASPxTextBox ID="txtstatus" runat="server" Height="19px" ReadOnly="True" style="margin-bottom: 0px" Theme="BlackGlass" Width="250px">
                                                             </dx:ASPxTextBox>
                                                         </td>
                                                         <td colspan="1" style="height: 26px">&nbsp;</td>
                                                         <td colspan="1" style="height: 26px">&nbsp;</td>
                                                         <td colspan="1" style="height: 26px">&nbsp;</td>
                                                     </tr>
                                                     <tr>
                                                         <td colspan="1" style="height: 26px">
                                                             <dx:ASPxLabel ID="ASPxLabel70" runat="server" Font-Names="Cambria" Font-Size="Small" Text="CDC Account" Theme="Glass">
                                                             </dx:ASPxLabel>
                                                         </td>
                                                         <td colspan="1" style="height: 26px">
                                                             <dx:ASPxTextBox ID="txtcdcaccount" runat="server" Height="19px" ReadOnly="True" style="margin-bottom: 0px" Theme="BlackGlass" Width="250px">
                                                             </dx:ASPxTextBox>
                                                         </td>
                                                         <td colspan="1" style="height: 26px">
                                                             <dx:ASPxLabel ID="ASPxLabel71" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Captured By" Theme="Glass">
                                                             </dx:ASPxLabel>
                                                         </td>
                                                         <td colspan="1" style="height: 26px">
                                                             <dx:ASPxTextBox ID="txtcapturedby" runat="server" Height="19px" ReadOnly="True" style="margin-bottom: 0px" Theme="BlackGlass" Width="250px">
                                                             </dx:ASPxTextBox>
                                                         </td>
                                                         <td colspan="1" style="height: 26px"></td>
                                                         <td colspan="1" style="height: 26px"></td>
                                                         <td colspan="1" style="height: 26px"></td>
                                                     </tr>
                                                     <tr>
                                                         <td colspan="1" style="height: 26px">
                                                             <dx:ASPxLabel ID="ASPxLabel72" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Date Captured" Theme="Glass">
                                                             </dx:ASPxLabel>
                                                         </td>
                                                         <td colspan="1" style="height: 26px">
                                                             <dx:ASPxDateEdit ID="dtcaptured" runat="server" ReadOnly="True" Width="250px">
                                                             </dx:ASPxDateEdit>
                                                         </td>
                                                         <td colspan="1" style="height: 26px">&nbsp;</td>
                                                         <td colspan="1" style="height: 26px">&nbsp;</td>
                                                         <td colspan="1" style="height: 26px">&nbsp;</td>
                                                         <td colspan="1" style="height: 26px">&nbsp;</td>
                                                         <td colspan="1" style="height: 26px">&nbsp;</td>
                                                     </tr>
                                                     <tr>
                                                         <td colspan="1" style="height: 26px">&nbsp;</td>
                                                         <td colspan="1" style="height: 26px">
                                                             <asp:Label ID="lblidshow" runat="server" Visible="False"></asp:Label>
                                                         </td>
                                                         <td colspan="1" style="height: 26px">&nbsp;</td>
                                                         <td colspan="1" style="height: 26px">&nbsp;</td>
                                                         <td colspan="1" style="height: 26px">&nbsp;</td>
                                                         <td colspan="1" style="height: 26px">&nbsp;</td>
                                                         <td colspan="1" style="height: 26px">&nbsp;</td>
                                                     </tr>
                                                     <tr>
                                                         <td colspan="7" align="center" style="height: 26px">
                                                             <dx:ASPxButton ID="ASPxButton13" runat="server" style="height: 23px" Text="Approve" Theme="Glass">
                                                             </dx:ASPxButton>
                                                             &nbsp;<dx:ASPxButton ID="ASPxButton14" runat="server" style="height: 23px" Text="Decline for Edit" Theme="Glass">
                                                             </dx:ASPxButton>
                                                             &nbsp;<dx:ASPxButton ID="ASPxButton16" runat="server" style="height: 23px" Text="Reject CDS" Theme="Glass">
                                                             </dx:ASPxButton>
&nbsp;<dx:ASPxButton ID="ASPxButton15" runat="server" style="height: 23px" Text="View Document" Theme="Glass">
                                                             </dx:ASPxButton>
                                                         </td>
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

