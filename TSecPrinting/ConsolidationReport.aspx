<%@ Page Language="VB" MasterPageFile="~/TSec.master" AutoEventWireup="false" CodeFile="ConsolidationReport.aspx.vb" Inherits="TSecPrinting_ConsolidationReport" title="Account Details Enquiry" %>
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
                <td style="height: 27px" >
                  <asp:Label id="Label2" runat="server"  Text="Select The Type" font-bold="True" font-names="Arial" font-size="Small"></asp:Label>
                  </td>
                  <td style="height: 27px">
                    <asp:RadioButton id="rbUpdated" runat="server" Text="Printed" GroupName="grpprinted" font-bold="True" TabIndex="1" />
                    <asp:RadioButton id="rbnotUpdated" runat="server"  Text="NotPrinted" GroupName="grpprinted" font-bold="True" TabIndex="2" />
                   
                   </td>
            </tr>
            <tr>
              <td style="height: 27px">
                </td>
                <td style="height: 27px">
                 <asp:Button id="btnGetlist" runat="server"  Text="Get List" BorderColor="Black" backcolor="#E0E0E0" TabIndex="3"/>
                </td>
              
            </tr>
            <tr>
                <td style="height: 27px"  >
                    <asp:Label id="Label3" runat="server" font-bold="True" font-names="Arial" font-size="Small"
                      Text="Update No & Company"></asp:Label>
                        </td>
                  <td style="height: 27px">
                  
                    <asp:DropDownList id="ddlUpdateno" runat="server"  width="328px" TabIndex="4">
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td style="height: 17px"  >
                    <asp:Label id="Label5" runat="server" font-bold="True" font-names="Arial" font-size="Small"
                        Text="Select Template" width="176px" Visible="False"></asp:Label></td>
                  <td style="height: 17px" >
                      <asp:DropDownList id="drTemplate" runat="server" width="328px" Visible="False">
                      </asp:DropDownList></td>
            </tr>
            <tr align="center">
               
                <td colspan=2 bgcolor="slategray" style="height: 30px" 
                    >
                    
                   <asp:Button  id="btnChange" runat="server" Text="Proccess" BorderColor="Black" backcolor="#E0E0E0" TabIndex="5" ></asp:Button>
                    <asp:Button id="btnPrint" runat="server" backcolor="#E0E0E0" BorderColor="Black"  Text="Print" width="64px" TabIndex="6" /></td>
                    
            </tr>
            </table>
            
            <table>
                <tr>
                    <td colspan="1" style="width: 147px">
                    </td>
                    <td colspan="1" style="width: 203px">
                    </td>
                    <td colspan="1" style="width: 172px">
                    </td>
                    <td colspan="1" style="width: 316px">
                    </td>
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

