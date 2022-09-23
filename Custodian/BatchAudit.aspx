<%@ Page Language="VB" MasterPageFile="~/Tsec.master" AutoEventWireup="false" CodeFile="BatchAudit.aspx.vb" Inherits="Trading_BatchAudit" title="Batch Audit" %>

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
                <td>
                    <asp:RadioButton id="rdBatchAuth" runat="server" Text="Batch Authorization" GroupName ="AuditType" autopostback="True" font-names="Verdana" font-size="Small" /><asp:RadioButton id="rdAuthoriseAll" Text="Authorize All" GroupName="AuditType"
                        runat="server" autopostback="True" font-names="Verdana" font-size="Small" /></td>
            </tr>
            <tr>
                <td style="width: 870px" align="center" colspan="2">
                    <asp:Label id="Label4" runat="server" backcolor="#8080FF" font-bold="True" font-names="Arial"
                        Text="Batch Audit" width="872px"></asp:Label></td>
            </tr>
            <tr>
                <td style="width: 47px">
                    <asp:Label id="Label3" runat="server" Text="Selected Batch" font-names="Verdana" font-size="Small"></asp:Label></td> 
                            <td colspan ="1" style="width: 473px">
                                &nbsp;<asp:Label id="lblBatchSearch" runat="server"></asp:Label></td>                   
            </tr>
            <tr>
                <td style="width: 47px">
                    <asp:Label id="Label1" runat="server" Text="Batch Scroll Search" font-names="Verdana" font-size="Small" width="136px"></asp:Label></td> 
                            <td colspan ="1" style="width: 473px">
                                <asp:DropDownList id="CmbBatchNumber" runat="server" width="176px" autopostback="True">
                                </asp:DropDownList></td>                   
            </tr>
            
            <tr>
                <td  style="width: 47px">
                    <asp:Label id="Label11" runat="server" Text="Batch Search" font-names="Verdana" font-size="Small" width="96px"></asp:Label></td> 
                            <td colspan ="1" style="width: 473px">
                                <asp:TextBox id="txtBatchSearch" runat="server"></asp:TextBox>
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
                    <asp:Label id="Label7" runat="server" font-names="Verdana" font-size="Small" Text="Selected Batch Details"
                        width="224px" font-bold="True"></asp:Label></td>
            </tr>
            <tr>
                <td  style="width: 47px; height: 21px;">
                    </td> 
                            <td colspan ="1" style="width: 473px; height: 21px;">
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
                                &nbsp;
                                <asp:Button id="btnApprove" runat="server" Text="Approve Batch" />
                                <asp:Button id="btnDeclineBatch" runat="server" Text="Decline Batch" /></td>                   
            </tr>
            <tr>
                <td style="background-color: #ccccff">
                    </td>
                <td style="background-color: #ccccff">
                    <asp:Label id="Label9" runat="server" font-names="Verdana" font-size="Small" Text="Update Summary"
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
                    <asp:Button id="btnApproveall" runat="server" Text="Approve all" />&nbsp;<asp:Button
                        id="btnDeclineall" runat="server" Text="Decline All" /></td>
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

