<%@ Page Language="VB" MasterPageFile="~/CDSUser.master" AutoEventWireup="false" CodeFile="derivatives.aspx.vb" Inherits="BA_derivatives" title="Available Derivatives" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<%@ Register assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxRoundPanel" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxPanel" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.Aspxdateedit" tagprefix="dx" %>


<%@ Register assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxFormLayout" tagprefix="dx" %>


<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxRibbon" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxFormLayout" TagPrefix="dx" %>

<%@ Register namespace="BasicFrame.WebControls" tagprefix="WebControls" %>

   



<%@ Register assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxDocking" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxPopupControl" tagprefix="dx" %>

   



<%@ Register assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxUploadControl" tagprefix="dx" %>

   



<%@ Register assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxLoadingPanel" tagprefix="dx" %>

  



<%@ Register assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxGridView.Export" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxRibbon" tagprefix="dx1" %>
<asp:Content id="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
    <asp:Panel id="Panel1" runat="server" Width="840px" Font-Names="Arial" Font-Size="Medium" BackColor="White">
    
        <table width ="810px">
            <tr>
                   <td style ="text-align :left;" align="left">
                       <dx:ASPxLabel ID="ASPxLabel1" runat="server" Text="CDS&gt;&gt;Available WDR" Font-Names="Cambria" Font-Size="Small" Theme="PlasticBlue"></dx:ASPxLabel>

                   </td>
            </tr>
        </table>
        <asp:panel id="Panel2" runat="server" GroupingText="Deposits" Font-Names="Cambria">
        <table width="810px">
            <tr>
                <td colspan="1" style="height: 18px; width: 112px;">
                    <dx:ASPxLabel ID="ASPxLabel80" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Search WDR." Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                <td style="height: 18px; width: 253px;">
                    <table class="auto-style1">
                        <tr>
                            <td style="width: 238px">
                                <dx:ASPxTextBox ID="txtcompany_name" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="250px">
                                </dx:ASPxTextBox>
                            </td>
                            <td>
                                <dx:ASPxButton ID="ASPxButton5" runat="server" Text="Search" Theme="BlackGlass">
                                </dx:ASPxButton>
                            </td>
                        </tr>
                    </table>
                </td>
                <td colspan="1" style="height: 18px">
                    &nbsp;</td>
                <td colspan="1" style="height: 18px"></td>
                <td colspan="1" style="height: 18px"></td>
                <td colspan="1" style="height: 18px"></td>
            </tr>
            <tr>
                <td colspan="1" style="height: 18px; width: 112px;">
                    <dx:ASPxLabel ID="ASPxLabel79" runat="server" Font-Names="Cambria" Font-Size="Small"  Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                <td colspan="5" style="height: 18px; ">
                    <table class="auto-style1" style="width: 48%">
                        <tr>
                            <td>
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td colspan="1" style="height: 18px; width: 112px;">&nbsp;</td>
                <td colspan="5" style="height: 18px; ">&nbsp;</td>
            </tr>
            <tr>
                <td colspan="6" style="height: 18px; ">
                    <dx:ASPxLabel ID="ASPxLabel81" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Available Deposits" Theme="iOS">
                    </dx:ASPxLabel>
                </td>
            </tr>
            <tr>
                <td align="right" colspan="6" style="height: 18px; ">
                    <table class="auto-style1" style="width: 14%; margin-left: 0px;">
                        <tr>
                            <td>
                                <dx:ASPxButton ID="ASPxButton4" runat="server" BackColor="#023E5A" Height="20px" Text="View Rejected Deposits" Theme="BlackGlass" Width="180px">
                                </dx:ASPxButton>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                    <td align="right"  colspan ="6" align="center">
                        <dx:ASPxGridView ID="ASPxGridView2"  runat="server" KeyFieldName="Contract No." Settings-ShowTitlePanel="true" SettingsText-Title="Deposits" Theme="Glass" Width="100%">
                            <SettingsBehavior AllowSelectByRowClick="True" AllowSelectSingleRowOnly="True" ProcessSelectionChangedOnServer="True" />
                            <SettingsPager Visible="False">
                            </SettingsPager>
                            <Settings ShowTitlePanel="True" />
                            <SettingsText Title="Deposits" />
                            <SettingsPopup>
                                <EditForm AllowResize="True" Modal="True" />
                            </SettingsPopup>
                            <SettingsCommandButton>
                                <SelectButton Text="Select">
                                </SelectButton>
                            </SettingsCommandButton>
                        </dx:ASPxGridView>
                    </td>


            </tr>
            <tr>
                <td  align="center" colspan="6">
                    <br />
                    <dx:ASPxButton ID="btnSaveContract0" runat="server" Text="view" Theme="BlackGlass">
                    </dx:ASPxButton>
                    <br />
                </td>
            </tr>
            <tr>
                <td align="right" align="center" colspan="6">
                    <dx:ASPxPopupControl ID="ASPxPopupControl1" runat="server" BackColor="#DDECFE" CloseAction="CloseButton" EnableCallbackAnimation="True" HeaderText="Derivatives Contract" ShowCollapseButton="True" ShowMaximizeButton="True" ShowPageScrollbarWhenModal="True" ShowPinButton="True" ShowRefreshButton="True" Theme="Office2003Blue" Width="718px">
        <contentcollection>
<dx:PopupControlContentControl runat="server" SupportsDisabledAttribute="True">
    <dx:ASPxRoundPanel ID="ASPxRoundPanel6" runat="server" ShowHeader="False" Theme="Office2003Blue" Width="100%">
        <panelcollection>
            <dx:PanelContent runat="server" SupportsDisabledAttribute="True">
                <table class="dxflInternalEditorTable_Moderno" style="width: 100%">
                    <tr>
                        <td align="right" style="width: 230px">
                            <dx:ASPxLabel ID="ASPxLabel60" runat="server" Text="OTP" Theme="iOS">
                            </dx:ASPxLabel>
                        </td>
                        <td align="left">
                            <dx:ASPxTextBox ID="txtwritername" runat="server" DisplayFormatString="n" Theme="iOS" Width="280px" ReadOnly="True">
                            </dx:ASPxTextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" style="width: 230px">&nbsp;</td>
                        <td align="left">
                            <dx:ASPxButton ID="btnSaveContract1" runat="server" Text="Submit" Theme="Glass">
                            </dx:ASPxButton>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" colspan="2">
                            <br />
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td align="left" colspan="2">&#160;</td>
                    </tr>
                </table>
            </dx:PanelContent>
        </panelcollection>
    </dx:ASPxRoundPanel>
            </dx:PopupControlContentControl>
</contentcollection>
    </dx:ASPxPopupControl>
                </td>
            </tr>
      </table>

    </asp:panel>
                 
</asp:Panel>
  
</div>
</asp:Content>

