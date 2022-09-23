<%@ Page Title="" Language="VB" MasterPageFile="~/CDSUser.master" AutoEventWireup="false" CodeFile="AccountsCreated.aspx.vb" Inherits="Reporting_AccountsCreated" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<%@ Register Assembly="BasicFrame.WebControls.BasicDatePicker" Namespace="BasicFrame.WebControls"
    TagPrefix="BDP" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    
    
<%--    <asp:GridView ID="grdApps" runat="server" AllowPaging="True" AutoGenerateColumns="True"--%>
<%--                                HorizontalAlign="Left" CssClass="table table-bordered table-striped tablestyle success"--%>
<%--                                EmptyDataText="0 records found!" EmptyDataRowStyle-CssClass="text-warning text-center">--%>
<%--                                <AlternatingRowStyle CssClass="altrowstyle" />--%>
<%--                                <HeaderStyle CssClass="header info" />--%>
<%--                                <RowStyle CssClass="rowstyle" />--%>
<%--                                <PagerStyle CssClass="pagination-ys" />--%>
<%--                            </asp:GridView>--%>
    

<%--        <form id="form1" runat="server">--%>
<%--        <div>--%>
<%--            <img src="../images/CDS-System_01.png" height="105" alt=""--%>
<%--                style="width: 100%">--%>
<%--        </div>--%>
<%--        <div>--%>
<%--            <table runat="server" class="auto-style1">--%>
<%--                <tr>--%>
<%--                    <td>From</td>--%>
<%--                    <td>--%>
<%--  <BDP:BasicDatePicker ID="ddateFrom" runat="server" ReadOnly="True">--%>
<%--                        </BDP:BasicDatePicker>--%>
<%--                    </td>--%>
<%--                    --%>
<%--                       <td>To</td>--%>
<%--                    <td>--%>
<%--                           <BDP:BasicDatePicker ID="ddateTo" runat="server" ReadOnly="True">--%>
<%--                        </BDP:BasicDatePicker>--%>
<%--                    </td>--%>
<%----%>
<%----%>
<%--                    <td>Enter Client's Investor PIN</td>--%>
<%--                    <td>--%>
<%--                        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>--%>
<%--                    </td>--%>
<%----%>
<%--                    <td>--%>
<%--                        <asp:Button ID="Button1" runat="server" Text="Load" Width="140px" />--%>
<%--                    </td>--%>
<%--                </tr>--%>
<%--            </table>--%>
<%--        </div>--%>

        <div>
            <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true" />
            <%--<CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true" EnableDatabaseLogonPrompt="False" EnableParameterPrompt="False" ReuseParameterValuesOnRefresh="True" />--%>
        </div>
<%--    </form>--%>

</asp:Content>

