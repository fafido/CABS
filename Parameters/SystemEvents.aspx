<%@ Page Title="" Language="VB" MasterPageFile="~/CDSUser.master" AutoEventWireup="false" CodeFile="SystemEvents.aspx.vb" Inherits="Parameters_Default" %><%@ Register assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dx" %>
<%@ Register assembly="BasicFrame.WebControls.BasicDatePicker" namespace="BasicFrame.WebControls" tagprefix="BDP" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width: 100%">
        <tr>
            <td style="width: 213px; height: 18px"></td>
            <td style="height: 18px; width: 711px"></td>
        </tr>
        <tr>
            <td style="width: 213px">
                <dx:ASPxLabel ID="ASPxLabel1" runat="server" Text="Event Title">
                </dx:ASPxLabel>
            </td>
            <td style="width: 711px">
                <dx:ASPxTextBox ID="txtEvent" runat="server" Width="170px">
                </dx:ASPxTextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 213px">
                <dx:ASPxLabel ID="ASPxLabel2" runat="server" Text="Event Time">
                </dx:ASPxLabel>
            </td>
            <td style="width: 711px">
                <BDP:TimePicker ID="tpEventTime" runat="server">
                </BDP:TimePicker>
            </td>
        </tr>
        <tr>
            <td style="width: 213px">
                <dx:ASPxLabel ID="ASPxLabel3" runat="server" Text="Last Run Time">
                </dx:ASPxLabel>
            </td>
            <td style="width: 711px">
                <dx:ASPxTextBox ID="txtLastRun" runat="server" Width="170px">
                </dx:ASPxTextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 213px">&nbsp;</td>
            <td style="width: 711px">
                <dx:ASPxButton ID="btnSave" runat="server" Text="Save Event">
                </dx:ASPxButton>
            </td>
        </tr>
        <tr>
            <td style="width: 213px">&nbsp;</td>
            <td style="width: 711px">&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 213px">&nbsp;</td>
            <td style="width: 711px">
                <asp:GridView ID="grdvEvents" runat="server" AutoGenerateSelectButton="True">
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td style="width: 213px">&nbsp;</td>
            <td style="width: 711px">&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 213px">&nbsp;</td>
            <td style="width: 711px">&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 213px">&nbsp;</td>
            <td style="width: 711px">&nbsp;</td>
        </tr>
    </table>
</asp:Content>

