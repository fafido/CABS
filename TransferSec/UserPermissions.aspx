<%@ Page Language="VB" MasterPageFile="~/CDSUser.master" AutoEventWireup="false" CodeFile="UserPermissions.aspx.vb" Inherits="TransferSec_UserPermissions" title="Account Details Enquiry" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<asp:Content id="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
    <asp:Panel id="Panel1" runat="server" Width="840px" Font-Names="Arial" Font-Size="Medium" BackColor="White">
    
        <table width ="810px">
            <tr>
                   <td style ="text-align :left;" align="left">
                       <dx:ASPxLabel ID="ASPxLabel1" runat="server" Text="Parameters&gt;&gt;User Permissions Management" Font-Names="Cambria" Font-Size="Small" Theme="PlasticBlue"></dx:ASPxLabel>

                   </td>
            </tr>
        </table>
        <asp:panel id="Panel2" runat="server" GroupingText="Users " Font-Names="Cambria">
        <table width="810px">
            <tr>
            
                <td colspan ="8" align="center">
                    <dx:ASPxListBox ID="lstUsersList" runat="server" Theme="BlackGlass" ValueType="System.String" Width="710px" AutoPostBack="True">
                    </dx:ASPxListBox>
                </td>

            </tr>

        </table>

    </asp:panel>
        <asp:panel id="Panel8" runat="server" GroupingText="Personal Details" Font-Names="Cambria">
        <table width="810px">
            <tr>
                <td colspan ="1">
                    <dx:ASPxLabel ID="ASPxLabel25" runat="server" Font-Names="Cambria" Font-Size="Small" Text="User Name" Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                <td colspan ="1">
                    <dx:ASPxTextBox ID="txtUsername" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="250px">
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
                   <dx:ASPxLabel ID="ASPxLabel26" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Surname" Theme="Glass">
                   </dx:ASPxLabel>
               </td>
               <td colspan ="7">
                   <dx:ASPxTextBox ID="txtSurname" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="710px">
                   </dx:ASPxTextBox>
               </td>

           </tr>
            <tr>
                    <td colspan ="1">
                        <dx:ASPxLabel ID="ASPxLabel27" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Other Names" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                <td colspan ="7">
                    <dx:ASPxTextBox ID="txtForenames" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="710px">
                    </dx:ASPxTextBox>
                    </td>

            </tr>
            <tr>
                    <td colspan ="1">
                        <dx:ASPxLabel ID="ASPxLabel28" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Initials" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                <td colspan ="1">
                    <dx:ASPxTextBox ID="txtInitials" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="250px">
                    </dx:ASPxTextBox>
                    </td>
                <td colspan ="1">
                    <dx:ASPxLabel ID="ASPxLabel30" runat="server" Font-Names="Cambria" Font-Size="Small" Text="ID No./Pin" Theme="Glass">
                    </dx:ASPxLabel>
                    </td>
                <td colspan ="1">
                    <dx:ASPxTextBox ID="txtIDNo" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="250px">
                    </dx:ASPxTextBox>
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
                        <dx:ASPxLabel ID="ASPxLabel33" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Gender" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                <td colspan ="1">
                    <asp:RadioButton ID="rdMale" runat="server" AutoPostBack="True" GroupName="Gender" Text="Male" />
                    <asp:RadioButton ID="rdFemale" runat="server" AutoPostBack="True" GroupName="Gender" Text="Female" />
                    <asp:RadioButton ID="rdNa" runat="server" AutoPostBack="True" GroupName="Gender" Text="N/A" />
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
                    <dx:ASPxLabel ID="ASPxLabel65" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Account Type" Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                <td colspan ="1">
                    <asp:RadioButton ID="rdAccPermanent" runat="server" AutoPostBack="True" GroupName="AccTenure" Text="Permanent" />
                    <asp:RadioButton ID="rdAccPermanent0" runat="server" AutoPostBack="True" GroupName="AccTenure" Text="Temporary" />
                </td>
                <td colspan ="1">
                    &nbsp;</td>
                <td colspan ="1">
                    <asp:RadioButton ID="rdControlled0" runat="server" AutoPostBack="True" GroupName="AccType" Text="Admin" />
                    <asp:RadioButton ID="rdControlled1" runat="server" AutoPostBack="True" GroupName="AccType" Text="User" />
                </td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>

            </tr>
            <tr>
                <td colspan ="1">
                    <dx:ASPxLabel ID="ASPxLabel63" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Role" Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                <td colspan ="1">
                    <dx:ASPxTextBox ID="txtRole" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="250px">
                    </dx:ASPxTextBox>
                </td>
                <td colspan ="1">
                    <dx:ASPxLabel ID="ASPxLabel62" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Department" Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                <td colspan ="1">
                    <dx:ASPxTextBox ID="txtDepartment" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="250px">
                    </dx:ASPxTextBox>
                </td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>
            </tr>
            <tr>
                    <td colspan ="1"></td>
                <td colspan ="7" align="center"></td>

            </tr>

        </table>

    </asp:panel>
        <asp:panel id="Panel11" runat="server" GroupingText="Permissions" Font-Names="Cambria">
        <table width="810px">
            <tr>
                    <td colspan ="3" align="center">
                        <dx:ASPxLabel ID="ASPxLabel66" runat="server" Font-Names="Cambria" Font-Size="Small" Text="System Permissions" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                <td colspan ="2" align="center"></td>
                <td colspan ="3" align="center">
                        <dx:ASPxLabel ID="ASPxLabel67" runat="server" Font-Names="Cambria" Font-Size="Small" Text="User Permissions" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>

            </tr>
            <tr>
                    <td colspan ="3" align="center">
                        <dx:ASPxListBox ID="lstSystemPermissions" runat="server" Height="175px" Theme="iOS" ValueType="System.String" Width="250px">
                        </dx:ASPxListBox>
                    </td>
                <td colspan ="2" align="center">
                    <dx:ASPxButton ID="ASPxButton2" runat="server" Text="&lt;&lt;" Theme="BlackGlass" Width="45px">
                    </dx:ASPxButton>
                    <dx:ASPxButton ID="ASPxButton3" runat="server" Text="&lt;" Theme="BlackGlass" Width="45px">
                    </dx:ASPxButton>
                    <dx:ASPxButton ID="ASPxButton5" runat="server" Text="&gt;" Theme="BlackGlass" Width="45px">
                    </dx:ASPxButton>
                    <dx:ASPxButton ID="ASPxButton4" runat="server" Text="&gt;&gt;" Theme="BlackGlass" Width="45px">
                    </dx:ASPxButton>
                    </td>
                <td colspan ="3" align="center">
                        <dx:ASPxListBox ID="lstUserPermissions" runat="server" Height="175px" Theme="iOS" ValueType="System.String" Width="250px">
                        </dx:ASPxListBox>
                    </td>

            </tr>
         
           <tr>
               <td colspan ="1">
                   &nbsp;</td>
               <td colspan ="7">
                   &nbsp;</td>

           </tr>
             <tr>
               <td colspan ="8" align="center">
                   <dx:ASPxButton ID="ASPxButton1" runat="server" Text="save" Theme="BlackGlass"></dx:ASPxButton>
                   &nbsp;</td>


           </tr>
               
        </table>

    </asp:panel>
        <asp:panel id="Panel10" runat="server" GroupingText="User Accounts" Font-Names="Cambria">
        <table width="810px">
            <tr>
                    <td colspan ="8" align ="center">
                        <dx:ASPxGridView ID="grdJointAccounts" runat="server" Theme="Aqua" Width="600px" Visible="False">
                        </dx:ASPxGridView>
                    </td>

            </tr>
        </table>

    </asp:panel>
                 
</asp:Panel>
  
</div>
</asp:Content>

