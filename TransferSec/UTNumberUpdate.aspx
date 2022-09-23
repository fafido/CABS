<%@ Page Language="VB" MasterPageFile="~/CDSUser.master" AutoEventWireup="false" CodeFile="UTNumberUpdate.aspx.vb" Inherits="Enquiries_PortfolioDetailsEnquiry" title="Portfolio Details Enquiry" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<asp:Content id="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
    <asp:Panel id="Panel1" runat="server" Width="840px" Font-Names="Arial" Font-Size="Medium" BackColor="White">
    
        <table width ="810px">
            <tr>
                   <td style ="text-align :left;" align="left">
                       <dx:ASPxLabel ID="ASPxLabel1" runat="server" Text="UT Number&gt;&gt;Accounts Update" Font-Names="Cambria" Font-Size="Small" Theme="PlasticBlue"></dx:ASPxLabel>

                   </td>
            </tr>
        </table>

          <asp:panel id="Panel2" runat="server" GroupingText="Search Option" Font-Names="Cambria">


        <table width="810px">
            <tr>
                <td colspan ="1" align="right">
                    <dx:ASPxLabel ID="ASPxLabel3" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Fund" Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                <td colspan ="8" align ="center">
                    <dx:ASPxcombobox ID="cmbFund" autopostback="true"    runat="server" Theme="BlackGlass" Width="300px">
                    </dx:ASPxcombobox>
                </td>
                
                <td colspan ="1"></td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>

            </tr>

           
        </table>
               </asp:panel>
<asp:Panel   id="data" runat="server" visible="false" GroupingText="Accounts" Font-Names="Cambria">
      <table width="810px">
             <tr>
                
                                <td >

                                    <asp:GridView ID="grdvCharges" runat="server" AutoGenerateSelectButton="True" EmptyDataText="No Accounts!" CellPadding="4" ForeColor="#333333" GridLines="None" Height="72px" Width="800px" EmptyDataRowStyle-CssClass="text-warning text-center" >
                                       
                                        
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
                   
              
                   <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton  ID="lnkDiscard" runat="server" CommandArgument="<%# Bind('IDNumber') %>" OnClick=" getClientId">View  Id</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                                              </Columns>
                                         
                                    </asp:GridView>
                                </td>
                 
               

            </tr>
           
    
            </table>

    </asp:Panel>
        <asp:Panel runat="server" ID="Panel3" Font-Names="Cambria" GroupingText="Holder Basic Details">

                <table width="810px">
<tr>
        <td colspan ="1">
            <dx:ASPxLabel ID="ASPxLabel4" runat="server" Font-Names="Cambria" Font-Size="Small" Text="CDS No." Theme="Glass">
            </dx:ASPxLabel>
        </td>
    <td colspan ="1">
        <dx:ASPxTextBox ID="txtClientID" runat="server" Theme="BlackGlass" Width="250px" BackColor="#E4E4E4">
        </dx:ASPxTextBox>
        </td>
    <td colspan ="1">
        <dx:ASPxLabel ID="ASPxLabel5" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Identification No." Theme="Glass">
        </dx:ASPxLabel>
        </td>
    <td>
        <dx:ASPxTextBox ID="txtIdNo" runat="server" Theme="BlackGlass" Width="287px" BackColor="#E4E4E4" Height="19px">
        </dx:ASPxTextBox>
        </td>

</tr>
                    
                    <tr>
                            <td colspan ="1">
                                <dx:ASPxLabel ID="ASPxLabel8" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Account Name" Theme="Glass">
                                </dx:ASPxLabel>
                            </td>
                        <td colspan ="3">
                            <dx:ASPxTextBox ID="txtSurnames" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="710px">
                            </dx:ASPxTextBox>
                            </td>

                    </tr>
                    <tr>
                            <td colspan ="1">
                                <dx:ASPxLabel ID="ASPxLabel7" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Other Name" Theme="Glass">
                                </dx:ASPxLabel>
                            </td>
                        <td colspan ="3">
                            <dx:ASPxTextBox ID="txtForenames" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="710px">
                            </dx:ASPxTextBox>
                            </td>

                    </tr>
                    <tr>
                        <td colspan="1">
                            <dx:ASPxLabel ID="ASPxLabel27" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Mobile" Theme="Glass">
                            </dx:ASPxLabel>
                        </td>
                        <td colspan="3">
                            <dx:ASPxTextBox ID="txtmobile" runat="server" BackColor="#E4E4E4" Height="19px" Theme="BlackGlass" Width="287px">
                            </dx:ASPxTextBox>
                        </td>
                    </tr>
        </table>
        </asp:Panel>
        <asp:Panel runat="server" ID="Panel7" Font-Names="Cambria" GroupingText="Update Investor Pin" Font-Size="Medium">

                <table width="810px">
<tr>
    <td colspan="1">
                            <dx:ASPxLabel ID="ASPxLabel2" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Investor Pin" Theme="Glass">
                            </dx:ASPxLabel>
                        </td>
                        <td colspan="1">
                            <dx:ASPxTextBox ID="txtInvestorPin" runat="server" BackColor="#E4E4E4" Height="19px" Theme="BlackGlass" Width="250px">
                            </dx:ASPxTextBox>
                        </td>

        
    
   

</tr>
                     <tr>
                        <td align="center">
                            &nbsp;</td>
                    </tr>
                 
                    <tr>
                       
                           <td colspan ="6" align ="center">
                               <dx:ASPxButton ID="ASPxButton1" OnClick="ASPxButton1_Click" runat="server" Text="Update" Theme="BlackGlass"></dx:ASPxButton>

                           </td>
                    </tr>
                 
                   
                 
        </table>
        </asp:Panel>

         <asp:Panel runat="server" ID="Panel4" Font-Names="Cambria" GroupingText="Securities Category" Font-Size="Medium" Visible="False">

                <table width="810px">
<tr>
        
    <td align="center">
        &nbsp;</td>
   

</tr>
                 
                    <tr>
                        <td align="center">
                            &nbsp;</td>
                    </tr>
                 
        </table>
        </asp:Panel>
         
        <asp:Panel runat="server" ID="Panel6" Font-Names="Cambria" GroupingText="Movement Summaries" Font-Size="Medium" Visible="False">

                <table width="810px">
                    <tr>
                            <td colspan ="1">
                                <dx:ASPxLabel ID="ASPxLabel11" runat="server" Font-Names="Cambria" Font-Size="Small" Text="________________" Theme="Glass">
                                </dx:ASPxLabel>
                            </td>
                        <td colspan ="7"></td>

                    </tr>
                    <tr>
                            <td colspan ="1">
                                <dx:ASPxLabel ID="ASPxLabel12" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Company" Theme="Glass">
                                </dx:ASPxLabel>
                            </td>
                        <td colspan ="1">
                            <dx:ASPxComboBox ID="cmbCompany" runat="server" Theme="BlackGlass" ValueType="System.String" Width="250px">
                            </dx:ASPxComboBox>
                            </td>
                        <td colspan ="1">
                            <dx:ASPxLabel ID="ASPxLabel25" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Date From" Theme="Glass">
                            </dx:ASPxLabel>
                            </td>
                        <td colspan ="1">
                            <dx:ASPxDateEdit ID="txtBatchDate" runat="server" Theme="Aqua" Width="150px">
                            </dx:ASPxDateEdit>
                            </td>
                        <td colspan ="1">
                            <dx:ASPxLabel ID="ASPxLabel26" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Date To" Theme="Glass">
                            </dx:ASPxLabel>
                            </td>
                        <td colspan ="1">
                            <dx:ASPxDateEdit ID="txtBatchDate0" runat="server" Theme="Aqua" Width="150px">
                            </dx:ASPxDateEdit>
                            </td>
                        <td colspan ="1"></td>
                        <td colspan ="1"></td>

                    </tr>
                    <tr>
                           <td colspan ="8" align ="center">
                               <dx:ASPxButton ID="ASPxButton3" runat="server" Text="View" Theme="BlackGlass"></dx:ASPxButton>

                           </td>
                    </tr>
                    <tr>
                        <td colspan ="8" align="center">
                            <dx:ASPxGridView ID="rdMovements" runat="server" Theme="Aqua" Width="800px">
                            </dx:ASPxGridView>
                        </td>
                    </tr>
                    <tr>
                        <td colspan ="8" align="center">
                            <dx:ASPxButton ID="ASPxButton4" runat="server" Text="Print Statement" Theme="BlackGlass" style="height: 23px"></dx:ASPxButton>
                            
                        </td>

                    </tr>
                   
                 
        </table>
        </asp:Panel>
        
</asp:Panel>
  
</div>
</asp:Content>

