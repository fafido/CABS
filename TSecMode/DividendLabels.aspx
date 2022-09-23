<%@ Page Language="VB" MasterPageFile="~/Tsec.master" AutoEventWireup="false" CodeFile="DividendLabels.aspx.vb" Inherits="TsecMode_DividendLabels" title="CDS Capture" %>
<asp:Content id="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
    <asp:Panel id="Panel1" runat="server" width="868px">
    
<table style="border-right: #000033 thin solid; border-top: #000033 thin solid; border-left: #000033 thin solid; width: 832px; border-bottom: #000033 thin solid; background-color: #ffffff">
    <tr>
        <td style="width: 634px; height: 226px" valign="top">
            <table>
            <tr>
                <td>
                    <asp:Label id="lblsitemap" runat="server"></asp:Label></td>
            </tr>
            <tr>
                <td style="width: 870px" align="center">
                    <asp:Label id="Label4" runat="server" backcolor="#8080FF" font-bold="True" font-names="Arial"
                        Text="Dividend Labels" width="847px" Height="19px"></asp:Label></td>
            </tr>
           
                
            </table>
            <table style="left: 0px; position: relative; top: 0px">
    <tr>
    <td align="left" style="width: 664px">
    
  <table  border="0"
            cellpadding="0" cellspacing="0">
            
            <tr>
                <td style="height: 27px; width: 108px;" >
                   <asp:Label id="Label2" runat="server" font-bold="True"
                        font-names="Arial" font-size="Small" Text="Company"></asp:Label></td>
                <td style="width: 162px; height: 27px" >
                   
                    <asp:DropDownList id="cmbcompany" runat="server" autopostback="True" width="205px" TabIndex="1">
                    </asp:DropDownList>
                  
                </td>
            </tr>
            <tr >
                <td style="height: 27px; width: 108px;" >
                   
                    <asp:Label id="Label1" runat="server" font-bold="True" font-names="Arial" font-size="Small"
                        Text="Dividend No"></asp:Label></td>
                <td style="width: 162px; height: 27px;" >
                    
                    <asp:DropDownList id="cmbdivino" runat="server" width="205px" TabIndex="2">
                    </asp:DropDownList>
                    
                </td>
            </tr>
            <tr >
                <td align="center" bgcolor="slategray" colspan="2" style="height: 30px" >
                  
                    <asp:Button id="btn_print" runat="server" OnClientClick="javascript:newwindow();"
                        Text="PRINT" backcolor="#E0E0E0" BorderColor="Black" TabIndex="3" />
                   
                </td>
            </tr>
        </table>
    
    </td>
    </tr>
    <tr>
    <td style="width: 664px">
    <br />
    </td>
    </tr>
    <tr>
    <td style="width: 664px">
        &nbsp;</td>
    </tr>
    <tr>
    <td style="width: 664px">
        &nbsp;</td>
    </tr>
    <tr>
    <td style="width: 664px">
        &nbsp;</td>
    </tr>
    </table>
        </td>
    </tr>
</table>
</asp:Panel>
</div>
</asp:Content>

