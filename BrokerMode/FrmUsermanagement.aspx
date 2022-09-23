<%@ Page Language="VB" MasterPageFile="~/CDSUser.master" AutoEventWireup="false" CodeFile="FrmUsermanagement.aspx.vb" Inherits="BrokerMode_FrmUsermanagement" title="Untitled Page" %>

<asp:Content id="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="border-right: #000033 thin solid; border-top: #000033 thin solid; border-left: #000033 thin solid; width: 832px; border-bottom: #000033 thin solid; background-color: #ffffff" 
            __designer:mapid="21f">
        <tr align="left" __designer:mapid="220">
            <td style="width: 712px; height: 226px" valign="top" __designer:mapid="221">
                <table __designer:mapid="222">
                    <tr __designer:mapid="223">
                        <td style="width: 870px" align="center" __designer:mapid="224">
                            <asp:Label id="Label4" runat="server" backcolor="#8080FF" font-bold="True" font-names="Arial"
                        Text="Usermanagement" width="848px"></asp:Label>
                        </td>
                    </tr>
                </table>
                <br />
                <table __designer:mapid="226" style="width: 571px">
                    <tr __designer:mapid="227">
                        <td align="left" __designer:mapid="228" style="width: 261px">
                            <asp:Label id="Label1" runat="server" Text="Employee Name" font-names="Arial" 
                            font-size="Small"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox id="txtCode" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr __designer:mapid="227">
                        <td align="left" __designer:mapid="228" style="width: 261px">
                            <asp:Label id="Label11" runat="server" Text="Username" font-names="Arial" 
                            font-size="Small"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox id="txtCode0" runat="server" width="143px"></asp:TextBox>
                        </td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr __designer:mapid="22c">
                        <td align="left" __designer:mapid="22d" style="width: 261px">
                            <asp:Label id="Label2" runat="server" Text="Password" font-names="Arial" 
                            font-size="Small"></asp:Label>
                        </td>
                        <td __designer:mapid="22f" style="text-align: left">
                            <asp:TextBox id="txtFname" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td align="left">
                            <asp:Label id="Label13" runat="server" Text="Role" font-names="Arial" 
                            font-size="Small"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList id="DropDownList2" runat="server" autopostback="True" 
                                width="125px">
                                <asp:ListItem>Administrator</asp:ListItem>
                                <asp:ListItem>Super Administrator</asp:ListItem>
                                <asp:ListItem>Processing</asp:ListItem>
                                <asp:ListItem>Audit</asp:ListItem>
                                <asp:ListItem>Reporting</asp:ListItem>
                                <asp:ListItem>Housekeeping</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td></td>
                        <td></td>
                    </tr>
                    <tr>
                        <td colspan ="1" align ="left">
                            <asp:Label id="Label14" runat="server" Text="Permissions" font-names="Arial" 
                            font-size="Small"></asp:Label>
                        </td>
                        <td colspan ="3">
                            <asp:ListBox id="ListBox1" runat="server" width="289px" Height="64px" 
                                SelectionMode="Multiple">
                                <asp:ListItem>Enquiries</asp:ListItem>
                                <asp:ListItem>Corporate Events Enquieries</asp:ListItem>
                                <asp:ListItem>Transactions Authorization</asp:ListItem>
                                <asp:ListItem>Accounts Creation</asp:ListItem>
                                <asp:ListItem>Auditing</asp:ListItem>
                                <asp:ListItem>Reporting</asp:ListItem>
                                <asp:ListItem>Parameter Setting</asp:ListItem>
                                <asp:ListItem>Sub System Users</asp:ListItem>
                                <asp:ListItem>Transaction Batching</asp:ListItem>
                            </asp:ListBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan ="1" align ="left">
                            &nbsp;</td>
                        <td colspan ="3">
                            <asp:Button id="btnSave" runat="server" Text="Save" width="64px" 
                                style="height: 26px; text-align: center" />
                        </td>
                    </tr>
                    <tr __designer:mapid="231">
                        <td align="left" __designer:mapid="232" colspan="4" style="text-align: center">
                            &nbsp;</td>
                    </tr>
                </table>
                <table __designer:mapid="249">
                    <tr __designer:mapid="24a">
                        <td colspan="3" align="center" bgcolor="#8080ff" style="height: 13px" 
                        __designer:mapid="24b">
                            <asp:Label id="Label10" runat="server" 
                            Text="..................................................................................................................................................................................................." 
                            width="848px"></asp:Label>
                        </td>
                    </tr>
                    <tr __designer:mapid="24d">
                        <td colspan ="1" style="width: 260px" __designer:mapid="24e">
                            <asp:Label id="Label3" runat="server" Text="Search User"></asp:Label>
                        </td>
                        <td colspan ="2" align ="left"> 
                            <asp:TextBox id="TextBox1" runat="server"></asp:TextBox><asp:Button id="Button1"
                                runat="server" Text=">>" />
                        </td>
                        <td colspan ="1" style="width: 424px" __designer:mapid="252">
                        </td>
                    </tr>
                    
                    <tr __designer:mapid="24d">
                        <td colspan ="1" style="width: 260px" __designer:mapid="24e">
                            <asp:Label id="Label5" runat="server" Text=" Details"></asp:Label>
                        </td>
                        <td colspan ="2" align ="left"> 
                            &nbsp;</td>
                        <td colspan ="1" style="width: 424px" __designer:mapid="252">
                        </td>
                    </tr>
                    <tr>
                        <td colspan ="4" align ="center">
                            <asp:RadioButton id="rdSacve" GroupName ="Options" Text ="Lock Account" runat="server" />
                            <asp:RadioButton id="RadioButton1" GroupName ="Options" Text ="Delete Account" runat="server" />
                           <asp:RadioButton id="RadioButton2" GroupName ="Options" Text ="Reset Account" runat="server" />
                        </td>
                        
                    </tr>
                    
                    <tr>
                        <td colspan ="4" align="center">
                            <asp:Button id="Button2" runat="server" Text="Save" /></td>
                    </tr>
                     
                </table>
                <table __designer:mapid="253">
                    <tr __designer:mapid="254">
                        <td style="width: 850px" align="center" __designer:mapid="255">
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>

