<%@ Page Language="VB" MasterPageFile="~/CDSUser.master" AutoEventWireup="false" CodeFile="SystemCalender.aspx.vb" Inherits="BrokerMode_SystemCalender" title="Broker Home" %>

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


<%@ Register assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxGridView" tagprefix="dx1" %>


<asp:Content id="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
    <asp:Panel id="Panel1" runat="server">
    
<table style="width:100%">
    <tr>
        <td style="width: 712px; height: 226px" valign="top">
       
            <table>
            <tr>
                <td style="width: 870px" align="left">
                    <asp:Label id="Label1" runat="server" text="Utilities&gt;&gt;System Calendar" font-names="Cambria" width="275px"></asp:Label></td>
            </tr>
                               
            </table>  
            <asp:Panel runat="server" ID="PanelASet" Font-Names="Cambria" GroupingText="Calendar">
                 <table>
            
                <tr>
                        <td colspan ="1">
                            &nbsp;</td>
                    
                    <td align="center">
                        <dx:ASPxCalendar ID="ASPxCalendar1" runat="server" Theme="MetropolisBlue" Width="600px">
                        </dx:ASPxCalendar>
                        </td>
                    
                </tr>
                <tr>
                    <td colspan ="1">
                        <dx:ASPxLabel ID="ASPxLabel1" runat="server" Text="Holiday Comments">
                        </dx:ASPxLabel>
                    </td>
                    <td>
                        <dx:ASPxTextBox ID="txtHolidayComments" runat="server" Height="80px" Theme="Aqua" Width="600px">
                        </dx:ASPxTextBox>
                    </td>
                </tr>
                <tr>
                    <td align ="center" colspan="2" style="height: 19px" >
                        <dx:ASPxButton ID="ASPxButton1" runat="server" Text="Save" Theme="BlackGlass">
                        </dx:ASPxButton>
                    </td>
                </tr>
                                           
                     <tr>
                         <td align="center" colspan="2">
                             <dx1:ASPxGridView ID="ASPxGridView2" runat="server" KeyFieldName="id" SettingsPager-Mode="ShowAllRecords" Theme="Glass" Width="640px">
                                 <Columns>
                                     <dx:GridViewDataColumn Caption="" VisibleIndex="0">
                                         <dataitemtemplate>
                                             <asp:LinkButton ID="SelectID" runat="server" CommandArgument='<%# Eval("ID") %>' CommandName="Edit" Text="Edit">
                                             </asp:LinkButton>
                                         </dataitemtemplate>
                                     </dx:GridViewDataColumn>
                                     <dx:GridViewDataColumn Caption="" VisibleIndex="0">
                                         <dataitemtemplate>
                                             <asp:LinkButton ID="DeleteID" runat="server" CommandArgument='<%# Eval("ID") %>' CommandName="Delete" OnClientClick="if ( !confirm('Are you sure you want to delete ? ')) return false;" Text="Delete">
                                             </asp:LinkButton>
                                         </dataitemtemplate>
                                     </dx:GridViewDataColumn>
                                     <dx:GridViewDataColumn Caption="Date">
                                         <dataitemtemplate>
                                             <dx:aspxlabel runat="server" Text='<%# Eval("Date") %>'>
                                            </dx:aspxlabel>
                                         </dataitemtemplate>
                                     </dx:GridViewDataColumn>
                                     <dx:GridViewDataColumn Caption="Holiday">
                                         <dataitemtemplate>
                                             <dx:aspxlabel runat="server" Text='<%# Eval("Comment") %>'>
                                            </dx:aspxlabel>
                                         </dataitemtemplate>
                                     </dx:GridViewDataColumn>
                                 </Columns>
                             </dx1:ASPxGridView>
                         </td>
                     </tr>
                                           
            </table>    
            </asp:Panel>
            <table>
                <tr>
                    <td style="width: 850px" align="center">
                        <asp:Label ID="lblid" runat="server" Visible="False"></asp:Label>
                        </td>                
                </tr>
            </table>
        </td>
    </tr>
</table>
</asp:Panel>
</div>
</asp:Content>

