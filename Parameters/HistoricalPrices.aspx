<%@ Page Language="VB" MasterPageFile="~/CDSUser.master" AutoEventWireup="false" CodeFile="HistoricalPrices.aspx.vb" Inherits="Parameters_BrokerFees" title="Brokerage Fee Maitenance" %>
<%@ Register assembly="BasicFrame.WebControls.BasicDatePicker" namespace="BasicFrame.WebControls" tagprefix="BDP" %>
<%@ Register assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxGridView" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dx" %>
<asp:Content id="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div>
    <asp:Panel id="Panel1" runat="server">
    
<table style="border-right: #000033 thin solid; border-top: #000033 thin solid; border-left: #000033 thin solid; width: 832px; border-bottom: #000033 thin solid; background-color: #ffffff">
    <tr align="center">
        <td style="width: 712px; height: 226px" valign="top">
            <table>
            <tr>
                <td style="width: 870px" align="center">
                    <asp:Label id="Label4" runat="server" backcolor="#8080FF" font-bold="True" font-names="Arial"
                        Text="Share Prices" width="848px"></asp:Label></td>
            </tr>                
            </table>
            <table>
                <tr>
                    <td align="left" style="width: 156px; height: 26px;">
                        <asp:Label id="Label1" runat="server" Text="Company" font-names="Arial" font-size="Small"></asp:Label></td>
                        <td align="left" style="height: 26px">
                            <asp:DropDownList id="cmbParaCompany" autopostback="true"  runat="server" width="179px">
                            </asp:DropDownList></td>
                </tr>    
               
                 <tr>
                    <td align="left" style="width: 156px">
                        <asp:Label id="Label8" runat="server" Text="Date From" font-names="Arial" 
                            font-size="Small"></asp:Label></td>
                        <td style="text-align: left">
                            <BDP:BasicDatePicker ID="txtdatefrom" runat="server" ReadOnly="True" width="180px">
                            </BDP:BasicDatePicker>
                    </td>
                </tr>
                <tr>
                    <td align="left" style="width: 156px">
                        <asp:Label id="Label3" runat="server" Text="Date To" font-names="Arial" 
                            font-size="Small"></asp:Label></td>
                        <td style="text-align: left">
                            <BDP:BasicDatePicker ID="txtdate" runat="server" ReadOnly="True" width="180px">
                            </BDP:BasicDatePicker>
                    </td>
                </tr>
                
                
                <tr>
                    <td align="left" style="width: 156px">&nbsp;</td>
                    <td style="text-align: left">
                        <asp:Button ID="btnPrintStatement" runat="server" style="height: 26px" Text="View" width="64px" />
                    </td>
                </tr>
            </table>
            
            <br />
            <dx:ASPxGridView ID="ASPxGridView1" runat="server" Theme="BlackGlass" Width="556px">
            </dx:ASPxGridView>
            
           </td>
    </tr>
</table>

</asp:Panel>
</div>
</asp:Content>

