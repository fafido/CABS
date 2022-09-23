<%@ Page Title="" Language="VB" MasterPageFile="~/CDSUser.master" AutoEventWireup="false" CodeFile="RegulatoryPort.aspx.vb" Inherits="Reporting_RegulatoryPort" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
    <asp:Panel id="Panel1" runat="server" Width="100%" Font-Names="Arial" Font-Size="Medium" BackColor="White">
    
        <table width ="100%">
            <tr>
                   <td style ="text-align :left;" align="left">
                       <dx:ASPxLabel ID="ASPxLabel1" runat="server" Text="Reporting&gt;&gt;Regulatory Report(Portfolio)" Font-Names="Cambria" Font-Size="Small" Theme="PlasticBlue"></dx:ASPxLabel>

                   </td>
            </tr>
        </table>
        <asp:panel id="Panel5" runat="server" GroupingText="Search Options" Font-Names="Cambria">
        <table width="100%">
            <tr>
                <td colspan="1" style="width: 109px; height: 26px">
                    <dx:ASPxLabel ID="ASPxLabel15" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Top" Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                <td colspan="1" style="height: 26px" width="301">
                    <dx:ASPxTextBox ID="txtAccountNo" runat="server" Height="19px" Theme="BlackGlass" Width="170px">
                    </dx:ASPxTextBox>
                </td>
                <td colspan="1" style="height: 26px">&nbsp;</td>
                <td colspan="1" style="height: 26px">&nbsp;</td>
                <td colspan="1" style="height: 26px">&nbsp;</td>
            </tr>
            <tr>
                <td colspan="1" style="width: 109px; height: 26px">
                    <dx:ASPxLabel ID="ASPxLabel14" runat="server" Font-Names="Cambria" Font-Size="Small" Text="As at" Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                <td colspan="1" style="height: 26px" width="301">
                    <dx:ASPxDateEdit ID="ASPxDateEdit1" runat="server" AutoPostBack="True">
                    </dx:ASPxDateEdit>
                </td>
                <td colspan="1" style="height: 26px">&nbsp;</td>
                <td colspan="1" style="height: 26px">&nbsp;</td>
                <td colspan="1" style="height: 26px">&nbsp;</td>
            </tr>
            <tr>
                <td colspan="1" style="width: 109px"></td>
                <td colspan ="2">
                    <dx:ASPxButton ID="btnPrint0" runat="server" Text="Generate Portfolios" Theme="BlackGlass" Width="150px">
                    </dx:ASPxButton>
                    &nbsp;
                    <dx:ASPxButton ID="btnPrint" runat="server" Text="Print" Theme="BlackGlass" Width="150px">
                    </dx:ASPxButton>
                </td>
            </tr>

        </table>

    </asp:panel>
         
</asp:Panel>
  
</div>
</asp:Content>

