<%@ Page Language="VB" MasterPageFile="~/CDSUser.master" AutoEventWireup="false" CodeFile="CorpEventsList.aspx.vb" Inherits="CORPEventsListReport" title="Corporate Events List" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>

<asp:Content id="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Panel id="Panel1" runat="server" Width="90%" Font-Names="Cambria" BackColor="White" GroupingText="Corporate Events List">
       <table>
           <tr id="Tr1" runat="server">
                <td colspan="6">
                    <dx:ASPxLabel ID="ASPxLabel1" runat="server" Font-Names="Cambria" Font-Size="Small" Text="" Theme="Glass">
                    </dx:ASPxLabel>
                   <hr/>
                </td>
            </tr>
           <tr id="Panel13a" runat="server">
                <td style="width: 208px">
                    <dx:ASPxLabel ID="ASPxLabel30" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Company" Theme="Glass">
                    </dx:ASPxLabel>
                        <dx:ASPxLabel ID="ASPxLabel73" runat="server" ForeColor="Red" Text="*">
                        </dx:ASPxLabel>
                </td>
                    <td style="width: 212px">
                        <dx:ASPxComboBox ID="cmbCompany" runat="server" Theme="Glass" Width="250px"  CallbackPageSize="15" EnableCallbackMode="True" DropDownStyle="DropDownList"  IncrementalFilteringMode="Contains"  AnimationType="Slide" AutoPostBack="False">
                            <Items>
                                <dx:ListEditItem Text="" Value="" /> 
                            </Items>
                        </dx:ASPxComboBox>
                    </td>
                   <td style="width: 212px"></td>
                   <td style="width: 212px"></td>
                    <td style="width: 212px"></td>
                    <td style="width: 212px"></td>
           </tr>
           <tr id="Tr2" runat="server">
                <td style="width: 208px">
                    <dx:ASPxLabel ID="ASPxLabel2" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Event Type" Theme="Glass">
                    </dx:ASPxLabel>
                        <dx:ASPxLabel ID="ASPxLabel3" runat="server" ForeColor="Red" Text="*">
                        </dx:ASPxLabel>
                </td>
                    <td style="width: 212px">
                        <dx:ASPxComboBox ID="cmbEventType" runat="server" Theme="Glass" Width="250px"  CallbackPageSize="15" EnableCallbackMode="True" DropDownStyle="DropDownList"  IncrementalFilteringMode="Contains"  AnimationType="Slide" AutoPostBack="False">
                            <Items>
                                <dx:ListEditItem Text="ALL" Value="ALL" /> 
                                <dx:ListEditItem Text="Bonus" Value="Bonus" /> 
                                <dx:ListEditItem Text="Consolidation" Value="Consolidation" /> 
                                <dx:ListEditItem Text="DeMerger" Value="DeMerger" /> 
                                <dx:ListEditItem Text="Dividend" Value="Dividend" /> 
                                <dx:ListEditItem Text="Merger" Value="Merger" /> 
                                <dx:ListEditItem Text="Rights" Value="Rights" /> 
                                <dx:ListEditItem Text="Split" Value="Split" /> 
                            </Items>
                        </dx:ASPxComboBox>
                    </td>
                   <td style="width: 212px"></td>
                   <td style="width: 212px"></td>
                    <td style="width: 212px"></td>
                    <td style="width: 212px"></td>
           </tr>
           <tr id="Panel8b" runat="server">
                    <td style="width: 208px">
                        <dx:ASPxLabel ID="ASPxLabel29" runat="server" Font-Names="Cambria" Font-Size="Small" Text="From" Theme="Glass">
                        </dx:ASPxLabel>
                        <dx:ASPxLabel ID="ASPxLabel6" runat="server" ForeColor="Red" Text="*">
                        </dx:ASPxLabel>
                    </td>
                    <td style="width: 212px">
                        <dx:ASPxDateEdit ID="txtDateFROM" runat="server" EditFormat="Custom" EditFormatString="dd MMMM yyyy" Theme="BlackGlass" Width="250px">
                        </dx:ASPxDateEdit>
                    </td>
                </tr>
           <tr id="Tr3" runat="server">
                    <td style="width: 208px">
                        <dx:ASPxLabel ID="ASPxLabel4" runat="server" Font-Names="Cambria" Font-Size="Small" Text="To" Theme="Glass">
                        </dx:ASPxLabel>
                        <dx:ASPxLabel ID="ASPxLabel5" runat="server" ForeColor="Red" Text="*">
                        </dx:ASPxLabel>
                    </td>
                    <td style="width: 212px">
                        <dx:ASPxDateEdit ID="txtDateTO" runat="server" EditFormat="Custom" EditFormatString="dd MMMM yyyy" Theme="BlackGlass" Width="250px">
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
           <tr id="PanelSAVE" runat="server">
                        <td style="width:208px"></td>
                        <td style="width:212px">
                            &nbsp;<dx:ASPxButton ID="btnPreview" runat="server" Text="Preview" Theme="Glass">
                            </dx:ASPxButton>
                        </td>
                </tr>
        </table> 
      </asp:Panel>
</asp:Content>

