<%@ Page Language="VB" MasterPageFile="~/CDSUser.master" AutoEventWireup="false" CodeFile="ATSDataImportReport.aspx.vb" Inherits="CDSMode_ATSDataImportReport" title="ATSDataImportReport" %>
<%@ Register namespace="BasicFrame.WebControls" tagprefix="WebControls" %>
<%@ Register assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>
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
                        Text="ATS TRADES DATA UPLOAD SUMMARY" width="853px"></asp:Label></td>
            </tr>
                <tr>
                    <td colspan ="4" valign="top">
                        &nbsp;</td>
                </tr>
                
            </table>
            <table>
   
            </table>
            <table>
            <tr>
                    <td style="width: 146px">
                        &nbsp;</td>
                    <td style="width: 219px">
                        &nbsp;</td>
                    
                    
                    <td style="width: 146px">
                        &nbsp;</td>
                    <td style="width: 219px">
                        &nbsp;</td>
                    
                </tr>
                <tr>
                    <td style="width: 146px">
                        &nbsp;</td>
                    <td style="width: 219px">
                        &nbsp;</td>
                    
                    
                    <td style="width: 146px">
                        &nbsp;</td>
                    <td style="width: 219px">
                        &nbsp;</td>
                    
                </tr>
                <tr>

                        <td>
                            <asp:Label ID="Label5" runat="server" Text="Summary Date Range"></asp:Label>
                        </td>
                    <td>
                        <asp:Label ID="Label6" runat="server" Text="From"></asp:Label>
                        <BDP:BasicDatePicker ID="txtDateFrom" runat="server" ReadOnly="True" width="180px"></BDP:BasicDatePicker>
                        </td>
                    <td>
                        &nbsp;</td>
                    <td>
                        <asp:Label ID="Label7" runat="server" Text="To"></asp:Label>
                        <BDP:BasicDatePicker ID="txtDateTo" runat="server" ReadOnly="True" width="180px"></BDP:BasicDatePicker>
                        </td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        &nbsp;</td>
                    <td>
                        <asp:Button ID="Button1" runat="server" Text="Print" />
                    </td>
                    <td></td>
                </tr>
                <tr>
                        <td>
                            &nbsp;</td>
                    <td>
                        &nbsp;</td>
                    <td></td>
                    <td></td>

                </tr>
                <tr>
                    <td style="height: 18px"></td>
                    <td style="height: 18px">
                        &nbsp;</td>
                    <td style="height: 18px"></td>
                    <td style="height: 18px"></td>
                </tr>
                <tr>
                    <td>
                        &nbsp;</td>
                    <td align="center" style="width: 219px">
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                    <td align="center" style="width: 219px">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td></td>
                    <td style="width: 219px">
                        
                        &nbsp;</td>
                </tr>
                <tr>
                    <td></td>
                    <td colspan ="2">
                        &nbsp;</td>
                </tr>
            </table>
            
            <table>
                <tr>
                    <td colspan ="4" style="width: 850px" align="center">
                        &nbsp;</td>                
                </tr>
            </table>
        </td>
    </tr>
</table>
</asp:Panel>
</div>
</asp:Content>

