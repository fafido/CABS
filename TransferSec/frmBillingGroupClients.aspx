<%@ Page Language="VB" MasterPageFile="~/CDSUser.master" AutoEventWireup="false" CodeFile="frmBillingGroupClients.aspx.vb" Inherits="Corp_InvoiceMultiple" title="Add Group Clients" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView.Export" TagPrefix="dx" %>
<%@ Register assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxPanel" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxRoundPanel" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxPopupControl" tagprefix="dx" %>

<asp:Content id="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Panel id="Panel1" runat="server" Width="90%" Font-Names="Cambria" BackColor="White" GroupingText="Add Group Clients">
       <table>
           <tr id="Tr1" runat="server">
                <td colspan="6">
                    <dx:ASPxLabel ID="ASPxLabel1" runat="server" Font-Names="Cambria" Font-Size="Small" Text="" Theme="Glass">
                    </dx:ASPxLabel>
                   <hr/>
                </td>
            </tr>
           <tr id="Tr5" runat="server">
                    <td style="width: 208px">
                        <dx:ASPxLabel ID="ASPxLabel72d" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Group" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td style="width: 212px">
                        <dx:ASPxComboBox ID="cmbBillingGroup" runat="server" Theme="Glass" Width="250px"  CallbackPageSize="15" EnableCallbackMode="True" DropDownStyle="DropDownList"  IncrementalFilteringMode="Contains"  AnimationType="Slide" AutoPostBack="True">
                            <Items>
                                <dx:ListEditItem Text="" Value="" /> 
                            </Items>
                        </dx:ASPxComboBox>
                    </td>
               <td style="width: 208px"></td>
               <td style="width: 212px"></td>
               <td style="width: 208px"></td>
                  </tr>
           <tr id="Tr4" runat="server">
                    <td style="width: 208px">
                        <dx:ASPxLabel ID="ASPxLabel3" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Asset Manager" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td style="width: 212px">
                        <dx:ASPxComboBox ID="cmbAssetManager" runat="server" Theme="Glass" Width="250px"  CallbackPageSize="15" EnableCallbackMode="True" DropDownStyle="DropDownList"  IncrementalFilteringMode="Contains"  AnimationType="Slide" AutoPostBack="True">
                            <Items>
                                <dx:ListEditItem Text="" Value="" /> 
                            </Items>
                        </dx:ASPxComboBox>
                    </td>
               <td style="width: 208px"></td>
               <td style="width: 212px"></td>
               <td style="width: 208px"></td>
                  </tr>
           <tr id="Tr11" runat="server">
                <td colspan="6">
                    <dx:ASPxLabel ID="ASPxLabel26" runat="server" Font-Names="Cambria" Font-Size="Small" Text="" Theme="Glass">
                    </dx:ASPxLabel>
                   <hr/>
                </td>
            </tr>
           <tr id="panel00003" runat="server">
                <td colspan="5" style="height: 18px">
                    <dx:ASPxGridView ID="grdNewAccountsToBill" SettingsPager-Mode="ShowAllRecords" runat="server" KeyFieldName="ID" Theme="Glass" Width="100%">
                        <SettingsPager Visible="False">
                        </SettingsPager>
                        <Columns >
                            <dx:GridViewDataColumn VisibleIndex="0">
                                    <DataItemTemplate>
                                        <asp:LinkButton ID="LinkButton1" Text="Remove"  OnClientClick="if ( !confirm('Are you sure you want to remove this client from the billing group ? ')) return false;" CommandName="Authorise" CommandArgument='<%# Eval("ID") %>' runat="server">
                                        </asp:LinkButton>
                                    </DataItemTemplate>
                            </dx:GridViewDataColumn>
                            <dx:GridViewDataColumn FieldName="ID" HeaderStyle-Font-Bold="true" Caption="ID">
                                    <DataItemTemplate>
                                        <dx:ASPxLabel ID="lblID" Text='<%# Eval("ID") %>' runat="server"></dx:ASPxLabel>
                                    </DataItemTemplate>
                            </dx:GridViewDataColumn>
                            <dx:GridViewDataColumn HeaderStyle-Font-Bold="true" Caption="Client No.">
                                    <DataItemTemplate>
                                        <dx:ASPxLabel Text='<%# Eval("ClientNo") %>' runat="server"></dx:ASPxLabel>
                                    </DataItemTemplate>
                            </dx:GridViewDataColumn>
                            <dx:GridViewDataColumn HeaderStyle-Font-Bold="true" Caption="Names">
                                    <DataItemTemplate>
                                        <dx:ASPxLabel Text='<%# Eval("ClientName") %>' runat="server"></dx:ASPxLabel>
                                    </DataItemTemplate>
                            </dx:GridViewDataColumn>
                        </Columns>
                    </dx:ASPxGridView>
                </td>
            </tr>
           <tr id="Tr2" runat="server">
                <td colspan="6">
                    <dx:ASPxLabel ID="ASPxLabel2" runat="server" Font-Names="Cambria" Font-Size="Small" Text="" Theme="Glass">
                    </dx:ASPxLabel>
                   <hr/>
                </td>
            </tr>
           <tr>
               <td align="center">
                        <dx:ASPxPopupControl ID="ASPxPopupControl1"  runat="server" BackColor="#DDECFE" CloseAction="CloseButton"  PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" EnableCallbackAnimation="True" HeaderText="Select from List" ShowCollapseButton="True" ShowPageScrollbarWhenModal="True" ShowPinButton="True" Theme="Office2010Blue" Width="400px">
                            <contentcollection>
                                <dx:PopupControlContentControl runat="server" SupportsDisabledAttribute="True">
                                    <dx:ASPxRoundPanel ID="ASPxRoundPanel6" BackColor="White" runat="server" ShowHeader="False"  Width="100%">
                                         <panelcollection>
                                           <dx:PanelContent runat="server" SupportsDisabledAttribute="True">
                                              <table  style="width: 100%">
                                                             <tr id="Tr12" runat="server">
                                                    <td style="width: 208px">
                                                      <asp:CheckBox ID="chkSelectAll" runat="server" Text="Select All" Font-Size="Small" Font-Names="Cambria" AutoPostBack ="true"/>
                                                    </td>
                                               </tr>
                                               <tr id="Tr3" runat="server">
                                                    <td colspan="5" style="height: 18px">
                                                        <dx:ASPxGridView ID="grdSelectFromGrid" SettingsPager-Mode="ShowAllRecords" runat="server" KeyFieldName="cds_number" Theme="Glass" Width="100%">
                                                            <SettingsPager Visible="False">
                                                            </SettingsPager>
                                                            <Columns >
                                                                <dx:GridViewDataColumn Caption="Select" FieldName="Selec"  VisibleIndex="0">
                                                                        <DataItemTemplate>
                                                                            <dx:aspxcheckbox ID="chk1" Checked="false" Enabled="true" runat="server" >
                                                                                                  </dx:aspxcheckbox>
                                                                        </DataItemTemplate>
                                                                </dx:GridViewDataColumn>
                                                                <dx:GridViewDataColumn FieldName="cds_number" HeaderStyle-Font-Bold="true" Caption="Client No.">
                                                                        <DataItemTemplate>
                                                                            <dx:ASPxLabel ID="lblID" Text='<%# Eval("cds_number") %>' runat="server"></dx:ASPxLabel>
                                                                        </DataItemTemplate>
                                                                        <HeaderStyle Font-Bold="True" />
                                                                </dx:GridViewDataColumn>
                                                                <dx:GridViewDataColumn FieldName="namess" HeaderStyle-Font-Bold="true" Caption="Names">
                                                                        <DataItemTemplate>
                                                                            <dx:ASPxLabel ID="lblHolder" Text='<%# Eval("namess") %>' runat="server"></dx:ASPxLabel>
                                                                        </DataItemTemplate>
                                                                        <HeaderStyle Font-Bold="True" />
                                                                </dx:GridViewDataColumn>
                                                            </Columns>
                                                        </dx:ASPxGridView>
                                                    </td>
                                                </tr>
                                                   <tr id="Tr6" runat="server">
                                                    <td colspan="6">
                                                        <dx:ASPxLabel ID="ASPxLabel4" runat="server" Font-Names="Cambria" Font-Size="Small" Text="" Theme="Glass">
                                                        </dx:ASPxLabel>
                                                       <hr/>
                                                    </td>
                                                </tr>
                                               <tr id="PanelSAVE" runat="server" visible="true">
                                                            <td style="width:208px"></td>
                                                            <td style="width:212px">
                                                                &nbsp;<dx:ASPxButton ID="btnSave" runat="server" Text="Submit" Theme="Glass">
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
</asp:Content>

