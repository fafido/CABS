<%@ Page Language="VB" MasterPageFile="~/CDSUser.master" AutoEventWireup="false" CodeFile="AccountsList.aspx.vb" Inherits="TransferSec_AccountsPendingAuthList" title="Accounts Pending Authorization" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>

<%@ Register assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxRoundPanel" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxPanel" tagprefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<%@ Register assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxUploadControl" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxLoadingPanel" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxPopupControl" tagprefix="dx" %>
<asp:Content id="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Panel id="Panel1" runat="server" Width="100%" Font-Names="Cambria" BackColor="White" GroupingText="Accounts Pending Authorization">
       <table>
            <tr>
              <td colspan="4" style="height: 18px;">
                    <dx:ASPxLabel ID="ASPxLabel25" runat="server" Font-Names="Cambria" Font-Size="Small" Font-Bold="true" Text="" Theme="Glass">
                    </dx:ASPxLabel>
                    <hr/>
                </td>
              </tr>
            <tr id="wippp" runat="server" >
                <td style="height: 18px;"></td>
                <td colspan="3" style="height: 18px">
                    <dx:ASPxGridView ID="grdWIP" runat="server" AutoGenerateColumns="true" KeyFieldName="ID" Theme="Glass">
                        <SettingsPager Visible="False">
                        </SettingsPager>
                        <Columns >
                            <dx:GridViewDataColumn VisibleIndex="0">
                                    <DataItemTemplate>
                                        <asp:LinkButton ID="SelectID" Text="Edit" CommandName="Select" CommandArgument='<%# Eval("ID") %>' runat="server">
                                        </asp:LinkButton>
                                    </DataItemTemplate>
                            </dx:GridViewDataColumn>
                            <dx:GridViewDataColumn HeaderStyle-Font-Bold="true" Caption="Account Type">
                                    <DataItemTemplate>
                                        <dx:ASPxLabel Text='<%# Eval("AccType") %>' runat="server"></dx:ASPxLabel>
                                    </DataItemTemplate>
                            </dx:GridViewDataColumn>
                            <dx:GridViewDataColumn HeaderStyle-Font-Bold="true" Caption="Forenames">
                                    <DataItemTemplate>
                                        <dx:ASPxLabel Text='<%# Eval("Forenames") %>' runat="server"></dx:ASPxLabel>
                                    </DataItemTemplate>
                            </dx:GridViewDataColumn>
                            <dx:GridViewDataColumn HeaderStyle-Font-Bold="true" Caption="Surname">
                                    <DataItemTemplate>
                                        <dx:ASPxLabel Text='<%# Eval("Surname") %>' runat="server"></dx:ASPxLabel>
                                    </DataItemTemplate>
                            </dx:GridViewDataColumn>
                            <dx:GridViewDataColumn HeaderStyle-Font-Bold="true" Caption="Identification">
                                    <DataItemTemplate>
                                        <dx:ASPxLabel Text='<%# Eval("IDNoPP") %>' runat="server"></dx:ASPxLabel>
                                    </DataItemTemplate>
                            </dx:GridViewDataColumn>
                            <dx:GridViewDataColumn HeaderStyle-Font-Bold="true" Caption="Address">
                                    <DataItemTemplate>
                                        <dx:ASPxLabel Text='<%# Eval("Add_1") %>' runat="server"></dx:ASPxLabel>
                                    </DataItemTemplate>
                            </dx:GridViewDataColumn>
                        </Columns>
                    </dx:ASPxGridView>
                </td>
            </tr> 
           <tr>
                 <td style="width:208px"></td>
            </tr>
            <tr>
                 <td style="width:208px"></td>
            </tr>
        </table> 
      </asp:Panel>
</asp:Content>

