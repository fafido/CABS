<%@ Page Language="VB" MasterPageFile="~/CDSUser.master" AutoEventWireup="false" CodeFile="retrievepayments.aspx.vb" Inherits="TransferSec_retrievepayments" title="Confirm Delivery" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<asp:Content id="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
    <asp:Panel id="Panel1" runat="server" Width="840px" Font-Names="Arial" Font-Size="Medium" BackColor="White">
    
        <table width ="810px">
            <tr>
                   <td style ="text-align :left;" align="left">
                       <dx:ASPxLabel ID="ASPxLabel1" runat="server" Text="Trading&gt;&gt;Confirm Delivery" Font-Names="Cambria" Font-Size="Small" Theme="PlasticBlue"></dx:ASPxLabel>

                   </td>
            </tr>
        </table>
        <asp:Panel runat="server" ID="PanelType" Font-Names="Cambria" GroupingText="Confirm Delivery">
            <br />
            <table style="width: 828px">
                <tr>
                    <td>
                         <asp:GridView ID="grdsellers" runat="server" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" CssClass="tablestyle"  Font-Size="Small" ForeColor="Black" GridLines="None" Style="position: relative; top: 0px; left: 0px; width:100%; height: 3px;" AutoGenerateColumns="False">
                             <PagerSettings FirstPageText="First" LastPageText="Last" NextPageText="Next" PreviousPageText="Previous" />
                             <AlternatingRowStyle CssClass="altrowstyle" />
                             <Columns>
                                 <asp:BoundField DataField="Mobile" HeaderText="Mobile" />
                                 <asp:BoundField DataField="Amount" HeaderText="Amount" />
                                 <asp:BoundField DataField="Quantity" HeaderText="Quntity" />
                             </Columns>
                             <HeaderStyle BackColor="#023E5A" ForeColor="White" HorizontalAlign="Left" />
                             <RowStyle CssClass="rowstyle" />
                         </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td align="center">
                        <asp:Button ID="Button1" runat="server" BackColor="#023E5A" ForeColor="White" Height="28px" Text="Extract Payments For Sell Orders" Width="215px" />
                    </td>
                </tr>
                <tr>
                    <td align="center">
                        <asp:GridView ID="grdsellers0" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" CssClass="tablestyle" Font-Size="Small" ForeColor="Black" GridLines="None" Style="position: relative; top: 0px; left: 0px; width:100%; height: 3px;">
                            <PagerSettings FirstPageText="First" LastPageText="Last" NextPageText="Next" PreviousPageText="Previous" />
                            <AlternatingRowStyle CssClass="altrowstyle" />
                            <Columns>
                                <asp:BoundField DataField="Mobile" HeaderText="Mobile" />
                                <asp:BoundField DataField="Amount" HeaderText="Amount" />
                                <asp:BoundField DataField="Quantity" HeaderText="Quntity" />
                            </Columns>
                            <HeaderStyle BackColor="#023E5A" ForeColor="White" HorizontalAlign="Left" />
                            <RowStyle CssClass="rowstyle" />
                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td align="center">
                        <asp:Button ID="Button2" runat="server" BackColor="#023E5A" ForeColor="White" Height="28px" Text="Extract Payments for Interest" Width="215px" />
                    </td>
                </tr>
                <tr>
                    <td align="center">&nbsp;</td>
                </tr>
                <tr>
                    <td align="center">
                        <asp:GridView ID="grdsellers1" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" CssClass="tablestyle" Font-Size="Small" ForeColor="Black" GridLines="None" Style="position: relative; top: 0px; left: 1px; width:100%; height: 3px;">
                            <PagerSettings FirstPageText="First" LastPageText="Last" NextPageText="Next" PreviousPageText="Previous" />
                            <AlternatingRowStyle CssClass="altrowstyle" />
                            <Columns>
                                <asp:BoundField DataField="Mobile" HeaderText="Mobile" />
                                <asp:BoundField DataField="Amount" HeaderText="Amount" />
                                <asp:BoundField DataField="Quantity" HeaderText="Quntity" />
                            </Columns>
                            <HeaderStyle BackColor="#023E5A" ForeColor="White" HorizontalAlign="Left" />
                            <RowStyle CssClass="rowstyle" />
                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td align="center">
                        <asp:Button ID="Button3" runat="server" BackColor="#023E5A" ForeColor="White" Height="28px" Text="Extract Payments for Capital Repayments" Width="275px" />
                    </td>
                </tr>
            </table>
         
        </asp:Panel>
         
                 
</asp:Panel>
  
</div>
</asp:Content>

