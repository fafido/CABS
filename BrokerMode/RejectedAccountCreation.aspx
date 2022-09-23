<%@ Page Language="VB" MasterPageFile="~/CDSUser.master" AutoEventWireup="false" CodeFile="RejectedAccountCreation.aspx.vb" Inherits="BrokerMode_RejectedAccountCreation" title="Account Creation" %>

<%@ Register Assembly="BasicFrame.WebControls.BasicDatePicker" Namespace="BasicFrame.WebControls"
    TagPrefix="BDP" %>
<asp:Content id="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <style type="text/css">
        #fDocument
        {
            width: 247px;
            height: 23px;
            margin-left: 146px;
        }
        .style1
        {
            height: 27px;
            width: 179px;
        }
        .style3
        {
            width: 172px;
        }
        .style4
        {
            width: 157px;
        }
        .style5
        {
            width: 160px;
        }
        .style6
        {
            width: 148px;
        }
        </style>
<script type="text/javascript"language="javascript">
/*function getFile()
{
    document.getElementById("fDocument").click();
    var file = "";
    if(document.getElementById("TextBox1").value == "")
        file = document.getElementById("fDocument").value; 
    else
        file = document.getElementById("TextBox1").value +
            "\r\n" + document.getElementById("fDocument").value;
    document.getElementById("TextBox1").value = file ;
}
*/
    function fDocument_onclick() {

    }

</script>
<div>
    <asp:Panel id="Panel1" runat="server">
    
<table style="border-right: #000033 thin solid; border-top: #000033 thin solid; border-left: #000033 thin solid; width: 832px; border-bottom: #000033 thin solid; background-color: #ffffff">
    <tr>
        <td style="width: 712px; height: 226px" valign="top">
            <table>
            <tr>
                <td style="width: 870px" align="center">
                    <asp:Label id="Label4" runat="server" backcolor="#8080FF" font-bold="True" font-names="Arial"
                        Text="Rejected Accounts Creation Form" width="848px"></asp:Label></td>
            </tr>
                <tr>
                    <td colspan ="4" valign="top">
                        &nbsp;</td>
                </tr>
                
            </table>
            <table style="width: 831px">
                <tr>
                    <td class="style3">
                        <asp:Label id="Label1" runat="server" font-names="Verdana" font-size="Small" 
                            Text="Shareholder Number:" width="169px"></asp:Label>
                    </td>
                        <td class="style5">
                            <asp:DropDownList id="cmbCdsNumber" runat="server" autopostback="True" 
                                width="132px">
                            </asp:DropDownList>
                    </td>
                            <td class="style6">
                                &nbsp;</td>
                                <td class="style4">
                                    &nbsp;</td>
                                    <td style="width: 141px">
                                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="style3">
                        <asp:Label id="Label5" runat="server" font-names="Verdana" font-size="Small" 
                            Text="Account Type:"></asp:Label>
                    </td>
                    <td class="style5">
                        <asp:RadioButton id="rdIndividual" runat="server" autopostback="True" 
                            font-names="Verdana" font-size="Small" GroupName="Acctype" 
                            Text="Individual Account" />
                    </td>
                    <td class="style6">
                        <asp:RadioButton id="rdJoint" runat="server" autopostback="True" 
                            font-names="Verdana" font-size="Small" GroupName="Acctype" 
                            Text="Joint Account" />
                    </td>
                    <td class="style4">
                        <asp:RadioButton id="rdNominee" runat="server" autopostback="True" 
                            font-names="Verdana" font-size="Small" GroupName="Acctype" 
                            Text="Nominee Account" />
                    </td>
                    <td style="width: 141px">
                        <asp:RadioButton id="rdCompany" runat="server" autopostback="True" 
                            font-names="Verdana" font-size="Small" GroupName="Acctype" 
                            Text="Company Account" width="150px" />
                    </td>
                </tr>
            </table>
            <table>
                <tr>
                    <td colspan ="1" style="width: 175px">
                        <asp:Label id="Label2" runat="server" Text="Surname" font-names="Verdana" font-size="Small"></asp:Label>
                        <asp:Label id="Label31" runat="server" font-names="Verdana" font-size="Small" 
                            forecolor="Red" Text="*"></asp:Label>
                    </td>
                        <td colspan="1" style="width: 203px">
                            <asp:TextBox id="txtSurname" runat="server" width="180px"></asp:TextBox></td>
                            <td colspan ="1" style="width: 172px">
                                <asp:Label id="Label3" runat="server" Text="Fornames" font-names="Verdana" font-size="Small"></asp:Label></td>
                                <td colspan ="1" style="width: 316px">
                                    <asp:TextBox id="txtforenames" runat="server" width="180px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td colspan ="1" style="width: 175px">
                        <asp:Label id="Label27" runat="server" Text="Surname" font-names="Verdana" font-size="Small" Visible ="false"></asp:Label></td>
                        <td colspan="1" style="width: 203px">
                            <asp:TextBox id="TextBox4" runat="server" width="180px" Visible ="false"></asp:TextBox></td>
                            <td colspan ="1" style="width: 172px">
                                <asp:Label id="Label28" runat="server" Text="Fornames" font-names="Verdana" font-size="Small" Visible ="false"></asp:Label></td>
                                <td colspan ="1" style="width: 316px">
                                    <asp:TextBox id="TextBox5" runat="server" width="180px" Visible ="false"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>
                        <asp:Label id="Label22" runat="server" font-names="Verdana" font-size="Small" 
                            Text="Initials"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox id="txtInitials" runat="server" width="180px"></asp:TextBox>
                    </td>
                    <td>
                        <asp:Label id="Label23" runat="server" font-names="Verdana" font-size="Small" 
                            Text="Title"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList id="cmbTitle" runat="server">
                            <asp:ListItem>MR</asp:ListItem>
                            <asp:ListItem>MISS</asp:ListItem>
                            <asp:ListItem>MRS</asp:ListItem>
                            <asp:ListItem>DR</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td style="width: 175px">
                        <asp:Label id="Label20" runat="server" font-names="Verdana" font-size="Small" 
                            Text="DOB"></asp:Label>
                    </td>
                        <td>
                            <BDP:BasicDatePicker id="BasicDatePicker1" runat="server" ReadOnly="True" 
                                width="180px">
                            </BDP:BasicDatePicker>
                    </td>
                            <td style="width: 172px">
                                <asp:Label id="Label37" runat="server" font-names="Verdana" font-size="Small" 
                                    Text="Old Shareholder No."></asp:Label>
                    </td>
                            <td>
                                <asp:TextBox id="txtOldShareholder" runat="server" width="180px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="width: 175px">
                        <asp:Label id="Label26" runat="server" font-names="Verdana" font-size="Small" 
                            Text="Identity Document"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList id="cmbSecurityDoc" runat="server" autopostback="True" 
                            width="186px" Height="22px">
                        </asp:DropDownList>
                    </td>
                    <td style="width: 172px">
                        <asp:Label id="Label6" runat="server" font-names="Verdana" font-size="Small" 
                            Text="Identity Doc No."></asp:Label>
                        <asp:Label id="Label33" runat="server" font-names="Verdana" font-size="Small" 
                            forecolor="Red" Text="*"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox id="txtID" runat="server" width="180px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="width: 175px">
                        <asp:Label id="Label7" runat="server" Text="Address:" font-names="Verdana" font-size="Small"></asp:Label>
                        <asp:Label id="Label34" runat="server" font-names="Verdana" font-size="Small" 
                            forecolor="Red" Text="*"></asp:Label>
                    </td>
                        <td>
                            <asp:TextBox id="txtAdd1" runat="server" width="180px"></asp:TextBox></td>
                            <td style="width: 172px"></td>
                            <td>
                                <asp:TextBox id="txtAdd2" runat="server" width="180px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="width: 175px"></td>
                    <td>
                        <asp:TextBox id="txtadd3" runat="server" width="180px"></asp:TextBox></td>
                        <td style="width: 172px"></td>
                        <td>
                            <asp:TextBox id="txtadd4" runat="server" width="180px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>
                        <asp:Label id="Label24" runat="server" font-names="Verdana" font-size="Small" 
                            Text="Postal Code"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox id="txtpostal" runat="server" width="180px"></asp:TextBox>
                    </td>
                    <td></td>
                    <td></td>
                </tr>
                <tr>
                    <td style="width: 175px">
                        <asp:Label id="Label8" runat="server" Text="Country" font-names="Verdana" font-size="Small"></asp:Label>
                        <asp:Label id="lblCountry" runat="server" Visible ="false"></asp:Label></td>
                        <td>
                            <asp:DropDownList id="cmbCountry" runat="server" width="186px" 
                                autopostback="True">
                            </asp:DropDownList></td>
                            <td style="width: 172px">
                                <asp:Label id="Label9" runat="server" Text="City/Town" font-names="Verdana" font-size="Small"></asp:Label></td>
                                <td>
                                    <asp:DropDownList id="CmbCity" runat="server" width="186px" autopostback="True">
                                    </asp:DropDownList></td>
                </tr>
                <tr>
                    <td>
                        <asp:Label id="Label36" runat="server" font-names="Verdana" font-size="Small" 
                            Text="Nationality"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList id="cmbNaT" runat="server" autopostback="True" width="186px">
                        </asp:DropDownList>
                    </td>
                    <td></td>
                    <td></td>
                </tr>
                <tr>
                    <td style="width: 175px">
                        <asp:Label id="Label10" runat="server" Text="Telephone:" font-names="Verdana" font-size="Small"></asp:Label></td>
                        <td>
                            <asp:TextBox id="txtTel" runat="server" width="180px"></asp:TextBox></td>
                            <td style="width: 172px">
                                <asp:Label id="Label11" runat="server" Text="Mobile Phone" font-names="Verdana" 
                                    font-size="Small"></asp:Label></td>
                                <td>
                                    <asp:TextBox id="txtCell" runat="server" width="180px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="width: 175px">
                        &nbsp;</td>
                        <td>
                            &nbsp;</td>
                            <td style="width: 172px">
                                <asp:Label id="Label30" runat="server" Text="Mobile Phone" font-names="Verdana" 
                                    font-size="Small" Visible="False"></asp:Label></td>
                                <td>
                                    <asp:TextBox id="TextBox7" runat="server" width="180px" Visible="False"></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="width: 175px">
                        <asp:Label id="Label12" runat="server" Text="Email" font-names="Verdana" font-size="Small"></asp:Label></td>
                        <td>
                            <asp:TextBox id="txtEmail" runat="server" width="180px"></asp:TextBox></td>
                            <td style="width: 172px">
                                <asp:Label id="Label13" runat="server" Text="Fax" font-names="Verdana" font-size="Small"></asp:Label></td>
                                <td>
                                    <asp:TextBox id="txtFax" runat="server" width="180px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="width: 175px">
                        <asp:Label id="Label29" runat="server" Text="Email" font-names="Verdana" 
                            font-size="Small" Visible="False"></asp:Label></td>
                        <td>
                            <asp:TextBox id="TextBox6" runat="server" width="180px" Visible="False"></asp:TextBox></td>
                            <td style="width: 172px">
                                &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                </tr>
                <tr>
                    <td>
                        <asp:Label id="Label21" runat="server" font-names="Verdana" font-size="Small" 
                            Text="Broker"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList id="cmbBroker" runat="server" autopostback="True" 
                            width="186px">
                        </asp:DropDownList>
                    </td>
                    <td></td>
                    <td>
                        <asp:Label id="lblBrokercode" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="width: 175px">
                        <asp:CheckBox id="chkBank" runat="server" Text="Add Banking Details" font-names="Verdana" font-size="Small" autopostback="True" width="168px" /></td>
                    <td></td>
                    <td style="width: 172px"></td>
                    <td></td>
                </tr>
                <tr>
                    <td style="width: 175px">
                        <asp:Label id="Label14" runat="server" Text="Bank" font-names="Verdana" font-size="Small"></asp:Label>
                        <asp:Label id="lblBank" runat="server"></asp:Label></td>
                        <td>
                            <asp:DropDownList id="cmbBank" runat="server" width="186px" autopostback="True">
                            </asp:DropDownList></td>
                            <td style="width: 172px">
                                <asp:Label id="Label15" runat="server" Text="Branch" font-names="Verdana" font-size="Small"></asp:Label>
                                <asp:Label id="lblBranch" runat="server"></asp:Label></td>
                                <td>
                                    <asp:DropDownList id="cmbBranch" runat="server" width="186px">
                                    </asp:DropDownList></td>
                </tr>
                <tr>
                    <td style="width: 175px">
                        <asp:Label id="Label16" runat="server" Text="Account Number" font-names="Verdana" font-size="Small"></asp:Label></td>
                        <td>
                            <asp:TextBox id="txtBnkAccount" runat="server" width="180px"></asp:TextBox></td>
                            <td style="width: 172px">
                                <asp:Label id="Label17" runat="server" Text="Account Type" font-names="Verdana" font-size="Small"></asp:Label></td>
                                <td>
                                    <asp:DropDownList id="cmbAccType" runat="server" width="186px">
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
                            <asp:DropDownList id="cmbIndustry" runat="server" width="186px">
                            </asp:DropDownList></td>
                            <td style="width: 172px">
                                <asp:Label id="Label19" runat="server" Text="Tax Code" font-names="Verdana" font-size="Small"></asp:Label></td>
                                <td>
                                    <asp:DropDownList id="cmbTax" runat="server" width="186px">
                                    </asp:DropDownList></td>
                </tr>
                <tr>
                <td colspan ="1">
                    <asp:Label id="Label25" runat="server" font-names="Verdana" font-size="Small" 
                        Text="Capture Photo"></asp:Label>
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
                        <asp:Image id="Image1" runat="server" /></td>
                </tr>
                
                <tr>
                <td colspan ="1">
                    <asp:Label id="Label32" runat="server" font-names="Verdana" font-size="Small" 
                        Text="Scan id"></asp:Label>
                    </td>
                    <td colspan ="3" align="left">
                        <input id="File1" runat="server" onclick="return fDocument_onclick()" 
                            style="width: 266px; height: 26px;" type="file" validationgroup="*.jpg" /><asp:Button 
                            id="Button3" runat="server" Text="Load Image" />
                        <asp:TextBox 
                            id="TextBox8" runat="server" Visible="False"></asp:TextBox></td>
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
                        <asp:Image id="Image2" runat="server" /></td>
                </tr>
                 <tr>
                <td colspan ="1">
                    <asp:Label id="Label35" runat="server" font-names="Verdana" font-size="Small" 
                        Text="Capture Signature"></asp:Label>
                    </td>
                    <td colspan ="3" align="left">
                        <input id="File2" runat="server" onclick="return fDocument_onclick()" 
                            style="width: 266px; height: 26px;" type="file" validationgroup="*.jpg" /><asp:Button 
                            id="Button4" runat="server" Text="Load Image" />
                        <asp:TextBox 
                            id="TextBox9" runat="server" Visible="False"></asp:TextBox></td>
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
                        <asp:Image id="Image3" runat="server" /></td>
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

