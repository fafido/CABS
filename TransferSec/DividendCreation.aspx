<%@ Page Language="VB" MasterPageFile="~/CDSUser.master" AutoEventWireup="false" CodeFile="DividendCreation.aspx.vb" Inherits="TransferSec_DividendCreation" title="Account Details Enquiry" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<asp:Content id="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
    <asp:Panel id="Panel1" runat="server" Width="840px" Font-Names="Arial" Font-Size="Medium" BackColor="White">
    
        <table width ="810px">
            <tr>
                   <td style ="text-align :left;" align="left">
                       <dx:ASPxLabel ID="ASPxLabel1" runat="server" Text="Authorizations&gt;&gt;Dividend Creation" Font-Names="Cambria" Font-Size="Small" Theme="PlasticBlue"></dx:ASPxLabel>

                   </td>
            </tr>
        </table>
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
                   <dx:ASPxComboBox ID="cmbCompany0" runat="server" Theme="Glass" ValueType="System.String" Width="250px">
                   </dx:ASPxComboBox>
                </td>
               <td colspan ="1"></td>
               <td colspan ="1"></td>
           </tr>
               
                <tr>
                <td colspan ="8" align="center">
                    <dx:ASPxButton ID="ASPxButton8" runat="server" Text="create dividend" Theme="BlackGlass">
                    </dx:ASPxButton>

                </td>
               
           </tr>
                        <tr>
                            <td colspan="8">
                                <asp:Panel ID="PanelEft" runat="server" Font-Names="Cambria" GroupingText="Created Dividend Summary">
                                    <table>
                                        <tr>
                                            <td colspan="1">
                                                <dx:ASPxLabel ID="ASPxLabel75" runat="server" Font-Names="Cambria" Text="Dividend Type" Theme="Glass">
                                                </dx:ASPxLabel>
                                            </td>
                                            <td colspan="1">
                                                <dx:ASPxTextBox ID="txtClientNo15" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="250px">
                                                </dx:ASPxTextBox>
                                            </td>
                                            <td colspan="1"></td>
                                            <td colspan="1"></td>
                                            <td colspan="1">
                                                <dx:ASPxLabel ID="ASPxLabel76" runat="server" Font-Names="Cambria" Text="Year Ending" Theme="Glass">
                                                </dx:ASPxLabel>
                                            </td>
                                            <td colspan="1">
                                                <dx:ASPxTextBox ID="txtClientNo16" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="250px">
                                                </dx:ASPxTextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="1">
                                                <dx:ASPxLabel ID="ASPxLabel77" runat="server" Font-Names="Cambria" Text="Dividend Due Date" Theme="Glass">
                                                </dx:ASPxLabel>
                                            </td>
                                            <td colspan="1">
                                                <dx:ASPxTextBox ID="txtClientNo17" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="250px">
                                                </dx:ASPxTextBox>
                                            </td>
                                            <td colspan="1"></td>
                                            <td colspan="1"></td>
                                            <td colspan="1">
                                                <dx:ASPxLabel ID="ASPxLabel78" runat="server" Font-Names="Cambria" Text="Dividend Closure Date" Theme="Glass">
                                                </dx:ASPxLabel>
                                            </td>
                                            <td colspan="1">
                                                <dx:ASPxTextBox ID="txtClientNo18" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="250px">
                                                </dx:ASPxTextBox>
                                            </td>
                                        </tr>
                                          <tr>
                                            <td colspan="1">
                                                <dx:ASPxLabel ID="ASPxLabel2" runat="server" Font-Names="Cambria" Text="Dividend Account No." Theme="Glass">
                                                </dx:ASPxLabel>
                                            </td>
                                            <td colspan="1">
                                                <dx:ASPxTextBox ID="ASPxTextBox1" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="250px">
                                                </dx:ASPxTextBox>
                                            </td>
                                            <td colspan="1"></td>
                                            <td colspan="1"></td>
                                            <td colspan="1">
                                                <dx:ASPxLabel ID="ASPxLabel3" runat="server" Font-Names="Cambria" Text="Dividend No." Theme="Glass">
                                                </dx:ASPxLabel>
                                            </td>
                                            <td colspan="1">
                                                <dx:ASPxTextBox ID="ASPxTextBox2" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="250px">
                                                </dx:ASPxTextBox>
                                            </td>
                                        </tr>
                                          <tr>
                                            <td colspan="1">
                                                <dx:ASPxLabel ID="ASPxLabel4" runat="server" Font-Names="Cambria" Text="Dividend Rate" Theme="Glass">
                                                </dx:ASPxLabel>
                                            </td>
                                            <td colspan="1">
                                                <dx:ASPxTextBox ID="ASPxTextBox3" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="250px">
                                                </dx:ASPxTextBox>
                                            </td>
                                            <td colspan="1"></td>
                                            <td colspan="1"></td>
                                            <td colspan="1">
                                                <dx:ASPxLabel ID="ASPxLabel5" runat="server" Font-Names="Cambria" Text="Dividend Start Cheque No" Theme="Glass">
                                                </dx:ASPxLabel>
                                            </td>
                                            <td colspan="1">
                                                <dx:ASPxTextBox ID="ASPxTextBox4" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="250px">
                                                </dx:ASPxTextBox>
                                            </td>
                                        </tr>
                                          <tr>
                                            <td colspan="1">
                                                <dx:ASPxLabel ID="ASPxLabel6" runat="server" Font-Names="Cambria" Text="Accounts With EFT Instruction" Theme="Glass">
                                                </dx:ASPxLabel>
                                            </td>
                                            <td colspan="1">
                                                <dx:ASPxTextBox ID="ASPxTextBox5" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="250px">
                                                </dx:ASPxTextBox>
                                            </td>
                                            <td colspan="1"></td>
                                            <td colspan="1"></td>
                                            <td colspan="1">
                                                <dx:ASPxLabel ID="ASPxLabel7" runat="server" Font-Names="Cambria" Text="Accounts With SWIFT Instruction" Theme="Glass">
                                                </dx:ASPxLabel>
                                            </td>
                                            <td colspan="1">
                                                <dx:ASPxTextBox ID="ASPxTextBox6" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="250px">
                                                </dx:ASPxTextBox>
                                            </td>
                                        </tr>
                                          <tr>
                                            <td colspan="1">
                                                <dx:ASPxLabel ID="ASPxLabel8" runat="server" Font-Names="Cambria" Text="Total Shareholders" Theme="Glass">
                                                </dx:ASPxLabel>
                                            </td>
                                            <td colspan="1">
                                                <dx:ASPxTextBox ID="ASPxTextBox7" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="250px">
                                                </dx:ASPxTextBox>
                                            </td>
                                            <td colspan="1"></td>
                                            <td colspan="1"></td>
                                            <td colspan="1">
                                                <dx:ASPxLabel ID="ASPxLabel9" runat="server" Font-Names="Cambria" Text="Total Shares" Theme="Glass">
                                                </dx:ASPxLabel>
                                            </td>
                                            <td colspan="1">
                                                <dx:ASPxTextBox ID="ASPxTextBox8" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="250px">
                                                </dx:ASPxTextBox>
                                            </td>
                                        </tr>
                                            <tr>
                                            <td colspan="1">
                                                <dx:ASPxLabel ID="ASPxLabel10" runat="server" Font-Names="Cambria" Text="Total Gross Dividend" Theme="Glass">
                                                </dx:ASPxLabel>
                                            </td>
                                            <td colspan="1">
                                                <dx:ASPxTextBox ID="ASPxTextBox9" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="250px">
                                                </dx:ASPxTextBox>
                                            </td>
                                            <td colspan="1"></td>
                                            <td colspan="1"></td>
                                            <td colspan="1">
                                                <dx:ASPxLabel ID="ASPxLabel11" runat="server" Font-Names="Cambria" Text="Total Net Dividend" Theme="Glass">
                                                </dx:ASPxLabel>
                                            </td>
                                            <td colspan="1">
                                                <dx:ASPxTextBox ID="ASPxTextBox10" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="250px">
                                                </dx:ASPxTextBox>
                                            </td>
                                        </tr>
                                            <tr>
                                            <td colspan="1">
                                                <dx:ASPxLabel ID="ASPxLabel12" runat="server" Font-Names="Cambria" Text="Tax Deducted" Theme="Glass">
                                                </dx:ASPxLabel>
                                            </td>
                                            <td colspan="1">
                                                <dx:ASPxTextBox ID="ASPxTextBox11" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="250px">
                                                </dx:ASPxTextBox>
                                            </td>
                                            <td colspan="1"></td>
                                            <td colspan="1"></td>
                                            <td colspan="1">
                                                &nbsp;</td>
                                            <td colspan="1">
                                                &nbsp;</td>
                                        </tr>
                                            <tr>
                                            <td colspan="1">
                                                &nbsp;</td>
                                            <td colspan="1">
                                                &nbsp;</td>
                                            <td colspan="1"></td>
                                            <td colspan="1"></td>
                                            <td colspan="1">
                                                &nbsp;</td>
                                            <td colspan="1">
                                                &nbsp;</td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                            </td>
                </tr>
                        <tr>
                <td colspan ="8">
                    &nbsp;</td>
               
           </tr>
              
                <tr>
                <td colspan ="8" align="center">
                    <dx:ASPxButton ID="ASPxButton7" runat="server" Text="Print Control Summary" Theme="BlackGlass" Width="163px">
                    </dx:ASPxButton>
                    </td>
               
           </tr>

            </table>
        </asp:Panel>
         
                 
</asp:Panel>
  
</div>
</asp:Content>

