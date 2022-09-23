<%@ Page Language="VB" MasterPageFile="~/CDSMain.master" AutoEventWireup="false" CodeFile="SystemCalender.aspx.vb" Inherits="SystemCalender" %>

<asp:Content id="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <asp:Panel id="Panel1" runat="server">
    
<table style="border-right: #000033 thin solid; border-top: #000033 thin solid; border-left: #000033 thin solid; width: 832px; border-bottom: #000033 thin solid; background-color: #ffffff">
    <tr>
        <td style="width: 712px; height: 226px" valign="top">
            <table>
            <tr>
                <td colspan ="6" align="center">
                    <asp:Label id="Label4" runat="server" backcolor="#8080FF" font-bold="True" font-names="Arial"
                        text="System Calender - Events Updates" width="848px"></asp:Label></td>
            </tr>
            <tr>
                <td colspan ="2" align="left"><asp:Label runat="server" Text="Event Target:"></asp:Label>
                </td>
                <td colspan ="4">
                    <asp:DropDownList runat="server" ID="cmbTarget" Width="346px">
                        <asp:ListItem>All</asp:ListItem>
                        <asp:ListItem>Brokers</asp:ListItem>
                        <asp:ListItem>Custodians</asp:ListItem>
                        <asp:ListItem>CDS</asp:ListItem>
                        <asp:ListItem>Transfer Sectretaries</asp:ListItem>
                        <asp:ListItem>Shareholders</asp:ListItem>
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td align="center" colspan ="6">
                    <asp:Calendar ID="Calendar1" runat="server" Height="392px" Width="594px">
                    </asp:Calendar>
                </td>
            </tr>
             <tr>
             <td valign="top" align="left" colspan ="2">
                        <asp:Label ID="Label5" runat="server" Text="Subject"></asp:Label>
                        </td>
                        <td colspan ="4">
                        <asp:TextBox runat="server" ID="txtEventTitle" Width="446px" ></asp:TextBox></td>
                </tr>
                 <tr>
             <td valign="top" align="left" colspan ="2">
                        <asp:Label ID="Label6" runat="server" Text="Event Comment"></asp:Label>
                        </td>
                        <td colspan ="4">
                        <asp:TextBox runat="server" ID="txtEvent" Height="70px" TextMode="MultiLine" 
                                Width="446px" ></asp:TextBox></td>
                </tr>
                <tr>
                    
                    <td colspan ="6" align="center" style="height: 24px"><asp:RadioButton runat="server" ID="rdGrant" AutoPostBack="True" 
                            GroupName="SystemAccessOp" Text="Grant System Access"></asp:RadioButton>
                        <asp:RadioButton ID="rdLockSystem" runat="server" AutoPostBack="True" 
                            GroupName="SystemAccessOp" Text="Lock System to All" />
                        <asp:RadioButton ID="rdLockGroup" runat="server" AutoPostBack="True" 
                            GroupName="SystemAccessOp" Text="Lock System for Specific Group" />
                    </td>
                </tr>
                    <tr>
             <td valign="top" align="left" colspan ="2">
                        <asp:Label ID="lblGroups" runat="server" Text="Groups"></asp:Label>
                        </td>
                        <td colspan ="4">
                        <asp:DropDownList runat="server" ID="cmbGroups" AutoPostBack="True" Visible="False" 
                                Width="446px"></asp:DropDownList>
                        </td>
                </tr>
                <tr>
                    <td colspan ="2"></td>
                    <td colspan ="4" align ="left" ><asp:Button runat="server" Text="Save" ID="btnSave"></asp:Button></td>
                </tr>
                <tr>
                    <td valign="top">
                        </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
</asp:Panel>

</asp:Content>

