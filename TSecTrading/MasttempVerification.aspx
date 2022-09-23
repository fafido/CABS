<%@ Page Language="VB" MasterPageFile="~/TSec.master" AutoEventWireup="false" CodeFile="MasttempVerification.aspx.vb" Inherits="TSecTrading_MasttempVerification" title="MAST - TEMP VERIFICATION BEFORE UPLOAD" %>

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
                        Text="Upload Verification" width="872px"></asp:Label></td>
            </tr>            
            <tr>
                <td style="width: 66px; height: 11px;">
                    <asp:Label id="Label3" runat="server" Text="Select Company" 
                        font-names="Verdana" font-size="Small" width="157px"></asp:Label></td> 
                            <td style="width: 473px; height: 11px;">
                                <asp:DropDownList id="cmbBatch" runat="server" width="176px" autopostback="True">
                                </asp:DropDownList></td>                   
            </tr>
            <tr>
                <td style="width: 66px">
                    </td> 
                            <td style="width: 473px">
                                </td>                   
            </tr>
            
            <tr>
                <td style="width: 66px">
                    <asp:Label id="Label11" runat="server" Text="Current Share Capital" 
                        font-names="Verdana" font-size="Small" width="173px"></asp:Label></td> 
                            <td colspan ="1" style="width: 473px">
                                <asp:Label id="LblBatchDate" runat="server"></asp:Label></td>                   
            </tr>
                <tr>
                <td style="width: 66px">
                    <asp:Label id="Label12" runat="server" Text="Pending Upload Shares " 
                        font-names="Verdana" font-size="Small" width="175px"></asp:Label></td> 
                            <td style="width: 473px">
                                <asp:Label id="lblBatchTotal" runat="server"></asp:Label></td>                   
            </tr>
            <tr>
                <td style="width: 66px; height: 19px;">
                    <asp:Label id="Label6" runat="server" font-names="Verdana" font-size="Small" Text="Share Capital After Upload"
                        width="199px"></asp:Label></td> 
                            <td style="width: 473px; height: 19px;">
                                <asp:Label id="lblbatchref" runat="server" font-bold="True" font-names="Arial"
                                    width="152px"></asp:Label></td>                   
            </tr>                   
            </table>
            <center>
            <table>
                <tr align="center">
                    <td style="width: 425px">
                        <asp:GridView id="grdAddedCertificate" runat="server" forecolor="#333333" CellPadding="4" GridLines="None" font-names="Arial" font-size="Small" width="864px">
                        <FooterStyle backcolor="White" font-bold="True" forecolor="White"  />
                        
                        <Columns>
                            <asp:TemplateField HeaderText="SELECT">
                            <ItemTemplate >
                            
                            <asp:CheckBox id="checkbox1" runat ="server"  />
                            
                            </ItemTemplate>
                            
                            </asp:TemplateField>
                        </Columns>
                        <RowStyle backcolor="White" BorderColor="#E0E0E0" BorderStyle="Dotted" BorderWidth="1px"  />
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
                    <td style="width: 161px" align="center">
                        <table>
                            <tr align="center">                                                             
                                <td style="width: 276px; border-right: #cccccc thin solid; border-top: #cccccc thin solid; border-left: #cccccc thin solid; border-bottom: #cccccc thin solid;">
                                    <asp:Button id="btnForward" runat="server" Text="Update" /></td>
                                <td style="width: 280px; border-right: #cccccc thin solid; border-top: #cccccc thin solid; border-left: #cccccc thin solid; border-bottom: #cccccc thin solid;">
                                    <asp:Button id="btnDecline" runat="server" Text="Update Summary" /></td>
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

