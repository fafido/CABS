<%@ Page Language="VB" MasterPageFile="~/CDSUser.master" AutoEventWireup="false" CodeFile="LendingandBorrowingPara.aspx.vb" Inherits="BrokerMode_LendingandBorrowingPara" title="Lending & Borrowing Rules" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxTabControl" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx1" %>


<%@ Register assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dx1" %>

<%@ Register assembly="DevExpress.XtraCharts.v13.2.Web, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.XtraCharts.Web" tagprefix="dxchartsui" %>
<%@ Register assembly="DevExpress.XtraCharts.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.XtraCharts" tagprefix="cc1" %>


<%@ Register assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxFileManager" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxUploadControl" tagprefix="dx" %>


<%@ Register assembly="DevExpress.Web.ASPxScheduler.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxScheduler.Controls" tagprefix="dxwschsc" %>
<%@ Register assembly="DevExpress.Web.ASPxScheduler.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxScheduler" tagprefix="dxwschs" %>



<%@ Register assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxGridView" tagprefix="dx1" %>



<asp:Content id="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
        
    <asp:Panel id="Panel1" runat="server">
    
<table style="width: 100%" >
   
    
    <tr>
        <td style="width: 100%" valign="top">
              <dx:ASPxLabel ID="ASPxLabel1" runat="server" Text="Parameters&gt;&gt;Lending &amp; Borrowing Rules" Font-Names="Cambria" Font-Size="Small" Theme="PlasticBlue"></dx:ASPxLabel>
           
                 <asp:Panel runat="server" Width="100%" GroupingText="Lending and Borrowing Rules">
<table style="width: 100%">
            <tr>
                <td colspan ="1">
                    &nbsp;</td>
                <td colspan ="1">
                    <dx:ASPxComboBox ID="cmbSecurities" runat="server" Theme="Glass" Width="200px" Visible="False">
                        <ValidationSettings>
                            <RequiredField IsRequired="True" />
                        </ValidationSettings>
                    </dx:ASPxComboBox>
                </td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>

            </tr>
                <tr>
                    <td colspan="1">
                        <dx:ASPxLabel ID="ASPxLabel30" runat="server" Text="Option Name" Theme="Office2010Blue">
                        </dx:ASPxLabel>
                    </td>
                    <td colspan="1">
                        <dx:ASPxTextBox ID="txtoption" runat="server" Theme="Office2003Blue" Width="200px">
                            <ValidationSettings>
                                <RequiredField IsRequired="True" />
                            </ValidationSettings>
                        </dx:ASPxTextBox>
                    </td>
                    <td colspan="1">&nbsp;</td>
                    <td colspan="1">&nbsp;</td>
                    <td colspan="1">&nbsp;</td>
                    <td colspan="1">&nbsp;</td>
                    <td colspan="1">&nbsp;</td>
                    <td colspan="1">&nbsp;</td>
            </tr>
                <tr>
                    <td colspan="1">
                        <dx:ASPxLabel ID="ASPxLabel31" runat="server" Text="Interest Rate Interval" Theme="Office2010Blue">
                        </dx:ASPxLabel>
                    </td>
                    <td colspan="1">
                        <asp:RadioButtonList ID="RadioButtonList1" runat="server" Font-Size="X-Small" RepeatDirection="Horizontal">
                            <asp:ListItem>Monthly</asp:ListItem>
                            <asp:ListItem>Annually</asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                    <td colspan="1">&nbsp;</td>
                    <td colspan="1">&nbsp;</td>
                    <td colspan="1">&nbsp;</td>
                    <td colspan="1">&nbsp;</td>
                    <td colspan="1">&nbsp;</td>
                    <td colspan="1">&nbsp;</td>
            </tr>
                <tr>
                <td colspan ="1">
                    <dx:ASPxLabel ID="ASPxLabel24" runat="server" Text="Interest Rate (%)" Theme="Office2010Blue">
                    </dx:ASPxLabel>
                    </td>
                <td colspan ="1">
                    <dx:ASPxTextBox ID="txtInterestRate" runat="server" Theme="Office2003Blue" Width="200px">
                        <ValidationSettings>
                            <RequiredField IsRequired="True" />
                        </ValidationSettings>
                    </dx:ASPxTextBox>
                    </td>
                <td colspan ="1">
                    &nbsp;</td>
                <td colspan ="1">
                    &nbsp;</td>
                <td colspan ="1">
                    &nbsp;</td>
                <td colspan ="1">
                    &nbsp;</td>
                <td colspan ="1">&nbsp;</td>
                <td colspan ="1">&nbsp;</td>

            </tr>
                <tr>
                    <td colspan="1">
                        <dx:ASPxLabel ID="ASPxLabel25" runat="server" Text="Service Charges Amount" Theme="Office2010Blue">
                        </dx:ASPxLabel>
                    </td>
                    <td colspan="1">
                        <dx:ASPxTextBox ID="txtServiceRate" runat="server" Theme="Glass"  Width="200px">
                            <ValidationSettings>
                                <RequiredField IsRequired="True" />
                            </ValidationSettings>
                        </dx:ASPxTextBox>
                    </td>
                    <td colspan="1">&nbsp;</td>
                    <td colspan="1">&nbsp;</td>
                    <td colspan="1">&nbsp;</td>
                    <td colspan="1">&nbsp;</td>
                    <td colspan="1"></td>
                    <td colspan="1"></td>
            </tr>
            <tr>
                <td colspan="1">
                    <dx:ASPxLabel ID="ASPxLabel29" runat="server" Text="Haircut (%)" Theme="Office2010Blue">
                    </dx:ASPxLabel>
                </td>
                <td colspan="1">
                    <dx:ASPxTextBox ID="txthaircut" runat="server" Theme="Glass" Width="200px">
                        <ValidationSettings>
                            <RequiredField IsRequired="True" />
                        </ValidationSettings>
                    </dx:ASPxTextBox>
                </td>
                <td colspan="1">&nbsp;</td>
                <td colspan="1">&nbsp;</td>
                <td colspan="1">&nbsp;</td>
                <td colspan="1">&nbsp;</td>
                <td colspan="1">&nbsp;</td>
                <td colspan="1">&nbsp;</td>
            </tr>
            <tr>
                <td colspan="1" style="height: 28px">
                    <dx:ASPxLabel ID="ASPxLabel26" runat="server" Text="Lending Period (Months)" Theme="Office2010Blue">
                    </dx:ASPxLabel>
                </td>
                <td colspan="1" style="height: 28px">
                    <dx:ASPxTextBox ID="txtLendingPeriod" runat="server" Theme="Glass"  Width="200px">
                        <ValidationSettings>
                            <RequiredField IsRequired="True" />
                        </ValidationSettings>
                    </dx:ASPxTextBox>
                </td>
                <td colspan="1" style="height: 28px"></td>
                <td colspan="1" style="height: 28px"></td>
                <td colspan="1" style="height: 28px"></td>
                <td colspan="1" style="height: 28px"></td>
                <td colspan="1" style="height: 28px"></td>
                <td colspan="1" style="height: 28px"></td>
            </tr>
                <tr>
                    <td colspan="1">
                        <dx:ASPxLabel ID="ASPxLabel28" runat="server" Text="Maximum Amount" Theme="Office2010Blue">
                        </dx:ASPxLabel>
                    </td>
                    <td colspan="1">
                        <dx:ASPxTextBox ID="txtMaxAmount" runat="server" Text="99999999" Theme="Glass" Width="200px">
                        </dx:ASPxTextBox>
                    </td>
                    <td colspan="1">&nbsp;</td>
                    <td colspan="1">&nbsp;</td>
                    <td colspan="1">&nbsp;</td>
                    <td colspan="1">&nbsp;</td>
                    <td colspan="1">&nbsp;</td>
                    <td colspan="1">&nbsp;</td>
            </tr>
                <tr>
                <td colspan ="1">
                    <dx:ASPxLabel ID="ASPxLabel27" runat="server" Text="Minimum Amount" Theme="Office2010Blue">
                    </dx:ASPxLabel>
                    </td>
                <td colspan ="1">
                    <dx:ASPxTextBox ID="txtMinimumAmount" runat="server" Theme="Glass" Width="200px" Text="0">
                    </dx:ASPxTextBox>
                    </td>
                <td colspan ="1">
                    &nbsp;</td>
                <td colspan ="1">
                    &nbsp;</td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>

            </tr>
                <tr>
                    <td colspan ="1">
                        &nbsp;</td>

                    <td colspan="1">
                        <dx:ASPxButton ID="btnSave" runat="server" Text="Save" Theme="BlackGlass">
                        </dx:ASPxButton>
                        &nbsp;<dx:ASPxButton ID="btnSave0" runat="server" Text="Refresh" Theme="BlackGlass">
                        </dx:ASPxButton>
                    </td>
                    <td colspan="1">&nbsp;</td>
                    <td colspan="1">&nbsp;</td>
                    <td colspan="1">&nbsp;</td>
                    <td colspan="1">&nbsp;</td>
                    <td colspan="1">&nbsp;</td>
                    <td colspan="1">&nbsp;</td>

                </tr>
                <tr>
                    <td align="center" colspan="8">
                        <asp:Label ID="lblid" runat="server" Visible="False"></asp:Label>
                    </td>
            </tr>
                <tr>
                        <td colspan ="8" align="center">
                            <dx1:ASPxGridView ID="grdrules" runat="server" KeyFieldName="id" Settings-ShowTitlePanel="true" Theme="Glass" Width="100%">
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
                                    <dx1:GridViewDataColumn Caption="" VisibleIndex="0">
                                        <DataItemTemplate>
                                            <asp:LinkButton ID="deletetrans" runat="server" CommandArgument='<%# Eval("ID") %>' OnClientClick="if ( !confirm('Are you sure you want to delete ? ')) return false;" CommandName="Delete" Text="Delete">
                                                              </asp:LinkButton>
                                        </DataItemTemplate>
                                    </dx1:GridViewDataColumn>

                                       <dx1:GridViewDataColumn Caption="" VisibleIndex="0">
                                        <DataItemTemplate>
                                            <asp:LinkButton ID="edit" runat="server" CommandArgument='<%# Eval("ID") %>' CommandName="Edit" Text="Edit">
                                                              </asp:LinkButton>
                                        </DataItemTemplate>
                                    </dx1:GridViewDataColumn>

                                    <dx1:GridViewDataColumn Caption="Option">
                                        <DataItemTemplate>
                                            <dx1:aspxlabel runat="server" Text='<%# Eval("OptionName") %>'>
                                        </dx1:aspxlabel>
                                        </DataItemTemplate>
                                    </dx1:GridViewDataColumn>
                                    <dx1:GridViewDataColumn Caption="Interest Rate">
                                        <DataItemTemplate>
                                            <dx1:aspxlabel runat="server" Text='<%# Eval("InterestRate") %>'>
                                        </dx1:aspxlabel>
                                        </DataItemTemplate>
                                    </dx1:GridViewDataColumn>
                                    <dx1:GridViewDataColumn Caption="Interest Interval">
                                        <DataItemTemplate>
                                            <dx1:aspxlabel runat="server" Text='<%# Eval("Interest_Interval") %>'>
                                        </dx1:aspxlabel>
                                        </DataItemTemplate>
                                    </dx1:GridViewDataColumn>

                                      <dx1:GridViewDataColumn Caption="Service Charge">
                                        <DataItemTemplate>
                                            <dx1:aspxlabel runat="server" Text='<%# Eval("ServiceCharges") %>'>
                                        </dx1:aspxlabel>
                                        </DataItemTemplate>
                                    </dx1:GridViewDataColumn>

                                    <dx1:GridViewDataColumn Caption="Haircut (%)">
                                        <DataItemTemplate>
                                            <dx1:aspxlabel runat="server" Text='<%# Eval("Haircut") %>'>
                                        </dx1:aspxlabel>
                                        </DataItemTemplate>
                                    </dx1:GridViewDataColumn>
                                    <dx1:GridViewDataColumn Caption="Maximum Lending Period">
                                        <DataItemTemplate>
                                            <dx1:aspxlabel runat="server" Text='<%# Eval("LendingPeriod") %>'>
                                        </dx1:aspxlabel>
                                        </DataItemTemplate>
                                    </dx1:GridViewDataColumn>
                                    <dx1:GridViewDataColumn Caption="Minimum Amount">
                                        <DataItemTemplate>
                                            <dx1:aspxlabel runat="server" Text='<%# Eval("MiniAmount") %>'>
                                        </dx1:aspxlabel>
                                        </DataItemTemplate>
                                    </dx1:GridViewDataColumn>
                                    <dx1:GridViewDataColumn Caption="Maximum Amount">
                                        <DataItemTemplate>
                                            <dx1:aspxlabel runat="server" Text='<%# Eval("MaxiAmount") %>'>
                                        </dx1:aspxlabel>
                                        </DataItemTemplate>
                                    </dx1:GridViewDataColumn>
                                                                  </Columns>
                                <%-- W.EWR_Holder as [Account No], W.Company as [Details], W.ReceiptID AS [EWR No.], 
                                case when W.approvedby is NULL then 'Pending' else 'Approved' end as  [Status],  W.[Date],
                                 W.amount_to_withdraw ,wr.Commodity, wr.Grade, wr.WarehousePhysical, wr.Date_Issued, wr.[Status] --%>
                            </dx1:ASPxGridView>
                        </td>

                </tr>
                
                   <tr>
                        <td colspan ="1"></td>
                    <td colspan ="1"></td>
                    <td colspan ="1"></td>
                    <td colspan ="1"></td>
                    <td colspan ="1"></td>
                    <td colspan ="1"></td>
                    <td colspan ="1"></td>
                    <td colspan ="1"></td>

                </tr>
            </table>
            <table>
                <tr>
                    <td></td>
                </tr>
            </table>
 </asp:Panel>

             </asp:Panel>
            
            <table>
                <tr>
                    <td style="width: 850px" align="center">
                        </td>                
                </tr>
            </table>
        </td>
    </tr>

   
</table>
</asp:Panel>
</div>
</asp:Content>

