<%@ Page Language="VB" MasterPageFile="~/CDSUser.master" AutoEventWireup="false" CodeFile="exposure.aspx.vb" Inherits="Reporting_exposure" title="Exposure" %>
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
                        Text="Exposure Report" width="848px"></asp:Label></td>
            </tr>
                <tr>
                    <td colspan ="4" valign="top" style="height: 24px">
                        &nbsp;</td>
                </tr>
                
            </table>
            <table>
                <tr>
                    <td>
                        <asp:Label ID="Label1" runat="server" font-names="Verdana" font-size="Small" 
                            Text="Company" width="144px"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="cmbCompany" runat="server" autopostback="True" 
                            width="192px">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label6" runat="server" font-names="Verdana" font-size="Small" 
                            Text="Date" width="144px"></asp:Label>
                    </td>
                    <td>
                        <BDP:BasicDatePicker ID="txtTargetDate" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>
                        <asp:CheckBox ID="CheckBox1" runat="server" text="Show With Zeros" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label7" runat="server" font-names="Verdana" font-size="Small" 
                            Text="Top" width="144px" Visible="False"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtTop" runat="server" Width="190px" Visible="False">1000</asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan ="1">
                        &nbsp;</td>
                    <td colspan ="1" style="text-align:center; height: 26px;">
                        <asp:RadioButton ID="rdAll" runat="server" font-names="Verdana" 
                            font-size="Small" GroupName="Classifiction" Text="All" Checked="True" 
                            Visible="False" />
                        <asp:Button ID="btnSelect" runat="server" Text="Print Report" />
                    </td>
                </tr>
                <tr>
                  <td colspan ="2" style ="text-align:center;">
                      &nbsp;</td>
                    
                </tr>
            </table>
            <table>
                <tr>
                    <td style="width: 146px; height: 40px;">
                        &nbsp;</td>
                        <td style="width: 3px; height: 40px;">
                            &nbsp;</td>
                            <td style="width: 3px; height: 40px;">
                                &nbsp;</td>
                                <td style="height: 40px">
                                    &nbsp;</td>
                                    <td style="width: 90px; height: 40px;">
                                        &nbsp;</td>
                                            <td style="width: 141px; height: 40px;">
                                                &nbsp;</td>
                </tr>                
            </table>
            <table>
                <tr>
                    <td style="width: 146px">
                        </td>
                    <td style="width: 192px" align="center">
                        &nbsp;</td>
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

