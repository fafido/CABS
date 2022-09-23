<%@ Page Language="VB" AutoEventWireup="false" CodeFile="bondsetup2.aspx.vb"
    Inherits="ATS_bondsetup2" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">



<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Company Management</title>


    <link href="../Plugins/css/calendar-blue.css" rel="stylesheet" />
    <link href="../ATS/styles/layout.css" rel="stylesheet" type="text/css" />
    <link href="../ATS/styles/masterStyle.css" rel="stylesheet" type="text/css" />
    <link href="http://code.jquery.com/ui/1.9.0/themes/start/jquery-ui.css" rel="stylesheet"
        type="text/css" />


    <script src="../Plugins/js/jquery-1.4.1.min.js" type="text/javascript"></script>
    <script src="../Plugins/js/jquery-ui.js" type="text/javascript"></script>
    <script src="../Plugins/js/jquery.dynDateTime.min.js" type="text/javascript"></script>
    <script src="../Plugins/js/calendar-en.min.js" type="text/javascript"></script>
    <script src="http://code.jquery.com/jquery-1.8.2.js" type="text/javascript"></script>

    <script src="http://code.jquery.com/ui/1.9.0/jquery-ui.js" type="text/javascript"></script>

    <script type="text/javascript">
        $(document).ready(function () {
            $("#<%#txtIssueDate.ClientID %>").dynDateTime({
                ifFormat: "%m/%d/%Y",
                daFormat: "%l;%M %p, %e %m,  %Y",
                align: "BR",
                electric: false,
                singleClick: false,
                displayArea: ".siblings('.dtcDisplayArea')",
                button: ".next()"
            });

            $("#<%#txtMaturityDate.ClientID %>").dynDateTime({
                ifFormat: "%m/%d/%Y",
                daFormat: "%l;%M %p, %e %m,  %Y",
                align: "BR",
                electric: false,
                singleClick: false,
                displayArea: ".siblings('.dtcDisplayArea')",
                button: ".next()"
            });

            $("#<%#txtCapital.ClientID %>").dynDateTime({

                ifFormat: "%m/%d/%Y",
                daFormat: "%l;%M %p, %e %m,  %Y",
                align: "BR",
                electric: false,
                singleClick: false,
                displayArea: ".siblings('.dtcDisplayArea')",
                button: ".next()"
            });

            <%--       $("#<%=datepicker3.ClientID %>").dynDateTime({

                ifFormat: "%m/%d/%Y",
                daFormat: "%l;%M %p, %e %m,  %Y",
                align: "BR",
                electric: false,
                singleClick: false,
                displayArea: ".siblings('.dtcDisplayArea')",
                button: ".next()"
            });--%>

        });
    </script>

    <%-- <script type="text/javascript">
        $(document).ready(function () {
            //$("input:submit").button();--%>

    <%--     $("#<%=txtIssueDate.ClientID %>").dynDateTime({
                ifFormat: "%m/%d/%Y",
                daFormat: "%l;%M %p, %e %m,  %Y",
                align: "BR",
                electric: false,
                singleClick: false,
                displayArea: ".siblings('.dtcDisplayArea')",
                button: ".next()"
            });

            $("#<%=txtMaturityDate.ClientID %>").dynDateTime({
                ifFormat: "%m/%d/%Y",
                daFormat: "%l;%M %p, %e %m,  %Y",
                align: "BR",
                electric: false,
                singleClick: false,
                displayArea: ".siblings('.dtcDisplayArea')",
                button: ".next()"
            });

            $("#<%=txtCapital.ClientID %>").dynDateTime({

                ifFormat: "%m/%d/%Y",
                daFormat: "%l;%M %p, %e %m,  %Y",
                align: "BR",
                electric: false,
                singleClick: false,
                displayArea: ".siblings('.dtcDisplayArea')",
                button: ".next()"
            });
        });
    </script>--%>

    <%--<script type="text/javascript">
        function ISdINChk() {
            var isi = document.getElementById("<%#txtISIN.ClientID%>").value;

            if (isi != '') {
                //return alert(isi);
                return isValidISIN(isi);;
            }
            else { }
        }--%>
    <%--        function isValidISIN(isin) {
            // return alert('hi');
            // basic pattern (BE|BM|FR|BG|VE|DK|HR|DE|JP|HU|HK|JO|BR|XS|FI|GR|IS|RU|LB|PT|NO|TW|UA|TR|LK|LV|LU|TH|NL|PK|PH|RO|EG|PL|AA|CH|CN|CL|EE|CA|IR|IT|ZA|CZ|CY|AR|AU|AT|IN|CS|CR|IE|ID|ES|PE|TN|PA|SG|IL|US|MX|SK|KR|SI|KW|MY|MO|SE|GB|GG|KY|JE|VG|NG|SA|MU|MT)
            if (isin != '' || isin != null) {
                var regex = /^([A-Z]{2})([0-9A-Z]{9})([0-9])$/;
                var match = regex.exec(isin);
                if (match != null) {
                    if (match.length != 4) { document.getElementById("<%#lblErrISIN.ClientID%>").style.display = 'inherit'; return false };
                    //            // validate the check digit
                <%--    if ((match[3] != calcISINCheck(match[1] + match[2]))) {
                        document.getElementById("<%#lblErrISIN.ClientID%>").style.display = 'inherit';
                        document.getElementById("<%#txtISIN.ClientID%>").value = '';
                    }--%>

    <%--     document.getElementById("<%#lblErrISIN.ClientID%>").style.display = 'none';

                    return (match[3] == calcISINCheck(match[1] + match[2]));
                }
                else {
                    document.getElementById("<%#lblErrISIN.ClientID%>").style.display = 'inherit'; document.getElementById("<%#txtISIN.ClientID%>").value = '';
                    return false;
                };
            }
        //}--%>
    <%--    function calcISINCheck(code) {
            var conv = '';
            var digits = '';
            var sd = 0;
            // convert letters
            for (var i = 0; i < code.length; i++) {
                var c = code.charCodeAt(i);
                conv += (c > 57) ? (c - 55).toString() : code[i]
            }
            // group by odd and even, multiply digits from group containing rightmost character by 2
            for (var i = 0; i < conv.length; i++) {
                digits += (parseInt(conv[i]) * ((i % 2) == (conv.length % 2 != 0 ? 0 : 1) ? 2 : 1)).toString();
            }
            // sum all digits
            for (var i = 0; i < digits.length; i++) {
                sd += parseInt(digits[i]);
            }
            // subtract mod 10 of the sum from 10, return mod 10 of result 
            return (10 - (sd % 10)) % 10;
        }
    </script>--%>
    <style type="text/css">
        .TextBox_toolong {
            height: 22px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ToolkitScriptManager ID="TSM" runat="server">
        </asp:ToolkitScriptManager>
        <div>
            <table width="100%">
                <tr>
                    <td class="Page_header">
                        <table width="100%" cellpadding="0" cellspacing="0">
                            <tr>
                                <td style="width: 190px">
                                    <div style="float: left">
                                        <img align="middle" style="border: none;" src="Images/360-ATS-02.png" title="ATS"
                                            id="Img1" alt="Automated Trading System">
                                    </div>
                                </td>
                                <td>Welcome To Automated Trading System
                                </td>
                                <td width="30px;" align="right" style="padding: 2px 10px 0px 0px;">
                                    <asp:ImageButton ID="btnHome" runat="server" Style="width: 30px; height: 30px" ImageUrl="~/ATS/styles/images/home.png" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:TabContainer ID="tabCompany" runat="server" ActiveTabIndex="0" CssClass="ajax__myTab">
                            <asp:TabPanel ID="tpnlCompany" runat="server">
                                <HeaderTemplate>
                                    Create Bond
                                </HeaderTemplate>
                                <ContentTemplate>
                                    <table>
                                        <tr>
                                            <td class="Form_container" style="padding-top: 20px; padding-bottom: 20px; padding-right: 100px; padding-left: 100px;">
                                                <div class="Form_title_panel">
                                                    <span class="Form_title">Bond Setup </span>
                                                </div>


                                                <table class="Form_panel" cellpadding="0" cellspacing="5">
                                                    <tr>
                                                        <td valign="top" class="Form_sub_panel_outer">
                                                            <asp:ValidationSummary ID="ValidationSummary1" ValidationGroup="Submit" runat="server" />
                                                            <table width="100%" class="Field_Box" cellpadding="2" cellspacing="2">
                                                                <tr>
                                                                    <td class="Field_Text" style="width: 226px">
                                                                        <span style="color: Red">*<span style="color: #000000"> Issuer</span></span>
                                                                    </td>
                                                                    <td class="Field_Value" style="width: 299px">
                                                                        <asp:DropDownList runat="server" ID="txtIssuer" Width="180px">
                                                                        </asp:DropDownList>
                                                                        <asp:RequiredFieldValidator ID="re1" runat="server" ControlToValidate="txtIssuer"
                                                                            ErrorMessage="Issuer Required" SetFocusOnError="True" ValidationGroup="Submit">*</asp:RequiredFieldValidator>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="Field_Text" style="width: 226px">
                                                                        <span style="color: Red">*<span style="color: #000000"> Series</span></span>
                                                                    </td>
                                                                    <td class="Field_Value" style="width: 299px">
                                                                        <asp:TextBox ID="txtSeries" runat="server" Width="180px"></asp:TextBox>
                                                                    </td>

                                                                </tr>
                                                                <tr>
                                                                    <td class="Field_Text" style="width: 226px">
                                                                        <span style="color: Red">*Type</span>&nbsp;
                                                                    </td>
                                                                    <td>
                                                                        <asp:DropDownList runat="server" CssClass="form-control" ID="day" AutoPostBack="True" Width="180px">
                                                                            <asp:ListItem Text="Corporate" Value="Corporate"></asp:ListItem>
                                                                            <asp:ListItem Text="Municipal" Value="Municipal"></asp:ListItem>
                                                                        </asp:DropDownList>
                                                                    </td>
                                                        </td>
                                                    </tr>

                                                    <tr>
                                                        <td class="Field_Text" style="width: 226px">Face Value&nbsp;
                                                        </td>
                                                        <td class="Field_Value" style="width: 299px">
                                                            <asp:TextBox ID="txtFaceValue" runat="server" CssClass="TextBox_toolong"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="Field_Text" style="width: 226px;">Number of Notes Issued &nbsp; &nbsp;
                                                        </td>
                                                        <td class="Field_Value" style="width: 299px">
                                                            <asp:TextBox ID="txtNumOfNotes" runat="server" CssClass="TextBox_toolong"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="Field_Text" style="width: 226px;">Coupon Rate
                                                        </td>
                                                        <td class="Field_Value" style="width: 299px">
                                                            <asp:TextBox ID="txtCouponRate" runat="server" CssClass="TextBox_toolong" MaxLength="50"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="Field_Text" style="width: 226px">Number of Coupon Payments in a Year
                                                        </td>
                                                        <td class="Field_Value" style="width: 299px">
                                                            <asp:TextBox ID="txtNumOfCouponPyts" runat="server" CssClass="TextBox_toolong" MaxLength="255"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="Field_Text" style="width: 226px">Issue Date
                                                        </td>
                                                        <td class="Field_Value" style="width: 299px">
                                                            <asp:TextBox ID="txtIssueDate" runat="server" CssClass="TextBox_toolong" ValidationGroup="Submit"
                                                                MaxLength="50"></asp:TextBox>
                                                            <asp:Label ID="lblErrISIN" runat="server" ForeColor="Red" Text="Invalid ISIN" Style="display: none;"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="Field_Text" style="width: 226px">Maturity Date
                                                        </td>
                                                        <td class="Field_Value" style="width: 299px">

                                                            <asp:TextBox ID="txtMaturityDate" runat="server" CssClass="TextBox_toolong" MaxLength="255" AutoPostBack="True" OnTextChanged="txtMaturityDate_TextChanged"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="Field_Text" style="width: 226px">Tenure
                                                        </td>
                                                        <td class="Field_Value" style="width: 299px">
                                                            <asp:TextBox ID="txtTenure" runat="server" CssClass="TextBox_toolong" MaxLength="100"></asp:TextBox>
                                                        </td>
                                                    </tr>

                                                    <tr>
                                                        <td class="Field_Text" style="width: 226px">Number of Capital Repayments
                                                        </td>
                                                        <td class="Field_Value" style="width: 299px">
                                                            <asp:TextBox ID="TextBox1" runat="server" CssClass="TextBox_toolong" AutoPostBack="True" MaxLength="100"></asp:TextBox>

                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="Field_Text" style="width: 226px">Capital Repayment Dates
                                                        </td>
                                                        <td class="Field_Value" style="width: 299px">
                                                            <asp:TextBox ID="txtCapital" runat="server" CssClass="TextBox_toolong" MaxLength="100"></asp:TextBox>

                                                        </td>
                                                        <td>
                                                            <asp:Button runat="server" Text="Add" ID="btnAdd" class="btn btn-primary" />
                                                        </td>
                                                    </tr>

                                                    <tr>
                                                        <td></td>
                                                        <td> <asp:Label ID="TextArea1" runat="server"></asp:Label></td>
                                                        <td></td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center">
                                                <asp:Label ID="lblError" runat="server" ForeColor="Red"></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                    <div class="Form_footer">
                                        <table width="100%" class="Form_footer_Content">
                                            <tr>
                                                <td align="right">
                                                    <asp:Button ID="btnSave" Font-Size="12px" runat="server" Text="Save" ValidationGroup="Submit"
                                                        OnClientClick="javascript:return ISINChk();" CssClass="button"  OnClick="btnSave_Click" />
                                                    &nbsp;
                                                            <asp:Button ID="btn_Clear" Font-Size="12px" runat="server" Text="Clear" CssClass="button" />&nbsp;
                                                            <asp:Button ID="btn_Close" Font-Size="12px" runat="server" Text="Close" CssClass="button" />
                                                </td>
                                            </tr>
                                        </table>
                                        <asp:HiddenField ID="hfPwd" runat="server" />
                                        <asp:HiddenField ID="Uid" runat="server" />
                                        <asp:HiddenField ID="Mode" runat="server" />
                                    </div>
                                    </td>
                                        </tr>
                                    </table>
                                </ContentTemplate>
                            </asp:TabPanel>
                            <asp:TabPanel ID="tpnlSuspend" runat="server">
                                <HeaderTemplate>
                                    Suspend Bond
                                </HeaderTemplate>
                                <ContentTemplate>
                                    <table>
                                        <tr>
                                            <td class="Form_container" style="padding-top: 20px; padding-bottom: 20px; padding-right: 100px; padding-left: 100px;">
                                                <div class="Form_title_panel">
                                                    <span class="Form_title">Suspend Company </span>
                                                </div>
                                                <table class="Form_panel" cellpadding="0" cellspacing="5">
                                                    <tr>
                                                        <td class="Field_Text" width="153px">Select Company Name
                                                        </td>
                                                        <td class="Field_Value">
                                                            <asp:DropDownList runat="server" ID="ddlCompany" Width="243px" 
                                                               />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="Field_Text" width="153px">&nbsp;
                                                        </td>
                                                        <td class="Field_Value">&nbsp;
                                                        </td>
                                                    </tr>
                                                </table>
                                                <div class="Form_footer">
                                                    <table class="Form_footer_Content" width="100%">
                                                        <tr>
                                                            <td align="right">
                                                                <asp:Button ID="btnSuspend" Font-Size="12px" runat="server" Text="Suspend company"
                                                                    Width="124px" />
                                                                <asp:Button ID="btnAllow" Font-Size="12px" runat="server" Text="Allow company" Width="124px" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </div>
                                                <asp:Label ID="lblMsg" runat="server" BorderColor="#C0C0FF" Font-Bold="True" Font-Names="Calibri"
                                                    ForeColor="#0000C0" Width="495px"></asp:Label><br />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                               
                                            </td>
                                        </tr>
                                    </table>
                                </ContentTemplate>
                            </asp:TabPanel>
                        </asp:TabContainer>
                    </td>
                </tr>
                <tr>
                    <td class="Footer_bg">
                        <table width="100%" class="Footer_Content">
                            <td width="50%" align="left">
                                <img align="middle" style="border: none;" src="Images/Escrow_logo.png" title="ATS"
                                    id="Img2" alt="Automated Trading System">
                            </td>
                            <td width="50%" align="left">ESCROW 360&deg Automated Trading System
                            </td>
                        </table>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
