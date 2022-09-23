<%@ Page Language="VB" MasterPageFile="~/CDSUser.master" AutoEventWireup="false" CodeFile="AccountUpdate.aspx.vb" Inherits="Custodian_AccountUpdate" title="Accounts Update" %>

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
                        Text="Accounts Update" width="1020px"></asp:Label></td>
            </tr>
                <tr>
                    <td colspan ="4" valign="top">
                        <asp:Label id="Label1" runat="server" Text="Shareholder Number:" width="144px" font-names="Verdana" font-size="Small"></asp:Label>
                        <asp:TextBox id="txtshareholderSerch" runat="server"></asp:TextBox>
                        <asp:Button id="btnHolderNumSearch" runat="server" Text=">>" /></td>
                </tr>
                
            </table>
            <table>
                <tr>
                    <td style="width: 145px">
                        <asp:Label id="Label5" runat="server" Text="Shareholder Name:" font-names="Verdana" font-size="Small"></asp:Label></td>
                        <td style="width: 3px">
                            <asp:TextBox id="txtSearch" runat="server" width="144px"></asp:TextBox></td>
                            <td style="width: 3px">
                                <asp:Button id="btnSearchName" runat="server" Text=">>" /></td>
                                <td>
                                    </td>
                                    <td style="width: 141px">
                                        </td>
                </tr>                
            </table>
            <table>
                <tr>
                    <td style="width: 146px"></td>
                    <td style="width: 148px">
                        <asp:ListBox id="cmbShort" runat="server" Height="136px" width="328px"></asp:ListBox></td>
                        <td>
                            <asp:Image id="Image1" runat="server" /></td>
                </tr>
                <tr>
                    <td></td>
                    <td align="center">
                        <asp:Button id="btnSelect" runat="server" Text="Select" /></td>
                </tr>
            </table>
            <table>
            <tr>
                <td>
                    <asp:RadioButton id="rdIndividual" runat="server" font-names="Verdana" font-size="Small" GroupName="HolderTypes" Text="Individual" /></td>
                <td>
                    <asp:RadioButton id="rdJoint" runat="server" font-names="Verdana" font-size="Small" GroupName="HolderTypes" Text="Joint" /></td>
                <td>
                    <asp:RadioButton id="rdNominee" runat="server" font-names="Verdana" font-size="Small" GroupName="HolderTypes" Text="Nominee" /></td>
                <td>
                    <asp:RadioButton id="rdCompany" runat="server" font-names="Verdana" font-size="Small" GroupName="HolderTypes" Text="Company" /></td>
            </tr>
             <tr>
                    <td colspan ="1" style="width: 210px">
                        <asp:Label id="Label20" runat="server" Text="Shareholder Number:" font-names="Verdana" font-size="Small"></asp:Label></td>
                        <td colspan="1" style="width: 203px">
                            <asp:TextBox id="txtShareholder" runat="server" font-bold="True" ReadOnly="True"></asp:TextBox></td>
                            <td colspan ="1" style="width: 194px">
                                </td>
                                <td colspan ="1" style="width: 316px">
                                    </td>
                </tr>
                <tr>
                    <td colspan ="1" style="width: 210px">
                        <asp:Label id="Label2" runat="server" Text="Surname" font-names="Verdana" font-size="Small"></asp:Label></td>
                        <td colspan="1" style="width: 203px">
                            <asp:TextBox id="txtSurname" runat="server"></asp:TextBox></td>
                            <td colspan ="1" style="width: 194px">
                                <asp:Label id="Label3" runat="server" Text="Fornames" font-names="Verdana" font-size="Small"></asp:Label></td>
                                <td colspan ="1" style="width: 316px">
                                    <asp:TextBox id="txtforenames" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="width: 210px">
                        <asp:Label id="Label6" runat="server" Text="id Number" font-names="Verdana" font-size="Small"></asp:Label></td>
                        <td>
                            <asp:TextBox id="txtID" runat="server"></asp:TextBox></td>
                            <td style="width: 194px">
                                <asp:Label id="Label22" runat="server" font-names="Verdana" font-size="Small" Text="DOB"></asp:Label></td>
                            <td>
                                <BDP:BasicDatePicker id="BasicDatePicker1" runat="server">
                                </BDP:BasicDatePicker>
                            </td>
                </tr>
                <tr>
                    <td style="width: 210px"></td>
                    <td></td>
                    <td style="width: 194px"></td>
                    <td></td>
                </tr>
                <tr>
                    <td style="width: 210px; height: 40px;">
                        <asp:Label id="Label7" runat="server" Text="Address:" font-names="Verdana" font-size="Small"></asp:Label></td>
                        <td style="height: 40px">
                            <asp:TextBox id="txtAdd1" runat="server" Height="64px" TextMode="MultiLine" width="160px"></asp:TextBox></td>
                            <td style="width: 194px; height: 40px;"></td>
                            <td style="height: 40px">
                                <asp:TextBox id="txtAdd2" runat="server" Height="64px" TextMode="MultiLine"></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="width: 210px"></td>
                    <td>
                        <asp:TextBox id="txtadd3" runat="server" Height="56px" TextMode="MultiLine" width="160px"></asp:TextBox></td>
                        <td style="width: 194px"></td>
                        <td>
                            <asp:TextBox id="txtadd4" runat="server" Height="56px" TextMode="MultiLine"></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="width: 210px">
                        <asp:Label id="Label8" runat="server" Text="Country" font-names="Verdana" font-size="Small"></asp:Label>
                        <asp:Label id="lblCountry" runat="server"></asp:Label></td>
                        <td>
                            <asp:DropDownList id="cmbCountry" runat="server" width="152px" autopostback="True">
                            </asp:DropDownList></td>
                            <td style="width: 194px">
                                <asp:Label id="Label9" runat="server" Text="City/Town" font-names="Verdana" font-size="Small"></asp:Label></td>
                                <td>
                                    <asp:DropDownList id="CmbCity" runat="server" width="160px">
                                    </asp:DropDownList></td>
                </tr>
                <tr>
                    <td style="width: 210px">
                        <asp:Label id="Label10" runat="server" Text="Telephone:" font-names="Verdana" font-size="Small"></asp:Label></td>
                        <td>
                            <asp:TextBox id="txtTel" runat="server"></asp:TextBox></td>
                            <td style="width: 194px">
                                <asp:Label id="Label11" runat="server" Text="Cellphone" font-names="Verdana" font-size="Small"></asp:Label></td>
                                <td>
                                    <asp:TextBox id="txtCell" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="width: 210px">
                        <asp:Label id="Label12" runat="server" Text="Email" font-names="Verdana" font-size="Small"></asp:Label></td>
                        <td>
                            <asp:TextBox id="txtEmail" runat="server"></asp:TextBox></td>
                            <td style="width: 194px">
                                <asp:Label id="Label13" runat="server" Text="Fax" font-names="Verdana" font-size="Small"></asp:Label></td>
                                <td>
                                    <asp:TextBox id="txtFax" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="width: 210px">
                        <asp:CheckBox id="chkBank" runat="server" Text="Add Banking Details" font-names="Verdana" font-size="Small" width="152px" autopostback="True" /></td>
                    <td></td>
                    <td style="width: 194px"></td>
                    <td>
                        <asp:CheckBox id="ChkRemoveBank" runat="server" autopostback="True" font-names="Arial"
                            font-size="Small" Text="Remove Banking Details" /></td>
                </tr>
                <tr>
                    <td style="width: 210px">
                        <asp:Label id="Label14" runat="server" Text="Bank" font-names="Verdana" font-size="Small"></asp:Label>
                        <asp:Label id="lblBank" runat="server"></asp:Label></td>
                        <td>
                            <asp:DropDownList id="cmbBank" runat="server" width="152px" autopostback="True">
                            </asp:DropDownList></td>
                            <td style="width: 194px">
                                <asp:Label id="Label15" runat="server" Text="Branch" font-names="Verdana" font-size="Small"></asp:Label>
                                <asp:Label id="lblBranch" runat="server" width="56px"></asp:Label></td>
                                <td>
                                    <asp:DropDownList id="cmbBranch" runat="server" width="160px">
                                    </asp:DropDownList></td>
                </tr>
                <tr>
                    <td style="width: 210px">
                        <asp:Label id="Label16" runat="server" Text="Account Number" font-names="Verdana" font-size="Small"></asp:Label></td>
                        <td>
                            <asp:TextBox id="txtBnkAccount" runat="server"></asp:TextBox></td>
                            <td style="width: 194px">
                                <asp:Label id="Label17" runat="server" Text="Account Type" font-names="Verdana" font-size="Small"></asp:Label></td>
                                <td>
                                    <asp:DropDownList id="cmbAccType" runat="server" width="160px">
                                    </asp:DropDownList></td>
                </tr>
                <tr>
                    <td style="width: 210px"></td>
                    <td></td>
                    <td style="width: 194px"></td>
                    <td></td>
                </tr>
                <tr>
                    <td style="width: 210px">
                        <asp:Label id="Label18" runat="server" Text="Industry" font-names="Verdana" font-size="Small"></asp:Label></td>
                        <td>
                            <asp:DropDownList id="cmbIndustry" runat="server" width="152px">
                            </asp:DropDownList></td>
                            <td style="width: 194px">
                                <asp:Label id="Label19" runat="server" Text="Tax Code" font-names="Verdana" font-size="Small"></asp:Label></td>
                                <td>
                                    <asp:DropDownList id="cmbTax" runat="server" width="160px">
                                    </asp:DropDownList></td>
                </tr>
                <tr>
                    <td>
                        <asp:Label id="Label21" runat="server" font-names="Verdana" font-size="Small" Text="Account State"></asp:Label></td>
                    <td>
                        <asp:RadioButton id="rdLock" runat="server" font-names="Verdana" font-size="Small"
                            GroupName="LockAccounts" Text="Lock Account" /></td>
                    <td>
                        <asp:RadioButton id="rdUnlock" runat="server" font-names="Verdana" font-size="Small"
                            GroupName="LockAccounts" Text="Unlock Account" width="128px" /></td>
                    <td>
                        <asp:CheckBox id="chkHFC" runat="server" font-names="Verdana" font-size="Small" Text="H.F.C" /></td>
                </tr>
                <tr>
                <td colspan ="1">
                    <asp:Label id="Label25" runat="server" font-names="Verdana" font-size="Small" 
                        Text="Holder's Image"></asp:Label>
                    </td>
                    <td colspan ="3" align="left">
                        <input id="fDocument" runat="server" onclick="return fDocument_onclick()" 
                            style="width: 266px; height: 26px;" type="file" validationgroup="*.jpg" /><asp:Button 
                            id="Button2" runat="server" Text="Load Image" />
                        <asp:TextBox 
                            id="TextBox1" runat="server" Visible="False"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                    
                </tr>
                <tr>
                    <td colspan ="4" align="center">
                        <asp:TextBox id="TextBox3" runat="server" width="386px" Visible="False"></asp:TextBox>
                    </td>
                    
                                        
                </tr>
                <tr>
                    <td><asp:TextBox id="TextBox2" runat="server" Visible="False"></asp:TextBox></td>
                    <td></td>
                    <td></td>
                    <td>
                        <asp:Button id="Button1" runat="server" Text="Copy Image" Visible="False" /></td>
                </tr>
                
            </table>
            <table>
                <tr>
                    <td colspan ="4" style="width: 850px" align="center">
                        <asp:Button id="btnSave" runat="server" Text="Update" width="96px" /></td>                
                </tr>
            </table>
        </td>
    </tr>
</table>
</asp:Panel>
</div>
</asp:Content>

