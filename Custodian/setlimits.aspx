<%@ Page Language="VB" MasterPageFile="~/CDSUser.master" AutoEventWireup="false" CodeFile="setlimits.aspx.vb" Inherits="setlimits" title="Set Limits" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<asp:Content id="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
    <asp:Panel id="Panel1" runat="server" Width="100%" Font-Names="Arial" Font-Size="Medium" BackColor="White">
    
        <table width ="100%">
            <tr>
                   <td style ="text-align :left;" align="left">
                       <dx:ASPxLabel ID="ASPxLabel1" runat="server" Text="Utities&gt;&gt;Buy and Sell Limits" Font-Names="Cambria" Font-Size="Small" Theme="PlasticBlue"></dx:ASPxLabel>

                   </td>
            </tr>
        </table>

        <asp:Panel runat="server" ID="Panel3" Font-Names="Cambria" GroupingText="Buy and Sell Limits">

                <table width="100%">
<tr>
        <td colspan ="1" style="width: 241px">
            <dx:ASPxLabel ID="ASPxLabel9" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Account Class" Theme="Glass">
            </dx:ASPxLabel>
        </td>
    <td>
        <dx:ASPxComboBox ID="cmbaccountclass" runat="server" EnableCallbackMode="True" ReadOnly="False" Theme="Glass" Width="250px">
        </dx:ASPxComboBox>
        </td>

</tr>
                    
                    <tr>
                            <td colspan ="1" style="height: 24px; width: 241px">
                                <dx:ASPxLabel ID="ASPxLabel5" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Settlement Limit Amount" Theme="Glass">
                                </dx:ASPxLabel>
                            </td>
                        <td style="height: 24px">
                            <dx:ASPxTextBox ID="txtlimit" runat="server" DisplayFormatString="n" Height="19px" ReadOnly="False" style="margin-bottom: 0px" Theme="BlackGlass" Width="250px">
                            </dx:ASPxTextBox>
                            </td>

                    </tr>
                    <tr>
                        <td colspan="1" style="height: 24px; width: 241px">
                            <dx:ASPxLabel ID="ASPxLabel8" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Currency" Theme="Glass">
                            </dx:ASPxLabel>
                        </td>
                        <td style="height: 24px">
                            <dx:ASPxComboBox ID="cmbcurrency" runat="server" EnableCallbackMode="True" ReadOnly="False" Theme="Glass" Width="250px">
                            </dx:ASPxComboBox>
                        </td>
                    </tr>
                    <tr>
                            <td colspan ="1" valign="top" style="width: 241px">
                                <dx:ASPxLabel ID="ASPxLabel7" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Reaction" Theme="Glass">
                                </dx:ASPxLabel>
                            </td>
                        <td>
                            <asp:RadioButtonList ID="rdlreaction" runat="server" AutoPostBack="True">
                                <asp:ListItem>Reject Transaction</asp:ListItem>
                                <asp:ListItem>Authorize Transaction</asp:ListItem>
                                <asp:ListItem>Send Email But Proceed</asp:ListItem>
                            </asp:RadioButtonList>
                            </td>

                    </tr>
                    <tr>
                        <td colspan="1" style="width: 241px">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td colspan="1" style="width: 241px">&nbsp;</td>
                        <td>
                            <dx:ASPxButton ID="ASPxButton5" runat="server" Text="Save" Theme="BlackGlass">
                            </dx:ASPxButton>
                            &nbsp;<dx:ASPxButton ID="ASPxButton6" runat="server" Text="Clear Settings" Theme="BlackGlass">
                            </dx:ASPxButton>
                        </td>
                    </tr>
        </table>
        </asp:Panel>

         <asp:Panel runat="server" ID="Panel5" Font-Names="Cambria" GroupingText="Limits" Font-Size="Medium">

                <table width="810px">
<tr>
        
    <td align="center" colspan="8">
        <dx:ASPxGridView ID="grdPortfolios" runat="server" Theme="Aqua" Width="650px">
        </dx:ASPxGridView>
        <br />
        <br />
        <br />
        <br />
    </td>
   

</tr>
                 
                    <tr>
                        <td align="center" colspan="8">
                            &nbsp;</td>
                    </tr>
                 
        </table>
        </asp:Panel>
        
</asp:Panel>
  
</div>
</asp:Content>

