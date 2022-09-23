<%@ Page Language="VB" MasterPageFile="~/CDSUser.master" AutoEventWireup="false" CodeFile="EFTDebitResponseImport.aspx.vb" Inherits="CDSMode_EFTDebitResponseImport" title="Name Enquiry" %>
<%@ Register namespace="BasicFrame.WebControls" tagprefix="WebControls" %>
<asp:Content id="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
    <asp:Panel id="Panel1" runat="server">
    
<table style="border-right: #000033 thin solid; border-top: #000033 thin solid; border-left: #000033 thin solid; width: 832px; border-bottom: #000033 thin solid; background-color: #ffffff">
    <tr>
        <td style="width: 712px; height: 226px" valign="top">
            <table>
            <tr>
                <td style="width: 870px" align="center">
                    <asp:Label id="Label4" runat="server" backcolor="#8080FF" font-bold="True" font-names="Arial"
                        Text="Debit Response Import File" width="853px"></asp:Label></td>
            </tr>
                <tr>
                    <td colspan ="4" valign="top">
                        <asp:RadioButton id="rdSettlemts" runat="server" GroupName="filesop" 
                            Text="ATS Trades Import" autopostback="True" Visible="False" />
                        <asp:RadioButton id="rdSettlemts0" runat="server" GroupName="filesop" 
                            Text="Settlement Export" autopostback="True" Visible="False" />
                        <asp:RadioButton id="rdSettlemts1" runat="server" GroupName="filesop" 
                            Text="SFI Recon File" autopostback="True" Visible="False" />
                    </td>
                </tr>
                
            </table>
            <table>
   
            </table>
            <table>
            <tr>
                    <td style="width: 146px">
                        &nbsp;</td>
                    <td style="width: 219px">
                        &nbsp;</td>
                    
                    
                    <td style="width: 146px">
                        &nbsp;</td>
                    <td style="width: 219px">
                        <asp:DropDownList id="wk_comp" runat="server" TabIndex="1" Visible="False" 
                            width="205px">
                        </asp:DropDownList>
                    </td>
                    
                </tr>
                <tr>
                    <td style="width: 146px">
                        <asp:Label id="Label5" runat="server" font-names="Verdana" font-size="Small" 
                            Text="File" width="144px" Visible="False"></asp:Label>
                    </td>
                    <td style="width: 219px">
                        <input id="fDocument" runat="server" onclick="return fDocument_onclick()" 
                            type="file" visible="False" /><asp:TextBox id="txtSettlementExport" runat="server" 
                            Visible="False"></asp:TextBox></td>
                    
                    
                    <td style="width: 146px">
                        <asp:Label id="wk_path" runat="server" font-bold="True" Visible="False"></asp:Label>
                    </td>
                    <td style="width: 219px">
                        &nbsp;</td>
                    
                </tr>
                <tr>

                        <td></td>
                    <td>
                        <asp:FileUpload ID="FileUpload1" runat="server" />
                        </td>
                    <td>
                        <asp:TextBox ID="txtFileLocation" runat="server" Visible="False"></asp:TextBox>
                        </td>
                    <td></td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <asp:TextBox id="TextBox1" runat="server" Height="16px" Visible="False" 
                            width="201px"></asp:TextBox>
                    </td>
                    <td></td>
                    <td></td>
                </tr>
                <tr>
                        <td>
                            <asp:Label ID="Label1" runat="server" Text="Date" Visible="False"></asp:Label>
                        </td>
                    <td>
                        <asp:TextBox ID="TextBox2" runat="server" Visible="False"></asp:TextBox>
                        </td>
                    <td></td>
                    <td></td>

                </tr>
                <tr>
                    <td style="height: 18px"></td>
                    <td style="height: 18px">
                        <asp:Label id="wk_status" runat="server" font-bold="True" font-names="Arial" 
                            font-size="Large" forecolor="ActiveCaption"></asp:Label>
                        <asp:Label ID="lbl_ErrorMsg" runat="server" font-bold="True" font-names="Arial" font-size="Large" forecolor="ActiveCaption"></asp:Label>
                    </td>
                    <td style="height: 18px"></td>
                    <td style="height: 18px"></td>
                </tr>
                <tr>
                    <td>
                        &nbsp;</td>
                    <td align="center" style="width: 219px">
                        <asp:Button id="Button1" runat="server" Text="Transmit" Visible="False" />
                        <asp:Button ID="Button2" runat="server" Text="Transmit" />
                        <asp:Button ID="Button3" runat="server" Text="OrdersRepostTest" Visible="False" />
                    </td>
                    <td>
                        &nbsp;</td>
                    <td align="center" style="width: 219px">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td></td>
                    <td style="width: 219px">
                        
                        <asp:GridView ID="gv_gridview" runat="server" Visible="False">
                        </asp:GridView>
                        
                        </td>
                </tr>
                <tr>
                    <td></td>
                    <td colspan ="2">
                        <asp:GridView id="grdUploadStats" runat="server" CellPadding="4" 
                            forecolor="#333333" GridLines="None" width="599px">
                            <FooterStyle backcolor="#507CD1" font-bold="True" forecolor="White" />
                            <RowStyle backcolor="#EFF3FB" font-names="Arial" font-size="Small" 
                                HorizontalAlign="Left" />
                            <PagerStyle backcolor="#2461BF" forecolor="White" HorizontalAlign="Center" />
                            <SelectedRowStyle backcolor="#D1DDF1" font-bold="True" forecolor="#333333" />
                            <HeaderStyle backcolor="#507CD1" font-bold="True" forecolor="White" 
                                HorizontalAlign="Left" />
                            <EditRowStyle backcolor="#2461BF" />
                            <AlternatingRowStyle backcolor="White" />
                        </asp:GridView>
                    </td>
                </tr>
            </table>
            
            <table>
                <tr>
                    <td colspan ="4" style="width: 850px" align="center">
                        &nbsp;</td>                
                </tr>
            </table>
        </td>
    </tr>
</table>
</asp:Panel>
</div>
</asp:Content>

