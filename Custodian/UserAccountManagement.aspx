<%@ Page Language="VB" MasterPageFile="~/CDSUser.master" AutoEventWireup="false" CodeFile="UserAccountManagement.aspx.vb" Inherits="Custodian_UserAccountManagement" title="System Accounts Management" %>

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
        .style6
       {
           width: 150px;
       }
       .style7
       {
           width: 102px;
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
                <td>
                    <asp:Label id="lblsitemap" runat="server"></asp:Label></td>
            </tr>
            <tr>
                <td style="width: 870px" align="center">
                    <asp:Label id="Label4" runat="server" backcolor="#8080FF" font-bold="True" font-names="Arial"
                        Text="Accounts Management" width="1020px"></asp:Label></td>
            </tr>
                <tr>
                    <td colspan ="4" valign="top">
                        <asp:Label id="Label1" runat="server" Text="Shareholder Number:" width="144px" font-names="Verdana" font-size="Small"></asp:Label>
                        <asp:Label id="lblShareholder" runat="server" font-names="Verdana" font-size="Small"></asp:Label></td>
                </tr>
                
            </table>
            <table>
                <tr>
                    <td class="style7">
                        <asp:Label id="Label5" runat="server" Text="Options :" font-names="Verdana" 
                            font-size="Small"></asp:Label></td>
                        <td>
                            <asp:RadioButton id="rdIndividual" runat="server" Text="Create New Account" 
                                font-names="Verdana" font-size="Small" GroupName="Acctype" /></td>
                            <td class="style6">
                                <asp:RadioButton id="rdJoint" runat="server" Text="Update Account" 
                                    font-names="Verdana" font-size="Small" GroupName="Acctype" /></td>
                                <td>
                                    <asp:RadioButton id="rdNominee" runat="server" Text="Access Reports" 
                                        font-names="Verdana" font-size="Small" GroupName="Acctype" /></td>
                                    <td style="width: 141px">
                                        <asp:RadioButton id="rdCompany" runat="server" Text="Company Account" 
                                            font-names="Verdana" font-size="Small" GroupName="Acctype" Visible="False" /></td>
                </tr>
            </table>
            <table>
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
                    <td>
                        <asp:Label id="Label22" runat="server" font-names="Verdana" font-size="Small" 
                            Text="Department"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox id="txtDepartment" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:Label id="Label6" runat="server" font-names="Verdana" font-size="Small" 
                            Text="Role"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList id="cmbRoles" runat="server" autopostback="True" 
                            width="127px">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td style="width: 175px">
                        <asp:Label id="Label20" runat="server" font-names="Verdana" font-size="Small" 
                            Text="Username"></asp:Label>
                    </td>
                        <td>
                            <asp:TextBox id="txtUsername" runat="server"></asp:TextBox>
                    </td>
                            <td style="width: 172px">
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 175px"></td>
                    <td></td>
                    <td style="width: 172px"></td>
                    <td></td>
                </tr>
                <tr>
                    <td colspan ="4"></td>
                </tr>
                <tr>
                    <td style="width: 175px">
                        <asp:Label id="Label7" runat="server" Text="Address:" font-names="Verdana" font-size="Small"></asp:Label></td>
                        <td>
                            <asp:TextBox id="txtAdd1" runat="server"></asp:TextBox></td>
                            <td style="width: 172px"></td>
                            <td>
                                <asp:TextBox id="txtAdd2" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="width: 175px"></td>
                    <td>
                        <asp:TextBox id="txtadd3" runat="server"></asp:TextBox></td>
                        <td style="width: 172px"></td>
                        <td>
                            <asp:TextBox id="txtadd4" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>
                        <asp:Label id="Label24" runat="server" font-names="Verdana" font-size="Small" 
                            Text="Postal Code"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox id="txtpostal" runat="server"></asp:TextBox>
                    </td>
                    <td></td>
                    <td></td>
                </tr>
                <tr>
                    <td style="width: 175px">
                        <asp:Label id="Label8" runat="server" Text="Country" font-names="Verdana" font-size="Small"></asp:Label>
                        <asp:Label id="lblCountry" runat="server"></asp:Label></td>
                        <td>
                            <asp:DropDownList id="cmbCountry" runat="server" width="152px" autopostback="True">
                            </asp:DropDownList></td>
                            <td style="width: 172px">
                                <asp:Label id="Label9" runat="server" Text="City/Town" font-names="Verdana" font-size="Small"></asp:Label></td>
                                <td>
                                    <asp:DropDownList id="CmbCity" runat="server" width="160px" autopostback="True">
                                    </asp:DropDownList></td>
                </tr>
                <tr>
                    <td style="width: 175px">
                        <asp:Label id="Label10" runat="server" Text="Telephone:" font-names="Verdana" font-size="Small"></asp:Label></td>
                        <td>
                            <asp:TextBox id="txtTel" runat="server"></asp:TextBox></td>
                            <td style="width: 172px">
                                <asp:Label id="Label11" runat="server" Text="Cellphone" font-names="Verdana" font-size="Small"></asp:Label></td>
                                <td>
                                    <asp:TextBox id="txtCell" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="width: 175px">
                        <asp:Label id="Label12" runat="server" Text="Email" font-names="Verdana" font-size="Small"></asp:Label></td>
                        <td>
                            <asp:TextBox id="txtEmail" runat="server"></asp:TextBox></td>
                            <td style="width: 172px">
                                <asp:Label id="Label13" runat="server" Text="Fax" font-names="Verdana" font-size="Small"></asp:Label></td>
                                <td>
                                    <asp:TextBox id="txtFax" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>
                        <asp:Label id="Label21" runat="server" font-names="Verdana" font-size="Small" 
                            Text="Broker"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList id="cmbBroker" runat="server" autopostback="True" 
                            width="152px">
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
                            <asp:DropDownList id="cmbBank" runat="server" width="152px" autopostback="True">
                            </asp:DropDownList></td>
                            <td style="width: 172px">
                                <asp:Label id="Label15" runat="server" Text="Branch" font-names="Verdana" font-size="Small"></asp:Label>
                                <asp:Label id="lblBranch" runat="server"></asp:Label></td>
                                <td>
                                    <asp:DropDownList id="cmbBranch" runat="server" width="160px">
                                    </asp:DropDownList></td>
                </tr>
                <tr>
                    <td style="width: 175px">
                        <asp:Label id="Label16" runat="server" Text="Account Number" font-names="Verdana" font-size="Small"></asp:Label></td>
                        <td>
                            <asp:TextBox id="txtBnkAccount" runat="server"></asp:TextBox></td>
                            <td style="width: 172px">
                                <asp:Label id="Label17" runat="server" Text="Account Type" font-names="Verdana" font-size="Small"></asp:Label></td>
                                <td>
                                    <asp:DropDownList id="cmbAccType" runat="server" width="160px">
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
                            <asp:DropDownList id="cmbIndustry" runat="server" width="152px">
                            </asp:DropDownList></td>
                            <td style="width: 172px">
                                <asp:Label id="Label19" runat="server" Text="Tax Code" font-names="Verdana" font-size="Small"></asp:Label></td>
                                <td>
                                    <asp:DropDownList id="cmbTax" runat="server" width="160px">
                                    </asp:DropDownList></td>
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
                        <asp:Image id="Image1" runat="server" width="16px" /></td>
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
                        <asp:Button id="btnSave" runat="server" Text="Save Account" width="96px" /></td>                
                </tr>
            </table>
        </td>
    </tr>
</table>
</asp:Panel>
</div>
</asp:Content>

