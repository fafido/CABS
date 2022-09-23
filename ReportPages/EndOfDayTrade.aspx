<%@ Page Title="" Language="VB" MasterPageFile="~/CDSUser.master" AutoEventWireup="false" CodeFile="EndOfDayTrade.aspx.vb" Inherits="ReportPages_EndOfDayTrade" %><%@ Register assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width: 78%; height: 62px">
        <tr>
            <td style="width: 90px">&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td style="width: 235px">&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 90px">
                <dx:ASPxLabel ID="ASPxLabel1" runat="server" Text="Participant">
                </dx:ASPxLabel>
            </td>
            <td>
                <asp:DropDownList ID="ddParticipants" runat="server" Height="32px" Width="200px">
                </asp:DropDownList>
            </td>
            <td>&nbsp;</td>
            <td style="width: 235px">&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 90px">&nbsp;</td>
            <td>
                <dx:ASPxButton ID="ASPxButton1" runat="server" Text="View Report">
                </dx:ASPxButton>
            </td>
            <td>&nbsp;</td>
            <td style="width: 235px">&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 90px">&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td style="width: 235px">&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 90px">&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td style="width: 235px">&nbsp;</td>
        </tr>
    </table>
</asp:Content>

