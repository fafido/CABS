<%@ Page Language="VB" MasterPageFile="~/CDSUser.master" AutoEventWireup="false" CodeFile="AccountCreation.aspx.vb" Inherits="TSecMode_AccountCreation" title="Account Creation" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="BasicFrame.WebControls.BasicDatePicker" Namespace="BasicFrame.WebControls"
    TagPrefix="BDP" %>
    
<asp:Content id="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <script src='../Scripts/jquery-1.4.1.js' type='text/javascript'></script>
    <script src='../Scripts/jquery.filter_input.js' type='text/javascript'>
    </script>
    <script src='../Scripts/jquery.maskedinput-1.js' type='text/javascript'>
    </script>
    <style type="text/css">
        #fDocument
        {
            width: 247px;
            height: 23px;
            margin-left: 0px;
        }
        .style1
        {
            height: 27px;
            width: 179px;
        }
        .style2
        {
            width: 179px;
        }
        .style3
        {
            width: 163px;
        }
        .style4
        {
            width: 148px;
        }
        .style5
        {
            width: 120px;
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
                            <td align="center" style="width: 870px">
                                <asp:Label id="Label4" runat="server" backcolor="#8080FF" font-bold="True" 
                                    font-names="Arial" Text="Accounts Creation Form" width="845px" 
                                    Height="16px"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td valign="top">
                                <asp:Label id="Label1" runat="server" font-names="Verdana" font-size="Small" 
                                    Text="Shareholder Number:" width="208px"></asp:Label>
                                <asp:Label id="lblShareholder" runat="server" font-names="Verdana" 
                                    font-size="Small"></asp:Label>
                            </td>
                        </tr>
                    </table>
                    <table style="width: 840px">
                        <tr>
                            <td style="width: 143px">
                                <asp:Label id="Label5" runat="server" font-names="Verdana" font-size="Small" 
                                    Text="Account Type:"></asp:Label>
                            </td>
                            <td class="style4">
                                <asp:RadioButton id="rdIndividual" runat="server" autopostback="True" 
                                    font-names="Verdana" font-size="Small" GroupName="Acctype" 
                                    Text="Individual Account" />
                            </td>
                            <td class="style5">
                                <asp:RadioButton id="rdJoint" runat="server" autopostback="True" 
                                    font-names="Verdana" font-size="Small" GroupName="Acctype" 
                                    Text="Joint Account" />
                            </td>
                            <td class="style3">
                                <asp:RadioButton id="rdNominee" runat="server" autopostback="True" 
                                    font-names="Verdana" font-size="Small" GroupName="Acctype" 
                                    Text="Nominee Account" />
                            </td>
                            <td style="width: 141px">
                                <asp:RadioButton id="rdCompany" runat="server" autopostback="True" 
                                    font-names="Verdana" font-size="Small" GroupName="Acctype" 
                                    Text="Company Account" />
                            </td>
                        </tr>
                    </table>
                    <table style="width: 838px">
                        <tr>
                            <td colspan="1" style="width: 175px">
                                <asp:Label id="Label2" runat="server" font-names="Verdana" font-size="Small" 
                                    Text="Surname"></asp:Label>
                                <asp:Label id="Label31" runat="server" font-names="Verdana" font-size="Small" 
                                    forecolor="Red" Text="*"></asp:Label>
                            </td>
                            <td colspan="1" style="width: 203px">
                                <asp:TextBox id="txtSurname" runat="server" width="180px"></asp:TextBox>
                            </td>
                            <td colspan="1" style="width: 172px">
                                <asp:Label id="Label3" runat="server" font-names="Verdana" font-size="Small" 
                                    Text="Fornames"></asp:Label>
                            </td>
                            <td colspan="1" style="width: 316px">
                                <asp:TextBox id="txtforenames" runat="server" width="180px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="1" style="width: 175px">
                                <asp:Label id="Label27" runat="server" font-names="Verdana" font-size="Small" 
                                    Text="Surname" Visible="false"></asp:Label>
                            </td>
                            <td colspan="1" style="width: 203px">
                                <asp:TextBox id="TextBox4" runat="server" Visible="false" width="180px"></asp:TextBox>
                            </td>
                            <td colspan="1" style="width: 172px">
                                <asp:Label id="Label28" runat="server" font-names="Verdana" font-size="Small" 
                                    Text="Fornames" Visible="false"></asp:Label>
                            </td>
                            <td colspan="1" style="width: 316px">
                                <asp:TextBox id="TextBox5" runat="server" Visible="false" width="180px"></asp:TextBox>
                            </td>
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
                                    width="187px">
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
                                
                                <%--<script type="text/javascript">
                                    $(function() {
                                        $(txtIdtest).filter_input({ regex: '[0-9]' });
                                    });
                                </script>--%></td>
                        </tr>
                        
                        <tr>
                            <td style="width: 175px">
                                <asp:Label id="Label7" runat="server" font-names="Verdana" font-size="Small" 
                                    Text="Address:"></asp:Label>
                                <asp:Label id="Label34" runat="server" font-names="Verdana" font-size="Small" 
                                    forecolor="Red" Text="*"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox id="txtAdd1" runat="server" width="180px"></asp:TextBox>
                            </td>
                            <td style="width: 172px">
                            </td>
                            <td>
                                <asp:TextBox id="txtAdd2" runat="server" width="180px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 175px">
                            </td>
                            <td>
                                <asp:TextBox id="txtadd3" runat="server" width="180px"></asp:TextBox>
                            </td>
                            <td style="width: 172px">
                            </td>
                            <td>
                                <asp:TextBox id="txtadd4" runat="server" width="180px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label id="Label24" runat="server" font-names="Verdana" font-size="Small" 
                                    Text="Postal Code"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox id="txtpostal" runat="server" width="180px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:Label id="Label9" runat="server" font-names="Verdana" font-size="Small" 
                                    Text="City/Town"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList id="CmbCity" runat="server" autopostback="True" width="187px">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 175px">
                                <asp:Label id="Label8" runat="server" font-names="Verdana" font-size="Small" 
                                    Text="Country"></asp:Label>
                                <asp:Label id="lblCountry" runat="server" Visible="false"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList id="cmbCountry" runat="server" autopostback="True" 
                                    width="187px">
                                </asp:DropDownList>
                            </td>
                            <td style="width: 172px">
                                <asp:Label id="Label11" runat="server" font-names="Verdana" font-size="Small" 
                                    Text="Mobile Phone"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox id="txtCell" runat="server" width="180px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label id="Label36" runat="server" font-names="Verdana" font-size="Small" 
                                    Text="Nationality"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList id="cmbNaT" runat="server" autopostback="True" width="187px">
                                </asp:DropDownList>
                            </td>
                            <td>
                                <asp:Label id="Label30" runat="server" font-names="Verdana" font-size="Small" 
                                    Text="Mobile Phone" Visible="False"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox id="TextBox7" runat="server" Visible="False" width="180px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 175px">
                                <asp:Label id="Label10" runat="server" font-names="Verdana" font-size="Small" 
                                    Text="Telephone:"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox id="txtTel" runat="server" width="180px"></asp:TextBox>
                            </td>
                            <td style="width: 172px">
                                <asp:Label id="Label13" runat="server" font-names="Verdana" font-size="Small" 
                                    Text="Fax"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox id="txtFax" runat="server" width="180px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 175px">
                                <asp:Label id="Label12" runat="server" font-names="Verdana" font-size="Small" 
                                    Text="Email"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox id="txtEmail" runat="server" width="180px"></asp:TextBox>
                            </td>
                            <td style="width: 172px">
                                <asp:Label id="Label21" runat="server" font-names="Verdana" font-size="Small" 
                                    Text="Broker"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList id="cmbBroker" runat="server" autopostback="True" 
                                    width="187px">
                                </asp:DropDownList>
                                <asp:Label id="lblBrokercode" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 175px">
                                <asp:Label id="Label29" runat="server" font-names="Verdana" font-size="Small" 
                                    Text="Email" Visible="False"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox id="TextBox6" runat="server" Visible="False" width="180px"></asp:TextBox>
                            </td>
                            <td style="width: 172px">
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td colspan="4">
                              <hr /></td>
                        </tr>
                        <tr>
                            <td style="width: 175px">
                                &nbsp;</td>
                            <td>
                                <asp:CheckBox id="chkBank" runat="server" autopostback="True" 
                                    font-names="Verdana" font-size="Small" Text="Add Banking Details" 
                                    width="168px" />
                            </td>
                            <td style="width: 172px">
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 175px">
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                            <td style="width: 172px">
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width: 175px">
                                <asp:Label id="Label14" runat="server" font-names="Verdana" font-size="Small" 
                                    Text="Bank"></asp:Label>
                                <asp:Label id="lblBank" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList id="cmbBank" runat="server" autopostback="True" width="187px">
                                </asp:DropDownList>
                            </td>
                            <td style="width: 172px">
                                <asp:Label id="Label15" runat="server" font-names="Verdana" font-size="Small" 
                                    Text="Branch"></asp:Label>
                                <asp:Label id="lblBranch" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList id="cmbBranch" runat="server" width="187px">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 175px">
                                <asp:Label id="Label16" runat="server" font-names="Verdana" font-size="Small" 
                                    Text="Account Number"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox id="txtBnkAccount" runat="server" width="180px"></asp:TextBox>
                            </td>
                            <td style="width: 172px">
                                <asp:Label id="Label17" runat="server" font-names="Verdana" font-size="Small" 
                                    Text="Account Type"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList id="cmbAccType" runat="server" width="187px">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 175px">
                                <asp:Label id="Label18" runat="server" font-names="Verdana" font-size="Small" 
                                    Text="Industry"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList id="cmbIndustry" runat="server" width="187px">
                                </asp:DropDownList>
                            </td>
                            <td style="width: 172px">
                                <asp:Label id="Label19" runat="server" font-names="Verdana" font-size="Small" 
                                    Text="Tax Code"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList id="cmbTax" runat="server" width="187px">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="1">
                                &nbsp;</td>
                            <td align="left" colspan="3">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td colspan="1">
                                <asp:Label id="Label25" runat="server" font-names="Verdana" font-size="Small" 
                                    Text="Capture Photo" Visible="False"></asp:Label>
                            </td>
                            <td align="left" colspan="3">
                                <input id="fDocument" runat="server" onclick="return fDocument_onclick()" 
                                    style="width: 266px; height: 26px;" type="file" validationgroup="*.jpg" visible="False" /><asp:Button 
                                    id="Button2" runat="server" Text="Load Image" Visible="False" />
                                <asp:TextBox id="TextBox1" runat="server" Visible="False"></asp:TextBox>
                                <asp:Button id="BtnCapture1" runat="server" Text="Capture" Visible="False" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="1">
                                &nbsp;</td>
                            <td align="left" colspan="3">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td colspan="1">
                                <asp:Label id="Label32" runat="server" font-names="Verdana" font-size="Small" 
                                    Text="Scan id" Visible="False"></asp:Label>
                            </td>
                            <td align="left" colspan="3">
                                <input id="File1" runat="server" onclick="return fDocument_onclick()" 
                                    style="width: 266px; height: 26px;" type="file" validationgroup="*.jpg" visible="False" /><asp:Button 
                                    id="Button3" runat="server" Text="Load Image" Visible="False" />
                                <asp:TextBox id="TextBox8" runat="server" Visible="False"></asp:TextBox>
                                <asp:Button id="BtnCapture" runat="server" Text="Capture" Visible="False" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="1">
                                &nbsp;</td>
                            <td align="left" colspan="3">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td colspan="1">
                                <asp:Label id="Label35" runat="server" font-names="Verdana" font-size="Small" 
                                    Text="Capture Signature" Visible="False"></asp:Label>
                            </td>
                            <td align="left" colspan="3">
                                <input id="File2" runat="server" onclick="return fDocument_onclick()" 
                                    style="width: 266px; height: 26px;" type="file" validationgroup="*.jpg" visible="False" /><asp:Button 
                                    id="Button4" runat="server" Text="Load Image" Visible="False" />
                                <asp:TextBox id="TextBox9" runat="server" Visible="False"></asp:TextBox>
                                <asp:Button id="BtnCapture0" runat="server" Text="Capture" Visible="False" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="1">
                                &nbsp;</td>
                            <td align="left" colspan="3">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td colspan="1">
                                &nbsp;</td>
                            <td align="left" colspan="3">
                                <asp:Image id="Image1" runat="server" />
                                <asp:Image id="Image2" runat="server" />
                                <asp:Image id="Image3" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="1">
                                &nbsp;</td>
                            <td align="left" colspan="3">
                                <asp:Button id="Button1" runat="server" Text="Copy Image" Visible="False" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="1">
                                <asp:TextBox id="TextBox2" runat="server" Visible="False"></asp:TextBox>
                            </td>
                            <td align="left" colspan="3">
                                <asp:TextBox id="TextBox3" runat="server" Visible="False" width="198px"></asp:TextBox>
                                <asp:TextBox id="TextBox10" runat="server" Visible="False" width="198px"></asp:TextBox>
                                <asp:TextBox id="TextBox11" runat="server" Visible="False" width="198px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="4">
                                <asp:Button id="btnSave" runat="server" Text="Save Account" width="96px" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="1">
                                &nbsp;</td>
                            <td align="left" colspan="3">
                                &nbsp;</td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </asp:Panel>
</div>
</asp:Content>

