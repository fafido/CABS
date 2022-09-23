<%@ Page Language="VB" MasterPageFile="~/Tsec.master" AutoEventWireup="false" CodeFile="DividendReconciliation.aspx.vb" Inherits="TsecMode_DividendReconciliation" title="CDS Capture" %>
<asp:Content id="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
    <asp:Panel id="Panel1" runat="server" width="865px">
    
<table style="border-right: #000033 thin solid; border-top: #000033 thin solid; border-left: #000033 thin solid; width: 832px; border-bottom: #000033 thin solid; background-color: #ffffff">
    <tr>
        <td style="width: 659px; height: 226px" valign="top">
            <table>
            <tr>
                <td>
                    <asp:Label id="lblsitemap" runat="server"></asp:Label></td>
            </tr>
            
           
                
            </table>
            <table style="left: 0px; position: relative; top: 0px; width: 840px;">
    <tr>
    <td align="left" style="width: 664px">
    
    <table border="0" cellpadding="0" cellspacing="0"  >
          
            <tr>
                <td style="width: 118px; height: 27px" >
                    <asp:Label id="Label2" runat="server" Text="Company" font-bold="True" Font-Italic="False" font-names="Arial" font-size="Small"></asp:Label></td>
                <td style="height: 27px" >
                    <asp:DropDownList id="cmbCompany" runat="server"  autopostback="True" width="205px" TabIndex="1">
                    </asp:DropDownList></td>
               
            </tr>
            <tr>
                <td style="width: 118px; height: 27px" >
                    <asp:Label id="lbl" runat="server" Text="Dividend Number"  font-bold="True" Font-Italic="False" font-names="Arial" font-size="Small"></asp:Label></td>
                <td style="height: 27px" >
                    <asp:DropDownList id="cmbDiviNo" runat="server" width="205px" TabIndex="2">
                    </asp:DropDownList></td>
              
            </tr>
            <tr>
            <td style="width: 118px; height: 27px">
                <asp:Label id="Label1" runat="server" Text="Event Id" font-bold="True"></asp:Label>
            </td>
            <td>
                <asp:DropDownList id="txtEventId" runat="server" width="205px">
                </asp:DropDownList></td>
            </tr>
            <tr>
                <td  colspan="2" align="center">
                    <asp:Button id="Button1" runat="server" Text="PROCESS" BorderStyle="Solid" backcolor="#E0E0E0" BorderColor="Black" TabIndex="3" /></td>
              
              
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

