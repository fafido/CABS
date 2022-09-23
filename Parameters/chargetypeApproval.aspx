<%@ Page Language="VB" MasterPageFile="~/CDSUser.master" AutoEventWireup="false" CodeFile="ChargeTypeApproval.aspx.vb" Inherits="TransferSec_ChargeTypeApproval" title="Charges Approval" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<%@ Register assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxUploadControl" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxLoadingPanel" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxPopupControl" tagprefix="dx" %>

<%@ Register assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxRoundPanel" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxPanel" tagprefix="dx" %>
<asp:Content id="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <script src="../Scripts/jquery.min.js"></script>
    <script src="../Scripts/jquery.quicksearch.js"></script>
    <script type="text/javascript">
    $(function () {
        //$('input#txtSearch').quicksearch('table#table_example tbody tr');
        //$('input#txtSearch2').quicksearch('table#table_example2 tbody tr');
    });
</script>
    <asp:Panel id="Panel1" runat="server" Width="100%" Font-Names="Cambria" BackColor="White" GroupingText="Approve Charges">
       <table style="width:100%">
           <tr id="Tr1" runat="server">
                <td colspan="4">
                    <dx:ASPxLabel ID="ASPxLabel1" runat="server" Font-Names="Cambria" Font-Size="Small" Text="" Theme="Glass">
                    </dx:ASPxLabel>
                   <hr/>
                </td>
            </tr>
           <tr id="Panel13a1c" runat="server">
                <td colspan="4">
                    <dx:ASPxGridView ID="grdChargesCreated" runat="server" KeyFieldName="ID" SettingsPager-Mode="ShowAllRecords" Theme="Glass" Width="100%">
                        <SettingsPager Visible="False">
                        </SettingsPager>
                        <Columns>
                            <dx:GridViewDataColumn VisibleIndex="0">
                                <DataItemTemplate>
                                    <asp:LinkButton ID="SelectID" runat="server" CommandArgument='<%# Eval("ID") %>' CommandName="View" Text="View">
                                        </asp:LinkButton>
                                </DataItemTemplate>
                            </dx:GridViewDataColumn>
                           
                            <dx:GridViewDataColumn Caption="Charge Name" HeaderStyle-Font-Bold="true">
                                <DataItemTemplate>
                                    <dx:ASPxLabel runat="server" Text='<%# Eval("Name") %>'>
                                    </dx:ASPxLabel>
                                </DataItemTemplate>
                            </dx:GridViewDataColumn>
                            <dx:GridViewDataColumn Caption="Charge Type" HeaderStyle-Font-Bold="true">
                                <DataItemTemplate>
                                    <dx:ASPxLabel runat="server" Text='<%# Eval("ChargeType") %>'>
                                    </dx:ASPxLabel>
                                </DataItemTemplate>
                            </dx:GridViewDataColumn>
                            <dx:GridViewDataTextColumn FieldName="RangeFrom" HeaderStyle-Font-Bold="true" Name="Range From" PropertiesTextEdit-DisplayFormatString="n">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="RangeTo" HeaderStyle-Font-Bold="true" Name="Range To" PropertiesTextEdit-DisplayFormatString="n">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataColumn Caption="Range Currency" HeaderStyle-Font-Bold="true">
                                <DataItemTemplate>
                                    <dx:ASPxLabel runat="server" Text='<%# Eval("Currency") %>'>
                                    </dx:ASPxLabel>
                                </DataItemTemplate>
                            </dx:GridViewDataColumn>
                            <dx:GridViewDataColumn Caption="Charge Sub. Type" HeaderStyle-Font-Bold="true">
                                <DataItemTemplate>
                                    <dx:ASPxLabel runat="server" Text='<%# Eval("ChargeSUBType") %>'>
                                    </dx:ASPxLabel>
                                </DataItemTemplate>
                            </dx:GridViewDataColumn>
                            <dx:GridViewDataColumn Caption="Charge Currency" HeaderStyle-Font-Bold="true">
                                <DataItemTemplate>
                                    <dx:ASPxLabel runat="server" Text='<%# Eval("ChargeCurrency") %>'>
                                    </dx:ASPxLabel>
                                </DataItemTemplate>
                            </dx:GridViewDataColumn>
                            <dx:GridViewDataColumn Caption="Percentage/Amount" HeaderStyle-Font-Bold="true">
                                <DataItemTemplate>
                                    <dx:ASPxLabel runat="server" Text='<%# Eval("PercAmount1") %>'>
                                    </dx:ASPxLabel>
                                </DataItemTemplate>
                            </dx:GridViewDataColumn>
                            <dx:GridViewDataColumn Caption="Indicator" HeaderStyle-Font-Bold="true">
                                <DataItemTemplate>
                                    <dx:ASPxLabel runat="server" Text='<%# Eval("Indicator") %>'>
                                    </dx:ASPxLabel>
                                </DataItemTemplate>
                            </dx:GridViewDataColumn>
                            <dx:GridViewDataColumn Caption="Charge Interval" HeaderStyle-Font-Bold="true">
                                <DataItemTemplate>
                                    <dx:ASPxLabel runat="server" Text='<%# Eval("ChargeInterval") %>'>
                                    </dx:ASPxLabel>
                                </DataItemTemplate>
                            </dx:GridViewDataColumn>
                            <dx:GridViewDataColumn Caption="Update Type" HeaderStyle-Font-Bold="true">
                                <DataItemTemplate>
                                    <dx:ASPxLabel runat="server" Text='<%# Eval("UpdateType") %>'>
                                    </dx:ASPxLabel>
                                </DataItemTemplate>
                            </dx:GridViewDataColumn>
                            <dx:GridViewDataColumn Caption="Status" HeaderStyle-Font-Bold="true">
                                <DataItemTemplate>
                                    <dx:ASPxLabel runat="server" Text='<%# Eval("Status") %>'>
                                    </dx:ASPxLabel>
                                </DataItemTemplate>
                            </dx:GridViewDataColumn>
                        </Columns>
                    </dx:ASPxGridView>
                </td>
                  </tr>
           <tr id="Panel13a" runat="server">
               <td style="width: 208px">
                   <dx:ASPxLabel ID="ASPxLabel7115" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Name" Theme="Glass">
                   </dx:ASPxLabel>
               </td>
               <td style="width: 212px">
                   <dx:ASPxComboBox ID="cmbbillname" runat="server" AnimationType="Slide" CallbackPageSize="15" DropDownStyle="DropDownList" EnableCallbackMode="True" IncrementalFilteringMode="Contains" Theme="Glass" Width="250px">
                       <ValidationSettings>
                           <RequiredField IsRequired="true" />
                       </ValidationSettings>
                   </dx:ASPxComboBox>
               </td>
               <td align="right" style="width: 208px">
                   <dx:ASPxLabel ID="ASPxLabel72d0" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Update Type" Theme="Glass">
                   </dx:ASPxLabel>
               </td>
               <td style="width: 212px">
                   <dx:ASPxTextBox ID="txtupdatetype" runat="server" BackColor="White" DisplayFormatString="n" Theme="Glass" Width="250px">
                   </dx:ASPxTextBox>
               </td>
           </tr>
           <tr id="Panel13a1" runat="server">
               <td style="width: 208px">
                   <dx:ASPxLabel ID="ASPxLabel30" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Charge Type" Theme="Glass">
                   </dx:ASPxLabel>
                   <dx:ASPxLabel ID="ASPxLabel73" runat="server" ForeColor="Red" Text="*">
                   </dx:ASPxLabel>
               </td>
               <td style="width: 212px">
                   <dx:ASPxComboBox ID="cmbChargeType" runat="server" AnimationType="Slide" AutoPostBack="True" CallbackPageSize="15" DropDownStyle="DropDownList" EnableCallbackMode="True" IncrementalFilteringMode="Contains" Theme="Glass" Width="250px">
                       <ValidationSettings>
                           <RequiredField IsRequired="true" />
                       </ValidationSettings>
                   </dx:ASPxComboBox>
               </td>
               <td align="right" style="width: 208px">
                   <dx:ASPxLabel ID="ASPxLabel72d" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Fee Type" Theme="Glass">
                   </dx:ASPxLabel>
                   <dx:ASPxLabel ID="ASPxLabel2" runat="server" ForeColor="Red" Text="*">
                   </dx:ASPxLabel>
               </td>
               <td style="width: 212px">
                   <dx:ASPxComboBox ID="cmbChargeSubType" runat="server" AnimationType="Slide" CallbackPageSize="15" DropDownStyle="DropDownList" EnableCallbackMode="True" IncrementalFilteringMode="Contains" Theme="Glass" Width="250px">
                    <ValidationSettings>
                           <RequiredField IsRequired="true" />
                       </ValidationSettings>
                        </dx:ASPxComboBox>
               </td>
           </tr>
           <tr id="Panel8e" runat="server">
                    <td style="width: 208px">
                        <dx:ASPxLabel ID="ASPxLabel5" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Amount From" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td style="width: 212px">
                        <dx:ASPxTextBox ID="txtFrom" runat="server" DisplayFormatString="n" BackColor="White" Theme="Glass" Width="250px">
                          
                        </dx:ASPxTextBox>
                    </td>
                    <td style="width: 208px" align="right">
                        <dx:ASPxLabel ID="ASPxLabel27" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Amount to" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td style="width: 212px">
                        <dx:ASPxTextBox ID="txtTo" runat="server" DisplayFormatString="n" BackColor="White" Theme="Glass" Width="250px">
                        </dx:ASPxTextBox>
                    </td>
                </tr>
           <tr id="Panel8e1" runat="server">
               <td style="width: 208px">
                   <dx:ASPxLabel ID="ASPxLabel7117" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Range Currency" Theme="Glass">
                   </dx:ASPxLabel>
               </td>
               <td style="width: 212px">
                   <dx:ASPxComboBox ID="cmbcurrency" runat="server" AnimationType="Slide" CallbackPageSize="15" DropDownStyle="DropDownList" EnableCallbackMode="True" IncrementalFilteringMode="Contains" Theme="Glass" Width="250px">
                       <Items>
                           <dx:ListEditItem Text="" Value="" />
                       </Items>
                   </dx:ASPxComboBox>
               </td>
               <td align="right" style="width: 208px">&nbsp;</td>
               <td style="width: 212px">&nbsp;</td>
           </tr>
           <tr id="Panel8b" runat="server">
                    <td style="width: 208px">
                        <dx:ASPxLabel ID="ASPxLabel29" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Indicator" Theme="Glass">
                        </dx:ASPxLabel>
                        <dx:ASPxLabel ID="ASPxLabel6" runat="server" ForeColor="Red" Text="*">
                        </dx:ASPxLabel>
                    </td>
                    <td style="width: 212px">
                        <asp:RadioButtonList ID="rdbIndicator" RepeatDirection="Horizontal" AutoPostBack="true" runat="server">
                            <asp:ListItem Text="%" Value="%"></asp:ListItem>
                            <asp:ListItem Text="Flat" Value="Flat"></asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                    <td style="width: 208px" align="right">
                        <dx:ASPxLabel ID="ASPxLabel7" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Percentage/Amount" Theme="Glass">
                        </dx:ASPxLabel>
                        <dx:ASPxLabel ID="ASPxLabel8" runat="server" ForeColor="Red" Text="*">
                        </dx:ASPxLabel>
                    </td>
                    <td style="width: 212px; padding-left:-1px">
                        <table class="auto-style1">
                            <tr>
                                <td style="width: 214px">
                                    <dx:ASPxTextBox ID="txtPercAmount" runat="server" BackColor="White" Theme="Glass" Width="250px">
                                    </dx:ASPxTextBox>
                                </td>
                                <td>
                                    <dx:ASPxComboBox ID="cmbchargecurrency" runat="server" AnimationType="Slide" CallbackPageSize="15" DropDownStyle="DropDownList" EnableCallbackMode="True" IncrementalFilteringMode="Contains" Theme="Glass" Width="40px" Visible="False">
                                        <Items>
                                            <dx:ListEditItem Text="" Value="" />
                                        </Items>
                                    </dx:ASPxComboBox>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
           <tr id="Panel8i" runat="server">
                    <td style="width: 208px">
                        <dx:ASPxLabel ID="ASPxLabel714" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Charge Interval" Theme="Glass">
                        </dx:ASPxLabel>
                        <dx:ASPxLabel ID="ASPxLabel9" runat="server" ForeColor="Red" Text="*">
                        </dx:ASPxLabel>
                    </td>
                    <td style="width: 212px">
                        <dx:ASPxComboBox ID="cmbChargeInterval" runat="server" Theme="Glass" Width="250px"  CallbackPageSize="15" EnableCallbackMode="True" DropDownStyle="DropDownList"  IncrementalFilteringMode="Contains"  AnimationType="Slide">
                            <Items>
                                <dx:ListEditItem Text="" Value="" />
                            </Items>
                        </dx:ASPxComboBox>
                    </td>
                    <td align="right" style="width: 208px">
                        <dx:ASPxLabel ID="ASPxLabel274" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Up to Max" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td style="width: 212px">
                        <dx:ASPxTextBox ID="txtUptoMax" runat="server" DisplayFormatString="n" BackColor="White" Theme="Glass" Width="250px">
                        </dx:ASPxTextBox>
                    </td>
                </tr>
           <tr id="Panel0a1" runat="server">
               <td style="width: 208px; height: 24px;">
                   <dx:ASPxLabel ID="ASPxLabel110" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Levied On" Theme="Glass" Visible="False">
                   </dx:ASPxLabel>
                   <dx:ASPxLabel ID="ASPxLabel10" runat="server" ForeColor="Red" Text="*" Visible="False">
                   </dx:ASPxLabel>
               </td>
               <td style="width: 212px; height: 24px;">
                   <dx:ASPxComboBox ID="cmbParticipantType" runat="server" AnimationType="Slide" AutoPostBack="True" CallbackPageSize="15" DropDownStyle="DropDownList" EnableCallbackMode="True" IncrementalFilteringMode="Contains" Theme="Glass" Visible="False" Width="250px">
                       <Items>
                           <dx:ListEditItem Text="" Value="" />
                       </Items>
                   </dx:ASPxComboBox>
               </td>
               <td align="right" style="width: 208px; height: 24px;">
                   <dx:ASPxLabel ID="ASPxLabel72" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Accruals on Behalf of" Theme="Glass" Visible="False">
                   </dx:ASPxLabel>
                   <dx:ASPxLabel ID="ASPxLabel3" runat="server" ForeColor="Red" Text="*" Visible="False">
                   </dx:ASPxLabel>
               </td>
               <td style="width: 212px; height: 24px;">
                   <dx:ASPxComboBox ID="cmbAccrualsonBehalfof" runat="server" AnimationType="Slide" AutoPostBack="true" CallbackPageSize="15" DropDownStyle="DropDownList" EnableCallbackMode="True" IncrementalFilteringMode="Contains" Theme="Glass" Visible="False" Width="250px">
                       <Items>
                           <dx:ListEditItem Text="" Value="" />
                           <dx:ListEditItem Text="NCMCL" Value="NCMCL" />
                           <dx:ListEditItem Text="WHO" Value="WHO" />
                       </Items>
                   </dx:ASPxComboBox>
               </td>
           </tr>
           <tr id="Tr3" runat="server">
                    <td style="width: 208px; height: 27px;">
                        </td>
                    <td style="width: 212px; height: 27px;">
                         <asp:Label ID="lblid" runat="server" Visible="False"></asp:Label>
                         </td>
                    <td align="right" style="width: 208px; height: 27px;" runat="server" id="pnWHO1" visible="false">
                        </td>
                    <td style="width: 212px; height: 27px;" runat="server" id="pnWHO2" visible="false">
                         </td>
           </tr>
           <tr id="PanelSAVE" runat="server">
                        <td style="width:208px"></td>
                        <td style="width:212px">
                            &nbsp;<dx:ASPxButton ID="btnSaveCharge" runat="server" Width="164px" Text="Approve" Theme="Glass">
                            </dx:ASPxButton>
                        </td>
                </tr>
           <tr id="panelUPDATE" runat="server" visible="false">
                        <td style="width:208px"></td>
                        <td style="width:212px">
                            &nbsp;<dx:ASPxButton ID="btnUpdateCharge" runat="server" Text="Update" Theme="Glass">
                            </dx:ASPxButton>
                        </td>
                </tr>
           <tr id="panel00003" runat="server">
                <td colspan="4" style="height: 18px">
                    &nbsp;</td>
            </tr> 
           <tr id="panel00003a1" runat="server">
               <td colspan="4" style="height: 18px">
                   <dx:ASPxLabel ID="ASPxLabel7118" runat="server" Font-Bold="true" Font-Names="Cambria" Font-Size="Small" Text="List of Active Charges" Theme="Glass">
                   </dx:ASPxLabel>
                   <hr/>
               </td>
           </tr>
           <tr id="panel00003a" runat="server">
               <td colspan="4" style="height: 18px">
                   <dx:ASPxGridView ID="grdactivecharges" runat="server" KeyFieldName="ID" SettingsPager-Mode="ShowAllRecords" Theme="Glass" Width="100%">
                       <SettingsPager Visible="False">
                       </SettingsPager>
                       <Columns>
                           <dx:GridViewDataColumn VisibleIndex="0">
                               <DataItemTemplate>
                                   <asp:LinkButton ID="SelectID0" runat="server" CommandArgument='<%# Eval("ID") %>' CommandName="Select" Text="Edit">
                                        </asp:LinkButton>
                               </DataItemTemplate>
                           </dx:GridViewDataColumn>
                           <dx:GridViewDataColumn VisibleIndex="0">
                               <DataItemTemplate>
                                   <asp:LinkButton ID="SelectID1" runat="server" CommandArgument='<%# Eval("ID") %>' CommandName="Delete" OnClientClick="if ( !confirm('Are you sure you want to delete ? ')) return false;" Text="Delete">
                                        </asp:LinkButton>
                               </DataItemTemplate>
                           </dx:GridViewDataColumn>
                           <dx:GridViewDataColumn Caption="Charge Name" HeaderStyle-Font-Bold="true">
                               <DataItemTemplate>
                                   <dx:ASPxLabel runat="server" Text='<%# Eval("Name") %>'>
                                   </dx:ASPxLabel>
                               </DataItemTemplate>
                           </dx:GridViewDataColumn>
                           <dx:GridViewDataColumn Caption="Charge Type" HeaderStyle-Font-Bold="true">
                               <DataItemTemplate>
                                   <dx:ASPxLabel runat="server" Text='<%# Eval("ChargeType") %>'>
                                   </dx:ASPxLabel>
                               </DataItemTemplate>
                           </dx:GridViewDataColumn>
                           <dx:GridViewDataColumn Caption="Range From" HeaderStyle-Font-Bold="true">
                               <DataItemTemplate>
                                   <dx:ASPxLabel runat="server" Text='<%# Eval("RangeFrom") %>'>
                                   </dx:ASPxLabel>
                               </DataItemTemplate>
                           </dx:GridViewDataColumn>
                           <dx:GridViewDataColumn Caption="Range To" HeaderStyle-Font-Bold="true">
                               <DataItemTemplate>
                                   <dx:ASPxLabel runat="server" Text='<%# Eval("Rangeto") %>'>
                                   </dx:ASPxLabel>
                               </DataItemTemplate>
                           </dx:GridViewDataColumn>
                           <dx:GridViewDataColumn Caption="Range Currency" HeaderStyle-Font-Bold="true">
                               <DataItemTemplate>
                                   <dx:ASPxLabel runat="server" Text='<%# Eval("Currency") %>'>
                                   </dx:ASPxLabel>
                               </DataItemTemplate>
                           </dx:GridViewDataColumn>
                           <dx:GridViewDataColumn Caption="Charge Sub. Type" HeaderStyle-Font-Bold="true">
                               <DataItemTemplate>
                                   <dx:ASPxLabel runat="server" Text='<%# Eval("ChargeSUBType") %>'>
                                   </dx:ASPxLabel>
                               </DataItemTemplate>
                           </dx:GridViewDataColumn>
                           <dx:GridViewDataColumn Caption="Charge Currency" HeaderStyle-Font-Bold="true">
                               <DataItemTemplate>
                                   <dx:ASPxLabel runat="server" Text='<%# Eval("ChargeCurrency") %>'>
                                   </dx:ASPxLabel>
                               </DataItemTemplate>
                           </dx:GridViewDataColumn>
                           <dx:GridViewDataColumn Caption="Percentage/Amount" HeaderStyle-Font-Bold="true">
                               <DataItemTemplate>
                                   <dx:ASPxLabel runat="server" Text='<%# Eval("PercAmount1") %>'>
                                   </dx:ASPxLabel>
                               </DataItemTemplate>
                           </dx:GridViewDataColumn>
                           <dx:GridViewDataColumn Caption="Indicator" HeaderStyle-Font-Bold="true">
                               <DataItemTemplate>
                                   <dx:ASPxLabel runat="server" Text='<%# Eval("Indicator") %>'>
                                   </dx:ASPxLabel>
                               </DataItemTemplate>
                           </dx:GridViewDataColumn>
                           <dx:GridViewDataColumn Caption="Charge Interval" HeaderStyle-Font-Bold="true">
                               <DataItemTemplate>
                                   <dx:ASPxLabel runat="server" Text='<%# Eval("ChargeInterval") %>'>
                                   </dx:ASPxLabel>
                               </DataItemTemplate>
                           </dx:GridViewDataColumn>
                        
                       </Columns>
                   </dx:ASPxGridView>
               </td>
           </tr>
           <tr id="Tr2" runat="server">
                 <td style="width:208px"></td>
            </tr>
            <tr id="Tr2w" runat="server">
                 <td style="width:208px"></td>
            </tr>
            <tr>
                <td align="right" align="center" colspan="4">
                <dx:ASPxPopupControl ID="ASPxPopupControl1" runat="server" Modal="true" BackColor="#DDECFE" CloseAction="CloseButton" EnableCallbackAnimation="True" HeaderText="Additional Fee (Other)" ShowCollapseButton="False" ShowMaximizeButton="False" ShowPageScrollbarWhenModal="True" ShowPinButton="False" ShowRefreshButton="False" Theme="Glass">
            <contentcollection>
          <dx:PopupControlContentControl runat="server" SupportsDisabledAttribute="True">
            <dx:ASPxRoundPanel ID="ASPxRoundPanel6" runat="server" ShowHeader="False" Theme="Glass" Width="100%">
                <panelcollection>
                    <dx:PanelContent runat="server" SupportsDisabledAttribute="True">
                        <table class="dxflInternalEditorTable_Moderno" style="width: 100%">
                            <tr>
                                <td style="width:208px">
                                 <dx:ASPxLabel ID="ASPxLabel60" runat="server" Text="Fee Description" Theme="Glass"></dx:ASPxLabel>
                                </td>
                                <td style="width:212px">
                                    <dx:ASPxTextBox ID="txtAddChargesNames" runat="server" Theme="Glass" Width="250px">
                                    </dx:ASPxTextBox>
                                </td>
                            </tr>
                    <tr>
                         <td style="width:208px"></td>
                        <td style="width:212px">
                            <dx:ASPxButton ID="btnCommitNewAddFee" runat="server" Text="Save" Theme="iOS">
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
</asp:Content>

