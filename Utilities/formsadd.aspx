<%@ Page Language="VB" MasterPageFile="~/CDSUser.master" AutoEventWireup="false" CodeFile="Formsadd.aspx.vb" Inherits="Utilities_formsadd" title="Add Forms" %>

<asp:Content id="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="border-right: #000033 thin solid; border-top: #000033 thin solid; border-left: #000033 thin solid; width: 832px; border-bottom: #000033 thin solid; background-color: #ffffff" 
            __designer:mapid="21f">
        <tr align="center" __designer:mapid="220">
            <td style="width: 712px; height: 226px" valign="top" __designer:mapid="221">
                <table __designer:mapid="222">
                    <tr __designer:mapid="223">
                        <td style="width: 870px" align="center" __designer:mapid="224">
                            <asp:Label id="Label4" runat="server" backcolor="#8080FF" font-bold="True" font-names="Arial"
                        Text="System Forms" width="848px"></asp:Label>
                        </td>
                    </tr>
                </table>
                <table __designer:mapid="226" style="width: 291px">
                    <tr __designer:mapid="227">
                        <td align="left" __designer:mapid="228" style="width: 225px; height: 18px;">
                            For User Type</td>
                        <td align="left" >
                            <asp:DropDownList ID="DropDownList3" runat="server" Height="21px" Width="156px">
                            </asp:DropDownList>
                            </td>
                    </tr>
                    <tr __designer:mapid="227">
                        <td align="left" __designer:mapid="228" style="width: 225px; height: 18px;">
                            <asp:Label id="Label11" runat="server" Text="Module" font-names="Arial" 
                            font-size="Small"></asp:Label>
                        </td>
                        <td align="left" >
                            <asp:DropDownList ID="DropDownList2" runat="server" Height="21px" Width="156px">
                            </asp:DropDownList>
                            </td>
                    </tr>
                    <tr __designer:mapid="227">
                        <td align="left" __designer:mapid="228" style="width: 225px">
                            <asp:Label id="Label1" runat="server" Text="Folder" font-names="Arial" 
                            font-size="Small"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="DropDownList1" runat="server" Height="21px" Width="156px">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr __designer:mapid="22c">
                        <td align="left" __designer:mapid="22d" style="width: 225px">
                            <asp:Label id="Label2" runat="server" Text="Form Name" font-names="Arial" 
                            font-size="Small"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox id="txtFname" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr __designer:mapid="22c">
                        <td align="left" __designer:mapid="22d" style="width: 225px">
                            <asp:Label id="Label12" runat="server" Text="Form URL" font-names="Arial" 
                            font-size="Small"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox id="txturl" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr __designer:mapid="231">
                        <td align="left" __designer:mapid="232" colspan="2" style="text-align: center">
                            <asp:Button id="btnSave" runat="server" Text="Save" width="64px" 
                                style="height: 26px; text-align: center" />
                        </td>
                    </tr>
                </table>
                <table __designer:mapid="249">
                    <tr __designer:mapid="24a">
                        <td align="center" bgcolor="#8080ff" style="height: 13px" 
                        __designer:mapid="24b">
                            <asp:Label id="Label10" runat="server" 
                            Text="..................................................................................................................................................................................................." 
                            width="848px"></asp:Label>
                        </td>
                    </tr>
                    <tr __designer:mapid="24d">
                        <td __designer:mapid="24e">
                            <asp:GridView id="GridView1" runat="server" backcolor="White" 
                                BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" CellPadding="3" 
                                GridLines="Horizontal" width="831px" 
                                style="font-family: Verdana; font-size: small">
                                <RowStyle backcolor="#E7E7FF" forecolor="#4A3C8C" />
                                <FooterStyle backcolor="#B5C7DE" forecolor="#4A3C8C" />
                                <PagerStyle backcolor="#E7E7FF" forecolor="#4A3C8C" HorizontalAlign="Right" />
                                <SelectedRowStyle backcolor="#738A9C" font-bold="True" forecolor="#F7F7F7" />
                                <HeaderStyle backcolor="#4A3C8C" font-bold="True" forecolor="#F7F7F7" />
                                <AlternatingRowStyle backcolor="#F7F7F7" />
                            </asp:GridView>
                        </td>
                    </tr>
                </table>
                <table __designer:mapid="253">
                    <tr __designer:mapid="254">
                        <td style="width: 850px" align="center" __designer:mapid="255">
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>

