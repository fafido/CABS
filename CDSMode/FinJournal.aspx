<%@ Page Title="" Language="VB" MasterPageFile="~/CDSUser.master" AutoEventWireup="false" CodeFile="FinJournal.aspx.vb" Inherits="Parameters_Default" %><%@ Register assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dx" %>
<%@ Register assembly="BasicFrame.WebControls.BasicDatePicker" namespace="BasicFrame.WebControls" tagprefix="BDP" %>
<%@ Register assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxPanel" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxTabControl" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxClasses" tagprefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <dx:ASPxPageControl ID="ASPxPageControl1" runat="server" ActiveTabIndex="1" Font-Bold="False" ForeColor="Black">
    <TabPages>
        <dx:TabPage Text="Add Transaction">
            <ContentCollection>
                <dx:ContentControl runat="server" SupportsDisabledAttribute="True">
                    <table style="width: 100%">
                        <tr>
                            <td style="width: 144px">
                                &nbsp;</td>
                            <td style="width: 39px">
                                &nbsp;</td>
                            <td style="width: 203px">
                                &nbsp;</td>
                            <td style="width: 465px">&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width: 144px">
                                <dx:ASPxLabel ID="ASPxLabel11" runat="server" style="font-weight: 700" Text="Transaction Details">
                                </dx:ASPxLabel>
                            </td>
                            <td style="width: 39px">&nbsp;</td>
                            <td style="width: 203px">
                                <dx:ASPxLabel ID="ASPxLabel12" runat="server" style="font-weight: 700" Text="Transaction Values">
                                </dx:ASPxLabel>
                            </td>
                            <td style="width: 465px">&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width: 144px">
                                <dx:ASPxLabel ID="ASPxLabel1" runat="server" Text="Transaction Reference">
                                </dx:ASPxLabel>
                            </td>
                            <td style="width: 39px">&nbsp;</td>
                            <td style="width: 203px">
                                <dx:ASPxTextBox ID="txtTransRef" runat="server" Width="170px">
                                </dx:ASPxTextBox>
                            </td>
                            <td style="width: 465px">&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width: 144px">
                                <dx:ASPxLabel ID="ASPxLabel2" runat="server" Text="Transaction Narration">
                                </dx:ASPxLabel>
                            </td>
                            <td style="width: 39px">&nbsp;</td>
                            <td style="width: 203px">
                                <dx:ASPxTextBox ID="txtTranDesc" runat="server" Width="170px">
                                </dx:ASPxTextBox>
                            </td>
                            <td style="width: 465px">&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width: 144px; height: 26px">
                                <dx:ASPxLabel ID="ASPxLabel3" runat="server" Text="Value Date">
                                </dx:ASPxLabel>
                            </td>
                            <td style="width: 39px; height: 26px"></td>
                            <td style="height: 26px; width: 203px">
                                <dx:ASPxTextBox ID="txtdate" runat="server" Width="170px">
                                </dx:ASPxTextBox>
                            </td>
                            <td style="height: 26px; width: 465px">&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width: 144px">
                                <dx:ASPxLabel ID="ASPxLabel4" runat="server" Text="Debit Account">
                                </dx:ASPxLabel>
                            </td>
                            <td style="width: 39px">&nbsp;</td>
                            <td style="width: 203px">
                                <dx:ASPxTextBox ID="txtDebitAcc" runat="server" Width="170px">
                                </dx:ASPxTextBox>
                            </td>
                            <td style="width: 465px">&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width: 144px; height: 18px">
                                <dx:ASPxLabel ID="ASPxLabel5" runat="server" Text="Credit Account">
                                </dx:ASPxLabel>
                            </td>
                            <td style="height: 18px; width: 39px"></td>
                            <td style="height: 18px; width: 203px">
                                <dx:ASPxTextBox ID="txtCreditAcc" runat="server" Width="170px">
                                </dx:ASPxTextBox>
                            </td>
                            <td style="height: 18px; width: 465px">&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width: 144px">
                                <dx:ASPxLabel ID="ASPxLabel6" runat="server" Text="Currency">
                                </dx:ASPxLabel>
                            </td>
                            <td style="width: 39px">&nbsp;</td>
                            <td style="width: 203px">
                                <asp:DropDownList ID="ddCurrency" runat="server" Height="16px" Width="152px">
                                </asp:DropDownList>
                            </td>
                            <td style="width: 465px">&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width: 144px; height: 23px;">
                                <dx:ASPxLabel ID="ASPxLabel7" runat="server" Text="Amount">
                                </dx:ASPxLabel>
                            </td>
                            <td style="width: 39px; height: 23px;"></td>
                            <td style="width: 203px; height: 23px;">
                                <dx:ASPxTextBox ID="txtAmount" runat="server" Width="170px">
                                </dx:ASPxTextBox>
                            </td>
                            <td style="width: 465px; height: 23px;"></td>
                        </tr>
                        <tr>
                            <td style="width: 144px">
                                <dx:ASPxLabel ID="ASPxLabel10" runat="server" Text="Con. Rate">
                                </dx:ASPxLabel>
                            </td>
                            <td style="width: 39px">&nbsp;</td>
                            <td style="width: 203px">
                                <dx:ASPxTextBox ID="txtConRate" runat="server" Enabled="False" Width="170px">
                                </dx:ASPxTextBox>
                            </td>
                            <td style="width: 465px">&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width: 144px">
                                <dx:ASPxLabel ID="ASPxLabel8" runat="server" Text="Base Amount">
                                </dx:ASPxLabel>
                            </td>
                            <td style="width: 39px">&nbsp;</td>
                            <td style="width: 203px">
                                <dx:ASPxTextBox ID="txtBaseAmount" runat="server" Enabled="False" Width="170px">
                                </dx:ASPxTextBox>
                            </td>
                            <td style="width: 465px">&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width: 144px">&nbsp;</td>
                            <td style="width: 39px">&nbsp;</td>
                            <td style="width: 203px">
                                <dx:ASPxButton ID="ASPxButton1" runat="server" Height="21px" Text="Add to Batch" Width="168px">
                                </dx:ASPxButton>
                            </td>
                            <td style="width: 465px">&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width: 144px">&nbsp;</td>
                            <td style="width: 39px">&nbsp;</td>
                            <td style="width: 203px">&nbsp;</td>
                            <td style="width: 465px">&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width: 144px">&nbsp;</td>
                            <td style="width: 39px">&nbsp;</td>
                            <td style="width: 203px">&nbsp;</td>
                            <td style="width: 465px">&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width: 144px">&nbsp;</td>
                            <td style="width: 39px">&nbsp;</td>
                            <td style="width: 203px">&nbsp;</td>
                            <td style="width: 465px">&nbsp;</td>
                        </tr>
                    </table>
                </dx:ContentControl>
            </ContentCollection>
        </dx:TabPage>
        <dx:TabPage Text="Post Batch">
            <ContentCollection>
                <dx:ContentControl runat="server" SupportsDisabledAttribute="True">
                    <table class="dxflInternalEditorTable">
                        <tr>
                            <td>
                                <asp:GridView ID="grdvFinBatch" runat="server">
                                </asp:GridView>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <dx:ASPxButton ID="ASPxButton2" runat="server" Text="Post Batch">
                                </dx:ASPxButton>
                            </td>
                        </tr>
                    </table>
                </dx:ContentControl>
            </ContentCollection>
        </dx:TabPage>
    </TabPages>
    <ActiveTabStyle Font-Bold="True" ForeColor="#003366">
    </ActiveTabStyle>
</dx:ASPxPageControl>
</asp:Content>

