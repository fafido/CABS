<%@ Page Language="VB" MasterPageFile="~/CDSUser.master" AutoEventWireup="false" CodeFile="CorpEnquiries.aspx.vb" Inherits="Corp_Enquiries" title="Corporate Action Enquiries" %>
<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>

<asp:Content id="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Panel id="Panel1" Width="100%" runat="server" ScrollBars="Horizontal" Font-Names="Cambria" BackColor="White" GroupingText="Corporate Action Enquiries">
       <table style="width:80%">
           <tr id="Tr1" runat="server">
                <td colspan="6">
                    <dx:ASPxLabel ID="ASPxLabel1" runat="server" Font-Names="Cambria" Font-Size="Small" Text="" Theme="Glass">
                    </dx:ASPxLabel>
                   <hr/>
                </td>
            </tr> 
           <tr>
                <td colspan="6">
                    <dx:ASPxLabel ID="ASPxLabel119" runat="server" Font-Names="Cambria" Font-Size="Small" Font-Bold="true" Text="Search Account" Theme="Glass">
                    </dx:ASPxLabel>
                   <hr/>
                </td>
            </tr>
            <tr>
                <td style="width: 208px">
                    <dx:ASPxLabel ID="ASPxLabel8" runat="server" Text="Client Name/ID No./Account No." Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                <td style="width: 212px">
                    <dx:ASPxTextBox ID="txtnamesearch" runat="server" BackColor="White" Theme="BlackGlass" Width="250px">
                    </dx:ASPxTextBox>
                </td>
                <td style="width: 208px">
                    <dx:ASPxButton ID="ASPxButton11" ValidationGroup="saerch" runat="server" Text=">>" Theme="BlackGlass">
                    </dx:ASPxButton>
                </td>
            </tr>
            <tr>
                <td style="width: 208px"></td>
                <td style="width: 212px">
                    <dx:ASPxListBox ID="lstNameSearch" runat="server" AutoPostBack="True" Theme="BlackGlass" ValueType="System.String" Width="250px">
                    </dx:ASPxListBox>
                </td>
            </tr>
            <tr>
                <td colspan="6">
                    <dx:ASPxLabel ID="ASPxLabel141" runat="server" Font-Names="Cambria" Font-Size="Small" Font-Bold="true" Text="" Theme="Glass">
                    </dx:ASPxLabel>
                   <hr/>
                </td>
            </tr>
           <tr id="Panel13a" runat="server">
                <td style="width: 208px">
                    <dx:ASPxLabel ID="ASPxLabel30" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Corporate Event" Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                <td style="width: 212px">
                    <dx:ASPxComboBox ID="cmbEvent" runat="server" Theme="Glass" Width="250px"  CallbackPageSize="15" EnableCallbackMode="True" DropDownStyle="DropDownList"  IncrementalFilteringMode="Contains"  AnimationType="Slide" AutoPostBack="True">
                        <Items>
                            <dx:ListEditItem Text="All" Value="All" /> 
                            <dx:ListEditItem Text="Dividend" Value="Dividend" /> 
                            <dx:ListEditItem Text="Rights" Value="Rights" /> 
                            <dx:ListEditItem Text="Bonus" Value="Bonus" /> 
                            <dx:ListEditItem Text="Split" Value="Split" /> 
                            <dx:ListEditItem Text="Consolidation" Value="Consolidation" />
                            <dx:ListEditItem Text="Merger" Value="Merger" />
                        </Items>
                    </dx:ASPxComboBox>
                </td>
                <td style="width: 208px"></td>
                <td style="width: 212px"></td>
           </tr>
           <tr id="Tr7div" runat="server" visible ="false">
                <td colspan="6">
                    <dx:ASPxLabel ID="ASPxLabel7" runat="server" Font-Names="Cambria" Font-Size="Small" Font-Bold="true" Text="Dividends - Cash" Theme="Glass">
                    </dx:ASPxLabel>
                   <hr/>
                </td>
            </tr>
            <tr id="Panel001Div" runat="server" visible ="false">
                <td colspan="6">
                  <dx:ASPxGridView ID="grdDividend" SettingsPager-Mode="ShowAllRecords" runat="server" Theme="Glass" Width="100%">
                        <SettingsPager Visible="False">
                        </SettingsPager>
                    </dx:ASPxGridView>
                </td>
           </tr>
           <tr id="Tr8div" runat="server" visible ="false">
                <td colspan="6">
                    <dx:ASPxLabel ID="ASPxLabel9" runat="server" Font-Names="Cambria" Font-Size="Small" Font-Bold="true" Text="Dividends - Scrip" Theme="Glass">
                    </dx:ASPxLabel>
                   <hr/>
                </td>
            </tr>
            <tr id="Panel001DivScrip" runat="server" visible ="false">
                <td colspan="6">
                  <dx:ASPxGridView ID="grdDividendScrip" SettingsPager-Mode="ShowAllRecords" runat="server" Theme="Glass" Width="100%">
                        <SettingsPager Visible="False">
                        </SettingsPager>
                    </dx:ASPxGridView>
                </td>
           </tr>
           <tr id="Tr9div" runat="server" visible ="false">
                <td colspan="6">
                    <dx:ASPxLabel ID="ASPxLabel10" runat="server" Font-Names="Cambria" Font-Size="Small" Font-Bold="true" Text="Dividends - Specie" Theme="Glass">
                    </dx:ASPxLabel>
                   <hr/>
                </td>
            </tr>
            <tr id="Panel001DivSpecie" runat="server" visible ="false">
                <td colspan="6">
                  <dx:ASPxGridView ID="grdDividendSpecie" SettingsPager-Mode="ShowAllRecords" runat="server" Theme="Glass" Width="100%">
                        <SettingsPager Visible="False">
                        </SettingsPager>
                    </dx:ASPxGridView>
                </td>
           </tr>
           <tr id="Tr6rights" runat="server" visible ="false">
                <td colspan="6">
                    <dx:ASPxLabel ID="ASPxLabel6" runat="server" Font-Names="Cambria" Font-Size="Small" Font-Bold="true" Text="Rights" Theme="Glass">
                    </dx:ASPxLabel>
                   <hr/>
                </td>
            </tr>
            <tr id="Panel002Rights" runat="server" visible ="false">
                <td colspan="6">
                  <dx:ASPxGridView ID="grdRights" SettingsPager-Mode="ShowAllRecords" runat="server" Theme="Glass" Width="100%">
                        <SettingsPager Visible="False">
                        </SettingsPager>
                    </dx:ASPxGridView>
                </td>
           </tr>
           <tr id="Tr5bonus" runat="server" visible ="false">
                <td colspan="6">
                    <dx:ASPxLabel ID="ASPxLabel5" runat="server" Font-Names="Cambria" Font-Size="Small" Font-Bold="true" Text="Bonus" Theme="Glass">
                    </dx:ASPxLabel>
                   <hr/>
                </td>
            </tr>
            <tr id="Panel003Bonus" runat="server" visible ="false">
                <td colspan="6">
                  <dx:ASPxGridView ID="grdBonus" SettingsPager-Mode="ShowAllRecords" runat="server" Theme="Glass" Width="100%">
                        <SettingsPager Visible="False">
                        </SettingsPager>
                    </dx:ASPxGridView>
                </td>
           </tr>
           <tr id="Tr4split" runat="server" visible ="false">
                <td colspan="6">
                    <dx:ASPxLabel ID="ASPxLabel4" runat="server" Font-Names="Cambria" Font-Size="Small" Font-Bold="true" Text="Split" Theme="Glass">
                    </dx:ASPxLabel>
                   <hr/>
                </td>
            </tr>
            <tr id="Panel004Split" runat="server" visible ="false">
                <td colspan="6">
                  <dx:ASPxGridView ID="grdSplit" SettingsPager-Mode="ShowAllRecords" runat="server" Theme="Glass" Width="100%">
                        <SettingsPager Visible="False">
                        </SettingsPager>
                    </dx:ASPxGridView>
                </td>
           </tr>
           <tr id="Tr3consol" runat="server" visible ="false">
                <td colspan="6">
                    <dx:ASPxLabel ID="ASPxLabel3" runat="server" Font-Names="Cambria" Font-Size="Small" Font-Bold="true" Text="Consolidation" Theme="Glass">
                    </dx:ASPxLabel>
                   <hr/>
                </td>
            </tr>
            <tr id="Panel005Consol" runat="server" visible ="false">
                <td colspan="6">
                  <dx:ASPxGridView ID="grdConsol" SettingsPager-Mode="ShowAllRecords" runat="server" Theme="Glass" Width="100%">
                        <SettingsPager Visible="False">
                        </SettingsPager>
                    </dx:ASPxGridView>
                </td>
           </tr>
           <tr id="Tr11merge" runat="server" visible ="false">
                <td colspan="6">
                    <dx:ASPxLabel ID="ASPxLabel26" runat="server" Font-Names="Cambria" Font-Size="Small" Font-Bold="true" Text="Merger" Theme="Glass">
                    </dx:ASPxLabel>
                   <hr/>
                </td>
            </tr>
            <tr id="Panel006Merger" runat="server" visible ="false">
                <td colspan="6">
                  <dx:ASPxGridView ID="grdMerger" SettingsPager-Mode="ShowAllRecords" runat="server" Theme="Glass" Width="100%">
                        <SettingsPager Visible="False">
                        </SettingsPager>
                    </dx:ASPxGridView>
                </td>
           </tr>
           <tr id="Tr2" runat="server">
                <td colspan="6">
                    <dx:ASPxLabel ID="ASPxLabel2" runat="server" Font-Names="Cambria" Font-Size="Small" Text="" Theme="Glass">
                    </dx:ASPxLabel>
                   <hr/>
                </td>
            </tr>
        </table> 
      </asp:Panel>
</asp:Content>

