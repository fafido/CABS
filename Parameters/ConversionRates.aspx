<%@ Page Title="" Language="VB" MasterPageFile="~/CDSUser.master" AutoEventWireup="false" CodeFile="ConversionRates.aspx.vb" Inherits="_Default" %>

<%@ Register assembly="BasicFrame.WebControls.BasicDatePicker" namespace="BasicFrame.WebControls" tagprefix="BDP" %>
<%@ Register assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dx" %>

<%@ Register assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxGridView" tagprefix="dx1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
                       <dx:ASPxLabel ID="ASPxLabel5" runat="server" Text="Parameters&gt;&gt;Currency Rates" Font-Names="Cambria" Font-Size="Small" Theme="PlasticBlue"></dx:ASPxLabel>

     <asp:panel id="Panel2" runat="server" GroupingText="Currency Rates" Font-Names="Cambria" Visible="True">
    <table style="width:100%" >
        <tr>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 313px">
                       <dx:ASPxLabel ID="ASPxLabel6" runat="server" Text="Default Currency" Font-Names="Cambria" Font-Size="Small" Theme="PlasticBlue"></dx:ASPxLabel>

            </td>
            <td>
                <asp:Label ID="lbldefaultcur" runat="server"></asp:Label>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 313px">
                <dx:ASPxLabel ID="ASPxLabel1" runat="server" Text="Currency Code" Font-Names="Cambria" Font-Size="Small" Theme="PlasticBlue">
                </dx:ASPxLabel>
            </td>
            <td>
                <asp:DropDownList ID="ddCurrency" runat="server" Height="22px" Width="201px">
                </asp:DropDownList>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 313px">
                <dx:ASPxLabel ID="lblRate" runat="server" Text="Rate" Font-Names="Cambria" Font-Size="Small" Theme="PlasticBlue">
                </dx:ASPxLabel>
            </td>
            <td>
                <dx:ASPxTextBox ID="txtRate" runat="server" Height="22px" Width="201px">
                </dx:ASPxTextBox>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 313px">
                <dx:ASPxLabel ID="ASPxLabel2" runat="server" Text="Date" Font-Names="Cambria" Font-Size="Small" Theme="PlasticBlue">
                </dx:ASPxLabel>
            </td>
            <td>
                <BDP:BasicDatePicker ID="dtpFrom" runat="server" height="29px" width="231px">
                </BDP:BasicDatePicker>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 313px">&nbsp;</td>
            <td>
                <dx:ASPxButton ID="ASPxButton1" runat="server" Text="Save Rate" height="20px" width="110px">
                </dx:ASPxButton>
            <dx:ASPxButton ID="btnDelete" runat="server" Height="20px" Text="Delete Rate" Visible="False" Width="110px">
            </dx:ASPxButton>
            <dx:ASPxButton ID="btnClear" runat="server" Height="20px" Text="Clear" Visible="False" Width="110px">
            </dx:ASPxButton>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 313px">&nbsp;</td>
            <td>
                <asp:GridView ID="grdvRates" runat="server" AutoGenerateSelectButton="True" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" EmptyDataText="No Relevant Data Found" Font-Size="Small" ForeColor="#333333" GridLines="Vertical" Height="16px" Width="99%">
                    <PagerSettings FirstPageText="First" LastPageText="Last" NextPageText="Next" PreviousPageText="Previous" />
                    <AlternatingRowStyle CssClass="altrowstyle" />
                    <EditRowStyle BackColor="White" />
                    <FooterStyle BackColor="White" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#B7D8DC" CssClass="headerstyle" ForeColor="Black" HorizontalAlign="left" />
                    <PagerStyle BackColor="White" ForeColor="#B7D8DC" HorizontalAlign="left" />
                    <RowStyle BackColor="White" CssClass="rowstyle" />
                    <SelectedRowStyle BackColor="#D1DDF1" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#F5F7FB" />
                    <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                    <SortedDescendingCellStyle BackColor="#E9EBEF" />
                    <SortedDescendingHeaderStyle BackColor="#4870BE" />
                </asp:GridView>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 313px">
                &nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td colspan="2">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 313px">&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 313px">&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>
         </asp:panel>
</asp:Content>

