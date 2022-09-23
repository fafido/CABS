<%@ Page Language="VB" MasterPageFile="~/CDSuser.master" AutoEventWireup="false" CodeFile="browsefiles.aspx.vb" Inherits="browsefiles" %>
<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>

<%@ Register assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxFileManager" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxUploadControl" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxObjectContainer" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxPopupControl" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxDocking" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Dashboard.v13.2.Web, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.DashboardWeb" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.ASPxGauges.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxGauges" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.ASPxGauges.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxGauges.Gauges" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.ASPxGauges.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxGauges.Gauges.Linear" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.ASPxGauges.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxGauges.Gauges.Circular" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.ASPxGauges.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxGauges.Gauges.State" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.ASPxGauges.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxGauges.Gauges.Digital" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxGridLookup" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxGridView.Export" tagprefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
    <asp:Panel id="Panel1" runat="server" Width="840px" Font-Names="Arial" Font-Size="Medium" BackColor="White">
    
        <table width ="810px">
            <tr>
                   <td style ="text-align :left;" align="left">
                       <dx:ASPxLabel ID="ASPxLabel1" runat="server" Text="Utilities&gt;&gt;File Explorer" Font-Names="Cambria" Font-Size="Small" Theme="PlasticBlue"></dx:ASPxLabel>

                   </td>
            </tr>
        </table>
        <asp:panel id="Panel5" runat="server" GroupingText="File Browsing" Font-Names="Cambria">
        <table width="810px">
            <tr>
                <td colspan ="5">
               <dx:ASPxFileManager ID="fileManager" runat="server" Height="612px" >
        <Settings RootFolder="~/" ThumbnailFolder="~/"
            AllowedFileExtensions=".jpg,.jpeg,.gif,.rtf,.txt,.avi,.png,.mp3,.xml,.doc,.pdf,.aspx,.vb"
            InitialFolder="~/" />
                 
        <SettingsEditing AllowCreate="true" AllowDelete="true" AllowMove="true" AllowRename="true" AllowCopy="true" AllowDownload="true" />
        <SettingsPermissions>
           
            <AccessRules>
                <dx:FileManagerFolderAccessRule Path="System" Edit="Deny" />
            
            </AccessRules>
        </SettingsPermissions>
                   <SettingsToolbar ShowDownloadButton="True" />
        <SettingsUpload UseAdvancedUploadMode="true">
            <AdvancedModeSettings EnableMultiSelect="true" />
        </SettingsUpload>
    </dx:ASPxFileManager></td>

            </tr>
            <tr>
                <td colspan="1" style="width: 109px"></td>
                <td colspan ="1">
                    &nbsp;</td>
                <td></td>
                <td></td>
                <td></td>
            </tr>

            <tr>
                <td colspan="1" style="width: 109px">&nbsp;</td>
                <td colspan="1">&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td colspan="4">
                    &nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td colspan="5">
                    &nbsp;</td>
            </tr>

        </table>

    </asp:panel>
         
</asp:Panel>
  
</div>
</asp:Content>