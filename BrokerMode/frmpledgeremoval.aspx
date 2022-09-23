<%@ Page Language="VB" AutoEventWireup="false" MasterPageFile="~/CDSUser.master" CodeFile="frmpledgeremoval.aspx.vb" Inherits="BrokerMode_frmpledgeremoval" %>


<asp:Content id="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<asp:Panel id="mypanel" runat="server" backcolor="White" BorderColor="Black" 
        BorderStyle="Solid" BorderWidth="2px" Height="567px" width="857px" >
    <table style="background: #FFFFFF; width: 100%">
        <tr>
            <td align="center">
                            <asp:Label id="Label4" runat="server" 
                                backcolor="#8080FF" font-bold="True" font-names="Arial" 
                                Text="Pledge Removal" width="841px"></asp:Label>
                        </td>
        </tr>
    </table>
    
    
    <table style="width: 100%">
    <tr>
    <td>
        <br />
        <asp:RadioButtonList id="RadioButtonList1" runat="server" 
            RepeatDirection="Horizontal">
            <asp:ListItem>Remove Pledge</asp:ListItem>
            <asp:ListItem>Transfer Pledge shares to Pledgee</asp:ListItem>
            <asp:ListItem>Sell Pledge Shares</asp:ListItem>
        </asp:RadioButtonList>
        <table style="width: 100%">
            <tr>
                <td style="width: 124px">
                    Holder Name
                </td>
                <td colspan="2">
                    <asp:TextBox id="TextBox1" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 124px">
                    Holder Number</td>
                <td colspan="2">
                    <asp:TextBox id="TextBox2" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 124px">
                    &nbsp;</td>
                <td style="width: 242px">
                    <asp:ListBox id="ListBox1" runat="server" Height="65px" width="282px">
                    </asp:ListBox>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="width: 124px">
                    &nbsp;</td>
                <td align="RIGHT" style="width: 242px">
                    <asp:Button id="Button1" runat="server" Text="Select" width="55px" />
                </td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
        <br />
        <asp:Panel id="Panel1" runat="server">
            <table style="width: 100%">
                <tr>
                    <td style="width: 124px">
                        No of Pledge Units&nbsp;</td>
                    <td style="width: 279px">
                        <asp:TextBox id="TextBox3" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td valign="top" style="width: 124px">
                        Reason</td>
                    <td style="width: 279px">
                        <asp:TextBox id="TextBox4" runat="server" Height="59px" TextMode="MultiLine" 
                            width="278px"></asp:TextBox>
                    </td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 124px">
                        &nbsp;</td>
                    <td style="width: 279px">
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 124px">
                        &nbsp;</td>
                    <td align="right" style="width: 279px">
                        <asp:Button id="Button2" runat="server" Text="Scan and Upload Doc" />
                        &nbsp;
                        <asp:Button id="Button3" runat="server" Text="Save" />
                    </td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 124px">
                        &nbsp;</td>
                    <td style="width: 279px">
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
            </table>
        </asp:Panel>
        </td></tr>
    </table>
    </asp:Panel>

</asp:Content>
