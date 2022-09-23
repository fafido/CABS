<%@ Page Language="VB" MasterPageFile="~/CDSUser.master" AutoEventWireup="false" CodeFile="ApproveNewBond.aspx.vb" Inherits="ApproveNewBond" title="Approve New Bond" %>

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
                       <dx:ASPxLabel ID="ASPxLabel1" runat="server" Text="Fixed Income&gt;Approve Bond" Font-Names="Cambria" Font-Size="Small" Theme="PlasticBlue"></dx:ASPxLabel>

                   </td>
            </tr>
        </table>
        <asp:Panel ID="Panel5" runat="server" Font-Names="Cambria" GroupingText="Bonds">
            <table width="100%">
                <tr>
                    <td>
                        <table class="dxflInternalEditorTable_Glass">
                            <tr>
                                <td colspan="5">
                                    <dx:ASPxGridView ID="ASPxGridView2" runat="server" AutoGenerateColumns="true" Caption="Pending Transactions" KeyFieldName="ID" Theme="Glass" Width="100%">
                                        <SettingsPager Visible="False">
                                        </SettingsPager>
                                        <Columns>
                                            <dx:GridViewDataColumn Caption="" VisibleIndex="0">
                                                <DataItemTemplate>
                                                    <asp:LinkButton ID="ViewDoc1" runat="server" CommandArgument='<%# Eval("ID") %>' CommandName="Details" Text="Details">
                                                              </asp:LinkButton>
                                                </DataItemTemplate>
                                            </dx:GridViewDataColumn>
                                            <dx:GridViewDataColumn Caption="Issuer" FieldName="Issuer" Settings-AllowAutoFilter="True" Settings-AutoFilterCondition="Contains">
                                            </dx:GridViewDataColumn>
                                            <dx:GridViewDataTextColumn FieldName="Series" Name="Series" Settings-AutoFilterCondition="Contains">
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn FieldName="Type" Name="Type" Settings-AutoFilterCondition="Contains">
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn FieldName="DayCountBasis" Name="DayCountBasis" Settings-AutoFilterCondition="Equals">
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn FieldName="FaceValue" Name="FaceValue" Settings-AutoFilterCondition="Equals">
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn FieldName="Currency" Name="Currency" Settings-AutoFilterCondition="Equals">
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn FieldName="Rate" Name="Rate" Settings-AutoFilterCondition="Equals">
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn FieldName="IssueDate" Name="IssueDate" Settings-AutoFilterCondition="Equals">
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn FieldName="MaturityDate" Name="MaturityDate" Settings-AutoFilterCondition="Equals">
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn FieldName="Status" Name="Status" Settings-AutoFilterCondition="Equals">
                                            </dx:GridViewDataTextColumn>
                                        </Columns>
                                    </dx:ASPxGridView>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="5"><hr /></td>
                            </tr>
                            <tr>
                                <td>
                                    <dx:ASPxLabel ID="ASPxLabel39" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Issuer" Theme="Glass">
                                    </dx:ASPxLabel>
                                </td>
                                <td>
                                    <dx:ASPxComboBox ID="cmbIssuer" runat="server" Height="23px" Width="250px">
                                        <ValidationSettings>
                                            <RequiredField IsRequired="True" />
                                        </ValidationSettings>
                                    </dx:ASPxComboBox>
                                </td>
                                <td>&nbsp;</td>
                                <td style="width: 152px">
                                    <dx:ASPxLabel ID="ASPxLabel7" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Series" Theme="Glass">
                                    </dx:ASPxLabel>
                                </td>
                                <td>
                                    <dx:ASPxTextBox ID="txtSeries" runat="server" Theme="Glass" Width="250px">
                                        <ValidationSettings>
                                            <RequiredField IsRequired="True" />
                                        </ValidationSettings>
                                    </dx:ASPxTextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <dx:ASPxLabel ID="ASPxLabel46" runat="server" Font-Names="Cambria" Font-Size="Small" Text="ISIN" Theme="Glass">
                                    </dx:ASPxLabel>
                                </td>
                                <td>
                                    <dx:ASPxTextBox ID="txtisin" runat="server" AutoPostBack="True" Height="23px" Theme="Glass" Width="250px">
                                 
                                           </dx:ASPxTextBox>
                                </td>
                                <td>&nbsp;</td>
                                <td style="width: 152px">
                                    <dx:ASPxLabel ID="ASPxLabel42" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Type" Theme="Glass">
                                    </dx:ASPxLabel>
                                </td>
                                <td>
                                    <dx:ASPxComboBox ID="cmbType" runat="server" AutoPostBack="True" Height="23px" Width="250px">
                                        <Items>
                                            <dx:ListEditItem Text="Corporate" Value="Corporate" />
                                            <dx:ListEditItem Text="Municipal" Value="Municipal" />
                                             <dx:ListEditItem Text="Government" Value="Government" />
                                            <dx:ListEditItem Text="Parastatal" Value="Parastatal" />
                                        </Items>
                                          <ValidationSettings>
                                <RequiredField IsRequired="True" />
                            </ValidationSettings>
                                    </dx:ASPxComboBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <dx:ASPxLabel ID="ASPxLabel25" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Face Value" Theme="Glass">
                                    </dx:ASPxLabel>
                                </td>
                                <td>
                                    <dx:ASPxTextBox ID="txtFaceValue" DisplayFormatString="n" runat="server" AutoPostBack="True" Height="23px" Theme="Glass" Width="250px">
                                     <ValidationSettings>
                                <RequiredField IsRequired="True" />
                            </ValidationSettings>
                                         </dx:ASPxTextBox>
                                </td>
                                <td>&nbsp;</td>
                                <td style="width: 152px">
                                    <dx:ASPxLabel ID="ASPxLabel43" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Coupon Rate(%)" Theme="Glass">
                                    </dx:ASPxLabel>
                                </td>
                                <td>
                                    <dx:ASPxTextBox ID="txtcoupnRate" runat="server" Height="23px" Theme="Glass" Width="250px">
                                     <ValidationSettings>
                                <RequiredField IsRequired="True" />
                            </ValidationSettings>
                                         </dx:ASPxTextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="height: 28px">
                                    <dx:ASPxLabel ID="ASPxLabel30" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Issue Date" Theme="Glass">
                                    </dx:ASPxLabel>
                                </td>
                                <td style="height: 28px">
                                    <dx:ASPxDateEdit ID="txtIssueDate" runat="server" Height="23px" Width="250px">
                                     <ValidationSettings>
                                <RequiredField IsRequired="True" />
                            </ValidationSettings>
                                         </dx:ASPxDateEdit>
                                </td>
                                <td style="height: 28px"></td>
                                <td style="width: 152px; height: 28px;">
                                    <dx:ASPxLabel ID="ASPxLabel32" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Maturity Date" Theme="Glass">
                                    </dx:ASPxLabel>
                                </td>
                                <td style="height: 28px">
                                    <dx:ASPxDateEdit ID="txtMaturityDate" runat="server"  Height="23px" Width="250px">
                                  <ValidationSettings>
                                <RequiredField IsRequired="True" />
                            </ValidationSettings>
                                            </dx:ASPxDateEdit>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <dx:ASPxLabel ID="ASPxLabel44" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Coupon Payments" Theme="Glass">
                                    </dx:ASPxLabel>
                                </td>
                                <td>
                                    <dx:ASPxComboBox ID="cmbannualcoupon" runat="server"  Height="23px" Width="250px">
                                        <Items>
                                            <dx:ListEditItem Text="Annual" Value="Annual" />
                                            <dx:ListEditItem Text="Semi-Annual" Value="Semi-Annual" />
                                            
                                        </Items>
                                          <ValidationSettings>
                                <RequiredField IsRequired="True" />
                            </ValidationSettings>
                                    </dx:ASPxComboBox>
                                </td>
                                <td>&nbsp;</td>
                                <td style="width: 152px">
                                    <dx:ASPxLabel ID="ASPxLabel62" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Day Count Basis" Theme="Glass">
                                    </dx:ASPxLabel>
                                </td>
                                <td>
                                    <dx:ASPxComboBox ID="cmbdaycountbasis" runat="server" Height="23px" Width="250px">
                                           <Items>
                                            <dx:ListEditItem Text="actual/360" Value="actual/360" />
                                            <dx:ListEditItem Text="actual/365" Value="actual/365" />
                                          
                                        </Items>
                                          <ValidationSettings>
                                <RequiredField IsRequired="True" />
                            </ValidationSettings>
                                    </dx:ASPxComboBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <dx:ASPxLabel ID="ASPxLabel63" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Currency" Theme="Glass">
                                    </dx:ASPxLabel>
                                </td>
                                <td>
                                    <dx:ASPxComboBox ID="cmbcurrency" runat="server"  Height="23px" Width="250px">
                                          <ValidationSettings>
                                <RequiredField IsRequired="True" />
                            </ValidationSettings>
                                    </dx:ASPxComboBox>
                                </td>
                                <td>&nbsp;</td>
                                <td style="width: 152px">&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    <dx:ASPxLabel ID="ASPxLabel36" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Description" Theme="Glass">
                                    </dx:ASPxLabel>
                                </td>
                                <td>
                                    <dx:ASPxMemo ID="txtDesc" runat="server" Height="71px" Width="250px">
                                    </dx:ASPxMemo>
                                </td>
                                <td>&nbsp;</td>
                                <td style="width: 152px">&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    <dx:ASPxLabel ID="ASPxLabel61" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Sinking Fund Calculation" Theme="Glass" Visible="False">
                                    </dx:ASPxLabel>
                                </td>
                                <td colspan="4">
                                    <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal" Visible="False">
                                        <asp:ListItem>Daily</asp:ListItem>
                                        <asp:ListItem>Weekly</asp:ListItem>
                                        <asp:ListItem>Monthly</asp:ListItem>
                                    </asp:RadioButtonList>
                                    <asp:Label ID="lbltransid" runat="server" Visible="False"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>&nbsp;</td>
                                <td colspan="4">
                                    <dx:ASPxGridView ID="ASPxGridView3" runat="server" AutoGenerateColumns="False" Caption="Payment Dates" Theme="Glass" Width="60%">
                                        <Columns>
                                            
                                            <dx:GridViewDataTextColumn FieldName="Code" Name="Series" ShowInCustomizationForm="True" VisibleIndex="2">
                                                <Settings AutoFilterCondition="Contains" />
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataColumn Caption="PaymentDate" FieldName="PaymentDate" ShowInCustomizationForm="True" VisibleIndex="1">
                                                <Settings AllowAutoFilter="True" AutoFilterCondition="Contains" />
                                            </dx:GridViewDataColumn>
                                            <dx:GridViewDataTextColumn FieldName="Amount" Name="Amount" ShowInCustomizationForm="True" VisibleIndex="3">
                                                <Settings AutoFilterCondition="Contains" />
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn FieldName="Details" Name="Details" ShowInCustomizationForm="True" VisibleIndex="3">
                                                <Settings AutoFilterCondition="Contains" />
                                            </dx:GridViewDataTextColumn>
                                        </Columns>
                                        <SettingsPager Visible="False">
                                        </SettingsPager>
                                    </dx:ASPxGridView>
                                </td>
                            </tr>
                            <tr>
                                <td>&nbsp;</td>
                                <td>
                                    &nbsp;<dx:ASPxButton ID="btnSaveTB1" runat="server" Text="Approve Bond" Theme="BlackGlass" Width="180px">
                                    </dx:ASPxButton>
                                    &nbsp;<dx:ASPxButton ID="btnSaveTB0" runat="server" Text="Refresh" Theme="BlackGlass">
                                    </dx:ASPxButton>
                                </td>
                                <td>&nbsp;</td>
                                <td style="width: 152px">&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td style="width: 152px">&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td colspan="5">
                                    <br />
                                    <dx:ASPxPopupControl ID="ASPxPopupControl1" runat="server" BackColor="#DDECFE" CloseAction="CloseButton" EnableCallbackAnimation="True" HeaderText="Add Payment Dates" ShowCollapseButton="True" ShowPageScrollbarWhenModal="True" ShowPinButton="True" Theme="Office2010Blue" Width="590px">
        <contentcollection>
<dx:PopupControlContentControl runat="server" SupportsDisabledAttribute="True">
    <dx:ASPxRoundPanel ID="ASPxRoundPanel6" runat="server" BackColor="White" ShowHeader="False" Width="100%">
        <panelcollection>
            <dx:PanelContent runat="server" SupportsDisabledAttribute="True">
                <table style="width: 100%">
                    <tr>
                        <td align="right" style="height: 31px">
                            <dx:ASPxLabel ID="ASPxLabel67" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Payment No" Theme="Glass">
                            </dx:ASPxLabel>
                        </td>
                        <td align="left" style="height: 31px">
                            <dx:ASPxTextBox ID="txtpaymentno" runat="server" AutoPostBack="True" Height="23px" ReadOnly="True" Theme="Glass" Width="250px">
                              <ValidationSettings>
                                <RequiredField IsRequired="True" />
                            </ValidationSettings>
                            </dx:ASPxTextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" style="height: 31px">
                            <dx:ASPxLabel ID="ASPxLabel64" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Payment Date" Theme="Glass">
                            </dx:ASPxLabel>
                        </td>
                        <td align="left" style="height: 31px">
                            <dx:ASPxDateEdit ID="txtpaymentdate" runat="server" AutoPostBack="True" Height="23px" Width="250px">
                            <ValidationSettings>
                                <RequiredField IsRequired="True" />
                            </ValidationSettings>
                                  </dx:ASPxDateEdit>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" style="height: 31px">
                            <dx:ASPxLabel ID="ASPxLabel65" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Amount" Theme="Glass">
                            </dx:ASPxLabel>
                        </td>
                        <td align="left" style="height: 31px">
                            <dx:ASPxTextBox ID="txtamount" runat="server" AutoPostBack="True" DisplayFormatString="n" Height="23px" ReadOnly="True" Theme="Glass" Width="250px">
                           <ValidationSettings>
                                <RequiredField IsRequired="True" />
                            </ValidationSettings>
                                   </dx:ASPxTextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" style="height: 31px">
                            <dx:ASPxLabel ID="ASPxLabel66" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Option " Theme="Glass">
                            </dx:ASPxLabel>
                        </td>
                        <td align="left" style="height: 31px">
                            <dx:ASPxComboBox ID="cmboption" runat="server" Height="23px" Width="250px" AutoPostBack="True">
                                <Items>
                                    <dx:ListEditItem Text="Exclude Capital" Value="Exclude Capital" />
                                    <dx:ListEditItem Text="Include Capital" Value="Include Capital" />
                                </Items>
                                  <ValidationSettings>
                                <RequiredField IsRequired="True" />
                            </ValidationSettings>
                            </dx:ASPxComboBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" style="height: 31px">
                            <dx:ASPxLabel ID="ASPxLabel68" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Capital Amount" Theme="Glass" Visible="False">
                            </dx:ASPxLabel>
                        </td>
                        <td align="left" style="height: 31px">
                            <table class="dxflInternalEditorTable">
                                <tr>
                                    <td style="width: 76px">
                                        <dx:ASPxTextBox ID="txtcapitalamount" runat="server" AutoPostBack="True" DisplayFormatString="n" Height="23px" ReadOnly="False" Theme="Glass" Width="250px" Visible="False">
                                            <ValidationSettings>
                                                <RequiredField IsRequired="True" />
                                            </ValidationSettings>
                                        </dx:ASPxTextBox>
                                    </td>
                                    <td style="width: 6px">%</td>
                                    <td>
                                        <dx:ASPxTextBox ID="txtcapitalpercentage" runat="server" AutoPostBack="True" DisplayFormatString="n" Height="23px" ReadOnly="False" Theme="Glass" Width="38px" Visible="False">
                                            <ValidationSettings>
                                                <RequiredField IsRequired="True" />
                                            </ValidationSettings>
                                        </dx:ASPxTextBox>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">&nbsp;</td>
                        <td align="left">
                            <dx:ASPxButton ID="btnSaveContract1" runat="server" CausesValidation="False" Text="Submit" Theme="Glass">
                            </dx:ASPxButton>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" colspan="2">
                            &nbsp;</td>
                    </tr>
                  
                  
                    <tr>
                        <td align="center" colspan="2">
                            <dx:ASPxButton ID="btnSaveTB" CausesValidation="False" runat="server" Text="Save Bond" Theme="BlackGlass">
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
                    </td>
                </tr>
            </table>
        </asp:Panel>
                       
</asp:Panel>
  
</div>
</asp:Content>

