<%@ Page Language="VB" MasterPageFile="~/CDSUser.master" AutoEventWireup="false" CodeFile="redemptioninstr.aspx.vb" Inherits="Parameters_redemptioninstr" title="Redemption Instructions" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<asp:Content id="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
    <asp:Panel id="Panel1" runat="server" Width="840px" Font-Names="Arial" Font-Size="Medium" BackColor="White">
    
        <table width ="810px">
            <tr>
                   <td style ="text-align :left;" align="left">
                       <dx:ASPxLabel ID="ASPxLabel1" runat="server" Text="Parameters&gt;Redemption Instructions" Font-Names="Cambria" Font-Size="Small" Theme="PlasticBlue"></dx:ASPxLabel>

                   </td>
            </tr>
        </table>
        <asp:Panel ID="Panel5" runat="server" Font-Names="Cambria" GroupingText="Capital Redemption Instructions">
            <table width="810px">
                <tr>
                    <td align="center" colspan="8">&nbsp;</td>
                </tr>
                <tr>
                    <td colspan="1">
                        <dx:ASPxLabel ID="ASPxLabel23" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Security" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td colspan="1">
                        <dx:ASPxComboBox ID="cmbsecurity" runat="server" AutoPostBack="True" ValueType="System.String" Width="250px">
                        </dx:ASPxComboBox>
                    </td>
                    <td colspan="1">
                        <dx:ASPxDateEdit ID="cmbdatedeclared" runat="server" Visible="False" Width="250px">
                        </dx:ASPxDateEdit>
                    </td>
                    <td colspan="1">&nbsp;</td>
                    <td colspan="1">&nbsp;</td>
                    <td colspan="1">&nbsp;</td>
                    <td colspan="1">&nbsp;</td>
                </tr>
                <tr>
                    <td colspan="1">
                        <dx:ASPxLabel ID="ASPxLabel27" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Payment No" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td colspan="1">
                        <dx:ASPxTextBox ID="txtpaymentNo" runat="server" style="margin-top: 0px" Theme="Glass" Width="250px">
                        </dx:ASPxTextBox>
                    </td>
                    <td colspan="1">
                        <dx:ASPxDateEdit ID="cmbdateclosed" runat="server" Visible="False" Width="250px">
                        </dx:ASPxDateEdit>
                    </td>
                    <td colspan="1">&nbsp;</td>
                    <td colspan="1">&nbsp;</td>
                    <td colspan="1">&nbsp;</td>
                    <td colspan="1">&nbsp;</td>
                </tr>
                <tr>
                    <td colspan="1">
                        <dx:ASPxLabel ID="ASPxLabel26" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Payment Date" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td colspan="1">
                        <dx:ASPxDateEdit ID="cmbpaymentsdate" runat="server" Width="250px">
                        </dx:ASPxDateEdit>
                    </td>
                    <td colspan="1">
                        <dx:ASPxTextBox ID="txtinterest" runat="server" style="margin-top: 0px" Theme="Glass" Visible="False" Width="250px">
                        </dx:ASPxTextBox>
                    </td>
                    <td colspan="1">&nbsp;</td>
                    <td colspan="1">&nbsp;</td>
                    <td colspan="1">&nbsp;</td>
                    <td colspan="1">&nbsp;</td>
                </tr>
                <tr>
                    <td colspan="1">
                        <dx:ASPxLabel ID="ASPxLabel22" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Description" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td colspan="1">
                        <dx:ASPxTextBox ID="txtDesc" runat="server" style="margin-top: 0px" Theme="Glass" Width="250px">
                        </dx:ASPxTextBox>
                    </td>
                    <td colspan="1"></td>
                    <td colspan="1"></td>
                    <td colspan="1"></td>
                    <td colspan="1"></td>
                    <td colspan="1"></td>
                </tr>
                <tr>
                    <td colspan="1">&nbsp;</td>
                    <td colspan="1">&nbsp;</td>
                    <td colspan="1">&nbsp;</td>
                    <td colspan="1">&nbsp;</td>
                    <td colspan="1"></td>
                    <td colspan="1"></td>
                    <td colspan="1"></td>
                    <td colspan="1"></td>
                </tr>
                <tr>
                    <td colspan="1">&nbsp;</td>
                    <td colspan="1">
                        <dx:ASPxButton ID="ASPxButton7" runat="server" Text="Create Instruction" Theme="BlackGlass">
                        </dx:ASPxButton>
                    </td>
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
                    <td colspan="1" style="height: 18px"></td>
                    <td colspan="7" style="height: 18px">
                        <dx:ASPxGridView ID="ASPxGridView2" runat="server" Theme="Glass" Width="640px">
                            <SettingsPager Visible="True">
                            </SettingsPager>
                        </dx:ASPxGridView>
                    </td>
                </tr>
                <tr>
                    <td colspan="1"></td>
                    <td align="center" colspan="7">&nbsp;</td>
                </tr>
                <tr>
                    <td colspan="1">&nbsp;</td>
                    <td colspan="7">&nbsp;</td>
                </tr>
            </table>
        </asp:Panel>
                       
</asp:Panel>
  
</div>
</asp:Content>

