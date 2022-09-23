<%@ Page Language="VB" MasterPageFile="~/CDSUser.master" AutoEventWireup="false" CodeFile="splitewr.aspx.vb" Inherits="TransferSec_splitewr" title="Split EWR" %>
<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<%@ Register assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxRoundPanel" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxPanel" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.Aspxdateedit" tagprefix="dx" %>


<%@ Register assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxFormLayout" tagprefix="dx" %>


<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxRibbon" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxFormLayout" TagPrefix="dx" %>

<%@ Register assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxDocking" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxPopupControl" tagprefix="dx" %>
<asp:Content id="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
    <asp:Panel id="Panel1" runat="server" Width="100%" Font-Names="Arial" Font-Size="Medium" BackColor="White">
    
        <table width ="100%">
            <tr>
                   <td style ="text-align :left;" align="left">
                       <dx:ASPxLabel ID="ASPxLabel1" runat="server" Text="Batching&gt;&gt;Split" Font-Names="Cambria" Font-Size="Small" Theme="PlasticBlue"></dx:ASPxLabel>

                   </td>
            </tr>
        </table>

          <asp:panel id="Panel2" runat="server" GroupingText="Search Options" Font-Names="Cambria">
        <table width="100%">
            <tr>
                <td colspan ="1" align="right" style="width: 253px">
                    &nbsp;</td>
                <td colspan ="1" width="301">
                    <asp:RadioButtonList ID="rblTranType" runat="server">
                        <asp:ListItem>New Transaction</asp:ListItem>
                        <asp:ListItem>Rejected Entries</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
                <td colspan ="1">
                    &nbsp;</td>
                <td colspan ="1">&nbsp;</td>
                <td colspan ="1">&nbsp;</td>

            </tr>
             <tr>
                 <td align="right" colspan="1" style="width: 253px">&nbsp;</td>
                 <td colspan="1" width="301">&nbsp;</td>
                 <td colspan="1">&nbsp;</td>
                 <td colspan="1">&nbsp;</td>
                 <td colspan="1">&nbsp;</td>
            </tr>
            <tr>
                <td align="right" colspan="1" style="width: 253px">
                    <dx:ASPxLabel ID="ASPxLabel2" runat="server" Font-Names="Cambria" Font-Size="Small" Text="WR #" Theme="Glass" Visible="False">
                    </dx:ASPxLabel>
                </td>
                <td colspan="1" width="301">
                    <dx:ASPxTextBox ID="txtWRNo" runat="server" Theme="Glass" Width="300px" Visible="False">
                    </dx:ASPxTextBox>
                </td>
                <td colspan="1">
                    <dx:ASPxButton ID="ASPxButton1" runat="server" Text="&gt;&gt;" Theme="BlackGlass" Width="38px" Visible="False">
                    </dx:ASPxButton>
                </td>
                <td colspan="1"></td>
                <td colspan="1"></td>
            </tr>
             <tr>
                <td colspan ="1" align="right" style="width: 253px">
                    <dx:ASPxLabel ID="ASPxLabel3" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Depositor Name./Receipt No." Theme="Glass">
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
                    <asp:GridView ID="grdAvailableWRs" runat="server" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="id" EmptyDataText="No Relevant Data Found" OnPageIndexChanging="grdAvailableWRs_PageIndexChanged"  ForeColor="#333333" Height="16px" Width="99%" BackColor="White" Font-Size="Small" AllowPaging="True">
                        <PagerSettings FirstPageText="First" LastPageText="Last" NextPageText="Next" PreviousPageText="Previous"  />
                        <AlternatingRowStyle CssClass="altrowstyle" BackColor="White" />
                        <Columns>
                            <asp:BoundField DataField="ReceiptNo" HeaderText="WR#" />
                            <asp:BoundField DataField="DepositorAcc" HeaderText="Depositor Acc#" />
                            <asp:BoundField DataField="DepositorName" HeaderText="Depositor Name" />
                            <asp:BoundField DataField="Commodity" HeaderText="Commodity" />
                            <asp:BoundField DataField="Quantity" HeaderText="Quantity" />
                            <asp:CommandField SelectText="Split WR" ShowSelectButton="true" />
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
                <td colspan="1" style="width: 253px">&nbsp;</td>
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
         <asp:Panel runat="server" ID="Panel5" Font-Names="Cambria" GroupingText="Split Information" Font-Size="Medium">

                <table width="100%">
                    <tr>
                            <td colspan ="1" style="height: 18px; width: 259px;">
                                <dx:ASPxLabel ID="ASPxLabel37" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Splitting WR" Theme="Glass">
                                </dx:ASPxLabel>
                            </td>
                        <td colspan ="7" style="height: 18px">
                            <dx:ASPxLabel ID="lblWRNo" runat="server" Font-Names="Cambria" Font-Size="Small" Theme="Glass">
                            </dx:ASPxLabel>
                            <asp:TextBox ID="TextBox1" runat="server" Height="16px" Visible="False" Width="38px"></asp:TextBox>
                            </td>

                    </tr>
                             <tr>
                                 <td colspan="1" style="height: 18px; width: 259px;">
                                     <dx:ASPxLabel ID="ASPxLabel41" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Original Quantity" Theme="Glass">
                                     </dx:ASPxLabel>
                                 </td>
                                 <td colspan="7" style="height: 18px">
                                     <dx:ASPxLabel ID="lblOGQty" runat="server" Font-Names="Cambria" Font-Size="Small" Theme="Glass">
                                     </dx:ASPxLabel>
                                 </td>
                    </tr>

                     <tr>
                         <td colspan="1" style="height: 18px; width: 259px;">
                             <dx:ASPxLabel ID="ASPxLabel61" runat="server" Font-Names="Cambria" Font-Size="Small" Text="EWR Accumulated Charges" Theme="Glass">
                             </dx:ASPxLabel>
                         </td>
                         <td colspan="7" style="height: 18px">
                             <dx:ASPxLabel ID="lblaccumulatedcharges" runat="server" Font-Names="Cambria" Font-Size="Small" Theme="Glass">
                             </dx:ASPxLabel>
                         </td>
                    </tr>
                    <tr>
                        <td colspan="1" style="height: 18px; width: 259px;">
                            <dx:ASPxLabel ID="ASPxLabel62" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Transaction Charge" Theme="Glass">
                            </dx:ASPxLabel>
                        </td>
                        <td colspan="7" style="height: 18px">
                            <dx:ASPxLabel ID="lbltransactioncharges" runat="server" Font-Names="Cambria" Font-Size="Small" Theme="Glass">
                            </dx:ASPxLabel>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="1" style="height: 18px; width: 259px;">&nbsp;</td>
                        <td colspan="7" style="height: 18px">&nbsp;</td>
                    </tr>

                     <tr>

                            <td colspan ="1" style="width: 259px">
                                <strong>Add Splits</strong></td>
                        <td colspan ="1">
                            &nbsp;</td>
                        <td colspan ="1">
                            &nbsp;</td>
                        <td colspan ="2">&nbsp;</td>
                        <td colspan ="1">&nbsp;</td>
                        <td colspan ="1">&nbsp;</td>
                        <td colspan ="1">&nbsp;</td>
                    </tr>


                    <tr>

                            <td colspan ="1" style="width: 259px; height: 27px;">
                                <dx:ASPxLabel ID="ASPxLabel5" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Split Quantity" Theme="Glass">
                                </dx:ASPxLabel>
                            </td>
                        <td colspan ="1" style="height: 27px">
                            <dx:ASPxTextBox ID="txtSplitQty" runat="server" BackColor="#E4E4E4" Height="19px" Theme="BlackGlass" Width="250px">
                            </dx:ASPxTextBox>
                            </td>
                        <td colspan ="1" style="height: 27px">
                            </td>
                        <td colspan ="2" style="height: 27px"></td>
                        <td colspan ="1" style="height: 27px"></td>
                        <td colspan ="1" style="height: 27px"></td>
                        <td colspan ="1" style="height: 27px"></td>
                    </tr>

                    <tr>

                            <td colspan ="1" style="width: 259px">
                                <dx:ASPxLabel ID="TransRef" runat="server" Font-Names="Cambria" Font-Size="Small" Theme="Glass" Visible="False">
                                </dx:ASPxLabel>
                            </td>
                        <td colspan ="1">
                            <dx:ASPxButton ID="ASPxButton16" runat="server" Text="Add(+)" Theme="BlackGlass" style="height: 23px">
                            </dx:ASPxButton>
                            </td>
                        <td colspan ="1">
                            &nbsp;</td>
                        <td colspan ="2">&nbsp;</td>
                        <td colspan ="1">&nbsp;</td>
                        <td colspan ="1">&nbsp;</td>
                        <td colspan ="1">&nbsp;</td>
                    </tr>


                    <tr>
                            <td colspan ="8">
                                <asp:GridView ID="grdSplits" runat="server" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="id" EmptyDataText="No Relevant Data Found" ForeColor="#333333" Height="16px" Width="100%" Font-Size="Small">
                                    <PagerSettings FirstPageText="First" LastPageText="Last" NextPageText="Next" PreviousPageText="Previous" />
                                    <AlternatingRowStyle CssClass="altrowstyle" BackColor="White" />
                                    <Columns>
                                         <asp:BoundField DataField="TransactionRef" HeaderText="Reference" HeaderStyle-HorizontalAlign="Left" />
                                         <asp:BoundField DataField="WRChildSuffix" HeaderText="Suffix" HeaderStyle-HorizontalAlign="Left" />
                                        <asp:BoundField DataField="ChildQTY" HeaderText="Split Quantity" HeaderStyle-HorizontalAlign="Left"/>                                  
                                        <asp:CommandField SelectText="Edit Entry" ShowSelectButton="true" HeaderStyle-HorizontalAlign="Left"/>
                                    </Columns>
                                    <EditRowStyle BackColor="White" />
                                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                    <HeaderStyle CssClass="headerstyle" HorizontalAlign="Left" BackColor="#B7D8DC"  ForeColor="Black" />
                                    <PagerStyle BackColor="white" ForeColor="Black" HorizontalAlign="Center" />
                                    <RowStyle CssClass="rowstyle" BackColor="white" />
                                    <SelectedRowStyle BackColor="#B7D8DC" Font-Bold="True" ForeColor="#333333" />
                                    <SortedAscendingCellStyle BackColor="#F5F7FB" />
                                    <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                                    <SortedDescendingCellStyle BackColor="#E9EBEF" />
                                    <SortedDescendingHeaderStyle BackColor="#4870BE" />
                                </asp:GridView>
                            </td>

                    </tr>
                   
<tr>
        
    <td colspan ="2" align="center">
        <dx:ASPxLabel ID="lblOGQty2" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Split Total" Theme="Glass">
        </dx:ASPxLabel>
        <dx:ASPxLabel ID="lblSplitTotal" runat="server" Font-Names="Cambria" Font-Size="Small" Theme="Glass">
        </dx:ASPxLabel>
    </td>
   

    <td align="center" colspan="2">&nbsp;</td>
    <td align="center" colspan="4">&nbsp;&nbsp; &nbsp;</td>
   

</tr>
                 
                    <tr>
                        <td align="center" colspan="2">
                            <dx:ASPxLabel ID="lblOGQty3" runat="server" Font-Names="Cambria" Font-Size="Small" Text="WR Balance" Theme="Glass">
                            </dx:ASPxLabel>
                            <dx:ASPxLabel ID="lblWRBal" runat="server" Font-Names="Cambria" Font-Size="Small" Theme="Glass">
                            </dx:ASPxLabel>
                        </td>
                        <td align="center" colspan="2">&nbsp;</td>
                        <td align="center" colspan="4">&nbsp;</td>
                    </tr>
                 
        </table>
        </asp:Panel>
               
        <asp:Panel ID="Panel9" runat="server" Enabled="True" Font-Names="Cambria" Font-Size="Medium" GroupingText="Finish">
            <table width="100%">


                <tr>
                        <td align="center"  colspan="7">
                            <dx:ASPxButton ID="ASPxButton12" runat="server" Text="Submit" Theme="BlackGlass">
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
                    <td colspan="1">&nbsp;</td>
                    <td colspan="1">&nbsp;</td>
                    <td colspan="1">&nbsp;</td>
                    <td colspan="1">&nbsp;</td>
                </tr>
            </table>
        </asp:Panel>
               
        <asp:Panel ID="Panel10" runat="server" Enabled="True" Font-Names="Cambria" Font-Size="Medium" GroupingText="Pending OTP">
            <table width="100%">
                <tr>
                    <td>
                        <asp:GridView ID="grdOTP" runat="server" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="ReceiptNo" EmptyDataText="No OTP Pendig Splits" ForeColor="#333333" Height="16px" Width="100%" Font-Size="Small">
                            <PagerSettings FirstPageText="First" LastPageText="Last" NextPageText="Next" PreviousPageText="Previous" />
                            <AlternatingRowStyle BackColor="White" CssClass="altrowstyle" />
                            <Columns>
                                <asp:BoundField DataField="ReceiptNo" HeaderText="WR#" />
                                <asp:BoundField DataField="DepositorAcc" HeaderText="Depositor Acc#" />
                                <asp:BoundField DataField="DepositorName" HeaderText="Depositor Name" />
                                <asp:BoundField DataField="Commodity" HeaderText="Commodity" />
                                <asp:BoundField DataField="Quantity" HeaderText="Quantity" />
                                <asp:CommandField SelectText="Enter OTP" ShowSelectButton="true" />
                            </Columns>
                            <EditRowStyle BackColor="#2461BF" />
                            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#B7D8DC" HorizontalAlign="Left" CssClass="headerstyle"  ForeColor="Black" />
                            <PagerStyle BackColor="white" ForeColor="White" HorizontalAlign="Center" />
                            <RowStyle BackColor="white" CssClass="rowstyle" />
                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                            <SortedAscendingCellStyle BackColor="#F5F7FB" />
                            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                            <SortedDescendingCellStyle BackColor="#E9EBEF" />
                            <SortedDescendingHeaderStyle BackColor="#4870BE" />
                        </asp:GridView>
                        <br />
                        <br />
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
                    <td>
                        <dx:ASPxPopupControl ID="ASPxPopupControl1" runat="server" BackColor="#DDECFE" CloseAction="CloseButton" EnableCallbackAnimation="True" HeaderText="Enter OTP to Submit" ShowCollapseButton="True" ShowPageScrollbarWhenModal="True" ShowPinButton="True" Theme="Office2010Blue" Width="400px">
                            <contentcollection>
                                <dx:PopupControlContentControl runat="server" SupportsDisabledAttribute="True">
                                    <dx:ASPxRoundPanel ID="ASPxRoundPanel6" runat="server" BackColor="White" ShowHeader="False" Width="100%">
                                        <panelcollection>
                                            <dx:PanelContent runat="server" SupportsDisabledAttribute="True">
                                                <table style="width: 100%">
                                                    <tr>
                                                        <td align="right">
                                                            <dx:ASPxLabel ID="ASPxLabel60" runat="server" Text="OTP" Theme="iOS">
                                                            </dx:ASPxLabel>
                                                        </td>
                                                        <td align="left">
                                                            <dx:ASPxTextBox ID="txtotp" runat="server" Theme="iOS">
                                                                <MaskSettings ErrorText="Invalid OTP" Mask="0000" />
                                                            </dx:ASPxTextBox>
                                                            <asp:Label ID="lbltransid" runat="server" Visible="False"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right">&nbsp;</td>
                                                        <td align="left">
                                                            <dx:ASPxButton ID="btnSaveContract1" runat="server" CausesValidation="False" Text="Submit" Theme="Glass">
                                                            </dx:ASPxButton>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </dx:PanelContent>
                                        </panelcollection>
                                    </dx:ASPxRoundPanel>
                                </dx:PopupControlContentControl>
                            </contentcollection>
                        </dx:ASPxPopupControl>
                    </td>
                </tr>
            </table>
        </asp:Panel>
               
</asp:Panel>
  
</div>
</asp:Content>

