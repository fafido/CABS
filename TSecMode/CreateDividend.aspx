<%@ Page Language="VB" MasterPageFile="~/CDSUser.master" AutoEventWireup="false" CodeFile="CreateDividend.aspx.vb" Inherits="TsecMode_CreateDividend" title="CDS Capture" %>
<%@ Register Assembly="BasicFrame.WebControls.BasicDatePicker" Namespace="BasicFrame.WebControls" TagPrefix="BDP" %>
<asp:Content id="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
    <asp:Panel id="Panel1" runat="server" width="869px">
    
<table style="border-right: #000033 thin solid; border-top: #000033 thin solid; border-left: #000033 thin solid; width: 832px; border-bottom: #000033 thin solid; background-color: #ffffff">
    <tr>
        <td style="width: 634px; height: 226px" valign="top">
            <table>
            <tr>
                <td>
                    <asp:Label id="lblsitemap" runat="server"></asp:Label></td>
            </tr>
            <tr>
                <td style="width: 870px" align="center">
                    <asp:Label id="Label4" runat="server" backcolor="#8080FF" font-bold="True" font-names="Arial"
                        Text="Dividend Cheque Numbers Creation" width="846px" Height="19px"></asp:Label></td>
            </tr>
           
                
            </table>
            <table style="left: 0px; position: relative; top: 0px">
    <tr>
    <td align="center" style="width: 664px">
    
  <table>
          <tr>
                <td class ="LayoutFormat">
                    <table>     
            <tr>
                    <td colspan ="6"></td>

            </tr>
                        <tr>
                            <td colspan ="1" class="style2">
                <asp:Label ID="Label35" runat="server" Text="Company"></asp:Label></td>
                            <td colspan ="1">
                                <asp:DropDownList ID="CMBCOMPANY" runat="server" AutoPostBack="True" 
                                    Width="245px">
                                </asp:DropDownList>
                                <asp:Label ID="lblFullCompany" runat="server"></asp:Label>
                            </td>
                            <td colspan ="1"></td>
                            <td colspan ="1" class="style1">
                <asp:Label ID="Label1" runat="server" Text="Div Number"></asp:Label></td>
                            <td colspan ="1">
                                &nbsp;</td>
                            <td colspan ="1">
                                <asp:TextBox ID="txtDivno" runat="server" Width="245px"></asp:TextBox>
                            </td>
                        </tr>
                         <tr>
                            <td colspan ="1" class="style2">
                <asp:Label ID="Label3" runat="server" Text="Dividend Type"></asp:Label></td>
                            <td colspan ="1">
                                <asp:DropDownList ID="cmbDivType" runat="server" AutoPostBack="True" 
                                    Width="245px">
                                </asp:DropDownList>
                                <asp:Label ID="lblDivType" runat="server"></asp:Label>
                            </td>
                            <td colspan ="1"></td>
                            <td colspan ="1" class="style1">
                <asp:Label ID="Label5" runat="server" Text="Date Declared"></asp:Label></td>
                            <td colspan ="1">
                                &nbsp;</td>
                            <td colspan ="1">
                                <BDP:BasicDatePicker ID="txtDateDeclared" runat="server">
                                </BDP:BasicDatePicker>
                             </td>
                        </tr>
                         <tr>
                            <td colspan ="1" class="style2">
                <asp:Label ID="Label7" runat="server" Text="Date Closed"></asp:Label></td>
                            <td colspan ="1">
                                <BDP:BasicDatePicker ID="txtDateClosed" runat="server">
                                </BDP:BasicDatePicker>
                            </td>
                            <td colspan ="1"></td>
                            <td colspan ="1" class="style1">
                <asp:Label ID="Label9" runat="server" Text="Payment Date"></asp:Label></td>
                            <td colspan ="1">
                                &nbsp;</td>
                            <td colspan ="1">
                                <BDP:BasicDatePicker ID="txtPaymentDate" runat="server">
                                </BDP:BasicDatePicker>
                            </td>
                        </tr>
                         <tr>
                            <td colspan ="1" class="style2">
                <asp:Label ID="Label11" runat="server" Text="Rate per share"></asp:Label></td>
                            <td colspan ="1">
                                <asp:TextBox ID="txtRatepershare" runat="server" Width="245px"></asp:TextBox>
                            </td>
                            <td colspan ="1"></td>
                            <td colspan ="1" class="style1"></td>
                            <td colspan ="1">
                                &nbsp;</td>
                            <td colspan ="1">
                                &nbsp;</td>
                        </tr>
                         <tr>
                            <td colspan ="1" class="style2">
                <asp:Label ID="Label13" runat="server" Text="Message (1)"></asp:Label></td>
                            <td colspan ="1">
                                <asp:TextBox ID="txtComments1" runat="server" Height="63px" 
                                    TextMode="MultiLine" Width="245px"></asp:TextBox>
                            </td>
                            <td colspan ="1"></td>
                            <td colspan ="1" class="style1">
                <asp:Label ID="Label15" runat="server" Text="Message (2)"></asp:Label></td>
                            <td colspan ="1">
                                &nbsp;</td>
                            <td colspan ="1">
                                <asp:TextBox ID="txtComments2" runat="server" Height="63px" 
                                    TextMode="MultiLine" Width="245px"></asp:TextBox>
                             </td>
                        </tr>
                         
                        <tr>
                            <td colspan ="1" class="style2">
                <asp:Label ID="Label37" runat="server" Text="Comments"></asp:Label></td>
                            <td colspan ="1">
                                <asp:TextBox ID="txtComments3" runat="server" Height="63px" 
                                    TextMode="MultiLine" Width="245px"></asp:TextBox>
                             </td>
                            <td colspan ="1"></td>
                            <td colspan ="1" class="style1"></td>
                            <td colspan ="1"></td>
                            <td colspan ="1"></td>
                        </tr>
                        <tr>
                            <td colspan ="1" class="style2">
                <asp:Label ID="Label23" runat="server" Text="EFT"></asp:Label></td>
                            <td colspan ="1">
                                <asp:CheckBox ID="chkEft" runat="server" Text="EFT Data Only" 
                                    AutoPostBack="True" />
                                <asp:CheckBox ID="chkEft0" runat="server" Text="EFT and Names Data" 
                                    AutoPostBack="True" />
                            </td>
                            <td colspan ="1"></td>
                            <td colspan ="1" class="style1"></td>
                            <td colspan ="1"></td>
                            <td colspan ="1"></td>
                        </tr>
                        <tr>
                            <td colspan ="1" class="style2">
                <asp:Label ID="Label38" runat="server" Text="Bank"></asp:Label></td>
                            <td colspan ="1">
                                <asp:DropDownList ID="cmbBank" runat="server" AutoPostBack="True" 
                                    Width="245px" Enabled="False">
                                </asp:DropDownList>
                            </td>
                            <td colspan ="1"></td>
                            <td colspan ="1" class="style1">
                <asp:Label ID="Label39" runat="server" Text="Branch"></asp:Label></td>
                            <td colspan ="1"></td>
                            <td colspan ="1">
                                <asp:DropDownList ID="cmbBranch" runat="server" AutoPostBack="True" 
                                    Width="245px" Enabled="False">
                                </asp:DropDownList>
                            </td>
                        </tr>
                         <tr>
                            <td colspan ="1" class="style2">
                                &nbsp;</td>
                            <td colspan ="1">
                                &nbsp;</td>
                            <td colspan ="1"></td>
                            <td colspan ="1" class="style1">
                <asp:Label ID="Label36" runat="server" Text="Account No."></asp:Label></td>
                            <td colspan ="1">
                                &nbsp;</td>
                            <td colspan ="1">
                                <asp:TextBox ID="txtAccount" runat="server" Width="245px" Enabled="False"></asp:TextBox>
                             </td>
                        </tr>
                        <tr>
                                <td colspan ="1">&nbsp;</td>
                            <td colspan ="1">
                                <asp:CheckBox ID="chkDivSub" runat="server" Text="Run dividend with sub accounts" />
                                </td>
                            <td colspan ="1"></td>
                            <td colspan ="1"></td>
                            <td colspan ="1"></td>
                            <td colspan ="1"></td>

                        </tr>
                         <tr>
                            <td colspan ="1" class="style2">
                <asp:Label ID="Label17" runat="server" Text="Scrip"></asp:Label></td>
                            <td colspan ="1">
                                <asp:CheckBox ID="chkScrip" runat="server" Text="Scrip" />
                            </td>
                            <td colspan ="1"></td>
                            <td colspan ="1" class="style1"></td>
                            <td colspan ="1">
                                &nbsp;</td>
                            <td colspan ="1">
                                &nbsp;</td>
                        </tr>
                         <tr>
                            <td colspan ="1" class="style2">
                <asp:Label ID="Label19" runat="server" Text="Scrip Price"></asp:Label></td>
                            <td colspan ="1">
                                <asp:TextBox ID="txtScripPrice" runat="server" Width="245px"></asp:TextBox>
                            </td>
                            <td colspan ="1"></td>
                            <td colspan ="1" class="style1">
                <asp:Label ID="Label21" runat="server" Text="Scrip Rounding"></asp:Label></td>
                            <td colspan ="1">
                                &nbsp;</td>
                            <td colspan ="1">
                                <asp:DropDownList ID="cmbScriptRound" runat="server" AutoPostBack="True" 
                                    Width="168px">
                                </asp:DropDownList>
                             </td>
                        </tr>
                        <tr>
                                
                            <td colspan ="6" style ="text-align:center;">        <asp:Button ID="Button1" 
                                    runat="server"  Text="Save" BackColor="#E0E0E0" BorderColor="Black" 
                                    BorderStyle="Solid" CausesValidation="False" Width="72px" 
                                    UseSubmitBehavior="False" Height="25px" TabIndex="21" />
                    </td>

                        </tr>
                    
                    </table>

                </td>

          </tr>

    </table>
    
    </td>
    </tr>
    <tr>
    <td style="width: 664px">
    <br />
    </td>
    </tr>
    <tr>
    <td style="width: 664px">
        &nbsp;</td>
    </tr>
    <tr>
    <td style="width: 664px">
        &nbsp;</td>
    </tr>
    <tr>
    <td style="width: 664px">
        &nbsp;</td>
    </tr>
    </table>
        </td>
    </tr>
</table>
</asp:Panel>
</div>
</asp:Content>

