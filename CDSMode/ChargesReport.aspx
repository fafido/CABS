<%@ Page Language="VB" AutoEventWireup="false" CodeFile="ChargesReport.aspx.vb" Inherits="CDSMode_ChargesReport" %>
<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>

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
                    <td>Date</td>
                    <td>
                        <BDP:BasicDatePicker ID="ddateFrom" runat="server" ReadOnly="True">
                        </BDP:BasicDatePicker>
                    </td>
                    <td>Charge Code</td>
                    <td>
                      <%--  <BDP:BasicDatePicker ID="ddateTo" runat="server" ReadOnly="True">
                        </BDP:BasicDatePicker>--%>

                        <dx:ASPxComboBox ID="ddateTo" runat="server" Height="22px" ValueType="System.String" Visible="True" Width="250px">
        </dx:ASPxComboBox>
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
