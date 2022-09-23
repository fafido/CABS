<%@ Page Language="VB" MasterPageFile="~/CDSUser.master" AutoEventWireup="false" CodeFile="ApproveSplitEWR.aspx.vb" Inherits="TransferSec_ApproveSplitEWR" title="Approve Split EWR" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<asp:Content id="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
    <asp:Panel id="Panel1" runat="server" Width="100%" Font-Names="Arial" Font-Size="Medium" BackColor="White">
    
        <table width ="100%">
            <tr>
                   <td style ="text-align :left;" align="left">
                       <dx:ASPxLabel ID="ASPxLabel1" runat="server" Text="Authorisations&gt;&gt;Splits" Font-Names="Cambria" Font-Size="Small" Theme="PlasticBlue"></dx:ASPxLabel>

                   </td>
            </tr>
        </table>

          <asp:panel id="Panel2" runat="server" GroupingText="Search Options" Font-Names="Cambria" Width="100%">
        <table width="100%">
            <tr>
                <td colspan ="1" align="right" class="auto-style10" style="width: 206px">
                    <dx:ASPxLabel ID="ASPxLabel2" runat="server" Font-Names="Cambria" Font-Size="Small" Text="WR #" Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                <td colspan ="1" width="301">
                    <dx:ASPxTextBox ID="txtWRNo" runat="server" Theme="Glass" Width="300px">
                    </dx:ASPxTextBox>
                </td>
                <td colspan ="1">
                    <dx:ASPxButton ID="ASPxButton1" runat="server" Text="&gt;&gt;" Width="38px" Theme="BlackGlass">
                    </dx:ASPxButton>
                </td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>

            </tr>
             <tr>
                <td colspan ="1" align="right" class="auto-style10" style="width: 206px">
                    <dx:ASPxLabel ID="ASPxLabel3" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Depositor Name." Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                <td colspan ="1" width="301">
                    <dx:ASPxTextBox ID="txtClientName" runat="server" Theme="Glass" Width="300px">
                    </dx:ASPxTextBox>
                </td>
                <td colspan ="1">
                    <dx:ASPxButton ID="ASPxButton2" runat="server" Text="&gt;&gt;" Width="38px" Theme="BlackGlass">
                    </dx:ASPxButton>
                </td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>

            </tr>

            <tr>
                <td colspan="5">
                    <asp:GridView ID="grdAvailableWRs" runat="server" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="id" EmptyDataText="No Relevant Data Found" ForeColor="#333333" Height="16px" Width="100%" Font-Size="Small">
                        <PagerSettings FirstPageText="First" LastPageText="Last" NextPageText="Next" PreviousPageText="Previous" />
                        <AlternatingRowStyle CssClass="altrowstyle" BackColor="White" />
                        <Columns>
                            <asp:BoundField DataField="ReceiptNo" HeaderText="WR#" />
                            <asp:BoundField DataField="DepositorAcc" HeaderText="Depositor Acc#" />
                            <asp:BoundField DataField="DepositorName" HeaderText="Depositor Name" />
                            <asp:BoundField DataField="Commodity" HeaderText="Commodity" />
                            <asp:BoundField DataField="Quantity" HeaderText="Quantity" />
                            <asp:CommandField SelectText="View Split" ShowSelectButton="true" />
                        </Columns>
                        <EditRowStyle BackColor="white" />
                        <FooterStyle BackColor="white" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle CssClass="headerstyle" BackColor="#B7D8DC"  HorizontalAlign="left" ForeColor="Black" />
                        <PagerStyle BackColor="white" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle CssClass="rowstyle" BackColor="white" />
                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#F5F7FB" />
                        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                        <SortedDescendingCellStyle BackColor="#E9EBEF" />
                        <SortedDescendingHeaderStyle BackColor="#4870BE" />
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td colspan="1" class="auto-style10" style="width: 206px">&nbsp;</td>
                <td width="301">&nbsp;</td>
                <td colspan="1">&nbsp;</td>
                <td colspan="1">&nbsp;</td>
                <td colspan="1">&nbsp;</td>
            </tr>

            <tr>
                <td colspan="5">
                    <asp:GridView ID="grdSplits" runat="server" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="id" EmptyDataText="No Relevant Data Found" ForeColor="#333333" Height="16px" Width="100%" Font-Size="Small">
                        <PagerSettings FirstPageText="First" LastPageText="Last" NextPageText="Next" PreviousPageText="Previous" />
                        <AlternatingRowStyle BackColor="White" CssClass="altrowstyle" />
                        <Columns>
                            <asp:BoundField DataField="TransactionRef" HeaderText="Reference" HeaderStyle-HorizontalAlign="Left"/>
                            <asp:BoundField DataField="WRChildSuffix" HeaderText="Suffix" HeaderStyle-HorizontalAlign="Left" />
                            <asp:BoundField DataField="ChildQTY" HeaderText="Split Quantity" HeaderStyle-HorizontalAlign="Left" />
                           
                        </Columns>
                        <EditRowStyle BackColor="#2461BF" />
                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#B7D8DC" CssClass="headerstyle"  ForeColor="Black" />
                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="white" CssClass="rowstyle" />
                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#F5F7FB" />
                        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                        <SortedDescendingCellStyle BackColor="#E9EBEF" />
                        <SortedDescendingHeaderStyle BackColor="#4870BE" />
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td colspan="1" class="auto-style10" style="width: 206px">&nbsp;</td>
                <td width="301">&nbsp;</td>
                <td colspan="1">&nbsp;</td>
                <td colspan="1">&nbsp;</td>
                <td colspan="1">&nbsp;</td>
            </tr>

        </table>

    </asp:panel>
        <asp:Panel runat="server" ID="Panel8" Font-Names="Cambria" GroupingText="" Font-Size="Medium">

                <table width="810px">
<tr>
        
    <td colspan ="8" align="center">
        
        &nbsp;</td>
   

</tr>
                 
        </table>
        </asp:Panel>
         <asp:Panel runat="server" ID="Panel5" Font-Names="Cambria" GroupingText="Approve" Font-Size="Medium" Width="100%" Visible="False">

                <table width="100%">
                    <tr>
                            <td colspan ="1" style="height: 18px">
                                <dx:ASPxLabel ID="ASPxLabel4" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Remaks" Theme="Glass" Visible="False">
                                </dx:ASPxLabel>
                            </td>
                        <td style="height: 18px">
                            &nbsp;</td>

                    </tr>
                             <tr>
                                 <td colspan="2" style="height: 18px">
                                     <asp:TextBox ID="txtRemarks" runat="server" Height="146px" Rows="5" Width="760px" Visible="False"></asp:TextBox>
                                 </td>
                    </tr>
                    <tr>
                        <td colspan="1" style="height: 18px">&nbsp;</td>
                        <td style="height: 18px">&nbsp;</td>
                    </tr>

        </table>
        </asp:Panel>
               
        <asp:Panel ID="Panel9" runat="server" Enabled="True" Font-Names="Cambria" Font-Size="Medium" GroupingText="Finish" Width="100%">
            <table width="100%">


                <tr>
                        <td  align="center" colspan="7" style="height: 41px">
                            <dx:ASPxButton ID="ASPxButton12" runat="server" Text="Approve" Theme="BlackGlass">
                            </dx:ASPxButton>
                            &nbsp;<dx:ASPxButton ID="ASPxButton13" runat="server" style="height: 23px" Text="Reject" Theme="BlackGlass">
                            </dx:ASPxButton>
                        </td>
                    </tr>

                <%--<tr>
                    <td align="center" colspan="8">
                        <dx:ASPxButton ID="ASPxButton13" runat="server" Text="Save Batch Details" Theme="BlackGlass">
                        </dx:ASPxButton>
                        &nbsp;
                        <dx:ASPxButton ID="ASPxButton14" runat="server" Text="Delete Batch Details" Theme="BlackGlass">
                        </dx:ASPxButton>
                    </td>
                </tr>--%>
                <tr>
                    <td colspan="1">&nbsp;</td>
                    <td align="center">&nbsp;</td>
                    <td colspan="1" style="width: 158px">
                        &nbsp;</td>
                    <td colspan="1">
                        &nbsp;</td>
                    <td colspan="1">&nbsp;</td>
                    <td colspan="1">&nbsp;</td>
                    <td colspan="1">&nbsp;</td>
                </tr>
            </table>
        </asp:Panel>
               
</asp:Panel>
  
</div>
</asp:Content>

