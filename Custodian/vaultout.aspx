<%@ Page Language="VB" MasterPageFile="~/CDSUser.master" AutoEventWireup="false" CodeFile="Vaultout.aspx.vb" Inherits="TransferSec_vaultout" title="Vault-Out" %>
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
<%@ Register assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxTabControl" tagprefix="dx1" %>
<asp:Content id="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
    <asp:Panel id="Panel1" runat="server" Width="100%" Font-Names="Arial" Font-Size="Medium" BackColor="White">
    
        <table width ="100%">
            <tr>
                   <td style ="text-align :left;" align="left">
                       <dx:ASPxLabel ID="ASPxLabel1" runat="server" Text="Vault Management&gt;&gt;Vault-Out" Font-Names="Cambria" Font-Size="Small" Theme="PlasticBlue"></dx:ASPxLabel>

                   </td>
            </tr>
        </table>

        
        <asp:Panel ID="Panel3" runat="server" Font-Names="Cambria" Font-Size="Medium" GroupingText="Search Client">
            <table width="100%">
                <tr>
                    <td colspan="1">
                        <dx:ASPxLabel ID="ASPxLabel4" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Search Client" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td colspan="1">
                        <dx:ASPxTextBox ID="txtclientnumber0" runat="server" Height="19px" Theme="BlackGlass" Width="250px">
                        </dx:ASPxTextBox>
                    </td>
                    <td colspan="1">
                        <dx:ASPxButton ID="ASPxButton4" CausesValidation="False" runat="server" Text="&gt;&gt;" Theme="BlackGlass">
                        </dx:ASPxButton>
                    </td>
                    <td colspan="1"></td>
                    <td colspan="1"></td>
                    <td colspan="1"></td>
                    <td colspan="1"></td>
                </tr>
                <tr>
                    <td colspan="1">&nbsp;</td>
                    <td colspan="2">
                        <asp:ListBox ID="ListBox1" runat="server" AutoPostBack="True" Width="447px"></asp:ListBox>
                    </td>
                    <td colspan="1">&nbsp;</td>
                    <td colspan="1">&nbsp;</td>
                    <td colspan="1">&nbsp;</td>
                    <td colspan="1">&nbsp;</td>
                </tr>
                <tr>
                    <td colspan="7">&nbsp;</td>
                </tr>
                <tr>
                    <td colspan="7">
                        <dx:ASPxLabel ID="ASPxLabel37" runat="server" Font-Names="Cambria" Font-Size="Medium" Text="Participant Details" Theme="Glass">
                        </dx:ASPxLabel>
                        <hr />
                    </td>
                </tr>
                <tr>
                    <td colspan="1">
                        <dx:ASPxLabel ID="ASPxLabel5" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Participant Name" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td colspan="1">
                        <dx:ASPxTextBox ID="txtparticipantname" runat="server" Height="19px" ReadOnly="True" Theme="BlackGlass" Width="250px">
                        </dx:ASPxTextBox>
                    </td>
                    <td colspan="1">
                        <dx:ASPxLabel ID="ASPxLabel7" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Participant Account No" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td colspan="1">
                        <dx:ASPxTextBox ID="txtAccountNo" runat="server" Height="19px" ReadOnly="True" Theme="BlackGlass" Width="250px">
                        </dx:ASPxTextBox>
                    </td>
                    <td colspan="1">&nbsp;</td>
                    <td colspan="1">&nbsp;</td>
                    <td colspan="1">&nbsp;</td>
                </tr>
                <tr>
                    <td colspan="7">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td colspan="7">
                        <dx:ASPxLabel ID="ASPxLabel38" runat="server" Font-Names="Cambria" Font-Size="Medium" Text="Details" Theme="Glass">
                        </dx:ASPxLabel>
                        <hr />
                    </td>
                </tr>
                <tr>
                    <td colspan="1">
                        &nbsp;</td>
                    <td colspan="6">
                        <asp:RadioButtonList ID="RadioButtonList1" runat="server" AutoPostBack="True" RepeatDirection="Horizontal">
                            <asp:ListItem>Certificate</asp:ListItem>
                            <asp:ListItem>Other Items</asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                </tr>
                <tr>
                    <td colspan="1">
                        <dx:ASPxLabel ID="lblissuedate0" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Select Product" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td colspan="6">
                        <dx:ASPxComboBox ID="cmbitem" runat="server" AutoPostBack="True" Theme="Glass" Width="250px">
                        </dx:ASPxComboBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="1">
                        <dx:ASPxLabel ID="ASPxLabel9" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Name of Client" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td colspan="1">
                        <dx:ASPxTextBox ID="txtewrholder" runat="server" Height="19px" ReadOnly="True" Theme="BlackGlass" Width="250px">
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
                    <td colspan="1" style="height: 26px">
                        <dx:ASPxLabel ID="lblproduct" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Company" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td colspan="1" style="height: 26px">
                        <dx:ASPxComboBox ID="cmbparaCompany" runat="server" AutoPostBack="True"  ReadOnly="True"
        Width="250px" Theme="Glass">
                        
                        </dx:ASPxComboBox>
                    </td>
                    <td colspan="1" style="height: 26px">
                        <dx:ASPxLabel ID="ASPxLabel11" runat="server" Font-Names="Cambria" Font-Size="Small" Text="No of Units" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td colspan="1" style="height: 26px">
                        <dx:ASPxTextBox ID="txtavailableshares" runat="server" DisplayFormatString="n" Height="19px" style="margin-bottom: 0px" Theme="BlackGlass" Width="250px" ReadOnly="True">
                        </dx:ASPxTextBox>
                    </td>
                    <td colspan="1" style="height: 26px"></td>
                    <td colspan="1" style="height: 26px"></td>
                    <td colspan="1" style="height: 26px"></td>
                </tr>
                <tr>
                    <td colspan="1" style="height: 26px">
                        <dx:ASPxLabel ID="lblunitprice" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Current Unit Price" Theme="Glass" >
                        </dx:ASPxLabel>
                    </td>
                    <td colspan="1" style="height: 26px">
                        <dx:ASPxTextBox ID="txtprice" runat="server" Height="19px" ReadOnly="True" Theme="BlackGlass" Width="250px" >
                        </dx:ASPxTextBox>
                    </td>
                    <td colspan="1" style="height: 26px">
                        <dx:ASPxLabel ID="lblcertificate" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Certificate No." Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td colspan="1" style="height: 26px">
                        <dx:ASPxTextBox ID="txtcertno" runat="server" Height="19px" ReadOnly="True" style="margin-bottom: 0px" Theme="BlackGlass" Width="250px">
                        </dx:ASPxTextBox>
                    </td>
                    <td colspan="1" style="height: 26px">&nbsp;</td>
                    <td colspan="1" style="height: 26px">&nbsp;</td>
                    <td colspan="1" style="height: 26px">&nbsp;</td>
                </tr>
                <tr>
                    <td colspan="1" style="height: 26px">
                        <dx:ASPxLabel ID="lblissuedate" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Issue Date" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td colspan="1" style="height: 26px">
                        <dx:ASPxDateEdit ID="dtissue" Width="250px" runat="server">
                                            </dx:ASPxDateEdit>
                    </td>
                    <td colspan="1" style="height: 26px">
                        <dx:ASPxLabel ID="lblmaturity"  runat="server" Font-Names="Cambria" Font-Size="Small" Text="Maturity Date (Optional)" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td colspan="1" style="height: 26px">
                        <dx:ASPxDateEdit ID="dtmaturity" ReadOnly="True" runat="server" Width="250px">
                        </dx:ASPxDateEdit>
                    </td>
                    <td colspan="1" style="height: 26px">&nbsp;</td>
                    <td colspan="1" style="height: 26px">&nbsp;</td>
                    <td colspan="1" style="height: 26px">&nbsp;</td>
                </tr>
                <tr>
                    <td colspan="1" style="height: 26px">
                        <dx:ASPxLabel ID="lblissuedate1" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Counterpart Bank" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td colspan="1" style="height: 26px">
                        <dx:ASPxComboBox ID="cmbcounterpart" runat="server" AutoPostBack="True" Theme="Glass"  Width="250px">
                        </dx:ASPxComboBox>
                    </td>
                    <td colspan="1" style="height: 26px">
                        <dx:ASPxLabel ID="lblissuedate2" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Counterpart Account" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td colspan="1" style="height: 26px">
                        <dx:ASPxTextBox ID="txtcounterpartbank" runat="server" Height="19px" ReadOnly="True" style="margin-bottom: 0px" Theme="BlackGlass" Width="250px">
                        </dx:ASPxTextBox>
                    </td>
                    <td colspan="1" style="height: 26px"></td>
                    <td colspan="1" style="height: 26px"></td>
                    <td colspan="1" style="height: 26px"></td>
                </tr>
                <tr>
                    <td colspan="1" style="height: 26px">
                        <dx:ASPxLabel ID="lblissuedate3" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Asset Manager" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td colspan="1" style="height: 26px">
                        <dx:ASPxComboBox ID="cmbassetmanager" runat="server" EnableCallbackMode="True" Theme="Glass" Width="250px">
                        </dx:ASPxComboBox>
                    </td>
                    <td colspan="1" style="height: 26px">&nbsp;</td>
                    <td colspan="1" style="height: 26px">&nbsp;</td>
                    <td colspan="1" style="height: 26px">&nbsp;</td>
                    <td colspan="1" style="height: 26px">&nbsp;</td>
                    <td colspan="1" style="height: 26px">&nbsp;</td>
                </tr>
                <tr>
                    <td colspan="1" style="height: 26px">
                        <dx:ASPxLabel ID="ASPxLabel64" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Document Name" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td colspan="1" style="height: 26px">
                        <dx:ASPxTextBox ID="txtdocumentname" runat="server" Height="19px" ReadOnly="True" style="margin-bottom: 0px" Theme="BlackGlass" Width="250px" Text="Certificate">
                        </dx:ASPxTextBox>
                    </td>
                    <td colspan="1" style="height: 26px">
                        <dx:ASPxLabel ID="ASPxLabel63" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Document" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td colspan="1" style="height: 26px">
                        <table class="dxflInternalEditorTable">
                            <tr>
                                <td style="width: 200px">
                                    <asp:FileUpload ID="FileUpload1" runat="server" Enabled="False" />
                                </td>
                                <td>
                                    <dx:ASPxButton ID="ASPxButton14" runat="server" style="height: 23px" Text="Upload Document" Theme="BlackGlass" Enabled="False">
                                    </dx:ASPxButton>
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td colspan="1" style="height: 26px">&nbsp;</td>
                    <td colspan="1" style="height: 26px">&nbsp;</td>
                    <td colspan="1" style="height: 26px">&nbsp;</td>
                </tr>
                <tr>
                    <td colspan="1" style="height: 26px">
                        <dx:ASPxLabel ID="ASPxLabel61" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Total Charges" Theme="Glass" Visible="False">
                        </dx:ASPxLabel>
                    </td>
                    <td colspan="1" style="height: 26px">
                        <dx:ASPxTextBox ID="txttotalcharges" runat="server" Height="19px" ReadOnly="True" style="margin-bottom: 0px" Theme="BlackGlass" Visible="False" Width="250px">
                        </dx:ASPxTextBox>
                    </td>
                    <td colspan="1" style="height: 26px">&nbsp;</td>
                    <td colspan="4" style="height: 26px">
                        <dx:ASPxGridView ID="grddocuments" runat="server" KeyFieldName="id" Settings-ShowTitlePanel="true" Theme="Glass">
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
                        <dx:ASPxButton ID="ASPxButton13" runat="server" Text="Save" Theme="BlackGlass" style="height: 23px">
                        </dx:ASPxButton>
                    </td>
                </tr>
            </table>
        </asp:Panel>
               
        <asp:Panel ID="Panel9" runat="server" Enabled="true" Font-Names="Cambria" Font-Size="Medium" GroupingText="Vault Outs">
            <table width="100%">
                <tr>
                    <td align="center">
                         <dx:ASPxGridView ID="ASPxGridView3" runat="server" KeyFieldName="id" Settings-ShowTitlePanel="true"  Theme="Glass" Width="100%">
                            <SettingsBehavior AllowSelectByRowClick="True" AllowSelectSingleRowOnly="True" ProcessSelectionChangedOnServer="True" />
                            <SettingsPager PageSizeItemSettings-ShowAllItem="true"   Visible="True">
                            </SettingsPager>
                           
                            
                            <SettingsPopup>
                                <EditForm AllowResize="True" Modal="True" />
                            </SettingsPopup>
                            <SettingsCommandButton>
                                <SelectButton Text="Select">
                                </SelectButton>
                            </SettingsCommandButton>
                            <Settings ShowFilterRow="true" />

                            <Columns>

                            
                               
                                    <dx:GridViewDataColumn VisibleIndex="0" Caption="">
                                                                                           <DataItemTemplate>
                                                              <asp:LinkButton ID="Edit" Text="Edit" CommandName="Edit"  CommandArgument='<%# Eval("ID") %>' runat="server">
                                                              </asp:LinkButton>
                                                         </DataItemTemplate>
                                                    </dx:GridViewDataColumn>
                               
                              <dx:GridViewDataTextColumn Caption="Account No" FieldName="Account No" Settings-AutoFilterCondition="Contains">    </dx:GridViewDataTextColumn>
                                     <dx:GridViewDataTextColumn Caption="Names" FieldName="Names" Settings-AutoFilterCondition="Contains">    </dx:GridViewDataTextColumn>

                                               <dx:GridViewDataTextColumn Caption="AssetManager" FieldName="AssetManager" Settings-AutoFilterCondition="Contains">    </dx:GridViewDataTextColumn>
                                                                   <dx:GridViewDataTextColumn Caption="Certificate No" FieldName="Certificate No" Settings-AutoFilterCondition="Contains">    </dx:GridViewDataTextColumn>


                                                           <dx:GridViewDataTextColumn Caption="Company" FieldName="Company" Settings-AutoFilterCondition="Contains">    </dx:GridViewDataTextColumn>

                                                                <dx:GridViewDataTextColumn Caption="Units" FieldName="quantity" Settings-AutoFilterCondition="Equals" >    </dx:GridViewDataTextColumn>

                                                             <dx:GridViewDataTextColumn Caption="Price" FieldName="Price" Settings-AutoFilterCondition="Equals" >    </dx:GridViewDataTextColumn>

                                                              <dx:GridViewDataTextColumn Caption="Value" FieldName="value" PropertiesTextEdit-DisplayFormatString="n" Settings-AutoFilterCondition="Contains">    </dx:GridViewDataTextColumn>

                                                               <dx:GridViewDataDateColumn  Caption="Capturedate" FieldName="CaptureDate" Settings-AutoFilterCondition="Contains"></dx:GridViewDataDateColumn>  

                                  
                           
                                
                                
                                <dx:GridViewDataTextColumn Caption="Status" FieldName="Status" Settings-AutoFilterCondition="Contains">    </dx:GridViewDataTextColumn>
                            </Columns>
                            <%-- W.EWR_Holder as [Account No], W.Company as [Details], W.ReceiptID AS [EWR No.], 
                                case when W.approvedby is NULL then 'Pending' else 'Approved' end as  [Status],  W.[Date],
                                 W.amount_to_withdraw ,wr.Commodity, wr.Grade, wr.WarehousePhysical, wr.Date_Issued, wr.[Status] --%>
                        </dx:ASPxGridView>
                        &nbsp;
                        <%--<dx:ASPxButton ID="ASPxButton14" runat="server" Text="Delete Batch Details" Theme="BlackGlass">
                        </dx:ASPxButton>--%>
                    </td>
                </tr>
                <tr>
                    <td align="center">
                        &nbsp;</td>
                </tr>
            </table>
        </asp:Panel>
               
        <asp:Panel ID="Panel10" runat="server" Enabled="true" Font-Names="Cambria" Font-Size="Medium" GroupingText="Rejected Vault-Outs">
            <table width="100%">
                <tr>
                    <td align="center">
                     <dx:ASPxGridView ID="ASPxGridView4" runat="server" KeyFieldName="id" Settings-ShowTitlePanel="true" Theme="Glass" Width="100%">
                            <SettingsBehavior AllowSelectByRowClick="True" AllowSelectSingleRowOnly="True" ProcessSelectionChangedOnServer="True" />
                            <SettingsPager PageSizeItemSettings-ShowAllItem="true"   Visible="True">
                            </SettingsPager>
                            <SettingsPopup>
                                <EditForm AllowResize="True" Modal="True" />
                            </SettingsPopup>
                            <SettingsCommandButton>
                                <SelectButton Text="Select">
                                </SelectButton>
                            </SettingsCommandButton>
                            <Settings ShowFilterRow="true" />
                            <Columns>
                                <dx:GridViewDataColumn Caption="" VisibleIndex="0">
                                    <DataItemTemplate>
                                        <asp:LinkButton ID="edit" runat="server" CommandArgument='<%# Eval("ID") %>' CommandName="Edit"  Text="Edit & Re-Submit">
                                                              </asp:LinkButton>
                                    </DataItemTemplate>
                                </dx:GridViewDataColumn>

                                  <dx:GridViewDataColumn Caption="" VisibleIndex="0">
                                    <DataItemTemplate>
                                        <asp:LinkButton ID="deletetrans" runat="server" CommandArgument='<%# Eval("ID") %>' CommandName="delete" OnClientClick="if ( !confirm('Are you sure you want to cancel this transaction? ')) return false;" Text="Cancel Transaction">
                                                              </asp:LinkButton>
                                    </DataItemTemplate>
                                </dx:GridViewDataColumn>


                                           <dx:GridViewDataTextColumn Caption="Account No" FieldName="Account No" Settings-AutoFilterCondition="Contains">    </dx:GridViewDataTextColumn>

                                      <dx:GridViewDataTextColumn Caption="Names" FieldName="Names" Settings-AutoFilterCondition="Contains">    </dx:GridViewDataTextColumn>
                                                                         <dx:GridViewDataTextColumn Caption="AssetManager" FieldName="AssetManager" Settings-AutoFilterCondition="Contains">    </dx:GridViewDataTextColumn>
                                                                   <dx:GridViewDataTextColumn Caption="Certificate No" FieldName="Certificate No" Settings-AutoFilterCondition="Contains">    </dx:GridViewDataTextColumn>

                                                               <dx:GridViewDataTextColumn Caption="Status" FieldName="Status" Settings-AutoFilterCondition="Contains">    </dx:GridViewDataTextColumn>

                                                           <dx:GridViewDataTextColumn Caption="Company" FieldName="Company" Settings-AutoFilterCondition="Contains">    </dx:GridViewDataTextColumn>

                                                                <dx:GridViewDataTextColumn Caption="Units" FieldName="quantity" Settings-AutoFilterCondition="Equals" >    </dx:GridViewDataTextColumn>

                                                             <dx:GridViewDataTextColumn Caption="Price" FieldName="Price" Settings-AutoFilterCondition="Equals" >    </dx:GridViewDataTextColumn>

                                                              <dx:GridViewDataTextColumn Caption="Value" FieldName="value" PropertiesTextEdit-DisplayFormatString="n" Settings-AutoFilterCondition="Contains">    </dx:GridViewDataTextColumn>

                                                               <dx:GridViewDataDateColumn  Caption="Capturedate" FieldName="CaptureDate" Settings-AutoFilterCondition="Contains"></dx:GridViewDataDateColumn>  

                                  
                           
                                <dx:GridViewDataColumn Caption="Rejection Reason">
                                    <DataItemTemplate>
                                        <dx:ASPxLabel runat="server" Text='<%# Eval("RejectionReason") %>'>
                                        </dx:ASPxLabel>
                                    </DataItemTemplate>
                                </dx:GridViewDataColumn>
                                
                            </Columns>
                            <%-- W.EWR_Holder as [Account No], W.Company as [Details], W.ReceiptID AS [EWR No.], 
                                case when W.approvedby is NULL then 'Pending' else 'Approved' end as  [Status],  W.[Date],
                                 W.amount_to_withdraw ,wr.Commodity, wr.Grade, wr.WarehousePhysical, wr.Date_Issued, wr.[Status] --%>
                        </dx:ASPxGridView>
                        &nbsp; <%--<dx:ASPxButton ID="ASPxButton14" runat="server" Text="Delete Batch Details" Theme="BlackGlass">
                        </dx:ASPxButton>--%></td>
                </tr>
                <tr>
                    <td align="center"><dx:ASPxPopupControl ID="ASPxPopupControl1" runat="server" BackColor="#DDECFE" CloseAction="CloseButton" EnableCallbackAnimation="True" HeaderText="Enter OTP to Submit" ShowCollapseButton="True" ShowPageScrollbarWhenModal="True" ShowPinButton="True"   Width="400px" Theme="Office2010Blue">
        <contentcollection>
<dx:PopupControlContentControl runat="server" SupportsDisabledAttribute="True">
    <dx:ASPxRoundPanel ID="ASPxRoundPanel6" BackColor="White" runat="server" ShowHeader="False"  Width="100%">
        <panelcollection>
            <dx:PanelContent runat="server" SupportsDisabledAttribute="True">
                <table  style="width: 100%">
                    <tr>
                        <td align="right" style="height: 57px">
                            <dx:ASPxLabel ID="ASPxLabel60" runat="server" Text="OTP" Theme="iOS">
                            </dx:ASPxLabel>
                        </td>
                        <td align="left" style="height: 57px">
                            <dx:ASPxTextBox ID="txtotp" runat="server"  Theme="iOS" >
                            <MaskSettings ErrorText="Invalid OTP" Mask="0000" />
                            </dx:ASPxTextBox>
                             <asp:Label ID="lbltransid" runat="server" Visible="False"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" >&nbsp;</td>
                        <td align="left">
                            <dx:ASPxButton ID="btnSaveContract1" runat="server" CausesValidation="False" Text="Submit" Theme="Glass">
                            </dx:ASPxButton>
                        </td>
                    </tr>
                  
                  
                </table>
            </dx:PanelContent>
        </panelcollection>
    </dx:ASPxRoundPanel>
            </dx:PopupControlContentControl>
</contentcollection>
    </dx:ASPxPopupControl></td>
                </tr>
            </table>
        </asp:Panel>
               
</asp:Panel>
  
</div>
</asp:Content>

