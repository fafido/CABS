<%@ Page Language="VB" MasterPageFile="~/CDSUser.master" AutoEventWireup="false" CodeFile="CertificatesTracking.aspx.vb" Inherits="Enquiries_CertificatesTracking" title="Name Enquiry" %>
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
                        Text="Certificates Tracking" width="848px"></asp:Label></td>
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
                        <asp:Label id="Label5" runat="server" font-names="Verdana" font-size="Small" 
                            Text="Company" width="144px"></asp:Label>
                    </td>
                    <td style="width: 219px">
                        <asp:DropDownList id="cmbCompany" runat="server" width="153px">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label id="Label1" runat="server" font-names="Verdana" font-size="Small" 
                            Text="Certificate Number:" width="144px"></asp:Label>
                    </td>
                    <td align="left" style="width: 219px">
                        <asp:TextBox id="txtshareholder" runat="server"></asp:TextBox>
                        <asp:Button id="btnHolderNumSearch" runat="server" Text="&gt;&gt;" />
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td style="width: 219px">
                        
                        </td>
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

