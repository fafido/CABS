<%@ Page Language="VB" MasterPageFile="~/TSec.master" AutoEventWireup="false" CodeFile="TSecBatchVerification.aspx.vb" Inherits="TSecTrading_BrokerBatchVerification" title="Batch Verification" %>

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
                        Text="T\Sec Batch Verification" width="841px" Height="16px"></asp:Label></td>
            </tr>
            <tr>
                <td colspan="1" style="width: 15px; height: 11px;">
                    <asp:Label id="Label7" runat="server" Text="Search Batch" font-names="Verdana" 
                        font-size="Small" width="180px"></asp:Label></td> 
                            <td colspan ="1" style="width: 473px; height: 11px;">
                                <asp:TextBox id="txtSearch" runat="server"></asp:TextBox>
                                <asp:Button id="btnBatchSearch" runat="server" Text=">>" /></td>                   
            </tr>
            <tr>
                <td colspan="1" style="width: 15px; height: 11px;">
                    <asp:Label id="Label3" runat="server" Text="Select Batch" font-names="Verdana" 
                        font-size="Small" width="158px" Height="16px"></asp:Label></td> 
                            <td colspan ="1" style="width: 473px; height: 11px;">
                                <asp:DropDownList id="cmbBatch" runat="server" width="176px" autopostback="True">
                                </asp:DropDownList></td>                   
            </tr>
            <tr>
                <td colspan="1" style="width: 15px">
                    </td> 
                            <td colspan ="1" style="width: 473px">
                                </td>                   
            </tr>
            
            <tr>
                <td colspan="1" style="width: 15px; height: 23px;">
                    <asp:Label id="Label11" runat="server" Text="Batching Date" 
                        font-names="Verdana" font-size="Small" width="137px"></asp:Label></td> 
                            <td colspan ="1" style="width: 473px; height: 23px;">
                                <asp:Label id="LblBatchDate" runat="server"></asp:Label></td>                   
            </tr>
                <tr>
                <td colspan="1" style="width: 15px; height: 24px;">
                    <asp:Label id="Label12" runat="server" Text="Batch Total" font-names="Verdana" font-size="Small" width="128px"></asp:Label></td> 
                            <td colspan ="1" style="width: 473px; height: 24px;">
                                <asp:Label id="lblBatchTotal" runat="server"></asp:Label></td>                   
            </tr>
            <tr>
                <td colspan="1" style="width: 15px; height: 23px;">
                    <asp:Label id="Label6" runat="server" font-names="Verdana" font-size="Small" Text="Batch Ref"
                        width="145px"></asp:Label></td> 
                            <td colspan ="1" style="width: 473px; height: 23px;">
                                <asp:Label id="lblbatchref" runat="server" font-bold="True" font-names="Arial"
                                    width="152px"></asp:Label></td>                   
            </tr>       
            <tr>
                <td><asp:Label id="Label1" runat="server" font-size="Small" font-names="Verdana" 
                        width="161px" Text="Batch Captured By"></asp:Label></td>
                <td>
                    <asp:Label id="lblBatchBy" runat="server" Text=""></asp:Label></td>
            </tr>     
            </table>
            <center>
            <table>
                <tr align="center">
                    <td style="width: 425px">
                        <asp:GridView id="grdAddedCertificate" runat="server" forecolor="#333333" 
                            CellPadding="4" GridLines="None" font-names="Arial" font-size="Small" 
                            width="843px">
                        <FooterStyle backcolor="White" font-bold="True" forecolor="White"  />
                        
                        <Columns>
                            <asp:TemplateField HeaderText="SELECT">
                            <ItemTemplate >
                            
                            <asp:CheckBox id="checkbox1" runat ="server"  />
                            
                            </ItemTemplate>
                            
                            </asp:TemplateField>
                        </Columns>
                        <RowStyle backcolor="White" BorderColor="#E0E0E0" BorderStyle="Dotted" 
                                BorderWidth="1px" HorizontalAlign="Left"  />
                        <EditRowStyle backcolor="White" font-names="Arial" font-size="Small"  />
                        <SelectedRowStyle backcolor="White" font-bold="True" forecolor="#333333"  />
                        <PagerStyle backcolor="#2461BF" forecolor="White" HorizontalAlign="Center"  />
                        <HeaderStyle backcolor="#507CD1" font-bold="True" forecolor="White" 
                                HorizontalAlign="Left"  />
                        <AlternatingRowStyle backcolor="White" font-names="Arial" font-size="Small"  />
                    </asp:GridView>
                    </td>
                </tr>
                <tr align="center">
                    <td style="width: 425px">
                        <asp:CheckBox id="CheckBox2" runat="server" font-names="Arial" 
                            font-size="Small" autopostback ="true" Text ="Decline Batch" />
                    </td>
                </tr>
                <tr align ="center">
                    <td>
                        <asp:TextBox id="txtRejection" TextMode ="MultiLine" Visible = "false"
                            runat="server" Height="58px" width="358px"></asp:TextBox>
                    </td>
                </tr>
                <tr align ="left">
                    <td>
                    <asp:Label id="Label25" runat="server" font-names="Verdana" font-size="Small" 
                        Text="Capture Photo"></asp:Label>
                    
                    
                    <input id="fDocument" runat="server" onclick="return fDocument_onclick()" 
                        style="width: 100px; height: 26px;" type="file" validationgroup="*.jpg" />
                        
                    </td>
                </tr>
                <tr>
                    <td>                        <asp:Button 
                        id="Button2" runat="server" Text="Load Image" Visible ="false"  />
                    <asp:TextBox id="TextBox1" runat="server" Visible="False"></asp:TextBox>     
                    
                    
                    <asp:Button id="BtnCapture1" runat="server" Text="Capture" /></td>
                </tr>
                <tr>
                <td>
                    
                    </td>
                    <td colspan ="3" align="left">
                        &nbsp;</td>
                </tr>
            </table>
           </center>
            <table style="width: 792px">
                <tr align="center">
                    <td style="width: 161px" align="center">
                        <table>
                            <tr align="center">                                                             
                                <td style="width: 276px; border-right: #cccccc thin solid; border-top: #cccccc thin solid; border-left: #cccccc thin solid; border-bottom: #cccccc thin solid;">
                                    <asp:Button id="btnForward" runat="server" Text="Approve Account" /></td>
                                <td style="width: 280px; border-right: #cccccc thin solid; border-top: #cccccc thin solid; border-left: #cccccc thin solid; border-bottom: #cccccc thin solid;">
                                    <asp:Button id="btnDecline" runat="server" Text="DeclineBatch" /></td>
                            </tr>
                        </table>
                    </td>                      
                        
                </tr>                
            </table>
            
            <table>
                <tr>
                    <td colspan ="4" style="width: 1034px" align="center">
                        </td>                
                </tr>
            </table>
        </td>
    </tr>
</table>
</asp:Panel>
</div>
</asp:Content>

