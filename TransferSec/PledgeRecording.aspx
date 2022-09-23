<%@ Page Language="VB" MasterPageFile="~/CDSUser.master" AutoEventWireup="false" CodeFile="PledgeRecording.aspx.vb" Inherits="Enquiries_PledgeRecording" title="Account Details Enquiry" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<asp:Content id="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
    <asp:Panel id="Panel1" runat="server" Width="840px" Font-Names="Arial" Font-Size="Medium" BackColor="White">
    
        <table width ="810px">
            <tr>
                   <td style ="text-align :left;" align="left">
                       <dx:ASPxLabel ID="ASPxLabel1" runat="server" Text="Pledges&gt;&gt;Pledge Recording" Font-Names="Cambria" Font-Size="Small" Theme="PlasticBlue"></dx:ASPxLabel>

                   </td>
            </tr>
        </table>
        <asp:Panel runat="server" ID="PanelType" Font-Names="Cambria" GroupingText="Type">

            <table width ="810px">
                <tr>
                        <td colspan ="8" align="center">


                            <asp:RadioButton ID="rdVoluntary" runat="server" AutoPostBack="True" GroupName="PledgeType" Text="Voluntary" />
                            <asp:RadioButton ID="rdForced" runat="server" AutoPostBack="True" GroupName="PledgeType" Text="Forced" />


                        </td>

                </tr>
                <tr>
                    <td colspan ="1" style="width: 101px">
                        <dx:ASPxLabel ID="ASPxLabel52" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Reason" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td colspan ="7">
                        <dx:ASPxTextBox ID="txtPledgeReason" runat="server" AutoResizeWithContainer="True" BackColor="#E4E4E4" Theme="BlackGlass" Width="710px">
                            <Paddings PaddingBottom="30px" />
                        </dx:ASPxTextBox>
                    </td>
                </tr>
                <tr>
                        <td colspan ="1" style="width: 101px">
                            &nbsp;</td>
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
                        <td colspan ="1" style="height: 18px; width: 101px;"></td>
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
        <table width="810px">
            <tr>
                    <td colspan ="1" style="width: 90px">
                        <dx:ASPxLabel ID="ASPxLabel54" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Pin No." Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                <td colspan ="1">
                    <dx:ASPxTextBox ID="txtcds_number_search" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="250px">
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
                    <td colspan ="1" style="width: 90px">
                        <dx:ASPxLabel ID="ASPxLabel55" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Client Name" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                <td colspan ="1">
                    <dx:ASPxTextBox ID="txtNameSearch" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="250px">
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
                    <td colspan ="1" style="width: 90px"></td>
                <td colspan ="7">
                    <dx:ASPxListBox ID="lstNameSearch" runat="server" ValueType="System.String" AutoPostBack="True" Theme="Glass" Width="710px"></dx:ASPxListBox>

                </td>

            </tr>
            <tr>
                    <td colspan ="1" style="width: 90px"></td>
                <td colspan ="7">
                    <dx:ASPxLabel ID="lblClientID" runat="server" Font-Names="Cambria" Font-Size="Small" Theme="Glass">
                    </dx:ASPxLabel>
                    </td>
            </tr>
            <tr>
                <td colspan ="1" style="width: 90px">
                    <dx:ASPxLabel ID="ASPxLabel56" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Pin No." Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                <td colspan ="7">
                    <dx:ASPxTextBox ID="txtpin_no" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="710px">
                    </dx:ASPxTextBox>
                </td>

            </tr>
            <tr>
                    <td colspan ="1" style="width: 90px">
                        <dx:ASPxLabel ID="ASPxLabel57" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Account Name" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                <td colspan ="7">
                    <dx:ASPxTextBox ID="txtaccountname" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="710px">
                    </dx:ASPxTextBox>
                    </td>

            </tr>
         
        </table>

    </asp:panel>
        <asp:panel id="Panel11" runat="server" GroupingText="Pledge Details" Font-Names="Cambria">
        <table width="810px">
            <tr>
                    <td colspan ="1" style="width: 90px">
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
                    <td colspan ="1" style="width: 90px">
                        <dx:ASPxLabel ID="ASPxLabel58" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Company" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                <td colspan ="1">
                    <dx:ASPxComboBox ID="cmbCompany" runat="server" Theme="BlackGlass" ValueType="System.String" Width="250px">
                    </dx:ASPxComboBox>
                    </td>
                <td colspan ="1">
                    <dx:ASPxLabel ID="ASPxLabel59" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Security Type" Theme="Glass">
                    </dx:ASPxLabel>
                    </td>
                <td colspan ="1">
                    <dx:ASPxComboBox ID="cmbSecType" runat="server" Theme="BlackGlass" ValueType="System.String" Width="250px">
                    </dx:ASPxComboBox>
                    </td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>

            </tr>
             <tr>
                    <td colspan ="1" style="width: 90px">
                        <dx:ASPxLabel ID="ASPxLabel60" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Quantity" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                <td colspan ="1">
                    <dx:ASPxTextBox ID="txtQuantity" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="250px">
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
                    <td colspan ="1" style="width: 90px">
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
                    <dx:ASPxDateEdit ID="txtExpiryDate" runat="server" Theme="BlackGlass" Width="250px">
                    </dx:ASPxDateEdit>
                    </td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>

            </tr>
               
        </table>

    </asp:panel>
        <asp:Panel ID="Panel12" runat="server" Font-Names="Cambria" GroupingText="Pledge Options">
            <table width="810px">
                <tr>
                    <td colspan="1" style="width: 91px">&nbsp;</td>
                    <td colspan="1" style="width: 298px"></td>
                    <td colspan="1" style="width: 87px"></td>
                    <td colspan="1"></td>
                    <td colspan="1"></td>
                    <td colspan="1"></td>
                    <td colspan="1"></td>
                    <td colspan="1"></td>
                </tr>
                <tr>
                    <td colspan="1" style="width: 91px">
                        <dx:ASPxLabel ID="ASPxLabel65" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Release" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td colspan="1" style="width: 298px">
                        <dx:ASPxComboBox ID="cmbreleaseoption" runat="server" Theme="BlackGlass" Width="250px">
                            <Items>
                                <dx:ListEditItem Text="Automatically" Value="Automatically" />
                                <dx:ListEditItem Text="Pledgee Confirmation" Value="Pledgee Confirmation" />
                            </Items>
                        </dx:ASPxComboBox>
                    </td>
                    <td colspan="1" style="width: 87px">
                        <dx:ASPxLabel ID="ASPxLabel66" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Income" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td colspan="1">
                        <dx:ASPxComboBox ID="cmb_withincome" runat="server" Theme="BlackGlass" Width="250px">
                            <Items>
                                <dx:ListEditItem Text="Pledge with Income" Value="Yes" />
                                <dx:ListEditItem Text="Pledge Without Income" Value="No" />
                            </Items>
                        </dx:ASPxComboBox>
                    </td>
                    <td colspan="1"></td>
                    <td colspan="1"></td>
                    <td colspan="1"></td>
                    <td colspan="1"></td>
                </tr>
                <tr>
                    <td colspan="1" style="width: 91px">
                        <dx:ASPxLabel ID="ASPxLabel67" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Capital Benefits" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td colspan="1" style="width: 298px">
                        <dx:ASPxComboBox ID="cmbcapital_benefits" runat="server" Theme="BlackGlass" Width="250px">
                            <Items>
                                <dx:ListEditItem Text="With Capital Benefits" Value="Yes" />
                                <dx:ListEditItem Text="Without Capital Benefits" Value="No" />
                            </Items>
                        </dx:ASPxComboBox>
                    </td>
                    <td colspan="1" style="width: 87px"></td>
                    <td colspan="1"></td>
                    <td colspan="1"></td>
                    <td colspan="1"></td>
                    <td colspan="1"></td>
                    <td colspan="1"></td>
                </tr>
            </table>
        </asp:Panel>
        <asp:panel id="Panel10" runat="server" GroupingText="Pledgee Details" Font-Names="Cambria">
        <table width="810px">
            <tr>
                    <td colspan="8" align="center">
                        <asp:RadioButton ID="rdAccHolder" runat="server" AutoPostBack="True" GroupName="AccHolder" Text="Account Holder" />
                        <asp:RadioButton ID="rdnonAccountHolder" runat="server" AutoPostBack="True" GroupName="AccHolder" Text="Non-account Holder" />
                    </td>

            </tr>
              <tr>
                    <td colspan ="1" style="width: 99px">
                        <dx:ASPxLabel ID="ASPxLabel5" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Pin No." Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                <td colspan ="1">
                    <dx:ASPxTextBox ID="txtPledgeeNoSearch" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="250px">
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
                    <td colspan ="1" style="width: 99px">
                        <dx:ASPxLabel ID="ASPxLabel6" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Client Name" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                <td colspan ="1">
                    <dx:ASPxTextBox ID="txtPledgeeNameSearch" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="250px">
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
                <td colspan ="1" style="width: 99px"></td>
                <td colspan ="7"><dx:ASPxListBox ID="lstPledgeeSearch" runat="server" ValueType="System.String" AutoPostBack="True" Width="710px"></dx:ASPxListBox></td>

            </tr>
            <tr>
                    <td colspan ="1" style="width: 99px"></td>
                <td colspan ="7">
                    <dx:ASPxLabel ID="lblPledgeeClientID" runat="server" Font-Names="Cambria" Font-Size="Small" Theme="Glass">
                    </dx:ASPxLabel>
                    </td>

            </tr>
            <tr>
                <td colspan ="1" style="width: 99px">
                    <dx:ASPxLabel ID="ASPxLabel7" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Pin No." Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                <td colspan ="7">
                    <dx:ASPxTextBox ID="txtPledgeepin" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="710px">
                    </dx:ASPxTextBox>
                </td>

            </tr>
            <tr>
                    <td colspan ="1" style="width: 99px">
                        <dx:ASPxLabel ID="ASPxLabel8" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Account Name" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                <td colspan ="7">
                    <dx:ASPxTextBox ID="txtPledgeeforenames" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="710px">
                    </dx:ASPxTextBox>
                    </td>

            </tr>
                     
            <tr>
                <td colspan="1" style="width: 99px">
                    <dx:ASPxLabel ID="ASPxLabel69" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Email" Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                <td colspan="7">
                    <dx:ASPxTextBox ID="txtPledgeemail" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="710px">
                    </dx:ASPxTextBox>
                </td>
            </tr>
                     
           <tr>
               <td colspan ="1" style="width: 99px">
                   <dx:ASPxLabel ID="ASPxLabel18" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Address" Theme="Glass">
                   </dx:ASPxLabel>
               </td>
               <td colspan ="7">
                   <dx:ASPxTextBox ID="txtPledgeeAdd_1" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="710px">
                   </dx:ASPxTextBox>
               </td>

           </tr>
             <tr>
               <td colspan ="1" style="width: 99px">
                   &nbsp;</td>
               <td colspan ="7">
                   <dx:ASPxTextBox ID="txtPledgeeAdd_2" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="710px">
                   </dx:ASPxTextBox>
               </td>

           </tr>
            <tr>
               <td colspan ="1" style="width: 99px">
                   &nbsp;</td>
               <td colspan ="7">
                   <dx:ASPxTextBox ID="txtPledgeeAdd_3" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="710px">
                   </dx:ASPxTextBox>
               </td>

           </tr>
            <tr>
               <td colspan ="1" style="width: 99px">
                   <dx:ASPxLabel ID="ASPxLabel63" runat="server" Font-Names="Cambria" Font-Size="Small" Text="City" Theme="Glass">
                   </dx:ASPxLabel>
                </td>
               <td colspan ="7">
                   <dx:ASPxTextBox ID="txtPledgeeCity" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="710px">
                   </dx:ASPxTextBox>
               </td>

           </tr>
            <tr>
               <td colspan ="1" style="width: 99px">
                   <dx:ASPxLabel ID="ASPxLabel64" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Country" Theme="Glass">
                   </dx:ASPxLabel>
                </td>
               <td colspan ="7">
                   <dx:ASPxTextBox ID="txtPledgeeCounutry" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="710px">
                   </dx:ASPxTextBox>
               </td>

           </tr>
            <tr>
               <td colspan ="1" style="width: 99px">
                   <dx:ASPxLabel ID="ASPxLabel68" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Phone" Theme="Glass">
                   </dx:ASPxLabel>
                </td>
               <td colspan ="7">
                   <dx:ASPxTextBox ID="ASPxTextBox9" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="710px">
                   </dx:ASPxTextBox>
               </td>

           </tr>
        
            <tr>
                    <td colspan ="1" style="width: 99px"></td>
                <td colspan ="7" align="center">
                    <dx:ASPxButton ID="ASPxButton3" runat="server" Text="save" Theme="BlackGlass">
                    </dx:ASPxButton>
                    </td>

            </tr>
            <tr>
                    <td colspan ="8" align ="center">
                        &nbsp;</td>

            </tr>
        </table>

    </asp:panel>
         
                 
</asp:Panel>
  
</div>
</asp:Content>

