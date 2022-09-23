<%@ Page Language="VB" MasterPageFile="~/TSec.master" AutoEventWireup="false" CodeFile="TransferBatch.aspx.vb" Inherits="TSecTrading_TransferBatch" title="Batch Receipting" %>

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
                        text="Transfer Batch Processing" width="852px"></asp:Label></td>
            </tr>
            <tr>
                <td style="width: 47px">
                    <asp:Label id="Label3" runat="server" text="Selected Batch" width="143px" 
                        font-names="Verdana" font-size="Small"></asp:Label></td> 
                            <td colspan ="1" style="width: 473px">
                                &nbsp;<asp:Label id="lblBatchSearch" runat="server"></asp:Label></td>                   
            </tr>
            <tr>
                <td style="width: 47px">
                    <asp:Label id="Label1" runat="server" text="Batch Scroll Search" font-names="Verdana" font-size="Small" width="136px"></asp:Label></td> 
                            <td colspan ="1" style="width: 473px">
                                <asp:DropDownList id="CmbBatchNumber" runat="server" width="176px" autopostback="True">
                                </asp:DropDownList></td>                   
            </tr>
            
            <tr>
                <td  style="width: 47px">
                    <asp:Label id="Label11" runat="server" text="Batch Search" font-names="Verdana" font-size="Small" width="96px"></asp:Label></td> 
                            <td colspan ="1" style="width: 473px">
                                <asp:TextBox id="txtBatchSearch" runat="server"></asp:TextBox>
                                <asp:Button id="btnBatchSearch" runat="server" Text=">>" /></td>                   
            </tr>
                <tr>
                <td style="width: 47px; height: 26px;">
                    <asp:Label id="Label12" runat="server" Text="Batch Shares" font-names="Verdana" 
                        font-size="Small" width="141px"></asp:Label></td> 
                            <td colspan ="1" style="width: 473px; height: 26px;">
                                <asp:TextBox id="txtBatchShares" runat="server" ReadOnly="True"></asp:TextBox></td>                   
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
                    <asp:Label id="Label7" runat="server" font-names="Verdana" font-size="Small" Text="Transfer Shares from"
                        width="376px" font-bold="True"></asp:Label></td>
            </tr>
            <tr>
                <td  style="width: 47px">
                    <asp:Label id="Label2" runat="server" font-names="Verdana" font-size="Small" Text="holder Number Search"
                        width="179px"></asp:Label></td> 
                            <td colspan ="1" style="width: 473px">
                                &nbsp;<asp:TextBox id="txtHolderSearch" runat="server"></asp:TextBox><asp:Button id="btnNumSearch" runat="server" Text=">>" /></td>                   
            </tr>
            <tr>
                <td style="width: 47px">
                    <asp:Label id="Label5" runat="server" font-names="Verdana" font-size="Small" Text="Name Search"
                        width="140px"></asp:Label></td> 
                            <td colspan ="1" style="width: 473px">
                                &nbsp;<asp:TextBox id="txtNameSearch" runat="server"></asp:TextBox><asp:Button id="btnNameSearch" runat="server" Text=">>" /></td>                   
            </tr>
            <tr>
                <td  style="width: 47px">
                    <asp:Label id="Label6" runat="server" font-names="Verdana" font-size="Small" Text="Batch Shares"
                        width="160px"></asp:Label></td> 
                            <td colspan ="1" style="width: 473px">
                                &nbsp;<asp:ListBox id="lstNames" runat="server" width="407px" Height="51px"></asp:ListBox></td>                                                   
                                
            </tr>
            <tr>
                <td></td>
                <td>
                    &nbsp;<asp:Button id="btnSelectFrom" runat="server" Text="Select" /></td>
            </tr>
            <tr>
                <td></td>
                <td>
                    &nbsp;<asp:Label id="lblNames" runat="server" Text=""></asp:Label><asp:Label id="lblholderNum"
                        runat="server" Text=""></asp:Label></td>
            </tr>
            <tr>
                <td></td>
                <td>
                    <asp:Label id="Label8" runat="server" Text="Shares:"></asp:Label><asp:TextBox id="txtSharesTo"
                        runat="server"></asp:TextBox><asp:Button id="BtnAdd" runat="server" Text="Add" /></td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:GridView id="grdAddedCertificate" runat="server" CellPadding="4" 
                        font-names="Arial" font-size="Small" forecolor="#333333" GridLines="None" 
                        width="704px">
                        <FooterStyle backcolor="#507CD1" font-bold="True" forecolor="White" />
                        <Columns>
                            <asp:TemplateField HeaderText="SELECT">
                                <ItemTemplate>
                                    <asp:CheckBox id="checkbox1" runat="server" />
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
                    &nbsp;
                    <asp:Button id="btnDelFrom" runat="server" Text="Remove Holder" />
                </td>
            </tr>
            
            <tr>
                <td style="background-color: #ccccff">
                    </td>
                <td style="background-color: #ccccff">
                    <asp:Label id="Label9" runat="server" font-names="Verdana" font-size="Small" Text="Transfer Shares to:"
                        width="376px" font-bold="True"></asp:Label></td>
            </tr>
            <tr>
                <td  style="width: 47px">
                    <asp:Label id="Label10" runat="server" font-names="Verdana" font-size="Small" Text="holder Number Search"
                        width="173px"></asp:Label></td> 
                            <td colspan ="1" style="width: 473px">
                                &nbsp;<asp:TextBox id="txtToHolderNum" runat="server"></asp:TextBox><asp:Button id="btnHolderNumto" runat="server" Text=">>" /></td>                   
            </tr>
            <tr>
                <td style="width: 47px">
                    <asp:Label id="Label13" runat="server" font-names="Verdana" font-size="Small" Text="Name Search"
                        width="154px"></asp:Label></td> 
                            <td colspan ="1" style="width: 473px">
                                &nbsp;<asp:TextBox id="txtHolderNameTo" runat="server"></asp:TextBox><asp:Button id="btnHolderNameto" runat="server" Text=">>" /></td>                   
            </tr>
            <tr>
                <td  style="width: 47px">
                    <asp:Label id="Label15" runat="server" font-names="Verdana" font-size="Small" Text="Select a Name"
                        width="158px"></asp:Label></td> 
                            <td colspan ="1" style="width: 473px">
                                &nbsp;<asp:ListBox id="lstNameTo" runat="server" width="404px" Height="52px"></asp:ListBox></td>                                                   
                                
            </tr>
            <tr>
                <td></td>
                <td>
                    &nbsp;<asp:Button id="btnSelectTo" runat="server" Text="Select" /></td>                
            </tr>
            <tr>
                <td></td>
                <td>
                    &nbsp;<asp:Label id="lblNameTo" runat="server"></asp:Label><asp:Label id="lblNumberto"
                        runat="server"></asp:Label></td>
            </tr>
            <tr>
                <td></td>
                <td>
                    <asp:Label id="Label19" runat="server" Text="Shares:"></asp:Label><asp:TextBox id="txtSharestrans"
                        runat="server"></asp:TextBox><asp:Button id="btnAddto" runat="server" Text="Add" /></td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:GridView id="gdAddedHoldersto" runat="server" CellPadding="4" 
                        font-names="Arial" font-size="Small" forecolor="#333333" GridLines="None" 
                        width="704px">
                        <FooterStyle backcolor="#507CD1" font-bold="True" forecolor="White" />
                        <Columns>
                            <asp:TemplateField HeaderText="SELECT">
                                <ItemTemplate>
                                    <asp:CheckBox id="checkbox1" runat="server" />
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
                    &nbsp;
                    <asp:Button id="btnDelto" runat="server" Text="Remove Holder" />
                </td>
            </tr>
            <tr>
                <td></td>
                <td align="center">
                    <asp:Button id="BtnSaveTrans" runat="server" Text="Save Trans" /> 
                    <asp:Button id="BtnCancelTrans" runat="server" Text="Cancel Trans" /></td>
            </tr>
            </table>          
        </td>
    </tr>
</table>
</asp:Panel>
</div>
</asp:Content>

