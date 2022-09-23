<%@ Page Language="VB" MasterPageFile="~/TSec.master" AutoEventWireup="false" CodeFile="TransactionReport.aspx.vb" Inherits="TSecReports_TransactionReport" title="Account Details Enquiry" %>
<asp:Content id="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div>
    <asp:Panel id="Panel1" runat="server">
    
<table style="border-right: #000033 thin solid; border-top: #000033 thin solid; border-left: #000033 thin solid; width: 832px; border-bottom: #000033 thin solid; background-color: #ffffff">
    <tr>
        <td style="width: 712px; height: 226px" valign="top">
            <table>
                <tr>
                    <td align="center" style="width: 870px">
                        <asp:Label id="Label4a" runat="server" backcolor="#8080FF" font-bold="True" 
                            font-names="Arial" Text="Company Schedule" width="848px"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="4" valign="top">
                        &nbsp;</td>
                </tr>
            <table>
                    <tr>
                <td style="width: 92px; height: 27px">
                    <asp:Label id="Label2" runat="server" font-bold="True" font-names="Arial" font-size="Small"
                        Text="Company"></asp:Label></td>
                <td style="height: 27px">
                    <asp:DropDownList id="cmbCompany" runat="server" TabIndex="1" width="205px">
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td style="width: 92px; height: 27px">
                    <asp:Label id="Label4" runat="server" font-bold="True" font-names="Arial" font-size="Small"
                        Text="DateFrom"></asp:Label></td>
                <td style="height: 27px">
                    <asp:TextBox id="dtpDateFrom" runat="server" ReadOnly="True" width="150px"></asp:TextBox>
                    <asp:Button id="Button3" runat="server" CausesValidation="False" TabIndex="2" Text="V" />
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td>
                    <asp:Calendar id="Calendar1" runat="server" backcolor="White" BorderColor="#3366CC"
                        BorderWidth="1px" CellPadding="1" DayNameFormat="Shortest" font-names="Verdana"
                        font-size="8pt" forecolor="#003399" Height="100px" TabIndex="4" Visible="False"
                        width="155px">
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
                <td style="width: 92px; height: 27px">
                    <asp:Label id="Label3" runat="server" font-bold="True" font-names="Arial" font-size="Small"
                        Text="DateTo"></asp:Label></td>
                <td style="height: 27px">
                    <asp:TextBox id="dtpDateTo" runat="server" ReadOnly="True" TabIndex="5" width="150px"></asp:TextBox>
                    <asp:Button id="Button1" runat="server" CausesValidation="False" TabIndex="6" Text="V" />
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td>
                    <asp:Calendar id="Calendar2" runat="server" backcolor="White" BorderColor="#3366CC"
                        BorderWidth="1px" CellPadding="1" DayNameFormat="Shortest" font-names="Verdana"
                        font-size="8pt" forecolor="#003399" Height="100px" TabIndex="7" Visible="False"
                        width="155px">
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
                <td align="center" bgcolor="slategray" colspan="2" style="height: 30px">
                    <asp:Button id="btnPrint" runat="server" backcolor="#E0E0E0" BorderColor="Black"
                        BorderStyle="Solid" TabIndex="8" Text="PRINT" width="80px" />
                </td>
            </tr>
            </table> 
            </tr>               
            </table>
</asp:Panel>
</div>
</asp:Content>

