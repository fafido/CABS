<%@ Page Language="VB" MasterPageFile="~/TSec.master" AutoEventWireup="false" CodeFile="BrokerBatchReceipt.aspx.vb" Inherits="TSecTrading_BrokerBatchReceipt" title="Batch Receipting" %>

<%@ Register Assembly="BasicFrame.WebControls.BasicDatePicker" Namespace="BasicFrame.WebControls"
    TagPrefix="BDP" %>
<asp:Content id="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div>
    <asp:Panel id="Panel1" runat="server">
    
<table style="border-right: #000033 thin solid; border-top: #000033 thin solid; border-left: #000033 thin solid; width: 832px; border-bottom: #000033 thin solid; background-color: #ffffff">
    <tr>
        <td style="width: 712px; height: 226px" valign="top">
            <table>
            <tr>
        <td colspan="2" align="right">
          <asp:Label id="Label12" runat="server" font-bold="True"  Text="BATCH HEADER" font-size="Large" ></asp:Label>
        </td>
        
        </tr>
        <tr>
        <td >
        <asp:Label id="Label2" runat="server" font-bold="False" font-names="Arial" font-size="Small"
                        Text="Batch Reference" Visible="False" ></asp:Label>
        </td>
        <td>
        <asp:TextBox id="txtBatchRef" runat="server" font-bold="True"  Enabled="False" width="150px" TabIndex="1" Visible="False"></asp:TextBox>
            </td>
      
        </tr>
        <tr>
        <td >
        <asp:Label id="Label3" runat="server" font-bold="False" font-names="Arial" font-size="Small"
                        Text="Company"></asp:Label>
        </td>
        <td>
         <asp:DropDownList id="cmbCOmpany" runat="server" width="150px" TabIndex="2"  > </asp:DropDownList>
            &nbsp;&nbsp;</td>
       
        </tr>
         <tr>
                <td  >
                    <asp:Label id="Label4f" runat="server" Text="Date"  font-bold="False" 
                        font-names="Arial" font-size="Small"></asp:Label></td>
                <td >
                   
                    <asp:TextBox id="txtdate" runat="server" width="150px" ReadOnly="True" TabIndex="4"></asp:TextBox>
                    <asp:Button id="Button3" runat="server" Text="V" CausesValidation="False" TabIndex="5"  />
                    </td>
                    </tr>
                    <tr>
                    <td></td>
                    <td colspan ="2" >
                    
                     <asp:Calendar id="Calendar1" runat="server" backcolor="White" BorderColor="#3366CC"
                        BorderWidth="1px" CellPadding="1" DayNameFormat="Shortest" font-names="Verdana"
                        font-size="8pt" forecolor="#003399" Height="100px" width="155px" Visible="False" TabIndex="6">
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
        <asp:Label id="Label8h" runat="server" font-bold="False" font-names="Arial"
                        font-size="Small" 
                        Text="Batch Type" ></asp:Label>
        </td>
        <td>
         <asp:DropDownList id="cmbBatchType" runat="server"
                            autopostback="True" width="150px" TabIndex="7" >
                        </asp:DropDownList>
                        <asp:TextBox id="txtBatchType" runat="server"  font-bold="True" width="150px" TabIndex="8"></asp:TextBox>
                        <asp:RequiredFieldValidator id="RequiredFieldValidator2" runat="server" ControlToValidate="cmbBatchType"
                        ErrorMessage="Select Batch type" InitialValue="-Select-" ValidationGroup="addgrp" ></asp:RequiredFieldValidator>
        </td>
        </tr>
        <tr>
        <td >
        <asp:Label id="Label6" runat="server" font-bold="False" font-names="Arial" font-size="Small"
                         Text="Transfer No" Visible="False"></asp:Label>
        </td>
        <td>
         <asp:TextBox id="txtTransferno" runat="server" Enabled="False" width="150px" TabIndex="9" Visible="False" ></asp:TextBox>
        </td>
        </tr>
        <tr>
        <td >
        <asp:Label id="Label5" runat="server" font-bold="False" font-names="Arial" font-size="Small"
                           Text="Shares"></asp:Label>
        </td>
        <td>
          <asp:TextBox id="txtShares" runat="server" width="150px" TabIndex="10" ></asp:TextBox>
          <asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" ControlToValidate="txtShares"
                        ErrorMessage="Enter Shares ?" ValidationGroup="addgrp" ></asp:RequiredFieldValidator>
        </td>
        </tr>
        <tr>
        <td >
        <asp:Label id="Label7" runat="server" font-bold="False" font-names="Arial" font-size="Small"
                        Text="Batch Value"
                        ></asp:Label>
        </td>
        <td>
         <asp:TextBox id="txtBatchValue" runat="server" width="150px" TabIndex="11" >0.00</asp:TextBox>
         
         <asp:Label id="Label13" runat="server" font-bold="False" font-names="Arial" font-size="Small"
                        Text="Or Price Per Share"
                        ></asp:Label>
            &nbsp; &nbsp; &nbsp; &nbsp;<asp:TextBox id="txtPricePerShare" runat="server"  Enabled="False" width="150px">0.00</asp:TextBox></td>
        </tr>
        <tr>
        <td >
        <asp:Label id="Label9" runat="server" font-bold="False" font-names="Arial" font-size="Small"
                                 Text="Broker"></asp:Label>
        </td>
        <td>
        <asp:DropDownList id="cmbBroker1" runat="server" autopostback="True" width="314px" TabIndex="12">
                    </asp:DropDownList>&nbsp;
            <asp:Label id="cmbbroker" runat="server" Text="Label" Visible="False"></asp:Label></td>
        </tr>
        <tr>
        <td >
         <asp:Label id="Label10" runat="server" font-bold="False" font-names="Arial" font-size="Small"
                        Text="Broker Ref"></asp:Label>
        </td>
        <td>
        <asp:TextBox id="txtBrokerRef" runat="server" width="150px" TabIndex="14" ></asp:TextBox>
        </td>
        </tr>
        <tr>
        <td >
         <asp:Label id="Label11" runat="server" font-bold="False" font-names="Arial" font-size="Small"
                       Text="Lodger"></asp:Label>
                   
        </td>
        <td>
         <asp:TextBox id="txtLodger" runat="server" width="150px" TabIndex="15"></asp:TextBox>
        </td>
        </tr>
        <tr>
        <td >
          <asp:CheckBox id="chkAdvicereq" runat="server" font-bold="True" font-names="Arial"
                        font-size="Small"
                        Text="Advice Required" width="150px" TabIndex="16" />
                  
                    
        </td>
        <td>
        
                    <asp:CheckBox id="chkHold" runat="server" font-bold="True" font-names="Arial" font-size="Small"
                         Text="Hold" width="150px" TabIndex="17"
                         />
        </td>
        </tr>
        <tr>
        <td colspan="2" style="background-color: gray; height: 30px;"&nbsp;<asp:Button id="btnValidate" runat="server"  backcolor="#E0E0E0" BorderColor="Black" BorderStyle="Solid"  Text="Validate" width="72px" Height="25px" CausesValidation="False" TabIndex="19" />
                    <asp:Button id="btnAdd" runat="server"  Text="Add" backcolor="#E0E0E0" BorderColor="Black" BorderStyle="Solid" CausesValidation="False" width="72px" UseSubmitBehavior="False" Height="25px" ValidationGroup="addgrp" TabIndex="20" />
       <asp:Button id="btnUpdate" runat="server"  backcolor="#E0E0E0" BorderColor="Black" BorderStyle="Solid"  Text="Update" width="72px" Height="25px" CausesValidation="False" TabIndex="19" />
        <asp:Button id="Button1" runat="server"  Text="Print" backcolor="#E0E0E0" BorderColor="Black" BorderStyle="Solid" CausesValidation="False" width="72px" UseSubmitBehavior="False" Height="25px" TabIndex="21" />
                    <asp:Button id="Button2" runat="server" backcolor="#E0E0E0" BorderColor="Black"
                        CausesValidation="False"  Text="Document Scan" TabIndex="22" />
        </td>
        
        </tr>
            <tr>
                <td align="center" colspan="2">
         <asp:Label id="Label1" runat="server" font-bold="False" font-names="Arial" font-size="Small"
                Text="Certificate No"></asp:Label><asp:TextBox id="txtCertNo" runat="server" TabIndex="3"></asp:TextBox><asp:Button id="btnAddCert"
                runat="server" Text="Add" CausesValidation="False" backcolor="#E0E0E0" BorderColor="Black" />
                    <asp:Button id="btndeletecert"
                runat="server" Text="Delete" CausesValidation="False" backcolor="#E0E0E0" BorderColor="Black" width="60px" /></td>
            </tr>
            <tr>
                <td align="center" colspan="2">
                    <asp:GridView id="grdAddedCertificate" runat="server" CellPadding="4" forecolor="#333333" GridLines="None">
                        <FooterStyle backcolor="#507CD1" font-bold="True" forecolor="White" />
                        
                        <Columns>
                            <asp:TemplateField HeaderText="SELECT">
                            <ItemTemplate >
                            
                            <asp:CheckBox id="checkbox1" runat ="server" />
                            
                            </ItemTemplate>
                            
                            </asp:TemplateField>
                        </Columns>
                        <RowStyle backcolor="#EFF3FB" />
                        <EditRowStyle backcolor="#2461BF" />
                        <SelectedRowStyle backcolor="#D1DDF1" font-bold="True" forecolor="#333333" />
                        <PagerStyle backcolor="#2461BF" forecolor="White" HorizontalAlign="Center" />
                        <HeaderStyle backcolor="#507CD1" font-bold="True" forecolor="White" />
                        <AlternatingRowStyle backcolor="White" />
                    </asp:GridView>
                    &nbsp;</td>
            </tr>
       <tr>
       <td colspan ="2" align = "center">
           <asp:Label id="Label14g" runat="server" font-bold="True" font-names="Arial" font-size="Large"
               Text="SEARCH"></asp:Label></td>
       </tr> 
        <tr>
        <td colspan = "2" align = "center" >
         <table>
            <tr>
            <td>
                <asp:Label id="Label20" runat="server" font-bold="True" font-names="Arial" font-size="Small"
                    Text="Company"></asp:Label></td>
            
            <td><asp:DropDownList id="drSearchCompany" runat="server" 
                         width="205px" TabIndex="2">
            </asp:DropDownList></td>
            </tr>
            <tr>
            <td>
                <asp:Label id="Label21" runat="server" font-bold="True" font-names="Arial" font-size="Small"
                    Text="Batch_ref"></asp:Label></td>
            <td>
                <asp:TextBox id="txtSearchbatchref" runat="server" TabIndex="3" width="200px"></asp:TextBox></td>
            
            </tr>
            <tr>
            <td align=center colspan  = "2">
            <asp:Button id="btnSearch" runat="server" backcolor="#E0E0E0" BorderColor="Black"  Text="Search" width="88px" TabIndex="25" />
            </td>
            </tr>
            </table>
        </td>
        </tr>
            </table>
            
            
            <table>
                <tr>
                    <td colspan ="4" style="width: 850px" align="center">
                        </td>                
                </tr>
            </table>
        </td>
    </tr>
</table>
</asp:Panel>
</div>
</asp:Content>

