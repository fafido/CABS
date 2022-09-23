<%@ Page Language="VB" MasterPageFile="~/CDSUser.master" AutoEventWireup="false" CodeFile="SystemBackUp.aspx.vb" Inherits="BrokerMode_SystemBackUp" title="Broker Home" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxRoundPanel" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxTabControl" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>


<%@ Register assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dx" %>


<%@ Register assembly="DevExpress.XtraCharts.v13.2.Web, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.XtraCharts.Web" tagprefix="dxchartsui" %>
<%@ Register assembly="DevExpress.XtraCharts.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.XtraCharts" tagprefix="cc1" %>


<%@ Register assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxFileManager" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxUploadControl" tagprefix="dx" %>


<%@ Register assembly="DevExpress.Web.ASPxScheduler.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxScheduler.Controls" tagprefix="dxwschsc" %>
<%@ Register assembly="DevExpress.Web.ASPxScheduler.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxScheduler" tagprefix="dxwschs" %>


<%@ Register assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxRatingControl" tagprefix="dx" %>


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
                    <asp:Label id="Label1" runat="server" text="Utilities>>System Back Up" font-names="Cambria" width="150px"></asp:Label></td>
            </tr>
                               
            </table>  
            <asp:Panel runat="server" ID="PanelASet" Font-Names="Cambria" GroupingText="System Back Ups">
                 <table>
                     <tr>
                            <td colspan ="1">
                                <dx:ASPxLabel ID="ASPxLabel2" runat="server" Text="Back Up location" Theme="Glass">
                                </dx:ASPxLabel>
                            </td>
                         <td colspan ="1">
                             <dx:ASPxUploadControl ID="ASPxUploadControl1" runat="server" UploadMode="Auto" Width="280px">
                             </dx:ASPxUploadControl>
                            </td>
                         <td colspan ="1"></td>
                         <td colspan ="1"></td>
                         <td colspan ="1"></td>
                         <td colspan ="1"></td>
                         <td colspan ="1"></td>
                         <td colspan ="1"></td>

                     </tr>
                     <tr>
                            <td colspan ="1"></td>
                         <td colspan ="1">
                             <dx:ASPxButton ID="ASPxButton2" runat="server" Text="Create Back Up" Theme="BlackGlass">
                             </dx:ASPxButton>
                            </td>
                         <td colspan ="1"></td>
                         <td colspan ="1"></td>
                         <td colspan ="1"></td>
                         <td colspan ="1"></td>
                         <td colspan ="1"></td>
                         <td colspan ="1"></td>

                     </tr>
                     <tr>
                            <td colspan ="8">
<asp:Panel runat="server" ID="BackUphistory" Font-Names="Cambria" GroupingText="Back Up History">
    <dx:ASPxGridView ID="ASPxGridView1" runat="server" Theme="BlackGlass" Width="700px">
    </dx:ASPxGridView>
                                </asp:Panel>

                            </td>
                         
                     </tr>
 
                                           
            </table>    
            </asp:Panel>
            <table>
                <tr>
                    <td style="width: 850px" align="center">
                        </td>                
                </tr>
            </table>
        </td>
    </tr>
</table>
</asp:Panel>
</div>
</asp:Content>

