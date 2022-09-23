<%@ Page Language="VB" MasterPageFile="~/CDSUser.master" AutoEventWireup="false" CodeFile="funds.aspx.vb" Inherits="TransferSec_funds" title="Funds2" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<asp:Content id="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
    <asp:Panel id="Panel1" runat="server" Width="840px" Font-Names="Arial" Font-Size="Medium" BackColor="White">
    
        <table width ="810px">
            <tr>
                   <td style ="text-align :left;" align="left">
                       <dx:ASPxLabel ID="ASPxLabel1" runat="server" Text="Trading&gt;&gt;Funds" Font-Names="Cambria" Font-Size="Small" Theme="PlasticBlue"></dx:ASPxLabel>

                   </td>
            </tr>
        </table>
        <asp:Panel runat="server" ID="PanelType" Font-Names="Cambria" GroupingText="Available Funds">
            <br />
            <table style="width: 828px">
                <tr>
                    <td>
                         <table style="width: 100%">
                             <tr>
                                 <td style="width: 138px; height: 32px">
                                     <asp:Label ID="Label2" runat="server" Text="Account Name"></asp:Label>
                                 </td>
                                 <td style="height: 32px; width: 229px">
                                     <asp:TextBox ID="txtFileName" runat="server" width="194px" Enabled="False">Testbroker1</asp:TextBox>
                                 </td>
                                 <td style="height: 32px; width: 67px">
                                     &nbsp;</td>
                                 <td style="height: 32px; width: 177px">
                                     &nbsp;</td>
                                 <td style="height: 32px">
                                     &nbsp;</td>
                             </tr>
                             <tr>
                                 <td style="width: 138px; height: 32px">
                                     <asp:Label ID="Label3" runat="server" Text="Account No"></asp:Label>
                                 </td>
                                 <td style="height: 32px; width: 229px">
                                     <asp:TextBox ID="txtFileName0" runat="server" width="194px" Enabled="False">000037343769659</asp:TextBox>
                                 </td>
                                 <td style="height: 32px; width: 67px">&nbsp;</td>
                                 <td style="height: 32px; width: 177px">&nbsp;</td>
                                 <td style="height: 32px">&nbsp;</td>
                             </tr>
                             <tr>
                                 <td style="width: 138px; height: 32px">
                                     <asp:Label ID="Label4" runat="server" Text="Branch Code"></asp:Label>
                                 </td>
                                 <td style="height: 32px; width: 229px">
                                     <asp:TextBox ID="txtFileName1" runat="server" width="194px" Enabled="False">0023</asp:TextBox>
                                 </td>
                                 <td style="height: 32px; width: 67px">&nbsp;</td>
                                 <td style="height: 32px; width: 177px">&nbsp;</td>
                                 <td style="height: 32px">&nbsp;</td>
                             </tr>
                             <tr>
                                 <td style="width: 138px; height: 32px">
                                     <asp:Label ID="Label5" runat="server" Text="Total Deposits"></asp:Label>
                                 </td>
                                 <td style="height: 32px; width: 229px">
                                     <asp:TextBox ID="txtFileName2" runat="server" width="194px" Enabled="False"></asp:TextBox>
                                 </td>
                                 <td style="height: 32px; width: 67px">&nbsp;</td>
                                 <td style="height: 32px; width: 177px">&nbsp;</td>
                                 <td style="height: 32px">&nbsp;</td>
                             </tr>
                         </table>
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td align="center">
                        &nbsp;</td>
                </tr>
            </table>
         
        </asp:Panel>
         
                 
</asp:Panel>
  
</div>
</asp:Content>

