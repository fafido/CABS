<%@ Page Language="VB" MasterPageFile="~/CDSUser.master" AutoEventWireup="false" CodeFile="BorrowersRequest.aspx.vb" Inherits="TransferSec_BorrowersRequest" title="BorrowersRequest" %>

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

<asp:Content id="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
    <asp:Panel id="Panel1" runat="server" Width="100%" Font-Names="Arial" Font-Size="Medium" BackColor="White">
    
        <table width ="100%">
            <tr>
                   <td style ="text-align :left;" align="left">
                       <dx:ASPxLabel ID="ASPxLabel1" runat="server" Text="Lending And Borrowing&gt;&gt;Borrowers Request" Font-Names="Cambria" Font-Size="Small" Theme="PlasticBlue"></dx:ASPxLabel>

                   </td>
            </tr>
        </table>
          <asp:panel id="Panel3" runat="server" GroupingText="Search" Font-Names="Cambria">
        <table width ="100%">
            <tr>
                    <td style="width:163px" colspan ="1">
                        <dx:ASPxLabel ID="ASPxLabel54" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Account No." Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                <td colspan ="1">
                    <table class="dxflInternalEditorTable_Glass">
                        <tr>
                            <td style="width:253px">
                                <dx:ASPxTextBox ID="txtcds_number_search" runat="server" Theme="BlackGlass" Width="250px">
                                </dx:ASPxTextBox>
                            </td>
                            <td>
                                <dx:ASPxButton ID="ASPxButton6" runat="server" Text="&gt;&gt;" Theme="BlackGlass">
                                </dx:ASPxButton>
                            </td>
                        </tr>
                    </table>
                    </td>
                <td colspan ="1">
                    &nbsp;</td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>

            </tr>
            <tr>
                    <td colspan ="1">
                        <dx:ASPxLabel ID="ASPxLabel55" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Client Name" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                <td colspan ="1">
                    <table class="dxflInternalEditorTable_Glass">
                        <tr>
                            <td style="width: 221px">
                                <dx:ASPxTextBox ID="txtNameSearch" runat="server" Theme="BlackGlass" Width="250px">
                                </dx:ASPxTextBox>
                            </td>
                            <td>
                                <dx:ASPxButton ID="ASPxButton7" runat="server" Text="&gt;&gt;" Theme="BlackGlass">
                                </dx:ASPxButton>
                            </td>
                        </tr>
                    </table>
                    </td>
                <td colspan ="1">
                    &nbsp;</td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>

            </tr>
            <tr>
                    <td colspan ="1"></td>
                <td colspan ="7">
                    <dx:ASPxListBox ID="lstNameSearch" runat="server" ValueType="System.String" AutoPostBack="True" Theme="Glass" Width="710px"></dx:ASPxListBox>

                </td>

            </tr>
            <tr>
                    <td colspan ="1"></td>
                <td colspan ="7">
                    <dx:ASPxLabel ID="lblClientID" runat="server" Font-Names="Cambria" Font-Size="Small" Theme="Glass">
                    </dx:ASPxLabel>
                    </td>
            </tr>
        
        </table>

    </asp:panel>
        <asp:panel id="Panel8" runat="server" GroupingText="Personal Details" Font-Names="Cambria">
        <table width ="100%">
            <tr>
                <td style="width:210px" colspan ="1">
                    <dx:ASPxLabel ID="ASPxLabel25" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Account No." Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                <td colspan ="1" style="width: 426px">
                    <dx:ASPxTextBox ID="txtClientId" runat="server"  Theme="BlackGlass" Width="250px" ReadOnly="True">
                    </dx:ASPxTextBox>
                </td>
                <td colspan ="1">
                    <dx:ASPxLabel ID="ASPxLabel30" runat="server" Font-Names="Cambria" Font-Size="Small" Text="CNIC No" Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                <td colspan ="1">
                    <dx:ASPxTextBox ID="txtIdno" runat="server"  ReadOnly="True" Theme="BlackGlass" Width="250px">
                    </dx:ASPxTextBox>
                </td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>
                

            </tr>
           <tr>
               <td colspan ="1">
                   <dx:ASPxLabel ID="ASPxLabel26" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Account Name" Theme="Glass">
                   </dx:ASPxLabel>
               </td>
               <td colspan ="1" style="width: 426px">
                   <dx:ASPxTextBox ID="txtSurname" runat="server"  ReadOnly="True" Theme="BlackGlass" Width="250px">
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
                        <dx:ASPxLabel ID="ASPxLabel68" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Credit Limit" Theme="Glass" Visible="False">
                        </dx:ASPxLabel>
                    </td>
                <td colspan ="1" style="width: 426px">
                    <dx:ASPxTextBox ID="txtCreditLimit" runat="server"  Theme="BlackGlass" Width="250px" Visible="False">
                    </dx:ASPxTextBox>
                    </td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>

            </tr>
            

        </table>

    </asp:panel>
        <asp:panel id="Panel2" runat="server" GroupingText="Borrowing Request" Font-Names="Cambria">
        <table width ="100%">
            <tr>
                <td colspan ="1">
                    <dx:ASPxLabel ID="ASPxLabel2" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Collateral" Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                <td colspan ="1">
                    <dx:ASPxComboBox ID="cmbCompany" runat="server" DropDownWidth="550"
        DropDownStyle="DropDownList"  ValueField="ReceiptNo"
        ValueType="System.String" TextFormatString="{0}"  EnableCallbackMode="true" AutoPostBack="true" IncrementalFilteringMode="StartsWith"
        CallbackPageSize="1000" Width="250px" Theme="Glass">
                        <Columns>
                            <dx:ListBoxColumn FieldName="ReceiptNo" Name="Receipt No"/>
                            <dx:ListBoxColumn FieldName="Holder" Caption="Current Holder" Name="Current Holder"/>
                            <dx:ListBoxColumn FieldName="Commodity" Name="Commodity"/>
                            <dx:ListBoxColumn FieldName="Grade" Name="Grade"/>
                            <dx:ListBoxColumn FieldName="Quantity" Name="Quantity"/>
                            <dx:ListBoxColumn FieldName="UnitMeasure" Caption="Unit of Measure" Name="Measurement"/>
                            <dx:ListBoxColumn FieldName="WarehousePhysical" Caption="Warehouse"/>
                            <dx:ListBoxColumn FieldName="Status" Name="Status"/>
                          
                              

                        </Columns>
                    </dx:ASPxComboBox>
                </td>
                <td colspan ="1">
                    <dx:ASPxLabel ID="ASPxLabel69" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Available Quantity" Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                <td colspan ="1">
                    <dx:ASPxTextBox ID="txtavailableQuantity" runat="server"  Theme="BlackGlass" Width="250px" ReadOnly="True">
                    </dx:ASPxTextBox>
                </td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>
                

            </tr>
            <tr>
                    <td colspan ="1">
                        <dx:ASPxLabel ID="ASPxLabel75" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Indicative Commodity Price" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                <td colspan ="1">
                    <dx:ASPxTextBox ID="txtshareprice" runat="server" AutoPostBack="True" Theme="BlackGlass" Width="250px">
                    </dx:ASPxTextBox>
                    </td>
                <td colspan ="1">
                    <dx:ASPxLabel ID="ASPxLabel78" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Collateral Value (PKR)" Theme="Glass">
                    </dx:ASPxLabel>
                    </td>
                <td colspan ="1">
                    <dx:ASPxTextBox ID="txtcollateralvalue" runat="server" ReadOnly="True" Theme="BlackGlass" Width="250px">
                    </dx:ASPxTextBox>
                    </td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>


            </tr>
             <tr>
                    <td colspan ="1">
                        <dx:ASPxLabel ID="ASPxLabel79" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Preferred Financier" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                <td colspan ="1">
                    <dx:ASPxComboBox ID="cmbfinancier" runat="server" AutoPostBack="True" style="margin-top: 0px" Theme="Glass" Width="250px">
                    </dx:ASPxComboBox>
                    </td>
                <td colspan ="1">
                    <dx:ASPxLabel ID="ASPxLabel72" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Amount Required" Theme="Glass">
                    </dx:ASPxLabel>
                    </td>
                <td colspan ="1">
                    <dx:ASPxTextBox ID="txtquantity" runat="server" Theme="BlackGlass" Width="250px">
                    </dx:ASPxTextBox>
                    </td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>


            </tr>
            <tr>
                <td colspan="1">
                    <dx:ASPxLabel ID="ASPxLabel46" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Other Charges" Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                <td colspan="1">
                    <dx:ASPxTextBox ID="txtothercharges" runat="server" Height="19px" ReadOnly="True" Theme="BlackGlass" Width="250px">
                    </dx:ASPxTextBox>
                </td>
                <td colspan="1">
                    <dx:ASPxLabel ID="ASPxLabel44" runat="server" Font-Names="Cambria" Font-Size="Small" Text="EWR Accumulated Charges" Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                <td colspan="1">
                    <dx:ASPxTextBox ID="txtaccumulatedcharges" runat="server" Height="19px" ReadOnly="True" Theme="BlackGlass" Width="250px">
                    </dx:ASPxTextBox>
                </td>
                <td colspan="1">&nbsp;</td>
                <td colspan="1">&nbsp;</td>
                <td colspan="1">&nbsp;</td>
                <td colspan="1">&nbsp;</td>
            </tr>
            <tr>
                <td colspan="1">
                    <dx:ASPxLabel ID="ASPxLabel80" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Tenure" Theme="Glass" Visible="False">
                    </dx:ASPxLabel>
                </td>
                <td colspan="1">
                    <dx:ASPxComboBox ID="cmbtenure" runat="server" AutoPostBack="True" Theme="Glass" Visible="False" Width="250px">
                    </dx:ASPxComboBox>
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
                    &nbsp;</td>
                <td colspan="1">
                    &nbsp;</td>
                <td colspan="1">
                    <dx:ASPxLabel ID="ASPxLabel70" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Effective Date" Theme="Glass" Visible="False">
                    </dx:ASPxLabel>
                    <dx:ASPxLabel ID="ASPxLabel71" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Maturity Date" Theme="Glass" Visible="False">
                    </dx:ASPxLabel>
                </td>
                <td colspan="1">
                    <dx:ASPxDateEdit ID="txtEffectiveDate" runat="server" Theme="Glass" Visible="False" Width="250px">
                    </dx:ASPxDateEdit>
                </td>
                <td colspan="1">&nbsp;</td>
                <td colspan="1">&nbsp;</td>
                <td colspan="1">&nbsp;</td>
                <td colspan="1">&nbsp;</td>
            </tr>
            <tr>
                <td colspan="8" align="center">
                    <dx:ASPxButton ID="ASPxButton9" runat="server" Text="Apply" Theme="BlackGlass">
                    </dx:ASPxButton>
                    <dx:ASPxDateEdit ID="txtExpiryDate" runat="server" Theme="Glass" Visible="False" Width="250px">
                    </dx:ASPxDateEdit>
                </td>
            </tr>
            <tr>
                <td align="center" colspan="8">
                    <dx:ASPxGridView ID="grdOTP" runat="server" KeyFieldName="id" Settings-ShowTitlePanel="true" SettingsText-Title="Transactions Pending OTP" Theme="Glass" Width="100%">
                        <Columns>
                            <dx:GridViewDataColumn Caption="" VisibleIndex="0">
                                <DataItemTemplate>
                                    <asp:LinkButton ID="otpenabled" runat="server" CommandArgument='<%# Eval("id") %>' CommandName="OTP" Text="Enter OTP">
                                                              </asp:LinkButton>
                                </DataItemTemplate>
                            </dx:GridViewDataColumn>
                            <dx:GridViewDataColumn Caption="Account No">
                                <DataItemTemplate>
                                    <dx:ASPxLabel runat="server" Text='<%# Eval("Borrower") %>'>
                                    </dx:ASPxLabel>
                                </DataItemTemplate>
                            </dx:GridViewDataColumn>
                            <dx:GridViewDataColumn Caption="Receipt No.">
                                <DataItemTemplate>
                                    <dx:ASPxLabel runat="server" Text='<%# Eval("Collateral") %>'>
                                    </dx:ASPxLabel>
                                </DataItemTemplate>
                            </dx:GridViewDataColumn>
                            <dx:GridViewDataColumn Caption="Available Quantity">
                                <DataItemTemplate>
                                    <dx:ASPxLabel runat="server" Text='<%# Eval("AvailableQuantity") %>'>
                                    </dx:ASPxLabel>
                                </DataItemTemplate>
                            </dx:GridViewDataColumn>
                            <dx:GridViewDataColumn Caption="Loan Amount">
                                <DataItemTemplate>
                                    <dx:ASPxLabel runat="server" Text='<%# Eval("LoanAmount") %>'>
                                    </dx:ASPxLabel>
                                </DataItemTemplate>
                            </dx:GridViewDataColumn>
                       
                            <dx:GridViewDataColumn Caption="Captured Date">
                                <DataItemTemplate>
                                    <dx:ASPxLabel runat="server" Text='<%# Eval("CapturedDate") %>'>
                                    </dx:ASPxLabel>
                                </DataItemTemplate>
                            </dx:GridViewDataColumn>
                            <dx:GridViewDataColumn Caption="Service Charge">
                                <DataItemTemplate>
                                    <dx:ASPxLabel runat="server" Text='<%# Eval("ServiceCharge") %>'>
                                    </dx:ASPxLabel>
                                </DataItemTemplate>
                            </dx:GridViewDataColumn>
                        </Columns>
                    </dx:ASPxGridView>
                </td>
            </tr>
            <tr>
                <td colspan="7">
                    <dx:ASPxGridView ID="ASPxGridView2" SettingsBehavior-AllowSort="false"   Settings-ShowTitlePanel="true" SettingsText-Title="Bank Terms" runat="server" Theme="Glass" Width="100%" Visible="False">
                    </dx:ASPxGridView>
                </td>
                <td colspan="1">&nbsp;</td>
            </tr>
            <tr>
                <td align="center" colspan="8">
                    <dx:ASPxButton ID="ASPxButton8" runat="server" Text="Load Lenders" Theme="BlackGlass" Visible="False">
                    </dx:ASPxButton>
                </td>
            </tr>
            <tr>
                <td align="center" colspan="8">&nbsp;</td>
            </tr>
            <tr>
                <td align="center" colspan="8">
              
                    <dx:ASPxGridView ID="ASPxGridView1"  Settings-ShowTitlePanel="true" SettingsText-Title="Available Banks for my Loan Parameters" runat="server" Width="100%" Theme="Glass" Visible="False">
                    </dx:ASPxGridView>
              
                </td>
            </tr>
            <tr>
                <td align="center" colspan="8">
                    <table class="dxflInternalEditorTable_Glass">
                        <tr>
                            <td align="left" style="width: 125px">
                                &nbsp;</td>
                            <td align="left">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td align="center" colspan="2">
                                <br />
                                <br />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                  <td  colspan="8">
                      <dx:ASPxPopupControl ID="ASPxPopupControl1" runat="server" BackColor="#DDECFE" CloseAction="CloseButton" EnableCallbackAnimation="True" HeaderText="Enter OTP to Submit" ShowCollapseButton="True" ShowPageScrollbarWhenModal="True" ShowPinButton="True" Theme="Office2010Blue" Width="400px">
        <contentcollection>
<dx:PopupControlContentControl runat="server" SupportsDisabledAttribute="True">
    <dx:ASPxRoundPanel ID="ASPxRoundPanel6" runat="server" BackColor="White" ShowHeader="False" Width="100%">
        <panelcollection>
            <dx:PanelContent runat="server" SupportsDisabledAttribute="True">
                <table style="width: 100%">
                    <tr>
                        <td align="right">
                            <dx:ASPxLabel ID="ASPxLabel60" runat="server" Text="OTP" Theme="iOS">
                            </dx:ASPxLabel>
                        </td>
                        <td align="left">
                            <dx:ASPxTextBox ID="txtotp" runat="server" Theme="iOS">
                            <masksettings errortext="Invalid OTP" mask="0000" />
                            </dx:ASPxTextBox>
                             <asp:Label ID="lbltransid" runat="server" Visible="False"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">&#160;</td>
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
    </dx:ASPxPopupControl>
                      <br />
                      <br />
                      <br />
                  </td>
            </tr>
      </table>

    </asp:panel>
        <asp:panel id="Panel11" runat="server" GroupingText="Lending Pool" Font-Names="Cambria" Visible="False">
        <table width ="100%">
            <tr>
                    <td colspan ="2" align="left">
                        <dx:ASPxLabel ID="ASPxLabel66" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Lenders" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                <td align="center"></td>
                <td align="center">
                        &nbsp;</td>

            </tr>
            <tr>
                    <td valign="top"  colspan ="2" align="left">
                        <table class="dxflInternalEditorTable_Glass">
                            <tr>
                                <td style="width: 254px">
                                    <dx:ASPxListBox ID="lstLenders" runat="server" Height="175px" Theme="iOS" ValueType="System.String" Width="250px">
                                    </dx:ASPxListBox>
                                </td>
                                <td style="width: 98px">
                                    <dx:ASPxButton ID="ASPxButton5" runat="server" Height="23px" Text="Use Lender" Theme="BlackGlass" Width="86px">
                                    </dx:ASPxButton>
                                </td>
                                <td valign="top">
                                    &nbsp;</td>
                            </tr>
                        </table>
                    </td>
                <td align="center">
                    &nbsp;</td>
                <td align="center">
                        &nbsp;</td>

            </tr>
         
           <tr>
               <td colspan ="1">
                   <dx:ASPxLabel ID="ASPxLabel73" runat="server" Font-Names="Cambria" Font-Size="Medium" Text="Lender Details" Theme="Glass">
                   </dx:ASPxLabel>
               </td>
               <td colspan ="3">
                   &nbsp;</td>

           </tr>
             <tr>
               <td colspan ="1">
                   <asp:GridView ID="grdTranShareholder" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" DataKeyNames="id" EmptyDataText="No Relevant Data Found" ForeColor="Black" GridLines="Vertical" Height="16px" Width="99%">
                       <PagerSettings FirstPageText="First" LastPageText="Last" NextPageText="Next" PreviousPageText="Previous" />
                       <AlternatingRowStyle CssClass="altrowstyle" />
                       <Columns>
                           <asp:BoundField DataField="surname" HeaderText="Lender Account Name" />
                       <%--    <asp:BoundField DataField="forenames" HeaderText="Lender Forename" />--%>
                           <asp:BoundField DataField="Company" HeaderText="Company" />
                           <asp:BoundField DataField="Quantity" HeaderText="Quantity" />
                           <asp:BoundField DataField="Effectivedate" HeaderText="Effective Date" />
                           <asp:BoundField DataField="Expirydate" HeaderText="Expiry Date" />
                       </Columns>
                       <HeaderStyle BackColor="#424242" CssClass="headerstyle" ForeColor="White" />
                       <RowStyle CssClass="rowstyle" />
                   </asp:GridView>
                 </td>


                 <td colspan="3">&nbsp;</td>


           </tr>
               
            <tr>
                <td colspan="1">&nbsp;</td>
                <td colspan="3">&nbsp;</td>
            </tr>
            <tr>
                <td colspan="1">
                    <dx:ASPxLabel ID="ASPxLabel74" runat="server" Font-Names="Cambria" Font-Size="Medium" Text="Request Details" Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                <td colspan="3">&nbsp;</td>
            </tr>
            <tr>
                <td colspan="1">
                    <asp:GridView ID="grdTranShareholder0" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" DataKeyNames="id" EmptyDataText="No Relevant Data Found" ForeColor="Black" GridLines="Vertical" Height="16px" Width="99%">
                        <PagerSettings FirstPageText="First" LastPageText="Last" NextPageText="Next" PreviousPageText="Previous" />
                        <AlternatingRowStyle CssClass="altrowstyle" />
                        <Columns>
                            <asp:BoundField DataField="security" HeaderText="Security Type" />
                            <asp:BoundField DataField="interestrate" HeaderText="Interest Rate" />
                            <asp:BoundField DataField="servicecharges" HeaderText="Service Charge" />
                            <asp:BoundField DataField="lendingperiod" HeaderText="Period" />
                            <asp:BoundField DataField="miniamount" HeaderText="Min Amount" />
                            <asp:BoundField DataField="maxiamount" HeaderText="Max Amount" />
                          
                        </Columns>
                        <HeaderStyle BackColor="#424242" CssClass="headerstyle" ForeColor="White" />
                        <RowStyle CssClass="rowstyle" />
                    </asp:GridView>
                </td>
                <td colspan="3">&nbsp;</td>
            </tr>
            <tr>
                <td align="center" colspan="4">
                    <dx:ASPxButton ID="ASPxButton1" runat="server" style="height: 23px" Text="save" Theme="BlackGlass">
                    </dx:ASPxButton>
                    &nbsp;</td>
            </tr>
               
        </table>

    </asp:panel>
                 
</asp:Panel>
  
</div>
</asp:Content>

