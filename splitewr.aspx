<%@ Page Language="VB" MasterPageFile="~/CDSUser.master" AutoEventWireup="false" CodeFile="splitewr.aspx.vb" Inherits="TransferSec_splitewr" title="Split EWR" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<asp:Content id="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
    <asp:Panel id="Panel1" runat="server" Width="840px" Font-Names="Arial" Font-Size="Medium" BackColor="White">
    
        <table width ="810px">
            <tr>
                   <td style ="text-align :left;" align="left">
                       <dx:ASPxLabel ID="ASPxLabel1" runat="server" Text="Batching&gt;&gt;Split" Font-Names="Cambria" Font-Size="Small" Theme="PlasticBlue"></dx:ASPxLabel>

                   </td>
            </tr>
        </table>

          <asp:panel id="Panel2" runat="server" GroupingText="Search Options" Font-Names="Cambria">
        <table width="810px">
            <tr runat="server" visible="false">
                <td colspan ="1" align="right">
                    &nbsp;</td>
                <td colspan ="1" width="301">
                    <asp:RadioButtonList ID="rblTranType" runat="server">
                        <asp:ListItem>New Transaction</asp:ListItem>
                        <asp:ListItem>Rejected Entries</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
                <td colspan ="1">
                    &nbsp;</td>
                <td colspan ="1">&nbsp;</td>
                <td colspan ="1">&nbsp;</td>

            </tr>
             <tr>
                 <td align="right" colspan="1">&nbsp;</td>
                 <td colspan="1" width="301">&nbsp;</td>
                 <td colspan="1">&nbsp;</td>
                 <td colspan="1">&nbsp;</td>
                 <td colspan="1">&nbsp;</td>
            </tr>
            <tr  runat="server" visible="false">
                <td align="right" colspan="1">
                    <dx:ASPxLabel ID="ASPxLabel2" runat="server" Font-Names="Cambria" Font-Size="Small" Text="WR #" Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                <td colspan="1" width="301">
                    <dx:ASPxTextBox ID="txtWRNo" runat="server" Theme="Glass" Width="300px">
                    </dx:ASPxTextBox>
                </td>
                <td colspan="1">
                    <dx:ASPxButton ID="ASPxButton1" runat="server" Text="&gt;&gt;" Theme="BlackGlass" Width="38px">
                    </dx:ASPxButton>
                </td>
                <td colspan="1"></td>
                <td colspan="1"></td>
            </tr>
             <tr runat="server" visible="false">
                <td colspan ="1" align="right">
                    <dx:ASPxLabel ID="ASPxLabel3" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Depositor Name." Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                <td colspan ="1" width="301">
                    <dx:ASPxTextBox ID="txtClientName" runat="server" Theme="Glass" Width="300px">
                    </dx:ASPxTextBox>
                </td>
                <td colspan ="1">
                    <dx:ASPxButton ID="ASPxButton2" runat="server" Text="&gt;&gt;" Width="38px" Theme="BlackGlass">
                    </dx:ASPxButton>
                </td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>

            </tr>

            <tr>
                <td colspan="5">
                    <asp:GridView ID="grdAvailableWRs" runat="server" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="id" EmptyDataText="No Relevant Data Found" ForeColor="#333333" GridLines="None" Height="16px" Width="99%">
                        <PagerSettings FirstPageText="First" LastPageText="Last" NextPageText="Next" PreviousPageText="Previous" />
                        <AlternatingRowStyle CssClass="altrowstyle" BackColor="White" />
                        <Columns>
                            <asp:BoundField DataField="ReceiptNo" HeaderText="WR#" />
                            <asp:BoundField DataField="DepositorAcc" HeaderText="Depositor Acc#" />
                            <asp:BoundField DataField="DepositorName" HeaderText="Depositor Name" />
                            <asp:BoundField DataField="Commodity" HeaderText="Commodity" />
                            <asp:BoundField DataField="Quantity" HeaderText="Quantity" />
                            <asp:CommandField SelectText="Split WR" ShowSelectButton="true" />
                        </Columns>
                        <EditRowStyle BackColor="#2461BF" />
                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle CssClass="headerstyle" BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle CssClass="rowstyle" BackColor="#EFF3FB" />
                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#F5F7FB" />
                        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                        <SortedDescendingCellStyle BackColor="#E9EBEF" />
                        <SortedDescendingHeaderStyle BackColor="#4870BE" />
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td colspan="1">&nbsp;</td>
                <td width="301">&nbsp;</td>
                <td colspan="1">&nbsp;</td>
                <td colspan="1">&nbsp;</td>
                <td colspan="1">&nbsp;</td>
            </tr>

        </table>

    </asp:panel>
        <asp:Panel runat="server" ID="Panel8" Font-Names="Cambria" GroupingText="" Font-Size="Medium">

                <table width="810px">
<tr>
        
    <td colspan ="8" align="center">
        
        &nbsp;</td>
   

</tr>
                 
        </table>
        </asp:Panel>
         <asp:Panel runat="server" ID="Panel5" Font-Names="Cambria" GroupingText="Split Information" Font-Size="Medium">

                <table width="810px">
                    <tr>
                            <td colspan ="1" style="height: 18px">
                                <dx:ASPxLabel ID="ASPxLabel37" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Splitting WR" Theme="Glass">
                                </dx:ASPxLabel>
                            </td>
                        <td colspan ="7" style="height: 18px">
                            <dx:ASPxLabel ID="lblWRNo" runat="server" Font-Names="Cambria" Font-Size="Small" Theme="Glass">
                            </dx:ASPxLabel>
                            </td>

                    </tr>
                             <tr>
                                 <td colspan="1" style="height: 18px">
                                     <dx:ASPxLabel ID="ASPxLabel41" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Origianal Quantity" Theme="Glass">
                                     </dx:ASPxLabel>
                                 </td>
                                 <td colspan="7" style="height: 18px">
                                     <dx:ASPxLabel ID="lblOGQty" runat="server" Font-Names="Cambria" Font-Size="Small" Theme="Glass">
                                     </dx:ASPxLabel>
                                 </td>
                    </tr>
                    <tr>
                        <td colspan="1" style="height: 18px">&nbsp;</td>
                        <td colspan="7" style="height: 18px">&nbsp;</td>
                    </tr>

                     <tr>
                         <td colspan="1" style="height: 18px">&nbsp;</td>
                         <td colspan="7" style="height: 18px">
                             <asp:TextBox ID="TextBox1" runat="server" Height="82px" Width="409px"></asp:TextBox>
                         </td>
                    </tr>

                     <tr>

                            <td colspan ="1">
                                <strong>Add Splits</strong></td>
                        <td colspan ="1">
                            &nbsp;</td>
                        <td colspan ="1">
                            &nbsp;</td>
                        <td colspan ="2">&nbsp;</td>
                        <td colspan ="1">&nbsp;</td>
                        <td colspan ="1">&nbsp;</td>
                        <td colspan ="1">&nbsp;</td>
                    </tr>


                    <tr>

                            <td colspan ="1">
                                <dx:ASPxLabel ID="ASPxLabel5" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Split Quantity" Theme="Glass">
                                </dx:ASPxLabel>
                            </td>
                        <td colspan ="1">
                            <dx:ASPxTextBox ID="txtSplitQty" runat="server" BackColor="#E4E4E4" Height="19px" Theme="BlackGlass" Width="250px">
                            </dx:ASPxTextBox>
                            </td>
                        <td colspan ="1">
                            &nbsp;</td>
                        <td colspan ="2">&nbsp;</td>
                        <td colspan ="1">&nbsp;</td>
                        <td colspan ="1">&nbsp;</td>
                        <td colspan ="1">&nbsp;</td>
                    </tr>

                    <tr>

                            <td colspan ="1">
                                <dx:ASPxLabel ID="TransRef" runat="server" Font-Names="Cambria" Font-Size="Small" Theme="Glass" Visible="False">
                                </dx:ASPxLabel>
                            </td>
                        <td colspan ="1">
                            <dx:ASPxButton ID="ASPxButton16" runat="server" Text="Add(+)" Theme="BlackGlass" style="height: 23px">
                            </dx:ASPxButton>
                            </td>
                        <td colspan ="1">
                            &nbsp;</td>
                        <td colspan ="2">&nbsp;</td>
                        <td colspan ="1">&nbsp;</td>
                        <td colspan ="1">&nbsp;</td>
                        <td colspan ="1">&nbsp;</td>
                    </tr>


                    <tr>
                            <td colspan ="8">
                                <asp:GridView ID="grdSplits" runat="server" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="id" EmptyDataText="No Relevant Data Found" ForeColor="#333333" GridLines="None" Height="16px" Width="99%">
                                    <PagerSettings FirstPageText="First" LastPageText="Last" NextPageText="Next" PreviousPageText="Previous" />
                                    <AlternatingRowStyle CssClass="altrowstyle" BackColor="White" />
                                    <Columns>
                                         <asp:BoundField DataField="TransactionRef" HeaderText="Reference" HeaderStyle-HorizontalAlign="Left" />
                                         <asp:BoundField DataField="WRChildSuffix" HeaderText="Suffix" HeaderStyle-HorizontalAlign="Left" />
                                        <asp:BoundField DataField="ChildQTY" HeaderText="Split Quantity" HeaderStyle-HorizontalAlign="Left"/>                                  
                                        <asp:CommandField SelectText="Edit Entry" ShowSelectButton="true" HeaderStyle-HorizontalAlign="Left"/>
                                    </Columns>
                                    <EditRowStyle BackColor="#2461BF" />
                                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                    <HeaderStyle CssClass="headerstyle" BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                    <RowStyle CssClass="rowstyle" BackColor="#EFF3FB" />
                                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                    <SortedAscendingCellStyle BackColor="#F5F7FB" />
                                    <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                                    <SortedDescendingCellStyle BackColor="#E9EBEF" />
                                    <SortedDescendingHeaderStyle BackColor="#4870BE" />
                                </asp:GridView>
                            </td>

                    </tr>
                   
<tr>
        
    <td colspan ="2" align="center">
        <dx:ASPxLabel ID="lblOGQty2" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Split Total" Theme="Glass">
        </dx:ASPxLabel>
        <dx:ASPxLabel ID="lblSplitTotal" runat="server" Font-Names="Cambria" Font-Size="Small" Theme="Glass">
        </dx:ASPxLabel>
    </td>
   

    <td align="center" colspan="2">&nbsp;</td>
    <td align="center" colspan="4">&nbsp;&nbsp; &nbsp;</td>
   

</tr>
                 
                    <tr>
                        <td align="center" colspan="2">
                            <dx:ASPxLabel ID="lblOGQty3" runat="server" Font-Names="Cambria" Font-Size="Small" Text="WR Balance" Theme="Glass">
                            </dx:ASPxLabel>
                            <dx:ASPxLabel ID="lblWRBal" runat="server" Font-Names="Cambria" Font-Size="Small" Theme="Glass">
                            </dx:ASPxLabel>
                        </td>
                        <td align="center" colspan="2">&nbsp;</td>
                        <td align="center" colspan="4">&nbsp;</td>
                    </tr>


                        <tr>
                  
                   
                   
                    <td colspan="1">&nbsp;</td>
                    <td colspan="1">&nbsp;</td>
                    <td colspan="1">&nbsp;</td>
                    <td colspan="1">&nbsp;</td>
                </tr>
                       <tr>
                  
                   <td colspan="1">&nbsp;</td>
                    <td   align="center" colspan="1" style="width: 158px">
                        <dx:ASPxButton ID="ASPxButton12" runat="server" Text="Submit" Theme="BlackGlass">
                        </dx:ASPxButton>
                    </td>
                    
                    
                </tr>
                 
        </table>
        </asp:Panel>
               
        <asp:Panel ID="Panel9" runat="server" Enabled="True" Font-Names="Cambria" Font-Size="Medium" GroupingText="Finish">
            <table width="810px">


               

                  

              

             
                  <tr>
                    <td align="center">

                

                        <dx:ASPxGridView ID="ASPxGridView3" runat="server" AutoGenerateColumns="true"  KeyFieldName="ReceiptNo" Theme="Glass" Width="760px">
                      
                        <Columns >

                            
                            <dx:GridViewDataColumn HeaderStyle-Font-Bold="true" Caption="" CellStyle-HorizontalAlign="Right" Width="8PX" HeaderStyle-HorizontalAlign="Right">
                                    <DataItemTemplate>
                                       <dx:ASPxButton Height="18px" ID="btnAction" Value='<%# Eval("ReceiptNo") %>'  runat="server" AutoPostBack="False" ClientInstanceName="btnAction" Text="Approve" OnClick="btn_accept" >
                        </dx:ASPxButton>
                                    </DataItemTemplate>
                            </dx:GridViewDataColumn>
                           
                            <dx:GridViewDataColumn HeaderStyle-Font-Bold="true" Caption="" CellStyle-HorizontalAlign="Right" Width="8PX" HeaderStyle-HorizontalAlign="Right">
                                    <DataItemTemplate>
                                       <dx:ASPxButton Height="18px"   ID="btnAction" runat="server" AutoPostBack="False"  ClientInstanceName="btnAction" Text="Reject" OnClick="btn_reject"  >
                                            <ClientSideEvents Click="function(s,e){ e.processOnServer = confirm('Do you really want to Reject?');}" />  
                        </dx:ASPxButton>
                                    </DataItemTemplate>
                            </dx:GridViewDataColumn>
                           
                           
                            <dx:GridViewDataColumn HeaderStyle-Font-Bold="true" Caption="S.No" CellStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Right">
                                    <DataItemTemplate>
                                        <dx:ASPxLabel Text='<%# Eval("id") %>' runat="server"></dx:ASPxLabel>
                                    </DataItemTemplate>
                            </dx:GridViewDataColumn>
                                
                                <dx:GridViewDataColumn HeaderStyle-Font-Bold="true" Caption="EWR No.">
                                    <DataItemTemplate>
                                        <dx:ASPxLabel Text='<%# Eval("ReceiptNo") %>' runat="server"></dx:ASPxLabel>
                                    </DataItemTemplate>
                            </dx:GridViewDataColumn>
                            <dx:GridViewDataColumn HeaderStyle-Font-Bold="true" Caption="DepositorAcc#">
                                    <DataItemTemplate>
                                        <dx:ASPxLabel Text='<%# Eval("DepositorAcc") %>' runat="server"></dx:ASPxLabel>
                                    </DataItemTemplate>
                            </dx:GridViewDataColumn>
                                
                            <dx:GridViewDataColumn HeaderStyle-Font-Bold="true" Caption="DepositorName" CellStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Right">
                                    <DataItemTemplate>
                                        <dx:ASPxLabel Text='<%# Eval("DepositorName") %>' runat="server"></dx:ASPxLabel>
                                    </DataItemTemplate>
                            </dx:GridViewDataColumn>
                            <dx:GridViewDataColumn HeaderStyle-Font-Bold="true" Caption="Commodity">
                                    <DataItemTemplate>
                                        <dx:ASPxLabel Text='<%# Eval("Commodity") %>' runat="server"></dx:ASPxLabel>
                                    </DataItemTemplate>
                            </dx:GridViewDataColumn>
                           
                        
                            <dx:GridViewDataColumn HeaderStyle-Font-Bold="true" Caption="Quantity" CellStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Right">
                                    <DataItemTemplate>
                                        <dx:ASPxLabel Text='<%# Eval("Quantity") %>' runat="server"></dx:ASPxLabel>
                                    </DataItemTemplate>
                            </dx:GridViewDataColumn>

                               
                             <dx:GridViewDataColumn HeaderStyle-Font-Bold="true" Caption="Status" CellStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Right">
                                    <DataItemTemplate>
                                        <dx:ASPxLabel Text='<%# Eval("Status") %>' runat="server"></dx:ASPxLabel>
                                    </DataItemTemplate>
                            </dx:GridViewDataColumn>
                        </Columns>
                    </dx:ASPxGridView>
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
                 <tr>
                         <td align="center">


                        <dx:ASPxGridView ID="ASPxGridView1" runat="server" AutoGenerateColumns="true"  KeyFieldName="id" Theme="Glass" Width="760px">
                      
                        <Columns >


                           
                          <%--  <dx:GridViewDataColumn HeaderStyle-Font-Bold="true" Caption="S.No">
                                    <DataItemTemplate>
                                        <dx:ASPxLabel Text='<%# Eval("ID") %>' runat="server"></dx:ASPxLabel>
                                    </DataItemTemplate>
                            </dx:GridViewDataColumn>--%>
                            <dx:GridViewDataColumn HeaderStyle-Font-Bold="true" Caption="S.No" CellStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Right">
                                    <DataItemTemplate>
                                        <dx:ASPxLabel Text='<%# Eval("id") %>' runat="server"></dx:ASPxLabel>
                                    </DataItemTemplate>
                            </dx:GridViewDataColumn>
                                <dx:GridViewDataColumn HeaderStyle-Font-Bold="true" Caption="EWR No.">
                                    <DataItemTemplate>
                                        <dx:ASPxLabel Text='<%# Eval("ReceiptNo") %>' runat="server"></dx:ASPxLabel>
                                    </DataItemTemplate>
                            </dx:GridViewDataColumn>
                            <dx:GridViewDataColumn HeaderStyle-Font-Bold="true" Caption="DepositorAcc#">
                                    <DataItemTemplate>
                                        <dx:ASPxLabel Text='<%# Eval("DepositorAcc") %>' runat="server"></dx:ASPxLabel>
                                    </DataItemTemplate>
                            </dx:GridViewDataColumn>
                                
                            <dx:GridViewDataColumn HeaderStyle-Font-Bold="true" Caption="DepositorName" CellStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Right">
                                    <DataItemTemplate>
                                        <dx:ASPxLabel Text='<%# Eval("DepositorName") %>' runat="server"></dx:ASPxLabel>
                                    </DataItemTemplate>
                            </dx:GridViewDataColumn>
                            <dx:GridViewDataColumn HeaderStyle-Font-Bold="true" Caption="Commodity">
                                    <DataItemTemplate>
                                        <dx:ASPxLabel Text='<%# Eval("Commodity") %>' runat="server"></dx:ASPxLabel>
                                    </DataItemTemplate>
                            </dx:GridViewDataColumn>
                           
                        
                            <dx:GridViewDataColumn HeaderStyle-Font-Bold="true" Caption="Quantity" CellStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Right">
                                    <DataItemTemplate>
                                        <dx:ASPxLabel Text='<%# Eval("Quantity") %>' runat="server"></dx:ASPxLabel>
                                    </DataItemTemplate>
                            </dx:GridViewDataColumn>

                               
                             <dx:GridViewDataColumn HeaderStyle-Font-Bold="true" Caption="Status" CellStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Right">
                                    <DataItemTemplate>
                                        <dx:ASPxLabel Text='<%# Eval("Status") %>' runat="server"></dx:ASPxLabel>
                                    </DataItemTemplate>
                            </dx:GridViewDataColumn>
                        </Columns>
                    </dx:ASPxGridView>



<%--                         <asp:GridView ID="ASPxGridView3" runat="server" BackColor="White"  Settings-ShowTitlePanel="true" SettingsText-Title="Transfers"
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
                        <Columns>
                                <asp:BoundField DataField="id" Visible="false" HeaderText="ID" />
                                <asp:BoundField DataField="S.No" HeaderText="S.No" />
                                <asp:BoundField DataField="Transferor" HeaderText="Transferor" />
                              <asp:BoundField DataField="Transferee" HeaderText="Transferee" />
                             <asp:BoundField DataField="Quantity" HeaderText="Quantity" />
                              <asp:BoundField DataField="Commodity" HeaderText="Commodity" />
                               <asp:BoundField DataField="Grade" HeaderText="Grade" />
                            <asp:BoundField DataField="EWR No." HeaderText="EWR No." />

                             <asp:BoundField DataField="Status" HeaderText="Status" />
                              <asp:BoundField DataField="Trns. Date" HeaderText="Trns. Date" />
                              
                           
                           
                                                                                                                         <asp:TemplateField Visible="false"  HeaderText="id">
<ItemTemplate>
<asp:Label ID="id" runat="server" Text='<%# Bind("id") %>'></asp:Label>
</ItemTemplate>
</asp:TemplateField>
                       


                     
                            
                               <asp:CommandField ShowSelectButton="true" SelectText="Approve"  ControlStyle-Font-Bold="true"  />

                            
                            

                           
                                                    <asp:TemplateField >
                                                        <ItemTemplate>
                                                            <asp:ImageButton ID="LinkButton2" ToolTip="Reject" Font-Bold="True" AlternateText="Reject" CommandName="REJECT" runat="server" CommandArgument='<%#Eval("id")%>'/>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                            </Columns>
                             
                    </asp:GridView>--%>


 
                    </td>
                </tr>

            
               <%-- <tr>
                    <td >





                         <asp:GridView ID="ASPxGridView3" runat="server" BackColor="White"  Settings-ShowTitlePanel="true" SettingsText-Title="Transfers"
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
                        <Columns>
                                <asp:BoundField DataField="id" Visible="false" HeaderText="ID" />
                                <asp:BoundField DataField="S.No" HeaderText="S.No" />
                                <asp:BoundField DataField="Transferor" HeaderText="Transferor" />
                              <asp:BoundField DataField="Transferee" HeaderText="Transferee" />
                             <asp:BoundField DataField="Quantity" HeaderText="Quantity" />
                              <asp:BoundField DataField="Commodity" HeaderText="Commodity" />
                               <asp:BoundField DataField="Grade" HeaderText="Grade" />
                            <asp:BoundField DataField="EWR No." HeaderText="EWR No." />

                             <asp:BoundField DataField="Status" HeaderText="Status" />
                              <asp:BoundField DataField="Trns. Date" HeaderText="Trns. Date" />
                              
                           
                           
                                                                                                                         <asp:TemplateField Visible="false"  HeaderText="id">
<ItemTemplate>
<asp:Label ID="id" runat="server" Text='<%# Bind("id") %>'></asp:Label>
</ItemTemplate>
</asp:TemplateField>
                       


                     
                            
                               <asp:CommandField ShowSelectButton="true" SelectText="Approve"  ControlStyle-Font-Bold="true"  />

                            
                            

                           
                                                    <asp:TemplateField >
                                                        <ItemTemplate>
                                                            <asp:ImageButton ID="LinkButton2" ToolTip="Reject" Font-Bold="True" AlternateText="Reject" CommandName="REJECT" runat="server" CommandArgument='<%#Eval("id")%>'/>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                            </Columns>
                             
                    </asp:GridView>


 
                    </td>
                </tr>--%>
            </table>
           
                
                 
            
            <table  width="810px">
                 <tr runat="server" id="otptable" visible="false"> 
                        <td align="RIGHT" >
                            <dx:ASPxLabel ID="ASPxLabel4" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Please enter OTP here" Theme="Glass">
                            </dx:ASPxLabel>
                        </td>
                        <td>
                            <dx:ASPxTextBox ID="txtotp" runat="server" BackColor="#E4E4E4" Height="19px" Theme="BlackGlass" Width="250px">
                            </dx:ASPxTextBox>
                        </td>
                     
                     
                    </tr>

                   <tr  runat="server" id="otptable2" visible="false">
                       <td colspan="1">  &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp;&nbsp; </td>
                       

                        <td align="left" >
                            <dx:ASPxButton ID="btnotp" runat="server" Text="Confirm" Theme="BlackGlass">
                            </dx:ASPxButton>
                        </td>
                           <td colspan="1"></td>
                        <td colspan="1"></td>
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
                   <tr>
                        <td colspan="1">&nbsp;</td>
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
                   <tr>
                        <td colspan="1">&nbsp;</td>
                        <td colspan="1">&nbsp;</td>
                        <td colspan="1">&nbsp;</td>
                        <td colspan="1">&nbsp;</td>
                        <td colspan="1">&nbsp;</td>
                        <td colspan="1">&nbsp;</td>
                        <td colspan="1">&nbsp;</td>
                    </tr>
            </table>
               
        
        </asp:Panel>
               
</asp:Panel>
  
</div>
</asp:Content>

