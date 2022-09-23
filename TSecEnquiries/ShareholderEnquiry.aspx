<%@ Page Language="VB" MasterPageFile="~/TSec.master" AutoEventWireup="false" CodeFile="ShareholderEnquiry.aspx.vb" Inherits="TSecEnquiries_ShareholderEnquiry" title="Account Details Enquiry" %>
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
                        Text="Shareholder Enquiry" width="848px"></asp:Label></td>
            </tr>
            <tr>
                    <td colspan ="4" valign="top">
                        &nbsp;</td>
                </tr>
                
            </table>
            <table>
                <tr>
                <td >
                    <asp:Label id="Label1" runat="server" Text="Company"  font-bold="True" font-names="Arial" font-size="Small" ></asp:Label></td>
                <td >
                    <asp:DropDownList id="cmbCompany" runat="server" width="206px" TabIndex="1" >
                    </asp:DropDownList></td>
               
            </tr>
            <tr>
                <td >
                    <asp:Label id="Label2" runat="server" Text="Shareholder SurName" font-bold="True" font-names="Arial" font-size="Small" ></asp:Label></td>
                <td >
                    <asp:TextBox id="txtShort" runat="server" width="345px" TabIndex="2" ></asp:TextBox>
                    <asp:Button id="Button1" runat="server" backcolor="#E0E0E0" BorderColor="Black"
                         Text=">>" TabIndex="3" /></td>
               
            </tr>
            <tr>
                <td >
                    <asp:Label id="Label5" runat="server" font-bold="True" font-names="Arial" font-size="Small"
                         Text="Shareholder No" ></asp:Label></td>
                <td >
                    <asp:TextBox id="txtShareholder" runat="server" Style="position: relative" width="345px" TabIndex="4" ></asp:TextBox>
                    <asp:Button id="btnHolder" runat="server" backcolor="#E0E0E0" BorderColor="Black"
                        Text=">>" TabIndex="5" ></asp:Button></td>
            </tr>
            <tr>
                <td valign="top">
                    <asp:Label id="Label3" runat="server" font-bold="True" font-names="Arial" font-size="Small"
                         Text="Name"></asp:Label></td>
                <td >
                <asp:ListBox id="lstName" runat="server" width="350px" TabIndex="6" >
                    </asp:ListBox>
            </tr>
             <tr>
               
                <td  bgcolor="slategray" colspan="2" align="center" style="height: 30px">
                    <asp:Button id="btnSearch" runat="server" backcolor="#E0E0E0" BorderColor="Black"
                         Text="Search" TabIndex="7" />
                         </td>
                 </tr>
            </table>
            <table>
<tr>
        <td >
         <asp:label id="Label6" runat = "server" Text = "Total shares for shareholder  " font-bold="True" forecolor="Red"/>
        <asp:label id="lblShareholder" runat = "server" forecolor="OrangeRed"/>
         <asp:label id="Label7" runat = "server" Text = "are" font-bold="True" forecolor="Red"/>
                <asp:Label id="lblShares" runat = "server" forecolor="OrangeRed"/>
       
        
         
        </td>
        </tr>
        <tr>
        <td>
        <asp:GridView id="grdShareHolderEnquiry" runat="server" CellPadding="4" forecolor="#333333"
            GridLines="None"  AllowPaging="True" TabIndex="8">
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

