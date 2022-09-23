<%@ Page Language="VB" MasterPageFile="~/CDSmain.master" AutoEventWireup="false" CodeFile="Frmuserpermissions.aspx.vb" Inherits="CDSMode_Frmuserpermissions" title="System Permissions" %>

<asp:Content id="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="border-right: #000033 thin solid; border-top: #000033 thin solid; border-left: #000033 thin solid; width: 832px; border-bottom: #000033 thin solid; background-color: #ffffff" 
            __designer:mapid="21f">
        <tr align="center" __designer:mapid="220">
            <td style="width: 712px; height: 226px" valign="top" __designer:mapid="221">
                <table __designer:mapid="222">
                    <tr __designer:mapid="223">
                        <td style="width: 870px" align="center" __designer:mapid="224">
                            <asp:Label id="Label4" runat="server" backcolor="#8080FF" font-bold="True" font-names="Arial"
                        Text="Usermanagement" width="831px" Height="16px"></asp:Label>
                        </td>
                    </tr>
                </table>
                <table __designer:mapid="226" style="width: 828px">
                    <tr __designer:mapid="227">
                        <td align="left" __designer:mapid="228" style="width: 104px" align="right">
                            <asp:Label id="Label1" runat="server" Text="Employee Name" font-names="Arial" 
                            font-size="Small"></asp:Label>
                        </td>
                        <td style="width: 114px">
                            <asp:DropDownList id="DropDownList3" runat="server" width="165px">
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:Label id="Label11" runat="server" Text="Username" font-names="Arial" 
                            font-size="Small"></asp:Label>
                           </td>
                        <td style="width: 179px">
                            <asp:TextBox id="txtCode0" runat="server" width="179px"></asp:TextBox>
                        </td>
                    </tr>
                    
                    <tr>
                        <td colspan ="1" align ="left" style="width: 104px">
                            <asp:Label id="Label14" runat="server" Text="Permissions" font-names="Arial" 
                            font-size="Small"></asp:Label>
                        </td>
                        <td colspan ="3">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td colspan ="4" align="left">
                            <table>
                                <tr>
                                    <td colspan ="1"><asp:CheckBox id="CheckBox16" Text ="Account Enquiries" runat="server" /></td>
                                    <td colspan ="1"><asp:CheckBox id="CheckBox17" Text ="Portfolio Enquiries" runat="server" /></td>
                                    <td colspan ="1"><asp:CheckBox id="CheckBox18" Text ="Corporate Actions Enquiries" runat="server" /></td>
                                    <td colspan ="1"><asp:CheckBox id="CheckBox19" Text ="Corporate Actions Instructions Enquiries" runat="server" /></td>
                                </tr>
                                <tr>
                                    <td colspan ="1"><asp:CheckBox id="CheckBox20" Text ="Account Creations" runat="server" /></td>
                                    <td colspan ="1"><asp:CheckBox id="CheckBox21" Text ="Account Updates" runat="server" /></td>
                                    <td colspan ="1"><asp:CheckBox id="CheckBox22" Text ="Batch Creations" runat="server" /></td>
                                    <td colspan ="1"><asp:CheckBox id="CheckBox23" Text ="Transactions Creations" runat="server" /></td>
                                </tr>
                                <tr>
                                    <td colspan ="1"><asp:CheckBox id="CheckBox1" Text ="Account Creation Authorization" runat="server" /></td>
                                    <td colspan ="1"><asp:CheckBox id="CheckBox2" Text ="Account Update Authorization" runat="server" /></td>
                                    <td colspan ="1"><asp:CheckBox id="CheckBox3" Text ="Batch Creation Authorization" runat="server" /></td>
                                    <td colspan ="1"><asp:CheckBox id="CheckBox4" Text ="Transactions Authorization" runat="server" /></td>
                                </tr>
                                <tr>
                                    <td colspan ="1"><asp:CheckBox id="CheckBox5" Text ="Orders Posting" runat="server" /></td>
                                    <td colspan ="1"><asp:CheckBox id="CheckBox6" Text ="Orders Updates" runat="server" /></td>
                                    <td colspan ="1"><asp:CheckBox id="CheckBox7" Text ="Orders Cancellations" runat="server" /></td>
                                    <td colspan ="1"><asp:CheckBox id="CheckBox8" Text ="Orders Authorizations" runat="server" /></td>                                    
                                </tr>
                                <tr>
                                    <td colspan ="1"><asp:CheckBox id="CheckBox9" Text ="Orders File Export" runat="server" /></td>
                                    <td colspan ="1"><asp:CheckBox id="CheckBox10" Text ="ATS File Import" runat="server" /></td>
                                    <td colspan ="1"><asp:CheckBox id="CheckBox11" Text ="Settlement Bank File Export" runat="server" /></td>
                                    <td colspan ="1"><asp:CheckBox id="CheckBox12" Text ="Settlement Import" runat="server" /></td>                                    
                                </tr>
                                <tr>
                                    <td colspan ="1"><asp:CheckBox id="CheckBox13" Text ="Account Reports" runat="server" /></td>
                                    <td colspan ="1"><asp:CheckBox id="CheckBox14" Text ="Corporate Actions Reports" runat="server" /></td>
                                    <td colspan ="1"><asp:CheckBox id="CheckBox15" Text ="Cheques Printing" runat="server" /></td>
                                    <td colspan ="1"></td>
                                </tr>
                                <tr>
                                    <td colspan ="1"></td>
                                    <td colspan ="1"></td>
                                    <td colspan ="1"></td>
                                    <td colspan ="1"></td>
                                </tr>
                                <tr>
                                    <td colspan ="1"></td>
                                    <td colspan ="1"></td>
                                    <td colspan ="1"></td>
                                    <td colspan ="1"></td>
                                </tr>
                                <tr>
                                   <td colspan ="1"></td>
                                    <td colspan ="1">
                                        <asp:CheckBox id="CheckBox24" runat="server" Text ="Lock Account" /></td>
                                    <td colspan ="1">
                                        <asp:CheckBox id="CheckBox25" runat="server" Text ="Reset Account Password" /></td>
                                    <td colspan ="1"></td>
                                </tr>
                            </table>
                        </td>
                    </tr>                        
                      
                    <tr __designer:mapid="231">
                        <td align="left" __designer:mapid="232" colspan="4" style="text-align: center">
                            <asp:Button id="btnSave" runat="server" Text="Save" width="64px" 
                                style="height: 26px; text-align: center" />
                        </td>
                    </tr>
                </table>
                <table __designer:mapid="249" style="width: 813px">
                    <tr __designer:mapid="24a">
                        <td colspan="2" align="center" bgcolor="#8080ff" style="height: 13px" 
                        __designer:mapid="24b">
                            <asp:Label id="Label10" runat="server" 
                            Text="..................................................................................................................................................................................................." 
                            width="848px"></asp:Label>
                        </td>
                    </tr>
                    <tr __designer:mapid="24d">
                        <td colspan ="1" style="width: 147px" __designer:mapid="24e">
                            <asp:Label id="Label3" runat="server" Text="Search User"></asp:Label>
                        </td>
                        <td align ="left"> 
                            <asp:TextBox id="TextBox1" runat="server"></asp:TextBox><asp:Button id="Button1"
                                runat="server" Text=">>" />
                        </td>
                    </tr>
                    
                    <tr __designer:mapid="24d">
                        <td colspan ="1" style="width: 147px" __designer:mapid="24e">
                            <asp:Label id="Label5" runat="server" Text=" Details"></asp:Label>
                        </td>
                        <td align ="left"> 
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td colspan ="2" align ="center">
                            <asp:RadioButton id="rdSacve" GroupName ="Options" Text ="Lock Account" runat="server" />
                            <asp:RadioButton id="RadioButton1" GroupName ="Options" Text ="Delete Account" runat="server" />
                           <asp:RadioButton id="RadioButton2" GroupName ="Options" Text ="Reset Account" runat="server" />
                        </td>
                        
                    </tr>
                    
                    <tr>
                        <td colspan ="2" align="center">
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

