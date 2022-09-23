<%@ Page Language="VB" MasterPageFile="~/CDSUser.master" AutoEventWireup="false" CodeFile="frmApproveInterCompanyAccounts.aspx.vb" Inherits="Parameters_ApproveInterCompanyAccountsSetup" title="Inter-Company Accounts Setup" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<asp:Content id="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
   <asp:Panel id="Panel1" runat="server"  Width="100%" Font-Names="Arial" Font-Size="Medium" BackColor="White" GroupingText="Inter-Company Accounts Pending Authorization">
           <table>
               <tr id="Tr4" runat="server">
                    <td colspan="4">
                        <dx:ASPxLabel ID="ASPxLabel1" runat="server" Font-Names="Cambria" Font-Size="Small" Font-Bold="true" Text="" Theme="Glass">
                        </dx:ASPxLabel>
                       <hr/>
                    </td>
                </tr>
              <tr>
                   <td style="width: 208px"> </td>
                   <td colspan ="3">
                            <dx:ASPxGridView ID="ASPxGridView2"  runat="server" Theme="Glass" Width="640px" KeyFieldName="ID" SettingsPager-Mode="ShowAllRecords" >
                            <Columns>
                                   <dx:GridViewDataColumn VisibleIndex="0" Caption="">
                                        <DataItemTemplate>
                                            <asp:LinkButton ID="SelectID" Text="Select"  CommandName="Select" CommandArgument='<%# Eval("ID") %>' runat="server">
                                            </asp:LinkButton>
                                        </DataItemTemplate>
                                     </dx:GridViewDataColumn>
                                    <dx:GridViewDataColumn Caption="ID">
                                            <DataItemTemplate>
                                                <dx:ASPxLabel Text='<%# Eval("ID") %>' runat="server"></dx:ASPxLabel>
                                            </DataItemTemplate>
                                    </dx:GridViewDataColumn>
                                  <dx:GridViewDataColumn Caption="A/c Name">
                                        <DataItemTemplate>
                                            <dx:ASPxLabel Text='<%# Eval("AccountName") %>' runat="server"></dx:ASPxLabel>
                                        </DataItemTemplate>
                                </dx:GridViewDataColumn>
                                  <dx:GridViewDataColumn Caption="A/c Number">
                                        <DataItemTemplate>
                                            <dx:ASPxLabel Text='<%# Eval("AccountNumber") %>' runat="server"></dx:ASPxLabel>
                                        </DataItemTemplate>
                                </dx:GridViewDataColumn>
                            </Columns>
                            </dx:ASPxGridView>
                            </td>
                    </tr>
                <tr>
                    <td style="width: 208px">
                        <dx:ASPxLabel ID="ASPxLabel7" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Account Name" Theme="Glass"></dx:ASPxLabel>
                    </td>
                    <td style="width: 212px">
                        <dx:ASPxTextBox ID="txtAccountName" runat="server" style="margin-top: 0px" Theme="Glass" Width="250px" Font-Bold="true" ReadOnly="true">
                                </dx:ASPxTextBox>
                    </td>
                    <td style="width: 208px" align="right">
                        <dx:ASPxLabel ID="ASPxLabel8" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Old Account Name" Theme="Glass"></dx:ASPxLabel>
                    </td>
                    <td style="width: 212px">
                        <dx:ASPxTextBox ID="txtOLDAccountName" runat="server" style="margin-top: 0px" Theme="Glass" Width="250px" Font-Bold="true" ReadOnly="true">
                                </dx:ASPxTextBox>
                    </td>
                </tr>
                <tr>
                    <td style="width: 208px">
                        <dx:ASPxLabel ID="ASPxLabel22" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Account Number" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td style="width: 212px">
                        <dx:ASPxTextBox ID="txtAccountNumber" runat="server" style="margin-top: 0px" Theme="Glass" Width="250px" Font-Bold="true" ReadOnly="true">
                                </dx:ASPxTextBox>
                    </td>
                    <td style="width: 208px" align="right">
                        <dx:ASPxLabel ID="ASPxLabel9" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Old Account Number" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td style="width: 212px">
                        <dx:ASPxTextBox ID="txtOLDAccountNumber" runat="server" style="margin-top: 0px" Theme="Glass" Width="250px" Font-Bold="true" ReadOnly="true">
                                </dx:ASPxTextBox>
                    </td>
                </tr>
                <tr>
                    <td style="width: 208px">
                        <dx:ASPxLabel ID="ASPxLabel4" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Created/Update By" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td style="width: 212px">
                        <dx:ASPxTextBox ID="txtCreatedUpdateBy" runat="server" style="margin-top: 0px" Theme="Glass" ReadOnly="true" Font-Bold="true" Width="250px">
                                </dx:ASPxTextBox>
                    </td>
                </tr>
                <tr>
                    <td style="width: 208px">
                        <dx:ASPxLabel ID="ASPxLabel5" runat="server" Font-Names="Cambria" Font-Size="Small" Text="DateTime Created/Updated" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td style="width: 212px">
                        <dx:ASPxTextBox ID="txtDateTimeCreatedUpdated" runat="server" style="margin-top: 0px" Theme="Glass" ReadOnly="true" Font-Bold="true" Width="250px">
                                </dx:ASPxTextBox>
                    </td>
                </tr>
                <tr>
                    <td style="width: 208px">
                        <dx:ASPxLabel ID="ASPxLabel6" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Update Type" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td style="width: 212px">
                        <dx:ASPxTextBox ID="txtUpdateType" runat="server" style="margin-top: 0px" Theme="Glass" ReadOnly="true" Width="250px" Font-Bold="true">
                                </dx:ASPxTextBox>
                    </td>
                </tr>
                <tr>
                    <td style="width: 208px">
                        <dx:ASPxLabel ID="ASPxLabel2" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Record ID" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td style="width: 212px">
                        <dx:ASPxTextBox ID="txtRecordID" runat="server" style="margin-top: 0px" Theme="Glass" ReadOnly="true" Width="250px" Font-Bold="true">
                                </dx:ASPxTextBox>
                    </td>
                </tr>
                <tr>
                    <td style="width: 208px">
                        <dx:ASPxLabel ID="ASPxLabel3" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Audit ID" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td style="width: 212px">
                        <dx:ASPxTextBox ID="txtAuditID" runat="server" style="margin-top: 0px" Theme="Glass" ReadOnly="true" Width="250px" Font-Bold="true">
                                </dx:ASPxTextBox>
                    </td>
                </tr>
               
           <tr id="panelLastSection1" runat="server">
                    <td style="width:208px"></td>
                        <td colspan="3">
                            <dx:ASPxRadioButton ID="rdApprove" runat="server" AutoPostBack="True" GroupName="Approval" Text="Approve" Theme="DevEx">
                            </dx:ASPxRadioButton>
                            <dx:ASPxRadioButton ID="rdReject" runat="server" AutoPostBack="True" GroupName="Approval" Text="Reject" Theme="DevEx">
                            </dx:ASPxRadioButton>
                        </td>
                    </tr>
           <tr id="panelLastSection2" runat="server">
                        <td style="width:208px">
                            <dx:ASPxLabel ID="lblRejection" runat="server" Text="Rejection Reason" Visible="False">
                            </dx:ASPxLabel>
                        </td>
                        <td colspan="3">
                            <dx:ASPxMemo ID="txtReasons" runat="server" Height="80px" Theme="BlackGlass" Visible="False" Width="400px">
                            </dx:ASPxMemo>
                        </td>
                    </tr>
           <tr id="panelLastSection3" runat="server">
                    <td style="width:208px"></td>
                    <td style="width:212px">
                        <dx:ASPxButton ID="ASPxButton1" runat="server" Text="Submit" Theme="BlackGlass" style="height: 23px">
                        </dx:ASPxButton>
                    </td>
            </tr>
        </table>
</asp:Panel>
</asp:Content>

