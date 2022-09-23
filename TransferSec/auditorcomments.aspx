<%@ Page Language="VB" MasterPageFile="~/CDSUser.master" AutoEventWireup="false" CodeFile="auditorcomments.aspx.vb" Inherits="TransferSec_auditorcomments" title="Auditor Comments" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<asp:Content id="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
    <asp:Panel id="Panel1" runat="server" Width="840px" Font-Names="Arial" Font-Size="Medium" BackColor="White">
    
        <table width ="810px">
            <tr>
                   <td style ="text-align :left;" align="left">
                       <dx:ASPxLabel ID="ASPxLabel1" runat="server" Text="Trading&gt;&gt;Auditor Comments" Font-Names="Cambria" Font-Size="Small" Theme="PlasticBlue"></dx:ASPxLabel>

                   </td>
            </tr>
        </table>
        <asp:Panel runat="server" ID="PanelType" Font-Names="Cambria" GroupingText="Auditor Comments">
            <br />
            <table style="width: 828px">
                <tr>
                    <td>
                         <table style="width: 100%">
                             <tr>
                                 <td style="width: 87px; height: 32px">
                                     <asp:Label ID="Label2" runat="server" Text="Date From"></asp:Label>
                                 </td>
                                 <td style="height: 32px; width: 124px">
                                     <dx:ASPxDateEdit ID="txtDateFrom" runat="server">
                                     </dx:ASPxDateEdit>
                                 </td>
                                 <td style="height: 32px; width: 67px">
                                     <asp:Label ID="Label3" runat="server" Text="Date to"></asp:Label>
                                 </td>
                                 <td style="height: 32px; width: 177px">
                                     <dx:ASPxDateEdit ID="txtDateFrom0" runat="server">
                                     </dx:ASPxDateEdit>
                                 </td>
                                 <td style="height: 32px">
                                     <asp:Button ID="Button2" runat="server" BackColor="#023E5A" ForeColor="White" Height="28px" Text="Get Records" Width="120px" />
                                 </td>
                             </tr>
                         </table>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:GridView ID="grdsellers" runat="server" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" CssClass="tablestyle"  Font-Size="Small" ForeColor="Black" GridLines="None" Style="position: relative; top: 0px; left: 0px; width:100%; height: 3px;">
                            <PagerSettings FirstPageText="First" LastPageText="Last" NextPageText="Next" PreviousPageText="Previous" />
                            <AlternatingRowStyle CssClass="altrowstyle" />
                            <HeaderStyle BackColor="#023E5A" ForeColor="White" HorizontalAlign="Left" />
                            <RowStyle CssClass="rowstyle" />
                        </asp:GridView>
                    </td>
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

