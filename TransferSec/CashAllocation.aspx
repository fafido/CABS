<%@ Page Language="VB" MasterPageFile="~/CDSUser.master" AutoEventWireup="false" CodeFile="CashAllocation.aspx.vb" Inherits="Enquiries_CashAllocation" title="Cash Allocation" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<asp:Content id="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
    <asp:Panel id="Panel1" runat="server" Width="100%" Font-Names="Arial" Font-Size="Medium" BackColor="White">
    
        <table width ="100%">
            <tr>
                   <td style ="text-align :left;" align="left">
                       <dx:ASPxLabel ID="ASPxLabel1" runat="server" Text="Cash Management&gt;&gt;Cash Allocation" Font-Names="Cambria" Font-Size="Small" Theme="PlasticBlue"></dx:ASPxLabel>

                   </td>
            </tr>
        </table>

   <asp:panel id="pnlfirst" runat="server" GroupingText="Un-Allocated Funds" Font-Names="Cambria">
        <table class="dxflInternalEditorTable_BlackGlass">
            <tr>
                <td style="width: 160px">
                    <dx:ASPxLabel ID="ASPxLabel12" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Select Asset Manager" Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                <td>
                    <dx:ASPxComboBox ID="cmbassetmanager" runat="server" AutoPostBack="true" Theme="Glass"  Width="250px" IncrementalFilteringMode="StartsWith" DropDownstyle="DropDown" >
                      
                    </dx:ASPxComboBox>
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td style="width: 160px">
                    <dx:ASPxLabel ID="ASPxLabel16" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Select Account" Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                <td>
                    <dx:ASPxComboBox ID="cmbaccount" runat="server" DropDownstyle="DropDown" IncrementalFilteringMode="StartsWith" Theme="Glass" Width="250px">
                    </dx:ASPxComboBox>
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td style="width: 160px">&nbsp;</td>
                <td>
                    <dx:ASPxButton ID="ASPxButton4" CausesValidation="false" runat="server" Text="View" Theme="BlackGlass" Width="70px">
                    </dx:ASPxButton>
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
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
                                <dx:GridViewDataColumn Caption="Select" FieldName="Selec"  VisibleIndex="0">
                                    <DataItemTemplate>
                                        <dx:aspxcheckbox ID="chk1" runat="server" >
                                                              </dx:aspxcheckbox>
                                    </DataItemTemplate>
                                </dx:GridViewDataColumn>
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
                        <%-- W.EWR_Holder as [Account No], W.Company as [Details], W.ReceiptID AS [EWR No.], 
                                case when W.approvedby is NULL then 'Pending' else 'Approved' end as  [Status],  W.[Date],
                                 W.amount_to_withdraw ,wr.Commodity, wr.Grade, wr.WarehousePhysical, wr.Date_Issued, wr.[Status] --%>
                    </dx:ASPxGridView>
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>
                    <dx:ASPxButton ID="ASPxButton5" runat="server" CausesValidation="false" Text="Mark Selected as Allocated" Theme="BlackGlass" Width="200px">
                    </dx:ASPxButton>
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
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

          <asp:panel id="Panel2" runat="server" GroupingText="Search Account to Allocate" Font-Names="Cambria">
        <table width="100%">
             <tr>
                <td colspan ="1" align="left" style="width: 134px">
                    <dx:ASPxLabel ID="ASPxLabel3" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Client Name." Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                <td colspan ="1" width="301">
                    <dx:ASPxTextBox ID="txtClientNameSearch" runat="server" Theme="Glass" Width="300px">
                    </dx:ASPxTextBox>
                </td>
                <td colspan ="1">
                    <dx:ASPxButton ID="ASPxButton2" runat="server" CausesValidation="false" Text="&gt;&gt;" Width="38px" Theme="BlackGlass">
                    </dx:ASPxButton>
                </td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>

            </tr>
            <tr>
                <td colspan ="1" style="width: 160px"></td>
                <td colspan ="2"><dx:ASPxListBox ID="lstNamesSearch" AutoPostBack="true" runat="server" ValueType="System.String" Height="90px" Theme="BlackGlass" Width="519px"></dx:ASPxListBox></td>
                
                <td colspan ="1"></td>
                <td colspan ="1"></td>

            </tr>
            <tr>
                <td colspan ="1" style="width: 134px"></td>
                <td width="301"></td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>

            </tr>

        </table>

    </asp:panel>
        <asp:Panel runat="server" ID="Panel3" Font-Names="Cambria" GroupingText="Account Details">

                <table width="100%">
<tr>
        <td colspan ="1" style="width: 160px">
            <dx:ASPxLabel ID="ASPxLabel4" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Account No." Theme="Glass">
            </dx:ASPxLabel>
        </td>
    <td colspan ="1"  style="width: 460px">
        <dx:ASPxTextBox ID="txtClientNo" runat="server" Theme="BlackGlass" Width="250px" ReadOnly="True">
        </dx:ASPxTextBox>
        </td>
    <td colspan ="1" style="width: 110px">
        <dx:ASPxLabel ID="ASPxLabel5" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Names" Theme="Glass">
        </dx:ASPxLabel>
        </td>
    <td colspan ="1">
        <dx:ASPxTextBox ID="txtSurname" runat="server" ReadOnly="True" Theme="BlackGlass" Width="250px">
        </dx:ASPxTextBox>
        </td>
    <td colspan ="1">
        &nbsp;</td>
    <td colspan ="1">
        &nbsp;</td>
    <td colspan ="1"></td>
    <td colspan ="1"></td>

</tr>
                    
                    <tr>
                        <td colspan="1">&nbsp;</td>
                        <td colspan="7" style="text-align: center">
                            <dx:ASPxLabel ID="lblCashBal" Visible="false" runat="server" Font-Names="Cambria" Font-Size="Small" Theme="Glass">
                            </dx:ASPxLabel>
                        </td>
                    </tr>
        </table>
        </asp:Panel>
        

         <asp:Panel runat="server" ID="Panel4" Font-Names="Cambria" GroupingText="Transaction Details" Font-Size="Medium">

                <table style="width: 100%">
                    <tr>
                        <td colspan="1" style="width: 160px">
                            <dx:ASPxLabel ID="ASPxLabel13" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Bank Name" Theme="Glass">
                            </dx:ASPxLabel>
                        </td>
                        <td colspan="1" style="width: 460px">
                            <dx:ASPxTextBox ID="txtbankname" runat="server" ReadOnly="True" Theme="BlackGlass" Width="250px">
                            </dx:ASPxTextBox>
                        </td>
                        <td colspan="1" style="width: 110px">
                            <dx:ASPxLabel ID="ASPxLabel14" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Bank Account" Theme="Glass">
                            </dx:ASPxLabel>
                        </td>
                        <td colspan="1" style="height: 18px">
                            <dx:ASPxTextBox ID="txtaccountno" runat="server" ReadOnly="True" Theme="BlackGlass" Width="250px">
                            </dx:ASPxTextBox>
                        </td>
                        <td colspan="1" style="height: 18px">&nbsp;</td>
                        <td colspan="1" style="height: 18px">&nbsp;</td>
                        <td colspan="1" style="height: 18px">&nbsp;</td>
                        <td style="height: 18px">&nbsp;</td>
                    </tr>
                    <tr>
                        <td colspan="1" style="width: 160px">
                            <dx:ASPxLabel ID="ASPxLabel9" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Deposit Amount" Theme="Glass">
                            </dx:ASPxLabel>
                        </td>
                        <td colspan="1" style="width: 460px">
                            <dx:ASPxTextBox ID="txtAmount" runat="server" Theme="BlackGlass" Width="250px">
                            </dx:ASPxTextBox>
                        </td>
                        <td colspan="1" style="width: 110px">
                            <dx:ASPxLabel ID="ASPxLabel11" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Description" Theme="Glass">
                            </dx:ASPxLabel>
                        </td>
                        <td colspan="1" style="height: 18px">
                            <dx:ASPxTextBox ID="txtdesc" runat="server" Theme="BlackGlass" Width="250px">
                            </dx:ASPxTextBox>
                        </td>
                        <td colspan="1" style="height: 18px"></td>
                        <td colspan="1" style="height: 18px"></td>
                        <td colspan="1" style="height: 18px"></td>
                        <td style="height: 18px">&nbsp;</td>
                    </tr>
                    <tr>
                        <td colspan="1" style="height: 18px">
                            <dx:ASPxLabel ID="ASPxLabel15" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Currency" Theme="Glass">
                            </dx:ASPxLabel>
                        </td>
                        <td colspan="1" style="height: 18px">
                            <dx:ASPxTextBox ID="txtcurrency" runat="server" ReadOnly="True" Theme="BlackGlass" Width="250px">
                            </dx:ASPxTextBox>
                        </td>
                        <td colspan="1" style="height: 18px">
                            <dx:ASPxLabel ID="ASPxLabel17" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Transaction Code" Theme="Glass">
                            </dx:ASPxLabel>
                        </td>
                        <td colspan="1" style="height: 18px">
                            <dx:ASPxComboBox ID="cmbtransactioncode" runat="server"  EnableCallbackMode="true" Theme="Glass" Width="250px">
                              <ValidationSettings RequiredField-IsRequired="true" ></ValidationSettings>
                            </dx:ASPxComboBox>
                        </td>
                        <td colspan="1" style="height: 18px">&nbsp;</td>
                        <td colspan="1" style="height: 18px">&nbsp;</td>
                        <td colspan="1" style="height: 18px">&nbsp;</td>
                        <td style="height: 18px">&nbsp;</td>
                    </tr>
                    <tr>
                        <td colspan="1" style="height: 18px">
                            <dx:ASPxLabel ID="ASPxLabel18" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Date" Theme="Glass">
                            </dx:ASPxLabel>
                        </td>
                        <td colspan="1" style="height: 18px">
                            <dx:ASPxTextBox ID="txtdate" runat="server" ReadOnly="True" Theme="BlackGlass" Width="250px">
                            </dx:ASPxTextBox>
                        </td>
                        <td colspan="1" style="height: 18px">
                            <dx:ASPxLabel ID="ASPxLabel19" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Asset Manager" Theme="Glass">
                            </dx:ASPxLabel>
                        </td>
                        <td colspan="1" style="height: 18px">
                            <dx:ASPxTextBox ID="txtassetmanager" runat="server" ReadOnly="True" Theme="BlackGlass" Width="250px">
                            </dx:ASPxTextBox>
                        </td>
                        <td colspan="1" style="height: 18px"></td>
                        <td colspan="1" style="height: 18px"></td>
                        <td colspan="1" style="height: 18px"></td>
                        <td style="height: 18px"></td>
                    </tr>
                    <tr>
                        <td colspan="1" style="height: 18px">&nbsp;</td>
                        <td colspan="1" style="height: 18px">
                            <dx:ASPxButton ID="ASPxButton3" runat="server" Text="Allocate" Theme="BlackGlass" Width="80px">
                            </dx:ASPxButton>
                        </td>
                        <td colspan="1" style="height: 18px">&nbsp;</td>
                        <td colspan="1" style="height: 18px">&nbsp;</td>
                        <td colspan="1" style="height: 18px">&nbsp;</td>
                        <td colspan="1" style="height: 18px">&nbsp;</td>
                        <td colspan="1" style="height: 18px">&nbsp;</td>
                        <td style="height: 18px">&nbsp;</td>
                    </tr>
                    <tr>
    <td colspan="1" style="height: 28px">
            </td>
    <td colspan="1" style="height: 28px">
        <dx:ASPxComboBox ID="cmbCounter" runat="server" AutoPostBack="true" CallbackPageSize="1000" DropDownStyle="DropDownList" DropDownWidth="550" EnableCallbackMode="true" IncrementalFilteringMode="StartsWith" PopupHorizontalAlign="NotSet" TextFormatString="{0}" Theme="Glass" ValueField="ReceiptNo" ValueType="System.String" Visible="False" Width="250px">
            <Columns>
                <dx:ListBoxColumn FieldName="ReceiptNo" Name="Receipt No" />
                <dx:ListBoxColumn Caption="Current Holder" FieldName="Holder" Name="Current Holder" />
                <dx:ListBoxColumn FieldName="Commodity" Name="Commodity" />
                <dx:ListBoxColumn FieldName="Grade" Name="Grade" />
                <dx:ListBoxColumn FieldName="Quantity" Name="Quantity" />
                <dx:ListBoxColumn Caption="Unit of Measure" FieldName="UnitMeasure" Name="Measurement" />
                <dx:ListBoxColumn Caption="Warehouse" FieldName="WarehousePhysical" />
                <dx:ListBoxColumn FieldName="Status" Name="Status" />
            </Columns>
        </dx:ASPxComboBox>
        <asp:CheckBox ID="chkCounter" runat="server" AutoPostBack="True" Text="Untick if deposit is not specific to an EWR" Visible="False" />
        <dx:ASPxTextBox ID="txtcharges" runat="server" ReadOnly="True" Theme="BlackGlass" Visible="False" Width="250px">
        </dx:ASPxTextBox>
                        </td>
    <td colspan="1" style="height: 28px"></td>
    <td colspan="1" style="height: 28px"></td>
    <td colspan="1" style="height: 28px"></td>
    <td colspan="1" style="height: 28px"></td>
    <td colspan="1" style="height: 28px"></td>
                        <td style="height: 28px">&nbsp;</td>
     </tr>
                 
                    <tr>
                        <td colspan="8" style="height: 28px">
                            <dx:ASPxGridView ID="ASPxGridView3" runat="server" KeyFieldName="ID" Settings-ShowTitlePanel="true" Theme="Glass" Width="100%">
                                <Settings ShowFilterRow="true" />
                                <Columns>
                                    <dx:GridViewDataTextColumn FieldName="AssetManager" Name="AssetManager" Settings-AutoFilterCondition="Contains">
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn FieldName="BankAccount" Name="BankAccount" Settings-AutoFilterCondition="Contains">
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn FieldName="BankName" Name="BankName" Settings-AutoFilterCondition="Contains">
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn FieldName="Amount" Name="Amount" PropertiesTextEdit-DisplayFormatString="n" Settings-AutoFilterCondition="Equals">
                                    </dx:GridViewDataTextColumn>
                                      <dx:GridViewDataTextColumn FieldName="Currency" Name="Currency" Settings-AutoFilterCondition="Equals">
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn FieldName="Reference" Name="Reference" Settings-AutoFilterCondition="Contains">
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn FieldName="Other_Details" Caption="Description" Settings-AutoFilterCondition="Contains">
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataDateColumn FieldName="DateCreated" Name="Record Date" Settings-AutoFilterCondition="Equals">
                                    </dx:GridViewDataDateColumn>
                                    <dx:GridViewDataTextColumn FieldName="AllocatedTo" caption="Allocated To" Settings-AutoFilterCondition="Contains">
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn FieldName="Names" caption="Allocated To" Settings-AutoFilterCondition="Contains">
                                    </dx:GridViewDataTextColumn>
                                       <dx:GridViewDataTextColumn FieldName="Allocated" caption="Status" Settings-AutoFilterCondition="Contains">
                                    </dx:GridViewDataTextColumn>
                                </Columns>
                            </dx:ASPxGridView>
                        </td>
                    </tr>
                 
        </table>
        </asp:Panel>
         
</asp:Panel>
  
</div>
</asp:Content>

