<%@ Page Language="VB" MasterPageFile="~/CDSUser.master" AutoEventWireup="false" CodeFile="CDSAdminHome.aspx.vb" Inherits="CDSMode_CDSAdminHome" title="TSec Home" %>
<%@ Register assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxGridView" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dx" %>
<asp:Content id="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
    <asp:Panel id="Panel1" runat="server">
    
<table style="border-right: #000033 thin solid; border-top: #000033 thin solid; border-left: #000033 thin solid; width: 832px; border-bottom: #000033 thin solid; background-color: #ffffff">
    <tr>
        <td style="width: 759px; height: 226px" valign="top">
            <table>
            <tr>
                <td style="width: 870px" align="center">
                    <asp:Label id="Label4" runat="server" backcolor="#8080FF" font-bold="True" 
                        font-names="Arial" width="851px" Height="17px"></asp:Label></td>
            </tr>
                               
            </table>
            <table>
                <tr>
                    <td style="width: 143px">
                        &nbsp;</td>
                        <td>
                            </td>
                            <td style="width: 504px">
                                <asp:Label ID="Label5" runat="server" font-names="Verdana" font-size="Small" Text="News Update:"></asp:Label>
                                </td>
                                <td style="width: 302px">
                                    <asp:Label ID="Label6" runat="server"></asp:Label>
                                    </td>
                                    <td style="width: 141px">
                                        </td>
                </tr>
                <tr>
                    <td colspan ="1">
                        &nbsp;</td>
                    <td colspan ="3">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td colspan ="1">
                        &nbsp;</td>
                    <td colspan ="3">
                        <asp:Panel ID="Panel2" runat="server" Width="767px">
                            <dx:ASPxGridView ID="grdEventsDiary" runat="server" Theme="Office2003Silver">
                            </dx:ASPxGridView>
                        </asp:Panel>
                    </td>
                </tr>
                <tr>
                    <td colspan ="1">&nbsp;</td>
                    <td colspan ="3"></td>
                </tr>
            </table>
            <table>
                <tr>
                    <td></td>
                </tr>
            </table>
            <table>
                <tr>
                    <td colspan ="4" style="width: 850px" align="center">
                        <dx: CreateDatabaseControl>

                            </dx:>
                        </td>                
                </tr>
            </table>
        </td>
    </tr>
</table>
</asp:Panel>
</div>
</asp:Content>

