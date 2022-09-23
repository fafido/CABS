<%@ Page Language="VB" MasterPageFile="~/CDSUser.master" AutoEventWireup="false" CodeFile="confirmpayment.aspx.vb" Inherits="BA_confirmpayment" title="Confirm Payment" %>

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
                    <dx:ASPxLabel ID="ASPxLabel81" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Available Offers" Theme="iOS">
                    </dx:ASPxLabel>
                </td>
            </tr>
            <tr>
                <td colspan="2" style="height: 18px; " align="right">
                    <table class="auto-style1" style="width: 14%">
                        <tr>
                            <td>&nbsp;</td>
                            <td>
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td colspan="2" align="right" align="center">
                    <asp:GridView ID="grdEvent0" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" CssClass="tablestyle" DataKeyNames="id" EmptyDataText="No Pending Payments" Font-Size="Small" ForeColor="Black" GridLines="None" Style="position: relative; top: 0px; left: 0px; width:100%; height: 3px;">
                        <PagerSettings FirstPageText="First" LastPageText="Last" NextPageText="Next" PreviousPageText="Previous" />
                        <AlternatingRowStyle CssClass="altrowstyle" />
                        <HeaderStyle BackColor="#023E5A" ForeColor="White" HorizontalAlign="Left" />
                        <RowStyle CssClass="rowstyle" />
                        <Columns>
                            <asp:BoundField DataField="BA Number" HeaderText="BA Number" />
                            <asp:BoundField DataField="Company name" HeaderText="Payee" />
                            <asp:BoundField DataField="Company Type" HeaderText="Payee Type" />
                            <asp:BoundField DataField="Phone" HeaderText="Phone" />
                            <asp:BoundField DataField="Payment Ref" HeaderText="Payment Ref" />
                             <asp:BoundField DataField="Transaction Date" HeaderText="Transaction Date" />
                         

                                        <asp:CommandField EditText="Acce" SelectText="Confirm" ShowSelectButton="true">
                            <ItemStyle Font-Bold="True" Font-Italic="True" ForeColor="Red" HorizontalAlign="Right" />
                            </asp:CommandField>
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td align="left" align="center" colspan="2">
                    <asp:Panel ID="Panel3" runat="server" Visible="False">
                        <table class="auto-style1">
                            <tr>
                                <td style="height: 12px">
                                    <dx:ASPxLabel ID="lblsure" runat="server" Font-Names="Cambria" Font-Size="Small" Theme="iOS">
                                    </dx:ASPxLabel>
                                    <dx:ASPxLabel ID="lblbanumber" runat="server" Font-Names="Cambria" Font-Size="Small" Theme="iOS">
                                    </dx:ASPxLabel>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" >
                                    &nbsp;</td>
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

