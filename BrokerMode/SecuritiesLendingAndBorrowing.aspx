<%@ Page Language="VB" MasterPageFile="~/CDSUser.master" AutoEventWireup="false" CodeFile="SecuritiesLendingAndBorrowing.aspx.vb" Inherits="BrokerMode_SecuritiesLendingAndBorrowing" title="Broker Home" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>


<%@ Register assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dx" %>


<%@ Register assembly="DevExpress.XtraCharts.v13.2.Web, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.XtraCharts.Web" tagprefix="dxchartsui" %>
<%@ Register assembly="DevExpress.XtraCharts.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.XtraCharts" tagprefix="cc1" %>


<asp:Content id="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
    <asp:Panel id="Panel1" runat="server">
    
<table style="border-right: #000033 thin solid; border-top: #000033 thin solid; border-left: #000033 thin solid; width: 832px; border-bottom: #000033 thin solid; background-color: #ffffff">
    <tr>
        <td style="width: 712px; height: 226px" valign="top">
            <table>
            <tr>
                <td style="width: 870px" align="center">
                    <asp:Label id="Label4" runat="server" backcolor="#8080FF" font-bold="True" font-names="Arial" width="848px"></asp:Label></td>
            </tr>
                               
            </table>
            <table>
                <tr>

                    <td colspan ="1">
                        &nbsp;</td>
                    <td colspan ="1">
                        &nbsp;</td>
                    <td colspan ="1">
                        &nbsp;</td>
                    <td colspan ="1">
                        &nbsp;</td>
                    <td colspan ="1">
                        &nbsp;</td>
                    <td colspan ="1">
                        &nbsp;</td>
                    <td colspan ="1"></td>
                    <td colspan ="1"></td>
                </tr>
                <tr>

                    <td colspan ="1">
                        <dx:ASPxLabel ID="ASPxLabel4" runat="server" Text="Client Name" Theme="Office2010Blue">
                        </dx:ASPxLabel>
                    </td>
                    <td colspan ="1">
                        <dx:ASPxTextBox ID="txtNameSearch" runat="server" Theme="Glass" Width="250px">
                        </dx:ASPxTextBox>
                    </td>
                    <td colspan ="1">
                        <dx:ASPxButton ID="btnNameSearch" runat="server" Text="&gt;&gt;" Theme="Glass" Width="45px">
                        </dx:ASPxButton>
                    </td>
                    <td colspan ="1">
                        &nbsp;</td>
                    <td colspan ="1">
                        &nbsp;</td>
                    <td colspan ="1"></td>
                </tr>
                <tr>

                    <td colspan ="1"></td>
                    <td colspan ="3">
                        <asp:ListBox ID="lstNamesSearch" runat="server" AutoPostBack="True" Width="474px"></asp:ListBox>
                    </td>
                    
                    <td colspan ="1"></td>
                    <td colspan ="1"></td>
                    <td colspan ="1"></td>
                    <td colspan ="1"></td>
                </tr>
                <tr>

                    <td colspan ="1">
                        <dx:ASPxLabel ID="ASPxLabel5" runat="server" Text="Client Type" Theme="Office2010Blue">
                        </dx:ASPxLabel>
                    </td>
                    <td colspan ="1">
                        <asp:DropDownList ID="cmbClientType" runat="server" AutoPostBack="True" Width="250px">
                        </asp:DropDownList>
                    </td>
                    <td colspan ="1">
                        <dx:ASPxLabel ID="ASPxLabel12" runat="server" Text="Client Code" Theme="Office2010Blue">
                        </dx:ASPxLabel>
                    </td>
                    <td colspan ="1">
                        <dx:ASPxTextBox ID="txtClientCode" runat="server" Theme="Glass" Width="155px">
                        </dx:ASPxTextBox>
                    </td>
                    <td colspan ="1">
                        <dx:ASPxLabel ID="ASPxLabel13" runat="server" Text="Client Name" Theme="Office2010Blue">
                        </dx:ASPxLabel>
                    </td>
                    <td colspan ="1">
                        <dx:ASPxTextBox ID="txtClientName" runat="server" Theme="Glass" Width="170px">
                        </dx:ASPxTextBox>
                    </td>
                    <td colspan ="1"></td>
                    <td colspan ="1"></td>
                </tr>
                <tr>

                    <td colspan ="1">
                        <dx:ASPxLabel ID="ASPxLabel7" runat="server" Text="Client Address" Theme="Office2010Blue">
                        </dx:ASPxLabel>
                    </td>
                    <td colspan ="1">
                        <asp:TextBox ID="txtAddress" runat="server" Height="59px" TextMode="MultiLine" Width="250px"></asp:TextBox>
                    </td>
                    <td colspan ="1">
                        <dx:ASPxLabel ID="ASPxLabel8" runat="server" Text="Bank" Theme="Office2010Blue">
                        </dx:ASPxLabel>
                    </td>
                    <td colspan ="1">
                        <dx:ASPxTextBox ID="txtBank" runat="server" Theme="Glass" Width="155px">
                        </dx:ASPxTextBox>
                    </td>
                    <td colspan ="1">
                        <dx:ASPxLabel ID="ASPxLabel9" runat="server" Text="Branch" Theme="Office2010Blue">
                        </dx:ASPxLabel>
                    </td>
                    <td colspan ="1">
                        <dx:ASPxTextBox ID="txtBranch" runat="server" Theme="Glass" Width="170px">
                        </dx:ASPxTextBox>
                    </td>
                    <td colspan ="1"></td>
                    <td colspan ="1"></td>
                </tr>
                <tr>

                    <td colspan ="1">
                        &nbsp;</td>
                    <td colspan ="1">
                        &nbsp;</td>
                    <td colspan ="1">
                        &nbsp;</td>
                    <td colspan ="1">
                        &nbsp;</td>
                    <td colspan ="1">
                        <dx:ASPxLabel ID="ASPxLabel10" runat="server" Text="Account" Theme="Office2010Blue">
                        </dx:ASPxLabel>
                    </td>
                    <td colspan ="1">
                        <dx:ASPxTextBox ID="txtAccountNo" runat="server" Theme="Glass" Width="170px">
                        </dx:ASPxTextBox>
                    </td>
                    <td colspan ="1"></td>
                    <td colspan ="1"></td>
                </tr>
                <tr>
                        <td colspan ="8" style="text-align:center;">
                            <dx:ASPxButton ID="ASPxButton1" runat="server" Text="save" Theme="BlackGlass" Width="200px">
                            </dx:ASPxButton>
                        </td>

                </tr>
                <tr>
                        <td colspan ="8" align ="center"><dx:ASPxGridView ID="grdBorrowers" runat="server" Theme="Office2003Blue" EnablePagingCallbackAnimation="True" TabIndex="5">
                            <SettingsBehavior FilterRowMode="OnClick" SortMode="Custom" />
                            <SettingsPager AlwaysShowPager="True">
                            </SettingsPager>
                            </dx:ASPxGridView></td>

                </tr>
                <tr>

                    <td colspan ="1">
                        &nbsp;</td>
                    <td colspan ="1">
                        &nbsp;</td>
                    <td colspan ="1"></td>
                    <td colspan ="1"></td>
                    <td colspan ="1"></td>
                    <td colspan ="1"></td>
                    <td colspan ="1"></td>
                    <td colspan ="1"></td>
                </tr>
                
                <tr>
                        <td colspan ="1"></td>
                    <td colspan ="1"></td>
                    <td colspan ="1"></td>
                    <td colspan ="1"></td>
                    <td colspan ="1"></td>
                    <td colspan ="1"></td>
                    <td colspan ="1"></td>
                    <td colspan ="1"></td>

                </tr>
                <tr>
                        <td colspan ="1"></td>
                    <td colspan ="1"></td>
                    <td colspan ="1"></td>
                    <td colspan ="1"></td>
                    <td colspan ="1"></td>
                    <td colspan ="1"></td>
                    <td colspan ="1"></td>
                    <td colspan ="1">
                        <dx:ASPxButton ID="btnNext" runat="server" Text="next" Theme="SoftOrange" Width="85px">
                        </dx:ASPxButton>
                        </td>

                </tr>
            </table>
            <table>
                <tr>
                    <td></td>
                </tr>
            </table>
            <table>
                <tr>
                    <td style="width: 850px" align="center">
                        </td>                
                </tr>
            </table>
        </td>
    </tr>
</table>
</asp:Panel>
</div>
</asp:Content>

