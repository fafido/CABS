<%@ Page Language="VB" MasterPageFile="~/CDSUser.master" AutoEventWireup="false" CodeFile="DividendInstructionsApproval.aspx.vb" Inherits="TransferSec_DividendInstructionsApproval" title="Account Details Enquiry" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<asp:Content id="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
    <asp:Panel id="Panel1" runat="server" Width="840px" Font-Names="Arial" Font-Size="Medium" BackColor="White">
    
        <table width ="810px">
            <tr>
                   <td style ="text-align :left;" align="left">
                       <dx:ASPxLabel ID="ASPxLabel1" runat="server" Text="Authorizations&gt;&gt;Dividend Instructions Approval" Font-Names="Cambria" Font-Size="Small" Theme="PlasticBlue"></dx:ASPxLabel>

                   </td>
            </tr>
        </table>
        <asp:Panel runat="server" ID="Panel3" Font-Names="Cambria" GroupingText="Pending Approval Dividend Instructions">

            <table width ="810px">
                <tr>
                        <td colspan ="8">&nbsp;</td>

                </tr>
           <tr>
                <td colspan ="1">
                    <dx:ASPxLabel ID="ASPxLabel2" runat="server" Font-Names="Cambria" Text="Company" Theme="Glass">
                    </dx:ASPxLabel>
                </td>
               <td colspan ="1">
                   <dx:ASPxComboBox ID="ASPxComboBox1" runat="server" Theme="Glass" ValueType="System.String" Width="250px">
                   </dx:ASPxComboBox>
                </td>
               <td colspan ="1"></td>
               <td colspan ="1"></td>
               <td colspan ="1">
                   <dx:ASPxLabel ID="ASPxLabel5" runat="server" Font-Names="Cambria" Text="Dividend Number" Theme="Glass">
                   </dx:ASPxLabel>
                </td>
               <td colspan ="1">
                   <dx:ASPxComboBox ID="ASPxComboBox3" runat="server" Theme="Glass" ValueType="System.String" Width="250px">
                   </dx:ASPxComboBox>
                </td>
               <td colspan ="1"></td>
               <td colspan ="1"></td>
           </tr>

                <tr>
                        <td colspan ="8">&nbsp;</td>

                </tr>
               
            </table>
        </asp:Panel>
        <asp:Panel runat="server" ID="PanelType" Font-Names="Cambria" GroupingText="Dividend Details">

            <table width ="810px">
           <tr>
                <td colspan ="1">
                    <dx:ASPxLabel ID="ASPxLabel65" runat="server" Font-Names="Cambria" Text="Company" Theme="Glass">
                    </dx:ASPxLabel>
                </td>
               <td colspan ="1">
                   <dx:ASPxComboBox ID="cmbCompany" runat="server" Theme="Glass" ValueType="System.String" Width="250px">
                   </dx:ASPxComboBox>
                </td>
               <td colspan ="1"></td>
               <td colspan ="1"></td>
               <td colspan ="1">
                   <dx:ASPxLabel ID="ASPxLabel66" runat="server" Font-Names="Cambria" Text="Dividend Number" Theme="Glass">
                   </dx:ASPxLabel>
                </td>
               <td colspan ="1">
                   <dx:ASPxTextBox ID="txtClientNo" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="250px">
                   </dx:ASPxTextBox>
                </td>
               <td colspan ="1"></td>
               <td colspan ="1"></td>
           </tr>
                <tr>
                <td colspan ="1">
                    <dx:ASPxLabel ID="ASPxLabel67" runat="server" Font-Names="Cambria" Text="Dividend Type" Theme="Glass">
                    </dx:ASPxLabel>
                    </td>
               <td colspan ="1">
                   <dx:ASPxComboBox ID="cmbCompany0" runat="server" Theme="Glass" ValueType="System.String" Width="250px">
                   </dx:ASPxComboBox>
                    </td>
               <td colspan ="1"></td>
               <td colspan ="1"></td>
               <td colspan ="1">
                   <dx:ASPxLabel ID="ASPxLabel68" runat="server" Font-Names="Cambria" Text="Date Declared" Theme="Glass">
                   </dx:ASPxLabel>
                    </td>
               <td colspan ="1">
                   <dx:ASPxDateEdit ID="txtDateDeclared" runat="server" Theme="Aqua" Width="250px">
                   </dx:ASPxDateEdit>
                    </td>
               <td colspan ="1"></td>
               <td colspan ="1"></td>
           </tr>
                <tr>
                <td colspan ="1">
                    <dx:ASPxLabel ID="ASPxLabel69" runat="server" Font-Names="Cambria" Text="Date Closed" Theme="Glass">
                    </dx:ASPxLabel>
                    </td>
               <td colspan ="1">
                   <dx:ASPxDateEdit ID="txtDateDeclared0" runat="server" Theme="Aqua" Width="250px">
                   </dx:ASPxDateEdit>
                    </td>
               <td colspan ="1"></td>
               <td colspan ="1"></td>
               <td colspan ="1">
                   <dx:ASPxLabel ID="ASPxLabel70" runat="server" Font-Names="Cambria" Text="Payment Date" Theme="Glass">
                   </dx:ASPxLabel>
                    </td>
               <td colspan ="1">
                   <dx:ASPxDateEdit ID="txtDateDeclared1" runat="server" Theme="Aqua" Width="250px">
                   </dx:ASPxDateEdit>
                    </td>
               <td colspan ="1"></td>
               <td colspan ="1"></td>
           </tr>
                <tr>
                <td colspan ="1">
                    <dx:ASPxLabel ID="ASPxLabel71" runat="server" Font-Names="Cambria" Text="Rate Per Share" Theme="Glass">
                    </dx:ASPxLabel>
                    </td>
               <td colspan ="1">
                   <dx:ASPxTextBox ID="txtClientNo11" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="250px">
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
                    <dx:ASPxLabel ID="ASPxLabel72" runat="server" Font-Names="Cambria" Text="Message (1)" Theme="Glass">
                    </dx:ASPxLabel>
                    </td>
               <td colspan ="7">
                   <dx:ASPxTextBox ID="txtClientNo12" runat="server" BackColor="#E4E4E4" Height="80px" Theme="BlackGlass" Width="660px">
                   </dx:ASPxTextBox>
                    </td>
               
           </tr>
                <tr>
                <td colspan ="1">
                    <dx:ASPxLabel ID="ASPxLabel73" runat="server" Font-Names="Cambria" Text="Message (2)" Theme="Glass">
                    </dx:ASPxLabel>
                    </td>
               <td colspan ="7">
                   <dx:ASPxTextBox ID="txtClientNo13" runat="server" BackColor="#E4E4E4" Height="80px" Theme="BlackGlass" Width="660px">
                   </dx:ASPxTextBox>
                    </td>
               
           </tr>
                <tr>
                <td colspan ="1">
                    <dx:ASPxLabel ID="ASPxLabel74" runat="server" Font-Names="Cambria" Text="Comments" Theme="Glass">
                    </dx:ASPxLabel>
                    </td>
               <td colspan ="7">
                   <dx:ASPxTextBox ID="txtClientNo14" runat="server" BackColor="#E4E4E4" Height="80px" Theme="BlackGlass" Width="660px">
                   </dx:ASPxTextBox>
                    </td>
               
           </tr>
                <tr>
                <td colspan ="8">
                    <asp:Panel runat="server" ID="PanelEft" Font-Names="Cambria" GroupingText="Dividend Payment Methods">

                        <table>
                            <tr>
                                <td colspan ="6" align="center">
                                    <asp:CheckBox ID="CheckBox1" runat="server" Text="Enable EFT Payment" />
                                    <asp:CheckBox ID="CheckBox2" runat="server" Text="Enable SWIFT Payment" />
                                    <asp:CheckBox ID="CheckBox3" runat="server" Text="Enable Postillion Payment" />
                                </td>

                            </tr>
                                <tr>
                                        <td colspan ="1">
                                            <dx:ASPxLabel ID="ASPxLabel75" runat="server" Font-Names="Cambria" Text="Bank" Theme="Glass">
                                            </dx:ASPxLabel>
                                        </td>
                                    <td colspan ="1">
                                        <dx:ASPxComboBox ID="cmbCompany1" runat="server" Theme="Glass" ValueType="System.String" Width="250px">
                                        </dx:ASPxComboBox>
                                        </td>
                                    <td colspan ="1"></td>
                                    <td colspan ="1"></td>
                                    <td colspan ="1">
                                        <dx:ASPxLabel ID="ASPxLabel76" runat="server" Font-Names="Cambria" Text="Branch" Theme="Glass">
                                        </dx:ASPxLabel>
                                        </td>
                                    <td colspan ="1">
                                        <dx:ASPxComboBox ID="cmbCompany2" runat="server" Theme="Glass" ValueType="System.String" Width="250px">
                                        </dx:ASPxComboBox>
                                        </td>


                                </tr>
                                <tr>
                                        <td colspan ="1">
                                            <dx:ASPxLabel ID="ASPxLabel77" runat="server" Font-Names="Cambria" Text="Account No." Theme="Glass">
                                            </dx:ASPxLabel>
                                        </td>
                                    <td colspan ="1">
                                        <dx:ASPxTextBox ID="txtClientNo15" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="250px">
                                        </dx:ASPxTextBox>
                                        </td>
                                    <td colspan ="1"></td>
                                    <td colspan ="1"></td>
                                    <td colspan ="1"></td>
                                    <td colspan ="1"></td>


                                </tr>
                               

                        </table>
                    </asp:Panel>

                </td>
               
           </tr>
                        <tr>
                <td colspan ="8">
                    <asp:Panel runat="server" ID="Panel2" Font-Names="Cambria" GroupingText="Scrip Dividend">

                        <table>
                            <tr>
                                <td colspan ="6" align="center">
                                    <asp:CheckBox ID="CheckBox4" runat="server" Text="Enable Scrip Dividend" />
                                                                    </td>

                            </tr>
                                <tr>
                                        <td colspan ="1">
                                            <dx:ASPxLabel ID="ASPxLabel4" runat="server" Font-Names="Cambria" Text="Account No." Theme="Glass">
                                            </dx:ASPxLabel>
                                        </td>
                                    <td colspan ="1">
                                        <dx:ASPxTextBox ID="ASPxTextBox1" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="250px">
                                        </dx:ASPxTextBox>
                                        </td>
                                    <td colspan ="1"></td>
                                    <td colspan ="1"></td>
                                    <td colspan ="1">
                                        <dx:ASPxLabel ID="ASPxLabel3" runat="server" Font-Names="Cambria" Text="Rounding" Theme="Glass">
                                        </dx:ASPxLabel>
                                        </td>
                                    <td colspan ="1">
                                        <dx:ASPxComboBox ID="ASPxComboBox2" runat="server" Theme="Glass" ValueType="System.String" Width="250px">
                                        </dx:ASPxComboBox>
                                        </td>


                                </tr>
                                <tr>
                                        <td colspan ="1">
                                            &nbsp;</td>
                                    <td colspan ="1">
                                        &nbsp;</td>
                                    <td colspan ="1"></td>
                                    <td colspan ="1"></td>
                                    <td colspan ="1"></td>
                                    <td colspan ="1"></td>


                                </tr>
                               

                        </table>
                    </asp:Panel>

                </td>
               
           </tr>
              
                <tr>
                <td colspan ="8" align="center">
                    <dx:ASPxButton ID="ASPxButton7" runat="server" Text="save" Theme="BlackGlass">
                    </dx:ASPxButton>
                    </td>
               
           </tr>

            </table>
        </asp:Panel>
         
                 
</asp:Panel>
  
</div>
</asp:Content>

