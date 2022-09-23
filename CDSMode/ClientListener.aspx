<%@ Page Language="VB"  MasterPageFile="~/CDSUser.master" AutoEventWireup="false" CodeFile="ClientListener.aspx.vb" Inherits="CDSMode_ClientListener" title="ORDERS Verification" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxRibbon" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxFormLayout" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxRoundPanel" TagPrefix="dx" %>
<%@ Register namespace="BasicFrame.WebControls" tagprefix="WebControls" %>
<%@ Register assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxGridView" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxPanel" tagprefix="dx" %>
<asp:Content id="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <meta http-equiv="Refresh" content="10" /> 
    <asp:panel runat="server" ScrollBars="Auto">

        <table style="background-color:ivory ; border-style:solid ;">
            <tr>
                        <td colspan ="8" align="center"><dx:ASPxLabel ID="ASPxLabel4" runat="server" Text="Socket Listener" Theme="iOS" Font-Names="Cambria" Font-Size="Medium"></dx:ASPxLabel></td>

                </tr>
            <tr>

                <td colspan ="8" align="center">
                    <dx:ASPxButton ID="ASPxButton1" runat="server" Text="Start Listener" Theme="BlackGlass">
                    </dx:ASPxButton>
                </td>
            </tr>
            <tr>
                    <td colspan ="1">
                        <dx:ASPxLabel ID="ASPxLabel5" runat="server" Text="Running Service at:">
                        </dx:ASPxLabel>
                    </td>
                <td colspan ="7">
                    <dx:ASPxLabel ID="ServiceID" runat="server">
                    </dx:ASPxLabel>
                    </td>

            </tr>
            <tr>
                    <td colspan ="1">
                        <dx:ASPxLabel ID="ASPxLabel6" runat="server" Text="Connection Accepted From:">
                        </dx:ASPxLabel>
                    </td>
                <td colspan ="7">
                    <dx:ASPxLabel ID="ConnectionID" runat="server">
                    </dx:ASPxLabel>
                    </td>

            </tr>
            <tr>
                    <td colspan ="8" align="center">&nbsp;</td>

            </tr>
            <tr>
                <td colspan ="8" align ="center">
                    <dx:ASPxTextBox ID="rtfMessage" runat="server" Height="180px" Theme="BlackGlass" Width="710px">
                    </dx:ASPxTextBox>
                </td>
            </tr>
                <tr>
                        <td colspan ="8" align="center">&nbsp;</td>

                </tr>
            <tr>

                <td colspan ="8" align="center">&nbsp;</td>
            </tr>
            <tr>
                    <td colspan ="8" align="center">&nbsp;</td>

            </tr>
            <tr>
                <td colspan ="8" align ="center">
                    &nbsp;</td>
            </tr>
            
            <tr>
                        <td colspan ="8" align="center">&nbsp;</td>

                </tr>
            <tr>

                <td colspan ="8" align="center">&nbsp;</td>
            </tr>
            
           
            <tr>
                <td colspan ="8" align="center">
                    &nbsp;</td>

            </tr>

        </table>
    </asp:panel>
</asp:Content>

