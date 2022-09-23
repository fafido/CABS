<%@ Page Language="VB"  MasterPageFile="~/CDSUser.master" AutoEventWireup="false" CodeFile="regulatordates.aspx.vb" Inherits="TransferSec_regulatordates" title="Regulator" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxRibbon" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxFormLayout" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxRoundPanel" TagPrefix="dx" %>
<%@ Register namespace="BasicFrame.WebControls" tagprefix="WebControls" %>
<%@ Register assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxGridView" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxPanel" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxDocking" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxPopupControl" tagprefix="dx" %>
<asp:Content id="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:panel runat="server" ScrollBars="Auto">

        <table style="background-color:ivory; width:100%;">
            <tr>
                        <td colspan ="8" align="center">&nbsp;</td>

                </tr>
            <tr>

                <td colspan ="8" align="left">
                    <table class="dxflInternalEditorTable_PlasticBlue">
                        <tr>
                            <td align="center" colspan="2">
                                <dx:ASPxButton ID="ASPxButton11" runat="server" Text="Change Dates" Theme="iOS" Visible="True">
                                </dx:ASPxButton>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="2">
                                <dx:ASPxRoundPanel ID="ASPxRoundPanel10" runat="server" HeaderText="Criteria Selection" HorizontalAlign="Center" Theme="iOS" Width="100%" Visible="False">
                                    <PanelCollection>
                                        <dx:PanelContent runat="server" SupportsDisabledAttribute="True">
                                            <table class="dxflInternalEditorTable" style="width:100%">
                                                <tr>
                                                    <td align="left" style="height: 18px; width: 91px;">Opening Date</td>
                                                    <td align="left" style="height: 18px">
                                                        <dx:ASPxDateEdit ID="ASPxDateEdit1" runat="server">
                                                        </dx:ASPxDateEdit>
                                                    </td>
                                                    <td align="left" style="height: 18px"></td>
                                                </tr>
                                                <tr>
                                                    <td align="left" style="height: 18px; width: 91px;">Closing Date</td>
                                                    <td align="left" style="height: 18px">
                                                        <dx:ASPxDateEdit ID="ASPxDateEdit2" runat="server">
                                                        </dx:ASPxDateEdit>
                                                    </td>
                                                    <td align="left" style="height: 18px"></td>
                                                </tr>
                                                <tr>
                                                    <td align="left" style="height: 18px; width: 91px;"></td>
                                                    <td align="left" style="height: 18px">
                                                        <dx:ASPxButton ID="ASPxButton19" runat="server" Font-Size="X-Small" Height="16px" Text="View" Theme="iOS">
                                                        </dx:ASPxButton>
                                                    </td>
                                                    <td align="left" style="height: 18px"></td>
                                                </tr>
                                            </table>
                                            <br />
                                        </dx:PanelContent>
                                    </PanelCollection>
                                </dx:ASPxRoundPanel>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:ScriptManager ID="ScriptManager1" runat="server">
                                </asp:ScriptManager>
                                <asp:Timer ID="Timer1" runat="server" Interval="30000" Enabled="False">
                                </asp:Timer>
                            </td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <dx:ASPxRoundPanel ID="ASPxRoundPanel2" runat="server" HeaderText="Buy Orders" HorizontalAlign="Center" Theme="iOS" Width="100%">
                                    <PanelCollection>
                                        <dx:PanelContent runat="server" SupportsDisabledAttribute="True">
                                            <dx:ASPxGridView ID="grdOrdersSummary0" runat="server" EnableTheming="True" Font-Names="Cambria" Font-Size="Small" Theme="PlasticBlue" Width="100%" AutoGenerateColumns="False">
                                                <Columns>
                                                    <dx:GridViewDataTextColumn FieldName="Broker" Name="Broker" ShowInCustomizationForm="True" VisibleIndex="0">
                                                    </dx:GridViewDataTextColumn>
                                                    <dx:GridViewDataTextColumn FieldName="Counter" Name="Counter" ShowInCustomizationForm="True" VisibleIndex="1">
                                                    </dx:GridViewDataTextColumn>
                                                    <dx:GridViewDataTextColumn FieldName="Price" Name="Price" ShowInCustomizationForm="True" VisibleIndex="2">
                                                    </dx:GridViewDataTextColumn>
                                                    <dx:GridViewDataTextColumn FieldName="Quantity" Name="Quantity" ShowInCustomizationForm="True" VisibleIndex="3">
                                                    </dx:GridViewDataTextColumn>
                                                    <dx:GridViewDataTextColumn FieldName="Value" Name="Value" ShowInCustomizationForm="True" VisibleIndex="4">
                                                    </dx:GridViewDataTextColumn>
                                                </Columns>
                                                <Settings VerticalScrollBarMode="Visible" />
                                            </dx:ASPxGridView>
                                            <br />
                                            <dx:ASPxButton ID="ASPxButton4" runat="server" Text="More Details" Theme="iOS">
                                            </dx:ASPxButton>
                                            <br />
                                        </dx:PanelContent>
                                    </PanelCollection>
                                </dx:ASPxRoundPanel>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <dx:ASPxRoundPanel ID="ASPxRoundPanel7" runat="server" HeaderText="Sell Orders" HorizontalAlign="Center" Theme="iOS" Width="100%">
                                    <PanelCollection>
                                        <dx:PanelContent runat="server" SupportsDisabledAttribute="True">
                                            <dx:ASPxGridView ID="grdOrdersSummary9" runat="server" EnableTheming="True" Font-Names="Cambria" Font-Size="Small" Theme="PlasticBlue" Width="100%" AutoGenerateColumns="False">
                                                <Columns>
                                                    <dx:GridViewDataTextColumn FieldName="Broker" Name="Broker" ShowInCustomizationForm="True" VisibleIndex="0">
                                                    </dx:GridViewDataTextColumn>
                                                    <dx:GridViewDataTextColumn FieldName="Counter" Name="Counter" ShowInCustomizationForm="True" VisibleIndex="1">
                                                    </dx:GridViewDataTextColumn>
                                                    <dx:GridViewDataTextColumn FieldName="Price" Name="Price" ShowInCustomizationForm="True" VisibleIndex="2">
                                                    </dx:GridViewDataTextColumn>
                                                    <dx:GridViewDataTextColumn FieldName="Quantity" Name="Quantity" ShowInCustomizationForm="True" VisibleIndex="3">
                                                    </dx:GridViewDataTextColumn>
                                                    <dx:GridViewDataTextColumn FieldName="Value" Name="Value" ShowInCustomizationForm="True" VisibleIndex="4">
                                                    </dx:GridViewDataTextColumn>
                                                </Columns>
                                                <Settings VerticalScrollBarMode="Visible" />
                                            </dx:ASPxGridView>
                                            <br />
                                            <dx:ASPxButton ID="ASPxButton15" runat="server" Text="More Details" Theme="iOS">
                                            </dx:ASPxButton>
                                            <br />
                                        </dx:PanelContent>
                                    </PanelCollection>
                                </dx:ASPxRoundPanel>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <dx:ASPxRoundPanel ID="ASPxRoundPanel8" runat="server" HeaderText="Matched Orders" HorizontalAlign="Center" Theme="iOS" Width="100%">
                                    <PanelCollection>
                                        <dx:PanelContent runat="server" SupportsDisabledAttribute="True">
                                            <dx:ASPxGridView ID="grdOrdersSummary10" runat="server" EnableTheming="True" Font-Names="Cambria" Font-Size="Small" Theme="PlasticBlue" Width="100%">
                                                <Settings VerticalScrollBarMode="Visible" />
                                            </dx:ASPxGridView>
                                            <br />
                                            <dx:ASPxButton ID="ASPxButton16" runat="server" Text="More Details" Theme="iOS">
                                            </dx:ASPxButton>
                                            <br />
                                        </dx:PanelContent>
                                    </PanelCollection>
                                </dx:ASPxRoundPanel>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="2">
                                <dx:ASPxRoundPanel ID="ASPxRoundPanel6" runat="server" Theme="iOS" Width="100%" HeaderText="Market Activity">
                                    <PanelCollection>
                                        <dx:PanelContent runat="server" SupportsDisabledAttribute="True">
                                            <dx:ASPxGridView ID="grdOrdersSummary5" runat="server" EnableTheming="True" Font-Names="Cambria" Font-Size="Small" Theme="PlasticBlue" Width="100%">
                                            </dx:ASPxGridView>
                                        </dx:PanelContent>
                                    </PanelCollection>
                                </dx:ASPxRoundPanel>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="2">
                                <dx:ASPxRoundPanel ID="ASPxRoundPanel9" runat="server" HeaderText="Market Viewer" Theme="iOS" Width="100%">
                                    <PanelCollection>
                                        <dx:PanelContent runat="server" SupportsDisabledAttribute="True">
                                            <dx:ASPxGridView ID="grdOrdersSummary11" runat="server" EnableTheming="True" Font-Names="Cambria" Font-Size="Small" Theme="PlasticBlue" Width="100%">
                                            </dx:ASPxGridView>
                                        </dx:PanelContent>
                                    </PanelCollection>
                                </dx:ASPxRoundPanel>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                    <td colspan ="8" align="center" style="height: 18px">
                        &nbsp;</td>

            </tr>
            <tr>
                <td colspan ="8" align ="center">
                    &nbsp;</td>
            </tr>
                <tr>
                        <td colspan ="8" align="center">&nbsp;</td>

                </tr>
            <tr>

                <td colspan ="8" align="center">&nbsp;</td>
            </tr>
            <tr>
                    <td colspan ="8" align="center">&nbsp;</td>

            </tr>
            <tr>
                <td colspan ="8" align ="center">
                    &nbsp;</td>
            </tr>
            
            <tr>
                        <td colspan ="8" align="center">&nbsp;</td>

                </tr>
            <tr>

                <td colspan ="8" align="center">&nbsp;</td>
            </tr>
            
           
            <tr>
                <td colspan ="8" align="center">
                    &nbsp;</td>

            </tr>

        </table>
    </asp:panel>
</asp:Content>

