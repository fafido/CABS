<%@ Page Language="VB" AutoEventWireup="false" CodeFile="dashboardpage.aspx.vb" Inherits="dashboardpage" Title="Business Intelligence" %>

<%@ Register assembly="DevExpress.Dashboard.v13.2.Web, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.DashboardWeb" tagprefix="dx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <align="center">
    <form id="form1"  runat="server">
    <div>
                                <asp:ScriptManager ID="ScriptManager1" runat="server">
                                </asp:ScriptManager>
                                <asp:Timer ID="Timer1" runat="server" Interval="30000">
                                </asp:Timer>
      <dx:ASPxDashboardViewer ID="ASPxDashboardViewer2" runat="server" DashboardSource="~/ReportFiles/trading.xml" RegisterJQuery="True" Width="100%"  AllowExportDashboard="False" AllowExportDashboardItems="True" DashboardTheme="Dark">
        </dx:ASPxDashboardViewer>
        <dx:ASPxDashboardViewer ID="ASPxDashboardViewer1" runat="server" DashboardSource="~/ReportFiles/mydash2.xml" RegisterJQuery="True" Width="100%" AllowExportDashboard="False" AllowExportDashboardItems="True" DashboardTheme="Dark">
        </dx:ASPxDashboardViewer>
    
      
    
    </div>
    </form>
        </align>
</body>
</html>
