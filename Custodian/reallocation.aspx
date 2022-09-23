<%@ Page Language="VB" MasterPageFile="~/CDSUser.master" AutoEventWireup="false" CodeFile="reallocation.aspx.vb" Inherits="TransferSec_reallocation" title="Re-Allocation" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<%@ Register assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxPopupControl" tagprefix="dx" %>
<asp:Content id="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
    <asp:Panel id="Panel1" runat="server" Width="100%" Font-Names="Arial" Font-Size="Medium" BackColor="White">
    
        <table width ="100%">
            <tr>
                   <td style ="text-align :left;" align="left">
                       <dx:ASPxLabel ID="ASPxLabel1" runat="server" Text="Fixed Income Investments Settlements&gt;&gt;Re-Allocation" Font-Names="Cambria" Font-Size="Small" Theme="PlasticBlue"></dx:ASPxLabel>

                   </td>
            </tr>
        </table>

          <asp:panel id="Panel2" runat="server" GroupingText="Search Options" Font-Names="Cambria" Visible="False">
        <table width="100%">
            <tr>
                <td colspan ="1" align="right" style="height: 20px">
                    <dx:ASPxLabel ID="ASPxLabel2" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Batch No." Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                <td colspan ="1" width="301" style="height: 20px">
                    <dx:ASPxTextBox ID="txtClientNoSe" runat="server" Theme="Glass" Width="300px">
                    </dx:ASPxTextBox>
                </td>
                <td colspan ="1" style="height: 20px">
                    <dx:ASPxButton ID="ASPxButton1" runat="server" Text="&gt;&gt;" Width="38px" Theme="BlackGlass">
                    </dx:ASPxButton>
                </td>
                <td colspan ="1" style="height: 20px"></td>
                <td colspan ="1" style="height: 20px"></td>

            </tr>
             <tr>
                <td colspan ="1" align="right">
                    <dx:ASPxLabel ID="ASPxLabel3" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Client Name." Theme="Glass" Visible="False">
                    </dx:ASPxLabel>
                </td>
                <td colspan ="1" width="301">
                    <dx:ASPxTextBox ID="txtClientName" runat="server" Theme="Glass" Width="300px" Visible="False">
                    </dx:ASPxTextBox>
                </td>
                <td colspan ="1">
                    <dx:ASPxButton ID="ASPxButton2" runat="server" Text="&gt;&gt;" Width="38px" Theme="BlackGlass" Visible="False">
                    </dx:ASPxButton>
                </td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>

            </tr>
            <tr>
                <td colspan ="1">
                    &nbsp;</td>
                <td width="301">
                    <dx:ASPxComboBox ID="cmbBatchType" runat="server" Theme="BlackGlass" ValueType="System.String" Width="250px" Visible="False">
                    </dx:ASPxComboBox>
                </td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>

            </tr>
            <tr>
                <td colspan ="1">
                    &nbsp;</td>
                <td width="301">
                    &nbsp;</td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>

            </tr>

        </table>

    </asp:panel>
        <asp:Panel runat="server" ID="Panel3" Font-Names="Cambria" GroupingText="Search Trade to Re-Allocate">

                <table width="100%">
<tr>
        <td>
            <table class="auto-style1" style="width: 32%">
                <tr>
                    <td>
                        <dx:ASPxLabel ID="ASPxLabel4" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Date From" Theme="Glass" >
                        </dx:ASPxLabel>
                    </td>
                    <td>
                        <dx:ASPxDateEdit ID="txtdatefrom" runat="server">
                        </dx:ASPxDateEdit>
                    </td>
                </tr>
                <tr>
                    <td>
                        <dx:ASPxLabel ID="ASPxLabel5" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Date to" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td>
                        <dx:ASPxDateEdit ID="txtdateto" runat="server">
                        </dx:ASPxDateEdit>
                    </td>
                </tr>
                
                <tr>
                    <td>&nbsp;</td>
                    <td>
                        <dx:ASPxButton ID="ASPxButton3" runat="server" Text="Search Trade" Theme="BlackGlass"  Width="102px" Height="23px">
                        </dx:ASPxButton>
                    </td>
                </tr>
               
            </table>
        </td>

</tr>
               
                    
                    <tr>
                        <td>
                            <asp:GridView ID="grdApps" runat="server" width="100%" AllowPaging="False" CellPadding="4"  EmptyDataRowStyle-CssClass="text-warning text-center" EmptyDataText="No Trades Found!" ForeColor="#333333" Height="16px"  BackColor="White" Font-Size="Small">
                                <AlternatingRowStyle BackColor="White" CssClass="altrowstyle" />
                                <EditRowStyle BackColor="#2461BF" />
                                <EmptyDataRowStyle CssClass="text-warning text-center" />
                                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                <HeaderStyle BackColor="#507CD1" CssClass="header info" Font-Bold="True" ForeColor="White" />
                                <RowStyle BackColor="#EFF3FB" CssClass="rowstyle" />
                                <PagerStyle BackColor="#2461BF" CssClass="pagination-ys" ForeColor="White" HorizontalAlign="Center" />
                                <Columns>
                                    <asp:CommandField ItemStyle-Width="12.5%" SelectText="Select" ShowSelectButton="True">
                                    <ItemStyle Width="12.5%" />
                                    </asp:CommandField>
                                </Columns>
                                <EditRowStyle BackColor="White" />
                        <FooterStyle BackColor="White" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle CssClass="headerstyle" BackColor="#B7D8DC" ForeColor="Black" HorizontalAlign="left" />
                        <PagerStyle BackColor="White" ForeColor="#B7D8DC" HorizontalAlign="left" />
                        <RowStyle CssClass="rowstyle" BackColor="White" />
                        <SelectedRowStyle BackColor="#D1DDF1"  ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#F5F7FB" />
                        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                        <SortedDescendingCellStyle BackColor="#E9EBEF" />
                        <SortedDescendingHeaderStyle BackColor="#4870BE" />
                            </asp:GridView>
                        </td>
                    </tr>
               
                    
                    <tr>
                        <td>
                            <dx:ASPxPopupControl ID="ASPxPopupControl1" runat="server" HeaderText="Update Settlement Date" Theme="Moderno" Width="493px">
                                <HeaderStyle Font-Bold="True" />
                                <ContentCollection>
                                    <dx:PopupControlContentControl runat="server" SupportsDisabledAttribute="True">
                                        <table class="dxflInternalEditorTable_Moderno">
                                            <tr>
                                                <td>
                                                    <dx:ASPxLabel ID="ASPxLabel7" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Trade ID" Theme="iOS">
                                                    </dx:ASPxLabel>
                                                </td>
                                                <td colspan="2">
                                                    <dx:ASPxTextBox ID="ASPxTextBox1" THEME="iOS" runat="server" Width="276px" ReadOnly="True">
                                                    </dx:ASPxTextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>&nbsp;</td>
                                                <td colspan="2">
                                                    <dx:ASPxRadioButtonList ID="ASPxRadioButtonList1" runat="server" RepeatDirection="Horizontal">
                                                        <Items>
                                                            <dx:ListEditItem Text="Change Buyer" Value="Change Buyer" />
                                                            <dx:ListEditItem Text="Change Seller" Value="Change Seller" />
                                                        </Items>
                                                    </dx:ASPxRadioButtonList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <dx:ASPxLabel ID="ASPxLabel6" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Search CDS/Name" Theme="iOS">
                                                    </dx:ASPxLabel>
                                                </td>
                                                <td style="width: 198px">
                                                    <dx:ASPxTextBox ID="txtsearch" runat="server"  Theme="iOS" Width="100%">
                                                    </dx:ASPxTextBox>
                                                </td>
                                                <td>
                                                    <dx:ASPxButton ID="ASPxButton5" runat="server" Text="Search" Theme="iOS" Width="88px">
                                                    </dx:ASPxButton>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>&nbsp;</td>
                                                <td style="width: 198px">
                                                    <dx:ASPxListBox ID="lstclients" runat="server" Height="81px" Width="280px">
                                                    </dx:ASPxListBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>&nbsp;</td>
                                                <td colspan="2">
                                                    <dx:ASPxButton ID="ASPxButton4" runat="server" Text="Update" Theme="iOS" Width="144px">
                                                    </dx:ASPxButton>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>&nbsp;</td>
                                                <td colspan="2">
                                                    &nbsp;</td>
                                            </tr>
                                        </table>
                            
                                    </dx:PopupControlContentControl>
                                </ContentCollection>
                            </dx:ASPxPopupControl>
                        </td>
                    </tr>
               
                    
        </table>
        </asp:Panel>
        

</asp:Panel>
         
  
</div>
</asp:Content>

