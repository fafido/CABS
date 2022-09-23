<%@ Page Language="VB" MasterPageFile="~/Tsec.master" AutoEventWireup="false" CodeFile="ElectronicReconUpdate.aspx.vb" Inherits="TsecMode_ElectronicReconUpdate" title="CDS Capture" %>
<asp:Content id="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div style="width: 866px">
    <asp:Panel id="Panel1" runat="server" width="873px">
    
<table style="border-right: #000033 thin solid; border-top: #000033 thin solid; border-left: #000033 thin solid; width: 832px; border-bottom: #000033 thin solid; background-color: #ffffff">
    <tr>
        <td style="width: 634px; height: 226px" valign="top">
            <table>
            <tr>
                <td>
                    <asp:Label id="lblsitemap" runat="server"></asp:Label></td>
            </tr>
            <tr>
                <td style="width: 870px" align="center">
                    <asp:Label id="Label4" runat="server" backcolor="#8080FF" font-bold="True" font-names="Arial"
                        Text="Dividend Electronic Reconciliation" width="850px" Height="19px"></asp:Label></td>
            </tr>
           
                
            </table>
            
            <table cellpadding="4" cellspacing="0" style="width: 90%" align=left >
                <tr>
       
                    <td valign="top">
                     <table align=left >
                <tr>
                    <td colspan="2" style="text-align: left">
                        <asp:Label id="lblErrorMessage" runat="server" CssClass="text" forecolor="Red"></asp:Label></td>
                </tr>
                <tr>
                    <td style="width: 106px; text-align: left;" class="textBlack">
                        Company:</td>
                    <td style="text-align: left">
                        <asp:DropDownList id="ddlCompanies" runat="server" width="253px" DataTextField="company" DataValueField="company">
                        </asp:DropDownList></td>
                </tr>
                <tr>
                    <td style="width: 106px; text-align: left;">
                        Full Path of File:
                    </td>
                    <td style="text-align: left">
                        <asp:FileUpload id="FileUpload1" runat="server" width="396px" /></td>
                </tr>
                <tr>
                    <td style="width: 106px; text-align: left">
                    </td>
                    <td style="text-align: left">
                        <asp:Button id="btnProcess" runat="server" Text="Process"
                            width="93px" /></td>
                </tr>
            </table>
                        <br />
                        <br />
                        <br />
                        <br />
                        <br />
                        <br />
        <asp:Panel id="pnlSummaryReport" runat="server" Visible="False" width="100%">
            <table border="0" cellpadding="1" cellspacing="2" style="width: 100%">
                <tr>
                    <td class="h1Blue">
                        Summary Report</td>
                </tr>
                <tr>
                    <td class="text">
                        <table border="0" cellpadding="2" cellspacing="2" style="width: 100%">
                            <tr>
                                <td width="250" class="textBlack">
                                    Total records of Company
                                    <asp:Label id="lblCompany" runat="server" forecolor="Black"></asp:Label>:</td>
                                <td>
                                    <asp:Label id="lblTotalRecords" runat="server" forecolor="Black"></asp:Label></td>
                            </tr>
                            <tr>
                                <td class="textBlack">
                                    Cleared Cheque:</td>
                                <td>
                                    <asp:Label id="lblClearedCheque" runat="server" forecolor="Black"></asp:Label></td>
                            </tr>
                            <tr>
                                <td class="textBlack" style="height: 20px">
                                    Errors:</td>
                                <td style="height: 20px">
                                    <asp:Label id="lblTotalErrors" runat="server" forecolor="Black"></asp:Label></td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </asp:Panel>
                    </td>
                </tr>
                </table>
        </td>
    </tr>
</table>
</asp:Panel>
</div>
</asp:Content>

