<%@ Page Language="VB" MasterPageFile="~/CDSUser.master" AutoEventWireup="false" CodeFile="UserManagement.aspx.vb" Inherits="Parameters_UserManagement" title="Account Details Enquiry" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<asp:Content id="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
    <asp:Panel id="Panel1" runat="server" Width="840px" Font-Names="Arial" Font-Size="Medium" BackColor="White">
    
        <table width ="810px">
            <tr>
                   <td style ="text-align :left;" align="left">
                       <dx:ASPxLabel ID="ASPxLabel1" runat="server" Text="System User Accounts&gt;&gt;User account management" Font-Names="Cambria" Font-Size="Small" Theme="PlasticBlue"></dx:ASPxLabel>

                   </td>
            </tr>
        </table>

          <asp:Panel runat="server" ID="Panel4" Font-Names="Cambria" GroupingText="Form Options">

              <table width ="810px">
                  <tr>
                        <td align="center"></td>

                  </tr>
              </table>
                <table width="810px">
                    <tr>
                        <td colspan ="2" align="right">
                            <dx:ASPxRadioButton ID="rdExisting" runat="server" AutoPostBack="True" GroupName="FormOptions" Text="Search Existing" Theme="DevEx">
                            </dx:ASPxRadioButton>
                        </td>
                            <td colspan ="2" align ="left" >
                                <dx:ASPxRadioButton ID="rdNew" runat="server" AutoPostBack="True" GroupName="FormOptions" Text="Create New" Theme="DevEx">
                                </dx:ASPxRadioButton>
                            </td>
                        <td colspan ="2" align ="left" >
                            &nbsp;</td>
                        <td colspan ="2"></td>
                    </tr>
                    <tr>

                        <td colspan ="1" align ="right">
                            &nbsp;</td>
                        <td colspan ="2">
                            <dx:ASPxLabel ID="ASPxLabel21" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Username" Theme="Glass">
                            </dx:ASPxLabel>
                            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                            <dx:ASPxButton ID="ASPxButton4" runat="server" Text="&gt;&gt;" Theme="BlackGlass" Width="78px">
                            </dx:ASPxButton>
                        </td>
                        <td colspan ="2">
                            &nbsp;</td>
                        <td colspan ="3"></td>
                    </tr>
                    <tr>
                        <td colspan="1">
                            &nbsp;</td>
                        <td colspan ="7">
                            &nbsp;</td>

                    </tr>
                 
        </table>
        </asp:Panel>
    
        <asp:Panel runat="server" ID="Panel3" Font-Names="Cambria" GroupingText="User Basic Details">

                <table width="810px">
                    <tr>
                            <td colspan ="1">
                                <dx:ASPxLabel ID="ASPxLabel12" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Surname" Theme="Glass">
                                </dx:ASPxLabel>
                            </td>
                        <td colspan ="1">
                            <dx:ASPxTextBox ID="txtClientNo8" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="250px">
                            </dx:ASPxTextBox>
                            </td>
                        <td colspan ="1">
                            <dx:ASPxLabel ID="ASPxLabel13" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Other Names" Theme="Glass">
                            </dx:ASPxLabel>
                            </td>
                        <td colspan ="1">
                            <dx:ASPxTextBox ID="txtClientNo9" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="250px">
                            </dx:ASPxTextBox>
                            </td>
                        <td colspan ="1">
                            <dx:ASPxLabel ID="ASPxLabel14" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Title" Theme="Glass">
                            </dx:ASPxLabel>
                            </td>
                        <td colspan ="1">
                            <dx:ASPxTextBox ID="txtClientNo7" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="65px">
                            </dx:ASPxTextBox>
                            </td>
                        <td colspan ="1"></td>
                        <td colspan ="1"></td>


                    </tr>
                    <tr>
                            <td colspan ="1">
                                <dx:ASPxLabel ID="ASPxLabel15" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Email" Theme="Glass">
                                </dx:ASPxLabel>
                            </td>
                        <td colspan ="1">
                            <dx:ASPxTextBox ID="txtClientNo10" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="250px">
                            </dx:ASPxTextBox>
                            </td>
                        <td colspan ="1">
                            <dx:ASPxLabel ID="ASPxLabel16" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Mobile" Theme="Glass">
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


                    </tr>
                    <tr>
                            <td colspan ="1">
                                <dx:ASPxLabel ID="ASPxLabel17" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Address" Theme="Glass">
                                </dx:ASPxLabel>
                            </td>
                        <td colspan ="7">
                            <dx:ASPxTextBox ID="txtClientNo12" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="720px">
                            </dx:ASPxTextBox>
                            </td>
                        


                    </tr>
                    <tr>
                        <td colspan ="1"></td>
                        <td colspan ="7">
                            <dx:ASPxTextBox ID="txtClientNo13" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="720px">
                            </dx:ASPxTextBox>
                        </td>

                    </tr>
                    <tr>
                        <td colspan="1">
                            <asp:Label ID="Label2" runat="server" Text="___________"></asp:Label>
                        </td>
                        <td colspan ="7">
                            <dx:ASPxTextBox ID="txtClientNo14" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="720px">
                            </dx:ASPxTextBox>
                        </td>

                    </tr>
                 
        </table>
        </asp:Panel>
        
        <asp:Panel runat="server" ID="Panel2" Font-Names="Cambria" GroupingText="User Account Details">

                <table width="810px">

                    <tr>
                            <td colspan ="1">
                                <dx:ASPxLabel ID="ASPxLabel4" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Company" Theme="Glass">
                                </dx:ASPxLabel>
                            </td>
                        <td colspan ="1">
                            <dx:ASPxDropDownEdit ID="ASPxDropDownEdit3" runat="server" Theme="Glass" Width="250px">
                            </dx:ASPxDropDownEdit>
                            </td>
                        <td colspan ="1">
                            <dx:ASPxLabel ID="ASPxLabel6" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Company Code" Theme="Glass">
                            </dx:ASPxLabel>
                            </td>
                        <td colspan ="1">
                            <dx:ASPxTextBox ID="txtClientNo15" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="250px">
                            </dx:ASPxTextBox>
                            </td>
                        <td colspan ="1">
                            &nbsp;</td>
                        <td colspan ="1">
                            &nbsp;</td>
                        <td colspan ="1"></td>
                        <td colspan ="1"></td>


                    </tr>
                    <tr>
                            <td colspan ="1">
                                <dx:ASPxLabel ID="ASPxLabel2" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Department" Theme="Glass">
                                </dx:ASPxLabel>
                            </td>
                        <td colspan ="1">
                            <dx:ASPxDropDownEdit ID="ASPxDropDownEdit1" runat="server" Theme="Glass" Width="250px">
                            </dx:ASPxDropDownEdit>
                            </td>
                        <td colspan ="1">
                            <dx:ASPxLabel ID="ASPxLabel3" runat="server" Font-Names="Cambria" Font-Size="Small" Text="User Role" Theme="Glass">
                            </dx:ASPxLabel>
                            </td>
                        <td colspan ="1">
                            <dx:ASPxDropDownEdit ID="ASPxDropDownEdit2" runat="server" Theme="Glass" Width="250px">
                            </dx:ASPxDropDownEdit>
                            </td>
                        <td colspan ="1">
                            &nbsp;</td>
                        <td colspan ="1">
                            &nbsp;</td>
                        <td colspan ="1"></td>
                        <td colspan ="1"></td>


                    </tr>
                    <tr>
                            <td colspan ="1">
                                <dx:ASPxLabel ID="ASPxLabel5" runat="server" Font-Names="Cambria" Font-Size="Small" Text="User ID" Theme="Glass">
                                </dx:ASPxLabel>
                            </td>
                        <td colspan ="1">
                            <dx:ASPxTextBox ID="ASPxTextBox4" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="250px">
                            </dx:ASPxTextBox>
                            </td>
                        <td colspan ="1">
                            &nbsp;</td>
                        <td colspan ="1">
                            &nbsp;</td>
                        <td colspan ="1"></td>
                        <td colspan ="1"></td>
                        <td colspan ="1"></td>
                        <td colspan ="1"></td>


                    </tr>
                    <tr>
                            <td colspan ="1">
                                &nbsp;</td>
                        <td colspan ="7" align="center">
                            <asp:RadioButton ID="RDactive" runat="server" AutoPostBack="True" GroupName="ActivationStatus" Text="Activate Account" />
                            <asp:RadioButton ID="RDactive0" runat="server" AutoPostBack="True" GroupName="ActivationStatus" Text="Deactivate Account" />
                            </td>
                        


                    </tr>
                    <tr>
                        <td colspan ="1"></td>
                        <td colspan ="7" align="center">
                            <dx:ASPxLabel ID="ASPxLabel20" runat="server" Font-Names="Cambria" Text="Account activity last updated on: " Theme="BlackGlass">
                            </dx:ASPxLabel>
                        </td>

                    </tr>
                    <tr>
                        <td colspan="1"></td>
                        <td colspan ="7">
                            &nbsp;</td>

                    </tr>
                 
        </table>
        </asp:Panel>
        

        
        <asp:Panel runat="server" ID="Panel8" Font-Names="Cambria" GroupingText="_" Font-Size="Medium">

                <table width="810px">
<tr>
        
    <td colspan ="8" align="center">
        
        <dx:ASPxButton ID="ASPxButton1" runat="server" Text="save" Theme="BlackGlass">
        </dx:ASPxButton>
        <dx:ASPxButton ID="ASPxButton3" runat="server" Text="reset account" Theme="Office2003Olive">
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

