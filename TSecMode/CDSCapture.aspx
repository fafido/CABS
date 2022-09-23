<%@ Page Language="VB" MasterPageFile="~/Tsec.master" AutoEventWireup="false" CodeFile="CDSCapture.aspx.vb" Inherits="TsecMode_CDSCapture" title="CDS Capture" %>
<asp:Content id="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
    <asp:Panel id="Panel1" runat="server" width="866px">
    
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
                        Text="CDS" width="855px" Height="19px"></asp:Label></td>
            </tr>
           
                
            </table>
            <table style="left: 0px; position: relative; top: 0px">
    <tr>
    <td align="center">
    <table style="left: 0px; position: relative; top: 0px; width: 654px;">
            
            <tr>
                <td >
                    <asp:Label id="Label2" runat="server" Text="Batch Ref" font-bold="True" font-names="Arial" font-size="Small"></asp:Label>
                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp;
                    <asp:DropDownList id="cmbbatchref" runat="server" width="200px" autopostback="True" TabIndex="1">
                    </asp:DropDownList></td>
               
            </tr>
            <tr>
                <td >
                    <asp:Label id="Label3" runat="server" Text="Company" font-bold="True" font-names="Arial" font-size="Small"></asp:Label>
                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp;<asp:Label id="lblcompany" runat="server"></asp:Label>&nbsp; &nbsp; 
                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp;<asp:Label id="Label1" runat="server" Text="XFer No" font-bold="True" font-names="Arial" font-size="Small"></asp:Label>&nbsp;&nbsp; 
                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                    <asp:Label id="lblXfer" runat="server"></asp:Label>
                    
                  </td>  
                    
                
            </tr>
            <tr>
                <td>
                    
                    <asp:Label id="Label5" runat="server" Text="Shares" font-bold="True" font-names="Arial" font-size="Small"></asp:Label>
                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp;<asp:Label id="lblShares" runat="server"></asp:Label>&nbsp; 
                    &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                    <asp:Label id="Label6" runat="server" Text="Date" font-bold="True" font-names="Arial" font-size="Small"></asp:Label>
                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;<asp:Label id="lblDate" runat="server"></asp:Label></td>
            </tr>
            <tr>
                <td>
                    <asp:Label id="Label7" runat="server" Text="Enter Certificate No:" font-bold="True" font-names="Arial" font-size="Small"></asp:Label>
                    &nbsp; &nbsp;
                    <asp:TextBox id="txtCertNo" runat="server" TabIndex="2"></asp:TextBox>&nbsp;<asp:Button id="btnAdd"
                        runat="server" Text="Add" backcolor="#E0E0E0" BorderColor="Black" TabIndex="3" /></td>
            </tr>
           
            <tr>
                <td>
                    <asp:GridView id="grdInsertCert" runat="server" AllowPaging="True" CellPadding="4" forecolor="#333333" GridLines="None" PageSize="2" TabIndex="4">
                        <PagerSettings FirstPageText="First" LastPageText="Last" Mode="NextPreviousFirstLast"
                            NextPageText="Next" PreviousPageText="Previous" />
                        <FooterStyle backcolor="#507CD1" font-bold="True" forecolor="White" />
                        <RowStyle backcolor="#EFF3FB" />
                        <EditRowStyle backcolor="#2461BF" />
                        <SelectedRowStyle backcolor="#D1DDF1" font-bold="True" forecolor="#333333" />
                        <PagerStyle backcolor="#2461BF" forecolor="White" HorizontalAlign="Center" />
                        <HeaderStyle backcolor="#507CD1" font-bold="True" forecolor="White" />
                        <AlternatingRowStyle backcolor="White" />
                        <Columns>
                            <asp:TemplateField HeaderText="Select">
                            <ItemTemplate>
                            <asp:CheckBox id="checkbox1" runat=server /> 
                            
                            </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
            
            <tr>
                <td style="height: 26px" >
                    <asp:Button id="btnValidate" runat="server" Text="Delete" backcolor="#E0E0E0" BorderColor="Black" TabIndex="5" /></td>
            </tr>
            <tr>
                <td>
                    <asp:RadioButton id="rdNormalCDS" runat="server" autopostback="True" 
                        Checked="True" GroupName="CDSAccs" Text="Main CDS Account" />
                    <asp:RadioButton id="rdSecCDSAcc" runat="server" autopostback="True" 
                        GroupName="CDSAccs" Text="Secondary CDS Account" />
                </td>
            </tr>
            <tr>
            <td>
                 <asp:Label id="Label8" runat="server" Text="CDS Nominee Ac" font-bold="True" 
                     font-names="Arial" font-size="Small"></asp:Label>
                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp;<asp:TextBox id="txtShareHolder" runat="server" TabIndex="6" Enabled="False"></asp:TextBox>&nbsp;
                    
            </td>
            </tr>
            
           
            <tr>
                <td >
                    <asp:Button id="btnTransaction" runat="server" Text="Process" backcolor="#E0E0E0" BorderColor="Black" TabIndex="9" />
                    <asp:Button id="Button1" runat="server" Text="Cancel" backcolor="#E0E0E0" BorderColor="Black" TabIndex="10" /></td>
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

