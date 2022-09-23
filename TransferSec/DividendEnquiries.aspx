<%@ Page Language="VB" MasterPageFile="~/CDSUser.master" AutoEventWireup="false" CodeFile="DividendEnquiries.aspx.vb" Inherits="TransferSec_DividendEnquiries" title="Account Details Enquiry" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<asp:Content id="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
    <asp:Panel id="Panel1" runat="server" Width="840px" Font-Names="Arial" Font-Size="Medium" BackColor="White">
    
        <table width ="810px">
            <tr>
                   <td style ="text-align :left;" align="left">
                       <dx:ASPxLabel ID="ASPxLabel1" runat="server" Text="Enquiries&gt;&gt;Dividend" Font-Names="Cambria" Font-Size="Small" Theme="PlasticBlue"></dx:ASPxLabel>

                   </td>
            </tr>
        </table>
        <asp:Panel runat="server" ID="PanelType" Font-Names="Cambria" GroupingText="Dividend Enquiries">

            <table width ="810px">
                <tr>
                    <td colspan ="8" align ="center">
                        <asp:RadioButton ID="rdSingle" runat="server" GroupName="enquiryType" Text="Single Company Enquiry" />
                        <asp:RadioButton ID="rdSingle0" runat="server" GroupName="enquiryType" Text="All Companies Enquiry" />
                    </td>
                </tr>
                    <tr>
                <td colspan ="1" align="right" >
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
                        <td colspan ="1" align="right">
                            <dx:ASPxLabel ID="ASPxLabel79" runat="server" Font-Names="Cambria" Text="Client ID." Theme="Glass">
                            </dx:ASPxLabel>
                        </td>
                    <td colspan ="4" width="250">
                        <dx:ASPxTextBox ID="txtClientNo19" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="250px">
                        </dx:ASPxTextBox>
                        </td>
                    <td colspan ="3" align="left"> <dx:ASPxButton ID="ASPxButton9" runat="server" Text="&gt;&gt;" Theme="BlackGlass" Width="50px">
                        </dx:ASPxButton></td>

                </tr>
                <tr>
                        <td colspan ="1" align="right">
                            <dx:ASPxLabel ID="ASPxLabel13" runat="server" Font-Names="Cambria" Text="Client Name." Theme="Glass">
                            </dx:ASPxLabel>
                        </td>
                    <td colspan ="4" width="250">
                        <dx:ASPxTextBox ID="ASPxTextBox12" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="250px">
                        </dx:ASPxTextBox>
                        </td>
                    <td colspan ="3" align="left"> <dx:ASPxButton ID="ASPxButton1" runat="server" Text="&gt;&gt;" Theme="BlackGlass" Width="50px">
                        </dx:ASPxButton></td>

                </tr>
                <tr>
                        <td colspan ="4" align="right"></td>
                    <td colspan ="4">
                        
                        </td>

                </tr>
       
               
                <tr>
                <td colspan ="8" align="center">
                    <dx:ASPxButton ID="ASPxButton8" runat="server" Text="Search" Theme="BlackGlass">
                    </dx:ASPxButton>

                </td>
               
           </tr>
                        <tr>
                            <td colspan="8">
                                <asp:Panel ID="PanelEft" runat="server" Font-Names="Cambria" GroupingText="Search Results">
                                    <table>
                                    <tr>
                                        <td colspan ="6" align="center">
                                            <dx:ASPxGridView ID="ASPxGridView1" runat="server" Theme="Aqua" Width="800px">
                                            </dx:ASPxGridView>
                                        </td>
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
                    <dx:ASPxButton ID="ASPxButton7" runat="server" Text="Print Dividend Report" Theme="BlackGlass" Width="163px">
                    </dx:ASPxButton>
                    </td>
               
           </tr>

            </table>
        </asp:Panel>
         
                 
</asp:Panel>
  
</div>
</asp:Content>

