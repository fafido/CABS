<%@ Page Language="VB" MasterPageFile="~/CDSUser.master" AutoEventWireup="false" CodeFile="history.aspx.vb" Inherits="history" title="BA History" %>

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
                    <dx:ASPxLabel ID="ASPxLabel80" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Search BA No." Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                <td style="height: 18px; width: 253px;">
                    <table class="auto-style1">
                        <tr>
                            <td style="width: 238px">
                                <dx:ASPxTextBox ID="txtcompany_name" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="250px">
                                </dx:ASPxTextBox>
                            </td>
                            <td>
                                <dx:ASPxButton ID="ASPxButton5" runat="server" Text="Search" Theme="BlackGlass">
                                </dx:ASPxButton>
                            </td>
                        </tr>
                    </table>
                </td>
                <td colspan="1" style="height: 18px">
                    &nbsp;</td>
                <td colspan="1" style="height: 18px"></td>
                <td colspan="1" style="height: 18px"></td>
                <td colspan="1" style="height: 18px"></td>
            </tr>
            <tr>
                <td colspan="1" style="height: 18px; width: 92px;">
                    &nbsp;</td>
                <td colspan="5" style="height: 18px; ">
                    <dx:ASPxListBox ID="ASPxListBox1" runat="server" AutoPostBack="True" ValueType="System.String" Width="260px">
                    </dx:ASPxListBox>
                </td>
            </tr>
            <tr>
                <td colspan="1" style="height: 18px; width: 92px;">&nbsp;</td>
                <td colspan="5" style="height: 18px; ">&nbsp;</td>
            </tr>
            <tr>
                <td colspan="6" style="height: 18px; ">
                    <dx:ASPxLabel ID="ASPxLabel81" runat="server" Font-Names="Cambria" Font-Size="Small" Text="History" Theme="iOS">
                    </dx:ASPxLabel>
                </td>
            </tr>
            <tr>
                <td align="right" colspan="6" style="height: 18px; ">
                    <table class="auto-style1" style="width: 14%">
                        <tr>
                            <td>
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                            <td>
                                <dx:ASPxButton ID="ASPxButton4" runat="server" Text="Sort" Theme="BlackGlass" BackColor="#023E5A">
                                </dx:ASPxButton>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                    <td align="right"  colspan ="6" align="center">
                        <asp:GridView ID="grdEvent0" runat="server" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" CssClass="tablestyle"  Font-Size="Small" ForeColor="Black" GridLines="None" Style="position: relative; top: 0px; left: 0px; width:100%; height: 3px;">
                            <PagerSettings FirstPageText="First" LastPageText="Last" NextPageText="Next" PreviousPageText="Previous" />
                            <AlternatingRowStyle CssClass="altrowstyle" />
                            <HeaderStyle BackColor="#023E5A" ForeColor="White" HorizontalAlign="Left" />
                            <RowStyle CssClass="rowstyle" />
                        </asp:GridView>
                    </td>


            </tr>
      </table>

    </asp:panel>
                 
</asp:Panel>
  
</div>
</asp:Content>

