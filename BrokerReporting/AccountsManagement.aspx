<%@ Page Language="VB" MasterPageFile="~/CDSUser.master" AutoEventWireup="false" CodeFile="AccountsManagement.aspx.vb" Inherits="Reporting_AccountsManagement" title="Accounts Management" %>
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
                        Text="Accounts Maintanance Reporting" width="848px"></asp:Label></td>
            </tr>
                <tr>
                    <td colspan ="4" valign="top" style="height: 24px">
                        <asp:Label id="Label1" runat="server" Text="Company" width="144px" font-names="Verdana" font-size="Small" Visible="False"></asp:Label>&nbsp;<asp:DropDownList
                            id="cmbCompany" runat="server" width="192px" autopostback="True" Visible="False">
                        </asp:DropDownList></td>
                </tr>
                
            </table>
            <table>
                <tr>
                    <td style="width: 146px; height: 40px;">
                        <asp:Label id="Label5" runat="server" Text="Classification" font-names="Verdana" font-size="Small"></asp:Label></td>
                        <td style="width: 3px; height: 40px;">
                            <asp:RadioButton id="RdInd" runat="server" font-names="Verdana" font-size="Small"
                                Text="All" width="120px" GroupName="Classifiction" /></td>
                            <td style="width: 3px; height: 40px;">
                                <asp:RadioButton id="rdJoint" runat="server" font-names="Verdana" font-size="Small"
                                    Text="Updated" width="120px" GroupName="Classifiction" /></td>
                                <td style="height: 40px">
                                    <asp:RadioButton id="rdNominee" runat="server" font-names="Verdana" font-size="Small"
                                        Text="New" GroupName="Classifiction" /></td>
                                    <td style="width: 141px; height: 40px;">
                                        <asp:RadioButton id="rdCompany" runat="server" font-names="Verdana" font-size="Small"
                                            GroupName="Classifiction" Text="Suspended" /></td>
                </tr>   
                <tr>
                    <td>
                        <asp:Label id="Label6" runat="server" font-names="Verdana" font-size="Small" 
                            Text="Date From"></asp:Label>
                    </td>
                    <td>
                        <BDP:BasicDatePicker id="BasicDatePicker1" runat="server" ReadOnly="True">
                        </BDP:BasicDatePicker>
                    </td>
                    <td>
                        <asp:Label id="Label7" runat="server" font-names="Verdana" font-size="Small" 
                            Text="Date To"></asp:Label>
                    </td>
                    <td>
                        <BDP:BasicDatePicker id="BasicDatePicker2" runat="server" ReadOnly="True">
                        </BDP:BasicDatePicker>
                    </td>
                    <td></td>
                </tr>        
                <tr>
                    <td>
                        <asp:Label id="Label8" runat="server" font-names="Verdana" font-size="Small" 
                            Text="Sort"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList id="cmb1" runat="server" width="150px">
                            <asp:ListItem Value="1">Shareholder</asp:ListItem>
                            <asp:ListItem Value="2">Forenames</asp:ListItem>
                            <asp:ListItem Value="3">Surname</asp:ListItem>
                            <asp:ListItem Value="4">Date</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td></td>
                    <td>
                        <asp:DropDownList id="cmb2" runat="server">
                            <asp:ListItem Value="1">Asc</asp:ListItem>
                            <asp:ListItem Value="2">Desc</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td></td>
                </tr>             
            </table>
            <table>
                <tr>
                    <td style="width: 146px">
                        </td>
                    <td style="width: 192px" align="center">
                        <asp:Button id="btnSelect" runat="server" Text="Print Report" /></td>
                </tr>
                <tr>
                    <td style="width: 146px">
                        </td>
                    <td style="width: 192px">
                        </td>
                </tr>
                <tr>
                    <td style="width: 146px">
                        </td>
                    <td style="width: 192px">
                        </td>
                </tr>
                <tr>
                    <td></td>
                    <td align="center" style="width: 192px">
                        </td>
                </tr>
                <tr>
                    <td></td>
                    <td style="width: 192px">
                        </td>
                </tr>
            </table>
            <table>
            <tr>
                    <td colspan ="4" style="width: 850px" align="center">
                        &nbsp;</td>                
                </tr>
                <tr>
                    <td colspan ="4" style="width: 850px" align="center">
                        </td>                
                </tr>
            </table>
        </td>
    </tr>
</table>
</asp:Panel>
</div>
</asp:Content>

