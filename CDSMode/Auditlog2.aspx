<%@ Page Language="VB" MasterPageFile="~/CDSuser.master" AutoEventWireup="false" CodeFile="Auditlog2.aspx.vb" Inherits="Auditlog2" %>
<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>

<%@ Register assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxFileManager" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxUploadControl" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxObjectContainer" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxPopupControl" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxDocking" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Dashboard.v13.2.Web, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.DashboardWeb" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.ASPxGauges.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxGauges" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.ASPxGauges.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxGauges.Gauges" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.ASPxGauges.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxGauges.Gauges.Linear" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.ASPxGauges.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxGauges.Gauges.Circular" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.ASPxGauges.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxGauges.Gauges.State" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.ASPxGauges.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxGauges.Gauges.Digital" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxGridLookup" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxGridView.Export" tagprefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
    <asp:Panel id="Panel1" runat="server" Width="100%" Font-Names="Arial" Font-Size="Medium" BackColor="White">
    
        <table width ="100%">
            <tr>
                   <td style ="text-align :left;" align="left">
                       <dx:ASPxLabel ID="ASPxLabel1" runat="server" Text="Auditing&gt;&gt;Audit Log" Font-Names="Cambria" Font-Size="Small" Theme="PlasticBlue"></dx:ASPxLabel>

                   </td>
            </tr>
        </table>
        <asp:panel id="Panel5" runat="server" GroupingText="Search Options" Font-Names="Cambria">
        <table width ="100%">
            <tr>
                <td colspan ="1" style="width: 109px">
                    <dx:ASPxLabel ID="ASPxLabel11" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Date From" Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                <td width="301">
                    <dx:ASPxDateEdit ID="txtDateFrom" runat="server" Theme="BlackGlass">
                    </dx:ASPxDateEdit>
                </td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>

            </tr>
            <tr>
                <td colspan ="1" style="width: 109px; height: 23px;">
                    <dx:ASPxLabel ID="ASPxLabel12" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Date To" Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                <td width="301" style="height: 23px">
                    <dx:ASPxDateEdit ID="txtDateTo" runat="server" Theme="BlackGlass">
                    </dx:ASPxDateEdit>
                </td>
                <td colspan ="1" style="height: 23px"></td>
                <td colspan ="1" style="height: 23px"></td>
                <td colspan ="1" style="height: 23px"></td>

            </tr>
            <tr>
                <td colspan="1" style="width: 109px; height: 23px;">&nbsp;</td>
                <td style="height: 23px" width="301">&nbsp;</td>
                <td colspan="1" style="height: 23px">&nbsp;</td>
                <td colspan="1" style="height: 23px">&nbsp;</td>
                <td colspan="1" style="height: 23px">&nbsp;</td>
            </tr>
            <tr>
                <td colspan="1" style="width: 109px; height: 16px;"></td>
                <td colspan ="1" style="height: 16px">
                    <dx:ASPxButton ID="btnPrint" runat="server" Text="View" Theme="BlackGlass" Width="150px">
                    </dx:ASPxButton>
                </td>
                <td style="height: 16px"></td>
                <td style="height: 16px"></td>
                <td style="height: 16px"></td>
            </tr>

            <tr>
                <td colspan="5" style="height: 16px;">
                    <dx:ASPxGridView ID="ASPxGridView1" runat="server" EnablePagingGestures="False" Theme="Glass" Width="100%">
                    </dx:ASPxGridView>
                </td>
            </tr>

            <tr>
                <td colspan="5">
                    &nbsp;</td>
            </tr>
            <tr>
                <td colspan="5" style="height: 19px;">&nbsp;</td>
            </tr>
            <tr>
                <td colspan="5">&nbsp;</td>
            </tr>

        </table>

    </asp:panel>
         
</asp:Panel>
  
</div>
</asp:Content>