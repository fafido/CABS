<%@ Page Language="VB" MasterPageFile="~/CDSUser.master" AutoEventWireup="false" CodeFile="UserAccountsApproval.aspx.vb" Inherits="CDSMode_UserAccountsApproval" title="User Approval" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<asp:Content id="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
    <asp:Panel id="Panel1" runat="server" Width="100%" Font-Names="Arial" Font-Size="Medium" BackColor="White">
    
        <table width ="100%">
            <tr>
                   <td style ="text-align :left;" align="left">
                       <dx:ASPxLabel ID="ASPxLabel1" runat="server" Text="Parameters&gt;&gt;Approve Users" Font-Names="Cambria" Font-Size="Small" Theme="PlasticBlue"></dx:ASPxLabel>

                   </td>
            </tr>
        </table>
<asp:Panel runat="server" ID="Panel8" Font-Names="Cambria" GroupingText="Participant Users">
    <table width="100%">
            <tr>
                <td colspan ="8">
                    <asp:Panel ID="Panel12" runat="server" Font-Names="Cambria" GroupingText="Pending Accounts">
                        <table width="100%">
                            <tr>
                                <td align="center" colspan="8">
                                    <dx:ASPxGridView ID="grdJointAccounts0" runat="server" AutoGenerateColumns="false" KeyFieldName="id" SettingsBehavior-AllowSort="true" Theme="Aqua" Width="100%">
                                        <Columns>
                                             <dx:GridViewDataColumn Caption="Update Type">
                                                <DataItemTemplate>
                                                    <dx:ASPxLabel runat="server" Text='<%# Eval("UpdateType") %>'>
                                                    </dx:ASPxLabel>
                                                </DataItemTemplate>
                                            </dx:GridViewDataColumn>
                                            <dx:GridViewDataColumn Caption="" VisibleIndex="0">
                                                <DataItemTemplate>
                                                    <asp:LinkButton ID="SelectID0" runat="server" CommandArgument='<%# Eval("ID") %>' CommandName="Edit" Text="View Details">
                                                              </asp:LinkButton>
                                                </DataItemTemplate>
                                            </dx:GridViewDataColumn>
                                            <dx:GridViewDataColumn Caption="ID">
                                                <DataItemTemplate>
                                                    <dx:ASPxLabel runat="server" Text='<%# Eval("id") %>'>
                                                    </dx:ASPxLabel>
                                                </DataItemTemplate>
                                            </dx:GridViewDataColumn>
                                            <dx:GridViewDataColumn Caption="Names">
                                                <DataItemTemplate>
                                                    <dx:ASPxLabel runat="server" Text='<%# Eval("Names") %>'>
                                                    </dx:ASPxLabel>
                                                </DataItemTemplate>
                                            </dx:GridViewDataColumn>
                                            <dx:GridViewDataColumn Caption="Username">
                                                <DataItemTemplate>
                                                    <dx:ASPxLabel runat="server" Text='<%# Eval("userName") %>'>
                                                    </dx:ASPxLabel>
                                                </DataItemTemplate>
                                            </dx:GridViewDataColumn>
                                            <dx:GridViewDataColumn Caption="Gender">
                                                <DataItemTemplate>
                                                    <dx:ASPxLabel runat="server" Text='<%# Eval("gender") %>'>
                                                    </dx:ASPxLabel>
                                                </DataItemTemplate>
                                            </dx:GridViewDataColumn>
                                            <dx:GridViewDataColumn Caption="Department">
                                                <DataItemTemplate>
                                                    <dx:ASPxLabel runat="server" Text='<%# Eval("Department") %>'>
                                                    </dx:ASPxLabel>
                                                </DataItemTemplate>
                                            </dx:GridViewDataColumn>
                                            <dx:GridViewDataColumn Caption="Account Type">
                                                <DataItemTemplate>
                                                    <dx:ASPxLabel runat="server" Text='<%# Eval("AccountType") %>'>
                                                    </dx:ASPxLabel>
                                                </DataItemTemplate>
                                            </dx:GridViewDataColumn>
                                            <dx:GridViewDataColumn Caption="Account Status">
                                                <DataItemTemplate>
                                                    <dx:ASPxLabel runat="server" Text='<%# Eval("Activation") %>'>
                                                    </dx:ASPxLabel>
                                                </DataItemTemplate>
                                            </dx:GridViewDataColumn>
                                            <dx:GridViewDataColumn Caption="Email">
                                                <DataItemTemplate>
                                                    <dx:ASPxLabel runat="server" Text='<%# Eval("email") %>'>
                                                    </dx:ASPxLabel>
                                                </DataItemTemplate>
                                            </dx:GridViewDataColumn>
                                            <dx:GridViewDataColumn Caption="Mobile">
                                                <DataItemTemplate>
                                                    <dx:ASPxLabel runat="server" Text='<%# Eval("Mobile1") %>'>
                                                    </dx:ASPxLabel>
                                                </DataItemTemplate>
                                            </dx:GridViewDataColumn>
                                           
                                        </Columns>
                                    </dx:ASPxGridView>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                </td>
            </tr>
        <tr>
                <td colspan ="1" style="width:150px">
                    <dx:ASPxLabel ID="ASPxLabel67" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Participant" Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                <td colspan ="1" style="width: 150px">
                    <dx:ASPxTextBox ID="cmbparticipants" runat="server" ReadOnly="True" Theme="BlackGlass" Width="250px">
                        <ValidationSettings SetFocusOnError="true">
                            <RequiredField IsRequired="True" />
                        </ValidationSettings>
                    </dx:ASPxTextBox>
                    <td colspan="1" style="width:50px">
                        <dx:ASPxLabel ID="ASPxLabel68" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Participant Code" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td colspan="1">
                        <dx:ASPxTextBox ID="txtParticipant" runat="server" ReadOnly="True" Theme="BlackGlass" Width="250px">
                            <ValidationSettings SetFocusOnError="true">
                                <RequiredField IsRequired="True" />
                            </ValidationSettings>
                        </dx:ASPxTextBox>
                    </td>
                    <td colspan="1">
                        <dx:ASPxLabel ID="ASPxLabel69" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Participant  Type" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td colspan="1">
                        <dx:ASPxTextBox ID="txtParticipantType" runat="server" ReadOnly="True" Theme="BlackGlass" Width="250px">
                            <ValidationSettings SetFocusOnError="true">
                                <RequiredField IsRequired="True" />
                            </ValidationSettings>
                        </dx:ASPxTextBox>
                    </td>
                    <td colspan="1">&nbsp;</td>
                    <td colspan="1">&nbsp;</td>
                </td>
            </tr>
        <tr>
                <td colspan ="1" style="width:150px; height: 27px;"></td>
                <td colspan ="1" style="width:150px; height: 27px;"><td colspan="1" style="height: 27px"></td>
                    <td colspan="1" style="height: 27px"></td>
                    <td colspan="1" style="height: 27px"></td>
                    <td colspan="1" style="height: 27px"></td>
                    <td colspan="1" style="height: 27px"></td>
                    <td colspan="1" style="height: 27px"></td>
                </td>
            </tr>

            <tr>
                <td colspan="8">User Account Details
                    <hr />
                </td>
                <td></td>
            </tr>
            <tr>
                <td colspan="1" style="width:150px">
                    <dx:ASPxLabel ID="ASPxLabel25" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Username" Theme="Glass">
                    </dx:ASPxLabel>
                    <dx:ASPxLabel ID="ASPxLabel61" runat="server" ForeColor="Red" Text="*">
                    </dx:ASPxLabel>
                </td>
                <td colspan="1" style="width:150px">
                    <dx:ASPxTextBox ID="txtUsername" runat="server" ReadOnly="true" Theme="BlackGlass" Width="250px">
                        <ValidationSettings SetFocusOnError="true">
                            <RequiredField IsRequired="True" />
                        </ValidationSettings>
                    </dx:ASPxTextBox>
                    </t>
                    <td colspan="1">
                        <dx:ASPxLabel ID="ASPxLabel30" runat="server" Font-Names="Cambria" Font-Size="Small" Text="ID No." Theme="Glass">
                        </dx:ASPxLabel>
                        <dx:ASPxLabel ID="ASPxLabel71" runat="server" ForeColor="Red" Text="*">
                        </dx:ASPxLabel>
                    </td>
                    <td colspan="1">
                        <dx:ASPxTextBox ID="txtIDno" runat="server" ReadOnly="true" Theme="BlackGlass" Width="250px">
                            <MaskSettings ErrorText="Invalid CNIC" Mask="00-0000000-A-00" />
                        </dx:ASPxTextBox>
                    </td>
                    <td colspan="1">
                        <dx:ASPxLabel ID="ASPxLabel26" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Surname" Theme="Glass">
                        </dx:ASPxLabel>
                        <dx:ASPxLabel ID="ASPxLabel56" runat="server" ForeColor="Red" Text="*">
                        </dx:ASPxLabel>
                    </td>
                    <td colspan="1">
                        <dx:ASPxTextBox ID="txtSurname" runat="server" ReadOnly="true" Theme="BlackGlass" Width="250px">
                            <ValidationSettings SetFocusOnError="true">
                                <RequiredField IsRequired="True" />
                            </ValidationSettings>
                        </dx:ASPxTextBox>
                    </td>
                    <td colspan="1"></td>
                    <td colspan="1"></td>
                </td>
            </tr>
            <tr>
                <td colspan="1" style="width:150px">
                    <dx:ASPxLabel ID="ASPxLabel27" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Forenames" Theme="Glass">
                    </dx:ASPxLabel>
                    <dx:ASPxLabel ID="ASPxLabel57" runat="server" ForeColor="Red" Text="*">
                    </dx:ASPxLabel>
                </td>
                <td colspan="1" style="width:150px">
                    <dx:ASPxTextBox ID="txtOthernames" runat="server" ReadOnly="true" Theme="BlackGlass" Width="250px">
                        <ValidationSettings SetFocusOnError="true">
                            <RequiredField IsRequired="True" />
                        </ValidationSettings>
                    </dx:ASPxTextBox>
                    <td colspan="1">
                        <dx:ASPxLabel ID="ASPxLabel62" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Department" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td colspan="1">
                        <dx:ASPxTextBox ID="txtDepartment" runat="server" ReadOnly="true"  Theme="BlackGlass" Width="250px">
                        </dx:ASPxTextBox>
                    </td>
                    <td colspan="1">
                        <dx:ASPxLabel ID="ASPxLabel33" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Gender" Theme="Glass">
                        </dx:ASPxLabel>
                        <dx:ASPxLabel ID="ASPxLabel72" runat="server" ForeColor="Red" Text="*">
                        </dx:ASPxLabel>
                    </td>
                    <td colspan="1">
                        <asp:RadioButton ID="rdMale" runat="server" GroupName="Gender" Enabled="false" Text="Male" />
                        <asp:RadioButton ID="rdFemale" runat="server" GroupName="Gender" Enabled="false"  Text="Female" />
                        <asp:RadioButton ID="rdNa" runat="server" GroupName="Gender" Enabled="false"  Text="N/A" />
                    </td>
                    <td colspan="1">&nbsp;</td>
                    <td colspan="1">&nbsp;</td>
                </td>
            </tr>
            <tr>
                <td colspan="1" style="width:150px">
                    <dx:ASPxLabel ID="ASPxLabel10" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Email" Theme="Glass">
                    </dx:ASPxLabel>
                    <dx:ASPxLabel ID="ASPxLabel70" runat="server" ForeColor="Red" Text="*">
                    </dx:ASPxLabel>
                </td>
                <td colspan="1" style="width:150px">
                    <dx:ASPxTextBox ID="txtEmail" runat="server" Theme="BlackGlass" ReadOnly="true" Width="250px">
                        <ValidationSettings ErrorText="Invalid Email" SetFocusOnError="True">
                            <RegularExpression ErrorText="Invalid Email" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" />
                            <RequiredField IsRequired="True" />
                        </ValidationSettings>
                    </dx:ASPxTextBox>
                    <td colspan="1">
                        <dx:ASPxLabel ID="ASPxLabel76" runat="server" Font-Names="Cambria" Font-Size="Small" Text="User Type" Theme="Glass">
                        </dx:ASPxLabel>
                        <dx:ASPxLabel ID="ASPxLabel77" runat="server" ForeColor="Red" Text="*">
                        </dx:ASPxLabel>
                    </td>
                    <td colspan="1">
                        <asp:RadioButton ID="rdControlled0" runat="server" Enabled="false" AutoPostBack="True" GroupName="AccType" Text="Admin"  />
                        <asp:RadioButton ID="rdControlled1" runat="server" Enabled="false"  AutoPostBack="True" GroupName="AccType" Text="User" />
                    </td>
                    <td colspan="1">
                        <table class="dxflInternalEditorTable_Aqua">
                            <tr>
                                <td>
                                    <dx:ASPxLabel ID="ASPxLabel9" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Mobile" Theme="Glass">
                                    </dx:ASPxLabel>
                                    <dx:ASPxLabel ID="ASPxLabel73" runat="server" ForeColor="Red" Text="*">
                                    </dx:ASPxLabel>
                                </td>
                                <td align="right">
                                    <dx:ASPxTextBox ID="txtcode2" runat="server" ReadOnly="True" Theme="BlackGlass" Width="40px">
                                    </dx:ASPxTextBox>
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td colspan="1">
                        <dx:ASPxTextBox ID="txtMobile" runat="server" ReadOnly="true" Theme="BlackGlass" Width="250px">
                            <MaskSettings ErrorText="10 digits expected" Mask="0000000000" />
                        </dx:ASPxTextBox>
                    </td>
                    <td colspan="1">&nbsp;</td>
                    <td colspan="1">&nbsp;</td>
                </td>
            </tr>
            <tr>
                <td colspan="1" style="width:150px">
                    <table class="dxflInternalEditorTable_Aqua">
                        <tr>
                            <td>
                                <dx:ASPxLabel ID="ASPxLabel74" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Telephone" Theme="Glass">
                                </dx:ASPxLabel>
                            </td>
                            <td align="right">
                                <dx:ASPxTextBox ID="txtcode3" runat="server" ReadOnly="True" Theme="BlackGlass" Width="40px">
                                </dx:ASPxTextBox>
                            </td>
                        </tr>
                    </table>
                </td>
                <td colspan="1" style="width:150px">
                    <dx:ASPxTextBox ID="txtTel" runat="server" ReadOnly="true" Theme="BlackGlass" Width="250px">
                        <%--  <MaskSettings ErrorText="10 digits expected" Mask="0000000000" />--%>
                    </dx:ASPxTextBox>
                    <td colspan="1">
                        <dx:ASPxLabel ID="ASPxLabel78" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Request ID" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td colspan="1">
                        <dx:ASPxTextBox ID="TXTID" runat="server" ReadOnly="true" Theme="BlackGlass" Width="250px">
                        </dx:ASPxTextBox>
                    </td>
                    <td colspan="1">
                        <dx:ASPxLabel ID="ASPxLabel63" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Role" Theme="Glass" Visible="False">
                        </dx:ASPxLabel>
                    </td>
                    <td colspan="1">
                        <dx:ASPxTextBox ID="txtRole" runat="server" ReadOnly="true" Theme="BlackGlass" Visible="False" Width="250px">
                        </dx:ASPxTextBox>
                    </td>
                    <td colspan="1">&nbsp;</td>
                    <td colspan="1">&nbsp;</td>
                </td>
            </tr>

    </table>
</asp:Panel>
    <asp:panel id="Panel3" runat="server" GroupingText="User Account Details" Font-Names="Cambria" Visible="False">
        <table >
      
           
            <tr>
                    <td style="width:150px" >
                        &nbsp;</td>
                <td colspan ="1">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                    <td align="right">
                        &nbsp;</td>
                <td colspan ="1">
                    &nbsp;</td>

            </tr>
            <tr>
                <td style="width:150px">
                    &nbsp;</td>
                <td colspan ="1">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td align="right">
                    &nbsp;</td>
                <td colspan ="1">
                    &nbsp;</td>
            </tr>
             <tr>
                <td >
                    &nbsp;</td>
                <td colspan ="1">
                    &nbsp;</td>
                <td colspan ="2">
                    &nbsp;</td>
                <td colspan ="1">
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    <dx:ASPxLabel ID="ASPxLabel65" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Account Type" Theme="Glass" Visible="False">
                    </dx:ASPxLabel>
                </td>
                <td colspan ="1" style="height: 88px">
                    <asp:RadioButton ID="rdAccPermanent" runat="server" AutoPostBack="True" GroupName="AccTenure" Text="Permanent" Visible="False" />
                    <asp:RadioButton ID="rdAccPermanent0" runat="server" AutoPostBack="True" GroupName="AccTenure" Text="Temporary" Visible="False" />
                </td>
                <td colspan ="2" style="height: 88px">
                    <dx:ASPxLabel ID="ASPxLabel66" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Expiry Date(temporary)" Theme="Glass" Visible="False">
                    </dx:ASPxLabel>
                </td>
                <td colspan ="1" style="height: 88px">
                    <dx:ASPxDateEdit ID="txtExpiryDate" runat="server" Theme="BlackGlass" Visible="False">
                    </dx:ASPxDateEdit>
                </td>

            </tr>
           
        </table>
    </asp:panel>
        <asp:panel id="Panel2" runat="server" GroupingText="Options" Font-Names="Cambria">
        <table width="100%">
      
           
           
            <tr>
               
                <td colspan ="8" align="center">
                    <asp:RadioButton ID="rdunLocked" runat="server" AutoPostBack="True" GroupName="AccLockStatus" Text="Unlocked" Checked="True" Visible="False" />
                    <asp:RadioButton ID="rdLockedd" runat="server" AutoPostBack="True" GroupName="AccLockStatus" Text="Locked" Visible="False" />
                    <br />
                    <dx:ASPxButton ID="ASPxButton1" runat="server" Text="Save" Theme="BlackGlass">
                    </dx:ASPxButton>
                    &nbsp;<dx:ASPxButton ID="ASPxButton2" runat="server" CausesValidation="False" Text="Reject" Theme="BlackGlass">
                    </dx:ASPxButton>
                    <br />
                    <asp:TextBox ID="txtreason" runat="server" Height="78px" TextMode="MultiLine" Visible="False" Width="273px"></asp:TextBox>
                </td>
                

            </tr>
           
          
        </table>
    </asp:panel>
    
        <asp:panel id="Panel11" runat="server" GroupingText="." Font-Names="Cambria" Visible="False">
        <table width="810px">
            <tr>
                    <td colspan ="8" align="center">
                        <asp:RadioButton ID="rdNew" runat="server" AutoPostBack="True" GroupName="SaveOptions" Text="Save New" Checked="True" Visible="False" />
                        <asp:RadioButton ID="rdSave" runat="server" AutoPostBack="True" GroupName="SaveOptions" Text="Save/Update" Visible="False" />
                        <asp:RadioButton ID="rdReset" runat="server" AutoPostBack="True" GroupName="SaveOptions" Text="Reset Password" Visible="False" />
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
                   &nbsp;</td>


           </tr>
               
        </table>

    </asp:panel>
                 
        <br />
        <br />
                 
</asp:Panel>
  
</div>
</asp:Content>

