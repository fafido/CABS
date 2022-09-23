<%@ Page Title="" Language="VB" MasterPageFile="~/CDSUser.master" AutoEventWireup="false" CodeFile="FullCompanySchedule.aspx.vb" Inherits="FullCompanySchedule" %><%@ Register assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxTabControl" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxClasses" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dx" %>
<%@ Register assembly="BasicFrame.WebControls.BasicDatePicker" namespace="BasicFrame.WebControls" tagprefix="BDP" %>
<%@ Register assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>
<asp:Content id="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <table style="width: 79%">
    <tr>
        <td style="height: 18px"></td>
        <td style="height: 18px">&nbsp;</td>
        <td style="height: 18px"></td>
        <td style="height: 18px"></td>
    </tr>
    <tr>
        <td style="height: 26px">
            <dx:ASPxLabel ID="ASPxLabel1" runat="server" Text="Security">
            </dx:ASPxLabel>
        </td>
        <td style="height: 26px">
            <asp:DropDownList ID="ddSecurities" runat="server" Height="30px" Width="247px">
            </asp:DropDownList>
        </td>
        <td style="height: 26px"></td>
        <td style="height: 26px"></td>
    </tr>
    <tr>
        <td>
            <dx:ASPxLabel ID="ASPxLabel2" runat="server" Text="As at">
            </dx:ASPxLabel>
        </td>
        <td>
            <BDP:BasicDatePicker ID="dtpAsAt" runat="server">
            </BDP:BasicDatePicker>
        </td>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td>&nbsp;</td>
        <td>
            <asp:Button ID="Button1" runat="server" Text="View Report" />
        </td>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
    </tr>
</table>

    </asp:Content>



