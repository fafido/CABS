<%@ Page Language="VB" MasterPageFile="~/CDSMain.master" AutoEventWireup="false" CodeFile="Auditlog.aspx.vb" Inherits="Auditlog" %>

<asp:Content id="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <asp:Panel id="Panel1" runat="server">
    
<table style="border-right: #000033 thin solid; border-top: #000033 thin solid; border-left: #000033 thin solid; width: 832px; border-bottom: #000033 thin solid; background-color: #ffffff">
    <tr>
        <td style="width: 712px; height: 226px" valign="top">
            <table>
            <tr>
                <td style="width: 870px" align="center">
                    <asp:Label id="Label4" runat="server" backcolor="#8080FF" font-bold="True" font-names="Arial"
                        Text="Audit Log" width="848px"></asp:Label></td>
            </tr>
                <tr>
                    <td valign="top">
                        &nbsp;</td>
                </tr>
                
                <tr>
                    <td valign="top">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td valign="top">
                        <asp:GridView id="GridView1" runat="server" CellPadding="4" forecolor="#333333" 
                            GridLines="None" width="777px">
                            <RowStyle backcolor="#EFF3FB" />
                            <FooterStyle backcolor="#507CD1" font-bold="True" forecolor="White" />
                            <PagerStyle backcolor="#2461BF" forecolor="White" HorizontalAlign="Center" />
                            <SelectedRowStyle backcolor="#D1DDF1" font-bold="True" forecolor="#333333" />
                            <HeaderStyle backcolor="#507CD1" font-bold="True" forecolor="White" />
                            <EditRowStyle backcolor="#2461BF" />
                            <AlternatingRowStyle backcolor="White" />
                        </asp:GridView>
                    </td>
                </tr>
                
            </table>
        </td>
    </tr>
</table>
</asp:Panel>

</asp:Content>

