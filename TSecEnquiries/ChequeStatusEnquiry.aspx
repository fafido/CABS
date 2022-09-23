<%@ Page Language="VB" MasterPageFile="~/TSec.master" AutoEventWireup="false" CodeFile="ChequeStatusEnquiry.aspx.vb" Inherits="TSecEnquiries_ChequeStatusEnquiry" title="Account Details Enquiry" %>
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
            <td>
                <asp:Label id="Label9" runat="server" font-bold="True" font-names="Arial" font-size="Small"
                    Text="Company"></asp:Label></td>
            <td>
                <asp:DropDownList id="cmbCompany" runat="server" width="205px" autopostback="True">
                </asp:DropDownList></td>
            </tr>
              <tr>
            <td>
                <asp:Label id="Label10" runat="server" font-bold="True" font-names="Arial" font-size="Small"
                    Text="Dividend No"></asp:Label></td>
            <td>
                <asp:DropDownList id="cmbDivno" runat="server" width="205px" autopostback="True">
                </asp:DropDownList></td>
            </tr>
            <tr>
                <td >
                    <asp:Label id="Label3" runat="server"  Text="Cheque No" font-bold="True" font-names="Arial" font-size="Small"></asp:Label></td>
                        <td style="width: 306px">
                         <asp:TextBox id="txtChequeNo" runat="server"  width="200px" TabIndex="2"></asp:TextBox>
                            </td>
            </tr>
           
            <tr>
                <td  bgcolor="slategray" colspan="2" align="center" style="border-top-color: black; height: 30px">
                   
                    <asp:Button id="btnShow" runat="server"  Text="Show" width="90px" backcolor="#E0E0E0" BorderColor="Black" TabIndex="10" />
                   
                    
                    </td>
            </tr>
            </table>
                        <table>
                <tr>
       <td valign ="top">
       <asp:DetailsView id="dtlList" runat="server" CellPadding="4" forecolor="#333333"
               GridLines="None" Height="50px" >
               <FooterStyle backcolor="#5D7B9D" font-bold="True" forecolor="White" />
               <CommandRowStyle backcolor="#E2DED6" font-bold="True" />
               <EditRowStyle backcolor="#999999" />
               <RowStyle backcolor="#F7F6F3" forecolor="#333333" />
               <PagerStyle backcolor="#284775" forecolor="White" HorizontalAlign="Center" />
               <FieldHeaderStyle backcolor="#E9ECF1" font-bold="True" />
               <HeaderStyle backcolor="#5D7B9D" font-bold="True" forecolor="White" />
               <AlternatingRowStyle backcolor="White" forecolor="#284775" />
           </asp:DetailsView>
       </td>
       </tr>
                
            </table>
         
        </td>
    </tr>
</table>
</asp:Panel>
</div>
</asp:Content>

