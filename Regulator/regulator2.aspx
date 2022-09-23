<%@ Page Language="VB"  MasterPageFile="~/CDSUser.master" AutoEventWireup="false" CodeFile="regulator2.aspx.vb" Inherits="TransferSec_regulator2" title="Regulator" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxRibbon" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxFormLayout" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxRoundPanel" TagPrefix="dx" %>
<%@ Register namespace="BasicFrame.WebControls" tagprefix="WebControls" %>
<%@ Register assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxGridView" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxPanel" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxDocking" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxPopupControl" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxGridView" tagprefix="dx1" %>
<asp:Content id="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:panel runat="server" ScrollBars="Auto" Width="870px">

        <table style="background-color:ivory; width:100%;">
            <tr>
                        <td align="left"><dx:ASPxLabel ID="ASPxLabel1" runat="server" Text="Surveillance&gt;&gt;Surveillance" Font-Names="Cambria" Font-Size="Small" Theme="PlasticBlue"></dx:ASPxLabel></td>

                </tr>
            <tr>

                <td align="center">
                    
                    &nbsp;</td>
            </tr>
            <tr>
                <td align="center">
                    <dx:ASPxButton ID="ASPxButton1" runat="server" Text="Surveillance" Theme="MetropolisBlue" Width="316px">
                    </dx:ASPxButton>
                    <br />
                </td>
            </tr>
            <tr>
                    <td align="left">
                        <dx:ASPxPopupControl ID="ASPxPopupControl1" runat="server" Theme="PlasticBlue" ShowCollapseButton="True" ShowMaximizeButton="True" ShowPinButton="True" ShowRefreshButton="True" HeaderText="Surveillance">
                      
                              <FooterStyle BackColor="#3D5294" />
                      
                              <ContentCollection>
                                  <dx:PopupControlContentControl runat="server" SupportsDisabledAttribute="True">
                                      <iframe src="surve.aspx" frameborder="0"  width="1200px" height="600px"></iframe>
                                  </dx:PopupControlContentControl>
                              </ContentCollection>
                      
                              </dx:ASPxPopupControl>
                    </td>

            </tr>

        </table>
    </asp:panel>
</asp:Content>

