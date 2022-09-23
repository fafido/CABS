<%@ Page Language="VB" MasterPageFile="~/CDSUser.master" AutoEventWireup="false" CodeFile="BorrowersRequest.aspx.vb" Inherits="Depositor_BorrowersRequest" title="BorrowersRequest" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<%@ Register assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxTabControl" tagprefix="dx1" %>
<asp:Content id="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
    <asp:Panel id="Panel1" runat="server" Width="100%" Font-Names="Arial" Font-Size="Medium" BackColor="White">
    
        <table width ="100%">
            <tr>
                   <td style ="text-align :left;" align="left">
                       <dx:ASPxLabel ID="ASPxLabel1" runat="server" Text="Lending And Borrowing&gt;&gt;Borrowers Request" Font-Names="Cambria" Font-Size="Small" Theme="PlasticBlue"></dx:ASPxLabel>

                   </td>
            </tr>
        </table>
          <asp:panel id="Panel3" runat="server" Visible="false" GroupingText="Search" Font-Names="Cambria">
        <table width ="100%">
            <tr>
                    <td style="width:163px" colspan ="1">
                        <dx:ASPxLabel ID="ASPxLabel54" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Account No." Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                <td colspan ="1">
                    <table class="dxflInternalEditorTable_Glass">
                        <tr>
                            <td style="width: 224px">
                                <dx:ASPxTextBox ID="txtcds_number_search" runat="server" Theme="BlackGlass" Width="250px">
                                </dx:ASPxTextBox>
                            </td>
                            <td>
                                <dx:ASPxButton ID="ASPxButton6" runat="server" Text="&gt;&gt;" Theme="BlackGlass">
                                </dx:ASPxButton>
                            </td>
                        </tr>
                    </table>
                    </td>
                <td colspan ="1">
                    &nbsp;</td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>

            </tr>
            <tr>
                    <td colspan ="1">
                        <dx:ASPxLabel ID="ASPxLabel55" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Client Name" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                <td colspan ="1">
                    <table class="dxflInternalEditorTable_Glass">
                        <tr>
                            <td style="width: 221px">
                                <dx:ASPxTextBox ID="txtNameSearch" runat="server" Theme="BlackGlass" Width="250px">
                                </dx:ASPxTextBox>
                            </td>
                            <td>
                                <dx:ASPxButton ID="ASPxButton7" runat="server" Text="&gt;&gt;" Theme="BlackGlass">
                                </dx:ASPxButton>
                            </td>
                        </tr>
                    </table>
                    </td>
                <td colspan ="1">
                    &nbsp;</td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>

            </tr>
            <tr>
                    <td colspan ="1"></td>
                <td colspan ="7">
                    <dx:ASPxListBox ID="lstNameSearch" runat="server" ValueType="System.String" AutoPostBack="True" Theme="Glass" Width="710px"></dx:ASPxListBox>

                </td>

            </tr>
            <tr>
                    <td colspan ="1"></td>
                <td colspan ="7">
                    <dx:ASPxLabel ID="lblClientID" runat="server" Font-Names="Cambria" Font-Size="Small" Theme="Glass">
                    </dx:ASPxLabel>
                    </td>
            </tr>
        
        </table>

    </asp:panel>
        <asp:panel id="Panel8" runat="server" GroupingText="Personal Details" Font-Names="Cambria">
        <table width ="100%">
            <tr>
                <td style="width:163px" colspan ="1">
                    <dx:ASPxLabel ID="ASPxLabel25" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Account No." Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                <td colspan ="1" style="width: 426px">
                    <dx:ASPxTextBox ID="txtClientId" runat="server"  Theme="BlackGlass" Width="250px" enabled="false">
                    </dx:ASPxTextBox>
                </td>
                <td colspan ="1">
                    <dx:ASPxLabel ID="ASPxLabel30" runat="server" Font-Names="Cambria" Font-Size="Small" Text="CNIC No" Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                <td colspan ="1">
                    <dx:ASPxTextBox ID="txtIdno" runat="server"   enabled="false" Theme="BlackGlass" Width="250px">
                    </dx:ASPxTextBox>
                </td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>
                

            </tr>
           <tr>
               <td colspan ="1">
                   <dx:ASPxLabel ID="ASPxLabel26" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Account Name" Theme="Glass">
                   </dx:ASPxLabel>
               </td>
               <td colspan ="1" style="width: 426px">
                   <dx:ASPxTextBox ID="txtSurname" runat="server"  enabled="false" Theme="BlackGlass" Width="250px">
                   </dx:ASPxTextBox>
               </td>

               <td colspan="1">&nbsp;</td>
               <td colspan="1">&nbsp;</td>
               <td colspan="1">&nbsp;</td>
               <td colspan="1">&nbsp;</td>
               <td colspan="1">&nbsp;</td>
               <td colspan="1">&nbsp;</td>

           </tr>
            <tr>
                    <td colspan ="1">
                        <dx:ASPxLabel ID="ASPxLabel68" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Credit Limit" Theme="Glass" Visible="False">
                        </dx:ASPxLabel>
                    </td>
                <td colspan ="1" style="width: 426px">
                    <dx:ASPxTextBox ID="txtCreditLimit" runat="server"  Theme="BlackGlass" Width="250px" Visible="False">
                    </dx:ASPxTextBox>
                    </td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>

            </tr>
            

        </table>

    </asp:panel>
        <asp:panel id="Panel2" runat="server" GroupingText="Borrowing Request" Font-Names="Cambria">
        <table width ="100%">
            <tr>
                <td colspan ="1">
                    <dx:ASPxLabel ID="ASPxLabel2" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Collateral" Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                <td colspan ="1">
                    <dx:ASPxComboBox ID="cmbCompany" runat="server" Theme="BlackGlass" ValueType="System.String" Width="250px" AutoPostBack="True">
                    </dx:ASPxComboBox>
                </td>
                <td colspan ="1">
                    <dx:ASPxLabel ID="ASPxLabel69" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Available Quantity" Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                <td colspan ="1">
                    <dx:ASPxTextBox ID="txtavailableQuantity" runat="server"  Theme="BlackGlass" Width="250px" ReadOnly="True">
                    </dx:ASPxTextBox>
                </td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>
                

            </tr>
            <tr>
                    <td colspan ="1">
                        <dx:ASPxLabel ID="ASPxLabel70" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Effective Date" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                <td colspan ="1">
                    <dx:ASPxDateEdit ID="txtEffectiveDate" runat="server" Theme="Aqua" Width="250px">
                    </dx:ASPxDateEdit>
                    </td>
                <td colspan ="1">
                    <dx:ASPxLabel ID="ASPxLabel80" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Tenure" Theme="Glass">
                    </dx:ASPxLabel>
                    </td>
                <td colspan ="1">
                    <dx:ASPxComboBox ID="cmbtenure" runat="server" AutoPostBack="True" Theme="BlackGlass" Width="250px">
                       <%-- <Items>
                            <dx:ListEditItem Text="1 Month" Value="1" />
                            <dx:ListEditItem Text="2 Month" Value="2" />
                            <dx:ListEditItem Text="3 Month" Value="3" />
                            <dx:ListEditItem Text="4 Month" Value="" />
                            <dx:ListEditItem Text="5 Month" Value="1" />
                            <dx:ListEditItem Text="6 Month" Value="1" />
                            <dx:ListEditItem Text="7 Month" Value="1" />
                            <dx:ListEditItem Text="8 Month" Value="1" />
                            <dx:ListEditItem Text="9 Month" Value="1" />
                            <dx:ListEditItem Text="10 Month" Value="1" />
                            <dx:ListEditItem Text="11 Month" Value="1" />
                            <dx:ListEditItem Text="12 Month" Value="1" />

                            <dx:ListEditItem Text="13 Month" Value="1" />
                            <dx:ListEditItem Text="14 Month" Value="1" />
                            <dx:ListEditItem Text="15 Month" Value="1" />
                            <dx:ListEditItem Text="16 Month" Value="1" />
                            <dx:ListEditItem Text="17 Month" Value="1" />
                            <dx:ListEditItem Text="18 Month" Value="1" />
                            <dx:ListEditItem Text="19 Month" Value="1" />
                            <dx:ListEditItem Text="20 Month" Value="1" />
                            <dx:ListEditItem Text="21 Month" Value="1" />
                               <dx:ListEditItem Text="22 Month" Value="1" />
                               <dx:ListEditItem Text="23 Month" Value="1" />
                               <dx:ListEditItem Text="24 Month" Value="1" />
                               <dx:ListEditItem Text="25 Month" Value="1" />
                               <dx:ListEditItem Text="26 Month" Value="1" />
                               <dx:ListEditItem Text="27 Month" Value="1" />
                               <dx:ListEditItem Text="28 Month" Value="1" />
                               <dx:ListEditItem Text="29 Month" Value="1" />
                               <dx:ListEditItem Text="30 Month" Value="1" />
                               <dx:ListEditItem Text="31 Month" Value="1" />
                               <dx:ListEditItem Text="32 Month" Value="1" />
                               <dx:ListEditItem Text="33 Month" Value="1" />
                              <dx:ListEditItem Text="34 Month" Value="1" />
                              <dx:ListEditItem Text="35 Month" Value="1" />
                              <dx:ListEditItem Text="36 Month" Value="1" />
                        </Items>--%>
                    </dx:ASPxComboBox>
                    </td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>


            </tr>
             <tr>
                    <td colspan ="1">
                        <dx:ASPxLabel ID="ASPxLabel72" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Amount Required" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                <td colspan ="1">
                    <dx:ASPxTextBox ID="txtquantity" runat="server"  Theme="BlackGlass" Width="250px">
                    </dx:ASPxTextBox>
                    </td>
                <td colspan ="1">
                    <dx:ASPxLabel ID="ASPxLabel75" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Commodity Price" Theme="Glass">
                    </dx:ASPxLabel>
                    </td>
                <td colspan ="1">
                    <dx:ASPxTextBox ID="txtshareprice" runat="server"  Theme="BlackGlass" Width="250px" AutoPostBack="True" ReadOnly="True">
                    </dx:ASPxTextBox>
                    </td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>


            </tr>
            <tr>
                <td colspan="1">
                    <dx:ASPxLabel ID="ASPxLabel78" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Collateral Value" Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                <td colspan="1">
                    <dx:ASPxTextBox ID="txtcollateralvalue" runat="server"  Theme="BlackGlass" Width="250px" ReadOnly="True">
                    </dx:ASPxTextBox>
                </td>
                <td colspan="1">
                    <dx:ASPxLabel ID="ASPxLabel71" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Maturity Date" Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                <td colspan="1">
                    <dx:ASPxDateEdit ID="txtExpiryDate" runat="server" Theme="Aqua" Width="250px">
                    </dx:ASPxDateEdit>
                </td>
                <td colspan="1">&nbsp;</td>
                <td colspan="1">&nbsp;</td>
                <td colspan="1">&nbsp;</td>
                <td colspan="1">&nbsp;</td>
            </tr>
            <tr>
                <td colspan="7">
                    <dx:ASPxGridView ID="ASPxGridView2"  Settings-ShowTitlePanel="true" SettingsText-Title="Bank Terms" runat="server" Theme="Aqua" Width="100%">
                    </dx:ASPxGridView>
                </td>
                <td colspan="1">&nbsp;</td>
            </tr>
            <tr>
                <td align="center" colspan="8">
                    <dx:ASPxButton ID="ASPxButton8" runat="server" Text="Load Lenders" Theme="BlackGlass">
                    </dx:ASPxButton>
                </td>
            </tr>
            <tr>
                <td align="center" colspan="8">&nbsp;</td>
            </tr>
            <tr>
                <td align="center" colspan="8">
              
                    <dx:ASPxGridView ID="ASPxGridView1"  Settings-ShowTitlePanel="true" SettingsText-Title="Available Banks for my Loan Parameters" runat="server" Width="100%" Theme="Aqua">
                    </dx:ASPxGridView>
              
                </td>
            </tr>
            <tr>
                <td align="center" colspan="8">
                    <table class="dxflInternalEditorTable_Glass">
                        <tr>
                            <td align="left" style="width: 125px">
                                <dx:ASPxLabel ID="ASPxLabel79" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Preferred Financier" Theme="Glass">
                                </dx:ASPxLabel>
                            </td>
                            <td align="left">
                                <dx:ASPxComboBox ID="cmbfinancier" runat="server" AutoPostBack="True" Theme="BlackGlass" ValueType="System.String" Width="250px">
                                </dx:ASPxComboBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="2">
                                <dx:ASPxButton ID="ASPxButton9" runat="server" Text="Apply" Theme="BlackGlass">
                                </dx:ASPxButton>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
      </table>

    </asp:panel>
                <asp:panel id="Panel4" runat="server" GroupingText="Plegdes" Font-Names="Cambria" >
        <table width ="100%">
       <%--     <tr>
                 <td align="center">





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
                                <asp:BoundField DataField="Borrower" HeaderText="Borrower" />
                              <asp:BoundField DataField="Commodity" HeaderText="Commodity" />
                             <asp:BoundField DataField="Grade" HeaderText="Grade" />
                              <asp:BoundField DataField="Bank" HeaderText="Bank" />
                               <asp:BoundField DataField="Unit_Price" HeaderText="Unit_Price" />
                            <asp:BoundField DataField="Status" HeaderText="Status" />

                             <asp:BoundField DataField="CapturedDate" HeaderText="CapturedDate" />
                             
                              
                           
                                                                                             <asp:TemplateField Visible="false"  HeaderText="id">
<ItemTemplate>
<asp:Label ID="id" runat="server" Text='<%# Bind("id") %>'></asp:Label>
</ItemTemplate>
</asp:TemplateField>
                       


                     

                     
                            
                               <asp:CommandField ShowSelectButton="true" SelectText="Approve"  />

                            
                            

                           
                                                    <asp:TemplateField >
                                                        <ItemTemplate>
                                                            <asp:ImageButton ID="LinkButton2" ToolTip="Reject" AlternateText="Reject" CommandName="REJECT" runat="server" CommandArgument='<%#Eval("id")%>'/>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                            </Columns>
                             
                    </asp:GridView>


 
                    </td> 
            </tr>--%>

            <tr>
                <td align="center">


                        <dx:ASPxGridView ID="ASPxGridView3" runat="server" AutoGenerateColumns="true"  KeyFieldName="id" Theme="Glass" Width="740px">
                      
                        <Columns >

                        

                             <dx:GridViewDataColumn HeaderStyle-Font-Bold="true" Caption="" CellStyle-HorizontalAlign="Right" Width="8PX" HeaderStyle-HorizontalAlign="Right">
                                    <DataItemTemplate>
                                       <dx:ASPxButton Height="18px" ID="btnAction" Value='<%# Eval("id") %>'  runat="server" AutoPostBack="False" ClientInstanceName="btnAction" Text="Approve" OnClick="btn_accept" >
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
                                <dx:GridViewDataColumn HeaderStyle-Font-Bold="true" Caption="Commodity">
                                    <DataItemTemplate>
                                        <dx:ASPxLabel Text='<%# Eval("Commodity") %>' runat="server"></dx:ASPxLabel>
                                    </DataItemTemplate>
                            </dx:GridViewDataColumn>
                            <dx:GridViewDataColumn HeaderStyle-Font-Bold="true" Caption="Grade">
                                    <DataItemTemplate>
                                        <dx:ASPxLabel Text='<%# Eval("Grade") %>' runat="server"></dx:ASPxLabel>
                                    </DataItemTemplate>
                            </dx:GridViewDataColumn>
                                
                         
                           
                        
                            <dx:GridViewDataColumn HeaderStyle-Font-Bold="true" Caption="Bank" CellStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Right">
                                    <DataItemTemplate>
                                        <dx:ASPxLabel Text='<%# Eval("Bank") %>' runat="server"></dx:ASPxLabel>
                                    </DataItemTemplate>
                            </dx:GridViewDataColumn>

                               <dx:GridViewDataColumn HeaderStyle-Font-Bold="true" Caption="Status" CellStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Right">
                                    <DataItemTemplate>
                                        <dx:ASPxLabel Text='<%# Eval("Status") %>' runat="server"></dx:ASPxLabel>
                                    </DataItemTemplate>
                            </dx:GridViewDataColumn>
                         <%--    <dx:GridViewDataColumn HeaderStyle-Font-Bold="true" Caption="Status" CellStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Right">
                                    <DataItemTemplate>
                                        <dx:ASPxLabel Text='<%# Eval("Status") %>' runat="server"></dx:ASPxLabel>
                                    </DataItemTemplate>
                            </dx:GridViewDataColumn>--%>
                        </Columns>
                    </dx:ASPxGridView>





 
                    </td>
                </tr>
        
                    <tr>
                      
                        
                        
                        <td colspan="1">&nbsp;</td>
                        <td colspan="1">&nbsp;</td>
                        <td colspan="1">&nbsp;</td>
                        <td colspan="1">&nbsp;</td>
                    </tr>

                 <tr>

                <td align="center">


                        <dx:ASPxGridView ID="ASPxGridView4" runat="server" AutoGenerateColumns="true"  KeyFieldName="id" Theme="Glass" Width="740px">
                      
                        <Columns >

                        

                           
                           
                       
                                 

                            <dx:GridViewDataColumn HeaderStyle-Font-Bold="true" Caption="S.No" CellStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Right">
                                    <DataItemTemplate>
                                        <dx:ASPxLabel Text='<%# Eval("id") %>' runat="server"></dx:ASPxLabel>
                                    </DataItemTemplate>
                            </dx:GridViewDataColumn>
                                <dx:GridViewDataColumn HeaderStyle-Font-Bold="true" Caption="Commodity">
                                    <DataItemTemplate>
                                        <dx:ASPxLabel Text='<%# Eval("Commodity") %>' runat="server"></dx:ASPxLabel>
                                    </DataItemTemplate>
                            </dx:GridViewDataColumn>
                            <dx:GridViewDataColumn HeaderStyle-Font-Bold="true" Caption="Grade">
                                    <DataItemTemplate>
                                        <dx:ASPxLabel Text='<%# Eval("Grade") %>' runat="server"></dx:ASPxLabel>
                                    </DataItemTemplate>
                            </dx:GridViewDataColumn>
                                
                         
                           
                        
                            <dx:GridViewDataColumn HeaderStyle-Font-Bold="true" Caption="Bank" CellStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Right">
                                    <DataItemTemplate>
                                        <dx:ASPxLabel Text='<%# Eval("Bank") %>' runat="server"></dx:ASPxLabel>
                                    </DataItemTemplate>
                            </dx:GridViewDataColumn>

                               <dx:GridViewDataColumn HeaderStyle-Font-Bold="true" Caption="Status" CellStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Right">
                                    <DataItemTemplate>
                                        <dx:ASPxLabel Text='<%# Eval("Status") %>' runat="server"></dx:ASPxLabel>
                                    </DataItemTemplate>
                            </dx:GridViewDataColumn>
                         <%--    <dx:GridViewDataColumn HeaderStyle-Font-Bold="true" Caption="Status" CellStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Right">
                                    <DataItemTemplate>
                                        <dx:ASPxLabel Text='<%# Eval("Status") %>' runat="server"></dx:ASPxLabel>
                                    </DataItemTemplate>
                            </dx:GridViewDataColumn>--%>
                        </Columns>
                      
                    </dx:ASPxGridView>





 
                    </td>
                </tr>
               
        </table>
                     <table style="width:810px">
                 <tr runat="server" id="otptable" visible="false"> 
                        <td align="right" >
                            <dx:ASPxLabel ID="ASPxLabel11" runat="server" Font-Names="Cambria" Font-Size="Small" Text="OTP" Theme="Glass">
                            </dx:ASPxLabel>
                        </td>
                        <td >
                            <dx:ASPxTextBox ID="txtotp" runat="server" BackColor="#E4E4E4" Height="19px" Theme="BlackGlass" Width="250px">
                            </dx:ASPxTextBox>
                        </td>
                     
                     
                    </tr>

                   <tr  runat="server" id="otptable2" visible="false">
                       <td colspan="1"> &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp;
                      </td> 
                       

                        <td align="left" >
                            <dx:ASPxButton ID="btnotp" runat="server" Text="SEND OTP" Theme="BlackGlass">
                            </dx:ASPxButton>
                        </td>
                        <td></td>
                    </tr>
                                   <tr>
               
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
            </tr>
                         
                         <tr>
               
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
            </tr>
                         
                         <tr>
               
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
            </tr>

            </table>

    </asp:panel>



        <asp:panel id="Panel11" runat="server" GroupingText="Lending Pool" Font-Names="Cambria" Visible="False">
        <table width ="100%">
            <tr>
                    <td colspan ="2" align="left">
                        <dx:ASPxLabel ID="ASPxLabel66" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Lenders" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                <td align="center"></td>
                <td align="center">
                        &nbsp;</td>

            </tr>
            <tr>
                    <td valign="top"  colspan ="2" align="left">
                        <table class="dxflInternalEditorTable_Glass">
                            <tr>
                                <td style="width: 254px">
                                    <dx:ASPxListBox ID="lstLenders" runat="server" Height="175px" Theme="iOS" ValueType="System.String" Width="250px">
                                    </dx:ASPxListBox>
                                </td>
                                <td style="width: 98px">
                                    <dx:ASPxButton ID="ASPxButton5" runat="server" Height="23px" Text="Use Lender" Theme="BlackGlass" Width="86px">
                                    </dx:ASPxButton>
                                </td>
                                <td valign="top">
                                    &nbsp;</td>
                            </tr>
                        </table>
                    </td>
                <td align="center">
                    &nbsp;</td>
                <td align="center">
                        &nbsp;</td>

            </tr>
         
           <tr>
               <td colspan ="1">
                   <dx:ASPxLabel ID="ASPxLabel73" runat="server" Font-Names="Cambria" Font-Size="Medium" Text="Lender Details" Theme="Glass">
                   </dx:ASPxLabel>
               </td>
               <td colspan ="3">
                   &nbsp;</td>

           </tr>
             <tr>
               <td colspan ="1">
                   <asp:GridView ID="grdTranShareholder" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" DataKeyNames="id" EmptyDataText="No Relevant Data Found" ForeColor="Black" GridLines="Vertical" Height="16px" Width="99%">
                       <PagerSettings FirstPageText="First" LastPageText="Last" NextPageText="Next" PreviousPageText="Previous" />
                       <AlternatingRowStyle CssClass="altrowstyle" />
                       <Columns>
                           <asp:BoundField DataField="surname" HeaderText="Lender Account Name" />
                       <%--    <asp:BoundField DataField="forenames" HeaderText="Lender Forename" />--%>
                           <asp:BoundField DataField="Company" HeaderText="Company" />
                           <asp:BoundField DataField="Quantity" HeaderText="Quantity" />
                           <asp:BoundField DataField="Effectivedate" HeaderText="Effective Date" />
                           <asp:BoundField DataField="Expirydate" HeaderText="Expiry Date" />
                       </Columns>
                       <HeaderStyle BackColor="#424242" CssClass="headerstyle" ForeColor="White" />
                       <RowStyle CssClass="rowstyle" />
                   </asp:GridView>
                 </td>


                 <td colspan="3">&nbsp;</td>


           </tr>
               
            <tr>
                <td colspan="1">&nbsp;</td>
                <td colspan="3">&nbsp;</td>
            </tr>
            <tr>
                <td colspan="1">
                    <dx:ASPxLabel ID="ASPxLabel74" runat="server" Font-Names="Cambria" Font-Size="Medium" Text="Request Details" Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                <td colspan="3">&nbsp;</td>
            </tr>
            <tr>
                <td colspan="1">
                    <asp:GridView ID="grdTranShareholder0" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" DataKeyNames="id" EmptyDataText="No Relevant Data Found" ForeColor="Black" GridLines="Vertical" Height="16px" Width="99%">
                        <PagerSettings FirstPageText="First" LastPageText="Last" NextPageText="Next" PreviousPageText="Previous" />
                        <AlternatingRowStyle CssClass="altrowstyle" />
                        <Columns>
                            <asp:BoundField DataField="security" HeaderText="Security Type" />
                            <asp:BoundField DataField="interestrate" HeaderText="Interest Rate" />
                            <asp:BoundField DataField="servicecharges" HeaderText="Service Charge" />
                            <asp:BoundField DataField="lendingperiod" HeaderText="Period" />
                            <asp:BoundField DataField="miniamount" HeaderText="Min Amount" />
                            <asp:BoundField DataField="maxiamount" HeaderText="Max Amount" />
                          
                        </Columns>
                        <HeaderStyle BackColor="#424242" CssClass="headerstyle" ForeColor="White" />
                        <RowStyle CssClass="rowstyle" />
                    </asp:GridView>
                </td>
                <td colspan="3">&nbsp;</td>
            </tr>
            <tr>
                <td align="center" colspan="4">
                    <dx:ASPxButton ID="ASPxButton1" runat="server" style="height: 23px" Text="save" Theme="BlackGlass">
                    </dx:ASPxButton>
                    &nbsp;</td>
            </tr>
               
        </table>

    </asp:panel>
                 
</asp:Panel>
  
</div>
</asp:Content>

