<%@ Page Language="VB" MasterPageFile="~/CDSUser.master" AutoEventWireup="false" CodeFile="PledgeAmendments.aspx.vb" Inherits="TransferSec_PledgeAmendments" title="Account Details Enquiry" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<asp:Content id="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
    <asp:Panel id="Panel1" runat="server" Width="840px" Font-Names="Arial" Font-Size="Medium" BackColor="White">
    
        <table width ="810px">
            <tr>
                   <td style ="text-align :left;" align="left">
                       <dx:ASPxLabel ID="ASPxLabel1" runat="server" Text="Pledges&gt;&gt;Pledge Amendment" Font-Names="Cambria" Font-Size="Small" Theme="PlasticBlue"></dx:ASPxLabel>

                   </td>
            </tr>
        </table>
<asp:Panel runat="server" ID="SearchOptions" Font-Names="Cambria" GroupingText="Search">
    <table>

        <tr>

                <td colspan ="1">
                    <dx:ASPxLabel ID="ASPxLabel65" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Pledge Search" Theme="Glass">
                    </dx:ASPxLabel>
                </td>
            <td colspan ="7">
                <dx:ASPxComboBox ID="lstpledgesearch" runat="server" Theme="BlackGlass" ValueType="System.String" Width="650px" AutoPostBack="True">
                </dx:ASPxComboBox>
                </td>

        </tr>

    </table>
</asp:Panel>
        <asp:Panel runat="server" ID="Panelselect" Font-Names="Cambria" GroupingText="Amendment Category" Visible="False">

            <table style="width: 823px">
                <tr>
                        <td colspan ="8" align="center" style="height: 24px">


                            &nbsp;</td>

                </tr>
                <tr>
                    <td align="center" colspan="8" style="height: 24px">
                        <dx:ASPxButton ID="ASPxButton11" runat="server" Text="Pledge Details" Theme="BlackGlass">
                        </dx:ASPxButton>
                        &nbsp;
                        <dx:ASPxButton ID="ASPxButton12" runat="server" Text="Pledge Options" Theme="BlackGlass">
                        </dx:ASPxButton>
                    </td>
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
        <asp:Panel ID="PanelType" runat="server" Font-Names="Cambria" GroupingText="Type" Visible="False">
            <table style="width: 823px">
                <tr>
                    <td align="center" colspan="8" style="height: 24px">
                        <asp:RadioButton ID="rdVoluntary" runat="server" AutoPostBack="True" Enabled="False" GroupName="PledgeType" Text="Voluntary" />
                        <asp:RadioButton ID="rdPledgeType" runat="server" AutoPostBack="True" Enabled="False" GroupName="PledgeType" Text="Forced" />
                    </td>
                </tr>
                <tr>
                    <td colspan="1" style="width: 150px">
                        <dx:ASPxLabel ID="ASPxLabel52" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Reason" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td colspan="7">
                        <dx:ASPxTextBox ID="txtreasons" runat="server" AutoResizeWithContainer="True" BackColor="#E4E4E4" Theme="BlackGlass" Width="710px">
                            <Paddings PaddingBottom="30px" />
                        </dx:ASPxTextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="1" style="width: 150px">&nbsp;</td>
                    <td colspan="1"></td>
                    <td colspan="1"></td>
                    <td colspan="1"></td>
                    <td align="center" colspan="1">&nbsp;</td>
                    <td colspan="1"></td>
                    <td colspan="1"></td>
                    <td colspan="1"></td>
                </tr>
                <tr>
                    <td colspan="1" style="height: 18px; width: 150px;"></td>
                    <td colspan="1" style="height: 18px"></td>
                    <td colspan="1" style="height: 18px"></td>
                    <td colspan="1" style="height: 18px"></td>
                    <td align="center" colspan="1" style="height: 18px">&nbsp;</td>
                    <td colspan="1" style="height: 18px"></td>
                    <td colspan="1" style="height: 18px"></td>
                    <td colspan="1" style="height: 18px"></td>
                </tr>
            </table>
        </asp:Panel>
        <asp:panel id="Panel8" runat="server" GroupingText="Pledgor Information" Font-Names="Cambria" Visible="False">
        <table style="width: 836px">
            <tr>
                    <td colspan ="1" style="width: 99px">
                        <dx:ASPxLabel ID="ASPxLabel54" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Client ID." Theme="Glass">
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
                    <dx:ASPxLabel ID="ASPxLabel56" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Surname" Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                <td colspan ="7">
                    <dx:ASPxTextBox ID="txtpledgor_surname" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="710px">
                    </dx:ASPxTextBox>
                </td>

            </tr>
            <tr>
                    <td colspan ="1" style="width: 99px">
                        <dx:ASPxLabel ID="ASPxLabel57" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Other Names" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                <td colspan ="7">
                    <dx:ASPxTextBox ID="txtpledgor_othernames" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="710px">
                    </dx:ASPxTextBox>
                    </td>

            </tr>
         
        </table>

    </asp:panel>
        <asp:panel id="Panel11" runat="server" GroupingText="Old Pledge Details" Font-Names="Cambria">
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
               
            <tr>
                <td align="center" colspan="8">
                    &nbsp;
                    </td>
            </tr>
               
        </table>

    </asp:panel>
        <asp:Panel ID="Panel13" runat="server" Font-Names="Cambria" GroupingText="New Pledge Details">
            <table width="810px">
                <tr>
                    <td colspan="1" style="width: 90px">&nbsp;</td>
                    <td colspan="1"></td>
                    <td colspan="1"></td>
                    <td colspan="1"></td>
                    <td colspan="1"></td>
                    <td colspan="1"></td>
                    <td colspan="1"></td>
                    <td colspan="1"></td>
                </tr>
                <tr>
                    <td colspan="1" style="width: 90px">
                        <dx:ASPxLabel ID="ASPxLabel69" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Company" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td colspan="1">
                        <dx:ASPxComboBox ID="cmbCompany" runat="server" Theme="BlackGlass" ValueType="System.String" Width="250px">
                        </dx:ASPxComboBox>
                    </td>
                    <td colspan="1">
                        <dx:ASPxLabel ID="ASPxLabel70" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Security Type" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td colspan="1">
                        <dx:ASPxComboBox ID="cmbSecurity_Type" runat="server" Theme="BlackGlass" ValueType="System.String" Width="250px">
                        </dx:ASPxComboBox>
                    </td>
                    <td colspan="1"></td>
                    <td colspan="1"></td>
                    <td colspan="1"></td>
                    <td colspan="1"></td>
                </tr>
                <tr>
                    <td colspan="1" style="width: 90px">
                        <dx:ASPxLabel ID="ASPxLabel71" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Quantity" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td colspan="1">
                        <dx:ASPxTextBox ID="txtQuantity0" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="250px">
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
                    <td colspan="1" style="width: 90px">
                        <dx:ASPxLabel ID="ASPxLabel72" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Effective Date" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td colspan="1">
                        <dx:ASPxDateEdit ID="txtEffectiveDate0" runat="server" Theme="BlackGlass" Width="250px">
                        </dx:ASPxDateEdit>
                    </td>
                    <td colspan="1">
                        <dx:ASPxLabel ID="ASPxLabel73" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Expiry Date" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td colspan="1">
                        <dx:ASPxDateEdit ID="txtExpiryDate0" runat="server" Theme="BlackGlass" Width="250px">
                        </dx:ASPxDateEdit>
                    </td>
                    <td colspan="1"></td>
                    <td colspan="1"></td>
                    <td colspan="1"></td>
                    <td colspan="1"></td>
                </tr>
                <tr>
                    <td align="center" colspan="8">
                        &nbsp;</td>
                </tr>
            </table>
        </asp:Panel>
        <asp:Panel ID="Panel12" runat="server" Font-Names="Cambria" GroupingText="Current Pledge Options">
            <table width="810px">
                <tr>
                    <td colspan="1" style="width: 99px">&nbsp;</td>
                    <td colspan="1"></td>
                    <td colspan="1"></td>
                    <td colspan="1"></td>
                    <td colspan="1"></td>
                    <td colspan="1"></td>
                    <td colspan="1"></td>
                    <td colspan="1"></td>
                </tr>
                <tr>
                    <td colspan="1" style="width: 99px">
                        <dx:ASPxLabel ID="ASPxLabel66" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Release Option" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td colspan="1">
                        <dx:ASPxTextBox ID="txtrelease_option" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="250px">
                        </dx:ASPxTextBox>
                    </td>
                    <td colspan="1">
                        <dx:ASPxLabel ID="ASPxLabel67" runat="server" Font-Names="Cambria" Font-Size="Small" Text="With Income" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td colspan="1">
                        <dx:ASPxTextBox ID="txtrelease_income" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="250px">
                        </dx:ASPxTextBox>
                    </td>
                    <td colspan="1"></td>
                    <td colspan="1"></td>
                    <td colspan="1"></td>
                    <td colspan="1"></td>
                </tr>
                <tr>
                    <td colspan="1" style="width: 99px">
                        <dx:ASPxLabel ID="ASPxLabel68" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Capital Benefits" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td colspan="1">
                        <dx:ASPxTextBox ID="txtcapitalbenefits" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="250px">
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
                    <td align="center" colspan="8">
                        &nbsp;</td>
                </tr>
            </table>
        </asp:Panel>
        <asp:Panel ID="Panel14" runat="server" Font-Names="Cambria" GroupingText="New Pledge Options">
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
                        <dx:ASPxLabel ID="ASPxLabel74" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Release" Theme="Glass">
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
                        <dx:ASPxLabel ID="ASPxLabel75" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Income" Theme="Glass">
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
                        <dx:ASPxLabel ID="ASPxLabel76" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Capital Benefits" Theme="Glass">
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
                <tr>
                    <td align="center" colspan="8">
                        <dx:ASPxButton ID="ASPxButton15" runat="server" Text="Update" Theme="BlackGlass">
                        </dx:ASPxButton>
                        &nbsp;</td>
                </tr>
            </table>
        </asp:Panel>
        <asp:panel id="Panel10" runat="server" GroupingText="Pledgee Details" Font-Names="Cambria" Visible="False">
        <table style="width: 828px">
            <tr>
                    <td colspan="8" align="center">
                        <asp:RadioButton ID="rdAccHolder" runat="server" AutoPostBack="True" GroupName="AccHolder" Text="Account Holder" Enabled="False" />
                        <asp:RadioButton ID="rdAccHolder0" runat="server" AutoPostBack="True" GroupName="AccHolder" Text="Non-account Holder" Enabled="False" />
                    </td>

            </tr>
              <tr>
                    <td colspan ="1" style="width: 102px">
                        <dx:ASPxLabel ID="ASPxLabel5" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Client ID." Theme="Glass">
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
                    <dx:ASPxLabel ID="ASPxLabel7" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Surname" Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                <td colspan ="7">
                    <dx:ASPxTextBox ID="txtpledgee_surname" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="710px">
                    </dx:ASPxTextBox>
                </td>

            </tr>
            <tr>
                    <td colspan ="1" style="width: 102px">
                        <dx:ASPxLabel ID="ASPxLabel8" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Other Names" Theme="Glass">
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
        </table>

    </asp:panel>


         <asp:Panel runat="server" ID="PanelRelease" Font-Names="Cambria" GroupingText="Release Details" Visible="False">
             <table>
                 <tr>

                     <td colspan ="1" style="width: 106px">
                         <asp:Label ID="Label2" runat="server" Text="____________"></asp:Label>
                     </td>
                     <td colspan ="7">&nbsp;</td>
                 </tr>
                        <tr>
                            <td colspan ="1" style="width: 106px">
                                <dx:ASPxLabel ID="ASPxLabel2" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Reason" Theme="Glass">
                                </dx:ASPxLabel>
                            </td>
                            <td colspan ="7">
                                <dx:ASPxTextBox ID="txtreleasereason" runat="server" BackColor="#E4E4E4" Height="100px" Theme="BlackGlass" Width="710px">
                                </dx:ASPxTextBox>
                            </td>
                        </tr>
                   <tr>
                        
                    <td colspan ="8" align="center" style="height: 32px">
                        <dx:ASPxButton ID="ASPxButton3" runat="server" Text="Scan" Theme="BlackGlass">
                        </dx:ASPxButton>
                        </td>
                    

                </tr>
                     <tr>
                        <td colspan ="1" style="height: 18px; width: 106px;"></td>
                    <td colspan ="1" style="height: 18px"></td>
                    <td colspan ="1" style="height: 18px"></td>
                    <td colspan ="1" style="height: 18px"></td>
                    <td colspan ="1" align="center" style="height: 18px">
                        <asp:RadioButton ID="RadioButton1" runat="server" AutoPostBack="True" GroupName="DocumentsType" Text="Identity Documents" />
                        <asp:RadioButton ID="RadioButton2" runat="server" AutoPostBack="True" GroupName="DocumentsType" Text="Court Documents" />
                        <asp:RadioButton ID="RadioButton3" runat="server" AutoPostBack="True" GroupName="DocumentsType" Text="Pledge Forms" />
                        <asp:RadioButton ID="RadioButton4" runat="server" AutoPostBack="True" GroupName="DocumentsType" Text="Other" />
                         </td>
                    <td colspan ="1" style="height: 18px"></td>
                    <td colspan ="1" style="height: 18px"></td>
                    <td colspan ="1" style="height: 18px"></td>

                </tr>
                 <tr>

                     <td colspan ="8" align="center">
                         <asp:RadioButton ID="rdAppropriation" runat="server" AutoPostBack="True" GroupName="ReleaseTypes" Text="Appropriation Release" />
                         <asp:RadioButton ID="rdAppropriation0" runat="server" AutoPostBack="True" GroupName="ReleaseTypes" Text="Sell Release" />
                         <asp:RadioButton ID="rdAppropriation1" runat="server" AutoPostBack="True" GroupName="ReleaseTypes" Text="Normal Release" />
                     </td>
                 </tr>
                 <tr>
                        <td colspan ="8" align="center">
                            <dx:ASPxButton ID="ASPxButton10" runat="server" Text="Approve" Theme="BlackGlass">
                            </dx:ASPxButton>
                        </td>

                 </tr>
                 </table>

         </asp:Panel>
                 
</asp:Panel>
  
</div>
</asp:Content>



