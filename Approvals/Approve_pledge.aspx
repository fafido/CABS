<%@ Page  Language="VB" MasterPageFile="~/CDSUser.master" AutoEventWireup="false" CodeFile="Approve_pledge.aspx.vb" Inherits="_Default" title="Approve Pledge" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<asp:Content id="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
    <asp:Panel id="Panel1" runat="server" Width="840px" Font-Names="Arial" Font-Size="Medium" BackColor="White">
    
        <table width ="810px">
            <tr>
                   <td style ="text-align :left;" align="left">
                       <dx:ASPxLabel ID="ASPxLabel1" runat="server" Text="Approvals&gt;&gt;Pledge Approve" Font-Names="Cambria" Font-Size="Small" Theme="PlasticBlue"></dx:ASPxLabel>

                   </td>
            </tr>
        </table>
          <asp:panel id="Panel2" runat="server" GroupingText="Search Pledge(s)" Font-Names="Cambria">
        <table width="810px">
            <tr>
                    <td colspan="8" align="center">
                        &nbsp;</td>

            </tr>
              <tr>
                    <td colspan ="1" style="width: 104px">
                        <dx:ASPxLabel ID="ASPxLabel2" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Pledge ID." Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                <td colspan ="1">
                    <dx:ASPxTextBox ID="txtpledgeid" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="250px">
                    </dx:ASPxTextBox>
                    </td>
                <td colspan ="1">
                    <dx:ASPxButton ID="ASPxButton7" runat="server" Text="&gt;&gt;" Theme="BlackGlass">
                    </dx:ASPxButton>
                    </td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>

            </tr>
            <tr>
                    <td colspan ="1" style="width: 104px">
                        <dx:ASPxLabel ID="ASPxLabel3" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Pledgor Name" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                <td colspan ="1">
                    <dx:ASPxTextBox ID="txtpledgorname" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="250px">
                    </dx:ASPxTextBox>
                    </td>
                <td colspan ="1">
                    <dx:ASPxButton ID="ASPxButton8" runat="server" Text="&gt;&gt;" Theme="BlackGlass">
                    </dx:ASPxButton>
                    </td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>

            </tr>
                     <tr>
                    <td colspan ="1" style="width: 104px">
                        <dx:ASPxLabel ID="ASPxLabel4" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Pledgee Name" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                <td colspan ="1">
                    <dx:ASPxTextBox ID="txtpledgeename" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="250px">
                    </dx:ASPxTextBox>
                    </td>
                <td colspan ="1">
                    <dx:ASPxButton ID="ASPxButton9" runat="server" Text="&gt;&gt;" Theme="BlackGlass">
                    </dx:ASPxButton>
                    </td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>

            </tr>
         
            <tr>
                <td colspan="1" style="width: 104px">&nbsp;</td>
                <td colspan="7">
                    <dx:ASPxListBox ID="lstpledgeSearch" runat="server" AutoPostBack="True" Theme="Glass" ValueType="System.String" Width="710px">
                    </dx:ASPxListBox>
                </td>
            </tr>
         
            <tr>
                    <td colspan ="8" align ="center">
                        &nbsp;</td>

            </tr>
        </table>

    </asp:panel>
      

        <asp:Panel runat="server" ID="PanelType" Font-Names="Cambria" GroupingText="Type">

            <table style="width: 823px">
                <tr>
                        <td colspan ="8" align="center">


                            <asp:RadioButton ID="rdVoluntary" runat="server" AutoPostBack="True" GroupName="PledgeType" Text="Voluntary" Enabled="False" />
                            <asp:RadioButton ID="rdPledgeType" runat="server" AutoPostBack="True" GroupName="PledgeType" Text="Forced" Enabled="False" />


                        </td>

                </tr>
                <tr>
                    <td colspan ="1" style="width: 150px">
                        <dx:ASPxLabel ID="ASPxLabel52" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Reason" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td colspan ="7">
                        <dx:ASPxTextBox ID="txtreasons" runat="server" AutoResizeWithContainer="True" BackColor="#E4E4E4" Theme="BlackGlass" Width="710px">
                            <Paddings PaddingBottom="30px" />
                        </dx:ASPxTextBox>
                    </td>
                </tr>
                <tr>
                        <td colspan ="1" style="width: 150px">
                            &nbsp;</td>
                    <td colspan ="1"></td>
                    <td colspan ="1"></td>
                    <td colspan ="1"></td>
                    <td colspan ="1" align="center">
                        &nbsp;</td>
                    <td colspan ="1"></td>
                    <td colspan ="1"></td>
                    <td colspan ="1"></td>

                </tr>
                     <tr>
                        <td colspan ="1" style="height: 18px; width: 150px;"></td>
                    <td colspan ="1" style="height: 18px"></td>
                    <td colspan ="1" style="height: 18px"></td>
                    <td colspan ="1" style="height: 18px"></td>
                    <td colspan ="1" align="center" style="height: 18px">
                        &nbsp;</td>
                    <td colspan ="1" style="height: 18px"></td>
                    <td colspan ="1" style="height: 18px"></td>
                    <td colspan ="1" style="height: 18px"></td>

                </tr>

            </table>
        </asp:Panel>
        <asp:panel id="Panel8" runat="server" GroupingText="Pledgor Information" Font-Names="Cambria">
        <table style="width: 836px">
            <tr>
                    <td colspan ="1" style="width: 99px">
                        <dx:ASPxLabel ID="ASPxLabel54" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Pin No." Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                <td colspan ="1">
                    <dx:ASPxTextBox ID="txtpledgor_Id" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="250px">
                    </dx:ASPxTextBox>
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
                <td colspan ="1" style="width: 99px">
                    <dx:ASPxLabel ID="ASPxLabel56" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Account Name" Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                <td colspan ="7">
                    <dx:ASPxTextBox ID="txtpledgor_surname" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="710px">
                    </dx:ASPxTextBox>
                </td>

            </tr>
            <tr>
                    <td colspan ="1" style="width: 99px">
                        <dx:ASPxLabel ID="ASPxLabel57" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Other Name" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                <td colspan ="7">
                    <dx:ASPxTextBox ID="txtpledgor_othernames" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="710px">
                    </dx:ASPxTextBox>
                    </td>

            </tr>
         
        </table>

    </asp:panel>
        <asp:panel id="Panel11" runat="server" GroupingText="Pledge Details" Font-Names="Cambria">
        <table width="810px">
            <tr>
                    <td colspan ="1" style="width: 99px">
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
                    <td colspan ="1" style="width: 99px">
                        <dx:ASPxLabel ID="ASPxLabel58" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Company" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                <td colspan ="1">
                    <dx:ASPxTextBox ID="txtcompany" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="250px">
                    </dx:ASPxTextBox>
                    </td>
                <td colspan ="1">
                    <dx:ASPxLabel ID="ASPxLabel59" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Security Type" Theme="Glass">
                    </dx:ASPxLabel>
                    </td>
                <td colspan ="1">
                    <dx:ASPxTextBox ID="txtsecuritytype" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="250px">
                    </dx:ASPxTextBox>
                    </td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>

            </tr>
             <tr>
                    <td colspan ="1" style="width: 99px">
                        <dx:ASPxLabel ID="ASPxLabel60" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Quantity" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                <td colspan ="1">
                    <dx:ASPxTextBox ID="txtquantity" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="250px">
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
                    <td colspan ="1" style="width: 99px">
                        <dx:ASPxLabel ID="ASPxLabel61" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Effective Date" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                <td colspan ="1">
                    <dx:ASPxTextBox ID="txteffectivedate" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="250px">
                    </dx:ASPxTextBox>
                    </td>
                <td colspan ="1">
                    <dx:ASPxLabel ID="ASPxLabel62" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Expiry Date" Theme="Glass">
                    </dx:ASPxLabel>
                    </td>
                <td colspan ="1">
                    <dx:ASPxTextBox ID="txtexpirydate" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="250px">
                    </dx:ASPxTextBox>
                    </td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>

            </tr>
               
        </table>

    </asp:panel>
        <asp:panel id="Panel10" runat="server" GroupingText="Pledgee Details" Font-Names="Cambria">
        <table style="width: 828px">
            <tr>
                    <td colspan="8" align="center">
                        <asp:RadioButton ID="rdAccHolder" runat="server" AutoPostBack="True" GroupName="AccHolder" Text="Account Holder" Enabled="False" />
                        <asp:RadioButton ID="rdAccHolder0" runat="server" AutoPostBack="True" GroupName="AccHolder" Text="Non-account Holder" Enabled="False" />
                    </td>

            </tr>
              <tr>
                    <td colspan ="1" style="width: 102px">
                        <dx:ASPxLabel ID="ASPxLabel5" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Pin No." Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                <td colspan ="1">
                    <dx:ASPxTextBox ID="txtpledgee_client_id" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="250px">
                    </dx:ASPxTextBox>
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
                    <td colspan ="1" style="width: 102px">
                        &nbsp;</td>
                <td colspan ="1">
                    &nbsp;</td>
                <td colspan ="1">
                    &nbsp;</td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>

            </tr>
            <tr>
                <td colspan ="1" style="width: 102px">
                    <dx:ASPxLabel ID="ASPxLabel7" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Account Name" Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                <td colspan ="7">
                    <dx:ASPxTextBox ID="txtpledgee_surname" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="710px">
                    </dx:ASPxTextBox>
                </td>

            </tr>
            <tr>
                    <td colspan ="1" style="width: 102px">
                        <dx:ASPxLabel ID="ASPxLabel8" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Other Name" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                <td colspan ="7">
                    <dx:ASPxTextBox ID="txtpledgee_other_names" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="710px">
                    </dx:ASPxTextBox>
                    </td>

            </tr>
                     
           <tr>
               <td colspan ="1" style="width: 102px">
                   <dx:ASPxLabel ID="ASPxLabel18" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Address" Theme="Glass">
                   </dx:ASPxLabel>
               </td>
               <td colspan ="7">
                   <dx:ASPxTextBox ID="txtpledgee_address" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="710px">
                   </dx:ASPxTextBox>
               </td>

           </tr>
             <tr>
               <td colspan ="1" style="width: 102px">
                   &nbsp;</td>
               <td colspan ="7">
                   <dx:ASPxTextBox ID="txtpledgee_address2" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="710px">
                   </dx:ASPxTextBox>
               </td>

           </tr>
            <tr>
               <td colspan ="1" style="width: 102px">
                   &nbsp;</td>
               <td colspan ="7">
                   <dx:ASPxTextBox ID="txtpledgee_address3" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="710px">
                   </dx:ASPxTextBox>
               </td>

           </tr>
            <tr>
               <td colspan ="1" style="width: 102px">
                   <dx:ASPxLabel ID="ASPxLabel63" runat="server" Font-Names="Cambria" Font-Size="Small" Text="City" Theme="Glass">
                   </dx:ASPxLabel>
                </td>
               <td colspan ="7">
                   <dx:ASPxTextBox ID="txtpledgee_city" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="710px">
                   </dx:ASPxTextBox>
               </td>

           </tr>
            <tr>
               <td colspan ="1" style="width: 102px">
                   <dx:ASPxLabel ID="ASPxLabel64" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Country" Theme="Glass">
                   </dx:ASPxLabel>
                </td>
               <td colspan ="7">
                   <dx:ASPxTextBox ID="txtpledgee_country" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="710px">
                   </dx:ASPxTextBox>
               </td>

           </tr>
            <tr>
               <td colspan ="1" style="width: 102px">
                   &nbsp;</td>
               <td colspan ="7">
                   <dx:ASPxTextBox ID="ASPxTextBox9" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="710px">
                   </dx:ASPxTextBox>
               </td>

           </tr>
            <tr>
                <td colspan="1" style="width: 102px">&nbsp;</td>
                <td align="center" colspan="7">
                    <br />
                    <dx:ASPxButton ID="ASPxButton10" runat="server" Text="Approve" Theme="BlackGlass">
                    </dx:ASPxButton>
                    <br />
                </td>
            </tr>
        </table>

    </asp:panel>


</asp:Panel>
  
</div>
</asp:Content>


