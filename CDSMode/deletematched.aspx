<%@ Page Language="VB" MasterPageFile="~/CDSUser.master" AutoEventWireup="false" CodeFile="deletematched.aspx.vb" Inherits="TransferSec_deletematched" title="Delete/Cancel Trades" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<%@ Register assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxPopupControl" tagprefix="dx" %>
<asp:Content id="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
    <asp:Panel id="Panel1" runat="server" Width="840px" Font-Names="Arial" Font-Size="Medium" BackColor="White">
    
        <table width ="810px">
            <tr>
                   <td style ="text-align :left;" align="left">
                       <dx:ASPxLabel ID="ASPxLabel1" runat="server" Text="Settlement&gt;&gt;Delete Matched" Font-Names="Cambria" Font-Size="Small" Theme="PlasticBlue"></dx:ASPxLabel>

                   </td>
            </tr>
        </table>

          <asp:panel id="Panel2" runat="server" GroupingText="Search Options" Font-Names="Cambria" Visible="False">
        <table width="810px">
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
        <asp:Panel runat="server" ID="Panel3" Font-Names="Cambria" GroupingText="New Accounts">

                <table width="810px">
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
                        <dx:ASPxButton ID="ASPxButton3" runat="server" Text="View" Theme="BlackGlass"  Width="60px">
                        </dx:ASPxButton>
                    </td>
                </tr>
            </table>
        </td>

</tr>
               
                    
                    <tr>
                        <td>
                            <asp:GridView ID="grdApps" runat="server" AllowPaging="True" CellPadding="4" CssClass="table table-bordered table-striped tablestyle success" EmptyDataRowStyle-CssClass="text-warning text-center" EmptyDataText="No Trades Found!" ForeColor="#333333" GridLines="None" HorizontalAlign="Left">
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
                                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                <SortedAscendingCellStyle BackColor="#F5F7FB" />
                                <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                                <SortedDescendingCellStyle BackColor="#E9EBEF" />
                                <SortedDescendingHeaderStyle BackColor="#4870BE" />
                            </asp:GridView>
                        </td>
                    </tr>
               
                    
                    <tr>
                        <td>
                            <dx:ASPxPopupControl ID="ASPxPopupControl1" runat="server" HeaderText="Delete Matched" Theme="Moderno" Width="493px">
                                <HeaderStyle Font-Bold="True" />
                                <ContentCollection>
                                    <dx:PopupControlContentControl runat="server" SupportsDisabledAttribute="True">
                                        <table class="dxflInternalEditorTable_Moderno">
                                            <tr>
                                                <td>
                                                    <dx:ASPxLabel ID="ASPxLabel7" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Trade ID" Theme="iOS">
                                                    </dx:ASPxLabel>
                                                </td>
                                                <td>
                                                    <dx:ASPxTextBox ID="ASPxTextBox1" THEME="iOS" runat="server" Width="276px" ReadOnly="True">
                                                    </dx:ASPxTextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <dx:ASPxLabel ID="ASPxLabel6" runat="server" Font-Names="Cambria" Font-Size="Small" Text="New Settlement Date" Theme="iOS">
                                                    </dx:ASPxLabel>
                                                </td>
                                                <td>
                                                    <dx:ASPxTextBox ID="ASPxTextBox2" runat="server" ReadOnly="True" Theme="iOS" Width="276px">
                                                    </dx:ASPxTextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>&nbsp;</td>
                                                <td>
                                                    <dx:ASPxButton ID="ASPxButton4" runat="server" Text="Delete" Theme="iOS" Width="144px">
                                                    </dx:ASPxButton>
                                                </td>
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

