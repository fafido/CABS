<%@ Page Language="VB" MasterPageFile="~/CDSUser.master" AutoEventWireup="false" CodeFile="moneymarketrollover.aspx.vb" Inherits="TransferSec_moneymarketrollover" title="Money Market Rollover" %>
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
                       <dx:ASPxLabel ID="ASPxLabel1" runat="server" Text="Fixed Income Investment Settlements&gt;&gt;Money Market Rollover" Font-Names="Cambria" Font-Size="Small" Theme="PlasticBlue"></dx:ASPxLabel>

                   </td>
            </tr>
        </table>

        
        <asp:Panel ID="Panel3" runat="server" Font-Names="Cambria" Font-Size="Medium" GroupingText="Search Client">
           
            <table width="100%">
                <tr>
                    <td colspan="1">
                        <dx:ASPxLabel ID="ASPxLabel4" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Search Money Market Client" Theme="Glass">
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
                    <td colspan="1">
                        <dx:ASPxLabel ID="ASPxLabel83" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Select Money Market" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td colspan="2">
                        <dx:ASPxComboBox ID="cmbmoneymarket" runat="server" Theme="Glass" Width="447px" AutoPostBack="True">
                           
                          
                        </dx:ASPxComboBox>
                    </td>
                    <td colspan="1">&nbsp;</td>
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
                        <dx:ASPxLabel ID="ASPxLabel38" runat="server" Font-Names="Cambria" Font-Size="Medium" Text="Account Details" Theme="Glass">
                        </dx:ASPxLabel>
                        <hr />
                    </td>
                </tr>
                <tr>
                    <td colspan="1">
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
                    <td colspan="1">&nbsp;</td>
                    <td colspan="1">&nbsp;</td>
                    <td colspan="1">&nbsp;</td>
                </tr>
                <tr>
                    <td colspan="1">
                        <dx:ASPxLabel ID="ASPxLabel66" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Description" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td colspan="1">
                        <dx:ASPxTextBox ID="txtdescription" runat="server" Height="19px" ReadOnly="False" style="margin-bottom: 0px" Theme="BlackGlass" Width="250px">
                       
                             </dx:ASPxTextBox>
                    </td>
                    <td colspan="1">
                        <dx:ASPxLabel ID="ASPxLabel67" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Asset Manager" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td colspan="1">
                        <dx:ASPxComboBox ID="cmbassetmanager" runat="server" ReadOnly="True" EnableCallbackMode="True" Theme="Glass" Width="250px">
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
                        <dx:ASPxTextBox ID="txtamount" DisplayFormatString="n" ReadOnly="True" runat="server" Height="19px" style="margin-bottom: 0px" Theme="BlackGlass" Width="250px">
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
                        <dx:ASPxLabel ID="ASPxLabel36" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Settlement Amount" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td colspan="1" style="height: 26px">
                        <dx:ASPxTextBox ID="txtsettlementamount" DisplayFormatString="n"  runat="server" Height="19px" ReadOnly="False" Theme="BlackGlass" Width="250px">
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
                        <dx:ASPxComboBox ID="cmbcurrency" runat="server" AutoPostBack="True" ReadOnly="True" EnableCallbackMode="True" Theme="Glass" Width="250px">
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
                        <dx:ASPxLabel ID="ASPxLabel80" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Settlement Currency" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td colspan="1" style="height: 26px">
                        <dx:ASPxComboBox ID="cmbcurrencysett" runat="server" EnableCallbackMode="True" ReadOnly="True" AutoPostBack="True" Theme="Glass" Width="250px">
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
                        <dx:ASPxDateEdit ID="dttradedate" runat="server" ReadOnly="True" Width="250px">
                       <ValidationSettings>
                                <RequiredField IsRequired="True" />
                            </ValidationSettings>
                             </dx:ASPxDateEdit>
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
                        <dx:ASPxDateEdit ID="dtsettlementdate" ReadOnly="True" runat="server" Width="250px">
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
                        <dx:ASPxTextBox ID="txtfixedrate" runat="server" ReadOnly="True" DisplayFormatString="n" Height="19px" style="margin-bottom: 0px" Theme="BlackGlass" Width="250px">
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
                        <dx:ASPxLabel ID="ASPxLabel79" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Number of Days" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td colspan="1" style="height: 26px">
                        <dx:ASPxTextBox ID="txtnumberofdays" runat="server" ReadOnly="True"  AutoPostBack="True" Height="19px" style="margin-bottom: 0px" Theme="BlackGlass" Width="250px">
                       
                             </dx:ASPxTextBox>
                    </td>
                    <td colspan="1" style="height: 26px">
                        <dx:ASPxLabel ID="ASPxLabel81" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Exchange Rate" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td colspan="1" style="height: 26px">
                        <dx:ASPxTextBox ID="txtexchangerate" runat="server" Height="19px" DisplayFormatString="n" ReadOnly="True" style="margin-bottom: 0px" Theme="BlackGlass" Width="250px">
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
                        <dx:ASPxLabel ID="ASPxLabel70" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Day Count Basis" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td colspan="1" style="height: 26px">
                        <dx:ASPxComboBox ID="cmbdaycount" runat="server" ReadOnly="True" EnableCallbackMode="True" Theme="Glass" Width="250px" AutoPostBack="True">
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
                        <dx:ASPxComboBox ID="cmbpaymentfrequency" ReadOnly="True" runat="server" EnableCallbackMode="True" Theme="Glass" Width="250px">
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
                    <td colspan="1" style="height: 26px">&nbsp;</td>
                    <td colspan="1" style="height: 26px">&nbsp;</td>
                    <td colspan="1" style="height: 26px">&nbsp;</td>
                </tr>
                <tr>
                    <td colspan="1" style="height: 26px">
                        <dx:ASPxLabel ID="ASPxLabel72" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Maturity Date" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td colspan="1" style="height: 26px">
                        <dx:ASPxDateEdit ID="dtmaturitydate" ReadOnly="True" runat="server" Width="250px">
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
                        <dx:ASPxTextBox ID="txttax" runat="server" ReadOnly="True" Height="19px" DisplayFormatString="n" style="margin-bottom: 0px" Theme="BlackGlass" Width="250px">
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
                        <dx:ASPxLabel ID="ASPxLabel62" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Trade Charges" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td colspan="1" style="height: 26px">
                        <dx:ASPxTextBox ID="txttranscharge" runat="server" Height="19px" ReadOnly="True" DisplayFormatString="n" style="margin-bottom: 0px" Theme="BlackGlass" Width="250px">
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
                        <dx:ASPxComboBox ID="cmbordertype" runat="server" ReadOnly="True" EnableCallbackMode="True" Theme="Glass" Width="250px">
                            <Items>
                                <dx:ListEditItem Text="RVP" Value="RVP" />
                                <dx:ListEditItem Text="RF" Value="RF" />
                            </Items>
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
                        <dx:ASPxLabel ID="ASPxLabel75" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Counter Part Bank" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td colspan="1" style="height: 26px">
                        <dx:ASPxComboBox ID="cmbbank" runat="server" ReadOnly="True" EnableCallbackMode="True" Theme="Glass" Width="250px" AutoPostBack="True">
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
                        <dx:ASPxTextBox ID="txtAccountName" ReadOnly="True" runat="server" Height="19px" style="margin-bottom: 0px" Theme="BlackGlass" Width="250px">
                      
                             </dx:ASPxTextBox>
                    </td>
                    <td colspan="1" style="height: 26px"></td>
                    <td colspan="1" style="height: 26px"></td>
                    <td colspan="1" style="height: 26px"></td>
                </tr>
                <tr>
                    <td colspan="1" style="height: 26px">
                        <dx:ASPxLabel ID="ASPxLabel77" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Bank Account Number" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td colspan="1" style="height: 26px">
                        <dx:ASPxTextBox ID="txtaccountnumber" ReadOnly="True" runat="server" Height="19px" style="margin-bottom: 0px" Theme="BlackGlass" Width="250px">
                     
                             </dx:ASPxTextBox>
                    </td>
                    <td colspan="1" style="height: 26px">
                        <dx:ASPxLabel ID="ASPxLabel78" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Maturity Value" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td colspan="1" style="height: 26px">
                        <dx:ASPxTextBox ID="txtmaturityvalue" DisplayFormatString="n" ReadOnly="True" runat="server" Height="19px" style="margin-bottom: 0px" Theme="BlackGlass" Width="250px">
                        </dx:ASPxTextBox>
                    </td>
                    <td colspan="1" style="height: 26px">&nbsp;</td>
                    <td colspan="1" style="height: 26px">&nbsp;</td>
                    <td colspan="1" style="height: 26px">&nbsp;</td>
                </tr>
                <tr>
                    <td colspan="1" style="height: 26px">
                        <dx:ASPxLabel ID="ASPxLabel65" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Reference" Theme="Glass">
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
                    <td colspan="1" style="height: 26px">&nbsp;</td>
                    <td colspan="1" style="height: 26px">&nbsp;</td>
                </tr>
                <tr>
                    <td colspan="7" style="height: 26px">
                        <hr /></td>
                </tr>
                <tr>
                    <td colspan="1" style="height: 26px">
                        <dx:ASPxLabel ID="ASPxLabel84" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Callback Amount" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td colspan="1" style="height: 26px">
                        <dx:ASPxTextBox ID="txtcallbackamount" runat="server" DisplayFormatString="n" Height="19px" style="margin-bottom: 0px" Text="0" Theme="BlackGlass" Width="250px" AutoPostBack="True">
                        </dx:ASPxTextBox>
                    </td>
                    <td colspan="1" style="height: 26px">
                        <dx:ASPxLabel ID="ASPxLabel82" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Rollover Amount" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td colspan="1" style="height: 26px">
                        <table class="auto-style1">
                            <tr>
                                <td style="width: 182px">
                                    <dx:ASPxTextBox ID="txtcurrentvalue" runat="server" AutoPostBack="True" DisplayFormatString="n" Height="19px" style="margin-bottom: 0px" Theme="BlackGlass" Width="250px">
                                    </dx:ASPxTextBox>
                                    <asp:Label ID="lblcurrentamount" runat="server" Visible="False"></asp:Label>
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                        </table>
                    </td>
                    <td colspan="1" style="height: 26px"></td>
                    <td colspan="1" style="height: 26px"></td>
                    <td colspan="1" style="height: 26px"></td>
                </tr>
                <tr>
                    <td colspan="1" style="height: 26px">
                        <dx:ASPxLabel ID="ASPxLabel86" runat="server" Font-Names="Cambria" Font-Size="Small" Text="New Start Date" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td colspan="1" style="height: 26px">
                        <dx:ASPxDateEdit ID="dtnewtradedate" runat="server" Width="250px">
                            <ValidationSettings>
                                <RequiredField IsRequired="True" />
                            </ValidationSettings>
                        </dx:ASPxDateEdit>
                    </td>
                    <td colspan="1" style="height: 26px">
                        <dx:ASPxLabel ID="ASPxLabel85" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Number of Days" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td colspan="1" style="height: 26px">
                        <dx:ASPxTextBox ID="txtnewnumberofdays" runat="server" AutoPostBack="True" Height="19px" style="margin-bottom: 0px" Theme="BlackGlass" Width="250px">
                        </dx:ASPxTextBox>
                    </td>
                    <td colspan="1" style="height: 26px">&nbsp;</td>
                    <td colspan="1" style="height: 26px">&nbsp;</td>
                    <td colspan="1" style="height: 26px">&nbsp;</td>
                </tr>
                <tr>
                    <td colspan="1" style="height: 26px">
                        <dx:ASPxLabel ID="ASPxLabel87" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Maturity Date" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td colspan="1" style="height: 26px">
                        <dx:ASPxDateEdit ID="dtnewmaturitydate" runat="server" Width="250px">
                            <ValidationSettings>
                                <RequiredField IsRequired="True" />
                            </ValidationSettings>
                        </dx:ASPxDateEdit>
                    </td>
                    <td colspan="1" style="height: 26px">
                        <dx:ASPxLabel ID="ASPxLabel88" runat="server" Font-Names="Cambria" Font-Size="Small" Text="New Fixed Rate" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td colspan="1" style="height: 26px">
                        <dx:ASPxTextBox ID="txtnewinterest" runat="server" AutoPostBack="True" DisplayFormatString="n" Height="19px" style="margin-bottom: 0px" Theme="BlackGlass" Width="250px">
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
                        <dx:ASPxLabel ID="ASPxLabel89" runat="server" Font-Names="Cambria" Font-Size="Small" Text="New Maturity Value" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td colspan="1" style="height: 26px">
                        <dx:ASPxTextBox ID="txtnewmaturityvalue" runat="server" DisplayFormatString="n" Height="19px" style="margin-bottom: 0px" Theme="BlackGlass" Width="250px">
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
                        <dx:ASPxLabel ID="ASPxLabel64" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Document Name" Theme="Glass" Visible="False">
                        </dx:ASPxLabel>
                    </td>
                    <td colspan="1" style="height: 26px">
                        <dx:ASPxTextBox ID="txtdocumentname" runat="server" Height="19px" ReadOnly="True" style="margin-bottom: 0px" Theme="BlackGlass" Width="250px" Text="Attachment" Visible="False">
                        </dx:ASPxTextBox>
                    </td>
                    <td colspan="1" style="height: 26px">
                        <dx:ASPxLabel ID="ASPxLabel63" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Upload Deal Slip (Optional)" Theme="Glass" Visible="False">
                        </dx:ASPxLabel>
                    </td>
                    <td colspan="1" style="height: 26px">
                        <table class="dxflInternalEditorTable">
                            <tr>
                                <td style="width: 200px">
                                    <asp:FileUpload ID="FileUpload1" runat="server" Visible="False" />
                                </td>
                                <td>
                                    <dx:ASPxButton ID="ASPxButton14" runat="server" style="height: 23px" Text="Upload Document" Theme="BlackGlass" Visible="False">
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
                        <asp:Label ID="lblid" runat="server" Visible="False"></asp:Label>
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
                    <td align="center" colspan="7">
                       
                        <dx:ASPxButton ID="ASPxButton13" runat="server" style="height: 23px" Text="Save" Theme="BlackGlass">
                        </dx:ASPxButton>
                        &nbsp;<dx:ASPxButton ID="ASPxButton15" runat="server" CausesValidation="False" style="height: 23px" Text="Refresh" Theme="BlackGlass">
                        </dx:ASPxButton>
                       
                    </td>
                </tr>
            </table>
                   

        </asp:Panel>
       
                        &nbsp;<asp:Panel ID="Panel10" runat="server" Enabled="true" Font-Names="Cambria" Font-Size="Medium" GroupingText="Pending Money Market Rollover">
            <table width="100%">
                <tr>
                    <td align="center">
                        <dx:ASPxGridView ID="AspxGridview4" runat="server" KeyFieldName="id" Settings-ShowTitlePanel="true" Theme="Glass" Width="100%">
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
                                <dx:GridViewDataColumn Caption="ClientName">
                                    <DataItemTemplate>
                                        <dx:ASPxLabel runat="server" Text='<%# Eval("ClientName") %>'>
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
                                        <dx:ASPxLabel runat="server" Text='<%# Eval("Amount") %>'>
                                        </dx:ASPxLabel>
                                    </DataItemTemplate>
                                </dx:GridViewDataColumn>
                                   <dx:GridViewDataColumn Caption="Rollover Amount">
                                    <DataItemTemplate>
                                        <dx:ASPxLabel runat="server" Text='<%# Eval("CallbackAmount") %>'>
                                        </dx:ASPxLabel>
                                    </DataItemTemplate>
                                </dx:GridViewDataColumn>
                                <dx:GridViewDataColumn Caption="Rate">
                                    <DataItemTemplate>
                                        <dx:ASPxLabel runat="server" Text='<%# Eval("FixedRate") %>'>
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
                    <td align="center">&nbsp;</td>
                </tr>
            </table>
        </asp:Panel>
               
        <asp:Panel ID="Panel12" runat="server" Enabled="true" Font-Names="Cambria" Font-Size="Medium" GroupingText="Rejected Money Market Rollover">
            <table width="100%">
                <tr>
                    <td align="center">
                        <dx:ASPxGridView ID="AspxGridview6" runat="server" KeyFieldName="id" Settings-ShowTitlePanel="true" Theme="Glass" Width="100%">
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
                                        <asp:LinkButton ID="DeleteID5" runat="server" CommandArgument='<%# Eval("ID") %>' CommandName="Edit" Text="Edit & Re-Submit">
                                                              </asp:LinkButton>
                                    </DataItemTemplate>
                                </dx:GridViewDataColumn>
                                <dx:GridViewDataColumn Caption="Client">
                                    <DataItemTemplate>
                                        <dx:ASPxLabel runat="server" Text='<%# Eval("ClientNo") %>'>
                                        </dx:ASPxLabel>
                                    </DataItemTemplate>
                                </dx:GridViewDataColumn>
                                <dx:GridViewDataColumn Caption="ClientName">
                                    <DataItemTemplate>
                                        <dx:ASPxLabel runat="server" Text='<%# Eval("ClientName") %>'>
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
                                        <dx:ASPxLabel runat="server" Text='<%# Eval("Amount") %>'>
                                        </dx:ASPxLabel>
                                    </DataItemTemplate>
                                </dx:GridViewDataColumn>
                                 <dx:GridViewDataColumn Caption="Rollover Amount">
                                    <DataItemTemplate>
                                        <dx:ASPxLabel runat="server" Text='<%# Eval("CallbackAmount") %>'>
                                        </dx:ASPxLabel>
                                    </DataItemTemplate>
                                </dx:GridViewDataColumn>
                                <dx:GridViewDataColumn Caption="Rate">
                                    <DataItemTemplate>
                                        <dx:ASPxLabel runat="server" Text='<%# Eval("FixedRate") %>'>
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
            </table>
        </asp:Panel>
               
        <asp:Panel ID="Panel11" runat="server" Enabled="true" Font-Names="Cambria" Font-Size="Medium" GroupingText="Committed Money Market Rollover">
            <table width="100%">
                <tr>
                    <td align="center">
                        <dx:ASPxGridView ID="AspxGridview5" runat="server" Settings-ShowTitlePanel="true" Theme="Glass" Width="100%" KeyFieldName="id">
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
                                        <asp:LinkButton ID="DeleteID6" runat="server" CommandArgument='<%# Eval("ID") %>' CommandName="Edit" Text="View Money Market">
                                                              </asp:LinkButton>
                                    </DataItemTemplate>
                                </dx:GridViewDataColumn>
                                <dx:GridViewDataColumn Caption="Client">
                                    <DataItemTemplate>
                                        <dx:ASPxLabel runat="server" Text='<%# Eval("ClientNo") %>'>
                                        </dx:ASPxLabel>
                                    </DataItemTemplate>
                                </dx:GridViewDataColumn>
                                <dx:GridViewDataColumn Caption="ClientName">
                                    <DataItemTemplate>
                                        <dx:ASPxLabel runat="server" Text='<%# Eval("ClientName") %>'>
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
                                        <dx:ASPxLabel runat="server" Text='<%# Eval("Amount") %>'>
                                        </dx:ASPxLabel>
                                    </DataItemTemplate>
                                </dx:GridViewDataColumn>
                                 <dx:GridViewDataColumn Caption="Rollover Amount">
                                    <DataItemTemplate>
                                        <dx:ASPxLabel runat="server" Text='<%# Eval("CallbackAmount") %>'>
                                        </dx:ASPxLabel>
                                    </DataItemTemplate>
                                </dx:GridViewDataColumn>
                                <dx:GridViewDataColumn Caption="Rate">
                                    <DataItemTemplate>
                                        <dx:ASPxLabel runat="server" Text='<%# Eval("FixedRate") %>'>
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
                        &nbsp; <%--<dx:ASPxButton ID="ASPxButton14" runat="server" Text="Delete Batch Details" Theme="BlackGlass">
                        </dx:ASPxButton>--%></td>
                </tr>
                <tr>
                    <td align="center">
                        <dx:ASPxPopupControl ID="ASPxPopupControl1" runat="server" BackColor="#DDECFE" CloseAction="CloseButton" EnableCallbackAnimation="True" HeaderText="System Message" ShowCollapseButton="True" ShowPageScrollbarWhenModal="True" ShowPinButton="True" Theme="Office2010Blue" Width="400px">
                            <contentcollection>
                                <dx:PopupControlContentControl runat="server" SupportsDisabledAttribute="True">
                                    <dx:ASPxRoundPanel ID="ASPxRoundPanel6" runat="server" BackColor="White" ShowHeader="False" Width="100%">
                                        <panelcollection>
                                            <dx:PanelContent runat="server" SupportsDisabledAttribute="True">
                                                <table style="width: 100%">
                                                    <tr>
                                                        <td align="center" style="height: 57px">
                                                            <dx:ASPxLabel ID="lblmsgboxnew" runat="server" Text="OTP" Theme="iOS">
                                                            </dx:ASPxLabel>
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

