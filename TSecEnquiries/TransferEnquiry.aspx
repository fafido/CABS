<%@ Page Language="VB" MasterPageFile="~/TSec.master" AutoEventWireup="false" CodeFile="TransferEnquiry.aspx.vb" Inherits="TSecEnquiries_TransferEnquiry" title="Account Details Enquiry" %>
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
                <td style="width: 94px">
                    <asp:Label id="Label2" runat="server" Text="Company" font-bold="True" font-names="Arial" font-size="Small" ></asp:Label></td>
                <td>
                    <asp:DropDownList id="cmbCompany" runat="server"  autopostback="True" width="205px" TabIndex="1">
                        <asp:ListItem Value="---select----"></asp:ListItem>
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td style="width: 94px" >
                    <asp:Label id="Label1" runat="server" Text="Transfer No"  font-bold="True" font-names="Arial" font-size="Small" width="80px" ></asp:Label></td>
                <td >
                    <asp:DropDownList id="cmbTransferno" runat="server" width="205px" TabIndex="2" >
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td align="center" colspan="2"  bgcolor="slategray" style="height: 29px" >
                    <asp:Button id="b_search" runat="server" 
                        Text="Search" backcolor="#E0E0E0" BorderColor="Black" TabIndex="3" /></td>
            </tr>
            </table>
            <table>
               <tr>
       <td style="width: 211px; height: 195px">
        <asp:GridView  id="grdEnqTran" runat="server" AllowPaging="True" CellPadding="4" forecolor="#333333"
            GridLines="None"  Height="1px" PageSize="3" TabIndex="4">
            <PagerSettings FirstPageText="First" NextPageText="Next"
                Position="TopAndBottom" PreviousPageText="Previous" LastPageText="Last" Mode="NextPreviousFirstLast" />
            <FooterStyle backcolor="#507CD1" font-bold="True" forecolor="White" />
            <RowStyle backcolor="#EFF3FB" />
            <EditRowStyle backcolor="#2461BF" />
            <SelectedRowStyle backcolor="#D1DDF1" font-bold="True" forecolor="#333333" />
            <PagerStyle backcolor="#2461BF" forecolor="White" HorizontalAlign="Center" />
            <HeaderStyle backcolor="#507CD1" font-bold="True" forecolor="White" />
            <AlternatingRowStyle backcolor="White" />
        </asp:GridView>
      
       </td>
       </tr>
      <tr>
       <td style="width: 211px">
        <asp:Label id="Label6" runat="server" Text="Transfer To" forecolor="Tomato"></asp:Label><tr>
       </td>
       </tr>
       <tr>
       <td style="width: 211px">
       <asp:GridView  id="grdbatchto" runat="server" AllowPaging="True" CellPadding="4" forecolor="#333333"
            PageSize="3" TabIndex="5">
            <PagerSettings FirstPageText="First" NextPageText="Next"
                Position="TopAndBottom" PreviousPageText="Previous" LastPageText="Last" Mode="NextPreviousFirstLast" />
            <FooterStyle backcolor="#507CD1" font-bold="True" forecolor="White" />
            <RowStyle backcolor="#EFF3FB" />
            <EditRowStyle backcolor="#2461BF" />
            <SelectedRowStyle backcolor="#D1DDF1" font-bold="True" forecolor="#333333" />
            <PagerStyle backcolor="#2461BF" forecolor="White" HorizontalAlign="Center" />
            <HeaderStyle backcolor="#507CD1" font-bold="True" forecolor="White" />
            <AlternatingRowStyle backcolor="White" />
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
         
        </td>
    </tr>
</table>
</asp:Panel>
</div>
</asp:Content>

