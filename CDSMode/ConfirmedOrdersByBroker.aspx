<%@ Page Language="VB"  MasterPageFile="~/CDSUser.master" AutoEventWireup="false" CodeFile="ConfirmedOrdersByBroker.aspx.vb" Inherits="CDSMode_ConfirmedOrdersByBroker" title="Confirmed Orders By Broker" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxRibbon" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxFormLayout" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxRoundPanel" TagPrefix="dx" %>
<%@ Register namespace="BasicFrame.WebControls" tagprefix="WebControls" %>
<%@ Register assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxGridView" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxPanel" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dx1" %>
<asp:Content id="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <meta http-equiv="Refresh" content="10" />  
    <asp:panel runat="server" ScrollBars="Auto">

        <table style="background-color:ivory ; border-style:solid ;">
                <tr>
                        <td colspan ="8" align="center"><dx:ASPxLabel ID="ASPxLabel1" runat="server" Text="Orders Verification By Broker" Theme="iOS" Font-Names="Cambria" Font-Size="Medium"></dx:ASPxLabel></td>

                </tr>
            <tr>

                <td colspan ="8" align="center"><dx:ASPxGridView ID="grdOrdersSummary" runat="server" Theme="Office2003Silver" Width="840px" EnableTheming="True" Font-Names="Cambria" Font-Size="Small"></dx:ASPxGridView></td>
            </tr>
            <tr>
                <td colspan ="4" bgcolor="#00CC66">
                    &nbsp;</td>
                <td colspan ="4" bgcolor="#00CC66">
                    &nbsp;</td>
            </tr>
            <tr>
                <td colspan ="4" align="left">
                    <dx:ASPxButton ID="ASPxButton1" runat="server" Text="previous page" Theme="BlackGlass">
                    </dx:ASPxButton>
                </td>
                <td colspan ="1">
                    
                </td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>
                <td colspan ="1" align="right"><dx1:ASPxButton ID="ASPxButton2" runat="server" Text="Receive ATS Orders" Theme="BlackGlass">
                    </dx1:ASPxButton></td>
            </tr>
            <tr>
                <td colspan ="8" align="center">
                    &nbsp;</td>

            </tr>

        </table>
    </asp:panel>
</asp:Content>

