<%@ Page Title="" Language="VB" MasterPageFile="~/CDSUser.master" AutoEventWireup="false" CodeFile="NewAccountCreation.aspx.vb" Inherits="Custodian_NewAccountCreation" %>

<%@ Register TagPrefix="BDP" Namespace="BasicFrame.WebControls" Assembly="BasicFrame.WebControls.BasicDatePicker, Version=1.4.1.41500, Culture=neutral, PublicKeyToken=e1cce521aa9b4849" %>
<%@ Register TagPrefix="dx" Namespace="DevExpress.Web.ASPxEditors" Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" %>
<%@ Register TagPrefix="dx" Namespace="DevExpress.Web.ASPxGridView" Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" %>
<%@ Register TagPrefix="dx" Namespace="DevExpress.Web.ASPxLoadingPanel" Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:panel id="Panel1" runat="server" groupingtext="Account to be Captured" font-names="Cambria">

                <asp:GridView ID="grdApps" runat="server" AllowPaging="True" AutoGenerateColumns="True"
                                HorizontalAlign="Center" CssClass="table table-bordered table-striped tablestyle success"
                                EmptyDataText="0 records found!" EmptyDataRowStyle-CssClass="text-warning text-center">
                                <AlternatingRowStyle CssClass="altrowstyle" />
                                <HeaderStyle CssClass="header info" />
                                <RowStyle CssClass="rowstyle" />
                                <PagerStyle CssClass="pagination-ys" />
                                <Columns>
                                    <asp:CommandField SelectText="Select" ShowSelectButton="True" />
                                </Columns>
                            </asp:GridView>
             </asp:panel>

    <asp:panel id="panelCorp" runat="server" font-names="Cambria" groupingtext="Company Details" visible="False">
            <table style="width: 1004px">
                <tr>
                    <td style="width: 268px; font-size: small;">
                        CDS Number</td>
                    <td colspan="7">
                        <dx:ASPxTextBox ID="txtCdsNumber" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="650px" ReadOnly="True">
                        </dx:ASPxTextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="1" style="width: 268px">
                        <dx:ASPxLabel ID="ASPxLabel26" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Full Company Name" Theme="Glass">
                        </dx:ASPxLabel>
                        <dx:ASPxLabel ID="ASPxLabel56" runat="server" ForeColor="Red" Text="*">
                        </dx:ASPxLabel>
                    </td>
                    <td colspan="7">
                        <dx:ASPxTextBox ID="txtSurname" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" ReadOnly="True" Width="650px">
                        </dx:ASPxTextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="1" style="width: 268px">
                        <dx:ASPxLabel ID="ASPxLabel5" runat="server" Font-Names="Cambria" Font-Size="Small"  Text="Company Code" Theme="Glass">
                        </dx:ASPxLabel>
                        <dx:ASPxLabel ID="ASPxLabel63" runat="server" ForeColor="Red" Text="*">
                        </dx:ASPxLabel>
                    </td>
                    <td colspan="7">
                        <dx:ASPxTextBox ID="txtOthernames" runat="server" BackColor="#E4E4E4" ReadOnly="True" Theme="BlackGlass" Width="650px">
                        </dx:ASPxTextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="1" style="width: 268px">
                        <dx:ASPxLabel ID="ASPxLabel27" runat="server" Font-Names="Cambria" Font-Size="Small" Text="ISIN" Theme="Glass">
                        </dx:ASPxLabel>
                        <dx:ASPxLabel ID="ASPxLabel64" runat="server" Font-Italic="True" Font-Names="Cambria" Font-Size="Small" Text="(if listed)" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td colspan="7">
                        <dx:ASPxTextBox ID="txtMiddleName" ReadOnly="True" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="650px">
                        </dx:ASPxTextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="1" style="width: 268px">
                        <dx:ASPxLabel ID="ASPxLabel65" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Certificate of Incorporation Number" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td colspan="7">
                        <dx:ASPxTextBox ID="txtMiddleName0" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="650px">
                        </dx:ASPxTextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="1" style="width: 268px">
                        <dx:ASPxLabel ID="ASPxLabel32" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Date of Incorporation" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td colspan="7">
                        <dx:ASPxTextBox ID="txtDOB" ReadOnly="True" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="650px">
                        </dx:ASPxTextBox>
                    </td>
                </tr>
                

<%--                <tr>--%>
<%--                    <td colspan="1" style="width: 123px">--%>
<%--                        <dx:ASPxLabel ID="ASPxLabel44" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Nationality" Theme="Glass">--%>
<%--                        </dx:ASPxLabel>--%>
<%--                    </td>--%>
<%--                    <td>--%>
<%--                        <dx:ASPxComboBox ID="cmbNationality" runat="server" Theme="BlackGlass" ValueType="System.String" Width="250px">--%>
<%--                        </dx:ASPxComboBox>--%>
<%--                    </td>--%>
<%--                    <td colspan="1">--%>
<%--                        &nbsp;</td>--%>
<%--                    <td colspan="1">--%>
<%--                        &nbsp;</td>--%>
<%--                    <td colspan="1">&nbsp;</td>--%>
<%--                    <td colspan="1">&nbsp;</td>--%>
<%--                    <td colspan="1">&nbsp;</td>--%>
<%--                    <td colspan="1">&nbsp;</td>--%>
<%--                </tr>--%>
                <tr>
                    <td colspan="1" style="width: 268px">
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                    <td colspan="1"></td>
                    <td colspan="1"></td>
                    <td colspan="1"></td>
                    <td colspan="1"></td>
                    <td colspan="1"></td>
                    <td colspan="1"></td>
                </tr>
            </table>
        </asp:panel>



    <asp:panel id="jointDetails" runat="server" groupingtext="Joint Details" font-names="Cambria">
     <table style="width: 100%">
                   <tr>
              <td class="dxcpCurrentColor_Glass" style="height: 28px; width: 209px;">
                    Joint Account Name<span style="color: red">*</span></td>

             
        
  

<%--               <td colspan ="1" class="dxcpCurrentColor_Glass" style="height: 28px; width: 76px;">--%>
<%--                <asp:Label runat="server" Text="Forenames"></asp:Label><span style="color: red">*</span>--%>
<%--               </td>--%>
               <td class="dxcpCurrentColor_Glass" style="height: 28px; width: 395px;">
                   <asp:TextBox runat="server" ReadOnly="True" ID="joAccName" Width="240px"></asp:TextBox>
               </td>
<%--               <td class="dxcpCurrentColor_Glass" style="height: 28px; width: 51px;">--%>
<%--                   <asp:Label runat="server" Text="Surname"></asp:Label><span style="color: red">*</span>--%>
<%--               </td>--%>
<%--               <td class="dxcpCurrentColor_Glass" style="height: 28px; width: 191px;">--%>
<%--                   <asp:TextBox runat="server"  ID="TextBox3"></asp:TextBox>--%>
<%--               </td>--%>
                       <td class="dxcpCurrentColor_Glass" style="height: 28px; width: 369px;">CDS Number</td>
                       <td class="dxcpCurrentColor_Glass" style="height: 28px; width: 447px;">
                           <asp:TextBox ID="cdsNumbers" ReadOnly="True" runat="server" Width="240px"></asp:TextBox>
                       </td>
           </tr>
        

        </table>
     </asp:panel>

    <asp:panel id="Panel2" runat="server" groupingtext="Personal Details" font-names="Cambria">
     <table style="width: 100%">
                   <tr>
              <td class="dxcpCurrentColor_Glass" style="height: 28px; width: 178px;">
                    <asp:Label runat="server" Text="Id Number"></asp:Label>
               </td>

               <td class="dxcpCurrentColor_Glass" style="height: 28px; width: 194px;">
                   <asp:TextBox runat="server" ReadOnly="True" ID="idNumtext"></asp:TextBox>
               </td>
           </tr>
        

          <tr>
              <td class="dxcpCurrentColor_Glass" style="height: 28px; width: 178px;">
                    <asp:Label runat="server" Text="Title"></asp:Label>
                    </td>

               <td class="dxcpCurrentColor_Glass" style="height: 28px; width: 191px;">
                   <asp:TextBox ID="titleText" ReadOnly="True" runat="server"></asp:TextBox>
                </td>

               <td colspan ="1" class="dxcpCurrentColor_Glass" style="height: 28px; width: 76px;">
                <asp:Label runat="server" Text="Forenames"></asp:Label>&nbsp;</td>
               <td class="dxcpCurrentColor_Glass" style="height: 28px; width: 194px;">
                   <asp:TextBox runat="server" ReadOnly="True" ID="forenamesText"></asp:TextBox>
               </td>
               <td class="dxcpCurrentColor_Glass" style="height: 28px; width: 51px;">
                   <asp:Label runat="server" Text="Surname"></asp:Label>&nbsp;</td>
               <td class="dxcpCurrentColor_Glass" style="height: 28px; width: 191px;">
                   <asp:TextBox runat="server" ReadOnly="True"  ID="surnameText"></asp:TextBox>
               </td>
           </tr>
        
         <tr>
              <td class="dxcpCurrentColor_Glass" style="height: 28px; width: 178px;">
                    <asp:Label runat="server" Text="CDS Number"></asp:Label>&nbsp;</td>

               <td class="dxcpCurrentColor_Glass" style="height: 28px; width: 191px;">
                    <asp:TextBox runat="server" ReadOnly="True" ID="cdsNumberText"></asp:TextBox>
               </td>

               <td colspan ="1" class="dxcpCurrentColor_Glass" style="height: 28px; width: 76px;">
                <asp:Label runat="server" Text="Date of Birth"></asp:Label>
               </td>
               <td class="dxcpCurrentColor_Glass" style="height: 28px; width: 194px;">
                   <asp:TextBox ID="dateOfBirthText" ReadOnly="True" runat="server"></asp:TextBox>
               </td>
               <td class="dxcpCurrentColor_Glass" style="height: 28px; width: 51px;">
                   <asp:Label runat="server" Text="Gender"></asp:Label>&nbsp;</td>
               <td class="dxcpCurrentColor_Glass" style="height: 28px; width: 191px;">
                   <asp:TextBox ID="genderText" ReadOnly="True" runat="server"></asp:TextBox>
<%--                   <asp:TextBox runat="server"  ID="TextBox3"></asp:TextBox>--%>
               </td>
              
               <td class="dxcpCurrentColor_Glass" style="height: 28px; width: 51px;">
<%--                    <asp:Label runat="server" Text="Date of Birth"></asp:Label>--%>
               </td>

               <td class="dxcpCurrentColor_Glass" style="height: 28px; width: 191px;">
<%--                    <asp:TextBox runat="server"  ID="TextBox4"></asp:TextBox>--%>
               </td>
           </tr>
        </table>
     </asp:panel>


    <asp:panel id="Panel4" runat="server" groupingtext="Contact Details" font-names="Cambria">
       <table style="width: 100%">
          <tr>
               <td colspan ="1" class="dxcpCurrentColor_Glass" style="height: 28px; width: 193px;">
                <asp:Label runat="server" Text="Address"></asp:Label>
               </td>
               <td class="dxcpCurrentColor_Glass" style="height: 28px; width: 100%;">
                   <asp:TextBox runat="server" ReadOnly="True" ID="addressText" style="margin-left: 78px" Width="429px"></asp:TextBox>
               </td>
           </tr>
        </table>
        <table style="width: 100%">
          <tr>
               <td colspan ="1" class="dxcpCurrentColor_Glass" style="height: 28px;  width: 149px;">
                <asp:Label runat="server" Text="Country"></asp:Label>&nbsp;</td>
               <td class="dxcpCurrentColor_Glass" style="height: 28px; width: 194px;">
                  
                       <asp:TextBox ID="countryText" ReadOnly="True" runat="server"></asp:TextBox>
               </td>
               <td class="dxcpCurrentColor_Glass" style="height: 28px;  width: 76px;">
                   <asp:Label runat="server" Text="Phone"></asp:Label>
               </td>
               <td class="dxcpCurrentColor_Glass" style="height: 28px; width: 194px;">
                   <asp:TextBox runat="server" ReadOnly="True"  ID="phoneText"></asp:TextBox>
               </td>
              
               <td class="dxcpCurrentColor_Glass" style="height: 28px; width: 51px;">
                   <asp:Label runat="server" Text="Email"></asp:Label>
               </td>

               <td class="dxcpCurrentColor_Glass" style="height: 28px; width: 191px;">
                    <asp:TextBox runat="server" ReadOnly="True" ID="emailText" style="margin-left: 0px" Width="144px"></asp:TextBox>
               </td>
               <td class="dxcpCurrentColor_Glass" style="height: 28px; width: 191px;">&nbsp;</td>
           </tr>
        </table>
    </asp:panel>


    <asp:panel id="Panel3" runat="server" groupingtext="Trading Instructions" font-names="Cambria">
        <table style="width: 100%">
          <tr>
               <td colspan ="1" class="dxcpCurrentColor_Glass" style="height: 28px; width: 120px;">
                <asp:Label runat="server" Text="Shares"></asp:Label>
               </td>
               <td class="dxcpCurrentColor_Glass" style="height: 28px; width: 183px;">
                   <asp:TextBox runat="server" ReadOnly="True" ID="custodyText"></asp:TextBox>
               </td>
               
               <td class="dxcpCurrentColor_Glass" style="height: 28px; width: 42px;">
                   <asp:Label runat="server" Text="Select Custodian"></asp:Label>&nbsp;</td>

               <td class="dxcpCurrentColor_Glass" style="height: 28px; width: 238px;">
                   <asp:TextBox ID="custodianText" ReadOnly="True" runat="server" style="margin-left: 0px" Width="222px"></asp:TextBox>
               </td>
               <td class="dxcpCurrentColor_Glass" style="height: 28px; width: 88px;">&nbsp;</td>

               <td class="dxcpCurrentColor_Glass" style="height: 28px; width: 191px;">&nbsp;</td>
           </tr>
        </table>
    </asp:panel>


    <asp:panel id="Panel5" runat="server" groupingtext="Industry Details" font-names="Cambria">
        <table style="width: 100%">
          <tr>
               <td colspan ="1" class="dxcpCurrentColor_Glass" style="height: 28px;width: 92px;">
                <asp:Label runat="server" Text="Industry"></asp:Label>
               </td>
               <td class="dxcpCurrentColor_Glass" style="height: 28px; width: 191px;">
                   <asp:TextBox runat="server" ReadOnly="True" ID="industryText"></asp:TextBox>
               </td>
               <td class="dxcpCurrentColor_Glass" style="height: 28px; width: 24px;">
                   <asp:Label runat="server" Text="Tax"></asp:Label>
               </td>
               <td class="dxcpCurrentColor_Glass" style="height: 28px; width: 191px;">
                   <asp:TextBox runat="server" ReadOnly="True"  ID="taxText"></asp:TextBox>
               </td>
               <td class="dxcpCurrentColor_Glass" style="height: 28px; width: 191px;">&nbsp;</td>
           </tr>
        </table>
    </asp:panel>


    <asp:panel id="Panel6" runat="server" groupingtext="Banking Details" font-names="Cambria">
     <table style="width: 100%">
             <tr>
                  <td class="dxcpCurrentColor_Glass" style="height: 28px; width: 117px;">
                    <asp:Label runat="server" Text="Payee"></asp:Label>
               </td>

                   <td class="dxcpCurrentColor_Glass" style="height: 28px; width: 51px;">
                    <asp:TextBox runat="server" ReadOnly="True" ID="payeeText"></asp:TextBox>
               </td>
                 <td class="dxcpCurrentColor_Glass" style="height: 28px; width: 130px;">
                     &nbsp;</td>
                 
                  <td class="dxcpCurrentColor_Glass" style="height: 28px; width: 51px;">
                      &nbsp;</td>

                 </tr>

          <tr>
              <td class="dxcpCurrentColor_Glass" style="height: 28px; width: 117px;">
                    <asp:Label runat="server" Text="Bank"></asp:Label>
               </td>

               <td class="dxcpCurrentColor_Glass" style="height: 28px; width: 191px;">

                   <asp:TextBox ID="bankText" ReadOnly="True" runat="server"></asp:TextBox>

               </td>

               <td colspan ="1" class="dxcpCurrentColor_Glass" style="height: 28px; width: 130px;">
                <asp:Label runat="server" Text="Branch"></asp:Label>
               </td>
               <td class="dxcpCurrentColor_Glass" style="height: 28px; width: 194px;">

                   
                       <asp:TextBox ID="branchText" ReadOnly="True" runat="server"></asp:TextBox>

               </td>
               <td class="dxcpCurrentColor_Glass" style="height: 28px; width: 51px;">
                   <asp:Label runat="server" ReadOnly="True" Text="Account"></asp:Label><span style="color: red">*</span>
               </td>
               <td class="dxcpCurrentColor_Glass" style="height: 28px; width: 191px;">
                   <asp:TextBox runat="server" ReadOnly="True"  ID="accountText"></asp:TextBox>
               </td>
           </tr>
        </table>
        
        
        
                   <asp:Panel ID="Panel16" runat="server" Font-Bold="True" Font-Names="Cambria" Font-Size="10pt" GroupingText="Mobile Money Details" Width="785px">
                       <table style="width: 780px; height:30px;">
                           <tr>
                               <td colspan="1" style="height: 46px; width: 108px">
                                   <dx:ASPxLabel ID="ASPxLabel76" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Mobile Money" Theme="Glass">
                                   </dx:ASPxLabel>
                               </td>
                               <td colspan="1" style="height: 46px; width: 249px">
                                   <dx:ASPxTextBox ID="mobileMonetText" ReadOnly="True" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="250px">
                                   </dx:ASPxTextBox>
                               </td>
                               <td colspan="2" style="height: 46px">&nbsp;</td>
                               <td colspan="1" style="height: 46px">&nbsp;</td>
                               <td colspan="1" style="height: 46px">&nbsp;</td>
                               <td colspan="1" style="height: 46px">&nbsp;</td>
                               <td colspan="1" style="height: 46px">&nbsp;</td>
                           </tr>
                           <tr>
                               <td colspan="1" style="height: 46px; width: 108px">
                                   <dx:ASPxLabel ID="ASPxLabel75" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Mobile Number" Theme="Glass">
                                   </dx:ASPxLabel>
                               </td>
                               <td colspan="1" style="height: 46px; width: 249px">
                                   <dx:ASPxTextBox ID="txtmobilemonephone" ReadOnly="True" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="250px">
                                    
                                   </dx:ASPxTextBox>
                               </td>
                               <td colspan="2" style="height: 46px">
                                   &nbsp;</td>
                               <td colspan="1" style="height: 46px"></td>
                               <td colspan="1" style="height: 46px"></td>
                               <td colspan="1" style="height: 46px"></td>
                               <td colspan="1" style="height: 46px"></td>
                           </tr>
                           <tr>
                               <td colspan="1" style="width: 108px"></td>
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
     </asp:panel>


    <asp:panel id="Panel9" runat="server" groupingtext="Attributes" font-names="Cambria">
        <table style="width: 927px">
         <tr>
            <td class="dxcpCurrentColor_Glass" style="height: 28px; width: 120px;">
                       <asp:Label runat="server" Text="Trading Status"></asp:Label>
                </td>
       <td class="dxcpCurrentColor_Glass" style="height: 28px; width: 374px;">

                 
                    <asp:TextBox ID="tradingStatusText" ReadOnly="True" runat="server"></asp:TextBox>

                </td>
            

         </tr>
            <tr>
                <td colspan ="1" style="width: 120px">
                    <asp:Label runat="server" Text="Client Type"></asp:Label>
                </td>
                <td colspan ="1" style="width: 374px">
                    <asp:TextBox ID="clientTypeText" ReadOnly="True" runat="server"></asp:TextBox>
                </td>
                
<%--                runat="server" AutoPostBack="True" Theme="BlackGlass" ValueType="System.String" Width="250px">--%>
<%--                                   </dx:ASPxComboBox>--%>
                <td colspan ="1">
                    Tax</td>
                <td colspan ="1">
                    <asp:TextBox ID="taxText1" ReadOnly="True" runat="server"></asp:TextBox>
                </td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>

            </tr>

        </table>
             </asp:panel>



    <asp:panel id="Panel7" runat="server" font-bold="True" font-names="Cambria" font-size="10pt" groupingtext="Empowerment Segment Declarations" width="785px">
                       <table style="width: 820px; height:30px;">
                           <tr>
                               <td colspan="1" style="height: 9px; width: 429px">
                                   <dx:ASPxLabel ID="ASPxLabel7" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Indegious Zimbabwean?" Theme="Glass">
                                   </dx:ASPxLabel>
                               </td>
                               <td colspan="1" style="height: 9px; width: 249px">
<%--                                   <asp:RadioButtonList runat="server">--%>
                                   <dx:ASPxTextBox ID="indegText" runat="server" ReadOnly="True" BackColor="#E4E4E4" Theme="BlackGlass" Width="250px">
                                   </dx:ASPxTextBox>
                               </td>
                               <td colspan="2" style="height: 9px"></td>
                               <td colspan="1" style="height: 9px"></td>
                               <td colspan="1" style="height: 9px"></td>
                               <td colspan="1" style="height: 9px"></td>
                               <td colspan="1" style="height: 9px"></td>
                           </tr>
                           <tr>
                               <td colspan="1" style="height: 20px; width: 429px">
                                   <dx:ASPxLabel ID="ASPxLabel12" runat="server" Font-Names="Cambria" Font-Size="Small" Text="State your Race" Theme="Glass">
                                   </dx:ASPxLabel>
                               </td>
                               <td colspan="1" style="height: 20px; width: 249px">
                                   <dx:ASPxTextBox ID="raceText" runat="server" ReadOnly="True" BackColor="#E4E4E4" Theme="BlackGlass" Width="250px">
                                   </dx:ASPxTextBox>
                               </td>
                               <td colspan="2" style="height: 20px">
<%--                                   <dx:ASPxCheckBox ID="ASPxCheckBox1" runat="server" AutoPostBack="True" Text="Use Mobile Number">--%>
<%--                                   </dx:ASPxCheckBox>--%>
                               </td>
                               <td colspan="1" style="height: 20px"></td>
                               <td colspan="1" style="height: 20px"></td>
                               <td colspan="1" style="height: 20px"></td>
                               <td colspan="1" style="height: 20px"></td>
                           </tr>
                           
                           <tr>
                               <td colspan="1" style="height: 18px; width: 429px">
                                   <dx:ASPxLabel ID="ASPxLabel14" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Was your race previously disadvantaged?" Theme="Glass">
                                   </dx:ASPxLabel>
                               </td>
                               <td colspan="1" style="height: 18px; width: 249px">
                                     <dx:ASPxTextBox ID="disadvantagedText" ReadOnly="True" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="250px">
                                     </dx:ASPxTextBox>
                               </td>
                               <td colspan="2" style="height: 18px">
<%--                                   <dx:ASPxCheckBox ID="ASPxCheckBox2" runat="server" AutoPostBack="True" Text="Use Mobile Number">--%>
<%--                                   </dx:ASPxCheckBox>--%>
                               </td>
                               <td colspan="1" style="height: 18px"></td>
                               <td colspan="1" style="height: 18px"></td>
                               <td colspan="1" style="height: 18px"></td>
                               <td colspan="1" style="height: 18px"></td>
                           </tr>
                           
                        
                           <tr>
                           <td align="left" colspan="1" style="width: 429px">
                                        <dx:ASPxLabel ID="lblJnationality0" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Nationality" Theme="Glass">
                                        </dx:ASPxLabel>
                                    </td>
                                    <td align="left" colspan="2">
                                        <asp:TextBox ID="nationalityText" ReadOnly="True" runat="server"></asp:TextBox>

                                    </td>
                                 </tr>
                           <tr>
                               <td colspan="1" style="height: 4px; width: 429px">
                                   <dx:ASPxLabel ID="ASPxLabel16" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Nationality By?" Theme="Glass">
                                   </dx:ASPxLabel>
                               </td>
                               <td colspan="1" style="height: 4px; width: 249px">
                                   <dx:ASPxTextBox ID="nationalityByText" runat="server" ReadOnly="True" BackColor="#E4E4E4" Theme="BlackGlass" Width="250px">
                                   </dx:ASPxTextBox>
                               </td>
                               <td colspan="2" style="height: 4px" class="dxcpCurrentColor_PlasticBlue">
                                   </td>
                               <td colspan="1" style="height: 4px" class="dxcpCurrentColor_PlasticBlue"></td>
                               <td colspan="1" style="height: 4px" class="dxcpCurrentColor_PlasticBlue"></td>
                               <td colspan="1" style="height: 4px" class="dxcpCurrentColor_PlasticBlue"></td>
                               <td colspan="1" style="height: 4px" class="dxcpCurrentColor_PlasticBlue"></td>
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


    <asp:panel runat="server" id="panelSave" font-names="Cambria" groupingtext="Attachments">
        
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="True"
                                HorizontalAlign="Center" CssClass="table table-bordered table-striped tablestyle success"
                                EmptyDataText="0 records found!" EmptyDataRowStyle-CssClass="text-warning text-center">
                                <AlternatingRowStyle CssClass="altrowstyle" />
                                <HeaderStyle CssClass="header info" />
                                <RowStyle CssClass="rowstyle" />
                                <PagerStyle CssClass="pagination-ys" />
                                <Columns>
                                    <asp:CommandField SelectText="View" ShowSelectButton="True" />

                                </Columns>
                            </asp:GridView>
        

<%--         <table style="width: 763px">--%>
<%--             <tr>--%>
<%--                    <td align="center">--%>
<%--                        --%>

<%--                        <asp:GridView ID="grdEvent" runat="server" AutoGenerateColumns="False" CellPadding="4" CssClass="tablestyle"--%>
<%--                            EmptyDataText="0 records found!"--%>
<%--                             DataKeyNames="ID" Font-Size="Small" ForeColor="#333333" GridLines="None" Style="position: relative; top: 12px; left: 62px; width: 35%; height: 3px;">--%>
<%--                            <PagerSettings FirstPageText="First" LastPageText="Last" NextPageText="Next" PreviousPageText="Previous" />--%>
<%--                            <AlternatingRowStyle BackColor="White" CssClass="altrowstyle" />--%>
<%--                            <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />--%>
<%--                            <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />--%>
<%--                            <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />--%>
<%--                            <RowStyle BackColor="#FFFBD6" CssClass="rowstyle" ForeColor="#333333" />--%>
<%--                            <Columns>--%>
<%--                                <asp:BoundField DataField="name" HeaderText="Document Name" />--%>
<%--                                <asp:CommandField SelectText="View" ShowSelectButton="true">--%>
<%--                                <ItemStyle Font-Bold="True" Font-Italic="True" ForeColor="Red" />--%>
<%--                                </asp:CommandField>--%>
<%--                            </Columns>--%>
<%--                            <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />--%>
<%--                            <SortedAscendingCellStyle BackColor="#FDF5AC" />--%>
<%--                            <SortedAscendingHeaderStyle BackColor="#4D0000" />--%>
<%--                            <SortedDescendingCellStyle BackColor="#FCF6C0" />--%>
<%--                            <SortedDescendingHeaderStyle BackColor="#820000" />--%>
<%--                        </asp:GridView>--%>
<%--                    </td>--%>
<%--             </tr>--%>
<%----%>
<%--         </table>--%>

     </asp:panel>



    <asp:panel runat="server" id="panel8" font-names="Cambria" groupingtext="&nbsp;">
                 <div style="text-align: center">
                     
                         <table style="width:100%;">
                             <tr>
                                 <td style="width: 331px">&nbsp;</td>
                                 <td style="width: 93px">&nbsp;</td>
                                 <td style="width: 80px">&nbsp;</td>
                                 <td>&nbsp;</td>
                             </tr>
                             <tr>
                                 <td style="width: 331px">&nbsp;</td>
                                 <td style="width: 80px">
                                     <asp:Button runat="server" Text="Accept" OnClick="Unnamed23_Click" />
                                 </td>
                                 <td style="width: 80px">
                                     <asp:Button ID="Button2" runat="server" Text="Reject" />
                                 </td>
                                 <td>&nbsp;</td>
                             </tr>
                             <tr>
                                 <td style="width: 331px">&nbsp;</td>
                                 <td style="width: 93px">&nbsp;</td>
                                 <td style="width: 80px">&nbsp;</td>
                                 <td>&nbsp;</td>
                             </tr>
                              <tr>
                                 <td style="width: 331px">&nbsp;</td>
                                  <td style="width: 93px">&nbsp;</td>
                                 <td style="width: 80px">&nbsp;</td>
                                 <td>&nbsp;</td>
                             </tr>
                         </table>
                     </div>
         </asp:panel>
</asp:Content>
