<%@ Page Language="VB" MasterPageFile="~/Tsec.master" AutoEventWireup="false" CodeFile="Indemnities.aspx.vb" Inherits="TsecMode_Indemnities" title="Batches" %>
<asp:Content id="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
    <asp:Panel id="Panel1" runat="server" width="870px">
    
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
                        Text="Indemnities" width="853px" Height="19px"></asp:Label></td>
            </tr>
           
                
            </table>
            <table style="left: 0px; position: relative; top: 0px">
    <tr>
    <td align="center">
    <table>
            
            <tr>
                <td style="height: 24px; width: 120px;" >
                    <asp:Label id="Label2" runat="server" font-bold="True" font-names="Arial" font-size="Small"
                        Text="Batch Ref"
                        ></asp:Label>
                        </td>
                        <td style="height: 24px">
                    <asp:DropDownList id="cmbBatchref" runat="server" autopostback="True" width="200px" TabIndex="1" >
                    </asp:DropDownList>
                   </td>
                   </tr>
                   <tr>
                   <td style="height: 21px; width: 120px;">
                   <asp:Label id="Label13" runat="server" font-bold="True" font-names="Arial" font-size="Small"
                         Text="Company"></asp:Label>
                   
                   </td>
                   <td style="height: 21px">
                   <asp:Label id="lblCompany" runat="server" font-bold="True" font-names="Arial" font-size="Small"
                        ></asp:Label>
                     
                   </td>
                   </tr>
                   <tr>
                   <td style="width: 120px">
                   <asp:Label id="Label7" runat="server" font-bold="True" font-names="Arial" font-size="Small"
                        Text="Shares"></asp:Label>
                   </td>
                   <td>
                   <asp:Label id="lblShares" runat="server" font-bold="True" font-names="Arial" font-size="Small"
                       ></asp:Label>
                   </td>
            </tr>
            <tr>
                <td style="width: 120px">
                    
                    <asp:Label id="Label3" runat="server" font-bold="True" font-names="Arial" font-size="Small"
                        Text="Old Cert No"
                       ></asp:Label>
                       </td>
                       <td>
                    <asp:TextBox id="txtOldCert" runat="server" width="200px" TabIndex="2" ></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="2" align="center">                    
                    <asp:Button id="btnAdd" runat="server" backcolor="#E0E0E0" BorderColor="Black"
                         Text="Add" TabIndex="3" />
                    <asp:Button id="btnChange" runat="server" backcolor="#E0E0E0" BorderColor="Black"
                         Text="Process" TabIndex="3" />
                    <asp:Button id="btnDelete" runat="server" backcolor="#E0E0E0" BorderColor="Black"
                         Text="Delete" TabIndex="3" /></td>
            </tr>
            <tr>
            <td colspan ="2">
                <asp:GridView id="grdCert" runat="server" CellPadding="4" forecolor="#333333" GridLines="None">
                <Columns>
                <asp:TemplateField >
                <ItemTemplate>
                <asp:CheckBox id="checkbox1" runat ="server" />
                
                </ItemTemplate> 
                
                
                </asp:TemplateField>
                
                </Columns>
                    <FooterStyle backcolor="#507CD1" font-bold="True" forecolor="White" />
                    <RowStyle backcolor="#EFF3FB" />
                    <EditRowStyle backcolor="#2461BF" />
                    <SelectedRowStyle backcolor="#D1DDF1" font-bold="True" forecolor="#333333" />
                    <PagerStyle backcolor="#2461BF" forecolor="White" HorizontalAlign="Center" />
                    <HeaderStyle backcolor="#507CD1" font-bold="True" forecolor="White" />
                    <AlternatingRowStyle backcolor="White" />
                </asp:GridView>
            
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

