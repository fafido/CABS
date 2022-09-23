<%@ Page Language="VB" AutoEventWireup="false" CodeFile="BrokerAuditReport.aspx.vb" Inherits="Reporting_BrokerAuditReport" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
  <%--<script lang="javaScript" type="text/javascript" src="/crystalreportviewers13/js/crviewer/crv.js"></script>--%>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true" EnableDatabaseLogonPrompt="False" EnableParameterPrompt="False" ReuseParameterValuesOnRefresh="True" />
    </div>
    </form>
</body>
</html>
