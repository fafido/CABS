<%@ Page Title="" Language="VB" MasterPageFile="~/CDSUser.master" AutoEventWireup="false" CodeFile="ClientHolding.aspx.vb" Inherits="Reporting_ClientHolding" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 
    <asp:Panel id="Panel1" runat="server" Width="100%" Font-Names="Arial" Font-Size="Medium" GroupingText="Reporting>>Client Holding Statement" BackColor="White">
        <table>
            <tr runat="server" visible="false">
                <td style="width:208px">
                    <dx:ASPxLabel ID="ASPxLabel13" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Search Name/CDS Number/Mobile" Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                <td style="width:212px">
                    <dx:ASPxTextBox ID="txtSeachName" runat="server" Theme="BlackGlass" Width="400px">
                    </dx:ASPxTextBox>
                </td>
                <td style="width:208px">
                    <dx:ASPxButton ID="btnSearch" runat="server" Text=">>" Theme="BlackGlass" Width="250px">
                    </dx:ASPxButton>
                </td>
            </tr>
             <tr runat="server" visible="false">
                <td style="width:208px">
                    <dx:ASPxListBox ID="lstSearchAcc" runat="server" AutoPostBack="True" Theme="Glass" ValueType="System.String" Width="250px">
                    </dx:ASPxListBox>
                 </td>
            </tr>
            <tr>
                 <td align="right" style="width:20px">
                    
                    
                </td>
                <td   style="width:408px">
                    <dx:ASPxLabel ID="lblCDsNumber" runat="server" Theme="BlackGlass">
                    </dx:ASPxLabel>
                     <dx:ASPxLabel ID="lblCDsAccount" runat="server" Theme="BlackGlass">
                    </dx:ASPxLabel>
                </td>
               
            </tr>

             <tr>
                <td style="width:212px">
                    <dx:ASPxLabel ID="ASPxLabel35" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Warehouse" Theme="Glass">
                    </dx:ASPxLabel>
                    
                </td>
                <td style="width:208px">
                      <asp:DropDownList runat="server" ID="cmbwarehouse" Width="171px">
                                              

                                                  
                                       </asp:DropDownList>

                 

                    </tr>
            <tr>
                <td  style="width:212px">
                    <dx:ASPxLabel ID="ASPxLabel11" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Date From" Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                <td style="width:208px">
                    <dx:ASPxDateEdit ID="txtDateFrom" runat="server" Theme="BlackGlass">
                    </dx:ASPxDateEdit>
                </td>
               
            </tr>

           

  <tr>
                <td style="width:212px">
                    <dx:ASPxLabel ID="ASPxLabel12" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Date To" Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                <td style="width:208px">
                    <dx:ASPxDateEdit ID="txtDateTo" runat="server" Theme="BlackGlass">
                    </dx:ASPxDateEdit>
                </td>
                

            </tr>

            <tr>
                <td colspan="1"></td>
                <td colspan ="1">
                    <dx:ASPxButton ID="btnPrint" runat="server" Text="Print" Theme="BlackGlass" Width="150px">
                    </dx:ASPxButton>
                    &nbsp;<dx:ASPxButton ID="btnPrint0" runat="server" Text="Clear" Theme="BlackGlass" Width="150px">
                    </dx:ASPxButton>
                </td>
            </tr>

           <%-- <tr >
                  <td align="right" style="width:508px">
                <asp:GridView ID="GridView1" runat="server"  AutoGenerateSelectButton="False"  EmptyDataText="No Holdings" CellPadding="4" ForeColor="#333333" GridLines="None"   Width="750px" EmptyDataRowStyle-CssClass="text-warning text-center" >
                                       
                                        
                                        <AlternatingRowStyle BackColor="White" ForeColor="#284775"  />

                                        <EditRowStyle BackColor="#999999" />

                                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />
                                        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                        <SortedAscendingCellStyle BackColor="#E9E7E2" />
                                        <SortedAscendingHeaderStyle BackColor="#506C8C" />
                                        <SortedDescendingCellStyle BackColor="#FFFDF8" />
                                        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                                          <Columns>
                   
              
                                               <asp:TemplateField HeaderText="ATF"> 
                        <ItemTemplate >
                            

                            <asp:CheckBox ID="chkRow" runat="server"  autopostback="true"  />

                            
                    </ItemTemplate>
                      
                                                   </asp:TemplateField>
                                              <asp:TemplateField Visible="false"  HeaderText="id">
<ItemTemplate>
<asp:Label ID="id" runat="server" Text='<%# Bind("id") %>'></asp:Label>
</ItemTemplate>
</asp:TemplateField>
                                         
                                               
                       
                                              </Columns>
                                         
                                    </asp:GridView>
                 
                
                </td>
            </tr>--%>



        </table>
        <asp:panel id="Panel5" runat="server" GroupingText="" Font-Names="Cambria">
        <table width="810px">
           
          
            





            <tr >
                  <td align="left" colspan ="1">

                      
                         <asp:GridView ID="grdRules" runat="server" BackColor="White"  Settings-ShowTitlePanel="true" SettingsText-Title="Transfers"
                        BorderColor="#eafaf1" BorderStyle="None" BorderWidth="1px" CellPadding="3" 
                        CssClass="tablestyle" 
                        Style="position: relative; top: 0px; left: 0px; width: 99%;" 
                         DataKeyNames="id" AutoGenerateColumns="False" Font-Size="Small" >
                        <PagerSettings FirstPageText="First" LastPageText="Last" NextPageText="Next" PreviousPageText="Previous" />
                        <AlternatingRowStyle CssClass="altrowstyle" />
                              <FooterStyle BackColor="White" ForeColor="#000066" />
                        <HeaderStyle CssClass="headerstyle" BackColor="#eafaf1" Font-Bold="True" ForeColor="#000" />
                              <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                        <RowStyle CssClass="rowstyle" ForeColor="#000" />


              <%--  <asp:GridView ID="grdRules" runat="server"  AutoGenerateSelectButton="False"  EmptyDataText="No Holdings" CellPadding="4" ForeColor="#000" GridLines="None" AutoGenerateColumns="False"  Width="750px" EmptyDataRowStyle-CssClass="text-warning text-center" >
                                    
                    

                                        
                                       <PagerSettings FirstPageText="First" LastPageText="Last" NextPageText="Next" PreviousPageText="Previous" />
                        <AlternatingRowStyle CssClass="altrowstyle" />
                              <FooterStyle BackColor="White" ForeColor="#000066" />
                        <HeaderStyle CssClass="headerstyle" BackColor="#eafaf1" Font-Bold="True" ForeColor="#000" />
                              <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                        <RowStyle CssClass="rowstyle" ForeColor="#000" />--%>
                                          <Columns>
                 
              
                                               <asp:TemplateField HeaderText="AFT"> 
                        <ItemTemplate >
                            

                            <asp:CheckBox ID="chkRow" runat="server"  autopostback="true"  />

                            
                    </ItemTemplate>
                                                 

                                                   </asp:TemplateField>

                                                  <asp:BoundField DataField="id" Visible="false" HeaderText="ID" />
                      
                                                    <asp:BoundField DataField="S.No" HeaderText="S.No" />
                                                 <asp:BoundField DataField="EWR No." HeaderText="EWR No." />
                                <asp:BoundField DataField="WarehouseName" HeaderText="WarehouseName" />
                              
                          
                              <asp:BoundField DataField="Commodity" HeaderText="Commodity" />
                               <asp:BoundField DataField="Grade" HeaderText="Grade" />
                         

                             <asp:BoundField DataField="Quantity" HeaderText="Quantity" />
                                              <asp:BoundField DataField="Price" HeaderText="Price" />
                                              <asp:BoundField DataField="Unit of Measure" HeaderText="Unit of Measure" />
                                            

                                              <asp:TemplateField Visible="false"  HeaderText="id">
<ItemTemplate>
<asp:Label ID="id" runat="server" Text='<%# Bind("id") %>'></asp:Label>
</ItemTemplate>
</asp:TemplateField>
                                         
                                               
                       
                                              </Columns>
                                         
                                    </asp:GridView>
                 
                
                </td>
            </tr>
             
            <tr>
                        <td colspan="1">&nbsp;</td>
                        <td colspan="1">&nbsp;</td>
                        <td colspan="1">&nbsp;</td>
                        <td colspan="1">&nbsp;</td>
                        <td colspan="1">&nbsp;</td>
                        <td colspan="1">&nbsp;</td>
                        <td colspan="1">&nbsp;</td>
                    </tr>

                <tr >
                  <td align="left" colspan ="1">

                      
                         <asp:GridView ID="GridView1" runat="server" BackColor="White"  Settings-ShowTitlePanel="true" SettingsText-Title="Transfers"
                        BorderColor="#eafaf1" BorderStyle="None" BorderWidth="1px" CellPadding="3" 
                        CssClass="tablestyle" 
                        Style="position: relative; top: 0px; left: 0px; width: 99%;" 
                         DataKeyNames="id" AutoGenerateColumns="False" Font-Size="Small" >
                        <PagerSettings FirstPageText="First" LastPageText="Last" NextPageText="Next" PreviousPageText="Previous" />
                        <AlternatingRowStyle CssClass="altrowstyle" />
                              <FooterStyle BackColor="White" ForeColor="#000066" />
                        <HeaderStyle CssClass="headerstyle" BackColor="#eafaf1" Font-Bold="True" ForeColor="#000" />
                              <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                        <RowStyle CssClass="rowstyle" ForeColor="#000" />


              <%--  <asp:GridView ID="grdRules" runat="server"  AutoGenerateSelectButton="False"  EmptyDataText="No Holdings" CellPadding="4" ForeColor="#000" GridLines="None" AutoGenerateColumns="False"  Width="750px" EmptyDataRowStyle-CssClass="text-warning text-center" >
                                    
                    

                                        
                                       <PagerSettings FirstPageText="First" LastPageText="Last" NextPageText="Next" PreviousPageText="Previous" />
                        <AlternatingRowStyle CssClass="altrowstyle" />
                              <FooterStyle BackColor="White" ForeColor="#000066" />
                        <HeaderStyle CssClass="headerstyle" BackColor="#eafaf1" Font-Bold="True" ForeColor="#000" />
                              <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                        <RowStyle CssClass="rowstyle" ForeColor="#000" />--%>
                                          <Columns>
                 
              
                                               <asp:TemplateField HeaderText="AFT"> 
                        <ItemTemplate >
                            

                            <asp:CheckBox ID="chkRow" runat="server"  autopostback="true"  />

                            
                    </ItemTemplate>
                                                 

                                                   </asp:TemplateField>
                                 

                                                  <asp:BoundField DataField="id" Visible="false" HeaderText="ID" />
                      
                                                    <asp:BoundField DataField="S.No" HeaderText="S.No" />
                                                 <asp:BoundField DataField="EWR No." HeaderText="EWR No." />
                                <asp:BoundField DataField="WarehouseName" HeaderText="WarehouseName" />
                              
                          
                              <asp:BoundField DataField="Commodity" HeaderText="Commodity" />
                               <asp:BoundField DataField="Grade" HeaderText="Grade" />
                         

                             <asp:BoundField DataField="Quantity" HeaderText="Quantity" />
                                              <asp:BoundField DataField="Price" HeaderText="Price" />
                                              <asp:BoundField DataField="Unit of Measure" HeaderText="Unit of Measure" />
                                            

                                              <asp:TemplateField Visible="false"  HeaderText="id">
<ItemTemplate>
<asp:Label ID="id" runat="server" Text='<%# Bind("id") %>'></asp:Label>
</ItemTemplate>
</asp:TemplateField>
                                         
                                               
                       
                                              </Columns>
                                         
                                    </asp:GridView>
                 
                
                </td>
            </tr>
             


             <tr>
                        <td colspan="1">&nbsp;</td>
                        <td colspan="1">&nbsp;</td>
                        <td colspan="1">&nbsp;</td>
                        <td colspan="1">&nbsp;</td>
                        <td colspan="1">&nbsp;</td>
                        <td colspan="1">&nbsp;</td>
                        <td colspan="1">&nbsp;</td>
                    </tr>

                <tr >
                  <td align="left" colspan ="1">

                      
                         <asp:GridView ID="GridView2" runat="server" BackColor="White"  Settings-ShowTitlePanel="true" SettingsText-Title="Transfers"
                        BorderColor="#eafaf1" BorderStyle="None" BorderWidth="1px" CellPadding="3" 
                        CssClass="tablestyle" 
                        Style="position: relative; top: 0px; left: 0px; width: 99%;" 
                         DataKeyNames="id" AutoGenerateColumns="False" Font-Size="Small" >
                        <PagerSettings FirstPageText="First" LastPageText="Last" NextPageText="Next" PreviousPageText="Previous" />
                        <AlternatingRowStyle CssClass="altrowstyle" />
                              <FooterStyle BackColor="White" ForeColor="#000066" />
                        <HeaderStyle CssClass="headerstyle" BackColor="#eafaf1" Font-Bold="True" ForeColor="#000" />
                              <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                        <RowStyle CssClass="rowstyle" ForeColor="#000" />


              <%--  <asp:GridView ID="grdRules" runat="server"  AutoGenerateSelectButton="False"  EmptyDataText="No Holdings" CellPadding="4" ForeColor="#000" GridLines="None" AutoGenerateColumns="False"  Width="750px" EmptyDataRowStyle-CssClass="text-warning text-center" >
                                    
                    

                                        
                                       <PagerSettings FirstPageText="First" LastPageText="Last" NextPageText="Next" PreviousPageText="Previous" />
                        <AlternatingRowStyle CssClass="altrowstyle" />
                              <FooterStyle BackColor="White" ForeColor="#000066" />
                        <HeaderStyle CssClass="headerstyle" BackColor="#eafaf1" Font-Bold="True" ForeColor="#000" />
                              <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                        <RowStyle CssClass="rowstyle" ForeColor="#000" />--%>
                                          <Columns>
                 
              
                                               <asp:TemplateField HeaderText="AFT"> 
                        <ItemTemplate >
                            

                            <asp:CheckBox ID="chkRow" runat="server"  autopostback="true"  />

                            
                    </ItemTemplate>
                                                 

                                                   </asp:TemplateField>

                                                  <asp:BoundField DataField="id" Visible="false" HeaderText="ID" />
                      
                                                    <asp:BoundField DataField="S.No" HeaderText="S.No" />
                                                 <asp:BoundField DataField="EWR No." HeaderText="EWR No." />
                                <asp:BoundField DataField="WarehouseName" HeaderText="WarehouseName" />
                              
                          
                              <asp:BoundField DataField="Commodity" HeaderText="Commodity" />
                               <asp:BoundField DataField="Grade" HeaderText="Grade" />
                         

                             <asp:BoundField DataField="Quantity" HeaderText="Quantity" />
                                              <asp:BoundField DataField="Price" HeaderText="Price" />
                                              <asp:BoundField DataField="Unit of Measure" HeaderText="Unit of Measure" />
                                            

                                              <asp:TemplateField Visible="false"  HeaderText="id">
<ItemTemplate>
<asp:Label ID="id" runat="server" Text='<%# Bind("id") %>'></asp:Label>
</ItemTemplate>
</asp:TemplateField>
                                         
                                               
                       
                                              </Columns>
                                         
                                    </asp:GridView>
                 
                
                </td>
            </tr>
                 
             <tr>

                    <td align="CENTER" colspan ="1">
                    <dx:ASPxButton ID="btnprocess" visible="false" runat="server" Text="Process" Theme="BlackGlass" Width="150px">
                    </dx:ASPxButton>
               
                </td>
                </tr>
               
           

        </table>

    </asp:panel>
         
</asp:Panel>
</asp:Content>

