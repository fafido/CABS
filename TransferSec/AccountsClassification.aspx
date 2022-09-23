<%@ Page Language="VB" MasterPageFile="~/CDSUser.master" AutoEventWireup="false" CodeFile="AccountsClassification.aspx.vb" Inherits="TransferSec_AccountsClassification" title="Account Details Enquiry" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<asp:Content id="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
    <asp:Panel id="Panel1" runat="server" Width="840px" Font-Names="Arial" Font-Size="Medium" BackColor="White">
    
        <table width ="810px">
            <tr>
                   <td style ="text-align :left;" align="left">
                       <dx:ASPxLabel ID="ASPxLabel1" runat="server" Text="Accounts Maintenance&gt;&gt;Accounts Classification" Font-Names="Cambria" Font-Size="Small" Theme="PlasticBlue"></dx:ASPxLabel>

                   </td>
            </tr>
        </table>
<asp:Panel runat="server" ID="panelSearch" Font-Names="Cambria" GroupingText="Search">
    <table>
            <tr>
                    <td align ="right" >
                        <dx:ASPxLabel ID="ASPxLabel57" runat="server" Text="Identification No. Search" Theme="Office2003Silver">
                        </dx:ASPxLabel>
                    </td>
                <td align ="left">
                    <dx:ASPxTextBox ID="txtClientNo9" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="250px">
                    </dx:ASPxTextBox>
                    </td>
                <td colspan ="1" align ="left" style="width: 280px" >
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
                     <td align="left" colspan="1" style="width: 280px">
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
                <td colspan ="1" align ="left" style="width: 280px" >
                    <dx:ASPxButton ID="ASPxButton1" runat="server" Text="&gt;&gt;" Theme="BlackGlass">
                    </dx:ASPxButton>
                    </td>

            </tr>

            <tr>
                <td align="right">&nbsp;</td>
                <td align="left" colspan="2">
                    <dx:ASPxListBox ID="ASPxListBox1" runat="server" AutoPostBack="True" Height="75px" ValueType="System.String" Width="528px">
                    </dx:ASPxListBox>
                </td>
            </tr>

    </table>

</asp:Panel>
        <asp:panel id="Panel8" runat="server" GroupingText="Personal Details" Font-Names="Cambria">
        <table width="810px">
            <tr>
                <td colspan ="1" style="width: 125px">
                    <dx:ASPxLabel ID="ASPxLabel25" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Client ID." Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                <td colspan ="1">
                    <dx:ASPxTextBox ID="txtclientid" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="250px">
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
               <td colspan ="1" style="width: 125px">
                   <dx:ASPxLabel ID="ASPxLabel26" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Surname" Theme="Glass">
                   </dx:ASPxLabel>
               </td>
               <td colspan ="7">
                   <dx:ASPxTextBox ID="txtsurname" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="710px">
                   </dx:ASPxTextBox>
               </td>

           </tr>
            <tr>
                    <td colspan ="7" align="center">
                    </td>

            </tr>

        </table>

    </asp:panel>
        <asp:panel id="Panel11" runat="server" GroupingText="Classification" Font-Names="Cambria">
        <table width="810px">
            <tr>
                    <td colspan ="2" align="center">
                        &nbsp;</td>

            </tr>
         
           <tr>
               <td colspan ="1" style="width: 109px">
                   <dx:ASPxLabel ID="ASPxLabel56" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Current Class" Theme="Glass">
                   </dx:ASPxLabel>
               </td>
               <td>
                   <dx:ASPxTextBox ID="txtcurrentclass" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="250px">
                   </dx:ASPxTextBox>
                   &nbsp;<dx:ASPxLabel ID="txtclasscode" runat="server" Font-Names="Cambria" Font-Size="Small" Theme="Glass" Visible="False">
                   </dx:ASPxLabel>
               </td>

           </tr>
             <tr>
               <td colspan ="1" style="width: 109px">
                   <dx:ASPxLabel ID="ASPxLabel35" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Class Type" Theme="Glass">
                   </dx:ASPxLabel>
                 </td>
               <td>
                   <dx:ASPxComboBox ID="cmbclasstype" runat="server" Theme="BlackGlass" ValueType="System.String" Width="710px">
                   </dx:ASPxComboBox>
                 </td>

           </tr>
               
            <tr>
                <td colspan="1" style="width: 109px">
                    <dx:ASPxLabel ID="ASPxLabel55" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Comments" Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                <td>
                    <dx:ASPxTextBox ID="txtComments" runat="server" BackColor="#E4E4E4" Height="80px" Theme="BlackGlass" Width="710px">
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
                            <dx:ASPxButton ID="ASPxButton5" runat="server" Text="save" Theme="BlackGlass">
                            </dx:ASPxButton>
                        </td>

                </tr>

            </table>
        </asp:Panel>  
                 
</asp:Panel>
  
</div>
</asp:Content>

