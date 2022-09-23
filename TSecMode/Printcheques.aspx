<%@ Page Language="VB" MasterPageFile="~/Tsec.master" AutoEventWireup="false" CodeFile="Printcheques.aspx.vb" Inherits="TsecMode_Printcheques" title="CDS Capture" %>
<asp:Content id="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
    <asp:Panel id="Panel1" runat="server" width="869px">
    
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
                        Text="Print Cheques" width="850px" Height="19px"></asp:Label></td>
            </tr>
           
                
            </table>
            <table style="left: 0px; position: relative; top: 0px">
    <tr>
    <td align="left" style="width: 664px">
    
   <table  border="0" cellpadding="0" cellspacing="0">
   
            <tr>
                <td style="width: 179px; height: 27px" >
                    <asp:Label id="Label2" runat="server" Text="Company" font-bold="True" font-names="Arial" font-size="Small"></asp:Label></td>
                <td style="height: 27px" >
                    <asp:DropDownList id="dr_company" runat="server"  autopostback="True" width="205px" TabIndex="1">
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td style="width: 179px; height: 27px" >
                    <asp:Label id="lbl" runat="server" Text="Dividend No"  font-bold="True" font-names="Arial" font-size="Small"></asp:Label></td>
                <td style="height: 27px" >
                    <asp:DropDownList id="dr_divno" runat="server"  width="205px" autopostback="True" TabIndex="2">
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td style="width: 179px; height: 27px" >
                    <asp:Label id="Label1" runat="server" Text="Industry"  font-bold="True" font-names="Arial" font-size="Small"></asp:Label></td>
                <td style="height: 27px" >
                    <asp:DropDownList id="Dr_industry" runat="server"  width="205px" TabIndex="3">
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td style="width: 179px" >
                    <asp:Label id="Label5" runat="server" Text="Restart At Cheque Number"  font-bold="True" font-names="Arial" font-size="Small"></asp:Label></td>
                <td >
                    <asp:TextBox id="txt_cheqno" runat="server" 
                        width="200px" TabIndex="4"></asp:TextBox>
                        </td>
                        </tr>
            <tr>
                <td style="width: 179px">
                </td>
                <td>
                    <asp:RadioButtonList id="rbl" runat="server" autopostback="True">
                        <asp:ListItem Selected="True" Value="0">Non Mandated</asp:ListItem>
                        <asp:ListItem Value="1">Mandated</asp:ListItem>
                    </asp:RadioButtonList></td>
            </tr>
                        <tr>
                        <td colspan=2 align=right >
                    <asp:Label id="Label7" runat="server" font-bold="True" 
                         Text="Only If Cheque Numbers have already been entered" width="365px"></asp:Label></td>
            </tr>
            <tr>
                <td align="center" colspan="2"  bgcolor="slategray" style="height: 30px">
                    <asp:Button id="Button1" runat="server" BorderStyle="Solid" 
                        Text="PRINT" backcolor="#E0E0E0" BorderColor="Black" TabIndex="5"/></td>
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

