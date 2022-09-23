<%@ Page Title="" Language="VB" MasterPageFile="~/CDSUser.master" AutoEventWireup="false" CodeFile="Interfaces.aspx.vb" Inherits="Parameters_Default" %><%@ Register assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width: 80%; height: 405px;">
    <tr>
        <td style="width: 146px">&nbsp;</td>
        <td style="width: 126px">&nbsp;</td>
        <td style="width: 137px">&nbsp;</td>
        <td style="width: 86px">&nbsp;</td>
        <td style="width: 156px">&nbsp;</td>
        <td style="width: 273px">&nbsp;</td>
    </tr>
    <tr>
        <td style="width: 146px">
            <dx:ASPxLabel ID="ASPxLabel1" runat="server" style="font-weight: 700" Text="Trading Interface">
            </dx:ASPxLabel>
        </td>
        <td style="width: 126px">
            <dx:ASPxTextBox ID="txtTradingRoute" runat="server" Height="19px" Width="130px">
            </dx:ASPxTextBox>
        </td>
        <td style="width: 137px">
            <dx:ASPxLabel ID="ASPxLabel5" runat="server" style="font-weight: 700" Text="Settlement Interface">
            </dx:ASPxLabel>
        </td>
        <td style="width: 86px">
            <dx:ASPxTextBox ID="txtSettlementRoute" runat="server" Height="19px" Width="130px">
            </dx:ASPxTextBox>
&nbsp;</td>
        <td style="width: 156px">
            <dx:ASPxLabel ID="ASPxLabel10" runat="server" style="font-weight: 700" Text="Interdepository Interface">
            </dx:ASPxLabel>
        </td>
        <td style="width: 273px">
            <dx:ASPxTextBox ID="txtInterDepRoute" runat="server" Height="19px" Width="130px">
            </dx:ASPxTextBox>
        </td>
    </tr>
    <tr>
        <td style="width: 146px">
            <dx:ASPxLabel ID="ASPxLabel2" runat="server" Text="Local Listener IP Address">
            </dx:ASPxLabel>
        </td>
        <td style="width: 126px">
            <dx:ASPxTextBox ID="txtTradingLocalListenerIP" runat="server" Height="19px" Width="130px">
            </dx:ASPxTextBox>
        </td>
        <td style="width: 137px">
            <dx:ASPxLabel ID="ASPxLabel6" runat="server" Text="Local Listener IP Address">
            </dx:ASPxLabel>
        </td>
        <td style="width: 86px">
            <dx:ASPxTextBox ID="txtSettlementLocalListenerIP" runat="server" Height="19px" Width="130px">
            </dx:ASPxTextBox>
        </td>
        <td style="width: 156px">
            <dx:ASPxLabel ID="ASPxLabel11" runat="server" Text="Local Listener IP Address">
            </dx:ASPxLabel>
        </td>
        <td style="width: 273px">
            <dx:ASPxTextBox ID="txtInterDepLocalListenerIP" runat="server" Height="19px" Width="130px">
            </dx:ASPxTextBox>
        </td>
    </tr>
    <tr>
        <td style="width: 146px">
            <dx:ASPxLabel ID="Port" runat="server" Text="Local Listening Port">
            </dx:ASPxLabel>
        </td>
        <td style="width: 126px">
            <dx:ASPxTextBox ID="txtTradingLocalListenerPort" runat="server" Height="19px" Width="130px">
            </dx:ASPxTextBox>
        </td>
        <td style="width: 137px">
            <dx:ASPxLabel ID="Port2" runat="server" Text="Local Listening Port">
            </dx:ASPxLabel>
        </td>
        <td style="width: 86px">
            <dx:ASPxTextBox ID="txtSettlementLocalListenerPort" runat="server" Height="19px" Width="130px">
            </dx:ASPxTextBox>
        </td>
        <td style="width: 156px">
            <dx:ASPxLabel ID="Port4" runat="server" Text="Local Listening Port">
            </dx:ASPxLabel>
        </td>
        <td style="width: 273px">
            <dx:ASPxTextBox ID="txtInterDepLocalListenerPort" runat="server" Height="19px" Width="130px">
            </dx:ASPxTextBox>
        </td>
    </tr>
    <tr>
        <td style="width: 146px">
            <dx:ASPxLabel ID="ASPxLabel3" runat="server" Text="Local Sending IP Address">
            </dx:ASPxLabel>
        </td>
        <td style="width: 126px">
            <dx:ASPxTextBox ID="txtTradingLocalSenderIP" runat="server" Height="19px" Width="130px">
            </dx:ASPxTextBox>
        </td>
        <td style="width: 137px">
            <dx:ASPxLabel ID="ASPxLabel7" runat="server" Text="Local Sending IP Address">
            </dx:ASPxLabel>
        </td>
        <td style="width: 86px">
            <dx:ASPxTextBox ID="txtSettlementLocalSenderIP" runat="server" Height="19px" Width="130px">
            </dx:ASPxTextBox>
        </td>
        <td style="width: 156px">
            <dx:ASPxLabel ID="ASPxLabel12" runat="server" Text="Local Sending IP Address">
            </dx:ASPxLabel>
        </td>
        <td style="width: 273px">
            <dx:ASPxTextBox ID="txtInterDepLocalSenderIP" runat="server" Height="19px" Width="130px">
            </dx:ASPxTextBox>
        </td>
    </tr>
    <tr>
        <td style="width: 146px">
            <dx:ASPxLabel ID="Port0" runat="server" Text="Local Sending Port">
            </dx:ASPxLabel>
        </td>
        <td style="width: 126px">
            <dx:ASPxTextBox ID="txtTradingLocalSenderPort" runat="server" Height="19px" Width="130px">
            </dx:ASPxTextBox>
        </td>
        <td style="width: 137px">
            <dx:ASPxLabel ID="ASPxLabel8" runat="server" Text="Local Sending Port">
            </dx:ASPxLabel>
        </td>
        <td style="width: 86px">
            <dx:ASPxTextBox ID="txtSettlementLocalSenderPort" runat="server" Height="19px" Width="130px">
            </dx:ASPxTextBox>
        </td>
        <td style="width: 156px">
            <dx:ASPxLabel ID="ASPxLabel13" runat="server" Text="Local Sending Port">
            </dx:ASPxLabel>
        </td>
        <td style="width: 273px">
            <dx:ASPxTextBox ID="txtInterDepLocalSenderPort" runat="server" Height="19px" Width="130px">
            </dx:ASPxTextBox>
        </td>
    </tr>
    <tr>
        <td style="width: 146px">
            <dx:ASPxLabel ID="ASPxLabel4" runat="server" Text="Remote Receiver IP Address">
            </dx:ASPxLabel>
        </td>
        <td style="width: 126px">
            <dx:ASPxTextBox ID="txtTradingRemoteReceiverIP" runat="server" Height="19px" Width="130px">
            </dx:ASPxTextBox>
        </td>
        <td style="width: 137px">
            <dx:ASPxLabel ID="ASPxLabel9" runat="server" Text="Remote Receiver IP Address">
            </dx:ASPxLabel>
        </td>
        <td style="width: 86px">
            <dx:ASPxTextBox ID="txtSettlementRemoteReceiverIP" runat="server" Height="19px" Width="130px">
            </dx:ASPxTextBox>
        </td>
        <td style="width: 156px">
            <dx:ASPxLabel ID="ASPxLabel14" runat="server" Text="Remote Receiver IP Address">
            </dx:ASPxLabel>
        </td>
        <td style="width: 273px">
            <dx:ASPxTextBox ID="txtInterDepRemoteReceiverIP" runat="server" Height="19px" Width="130px">
            </dx:ASPxTextBox>
        </td>
    </tr>
    <tr>
        <td style="width: 146px">
            <dx:ASPxLabel ID="Port1" runat="server" Text="Remote Receiver Port">
            </dx:ASPxLabel>
        </td>
        <td style="width: 126px">
            <dx:ASPxTextBox ID="txtTradingRemoteReceiverPort" runat="server" Height="19px" Width="130px">
            </dx:ASPxTextBox>
        </td>
        <td style="width: 137px">
            <dx:ASPxLabel ID="Port3" runat="server" Text="Remote Receiver Port">
            </dx:ASPxLabel>
        </td>
        <td style="width: 86px">
            <dx:ASPxTextBox ID="txtSettlementRemoteReceiverPort" runat="server" Height="19px" Width="130px">
            </dx:ASPxTextBox>
        </td>
        <td style="width: 156px">
            <dx:ASPxLabel ID="Port5" runat="server" Text="Remote Receiver Port">
            </dx:ASPxLabel>
        </td>
        <td style="width: 273px">
            <dx:ASPxTextBox ID="txtInterDepRemoteReceiverPort" runat="server" Height="19px" Width="130px">
            </dx:ASPxTextBox>
        </td>
    </tr>
    <tr>
        <td style="width: 146px">
            <dx:ASPxLabel ID="ASPxLabel15" runat="server" Text="Remote Sender IP Address">
            </dx:ASPxLabel>
        </td>
        <td style="width: 126px">
            <dx:ASPxTextBox ID="txtTradingRemoteSenderIP" runat="server" Height="19px" Width="130px">
            </dx:ASPxTextBox>
        </td>
        <td style="width: 137px">
            <dx:ASPxLabel ID="ASPxLabel16" runat="server" Text="Remote Sender IP Address">
            </dx:ASPxLabel>
        </td>
        <td style="width: 86px">
            <dx:ASPxTextBox ID="txtSettlementRemoteSenderIP" runat="server" Height="19px" Width="130px">
            </dx:ASPxTextBox>
        </td>
        <td style="width: 156px">
            <dx:ASPxLabel ID="ASPxLabel17" runat="server" Text="Remote Sender IP Address">
            </dx:ASPxLabel>
        </td>
        <td style="width: 273px">
            <dx:ASPxTextBox ID="txtInterDepRemoteSenderIP" runat="server" Height="19px" Width="130px">
            </dx:ASPxTextBox>
        </td>
    </tr>
    <tr>
        <td style="width: 146px">
            <dx:ASPxLabel ID="Port6" runat="server" Text="Remote Sender Port">
            </dx:ASPxLabel>
        </td>
        <td style="width: 126px">
            <dx:ASPxTextBox ID="txtTradingRemoteSenderPort" runat="server" Height="19px" Width="130px">
            </dx:ASPxTextBox>
        </td>
        <td style="width: 137px">
            <dx:ASPxLabel ID="Port7" runat="server" Text="Remote Sender Port">
            </dx:ASPxLabel>
        </td>
        <td style="width: 86px">
            <dx:ASPxTextBox ID="txtSettlementRemoteSenderPort" runat="server" Height="19px" Width="130px">
            </dx:ASPxTextBox>
        </td>
        <td style="width: 156px">
            <dx:ASPxLabel ID="Port8" runat="server" Text="Remote Sender Port">
            </dx:ASPxLabel>
        </td>
        <td style="width: 273px">
            <dx:ASPxTextBox ID="txtInterDepRemoteSenderPort" runat="server" Height="19px" Width="130px">
            </dx:ASPxTextBox>
        </td>
    </tr>
    <tr>
        <td style="width: 146px">&nbsp;</td>
        <td style="width: 126px">
            <dx:ASPxButton ID="btnTradingSave" runat="server" Text="Add ">
            </dx:ASPxButton>
        </td>
        <td style="width: 137px">&nbsp;</td>
        <td style="width: 86px">
            <dx:ASPxButton ID="btnAddSettlement" runat="server" Text="Add">
            </dx:ASPxButton>
        </td>
        <td style="width: 156px">&nbsp;</td>
        <td style="width: 273px">
            <dx:ASPxButton ID="btnSaveInterDepository" runat="server" Text="Add">
            </dx:ASPxButton>
        </td>
    </tr>
    <tr>
        <td style="width: 146px">&nbsp;</td>
        <td style="width: 126px">&nbsp;</td>
        <td style="width: 137px">&nbsp;</td>
        <td style="width: 86px">&nbsp;</td>
        <td style="width: 156px">&nbsp;</td>
        <td style="width: 273px">&nbsp;</td>
    </tr>
    <tr>
        <td colspan="6">
            <table style="width: 100%; height: 102px;">
                <tr>
                    <td>
                        <asp:GridView ID="grdvInterfaces" runat="server" AutoGenerateSelectButton="True">
                        </asp:GridView>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
</asp:Content>

