<%@ Page Language="VB" MasterPageFile="~/CDSUser.master" AutoEventWireup="false" CodeFile="charges.aspx.vb" Inherits="Charges" title="Charges" %>

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

<asp:Content id="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
        
    <asp:Panel id="Panel1" runat="server">
    
<table style="width:100%">
   
    
    <tr>
        <td >
             <asp:Panel runat="server" ID="panel4" GroupingText="Reporting&gt;&gt;Charges">
                 <asp:Panel runat="server" GroupingText="Charges">
<table style="width:100%">
            <tr>
                <td colspan ="6">
                    <table class="dxflInternalEditorTable_Glass">
                        <tr>
                            <td>
                                &nbsp;</td>
                            
                        </tr>
                    </table>
                </td>

            </tr>
                <tr>
                    <td colspan="2">
                        <asp:RadioButtonList ID="RadioButtonList1" runat="server" AutoPostBack="True" RepeatDirection="Horizontal">
                            <asp:ListItem>Depositor</asp:ListItem>
                            <asp:ListItem>Warehouse</asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                    <td colspan="2">
                        <asp:DropDownList ID="DropDownList2" runat="server" AppendDataBoundItems="true">
                            <asp:ListItem>All</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>&nbsp;</td>
                    <td>
                        &nbsp;</td>
                    
                       
                   
                    <td>
                        &nbsp;</td>
                    <td>&nbsp;</td>
            </tr>
            <tr>
                <td style="width: 87px">&nbsp;</td>
                <td style="width: 176px">&nbsp;</td>
                <td style="width: 71px">&nbsp;</td>
                <td style="width: 160px">&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td style="width: 87px">Date From</td>
                <td style="width: 176px">
                    <dx:ASPxDateEdit ID="dtfrom" runat="server" AutoPostBack="True">
                    </dx:ASPxDateEdit>
                </td>
                <td style="width: 71px">Date To</td>
                <td style="width: 160px">
                    <dx:ASPxDateEdit ID="dtto" runat="server" AutoPostBack="True">
                    </dx:ASPxDateEdit>
                </td>
                <td>Charge</td>
                <td>
                    <asp:DropDownList ID="DropDownList1" runat="server" AppendDataBoundItems="true">
                        <asp:ListItem>All Charges</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    <dx:ASPxButton ID="ASPxButton1" runat="server" Text="View">
                    </dx:ASPxButton>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td colspan="6">
                    &nbsp;</td>
            </tr>
                <tr>
                        <td colspan ="6" align="center">
                            <dx:ASPxGridView ID="grdRules" runat="server" Theme="Glass" Width="100%" style="overflow:scroll">
                                
                            </dx:ASPxGridView>
                            <br />
                            <br />
                             <dx:ASPxButton ID="ASPxButton8" runat="server" Text="Export to Excel">
                                                                    </dx:ASPxButton>
                                                                    <dx:ASPxGridViewExporter ID="ASPxGridViewExporter1" GridViewID="grdRules"  FileName="ChargesExport" runat="server">
                                                                    </dx:ASPxGridViewExporter>
                        <dx:ASPxGridViewExporter ID="ASPxGridViewExporter2" GridViewID="grdRules" runat="server">
                                                                    </dx:ASPxGridViewExporter>
                            

                        </td>

                </tr>
                
            </table>
            <table>
                <tr>
                    <td></td>
                </tr>
            </table>
 </asp:Panel>

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

