<%@ Page Title="" Language="VB" MasterPageFile="~/CDSUser.master" AutoEventWireup="false" CodeFile="RegulatoryTrans.aspx.vb" Inherits="Reporting_RegulatoryTrans" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
    <asp:Panel id="Panel1" runat="server" Width="100%" Font-Names="Arial" Font-Size="Medium" BackColor="White">
    
        <table width ="100%">
            <tr>
                   <td style ="text-align :left;" align="left">
                       <dx:ASPxLabel ID="ASPxLabel1" runat="server" Text="Reporting&gt;&gt;Regulatory Transaction Report" Font-Names="Cambria" Font-Size="Small" Theme="PlasticBlue"></dx:ASPxLabel>

                   </td>
            </tr>
        </table>
        <asp:panel id="Panel5" runat="server" GroupingText="Search Options" Font-Names="Cambria">
        <table width="100%">
            <tr>
                <td colspan="1" style="width: 109px; height: 26px">
                    <dx:ASPxLabel ID="ASPxLabel15" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Date From" Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                <td colspan="1" style="height: 26px" width="301">
                    <dx:ASPxDateEdit ID="dtfrom" runat="server">
                         <ValidationSettings>
                            <RequiredField IsRequired="True" />
                        </ValidationSettings>
                    </dx:ASPxDateEdit>
                </td>
                <td colspan="1" style="height: 26px">&nbsp;</td>
                <td colspan="1" style="height: 26px">&nbsp;</td>
                <td colspan="1" style="height: 26px">&nbsp;</td>
            </tr>
            <tr>
                <td colspan="1" style="width: 109px; height: 26px">
                    <dx:ASPxLabel ID="ASPxLabel14" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Date To" Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                <td colspan="1" style="height: 26px" width="301">
                    <dx:ASPxDateEdit ID="dtto" runat="server">
                         <ValidationSettings>
                            <RequiredField IsRequired="True" />
                        </ValidationSettings>
                    </dx:ASPxDateEdit>
                </td>
                <td colspan="1" style="height: 26px">&nbsp;</td>
                <td colspan="1" style="height: 26px">&nbsp;</td>
                <td colspan="1" style="height: 26px">&nbsp;</td>
            </tr>
            <tr>
                <td colspan="1" style="width: 109px; height: 26px">
                    <dx:ASPxLabel ID="ASPxLabel16" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Top" Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                <td colspan="1" style="height: 26px" width="301">
                    <dx:ASPxTextBox ID="txttop" runat="server" style="margin-top: 0px" Theme="Glass" Width="170px">
                        <ValidationSettings>
                            <RequiredField IsRequired="True" />
                        </ValidationSettings>
                    </dx:ASPxTextBox>
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

