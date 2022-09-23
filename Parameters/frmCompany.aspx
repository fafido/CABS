<%@ Page Language="VB" MasterPageFile="~/CDSUser.master" AutoEventWireup="false" CodeFile="frmCompany.aspx.vb" Inherits="Parameters_frmCompany" title="Untitled Page" %>

<%@ Register assembly="BasicFrame.WebControls.BasicDatePicker" namespace="BasicFrame.WebControls" tagprefix="BDP" %>

<asp:Content id="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="border-right: #000033 thin solid; border-top: #000033 thin solid; border-left: #000033 thin solid; width: 650px; border-bottom: #000033 thin solid; background-color: #ffffff" 
            __designer:mapid="182">
        <tr align="center" __designer:mapid="183">
            <td style="height: 226px; width: 574px;" valign="top" __designer:mapid="184">
                <table __designer:mapid="185">
                    <tr __designer:mapid="186">
                        <td style="width: 600px" align="center" __designer:mapid="187">
                            <asp:Label id="Label4" runat="server" backcolor="#8080FF" font-bold="True" font-names="Arial"
                        Text="Companies" width="811px"></asp:Label>
                        </td>
                    </tr>
                </table>
                <table __designer:mapid="189" style="width: 532px">
                    <tr __designer:mapid="18a">
                        <td align="left" __designer:mapid="18b" style="width: 323px">
                            <asp:Label id="Label1" runat="server" Text="Short Name" font-names="Arial" 
                            font-size="Small"></asp:Label>
                        </td>
                        <td __designer:mapid="18d" style="text-align: left">
                            <asp:TextBox id="txtShort" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr __designer:mapid="18f">
                        <td align="left" __designer:mapid="190" style="width: 323px">
                            <asp:Label id="Label2" runat="server" Text="Company" font-names="Arial" 
                            font-size="Small"></asp:Label>
                        </td>
                        <td __designer:mapid="192" style="text-align: left">
                            <asp:TextBox id="txtFname" runat="server" width="246px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr __designer:mapid="194">
                        <td align="left" __designer:mapid="195" style="width: 323px">
                            <asp:Label id="Label5" runat="server" Text="Date Created" 
                            font-names="Arial" font-size="Small"></asp:Label>
                        </td>
                        <td __designer:mapid="197" style="text-align: left">
                            <BDP:BasicDatePicker id="BasicDatePicker1" runat="server" />
                        </td>
                    </tr>
                    <tr __designer:mapid="199">
                        <td align="left" __designer:mapid="19a" style="width: 323px">
                            <asp:Label id="Label6" runat="server" Text="Initial Share Capital" font-names="Arial" 
                            font-size="Small"></asp:Label>
                        </td>
                        <td __designer:mapid="19c" style="text-align: left">
                            <asp:TextBox id="txtInitShares" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr __designer:mapid="19e">
                        <td align="left" __designer:mapid="19f" style="width: 323px">
                            <asp:Label id="Label7" runat="server" Text="Shares On System" font-names="Arial" 
                            font-size="Small"></asp:Label>
                        </td>
                        <td __designer:mapid="1a1" style="text-align: left">
                            <asp:TextBox id="txtCurrShares" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr __designer:mapid="1a3">
                        <td align="left" __designer:mapid="1a4" style="width: 323px">
                            <asp:Label id="Label3" runat="server" Text="CDS Account No" 
                            font-names="Arial" font-size="Small"></asp:Label>
                        </td>
                        <td __designer:mapid="1a6" style="text-align: left">
                            <asp:TextBox id="txtCDSNo" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr __designer:mapid="1a3">
                        <td align="left" __designer:mapid="1a4" style="width: 323px">
                            <asp:Label id="Label11" runat="server" Text="Registrar" 
                            font-names="Arial" font-size="Small"></asp:Label>
                        </td>
                        <td __designer:mapid="1a6" style="text-align: left">
                            <asp:TextBox id="txtTSec" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr __designer:mapid="1a3">
                        <td align="left" __designer:mapid="1a4" style="width: 323px" valign="top">
                            <asp:Label id="Label12" runat="server" Text="Address" 
                            font-names="Arial" font-size="Small"></asp:Label>
                        </td>
                        <td __designer:mapid="1a6" style="text-align: left">
                            <asp:TextBox id="txtAddress" runat="server" Height="93px" width="243px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr __designer:mapid="1a3">
                        <td align="left" __designer:mapid="1a4" style="width: 323px">
                            <asp:Label id="Label13" runat="server" Text="City" 
                            font-names="Arial" font-size="Small"></asp:Label>
                        </td>
                        <td __designer:mapid="1a6" style="text-align: left">
                            <asp:TextBox id="txtCity" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr __designer:mapid="1a3">
                        <td align="left" __designer:mapid="1a4" style="width: 323px">
                            <asp:Label id="Label14" runat="server" Text="Country" 
                            font-names="Arial" font-size="Small"></asp:Label>
                        </td>
                        <td __designer:mapid="1a6" style="text-align: left">
                            <asp:TextBox id="txtCountry" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr __designer:mapid="1a3">
                        <td align="left" __designer:mapid="1a4" style="width: 323px">
                            <asp:Label id="Label15" runat="server" Text="Contact Person" 
                            font-names="Arial" font-size="Small"></asp:Label>
                        </td>
                        <td __designer:mapid="1a6" style="text-align: left">
                            <asp:TextBox id="txtcontact" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr __designer:mapid="1a3">
                        <td align="left" __designer:mapid="1a4" style="width: 323px">
                            <asp:Label id="Label16" runat="server" Text="Contact Number" 
                            font-names="Arial" font-size="Small"></asp:Label>
                        </td>
                        <td __designer:mapid="1a6" style="text-align: left">
                            <asp:TextBox id="txtCellNo" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr __designer:mapid="1a3">
                        <td align="left" __designer:mapid="1a4" style="width: 323px">
                            <asp:Label id="Label17" runat="server" Text="Fax" 
                            font-names="Arial" font-size="Small"></asp:Label>
                        </td>
                        <td __designer:mapid="1a6" style="text-align: left">
                            <asp:TextBox id="txtFax" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr __designer:mapid="1a3">
                        <td align="left" __designer:mapid="1a4" style="width: 323px" valign="top">
                            <asp:Label id="Label18" runat="server" Text="Comments" 
                            font-names="Arial" font-size="Small"></asp:Label>
                        </td>
                        <td __designer:mapid="1a6" style="text-align: left">
                            <asp:TextBox id="txtComments" runat="server" Height="51px" width="236px"></asp:TextBox>
                        </td>
                    </tr>
                </table>
                <table __designer:mapid="1ac">
                    <tr __designer:mapid="1ad">
                        <td colspan="4" align="center" bgcolor="#8080ff" style="height: 13px" 
                        __designer:mapid="1ae">
                            <asp:Label id="Label10" runat="server" 
                            Text="..................................................................................................................................................................................................." 
                            width="553px"></asp:Label>
                        </td>
                    </tr>
                    <tr __designer:mapid="1b0">
                        <td colspan ="1" style="width: 147px" __designer:mapid="1b1">
                        </td>
                        <td colspan="1" style="width: 203px" __designer:mapid="1b2">
                        </td>
                        <td colspan ="1" style="width: 172px" __designer:mapid="1b3">
                            <asp:Button id="btnPrintStatement" runat="server" Text="Save" width="64px" />
                        </td>
                        <td colspan ="1" style="width: 424px" __designer:mapid="1b5">
                        </td>
                    </tr>
                </table>
                <table __designer:mapid="1b6">
                    <tr __designer:mapid="1b7">
                        <td style="width: 850px" align="center" __designer:mapid="1b8">
                            <asp:GridView id="GridView1" runat="server" backcolor="White" 
                                BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" CellPadding="3" 
                                GridLines="Horizontal" width="491px">
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

