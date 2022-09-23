<%@ Page Language="VB" MasterPageFile="~/CDSUser.master" AutoEventWireup="false" CodeFile="fixedincome.aspx.vb" Inherits="TransferSec_fixedincome" title="Fixed Income-Trades" %>
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
                       <dx:ASPxLabel ID="ASPxLabel1" runat="server" Text="Fixed Income Trades Settlement (Bond)&gt;&gt;Trade Creation" Font-Names="Cambria" Font-Size="Small" Theme="PlasticBlue"></dx:ASPxLabel>

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
                    <td colspan="1" style="height: 27px">
                        <dx:ASPxLabel ID="ASPxLabel5" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Participant Name" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td colspan="1" style="height: 27px">
                        <dx:ASPxTextBox ID="txtparticipantname" runat="server" Height="19px" ReadOnly="True" Theme="BlackGlass" Width="250px">
                        </dx:ASPxTextBox>
                    </td>
                    <td colspan="1" style="height: 27px">
                        <dx:ASPxLabel ID="ASPxLabel7" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Participant Account No" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td colspan="1" style="height: 27px">
                        <dx:ASPxTextBox ID="txtAccountNo" runat="server" Height="19px" ReadOnly="True" Theme="BlackGlass" Width="250px">
                        </dx:ASPxTextBox>
                    </td>
                    <td colspan="1" style="height: 27px"></td>
                    <td colspan="1" style="height: 27px"></td>
                    <td colspan="1" style="height: 27px"></td>
                </tr>
                <tr>
                    <td colspan="7">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td colspan="7">
                        <dx:ASPxLabel ID="ASPxLabel38" runat="server" Font-Names="Cambria" Font-Size="Medium" Text="Account Details" Theme="Glass">
                        </dx:ASPxLabel>
                        <hr />
                    </td>
                </tr>
                <tr>
                    <td colspan="1" style="height: 27px">
                        <dx:ASPxLabel ID="ASPxLabel9" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Name of Client" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td colspan="1" style="height: 27px">
                        <dx:ASPxTextBox ID="txtewrholder" runat="server" Height="19px" ReadOnly="True" Theme="BlackGlass" Width="250px">
                        <ValidationSettings SetFocusOnError="true">
                            <RequiredField IsRequired="True" />
                        </ValidationSettings>
                              </dx:ASPxTextBox>
                    </td>
                    <td colspan="1" style="height: 27px">
                        <dx:ASPxLabel ID="ASPxLabel10" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Account No" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td colspan="1" style="height: 27px">
                        <dx:ASPxTextBox ID="txtewraccountno" runat="server" Height="19px" ReadOnly="True" Theme="BlackGlass" Width="250px">
                        <ValidationSettings SetFocusOnError="true">
                            <RequiredField IsRequired="True" />
                        </ValidationSettings>
                              </dx:ASPxTextBox>
                    </td>
                    <td colspan="1" style="height: 27px"></td>
                    <td colspan="1" style="height: 27px"></td>
                    <td colspan="1" style="height: 27px"></td>
                </tr>
                <tr>
                    <td colspan="1">
                        <dx:ASPxLabel ID="ASPxLabel66" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Order Type" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td colspan="1">
                        <dx:ASPxComboBox ID="cmbordertype" runat="server"  EnableCallbackMode="True" Theme="Glass"  Width="250px" AutoPostBack="True">
                           <ValidationSettings SetFocusOnError="true">
                            <RequiredField IsRequired="True" />
                        </ValidationSettings>
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
                        <dx:ASPxComboBox ID="cmbassetmanager" runat="server" EnableCallbackMode="True" Theme="Glass" Width="250px">
                             <ValidationSettings>
                                <RequiredField IsRequired="True" />
                            </ValidationSettings>
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
                        <dx:ASPxComboBox ID="cmbparaCompany" runat="server" IncrementalFilteringMode="StartsWith"  Width="250px" Theme="Glass" DropDownStyle="DropDown" AutoPostBack="True">
                       <ValidationSettings>
                                <RequiredField IsRequired="True" />
                            </ValidationSettings>
                        </dx:ASPxComboBox>
                    </td>
                    <td colspan="1" style="height: 26px">
                        <dx:ASPxLabel ID="ASPxLabel11" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Face Value" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td colspan="1" style="height: 26px">
                        <dx:ASPxTextBox ID="txtavailableshares" DisplayFormatString="n" runat="server" AutoPostBack="True" Height="19px" Theme="BlackGlass" Width="250px">
                            <ValidationSettings>
                                <RequiredField IsRequired="True" />
                            </ValidationSettings>
                        </dx:ASPxTextBox>
                    </td>
                    <td colspan="1" style="height: 26px"></td>
                    <td colspan="1" style="height: 26px"></td>
                    <td colspan="1" style="height: 26px"></td>
                </tr>
                <tr>
                    <td colspan="1" style="height: 26px">
                        <dx:ASPxLabel ID="ASPxLabel75" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Discount Rate" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td colspan="1" style="height: 26px">
                        <dx:ASPxTextBox ID="txtdiscountrate" runat="server" DisplayFormatString="n" AutoPostBack="True" Height="19px" ReadOnly="False" Theme="BlackGlass" Width="250px">
                            <ValidationSettings>
                                <RequiredField IsRequired="True" />
                            </ValidationSettings>
                        </dx:ASPxTextBox>
                    </td>
                    <td colspan="1" style="height: 26px">
                        <dx:ASPxLabel ID="ASPxLabel65" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Trade Reference" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td colspan="1" style="height: 26px">
                        <dx:ASPxTextBox ID="txtereference" runat="server" Height="19px" ReadOnly="False" style="margin-bottom: 0px" Theme="BlackGlass" Width="250px">
                            <ValidationSettings>
                                <RequiredField IsRequired="True" />
                            </ValidationSettings>
                        </dx:ASPxTextBox>
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
                        <dx:ASPxDateEdit ID="dtfrom" runat="server" AutoPostBack="True" Width="250px">
                            <ValidationSettings>
                                <RequiredField IsRequired="True" />
                            </ValidationSettings>
                        </dx:ASPxDateEdit>
                    </td>
                    <td colspan="1" style="height: 26px">
                        <dx:ASPxLabel ID="ASPxLabel68" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Trade Currency" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td colspan="1" style="height: 26px">
                        <dx:ASPxComboBox ID="cmbcurrency" runat="server" AutoPostBack="True" EnableCallbackMode="True" Theme="Glass" Width="250px">
                            <ValidationSettings>
                                <RequiredField IsRequired="True" />
                            </ValidationSettings>
                        </dx:ASPxComboBox>
                    </td>
                    <td colspan="1" style="height: 26px">&nbsp;</td>
                    <td colspan="1" style="height: 26px">&nbsp;</td>
                    <td colspan="1" style="height: 26px">&nbsp;</td>
                </tr>
                <tr>
                    <td colspan="1" style="height: 26px">
                        <dx:ASPxLabel ID="ASPxLabel71" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Settlement Currency" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td colspan="1" style="height: 26px">
                        <dx:ASPxComboBox ID="cmbcurrencysett" runat="server" AutoPostBack="True" EnableCallbackMode="True" Theme="Glass" Width="250px">
                            <ValidationSettings>
                                <RequiredField IsRequired="True" />
                            </ValidationSettings>
                        </dx:ASPxComboBox>
                    </td>
                    <td colspan="1" style="height: 26px">
                        <dx:ASPxLabel ID="ASPxLabel72" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Exchange Rate" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td colspan="1" style="height: 26px">
                        <dx:ASPxTextBox ID="txtexchangerate" runat="server" AutoPostBack="True" Height="19px" ReadOnly="False" style="margin-bottom: 0px" Theme="BlackGlass" Width="250px">
                            <ValidationSettings>
                                <RequiredField IsRequired="True" />
                            </ValidationSettings>
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
                        <dx:ASPxDateEdit ID="dtsettlementdate" runat="server" Width="250px" AutoPostBack="True">
                            <ValidationSettings>
                                <RequiredField IsRequired="True" />
                            </ValidationSettings>
                        </dx:ASPxDateEdit>
                    </td>
                    <td colspan="1" style="height: 26px">
                        <dx:ASPxLabel ID="ASPxLabel62" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Trade Charges" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td colspan="1" style="height: 26px">
                        <table>
                            <tr>
                                <td style="width:250px; height: 28px;">
                                    <dx:ASPxTextBox ID="txttranscharge" runat="server" AutoPostBack="True" Height="19px" Theme="BlackGlass" Width="250px">
                                        <ValidationSettings>
                                            <RequiredField IsRequired="True" />
                                        </ValidationSettings>
                                    </dx:ASPxTextBox>
                                </td>
                                <td align="left" style="height: 28px">
                                    &nbsp;</td>
                            </tr>
                        </table>
                    </td>
                    <td colspan="1" style="height: 26px">&nbsp;</td>
                    <td colspan="1" style="height: 26px">&nbsp;</td>
                    <td colspan="1" style="height: 26px">&nbsp;</td>
                </tr>
                <tr>
                    <td colspan="1" style="height: 26px">
                        <dx:ASPxLabel ID="ASPxLabel73" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Gross Amount" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td colspan="1" style="height: 26px">
                        <dx:ASPxTextBox ID="txtgross" runat="server" AutoPostBack="False" Height="19px" Theme="BlackGlass" Width="250px">
                            <ValidationSettings>
                                <RequiredField IsRequired="True" />
                            </ValidationSettings>
                        </dx:ASPxTextBox>
                    </td>
                    <td colspan="1" style="height: 26px">
                        <dx:ASPxLabel ID="ASPxLabel69" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Settlement Amount" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td colspan="1" style="height: 26px">
                        <dx:ASPxTextBox ID="txtsettlementamount" runat="server" Height="19px" ReadOnly="False" style="margin-bottom: 0px" Theme="BlackGlass" Width="250px">
                            <ValidationSettings>
                                <RequiredField IsRequired="True" />
                            </ValidationSettings>
                        </dx:ASPxTextBox>
                    </td>
                    <td colspan="1" style="height: 26px">&nbsp;</td>
                    <td colspan="1" style="height: 26px">&nbsp;</td>
                    <td colspan="1" style="height: 26px">&nbsp;</td>
                </tr>
                <tr>
                    <td colspan="1" style="height: 26px">
                        <dx:ASPxLabel ID="ASPxLabel76" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Counterpart Bank" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td colspan="1" style="height: 26px">
                        <dx:ASPxComboBox ID="cmbbank" runat="server" AutoPostBack="True" EnableCallbackMode="True" Theme="Glass" Width="250px">
                            <ValidationSettings>
                                <RequiredField IsRequired="True" />
                            </ValidationSettings>
                        </dx:ASPxComboBox>
                    </td>
                    <td colspan="1" style="height: 26px">
                        <dx:ASPxLabel ID="ASPxLabel77" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Counterpart Account" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td colspan="1" style="height: 26px">
                        <dx:ASPxTextBox ID="txtcounterpartaccount" runat="server" Height="19px" ReadOnly="False" style="margin-bottom: 0px" Theme="BlackGlass" Width="250px">
                            <ValidationSettings>
                                <RequiredField IsRequired="True" />
                            </ValidationSettings>
                        </dx:ASPxTextBox>
                    </td>
                    <td colspan="1" style="height: 26px">&nbsp;</td>
                    <td colspan="1" style="height: 26px">&nbsp;</td>
                    <td colspan="1" style="height: 26px">&nbsp;</td>
                </tr>
                <tr>
                    <td colspan="1" style="height: 26px">
                        <dx:ASPxLabel ID="ASPxLabel78" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Account Name" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td colspan="1" style="height: 26px">
                        <dx:ASPxTextBox ID="txtaccountname" runat="server" Height="19px" ReadOnly="False" style="margin-bottom: 0px" Theme="BlackGlass" Width="250px">
                            <ValidationSettings>
                                <RequiredField IsRequired="True" />
                            </ValidationSettings>
                        </dx:ASPxTextBox>
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
                        <dx:ASPxTextBox ID="txtdocumentname" runat="server" Height="19px" ReadOnly="True" style="margin-bottom: 0px" Theme="BlackGlass" Width="250px" Text="Deal Slip">
                        </dx:ASPxTextBox>
                    </td>
                    <td colspan="1" style="height: 26px">
                        <dx:ASPxLabel ID="ASPxLabel63" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Upload Deal Slip (Optional)" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td colspan="1" style="height: 26px">
                        <table class="dxflInternalEditorTable">
                            <tr>
                                <td style="width: 200px">
                                    <asp:FileUpload ID="FileUpload1" runat="server" />
                                </td>
                                <td>
                                    <dx:ASPxButton ID="ASPxButton14" runat="server" style="height: 23px" Text="Upload Document" Theme="BlackGlass">
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
                    <td colspan="1" style="height: 25px">
                        <dx:ASPxLabel ID="ASPxLabel61" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Total Charges" Theme="Glass" Visible="False">
                        </dx:ASPxLabel>
                        <dx:ASPxLabel ID="ASPxLabel39" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Client Outstanding Charges" Theme="Glass" Visible="False">
                        </dx:ASPxLabel>
                        <dx:ASPxTextBox ID="txtcharge" runat="server" Height="19px" ReadOnly="True" style="margin-bottom: 0px" Theme="BlackGlass" Visible="False" Width="250px">
                        </dx:ASPxTextBox>
                    </td>
                    <td colspan="1" style="height: 25px">
                        <dx:ASPxTextBox ID="txttotalcharges" runat="server" Height="19px" ReadOnly="True" style="margin-bottom: 0px" Theme="BlackGlass" Visible="False" Width="250px">
                        </dx:ASPxTextBox>
                    </td>
                    <td colspan="1" style="height: 25px"></td>
                    <td colspan="4" style="height: 25px">
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
                        &nbsp;
                        <dx:ASPxButton ID="ASPxButton15" runat="server" style="height: 23px" Text="Refresh" Theme="BlackGlass">
                        </dx:ASPxButton>
                        &nbsp;<dx:ASPxButton ID="ASPxButton16" runat="server" style="height: 23px" Text="Archive" Theme="BlackGlass" CausesValidation="False" Visible="False">
                        </dx:ASPxButton>
                    </td>
                </tr>
            </table>
        </asp:Panel>
               
        <asp:Panel ID="Panel13" runat="server" Enabled="true" Font-Names="Cambria" Font-Size="Medium" GroupingText="Captured Trades">
            <table width="100%">
                <tr>
                    <td align="center">
            
                        <dx:ASPxGridView ID="grdeditable" runat="server" KeyFieldName="id" Settings-ShowTitlePanel="true" Theme="Glass" Width="100%">
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
                                        <asp:LinkButton ID="DeleteID5" runat="server" CommandArgument='<%# Eval("ID") %>' CommandName="Edit" Text="Edit">
                                                              </asp:LinkButton>
                                    </DataItemTemplate>
                                </dx:GridViewDataColumn>
                                <dx:GridViewDataColumn Caption="Client">
                                    <DataItemTemplate>
                                        <dx:ASPxLabel runat="server" Text='<%# Eval("ClientNo") %>'>
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
                                <dx:GridViewDataColumn Caption="Face Value">
                                    <DataItemTemplate>
                                        <dx:ASPxLabel runat="server" Text='<%# Eval("Units") %>'>
                                        </dx:ASPxLabel>
                                    </DataItemTemplate>
                                </dx:GridViewDataColumn>
                                <dx:GridViewDataColumn Caption="Price">
                                    <DataItemTemplate>
                                        <dx:ASPxLabel runat="server" Text='<%# Eval("Price") %>'>
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
                    <td align="center">
                        &nbsp;</td>
                </tr>
            </table>
        </asp:Panel>
               
        <asp:Panel ID="Panel9" runat="server" Enabled="true" Font-Names="Cambria" Font-Size="Medium" GroupingText="Pending Settlement" Visible="False">
            <table width="100%">
                <tr>
                    <td align="center">
                        <dx:ASPxGridView ID="grdpendingsettlement" runat="server" KeyFieldName="id" Settings-ShowTitlePanel="true" Theme="Glass" Width="100%">
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
                                        <asp:LinkButton ID="DeleteID2" runat="server" CommandArgument='<%# Eval("ID") %>' CommandName="Update Settled" OnClientClick="if ( !confirm('Are you sure you want to mark this Transaction as Settled? ')) return false;" Text="Update Settled">
                                                              </asp:LinkButton>
                                    </DataItemTemplate>
                                </dx:GridViewDataColumn>
                                <dx:GridViewDataColumn Caption="" VisibleIndex="0">
                                    <DataItemTemplate>
                                        <asp:LinkButton ID="DeleteID1" runat="server" CommandArgument='<%# Eval("ID") %>' CommandName="Update Failed" OnClientClick="if ( !confirm('Are you sure you want to mark this Transaction as Failed?')) return false;" Text="Update Failed">
                                                              </asp:LinkButton>
                                    </DataItemTemplate>
                                </dx:GridViewDataColumn>
                                <dx:GridViewDataColumn Caption="Client">
                                    <DataItemTemplate>
                                        <dx:ASPxLabel runat="server" Text='<%# Eval("ClientNo") %>'>
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
                                <dx:GridViewDataColumn Caption="Face Value">
                                    <DataItemTemplate>
                                        <dx:ASPxLabel runat="server" Text='<%# Eval("Units") %>'>
                                        </dx:ASPxLabel>
                                    </DataItemTemplate>
                                </dx:GridViewDataColumn>
                                <dx:GridViewDataColumn Caption="Price">
                                    <DataItemTemplate>
                                        <dx:ASPxLabel runat="server" Text='<%# Eval("Price") %>'>
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
                    <td align="center">&nbsp;</td>
                </tr>
            </table>
        </asp:Panel>
               
        <asp:Panel ID="Panel12" runat="server" Enabled="true" Font-Names="Cambria" Font-Size="Medium" GroupingText="Rejected Trades">
            <table width="100%">
                <tr>
                    <td align="center">
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
                                        <asp:LinkButton ID="DeleteID4" runat="server" CommandArgument='<%# Eval("ID") %>' CommandName="Edit & Re-Submit"  Text="Edit & Re-Submit">
                                                              </asp:LinkButton>
                                    </DataItemTemplate>
                                </dx:GridViewDataColumn>
                                <dx:GridViewDataColumn Caption="Client">
                                    <DataItemTemplate>
                                        <dx:ASPxLabel runat="server" Text='<%# Eval("ClientNo") %>'>
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
                                <dx:GridViewDataColumn Caption="Face Value">
                                    <DataItemTemplate>
                                        <dx:ASPxLabel runat="server" Text='<%# Eval("Units") %>'>
                                        </dx:ASPxLabel>
                                    </DataItemTemplate>
                                </dx:GridViewDataColumn>
                                <dx:GridViewDataColumn Caption="Price">
                                    <DataItemTemplate>
                                        <dx:ASPxLabel runat="server" Text='<%# Eval("Price") %>'>
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
                    <td align="center">&nbsp;</td>
                </tr>
            </table>
        </asp:Panel>
               
        <asp:Panel ID="Panel10" runat="server" Enabled="true" Font-Names="Cambria" Font-Size="Medium" GroupingText="Failed Trades">
            <table width="100%">
                <tr>
                    <td align="center">
                        <dx:ASPxGridView ID="grdfailed" runat="server" KeyFieldName="id" Settings-ShowTitlePanel="true" Theme="Glass" Width="100%">
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
                            <Columns>
                               <%-- <dx:GridViewDataColumn Caption="" VisibleIndex="0">
                                    <DataItemTemplate>
                                        <asp:LinkButton ID="edit" runat="server" CommandArgument='<%# Eval("ID") %>' CommandName="Edit"  Text="Edit & Re-Submit">
                                                              </asp:LinkButton>
                                    </DataItemTemplate>
                                </dx:GridViewDataColumn>

                                  <dx:GridViewDataColumn Caption="" VisibleIndex="0">
                                    <DataItemTemplate>
                                        <asp:LinkButton ID="deletetrans" runat="server" CommandArgument='<%# Eval("ID") %>' CommandName="delete"  Text="Cancel Transaction">
                                                              </asp:LinkButton>
                                    </DataItemTemplate>
                                </dx:GridViewDataColumn>--%>


                                <dx:GridViewDataColumn Caption="Client">
                                    <DataItemTemplate>
                                        <dx:ASPxLabel runat="server" Text='<%# Eval("ClientNo") %>'>
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
                                <dx:GridViewDataColumn Caption="Price">
                                    <DataItemTemplate>
                                        <dx:ASPxLabel runat="server" Text='<%# Eval("Price") %>'>
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
               
        <asp:Panel ID="Panel11" runat="server" Enabled="true" Font-Names="Cambria" Font-Size="Medium" GroupingText="Settled Trades">
            <table width="100%">
                <tr>
                    <td align="center">
                        <dx:ASPxGridView ID="grdsettled" runat="server" KeyFieldName="id" Settings-ShowTitlePanel="true" Theme="Glass" Width="100%">
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
                                <%-- <dx:GridViewDataColumn Caption="" VisibleIndex="0">
                                    <DataItemTemplate>
                                        <asp:LinkButton ID="edit" runat="server" CommandArgument='<%# Eval("ID") %>' CommandName="Edit"  Text="Edit & Re-Submit">
                                                              </asp:LinkButton>
                                    </DataItemTemplate>
                                </dx:GridViewDataColumn>

                                  <dx:GridViewDataColumn Caption="" VisibleIndex="0">
                                    <DataItemTemplate>
                                        <asp:LinkButton ID="deletetrans" runat="server" CommandArgument='<%# Eval("ID") %>' CommandName="delete"  Text="Cancel Transaction">
                                                              </asp:LinkButton>
                                    </DataItemTemplate>
                                </dx:GridViewDataColumn>--%>
                               <dx:GridViewDataColumn Caption="Client">
                                    <DataItemTemplate>
                                        <dx:ASPxLabel runat="server" Text='<%# Eval("ClientNo") %>'>
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
                                <dx:GridViewDataColumn Caption="Price">
                                    <DataItemTemplate>
                                        <dx:ASPxLabel runat="server" Text='<%# Eval("Price") %>'>
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
                        &nbsp; <%--<dx:ASPxButton ID="ASPxButton14" runat="server" Text="Delete Batch Details" Theme="BlackGlass">
                        </dx:ASPxButton>--%></td>
                </tr>
                <tr>
                    <td align="center">&nbsp;</td>
                </tr>
            </table>
        </asp:Panel>
               
</asp:Panel>
  
</div>
</asp:Content>

