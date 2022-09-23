<%@ Page Language="VB" MasterPageFile="~/CDSUser.master" AutoEventWireup="false" CodeFile="Callables.aspx.vb" Inherits="Parameters_BillingPara" title="Call Backs" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<%@ Register Assembly="BasicFrame.WebControls.BasicDatePicker" Namespace="BasicFrame.WebControls"
    TagPrefix="BDP" %>

<asp:Content id="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
    <asp:Panel id="Panel1" runat="server" Width="840px" Font-Names="Arial" Font-Size="Medium" BackColor="White">
    
        <table width ="810px">
            <tr>
                   <td style ="text-align :left;" align="left">
                       <dx:ASPxLabel ID="ASPxLabel1" runat="server" Text="Callables&gt;&gt; Billing" Font-Names="Cambria" Font-Size="Small" Theme="PlasticBlue"></dx:ASPxLabel>

                   </td>
            </tr>
        </table>

          <asp:panel id="Panel2" runat="server" GroupingText="Call Backs" Font-Names="Cambria">
        <table style="width: 826px">
             
            
            
            
            <asp:Panel runat="server" id="mainproduct">
             <tr>
                <td align="left" style="height: 14px; width: 206px;">
                    <dx:ASPxLabel ID="ASPxLabel2" runat="server" Font-Names="Cambria" Font-Size="Small" style="font-weight: 700" Text="Period From" Theme="Glass">
                    </dx:ASPxLabel>
                 </td>

                 <td align="left" colspan="1" style="height: 14px; width: 264px;">
                      <BDP:BasicDatePicker ID="txtPeriodFrom" runat="server" ReadOnly="false" Width="250px">
                        </BDP:BasicDatePicker>
                 </td>
                <td colspan ="1" style="height: 14px; width: 73px;">
                    </td>
                <td colspan ="1" style="height: 14px">
                    </td>
                <td colspan ="1" style="height: 14px; width: 367px;">
                    </td>
                <td colspan ="1" style="height: 14px"></td>

            </tr>
                 <tr>
                <td align="left" style="height: 14px; width: 206px;">
                    <dx:ASPxLabel ID="ASPxLabel4" runat="server" Font-Names="Cambria" Font-Size="Small" style="font-weight: 700" Text="Period To" Theme="Glass">
                    </dx:ASPxLabel>
                 </td>
         <dx:ASPxTextBox ID="txtId" visible="false" runat="server" BackColor="#E4E4E4" Height="18px" Theme="BlackGlass" Width="269px">
                     </dx:ASPxTextBox>
                     <dx:ASPxTextBox ID="txtbatchnumber" visible="false" runat="server" BackColor="#E4E4E4" Height="18px" Theme="BlackGlass" Width="269px">
                     </dx:ASPxTextBox>
                     <dx:ASPxTextBox ID="txtcounter" visible="false" runat="server" BackColor="#E4E4E4" Height="18px" Theme="BlackGlass" Width="269px">
                     </dx:ASPxTextBox>
                     <dx:ASPxTextBox ID="txtinstrument" visible="false" runat="server" BackColor="#E4E4E4" Height="18px" Theme="BlackGlass" Width="269px">
                     </dx:ASPxTextBox>
                       <dx:ASPxTextBox ID="txtInterest" visible="false" runat="server" BackColor="#E4E4E4" Height="18px" Theme="BlackGlass" Width="269px">
                     </dx:ASPxTextBox>
                     <dx:ASPxTextBox ID="txtIssueDate" visible="false" runat="server" BackColor="#E4E4E4" Height="18px" Theme="BlackGlass" Width="269px">
                     </dx:ASPxTextBox>
                 <td align="left" colspan="1" style="height: 14px; width: 264px;">
                      <BDP:BasicDatePicker ID="txtPeriodTo" runat="server" ReadOnly="false" Width="250px">
                        </BDP:BasicDatePicker>
                 </td>
                <td colspan ="1" style="height: 14px; width: 73px;">
                    </td>
                <td colspan ="1" style="height: 14px">
                    </td>
                <td colspan ="1" style="height: 14px; width: 367px;">
                    </td>
                <td colspan ="1" style="height: 14px"></td>

            </tr>
                  <tr>
                <td align="right" style="height: 17px; width: 206px;">
                    &nbsp;</td>
                    <td align="left" colspan="1" style="height: 17px; width: 264px;">
                        <dx:ASPxButton ID="ASPxButton1" OnClick="ASPxButton1_Click" runat="server" Text="View" Theme="BlackGlass">
                        </dx:ASPxButton>
                    </td>
                <td colspan ="1" style="height: 17px; width: 73px;">
                    &nbsp;</td>
                <td colspan ="1" style="height: 17px">
                    &nbsp;</td>
                <td colspan ="1" style="height: 17px; width: 367px;">
                    &nbsp;</td>
                <td colspan ="1" style="height: 17px"></td>

            </tr>
               
           
      
           

             
             
             
            


           
           
             
           
          
            
            
   
               
                <tr>
                <td align="right" style="width: 206px">
                    &nbsp;</td>
                    <td align="right" colspan="1" style="width: 264px">&nbsp;</td>
                <td colspan ="1" style="width: 73px">
                    &nbsp;</td>
                <td colspan ="1">
                    &nbsp;</td>
                <td colspan ="1" style="width: 367px">
                    &nbsp;</td>
                <td colspan ="1"></td>

            </tr>
                            <tr>
                <td align="right" style="width: 206px; height: 170px;">
                                </td>
                                <td valign="top" align="left" colspan="4" style="height: 170px;">
                                    <asp:GridView ID="grdvCharges" AutoGenerateSelectButton="True" runat="server" AllowPaging="True" CellPadding="4" CssClass="table table-bordered table-striped tablestyle success" EmptyDataRowStyle-CssClass="text-warning text-center" EmptyDataText="No Accounts Pending Creation!" ForeColor="#333333" GridLines="None" HorizontalAlign="Left">
                <AlternatingRowStyle BackColor="White" CssClass="altrowstyle" />
                <EditRowStyle BackColor="#2461BF" />
                <EmptyDataRowStyle CssClass="text-warning text-center" />
                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#507CD1" CssClass="header info" Font-Bold="True" ForeColor="White" />
                <RowStyle BackColor="#EFF3FB" CssClass="rowstyle" />
                <PagerStyle BackColor="#2461BF" CssClass="pagination-ys" ForeColor="White" HorizontalAlign="Center" />
                
                
                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#F5F7FB" />
                <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                <SortedDescendingCellStyle BackColor="#E9EBEF" />
                <SortedDescendingHeaderStyle BackColor="#4870BE" />
                                 
            </asp:GridView>
                                </td>
                <td colspan ="1" style="height: 170px"></td>

            </tr>
                 </asp:Panel>
                  
        </table>

    </asp:panel>
  
        <!--Settlement-->
       
        <asp:Panel runat="server" visible="false" ID="Panel10" Font-Names="Cambria" GroupingText="Call Back Date" Font-Size="Medium">

                <table width="810px">
<tr>
                <td align="left" style="height: 14px; width: 206px;">
                    <dx:ASPxLabel ID="ASPxLabel3" runat="server" Font-Names="Cambria" Font-Size="Small" style="font-weight: 700" Text="Enter Call Back Date" Theme="Glass">
                    </dx:ASPxLabel>
                 </td>

                 <td align="left" colspan="1" style="height: 14px; width: 264px;">
                      <BDP:BasicDatePicker ID="txtCallBackDate" runat="server" ReadOnly="false" Width="250px">
                        </BDP:BasicDatePicker>
                 </td>
                <td colspan ="1" style="height: 14px; width: 73px;">
                    </td>
                <td colspan ="1" style="height: 14px">
                    </td>
                <td colspan ="1" style="height: 14px; width: 367px;">
                    </td>
                <td colspan ="1" style="height: 14px"></td>

            </tr>
                    <tr>
    <td colspan="1" style="height: 18px">
            <dx:ASPxLabel ID="ASPxLabel12" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Issuer" Theme="Glass">
            </dx:ASPxLabel>
            </td>
    <td colspan="1" style="height: 18px">
        <dx:ASPxcombobox ID="cmbCounter" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="250px">
        </dx:ASPxcombobox>
    </td>
    <td colspan="1" style="height: 18px"></td>
    <td colspan="1" style="height: 18px"></td>
    <td colspan="1" style="height: 18px"></td>
    <td colspan="1" style="height: 18px"></td>
    <td colspan="1" style="height: 18px"></td>
     </tr>
                     <tr>
                <td align="right" style="height: 17px; width: 206px;">
                    &nbsp;</td>
                    <td align="left" colspan="1" style="height: 17px; width: 264px;">
                        <dx:ASPxButton ID="ASPxButton2" OnClick="ASPxButton2_Click" runat="server" Text="Save" Theme="BlackGlass">
                        </dx:ASPxButton>
                    </td>
                <td colspan ="1" style="height: 17px; width: 73px;">
                    &nbsp;</td>
                <td colspan ="1" style="height: 17px">
                    &nbsp;</td>
                <td colspan ="1" style="height: 17px; width: 367px;">
                    &nbsp;</td>
                <td colspan ="1" style="height: 17px"></td>

            </tr>
                 
        </table>
        </asp:Panel>
        
</asp:Panel>
  
</div>
</asp:Content>

