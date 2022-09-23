<%@ Page Title="" Language="VB" MasterPageFile="~/CDSUser.master" AutoEventWireup="false" CodeFile="participants.aspx.vb" Inherits="Reporting_participants" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
    <asp:Panel id="Panel1" runat="server" Width="840px" Font-Names="Arial" Font-Size="Medium" BackColor="White">
    
        <table width ="810px">
            <tr>
                   <td style ="text-align :left;" align="left">
                       <dx:ASPxLabel ID="ASPxLabel1" runat="server" Text="Reporting&gt;&gt;Client Holding Statement" Font-Names="Cambria" Font-Size="Small" Theme="PlasticBlue"></dx:ASPxLabel>

                   </td>
            </tr>
        </table>
        <asp:panel id="Panel5" runat="server" GroupingText="Search Options" Font-Names="Cambria">
        <table width="810px">
            <tr>
                <td colspan ="1" style="width: 109px; height: 26px">
                    <dx:ASPxLabel ID="ASPxLabel13" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Search Name" Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                <td colspan ="1" width="301" style="height: 26px">
                    <asp:DropDownList ID="DropDownList1" runat="server" Height="21px" Width="169px">
                        <asp:ListItem>All</asp:ListItem>
                        <asp:ListItem Value="Broker">Brokers</asp:ListItem>
                        <asp:ListItem Value="Tsec">Transfer Secretaries</asp:ListItem>
                        <asp:ListItem Value="Custodian">Custodians</asp:ListItem>
                        <asp:ListItem Value="Regulator">Regulators</asp:ListItem>
                        <asp:ListItem Value="Admin">Administrators</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td colspan ="1" style="height: 26px">
                    </td>
                <td colspan ="1" style="height: 26px">
                    </td>
                <td colspan ="1" style="height: 26px"></td>

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

