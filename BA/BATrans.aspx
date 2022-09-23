<%@ Page Title="" Language="VB" MasterPageFile="~/CDSUser.master" AutoEventWireup="false" CodeFile="BATrans.aspx.vb" Inherits="BA_Payments" %>

<%@ Register assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxPanel" tagprefix="dx" %>

<%@ Register assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxTabControl" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxClasses" tagprefix="dx" %>
<%@ Register assembly="BasicFrame.WebControls.BasicDatePicker" namespace="BasicFrame.WebControls" tagprefix="BDP" %>
<%@ Register assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxGridView" tagprefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Panel ID="Panel1" runat="server" Height="420px" Width="840px">
        <dx:ASPxPageControl ID="ASPxPageControl1" runat="server" ActiveTabIndex="0" EnableTheming="True" Theme="MetropolisBlue">
            <TabPages>
                <dx:TabPage Name="STD" Text="Standard Transactions">
                    <ContentCollection>
                        <dx:ContentControl runat="server" SupportsDisabledAttribute="True">
                            <asp:Panel ID="Panel2" runat="server" GroupingText="Transaction Details">
                                <table style="width:97%;">
                                    <tr>
                                        <td style="height: 4px; width: 219px;">
                                            <asp:Label ID="Label2" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Transaction Type"></asp:Label>
                                        </td>
                                        <td class="dxflEmptyItem_Moderno" style="height: 4px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;</td>
                                        <td class="dxflEmptyItem_Moderno" style="height: 4px">
                                            <asp:DropDownList ID="ddlTransType" runat="server" BackColor="#E4E4E4" Height="23px" Width="250px">
                                            </asp:DropDownList>
                                        </td>
                                        <td class="dxflEmptyItem_Moderno" style="height: 4px"></td>
                                    </tr>
                                    <tr>
                                        <td style="height: 31px; width: 219px;">
                                            <asp:Label ID="Label3" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Value Date"></asp:Label>
                                        </td>
                                        <td style="height: 31px"></td>
                                        <td style="height: 31px">
                                            <dx:ASPxDateEdit ID="dtpValueDate" runat="server" BackColor="#E4E4E4" Height="16px" Width="250px">
                                            </dx:ASPxDateEdit>
                                        </td>
                                        <td style="height: 31px">&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td style="height: 25px; width: 219px;">
                                            <asp:Label ID="Label4" runat="server" Font-Names="Cambria" Font-Size="Small" Text="BA Number"></asp:Label>
                                        </td>
                                        <td style="height: 25px"></td>
                                        <td style="height: 25px">
                                            <dx:ASPxTextBox ID="txtBANum" runat="server" BackColor="#E4E4E4" Height="16px" Width="250px">
                                            </dx:ASPxTextBox>
                                        </td>
                                        <td style="height: 25px">&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td style="height: 25px; width: 219px;">&nbsp;</td>
                                        <td style="height: 25px">&nbsp;</td>
                                        <td style="height: 25px">
                                            <dx:ASPxButton ID="btnSearchBA" runat="server" Font-Size="Smaller" Height="16px" Text="..." Width="29px">
                                            </dx:ASPxButton>
                                        </td>
                                        <td style="height: 25px">&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td class="dxflEmptyItem_Moderno" style="height: 19px; width: 219px;">&nbsp;</td>
                                        <td class="dxflEmptyItem_Moderno" style="height: 19px"></td>
                                        <td class="dxflEmptyItem_Moderno" style="height: 19px">
                                            <asp:GridView ID="dtlBAs" runat="server" AutoGenerateSelectButton="True" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" Height="125px" Width="250px">
                                                <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                                                <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
                                                <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
                                                <RowStyle BackColor="White" ForeColor="#003399" />
                                                <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                                                <SortedAscendingCellStyle BackColor="#EDF6F6" />
                                                <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
                                                <SortedDescendingCellStyle BackColor="#D6DFDF" />
                                                <SortedDescendingHeaderStyle BackColor="#002876" />
                                            </asp:GridView>
                                            </td>
                                        <td class="dxflEmptyItem_Moderno" style="height: 19px">&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td style="height: 22px; width: 219px;">
                                            <asp:Label ID="Label5" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Participant"></asp:Label>
                                        </td>
                                        <td style="height: 22px"></td>
                                        <td style="height: 22px">
                                            <asp:Label ID="lblParticipant" runat="server" Text="Participant" Font-Bold="True" ForeColor="Black"></asp:Label>
                                        </td>
                                        <td style="height: 22px">&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td style="width: 219px">
                                            <asp:Label ID="Label7" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Reference Number"></asp:Label>
                                        </td>
                                        <td>&nbsp;</td>
                                        <td>
                                            <dx:ASPxTextBox ID="txtRef" runat="server" BackColor="#E4E4E4" Height="19px" Width="250px">
                                            </dx:ASPxTextBox>
                                        </td>
                                        <td>&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td style="width: 219px">&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td style="width: 219px">&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>
                                            <asp:Button ID="btnPost" runat="server" Text="Post" Width="75px" />
                                        </td>
                                        <td>&nbsp;</td>
                                    </tr>
                                </table>
                            </asp:Panel>
                        </dx:ContentControl>
                    </ContentCollection>
                </dx:TabPage>
                <dx:TabPage Name="Rec" Text="Split Transactions">
                    <ContentCollection>
                        <dx:ContentControl runat="server" SupportsDisabledAttribute="True">
                        </dx:ContentControl>
                    </ContentCollection>
                </dx:TabPage>
                <dx:TabPage Name="Swift" Text="Swift Payments">
                    <ContentCollection>
                        <dx:ContentControl runat="server" SupportsDisabledAttribute="True">
                        </dx:ContentControl>
                    </ContentCollection>
                </dx:TabPage>
            </TabPages>
            <TabStyle>
                <Border BorderStyle="None" />
                <BorderLeft BorderStyle="None" />
                <BorderTop BorderStyle="None" />
                <BorderRight BorderStyle="None" />
                <BorderBottom BorderStyle="None" />
            </TabStyle>
            <Border BorderStyle="None" />
            <BorderLeft BorderStyle="None" />
            <BorderTop BorderStyle="None" />
            <BorderRight BorderStyle="None" />
            <BorderBottom BorderStyle="None" />
        </dx:ASPxPageControl>
        <br />
        
    </asp:Panel>
</asp:Content>

