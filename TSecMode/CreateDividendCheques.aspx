<%@ Page Language="VB" MasterPageFile="~/Tsec.master" AutoEventWireup="false" CodeFile="CreateDividendCheques.aspx.vb" Inherits="TsecMode_CreateDividendCheques" title="CDS Capture" %>
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
                        Text="Dividend Cheque Numbers Creation" width="846px" Height="19px"></asp:Label></td>
            </tr>
           
                
            </table>
            <table style="left: 0px; position: relative; top: 0px">
    <tr>
    <td align="center" style="width: 664px">
    
   <table  border="0" cellpadding="0" cellspacing="0" >
            
            <tr>
                <td style="height: 27px" align="left">
                   
                    <asp:Label id="Label5" runat="server" font-bold="True" font-names="Arial" font-size="Small"
                         Text="Company"></asp:Label>
                </td>
                <td style="height: 27px" align="left">
                    <asp:DropDownList id="dr_company" runat="server" width="208px" autopostback="True" TabIndex="1" >
                    </asp:DropDownList>
                    </td>
            </tr>
            <tr>
                <td style="height: 27px" align="left">
                    <asp:Label id="Label1" runat="server" 
                        Text="Dividend No" font-bold="True" font-names="Arial" font-size="Small" width="80px"></asp:Label></td>
                <td style="height: 27px" align="left">
                   
                    <asp:DropDownList id="dr_divno" runat="server" AppendDataBoundItems="True"
                         width="208px" autopostback="True" TabIndex="2">
                    </asp:DropDownList>
                    
                 
                  
                    
                </td>
            </tr>
             <tr>
                <td style="height: 27px" align="left">
                </td>
                <td style="height: 27px" align="left">
                    <asp:RadioButtonList id="rbl" runat="server" autopostback="True">
                        <asp:ListItem Selected="True" Value="0">Non Mandated</asp:ListItem>
                        <asp:ListItem Value="1">Mandated</asp:ListItem>
                    </asp:RadioButtonList></td>
            </tr>
            <tr>
            <td valign="top" style="height: 102px" align="left">
            <asp:Label id="lbl" runat="server"  Text="Industry" font-bold="True" font-names="Arial" font-size="Small"></asp:Label>
            </td>
            <td style="height: 102px" align="left">
               <asp:ListBox id="dr_industry" runat="server" autopostback="True" Height="96px" SelectionMode="Multiple"
                        width="205px" TabIndex="3"></asp:ListBox>
            </td>
            </tr>
            <tr>
            <td style="height: 27px" align="left">
             <asp:Label id="Label7" runat="server" font-bold="True" font-names="Arial" font-size="Small"
                       Text="Total Cheques"
                        width="104px"></asp:Label>
            </td>
            <td style="height: 27px" align="left">
            <asp:TextBox id="dr_name" runat="server" Enabled="False" font-bold="True"  width="200px" TabIndex="4"></asp:TextBox>
            </td>
            </tr>
            <tr>
            <td style="height: 27px" align="left">
                &nbsp;</td>
            <td style="height: 27px" align="left">
            <asp:CheckBox id="CheckBox1" runat="server" autopostback="True" font-bold="True"
                        font-names="Arial" 
                        Text="All Industries" width="113px" font-size="Small" TabIndex="5" /></td>
            </tr>
            <tr>
                <td style="height: 27px"  align="left">
                    <asp:Label id="Label6" runat="server" 
                        Text="First Cheque Number?" font-bold="True" font-names="Arial" font-size="Small"></asp:Label>
                    </td>
                <td style="height: 27px"  align="left">
                    <asp:TextBox id="txt_firstcheqno" runat="server"  TabIndex="6" width="200px"></asp:TextBox>
                    
                    <asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" ControlToValidate="txt_firstcheqno"
                        ErrorMessage="First Cheque No?"  width="137px"></asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td style="height: 27px" align="left">
                    <asp:Label id="Label2" runat="server"
                        Text="Last Cheque Number?" font-bold="True" font-names="Arial" font-size="Small"></asp:Label>
                    &nbsp;
                </td>
                <td style="height: 27px"  align="left">
                    <asp:TextBox id="txt_lastchequeno" runat="server"  TabIndex="7" width="200px"></asp:TextBox>
                    <asp:RequiredFieldValidator id="RequiredFieldValidator2" runat="server" ControlToValidate="txt_lastchequeno"
                        ErrorMessage="Last Cheque No?" width="176px"></asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td style="height: 27px" align="left">
                    <asp:Label id="Label8" runat="server" font-bold="True" font-names="Arial" font-size="Small"
                        Text="Last Cheque Number Allocated"></asp:Label></td>
                <td style="height: 27px" align="left">
                    <asp:TextBox id="txtLastCheckAllocated" runat="server" TabIndex="7" width="200px" Enabled="False"></asp:TextBox></td>
            </tr>
           
            <tr>
            <td style="height: 27px" align="left">
            
            </td>
            <td style="height: 27px" align="left">
            <asp:CompareValidator id="CompareValidator1" runat="server" ControlToCompare="txt_firstcheqno"
            ControlToValidate="txt_lastchequeno" ErrorMessage="Last Cheque No Should be Greater Than first cheque No"
            Operator="GreaterThanEqual"  Type="Double" ValueToCompare="0" width="351px" Height="17px"></asp:CompareValidator>
            </td>
            </tr>
            <tr>
                <td align="center" colspan="2"  style="height: 30px">
                    <asp:Button id="Button1" runat="server" BorderStyle="Solid"  Text="PROCESS" backcolor="#E0E0E0" BorderColor="Black" TabIndex="8"/></td>
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

