<%@ Page Language="VB" MasterPageFile="~/CDSUser.master" AutoEventWireup="false" CodeFile="AccountsUploadFile.aspx.vb" Inherits="Trading_AccountsUploadFile" title="Trades File Generation" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
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
                        Text="CDS Accounts Electronic File" width="848px"></asp:Label></td>
            </tr>
                <tr>
                    <td valign="top">
                        &nbsp;</td>
                </tr>
                
            </table>
            <table>
            <tr>
                    <td style="width: 146px">
                        &nbsp;</td>
                        <td style="width: 117px">
                            &nbsp;</td>
                            <td style="width: 3px">
                                </td>
                                <td>
                                    </td>
                                    <td style="width: 141px">
                                        </td>
                </tr>                
                <tr>
                    <td style="width: 146px">
                        <asp:Label id="Label5" runat="server" font-names="Verdana" font-size="Small" 
                            Text="File"></asp:Label>
                    </td>
                        <td style="width: 117px">
                            <input id="fDocument" runat="server" onclick="return fDocument_onclick()" 
                                style="width: 266px; height: 26px;" type="file" validationgroup="*.jpg" /></td>
                            <td style="width: 3px">
                                </td>
                                <td>
                                    </td>
                                    <td style="width: 141px">
                                        </td>
                </tr>    
                <tr>
                    <td>
                        <asp:Label id="Label7" runat="server" font-names="Verdana" font-size="Small" 
                            Text="Upload Date (Default today)"></asp:Label>
                    </td>
                    <td>
                        <BDP:BasicDatePicker id="BasicDatePicker1" runat="server" />
                    </td>
                    <td></td>
                    <td></td>
                </tr>            
                <tr>
                    <td style="width: 146px; height: 21px;">
                        &nbsp;</td>
                        <td style="width: 117px; height: 21px;">
                            <asp:Button id="btnSelect" runat="server" Text="Upload File" />
                    </td>
                            <td style="width: 3px; height: 21px;">
                                </td>
                                <td style="height: 21px">
                                    </td>
                                    <td style="width: 141px; height: 21px;">
                                        </td>
                </tr>                
            </table>
            <table>
                <tr>
                    <td style="width: 146px">
                        <asp:Label id="Label6" runat="server" font-names="Verdana" font-size="Small" 
                            Text="Upload id"></asp:Label>
                        </td>
                    <td style="width: 192px">
                        <asp:Label id="lblUploadID" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="width: 146px">
                        </td>
                    <td style="width: 192px">
                        </td>
                </tr>
                <tr>
                    <td style="width: 146px">
                        </td>
                    <td style="width: 192px">
                        </td>
                </tr>
                <tr>
                    <td></td>
                    <td align="center" style="width: 192px">
                        </td>
                </tr>
                <tr>
                    <td></td>
                    <td style="width: 192px">
                        </td>
                </tr>
            </table>
            <table>
            <tr>
                    <td style="width: 850px" align="center">
                        &nbsp;</td>                
                </tr>
                <tr>
                    <td style="width: 850px" align="center">
                        </td>                
                </tr>
            </table>
        </td>
    </tr>
</table>
</asp:Panel>
</div>
</asp:Content>

