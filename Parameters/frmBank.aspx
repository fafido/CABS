<%@ Page Language="VB" MasterPageFile="~/CDSUser.master" AutoEventWireup="false" CodeFile="frmBank.aspx.vb" Inherits="Parameters_frmBank" title="Banks" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>

<asp:Content id="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <dx:ASPxLabel ID="ASPxLabel1" runat="server" Text="Parameters&gt;Commodity Grades" Font-Names="Cambria" Font-Size="Small" Theme="PlasticBlue"></dx:ASPxLabel>
    <asp:Panel runat="server" ID="pan" GroupingText="Banks">
    <table style ="width: 100%;>
        <tr align="center" >
        </tr>
            <tr>
                <td style="width: 100%; height: 226px" valign="top">
                    <table style="width: 1418px">
                        <tr>
                            <td align="left" style="width: 161px; height: 74px;">
                                <asp:Label ID="Label1" runat="server" font-names="Arial" font-size="Small" Text="Bank Code"></asp:Label>
                            </td>
                            <td style="height: 74px">
                                <asp:TextBox ID="txtCode" runat="server"></asp:TextBox>
                            </td>
                            <td style="height: 74px">
                                <asp:Label ID="Label2" runat="server" font-names="Arial" font-size="Small" Text="Short Name"></asp:Label>
                            </td>
                            <td style="height: 74px">
                                <asp:TextBox ID="txtshortname" runat="server"></asp:TextBox>
                            </td>
                            <td style="height: 74px">
                                <asp:Label ID="Label11" runat="server" font-names="Arial" font-size="Small" Text="Bank Full Name"></asp:Label>
                            </td>
                            <td style="height: 74px">
                                <asp:TextBox ID="txtName" runat="server" Width="275px"></asp:TextBox>
                            </td>
                            <td style="height: 74px">
                                <asp:Button ID="btnSave" runat="server" Height="31px" style="text-align: center" Text="Add" width="129px" />
                            </td>
                        </tr>
                        <tr>
                            <td align="left" colspan="7" style="height: 134px">
                                <asp:Button ID="btnDelete" runat="server" Height="31px" style="text-align: center" Text="Delete" Visible="False" width="67px" />
                                <asp:Button ID="btnClear" runat="server" Height="31px" style="text-align: center" Text="Clear" Visible="False" width="67px" />
                                <br />
                                <br />
                                <asp:GridView ID="GridView1" runat="server" AutoGenerateSelectButton="True" CellPadding="4" ForeColor="#333333" Width="827px" Font-Size="Small">
                                    <AlternatingRowStyle BackColor="White" />
                                    <EditRowStyle BackColor="#2461BF" />
                                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                    <HeaderStyle CssClass="headerstyle" BackColor="#B7D8DC" ForeColor="Black" HorizontalAlign="left" />
                                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                    <RowStyle BackColor="white" />
                                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                    <SortedAscendingCellStyle BackColor="#F5F7FB" />
                                    <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                                    <SortedDescendingCellStyle BackColor="#E9EBEF" />
                                    <SortedDescendingHeaderStyle BackColor="#4870BE" />
                                </asp:GridView>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" class="dxeButtonEditSys" style="width: 161px">&nbsp;</td>
                            <td style="text-align: left">&nbsp;</td>
                            <td style="text-align: left">&nbsp;</td>
                            <td style="text-align: left">&nbsp;</td>
                            <td style="text-align: left">&nbsp;</td>
                            <td style="text-align: left">&nbsp;</td>
                            <td style="text-align: left">&nbsp;</td>
                        </tr>
                        <tr>
                            <td align="left" class="dxeButtonEditSys" style="width: 161px">&nbsp;</td>
                            <td style="text-align: left">&nbsp;</td>
                            <td style="text-align: left">&nbsp;</td>
                            <td style="text-align: left">&nbsp;</td>
                            <td style="text-align: left">&nbsp;</td>
                            <td style="text-align: left">&nbsp;</td>
                            <td style="text-align: left">&nbsp;</td>
                        </tr>
                        <tr>
                            <td align="left" colspan="2" style="text-align: center">&nbsp;</td>
                            <td align="left" style="text-align: center">&nbsp;</td>
                            <td align="left" style="text-align: center">&nbsp;</td>
                            <td align="left" style="text-align: center">&nbsp;</td>
                            <td align="left" style="text-align: center">&nbsp;</td>
                            <td align="left" style="text-align: center">&nbsp;</td>
                        </tr>
                    </table>
                    <table>
                        <tr>
                            <td colspan="1" style="width: 147px"></td>
                            <td>&nbsp;</td>
                            <td colspan="1" style="width: 424px"></td>
                        </tr>
                    </table>
                    <table>
                        <tr>
                            <td align="center" style="width: 850px"></td>
                        </tr>
                    </table>
                </td>
        </tr>
    </table>
        </asp:Panel>
</asp:Content>

