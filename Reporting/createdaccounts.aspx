<%@ Page Title="" Language="VB" MasterPageFile="~/CDSUser.master" AutoEventWireup="false" CodeFile="createdaccounts.aspx.vb" Inherits="Reporting_createdaccounts" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
    <asp:Panel id="Panel1" runat="server" Width="100%" Font-Names="Arial" Font-Size="Medium" BackColor="White">
    
        <table width ="100%">
            <tr>
                   <td style ="text-align :left;" align="left">
                       <dx:ASPxLabel ID="ASPxLabel1" runat="server" Text="Reporting&gt;&gt;Created Accounts" Font-Names="Cambria" Font-Size="Small" Theme="PlasticBlue"></dx:ASPxLabel>

                   </td>
            </tr>
        </table>
        <asp:panel id="Panel5" runat="server" GroupingText="Search Options" Font-Names="Cambria">
        <table width="100%">
            <tr>
                <td>
                    <dx:ASPxLabel ID="ASPxLabel16" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Search By" Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                <td colspan="4" style="height: 26px">
                    <asp:RadioButtonList ID="RadioButtonList1" runat="server" AutoPostBack="True" RepeatDirection="Horizontal">
                        <asp:ListItem>Account Type</asp:ListItem>
                        <asp:ListItem>Asset Manager</asp:ListItem>
                        <asp:ListItem>Category</asp:ListItem>
                        <asp:ListItem>All Accounts</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
                <td colspan ="1" style="height: 26px">&nbsp;</td>

            </tr>
            <tr>
                <td colspan="1" style="width: 109px; height: 26px">
                    <dx:ASPxLabel ID="lbltype" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Type" Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                <td colspan="1" style="height: 26px" width="301">
                    <asp:DropDownList ID="DropDownList1" runat="server" Height="21px" Width="169px">
                    </asp:DropDownList>
                </td>
                <td colspan="1" style="height: 26px"></td>
                <td colspan="1" style="height: 26px"></td>
                <td colspan="1" style="height: 26px"></td>
            </tr>
            <tr>
                <td colspan="1" style="width: 109px; height: 26px">
                    <dx:ASPxLabel ID="ASPxLabel14" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Date from" Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                <td colspan="1" style="height: 26px" width="301">
                    <dx:ASPxDateEdit ID="ASPxDateEdit1" runat="server">
                    </dx:ASPxDateEdit>
                </td>
                <td colspan="1" style="height: 26px">&nbsp;</td>
                <td colspan="1" style="height: 26px">&nbsp;</td>
                <td colspan="1" style="height: 26px">&nbsp;</td>
            </tr>
            <tr>
                <td colspan="1" style="width: 109px; height: 26px">
                    <dx:ASPxLabel ID="ASPxLabel15" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Date to" Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                <td colspan="1" style="height: 26px" width="301">
                    <dx:ASPxDateEdit ID="ASPxDateEdit2" runat="server">
                    </dx:ASPxDateEdit>
                </td>
                <td colspan="1" style="height: 26px">&nbsp;</td>
                <td colspan="1" style="height: 26px">&nbsp;</td>
                <td colspan="1" style="height: 26px">&nbsp;</td>
            </tr>
            <tr>
                <td colspan="1" style="width: 109px"></td>
                <td colspan ="1">
                    <dx:ASPxButton ID="btnPrint" runat="server" Text="Print" Theme="BlackGlass" Width="150px">
                    </dx:ASPxButton>
                </td>
            </tr>

        </table>

    </asp:panel>
         
</asp:Panel>
  
</div>
</asp:Content>

