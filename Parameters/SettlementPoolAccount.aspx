<%@ Page Language="VB" MasterPageFile="~/CDSUser.master" AutoEventWireup="false" CodeFile="SettlementPoolAccount.aspx.vb" Inherits="Parameters_SettlementPoolAccount" title="Account Details Enquiry" %>


<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>

<asp:Content id="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    <div>
    <asp:Panel id="Panel1" runat="server" Width="840px" Font-Names="Arial" Font-Size="Medium" BackColor="White">
        
    
        <table width ="810px">
            <tr>
                   <td style ="text-align :left;" align="left">
                       <dx:ASPxLabel ID="ASPxLabel1" runat="server" Text="Parameters&gt;&gt;Settlement Pool Account(s)" Font-Names="Cambria" Font-Size="Small" Theme="PlasticBlue"></dx:ASPxLabel>

                   </td>
            </tr>
        </table>

    
        <asp:Panel runat="server" ID="Panel3" Font-Names="Cambria" GroupingText="Pool Account Details">

                <table width="810px">
<tr>
        <td colspan ="1">
            <dx:ASPxLabel ID="ASPxLabel4" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Account Name" Theme="Glass">
            </dx:ASPxLabel>
        </td>
    <td colspan ="1">
        <dx:ASPxTextBox ID="txtClientNo" runat="server" Theme="BlackGlass" Width="250px" BackColor="#E4E4E4">
        </dx:ASPxTextBox>
        </td>
    <td colspan ="1">
        &nbsp;</td>
    <td colspan ="1">
        &nbsp;</td>
    <td colspan ="1">
        &nbsp;</td>
    <td colspan ="1">
        &nbsp;</td>
    <td colspan ="1"></td>
    <td colspan ="1"></td>

</tr>
                    <tr>
                            <td colspan ="1">
                                <dx:ASPxLabel ID="ASPxLabel9" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Bank" Theme="Glass">
                                </dx:ASPxLabel>
                            </td>
                        <td colspan ="1">
                            <dx:ASPxComboBox ID="ASPxComboBox1" runat="server" Theme="BlackGlass" ValueType="System.String" Width="250px">
                            </dx:ASPxComboBox>
                            </td>
                        <td colspan ="1">
                            <dx:ASPxLabel ID="ASPxLabel5" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Branch" Theme="Glass">
                            </dx:ASPxLabel>
                            </td>
                        <td colspan ="1">
                            <dx:ASPxComboBox ID="ASPxComboBox2" runat="server" Theme="BlackGlass" ValueType="System.String" Width="250px">
                            </dx:ASPxComboBox>
                            </td>
                        <td colspan ="1">
                            &nbsp;</td>
                        <td colspan ="1"></td>
                        <td colspan ="1"></td>
                        <td colspan ="1"></td>

                    </tr>
                    <tr>
                            <td colspan ="1">
                                <dx:ASPxLabel ID="ASPxLabel7" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Account Number" Theme="Glass">
                                </dx:ASPxLabel>
                            </td>
                        <td colspan ="1">
                            <dx:ASPxTextBox ID="txtClientNo6" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="250px">
                            </dx:ASPxTextBox>
                            </td>
                        <td colspan ="1"></td>
                        <td colspan ="1">
                            <dx:ASPxCheckBox ID="ASPxCheckBox1" runat="server" Text="Account Activated" Theme="Glass">
                            </dx:ASPxCheckBox>
                            </td>
                        <td colspan ="1"></td>
                        <td colspan ="1"></td>
                        <td colspan ="1"></td>
                        <td colspan ="1"></td>

                    </tr>
                    <tr>

                        <td colspan ="1">
                            <dx:ASPxLabel ID="ASPxLabel10" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Account Beneficiaries" Theme="Glass">
                            </dx:ASPxLabel>
                        </td>
                        <td colspan ="1">
                            <dx:ASPxComboBox ID="ASPxComboBox3" runat="server" Theme="BlackGlass" ValueType="System.String" Width="250px">
                            </dx:ASPxComboBox>
                        </td>
                        <td colspan ="1">
                            <dx:ASPxLabel ID="ASPxLabel11" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Messaging Protocol" Theme="Glass">
                            </dx:ASPxLabel>
                        </td>
                        <td colspan ="1">
                            <dx:ASPxComboBox ID="ASPxComboBox4" runat="server" Theme="BlackGlass" ValueType="System.String" Width="250px">
                            </dx:ASPxComboBox>
                        </td>
                        <td colspan ="1"></td>
                        <td colspan ="1"></td>
                        <td colspan ="1"></td>
                        <td colspan ="1"></td>
                    </tr>
                    <tr>

                        <td colspan ="1">
                            &nbsp;</td>
                        <td colspan ="1">
                            &nbsp;</td>
                        <td colspan ="1">
                            <dx:ASPxLabel ID="ASPxLabel3" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Messaging Format" Theme="Glass">
                            </dx:ASPxLabel>
                        </td>
                        <td colspan ="1">
                            <dx:ASPxComboBox ID="ASPxComboBox6" runat="server" Theme="BlackGlass" ValueType="System.String" Width="250px">
                            </dx:ASPxComboBox>
                        </td>
                        <td colspan ="1"></td>
                        <td colspan ="1"></td>
                        <td colspan ="1"></td>
                        <td colspan ="1"></td>
                    </tr>
                 
        </table>
        </asp:Panel>
        

         <asp:Panel runat="server" ID="Panel4" Font-Names="Cambria" GroupingText="Saved Settlement Accounts" Font-Size="Medium">

                <table width="810px">
<tr>
        
    <td colspan ="8" align="center">
        <dx:ASPxGridView ID="ASPxGridView3" runat="server" Theme="BlackGlass" Width="800px">
        </dx:ASPxGridView>
        </td>
   

</tr>
                 
        </table>
        </asp:Panel>
        <asp:Panel runat="server" ID="Panel8" Font-Names="Cambria" GroupingText="_" Font-Size="Medium">

                <table width="810px">
<tr>
        
    <td colspan ="8" align="center">
        
        <dx:ASPxButton ID="ASPxButton1" runat="server" Text="save" Theme="BlackGlass">
        </dx:ASPxButton>
        <dx:ASPxButton ID="ASPxButton2" runat="server" BackColor="#FF3300" Text="delete" Theme="RedWine">
        </dx:ASPxButton>
        
        </td>
   

</tr>
                 
        </table>
        </asp:Panel>
      
        
</asp:Panel>
  
</div>
</asp:Content>

