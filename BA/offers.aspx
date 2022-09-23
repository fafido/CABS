<%@ Page Language="VB" MasterPageFile="~/CDSUser.master" AutoEventWireup="false" CodeFile="offers.aspx.vb" Inherits="BA_offers" title="Offers" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<asp:Content id="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
    <asp:Panel id="Panel1" runat="server" Width="840px" Font-Names="Arial" Font-Size="Medium" BackColor="White">
    
        <table width ="810px">
            <tr>
                   <td style ="text-align :left;" align="left">
                       <dx:ASPxLabel ID="ASPxLabel1" runat="server" Text="Bankers Acceptance&gt;&gt;Offers" Font-Names="Cambria" Font-Size="Small" Theme="PlasticBlue"></dx:ASPxLabel>

                   </td>
            </tr>
        </table>
        <asp:panel id="Panel2" runat="server" GroupingText="Search BA" Font-Names="Cambria">
        <table width="810px">
            <tr>
                <td colspan="1" style="height: 18px; width: 92px;">
                    &nbsp;</td>
                <td style="height: 18px; ">
                    &nbsp;</td>
            </tr>
            <tr>
                <td colspan="2" style="height: 18px; ">
                    <dx:ASPxLabel ID="ASPxLabel81" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Available Bids" Theme="iOS">
                    </dx:ASPxLabel>
                </td>
            </tr>
            <tr>
                <td colspan="2" style="height: 18px; " align="right">
                    <table class="auto-style1" style="width: 14%">
                        <tr>
                            <td>&nbsp;</td>
                            <td>
                                <dx:ASPxButton ID="ASPxButton2" runat="server" BackColor="#023E5A" Text="Bid Amount" Theme="BlackGlass">
                                </dx:ASPxButton>
                            </td>
                            <td>
                                <dx:ASPxButton ID="ASPxButton3" runat="server" BackColor="#023E5A" Text="Bid By" Theme="BlackGlass">
                                </dx:ASPxButton>
                            </td>
                            <td>
                                <dx:ASPxButton ID="ASPxButton4" runat="server" BackColor="#023E5A" Text="Bid Date" Theme="BlackGlass">
                                </dx:ASPxButton>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td colspan="2" align="right" align="center">
                    <asp:GridView ID="grdEvent0" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" CssClass="tablestyle" DataKeyNames="id" EmptyDataText="No Aavailable Bids" Font-Size="Small" ForeColor="Black" GridLines="None" Style="position: relative; top: 0px; left: 0px; width:100%; height: 3px;">
                        <PagerSettings FirstPageText="First" LastPageText="Last" NextPageText="Next" PreviousPageText="Previous" />
                        <AlternatingRowStyle CssClass="altrowstyle" />
                        <HeaderStyle BackColor="#023E5A" ForeColor="White" HorizontalAlign="Left" />
                        <RowStyle CssClass="rowstyle" />
                        <Columns>
                            <asp:BoundField DataField="BA_number" HeaderText="BA Number" />
                            <asp:BoundField DataField="company_name" HeaderText="Bid By" />
                            <asp:BoundField DataField="offer_date" HeaderText="Bid Date" />
                            <asp:BoundField DataField="discount_rate" HeaderText="Bid Discount(%)" />
                            <asp:BoundField DataField="Offer" HeaderText="Bid Amount" />
                             <asp:BoundField DataField="face_value" HeaderText="Full Amount" />
                            
                                                       <asp:CommandField EditText="Acce" SelectText="Accept Bid" ShowSelectButton="true">
                            <ItemStyle Font-Bold="True" Font-Italic="True" ForeColor="Red" HorizontalAlign="Right" />
                            </asp:CommandField>
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td align="left" align="center" colspan="2">
                    <asp:Panel ID="Panel3" runat="server" Visible="False">
                        <table class="auto-style1" style="width: 31%">
                            <tr>
                                <td colspan="2">
                                    <dx:ASPxLabel ID="ASPxLabel82" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Negotiate Offer" Theme="iOS">
                                    </dx:ASPxLabel>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 132px">
                                    <asp:Label ID="Label8" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Offer ID"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtofferid" runat="server" Enabled="False"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 132px">
                                    <asp:Label ID="Label9" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Offer Amount"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtofferamount" runat="server" Enabled="False"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 132px">
                                    <asp:Label ID="Label10" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Offered By"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtofferedby" runat="server" Enabled="False"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 132px">
                                    <asp:Label ID="Label11" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Counter Offer"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtcounteroffer" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="2">
                                    <table class="auto-style1">
                                        <tr>
                                            <td>
                                                <dx:ASPxButton ID="ASPxButton5" runat="server" BackColor="#023E5A" Height="21px" Text="Accept Offer" Theme="BlackGlass" Width="85px">
                                                </dx:ASPxButton>
                                            </td>
                                            <td>
                                                <dx:ASPxButton ID="ASPxButton6" runat="server" BackColor="#023E5A" Height="21px" Text="Counter Offer" Theme="BlackGlass" Width="94px">
                                                </dx:ASPxButton>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                </td>
            </tr>
      </table>

    </asp:panel>
                 
</asp:Panel>
  
</div>
</asp:Content>

