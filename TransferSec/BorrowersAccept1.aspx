<%@ Page Language="VB" MasterPageFile="~/CDSUser.master" AutoEventWireup="false" CodeFile="BorrowersAccept1.aspx.vb" Inherits="TransferSec_BorrowersAccept1" title="BorrowersAccept" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<%@ Register assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxTabControl" tagprefix="dx1" %>
<asp:Content id="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
    <asp:Panel id="Panel1" runat="server" Width="100%" Font-Names="Arial" Font-Size="Medium" BackColor="White">
    
        <table width ="100%">
            <tr>
                   <td style ="text-align :left;" align="left">
                       <dx:ASPxLabel ID="ASPxLabel1" runat="server" Text="Lending And Borrowing&gt;&gt;Borrowers Acceptance" Font-Names="Cambria" Font-Size="Small" Theme="PlasticBlue"></dx:ASPxLabel>

                   </td>
            </tr>
        </table>
          <asp:panel id="Panel3" runat="server" GroupingText="Search" Font-Names="Cambria">
        <table width="100%">
            <tr>
                    <td valign="top" style="width:260px" colspan ="1">

                        <dx:ASPxLabel ID="ASPxLabel84" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Pending Pledges" Theme="Glass">
                        </dx:ASPxLabel>

                    </td>
                <td>
                    <dx:ASPxListBox ID="lstNameSearch" runat="server" AutoPostBack="True" Theme="Glass" ValueType="System.String" Width="710px">
                    </dx:ASPxListBox>
                    </td>

            </tr>
            <tr>
                    <td colspan ="1">
                    </td>
                <td>
                    <dx:ASPxLabel ID="lblClientID" runat="server" Font-Names="Cambria" Font-Size="Small" Theme="Glass">
                    </dx:ASPxLabel>
                    </td>

            </tr>
        
        </table>

    </asp:panel>
        <asp:panel id="Panel8" runat="server" GroupingText="Personal Details" Font-Names="Cambria">
        <table width="100%">
            <tr>
                <td colspan ="1" style="width:260px">
                    <dx:ASPxLabel ID="ASPxLabel25" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Account No." Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                <td colspan ="1">
                    <dx:ASPxTextBox ID="txtClientId" runat="server" ReadOnly="true" Theme="BlackGlass" Width="250px">
                    </dx:ASPxTextBox>
                </td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>
                

            </tr>
           <tr>
               <td style="width:120px" colspan ="1">
                   <dx:ASPxLabel ID="ASPxLabel26" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Account Name" Theme="Glass">
                   </dx:ASPxLabel>
               </td>
               <td colspan ="7">
                   <dx:ASPxTextBox ID="txtSurname" runat="server" ReadOnly="true" Theme="BlackGlass" Width="558px" Height="19px">
                   </dx:ASPxTextBox>
               </td>

           </tr>
            <tr>
                    <td colspan ="1">
                        <dx:ASPxLabel ID="ASPxLabel30" runat="server" Font-Names="Cambria" Font-Size="Small" Text="CNIC" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                <td colspan ="1">
                    <dx:ASPxTextBox ID="txtIdno" runat="server" ReadOnly="true" Theme="BlackGlass" Width="250px">
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
                        <dx:ASPxLabel ID="ASPxLabel68" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Credit Limit" Theme="Glass" Visible="False">
                        </dx:ASPxLabel>
                    </td>
                <td colspan ="1">
                    <dx:ASPxTextBox ID="txtCreditLimit" runat="server" ReadOnly="true" Theme="BlackGlass" Width="250px" Visible="False">
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
        <asp:Panel ID="Panel2" runat="server" Font-Names="Cambria" GroupingText="Borrowing Request">
            <table width="100%">
                <tr>
                    <td colspan="1">
                        <dx:ASPxLabel ID="ASPxLabel2" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Collateral" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td colspan="1">
                        <dx:ASPxComboBox ID="cmbCompany" runat="server" AutoPostBack="True" ReadOnly="true" Theme="BlackGlass" ValueType="System.String" Width="250px">
                        </dx:ASPxComboBox>
                    </td>
                    <td colspan="1">
                        <dx:ASPxLabel ID="ASPxLabel69" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Available Quantity" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td colspan="1" style="width: 247px">
                        <dx:ASPxTextBox ID="txtavailableQuantity" runat="server" ReadOnly="true" Theme="BlackGlass" Width="250px">
                        </dx:ASPxTextBox>
                    </td>
                    <td colspan="1">&nbsp;</td>
                    <td colspan="1"></td>
                    <td colspan="1"></td>
                    <td colspan="1"></td>
                </tr>
                <tr>
                    <td colspan="1" style="height: 32px">
                        <dx:ASPxLabel ID="ASPxLabel75" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Indicative Commodity Price" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td colspan="1" style="height: 32px">
                        <dx:ASPxTextBox ID="txtshareprice" runat="server" AutoPostBack="True" ReadOnly="true" Theme="BlackGlass" Width="250px">
                        </dx:ASPxTextBox>
                    </td>
                    <td colspan="1" style="height: 32px">
                        <dx:ASPxLabel ID="ASPxLabel78" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Collateral Value" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td colspan="1" style="height: 32px; width: 247px;">
                        <dx:ASPxTextBox ID="txtcollateralvalue" runat="server" ReadOnly="True" Theme="BlackGlass" Width="250px">
                        </dx:ASPxTextBox>
                    </td>
                    <td colspan="1" style="height: 32px"></td>
                    <td colspan="1" style="height: 32px"></td>
                    <td colspan="1" style="height: 32px"></td>
                    <td colspan="1" style="height: 32px"></td>
                </tr>
                <tr>
                    <td colspan="1">
                        <dx:ASPxLabel ID="ASPxLabel85" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Preferred Financier" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td colspan="1">
                        <dx:ASPxTextBox ID="txtfinancier" runat="server" AutoPostBack="True" ReadOnly="true" Theme="BlackGlass" Width="250px">
                        </dx:ASPxTextBox>
                    </td>
                    <td colspan="1">
                        <dx:ASPxLabel ID="ASPxLabel72" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Amount Required" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td colspan="1" style="width: 247px">
                        <dx:ASPxTextBox ID="txtquantity" runat="server" ReadOnly="true" Theme="BlackGlass" Width="250px">
                        </dx:ASPxTextBox>
                    </td>
                    <td colspan="1">&nbsp;</td>
                    <td colspan="1">&nbsp;</td>
                    <td colspan="1">&nbsp;</td>
                    <td colspan="1">&nbsp;</td>
                </tr>
                <tr>
                    <td colspan="1">
                        <dx:ASPxLabel ID="ASPxLabel44" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Total Remaining Charges" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td colspan="1">
                        <dx:ASPxTextBox ID="txtaccumulatedcharges" runat="server" Height="19px" ReadOnly="True" Theme="BlackGlass" Width="250px">
                        </dx:ASPxTextBox>
                    </td>
                    <td colspan="1">
                        <dx:ASPxLabel ID="ASPxLabel79" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Application Date" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td colspan="1" style="width: 247px">
                        <dx:ASPxTextBox ID="txtcapturedate" runat="server" AutoPostBack="True" ReadOnly="true" Theme="BlackGlass" Width="250px">
                        </dx:ASPxTextBox>
                    </td>
                    <td colspan="1">&nbsp;</td>
                    <td colspan="1">&nbsp;</td>
                    <td colspan="1">&nbsp;</td>
                    <td colspan="1">&nbsp;</td>
                </tr>
                <tr>
                    <td colspan="1">
                        <dx:ASPxLabel ID="ASPxLabel46" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Other Charges" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td colspan="1">
                        <table class="dxflInternalEditorTable_iOS">
                            <tr>
                                <td style="width: 228px">
                                    <dx:ASPxTextBox ID="txtothercharges" runat="server" Height="19px" ReadOnly="True" Theme="BlackGlass" Width="250px">
                                    </dx:ASPxTextBox>
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                        </table>
                    </td>
                    <td colspan="1">
                        &nbsp;</td>
                    <td colspan="1" style="width: 247px">
                        &nbsp;</td>
                    <td colspan="1">&nbsp;</td>
                    <td colspan="1">&nbsp;</td>
                    <td colspan="1">&nbsp;</td>
                    <td colspan="1">&nbsp;</td>
                </tr>
                <tr>
                    <td align="center" colspan="8">
                        <table class="dxflInternalEditorTable_Glass">
                            <tr>
                                <td align="left" style="width: 125px">
                                    <dx:ASPxLabel ID="ASPxLabel70" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Effective Date" Theme="Glass" Visible="False">
                                    </dx:ASPxLabel>
                                    <dx:ASPxLabel ID="ASPxLabel71" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Maturity Date" Theme="Glass" Visible="False">
                                    </dx:ASPxLabel>
                                    <dx:ASPxLabel ID="ASPxLabel82" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Tenure" Theme="Glass" Visible="False">
                                    </dx:ASPxLabel>
                                </td>
                                <td align="left">
                                    <dx:ASPxDateEdit ID="txtEffectiveDate" runat="server" ReadOnly="true" Theme="Aqua" Visible="False" Width="250px">
                                    </dx:ASPxDateEdit>
                                    <dx:ASPxDateEdit ID="txtExpiryDate" runat="server" ReadOnly="true" Theme="Aqua" Visible="False" Width="250px">
                                    </dx:ASPxDateEdit>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="2">
                                    <dx:ASPxButton ID="ASPxButton9" runat="server" Text="Approve" Theme="BlackGlass">
                                    </dx:ASPxButton>
                                    &nbsp; &nbsp;</td>
                            </tr>
                            <tr>
                                <td align="center" colspan="2">
                                    <dx:ASPxLabel ID="ASPxLabel83" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Service Fee" Theme="Glass" Visible="False">
                                    </dx:ASPxLabel>
                                    <dx:ASPxTextBox ID="txtservicefee" runat="server" AutoPostBack="True " ReadOnly="true" Theme="BlackGlass" Visible="False" Width="250px">
                                    </dx:ASPxTextBox>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </asp:Panel>
        <asp:panel id="Panel11" runat="server" GroupingText="Lending Pool" Font-Names="Cambria" Visible="False">
        <table width="810px">
            <tr>
                    <td colspan ="2" align="left">
                        <dx:ASPxLabel ID="ASPxLabel66" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Lenders" Theme="Glass" Visible="False">
                        </dx:ASPxLabel>
                        <dx:ASPxLabel ID="ASPxLabel80" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Monthly Instalment" Theme="Glass" Visible="False">
                        </dx:ASPxLabel>
                        <dx:ASPxTextBox ID="txtmonthlyinstalment" runat="server" AutoPostBack="True" ReadOnly="true" Theme="BlackGlass" Visible="False" Width="250px">
                        </dx:ASPxTextBox>
                        <dx:ASPxLabel ID="ASPxLabel81" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Total" Theme="Glass" Visible="False">
                        </dx:ASPxLabel>
                        <dx:ASPxTextBox ID="txttotal" runat="server" AutoPostBack="True" ReadOnly="true" Theme="BlackGlass" Width="250px">
                        </dx:ASPxTextBox>
                        <dx:ASPxTextBox ID="txttenure" runat="server" AutoPostBack="True" ReadOnly="true" Theme="BlackGlass" Visible="False" Width="250px">
                        </dx:ASPxTextBox>
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

