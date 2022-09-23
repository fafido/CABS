<%@ Page Language="VB" MasterPageFile="~/CDSUser.master" AutoEventWireup="false" CodeFile="RightsPosting.aspx.vb" Inherits="Corp_RightsFinalPosting" title="Rights Posting" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>

<asp:Content id="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Panel id="Panel1" runat="server" Width="90%" Font-Names="Cambria" BackColor="White" GroupingText="Rights Posting">
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
                        <dx:ASPxLabel ID="ASPxLabel72d" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Issue No." Theme="Glass">
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
           <tr id="Panel8i" runat="server">
                    <td style="width: 208px">
                        <dx:ASPxLabel ID="ASPxLabel714" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Price per share" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td style="width: 212px">
                        <dx:ASPxTextBox ID="txtRate" ReadOnly="true" runat="server" BackColor="White" Theme="Glass" Width="250px">
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
           <tr id="Tr6" runat="server">
                <td style="width: 208px">
                    <dx:ASPxLabel ID="ASPxLabel5" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Currency" Theme="Glass">
                    </dx:ASPxLabel>
                </td>
               <td style="width: 212px">
                    <dx:ASPxTextBox ID="txtCurrency" ReadOnly="true" runat="server" BackColor="White" Theme="Glass" Width="250px">
                        </dx:ASPxTextBox>
               </td>
            </tr>
           <tr id="Tr4" runat="server">
                <td colspan="6">
                    <dx:ASPxLabel ID="ASPxLabel4" runat="server" Font-Names="Cambria" Font-Size="Small" Text="TransFer Sec. Bank Details" Theme="Glass">
                    </dx:ASPxLabel>
                   <hr/>
                </td>
            </tr>
           <tr id="divSpecie2a" runat="server">
                <td style="width: 208px">
                    <dx:ASPxLabel ID="ASPxLabel19a" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Bank" Theme="Glass">
                    </dx:ASPxLabel>
                </td>
               <td style="width: 212px">
                    <dx:ASPxTextBox ID="txtBank" ReadOnly="true" runat="server" BackColor="White" Theme="Glass" Width="250px">
                        </dx:ASPxTextBox>
               </td>
            </tr>
           <tr id="divSpecie2b" runat="server">
                <td style="width: 208px">
                    <dx:ASPxLabel ID="ASPxLabel19b" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Branch" Theme="Glass">
                    </dx:ASPxLabel>
                </td>
               <td style="width: 212px">
                    <dx:ASPxTextBox ID="txtBranch" ReadOnly="true" runat="server" BackColor="White" Theme="Glass" Width="250px">
                        </dx:ASPxTextBox>
               </td>
            </tr>
           <tr id="divSpecie2c" runat="server">
                <td style="width: 208px">
                    <dx:ASPxLabel ID="ASPxLabel19c" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Account No." Theme="Glass">
                    </dx:ASPxLabel>
                </td>
               <td style="width: 212px">
                    <dx:ASPxTextBox ID="txtAccountNo" ReadOnly="true" runat="server" BackColor="White" Theme="Glass" Width="250px">
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
           <tr id="Tr11a" runat="server">
                <td colspan="6">
                    <dx:ASPxGridView ID="grdPaymentsRights" Width="100%" runat="server" KeyFieldName="RightsId" Settings-ShowTitlePanel="true" Theme="Glass" Visible="false">                            <SettingsBehavior AllowSelectByRowClick="True" AllowSelectSingleRowOnly="True" ProcessSelectionChangedOnServer="True" />                            <SettingsPager PageSizeItemSettings-ShowAllItem="true" Visible="True">                            </SettingsPager>                            <SettingsPopup>                                <EditForm AllowResize="True" Modal="True" />                            </SettingsPopup>                            <SettingsCommandButton>                                <SelectButton Text="Select">                                </SelectButton>                            </SettingsCommandButton>                        <Settings ShowFilterRow="true"/>                            <Columns>                                  <dx:GridViewDataColumn Caption="Select" FieldName="Selec"  VisibleIndex="0">                                    <DataItemTemplate>                                        <dx:aspxcheckbox ID="chk1" runat="server" >                                                              </dx:aspxcheckbox>                                    </DataItemTemplate>                                </dx:GridViewDataColumn>                                <dx:GridViewDataColumn FieldName="Origin" Caption="Holder No." Settings-AutoFilterCondition="Contains">                                    <DataItemTemplate>                                        <dx:ASPxLabel ID="lblshareholder" runat="server" Text='<%# Eval("Origin") %>'>                                        </dx:ASPxLabel>                                    </DataItemTemplate>                                </dx:GridViewDataColumn>                                <dx:GridViewDataColumn Caption="Names" FieldName="holder" Settings-AutoFilterCondition="Contains">                                    <DataItemTemplate>                                        <dx:ASPxLabel runat="server" Text='<%# Eval("Holder") %>'>                                        </dx:ASPxLabel>                                    </DataItemTemplate>                                </dx:GridViewDataColumn>                                <dx:GridViewDataColumn FieldName="AssetManager" Caption="Asset Manager" Settings-AutoFilterCondition="Contains">                                    <DataItemTemplate>                                        <dx:ASPxLabel ID="lblAssetManager" runat="server" Text='<%# Eval("AssetManager") %>'>                                        </dx:ASPxLabel>                                    </DataItemTemplate>                                </dx:GridViewDataColumn>                                <dx:GridViewDataColumn Caption="Shares held">                                    <DataItemTemplate>                                        <dx:ASPxLabel runat="server" Text='<%# Eval("Shares") %>'>                                        </dx:ASPxLabel>                                    </DataItemTemplate>                                </dx:GridViewDataColumn>                                <dx:GridViewDataColumn Caption="Offered Rights">                                    <DataItemTemplate>                                        <dx:ASPxLabel runat="server" Text='<%# Eval("Rights") %>'>                                        </dx:ASPxLabel>                                    </DataItemTemplate>                                </dx:GridViewDataColumn>                                <dx:GridViewDataColumn FieldName="AcceptedRightsc" Caption="Accepted Rights">                                    <DataItemTemplate>                                        <dx:ASPxLabel runat="server" ID="lblAcceptedRights" Text='<%# Eval("AcceptedRights") %>'>                                        </dx:ASPxLabel>                                    </DataItemTemplate>                                </dx:GridViewDataColumn>                                <dx:GridViewDataColumn Caption="Cost">                                    <DataItemTemplate>                                        <dx:ASPxLabel runat="server" Text='<%# Eval("AcceptedCost") %>'>                                        </dx:ASPxLabel>                                    </DataItemTemplate>                                </dx:GridViewDataColumn>                                <dx:GridViewDataColumn FieldName="AmountPaidc" Caption="Amount Paid">                                    <DataItemTemplate>                                        <dx:ASPxLabel ID="lblAmountPaid" runat="server" Text='<%# Eval("AmountPaid") %>'>                                        </dx:ASPxLabel>                                    </DataItemTemplate>                                </dx:GridViewDataColumn>                                <dx:GridViewDataColumn Caption="Bank">                                    <DataItemTemplate>                                        <dx:ASPxLabel runat="server" Text='<%# Eval("Bank") %>'>                                        </dx:ASPxLabel>                                    </DataItemTemplate>                                </dx:GridViewDataColumn>                                <dx:GridViewDataColumn Caption="Branch">                                    <DataItemTemplate>                                        <dx:ASPxLabel ID="lblBankBranch" runat="server" Text='<%# Eval("BankBranch") %>'>                                        </dx:ASPxLabel>                                    </DataItemTemplate>                                </dx:GridViewDataColumn>                                <dx:GridViewDataColumn Caption="A/c Number">                                    <DataItemTemplate>                                        <dx:ASPxLabel ID="lblBankAccount" runat="server" Text='<%# Eval("BankAccount") %>'>                                        </dx:ASPxLabel>                                    </DataItemTemplate>                                </dx:GridViewDataColumn>                                <dx:GridViewDataColumn FieldName="RemainingSharesc" Caption="Remaining Rights">                                    <DataItemTemplate>                                        <dx:ASPxLabel ID="lblRemainingShares" runat="server" Text='<%# Eval("RemainingShares") %>'>                                        </dx:ASPxLabel>                                    </DataItemTemplate>                                </dx:GridViewDataColumn>                                <dx:GridViewDataColumn FieldName="SharesToPayc" Caption="Rights to Post">                                    <DataItemTemplate>                                        <dx:ASPxTextBox ID="txtSharesToPay" Width="100px" Text='<%# Eval("RemainingShares") %>' runat="server" BackColor="White" Theme="Glass">
                                            </dx:ASPxTextBox>                                    </DataItemTemplate>                                </dx:GridViewDataColumn>                                <dx:GridViewDataColumn FieldName="SharesWriteoffc" Caption="Write-off Rights">                                    <DataItemTemplate>                                        <dx:ASPxTextBox ID="txtSharesWriteoff" Width="100px" Text="0" runat="server" BackColor="White" Theme="Glass">
                                            </dx:ASPxTextBox>                                    </DataItemTemplate>                                </dx:GridViewDataColumn>                            </Columns>                        </dx:ASPxGridView>
                </td>
            </tr>
           <tr id="Tr11" runat="server">
                <td colspan="6">
                    <dx:ASPxLabel ID="ASPxLabel26" runat="server" Font-Names="Cambria" Font-Size="Small" Text="" Theme="Glass">
                    </dx:ASPxLabel>
                   <hr/>
                </td>
            </tr>
           <tr id="PanelSAVE" runat="server" visible="false">
                        <td style="width:208px"></td>
                        <td style="width:212px">
                            &nbsp;<dx:ASPxButton ID="btnPost" runat="server" Text="Final Authorization" Theme="Glass">
                            </dx:ASPxButton>
                        </td>
                </tr>
        </table> 
      </asp:Panel>
</asp:Content>

