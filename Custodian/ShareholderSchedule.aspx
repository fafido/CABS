<%@ Page Language="VB" MasterPageFile="~/CDSUser.master" AutoEventWireup="false" CodeFile="ShareholderSchedule.aspx.vb" Inherits="Custodian_ShareholderSchedule" title="Account Details Enquiry" %>
<asp:Content id="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
    <asp:Panel id="Panel1" runat="server">
    
<table style="border-right: #000033 thin solid; border-top: #000033 thin solid; border-left: #000033 thin solid; width: 832px; border-bottom: #000033 thin solid; background-color: #ffffff">
    <tr>
        <td style="width: 712px; height: 226px" valign="top">
            <table>
            <tr>
                <td>
                    <asp:Label id="lblsitemap" runat="server"></asp:Label></td>
            </tr>
            <tr>
                <td style="width: 870px" align="center">
                    <asp:Label id="Label4" runat="server" backcolor="#8080FF" font-bold="True" font-names="Arial"
                        Text="Shareholders Holding Schedule" width="849px"></asp:Label></td>
            </tr>
            <tr>
                    <td colspan ="4" valign="top">
                        <asp:RadioButton id="RadioButton1" runat="server" autopostback="True" 
                            font-names="Arial" font-size="Small" GroupName="ShareholdersSched" 
                            Text="All shareholders" />
                        <asp:RadioButton id="RadioButton2" runat="server" autopostback="True" 
                            font-names="Arial" font-size="Small" GroupName="ShareholdersSched" 
                            Text="Shareholders By Company" />
                    </td>
                </tr>
                
            </table>
            <table>
                <tr>
                    <td style="width: 140px">
                        <asp:Label id="Label5" runat="server" Text="Company" font-names="Verdana" 
                            font-size="Small"></asp:Label></td>
                        <td style="width: 3px">
                            <asp:DropDownList id="DropDownList1" runat="server" autopostback="True" 
                                width="178px">
                            </asp:DropDownList>
                    </td>
                            <td style="width: 3px">
                                &nbsp;</td>
                                <td>
                                    </td>
                                    <td style="width: 141px">
                                        </td>
                </tr>                
            </table>
            <table>
                <tr>
                    <td style="width: 146px"></td>
                    <td style="width: 148px">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td></td>
                    <td align="center">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td></td>
                    <td align ="center">
                    <asp:Button id="btnPrintStatement" runat="server" Text="Print "></asp:Button></td>
                </tr>
            </table>
            <table>
                <tr>
                    <td colspan ="1" style="width: 147px">
                        </td>
                        <td colspan="1" style="width: 203px">
                            </td>
                            <td colspan ="1" style="width: 172px">
                                </td>
                                <td colspan ="1" style="width: 316px">
                                    </td>
                </tr>
                
            </table>
            <table>
            <tr>
                <td colspan ="4" style=" width : 850px" align ="center">
                    &nbsp;</td>
            </tr>
                <tr>
                    <td colspan ="4" style="width: 850px" align="center">
                        <asp:GridView id="gdPortfolioResults" runat="server" width="584px">
                        </asp:GridView>
                        </td>                
                </tr>
            </table>
        </td>
    </tr>
</table>
</asp:Panel>
</div>
</asp:Content>

