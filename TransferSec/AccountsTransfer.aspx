<%@ Page Language="VB" MasterPageFile="~/CDSUser.master" AutoEventWireup="false" CodeFile="AccountsTransfer.aspx.vb" Inherits="TransferSec_AccountsTransfer" title="Account Details Enquiry" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<asp:Content id="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
    <asp:Panel id="Panel1" runat="server" Width="840px" Font-Names="Arial" Font-Size="Medium" BackColor="White">
    
        <table width ="810px">
            <tr>
                   <td style ="text-align :left;" align="left">
                       <dx:ASPxLabel ID="ASPxLabel1" runat="server" Text="Accounts Maintenance&gt;&gt;Accounts Transfer" Font-Names="Cambria" Font-Size="Small" Theme="PlasticBlue"></dx:ASPxLabel>

                   </td>
            </tr>
        </table>
<asp:Panel runat="server" ID="panelSearch" Font-Names="Cambria" GroupingText="Search">
    <table>
            <tr>
                    <td align ="right" >
                        <dx:ASPxLabel ID="ASPxLabel57" runat="server" Text="ID No. Search" Theme="Office2003Silver">
                        </dx:ASPxLabel>
                    </td>
                <td align ="left">
                    <dx:ASPxTextBox ID="txtClientNo9" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="250px">
                    </dx:ASPxTextBox>
                    </td>
                <td colspan ="1" align ="left" style="width: 287px" >
                    <dx:ASPxButton ID="ASPxButton7" runat="server" Text="&gt;&gt;" Theme="BlackGlass">
                    </dx:ASPxButton>
                    </td>

            </tr>
                 <tr>
                     <td align="right">
                         <dx:ASPxLabel ID="ASPxLabel54" runat="server" Text="Pin No. Search" Theme="Office2003Silver">
                         </dx:ASPxLabel>
                     </td>
                     <td align="left">
                         <dx:ASPxTextBox ID="txtClientNo8" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="250px">
                         </dx:ASPxTextBox>
                     </td>
                     <td align="left" colspan="1" style="width: 287px">
                         <dx:ASPxButton ID="ASPxButton6" runat="server" Text="&gt;&gt;" Theme="BlackGlass">
                         </dx:ASPxButton>
                     </td>
            </tr>
                 <tr>
                    <td align ="right" >
                        <dx:ASPxLabel ID="ASPxLabel5" runat="server" Text="Client Name Search" Theme="Office2003Silver">
                        </dx:ASPxLabel>
                    </td>
                <td align ="left">
                    <dx:ASPxTextBox ID="ASPxTextBox2" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="250px">
                    </dx:ASPxTextBox>
                    </td>
                <td colspan ="1" align ="left" style="width: 287px" >
                    <dx:ASPxButton ID="ASPxButton1" runat="server" Text="&gt;&gt;" Theme="BlackGlass">
                    </dx:ASPxButton>
                    </td>

            </tr>

            <tr>
                <td align="right">&nbsp;</td>
                <td align="left" colspan="2">
                    <dx:ASPxListBox ID="ASPxListBox1" runat="server" AutoPostBack="True" Height="75px" ValueType="System.String" Width="537px">
                    </dx:ASPxListBox>
                </td>
            </tr>

    </table>

</asp:Panel>
        <asp:panel id="Panel8" runat="server" GroupingText="Personal Details" Font-Names="Cambria">
        <table width="810px">
            <tr>
                <td colspan ="1">
                    <dx:ASPxLabel ID="ASPxLabel25" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Pin No." Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                <td colspan ="1">
                    <dx:ASPxTextBox ID="txtclientid" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="250px" ReadOnly="True">
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
               <td colspan ="1">
                   <dx:ASPxLabel ID="ASPxLabel26" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Account Name" Theme="Glass">
                   </dx:ASPxLabel>
               </td>
               <td colspan ="7">
                   <dx:ASPxTextBox ID="txtsurname" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="710px" ReadOnly="True">
                   </dx:ASPxTextBox>
               </td>

           </tr>
            <tr>
                    <td colspan ="1">
                    </td>

            </tr>
            <tr>
                    <td colspan ="1"></td>
                <td colspan ="7" align="center"></td>

            </tr>

        </table>

    </asp:panel>
        <asp:panel id="Panel11" runat="server" GroupingText="Details" Font-Names="Cambria">
        <table width="810px">
            <tr>
                    <td colspan ="2" align="left" style="height: 18px">
                        <asp:Panel ID="Panel12" runat="server">
                            <table class="auto-style1">
                                <tr>
                                    <td style="width: 88px; height: 18px;">
                                        <dx:ASPxLabel ID="ASPxLabel58" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Company" Theme="Glass">
                                        </dx:ASPxLabel>
                                    </td>
                                    <td style="height: 18px">
                                        <dx:ASPxComboBox ID="ASPxComboBox1" runat="server" AutoPostBack="True" ValueType="System.String">
                                        </dx:ASPxComboBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 88px; height: 23px;">
                                        <dx:ASPxLabel ID="ASPxLabel59" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Portfolio" Theme="Glass">
                                        </dx:ASPxLabel>
                                    </td>
                                    <td style="height: 23px">
                                        <dx:ASPxTextBox ID="ASPxTextBox3" runat="server" BackColor="#E4E4E4" Enabled="False" Theme="BlackGlass" Width="170px">
                                        </dx:ASPxTextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 88px">
                                        <dx:ASPxLabel ID="ASPxLabel60" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Transferrable" Theme="Glass">
                                        </dx:ASPxLabel>
                                    </td>
                                    <td>
                                        <dx:ASPxTextBox ID="ASPxTextBox4" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="170px">
                                        </dx:ASPxTextBox>
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                        </td>

            </tr>
         
           <tr>
               <td colspan ="1" style="width: 168px; height: 37px;">
                   <dx:ASPxLabel ID="ASPxLabel56" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Current Broker" Theme="Glass">
                   </dx:ASPxLabel>
               </td>
               <td style="height: 37px">
                   <dx:ASPxTextBox ID="txtcurrentbroker" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="250px" ReadOnly="True">
                   </dx:ASPxTextBox>
                   &nbsp;<dx:ASPxLabel ID="txtbrokercode" runat="server" Font-Names="Cambria" Font-Size="Small" Theme="Glass" Visible="False">
                   </dx:ASPxLabel>
               </td>

           </tr>
             <tr>
               <td colspan ="1" style="width: 168px; height: 23px;">
                   <dx:ASPxLabel ID="ASPxLabel35" runat="server" Font-Names="Cambria" Font-Size="Small" Text="New Broker" Theme="Glass">
                   </dx:ASPxLabel>
                 </td>
               <td style="height: 23px">
                   <dx:ASPxComboBox ID="cmbbrokers" runat="server" Theme="BlackGlass" ValueType="System.String" Width="710px" AutoPostBack="True">
                   </dx:ASPxComboBox>
                 </td>

           </tr>
               
            <tr>
                <td valign="top" colspan="1" style="width: 168px">
                    <dx:ASPxLabel ID="ASPxLabel55" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Comments" Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                <td>
                    <dx:ASPxMemo ID="txtcomments" runat="server" Height="71px" Width="575px">
                    </dx:ASPxMemo>
                </td>
            </tr>
               
            <tr>
                <td colspan="2" valign="top" align="center">&nbsp;</td>
            </tr>
               
        </table>

    </asp:panel>

        <asp:Panel runat="server" ID="panelsaving" GroupingText=".">
            <table>
                    <tr>
                            <td colspan ="8" align="center" style="width: 824px">
                                &nbsp;</td>


                    </tr>
                <tr>
                        <td colspan ="8" align ="center" style="width: 824px">
                            <dx:ASPxButton ID="ASPxButton5" runat="server" Text="save" Theme="BlackGlass" Visible="False">
                            </dx:ASPxButton>
                        </td>

                </tr>

            </table>
        </asp:Panel>  
                 
</asp:Panel>
  
</div>
</asp:Content>

