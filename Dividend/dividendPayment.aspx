<%@ Page Language="VB" MasterPageFile="~/CDSUser.master" AutoEventWireup="false" CodeFile="dividendPayment.aspx.vb" Inherits="Corp_divPayment" title="Dividend Payment" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>

<asp:Content id="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
   <%-- <script
      src="https://code.jquery.com/jquery-3.2.1.js"
      integrity="sha256-DZAnKJ/6XZ9si04Hgrsxu/8s717jcIzLy3oi35EouyE="
      crossorigin="anonymous">
      </script>--%>
         <script src="../Scripts/jquery.min.js"></script>
    <script src="../Scripts/jquery.quicksearch.js"></script>
    <script type="text/javascript">
    $(function () {
        $('input#txtSearch').quicksearch('table#grdPaymantsSpecie tbody');
    });
</script>
    <asp:Panel id="Panel1" runat="server" Width="90%" Font-Names="Cambria" BackColor="White" GroupingText="Dividend Payment">
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
                        <dx:ASPxLabel ID="ASPxLabel72d" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Dividend No." Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td style="width: 212px">
                        <dx:ASPxComboBox ID="cmbDivNo" runat="server" Theme="Glass" Width="250px"  CallbackPageSize="15" EnableCallbackMode="True" DropDownStyle="DropDownList"  IncrementalFilteringMode="Contains"  AnimationType="Slide" AutoPostBack="True">
                            <Items>
                                <dx:ListEditItem Text="" Value="" /> 
                            </Items>
                        </dx:ASPxComboBox>
                    </td>
                  </tr>
           
           
            <tr id="Panel8e" runat="server">
                    <td style="width: 208px">
                        <dx:ASPxLabel ID="ASPxLabel5" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Dividend Type" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td style="width: 212px">
                        <dx:ASPxTextBox ID="txtDividendType" runat="server" ReadOnly="true" BackColor="White" Theme="Glass" Width="250px">
                        </dx:ASPxTextBox>
                    </td>
                </tr>
           <tr id="Tr6" runat="server">
                    <td style="width: 208px">
                        <dx:ASPxLabel ID="ASPxLabel2" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Event Type" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td style="width: 212px">
                        <dx:ASPxTextBox ID="txtEventType" runat="server" ReadOnly="true" BackColor="White" Theme="Glass" Width="250px">
                        </dx:ASPxTextBox>
                    </td>
                </tr>
           <tr id="Panel8b" runat="server">
                    <td style="width: 208px">
                        <dx:ASPxLabel ID="ASPxLabel29" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Date Announced" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td style="width: 212px">
                        <dx:ASPxTextBox ID="txtDateCreated" runat="server" ReadOnly="true" BackColor="White" Theme="Glass" Width="250px">
                        </dx:ASPxTextBox>
                    </td>
                </tr>
           <tr id="Tr7" runat="server">
                    <td style="width: 208px">
                        <dx:ASPxLabel ID="ASPxLabel7" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Record Date (LDR)" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td style="width: 212px">
                        <dx:ASPxTextBox ID="txtDateClose" runat="server" ReadOnly="true" BackColor="White" Theme="Glass" Width="250px">
                        </dx:ASPxTextBox>
                    </td>
                </tr>
           <tr id="Tr8" runat="server">
                    <td style="width: 208px">
                        <dx:ASPxLabel ID="ASPxLabel15" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Payment Date" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td style="width: 212px">
                        <dx:ASPxTextBox ID="txtPaymentdate" runat="server" ReadOnly="true" BackColor="White" Theme="Glass" Width="250px">
                        </dx:ASPxTextBox>
                    </td>
                </tr>
           <tr id="Tr9" runat="server">
                    <td style="width: 208px">
                        <dx:ASPxLabel ID="ASPxLabel17" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Year Ended/Ending" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td style="width: 212px">
                        <dx:ASPxTextBox ID="txtYearEnding" runat="server" ReadOnly="true" BackColor="White" Theme="Glass" Width="250px">
                        </dx:ASPxTextBox>
                    </td>
                </tr>
           <tr id="Panel8i" runat="server">
                    <td style="width: 208px">
                        <dx:ASPxLabel ID="ASPxLabel714" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Dividend Rate" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td style="width: 212px">
                        <dx:ASPxTextBox ID="txtRate" ReadOnly="true" runat="server" BackColor="White" Theme="Glass" Width="250px">
                        </dx:ASPxTextBox>
                    </td>
                </tr>
           <tr id="Panel0a" runat="server" visible="false">
                <td  style="width: 208px">
                    <dx:ASPxLabel ID="ASPxLabel110" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Bank Account No." Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                <td style="width: 212px">
                        <dx:ASPxTextBox ID="txtBankAccount" ReadOnly="true" runat="server" BackColor="White" Theme="Glass" Width="250px">
                        </dx:ASPxTextBox>
                </td>
            </tr>
           <tr id="Tr2" runat="server">
                    <td style="width: 208px">
                        <dx:ASPxLabel ID="ASPxLabel24" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Tax Rate" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td style="width: 212px">
                        <dx:ASPxTextBox ID="txtTaxRate" ReadOnly="true" runat="server" BackColor="White" Theme="Glass" Width="250px">
                        </dx:ASPxTextBox>
                    </td>
                </tr>
           <tr id="Tr4" runat="server" visible="false">
                <td style="width: 208px">
                    <dx:ASPxLabel ID="ASPxLabel31" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Tax Bank Acc." Theme="Glass">
                    </dx:ASPxLabel>
                </td>
               <td style="width: 212px">
                    <dx:ASPxTextBox ID="txtTaxAccount" ReadOnly="true" runat="server" BackColor="White" Theme="Glass" Width="250px">
                        </dx:ASPxTextBox>
               </td>
            </tr>
           <tr id="Tr3" runat="server" visible="false">
                <td style="width: 208px">
                    <dx:ASPxLabel ID="ASPxLabel3" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Payment Narration" Theme="Glass">
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
           <tr id="divSpecie1" visible="false" runat="server">
                <td style="width: 208px">
                    <dx:ASPxLabel ID="ASPxLabel13" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Specie Shares" Theme="Glass">
                    </dx:ASPxLabel>
                </td>
               <td style="width: 212px">
                    <dx:ASPxTextBox ID="txtSpecieShares" ReadOnly="true" runat="server" BackColor="White" Theme="Glass" Width="250px">
                        </dx:ASPxTextBox>
               </td>
            </tr>
           <tr id="divSpecie2" runat="server" visible="false">
                <td style="width: 208px">
                    <dx:ASPxLabel ID="ASPxLabel19" runat="server" Font-Names="Cambria" Font-Size="Small" Text="For Every" Theme="Glass">
                    </dx:ASPxLabel>
                </td>
               <td style="width: 212px">
                    <dx:ASPxTextBox ID="txtForEvery" ReadOnly="true" runat="server" BackColor="White" Theme="Glass" Width="250px">
                        </dx:ASPxTextBox>
               </td>
            </tr>
           <tr id="divSpecie3" runat="server" visible="false">
                    <td style="width: 208px">
                        <dx:ASPxLabel ID="ASPxLabel21" runat="server" Font-Names="Cambria" Font-Size="Small" Text="New Company" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td style="width: 212px">
                    <dx:ASPxTextBox ID="txtSpecieNewCompany" ReadOnly="true" runat="server" BackColor="White" Theme="Glass" Width="250px">
                        </dx:ASPxTextBox>
                    </td>
                </tr>
           <tr id="divScrip1" runat="server" visible="false">
                <td style="width: 208px">
                    <dx:ASPxLabel ID="ASPxLabel22" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Scrip price" Theme="Glass">
                    </dx:ASPxLabel>
                </td>
               <td style="width: 212px">
                    <dx:ASPxTextBox ID="txtScriptPrice" ReadOnly="true" runat="server" BackColor="White" Theme="Glass" Width="250px">
                        </dx:ASPxTextBox>
               </td>
            </tr>
           <tr id="divCashScrip" runat="server" visible="false"> 
                    <td style="width: 208px">
                        <dx:ASPxLabel ID="ASPxLabel36" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Currency" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td style="width: 212px">
                    <dx:ASPxTextBox ID="txtCurrency" ReadOnly="true" runat="server" BackColor="White" Theme="Glass" Width="250px">
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
                <td colspan="2">
                    <dx:ASPxLabel ID="lblTotalCashSelected" runat="server" Font-Names="Cambria" Font-Size="Small" Font-Bold="true" Text="" Theme="Glass">
                    </dx:ASPxLabel>
                </td>
           </tr>
           <tr id="Tr13" runat="server">
                    <td style="width: 208px">
                        <dx:ASPxLabel ID="ASPxLabel4" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Search" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td style="width: 212px">
                         <input type="text" name="search" value="" id="txtSearch" style="width:250px;" autocomplete="off" placeholder="" />
                    </td>
           </tr>
           <tr id="Tr11a" runat="server">
                <td colspan="6">
                         <dx:ASPxGridView ID="grdPaymantsSpecie" Width="100%" runat="server" SettingsPager-Mode="ShowAllRecords" KeyFieldName="SEQ" Settings-ShowTitlePanel="true" Theme="Glass" Visible="false">
                            <SettingsBehavior AllowSelectByRowClick="false" AllowSelectSingleRowOnly="false" ProcessSelectionChangedOnServer="false" />
                            <SettingsPager PageSizeItemSettings-ShowAllItem="true" Visible="True">
                            </SettingsPager>
                             <SettingsBehavior AllowSort="false" AllowGroup="false" />
                            <SettingsPopup>
                                <EditForm AllowResize="True" Modal="True" />
                            </SettingsPopup>
                            <SettingsCommandButton>
                                <SelectButton Text="Select">
                                </SelectButton>
                            </SettingsCommandButton>
                            <Settings ShowFilterRow="false"/><SettingsPager Visible="false"></SettingsPager>
                            <Columns>
                                  <dx:GridViewDataColumn Caption="Select" FieldName="Selec"  VisibleIndex="0">
                                    <DataItemTemplate>
                                        <dx:aspxcheckbox ID="chk1" Checked="false" Enabled="true" runat="server" >
                                                              </dx:aspxcheckbox>
                                    </DataItemTemplate>
                                </dx:GridViewDataColumn>
                                <dx:GridViewDataColumn FieldName="shareholder" Caption="Holder No." Settings-AutoFilterCondition="Contains">
                                    <DataItemTemplate>
                                        <dx:ASPxLabel ID="lblshareholder" runat="server" Text='<%# Eval("shareholder") %>'>
                                        </dx:ASPxLabel>
                                    </DataItemTemplate>
                                </dx:GridViewDataColumn>
                                <dx:GridViewDataColumn Caption="Names" FieldName="holder" Settings-AutoFilterCondition="Contains">
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
                                <dx:GridViewDataColumn Caption="Gross">
                                    <DataItemTemplate>
                                        <dx:ASPxLabel runat="server" Text='<%# Eval("SpecieGross") %>'>
                                        </dx:ASPxLabel>
                                    </DataItemTemplate>
                                </dx:GridViewDataColumn>
                                <dx:GridViewDataColumn Caption="Tax">
                                    <DataItemTemplate>
                                        <dx:ASPxLabel runat="server" Text='<%# Eval("SpecieTax") %>'>
                                        </dx:ASPxLabel>
                                    </DataItemTemplate>
                                </dx:GridViewDataColumn>
                                <dx:GridViewDataColumn Caption="New Shares">
                                    <DataItemTemplate>
                                        <dx:ASPxLabel runat="server" Text='<%# Eval("DivSpecieShares") %>'>
                                        </dx:ASPxLabel>
                                    </DataItemTemplate>
                                </dx:GridViewDataColumn>
                                <dx:GridViewDataColumn FieldName="RemainingSharesc" Caption="Remaining Shares">
                                    <DataItemTemplate>
                                        <dx:ASPxLabel ID="lblRemainingShares" runat="server" Text='<%# Eval("RemainingShares") %>'>
                                        </dx:ASPxLabel>
                                    </DataItemTemplate>
                                </dx:GridViewDataColumn>
                                <dx:GridViewDataColumn FieldName="SharesToPayc" Caption="Specie Shares to Post">
                                    <DataItemTemplate>
                                        <dx:ASPxTextBox ID="txtSharesToPay" Width="100px" Text='<%# Eval("RemainingShares") %>' runat="server" BackColor="White" Theme="Glass">
                                            </dx:ASPxTextBox>
                                    </DataItemTemplate>
                                </dx:GridViewDataColumn>
                                <dx:GridViewDataColumn FieldName="SharesWriteoffc" Caption="Write-off Shares">
                                    <DataItemTemplate>
                                        <dx:ASPxTextBox ID="txtSharesWriteoff" Width="100px" Text="0" runat="server" BackColor="White" Theme="Glass">
                                            </dx:ASPxTextBox>
                                    </DataItemTemplate>
                                </dx:GridViewDataColumn>
                            </Columns>
                        </dx:ASPxGridView>
                         <dx:ASPxGridView ID="grdPaymentsScrip" Width="100%" runat="server" KeyFieldName="SEQ" Settings-ShowTitlePanel="true" Theme="Glass" Visible="false">
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
                                        <dx:aspxcheckbox ID="chk1" Checked="false" Enabled="true" runat="server" >
                                                              </dx:aspxcheckbox>
                                    </DataItemTemplate>
                                </dx:GridViewDataColumn>
                                <dx:GridViewDataColumn FieldName="Shareholder" Caption="Holder No." Settings-AutoFilterCondition="Contains">
                                    <DataItemTemplate>
                                        <dx:ASPxLabel ID="lblShareholder" runat="server" Text='<%# Eval("shareholder") %>'>
                                        </dx:ASPxLabel>
                                    </DataItemTemplate>
                                </dx:GridViewDataColumn>
                                <dx:GridViewDataColumn Caption="Names" FieldName="holder" Settings-AutoFilterCondition="Contains">
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
                                <dx:GridViewDataColumn Caption="Gross">
                                    <DataItemTemplate>
                                        <dx:ASPxLabel runat="server" Text='<%# Eval("SpecieGross") %>'>
                                        </dx:ASPxLabel>
                                    </DataItemTemplate>
                                </dx:GridViewDataColumn>
                                <dx:GridViewDataColumn Caption="Tax">
                                    <DataItemTemplate>
                                        <dx:ASPxLabel runat="server" Text='<%# Eval("SpecieTax") %>'>
                                        </dx:ASPxLabel>
                                    </DataItemTemplate>
                                </dx:GridViewDataColumn>
                                <dx:GridViewDataColumn Caption="Scrip Shares">
                                    <DataItemTemplate>
                                        <dx:ASPxLabel runat="server" Text='<%# Eval("DivSpecieShares") %>'>
                                        </dx:ASPxLabel>
                                    </DataItemTemplate>
                                </dx:GridViewDataColumn>
                                <dx:GridViewDataColumn FieldName="RemainingSharesc" Caption="Remaining Shares">
                                    <DataItemTemplate>
                                        <dx:ASPxLabel ID="lblRemainingShares" runat="server" Text='<%# Eval("RemainingShares") %>'>
                                        </dx:ASPxLabel>
                                    </DataItemTemplate>
                                </dx:GridViewDataColumn>
                                <dx:GridViewDataColumn FieldName="SharesToPayc" Caption="Scrip Shares to Post">
                                    <DataItemTemplate>
                                        <dx:ASPxTextBox ID="txtSharesToPay" Width="100px" Text='<%# Eval("RemainingShares") %>' runat="server" BackColor="White" Theme="Glass">
                                            </dx:ASPxTextBox>
                                    </DataItemTemplate>
                                </dx:GridViewDataColumn>
                                <dx:GridViewDataColumn FieldName="SharesWriteoffc" Caption="Write-off Shares">
                                    <DataItemTemplate>
                                        <dx:ASPxTextBox ID="txtSharesWriteoff" Width="100px" Text="0" runat="server" BackColor="White" Theme="Glass">
                                            </dx:ASPxTextBox>
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
           <tr id="PanelSAVE" runat="server" visible="false">
                        <td style="width:208px"></td>
                        <td style="width:212px">
                            &nbsp;<dx:ASPxButton ID="btnPost" runat="server" Text="Post Payments" Theme="Glass">
                            </dx:ASPxButton>
                        </td>
                </tr>
           <tr id="Tr14" runat="server">
                <td colspan="6">
                    <dx:ASPxLabel ID="ASPxLabel6" runat="server" Font-Names="Cambria" Font-Size="Small" Text="" Theme="Glass">
                    </dx:ASPxLabel>
                   <hr/>
                </td>
            </tr>
        </table> 
      </asp:Panel>
</asp:Content>

