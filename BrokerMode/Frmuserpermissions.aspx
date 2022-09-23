<%@ Page Language="VB" MasterPageFile="~/CDSUser.master" AutoEventWireup="false" CodeFile="Frmuserpermissions.aspx.vb" Inherits="BrokerMode_Frmuserpermissions" title="System Permissions" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<asp:Content id="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
        
    <asp:Panel id="Panel1" runat="server" Width="840px" Font-Names="Arial" Font-Size="Medium" BackColor="White">
    
        <table width ="810px">
            <tr>
                   <td style ="text-align :left;" align="left">
                       <dx:ASPxLabel ID="ASPxLabel1" runat="server" Text="Parameters&gt;&gt;User Permissions Management" Font-Names="Cambria" Font-Size="Small" Theme="PlasticBlue"></dx:ASPxLabel>

                   </td>
            </tr>
        </table>
        <asp:Panel runat="server" ID="Companie" Font-Names="Cambria" GroupingText="Company Details">
    <table>
            <tr>
                <td colspan ="1">
                    <dx:ASPxLabel ID="ASPxLabel2" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Select User" Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                <td colspan ="1">
                    <asp:DropDownList ID="cmbParticipants" runat="server" AutoPostBack="True" Width="250px">
                    </asp:DropDownList>
                </td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>
                <td colspan ="1">
                    <asp:Button ID="Button2" runat="server" Text="Button" Visible="False" />
                </td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>
            </tr>

    </table>
</asp:Panel>
        <asp:panel id="Panel10" runat="server" GroupingText="All Permissions" Font-Names="Cambria">
        <table width="810px">
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
                        <HeaderStyle CssClass="headerstyle" BackColor="#006699" Font-Bold="True" ForeColor="White" />
                              <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                        <RowStyle CssClass="rowstyle" ForeColor="#000066" />
                        <Columns>
                               
                                <asp:BoundField DataField="Name" HeaderText="Menu Name" />
                                
                                <asp:BoundField DataField="url" HeaderText="Url" />
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
            <table width="810px">
                <tr>
                    <td align="left" colspan="8">
                        <asp:GridView ID="Gridview2" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" CssClass="tablestyle" DataKeyNames="ID" Font-Size="Small" Style="position: relative; top: 0px; left: 0px; width: 99%;">
                            <PagerSettings FirstPageText="First" LastPageText="Last" NextPageText="Next" PreviousPageText="Previous" />
                            <AlternatingRowStyle CssClass="altrowstyle" />
                            <FooterStyle BackColor="White" ForeColor="#000066" />
                            <HeaderStyle BackColor="#006699" CssClass="headerstyle" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                            <RowStyle CssClass="rowstyle" ForeColor="#000066" />
                            <Columns>
                               
                                <asp:BoundField DataField="Name" HeaderText="Menu Name" />
                                
                                <asp:BoundField DataField="url" HeaderText="Url" />
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

