<%@ Page Language="VB" MasterPageFile="~/Tsec.master" AutoEventWireup="false" CodeFile="ChangeChequeNo.aspx.vb" Inherits="TsecMode_ChangeChequeNo" title="Batches" %>
<asp:Content id="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
    <asp:Panel id="Panel1" runat="server" width="871px">
    
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
                        Text="Cheque Posting" width="846px" Height="19px"></asp:Label></td>
            </tr>
           
                
            </table>
            <table style="left: 0px; position: relative; top: 0px">
    <tr>
    <td align="center">
    <table id="TABLE1" onclick="return TABLE1_onclick()" >
             
            <tr><td style="height: 27px" align="left">
                  <asp:Label id="Label11" runat="server" font-bold="True" font-names="Arial" font-size="Small"
                        Text="Company"></asp:Label>
                       </td>
                       <td style="height: 27px" align="left">
                          <asp:DropDownList id="cmbCompany" runat="server"  
                       autopostback="True" width="205px" TabIndex="1">
                    </asp:DropDownList>
                    </td></tr >
            <tr>
                    <td align="left">
                        <asp:Label id="lblDividendNo" runat="server" font-bold="True" font-names="Arial"
                            font-size="Small" Text="Dividend no"></asp:Label></td>
                    <td align="left">
                        <asp:DropDownList id="cmbDivno" runat="server" width="205px" autopostback="True">
                        </asp:DropDownList></td>
                    </tr>
            <tr>
                <td  align="left">
                    <asp:Label id="Label2" runat="server" font-bold="True" font-names="Arial" font-size="Small"
                        Text="Event" width="96px" Visible="False"></asp:Label>
                        </td>
                        <td style="width: 306px" align="left">
                    <asp:DropDownList id="cmbEvent" runat="server" autopostback="True"  width="205px" 
                                TabIndex="1" Visible="False">
                    </asp:DropDownList>
                            </td>
            </tr>
            <tr>
                <td align="left">
                    
                    <asp:Label id="Label3" runat="server"  Text="Cheque No" font-bold="True" font-names="Arial" font-size="Small"></asp:Label>
                    </td>
                        <td style="width: 306px" align="left">
                    <asp:TextBox id="txtChequeNo" runat="server"  width="200px" TabIndex="2"></asp:TextBox>&nbsp;
                            <asp:Button id="SerchByCheq" runat="server" Text=">>" /></td>
            </tr>
            <tr>
                <td align="left">
                    
                    <asp:Label id="Label14" runat="server"  Text="Shareholder No" font-bold="True" font-names="Arial" font-size="Small"></asp:Label>
                    </td>
                        <td style="width: 306px" align="left" >
                    <asp:TextBox id="txtShareholderSearch" runat="server"  width="200px" TabIndex="2"></asp:TextBox>
                            &nbsp;
                            <asp:Button id="BtnShareholderSearch" runat="server" Text=">>" /></td>
            </tr>
            
            <tr>
                <td  align="left">
                  
                    <asp:Label id="Label1" runat="server" Text="Amount" font-bold="True" font-names="Arial" font-size="Small"></asp:Label>
                    </td>
                        <td style="width: 306px" align="left">
                    <asp:TextBox id="txtAmount" runat="server"  width="200px" TabIndex="3" Enabled="False"></asp:TextBox>
                            &nbsp;
                </td>
            </tr>
            <tr>
                <td align="left" >
                    
                   
                    <asp:Label id="Label5" runat="server" Text="Status" font-bold="True" font-names="Arial" font-size="Small"></asp:Label>
                   
                </td>
                <td style="width: 306px" align="left">
                  <asp:TextBox id="cmbStatus" runat="server" width="200px" Enabled="False"></asp:TextBox></td>
            </tr>
        
                    <tr>
                    <td align="left">
                    
                    
                    <asp:Label id="Label7" runat="server"  Text="Payee" font-bold="True" font-names="Arial" font-size="Small"></asp:Label>
                    
                    
                    
                    
                </td>
                <td style="width: 306px" align="left">
                <asp:TextBox id="txtPayee" runat="server"  width="200px" TabIndex="8" Enabled="False"></asp:TextBox>
                </td>
            </tr>
            <tr>
                    <td align="left">
                    
                    
                    <asp:Label id="Label12" runat="server"  Text="Shareholder" font-bold="True" font-names="Arial" font-size="Small"></asp:Label>
                    
                    
                    
                    
                </td>
                <td style="width: 306px" align="left">
                <asp:TextBox id="Shareholder" runat="server"  width="200px" TabIndex="8" Enabled="False"></asp:TextBox>
                </td>
            </tr>
             <tr>
            <td align="left">
            <asp:Label id="Label8" runat="server" Text="Type" font-bold="True" font-names="Arial" font-size="Small"></asp:Label>
            </td>
            <td style="width: 306px" align="left">
            <asp:TextBox id="txtType" runat="server" width="200px" MaxLength="1" TabIndex="9" Enabled="False"></asp:TextBox>
            </td>
            </tr>
            <tr>
            <td align="left">
                <asp:Label id="Label10" runat="server" font-bold="True" font-names="Arial" font-size="Small"
                    Text="Action Date"></asp:Label></td>
            <td align="left">
                <asp:TextBox id="txtActionDate" runat="server" Enabled="False"></asp:TextBox></td>
            </tr>
             <tr>
                <td align="left">
                    <asp:Label id="Label6" runat="server" Text="Date"  font-bold="True" font-names="Arial" font-size="Small"></asp:Label></td>
                <td  align="left">
                   
                    <asp:TextBox id="dtpDate" runat="server" width="150px" ReadOnly="True" TabIndex="5"></asp:TextBox>
                    <asp:Button id="Button3" runat="server" Text="V" CausesValidation="False" TabIndex="6"  />
                    </td>
                    </tr>
                    <tr>
                    <td ></td>
                    <td colspan ="2" >
                    
                     <asp:Calendar id="Calendar1" runat="server" backcolor="White" BorderColor="#3366CC"
                        BorderWidth="1px" CellPadding="1" DayNameFormat="Shortest" font-names="Verdana"
                        font-size="8pt" forecolor="#003399" Height="100px" width="155px" Visible="False" TabIndex="7">
                        <SelectedDayStyle backcolor="#009999" font-bold="True" forecolor="#CCFF99" />
                        <TodayDayStyle backcolor="#99CCCC" forecolor="White" />
                        <SelectorStyle backcolor="#99CCCC" forecolor="#336666" />
                        <WeekendDayStyle backcolor="#CCCCFF" />
                        <OtherMonthDayStyle forecolor="#999999" />
                        <NextPrevStyle font-size="8pt" forecolor="#CCCCFF" />
                        <DayHeaderStyle backcolor="#99CCCC" forecolor="#336666" Height="1px" />
                        <TitleStyle backcolor="#003399" BorderColor="#3366CC" BorderWidth="1px" font-bold="True"
                            font-size="10pt" forecolor="#CCCCFF" Height="25px" />
                    </asp:Calendar>
                   </td>
               
            </tr>
           
            <tr>
            <td>
            <asp:Label id="Label9" runat="server" Text="New Cheque Number" font-bold="True" font-names="Arial" font-size="Small" Visible="False"></asp:Label>
            </td>
            <td style="width: 306px" align="left">
                &nbsp;<asp:TextBox id="txtNewChequeNumber" runat="server" width="200px" Visible="False"></asp:TextBox></td>
            </tr>
            <tr>
            <td>
            <asp:Label id="Label13" runat="server" Text="Mandates Present ?" font-bold="True" font-names="Arial" font-size="Small" Visible="False"></asp:Label>
            </td>
            <td style="width: 306px">
                &nbsp;<asp:CheckBox id="mandate" runat="server" font-bold="True" Text="mandated" autopostback="True" />
                <asp:CheckBox id="nonmandate" runat="server" font-bold="True" Text="non mandated" autopostback="True" /></td>
            </tr>
            <tr>
                <td class="style3">
            <asp:Label id="Label15" runat="server" Text="Account Status" font-bold="True" 
                        font-names="Arial" font-size="Small" Visible="False"></asp:Label>
                </td>
                <td class="style3">
            <asp:Label id="lblAccstat" runat="server" font-bold="True" font-names="Arial" 
                        font-size="Small" Visible="False"></asp:Label>
                </td>
            </tr>
            <tr>
                <td></td>
                <td>
                    <asp:CheckBox id="chkActivate" runat="server" autopostback="True" 
                        font-bold="True" font-names="Arial" font-size="Small" Text="Activate Account" />
                </td>
            </tr>
            <tr>
                <td  bgcolor="slategray" colspan="2" align="center" style="border-top-color: black; height: 30px">
                   
                    <asp:Button id="btnUpdate" runat="server"  Text="Update" width="104px" backcolor="#E0E0E0" BorderColor="Black" TabIndex="10" />
                   
                    
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

