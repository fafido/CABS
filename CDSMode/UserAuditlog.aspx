<%@ Page Language="VB" MasterPageFile="~/CDSMain.master" AutoEventWireup="false" CodeFile="UserAuditlog.aspx.vb" Inherits="UserAuditlog" %>

<%@ Register Assembly="obout_Grid_NET" Namespace="Obout.Grid" TagPrefix="cc1" %>

<%@ Register assembly="BasicFrame.WebControls.BasicDatePicker" namespace="BasicFrame.WebControls" tagprefix="BDP" %>

<asp:Content id="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<script type ="text/javascript">
    
</script>


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
                    <td align="center"><asp:DropDownList runat="server" id="cmbUserId" autopostback="True" 
                            width="158px"></asp:DropDownList></td>
                </tr>
                
                <tr>
                    <td valign="top" align="center">
                        <asp:RadioButton id="rdDateSelect" runat="server" autopostback="True" 
                            groupname="RecordsSelect" text="Date Selection" />
                        <asp:RadioButton id="rdDateSelect0" runat="server" autopostback="True" 
                            groupname="RecordsSelect" text="Action Type" />
                    </td>
                </tr>
                <tr>
                    <td align="center"><asp:DropDownList runat="server" id="cmbAction" 
                            autopostback="True" Visible="False" width="158px">
                        <asp:ListItem>Accounts Creations</asp:ListItem>
                        <asp:ListItem>Accounts Authorizations</asp:ListItem>
                        <asp:ListItem>Batch Receipting</asp:ListItem>
                        <asp:ListItem>Batch Header Authorizations</asp:ListItem>
                        <asp:ListItem>Transaction Batching</asp:ListItem>
                        <asp:ListItem>Transaction Authorization</asp:ListItem>
                        <asp:ListItem>Order Maintenance</asp:ListItem>
                        <asp:ListItem>Order Authorization</asp:ListItem>
                        <asp:ListItem>File Downloads</asp:ListItem>
                        <asp:ListItem>File Uploads</asp:ListItem>
                        <asp:ListItem>Reports Printing</asp:ListItem>
                        </asp:DropDownList></td>
                </tr>
                <tr>
                    <td align="center" ><asp:Label runat="server" Text="from" id="Lblfrom" 
                            Visible="False"></asp:Label>
                        <BDP:BasicDatePicker id="txtDatefrom" runat="server" Visible="False" />
                        <asp:Label id="lblTo" runat="server" Text="To" Visible="False"></asp:Label>
                        <BDP:BasicDatePicker id="txtDateto" runat="server" Visible="False" />
                    </td>
                </tr>
                <tr>
                    <td align ="center"><asp:Button runat="server" Text="View" id="btnView"></asp:Button></td>
                </tr>
                <tr>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td><asp:Label runat="server" id="lblAccAction"></asp:Label></td>
                </tr>
                <tr>
                    <td valign="top">
                        <asp:GridView id="grdAccountsM" runat="server" cellpadding="4" forecolor="#333333" 
                            gridlines="None" width="777px" cssclass="grid">
                            <%--<RowStyle backcolor="#EFF3FB" />
                            <FooterStyle backcolor="#507CD1" font-bold="True" forecolor="White" />
                            <PagerStyle backcolor="#2461BF" forecolor="White" HorizontalAlign="Center" />
                            <SelectedRowStyle backcolor="#D1DDF1" font-bold="True" forecolor="#333333" />
                            <HeaderStyle backcolor="#507CD1" font-bold="True" forecolor="White" />
                            <EditRowStyle backcolor="#2461BF" />
                            <AlternatingRowStyle backcolor="White" />--%>
                        </asp:GridView>
                    </td>
                </tr>
                
                <tr>
                    <td><asp:Label runat="server" id="lblBatchesAction"></asp:Label></td>
                </tr>
                <tr>
                    <td valign="top">
                        <asp:GridView id="grdBatches" runat="server" CellPadding="4" forecolor="#333333" 
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
                <tr>
                    <td><asp:Label runat="server" id="lblTransAction"></asp:Label></td>
                </tr>
                <tr>
                    <td valign="top">
                        <asp:GridView id="grdTransactions" runat="server" CellPadding="4" forecolor="#333333" 
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
                <tr>
                    <td><asp:Label runat="server" id="lblOrdersAction"></asp:Label></td>
                </tr>
                <tr>
                    <td valign="top">
                        <asp:GridView id="grdOrders" runat="server" CellPadding="4" forecolor="#333333" 
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

