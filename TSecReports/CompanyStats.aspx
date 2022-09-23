<%@ Page Language="VB" MasterPageFile="~/TSec.master" AutoEventWireup="false" CodeFile="CompanyStats.aspx.vb" Inherits="TSecReports_CompanyStats" title="Account Details Enquiry" %>
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
                <td style="height: 27px; width: 104px;"  >
                      <asp:Label id="Label5" runat="server" 
                      Text="Company" font-bold="True" font-names="Arial" font-size="Small"></asp:Label></td>
                <td style="height: 27px"  >
                    <asp:DropDownList id="cmbCompany" runat="server" width="205px" TabIndex="1" >
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td style="width: 104px; height: 27px"  >
                    <asp:Label id="Label7" runat="server" 
                        Text="Date" font-bold="True" font-names="Arial" font-size="Small"></asp:Label></td>
                <td style="height: 27px"  >
                      <asp:TextBox id="dtpDateCreated" runat="server" width="150px" TabIndex="2"></asp:TextBox>
                    <asp:Button id="Button3" runat="server" Text="V" CausesValidation="False" TabIndex="3"  /></td>
                    
            </tr>
            
            
            <tr>
            <td>
            
            </td>
            <td>
            <asp:Calendar id="Calendar1" runat="server" backcolor="White" BorderColor="#3366CC"
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
                <td colspan="2" style="height: 27px" align="center" >
                    <asp:Panel id="Panel1a" runat="server" backcolor="ControlLight" Height="32px" 
                      width="392px">
                        <asp:RadioButton id="rdbIndustry" runat="server" font-bold="True" font-names="Arial"
                            font-size="Small" GroupName="vimal" 
                         Text="Industry" TabIndex="5" />
                        <asp:RadioButton id="rdbShareHolding" runat="server" font-bold="True" font-names="Arial"
                            font-size="Small" GroupName="vimal" 
                             Text="Ranges" TabIndex="6" />
                        <asp:RadioButton id="rdbCountry" runat="server" font-bold="True" font-names="Arial"
                            font-size="Small" GroupName="vimal" 
                        Text="Countries" TabIndex="7" />
                    </asp:Panel>
                </td>
               
            </tr>
           
            <tr>
                <td align="center" colspan="2"  bgcolor="slategray" style="height: 30px" >
                    <asp:Button id="btnPrint" runat="server" BorderStyle="Solid" 
                      Text="PRINT" backcolor="#E0E0E0" BorderColor="Black" TabIndex="8" /></td>
            </tr>
            </table> 
            <table>
                <tr>
                    <td align="center" colspan="4" style=" width : 850px">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td align="center" colspan="4" style="width: 850px">
                        <asp:GridView id="gdPortfolioResults" runat="server" width="584px">
                        </asp:GridView>
                    </td>
                </tr>
            </table>
            </tr>
                
            </table>
</asp:Panel>
</div>
</asp:Content>

