<%@ Page Language="VB" MasterPageFile="~/TSec.master" AutoEventWireup="false" CodeFile="DepositSecurities.aspx.vb" Inherits="TSecPledges_DepositSecurities" title="Deposit Securities" %>
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
                        Text="Deposit Securities" width="848px"></asp:Label></td>
            </tr>
                            <tr>
                    <td colspan ="4" valign="top">
                        <asp:Label id="Label1" runat="server" Text="C . D . S  Number:" width="144px" font-names="Verdana" font-size="Small"></asp:Label>
                        <asp:TextBox id="txtshareholder" runat="server"></asp:TextBox>
                        <asp:Button id="btnHolderNumSearch" runat="server" Text=">>" /></td>
                </tr>
                
            </table>
            <table>
                <tr>
                    <td style="width: 146px">
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
                        <asp:ListBox id="lstNames" runat="server" Height="136px" width="328px"></asp:ListBox></td>
                </tr>
                <tr>
                    <td></td>
                    <td align="center">
                        <asp:Button id="btnSelect" runat="server" Text="Select" /></td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        </td>
                </tr>
            </table>
            <table>
                <tr>
                    <td colspan ="1" style="width: 192px; height: 26px;">
                        <asp:Label id="Label2" runat="server" Text="Surname" font-names="Verdana" font-size="Small"></asp:Label></td>
                        <td colspan="1" style="width: 203px; height: 26px;">
                            <asp:TextBox id="txtSurname" runat="server" Height="40px" ReadOnly="True" TextMode="MultiLine" width="272px"></asp:TextBox></td>
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
                            <asp:TextBox id="txtAdd1" runat="server" Height="80px" width="344px" ReadOnly="True" TextMode="MultiLine"></asp:TextBox></td>
                            <td style="height: 35px"></td>
                            <td style="height: 35px">
                                </td>
                </tr>
                <tr>
                    <td style="width: 192px"></td>
                    <td>
                        &nbsp;</td>
                        <td></td>
                        <td>
                            </td>
                </tr>
                <tr>
                    <td style="width: 192px">
                        </td>
                    <td>
                        </td>
                    <td></td>
                    <td></td>
                </tr>
                <tr>
                    <td style="width: 192px">
                        <asp:Label id="Label14" runat="server" Text="Security Type:"></asp:Label></td>
                        <td>
                            <asp:DropDownList id="cmbSecurities" runat="server" width="152px">
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
                            <asp:DropDownList id="cmbCompany" runat="server" width="152px" autopostback="True">
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
                        <asp:Label id="Label15" runat="server" Text="Value"></asp:Label></td>
                    <td style="height: 26px">
                        <asp:TextBox id="txtPledge" runat="server"></asp:TextBox></td>
                    <td style="height: 26px"></td>
                    <td style="height: 26px"></td>
                </tr>
                <tr>
                    <td style="width: 192px; height: 21px;">
                        <asp:Label id="Label8" runat="server" Text="Pledge Reason"></asp:Label></td>
                        <td style="height: 21px">
                            <asp:TextBox id="txtPledgeReason" runat="server" Height="104px" TextMode="MultiLine" width="336px"></asp:TextBox></td>
                            <td style="height: 21px">
                                </td>
                                <td style="height: 21px">
                                    </td>
                </tr>
                
            </table>
            <table>
            <tr>
                    <td colspan ="4" style="width: 850px" align="center">
                        <asp:GridView id="GdStatisticsView" runat="server" Height="48px" width="832px">
                            <RowStyle font-names="Verdana" font-size="Small" HorizontalAlign="Left" />
                            <HeaderStyle font-bold="True" font-names="Calibri" font-size="Medium" Font-Underline="True"
                                forecolor="#0000C0" HorizontalAlign="Left" />
                            <EditRowStyle HorizontalAlign="Left" />
                        </asp:GridView>
                    </td>                
                </tr>
                <tr>
                    <td colspan ="4" style="width: 850px" align="center">
                        <asp:Button id="btnSave" runat="server" Text="Save" width="96px" /></td>                
                </tr>
            </table>
        </td>
    </tr>
</table>
</asp:Panel>
</div>
</asp:Content>

