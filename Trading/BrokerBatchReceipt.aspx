<%@ Page Language="VB" MasterPageFile="~/CDSUser.master" AutoEventWireup="false" CodeFile="BrokerBatchReceipt.aspx.vb" Inherits="Trading_BrokerBatchReceipt" title="Batch Receipting" %>

<%@ Register Assembly="BasicFrame.WebControls.BasicDatePicker" Namespace="BasicFrame.WebControls"
    TagPrefix="BDP" %>
<asp:Content id="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
    <asp:Panel id="Panel1" runat="server">
    
<table style="border-right: #000033 thin solid; border-top: #000033 thin solid; border-left: #000033 thin solid; width: 832px; border-bottom: #000033 thin solid; background-color: #ffffff">
    
    <tr>
        <td style="width: 478px; height: 226px" valign="top">
       
            <table style="width: 178%">
                <tr>
                    <td style="width: 123px">
                        <asp:Label id="Label7" runat="server" font-names="Verdana" font-size="Small" 
                            Text="Search Batch" width="96px"></asp:Label>
                    </td>
                    <td style="width: 280px">
                        <asp:TextBox id="txtSearch" runat="server" width="131px"></asp:TextBox>
                        <asp:Button id="btnBatchSearch" runat="server" Text="&gt;&gt;" />
                    </td>
                    <td style="width: 83px">
                        <asp:Label id="Label1" runat="server" font-names="Verdana" font-size="Small" 
                            Text="Batch Type" width="80px"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList id="CmbBatchType" runat="server" autopostback="True" 
                            width="176px">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td style="width: 123px">
                        <asp:Label id="Label3" runat="server" font-names="Verdana" font-size="Small" 
                            Text="Company"></asp:Label>
                    </td>
                    <td style="width: 280px">
                        <asp:DropDownList id="cmbParaCompany" runat="server" width="176px">
                        </asp:DropDownList>
                    </td>
                    <td style="width: 83px">
                        <asp:Label id="Label12" runat="server" font-names="Verdana" font-size="Small" 
                            Height="16px" Text="Batch Shares" width="97px"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox id="txtBatchShares" runat="server" width="169px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="width: 123px">
                        <asp:Label id="Label11" runat="server" font-names="Verdana" font-size="Small" 
                            Text="Batching Date" width="136px" Height="16px"></asp:Label>
                    </td>
                    <td style="width: 280px">
                        <BDP:BasicDatePicker id="BasicDatePicker1" runat="server" ReadOnly="True">
                        </BDP:BasicDatePicker>
                    </td>
                    <td style="width: 83px">
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 123px; height: 25px;">
                        <asp:Label id="Label6" runat="server" font-names="Verdana" font-size="Small" 
                            Text="Batch Ref" width="88px"></asp:Label>
                    </td>
                    <td style="width: 280px; height: 25px;">
                        <asp:Label id="lblbatchref" runat="server" font-bold="True" font-names="Arial"></asp:Label>
                    </td>
                    <td style="width: 83px; height: 25px;">
                        </td>
                    <td style="height: 25px">
                        </td>
                </tr>
                <tr>
                    <td align="left" colspan="4">
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button 
                            id="btnSave" runat="server" Text="Save Batch" />
                        &nbsp;<asp:Button id="BtnUpdate" runat="server" Enabled="False" Text="Update Batch" />
                        &nbsp;<asp:Button id="BtnPrint" runat="server" Text="Print Batch Receipt" />
                        <asp:Button id="Button6" runat="server" Text="New Batch" />
                    </td>
                </tr>
                <tr>
                    <td style="width: 123px">
                        <asp:Label id="Label2" runat="server" font-names="Arial" font-size="Small" 
                            Text="Shareholder Number"></asp:Label>
                    </td>
                    <td style="width: 280px">
                        <asp:TextBox id="txtShareholderSearch" runat="server"></asp:TextBox>
                        <asp:Button id="btnNumberSearch" runat="server" Text="&gt;&gt;" />
                    </td>
                    <td style="width: 83px">
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 123px">
                        <asp:Label id="Label5" runat="server" font-names="Arial" font-size="Small" 
                            Text="Shareholder Name" width="139px"></asp:Label>
                    </td>
                    <td style="width: 280px">
                        <asp:TextBox id="txtShareholderName" runat="server"></asp:TextBox>
                        <asp:Button id="btnNameSearch1" runat="server" Text="&gt;&gt;" />
                    </td>
                    <td style="width: 83px">
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 123px">
                        &nbsp;</td>
                    <td colspan="3" rowspan="2">
                        <asp:ListBox id="lstName" runat="server" autopostback="True" Height="58px" 
                            width="277px"></asp:ListBox>
                    </td>
                </tr>
                <tr>
                    <td style="width: 123px">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 123px">
                        &nbsp;</td>
                    <td style="width: 280px">
                        <asp:Button id="btnSelect" runat="server" Text="Select" />
                    </td>
                    <td style="width: 83px">
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 123px">
                        &nbsp;</td>
                    <td style="width: 280px">
                        <asp:Label id="lblSelctedNames" runat="server"></asp:Label>
                        <asp:Label id="LblShareholder" runat="server"></asp:Label>
                    </td>
                    <td style="width: 83px">
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                <td align="center" colspan="4">
                    <asp:Label id="Label10" runat="server" backcolor="#CCCCCC" font-bold="True" font-names="Arial"
                        Text="Old Shareholder Account Immobilization" width="872px"></asp:Label></td>
            </tr>
            </table>
            <br />
            <table>
            <tr>
                <td></td>
                <td>
                    <asp:Label id="Label14" runat="server" font-names="Verdana" font-size="Small" 
                        Text="Certificate No." width="148px"></asp:Label>
                </td>
                <td>
                    <asp:TextBox id="txtCert" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:Button id="Button5" runat="server" Text="&gt;&gt;" />
                </td>
            </tr>
                        <tr>
                <td></td>
                <td>
                    <asp:Label id="Label8" runat="server" font-names="Verdana" font-size="Small" 
                        Text="Old Shareholder No." width="148px"></asp:Label>
                </td>
                <td>
                    <asp:TextBox id="txtOldholder" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:Button id="Button2" runat="server" Text="&gt;&gt;" />
                </td>
            </tr>        
            </table>
            <center>
            <table>
            <%--<tr>
                <td></td>
                <td>
                    <asp:Label id="Label14" runat="server" font-names="Verdana" font-size="Small" 
                        Text="Certificate" width="112px"></asp:Label>
                </td>
                <td>
                    <asp:TextBox id="txtCert" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:Button id="Button5" runat="server" Text="&gt;&gt;" />
                </td>
            </tr>--%>
                                
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
                        <RowStyle backcolor="#EFF3FB" HorizontalAlign="Left"  />
                        <EditRowStyle backcolor="White" font-names="Arial" font-size="Small"  />
                        <SelectedRowStyle backcolor="White" font-bold="True" forecolor="#333333" 
                                HorizontalAlign="Left"  />
                        <PagerStyle backcolor="#2461BF" forecolor="White" HorizontalAlign="Center"  />
                        <HeaderStyle backcolor="#507CD1" font-bold="True" forecolor="White" 
                                HorizontalAlign="Left"  />
                        <AlternatingRowStyle backcolor="White" font-names="Arial" font-size="Small" 
                                HorizontalAlign="Left"  />
                    </asp:GridView>
                    </td>
                </tr>
            </table>
           </center>
           <center>
           <table>
            <tr>
                <td align="left" colspan ="4" align="center" style="width: 397px">
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button id="BtnDelCert" runat="server" Text="Delete Cert" />
                    <asp:Button id="BtnPrintBatchReport" runat="server" Text="Print Batch Summary" 
                        width="166px" />
                </td>
            </tr>
           </table>
           </center>
            <table style="width: 792px">
                <tr align="center">
                    <td style="width: 146px" align="center">
                        <table>
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

