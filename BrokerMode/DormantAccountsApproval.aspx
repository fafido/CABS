<%@ Page Language="VB" MasterPageFile="~/CDSUser.master" AutoEventWireup="false" CodeFile="DormantAccountsApproval.aspx.vb" Inherits="BrokerMode_DormantAccountsApproval" title="Dormant Accounts Authorization" %>

<%@ Register Assembly="BasicFrame.WebControls.BasicDatePicker" Namespace="BasicFrame.WebControls"
    TagPrefix="BDP" %>
<asp:Content id="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
    <asp:Panel id="Panel1" runat="server">
    
<table style="border-right: #000033 thin solid; border-top: #000033 thin solid; border-left: #000033 thin solid; width: 832px; border-bottom: #000033 thin solid; background-color: #ffffff">
<tr>
    <td>
    <table>
    <tr>
        <td style="width: 712px; height: 226px" valign="top">
            <table>
            <tr>
                <td style="width: 870px" align="center">
                    <asp:Label id="Label4" runat="server" backcolor="#8080FF" font-bold="True" font-names="Arial"
                        Text="Dormant Accounts Authorization Form" width="808px"></asp:Label></td>
            </tr>
                <tr>
                    <td colspan ="4" valign="top">
                        <asp:Label id="Label1" runat="server" Text="Shareholder Number:" width="176px" font-names="Verdana" font-size="Small"></asp:Label>
                        <asp:DropDownList id="cmbCdsNumber" runat="server" width="152px" autopostback="True">
                        </asp:DropDownList></td>
                </tr>
                
            </table>
            <table>
                <tr>
                    <td style="width: 143px">
                        <asp:Label id="Label5" runat="server" Text="Account Type:" font-names="Verdana" font-size="Small"></asp:Label></td>
                        <td>
                            </td>
                            <td style="width: 4px">
                                </td>
                                <td style="width: 13px">
                                    </td>
                                    <td style="width: 141px">
                                        <asp:Label id="lblAccount" runat="server"></asp:Label></td>
                                        <td colspan ="2" style="width: 166px"></td>
                                        <td align="center">                        &nbsp;</td>
                </tr>
            </table>
            <table>
                <tr>
                    <td colspan ="1" style="width: 175px">
                        <asp:Label id="Label2" runat="server" Text="Surname" font-names="Verdana" font-size="Small"></asp:Label></td>
                        <td colspan="1" style="width: 203px">
                            <asp:TextBox id="txtSurname" runat="server" ReadOnly="True" width="195px"></asp:TextBox></td>
                            <td colspan ="1" style="width: 172px">
                                <asp:Label id="Label3" runat="server" Text="Fornames" font-names="Verdana" font-size="Small"></asp:Label></td>
                                <td colspan ="1" style="width: 316px">
                                    <asp:TextBox id="txtforenames" runat="server" ReadOnly="True" width="218px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td colspan ="1" style="width: 175px">
                        <asp:Label id="Label25" runat="server" Text="Surname" font-names="Verdana" font-size="Small"></asp:Label></td>
                        <td colspan="1" style="width: 203px">
                            <asp:TextBox id="txtJSurname" runat="server" ReadOnly="True" width="195px"></asp:TextBox></td>
                            <td colspan ="1" style="width: 172px">
                                <asp:Label id="Label26" runat="server" Text="Fornames" font-names="Verdana" font-size="Small"></asp:Label></td>
                                <td colspan ="1" style="width: 316px">
                                    <asp:TextBox id="txtJForenames" runat="server" ReadOnly="True" width="218px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="width: 175px">
                        <asp:Label id="Label6" runat="server" Text="id Number" font-names="Verdana" font-size="Small"></asp:Label></td>
                        <td>
                            <asp:TextBox id="txtID" runat="server" ReadOnly="True" width="194px"></asp:TextBox></td>
                            <td style="width: 172px">
                                <asp:Label id="Label20" runat="server" font-names="Verdana" font-size="Small" Text="DOB"></asp:Label></td>
                            <td>
                                <asp:TextBox id="txtDOB" runat="server" ReadOnly="True"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>
                        <asp:Label id="Label22" runat="server" font-names="Verdana" font-size="Small" 
                            Text="Title"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox id="txtTitle" runat="server" ReadOnly="True"></asp:TextBox>
                    </td>
                    <td>
                        <asp:Label id="Label23" runat="server" font-names="Verdana" font-size="Small" 
                            Text="Initials"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox id="txtInitials" runat="server" ReadOnly="True" width="223px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="width: 175px"></td>
                    <td></td>
                    <td style="width: 172px"></td>
                    <td></td>
                </tr>
                <tr>
                    <td style="width: 175px">
                        <asp:Label id="Label7" runat="server" Text="Address:" font-names="Verdana" font-size="Small"></asp:Label></td>
                        <td>
                            <asp:TextBox id="txtAdd1" runat="server" ReadOnly="True" width="195px"></asp:TextBox></td>
                            <td style="width: 172px"></td>
                            <td>
                                <asp:TextBox id="txtAdd2" runat="server" ReadOnly="True" width="224px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="width: 175px"></td>
                    <td>
                        <asp:TextBox id="txtadd3" runat="server" ReadOnly="True" width="193px"></asp:TextBox></td>
                        <td style="width: 172px"></td>
                        <td>
                            <asp:TextBox id="txtadd4" runat="server" ReadOnly="True" width="223px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>
                        <asp:Label id="Label24" runat="server" font-names="Verdana" font-size="Small" 
                            Text="Postal Code"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox id="txtPostal" runat="server" ReadOnly="True" width="194px"></asp:TextBox>
                    </td>
                    <td></td>
                    <td></td>
                </tr>
                <tr>
                    <td style="width: 175px">
                        <asp:Label id="Label8" runat="server" Text="Country" font-names="Verdana" font-size="Small"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox id="txtCountry" runat="server" ReadOnly="True" width="196px"></asp:TextBox></td>
                            <td style="width: 172px">
                                <asp:Label id="Label9" runat="server" Text="City/Town" font-names="Verdana" font-size="Small"></asp:Label></td>
                                <td>
                                    <asp:TextBox id="txtCity" runat="server" ReadOnly="True" width="221px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>
                        <asp:Label id="Label29" runat="server" font-names="Verdana" font-size="Small" 
                            Text="Nationality"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox id="txtNationality" runat="server" ReadOnly="True" width="196px"></asp:TextBox>
                    </td>
                    <td></td>
                    <td></td>
                </tr>
                <tr>
                    <td style="width: 175px">
                        <asp:Label id="Label10" runat="server" Text="Telephone:" font-names="Verdana" font-size="Small"></asp:Label></td>
                        <td>
                            <asp:TextBox id="txtTel" runat="server" ReadOnly="True" width="195px"></asp:TextBox></td>
                            <td style="width: 172px">
                                <asp:Label id="Label11" runat="server" Text="Cellphone" font-names="Verdana" font-size="Small"></asp:Label></td>
                                <td>
                                    <asp:TextBox id="txtCell" runat="server" ReadOnly="True" width="221px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="width: 175px">
                        &nbsp;</td>
                        <td>
                            &nbsp;</td>
                            <td style="width: 172px">
                                <asp:Label id="Label28" runat="server" Text="Cellphone" font-names="Verdana" font-size="Small"></asp:Label></td>
                                <td>
                                    <asp:TextBox id="txtJcellphone" runat="server" ReadOnly="True" width="221px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="width: 175px">
                        <asp:Label id="Label12" runat="server" Text="Email" font-names="Verdana" font-size="Small"></asp:Label></td>
                        <td>
                            <asp:TextBox id="txtEmail" runat="server" ReadOnly="True"></asp:TextBox></td>
                            <td style="width: 172px">
                                <asp:Label id="Label13" runat="server" Text="Fax" font-names="Verdana" font-size="Small"></asp:Label></td>
                                <td>
                                    <asp:TextBox id="txtFax" runat="server" ReadOnly="True" width="219px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="width: 175px">
                        <asp:Label id="Label27" runat="server" Text="Email" font-names="Verdana" font-size="Small"></asp:Label></td>
                        <td>
                            <asp:TextBox id="txtJemail" runat="server" ReadOnly="True"></asp:TextBox></td>
                            <td style="width: 172px">
                                </td>
                                <td>
                                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label id="Label21" runat="server" font-names="Verdana" font-size="Small" 
                            Text="Broker"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox id="txtBrokerCode" runat="server" ReadOnly="True"></asp:TextBox>
                    </td>
                    <td></td>
                    <td></td>
                </tr>
                <tr>
                    <td style="width: 175px">
                        </td>
                    <td></td>
                    <td style="width: 172px"></td>
                    <td></td>
                </tr>
                <tr>
                    <td style="width: 175px">
                        <asp:Label id="Label14" runat="server" Text="Bank" font-names="Verdana" font-size="Small"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox id="txtBank" runat="server" ReadOnly="True"></asp:TextBox></td>
                            <td style="width: 172px">
                                <asp:Label id="Label15" runat="server" Text="Branch" font-names="Verdana" font-size="Small"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox id="txtBranch" runat="server" ReadOnly="True"></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="width: 175px">
                        <asp:Label id="Label16" runat="server" Text="Account Number" font-names="Verdana" font-size="Small"></asp:Label></td>
                        <td>
                            <asp:TextBox id="txtBnkAccount" runat="server" ReadOnly="True"></asp:TextBox></td>
                            <td style="width: 172px">
                                <asp:Label id="Label17" runat="server" Text="Account Type" font-names="Verdana" font-size="Small"></asp:Label></td>
                                <td>
                                    <asp:DropDownList id="cmbAccType" runat="server" width="160px" Enabled="False">
                                    </asp:DropDownList></td>
                </tr>
                <tr>
                    <td style="width: 175px"></td>
                    <td></td>
                    <td style="width: 172px"></td>
                    <td></td>
                </tr>
                <tr>
                    <td style="width: 175px">
                        <asp:Label id="Label18" runat="server" Text="Industry" font-names="Verdana" font-size="Small"></asp:Label></td>
                        <td>
                            <asp:TextBox id="txtIndustry" runat="server" ReadOnly="True"></asp:TextBox></td>
                            <td style="width: 172px">
                                <asp:Label id="Label19" runat="server" Text="Tax Code" font-names="Verdana" font-size="Small"></asp:Label></td>
                                <td>
                                    <asp:TextBox id="txtTax" runat="server" ReadOnly="True"></asp:TextBox></td>
                </tr>
                <tr>
                    <td colspan = "4" align="center"> 
                        <asp:CheckBox id="CheckBox1" runat="server" autopostback="True" 
                            Text="Reject Account Creation ?" />
                    </td>
                </tr>
                <tr>
                    <td colspan = "4" align="center"> 
                        <asp:TextBox id="txtRejection" runat="server" Height="67px" 
                            TextMode="MultiLine" Visible="False" width="693px"></asp:TextBox>
                    </td>
                </tr>
                
            </table>
            <table>
                <tr>
                    <td style="width: 850px" align="center">
                        <asp:Button id="btnSave" runat="server" Text="Approve Account Creation" width="200px" />
                        <asp:Button id="btnSave0" runat="server" Text="Reject Account Creation" 
                            width="200px" Visible="False" />
                    </td>                
                </tr>
                <tr>
                    <td align="center" style="width: 850px">
                        <asp:Image id="Image1" runat="server" />
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    </table>
    </td>
    <td valign ="top">
        <table>
            <tr>
                <td>&nbsp;</td>
            </tr>
        </table>
    </td>
    
    
</tr>
    
</table>

</asp:Panel>
</div>
</asp:Content>

