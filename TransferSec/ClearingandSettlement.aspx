<%@ Page Language="VB"  MasterPageFile="~/CDSUser.master" AutoEventWireup="false" CodeFile="ClearingandSettlement.aspx.vb" Inherits="TransferSec_ClearingandSettlement" title="ORDERS Verification" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxRibbon" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxFormLayout" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxRoundPanel" TagPrefix="dx" %>
<%@ Register namespace="BasicFrame.WebControls" tagprefix="WebControls" %>
<%@ Register assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxGridView" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxPanel" tagprefix="dx" %>
<asp:Content id="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:panel runat="server" ScrollBars="Auto">

        <table style="background-color:ivory ; border-style:solid ;">
            <tr>
                        <td colspan ="8" align="center"><dx:ASPxLabel ID="ASPxLabel4" runat="server" Text="Trades Settled From Banks" Theme="iOS" Font-Names="Cambria" Font-Size="Medium"></dx:ASPxLabel></td>

                </tr>
            <tr>

                <td colspan ="8" align="center"><dx:ASPxGridView ID="grdBrokersNet" runat="server" Theme="Office2003Olive" Width="840px" EnableTheming="True" Font-Names="Cambria" Font-Size="Small"></dx:ASPxGridView></td>
            </tr>
            <tr>
                    <td colspan ="8" align="center"><asp:RadioButton runat="server" ID="rdAll" AutoPostBack="True" Font-Names="Cambria" GroupName="Banksettlement" Text="Settle All Transactions" Visible="False"></asp:RadioButton>
                        <asp:RadioButton ID="rdAll0" runat="server" AutoPostBack="True" Font-Names="Cambria" GroupName="Banksettlement" Text="Settle Individual Transactions" Visible="False" />
                    </td>

            </tr>
            <tr>
                <td colspan ="8" align ="center">
                    <dx:ASPxButton ID="ASPxButton2" runat="server" Text="Process Settlement" Theme="iOS" Visible="False">
                    </dx:ASPxButton>
                </td>
            </tr>
                <tr>
                        <td colspan ="8" align="center"><dx:ASPxLabel ID="ASPxLabel1" runat="server" Text="Trades Settled From Guarantee Funds" Theme="iOS" Font-Names="Cambria" Font-Size="Medium"></dx:ASPxLabel></td>

                </tr>
            <tr>

                <td colspan ="8" align="center"><dx:ASPxGridView ID="grdOrdersSummary" runat="server" Theme="PlasticBlue" Width="840px" EnableTheming="True" Font-Names="Cambria" Font-Size="Small"></dx:ASPxGridView></td>
            </tr>
            <tr>
                    <td colspan ="8" align="center"><asp:RadioButton runat="server" ID="RadioButton1" AutoPostBack="True" Font-Names="Cambria" GroupName="Banksettlement" Text="Settle All Transactions" Visible="False"></asp:RadioButton>
                        <asp:RadioButton ID="RadioButton2" runat="server" AutoPostBack="True" Font-Names="Cambria" GroupName="Banksettlement" Text="Settle Individual Transactions" Visible="False" />
                    </td>

            </tr>
            <tr>
                <td colspan ="8" align ="center">
                    <dx:ASPxButton ID="ASPxButton3" runat="server" Text="Process Settlement" Theme="iOS" Visible="False">
                    </dx:ASPxButton>
                </td>
            </tr>
            
            <tr>
                        <td colspan ="8" align="center"><dx:ASPxLabel ID="ASPxLabel2" runat="server" Text="Failed Trades" Theme="iOS" Font-Names="Cambria" Font-Size="Medium"></dx:ASPxLabel></td>

                </tr>
            <tr>

                <td colspan ="8" align="center"><dx:ASPxGridView ID="ASPxGridView1" runat="server" Theme="RedWine" Width="840px" EnableTheming="True" Font-Names="Cambria" Font-Size="Small"></dx:ASPxGridView></td>
            </tr>
            
           
            <tr>
                <td colspan ="8" align="center">
                    <dx:ASPxButton ID="ASPxButton1" runat="server" Text="Send Notifications" Theme="iOS">
                    </dx:ASPxButton>
                </td>

            </tr>

        </table>
    </asp:panel>
</asp:Content>

