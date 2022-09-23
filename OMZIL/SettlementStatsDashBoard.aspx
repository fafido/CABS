<%@ Page Language="VB" MasterPageFile="~/CDSUser.master" AutoEventWireup="false" CodeFile="SettlementStatsDashBoard.aspx.vb" Inherits="TransferSec_SettlementStatsDashBoard" title="OTC" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<asp:Content id="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
    <asp:Panel id="Panel1" runat="server" Width="840px" Font-Names="Arial" Font-Size="Medium" BackColor="White">
    
        <table width ="810px">
            <tr>
                   <td style ="text-align :left;" align="left">
                       <dx:ASPxLabel ID="ASPxLabel1" runat="server" Text="Trading&gt;&gt;Trades Dashboard and Statistics Watch" Font-Names="Cambria" Font-Size="Small" Theme="PlasticBlue"></dx:ASPxLabel>

                   </td>
            </tr>
        </table>
        <asp:Panel runat="server" ID="PanelType" Font-Names="Cambria" GroupingText="Orders">
            <table>
                <tr>
                    <td colspan ="3"><asp:Label runat="server" Text="Start Date"></asp:Label></td>
                    <td colspan ="3"><dx:ASPxDateEdit ID="txtDateFrom" runat="server"></dx:ASPxDateEdit></td>
                    <td colspan ="3">
                        <asp:Label ID="Label2" runat="server" Text="End Date"></asp:Label>
                    </td>
                    <td colspan ="3">
                        <dx:ASPxDateEdit ID="txtDateTo" runat="server">
                        </dx:ASPxDateEdit>
                    </td>
                </tr>
                <tr>
                    <td colspan ="12" align ="center" ><asp:Button runat="server" Text="View Stats" ID="btnView" OnClick="btnView_Click"></asp:Button></td>
                </tr>
                <tr>
                    <td colspan ="4"><asp:Label runat="server" Text="Sellers"></asp:Label></td>
                    <td colspan ="4"></td>
                    <td colspan ="4"><asp:Label runat="server" Text="Buyers"></asp:Label></td>
                </tr>
                <tr>
                    <td colspan ="5">
                        <asp:GridView ID="grdSellers" runat="server" CellPadding="4" Font-Names="Arial" Font-Size="Small" ForeColor="#333333" GridLines="None">
                            <AlternatingRowStyle BackColor="White" />
                            <EditRowStyle Font-Names="Arial" Font-Size="Small" />
                            <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                            <PagerStyle Font-Names="Arial" Font-Size="Small" BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                            <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
                            <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                            <SortedAscendingCellStyle BackColor="#FDF5AC" />
                            <SortedAscendingHeaderStyle BackColor="#4D0000" />
                            <SortedDescendingCellStyle BackColor="#FCF6C0" />
                            <SortedDescendingHeaderStyle BackColor="#820000" />
                        </asp:GridView>
                    </td>
                    <td colspan ="2"></td>
                    <td colspan ="5">
                        <asp:GridView ID="grdBuyers" runat="server" CellPadding="4" Font-Names="Arial" Font-Size="Small" ForeColor="#333333" GridLines="None">
                            <AlternatingRowStyle BackColor="White" />
                            <EditRowStyle BackColor="#7C6F57" />
                            <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                            <RowStyle BackColor="#E3EAEB" />
                            <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                            <SortedAscendingCellStyle BackColor="#F8FAFA" />
                            <SortedAscendingHeaderStyle BackColor="#246B61" />
                            <SortedDescendingCellStyle BackColor="#D4DFE1" />
                            <SortedDescendingHeaderStyle BackColor="#15524A" />
                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td colspan ="12" align="center" ><asp:Label runat="server" Text="Trades Pending Settlement"></asp:Label></td>
                </tr>
                <tr>
                    <td colspan ="12" align="center" ><asp:GridView ID="grdPendingSettlements" runat="server">
                        </asp:GridView></td>
                </tr>
                <tr>
                    <td colspan ="12" align="center" ><asp:Label runat="server" Text="Settled Trades"></asp:Label></td>
                </tr>
                <tr>
                    <td colspan ="12" align="center" ><asp:GridView ID="grdSettledTrades" runat="server" CellPadding="4" Font-Names="Arial" Font-Size="Small" ForeColor="#333333" GridLines="None">
                        <AlternatingRowStyle BackColor="White" />
                        <EditRowStyle BackColor="#2461BF" />
                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#EFF3FB" />
                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#F5F7FB" />
                        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                        <SortedDescendingCellStyle BackColor="#E9EBEF" />
                        <SortedDescendingHeaderStyle BackColor="#4870BE" />
                        </asp:GridView></td>
                </tr>
            </table>
         
        </asp:Panel>
         
                 
</asp:Panel>
  
</div>
</asp:Content>

