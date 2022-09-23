<%@ Page Language="VB" MasterPageFile="~/CDSUser.master" AutoEventWireup="false" CodeFile="receivables.aspx.vb" Inherits="BA_receivables" title="Receivables" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<asp:Content id="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
    <asp:Panel id="Panel1" runat="server" Width="840px" Font-Names="Arial" Font-Size="Medium" BackColor="White">
    
        <table width ="810px">
            <tr>
                   <td style ="text-align :left;" align="left">
                       <dx:ASPxLabel ID="ASPxLabel1" runat="server" Text="Bankers Acceptance&gt;&gt;Available BAs" Font-Names="Cambria" Font-Size="Small" Theme="PlasticBlue"></dx:ASPxLabel>

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
                    <dx:ASPxLabel ID="ASPxLabel81" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Receivables" Theme="iOS">
                    </dx:ASPxLabel>
                </td>
            </tr>
            <tr>
                <td colspan="2" style="height: 18px; " align="right">
                    <table class="auto-style1" style="width: 14%">
                        <tr>
                            <td>&nbsp;</td>
                            <td>
                                <dx:ASPxButton ID="ASPxButton2" runat="server" BackColor="#023E5A" Text="Date Issued" Theme="BlackGlass">
                                </dx:ASPxButton>
                            </td>
                            <td>
                                <dx:ASPxButton ID="ASPxButton3" runat="server" BackColor="#023E5A" Text="Tenor" Theme="BlackGlass">
                                </dx:ASPxButton>
                            </td>
                            <td>
                                <dx:ASPxButton ID="ASPxButton4" runat="server" BackColor="#023E5A" Text="Face Value" Theme="BlackGlass">
                                </dx:ASPxButton>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td colspan="2" align="right" align="center">
                    <asp:GridView ID="grdEvent0" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" CssClass="tablestyle" DataKeyNames="id" Font-Size="Small" ForeColor="Black" GridLines="None" Style="position: relative; top: 0px; left: 0px; width:100%; height: 3px;">
                        <PagerSettings FirstPageText="First" LastPageText="Last" NextPageText="Next" PreviousPageText="Previous" />
                        <AlternatingRowStyle CssClass="altrowstyle" />
                        <HeaderStyle BackColor="#023E5A" ForeColor="White" HorizontalAlign="Left" />
                        <RowStyle CssClass="rowstyle" />
                        <Columns>
                            <asp:BoundField DataField="BA_Number" HeaderText="BA Number" />
                            <asp:BoundField DataField="date_received" HeaderText="Date Received" />
                            <asp:BoundField DataField="Company_name" HeaderText="Issuer" />
                            <asp:BoundField DataField="Face_Value" HeaderText="Face Value" />
                            <asp:BoundField DataField="Tenor" HeaderText="Tenor(Dys)" />
                            <asp:BoundField DataField="Maturity_date" HeaderText="Maturity Date" />
                            <asp:CommandField EditText="More Details" SelectText="More Details" ShowSelectButton="true">
                            <ItemStyle Font-Bold="True" Font-Italic="True" ForeColor="Red" HorizontalAlign="Right" />
                            </asp:CommandField>
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
      </table>

    </asp:panel>
                 
</asp:Panel>
  
</div>
</asp:Content>

