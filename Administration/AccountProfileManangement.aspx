<%@ Page Language="VB" MasterPageFile="~/BrokerAdministration.master" AutoEventWireup="false" CodeFile="AccountProfileManangement.aspx.vb" Inherits="Administration_AccountPermisions" title="Account Permissions" %>

<%@ Register Assembly="BasicFrame.WebControls.BasicDatePicker" Namespace="BasicFrame.WebControls"
    TagPrefix="BDP" %>
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
                        Text="System Users Profile" width="848px"></asp:Label></td>
            </tr>
                <tr>
                    <td colspan ="4" valign="top">
                        <asp:Label id="Label1" runat="server" Text="Shareholder Number:" width="144px" font-names="Verdana" font-size="Small" Visible="False"></asp:Label>
                        <asp:Label id="lblShareholder" runat="server" font-names="Verdana" font-size="Small" Visible="False"></asp:Label></td>
                </tr>
                
            </table>
            <table>
                <tr>
                    <td style="width: 143px">
                        </td>
                        <td>
                            </td>
                            <td>
                                </td>
                                <td>
                                    </td>
                                    <td style="width: 141px">
                                        </td>
                </tr>
            </table>
            <table>
            <tr>
                    <td colspan ="1" style="width: 175px">
                        <asp:Label id="Label5" runat="server" Text="UserName" font-names="Verdana" font-size="Small"></asp:Label></td>
                        <td colspan="1" style="width: 203px">
                            <asp:DropDownList id="cmbUser" runat="server" autopostback="True" width="160px">
                            </asp:DropDownList></td>
                            <td colspan ="1" style="width: 172px">
                                </td>
                                <td colspan ="1" style="width: 316px">
                                    </td>
                </tr>
                <tr>
                    <td colspan ="1" style="width: 175px">
                        <asp:Label id="Label2" runat="server" Text="Surname" font-names="Verdana" font-size="Small"></asp:Label></td>
                        <td colspan="1" style="width: 203px">
                            <asp:TextBox id="txtSurname" runat="server"></asp:TextBox></td>
                            <td colspan ="1" style="width: 172px">
                                <asp:Label id="Label3" runat="server" Text="Fornames" font-names="Verdana" font-size="Small"></asp:Label></td>
                                <td colspan ="1" style="width: 316px">
                                    <asp:TextBox id="txtforenames" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="width: 175px">
                        <asp:Label id="Label6" runat="server" Text="id Number" font-names="Verdana" font-size="Small"></asp:Label></td>
                        <td>
                            <asp:TextBox id="txtID" runat="server"></asp:TextBox></td>
                            <td>
                                <asp:Label id="Label20" runat="server" font-names="Verdana" font-size="Small" Text="DOB"></asp:Label></td>
                            <td>
                                <asp:TextBox id="txtDOB" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="width: 175px"></td>
                    <td></td>
                    <td></td>
                    <td></td>
                </tr>
                
                <tr>
                    <td colspan ="1" style="width: 175px">
                        <asp:Label id="Label21" runat="server" Text="Employee id" font-names="Verdana" font-size="Small"></asp:Label></td>
                        <td colspan="1" style="width: 203px">
                            <asp:TextBox id="txtEmpID" runat="server"></asp:TextBox></td>
                            <td colspan ="1" style="width: 172px">
                        <asp:Label id="Label23" runat="server" Text="Company" font-names="Verdana" font-size="Small"></asp:Label></td>
                                <td colspan ="1" style="width: 316px">
                            <asp:TextBox id="txtCompany" runat="server" font-bold="True" font-names="Arial" font-size="Small" ReadOnly="True" width="184px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="width: 175px">
                        </td>
                        <td>
                            </td>
                            <td>
                                <asp:Label id="Label24" runat="server" font-names="Verdana" font-size="Small" Text="Department"></asp:Label></td>
                            <td>
                                <asp:TextBox id="txtDept" runat="server" width="184px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="width: 175px">
                        <asp:Label id="Label25" runat="server" font-names="Verdana" font-size="Small" Text="Job Title"></asp:Label></td>
                    <td>
                        <asp:TextBox id="txtJobTitle" runat="server"></asp:TextBox></td>
                    <td></td>
                    <td></td>
                </tr>
                
                <tr>
                    <td style="width: 175px">
                        <asp:Label id="Label7" runat="server" Text="Address:" font-names="Verdana" font-size="Small"></asp:Label></td>
                        <td>
                            <asp:TextBox id="txtAdd1" runat="server" Height="72px" TextMode="MultiLine"></asp:TextBox></td>
                            <td></td>
                            <td>
                                </td>
                </tr>
                <tr>
                    <td style="width: 175px"></td>
                    <td>
                        </td>
                        <td></td>
                        <td>
                            </td>
                </tr>
                <tr>
                    <td style="width: 175px">
                        &nbsp;</td>
                        <td>
                            </td>
                            <td>
                                </td>
                                <td>
                                    </td>
                </tr>
                <tr>
                    <td style="width: 175px">
                        <asp:Label id="Label10" runat="server" Text="Telephone:" font-names="Verdana" font-size="Small"></asp:Label></td>
                        <td>
                            <asp:TextBox id="txtTel" runat="server"></asp:TextBox></td>
                            <td>
                                <asp:Label id="Label11" runat="server" Text="Cellphone" font-names="Verdana" font-size="Small"></asp:Label></td>
                                <td>
                                    <asp:TextBox id="txtCell" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="width: 175px">
                        <asp:Label id="Label12" runat="server" Text="Email" font-names="Verdana" font-size="Small"></asp:Label></td>
                        <td>
                            <asp:TextBox id="txtEmail" runat="server"></asp:TextBox></td>
                            <td>
                                <asp:Label id="Label13" runat="server" Text="Fax" font-names="Verdana" font-size="Small"></asp:Label></td>
                                <td>
                                    <asp:TextBox id="txtFax" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="width: 175px">
                        </td>
                    <td></td>
                    <td></td>
                    <td></td>
                </tr>
                <tr>
                    <td style="width: 175px">
                        &nbsp;<asp:Label id="Label8" runat="server" font-names="Verdana" font-size="Small"
                            Text="HOD"></asp:Label></td>
                        <td>
                            <asp:TextBox id="txtHod" runat="server"></asp:TextBox></td>
                            <td>
                                &nbsp;</td>
                                <td>
                                    </td>
                </tr>
                <tr>
                    <td style="width: 175px">
                        </td>
                        <td>
                            </td>
                            <td>
                                </td>
                                <td>
                                    </td>
                </tr>
                <tr>
                    <td style="width: 175px"></td>
                    <td></td>
                    <td></td>
                    <td></td>
                </tr>
                <tr>
                    <td style="width: 175px">
                        </td>
                        <td>
                            </td>
                            <td>
                                </td>
                                <td>
                                    </td>
                </tr>
                
            </table>
            <table>
                <tr>
                    <td colspan ="4" style="width: 850px" align="center">
                        <asp:Button id="btnSave" runat="server" Text="Save Account" width="96px" /></td>                
                </tr>
            </table>
        </td>
    </tr>
</table>
</asp:Panel>
</div>
</asp:Content>

