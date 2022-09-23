<%@ Page Language="VB" MasterPageFile="~/CDSUser.master" AutoEventWireup="false" CodeFile="AccountsVerification.aspx.vb" Inherits="CDSMode_AccountsVerification" title="Account Details Enquiry" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<asp:Content id="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
    <asp:Panel id="Panel1" runat="server" Width="840px" Font-Names="Arial" Font-Size="Medium" BackColor="White">
    
        <table width ="810px">
            <tr>
                   <td style ="text-align :left;" align="left">
                       <dx:ASPxLabel ID="ASPxLabel1" runat="server" Text="Authorizations&gt;&gt;Accounts Authorizations" Font-Names="Cambria" Font-Size="Small" Theme="PlasticBlue"></dx:ASPxLabel>

                   </td>
            </tr>
        </table>
        <asp:Panel runat="server" ID="Search" Font-Names="Cambria" GroupingText="Pending Verication Accounts">
            <table>
                    <tr>
                            <td colspan ="1">
                                <dx:ASPxLabel ID="ASPxLabel56" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Select Account" Theme="Glass">
                                </dx:ASPxLabel>
                            </td>
                        <td colspan ="7">
                            <dx:ASPxComboBox ID="cmbPendingAccounts" runat="server" Theme="BlackGlass" ValueType="System.String" Width="710px" AutoPostBack="True">
                            </dx:ASPxComboBox>
                            </td>

                    </tr>

                <tr>
                            <td colspan ="1">
                                <dx:ASPxLabel ID="ASPxLabel57" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Update Type" Theme="Glass">
                                </dx:ASPxLabel>
                            </td>
                        <td colspan ="7">
                            <dx:ASPxLabel ID="lblUpdateType" runat="server">
                            </dx:ASPxLabel>
                            </td>

                    </tr>
                <tr>
                        <td colspan ="1"></td>
                    <td colspan ="7" align="center">
                        <dx:ASPxLabel ID="ASPxLabel59" runat="server" Font-Italic="True" Font-Size="X-Small" ForeColor="Red" Text="*NB Highlighted fields indicate the updated sections on an account amendment" Theme="Office2003Blue">
                        </dx:ASPxLabel>
                        </td>

                </tr>

            </table>

        </asp:Panel>
        <asp:panel id="Panel10" runat="server" GroupingText="Account Type" Font-Names="Cambria">
        <table width="810px">
            <tr>
                    <td colspan ="8" align="center">
                        <asp:RadioButton ID="rdIndividual" enabled="false" runat="server" AutoPostBack="True" GroupName="AccountType" Text="Individual" />
                        <asp:RadioButton ID="rdJoint" enabled="false" runat="server" AutoPostBack="True" GroupName="AccountType" Text="Joint" />
                        <asp:RadioButton ID="rdJoint0" visible="false" enabled="false" runat="server" AutoPostBack="True" GroupName="Nominee" Text="Nominee" />
                        <asp:RadioButton ID="rdCorprate" enabled="false" runat="server" AutoPostBack="True" GroupName="AccountType" Text="Corporate" />
                        <asp:RadioButton ID="rdBroker" visible="false" enabled="false" runat="server" AutoPostBack="True" GroupName="AccountType" Text="Broker" />
                    </td>

            </tr>
         
           <tr>
               <td colspan ="1">
                   <dx:ASPxLabel ID="lblJSurname" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Surname" Theme="Glass" Visible="False">
                   </dx:ASPxLabel>
               </td>
               <td colspan ="7">
                   <dx:ASPxTextBox ReadOnly="True" ID="txtJsurname" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="710px" Visible="False">
                   </dx:ASPxTextBox>
                   <dx:ASPxLabel ID="lbljsur" runat="server">
                   </dx:ASPxLabel>
               </td>

           </tr>
             <tr>
               <td colspan ="1">
                   <dx:ASPxLabel ID="lblJforenames" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Forenames" Theme="Glass" Visible="False">
                   </dx:ASPxLabel>
                 </td>
               <td colspan ="7">
                   <dx:ASPxTextBox ReadOnly="True" ID="txtJforenames" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="710px" Visible="False">
                   </dx:ASPxTextBox>
               </td>

           </tr>
        
            <tr>
                    <td colspan ="1"></td>
                <td colspan ="7" align="center">
                    <dx:ASPxButton ID="btnJadd" runat="server" Text="Add" Theme="BlackGlass" Visible="False">
                    </dx:ASPxButton>
                    </td>

            </tr>
            <tr>
                <td colspan ="1">
                   <dx:ASPxLabel ID="ASPxLabel41" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Authorised Persons" Theme="Glass" Visible="False">
                   </dx:ASPxLabel>
                 </td>
                    <td colspan ="8" align ="center">
                        <dx:ASPxGridView ID="grdJointAccounts" runat="server" Theme="Aqua" Width="600px" Visible="False">
                        </dx:ASPxGridView>
                    </td>

            </tr>
        </table>

    </asp:panel>
         <asp:panel id="Panel8" runat="server" GroupingText="Personal Details" Font-Names="Cambria">
        <table width="810px">
            <tr>
                <td colspan ="1">
                    <dx:ASPxLabel ID="ASPxLabel25" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Pin No." Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                <td colspan ="1">
                    <dx:ASPxTextBox ReadOnly="True" ID="TXTClientID" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="250px">
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
                   <dx:ASPxTextBox ReadOnly="True" ID="txtSurname" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="710px">
                   </dx:ASPxTextBox>
               </td>

           </tr>
             <tr>
                <td colspan ="1"></td>
                <td colspan ="7">
                    <dx:ASPxLabel ID="lblSurname" runat="server">
                    </dx:ASPxLabel>
                </td>

            </tr>
             <tr>
                    <td colspan ="1">
                        <dx:ASPxLabel ID="ASPxLabel5" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Firstname" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                <td colspan ="7">
                    <dx:ASPxTextBox ReadOnly="True" ID="txtOtherNames" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="710px">
                    </dx:ASPxTextBox>
                    </td>

            </tr>
            <tr>
                    <td colspan="1">
                        <dx:ASPxLabel ID="ASPxLabel36" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Designation" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td colspan="7">
                        <dx:ASPxTextBox ID="txtdesignation" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="710px">
                        </dx:ASPxTextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="1">
                        <dx:ASPxLabel ID="ASPxLabel274" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Father/Husband" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td colspan="7">
                        <dx:ASPxTextBox ID="txtHusband" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="710px">
                        </dx:ASPxTextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="1">
                        <dx:ASPxLabel ID="ASPxLabel714" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Source of Income" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td colspan="7">
                        <dx:ASPxTextBox ID="txtsourceofIncome" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="710px">
                        </dx:ASPxTextBox>
                    </td>
                </tr>
            <tr>
                    <td colspan="1">
                        <dx:ASPxLabel ID="ASPxLabel40" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Occupation" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td colspan="7">
                        <dx:ASPxTextBox ID="txtOccupation" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="710px">
                        </dx:ASPxTextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="1">
                        <dx:ASPxLabel ID="ASPxLabel7114" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Gross Income" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td colspan="7">
                        <dx:ASPxTextBox ID="txtgrossincome" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="710px">
                        </dx:ASPxTextBox>
                    </td>
                </tr>
            <tr>
                    <td colspan ="1"></td>
                <td colspan ="7">
                    <dx:ASPxLabel ID="lblForenames" runat="server">
                    </dx:ASPxLabel>
                    </td>

            </tr>
            <tr>
                    <td colspan ="1">
                        <dx:ASPxLabel ID="ASPxLabel27" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Other Names" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                <td colspan ="7">
                    <dx:ASPxTextBox ReadOnly="True" ID="txtMiddlename" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="710px">
                    </dx:ASPxTextBox>
                    </td>

            </tr>
                 <tr>
                <td colspan ="1"></td>
                <td colspan ="7">
                    <dx:ASPxLabel ID="lblMiddlename" runat="server">
                    </dx:ASPxLabel>
                 </td>

            </tr>
            <tr>
                    <td colspan ="1">
                        <dx:ASPxLabel ID="ASPxLabel29" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Title" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                <td colspan ="1">
                    <dx:ASPxTextBox ReadOnly="True" ID="txtTitle" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="250px">
                    </dx:ASPxTextBox>
                    </td>
                <td colspan ="1">
                    <dx:ASPxLabel ID="ASPxLabel28" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Initials" Theme="Glass" Visible="False">
                    </dx:ASPxLabel>
                    </td>
                <td colspan ="1">
                    <dx:ASPxTextBox ReadOnly="True" ID="txtInitials" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Visible="False" Width="250px">
                    </dx:ASPxTextBox>
                    </td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>

            </tr>
              <tr>
                <td colspan ="1"></td>
                <td colspan ="1">
                    <dx:ASPxLabel ID="lblTitle" runat="server">
                    </dx:ASPxLabel>
                </td>
                <td colspan ="1"></td>
                <td colspan ="1">
                    <dx:ASPxLabel ID="lblInitials" runat="server" Visible="False">
                    </dx:ASPxLabel>
                </td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>
            </tr>
            <tr>
                <td colspan ="1">
                    <dx:ASPxLabel ID="ASPxLabel30" runat="server" Font-Names="Cambria" Font-Size="Small" Text="ID No" Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                <td colspan ="1">
                    <dx:ASPxTextBox ReadOnly="True" ID="txtIDNo" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="250px">
                    </dx:ASPxTextBox>
                </td>
                <td colspan ="1">
                    <dx:ASPxLabel ID="ASPxLabel31" runat="server" Font-Names="Cambria" Font-Size="Small" Text="ID Type" Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                <td colspan ="1">
                    <dx:ASPxTextBox ReadOnly="True" ID="txtIDType" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="250px">
                    </dx:ASPxTextBox>
                </td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>

            </tr>
             <tr>
                <td colspan ="1"></td>
                <td colspan ="1">
                    <dx:ASPxLabel ID="lblIdNo" runat="server">
                    </dx:ASPxLabel>
                </td>
                <td colspan ="1"></td>
                <td colspan ="1">
                    <dx:ASPxLabel ID="lblIdtype" runat="server">
                    </dx:ASPxLabel>
                </td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>
            </tr>
            <tr>
                    <td colspan ="1">
                        <dx:ASPxLabel ID="ASPxLabel44" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Nationality" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                <td colspan ="1">
                    <dx:ASPxTextBox ReadOnly="True" ID="txtNationality" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="250px">
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
                <td colspan ="1"></td>
                <td colspan ="1">
                    <dx:ASPxLabel ID="lblNationality" runat="server">
                    </dx:ASPxLabel>
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
                    <dx:ASPxLabel ID="ASPxLabel32" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Date Of Birth" Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                <td colspan ="1">
                    <dx:ASPxTextBox ReadOnly="True" ID="txtDOB" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="250px">
                    </dx:ASPxTextBox>
                </td>
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

            </tr>
             <tr>
                <td colspan ="1"></td>
                <td colspan ="1">
                    <dx:ASPxLabel ID="lblDob" runat="server">
                    </dx:ASPxLabel>
                </td>
                <td colspan ="1"></td>
                <td colspan ="1">
                    <dx:ASPxLabel ID="lblgender" runat="server">
                    </dx:ASPxLabel>
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
            <tr>
                    <td colspan ="1"></td>
                <td colspan ="7" align="center"></td>

            </tr>

        </table>

    </asp:panel>
        
        
        <asp:Panel ID="Panel5" runat="server" Font-Bold="True" Font-Names="Cambria" Font-Size="10pt" GroupingText="Empowerment Segment Declarations" Width="785px" Visible="False">
                       <table style="width: 820px; height:30px;">
                           <tr>
                               <td colspan="1" style="height: 26px; width: 429px">
                                   <dx:ASPxLabel ID="ASPxLabel18" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Indegious Zimbabwean?" Theme="Glass">
                                   </dx:ASPxLabel>
                                   <dx:ASPxLabel ID="ASPxLabel19" runat="server" ForeColor="Red" Text="*">
                                   </dx:ASPxLabel>
                               </td>
                               <td colspan="1" style="height: 26px; width: 249px">
<%--                                   <asp:RadioButtonList runat="server">--%>
                <asp:RadioButtonList ID="rbtLstRating" runat="server" 
                         RepeatDirection="Horizontal" RepeatLayout="Table" Enabled="False">
                             <asp:ListItem Text="Yes" Value="Yes"></asp:ListItem>
                             <asp:ListItem Text="No" Value="No"></asp:ListItem>
                 </asp:RadioButtonList>  
<%--                                   </asp:RadioButtonList>--%>
                                   

<%--                                   <dx:ASPxComboBox ID="ASPxComboBox1" runat="server" AutoPostBack="True" Theme="BlackGlass" ValueType="System.String" Width="250px">--%>
<%--                                   </dx:ASPxComboBox>--%>
                               </td>
                               <td colspan="2" style="height: 26px"></td>
                               <td colspan="1" style="height: 26px"></td>
                               <td colspan="1" style="height: 26px"></td>
                               <td colspan="1" style="height: 26px"></td>
                               <td colspan="1" style="height: 26px"></td>
                           </tr>
                           <tr>
                               <td colspan="1" style="height: 30px; width: 429px">
                                   <dx:ASPxLabel ID="ASPxLabel20" runat="server" Font-Names="Cambria" Font-Size="Small" Text="State your Race" Theme="Glass">
                                   </dx:ASPxLabel>
                                   <dx:ASPxLabel ID="ASPxLabel21" runat="server" ForeColor="Red" Text="*">
                                   </dx:ASPxLabel>
                               </td>
                               <td colspan="1" style="height: 30px; width: 249px">
                                   <dx:ASPxTextBox ID="raceText" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="250px" ReadOnly="True">
                                   </dx:ASPxTextBox>
                               </td>
                               <td colspan="2" style="height: 30px">
<%--                                   <dx:ASPxCheckBox ID="ASPxCheckBox1" runat="server" AutoPostBack="True" Text="Use Mobile Number">--%>
<%--                                   </dx:ASPxCheckBox>--%>
                               </td>
                               <td colspan="1" style="height: 30px"></td>
                               <td colspan="1" style="height: 30px"></td>
                               <td colspan="1" style="height: 30px"></td>
                               <td colspan="1" style="height: 30px"></td>
                           </tr>
                           
                           <tr>
                               <td colspan="1" style="height: 25px; width: 429px">
                                   <dx:ASPxLabel ID="ASPxLabel22" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Was your race previously disadvantaged?" Theme="Glass">
                                   </dx:ASPxLabel>
                                   <dx:ASPxLabel ID="ASPxLabel23" runat="server" ForeColor="Red" Text="*">
                                   </dx:ASPxLabel>
                               </td>
                               <td colspan="1" style="height: 25px; width: 249px">
                                     <asp:RadioButtonList ID="dis" runat="server" 
                         RepeatDirection="Horizontal" RepeatLayout="Table" Enabled="False">
                             <asp:ListItem Text="Yes" Value="Yes"></asp:ListItem>
                             <asp:ListItem Text="No" Value="No"></asp:ListItem>
                
                 </asp:RadioButtonList>  
                               </td>
                               <td colspan="2" style="height: 25px">
<%--                                   <dx:ASPxCheckBox ID="ASPxCheckBox2" runat="server" AutoPostBack="True" Text="Use Mobile Number">--%>
<%--                                   </dx:ASPxCheckBox>--%>
                               </td>
                               <td colspan="1" style="height: 25px"></td>
                               <td colspan="1" style="height: 25px"></td>
                               <td colspan="1" style="height: 25px"></td>
                               <td colspan="1" style="height: 25px"></td>
                           </tr>
                           
                        
<%--                           <tr>--%>
<%--                           <td align="left" colspan="1" style="width: 429px">--%>
<%--                                        <dx:ASPxLabel ID="ASPxLabel16" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Nationality" Theme="Glass">--%>
<%--                                        </dx:ASPxLabel>--%>
<%--                                    </td>--%>
<%--                                    <td align="left" colspan="2">--%>
<%--                                        <dx:ASPxComboBox ID="ASPxComboBox1" runat="server" Theme="BlackGlass" ValueType="System.String" Width="250px">--%>
<%--                                        </dx:ASPxComboBox>--%>
<%--                                    </td>--%>
<%--                                 </tr>--%>
                           
                           
                           <tr>
                               <td colspan="1" style="height: 22px; width: 429px">
                                   <dx:ASPxLabel ID="ASPxLabel24" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Nationality By?" Theme="Glass">
                                   </dx:ASPxLabel>
                                   <dx:ASPxLabel ID="ASPxLabel34" runat="server" ForeColor="Red" Text="*">
                                   </dx:ASPxLabel>
                               </td>
                               <td colspan="1" style="height: 22px; width: 249px">
                                   <asp:RadioButtonList ID="natBy" runat="server" 
                         RepeatDirection="Horizontal" RepeatLayout="Table" Enabled="False">
                             <asp:ListItem Text="Birth" Value="Birth"></asp:ListItem>
                             <asp:ListItem Text="Descendancy" Value="Descendancy"></asp:ListItem>
                   <asp:ListItem Text="Adoption" Value="Adoption"></asp:ListItem>
                 </asp:RadioButtonList> 
                               </td>
                               <td colspan="2" style="height: 22px">
                                   </td>
                               <td colspan="1" style="height: 22px"></td>
                               <td colspan="1" style="height: 22px"></td>
                               <td colspan="1" style="height: 22px"></td>
                               <td colspan="1" style="height: 22px"></td>
                           </tr>
                           

                           <tr>
                               <td colspan="1" style="width: 429px"></td>
                               <td colspan="1" style="width: 249px"></td>
                               <td colspan="1"></td>
                               <td colspan="1"></td>
                               <td colspan="1"></td>
                               <td colspan="1"></td>
                               <td colspan="1"></td>
                               <td colspan="1"></td>
                           </tr>
                       </table>

    </asp:panel>

        <asp:panel id="Panel3" runat="server" GroupingText="Contact Details" Font-Names="Cambria">
        <table width="810px">
      
           <tr>
               <td colspan ="1">
                   <dx:ASPxLabel ID="ASPxLabel6" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Address" Theme="Glass">
                   </dx:ASPxLabel>
               </td>
               <td colspan ="7">
                   <dx:ASPxTextBox ReadOnly="True" ID="txtAdd1" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="710px">
                   </dx:ASPxTextBox>
               </td>

           </tr>
             <tr>
                    <td colspan ="1"></td>
                <td colspan ="7">
                    <dx:ASPxLabel ID="lblAdd1" runat="server">
                    </dx:ASPxLabel>
                    </td>

            </tr>
            <tr>
                    <td colspan ="1">
                        &nbsp;</td>
                <td colspan ="7">
                    <dx:ASPxTextBox ReadOnly="True" ID="txtAdd2" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="710px">
                    </dx:ASPxTextBox>
                    </td>

            </tr>
             <tr>
                    <td colspan ="1"></td>
                <td colspan ="7">
                    <dx:ASPxLabel ID="lblAdd2" runat="server">
                    </dx:ASPxLabel>
                    </td>

            </tr>
                <tr>
                    <td colspan ="1">
                        &nbsp;</td>
                <td colspan ="7">
                    <dx:ASPxTextBox ReadOnly="True" ID="txtAdd3" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="710px">
                    </dx:ASPxTextBox>
                    </td>

            </tr>
             <tr>
                    <td colspan ="1"></td>
                <td colspan ="7">
                    <dx:ASPxLabel ID="lblAdd3" runat="server">
                    </dx:ASPxLabel>
                    </td>

            </tr>
                <tr>
                    <td colspan ="1">
                        &nbsp;</td>
                <td colspan ="7">
                    <dx:ASPxTextBox ReadOnly="True" ID="txtAdd4" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="710px">
                    </dx:ASPxTextBox>
                    </td>

            </tr>
             <tr>
                    <td colspan ="1"></td>
                <td colspan ="7">
                    <dx:ASPxLabel ID="lblAdd4" runat="server">
                    </dx:ASPxLabel>
                    </td>

            </tr>
                <tr>
                    <td colspan ="1">
                        <dx:ASPxLabel ID="ASPxLabel54" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Country" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                <td colspan ="1">
                    
                    <dx:ASPxTextBox ReadOnly="True" ID="txtCountry" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="250px">
                    </dx:ASPxTextBox>
                    
                    </td>
                    <td colspan ="1">
                    
                        &nbsp;</td>
                    <td colspan ="1">
                    
                        <dx:ASPxTextBox ReadOnly="True" ID="txtCity" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="250px" Visible="False">
                        </dx:ASPxTextBox>
                    
                    </td>
                    <td colspan ="1">
                    
                    </td>
                    <td colspan ="1">
                    
                    </td>
                    <td colspan ="1">
                    
                    </td>
                    <td colspan ="1">
                    
                    </td>

            </tr>
            <tr>
                    <td colspan ="1"></td>
                <td colspan ="1">
                    <dx:ASPxLabel ID="lblCountry" runat="server">
                    </dx:ASPxLabel>
                    </td>
                <td colspan ="1"></td>
                <td colspan ="1">
                    <dx:ASPxLabel ID="lblCity" runat="server">
                    </dx:ASPxLabel>
                    </td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>

            </tr>
            <tr>
                    <td colspan ="1">
                        <dx:ASPxLabel ID="ASPxLabel8" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Telephone" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                <td colspan ="1">
                    <dx:ASPxTextBox ReadOnly="True" ID="txtTel" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="250px">
                    </dx:ASPxTextBox>
                    </td>
                <td colspan ="1">
                    <dx:ASPxLabel ID="ASPxLabel9" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Mobile" Theme="Glass">
                    </dx:ASPxLabel>
                    </td>
                <td colspan ="1">
                    <dx:ASPxTextBox ReadOnly="True" ID="txtMobile" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="250px">
                    </dx:ASPxTextBox>
                    </td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>

            </tr>
            <tr>
<td colspan ="1">
    <dx:ASPxLabel ID="ASPxLabel138" runat="server" Font-Names="Cambria" Font-Size="Small" Text="CNIC" Theme="Glass">
    </dx:ASPxLabel>
</td>
<td colspan ="1">
<dx:ASPxTextBox ID="txtCNIC" ReadOnly="true" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="250px">
</dx:ASPxTextBox>
</td>
<td colspan="1" style="height: 16px">
    <dx:ASPxLabel ID="ASPxLabel312" runat="server" Font-Names="Cambria" Font-Size="Small" Text="CNIC Expiry Date" Theme="Glass">
    </dx:ASPxLabel>
    
</td>
<td style="height: 16px">
    <dx:ASPxTextBox ID="txtCNICExpiry" ReadOnly="true" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="250px">
</dx:ASPxTextBox>
</td>
</tr>
<tr>
<td colspan ="1">
    <dx:ASPxLabel ID="ASPxLabel1318" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Passport " Theme="Glass">
    </dx:ASPxLabel>
</td>
<td colspan ="1">
<dx:ASPxTextBox ID="txtpassport" readonly="true" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="250px">
</dx:ASPxTextBox>
</td>
  <td colspan="1" style="height: 16px">
    <dx:ASPxLabel ID="ASPxLabel3124" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Passport Expiry Date" Theme="Glass">
    </dx:ASPxLabel>
  
</td>
<td style="height: 16px">
    <<dx:ASPxTextBox ID="txtpassportexpirydate" readonly="true" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="250px">
</dx:ASPxTextBox>
</td>
</tr>
              <tr>
                    <td colspan ="1"></td>
                <td colspan ="1">
                    <dx:ASPxLabel ID="lblTel" runat="server">
                    </dx:ASPxLabel>
                    </td>
                <td colspan ="1"></td>
                <td colspan ="1">
                    <dx:ASPxLabel ID="lblMobile" runat="server">
                    </dx:ASPxLabel>
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
                    <dx:ASPxTextBox ReadOnly="True" ID="txtEmail" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="250px">
                    </dx:ASPxTextBox>
                </td>
                 <td colspan ="1">
                    <dx:ASPxLabel ID="ASPxLabel120" runat="server" Font-Names="Cambria" Font-Size="Small" Text="NTN number" Theme="Glass">
                    </dx:ASPxLabel>
                   
                </td>
                <td colspan ="1">
                    <dx:ASPxTextBox ID="txtNTN" ReadOnly="true" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="250px">
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
                    <dx:ASPxLabel ID="ASPxLabel39" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Residental Status" Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                <td colspan ="1">
                    <dx:ASPxTextBox ReadOnly="True" ID="txtResidentialStatus" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="250px">
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
              <tr id="tax" runat="server" visible="false">
                <td colspan ="1">
                    <dx:ASPxLabel ID="ASPxLabel63" runat="server" Font-Names="Cambria" Font-Size="Small" Text="National Tax" Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                <td colspan ="1">
                    <dx:ASPxTextBox ReadOnly="True" ID="txtNationalTax" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="250px">
                    </dx:ASPxTextBox>
                </td>
                 <td colspan ="1">
                    <dx:ASPxLabel ID="ASPxLabel64" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Sales Tax Registration" Theme="Glass">
                    </dx:ASPxLabel>
                    <dx:ASPxLabel ID="ASPxLabel65" runat="server" ForeColor="Red" Text="*">
                    </dx:ASPxLabel>
                </td>
                <td colspan ="1">
                    <dx:ASPxTextBox ID="txtTaxRegistration" ReadOnly="true" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="250px">
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
            <tr id="Revenue" runat="server" visible="false">
                <td colspan ="1">
                    <dx:ASPxLabel ID="ASPxLabel66" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Expected Revenue Current Year" Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                <td colspan ="1">
                    <dx:ASPxTextBox ReadOnly="True" ID="txtRevenue" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="250px">
                    </dx:ASPxTextBox>
                </td>
                 <td colspan ="1">
                    <dx:ASPxLabel ID="ASPxLabel67" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Net Assets" Theme="Glass">
                    </dx:ASPxLabel>
                    <dx:ASPxLabel ID="ASPxLabel68" runat="server" ForeColor="Red" Text="*">
                    </dx:ASPxLabel>
                </td>
                <td colspan ="1">
                    <dx:ASPxTextBox ID="txtNetAssets" ReadOnly="true" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="250px">
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
                    <td colspan ="1"></td>
                <td colspan ="1">
                    <dx:ASPxLabel ID="lblEmail" runat="server">
                    </dx:ASPxLabel>
                    </td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>

            </tr>
          
        </table>

    </asp:panel>
        <asp:Panel runat="server" GroupingText="Banking Details" Font-Names="Cambria">
         

        <table width="810px">
           <tr>
               <td colspan ="1">
                   <dx:ASPxLabel ID="ASPxLabel7" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Payee" Theme="Glass" Visible="False">
                   </dx:ASPxLabel>
               </td>
               <td colspan ="1">
                   <dx:ASPxTextBox ReadOnly="True" ID="txtpayee" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="250px" Visible="False">
                   </dx:ASPxTextBox>
                   <dx:ASPxLabel ID="ASPxLabel11" runat="server">
                   </dx:ASPxLabel>
               </td>
               <td colspan ="1">
                   &nbsp;</td>
               <td colspan ="1">
                   &nbsp;</td>
               <td colspan ="1">&nbsp;</td>
               <td colspan ="1">&nbsp;</td>
               <td colspan ="1">&nbsp;</td>
               <td colspan ="1">&nbsp;</td>
           </tr>
                <tr>
                    <td colspan="1">
                        <dx:ASPxLabel ID="ASPxLabel12" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Bank Name" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td colspan="1">
                        <dx:ASPxTextBox ReadOnly="True" ID="txtbnkname" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="250px">
                        </dx:ASPxTextBox>
                        <dx:ASPxLabel ID="ASPxLabel13" runat="server">
                        </dx:ASPxLabel>
                    </td>
                    <td colspan="1">
                        <dx:ASPxLabel ID="ASPxLabel14" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Branch" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td colspan="1">
                        <dx:ASPxTextBox ReadOnly="True" ID="txtbranchname" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="250px">
                        </dx:ASPxTextBox>
                        <dx:ASPxLabel ID="ASPxLabel15" runat="server">
                        </dx:ASPxLabel>
                    </td>
                    <td colspan="1"></td>
                    <td colspan="1"></td>
                    <td colspan="1"></td>
                    <td colspan="1"></td>
            </tr>
                <tr>
               <td colspan ="1">
                   <dx:ASPxLabel ID="ASPxLabel16" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Account No." Theme="Glass">
                   </dx:ASPxLabel>
                    </td>
               <td colspan ="1">
                   <dx:ASPxTextBox ReadOnly="True" ID="txtaccno" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="250px">
                   </dx:ASPxTextBox>
                    <dx:ASPxLabel ID="ASPxLabel17" runat="server">
                   </dx:ASPxLabel>
                    </td>
                     <td colspan ="1">
                   <dx:ASPxLabel ID="ASPxLabel37" runat="server" Font-Names="Cambria" Font-Size="Small" Text="IBAN." Theme="Glass">
                   </dx:ASPxLabel>
                    </td>
               <td colspan ="1">
                   <dx:ASPxTextBox ReadOnly="True" ID="txtIBAN" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="250px">
                   </dx:ASPxTextBox>
                    <dx:ASPxLabel ID="ASPxLabel38" runat="server">
                   </dx:ASPxLabel>
                    </td>
               <td colspan ="1"></td>
               <td colspan ="1"></td>
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
          <asp:Panel runat="server" GroupingText="Witnesses" Font-Names="Cambria">
         

        <table width="810px">
           
                <tr>
                    <td colspan="1">
                        <dx:ASPxLabel ID="ASPxLabel42" runat="server" Font-Names="Cambria" Font-Size="Small" Text="First Witness Name" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td colspan="1">
                        <dx:ASPxTextBox ReadOnly="True" ID="txtFirstWitnessName" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="250px">
                        </dx:ASPxTextBox>
                        <dx:ASPxLabel ID="ASPxLabel43" runat="server">
                        </dx:ASPxLabel>
                    </td>
                    <td colspan="1">
                        <dx:ASPxLabel ID="ASPxLabel45" runat="server" Font-Names="Cambria" Font-Size="Small" Text="First Witness CNIC" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td colspan="1">
                        <dx:ASPxTextBox ReadOnly="True" ID="txtFirstWitnessCNIC" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="250px">
                        </dx:ASPxTextBox>
                        <dx:ASPxLabel ID="ASPxLabel52" runat="server">
                        </dx:ASPxLabel>
                    </td>
                    <td colspan="1"></td>
                    <td colspan="1"></td>
                    <td colspan="1"></td>
                    <td colspan="1"></td>
            </tr>
                <tr>
               <td colspan ="1">
                   <dx:ASPxLabel ID="ASPxLabel53" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Second Witness Name" Theme="Glass">
                   </dx:ASPxLabel>
                    </td>
               <td colspan ="1">
                   <dx:ASPxTextBox ReadOnly="True" ID="txtSecondWitnesName" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="250px">
                   </dx:ASPxTextBox>
                    <dx:ASPxLabel ID="ASPxLabel55" runat="server">
                   </dx:ASPxLabel>
                    </td>
                     <td colspan ="1">
                   <dx:ASPxLabel ID="ASPxLabel58" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Second Witness CNIC" Theme="Glass">
                   </dx:ASPxLabel>
                    </td>
               <td colspan ="1">
                   <dx:ASPxTextBox ReadOnly="True" ID="txtSecondWitnessCNIC" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="250px">
                   </dx:ASPxTextBox>
                    <dx:ASPxLabel ID="ASPxLabel62" runat="server">
                   </dx:ASPxLabel>
                    </td>
               <td colspan ="1"></td>
               <td colspan ="1"></td>
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
        <asp:panel id="Panel11" runat="server" GroupingText="Controlled/Non-controlled" Font-Names="Cambria" Enabled="False" Visible="False">
        <table width="810px">
            <tr>
                    <td colspan ="8" align="center">
                        <asp:RadioButton ID="rdControlled" runat="server" AutoPostBack="True" GroupName="Controlling" Text="Controlled" />
                        <asp:RadioButton ID="rdNonControlled" runat="server" AutoPostBack="True" GroupName="Controlling" Text="Non Controlled" />
                    </td>

            </tr>
         
           <tr>
               <td colspan ="1" valign="bottom"   style="width: 58px; height: 47px;">
                   <dx:ASPxLabel ID="ASPxLabel35" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Custodian" Theme="Glass">
                   </dx:ASPxLabel>
                   &nbsp;</td>
               <td valign="middle" colspan ="7" style="height: 47px">
                   <dx:ASPxTextBox ReadOnly="True" ID="txtcust" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="250px">
                   </dx:ASPxTextBox>
               </td>

           </tr>
             <tr>
               <td colspan ="1" style="width: 58px">
                   &nbsp;</td>
               <td colspan ="7">
                   <dx:ASPxLabel ID="lblcustodian" runat="server">
                   </dx:ASPxLabel>
                 </td>

           </tr>
               
        </table>

    </asp:panel>
        
        <asp:panel id="Panel9" runat="server" GroupingText="Attributes" Font-Names="Cambria" Visible="False">
        <table width="810px">
         <tr>
                <td colspan ="1">
                    <dx:ASPxLabel ID="ASPxLabel46" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Trading Status" Theme="Glass">
                    </dx:ASPxLabel>
                </td>
             <td colspan ="1">
                 <asp:RadioButton ID="rdTrading" runat="server" enabled="false" AutoPostBack="True" GroupName="TradingStatus" Text="DEALING ALLOWED" />
                 <asp:RadioButton ID="rdNonTrading" runat="server" enabled="false" AutoPostBack="True" GroupName="TradingStatus" Text="NON-TRADING" />
                </td>
             <td colspan ="1">
                 &nbsp;</td>
             <td colspan ="1"></td>
             <td colspan ="1"></td>
             <td colspan ="1"></td>
             <td colspan ="1"></td>
             <td colspan ="1"></td>

         </tr>
            <tr>

                <td colspan ="1">
                    <dx:ASPxLabel ID="ASPxLabel48" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Industry" Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                <td colspan ="1">
                    <dx:ASPxTextBox ReadOnly="True" ID="txtIndustry" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="250px">
                    </dx:ASPxTextBox>
                </td>
                <td colspan ="1">
                    <dx:ASPxLabel ID="ASPxLabel47" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Tax" Theme="Glass" Visible="False">
                    </dx:ASPxLabel>
                </td>
                <td colspan ="1">
                    <dx:ASPxTextBox ReadOnly="True" ID="txtTax" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="250px" Visible="False">
                    </dx:ASPxTextBox>
                </td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>

            </tr>

            <tr>
                <td colspan="1">&nbsp;</td>
                <td colspan="1">
                    <dx:ASPxLabel ID="lblindustry" runat="server">
                    </dx:ASPxLabel>
                </td>
                <td colspan="1">&nbsp;</td>
                <td colspan="1">
                    <dx:ASPxLabel ID="lbltax" runat="server" Visible="False">
                    </dx:ASPxLabel>
                </td>
                <td colspan="1">&nbsp;</td>
                <td colspan="1">&nbsp;</td>
                <td colspan="1">&nbsp;</td>
                <td colspan="1">&nbsp;</td>
            </tr>

        </table>
             </asp:panel>
          <asp:Panel ID="Panel17" runat="server" Font-Names="Cambria" GroupingText="Holdings(Units)" Visible="False">
              <table width="810px">
                  <tr>
                      <td align="center" colspan="2">
                          <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" ShowFooter="True" Width="100%">
                              <AlternatingRowStyle BackColor="White" />
                              <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                              <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />
                              <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                              <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
                              <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                              <SortedAscendingCellStyle BackColor="#FDF5AC" />
                              <SortedAscendingHeaderStyle BackColor="#4D0000" />
                              <SortedDescendingCellStyle BackColor="#FCF6C0" />
                              <SortedDescendingHeaderStyle BackColor="#820000" />
                          </asp:GridView>
                      </td>
                  </tr>
                  <tr>
                      <td colspan="1">&nbsp;</td>
                      <td>&nbsp;</td>
                  </tr>
              </table>
        </asp:Panel>
          <asp:panel id="Panel12" runat="server" GroupingText="Dividend Payment Mandate" Font-Names="Cambria" Visible="False">
        <table width="810px">
           <tr>
               <td colspan ="1" style="height: 23px">
                   <dx:ASPxLabel ID="ASPxLabel61" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Payee" Theme="Glass">
                   </dx:ASPxLabel>
               </td>
               <td colspan ="1" style="height: 23px">
                   <dx:ASPxTextBox ReadOnly="True" ID="txtPayee2" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="250px">
                   </dx:ASPxTextBox>
                   <dx:ASPxLabel ID="lbldivpayee" runat="server">
                   </dx:ASPxLabel>
               </td>
               <td colspan ="1" style="height: 23px">
                   </td>
               <td colspan ="1" style="height: 23px">
                   </td>
               <td colspan ="1" style="height: 23px"></td>
               <td colspan ="1" style="height: 23px"></td>
               <td colspan ="1" style="height: 23px"></td>
               <td colspan ="1" style="height: 23px"></td>
           </tr>
                <tr>
                    <td colspan="1">
                        <dx:ASPxLabel ID="ASPxLabel49" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Bank Name" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td colspan="1">
                        <dx:ASPxTextBox ReadOnly="True" ID="txtBankName" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="250px">
                        </dx:ASPxTextBox>
                        <dx:ASPxLabel ID="lbldivbank" runat="server">
                        </dx:ASPxLabel>
                    </td>
                    <td colspan="1">
                        <dx:ASPxLabel ID="ASPxLabel50" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Branch" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td colspan="1">
                        <dx:ASPxTextBox ReadOnly="True" ID="txtBranch" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="250px">
                        </dx:ASPxTextBox>
                        <dx:ASPxLabel ID="lbldivbranch" runat="server">
                        </dx:ASPxLabel>
                    </td>
                    <td colspan="1"></td>
                    <td colspan="1"></td>
                    <td colspan="1"></td>
                    <td colspan="1"></td>
            </tr>
                <tr>
               <td colspan ="1">
                   <dx:ASPxLabel ID="ASPxLabel51" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Account No." Theme="Glass">
                   </dx:ASPxLabel>
                    </td>
               <td colspan ="1">
                   <dx:ASPxTextBox ReadOnly="True" ID="txtAccountNo" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="250px">
                   </dx:ASPxTextBox>
                    <dx:ASPxLabel ID="lbldivaccountno" runat="server">
                   </dx:ASPxLabel>
                    </td>
               <td colspan ="1"></td>
               <td colspan ="1"></td>
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

    </asp:panel>
        <asp:Panel ID="Panel16" visible="false" runat="server" Font-Bold="True" Font-Names="Cambria" Font-Size="10pt" GroupingText="Mobile Money Details" Width="840px">
            <table style="width: 840px; height:30px;">
                <tr>
                    <td colspan="1" style="height: 46px; width: 98px">
                        <dx:ASPxLabel ID="ASPxLabel76" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Mobile Money" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td colspan="1" style="height: 46px; width: 249px">
                        <dx:ASPxTextBox ID="txtmobilemoney" runat="server" BackColor="#E4E4E4" ReadOnly="True" Theme="BlackGlass" Width="250px">
                        </dx:ASPxTextBox>
                    </td>
                    <td colspan="2" style="height: 46px">&nbsp;</td>
                    <td colspan="1" style="height: 46px">&nbsp;</td>
                    <td colspan="1" style="height: 46px">&nbsp;</td>
                    <td colspan="1" style="height: 46px">&nbsp;</td>
                    <td colspan="1" style="height: 46px">&nbsp;</td>
                </tr>
                <tr>
                    <td colspan="1" style="height: 46px; width: 98px">
                        <dx:ASPxLabel ID="ASPxLabel75" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Mobile Number" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td colspan="1" style="height: 46px; width: 249px">
                        <dx:ASPxTextBox ID="txtmobilemonephone" runat="server" BackColor="#E4E4E4" ReadOnly="True" Theme="BlackGlass" Width="250px">
                        </dx:ASPxTextBox>
                    </td>
                    <td colspan="2" style="height: 46px">&nbsp;</td>
                    <td colspan="1" style="height: 46px"></td>
                    <td colspan="1" style="height: 46px"></td>
                    <td colspan="1" style="height: 46px"></td>
                    <td colspan="1" style="height: 46px"></td>
                </tr>
                <tr>
                    <td colspan="1" style="width: 98px"></td>
                    <td colspan="1" style="width: 249px"></td>
                    <td colspan="1"></td>
                    <td colspan="1"></td>
                    <td colspan="1"></td>
                    <td colspan="1"></td>
                    <td colspan="1"></td>
                    <td colspan="1"></td>
                </tr>
            </table>
        </asp:Panel>
        <asp:panel id="Panel2" runat="server" GroupingText="Settlement  Account Mandate" Font-Names="Cambria" Enabled="False" Visible="False">
        <table width="810px">
           <tr>
               <td colspan ="1">
                   <dx:ASPxLabel ID="ASPxLabel60" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Payee" Theme="Glass">
                   </dx:ASPxLabel>
               </td>
               <td colspan ="1">
                   <dx:ASPxTextBox ReadOnly="True" ID="txtPayee1" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="250px">
                   </dx:ASPxTextBox>
                   <dx:ASPxLabel ID="lblcashpayee" runat="server">
                   </dx:ASPxLabel>
               </td>
               <td colspan ="1">
                   &nbsp;</td>
               <td colspan ="1">
                   &nbsp;</td>
               <td colspan ="1">&nbsp;</td>
               <td colspan ="1">&nbsp;</td>
               <td colspan ="1">&nbsp;</td>
               <td colspan ="1">&nbsp;</td>
           </tr>
                <tr>
                    <td colspan="1">
                        <dx:ASPxLabel ID="ASPxLabel2" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Bank Name" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td colspan="1">
                        <dx:ASPxTextBox ReadOnly="True" ID="txtCashBank" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="250px">
                        </dx:ASPxTextBox>
                        <dx:ASPxLabel ID="lblcashbank" runat="server">
                        </dx:ASPxLabel>
                    </td>
                    <td colspan="1">
                        <dx:ASPxLabel ID="ASPxLabel3" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Branch" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td colspan="1">
                        <dx:ASPxTextBox ReadOnly="True" ID="txtCashBrach" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="250px">
                        </dx:ASPxTextBox>
                        <dx:ASPxLabel ID="lblcashbranch" runat="server">
                        </dx:ASPxLabel>
                    </td>
                    <td colspan="1"></td>
                    <td colspan="1"></td>
                    <td colspan="1"></td>
                    <td colspan="1"></td>
            </tr>
                <tr>
               <td colspan ="1">
                   <dx:ASPxLabel ID="ASPxLabel4" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Account No." Theme="Glass">
                   </dx:ASPxLabel>
                    </td>
               <td colspan ="1">
                   <dx:ASPxTextBox ReadOnly="True" ID="txtCashAccount" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="250px">
                   </dx:ASPxTextBox>
                    <dx:ASPxLabel ID="lblcashaccountno" runat="server">
                   </dx:ASPxLabel>
                    </td>
               <td colspan ="1"></td>
               <td colspan ="1"></td>
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

    </asp:panel>

        <asp:Panel ID="panelSave" runat="server" Font-Names="Cambria" GroupingText="Attachments">
            <table style="width: 576px">
                <tr>
                    <td align="center">
                        <asp:GridView ID="grdEvent" runat="server" AutoGenerateColumns="False" CellPadding="4" CssClass="tablestyle" DataKeyNames="ID" Font-Size="Small" ForeColor="#333333" GridLines="None" Style="position: relative; top: 12px; left: 62px; width: 35%; height: 3px;">
                            <PagerSettings FirstPageText="First" LastPageText="Last" NextPageText="Next" PreviousPageText="Previous" />
                            <AlternatingRowStyle BackColor="White" CssClass="altrowstyle" />
                            <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />
                            <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                            <RowStyle BackColor="#FFFBD6" CssClass="rowstyle" ForeColor="#333333" />
                            <Columns>
                                <asp:BoundField DataField="name" HeaderText="Document Name" />
                                <asp:CommandField SelectText="View" ShowSelectButton="true">
                                <ItemStyle Font-Bold="True" Font-Italic="True" ForeColor="Red" />
                                </asp:CommandField>
                            </Columns>
                            <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                            <SortedAscendingCellStyle BackColor="#FDF5AC" />
                            <SortedAscendingHeaderStyle BackColor="#4D0000" />
                            <SortedDescendingCellStyle BackColor="#FCF6C0" />
                            <SortedDescendingHeaderStyle BackColor="#820000" />
                        </asp:GridView>
                    </td>
                </tr>
            </table>
        </asp:Panel>
        <asp:Panel runat="server" ID="panel4" GroupingText=".">
            <table style="width: 825px">
                    <tr>
                            <td colspan ="2" align="center">
                                &nbsp;</td>


                    </tr>
                <tr>
                        <td colspan ="2" align ="center">
                            <dx:ASPxRadioButton ID="rdApprove" runat="server" AutoPostBack="True" GroupName="Approval" Text="Approve" Theme="DevEx">
                            </dx:ASPxRadioButton>
                            <dx:ASPxRadioButton ID="rdReject" runat="server" AutoPostBack="True" GroupName="Approval" Text="Reject" Theme="DevEx">
                            </dx:ASPxRadioButton>
                        </td>

                </tr>
                <tr>
                    <td colspan ="1">
                        <dx:ASPxLabel ID="lblRejection" runat="server" Text="Rejection Reason" Visible="False">
                        </dx:ASPxLabel>
                    </td>
                    <td>
                        <dx:ASPxTextBox ID="txtReasons" runat="server" Height="80px" Theme="BlackGlass" Visible="False" Width="700px">
                        </dx:ASPxTextBox>
                    </td>
                </tr>
                <tr>
                        <td colspan ="2" align ="center">
                            <dx:ASPxButton ID="ASPxButton1" runat="server" Text="save" Theme="BlackGlass">
                            </dx:ASPxButton>
                        </td>

                </tr>

            </table>
        </asp:Panel>
        <asp:Panel runat="server" ID="panelsaving" GroupingText=".">
            <table>
                    <tr>
                            <td colspan ="8" align="center">
                                &nbsp;</td>


                    </tr>
                <tr>
                        <td colspan ="8" align ="center">
                            &nbsp;</td>

                </tr>

            </table>
        </asp:Panel>  
                 
</asp:Panel>
  
</div>
</asp:Content>

