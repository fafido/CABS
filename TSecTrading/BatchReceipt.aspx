<%@ Page Language="VB" MasterPageFile="~/TSec.master" AutoEventWireup="false" CodeFile="BatchReceipt.aspx.vb" Inherits="TSecTrading_BatchReceipt" title="Batch Receipting" %>

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
                        Text="Batch Receipting" width="847px"></asp:Label></td>
            </tr>
            <tr>
                <td colspan="1" style="width: 68px">
                    <asp:Label id="Label3" runat="server" Text="Company" font-names="Verdana" font-size="Small"></asp:Label></td> 
                            <td colspan ="1" style="width: 473px">
                                <asp:DropDownList id="cmbParaCompany" runat="server" width="176px">
                                </asp:DropDownList></td>                   
            </tr>
            <tr>
                <td colspan="1" style="width: 68px">
                    <asp:Label id="Label1" runat="server" Text="Batch Type" font-names="Verdana" 
                        font-size="Small" width="111px"></asp:Label></td> 
                            <td colspan ="1" style="width: 473px">
                                <asp:DropDownList id="CmbBatchType" runat="server" width="176px">
                                    <asp:ListItem>KUUMBA</asp:ListItem>
                                </asp:DropDownList></td>                   
            </tr>
            
            <tr>
                <td colspan="1" style="width: 68px">
                    <asp:Label id="Label11" runat="server" Text="Batching Date" 
                        font-names="Verdana" font-size="Small" width="149px"></asp:Label></td> 
                            <td colspan ="1" style="width: 473px">
                                <BDP:BasicDatePicker id="BasicDatePicker1" runat="server">
                                </BDP:BasicDatePicker>
                            </td>                   
            </tr>
                <tr>
                <td colspan="1" style="width: 68px">
                    <asp:Label id="Label12" runat="server" Text="Batch Shares" font-names="Verdana" 
                        font-size="Small" width="132px"></asp:Label></td> 
                            <td colspan ="1" style="width: 473px">
                                <asp:TextBox id="txtBatchShares" runat="server"></asp:TextBox></td>                   
            </tr>
            <tr>
                <td colspan="1" style="width: 68px">
                    <asp:Label id="Label13" runat="server" Text="Broker / Lodger ?" 
                        font-names="Verdana" font-size="Small" width="139px"></asp:Label></td> 
                            <td colspan ="1" style="width: 473px">
                                <asp:RadioButton id="rdBroker" runat="server" GroupName="Lodger" Text="Broker" autopostback="True" font-names="Arial" font-size="Small" />
                                <asp:RadioButton id="rdLodger" runat="server" GroupName="Lodger" Text="Lodger" autopostback="True" font-names="Arial" font-size="Small" /></td>                   
            </tr>
            <tr>
                <td colspan="1" style="width: 68px">
                    <asp:Label id="lblBroker" runat="server" Text="Broker/Lodger" 
                        font-names="Verdana" font-size="Small" width="123px"></asp:Label></td> 
                            <td colspan ="1" style="width: 473px">
                                <asp:DropDownList id="CmbBroker" runat="server" width="240px">
                                </asp:DropDownList>
                                <asp:TextBox id="txtLodger" runat="server"></asp:TextBox></td>                   
            </tr>
            <tr>
                <td colspan="1" style="width: 68px">
                    <asp:Label id="Label15" runat="server" Text="Options" font-names="Verdana" 
                        font-size="Small" width="108px"></asp:Label></td> 
                            <td colspan ="1" style="width: 473px">
                                <asp:Button id="btnSave" runat="server" Text="Save Batch" />&nbsp;<asp:Button id="BtnUpdate"
                                    runat="server" Text="Update Batch" />&nbsp;<asp:Button id="BtnPrint" runat="server"
                                        Text="Print Batch Receipt" /></td>                   
            </tr>
            <tr>
                <td colspan="1" style="width: 68px">
                    </td> 
                            <td colspan ="1" style="width: 473px">
                                </td>                                                   
                                
            </tr>
            </table>
            <center>
            <table>
                <tr>
                    <td colspan="0.5" style="width: 197px; border-right: #cccccc thin solid; border-top: #cccccc thin solid; border-left: #cccccc thin solid; border-bottom: #cccccc thin solid;"><asp:Label id="Label14" runat="server" Text="Certificate" font-names="Verdana" font-size="Small" width="112px"></asp:Label></td>
                    <td colspan = "0.5" style="width: 287px; border-right: #cccccc thin solid; border-top: #cccccc thin solid; border-left: #cccccc thin solid; border-bottom: #cccccc thin solid;"><asp:TextBox id="TextBox14" runat="server"></asp:TextBox>
                        <asp:TextBox id="txtCd" runat="server" width="32px"></asp:TextBox></td>
                    <td style="width: 197px; border-right: #cccccc thin solid; border-top: #cccccc thin solid; border-left: #cccccc thin solid; border-bottom: #cccccc thin solid;">
                    <asp:Label id="Label17" runat="server" Text="Shares" font-names="Verdana" font-size="Small" width="80px"></asp:Label></td>
                    <td style="width: 197px; border-right: #cccccc thin solid; border-top: #cccccc thin solid; border-left: #cccccc thin solid; border-bottom: #cccccc thin solid;">
                        <asp:TextBox id="txtShares" runat="server"></asp:TextBox></td>
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
                                    <asp:Button id="Button1" runat="server" Text="Delete Cert" /></td>
                                <td style="width: 280px; border-right: #cccccc thin solid; border-top: #cccccc thin solid; border-left: #cccccc thin solid; border-bottom: #cccccc thin solid;">
                                    <asp:Button id="Button2" runat="server" Text="Print Batch Summary" /></td>
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

