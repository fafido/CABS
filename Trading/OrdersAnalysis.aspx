<%@ Page Language="VB" MasterPageFile="~/CDSUser.master" AutoEventWireup="false" CodeFile="OrdersAnalysis.aspx.vb" Inherits="Trading_OrdersAnalysis" title="Orders Summary Reporting" %>

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
                <td></td>
                <td align="center">
                    <asp:RadioButton id="rdAll" runat="server" autopostback="True" 
                        GroupName="Printoptions" Text="Print All" />
                    <asp:RadioButton id="rdAll0" runat="server" autopostback="True" 
                        GroupName="Printoptions" Text="Buys" />
                    <asp:RadioButton id="rdAll1" runat="server" autopostback="True" 
                        GroupName="Printoptions" Text="Sales" />
                    <asp:RadioButton id="rdAll2" runat="server" autopostback="True" 
                        GroupName="Printoptions" Text="Individual" />
                </td>
            </tr>
            <tr>
                <td style="width: 870px" align="left" colspan="6">
                    <asp:Label id="Label4" runat="server" backcolor="#8080FF" font-bold="True" font-names="Arial"
                        Text="Orders Summary Report" width="872px"></asp:Label></td>
            </tr>
            
            <tr>
                <td style="width: 47px">
                    <asp:Label id="Label3" runat="server" Text="Start Date" font-names="Verdana" 
                        font-size="Small" width="104px"></asp:Label></td> 
                            <td colspan ="1" style="width: 473px">
                                <BDP:BasicDatePicker id="BasicDatePicker1" runat="server" ReadOnly="True" 
                                    width="180px">
                                </BDP:BasicDatePicker>
                </td>                   
            </tr>
            <tr>
                <td style="width: 47px">
                    <asp:Label id="Label1" runat="server" Text="End Date" font-names="Verdana" 
                        font-size="Small" width="136px"></asp:Label></td> 
                            <td colspan ="1" style="width: 473px">
                                <BDP:BasicDatePicker id="BasicDatePicker2" runat="server" ReadOnly="True" 
                                    width="180px">
                                </BDP:BasicDatePicker>
                </td>                   
            </tr>
            
            <tr>
                <td  style="width: 47px">
                    <asp:Label id="Label11" runat="server" Text="Holder Search" 
                        font-names="Verdana" font-size="Small" width="96px"></asp:Label></td> 
                            <td colspan ="1" style="width: 473px">
                                <asp:TextBox id="txtOrderSearch" runat="server"></asp:TextBox>
                                <asp:Button id="btnBatchSearch" runat="server" Text=">>" /></td>                   
            </tr>
                
            <tr>
                <td style="width: 47px">
                    </td> 
                            <td colspan ="1" style="width: 473px">
                                &nbsp;<asp:Label id="lblCompany" runat="server"></asp:Label>,
                                <asp:Label id="lblBatchshares" runat="server"></asp:Label></td>                   
            </tr>
            <tr>
                <td style="background-color: #ccccff">
                    </td>
                <td style="background-color: #ccccff">
                    <asp:Label id="Label7" runat="server" font-names="Verdana" font-size="Small" Text="Selected Order Details"
                        width="224px" font-bold="True"></asp:Label></td>
            </tr>
            <tr>
                <td  style="width: 47px; height: 21px;">
                    </td> 
                            <td colspan ="1" style="width: 473px; height: 21px;">
                                &nbsp;
                                <asp:Button id="btnApprove" runat="server" Text="Print" />
                                </td>                   
            </tr>
            <tr>
                <td style="background-color: #ccccff">
                    </td>
                <td style="background-color: #ccccff">
                    <asp:Label id="Label9" runat="server" font-names="Verdana" font-size="Small" Text="Order Summary"
                        width="376px" font-bold="True"></asp:Label></td>
            </tr>            
            <tr>
                <td>
                </td>
                <td>
                        <asp:GridView id="gdAddedHoldersto" runat="server" forecolor="#333333" CellPadding="4" GridLines="None" font-names="Arial" font-size="Small" width="704px">
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
                        &nbsp;
                    <asp:Button id="btnApproveall" runat="server" Text="Print All Orders Summary" />&nbsp;</td>
            </tr>
            <tr>
                <td></td>
                <td align="center">
                    &nbsp;</td>
            </tr>
            </table>          
        </td>
    </tr>
</table>
</asp:Panel>
</div>
</asp:Content>

