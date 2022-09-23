<%@ Page Language="VB" MasterPageFile="~/CDSUser.master" AutoEventWireup="false" CodeFile="EventsManagement.aspx.vb" Inherits="BrokerMode_EventsManagement" title="Broker Home" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxTabControl" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>


<%@ Register assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dx" %>


<%@ Register assembly="DevExpress.XtraCharts.v13.2.Web, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.XtraCharts.Web" tagprefix="dxchartsui" %>
<%@ Register assembly="DevExpress.XtraCharts.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.XtraCharts" tagprefix="cc1" %>


<%@ Register assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxFileManager" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxUploadControl" tagprefix="dx" %>


<%@ Register assembly="DevExpress.Web.ASPxScheduler.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxScheduler.Controls" tagprefix="dxwschsc" %>
<%@ Register assembly="DevExpress.Web.ASPxScheduler.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxScheduler" tagprefix="dxwschs" %>


<asp:Content id="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
    <asp:Panel id="Panel1" runat="server">
    
<table style="border-right: #000033 thin solid; border-top: #000033 thin solid; border-left: #000033 thin solid; width: 832px; border-bottom: #000033 thin solid; background-color: #ffffff">
    <tr>
        <td style="width: 712px; height: 226px" valign="top">
            <table>
            <tr>
                <td style="width: 870px" align="center">
                    <asp:Label id="Label4" runat="server" backcolor="#8080FF" font-bold="True" font-names="Arial" width="848px"></asp:Label></td>
            </tr>
                               
            </table>
            <table>
            <tr>
                <td style="width: 870px" align="left">
                    <asp:Label id="Label1" runat="server" text="Utilities >> Events Management" font-names="Cambria" width="250"></asp:Label></td>
            </tr>
                               
            </table>

           <asp:Panel runat="server" ID="panelSet" Font-Names="Cambria" GroupingText="Events Management">
                <table>
            <tr>
                <td colspan ="1">
                    <dx:ASPxLabel ID="ASPxLabel23" runat="server" Text="Company" Theme="Office2010Blue">
                    </dx:ASPxLabel>
                </td>
                <td colspan ="1">
                    <dx:ASPxComboBox ID="cmbSecurities" runat="server" Theme="Glass" Width="200px" DataSourceID="distinctCompany" TextField="company" ValueField="company">
                    </dx:ASPxComboBox>
                    <asp:SqlDataSource ID="distinctCompany" runat="server" ConnectionString="<%$ ConnectionStrings:CDSConnectionString %>" SelectCommand="select distinct (company) from para_company"></asp:SqlDataSource>
                </td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>

            </tr>
                <tr>
                        <td colspan ="1">
                            <dx:ASPxLabel ID="ASPxLabel29" runat="server" Text="Start Date" Theme="Office2010Blue">
                            </dx:ASPxLabel>
                        </td>
                    <td colspan ="1">
                        <dx:ASPxDateEdit ID="txtStartDate" runat="server" Theme="Glass" Width="200px">
                        </dx:ASPxDateEdit>
                        </td>
                    <td colspan ="1"></td>
                    <td colspan ="1">
                        <dx:ASPxLabel ID="ASPxLabel30" runat="server" Text="End Date" Theme="Office2010Blue">
                        </dx:ASPxLabel>
                        </td>
                    <td colspan ="1">
                        <dx:ASPxDateEdit ID="txtEndDate" runat="server" Theme="Glass" Width="200px">
                        </dx:ASPxDateEdit>
                        </td>
                    <td colspan ="1">&nbsp;</td>
                    <td colspan ="1"></td>
                    <td colspan ="1"></td>

                </tr>
                <tr>
                        <td colspan ="1">
                            <dx:ASPxLabel ID="ASPxLabel31" runat="server" Text="Title" Theme="Office2010Blue">
                            </dx:ASPxLabel>
                        </td>
                    <td colspan ="1">
                        <dx:ASPxTextBox ID="txtTitle" runat="server" Theme="Office2003Blue" Width="200px">
                        </dx:ASPxTextBox>
                        </td>
                    <td colspan ="1"></td>
                    <td colspan ="1"></td>
                    <td colspan ="1"></td>
                    <td colspan ="1"></td>
                    <td colspan ="1"></td>
                    <td colspan ="1"></td>

                </tr>
                <tr>
                        <td colspan ="1">
                            <dx:ASPxLabel ID="ASPxLabel32" runat="server" Text="Event Details" Theme="Office2010Blue">
                            </dx:ASPxLabel>
                        </td>
                    
                    <td colspan ="7">
                        <asp:TextBox ID="txtDetails" runat="server" Height="97px" TextMode="MultiLine" Width="781px"></asp:TextBox>
                        </td>
                    
                </tr>
                <tr>
                    <td colspan ="8" align="center">
                        <dx:ASPxButton ID="btnSave" runat="server" Text="save" Theme="BlackGlass">
                        </dx:ASPxButton>
                    </td>

                </tr>
                <tr>
                        <td colspan ="8" align="center">
                            <dx:ASPxGridView ID="grdRules" runat="server" Theme="Glass" Width="666px">
                                <SettingsPager AlwaysShowPager="True">
                                </SettingsPager>
                            </dx:ASPxGridView>
                        </td>

                </tr>
                
                   <tr>
                        <td colspan ="1"></td>
                    <td colspan ="1"></td>
                    <td colspan ="1"></td>
                    <td colspan ="1"></td>
                    <td colspan ="1"></td>
                    <td colspan ="1"></td>
                    <td colspan ="1"></td>
                    <td colspan ="1"></td>

                </tr>
                <tr>
                        <td colspan ="1">
                            &nbsp;</td>
                    <td colspan ="1">
                        &nbsp;</td>
                    <td colspan ="1">
                        &nbsp;</td>
                    <td colspan ="1">
                        &nbsp;</td>
                    <td colspan ="1">
                        &nbsp;</td>
                    <td colspan ="1">
                        &nbsp;</td>
                    <td colspan ="1"></td>
                    <td colspan ="1"></td>

                </tr>
                <tr>
                        <td colspan ="1"></td>
                    <td colspan ="3">
                        &nbsp;</td>
                    
                    <td colspan ="1"></td>
                    <td colspan ="1"></td>
                    <td colspan ="1"></td>
                    <td colspan ="1"></td>

                </tr>
                <tr>
                        <td colspan ="1"></td>
                    <td colspan ="1"></td>
                    <td colspan ="1"></td>
                    <td colspan ="1"></td>
                    <td colspan ="1">&nbsp;</td>
                    <td colspan ="1"></td>
                    <td colspan ="1"></td>
                    <td colspan ="1"></td>

                </tr>
                <tr>

                    <td colspan ="1">
                        &nbsp;</td>
                    <td colspan ="1">
                        &nbsp;</td>
                    <td colspan ="1">
                        &nbsp;</td>
                    <td colspan ="1">
                        &nbsp;</td>
                    <td colspan ="1">
                        &nbsp;</td>
                    <td colspan ="1">
                        &nbsp;</td>
                    <td colspan ="1"></td>
                    <td colspan ="1"></td>
                </tr>
                <tr>
                        <td colspan ="1"></td>
                    <td colspan ="1"></td>
                    <td colspan ="1"></td>
                    <td colspan ="1"></td>
                    <td colspan ="1"></td>
                    <td colspan ="1"></td>
                    <td colspan ="1"></td>
                    <td colspan ="1"></td>

                </tr>
                <tr>
                        <td colspan ="8" style="text-align:center;">
                            &nbsp;</td>

                </tr>
                <tr>
                        <td colspan ="8" style=" align-items :center;">&nbsp;</td>

                </tr>
                <tr>

                    <td colspan ="1">
                        &nbsp;</td>
                    <td colspan ="1">
                        &nbsp;</td>
                    <td colspan ="1"></td>
                    <td colspan ="1"></td>
                    <td colspan ="1"></td>
                    <td colspan ="1"></td>
                    <td colspan ="1"></td>
                    <td colspan ="1"></td>
                </tr>
                
                <tr>
                        <td colspan ="1"></td>
                    <td colspan ="1"></td>
                    <td colspan ="1"></td>
                    <td colspan ="1"></td>
                    <td colspan ="1"></td>
                    <td colspan ="1"></td>
                    <td colspan ="1"></td>
                    <td colspan ="1"></td>

                </tr>
                <tr>
                        <td colspan ="1"></td>
                    <td colspan ="1"></td>
                    <td colspan ="1"></td>
                    <td colspan ="1"></td>
                    <td colspan ="1"></td>
                    <td colspan ="1"></td>
                    <td colspan ="1"></td>
                    <td colspan ="1"></td>

                </tr>
            </table>
            <table>
                <tr>
                    <td></td>
                </tr>
            </table>
            <table>
                <tr>
                    <td style="width: 850px" align="center">
                        </td>                
                </tr>
            </table>
           </asp:Panel>
        </td>
    </tr>
</table>
</asp:Panel>
</div>
</asp:Content>

