<%@ Page Language="VB" MasterPageFile="~/CDSUser.master" AutoEventWireup="false" CodeFile="OpenSales.aspx.vb" Inherits="Reporting_OpenSales" title="Open Sales Report" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<asp:Content id="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
    <asp:Panel id="Panel1" runat="server" Width="840px" Font-Names="Arial" Font-Size="Medium" BackColor="White">
    
        <table width ="810px">
            <tr>
                   <td style ="text-align :left;" align="left">
                       <dx:ASPxLabel ID="ASPxLabel1" runat="server" Text="Reporting&gt;&gt;Open Sales Report" Font-Names="Cambria" Font-Size="Small" Theme="PlasticBlue"></dx:ASPxLabel>

                   </td>
            </tr>
        </table>
        <asp:panel id="Panel5" runat="server" GroupingText="Search Options" Font-Names="Cambria">
        <table width="810px">
            <tr>
                <td></td>
                <td>
                    <asp:RadioButton ID="rdOpenSale" runat="server" AutoPostBack="True" GroupName="SalesPurchases" Text="Open Sales" />
                    <asp:RadioButton ID="rdPurchasesOpen" runat="server" AutoPostBack="True" GroupName="SalesPurchases" Text="Purchases Sales" />
                </td>
                <td></td>
                <td></td>
                <td></td>
            </tr>
         
            <tr>
                <td colspan ="1">
                    <dx:ASPxLabel ID="ASPxLabel11" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Date From" Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                <td width="301">
                    <dx:ASPxDateEdit ID="txtDateFrom" runat="server" Theme="BlackGlass">
                    </dx:ASPxDateEdit>
                </td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>

            </tr>
            <tr>
                <td colspan ="1">
                    <dx:ASPxLabel ID="ASPxLabel12" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Date To" Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                <td width="301">
                    <dx:ASPxDateEdit ID="txtDateTo" runat="server" Theme="BlackGlass">
                    </dx:ASPxDateEdit>
                </td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>

            </tr>
            <tr>
                <td colspan="1"></td>
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

