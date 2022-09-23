<%@ Page Language="VB" MasterPageFile="~/CDSUser.master" AutoEventWireup="false" CodeFile="CustodianBatchReceipt.aspx.vb" Inherits="Custodian_CustodianBatchReceipt" title="Batch Receipting" %>

<%@ Register Assembly="BasicFrame.WebControls.BasicDatePicker" Namespace="BasicFrame.WebControls"
    TagPrefix="BDP" %>
<asp:Content id="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div>
    <asp:Panel id="Panel1" runat="server">
    
<table style="border-right: #000033 thin solid; border-top: #000033 thin solid; border-left: #000033 thin solid; width: 832px; border-bottom: #000033 thin solid; background-color: #ffffff">
    <tr>
        <td style="width: 712px; height: 226px" valign="top">
            <table>
            <tr>
                <td style="width: 870px" align="center" colspan="2">
                    <asp:Label id="Label4" runat="server" backcolor="#8080FF" font-bold="True" font-names="Arial"
                        Text="Batch Receipting" width="872px"></asp:Label></td>
            </tr>
            <tr>
                <td colspan="1" style="width: 15px; height: 11px;">
                    <asp:Label id="Label7" runat="server" Text="Search Batch" font-names="Verdana" font-size="Small" width="96px"></asp:Label></td> 
                            <td colspan ="1" style="width: 473px; height: 11px;">
                                <asp:TextBox id="txtSearch" runat="server"></asp:TextBox>
                                <asp:Button id="btnBatchSearch" runat="server" Text=">>" /></td>                   
            </tr>
            <tr>
                <td colspan="1" style="width: 15px; height: 11px;">
                    <asp:Label id="Label3" runat="server" Text="Company" font-names="Verdana" font-size="Small"></asp:Label></td> 
                            <td colspan ="1" style="width: 473px; height: 11px;">
                                <asp:DropDownList id="cmbParaCompany" runat="server" width="176px">
                                </asp:DropDownList></td>                   
            </tr>
            <tr>
                <td colspan="1" style="width: 15px">
                    <asp:Label id="Label1" runat="server" Text="Batch Type" font-names="Verdana" font-size="Small" width="80px"></asp:Label></td> 
                            <td colspan ="1" style="width: 473px">
                                <asp:DropDownList id="CmbBatchType" runat="server" width="176px" 
                                    autopostback="True">
                                </asp:DropDownList></td>                   
            </tr>
            
            <tr>
                <td colspan="1" style="width: 15px">
                    <asp:Label id="Label11" runat="server" Text="Batching Date" font-names="Verdana" font-size="Small" width="96px"></asp:Label></td> 
                            <td colspan ="1" style="width: 473px">
                                <BDP:BasicDatePicker id="BasicDatePicker1" runat="server" ReadOnly="True">
                                </BDP:BasicDatePicker>
                            </td>                   
            </tr>
                <tr>
                <td colspan="1" style="width: 15px">
                    <asp:Label id="Label12" runat="server" Text="Batch Shares" font-names="Verdana" font-size="Small" width="88px"></asp:Label></td> 
                            <td colspan ="1" style="width: 473px">
                                <asp:TextBox id="txtBatchShares" runat="server"></asp:TextBox></td>                   
            </tr>
            <tr>
                <td colspan="1" style="width: 15px">
                    <asp:Label id="Label6" runat="server" font-names="Verdana" font-size="Small" Text="Batch Ref"
                        width="88px"></asp:Label></td> 
                            <td colspan ="1" style="width: 473px">
                                &nbsp;<asp:Label id="lblbatchref" runat="server" font-bold="True" font-names="Arial"
                                    width="152px"></asp:Label></td>                   
            </tr>
            <tr>
                <td colspan="1" style="width: 15px">
                    <asp:Label id="Label15" runat="server" Text="Options" font-names="Verdana" font-size="Small" width="80px"></asp:Label></td> 
                            <td colspan ="1" style="width: 473px">
                                <asp:Button id="btnSave" runat="server" Text="Save Batch" />&nbsp;<asp:Button id="BtnUpdate"
                                    runat="server" Text="Update Batch" Enabled="False" />&nbsp;<asp:Button id="BtnPrint" runat="server"
                                        Text="Print Batch Receipt" /></td>                   
            </tr>
            <tr>
                <td style="width: 15px">
                    <asp:Label id="Label2" runat="server" font-names="Arial" font-size="Small" Text="Shareholder Number"></asp:Label></td> 
                            <td colspan ="1" style="width: 473px">
                                <asp:TextBox id="txtShareholderSearch" runat="server"></asp:TextBox>
                                <asp:Button id="btnNumberSearch" runat="server" Text=">>" /></td>                                                   
                                
            </tr>
            <tr>
                <td colspan="1" style="width: 15px">
                    <asp:Label id="Label5" runat="server" font-names="Arial" font-size="Small" Text="Shareholder Name" width="88px"></asp:Label></td> 
                            <td colspan ="1" style="width: 473px">
                                <asp:TextBox id="txtShareholderName" runat="server"></asp:TextBox>
                                <asp:Button id="btnNameSearch1" runat="server" Text=">>" /></td>                                                   
                                
            </tr>
            <tr>
                <td colspan="1" style="width: 15px">
                    </td> 
                            <td colspan ="1" style="width: 473px">
                                <asp:ListBox id="lstName" runat="server" width="328px" autopostback="True"></asp:ListBox></td>                                                   
                                
            </tr>
            <tr>
                <td colspan="1" style="width: 15px">
                    </td> 
                            <td colspan ="1" style="width: 473px">
                                <asp:Button id="btnSelect" runat="server" Text="Select" /></td>                                                   
                                
            </tr>
            <tr>
                <td colspan="1" style="width: 15px">
                    </td> 
                            <td colspan ="1" style="width: 473px">
                                <asp:Label id="lblSelctedNames" runat="server"></asp:Label>
                                <asp:Label id="LblShareholder" runat="server"></asp:Label></td>                                                   
                                
            </tr>
            </table>
            <center>
            <table>
                <tr>
                    <td colspan="0.5" style="width: 221px; border-right: #cccccc thin solid; border-top: #cccccc thin solid; border-left: #cccccc thin solid; border-bottom: #cccccc thin solid; height: 9px;"><asp:Label id="Label14" runat="server" Text="Certificate" font-names="Verdana" font-size="Small" width="112px"></asp:Label></td>
                    <td colspan = "0.5" style="width: 312px; border-right: #cccccc thin solid; border-top: #cccccc thin solid; border-left: #cccccc thin solid; border-bottom: #cccccc thin solid; height: 9px;"><asp:TextBox id="txtCert" runat="server"></asp:TextBox>
                        </td>
                        <td style="width: 221px; border-right: #cccccc thin solid; border-top: #cccccc thin solid; border-left: #cccccc thin solid; border-bottom: #cccccc thin solid; height: 9px;"><asp:TextBox id="txtCd" runat="server" width="32px"></asp:TextBox></td>
                        <td style="width: 221px; border-right: #cccccc thin solid; border-top: #cccccc thin solid; border-left: #cccccc thin solid; border-bottom: #cccccc thin solid; height: 9px;">
                            <asp:Label id="Label8" runat="server" Text="Old Holder Number" font-names="Arial" font-size="Small" width="136px"></asp:Label></td>
                        <td style="width: 162px; border-right: #cccccc thin solid; border-top: #cccccc thin solid; border-left: #cccccc thin solid; border-bottom: #cccccc thin solid; height: 9px;">
                            <asp:TextBox id="txtShareholder" runat="server"></asp:TextBox></td>
                    <td style="width: 267px; border-right: #cccccc thin solid; border-top: #cccccc thin solid; border-left: #cccccc thin solid; border-bottom: #cccccc thin solid; height: 9px;">
                    <asp:Label id="Label17" runat="server" Text="Shares" font-names="Verdana" font-size="Small" width="80px"></asp:Label></td>
                    <td style="width: 424px; border-right: #cccccc thin solid; border-top: #cccccc thin solid; border-left: #cccccc thin solid; border-bottom: #cccccc thin solid; height: 9px;">
                        <asp:TextBox id="txtShares" runat="server"></asp:TextBox>
                        </td>
                        <td><asp:Button id="btnAddCerts" runat="server" Text=">>" /></td>
                </tr>
                
                
            </table>
            <table>
                <tr align="center">
                    <td style="width: 425px">
                        <asp:GridView id="grdAddedCertificate" runat="server" forecolor="#333333" CellPadding="4" GridLines="None" font-names="Arial" font-size="Small" width="704px">
                        <FooterStyle backcolor="#507CD1" font-bold="True" forecolor="White"  />
                        
                        <Columns>
                            <asp:TemplateField HeaderText="SELECT">
                            <ItemTemplate >
                            
                            <asp:CheckBox id="checkbox1" runat ="server"  />
                            
                            </ItemTemplate>
                            
                            </asp:TemplateField>
                        </Columns>
                        <RowStyle backcolor="#EFF3FB"  />
                        <EditRowStyle backcolor="White" font-names="Arial" font-size="Small"  />
                        <SelectedRowStyle backcolor="White" font-bold="True" forecolor="#333333"  />
                        <PagerStyle backcolor="#2461BF" forecolor="White" HorizontalAlign="Center"  />
                        <HeaderStyle backcolor="#507CD1" font-bold="True" forecolor="White"  />
                        <AlternatingRowStyle backcolor="White" font-names="Arial" font-size="Small"  />
                    </asp:GridView>
                    </td>
                </tr>
            </table>
           </center>
            <table style="width: 792px">
                <tr align="center">
                    <td style="width: 146px" align="center">
                        <table>
                            <tr align="center">                                                             
                                <td style="width: 276px; border-right: #cccccc thin solid; border-top: #cccccc thin solid; border-left: #cccccc thin solid; border-bottom: #cccccc thin solid;">
                                    <asp:Button id="BtnDelCert" runat="server" Text="Delete Cert" /></td>
                                <td style="width: 280px; border-right: #cccccc thin solid; border-top: #cccccc thin solid; border-left: #cccccc thin solid; border-bottom: #cccccc thin solid;">
                                    <asp:Button id="BtnPrintBatchReport" runat="server" Text="Print Batch Summary" /></td>
                                </tr>
                            <tr>
                                <td></td>
                                <td>
                                    <asp:Label id="Label18" runat="server" Text="Transfer Shares To"></asp:Label>
                                </td>
                                <td></td>
                            </tr>
                              <tr>
                <td style="width: 15px" align="left">
                    <asp:Label id="Label19" runat="server" font-names="Arial" font-size="Small" 
                        Text="Shareholder Number" width="169px"></asp:Label>
                                  </td> 
                            <td colspan ="1" style="width: 473px" align="left">
                                <asp:TextBox id="txtTransferee" runat="server"></asp:TextBox>
                                <asp:Button id="Button3" runat="server" Text=">>" /></td>                                                   
                                
            </tr>
                              <tr>
                            
                <td colspan="1" style="width: 15px" align="left">
                    <asp:Label id="Label9" runat="server" font-names="Arial" font-size="Small" 
                        Text="Shareholder Name" width="169px"></asp:Label></td> 
                            <td colspan ="1" style="width: 473px" align="left">
                                <asp:TextBox id="txtTransfereeName" runat="server"></asp:TextBox>
                                <asp:Button id="Button1" runat="server" Text=">>" /></td>                                                   
                                
            </tr>
            <tr>
                <td colspan="1" style="width: 15px">
                    </td> 
                            <td colspan ="1" style="width: 473px">
                                <asp:ListBox id="lstTransferee" runat="server" width="328px" 
                                    autopostback="True"></asp:ListBox></td>                                                   
                                
            </tr>
            <tr>
                <td colspan="1" style="width: 15px">
                    </td> 
                            <td colspan ="1" style="width: 473px">
                                &nbsp;</td>                                                   
                                
            </tr>
            <tr>
                <td colspan="1" style="width: 15px">
                    </td> 
                            <td colspan ="1" style="width: 473px">
                                <asp:Label id="lblTransfereeName" runat="server"></asp:Label>
                                <asp:Label id="lblTransfereeNum" runat="server"></asp:Label></td>                                                   
                                
            </tr>
            <tr>
                <td align="left">
                    <asp:Label id="Label20" runat="server" font-names="Arial" font-size="Small" 
                        Text="Shares to Transfer" width="169px"></asp:Label>
                </td>
                <td align="left">
                    <asp:TextBox id="txtTransferShares" runat="server"></asp:TextBox><asp:Button id="Button4"
                        runat="server" Text=">>" /></td>
            </tr>
                        </table>
                         <table>
                <tr align="center">
                    <td style="width: 425px">
                        <asp:GridView id="GridView1" runat="server" forecolor="#333333" CellPadding="4" GridLines="None" font-names="Arial" font-size="Small" width="704px">
                        <FooterStyle backcolor="#507CD1" font-bold="True" forecolor="White"  />
                        
                        <Columns>
                            <asp:TemplateField HeaderText="SELECT">
                            <ItemTemplate >
                            
                            <asp:CheckBox id="checkbox1" runat ="server"  />
                            
                            </ItemTemplate>
                            
                            </asp:TemplateField>
                        </Columns>
                        <RowStyle backcolor="#EFF3FB"  />
                        <EditRowStyle backcolor="White" font-names="Arial" font-size="Small"  />
                        <SelectedRowStyle backcolor="White" font-bold="True" forecolor="#333333"  />
                        <PagerStyle backcolor="#2461BF" forecolor="White" HorizontalAlign="Center"  />
                        <HeaderStyle backcolor="#507CD1" font-bold="True" forecolor="White"  />
                        <AlternatingRowStyle backcolor="White" font-names="Arial" font-size="Small"  />
                    </asp:GridView>
                    </td>
                </tr>
            </table>
                    </td>                      
                        
                </tr>                
            </table>
            
            <table>
                <tr>
                    <td colspan ="4" style="width: 850px" align="center">
                        </td>                
                </tr>
            </table>
        </td>
    </tr>
</table>
</asp:Panel>
</div>
</asp:Content>

