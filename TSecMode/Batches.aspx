<%@ Page Language="VB" MasterPageFile="~/Tsec.master" AutoEventWireup="false" CodeFile="Batches.aspx.vb" Inherits="TsecMode_Batches" title="Batches" %>
<asp:Content id="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
    <asp:Panel id="Panel1" runat="server" width="857px">
    
<table style="border-right: #000033 thin solid; border-top: #000033 thin solid; border-left: #000033 thin solid; width: 832px; border-bottom: #000033 thin solid; background-color: #ffffff">
    <tr>
        <td style="width: 634px; height: 226px" valign="top">
            <table>
            <tr>
                <td>
                    <asp:Label id="lblsitemap" runat="server"></asp:Label></td>
            </tr>
            <tr>
                <td style="width: 870px" align="center">
                    <asp:Label id="Label4" runat="server" backcolor="#8080FF" font-bold="True" font-names="Arial"
                        Text="Batches" width="838px" Height="19px"></asp:Label></td>
            </tr>
           
                
            </table>
            <table style="left: 0px; position: relative; top: 0px">
    <tr>
    <td align="center">
    <table>
            <tr>
                <td style="border-bottom-color: black; width: 93px; height: 43px;
                    border-bottom-style: solid" colspan ="4">
                    <asp:Label id="Lbl1" runat="server" font-bold="True" font-names="Arial" font-size="Large"
                        Style="z-index: 100; top: 16px" Text="BATCH"
                        width="104px"></asp:Label>
                </td>
            </tr>
            <tr>
                <td >
                <asp:Label id="Label10" runat="server" font-bold="True" font-names="Arial" font-size="Small"
                         Text="Batch Types"></asp:Label>
                          
                            
                   </td>
                   <td>
                          <asp:DropDownList id="cmbBatchType" runat="server" 
                        width="206px" autopostback="True" TabIndex="1">
                    </asp:DropDownList>
                
                    
                  
                    
                 
                   
                  </td>
                  <td></td>
                  <td></td>
            </tr>
            <tr>
            <td>
            <asp:Label id="Label2" runat="server" font-bold="True" font-names="Arial" font-size="Small"
                         Text="Batch Ref"
                        width="144px"></asp:Label>
                       
                        </td>
                        <td>
                          <asp:DropDownList id="cmbBatchref" runat="server" autopostback="True"
                         width="208px" TabIndex="2">
                    </asp:DropDownList>
                    </td>
                    <td>
                    
                  
                     <asp:Label id="Label13" runat="server" font-bold="True" font-names="Arial" font-size="Small"
                        Text="Company"></asp:Label>
                  
                        </td>
                        <td align="left">
                         <asp:Label id="lblCompany" runat="server" font-bold="True" font-names="Arial" font-size="Small"
                        ></asp:Label>
                        
                        
            </td>
            </tr>
            <tr>
                <td >
                    <asp:Label id="Label3" runat="server" font-bold="True" font-names="Arial" font-size="Small" Text="Share"></asp:Label>
                    </td>
                    <td>
                    <asp:TextBox id="txtShare" runat="server"
                         width="200px" Enabled="False" TabIndex="3"></asp:TextBox>
                         </td>
                         <td>
                        
                          <asp:Label id="Label1" runat="server" font-bold="True" font-names="Arial" font-size="Small"
                         Text="Date" width="88px"></asp:Label>
                         </td>
                         <td>
                         
                    <asp:TextBox id="txtDate" runat="server" width="200px" Enabled="False" TabIndex="4"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td >
                        <asp:Label id="Label5" runat="server" font-bold="True" font-names="Arial" font-size="Small"
            Text="Shareholder" width="96px"></asp:Label>
             </td>
             <td colspan ="3">
                    <asp:TextBox id="txtshareholder" runat="server"  width="200px" TabIndex="5"></asp:TextBox>
                  
                    <asp:Button id="Button1" runat="server" backcolor="#E0E0E0" BorderColor="Black"
                        CausesValidation="False" Text="Add" TabIndex="6" />
                    </td>
            </tr>
           
            <tr>
                <td >
                    
                    <asp:Label id="Label8" runat="server" font-bold="True" font-names="Arial" font-size="Small"
                     Text="Total Shares"></asp:Label>
                     </td>
     <td>
                    <asp:TextBox id="txtTotalShare" runat="server" width="200px" TabIndex="11"></asp:TextBox>
                  
            
                    <asp:RequiredFieldValidator id="RequiredFieldValidator3" runat="server" ControlToValidate="txtTotalShare"
                        ErrorMessage="Total Share?" 
                         width="80px"></asp:RequiredFieldValidator>
                  </td>
                  <td>
                    <asp:Label id="Label9" runat="server" Visible="False" ></asp:Label></td>
                  <td></td>
            </tr>
            <tr>
                <td  colspan ="4">
                 <asp:Button id="btnDelete" runat="server" font-bold="True"   backcolor="#E0E0E0" BorderColor="Black" Text="Delete the selected " CausesValidation="False" TabIndex="12" />
                    &nbsp;&nbsp;&nbsp;&nbsp;
                  <asp:Button id="btnAdd" runat="server" backcolor="#E0E0E0" BorderColor="Black"
                        font-bold="True"  Text="Add"
                        width="80px" TabIndex="13" />
                        &nbsp;&nbsp;
                    <asp:Button id="btnCancel" runat="server" backcolor="#E0E0E0" BorderColor="Black"
                        font-bold="True"  Text="Cancel"
                        width="80px" CausesValidation="False" TabIndex="14" />
                        &nbsp;&nbsp;
                          <asp:Button id="btnAllocate" runat="server" backcolor="#E0E0E0" font-bold="True" font-names="Arial"
                        font-size="Small" Height="24px"  Text="Process" width="80px" BorderColor="Black" CausesValidation="False" TabIndex="15" />
                        &nbsp;&nbsp;
                        <asp:Button id="btnNew" runat="server" backcolor="#E0E0E0" font-bold="True" font-names="Arial"
                        font-size="Small" Height="24px"  Text="New Shareholder" CausesValidation="False" BorderColor="Black" TabIndex="16" />
                </td>
            </tr>
        </table>
    </td>
    </tr>
    <tr>
    <td>
    <br />
    </td>
    </tr>
    <tr>
    <td>
    <asp:GridView id="grdbonus" runat="server"  AllowPaging="True"  PageSize="5" TabIndex="17">
            <PagerSettings FirstPageText="First" LastPageText="Last"
                NextPageText="Next" Position="TopAndBottom" PreviousPageText="Previous" Mode="NextPreviousFirstLast" />
            <FooterStyle backcolor="#507CD1" font-bold="True" forecolor="White" />
            <RowStyle backcolor="#EFF3FB" />
            <EditRowStyle backcolor="#2461BF" />
            <SelectedRowStyle backcolor="#D1DDF1" font-bold="True" forecolor="#333333" />
            <PagerStyle backcolor="#2461BF" forecolor="White" HorizontalAlign="Center" />
            <HeaderStyle backcolor="#507CD1" font-bold="True" forecolor="White" />
            <AlternatingRowStyle backcolor="White" />
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:CheckBox id="CheckBox1" runat="server" Style="position: relative" />
                    </ItemTemplate>
                </asp:TemplateField>
               
            </Columns>
        </asp:GridView>
    </td>
    </tr>
    <tr>
    <td>
        &nbsp;<asp:DetailsView id="grdshareholderdetail" runat="server" Height="50px" CellPadding="4" forecolor="#333333" GridLines="None">
            <FooterStyle backcolor="#5D7B9D" font-bold="True" forecolor="White" />
            <CommandRowStyle backcolor="#E2DED6" font-bold="True" />
            <EditRowStyle backcolor="#999999" />
            <RowStyle backcolor="#F7F6F3" forecolor="#333333" />
            <PagerStyle backcolor="#284775" forecolor="White" HorizontalAlign="Center" />
            <FieldHeaderStyle backcolor="#E9ECF1" font-bold="True" />
            <HeaderStyle backcolor="#5D7B9D" font-bold="True" forecolor="White" />
            <AlternatingRowStyle backcolor="White" forecolor="#284775" />
        </asp:DetailsView>
    </td>
    </tr>
    <tr>
    <td>
        &nbsp;</td>
    </tr>
    </table>
        </td>
    </tr>
</table>
</asp:Panel>
</div>
</asp:Content>

