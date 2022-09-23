<%@ Page Language="VB" MasterPageFile="~/CDSUser.master" AutoEventWireup="false" CodeFile="assetman.aspx.vb" Inherits="Orders" title="Comparing" %>

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


<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<%@ Register assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxRoundPanel" tagprefix="dx1" %>
<%@ Register assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxPanel" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.Aspxdateedit" tagprefix="dx" %>


<%@ Register assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxFormLayout" tagprefix="dx" %>


<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxRibbon" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxFormLayout" TagPrefix="dx" %>

<%@ Register assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxDocking" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxPopupControl" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxTabControl" tagprefix="dx1" %>

<asp:Content id="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 
    <asp:Panel id="Panel1" runat="server">
    
<table style="width:100%">
   
    
    <tr>
        <td>
       
             
                 <dx:ASPxLabel ID="ASPxLabel1" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Recon&gt;&gt;Asset Manager" Theme="PlasticBlue"></dx:ASPxLabel>
       
             
                 <asp:Panel runat="server" GroupingText="Upload Asset Manager File">
<table  style="width:100%">
            <tr>
                <td colspan ="8">
                    <table style="width:100%">
                       
                       
                   <tr>
                        <td style="width: 210px; height: 28px;">
                            <dx:ASPxLabel ID="ASPxLabel5" runat="server" Font-Names="Cambria" Font-Size="Small" Text="As at Date" Theme="Glass">
                            </dx:ASPxLabel>
                        </td>
                        <td colspan="1" style="height: 28px">
                            <dx:ASPxDateEdit ID="dtdate" runat="server" AutoPostBack="True" Height="23px" Width="250px">
                            </dx:ASPxDateEdit>
                        </td>
                    <td colspan ="1" style="height: 28px"></td>
                    <td colspan ="1" style="height: 28px"></td>
                    <td colspan ="1" style="height: 28px"></td>
                    <td colspan ="1" style="height: 28px"></td>
                    <td colspan ="1" style="height: 28px"></td>
                    <td colspan ="1" style="height: 28px"></td>
                    <td colspan ="1" style="height: 28px"></td>

                </tr>
                <tr>
                        <td style="width: 210px">
                            <dx:ASPxLabel ID="ASPxLabel6" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Select File" Theme="Glass">
                            </dx:ASPxLabel>
                        </td>
                        <td colspan="1">
                            <asp:FileUpload ID="fileupload1" runat="server" />
                        </td>
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
                        <td style="width: 210px" ></td>
                        <td colspan="1">
                            <dx:ASPxButton ID="btnupload" runat="server" OnClick="btnupload_Click" Text="Upload">
                            </dx:ASPxButton>
                        </td>
                    <td colspan ="3">
                        </td>
                    
                    <td colspan ="1" style="height: 29px"></td>
                    <td colspan ="1" style="height: 29px"></td>
                    <td colspan ="1" style="height: 29px"></td>
                    <td colspan ="1" style="height: 29px"></td>

                </tr>
                <tr>
                        <td colspan="9">
                        <hr />
                            </td>

                </tr>
                        <tr>
                            <td colspan="9">
                                <dx:ASPxLabel ID="ASPxLabel7" runat="server" Font-Bold="True" Font-Names="Cambria" Font-Size="Small" Text="View Exceptions" Theme="PlasticBlue">
                                </dx:ASPxLabel>
                            </td>
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
                            <td style="width: 210px">
                                <dx:ASPxLabel ID="ASPxLabel9" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Select Exception Type" Theme="Glass">
                                </dx:ASPxLabel>
                            </td>
                            <td>
                                <dx:ASPxComboBox ID="cmbtype" runat="server" EnableTheming="True" Theme="Default" Width="250px">
                                    <Items>
                                        <dx:ListEditItem Text="Exceptions - Uploaded" Value="Exceptions - Uploaded" />
                                        <dx:ListEditItem Text="Exceptions - Not Uploaded" Value="Exceptions - Not Uploaded" />
                                       
                                    
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
                                <asp:CheckBox ID="CheckBox1" runat="server" AutoPostBack="True" Font-Size="X-Small" Text="Select All" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="9">
                                <dx:ASPxGridView ID="ASPxGridView2"   runat="server" AutoGenerateColumns="True" KeyFieldName="ID" Settings-ShowTitlePanel="true" SettingsBehavior-ProcessSelectionChangedOnServer="true" SettingsText-Title="" Theme="Glass" Width="100%">
                                    <Settings ShowFilterRow="True" />
                                    <SettingsText Title="Display" />
                                      <SettingsPager PageSize="100"></SettingsPager>
                                    <Columns>
                                        <dx:GridViewDataColumn Caption="Select"  VisibleIndex="0">
                                            <DataItemTemplate>
                                                <dx:ASPxCheckBox ID="chk1" runat="server">
                                                </dx:ASPxCheckBox>
                                            </DataItemTemplate>
                                        </dx:GridViewDataColumn>
                                        <dx:GridViewDataColumn Caption="" VisibleIndex="0">
                                            <DataItemTemplate>
                                                <asp:LinkButton ID="DeleteID0" runat="server" CommandArgument='<%# Eval("ID") %>' CommandName="Comment" Text="Comment">
                                                              </asp:LinkButton>
                                            </DataItemTemplate>
                                        </dx:GridViewDataColumn>
                                        <dx:GridViewDataColumn Caption="" VisibleIndex="0">
                                            <DataItemTemplate>
                                                <asp:LinkButton ID="DeleteID1" runat="server" CommandArgument='<%# Eval("ID") %>' CommandName="Send for Authorization" Text="Send for Authorization">
                                                              </asp:LinkButton>
                                            </DataItemTemplate>
                                        </dx:GridViewDataColumn>
                                        <dx:GridViewDataTextColumn FieldName="Account No" Name="Account No" Settings-AutoFilterCondition="Contains">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="Names" Name="Names" Settings-AutoFilterCondition="Contains">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="Security" Name="Security" Settings-AutoFilterCondition="Contains">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="AssetManager" Name="AssetManager" Settings-AutoFilterCondition="Contains">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="C-Trade Holding" Name="C-Trade Holding" PropertiesTextEdit-DisplayFormatString="n" Settings-AutoFilterCondition="Contains">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="Asset Manager Holding" Name="Asset Manager Holding"  PropertiesTextEdit-DisplayFormatString="n" Settings-AutoFilterCondition="Contains">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="Variance" Name="Variance"  PropertiesTextEdit-DisplayFormatString="n" Settings-AutoFilterCondition="Contains">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="Status" Name="Status" Settings-AutoFilterCondition="Contains">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="C-Trade Value" Name="C-Trade Value"  PropertiesTextEdit-DisplayFormatString="n" Settings-AutoFilterCondition="Contains">
                                        </dx:GridViewDataTextColumn>
                                           <dx:GridViewDataTextColumn FieldName="Asset Manager Value" Name="Asset Manager Value"   PropertiesTextEdit-DisplayFormatString="n" Settings-AutoFilterCondition="Contains">
                                        </dx:GridViewDataTextColumn>
                                              <dx:GridViewDataTextColumn FieldName="Value Variance" Name="Value Variance"  PropertiesTextEdit-DisplayFormatString="n" Settings-AutoFilterCondition="Contains">
                                        </dx:GridViewDataTextColumn>
                                                   <dx:GridViewDataTextColumn FieldName="Value Status" Name="Value Status" Settings-AutoFilterCondition="Contains">
                                        </dx:GridViewDataTextColumn>
                                    </Columns>
                                </dx:ASPxGridView>
                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="9">
                                <dx:ASPxButton ID="btnupload2" runat="server" Text="Send For Approval">
                                </dx:ASPxButton>
                                &nbsp;<dx:ASPxButton ID="btnupload3" runat="server" Text="Comment and Send For Approval" Width="250px">
                                </dx:ASPxButton>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="9">
                                <dx:ASPxGridView ID="ASPxGridView2_auth" runat="server" AutoGenerateColumns="True" KeyFieldName="ID" Settings-ShowTitlePanel="true" SettingsBehavior-ProcessSelectionChangedOnServer="true" SettingsText-Title="" Theme="Glass" Width="100%">
                                    <SettingsBehavior ProcessSelectionChangedOnServer="True" />
                                    <Settings ShowFilterRow="True" />
                                    <SettingsText Title="Display - Authorized" />
                                    <Columns>
                                        <dx:GridViewDataTextColumn FieldName="Account No" Name="Account No" Settings-AutoFilterCondition="Contains">
                                            <Settings AutoFilterCondition="Contains" />
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="Names" Name="Names" Settings-AutoFilterCondition="Contains">
                                            <Settings AutoFilterCondition="Contains" />
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="Security" Name="Security" Settings-AutoFilterCondition="Contains">
                                            <Settings AutoFilterCondition="Contains" />
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="AssetManager" Name="AssetManager" Settings-AutoFilterCondition="Contains">
                                            <Settings AutoFilterCondition="Contains" />
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="C-Trade Holding" Name="C-Trade Holding" PropertiesTextEdit-DisplayFormatString="n" Settings-AutoFilterCondition="Contains">
                                            <Settings AutoFilterCondition="Contains" />
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="Asset Manager Holding" Name="Asset Manager Holding" PropertiesTextEdit-DisplayFormatString="n" Settings-AutoFilterCondition="Contains">
                                            <Settings AutoFilterCondition="Contains" />
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="Variance" Name="Variance" PropertiesTextEdit-DisplayFormatString="n" Settings-AutoFilterCondition="Contains">
                                            <Settings AutoFilterCondition="Contains" />
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="Status" Name="Status" Settings-AutoFilterCondition="Contains">
                                            <Settings AutoFilterCondition="Contains" />
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="C-Trade Value" Name="C-Trade Value" PropertiesTextEdit-DisplayFormatString="n" Settings-AutoFilterCondition="Contains">
                                            <Settings AutoFilterCondition="Contains" />
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="Asset Manager Value" Name="Asset Manager Value" PropertiesTextEdit-DisplayFormatString="n" Settings-AutoFilterCondition="Contains">
                                            <Settings AutoFilterCondition="Contains" />
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="Value Variance" Name="Value Variance" PropertiesTextEdit-DisplayFormatString="n" Settings-AutoFilterCondition="Contains">
                                            <Settings AutoFilterCondition="Contains" />
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="Value Status" Name="Value Status" Settings-AutoFilterCondition="Contains">
                                            <Settings AutoFilterCondition="Contains" />
                                        </dx:GridViewDataTextColumn>
                                          <dx:GridViewDataTextColumn FieldName="Comment" Name="Comment" Settings-AutoFilterCondition="Contains">
                                            <Settings AutoFilterCondition="Contains" />
                                        </dx:GridViewDataTextColumn>
                                    </Columns>
                                </dx:ASPxGridView>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="9">
                                <dx:ASPxGridView ID="ASPxGridView3" runat="server" AutoGenerateColumns="True" Settings-ShowTitlePanel="true" SettingsBehavior-ProcessSelectionChangedOnServer="true" SettingsText-Title="" Theme="Glass" Width="100%" Visible="False">
                                                                   
                                </dx:ASPxGridView>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="9" align="center">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td align="center" colspan="9">
                                <dx:ASPxPopupControl ID="ASPxPopupControl1" runat="server" BackColor="#DDECFE" CloseAction="CloseButton" EnableCallbackAnimation="True" HeaderText="Comments" ShowCollapseButton="True" ShowPageScrollbarWhenModal="True" ShowPinButton="True" Theme="Office2010Blue" Width="400px">
        <contentcollection>
<dx:popupcontrolcontentcontrol runat="server" SupportsDisabledAttribute="True">
    <dx1:aspxroundpanel ID="ASPxRoundPanel6" runat="server" BackColor="White" ShowHeader="False" Width="100%">
        <panelcollection>
            <dx:panelcontent runat="server" SupportsDisabledAttribute="True">
                <table style="width: 100%">
                    <tr>
                        <td align="right" style="height: 57px">
                            <dx:aspxlabel ID="ASPxLabel60" runat="server" Text="Comments" Theme="iOS">
                            </dx:aspxlabel>
                        </td>
                        <td align="left" style="height: 57px">
                            <dx:aspxtextbox ID="txtotp" runat="server" Theme="iOS" Width="242px">
                           
                            </dx:aspxtextbox>
                             <asp:Label ID="lbltransid" runat="server" Visible="False"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">&#160;</td>
                        <td align="left">
                            <dx:aspxbutton ID="btnSaveContract1" runat="server" CausesValidation="False" Text="Submit" Theme="Glass">
                            </dx:aspxbutton>
                        </td>
                    </tr>
                  
                  
                </table>
            </dx:panelcontent>
        </panelcollection>
    </dx1:aspxroundpanel>
            </dx:popupcontrolcontentcontrol>
</contentcollection>
    </dx:ASPxPopupControl>
                            </td>
                        </tr>
            </table>
            </asp:Panel>

      
            
        </td>
    </tr>

   
</table>
</asp:Panel>

</asp:Content>

