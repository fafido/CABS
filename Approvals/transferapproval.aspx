<%@ Page Language="VB" MasterPageFile="~/CDSUser.master" AutoEventWireup="false" CodeFile="transferapproval.aspx.vb" Inherits="transferapproval" title="Account Details Enquiry" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<asp:Content id="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
    <asp:Panel id="Panel1" runat="server" Width="840px" Font-Names="Arial" Font-Size="Medium" BackColor="White">
    
        <table width ="810px">
            <tr>
                   <td style ="text-align :left;" align="left">
                       <dx:ASPxLabel ID="ASPxLabel1" runat="server" Text="Authorizations&gt;&gt;Transfer Authorization" Font-Names="Cambria" Font-Size="Small" Theme="PlasticBlue"></dx:ASPxLabel>

                   </td>
            </tr>
        </table>
<asp:Panel runat="server" ID="panelSearch" Font-Names="Cambria" GroupingText="Search">
    <table>
                 <tr>
                    <td align ="right" >
                        <dx:ASPxLabel ID="ASPxLabel5" runat="server" Text="Pending  Transfers" Theme="Office2003Silver">
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
        <asp:panel id="Panel8" runat="server" GroupingText="Transferor Details" Font-Names="Cambria">
        <table width="810px">
            <tr>
                <td colspan ="1">
                    <dx:ASPxLabel ID="ASPxLabel25" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Account No." Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                <td colspan ="1">
                    <dx:ASPxTextBox ID="txttransferorid" runat="server"  Theme="BlackGlass" Width="250px" ReadOnly="True">
                    </dx:ASPxTextBox>
                </td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>
                

            </tr>
           <tr>
               <td colspan ="1" style="height: 23px">
                   <dx:ASPxLabel ID="ASPxLabel26" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Account Name" Theme="Glass">
                   </dx:ASPxLabel>
               </td>
               <td colspan ="7" style="height: 23px">
                   <dx:ASPxTextBox ID="txttransferorname" runat="server"  Theme="BlackGlass" Width="710px" ReadOnly="True">
                   </dx:ASPxTextBox>
               </td>

           </tr>
            <tr>
                    <td colspan ="1"></td>
                <td colspan ="7" align="center"></td>

            </tr>

        </table>

    </asp:panel>
        <asp:Panel ID="Panel12" runat="server" Font-Names="Cambria" GroupingText="Transferee Details">
            <table width="810px">
                <tr>
                    <td colspan="1">
                        <dx:ASPxLabel ID="ASPxLabel57" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Account No." Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td colspan="1">
                        <dx:ASPxTextBox ID="txttransfereeid" runat="server"  Theme="BlackGlass" Width="250px" ReadOnly="True">
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
                    <td colspan="1" style="height: 23px">
                        <dx:ASPxLabel ID="ASPxLabel58" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Account Name" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td colspan="7" style="height: 23px">
                        <dx:ASPxTextBox ID="txttransfereename" runat="server"  Theme="BlackGlass" Width="710px" ReadOnly="True">
                        </dx:ASPxTextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="1"></td>
                    <td align="center" colspan="7"></td>
                </tr>
            </table>
        </asp:Panel>
        <asp:panel id="Panel11" runat="server" GroupingText="Transfer Details" Font-Names="Cambria">
        <table width="810px">
            <tr>
                    <td colspan ="2" align="center">
                        &nbsp;</td>

            </tr>
         
            <tr>
                <td colspan="1" style="width: 121px; height: 24px;">
                    <dx:ASPxLabel ID="ASPxLabel56" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Units to transfer" Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                <td style="height: 24px">
                    <dx:ASPxTextBox ID="txtshares" runat="server"  Theme="BlackGlass" Width="250px" ReadOnly="True">
                    </dx:ASPxTextBox>
                </td>
            </tr>
            <tr>
                <td colspan="1" style="width: 121px">
                    <dx:ASPxLabel ID="ASPxLabel59" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Receipt Details" Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                <td>
                    <dx:ASPxTextBox ID="txtcomp" runat="server"  Theme="BlackGlass" Width="250px" ReadOnly="True">
                    </dx:ASPxTextBox>
                </td>
            </tr>
               
            <tr>
                <td colspan="1" style="width: 121px">
                    <dx:ASPxLabel ID="ASPxLabel61" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Receipt No" Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                <td>
                    <dx:ASPxTextBox ID="txtreceiptno" runat="server" ReadOnly="True" Theme="BlackGlass" Width="250px">
                    </dx:ASPxTextBox>
                </td>
            </tr>
            <tr>
                <td colspan="1" style="width: 121px">
                    <dx:ASPxLabel ID="ASPxLabel62" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Charge" Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                <td>
                    <dx:ASPxTextBox ID="txtcharge" runat="server" ReadOnly="True" Theme="BlackGlass" Width="250px">
                    </dx:ASPxTextBox>
                </td>
            </tr>
            <tr>
                <td colspan="1" style="width: 121px">
                    <dx:ASPxLabel ID="ASPxLabel60" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Captured By" Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                <td>
                    <dx:ASPxTextBox ID="txtcapturedby" runat="server" ReadOnly="True" Theme="BlackGlass" Width="250px">
                    </dx:ASPxTextBox>
                </td>
            </tr>
               
        </table>

    </asp:panel>

        <asp:Panel runat="server" ID="panelsaving" GroupingText=".">
            <table>
                    <tr>
                            <td colspan ="8" align="center">
                                <dx:ASPxLabel ID="ASPxLabel53" runat="server" Text="____________________________________________________________________________________________________________________" Theme="BlackGlass">
                                </dx:ASPxLabel>
                            </td>


                    </tr>
                <tr>
                        <td colspan ="8" align ="center">
                            <dx:ASPxButton ID="ASPxButton5" runat="server" Text="Approve" Theme="BlackGlass">
                            </dx:ASPxButton>
                        </td>

                </tr>

            </table>
        </asp:Panel>  
                 
</asp:Panel>
  
</div>
</asp:Content>

