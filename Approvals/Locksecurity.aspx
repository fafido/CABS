<%@ Page Language="VB" MasterPageFile="~/CDSUser.master" AutoEventWireup="false" CodeFile="Locksecurity.aspx.vb" Inherits="Locksecurity" title="Lock Security" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<asp:Content id="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
    <asp:Panel id="Panel1" runat="server" Width="840px" Font-Names="Arial" Font-Size="Medium" BackColor="White">
    
        <table width ="810px">
            <tr>
                   <td style ="text-align :left;" align="left">
                       <dx:ASPxLabel ID="ASPxLabel1" runat="server" Text="Broker Authorizations&gt;&gt;Share Transfer Authorization" Font-Names="Cambria" Font-Size="Small" Theme="PlasticBlue"></dx:ASPxLabel>

                   </td>
            </tr>
        </table>
<asp:Panel runat="server" ID="panelSearch" Font-Names="Cambria" GroupingText="Search">
    <table>
                 <tr>
                    <td align ="right" >
                        <dx:ASPxLabel ID="ASPxLabel5" runat="server" Text="Pending Security Lock" Theme="Office2003Silver">
                        </dx:ASPxLabel>
                    </td>
                <td align ="left">
                    <dx:ASPxComboBox ID="cmbpending" runat="server" AutoPostBack="True" Theme="BlackGlass" ValueType="System.String" Width="250px">
                    </dx:ASPxComboBox>
                    </td>
                <td colspan ="1" align ="left" >
                    &nbsp;</td>

            </tr>

            <tr>
                <td align="right">&nbsp;</td>
                <td align="left">
                    &nbsp;</td>
                <td align="left" colspan="1">&nbsp;</td>
            </tr>

    </table>

</asp:Panel>
        <asp:panel id="Panel8" runat="server" GroupingText="Account to be Locked/Unlocked" Font-Names="Cambria">
        <table width="810px">
            <tr>
                <td colspan ="1">
                    <dx:ASPxLabel ID="ASPxLabel61" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Instruction" Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                <td colspan ="1">
                    <dx:ASPxTextBox ID="txttype" runat="server" BackColor="#E4E4E4" ReadOnly="True" Theme="BlackGlass" Width="250px">
                    </dx:ASPxTextBox>
                </td>
                <td colspan ="1">&nbsp;</td>
                <td colspan ="1">&nbsp;</td>
                <td colspan ="1">&nbsp;</td>
                <td colspan ="1">&nbsp;</td>
                <td colspan ="1">&nbsp;</td>
                <td colspan ="1">&nbsp;</td>
                

            </tr>
            <tr>
                <td colspan="1">
                    <dx:ASPxLabel ID="ASPxLabel25" runat="server" Font-Names="Cambria" Font-Size="Small" Text="CDS Number" Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                <td colspan="1">
                    <dx:ASPxTextBox ID="txttransferorid" runat="server" BackColor="#E4E4E4" ReadOnly="True" Theme="BlackGlass" Width="250px">
                    </dx:ASPxTextBox>
                </td>
                <td colspan="1"></td>
                <td colspan="1"></td>
                <td colspan="1"></td>
                <td colspan="1"></td>
                <td colspan="1"></td>
                <td colspan="1"></td>
            </tr>
           <tr>
               <td colspan ="1" style="height: 23px">
                   <dx:ASPxLabel ID="ASPxLabel26" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Account Name" Theme="Glass">
                   </dx:ASPxLabel>
               </td>
               <td colspan ="7" style="height: 23px">
                   <dx:ASPxTextBox ID="txttransferorname" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="710px" ReadOnly="True">
                   </dx:ASPxTextBox>
               </td>

           </tr>
            <tr>
                    <td colspan ="1">
                        <dx:ASPxLabel ID="ASPxLabel60" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Company" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                <td colspan ="7" align="left">
                    <dx:ASPxTextBox ID="txttransferorid0" runat="server" BackColor="#E4E4E4" ReadOnly="True" Theme="BlackGlass" Width="250px">
                    </dx:ASPxTextBox>
                    </td>

            </tr>

            <tr>
                <td colspan="1">&nbsp;</td>
                <td align="left" colspan="7">
                    <dx:ASPxButton ID="ASPxButton5" runat="server" Text="Approve" Theme="BlackGlass">
                    </dx:ASPxButton>
                </td>
            </tr>

        </table>

    </asp:panel>
                 
</asp:Panel>
  
</div>
</asp:Content>

