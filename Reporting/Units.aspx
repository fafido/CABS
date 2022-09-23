<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Units.aspx.vb" Inherits="Presettlement" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<%@ Register Assembly="BasicFrame.WebControls.BasicDatePicker" Namespace="BasicFrame.WebControls"
    TagPrefix="BDP" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server" style="background-color: #E4E4E4;">
        <div>
            <img src="../images/CDS-System_01.png" height="105" alt=""
                style="width: 100%">
        </div>
        <div>
            <table runat="server">
                <tr>
                    
                    
                    <td>
                        <asp:Button ID="Button1" runat="server" Text="Load" />
                    </td>
                </tr>
            </table>
        </div>
        <div>
            <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true" EnableDatabaseLogonPrompt="False" EnableParameterPrompt="False" ReuseParameterValuesOnRefresh="True" />
        </div>
    </form>
</body>
</html>
