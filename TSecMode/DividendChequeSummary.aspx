<%@ Page Language="VB" MasterPageFile="~/Tsec.master" AutoEventWireup="false" CodeFile="DividendChequeSummary.aspx.vb" Inherits="TsecMode_DividendChequeSummary" title="CDS Capture" %>
<asp:Content id="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
    <asp:Panel id="Panel1" runat="server" width="871px">
    
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
                        Text="Dividend Cheque Summary" width="850px" Height="19px"></asp:Label></td>
            </tr>
           
                
            </table>
<table border="0" cellpadding="0" cellspacing="0" id="TABLE1" onclick="return TABLE1_onclick()" style="left: 311px; position: relative; top: 0px" >
            <tr>
                <td style="height: 27px"   >
                  <asp:Label id="Label2" runat="server" font-bold="True" font-names="Arial" font-size="Small"
                        Text="Company" width="117px"></asp:Label></td>
                <td style="height: 27px" >
                    <asp:DropDownList id="cmb_company" runat="server" autopostback="True" width="205px" TabIndex="1" >
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td style="height: 27px"  >
                 <asp:Label id="lbl" runat="server" font-bold="True" font-names="Arial" font-size="Small"
                        Text="Event No"></asp:Label></td>
                <td style="height: 27px"  >
                <asp:DropDownList id="txt_eventno" runat="server" 
             width="205px" autopostback="True" TabIndex="2">
        </asp:DropDownList>
                 </td> 
            </tr>
            <tr>
                <td style="height: 27px"  >
                  <asp:Label id="Label1" runat="server" font-bold="True" font-names="Arial" font-size="Small"
                        Text="Event Description"></asp:Label></td>
               
                    <td style="height: 27px" >
                    <asp:textbox id="txt_eventdesc" runat="server" 
                       Enabled="False" font-bold="True" ReadOnly="True" width="200px" TabIndex="3"></asp:textbox></td>
            </tr>
            <tr>
                <td align="center" bgcolor="slategray" colspan="2" style="height: 30px" >
                    <asp:Button id="btn_Print" runat="server" backcolor="#E0E0E0" BorderColor="Black"
                        BorderStyle="Solid"  Text="PRINT" TabIndex="4" /></td>
            </tr>
        </table>
        </td>
    </tr>
</table>
</asp:Panel>
</div>
</asp:Content>

