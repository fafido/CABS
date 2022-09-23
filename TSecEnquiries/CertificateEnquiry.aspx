<%@ Page Language="VB" MasterPageFile="~/TSec.master" AutoEventWireup="false" CodeFile="CertificateEnquiry.aspx.vb" Inherits="TSecEnquiries_CertificateEnquiry" title="Account Details Enquiry" %>
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
                        Text="Certificate Enquiry" width="848px"></asp:Label></td>
            </tr>
            <tr>
                    <td colspan ="4" valign="top">
                        &nbsp;</td>
                </tr>
                
            </table>
            <table>
            <tr>
                <td style="height: 24px">
                    <asp:Label id="Label2" runat="server" Text="Company" font-bold="True" font-names="Arial" font-size="Small"></asp:Label></td>
                <td style="height: 24px" >
                    <asp:DropDownList id="cmbCompany" runat="server"  font-size="Smaller" width="205px" autopostback="True" TabIndex="1" >
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td>
                    <asp:Label id="Label1" runat="server" Text="Certificate"  font-bold="True" font-names="Arial" font-size="Small"></asp:Label></td>
                <td >
                    <asp:TextBox id="txtCert" runat="server" width="200px" TabIndex="2" 
                        ></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="center" colspan="2"  bgcolor="slategray" style="height: 30px">
                    <asp:Button id="btnSerch" runat="server" backcolor="#E0E0E0" BorderColor="Black"
                        Text="Search" TabIndex="3" />
                    </td>
            </tr>
            </table>
            <table>
                <tr>
        <td style="width: 286px">
         <asp:GridView id="grdCertiEnqu" runat="server" CellPadding="4" forecolor="#333333"
            GridLines="None" AllowPaging="True" TabIndex="4">
            <FooterStyle backcolor="#507CD1" font-bold="True" forecolor="White" />
            <RowStyle backcolor="#EFF3FB" />
            <EditRowStyle backcolor="#2461BF" />
            <SelectedRowStyle backcolor="#D1DDF1" font-bold="True" forecolor="#333333" />
            <PagerStyle backcolor="#2461BF" forecolor="White" HorizontalAlign="Center" />
            <HeaderStyle backcolor="#507CD1" font-bold="True" forecolor="White" />
            <AlternatingRowStyle backcolor="White" />
            <PagerSettings FirstPageText="First" LastPageText="Last"
                NextPageText="Next" Position="TopAndBottom" PreviousPageText="Previous" Mode="NextPreviousFirstLast" />
        </asp:GridView>
        </td>
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

