<%@ Page Language="VB" MasterPageFile="~/CDSMain.master" AutoEventWireup="false" CodeFile="PostedOrders.aspx.vb" Inherits="CDSMode_PostedOrders" title="Orders Enquiries" %>

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
                        Text="Posted Orders"  width="849px"></asp:Label></td>
            </tr>
            <tr>
                <td colspan="1" style="width: 14px; height: 11px;">
                    <asp:Label id="Label5" runat="server" Text="Search Options" 
                        font-names="Verdana" font-size="Small" width="142px"></asp:Label></td> 
                            <td colspan ="1" style="width: 473px; height: 11px;">
                                <asp:RadioButton id="rdByOrderID" GroupName ="OrdersSeach" Text ="By Order id" runat="server" autopostback="true" />
                                <asp:RadioButton id="rdByBroker" GroupName ="OrdersSeach" Text ="By Broker" runat="server" autopostback="true" />
                                <asp:RadioButton id="rdBydate" GroupName ="OrdersSeach" Text ="By Date Placed" runat="server" autopostback="true" />
                                <asp:RadioButton id="rdByCompany" GroupName ="OrdersSeach" Text ="By Company" runat="server" autopostback="true" />
                               
                               </td>                   
            </tr>
            <tr>
                <td colspan="1" style="width: 14px; height: 11px;">
                    <asp:Label id="Label7" runat="server" Text="Search" font-names="Verdana" 
                        font-size="Small" width="156px"></asp:Label></td> 
                            <td colspan ="1" style="width: 473px; height: 11px;">
                                <asp:TextBox id="txtSearch" runat="server"></asp:TextBox>
                                <asp:Button id="btnBatchSearch" runat="server" Text=">>" />
                                <asp:DropDownList id="cmbBatch" runat="server" autopostback="True" 
                                    width="176px">
                                </asp:DropDownList>
                                <asp:Label id="Label8" runat="server" Visible="False"></asp:Label>
                </td>                   
            </tr>
            <tr>
                <td colspan="1" style="width: 14px; height: 11px;">
                    <asp:Label id="Label3" runat="server" font-names="Verdana" font-size="Small" 
                        width="156px"></asp:Label></td> 
                            <td colspan ="1" style="width: 473px; height: 11px;">
                                <BDP:BasicDatePicker id="BasicDatePicker1" runat="server" />
                                <asp:Button id="Button1" runat="server" Text="&gt;&gt;" Visible="False" />
                </td>                   
            </tr>
            <tr>
                <td colspan="1" style="width: 14px">
                    &nbsp;</td> 
                            <td colspan ="1" style="width: 473px">
                                &nbsp;</td>                   
            </tr>
            
            
            </table>
            <center>
            <table>
                <tr align="center">
                    <td style="width: 425px" align ="center">
                        <asp:GridView id="grdAddedCertificate" runat="server" forecolor="#333333" 
                            CellPadding="4" GridLines="None" font-names="Arial" font-size="Small" 
                            width="843px">
                        <FooterStyle backcolor="#507CD1" font-bold="True" forecolor="White"  />
                        
                            <EmptyDataRowStyle HorizontalAlign="Left" />
                        
                        <Columns>
                            <asp:TemplateField HeaderText="SELECT">
                            <ItemTemplate >
                            
                            <asp:CheckBox id="checkbox1" runat ="server"  />
                            
                            </ItemTemplate>
                            
                            </asp:TemplateField>
                        </Columns>
                        <RowStyle backcolor="#EFF3FB" HorizontalAlign="Left"  />
                        <EditRowStyle backcolor="White" font-names="Arial" font-size="Small" 
                                HorizontalAlign="Left"  />
                        <SelectedRowStyle backcolor="White" font-bold="True" forecolor="#333333"  />
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
            <table style="width: 792px">
                <tr align="center">
                    <td style="width: 146px" align="center">
                        <table>
                            <tr align="center">                                                             
                                <td style="width: 276px; border-right: #cccccc thin solid; border-top: #cccccc thin solid; border-left: #cccccc thin solid; border-bottom: #cccccc thin solid;">
                                    &nbsp;</td>
                                <td style="width: 280px; border-right: #cccccc thin solid; border-top: #cccccc thin solid; border-left: #cccccc thin solid; border-bottom: #cccccc thin solid;">
                                    &nbsp;</td>
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

