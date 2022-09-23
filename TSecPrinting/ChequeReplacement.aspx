<%@ Page Language="VB" MasterPageFile="~/TSec.master" AutoEventWireup="false" CodeFile="ChequeReplacement.aspx.vb" Inherits="TSecPrinting_ChequeReplacement" title="Account Details Enquiry" %>
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
                <td style="height: 20px">
                    <asp:Label id="Label7" runat="server" Text="Cheque Template" font-bold="True" font-names="Arial" font-size="Small"></asp:Label></td>
                    <td style="height: 20px">
                        <asp:RadioButton id="rdtemp1" runat="server" GroupName ="cheqTemp" font-bold="True" font-names="Arial" font-size="Small" Text="Digits Narration" /></td>
                        <td style="height: 20px">
                            <asp:RadioButton id="rdtemp2" runat="server" GroupName ="CheqTemp" font-bold="True" font-names="Arial" font-size="Small" Text="Word Narration" /></td>
            </tr>
           
            <tr>
            <td style="height: 22px; width: 173px;">
                <asp:Label id="Label1" runat="server" font-bold="True" font-names="Calibri" font-size="Medium"
                    Text="Company Name"></asp:Label></td>
            <td style="height: 22px; width: 189px;">
                <asp:DropDownList id="cmbCompany" runat="server" width="205px" autopostback="True">
                </asp:DropDownList></td>
                <td>
                    <asp:DropDownList id="DropDownList1" runat="server" Visible="False" width="216px">
                    </asp:DropDownList></td>
            </tr>
            <tr>
                    <td style="width: 173px">
                        <asp:Label id="lblDividendNo" runat="server" font-bold="True" font-names="Calibri"
                            font-size="Medium" Text="Dividend no"></asp:Label></td>
                    <td style="width: 189px">
                        <asp:DropDownList id="cmbDivno" runat="server" width="205px" autopostback="True">
                        </asp:DropDownList></td>
                        <td>
                       <asp:Label id="lbltemp" runat="server" Visible="False"></asp:Label></td>
                    </tr>
             <tr>
            <td style="width: 173px">
                <asp:Label id="Label2" runat="server" font-bold="True" font-names="Calibri" font-size="Medium"
                    Text="New Cheque No"></asp:Label></td>
            <td style="width: 189px">
                <asp:TextBox id="txtNewChequeNo" runat="server" width="200px"></asp:TextBox></td>
                <td></td>
            </tr>
            
            <tr>
            <td style="height: 25px; width: 173px;">
                <asp:Label id="ReplacementDate" runat="server" font-bold="True" font-names="Calibri" font-size="Medium"
                    Text="Replacement Date"></asp:Label></td>
                    <td style="width: 189px" >
                   
                    <asp:TextBox id="repdate" runat="server" width="150px" ReadOnly="True" TabIndex="5"></asp:TextBox><asp:Button id="Button3" runat="server" Text="V" CausesValidation="False" TabIndex="6"  /></td>
                    <td>
                        &nbsp;</td>
                    </tr>
                    <tr>
                    <td style="width: 173px" ></td>
                    <td colspan ="2" >
                    
                     <asp:Calendar id="Calendar1" runat="server" backcolor="White" BorderColor="#3366CC"
                        BorderWidth="1px" CellPadding="1" DayNameFormat="Shortest" font-names="Verdana"
                        font-size="8pt" forecolor="#003399" Height="100px" width="155px" Visible="False" TabIndex="7">
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
                   <td style="width: 30px">
                       </td>
               
            </tr>
            <tr>
            <td style="width: 173px">
            
            </td>
            <td style="width: 189px">
            
            </td>
            
            </tr>
               
                    <tr>
                    
                                <td style="height: 19px; width: 173px;">
                                    <asp:Label id="Label4" runat="server" font-bold="True" Text="Clear Replaced Cheques" font-names="Calibri" font-size="Medium"></asp:Label></td>
                                <td colspan="2" style="height: 19px">
                                    <asp:Button id="Button2" runat="server" Text="Clear Replaced cheques" width="173px" /></td>
                                
                   </tr>
                   
                   <tr>
                    <td style="width: 173px"></td>
                    <td style="width: 189px"></td>
                   </tr>
                   
                   <tr>
                        <td style="width: 173px; height: 24px;">
                            <asp:Label id="Label5" runat="server" font-names="Calibri" font-size="Medium" Text="Replacement Reports" font-bold="True"></asp:Label></td>
                        
                        <td style="width: 189px; height: 24px;">
                            <asp:Button id="Button4" runat="server" Text="Print Report" width="176px" />
                            </td>
                   
                    <td style="height: 24px">
                            <asp:Button id="btnMandates" runat="server" Text="Mandates" width="72px" Visible="False" /></td>
                   </tr>                  
                   <tr>
                        <td style="width: 173px">
                            <asp:CheckBox id="Nomandate" runat="server" font-bold="True" Text="No Mandate" autopostback="True" font-names="Calibri" font-size="Medium" />
                          </td>
                            
                        <td style="width: 189px"><asp:CheckBox id="Mandate" runat="server" autopostback="True" font-bold="True" Text="Mandate" width="91px" Visible="False" font-names="Calibri" font-size="Medium" /></td>
                    <td style="height: 20px;">
                        <asp:CheckBox id="bankMandate" runat="server" font-bold="True" Text="Bank Mandate" autopostback="True" Height="18px" width="128px" font-names="Calibri" font-size="Medium" /></td>
                   </tr>     
                   
            <tr>
                <td align="center" bgcolor="slategray" colspan="2" style="height: 30px" >
                    <asp:Button id="btn_Print" runat="server" backcolor="#E0E0E0" BorderColor="Black"
                        BorderStyle="Solid"  Text="Replace No Mandates" TabIndex="7" width="160px" />
                        </td>
                    <td align="left" bgcolor="slategray" colspan="2" style="height: 30px; width: 164px;"><asp:Button id="btnReplaceMan" runat="server" backcolor="#E0E0E0" BorderColor="Black"
                        BorderStyle="Solid"  TabIndex="7" Text="Replace Mandates" />                        
                        </td>
                          <td align="left" bgcolor="slategray" colspan="2" style="height: 30px"><asp:Button id="Button1" runat="server" backcolor="#E0E0E0" BorderColor="Black"
                        BorderStyle="Solid"  Text="PRINT CHEQUES" TabIndex="7" />&nbsp;
                        </td>
            
                   </tr>   
            </table>
            </td>
            </tr>
                             
            </table>
</asp:Panel>
</div>
</asp:Content>

