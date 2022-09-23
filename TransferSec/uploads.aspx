<%@ Page Language="VB"  MasterPageFile="~/CDSUser.master" AutoEventWireup="false" CodeFile="uploads.aspx.vb" Title="uploads" Inherits="Depositor_uploads" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<asp:Content id="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Panel id="Panel1" runat="server" Width="100%" Font-Names="Arial" Font-Size="Medium" GroupingText="" BackColor="White">
        <table>
            <tr id="Tr1" runat="server">
              <td colspan="5" style="height: 18px;">
                    &nbsp;</td>
              </tr>
           
 
           

             <tr>
                                    <td style="width: 208px">
                                        <dx:ASPxLabel ID="ASPxLabel62" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Upload payment proof" Theme="Glass">
                                        </dx:ASPxLabel>
                                    </td>
                                    <td style="width: 212px">
                                        <asp:FileUpload ID="FileUpload1" runat="server" Width="248px" />
                                    </td>
                                </tr>
            <tr>
               <td style="width: 208px;"></td>
                <td style="width: 212px;">
                    <dx:ASPxButton ID="btnSave" runat="server" Text="Submit" Theme="Glass">
                    </dx:ASPxButton>
                </td>
            </tr>
          
           
        </table>
    </asp:Panel>
</asp:Content>
