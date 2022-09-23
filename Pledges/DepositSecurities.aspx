<%@ Page Language="VB" MasterPageFile="~/CDSUser.master" AutoEventWireup="false" CodeFile="DepositSecurities.aspx.vb" Inherits="Pledges_DepositSecurities" title="Deposit Securities" %>
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
                        Text="Securities Pledge" width="848px"></asp:Label></td>
            </tr>
                            <tr>
                    <td valign="top">
                        <asp:Label id="Label17" runat="server" font-size="Medium" Text="Holder Details"></asp:Label>
                                </td>
                </tr>
                
                <tr>
                    <td valign="top">
                        &nbsp;</td>
                </tr>
                
            </table>
            <table>
                <tr>
                    <td style="width: 167px">
                        <asp:Label id="Label1" runat="server" font-names="Verdana" font-size="Small" 
                            Text="C . D . S  Number:" width="144px"></asp:Label>
                    </td>
                        <td style="width: 3px">
                            <asp:TextBox id="txtshareholder" runat="server"></asp:TextBox>
                    </td>
                            <td style="width: 3px">
                                <asp:Button id="btnHolderNumSearch" runat="server" Text="&gt;&gt;" />
                    </td>
                                <td>
                                    &nbsp;</td>
                                    <td style="width: 141px">
                                        &nbsp;</td>
                </tr>                
                <tr>
                    <td style="width: 167px">
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
                    <td style="width: 166px"></td>
                    <td style="width: 148px">
                        <asp:ListBox id="lstNames" runat="server" Height="62px" width="277px"></asp:ListBox></td>
                </tr>
                <tr>
                    <td style="width: 166px"></td>
                    <td align="right">
                        <asp:Button id="btnSelect" runat="server" Text="Select" /></td>
                </tr>
                <tr>
                    <td style="width: 166px"></td>
                    <td>
                        </td>
                </tr>
            </table>
            <table>
                <tr>
                    <td colspan ="1" style="width: 192px; height: 26px;">
                        <asp:Label id="Label2" runat="server" Text="Surname" font-names="Verdana" font-size="Small"></asp:Label></td>
                        <td colspan="1" style="width: 203px; height: 26px;">
                            <asp:TextBox id="txtSurname" runat="server" Height="18px" ReadOnly="True" 
                                width="272px"></asp:TextBox></td>
                            <td colspan ="1" style="width: 172px; height: 26px;">
                                </td>
                                <td colspan ="1" style="width: 316px; height: 26px;">
                                    </td>
                </tr>
                <tr>
                    <td style="width: 192px">
                        <asp:Label id="Label6" runat="server" Text="id Number" font-names="Verdana" font-size="Small"></asp:Label></td>
                        <td>
                            <asp:TextBox id="txtID" runat="server" ReadOnly="True" width="272px"></asp:TextBox></td>
                            <td>
                            </td>
                            <td></td>
                </tr>
                <tr>
                    <td style="width: 192px"></td>
                    <td></td>
                    <td></td>
                    <td></td>
                </tr>
                <tr>
                    <td style="width: 192px; height: 35px;">
                        <asp:Label id="Label7" runat="server" Text="Address:" font-names="Verdana" font-size="Small"></asp:Label></td>
                        <td style="height: 35px">
                            <asp:TextBox id="txtAdd1" runat="server" Height="45px" width="272px" 
                                ReadOnly="True" TextMode="MultiLine"></asp:TextBox></td>
                            <td style="height: 35px"></td>
                            <td style="height: 35px">
                                </td>
                </tr>
                <tr>
                    <td style="width: 192px">
                        <asp:Label id="Label14" runat="server" Text="Security Type:"></asp:Label></td>
                        <td>
                            <asp:DropDownList id="cmbSecurities" runat="server" width="150px">
                            </asp:DropDownList></td>
                            <td>
                                </td>
                                <td>
                                    </td>
                </tr>
                <tr>
                    <td style="width: 192px">
                        <asp:Label id="Label16" runat="server" Text="Counter"></asp:Label></td>
                        <td>
                            <asp:DropDownList id="cmbCompany" runat="server" width="150px" autopostback="True">
                            </asp:DropDownList></td>
                            <td>
                                </td>
                                <td>
                                    </td>
                </tr>
                
                <tr>
                    <td style="width: 192px">
                        <asp:Label id="Label3" runat="server" Text="Account Balance:"></asp:Label></td>
                        <td>
                            <asp:TextBox id="txtBalance" runat="server" ReadOnly="True"></asp:TextBox></td>
                            <td>
                                </td>
                                <td>
                                    </td>
                </tr>
                <tr>
                    <td style="width: 192px; height: 26px;">
                        Pledge Units</td>
                    <td style="height: 26px" colspan="3">
                        <asp:TextBox id="txtPledge" runat="server"></asp:TextBox>&nbsp;
                        <asp:CheckBox id="CheckBox1" runat="server" 
                            Text="Pledge with Income/Entitlements" />
                    </td>
                </tr>
                <tr>
                    <td valign="top" style="width: 192px; height: 21px;">
                        <asp:Label id="Label8" runat="server" Text="Pledge Details"></asp:Label></td>
                        <td style="height: 21px">
                            <asp:TextBox id="txtPledgeReason" runat="server" Height="45px" 
                                TextMode="MultiLine" width="272px"></asp:TextBox></td>
                            <td style="height: 21px">
                                </td>
                                <td style="height: 21px">
                                    </td>
                </tr>
                
            </table>
            <table>
            <tr>
                    <td style="width: 850px" align="center" colspan="2">
                        <asp:GridView id="GdStatisticsView" runat="server" Height="48px" width="832px">
                            <RowStyle font-names="Verdana" font-size="Small" HorizontalAlign="Left" />
                            <HeaderStyle font-bold="True" font-names="Calibri" font-size="Medium" Font-Underline="True"
                                forecolor="#0000C0" HorizontalAlign="Left" />
                            <EditRowStyle HorizontalAlign="Left" />
                        </asp:GridView>
                    </td>                
                </tr>
                <tr>
                    <td style="width: 850px; height: 23px;" align="center" colspan="2">
                        &nbsp;</td>                
                </tr>
                <tr>
                    <td align="center" style="width: 850px" colspan="2">
                       <hr /></td>
                </tr>
                <tr>
                    <td align="left" style="width: 850px" colspan="2">
                        <asp:Label id="Label18" runat="server" font-size="Medium" 
                            Text="Pledgee Details"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="left" colspan="2" style="width: 850px">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td align="left" style="width: 850px" colspan="2">
                        </td>
                </tr>
                <tr>
                    <td align="left" style="width: 214px">
                        Full Name</td>
                    <td align="left" style="width: 850px">
                        <asp:TextBox id="txtPledge0" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td valign="TOP" align="left" style="width: 214px">
                        Address</td>
                    <td align="left" style="width: 850px">
                        <asp:TextBox id="txtPledge1" runat="server" Height="58px" TextMode="MultiLine"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="left" style="width: 214px">
                        Telephone</td>
                    <td align="left" style="width: 850px">
                        <asp:TextBox id="txtPledge2" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="left" style="width: 214px">
                        Mobile</td>
                    <td align="left" style="width: 850px">
                        <asp:TextBox id="txtPledge3" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="left" style="width: 214px">
                        Email</td>
                    <td align="left" style="width: 850px">
                        <asp:TextBox id="txtPledge4" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="left" style="width: 214px">
                        Contact Person</td>
                    <td align="left" style="width: 850px">
                        <asp:TextBox id="txtPledge5" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="left" style="width: 214px">
                        &nbsp;</td>
                    <td align="left" style="width: 850px">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td align="left" style="width: 214px">
                        &nbsp;</td>
                    <td align="left" style="width: 850px">
                        <asp:Button id="Button1" runat="server" Text="Scan and Upload Doc" />
                        &nbsp;&nbsp;
                        <asp:Button id="btnSave" runat="server" Text="Save" width="96px" />
                    </td>
                </tr>
                <tr>
                    <td align="left" style="width: 214px">
                        &nbsp;</td>
                    <td align="left" style="width: 850px">
                        &nbsp;</td>
                </tr>
            </table>
        </td>
    </tr>
</table>
</asp:Panel>
</div>
</asp:Content>

