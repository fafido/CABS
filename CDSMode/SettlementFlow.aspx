<%@ Page Title="" Language="VB" MasterPageFile="~/CDSUser.master" AutoEventWireup="false" CodeFile="SettlementFlow.aspx.vb" Inherits="_Default" %><%@ Register assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dx" %>

<%@ Register assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxTabControl" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxClasses" tagprefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width: 78%; height: 288px;">
    <tr>
        <td class="dxeButtonEditSys" style="width: 163px">
            <dx:ASPxPageControl ID="ASPxPageControl1" runat="server" ActiveTabIndex="0" EnableTabScrolling="True" Theme="BlackGlass">
                <TabPages>
                    <dx:TabPage Text="New and Pending Orders">
                        <ActiveTabStyle Font-Bold="True" ForeColor="#003366">
                        </ActiveTabStyle>
                        <ContentCollection>
                            <dx:ContentControl runat="server" SupportsDisabledAttribute="True">
                                <asp:GridView ID="grdvOrdersSummary" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" ShowFooter="True">
                                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                    <EditRowStyle BackColor="#999999" />
                                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                    <SortedAscendingCellStyle BackColor="#E9E7E2" />
                                    <SortedAscendingHeaderStyle BackColor="#506C8C" />
                                    <SortedDescendingCellStyle BackColor="#FFFDF8" />
                                    <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                                </asp:GridView>
                            </dx:ContentControl>
                        </ContentCollection>
                    </dx:TabPage>
                    <dx:TabPage Text="Settlement Pool">
                        <ActiveTabStyle Font-Bold="True" ForeColor="#003366">
                        </ActiveTabStyle>
                        <ContentCollection>
                            <dx:ContentControl runat="server" SupportsDisabledAttribute="True">
                                <asp:GridView ID="grdvBankOutbox" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" ShowFooter="True">
                                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                    <EditRowStyle BackColor="#999999" />
                                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                    <SortedAscendingCellStyle BackColor="#E9E7E2" />
                                    <SortedAscendingHeaderStyle BackColor="#506C8C" />
                                    <SortedDescendingCellStyle BackColor="#FFFDF8" />
                                    <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                                </asp:GridView>
                            </dx:ContentControl>
                        </ContentCollection>
                    </dx:TabPage>
                    <dx:TabPage Text="Raw Time Stamps">
                        <ActiveTabStyle Font-Bold="True" ForeColor="#003366">
                        </ActiveTabStyle>
                        <ContentCollection>
                            <dx:ContentControl runat="server" SupportsDisabledAttribute="True">
                                <asp:GridView ID="grdvBankResponses" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" ShowFooter="True" ShowHeaderWhenEmpty="True">
                                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                    <EditRowStyle BackColor="#999999" />
                                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                    <SortedAscendingCellStyle BackColor="#E9E7E2" />
                                    <SortedAscendingHeaderStyle BackColor="#506C8C" />
                                    <SortedDescendingCellStyle BackColor="#FFFDF8" />
                                    <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                                </asp:GridView>
                            </dx:ContentControl>
                        </ContentCollection>
                    </dx:TabPage>
                </TabPages>
                <ActiveTabStyle Font-Bold="True" ForeColor="#000099">
                    <HoverStyle BackColor="#999999">
                    </HoverStyle>
                    <Border BorderStyle="Solid" />
                    <BorderBottom BorderStyle="Solid" />
                </ActiveTabStyle>
            </dx:ASPxPageControl>
        </td>
        <td style="width: 14px">&nbsp;</td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td class="dxeButtonEditSys" style="width: 163px">
            &nbsp;</td>
        <td style="width: 14px">&nbsp;</td>
        <td style="width: 233px">
            &nbsp;</td>
    </tr>
    <tr>
        <td class="dxeButtonEditSys" style="width: 163px">&nbsp;</td>
        <td style="width: 14px">&nbsp;</td>
        <td style="width: 233px">
            &nbsp;</td>
    </tr>
    <tr>
        <td class="dxeButtonEditSys" style="width: 163px">&nbsp;</td>
        <td style="width: 14px">&nbsp;</td>
        <td style="width: 233px">&nbsp;</td>
    </tr>
    <tr>
        <td class="dxeButtonEditSys" style="width: 163px; height: 46px;"></td>
        <td style="width: 14px; height: 46px;"></td>
        <td style="height: 46px; width: 233px;"></td>
    </tr>
</table>
</asp:Content>

