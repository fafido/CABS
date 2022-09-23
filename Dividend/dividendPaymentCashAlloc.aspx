<%@ Page Language="VB" MasterPageFile="~/CDSUser.master" AutoEventWireup="false" CodeFile="dividendPaymentCashAlloc.aspx.vb" Inherits="Corp_divPaymentAllocation" title="Dividend Payment" %>
        <table class="dxflInternalEditorTable_BlackGlass">
            <tr>
                <td style="width: 208px">
                    <dx:ASPxLabel ID="ASPxLabel3" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Select Asset Manager" Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                <td>
                    <dx:ASPxComboBox ID="cmbassetmanager" runat="server" Theme="Glass" Width="250px"  EnableCallbackMode="True" DropDownStyle="DropDownList"  IncrementalFilteringMode="Contains"  AnimationType="Slide" AutoPostBack="True">
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>
                    <dx:ASPxGridView ID="ASPxGridView5" runat="server" KeyFieldName="id" Settings-ShowTitlePanel="true" SettingsBehavior-AllowDragDrop="true" Theme="Glass" Width="100%">
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
                                    <asp:LinkButton ID="ActionID" runat="server" CommandArgument='<%# Eval("ID") %>' CommandName="Select" Text="Select">
                                                              </asp:LinkButton>
                                </DataItemTemplate>
                            </dx:GridViewDataColumn>
                            <dx:GridViewDataColumn Caption="Asset Manager" FieldName="AssetManager" />
                            <dx:GridViewDataColumn Caption="Bank Name" FieldName="BankName"  />
                            <dx:GridViewDataColumn Caption="Account No" FieldName="BankAccount" />
                            <dx:GridViewDataColumn Caption="Reference" FieldName="Reference" />
                            <dx:GridViewDataColumn Caption="Details" FieldName="Other_Details" />
                            <dx:GridViewDataColumn Caption="Date Received" FieldName="DateCreated"/>
                            <dx:GridViewDataColumn Caption="Received Via" FieldName="ReceivedVia" />
                            <dx:GridViewDataColumn Caption="Amount" FieldName="Amount" />
                        </Columns>
                    </dx:ASPxGridView>
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
             <tr>
                <td style="width: 208px">
                    <dx:ASPxLabel ID="ASPxLabel6" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Select Dividend Asset Manager" Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                <td>
                    <dx:ASPxComboBox ID="cmbDividendAssetManager" runat="server" Theme="Glass" Width="250px"  EnableCallbackMode="True" DropDownStyle="DropDownList"  IncrementalFilteringMode="Contains"  AnimationType="Slide" AutoPostBack="True">
                </td>
            </tr>
            <tr>
                <td style="height: 27px"></td>
                <td style="height: 27px">
                    <asp:Label ID="lblselected" runat="server" Visible="False"></asp:Label>
                </td>
                <td style="height: 27px"></td>
                <td style="height: 27px"></td>
            </tr>
        </table>
        </asp:Panel>
                <table>
                    <tr>
                        <td style="width: 208px">
                            <dx:ASPxLabel ID="ASPxLabel13" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Bank Name" Theme="Glass">
                            </dx:ASPxLabel>
                        </td>
                        <td  style="width: 212px">
                            <dx:ASPxTextBox ID="txtbankname" runat="server" ReadOnly="True" Theme="BlackGlass" Width="250px">
                            </dx:ASPxTextBox>
                        </td>
                        <td  style="width: 208px">
                            <dx:ASPxLabel ID="ASPxLabel14" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Bank Account" Theme="Glass">
                            </dx:ASPxLabel>
                        </td>
                        <td  style="width: 212px">
                            <dx:ASPxTextBox ID="txtaccountno" runat="server" ReadOnly="True" Theme="BlackGlass" Width="250px">
                            </dx:ASPxTextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 208px">
                            <dx:ASPxLabel ID="ASPxLabel9" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Deposit Amount" Theme="Glass">
                            </dx:ASPxLabel>
                        </td>
                        <td style="width: 212px">
                            <dx:ASPxTextBox ID="txtAmount" runat="server" Theme="BlackGlass" Width="250px">
                            </dx:ASPxTextBox>
                        </td>
                        <td style="width: 208px">
                            <dx:ASPxLabel ID="ASPxLabel11" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Description" Theme="Glass">
                            </dx:ASPxLabel>
                        </td>
                        <td style="width: 212px">
                            <dx:ASPxTextBox ID="txtdesc" ReadOnly="true" runat="server" Theme="BlackGlass" Width="250px">
                            </dx:ASPxTextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 208px">
                            <dx:ASPxLabel ID="ASPxLabel4" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Currency" Theme="Glass">
                            </dx:ASPxLabel>
                        </td>
                        <td style="width: 212px">
                            <dx:ASPxTextBox ID="txtcurrency2" runat="server" ReadOnly="True" Theme="BlackGlass" Width="250px">
                            </dx:ASPxTextBox>
                        </td>
                        <td style="width: 208px">
                            <dx:ASPxLabel ID="ASPxLabel41" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Avalibale Amount" Theme="Glass">
                            </dx:ASPxLabel>
                        </td>
                        <td style="width: 212px">
                            <dx:ASPxTextBox ID="lblCashBal" runat="server" Enabled ="false" ReadOnly="True" Theme="BlackGlass" Width="250px">
                            </dx:ASPxTextBox>
                        </td>
                    </tr>
        </table>
        </asp:Panel>