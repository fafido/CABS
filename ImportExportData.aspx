<%@ Page Language="VB" AutoEventWireup="false" CodeFile="ImportExportData.aspx.vb"
    Inherits="Dealing_ImportExportData" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Automatic Trading System</title>
    <link href="../ATS/styles/masterStyle.css" rel="stylesheet" type="text/css" />
    <link href="../ATS/styles/layout.css" rel="stylesheet" type="text/css" />

 <link href="http://code.jquery.com/ui/1.9.0/themes/start/jquery-ui.css" rel="stylesheet" type="text/css" />
    
    <script src="http://code.jquery.com/jquery-1.8.2.js" type="text/javascript"></script>
    <script src="http://code.jquery.com/ui/1.9.0/jquery-ui.js" type="text/javascript"></script>

<style type="text/css">
body
{
    font-size:10px;
}
</style>
    <script type="text/javascript" language="javascript">
        $(document).ready(function() {
            $("input:submit").button();
            $("#txtDate").datepicker();
        });
        function validate() {
            var uploadcontrol = document.getElementById('<%=txtFile.ClientID%>').value;
            //Regular Expression for fileupload control.
            var reg = /^(([a-zA-Z]:)|(\\{2}\w+)\$?)(\\(\w[\w].*))+(.txt|.TXT)$/;
            if (uploadcontrol.length > 0) {
                //Checks with the control value.
                alert(uploadcontrol);
                if (reg.test(uploadcontrol)) {
                    return true;
                }
                else {
                    //If the condition not satisfied shows error message.
                    alert("Only .txt files are allowed!");
                    return false;
                }
            }
        } //End of function validate.

//        function OnPickDate(Pickerobj, divCalendar) {
//            divCalendar = document.getElementById(divCalendar);
//            if (divCalendar.style.display == "none")
//                divCalendar.style.display = "";
//            else
//                divCalendar.style.display = "none";
//        }
    </script>

</head>
<body>
    <form id="form1" runat="server">
    <asp:ToolkitScriptManager ID="TSM" runat="server">
    </asp:ToolkitScriptManager>
    <div>
        <table width="100%">
            <%--<tr>
                <td class="Page_header">
                    <table width="100%" cellpadding="0" cellspacing="0">
                        <tr>
                            <td>
                                <asp:Label ID="popupTitle" runat="server" Visible="false"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>--%>
            <tr>
                <td style="padding: 10px 5px 5px 5px" align="center">
                    <table width="100%" class="Form_panel Field_Box" cellpadding="2" cellspacing="2">
                        <tr>
                            <td colspan="3" style="height: 34px" valign="middle">
                                <asp:Panel ID="plImport" runat="server" Visible="False" Height="115px" Width="460px">
                                    <table align="center" style="padding-top:31px; vertical-align:middle;" width="75%">
                                        <tr>
                                            <td align="left" style="vertical-align: middle;">
                                                Select file name to import
                                                <br />
                                                <asp:FileUpload ID="txtFile" runat="server" Height="24px"/>
                                            </td>
                                            <td valign="bottom">
                                                <asp:Button ID="cmdImport" runat="server" style="font-size:12px;" Text="Import Orders" Width="95px" />
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                <asp:Panel ID="plExport" runat="server" Visible="False" Height="115px" Width="460px">
                                    <table align="center" style="padding-top:20px;">
                                        <tr>
                                            <td style="height: 10px">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" style="vertical-align: middle;">
                                                <asp:Label ID="Label1" runat="server" Text="Select Deal Date: "></asp:Label>
                                                <asp:TextBox Style="text-align: right" ID="txtDate" runat="server"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:Button ID="cmdExportDeals" runat="server" Text="Export Deals" style="font-size:12px;" Width="98px" />
                                            </td>
                                        </tr>
                                    </table>
                                    <asp:Button ID="Button1" Visible="false" runat="server" Text="Button" /></asp:Panel>
                                <asp:Label ID="lblmsg" runat="server" Width="430px" BackColor="#FFFFC0" BorderColor="#C04000"
                                    BorderStyle="Double" ForeColor="#0000C0" Visible="False"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td class="Footer_bg">
                    <table width="100%" class="Footer_Content">
                        <tr>
                            <td>
                                ESCROW 360&deg Automated Trading System
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
