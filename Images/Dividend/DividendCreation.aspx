<%@ Page Language="VB" MasterPageFile="~/TSEc.master" AutoEventWireup="false" CodeFile="DividendCreation.aspx.vb" Inherits="Dividend_DividendInstructions" title="Deposit Securities" %>

<%@ Register Assembly="BasicFrame.WebControls.BasicDatePicker" Namespace="BasicFrame.WebControls"
    TagPrefix="BDP" %>
<asp:Content id="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div>
    <asp:Panel id="Panel1" runat="server">
    
<table style="border-right: #000033 thin solid; border-top: #000033 thin solid; border-left: #000033 thin solid; width: 832px; border-bottom: #000033 thin solid; background-color: #ffffff">
    <tr>
        <td style="width: 712px; height: 226px" valign="top">
            <table>
            <tr>
                <td style="width: 870px" align="center">
                    <asp:Label id="Label4" runat="server" backcolor="#8080FF" font-bold="True" font-names="Arial"
                        Text="Dividend Creation" width="848px"></asp:Label></td>
            </tr>
                <tr>
                    <td colspan ="4" valign="top">
                        <asp:Label id="Label1" runat="server" Text="Company" width="144px" font-names="Verdana" font-size="Small"></asp:Label>&nbsp;<asp:DropDownList
                            id="cmbCompany" runat="server" width="192px" autopostback="True">
                        </asp:DropDownList>
                        </td>
                </tr>
                
            </table>
            <table>
                <tr>
                    <td style="width: 146px">
                        <asp:Label id="Label2" runat="server" Text="Dividend Number" font-names="Verdana" font-size="Small"></asp:Label></td>
                        <td style="width: 3px">
                            <asp:DropDownList id="cmbDividend" runat="server" width="192px">
                            </asp:DropDownList></td>
                            <td style="width: 3px">
                                </td>
                                <td>
                                    </td>
                                    <td style="width: 141px">
                                        <asp:Label id="LblDivType" runat="server"></asp:Label></td>
                </tr>                
            </table>
            <table>
                <tr>
                    <td style="width: 146px">
                        <asp:Label id="Label3" runat="server" Text="Dividend Type" font-names="Verdana" font-size="Small"></asp:Label></td>
                    <td style="width: 148px">
                        &nbsp;<asp:TextBox id="txtDivTypes" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="width: 146px">
                        <asp:Label id="Label5" runat="server" Text="Date Announced" font-names="Verdana" font-size="Small"></asp:Label></td>
                    <td style="width: 148px">
                        &nbsp;<asp:TextBox id="txtDateAnn" runat="server" ReadOnly="True"></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="width: 146px">
                        <asp:Label id="Label6" runat="server" Text="Record Date" font-names="Verdana" font-size="Small"></asp:Label></td>
                    <td style="width: 148px">
                        &nbsp;<asp:TextBox id="txtRecordDate" runat="server" ReadOnly="True"></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="width: 146px">
                        <asp:Label id="Label7" runat="server" Text="Payment Date" font-names="Verdana" font-size="Small"></asp:Label></td>
                    <td style="width: 148px">
                        &nbsp;<asp:TextBox id="txtPayments" runat="server" ReadOnly="True"></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="width: 146px">
                        <asp:Label id="Label8" runat="server" Text="Year Ending" font-names="Verdana" font-size="Small"></asp:Label></td>
                    <td style="width: 148px">
                        &nbsp;<asp:TextBox id="txtYearEnding" runat="server" ReadOnly="True"></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="width: 146px">
                        <asp:Label id="Label9" runat="server" Text="Dividend Rate" font-names="Verdana" font-size="Small"></asp:Label></td>
                    <td style="width: 148px">
                        &nbsp;<asp:TextBox id="txtDivRate" runat="server" ReadOnly="True"></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="width: 146px">
                        <asp:Label id="Label10" runat="server" Text="Bank Account No" font-names="Verdana" font-size="Small"></asp:Label></td>
                    <td style="width: 148px">
                        &nbsp;<asp:TextBox id="txtBankAc" runat="server" ReadOnly="True"></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="width: 146px">
                        <asp:Label id="Label11" runat="server" Text="Dividend Message" font-names="Verdana" font-size="Small"></asp:Label></td>
                    <td style="width: 148px">
                        <asp:TextBox id="txtDivNote" runat="server" TextMode="MultiLine" ReadOnly="True"></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="width: 146px">
                        <asp:Label id="Label12" runat="server" Text="Scrip" font-names="Verdana" font-size="Small"></asp:Label></td>
                    <td style="width: 148px">
                        <asp:CheckBox id="chkScrip" runat="server" font-names="Verdana" font-size="Small"
                            Text="Dividend Scrip" /></td>
                </tr>
                <tr>
                    <td style="width: 146px">
                        <asp:Label id="Label13" runat="server" Text="Scrip Price" font-names="Verdana" font-size="Small"></asp:Label></td>
                    <td style="width: 148px">
                        <asp:TextBox id="TxtScrip" runat="server" ReadOnly="True"></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="width: 146px">
                        <asp:Label id="Label14" runat="server" Text="Scrip Rounding" font-names="Verdana" font-size="Small"></asp:Label></td>
                    <td style="width: 148px">
                        <asp:TextBox id="txtScripRound" runat="server" ReadOnly="True"></asp:TextBox></td>
                </tr>
                
                <tr>
                    <td></td>
                    <td align="center">
                        <asp:Button id="btnSaveDiv" runat="server" Text="Create Dividend" /></td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        </td>
                </tr>
            </table>
            <table>
            <tr>
                    <td colspan ="4" style="width: 850px" align="center">
                        &nbsp;</td>                
                </tr>
                <tr>
                    <td colspan ="4" style="width: 850px" align="center">
                        </td>                
                </tr>
            </table>
        </td>
    </tr>
</table>
</asp:Panel>
</div>
</asp:Content>

