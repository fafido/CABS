<%@ Page Language="VB" MasterPageFile="~/CDSUser.master" AutoEventWireup="false" CodeFile="Instr.aspx.vb" Inherits="Corp_BondInstr" title="Instruction" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>

<asp:Content id="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Panel id="Panel1" runat="server" Width="90%" Font-Names="Cambria" BackColor="White" GroupingText="Instruction">
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
                        <dx:ASPxLabel ID="ASPxLabel73" runat="server" ForeColor="Red" Text="*">
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
           <tr id="Tr6" runat="server">
                    <td style="width: 208px">
                        <dx:ASPxLabel ID="ASPxLabel2" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Edit Existing" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td style="width: 212px">
                       <asp:CheckBox ID="chkEdit" runat="server" AutoPostBack="True" />
                    </td>
                  </tr>
           <tr id="paneldivList" runat="server" visible="false">
                    <td style="width: 208px">
                        <dx:ASPxLabel ID="ASPxLabel38" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Select Existing Div No." Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td style="width: 212px">
                    <dx:ASPxListBox ID="lstDivs" runat="server" AutoPostBack="True" Theme="BlackGlass" ValueType="System.String" Width="250px">
                    </dx:ASPxListBox>
                    </td>
                  </tr>
           <tr id="Tr5" runat="server">
                    <td style="width: 208px">
                        <dx:ASPxLabel ID="ASPxLabel72d" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Instruction No." Theme="Glass">
                        </dx:ASPxLabel>
                        <dx:ASPxLabel ID="ASPxLabel32" runat="server" ForeColor="Red" Text="*">
                        </dx:ASPxLabel>
                    </td>
                    <td style="width: 212px">
                        <dx:ASPxTextBox ID="txtDivNo" runat="server" Enabled ="false" BackColor="White" Theme="Glass" Width="250px">
                        </dx:ASPxTextBox>
                    </td>
                    <td style="width: 212px">
                        <dx:ASPxButton ID="btnDivsearch" runat="server" Text=">>" Visible="false" Theme="Glass">
                            </dx:ASPxButton>
                    </td>
                  </tr>
           <tr id="Panel8e" runat="server">
                    <td style="width: 208px">
                        <dx:ASPxLabel ID="ASPxLabel5" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Instruction Type" Theme="Glass">
                        </dx:ASPxLabel>
                        <dx:ASPxLabel ID="ASPxLabel33" runat="server" ForeColor="Red" Text="*">
                        </dx:ASPxLabel>
                    </td>
                    <td style="width: 212px">
                        <dx:ASPxComboBox ID="cmbDividendType" AutoPostBack="false" runat="server" Theme="Glass" Width="250px"  CallbackPageSize="15" EnableCallbackMode="True" DropDownStyle="DropDownList"  IncrementalFilteringMode="Contains"  AnimationType="Slide">
                            <Items>
                                <dx:ListEditItem Text="" Value="" />
                                <dx:ListEditItem Text="Interest Payment" Value="Interest Payment" />
                                <dx:ListEditItem Text="Capital Redemption" Value="Capital Redemption" />
                            </Items>
                        </dx:ASPxComboBox>
                    </td>
                </tr>
           <tr id="Panel8b" runat="server">
                    <td style="width: 208px">
                        <dx:ASPxLabel ID="ASPxLabel29" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Date Announced" Theme="Glass">
                        </dx:ASPxLabel>
                        <dx:ASPxLabel ID="ASPxLabel6" runat="server" ForeColor="Red" Text="*">
                        </dx:ASPxLabel>
                    </td>
                    <td style="width: 212px">
                        <dx:ASPxDateEdit ID="txtDateCreated" runat="server" EditFormat="Custom" EditFormatString="dd MMMM yyyy" Theme="BlackGlass" Width="250px">
                        </dx:ASPxDateEdit>
                    </td>
                </tr>
           <tr id="Tr7" runat="server">
                    <td style="width: 208px">
                        <dx:ASPxLabel ID="ASPxLabel7" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Record Date (LDR)" Theme="Glass">
                        </dx:ASPxLabel>
                        <dx:ASPxLabel ID="ASPxLabel8" runat="server" ForeColor="Red" Text="*">
                        </dx:ASPxLabel>
                    </td>
                    <td style="width: 212px">
                        <dx:ASPxDateEdit ID="txtDateClose" runat="server" EditFormat="Custom" EditFormatString="dd MMMM yyyy" Theme="BlackGlass" Width="250px">
                        </dx:ASPxDateEdit>
                    </td>
                </tr>
           <tr id="Tr8" runat="server">
                    <td style="width: 208px">
                        <dx:ASPxLabel ID="ASPxLabel15" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Payment Date" Theme="Glass">
                        </dx:ASPxLabel>
                        <dx:ASPxLabel ID="ASPxLabel16" runat="server" ForeColor="Red" Text="*">
                        </dx:ASPxLabel>
                    </td>
                    <td style="width: 212px">
                        <dx:ASPxDateEdit ID="txtPaymentdate" runat="server" EditFormat="Custom" EditFormatString="dd MMMM yyyy" Theme="BlackGlass" Width="250px">
                        </dx:ASPxDateEdit>
                    </td>
                </tr>
           <tr id="Tr9" runat="server">
                    <td style="width: 208px">
                        <dx:ASPxLabel ID="ASPxLabel17" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Year Ended/Ending" Theme="Glass">
                        </dx:ASPxLabel>
                        <dx:ASPxLabel ID="ASPxLabel18" runat="server" ForeColor="Red" Text="*">
                        </dx:ASPxLabel>
                    </td>
                    <td style="width: 212px">
                        <dx:ASPxDateEdit ID="txtYearEnding" runat="server" EditFormat="Custom" EditFormatString="dd MMMM yyyy" Theme="BlackGlass" Width="250px">
                        </dx:ASPxDateEdit>
                    </td>
                </tr>
           <tr id="Tr2" runat="server">
                    <td style="width: 208px">
                        <dx:ASPxLabel ID="ASPxLabel24" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Tax Rate" Theme="Glass">
                        </dx:ASPxLabel>
                        <dx:ASPxLabel ID="ASPxLabel25" runat="server" ForeColor="Red" Text="*">
                        </dx:ASPxLabel>
                    </td>
                    <td style="width: 212px">
                        <dx:ASPxTextBox ID="txtTaxRate" runat="server" BackColor="White" Theme="Glass" Width="250px">
                        </dx:ASPxTextBox>
                    </td>
                </tr>
           <tr id="Tr10" runat="server">
                    <td style="width: 208px">
                        <dx:ASPxLabel ID="ASPxLabel12" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Round" Theme="Glass">
                        </dx:ASPxLabel>
                        <dx:ASPxLabel ID="ASPxLabel27" runat="server" ForeColor="Red" Text="*">
                        </dx:ASPxLabel>
                    </td>
                    <td style="width: 212px">
                        <dx:ASPxComboBox ID="cmbRound" runat="server" Theme="Glass" Width="250px"  CallbackPageSize="15" EnableCallbackMode="True" DropDownStyle="DropDownList"  IncrementalFilteringMode="Contains"  AnimationType="Slide">
                            <Items>
                                <dx:ListEditItem Text="" Value="" />
                                <dx:ListEditItem Text="Middle" Value="M" />
                                <dx:ListEditItem Text="Down" Value="D" />
                                <dx:ListEditItem Text="Up" Value="U" />
                            </Items>
                        </dx:ASPxComboBox>
                    </td>
                </tr>
           <tr id="divCashScrip" runat="server" visible="false"> 
                    <td style="width: 208px">
                        <dx:ASPxLabel ID="ASPxLabel36" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Currency" Theme="Glass">
                        </dx:ASPxLabel>
                        <dx:ASPxLabel ID="ASPxLabel37" runat="server" ForeColor="Red" Text="*">
                        </dx:ASPxLabel>
                    </td>
                    <td style="width: 212px">
                        <dx:ASPxComboBox ID="cmbCurrency" Enabled="false" runat="server" Theme="Glass" Width="250px"  CallbackPageSize="15" EnableCallbackMode="True" DropDownStyle="DropDownList"  IncrementalFilteringMode="Contains"  AnimationType="Slide">
                            <Items>
                                <dx:ListEditItem Text="" Value="" />
                            </Items>
                        </dx:ASPxComboBox>
                    </td>
                </tr>
           <tr id="Tr11" runat="server">
                <td colspan="6">
                    <dx:ASPxLabel ID="ASPxLabel26" runat="server" Font-Names="Cambria" Font-Size="Small" Text="" Theme="Glass">
                    </dx:ASPxLabel>
                   <hr/>
                </td>
            </tr>
           <tr id="PanelSAVE" runat="server">
                        <td style="width:208px"></td>
                        <td style="width:212px">
                            &nbsp;<dx:ASPxButton ID="btnSave" runat="server" Text="Save" Theme="Glass">
                            </dx:ASPxButton>
                        </td>
                </tr>
           <tr id="panelUPDATE" runat="server" visible="false">
                        <td style="width:208px"></td>
                        <td style="width:212px">
                            &nbsp;<dx:ASPxButton ID="btnUpdate" runat="server" Text="Update" Theme="Glass">
                            </dx:ASPxButton>
                        </td>
                </tr>
        </table> 
      </asp:Panel>
</asp:Content>

