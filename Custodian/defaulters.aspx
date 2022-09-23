<%@ Page Language="VB" MasterPageFile="~/CDSUser.master" AutoEventWireup="false" CodeFile="defaulters.aspx.vb" Inherits="defaulters" title="Defaulters" %>

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
    
<table style="width:100%" >
   
    
    <tr>
        <td>
            <dx:ASPxLabel ID="ASPxLabel1" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Reporting&gt;&gt;Pledges" Theme="PlasticBlue"></dx:ASPxLabel>
            
                 <asp:Panel runat="server" GroupingText="Pledges">
<table style="width:100%">
            <tr>
                <td colspan ="8">
                    <table class="dxflInternalEditorTable_Glass">
                        <tr>
                            <td>
                                <asp:RadioButtonList ID="RadioButtonList1" runat="server" AutoPostBack="True" RepeatDirection="Horizontal" Font-Size="Small">
                                    <asp:ListItem>Active Pledges</asp:ListItem>
                                    <asp:ListItem>Foreclosure Pledges</asp:ListItem>
                                      <asp:ListItem>Released Pledges</asp:ListItem>
                                   
                                  
                                    
                                </asp:RadioButtonList>
                            </td>
                            
                        </tr>
                    </table>
                </td>

            </tr>
                <tr>
                    <td colspan="8">
                        <table class="dxflInternalEditorTable_Glass" style="width: 54%">
                            <tr>
                                <td>Date From</td>
                                <td>
                                    <dx:ASPxDateEdit ID="dtfrom" runat="server" AutoPostBack="True">
                                    </dx:ASPxDateEdit>
                                </td>
                                <td>Date To</td>
                                <td>
                                    <dx:ASPxDateEdit ID="dtto" runat="server" AutoPostBack="True">
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
                <td colspan="8">
                    &nbsp;</td>
            </tr>
                <tr>
                        <td colspan ="8" align="center">
                            <dx:ASPxGridView ID="grdRules" runat="server" Theme="Glass" Width="100%" style="overflow:scroll">
                                
                            </dx:ASPxGridView>
                            <br />
                            <br />
                             <dx:ASPxButton ID="ASPxButton8" runat="server" Text="Export to Excel">
                                                                    </dx:ASPxButton>
                                                                    <dx:ASPxGridViewExporter ID="ASPxGridViewExporter1" GridViewID="grdRules" runat="server">
                                                                    </dx:ASPxGridViewExporter>
                        <dx:ASPxGridViewExporter ID="ASPxGridViewExporter2" GridViewID="grdRules" runat="server">
                                                                    </dx:ASPxGridViewExporter>
                            

                        </td>

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

