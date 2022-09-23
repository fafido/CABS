<%@ Page Language="VB" MasterPageFile="~/CDSUser.master" AutoEventWireup="false" CodeFile="UploadRecon.aspx.vb" Inherits="UploadRecon" title="Reconciliation" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxRoundPanel" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxTabControl" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>


<%@ Register assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dx" %>


<%@ Register assembly="DevExpress.XtraCharts.v13.2.Web, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.XtraCharts.Web" tagprefix="dxchartsui" %>
<%@ Register assembly="DevExpress.XtraCharts.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.XtraCharts" tagprefix="cc1" %>


<%@ Register assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxFileManager" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxUploadControl" tagprefix="dx" %>


<%@ Register assembly="DevExpress.Web.ASPxScheduler.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxScheduler.Controls" tagprefix="dxwschsc" %>
<%@ Register assembly="DevExpress.Web.ASPxScheduler.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxScheduler" tagprefix="dxwschs" %>


<%@ Register assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxRatingControl" tagprefix="dx" %>


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
                <td style="width: 870px" align="left">
                    <asp:Label id="Label1" runat="server" text="Utilities&gt;&gt;Upload Recon File" font-names="Cambria" width="150px"></asp:Label></td>
            </tr>
                               
            </table>  
            <asp:Panel runat="server" ID="PanelASet" Font-Names="Cambria" GroupingText="Upload File">
                 <table>
                     <tr>
                            <td colspan ="1">
                                <dx:ASPxLabel ID="ASPxLabel3" runat="server" Text="Channel" Theme="Glass">
                                </dx:ASPxLabel>
                            </td>
                         <td colspan ="1">
                             <dx:ASPxComboBox ID="ASPxComboBox1" runat="server">
                                 <Items>
                                     <dx:ListEditItem Text="Telecel" Value="Telecel" />
                                       <dx:ListEditItem Text="Econet" Value="Econet" />
                                      <dx:ListEditItem Text="Paynow" Value="Paynow" />
                                 </Items>
                             </dx:ASPxComboBox>
                            </td>
                         <td colspan ="1">&nbsp;</td>
                         <td colspan ="1">&nbsp;</td>
                         <td colspan ="1">&nbsp;</td>
                         <td colspan ="1">&nbsp;</td>
                         <td colspan ="1">&nbsp;</td>
                         <td colspan ="1">&nbsp;</td>

                     </tr>
                     <tr>
                         <td colspan="1">
                             <dx:ASPxLabel ID="ASPxLabel2" runat="server" Text="File Location" Theme="Glass">
                             </dx:ASPxLabel>
                         </td>
                         <td colspan="1">
                             <asp:FileUpload ID="FileUpload1" runat="server" />
                         </td>
                         <td colspan="1"></td>
                         <td colspan="1"></td>
                         <td colspan="1"></td>
                         <td colspan="1"></td>
                         <td colspan="1"></td>
                         <td colspan="1"></td>
                     </tr>
                     <tr>
                            <td colspan ="1">
                                &nbsp;</td>
                         <td colspan ="1">
                             <dx:ASPxButton ID="ASPxButton2" runat="server" Text="Import" Theme="BlackGlass">
                             </dx:ASPxButton>
                             &nbsp;<dx:ASPxButton ID="ASPxButton3" runat="server" Text="View Exceptions" Theme="BlackGlass">
                             </dx:ASPxButton>
                            </td>
                         <td colspan ="1"></td>
                         <td colspan ="1"></td>
                         <td colspan ="1"></td>
                         <td colspan ="1"></td>
                         <td colspan ="1"></td>
                         <td colspan ="1"></td>

                     </tr>
                     <tr>
                            <td colspan ="8">
<asp:Panel runat="server" ID="BackUphistory" Font-Names="Cambria" GroupingText="Accounts Upload" Width="843px" Visible="False">
    <dx:ASPxGridView ID="ASPxGridView1" runat="server" Theme="BlackGlass" Width="700px">
    </dx:ASPxGridView>
                                </asp:Panel>

                            </td>
                         
                     </tr>
 
                                           
            </table>    
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

