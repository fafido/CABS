<%@ Page Language="VB" MasterPageFile="~/CDSUser.master" AutoEventWireup="false" CodeFile="TransferToLandingPool.aspx.vb" Inherits="Pledges_TransferToLandingPool" title="Deposit Securities" %>
<%@ Register assembly="BasicFrame.WebControls.BasicDatePicker" namespace="BasicFrame.WebControls" tagprefix="BDP" %>
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
                        Text="Transfer To Landing Pool" width="848px"></asp:Label></td>
            </tr>
                            <tr>
                    <td valign="top">
                        &nbsp;</td>
                </tr>
                
                <tr>
                    <td valign="top">
                        &nbsp;</td>
                </tr>
                
            </table>
            <table>
                <tr>
                    <td style="width: 128px">
                        <asp:Label id="Label1" runat="server" font-names="Verdana" font-size="Small" 
                            Text="Security" width="144px"></asp:Label>
                    </td>
                        <td style="width: 3px">
                            <asp:DropDownList id="cmbSecurityType" runat="server" autopostback="True" 
                                width="142px">
                            </asp:DropDownList>
                    </td>
                            <td style="width: 3px">
                                &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                    <td style="width: 141px">
                                        &nbsp;</td>
                </tr>                
                <tr>
                    <td style="width: 128px">
                        <asp:Label id="Label5" runat="server" font-names="Verdana" font-size="Small" 
                            Text="Shareholder Name:"></asp:Label>
                    </td>
                    <td style="width: 3px">
                        <asp:TextBox id="txtSearch" runat="server" width="144px"></asp:TextBox>
                    </td>
                    <td style="width: 3px">
                        <asp:Button id="btnSearchName" runat="server" Text="&gt;&gt;" />
                    </td>
                    <td>
                    </td>
                    <td style="width: 141px">
                    </td>
                </tr>
            </table>
            <table>
                <tr>
                    <td style="width: 135px"></td>
                    <td style="width: 148px">
                        <asp:ListBox id="lstNames" runat="server" Height="62px" width="277px" 
                            style="margin-left: 10px" AutoPostBack="True"></asp:ListBox></td>
                </tr>
                <tr>
                    <td style="width: 135px"></td>
                    <td align="right">
                        <asp:Button id="btnSelect" runat="server" Text="Select" Visible="False" /></td>
                </tr>
                <tr>
                    <td style="width: 135px"></td>
                    <td>
                        <asp:Label id="lblShareholder" runat="server"></asp:Label>
                        </td>
                </tr>
            </table>
            <table >
                <tr>
                    <td colspan ="2" style="width: 140px">
                        <asp:Label ID="Label17" runat="server" Text="Counter"></asp:Label>
                    </td>
                    <td colspan ="2">
                        <asp:DropDownList ID="cmbCounter" runat="server" AutoPostBack="True" 
                            Width="164px">
                        </asp:DropDownList>
                    </td>
                    <td colspan ="2" style="width: 95px"></td>
                    <td colspan ="2">
                        &nbsp;</td>
                    <td colspan ="2">
                        &nbsp;</td>
                    <td colspan ="2"></td>
                </tr>
                  <tr>
                    <td colspan ="2" style="width: 140px">
                        
                        <asp:Label ID="Label19" runat="server" Text="Shares Quantity"></asp:Label>
                        
                        <asp:Label ID="Label20" runat="server" Text="Asset"></asp:Label>
                        
                    </td>
                    <td colspan ="2">
                        
                        <asp:TextBox ID="txtSharesTrans" runat="server" Width="162px"></asp:TextBox>
                        
                        <asp:TextBox ID="txtAssetType" runat="server" Width="163px"></asp:TextBox>
                        
                    </td>
                    <td colspan ="2" style="width: 95px"></td>
                    <td colspan ="2">
                        
                        <asp:Label ID="Label18" runat="server" Text="Share Price"></asp:Label>
                        <asp:Label ID="Label21" runat="server" Text="Asset Value"></asp:Label>
                        
                    </td>
                    <td colspan ="2">
                       
                        <asp:TextBox ID="txtSharePrice" runat="server"></asp:TextBox>
                       
                    </td>
                    <td colspan ="2"></td>
                </tr>
                <tr>
                    <td colspan ="2" style="width: 140px">
                        
                        &nbsp;</td>
                    <td colspan ="2">
                        
                        &nbsp;</td>
                    <td colspan ="2" style="width: 95px"></td>
                    <td colspan ="2">
                        
                        <asp:Label ID="Label23" runat="server" Text="Lending Expiration"></asp:Label>
                        
                    </td>
                    <td colspan ="2">
                       
                        <BDP:BasicDatePicker ID="ReturnDueDate" runat="server" ReadOnly="True" 
                            width="180px">
                        </BDP:BasicDatePicker>
                       
                    </td>
                    <td colspan ="2"></td>
                </tr>
                <tr>
                    <td colspan ="2" style="width: 140px">
                        
                        <asp:Label ID="Label22" runat="server" Text="Asset Description"></asp:Label>
                        
                    </td>
                    <td colspan ="2">
                        
                        <asp:TextBox ID="txtAssetDescr" runat="server" TextMode="MultiLine" 
                            Width="161px"></asp:TextBox>
                        
                    </td>
                    <td colspan ="2" style="width: 95px"></td>
                    <td colspan ="2">
                        
                        &nbsp;</td>
                    <td colspan ="2">
                       
                        &nbsp;</td>
                    <td colspan ="2"></td>
                </tr>
            </table>
            <table>
                <tr>
                    <td colspan ="1" style="width: 198px; height: 26px;">
                        <asp:Label id="Label2" runat="server" Text="Surname" font-names="Verdana" 
                            font-size="Small" Visible="False"></asp:Label></td>
                        <td colspan="1" style="width: 203px; height: 26px;">
                            <asp:TextBox id="txtSurname" runat="server" Height="18px" ReadOnly="True" 
                                width="256px" Visible="False"></asp:TextBox></td>
                            <td colspan ="1" style="width: 172px; height: 26px;">
                                </td>
                                <td colspan ="1" style="width: 316px; height: 26px;">
                                    </td>
                </tr>
                <tr>
                    <td style="width: 198px">
                        <asp:Label id="Label6" runat="server" Text="id Number" font-names="Verdana" 
                            font-size="Small" Visible="False"></asp:Label></td>
                        <td>
                            <asp:TextBox id="txtID" runat="server" ReadOnly="True" width="253px" 
                                Visible="False"></asp:TextBox></td>
                            <td>
                            </td>
                            <td></td>
                </tr>
                <tr>
                    <td style="width: 198px">
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                    <td></td>
                    <td></td>
                </tr>
                <tr>
                    <td style="width: 198px; height: 35px;">
                        &nbsp;</td>
                        <td style="height: 35px">
                            &nbsp;</td>
                            <td style="height: 35px"></td>
                            <td style="height: 35px">
                                </td>
                </tr>
                <tr>
                    <td style="width: 198px">
                        &nbsp;</td>
                        <td>
                            <asp:Button id="Button1" runat="server" Text="Save" />
                    </td>
                            <td>
                                </td>
                                <td>
                                    </td>
                </tr>
                <tr>
                    <td style="width: 198px">
                        &nbsp;</td>
                        <td>
                            &nbsp;</td>
                            <td>
                                </td>
                                <td>
                                    </td>
                </tr>
                
          
                
            </table>
    
        </td>
    </tr>
</table>
</asp:Panel>
</div>
</asp:Content>

