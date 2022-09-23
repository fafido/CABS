<%@ Page Language="VB" AutoEventWireup="false" CodeFile="EndOfDayTradeCRV.aspx.vb" Inherits=" ReportPages_EndOfDayTradeCRV" %>

<%@ Register assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>

<!DOCTYPE html>
<script runat="server">

    Protected Sub Page_Load(sender As Object, e As EventArgs)

    End Sub
</script>


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <CR:CrystalReportViewer ID="crvEODTrade" runat="server" AutoDataBind="true" />
    
    </div>
    </form>
</body>
</html>
