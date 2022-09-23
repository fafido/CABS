<%@ Page Language="VB" MasterPageFile="~/CDSUser.master" AutoEventWireup="false" CodeFile="OTCMatching.aspx.vb" Inherits="TransferSec_OTCMatching" title="OTC" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<asp:Content id="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
    <asp:Panel id="Panel1" runat="server" Width="840px" Font-Names="Arial" Font-Size="Medium" BackColor="White">
    
        <table width ="810px">
            <tr>
                   <td style ="text-align :left;" align="left">
                       <dx:ASPxLabel ID="ASPxLabel1" runat="server" Text="Trading&gt;&gt;O.T.C Matching" Font-Names="Cambria" Font-Size="Small" Theme="PlasticBlue"></dx:ASPxLabel>

                   </td>
            </tr>
        </table>
<asp:Panel runat="server" ID="panelMarketWatch" Font-Names="Cambria" GroupingText="Market Watch View">
        <table>

            <tr>

                <td colspan =" 8" align="center">
                    <dx:ASPxGridView ID="ASPxGridView1" runat="server" Theme="Metropolis" Width="785px">
                    </dx:ASPxGridView>
                </td>
            </tr>
        </table>

</asp:Panel>
        <asp:Panel runat="server" ID="PanelOrders" Font-Names="Cambria" GroupingText="Orders View">

            <table>
                    <tr>
                            <td colspan ="8">

                                <table>
                                    <tr>
                                        <td colspan ="3" align="center"><asp:Panel runat="server" ID="PanelMakers" Font-Names="Cambria" GroupingText="Makers">
                                            <dx:ASPxListBox ID="lstMakers" runat="server" ValueType="System.String" Theme="DevEx" Width="300px"></dx:ASPxListBox>

                                                                        </asp:Panel></td>
                                        <td colspan ="2" align="center">
                                            <dx:ASPxButton ID="ASPxButton8" runat="server" Text="match" Theme="Glass">
                                            </dx:ASPxButton>
                                        </td>
                                        <td colspan ="3" align="center"><asp:Panel runat="server" ID="PanelSellers" Font-Names="Cambria" GroupingText="Sellers">
                                            <dx:ASPxListBox ID="lstSellers" runat="server" ValueType="System.String" Theme="Aqua" Width="300px"></dx:ASPxListBox>
                                                                        </asp:Panel></td>

                                    </tr>

                                </table>
                            </td>

                    </tr>

            </table>
        </asp:Panel>
        <asp:Panel runat="server" ID="PanelType" Font-Names="Cambria" GroupingText="Matched Orders">

            <table width ="810px">
             
               
                <tr>
                <td colspan ="8" align="center">
                    <dx:ASPxGridView ID="grdMatchedSummary" runat="server" Theme="BlackGlass" Width="710px">
                    </dx:ASPxGridView>
                    </td>
               
           </tr>

            </table>
        </asp:Panel>
         
                 
</asp:Panel>
  
</div>
</asp:Content>

