<%@ Page Language="VB" MasterPageFile="~/CDSUser.master" AutoEventWireup="false" CodeFile="frmBranch.aspx.vb" Inherits="Parameters_frmBranch" title="Untitled Page" %>

<%@ Register assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxGridView" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dx" %>

<asp:Content id="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <dx:ASPxLabel ID="ASPxLabel1" runat="server" Text="Parameters&gt; Branches" Font-Names="Cambria" Font-Size="Small" Theme="PlasticBlue"></dx:ASPxLabel>
   <asp:Panel runat="server" ID="pan" GroupingText="Branches">    <table style="width: 100%; " 
            >
        <tr align="left">
            <td style="width: 100%; height: 226px" valign="top">
                <table>
                    <tr>
                        <td style="width: 870px" align="left">
                            &nbsp;</td>
                    </tr>
                </table>
                <table style="width: 100%">
                    <tr>
                        <td align="left" style="width: 91px" class="dxeButtonEditSys">
                            <asp:Label id="Label12" runat="server" Text="Bank " font-names="Arial" 
                            font-size="Small"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList id="cmbBank" runat="server" Height="20px" width="173px" AutoPostBack="True">
                            </asp:DropDownList>
                            <asp:TextBox id="txtBankCode" runat="server" Visible="False"></asp:TextBox>
                        </td>
                        <td>
                            <asp:Label id="Label2" runat="server" Text="Branch Code" font-names="Arial" 
                            font-size="Small"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox id="txtbcode" runat="server" Width="173px"></asp:TextBox>
                        </td>
                        <td>
                            <asp:Label id="Label11" runat="server" Text="Branch Name" font-names="Arial" 
                            font-size="Small"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox id="txtName" runat="server" Width="173px"></asp:TextBox>
                        </td>
                        <td>
                            <asp:Button id="btnSave" runat="server" Text="Save" width="64px" 
                                style="height: 26px; text-align: center" />
                        </td>
                    </tr>
                    <tr>
                        <td align="left" colspan="7" style="height: 28px">
                            <asp:Label ID="lblid" runat="server" font-names="Arial" font-size="Small" Visible="False"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" style="width: 91px" class="dxeButtonEditSys">
                            &nbsp;</td>
                        <td style="text-align: left" colspan="5">
                            <dx:ASPxGridView ID="ASPxGridView2" runat="server" SettingsPager-Mode="ShowAllRecords" Theme="Glass" Width="640px" KeyFieldName="id">
                                <Columns>
                                    <dx:GridViewDataColumn Caption="" VisibleIndex="0">
                                        <DataItemTemplate>
                                            <asp:LinkButton ID="SelectID" runat="server" CommandArgument='<%# Eval("ID") %>' CommandName="Edit" Text="Edit">
                                                              </asp:LinkButton>
                                        </DataItemTemplate>
                                    </dx:GridViewDataColumn>
                                    <dx:GridViewDataColumn Caption="" VisibleIndex="0">
                                        <DataItemTemplate>
                                            <asp:LinkButton ID="DeleteID" runat="server" CommandArgument='<%# Eval("ID") %>' CommandName="Delete" OnClientClick="if ( !confirm('Are you sure you want to delete ? ')) return false;" Text="Delete">
                                                              </asp:LinkButton>
                                        </DataItemTemplate>
                                    </dx:GridViewDataColumn>
                                    <dx:GridViewDataColumn Caption="Branch Code">
                                        <DataItemTemplate>
                                            <dx:ASPxLabel runat="server" Text='<%# Eval("Branch Code") %>'>
                                            </dx:ASPxLabel>
                                        </DataItemTemplate>
                                    </dx:GridViewDataColumn>
                                    <dx:GridViewDataColumn Caption="Branch Name">
                                        <DataItemTemplate>
                                            <dx:ASPxLabel runat="server" Text='<%# Eval("Branch_Name") %>'>
                                            </dx:ASPxLabel>
                                        </DataItemTemplate>
                                    </dx:GridViewDataColumn>
                                 
                                </Columns>
                            </dx:ASPxGridView>
                        </td>
                        <td style="text-align: left">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td align="left" style="width: 91px" class="dxeButtonEditSys">
                            &nbsp;</td>
                        <td style="text-align: left">
                            <asp:TextBox id="txtCode" runat="server" Visible="False">1</asp:TextBox>
                        </td>
                        <td style="text-align: left">
                            &nbsp;</td>
                        <td style="text-align: left">
                            &nbsp;</td>
                        <td style="text-align: left">
                            &nbsp;</td>
                        <td style="text-align: left">
                            &nbsp;</td>
                        <td style="text-align: left">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td align="left" colspan="2" style="text-align: center">
                            &nbsp;</td>
                        <td align="left" style="text-align: center">
                            &nbsp;</td>
                        <td align="left" style="text-align: center">
                            &nbsp;</td>
                        <td align="left" style="text-align: center">
                            &nbsp;</td>
                        <td align="left" style="text-align: center">
                            &nbsp;</td>
                        <td align="left" style="text-align: center">
                            &nbsp;</td>
                    </tr>
                </table>
                <table>
                    <tr>
                        <td colspan ="1" style="width: 147px">
                        </td>
                        <td>
                            &nbsp;</td>
                        <td colspan ="1" style="width: 424px">
                        </td>
                    </tr>
                </table>
                <table>
                    <tr>
                        <td style="width: 850px" align="center">
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
       </asp:Panel>
 
</asp:Content>

