<%@ Page Language="VB" MasterPageFile="~/CDSUser.master" AutoEventWireup="false" CodeFile="BonusPostingAuth.aspx.vb" Inherits="Corp_BonusPostingAuth" title="Bonus Posting Authorization" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>

<asp:Content id="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Panel id="Panel1" runat="server" Width="90%" Font-Names="Cambria" BackColor="White" GroupingText="Bonus Posting Authorization">
       <table>
           <tr id="Tr1" runat="server">
                <td colspan="6">
                    <dx:ASPxLabel ID="ASPxLabel1" runat="server" Font-Names="Cambria" Font-Size="Small" Text="" Theme="Glass">
                    </dx:ASPxLabel>
                   <hr/>
                </td>
            </tr>
           <tr id="Panel13a" runat="server">
                <td style="width: 208px">
                    <dx:ASPxLabel ID="ASPxLabel30" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Company" Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                    <td style="width: 212px">
                       <dx:ASPxComboBox ID="cmbCompany" runat="server" Theme="Glass" Width="250px"  CallbackPageSize="15" EnableCallbackMode="True" DropDownStyle="DropDownList"  IncrementalFilteringMode="Contains"  AnimationType="Slide" AutoPostBack="True">
                            <Items>
                                <dx:ListEditItem Text="" Value="" /> 
                            </Items>
                        </dx:ASPxComboBox>
                    </td>
                   <td style="width: 212px"></td>
                   <td style="width: 212px"></td>
                    <td style="width: 212px"></td>
                    <td style="width: 212px"></td>
           </tr>
           
           <tr id="Tr5" runat="server">
                    <td style="width: 208px">
                        <dx:ASPxLabel ID="ASPxLabel72d" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Bonus Issue" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td style="width: 212px">
                        <dx:ASPxComboBox ID="cmbIssueNo" runat="server" Theme="Glass" Width="250px"  CallbackPageSize="15" EnableCallbackMode="True" DropDownStyle="DropDownList"  IncrementalFilteringMode="Contains"  AnimationType="Slide" AutoPostBack="True">
                            <Items>
                                <dx:ListEditItem Text="" Value="" /> 
                            </Items>
                        </dx:ASPxComboBox>
                    </td>
                  </tr>
           <tr id="Tr7" runat="server">
                    <td style="width: 208px">
                        <dx:ASPxLabel ID="ASPxLabel7" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Record Date" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td style="width: 212px">
                        <dx:ASPxTextBox ID="txtDateClose" runat="server" ReadOnly="true" BackColor="White" Theme="Glass" Width="250px">
                        </dx:ASPxTextBox>
                    </td>
                </tr>
           <tr id="Tr2" runat="server">
                    <td style="width: 208px">
                        <dx:ASPxLabel ID="ASPxLabel2" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Payment Date" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td style="width: 212px">
                        <dx:ASPxTextBox ID="txtPaymentDate" runat="server" ReadOnly="true" BackColor="White" Theme="Glass" Width="250px">
                        </dx:ASPxTextBox>
                    </td>
                </tr>
           <tr id="Tr3" runat="server" visible="false">
                <td style="width: 208px">
                    <dx:ASPxLabel ID="ASPxLabel3" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Narration" Theme="Glass">
                    </dx:ASPxLabel>
                </td>
               <td style="width: 212px">
                    <dx:ASPxTextBox ID="txtMsg1" ReadOnly="true" runat="server" BackColor="White" Theme="Glass" Width="250px">
                        </dx:ASPxTextBox>
               </td>
            </tr>
           <tr id="Tr10" runat="server">
                    <td style="width: 208px">
                        <dx:ASPxLabel ID="ASPxLabel12" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Round" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td style="width: 212px">
                    <dx:ASPxTextBox ID="txtRound" ReadOnly="true" runat="server" BackColor="White" Theme="Glass" Width="250px">
                        </dx:ASPxTextBox>
                    </td>
                </tr>
           <tr id="divSpecie1" runat="server">
                <td style="width: 208px">
                    <dx:ASPxLabel ID="ASPxLabel13" runat="server" Font-Names="Cambria" Font-Size="Small" Text="New" Theme="Glass">
                    </dx:ASPxLabel>
                </td>
               <td style="width: 212px">
                    <dx:ASPxTextBox ID="txtSpecieShares" ReadOnly="true" runat="server" BackColor="White" Theme="Glass" Width="250px">
                        </dx:ASPxTextBox>
               </td>
            </tr>
           <tr id="divSpecie2" runat="server">
                <td style="width: 208px">
                    <dx:ASPxLabel ID="ASPxLabel19" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Existing" Theme="Glass">
                    </dx:ASPxLabel>
                </td>
               <td style="width: 212px">
                    <dx:ASPxTextBox ID="txtForEvery" ReadOnly="true" runat="server" BackColor="White" Theme="Glass" Width="250px">
                        </dx:ASPxTextBox>
               </td>
            </tr>
           
           <tr id="Tr12" runat="server">
                <td style="width: 208px">
                  <asp:CheckBox ID="chkSelectAll" runat="server" Text="Select All" Font-Size="Small" Font-Names="Cambria" AutoPostBack ="true"/>
                </td>
                <td style="width: 212px">
                    <dx:ASPxButton ID="btnCalc" runat="server" Text="Calc Total >>" Theme="Glass">
                            </dx:ASPxButton>
                </td>
                <td colspan="3">
                    <dx:ASPxLabel ID="lblTotalCashSelected" runat="server" Font-Names="Cambria" Font-Size="Small" Font-Bold="true" Text="" Theme="Glass">
                    </dx:ASPxLabel>
                </td>
           </tr>
           <tr id="Tr4" runat="server">
                <td colspan="6">
                    <dx:ASPxLabel ID="ASPxLabel4" runat="server" Font-Names="Cambria" Font-Size="Small" Text="" Theme="Glass">
                    </dx:ASPxLabel>
                   <hr/>
                </td>
            </tr>
           <tr id="Tr11a" runat="server">
                <td colspan="6">
                    <dx:ASPxGridView ID="grdPaymentsBonus" Width="100%" runat="server" KeyFieldName="ID" Settings-ShowTitlePanel="true" Theme="Glass" Visible="false">
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
                            <Settings ShowFilterRow="true"/>
                            <Columns>
                                  <dx:GridViewDataColumn Caption="Select" FieldName="Selec"  VisibleIndex="0">
                                    <DataItemTemplate>
                                        <dx:aspxcheckbox ID="chk1" runat="server" >
                                                              </dx:aspxcheckbox>
                                    </DataItemTemplate>
                                </dx:GridViewDataColumn>
                                <dx:GridViewDataColumn FieldName="Shareholder" Caption="Holder No." Settings-AutoFilterCondition="Contains">
                                    <DataItemTemplate>
                                        <dx:ASPxLabel ID="lblshareholder" runat="server" Text='<%# Eval("Shareholder") %>'>
                                        </dx:ASPxLabel>
                                    </DataItemTemplate>
                                </dx:GridViewDataColumn>
                                <dx:GridViewDataColumn Caption="Names" FieldName="Holder" Settings-AutoFilterCondition="Contains">
                                    <DataItemTemplate>
                                        <dx:ASPxLabel runat="server" Text='<%# Eval("Holder") %>'>
                                        </dx:ASPxLabel>
                                    </DataItemTemplate>
                                </dx:GridViewDataColumn>
                                <dx:GridViewDataColumn FieldName="AssetManager" Caption="Asset Manager" Settings-AutoFilterCondition="Contains">
                                    <DataItemTemplate>
                                        <dx:ASPxLabel ID="lblAssetManager" runat="server" Text='<%# Eval("AssetManager") %>'>
                                        </dx:ASPxLabel>
                                    </DataItemTemplate>
                                </dx:GridViewDataColumn>
                                <dx:GridViewDataColumn Caption="Shares_held">
                                    <DataItemTemplate>
                                        <dx:ASPxLabel runat="server" Text='<%# Eval("Shares_held") %>'>
                                        </dx:ASPxLabel>
                                    </DataItemTemplate>
                                </dx:GridViewDataColumn>
                                <dx:GridViewDataColumn Caption="Total Bonus Shares">
                                    <DataItemTemplate>
                                        <dx:ASPxLabel runat="server" Text='<%# Eval("Scaled_Shares") %>'>
                                        </dx:ASPxLabel>
                                    </DataItemTemplate>
                                </dx:GridViewDataColumn>
                                <dx:GridViewDataColumn FieldName="Sharesc" Caption="Post Bonus Shares">
                                    <DataItemTemplate>
                                        <dx:ASPxLabel ID="lblShares" runat="server" Text='<%# Eval("PaidShares") %>'>
                                        </dx:ASPxLabel>
                                    </DataItemTemplate>
                                </dx:GridViewDataColumn>
                                <dx:GridViewDataColumn FieldName="PaymentTypec" Caption="Narration">
                                    <DataItemTemplate>
                                        <dx:ASPxLabel ID="lblPaymentType" runat="server" Text='<%# Eval("PaymentType") %>'>
                                        </dx:ASPxLabel>
                                    </DataItemTemplate>
                                </dx:GridViewDataColumn>
                            </Columns>
                        </dx:ASPxGridView>
                </td>
            </tr>
           <tr id="Tr11" runat="server">
                <td colspan="6">
                    <dx:ASPxLabel ID="ASPxLabel26" runat="server" Font-Names="Cambria" Font-Size="Small" Text="" Theme="Glass">
                    </dx:ASPxLabel>
                   <hr/>
                </td>
            </tr>
           
           <tr id="PanelSAVE1" runat="server" visible="false">
                    <td style="width:208px"></td>
                        <td colspan="3">
                            <asp:RadioButtonList ID="RadioButtonList1" RepeatDirection="Horizontal" Font-Size="Small" Font-Names="Cambria" runat="server">
                                <asp:ListItem Text="Authorize" Value="Authorize"></asp:ListItem>
                                <asp:ListItem Text="Reject" Value="Reject"></asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                    </tr>
           <tr id="PanelSAVE" runat="server" visible="false">
                        <td style="width:208px"></td>
                        <td style="width:212px">
                            &nbsp;<dx:ASPxButton ID="btnPost" runat="server" Text="Authorize Payments" Theme="Glass">
                            </dx:ASPxButton>
                        </td>
                </tr>
        </table> 
      </asp:Panel>
</asp:Content>

