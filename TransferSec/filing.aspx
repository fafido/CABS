<%@ Page Language="VB"  MasterPageFile="~/CDSUser.master" AutoEventWireup="false" CodeFile="filing.aspx.vb" Inherits="Administration_AccountCreation" title="Sanctioned People" %>

<%@ Register Assembly="BasicFrame.WebControls.BasicDatePicker" Namespace="BasicFrame.WebControls"
    TagPrefix="BDP" %>
<asp:Content id="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    

    
   
<table style="border-right: #000033 thin solid; border-top: #000033 thin solid; border-left: #000033 thin solid; width: 832px; border-bottom: #000033 thin solid; background-color: #ffffff">
    <tr>
        <td style="width: 712px; height: 226px" valign="top">
            <table>
            <tr>
                <td style="width: 870px" align="center">
                    <asp:Label id="Label4" runat="server" backcolor="#8080FF" font-bold="True" font-names="Arial"
                        text=" Custodial Filing" width="848px"></asp:Label></td>
            </tr>
                
                
            </table>
            <table>
                <tr>
                     <td colspan ="1" style="width: 172px">
                                <asp:Label id="Label2" runat="server" text="Description" font-names="Verdana" font-size="Small"></asp:Label></td>
                        <td colspan ="1" style="width: 316px">
                            <asp:textbox id="txtDescription" runat="server"></asp:textbox>

                            </td>
                            <td>
                                </td>
                                <td>
                                    </td>
                                    <td style="width: 141px">
                                        </td>
                </tr>
            </table>
            <table>
                <tr>
                     <td colspan ="1" style="width: 172px">
                                <asp:Label id="Label3" runat="server" text="Company/Client" font-names="Verdana" font-size="Small"></asp:Label></td>
                        <td colspan ="1" style="width: 316px">
                            <asp:textbox id="txtFor" runat="server"></asp:textbox>

                            </td>
                            <td>
                                </td>
                                <td>
                                    </td>
                                    <td style="width: 141px">
                                        </td>
                </tr>
            </table>
          

            
                
            
            <table>
                 
                
         <tr>
                    <td colspan ="1" style="width: 172px">
                                <asp:Label id="Label10" runat="server" text="Uploads" font-names="Verdana" font-size="Small"></asp:Label></td>
                                <td colspan ="1" style="width: 316px">
                                   
                                    <asp:fileupload runat="server" id="FileUpload1"></asp:fileupload>
                                    <br />
                                    
                                    
                                    
                                     <asp:Button id="Button1" runat="server" text="upload" width="96px" /></td>   
                </tr>

            </table>

            
            
      
    

      <table>
                <tr>
                    <td colspan ="4" style="width: 850px" align="center">
                <asp:GridView ID="grdApps" runat="server" AllowPaging="True" CellPadding="4" CssClass="table table-bordered table-striped tablestyle success" EmptyDataRowStyle-CssClass="text-warning text-center" EmptyDataText="No Accounts Pending Creation!" ForeColor="#333333" GridLines="None" HorizontalAlign="Left">
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
                    <Columns>
                  <asp:TemplateField HeaderText="Download" HeaderStyle-Width="7%">
                  <ItemTemplate>
                      <asp:LinkButton ID="lnkDownload" Text="Download" CommandArgument='<%# Eval("location") %>' runat="server" OnClick="DownloadFile"></asp:LinkButton>
                  </ItemTemplate>
              </asp:TemplateField>
                        </Columns>
            </asp:GridView>
                      </td>           
                </tr> 
            </table>
                 <table>
         <tr>
                    <td colspan ="1" style="width: 172px">
                                <asp:Label id="Label1" runat="server" text="From Physical Scanner" font-names="Verdana" font-size="Small"></asp:Label></td>
                                <td colspan ="1" style="width: 316px">
                                   
                                   
                                    
                                    
                                     <asp:Button id="Button2" runat="server" text="Scan" width="96px" /></td>   
                </tr>
            </table>
    
    
            
           
    


</asp:Content>

