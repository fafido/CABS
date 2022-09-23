<%@ Page Language="VB" MasterPageFile="~/CDSUser.master" AutoEventWireup="false" CodeFile="AccountUpdate.aspx.vb" Inherits="CDSMode_AccountUpdate" title="Accounts Update" %>

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
                        Text="Accounts Update" width="848px"></asp:Label></td>
            </tr>
                
            </table>
            <table>
                <tr>
                    <td style="width: 196px">
                        <asp:Label id="Label1" runat="server" font-names="Verdana" font-size="Small" 
                            Text="Shareholder Number:" width="179px"></asp:Label>
                    </td>
                        <td style="width: 3px">
                            <asp:TextBox id="txtshareholderSerch" runat="server" width="323px"></asp:TextBox>
                    </td>
                            <td colspan ="3">
                                <asp:Button id="btnHolderNumSearch" runat="server" Text="&gt;&gt;" />
                    </td>
                                
                </tr>                
                <tr>
                    <td style="width: 196px">
                        <asp:Label id="Label5" runat="server" font-names="Verdana" font-size="Small" 
                            Text="Shareholder Name:"></asp:Label>
                    </td>
                    <td style="width: 3px">
                        <asp:TextBox id="txtSearch" runat="server" width="323px"></asp:TextBox>
                    </td>
                    <td colspan="3">
                        <asp:Button id="btnSearchName" runat="server" Text="&gt;&gt;" />
                    </td>
                    
                </tr>
            </table>
            <table>
                <tr>
                    <td valign="top" align="left" style="width: 195px">
                        <asp:Label id="Label26" runat="server" font-names="Verdana" font-size="Small" 
                            Text="Select Name:"></asp:Label>
                    </td>
                    <td style="width: 148px">
                        <asp:ListBox id="cmbShort" runat="server" Height="47px" width="339px"></asp:ListBox></td>
                        <td>
                            <asp:Image id="Image1" runat="server" /></td>
                </tr>
                <tr>
                    <td style="width: 195px">&nbsp;</td>
                    <td align="right">
                        <asp:Button id="btnSelect" runat="server" Text="Select" /></td>
                </tr>
            </table>
            <table>
                <tr>
                    <td align="center" style="width: 870px">
                        <asp:Label id="Label27" runat="server" backcolor="#8080FF" font-bold="True" 
                            font-names="Arial" Text="Details" width="848px"></asp:Label>
                    </td>
                </tr>
            </table>
            <table>
            <tr>
                <td style="width: 256px">
                    <asp:RadioButton id="rdIndividual" runat="server" font-names="Verdana" font-size="Small" GroupName="HolderTypes" Text="Individual" /></td>
                <td>
                    <asp:RadioButton id="rdJoint" runat="server" font-names="Verdana" font-size="Small" GroupName="HolderTypes" Text="Joint" /></td>
                <td>
                    <asp:RadioButton id="rdNominee" runat="server" font-names="Verdana" font-size="Small" GroupName="HolderTypes" Text="Nominee" /></td>
                <td>
                    <asp:RadioButton id="rdCompany" runat="server" font-names="Verdana" font-size="Small" GroupName="HolderTypes" Text="Company" /></td>
            </tr>
             <tr>
                    <td colspan ="1" style="width: 256px">
                        <asp:Label id="Label20" runat="server" Text="Shareholder Number:" font-names="Verdana" font-size="Small"></asp:Label></td>
                        <td colspan="3">
                            <asp:TextBox id="txtShareholder" runat="server" font-bold="True" 
                                ReadOnly="True" width="437px"></asp:TextBox></td>
                            
                </tr>
                <tr>
                    <td colspan ="1" style="width: 256px">
                        <asp:Label id="Label2" runat="server" Text="Surname" font-names="Verdana" font-size="Small"></asp:Label></td>
                        <td colspan="1" style="width: 203px">
                            <asp:TextBox id="txtSurname" runat="server" TextMode="MultiLine" Width="180px"></asp:TextBox></td>
                            <td colspan ="1" style="width: 194px">
                                <asp:Label id="Label3" runat="server" Text="Fornames" font-names="Verdana" font-size="Small"></asp:Label></td>
                                <td colspan ="1" style="width: 316px">
                                    <asp:TextBox id="txtforenames" runat="server" TextMode="MultiLine" Width="180px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="width: 256px">
                        <asp:Label id="Label6" runat="server" Text="ID Number" font-names="Verdana" font-size="Small"></asp:Label></td>
                        <td>
                            <asp:TextBox id="txtID" runat="server" Width="180px"></asp:TextBox></td>
                            <td style="width: 194px">
                                <asp:Label id="Label22" runat="server" font-names="Verdana" font-size="Small" Text="DOB"></asp:Label></td>
                            <td>
                                <BDP:BasicDatePicker id="BasicDatePicker1" runat="server">
                                </BDP:BasicDatePicker>
                            </td>
                </tr>
                <tr>
                    <td style="width: 256px">
                        <asp:Label ID="Label7" runat="server" font-names="Verdana" font-size="Small" Text="Address:"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtAdd1" runat="server" Width="180px" TextMode="MultiLine"></asp:TextBox>
                    </td>
                    <td style="width: 194px"></td>
                    <td>
                        <asp:TextBox ID="txtAdd2" runat="server" Width="180px" TextMode="MultiLine"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="width: 256px">
                        <asp:Label ID="Label23" runat="server" font-names="Verdana" font-size="Small" Text="Address:"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtadd3" runat="server" Width="180px" TextMode="MultiLine"></asp:TextBox>
                    </td>
                    <td style="width: 194px"></td>
                    <td>
                        <asp:TextBox ID="txtadd4" runat="server" Width="180px" TextMode="MultiLine"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="width: 256px; height: 16px;">
                        &nbsp;</td>
                        <td colspan="3">
                            &nbsp;</td>
                            
                                </td>
                </tr>
              
                <tr>
                    <td style="width: 256px">
                        <asp:Label id="Label8" runat="server" Text="Country" font-names="Verdana" font-size="Small"></asp:Label>
                        <asp:Label id="lblCountry" runat="server"></asp:Label></td>
                        <td>
                            <asp:DropDownList id="cmbCountry" runat="server" width="200px" 
                                autopostback="True" Height="22px">
                            </asp:DropDownList></td>
                            <td style="width: 194px">
                                <asp:Label id="Label9" runat="server" Text="City/Town" font-names="Verdana" font-size="Small"></asp:Label></td>
                                <td>
                                    <asp:DropDownList id="CmbCity" runat="server" width="200px">
                                    </asp:DropDownList></td>
                </tr>
                <tr>
                    <td style="width: 256px">
                        <asp:Label id="Label10" runat="server" Text="Telephone:" font-names="Verdana" font-size="Small"></asp:Label></td>
                        <td>
                            <asp:TextBox id="txtTel" runat="server" Width="180px"></asp:TextBox></td>
                            <td style="width: 194px">
                                <asp:Label id="Label11" runat="server" Text="Cellphone" font-names="Verdana" font-size="Small"></asp:Label></td>
                                <td>
                                    <asp:TextBox id="txtCell" runat="server" Width="180px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="width: 256px">
                        <asp:Label id="Label12" runat="server" Text="Email" font-names="Verdana" font-size="Small"></asp:Label></td>
                        <td>
                            <asp:TextBox id="txtEmail" runat="server" Width="180px"></asp:TextBox></td>
                            <td style="width: 194px">
                                <asp:Label id="Label13" runat="server" Text="Fax" font-names="Verdana" font-size="Small"></asp:Label></td>
                                <td>
                                    <asp:TextBox id="txtFax" runat="server" Width="180px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="width: 256px">
                        <asp:CheckBox id="chkBank" runat="server" Text="Add Banking Details" 
                            font-names="Verdana" font-size="Small" width="168px" autopostback="True" /></td>
                    <td></td>
                    <td style="width: 194px"></td>
                    <td>
                        <asp:CheckBox id="ChkRemoveBank" runat="server" autopostback="True" font-names="Arial"
                            font-size="Small" Text="Remove Banking Details" /></td>
                </tr>
                <tr>
                    <td style="width: 256px">
                        <asp:Label id="Label14" runat="server" Text="Bank" font-names="Verdana" font-size="Small"></asp:Label>
                        <asp:Label id="lblBank" runat="server"></asp:Label></td>
                        <td>
                            <asp:DropDownList id="cmbBank" runat="server" width="144px" autopostback="True">
                            </asp:DropDownList></td>
                            <td style="width: 194px">
                                <asp:Label id="Label15" runat="server" Text="Branch" font-names="Verdana" font-size="Small"></asp:Label>
                                <asp:Label id="lblBranch" runat="server" width="56px"></asp:Label></td>
                                <td>
                                    <asp:DropDownList id="cmbBranch" runat="server" width="144px">
                                    </asp:DropDownList></td>
                </tr>
                <tr>
                    <td style="width: 256px">
                        <asp:Label id="Label16" runat="server" Text="Account Number" font-names="Verdana" font-size="Small"></asp:Label></td>
                        <td>
                            <asp:TextBox id="txtBnkAccount" runat="server"></asp:TextBox></td>
                            <td style="width: 194px">
                                <asp:Label id="Label17" runat="server" Text="Account Type" font-names="Verdana" font-size="Small"></asp:Label></td>
                                <td>
                                    <asp:DropDownList id="cmbAccType" runat="server" width="144px">
                                    </asp:DropDownList></td>
                </tr>
                <tr>
                    <td style="width: 256px"></td>
                    <td></td>
                    <td style="width: 194px"></td>
                    <td></td>
                </tr>
                <tr>
                    <td style="width: 256px">
                        <asp:Label id="Label18" runat="server" Text="Industry" font-names="Verdana" font-size="Small"></asp:Label></td>
                        <td>
                            <asp:DropDownList id="cmbIndustry" runat="server" width="144px">
                            </asp:DropDownList></td>
                            <td style="width: 194px">
                                <asp:Label id="Label19" runat="server" Text="Tax Code" font-names="Verdana" font-size="Small"></asp:Label></td>
                                <td>
                                    <asp:DropDownList id="cmbTax" runat="server" width="144px">
                                    </asp:DropDownList></td>
                </tr>
                <tr>
                    <td style="width: 256px">
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
                <td colspan ="1" style="width: 256px">
                    &nbsp;</td>
                    <tr>

                        <td>
                            <asp:Label ID="Label28" runat="server" font-names="Verdana" font-size="Small" Text="Document type"></asp:Label>
                        </td>
                        <td>
                            <asp:RadioButton ID="rdPhoto" runat="server" AutoPostBack="True" GroupName="Attachments" Text="Photo" />
                            <asp:RadioButton ID="rdID" runat="server" AutoPostBack="True" GroupName="Attachments" Text="ID" />
                            <asp:RadioButton ID="rdOther" runat="server" AutoPostBack="True" GroupName="Attachments" Text="Other" />
                        </td>
                        <td></td>
                        <td>
                            <asp:TextBox ID="txtOther" runat="server" Visible="False" Width="180px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label25" runat="server" font-names="Verdana" font-size="Small" Text="Account Attachments"></asp:Label>
                        </td>
                        <td align="left" colspan="3">
                            <asp:FileUpload ID="fileuploadImage" runat="server" />
                            <asp:Button ID="Button2" runat="server" Text="Save Attachments" />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 256px">&nbsp;</td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td align="center" colspan="4">
                            <asp:GridView ID="imgGrid" runat="server" AutoGenerateColumns="False" AutoGenerateSelectButton="True" CellPadding="4" EnableModelValidation="True" ForeColor="#333333" GridLines="None" Width="384px">
                                <RowStyle BackColor="#E3EAEB" />
                                <Columns>
                                    <asp:BoundField DataField="document_Type" HeaderText="Document Type" />
                                    <asp:ImageField DataImageUrlField="Image_data" HeaderText="Image">
                                        <ControlStyle Height="150px" Width="100px" />
                                    </asp:ImageField>
                                    <asp:BoundField DataField="id" HeaderText="ID">
                                    <ControlStyle Height="0px" Width="0px" />
                                    </asp:BoundField>
                                </Columns>
                                <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                                <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                                <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                                <EditRowStyle BackColor="#7C6F57" />
                                <AlternatingRowStyle BackColor="White" />
                            </asp:GridView>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 256px">
                            <asp:TextBox ID="TextBox2" runat="server" Visible="False"></asp:TextBox>
                        </td>
                        <td></td>
                        <td></td>
                        <td>
                            <asp:Button ID="Button1" runat="server" Text="Copy Image" Visible="False" />
                        </td>
                    </tr>
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

