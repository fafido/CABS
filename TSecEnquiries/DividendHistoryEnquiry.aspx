<%@ Page Language="VB" MasterPageFile="~/TSec.master" AutoEventWireup="false" CodeFile="DividendHistoryEnquiry.aspx.vb" Inherits="TSecEnquiries_DividendHistoryEnquiry" title="Account Details Enquiry" %>
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
                        Text="Dividend History Enquiry" width="848px"></asp:Label></td>
            </tr>
            <tr>
                    <td colspan ="4" valign="top">
                        &nbsp;</td>
                </tr>
                
            </table>
            <table>
            <tr>
                <td style="width: 118px; height: 27px" >
                    <asp:Label id="Label2" runat="server" Text="Company" font-bold="True" Font-Italic="False" font-names="Arial" font-size="Small"></asp:Label></td>
                <td style="height: 27px" >
                    <asp:DropDownList id="cmbCompany" runat="server"  autopostback="True" width="255px" TabIndex="1">
                    </asp:DropDownList></td>
               
            </tr>
            <tr>
                <td style="width: 118px; height: 27px" >
                    <asp:Label id="Label1" runat="server" font-bold="True" font-names="Arial" font-size="Small"
                        Text="Shareholder NO"></asp:Label></td>
                <td style="height: 27px" >
                    <asp:TextBox id="txtShareholder" runat="server" width="250px"></asp:TextBox></td>
              
            </tr>
            <tr>
            <td style="width: 118px; height: 27px">
                &nbsp;</td>
            <td>
                </td>
            </tr>
            <tr>
                <td  colspan="2" align="center" bgcolor="slategray" style="height: 30px" >
                    <asp:Button id="btnPrint" runat="server" Text="PRINT" BorderStyle="Solid" backcolor="#E0E0E0" BorderColor="Black" TabIndex="3" /></td>
              
              
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
         
        </td>
    </tr>
</table>
</asp:Panel>
</div>
</asp:Content>

