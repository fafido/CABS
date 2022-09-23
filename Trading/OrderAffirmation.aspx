<%@ Page Title="" Language="VB" MasterPageFile="~/CDSUser.master" AutoEventWireup="false" CodeFile="OrderAffirmation.aspx.vb" Inherits="Trading_OrderAffirmation" %>

<%@ Register TagPrefix="dx" Namespace="DevExpress.Web.ASPxEditors" Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">


    <%--    <link href="../Content/bootstrap.min.css" rel="stylesheet" />--%>
    <%--    <script src="../Scripts/jquery-1.9.1.min.js"></script>--%>
    <%--    <script src="../Scripts/bootstrap.min.js"></script>--%>
    <%--    <link href="../Content/Pagination.css" rel="stylesheet" />--%>

    <asp:panel id="Panel4" runat="server" groupingtext="Transaction Type" font-names="Cambria">
       <asp:RadioButtonList ID="accType" runat="server" AutoPostBack="True"
                         RepeatDirection="Horizontal" RepeatLayout="Table">
                             <asp:ListItem Text="Buy Side" Value="B"></asp:ListItem>
                             <asp:ListItem Text="Sell Side" Value="S"></asp:ListItem>
                 </asp:RadioButtonList>
  </asp:panel>




    <asp:panel id="Panel8" runat="server" font-names="Cambria" groupingtext="Company Details" visible="True">
        
        <table class="auto-style1">
            <tr>
                <td>
                    <asp:GridView ID="grdApps" runat="server" AllowPaging="True" AutoGenerateColumns="True" CssClass="table table-bordered table-striped tablestyle success" EmptyDataRowStyle-CssClass="text-warning text-center" EmptyDataText="No pending orders!" HorizontalAlign="Center">
                        <AlternatingRowStyle CssClass="altrowstyle" />
                        <HeaderStyle CssClass="header info" />
                        <RowStyle CssClass="rowstyle" />
                        <PagerStyle CssClass="pagination-ys" />
                        <Columns>
                            <%--                        <asp:CommandField ItemStyle-Width="12.5%" SelectText="Confirm" ShowSelectButton="True">--%><%--                               <ItemStyle Width="12.5%" />--%><%--                               </asp:CommandField>--%><%--                                                <asp:CommandField ItemStyle-Width="12.5%" SelectText="Reject" ShowSelectButton="True" >--%><%--                                        <ItemStyle Width="12.5%" />--%><%--                                                </asp:CommandField>--%>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="linkAuthorize" runat="server" CommandArgument="<%# Bind('ID') %>" OnClick="linkAuthorize_Click">Confirm</asp:LinkButton>
                                    |
                                    <asp:LinkButton ID="linkDiscard" runat="server" CommandArgument="<%# Bind('ID') %>" OnClick="linkDiscard_Click">Reject</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <%--                                    <asp:BoundField ItemStyle-Width="12.5%" DataField="Price" HeaderText="Price" >--%><%--                                                <ItemStyle Width="12.5%" />--%><%--                                                </asp:BoundField>--%><%--                                    <asp:BoundField ItemStyle-Width="12.5%" DataField="Quanity" HeaderText="Quantity" >--%><%--                                                <ItemStyle Width="12.5%" />--%><%--                                                </asp:BoundField>--%><%--                                    <asp:BoundField ItemStyle-Width="12.5%" DataField="Buying Investor" HeaderText="Buying Investor" >--%><%--                                                <ItemStyle Width="12.5%" />--%><%--                                                </asp:BoundField>--%>
                            <%--                                    <asp:BoundField ItemStyle-Width="12.5%" DataField="Selling Investor" HeaderText="Selling Investor" >--%><%--                                                <ItemStyle Width="12.5%" />--%><%--                                                </asp:BoundField>--%><%--                                    <asp:BoundField ItemStyle-Width="12.5%" DataField="Buying Broker" HeaderText="Buying Broker" >--%><%--                                                <ItemStyle Width="12.5%" />--%><%--                                                </asp:BoundField>--%><%--                                    <asp:BoundField ItemStyle-Width="12.5%" DataField="Selling Broker" HeaderText="Selling Broker" >--%><%--                                                <ItemStyle Width="12.5%" />--%><%--                                                </asp:BoundField>--%>
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Panel ID="Panel9" runat="server" Visible="False">
                        <table>
                            <tr>
                                <td style="height: 16px">ID </td>
                                <td style="height: 16px; width: 260px;">
                                    <asp:TextBox ID="TextBox2" runat="server" ReadOnly="True" Width="179px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>Reason For Rejection</td>
                                <td style="width: 260px">
                                    <asp:TextBox ID="TextBox1" runat="server" Height="53px" TextMode="MultiLine" Width="254px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>&nbsp;</td>
                                <td style="width: 260px">
                                    <asp:Button ID="Button2" runat="server" BackColor="#1E4D6E" ForeColor="White" Text="Reject" />
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                </td>
            </tr>
        </table>


<%--$1$                         <div style="height: 150px; width: 100%; overflow: auto;">#1#--%>
<%--                            <asp:GridView ID="grdApps" runat="server" AllowPaging="True" AutoGenerateColumns="False"--%>
<%--                                HorizontalAlign="Center" CssClass="table table-bordered table-striped tablestyle success"--%>
<%--                                EmptyDataText="Customer number not found!" EmptyDataRowStyle-CssClass="text-warning text-center" ShowHeaderWhenEmpty="True">--%>
<%--                                <AlternatingRowStyle CssClass="altrowstyle" />--%>
<%--                                <HeaderStyle CssClass="header info" />--%>
<%--                                <RowStyle CssClass="rowstyle" />--%>
<%--                                <PagerStyle CssClass="pagination-ys" />--%>
<%--                                <Columns>--%>
<%--                                    <asp:CommandField ItemStyle-Width="12.5%" SelectText="Confirm" ShowSelectButton="True" />--%>
<%----%>
<%--                                    $1$                                    <asp:TemplateField ShowHeader="False">#1#--%>
<%--                                    $1$                                        <ItemTemplate>#1#--%>
<%--                                    $1$                                            <asp:Button ID="Button1" runat="server" CausesValidation="false" CommandName="SendMail"#1#--%>
<%--                                    $1$                                                Text="SendMail" CommandArgument='<%# Eval("Time") %>' />#1#--%>
<%--                                    $1$                                        </ItemTemplate>#1#--%>
<%--                                    $1$                                    </asp:TemplateField>#1#--%>
<%----%>
<%----%>
<%--                                    <asp:BoundField ItemStyle-Width="12.5%" DataField="Time" />--%>
<%--                                    <asp:BoundField ItemStyle-Width="12.5%" DataField="Price" />--%>
<%--                                    <asp:BoundField ItemStyle-Width="12.5%" DataField="Quanity" />--%>
<%--                                    <asp:BoundField ItemStyle-Width="12.5%" DataField="Buying Investor" />--%>
<%--                                    <asp:BoundField ItemStyle-Width="12.5%" DataField="Selling Investor" />--%>
<%--                                    <asp:BoundField ItemStyle-Width="12.5%" DataField="Buying Broker" />--%>
<%--                                    <asp:BoundField ItemStyle-Width="12.5%" DataField="Selling Broker" />--%>
<%--                                </Columns>--%>
<%--                            </asp:GridView>--%>
                    
        

        </asp:panel>
</asp:Content>
