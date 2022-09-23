<%@ Page Language="VB" MasterPageFile="~/CDSUser.master" AutoEventWireup="false" CodeFile="depositors.aspx.vb" Inherits="Depositors" title="Depositors" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxTabControl" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>


<%@ Register assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dx1" %>


<%@ Register assembly="DevExpress.XtraCharts.v13.2.Web, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.XtraCharts.Web" tagprefix="dxchartsui" %>
<%@ Register assembly="DevExpress.XtraCharts.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.XtraCharts" tagprefix="cc1" %>


<%@ Register assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxFileManager" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxUploadControl" tagprefix="dx" %>


<%@ Register assembly="DevExpress.Web.ASPxScheduler.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxScheduler.Controls" tagprefix="dxwschsc" %>
<%@ Register assembly="DevExpress.Web.ASPxScheduler.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxScheduler" tagprefix="dxwschs" %>
<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView.Export" TagPrefix="dx" %>

<%@ Register assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxGridView" tagprefix="dx1" %>
<asp:Content id="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
        
    <asp:Panel id="Panel1" runat="server">
    
<table style="width:100%">
   
    
    <tr>
        <td >
          
             <dx:ASPxLabel ID="ASPxLabel1" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Reporting&gt;&gt;Depositors" Theme="PlasticBlue">
             </dx:ASPxLabel>
        </td>
    </tr>

   
    <tr>
        <td style="width: 100%;">
            <asp:Panel ID="panel4" runat="server" GroupingText="Depositors">
              
                    <table style="width: 100%;">
                        <tr>
                            <td>
                                <table>
                                    <tr>
                                        <td>
                                            <dx1:ASPxLabel ID="ASPxLabel55" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Search" Theme="Glass">
                    </dx1:ASPxLabel>
                                        </td>
                                        <td>
                                            <dx1:ASPxTextBox ID="txtsearch" runat="server" Height="19px" Theme="BlackGlass" Width="250px">
                    </dx1:ASPxTextBox>
                                        </td>
                                        <td>
                                            <dx1:ASPxButton ID="btnsearch" runat="server" Text="Search" Theme="BlackGlass">
                    </dx1:ASPxButton>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td align="center">
                                <dx:ASPxGridView ID="grdRules" runat="server" style="overflow:scroll" Theme="Glass" Width="100%">
                                </dx:ASPxGridView>
                                <br />
                                <br />
                                <dx:ASPxButton ID="ASPxButton8" runat="server" Text="Export to Excel">
                                </dx:ASPxButton>
                                <dx:ASPxGridViewExporter ID="ASPxGridViewExporter1" runat="server" GridViewID="grdRules">
                                </dx:ASPxGridViewExporter>
                                <dx:ASPxGridViewExporter ID="ASPxGridViewExporter2" runat="server" GridViewID="grdRules">
                                </dx:ASPxGridViewExporter>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="1"></td>
                        </tr>
                    </table>
                    <table>
                        <tr>
                            <td></td>
                        </tr>
                    </table>
                </asp:Panel>
          
            <table>
                <tr>
                    <td align="center" style="width: 850px"></td>
                </tr>
            </table>
        </td>
    </tr>

   
</table>
</asp:Panel>
</div>
</asp:Content>

