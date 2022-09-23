<%@ Page Language="VB" MasterPageFile="~/CDSuser.master" AutoEventWireup="false" CodeFile="DepositoryVerification2.aspx.vb" Inherits="CDSMode_DepositoryVerification2" title="Batch Verification" %>

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
                        Text="Deposited Certficates Verification" width="852px"></asp:Label></td>
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
                    <asp:Label id="Label3" runat="server" Text="Select Batch" font-names="Verdana" font-size="Small" width="88px"></asp:Label></td> 
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
                <td colspan="1" style="width: 15px">
                    <asp:Label id="Label11" runat="server" Text="Batching Date" font-names="Verdana" font-size="Small" width="96px"></asp:Label></td> 
                            <td colspan ="1" style="width: 473px">
                                <asp:Label id="LblBatchDate" runat="server"></asp:Label></td>                   
            </tr>
                <tr>
                <td colspan="1" style="width: 15px">
                    <asp:Label id="Label12" runat="server" Text="Batch Total" font-names="Verdana" font-size="Small" width="128px"></asp:Label></td> 
                            <td colspan ="1" style="width: 473px">
                                <asp:Label id="lblBatchTotal" runat="server"></asp:Label></td>                   
            </tr>
            <tr>
                <td colspan="1" style="width: 15px">
                    <asp:Label id="Label6" runat="server" font-names="Verdana" font-size="Small" Text="Batch Ref"
                        width="88px"></asp:Label></td> 
                            <td colspan ="1" style="width: 473px">
                                <asp:Label id="lblbatchref" runat="server" font-bold="True" font-names="Arial"
                                    width="152px"></asp:Label></td>                   
            </tr>       
            <tr>
                <td><asp:Label id="Label1" runat="server" font-size="Small" font-names="Verdana" width="128px" Text="Batch Captured By"></asp:Label></td>
                <td>
                    <asp:Label id="lblBatchBy" runat="server" Text=""></asp:Label></td>
            </tr>     
            <tr>
                <td><asp:Label id="Label2" runat="server" font-size="Small" font-names="Verdana" width="128px" Text="Broker Code"></asp:Label></td>
                <td>
                    <asp:Label id="lblBrokercode" runat="server" Text=""></asp:Label></td>
            </tr>
            </table>
            <center>
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
                                <td style="border: thin solid #cccccc; " colspan ="2">
                                    <asp:RadioButton id="rdApproveAll" runat="server" GroupName="ApprovalSet" 
                                        Text="Approve All" />
                                    <asp:RadioButton id="rdApproveAll0" runat="server" GroupName="ApprovalSet" 
                                        Text="Approve Individual Certificates" />
                                </td>
                                
                            </tr>
                            <tr align="center">                                                             
                                <td style="border: thin solid #cccccc; width: 329px; ">
                                    <asp:Button id="btnForward" runat="server" Text="Approve " /></td>
                                <td style="border: thin solid #cccccc; width: 407px; ">
                                    <asp:Button id="btnDecline" runat="server" Text="Decline " /></td>
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

