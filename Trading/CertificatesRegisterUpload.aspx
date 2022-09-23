<%@ Page Language="VB" MasterPageFile="~/CDSUser.master" AutoEventWireup="false" CodeFile="CertificatesRegisterUpload.aspx.vb" Inherits="Trading_CertificatesRegisterUpload" title="Immobilization Upload" %>

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
                        Text="Certificates Upload" width="872px"></asp:Label></td>
            </tr>
            <tr>
                <td colspan="1" style="width: 15px; height: 11px;">
                    &nbsp;</td> 
                            <td colspan ="1" style="width: 473px; height: 11px;">
                                &nbsp;</td>                   
            </tr>
            <tr>
                <td colspan="1" style="width: 15px; height: 11px;">
                    <asp:Label id="Label3" runat="server" Text="Company" font-names="Verdana" font-size="Small"></asp:Label></td> 
                            <td colspan ="1" style="width: 473px; height: 11px;">
                                <asp:DropDownList id="cmbParaCompany" runat="server" width="176px">
                                </asp:DropDownList>
                                <asp:Label id="wk_path" runat="server" font-bold="True" Visible="False"></asp:Label>
                </td>                   
            </tr>
            
            <tr>
                <td colspan="1" style="width: 15px">
                    <asp:Label id="Label11" runat="server" Text="Batching Date" font-names="Verdana" font-size="Small" width="96px"></asp:Label></td> 
                            <td colspan ="1" style="width: 473px">
                                <BDP:BasicDatePicker id="BasicDatePicker1" runat="server" ReadOnly="True">
                                </BDP:BasicDatePicker>
                            </td>                   
            </tr>
                <tr>
                <td colspan="1" style="width: 15px">
                    <asp:Label id="Label17" runat="server" font-names="Verdana" font-size="Small" 
                        Text="File" width="96px"></asp:Label>
                    </td> 
                            <td colspan ="1" style="width: 473px">
                                <input id="fDocument" runat="server" onclick="return fDocument_onclick()" 
                                    style="width: 266px; height: 26px;" type="file" validationgroup="*.jpg" /><asp:TextBox 
                                    id="TextBox1" runat="server" Visible="False"></asp:TextBox></td>                   
            </tr>
            <tr>
                <td colspan="1" style="width: 15px; height: 23px;">
                    <asp:Label id="Label6" runat="server" font-names="Verdana" font-size="Small" Text="Upload Status"
                        width="112px"></asp:Label></td> 
                            <td colspan ="1" style="width: 473px; height: 23px;">
                                <asp:Label id="lblbatchref" runat="server" font-bold="True" font-names="Arial"
                                    width="88px"></asp:Label></td>                   
            </tr>
            <tr>
                <td style="height: 25px">
                    <asp:Label id="Label16" runat="server" font-names="Verdana" font-size="Small" 
                        Text="Upload id" width="112px"></asp:Label>
                </td>
                <td style="height: 25px">
                    <asp:Label id="lblUploadId" runat="server" font-bold="True" font-names="Arial" 
                        width="152px"></asp:Label>
                </td>
                
            </tr>
            <tr>
                <td colspan="1" style="width: 15px">
                    <asp:Label id="Label15" runat="server" Text="Options" font-names="Verdana" font-size="Small" width="80px"></asp:Label></td> 
                            <td colspan ="1" style="width: 473px">
                                <asp:Button id="btnSave" runat="server" Text="Upload File" />&nbsp;<asp:Button id="BtnUpdate"
                                    runat="server" Text="Delete Upload" Enabled="False" />&nbsp;</td>                   
            </tr>
            
            </table>
            <center>
            <table>
                
            </table>
            <table>
                <tr align="center">
                    <td style="width: 425px">
                        &nbsp;</td>
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
                    <td style="width: 850px" align="center">
                        </td>                
                </tr>
            </table>
        </td>
    </tr>
</table>
</asp:Panel>
</div>
</asp:Content>

