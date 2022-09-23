<%@ Page Language="VB" MasterPageFile="~/CDSMain.master" AutoEventWireup="false" CodeFile="NameEnquiry.aspx.vb" Inherits="CDSMode_NameEnquiry" title="Name Enquiry" %>
<asp:Content id="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <meta http-equiv="Refresh" content="10" />  
<div>
    <asp:Panel id="Panel1" runat="server">
    
<table style="border-right: #000033 thin solid; border-top: #000033 thin solid; border-left: #000033 thin solid; width: 832px; border-bottom: #000033 thin solid; background-color: #ffffff">
    <tr>
        <td style="width: 712px; height: 226px" valign="top">
            <table>
            <tr>
                <td style="width: 870px" align="center">
                    <asp:Label id="Label4" runat="server" backcolor="#8080FF" font-bold="True" font-names="Arial"
                        Text="Account Details Enquiry"  width="985px"></asp:Label></td>
            </tr>
                <tr>
                    <td colspan ="4" valign="top">
                        <asp:Label id="Label1" runat="server" Text="Shareholder Number:" width="144px" font-names="Verdana" font-size="Small"></asp:Label>
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
                        <asp:ListBox id="lstNames" runat="server" Height="136px" width="328px" 
                            autopostback="True"></asp:ListBox></td>
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
                    <td colspan ="1" style="width: 168px">
                        <asp:Label id="Label2" runat="server" Text="Holder Names" font-names="Verdana" font-size="Small"></asp:Label></td>
                        <td colspan="1" style="width: 203px">
                            <asp:TextBox id="txtSurname" runat="server" font-bold="True" ReadOnly="True" TextMode="MultiLine" width="304px"></asp:TextBox></td>
                            <td colspan ="1" style="width: 172px">
                                </td>
                                <td colspan ="1" style="width: 316px">
                                    </td>
                </tr>
                <tr>
                    <td style="width: 168px">
                        <asp:Label id="Label6" runat="server" Text="id Number" font-names="Verdana" font-size="Small"></asp:Label></td>
                        <td>
                            <asp:TextBox id="txtID" runat="server" font-bold="True" ReadOnly="True"></asp:TextBox></td>
                            <td>
                            </td>
                            <td></td>
                </tr>
                <tr>
                    <td style="width: 168px"></td>
                    <td></td>
                    <td></td>
                    <td></td>
                </tr>
                <tr>
                    <td style="width: 168px">
                        <asp:Label id="Label7" runat="server" Text="Address:" font-names="Verdana" font-size="Small"></asp:Label></td>
                        <td>
                            <asp:TextBox id="txtAdd1" runat="server" font-bold="True" ReadOnly="True" Height="152px" TextMode="MultiLine" width="304px"></asp:TextBox></td>
                            <td></td>
                            <td>
                                </td>
                </tr>
                <tr>
                    <td style="width: 168px"></td>
                    <td>
                        </td>
                        <td></td>
                        <td>
                            </td>
                </tr>                            
                <tr>
                    <td style="width: 168px; height: 41px;">
                        <asp:Label id="Label12" runat="server" Text="Other Contact Details" font-names="Verdana" font-size="Small"></asp:Label></td>
                        <td style="height: 41px">
                            <asp:TextBox id="txtEmail" runat="server" Enabled="False" font-bold="True" ReadOnly="True" Height="56px" TextMode="MultiLine" width="304px"></asp:TextBox></td>
                            <td style="height: 41px">
                                </td>
                                <td style="height: 41px">
                                    </td>
                </tr>
                <tr>
                    <td style="width: 168px">
                        </td>
                    <td></td>
                    <td></td>
                    <td></td>
                </tr>
                <tr>
                    <td style="width: 168px">
                        <asp:Label id="Label14" runat="server" Text="Bank" font-names="Verdana" font-size="Small"></asp:Label></td>
                        <td>
                            <asp:TextBox id="txtBank" runat="server" Enabled="False" font-bold="True" ReadOnly="True"></asp:TextBox></td>
                            <td>
                                </td>
                                <td>
                                    </td>
                </tr>
                <tr>
                    <td style="width: 168px">
                                <asp:Label id="Label15" runat="server" Text="Branch" font-names="Verdana" font-size="Small"></asp:Label></td>
                        <td>
                                    <asp:TextBox id="txtBranch" runat="server" Enabled="False" font-bold="True" ReadOnly="True"></asp:TextBox></td>
                            <td>
                                </td>
                                <td>
                                    </td>
                </tr>
                <tr>
                    <td style="width: 168px">
                        <asp:Label id="Label16" runat="server" Text="Account Number" font-names="Verdana" font-size="Small"></asp:Label></td>
                    <td>
                            <asp:TextBox id="txtBnkAccount" runat="server" Enabled="False" font-bold="True" ReadOnly="True"></asp:TextBox></td>
                    <td></td>
                    <td></td>
                </tr>
                <tr>
                    <td style="width: 168px">
                        </td>
                        <td>
                            </td>
                            <td>
                                </td>
                                <td>
                                    </td>
                </tr>
                
            </table>
            <table>
                <tr>
                    <td colspan ="4" style="width: 850px" align="center">
                        <asp:Button id="btnPrint" runat="server" Text="Print Account Details Statement" width="240px" /></td>                
                </tr>
            </table>
        </td>
    </tr>
</table>
</asp:Panel>
</div>
</asp:Content>

