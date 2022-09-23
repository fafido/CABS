<%@ Page Language="VB" MasterPageFile="~/CDSUser.master" AutoEventWireup="false" CodeFile="frmBrokers.aspx.vb" Inherits="Parameters_frmBrokers" title="Untitled Page" %>

<asp:Content id="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="border-right: #000033 thin solid; border-top: #000033 thin solid; border-left: #000033 thin solid; width: 832px; border-bottom: #000033 thin solid; background-color: #ffffff" 
            __designer:mapid="417">
        <tr align="center" __designer:mapid="418">
            <td style="width: 712px; height: 226px" valign="top" __designer:mapid="419">
                <table __designer:mapid="41a">
                    <tr __designer:mapid="41b">
                        <td style="width: 870px" align="center" __designer:mapid="41c">
                            <asp:Label id="Label4" runat="server" backcolor="#8080FF" font-bold="True" font-names="Arial"
                        Text="Brokers" width="848px"></asp:Label>
                        </td>
                    </tr>
                </table>
                <table __designer:mapid="41e" style="width: 367px">
                    <tr __designer:mapid="41f">
                        <td align="left" __designer:mapid="420">
                            <asp:Label id="Label1" runat="server" Text="Broker Code" font-names="Arial" 
                            font-size="Small"></asp:Label>
                        </td>
                        <td __designer:mapid="422">
                            <asp:TextBox id="txtCode" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr __designer:mapid="424">
                        <td align="left" __designer:mapid="425">
                            <asp:Label id="Label2" runat="server" Text="Broker Name" font-names="Arial" 
                            font-size="Small"></asp:Label>
                        </td>
                        <td __designer:mapid="427">
                            <asp:TextBox id="txtFname" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr __designer:mapid="429">
                        <td align="left" __designer:mapid="42a">
                            <asp:Label id="Label3" runat="server" Text="Address" 
                            font-names="Arial" font-size="Small"></asp:Label>
                        </td>
                        <td __designer:mapid="42c">
                            <asp:TextBox id="txtAddress" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr __designer:mapid="42e">
                        <td align="left" __designer:mapid="42f">
                            <asp:Label id="Label5" runat="server" Text="City" 
                            font-names="Arial" font-size="Small"></asp:Label>
                        </td>
                        <td __designer:mapid="431">
                            <asp:TextBox id="txtCity" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr __designer:mapid="433">
                        <td align="left" __designer:mapid="434">
                            <asp:Label id="Label6" runat="server" Text="Phone No" font-names="Arial" 
                            font-size="Small"></asp:Label>
                        </td>
                        <td __designer:mapid="436">
                            <asp:TextBox id="txtPhoneNo" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr __designer:mapid="438">
                        <td align="left" __designer:mapid="439">
                            <asp:Label id="Label7" runat="server" Text="Email Address" font-names="Arial" 
                            font-size="Small"></asp:Label>
                        </td>
                        <td __designer:mapid="43b">
                            <asp:TextBox id="txtEmail" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                </table>
                <table __designer:mapid="441">
                    <tr __designer:mapid="442">
                        <td colspan="4" align="center" bgcolor="#8080ff" style="height: 13px" 
                        __designer:mapid="443">
                            <asp:Label id="Label10" runat="server" 
                            Text="..................................................................................................................................................................................................." 
                            width="848px"></asp:Label>
                        </td>
                    </tr>
                    <tr __designer:mapid="445">
                        <td colspan ="1" style="width: 147px" __designer:mapid="446">
                        </td>
                        <td colspan="1" style="width: 203px" __designer:mapid="447">
                        </td>
                        <td colspan ="1" style="width: 172px" __designer:mapid="448">
                            <asp:Button id="btnSave" runat="server" Text="Save" />
                        </td>
                        <td colspan ="1" style="width: 424px" __designer:mapid="44a">
                        </td>
                    </tr>
                </table>
                <table __designer:mapid="44b">
                    <tr __designer:mapid="44c">
                        <td style="width: 850px" align="center" __designer:mapid="44d">
                            <asp:GridView id="GridView1" runat="server" backcolor="White" 
                                BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" CellPadding="3" 
                                GridLines="Horizontal" width="386px">
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
            </td>
        </tr>
    </table>
</asp:Content>

