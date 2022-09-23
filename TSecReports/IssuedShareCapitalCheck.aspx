<%@ Page Language="VB" MasterPageFile="~/TSec.master" AutoEventWireup="false" CodeFile="IssuedShareCapitalCheck.aspx.vb" Inherits="TSecReports_IssuedShareCapitalCheck" title="Account Details Enquiry" %>
<asp:Content id="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div>
    <asp:Panel id="Panel1" runat="server">
    
<table style="border-right: #000033 thin solid; border-top: #000033 thin solid; border-left: #000033 thin solid; width: 832px; border-bottom: #000033 thin solid; background-color: #ffffff">
<tr>
                <td style="width: 129px; height: 27px" >
                    <asp:Label id="Label2" runat="server" font-bold="True" font-names="Arial" font-size="Small"
                        Text="Company"></asp:Label></td>
                <td style="height: 27px" >
                    <asp:DropDownList id="cmbCompany" runat="server"  autopostback="True" width="205px" TabIndex="1" >
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td style="height: 27px" >
                    <asp:Label id="Label1" runat="server" font-bold="True" font-names="Arial" font-size="Small"
                        Text="Date"></asp:Label></td>
                <td style="height: 27px">
                      <asp:TextBox id="txtFromDate" runat="server" width="150px" TabIndex="2"></asp:TextBox>
                    <asp:Button id="btnFromDate" runat="server" Text="V" CausesValidation="False" TabIndex="3"  /></td>
            </tr>
              <tr>
            <td>
            
            </td>
            <td>
            <asp:Calendar id="cal1" runat="server" backcolor="White" BorderColor="#3366CC"
                        BorderWidth="1px" CellPadding="1" DayNameFormat="Shortest" font-names="Verdana"
                        font-size="8pt" forecolor="#003399" Height="100px" width="155px" Visible="False" TabIndex="4">
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
            
            </td>
            <td>
                &nbsp;</td>
            </tr>
            <tr>
                <td colspan="2" align="center" style="background-color: slategray">
                    <asp:Button id="btnUpdate" runat="server" Text="PRINT" backcolor="#E0E0E0" BorderColor="Black" /></td>
               
            </tr>
                
            </table>
</asp:Panel>
</div>
</asp:Content>

