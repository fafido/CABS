<%@ Page Language="VB" MasterPageFile="~/CDSUser.master" AutoEventWireup="false" CodeFile="AccountUpdateAuthorize.aspx.vb" Inherits="BrokerMode_AccountUpdateAuthorize" title="Accounts Update" %>

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
                        Text="Accounts Update Authorization" width="848px"></asp:Label></td>
            </tr>
                <tr>
                    <td colspan ="4" valign="top">
                        <asp:Label id="Label1" runat="server" Text="Date From" width="144px" font-names="Verdana" font-size="Small"></asp:Label>&nbsp;
                        <BDP:BasicDatePicker id="BasicDatePicker1" runat="server">
                        </BDP:BasicDatePicker>
                    </td>
                </tr>
                
            </table>
            <table>
                <tr>
                    <td style="width: 145px">
                        <asp:Label id="Label5" runat="server" Text="Date To" font-names="Verdana" font-size="Small"></asp:Label></td>
                        <td style="width: 3px">
                            <BDP:BasicDatePicker id="BasicDatePicker2" runat="server">
                            </BDP:BasicDatePicker>
                        </td>
                            <td style="width: 3px">
                                </td>
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
                        <asp:Button id="btnSearch" runat="server" Text="Search" /></td>
                </tr>
                <tr>
                    <td></td>
                    <td align="center">
                        </td>
                </tr>
            </table>
            <table>
             <tr>
                <td><asp:GridView id="gvTransactions" runat="server" AutoGenerateColumns="False">
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton id="linkAuthorize" runat="server" CommandArgument="<%# Bind('FKey') %>"
                                        OnClick="linkAuthorize_Click">Authorize</asp:LinkButton>
                                    |
                                    <asp:LinkButton id="linkDiscard" runat="server" CommandArgument="<%# Bind('FKey') %>"
                                        OnClick="linkDiscard_Click">Discard</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="CDS_Number" HeaderText="CDS Number" />
                            <asp:BoundField DataField="New Name" HeaderText="New Surname" />
                            <asp:BoundField DataField="New Forenames" HeaderText="New Forenames" />
                            <asp:BoundField DataField="New Add" HeaderText="New Address" />
                            <asp:BoundField DataField="Old Names" HeaderText="Old Address" />
                            <asp:BoundField DataField="Old Add" HeaderText="Old Add" />
                        </Columns>
                    </asp:GridView></td>
             </tr>
            </table>
            <table>
                <tr>
                    <td colspan ="4" style="width: 850px" align="center">
                        <asp:Button id="btnSave" runat="server" Text="Update" width="96px" /></td>                
                </tr>
            </table>
        </td>
    </tr>
</table>
</asp:Panel>
</div>
</asp:Content>

