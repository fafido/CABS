<%@ Page Language="VB" MasterPageFile="~/CDSUser.master" AutoEventWireup="false" CodeFile="BatchReceiptNewver.aspx.vb" Inherits="Trading_BatchReceiptNewver" title="Batch Receipting" %>

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
                        Text="Batch Receipting" width="824px" Height="16px"></asp:Label></td>
            </tr>
        </table>
        <table >
              <tr>
                <td colspan = "1" style="height: 18px" align ="left"><asp:Label runat="server"  
                        text="Security Type" ID="lblSecurityType"></asp:Label></td>
                <td colspan = "1" style="height: 18px" align ="left">
                    <asp:DropDownList ID="cmbSecurityType" runat="server" AutoPostBack="True" 
                        Width="175px">
                        <asp:ListItem>Shares</asp:ListItem>
                        <asp:ListItem>Bonds</asp:ListItem>
                        <asp:ListItem>Govt Debt</asp:ListItem>
                        <asp:ListItem>Assets</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td colspan ="2" align ="left"></td>
                <td colspan ="2" align ="left"></td>
                <td colspan ="1" style="height: 18px" align ="left">
                    <asp:Label ID="Label26" runat="server" font-names="Verdana" font-size="Small" 
                        Text="Batch Reference" width="139px"></asp:Label>
                </td>
                <td colspan ="1" style="height: 18px" align ="left">
                    <asp:Label ID="lblBatchRef" runat="server" 
                        style="font-family: Arial, Helvetica, sans-serif; font-weight: 700; color: #0033CC"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan ="1">
                    <asp:Label ID="Label3" runat="server" font-names="Verdana" font-size="Small" 
                        Text="Company"></asp:Label>
                </td>
                <td colspan ="1">
                    <asp:DropDownList ID="cmbParaCompany" runat="server" width="175px">
                    </asp:DropDownList>
                </td>
                <td colspan ="2"></td>
                <td colspan ="2"></td>
                <td colspan ="1">
                    <asp:Label ID="Label11" runat="server" font-names="Verdana" font-size="Small" 
                        Text="Transaction Date" width="139px"></asp:Label>
                </td>
                <td colspan ="1">
                    <BDP:BasicDatePicker ID="BasicDatePicker1" runat="server" Width="175px">
                    </BDP:BasicDatePicker>
                </td>
            </tr>
            <tr>
                <td colspan ="1">
                    <asp:Label ID="Label12" runat="server" font-names="Verdana" font-size="Small" 
                        Text="Trading Shares" width="106px"></asp:Label>
                </td>
                <td colspan ="1">
                    <asp:TextBox ID="txtBatchShares" runat="server" Width="175px"></asp:TextBox>
                </td>
                <td colspan ="2"></td>
                <td colspan ="2"></td>
                <td colspan ="1">
                    <asp:Label ID="Label1" runat="server" font-names="Verdana" font-size="Small" 
                        Text="Transaction Type" width="134px"></asp:Label>
                </td>
                <td colspan ="1">
                    <asp:DropDownList ID="CmbBatchType" runat="server" width="175px" 
                        AutoPostBack="True">
                        <asp:ListItem>IMMOB</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td colspan ="1" align="left">
                    <asp:Label ID="Label28" runat="server" font-names="Verdana" font-size="Small" 
                        Text="Batch Search" width="106px"></asp:Label>
                </td>
                <td colspan ="1"  align="left">
                    <asp:TextBox ID="txtBatchSearch" runat="server" Width="142px"></asp:TextBox>
                    <asp:Button ID="BtnBatchSearch" runat="server" Text="..." />
                </td>
                <td colspan ="2"  align="left"></td>
                <td colspan ="2"  align="left"></td>
                <td colspan ="1"  align="left"></td>
                <td colspan ="1"  align="left"></td>
            </tr>
            <tr>
                <td colspan ="1" style="height: 18px"></td>
                <td colspan ="1" style="height: 18px">
                    <asp:RadioButton ID="rdBatchDetails" runat="server" AutoPostBack="True" 
                        GroupName="BatchOptions" Text="Enter Batch Details" />
                </td>
                <td colspan ="2" style="height: 18px"></td>
                <td colspan ="2" style="height: 18px"></td>
                <td colspan ="1" style="height: 18px">
                    <asp:RadioButton ID="rdForwardBatch" runat="server" AutoPostBack="True" 
                        GroupName="BatchOptions" Text="Forward Batch for Capturing" />
                </td>
                <td colspan ="1" style="height: 18px"></td>
            </tr>
            <tr>
                <td colspan ="1"></td>
                <td colspan ="1"></td>
                <td colspan ="2"></td>
                <td colspan ="2"></td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>
            </tr>            
        </table>
        <table >
            <tr>
                <td colspan ="1">
                    <asp:Label ID="Label18" runat="server" font-names="Verdana" font-size="Small" 
                        Text="....... ......" width="106px"></asp:Label>
                </td>
                <td colspan ="2">
                    <asp:Button ID="btnSave" runat="server" Text="Save Batch" />
                </td>
                <td colspan ="2">
                    <asp:Button ID="BtnUpdate" runat="server" Text="Update Batch" />
                </td>
                <td colspan ="2">
                    <asp:Button ID="BtnPrint" runat="server" Text="Print Batch Receipt" />
                </td>
                <td colspan ="1">
                <asp:Button runat="server" text="Data Import" id="BtnDataImport" 
                        ></asp:Button>
                </td>
            </tr>
        </table>
        <table>
            <tr>
                <td colspan ="1" align="left">
                    &nbsp;</td>
                <td colspan ="1" style="width: 10px">
                    &nbsp;</td>
                <td colspan ="2" style="width: 10px">
                    &nbsp;</td>
                <td colspan ="2"></td>
                <td colspan ="1">
                    <asp:Label ID="Label29" runat="server" font-names="Verdana" font-size="Small" 
                        Text="Transaction Type" width="134px" Visible="False"></asp:Label>
                </td>
                <td colspan ="1">
                    <asp:DropDownList ID="CmbBatchType0" runat="server" width="175px" 
                        AutoPostBack="True" Visible="False">
                        <asp:ListItem>IMMOB</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>            
        </table>
        <table>
            <tr>
                    <td colspan ="1">
                    <asp:Label ID="Label20" runat="server" font-names="Verdana" font-size="Small" 
                        Text="Name Search" Width="106px"></asp:Label>
                    </td>
                    <td colspan ="7" align ="left">
                    <asp:TextBox ID="txtNameSearch" runat="server" Width="175px"></asp:TextBox>
                    <asp:Button ID="Button3" runat="server" Text="..." />
                    </td>
            </tr>
            <tr>
                <td colspan ="1" class="auto-style1">
                    <asp:Label ID="Label21" runat="server" font-names="Verdana" font-size="Small" 
                        Text="Name Search" Width="106px"></asp:Label>
                </td>
                <td colspan ="7" align="left" class="auto-style1">
                    <asp:ListBox ID="lstNameSearch" runat="server" AutoPostBack="True" 
                        Width="502px"></asp:ListBox>
                </td>
                </tr>
                <tr>
                    <td colspan ="1" style="height: 18px"></td>
                    <td colspan ="7" style="height: 18px">
                        <asp:Label ID="lblShareholder" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan ="1" style="height: 18px">
                        <asp:Label runat="server" 
                            Text="Holding Balance" ID="lblHoldingBalance"></asp:Label></td>
                    <td colspan ="7" style="height: 18px">
                        <asp:Label ID="lblBalance" runat="server"></asp:Label>
                    </td>
                </tr>
            <tr>
                <td colspan ="1">
                    <asp:Label ID="Certificates" runat="server" Text="Certificates"></asp:Label>
                </td>
                <td colspan ="7">
                    <asp:Panel ID="Panel2" runat="server">
                        <asp:GridView ID="grdHolderCertificates" runat="server" CellPadding="4" 
                            font-names="Arial" font-size="Small" forecolor="#333333" GridLines="None" 
                            Height="16px" width="506px">
                            <FooterStyle backcolor="#507CD1" font-bold="True" forecolor="White" />
                            <Columns>
                                <asp:TemplateField HeaderText="SELECT">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="checkbox2" runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <RowStyle backcolor="#EFF3FB" HorizontalAlign="Left" />
                            <EditRowStyle backcolor="White" font-names="Arial" font-size="Small" />
                            <SelectedRowStyle backcolor="White" font-bold="True" forecolor="#333333" />
                            <PagerStyle backcolor="#2461BF" forecolor="White" HorizontalAlign="Center" />
                            <HeaderStyle backcolor="#507CD1" font-bold="True" forecolor="White" 
                                HorizontalAlign="Left" />
                            <AlternatingRowStyle backcolor="White" font-names="Arial" font-size="Small" />
                        </asp:GridView>
                    </asp:Panel>
                </td>
            </tr>
            <tr>
                <td colspan ="1">
                    <asp:Label ID="Label23" runat="server" Text="Shares to batch"></asp:Label>
                </td>
                <td colspan ="7">
                    <asp:Label ID="Label27" runat="server"></asp:Label>
                    <asp:TextBox ID="txtSharesToBatch" runat="server" Width="175px"></asp:TextBox>
                    <asp:Button ID="btnBatchSharesSave" runat="server" Text="Save" />
                </td>
            </tr>
            <tr>
                <td colspan ="1">
                    
                </td>
                <td colspan ="7">
                    <asp:Panel ID="PanelTrans" runat="server" Width="523px">
                        <asp:GridView ID="grdBatched" runat="server" CellPadding="4" 
                            font-names="Arial" font-size="Small" forecolor="#333333" GridLines="None" 
                            Height="16px" width="518px">
                            <FooterStyle backcolor="#507CD1" font-bold="True" forecolor="White" />
                            <Columns>
                                <asp:TemplateField HeaderText="SELECT">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="checkbox1" runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <RowStyle backcolor="#EFF3FB" HorizontalAlign="Left" />
                            <EditRowStyle backcolor="White" font-names="Arial" font-size="Small" />
                            <SelectedRowStyle backcolor="White" font-bold="True" forecolor="#333333" />
                            <PagerStyle backcolor="#2461BF" forecolor="White" HorizontalAlign="Center" />
                            <HeaderStyle backcolor="#507CD1" font-bold="True" forecolor="White" 
                                HorizontalAlign="Left" />
                            <AlternatingRowStyle backcolor="White" font-names="Arial" font-size="Small" />
                        </asp:GridView>
                    </asp:Panel>
                </td>
            </tr>
        </table>
        <table>
            <tr>
                <td colspan ="1"></td>
                <td colspan ="1"></td>
                <td colspan ="2"></td>
                <td colspan ="2"></td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>
            </tr>
        </table>
        <table>
            <tr>
                <td colspan ="1">
                    &nbsp;</td>
                <td colspan ="1" style="width: 10px">
                    &nbsp;</td>
                <td colspan ="2" style="width: 10px">
                    &nbsp;</td>
                <td colspan ="2"></td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>
            </tr>            
        </table>
        <table>
            <tr>
                    <td colspan ="1">
                    <asp:Label ID="LabelTransferee" runat="server" font-names="Verdana" font-size="Small" 
                        Text="Transferee" Width="106px"></asp:Label>
                    </td>
                    <td colspan ="7" align ="left" >
                    <asp:TextBox ID="txtTransfereeSearch" runat="server" Width="175px"></asp:TextBox>
                    <asp:Button ID="btnTransferee" runat="server" Text="..." />
                    </td>
            </tr>
            <tr>
                <td colspan ="1" style="height: 74px">
                    <asp:Label ID="LabelTransferree" runat="server" font-names="Verdana" font-size="Small" 
                        text="Transferee Search" Width="106px"></asp:Label>
                </td>
                <td colspan ="7" align ="left"  style="height: 74px">
                    <asp:ListBox ID="lstTransfereeSearch" runat="server" AutoPostBack="True" 
                        Width="502px"></asp:ListBox>
                </td>
                </tr>
                <tr>
                    <td colspan ="1"></td>
                    <td colspan ="7">
                        <asp:Label ID="lblTransfereeNum" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan ="1" style="height: 18px">
                        <asp:Label ID="Sahres" runat="server" Text="Shares"></asp:Label>
                    </td>
                    <td colspan ="7" style="height: 18px">
                        
                        <asp:TextBox ID="txtTransfereeShares" runat="server" Width="175px"></asp:TextBox>
                        <asp:Button ID="btnTransfereeSave" runat="server" Text="Save" />
                        
                    </td>
                </tr>
                <tr>
                    <td colspan ="1" style="height: 18px">&nbsp;</td>
                    <td colspan ="7" style="height: 18px">
                        
                        <asp:Label ID="Label24" runat="server"></asp:Label>
                        
                    </td>
                </tr>
                <tr>
                <td colspan ="1">
                    <asp:Label ID="lblTransfers" runat="server" Text="Transfers"></asp:Label>
                </td>
                <td colspan ="7">
                    <asp:Panel ID="Panel3" runat="server">
                        <asp:GridView ID="grdTransfers" runat="server" CellPadding="4" 
                            font-names="Arial" font-size="Small" forecolor="#333333" GridLines="None" 
                            Height="143px" width="513px">
                            <FooterStyle backcolor="#507CD1" font-bold="True" forecolor="White" />
                            <Columns>
                                <asp:TemplateField HeaderText="SELECT">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="checkbox3" runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <RowStyle backcolor="#EFF3FB" />
                            <EditRowStyle backcolor="White" font-names="Arial" font-size="Small" />
                            <SelectedRowStyle backcolor="White" font-bold="True" forecolor="#333333" />
                            <PagerStyle backcolor="#2461BF" forecolor="White" HorizontalAlign="Center" />
                            <HeaderStyle backcolor="#507CD1" font-bold="True" forecolor="White" />
                            <AlternatingRowStyle backcolor="White" font-names="Arial" font-size="Small" />
                        </asp:GridView>
                    </asp:Panel>
                </td>
            </tr>
            <tr>
                <td colspan ="1"></td>
                <td colspan ="7">
                    <asp:Label ID="Label25" runat="server" Width="175px"></asp:Label>
                    <asp:Button ID="Button4" runat="server" Text="Del" />
                </td>
            </tr>
        </table>
            <table>                     
            <tr>
                <td colspan="1" style="width: 68px">
                    &nbsp;</td> 
                            <td colspan ="1" style="width: 473px">
                                &nbsp;</td>                   
            </tr>
            <tr>
                <td colspan="1" style="width: 68px">
                    &nbsp;</td> 
                            <td colspan ="1" style="width: 473px">
                                &nbsp;</td>                   
            </tr>                     
            <tr>
                <td colspan="1" style="width: 68px">
                    &nbsp;</td> 
                            <td colspan ="1" style="width: 473px">
                                &nbsp;</td>                   
            </tr>
            <tr>
                <td colspan="1" style="width: 68px">
                    &nbsp;</td> 
                            <td colspan ="1" style="width: 473px">
                                &nbsp;</td>                   
            </tr>
                  </table>                      
        </td>
    </tr>
</table>
        </asp:Panel>
</div>
</asp:Content>

