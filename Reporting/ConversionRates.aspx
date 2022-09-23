<%@ Page Title="" Language="VB" MasterPageFile="~/CDSUser.master" AutoEventWireup="false" CodeFile="ConversionRates.aspx.vb" Inherits="_Default" %>

<%@ Register assembly="BasicFrame.WebControls.BasicDatePicker" namespace="BasicFrame.WebControls" tagprefix="BDP" %>
<%@ Register assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="border-right: #000033 thin solid; border-top: #000033 thin solid; border-left: #000033 thin solid; width: 832px; border-bottom: #000033 thin solid; background-color: #ffffff">
        <tr>
            <td align="center" colspan="2">
            <asp:Label ID="Label4" runat="server" backcolor="#8080FF" font-bold="True" font-names="Arial" Text="Currency Setup" width="848px"></asp:Label>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 313px">
                <dx:ASPxLabel ID="ASPxLabel4" runat="server" Text="Default Currency Code">
                </dx:ASPxLabel>
            </td>
            <td>
                <asp:Label ID="lbldefaultcur" runat="server"></asp:Label>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 313px">
                <dx:ASPxLabel ID="ASPxLabel1" runat="server" Text="Currency Code">
                </dx:ASPxLabel>
            </td>
            <td>
                <asp:DropDownList ID="ddCurrency" runat="server" Height="27px" Width="201px">
                </asp:DropDownList>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 313px">
                <dx:ASPxLabel ID="lblRate" runat="server" Text="Rate">
                </dx:ASPxLabel>
            </td>
            <td>
                <dx:ASPxTextBox ID="txtRate" runat="server" Height="29px" Width="201px">
                </dx:ASPxTextBox>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 313px">
                <dx:ASPxLabel ID="ASPxLabel2" runat="server" Text="Date From">
                </dx:ASPxLabel>
            </td>
            <td>
                <BDP:BasicDatePicker ID="dtpFrom" runat="server" height="29px" width="201px">
                </BDP:BasicDatePicker>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 313px">
                <dx:ASPxLabel ID="ASPxLabel3" runat="server" Text="Date To">
                </dx:ASPxLabel>
            </td>
            <td>
                <BDP:BasicDatePicker ID="dtpTo" runat="server" height="29px" width="201px">
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
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 313px">&nbsp;</td>
            <td>
            <asp:GridView ID="grdvRates" runat="server" AutoGenerateSelectButton="True" CellPadding="4" ForeColor="#333333" GridLines="None" Width="677px">
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
            </asp:GridView>
            </td>
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
</asp:Content>

