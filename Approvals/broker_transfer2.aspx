<%@ Page Language="VB" MasterPageFile="~/cdsuser.master" AutoEventWireup="false" CodeFile="broker_transfer2.aspx.vb" Inherits="TransferSec_broker_transfer2" title="Account Details Enquiry" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<asp:Content id="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
    <asp:Panel id="Panel1" runat="server" Width="840px" Font-Names="Arial" Font-Size="Medium" BackColor="White">
    
        <table width ="810px">
            <tr>
                   <td style ="text-align :left;" align="left">
                       <dx:ASPxLabel ID="ASPxLabel1" runat="server" Text="Accounts Maintenance&gt;&gt;Broker Transfer Authorization" Font-Names="Cambria" Font-Size="Small" Theme="PlasticBlue"></dx:ASPxLabel>

                   </td>
            </tr>
        </table>
<asp:Panel runat="server" ID="panelSearch" Font-Names="Cambria" GroupingText="Search">
    <table>
                 <tr>
                    <td align ="right" >
                        <dx:ASPxLabel ID="ASPxLabel5" runat="server" Text="Pending Broker Transfer" Theme="Office2003Silver">
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
        <asp:panel id="Panel8" runat="server" GroupingText="Personal Details" Font-Names="Cambria">
        <table width="810px">
            <tr>
                <td colspan ="1" style="width: 96px">
                    <dx:ASPxLabel ID="ASPxLabel25" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Client ID." Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                <td colspan ="1">
                    <dx:ASPxTextBox ID="txtclientid" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="250px" Enabled="False">
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
               <td colspan ="1" style="width: 96px">
                   <dx:ASPxLabel ID="ASPxLabel26" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Surname" Theme="Glass">
                   </dx:ASPxLabel>
               </td>
               <td colspan ="7">
                   <dx:ASPxTextBox ID="txtsurname" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="710px" Enabled="False">
                   </dx:ASPxTextBox>
               </td>

           </tr>
            <tr>
                <td colspan="1" style="width: 96px">&nbsp;</td>
                <td colspan="7">&nbsp;</td>
            </tr>

        </table>

    </asp:panel>
        <asp:panel id="Panel11" runat="server" GroupingText="Broker" Font-Names="Cambria">
        <table width="810px">
            <tr>
                    <td colspan ="2" align="center">
                        &nbsp;</td>

            </tr>
         
           <tr>
               <td colspan ="1" style="height: 23px">
                   <dx:ASPxLabel ID="ASPxLabel58" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Company" Theme="Glass">
                   </dx:ASPxLabel>
               </td>
               <td style="height: 23px">
                   <dx:ASPxTextBox ID="txtcompany" runat="server" BackColor="#E4E4E4" Enabled="False" Theme="BlackGlass" Width="250px">
                   </dx:ASPxTextBox>
               </td>

           </tr>
             <tr>
                 <td colspan="1">
                     <dx:ASPxLabel ID="ASPxLabel57" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Portfolio" Theme="Glass">
                     </dx:ASPxLabel>
                 </td>
                 <td>
                     <dx:ASPxTextBox ID="txtportfolio" runat="server" BackColor="#E4E4E4" Enabled="False" Theme="BlackGlass" Width="250px">
                     </dx:ASPxTextBox>
                 </td>
            </tr>
            <tr>
                <td colspan="1">
                    <dx:ASPxLabel ID="ASPxLabel56" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Current Broker" Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                <td>
                    <dx:ASPxTextBox ID="txtcurrentbroker" runat="server" BackColor="#E4E4E4" Enabled="False" Theme="BlackGlass" Width="250px">
                    </dx:ASPxTextBox>
                    &nbsp;<dx:ASPxLabel ID="txtbrokercode" runat="server" Font-Names="Cambria" Font-Size="Small" Theme="Glass" Visible="False">
                    </dx:ASPxLabel>
                </td>
            </tr>
             <tr>
               <td colspan ="1">
                   <dx:ASPxLabel ID="ASPxLabel35" runat="server" Font-Names="Cambria" Font-Size="Small" Text="New Broker" Theme="Glass">
                   </dx:ASPxLabel>
                 </td>
               <td>
                   <dx:ASPxTextBox ID="txtnewbroker" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="250px" Enabled="False">
                   </dx:ASPxTextBox>
                 </td>

           </tr>
               
            <tr>
                <td colspan="1">
                    <dx:ASPxLabel ID="ASPxLabel55" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Comments" Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                <td>
                    <dx:ASPxTextBox ID="txtComments" runat="server" BackColor="#E4E4E4" Height="80px" Theme="BlackGlass" Width="710px" Enabled="False">
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

