<%@ Page Language="VB" MasterPageFile="~/CDSUser.master" AutoEventWireup="false" CodeFile="BorrowersRequest_authorization.aspx.vb" Inherits="TransferSec_BorrowersRequest_authorization" title="BorrowersRequest" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<asp:Content id="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
    <asp:Panel id="Panel1" runat="server" Width="840px" Font-Names="Arial" Font-Size="Medium" BackColor="White">
    
        <table width ="810px">
            <tr>
                   <td style ="text-align :left;" align="left">
                       <dx:ASPxLabel ID="ASPxLabel1" runat="server" Text="Authorizations&gt;&gt;Authorize Lending" Font-Names="Cambria" Font-Size="Small" Theme="PlasticBlue"></dx:ASPxLabel>

                   </td>
            </tr>
        </table>
          <asp:panel id="Panel3" runat="server" GroupingText="Search" Font-Names="Cambria">
        <table width="810px">
            <tr>
                    <td colspan ="1" style="width: 124px">
                        <dx:ASPxLabel ID="lbl" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Select Transaction" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                <td>
                    <dx:ASPxComboBox ID="ASPxComboBox1" runat="server" AutoPostBack="True" Height="21px" ValueType="System.String" Width="332px">
                    </dx:ASPxComboBox>
                    </td>

            </tr>
            <tr>
                    <td colspan ="1" style="width: 124px">
                    </td>
                <td>
                    &nbsp;</td>

            </tr>
        
        </table>

    </asp:panel>
        <asp:panel id="Panel11" runat="server" GroupingText="Lending Details" Font-Names="Cambria">
        <table width="810px">
            <tr>
                <td align="left">
                    <asp:DetailsView ID="dtlBankDetail" runat="server" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" CssClass="tablestyle" EmptyDataText="No Data to Display" Font-Size="X-Small" ForeColor="Black" GridLines="None" Height="355px" Width="681px">
                        <AlternatingRowStyle BackColor="#F4F4F4" CssClass="altrowstyle" />
                        <HeaderStyle CssClass="headerstyle" />
                        <RowStyle CssClass="rowstyle" />
                    </asp:DetailsView>
                </td>
                

            </tr>
            <tr>
                    <td align="center">
                        <dx:ASPxButton ID="ASPxButton1" runat="server" style="height: 23px" Text="Approve" Theme="BlackGlass">
                        </dx:ASPxButton>
                        &nbsp;</td>


            </tr>
      </table>

    </asp:panel>
                 
</asp:Panel>
  
</div>
</asp:Content>

