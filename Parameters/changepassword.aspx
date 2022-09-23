<%@ Page Language="VB" MasterPageFile="~/CDSUser.master" AutoEventWireup="false" CodeFile="changepassword.aspx.vb" Inherits="Parameters_changepassword" title="Change Password" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<asp:Content id="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
    <asp:Panel id="Panel1" runat="server" Width="840px" Font-Names="Arial" Font-Size="Medium" BackColor="White">
    
        <table width ="810px">
            <tr>
                   <td style ="text-align :left;" align="left">
                       <dx:ASPxLabel ID="ASPxLabel1" runat="server" Text="System Access&gt;&gt;Password Management" Font-Names="Cambria" Font-Size="Small" Theme="PlasticBlue"></dx:ASPxLabel>

                   </td>
            </tr>
        </table>

          <asp:panel id="Panel2" runat="server" GroupingText="Password Update" Font-Names="Cambria">
        <table width="810px">
            <tr>
                <td colspan ="5" align ="center">
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="Submit" />
                </td>

            </tr>
             <tr>
                <td colspan ="1" align="right" style="width: 281px; height: 23px;">
                    <dx:ASPxLabel ID="ASPxLabel10" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Old Password" Theme="Glass">
                    </dx:ASPxLabel>
                 </td>
                <td colspan ="1" width="301" style="height: 23px">
                    <dx:ASPxTextBox ID="txtoldpassword" runat="server" BackColor="#E4E4E4" Password="True" Theme="BlackGlass" Width="250px">
                    </dx:ASPxTextBox>
                 </td>
                <td colspan ="1" style="height: 23px">
                    &nbsp;</td>
                <td colspan ="1" style="height: 23px">&nbsp;</td>
                <td colspan ="1" style="height: 23px">&nbsp;</td>

            </tr>
            <tr>
                <td align="right" colspan="1" style="width: 281px; height: 23px;">
                    <dx:ASPxLabel ID="ASPxLabel9" runat="server" Font-Names="Cambria" Font-Size="Small" Text="New Password" Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                <td colspan="1" style="height: 23px" width="301">
                    <dx:ASPxTextBox ID="txtNewPass" runat="server" BackColor="#E4E4E4" Password="True" Theme="BlackGlass" Width="250px">
                    </dx:ASPxTextBox>
                   <%-- <asp:RequiredFieldValidator ID="req_Pwd" runat="server" ControlToValidate="txtNewPass" Display="None" ErrorMessage="Password is required" ValidationGroup="Submit"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="rev_Pwd" runat="server" ControlToValidate="txtNewPass" Display="None" ErrorMessage="Password must contain: Minimum 8 characters atleast 1 UpperCase Alphabet, 1 LowerCase Alphabet, 1 Number and 1 Special Character" ValidationExpression="^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[$@$!%*?&amp;])[A-Za-z\d$@$!%*?&amp;]{8,}" ValidationGroup="Submit"></asp:RegularExpressionValidator>--%>
                </td>
                <td colspan="1" style="height: 23px"></td>
                <td colspan="1" style="height: 23px"></td>
                <td colspan="1" style="height: 23px"></td>
            </tr>
            <tr>
                <td colspan ="1" align="right" style="width: 281px">
                    <dx:ASPxLabel ID="ASPxLabel2" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Confirm Password" Theme="Glass">
                    </dx:ASPxLabel>
                 </td>
                <td colspan ="1" width="301">
                    <dx:ASPxTextBox ID="txtConfirmPassword" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="250px" Password="True">
                    </dx:ASPxTextBox>
            <%--        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtConfirmPassword" Display="None" ErrorMessage="Confirm Password is required" ValidationGroup="Submit"></asp:RequiredFieldValidator>
                    <asp:CompareValidator ID="cmpPassword" runat="server" ControlToCompare="txtNewPass" ControlToValidate="txtConfirmPassword" Display="None" ErrorMessage="Password mismatch" ValidationGroup="Submit"></asp:CompareValidator>--%>
                 </td>
                <td colspan ="1">
                    &nbsp;</td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>

            </tr>
                <tr>
                <td colspan ="1" align="right" style="width: 281px">
                    &nbsp;</td>
                <td colspan ="1" width="301">
                    &nbsp;</td>
                <td colspan ="1">
                    &nbsp;</td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>

            </tr>
            <tr>
                <td colspan ="1" style="width: 281px">&nbsp;</td>
                <td width="301">
                    <dx:ASPxButton ID="ASPxButton3" runat="server" Text="Update" Theme="BlackGlass"  ValidationGroup="Submit">
                    </dx:ASPxButton>
                </td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>

            </tr>
            <tr>
                <td colspan ="1" style="width: 281px"></td>
                <td width="301"></td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>

            </tr>

        </table>

    </asp:panel>
  
        <!--Settlement-->
       
</asp:Panel>
  
</div>
</asp:Content>

