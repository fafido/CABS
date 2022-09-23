<%@ Page Language="VB" MasterPageFile="~/CDSUser.master" AutoEventWireup="false" CodeFile="counterpartrecon.aspx.vb" Inherits="Counterpartrecon" title="Counterpartrecon" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxTabControl" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>


<%@ Register assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dx" %>


<%@ Register assembly="DevExpress.XtraCharts.v13.2.Web, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.XtraCharts.Web" tagprefix="dxchartsui" %>
<%@ Register assembly="DevExpress.XtraCharts.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.XtraCharts" tagprefix="cc1" %>


<%@ Register assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxFileManager" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxUploadControl" tagprefix="dx" %>


<%@ Register assembly="DevExpress.Web.ASPxScheduler.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxScheduler.Controls" tagprefix="dxwschsc" %>
<%@ Register assembly="DevExpress.Web.ASPxScheduler.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxScheduler" tagprefix="dxwschs" %>
<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView.Export" TagPrefix="dx" %>

<%@ Register assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxGridView" tagprefix="dx1" %>

<asp:Content id="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 
    <asp:Panel id="Panel1" runat="server">
    
<table style="width:100%">
   
    
    <tr>
        <td>
       
             
                 <dx:ASPxLabel ID="ASPxLabel1" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Recon&gt;&gt;Counterpart Bank" Theme="PlasticBlue"></dx:ASPxLabel>
       
             
                 <asp:Panel runat="server" GroupingText="Counterpart Bank Recon">
<table  style="width:100%">
            <tr>
                <td colspan ="8">
                    <table style="width:100%">
                       
                       
                        <tr>
                            <td colspan="9">
                                <dx:ASPxLabel ID="ASPxLabel7" runat="server" Font-Bold="True" Font-Names="Cambria" Font-Size="Small" Text="View Exceptions" Theme="PlasticBlue">
                                </dx:ASPxLabel>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 210px">
                                <dx:ASPxLabel ID="ASPxLabel10" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Bank" Theme="Glass">
                                </dx:ASPxLabel>
                            </td>
                            <td>
                                <dx:ASPxComboBox ID="cmbbank" runat="server" EnableTheming="True" Theme="Default" Width="250px">
                                    <Items>
                                        <dx:ListEditItem Text="Available at Asset Manager not on C-Trade" Value="Available at Asset Manager not on C-Trade" />
                                        <dx:ListEditItem Text="Available on C-Trade not on Asset Manager" Value="Available on C-Trade not on Asset Manager" />
                                        <dx:ListEditItem Text="Available at Both" Value="Available at Both" />
                                        <dx:ListEditItem Text="Asset Manager only" Value="Asset Manager only" />
                                        <dx:ListEditItem Text="C-Trade Only" Value="C-Trade Only" />
                                    </Items>
                                </dx:ASPxComboBox>
                            </td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width: 210px">
                                <dx:ASPxLabel ID="ASPxLabel12" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Asset Manager" Theme="Glass">
                                </dx:ASPxLabel>
                            </td>
                            <td>
                                <dx:ASPxComboBox ID="cmbassetmanager0" runat="server" DropDownStyle="DropDown" EnableTheming="True" IncrementalFilteringMode="StartsWith" Theme="Default" Width="250px">
                                </dx:ASPxComboBox>
                            </td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width: 210px">
                                <dx:ASPxLabel ID="ASPxLabel8" runat="server" Font-Names="Cambria" Font-Size="Small" Text="As at Date" Theme="Glass">
                                </dx:ASPxLabel>
                            </td>
                            <td>
                                <dx:ASPxDateEdit ID="dtdateview" runat="server" AutoPostBack="True" Height="23px" Width="250px">
                                </dx:ASPxDateEdit>
                            </td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width: 210px">&nbsp;</td>
                            <td>
                                <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal">
                                    <asp:ListItem>Authorized</asp:ListItem>
                                    <asp:ListItem>Un-Authorized</asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width: 210px">&nbsp;</td>
                            <td>
                                <dx:ASPxButton ID="btnupload0" runat="server"  Text="View">
                                </dx:ASPxButton>
                                &nbsp;<dx:ASPxButton ID="btnupload1" runat="server" Text="Export">
                                </dx:ASPxButton>
                                <dx:ASPxGridViewExporter ID="ASPxGridViewExporter1" runat="server" GridViewID="ASPxGridView2">
                                </dx:ASPxGridViewExporter>
                                &nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td colspan="9">
                                <dx:ASPxGridView ID="ASPxGridView2" runat="server"  Settings-ShowTitlePanel="true" SettingsText-Title="" Theme="Glass" Width="100%">
                                    <SettingsBehavior AllowSelectByRowClick="True"  AllowSelectSingleRowOnly="True" ProcessSelectionChangedOnServer="True" />
                                    <SettingsPager Visible="False">
                                    </SettingsPager>
                                    <Settings ShowTitlePanel="True" />
                                    <SettingsText Title="Display" />
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
            </table>
            </asp:Panel>

      
            
        </td>
    </tr>

   
</table>
</asp:Panel>

</asp:Content>

