<%@ Page Language="VB" MasterPageFile="~/TSec.master" AutoEventWireup="false" CodeFile="AuditandReports.aspx.vb" Inherits="TSecAudit_AuditandReports" title="Account Details Enquiry" %>
<asp:Content id="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div>
    <asp:Panel id="Panel1" runat="server">
    
<table style="border-right: #000033 thin solid; border-top: #000033 thin solid; border-left: #000033 thin solid; width: 832px; border-bottom: #000033 thin solid; background-color: #ffffff">
    <tr>
        <td style="width: 712px; height: 226px" valign="top">
            <table>
            <tr>
                <td style="width: 870px" align="center">
                    <asp:Label id="Label4" runat="server" backcolor="#8080FF" font-bold="True" font-names="Arial"
                        Text="Audit Reports" width="848px"></asp:Label></td>
            </tr>
            <tr>
                    <td colspan ="4" valign="top">
                        &nbsp;</td>
                </tr>
                
            </table>
            
            <table>
             <tr>
                   <td style="height: 21px">
                       <asp:Label id="Label2" runat="server" font-bold="True" font-names="Arial" font-size="Small"
                           Text="Company"></asp:Label></td>
                   <td style="height: 21px">
                       <asp:DropDownList id="cmbCompany" runat="server" font-bold="False" width="183px" TabIndex="6">
                       </asp:DropDownList></td>
                   </tr>
            <tr>
                <td >
                <asp:Label  runat ="server" id="lblfrom" Text ="From Date" font-bold="True" font-names="Arial" font-size="Small"></asp:Label>
                </td>
                <td >
                     <asp:TextBox id="txtfrom" runat="server" width="150px" ReadOnly="True"></asp:TextBox>
                    <asp:Button id="Button3" runat="server" Text="V" CausesValidation="False" TabIndex="1"  /></td>
            </tr>
            
             <tr>
            <td>
            
            </td>
            <td>
            <asp:Calendar id="Calendar1" runat="server" backcolor="White" BorderColor="#3366CC"
                        BorderWidth="1px" CellPadding="1" DayNameFormat="Shortest" font-names="Verdana"
                        font-size="8pt" forecolor="#003399" Height="100px" width="155px" Visible="False" TabIndex="2">
                        <SelectedDayStyle backcolor="#009999" font-bold="True" forecolor="#CCFF99" />
                        <TodayDayStyle backcolor="#99CCCC" forecolor="White" />
                        <SelectorStyle backcolor="#99CCCC" forecolor="#336666" />
                        <WeekendDayStyle backcolor="#CCCCFF" />
                        <OtherMonthDayStyle forecolor="#999999" />
                        <NextPrevStyle font-size="8pt" forecolor="#CCCCFF" />
                        <DayHeaderStyle backcolor="#99CCCC" forecolor="#336666" Height="1px" />
                        <TitleStyle backcolor="#003399" BorderColor="#3366CC" BorderWidth="1px" font-bold="True"
                            font-size="10pt" forecolor="#CCCCFF" Height="25px" />
                    </asp:Calendar>
            </td>
            </tr>
            <tr>
                <td >
                <asp:Label  runat ="server" id="lblTo" Text ="To Date" font-bold="True" font-names="Arial" font-size="Small"></asp:Label>
                </td>
                <td>
                     <asp:TextBox id="txtto" runat="server" width="150px" ReadOnly="True" TabIndex="3"></asp:TextBox>
                    <asp:Button id="Button1" runat="server" Text="V" CausesValidation="False" TabIndex="4"  /></td>
                    </tr>
                    
                     <tr>
            <td>
            
            </td>
            <td>
            <asp:Calendar id="Calendar2" runat="server" backcolor="White" BorderColor="#3366CC"
                        BorderWidth="1px" CellPadding="1" DayNameFormat="Shortest" font-names="Verdana"
                        font-size="8pt" forecolor="#003399" Height="100px" width="155px" Visible="False" TabIndex="5">
                        <SelectedDayStyle backcolor="#009999" font-bold="True" forecolor="#CCFF99" />
                        <TodayDayStyle backcolor="#99CCCC" forecolor="White" />
                        <SelectorStyle backcolor="#99CCCC" forecolor="#336666" />
                        <WeekendDayStyle backcolor="#CCCCFF" />
                        <OtherMonthDayStyle forecolor="#999999" />
                        <NextPrevStyle font-size="8pt" forecolor="#CCCCFF" />
                        <DayHeaderStyle backcolor="#99CCCC" forecolor="#336666" Height="1px" />
                        <TitleStyle backcolor="#003399" BorderColor="#3366CC" BorderWidth="1px" font-bold="True"
                            font-size="10pt" forecolor="#CCCCFF" Height="25px" />
                    </asp:Calendar>
            </td>
            </tr>
            <tr>
                <td>
                    <asp:Label id="Label3" runat="server" font-bold="True" font-names="Arial" font-size="Small"
                        Text="Audit Status"></asp:Label></td>
                <td>
                    <asp:DropDownList id="ddlStatus" runat="server" width="130px">
                        <asp:ListItem Value="0">UnAudited</asp:ListItem>
                        <asp:ListItem Value="1">Audited</asp:ListItem>
                        <asp:ListItem Value="2">All</asp:ListItem>
                    </asp:DropDownList></td>
            </tr>
                    
                  
                <tr>
                <td colspan ="2">
                    <asp:RadioButtonList id="RadioButtonList1" runat="server" font-bold="True" font-names="Arial" font-size="Small" TabIndex="7">
                        <asp:ListItem Value="0">Transfer Schedule</asp:ListItem>
                        <asp:ListItem Value="1">Mandates Schedule</asp:ListItem>
                        <asp:ListItem Value="2">Certificate Schedule</asp:ListItem>
                        <asp:ListItem Value ="3">Names and Address Schedule</asp:ListItem>
                        <asp:ListItem Value="4">Unpaid Cheques</asp:ListItem>
                        <asp:ListItem Value="5">CDS Certificates Schedule</asp:ListItem>
                    </asp:RadioButtonList></td>
                </tr>
                <tr>
                <td align ="center" COLSPAN="2" height: 30px;">
                <asp:Button runat ="server" id="btnPrint" Text="Show" BorderColor="Black" backcolor="#E0E0E0" TabIndex="8" />
                </td>
                </tr>
            </table>
            <table>
                <tr>
                    <td colspan ="1" style="width: 147px">
                        </td>
                        <td colspan="1" style="width: 203px">
                            </td>
                            <td colspan ="1" style="width: 172px">
                                </td>
                                <td colspan ="1" style="width: 316px">
                                    </td>
                </tr>
                
            </table>
            
        </td>
    </tr>
</table>
</asp:Panel>
</div>
</asp:Content>

