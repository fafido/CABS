<%@ Page Language="VB" MasterPageFile="~/CDSUser.master" AutoEventWireup="false" CodeFile="Orders.aspx.vb" Inherits="Orders" title="Orders" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxTabControl" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>


<%@ Register assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dx" %>



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
          
             <dx:ASPxLabel ID="ASPxLabel1" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Reporting&gt;&gt;Warehouse Receipts" Theme="PlasticBlue">
             </dx:ASPxLabel>
        </td>
    </tr>

   
    <tr>
        <td style="width: 100%;">
            <asp:Panel ID="panel4" runat="server" GroupingText="Warehouse Receipts">
              
                    <table style="width: 100%;">
                        <tr>
                            <td>
                                <table class="dxflInternalEditorTable_Glass">
                                    <tr>
                                        <td>
                                            <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal" Font-Size="Small">
                                                <asp:ListItem value="All Warehouse Receipts">All Warehouse Receipts</asp:ListItem>
                                                <asp:ListItem value="Pending Approval">Pending Approval</asp:ListItem>
                                                <asp:ListItem value="Approved">Approved</asp:ListItem>
                                                <asp:ListItem value="Expired">Expired</asp:ListItem>
                                                <asp:ListItem  value="Cancelled">Cancelled</asp:ListItem>
                                            </asp:RadioButtonList>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <table>
                                    <tr>
                                        <td>
                                            <dx:ASPxLabel ID="ASPxLabel4" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Date From" Theme="Glass">
            </dx:ASPxLabel>
                                        </td>
                                        <td>
                                            <dx:ASPxDateEdit ID="dtfrom" runat="server">
                                            </dx:ASPxDateEdit>
                                        </td>
                                        <td>
                                            <dx:ASPxLabel ID="ASPxLabel5" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Date To" Theme="Glass">
                                            </dx:ASPxLabel>
                                        </td>
                                        <td>
                                            <dx:ASPxDateEdit ID="dtto" runat="server">
                                            </dx:ASPxDateEdit>
                                        </td>
                                        <td>
                                            <dx:ASPxButton ID="ASPxButton1" runat="server" Text="View">
                                            </dx:ASPxButton>
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

