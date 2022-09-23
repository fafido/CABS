<%@ Page Language="VB" MasterPageFile="~/Tsec.master" AutoEventWireup="false" CodeFile="DividendReconEvent.aspx.vb" Inherits="TsecMode_DividendReconEvent" title="CDS Capture" %>
<asp:Content id="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
    <asp:Panel id="Panel1" runat="server" width="870px">
    
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
                        Text="Dividend Recon Event Creation" width="845px" Height="19px"></asp:Label></td>
            </tr>
           
                
            </table>
            <table style="left: 0px; position: relative; top: 0px">
    <tr>
    <td align="left" style="width: 664px">
    
  <table   cellspacing="0" border="0" cellpadding="0">
            
            <tr>
                <td style="width: 99px; height: 27px;" >
                    <asp:Label id="Label2" runat="server" Text="id" width="48px"  font-bold="True" font-names="Arial" font-size="Small"></asp:Label>
                </td>
                <td style="height: 27px" >
                    &nbsp;<asp:TextBox id="txtId" runat="server"  Enabled="False" ReadOnly="True" width="200px" TabIndex="1"></asp:TextBox></td>
                
            </tr>
            <tr>
                <td style="width: 99px; height: 27px;" >
                    <asp:Label id="Label3" runat="server" Text="Company"  font-bold="True" font-names="Arial" font-size="Small"></asp:Label></td>
                <td style="height: 27px" >
                    &nbsp;<asp:DropDownList id="txtCompany" runat="server" width="205px">
                    </asp:DropDownList>
                </td>
                
            </tr>
            <tr>
            <td style="width: 99px; height: 27px;">
                    <asp:Label id="Label1" runat="server" Text="Description"  font-bold="True" font-names="Arial" font-size="Small"></asp:Label></td>
                    <td style="height: 27px">
                        &nbsp;<asp:TextBox id="txtDescription" runat="server" TabIndex="3" width="200px" ></asp:TextBox><asp:RequiredFieldValidator id="RequiredFieldValidator2" runat="server" ControlToValidate="txtDescription"
                        ErrorMessage="Please Enter Description" ></asp:RequiredFieldValidator></td>
            </tr>
             <tr>
               
               <td colspan="3" align="center" >
                   <asp:Button id="Button1" runat="server" Text="SAVE" backcolor="#E0E0E0" BorderColor="Black" BorderStyle="Solid" TabIndex="4" />
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

