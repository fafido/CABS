﻿<%@ Page Language="VB" AutoEventWireup="false" CodeFile="companyschedulereport.aspx.vb" Inherits="TSecReports_companyschedulereport" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Company Schedule Report</title>
    <link href="/aspnet_client/System_Web/2_0_50727/CrystalReportWebFormViewer3/css/default.css"
        rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <cr:crystalreportviewer id="CrystalReportViewer1" runat="server" autodatabind="true"
            style="z-index: 18; left: 0px; position: absolute; top: 0px" EnableParameterPrompt="False" ReuseParameterValuesOnRefresh="True" EnableDatabaseLogonPrompt="False"></cr:crystalreportviewer>
    
    </div>
    </form>
</body>
</html>
