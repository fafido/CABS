<%@ Page Language="VB" MasterPageFile="~/CDSUser.master" AutoEventWireup="false" CodeFile="convert.aspx.vb" Inherits="Parameters_convert" title="Convert Currency" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>




<%@ Register assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxPopupControl" tagprefix="dx" %>
<asp:Content id="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
    <asp:Panel id="Panel1" runat="server" Width="840px" Font-Names="Arial" Font-Size="Medium" BackColor="White">
    
        <table width ="810px">
            <tr>
                   <td style ="text-align :left;" align="left">
                       <dx:ASPxLabel ID="ASPxLabel1" runat="server" Text="Approvals&gt;Withdrawal Reversals" Font-Names="Cambria" Font-Size="Small" Theme="PlasticBlue"></dx:ASPxLabel>

                   </td>
            </tr>
        </table>
        <asp:Panel runat="server" ID="Panel5" Font-Names="Cambria" GroupingText="Withdrawal Reversals">

                <table width="810px">
                    <tr>
                            <td colspan ="8" align ="center">
                                &nbsp;</td>

                    </tr>
                    <tr>
                        <td colspan="1">
                            <dx:ASPxLabel ID="ASPxLabel26" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Conversions From" Theme="Glass">
                            </dx:ASPxLabel>
                        </td>
                        <td colspan="1">
                            <dx:ASPxDateEdit ID="cmbfrom" runat="server" Width="250px">
                            </dx:ASPxDateEdit>
                        </td>
                        <td colspan="1">&nbsp;</td>
                        <td colspan="1">&nbsp;</td>
                        <td colspan="1">&nbsp;</td>
                        <td colspan="1">&nbsp;</td>
                        <td colspan="1">&nbsp;</td>
                    </tr>
                    <tr>
                        <td colspan="1">
                            <dx:ASPxLabel ID="ASPxLabel27" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Conversions to" Theme="Glass">
                            </dx:ASPxLabel>
                        </td>
                        <td colspan="1">
                            <dx:ASPxDateEdit ID="cmbto" runat="server" Width="250px">
                            </dx:ASPxDateEdit>
                        </td>
                        <td colspan="1">&nbsp;</td>
                        <td colspan="1">&nbsp;</td>
                        <td colspan="1">&nbsp;</td>
                        <td colspan="1"></td>
                        <td colspan="1"></td>
                    </tr>
                    <tr>
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
                        <td colspan ="1"></td>
                        <td colspan ="1"></td>


                    </tr>
                    <tr>
                        <td colspan="1">&nbsp;</td>
                        <td colspan="1">
                            <dx:ASPxButton ID="ASPxButton7" runat="server" Text="View Conversions" Theme="BlackGlass">
                            </dx:ASPxButton>
                            &nbsp;</td>
                        <td colspan="1">&nbsp;</td>
                        <td colspan="1">&nbsp;</td>
                        <td colspan="1">&nbsp;</td>
                        <td colspan="1">&nbsp;</td>
                        <td colspan="1">&nbsp;</td>
                        <td colspan="1">&nbsp;</td>
                    </tr>
                    <tr>
                        <td colspan="1">&nbsp;</td>
                        <td colspan="1">&nbsp;</td>
                        <td colspan="1">&nbsp;</td>
                        <td colspan="1">&nbsp;</td>
                        <td colspan="1">&nbsp;</td>
                        <td colspan="1">&nbsp;</td>
                        <td colspan="1">&nbsp;</td>
                        <td colspan="1">&nbsp;</td>
                    </tr>
                    <tr>
                            <td colspan ="1" style="height: 18px">
                            </td>
                        <td colspan ="7" style="height: 18px">
                            <asp:GridView ID="Gridview1" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" CssClass="tablestyle" DataKeyNames="ID" Font-Size="Small" Style="position: relative; top: 0px; left: 0px; width: 99%;">
                                <PagerSettings FirstPageText="First" LastPageText="Last" NextPageText="Next" PreviousPageText="Previous" />
                                <AlternatingRowStyle CssClass="altrowstyle" />
                                <FooterStyle BackColor="White" ForeColor="#000066" />
                                <HeaderStyle BackColor="#006699" CssClass="headerstyle" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                                <RowStyle CssClass="rowstyle" ForeColor="#000066" />
                                <Columns>
                                    <%--<asp:BoundField DataField="id" HeaderText="ID" />--%>
									<asp:BoundField DataField="cds number" HeaderText="Name" />
                                    <asp:BoundField DataField="cds_number" HeaderText="cdsnumber" />
                                    <asp:BoundField DataField="transtype" HeaderText="transtype" />
                                    <asp:BoundField DataField="Amount" HeaderText="Amount Withdrawn">
                                    <ItemStyle HorizontalAlign="Right" />
                                    </asp:BoundField>
                                    <asp:CommandField SelectText="Convert" ShowSelectButton="true" />
                                </Columns>
                                <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                <SortedAscendingHeaderStyle BackColor="#007DBB" />
                                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                <SortedDescendingHeaderStyle BackColor="#00547E" />
                            </asp:GridView>
                            </td>
                        


                    </tr>
                    <tr>
                        <td colspan ="1"></td>
                        <td colspan ="7" align="center">
                            <dx:ASPxPopupControl ID="ASPxPopupControl1" runat="server" HeaderText="Convert" Theme="Moderno" Width="550px">
                                <HeaderStyle Font-Bold="True" />
                                <contentcollection>
                                    <dx:PopupControlContentControl runat="server" SupportsDisabledAttribute="True">
                                        <table class="dxflInternalEditorTable_Moderno" style="width: 122%">
                                            <tr>
                                                <td style="width: 162px; height: 43px;">
                                                    <dx:ASPxLabel ID="ASPxLabel28" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Ctrade No" Theme="iOS">
                                                    </dx:ASPxLabel>
                                                </td>
                                                <td style="height: 43px">
                                                    <dx:ASPxTextBox ID="txtctradeno" runat="server" Theme="iOS" Width="75%">
                                                    </dx:ASPxTextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 162px; height: 43px;">
                                                    <dx:ASPxLabel ID="ASPxLabel7" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Amount" Theme="iOS">
                                                    </dx:ASPxLabel>
                                                </td>
                                                <td style="height: 43px">
                                                    <dx:ASPxTextBox ID="txtamount" runat="server" Theme="iOS" Width="75%">
                                                    </dx:ASPxTextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 162px">&#160;</td>
                                                <td>
                                                    <dx:ASPxButton ID="ASPxButton4" runat="server" Text="Convert" Theme="iOS" Width="144px">
                                                    </dx:ASPxButton>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 162px">&#160;</td>
                                                <td>
                                                    &#160;</td>
                                            </tr>
                                        </table>
                                    </dx:PopupControlContentControl>
                                </contentcollection>
                            </dx:ASPxPopupControl>
                        </td>

                    </tr>
                    <tr>
                        <td colspan="1">
                            &nbsp;</td>
                        <td colspan ="7">
                            &nbsp;</td>

                    </tr>
                 
        </table>
        </asp:Panel>
                       
</asp:Panel>
  
</div>
</asp:Content>

