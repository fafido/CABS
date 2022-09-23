<%@ Page Language="VB" AutoEventWireup="false" CodeFile="sendmail.aspx.vb" Inherits="sendmail" Title="Business Intelligence" %>

<%@ Register assembly="DevExpress.Dashboard.v13.2.Web, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.DashboardWeb" tagprefix="dx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        #frame {
            width: 1361px;
            height: 591px;
        }
    </style>
</head>
<body>
    <align="center">
    <form id="form1"  runat="server">
    <div>
    <iframe runat="server" id="frame"></iframe>
      
    
        <asp:Timer ID="Timer1" runat="server">
        </asp:Timer>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <br />
      
    
    </div>
    </form>
        </align>
</body>
</html>
