<%@ Page Language="VB" MasterPageFile="~/CDSUser.master" AutoEventWireup="false" CodeFile="CashAccountsViewer.aspx.vb" Inherits="Parameters_CashAccountsViewer" title="Cash Accounts Viewer" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<asp:Content id="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
    <asp:Panel id="Panel1" runat="server" Width="840px" Font-Names="Arial" Font-Size="Medium" BackColor="White">
    
        <table width ="810px">
            <tr>
                   <td style ="text-align :left;" align="left">
                       <dx:ASPxLabel ID="ASPxLabel1" runat="server" Text="Utilities&gt;&gt;Settlement Banks Postions" Font-Names="Cambria" Font-Size="Small" Theme="PlasticBlue"></dx:ASPxLabel>

                   </td>
            </tr>
        </table>

          <asp:panel id="Panel2" runat="server" GroupingText="Settlment Bank Positions" Font-Names="Cambria">
        <table width="810px">
            <tr>
                <td colspan ="5" align ="center">
                    &nbsp;</td>

            </tr>
             <tr>
                
                <td colspan ="8"align="center" >
                    <dx:ASPxGridView ID="ASPxGridView1" runat="server" Theme="BlackGlass" Width="710px">
                    </dx:ASPxGridView>
                 </td>
                

            </tr>
            <tr>
                <td colspan ="8" align ="center" >
                    &nbsp;</td>
                

            </tr>
            <tr>
                
                <td colspan ="8" align="center">
                    &nbsp;</td>
                

            </tr>
            <tr>
                <td colspan ="1"></td>
                <td width="301"></td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>

            </tr>

        </table>

    </asp:panel>

</asp:Panel>
  
</div>
</asp:Content>

