
<%@ Page Language="VB" MasterPageFile="~/CDSUser.master" AutoEventWireup="false" CodeFile="reconibank.aspx.vb" Inherits="Orders" title="Comparing" %>

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
             <asp:Panel runat="server" ID="panel4" GroupingText="Reconcile Bank accounts vs Cashbook (Systems)">
                 <asp:Panel runat="server" GroupingText="Upload Bank statement">
<table>
            <tr>
                <td colspan ="8">
                    <table class="dxflInternalEditorTable_Glass">
                       
                       
                <tr>
                    
                    <td>
                        <asp:FileUpload runat="server" id="fileupload1"></asp:FileUpload>
                         <dx:ASPxButton ID="btnupload" OnClick="btnupload_Click" runat="server" Text="Upload">
                                                                    </dx:ASPxButton>
                    </td>
                   
                     <td>
                       
                       
                    </td>
                    
                   
                    <td>&nbsp;</td>
            </tr>
                         <tr>
                    
                   
                    
                    
                   
                    <td>&nbsp;</td>
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
                        <td colspan ="1">
                            &nbsp;</td>
                    <td colspan ="1"></td>
                    <td colspan ="1"></td>
                    <td colspan ="1"></td>
                    <td colspan ="1">&nbsp;</td>
                    <td colspan ="1"></td>
                    <td colspan ="1"></td>
                    <td colspan ="1"></td>

                </tr>
                <tr>
                        <td colspan ="1" style="height: 18px; width: 387px;">
                            <dx:ASPxGridView ID="ASPxGridView2" runat="server" KeyFieldName="Contract No." Settings-ShowTitlePanel="true" SettingsText-Title="Derivatives" Theme="Glass" Width="640px">
                                <SettingsBehavior AllowSelectByRowClick="True" AllowSelectSingleRowOnly="True" ProcessSelectionChangedOnServer="True" />
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
                    <td colspan ="5" style="height: 18px">
                        <br />
                        </td>
                        <tr>
                            <td colspan="1" style="height: 18px">
                                &nbsp;</td>
                            <td colspan="1" style="height: 18px"></td>
                            <td colspan="1" style="height: 18px"></td>
                            <td colspan="1" style="height: 18px"></td>
                            <td colspan="1" style="height: 18px"></td>
                            <td colspan="1" style="height: 18px"></td>
                            <td colspan="1" style="height: 18px"></td>
                            <td colspan="1" style="height: 18px"></td>
                        </tr>
                        <tr>
                            <td colspan="8" style="text-align:center; height: 18px;"></td>
                        </tr>
                        <tr>
                            <td colspan="8" style=" align-items :center;">
                                <asp:Button ID="Button1" runat="server" Text="View Mismatch balances" Width="251px" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="1">&nbsp;</td>
                            <td colspan="1">&nbsp;</td>
                            <td colspan="1"></td>
                            <td colspan="1"></td>
                            <td colspan="1"></td>
                            <td colspan="1"></td>
                            <td colspan="1"></td>
                            <td colspan="1"></td>
                        </tr>
                        <tr>
                            <td colspan="1">
                                <asp:Button ID="Button4" runat="server" Text="View in Bank accounts not in Cashbook" />
                                <br/>
                                <br/>
                                <asp:Button ID="Button3" runat="server" Text="View in  Cashbook not in Bank accounts" />
                                <br/>
                                <br/>
                                <br/>
                                <br/>
                            </td>
                            <td colspan="1"></td>
                            <td colspan="1"></td>
                            <td colspan="1"></td>
                            <td colspan="1"></td>
                            <td colspan="1"></td>
                            <td colspan="1"></td>
                            <td colspan="1">&nbsp;</td>
                        </tr>
                        <tr>
                            <td colspan="1"></td>
                            <td colspan="1"></td>
                            <td colspan="1"></td>
                            <td colspan="1"></td>
                            <td colspan="1"></td>
                            <td colspan="1"></td>
                            <td colspan="1"></td>
                            <td colspan="1"></td>
                        </tr>

                </tr>
            </table>
            <table>
                <tr>
                    <td></td>
                </tr>
            </table>
 </asp:Panel>

             </asp:Panel>
            
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

