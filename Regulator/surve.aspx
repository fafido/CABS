<%@ Page Language="VB" AutoEventWireup="false" CodeFile="surve.aspx.vb" Inherits="Regulator_surve" %>

<%@ Register Assembly="BasicFrame.WebControls.BasicDatePicker" Namespace="BasicFrame.WebControls" TagPrefix="BDP" %>
<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxTabControl" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxClasses" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxRibbon" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxFormLayout" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxRoundPanel" TagPrefix="dx" %>
<%@ Register Namespace="BasicFrame.WebControls" TagPrefix="WebControls" %>
<%@ Register Assembly="BasicFrame.WebControls.BasicDatePicker" Namespace="BasicFrame.WebControls" TagPrefix="BDP" %>
<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxPanel" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxDocking" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxPopupControl" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView.Export" TagPrefix="dx" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1z {
            width: 800px;
        }

        .auto-style4z {
            width: 70px;
        }

        .auto-style5z {
            width: 182px;
        }

        .auto-style6z {
            height: 46px;
        }

        .auto-style7z {
            height: 43px;
        }

        .auto-style8 {
            width: 1126px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <table class="auto-style1z">
                <tr>
                    <td align="center">
                        <table>
                            <tr>
                                <td align="left" class="auto-style7z">
                                    <table class="dxeLyGroup_MetropolisBlue">
                                        <tr>
                                            <td>
                                                <asp:Image ID="Image1" runat="server" Height="78px" ImageUrl="~/Images/logofin.png" Width="199px" />
                                            </td>
                                            <td align="right">
                                                <asp:Image ID="Image2" runat="server" Height="106px" ImageUrl="~/Images/secz.png" Width="120px" Visible="False" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" style="background-color: #003E7A">
                                    <dx:ASPxLabel ID="ASPxLabel1" runat="server" Font-Bold="False" Font-Names="Franklin Gothic Medium" Font-Size="Large" ForeColor="White" Text="SURVEILLANCE">
                                    </dx:ASPxLabel>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" style="border-style: solid; border-width: 0.5px">
                                    <dx:ASPxPageControl ID="ASPxPageControl1" runat="server" ActiveTabIndex="11" Theme="Moderno">
                                        <TabPages>
                                            <dx:TabPage Text="Buy Orders">
                                                <ContentCollection>
                                                    <dx:ContentControl runat="server" SupportsDisabledAttribute="True">
                                                        <table class="dxflInternalEditorTable_PlasticBlue" style="height: 594px">
                                                            <tr>
                                                                <td class="auto-style6z">
                                                                    <table class="dxflInternalEditorTable_PlasticBlue" style="width: 600px">
                                                                        <tr>
                                                                            <td align="left" class="auto-style4z">
                                                                                <asp:Label ID="Label1" runat="server" Text="Date From"></asp:Label>
                                                                            </td>
                                                                            <td align="left">
                                                                                <dx:ASPxDateEdit ID="ASPxDateEdit1" runat="server" Theme="PlasticBlue" DisplayFormatString="dd MMM yyyy" EditFormatString="dd MMM yyyy">
                                                                                </dx:ASPxDateEdit>
                                                                            </td>
                                                                            <td>
                                                                                <asp:Label ID="Label2" runat="server" Text="Date to"></asp:Label>
                                                                            </td>
                                                                            <td class="auto-style5z">
                                                                                <dx:ASPxDateEdit ID="ASPxDateEdit2" runat="server" Theme="PlasticBlue" DisplayFormatString="dd MMM yyyy" EditFormatString="dd MMM yyyy">
                                                                                </dx:ASPxDateEdit>
                                                                            </td>
                                                                            <td>
                                                                                <dx:ASPxButton ID="ASPxButton1" runat="server" Text="Filter" Theme="MetropolisBlue">
                                                                                </dx:ASPxButton>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td valign="top">
                                                                    <dx:ASPxGridView ID="grdOrdersSummary0" runat="server" AutoGenerateColumns="False" EnableTheming="True" Font-Names="Cambria" Font-Size="Small" Theme="PlasticBlue" Width="1100px">
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


                                                                                <PropertiesTextEdit DisplayFormatString="C2">
                                                                                </PropertiesTextEdit>
                                                                            </dx:GridViewDataTextColumn>
                                                                            <dx:GridViewDataTextColumn FieldName="Date" Name="Order Date" ShowInCustomizationForm="True" VisibleIndex="4">
                                                                            </dx:GridViewDataTextColumn>
                                                                        </Columns>
                                                                        <SettingsPager PageSize="19">
                                                                        </SettingsPager>
                                                                        <Settings VerticalScrollBarMode="Visible" VerticalScrollableHeight="500" ShowFilterRow="True" ShowFilterRowMenuLikeItem="True" />
                                                                    </dx:ASPxGridView>
                                                                    <br />
                                                                    <dx:ASPxButton ID="ASPxButton8" runat="server" Text="Export ">
                                                                    </dx:ASPxButton>
                                                                    <dx:ASPxGridViewExporter ID="ASPxGridViewExporter1" GridViewID="grdOrdersSummary0" runat="server">
                                                                    </dx:ASPxGridViewExporter>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </dx:ContentControl>
                                                </ContentCollection>
                                            </dx:TabPage>
                                            <dx:TabPage Name="Sell Orders" Text="Sell Orders">
                                                <ContentCollection>
                                                    <dx:ContentControl runat="server" SupportsDisabledAttribute="True">
                                                        <table class="dxflInternalEditorTable_Moderno">
                                                            <tr>
                                                                <td>
                                                                    <table class="dxflInternalEditorTable_PlasticBlue" style="width: 600px">
                                                                        <tr>
                                                                            <td align="left" class="auto-style4z">
                                                                                <asp:Label ID="Label3" runat="server" Text="Date From"></asp:Label>
                                                                            </td>
                                                                            <td align="left">
                                                                                <dx:ASPxDateEdit ID="ASPxDateEdit3" runat="server" Theme="PlasticBlue" DisplayFormatString="dd MMM yyyy" EditFormatString="dd MMM yyyy">
                                                                                </dx:ASPxDateEdit>
                                                                            </td>
                                                                            <td>
                                                                                <asp:Label ID="Label4" runat="server" Text="Date to"></asp:Label>
                                                                            </td>
                                                                            <td class="auto-style5z">
                                                                                <dx:ASPxDateEdit ID="ASPxDateEdit4" runat="server" Theme="PlasticBlue" DisplayFormatString="dd MMM yyyy" EditFormatString="dd MMM yyyy">
                                                                                </dx:ASPxDateEdit>
                                                                            </td>
                                                                            <td>
                                                                                <dx:ASPxButton ID="ASPxButton2" runat="server" Text="Filter" Theme="MetropolisBlue">
                                                                                </dx:ASPxButton>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <dx:ASPxGridView ID="grdOrdersSummary9" runat="server" EnableTheming="True" Font-Names="Cambria" Font-Size="Small" Theme="PlasticBlue" Width="1100px" AutoGenerateColumns="False">
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


                                                                                <PropertiesTextEdit DisplayFormatString="C2">
                                                                                </PropertiesTextEdit>
                                                                            </dx:GridViewDataTextColumn>
                                                                            <dx:GridViewDataTextColumn FieldName="Date" Name="Date" ShowInCustomizationForm="True" VisibleIndex="4">
                                                                            </dx:GridViewDataTextColumn>
                                                                        </Columns>
                                                                        <SettingsPager PageSize="19">
                                                                        </SettingsPager>
                                                                        <Settings VerticalScrollBarMode="Visible" VerticalScrollableHeight="500" ShowFilterRow="True" ShowFilterRowMenuLikeItem="True" />
                                                                    </dx:ASPxGridView>
                                                                    <br />
                                                                    <dx:ASPxButton ID="ASPxButton9" runat="server" Text="Export ">
                                                                    </dx:ASPxButton>
                                                                    <br />
                                                                    <dx:ASPxGridViewExporter ID="ASPxGridViewExporter2" runat="server" GridViewID="grdOrdersSummary9">
                                                                    </dx:ASPxGridViewExporter>
                                                                    <br />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </dx:ContentControl>
                                                </ContentCollection>
                                            </dx:TabPage>
                                            <dx:TabPage Name="Matched Orders" Text="Matched Orders">
                                                <ContentCollection>
                                                    <dx:ContentControl runat="server" SupportsDisabledAttribute="True">
                                                        <table class="dxflInternalEditorTable_PlasticBlue">
                                                            <tr>
                                                                <td>
                                                                    <table class="dxflInternalEditorTable_PlasticBlue" style="width: 600px">
                                                                        <tr>
                                                                            <td align="left" class="auto-style4z">
                                                                                <asp:Label ID="Label5" runat="server" Text="Date From"></asp:Label>
                                                                            </td>
                                                                            <td align="left">
                                                                                <dx:ASPxDateEdit ID="ASPxDateEdit5" runat="server" Theme="PlasticBlue" DisplayFormatString="dd MMM yyyy" EditFormatString="dd MMM yyyy">
                                                                                </dx:ASPxDateEdit>
                                                                            </td>
                                                                            <td>
                                                                                <asp:Label ID="Label6" runat="server" Text="Date to"></asp:Label>
                                                                            </td>
                                                                            <td class="auto-style5z">
                                                                                <dx:ASPxDateEdit ID="ASPxDateEdit6" runat="server" Theme="PlasticBlue" DisplayFormatString="dd MMM yyyy" EditFormatString="dd MMM yyyy">
                                                                                </dx:ASPxDateEdit>
                                                                            </td>
                                                                            <td>
                                                                                <dx:ASPxButton ID="ASPxButton3" runat="server" Text="Filter" Theme="MetropolisBlue">
                                                                                </dx:ASPxButton>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <dx:ASPxGridView ID="grdOrdersSummary10" runat="server" EnableTheming="True" Font-Names="Cambria" Font-Size="Small" Theme="PlasticBlue" Width="1100px">
                                                                        <SettingsPager PageSize="19">
                                                                        </SettingsPager>
                                                                        <Settings VerticalScrollableHeight="500" VerticalScrollBarMode="Visible" ShowFilterRow="True" />
                                                                    </dx:ASPxGridView>
                                                                    <br />
                                                                    <dx:ASPxButton ID="ASPxButton10" runat="server" Text="Export ">
                                                                    </dx:ASPxButton>
                                                                    <br />
                                                                    <br />
                                                                    <dx:ASPxGridViewExporter ID="ASPxGridViewExporter3" runat="server" GridViewID="grdOrdersSummary10">
                                                                    </dx:ASPxGridViewExporter>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </dx:ContentControl>
                                                </ContentCollection>
                                            </dx:TabPage>
                                            <dx:TabPage Name="Market Activity" Text="Market Activity" Enabled="False" Visible="False">
                                                <ContentCollection>
                                                    <dx:ContentControl runat="server" SupportsDisabledAttribute="True">
                                                        <table class="dxflInternalEditorTable_Moderno">
                                                            <tr>
                                                                <td>&nbsp;</td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <dx:ASPxGridView ID="grdOrdersSummary5" runat="server" EnableTheming="True" Font-Names="Cambria" Font-Size="Small" Theme="PlasticBlue" Width="1100px">
                                                                    </dx:ASPxGridView>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </dx:ContentControl>
                                                </ContentCollection>
                                            </dx:TabPage>
                                            <dx:TabPage Name="Market Statistics" Text="Market Statistics">
                                                <ContentCollection>
                                                    <dx:ContentControl runat="server" SupportsDisabledAttribute="True">
                                                        <table class="dxflInternalEditorTable_Moderno">
                                                            <tr>
                                                                <td>&nbsp;</td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <dx:ASPxGridView ID="grdOrdersSummary11" runat="server" EnableTheming="True" Font-Names="Cambria" Font-Size="Small" Theme="PlasticBlue" Width="1100px">
                                                                        <Settings ShowFilterRow="True" />
                                                                    </dx:ASPxGridView>
                                                                    <br />
                                                                    <dx:ASPxButton ID="ASPxButton11" runat="server" Text="Export ">
                                                                    </dx:ASPxButton>
                                                                    <br />
                                                                    <br />
                                                                    <dx:ASPxGridViewExporter ID="ASPxGridViewExporter4" runat="server" GridViewID="grdOrdersSummary11">
                                                                    </dx:ASPxGridViewExporter>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </dx:ContentControl>
                                                </ContentCollection>
                                            </dx:TabPage>
                                            <dx:TabPage Text="Settlement(Sells)">
                                                <ContentCollection>
                                                    <dx:ContentControl runat="server" SupportsDisabledAttribute="True">
                                                        <table class="dxflInternalEditorTable_Moderno">
                                                            <tr>
                                                                <td>
                                                                    <table class="dxflInternalEditorTable_PlasticBlue" style="width: 600px">
                                                                        <tr>
                                                                            <td align="left" class="auto-style4z">
                                                                                <asp:Label ID="Label9" runat="server" Text="Date From"></asp:Label>
                                                                            </td>
                                                                            <td align="left">
                                                                                <dx:ASPxDateEdit ID="ASPxDateEdit9" runat="server" Theme="PlasticBlue" DisplayFormatString="dd MMM yyyy" EditFormatString="dd MMM yyyy">
                                                                                </dx:ASPxDateEdit>
                                                                            </td>
                                                                            <td>
                                                                                <asp:Label ID="Label10" runat="server" Text="Date to"></asp:Label>
                                                                            </td>
                                                                            <td class="auto-style5z">
                                                                                <dx:ASPxDateEdit ID="ASPxDateEdit10" runat="server" Theme="PlasticBlue" DisplayFormatString="dd MMM yyyy" EditFormatString="dd MMM yyyy">
                                                                                </dx:ASPxDateEdit>
                                                                            </td>
                                                                            <td>
                                                                                <dx:ASPxButton ID="ASPxButton5" runat="server" Text="Filter" Theme="MetropolisBlue">
                                                                                </dx:ASPxButton>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <dx:ASPxGridView ID="grdOrdersSummary12" runat="server" AutoGenerateColumns="False" EnableTheming="True" Font-Names="Cambria" Font-Size="Small" Theme="PlasticBlue" Width="1100px">
                                                                        <Columns>
                                                                            <dx:GridViewDataTextColumn Caption="Date" FieldName="Date_posted" ShowInCustomizationForm="True" VisibleIndex="0">
                                                                            </dx:GridViewDataTextColumn>
                                                                            <dx:GridViewDataTextColumn Caption="Deal ID" FieldName="dealnr" ShowInCustomizationForm="True" VisibleIndex="0">
                                                                            </dx:GridViewDataTextColumn>
                                                                            <dx:GridViewDataTextColumn Caption="Selling CDS" FieldName="Account2" ShowInCustomizationForm="True" VisibleIndex="0">
                                                                            </dx:GridViewDataTextColumn>
                                                                            <dx:GridViewDataTextColumn Caption="Name" FieldName="name" ShowInCustomizationForm="True" VisibleIndex="0">
                                                                            </dx:GridViewDataTextColumn>
                                                                            <dx:GridViewDataTextColumn Caption="Company" FieldName="Company" ShowInCustomizationForm="True" VisibleIndex="0">
                                                                            </dx:GridViewDataTextColumn>
                                                                            <dx:GridViewDataTextColumn Caption="Quantity" FieldName="TradeQty" ShowInCustomizationForm="True" VisibleIndex="0">
                                                                            </dx:GridViewDataTextColumn>
                                                                            <dx:GridViewDataTextColumn Caption="Price" FieldName="TradePrice" ShowInCustomizationForm="True" VisibleIndex="0">
                                                                            </dx:GridViewDataTextColumn>
                                                                            <dx:GridViewDataTextColumn Caption="Gross" FieldName="Value" ShowInCustomizationForm="True" VisibleIndex="0">


                                                                                <PropertiesTextEdit DisplayFormatString="C2">
                                                                                </PropertiesTextEdit>
                                                                            </dx:GridViewDataTextColumn>
                                                                            <dx:GridViewDataTextColumn Caption="Charges" FieldName="Charges" ShowInCustomizationForm="True" VisibleIndex="0">


                                                                                <PropertiesTextEdit DisplayFormatString="C2">
                                                                                </PropertiesTextEdit>
                                                                            </dx:GridViewDataTextColumn>
                                                                            <dx:GridViewDataTextColumn Caption="Net" FieldName="Net" ShowInCustomizationForm="True" VisibleIndex="0">

                                                                                <PropertiesTextEdit DisplayFormatString="C2">
                                                                                </PropertiesTextEdit>
                                                                            </dx:GridViewDataTextColumn>
                                                                            <dx:GridViewDataTextColumn Caption="Status" FieldName="Status" ShowInCustomizationForm="True" VisibleIndex="0">
                                                                            </dx:GridViewDataTextColumn>
                                                                        </Columns>
                                                                        <Settings ShowFilterRow="True" />
                                                                    </dx:ASPxGridView>
                                                                    <br />
                                                                    <dx:ASPxButton ID="ASPxButton12" runat="server" Text="Export ">
                                                                    </dx:ASPxButton>
                                                                    <br />
                                                                    <br />
                                                                    <dx:ASPxGridViewExporter ID="ASPxGridViewExporter5" runat="server" GridViewID="grdOrdersSummary12">
                                                                    </dx:ASPxGridViewExporter>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </dx:ContentControl>
                                                </ContentCollection>
                                            </dx:TabPage>
                                            <dx:TabPage Name="Settlement" Text="Settlement(Purchases)">
                                                <ContentCollection>
                                                    <dx:ContentControl runat="server" SupportsDisabledAttribute="True">
                                                        <table class="dxflInternalEditorTable_Moderno">
                                                            <tr>
                                                                <td>
                                                                    <table class="dxflInternalEditorTable_PlasticBlue" style="width: 600px">
                                                                        <tr>
                                                                            <td align="left" class="auto-style4z">
                                                                                <asp:Label ID="Label11" runat="server" Text="Date From"></asp:Label>
                                                                            </td>
                                                                            <td align="left">
                                                                                <dx:ASPxDateEdit ID="ASPxDateEdit11" runat="server" Theme="PlasticBlue" DisplayFormatString="dd MMM yyyy" EditFormatString="dd MMM yyyy">
                                                                                </dx:ASPxDateEdit>
                                                                            </td>
                                                                            <td>
                                                                                <asp:Label ID="Label12" runat="server" Text="Date to"></asp:Label>
                                                                            </td>
                                                                            <td class="auto-style5z">
                                                                                <dx:ASPxDateEdit ID="ASPxDateEdit12" runat="server" Theme="PlasticBlue" DisplayFormatString="dd MMM yyyy" EditFormatString="dd MMM yyyy">
                                                                                </dx:ASPxDateEdit>
                                                                            </td>
                                                                            <td>
                                                                                <dx:ASPxButton ID="ASPxButton6" runat="server" Text="Filter" Theme="MetropolisBlue">
                                                                                </dx:ASPxButton>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <dx:ASPxGridView ID="grdOrdersSummary13" runat="server" AutoGenerateColumns="False" EnableTheming="True" Font-Names="Cambria" Font-Size="Small" Theme="PlasticBlue" Width="1100px">
                                                                        <Columns>
                                                                            <dx:GridViewDataTextColumn FieldName="Date_posted" ShowInCustomizationForm="True" VisibleIndex="0" Caption="Date">
                                                                            </dx:GridViewDataTextColumn>
                                                                            <%-- <dx:GridViewDataTextColumn FieldName="T4"  ShowInCustomizationForm="True" VisibleIndex="0" Caption="Settlement Date">
                                                                        </dx:GridViewDataTextColumn>--%>
                                                                            <dx:GridViewDataTextColumn FieldName="dealnr" ShowInCustomizationForm="True" VisibleIndex="0" Caption="Deal ID">
                                                                            </dx:GridViewDataTextColumn>
                                                                            <dx:GridViewDataTextColumn FieldName="Account1" ShowInCustomizationForm="True" VisibleIndex="0" Caption="Buying CDS">
                                                                            </dx:GridViewDataTextColumn>
                                                                            <dx:GridViewDataTextColumn FieldName="name" ShowInCustomizationForm="True" VisibleIndex="0" Caption="Name">
                                                                            </dx:GridViewDataTextColumn>
                                                                            <dx:GridViewDataTextColumn FieldName="Company" ShowInCustomizationForm="True" VisibleIndex="0" Caption="Company">
                                                                            </dx:GridViewDataTextColumn>
                                                                            <dx:GridViewDataTextColumn FieldName="TradeQty" ShowInCustomizationForm="True" VisibleIndex="0" Caption="Quantity">
                                                                            </dx:GridViewDataTextColumn>
                                                                            <dx:GridViewDataTextColumn FieldName="TradePrice" ShowInCustomizationForm="True" VisibleIndex="0" Caption="Price">
                                                                            </dx:GridViewDataTextColumn>
                                                                            <dx:GridViewDataTextColumn FieldName="Value" ShowInCustomizationForm="True" VisibleIndex="0" Caption="Net">


                                                                                <PropertiesTextEdit DisplayFormatString="C2">
                                                                                </PropertiesTextEdit>
                                                                            </dx:GridViewDataTextColumn>
                                                                            <dx:GridViewDataTextColumn FieldName="Charges" ShowInCustomizationForm="True" VisibleIndex="0" Caption="Charges">


                                                                                <PropertiesTextEdit DisplayFormatString="C2">
                                                                                </PropertiesTextEdit>
                                                                            </dx:GridViewDataTextColumn>
                                                                            <dx:GridViewDataTextColumn FieldName="Net" ShowInCustomizationForm="True" VisibleIndex="0" Caption="Gross">


                                                                                <PropertiesTextEdit DisplayFormatString="C2">
                                                                                </PropertiesTextEdit>
                                                                            </dx:GridViewDataTextColumn>
                                                                            <dx:GridViewDataTextColumn FieldName="Status" ShowInCustomizationForm="True" VisibleIndex="0" Caption="Status">
                                                                            </dx:GridViewDataTextColumn>
                                                                        </Columns>
                                                                        <Settings ShowFilterRow="True" />
                                                                    </dx:ASPxGridView>
                                                                    <br />
                                                                    <dx:ASPxButton ID="ASPxButton13" runat="server" Text="Export ">
                                                                    </dx:ASPxButton>
                                                                    <br />
                                                                    <br />
                                                                    <dx:ASPxGridViewExporter ID="ASPxGridViewExporter6" runat="server" GridViewID="grdOrdersSummary13">
                                                                    </dx:ASPxGridViewExporter>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </dx:ContentControl>
                                                </ContentCollection>
                                            </dx:TabPage>
                                            <dx:TabPage Name="Rejected" Text="Rejected">
                                                <ContentCollection>
                                                    <dx:ContentControl runat="server" SupportsDisabledAttribute="True">
                                                        <table class="dxflInternalEditorTable_Moderno">
                                                            <tr>
                                                                <td>
                                                                    <table class="dxflInternalEditorTable_PlasticBlue" style="width: 600px">
                                                                        <tr>
                                                                            <td align="left" class="auto-style4z">
                                                                                <asp:Label ID="Label13" runat="server" Text="Date From"></asp:Label>
                                                                            </td>
                                                                            <td align="left">
                                                                                <dx:ASPxDateEdit ID="ASPxDateEdit13" runat="server" Theme="PlasticBlue" DisplayFormatString="dd MMM yyyy" EditFormatString="dd MMM yyyy">
                                                                                </dx:ASPxDateEdit>
                                                                            </td>
                                                                            <td>
                                                                                <asp:Label ID="Label14" runat="server" Text="Date to"></asp:Label>
                                                                            </td>
                                                                            <td class="auto-style5z">
                                                                                <dx:ASPxDateEdit ID="ASPxDateEdit14" runat="server" Theme="PlasticBlue" DisplayFormatString="dd MMM yyyy" EditFormatString="dd MMM yyyy">
                                                                                </dx:ASPxDateEdit>
                                                                            </td>
                                                                            <td>
                                                                                <dx:ASPxButton ID="ASPxButton7" runat="server" Text="Filter" Theme="MetropolisBlue">
                                                                                </dx:ASPxButton>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <dx:ASPxGridView ID="grdOrdersSummary14" runat="server" AutoGenerateColumns="False" EnableTheming="True" Font-Names="Cambria" Font-Size="Small" Theme="PlasticBlue" Width="1100px">
                                                                        <Columns>
                                                                            <dx:GridViewDataTextColumn Caption="Date" FieldName="Date_posted" ShowInCustomizationForm="True" VisibleIndex="0">
                                                                            </dx:GridViewDataTextColumn>
                                                                            <dx:GridViewDataTextColumn Caption="Deal ID" FieldName="dealnr" ShowInCustomizationForm="True" VisibleIndex="0">
                                                                            </dx:GridViewDataTextColumn>
                                                                            <dx:GridViewDataTextColumn Caption="Buying Broker" FieldName="Broker1" ShowInCustomizationForm="True" VisibleIndex="0">
                                                                            </dx:GridViewDataTextColumn>
                                                                            <dx:GridViewDataTextColumn Caption="Selling Broker" FieldName="Broker2" ShowInCustomizationForm="True" VisibleIndex="0">
                                                                            </dx:GridViewDataTextColumn>
                                                                            <dx:GridViewDataTextColumn Caption="Company" FieldName="Company" ShowInCustomizationForm="True" VisibleIndex="0">
                                                                            </dx:GridViewDataTextColumn>
                                                                            <dx:GridViewDataTextColumn Caption="Quantity" FieldName="TradeQty" ShowInCustomizationForm="True" VisibleIndex="0">
                                                                            </dx:GridViewDataTextColumn>
                                                                            <dx:GridViewDataTextColumn Caption="Price" FieldName="TradePrice" ShowInCustomizationForm="True" VisibleIndex="0">
                                                                            </dx:GridViewDataTextColumn>
                                                                            <dx:GridViewDataTextColumn Caption="Value" FieldName="Value" ShowInCustomizationForm="True" VisibleIndex="0">


                                                                                <PropertiesTextEdit DisplayFormatString="C2">
                                                                                </PropertiesTextEdit>
                                                                            </dx:GridViewDataTextColumn>
                                                                            <%--<dx:GridViewDataTextColumn Caption="Charges" FieldName="Charges" ShowInCustomizationForm="True" VisibleIndex="0">
                                                                        </dx:GridViewDataTextColumn>
                                                                        <dx:GridViewDataTextColumn Caption="Gross" FieldName="Net" ShowInCustomizationForm="True" VisibleIndex="0">
                                                                        </dx:GridViewDataTextColumn>--%>
                                                                            <dx:GridViewDataTextColumn Caption="Status" FieldName="Status" ShowInCustomizationForm="True" VisibleIndex="0">
                                                                            </dx:GridViewDataTextColumn>
                                                                        </Columns>
                                                                        <Settings ShowFilterRow="True" />
                                                                    </dx:ASPxGridView>
                                                                    <br />
                                                                    <dx:ASPxButton ID="ASPxButton14" runat="server" Text="Export ">
                                                                    </dx:ASPxButton>
                                                                    <br />
                                                                    <dx:ASPxGridViewExporter ID="ASPxGridViewExporter7" runat="server" GridViewID="grdOrdersSummary14">
                                                                    </dx:ASPxGridViewExporter>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </dx:ContentControl>
                                                </ContentCollection>
                                            </dx:TabPage>
                                            <dx:TabPage Name="Failed" Text="Failed Settlement" Visible="False">
                                                <ContentCollection>
                                                    <dx:ContentControl runat="server" SupportsDisabledAttribute="True">
                                                    </dx:ContentControl>
                                                </ContentCollection>
                                            </dx:TabPage>
                                            <dx:TabPage Text="Charges - Summarized" Name="Charges - Summarized">
                                                <ContentCollection>
                                                    <dx:ContentControl runat="server" SupportsDisabledAttribute="True">
                                                        <table class="dxflInternalEditorTable_Moderno">
                                                            <tr>
                                                                <td>
                                                                    <table class="dxflInternalEditorTable_PlasticBlue" style="width: 600px">
                                                                        <tr>
                                                                            <td align="left" class="auto-style4z">
                                                                                <asp:Label ID="Label15" runat="server" Text="Date From"></asp:Label>
                                                                            </td>
                                                                            <td align="left">
                                                                                <dx:ASPxDateEdit ID="ASPxDateEdit15" runat="server" DisplayFormatString="dd MMM yyyy" EditFormat="Custom" EditFormatString="dd MMM yyyy" Theme="PlasticBlue">
                                                                                </dx:ASPxDateEdit>
                                                                            </td>
                                                                            <td>
                                                                                <asp:Label ID="Label16" runat="server" Text="Date to"></asp:Label>
                                                                            </td>
                                                                            <td class="auto-style5z">
                                                                                <dx:ASPxDateEdit ID="ASPxDateEdit16" runat="server" DisplayFormatString="dd MMM yyyy" EditFormat="Custom" EditFormatString="dd MMM yyyy" Theme="PlasticBlue">
                                                                                </dx:ASPxDateEdit>
                                                                            </td>
                                                                            <td>
                                                                                <dx:ASPxButton ID="ASPxButton15" runat="server" Text="Filter" Theme="MetropolisBlue">
                                                                                </dx:ASPxButton>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <dx:ASPxGridView ID="grdOrdersSummary15" runat="server" AutoGenerateColumns="False" EnableTheming="True" Font-Names="Cambria" Font-Size="Small" Theme="PlasticBlue" Width="1100px">
                                                                        <Columns>
                                                                            <dx:GridViewDataTextColumn Caption="Date" FieldName="Date_posted" ShowInCustomizationForm="True" VisibleIndex="0">
                                                                            </dx:GridViewDataTextColumn>
                                                                            <dx:GridViewDataTextColumn Caption="Deal ID" FieldName="dealnr" ShowInCustomizationForm="True" VisibleIndex="0">
                                                                            </dx:GridViewDataTextColumn>
                                                                            <dx:GridViewDataTextColumn Caption="Buying CDS" FieldName="Account1" ShowInCustomizationForm="True" VisibleIndex="0">
                                                                            </dx:GridViewDataTextColumn>
                                                                            <dx:GridViewDataTextColumn Caption="Selling CDS" FieldName="Account2" ShowInCustomizationForm="True" VisibleIndex="0">
                                                                            </dx:GridViewDataTextColumn>
                                                                            <dx:GridViewDataTextColumn Caption="Name" FieldName="name" ShowInCustomizationForm="True" VisibleIndex="0">
                                                                            </dx:GridViewDataTextColumn>
                                                                            <dx:GridViewDataTextColumn Caption="Company" FieldName="Company" ShowInCustomizationForm="True" VisibleIndex="0">
                                                                            </dx:GridViewDataTextColumn>
                                                                            <dx:GridViewDataTextColumn Caption="Quantity" FieldName="TradeQty" ShowInCustomizationForm="True" VisibleIndex="0">
                                                                            </dx:GridViewDataTextColumn>
                                                                            <dx:GridViewDataTextColumn Caption="Sell Charges" FieldName="Charges" ShowInCustomizationForm="True" VisibleIndex="0">


                                                                                <PropertiesTextEdit DisplayFormatString="C2">
                                                                                </PropertiesTextEdit>
                                                                            </dx:GridViewDataTextColumn>
                                                                            <dx:GridViewDataTextColumn Caption="Buy Charges" FieldName="Buy" ShowInCustomizationForm="True" VisibleIndex="0">


                                                                                <PropertiesTextEdit DisplayFormatString="C2">
                                                                                </PropertiesTextEdit>
                                                                            </dx:GridViewDataTextColumn>

                                                                        </Columns>
                                                                        <Settings ShowFilterRow="True" />
                                                                    </dx:ASPxGridView>
                                                                    <br />
                                                                    <dx:ASPxButton ID="ASPxButton16" runat="server" Text="Export ">
                                                                    </dx:ASPxButton>
                                                                    <br />
                                                                    <br />
                                                                    <dx:ASPxGridViewExporter ID="ASPxGridViewExporter8" runat="server" GridViewID="grdOrdersSummary13">
                                                                    </dx:ASPxGridViewExporter>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </dx:ContentControl>
                                                </ContentCollection>
                                            </dx:TabPage>
                                            <dx:TabPage Name="Levies" Text="Levies">
                                                <ContentCollection>
                                                    <dx:ContentControl runat="server" SupportsDisabledAttribute="True">
                                                        <table class="dxflInternalEditorTable_Moderno">
                                                            <tr>
                                                                <td>
                                                                    <table class="dxflInternalEditorTable_PlasticBlue" style="width: 600px">
                                                                        <tr>
                                                                            <td align="left" class="auto-style4z">
                                                                                <asp:Label ID="Label17" runat="server" Text="Date From"></asp:Label>
                                                                            </td>
                                                                            <td align="left">
                                                                                <dx:ASPxDateEdit ID="ASPxDateEdit17" runat="server" DisplayFormatString="dd MMM yyyy" EditFormat="Custom" EditFormatString="dd MMM yyyy" Theme="PlasticBlue">
                                                                                </dx:ASPxDateEdit>
                                                                            </td>
                                                                            <td>
                                                                                <asp:Label ID="Label18" runat="server" Text="Date to"></asp:Label>
                                                                            </td>
                                                                            <td class="auto-style5z">
                                                                                <dx:ASPxDateEdit ID="ASPxDateEdit18" runat="server" DisplayFormatString="dd MMM yyyy" EditFormat="Custom" EditFormatString="dd MMM yyyy" Theme="PlasticBlue">
                                                                                </dx:ASPxDateEdit>
                                                                            </td>
                                                                            <td>
                                                                                <dx:ASPxButton ID="ASPxButton18" runat="server" Text="Filter" Theme="MetropolisBlue">
                                                                                </dx:ASPxButton>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <dx:ASPxGridView ID="grdOrdersSummary16" runat="server" AutoGenerateColumns="True" EnableTheming="True" Font-Names="Cambria" Font-Size="Small" Theme="PlasticBlue" Width="100%">
                                                                        <Columns>
                                                                            <dx:GridViewDataTextColumn Caption="Participant Name" FieldName="Company_name" ShowInCustomizationForm="True" VisibleIndex="0">
                                                                            </dx:GridViewDataTextColumn>
                                                                            <dx:GridViewDataTextColumn Caption="Participnat Code" FieldName="Company_Code" ShowInCustomizationForm="True" VisibleIndex="0">
                                                                            </dx:GridViewDataTextColumn>
                                                                            <dx:GridViewDataTextColumn Caption="Buy Volume" FieldName="Buy Volume" ShowInCustomizationForm="True" VisibleIndex="0">

                                                                                <PropertiesTextEdit DisplayFormatString="f0">
                                                                                </PropertiesTextEdit>
                                                                            </dx:GridViewDataTextColumn>
                                                                            <dx:GridViewDataTextColumn Caption="Buy Value" FieldName="Buy Value" ShowInCustomizationForm="True" VisibleIndex="0">


                                                                                <PropertiesTextEdit DisplayFormatString="C2">
                                                                                </PropertiesTextEdit>
                                                                            </dx:GridViewDataTextColumn>
                                                                            <dx:GridViewDataTextColumn Caption="Sell Volume" FieldName="Sell Volume" ShowInCustomizationForm="True" VisibleIndex="0">

                                                                                <PropertiesTextEdit DisplayFormatString="f0">
                                                                                </PropertiesTextEdit>

                                                                            </dx:GridViewDataTextColumn>
                                                                            <dx:GridViewDataTextColumn Caption="Sell Value" FieldName="Sell Value" ShowInCustomizationForm="True" VisibleIndex="0">

                                                                                <PropertiesTextEdit DisplayFormatString="C2">
                                                                                </PropertiesTextEdit>
                                                                            </dx:GridViewDataTextColumn>
                                                                            <dx:GridViewDataTextColumn Caption="No. of Buy Trades" FieldName="Number of Buy Trades" ShowInCustomizationForm="True" VisibleIndex="0">
                                                                                <PropertiesTextEdit DisplayFormatString="f0">
                                                                                </PropertiesTextEdit>
                                                                            </dx:GridViewDataTextColumn>
                                                                            <dx:GridViewDataTextColumn Caption="No. of Sell Trades" FieldName="Number of Sell Trades" ShowInCustomizationForm="True" VisibleIndex="0">
                                                                                <PropertiesTextEdit DisplayFormatString="D">
                                                                                </PropertiesTextEdit>
                                                                            </dx:GridViewDataTextColumn>
                                                                            <dx:GridViewDataTextColumn Caption="SECZ Levy" FieldName="SECZ Levy" ShowInCustomizationForm="True" VisibleIndex="0">
                                                                                <PropertiesTextEdit DisplayFormatString="C2">
                                                                                </PropertiesTextEdit>
                                                                            </dx:GridViewDataTextColumn>


                                                                            <dx:GridViewDataTextColumn Caption="VAT" FieldName="VAT" ShowInCustomizationForm="True" VisibleIndex="0">
                                                                                <PropertiesTextEdit DisplayFormatString="C2">
                                                                                </PropertiesTextEdit>
                                                                            </dx:GridViewDataTextColumn>

                                                                            <dx:GridViewDataTextColumn Caption="CGT TAX" FieldName="CGT TAX" ShowInCustomizationForm="True" VisibleIndex="0">
                                                                                <PropertiesTextEdit DisplayFormatString="C2">
                                                                                </PropertiesTextEdit>
                                                                            </dx:GridViewDataTextColumn>

                                                                            <dx:GridViewDataTextColumn Caption="Investor Levy" FieldName="Investor Levy" ShowInCustomizationForm="True" VisibleIndex="0">
                                                                                <PropertiesTextEdit DisplayFormatString="C2">
                                                                                </PropertiesTextEdit>
                                                                            </dx:GridViewDataTextColumn>

                                                                            <dx:GridViewDataTextColumn Caption="Brokerage Fees" FieldName="Brokerage Levy" ShowInCustomizationForm="True" VisibleIndex="0">
                                                                                <PropertiesTextEdit DisplayFormatString="C2">
                                                                                </PropertiesTextEdit>
                                                                            </dx:GridViewDataTextColumn>

                                                                            <dx:GridViewDataTextColumn Caption="Stamp Duty" FieldName="Stamp Duty" ShowInCustomizationForm="True" VisibleIndex="0">
                                                                                <PropertiesTextEdit DisplayFormatString="C2">
                                                                                </PropertiesTextEdit>
                                                                            </dx:GridViewDataTextColumn>

                                                                            <dx:GridViewDataTextColumn Caption="FINSEC Platform" FieldName="ZSE Levy" ShowInCustomizationForm="True" VisibleIndex="0">
                                                                                <PropertiesTextEdit DisplayFormatString="C2">
                                                                                </PropertiesTextEdit>
                                                                            </dx:GridViewDataTextColumn>

                                                                            <dx:GridViewDataTextColumn Caption="Settlement Levy" FieldName="CSD Levy" ShowInCustomizationForm="True" VisibleIndex="0">
                                                                                <PropertiesTextEdit DisplayFormatString="C2">
                                                                                </PropertiesTextEdit>
                                                                            </dx:GridViewDataTextColumn>

                                                                            <dx:GridViewDataTextColumn Caption="Total" FieldName="Total" ShowInCustomizationForm="True" VisibleIndex="0">
                                                                                <PropertiesTextEdit DisplayFormatString="C2">
                                                                                </PropertiesTextEdit>
                                                                            </dx:GridViewDataTextColumn>



                                                                        </Columns>
                                                                        <Settings ShowFilterRow="True" />
                                                                    </dx:ASPxGridView>
                                                                    <br />
                                                                    <dx:ASPxButton ID="ASPxButton19" runat="server" Text="Export" AutoPostBack="False">
                                                                    </dx:ASPxButton>
                                                                    <br />
                                                                    <br />
                                                                    <dx:ASPxGridViewExporter ID="ASPxGridViewExporter9" runat="server" GridViewID="grdOrdersSummary16">
                                                                    </dx:ASPxGridViewExporter>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </dx:ContentControl>
                                                </ContentCollection>
                                            </dx:TabPage>
                                            <dx:TabPage Name="Charges - Detailed" Text="Charges - Detailed">
                                                <ContentCollection>
                                                    <dx:ContentControl runat="server" SupportsDisabledAttribute="True">
                                                        <table class="dxflInternalEditorTable_Moderno">
                                                            <tr>
                                                                <td>
                                                                    <table class="dxflInternalEditorTable_PlasticBlue" style="width: 1000px">
                                                                        <tr>
                                                                            <td align="left" class="auto-style4z">
                                                                                <asp:Label ID="Label19" runat="server" Text="Date From"></asp:Label>
                                                                            </td>
                                                                            <td align="left">
                                                                                <dx:ASPxDateEdit ID="ASPxDateEdit19" runat="server" DisplayFormatString="dd MMM yyyy" EditFormat="Custom" EditFormatString="dd MMM yyyy" Theme="PlasticBlue">
                                                                                </dx:ASPxDateEdit>
                                                                            </td>
                                                                            <td>
                                                                                <asp:Label ID="Label20" runat="server" Text="Date to"></asp:Label>
                                                                            </td>
                                                                            <td class="auto-style5z">
                                                                                <dx:ASPxDateEdit ID="ASPxDateEdit20" runat="server" DisplayFormatString="dd MMM yyyy" EditFormat="Custom" EditFormatString="dd MMM yyyy" Theme="PlasticBlue">
                                                                                </dx:ASPxDateEdit>
                                                                            </td>

                                                                            <td>
                                                                                <asp:Label ID="Label7" runat="server" Text="Charge Code"></asp:Label>
                                                                            </td>
                                                                            <td class="auto-style5z">
                                                                                <dx:ASPxComboBox ID="cmbJnationality1" runat="server" Theme="BlackGlass" ValueType="System.String" Width="250px" Visible="True" AutoPostBack="True">
                                                                                </dx:ASPxComboBox>
                                                                            </td>

                                                                            <td>
                                                                                <dx:ASPxButton ID="ASPxButton20" runat="server" Text="Filter" Theme="MetropolisBlue">
                                                                                </dx:ASPxButton>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <dx:ASPxGridView ID="grdOrdersSummary17" runat="server" AutoGenerateColumns="False" EnableTheming="True" Font-Names="Cambria" Font-Size="Small" Theme="PlasticBlue" Width="1100px">
                                                                        <Columns>
                                                                            
                                                                               <dx:GridViewDataTextColumn Caption="Deal Number" FieldName="ID" ShowInCustomizationForm="True" VisibleIndex="0">
                                                                            </dx:GridViewDataTextColumn>

                                                                            <dx:GridViewDataTextColumn Caption="Price ($)" FieldName="TradePrice" ShowInCustomizationForm="True" VisibleIndex="0">
                                                                            </dx:GridViewDataTextColumn>
                                                                            
                                                                            

                                                                            <dx:GridViewDataTextColumn Caption="Quantity" FieldName="TradeQty" ShowInCustomizationForm="True" VisibleIndex="0">
                                                                            </dx:GridViewDataTextColumn>
                                                                            <dx:GridViewDataTextColumn Caption="Deal Value ($)" FieldName="DealValue" ShowInCustomizationForm="True" VisibleIndex="0">


<%--                                                                                <PropertiesTextEdit DisplayFormatString="f4">--%>
<%--                                                                                </PropertiesTextEdit>--%>
                                                                            </dx:GridViewDataTextColumn>
                                                                            <dx:GridViewDataTextColumn Caption="ChargeCode" FieldName="ChargeCode" ShowInCustomizationForm="True" VisibleIndex="0">
                                                                            </dx:GridViewDataTextColumn>
                                                                            
                                                                            <dx:GridViewDataTextColumn Caption="Buy Charges ($)" FieldName="BuyCharges" ShowInCustomizationForm="True" VisibleIndex="0">

<%--                                                                                <PropertiesTextEdit DisplayFormatString="f4">--%>
<%--                                                                                </PropertiesTextEdit>--%>
                                                                            </dx:GridViewDataTextColumn>
                                                                            <dx:GridViewDataTextColumn Caption="Sell Charges (S)" FieldName="SellCharges" ShowInCustomizationForm="True" VisibleIndex="0">

<%----%>
<%--                                                                                <PropertiesTextEdit DisplayFormatString="f4">--%>
<%--                                                                                </PropertiesTextEdit>--%>
                                                                            </dx:GridViewDataTextColumn>

                                                                            <dx:GridViewDataTextColumn Caption="Buying Broker" FieldName="Broker1" ShowInCustomizationForm="True" VisibleIndex="0">
                                                                            </dx:GridViewDataTextColumn>
                                                                            <dx:GridViewDataTextColumn Caption="Selling Broker" FieldName="Broker2" ShowInCustomizationForm="True" VisibleIndex="0">
                                                                            </dx:GridViewDataTextColumn>

                                                                            <dx:GridViewDataTextColumn Caption="Date" FieldName="Date_posted" ShowInCustomizationForm="True" VisibleIndex="0">
                                                                               
                                                                                 <PropertiesTextEdit DisplayFormatString="dd-MM-yyyy">
                                                                                </PropertiesTextEdit>
                                                                            </dx:GridViewDataTextColumn>
                                                                        </Columns>
                                                                        <Settings ShowFilterRow="True" />
                                                                    </dx:ASPxGridView>
                                                                    <br />
                                                                    <dx:ASPxButton ID="ASPxButton21" runat="server" Text="Export ">
                                                                    </dx:ASPxButton>
                                                                    <br />
                                                                    <br />
                                                                    <dx:ASPxGridViewExporter ID="ASPxGridViewExporter10" runat="server" GridViewID="grdOrdersSummary17">
                                                                    </dx:ASPxGridViewExporter>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </dx:ContentControl>
                                                </ContentCollection>
                                            </dx:TabPage>
                                        </TabPages>
                                    </dx:ASPxPageControl>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" style="border-style: solid; border-width: 0.5px">
                                    <dx:ASPxButton ID="ASPxButton17" runat="server" Text="Halt Trading" Theme="Moderno">
                                    </dx:ASPxButton>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>

        </div>
    </form>
</body>
</html>
