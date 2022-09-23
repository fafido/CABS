<%@ Page Language="VB" MasterPageFile="~/CDSUser.master" AutoEventWireup="false" CodeFile="checkorder.aspx.vb" Inherits="checkorder" title="Confirm Delivery" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>


<asp:Content id="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
    <asp:Panel id="Panel1" runat="server" Width="840px" Font-Names="Arial" Font-Size="Medium" BackColor="White">
    
        <table width ="810px">
            <tr>
                   <td style ="text-align :left;" align="left">
                       <dx:ASPxLabel ID="ASPxLabel1" runat="server" Text="Trading&gt;&gt;Confirm Delivery" Font-Names="Cambria" Font-Size="Small" Theme="PlasticBlue"></dx:ASPxLabel>

                   </td>
            </tr>
        </table>
        <asp:Panel runat="server" ID="PanelType" Font-Names="Cambria" GroupingText="Confirm Delivery">
            <br />
            <table style="width: 828px">
                <tr>
                    <td>
                         <asp:TextBox ID="TextBox1" runat="server" Height="171px" TextMode="MultiLine" Width="672px"></asp:TextBox>
                         <br />
                         <asp:Button ID="Button2" runat="server" Text="Get Records" />
                         &nbsp;&nbsp;
                         <dx:ASPxTextBox ID="ASPxTextBox1" runat="server" Width="170px">
                             <MaskSettings Mask="00-000000-Y-00" />
                         </dx:ASPxTextBox>
                         <asp:GridView ID="grdsellers" runat="server" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" CssClass="tablestyle"  Font-Size="Small" ForeColor="Black" GridLines="None" Style="position: relative; top: 0px; left: 0px; width:100%; height: 3px;">
                             <PagerSettings FirstPageText="First" LastPageText="Last" NextPageText="Next" PreviousPageText="Previous" />
                             <AlternatingRowStyle CssClass="altrowstyle" />
                             <HeaderStyle BackColor="#023E5A" ForeColor="White" HorizontalAlign="Left" />
                             <RowStyle CssClass="rowstyle" />
                         </asp:GridView>
                         <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="Submit" />
                         <br />
                    </td>
                </tr>
                <tr>
                    <td align="center">
                        <br />
                        <asp:TextBox ID="txtNewPass" runat="server" TextMode="Password" width="144px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="req_Pwd" runat="server" ControlToValidate="txtNewPass" Display="None" ErrorMessage="Password is required" ValidationGroup="Submit"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="rev_Pwd" runat="server" ControlToValidate="txtNewPass" Display="None" ErrorMessage="Password  must be between 8 and 15 characters long. Password must contain at least one number. Password must contain at least one uppercase letter. Password must contain at least one lowercase letter. " ValidationExpression="(?!^[0-9]*$)(?!^[a-zA-Z]*$)^([a-zA-Z0-9]{8,15})$" ValidationGroup="Submit"></asp:RegularExpressionValidator>
                        <br />
                        <asp:TextBox ID="txtConfirmPassword" runat="server" Height="22px" TextMode="Password" width="144px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtConfirmPassword" Display="None" ErrorMessage="Confirm Password is required" ValidationGroup="Submit"></asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="cmpPassword" runat="server" ControlToCompare="txtNewPass" ControlToValidate="txtConfirmPassword" Display="None" ErrorMessage="Password mismatch" ValidationGroup="Submit"></asp:CompareValidator>
                        <br />
                        <br />
                        <asp:Button ID="Button1" runat="server" BackColor="#023E5A" ForeColor="White" Height="28px" Text="Authorize all pending Records" Width="260px"  ValidationGroup="Submit" />
                        <br />
                        <br />
                        <br />
                    </td>
                </tr>
            </table>
         
        </asp:Panel>
         
                 
</asp:Panel>
  
</div>
</asp:Content>

