<%@ Page Language="VB" MasterPageFile="~/CDSUser.master" AutoEventWireup="false" CodeFile="BankingDetailsSetUp.aspx.vb" Inherits="BrokerMode_BankingDetailsSetUp" title="Broker Home" %>

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
                    <dx:ASPxLabel ID="ASPxLabel36" runat="server" Text="Bank Name" Theme="Office2010Blue">
                    </dx:ASPxLabel>
                </td>
                <td colspan ="1">
                    <dx:ASPxComboBox ID="cmbBank" runat="server" Theme="Glass" ValueType="System.String" Width="200px">
                    </dx:ASPxComboBox>
                </td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>

            </tr>
                   <tr>
                <td colspan ="1">
                    <dx:ASPxLabel ID="ASPxLabel37" runat="server" Text="Bank Name" Theme="Office2010Blue">
                    </dx:ASPxLabel>
                       </td>
                <td colspan ="1">
                    <dx:ASPxTextBox ID="txtBankName" runat="server" Theme="Office2010Blue" Width="200px">
                    </dx:ASPxTextBox>
                       </td>
                <td colspan ="1">
                    <dx:ASPxLabel ID="ASPxLabel38" runat="server" Text="Bank Code" Theme="Office2010Blue">
                    </dx:ASPxLabel>
                       </td>
                <td colspan ="1">
                    <dx:ASPxTextBox ID="txtBankCde" runat="server" Theme="Office2010Blue" Width="200px">
                    </dx:ASPxTextBox>
                       </td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>

            </tr>
                   <tr>
                <td colspan ="1">
                    <dx:ASPxLabel ID="ASPxLabel39" runat="server" Text="Bank Country" Theme="Office2010Blue">
                    </dx:ASPxLabel>
                       </td>
                <td colspan ="1">
                    <dx:ASPxComboBox ID="cmbCountry" runat="server" Theme="Glass" ValueType="System.String" Width="200px">
                    </dx:ASPxComboBox>
                       </td>
                <td colspan ="1">
                    <dx:ASPxLabel ID="ASPxLabel45" runat="server" Text="Country Code" Theme="Office2010Blue">
                    </dx:ASPxLabel>
                       </td>
                <td colspan ="1">
                    <dx:ASPxTextBox ID="txtCountryCode" runat="server" Theme="Office2010Blue" Width="200px">
                    </dx:ASPxTextBox>
                       </td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>

            </tr>
                   <tr>
                <td colspan ="1" style="height: 18px">
                       </td>
                <td colspan ="1" style="height: 18px">
                       </td>
                <td colspan ="1" style="height: 18px">
                    <dx:ASPxButton ID="btnSave0" runat="server" Text="save" Theme="BlackGlass">
                    </dx:ASPxButton>
                       </td>
                <td colspan ="1" style="height: 18px"></td>
                <td colspan ="1" style="height: 18px"></td>
                <td colspan ="1" style="height: 18px"></td>
                <td colspan ="1" style="height: 18px"></td>
                <td colspan ="1" style="height: 18px"></td>

            </tr>
                <tr>
                    <td colspan ="8" align="center">
                        <dx:ASPxGridView ID="ASPxGridView1" runat="server" Theme="Glass" Width="549px">
                        </dx:ASPxGridView>
                    </td>
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
                <td colspan ="1">
                    <dx:ASPxLabel ID="ASPxLabel40" runat="server" Text="Bank Name" Theme="Office2010Blue">
                    </dx:ASPxLabel>
                       </td>
                <td colspan ="1">
                    <dx:ASPxComboBox ID="cmbBankNameBr" runat="server" Theme="Glass" ValueType="System.String" Width="200px">
                    </dx:ASPxComboBox>
                       </td>
                <td colspan ="1">
                    <dx:ASPxLabel ID="lblBankCode" runat="server" Theme="iOS">
                    </dx:ASPxLabel>
                       </td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>

            </tr>
                 <tr>
                <td colspan ="1">
                    <dx:ASPxLabel ID="ASPxLabel41" runat="server" Text="Branch Name" Theme="Office2010Blue">
                    </dx:ASPxLabel>
                     </td>
                <td colspan ="1">
                    <dx:ASPxTextBox ID="txtBranch" runat="server" Theme="Office2010Blue" Width="200px">
                    </dx:ASPxTextBox>
                     </td>
                <td colspan ="1">
                    <dx:ASPxLabel ID="ASPxLabel42" runat="server" Text="Branch Code" Theme="Office2010Blue">
                    </dx:ASPxLabel>
                     </td>
                <td colspan ="1">
                    <dx:ASPxTextBox ID="txtTradingLimit3" runat="server" Theme="Office2010Blue" Width="200px">
                    </dx:ASPxTextBox>
                     </td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>

            </tr>
                 <tr>
                <td colspan ="1">
                    <dx:ASPxLabel ID="ASPxLabel43" runat="server" Text="Branch City" Theme="Office2010Blue">
                    </dx:ASPxLabel>
                     </td>
                <td colspan ="1">
                    <dx:ASPxComboBox ID="cmbCountryCode1" runat="server" Theme="Glass" ValueType="System.String" Width="200px">
                    </dx:ASPxComboBox>
                     </td>
                <td colspan ="1">
                    <dx:ASPxLabel ID="ASPxLabel44" runat="server" Text="City Code" Theme="Office2010Blue">
                    </dx:ASPxLabel>
                     </td>
                <td colspan ="1">
                    <dx:ASPxTextBox ID="txtTradingLimit4" runat="server" Theme="Office2010Blue" Width="200px">
                    </dx:ASPxTextBox>
                     </td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>

            </tr>
                 <tr>
                <td colspan ="1">
                    &nbsp;</td>
                <td colspan ="1">
                    &nbsp;</td>
                <td colspan ="1">
                    <dx:ASPxButton ID="btnSave" runat="server" Text="save" Theme="BlackGlass">
                    </dx:ASPxButton>
                     </td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>

            </tr>
              
          
                <tr>
                        <td colspan ="8" align="center">
                            <dx:ASPxGridView ID="grdRules" runat="server" Theme="Glass" Width="666px">
                                <SettingsPager AlwaysShowPager="True">
                                </SettingsPager>
                            </dx:ASPxGridView>
                        </td>

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
                        <td colspan ="1"></td>
                    <td colspan ="3">
                        &nbsp;</td>
                    
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
                    <td colspan ="1">&nbsp;</td>
                    <td colspan ="1"></td>
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
                        &nbsp;</td>
                    <td colspan ="1">
                        &nbsp;</td>
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
                        <td colspan ="8" style="text-align:center;">
                            &nbsp;</td>

                </tr>
                <tr>
                        <td colspan ="8" style=" align-items :center;">&nbsp;</td>

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
                    <td colspan ="1"></td>

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

