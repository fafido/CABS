<%@ Page Language="VB" MasterPageFile="~/CDSUser.master" AutoEventWireup="false" CodeFile="withdrawcomm.aspx.vb" Inherits="withdrawcomm" title="Affirm Withdrawals" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<asp:Content id="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
        
    <asp:Panel id="Panel1" runat="server" Width="840px" Font-Names="Arial" Font-Size="Medium" BackColor="White">
    
        <table width ="810px">
            <tr>
                   <td style ="text-align :left;" align="left">
                       <dx:ASPxLabel ID="ASPxLabel1" runat="server" Text="Affirmation&gt;&gt;Withdrawal Affirmation" Font-Names="Cambria" Font-Size="Small" Theme="PlasticBlue"></dx:ASPxLabel>

                   </td>
            </tr>
        </table>
    
        <asp:panel id="Panel10" runat="server" GroupingText="Withdrawal Affirmation" Font-Names="Cambria">
        <table width="810px">
            <tr>
                    <td colspan ="8" align ="left">
                          <asp:GridView ID="Gridview1" runat="server" BackColor="White" 
                        BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" 
                        CssClass="tablestyle" 
                        Style="position: relative; top: 0px; left: 0px; width: 99%;" 
                         DataKeyNames="id" AutoGenerateColumns="False" Font-Size="Small" >
                        <PagerSettings FirstPageText="First" LastPageText="Last" NextPageText="Next" PreviousPageText="Previous" />
                        <AlternatingRowStyle CssClass="altrowstyle" />
                              <FooterStyle BackColor="White" ForeColor="#000066" />
                        <HeaderStyle CssClass="headerstyle" BackColor="#006699" Font-Bold="True" ForeColor="White" />
                              <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                        <RowStyle CssClass="rowstyle" ForeColor="#000066" />
                        <Columns>
                                <%--<asp:BoundField DataField="id" HeaderText="ID" />--%>
                                <asp:BoundField DataField="ID" HeaderText="ID" />
                                <asp:BoundField DataField="Client No" HeaderText="Client No" />
                              <asp:BoundField DataField="Quantity" HeaderText="Quantity" />
                              <asp:BoundField DataField="commodity" HeaderText="Commodity" />
                                 <asp:BoundField DataField="grade" HeaderText="Grade" />
                              <asp:BoundField DataField="unitofmeasure" HeaderText="Unit of Measure" />
                            <asp:BoundField DataField="withdrawaldate" HeaderText="Withdrawal Date" />
                           

                     
                               <asp:CommandField ShowSelectButton="true" SelectText="Affirm Withdrawal"  />
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
                 
</asp:Panel>
  
</div>
</asp:Content>

