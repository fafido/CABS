<%@ Page Language="VB" AutoEventWireup="false" CodeFile="PendingSettlement.aspx.vb" Inherits="PendingSettlement" %>

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
                    <td>Date From</td>
                    <td>
                        <BDP:BasicDatePicker ID="ddateFrom" runat="server" ReadOnly="True">
                        </BDP:BasicDatePicker>
                    </td>
                    <td>Date To</td>
                    <td>
                        <BDP:BasicDatePicker ID="ddateTo" runat="server" ReadOnly="True">
                        </BDP:BasicDatePicker>
                    </td>
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
