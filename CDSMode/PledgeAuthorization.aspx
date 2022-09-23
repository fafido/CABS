<%@ Page Language="VB" MasterPageFile="~/CDSUser.master" AutoEventWireup="false" CodeFile="PledgeAuthorization.aspx.vb" Inherits="CDSMode_PledgeAuthorization" title="Account Details Enquiry" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<asp:Content id="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
    <asp:Panel id="Panel1" runat="server" Width="840px" Font-Names="Arial" Font-Size="Medium" BackColor="White">
    
        <table width ="810px">
            <tr>
                   <td style ="text-align :left;" align="left">
                       <dx:ASPxLabel ID="ASPxLabel1" runat="server" Text="Authorizations&gt;&gt;Pledge Authorization" Font-Names="Cambria" Font-Size="Small" Theme="PlasticBlue"></dx:ASPxLabel>

                   </td>
            </tr>
        </table>
<asp:Panel runat="server" ID="SearchOptions" Font-Names="Cambria" GroupingText="Search">
    <table>

        <tr>

                <td colspan ="1">
                    <dx:ASPxLabel ID="ASPxLabel65" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Pledges Pending Approval" Theme="Glass">
                    </dx:ASPxLabel>
                </td>
            <td colspan ="7">
                <dx:ASPxComboBox ID="ASPxComboBox1" runat="server" Theme="BlackGlass" ValueType="System.String" Width="650px">
                </dx:ASPxComboBox>
                </td>

        </tr>
        <tr>

                <td colspan ="1">
                    <dx:ASPxLabel ID="ASPxLabel67" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Status" Theme="Glass">
                    </dx:ASPxLabel>
                </td>
            <td colspan ="7">
                <dx:ASPxLabel ID="ASPxLabel66" runat="server" Font-Names="Cambria" Font-Size="Small" Text="New Pledge/Update Pledge/Transfer Pledge" Theme="Glass">
                </dx:ASPxLabel>
                </td>
        </tr>

    </table>
</asp:Panel>
        <asp:Panel runat="server" ID="PanelType" Font-Names="Cambria" GroupingText="Type">

            <table width ="810px">
                <tr>
                        <td colspan ="8" align="center">


                            <asp:RadioButton ID="rdVoluntary" runat="server" AutoPostBack="True" GroupName="PledgeType" Text="Voluntary" />
                            <asp:RadioButton ID="rdPledgeType" runat="server" AutoPostBack="True" GroupName="PledgeType" Text="Forced" />


                        </td>

                </tr>
                <tr>
                    <td colspan ="1">
                        <dx:ASPxLabel ID="ASPxLabel52" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Reason" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td colspan ="7">
                        <dx:ASPxTextBox ID="ASPxTextBox18" runat="server" AutoResizeWithContainer="True" BackColor="#E4E4E4" Theme="BlackGlass" Width="710px">
                            <Paddings PaddingBottom="30px" />
                        </dx:ASPxTextBox>
                    </td>
                </tr>
                <tr>
                        <td colspan ="1">
                            <dx:ASPxLabel ID="ASPxLabel53" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Supporting Documents" Theme="Glass">
                            </dx:ASPxLabel>
                        </td>
                    <td colspan ="1"></td>
                    <td colspan ="1"></td>
                    <td colspan ="1"></td>
                    <td colspan ="1" align="center">
                        <dx:ASPxButton ID="ASPxButton4" runat="server" Text="Scan" Theme="BlackGlass">
                        </dx:ASPxButton>
                        </td>
                    <td colspan ="1"></td>
                    <td colspan ="1"></td>
                    <td colspan ="1"></td>

                </tr>
                     <tr>
                        <td colspan ="1" style="height: 18px"></td>
                    <td colspan ="1" style="height: 18px"></td>
                    <td colspan ="1" style="height: 18px"></td>
                    <td colspan ="1" style="height: 18px"></td>
                    <td colspan ="1" align="center" style="height: 18px">
                        <asp:RadioButton ID="rdiD" runat="server" AutoPostBack="True" GroupName="DocumentsType" Text="Identity Documents" />
                        <asp:RadioButton ID="rdCourtDocs" runat="server" AutoPostBack="True" GroupName="DocumentsType" Text="Court Documents" />
                        <asp:RadioButton ID="rdPledgeForms" runat="server" AutoPostBack="True" GroupName="DocumentsType" Text="Pledge Forms" />
                        <asp:RadioButton ID="rdPledgeForms0" runat="server" AutoPostBack="True" GroupName="DocumentsType" Text="Other" />
                         </td>
                    <td colspan ="1" style="height: 18px"></td>
                    <td colspan ="1" style="height: 18px"></td>
                    <td colspan ="1" style="height: 18px"></td>

                </tr>

            </table>
        </asp:Panel>
        <asp:panel id="Panel8" runat="server" GroupingText="Pledgor Information" Font-Names="Cambria">
        <table width="810px">
            <tr>
                    <td colspan ="1">
                        <dx:ASPxLabel ID="ASPxLabel54" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Client ID." Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                <td colspan ="1">
                    <dx:ASPxTextBox ID="txtClientNo8" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="250px">
                    </dx:ASPxTextBox>
                    </td>
                <td colspan ="1">
                    <dx:ASPxButton ID="ASPxButton5" runat="server" Text="&gt;&gt;" Theme="BlackGlass">
                    </dx:ASPxButton>
                    </td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>

            </tr>
            <tr>
                    <td colspan ="1">
                        <dx:ASPxLabel ID="ASPxLabel55" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Client Name" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                <td colspan ="1">
                    <dx:ASPxTextBox ID="txtClientNo9" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="250px">
                    </dx:ASPxTextBox>
                    </td>
                <td colspan ="1">
                    <dx:ASPxButton ID="ASPxButton6" runat="server" Text="&gt;&gt;" Theme="BlackGlass">
                    </dx:ASPxButton>
                    </td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>

            </tr>
            <tr>
                <td colspan ="1">
                    <dx:ASPxLabel ID="ASPxLabel56" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Surname" Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                <td colspan ="7">
                    <dx:ASPxTextBox ID="ASPxTextBox19" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="710px">
                    </dx:ASPxTextBox>
                </td>

            </tr>
            <tr>
                    <td colspan ="1">
                        <dx:ASPxLabel ID="ASPxLabel57" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Other Names" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                <td colspan ="7">
                    <dx:ASPxTextBox ID="ASPxTextBox20" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="710px">
                    </dx:ASPxTextBox>
                    </td>

            </tr>
         
        </table>

    </asp:panel>
        <asp:panel id="Panel11" runat="server" GroupingText="Pledge Details" Font-Names="Cambria">
        <table width="810px">
            <tr>
                    <td colspan ="1">
                        &nbsp;</td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>

            </tr>
            <tr>
                    <td colspan ="1">
                        <dx:ASPxLabel ID="ASPxLabel58" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Company" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                <td colspan ="1">
                    <dx:ASPxComboBox ID="cmbIndustry1" runat="server" Theme="BlackGlass" ValueType="System.String" Width="250px">
                    </dx:ASPxComboBox>
                    </td>
                <td colspan ="1">
                    <dx:ASPxLabel ID="ASPxLabel59" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Security Type" Theme="Glass">
                    </dx:ASPxLabel>
                    </td>
                <td colspan ="1">
                    <dx:ASPxComboBox ID="cmbIndustry2" runat="server" Theme="BlackGlass" ValueType="System.String" Width="250px">
                    </dx:ASPxComboBox>
                    </td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>

            </tr>
             <tr>
                    <td colspan ="1">
                        <dx:ASPxLabel ID="ASPxLabel60" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Quantity" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                <td colspan ="1">
                    <dx:ASPxTextBox ID="txtClientNo10" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="250px">
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
                        <dx:ASPxLabel ID="ASPxLabel61" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Effective Date" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                <td colspan ="1">
                    <dx:ASPxDateEdit ID="txtEffectiveDate" runat="server" Theme="BlackGlass" Width="250px">
                    </dx:ASPxDateEdit>
                    </td>
                <td colspan ="1">
                    <dx:ASPxLabel ID="ASPxLabel62" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Expiry Date" Theme="Glass">
                    </dx:ASPxLabel>
                    </td>
                <td colspan ="1">
                    <dx:ASPxDateEdit ID="txtEffectiveDate0" runat="server" Theme="BlackGlass" Width="250px">
                    </dx:ASPxDateEdit>
                    </td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>

            </tr>
               
        </table>

    </asp:panel>
        <asp:panel id="Panel10" runat="server" GroupingText="Pledgee Details" Font-Names="Cambria">
        <table width="810px">
            <tr>
                    <td colspan="8" align="center">
                        <asp:RadioButton ID="rdAccHolder" runat="server" AutoPostBack="True" GroupName="AccHolder" Text="Account Holder" />
                        <asp:RadioButton ID="rdAccHolder0" runat="server" AutoPostBack="True" GroupName="AccHolder" Text="Non-account Holder" />
                    </td>

            </tr>
              <tr>
                    <td colspan ="1">
                        <dx:ASPxLabel ID="ASPxLabel5" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Client ID." Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                <td colspan ="1">
                    <dx:ASPxTextBox ID="ASPxTextBox2" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="250px">
                    </dx:ASPxTextBox>
                    </td>
                <td colspan ="1">
                    <dx:ASPxButton ID="ASPxButton1" runat="server" Text="&gt;&gt;" Theme="BlackGlass">
                    </dx:ASPxButton>
                    </td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>

            </tr>
            <tr>
                    <td colspan ="1">
                        <dx:ASPxLabel ID="ASPxLabel6" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Client Name" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                <td colspan ="1">
                    <dx:ASPxTextBox ID="ASPxTextBox3" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="250px">
                    </dx:ASPxTextBox>
                    </td>
                <td colspan ="1">
                    <dx:ASPxButton ID="ASPxButton2" runat="server" Text="&gt;&gt;" Theme="BlackGlass">
                    </dx:ASPxButton>
                    </td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>

            </tr>
            <tr>
                <td colspan ="1">
                    <dx:ASPxLabel ID="ASPxLabel7" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Surname" Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                <td colspan ="7">
                    <dx:ASPxTextBox ID="ASPxTextBox4" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="710px">
                    </dx:ASPxTextBox>
                </td>

            </tr>
            <tr>
                    <td colspan ="1">
                        <dx:ASPxLabel ID="ASPxLabel8" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Other Names" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                <td colspan ="7">
                    <dx:ASPxTextBox ID="ASPxTextBox5" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="710px">
                    </dx:ASPxTextBox>
                    </td>

            </tr>
                     
           <tr>
               <td colspan ="1">
                   <dx:ASPxLabel ID="ASPxLabel18" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Address" Theme="Glass">
                   </dx:ASPxLabel>
               </td>
               <td colspan ="7">
                   <dx:ASPxTextBox ID="ASPxTextBox16" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="710px">
                   </dx:ASPxTextBox>
               </td>

           </tr>
             <tr>
               <td colspan ="1">
                   &nbsp;</td>
               <td colspan ="7">
                   <dx:ASPxTextBox ID="ASPxTextBox17" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="710px">
                   </dx:ASPxTextBox>
               </td>

           </tr>
            <tr>
               <td colspan ="1">
                   &nbsp;</td>
               <td colspan ="7">
                   <dx:ASPxTextBox ID="ASPxTextBox6" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="710px">
                   </dx:ASPxTextBox>
               </td>

           </tr>
            <tr>
               <td colspan ="1">
                   <dx:ASPxLabel ID="ASPxLabel63" runat="server" Font-Names="Cambria" Font-Size="Small" Text="City" Theme="Glass">
                   </dx:ASPxLabel>
                </td>
               <td colspan ="7">
                   <dx:ASPxTextBox ID="ASPxTextBox7" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="710px">
                   </dx:ASPxTextBox>
               </td>

           </tr>
            <tr>
               <td colspan ="1">
                   <dx:ASPxLabel ID="ASPxLabel64" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Country" Theme="Glass">
                   </dx:ASPxLabel>
                </td>
               <td colspan ="7">
                   <dx:ASPxTextBox ID="ASPxTextBox8" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="710px">
                   </dx:ASPxTextBox>
               </td>

           </tr>
            <tr>
               <td colspan ="1" style="height: 23px">
                   </td>
               <td colspan ="7" style="height: 23px">
                   <dx:ASPxTextBox ID="ASPxTextBox9" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="710px">
                   </dx:ASPxTextBox>
               </td>

           </tr>
        
            <tr>
                    <td colspan ="1"></td>
                <td colspan ="7" align="center">
                    <asp:RadioButton ID="rdApprove" runat="server" AutoPostBack="True" GroupName="Approval" Text="Approve" />
                    <asp:RadioButton ID="rdReject" runat="server" AutoPostBack="True" GroupName="Approval" Text="Reject" />
                    </td>

            </tr>
            <tr>
                    <td colspan ="8" align ="center">
                        <dx:ASPxButton ID="ASPxButton3" runat="server" Text="save" Theme="BlackGlass">
                        </dx:ASPxButton>
                    </td>

            </tr>
        </table>

    </asp:panel>
         
                 
</asp:Panel>
  
</div>
</asp:Content>

