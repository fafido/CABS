<%@ Page Language="VB" MasterPageFile="~/CDSMain.master" AutoEventWireup="false" CodeFile="TradesEnquiries.aspx.vb" Inherits="CDSMode_TradesEnquiries" title="Name Enquiry" %>
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
                        Text="Trades Enquiries" width="853px" ></asp:Label></td>
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
                            GroupName="SearchOptions" Text="Dates" />
                        <asp:RadioButton id="rdDate0" runat="server" autopostback="True" 
                            GroupName="SearchOptions" Text="Transaction Types" />
                        <asp:RadioButton id="rdDate1" runat="server" autopostback="True" 
                            GroupName="SearchOptions" Text="Company" />
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;</td>
                    <td align="left" style="width: 629px">
                        <asp:Label id="Label6" runat="server" font-names="Verdana" font-size="Small" 
                            Text="From" width="44px" Visible="False"></asp:Label>
                        <BDP:BasicDatePicker id="BasicDatePicker1" runat="server" Visible="False" />
                        <asp:Label id="Label7" runat="server" font-names="Verdana" font-size="Small" 
                            Text="To" width="44px" Visible="False"></asp:Label>
                        <BDP:BasicDatePicker id="BasicDatePicker2" runat="server" Visible="False" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label id="Label8" runat="server" font-names="Verdana" font-size="Small" 
                            Text="Transaction Type" width="144px" Visible="False"></asp:Label>
                    </td>
                    <td style="width: 629px">
                        
                        <asp:DropDownList id="cmdTransType" runat="server" autopostback="True" 
                            Height="16px" width="170px" Visible="False">
                        </asp:DropDownList>
                        
                        </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label id="Label2" runat="server" font-names="Verdana" font-size="Small" 
                            Text="Company" width="144px" Visible="False"></asp:Label>
                    </td>
                    <td style="width: 629px">
                        
                        <asp:DropDownList id="cmbCompany" runat="server" width="172px" Visible="False">
                        </asp:DropDownList>
                        <asp:Button id="btnHolderNumSearch" runat="server" Text="&gt;&gt;" 
                            Visible="False" />
                        <asp:TextBox id="txtshareholder" runat="server" Visible="False"></asp:TextBox>
                        
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

