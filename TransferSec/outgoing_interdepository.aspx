<%@ Page Language="VB" MasterPageFile="~/CDSUser.master" AutoEventWireup="false" CodeFile="outgoing_interdepository.aspx.vb" Inherits="TransferSec_outgoing_interdepository" title="Interdepositories" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<asp:Content id="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
    <asp:Panel id="Panel1" runat="server" Width="840px" Font-Names="Arial" Font-Size="Medium" BackColor="White">
    
        <table width ="810px">
            <tr>
                   <td style ="text-align :left;" align="left">
                       <dx:ASPxLabel ID="ASPxLabel1" runat="server" Text="Interdepository&gt;&gt;Outgoing Interdepository" Font-Names="Cambria" Font-Size="Small" Theme="PlasticBlue"></dx:ASPxLabel>

                   </td>
            </tr>
        </table>
         <asp:Panel ID="Panel5" runat="server" Font-Names="Cambria" Font-Size="Medium" GroupingText="Origin Details">
             <table width="810px">
                 <tr>
                     <td colspan="1" style="width: 161px">
                         <dx:ASPxLabel ID="ASPxLabel10" runat="server" Font-Names="Cambria" Font-Size="Small" Text="________________" Theme="Glass">
                         </dx:ASPxLabel>
                     </td>
                     <td colspan="6"></td>
                 </tr>
                 <tr>
                     <td colspan="1" style="width: 161px">
                         <dx:ASPxLabel ID="ASPxLabel6" runat="server" Font-Names="Cambria" Font-Size="Small" Text="CDS Number" Theme="Glass">
                         </dx:ASPxLabel>
                     </td>
                     <td colspan="1" style="width: 248px">
                         <dx:ASPxTextBox ID="txtclientnumber" runat="server" BackColor="#E4E4E4" Height="19px" Theme="BlackGlass" Width="250px">
                         </dx:ASPxTextBox>
                     </td>
                     <td colspan="1">
                         <dx:ASPxButton ID="ASPxButton10" runat="server" Text="&gt;&gt;" Theme="BlackGlass" Height="19px">
                         </dx:ASPxButton>
                     </td>
                     <td colspan="1"></td>
                     <td colspan="1"></td>
                     <td colspan="1"></td>
                     <td colspan="1"></td>
                 </tr>
                 <tr>
                     <td colspan="1" style="width: 161px">&nbsp;</td>
                     <td colspan="2">
                         <asp:ListBox ID="ListBox1" runat="server" Width="372px" AutoPostBack="True"></asp:ListBox>
                     </td>
                     <td colspan="1">&nbsp;</td>
                     <td colspan="1">&nbsp;</td>
                     <td colspan="1">&nbsp;</td>
                     <td colspan="1">&nbsp;</td>
                 </tr>
                 <tr>
                     <td colspan="1" style="width: 161px">
                         <dx:ASPxLabel ID="ASPxLabel75" runat="server" Font-Names="Cambria" Font-Size="Small" Text="CDS Number" Theme="Glass">
                         </dx:ASPxLabel>
                     </td>
                     <td colspan="2">
                         <dx:ASPxComboBox ID="ASPxComboBox1" runat="server" AutoPostBack="True" ValueType="System.String">
                         </dx:ASPxComboBox>
                     </td>
                     <td colspan="1">&nbsp;</td>
                     <td colspan="1">&nbsp;</td>
                     <td colspan="1">&nbsp;</td>
                     <td colspan="1">&nbsp;</td>
                 </tr>
                 <tr>
                     <td colspan="1" style="width: 161px">&nbsp;</td>
                     <td colspan="2">&nbsp;</td>
                     <td colspan="1">&nbsp;</td>
                     <td colspan="1">&nbsp;</td>
                     <td colspan="1">&nbsp;</td>
                     <td colspan="1">&nbsp;</td>
                 </tr>
                 <tr>
                     <td colspan="7">
                         <asp:GridView ID="grdTranShareholder" runat="server" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" EmptyDataText="No Relevant Data Found" ForeColor="Black" GridLines="Vertical" Height="16px" Width="99%" Font-Size="Small">
                             <PagerSettings FirstPageText="First" LastPageText="Last" NextPageText="Next" PreviousPageText="Previous" />
                             <AlternatingRowStyle CssClass="altrowstyle" />
                             <HeaderStyle CssClass="headerstyle" BackColor="#424242" ForeColor="White" />
                             <RowStyle CssClass="rowstyle" />
                         </asp:GridView>
                     </td>
                 </tr>
             </table>
        </asp:Panel>
        <asp:panel id="Panel9" runat="server" GroupingText="Beneficiary Account Details" Font-Names="Cambria" Font-Size="Medium">
        <table width="810px">
            <tr>
                <td colspan ="1" style="width: 163px">
                    <dx:ASPxLabel ID="ASPxLabel70" runat="server" Font-Names="Cambria" Font-Size="Small" Text="________________" Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                <td colspan ="6">
                </td>
                

            </tr>
           <tr>
               <td colspan ="1" style="width: 163px">
                   <dx:ASPxLabel ID="ASPxLabel71" runat="server" Font-Names="Cambria" Font-Size="Small" Text="CDS Number" Theme="Glass">
                   </dx:ASPxLabel>
               </td>
               <td colspan ="1" style="width: 248px">
                   <dx:ASPxTextBox ID="txtclientnumber0" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="250px" Height="19px">
                   </dx:ASPxTextBox>
               </td>

               <td colspan="1">
                   <dx:ASPxButton ID="ASPxButton11" runat="server" Text="&gt;&gt;" Theme="BlackGlass">
                   </dx:ASPxButton>
               </td>
               <td colspan="1"></td>
               <td colspan="1"></td>
               <td colspan="1"></td>
               <td colspan="1"></td>

           </tr>
            <tr>
                    <td colspan ="1" style="width: 163px">
                        &nbsp;</td>
                <td colspan ="2">
                    <asp:ListBox ID="ListBox2" runat="server" Width="372px" AutoPostBack="True"></asp:ListBox>
                    </td>

                    <td colspan="1">&nbsp;</td>
                    <td colspan="1">&nbsp;</td>
                    <td colspan="1">&nbsp;</td>
                    <td colspan="1">&nbsp;</td>

            </tr>

            <tr>
                <td colspan="7">
                    <asp:GridView ID="grdTranShareholder0" runat="server" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" EmptyDataText="No Relevant Data Found" Font-Size="Small" ForeColor="Black" GridLines="Vertical" Height="16px" Width="99%">
                        <PagerSettings FirstPageText="First" LastPageText="Last" NextPageText="Next" PreviousPageText="Previous" />
                        <AlternatingRowStyle CssClass="altrowstyle" />
                        <HeaderStyle BackColor="#424242" CssClass="headerstyle" ForeColor="White" />
                        <RowStyle CssClass="rowstyle" />
                    </asp:GridView>
                </td>
            </tr>

        </table>

    </asp:panel>
        <asp:Panel ID="Panel10" runat="server" Font-Names="Cambria" Font-Size="Medium" GroupingText="Details of Transfer">
            <table width="810px">
                <tr>
                    <td colspan="1" style="width: 168px">
                        <dx:ASPxLabel ID="ASPxLabel72" runat="server" Font-Names="Cambria" Font-Size="Small" Text="________________" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td colspan="6"></td>
                </tr>
                <tr>
                    <td colspan="1" style="width: 168px">
                        <dx:ASPxLabel ID="ASPxLabel73" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Quantity to Transfer" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td colspan="1" style="width: 248px">
                        <dx:ASPxTextBox ID="txtquantity" runat="server" BackColor="#E4E4E4" Height="19px" Theme="BlackGlass" Width="170px">
                        </dx:ASPxTextBox>
                    </td>
                    <td colspan="1">&nbsp;</td>
                    <td colspan="1"></td>
                    <td colspan="1"></td>
                    <td colspan="1"></td>
                    <td colspan="1"></td>
                </tr>
                <tr>
                    <td colspan="1" style="width: 168px; height: 26px">
                        <dx:ASPxLabel ID="ASPxLabel74" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Reason for Transfer" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td colspan="6" style="height: 26px;">
                        <dx:ASPxTextBox ID="txtreasonfortrans" runat="server" BackColor="#E4E4E4" Height="22px" Theme="BlackGlass" Width="420px">
                        </dx:ASPxTextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="1" style="width: 168px; height: 18px"></td>
                    <td colspan="1" style="width: 248px; height: 18px;"></td>
                    <td colspan="1" style="height: 18px"></td>
                    <td colspan="1" style="height: 18px"></td>
                    <td colspan="1" style="height: 18px"></td>
                    <td colspan="1" style="height: 18px"></td>
                    <td colspan="1" style="height: 18px"></td>
                </tr>
                <tr>
                    <td colspan="1" style="width: 168px; height: 18px">&nbsp;</td>
                    <td colspan="1" style="width: 248px; height: 18px;">&nbsp;</td>
                    <td colspan="1" style="height: 18px">&nbsp;</td>
                    <td colspan="1" style="height: 18px">&nbsp;</td>
                    <td colspan="1" style="height: 18px">&nbsp;</td>
                    <td colspan="1" style="height: 18px">&nbsp;</td>
                    <td colspan="1" style="height: 18px">&nbsp;</td>
                </tr>
                <tr>
                    <td align="center" colspan="7" style="height: 17px">
                        <dx:ASPxButton ID="ASPxButton12" runat="server" Text="Save" Theme="BlackGlass">
                        </dx:ASPxButton>
                    </td>
                </tr>
            </table>
        </asp:Panel>
                 
</asp:Panel>
  
</div>
</asp:Content>

