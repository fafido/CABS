<%@ Page Language="VB" MasterPageFile="~/Tsec.master" AutoEventWireup="false" CodeFile="ManualReconciliation.aspx.vb" Inherits="TsecMode_ManualReconciliation" title="CDS Capture" %>
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
                        Text="Manual Reconciliation" width="846px" Height="19px"></asp:Label></td>
            </tr>
           
                
            </table>
            <table style="left: 0px; position: relative; top: 0px">
    <tr>
  <td align="left" style="width: 664px">
    
<table>
          
            <tr>
            <td>
                <asp:Label id="Label9" runat="server" font-bold="True" font-names="Arial" font-size="Small"
                    Text="Company"></asp:Label></td>
            <td>
                <asp:DropDownList id="cmbCompany" runat="server" width="205px" autopostback="True">
                </asp:DropDownList></td>
            </tr>
              <tr>
            <td>
                <asp:Label id="Label10" runat="server" font-bold="True" font-names="Arial" font-size="Small"
                    Text="Dividend No"></asp:Label></td>
            <td>
                <asp:DropDownList id="cmbDivno" runat="server" width="205px" autopostback="True">
                </asp:DropDownList></td>
            </tr>
            <tr>
                <td >
                    <asp:Label id="Label2" runat="server" font-bold="True" font-names="Arial" font-size="Small"
                        Text="Event" width="96px"></asp:Label>
                        </td>
                        <td style="width: 306px">
                    <asp:DropDownList id="cmbEvent" runat="server" autopostback="True"  width="205px" TabIndex="1">
                    </asp:DropDownList>
                            </td>
            </tr>
            <tr>
                <td>
                    
                    <asp:Label id="Label3" runat="server"  Text="Cheque No" font-bold="True" font-names="Arial" font-size="Small"></asp:Label>
                    </td>
                        <td style="width: 306px">
                    <asp:TextBox id="txtChequeNo" runat="server"  width="200px" TabIndex="2"></asp:TextBox>&nbsp;
                            <asp:Button id="SerchByCheq" runat="server" Text=">>" /></td>
            </tr>
            <tr>
                <td >
                  
                    <asp:Label id="Label1" runat="server" Text="Amount In Ksh" font-bold="True" font-names="Arial" font-size="Small"></asp:Label>
                    </td>
                        <td style="width: 306px">
                    <asp:TextBox id="txtAmount" runat="server"  width="200px" TabIndex="3" Enabled="False"></asp:TextBox>
                            &nbsp;
                </td>
            </tr>
            <tr>
                <td >
                    
                   
                    <asp:Label id="Label5" runat="server" Text="Action" font-bold="True" font-names="Arial" font-size="Small"></asp:Label>
                   
                </td>
                <td style="width: 306px">
                    <asp:DropDownList id="cmbStatus" runat="server" TabIndex="4" width="205px">
                        <asp:ListItem Value="C">Paid Cheque</asp:ListItem>
                        <asp:ListItem Value="X">Cancelled Cheque</asp:ListItem>
                        <asp:ListItem Value="W">Warrant Not Presentable</asp:ListItem>
                    </asp:DropDownList></td>
            </tr>
         <tr>
                <td  >
                    <asp:Label id="Label6" runat="server" Text="Date"  font-bold="True" font-names="Arial" font-size="Small"></asp:Label></td>
                <td >
                   
                    <asp:TextBox id="dtpDate" runat="server" width="150px" ReadOnly="True" TabIndex="5"></asp:TextBox>
                    <asp:Button id="Button3" runat="server" Text="V" CausesValidation="False" TabIndex="6"  />
                    </td>
                    </tr>
                    <tr>
                    <td ></td>
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
               
            </tr>
                    <tr>
                    <td>
                    
                    
                    <asp:Label id="Label7" runat="server"  Text="Payee" font-bold="True" font-names="Arial" font-size="Small"></asp:Label>
                    
                    
                    
                    
                </td>
                <td style="width: 306px">
                <asp:TextBox id="txtPayee" runat="server"  width="296px" TabIndex="8" Enabled="False"></asp:TextBox>
                </td>
            </tr>
            <tr>
            <td>
            <asp:Label id="Label8" runat="server" Text="Type" font-bold="True" font-names="Arial" font-size="Small"></asp:Label>
            </td>
            <td style="width: 306px">
            <asp:TextBox id="txtType" runat="server" width="200px" MaxLength="1" TabIndex="9" Enabled="False"></asp:TextBox>
            </td>
            
            </tr>
            <tr>
            <td>
                </td>
            <td>
            
            </td>
            </tr>
            <tr>
                <td  bgcolor="slategray" colspan="2" align="center" style="border-top-color: black; height: 30px">
                    &nbsp;&nbsp;
                    <asp:Button id="btnUpdate" runat="server"  Text="Update" width="104px" backcolor="#E0E0E0" BorderColor="Black" TabIndex="10" UseSubmitBehavior="False" />
                    &nbsp;
                    
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

