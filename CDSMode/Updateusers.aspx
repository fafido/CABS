<%@ Page Language="VB" MasterPageFile="~/CDSUser.master" AutoEventWireup="false" CodeFile="updateusers.aspx.vb" Inherits="CDSMode_updateusers" title="Update Users" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<asp:Content id="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
    <asp:Panel id="Panel1" runat="server" Width="100%" Font-Names="Arial" Font-Size="Medium" BackColor="White">
    
        <table width ="100%">
            <tr>
                   <td style ="text-align :left;" align="left">
                       <dx:ASPxLabel ID="ASPxLabel1" runat="server" Text="Parameters&gt;&gt;Administrator Accounts Creation" Font-Names="Cambria" Font-Size="Small" Theme="PlasticBlue"></dx:ASPxLabel>

                   </td>
            </tr>
        </table>
<asp:Panel runat="server" ID="Companie" Font-Names="Cambria" GroupingText="Participant  Details" Width="100%">
    <table style="width:100%">
            <tr>
                <td colspan ="1">
                    <dx:ASPxLabel ID="ASPxLabel67" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Select Participant" Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                <td colspan ="1">
                    <asp:DropDownList ID="cmbParticipants" AppendDataBoundItems="true" runat="server" AutoPostBack="True" Width="250px">
                        <asp:ListItem Text="-Select-"></asp:ListItem>
                    </asp:DropDownList>
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
                    <dx:ASPxLabel ID="ASPxLabel68" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Participant Code" Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                <td colspan ="1">
                    <dx:ASPxTextBox ID="txtParticipant" runat="server" Theme="BlackGlass" Width="250px" ReadOnly="True">
                    </dx:ASPxTextBox>
                </td>
                <td colspan ="1">
                    <dx:ASPxLabel ID="ASPxLabel69" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Participant  Type" Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                <td colspan ="1">
                    <dx:ASPxTextBox ID="txtParticipantType" runat="server" Theme="BlackGlass" Width="250px" ReadOnly="True">
                    </dx:ASPxTextBox>
                </td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>
            </tr>
        <tr>
                <td colspan ="1"></td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>
            </tr>

    </table>
</asp:Panel>
        <asp:Panel ID="Panel10" runat="server" Font-Names="Cambria" GroupingText="User Accounts">
            <table width="100%">
                <tr>
                    <td align="center" style="width:165px">
                        &nbsp;</td>
                    <td>
                        <asp:GridView ID="grdjointaccounts" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" CssClass="tablestyle" DataKeyNames="id" Font-Size="Small" ForeColor="Black" GridLines="None" Style="position: relative; top: 0px; left: -1px; width: 82%; height: 3px;">
                            <PagerSettings FirstPageText="First" LastPageText="Last" NextPageText="Next" PreviousPageText="Previous" />
                            <AlternatingRowStyle CssClass="altrowstyle" />
                            <HeaderStyle BackColor="#023E5A" ForeColor="White" HorizontalAlign="Left" />
                            <RowStyle CssClass="rowstyle" />
                            <Columns>
                                <asp:BoundField DataField="ID" HeaderText="Account ID" />
                                <asp:BoundField DataField="User Account" HeaderText="User Account" />
                                <asp:BoundField DataField="names" HeaderText="Full Name" />
                                <asp:BoundField DataField="Mobile1" HeaderText="Mobile" />
                                <asp:BoundField DataField="Email" HeaderText="Email" />
                                <asp:CommandField EditText="Update " SelectText="Update" ShowSelectButton="true">
                                <ItemStyle Font-Bold="True" Font-Italic="True" ForeColor="Red" HorizontalAlign="Right" />
                                </asp:CommandField>
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
            </table>
        </asp:Panel>
        <asp:panel id="Panel8" runat="server" GroupingText="Personal Details" Font-Names="Cambria">
        <table width="100%">
            <tr>
                <td colspan ="1" style="width:165px">
                    <dx:ASPxLabel ID="ASPxLabel70" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Account ID" Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                <td colspan ="1">
                    <dx:ASPxTextBox ID="txtaccountid" runat="server" Theme="BlackGlass" Width="250px" ReadOnly="True">
                    </dx:ASPxTextBox>
                </td>
                <td colspan ="1">&nbsp;</td>
                <td colspan ="1">&nbsp;</td>
                <td colspan ="1">&nbsp;</td>
                <td colspan ="1">&nbsp;</td>
                <td colspan ="1">&nbsp;</td>
                <td colspan ="1">&nbsp;</td>
                

            </tr>
            <tr>
                <td colspan="1">
                    <dx:ASPxLabel ID="ASPxLabel25" runat="server" Font-Names="Cambria" Font-Size="Small" Text="User Name" Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                <td colspan="1">
                    <dx:ASPxTextBox ID="txtUsername" runat="server" Theme="BlackGlass" Width="250px">
                   <ValidationSettings SetFocusOnError="true">
                                <RequiredField IsRequired="True" />
                            </ValidationSettings>
                         </dx:ASPxTextBox>
                </td>
                <td colspan="1"></td>
                <td colspan="1"></td>
                <td colspan="1"></td>
                <td colspan="1"></td>
                <td colspan="1"></td>
                <td colspan="1"></td>
            </tr>
           <tr>
               <td colspan ="1">
                   <dx:ASPxLabel ID="ASPxLabel26" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Surname" Theme="Glass">
                   </dx:ASPxLabel>
               </td>
               <td colspan ="7">
                   <dx:ASPxTextBox ID="txtSurname" runat="server" Theme="BlackGlass" Width="710px">
                   </dx:ASPxTextBox>
               </td>

           </tr>
            <tr>
                    <td colspan ="1" style="height: 23px">
                        <dx:ASPxLabel ID="ASPxLabel27" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Forenames" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                <td colspan ="7" style="height: 23px">
                    <dx:ASPxTextBox ID="txtOthernames" runat="server" Theme="BlackGlass" Width="710px">
                    </dx:ASPxTextBox>
                    </td>

            </tr>
            <tr>
                    <td colspan ="1">
                        <dx:ASPxLabel ID="ASPxLabel30" runat="server" Font-Names="Cambria" Font-Size="Small" Text="CNIC No./ UIN No." Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                <td colspan ="1">
                    <dx:ASPxTextBox ID="txtIDno" runat="server" Theme="BlackGlass" Width="250px">
                        <MaskSettings ErrorText="Invalid CNIC" Mask="00000-0000000-0" />
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
                <td colspan ="1">
                    &nbsp;</td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>

            </tr>
           
        </table>

    </asp:panel>
    <asp:panel id="Panel3" runat="server" GroupingText="User Account Details" Font-Names="Cambria">
        <table width="100%">
      
           
            <tr>
                    <td colspan ="1" style="width:165px">
                        <table class="auto-style1">
                            <tr>
                                <td >
                                    <dx:ASPxLabel ID="ASPxLabel8" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Telephone" Theme="Glass">
                                    </dx:ASPxLabel>
                                </td>
                                <td align="Right">
                                    <dx:ASPxTextBox ID="txtcode1" runat="server" ReadOnly="True" Theme="BlackGlass" Width="40px">
                                    </dx:ASPxTextBox>
                                </td>
                            </tr>
                        </table>
                    </td>
                <td colspan ="1">
                    <dx:ASPxTextBox ID="txtTel" runat="server" Theme="BlackGlass" Width="250px">
                    </dx:ASPxTextBox>
                    </td>
                <td colspan ="1">
                    <table class="auto-style1">
                        <tr>
                            <td>
                                <dx:ASPxLabel ID="ASPxLabel9" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Mobile" Theme="Glass">
                                </dx:ASPxLabel>
                            </td>
                            <td align="right">
                                <dx:ASPxTextBox ID="txtcode2" runat="server" ReadOnly="True" Theme="BlackGlass" Width="40px">
                                </dx:ASPxTextBox>
                            </td>
                        </tr>
                    </table>
                    </td>
                <td colspan ="1">
                    <dx:ASPxTextBox ID="txtMobile" runat="server" Theme="BlackGlass" Width="250px">
                        <MaskSettings ErrorText="Invalid Mobile" Mask="0000000000" />
                    </dx:ASPxTextBox>
                    </td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>

            </tr>
            <tr>
                <td colspan ="1">
                    <dx:ASPxLabel ID="ASPxLabel10" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Email" Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                <td colspan ="1">
                    <dx:ASPxTextBox ID="txtEmail" runat="server" Theme="BlackGlass" Width="250px">
                         <ValidationSettings ErrorText="Invalid Email" SetFocusOnError="True">
                                <RegularExpression ErrorText="Invalid Email" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" />
                                <RequiredField IsRequired="True" />
                            </ValidationSettings>
                    </dx:ASPxTextBox>
                </td>
                <td colspan ="1">
                    <dx:ASPxLabel ID="ASPxLabel62" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Department" Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                <td colspan ="1">
                    <dx:ASPxTextBox ID="txtDepartment" runat="server" Theme="BlackGlass" Width="250px">
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
                    <asp:RadioButton ID="rdControlled0" runat="server" AutoPostBack="True" GroupName="AccType" Text="Admin" />
                    <asp:RadioButton ID="rdControlled1" runat="server" AutoPostBack="True" GroupName="AccType" Text="User" />
                 </td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>
            </tr>
           
            <tr>
                <td colspan="1">&nbsp;</td>
                <td colspan="1">&nbsp;</td>
                <td colspan="1">&nbsp;</td>
                <td colspan="1">&nbsp;</td>
                <td colspan="1">&nbsp;</td>
                <td colspan="1">&nbsp;</td>
                <td colspan="1">&nbsp;</td>
                <td colspan="1">&nbsp;</td>
            </tr>
           
        </table>
    </asp:panel>
        <asp:panel id="Panel2" runat="server" GroupingText="Admin Account Status" Font-Names="Cambria">
        <table width="100%">
      
           
           
            <tr>
               
                <td colspan ="8" align="center">
                    <dx:ASPxButton ID="ASPxButton1" runat="server" Text="Update" Theme="BlackGlass">
                    </dx:ASPxButton>
                    &nbsp;<dx:ASPxButton ID="ASPxButton2" runat="server" Text="Lock Account" Theme="BlackGlass">
                    </dx:ASPxButton>
                    &nbsp;<dx:ASPxButton ID="ASPxButton3" runat="server" Text="Reset Password" Theme="BlackGlass">
                    </dx:ASPxButton>
                </td>
                

            </tr>
           
          
        </table>
    </asp:panel>
    
</asp:Panel>
  
</div>
</asp:Content>

