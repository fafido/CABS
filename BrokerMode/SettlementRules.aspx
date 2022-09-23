<%@ Page Language="VB" MasterPageFile="~/CDSUser.master" AutoEventWireup="false" CodeFile="SettlementRules.aspx.vb" Inherits="BrokerMode_SettlementRules" title="Broker Home" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxTabControl" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>


<%@ Register assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dx" %>


<%@ Register assembly="DevExpress.XtraCharts.v13.2.Web, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.XtraCharts.Web" tagprefix="dxchartsui" %>
<%@ Register assembly="DevExpress.XtraCharts.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.XtraCharts" tagprefix="cc1" %>


<%@ Register assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxFileManager" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxUploadControl" tagprefix="dx" %>


<%@ Register assembly="DevExpress.Web.ASPxScheduler.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxScheduler.Controls" tagprefix="dxwschsc" %>
<%@ Register assembly="DevExpress.Web.ASPxScheduler.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxScheduler" tagprefix="dxwschs" %>


<asp:Content id="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
        <table style ="background-color:white;" width="840px">
                <tr>
                        <td>
                            <asp:Panel id="Panel1" runat="server" BorderStyle="Solid" BorderWidth="1px">
        <table border="0" style="background-color:white;">
                <tr>
                        <td colspan ="2" align="center"><dx:ASPxLabel ID="ASPxLabel1" runat="server" Text="Clearing and Settlement Messaging Parameters" Theme="iOS" Width="840px" BackColor="#000066" ForeColor="White"></dx:ASPxLabel></td>

               </tr>            
        </table>
<asp:Panel runat="server" id="Panel2" GroupingText="Trades Data Verification Messaging" Width="840px" Font-Names="Cambria" Font-Size="Medium" BorderStyle="None" BorderWidth="1px">
    <table style="background-color:ivory;" width ="820px">
            <tr>
                    <td colspan ="2" align ="center">&nbsp;</td>

            </tr>
            <tr>
                <td align="center"><dx:ASPxLabel ID="ASPxLabel3" runat="server" Text="Securities Confirmations" Font-Names="Cambria" Font-Size="Small"></dx:ASPxLabel></td>
                <td align ="center"><dx:ASPxLabel ID="ASPxLabel4" runat="server" Text="Cash Accounts Confirmations" Font-Names="Cambria" Font-Size="Small"></dx:ASPxLabel></td>
            </tr>

            <tr>
               <td align ="center">
                   <asp:RadioButton ID="rdSwift" runat="server" AutoPostBack="True" Font-Names="Cambria" GroupName="TradesConfirmations" Text="Swift" Font-Size="Small" />
                   <asp:RadioButton ID="rdSwift0" runat="server" AutoPostBack="True" Font-Names="Cambria" GroupName="TradesConfirmations" Text="Web Services" Font-Size="Small" />
                </td>
                <td align="center">
                    <asp:RadioButton ID="rdCashSwift" runat="server" AutoPostBack="True" Font-Names="Cambria" GroupName="CashAccountsConfirmations" Text="Swift" Font-Size="Small" />
                    <asp:RadioButton ID="rdPostillion" runat="server" AutoPostBack="True" Font-Names="Cambria" GroupName="CashAccountsConfirmations" Text="Postillion" Font-Size="Small" />
                </td>
                

            </tr>
            <tr>
                    <td align="center"></td>
                <td align ="center"></td>

            </tr>
            <tr>
                    <td align="center">
                        <dx:ASPxButton ID="ASPxButton1" runat="server" Text="Save" Theme="BlackGlass">
                        </dx:ASPxButton>
                    </td>
                <td align ="center">
                    <dx:ASPxButton ID="ASPxButton2" runat="server" Text="Save" Theme="BlackGlass">
                    </dx:ASPxButton>
                    </td>

            </tr>
    </table>


</asp:Panel>
                                <asp:Panel runat="server" ID="panel3" Font-Names="Cambria" GroupingText="Matched Trades Messaging Options" Width="840px" Font-Size="Medium">
                                <table style="background-color:ivory;" width ="820px">
                                        <tr>

                    <td colspan ="2" align ="center">&nbsp;</td>
            </tr>
            <tr>
                <td colspan ="2" align="center">
                    <asp:RadioButton ID="RdMatchedSwift" runat="server" AutoPostBack="True" CausesValidation="True" Font-Names="Cambria" Font-Size="Small" GroupName="MatchedOptions" Text="Swift" />
                    <asp:RadioButton ID="RdMatchedSwift0" runat="server" AutoPostBack="True" CausesValidation="True" Font-Names="Cambria" Font-Size="Small" GroupName="MatchedOptions" Text="Postillion" />
                </td>

            </tr>
            <tr>
                    <td></td>
                    <td></td>

            </tr>
            <tr>

                <td colspan="2" align ="center">
                    <dx:ASPxButton ID="ASPxButton3" runat="server" Text="Save" Theme="BlackGlass">
                    </dx:ASPxButton>
                </td>
            </tr>

                                </table>
                                    
                                </asp:Panel>

                                <asp:Panel runat="server" id="Panel4" GroupingText="Matched Trades Confirmation Messaging" Width="840px" Font-Names="Cambria" Font-Size="Medium" BorderStyle="None" BorderWidth="1px">
    <table style="background-color:ivory;" width ="820px">
            <tr>
                    <td colspan ="2" align ="center">&nbsp;</td>

            </tr>
            <tr>
                <td align="center"><dx:ASPxLabel ID="ASPxLabel2" runat="server" Text="Direct Participants Notifications" Font-Names="Cambria" Font-Size="Small"></dx:ASPxLabel></td>
                <td align ="center"><dx:ASPxLabel ID="ASPxLabel6" runat="server" Text="Institutional Participants Notifications" Font-Names="Cambria" Font-Size="Small"></dx:ASPxLabel></td>
                <td align ="center"><dx:ASPxLabel ID="ASPxLabel5" runat="server" Text="Indirect Participants Notifications" Font-Names="Cambria" Font-Size="Small"></dx:ASPxLabel></td>
            </tr>

            <tr>
               <td align ="center">
                   <asp:RadioButton ID="RadioButton1" runat="server" AutoPostBack="True" Font-Names="Cambria" GroupName="TradesConfirmations" Text="Swift" Font-Size="Small" />
                   <asp:RadioButton ID="RadioButton2" runat="server" AutoPostBack="True" Font-Names="Cambria" GroupName="TradesConfirmations" Text="SMSs" Font-Size="Small" />
                   <asp:RadioButton ID="RadioButton5" runat="server" AutoPostBack="True" Font-Names="Cambria" GroupName="TradesConfirmations" Text="Emails" Font-Size="Small" />
                </td>
                <td align="center">
                    <asp:RadioButton ID="RadioButton8" runat="server" AutoPostBack="True" Font-Names="Cambria" Font-Size="Small" GroupName="TradesConfirmations" Text="Swift" />
                    <asp:RadioButton ID="RadioButton6" runat="server" AutoPostBack="True" Font-Names="Cambria" GroupName="CashAccountsConfirmations" Text="SMSs" Font-Size="Small" />
                    <asp:RadioButton ID="RadioButton7" runat="server" AutoPostBack="True" Font-Names="Cambria" GroupName="CashAccountsConfirmations" Text="Emails" Font-Size="Small" />
                </td>

                <td align="center">
                    <asp:RadioButton ID="RadioButton3" runat="server" AutoPostBack="True" Font-Names="Cambria" GroupName="CashAccountsConfirmations" Text="SMSs" Font-Size="Small" />
                    <asp:RadioButton ID="RadioButton4" runat="server" AutoPostBack="True" Font-Names="Cambria" GroupName="CashAccountsConfirmations" Text="Emails" Font-Size="Small" />
                </td>
                </tr>
            <tr>
                    <td align="center"></td>
                <td align ="center"></td>

            </tr>
            <tr>
                    <td align="center">
                        <dx:ASPxButton ID="ASPxButton4" runat="server" Text="Save" Theme="BlackGlass">
                        </dx:ASPxButton>
                    </td>
                <td align ="center">
                    <dx:ASPxButton ID="ASPxButton5" runat="server" Text="Save" Theme="BlackGlass">
                    </dx:ASPxButton>
                    </td>
                <td align ="center">
                    <dx:ASPxButton ID="ASPxButton6" runat="server" Text="Save" Theme="BlackGlass">
                    </dx:ASPxButton>
                    </td>

            </tr>
    </table>


</asp:Panel>

    </asp:Panel>

                        </td>

                </tr>

        </table>
    
</div>
</asp:Content>

