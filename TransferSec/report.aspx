<%@ Page Language="VB" AutoEventWireup="false" CodeFile="report.aspx.vb" Inherits="TransferSec_report" %>

<%@ Register assembly="DevExpress.XtraReports.v13.2.Web, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.XtraReports.Web" tagprefix="dx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <dx:ASPxDocumentViewer ID="ASPxDocumentViewer1" runat="server" EnableTheming="True" ReportTypeName="XtraReport1" Theme="BlackGlass">
        </dx:ASPxDocumentViewer>
    
    </div>
    </form>
</body>
</html>
