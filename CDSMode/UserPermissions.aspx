<%@ Page Language="VB" MasterPageFile="~/CDSUser.master" AutoEventWireup="false" CodeFile="UserPermissions.aspx.vb" Inherits="CDSMode_UserPermissions" title="Permissions" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<asp:Content id="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
        
    <asp:Panel id="Panel1" runat="server" Width="100%" Font-Names="Arial" Font-Size="Medium" BackColor="White">
    
        <table width ="100%">
            <tr>
                   <td style ="text-align :left;" align="left">
                       <dx:ASPxLabel ID="ASPxLabel1" runat="server" Text="Parameters&gt;&gt;Role Permissions" Font-Names="Cambria" Font-Size="Small" Theme="PlasticBlue"></dx:ASPxLabel>

                   </td>
            </tr>
        </table>
        <asp:Panel runat="server" ID="Companie" Font-Names="Cambria" GroupingText="Role Permissions">
    <table>
            <tr>
                <td colspan ="1" style="height: 23px">
                    <dx:ASPxLabel ID="ASPxLabel2" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Select User Type" Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                <td colspan ="1" style="height: 23px">
                    <asp:DropDownList ID="cmbParticipants" runat="server" AutoPostBack="True" Width="250px">
                    </asp:DropDownList>
                </td>
                <td colspan ="1" style="height: 23px"></td>
                <td colspan ="1" style="height: 23px">
                    &nbsp;</td>
                <td colspan ="1" style="height: 23px"></td>
                <td colspan ="1" style="height: 23px"></td>
                <td colspan ="1" style="height: 23px"></td>
                <td colspan ="1" style="height: 23px"></td>
            </tr>

            <tr>
                <td colspan="1" style="height: 23px">
                    <dx:ASPxLabel ID="ASPxLabel3" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Main Menu" Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                <td colspan="1" style="height: 23px">
                    <asp:DropDownList ID="cmbmenu" runat="server" AutoPostBack="True" Width="250px">
                       
                    </asp:DropDownList>
                </td>
                <td colspan="1" style="height: 23px"></td>
                <td colspan="1" style="height: 23px"></td>
                <td colspan="1" style="height: 23px"></td>
                <td colspan="1" style="height: 23px"></td>
                <td colspan="1" style="height: 23px"></td>
                <td colspan="1" style="height: 23px"></td>
            </tr>

            <tr>
                <td colspan="1" style="height: 23px">
                    <dx:ASPxLabel ID="ASPxLabel4" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Menu Search" Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                <td colspan="1" style="height: 23px">
                    <asp:TextBox ID="txtsearch" runat="server"  Width="247px" AutoPostBack="True"></asp:TextBox>
                </td>
                <td colspan="1" style="height: 23px">&nbsp;</td>
                <td colspan="1" style="height: 23px">
                    <asp:Button ID="Button2" runat="server" Text="Clear Search" />
                </td>
                <td colspan="1" style="height: 23px">&nbsp;</td>
                <td colspan="1" style="height: 23px">&nbsp;</td>
                <td colspan="1" style="height: 23px">&nbsp;</td>
                <td colspan="1" style="height: 23px">&nbsp;</td>
            </tr>

    </table>
</asp:Panel>
        <asp:panel id="Panel10" runat="server" GroupingText="All Permissions" Font-Names="Cambria">
        <table width="100%">
            <tr>
                    <td colspan ="8" align ="left">
                          <asp:GridView ID="Gridview1" runat="server" BackColor="White" 
                        BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" 
                        CssClass="tablestyle" 
                        Style="position: relative; top: 0px; left: 0px; width: 99%;" 
                         DataKeyNames="ID" AutoGenerateColumns="False" Font-Size="Small" >
                        <PagerSettings FirstPageText="First" LastPageText="Last" NextPageText="Next" PreviousPageText="Previous" />
                        <AlternatingRowStyle CssClass="altrowstyle" />
                              <FooterStyle BackColor="White" ForeColor="#000066" />
                        <HeaderStyle CssClass="headerstyle" BackColor="#C1DBFA" Font-Bold="True" ForeColor="#0078E7" />
                              <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                        <RowStyle CssClass="rowstyle" ForeColor="#000066" />
                        <Columns>
                                <%--<asp:BoundField DataField="id" HeaderText="ID" />--%>
                                <asp:BoundField DataField="Name" HeaderText="Menu Name" />
                                                               <asp:BoundField DataField="url" HeaderText="Url" />
                             <asp:BoundField DataField="Main Menu" HeaderText="Main Menu" />
                               <asp:CommandField ShowSelectButton="true" SelectText="Add"  />
                            </Columns>
                              <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                              <SortedAscendingCellStyle BackColor="#F1F1F1" />
                              <SortedAscendingHeaderStyle BackColor="#007DBB" />
                              <SortedDescendingCellStyle BackColor="#CAC9C9" />
                              <SortedDescendingHeaderStyle BackColor="#00547E" />
                    </asp:GridView>
                    </td>

            </tr>
        </table>

    </asp:panel>
                 
        <asp:Panel ID="Panel11" runat="server" Font-Names="Cambria" GroupingText="Added Permissions">
            <table width="100%">
                <tr>
                    <td align="left" colspan="8">
                        <asp:GridView ID="Gridview2" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" CssClass="tablestyle" DataKeyNames="ID" Font-Size="Small" Style="position: relative; top: 0px; left: 0px; width: 99%;">
                            <PagerSettings FirstPageText="First" LastPageText="Last" NextPageText="Next" PreviousPageText="Previous" />
                            <AlternatingRowStyle CssClass="altrowstyle" />
                            <FooterStyle BackColor="White" ForeColor="#000066" />
                            <HeaderStyle BackColor="#D0E4FE" CssClass="headerstyle" Font-Bold="True" ForeColor="#003AB6" />
                            <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                            <RowStyle CssClass="rowstyle" ForeColor="#000066" />
                            <Columns>
                               <%-- <asp:BoundField DataField="id" HeaderText="ID" />--%>
                                <asp:BoundField DataField="Name" HeaderText="Menu Name" />
                                
                                <asp:BoundField DataField="url" HeaderText="Url" />
                                <asp:BoundField DataField="Main Menu" HeaderText="Main Menu" />
                                <asp:CommandField SelectText="Remove" ShowSelectButton="true" />
                            </Columns>
                            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                            <SortedAscendingCellStyle BackColor="#F1F1F1" />
                            <SortedAscendingHeaderStyle BackColor="#007DBB" />
                            <SortedDescendingCellStyle BackColor="#CAC9C9" />
                            <SortedDescendingHeaderStyle BackColor="#00547E" />
                        </asp:GridView>
                    </td>
                </tr>
            </table>
        </asp:Panel>
                 
</asp:Panel>
  
</div>
</asp:Content>

