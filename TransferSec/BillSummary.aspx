<%@ Page Language="VB" MasterPageFile="~/CDSUser.master" AutoEventWireup="false" CodeFile="BillSummary.aspx.vb" Inherits="Corp_BillSummary" title="Bill Summary" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView.Export" TagPrefix="dx" %>

<asp:Content id="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Panel id="Panel1" runat="server" Width="90%" Font-Names="Cambria" BackColor="White" GroupingText="Bill Summary">
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
                        <dx:ASPxLabel ID="ASPxLabel72d" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Asset Manager" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td style="width: 212px">
                        <dx:ASPxComboBox ID="cmbAssetManager" runat="server" Theme="Glass" Width="250px"  CallbackPageSize="15" EnableCallbackMode="True" DropDownStyle="DropDownList"  IncrementalFilteringMode="Contains"  AnimationType="Slide" AutoPostBack="False">
                            <Items>
                                <dx:ListEditItem Text="" Value="" /> 
                            </Items>
                        </dx:ASPxComboBox>
                    </td>
                    <td style="width: 208px"></td>
                    <td style="width: 212px"></td>
                  </tr>
           <tr id="Tr2" runat="server">
                    <td style="width: 208px">
                        <dx:ASPxLabel ID="ASPxLabel2" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Client" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td style="width: 212px">
                        <dx:ASPxComboBox ID="cmbClient" runat="server" Theme="Glass" Width="250px"  CallbackPageSize="15" EnableCallbackMode="True" DropDownStyle="DropDownList"  IncrementalFilteringMode="Contains"  AnimationType="Slide" AutoPostBack="false">
                            <Items>
                                <dx:ListEditItem Text="" Value="" /> 
                            </Items>
                        </dx:ASPxComboBox>
                    </td>
                  </tr>
           <tr id="Tr3" runat="server">
                    <td style="width: 208px">
                        <dx:ASPxLabel ID="ASPxLabel3" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Invoice Status" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td style="width: 212px">
                        <dx:ASPxComboBox ID="cmbStatus" runat="server" Theme="Glass" Width="250px"  CallbackPageSize="15" EnableCallbackMode="True" DropDownStyle="DropDownList"  IncrementalFilteringMode="Contains"  AnimationType="Slide" AutoPostBack="false">
                            <Items>
                                <dx:ListEditItem Text="Authorised" Value="Authorised" /> 
                                <dx:ListEditItem Text="New" Value="New" /> 
                                <dx:ListEditItem Text="Rejected" Value="Rejected" /> 
                                <dx:ListEditItem Text="ALL" Value="ALL" /> 
                                <dx:ListEditItem Text="NOT Billed" Value="NOT Billed" /> 
                            </Items>
                        </dx:ASPxComboBox>
                    </td>
                  </tr>
           <tr id="Tr13" runat="server">
                    <td style="width: 208px">
                        <dx:ASPxLabel ID="ASPxLabel4" runat="server" Font-Names="Cambria" Font-Size="Small" Text="From Date" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td style="width: 212px">
                        <dx:ASPxDateEdit ID="txtFromDate" runat="server" EditFormat="Custom" EditFormatString="dd MMMM yyyy" Theme="BlackGlass" Width="250px">
                        </dx:ASPxDateEdit>
                    </td>
                </tr>
           <tr>
                <td style="width: 208px">
                    <dx:ASPxLabel ID="ASPxLabel17" runat="server" Font-Names="Cambria" Font-Size="Small" Text="To Date" Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                <td style="width: 212px">
                    <dx:ASPxDateEdit ID="txtToDate" runat="server" EditFormat="Custom" EditFormatString="dd MMMM yyyy" Theme="BlackGlass" AutoPostBack="false" Width="250px">
                    </dx:ASPxDateEdit>
                </td>
           </tr>
           <tr id="Tr11" runat="server">
                <td colspan="6">
                    <dx:ASPxLabel ID="ASPxLabel26" runat="server" Font-Names="Cambria" Font-Size="Small" Text="" Theme="Glass">
                    </dx:ASPxLabel>
                   <hr/>
                </td>
            </tr>
           <tr id="PanelSAVE" runat="server" visible="true">
                        <td style="width:208px"></td>
                        <td style="width:212px">
                            &nbsp;<dx:ASPxButton ID="btnPreview" runat="server" Text="Preview" Theme="Glass">
                            </dx:ASPxButton>
                        </td>
                </tr>
        </table> 
      </asp:Panel>
</asp:Content>

