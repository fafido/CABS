<%@ Page Language="VB" MasterPageFile="~/CDSMain.master" AutoEventWireup="false" CodeFile="DividendEnquiries.aspx.vb" Inherits="CDSMode_DividendEnquiries" title="Name Enquiry" %>
<%@ Register assembly="BasicFrame.WebControls.BasicDatePicker" namespace="BasicFrame.WebControls" tagprefix="BDP" %>
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
                        Text="Dividend Enquiries" width="851px"></asp:Label></td>
            </tr>
                <tr>
                    <td colspan ="4" valign="top">
                        &nbsp;</td>
                </tr>
                
            </table>
            <table>
   
            </table>
            <table>
                <tr>
                    <td style="width: 146px">
                        <asp:Label id="Label5" runat="server" font-names="Verdana" font-size="Small" 
                            Text="Search Options" width="144px"></asp:Label>
                    </td>
                    <td style="width: 629px">
                        <asp:RadioButton id="rdDate" runat="server" autopostback="True" 
                            GroupName="SearchOptions" Text="Dividend Instructions" />
                        <asp:RadioButton id="rdDate0" runat="server" autopostback="True" 
                            GroupName="SearchOptions" Text="Dividend Schedules" />
                        <asp:RadioButton id="rdDate1" runat="server" autopostback="True" 
                            GroupName="SearchOptions" Text="Accounts" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label id="Label1" runat="server" font-names="Verdana" font-size="Small" 
                            Text="Company" width="144px"></asp:Label>
                    </td>
                    <td align="left" style="width: 629px">
                        <asp:DropDownList id="cmbCompany" runat="server" width="172px">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label id="Label8" runat="server" font-names="Verdana" font-size="Small" 
                            Text="Dividend Number" width="144px"></asp:Label>
                    </td>
                    <td style="width: 629px">
                        
                        <asp:DropDownList id="DropDownList1" runat="server" autopostback="True" 
                            Height="16px" width="170px">
                        </asp:DropDownList>
                        
                        </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;</td>
                    <td style="width: 629px">
                        
                        <asp:Button id="Button1" runat="server" Text="Print" />
                        
                        </td>
                </tr>
            </table>
            
            <table>
                <tr>
                    <td colspan ="4" style="width: 850px" align="center">
                        &nbsp;</td>                
                </tr>
            </table>
        </td>
    </tr>
</table>
</asp:Panel>
</div>
</asp:Content>

